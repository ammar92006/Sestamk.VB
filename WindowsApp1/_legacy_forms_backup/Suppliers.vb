Imports System.Data.SqlClient
Imports Guna.UI2.WinForms

Public Class Suppliers

    Dim x, y As Integer
    Dim newpoint As New Point
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

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Suppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearchField.Items.Add("كود المورد")
        cmbSearchField.Items.Add("اسم المورد")
        cmbSearchField.Items.Add("اسم الشركة")
        cmbSearchField.Items.Add("رقم الهاتف")
        cmbSearchField.Items.Add("العنوان")
        cmbSearchField.Items.Add("الحالة")
        cmbSearchField.Items.Add("الملاحظات")


        cmbSearchField.SelectedIndex = 1
        Me.KeyPreview = True
        LoadSuppliers()
        Datagridviewsetup()
        GetMaxProductCode()

    End Sub

    Private Sub GetMaxProductCode()
        Connect()
        Try
            Dim maxCode As Integer = 0

            Using cmd As New SqlClient.SqlCommand("SELECT ISNULL(MAX(CAST(SuppliersCode AS INT)), 0) 
                                                    FROM Suppliers
                                                    WHERE ISNUMERIC(SuppliersCode) = 1
                                                    ", Conn)
                maxCode = Convert.ToInt32(cmd.ExecuteScalar())
                Disconnect()
            End Using


            txtSupplierCode.Text = (maxCode + 1).ToString()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء جلب كود المنتج: " & ex.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Datagridviewsetup()
        With dgvSuppliers
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .DefaultCellStyle.SelectionBackColor = Color.RoyalBlue

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
            .Columns("SuppliersID").Visible = False

            ' ✅ عناوين الأعمدة
            .Columns("SuppliersCode").HeaderText = "كود المورد"
            .Columns("SuppliersName").HeaderText = "اسم المورد"
            .Columns("PhoneNumber").HeaderText = "رقم الهاتف"
            .Columns("Address").HeaderText = "العنوان"
            .Columns("Companyname").HeaderText = "اسم الشركة"
            .Columns("CurrentBalance").HeaderText = "الرصيد الحالي"
            .Columns("IsActive").HeaderText = "الحالة"
            .Columns("Notes").HeaderText = "الملاحظات"
            .Columns("CreatedAt").HeaderText = "تاريخ الاضافة"
            .Columns("UpdatedAt").HeaderText = "تاريخ اخر تحديث"
            .Columns("ProductsCount").HeaderText = "عدد المنتجات"

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
        Try
            ' التحقق من الحقول المطلوبة
            If String.IsNullOrWhiteSpace(txtSupplierCode.Text) OrElse String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال كود واسم العميل على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تحقق من وجود كود العميل مسبقًا
            If IsSupplierCodeExists(txtSupplierCode.Text.Trim()) Then
                MessageBox.Show("⚠️ هذا الكود موجود بالفعل، لا يمكن تكراره.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تنفيذ عملية الإضافة
            Using Conn
                Connect()

                Dim query As String = "
            INSERT INTO Suppliers (SuppliersCode, SuppliersName, PhoneNumber, Address, Companyname, CurrentBalance, IsActive, Notes, CreatedAt)
            VALUES (@Code, @Name, @Phone, @Address, @Limit, @CurrentBalance, @Active, @Notes, GETDATE())"

                Using cmd As New SqlCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@Code", txtSupplierCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Limit", txtCompanyname.Text.Trim)
                    cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(If(String.IsNullOrEmpty(txtBalance.Text), 0, txtBalance.Text)))
                    cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم إضافة المورد بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadSuppliers()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء إضافة المورد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub ClearFields()
        txtSearch.Clear()
        txtSupplierCode.Clear()
        txtSupplierName.Clear()
        txtCreatedAt.Clear()
        txtUpdatedAt.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        txtCompanyname.Clear()
        txtBalance.Clear()
        chkActive.Checked = True
        txtNotes.Clear()
        dgvSuppliers.ClearSelection()
    End Sub

    Private Function IsSupplierCodeExists(SuppliersCode As String, Optional excludeCustomerID As Integer = -1) As Boolean
        Dim exists As Boolean = False

        Try
            Connect()

            Dim query As String = "SELECT COUNT(*) FROM Suppliers WHERE SuppliersCode = @code"
            If excludeCustomerID <> -1 Then
                query &= " AND SuppliersID <> @id"
            End If

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@code", SuppliersCode)
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

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()
        lstSuggestions.Items.Clear()

        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            LoadSuppliers() ' عرض الكل لو البحث فاضي
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

        LoadSuppliers(keyword, field)
    End Sub

    Private Function GetSuggestions(field As String, keyword As String) As List(Of String)
        Dim suggestions As New List(Of String)()

        Dim columnName As String = ""
        Select Case field
            Case "كود المورد"
                columnName = "SuppliersCode"
            Case "اسم المورد"
                columnName = "SuppliersName"
            Case "رقم الهاتف"
                columnName = "PhoneNumber"
            Case "اسم الشركة"
                columnName = "Companyname"
            Case "العنوان"
                columnName = "Address"
            Case "الحالة"
                columnName = "IsActive"
            Case "الملاحظات"
                columnName = "Notes"
        End Select

        Using Conn
            Connect()
            Dim query As String = $"SELECT {columnName} FROM Suppliers WHERE {columnName} LIKE @keyword"
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
        '    LoadSuppliers(txtSearch.Text)
        'End If
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txtSearch.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
            'LoadCustomers(txtSearch.Text)
            Dim keyword As String = txtSearch.Text.Trim()
            Dim field As String = cmbSearchField.SelectedItem.ToString()
            LoadSuppliers(keyword, field)

            If dgvSuppliers.Rows.GetRowCount(DataGridViewElementStates.Visible) = 1 Then

                Dim visibleRow As DataGridViewRow =
                    dgvSuppliers.Rows.Cast(Of DataGridViewRow)().
                    First(Function(r) r.Visible)

                Dim visibleCell As DataGridViewCell =
                    visibleRow.Cells.Cast(Of DataGridViewCell)().
                    First(Function(c) c.Visible)

                dgvSuppliers.ClearSelection()
                visibleRow.Selected = True
                dgvSuppliers.CurrentCell = visibleCell

                Selectrow(visibleRow.Index)

            End If
        End If
    End Sub
    Private Sub Selectrow(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvSuppliers.Rows.Count Then Exit Sub

        Dim row As DataGridViewRow = dgvSuppliers.Rows(rowIndex)
        Try
            txtSupplierCode.Text = row.Cells("SuppliersCode").Value.ToString()
            txtSupplierName.Text = row.Cells("SuppliersName").Value.ToString()
            txtPhone.Text = row.Cells("PhoneNumber").Value.ToString()
            txtAddress.Text = row.Cells("Address").Value.ToString()
            txtCompanyname.Text = row.Cells("Companyname").Value.ToString
            txtBalance.Text = row.Cells("CurrentBalance").Value.ToString()
            chkActive.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
            txtNotes.Text = row.Cells("Notes").Value.ToString()
            txtCreatedAt.Text = row.Cells("CreatedAt").Value.ToString()
            txtUpdatedAt.Text = row.Cells("UpdatedAt").Value.ToString()
        Catch ex As Exception
            MessageBox.Show("خطأ: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearFields()
        GetMaxProductCode()
    End Sub

    Private Sub dgvSuppliers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSuppliers.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvSuppliers.Rows(e.RowIndex)
            txtSupplierCode.Text = row.Cells("SuppliersCode").Value.ToString()
            txtSupplierName.Text = row.Cells("SuppliersName").Value.ToString()
            txtPhone.Text = row.Cells("PhoneNumber").Value.ToString()
            txtAddress.Text = row.Cells("Address").Value.ToString()
            txtCompanyname.Text = row.Cells("Companyname").Value.ToString
            txtBalance.Text = row.Cells("CurrentBalance").Value.ToString()
            chkActive.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
            txtNotes.Text = row.Cells("Notes").Value.ToString()
            txtCreatedAt.Text = row.Cells("CreatedAt").Value.ToString()
            txtUpdatedAt.Text = row.Cells("UpdatedAt").Value.ToString()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            ' التحقق من اختيار المورد من الجدول
            If dgvSuppliers.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى اختيار المورد أولاً من الجدول.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' جلب المعرف (ID) للمورد المحدد
            Dim supplierID As Integer = Convert.ToInt32(dgvSuppliers.SelectedRows(0).Cells("SuppliersID").Value)

            ' التحقق من الحقول المطلوبة
            If String.IsNullOrWhiteSpace(txtSupplierCode.Text) OrElse String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال كود واسم المورد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تحقق من تكرار الكود لمورد آخر
            If IsSupplierCodeExists(txtSupplierCode.Text.Trim(), supplierID) Then
                MessageBox.Show("⚠️ هذا الكود مستخدم من قبل مورد آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using Conn
                Connect()
                Dim query As String = "
            UPDATE Suppliers
            SET 
                SuppliersCode = @Code,
                SuppliersName = @Name,
                PhoneNumber = @Phone,
                Address = @Address,
                Companyname = @Company,
                CurrentBalance = @CurrentBalance,
                IsActive = @Active,
                Notes = @Notes,
                UpdatedAt = GETDATE()
            WHERE SuppliersID = @ID"

                Using cmd As New SqlCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@Code", txtSupplierCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Company", txtCompanyname.Text.Trim())
                    cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(If(String.IsNullOrEmpty(txtBalance.Text), 0, txtBalance.Text)))
                    cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                    cmd.Parameters.AddWithValue("@ID", supplierID)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم تعديل بيانات المورد بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadSuppliers()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تعديل المورد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            ' التحقق من اختيار المورد
            If dgvSuppliers.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى اختيار المورد المراد حذفه أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim supplierID As Integer = Convert.ToInt32(dgvSuppliers.SelectedRows(0).Cells("SuppliersID").Value)
            Dim supplierName As String = dgvSuppliers.SelectedRows(0).Cells("SuppliersName").Value.ToString()

            ' تأكيد الحذف
            Dim result = MessageBox.Show($"هل أنت متأكد أنك تريد حذف المورد ({supplierName})؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then Return

            Using Conn
                Connect()
                Dim query As String = "DELETE FROM Suppliers WHERE SuppliersID = @ID"

                Using cmd As New SqlCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@ID", supplierID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("🗑️ تم حذف المورد بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadSuppliers()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حذف المورد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            Disconnect()
        End Try

    End Sub

    Private Sub Suppliers_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.F Then
            e.SuppressKeyPress = True ' يمنع مرور الاختصار للنظام
            e.Handled = True           ' يمنع أي أكواد أخرى من التعامل مع نفس الحدث
            txtSearch.Focus()
        End If



        If (e.Alt AndAlso e.KeyCode = Keys.F4) OrElse (e.KeyCode = Keys.Escape) Then
            e.Handled = True
            Me.Close()
        End If


        If (e.Control AndAlso e.KeyCode = Keys.N) OrElse e.KeyCode = Keys.F2 Then
            btnNew.PerformClick()
        End If


        Select Case e.KeyCode
            Case Keys.F1
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

            Case Keys.F3
                btnEdit.PerformClick()  ' زر التعديل

            Case Keys.F4
                btnDelete.PerformClick() ' زر الحذف

            Case Keys.F6
                ClearFields()' زر مسح الحقول

            Case Keys.F5
                LoadSuppliers()         ' إعادة تحميل الجدول مثلاً
                    ' إعادة تحميل الجدول مثلاً

            Case Keys.Escape
                Me.Close()              ' خروج من الفورم
        End Select

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
        SplitBalance(txtBalance, txtDebit, txtCredit)
    End Sub

    Private Sub dgvSuppliers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSuppliers.CellDoubleClick
        'Try
        '    If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        '    ' خزن اسم القسم من العمود المطلوب
        '    Dim sectionName As String = dgvSuppliers.Rows(e.RowIndex).Cells("SuppliersName").Value.ToString()

        '    ' تحقق إذا الفورم شغال بالفعل
        '    Dim frm As Products = Nothing
        '    For Each f As Form In Application.OpenForms
        '        If TypeOf f Is Products Then
        '            frm = CType(f, Products)
        '            Exit For
        '        End If
        '    Next

        '    If frm Is Nothing Then
        '        ' افتح الفورم لأول مرة
        '        frm = New Products
        '        frm.Show()
        '    Else
        '        ' لو موجود بالفعل اعرضه قدام
        '        frm.BringToFront()
        '    End If

        '    ' اختياري: اختر القسم في ComboBox حسب الاسم أو Index
        '    Try
        '        frm.cmbSearchField.SelectedIndex = 5
        '    Catch
        '    End Try

        '    ' ضع النص في TextBox وشغل TextChanged
        '    Try
        '        frm.txtSearch.Text = sectionName
        '        ' تشغيل الحدث يدويًا لضمان ظهور الاقتراحات وتنفيذ LoadProducts
        '        frm.txtSearch_TextChanged(frm.txtSearch, EventArgs.Empty)
        '    Catch
        '    End Try

        'Catch ex As Exception
        '    ' تجاهل أي خطأ بصمت
        'End Try
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

    Private Sub LoadSuppliers(Optional filter As String = "", Optional field As String = "")
        'Using Conn
        '    Dim query As String = "SELECT SuppliersID, SuppliersCode, SuppliersName, PhoneNumber, Address, Companyname, CurrentBalance, IsActive, Notes , CreatedAt , UpdatedAt FROM Suppliers"
        '    Connect()


        '    If filter <> "" Then
        '        Dim columnName As String = ""
        '        Select Case field
        '            Case "كود المورد"
        '                columnName = "SuppliersCode"
        '            Case "اسم المورد"
        '                columnName = "SuppliersName"
        '            Case "رقم الهاتف"
        '                columnName = "PhoneNumber"
        '            Case "العنوان"
        '                columnName = "Address"
        '            Case "الحالة"
        '                columnName = "IsActive"
        '            Case "الملاحظات"
        '                columnName = "Notes"
        '            Case "تاريخ الاضافة"
        '                columnName = "CreatedAt"
        '            Case "تاريخ اخر تحديث"
        '                columnName = "UpdatedAt"
        '        End Select

        '        If columnName <> "" Then
        '            query &= $" WHERE {columnName} LIKE @filter"
        '        End If
        '    End If

        '    Dim cmd As New SqlCommand(query, Conn)
        '    If filter <> "" Then cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")

        '    Dim da As New SqlDataAdapter(cmd)
        '    Dim dt As New DataTable()
        '    da.Fill(dt)

        '    dgvSuppliers.DataSource = dt
        '    'Disconnect()
        'End Using

        '''' الاصدار السابق
        lblStatus.Text = "نشط غير"
        lblStatus.ForeColor = Color.Red

        txtSupplierCode.Clear()
        txtSupplierName.Clear()
        txtCreatedAt.Clear()
        txtUpdatedAt.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        txtCompanyname.Clear()
        txtBalance.Clear()
        chkActive.Checked = True
        txtNotes.Clear()
        dgvSuppliers.ClearSelection()

        Using Conn
            Connect()

            ' تحديث عدد المنتجات لكل مورد
            Dim updateQuery As String =
        "UPDATE S
         SET ProductsCount = ISNULL(P.Cnt, 0)
         FROM Suppliers S
         LEFT JOIN (
             SELECT Partner_ID, COUNT(*) AS Cnt
             FROM Products
             GROUP BY Partner_ID
         ) P ON S.SuppliersID = P.Partner_ID"

            Using updateCmd As New SqlCommand(updateQuery, Conn)
                updateCmd.ExecuteNonQuery()
            End Using
        End Using

        Dim query As String = "SELECT SuppliersID, SuppliersCode, SuppliersName, PhoneNumber, Address, Companyname, CurrentBalance,ProductsCount, IsActive, Notes , CreatedAt , UpdatedAt FROM Suppliers"
        Dim columnName As String = ""

        If filter <> "" Then
            Select Case field
                Case "كود المورد" : columnName = "SuppliersCode"
                Case "اسم المورد" : columnName = "SuppliersName"
                Case "رقم الهاتف" : columnName = "PhoneNumber"
                Case "العنوان" : columnName = "Address"
                Case "اسم الشركة" : columnName = "Companyname"
                Case "الحالة" : columnName = "IsActive"
                Case "الملاحظات" : columnName = "Notes"
                Case "تاريخ الاضافة" : columnName = "CreatedAt"
                Case "تاريخ اخر تحديث" : columnName = "UpdatedAt"
                Case "عدد المنتجات" : columnName = "ProductsCount"
            End Select

            If columnName <> "" Then
                query &= $" WHERE {columnName} LIKE @filter"
            End If
        End If

        Using Conn
            Connect()

            Using cmd As New SqlCommand(query, Conn)
                If filter <> "" Then cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvSuppliers.AutoGenerateColumns = True
                dgvSuppliers.DataSource = dt
                dgvSuppliers.Visible = True
                dgvSuppliers.BringToFront()
                dgvSuppliers.Refresh()
            End Using
        End Using


        ''''اصدار تجريبي


    End Sub



End Class