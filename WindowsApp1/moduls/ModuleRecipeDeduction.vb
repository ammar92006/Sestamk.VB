Imports System.Data.SqlClient

Public Module ModuleRecipeDeduction

    ''' <summary>
    ''' دالة الخصم الآلي للخامات بناءً على الصنف والحجم والكمية المبيعة
    ''' </summary>
    Public Function DeductRecipeStock(itemID As Integer?, sizeID As Integer?, modifierID As Integer?, soldQty As Decimal, storeID As Integer) As Boolean
        Try
            ' 1. جلب خامات الريسيبي المطلوبة لهذا الصنف/الحجم/الإضافة
            Dim queryRecipe As String = "SELECT MaterialID, Quantity FROM Recipes " &
                                         "WHERE (ItemID = @ItemID OR (@ItemID IS NULL AND ItemID IS NULL)) " &
                                         "AND (SizeID = @SizeID OR (@SizeID IS NULL AND SizeID IS NULL)) " &
                                         "AND (ModifierID = @ModifierID OR (@ModifierID IS NULL AND ModifierID IS NULL))"

            Dim dtRecipe As New DataTable()

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(queryRecipe, conn)
                    cmd.Parameters.AddWithValue("@ItemID", If(itemID.HasValue, itemID.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@SizeID", If(sizeID.HasValue, sizeID.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@ModifierID", If(modifierID.HasValue, modifierID.Value, DBNull.Value))

                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dtRecipe)
                End Using
            End Using

            If dtRecipe.Rows.Count = 0 Then
                ' الصنف ليس له ريسيبي مسجل (لن يتوقف البيع)
                Return True
            End If

            ' 2. التنفيذ داخل Transaction لضمان سلامة الخصم لكل الخامات معاً
            Using conn As New SqlConnection(DBModule.ConnectionString)
                conn.Open()
                Dim transaction As SqlTransaction = conn.BeginTransaction()

                Try
                    For Each row As DataRow In dtRecipe.Rows
                        Dim materialID As Integer = Convert.ToInt32(row("MaterialID"))
                        Dim unitQtyPerItem As Decimal = Convert.ToDecimal(row("Quantity"))
                        Dim totalDeductQty As Decimal = unitQtyPerItem * soldQty ' إجمالي الكمية الخصم = احتياج الوجبة * عدد الوجبات المبيعة

                        ' أ) خصم الكمية من جدول أرصدة المخزن StoreStock
                        Dim updateStockQuery As String = "UPDATE StoreStock SET CurrentStock = CurrentStock - @DeductQty " &
                                                         "WHERE StoreID = @StoreID AND MaterialID = @MaterialID"

                        Using cmdUpdate As New SqlCommand(updateStockQuery, conn, transaction)
                            cmdUpdate.Parameters.AddWithValue("@DeductQty", totalDeductQty)
                            cmdUpdate.Parameters.AddWithValue("@StoreID", storeID)
                            cmdUpdate.Parameters.AddWithValue("@MaterialID", materialID)
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        ' ب) تسجيل حركة مخزونية في StockMovements
                        Dim insertMovementQuery As String = "INSERT INTO StockMovements (StoreID, MaterialID, MovementType, Quantity, CreatedDate) " &
                                                           "VALUES (@StoreID, @MaterialID, 'SALE', @Qty, GETDATE())"

                        Using cmdMove As New SqlCommand(insertMovementQuery, conn, transaction)
                            cmdMove.Parameters.AddWithValue("@StoreID", storeID)
                            cmdMove.Parameters.AddWithValue("@MaterialID", materialID)
                            cmdMove.Parameters.AddWithValue("@Qty", -totalDeductQty) ' بالسالب لأنه خصم مبيعات
                            cmdMove.ExecuteNonQuery()
                        End Using
                    Next

                    transaction.Commit()
                    Return True

                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("خطأ أثناء خصم خامات الريسيبي: " & ex.Message, "خطأ مخزني", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("خطأ في قراءة الريسيبي: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Module