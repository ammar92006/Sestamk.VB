Imports System.Data.SqlClient
Imports System.Collections.Generic

''' <summary>
''' خصم وإرجاع خامات الريسيبي (الوصفات) داخل المعاملة المالية نفسها.
'''
''' إصلاح جوهري (v1.4.0): كان الاستعلام السابق يقرأ عمودين غير موجودين في جدول Recipes
''' هما ItemID و ModifierID، بينما الأعمدة الفعلية هي ProductID و SizeID و AddonID.
''' النتيجة كانت واحدة من اثنتين:
'''   • رمي خطأ "Invalid column name" فيُلغي معاملة البيع بالكامل عند تفعيل خصم الخامات، أو
'''   • خصم خاطئ صامت إن وُجدت الأعمدة القديمة في قاعدة قديمة.
''' كما كان خصم وصفات الأحجام والإضافات لا يحدث إطلاقاً (تُمرَّر Nothing دائماً).
''' </summary>
Public Module InventoryDeductionManager

    ''' <summary>الاستعلام المرجعي لوصفة واحدة: أساسية أو خاصة بحجم أو خاصة بإضافة.</summary>
    Private Const RecipeSelectSql As String =
        "SELECT MaterialID, Quantity FROM Recipes " &
        "WHERE ProductID = @ProductID " &
        "  AND ((@SizeID IS NULL AND SizeID IS NULL) OR SizeID = @SizeID) " &
        "  AND ((@AddonID IS NULL AND AddonID IS NULL) OR AddonID = @AddonID)"

    ''' <summary>
    ''' خصم خامات وصفة واحدة (أساسية أو حجم أو إضافة) داخل المعاملة المالية.
    ''' تُرجع True إن نجحت العملية (حتى لو لم توجد وصفة مسجّلة).
    ''' </summary>
    Public Function DeductItemRecipe(conn As SqlConnection,
                                     trans As SqlTransaction,
                                     storeID As Integer,
                                     productID As Integer?,
                                     sizeID As Integer?,
                                     addonID As Integer?,
                                     soldQuantity As Decimal,
                                     referenceNumber As String) As Boolean
        If Not productID.HasValue OrElse productID.Value <= 0 Then Return True
        If soldQuantity <= 0D Then Return True

        Try
            For Each recipeRow In ReadRecipe(conn, trans, productID.Value, sizeID, addonID)
                Dim materialID As Integer = CInt(recipeRow.MaterialID)
                Dim totalDeducted As Decimal = recipeRow.Quantity * soldQuantity
                ApplyStockDelta(conn, trans, storeID, materialID, -totalDeducted)
                WriteStockMovement(conn, trans, storeID, materialID, "SALE", -totalDeducted, referenceNumber)
            Next
            Return True
        Catch ex As Exception
            Throw New Exception("فشل في خصم الخامات من المخزن: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' إعادة خامات وصفة واحدة إلى المخزن داخل المعاملة المالية.
    ''' </summary>
    Public Function RestoreItemRecipe(conn As SqlConnection,
                                      trans As SqlTransaction,
                                      storeID As Integer,
                                      productID As Integer?,
                                      sizeID As Integer?,
                                      addonID As Integer?,
                                      returnedQuantity As Decimal,
                                      referenceNumber As String) As Boolean
        If Not productID.HasValue OrElse productID.Value <= 0 Then Return True
        If returnedQuantity <= 0D Then Return True

        Try
            For Each recipeRow In ReadRecipe(conn, trans, productID.Value, sizeID, addonID)
                Dim materialID As Integer = CInt(recipeRow.MaterialID)
                Dim totalRestored As Decimal = recipeRow.Quantity * returnedQuantity
                ApplyStockDelta(conn, trans, storeID, materialID, totalRestored)
                WriteStockMovement(conn, trans, storeID, materialID, "RETURN", totalRestored, referenceNumber)
            Next
            Return True
        Catch ex As Exception
            Throw New Exception("فشل في استرجاع خامات الصنف للمخزن: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' خصم خامات سطر فاتورة كامل: الوصفة الأساسية + وصفة الحجم + وصفة كل إضافة.
    ''' </summary>
    Public Function DeductInvoiceLineRecipes(conn As SqlConnection,
                                             trans As SqlTransaction,
                                             storeID As Integer,
                                             productID As Integer?,
                                             sizeID As Integer?,
                                             addonIDs As IEnumerable(Of Integer),
                                             soldQuantity As Decimal,
                                             referenceNumber As String) As Boolean
        If Not productID.HasValue OrElse productID.Value <= 0 Then Return True
        If soldQuantity <= 0D Then Return True

        ' 1) الوصفة الأساسية (بلا حجم وبلا إضافة)
        DeductItemRecipe(conn, trans, storeID, productID, Nothing, Nothing, soldQuantity, referenceNumber)

        ' 2) وصفة الحجم المختار (إن وُجدت)
        If sizeID.HasValue AndAlso sizeID.Value > 0 Then
            DeductItemRecipe(conn, trans, storeID, productID, sizeID, Nothing, soldQuantity, referenceNumber)
        End If

        ' 3) وصفة كل إضافة مختارة
        If addonIDs IsNot Nothing Then
            For Each addonID In addonIDs
                If addonID > 0 Then
                    DeductItemRecipe(conn, trans, storeID, productID, Nothing, addonID, soldQuantity, referenceNumber)
                End If
            Next
        End If

        Return True
    End Function

    ''' <summary>
    ''' إرجاع خامات سطر فاتورة كامل: الوصفة الأساسية + وصفة الحجم + وصفة كل إضافة.
    ''' </summary>
    Public Function RestoreInvoiceLineRecipes(conn As SqlConnection,
                                              trans As SqlTransaction,
                                              storeID As Integer,
                                              productID As Integer?,
                                              sizeID As Integer?,
                                              addonIDs As IEnumerable(Of Integer),
                                              returnedQuantity As Decimal,
                                              referenceNumber As String) As Boolean
        If Not productID.HasValue OrElse productID.Value <= 0 Then Return True
        If returnedQuantity <= 0D Then Return True

        RestoreItemRecipe(conn, trans, storeID, productID, Nothing, Nothing, returnedQuantity, referenceNumber)

        If sizeID.HasValue AndAlso sizeID.Value > 0 Then
            RestoreItemRecipe(conn, trans, storeID, productID, sizeID, Nothing, returnedQuantity, referenceNumber)
        End If

        If addonIDs IsNot Nothing Then
            For Each addonID In addonIDs
                If addonID > 0 Then
                    RestoreItemRecipe(conn, trans, storeID, productID, Nothing, addonID, returnedQuantity, referenceNumber)
                End If
            Next
        End If

        Return True
    End Function

    ' ══════════════════════════════════════════════════════════════════════════════
    ' دوال داخلية مشتركة
    ' ══════════════════════════════════════════════════════════════════════════════

    ''' <summary>صف وصفة: الخامة والكمية لكل وحدة مباعة.</summary>
    Private Class RecipeLine
        Public Property MaterialID As Integer
        Public Property Quantity As Decimal
    End Class

    Private Function ReadRecipe(conn As SqlConnection, trans As SqlTransaction,
                                productID As Integer, sizeID As Integer?, addonID As Integer?) As List(Of RecipeLine)
        Dim rows As New List(Of RecipeLine)
        Using cmd As New SqlCommand(RecipeSelectSql, conn, trans)
            cmd.Parameters.AddWithValue("@ProductID", productID)
            cmd.Parameters.AddWithValue("@SizeID", If(sizeID.HasValue AndAlso sizeID.Value > 0, CObj(sizeID.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@AddonID", If(addonID.HasValue AndAlso addonID.Value > 0, CObj(addonID.Value), DBNull.Value))

            Using rdr = cmd.ExecuteReader()
                While rdr.Read()
                    If Not IsDBNull(rdr("MaterialID")) Then
                        rows.Add(New RecipeLine With {
                            .MaterialID = Convert.ToInt32(rdr("MaterialID")),
                            .Quantity = If(IsDBNull(rdr("Quantity")), 0D, Convert.ToDecimal(rdr("Quantity")))
                        })
                    End If
                End While
            End Using
        End Using
        Return rows
    End Function

    ''' <summary>
    ''' تطبيق فرق على رصيد المخزن: إن لم يكن الصف موجوداً يُنشأ، وإلا يُحدَّث.
    ''' (deductedQty بالسالب للخصم وبالموجب للإرجاع)
    ''' </summary>
    Private Sub ApplyStockDelta(conn As SqlConnection, trans As SqlTransaction,
                                storeID As Integer, materialID As Integer, delta As Decimal)
        Dim sql As String =
            "IF NOT EXISTS (SELECT 1 FROM StoreStock WHERE StoreID = @StoreID AND MaterialID = @MaterialID) " &
            "    INSERT INTO StoreStock (StoreID, MaterialID, CurrentStock) VALUES (@StoreID, @MaterialID, @Delta); " &
            "ELSE " &
            "    UPDATE StoreStock SET CurrentStock = ISNULL(CurrentStock, 0) + @Delta WHERE StoreID = @StoreID AND MaterialID = @MaterialID;"
        Using cmd As New SqlCommand(sql, conn, trans)
            cmd.Parameters.AddWithValue("@StoreID", storeID)
            cmd.Parameters.AddWithValue("@MaterialID", materialID)
            cmd.Parameters.AddWithValue("@Delta", delta)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' <summary>تسجيل حركة المخزن للرقابة والتدقيق (بالسالب للخصم وبالموجب للإرجاع).</summary>
    Private Sub WriteStockMovement(conn As SqlConnection, trans As SqlTransaction,
                                   storeID As Integer, materialID As Integer,
                                   movementType As String, quantity As Decimal, referenceNumber As String)
        Dim sql As String = "INSERT INTO StockMovements (StoreID, MaterialID, MovementType, Quantity, ReferenceID, CreatedDate) " &
                            "VALUES (@StoreID, @MaterialID, @MovementType, @Qty, @Ref, GETDATE());"
        Using cmd As New SqlCommand(sql, conn, trans)
            cmd.Parameters.AddWithValue("@StoreID", storeID)
            cmd.Parameters.AddWithValue("@MaterialID", materialID)
            cmd.Parameters.AddWithValue("@MovementType", movementType)
            cmd.Parameters.AddWithValue("@Qty", quantity)
            cmd.Parameters.AddWithValue("@Ref", If(String.IsNullOrEmpty(referenceNumber), CObj(DBNull.Value), referenceNumber))
            cmd.ExecuteNonQuery()
        End Using
    End Sub

End Module
