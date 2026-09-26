Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Text

Module ReportsModule


    Private Sub SafeAddParam(cmd As SqlCommand, name As String, value As Object)
        If value Is Nothing Then
            cmd.Parameters.AddWithValue(name, DBNull.Value)
        Else
            cmd.Parameters.AddWithValue(name, value)
        End If
    End Sub

    Private Sub NormalizeDateRange(ByRef fromDate As Nullable(Of Date), ByRef toDate As Nullable(Of Date))
        If Not fromDate.HasValue AndAlso Not toDate.HasValue Then
            toDate = DateTime.Now.Date
            fromDate = toDate.Value.AddDays(-30)
            Return
        End If

        If fromDate.HasValue AndAlso Not toDate.HasValue Then
            toDate = fromDate.Value.Date.AddDays(1).AddSeconds(-1)
            fromDate = fromDate.Value.Date
            Return
        End If

        If Not fromDate.HasValue AndAlso toDate.HasValue Then
            fromDate = toDate.Value.Date.AddDays(-30)
            toDate = toDate.Value.Date.AddDays(1).AddSeconds(-1)
            Return
        End If

        If fromDate.Value > toDate.Value Then
            Dim temp = fromDate
            fromDate = toDate
            toDate = temp
        End If

        fromDate = fromDate.Value.Date
        toDate = toDate.Value.Date.AddDays(1).AddSeconds(-1)
    End Sub
    Public Function GetAllInvoicesPurchase() As DataTable
        Dim dt As New DataTable()
        Dim Maxnum As Integer = 250

        Try
            Connect()

            Dim sql As String = $"
            SELECT TOP {Maxnum}
               PH.Purchase_Id,
               PH.Purchase_type,
               PH.Purchase_Date,
               S.SuppliersID,
               S.SuppliersName,
               PH.Net_Amount,
               PH.Discount_Value,
               PH.Total_Amount,
               PH.Amount_Paid,
               PH.Remaining,
               PH.Notes,
               PH.purchases_Image,
               PH.User_ID,
               PH.User_Name
           FROM Purchase_Header PH
           LEFT JOIN Suppliers S ON PH.Supplier_ID = S.SuppliersID
           ORDER BY PH.Purchase_Id DESC"

            Using cmd As New SqlCommand(sql, Conn)
                cmd.CommandTimeout = 120

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function
    Public Function GetAllInvoices() As DataTable
        Dim dt As New DataTable()
        Dim Maxnum As Integer = 250

        Try
            Connect()

            Dim sql As String = $"
            SELECT TOP {Maxnum}
                SH.Invoice_ID,
                SH.Invoice_type,
                SH.Invoice_Date,
                C.CustomerID,
                C.CustomerName,
                SH.Net_Amount,
                SH.Discount_Value,
                SH.Total_Amount,
                SH.Amount_Paid,
                SH.Remaining,
                SH.Payment_Method,
                SH.User_ID,
                SH.User_Name,
                SH.Total_Profit
            FROM SalesHeader SH
            LEFT JOIN Customers C ON SH.Customer_ID = C.CustomerID
            ORDER BY SH.Invoice_ID DESC
"

            Using cmd As New SqlCommand(sql, Conn)
                cmd.CommandTimeout = 120

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function
    Public Function GetAll_most_sale() As DataTable
        Dim dt As New DataTable()

        Try
            Connect()

            Dim sql As String = "
                SELECT 
                    Product_ID,
                    Product_Name,
                    ProductUnit_Name,
                    Sale_Price_Per_Unit AS Sale_Price_Per_Unit,
                    SUM(Total_Line_Amount)   AS Total_Line_Amount,
                    SUM(Quantity_Sold)       AS TotalQuantitySold
                FROM SalesDetails
                WHERE 
                    ProductUnit_Name NOT LIKE N'%جرام%'
                    AND ProductUnit_Name NOT LIKE N'%جم%'
                GROUP BY 
                    Product_ID,
                    Product_Name,
                    ProductUnit_Name, 
	                Sale_Price_Per_Unit
                ORDER BY 
                    TotalQuantitySold DESC;"

            Using cmd As New SqlCommand(sql, Conn)
                cmd.CommandTimeout = 120

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function
    Public Function GetAllBalancedownload() As DataTable
        Dim dt As New DataTable()

        Try
            Connect()

            Dim sql As String = "
            SELECT 
                SH.LogID,
                SH.CustomerID,
                SH.CustomerCode,
                SH.CustomerName,
                SH.OldBalance,
                SH.PaidAmount,
                SH.NewBalance,
                SH.Notes,
                SH.UserName,
                SH.ActionDate
            FROM CustomerBalanceLog SH
            ORDER BY SH.LogID DESC"

            Using cmd As New SqlCommand(sql, Conn)
                cmd.CommandTimeout = 120

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function

    Public Function GetInvoiceHeaderpurchases(ByVal invoiceID As Integer) As DataTable
        Dim dt As New DataTable()
        If invoiceID <= 0 Then Return dt

        Try
            Connect()

            Dim q As String = "
            SELECT 
            PH.Purchase_Id,
            PH.Purchase_type,
            PH.Purchase_Date,
            S.SuppliersID,
            S.SuppliersCode,
            S.SuppliersName,
            S.PhoneNumber,
            PH.Net_Amount,
            PH.Discount_Value,
            PH.Total_Amount,
            PH.Amount_Paid,
            PH.Remaining,
            PH.Notes,
            PH.purchases_Image,
            PH.User_ID,
            PH.User_Name
            FROM Purchase_Header PH
            LEFT JOIN Suppliers S ON PH.Supplier_ID = S.SuppliersID
            WHERE PH.Purchase_Id =@ID"

            Using cmd As New SqlCommand(q, Conn)
                SafeAddParam(cmd, "@ID", invoiceID)

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function

    Public Function GetInvoiceHeader(ByVal invoiceID As Integer) As DataTable
        Dim dt As New DataTable()
        If invoiceID <= 0 Then Return dt

        Try
            Connect()

            Dim q As String = "
                                SELECT 
                                    SH.Invoice_type,
                                    SH.Invoice_ID,
                                    SH.Invoice_Date,
                                    SH.Customer_ID,
                                    C.CustomerName,
                                    SH.Total_Amount,
                                    SH.Discount_Value,
                                    SH.Net_Amount,
                                    SH.Amount_Paid,
                                    SH.Remaining,
                                    SH.Payment_Method,
                                    SH.User_Name,
                                    SH.Total_Profit
                                FROM SalesHeader SH
                                LEFT JOIN Customers C ON SH.Customer_ID = C.CustomerID
                                WHERE SH.Invoice_ID = @ID"

            Using cmd As New SqlCommand(q, Conn)
                SafeAddParam(cmd, "@ID", invoiceID)

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function
    Public Function GetInvoiceDetailsPurchase(ByVal invoiceID As Integer) As DataTable
        Dim dt As New DataTable()
        If invoiceID <= 0 Then Return dt

        Try
            Connect()

            Dim q As String = "
                    SELECT 
                        PD.Purchase_Id, 
                        PD.Product_Name, 
                        PD.Quantity_Sold, 
                        PD.ProductUnit_Name, 
                        PD.Purchase_Price_Per_Unit, 
                        PD.Total_Line_Amount
                    FROM Purchase_Detalis PD
                    WHERE PD.Purchase_Id = @ID
"

            Using cmd As New SqlCommand(q, Conn)
                SafeAddParam(cmd, "@ID", invoiceID)

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function
    Public Function GetInvoiceDetails(ByVal invoiceID As Integer) As DataTable
        Dim dt As New DataTable()
        If invoiceID <= 0 Then Return dt

        Try
            Connect()

            Dim q As String = "
                                SELECT 
                                    SD.Invoice_ID, 
                                    SD.Product_Name, 
                                    SD.Quantity_Sold, 
                                    SD.ProductUnit_Name, 
                                    SD.Sale_Price_Per_Unit, 
                                    SD.Total_Line_Amount,
                                    SD.Profit
                                FROM SalesDetails SD
                                WHERE SD.Invoice_ID = @ID"

            Using cmd As New SqlCommand(q, Conn)
                SafeAddParam(cmd, "@ID", invoiceID)

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function


    Public Function GetSalesReport(Optional fromDate As Date? = Nothing,
                               Optional toDate As Date? = Nothing,
                               Optional customerID As Integer? = Nothing,
                               Optional paymentMethod As String = Nothing,
                               Optional userID As Integer? = Nothing,
                               Optional includeDetails As Boolean = False) As DataTable

        Dim dt As New DataTable()

        Try
            NormalizeDateRange(fromDate, toDate)
            Connect()

            Dim sql As New Text.StringBuilder()

            If includeDetails Then
                sql.AppendLine("SELECT SH.Invoice_ID, SH.Invoice_Date, C.CustomerName,")
                sql.AppendLine("SH.Total_Amount, SH.Discount_Value, SH.Net_Amount,SH.Total_Profit,")
                sql.AppendLine("SH.Amount_Paid, SH.Remaining, SH.Payment_Method, SH.User_Name,")
                sql.AppendLine("SD.Product_ID, P.Product_Name, SD.Quantity_Sold,")
                sql.AppendLine("SD.Sale_Price_Per_Unit, SD.Total_Line_Amount")
                sql.AppendLine("FROM SalesHeader SH")
                sql.AppendLine("LEFT JOIN Customers C ON SH.Customer_ID = C.CustomerID")
                sql.AppendLine("LEFT JOIN SalesDetails SD ON SH.Invoice_ID = SD.Invoice_ID")
                sql.AppendLine("LEFT JOIN Products P ON SD.Product_ID = P.Product_ID")
            Else
                sql.AppendLine("SELECT SH.Invoice_ID, SH.Invoice_Date, C.CustomerName,")
                sql.AppendLine("SH.Total_Amount, SH.Discount_Value, SH.Net_Amount,SH.Total_Profit,")
                sql.AppendLine("SH.Amount_Paid, SH.Remaining, SH.Payment_Method, SH.User_Name")
                sql.AppendLine("FROM SalesHeader SH")
                sql.AppendLine("LEFT JOIN Customers C ON SH.Customer_ID = C.CustomerID")
            End If

            sql.AppendLine("
            WHERE SH.Invoice_Date BETWEEN @D1 AND @D2
            AND (@CID IS NULL OR SH.Customer_ID = @CID)
            AND (@UID IS NULL OR SH.User_ID = @UID)
            AND (@Pay IS NULL OR SH.Payment_Method = @Pay)
        ")

            Using cmd As New SqlCommand(sql.ToString(), Conn)
                cmd.CommandTimeout = 120

                cmd.Parameters.AddWithValue("@D1", fromDate.Value)
                cmd.Parameters.AddWithValue("@D2", toDate.Value)

                cmd.Parameters.AddWithValue("@CID", If(customerID.HasValue, customerID, DBNull.Value))
                cmd.Parameters.AddWithValue("@UID", If(userID.HasValue, userID, DBNull.Value))
                cmd.Parameters.AddWithValue("@Pay", If(String.IsNullOrWhiteSpace(paymentMethod), DBNull.Value, paymentMethod))

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function
    Public Function GetPurchaseReport2(Optional fromDate As Date? = Nothing,
                               Optional toDate As Date? = Nothing,
                               Optional customerID As Integer? = Nothing,
                               Optional paymentMethod As String = Nothing,
                               Optional userID As Integer? = Nothing,
                               Optional includeDetails As Boolean = False) As DataTable

        Dim dt As New DataTable()

        Try
            NormalizeDateRange(fromDate, toDate)
            Connect()

            Dim sql As New Text.StringBuilder()

            If includeDetails Then
                'sql.AppendLine("SELECT PH.Purchase_Id, PH.Purchase_type, PH.Purchase_Date, C.CustomerName,")
                'sql.AppendLine("PH.Total_Amount, SH.Discount_Value, SH.Net_Amount,")
                'sql.AppendLine("SH.Amount_Paid, SH.Remaining, SH.Payment_Method, SH.User_Name,")
                'sql.AppendLine("SD.Product_ID, P.Product_Name, SD.Quantity_Sold,")
                'sql.AppendLine("SD.Sale_Price_Per_Unit, SD.Total_Line_Amount")
                'sql.AppendLine("FROM Purchase_Header PH")
                'sql.AppendLine("LEFT JOIN Customers C ON SH.Customer_ID = C.CustomerID")
                'sql.AppendLine("LEFT JOIN SalesDetails SD ON SH.Invoice_ID = SD.Invoice_ID")
                'sql.AppendLine("LEFT JOIN Products P ON SD.Product_ID = P.Product_ID")
                sql.AppendLine("SELECT PH.Purchase_Id,PH.Purchase_type,PH.Purchase_Date,S.SuppliersID,S.SuppliersName,PH.Net_Amount,PH.Discount_Value,PH.Total_Amount,PH.Amount_Paid,PH.Remaining,PH.Notes,PH.purchases_Image,PH.User_ID,PH.User_Name,")
                sql.AppendLine("PD.Purchase_Id, PD.Product_Name, PD.Quantity_Sold, PD.ProductUnit_Name, PD.Purchase_Price_Per_Unit, PD.Total_Line_Amount")
                sql.AppendLine("FROM Purchase_Header PH")
                sql.AppendLine("LEFT JOIN Suppliers S ON PH.Supplier_ID = S.SuppliersID")
                sql.AppendLine("LEFT JOIN Purchase_Detalis PD ON PH.Purchase_Id = PD.Purchase_Id")

            Else
                'sql.AppendLine("SELECT SH.Invoice_ID, SH.Invoice_Date, C.CustomerName,")
                'sql.AppendLine("SH.Total_Amount, SH.Discount_Value, SH.Net_Amount,")
                'sql.AppendLine("SH.Amount_Paid, SH.Remaining, SH.Payment_Method, SH.User_Name")
                'sql.AppendLine("FROM SalesHeader SH")
                'sql.AppendLine("LEFT JOIN Customers C ON SH.Customer_ID = C.CustomerID")
                'sql.AppendLine("SELECT PH.Purchase_Id, PH.Purchase_type, PH.Purchase_Date, C.CustomerName,")
                'sql.AppendLine("PH.Total_Amount, SH.Discount_Value, SH.Net_Amount,")
                'sql.AppendLine("SH.Amount_Paid, SH.Remaining, SH.Payment_Method, SH.User_Name,")
                'sql.AppendLine("SD.Product_ID, P.Product_Name, SD.Quantity_Sold,")
                'sql.AppendLine("SD.Sale_Price_Per_Unit, SD.Total_Line_Amount")
                'sql.AppendLine("FROM Purchase_Header PH")
                'sql.AppendLine("LEFT JOIN Customers C ON SH.Customer_ID = C.CustomerID")
                'sql.AppendLine("LEFT JOIN SalesDetails SD ON SH.Invoice_ID = SD.Invoice_ID")
                'sql.AppendLine("LEFT JOIN Products P ON SD.Product_ID = P.Product_ID")
                sql.AppendLine("SELECT PH.Purchase_Id, PH.Purchase_type,PH.Purchase_Date,S.SuppliersID,S.SuppliersName,PH.Net_Amount,PH.Discount_Value,PH.Total_Amount,PH.Amount_Paid,PH.Remaining,PH.Notes,PH.purchases_Image,PH.User_ID,PH.User_Name , PH.Payment_Method")
                sql.AppendLine("FROM Purchase_Header PH")
                sql.AppendLine("LEFT JOIN Suppliers S ON PH.Supplier_ID = S.SuppliersID")

            End If

            sql.AppendLine("
            WHERE PH.Purchase_Date BETWEEN @D1 AND @D2
            AND (@CID IS NULL OR PH.Supplier_ID = @CID)
            AND (@UID IS NULL OR PH.User_ID = @UID)
            AND (@Pay IS NULL OR PH.Payment_Method = @Pay)")

            Using cmd As New SqlCommand(sql.ToString(), Conn)
                cmd.CommandTimeout = 120

                cmd.Parameters.AddWithValue("@D1", fromDate.Value)
                cmd.Parameters.AddWithValue("@D2", toDate.Value)

                cmd.Parameters.AddWithValue("@CID", If(customerID.HasValue, customerID, DBNull.Value))
                cmd.Parameters.AddWithValue("@UID", If(userID.HasValue, userID, DBNull.Value))
                cmd.Parameters.AddWithValue("@Pay", If(String.IsNullOrWhiteSpace(paymentMethod), DBNull.Value, paymentMethod))

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function


    ' -------------------------
    ' 2) GetPurchaseReport - المشتريات
    ' -------------------------

    Public Function GetPurchaseReport(Optional fromDate As Nullable(Of Date) = Nothing,
                                      Optional toDate As Nullable(Of Date) = Nothing,
                                      Optional supplierID As Integer = 0,
                                      Optional paymentMethod As String = "",
                                      Optional userID As Integer = 0,
                                      Optional includeDetails As Boolean = False) As DataTable
        Dim dt As New DataTable()
        Try
            NormalizeDateRange(fromDate, toDate)

            Connect()
            Dim sql As New Text.StringBuilder()
            If includeDetails Then
                sql.AppendLine("SELECT PH.Purchase_Id, PH.Purchase_Date, S.Supplier_Name, PH.Total_Amount, PH.Discount_Value, PH.Net_Amount,")
                sql.AppendLine(" PH.Amount_Paid, PH.Remaining, PH.Payment_Method, PH.User_Name, PD.Product_ID, P.ProductName, PD.Quantity_Sold, PD.Purchase_Price_Per_Unit")
                sql.AppendLine("FROM Purchase_Header PH")
                sql.AppendLine("LEFT JOIN Suppliers S ON PH.Supplier_ID = S.SuppliersID")
                sql.AppendLine("LEFT JOIN Purchase_Detalis PD ON PH.Purchase_Id = PD.Purchase_Id")
                sql.AppendLine("LEFT JOIN Products P ON PD.Product_ID = P.Product_ID")
                sql.AppendLine("WHERE PH.Purchase_Date BETWEEN @D1 AND @D2")
            Else
                sql.AppendLine("SELECT PH.Purchase_Id, PH.Purchase_Date, S.Supplier_Name, PH.Total_Amount, PH.Discount_Value, PH.Net_Amount,")
                sql.AppendLine(" PH.Amount_Paid, PH.Remaining, PH.Payment_Method, PH.User_Name")
                sql.AppendLine("FROM Purchase_Header PH")
                sql.AppendLine("LEFT JOIN Suppliers S ON PH.Supplier_ID = S.SuppliersID")
                sql.AppendLine("WHERE PH.Purchase_Date BETWEEN @D1 AND @D2")
            End If

            If supplierID > 0 Then sql.AppendLine(" AND PH.Supplier_ID = @SID")
            If Not String.IsNullOrWhiteSpace(paymentMethod) Then sql.AppendLine(" AND PH.Payment_Method = @Pay")
            If userID > 0 Then sql.AppendLine(" AND PH.User_ID = @UID")

            Using cmd As New SqlCommand(sql.ToString(), Conn)
                cmd.CommandTimeout = 120
                cmd.Parameters.AddWithValue("@D1", fromDate.Value)
                cmd.Parameters.AddWithValue("@D2", toDate.Value)

                If supplierID > 0 Then SafeAddParam(cmd, "@SID", supplierID)
                If Not String.IsNullOrWhiteSpace(paymentMethod) Then SafeAddParam(cmd, "@Pay", paymentMethod.Trim())
                If userID > 0 Then SafeAddParam(cmd, "@UID", userID)

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function

    ' -------------------------
    ' 3) GetSalesDetails - تفاصيل فاتورة محددة)
    ' -------------------------
    Public Function GetSalesDetails(ByVal invoiceID As Integer) As DataTable
        Dim dt As New DataTable()
        If invoiceID <= 0 Then Return dt

        Try
            Connect()
            Dim q As String = "
SELECT SD.Invoice_ID, P.Product_Name, SD.Quantity_Sold, SD.Sale_Price_Per_Unit, SD.Total_Line_Amount
FROM SalesDetails SD
LEFT JOIN Products P ON SD.Product_ID = P.Product_ID
WHERE SD.Invoice_ID = @ID"
            Using cmd As New SqlCommand(q, Conn)
                SafeAddParam(cmd, "@ID", invoiceID)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            ' LogError(ex)
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function

    ' -------------------------
    ' 4) GetPurchaseDetails - تفاصيل فاتورة مشتريات
    ' -------------------------
    Public Function GetPurchaseDetails(ByVal purchaseID As Integer) As DataTable
        Dim dt As New DataTable()
        If purchaseID <= 0 Then Return dt

        Try
            Connect()
            Dim q As String = "
SELECT PD.Purchase_Id, P.ProductName, PD.Quantity_Sold, PD.Purchase_Price_Per_Unit
FROM Purchase_Detalis PD
LEFT JOIN Products P ON PD.Product_ID = P.Product_ID
WHERE PD.Purchase_Id = @ID"
            Using cmd As New SqlCommand(q, Conn)
                SafeAddParam(cmd, "@ID", purchaseID)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            ' LogError(ex)
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function

    ' -------------------------
    ' 5) GetStockMovement - حركة المخزون
    ' -------------------------
    Public Function GetStockMovement(Optional fromDate As Nullable(Of Date) = Nothing,
                                     Optional toDate As Nullable(Of Date) = Nothing) As DataTable
        Dim dt As New DataTable()
        Try
            NormalizeDateRange(fromDate, toDate)

            Connect()
            Dim q As String = "
SELECT 
    P.Product_ID,
    P.ProductName,
    ISNULL((SELECT SUM(Quantity_Sold) FROM SalesDetails SD JOIN SalesHeader SH on SD.Invoice_ID=SH.Invoice_ID WHERE SD.Product_ID = P.Product_ID AND SH.Invoice_Date BETWEEN @D1 AND @D2),0) AS TotalSold,
    ISNULL((SELECT SUM(Quantity_Sold) FROM Purchase_Detalis PD JOIN Purchase_Header PH on PD.Purchase_Id=PH.Purchase_Id WHERE PD.Product_ID = P.Product_ID AND PH.Purchase_Date BETWEEN @D1 AND @D2),0) AS TotalPurchased,
    ISNULL(S.Quantity_OnHand,0) AS Quantity_OnHand
FROM Products P
LEFT JOIN Stock S ON S.Product_ID = P.Product_ID
ORDER BY P.ProductName
"
            Using cmd As New SqlCommand(q, Conn)
                cmd.Parameters.AddWithValue("@D1", fromDate.Value)
                cmd.Parameters.AddWithValue("@D2", toDate.Value)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

        Catch ex As Exception
            ' LogError(ex)
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function

    ' -------------------------
    ' 6) GetProfit - مبيعات ومشتريات للفترة
    ' -------------------------
    Public Function GetProfit(Optional fromDate As Nullable(Of Date) = Nothing,
                              Optional toDate As Nullable(Of Date) = Nothing) As DataTable
        Dim dt As New DataTable()
        Try
            NormalizeDateRange(fromDate, toDate)

            Connect()
            Dim q As String = "
SELECT 
    ISNULL((SELECT SUM(Net_Amount) FROM SalesHeader WHERE Invoice_Date BETWEEN @D1 AND @D2),0) AS TotalSales,
    ISNULL((SELECT SUM(Net_Amount) FROM Purchase_Header WHERE Purchase_Date BETWEEN @D1 AND @D2),0) AS TotalPurchases
"
            Using cmd As New SqlCommand(q, Conn)
                cmd.Parameters.AddWithValue("@D1", fromDate.Value)
                cmd.Parameters.AddWithValue("@D2", toDate.Value)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(rdr)
                End Using
            End Using

            If dt.Rows.Count > 0 Then
                If Not dt.Columns.Contains("NetProfit") Then
                    dt.Columns.Add("NetProfit", GetType(Decimal))
                End If
                For Each r As DataRow In dt.Rows
                    Dim s As Decimal = If(IsDBNull(r("TotalSales")), 0D, Convert.ToDecimal(r("TotalSales")))
                    Dim p As Decimal = If(IsDBNull(r("TotalPurchases")), 0D, Convert.ToDecimal(r("TotalPurchases")))
                    r("NetProfit") = s - p
                Next
            End If

        Catch ex As Exception
            ' LogError(ex)
            Return New DataTable()
        Finally
            Disconnect()
        End Try

        Return dt
    End Function

    ' -------------------------
    ' 7) Populate helpers for ComboBoxes (Customers, Suppliers, Users, Payment Methods)
    ' هذه دوال مساعدة تعيد DataTable جاهزة للربط بالـ ComboBox
    ' -------------------------
    Public Function GetCustomersList() As DataTable
        Dim dt As New DataTable()
        Try
            Connect()
            Using cmd As New SqlCommand("SELECT CustomerID, CustomerName FROM Customers ORDER BY CustomerName", Conn)
                dt.Load(cmd.ExecuteReader())
            End Using
        Catch
            Return New DataTable()
        Finally
            Disconnect()
        End Try
        Return dt
    End Function

    Public Function GetSuppliersList() As DataTable

        Dim dt As New DataTable()
        Try
            Connect()
            Using cmd As New SqlCommand("SELECT SuppliersID, SuppliersName FROM Suppliers ORDER BY SuppliersName", Conn)
                dt.Load(cmd.ExecuteReader())
            End Using
        Catch
            Return New DataTable()
        Finally
            Disconnect()
        End Try
        Return dt
    End Function

    Public Function GetUsersList() As DataTable
        Dim dt As New DataTable()
        Try
            Connect()
            Using cmd As New SqlCommand("SELECT User_ID, User_Name FROM Users_TBL ORDER BY User_Name", Conn)
                dt.Load(cmd.ExecuteReader())
            End Using
        Catch
            Return New DataTable()
        Finally
            Disconnect()
        End Try
        Return dt
    End Function

    Public Function GetPaymentMethodsList() As DataTable
        Dim dt As New DataTable()
        Try
            Connect()
            Using cmd As New SqlCommand("SELECT DISTINCT Payment_Method FROM (SELECT Payment_Method FROM SalesHeader UNION ALL SELECT Payment_Method FROM Purchase_Header) t WHERE Payment_Method IS NOT NULL", Conn)
                dt.Load(cmd.ExecuteReader())
            End Using
        Catch
            Return New DataTable()
        Finally
            Disconnect()
        End Try
        Return dt
    End Function
    Private Function GetInvoiceHeaderfromDB(invoiceID As Integer) As InvoiceHeader
        Dim inv As InvoiceHeader = Nothing

        ' ✅ تحسين: إضافة C.CurrentBalance لحساب الرصيد السابق
        Dim q As String = "
    SELECT
        H.Invoice_ID,
        H.Invoice_Date,
        C.CustomerCode,
        C.CustomerName,
        H.User_Name,
        H.Total_Amount,
        H.Discount_Value,
        H.Net_Amount,
        H.Amount_Paid,
        H.Remaining,
        H.PreviousBalance,
        H.Payment_Method,
        C.CurrentBalance
    FROM SalesHeader H
    INNER JOIN Customers C ON H.Customer_ID = C.CustomerID
    WHERE H.Invoice_ID = @id"
        ' كود قديم (بدون CurrentBalance):
        '    SELECT H.Invoice_ID, H.Invoice_Date, C.CustomerCode, C.CustomerName,
        '           H.User_Name, H.Total_Amount, H.Discount_Value, H.Net_Amount,
        '           H.Amount_Paid, H.Remaining, H.Payment_Method
        '    FROM SalesHeader H INNER JOIN Customers C ON H.Customer_ID = C.CustomerID
        '    WHERE H.Invoice_ID = @id
        Connect()

        Using cmd As New SqlCommand(q, Conn)
            cmd.Parameters.AddWithValue("@id", invoiceID)
            Connect()

            Using rd = cmd.ExecuteReader()
                Connect()

                If rd.Read() Then
                    Dim currentBalance As Decimal = If(IsDBNull(rd("CurrentBalance")), 0D, CDec(rd("CurrentBalance")))
                    Dim remaining As Decimal = CDec(rd("Remaining"))
                    inv = New InvoiceHeader With {
                    .InvoiceID = rd("Invoice_ID"),
                    .InvoiceDate = rd("Invoice_Date"),
                    .CustomerCode = rd("CustomerCode").ToString(),
                    .CustomerName = rd("CustomerName").ToString(),
                    .UserName = rd("User_Name").ToString(),
                    .TotalAmount = rd("Total_Amount"),
                    .Discount = rd("Discount_Value"),
                    .NetAmount = rd("Net_Amount"),
                    .Paid = rd("Amount_Paid"),
                    .Remaining = remaining,
                    .PaymentMethod = rd("Payment_Method").ToString(),
                    .PreviousBalance = rd("PreviousBalance")
                }

                End If
            End Using
        End Using

        Return inv
    End Function
    Private Function GetInvoiceHeaderfromDB2(invoiceID As Integer) As InvoicePurchaseHeader
        Dim inv As InvoicePurchaseHeader = Nothing

        Dim q As String = "
                        SELECT 
                        PH.Purchase_Id,
                        PH.Purchase_type,
                        PH.Purchase_Date,
                        S.SuppliersID,
                        S.SuppliersCode,
                        S.SuppliersName,
                        S.PhoneNumber,
                        PH.Net_Amount,
                        PH.Discount_Value,
                        PH.Total_Amount,
                        PH.Amount_Paid,
                        PH.Remaining,
                        PH.Notes,
                        PH.purchases_Image,
                        PH.User_ID,
                        PH.User_Name,
                        PH.Payment_Method

                        FROM Purchase_Header PH
                        LEFT JOIN Suppliers S ON PH.Supplier_ID = S.SuppliersID
                        WHERE PH.Purchase_Id = @id"
        Connect()

        Using cmd As New SqlCommand(q, Conn)
            cmd.Parameters.AddWithValue("@id", invoiceID)
            Connect()

            Using rd = cmd.ExecuteReader()
                Connect()

                If rd.Read() Then
                    inv = New InvoicePurchaseHeader With {
                    .Purchase_Id = rd("Purchase_Id"),
                    .Purchase_Date = rd("Purchase_Date"),
                    .Supplier_ID = rd("SuppliersID"),
                    .User_ID = rd("User_ID").ToString(),
                    .User_Name = rd("User_Name").ToString(),
                    .Net_Amount = rd("Net_Amount"),
                    .Discount_Value = rd("Discount_Value"),
                    .Total_Amount = rd("Total_Amount"),
                    .Amount_Paid = rd("Amount_Paid"),
                    .Remaining = rd("Remaining"),
                    .Payment_Method = rd("Payment_Method").ToString(),
                    .Purchase_type = rd("Purchase_type").ToString(),
                    .Supplier_Code = rd("SuppliersCode").ToString(),
                    .Supplier_Name = rd("SuppliersName").ToString()
                    }
                End If
            End Using
        End Using

        Return inv
    End Function
    Private Function GetInvoiceItemsfromDB(invoiceID As Integer) As List(Of InvoiceItem)
        Dim list As New List(Of InvoiceItem)

        Dim q As String = "
            SELECT 
                Product_Name,
                Quantity_Sold,
                Sale_Price_Per_Unit,
                Total_Line_Amount
            FROM SalesDetails
            WHERE Invoice_ID = @id"
        Connect()

        Using cmd As New SqlCommand(q, Conn)
            cmd.Parameters.AddWithValue("@id", invoiceID)
            Connect()

            Using rd = cmd.ExecuteReader()
                Connect()

                While rd.Read()
                    list.Add(New InvoiceItem With {
                    .ProductName = rd("Product_Name").ToString(),
                    .Quantity = rd("Quantity_Sold"),
                    .Price = rd("Sale_Price_Per_Unit"),
                    .Total = rd("Total_Line_Amount")
                })
                End While
            End Using
        End Using

        Return list
    End Function
    Private Function GetInvoiceItemsfromDB2(invoiceID As Integer) As List(Of InvoicePurchaseItem)
        Dim list As New List(Of InvoicePurchaseItem)

        Dim q As String = "
              SELECT 
                  Product_Name,
                  Quantity_Sold,
                  Purchase_Price_Per_Unit,
                  Total_Line_Amount
              FROM Purchase_Detalis
              WHERE Purchase_Id = @id"
        Connect()

        Using cmd As New SqlCommand(q, Conn)
            cmd.Parameters.AddWithValue("@id", invoiceID)
            Connect()

            Using rd = cmd.ExecuteReader()
                Connect()

                While rd.Read()
                    list.Add(New InvoicePurchaseItem With {
                  .Product_Name = If(rd("Product_Name") Is DBNull.Value, String.Empty, rd("Product_Name").ToString()),
                  .Quantity_Sold = If(rd("Quantity_Sold") Is DBNull.Value, 0, Convert.ToInt32(rd("Quantity_Sold"))),
                  .Purchase_Price_Per_Unit = If(rd("Purchase_Price_Per_Unit") Is DBNull.Value, 0D, Convert.ToDecimal(rd("Purchase_Price_Per_Unit"))),
                  .Total_Line_Amount = If(rd("Total_Line_Amount") Is DBNull.Value, 0D, Convert.ToDecimal(rd("Total_Line_Amount")))
                })
                End While
            End Using
        End Using

        Return list
    End Function
    'Public Sub PrintInvoiceFromDB(invoiceID As Integer)

    '    Connect()

    '    Dim header = GetInvoiceHeaderfromDB(invoiceID)
    '    If header Is Nothing Then
    '        MessageBox.Show("الفاتورة غير موجودة")
    '        Exit Sub
    '    End If

    '    Dim items = GetInvoiceItemsfromDB(invoiceID)

    '    Dim pd As New PrintDocument
    '    pd.PrinterSettings.PrinterName = "XP-80C"
    '    pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
    '    pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

    '    AddHandler pd.PrintPage,
    'Sub(sender, e)

    '    Dim g = e.Graphics
    '    Dim Y As Integer = 0
    '    Dim W As Integer = e.PageBounds.Width

    '    Dim f11 As New Font("Tahoma", 11)
    '    Dim fBold As New Font("Tahoma", 11, FontStyle.Bold)
    '    Dim fTitle As New Font("Tahoma", 15, FontStyle.Bold)

    '    Dim fmtR As New StringFormat With {.Alignment = StringAlignment.Far, .FormatFlags = StringFormatFlags.DirectionRightToLeft}
    '    Dim fmtC As New StringFormat With {.Alignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft}

    '    Dim Center =
    '        Sub(t As String, f As Font)
    '            g.DrawString(t, f, Brushes.Black, New RectangleF(0, Y, W, f.Height + 5), fmtC)
    '            Y += f.Height + 5
    '        End Sub

    '    Dim RightAligned =
    '        Sub(t As String, f As Font)
    '            g.DrawString(t, f, Brushes.Black, New RectangleF(0, Y, W, f.Height + 5), fmtR)
    '            Y += f.Height + 5
    '        End Sub

    '    ' ===== الرأس =====
    '    Center("سوبر ماركت الحمد والرضا", fTitle)
    '    Center("فاتورة مبيعات", fBold)
    '    Center(New String("═"c, 32), f11)

    '    RightAligned("رقم الفاتورة : " & header.InvoiceID, f11)
    '    RightAligned("التاريخ : " & header.InvoiceDate, f11)
    '    RightAligned("الكاشير : " & header.UserName, f11)
    '    RightAligned("كود العميل : " & header.CustomerCode, f11)
    '    RightAligned("اسم العميل : " & header.CustomerName, f11)

    '    Center(New String("─"c, 40), f11)

    '    ' ===== الأصناف =====
    '    For Each it In items
    '        RightAligned(it.ProductName, f11)
    '        RightAligned($"{it.Quantity} × {it.Price}", f11)
    '        RightAligned(it.Total.ToString("0.00"), fBold)
    '        Center(New String("."c, 38), f11)
    '    Next

    '    Center(New String("═"c, 32), f11)

    '    ' ===== المجاميع =====
    '    If header.Discount > 0 Then
    '        RightAligned("الإجمالي : " & header.TotalAmount, fBold)
    '        RightAligned("الخصم : " & header.Discount, fBold)
    '        RightAligned("الصافي : " & header.NetAmount, fBold)
    '    Else
    '        RightAligned("إجمالي الفاتورة : " & header.TotalAmount, fBold)
    '    End If

    '    RightAligned("المدفوع : " & header.Paid, fBold)
    '    RightAligned("المتبقي : " & header.Remaining, fBold)

    '    Center("❤ شكراً لتعاملكم معنا", fBold)

    '    e.HasMorePages = False
    'End Sub

    '    pd.Print()
    '    Disconnect()
    'End Sub






    'Public Sub PrintInvoiceFromDB(invoiceID As Integer, copiesCount As Integer)

    '    If copiesCount <= 0 Then copiesCount = 1

    '    Connect()

    '    Dim header = GetInvoiceHeaderfromDB(invoiceID)
    '    If header Is Nothing Then
    '        MessageBox.Show("الفاتورة غير موجودة")
    '        Exit Sub
    '    End If

    '    Dim items = GetInvoiceItemsfromDB(invoiceID)

    '    Dim printedCount As Integer = 0

    '    Dim pd As New PrintDocument
    '    pd.PrinterSettings.PrinterName = "XP-80C"
    '    pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
    '    pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

    '    AddHandler pd.PrintPage,
    'Sub(sender, e)

    '    printedCount += 1

    '    Dim g = e.Graphics
    '    Dim Y As Integer = 0
    '    Dim W As Integer = e.PageBounds.Width

    '    Dim f11 As New Font("Tahoma", 11)
    '    Dim fBold As New Font("Tahoma", 11, FontStyle.Bold)
    '    Dim fTitle As New Font("Tahoma", 15, FontStyle.Bold)

    '    Dim fmtR As New StringFormat With {
    '        .Alignment = StringAlignment.Far,
    '        .FormatFlags = StringFormatFlags.DirectionRightToLeft
    '    }

    '    Dim fmtC As New StringFormat With {
    '        .Alignment = StringAlignment.Center,
    '        .FormatFlags = StringFormatFlags.DirectionRightToLeft
    '    }

    '    Dim Center =
    '        Sub(t As String, f As Font)
    '            g.DrawString(t, f, Brushes.Black,
    '                         New RectangleF(0, Y, W, f.Height + 5), fmtC)
    '            Y += f.Height + 5
    '        End Sub

    '    Dim RightAligned =
    '        Sub(t As String, f As Font)
    '            g.DrawString(t, f, Brushes.Black,
    '                         New RectangleF(0, Y, W, f.Height + 5), fmtR)
    '            Y += f.Height + 5
    '        End Sub

    '    ' ================= الرأس =================
    '    Center("سوبر ماركت الحمد والرضا", fTitle)
    '    Center("فاتورة مبيعات", fBold)
    '    Center(New String("═"c, 32), f11)

    '    RightAligned("رقم الفاتورة : " & header.InvoiceID, f11)
    '    RightAligned("التاريخ : " & header.InvoiceDate.ToString("yyyy/MM/dd hh:mm tt"), f11)
    '    RightAligned("الكاشير : " & header.UserName, f11)
    '    RightAligned("كود العميل : " & header.CustomerCode, f11)
    '    RightAligned("اسم العميل : " & header.CustomerName, f11)

    '    Center(New String("─"c, 40), f11)

    '    ' ================= الأصناف =================
    '    For Each it In items
    '        RightAligned(it.ProductName, f11)
    '        RightAligned($"{it.Quantity} × {it.Price}", f11)
    '        RightAligned(it.Total.ToString("0.00"), fBold)
    '        Center(New String("."c, 38), f11)
    '    Next

    '    Center(New String("═"c, 32), f11)

    '    ' ================= المجاميع =================
    '    If header.Discount > 0 Then
    '        RightAligned("الإجمالي : " & header.TotalAmount, fBold)
    '        RightAligned("الخصم : " & header.Discount, fBold)
    '        RightAligned("الصافي : " & header.NetAmount, fBold)
    '    Else
    '        RightAligned("إجمالي الفاتورة : " & header.TotalAmount, fBold)
    '    End If

    '    RightAligned("المدفوع : " & header.Paid, fBold)
    '    RightAligned("المتبقي : " & header.Remaining, fBold)

    '    Center("❤ شكراً لتعاملكم معنا", fBold)

    '    ' ===== التحكم في عدد النسخ =====
    '    e.HasMorePages = (printedCount < copiesCount)

    'End Sub

    '    pd.Print()
    '    Disconnect()

    'End Sub

    ' Dispatcher: إعادة طباعة من قاعدة البيانات (شاشة التقارير) — يختار النمط ويستدعي الرسم الموحّد
    Public Sub PrintInvoiceFromDBProfessional(invoiceID As Integer, copiesCount As Integer)
        If copiesCount <= 0 Then copiesCount = 1

        Dim styleVal As String = SettingsManager.GetSetting("PrintStyle")
        If Not String.IsNullOrEmpty(styleVal) AndAlso styleVal.Trim() = "2" Then
            PrintInvoiceFromDB_Style2(invoiceID, copiesCount)
            Return
        End If

        Connect()
        Try
            Dim header = GetInvoiceHeaderfromDB(invoiceID)
            If header Is Nothing Then
                MessageBox.Show("الفاتورة غير موجودة")
                Return
            End If
            Dim items = GetInvoiceItemsfromDB(invoiceID)
            Dim printBarcode As Boolean = (If(SettingsManager.GetSetting("PrintBarcode"), "true").Trim().ToLower() = "true")
            RenderInvoiceReceiptStyle1(header, items, copiesCount, ShouldShowReportPreview(), "معاينة الفاتورة - استيل 1", printBarcode)
        Finally
            Disconnect()
        End Try
    End Sub

    ' ════════════════════════════════════════════════════════════════
    ' الرسم الموحّد لفاتورة استيل 1 — مصدر واحد للحقيقة.
    ' يستخدمه: المبيعات (طباعة حية) + التقارير (إعادة طباعة).
    ' ════════════════════════════════════════════════════════════════
    Public Sub RenderInvoiceReceiptStyle1(header As InvoiceHeader, items As List(Of InvoiceItem),
                                          copiesCount As Integer, usePreview As Boolean,
                                          previewTitle As String, printBarcode As Boolean)
        If copiesCount <= 0 Then copiesCount = 1

        Dim printedCount As Integer = 0

        ' === إعداد الطباعة ===
        Dim pd As New PrintDocument()
        Dim thermalPrinter As String = SettingsManager.GetSetting("ThermalPrinterName")
        If Not String.IsNullOrEmpty(thermalPrinter) Then
            pd.PrinterSettings.PrinterName = thermalPrinter
        End If
        pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

        AddHandler pd.PrintPage,
Sub(sender, e)

    printedCount += 1

    Dim g = e.Graphics
    Dim Y As Integer = 0
    Dim leftX As Integer = 0
    Dim pageW As Integer = e.MarginBounds.Width

    ' ==== الخطوط ====
    Dim fTitle As New Font("Arial", 16, FontStyle.Bold)
    Dim fBold As New Font("Arial", 12, FontStyle.Bold)
    Dim f11 As New Font("Arial", 11, FontStyle.Bold)
    Dim f11b As New Font("Arial", 11, FontStyle.Bold)
    Dim f12 As New Font("Arial", 12, FontStyle.Bold)

    ' ==== محاذاة النصوص ====
    Dim fmtC As New StringFormat With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center,
            .FormatFlags = StringFormatFlags.DirectionRightToLeft
        }
    Dim fmtR As New StringFormat With {
            .Alignment = StringAlignment.Far,
            .LineAlignment = StringAlignment.Center,
            .FormatFlags = StringFormatFlags.DirectionRightToLeft
        }
    Dim fmtProduct As New StringFormat With {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Near,
            .FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.LineLimit,
            .Trimming = StringTrimming.EllipsisWord
        }
    Dim fmtWrap As New StringFormat With {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Center,
            .FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.NoClip
        }

    Dim pen As New Pen(Color.Black, 1.8!)

    ' ==== الدوال الصغيرة للرسم ====
    Dim Center = Sub(t As String, f As Font)
                     g.DrawString(t, f, Brushes.Black, New RectangleF(leftX, Y, pageW, f.Height + 5), fmtC)
                     Y += f.Height + 5
                 End Sub

    Dim RightAligned = Sub(t As String, f As Font)
                           g.DrawString(t, f, Brushes.Black, New RectangleF(leftX, Y, pageW, f.Height + 6), fmtR)
                           Y += f.Height + 6
                       End Sub

    Dim DrawSeparator = Sub(thickness As Integer)
                            Using p As New Pen(Color.Black, thickness)
                                g.DrawLine(p, leftX, Y, leftX + pageW, Y)
                            End Using
                            Y += 8
                        End Sub

    Dim RightAlignedSub = Sub(t As String, f As Font, x As Integer, ByRef myY As Integer)
                              g.DrawString(t, f, Brushes.Black, New RectangleF(x, myY, pageW, f.Height + 6), fmtR)
                              myY += f.Height + 6
                          End Sub

    ' [إصلاح الالتفاف]: يرسم النص في سطر واحد ويصغّر حجم الخط تلقائياً لو كان أعرض من العمود
    Dim drawFitted = Sub(t As String, baseFont As Font, rect As RectangleF, fmt As StringFormat)
                         Dim ff As Font = baseFont
                         Dim ownFont As Boolean = False
                         Dim guard As Integer = 0
                         Do While g.MeasureString(t, ff).Width > rect.Width AndAlso ff.Size > 6.5F AndAlso guard < 40
                             Dim newSize As Single = ff.Size - 0.5F
                             If ownFont Then ff.Dispose()
                             ff = New Font(baseFont.FontFamily, newSize, baseFont.Style)
                             ownFont = True
                             guard += 1
                         Loop
                         g.DrawString(t, ff, Brushes.Black, rect, fmt)
                         If ownFont Then ff.Dispose()
                     End Sub

    ' ==== إعداد شعار المتجر ومعلوماته ====
    Dim StoreName As String = SettingsManager.GetSetting("ShopName")
    Dim ShopPhone As String = SettingsManager.GetSetting("ShopPhone")
    Dim ShopPhone2 As String = SettingsManager.GetSetting("ShopPhone2")
    Dim ShopAddress As String = SettingsManager.GetSetting("ShopAddress")
    Dim TaxNumber As String = SettingsManager.GetSetting("TaxNumber")
    Dim FooterMsg As String = SettingsManager.GetSetting("FooterText")
    Dim DeliveryText As String = SettingsManager.GetSetting("DeliveryText")
    If String.IsNullOrEmpty(DeliveryText) Then DeliveryText = "يوجد توصيل للمنازل"
    If String.IsNullOrEmpty(StoreName) Then StoreName = "سوبر ماركت الحمد والرضا"
    If String.IsNullOrEmpty(FooterMsg) Then FooterMsg = "❤ شكراً لتعاملكم معنا"
    Dim DevSig As String = ""

    Dim logoPath As String = SettingsManager.GetSetting("LogoPath")
    ' احترام إعداد "طباعة اللوجو مع الفاتورة"
    Dim printLogoSetting As String = SettingsManager.GetSetting("PrintLogo")
    Dim shouldPrintLogo As Boolean = String.IsNullOrEmpty(printLogoSetting) OrElse printLogoSetting.Trim().ToLower() = "true"
    Dim logoImg As System.Drawing.Image = Nothing
    Dim logoH As Integer = 0
    Try
        If shouldPrintLogo AndAlso Not String.IsNullOrEmpty(logoPath) AndAlso IO.File.Exists(logoPath) Then
            logoImg = System.Drawing.Image.FromFile(logoPath)
        End If
    Catch
    End Try

    Dim logoW As Integer = 180
    If logoImg IsNot Nothing Then
        logoH = CInt(logoW * logoImg.Height / logoImg.Width)
    End If

    ' ===== رأس الفاتورة الجديد =====
    Dim headerY As Integer = Y
    Dim spacing As Integer = 5

    If logoImg IsNot Nothing Then
        Dim logoXPos As Integer = leftX + (pageW - logoW) \ 2
        g.DrawImage(logoImg, logoXPos, Y, logoW, logoH)
        Y += logoH + 10
        headerY = Y
    End If

    ' قياس اسم المتجر
    Dim titleSize = g.MeasureString(StoreName, fTitle)

    ' اسم المتجر في المنتصف
    g.DrawString(StoreName, fTitle, Brushes.Black,
             New RectangleF(leftX, headerY, pageW, titleSize.Height),
             fmtC)
    Y += CInt(titleSize.Height) + 5

    ' رسم معلومات الهاتف والعنوان
    If Not String.IsNullOrEmpty(ShopPhone) Then Center("هاتف: " & ShopPhone, f11)
    If Not String.IsNullOrEmpty(ShopPhone2) Then Center("هاتف: " & ShopPhone2, f11)
    If Not String.IsNullOrEmpty(ShopAddress) Then Center(ShopAddress, f11)
    If Not String.IsNullOrEmpty(TaxNumber) Then Center("الرقم الضريبي: " & TaxNumber, f11)
    ' ✅ تحسين: نجوم بدل الإيموجي (التعويض)
    If Not String.IsNullOrEmpty(DeliveryText) Then Center("** " & DeliveryText & " **", f11)

    ' تحديث Y لبداية باقي الفاتورة
    Y = Math.Max(Y, headerY + titleSize.Height + spacing)

    ' ✅ تحسين: خط سميك يفصل رأس الفاتورة عن بيانات الفاتورة
    ' كود قديم: DrawSeparator(1)
    DrawSeparator(2)
    RightAligned("نوع الفاتورة : فاتورة مبيعات", f11)
    RightAligned("رقم الفاتورة : " & header.InvoiceID, f11)
    RightAligned("التاريخ : " & header.InvoiceDate.ToString("yyyy/MM/dd  hh:mm:ss tt"), f11)
    RightAligned("الكاشير : " & header.UserName, f11)
    RightAligned("كود العميل : " & header.CustomerCode, f11)
    RightAligned("اسم العميل : " & header.CustomerName, f11)
    ' ✅ تحسين: طريقة الدفع
    If Not String.IsNullOrEmpty(header.PaymentMethod) Then
        RightAligned("طريقة الدفع : " & header.PaymentMethod, f11)
    End If
    ' كود قديم: لم يكن يظهر طريقة الدفع
    ' ✅ تحسين: خط سميك قبل جدول الأصناف
    ' كود قديم: DrawSeparator(1)
    DrawSeparator(2)

    ' ===== جدول الأصناف =====
    Dim colTotalW = CInt(pageW * 0.22)
    Dim colPriceW = CInt(pageW * 0.18)
    Dim colQtyW = CInt(pageW * 0.15)
    Dim colNameW = pageW - (colTotalW + colPriceW + colQtyW)

    Dim xTotal As Integer = leftX
    Dim xPrice As Integer = xTotal + colTotalW
    Dim xQty As Integer = xPrice + colPriceW
    Dim xName As Integer = xQty + colQtyW

    Dim tableStartY As Integer = Y
    Dim headerH As Integer = 28

    ' رأس الجدول
    g.DrawString("المنتج", f11b, Brushes.Black, New RectangleF(xName, Y, colNameW, headerH), fmtC)
    g.DrawString("الكمية", f11b, Brushes.Black, New RectangleF(xQty, Y, colQtyW, headerH), fmtC)
    g.DrawString("السعر", f11b, Brushes.Black, New RectangleF(xPrice, Y, colPriceW, headerH), fmtC)
    g.DrawString("الإجمالي", f11b, Brushes.Black, New RectangleF(xTotal, Y, colTotalW, headerH), fmtC)
    Y += headerH

    ' صفوف المنتجات
    For Each it In items
        Dim name As String = "  " & it.ProductName & " "
        Dim qty As String = it.Quantity.ToString("0.##")
        Dim price As String = it.Price.ToString("0.00")
        Dim total As String = it.Total.ToString("0.00")

        Dim h As Integer = Math.Max(28, CInt(g.MeasureString(name, f11, colNameW, fmtWrap).Height) + 8)

        Dim productRect As New RectangleF(xName, Y + 4, colNameW, h - 8)
        g.DrawString(name, f11, Brushes.Black, productRect, fmtWrap)
        ' [إصلاح تقسيم السعر سطرين]: أرقام بخط يتسع داخل العمود في سطر واحد
        drawFitted(qty, f11, New RectangleF(xQty, Y, colQtyW, h), fmtC)
        drawFitted(price, f11, New RectangleF(xPrice, Y, colPriceW, h), fmtC)
        drawFitted(total, f11, New RectangleF(xTotal, Y, colTotalW, h), fmtC)

        Y += h
        g.DrawLine(pen, leftX, Y, leftX + pageW, Y)
    Next

    Dim tableEndY As Integer = Y

    ' رسم شبكة الجدول
    g.DrawLine(pen, leftX, tableStartY, leftX + pageW, tableStartY)
    g.DrawLine(pen, leftX, tableStartY + headerH, leftX + pageW, tableStartY + headerH)
    g.DrawLine(pen, xTotal, tableStartY, xTotal, tableEndY)
    g.DrawLine(pen, xPrice, tableStartY, xPrice, tableEndY)
    g.DrawLine(pen, xQty, tableStartY, xQty, tableEndY)
    g.DrawLine(pen, xName, tableStartY, xName, tableEndY)
    g.DrawLine(pen, xName + colNameW, tableStartY, xName + colNameW, tableEndY)

    ' ✅ تحسين: عدد الأصناف
    RightAligned("عدد الأصناف : " & items.Count, f11)
    ' كود قديم: لم يكن يظهر عدد الأصناف

    ' ✅ تحسين: خط سميك قبل المجاميع
    ' كود قديم: DrawSeparator(1)
    DrawSeparator(2)

    ' ===== المجاميع =====
    If header.Discount > 0 Then
        ' ✅ تحسين: فونت أكبر للإجمالي
        ' كود قديم: RightAligned("إجمالي قبل الخصم : " & header.TotalAmount, fBold)
        RightAligned("إجمالي قبل الخصم : " & header.TotalAmount.ToString("0.00"), fTitle)
        RightAligned("الخصم           : " & header.Discount.ToString("0.00"), fBold)
        RightAligned("الصافي          : " & header.NetAmount.ToString("0.00"), fTitle)
    Else
        ' ✅ تحسين: فونت أكبر للإجمالي
        ' كود قديم: RightAligned("إجمالي الفاتورة : " & header.TotalAmount, fBold)
        RightAligned("إجمالي الفاتورة : " & header.TotalAmount.ToString("0.00"), fTitle)
    End If

    RightAligned("المدفوع         : " & header.Paid.ToString("0.00"), fBold)
    RightAligned("المتبقي         : " & header.Remaining.ToString("0.00"), fBold)

    ' ===== رصيد العميل لو موجود ====
    If header.CustomerCode <> "1" Then
        Dim previousBalance As Decimal = header.PreviousBalance
        Dim invoiceRemaining As Decimal = header.Remaining
        Dim totalBalance As Decimal = previousBalance + invoiceRemaining
        DrawSeparator(1)
        RightAligned("رصيد سابق      : " & previousBalance.ToString("0.00"), fBold)
        RightAligned("متبقي الفاتورة  : " & invoiceRemaining.ToString("0.00"), fBold)
        RightAligned("إجمالي الحساب  : " & totalBalance.ToString("0.00"), fTitle)
    End If

    ' ✅ تحسين: خط سميك بعد المجاميع
    ' كود قديم: DrawSeparator(1)
    DrawSeparator(2)

    ' باركود (مشروط بالإعداد - يأتي كـ parameter من المُستدعي)
    If printBarcode Then
        Dim qr As Bitmap = GenerateQRCode(header.InvoiceID.ToString())
        g.DrawImage(qr, leftX + (pageW - qr.Width) \ 2, Y)
        Y += qr.Height + 5
    End If
    ' كود قديم (الباركود يطبع دائماً):
    ' Dim qr As Bitmap = GenerateQRCode(header.InvoiceID.ToString())
    ' g.DrawImage(qr, leftX + (pageW - qr.Width) \ 2, Y)
    ' Y += qr.Height + 5

    ' ✅ تحسين: فوتر بنجوم
    ' كود قديم: Center(FooterMsg, f11b)
    Center("* " & FooterMsg & " *", f11b)
    If Not String.IsNullOrEmpty(DeliveryText) Then Center("** " & DeliveryText & " **", f11)
    Center(DevSig, f11)

    ' ✅ تحسين: خط سميك في نهاية الفاتورة
    ' كود قديم: DrawSeparator(1)
    DrawSeparator(2)

    ' ===== التحكم في عدد النسخ =====
    e.HasMorePages = (printedCount < copiesCount)

End Sub

        Try
            If usePreview Then
                ShowReportPreviewDialog(pd, previewTitle)
            Else
                pd.Print()
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' هل المعاينة مفعّلة؟
    Public Function ShouldShowReportPreview() As Boolean
        Return SettingsManager.GetBoolSetting(SettingsKeys.PrintPreview, False)
    End Function

    ' فتح نافذة المعاينة بدون أي طباعة فعلية
    Public Sub ShowReportPreviewDialog(pd As PrintDocument, title As String)
        Try
            Dim dlg As New PrintPreviewDialog()
            Try
                dlg.Document = pd
                dlg.Text = title
                dlg.WindowState = FormWindowState.Maximized
                dlg.UseAntiAlias = True
                dlg.PrintPreviewControl.Zoom = 1.25
                dlg.ShowIcon = False
                dlg.StartPosition = FormStartPosition.CenterScreen
                dlg.ShowDialog()
            Finally
                dlg.Dispose()
            End Try
        Catch ex As Exception
            MessageBox.Show("خطأ في عرض المعاينة: " & ex.Message,
                            "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ════════════════════════════════════════════════════════════════
    ' استيل 2 (شبيه فاتورة المصطفى): لوجو على الشمال + بيانات على اليمين
    ' ════════════════════════════════════════════════════════════════
    ' Wrapper: إعادة طباعة من قاعدة البيانات (شاشة التقارير) — تجلب البيانات ثم تستدعي الرسم الموحّد
    Public Sub PrintInvoiceFromDB_Style2(invoiceID As Integer, copiesCount As Integer)
        If copiesCount <= 0 Then copiesCount = 1
        Connect()
        Try
            Dim header = GetInvoiceHeaderfromDB(invoiceID)
            If header Is Nothing Then
                MessageBox.Show("الفاتورة غير موجودة")
                Return
            End If
            Dim items = GetInvoiceItemsfromDB(invoiceID)
            Dim printBarcode As Boolean = (If(SettingsManager.GetSetting("PrintBarcode"), "true").Trim().ToLower() = "true")
            RenderInvoiceReceiptStyle2(header, items, copiesCount, ShouldShowReportPreview(), "معاينة الفاتورة - استيل 2", printBarcode)
        Finally
            Disconnect()
        End Try
    End Sub

    ' ════════════════════════════════════════════════════════════════
    ' الرسم الموحّد لفاتورة استيل 2 — مصدر واحد للحقيقة.
    ' يستخدمه: المبيعات (طباعة حية) + التقارير (إعادة طباعة).
    ' أي تعديل في شكل الفاتورة يتم هنا فقط فينطبق على الاثنين.
    ' ════════════════════════════════════════════════════════════════
    'Public Sub RenderInvoiceReceiptStyle2(header As InvoiceHeader, items As List(Of InvoiceItem),
    '                                      copiesCount As Integer, usePreview As Boolean,
    '                                      previewTitle As String, printBarcode As Boolean)
    '    If copiesCount <= 0 Then copiesCount = 1

    '    ' ─── إعدادات العامة ───
    '    Dim StoreName As String = SettingsManager.GetSetting("ShopName")
    '    Dim ShopPhone As String = SettingsManager.GetSetting("ShopPhone")
    '    Dim ShopPhone2 As String = SettingsManager.GetSetting("ShopPhone2")
    '    Dim ShopAddress As String = SettingsManager.GetSetting("ShopAddress")
    '    Dim TaxNumber As String = SettingsManager.GetSetting("TaxNumber")
    '    Dim FooterMsg As String = SettingsManager.GetSetting("FooterText")
    '    Dim DeliveryText As String = SettingsManager.GetSetting("DeliveryText")
    '    If String.IsNullOrEmpty(DeliveryText) Then DeliveryText = "يوجد توصيل للمنازل"
    '    If String.IsNullOrEmpty(StoreName) Then StoreName = "سوبر ماركت الحمد والرضا"
    '    If String.IsNullOrEmpty(FooterMsg) Then FooterMsg = "❤ شكراً لتعاملكم معنا"

    '    Dim thermalPrinter As String = SettingsManager.GetSetting("ThermalPrinterName")
    '    Dim logoPath As String = SettingsManager.GetSetting("LogoPath")
    '    Dim printLogoSetting As String = SettingsManager.GetSetting("PrintLogo")
    '    Dim shouldPrintLogo As Boolean = String.IsNullOrEmpty(printLogoSetting) OrElse printLogoSetting.Trim().ToLower() = "true"

    '    Dim logoImg As System.Drawing.Image = Nothing
    '    Try
    '        If shouldPrintLogo AndAlso Not String.IsNullOrEmpty(logoPath) AndAlso IO.File.Exists(logoPath) Then
    '            logoImg = System.Drawing.Image.FromFile(logoPath)
    '        End If
    '    Catch
    '    End Try

    '    Dim printedCount As Integer = 0
    '    Dim pd As New PrintDocument()
    '    If Not String.IsNullOrEmpty(thermalPrinter) Then
    '        pd.PrinterSettings.PrinterName = thermalPrinter
    '    End If
    '    pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
    '    pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

    '    AddHandler pd.PrintPage,
    '        Sub(sender, e)
    '            printedCount += 1
    '            Dim g = e.Graphics
    '            Dim Y As Integer = e.MarginBounds.Top
    '            Dim pageW As Integer = e.MarginBounds.Width
    '            Dim leftX As Integer = e.MarginBounds.Left

    '            Dim fBrand As New Font("Arial", 11, FontStyle.Bold)
    '            Dim fBold As New Font("Arial", 11, FontStyle.Bold)
    '            Dim fTotalLarge As New Font("Arial", 13, FontStyle.Bold)
    '            Dim f10 As New Font("Arial", 10, FontStyle.Bold)
    '            Dim f9 As New Font("Arial", 10, FontStyle.Bold)
    '            Dim f8 As New Font("Arial", 9, FontStyle.Bold)

    '            Dim fmtC As New StringFormat With {
    '                .Alignment = StringAlignment.Center,
    '                .LineAlignment = StringAlignment.Center,
    '                .FormatFlags = StringFormatFlags.DirectionRightToLeft}
    '            Dim fmtR As New StringFormat With {
    '                .Alignment = StringAlignment.Far,
    '                .LineAlignment = StringAlignment.Center,
    '                .FormatFlags = StringFormatFlags.DirectionRightToLeft}
    '            Dim fmtWrap As New StringFormat With {
    '                .Alignment = StringAlignment.Near,
    '                .LineAlignment = StringAlignment.Center,
    '                .FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.NoClip}
    '            Dim linePen As New Pen(Color.Black, 1)

    '            Const safeRightInset As Integer = 28
    '            Dim usableW As Integer = pageW - safeRightInset

    '            Dim centerLine = Sub(t As String, f As Font)
    '                                 g.DrawString(t, f, Brushes.Black,
    '                                              New RectangleF(leftX, Y, usableW, f.Height + 5), fmtC)
    '                                 Y += f.Height + 5
    '                             End Sub

    '            Dim rightLineSafe = Sub(t As String, f As Font)
    '                                    g.DrawString(t, f, Brushes.Black,
    '                                                 New RectangleF(leftX, Y, usableW, f.Height + 4), fmtR)
    '                                    Y += f.Height + 4
    '                                End Sub

    '            ' [إصلاح الالتفاف]: يرسم النص في سطر واحد ويصغّر حجم الخط تلقائياً لو كان
    '            ' أعرض من المستطيل — يمنع نزول التاريخ/السعر لسطر تاني.
    '            Dim drawFitted = Sub(t As String, baseFont As Font, rect As RectangleF, fmt As StringFormat)
    '                                 Dim ff As Font = baseFont
    '                                 Dim ownFont As Boolean = False
    '                                 Dim guard As Integer = 0
    '                                 Do While g.MeasureString(t, ff).Width > rect.Width AndAlso ff.Size > 6.5F AndAlso guard < 40
    '                                     Dim newSize As Single = ff.Size - 0.5F
    '                                     If ownFont Then ff.Dispose()
    '                                     ff = New Font(baseFont.FontFamily, newSize, baseFont.Style)
    '                                     ownFont = True
    '                                     guard += 1
    '                                 Loop
    '                                 g.DrawString(t, ff, Brushes.Black, rect, fmt)
    '                                 If ownFont Then ff.Dispose()
    '                             End Sub

    '            Dim separator = Sub()
    '                                g.DrawLine(linePen, leftX, Y, leftX + usableW, Y)
    '                                Y += 6
    '                            End Sub

    '            ' ─── الهيدر: لوجو على اليمين + بيانات على الشمال ───
    '            ' اللوجو ياخد مساحة أصغر عشان البيانات الأطول (التاريخ) تظهر كاملة
    '            Dim logoColW As Integer = CInt(usableW * 0.32)
    '            Dim infoColW As Integer = usableW - logoColW
    '            Dim infoColX As Integer = leftX
    '            Dim logoColX As Integer = leftX + infoColW
    '            Dim logoY As Integer = Y
    '            Dim infoY As Integer = Y

    '            If logoImg IsNot Nothing Then
    '                Dim logoWidth As Integer = Math.Min(95, logoColW - 6)
    '                Dim logoHeight As Integer = CInt(logoWidth * logoImg.Height / logoImg.Width)
    '                Dim logoXPos As Integer = logoColX + (logoColW - logoWidth) \ 2
    '                g.DrawImage(logoImg, logoXPos, logoY, logoWidth, logoHeight)
    '                logoY += logoHeight + 4
    '            End If

    '            ' اسم المحل فوق مع فرق بسيط من اللوجو
    '            logoY += 5

    '            ' [إصلاح وضوح اسم المحل]: نلفّ الاسم على أكثر من سطر داخل عمود اللوجو
    '            ' ونحسب الارتفاع الفعلي بدل قصّه في سطر واحد.
    '            Dim brandFont As Font = fBrand
    '            Dim brandRectW As Integer = logoColW - 4
    '            If g.MeasureString(StoreName, brandFont).Width > brandRectW * 2 Then
    '                brandFont = New Font("Arial", 9, FontStyle.Bold)
    '            End If
    '            Dim brandSize As SizeF = g.MeasureString(StoreName, brandFont, brandRectW, fmtC)
    '            Dim brandH As Integer = CInt(brandSize.Height) + 4
    '            g.DrawString(StoreName, brandFont, Brushes.Black,
    '                         New RectangleF(logoColX + 2, logoY, brandRectW, brandH), fmtC)
    '            logoY += brandH
    '            If Not brandFont Is fBrand Then brandFont.Dispose()

    '            ' حقول بيانات الفاتورة (شمال) - خط أصغر عشان تظهر كاملة
    '            Dim drawRightField = Sub(label As String, value As String)
    '                                     Dim txt As String = label & " : " & value
    '                                     Dim hh As Integer = f8.Height + 6
    '                                     ' [إصلاح نزول التاريخ سطر تاني]: نرسم القيمة في سطر واحد بخط يتسع تلقائياً
    '                                     drawFitted(txt, f8, New RectangleF(infoColX + 4, infoY, infoColW - 8, hh), fmtR)
    '                                     g.DrawLine(linePen, infoColX, infoY + hh, infoColX + infoColW, infoY + hh)
    '                                     infoY += hh + 1
    '                                 End Sub

    '            drawRightField("اسم العميل", header.CustomerName)
    '            drawRightField("فاتورة رقم", header.InvoiceID.ToString())
    '            ' تاريخ مختصر مع نظام 12 ساعة
    '            drawRightField("التاريخ", header.InvoiceDate.ToString("yyyy/MM/dd hh:mm tt"))
    '            drawRightField("المستخدم", header.UserName)
    '            drawRightField("طريقة الدفع", header.PaymentMethod)

    '            g.DrawLine(linePen, logoColX, Y, logoColX, Math.Max(logoY, infoY))

    '            Y = Math.Max(infoY, logoY) + 4
    '            g.DrawLine(linePen, leftX, Y, leftX + usableW, Y)
    '            Y += 6

    '            ' العنوان والهواتف
    '            Dim phones As String = ShopPhone
    '            If Not String.IsNullOrEmpty(ShopPhone2) Then
    '                phones = If(String.IsNullOrEmpty(phones), ShopPhone2, ShopPhone & " - " & ShopPhone2)
    '            End If
    '            If Not String.IsNullOrEmpty(ShopAddress) Then centerLine(ShopAddress, f9)
    '            If Not String.IsNullOrEmpty(phones) Then centerLine(phones, f9)
    '            If Not String.IsNullOrEmpty(TaxNumber) Then centerLine("الرقم الضريبي: " & TaxNumber, f9)

    '            separator()

    '            ' ─── جدول المنتجات ───
    '            Dim tableW As Integer = usableW
    '            Dim colTW = CInt(tableW * 0.22)
    '            Dim colPW = CInt(tableW * 0.18)
    '            Dim colQW = CInt(tableW * 0.16)
    '            Dim colNW = tableW - (colTW + colPW + colQW)
    '            Dim xT As Integer = leftX
    '            Dim xP As Integer = xT + colTW
    '            Dim xQ As Integer = xP + colPW
    '            Dim xN As Integer = xQ + colQW
    '            Dim tableY As Integer = Y
    '            Dim headerH As Integer = 26

    '            g.DrawString("الصنف", fBold, Brushes.Black, New RectangleF(xN, Y, colNW, headerH), fmtC)
    '            g.DrawString("الكمية", fBold, Brushes.Black, New RectangleF(xQ, Y, colQW, headerH), fmtC)
    '            g.DrawString("السعر", fBold, Brushes.Black, New RectangleF(xP, Y, colPW, headerH), fmtC)
    '            g.DrawString("إجمالي", fBold, Brushes.Black, New RectangleF(xT, Y, colTW, headerH), fmtC)
    '            Y += headerH

    '            Const namePadRight As Integer = 8
    '            Const namePadLeft As Integer = 4
    '            Dim nameTextWidth As Integer = colNW - namePadRight - namePadLeft
    '            If nameTextWidth < 20 Then nameTextWidth = colNW
    '            For Each it In items
    '                Dim cleanName As String = If(it.ProductName, "").Replace(vbCr, " ").Replace(vbLf, " ").Trim()
    '                Dim measured As SizeF = g.MeasureString(cleanName, f10, nameTextWidth, fmtWrap)
    '                Dim h As Integer = Math.Max(24, CInt(measured.Height) + 8)
    '                g.DrawString(cleanName, f10, Brushes.Black,
    '                             New RectangleF(xN + namePadLeft, Y + 3, nameTextWidth, h - 6), fmtWrap)
    '                ' [إصلاح تقسيم السعر سطرين]: أرقام بخط يتسع داخل العمود في سطر واحد
    '                drawFitted(it.Quantity.ToString("0.##"), f10, New RectangleF(xQ, Y, colQW, h), fmtC)
    '                drawFitted(it.Price.ToString("0.00"), f10, New RectangleF(xP, Y, colPW, h), fmtC)
    '                drawFitted(it.Total.ToString("0.00"), f10, New RectangleF(xT, Y, colTW, h), fmtC)
    '                Y += h
    '                g.DrawLine(linePen, leftX, Y, leftX + tableW, Y)
    '            Next

    '            Dim tableEndY As Integer = Y
    '            g.DrawLine(linePen, leftX, tableY, leftX + tableW, tableY)
    '            g.DrawLine(linePen, leftX, tableY + headerH, leftX + tableW, tableY + headerH)
    '            g.DrawLine(linePen, xT, tableY, xT, tableEndY)
    '            g.DrawLine(linePen, xP, tableY, xP, tableEndY)
    '            g.DrawLine(linePen, xQ, tableY, xQ, tableEndY)
    '            g.DrawLine(linePen, xN, tableY, xN, tableEndY)
    '            g.DrawLine(linePen, xN + colNW, tableY, xN + colNW, tableEndY)

    '            separator()
    '            rightLineSafe("عدد الأصناف : " & items.Count, fBold)
    '            separator()

    '            If header.Discount > 0 Then
    '                centerLine("إجمالي قبل الخصم : " & header.TotalAmount.ToString("0.00"), fTotalLarge)
    '                centerLine("الخصم           : " & header.Discount.ToString("0.00"), fTotalLarge)
    '                centerLine("الصافي          : " & header.NetAmount.ToString("0.00"), fTotalLarge)
    '            Else
    '                centerLine("إجمالي الفاتورة : " & header.TotalAmount.ToString("0.00"), fTotalLarge)
    '            End If
    '            centerLine("المدفوع         : " & header.Paid.ToString("0.00"), fTotalLarge)
    '            centerLine("المتبقي         : " & header.Remaining.ToString("0.00"), fTotalLarge)

    '            If header.CustomerCode <> "1" Then
    '                Dim totalBalance As Decimal = header.PreviousBalance + header.Remaining
    '                separator()
    '                rightLineSafe("رصيد سابق    : " & header.PreviousBalance.ToString("0.00"), fBold)
    '                rightLineSafe("متبقي الفاتورة: " & header.Remaining.ToString("0.00"), fBold)
    '                rightLineSafe("إجمالي الحساب: " & totalBalance.ToString("0.00"), fBold)
    '            End If

    '            separator()
    '            If printBarcode Then
    '                Try
    '                    Dim qr As Bitmap = GenerateQRCode(header.InvoiceID.ToString())
    '                    g.DrawImage(qr, leftX + (usableW - qr.Width) \ 2, Y)
    '                    Y += qr.Height + 5
    '                Catch
    '                End Try
    '            End If
    '            centerLine("* " & FooterMsg & " *", fBold)
    '            If Not String.IsNullOrEmpty(DeliveryText) Then
    '                centerLine("** " & DeliveryText & " **", fBold)
    '            End If
    '            separator()

    '            e.HasMorePages = (printedCount < copiesCount)
    '        End Sub

    '    Try
    '        If usePreview Then
    '            ShowReportPreviewDialog(pd, previewTitle)
    '        Else
    '            pd.Print()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("خطأ أثناء الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If logoImg IsNot Nothing Then logoImg.Dispose()
    '    End Try
    'End Sub

    Public Sub RenderInvoiceReceiptStyle2(header As InvoiceHeader, items As List(Of InvoiceItem),
                                      copiesCount As Integer, usePreview As Boolean,
                                      previewTitle As String, printBarcode As Boolean)
        If copiesCount <= 0 Then copiesCount = 1

        ' ─── إعدادات العامة ───
        Dim StoreName As String = SettingsManager.GetSetting("ShopName")
        Dim ShopPhone As String = SettingsManager.GetSetting("ShopPhone")
        Dim ShopPhone2 As String = SettingsManager.GetSetting("ShopPhone2")
        Dim ShopAddress As String = SettingsManager.GetSetting("ShopAddress")
        Dim TaxNumber As String = SettingsManager.GetSetting("TaxNumber")
        Dim FooterMsg As String = SettingsManager.GetSetting("FooterText")
        Dim DeliveryText As String = SettingsManager.GetSetting("DeliveryText")
        If String.IsNullOrEmpty(DeliveryText) Then DeliveryText = "يوجد توصيل للمنازل"
        If String.IsNullOrEmpty(StoreName) Then StoreName = "سوبر ماركت الحمد والرضا"
        If String.IsNullOrEmpty(FooterMsg) Then FooterMsg = "❤ شكراً لتعاملكم معنا"

        Dim thermalPrinter As String = SettingsManager.GetSetting("ThermalPrinterName")
        Dim logoPath As String = SettingsManager.GetSetting("LogoPath")
        Dim printLogoSetting As String = SettingsManager.GetSetting("PrintLogo")
        Dim shouldPrintLogo As Boolean = String.IsNullOrEmpty(printLogoSetting) OrElse printLogoSetting.Trim().ToLower() = "true"

        Dim logoImg As System.Drawing.Image = Nothing
        Try
            If shouldPrintLogo AndAlso Not String.IsNullOrEmpty(logoPath) AndAlso IO.File.Exists(logoPath) Then
                logoImg = System.Drawing.Image.FromFile(logoPath)
            End If
        Catch
        End Try

        ' ─── [جديد] تقسيم الأصناف على أكتر من صفحة ───
        ' المتغير ده بيتقرأ من الإعدادات، واسمه: InvoiceItemsPerPage
        ' لو مش موجود أو قيمته صفر أو غير صحيحة -> يبقى معناها "من غير تقسيم" (نفس السلوك القديم بالظبط)
        Dim itemsPerPageSetting As String = SettingsManager.GetSetting("InvoiceItemsPerPage")
        Dim itemsPerPage As Integer
        If Not Integer.TryParse(itemsPerPageSetting, itemsPerPage) OrElse itemsPerPage <= 0 Then
            itemsPerPage = Integer.MaxValue
        End If

        ' عدد "صفحات الأصناف" داخل النسخة الواحدة (لو الأصناف قليلة هتكون صفحة واحدة زي ما هي)
        Dim totalItemPages As Integer = 1
        If items.Count > 0 AndAlso itemsPerPage < items.Count Then
            totalItemPages = CInt(Math.Ceiling(items.Count / CDbl(itemsPerPage)))
        End If

        ' إجمالي عدد الصفحات الحقيقي = عدد النسخ * عدد صفحات الأصناف في النسخة الواحدة
        Dim totalPages As Integer = copiesCount * totalItemPages

        Dim printedCount As Integer = 0
        Dim pd As New PrintDocument()
        If Not String.IsNullOrEmpty(thermalPrinter) Then
            pd.PrinterSettings.PrinterName = thermalPrinter
        End If
        pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

        AddHandler pd.PrintPage,
        Sub(sender, e)
            printedCount += 1

            ' [جديد] تحديد مكان الصفحة الحالية داخل تسلسل صفحات الأصناف (بمعزل عن رقم النسخة)
            Dim itemPageIndex As Integer = (printedCount - 1) Mod totalItemPages ' 0-based
            Dim isFirstItemPage As Boolean = (itemPageIndex = 0)
            Dim isLastItemPage As Boolean = (itemPageIndex = totalItemPages - 1)

            ' [جديد] استخراج الأصناف الخاصة بالصفحة الحالية فقط
            Dim startIdx As Integer = itemPageIndex * itemsPerPage
            Dim pageItems As List(Of InvoiceItem)
            If startIdx < items.Count Then
                Dim countInPage As Integer = Math.Min(itemsPerPage, items.Count - startIdx)
                pageItems = items.GetRange(startIdx, countInPage)
            Else
                pageItems = New List(Of InvoiceItem)()
            End If

            Dim g = e.Graphics
            Dim Y As Integer = e.MarginBounds.Top
            Dim pageW As Integer = e.MarginBounds.Width
            Dim leftX As Integer = e.MarginBounds.Left

            Dim fBrand As New Font("Arial", 11, FontStyle.Bold)
            Dim fBold As New Font("Arial", 11, FontStyle.Bold)
            Dim fTotalLarge As New Font("Arial", 13, FontStyle.Bold)
            Dim f10 As New Font("Arial", 10, FontStyle.Bold)
            Dim f9 As New Font("Arial", 10, FontStyle.Bold)
            Dim f8 As New Font("Arial", 9, FontStyle.Bold)

            Dim fmtC As New StringFormat With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center,
                .FormatFlags = StringFormatFlags.DirectionRightToLeft}
            Dim fmtR As New StringFormat With {
                .Alignment = StringAlignment.Far,
                .LineAlignment = StringAlignment.Center,
                .FormatFlags = StringFormatFlags.DirectionRightToLeft}
            Dim fmtWrap As New StringFormat With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Center,
                .FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.NoClip}
            Dim linePen As New Pen(Color.Black, 1.8!)

            Const safeRightInset As Integer = 28
            Dim usableW As Integer = pageW - safeRightInset

            Dim centerLine = Sub(t As String, f As Font)
                                 g.DrawString(t, f, Brushes.Black,
                                              New RectangleF(leftX, Y, usableW, f.Height + 5), fmtC)
                                 Y += f.Height + 5
                             End Sub

            Dim rightLineSafe = Sub(t As String, f As Font)
                                    g.DrawString(t, f, Brushes.Black,
                                                 New RectangleF(leftX, Y, usableW, f.Height + 4), fmtR)
                                    Y += f.Height + 4
                                End Sub

            ' [إصلاح الالتفاف]: يرسم النص في سطر واحد ويصغّر حجم الخط تلقائياً لو كان
            ' أعرض من المستطيل — يمنع نزول التاريخ/السعر لسطر تاني.
            Dim drawFitted = Sub(t As String, baseFont As Font, rect As RectangleF, fmt As StringFormat)
                                 Dim ff As Font = baseFont
                                 Dim ownFont As Boolean = False
                                 Dim guard As Integer = 0
                                 Do While g.MeasureString(t, ff).Width > rect.Width AndAlso ff.Size > 6.5F AndAlso guard < 40
                                     Dim newSize As Single = ff.Size - 0.5F
                                     If ownFont Then ff.Dispose()
                                     ff = New Font(baseFont.FontFamily, newSize, baseFont.Style)
                                     ownFont = True
                                     guard += 1
                                 Loop
                                 g.DrawString(t, ff, Brushes.Black, rect, fmt)
                                 If ownFont Then ff.Dispose()
                             End Sub

            Dim separator = Sub()
                                g.DrawLine(linePen, leftX, Y, leftX + usableW, Y)
                                Y += 6
                            End Sub

            If isFirstItemPage Then
                ' ─── الهيدر: لوجو على اليمين + بيانات على الشمال (زي ما هو زمان، من غير أي تغيير في المقاسات) ───
                ' اللوجو ياخد مساحة أصغر عشان البيانات الأطول (التاريخ) تظهر كاملة
                Dim logoColW As Integer = CInt(usableW * 0.32)
                Dim infoColW As Integer = usableW - logoColW
                Dim infoColX As Integer = leftX
                Dim logoColX As Integer = leftX + infoColW
                Dim logoY As Integer = Y
                Dim infoY As Integer = Y

                If logoImg IsNot Nothing Then
                    Dim logoWidth As Integer = Math.Min(95, logoColW - 6)
                    Dim logoHeight As Integer = CInt(logoWidth * logoImg.Height / logoImg.Width)
                    Dim logoXPos As Integer = logoColX + (logoColW - logoWidth) \ 2
                    g.DrawImage(logoImg, logoXPos, logoY, logoWidth, logoHeight)
                    logoY += logoHeight + 4
                End If

                ' اسم المحل فوق مع فرق بسيط من اللوجو
                logoY += 5

                ' [إصلاح وضوح اسم المحل]: نلفّ الاسم على أكثر من سطر داخل عمود اللوجو
                ' ونحسب الارتفاع الفعلي بدل قصّه في سطر واحد.
                Dim brandFont As Font = fBrand
                Dim brandRectW As Integer = logoColW - 4
                If g.MeasureString(StoreName, brandFont).Width > brandRectW * 2 Then
                    brandFont = New Font("Arial", 9, FontStyle.Bold)
                End If
                Dim brandSize As SizeF = g.MeasureString(StoreName, brandFont, brandRectW, fmtC)
                Dim brandH As Integer = CInt(brandSize.Height) + 4
                g.DrawString(StoreName, brandFont, Brushes.Black,
                             New RectangleF(logoColX + 2, logoY, brandRectW, brandH), fmtC)
                logoY += brandH
                If Not brandFont Is fBrand Then brandFont.Dispose()

                ' حقول بيانات الفاتورة (شمال) - خط أصغر عشان تظهر كاملة
                Dim drawRightField = Sub(label As String, value As String)
                                         Dim txt As String = label & " : " & value
                                         Dim hh As Integer = f8.Height + 6
                                         ' [إصلاح نزول التاريخ سطر تاني]: نرسم القيمة في سطر واحد بخط يتسع تلقائياً
                                         drawFitted(txt, f8, New RectangleF(infoColX + 4, infoY, infoColW - 8, hh), fmtR)
                                         g.DrawLine(linePen, infoColX, infoY + hh, infoColX + infoColW, infoY + hh)
                                         infoY += hh + 1
                                     End Sub

                drawRightField("اسم العميل", header.CustomerName)
                drawRightField("فاتورة رقم", header.InvoiceID.ToString())
                ' تاريخ مختصر مع نظام 12 ساعة
                drawRightField("التاريخ", header.InvoiceDate.ToString("yyyy/MM/dd hh:mm tt"))
                drawRightField("المستخدم", header.UserName)
                drawRightField("طريقة الدفع", header.PaymentMethod)

                g.DrawLine(linePen, logoColX, Y, logoColX, Math.Max(logoY, infoY))

                Y = Math.Max(infoY, logoY) + 4
                g.DrawLine(linePen, leftX, Y, leftX + usableW, Y)
                Y += 6

                ' العنوان والهواتف
                Dim phones As String = ShopPhone
                If Not String.IsNullOrEmpty(ShopPhone2) Then
                    phones = If(String.IsNullOrEmpty(phones), ShopPhone2, ShopPhone & " - " & ShopPhone2)
                End If
                If Not String.IsNullOrEmpty(ShopAddress) Then centerLine(ShopAddress, f9)
                If Not String.IsNullOrEmpty(phones) Then centerLine(phones, f9)
                If Not String.IsNullOrEmpty(TaxNumber) Then centerLine("الرقم الضريبي: " & TaxNumber, f9)

                separator()
            Else
                ' [جديد] صفحة تكملة أصناف: هيدر مختصر بدل اللوجو والبيانات الكاملة
                centerLine("تابع فاتورة رقم " & header.InvoiceID.ToString(), fBold)
                centerLine("(الأصناف من " & (startIdx + 1) & " إلى " & (startIdx + pageItems.Count) & " من " & items.Count & ")", f9)
                separator()
            End If

            ' ─── جدول المنتجات ───
            Dim tableW As Integer = usableW
            Dim colTW = CInt(tableW * 0.22)
            Dim colPW = CInt(tableW * 0.18)
            Dim colQW = CInt(tableW * 0.16)
            Dim colNW = tableW - (colTW + colPW + colQW)
            Dim xT As Integer = leftX
            Dim xP As Integer = xT + colTW
            Dim xQ As Integer = xP + colPW
            Dim xN As Integer = xQ + colQW
            Dim tableY As Integer = Y
            Dim headerH As Integer = 26

            g.DrawString("الصنف", fBold, Brushes.Black, New RectangleF(xN, Y, colNW, headerH), fmtC)
            g.DrawString("الكمية", fBold, Brushes.Black, New RectangleF(xQ, Y, colQW, headerH), fmtC)
            g.DrawString("السعر", fBold, Brushes.Black, New RectangleF(xP, Y, colPW, headerH), fmtC)
            g.DrawString("إجمالي", fBold, Brushes.Black, New RectangleF(xT, Y, colTW, headerH), fmtC)
            Y += headerH

            Const namePadRight As Integer = 8
            Const namePadLeft As Integer = 4
            Dim nameTextWidth As Integer = colNW - namePadRight - namePadLeft
            If nameTextWidth < 20 Then nameTextWidth = colNW

            ' [تعديل] بنلف على أصناف الصفحة الحالية بس (pageItems) مش كل الأصناف
            For Each it In pageItems
                Dim cleanName As String = If(it.ProductName, "").Replace(vbCr, " ").Replace(vbLf, " ").Trim()
                Dim measured As SizeF = g.MeasureString(cleanName, f10, nameTextWidth, fmtWrap)
                Dim h As Integer = Math.Max(24, CInt(measured.Height) + 8)
                g.DrawString(cleanName, f10, Brushes.Black,
                             New RectangleF(xN + namePadLeft, Y + 3, nameTextWidth, h - 6), fmtWrap)
                ' [إصلاح تقسيم السعر سطرين]: أرقام بخط يتسع داخل العمود في سطر واحد
                drawFitted(it.Quantity.ToString("0.##"), f10, New RectangleF(xQ, Y, colQW, h), fmtC)
                drawFitted(it.Price.ToString("0.00"), f10, New RectangleF(xP, Y, colPW, h), fmtC)
                drawFitted(it.Total.ToString("0.00"), f10, New RectangleF(xT, Y, colTW, h), fmtC)
                Y += h
                g.DrawLine(linePen, leftX, Y, leftX + tableW, Y)
            Next

            Dim tableEndY As Integer = Y
            Using borderPen As New Pen(Color.Black, 2.0!)
                g.DrawLine(borderPen, leftX, tableY, leftX + tableW, tableY)
                g.DrawLine(borderPen, leftX, tableY + headerH, leftX + tableW, tableY + headerH)
                g.DrawLine(borderPen, leftX, tableEndY, leftX + tableW, tableEndY)
                g.DrawLine(borderPen, xT, tableY, xT, tableEndY)
                g.DrawLine(borderPen, xN + colNW, tableY, xN + colNW, tableEndY)
            End Using
            g.DrawLine(linePen, xP, tableY, xP, tableEndY)
            g.DrawLine(linePen, xQ, tableY, xQ, tableEndY)
            g.DrawLine(linePen, xN, tableY, xN, tableEndY)

            If isLastItemPage Then
                ' [تعديل] المجاميع والفوتر بيتطبعوا بس في آخر صفحة أصناف
                separator()
                rightLineSafe("عدد الأصناف : " & items.Count, fBold)
                separator()

                If header.Discount > 0 Then
                    centerLine("إجمالي قبل الخصم : " & header.TotalAmount.ToString("0.00"), fTotalLarge)
                    centerLine("الخصم           : " & header.Discount.ToString("0.00"), fTotalLarge)
                    centerLine("الصافي          : " & header.NetAmount.ToString("0.00"), fTotalLarge)
                Else
                    centerLine("إجمالي الفاتورة : " & header.TotalAmount.ToString("0.00"), fTotalLarge)
                End If
                centerLine("المدفوع         : " & header.Paid.ToString("0.00"), fTotalLarge)
                centerLine("المتبقي         : " & header.Remaining.ToString("0.00"), fTotalLarge)

                If header.CustomerCode <> "1" Then
                    Dim totalBalance As Decimal = header.PreviousBalance + header.Remaining
                    separator()
                    rightLineSafe("رصيد سابق    : " & header.PreviousBalance.ToString("0.00"), fBold)
                    rightLineSafe("متبقي الفاتورة: " & header.Remaining.ToString("0.00"), fBold)
                    rightLineSafe("إجمالي الحساب: " & totalBalance.ToString("0.00"), fBold)
                End If

                separator()
                If printBarcode Then
                    Try
                        Dim qr As Bitmap = GenerateQRCode(header.InvoiceID.ToString())
                        g.DrawImage(qr, leftX + (usableW - qr.Width) \ 2, Y)
                        Y += qr.Height + 5
                    Catch
                    End Try
                End If
                centerLine("* " & FooterMsg & " *", fBold)
                If Not String.IsNullOrEmpty(DeliveryText) Then
                    centerLine("** " & DeliveryText & " **", fBold)
                End If
                separator()
            Else
                ' [جديد] تنويه بسيط في نهاية الصفحة إن فيه تكملة جاية
                separator()
                centerLine("... تابع في الصفحة التالية", f9)
            End If

            ' [تعديل] الشرط بيراعي إجمالي عدد الصفحات (نسخ * صفحات أصناف) مش عدد النسخ بس
            e.HasMorePages = (printedCount < totalPages)
        End Sub

        Try
            If usePreview Then
                ShowReportPreviewDialog(pd, previewTitle)
            Else
                pd.Print()
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If logoImg IsNot Nothing Then logoImg.Dispose()
        End Try
    End Sub

    Private Function GenerateQRCode(text As String) As Bitmap
        Dim barcodeType As String = SettingsManager.GetSettingOrDefault(SettingsKeys.InvoiceBarcodeType, "2D")
        If barcodeType.Equals("1D", StringComparison.OrdinalIgnoreCase) Then
            Return QRCodeHelper.GenerateBarcode1D(text, 180, 50)
        Else
            Return QRCodeHelper.GenerateQRCode(text, 110, 110)
        End If
    End Function
    Public Function GenerateInvoiceText2(invoiceID As Integer) As String
        ' 1. جلب بيانات رأس الفاتورة
        Dim header = GetInvoiceHeaderfromDB2(invoiceID)
        If header Is Nothing Then Return "❌ الفاتورة غير موجودة."

        ' 2. جلب تفاصيل الأصناف
        Dim items = GetInvoiceItemsfromDB2(invoiceID)
        If items.Count = 0 Then Return "❌ لا توجد أصناف في الفاتورة."

        ' 3. بناء نص الفاتورة
        Dim sb As New StringBuilder()
        Dim StoreName2 As String = If(SettingsManager.GetSetting("ShopName"), "سوبر ماركت الحمد والرضا")
        Dim Phone1 As String = If(SettingsManager.GetSetting("ShopPhone"), "")
        Dim Phone2 As String = If(SettingsManager.GetSetting("ShopPhone2"), "")
        Dim DeliveryText As String = SettingsManager.GetSetting("DeliveryText")
        If String.IsNullOrEmpty(DeliveryText) Then DeliveryText = "يوجد توصيل للمنازل"

        sb.AppendLine("🧾 *" & StoreName2 & "*")
        If Not String.IsNullOrEmpty(Phone1) Then sb.AppendLine("*هاتف : " + Phone1 + "*")
        If Not String.IsNullOrEmpty(Phone2) Then sb.AppendLine("*هاتف : " + Phone2 + "*")
        sb.AppendLine("🧾 *فاتورة مشتريات*")
        sb.AppendLine("رقم الفاتورة: " & header.Purchase_Id)
        sb.AppendLine("التاريخ: " & header.Purchase_Date.ToString("yyyy/MM/dd HH:mm"))
        sb.AppendLine("الكاشير: " & header.User_Name)
        sb.AppendLine("المورد: " & header.Supplier_Name & " (كود: " & header.Supplier_Code & ")")
        sb.AppendLine("─────────────────────────")
        sb.AppendLine("*المنتجات:*")

        For Each it In items
            sb.AppendLine($"{it.Product_Name}")
            sb.AppendLine($"الكمية: {it.Quantity_Sold} × السعر: {it.Purchase_Price_Per_Unit:0.00} = الإجمالي: {it.Total_Line_Amount:0.00}")
            sb.AppendLine("─────────────────────────")
        Next

        sb.AppendLine($"*إجمالي الفاتورة:* {header.Total_Amount:0.00}")
        If header.Discount_Value > 0 Then
            sb.AppendLine($"الخصم: {header.Discount_Value:0.00}")
            sb.AppendLine($"الصافي: {header.Amount_Paid:0.00}")
        End If
        sb.AppendLine($"المدفوع: {header.Amount_Paid:0.00}")
        sb.AppendLine($"المتبقي: {header.Remaining:0.00}")
        sb.AppendLine("❤ شكرًا لتعاملكم معنا")
        ' ✅ تحسين: سطر التوصيل
        If Not String.IsNullOrEmpty(DeliveryText) Then sb.AppendLine(DeliveryText)
        ' كود قديم: لم يكن موجوداً

        Return sb.ToString()
    End Function
    Public Function GenerateInvoiceText(invoiceID As Integer) As String
        ' 1. جلب بيانات رأس الفاتورة
        Dim header = GetInvoiceHeaderfromDB(invoiceID)
        If header Is Nothing Then Return "❌ الفاتورة غير موجودة."

        ' 2. جلب تفاصيل الأصناف
        Dim items = GetInvoiceItemsfromDB(invoiceID)
        If items.Count = 0 Then Return "❌ لا توجد أصناف في الفاتورة."

        ' 3. بناء نص الفاتورة
        Dim sb As New StringBuilder()
        Dim StoreName1 As String = If(SettingsManager.GetSetting("ShopName"), "سوبر ماركت الحمد والرضا")
        Dim Phone1 As String = If(SettingsManager.GetSetting("ShopPhone"), "")
        Dim Phone2 As String = If(SettingsManager.GetSetting("ShopPhone2"), "")
        Dim DeliveryText As String = SettingsManager.GetSetting("DeliveryText")
        If String.IsNullOrEmpty(DeliveryText) Then DeliveryText = "يوجد توصيل للمنازل"

        sb.AppendLine("🧾 *" & StoreName1 & "*")
        If Not String.IsNullOrEmpty(Phone1) Then sb.AppendLine("*هاتف : " + Phone1 + "*")
        If Not String.IsNullOrEmpty(Phone2) Then sb.AppendLine("*هاتف : " + Phone2 + "*")
        sb.AppendLine("🧾 *فاتورة مبيعات*")
        sb.AppendLine("رقم الفاتورة: " & header.InvoiceID)
        sb.AppendLine("التاريخ: " & header.InvoiceDate.ToString("yyyy/MM/dd HH:mm"))
        sb.AppendLine("الكاشير: " & header.UserName)
        sb.AppendLine("العميل: " & header.CustomerName & " (كود: " & header.CustomerCode & ")")
        sb.AppendLine("─────────────────────────")
        sb.AppendLine("*الأصناف:*")

        For Each it In items
            sb.AppendLine($"{it.ProductName}")
            sb.AppendLine($"الكمية: {it.Quantity} × السعر: {it.Price:0.00} = الإجمالي: {it.Total:0.00}")
            sb.AppendLine("─────────────────────────")
        Next

        sb.AppendLine($"*إجمالي الفاتورة:* {header.TotalAmount:0.00}")
        If header.Discount > 0 Then
            sb.AppendLine($"الخصم: {header.Discount:0.00}")
            sb.AppendLine($"الصافي: {header.NetAmount:0.00}")
        End If
        sb.AppendLine($"المدفوع: {header.Paid:0.00}")
        sb.AppendLine($"المتبقي: {header.Remaining:0.00}")
        ' ✅ تحسين: رصيد العميل السابق في رسالة واتساب
        If header.CustomerCode <> "1" AndAlso header.PreviousBalance <> 0 Then
            sb.AppendLine("─────────────────────────")
            sb.AppendLine($"رصيد سابق: {header.PreviousBalance:0.00}")
            Dim totalBal As Decimal = header.PreviousBalance + header.Remaining
            sb.AppendLine($"إجمالي الحساب: {totalBal:0.00}")
        End If
        ' كود قديم: لم يكن يظهر الرصيد السابق
        sb.AppendLine("❤ شكرًا لتعاملكم معنا")
        ' ✅ تحسين: توحيد إيموجي التوصيل
        If Not String.IsNullOrEmpty(DeliveryText) Then sb.AppendLine(DeliveryText)
        ' كود قديم: sb.AppendLine("❤ يوجد توصيل للمنازل")

        Return sb.ToString()
    End Function

End Module
Public Class InvoiceHeader
    Public Property InvoiceID As Integer
    Public Property InvoiceDate As DateTime
    Public Property CustomerCode As String
    Public Property CustomerName As String
    Public Property UserName As String
    Public Property TotalAmount As Decimal
    Public Property Discount As Decimal
    Public Property NetAmount As Decimal
    Public Property Paid As Decimal
    Public Property Remaining As Decimal
    Public Property PreviousBalance As Decimal
    Public Property PaymentMethod As String
End Class
Public Class InvoiceItem
    Public Property ProductName As String
    Public Property Quantity As Decimal
    Public Property Price As Decimal
    Public Property Total As Decimal
End Class
Public Class InvoicePurchaseHeader
    Public Property Purchase_Id As Integer
    Public Property Purchase_Date As DateTime
    Public Property Supplier_ID As String
    Public Property Supplier_Code As String
    Public Property Supplier_Name As String
    Public Property User_ID As String
    Public Property User_Name As String
    Public Property Net_Amount As Decimal
    Public Property Discount_Value As Decimal
    Public Property Total_Amount As Decimal
    Public Property Amount_Paid As Decimal
    Public Property Remaining As Decimal
    Public Property Notes As Decimal
    Public Property Payment_Method As String
    Public Property Purchase_type As String
End Class
Public Class InvoicePurchaseItem
    Public Property Product_Name As String
    Public Property Quantity_Sold As Decimal
    Public Property Purchase_Price_Per_Unit As Decimal
    Public Property Total_Line_Amount As Decimal
End Class
