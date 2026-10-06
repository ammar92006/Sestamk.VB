Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Services.Cloud

    ''' <summary>
    ''' خادم بوابات سستمك الذكية المدمج (Sestamk Embedded Live Web and Mobile Server).
    ''' خادم خفيف وعالمي مبني على TcpListener (IPAddress.Any) لقبول كافة الطلبات والاتصالات:
    '''   • يتجاوز قيود Windows HTTP.sys تماماً (لا يظهر خطأ 400 Invalid Hostname أو مشاكل الصلاحيات).
    '''   • يخدم بوابة المالك (/) وتطبيق الويتر المحمول (/waiter) وشاشة المطبخ الذكية (/kds).
    '''   • يدعم الوصول من localhost أو 127.0.0.1 أو الآي بي المحلي 192.168.x.x ومن كافة هواتف وشاشات الواي فاي.
    ''' </summary>
    Public NotInheritable Class OwnerPortalServer

        Private Shared _instance As OwnerPortalServer
        Private Shared ReadOnly _lockObj As New Object()

        Public Shared ReadOnly Property Instance As OwnerPortalServer
            Get
                If _instance Is Nothing Then
                    SyncLock _lockObj
                        If _instance Is Nothing Then
                            _instance = New OwnerPortalServer()
                        End If
                    End SyncLock
                End If
                Return _instance
            End Get
        End Property

        Private _tcpListener As TcpListener = Nothing
        Private _isRunning As Boolean = False
        Private _port As Integer = 5055

        Private Sub New()
        End Sub

        Public ReadOnly Property IsRunning As Boolean
            Get
                Return _isRunning
            End Get
        End Property

        Public ReadOnly Property Port As Integer
            Get
                Return _port
            End Get
        End Property

        ''' <summary>
        ''' بدء تشغيل خادم البوابات الذكية في الخلفية على المنفذ المحدد.
        ''' </summary>
        Public Function StartServer(Optional port As Integer = 5055) As Boolean
            If _isRunning Then Return True
            _port = port

            Try
                _tcpListener = New TcpListener(IPAddress.Any, _port)
                _tcpListener.Start()
                _isRunning = True

                Task.Run(AddressOf ListenLoopAsync)
                Logger.LogInfo($"OwnerPortalServer: Started successfully on 0.0.0.0:{_port} via TcpListener.")
                Return True

            Catch ex As Exception
                _isRunning = False
                Logger.LogError("OwnerPortalServer.StartServer", ex)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' إيقاف السيرفر بأمان.
        ''' </summary>
        Public Sub StopServer()
            If Not _isRunning Then Return
            Try
                _isRunning = False
                If _tcpListener IsNot Nothing Then
                    _tcpListener.Stop()
                    _tcpListener = Nothing
                End If
                Logger.LogInfo("OwnerPortalServer: Stopped.")
            Catch ex As Exception
                Logger.LogError("OwnerPortalServer.StopServer", ex)
            End Try
        End Sub

        ''' <summary>
        ''' جلب الآي بي المحلي لجهاز الكاشير على شبكة الواي فاي أو الشبكة المحلية.
        ''' </summary>
        Public Shared Function GetLocalIPAddress() As String
            Try
                Dim host = Dns.GetHostEntry(Dns.GetHostName())
                For Each ip In host.AddressList
                    If ip.AddressFamily = Sockets.AddressFamily.InterNetwork AndAlso Not IPAddress.IsLoopback(ip) Then
                        Dim ipStr = ip.ToString()
                        If Not ipStr.StartsWith("169.254.") Then
                            Return ipStr
                        End If
                    End If
                Next
            Catch
            End Try
            Return "127.0.0.1"
        End Function

        Public Function GetMobilePortalUrl() As String
            Dim ip = GetLocalIPAddress()
            Return $"http://{ip}:{_port}/"
        End Function

        Public Function GetWaiterPortalUrl() As String
            Dim ip = GetLocalIPAddress()
            Return $"http://{ip}:{_port}/waiter"
        End Function

        Public Function GetKdsPortalUrl() As String
            Dim ip = GetLocalIPAddress()
            Return $"http://{ip}:{_port}/kds"
        End Function

        Public Function GetLocalPortalUrl() As String
            Return $"http://127.0.0.1:{_port}/"
        End Function

        ' ──────────────────────────────────────────────────────────
        ' حلقة الاستماع ومعالجة اتصالات العملاء
        ' ──────────────────────────────────────────────────────────
        Private Async Function ListenLoopAsync() As Task
            While _isRunning AndAlso _tcpListener IsNot Nothing
                Try
                    Dim client = Await _tcpListener.AcceptTcpClientAsync()
                    Dim processTask = Task.Run(Sub() ProcessClient(client))
                Catch ex As ObjectDisposedException
                    Exit While
                Catch ex As SocketException
                    If Not _isRunning Then Exit While
                Catch ex As Exception
                    If Not _isRunning Then Exit While
                End Try
            End While
        End Function

        Private Sub ProcessClient(client As TcpClient)
            Using client
                Try
                    Dim stream = client.GetStream()
                    stream.ReadTimeout = 5000
                    stream.WriteTimeout = 5000

                    Dim reader As New StreamReader(stream, Encoding.UTF8)
                    Dim reqLine = reader.ReadLine()
                    If String.IsNullOrWhiteSpace(reqLine) Then Return

                    Dim parts = reqLine.Split(" "c)
                    If parts.Length < 2 Then Return
                    Dim method = parts(0).ToUpperInvariant()
                    Dim rawPath = parts(1)

                    ' قراءة الترويسات (Headers)
                    Dim headers As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
                    Dim contentLength As Integer = 0
                    Dim line As String = reader.ReadLine()

                    While Not String.IsNullOrEmpty(line)
                        Dim colonIdx = line.IndexOf(":"c)
                        If colonIdx > 0 Then
                            Dim hName = line.Substring(0, colonIdx).Trim()
                            Dim hVal = line.Substring(colonIdx + 1).Trim()
                            headers(hName) = hVal
                            If hName.Equals("Content-Length", StringComparison.OrdinalIgnoreCase) Then
                                Integer.TryParse(hVal, contentLength)
                            End If
                        End If
                        line = reader.ReadLine()
                    End While

                    ' قراءة جسم الطلب (Body) في حال كان الطلب POST
                    Dim bodyStr As String = ""
                    If contentLength > 0 Then
                        Dim buffer(contentLength - 1) As Char
                        Dim totalRead As Integer = 0
                        While totalRead < contentLength
                            Dim r = reader.Read(buffer, totalRead, contentLength - totalRead)
                            If r <= 0 Then Exit While
                            totalRead += r
                        End While
                        bodyStr = New String(buffer, 0, totalRead)
                    End If

                    ' استخراج المسار النظيف بدون Query String
                    Dim cleanPath = rawPath
                    Dim qIdx = cleanPath.IndexOf("?"c)
                    If qIdx >= 0 Then cleanPath = cleanPath.Substring(0, qIdx)
                    cleanPath = cleanPath.ToLowerInvariant().TrimEnd("/"c)
                    If String.IsNullOrEmpty(cleanPath) Then cleanPath = "/"

                    ' التعامل مع طلبات Preflight OPTIONS للـ CORS
                    If method = "OPTIONS" Then
                        SendHttpResponse(stream, 200, "OK", "text/plain", Array.Empty(Of Byte)())
                        Return
                    End If

                    ' توجيه المسارات
                    Select Case cleanPath
                        Case "/", "/index.html"
                            SendFileResponse(stream, "index.html")

                        Case "/waiter", "/waiter.html"
                            SendFileResponse(stream, "waiter.html")

                        Case "/kds", "/kds.html"
                            SendFileResponse(stream, "kds.html")

                        Case "/api/summary"
                            SendJsonResponse(stream, BuildSummaryJson())

                        Case "/api/tables"
                            SendJsonResponse(stream, BuildTablesJson())

                        Case "/api/recent-orders"
                            SendJsonResponse(stream, BuildRecentOrdersJson())

                        Case "/api/top-items"
                            SendJsonResponse(stream, BuildTopItemsJson())

                        Case "/api/menu"
                            SendJsonResponse(stream, BuildMenuJson())

                        Case "/api/order/waiter"
                            SendJsonResponse(stream, HandleWaiterOrderPost(bodyStr))

                        Case "/api/kds/orders"
                            SendJsonResponse(stream, BuildKdsOrdersJson())

                        Case "/api/kds/bump"
                            SendJsonResponse(stream, HandleKdsBumpPost(bodyStr))

                        Case Else
                            Dim notFoundBytes = Encoding.UTF8.GetBytes("404 Not Found")
                            SendHttpResponse(stream, 404, "Not Found", "text/plain; charset=utf-8", notFoundBytes)
                    End Select

                Catch ex As Exception
                    Logger.LogError("OwnerPortalServer.ProcessClient", ex)
                End Try
            End Using
        End Sub

        Private Sub SendJsonResponse(stream As NetworkStream, json As String)
            Dim bytes = Encoding.UTF8.GetBytes(json)
            SendHttpResponse(stream, 200, "OK", "application/json; charset=utf-8", bytes)
        End Sub

        Private Sub SendFileResponse(stream As NetworkStream, fileName As String)
            Dim htmlContent As String = ""
            Dim portalPath = Path.Combine(Application.StartupPath, "WebPortal", fileName)

            If File.Exists(portalPath) Then
                Try
                    htmlContent = File.ReadAllText(portalPath, Encoding.UTF8)
                Catch
                End Try
            End If

            If String.IsNullOrWhiteSpace(htmlContent) Then
                Dim devPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "WebPortal", fileName)
                If File.Exists(devPath) Then
                    Try
                        htmlContent = File.ReadAllText(devPath, Encoding.UTF8)
                    Catch
                    End Try
                End If
            End If

            If String.IsNullOrWhiteSpace(htmlContent) Then
                htmlContent = "<!DOCTYPE html><html dir='rtl'><head><meta charset='utf-8'><title>سستمك</title></head><body style='font-family:sans-serif;padding:30px;background:#0F172A;color:#fff;'><h2>سستمك Live</h2><p>الملف قيد التجهيز: " & fileName & "</p></body></html>"
            End If

            Dim bytes = Encoding.UTF8.GetBytes(htmlContent)
            SendHttpResponse(stream, 200, "OK", "text/html; charset=utf-8", bytes)
        End Sub

        Private Sub SendHttpResponse(stream As NetworkStream, statusCode As Integer, statusText As String, contentType As String, body() As Byte)
            Try
                Dim sb As New StringBuilder()
                sb.AppendLine($"HTTP/1.1 {statusCode} {statusText}")
                sb.AppendLine($"Content-Type: {contentType}")
                sb.AppendLine($"Content-Length: {body.Length}")
                sb.AppendLine("Access-Control-Allow-Origin: *")
                sb.AppendLine("Access-Control-Allow-Methods: GET, POST, OPTIONS")
                sb.AppendLine("Access-Control-Allow-Headers: Content-Type, Authorization")
                sb.AppendLine("Connection: close")
                sb.AppendLine()

                Dim headerBytes = Encoding.ASCII.GetBytes(sb.ToString())
                stream.Write(headerBytes, 0, headerBytes.Length)
                If body.Length > 0 Then
                    stream.Write(body, 0, body.Length)
                End If
                stream.Flush()
            Catch
            End Try
        End Sub

        ' =========================================================
        ' بناء ردود JSON للـ APIs
        ' =========================================================

        Private Function BuildSummaryJson() As String
            Dim shopName = SettingsManager.GetSetting(SettingsKeys.ShopName)
            If String.IsNullOrWhiteSpace(shopName) Then shopName = "سستمك POS"

            Dim salesNet As Decimal = 0D
            Dim salesOrders As Integer = 0
            Dim salesCash As Decimal = 0D
            Dim salesVisa As Decimal = 0D

            Try
                Dim sqlSales = "
                SELECT 
                    ISNULL(SUM(NetTotal), 0) AS TotalNet,
                    COUNT(1) AS TotalOrders,
                    ISNULL(SUM(CASE WHEN PaymentType LIKE N'%نقدي%' THEN PaidAmount ELSE 0 END), 0) AS TotalCash,
                    ISNULL(SUM(CASE WHEN PaymentType LIKE N'%فيزا%' OR PaymentType LIKE N'%شبكة%' THEN PaidAmount ELSE 0 END), 0) AS TotalVisa
                FROM SalesInvoices 
                WHERE (IsDeleted = 0 OR IsDeleted IS NULL) 
                  AND CAST(InvoiceDate AS DATE) = CAST(GETDATE() AS DATE);"

                Dim dt = DBModule.ExecuteQuery(sqlSales)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    salesNet = Convert.ToDecimal(dt.Rows(0)("TotalNet"))
                    salesOrders = Convert.ToInt32(dt.Rows(0)("TotalOrders"))
                    salesCash = Convert.ToDecimal(dt.Rows(0)("TotalCash"))
                    salesVisa = Convert.ToDecimal(dt.Rows(0)("TotalVisa"))
                End If
            Catch ex As Exception
                Logger.LogError("OwnerPortal.BuildSummaryJson.Sales", ex)
            End Try

            Dim purchasesTotal As Decimal = 0D
            Dim purchasesCount As Integer = 0
            Try
                Dim sqlPur = "SELECT ISNULL(SUM(NetTotal), 0) AS Total, COUNT(1) AS Cnt FROM PurchaseHeaders WHERE CAST(PurchaseDate AS DATE) = CAST(GETDATE() AS DATE) AND (IsDeleted = 0 OR IsDeleted IS NULL);"
                Dim dt = DBModule.ExecuteQuery(sqlPur)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    purchasesTotal = Convert.ToDecimal(dt.Rows(0)("Total"))
                    purchasesCount = Convert.ToInt32(dt.Rows(0)("Cnt"))
                End If
            Catch
            End Try

            Dim expensesTotal As Decimal = 0D
            Try
                Dim sqlExp = "SELECT ISNULL(SUM(Amount), 0) AS Total FROM Expenses WHERE CAST(Expense_Date AS DATE) = CAST(GETDATE() AS DATE);"
                Dim dt = DBModule.ExecuteQuery(sqlExp)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    expensesTotal = Convert.ToDecimal(dt.Rows(0)("Total"))
                End If
            Catch
            End Try

            Dim treasuryBalance As Decimal = 0D
            Try
                Dim dt = DBModule.ExecuteQuery("SELECT ISNULL(SUM(CurrentBalance), 0) FROM Treasury WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL);")
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    treasuryBalance = Convert.ToDecimal(dt.Rows(0)(0))
                End If
            Catch
            End Try

            Dim totalTables As Integer = 0
            Dim occupiedTables As Integer = 0
            Dim freeTables As Integer = 0
            Dim reservedTables As Integer = 0
            Dim activeTabTotal As Decimal = 0D

            Try
                Dim dtTbls = DBModule.ExecuteQuery("SELECT TableStatus, COUNT(1) AS Cnt FROM RestaurantTables WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) GROUP BY TableStatus;")
                If dtTbls IsNot Nothing Then
                    For Each r As DataRow In dtTbls.Rows
                        Dim status = Convert.ToByte(r("TableStatus"))
                        Dim cnt = Convert.ToInt32(r("Cnt"))
                        totalTables += cnt
                        If status = 1 Then freeTables = cnt
                        If status = 2 Then occupiedTables = cnt
                        If status = 3 Then reservedTables = cnt
                    Next
                End If

                Dim dtPending = DBModule.ExecuteQuery("SELECT ISNULL(SUM(TotalAmount), 0) FROM PendingInvoices WHERE IsActive = 1 AND TableID > 0;")
                If dtPending IsNot Nothing AndAlso dtPending.Rows.Count > 0 Then
                    activeTabTotal = Convert.ToDecimal(dtPending.Rows(0)(0))
                End If
            Catch
            End Try

            Dim occupancyRate As Integer = If(totalTables > 0, CInt(Math.Round((occupiedTables * 100.0) / totalTables)), 0)

            Dim activeShiftObj As New JObject()
            Try
                Dim dtShift = DBModule.ExecuteQuery("
                SELECT TOP 1 s.ShiftID, s.OpeningDate, s.OpeningCash, s.TotalSales, s.TotalExpenses, u.User_Name 
                FROM Shifts s 
                LEFT JOIN Users_TBL u ON s.UserID = u.User_ID 
                WHERE s.Status = 1 
                ORDER BY s.ShiftID DESC;")

                If dtShift IsNot Nothing AndAlso dtShift.Rows.Count > 0 Then
                    Dim r = dtShift.Rows(0)
                    activeShiftObj("shiftId") = Convert.ToInt32(r("ShiftID"))
                    activeShiftObj("cashier") = If(IsDBNull(r("User_Name")), "المدير", r("User_Name").ToString())
                    activeShiftObj("openedAt") = If(IsDBNull(r("OpeningDate")), "--:--", Convert.ToDateTime(r("OpeningDate")).ToString("yyyy-MM-dd HH:mm"))
                    activeShiftObj("openingCash") = Convert.ToDecimal(r("OpeningCash"))
                    activeShiftObj("totalSales") = Convert.ToDecimal(r("TotalSales"))
                    activeShiftObj("totalExpenses") = Convert.ToDecimal(r("TotalExpenses"))
                Else
                    activeShiftObj("shiftId") = 0
                    activeShiftObj("cashier") = "لا توجد وردية نشطة"
                    activeShiftObj("openedAt") = "--:--"
                    activeShiftObj("openingCash") = 0
                    activeShiftObj("totalSales") = 0
                    activeShiftObj("totalExpenses") = 0
                End If
            Catch
            End Try

            Dim root As New JObject From {
                {"success", True},
                {"shopName", shopName},
                {"generatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                {"todaySales", New JObject From {
                    {"netTotal", salesNet},
                    {"ordersCount", salesOrders},
                    {"cashSales", salesCash},
                    {"visaSales", salesVisa},
                    {"averageTicket", If(salesOrders > 0, Math.Round(salesNet / salesOrders, 2), 0)}
                }},
                {"todayPurchases", New JObject From {
                    {"total", purchasesTotal},
                    {"count", purchasesCount}
                }},
                {"todayExpenses", New JObject From {
                    {"total", expensesTotal}
                }},
                {"netProfit", (salesNet - purchasesTotal - expensesTotal)},
                {"treasury", New JObject From {
                    {"currentBalance", treasuryBalance}
                }},
                {"floor", New JObject From {
                    {"totalTables", totalTables},
                    {"occupiedTables", occupiedTables},
                    {"freeTables", freeTables},
                    {"reservedTables", reservedTables},
                    {"occupancyRate", occupancyRate},
                    {"activeTabTotal", activeTabTotal}
                }},
                {"activeShift", activeShiftObj}
            }

            Return root.ToString(Formatting.None)
        End Function

        Private Function BuildTablesJson() As String
            Dim arr As New JArray()
            Try
                Dim sql = "
                SELECT 
                    t.TableID, t.TableNumber, t.TableName, t.SectionID, t.ChairsCount, t.TableStatus,
                    s.SectionName,
                    p.PendingDate, p.TotalAmount, p.CustomerName AS OrderCustomer,
                    r.CustomerName AS ResvCustomer, r.ReservationDateTime, r.DepositAmount
                FROM RestaurantTables t
                INNER JOIN RestaurantSections s ON t.SectionID = s.SectionID
                OUTER APPLY (
                    SELECT TOP 1 PendingDate, TotalAmount, CustomerName 
                    FROM PendingInvoices 
                    WHERE TableID = t.TableID AND IsActive = 1 
                    ORDER BY PendingID DESC
                ) p
                OUTER APPLY (
                    SELECT TOP 1 CustomerName, ReservationDateTime, DepositAmount 
                    FROM TableReservations 
                    WHERE TableID = t.TableID AND Status = 1 
                    ORDER BY ReservationDateTime ASC
                ) r
                WHERE t.IsActive = 1 AND (t.IsDeleted = 0 OR t.IsDeleted IS NULL)
                ORDER BY t.TableNumber;"

                Dim dt = DBModule.ExecuteQuery(sql)
                If dt IsNot Nothing Then
                    For Each row As DataRow In dt.Rows
                        Dim item As New JObject()
                        item("id") = Convert.ToInt32(row("TableID"))
                        item("number") = row("TableNumber").ToString()
                        item("name") = If(IsDBNull(row("TableName")), "", row("TableName").ToString())
                        item("section") = row("SectionName").ToString()
                        item("chairs") = Convert.ToInt32(row("ChairsCount"))
                        item("status") = Convert.ToInt32(row("TableStatus"))

                        Dim elapsed = 0
                        If Not IsDBNull(row("PendingDate")) Then
                            Dim dtSeated = Convert.ToDateTime(row("PendingDate"))
                            elapsed = Math.Max(0, CInt((DateTime.Now - dtSeated).TotalMinutes))
                        End If
                        item("elapsedMinutes") = elapsed

                        item("totalAmount") = If(IsDBNull(row("TotalAmount")), 0D, Convert.ToDecimal(row("TotalAmount")))
                        item("customerName") = If(Not IsDBNull(row("OrderCustomer")), row("OrderCustomer").ToString(),
                                               If(Not IsDBNull(row("ResvCustomer")), row("ResvCustomer").ToString(), ""))

                        arr.Add(item)
                    Next
                End If
            Catch ex As Exception
                Logger.LogError("OwnerPortal.BuildTablesJson", ex)
            End Try

            Return arr.ToString(Formatting.None)
        End Function

        Private Function BuildRecentOrdersJson() As String
            Dim arr As New JArray()
            Try
                Dim sql = "
                SELECT TOP 15 
                    ISNULL(i.InvoiceNumber, CAST(i.InvoiceID AS VARCHAR)) AS InvoiceNumber,
                    CONVERT(VARCHAR(5), i.InvoiceDate, 108) AS InvoiceTime,
                    ISNULL(c.CustomerName, N'عميل نقدي') AS CustomerName,
                    CASE i.OrderType WHEN 1 THEN N'تيك أواي' WHEN 2 THEN N'صالة' WHEN 3 THEN N'دليفري' ELSE N'مبيعات' END AS OrderTypeName,
                    i.NetTotal,
                    i.PaymentType
                FROM SalesInvoices i
                LEFT JOIN Customers c ON i.CustomerID = c.CustomerID
                WHERE (i.IsDeleted = 0 OR i.IsDeleted IS NULL)
                  AND CAST(i.InvoiceDate AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY i.InvoiceID DESC;"

                Dim dt = DBModule.ExecuteQuery(sql)
                If dt IsNot Nothing Then
                    For Each r As DataRow In dt.Rows
                        Dim it As New JObject()
                        it("invoiceNumber") = r("InvoiceNumber").ToString()
                        it("time") = r("InvoiceTime").ToString()
                        it("customerName") = r("CustomerName").ToString()
                        it("orderType") = r("OrderTypeName").ToString()
                        it("netTotal") = Convert.ToDecimal(r("NetTotal"))
                        it("paymentType") = r("PaymentType").ToString()
                        arr.Add(it)
                    Next
                End If
            Catch ex As Exception
                Logger.LogError("OwnerPortal.BuildRecentOrdersJson", ex)
            End Try

            Return arr.ToString(Formatting.None)
        End Function

        Private Function BuildTopItemsJson() As String
            Dim arr As New JArray()
            Try
                Dim sql = "
                SELECT TOP 10 
                    d.ProductName,
                    SUM(d.Quantity) AS TotalQty,
                    SUM(d.TotalPrice) AS TotalSales
                FROM SalesInvoiceDetails d
                INNER JOIN SalesInvoices i ON d.InvoiceID = i.InvoiceID
                WHERE (i.IsDeleted = 0 OR i.IsDeleted IS NULL)
                  AND CAST(i.InvoiceDate AS DATE) = CAST(GETDATE() AS DATE)
                  AND d.Quantity > 0
                GROUP BY d.ProductName
                ORDER BY TotalQty DESC;"

                Dim dt = DBModule.ExecuteQuery(sql)
                If dt IsNot Nothing Then
                    For Each r As DataRow In dt.Rows
                        Dim it As New JObject()
                        it("name") = r("ProductName").ToString()
                        it("quantity") = Convert.ToInt32(r("TotalQty"))
                        it("total") = Convert.ToDecimal(r("TotalSales"))
                        arr.Add(it)
                    Next
                End If
            Catch ex As Exception
                Logger.LogError("OwnerPortal.BuildTopItemsJson", ex)
            End Try

            Return arr.ToString(Formatting.None)
        End Function

        Private Function BuildMenuJson() As String
            Dim root As New JObject()
            Dim categoriesArr As New JArray()
            Try
                Dim dtCats = DBModule.ExecuteQuery("SELECT Category_ID, Category_Name FROM Categories WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY Category_ID;")
                Dim dtProds = DBModule.ExecuteQuery("SELECT Product_ID, Category_ID, ProductName, ISNULL(ProductNameAr, ProductName) AS NameAr, SalePrice, ISNULL(Image, '') AS ProdImg, ISNULL(PreparationTime, '00:10:00') AS PrepTime FROM Products WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY Product_ID;")
                Dim dtSizes = DBModule.ExecuteQuery("SELECT ps.ProductSizeID, ps.ProductID, ps.SizeID, s.SizeNameAr, ps.SalePrice FROM ProductSizes ps INNER JOIN Sizes s ON ps.SizeID = s.SizeID WHERE ps.IsActive = 1 AND ps.IsDeleted = 0;")

                If dtCats IsNot Nothing Then
                    For Each cRow As DataRow In dtCats.Rows
                        Dim catId = Convert.ToInt32(cRow("Category_ID"))
                        Dim catObj As New JObject From {
                            {"id", catId},
                            {"name", cRow("Category_Name").ToString()},
                            {"items", New JArray()}
                        }

                        Dim catItems = DirectCast(catObj("items"), JArray)
                        If dtProds IsNot Nothing Then
                            For Each pRow As DataRow In dtProds.Select("Category_ID = " & catId)
                                Dim pId = Convert.ToInt32(pRow("Product_ID"))
                                Dim pObj As New JObject From {
                                    {"id", pId},
                                    {"name", pRow("ProductName").ToString()},
                                    {"nameAr", pRow("NameAr").ToString()},
                                    {"price", Convert.ToDecimal(pRow("SalePrice"))},
                                    {"prepTime", pRow("PrepTime").ToString()},
                                    {"sizes", New JArray()}
                                }

                                Dim sizesArr = DirectCast(pObj("sizes"), JArray)
                                If dtSizes IsNot Nothing Then
                                    For Each sRow As DataRow In dtSizes.Select("ProductID = " & pId)
                                        sizesArr.Add(New JObject From {
                                            {"sizeId", Convert.ToInt32(sRow("SizeID"))},
                                            {"sizeName", sRow("SizeNameAr").ToString()},
                                            {"price", Convert.ToDecimal(sRow("SalePrice"))}
                                        })
                                    Next
                                End If

                                catItems.Add(pObj)
                            Next
                        End If

                        categoriesArr.Add(catObj)
                    Next
                End If

                root("success") = True
                root("categories") = categoriesArr
            Catch ex As Exception
                root("success") = False
                root("error") = ex.Message
            End Try
            Return root.ToString(Formatting.None)
        End Function

        Private Function HandleWaiterOrderPost(bodyStr As String) As String
            Dim resObj As New JObject()
            Try
                If String.IsNullOrWhiteSpace(bodyStr) Then
                    resObj("success") = False
                    resObj("error") = "بيانات الطلب فارغة."
                    Return resObj.ToString()
                End If

                Dim payload = JObject.Parse(bodyStr)
                Dim tableId As Integer = Convert.ToInt32(payload("tableId"))
                Dim tableName As String = If(payload("tableName")?.ToString(), "طاولة " & tableId)
                Dim waiterName As String = If(payload("waiterName")?.ToString(), "الويتر")
                Dim orderNotes As String = If(payload("notes")?.ToString(), "")

                Dim itemsToken = payload("items")
                If itemsToken Is Nothing OrElse Not itemsToken.HasValues Then
                    resObj("success") = False
                    resObj("error") = "يجب اختيار صنف واحد على الأقل."
                    Return resObj.ToString()
                End If

                Dim newItemsList As New List(Of InvoiceDetailModel)()
                Dim kitchenItems As New List(Of KitchenOrderItemModel)()
                Dim itemsTotal As Decimal = 0D

                For Each it In itemsToken
                    Dim pId = Convert.ToInt32(it("productId"))
                    Dim pName = it("productName").ToString()
                    Dim sName = If(it("sizeName")?.ToString(), "")
                    Dim sId As Integer? = If(it("sizeId") IsNot Nothing AndAlso Convert.ToInt32(it("sizeId")) > 0, Convert.ToInt32(it("sizeId")), CType(Nothing, Integer?))
                    Dim uPrice = Convert.ToDecimal(it("unitPrice"))
                    Dim qty = Math.Max(1, Convert.ToInt32(it("quantity")))
                    Dim lineTotal = uPrice * qty
                    Dim itmNotes = If(it("notes")?.ToString(), "")

                    itemsTotal += lineTotal

                    newItemsList.Add(New InvoiceDetailModel With {
                        .ProductID = pId,
                        .ProductName = pName,
                        .SizeName = sName,
                        .SizeID = sId,
                        .UnitPrice = uPrice,
                        .Quantity = qty,
                        .TotalPrice = lineTotal,
                        .Notes = itmNotes
                    })

                    kitchenItems.Add(New KitchenOrderItemModel With {
                        .ProductID = pId,
                        .ProductName = pName,
                        .SizeName = sName,
                        .Quantity = qty,
                        .Notes = itmNotes,
                        .StationName = "المطبخ"
                    })
                Next

                Dim repo As New POSRepository(DBModule.ConnectionString)
                Dim existingPending = repo.GetPendingInvoiceByTableID(tableId)

                If existingPending IsNot Nothing Then
                    Dim mergedList As New List(Of InvoiceDetailModel)()
                    Try
                        Dim oldItems = JsonConvert.DeserializeObject(Of List(Of InvoiceDetailModel))(existingPending.InvoiceJSON)
                        If oldItems IsNot Nothing Then mergedList.AddRange(oldItems)
                    Catch
                    End Try
                    mergedList.AddRange(newItemsList)

                    Dim newGrandTotal As Decimal = 0D
                    For Each m In mergedList
                        newGrandTotal += m.TotalPrice
                    Next

                    existingPending.InvoiceJSON = JsonConvert.SerializeObject(mergedList)
                    existingPending.TotalAmount = newGrandTotal
                    existingPending.Notes = If(String.IsNullOrWhiteSpace(existingPending.Notes), $"طلب من {waiterName}: {orderNotes}", $"{existingPending.Notes} | {waiterName}: {orderNotes}")
                    repo.UpdatePendingInvoice(existingPending)
                Else
                    Dim newPending As New PendingInvoiceModel With {
                        .ShiftID = If(ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, 1),
                        .UserID = 1,
                        .OrderType = 2,
                        .TableID = tableId,
                        .TableName = tableName,
                        .CustomerName = "طلب صالة (" & tableName & ")",
                        .DeliveryFee = 0,
                        .InvoiceJSON = JsonConvert.SerializeObject(newItemsList),
                        .TotalAmount = itemsTotal,
                        .Notes = $"ويتر: {waiterName} {orderNotes}"
                    }
                    repo.SavePendingInvoice(newPending)
                    repo.UpdateTableStatus(tableId, 2)
                End If

                Dim kOrder As New KitchenOrderModel With {
                    .OrderType = 2,
                    .TableID = tableId,
                    .TableName = tableName,
                    .ServerName = waiterName,
                    .CustomerName = tableName,
                    .Notes = orderNotes,
                    .Status = KitchenOrderStatus.New,
                    .Items = kitchenItems
                }
                Dim kOrderId = repo.CreateKitchenOrderAsync(kOrder).GetAwaiter().GetResult()

                resObj("success") = True
                resObj("message") = "تم إرسال الطلب للمطبخ وتسجيله على الطاولة بنجاح!"
                resObj("kitchenOrderId") = kOrderId
                resObj("tableId") = tableId
                resObj("totalAdded") = itemsTotal
            Catch ex As Exception
                resObj("success") = False
                resObj("error") = "فشل تسجيل طلب الويتر: " & ex.Message
            End Try
            Return resObj.ToString(Formatting.None)
        End Function

        Private Function BuildKdsOrdersJson() As String
            Dim arr As New JArray()
            Try
                Dim repo As New POSRepository(DBModule.ConnectionString)
                Dim activeOrders = repo.GetActiveKitchenOrders()
                If activeOrders IsNot Nothing Then
                    For Each ko In activeOrders
                        Dim oObj As New JObject From {
                            {"orderId", ko.KitchenOrderID},
                            {"orderNumber", ko.OrderNumber},
                            {"orderType", ko.OrderType},
                            {"orderTypeDisplay", ko.OrderTypeDisplay},
                            {"tableId", If(ko.TableID.HasValue, ko.TableID.Value, 0)},
                            {"tableName", If(ko.TableName, "")},
                            {"serverName", If(ko.ServerName, "")},
                            {"customerName", If(ko.CustomerName, "")},
                            {"createdAt", ko.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")},
                            {"elapsedSeconds", ko.ElapsedSeconds},
                            {"elapsedFormatted", ko.ElapsedFormatted},
                            {"estimatedPrepMinutes", ko.EstimatedPrepMinutes},
                            {"status", CInt(ko.Status)},
                            {"notes", If(ko.Notes, "")},
                            {"items", New JArray()}
                        }

                        Dim itemsArr = DirectCast(oObj("items"), JArray)
                        If ko.Items IsNot Nothing Then
                            For Each itm In ko.Items
                                itemsArr.Add(New JObject From {
                                    {"detailId", itm.DetailID},
                                    {"productName", itm.ProductName},
                                    {"sizeName", If(itm.SizeName, "")},
                                    {"addonsText", If(itm.AddonsText, "")},
                                    {"quantity", itm.Quantity},
                                    {"notes", If(itm.Notes, "")},
                                    {"isCompleted", itm.IsCompleted}
                                })
                            Next
                        End If

                        arr.Add(oObj)
                    Next
                End If
            Catch ex As Exception
                Logger.LogError("OwnerPortal.BuildKdsOrdersJson", ex)
            End Try
            Return arr.ToString(Formatting.None)
        End Function

        Private Function HandleKdsBumpPost(bodyStr As String) As String
            Dim resObj As New JObject()
            Try
                Dim payload = JObject.Parse(bodyStr)
                Dim action = payload("action")?.ToString().ToLowerInvariant()
                Dim orderId = Convert.ToInt32(payload("orderId"))
                Dim repo As New POSRepository(DBModule.ConnectionString)

                Select Case action
                    Case "item"
                        Dim detailId = Convert.ToInt32(payload("detailId"))
                        Dim isComp = If(payload("isCompleted") IsNot Nothing, Convert.ToBoolean(payload("isCompleted")), True)
                        repo.ToggleKitchenItemStatus(detailId, isComp)
                        resObj("success") = True
                        resObj("action") = "item"

                    Case "bump"
                        repo.UpdateKitchenOrderStatus(orderId, KitchenOrderStatus.Bumped)
                        resObj("success") = True
                        resObj("action") = "bump"

                    Case "ready"
                        repo.UpdateKitchenOrderStatus(orderId, KitchenOrderStatus.Ready)
                        resObj("success") = True
                        resObj("action") = "ready"

                    Case "recall"
                        repo.RecallKitchenOrder(orderId)
                        resObj("success") = True
                        resObj("action") = "recall"

                    Case Else
                        resObj("success") = False
                        resObj("error") = "إجراء غير معروف."
                End Select
            Catch ex As Exception
                resObj("success") = False
                resObj("error") = ex.Message
            End Try
            Return resObj.ToString(Formatting.None)
        End Function

    End Class

End Namespace
