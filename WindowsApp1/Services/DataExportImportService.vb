Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports ClosedXML.Excel

Namespace Services

    ''' <summary>
    ''' كائن إشعار بنسبة وخطوة التقدم لعمليات التصدير والاستيراد
    ''' </summary>
    Public Class ExportProgress
        Public Property Percentage As Integer
        Public Property CurrentStep As String
        Public Property Details As String

        Public Sub New(percentage As Integer, currentStep As String, Optional details As String = "")
            Me.Percentage = percentage
            Me.CurrentStep = currentStep
            Me.Details = details
        End Sub
    End Class

    ''' <summary>
    ''' تعريف قسم أو جدول مدعوم للتصدير والاستيراد مع دعم الفلترة الزمنية
    ''' </summary>
    Public Class EntityExportInfo
        Public Property Key As String
        Public Property DisplayNameAr As String
        Public Property TableName As String
        Public Property SqlQuery As String
        Public Property CanImport As Boolean
        Public Property DateColumnName As String

        Public Sub New(key As String, displayNameAr As String, tableName As String, sqlQuery As String, Optional canImport As Boolean = False, Optional dateColumnName As String = Nothing)
            Me.Key = key
            Me.DisplayNameAr = displayNameAr
            Me.TableName = tableName
            Me.SqlQuery = sqlQuery
            Me.CanImport = canImport
            Me.DateColumnName = dateColumnName
        End Sub
    End Class

    ''' <summary>
    ''' نتيجة عملية الاستيراد من ملف إكسيل مع تتبع ملف الأخطاء
    ''' </summary>
    Public Class ImportResult
        Public Property SuccessCount As Integer = 0
        Public Property UpdatedCount As Integer = 0
        Public Property SkippedCount As Integer = 0
        Public Property ErrorCount As Integer = 0
        Public Property ErrorMessages As New List(Of String)()
        Public Property TotalRows As Integer = 0
        Public Property ErrorFilePath As String = ""
    End Class

    ''' <summary>
    ''' الخدمة المركزية الموحدة لتصدير واستيراد البيانات (Excel و PDF)
    ''' </summary>
    Public Class DataExportImportService

        ' ─────────────────────────────────────────────────────────────
        ' 1. قائمة الأقسام والجداول المدعومة في النظام
        ' ─────────────────────────────────────────────────────────────
        Public Shared ReadOnly Property SupportedEntities As List(Of EntityExportInfo)
            Get
                Dim list As New List(Of EntityExportInfo)()

                ' 1. العملاء
                list.Add(New EntityExportInfo("Customers", "العملاء", "Customers",
                    "SELECT CustomerCode AS [كود العميل], CustomerName AS [اسم العميل], " &
                    "ISNULL(Phone1, PhoneNumber) AS [رقم الهاتف], Address AS [العنوان], " &
                    "ISNULL(CreditLimit, 0) AS [حد الائتمان], ISNULL(CurrentBalance, 0) AS [الرصيد الحالي], " &
                    "CASE WHEN IsActive = 1 THEN N'نشط' ELSE N'غير نشط' END AS [الحالة], Notes AS [ملاحظات] " &
                    "FROM Customers WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY CustomerName", True, "CreatedAt"))

                ' 2. الموردين
                list.Add(New EntityExportInfo("Suppliers", "الموردين", "Suppliers",
                    "SELECT SupplierCode AS [كود المورد], ISNULL(SupplierName, SuppliersName) AS [اسم المورد], " &
                    "Phone AS [رقم الهاتف], Address AS [العنوان], OpeningBalance AS [الرصيد الافتتاحي], " &
                    "ISNULL(CurrentBalance, ISNULL(Balance, 0)) AS [الرصيد الحالي], " &
                    "CASE WHEN IsActive = 1 THEN N'نشط' ELSE N'غير نشط' END AS [الحالة], Notes AS [ملاحظات] " &
                    "FROM Suppliers WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY ISNULL(SupplierName, SuppliersName)", True, "CreatedAt"))

                ' 3. الأصناف والمنتجات
                list.Add(New EntityExportInfo("Products", "الأصناف والمنتجات", "Products",
                    "SELECT p.ProductCode AS [كود الصنف], p.ProductName AS [اسم الصنف], " &
                    "ISNULL(c.Category_NameAr, c.CategoryName) AS [القسم], " &
                    "ISNULL(p.PurchasePrice, 0) AS [سعر الشراء], ISNULL(p.SalePrice, 0) AS [سعر البيع], " &
                    "ISNULL(p.Quantity, 0) AS [الكمية], ISNULL(p.MinAlertQuantity, 0) AS [حد الطلب], " &
                    "p.Barcode AS [الباركود], " &
                    "CASE WHEN p.IsActive = 1 THEN N'نشط' ELSE N'غير نشط' END AS [الحالة] " &
                    "FROM Products p " &
                    "LEFT JOIN Categories c ON p.CategoryID = c.Category_ID OR p.CategoryID = c.CategoryID " &
                    "WHERE (p.IsDeleted = 0 OR p.IsDeleted IS NULL) ORDER BY p.ProductName", True, "CreatedAt"))

                ' 4. الأقسام والتصنيفات
                list.Add(New EntityExportInfo("Categories", "الأقسام والتصنيفات", "Categories",
                    "SELECT CategoryCode AS [كود القسم], ISNULL(Category_NameAr, CategoryName) AS [اسم القسم], " &
                    "Description AS [الوصف], " &
                    "CASE WHEN IsActive = 1 THEN N'نشط' ELSE N'غير نشط' END AS [الحالة] " &
                    "FROM Categories WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY ISNULL(Category_NameAr, CategoryName)", True, "CreatedAt"))

                ' 5. المخازن والمستودعات
                list.Add(New EntityExportInfo("Stores", "المخازن والمستودعات", "Stores",
                    "SELECT StoreCode AS [كود المخزن], StoreName AS [اسم المخزن], " &
                    "Address AS [العنوان], Phone AS [الهاتف], " &
                    "CASE WHEN IsActive = 1 THEN N'نشط' ELSE N'غير نشط' END AS [الحالة] " &
                    "FROM Stores WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY StoreName", False, "CreatedAt"))

                ' 6. الموظفين
                list.Add(New EntityExportInfo("Employees", "إدارة الموظفين", "Employees",
                    "SELECT EmployeeCode AS [كود الموظف], FullName AS [الاسم الكامل], " &
                    "NationalID AS [الرقم القومي], Phone AS [الهاتف], JobTitle AS [المسمى الوظيفي], " &
                    "ISNULL(BasicSalary, 0) AS [الراتب الأساسي], " &
                    "CONVERT(VARCHAR(10), HireDate, 120) AS [تاريخ التعيين], " &
                    "CASE WHEN IsActive = 1 THEN N'نشط' ELSE N'غير نشط' END AS [الحالة] " &
                    "FROM Employees WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY FullName", False, "HireDate"))

                ' 7. المستخدمين
                list.Add(New EntityExportInfo("Users", "المستخدمين وحسابات الدخول", "Users",
                    "SELECT UserCode AS [كود المستخدم], UserName AS [اسم المستخدم], FullName AS [الاسم الكامل], " &
                    "UserRole AS [الصلاحية / الدور], Phone AS [الهاتف], " &
                    "CASE WHEN IsActive = 1 THEN N'نشط' ELSE N'موقوف' END AS [الحالة] " &
                    "FROM Users WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY FullName", False, "CreatedAt"))

                ' 8. الخزائن ونقاط النقدية
                list.Add(New EntityExportInfo("Treasury", "الخزائن ونقاط النقدية", "Treasury",
                    "SELECT TreasuryName AS [اسم الخزينة], ISNULL(Balance, 0) AS [الرصيد الحالي], " &
                    "CASE WHEN IsDefault = 1 THEN N'نعم' ELSE N'لا' END AS [الخزينة الافتراضية], " &
                    "CASE WHEN IsActive = 1 THEN N'نشطة' ELSE N'معطلة' END AS [الحالة] " &
                    "FROM Treasury WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY TreasuryName", False, Nothing))

                ' 9. المصروفات
                list.Add(New EntityExportInfo("Expenses", "سجل المصروفات", "Expenses",
                    "SELECT CONVERT(VARCHAR(10), ISNULL(ExpenseDate, Expense_Date), 120) AS [التاريخ], " &
                    "ISNULL(ExpenseType, Category) AS [نوع المصروف], Amount AS [المبلغ], " &
                    "Notes AS [البيان / ملاحظات], PaymentMethod AS [طريقة الدفع] " &
                    "FROM Expenses WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY ISNULL(ExpenseDate, Expense_Date) DESC", False, "ExpenseDate"))

                ' 10. فواتير المبيعات
                list.Add(New EntityExportInfo("Invoices", "فواتير المبيعات", "Invoices",
                    "SELECT TOP 5000 InvoiceNumber AS [رقم الفاتورة], " &
                    "CONVERT(VARCHAR(16), InvoiceDate, 120) AS [تاريخ الفاتورة], " &
                    "CustomerName AS [العميل], OrderType AS [نوع الطلب], " &
                    "SubTotal AS [المجموع], DiscountAmount AS [الخصم], TaxAmount AS [الضريبة], " &
                    "FinalTotal AS [الإجمالي النهائي], PaidAmount AS [المدفوع], " &
                    "RemainingAmount AS [المتبقي], PaymentStatus AS [حالة الدفع] " &
                    "FROM Invoices ORDER BY InvoiceID DESC", False, "InvoiceDate"))

                ' 11. فواتير المشتريات
                list.Add(New EntityExportInfo("Purchases", "فواتير مشتريات الخامات", "PurchaseHeaders",
                    "SELECT TOP 5000 InvoiceNumber AS [رقم الفاتورة], " &
                    "CONVERT(VARCHAR(16), PurchaseDate, 120) AS [تاريخ الشراء], " &
                    "(SELECT SupplierName FROM Suppliers S WHERE S.SupplierID=PurchaseHeaders.SupplierID) AS [المورد], TotalAmount AS [الإجمالي], " &
                    "Discount AS [الخصم], NetTotal AS [الصافي], " &
                    "PaidAmount AS [المدفوع], RemainingAmount AS [المتبقي] " &
                    "FROM PurchaseHeaders WHERE ISNULL(IsDeleted,0)=0 ORDER BY PurchaseID DESC", False, "PurchaseDate"))

                ' 12. وحدات القياس
                list.Add(New EntityExportInfo("Units", "وحدات القياس", "Units",
                    "SELECT UnitCode AS [كود الوحدة], UnitNameAr AS [اسم الوحدة], " &
                    "ConversionFactor AS [معامل التحويل], " &
                    "CASE WHEN IsActive = 1 THEN N'نشط' ELSE N'غير نشط' END AS [الحالة] " &
                    "FROM Units WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY UnitNameAr", False, "CreatedAt"))

                ' 13. المخزون الافتتاحي وجرد المخازن (استيراد وتحديث المخزون)
                list.Add(New EntityExportInfo("StockAdjustment", "المخزون الافتتاحي وجرد المخازن", "Products",
                    "SELECT p.ProductCode AS [كود الصنف], p.Barcode AS [الباركود], p.ProductName AS [اسم الصنف], " &
                    "ISNULL(p.Quantity, 0) AS [الكمية الحالية], ISNULL(p.PurchasePrice, 0) AS [سعر التكلفة] " &
                    "FROM Products p WHERE (p.IsDeleted = 0 OR p.IsDeleted IS NULL) ORDER BY p.ProductName", True, "CreatedAt"))

                Return list
            End Get
        End Property

        Public Shared Function GetEntityByKey(key As String) As EntityExportInfo
            For Each item In SupportedEntities
                If String.Equals(item.Key, key, StringComparison.OrdinalIgnoreCase) Then
                    Return item
                End If
            Next
            Return Nothing
        End Function

        ' ─────────────────────────────────────────────────────────────
        ' 2. جلب بيانات جدول محدد بأمان مع دعم فلترة التواريخ
        ' ─────────────────────────────────────────────────────────────
        Public Shared Function GetEntityDataTable(info As EntityExportInfo, Optional fromDate As Nullable(Of DateTime) = Nothing, Optional toDate As Nullable(Of DateTime) = Nothing) As DataTable
            Dim dt As New DataTable()
            If info Is Nothing Then Return dt

            Try
                Using conn As New SqlConnection(DBModule.ConnectionString)
                    conn.Open()

                    Dim checkSql = "SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @Tbl;"
                    Using chkCmd As New SqlCommand(checkSql, conn)
                        chkCmd.Parameters.AddWithValue("@Tbl", info.TableName)
                        Dim exists = Convert.ToInt32(chkCmd.ExecuteScalar()) > 0
                        If Not exists Then Return dt
                    End Using

                    Dim finalSql As String = info.SqlQuery

                    ' تطبيق فلترة التواريخ إذا طُلبت وكان الحقل مدعوماً
                    Dim hasDateFilter = fromDate.HasValue AndAlso toDate.HasValue AndAlso Not String.IsNullOrEmpty(info.DateColumnName)
                    If hasDateFilter Then
                        Dim dateCol = info.DateColumnName
                        ' إذا كان الاستعلام يحتوي على WHERE نقوم بالدمج قبل ORDER BY
                        Dim orderByIndex = finalSql.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase)
                        Dim filterClause = $" AND {dateCol} >= @FromDate AND {dateCol} <= @ToDate "

                        If orderByIndex >= 0 Then
                            Dim beforeOrder = finalSql.Substring(0, orderByIndex)
                            Dim afterOrder = finalSql.Substring(orderByIndex)
                            If beforeOrder.IndexOf("WHERE", StringComparison.OrdinalIgnoreCase) >= 0 Then
                                finalSql = beforeOrder & filterClause & afterOrder
                            Else
                                finalSql = beforeOrder & " WHERE " & filterClause.Substring(5) & afterOrder
                            End If
                        Else
                            If finalSql.IndexOf("WHERE", StringComparison.OrdinalIgnoreCase) >= 0 Then
                                finalSql &= filterClause
                            Else
                                finalSql &= " WHERE " & filterClause.Substring(5)
                            End If
                        End If
                    End If

                    Using cmd As New SqlCommand(finalSql, conn)
                        cmd.CommandTimeout = 60
                        If hasDateFilter Then
                            Dim fDate = fromDate.Value.Date
                            Dim tDate = toDate.Value.Date.AddDays(1).AddSeconds(-1)
                            cmd.Parameters.AddWithValue("@FromDate", fDate)
                            cmd.Parameters.AddWithValue("@ToDate", tDate)
                        End If

                        Using da As New SqlDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Debug.WriteLine($"GetEntityDataTable ({info.Key}) error: " & ex.Message)
            End Try

            Return dt
        End Function

        ' ─────────────────────────────────────────────────────────────
        ' 3. تصدير كافة بيانات النظام في ملف إكسيل واحد (شيتات متعددة)
        ' ─────────────────────────────────────────────────────────────
        Public Shared Async Function ExportAllToExcelAsync(filePath As String, progress As IProgress(Of ExportProgress), Optional cancellationToken As CancellationToken = Nothing) As Task(Of Boolean)
            Return Await Task.Run(
                Function() As Boolean
                    Try
                        Dim entities = SupportedEntities
                        Dim total = entities.Count
                        If total = 0 Then Return False

                        progress?.Report(New ExportProgress(5, "بدء إنشاء ملف الإكسيل الشامل...", "تهيئة الملف..."))

                        Using wb As New XLWorkbook()
                            For i As Integer = 0 To total - 1
                                cancellationToken.ThrowIfCancellationRequested()

                                Dim entity = entities(i)
                                If entity.Key = "StockAdjustment" Then Continue For ' لا حاجة لتكرار الأصناف

                                Dim currentPercent = 10 + CInt(((i + 1) / CDbl(total)) * 80)
                                progress?.Report(New ExportProgress(currentPercent, $"جارٍ تصدير [{entity.DisplayNameAr}] ({i + 1}/{total})...", entity.DisplayNameAr))

                                Dim dt = GetEntityDataTable(entity)
                                Dim sheetTitle = entity.DisplayNameAr
                                If sheetTitle.Length > 30 Then sheetTitle = sheetTitle.Substring(0, 30)

                                Dim ws = wb.Worksheets.Add(sheetTitle)
                                ws.RightToLeft = True

                                If dt.Rows.Count > 0 Then
                                    Dim table = ws.Cell(1, 1).InsertTable(dt, "Tbl_" & entity.Key, True)
                                    table.Theme = XLTableTheme.TableStyleMedium9
                                Else
                                    For colIndex As Integer = 0 To dt.Columns.Count - 1
                                        Dim cell = ws.Cell(1, colIndex + 1)
                                        cell.Value = dt.Columns(colIndex).ColumnName
                                        cell.Style.Font.Bold = True
                                        cell.Style.Fill.BackgroundColor = XLColor.FromArgb(46, 117, 182)
                                        cell.Style.Font.FontColor = XLColor.White
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                                    Next
                                End If

                                ws.Columns().AdjustToContents()
                            Next

                            cancellationToken.ThrowIfCancellationRequested()
                            progress?.Report(New ExportProgress(95, "جارٍ حفظ الملف النهائي على القرص...", "حفظ الملف..."))
                            wb.SaveAs(filePath)
                        End Using

                        progress?.Report(New ExportProgress(100, "تم التصدير الشامل بنجاح!", "اكتمل التصدير"))
                        Return True
                    Catch ex As OperationCanceledException
                        progress?.Report(New ExportProgress(0, "تم إلغاء عملية التصدير.", "ملغى"))
                        Return False
                    Catch ex As Exception
                        Debug.WriteLine("ExportAllToExcelAsync error: " & ex.Message)
                        Throw
                    End Try
                End Function, cancellationToken)
        End Function

        ' ─────────────────────────────────────────────────────────────
        ' 4. تصدير قسم محدد إلى ملف Excel مع دعم التواريخ والإلغاء
        ' ─────────────────────────────────────────────────────────────
        Public Shared Async Function ExportSingleToExcelAsync(entityKey As String, filePath As String, progress As IProgress(Of ExportProgress), Optional fromDate As Nullable(Of DateTime) = Nothing, Optional toDate As Nullable(Of DateTime) = Nothing, Optional cancellationToken As CancellationToken = Nothing) As Task(Of Boolean)
            Return Await Task.Run(
                Function() As Boolean
                    Try
                        cancellationToken.ThrowIfCancellationRequested()

                        Dim entity = GetEntityByKey(entityKey)
                        If entity Is Nothing Then Throw New ArgumentException("القسم المحدد غير موجود")

                        progress?.Report(New ExportProgress(20, $"جارٍ استخراج بيانات [{entity.DisplayNameAr}]...", "استخراج البيانات"))
                        Dim dt = GetEntityDataTable(entity, fromDate, toDate)

                        cancellationToken.ThrowIfCancellationRequested()

                        progress?.Report(New ExportProgress(60, "جارٍ إنشاء ورقة العمل وتنسيق الجداول...", "تنسيق Excel"))
                        Using wb As New XLWorkbook()
                            Dim ws = wb.Worksheets.Add(entity.DisplayNameAr)
                            ws.RightToLeft = True

                            If dt.Rows.Count > 0 Then
                                Dim table = ws.Cell(1, 1).InsertTable(dt, "Tbl_" & entity.Key, True)
                                table.Theme = XLTableTheme.TableStyleMedium9
                            Else
                                For colIndex As Integer = 0 To dt.Columns.Count - 1
                                    Dim cell = ws.Cell(1, colIndex + 1)
                                    cell.Value = dt.Columns(colIndex).ColumnName
                                    cell.Style.Font.Bold = True
                                    cell.Style.Fill.BackgroundColor = XLColor.FromArgb(46, 117, 182)
                                    cell.Style.Font.FontColor = XLColor.White
                                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                                Next
                            End If

                            ws.Columns().AdjustToContents()
                            cancellationToken.ThrowIfCancellationRequested()

                            progress?.Report(New ExportProgress(90, "جارٍ حفظ الملف...", "حفظ على القرص"))
                            wb.SaveAs(filePath)
                        End Using

                        progress?.Report(New ExportProgress(100, "تم تصدير ملف الإكسيل بنجاح!", "اكتمل التصدير"))
                        Return True
                    Catch ex As OperationCanceledException
                        progress?.Report(New ExportProgress(0, "تم إلغاء عملية التصدير.", "ملغى"))
                        Return False
                    Catch ex As Exception
                        Debug.WriteLine("ExportSingleToExcelAsync error: " & ex.Message)
                        Throw
                    End Try
                End Function, cancellationToken)
        End Function

        ' ─────────────────────────────────────────────────────────────
        ' 5. تصدير قسم محدد إلى ملف PDF
        ' ─────────────────────────────────────────────────────────────
        Public Shared Async Function ExportSingleToPdfAsync(entityKey As String, filePath As String, progress As IProgress(Of ExportProgress), Optional fromDate As Nullable(Of DateTime) = Nothing, Optional toDate As Nullable(Of DateTime) = Nothing, Optional cancellationToken As CancellationToken = Nothing) As Task(Of Boolean)
            Return Await Task.Run(
                Function() As Boolean
                    Dim tempHtmlPath As String = ""
                    Try
                        cancellationToken.ThrowIfCancellationRequested()

                        Dim entity = GetEntityByKey(entityKey)
                        If entity Is Nothing Then Throw New ArgumentException("القسم المحدد غير موجود")

                        progress?.Report(New ExportProgress(20, $"جارٍ استخراج بيانات [{entity.DisplayNameAr}]...", "قراءة البيانات"))
                        Dim dt = GetEntityDataTable(entity, fromDate, toDate)

                        cancellationToken.ThrowIfCancellationRequested()

                        progress?.Report(New ExportProgress(50, "جارٍ توليد التقرير والترويسة بصيغة PDF...", "بناء التقرير"))
                        Dim dateSub = If(fromDate.HasValue AndAlso toDate.HasValue, $" (الفترة من {fromDate.Value:yyyy/MM/dd} إلى {toDate.Value:yyyy/MM/dd})", "")
                        Dim htmlContent = GenerateHtmlReport(entity.DisplayNameAr & dateSub, dt)

                        tempHtmlPath = Path.Combine(Path.GetTempPath(), $"Report_{Guid.NewGuid():N}.html")
                        File.WriteAllText(tempHtmlPath, htmlContent, Encoding.UTF8)

                        cancellationToken.ThrowIfCancellationRequested()

                        progress?.Report(New ExportProgress(75, "جارٍ تحويل التقرير إلى مستند PDF...", "معالجة المستند"))
                        Dim converted = ConvertHtmlToPdfWithEdge(tempHtmlPath, filePath)

                        If Not converted OrElse Not File.Exists(filePath) Then
                            Throw New InvalidOperationException("تعذر إنشاء ملف PDF عبر محرك الطباعة.")
                        End If

                        progress?.Report(New ExportProgress(100, "تم تصدير ملف PDF بنجاح!", "اكتمل التصدير"))
                        Return True
                    Catch ex As OperationCanceledException
                        progress?.Report(New ExportProgress(0, "تم إلغاء عملية التصدير.", "ملغى"))
                        Return False
                    Catch ex As Exception
                        Debug.WriteLine("ExportSingleToPdfAsync error: " & ex.Message)
                        Throw
                    Finally
                        If Not String.IsNullOrEmpty(tempHtmlPath) AndAlso File.Exists(tempHtmlPath) Then
                            Try : File.Delete(tempHtmlPath) : Catch : End Try
                        End If
                    End Try
                End Function, cancellationToken)
        End Function

        ' ─────────────────────────────────────────────────────────────
        ' 6. تصدير جهات الاتصال لحملات الواتساب والتسويق (WhatsApp Export)
        ' ─────────────────────────────────────────────────────────────
        Public Shared Async Function ExportWhatsAppContactsAsync(filePath As String, progress As IProgress(Of ExportProgress), Optional cancellationToken As CancellationToken = Nothing) As Task(Of Boolean)
            Return Await Task.Run(
                Function() As Boolean
                    Try
                        cancellationToken.ThrowIfCancellationRequested()
                        progress?.Report(New ExportProgress(20, "استخراج جهات اتصال العملاء من قاعدة البيانات...", "قراءة أرقام الهواتف"))

                        Dim dtRaw As New DataTable()
                        Using conn As New SqlConnection(DBModule.ConnectionString)
                            conn.Open()
                            Dim sql = "SELECT CustomerCode AS [كود العميل], CustomerName AS [اسم العميل], " &
                                      "ISNULL(Phone1, PhoneNumber) AS [الهاتف], Address AS [العنوان], " &
                                      "ISNULL(CurrentBalance, 0) AS [الرصيد] " &
                                      "FROM Customers WHERE (IsDeleted = 0 OR IsDeleted IS NULL) " &
                                      "AND (Phone1 IS NOT NULL AND LTRIM(RTRIM(Phone1)) <> '' OR PhoneNumber IS NOT NULL AND LTRIM(RTRIM(PhoneNumber)) <> '') " &
                                      "ORDER BY CustomerName"
                            Using cmd As New SqlCommand(sql, conn)
                                Using da As New SqlDataAdapter(cmd)
                                    da.Fill(dtRaw)
                                End Using
                            End Using
                        End Using

                        cancellationToken.ThrowIfCancellationRequested()
                        progress?.Report(New ExportProgress(50, "تهيئة وتنسيق أرقام الواتساب الدولية وروابط المحادثة...", "تنسيق الأرقام"))

                        Dim dtFormatted As New DataTable("WhatsAppContacts")
                        dtFormatted.Columns.Add("كود العميل")
                        dtFormatted.Columns.Add("اسم العميل")
                        dtFormatted.Columns.Add("رقم الهاتف الأصلي")
                        dtFormatted.Columns.Add("رقم الواتساب الدولي (Formatted)")
                        dtFormatted.Columns.Add("رابط المحادثة المباشر (Direct Link)")
                        dtFormatted.Columns.Add("الرصيد الحالي")
                        dtFormatted.Columns.Add("العنوان")

                        For Each r As DataRow In dtRaw.Rows
                            Dim rawPhone = r("الهاتف").ToString().Trim()
                            Dim cleanDigits = Regex.Replace(rawPhone, "[^\d]", "")

                            ' تنسيق رقم الواتساب الدولي
                            Dim waNumber = cleanDigits
                            If cleanDigits.StartsWith("01") AndAlso cleanDigits.Length = 11 Then
                                waNumber = "20" & cleanDigits.Substring(1) ' مصر
                            ElseIf cleanDigits.StartsWith("05") AndAlso cleanDigits.Length = 10 Then
                                waNumber = "966" & cleanDigits.Substring(1) ' السعودية
                            ElseIf cleanDigits.StartsWith("00") Then
                                waNumber = cleanDigits.Substring(2)
                            End If

                            Dim waLink = If(String.IsNullOrEmpty(waNumber), "", $"https://wa.me/{waNumber}")

                            dtFormatted.Rows.Add(
                                r("كود العميل"),
                                r("اسم العميل"),
                                rawPhone,
                                waNumber,
                                waLink,
                                r("الرصيد"),
                                r("العنوان")
                            )
                        Next

                        cancellationToken.ThrowIfCancellationRequested()
                        progress?.Report(New ExportProgress(80, "إنشاء ملف إكسيل الحملات الإعلانية...", "حفظ الملف"))

                        Using wb As New XLWorkbook()
                            Dim ws = wb.Worksheets.Add("عملاء_الواتساب")
                            ws.RightToLeft = True

                            Dim table = ws.Cell(1, 1).InsertTable(dtFormatted, "WhatsAppCustomers", True)
                            table.Theme = XLTableTheme.TableStyleMedium11 ' أخضر واتساب أنيق

                            ws.Columns().AdjustToContents()
                            wb.SaveAs(filePath)
                        End Using

                        progress?.Report(New ExportProgress(100, $"تم تصدير {dtFormatted.Rows.Count} جهة اتصال جاهزة للواتساب بنجاح!", "اكتمل"))
                        Return True
                    Catch ex As OperationCanceledException
                        progress?.Report(New ExportProgress(0, "تم إلغاء عملية التصدير.", "ملغى"))
                        Return False
                    Catch ex As Exception
                        Debug.WriteLine("ExportWhatsAppContactsAsync error: " & ex.Message)
                        Throw
                    End Try
                End Function, cancellationToken)
        End Function

        ' ─────────────────────────────────────────────────────────────
        ' 7. توليد كود HTML منسق بأعلى المعايير العربية للطباعة و PDF
        ' ─────────────────────────────────────────────────────────────
        Private Shared Function GenerateHtmlReport(reportTitle As String, dt As DataTable) As String
            Dim companyName = SettingsManager.GetSettingOrDefault("CompanyName", "نظام سستامك لإدارة المبيعات والمخزون")
            Dim currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm")

            Dim sb As New StringBuilder()
            sb.AppendLine("<!DOCTYPE html>")
            sb.AppendLine("<html lang='ar' dir='rtl'>")
            sb.AppendLine("<head>")
            sb.AppendLine("  <meta charset='utf-8'>")
            sb.AppendLine($"  <title>{reportTitle}</title>")
            sb.AppendLine("  <style>")
            sb.AppendLine("    @page { size: A4 landscape; margin: 10mm; }")
            sb.AppendLine("    body { font-family: 'Segoe UI', Tahoma, Arial, sans-serif; direction: rtl; margin: 0; padding: 15px; background: #fff; color: #1e293b; }")
            sb.AppendLine("    .header { display: flex; justify-content: space-between; align-items: center; border-bottom: 2px solid #2563eb; padding-bottom: 12px; margin-bottom: 15px; }")
            sb.AppendLine("    .header .title-box h1 { margin: 0; font-size: 22px; color: #1e3a8a; }")
            sb.AppendLine("    .header .title-box p { margin: 4px 0 0 0; font-size: 13px; color: #64748b; }")
            sb.AppendLine("    .header .meta-box { text-align: left; font-size: 12px; color: #475569; }")
            sb.AppendLine("    table { width: 100%; border-collapse: collapse; margin-top: 10px; font-size: 11px; }")
            sb.AppendLine("    th { background-color: #1e3a8a; color: #ffffff; padding: 8px 6px; border: 1px solid #cbd5e1; text-align: center; }")
            sb.AppendLine("    td { padding: 6px; border: 1px solid #e2e8f0; text-align: center; }")
            sb.AppendLine("    tr:nth-child(even) { background-color: #f8fafc; }")
            sb.AppendLine("    .footer { margin-top: 20px; font-size: 11px; color: #94a3b8; text-align: center; border-top: 1px solid #e2e8f0; padding-top: 8px; }")
            sb.AppendLine("  </style>")
            sb.AppendLine("</head>")
            sb.AppendLine("<body>")

            sb.AppendLine("  <div class='header'>")
            sb.AppendLine("    <div class='title-box'>")
            sb.AppendLine($"      <h1>{reportTitle}</h1>")
            sb.AppendLine($"      <p>{companyName}</p>")
            sb.AppendLine("    </div>")
            sb.AppendLine("    <div class='meta-box'>")
            sb.AppendLine($"      <div>تاريخ التقرير: <strong>{currentDate}</strong></div>")
            sb.AppendLine($"      <div>إجمالي السجلات: <strong>{dt.Rows.Count}</strong></div>")
            sb.AppendLine("    </div>")
            sb.AppendLine("  </div>")

            sb.AppendLine("  <table>")
            sb.AppendLine("    <thead>")
            sb.AppendLine("      <tr>")
            For Each col As DataColumn In dt.Columns
                sb.AppendLine($"        <th>{col.ColumnName}</th>")
            Next
            sb.AppendLine("      </tr>")
            sb.AppendLine("    </thead>")
            sb.AppendLine("    <tbody>")

            For Each row As DataRow In dt.Rows
                sb.AppendLine("      <tr>")
                For Each col As DataColumn In dt.Columns
                    Dim val = If(row(col) Is DBNull.Value, "", row(col).ToString())
                    sb.AppendLine($"        <td>{System.Net.WebUtility.HtmlEncode(val)}</td>")
                Next
                sb.AppendLine("      </tr>")
            Next

            sb.AppendLine("    </tbody>")
            sb.AppendLine("  </table>")

            sb.AppendLine("  <div class='footer'>")
            sb.AppendLine($"    تم استخراج هذا التقرير آلياً عبر نظام سستامك | تاريخ الطباعة: {currentDate}")
            sb.AppendLine("  </div>")

            sb.AppendLine("</body>")
            sb.AppendLine("</html>")

            Return sb.ToString()
        End Function

        Private Shared Function ConvertHtmlToPdfWithEdge(htmlFilePath As String, pdfOutputPath As String) As Boolean
            Try
                Dim edgePaths As String() = {
                    "C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                    "C:\Program Files\Microsoft\Edge\Application\msedge.exe",
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\Edge\Application\msedge.exe")
                }

                Dim edgeExe As String = ""
                For Each p In edgePaths
                    If File.Exists(p) Then
                        edgeExe = p
                        Exit For
                    End If
                Next

                If String.IsNullOrEmpty(edgeExe) Then Return False

                If File.Exists(pdfOutputPath) Then File.Delete(pdfOutputPath)

                Dim psi As New ProcessStartInfo With {
                    .FileName = edgeExe,
                    .Arguments = $"--headless=new --disable-gpu --no-pdf-header-footer --print-to-pdf=""{pdfOutputPath}"" ""{htmlFilePath}""",
                    .CreateNoWindow = True,
                    .UseShellExecute = False,
                    .WindowStyle = ProcessWindowStyle.Hidden
                }

                Using proc = Process.Start(psi)
                    If proc IsNot Nothing Then
                        proc.WaitForExit(30000)
                        Return File.Exists(pdfOutputPath)
                    End If
                End Using
            Catch ex As Exception
                Debug.WriteLine("ConvertHtmlToPdfWithEdge error: " & ex.Message)
            End Try
            Return False
        End Function

        ' ─────────────────────────────────────────────────────────────
        ' 8. دوال الاستيراد من ملف Excel (مع النماذج والمعاينة والأخطاء)
        ' ─────────────────────────────────────────────────────────────

        Public Shared Sub GenerateBlankTemplate(entityKey As String, filePath As String)
            Using wb As New XLWorkbook()
                Dim ws = wb.Worksheets.Add("البيانات")
                ws.RightToLeft = True

                Select Case entityKey.ToLower()
                    Case "customers"
                        ws.Cell(1, 1).Value = "كود العميل"
                        ws.Cell(1, 2).Value = "اسم العميل"
                        ws.Cell(1, 3).Value = "رقم الهاتف"
                        ws.Cell(1, 4).Value = "العنوان"
                        ws.Cell(1, 5).Value = "حد الائتمان"
                        ws.Cell(1, 6).Value = "الرصيد الافتتاحي"
                        ws.Cell(1, 7).Value = "ملاحظات"

                        ws.Cell(2, 1).Value = "C-1001"
                        ws.Cell(2, 2).Value = "عميل تجريبي"
                        ws.Cell(2, 3).Value = "01012345678"
                        ws.Cell(2, 4).Value = "القاهرة"
                        ws.Cell(2, 5).Value = 5000
                        ws.Cell(2, 6).Value = 0
                        ws.Cell(2, 7).Value = "عميل نقدي"

                    Case "suppliers"
                        ws.Cell(1, 1).Value = "كود المورد"
                        ws.Cell(1, 2).Value = "اسم المورد"
                        ws.Cell(1, 3).Value = "رقم الهاتف"
                        ws.Cell(1, 4).Value = "العنوان"
                        ws.Cell(1, 5).Value = "الرصيد الافتتاحي"
                        ws.Cell(1, 6).Value = "ملاحظات"

                        ws.Cell(2, 1).Value = "S-1001"
                        ws.Cell(2, 2).Value = "شركة التوريدات الحديثة"
                        ws.Cell(2, 3).Value = "01123456789"
                        ws.Cell(2, 4).Value = "الجيزة"
                        ws.Cell(2, 5).Value = 0
                        ws.Cell(2, 6).Value = "مورد رئيسي"

                    Case "products"
                        ws.Cell(1, 1).Value = "كود الصنف"
                        ws.Cell(1, 2).Value = "اسم الصنف"
                        ws.Cell(1, 3).Value = "القسم"
                        ws.Cell(1, 4).Value = "سعر الشراء"
                        ws.Cell(1, 5).Value = "سعر البيع"
                        ws.Cell(1, 6).Value = "الكمية"
                        ws.Cell(1, 7).Value = "حد الطلب"
                        ws.Cell(1, 8).Value = "الباركود"

                        ws.Cell(2, 1).Value = "PRD-101"
                        ws.Cell(2, 2).Value = "منتج تجريبي"
                        ws.Cell(2, 3).Value = "عام"
                        ws.Cell(2, 4).Value = 25.5
                        ws.Cell(2, 5).Value = 35.0
                        ws.Cell(2, 6).Value = 100
                        ws.Cell(2, 7).Value = 10
                        ws.Cell(2, 8).Value = "6221234567890"

                    Case "categories"
                        ws.Cell(1, 1).Value = "كود القسم"
                        ws.Cell(1, 2).Value = "اسم القسم"
                        ws.Cell(1, 3).Value = "الوصف"

                        ws.Cell(2, 1).Value = "CAT-01"
                        ws.Cell(2, 2).Value = "المشروبات"
                        ws.Cell(2, 3).Value = "قسم المشروبات الباردة والساخنة"

                    Case "stockadjustment"
                        ws.Cell(1, 1).Value = "كود الصنف"
                        ws.Cell(1, 2).Value = "الباركود"
                        ws.Cell(1, 3).Value = "اسم الصنف"
                        ws.Cell(1, 4).Value = "الكمية الفعلية المجرودة"
                        ws.Cell(1, 5).Value = "سعر التكلفة"

                        ws.Cell(2, 1).Value = "PRD-101"
                        ws.Cell(2, 2).Value = "6221234567890"
                        ws.Cell(2, 3).Value = "منتج تجريبي"
                        ws.Cell(2, 4).Value = 150
                        ws.Cell(2, 5).Value = 25.0

                    Case Else
                        Throw New NotSupportedException("النموذج غير متوفر لهذا القسم")
                End Select

                Dim headerRange = ws.Range(1, 1, 1, ws.LastColumnUsed().ColumnNumber())
                headerRange.Style.Font.Bold = True
                headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(30, 64, 175)
                headerRange.Style.Font.FontColor = XLColor.White
                headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                ws.Columns().AdjustToContents()
                wb.SaveAs(filePath)
            End Using
        End Sub

        Public Shared Function ReadExcelPreview(filePath As String, Optional maxRows As Integer = 50) As DataTable
            Dim dt As New DataTable()

            Using wb As New XLWorkbook(filePath)
                Dim ws = wb.Worksheets.First()
                Dim firstRow = True

                For Each row In ws.RowsUsed()
                    If firstRow Then
                        For Each cell In row.CellsUsed()
                            Dim colName = cell.GetString().Trim()
                            If String.IsNullOrEmpty(colName) Then
                                colName = "عمود_" & cell.Address.ColumnNumber
                            End If
                            If dt.Columns.Contains(colName) Then
                                colName &= "_" & cell.Address.ColumnNumber
                            End If
                            dt.Columns.Add(colName)
                        Next
                        firstRow = False
                    Else
                        Dim dr = dt.NewRow()
                        Dim colIndex As Integer = 0
                        For Each cell In row.Cells()
                            If colIndex < dt.Columns.Count Then
                                dr(colIndex) = If(cell.IsEmpty(), "", cell.GetFormattedString().Trim())
                            End If
                            colIndex += 1
                        Next

                        Dim hasData As Boolean = False
                        For c As Integer = 0 To dt.Columns.Count - 1
                            If Not String.IsNullOrEmpty(dr(c).ToString()) Then
                                hasData = True
                                Exit For
                            End If
                        Next

                        If hasData Then
                            dt.Rows.Add(dr)
                            If dt.Rows.Count >= maxRows Then Exit For
                        End If
                    End If
                Next
            End Using

            Return dt
        End Function

        Public Shared Async Function ImportFromExcelAsync(entityKey As String, filePath As String, updateExisting As Boolean, progress As IProgress(Of ExportProgress), Optional cancellationToken As CancellationToken = Nothing) As Task(Of ImportResult)
            Return Await Task.Run(
                Function() As ImportResult
                    Dim result As New ImportResult()
                    Dim dtErrors As New DataTable("RejectedRows")

                    Try
                        cancellationToken.ThrowIfCancellationRequested()
                        progress?.Report(New ExportProgress(10, "قراءة محتويات ملف الإكسيل بالكامل...", "بدء القراءة"))

                        Dim dt = ReadExcelFull(filePath)
                        result.TotalRows = dt.Rows.Count

                        If result.TotalRows = 0 Then
                            result.ErrorMessages.Add("الملف المختار لا يحتوي على أي صفوف بيانات صالحة.")
                            Return result
                        End If

                        ' تهيئة جدول الأخطاء المرفوضة
                        For Each col As DataColumn In dt.Columns
                            dtErrors.Columns.Add(col.ColumnName, GetType(String))
                        Next
                        dtErrors.Columns.Add("سبب الرفض / الخطأ", GetType(String))

                        Using conn As New SqlConnection(DBModule.ConnectionString)
                            conn.Open()

                            Select Case entityKey.ToLower()
                                Case "customers"
                                    ImportCustomersInternal(conn, dt, updateExisting, progress, result, dtErrors, cancellationToken)
                                Case "suppliers"
                                    ImportSuppliersInternal(conn, dt, updateExisting, progress, result, dtErrors, cancellationToken)
                                Case "products"
                                    ImportProductsInternal(conn, dt, updateExisting, progress, result, dtErrors, cancellationToken)
                                Case "categories"
                                    ImportCategoriesInternal(conn, dt, updateExisting, progress, result, dtErrors, cancellationToken)
                                Case "stockadjustment"
                                    ImportStockAdjustmentInternal(conn, dt, progress, result, dtErrors, cancellationToken)
                                Case Else
                                    Throw New NotSupportedException("القسم المحدد لا يدعم الاستيراد المباشر.")
                            End Select
                        End Using

                        ' إذا كان هناك صفوف مرفوضة أو أخطاء، نقوم بإنشاء ملف الإكسيل الخاص بالأخطاء
                        If dtErrors.Rows.Count > 0 Then
                            Try
                                Dim errorFolder = Path.GetDirectoryName(filePath)
                                Dim errorFileName = $"{entityKey}_الأخطاء_المرفوضة_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                                Dim errorFullPath = Path.Combine(errorFolder, errorFileName)

                                Using errWb As New XLWorkbook()
                                    Dim errWs = errWb.Worksheets.Add("الصفوف_المرفوضة")
                                    errWs.RightToLeft = True

                                    Dim errTable = errWs.Cell(1, 1).InsertTable(dtErrors, "ErrorsTable", True)
                                    errTable.Theme = XLTableTheme.TableStyleMedium3 ' أحمر للأخطاء

                                    errWs.Columns().AdjustToContents()
                                    errWb.SaveAs(errorFullPath)
                                End Using

                                result.ErrorFilePath = errorFullPath
                            Catch errEx As Exception
                                Debug.WriteLine("Failed to generate error excel file: " & errEx.Message)
                            End Try
                        End If

                        progress?.Report(New ExportProgress(100, "اكتملت عملية الاستيراد!", "انتهى"))
                    Catch ex As OperationCanceledException
                        progress?.Report(New ExportProgress(0, "تم إلغاء عملية الاستيراد بناءً على طلبك.", "ملغى"))
                    Catch ex As Exception
                        result.ErrorMessages.Add("خطأ عام أثناء الاستيراد: " & ex.Message)
                    End Try

                    Return result
                End Function, cancellationToken)
        End Function

        Private Shared Function ReadExcelFull(filePath As String) As DataTable
            Dim dt As New DataTable()

            Using wb As New XLWorkbook(filePath)
                Dim ws = wb.Worksheets.First()
                Dim firstRow = True

                For Each row In ws.RowsUsed()
                    If firstRow Then
                        For Each cell In row.CellsUsed()
                            Dim colName = cell.GetString().Trim()
                            If String.IsNullOrEmpty(colName) Then
                                colName = "عمود_" & cell.Address.ColumnNumber
                            End If
                            If dt.Columns.Contains(colName) Then
                                colName &= "_" & cell.Address.ColumnNumber
                            End If
                            dt.Columns.Add(colName)
                        Next
                        firstRow = False
                    Else
                        Dim dr = dt.NewRow()
                        Dim colIndex As Integer = 0
                        For Each cell In row.Cells()
                            If colIndex < dt.Columns.Count Then
                                dr(colIndex) = If(cell.IsEmpty(), "", cell.GetFormattedString().Trim())
                            End If
                            colIndex += 1
                        Next

                        Dim hasData As Boolean = False
                        For c As Integer = 0 To dt.Columns.Count - 1
                            If Not String.IsNullOrEmpty(dr(c).ToString()) Then
                                hasData = True
                                Exit For
                            End If
                        Next

                        If hasData Then
                            dt.Rows.Add(dr)
                        End If
                    End If
                Next
            End Using

            Return dt
        End Function

        ' ─────────────────────────────────────────────────────────────
        ' استيراد العملاء
        ' ─────────────────────────────────────────────────────────────
        Private Shared Sub ImportCustomersInternal(conn As SqlConnection, dt As DataTable, updateExisting As Boolean, progress As IProgress(Of ExportProgress), result As ImportResult, dtErrors As DataTable, ct As CancellationToken)
            Dim total = dt.Rows.Count

            For i As Integer = 0 To total - 1
                ct.ThrowIfCancellationRequested()
                Dim row = dt.Rows(i)
                Dim pct = 10 + CInt(((i + 1) / CDbl(total)) * 85)

                Try
                    Dim code = GetRowValue(row, "كود العميل", "CustomerCode", "Code")
                    Dim name = GetRowValue(row, "اسم العميل", "CustomerName", "Name")
                    Dim phone = GetRowValue(row, "رقم الهاتف", "الهاتف", "Phone", "PhoneNumber")
                    Dim address = GetRowValue(row, "العنوان", "Address")
                    Dim creditLimit = ParseDecimal(GetRowValue(row, "حد الائتمان", "CreditLimit"), 0)
                    Dim balance = ParseDecimal(GetRowValue(row, "الرصيد الافتتاحي", "الرصيد", "Balance", "CurrentBalance"), 0)
                    Dim notes = GetRowValue(row, "ملاحظات", "Notes")

                    If String.IsNullOrWhiteSpace(name) Then
                        result.SkippedCount += 1
                        AddRowToErrors(dtErrors, row, "اسم العميل فارغ")
                        Continue For
                    End If

                    If String.IsNullOrWhiteSpace(code) Then
                        code = "CUST-" & (i + 1).ToString("D4")
                    End If

                    Dim existingId As Integer = 0
                    Using chkCmd As New SqlCommand("SELECT TOP 1 CustomerID FROM Customers WHERE CustomerCode = @Code OR (Phone1 = @Phone AND @Phone <> '');", conn)
                        chkCmd.Parameters.AddWithValue("@Code", code)
                        chkCmd.Parameters.AddWithValue("@Phone", phone)
                        Dim res = chkCmd.ExecuteScalar()
                        If res IsNot Nothing AndAlso Not Convert.IsDBNull(res) Then
                            existingId = Convert.ToInt32(res)
                        End If
                    End Using

                    If existingId > 0 Then
                        If updateExisting Then
                            Using updCmd As New SqlCommand(
                                "UPDATE Customers SET CustomerName = @Name, Phone1 = @Phone, PhoneNumber = @Phone, " &
                                "Address = @Address, CreditLimit = @CreditLimit, Notes = @Notes WHERE CustomerID = @ID;", conn)
                                updCmd.Parameters.AddWithValue("@Name", name)
                                updCmd.Parameters.AddWithValue("@Phone", phone)
                                updCmd.Parameters.AddWithValue("@Address", address)
                                updCmd.Parameters.AddWithValue("@CreditLimit", creditLimit)
                                updCmd.Parameters.AddWithValue("@Notes", notes)
                                updCmd.Parameters.AddWithValue("@ID", existingId)
                                updCmd.ExecuteNonQuery()
                                result.UpdatedCount += 1
                            End Using
                        Else
                            result.SkippedCount += 1
                        End If
                    Else
                        Using insCmd As New SqlCommand(
                            "INSERT INTO Customers (CustomerCode, CustomerName, Phone1, PhoneNumber, Address, CreditLimit, CurrentBalance, Balance, Notes, IsActive, IsDeleted, CreatedAt) " &
                            "VALUES (@Code, @Name, @Phone, @Phone, @Address, @CreditLimit, @Balance, @Balance, @Notes, 1, 0, GETDATE());", conn)
                            insCmd.Parameters.AddWithValue("@Code", code)
                            insCmd.Parameters.AddWithValue("@Name", name)
                            insCmd.Parameters.AddWithValue("@Phone", phone)
                            insCmd.Parameters.AddWithValue("@Address", address)
                            insCmd.Parameters.AddWithValue("@CreditLimit", creditLimit)
                            insCmd.Parameters.AddWithValue("@Balance", balance)
                            insCmd.Parameters.AddWithValue("@Notes", notes)
                            insCmd.ExecuteNonQuery()
                            result.SuccessCount += 1
                        End Using
                    End If

                    progress?.Report(New ExportProgress(pct, $"جارٍ استيراد العميل [{name}] ({i + 1}/{total})...", name))
                Catch ex As Exception
                    result.ErrorCount += 1
                    result.ErrorMessages.Add($"صف {i + 2}: {ex.Message}")
                    AddRowToErrors(dtErrors, row, ex.Message)
                End Try
            Next
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' استيراد الموردين
        ' ─────────────────────────────────────────────────────────────
        Private Shared Sub ImportSuppliersInternal(conn As SqlConnection, dt As DataTable, updateExisting As Boolean, progress As IProgress(Of ExportProgress), result As ImportResult, dtErrors As DataTable, ct As CancellationToken)
            Dim total = dt.Rows.Count

            For i As Integer = 0 To total - 1
                ct.ThrowIfCancellationRequested()
                Dim row = dt.Rows(i)
                Dim pct = 10 + CInt(((i + 1) / CDbl(total)) * 85)

                Try
                    Dim code = GetRowValue(row, "كود المورد", "SupplierCode", "Code")
                    Dim name = GetRowValue(row, "اسم المورد", "SupplierName", "SuppliersName", "Name")
                    Dim phone = GetRowValue(row, "رقم الهاتف", "الهاتف", "Phone")
                    Dim address = GetRowValue(row, "العنوان", "Address")
                    Dim balance = ParseDecimal(GetRowValue(row, "الرصيد الافتتاحي", "الرصيد", "Balance", "CurrentBalance"), 0)
                    Dim notes = GetRowValue(row, "ملاحظات", "Notes")

                    If String.IsNullOrWhiteSpace(name) Then
                        result.SkippedCount += 1
                        AddRowToErrors(dtErrors, row, "اسم المورد فارغ")
                        Continue For
                    End If

                    If String.IsNullOrWhiteSpace(code) Then
                        code = "SUP-" & (i + 1).ToString("D4")
                    End If

                    Dim existingId As Integer = 0
                    Using chkCmd As New SqlCommand("SELECT TOP 1 SupplierID FROM Suppliers WHERE SupplierCode = @Code OR (Phone = @Phone AND @Phone <> '');", conn)
                        chkCmd.Parameters.AddWithValue("@Code", code)
                        chkCmd.Parameters.AddWithValue("@Phone", phone)
                        Dim res = chkCmd.ExecuteScalar()
                        If res IsNot Nothing AndAlso Not Convert.IsDBNull(res) Then
                            existingId = Convert.ToInt32(res)
                        End If
                    End Using

                    If existingId > 0 Then
                        If updateExisting Then
                            Using updCmd As New SqlCommand(
                                "UPDATE Suppliers SET SupplierName = @Name, SuppliersName = @Name, Phone = @Phone, " &
                                "Address = @Address, Notes = @Notes WHERE SupplierID = @ID;", conn)
                                updCmd.Parameters.AddWithValue("@Name", name)
                                updCmd.Parameters.AddWithValue("@Phone", phone)
                                updCmd.Parameters.AddWithValue("@Address", address)
                                updCmd.Parameters.AddWithValue("@Notes", notes)
                                updCmd.Parameters.AddWithValue("@ID", existingId)
                                updCmd.ExecuteNonQuery()
                                result.UpdatedCount += 1
                            End Using
                        Else
                            result.SkippedCount += 1
                        End If
                    Else
                        Using insCmd As New SqlCommand(
                            "INSERT INTO Suppliers (SupplierCode, SupplierName, SuppliersName, Phone, Address, CurrentBalance, Balance, Notes, IsActive, IsDeleted, CreatedAt) " &
                            "VALUES (@Code, @Name, @Name, @Phone, @Address, @Balance, @Balance, @Notes, 1, 0, GETDATE());", conn)
                            insCmd.Parameters.AddWithValue("@Code", code)
                            insCmd.Parameters.AddWithValue("@Name", name)
                            insCmd.Parameters.AddWithValue("@Phone", phone)
                            insCmd.Parameters.AddWithValue("@Address", address)
                            insCmd.Parameters.AddWithValue("@Balance", balance)
                            insCmd.Parameters.AddWithValue("@Notes", notes)
                            insCmd.ExecuteNonQuery()
                            result.SuccessCount += 1
                        End Using
                    End If

                    progress?.Report(New ExportProgress(pct, $"جارٍ استيراد المورد [{name}] ({i + 1}/{total})...", name))
                Catch ex As Exception
                    result.ErrorCount += 1
                    result.ErrorMessages.Add($"صف {i + 2}: {ex.Message}")
                    AddRowToErrors(dtErrors, row, ex.Message)
                End Try
            Next
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' استيراد الأصناف والمنتجات
        ' ─────────────────────────────────────────────────────────────
        Private Shared Sub ImportProductsInternal(conn As SqlConnection, dt As DataTable, updateExisting As Boolean, progress As IProgress(Of ExportProgress), result As ImportResult, dtErrors As DataTable, ct As CancellationToken)
            Dim total = dt.Rows.Count

            For i As Integer = 0 To total - 1
                ct.ThrowIfCancellationRequested()
                Dim row = dt.Rows(i)
                Dim pct = 10 + CInt(((i + 1) / CDbl(total)) * 85)

                Try
                    Dim code = GetRowValue(row, "كود الصنف", "ProductCode", "Code")
                    Dim name = GetRowValue(row, "اسم الصنف", "ProductName", "Name")
                    Dim categoryName = GetRowValue(row, "القسم", "Category", "CategoryName")
                    Dim buyPrice = ParseDecimal(GetRowValue(row, "سعر الشراء", "PurchasePrice", "BuyPrice"), 0)
                    Dim salePrice = ParseDecimal(GetRowValue(row, "سعر البيع", "SalePrice", "Price"), 0)
                    Dim qty = ParseDecimal(GetRowValue(row, "الكمية", "Quantity", "Qty"), 0)
                    Dim minAlert = ParseDecimal(GetRowValue(row, "حد الطلب", "MinAlertQuantity"), 5)
                    Dim barcode = GetRowValue(row, "الباركود", "Barcode")

                    If String.IsNullOrWhiteSpace(name) Then
                        result.SkippedCount += 1
                        AddRowToErrors(dtErrors, row, "اسم الصنف فارغ")
                        Continue For
                    End If

                    If String.IsNullOrWhiteSpace(code) Then
                        code = "PRD-" & (i + 1).ToString("D4")
                    End If

                    Dim categoryId As Integer = 1
                    If Not String.IsNullOrWhiteSpace(categoryName) Then
                        Using catCmd As New SqlCommand("SELECT TOP 1 Category_ID FROM Categories WHERE Category_NameAr = @Cat OR CategoryName = @Cat;", conn)
                            catCmd.Parameters.AddWithValue("@Cat", categoryName)
                            Dim catRes = catCmd.ExecuteScalar()
                            If catRes IsNot Nothing AndAlso Not Convert.IsDBNull(catRes) Then
                                categoryId = Convert.ToInt32(catRes)
                            Else
                                Using insCat As New SqlCommand("INSERT INTO Categories (Category_NameAr, CategoryName, IsActive, IsDeleted, CreatedAt) VALUES (@Cat, @Cat, 1, 0, GETDATE()); SELECT SCOPE_IDENTITY();", conn)
                                    insCat.Parameters.AddWithValue("@Cat", categoryName)
                                    categoryId = Convert.ToInt32(insCat.ExecuteScalar())
                                End Using
                            End If
                        End Using
                    End If

                    Dim existingId As Integer = 0
                    Using chkCmd As New SqlCommand("SELECT TOP 1 ProductID FROM Products WHERE ProductCode = @Code OR (Barcode = @Bar AND @Bar <> '');", conn)
                        chkCmd.Parameters.AddWithValue("@Code", code)
                        chkCmd.Parameters.AddWithValue("@Bar", barcode)
                        Dim res = chkCmd.ExecuteScalar()
                        If res IsNot Nothing AndAlso Not Convert.IsDBNull(res) Then
                            existingId = Convert.ToInt32(res)
                        End If
                    End Using

                    If existingId > 0 Then
                        If updateExisting Then
                            Using updCmd As New SqlCommand(
                                "UPDATE Products SET ProductName = @Name, CategoryID = @CatID, PurchasePrice = @Buy, " &
                                "SalePrice = @Sale, Quantity = @Qty, MinAlertQuantity = @MinAlert, Barcode = @Bar WHERE ProductID = @ID;", conn)
                                updCmd.Parameters.AddWithValue("@Name", name)
                                updCmd.Parameters.AddWithValue("@CatID", categoryId)
                                updCmd.Parameters.AddWithValue("@Buy", buyPrice)
                                updCmd.Parameters.AddWithValue("@Sale", salePrice)
                                updCmd.Parameters.AddWithValue("@Qty", qty)
                                updCmd.Parameters.AddWithValue("@MinAlert", minAlert)
                                updCmd.Parameters.AddWithValue("@Bar", barcode)
                                updCmd.Parameters.AddWithValue("@ID", existingId)
                                updCmd.ExecuteNonQuery()
                                result.UpdatedCount += 1
                            End Using
                        Else
                            result.SkippedCount += 1
                        End If
                    Else
                        Using insCmd As New SqlCommand(
                            "INSERT INTO Products (ProductCode, ProductName, CategoryID, PurchasePrice, SalePrice, Quantity, MinAlertQuantity, Barcode, IsActive, IsDeleted, CreatedAt) " &
                            "VALUES (@Code, @Name, @CatID, @Buy, @Sale, @Qty, @MinAlert, @Bar, 1, 0, GETDATE());", conn)
                            insCmd.Parameters.AddWithValue("@Code", code)
                            insCmd.Parameters.AddWithValue("@Name", name)
                            insCmd.Parameters.AddWithValue("@CatID", categoryId)
                            insCmd.Parameters.AddWithValue("@Buy", buyPrice)
                            insCmd.Parameters.AddWithValue("@Sale", salePrice)
                            insCmd.Parameters.AddWithValue("@Qty", qty)
                            insCmd.Parameters.AddWithValue("@MinAlert", minAlert)
                            insCmd.Parameters.AddWithValue("@Bar", barcode)
                            insCmd.ExecuteNonQuery()
                            result.SuccessCount += 1
                        End Using
                    End If

                    progress?.Report(New ExportProgress(pct, $"جارٍ استيراد الصنف [{name}] ({i + 1}/{total})...", name))
                Catch ex As Exception
                    result.ErrorCount += 1
                    result.ErrorMessages.Add($"صف {i + 2}: {ex.Message}")
                    AddRowToErrors(dtErrors, row, ex.Message)
                End Try
            Next
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' استيراد الأقسام والتصنيفات
        ' ─────────────────────────────────────────────────────────────
        Private Shared Sub ImportCategoriesInternal(conn As SqlConnection, dt As DataTable, updateExisting As Boolean, progress As IProgress(Of ExportProgress), result As ImportResult, dtErrors As DataTable, ct As CancellationToken)
            Dim total = dt.Rows.Count

            For i As Integer = 0 To total - 1
                ct.ThrowIfCancellationRequested()
                Dim row = dt.Rows(i)
                Dim pct = 10 + CInt(((i + 1) / CDbl(total)) * 85)

                Try
                    Dim code = GetRowValue(row, "كود القسم", "CategoryCode", "Code")
                    Dim name = GetRowValue(row, "اسم القسم", "CategoryName", "Category_NameAr", "Name")
                    Dim desc = GetRowValue(row, "الوصف", "Description")

                    If String.IsNullOrWhiteSpace(name) Then
                        result.SkippedCount += 1
                        AddRowToErrors(dtErrors, row, "اسم القسم فارغ")
                        Continue For
                    End If

                    If String.IsNullOrWhiteSpace(code) Then
                        code = "CAT-" & (i + 1).ToString("D3")
                    End If

                    Dim existingId As Integer = 0
                    Using chkCmd As New SqlCommand("SELECT TOP 1 Category_ID FROM Categories WHERE CategoryCode = @Code OR Category_NameAr = @Name OR CategoryName = @Name;", conn)
                        chkCmd.Parameters.AddWithValue("@Code", code)
                        chkCmd.Parameters.AddWithValue("@Name", name)
                        Dim res = chkCmd.ExecuteScalar()
                        If res IsNot Nothing AndAlso Not Convert.IsDBNull(res) Then
                            existingId = Convert.ToInt32(res)
                        End If
                    End Using

                    If existingId > 0 Then
                        If updateExisting Then
                            Using updCmd As New SqlCommand("UPDATE Categories SET Category_NameAr = @Name, CategoryName = @Name, Description = @Desc WHERE Category_ID = @ID;", conn)
                                updCmd.Parameters.AddWithValue("@Name", name)
                                updCmd.Parameters.AddWithValue("@Desc", desc)
                                updCmd.Parameters.AddWithValue("@ID", existingId)
                                updCmd.ExecuteNonQuery()
                                result.UpdatedCount += 1
                            End Using
                        Else
                            result.SkippedCount += 1
                        End If
                    Else
                        Using insCmd As New SqlCommand("INSERT INTO Categories (CategoryCode, Category_NameAr, CategoryName, Description, IsActive, IsDeleted, CreatedAt) VALUES (@Code, @Name, @Name, @Desc, 1, 0, GETDATE());", conn)
                            insCmd.Parameters.AddWithValue("@Code", code)
                            insCmd.Parameters.AddWithValue("@Name", name)
                            insCmd.Parameters.AddWithValue("@Desc", desc)
                            insCmd.ExecuteNonQuery()
                            result.SuccessCount += 1
                        End Using
                    End If

                    progress?.Report(New ExportProgress(pct, $"جارٍ استيراد القسم [{name}] ({i + 1}/{total})...", name))
                Catch ex As Exception
                    result.ErrorCount += 1
                    result.ErrorMessages.Add($"صف {i + 2}: {ex.Message}")
                    AddRowToErrors(dtErrors, row, ex.Message)
                End Try
            Next
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' استيراد المخزون الافتتاحي وجرد المخازن
        ' ─────────────────────────────────────────────────────────────
        Private Shared Sub ImportStockAdjustmentInternal(conn As SqlConnection, dt As DataTable, progress As IProgress(Of ExportProgress), result As ImportResult, dtErrors As DataTable, ct As CancellationToken)
            Dim total = dt.Rows.Count

            For i As Integer = 0 To total - 1
                ct.ThrowIfCancellationRequested()
                Dim row = dt.Rows(i)
                Dim pct = 10 + CInt(((i + 1) / CDbl(total)) * 85)

                Try
                    Dim code = GetRowValue(row, "كود الصنف", "ProductCode", "Code")
                    Dim barcode = GetRowValue(row, "الباركود", "Barcode")
                    Dim name = GetRowValue(row, "اسم الصنف", "ProductName", "Name")
                    Dim qty = ParseDecimal(GetRowValue(row, "الكمية الفعلية المجرودة", "الكمية", "Quantity", "ActualQty"), -999999)
                    Dim cost = ParseDecimal(GetRowValue(row, "سعر التكلفة", "PurchasePrice", "Cost"), -1)

                    If qty = -999999 Then
                        result.SkippedCount += 1
                        AddRowToErrors(dtErrors, row, "الكمية المجرودة غير صحيحة أو فارغة")
                        Continue For
                    End If

                    ' البحث عن الصنف بالكود أو الباركود أو الاسم
                    Dim productId As Integer = 0
                    Using chkCmd As New SqlCommand(
                        "SELECT TOP 1 ProductID FROM Products WHERE " &
                        "(@Code <> '' AND ProductCode = @Code) OR " &
                        "(@Bar <> '' AND Barcode = @Bar) OR " &
                        "(@Name <> '' AND ProductName = @Name);", conn)
                        chkCmd.Parameters.AddWithValue("@Code", code)
                        chkCmd.Parameters.AddWithValue("@Bar", barcode)
                        chkCmd.Parameters.AddWithValue("@Name", name)
                        Dim res = chkCmd.ExecuteScalar()
                        If res IsNot Nothing AndAlso Not Convert.IsDBNull(res) Then
                            productId = Convert.ToInt32(res)
                        End If
                    End Using

                    If productId > 0 Then
                        Dim updateSql = "UPDATE Products SET Quantity = @Qty"
                        If cost >= 0 Then updateSql &= ", PurchasePrice = @Cost"
                        updateSql &= " WHERE ProductID = @ID;"

                        Using updCmd As New SqlCommand(updateSql, conn)
                            updCmd.Parameters.AddWithValue("@Qty", qty)
                            If cost >= 0 Then updCmd.Parameters.AddWithValue("@Cost", cost)
                            updCmd.Parameters.AddWithValue("@ID", productId)
                            updCmd.ExecuteNonQuery()
                        End Using

                        ' فحص وتحديث جدول StoreStock إن وجد
                        Try
                            Dim storeStockSql = "
                            IF OBJECT_ID('StoreStock', 'U') IS NOT NULL
                            BEGIN
                                IF EXISTS (SELECT 1 FROM StoreStock WHERE ProductID = @PID)
                                    UPDATE StoreStock SET Quantity = @Qty, LastUpdated = GETDATE() WHERE ProductID = @PID;
                                ELSE
                                    INSERT INTO StoreStock (StoreID, ProductID, Quantity, LastUpdated) VALUES (1, @PID, @Qty, GETDATE());
                            END"
                            Using stCmd As New SqlCommand(storeStockSql, conn)
                                stCmd.Parameters.AddWithValue("@PID", productId)
                                stCmd.Parameters.AddWithValue("@Qty", qty)
                                stCmd.ExecuteNonQuery()
                            End Using
                        Catch
                        End Try

                        result.UpdatedCount += 1
                        progress?.Report(New ExportProgress(pct, $"تم تعديل كمية الصنف ({code} - {name}) إلى {qty:N0}...", name))
                    Else
                        result.ErrorCount += 1
                        Dim errText = $"لم يتم العثور على الصنف في النظام (الكود: {code} / الباركود: {barcode})"
                        result.ErrorMessages.Add($"صف {i + 2}: {errText}")
                        AddRowToErrors(dtErrors, row, errText)
                    End If

                Catch ex As Exception
                    result.ErrorCount += 1
                    result.ErrorMessages.Add($"صف {i + 2}: {ex.Message}")
                    AddRowToErrors(dtErrors, row, ex.Message)
                End Try
            Next
        End Sub

        Private Shared Sub AddRowToErrors(dtErrors As DataTable, sourceRow As DataRow, errorReason As String)
            Try
                Dim dr = dtErrors.NewRow()
                For Each col As DataColumn In sourceRow.Table.Columns
                    If dtErrors.Columns.Contains(col.ColumnName) Then
                        dr(col.ColumnName) = sourceRow(col)
                    End If
                Next
                dr("سبب الرفض / الخطأ") = errorReason
                dtErrors.Rows.Add(dr)
            Catch
            End Try
        End Sub

        ' ── دوال مساعدة لاستخراج الحقول بأمان ─────────────────────────
        Private Shared Function GetRowValue(row As DataRow, ParamArray possibleColumnNames As String()) As String
            For Each colName In possibleColumnNames
                For Each col As DataColumn In row.Table.Columns
                    If String.Equals(col.ColumnName.Trim(), colName.Trim(), StringComparison.OrdinalIgnoreCase) Then
                        If row(col) IsNot DBNull.Value Then
                            Return row(col).ToString().Trim()
                        End If
                    End If
                Next
            Next
            Return ""
        End Function

        Private Shared Function ParseDecimal(val As String, defaultVal As Decimal) As Decimal
            Dim result As Decimal
            If Decimal.TryParse(val, result) Then
                Return result
            End If
            Return defaultVal
        End Function

    End Class

End Namespace
