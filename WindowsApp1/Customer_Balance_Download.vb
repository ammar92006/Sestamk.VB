Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports Guna.UI2.WinForms

Public Class Customer_Balance_Download

    Private _rawCustomersTable As DataTable = Nothing
    Private _selectedCustomerID As Integer = 0
    Private _selectedCustomerCode As String = ""
    Private _selectedCustomerName As String = ""
    Private _selectedCustomerBalance As Decimal = 0
    Private _selectedCustomerCreditLimit As Decimal = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Async Sub Customer_Balance_Download_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim drag As New FormDragHelper(Me, panelHeader)

            ' تطبيق الثيم العام
            ThemeManager.Instance.ApplyTheme(Me)
            ThemeHelper.ApplyDataGridViewTheme(dgvCustomers, ThemeManager.Instance.CurrentPalette)

            ' إعداد فلاتر البحث
            cmbFilterType.Items.Clear()
            cmbFilterType.Items.Add("جميع العملاء")
            cmbFilterType.Items.Add("العملاء المدينون فقط (عليهم مديونية)")
            cmbFilterType.Items.Add("العملاء الدائنون فقط (لهم رصيد)")
            cmbFilterType.SelectedIndex = 0

            Await LoadTreasuriesAsync()
            LoadCustomers()

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء فتح شاشة سداد الأرصدة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' تحميل الخزائن المتاحة
    ' =========================================================
    Private Async Function LoadTreasuriesAsync() As Task
        Try
            Dim dt As New DataTable()
            Using cn As SqlConnection = Await NewConnAsync()
                Const sql As String = "SELECT TreasuryID, TreasuryNameAr FROM Treasury WHERE IsActive = 1 AND IsDeleted = 0 ORDER BY TreasuryID;"
                Using da As New SqlDataAdapter(sql, cn)
                    Await Task.Run(Sub() da.Fill(dt))
                End Using
            End Using

            cmbTreasury.DataSource = dt
            cmbTreasury.DisplayMember = "TreasuryNameAr"
            cmbTreasury.ValueMember = "TreasuryID"

            Dim defTreasuryID As Integer = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)
            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing AndAlso ShiftSession.CurrentShift.TreasuryID.HasValue AndAlso ShiftSession.CurrentShift.TreasuryID.Value > 0 Then
                cmbTreasury.SelectedValue = ShiftSession.CurrentShift.TreasuryID.Value
            ElseIf defTreasuryID > 0 Then
                cmbTreasury.SelectedValue = defTreasuryID
            ElseIf cmbTreasury.Items.Count > 0 Then
                cmbTreasury.SelectedIndex = 0
            End If

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء تحميل بيانات الخزينة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' =========================================================
    ' تحميل العملاء وحساب المؤشرات
    ' =========================================================
    Private Sub LoadCustomers()
        Try
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Const sql As String = "
                    SELECT 
                        CustomerID,
                        CustomerCode,
                        CustomerName,
                        PhoneNumber,
                        Address,
                        CreditLimit,
                        CurrentBalance,
                        IsActive,
                        Notes,
                        CreatedAt
                    FROM Customers
                    ORDER BY CASE WHEN CurrentBalance < 0 THEN 0 ELSE 1 END, ABS(CurrentBalance) DESC, CustomerName;"

                Using da As New SqlDataAdapter(sql, conn)
                    _rawCustomersTable = New DataTable()
                    da.Fill(_rawCustomersTable)
                    ApplyFilter()
                End Using
            End Using

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء تحميل العملاء: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyFilter()
        If _rawCustomersTable Is Nothing Then Exit Sub

        Dim filterQuery As String = ""
        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")

        If Not String.IsNullOrEmpty(keyword) Then
            filterQuery = $"(CustomerName LIKE '%{keyword}%' OR CustomerCode LIKE '%{keyword}%' OR PhoneNumber LIKE '%{keyword}%' OR Address LIKE '%{keyword}%')"
        End If

        Select Case cmbFilterType.SelectedIndex
            Case 1 ' المدينون فقط (عليهم دين: رصيد سالب)
                Dim cond = "CurrentBalance < 0"
                filterQuery = If(String.IsNullOrEmpty(filterQuery), cond, $"{filterQuery} AND {cond}")
            Case 2 ' الدائنون فقط (لهم رصيد: موجب)
                Dim cond = "CurrentBalance > 0"
                filterQuery = If(String.IsNullOrEmpty(filterQuery), cond, $"{filterQuery} AND {cond}")
        End Select

        Dim dv As New DataView(_rawCustomersTable)
        dv.RowFilter = filterQuery
        dgvCustomers.DataSource = dv

        SetupGridColumns()
        UpdateKpis(dv)

        If dgvCustomers.Rows.Count > 0 Then
            dgvCustomers.Rows(0).Selected = True
            SelectCustomerRow(0)
        Else
            ClearSelectedCustomer()
        End If
    End Sub

    Private Sub SetupGridColumns()
        If dgvCustomers.Columns.Count = 0 Then Exit Sub

        If dgvCustomers.Columns.Contains("CustomerID") Then dgvCustomers.Columns("CustomerID").Visible = False
        If dgvCustomers.Columns.Contains("IsActive") Then dgvCustomers.Columns("IsActive").Visible = False
        If dgvCustomers.Columns.Contains("Notes") Then dgvCustomers.Columns("Notes").Visible = False
        If dgvCustomers.Columns.Contains("CreatedAt") Then dgvCustomers.Columns("CreatedAt").Visible = False

        If dgvCustomers.Columns.Contains("CustomerCode") Then
            dgvCustomers.Columns("CustomerCode").HeaderText = "كود العميل"
            dgvCustomers.Columns("CustomerCode").Width = 100
        End If

        If dgvCustomers.Columns.Contains("CustomerName") Then
            dgvCustomers.Columns("CustomerName").HeaderText = "اسم العميل"
            dgvCustomers.Columns("CustomerName").Width = 220
        End If

        If dgvCustomers.Columns.Contains("PhoneNumber") Then
            dgvCustomers.Columns("PhoneNumber").HeaderText = "رقم الهاتف"
            dgvCustomers.Columns("PhoneNumber").Width = 120
        End If

        If dgvCustomers.Columns.Contains("Address") Then
            dgvCustomers.Columns("Address").HeaderText = "العنوان"
            dgvCustomers.Columns("Address").Width = 160
        End If

        If dgvCustomers.Columns.Contains("CreditLimit") Then
            dgvCustomers.Columns("CreditLimit").HeaderText = "حد الائتمان"
            dgvCustomers.Columns("CreditLimit").DefaultCellStyle.Format = "N2"
            dgvCustomers.Columns("CreditLimit").Width = 110
        End If

        If dgvCustomers.Columns.Contains("CurrentBalance") Then
            dgvCustomers.Columns("CurrentBalance").HeaderText = "الرصيد الحالي"
            dgvCustomers.Columns("CurrentBalance").DefaultCellStyle.Format = "N2"
            dgvCustomers.Columns("CurrentBalance").Width = 130
        End If
    End Sub

    Private Sub UpdateKpis(dv As DataView)
        Dim totalDebt As Decimal = 0
        For Each r As DataRowView In dv
            Dim bal As Decimal = Convert.ToDecimal(r("CurrentBalance"))
            If bal < 0 Then
                totalDebt += Math.Abs(bal)
            End If
        Next
        lblTotalDebtKpi.Text = $"{totalDebt:N2} ج.م"
    End Sub

    Private Sub dgvCustomers_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCustomers.CellFormatting
        If dgvCustomers.Columns(e.ColumnIndex).Name = "CurrentBalance" AndAlso e.Value IsNot Nothing Then
            Dim bal As Decimal = 0
            If Decimal.TryParse(e.Value.ToString(), bal) Then
                If bal < 0 Then
                    e.CellStyle.ForeColor = Color.FromArgb(231, 76, 60) ' أحمر للمدين
                    e.CellStyle.Font = New Font(dgvCustomers.Font, FontStyle.Bold)
                ElseIf bal > 0 Then
                    e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96) ' أخضر للدائن
                    e.CellStyle.Font = New Font(dgvCustomers.Font, FontStyle.Bold)
                Else
                    e.CellStyle.ForeColor = Color.FromArgb(100, 110, 120)
                End If
            End If
        End If
    End Sub

    Private Sub dgvCustomers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCustomers.SelectionChanged
        If dgvCustomers.SelectedRows.Count > 0 Then
            SelectCustomerRow(dgvCustomers.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub SelectCustomerRow(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvCustomers.Rows.Count Then Exit Sub

        Dim row As DataGridViewRow = dgvCustomers.Rows(rowIndex)
        _selectedCustomerID = Convert.ToInt32(row.Cells("CustomerID").Value)
        _selectedCustomerCode = row.Cells("CustomerCode").Value?.ToString()
        _selectedCustomerName = row.Cells("CustomerName").Value?.ToString()
        _selectedCustomerBalance = Convert.ToDecimal(row.Cells("CurrentBalance").Value)
        _selectedCustomerCreditLimit = Convert.ToDecimal(row.Cells("CreditLimit").Value)

        Dim phone As String = row.Cells("PhoneNumber").Value?.ToString()

        lblCustomerName.Text = _selectedCustomerName
        lblCustomerPhone.Text = $"الكود: {_selectedCustomerCode}  |  الهاتف: {If(String.IsNullOrEmpty(phone), "---", phone)}"
        lblCreditLimitDisplay.Text = $"سقف الائتمان المسموح: {_selectedCustomerCreditLimit:N2} ج.م"

        If _selectedCustomerBalance < 0 Then
            lblBalanceDisplay.Text = $"{Math.Abs(_selectedCustomerBalance):N2} ج.م (مدين)"
            lblBalanceDisplay.ForeColor = Color.FromArgb(231, 76, 60)
            btnPayFullDebt.Visible = True
        ElseIf _selectedCustomerBalance > 0 Then
            lblBalanceDisplay.Text = $"{_selectedCustomerBalance:N2} ج.م (دائن)"
            lblBalanceDisplay.ForeColor = Color.FromArgb(39, 174, 96)
            btnPayFullDebt.Visible = False
        Else
            lblBalanceDisplay.Text = "0.00 ج.م (متزن)"
            lblBalanceDisplay.ForeColor = Color.FromArgb(100, 110, 120)
            btnPayFullDebt.Visible = False
        End If

        txtAmountPaid.Clear()
        txtNotes.Clear()
    End Sub

    Private Sub ClearSelectedCustomer()
        _selectedCustomerID = 0
        _selectedCustomerCode = ""
        _selectedCustomerName = ""
        _selectedCustomerBalance = 0
        _selectedCustomerCreditLimit = 0

        lblCustomerName.Text = "يرجى تحديد عميل من الجدول"
        lblCustomerPhone.Text = "الهاتف: ---  |  الكود: ---"
        lblBalanceDisplay.Text = "0.00 ج.م"
        lblBalanceDisplay.ForeColor = Color.Black
        lblCreditLimitDisplay.Text = "سقف الائتمان: 0.00 ج.م"
        btnPayFullDebt.Visible = False
        txtAmountPaid.Clear()
        txtNotes.Clear()
    End Sub

    ' سداد كامل الدين بنقرة واحدة
    Private Sub btnPayFullDebt_Click(sender As Object, e As EventArgs) Handles btnPayFullDebt.Click
        If _selectedCustomerBalance < 0 Then
            txtAmountPaid.Text = Math.Abs(_selectedCustomerBalance).ToString("N2")
            txtAmountPaid.Focus()
        End If
    End Sub

    ' تنفيذ عملية السداد وفتح فورم التأكيد
    Private Sub btnDoPayment_Click(sender As Object, e As EventArgs) Handles btnDoPayment.Click
        If _selectedCustomerID <= 0 Then
            SmartMessageBox.Show("يرجى اختيار العميل من القائمة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim payAmount As Decimal = 0
        If Not Decimal.TryParse(txtAmountPaid.Text.Trim(), payAmount) OrElse payAmount <= 0 Then
            SmartMessageBox.Show("يرجى إدخال مبلغ سداد صحيح أكبر من الصفر!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmountPaid.Focus()
            Exit Sub
        End If

        If cmbTreasury.SelectedValue Is Nothing Then
            SmartMessageBox.Show("يرجى اختيار الخزينة التي سيتم إيداع المبلغ فيها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTreasury.Focus()
            Exit Sub
        End If

        Dim targetTreasuryID As Integer = Convert.ToInt32(cmbTreasury.SelectedValue)
        Dim treasuryName As String = cmbTreasury.Text

        ' حساب الرصيد الجديد:
        ' إذا كان الرصيد سالباً (-500) وسدد 200 => يصبح -300
        ' إذا سدد 500 => يصبح 0
        Dim newBalance As Decimal = _selectedCustomerBalance + payAmount

        Using frmConfirm As New frmConfirmMessage()
            frmConfirm.CustomerID = _selectedCustomerID
            frmConfirm.CustomerCode = _selectedCustomerCode
            frmConfirm.CustomerName = _selectedCustomerName
            frmConfirm.BalanceBefore = _selectedCustomerBalance
            frmConfirm.AmountPaid = payAmount
            frmConfirm.BalanceAfter = newBalance
            frmConfirm.TargetTreasuryID = targetTreasuryID
            frmConfirm.TreasuryName = treasuryName
            frmConfirm.Notes = txtNotes.Text.Trim()

            If frmConfirm.ShowDialog(Me) = DialogResult.OK Then
                LoadCustomers()
            End If
        End Using
    End Sub

    ' فتح كشف حساب العميل مباشرة
    Private Sub btnOpenStatement_Click(sender As Object, e As EventArgs) Handles btnOpenStatement.Click
        If _selectedCustomerID <= 0 Then
            SmartMessageBox.Show("يرجى اختيار العميل أولاً لعرض كشف حسابه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim frmStatement As New FrmCustomerStatement()
            frmStatement.Show()
            If frmStatement.cmbCustomers.Items.Count > 0 Then
                frmStatement.cmbCustomers.SelectedValue = _selectedCustomerID
                frmStatement.btnSearch.PerformClick()
            End If
        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء فتح كشف الحساب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' تصدير إلى ملف إكسيل
    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvCustomers.Rows.Count = 0 Then
            SmartMessageBox.Show("لا توجد بيانات عملاء لتصديرها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "ملف إكسيل Excel (*.xlsx)|*.xlsx"
            sfd.FileName = $"أرصدة_العملاء_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                Using wb As New XLWorkbook()
                    Dim dtExport As New DataTable("CustomerBalances")
                    dtExport.Columns.Add("كود العميل")
                    dtExport.Columns.Add("اسم العميل")
                    dtExport.Columns.Add("رقم الهاتف")
                    dtExport.Columns.Add("العنوان")
                    dtExport.Columns.Add("حد الائتمان")
                    dtExport.Columns.Add("الرصيد الحالي")
                    dtExport.Columns.Add("حالة الحساب")

                    For Each row As DataGridViewRow In dgvCustomers.Rows
                        Dim bal As Decimal = Convert.ToDecimal(row.Cells("CurrentBalance").Value)
                        Dim statusStr As String = If(bal < 0, "مدين", If(bal > 0, "دائن", "متزن"))
                        dtExport.Rows.Add(
                            row.Cells("CustomerCode").Value?.ToString(),
                            row.Cells("CustomerName").Value?.ToString(),
                            row.Cells("PhoneNumber").Value?.ToString(),
                            row.Cells("Address").Value?.ToString(),
                            Convert.ToDecimal(row.Cells("CreditLimit").Value).ToString("N2"),
                            bal.ToString("N2"),
                            statusStr
                        )
                    Next

                    Dim ws = wb.Worksheets.Add("أرصدة العملاء")
                    ws.RightToLeft = True
                    ws.Cell(1, 1).Value = "تقرير أرصدة ومديونيات العملاء"
                    ws.Cell(1, 1).Style.Font.Bold = True
                    ws.Cell(1, 1).Style.Font.FontSize = 14
                    ws.Cell(2, 1).Value = $"تاريخ التصدير: {DateTime.Now:yyyy/MM/dd HH:mm}"

                    Dim table = ws.Cell(4, 1).InsertTable(dtExport, "CustomerBalances", True)
                    table.Theme = XLTableTheme.TableStyleMedium9
                    ws.Columns().AdjustToContents()

                    wb.SaveAs(sfd.FileName)
                End Using

                SmartMessageBox.Show("✅ تم تصدير بيانات وأرصدة العملاء إلى Excel بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Process.Start("explorer.exe", Path.GetDirectoryName(sfd.FileName))
            End If

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء تصدير ملف الإكسيل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cmbFilterType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterType.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        cmbFilterType.SelectedIndex = 0
        LoadCustomers()
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

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.Close()
            Return True
        ElseIf keyData = Keys.F10 Then
            btnDoPayment.PerformClick()
            Return True
        ElseIf keyData = Keys.F5 Then
            btnRefresh.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class