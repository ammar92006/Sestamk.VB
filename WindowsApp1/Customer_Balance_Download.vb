Imports System.Data.SqlClient
Imports ClosedXML.Excel
Imports Guna.UI2.WinForms

Public Class Customer_Balance_Download
    Dim x, y As Integer
    Dim newpoint As New Point
    Private defaultTreasuryid As Integer = If(SettingsManager.GetSetting("defaultTreasuryid"), -1)

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Async Sub Customer_Balance_Download_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearchField.Items.Add("كود العميل")
        cmbSearchField.Items.Add("اسم العميل")
        cmbSearchField.Items.Add("رقم الهاتف")
        cmbSearchField.Items.Add("العنوان")
        cmbSearchField.Items.Add("الحالة")
        cmbSearchField.Items.Add("الملاحظات")
        cmbSearchField.SelectedIndex = 1
        Me.KeyPreview = True
        LoadCustomers()
        datagridviewsetup()
        Await LoadTreasuriesAsync()
    End Sub

    Private Async Function LoadTreasuriesAsync() As Task

        Try

            Dim dt As New DataTable()

            Using cn As SqlConnection = Await NewConnAsync()

                Const sql As String =
                    "
                    SELECT
                    TreasuryID,
                    TreasuryNameAr
                    FROM Treasury
                    WHERE IsActive = 1
                    AND IsDeleted = 0
                    "

                Using da As New SqlDataAdapter(sql, cn)

                    Await Task.Run(Sub() da.Fill(dt))

                End Using

            End Using
            cmbTreasury.DataSource = dt
            cmbTreasury.DisplayMember = "TreasuryNameAr"
            cmbTreasury.ValueMember = "TreasuryID"
            defaultTreasuryid = If(SettingsManager.GetSetting("defaultTreasuryid"), -1)
            cmbTreasury.SelectedIndex = defaultTreasuryid

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Function
    Private Sub LoadCustomers(Optional filter As String = "", Optional field As String = "")
        Using Conn
            Dim query As String = "SELECT CustomerID, CustomerCode, CustomerName, PhoneNumber, Address, CreditLimit, CurrentBalance, IsActive, Notes , CreatedAt , UpdatedAt FROM Customers"
            Connect()
            txtCustomerCode.Clear()
            txtCustomerName.Clear()
            nudCreditLimit.Value = 0
            txtBalance.Clear()

            If filter <> "" Then
                Dim columnName As String = ""
                Select Case field
                    Case "كود العميل"
                        columnName = "CustomerCode"
                    Case "اسم العميل"
                        columnName = "CustomerName"
                    Case "رقم الهاتف"
                        columnName = "PhoneNumber"
                    Case "العنوان"
                        columnName = "Address"
                    Case "الحالة"
                        columnName = "IsActive"
                    Case "الملاحظات"
                        columnName = "Notes"
                    Case "تاريخ الاضافة"
                        columnName = "CreatedAt"
                    Case "تاريخ اخر تحديث"
                        columnName = "UpdatedAt"
                End Select

                If columnName <> "" Then
                    query &= $" WHERE {columnName} LIKE @filter"
                End If
            End If

            Dim cmd As New SqlCommand(query, Conn)
            If filter <> "" Then cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvCustomers.DataSource = dt
            Disconnect()
        End Using
    End Sub


    Private Sub datagridviewsetup()
        With dgvCustomers
            dgvCustomers.ReadOnly = True
            dgvCustomers.AllowUserToAddRows = False
            dgvCustomers.AllowUserToDeleteRows = False
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48)
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue

            '---------------------------
            ' إعداد العنوان (Header)
            '---------------------------
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 60
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            '---------------------------
            ' إعداد الصفوف (Rows)
            '---------------------------
            .DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 55)
            .DefaultCellStyle.ForeColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180) ' لون أزرق أنيق عند التحديد
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5)
            '.RowTemplate.Height = 60

            '---------------------------
            ' الصفوف المتبادلة
            '---------------------------
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65)

            '---------------------------
            ' شكل الشبكة
            '---------------------------
            .GridColor = Color.FromArgb(80, 80, 80)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

            '---------------------------
            ' الإعدادات العامة
            '---------------------------
            .BackgroundColor = Color.FromArgb(30, 30, 35)
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = True
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False

            ' ✅ ضبط النص في المنتصف داخل الخلايا
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' ✅ إظهار عناوين الأعمدة (لو كانت مخفية)
            .ColumnHeadersVisible = True


            '.Columns("BaseUnit_ID").Visible = False
            .Columns("CustomerID").Visible = False

            ' ✅ عناوين الأعمدة
            .Columns("CustomerCode").HeaderText = "كود العميل"
            .Columns("CustomerName").HeaderText = "اسم العميل"
            .Columns("PhoneNumber").HeaderText = "رقم الهاتف"
            .Columns("Address").HeaderText = "العنوان"
            .Columns("CreditLimit").HeaderText = "حد الائتمان"
            .Columns("CurrentBalance").HeaderText = "الرصيد الحالي"
            .Columns("IsActive").HeaderText = "الحالة"
            .Columns("Notes").HeaderText = "الملاحظات"
            .Columns("CreatedAt").HeaderText = "تاريخ الاضافة"
            .Columns("UpdatedAt").HeaderText = "تاريخ اخر تحديث"

            '' الترتيب
            '.Columns("Product_ID").DisplayIndex = 0
            '.Columns("Product_Code").DisplayIndex = 1
            '.Columns("Product_Name").DisplayIndex = 2
            '.Columns("Unit_Name").DisplayIndex = 3
            '.Columns("Category_Name").DisplayIndex = 4
            '.Columns("Partner_Name").DisplayIndex = 5
            '.Columns("CompanyName").DisplayIndex = 6
            '.Columns("Product_Note").DisplayIndex = 7
            '.Columns("Product_State").DisplayIndex = 8
            .Columns("CustomerName").Width = 300
            .Columns("IsActive").Width = 60


            ' ✅ عرض الأعمدة بالتساوي
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '' ✅ تحسين مظهر الصفوف
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
            '.DefaultCellStyle.Font = New Font("Segoe UI", 14)
            '.DefaultCellStyle.ForeColor = Color.Black
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255)
            '.DefaultCellStyle.SelectionForeColor = Color.White

            '' ✅ تحسين عناوين الأعمدة
            '.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            '.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 102, 153)
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.EnableHeadersVisualStyles = False   ' ← لازم False علشان التنسيق يبان فعلاً

            '' ✅ حدود الصفوف والخلايا
            '.GridColor = Color.LightGray
            '.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            '.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            '.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            ' ✅ شكل جميل للصفوف
            '.RowTemplate.Height = 100
            .MultiSelect = False
        End With
    End Sub
    Private Function GetSuggestions(field As String, keyword As String) As List(Of String)
        Dim suggestions As New List(Of String)()

        Dim columnName As String = ""
        Select Case field
            Case "كود العميل"
                columnName = "CustomerCode"
            Case "اسم العميل"
                columnName = "CustomerName"
            Case "رقم الهاتف"
                columnName = "PhoneNumber"
            Case "العنوان"
                columnName = "Address"
            Case "الحالة"
                columnName = "IsActive"
            Case "الملاحظات"
                columnName = "Notes"
        End Select

        Using Conn
            Connect()
            Dim query As String = $"SELECT {columnName} FROM Customers WHERE {columnName} LIKE @keyword"
            Dim cmd As New SqlCommand(query, Conn)
            cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")

            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                suggestions.Add(reader(columnName).ToString())
            End While
        End Using
        Disconnect()
        Return suggestions
    End Function
    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        'If lstSuggestions.SelectedItem IsNot Nothing Then
        '    txtSearch.Text = lstSuggestions.SelectedItem.ToString()
        '    lstSuggestions.Visible = False
        '    LoadCustomers(txtSearch.Text)
        'End If

        If lstSuggestions.SelectedItem IsNot Nothing Then
            txtSearch.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
            'LoadCustomers(txtSearch.Text)
            Dim keyword As String = txtSearch.Text.Trim()
            Dim field As String = cmbSearchField.SelectedItem.ToString()
            LoadCustomers(keyword, field)

            If dgvCustomers.Rows.GetRowCount(DataGridViewElementStates.Visible) = 1 Then

                Dim visibleRow As DataGridViewRow =
                    dgvCustomers.Rows.Cast(Of DataGridViewRow)().
                    First(Function(r) r.Visible)

                Dim visibleCell As DataGridViewCell =
                    visibleRow.Cells.Cast(Of DataGridViewCell)().
                    First(Function(c) c.Visible)

                dgvCustomers.ClearSelection()
                visibleRow.Selected = True
                dgvCustomers.CurrentCell = visibleCell

                SelectCustomer(visibleRow.Index)

            End If




        End If

    End Sub
    Private Sub SelectCustomer(rowIndex As Integer)

        If rowIndex < 0 OrElse rowIndex >= dgvCustomers.Rows.Count Then Exit Sub

        Dim row As DataGridViewRow = dgvCustomers.Rows(rowIndex)
        txtCustomerCode.Text = row.Cells("CustomerCode").Value.ToString()
        txtCustomerName.Text = row.Cells("CustomerName").Value.ToString()
        nudCreditLimit.Value = Convert.ToDecimal(row.Cells("CreditLimit").Value)
        txtBalance.Text = row.Cells("CurrentBalance").Value.ToString()

    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()
        lstSuggestions.Items.Clear()

        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            LoadCustomers() ' عرض الكل لو البحث فاضي
            Exit Sub
        End If

        Dim field As String = cmbSearchField.SelectedItem.ToString()
        Dim suggestions = GetSuggestions(field, keyword)

        If suggestions.Count > 0 Then
            lstSuggestions.Items.AddRange(suggestions.ToArray())
            lstSuggestions.Visible = True
        Else
            lstSuggestions.Visible = False
        End If

        LoadCustomers(keyword, field)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub dgvCustomers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCustomers.Rows(e.RowIndex)
            txtCustomerCode.Text = row.Cells("CustomerCode").Value.ToString()
            txtCustomerName.Text = row.Cells("CustomerName").Value.ToString()
            nudCreditLimit.Value = Convert.ToDecimal(row.Cells("CreditLimit").Value)
            txtBalance.Text = row.Cells("CurrentBalance").Value.ToString()
        End If
    End Sub

    Private Sub txtBalance_TextChanged(sender As Object, e As EventArgs) Handles txtBalance.TextChanged
        SplitBalance(txtBalance, txtDebit, txtCredit)
    End Sub

    'Private Sub btnDoPayment_Click(sender As Object, e As EventArgs) Handles btnDoPayment.Click
    '    If txtAmountPaid.Text = "" Then
    '        MsgBox("من فضلك قم بادخال قيمه الدفع")
    '        Exit Sub
    '    End If
    '    If txtCustomerCode.Text = "" Or txtBalance.Text = "" Then
    '        MsgBox("برجاء اختيار العميل")
    '        Exit Sub
    '    End If
    '    '------------------------------
    '    ' 1️⃣ جمع البيانات من الفورم
    '    '------------------------------
    '    Dim clientName As String = txtCustomerName.Text
    '    Dim balance As Decimal = CDec(txtBalance.Text) ' موجب أو سالب
    '    Dim payAmount As Decimal = CDec(txtAmountPaid.Text)
    '    Dim notes As String = txtNotes.Text

    '    ' فحص البيانات
    '    If clientName = "" Then
    '        MsgBox("من فضلك اختر العميل.", MsgBoxStyle.Exclamation)
    '        Exit Sub
    '    End If

    '    'If payAmount <= 0 Then
    '    '    MsgBox("قيمة الدفع يجب أن تكون أكبر من صفر.", MsgBoxStyle.Exclamation)
    '    '    Exit Sub
    '    'End If

    '    '------------------------------
    '    ' 2️⃣ حساب الرصيد الجديد
    '    '------------------------------
    '    Dim newBalance As Decimal = balance + payAmount  ' الدفع يقلل الدين (الدين سالب)

    '    '------------------------------
    '    ' 3️⃣ فتح فورم التأكيد مع تمرير البيانات
    '    '------------------------------
    '    Dim frm As New frmConfirmMessage()

    '    frm.CustomerName = clientName
    '    frm.BalanceBefore = balance
    '    frm.AmountPaid = payAmount
    '    frm.BalanceAfter = newBalance
    '    frm.Notes = notes

    '    If frm.ShowDialog() = DialogResult.OK Then

    '        txtCustomerCode.Text = ""
    '        txtCustomerName.Text = ""
    '        nudCreditLimit.Text = "0"
    '        txtBalance.Text = ""
    '        txtAmountPaid.Text = ""
    '        txtNotes.Text = ""
    '        LoadCustomers()
    '        dgvCustomers.ClearSelection()
    '    End If
    'End Sub



    Private Sub btnDoPayment_Click(sender As Object, e As EventArgs) Handles btnDoPayment.Click
        If txtAmountPaid.Text = "" Then
            MsgBox("من فضلك قم بادخال قيمه الدفع")
            Exit Sub
        End If
        If txtCustomerCode.Text = "" Or txtBalance.Text = "" Then
            MsgBox("برجاء اختيار العميل")
            Exit Sub
        End If

        ' 🛑 الجديد: التحقق من اختيار الخزنة
        If cmbTreasury.SelectedValue Is Nothing Then
            MsgBox("من فضلك اختر الخزنة التي سيتم إيداع المبلغ فيها.")
            Exit Sub
        End If
        Dim selectedTreasuryID As Integer = Convert.ToInt32(cmbTreasury.SelectedValue)

        '------------------------------
        ' 1️⃣ جمع البيانات من الفورم
        '------------------------------
        Dim clientName As String = txtCustomerName.Text
        Dim balance As Decimal = CDec(txtBalance.Text)
        Dim payAmount As Decimal = CDec(txtAmountPaid.Text)
        Dim notes As String = txtNotes.Text

        If clientName = "" Then
            MsgBox("من فضلك اختر العميل.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '------------------------------
        ' 2️⃣ حساب الرصيد الجديد
        '------------------------------
        Dim newBalance As Decimal = balance + payAmount

        '------------------------------
        ' 3️⃣ فتح فورم التأكيد مع تمرير البيانات
        '------------------------------
        Dim frm As New frmConfirmMessage()

        frm.CustomerName = clientName
        frm.BalanceBefore = balance
        frm.AmountPaid = payAmount
        frm.BalanceAfter = newBalance
        frm.Notes = notes
        frm.TargetTreasuryID = selectedTreasuryID ' ⬅️ تمرير معرف الخزنة لفورم التأكيد

        If frm.ShowDialog() = DialogResult.OK Then
            ' تنظيف الأدوات بعد النجاح
            txtCustomerCode.Text = ""
            txtCustomerName.Text = ""
            nudCreditLimit.Text = "0"
            txtBalance.Text = ""
            txtAmountPaid.Text = ""
            txtNotes.Text = ""
            cmbTreasury.SelectedIndex = -1 ' تصفير الخزنة
            LoadCustomers()
            dgvCustomers.ClearSelection()
        End If
    End Sub


    Private Sub SplitBalance(ByVal txtBalance As Guna2TextBox, ByVal txtDebit As Guna2TextBox, ByVal txtCredit As Guna2TextBox)

        Dim balance As Decimal

        ' نحاول نحول القيمة لرقم
        If Decimal.TryParse(txtBalance.Text.Trim(), balance) Then

            If balance < 0 Then
                ' لو رصيد سالب → يروح للمدين
                txtDebit.Text = Math.Abs(balance).ToString()
                txtCredit.Text = "0"

            ElseIf balance > 0 Then
                ' لو رصيد موجب → يروح للدائن
                txtDebit.Text = "0"
                txtCredit.Text = balance.ToString()

            Else
                ' لو صفر
                txtDebit.Text = "0"
                txtCredit.Text = "0"
            End If

        Else
            ' لو المستخدم كتب حاجة مش رقم
            txtDebit.Text = "0"
            txtCredit.Text = "0"
        End If

    End Sub
End Class