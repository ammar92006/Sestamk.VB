Imports System.Data.SqlClient

Public Class FrmTreasuryTransactionsReport
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private defaultTreasuryid As Integer = If(SettingsManager.GetSetting("defaultTreasuryid"), -1)
    Private _x, _y As Integer
    Private _newPoint As New Point
    Private Async Sub FrmTreasuryTransactionsReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ضبط التواريخ لتبدأ من بداية الشهر الحالي وحتى اليوم
        dtpFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpTo.Value = DateTime.Now
        SetupDataGridView(dgvTransactions)
        Await LoadFiltersDataAsync()
        Await LoadUsersAsync()
        Await SearchTransactionsAsync()
    End Sub

    ' 1. تعبئة الكومبو بوكس الخاص بالخزن ونوع الحركة
    Private Async Function LoadFiltersDataAsync() As Task
        Try
            ' جلب الخزن
            Dim dtTreasuries As DataTable = Await TreasuryService.GetAllTreasuriesAsync()

            ' إضافة سحرية: حياكة سطر "الكل" داخل الجدول لفلترة كل الخزن
            Dim dr As DataRow = dtTreasuries.NewRow()
            dr("TreasuryID") = DBNull.Value
            dr("TreasuryNameAr") = "--- الكل ---"
            dtTreasuries.Rows.InsertAt(dr, 0)

            cmbTreasuryFilter.DataSource = dtTreasuries
            cmbTreasuryFilter.DisplayMember = "TreasuryNameAr"
            cmbTreasuryFilter.ValueMember = "TreasuryID"
            cmbTreasuryFilter.SelectedIndex = 0

            ' تعبئة أنواع الحركات يدوياً - استبدلنا Nothing بالرقم 0 ليعبر عن الكل
            Dim types = New Dictionary(Of Integer, String) From {
                {0, "--- الكل ---"},
                {1, "رصيد إفتتاحي"}, {2, "مبيعات"}, {3, "مشتريات"},
                {4, "سند قبض عميل"}, {5, "سند صرف مورد"}, {6, "مصروفات"},
                {7, "إيرادات"}, {8, "تحويل بين الخزن"}, {9, "مرتجع مبيعات"},
                {10, "مرتجع مشتريات"}, {11, "إيداع يدوي"}, {12, "سحب يدوي"}
            }
            cmbTypeFilter.DataSource = New BindingSource(types, Nothing)
            cmbTypeFilter.DisplayMember = "Value"
            cmbTypeFilter.ValueMember = "Key"
            cmbTypeFilter.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Async Function LoadUsersAsync() As Task

        Try

            Dim dtUsers As New DataTable()

            Using cn As SqlConnection = Await NewConnAsync()

                Const sql As String =
                    "
                    SELECT
                    User_ID,
                    User_Name
                    FROM Users_TBL

                    "

                Using da As New SqlDataAdapter(sql, cn)

                    Await Task.Run(Sub() da.Fill(dtUsers))

                End Using

            End Using

            ' إضافة سطر "الكل" للمستخدمين
            Dim drUser As DataRow = dtUsers.NewRow()
            drUser("User_ID") = DBNull.Value ' تعيين القيمة الفارغة لتعني الكل
            drUser("User_Name") = "--- الكل ---"
            dtUsers.Rows.InsertAt(drUser, 0)

            cmbUserFilter.DataSource = dtUsers
            cmbUserFilter.DisplayMember = "User_Name"
            cmbUserFilter.ValueMember = "User_ID"
            cmbUserFilter.SelectedIndex = 0

        Catch ex As Exception

        End Try

    End Function

    ' 2. دالة البحث الرئيسية وحساب الإجماليات
    Private Async Function SearchTransactionsAsync() As Task
        Try
            ' 1. جلب القيم من الفلاتر (معالجة قيمة DBNull)
            Dim treasuryID As Integer? = If(cmbTreasuryFilter.SelectedValue Is DBNull.Value, Nothing, CType(cmbTreasuryFilter.SelectedValue, Integer?))

            Dim selectedType As Integer = Convert.ToInt32(cmbTypeFilter.SelectedValue)
            Dim transType As Integer? = If(selectedType = 0, Nothing, CType(selectedType, Integer?))

            ' ⬅️ جلب فلتر المستخدم الجديد
            'Dim userID As Integer? = If(cmbUserFilter.SelectedValue Is DBNull.Value, Nothing, CType(cmbUserFilter.SelectedValue, Integer?))

            Dim userID As Integer? = Nothing

            ' فحص آمن لمنع خطأ الـ Cast عند اختيار (الكل) أو أن القيمة فارغة
            If cmbUserFilter.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbUserFilter.SelectedValue) Then
                userID = Convert.ToInt32(cmbUserFilter.SelectedValue)
            End If

            ' 2. استدعاء الدالة المحدثة مع بارامتر المستخدم
            Dim dt As DataTable = Await TreasuryService.GetTransactionsReportAsync(
            treasuryID:=treasuryID,
            transactionType:=transType,
            userID:=userID,
            fromDate:=dtpFrom.Value,
            toDate:=dtpTo.Value,
            searchText:=txtSearch.Text.Trim()
        )

            dgvTransactions.DataSource = dt

            ' تنسيق وحساب الإجماليات (نفس الكود السابق دون تغيير)
            If dgvTransactions.Columns.Contains("TransactionID") Then dgvTransactions.Columns("TransactionID").Visible = False
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Dim totalDeposits As Decimal = dt.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("إيداع (+)"))
            Dim totalWithdrawals As Decimal = dt.AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("سحب (-)"))

            lblTotalDeposits.Text = totalDeposits.ToString("N2")
            lblTotalWithdrawals.Text = totalWithdrawals.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء جلب الحركات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' 3. أحداث الفلترة الفورية (بمجرد الضغط أو التغيير يتم تحديث البيانات فوراً للراحة)
    Private Async Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Await SearchTransactionsAsync()
    End Sub

    Private Async Sub cmbTreasuryFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTreasuryFilter.SelectedIndexChanged
        ' نضع شرط للتأكد من أن الكومبو بوكس انتهى من التعبئة لعدم حدوث خطأ أثناء الـ Load
        If cmbTreasuryFilter.Focused Then Await SearchTransactionsAsync()
    End Sub

    Private Async Sub cmbTypeFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeFilter.SelectedIndexChanged
        If cmbTypeFilter.Focused Then Await SearchTransactionsAsync()
    End Sub
    Private Async Sub cmbUserFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUserFilter.SelectedIndexChanged
        If cmbUserFilter.Focused Then Await SearchTransactionsAsync()
    End Sub

    ' البحث بمجرد ضغط Enter داخل مربع النص
    Private Async Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' منع صوت المزامير المزعج بالويندوز
            Await SearchTransactionsAsync()
        End If
    End Sub

    ' إعادة تعيين كل الفلاتر لوضعها الأصلي
    Private Async Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpTo.Value = DateTime.Now
        txtSearch.Clear()
        cmbTreasuryFilter.SelectedIndex = 0
        cmbTypeFilter.SelectedIndex = 0
        Await SearchTransactionsAsync()
    End Sub

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        _x = Control.MousePosition.X - Me.Location.X
        _y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            _newPoint = Control.MousePosition
            _newPoint.X -= _x
            _newPoint.Y -= _y
            Me.Location = _newPoint
        End If
    End Sub

    Private Sub SetupDataGridView(ByVal dgv As DataGridView)
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToResizeColumns = False
        dgv.AllowUserToResizeRows = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False
        'dgv.RightToLeft = True
        Dim darkBg As Color = Color.FromArgb(30, 30, 30)
        Dim darkRow As Color = Color.FromArgb(45, 45, 45)
        Dim darkAlt As Color = Color.FromArgb(55, 55, 55)
        Dim darkHdr As Color = Color.FromArgb(64, 64, 64)
        Dim highlight As Color = Color.FromArgb(0, 122, 204)
        Dim textClr As Color = Color.Gainsboro

        dgv.BackgroundColor = darkBg
        dgv.RowsDefaultCellStyle.BackColor = darkRow
        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAlt
        dgv.DefaultCellStyle.ForeColor = textClr
        dgv.GridColor = Color.FromArgb(80, 80, 80)

        With dgv
            '.Columns("ColProductName").Width = 230
            '.Columns("ColQuantity").Width = 160
            '.Columns("ColPrice").DefaultCellStyle.Format = "N2"
            '.Columns("ColTotal").DefaultCellStyle.Format = "N2"

            For Each col As DataGridViewColumn In .Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            .RowTemplate.Height = 35
            .ColumnHeadersHeight = 48
            .ColumnHeadersDefaultCellStyle.BackColor = darkHdr
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 15.0!, FontStyle.Bold)
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .DefaultCellStyle.SelectionBackColor = highlight
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Segoe UI", 14.0!)
            .RowHeadersVisible = False
            .DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        End With
    End Sub
End Class