'Imports System.Data.SqlClient
'Imports System.Text
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement

'Public Class Reports
'    Dim x, y As Integer
'    Dim newpoint As New Point
'    Dim adapter As SqlDataAdapter
'    Dim adapter2 As SqlDataAdapter
'    Dim adapter4 As SqlDataAdapter
'    Dim ds As New DataSet
'    Dim dt As New DataTable
'    Dim dt2 As New DataTable
'    Dim cmdb As New SqlCommandBuilder

'    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown, lblTime.MouseDown, lblDate.MouseDown, lbl_user_name.MouseDown, Label14.MouseDown, lblHeader.MouseDown
'        x = Control.MousePosition.X - Me.Location.X
'        y = Control.MousePosition.Y - Me.Location.Y
'    End Sub

'    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
'        Close()
'    End Sub

'    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
'        If WindowState = FormWindowState.Normal Then
'            WindowState = FormWindowState.Maximized
'        Else
'            WindowState = FormWindowState.Normal
'        End If
'    End Sub

'    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
'        WindowState = FormWindowState.Minimized
'    End Sub

'    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        ' ملء القوائم
'        cmbSalesCustomer.DataSource = ReportsModule.GetCustomersList()
'        cmbSalesCustomer.DisplayMember = "CustomerName"
'        cmbSalesCustomer.ValueMember = "CustomerID"
'        cmbSalesCustomer.SelectedIndex = -1


'        cmbSalesUser.DataSource = ReportsModule.GetUsersList()
'        cmbSalesUser.DisplayMember = "User_Name"
'        cmbSalesUser.ValueMember = "User_ID"
'        cmbSalesUser.SelectedIndex = -1


'        cmbSalesPay.DataSource = ReportsModule.GetPaymentMethodsList()
'        cmbSalesPay.DisplayMember = "Payment_Method"
'        cmbSalesPay.ValueMember = "Payment_Method"
'        cmbSalesPay.SelectedIndex = -1


'        dtpSalesTo.Value = DateTime.Now.Date
'        dtpSalesFrom.Value = dtpSalesTo.Value.AddDays(-30)
'    End Sub

'    Private Sub btnSalesLoadAll_Click(sender As Object, e As EventArgs) Handles btnSalesLoadAll.Click
'        'Try
'        '    LoadSalesSummary()
'        '    LoadSalesInvoices()
'        'Finally
'        '    btnSalesLoadAll.Enabled = True
'        'End Try
'    End Sub

'    Private Sub dtpSalesFrom_ValueChanged(sender As Object, e As EventArgs)

'    End Sub

'    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove, lblTime.MouseMove, lblDate.MouseMove, lbl_user_name.MouseMove, Label14.MouseMove, lblHeader.MouseMove
'        If e.Button = MouseButtons.Left Then
'            newpoint = Control.MousePosition
'            newpoint.X -= x
'            newpoint.Y -= y
'            Me.Location = newpoint
'        End If
'    End Sub
'End Class

'Imports System.Data
'Imports System.IO
'Imports System.Text
'Imports DocumentFormat.OpenXml.Spreadsheet

'Public Class Reports

'    ' ---------------------------
'    ' Form Load
'    ' ---------------------------
'    Private Sub FormReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Try
'            ' ضبط التواريخ الافتراضية (آخر 30 يوم)
'            dtpSalesTo.Value = DateTime.Now.Date
'            dtpSalesFrom.Value = dtpSalesTo.Value.AddDays(-30)

'            'dtpPurTo.Value = DateTime.Now.Date
'            'dtpPurFrom.Value = dtpPurTo.Value.AddDays(-30)

'            'dtpProfitTo.Value = DateTime.Now.Date
'            'dtpProfitFrom.Value = dtpProfitTo.Value.AddDays(-30)

'            ' ملء القوائم
'            BindComboBoxes()

'            ' تهيئة الـ DataGridViews الافتراضية (إن أردت)
'            PrepareDataGrids()

'        Catch ex As Exception
'            MessageBox.Show("خطأ أثناء تهيئة الفورم: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ---------------------------
'    ' Bind ComboBoxes
'    ' ---------------------------
'    Private Sub BindComboBoxes()
'        Try
'            ' Customers
'            Dim dtCust As DataTable = ReportsModule.GetCustomersList()
'            cmbSalesCustomer.DataSource = dtCust
'            cmbSalesCustomer.DisplayMember = "CustomerName"
'            cmbSalesCustomer.ValueMember = "CustomerID"
'            cmbSalesCustomer.SelectedIndex = -1

'            cmbSalesCustomer2.DataSource = ReportsModule.GetCustomersList()
'            cmbSalesCustomer2.DisplayMember = "CustomerName"
'            cmbSalesCustomer2.ValueMember = "CustomerID"
'            cmbSalesCustomer2.SelectedIndex = -1

'            ' Users
'            Dim dtUsers As DataTable = ReportsModule.GetUsersList()
'            cmbSalesUser.DataSource = dtUsers
'            cmbSalesUser.DisplayMember = "UserName"
'            cmbSalesUser.ValueMember = "UserID"
'            cmbSalesUser.SelectedIndex = -1

'            ' Payment methods
'            Dim dtPay As DataTable = ReportsModule.GetPaymentMethodsList()
'            cmbSalesPay.DataSource = dtPay
'            cmbSalesPay.DisplayMember = "Payment_Method"
'            cmbSalesPay.ValueMember = "Payment_Method"
'            cmbSalesPay.SelectedIndex = -1

'            ' Products for ByProduct tab (if you have a Products table)
'            Try
'                Connect()
'                Dim dtProducts As New DataTable()
'                Using cmd = New SqlClient.SqlCommand("SELECT Product_ID, ProductName FROM Products ORDER BY ProductName", Conn)
'                    dtProducts.Load(cmd.ExecuteReader())
'                End Using
'                cmbSalesProduct.DataSource = dtProducts
'                cmbSalesProduct.DisplayMember = "ProductName"
'                cmbSalesProduct.ValueMember = "Product_ID"
'                cmbSalesProduct.SelectedIndex = -1
'            Catch
'                ' إذا مفيش جدول منتجات أو فشل، نتركه فارغ
'                cmbSalesProduct.DataSource = Nothing
'            Finally
'                Disconnect()
'            End Try

'            '' Suppliers (for purchases tab)
'            'Dim dtSup As DataTable = ReportsModule.GetSuppliersList()
'            'cmbPurchaseSupplier.DataSource = dtSup
'            'cmbPurchaseSupplier.DisplayMember = "Supplier_Name"
'            'cmbPurchaseSupplier.ValueMember = "SuppliersID"
'            'cmbPurchaseSupplier.SelectedIndex = -1

'            '' Supplier filter on suppliers tab
'            'cmbSupplierFilter.DataSource = dtSup.Copy()
'            'cmbSupplierFilter.DisplayMember = "Supplier_Name"
'            'cmbSupplierFilter.ValueMember = "SuppliersID"
'            'cmbSupplierFilter.SelectedIndex = -1

'        Catch ex As Exception
'            MessageBox.Show("خطأ أثناء تحميل القوائم: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ---------------------------
'    ' Prepare DataGridView defaults
'    ' ---------------------------
'    Private Sub PrepareDataGrids()
'        ' Generic settings for several DataGridViews
'        Dim grids = New DataGridView() {
'            dgvSalesSummary, dgvSalesInvoices, dgvInvoiceDetails, dgvSalesByProduct, dgvSalesByCustomer}
'        '''dgvPurchaseSummary
'        '''dgvPurchaseInvoices
'        '''dgvPurchaseDetails
'        '''dgvPurchaseDetails
'        '''dgvStockList
'        '''dgvSuppliersReport
'        '''dgvProfitReport
'        For Each g In grids
'            Try
'                g.ReadOnly = True
'                g.AllowUserToAddRows = False
'                g.AllowUserToDeleteRows = False
'                g.SelectionMode = DataGridViewSelectionMode.FullRowSelect
'                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
'            Catch
'            End Try
'        Next
'    End Sub

'    ' ---------------------------
'    ' Main Load Button (Sales)
'    ' ---------------------------
'    Private Sub btnSalesLoadAll_Click(sender As Object, e As EventArgs) Handles btnSalesLoadAll.Click
'        btnSalesLoadAll.Enabled = False
'        Try
'            LoadSalesSummary()
'            LoadSalesInvoices()
'            ' Also refresh by-product and by-customer if desired
'        Catch ex As Exception
'            MessageBox.Show("فشل التحميل: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            btnSalesLoadAll.Enabled = True
'        End Try
'    End Sub

'    ' ---------------------------
'    ' Load Sales Summary
'    ' ---------------------------
'    Private Sub LoadSalesSummary()
'        Try
'            Dim fromD As Date? = dtpSalesFrom.Value
'            Dim toD As Date? = dtpSalesTo.Value

'            Dim cid As Integer = 0
'            If cmbSalesCustomer.SelectedIndex >= 0 Then Integer.TryParse(Convert.ToString(cmbSalesCustomer.SelectedValue), cid)

'            Dim uid As Integer = 0
'            If cmbSalesUser.SelectedIndex >= 0 Then Integer.TryParse(Convert.ToString(cmbSalesUser.SelectedValue), uid)

'            Dim pay As String = If(String.IsNullOrWhiteSpace(cmbSalesPay.Text), "", cmbSalesPay.Text)

'            Dim dt As DataTable = ReportsModule.GetSalesReport(fromD, toD, cid, pay, uid, False)
'            dgvSalesSummary.DataSource = dt

'            ' حساب المجاميع وعرضها
'            Dim totalNet As Decimal = 0D
'            Dim totalRemaining As Decimal = 0D
'            For Each r As DataRow In dt.Rows
'                totalNet += If(IsDBNull(r("Net_Amount")), 0D, Convert.ToDecimal(r("Net_Amount")))
'                totalRemaining += If(IsDBNull(r("Remaining")), 0D, Convert.ToDecimal(r("Remaining")))
'            Next
'            lblSalesTotal.Text = $"صافي: {totalNet:N2} — متبقي: {totalRemaining:N2}"

'            If dt.Rows.Count = 0 Then
'                lblStatus.Text = "لا توجد بيانات للفترة المحددة."
'            Else
'                lblStatus.Text = $"تم تحميل {dt.Rows.Count} سطر."
'            End If

'        Catch ex As Exception
'            MessageBox.Show("خطأ أثناء تحميل ملخص المبيعات: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ---------------------------
'    ' Load Sales Invoices (Headers)
'    ' ---------------------------
'    Private Sub LoadSalesInvoices()
'        Try
'            Dim fromD As Date? = dtpSalesFrom.Value
'            Dim toD As Date? = dtpSalesTo.Value
'            Dim cid As Integer = 0
'            If cmbSalesCustomer.SelectedIndex >= 0 Then Integer.TryParse(Convert.ToString(cmbSalesCustomer.SelectedValue), cid)
'            Dim uid As Integer = 0
'            If cmbSalesUser.SelectedIndex >= 0 Then Integer.TryParse(Convert.ToString(cmbSalesUser.SelectedValue), uid)
'            Dim pay As String = If(String.IsNullOrWhiteSpace(cmbSalesPay.Text), "", cmbSalesPay.Text)

'            Dim dt As DataTable = ReportsModule.GetSalesReport(fromD, toD, cid, pay, uid, False)
'            dgvSalesInvoices.DataSource = dt

'        Catch ex As Exception
'            MessageBox.Show("خطأ أثناء تحميل الفواتير: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ---------------------------
'    ' Open selected invoice (عرض الفاتورة) - btnOpenInvoice
'    ' ---------------------------
'    Private Sub btnOpenInvoice_Click(sender As Object, e As EventArgs) Handles btnOpenInvoice.Click
'        Try
'            If dgvSalesInvoices.SelectedRows.Count = 0 Then
'                MessageBox.Show("اختر فاتورة من القائمة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                Return
'            End If

'            Dim invID As Integer = Convert.ToInt32(dgvSalesInvoices.SelectedRows(0).Cells("Invoice_ID").Value)
'            ' يمكنك هنا فتح الفورم الخاص بعرض الفاتورة، أو استدعاء دالة طباعة
'            MessageBox.Show($"فتح الفاتورة رقم: {invID}", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information)

'            ' مثال: فتح نافذة جديدة لعرض تفاصيل
'            Dim dtDetails As DataTable = ReportsModule.GetSalesDetails(invID)
'            Using frm As New Form
'                frm.Text = $"تفاصيل الفاتورة {invID}"
'                Dim g As New DataGridView With {
'                    .Dock = DockStyle.Fill,
'                    .ReadOnly = True,
'                    .DataSource = dtDetails,
'                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
'                }
'                frm.Controls.Add(g)
'                frm.StartPosition = FormStartPosition.CenterParent
'                frm.Size = New Size(700, 400)
'                frm.ShowDialog()
'            End Using

'        Catch ex As Exception
'            MessageBox.Show("خطأ أثناء فتح الفاتورة: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ---------------------------
'    ' Invoice Details (by ID)
'    ' ---------------------------
'    Private Sub btnLoadInvoiceDetails_Click(sender As Object, e As EventArgs) Handles btnLoadInvoiceDetails.Click
'        Try
'            Dim id As Integer
'            If Integer.TryParse(txtInvoiceSearchID.Text.Trim(), id) AndAlso id > 0 Then
'                dgvInvoiceDetails.DataSource = ReportsModule.GetSalesDetails(id)
'                If dgvInvoiceDetails.Rows.Count = 0 Then lblStatus.Text = "لا توجد تفاصيل لهذه الفاتورة."
'            Else
'                MessageBox.Show("ادخل رقم فاتورة صحيح.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            End If
'        Catch ex As Exception
'            MessageBox.Show("خطأ أثناء تحميل تفاصيل الفاتورة: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ---------------------------
'    ' By Product
'    ' ---------------------------
'    Private Sub btnLoadByProduct_Click(sender As Object, e As EventArgs) Handles btnLoadByProduct.Click
'        Try
'            If cmbSalesProduct.SelectedIndex < 0 Then
'                MessageBox.Show("اختر صنف أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                Return
'            End If

'            Dim pid As Integer = Convert.ToInt32(cmbSalesProduct.SelectedValue)
'            Dim fromD As Date? = dtpSalesFrom.Value
'            Dim toD As Date? = dtpSalesTo.Value

'            ' نطلب البيانات مع includeDetails = True ثم نفلتر محلياً على Product_ID
'            Dim dtAll As DataTable = ReportsModule.GetSalesReport(fromD, toD, 0, "", 0, True)
'            If dtAll.Rows.Count = 0 Then
'                dgvSalesByProduct.DataSource = Nothing
'                lblStatus.Text = "لا توجد بيانات."
'                Return
'            End If

'            Dim dv As New DataView(dtAll)
'            dv.RowFilter = $"Product_ID = {pid}"
'            dgvSalesByProduct.DataSource = dv.ToTable()
'            lblStatus.Text = $"تم فتح تقرير المنتج: {cmbSalesProduct.Text}"

'        Catch ex As Exception
'            MessageBox.Show("خطأ أثناء تحميل تقرير المنتج: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ---------------------------
'    ' By Customer
'    ' ---------------------------
'    Private Sub btnLoadByCustomer_Click(sender As Object, e As EventArgs) Handles btnLoadByCustomer.Click
'        Try
'            If cmbSalesCustomer2.SelectedIndex < 0 Then
'                MessageBox.Show("اختر عميل أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                Return
'            End If

'            Dim cid As Integer = Convert.ToInt32(cmbSalesCustomer2.SelectedValue)
'            Dim fromD As Date? = dtpSalesFrom.Value
'            Dim toD As Date? = dtpSalesTo.Value

'            Dim dt As DataTable = ReportsModule.GetSalesReport(fromD, toD, cid, "", 0, True)
'            dgvSalesByCustomer.DataSource = dt
'            lblStatus.Text = $"تم عرض المبيعات للعميل: {cmbSalesCustomer2.Text}"

'        Catch ex As Exception
'            MessageBox.Show("خطأ أثناء تحميل تقرير العميل: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ---------------------------
'    ' EXPORT CSV helper (used for export button)
'    ' ---------------------------
'    Private Function ExportDataTableToCsv(dt As DataTable, filename As String) As Boolean
'        Try
'            Using sw As New StreamWriter(filename, False, Encoding.UTF8)
'                ' Header
'                Dim cols = dt.Columns.Cast(Of DataColumn)().Select(Function(c) c.ColumnName).ToArray()
'                sw.WriteLine(String.Join(","c, cols))

'                ' Rows
'                For Each r As DataRow In dt.Rows
'                    Dim fields = cols.Select(Function(c) EscapeCsv(Convert.ToString(r(c))))
'                    sw.WriteLine(String.Join(","c, fields))
'                Next
'            End Using
'            Return True
'        Catch ex As Exception
'            MessageBox.Show("فشل التصدير: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            Return False
'        End Try
'    End Function

'    Private Function EscapeCsv(value As String) As String
'        If value Is Nothing Then Return ""
'        Dim v = value.Replace("""", """""")
'        If v.Contains(",") OrElse v.Contains(vbCr) OrElse v.Contains(vbLf) Then
'            v = $"""{v}"""
'        End If
'        Return v
'    End Function

'    ' ---------------------------
'    ' Export button (exports current active grid)
'    ' ---------------------------
'    'Private Sub btnExportSales_Click(sender As Object, e As EventArgs) Handles btnExportSales.Click
'    '    Try
'    '        Dim activeGrid As DataGridView = GetActiveDataGridForExport()
'    '        If activeGrid Is Nothing OrElse activeGrid.DataSource Is Nothing Then
'    '            MessageBox.Show("لا يوجد جدول لتصديره الآن.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    '            Return
'    '        End If

'    '        Dim dt As DataTable = TryCast(activeGrid.DataSource, DataTable)
'    '        If dt Is Nothing Then
'    '            ' إذا مصدره BindingSource أو DataView
'    '            Dim bs = TryCast(activeGrid.DataSource, BindingSource)
'    '            If bs IsNot Nothing AndAlso TypeOf bs.DataSource Is DataTable Then
'    '                dt = CType(bs.DataSource, DataTable)
'    '            ElseIf TypeOf activeGrid.DataSource Is DataView Then
'    '                dt = CType(activeGrid.DataSource, DataView).ToTable()
'    '            Else
'    '                ' حاول تحويل الصفوف يدوياً
'    '                dt = New DataTable()
'    '                For Each c As DataGridViewColumn In activeGrid.Columns
'    '                    dt.Columns.Add(c.HeaderText)
'    '                Next
'    '                For Each r As DataGridViewRow In activeGrid.Rows
'    '                    If Not r.IsNewRow Then
'    '                        Dim row = dt.NewRow()
'    '                        For i = 0 To activeGrid.Columns.Count - 1
'    '                            row(i) = If(r.Cells(i).Value, DBNull.Value)
'    '                        Next
'    '                        dt.Rows.Add(row)
'    '                    End If
'    '                Next
'    '            End If
'    '        End If

'    '        Using sfd As New SaveFileDialog()
'    '            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
'    '            sfd.FileName = "report_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
'    '            If sfd.ShowDialog() = DialogResult.OK Then
'    '                If ExportDataTableToCsv(dt, sfd.FileName) Then
'    '                    MessageBox.Show("تم التصدير إلى: " & sfd.FileName, "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
'    '                    Try
'    '                        Process.Start(New ProcessStartInfo(sfd.FileName) With {.UseShellExecute = True})
'    '                    Catch
'    '                    End Try
'    '                End If
'    '            End If
'    '        End Using

'    '    Catch ex As Exception
'    '        MessageBox.Show("خطأ أثناء التصدير: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'    '    End Try
'    'End Sub

'    ' ---------------------------
'    ' Get currently active DataGridView for export (based on selected tab)
'    ' ---------------------------
'    Private Function GetActiveDataGridForExport() As DataGridView
'        ' المقارنة بالاسم بدل الكائن
'        If TabReports.SelectedTab.Name = "tpSales" Then

'            Select Case tabSalesMain.SelectedTab.Name

'                Case "tpSalesSummary"
'                    Return dgvSalesSummary

'                Case "tpSalesInvoices"
'                    Return dgvSalesInvoices

'                Case "tpSalesDetails"
'                    Return dgvInvoiceDetails

'                Case "tpSalesByProduct"
'                    Return dgvSalesByProduct

'                Case "tpSalesByCustomer"
'                    Return dgvSalesByCustomer

'            End Select
'            'ElseIf TabReports.SelectedTab Is tpPurchases Then
'            '    Select Case tabPurchasesMain.SelectedTab
'            '        Case tpPurchaseSummary
'            '            Return dgvPurchaseSummary
'            '        Case tpPurchaseInvoices
'            '            Return dgvPurchaseInvoices
'            '        Case tpPurchaseDetails
'            '            Return dgvPurchaseDetails
'            '    End Select
'            'ElseIf TabReports.SelectedTab Is tpStock Then
'            '    Return dgvStockList
'            'ElseIf TabReports.SelectedTab Is tpSuppliers Then
'            '    Return dgvSuppliersReport
'            'ElseIf TabReports.SelectedTab Is tpProfit Then
'            '    Return dgvProfitReport
'        End If

'        Return Nothing
'    End Function

'    ' ---------------------------
'    ' PURCHASES: Load All (purchase tab) - similar to sales
'    ' ---------------------------
'    'Private Sub btnPurchaseLoadAll_Click(sender As Object, e As EventArgs) Handles btnPurchaseLoadAll.Click
'    '    btnPurchaseLoadAll.Enabled = False
'    '    Try
'    '        LoadPurchaseSummary()
'    '        LoadPurchaseInvoices()
'    '    Catch ex As Exception
'    '        MessageBox.Show("فشل تحميل المشتريات: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'    '    Finally
'    '        btnPurchaseLoadAll.Enabled = True
'    '    End Try
'    'End Sub

'    Private Sub LoadPurchaseSummary()
'        'Try
'        '    Dim fromD As Date? = dtpPurFrom.Value
'        '    Dim toD As Date? = dtpPurTo.Value
'        '    Dim sid As Integer = 0
'        '    If cmbPurchaseSupplier.SelectedIndex >= 0 Then Integer.TryParse(Convert.ToString(cmbPurchaseSupplier.SelectedValue), sid)
'        '    Dim uid As Integer = 0
'        '    If cmbPurchaseUser.SelectedIndex >= 0 Then Integer.TryParse(Convert.ToString(cmbPurchaseUser.SelectedValue), uid)
'        '    Dim pay As String = If(String.IsNullOrWhiteSpace(cmbPurchasePay.Text), "", cmbPurchasePay.Text)

'        '    Dim dt As DataTable = ReportsModule.GetPurchaseReport(fromD, toD, sid, pay, uid, False)
'        '    dgvPurchaseSummary.DataSource = dt

'        '    If dt.Rows.Count = 0 Then lblStatus.Text = "لا توجد مشتريات للفترة المحددة." Else lblStatus.Text = $"تم تحميل {dt.Rows.Count} فاتورة مشتريات."

'        'Catch ex As Exception
'        '    MessageBox.Show("خطأ أثناء تحميل ملخص المشتريات: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        'End Try
'    End Sub

'    Private Sub LoadPurchaseInvoices()
'        'Try
'        '    Dim fromD As Date? = dtpPurFrom.Value
'        '    Dim toD As Date? = dtpPurTo.Value
'        '    Dim sid As Integer = 0
'        '    If cmbPurchaseSupplier.SelectedIndex >= 0 Then Integer.TryParse(Convert.ToString(cmbPurchaseSupplier.SelectedValue), sid)
'        '    Dim uid As Integer = 0
'        '    If cmbPurchaseUser.SelectedIndex >= 0 Then Integer.TryParse(Convert.ToString(cmbPurchaseUser.SelectedValue), uid)
'        '    Dim pay As String = If(String.IsNullOrWhiteSpace(cmbPurchasePay.Text), "", cmbPurchasePay.Text)

'        '    Dim dt As DataTable = ReportsModule.GetPurchaseReport(fromD, toD, sid, pay, uid, False)
'        '    dgvPurchaseInvoices.DataSource = dt
'        'Catch ex As Exception
'        '    MessageBox.Show("خطأ أثناء تحميل فواتير المشتريات: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        'End Try
'    End Sub

'    ' ---------------------------
'    ' STOCK: Load
'    ' ---------------------------
'    'Private Sub btnLoadStock_Click(sender As Object, e As EventArgs) Handles btnLoadStock.Click
'    '    'Try
'    '    '    Dim fromD As Date? = dtpStockFrom.Value
'    '    '    Dim toD As Date? = dtpStockTo.Value
'    '    '    Dim dt As DataTable = ReportsModule.GetStockMovement(fromD, toD)
'    '    '    dgvStockList.DataSource = dt
'    '    '    lblStatus.Text = $"تم تحميل حركة المخزون ({dt.Rows.Count} صنف)."
'    '    'Catch ex As Exception
'    '    '    MessageBox.Show("خطأ أثناء تحميل المخزون: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'    '    'End Try
'    'End Sub

'    ' ---------------------------
'    ' SUPPLIERS: Load by supplier
'    ' ---------------------------
'    'Private Sub btnLoadSupplier_Click(sender As Object, e As EventArgs) Handles btnLoadSupplier.Click
'    '    Try
'    '        If cmbSupplierFilter.SelectedIndex < 0 Then
'    '            MessageBox.Show("اختر مورداً أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    '            Return
'    '        End If

'    '        Dim sid As Integer = Convert.ToInt32(cmbSupplierFilter.SelectedValue)
'    '        Dim dt As DataTable = ReportsModule.GetSupplierBalance(sid)
'    '        dgvSuppliersReport.DataSource = dt
'    '        lblStatus.Text = $"تم تحميل تقرير المورد: {cmbSupplierFilter.Text}"
'    '    Catch ex As Exception
'    '        MessageBox.Show("خطأ أثناء تحميل تقرير المورد: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'    '    End Try
'    'End Sub

'    ' ---------------------------
'    ' PROFIT: Load
'    ' ---------------------------
'    'Private Sub btnLoadProfit_Click(sender As Object, e As EventArgs) Handles btnLoadProfit.Click
'    '    Try
'    '        Dim fromD As Date? = dtpProfitFrom.Value
'    '        Dim toD As Date? = dtpProfitTo.Value
'    '        Dim dt As DataTable = ReportsModule.GetProfit(fromD, toD)
'    '        dgvProfitReport.DataSource = dt
'    '        If dt.Rows.Count > 0 Then
'    '            Dim net As Decimal = If(IsDBNull(dt.Rows(0)("NetProfit")), 0D, Convert.ToDecimal(dt.Rows(0)("NetProfit")))
'    '            lblProfitTotal.Text = $"صافي الربح: {net:N2}"
'    '        Else
'    '            lblProfitTotal.Text = "صافي الربح: 0.00"
'    '        End If
'    '        lblStatus.Text = "تم تحميل تقرير الأرباح."
'    '    Catch ex As Exception
'    '        MessageBox.Show("خطأ أثناء تحميل تقرير الأرباح: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'    '    End Try
'    'End Sub

'    ' ---------------------------
'    ' Purchase: load details by ID (optional)
'    ' ---------------------------
'    'Private Sub btnLoadPurchaseDetails_Click(sender As Object, e As EventArgs) Handles btnLoadPurchaseDetails.Click
'    '    Try
'    '        Dim id As Integer
'    '        If Integer.TryParse(txtPurchaseSearchID.Text.Trim(), id) AndAlso id > 0 Then
'    '            dgvPurchaseDetails.DataSource = ReportsModule.GetPurchaseDetails(id)
'    '        Else
'    '            MessageBox.Show("ادخل رقم فاتورة مشتريات صحيح.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    '        End If
'    '    Catch ex As Exception
'    '        MessageBox.Show("خطأ أثناء تحميل تفاصيل مشتريات: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'    '    End Try
'    'End Sub

'    ' ---------------------------
'    ' Utilities: Disconnect if form closing (safety)
'    ' ---------------------------
'    Private Sub FormReports_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
'        Try
'            Disconnect()
'        Catch
'        End Try
'    End Sub

'End Class
' ==============================
' Reports.vb (Back-End Logic)
' يعتمد بالكامل على ReportsModule
' ==============================
'Imports System.Data.SqlClient
'Imports DevExpress.XtraEditors
'Imports DevExpress.XtraGrid.Views.Grid
'Imports DevExpress.XtraGrid
'Imports DevExpress.XtraEditors.Controls

'Public Class Reports

'    ' ==========================================
'    ' 1. Form Load & Setup
'    ' ==========================================
'    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Try
'            ' إعداد التواريخ الافتراضية (آخر 30 يوم)
'            SetDefaultDates(deSalesFrom, deSalesTo)
'            SetDefaultDates(dePurFrom, dePurTo)
'            SetDefaultDates(deStockFrom, deStockTo)
'            SetDefaultDates(deProfitFrom, deProfitTo)

'            ' تحميل القوائم (LookUpEdits)
'            LoadLookups()

'            ' تحسين شكل الجريد (Grid Views Styling)
'            SetupGridView(gvSales)
'            SetupGridView(gvPurchases)
'            SetupGridView(gvStock)
'            SetupGridView(gvProfit)

'        Catch ex As Exception
'            XtraMessageBox.Show("حدث خطأ أثناء تحميل الفورم: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    Private Sub SetDefaultDates(fromDt As DateEdit, toDt As DateEdit)
'        toDt.EditValue = DateTime.Now
'        fromDt.EditValue = DateTime.Now.AddDays(-30)
'    End Sub

'    Private Sub LoadLookups()
'        ' 1. Customers
'        SetupLookUpEdit(lkeSalesCustomer, ReportsModule.GetCustomersList(), "CustomerName", "CustomerID")

'        ' 2. Suppliers
'        SetupLookUpEdit(lkePurSupplier, ReportsModule.GetSuppliersList(), "Supplier_Name", "SuppliersID")

'        ' 3. Users
'        Dim dtUsers = ReportsModule.GetUsersList()
'        SetupLookUpEdit(lkeSalesUser, dtUsers, "User_Name", "User_ID")
'        SetupLookUpEdit(lkePurUser, dtUsers.Copy(), "User_Name", "User_ID") ' نسخ الجدول لاستخدامه مرة أخرى

'        ' 4. Payment Methods
'        Dim dtPay = ReportsModule.GetPaymentMethodsList()
'        SetupLookUpEdit(lkeSalesPay, dtPay, "Payment_Method", "Payment_Method")
'        SetupLookUpEdit(lkePurPay, dtPay.Copy(), "Payment_Method", "Payment_Method")
'    End Sub

'    ' دالة مساعدة لتهيئة الـ LookUpEdit بشكل احترافي
'    Private Sub SetupLookUpEdit(lke As LookUpEdit, dt As DataTable, displayMember As String, valueMember As String)
'        lke.Properties.DataSource = dt
'        lke.Properties.DisplayMember = displayMember
'        lke.Properties.ValueMember = valueMember

'        ' إضافة زر "X" لمسح الاختيار
'        lke.Properties.Buttons.Add(New EditorButton(ButtonPredefines.Delete))
'        lke.Properties.NullText = "الكل" ' النص عند عدم الاختيار
'        lke.Properties.SearchMode = SearchMode.AutoSuggest

'        ' Auto width for columns
'        lke.Properties.BestFitMode = BestFitMode.BestFitResizePopup
'    End Sub

'    ' مسح الاختيار عند الضغط على زر الحذف في القائمة
'    Private Sub LookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles lkeSalesCustomer.ButtonClick, lkeSalesUser.ButtonClick, lkeSalesPay.ButtonClick, lkePurSupplier.ButtonClick
'        If e.Button.Kind = ButtonPredefines.Delete Then
'            CType(sender, LookUpEdit).EditValue = Nothing
'        End If
'    End Sub

'    ' تنسيق الجريد وإظهار مجاميع الفوتر
'    Private Sub SetupGridView(gv As GridView)
'        gv.OptionsBehavior.Editable = False
'        gv.OptionsView.ShowFooter = True ' إظهار الفوتر للحساب
'        gv.OptionsView.ShowGroupPanel = False ' إخفاء بنل التجميع العلوي (اختياري)
'        gv.OptionsView.EnableAppearanceEvenRow = True ' تلوين الأسطر

'        ' تفعيل البحث التلقائي
'        gv.OptionsFind.AlwaysVisible = True
'    End Sub

'    ' ==========================================
'    ' 2. Sales Report Logic
'    ' ==========================================
'    Private Sub btnSalesSearch_Click(sender As Object, e As EventArgs) Handles btnSalesSearch.Click
'        Try
'            Dim fromD As Date? = If(IsDBNull(deSalesFrom.EditValue), Nothing, CType(deSalesFrom.EditValue, Date?))
'            Dim toD As Date? = If(IsDBNull(deSalesTo.EditValue), Nothing, CType(deSalesTo.EditValue, Date?))

'            Dim custID As Integer = If(lkeSalesCustomer.EditValue Is Nothing, 0, Convert.ToInt32(lkeSalesCustomer.EditValue))
'            Dim userID As Integer = If(lkeSalesUser.EditValue Is Nothing, 0, Convert.ToInt32(lkeSalesUser.EditValue))
'            Dim payMethod As String = If(lkeSalesPay.EditValue Is Nothing, "", lkeSalesPay.EditValue.ToString())

'            ' استدعاء الموديول
'            Dim dt As DataTable = ReportsModule.GetSalesReport(fromD, toD, custID, payMethod, userID, False)
'            gcSales.DataSource = dt

'            ' إضافة تجميع تلقائي للأعمدة الرقمية إذا لم تكن موجودة
'            AddSummaryColumn(gvSales, "Total_Amount")
'            AddSummaryColumn(gvSales, "Net_Amount")
'            AddSummaryColumn(gvSales, "Remaining")

'        Catch ex As Exception
'            XtraMessageBox.Show("خطأ في جلب المبيعات: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ==========================================
'    ' 3. Purchases Report Logic
'    ' ==========================================
'    Private Sub btnPurSearch_Click(sender As Object, e As EventArgs) Handles btnPurSearch.Click
'        Try
'            Dim fromD As Date? = If(IsDBNull(dePurFrom.EditValue), Nothing, CType(dePurFrom.EditValue, Date?))
'            Dim toD As Date? = If(IsDBNull(dePurTo.EditValue), Nothing, CType(dePurTo.EditValue, Date?))

'            Dim suppID As Integer = If(lkePurSupplier.EditValue Is Nothing, 0, Convert.ToInt32(lkePurSupplier.EditValue))
'            ' يمكن إضافة يوزر وطريقة دفع للمشتريات أيضاً إذا أضفت الأدوات في الديزاين

'            Dim dt As DataTable = ReportsModule.GetPurchaseReport(fromD, toD, suppID, "", 0, False)
'            gcPurchases.DataSource = dt

'            AddSummaryColumn(gvPurchases, "Total_Amount")
'            AddSummaryColumn(gvPurchases, "Net_Amount")
'            AddSummaryColumn(gvPurchases, "Remaining")

'        Catch ex As Exception
'            XtraMessageBox.Show("خطأ في جلب المشتريات: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' ==========================================
'    ' 4. Stock & Profit Logic
'    ' ==========================================
'    Private Sub btnStockSearch_Click(sender As Object, e As EventArgs) Handles btnStockSearch.Click
'        Try
'            Dim fromD As Date? = If(IsDBNull(deStockFrom.EditValue), Nothing, CType(deStockFrom.EditValue, Date?))
'            Dim toD As Date? = If(IsDBNull(deStockTo.EditValue), Nothing, CType(deStockTo.EditValue, Date?))

'            Dim dt As DataTable = ReportsModule.GetStockMovement(fromD, toD)
'            gcStock.DataSource = dt

'            AddSummaryColumn(gvStock, "TotalSold")
'            AddSummaryColumn(gvStock, "Quantity_OnHand")
'        Catch ex As Exception
'            XtraMessageBox.Show(ex.Message)
'        End Try
'    End Sub

'    Private Sub btnProfitSearch_Click(sender As Object, e As EventArgs) Handles btnProfitSearch.Click
'        Try
'            Dim fromD As Date? = If(IsDBNull(deProfitFrom.EditValue), Nothing, CType(deProfitFrom.EditValue, Date?))
'            Dim toD As Date? = If(IsDBNull(deProfitTo.EditValue), Nothing, CType(deProfitTo.EditValue, Date?))

'            Dim dt As DataTable = ReportsModule.GetProfit(fromD, toD)
'            gcProfit.DataSource = dt
'        Catch ex As Exception
'            XtraMessageBox.Show(ex.Message)
'        End Try
'    End Sub

'    ' ==========================================
'    ' 5. Shared Helpers (Export & Print & Summary)
'    ' ==========================================

'    ' إضافة مجموع (Sum) أسفل العمود تلقائياً
'    Private Sub AddSummaryColumn(view As GridView, fieldName As String)
'        If view.Columns(fieldName) IsNot Nothing AndAlso view.Columns(fieldName).Summary.Count = 0 Then
'            view.Columns(fieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, fieldName, "{0:N2}")
'        End If
'    End Sub

'    ' زر الطباعة العام (اربط كل أزرار الطباعة هنا أو استدعها)
'    Private Sub PrintGrid(view As GridView)
'        If view.RowCount > 0 Then
'            view.ShowRibbonPrintPreview()
'        Else
'            XtraMessageBox.Show("لا توجد بيانات للطباعة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'        End If
'    End Sub

'    ' زر التصدير العام
'    Private Sub ExportGrid(view As GridView)
'        If view.RowCount = 0 Then Return
'        Using sfd As New SaveFileDialog()
'            sfd.Filter = "Excel Files|*.xlsx"
'            If sfd.ShowDialog() = DialogResult.OK Then
'                view.ExportToXlsx(sfd.FileName)
'                If XtraMessageBox.Show("تم التصدير بنجاح. هل تريد فتح الملف؟", "تصدير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
'                    Process.Start(New ProcessStartInfo(sfd.FileName) With {.UseShellExecute = True})
'                End If
'            End If
'        End Using
'    End Sub

'    ' Events Handlers for Print/Export Buttons
'    Private Sub btnSalesPrint_Click(sender As Object, e As EventArgs) Handles btnSalesPrint.Click
'        PrintGrid(gvSales)
'    End Sub

'    Private Sub btnSalesExport_Click(sender As Object, e As EventArgs) Handles btnSalesExport.Click
'        ExportGrid(gvSales)
'    End Sub

'    ' يمكنك إضافة الأحداث لباقي الأزرار بنفس الطريقة (Purchases, Stock...)

'End Class

Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Security.Cryptography.Xml
Imports Org.BouncyCastle.Asn1.X9

Public Class Reports
    Dim x, y As Integer
    Dim newpoint As New Point
    Private originalSalesTable As DataTable = Nothing
    Private originalPurchaseTable As DataTable = Nothing
    Private status_show_p As Boolean = False

    Private Sub ReportsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateDateTime()
        Timer1.Interval = 1000
        Timer1.Enabled = True
        LoadCustomers()
        LoadSuppliers()
        LoadUsers()
        LoadPaymentMethods()
        SetupDataGridViewSales(dgvSales)
        SetupDataGridViewSales(dgvInvoiceDetails)
        SetupDataGridViewSales(dgvInvoiceDetailsPurchase)
        SetupDataGridViewSales(dgv_balance_download)
        SetupDataGridViewSales(dgvPurchase)
        ' [FIX] تفعيل DoubleBuffered على شبكات التقارير لتقليل الـ Flickering
        EnableDoubleBuffer(dgvSales)
        EnableDoubleBuffer(dgvInvoiceDetails)
        EnableDoubleBuffer(dgvInvoiceDetailsPurchase)
        EnableDoubleBuffer(dgv_balance_download)
        EnableDoubleBuffer(dgvPurchase)
        LoadAllInvoices()
        LoadAllInvoicesPurchase()
        loadlogininfo()
        LoadAllBalancedownload()
        Load_most_sale()
        LoadNumericColumns(dgvSales, cboColumns)
        TabReports.SelectedIndex = 5
        txtCopies.Text = 1
        chkSalesDate.Checked = True
        chkPurchaseDate.Checked = True
    End Sub
    Private Sub cboColumns_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
) Handles cboColumns.SelectedIndexChanged

        If cboColumns.SelectedIndex = -1 Then
            txt_sum_col.Text = ""
            Return
        End If

        Dim colName As String = cboColumns.SelectedValue.ToString()
        Dim sumValue As Decimal = GetColumnSum(dgvSales, colName)

        txt_sum_col.Text = sumValue.ToString("N2")



    End Sub

    Public Sub LoadNumericColumns(
    dgv As DataGridView,
    cbo As ComboBox)

        cbo.DataSource = Nothing

        Dim dt As New DataTable()
        dt.Columns.Add("Text")   ' اللي هيظهر
        dt.Columns.Add("Value")  ' الاسم الحقيقي للعمود

        For Each col As DataGridViewColumn In dgv.Columns
            If col.ValueType Is GetType(Integer) _
            OrElse col.ValueType Is GetType(Decimal) _
            OrElse col.ValueType Is GetType(Double) _
            OrElse col.ValueType Is GetType(Long) Then

                dt.Rows.Add(col.HeaderText, col.Name)
            End If
        Next

        cbo.DisplayMember = "Text"
        cbo.ValueMember = "Value"
        cbo.DataSource = dt

        cbo.SelectedIndex = -1

    End Sub
    Public Function GetColumnSum(
    dgv As DataGridView,
    columnName As String
) As Decimal

        Dim total As Decimal = 0

        If Not dgv.Columns.Contains(columnName) Then
            Return 0
        End If

        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow AndAlso
           row.Cells(columnName).Value IsNot Nothing AndAlso
           IsNumeric(row.Cells(columnName).Value) Then

                total += Convert.ToDecimal(row.Cells(columnName).Value)
            End If
        Next

        Return total
    End Function

    Private Sub UpdateDateTime()

        Dim now As DateTime = DateTime.Now
        Dim arCulture As New CultureInfo("ar-EG")

        Dim timeText As String = now.ToString("tt hh:mm:ss", arCulture)
        Dim dayName As String = now.ToString("dddd", arCulture)
        Dim dayNumber As String = now.ToString("d", arCulture)
        Dim monthName As String = now.ToString("MMMM", arCulture)
        Dim yearNumber As String = now.ToString("yyyy", arCulture)

        Dim dateText As String = $"{dayName} ، {dayNumber} {monthName} {yearNumber} م"

        lblTime.Text = timeText
        lblDate.Text = dateText

    End Sub


    Private Sub SetupDataGridViewSales(ByVal dgv As DataGridView)
        dgv.AllowUserToAddRows = False
        'dgv.AllowUser = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False

        Dim darkBackground As Color = Color.FromArgb(30, 30, 30)
        Dim darkRow As Color = Color.FromArgb(45, 45, 45)
        Dim darkAltRow As Color = Color.FromArgb(55, 55, 55)
        Dim darkHeader As Color = Color.FromArgb(64, 64, 64)
        Dim highlightColor As Color = Color.FromArgb(0, 122, 204)
        Dim textColor As Color = Color.Gainsboro

        dgv.BackgroundColor = darkBackground
        dgv.RowsDefaultCellStyle.BackColor = darkRow
        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAltRow
        dgv.DefaultCellStyle.ForeColor = textColor
        dgv.GridColor = Color.FromArgb(80, 80, 80)

        With dgv

            '    .Columns.Clear()
            '.Columns("Invoice_ID").HeaderText = "كود الفاتورة"
            '.Columns("Invoice_Date").HeaderText = "تاريخ الفاتورة"
            '.Columns("CustomerName").HeaderText = "اسم العميل"
            '.Columns("Total_Amount").HeaderText = "اجمالي الفاتورة"
            '.Columns("Discount_Value").HeaderText = "الخصم"
            '.Columns("Net_Amount").HeaderText = "الصافي"
            '.Columns("Amount_Paid").HeaderText = "المدفوع"
            '.Columns("Remaining").HeaderText = "المتبقي"
            '.Columns("Payment_Method").HeaderText = "طريقه الدفع"
            '.Columns("User_Name").HeaderText = "اسم المستخدم"
            '.Columns("Product_ID").HeaderText = "ID المنتج"
            '.Columns("Product_Name").HeaderText = "اسم المنتج"
            '.Columns("Quantity_Sold").HeaderText = "الكمية الاساسية"
            '.Columns("Sale_Price_Per_Unit").HeaderText = "سعر البيع"
            '.Columns("Total_Line_Amount").HeaderText = "اجمالي Line"


            '    .Columns("ColProductID").Visible = False
            '    .Columns("ColUnitID").Visible = False
            '    .Columns("ColFactor").Visible = False

            '    Dim btnCol As New DataGridViewButtonColumn()
            '    btnCol.HeaderText = "حذف"
            '    btnCol.Text = "❌"
            '    btnCol.Name = "ColDelete"
            '    btnCol.UseColumnTextForButtonValue = True
            '    .Columns.Add(btnCol)

            '.Columns("ColProductName").Width = 230
            '    .Columns("ColQuantity").Width = 160

            '    .Columns("ColPrice").DefaultCellStyle.Format = "N2"
            '    .Columns("ColTotal").DefaultCellStyle.Format = "N2"

            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            'dgv.RowTemplate.Height = 40
            'dgv.ColumnHeadersHeight = 80

            dgv.ColumnHeadersDefaultCellStyle.BackColor = darkHeader
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            dgv.DefaultCellStyle.SelectionBackColor = highlightColor
            dgv.DefaultCellStyle.SelectionForeColor = Color.White
            dgv.DefaultCellStyle.Font = New Font("Segoe UI", 12.0!)

            dgv.RowHeadersVisible = False
            dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

        End With

    End Sub
    Private Sub LoadCustomers()
        Dim dt = ReportsModule.GetCustomersList()
        cboSalesCustomer.DataSource = dt
        cboSalesCustomer.DisplayMember = "CustomerName"
        cboSalesCustomer.ValueMember = "CustomerID"
        cboSalesCustomer.SelectedIndex = -1
    End Sub

    Private Sub LoadSuppliers()
        cboPurchaseSupplier.DataSource = Nothing
        cboPurchaseSupplier.Items.Clear()
        Dim dt = ReportsModule.GetSuppliersList()
        cboPurchaseSupplier.DataSource = dt
        cboPurchaseSupplier.DisplayMember = "SuppliersName"
        cboPurchaseSupplier.ValueMember = "SuppliersID"
        cboPurchaseSupplier.SelectedIndex = -1
    End Sub

    Private Sub LoadUsers()
        Dim dt = ReportsModule.GetUsersList()

        cboSalesUser.DataSource = dt.Copy()
        cboSalesUser.DisplayMember = "User_Name"
        cboSalesUser.ValueMember = "User_ID"
        cboSalesUser.SelectedIndex = -1

        cboPurchaseUser.DataSource = dt.Copy()
        cboPurchaseUser.DisplayMember = "User_Name"
        cboPurchaseUser.ValueMember = "User_ID"
        cboPurchaseUser.SelectedIndex = -1
    End Sub

    Private Sub LoadPaymentMethods()
        Dim dt = ReportsModule.GetPaymentMethodsList()
        cboSalesPay.DataSource = dt.Copy()
        cboSalesPay.DisplayMember = "Payment_Method"
        cboSalesPay.SelectedIndex = -1

        cboPurchasePay.DataSource = dt.Copy()
        cboPurchasePay.DisplayMember = "Payment_Method"
        cboPurchasePay.SelectedIndex = -1
    End Sub

    ' ========================
    '     زر بحث المبيعات
    ' ========================
    Public Sub btnSearchSales_Click(sender As Object, e As EventArgs) Handles btnSearchSales.Click

        Dim f As Date? = If(chkSalesDate.Checked, dtSalesFrom.Value.Date, Nothing)
        Dim t As Date? = If(chkSalesDate.Checked, dtSalesTo.Value.Date, Nothing)

        Dim cust As Integer? = Nothing
        If cboSalesCustomer.SelectedIndex >= 0 Then
            cust = CInt(cboSalesCustomer.SelectedValue)
        End If

        Dim usr As Integer? = Nothing
        If cboSalesUser.SelectedIndex >= 0 Then
            usr = CInt(cboSalesUser.SelectedValue)
        End If

        Dim pay As String = Nothing
        If cboSalesPay.SelectedIndex >= 0 Then
            pay = cboSalesPay.Text.Trim()
        End If

        Dim dt = ReportsModule.GetSalesReport(f, t, cust, pay, usr, chkSalesDetails.Checked)
        dgvSales.DataSource = dt
        LoadNumericColumns(dgvSales, cboColumns)

    End Sub


    ' ========================   
    '     زر بحث المشتريات
    ' ========================
    Private Sub btnSearchPurchase_Click(sender As Object, e As EventArgs) Handles btnSearchPurchase.Click
        'Dim f As Date? = If(chkPurchaseDate.Checked, dtPurchaseFrom.Value.Date, Nothing)
        'Dim t As Date? = If(chkPurchaseDate.Checked, dtPurchaseTo.Value.Date, Nothing)

        'Dim sup As Integer = If(cboPurchaseSupplier.SelectedIndex >= 0, CInt(cboPurchaseSupplier.SelectedValue), 0)
        'Dim usr As Integer = If(cboPurchaseUser.SelectedIndex >= 0, CInt(cboPurchaseUser.SelectedValue), 0)
        'Dim pay As String = If(cboPurchasePay.SelectedIndex >= 0, cboPurchasePay.Text, "")

        'Dim dt = ReportsModule.GetPurchaseReport2(f, t, sup, pay, usr, chkPurchaseDetails.Checked)
        'dgvPurchase.DataSource = dt


        'Dim f As Date? = If(chkSalesDate.Checked, dtSalesFrom.Value.Date, Nothing)
        'Dim t As Date? = If(chkSalesDate.Checked, dtSalesTo.Value.Date, Nothing)

        'Dim cust As Integer? = Nothing
        'If cboSalesCustomer.SelectedIndex >= 0 Then
        '    cust = CInt(cboSalesCustomer.SelectedValue)
        'End If

        'Dim usr As Integer? = Nothing
        'If cboSalesUser.SelectedIndex >= 0 Then
        '    usr = CInt(cboSalesUser.SelectedValue)
        'End If

        'Dim pay As String = Nothing
        'If cboSalesPay.SelectedIndex >= 0 Then
        '    pay = cboSalesPay.Text.Trim()
        'End If

        'Dim dt = ReportsModule.GetSalesReport(f, t, cust, pay, usr, chkSalesDetails.Checked)
        'dgvSales.DataSource = dt

        Dim f As Date? = If(chkPurchaseDate.Checked, dtPurchaseFrom.Value.Date, Nothing)
        Dim t As Date? = If(chkPurchaseDate.Checked, dtPurchaseTo.Value.Date, Nothing)

        Dim sup As Integer? = Nothing
        If cboPurchaseSupplier.SelectedIndex >= 0 Then
            sup = CInt(cboPurchaseSupplier.SelectedValue)
        End If

        Dim usr As Integer? = Nothing
        If cboPurchaseUser.SelectedIndex >= 0 Then
            usr = CInt(cboPurchaseUser.SelectedValue)
        End If

        Dim pay As String = Nothing
        If cboPurchasePay.SelectedIndex >= 0 Then
            pay = cboPurchasePay.Text.Trim()
        End If

        Dim dt = ReportsModule.GetPurchaseReport2(
    f,
    t,
    sup,
    pay,
    usr,
    chkPurchaseDetails.Checked
)

        dgvPurchase.DataSource = dt

    End Sub

    ' ========================
    '     زر بحث حركة المخزون
    ' ========================
    'Private Sub btnSearchStock_Click(sender As Object, e As EventArgs)
    '    Dim f As Date? = If(chkStockDate.Checked, dtStockFrom.Value.Date, Nothing)
    '    Dim t As Date? = If(chkStockDate.Checked, dtStockTo.Value.Date, Nothing)

    '    Dim dt = ReportsModule.GetStockMovement(f, t)
    '    dgvStock.DataSource = dt
    'End Sub

    ' ========================
    '     زر بحث الأرباح
    ' ========================
    Private Sub btnSearchProfit_Click(sender As Object, e As EventArgs) Handles btnSearchProfit.Click
        Dim f As Date? = If(chkProfitDate.Checked, dtProfitFrom.Value.Date, Nothing)
        Dim t As Date? = If(chkProfitDate.Checked, dtProfitTo.Value.Date, Nothing)

        Dim dt = ReportsModule.GetProfit(f, t)
        dgv_balance_download.DataSource = dt
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Close()
    End Sub

    Private Sub dgvSales_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvSales.DataBindingComplete
        Try
            With dgvSales

                Dim headers As New Dictionary(Of String, String) From {
                    {"Invoice_ID", "كود الفاتورة"},
                    {"Invoice_type", "نوع الفاتورة"},
                    {"Invoice_Date", "تاريخ الفاتورة"},
                    {"CustomerID", "id العميل"},
                    {"CustomerName", "اسم العميل"},
                    {"Net_Amount", "اجمالي الفاتورة"},
                    {"Discount_Value", "الخصم"},
                    {"Total_Amount", "الاجمالي بعد الخصم"},
                    {"Amount_Paid", "المدفوع"},
                    {"Remaining", "المتبقي"},
                    {"Payment_Method", "طريقه الدفع"},
                    {"User_ID", "ID المستخدم"},
                    {"User_Name", "اسم المستخدم"},
                    {"Product_ID", "ID المنتج"},
                    {"Product_Name", "اسم المنتج"},
                    {"Quantity_Sold", "الكمية الاساسية"},
                    {"Sale_Price_Per_Unit", "سعر البيع"},
                    {"Total_Line_Amount", "اجمالي Line"},
                    {"Total_Profit", "الربح الصافي"}
                }

                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next
            End With
            Dim sumValue As Decimal = GetColumnSum(dgvSales, "Total_Profit")
            txt_Total_Profit_dgv.Text = sumValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvSales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSales.CellDoubleClick
        Try
            ' تأكد إن المستخدم ضغط على صف صحيح
            If e.RowIndex < 0 Then Exit Sub

            ' الحصول على رقم الفاتورة
            Dim invoiceID As Integer = Convert.ToInt32(dgvSales.Rows(e.RowIndex).Cells("Invoice_ID").Value)

            ' استدعاء دالة تحميل تفاصيل الفاتورة
            LoadSelectedInvoice(invoiceID)

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء فتح تفاصيل الفاتورة: " & ex.Message)
        End Try
    End Sub
    Public Sub scannerInvoice_DataReceived(code As String)
        If TabReports.SelectedIndex = 5 Or TabReports.SelectedIndex = 2 Then
            Try
                Me.Invoke(Sub()
                              Dim invoiceID As Integer
                              If Integer.TryParse(code, invoiceID) Then
                                  LoadSelectedInvoice(invoiceID)
                              Else
                                  MessageBox.Show("رقم الفاتورة غير صالح: " & code, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                              End If
                          End Sub)
            Catch ex As Exception
                MessageBox.Show("حدث خطأ أثناء استقبال البيانات من السكانر: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    'Private Sub LoadInvoiceDetails(invoiceID As Integer)
    '    Try
    '        ' استرجاع بيانات تفاصيل الفاتورة من الموديول
    '        Dim dt As DataTable = ReportsModule.GetSalesDetails(invoiceID)

    '        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
    '            MessageBox.Show("لا توجد تفاصيل لهذه الفاتورة.")
    '            Exit Sub
    '        End If

    '        ' عرض التفاصيل
    '        dgvInvoiceDetails.DataSource = dt

    '        ' فتح التاب
    '        TabReports.SelectedTab = tabInvoiceDetails

    '        ' عمل فوكس
    '        dgvInvoiceDetails.Focus()

    '    Catch ex As Exception
    '        MessageBox.Show("خطأ أثناء تحميل تفاصيل الفاتورة: " & ex.Message)
    '    End Try
    'End Sub
    'Private Sub LoadAllInvoices()
    '    Dim dt As DataTable = ReportsModule.GetAllInvoices()
    '    dgvSales.DataSource = dt
    'End Sub'
    Private Sub LoadAllInvoices()
        Dim dt As DataTable = ReportsModule.GetAllInvoices()
        originalSalesTable = dt
        dgvSales.DataSource = originalSalesTable
    End Sub
    Private Sub LoadAllInvoicesPurchase()
        Dim dt As DataTable = ReportsModule.GetAllInvoicesPurchase()
        originalPurchaseTable = dt
        dgvPurchase.DataSource = originalPurchaseTable
    End Sub

    Private Sub LoadAllBalancedownload()
        Dim dt As DataTable = ReportsModule.GetAllBalancedownload()
        dgv_balance_download.DataSource = dt
    End Sub
    Private Sub Load_most_sale()
        Dim dt As DataTable = ReportsModule.GetAll_most_sale()
        dgvStock.DataSource = dt
    End Sub
    Private Sub loadlogininfo()

        Try
            Connect()

            Dim query As String = "
                SELECT User_Name 
                FROM Users_TBL 
                WHERE User_ID = @ID
            "

            Using cmd As New SqlCommand(query, Conn)

                cmd.Parameters.AddWithValue("@ID", Session.CurrentUserID)

                Dim User_Name As String = Convert.ToString(cmd.ExecuteScalar())
                lbl_user_name.Text = User_Name

            End Using

        Catch ex As Exception

            MessageBox.Show("حدث خطأ أثناء التحقق من المستحدم: " & ex.Message,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Finally
            Disconnect()
        End Try

    End Sub


    Public Sub LoadSelectedInvoice(ByVal invoiceID As Integer)
        Try

            ' ========== هـــيــدر ==========
            Dim dtHeader As DataTable = GetInvoiceHeader(invoiceID)
            If dtHeader Is Nothing OrElse dtHeader.Rows.Count = 0 Then
                MessageBox.Show("لا توجد تفاصيل لهذه الفاتورة.")
                Exit Sub
            End If
            If dtHeader.Rows.Count > 0 Then
                Dim R = dtHeader.Rows(0)

                txt_Invoice_type.Text = R("Invoice_type").ToString()
                txtInvID.Text = R("Invoice_ID").ToString()
                dtpInvDate.Value = CDate(R("Invoice_Date"))
                'txt_Customer_Code.Text = R("Customer_ID").ToString()
                txtCustomerName.Text = R("CustomerName").ToString()
                txtTotal.Text = R("Total_Amount").ToString()
                txtDiscount.Text = R("Discount_Value").ToString()
                txtNet.Text = R("Net_Amount").ToString()
                txtPaid.Text = R("Amount_Paid").ToString()
                txtRemaining.Text = R("Remaining").ToString()
                txt_Payment_Method.Text = R("Payment_Method").ToString()
                txtUser.Text = R("User_Name").ToString()
                txt_Total_Profit.Text = R("Total_Profit").ToString()
                Dim phone As String = String.Empty
                Dim CustomerCode As String = String.Empty
                Try
                    Connect() ' فتح الاتصال بقاعدة البيانات

                    Dim query As String = "SELECT PhoneNumber , CustomerCode FROM Customers WHERE CustomerID = @CustomerID"
                    Using cmd As New SqlCommand(query, Conn)
                        cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = R("Customer_ID").ToString()

                        'Dim obj = cmd.ExecuteScalar()
                        'If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                        '    phone = obj.ToString().Trim()
                        '    txtCustomerPhone.Text = phone
                        'End If
                        Using rd = cmd.ExecuteReader()
                            If rd.Read() Then
                                phone = If(IsDBNull(rd("PhoneNumber")), "", rd("PhoneNumber").ToString().Trim())
                                txtCustomerPhone.Text = phone
                                CustomerCode = If(IsDBNull(rd("CustomerCode")), "", rd("CustomerCode").ToString().Trim())
                                txt_Customer_Code.Text = CustomerCode
                            End If
                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show("حدث خطأ أثناء البحث عن رقم الهاتف: " & ex.Message)
                Finally
                    Disconnect() ' غلق الاتصال
                End Try
            End If

            ' ========== تفاصيل ==========
            Dim dtDetails As DataTable = GetInvoiceDetails(invoiceID)
            dgvInvoiceDetails.DataSource = dtDetails

            ' ========== فتح التــاب ==========
            TabReports.SelectedTab = tabInvoiceDetails
            dgvInvoiceDetails.Focus()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub LoadSelectedInvoicePurchase(ByVal invoiceID As Integer)
        Try

            ' ========== هـــيــدر ==========
            Dim dtHeaderPurchase As DataTable = GetInvoiceHeaderpurchases(invoiceID)
            If dtHeaderPurchase Is Nothing OrElse dtHeaderPurchase.Rows.Count = 0 Then
                MessageBox.Show("لا توجد تفاصيل لهذه الفاتورة.")
                Exit Sub
            End If
            If dtHeaderPurchase.Rows.Count > 0 Then
                Dim R = dtHeaderPurchase.Rows(0)
                txtSupplier_Num.Text = R("PhoneNumber").ToString()
                txtSupplierCode.Text = R("SuppliersCode").ToString()
                txt_Invoice_type2.Text = R("Purchase_type").ToString()
                txtInvID2.Text = R("Purchase_Id").ToString()
                dtpInvDate2.Value = CDate(R("Purchase_Date"))
                txtSupplierName.Text = R("SuppliersName").ToString()
                txtTotal2.Text = R("Total_Amount").ToString()
                txtDiscount2.Text = R("Discount_Value").ToString()
                txtNet2.Text = R("Net_Amount").ToString()
                txtPaid2.Text = R("Amount_Paid").ToString()
                txtRemaining2.Text = R("Remaining").ToString()
                txtUser2.Text = R("User_Name").ToString()
            End If
            ' ========== تفاصيل ==========
            Dim dtDetailsPurchase As DataTable = GetInvoiceDetailsPurchase(invoiceID)
            dgvInvoiceDetailsPurchase.DataSource = dtDetailsPurchase

            ' ========== فتح التــاب ==========
            TabReports.SelectedIndex = 1
            dgvPurchase.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lblDate_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown, lblTime.MouseDown, lblHeader.MouseDown, lblDate.MouseDown, lbl_user_name.MouseDown, Label14.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub dgvInvoiceDetails_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvInvoiceDetails.DataBindingComplete
        Try
            With dgvInvoiceDetails

                ' قاموس يحتوي على (اسم العمود → الاسم الظاهر)
                Dim headers As New Dictionary(Of String, String) From {
                    {"Invoice_ID", "كود الفاتورة"},
                    {"Product_Name", "اسم المنتج"},
                    {"Quantity_Sold", "الاجمالي بالوحدة الاساسية"},
                    {"ProductUnit_Name", "اسم الوحدة"},
                    {"Sale_Price_Per_Unit", "سعر البيع"},
                    {"Total_Line_Amount", "السعر الاجمالي للمنتج"},
                    {"Profit", "الربح الصافي"}
                }

                ' تعيين العناوين لو الأعمدة موجودة
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next
            End With
        Catch
        End Try
    End Sub

    Private Sub dgv_balance_download_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgv_balance_download.DataBindingComplete
        Try
            With dgv_balance_download
                Dim headers As New Dictionary(Of String, String) From {
                    {"LogID", "كود العملية"},
                    {"CustomerID", "ID العميل"},
                    {"CustomerCode", "كود العميل"},
                    {"CustomerName", "اسم العميل"},
                    {"OldBalance", "الرصيد قبل"},
                    {"PaidAmount", "المدفوع"},
                    {"NewBalance", "الرصيد بعد"},
                    {"Notes", "الملاحظات"},
                    {"UserName", "اسم المستخدم"},
                    {"ActionDate", "التاريخ"}
                }
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next
            End With
        Catch
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UpdateDateTime()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim copies As Integer = 1
        Integer.TryParse(txtCopies.Text.Trim(), copies)
        Dim CurrentIDV As Integer
        Integer.TryParse(txtInvID.Text.Trim(), CurrentIDV)
        PrintInvoiceFromDBProfessional(CurrentIDV, copies)
    End Sub

    Private Async Sub btnSendInvoiceWhatsApp_Click(sender As Object, e As EventArgs) Handles btnSendInvoiceWhatsApp.Click
        Dim phone As String = txtCustomerPhone.Text.Trim()
        Dim invoiceID As Integer = txtInvID.Text.Trim
        If String.IsNullOrWhiteSpace(phone) Then
            MessageBox.Show("رقم الهاتف غير صالح.")
            Return
        End If

        ' توليد نص الفاتورة
        Dim message As String = ReportsModule.GenerateInvoiceText(invoiceID)

        ' إرسال الرسالة
        Dim success As Boolean = Await WhatsAppAPI.SendText(phone, message)

        If success Then
            MessageBox.Show("✅ تم إرسال الفاتورة على واتساب بنجاح")
        Else
            MessageBox.Show("❌ فشل إرسال الفاتورة على واتساب")
        End If
    End Sub


    Private Sub dgvPurchase_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvPurchase.DataBindingComplete
        Try
            With dgvPurchase
                If dgvPurchase.Columns.Contains("purchases_Image") Then
                    With dgvPurchase.Columns("purchases_Image")
                        .HeaderText = "صورة الفاتورة"
                        .Visible = False
                    End With
                End If
                Dim headers As New Dictionary(Of String, String) From {
                    {"Purchase_Id", "كود الفاتورة"},
                    {"Purchase_type", "نوع الفاتورة"},
                    {"Purchase_Date", "تاريخ الفاتورة"},
                    {"SuppliersID", "id المورد"},
                    {"SuppliersName", "اسم المورد"},
                    {"Net_Amount", "المبلغ الصافي"},
                    {"Discount_Value", "قيمة الخصم"},
                    {"Total_Amount", "اجمالي الفاتوة"},
                    {"Amount_Paid", "المدفوع"},
                    {"Remaining", "المتبقي"},
                    {"Notes", "الملاحظات"},
                    {"User_ID", "ID المستخدم"},
                    {"Payment_Method", "طريقة الدفع"},
                    {"User_Name", "اسم المستخدم"}
                }

                ' تعيين العناوين لو الأعمدة موجودة
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next

            End With

        Catch ex As Exception
            ' تجاهل أي خطأ
        End Try
    End Sub

    Private Sub dgvPurchase_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchase.CellDoubleClick
        Try
            ' تأكد إن المستخدم ضغط على صف صحيح
            If e.RowIndex < 0 Then Exit Sub

            ' الحصول على رقم الفاتورة
            Dim invoiceID As Integer = Convert.ToInt32(dgvPurchase.Rows(e.RowIndex).Cells("Purchase_Id").Value)
            ' استدعاء دالة تحميل تفاصيل الفاتورة
            LoadSelectedInvoicePurchase(invoiceID)

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء فتح تفاصيل الفاتورة: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvInvoiceDetailsPurchase_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvInvoiceDetailsPurchase.DataBindingComplete
        Try
            With dgvInvoiceDetailsPurchase
                ' قاموس يحتوي على (اسم العمود → الاسم الظاهر)
                Dim headers As New Dictionary(Of String, String) From {
                    {"Purchase_Id", "كود الفاتورة"},
                    {"Product_Name", "اسم المنتج"},
                    {"Quantity_Sold", "الكمية"},
                    {"ProductUnit_Name", "اسم الوحدة"},
                    {"Purchase_Price_Per_Unit", "سعر الشراء"},
                    {"Total_Line_Amount", "الاجمالي"}
                }

                ' تعيين العناوين لو الأعمدة موجودة
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next

            End With

        Catch ex As Exception
            ' تجاهل أي خطأ
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        WindowState = FormWindowState.Minimized

    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        UpdateDateTime()
        Timer1.Interval = 1000
        Timer1.Enabled = True
        LoadCustomers()
        LoadSuppliers()
        LoadUsers()
        LoadPaymentMethods()
        SetupDataGridViewSales(dgvSales)
        SetupDataGridViewSales(dgvInvoiceDetails)
        SetupDataGridViewSales(dgvInvoiceDetailsPurchase)
        SetupDataGridViewSales(dgv_balance_download)
        SetupDataGridViewSales(dgvPurchase)
        LoadAllInvoices()
        LoadAllInvoicesPurchase()
        loadlogininfo()
        LoadAllBalancedownload()
        LoadNumericColumns(dgvSales, cboColumns)
        TabReports.SelectedIndex = 5
        txtCopies.Text = 1
        chkSalesDate.Checked = True
        chkPurchaseDate.Checked = True
    End Sub

    Private Sub dgvStock_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvStock.DataBindingComplete
        Try
            With dgvStock
                SetupDataGridView(dgvStock)
                ' قاموس يحتوي على (اسم العمود → الاسم الظاهر)
                Dim headers As New Dictionary(Of String, String) From {
                    {"Product_ID", "ID المنتج"},
                    {"Product_Name", "اسم المنتج"},
                    {"ProductUnit_Name", "اسم الوحدة"},
                    {"Sale_Price_Per_Unit", "سعر البيع"},
                    {"Total_Line_Amount", "اجمالي المبيعات"},
                    {"TotalQuantitySold", "الكمية المباعة"}
                }

                ' تعيين العناوين لو الأعمدة موجودة
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next

            End With

        Catch ex As Exception
            ' تجاهل أي خطأ
        End Try
    End Sub

    Private Sub lblDate_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove, lblTime.MouseMove, lblHeader.MouseMove, lblDate.MouseMove, lbl_user_name.MouseMove, Label14.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub btn_inv_delete_Click(sender As Object, e As EventArgs) Handles btn_inv_delete.Click
        Try
            If dgvSales.CurrentRow Is Nothing Then
                MessageBox.Show("من فضلك اختر فاتورة لحذفها أولاً")
                Return
            End If

            Dim inv_id As Integer = Convert.ToInt32(dgvSales.CurrentRow.Cells("Invoice_ID").Value)

            If MessageBox.Show("هل أنت متأكد من حذف هذه الفاتورة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            Connect()

            Dim queryDetails As String = "DELETE FROM SalesDetails WHERE Invoice_ID = @Invoice_ID"
            Using cmdDetails As New SqlCommand(queryDetails, Conn)
                cmdDetails.Parameters.AddWithValue("@Invoice_ID", inv_id)
                cmdDetails.ExecuteNonQuery()
            End Using

            Dim queryHeader As String = "DELETE FROM SalesHeader WHERE Invoice_ID = @Invoice_ID"
            Using cmdHeader As New SqlCommand(queryHeader, Conn)
                cmdHeader.Parameters.AddWithValue("@Invoice_ID", inv_id)
                cmdHeader.ExecuteNonQuery()
            End Using

            Disconnect()

            MessageBox.Show("🗑️ تم حذف الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadAllInvoices()
        Catch ex As Exception
            Disconnect()
            MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_inv_purchases_del_Click(sender As Object, e As EventArgs) Handles btn_inv_purchases_del.Click
        Try
            If dgvPurchase.CurrentRow Is Nothing Then
                MessageBox.Show("من فضلك اختر فاتورة لحذفها أولاً")
                Return
            End If

            Dim inv_id As Integer = Convert.ToInt32(dgvPurchase.CurrentRow.Cells("Purchase_Id").Value)

            If MessageBox.Show("هل أنت متأكد من حذف هذه الفاتورة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            Connect()

            Dim queryDetails As String = "DELETE FROM Purchase_Detalis WHERE Purchase_Id = @Invoice_ID"
            Using cmdDetails As New SqlCommand(queryDetails, Conn)
                cmdDetails.Parameters.AddWithValue("@Invoice_ID", inv_id)
                cmdDetails.ExecuteNonQuery()
            End Using

            Dim queryHeader As String = "DELETE FROM Purchase_Header WHERE Purchase_Id = @Invoice_ID"
            Using cmdHeader As New SqlCommand(queryHeader, Conn)
                cmdHeader.Parameters.AddWithValue("@Invoice_ID", inv_id)
                cmdHeader.ExecuteNonQuery()
            End Using


            Disconnect()

            MessageBox.Show("🗑️ تم حذف الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadAllInvoicesPurchase()
        Catch ex As Exception
            Disconnect()
            MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        End Try
    End Sub

    Private Async Sub btn_sand_supplier_Click(sender As Object, e As EventArgs) Handles btn_sand_supplier.Click
        Dim phone As String = txtSupplier_Num.Text.Trim()
        Dim invoiceID As Integer = txtInvID2.Text.Trim
        If String.IsNullOrWhiteSpace(phone) Then
            MessageBox.Show("رقم الهاتف غير صالح.")
            Return
        End If

        ' توليد نص الفاتورة
        Dim message As String = ReportsModule.GenerateInvoiceText2(invoiceID)

        ' إرسال الرسالة
        Dim success As Boolean = Await WhatsAppAPI.SendText(phone, message)

        If success Then
            MessageBox.Show("✅ تم إرسال الفاتورة على واتساب بنجاح")
        Else
            MessageBox.Show("❌ فشل إرسال الفاتورة على واتساب")
        End If
    End Sub

    Private Sub btn_purchases_print_Click(sender As Object, e As EventArgs) Handles btn_purchases_print.Click
        Dim copies As Integer = 1
        Integer.TryParse(txtCopies2.Text.Trim(), copies)
        Dim CurrentIDV As Integer
        Integer.TryParse(txtInvID.Text.Trim(), CurrentIDV)
        PrintInvoiceFromDBProfessional(CurrentIDV, copies)
    End Sub

    Private Async Sub btn_edit_sale_Click(sender As Object, e As EventArgs) Handles btn_edit_sale.Click

        Dim frm As Sales = Nothing
        Dim invoiceID As Integer = txtInvID.Text.Trim
        For Each f As Form In Application.OpenForms
            If TypeOf f Is Sales Then
                frm = CType(f, Sales)
            End If
        Next

        If frm Is Nothing Then
            frm = New Sales()
            frm.Show()
        End If

        frm.inv_id_edit = invoiceID
        frm.btn_Invoice_Edit.Visible = True
        Await frm.LoadInvoiceAsync(invoiceID)


    End Sub

    Private Sub btn_show_pirfit_Click(sender As Object, e As EventArgs) Handles btn_show_pirfit.Click
        If status_show_p = False Then
            status_show_p = True
            btn_show_pirfit.Image = My.Resources.show
        Else
            status_show_p = False
            btn_show_pirfit.Image = My.Resources.hidden

        End If
        If status_show_p Then
            txt_Total_Profit_dgv.Visible = True
            Label39.Visible = True
        Else
            txt_Total_Profit_dgv.Visible = False
            Label39.Visible = False
        End If
    End Sub

    Private Sub SetupDataGridView(ByVal dgv As DataGridView)

        dgv.AllowUserToAddRows = False
        'dgv.AllowUser = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False

        Dim darkBackground As Color = Color.FromArgb(30, 30, 30)
        Dim darkRow As Color = Color.FromArgb(45, 45, 45)
        Dim darkAltRow As Color = Color.FromArgb(55, 55, 55)
        Dim darkHeader As Color = Color.FromArgb(64, 64, 64)
        Dim highlightColor As Color = Color.FromArgb(0, 122, 204)
        Dim textColor As Color = Color.Gainsboro

        dgv.BackgroundColor = darkBackground
        dgv.RowsDefaultCellStyle.BackColor = darkRow
        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAltRow
        dgv.DefaultCellStyle.ForeColor = textColor
        dgv.GridColor = Color.FromArgb(80, 80, 80)

        With dgv

            '.Columns.Clear()
            '.Columns.Add("ColProductID", "ID المنتج")
            '.Columns.Add("ColProduct_Code", "كود المنتج")
            '.Columns.Add("ColProductName", "اسم المنتج")
            '.Columns.Add("ColUnitName", "الوحدة")
            '.Columns.Add("ColPrice", "سعر البيع")
            'Dim ColQtyMinus As New DataGridViewButtonColumn()
            'ColQtyMinus.HeaderText = ""
            'ColQtyMinus.Text = "➖"
            'ColQtyMinus.Name = "ColQtyMinus"
            'ColQtyMinus.Width = 5
            'ColQtyMinus.UseColumnTextForButtonValue = True
            '.Columns.Add(ColQtyMinus)
            '.Columns.Add("ColQuantity", "الكمية / الوزن")
            'Dim ColQtyPlus As New DataGridViewButtonColumn()
            'ColQtyPlus.HeaderText = ""
            'ColQtyPlus.Text = "➕"
            'ColQtyPlus.Name = "ColQtyPlus"
            'ColQtyPlus.Width = 5
            'ColQtyPlus.UseColumnTextForButtonValue = True
            '.Columns.Add(ColQtyPlus)
            '.Columns.Add("ColTotal", "الإجمالي")

            '.Columns.Add("ColUnitID", "UnitID")
            '.Columns.Add("ColFactor", "Factor")
            '.Columns.Add("ColProfit", "Profit")
            '.Columns.Add("LastNumScaleBarcode", "lastnum")

            '.Columns("ColProductID").Visible = False
            .Columns("Product_ID").Visible = False
            '.Columns("ColFactor").Visible = False
            '.Columns("ColProfit").Visible = False
            '.Columns("LastNumScaleBarcode").Visible = False

            'Dim btnCol As New DataGridViewButtonColumn()
            'btnCol.HeaderText = "حذف"
            'btnCol.Text = "❌"
            'btnCol.Name = "ColDelete"
            'btnCol.UseColumnTextForButtonValue = True
            '.Columns.Add(btnCol)

            '.Columns("ColProductName").Width = 230
            '.Columns("ColQuantity").Width = 160

            .Columns("Sale_Price_Per_Unit").DefaultCellStyle.Format = "N2"
            '.Columns("ColTotal").DefaultCellStyle.Format = "N2"
            .Columns("Product_ID").DisplayIndex = 0
            .Columns("Product_Name").DisplayIndex = 1
            .Columns("ProductUnit_Name").DisplayIndex = 2
            .Columns("Sale_Price_Per_Unit").DisplayIndex = 3
            .Columns("TotalQuantitySold").DisplayIndex = 4
            .Columns("Total_Line_Amount").DisplayIndex = 5

            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            'dgv.RowTemplate.Height = 32
            dgv.ColumnHeadersHeight = 60

            dgv.ColumnHeadersDefaultCellStyle.BackColor = darkHeader
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16.0!, FontStyle.Bold)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            dgv.DefaultCellStyle.SelectionBackColor = highlightColor
            dgv.DefaultCellStyle.SelectionForeColor = Color.White
            dgv.DefaultCellStyle.Font = New Font("Segoe UI", 14.0!)

            dgv.RowHeadersVisible = False
            dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

        End With

    End Sub





End Class
