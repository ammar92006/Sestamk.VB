Imports System.Data.SqlClient

Public Module InventoryDeductionManager

    ''' <summary>
    ''' خصم خامات الريسيبي لصنف أو إضافة داخل المعاملة المالية (Transaction)
    ''' </summary>
    Public Function DeductItemRecipe(conn As SqlConnection,
                                     trans As SqlTransaction,
                                     storeID As Integer,
                                     productID As Integer?,
                                     sizeID As Integer?,
                                     addonID As Integer?,
                                     soldQuantity As Decimal,
                                     referenceNumber As String) As Boolean
        Try
            ' 1. قراءة مكونات الريسيبي المطلوبة
            Dim recipeSql As String = "SELECT MaterialID, Quantity FROM Recipes " &
                                      "WHERE ((ItemID = @ProductID OR (@ProductID IS NULL AND ItemID IS NULL))) " &
                                      "AND ((SizeID = @SizeID OR (@SizeID IS NULL AND SizeID IS NULL))) " &
                                      "AND ((ModifierID = @AddonID OR (@AddonID IS NULL AND ModifierID IS NULL)))"

            Dim dtRecipe As New DataTable()
            Using cmdRecipe As New SqlCommand(recipeSql, conn, trans)
                cmdRecipe.Parameters.AddWithValue("@ProductID", If(productID.HasValue, productID.Value, DBNull.Value))
                cmdRecipe.Parameters.AddWithValue("@SizeID", If(sizeID.HasValue, sizeID.Value, DBNull.Value))
                cmdRecipe.Parameters.AddWithValue("@AddonID", If(addonID.HasValue, addonID.Value, DBNull.Value))

                Using da As New SqlDataAdapter(cmdRecipe)
                    da.Fill(dtRecipe)
                End Using
            End Using

            ' إذا لم يكن هناك ريسيبي مسجل، يتم تخطي الصنف دون إيقاف الفاتورة
            If dtRecipe.Rows.Count = 0 Then Return True

            ' 2. تنفيذ الخصم السريع لكل خامة
            For Each row As DataRow In dtRecipe.Rows
                Dim materialID As Integer = Convert.ToInt32(row("MaterialID"))
                Dim qtyPerUnit As Decimal = Convert.ToDecimal(row("Quantity"))
                Dim totalDeducted As Decimal = qtyPerUnit * soldQuantity

                ' أ) التأكد من وجود الخامة ثم خصم الكمية في استعلام واحد متكامل
                Dim sqlStock As String = "IF NOT EXISTS (SELECT 1 FROM StoreStock WHERE StoreID = @StoreID AND MaterialID = @MaterialID) " &
                                         "    INSERT INTO StoreStock (StoreID, MaterialID, CurrentStock) VALUES (@StoreID, @MaterialID, -@DeductQty); " &
                                         "ELSE " &
                                         "    UPDATE StoreStock SET CurrentStock = CurrentStock - @DeductQty WHERE StoreID = @StoreID AND MaterialID = @MaterialID;"

                Using cmdStock As New SqlCommand(sqlStock, conn, trans)
                    cmdStock.Parameters.AddWithValue("@StoreID", storeID)
                    cmdStock.Parameters.AddWithValue("@MaterialID", materialID)
                    cmdStock.Parameters.AddWithValue("@DeductQty", totalDeducted)
                    cmdStock.ExecuteNonQuery()
                End Using

                ' ب) تسجيل حركة المخزن بالسالب للرقابة والتدقيق
                Dim sqlMovement As String = "INSERT INTO StockMovements (StoreID, MaterialID, MovementType, Quantity, ReferenceID, CreatedDate) " &
                                            "VALUES (@StoreID, @MaterialID, 'SALE', @Qty, @Ref, GETDATE());"

                Using cmdMove As New SqlCommand(sqlMovement, conn, trans)
                    cmdMove.Parameters.AddWithValue("@StoreID", storeID)
                    cmdMove.Parameters.AddWithValue("@MaterialID", materialID)
                    cmdMove.Parameters.AddWithValue("@Qty", -totalDeducted)
                    cmdMove.Parameters.AddWithValue("@Ref", If(String.IsNullOrEmpty(referenceNumber), DBNull.Value, referenceNumber))
                    cmdMove.ExecuteNonQuery()
                End Using
            Next

            Return True
        Catch ex As Exception
            Throw New Exception("فشل في خصم الخامات من المخزن: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' إعادة خامات الريسيبي لصنف مرتجع داخل المعاملة المالية (Transaction)
    ''' </summary>
    Public Function RestoreItemRecipe(conn As SqlConnection,
                                      trans As SqlTransaction,
                                      storeID As Integer,
                                      productID As Integer?,
                                      sizeID As Integer?,
                                      addonID As Integer?,
                                      returnedQuantity As Decimal,
                                      referenceNumber As String) As Boolean
        Try
            Dim recipeSql As String = "SELECT MaterialID, Quantity FROM Recipes " &
                                      "WHERE ((ItemID = @ProductID OR (@ProductID IS NULL AND ItemID IS NULL))) " &
                                      "AND ((SizeID = @SizeID OR (@SizeID IS NULL AND SizeID IS NULL))) " &
                                      "AND ((ModifierID = @AddonID OR (@AddonID IS NULL AND ModifierID IS NULL)))"

            Dim dtRecipe As New DataTable()
            Using cmdRecipe As New SqlCommand(recipeSql, conn, trans)
                cmdRecipe.Parameters.AddWithValue("@ProductID", If(productID.HasValue, productID.Value, DBNull.Value))
                cmdRecipe.Parameters.AddWithValue("@SizeID", If(sizeID.HasValue, sizeID.Value, DBNull.Value))
                cmdRecipe.Parameters.AddWithValue("@AddonID", If(addonID.HasValue, addonID.Value, DBNull.Value))

                Using da As New SqlDataAdapter(cmdRecipe)
                    da.Fill(dtRecipe)
                End Using
            End Using

            If dtRecipe.Rows.Count = 0 Then Return True

            For Each row As DataRow In dtRecipe.Rows
                Dim materialID As Integer = Convert.ToInt32(row("MaterialID"))
                Dim qtyPerUnit As Decimal = Convert.ToDecimal(row("Quantity"))
                Dim totalRestored As Decimal = qtyPerUnit * returnedQuantity

                Dim sqlStock As String = "IF NOT EXISTS (SELECT 1 FROM StoreStock WHERE StoreID = @StoreID AND MaterialID = @MaterialID) " &
                                         "    INSERT INTO StoreStock (StoreID, MaterialID, CurrentStock) VALUES (@StoreID, @MaterialID, @RestoredQty); " &
                                         "ELSE " &
                                         "    UPDATE StoreStock SET CurrentStock = CurrentStock + @RestoredQty WHERE StoreID = @StoreID AND MaterialID = @MaterialID;"

                Using cmdStock As New SqlCommand(sqlStock, conn, trans)
                    cmdStock.Parameters.AddWithValue("@StoreID", storeID)
                    cmdStock.Parameters.AddWithValue("@MaterialID", materialID)
                    cmdStock.Parameters.AddWithValue("@RestoredQty", totalRestored)
                    cmdStock.ExecuteNonQuery()
                End Using

                Dim sqlMovement As String = "INSERT INTO StockMovements (StoreID, MaterialID, MovementType, Quantity, ReferenceID, CreatedDate) " &
                                            "VALUES (@StoreID, @MaterialID, 'RETURN', @Qty, @Ref, GETDATE());"

                Using cmdMove As New SqlCommand(sqlMovement, conn, trans)
                    cmdMove.Parameters.AddWithValue("@StoreID", storeID)
                    cmdMove.Parameters.AddWithValue("@MaterialID", materialID)
                    cmdMove.Parameters.AddWithValue("@Qty", totalRestored)
                    cmdMove.Parameters.AddWithValue("@Ref", If(String.IsNullOrEmpty(referenceNumber), DBNull.Value, referenceNumber))
                    cmdMove.ExecuteNonQuery()
                End Using
            Next

            Return True
        Catch ex As Exception
            Throw New Exception("فشل في استرجاع خامات الصنف للمخزن: " & ex.Message)
        End Try
    End Function

End Module