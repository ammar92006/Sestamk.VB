Imports System.Data.SqlClient
Imports ClosedXML.Excel
Imports System.IO
Imports Guna.UI2.WinForms
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports SeleniumExtras.WaitHelpers
Imports System.Threading.Tasks
Imports System.Net.Http
Imports System.Text

Public Class Customer
    Dim x, y As Integer
    Dim newpoint As New Point
    Private importedData As DataTable
    Public Driver As IWebDriver = Nothing
    Private SessionPath As String = "C:\WhatsAppSession"
    Public Enum BalanceSource
        Balance
        Debit
        Credit
    End Enum
    Private isUpdating As Boolean = False

    Private Sub UpdateBalanceFields(
    source As BalanceSource,
    txtBalance As Guna2TextBox,
    txtDebit As Guna2TextBox,
    txtCredit As Guna2TextBox)

        If isUpdating Then Exit Sub
        isUpdating = True

        Dim balance As Decimal = 0
        Dim debit As Decimal = 0
        Dim credit As Decimal = 0

        Decimal.TryParse(txtBalance.Text.Trim(), balance)
        Decimal.TryParse(txtDebit.Text.Trim(), debit)
        Decimal.TryParse(txtCredit.Text.Trim(), credit)

        Select Case source

            Case BalanceSource.Balance
                If balance < 0 Then
                    txtDebit.Text = Math.Abs(balance).ToString()
                    txtCredit.Text = "0.00"
                Else
                    txtDebit.Text = "0.00"
                    txtCredit.Text = balance.ToString()
                End If

            Case BalanceSource.Debit
                txtCredit.Text = "0.00"
                txtBalance.Text = (-Math.Abs(debit)).ToString()

            Case BalanceSource.Credit
                txtDebit.Text = "0.00"
                txtBalance.Text = Math.Abs(credit).ToString()

        End Select

        isUpdating = False
    End Sub





    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub
    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub
    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ' [FIX] تفعيل DoubleBuffered لتقليل الـ Flickering
        EnableDoubleBuffer(dgvCustomers)
        GetMaxProductCode()

        ''الزراير
        Me.btnImportExcel.Location = New System.Drawing.Point(5, 2)
        Me.btnExportExcel.Location = New System.Drawing.Point(340, 2)
        Me.btnDelete.Location = New System.Drawing.Point(580, 2)
        Me.btnEdit.Location = New System.Drawing.Point(880, 2)
        Me.btnNew.Location = New System.Drawing.Point(1220, 2)

    End Sub
    Private Sub GetMaxProductCode()
        Connect()
        Try
            Dim maxCode As Integer = 0

            Using cmd As New SqlClient.SqlCommand("SELECT ISNULL(MAX(CAST(CustomerCode AS INT)), 0) 
                                                    FROM Customers
                                                    WHERE ISNUMERIC(CustomerCode) = 1
                                                    ", Conn)
                maxCode = Convert.ToInt32(cmd.ExecuteScalar())
                Disconnect()
            End Using


            txtCustomerCode.Text = (maxCode + 1).ToString()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء جلب كود المنتج: " & ex.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try

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

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
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

        txtCustomerCode.Text = row.Cells("CustomerCode").Value?.ToString()
        txtCustomerName.Text = row.Cells("CustomerName").Value?.ToString()
        txtPhone.Text = row.Cells("PhoneNumber").Value?.ToString()
        txtAddress.Text = row.Cells("Address").Value?.ToString()

        nudCreditLimit.Value = Convert.ToDecimal(If(row.Cells("CreditLimit").Value, 0))
        txtBalance.Text = row.Cells("CurrentBalance").Value?.ToString()
        chkActive.Checked = Convert.ToBoolean(If(row.Cells("IsActive").Value, False))

        txtNotes.Text = row.Cells("Notes").Value?.ToString()
        txtCreatedAt.Text = row.Cells("CreatedAt").Value?.ToString()
        txtUpdatedAt.Text = row.Cells("UpdatedAt").Value?.ToString()

        Dim name As String = row.Cells("CustomerName").Value?.ToString()
        Dim balance As Decimal = Convert.ToDecimal(If(row.Cells("CurrentBalance").Value, 0))

        Dim word1 As String
        If balance < 0 Then
            balance = Math.Abs(balance)
            word1 = "عليك"
        Else
            word1 = "لديك"
        End If

        Dim message As String =
$"السلام عليكم ورحمة الله وبركاته الأستاذ/ {name}

نفيد سيادتكم بأنه {word1} مبلغ وقدره {balance} جنيه
وذلك بحسابكم لدى سوبر ماركت الحمد والرضا.
يرجى التواصل معنا على:
01095032689

وتفضلوا بقبول فائق الاحترام والتقدير.
إدارة سوبر ماركت الحمد والرضا"

        txtMessage.Text = message

    End Sub



    Private Sub LoadCustomers(Optional filter As String = "", Optional field As String = "")
        Using Conn
            Dim query As String = "SELECT CustomerID, CustomerCode, CustomerName, PhoneNumber, Address, CreditLimit, CurrentBalance, IsActive, Notes , CreatedAt , updated_at AS UpdatedAt FROM Customers"
            Connect()
            txtCustomerCode.Clear()
            txtCustomerName.Clear()
            txtCreatedAt.Clear()
            txtUpdatedAt.Clear()
            txtPhone.Clear()
            txtAddress.Clear()
            nudCreditLimit.Value = 0
            txtBalance.Clear()
            chkActive.Checked = False
            txtNotes.Clear()
            txtMessage.Clear()

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
                        columnName = "updated_at"
                End Select

                If columnName <> "" Then
                    query &= $" WHERE {columnName} LIKE @filter"
                End If
            End If

            Dim cmd As New SqlCommand(query, Conn)
            If filter <> "" Then
                cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")
            End If

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvCustomers.DataSource = dt
            Disconnect()
        End Using
        lblStatus.Text = "نشط غير"
        lblStatus.ForeColor = Color.Red
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

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'Try
        '    If String.IsNullOrWhiteSpace(txtCustomerCode.Text) OrElse String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
        '        MessageBox.Show("يرجى إدخال كود العميل واسم العميل.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Exit Sub
        '    End If

        '    Using con As New SqlConnection(ConnectionString)
        '        con.Open()
        '        Dim query As String = "
        '        INSERT INTO Customers (CustomerCode, CustomerName, PhoneNumber, Address, CreditLimit, CurrentBalance, IsActive, Notes)
        '        VALUES (@Code, @Name, @Phone, @Address, @Limit, @Balance, @Active, @Notes)"
        '        Dim cmd As New SqlCommand(query, con)
        '        cmd.Parameters.AddWithValue("@Code", txtCustomerCode.Text)
        '        cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text)
        '        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
        '        cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
        '        cmd.Parameters.AddWithValue("@Limit", Convert.ToInt32(nudCreditLimit.Value))
        '        cmd.Parameters.AddWithValue("@Balance", Convert.ToInt32(txtBalance.Text))
        '        cmd.Parameters.AddWithValue("@Active", toggleActive.Checked)
        '        cmd.Parameters.AddWithValue("@Notes", txtNotes.Text)
        '        cmd.ExecuteNonQuery()
        '    End Using

        '    MessageBox.Show("✅ تم إضافة العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    ClearFields()
        '    LoadCustomers()
        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء الإضافة: " & ex.Message)
        'End Try

        Try
            ' التحقق من الحقول المطلوبة
            If String.IsNullOrWhiteSpace(txtCustomerCode.Text) OrElse String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال كود واسم العميل على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تحقق من وجود كود العميل مسبقًا
            If IsCustomerCodeExists(txtCustomerCode.Text.Trim()) Then
                MessageBox.Show("⚠️ هذا الكود موجود بالفعل، لا يمكن تكراره.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تنفيذ عملية الإضافة
            Using Conn
                Connect()

                Dim query As String = "
            INSERT INTO Customers (CustomerCode, CustomerName, PhoneNumber, Address, CreditLimit, CurrentBalance, IsActive, Notes, CreatedAt)
            VALUES (@Code, @Name, @Phone, @Address, @Limit, @CurrentBalance, @Active, @Notes, GETDATE())"

                Using cmd As New SqlCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@Code", txtCustomerCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Limit", nudCreditLimit.Value)
                    cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(If(String.IsNullOrEmpty(txtBalance.Text), 0, txtBalance.Text)))
                    cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم إضافة العميل بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadCustomers()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء إضافة العميل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try

    End Sub

    Private Function IsCustomerCodeExists(customerCode As String, Optional excludeCustomerID As Integer = -1) As Boolean
        Dim exists As Boolean = False

        Try
            Connect()

            Dim query As String = "SELECT COUNT(*) FROM Customers WHERE CustomerCode = @code"
            If excludeCustomerID <> -1 Then
                query &= " AND CustomerID <> @id"
            End If

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@code", customerCode)
                If excludeCustomerID <> -1 Then
                    cmd.Parameters.AddWithValue("@id", excludeCustomerID)
                End If

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                exists = (count > 0)
            End Using

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء التحقق من الكود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try

        Return exists
    End Function

    Private Sub dgvCustomers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCustomers.Rows(e.RowIndex)
            txtCustomerCode.Text = row.Cells("CustomerCode").Value.ToString()
            txtCustomerName.Text = row.Cells("CustomerName").Value.ToString()
            txtPhone.Text = row.Cells("PhoneNumber").Value.ToString()
            txtAddress.Text = row.Cells("Address").Value.ToString()
            nudCreditLimit.Value = Convert.ToDecimal(row.Cells("CreditLimit").Value)
            txtBalance.Text = row.Cells("CurrentBalance").Value.ToString()
            chkActive.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
            txtNotes.Text = row.Cells("Notes").Value.ToString()
            txtCreatedAt.Text = row.Cells("CreatedAt").Value.ToString()
            txtUpdatedAt.Text = row.Cells("UpdatedAt").Value.ToString()
            Dim massege As String
            Dim name As String = row.Cells("CustomerName").Value.ToString()
            Dim Balance As Decimal = row.Cells("CurrentBalance").Value.ToString()
            Dim word1 As String = "لديك"
            If Decimal.TryParse(txtBalance.Text.Trim(), Balance) Then

                If Balance < 0 Then
                    ' لو رصيد سالب → يروح للمدين
                    Balance = Math.Abs(Balance).ToString()
                    word1 = "عليك"
                ElseIf Balance > 0 Then
                    ' لو رصيد موجب → يروح للدائن
                    Balance = Balance.ToString()
                    word1 = "لديك"
                Else
                    word1 = "لديك"

                End If

            Else
                ' لو المستخدم كتب حاجة مش رقم
                txtDebit.Text = "0"
                txtCredit.Text = "0"
            End If
            '            massege = $"السلام عليكم يا {name} 🌟
            'نحب نذكرك أن {word1} مبلغ {Balance} جنيه مستحق في سوبر ماركت الحمد والرضا.
            'لأي استفسار أو تسوية، اتصل بنا على: [01095032689]
            'شكرًا لتعاملك معنا ❤️"
            massege = $"السلام عليكم ورحمة الله وبركاته الأستاذ/ {name}

نفيد سيادتكم بأنه {word1} مبلغ وقدره {Balance} جنيه
وذلك بحسابكم لدى سوبر ماركت الحمد والرضا.
يرجى التواصل معنا على:
01095032689

وتفضلوا بقبول فائق الاحترام والتقدير.
إدارة سوبر ماركت الحمد والرضا"

            txtMessage.Text = massege
            End If
    End Sub



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvCustomers.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار العميل أولاً من الجدول.")
            Return
        End If

        Dim id As Integer = Convert.ToInt32(dgvCustomers.SelectedRows(0).Cells("CustomerID").Value)
        Dim name As String = dgvCustomers.SelectedRows(0).Cells("CustomerName").Value.ToString()

        If MessageBox.Show($"هل أنت متأكد من حذف العميل '{name}'؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Using con As New SqlConnection(ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand("DELETE FROM Customers WHERE CustomerID=@ID", con)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("🗑️ تم حذف العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadCustomers()
            ClearFields()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        '   If dgvCustomers.SelectedRows.Count = 0 Then
        '       MessageBox.Show("يرجى اختيار العميل أولاً من الجدول.")
        '       Return
        '   End If

        '   Dim id As Integer = Convert.ToInt32(dgvCustomers.SelectedRows(0).Cells("CustomerID").Value)

        '   Using Conn
        '       Connect()
        '       Dim query As String = "
        'UPDATE Customers
        'SET CustomerCode=@Code, CustomerName=@Name, PhoneNumber=@Phone, Address=@Address,
        '    CreditLimit=@Limit, CurrentBalance=@CurrentBalance , IsActive=@Active, Notes=@Notes, UpdatedAt=GETDATE()
        'WHERE CustomerID=@ID"
        '       Dim cmd As New SqlCommand(query, Conn)
        '       cmd.Parameters.AddWithValue("@Code", txtCustomerCode.Text)
        '       cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text)
        '       cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
        '       cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
        '       cmd.Parameters.AddWithValue("@Limit", nudCreditLimit.Value)
        '       cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(txtBalance.Text))
        '       cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
        '       cmd.Parameters.AddWithValue("@Notes", txtNotes.Text)
        '       cmd.Parameters.AddWithValue("@ID", id)
        '       cmd.ExecuteNonQuery()
        '   End Using

        '   MessageBox.Show("✅ تم تعديل بيانات العميل بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '   ClearFields()
        '   LoadCustomers()

        Try
            If dgvCustomers.SelectedRows.Count = 0 Then
                MessageBox.Show("⚠️ يرجى اختيار العميل أولاً من الجدول.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim id As Integer = Convert.ToInt32(dgvCustomers.SelectedRows(0).Cells("CustomerID").Value)
            Dim code As String = txtCustomerCode.Text.Trim()

            ' تحقق من وجود كود العميل مكرر لكود آخر
            If IsCustomerCodeExists(code, id) Then
                MessageBox.Show("⚠️ هذا الكود مستخدم بواسطة عميل آخر، لا يمكن تكراره.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تنفيذ التعديل
            Using Conn
                Connect()

                Dim query As String = "
            UPDATE Customers
            SET CustomerCode=@Code, 
                CustomerName=@Name, 
                PhoneNumber=@Phone, 
                Address=@Address,
                CreditLimit=@Limit, 
                CurrentBalance=@CurrentBalance,
                IsActive=@Active, 
                Notes=@Notes, 
                updated_at=SYSUTCDATETIME(),
                LastTransactionDate=GETDATE()
            WHERE CustomerID=@ID"

                Using cmd As New SqlCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@Code", code)
                    cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Limit", nudCreditLimit.Value)
                    cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(If(String.IsNullOrEmpty(txtBalance.Text), 0, txtBalance.Text)))
                    cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                    cmd.Parameters.AddWithValue("@ID", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم تعديل بيانات العميل بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadCustomers()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تعديل العميل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try

    End Sub

    Private Sub toggleActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkActive.CheckedChanged
        If chkActive.Checked Then
            lblStatus.Text = "نشط"
            lblStatus.ForeColor = Color.Green
        Else
            lblStatus.Text = "نشط غير"
            lblStatus.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            ' 1️⃣ تحميل البيانات من قاعدة البيانات
            Dim dt As New DataTable()
            Using Conn
                Connect()
                Dim cmd As New SqlCommand("
                SELECT CustomerCode AS [كود العميل],
                       CustomerName AS [اسم العميل],
                       PhoneNumber AS [رقم الهاتف],
                       Address AS [العنوان],
                       CreditLimit AS [حد الائتمان],
                       CurrentBalance AS [الرصيد الحالي],
                       CASE WHEN IsActive = 1 THEN N'نشط' ELSE N'غير نشط' END AS [الحالة],
                       Notes AS [ملاحظات],
                       CreatedAt AS [تاريخ الإنشاء],
                       updated_at AS [آخر تحديث]
                FROM Customers", Conn)
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Disconnect()
            End Using

            ' 2️⃣ تحديد مسار الحفظ
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "Excel Workbook|*.xlsx"
            sfd.FileName = "قائمة_العملاء_" & DateTime.Now.ToString("yyyy-MM-dd_HH-mm") & ".xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                ' 3️⃣ إنشاء ملف Excel جديد
                Using wb As New XLWorkbook()
                    Dim ws = wb.Worksheets.Add("العملاء")
                    ws.Cell(1, 1).InsertTable(dt, "Customers", True)

                    ' 🎨 تنسيق بسيط وجميل
                    ws.Columns().AdjustToContents()
                    ws.Rows(1, 1).Style.Font.Bold = True
                    ws.Rows(1, 1).Style.Fill.BackgroundColor = XLColor.FromArgb(46, 117, 182)
                    ws.Rows(1, 1).Style.Font.FontColor = XLColor.White
                    ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                    ' 4️⃣ حفظ الملف
                    wb.SaveAs(sfd.FileName)
                End Using

                MessageBox.Show("✅ تم تصدير بيانات العملاء إلى Excel بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 5️⃣ فتح المجلد تلقائيًا
                Dim folderPath As String = Path.GetDirectoryName(sfd.FileName)
                Process.Start("explorer.exe", folderPath)
            End If

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء التصدير: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnImportExcel_Click(sender As Object, e As EventArgs) Handles btnImportExcel.Click
        'Try
        '    Dim openDialog As New OpenFileDialog With {
        '        .Filter = "Excel Workbook|*.xlsx",
        '        .Title = "استيراد بيانات العملاء من Excel"
        '    }

        '    If openDialog.ShowDialog() = DialogResult.OK Then
        '        Dim dt As New DataTable()

        '        Using workbook As New XLWorkbook(openDialog.FileName)
        '            Dim worksheet = workbook.Worksheet(1)
        '            Dim firstRow = True

        '            For Each row In worksheet.RowsUsed()
        '                If firstRow Then
        '                    ' إنشاء الأعمدة
        '                    For Each cell In row.CellsUsed()
        '                        dt.Columns.Add(cell.GetString())
        '                    Next
        '                    firstRow = False
        '                Else
        '                    ' إضافة صفوف البيانات
        '                    Dim newRow = dt.NewRow()
        '                    Dim colIndex As Integer = 0

        '                    For Each cell In row.Cells()
        '                        Try
        '                            Dim cellValue As String = ""
        '                            If Not cell.IsEmpty() Then
        '                                ' نحول أي قيمة إلى نص آمن
        '                                cellValue = cell.GetFormattedString()
        '                            End If
        '                            newRow(colIndex) = cellValue
        '                        Catch
        '                            newRow(colIndex) = ""
        '                        End Try
        '                        colIndex += 1
        '                    Next
        '                    dt.Rows.Add(newRow)
        '                End If
        '            Next
        '        End Using

        '        ' ✅ عرض البيانات في DataGridView الرئيسي (اختياري)
        '        dgvCustomers.DataSource = dt

        '        ' ✅ فتح فورم المعاينة تلقائيًا
        '        ' ✅ فتح فورم المعاينة تلقائيًا
        '        Dim previewForm As New FormPreviewCustomers(dt)


        '        previewForm.LoadData(dt)
        '        previewForm.ShowDialog()

        '    End If

        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء الاستيراد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        'Try
        '    Dim ofd As New OpenFileDialog()
        '    ofd.Filter = "Excel Files|*.xlsx;*.xls"

        '    If ofd.ShowDialog() = DialogResult.OK Then
        '        Dim filePath As String = ofd.FileName
        '        importedData = ImportExcelFile(filePath)

        '        ' فتح شاشة المعاينة
        '        Dim preview As New FormPreviewCustomers(importedData)
        '        preview.ShowDialog()
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء الاستيراد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub SaveImportedData(dt As DataTable)
        Try
            Using Conn
                Connect()

                For Each row As DataRow In dt.Rows
                    Dim cmd As New SqlCommand("
                    INSERT INTO Customers (CustomerCode, CustomerName, PhoneNumber, Address, CreditLimit, CurrentBalance, IsActive, Notes, CreatedAt, updated_at)
                    VALUES (@Code, @Name, @Phone, @Address, @Credit, @Balance, @Active, @Notes, GETDATE(), SYSUTCDATETIME())", Conn)

                    cmd.Parameters.AddWithValue("@Code", row("كود العميل"))
                    cmd.Parameters.AddWithValue("@Name", row("اسم العميل"))
                    cmd.Parameters.AddWithValue("@Phone", row("رقم الهاتف"))
                    cmd.Parameters.AddWithValue("@Address", row("العنوان"))
                    cmd.Parameters.AddWithValue("@Credit", If(IsNumeric(row("حد الائتمان")), Convert.ToDecimal(row("حد الائتمان")), 0))
                    cmd.Parameters.AddWithValue("@Balance", If(IsNumeric(row("الرصيد الحالي")), Convert.ToDecimal(row("الرصيد الحالي")), 0))
                    cmd.Parameters.AddWithValue("@Active", If(row("الحالة").ToString().Trim() = "نشط", 1, 0))
                    cmd.Parameters.AddWithValue("@Notes", row("ملاحظات"))

                    cmd.ExecuteNonQuery()
                Next
            End Using

            MessageBox.Show("💾 تم حفظ البيانات المستوردة في قاعدة العملاء بنجاح!", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء حفظ البيانات في القاعدة: " & ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Try
            If dgvCustomers.Rows.Count = 0 Then
                MessageBox.Show("لا توجد بيانات للمعاينة.", "تنبيه")
                Return
            End If

            Dim previewForm As New Form()
            previewForm.Text = "معاينة البيانات"
            previewForm.Size = New Size(800, 500)

            Dim dgvPreview As New DataGridView With {
                .Dock = DockStyle.Fill,
                .DataSource = dgvCustomers.DataSource,
                .ReadOnly = True,
                .AllowUserToAddRows = False
            }

            previewForm.Controls.Add(dgvPreview)
            previewForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء المعاينة: " & ex.Message)
        End Try
    End Sub
    Private Sub ClearFields()
        txtCustomerCode.Clear()
        txtCustomerName.Clear()
        txtCreatedAt.Clear()
        txtUpdatedAt.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        nudCreditLimit.Value = 0
        txtBalance.Clear()
        chkActive.Checked = False
        txtNotes.Clear()
        dgvCustomers.ClearSelection()
        txtMessage.Clear()
    End Sub

    Private Sub Customer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.Control AndAlso e.KeyCode = System.Windows.Forms.Keys.F1 Then
            e.SuppressKeyPress = True ' يمنع مرور الاختصار للنظام
            e.Handled = True           ' يمنع أي أكواد أخرى من التعامل مع نفس الحدث
            txtSearch.Focus()
        End If

        Select Case e.KeyCode
            Case System.Windows.Forms.Keys.F1
                MessageBox.Show("الاختصارات المتاحة:" & vbCrLf &
                    "F2 / Ctrl+N : إضافة جديد" & vbCrLf &
                    "F3 : تعديل" & vbCrLf &
                    "F4 : حذف" & vbCrLf &
                    "F5 : تحديث الجدول" & vbCrLf &
                    "F6 : مسح الحقول" & vbCrLf &
                    "Ctrl+F : بحث" & vbCrLf &
                    "Esc : خروج", "دليل الاختصارات", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Case Keys.F2
            '    btnNew.PerformClick()   ' زر الإضافة

            Case System.Windows.Forms.Keys.F3
                btnEdit.PerformClick()  ' زر التعديل

            Case System.Windows.Forms.Keys.F4
                btnDelete.PerformClick() ' زر الحذف

            Case System.Windows.Forms.Keys.F6
                ClearFields()' زر مسح الحقول

            Case System.Windows.Forms.Keys.F5
                LoadCustomers()         ' إعادة تحميل الجدول مثلاً
                    ' إعادة تحميل الجدول مثلاً

            Case System.Windows.Forms.Keys.Escape
                Me.Close()              ' خروج من الفورم
        End Select

    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearFields()
        GetMaxProductCode()
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

    Private Sub txtBalance_TextChanged(sender As Object, e As EventArgs) Handles txtBalance.TextChanged
        'SplitBalance(txtBalance, txtDebit, txtCredit)
        UpdateBalanceFields(BalanceSource.Balance, txtBalance, txtDebit, txtCredit)

    End Sub

    Private Async Sub btnSendWhatsApp_Click(sender As Object, e As EventArgs) Handles btnSendWhatsApp.Click
        Dim phone As String = txtPhone.Text.Trim()
        Dim message As String = txtMessage.Text.Trim()

        If String.IsNullOrEmpty(phone) OrElse String.IsNullOrEmpty(message) Then
            MessageBox.Show("من فضلك أدخل الرقم والرسالة.")
            Return
        End If
        Dim success As Boolean = Await WhatsAppAPI.SendText(phone, message)

        If success Then
            MessageBox.Show("✅ تم إرسال الرسالة")
        Else
            MessageBox.Show("❌ فشل الإرسال")
        End If
    End Sub

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub

    Private Sub grpCustomerInfo_Click(sender As Object, e As EventArgs) Handles grpCustomerInfo.Click

    End Sub

    Private Sub txtCredit_TextChanged(sender As Object, e As EventArgs) Handles txtCredit.TextChanged
        UpdateBalanceFields(BalanceSource.Credit, txtBalance, txtDebit, txtCredit)
    End Sub

    Private Sub txtDebit_TextChanged(sender As Object, e As EventArgs) Handles txtDebit.TextChanged
        UpdateBalanceFields(BalanceSource.Debit, txtBalance, txtDebit, txtCredit)

    End Sub

    Private Sub dgvCustomers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellDoubleClick
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

            Dim sectionName As String = dgvCustomers.Rows(e.RowIndex).Cells("CustomerName").Value.ToString()

            Dim frm As Reports = Nothing
            For Each f As Form In Application.OpenForms
                If TypeOf f Is Reports Then
                    frm = CType(f, Reports)
                    Exit For
                End If
            Next

            If frm Is Nothing Then
                frm = New Reports
                frm.Show()
            Else
                frm.BringToFront()
            End If

            'Try
            '    frm.cmbSearchField.SelectedIndex = 3
            'Catch
            'End Try

            Try
                frm.cboSalesCustomer.Text = sectionName
                'frm.btnSearchSales_Click(frm.cboSalesCustomer, EventArgs.Empty)
                frm.btnSearchSales.PerformClick()
            Catch
            End Try

        Catch ex As Exception
            ' تجاهل أي خطأ بصمت
        End Try
    End Sub

    Private Function ImportExcelFile(filePath As String) As DataTable
        Dim dt As New DataTable()

        Try
            Using workbook As New XLWorkbook(filePath)
                Dim worksheet = workbook.Worksheets.First()
                Dim firstRow = True

                For Each row In worksheet.RowsUsed()
                    If firstRow Then
                        ' قراءة رؤوس الأعمدة كما هي
                        For Each cell In row.CellsUsed()
                            Dim colName As String = cell.GetString()

                            ' لو الاسم فاضي أو مكرر بنضيف رقم بسيط علشان ما يحصلش crash
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
                        ' قراءة الصفوف كما هي (بدون تعديل)
                        Dim dataRow = dt.NewRow()
                        Dim colIndex As Integer = 0
                        For Each cell In row.CellsUsed()
                            If colIndex < dt.Columns.Count Then
                                dataRow(colIndex) = cell.GetFormattedString()
                            End If
                            colIndex += 1
                        Next
                        dt.Rows.Add(dataRow)
                    End If
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء قراءة الملف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function
End Class