Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports ClosedXML.Excel

Public Class FrmShiftReports

    Private _rawTable As DataTable = Nothing
    Private _isLoading As Boolean = False
    Private _currentPrintRowIndex As Integer = 0
    Private _currentPrintPageNumber As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmShiftReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _isLoading = True

            ' تفعيل سحب النافذة من الهيدر
            Dim drag As New FormDragHelper(Me, panelHeader)

            ' إعداد الـ DataGridView
            datagridviewsetup(dgvReport)
            ThemeHelper.ApplyDataGridViewTheme(dgvReport, ThemeManager.Instance.CurrentPalette)
            ThemeManager.Instance.ApplyTheme(Me)

            ' ضبط الفترة الزمنية الافتراضية (من بداية الشهر الحالي حتى الآن)
            dtpFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            dtpTo.Value = DateTime.Now

            ' تعبئة قائمة نوع التقرير
            cmbReportMode.Items.Clear()
            cmbReportMode.Items.Add("ملخص الورديات الشامل")
            cmbReportMode.Items.Add("مبيعات الأصناف فقط")
            cmbReportMode.Items.Add("تقرير العملاء فقط")
            cmbReportMode.Items.Add("فواتير المبيعات فقط")
            cmbReportMode.Items.Add("تقرير المصروفات فقط")
            cmbReportMode.SelectedIndex = 0

            ' تعبئة قائمة حالات الورديات
            cmbStatusFilter.Items.Clear()
            cmbStatusFilter.Items.Add("--- كل الحالات ---")
            cmbStatusFilter.Items.Add("نشطة / مفتوحة")
            cmbStatusFilter.Items.Add("مغلقة")
            cmbStatusFilter.Items.Add("معلقة")
            cmbStatusFilter.SelectedIndex = 0

            ' تحميل قوائم الورديات والمستخدمين
            LoadFilterDropdowns()

            _isLoading = False

            ' تحميل وعرض التقرير
            LoadReportData()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء فتح شاشة تقارير الورديات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            _isLoading = False
        End Try
    End Sub

    Private Sub LoadFilterDropdowns()
        Try
            ' 1. تعبئة قائمة الورديات
            Dim dtShifts As New DataTable()
            dtShifts.Columns.Add("ShiftID", GetType(Integer))
            dtShifts.Columns.Add("ShiftDisplay", GetType(String))
            dtShifts.Rows.Add(0, "--- كل الورديات ---")

            Dim queryShifts As String = "SELECT S.ShiftID, S.ShiftNumber, S.OpenDateTime, ISNULL(W.WorkShiftName, N'عامة') AS WorkShiftName " &
                                        "FROM Shifts S " &
                                        "LEFT JOIN WorkShifts W ON S.WorkShiftID = W.WorkShiftID " &
                                        "WHERE S.IsDeleted = 0 OR S.IsDeleted IS NULL " &
                                        "ORDER BY S.ShiftID DESC"
            Dim dtRawShifts As DataTable = DBModule.ExecuteQuery(queryShifts)
            If dtRawShifts IsNot Nothing Then
                For Each r As DataRow In dtRawShifts.Rows
                    Dim sID As Integer = Convert.ToInt32(r("ShiftID"))
                    Dim sNum As String = r("ShiftNumber").ToString()
                    Dim wName As String = r("WorkShiftName").ToString()
                    Dim oDate As String = Convert.ToDateTime(r("OpenDateTime")).ToString("yyyy-MM-dd HH:mm")
                    dtShifts.Rows.Add(sID, $"{sNum} ({wName} - {oDate})")
                Next
            End If

            cmbShiftFilter.DataSource = dtShifts
            cmbShiftFilter.DisplayMember = "ShiftDisplay"
            cmbShiftFilter.ValueMember = "ShiftID"
            cmbShiftFilter.SelectedIndex = 0

            ' 2. تعبئة قائمة المستخدمين
            Dim dtUsers As New DataTable()
            dtUsers.Columns.Add("User_ID", GetType(Integer))
            dtUsers.Columns.Add("User_Name", GetType(String))
            dtUsers.Rows.Add(0, "--- كل المستخدمين ---")

            Dim queryUsers As String = "SELECT User_ID, User_Name FROM Users_TBL WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY User_Name"
            Dim dtRawUsers As DataTable = DBModule.ExecuteQuery(queryUsers)
            If dtRawUsers IsNot Nothing Then
                For Each r As DataRow In dtRawUsers.Rows
                    dtUsers.Rows.Add(Convert.ToInt32(r("User_ID")), r("User_Name").ToString())
                Next
            End If

            cmbUserFilter.DataSource = dtUsers
            cmbUserFilter.DisplayMember = "User_Name"
            cmbUserFilter.ValueMember = "User_ID"
            cmbUserFilter.SelectedIndex = 0

        Catch ex As Exception
            Logger.LogError("FrmShiftReports.LoadFilterDropdowns", ex)
        End Try
    End Sub

    Public Sub LoadReportData()
        If _isLoading Then Exit Sub

        Try
            Dim fromDate As DateTime = dtpFrom.Value.Date
            Dim toDate As DateTime = dtpTo.Value.Date.AddDays(1).AddSeconds(-1)
            Dim shiftID As Integer = If(cmbShiftFilter.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbShiftFilter.SelectedValue), Convert.ToInt32(cmbShiftFilter.SelectedValue), 0)
            Dim userID As Integer = If(cmbUserFilter.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbUserFilter.SelectedValue), Convert.ToInt32(cmbUserFilter.SelectedValue), 0)
            Dim statusIdx As Integer = cmbStatusFilter.SelectedIndex

            Select Case cmbReportMode.SelectedIndex
                Case 0
                    LoadShiftsOverview(fromDate, toDate, shiftID, userID, statusIdx)
                Case 1
                    LoadProductsReport(fromDate, toDate, shiftID, userID)
                Case 2
                    LoadCustomersReport(fromDate, toDate, shiftID, userID)
                Case 3
                    LoadInvoicesReport(fromDate, toDate, shiftID, userID)
                Case 4
                    LoadExpensesReport(fromDate, toDate, userID)
            End Select

            ApplySearchFilter()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء استعلام التقرير: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 1. ملخص الورديات الشامل
    Private Sub LoadShiftsOverview(fromDate As DateTime, toDate As DateTime, shiftID As Integer, userID As Integer, statusIdx As Integer)
        Dim sql As String = "SELECT S.ShiftID, S.ShiftNumber, " &
                            "ISNULL(W.WorkShiftName, N'عامة') AS WorkShiftName, " &
                            "CASE WHEN S.Status = 1 THEN N'نشطة' WHEN S.Status = 3 THEN N'معلقة' ELSE N'مغلقة' END AS StatusName, " &
                            "ISNULL(U1.User_Name, N'غير محدد') AS OpenUserName, " &
                            "ISNULL(U2.User_Name, N'غير محدد') AS CloseUserName, " &
                            "S.OpenDateTime, S.CloseDateTime, " &
                            "ISNULL(S.OpeningCash, 0) AS OpeningCash, " &
                            "ISNULL(S.TotalSales, 0) AS TotalSales, " &
                            "(ISNULL(S.TotalSales, 0) - ISNULL(S.TotalVisaSales, 0)) AS TotalCashSales, " &
                            "ISNULL(S.TotalVisaSales, 0) AS TotalVisaSales, " &
                            "ISNULL(S.TotalExpenses, 0) AS TotalExpenses, " &
                            "ISNULL(S.TotalIncomes, 0) AS TotalIncomes, " &
                            "ISNULL(S.ExpectedCash, 0) AS ExpectedCash, " &
                            "ISNULL(S.ClosingCash, 0) AS ClosingCash, " &
                            "ISNULL(S.CashDifference, 0) AS CashDifference, " &
                            "ISNULL(S.TotalOrders, 0) AS TotalOrders, " &
                            "ISNULL(S.Notes, '') AS Notes " &
                            "FROM Shifts S " &
                            "LEFT JOIN WorkShifts W ON S.WorkShiftID = W.WorkShiftID " &
                            "LEFT JOIN Users_TBL U1 ON S.UserID = U1.User_ID " &
                            "LEFT JOIN Users_TBL U2 ON S.ClosedByUserID = U2.User_ID " &
                            "WHERE (S.IsDeleted = 0 OR S.IsDeleted IS NULL) " &
                            "AND S.OpenDateTime >= @FromDate AND S.OpenDateTime <= @ToDate "

        If shiftID > 0 Then sql &= "AND S.ShiftID = @ShiftID "
        If userID > 0 Then sql &= "AND (S.UserID = @UserID OR S.ClosedByUserID = @UserID) "
        If statusIdx = 1 Then sql &= "AND S.Status = 1 "
        If statusIdx = 2 Then sql &= "AND S.Status = 2 "
        If statusIdx = 3 Then sql &= "AND S.Status = 3 "

        sql &= "ORDER BY S.ShiftID DESC"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@FromDate", fromDate)
                cmd.Parameters.AddWithValue("@ToDate", toDate)
                If shiftID > 0 Then cmd.Parameters.AddWithValue("@ShiftID", shiftID)
                If userID > 0 Then cmd.Parameters.AddWithValue("@UserID", userID)

                Using da As New SqlDataAdapter(cmd)
                    _rawTable = New DataTable()
                    da.Fill(_rawTable)
                End Using
            End Using
        End Using

        dgvReport.DataSource = _rawTable.DefaultView
        FormatShiftsOverviewColumns()
    End Sub

    Private Sub FormatShiftsOverviewColumns()
        If dgvReport.Columns.Contains("ShiftID") Then dgvReport.Columns("ShiftID").Visible = False

        SetCol("ShiftNumber", "رقم الوردية", 110)
        SetCol("WorkShiftName", "نوع الوردية", 90)
        SetCol("StatusName", "الحالة", 80)
        SetCol("OpenUserName", "مسؤول الفتح", 100)
        SetCol("CloseUserName", "مسؤول الإغلاق", 100)
        SetCol("OpenDateTime", "تاريخ الفتح", 120, "yyyy/MM/dd HH:mm")
        SetCol("CloseDateTime", "تاريخ الإغلاق", 120, "yyyy/MM/dd HH:mm")
        SetCol("OpeningCash", "العهدة", 85, "N2")
        SetCol("TotalSales", "المبيعات", 95, "N2")
        SetCol("TotalCashSales", "كاش", 85, "N2")
        SetCol("TotalVisaSales", "فيزا", 85, "N2")
        SetCol("TotalExpenses", "المصروفات", 85, "N2")
        SetCol("TotalIncomes", "المقبوضات", 85, "N2")
        SetCol("ExpectedCash", "المفترض", 90, "N2")
        SetCol("ClosingCash", "الفعلي", 90, "N2")
        SetCol("CashDifference", "العجز/الزيادة", 95, "N2")
        SetCol("TotalOrders", "الفواتير", 75)
        SetCol("Notes", "ملاحظات", 140)
    End Sub

    ' 2. مبيعات الأصناف فقط
    Private Sub LoadProductsReport(fromDate As DateTime, toDate As DateTime, shiftID As Integer, userID As Integer)
        Dim sql As String = "SELECT D.ProductID, D.ProductName, " &
                            "ISNULL(D.SizeName, N'-') AS SizeName, " &
                            "SUM(D.Quantity) AS TotalQty, " &
                            "CASE WHEN SUM(D.Quantity) > 0 THEN ROUND(SUM(D.TotalPrice) / SUM(D.Quantity), 2) ELSE 0 END AS AvgPrice, " &
                            "SUM(D.TotalPrice) AS TotalSales, " &
                            "COUNT(DISTINCT I.InvoiceID) AS InvoicesCount " &
                            "FROM SalesInvoiceDetails D " &
                            "INNER JOIN SalesInvoices I ON D.InvoiceID = I.InvoiceID " &
                            "WHERE (I.IsDeleted = 0 OR I.IsDeleted IS NULL) " &
                            "AND I.InvoiceDate >= @FromDate AND I.InvoiceDate <= @ToDate "

        If shiftID > 0 Then sql &= "AND I.ShiftID = @ShiftID "
        If userID > 0 Then sql &= "AND I.UserID = @UserID "

        sql &= "GROUP BY D.ProductID, D.ProductName, D.SizeName " &
               "ORDER BY TotalSales DESC"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@FromDate", fromDate)
                cmd.Parameters.AddWithValue("@ToDate", toDate)
                If shiftID > 0 Then cmd.Parameters.AddWithValue("@ShiftID", shiftID)
                If userID > 0 Then cmd.Parameters.AddWithValue("@UserID", userID)

                Using da As New SqlDataAdapter(cmd)
                    _rawTable = New DataTable()
                    da.Fill(_rawTable)
                End Using
            End Using
        End Using

        dgvReport.DataSource = _rawTable.DefaultView
        FormatProductsReportColumns()
    End Sub

    Private Sub FormatProductsReportColumns()
        SetCol("ProductID", "كود الصنف", 90)
        SetCol("ProductName", "اسم الصنف", 250)
        SetCol("SizeName", "الحجم / المقاس", 120)
        SetCol("TotalQty", "إجمالي الكمية المباعة", 140, "N0")
        SetCol("AvgPrice", "متوسط سعر البيع", 130, "N2")
        SetCol("TotalSales", "إجمالي قيمة المبيعات", 160, "N2")
        SetCol("InvoicesCount", "عدد مرات الطلب / الفواتير", 160)
    End Sub

    ' 3. تقرير العملاء فقط
    Private Sub LoadCustomersReport(fromDate As DateTime, toDate As DateTime, shiftID As Integer, userID As Integer)
        Dim sql As String = "SELECT ISNULL(C.CustomerID, 0) AS CustomerID, " &
                            "ISNULL(C.CustomerName, N'عميل نقدي / غير مسجل') AS CustomerName, " &
                            "ISNULL(C.PhoneNumber, N'-') AS PhoneNumber, " &
                            "COUNT(I.InvoiceID) AS InvoicesCount, " &
                            "SUM(I.NetTotal) AS TotalSpent, " &
                            "SUM(I.PaidAmount) AS TotalPaid, " &
                            "SUM(I.RemainingAmount) AS TotalRemaining, " &
                            "MAX(I.InvoiceDate) AS LastOrderDate " &
                            "FROM SalesInvoices I " &
                            "LEFT JOIN Customers C ON I.CustomerID = C.CustomerID " &
                            "WHERE (I.IsDeleted = 0 OR I.IsDeleted IS NULL) " &
                            "AND I.InvoiceDate >= @FromDate AND I.InvoiceDate <= @ToDate "

        If shiftID > 0 Then sql &= "AND I.ShiftID = @ShiftID "
        If userID > 0 Then sql &= "AND I.UserID = @UserID "

        sql &= "GROUP BY C.CustomerID, C.CustomerName, C.PhoneNumber " &
               "ORDER BY TotalSpent DESC"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@FromDate", fromDate)
                cmd.Parameters.AddWithValue("@ToDate", toDate)
                If shiftID > 0 Then cmd.Parameters.AddWithValue("@ShiftID", shiftID)
                If userID > 0 Then cmd.Parameters.AddWithValue("@UserID", userID)

                Using da As New SqlDataAdapter(cmd)
                    _rawTable = New DataTable()
                    da.Fill(_rawTable)
                End Using
            End Using
        End Using

        dgvReport.DataSource = _rawTable.DefaultView
        FormatCustomersReportColumns()
    End Sub

    Private Sub FormatCustomersReportColumns()
        If dgvReport.Columns.Contains("CustomerID") Then dgvReport.Columns("CustomerID").Visible = False

        SetCol("CustomerName", "اسم العميل", 240)
        SetCol("PhoneNumber", "رقم الهاتف", 140)
        SetCol("InvoicesCount", "عدد الفواتير والطلبات", 140)
        SetCol("TotalSpent", "إجمالي المشتريات", 150, "N2")
        SetCol("TotalPaid", "المبلغ المسدد", 140, "N2")
        SetCol("TotalRemaining", "المتبقي / آجل", 140, "N2")
        SetCol("LastOrderDate", "تاريخ آخر طلب", 160, "yyyy/MM/dd HH:mm")
    End Sub

    ' 4. فواتير المبيعات فقط
    Private Sub LoadInvoicesReport(fromDate As DateTime, toDate As DateTime, shiftID As Integer, userID As Integer)
        Dim sql As String = "SELECT I.InvoiceID, I.InvoiceNumber, I.InvoiceDate, " &
                            "CASE I.OrderType WHEN 1 THEN N'تيك أوي' WHEN 2 THEN N'صالة' WHEN 3 THEN N'دليفري' ELSE N'أخرى' END AS OrderTypeName, " &
                            "ISNULL(C.CustomerName, N'عميل نقدي') AS CustomerName, " &
                            "ISNULL(U.User_Name, N'-') AS CashierName, " &
                            "ISNULL(S.ShiftNumber, N'-') AS ShiftNumber, " &
                            "I.TotalBeforeDiscount, I.DiscountAmount, I.DeliveryFee, I.NetTotal, I.PaidAmount, I.RemainingAmount, " &
                            "CASE WHEN I.IsCredit = 1 THEN N'آجل' ELSE N'نقدي' END AS PaymentTypeName, " &
                            "ISNULL(I.Notes, '') AS Notes " &
                            "FROM SalesInvoices I " &
                            "LEFT JOIN Customers C ON I.CustomerID = C.CustomerID " &
                            "LEFT JOIN Users_TBL U ON I.UserID = U.User_ID " &
                            "LEFT JOIN Shifts S ON I.ShiftID = S.ShiftID " &
                            "WHERE (I.IsDeleted = 0 OR I.IsDeleted IS NULL) " &
                            "AND I.InvoiceDate >= @FromDate AND I.InvoiceDate <= @ToDate "

        If shiftID > 0 Then sql &= "AND I.ShiftID = @ShiftID "
        If userID > 0 Then sql &= "AND I.UserID = @UserID "

        sql &= "ORDER BY I.InvoiceID DESC"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@FromDate", fromDate)
                cmd.Parameters.AddWithValue("@ToDate", toDate)
                If shiftID > 0 Then cmd.Parameters.AddWithValue("@ShiftID", shiftID)
                If userID > 0 Then cmd.Parameters.AddWithValue("@UserID", userID)

                Using da As New SqlDataAdapter(cmd)
                    _rawTable = New DataTable()
                    da.Fill(_rawTable)
                End Using
            End Using
        End Using

        dgvReport.DataSource = _rawTable.DefaultView
        FormatInvoicesReportColumns()
    End Sub

    Private Sub FormatInvoicesReportColumns()
        If dgvReport.Columns.Contains("InvoiceID") Then dgvReport.Columns("InvoiceID").Visible = False

        SetCol("InvoiceNumber", "رقم الفاتورة", 100)
        SetCol("InvoiceDate", "تاريخ الفاتورة", 130, "yyyy/MM/dd HH:mm")
        SetCol("OrderTypeName", "نوع الطلب", 90)
        SetCol("CustomerName", "العميل", 150)
        SetCol("CashierName", "الكاشير", 110)
        SetCol("ShiftNumber", "الوردية", 100)
        SetCol("TotalBeforeDiscount", "الإجمالي قبل الخصم", 110, "N2")
        SetCol("DiscountAmount", "الخصم", 85, "N2")
        SetCol("DeliveryFee", "التوصيل", 85, "N2")
        SetCol("NetTotal", "الصافي", 105, "N2")
        SetCol("PaidAmount", "المدفوع", 100, "N2")
        SetCol("RemainingAmount", "المتبقي", 100, "N2")
        SetCol("PaymentTypeName", "الدفع", 80)
        SetCol("Notes", "ملاحظات", 140)
    End Sub

    ' 5. تقرير المصروفات فقط
    Private Sub LoadExpensesReport(fromDate As DateTime, toDate As DateTime, userID As Integer)
        Dim sql As String = "SELECT E.Expense_ID, E.Expense_Date, ISNULL(E.Category, N'عام') AS Category, " &
                            "ISNULL(E.Amount, 0) AS Amount, ISNULL(E.Payee, N'-') AS Payee, " &
                            "ISNULL(E.Payment_Method, N'-') AS Payment_Method, " &
                            "ISNULL(E.Payment_Status, N'-') AS Payment_Status, " &
                            "ISNULL(E.Notes, '') AS Notes, " &
                            "ISNULL(U.User_Name, ISNULL(E.Created_By, N'غير محدد')) AS CreatedByUserName " &
                            "FROM Expenses E " &
                            "LEFT JOIN Users_TBL U ON (TRY_CAST(E.Created_By AS INT) = U.User_ID OR E.Created_By = U.User_Name OR E.Created_By = U.User_username) " &
                            "WHERE CAST(E.Expense_Date AS DATE) >= CAST(@FromDate AS DATE) AND CAST(E.Expense_Date AS DATE) <= CAST(@ToDate AS DATE) "

        If userID > 0 Then
            sql &= "AND (TRY_CAST(E.Created_By AS INT) = @UserID OR E.Created_By = (SELECT TOP 1 User_Name FROM Users_TBL WHERE User_ID = @UserID) OR E.Created_By = (SELECT TOP 1 User_username FROM Users_TBL WHERE User_ID = @UserID)) "
        End If

        sql &= "ORDER BY E.Expense_ID DESC"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@FromDate", fromDate)
                cmd.Parameters.AddWithValue("@ToDate", toDate)
                If userID > 0 Then cmd.Parameters.AddWithValue("@UserID", userID)

                Using da As New SqlDataAdapter(cmd)
                    _rawTable = New DataTable()
                    da.Fill(_rawTable)
                End Using
            End Using
        End Using

        dgvReport.DataSource = _rawTable.DefaultView
        FormatExpensesReportColumns()
    End Sub

    Private Sub FormatExpensesReportColumns()
        SetCol("Expense_ID", "كود المصروف", 95)
        SetCol("Expense_Date", "التاريخ", 130, "yyyy/MM/dd")
        SetCol("Category", "بند المصروف", 160)
        SetCol("Amount", "المبلغ", 110, "N2")
        SetCol("Payee", "الجهة المنصرف إليها", 160)
        SetCol("Payment_Method", "طريقة الدفع", 110)
        SetCol("Payment_Status", "الحالة", 100)
        SetCol("CreatedByUserName", "المستخدم", 130)
        SetCol("Notes", "ملاحظات", 200)
    End Sub

    Private Sub SetCol(colName As String, header As String, width As Integer, Optional format As String = "")
        If dgvReport.Columns.Contains(colName) Then
            Dim c = dgvReport.Columns(colName)
            c.HeaderText = header
            c.Width = width
            c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If Not String.IsNullOrEmpty(format) Then
                c.DefaultCellStyle.Format = format
            End If
        End If
    End Sub

    ' البحث الفوري عبر كافة الأعمدة
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearchFilter()
    End Sub

    Private Sub ApplySearchFilter()
        If _rawTable Is Nothing Then Exit Sub

        Try
            Dim term As String = txtSearch.Text.Trim().Replace("'", "''")
            If String.IsNullOrWhiteSpace(term) Then
                _rawTable.DefaultView.RowFilter = String.Empty
            Else
                Dim filterParts As New List(Of String)
                For Each col As DataColumn In _rawTable.Columns
                    If col.DataType Is GetType(String) Then
                        filterParts.Add($"[{col.ColumnName}] LIKE '%{term}%'")
                    ElseIf col.DataType Is GetType(Integer) OrElse col.DataType Is GetType(Decimal) OrElse col.DataType Is GetType(Double) Then
                        filterParts.Add($"Convert([{col.ColumnName}], 'System.String') LIKE '%{term}%'")
                    End If
                Next
                _rawTable.DefaultView.RowFilter = String.Join(" OR ", filterParts)
            End If

            CalculateKPIs()

        Catch ex As Exception
            Logger.LogError("FrmShiftReports.ApplySearchFilter", ex)
        End Try
    End Sub

    ' حساب وعرض كروت المؤشرات المالية والإجماليات
    Private Sub CalculateKPIs()
        If _rawTable Is Nothing Then Exit Sub

        Dim view As DataView = _rawTable.DefaultView
        Dim count As Integer = view.Count
        lblRecordsCount.Text = count.ToString("N0")

        Dim totalSales As Decimal = 0
        Dim totalCash As Decimal = 0
        Dim totalVisa As Decimal = 0
        Dim totalExpenses As Decimal = 0
        Dim netIncome As Decimal = 0
        Dim totalDiff As Decimal = 0

        ' إعادة المسميات الافتراضية للبطاقات
        lblTotalSalesTitle.Text = "إجمالي المبيعات"
        lblTotalCashTitle.Text = "مبيعات الكاش"
        lblTotalVisaTitle.Text = "مبيعات الفيزا"
        lblTotalExpensesTitle.Text = "إجمالي المصروفات"
        lblNetIncomeTitle.Text = "صافي النقدية / الإيراد"
        lblTotalDiffTitle.Text = "فارق الدرج (عجز/زيادة)"
        lblRecordsCountTitle.Text = "عدد السجلات / العمليات"

        Select Case cmbReportMode.SelectedIndex
            Case 0 ' ملخص الورديات
                For Each rv As DataRowView In view
                    Dim row = rv.Row
                    If _rawTable.Columns.Contains("TotalSales") AndAlso Not IsDBNull(row("TotalSales")) Then totalSales += Convert.ToDecimal(row("TotalSales"))
                    If _rawTable.Columns.Contains("TotalCashSales") AndAlso Not IsDBNull(row("TotalCashSales")) Then totalCash += Convert.ToDecimal(row("TotalCashSales"))
                    If _rawTable.Columns.Contains("TotalVisaSales") AndAlso Not IsDBNull(row("TotalVisaSales")) Then totalVisa += Convert.ToDecimal(row("TotalVisaSales"))
                    If _rawTable.Columns.Contains("TotalExpenses") AndAlso Not IsDBNull(row("TotalExpenses")) Then totalExpenses += Convert.ToDecimal(row("TotalExpenses"))
                    If _rawTable.Columns.Contains("CashDifference") AndAlso Not IsDBNull(row("CashDifference")) Then totalDiff += Convert.ToDecimal(row("CashDifference"))
                Next
                netIncome = totalSales - totalExpenses

            Case 1 ' الأصناف فقط
                lblTotalCashTitle.Text = "إجمالي الكمية المباعة"
                lblTotalVisaTitle.Text = "عدد الفواتير"
                Dim totalInvoices As Integer = 0
                For Each rv As DataRowView In view
                    Dim row = rv.Row
                    If _rawTable.Columns.Contains("TotalSales") AndAlso Not IsDBNull(row("TotalSales")) Then totalSales += Convert.ToDecimal(row("TotalSales"))
                    If _rawTable.Columns.Contains("TotalQty") AndAlso Not IsDBNull(row("TotalQty")) Then totalCash += Convert.ToDecimal(row("TotalQty"))
                    If _rawTable.Columns.Contains("InvoicesCount") AndAlso Not IsDBNull(row("InvoicesCount")) Then totalInvoices += Convert.ToInt32(row("InvoicesCount"))
                Next
                netIncome = totalSales
                totalVisa = totalInvoices

            Case 2 ' العملاء فقط
                lblTotalSalesTitle.Text = "إجمالي المشتريات"
                lblTotalCashTitle.Text = "المبالغ المسددة"
                lblTotalVisaTitle.Text = "المبالغ المتبقية/آجل"
                For Each rv As DataRowView In view
                    Dim row = rv.Row
                    If _rawTable.Columns.Contains("TotalSpent") AndAlso Not IsDBNull(row("TotalSpent")) Then totalSales += Convert.ToDecimal(row("TotalSpent"))
                    If _rawTable.Columns.Contains("TotalPaid") AndAlso Not IsDBNull(row("TotalPaid")) Then totalCash += Convert.ToDecimal(row("TotalPaid"))
                    If _rawTable.Columns.Contains("TotalRemaining") AndAlso Not IsDBNull(row("TotalRemaining")) Then totalVisa += Convert.ToDecimal(row("TotalRemaining"))
                Next
                netIncome = totalCash

            Case 3 ' الفواتير فقط
                lblTotalCashTitle.Text = "المبالغ المسددة"
                lblTotalVisaTitle.Text = "المبالغ المتبقية/آجل"
                For Each rv As DataRowView In view
                    Dim row = rv.Row
                    If _rawTable.Columns.Contains("NetTotal") AndAlso Not IsDBNull(row("NetTotal")) Then totalSales += Convert.ToDecimal(row("NetTotal"))
                    If _rawTable.Columns.Contains("PaidAmount") AndAlso Not IsDBNull(row("PaidAmount")) Then totalCash += Convert.ToDecimal(row("PaidAmount"))
                    If _rawTable.Columns.Contains("RemainingAmount") AndAlso Not IsDBNull(row("RemainingAmount")) Then totalVisa += Convert.ToDecimal(row("RemainingAmount"))
                Next
                netIncome = totalCash

            Case 4 ' المصروفات فقط
                lblTotalSalesTitle.Text = "إجمالي المصروفات"
                lblTotalCashTitle.Text = "المصروفات النقدية"
                lblTotalVisaTitle.Text = "مصروفات أخرى"
                Dim cashExp As Decimal = 0
                Dim otherExp As Decimal = 0
                For Each rv As DataRowView In view
                    Dim row = rv.Row
                    Dim amt As Decimal = 0
                    If _rawTable.Columns.Contains("Amount") AndAlso Not IsDBNull(row("Amount")) Then
                        amt = Convert.ToDecimal(row("Amount"))
                        totalExpenses += amt
                    End If
                    Dim method As String = If(_rawTable.Columns.Contains("Payment_Method") AndAlso Not IsDBNull(row("Payment_Method")), row("Payment_Method").ToString(), "")
                    If method.Contains("نقدي") OrElse method.Contains("كاش") Then
                        cashExp += amt
                    Else
                        otherExp += amt
                    End If
                Next
                totalSales = totalExpenses
                totalCash = cashExp
                totalVisa = otherExp
                netIncome = -totalExpenses
        End Select

        lblTotalSalesSum.Text = totalSales.ToString("N2") & " ج"
        If cmbReportMode.SelectedIndex = 1 Then
            lblTotalCashSum.Text = totalCash.ToString("N0")
            lblTotalVisaSum.Text = totalVisa.ToString("N0")
        Else
            lblTotalCashSum.Text = totalCash.ToString("N2") & " ج"
            lblTotalVisaSum.Text = totalVisa.ToString("N2") & " ج"
        End If
        lblTotalExpensesSum.Text = totalExpenses.ToString("N2") & " ج"
        lblNetIncomeSum.Text = netIncome.ToString("N2") & " ج"
        lblTotalDifferenceSum.Text = totalDiff.ToString("N2") & " ج"

        If totalDiff < 0 Then
            lblTotalDifferenceSum.ForeColor = Color.Red
        ElseIf totalDiff > 0 Then
            lblTotalDifferenceSum.ForeColor = Color.ForestGreen
        Else
            lblTotalDifferenceSum.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cmbReportMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportMode.SelectedIndexChanged
        Dim isExpenses = (cmbReportMode.SelectedIndex = 4)
        cmbShiftFilter.Enabled = Not isExpenses
        cmbStatusFilter.Enabled = (cmbReportMode.SelectedIndex = 0)
        If Not _isLoading Then LoadReportData()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadReportData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _isLoading = True
        dtpFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpTo.Value = DateTime.Now
        cmbShiftFilter.SelectedIndex = 0
        cmbUserFilter.SelectedIndex = 0
        cmbStatusFilter.SelectedIndex = 0
        txtSearch.Clear()
        _isLoading = False
        LoadReportData()
    End Sub

    ' تصدير إلى Excel بتنسيق راقٍ
    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("لا توجد بيانات معروضة لتصديرها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "ملف إكسيل Excel Workbook (*.xlsx)|*.xlsx"
            sfd.FileName = $"تقرير_الورديات_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                ' بناء جدول بيانات نظيف بالعناوين العربية المعروضة حالياً
                Dim exportDt As New DataTable("ShiftReport")
                For Each col As DataGridViewColumn In dgvReport.Columns
                    If col.Visible Then
                        exportDt.Columns.Add(col.HeaderText, GetType(String))
                    End If
                Next

                For Each row As DataGridViewRow In dgvReport.Rows
                    If Not row.IsNewRow Then
                        Dim newRow = exportDt.NewRow()
                        For Each col As DataGridViewColumn In dgvReport.Columns
                            If col.Visible Then
                                Dim val = row.Cells(col.Index).Value
                                If val IsNot Nothing AndAlso Not IsDBNull(val) Then
                                    If TypeOf val Is DateTime Then
                                        newRow(col.HeaderText) = Convert.ToDateTime(val).ToString("yyyy/MM/dd HH:mm")
                                    ElseIf TypeOf val Is Decimal OrElse TypeOf val Is Double Then
                                        newRow(col.HeaderText) = Convert.ToDecimal(val).ToString("N2")
                                    Else
                                        newRow(col.HeaderText) = val.ToString()
                                    End If
                                Else
                                    newRow(col.HeaderText) = ""
                                End If
                            End If
                        Next
                        exportDt.Rows.Add(newRow)
                    End If
                Next

                Using wb As New XLWorkbook()
                    Dim ws = wb.Worksheets.Add("التقرير")
                    ws.RightToLeft = True

                    ' عنوان التقرير
                    ws.Cell(1, 1).Value = Me.Text & " - " & cmbReportMode.Text
                    ws.Cell(1, 1).Style.Font.Bold = True
                    ws.Cell(1, 1).Style.Font.FontSize = 14
                    ws.Cell(1, 1).Style.Font.FontColor = XLColor.FromArgb(43, 91, 132)

                    ' الفترة
                    ws.Cell(2, 1).Value = $"الفترة من: {dtpFrom.Value:yyyy/MM/dd} إلى: {dtpTo.Value:yyyy/MM/dd}"
                    ws.Cell(2, 1).Style.Font.FontSize = 11

                    ' إضافة الجدول
                    Dim table = ws.Cell(4, 1).InsertTable(exportDt, "ReportData", True)
                    table.Theme = XLTableTheme.TableStyleMedium9

                    ' ضبط المحاذاة وحجم الأعمدة
                    ws.Columns().AdjustToContents()
                    ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                    wb.SaveAs(sfd.FileName)
                End Using

                MessageBox.Show("✅ تم تصدير التقرير إلى Excel بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim folderPath As String = Path.GetDirectoryName(sfd.FileName)
                Process.Start("explorer.exe", folderPath)
            End If

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تصدير ملف الإكسيل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' طباعة التقرير مع دعم تعدد الصفحات بالكامل
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If dgvReport.Rows.Count = 0 Then
                MessageBox.Show("لا توجد بيانات معروضة للطباعة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim doc As New Printing.PrintDocument()
            AddHandler doc.BeginPrint, Sub(s, ev)
                                           _currentPrintRowIndex = 0
                                           _currentPrintPageNumber = 0
                                       End Sub
            AddHandler doc.PrintPage, AddressOf PrintDocument_PrintPage

            Dim prevDlg As New PrintPreviewDialog()
            prevDlg.Document = doc
            prevDlg.WindowState = FormWindowState.Maximized
            prevDlg.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' تصدير إلى PDF بتنسيق راقٍ ومباشر
    Private Sub btnExportPdf_Click(sender As Object, e As EventArgs) Handles btnExportPdf.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("لا توجد بيانات معروضة لتصديرها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "ملف PDF (*.pdf)|*.pdf"
            sfd.FileName = $"تقرير_الورديات_{DateTime.Now:yyyyMMdd_HHmm}.pdf"

            If sfd.ShowDialog() = DialogResult.OK Then
                Dim doc As New Printing.PrintDocument()
                Dim isPdfPrinterFound As Boolean = False

                For Each printer As String In Printing.PrinterSettings.InstalledPrinters
                    If printer.IndexOf("Print to PDF", StringComparison.OrdinalIgnoreCase) >= 0 Then
                        doc.PrinterSettings.PrinterName = printer
                        isPdfPrinterFound = True
                        Exit For
                    End If
                Next

                If Not isPdfPrinterFound Then
                    MessageBox.Show("طابعة 'Microsoft Print to PDF' غير محددة كطابعة افتراضية. سيتم فتح نافذة اختيار الطابعة لحفظ الملف كـ PDF.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Using printDlg As New PrintDialog()
                        printDlg.Document = doc
                        If printDlg.ShowDialog() <> DialogResult.OK Then Exit Sub
                    End Using
                End If

                doc.PrinterSettings.PrintToFile = True
                doc.PrinterSettings.PrintFileName = sfd.FileName

                AddHandler doc.BeginPrint, Sub(s, ev)
                                               _currentPrintRowIndex = 0
                                               _currentPrintPageNumber = 0
                                           End Sub
                AddHandler doc.PrintPage, AddressOf PrintDocument_PrintPage

                doc.Print()

                MessageBox.Show("✅ تم تصدير تقرير الوردية إلى PDF بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If File.Exists(sfd.FileName) Then
                    Dim folderPath As String = Path.GetDirectoryName(sfd.FileName)
                    Process.Start("explorer.exe", folderPath)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تصدير ملف الـ PDF: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim fontTitle As New Font("Segoe UI", 15, FontStyle.Bold)
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontBody As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim fontFooter As New Font("Segoe UI", 8, FontStyle.Italic)
        Dim sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        Dim sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}

        _currentPrintPageNumber += 1
        Dim y As Single = 40
        Dim pageWidth As Single = e.MarginBounds.Width
        Dim leftMargin As Single = e.MarginBounds.Left

        ' رأس الصفحة الأولى فقط
        If _currentPrintPageNumber = 1 Then
            g.DrawString("نظام سستمك لإدارة نقاط البيع والمطاعم", fontHeader, Brushes.Gray, New RectangleF(leftMargin, y, pageWidth, 25), sfCenter)
            y += 30
            g.DrawString(Me.Text & " (" & cmbReportMode.Text & ")", fontTitle, Brushes.Black, New RectangleF(leftMargin, y, pageWidth, 35), sfCenter)
            y += 40

            Dim periodText As String = $"الفترة من: {dtpFrom.Value:yyyy/MM/dd}  إلى: {dtpTo.Value:yyyy/MM/dd}  | تاريخ الطباعة: {DateTime.Now:yyyy/MM/dd HH:mm}"
            g.DrawString(periodText, fontBody, Brushes.DarkSlateGray, New RectangleF(leftMargin, y, pageWidth, 25), sfCenter)
            y += 35

            g.DrawLine(Pens.Gray, leftMargin, y, leftMargin + pageWidth, y)
            y += 10

            Dim kpiText As String = $"إجمالي المبيعات: {lblTotalSalesSum.Text}  |  المصروفات: {lblTotalExpensesSum.Text}  |  الصافي: {lblNetIncomeSum.Text}  |  السجلات: {lblRecordsCount.Text}"
            g.DrawString(kpiText, fontHeader, Brushes.Black, New RectangleF(leftMargin, y, pageWidth, 25), sfCenter)
            y += 35
            g.DrawLine(Pens.Gray, leftMargin, y, leftMargin + pageWidth, y)
            y += 15
        Else
            g.DrawString(Me.Text & " - " & cmbReportMode.Text & $" (صفحة {_currentPrintPageNumber})", fontHeader, Brushes.DarkSlateGray, New RectangleF(leftMargin, y, pageWidth, 25), sfCenter)
            y += 30
            g.DrawLine(Pens.Gray, leftMargin, y, leftMargin + pageWidth, y)
            y += 10
        End If

        ' تحديد الأعمدة المرئية للطباعة
        Dim visibleCols As New List(Of DataGridViewColumn)()
        For Each col As DataGridViewColumn In dgvReport.Columns
            If col.Visible AndAlso visibleCols.Count < 6 Then visibleCols.Add(col)
        Next

        If visibleCols.Count > 0 Then
            Dim colW As Single = pageWidth / visibleCols.Count
            Dim curX As Single = leftMargin

            ' رسم رؤوس الأعمدة
            For i As Integer = visibleCols.Count - 1 To 0 Step -1
                Dim col = visibleCols(i)
                g.FillRectangle(Brushes.LightSteelBlue, curX, y, colW, 28)
                g.DrawRectangle(Pens.Gray, curX, y, colW, 28)
                g.DrawString(col.HeaderText, fontHeader, Brushes.Black, New RectangleF(curX, y, colW, 28), sfCenter)
                curX += colW
            Next
            y += 28

            ' رسم صفوف الجدول للصفحة الحالية
            Dim bottomMargin As Single = e.MarginBounds.Bottom - 35
            While _currentPrintRowIndex < dgvReport.Rows.Count
                If y + 24 > bottomMargin Then
                    e.HasMorePages = True
                    Exit Sub
                End If

                Dim row = dgvReport.Rows(_currentPrintRowIndex)
                curX = leftMargin
                For i As Integer = visibleCols.Count - 1 To 0 Step -1
                    Dim col = visibleCols(i)
                    Dim cellVal = row.Cells(col.Index).FormattedValue?.ToString()
                    g.DrawRectangle(Pens.LightGray, curX, y, colW, 24)
                    g.DrawString(cellVal, fontBody, Brushes.Black, New RectangleF(curX, y, colW, 24), sfCenter)
                    curX += colW
                Next
                y += 24
                _currentPrintRowIndex += 1
            End While
        End If

        ' تذييل الصفحة ورقمها
        Dim footerY As Single = e.MarginBounds.Bottom - 20
        g.DrawString($"صفحة {_currentPrintPageNumber}  |  نظام سستمك", fontFooter, Brushes.Gray, New RectangleF(leftMargin, footerY, pageWidth, 20), sfCenter)

        e.HasMorePages = False
    End Sub

    ' أزرار الهيدر
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

End Class
