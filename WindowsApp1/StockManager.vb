Imports System.Data.SqlClient

' ---------------------------------------------------------
' الكلاس المساعد 1: ProductUnitInfo
' ---------------------------------------------------------
Public Class ProductUnitInfo
    Public Property UnitName As String
    Public Property ConversionFactor As Decimal
End Class

' ---------------------------------------------------------
' الكلاس المساعد 2: StockDisplayItem
' ---------------------------------------------------------
Public Class StockDisplayItem
    Public Property ProductName As String
    Public Property DisplayStockQuantity As String
    Public Property BaseQuantityTotal As Decimal
    Public Property MinQuantity As Decimal

    Public Property ProductId As Integer
    Public Property Stock_ID As String
    Public Property ProductCode As String
    Public Property Partner_ID As Integer
    Public Property CategoryName As String
    Public Property BaseUnitName As String
    Public Property LastUpdate As Date
    Public Property Partner_Name As String
    Public Property ProductImagePath As String

    Public Property ProductImage As Byte()
End Class

' ---------------------------------------------------------
' StockManager
' ---------------------------------------------------------
Public Class StockManager

    ' -----------------------------------------------------
    ' دوال القراءة الآمنة Safe Readers
    ' -----------------------------------------------------
    Private Function SafeGetString(r As SqlDataReader, col As String) As String
        Dim i = r.GetOrdinal(col)
        If r.IsDBNull(i) Then Return ""
        Return Convert.ToString(r.GetValue(i))
    End Function

    Private Function SafeGetDecimal(r As SqlDataReader, col As String) As Decimal
        Dim i = r.GetOrdinal(col)
        If r.IsDBNull(i) Then Return 0D
        Return Convert.ToDecimal(r.GetValue(i))
    End Function

    Private Function SafeGetInt(r As SqlDataReader, col As String) As Integer
        Dim i = r.GetOrdinal(col)
        If r.IsDBNull(i) Then Return 0
        Return Convert.ToInt32(r.GetValue(i))
    End Function

    Private Function SafeGetDate(r As SqlDataReader, col As String) As Date
        Dim i = r.GetOrdinal(col)
        If r.IsDBNull(i) Then Return Date.MinValue
        Return Convert.ToDateTime(r.GetValue(i))
    End Function

    Private Function SafeGetBytes(r As SqlDataReader, col As String) As Byte()
        Dim i = r.GetOrdinal(col)

        If r.IsDBNull(i) Then Return Nothing

        Dim value = r.GetValue(i)

        ' لو فعلاً Byte Array
        If TypeOf value Is Byte() Then
            Return DirectCast(value, Byte())
        End If

        ' لو القيمة String
        If TypeOf value Is String Then
            Dim s As String = CStr(value).Trim()

            ' 1) لو Base64
            Try
                Return Convert.FromBase64String(s)
            Catch
                ' مش Base64
            End Try

            ' 2) لو مسار صورة
            If IO.File.Exists(s) Then
                Try
                    Return IO.File.ReadAllBytes(s)
                Catch
                    Return Nothing
                End Try
            End If

            ' 3) أي شيء آخر → Not Supported
            Return Nothing
        End If

        ' غير معروف
        Return Nothing
    End Function

    Private Function SafeGetImagePath(r As SqlDataReader, col As String) As String
        Dim i = r.GetOrdinal(col)

        If r.IsDBNull(i) Then Return Nothing

        Dim value = r.GetValue(i)

        ' لو القيمة String (مسار الصورة)
        If TypeOf value Is String Then
            Dim path As String = CStr(value).Trim()

            ' لو الملف موجود
            If IO.File.Exists(path) Then
                Return path
            End If
        End If

        ' أي شيء آخر → Not Supported
        Return Nothing
    End Function


    ' ---------------------------------------------------------
    ' الدالة 1: تحليل الكمية DecomposeQuantity
    ' ---------------------------------------------------------
    Private Function DecomposeQuantity(ByVal conn As SqlConnection, ByVal productId As Integer, ByVal totalBaseQuantity As Decimal) As String

        If totalBaseQuantity <= 0 Then Return "لا يوجد مخزون"

        Dim unitsQuery As String = "
            SELECT Unit_Name, Unit_Quantity 
            FROM dbo.ProductUnits 
            WHERE Product_ID = @ProductID
            ORDER BY Unit_Quantity DESC;"

        Dim unitsList As New List(Of ProductUnitInfo)

        Using cmdUnits As New SqlCommand(unitsQuery, conn)
            cmdUnits.Parameters.AddWithValue("@ProductID", productId)

            Using unitReader As SqlDataReader = cmdUnits.ExecuteReader()
                While unitReader.Read()
                    unitsList.Add(New ProductUnitInfo With {
                        .UnitName = If(unitReader.IsDBNull(0), "", unitReader.GetString(0)),
                        .ConversionFactor = If(unitReader.IsDBNull(1), 0D, unitReader.GetDecimal(1))
                    })
                End While
            End Using
        End Using

        ' لو مفيش وحدات أصلاً
        If unitsList.Count = 0 Then
            Return totalBaseQuantity.ToString("N2") & " وحدة"
        End If

        Dim remainingQuantity As Decimal = totalBaseQuantity
        Dim breakdownList As New List(Of String)

        For Each unit In unitsList

            If unit.ConversionFactor <= 0 Then Continue For

            Dim unitCount As Decimal

            Try
                unitCount = Math.Floor(remainingQuantity / unit.ConversionFactor)
            Catch
                Continue For
            End Try

            If unitCount >= 1 Then
                breakdownList.Add($"{unitCount:N0} {unit.UnitName}")
                remainingQuantity -= (unitCount * unit.ConversionFactor)
            End If

            If remainingQuantity <= 0.001D Then Exit For
        Next

        If breakdownList.Count = 0 Then
            Return totalBaseQuantity.ToString("N2") & " وحدة أساسية"
        End If

        Return String.Join(" + ", breakdownList)
    End Function

    Public Function SearchStock(keyword As String) As List(Of StockDisplayItem)

        Dim list As New List(Of StockDisplayItem)

        Dim sql As String = "
SELECT 
    ISNULL(S.Stock_ID, 0) AS Stock_ID,
    P.Product_ID,
    P.Product_Code,
    P.Product_Name,
    P.Product_Image,
    ISNULL(S.Quantity_OnHand, 0) AS Quantity_OnHand,
    ISNULL(S.Min_Quantity, 0) AS Min_Quantity,
    ISNULL(S.Last_Update, GETDATE()) AS Last_Update,
    BU.Unit_Name AS BaseUnit_Name,
    C.Category_Name,
    P.Partner_ID AS SuppliersID,
    V.SuppliersName
FROM
    dbo.Products AS P
LEFT JOIN
    dbo.Stock AS S ON P.Product_ID = S.Product_ID
LEFT JOIN
    dbo.ProductUnits AS BU ON P.BaseUnit_ID = BU.ProductUnit_ID
LEFT JOIN
    dbo.Categories AS C ON P.Category_ID = C.Category_ID
LEFT JOIN
    dbo.Suppliers AS V ON P.Partner_ID = V.SuppliersID
WHERE
    P.Product_Name LIKE '%' + @KW + '%'
    OR P.Product_Code LIKE '%' + @KW + '%'
    OR C.Category_Name LIKE '%' + @KW + '%'
    OR V.SuppliersName LIKE '%' + @KW + '%'
ORDER BY
    P.Product_Name ASC;
"

        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@KW", keyword)

                    Using r = cmd.ExecuteReader()
                        While r.Read()

                            Dim productId As Integer = Convert.ToInt32(r("Product_ID"))
                            Dim qty As Decimal = Convert.ToDecimal(r("Quantity_OnHand"))

                            Dim displayQty As String
                            If qty <= 0 Then
                                displayQty = "غير متوفر"
                            Else
                                displayQty = DecomposeQuantity(cn, productId, qty)
                            End If

                            list.Add(New StockDisplayItem With {
                            .Stock_ID = Convert.ToInt32(r("Stock_ID")),
                            .ProductId = productId,
                            .ProductCode = r("Product_Code").ToString(),
                            .ProductName = r("Product_Name").ToString(),
                            .CategoryName = r("Category_Name").ToString(),
                            .Partner_Name = r("SuppliersName").ToString(),
                            .BaseQuantityTotal = qty,
                            .MinQuantity = Convert.ToDecimal(r("Min_Quantity")),
                            .DisplayStockQuantity = displayQty,
                            .BaseUnitName = r("BaseUnit_Name").ToString(),
                            .LastUpdate = Convert.ToDateTime(r("Last_Update")),
                            .ProductImage = TryCast(r("Product_Image"), Byte())
                        })
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return list

    End Function

    Public Function DeleteStock(stockId As Integer) As Boolean
        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Dim sql As String = "DELETE FROM Stock WHERE Stock_ID = @ID"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@ID", stockId)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Public Function UpdateStock(stockId As Integer,
                            newQuantity As Decimal,
                            newMinQty As Decimal) As Boolean
        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Dim sql As String = "
            UPDATE Stock
            SET Quantity_OnHand = @QTY,
                Min_Quantity = @MinQty,
                Last_Update = GETDATE()
            WHERE Stock_ID = @ID"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@QTY", newQuantity)
                    cmd.Parameters.AddWithValue("@MinQty", newMinQty)
                    cmd.Parameters.AddWithValue("@ID", stockId)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Sub AutoInsertMissingStock(conn As SqlConnection)
        ' 1) نجيب كل المنتجات اللي ملهاش سجل مخزون
        Dim sql As String = "
        SELECT P.Product_ID
        FROM Products P
        LEFT JOIN Stock S ON P.Product_ID = S.Product_ID
        WHERE S.Product_ID IS NULL;"

        Dim missingList As New List(Of Integer)

        Using cmd As New SqlCommand(sql, conn)
            Using r = cmd.ExecuteReader()
                While r.Read()
                    missingList.Add(Convert.ToInt32(r(0)))
                End While
            End Using
        End Using

        ' 2) لو مفيش منتجات ناقصة خلاص نخرج
        If missingList.Count = 0 Then Exit Sub

        ' 3) إدخال المنتجات في جدول Stock بقيم صفر
        For Each ProductId In missingList
            Dim insertSQL As String = "
            INSERT INTO Stock (Product_ID, Quantity_OnHand, Min_Quantity, Last_Update)
            VALUES (@PID, 0, 0, GETDATE());"

            Using cmd As New SqlCommand(insertSQL, conn)
                cmd.Parameters.AddWithValue("@PID", ProductId)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub
    ' ---------------------------------------------------------
    ' الدالة 2: جلب بيانات المخزون وتحليلها
    ' ---------------------------------------------------------
    Public Function GetDecomposedStockData() As List(Of StockDisplayItem)

        Dim stockList As New List(Of StockDisplayItem)

        Dim stockQuery As String = "
                         SELECT 
   S.Stock_ID,
    S.Product_ID,
    P.Product_Code,
    P.Product_Name,
    P.Product_Image,   -- <--- جلب الصورة
    S.Quantity_OnHand,
    S.Min_Quantity,
    S.Last_Update,
    BU.Unit_Name AS BaseUnit_Name,  
    C.Category_Name,                 
    V.SuppliersID ,   
	V.SuppliersName-- <--- جلب اسم المورد
FROM
    dbo.Stock AS S
LEFT JOIN
    dbo.Products AS P ON S.Product_ID = P.Product_ID
LEFT JOIN
    dbo.ProductUnits AS BU ON P.BaseUnit_ID = BU.ProductUnit_ID 
LEFT JOIN
    dbo.Categories AS C ON P.Category_ID = C.Category_ID
LEFT JOIN
    dbo.Suppliers AS V ON P.Partner_ID = V.SuppliersID ;"

        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlCommand(stockQuery, cn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()

                        While reader.Read()

                            Dim productId As Integer = SafeGetInt(reader, "Product_ID")
                            Dim baseQty As Decimal = SafeGetDecimal(reader, "Quantity_OnHand")

                            Dim displayQuantity As String =
                                DecomposeQuantity(cn, productId, baseQty)

                            Dim item As New StockDisplayItem With {
                                .ProductId = productId,
                                .Stock_ID = SafeGetInt(reader, "Stock_ID"),
                                .ProductCode = SafeGetString(reader, "Product_Code"),
                                .ProductName = SafeGetString(reader, "Product_Name"),
                                .Partner_ID = SafeGetInt(reader, "SuppliersID"),
                                .Partner_Name = SafeGetString(reader, "SuppliersName"),
                                .BaseQuantityTotal = baseQty,
                                .MinQuantity = SafeGetDecimal(reader, "Min_Quantity"),
                                .LastUpdate = SafeGetDate(reader, "Last_Update"),
                                .BaseUnitName = SafeGetString(reader, "BaseUnit_Name"),
                                .CategoryName = SafeGetString(reader, "Category_Name"),
                                .ProductImagePath = SafeGetImagePath(reader, "Product_Image"),
                                .DisplayStockQuantity = displayQuantity
                            }

                            stockList.Add(item)
                        End While

                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("حدث خطأ أثناء جلب بيانات المخزون: " & ex.Message, ex)
        End Try

        Return stockList
    End Function
    Public Function GetFilteredStockData(Optional filter As String = "", Optional field As String = "") As List(Of StockDisplayItem)

        Dim stockList As New List(Of StockDisplayItem)

        Dim baseQuery As String =
        "SELECT 
            S.Stock_ID,
            S.Product_ID,
            P.Product_Code,
            P.Product_Name,
            P.Product_Image,
            S.Quantity_OnHand,
            S.Min_Quantity,
            S.Last_Update,
            BU.Unit_Name AS BaseUnit_Name,  
            C.Category_Name,
            V.SuppliersID,
            V.SuppliersName
         FROM dbo.Stock AS S
         LEFT JOIN dbo.Products AS P ON S.Product_ID = P.Product_ID
         LEFT JOIN dbo.ProductUnits AS BU ON P.BaseUnit_ID = BU.ProductUnit_ID 
         LEFT JOIN dbo.Categories AS C ON P.Category_ID = C.Category_ID
         LEFT JOIN dbo.Suppliers AS V ON P.Partner_ID = V.SuppliersID"

        '-----------------------
        '  تحديد عمود البحث
        '-----------------------
        Dim columnName As String = ""
        Select Case field
            Case "كود المنتج" : columnName = "P.Product_Code"
            Case "اسم المنتج" : columnName = "P.Product_Name"
            Case "الوحدة الأساسية" : columnName = "BU.Unit_Name"
            Case "المخزون المتوفر" : columnName = "S.Quantity_OnHand"
            Case "القسم" : columnName = "C.Category_Name"
            Case "اسم المورد" : columnName = "V.SuppliersName"
        End Select

        If filter <> "" AndAlso columnName <> "" Then
            baseQuery &= $" WHERE {columnName} LIKE @filter"
        End If

        Using cmd As New SqlCommand(baseQuery, Conn)
            If filter <> "" AndAlso columnName <> "" Then
                cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")
            End If

            Using reader = cmd.ExecuteReader()
                While reader.Read()

                    Dim productId As Integer = SafeGetInt(reader, "Product_ID")
                    Dim baseQty As Decimal = SafeGetDecimal(reader, "Quantity_OnHand")

                    Dim item As New StockDisplayItem With {
                    .ProductId = productId,
                    .Stock_ID = SafeGetInt(reader, "Stock_ID"),
                    .ProductCode = SafeGetString(reader, "Product_Code"),
                    .ProductName = SafeGetString(reader, "Product_Name"),
                    .Partner_ID = SafeGetInt(reader, "SuppliersID"),
                    .Partner_Name = SafeGetString(reader, "SuppliersName"),
                    .BaseQuantityTotal = baseQty,
                    .MinQuantity = SafeGetDecimal(reader, "Min_Quantity"),
                    .LastUpdate = SafeGetDate(reader, "Last_Update"),
                    .BaseUnitName = SafeGetString(reader, "BaseUnit_Name"),
                    .CategoryName = SafeGetString(reader, "Category_Name"),
                    .ProductImagePath = SafeGetImagePath(reader, "Product_Image"),
                    .DisplayStockQuantity = DecomposeQuantity(Conn, productId, baseQty)
                }

                    stockList.Add(item)
                End While
            End Using
            '.DisplayStockQuantity = DecomposeQuantity(Conn, productId, baseQty)
        End Using

        Return stockList
    End Function

    Private Function LoadAllProductUnits(conn As SqlConnection) _
    As Dictionary(Of Integer, List(Of ProductUnitInfo))

        Dim dict As New Dictionary(Of Integer, List(Of ProductUnitInfo))

        Dim sql As String = "
        SELECT 
            Product_ID,
            Unit_Name,
            Unit_Quantity
        FROM ProductUnits
        ORDER BY Product_ID, Unit_Quantity DESC;
    "

        Using cmd As New SqlCommand(sql, conn)
            Using r = cmd.ExecuteReader()
                While r.Read()

                    Dim productId As Integer = Convert.ToInt32(r("Product_ID"))

                    If Not dict.ContainsKey(productId) Then
                        dict(productId) = New List(Of ProductUnitInfo)
                    End If

                    dict(productId).Add(New ProductUnitInfo With {
                    .UnitName = r("Unit_Name").ToString(),
                    .ConversionFactor = Convert.ToDecimal(r("Unit_Quantity"))
                })
                End While
            End Using
        End Using

        Return dict
    End Function
    Private Function DecomposeQuantityFast(
    productId As Integer,
    totalBaseQuantity As Decimal,
    unitsCache As Dictionary(Of Integer, List(Of ProductUnitInfo))
) As String

        If totalBaseQuantity <= 0 Then
            Return "لا يوجد مخزون"
        End If

        If Not unitsCache.ContainsKey(productId) Then
            Return totalBaseQuantity.ToString("N2") & " وحدة"
        End If

        Dim remaining As Decimal = totalBaseQuantity
        Dim result As New List(Of String)

        For Each unit In unitsCache(productId)

            If unit.ConversionFactor <= 0 Then Continue For

            Dim count As Decimal = Math.Floor(remaining / unit.ConversionFactor)

            If count >= 1 Then
                result.Add($"{count:N0} {unit.UnitName}")
                remaining -= count * unit.ConversionFactor
            End If

            If remaining <= 0.001D Then Exit For
        Next

        If result.Count = 0 Then
            Return totalBaseQuantity.ToString("N2") & " وحدة أساسية"
        End If

        Return String.Join(" + ", result)
    End Function
    'Public Function GetDecomposedStockData_FAST() As List(Of StockDisplayItem)

    '    Dim stockList As New List(Of StockDisplayItem)

    '    Try
    '        Connect()

    '        ' 1) تحميل كل الوحدات مرة واحدة
    '        Dim unitsCache = LoadAllProductUnits(Conn)

    '        ' 2) جلب بيانات المخزون
    '        Dim sql As String = "
    '        SELECT 
    '            S.Stock_ID,
    '            S.Product_ID,
    '            P.Product_Code,
    '            P.Product_Name,
    '            P.Product_Image,
    '            S.Quantity_OnHand,
    '            S.Min_Quantity,
    '            S.Last_Update,
    '            BU.Unit_Name AS BaseUnit_Name,
    '            C.Category_Name,
    '            V.SuppliersID,
    '            V.SuppliersName
    '        FROM Stock S
    '        LEFT JOIN Products P ON S.Product_ID = P.Product_ID
    '        LEFT JOIN ProductUnits BU ON P.BaseUnit_ID = BU.ProductUnit_ID
    '        LEFT JOIN Categories C ON P.Category_ID = C.Category_ID
    '        LEFT JOIN Suppliers V ON P.Partner_ID = V.SuppliersID;
    '    "

    '        Using cmd As New SqlCommand(sql, Conn)
    '            Using r = cmd.ExecuteReader()

    '                While r.Read()

    '                    Dim productId As Integer = SafeGetInt(r, "Product_ID")
    '                    Dim qty As Decimal = SafeGetDecimal(r, "Quantity_OnHand")

    '                    Dim displayQty As String =
    '                    DecomposeQuantityFast(productId, qty, unitsCache)

    '                    stockList.Add(New StockDisplayItem With {
    '                    .Stock_ID = SafeGetInt(r, "Stock_ID"),
    '                    .ProductId = productId,
    '                    .ProductCode = SafeGetString(r, "Product_Code"),
    '                    .ProductName = SafeGetString(r, "Product_Name"),
    '                    .Partner_ID = SafeGetInt(r, "SuppliersID"),
    '                    .Partner_Name = SafeGetString(r, "SuppliersName"),
    '                    .BaseQuantityTotal = qty,
    '                    .MinQuantity = SafeGetDecimal(r, "Min_Quantity"),
    '                    .LastUpdate = SafeGetDate(r, "Last_Update"),
    '                    .BaseUnitName = SafeGetString(r, "BaseUnit_Name"),
    '                    .CategoryName = SafeGetString(r, "Category_Name"),
    '                    .ProductImagePath = SafeGetImagePath(r, "Product_Image"),
    '                    .DisplayStockQuantity = displayQty
    '                })

    '                End While
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        Disconnect()
    '    End Try

    '    Return stockList
    'End Function
    Public Function GetDecomposedStockData_FAST(Optional filter As String = "", Optional field As String = "") As List(Of StockDisplayItem)

        Dim stockList As New List(Of StockDisplayItem)

        Try
            Using cn As SqlConnection = DBModule.NewConn()
                ' 1) تحميل كل الوحدات مرة واحدة
                Dim unitsCache = LoadAllProductUnits(cn)

                ' 2) تحديد عمود البحث (نفس النظام القديم)
                Dim columnName As String = ""
                Select Case field
                    Case "كود المنتج" : columnName = "P.Product_Code"
                    Case "اسم المنتج" : columnName = "P.Product_Name"
                    Case "الوحدة الأساسية" : columnName = "BU.Unit_Name"
                    Case "المخزون المتوفر" : columnName = "S.Quantity_OnHand"
                    Case "القسم" : columnName = "C.Category_Name"
                    Case "اسم المورد" : columnName = "V.SuppliersName"
                End Select

                ' 3) الاستعلام الأساسي
                Dim sql As String = "
            SELECT 
                S.Stock_ID,
                S.Product_ID,
                P.Product_Code,
                P.Product_Name,
                P.Product_Image,
                S.Quantity_OnHand,
                S.Min_Quantity,
                S.Last_Update,
                BU.Unit_Name AS BaseUnit_Name,
                C.Category_Name,
                V.SuppliersID,
                V.SuppliersName
            FROM Stock S
            LEFT JOIN Products P ON S.Product_ID = P.Product_ID
            LEFT JOIN ProductUnits BU ON P.BaseUnit_ID = BU.ProductUnit_ID
            LEFT JOIN Categories C ON P.Category_ID = C.Category_ID
            LEFT JOIN Suppliers V ON P.Partner_ID = V.SuppliersID
            "

                ' 4) إضافة الفلتر لو موجود
                If filter <> "" AndAlso columnName <> "" Then
                    sql &= $" WHERE {columnName} LIKE @filter"
                End If

                Using cmd As New SqlCommand(sql, cn)

                    If filter <> "" AndAlso columnName <> "" Then
                        cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")
                    End If

                    Using r = cmd.ExecuteReader()
                        While r.Read()

                            Dim productId As Integer = SafeGetInt(r, "Product_ID")
                            Dim qty As Decimal = SafeGetDecimal(r, "Quantity_OnHand")

                            Dim displayQty As String =
                            DecomposeQuantityFast(productId, qty, unitsCache)

                            stockList.Add(New StockDisplayItem With {
                            .Stock_ID = SafeGetInt(r, "Stock_ID"),
                            .ProductId = productId,
                            .ProductCode = SafeGetString(r, "Product_Code"),
                            .ProductName = SafeGetString(r, "Product_Name"),
                            .Partner_ID = SafeGetInt(r, "SuppliersID"),
                            .Partner_Name = SafeGetString(r, "SuppliersName"),
                            .BaseQuantityTotal = qty,
                            .MinQuantity = SafeGetDecimal(r, "Min_Quantity"),
                            .LastUpdate = SafeGetDate(r, "Last_Update"),
                            .BaseUnitName = SafeGetString(r, "BaseUnit_Name"),
                            .CategoryName = SafeGetString(r, "Category_Name"),
                            .ProductImagePath = SafeGetImagePath(r, "Product_Image"),
                            .DisplayStockQuantity = displayQty
                        })

                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return stockList
    End Function


End Class
