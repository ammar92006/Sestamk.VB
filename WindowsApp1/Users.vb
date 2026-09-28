Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ClosedXML.Excel
Imports DevExpress.Utils.About
Imports DevExpress.XtraExport.Helpers
Imports Guna.UI2.WinForms
Imports ZXing
Imports System.Drawing
Imports ZXing.Common

Public Class Users
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim adapter As SqlDataAdapter
    Dim ds As New DataSet
    Dim cmdb As New SqlCommandBuilder
    Dim oldid As Integer
    Dim lastrow As Integer
    Public filePath As String
    Private User_Barcode_path As String = ""
    Private User_photo_path As String = ""


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        datagridviewsetup()
        LoadStaff()
        Try
            ' جلب الصف الخاص بالفورم من Session.Permissions
            If Session.HasPermission("Users", "CanAdd") = False Then btnNew.Visible = False
            If Session.HasPermission("Users", "CanEdit") = False Then btnEdit.Visible = False
            If Session.HasPermission("Users", "CanDelete") = False Then btnDelete.Visible = False
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل صلاحيات المنتجات: " & ex.Message)
        End Try
        Me.KeyPreview = True
        cmbSearchField.Items.AddRange({
        "كود المستخدم",
        "الاسم كامل",
        "اسم المستخدم",
        "كلمة المرور",
        "الحالة",
        "الموظف",
        "الملاحظات"
    })
        cmbSearchField.SelectedIndex = 1

    End Sub

    Private Sub Users_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, Guna2HtmlLabel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(code_user.Text) OrElse String.IsNullOrEmpty(username.Text) OrElse String.IsNullOrEmpty(password.Text) Then
        '    MsgBox("برجاء إدخال جميع الحقول: كود المستخدم، اسم المستخدم، وكلمة المرور.", MsgBoxStyle.Critical, "خطأ")
        '    Exit Sub
        'End If
        ''معرفة اخر صف يحتوي علي بيانات
        'Dim query1 As String = "SELECT COUNT(User_ID) AS NumberOfItems FROM Users_TBL WHERE User_ID IS NOT NULL"

        'Try
        '    Connect()
        '    ' تنفيذ الاستعلام
        '    Dim command As New SqlCommand(query1, Conn)
        '    Dim result As Object = command.ExecuteScalar()
        '    lastrow = Val(result) + 1
        'Catch ex As Exception
        '    MsgBox("حدث خطأ: " & ex.Message)
        'Finally
        '    Disconnect()
        'End Try


        'Try
        '    Connect()
        '    Dim query As String = "INSERT INTO Users_TBL (User_ID, User_Code, User_Name, User_username, User_password, User_Stats, User_Role, User_Note)
        '                       VALUES (@User_ID, @User_Code, @User_Name, @User_username, @User_password, @User_Stats, @User_Role, @User_Note)"
        '    Dim cmd As New SqlCommand(query, Conn)
        '    cmd.Parameters.AddWithValue("@User_ID", lastrow)
        '    cmd.Parameters.AddWithValue("@User_Code", code_user.Text)
        '    cmd.Parameters.AddWithValue("@User_Name", txt_user_full_name.Text)
        '    cmd.Parameters.AddWithValue("@User_username", username.Text)
        '    cmd.Parameters.AddWithValue("@User_password", password.Text)
        '    cmd.Parameters.AddWithValue("@User_Stats", txt_stats.Text)
        '    cmd.Parameters.AddWithValue("@User_Role", txt_role.Text)
        '    cmd.Parameters.AddWithValue("@User_Note", txt_nots.Text)
        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("✅ تم إضافة الوحدة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Disconnect()
        '    LoadData() ' لإعادة تحميل البيانات
        '    dgvUsers.CurrentCell = Nothing
        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء الإضافة: " & ex.Message)
        'End Try
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(txt_iduser.Text.Trim()) Then
        '    MsgBox("يرجي تحديد المستخدم أولاً ثم الحذف", MsgBoxStyle.Critical, "الحذف")
        '    Exit Sub
        'End If

        'Try
        '    If MessageBox.Show("هل أنت متأكد من حذف هذا المستخدم ؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '        Connect()
        '        Dim query As String = "DELETE FROM Users_TBL WHERE User_ID=@txt_iduser"
        '        Dim cmd As New SqlCommand(query, Conn)
        '        cmd.Parameters.AddWithValue("@txt_iduser", txt_iduser.Text.Trim())
        '        cmd.ExecuteNonQuery()
        '        Disconnect()
        '        MessageBox.Show("🗑️ تم حذف المستخدم بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        LoadData()
        '        dgvUsers.ClearSelection()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        '    dgvUsers.ClearSelection()
        'End Try


    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        '' التحقق من أن الصف الحالي صالح
        'If e.RowIndex >= 0 Then
        '    ' تحديد الصف المحدد
        '    Dim selectedRow As DataGridViewRow = dgvUsers.Rows(e.RowIndex)

        '    ' نقل البيانات إلى مربعات النص
        '    txt_iduser.Text = If(selectedRow.Cells(0).Value IsNot Nothing, selectedRow.Cells(0).Value.ToString(), "")  ' العمود الأول
        '    code_user.Text = If(selectedRow.Cells(1).Value IsNot Nothing, selectedRow.Cells(1).Value.ToString(), "")  ' العمود الأول
        '    username.Text = If(selectedRow.Cells(3).Value IsNot Nothing, selectedRow.Cells(3).Value.ToString(), "") ' العمود الثاني
        '    password.Text = If(selectedRow.Cells(4).Value IsNot Nothing, selectedRow.Cells(4).Value.ToString(), "") ' العمود الثالث
        '    txt_user_full_name.Text = If(selectedRow.Cells(2).Value IsNot Nothing, selectedRow.Cells(2).Value.ToString(), "")  ' العمود الأول
        '    txt_stats.Text = If(selectedRow.Cells(5).Value IsNot Nothing, selectedRow.Cells(5).Value.ToString(), "")  ' العمود الأول
        '    txt_nots.Text = If(selectedRow.Cells(7).Value IsNot Nothing, selectedRow.Cells(7).Value.ToString(), "") ' العمود الثاني
        '    txt_role.Text = If(selectedRow.Cells(6).Value IsNot Nothing, selectedRow.Cells(6).Value.ToString(), "") ' العمود الثالث

        '    If Not File.Exists(txt_user_full_name.Text) Then
        '        ' إذا لم يكن هناك مسار صالح، عرض صورة افتراضية
        '        Barcode.Image = My.Resources.DefaultBarcodeImage ' تأكد من إضافة صورة افتراضية في الموارد
        '    Else


        '        Barcode.Image = System.Drawing.Image.FromFile(txt_user_full_name.Text)

        '    End If
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim row As DataRow = ds.Tables("Users").Rows.Find(TXTSearch.Text.Trim)
        'If row IsNot Nothing Then
        '    oldid = row(0)
        '    code_user.Text = row(0)
        '    username.Text = row(1)
        '    password.Text = row(2)
        'Else
        '    MsgBox("كود المستخدم الذي تبحث عنه غير موجود", MsgBoxStyle.Critical, "بحث")
        'End If

        'Dim dv As DataView = ds.Tables("Users").DefaultView
        'Dim row As String
        'row = "كود المستخدم=" & txtSearch.Text
        'MsgBox(row)
        'dv.RowFilter = "كود المستخدم = " & txtSearch.Text
        'dgvUsers.DataSource = dv



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'Try
        '    If txt_iduser.Text = "" Then
        '        MessageBox.Show("من فضلك اختر المستخدم أولاً")
        '        Return
        '    End If

        '    Connect()
        '    Dim query As String = "UPDATE Users_TBL SET 

        '                        User_Code=@User_Code,
        '                        User_Name=@User_Name,
        '                        User_username=@username,
        '                        User_password=@password,
        '                        User_Stats=@Stats,
        '                        User_Role=@Role,
        '                        User_Note=@Note
        '                      WHERE User_ID=@User_ID"

        '    Dim cmd As New SqlCommand(query, Conn)
        '    cmd.Parameters.AddWithValue("@User_ID", txt_iduser.Text.Trim)
        '    cmd.Parameters.AddWithValue("@User_Code", code_user.Text)
        '    cmd.Parameters.AddWithValue("@User_Name", txt_user_full_name.Text)
        '    cmd.Parameters.AddWithValue("@username", username.Text)
        '    cmd.Parameters.AddWithValue("@password", password.Text)
        '    cmd.Parameters.AddWithValue("@Stats", txt_stats.Text)
        '    cmd.Parameters.AddWithValue("@Role", txt_role.Text)
        '    cmd.Parameters.AddWithValue("@Note", txt_nots.Text)
        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("✏️ تم تعديل البيانات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Disconnect()
        '    LoadData()
        '    dgvUsers.ClearSelection()
        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء التعديل: " & ex.Message)
        '    dgvUsers.ClearSelection()
        'End Try
    End Sub

    Private Sub dgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Users_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, Guna2HtmlLabel1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs)
        'txt_iduser.Clear()
        'code_user.Clear()
        'username.Clear()
        'password.Clear()
    End Sub

    Private Sub code_user_KeyDown(sender As Object, e As KeyEventArgs)
        'If e.KeyValue = Keys.Enter Then
        '    username.Focus()
        'End If
    End Sub

    Private Sub username_KeyDown(sender As Object, e As KeyEventArgs)
        'If e.KeyValue = Keys.Enter Then
        '    password.Focus()
        'End If
    End Sub

    Private Sub btn_new_barcode_Click(sender As Object, e As EventArgs)
        '        ' توليد الباركود وحفظه في مجلد
        '        Dim barcode As New BarcodeWriter()
        '        barcode.Format = BarcodeFormat.CODE_128 ' يمكنك تغيير نوع الباركود حسب الحاجة
        '        barcode.Options = New ZXing.Common.EncodingOptions With {
        '    .Width = 250,
        '    .Height = 100
        '}

        '        Dim combinedText As String = username.Text.Trim() & ":" & password.Text.Trim()

        '        ' توليد الباركود بناءً على النص المدمج
        '        Dim barcodeImage As Bitmap = barcode.Write(combinedText)

        '        ' تحديد المجلد لحفظ الصورة
        '        Dim folderPath As String = Path.Combine(Application.StartupPath, "Barcodes")
        '        If Not Directory.Exists(folderPath) Then
        '            Directory.CreateDirectory(folderPath) ' إنشاء المجلد إذا لم يكن موجوداً
        '        End If

        '        ' تحديد اسم الصورة (يمكنك إضافة كود المستخدم أو أي معرف آخر لجعل الاسم فريدًا)
        '        Dim fileName As String = "barcode_" & txt_iduser.Text.Trim() & ".png"
        '        filePath = Path.Combine(folderPath, fileName)

        '        ' حفظ الصورة في المجلد
        '        barcodeImage.Save(filePath, Imaging.ImageFormat.Png)

        '        ' حفظ المسار في قاعدة البيانات
        '        Try
        '            ' الاتصال بقاعدة البيانات
        '            Connect()

        '            ' استعلام لتحديث أو إضافة المسار في قاعدة البيانات
        '            Dim query As String = "UPDATE Users_TBL SET User_Name = @barcodePath WHERE User_ID = @userID"
        '            Dim cmd As New SqlCommand(query, Conn)
        '            cmd.Parameters.AddWithValue("@barcodePath", filePath) ' حفظ المسار
        '            cmd.Parameters.AddWithValue("@userID", txt_iduser.Text.Trim())

        '            cmd.ExecuteNonQuery()
        '            Disconnect()

        '            MessageBox.Show("تم إنشاء الباركود وحفظه بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            LoadData()
        '        Catch ex As Exception
        '            MessageBox.Show("حدث خطأ أثناء حفظ الباركود: " & ex.Message)
        '        End Try

    End Sub

    Private Sub btn_delet_Click(sender As Object, e As EventArgs)
        'Try
        '    If File.Exists(filePath) Then

        '        File.Delete(filePath)
        '    End If

        '    Dim filepathdb As String

        '    filepathdb = txt_user_full_name.Text

        '    If File.Exists(filepathdb) Then
        '        File.Delete(filepathdb)
        '    End If
        '    MessageBox.Show("تم حذف الباركود بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    LoadData()
        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء حذف الباركود: " & ex.Message)
        'End Try
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub LoadStaff()
        Try
            Dim cmd_LoadStaff As SqlCommand
            Dim da_LoadStaff As SqlDataAdapter
            Dim dt_LoadStaff As DataTable
            Using cn As SqlConnection = DBModule.NewConn()
                cmd_LoadStaff = New SqlCommand("SELECT RoleID, RoleName FROM Roles ORDER BY RoleID", cn)
                da_LoadStaff = New SqlDataAdapter(cmd_LoadStaff)
                dt_LoadStaff = New DataTable
                da_LoadStaff.Fill(dt_LoadStaff)
            End Using
            cmbRoleName.DataSource = dt_LoadStaff
            cmbRoleName.DisplayMember = "RoleName"
            cmbRoleName.ValueMember = "RoleID"
            cmbRoleName.SelectedIndex = -1
            cmbRoleName.TextAlign = HorizontalAlignment.Center

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub LoadUsers(Optional filter As String = "", Optional field As String = "")
        Using cn As SqlConnection = DBModule.NewConn()
            Dim query As String = "SELECT   
                                        U.User_ID,
                                        U.User_Code,
                                        U.User_Name,
                                        U.User_username,
                                        U.User_password,
                                        U.User_Stats,
                                        U.User_Note,
                                        U.RoleID,
                                        R.RoleName,
                                        U.User_Barcode_path,
                                        U.User_photo_path
                                        FROM Users_TBL AS U
                                        LEFT JOIN Roles AS R ON U.RoleID = R.RoleID"

            If filter <> "" Then
                Dim columnName As String = ""
                Select Case field
                    Case "كود المستخدم"
                        columnName = "User_Code"
                    Case "الاسم كامل"
                        columnName = "User_Name"
                    Case "اسم المستخدم"
                        columnName = "User_username"
                    Case "كلمة المرور"
                        columnName = "User_password"
                    Case "الحالة"
                        columnName = "User_Stats"
                    Case "الملاحظات"
                        columnName = "User_Note"
                    Case "الموظف"
                        columnName = "RoleName"
                End Select

                If columnName <> "" Then
                    query &= $" WHERE {columnName} LIKE @filter"
                End If
            End If

            Dim cmd As New SqlCommand(query, cn)
            If filter <> "" Then cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgv_Users.DataSource = dt
        End Using
        lblStatus.Text = "نشط غير"
        lblStatus.ForeColor = Color.Red
    End Sub

    Private Sub chkActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkUser_Stats.CheckedChanged
        If chkUser_Stats.Checked Then
            lblStatus.Text = "نشط"
            lblStatus.ForeColor = Color.Green
        Else
            lblStatus.Text = "نشط غير"
            lblStatus.ForeColor = Color.Red
        End If
    End Sub

    Private Sub dgv_Users_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Users.CellClick
        ' التحقق من أن الصف الحالي صالح
        If e.RowIndex >= 0 Then
            ' تحديد الصف المحدد
            Dim selectedRow As DataGridViewRow = dgv_Users.Rows(e.RowIndex)
            Dim value = selectedRow.Cells("User_Stats").Value

            ' نقل البيانات إلى مربعات النص
            txtUser_Code.Text = If(selectedRow.Cells(0).Value IsNot Nothing, selectedRow.Cells("User_Code").Value.ToString(), "")  ' العمود الأول
            txtUser_Name.Text = If(selectedRow.Cells(1).Value IsNot Nothing, selectedRow.Cells("User_Name").Value.ToString(), "")  ' العمود الأول
            txtUser_username.Text = If(selectedRow.Cells(3).Value IsNot Nothing, selectedRow.Cells("User_username").Value.ToString(), "") ' العمود الثاني
            txtUser_password.Text = If(selectedRow.Cells(4).Value IsNot Nothing, selectedRow.Cells("User_password").Value.ToString(), "")

            If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                Dim strValue As String = value.ToString().Trim().ToLower()
                chkUser_Stats.Checked = (strValue = "true" Or strValue = "1" Or strValue = "نعم" Or strValue = "active")
            Else
                chkUser_Stats.Checked = False
            End If
            cmbRoleName.Text = If(selectedRow.Cells(2).Value IsNot Nothing, selectedRow.Cells("RoleName").Value.ToString(), "")  ' العمود الأول
            txtUser_Note.Text = If(selectedRow.Cells(5).Value IsNot Nothing, selectedRow.Cells("User_Note").Value.ToString(), "")  ' العمود الأول

            User_Barcode_path = selectedRow.Cells("User_Barcode_path").Value.ToString()

            If Not File.Exists(User_Barcode_path) Then

                ' إذا لم يكن هناك مسار صالح، عرض صورة افتراضية
                pic_Barcode.Image = My.Resources.DefaultBarcodeImage

            Else

                ' تحميل الصورة بدون أن يحدث Lock للملف
                If pic_Barcode.Image IsNot Nothing Then
                    pic_Barcode.Image.Dispose()
                    pic_Barcode.Image = Nothing
                End If

                Using img As Drawing.Image = Drawing.Image.FromFile(User_Barcode_path)
                    pic_Barcode.Image = New Bitmap(img)  ' ← نسخ الصورة (Clone)
                End Using

            End If

            User_photo_path = selectedRow.Cells("User_photo_path").Value.ToString()
            If Not File.Exists(User_photo_path) Then
                ' إذا لم يكن هناك مسار صالح، عرض صورة افتراضية
                pic_user.Image = My.Resources.لايوجد_صورة_للمستخدم ' تأكد من إضافة صورة افتراضية في الموارد
            Else


                pic_user.Image = System.Drawing.Image.FromFile(User_photo_path)
            End If

        End If

    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub txtUser_Code_TextChanged(sender As Object, e As EventArgs) Handles txtUser_Code.TextChanged

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()


        If cmbSearchField.SelectedItem Is Nothing Then
            Return
        End If

        Dim field As String = cmbSearchField.SelectedItem.ToString()


        If keyword.Length < 1 Then
            LoadUsers() ' عرض الكل لو البحث فاضي
            Exit Sub
        End If

        LoadUsers(keyword, field)
    End Sub

    Private Sub btn_Staff_Click(sender As Object, e As EventArgs) Handles btn_Staff.Click
        Dim frm_Staff As New Staff
        frm_Staff.Show()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            '===========================
            ' 🔍 التحقق من الحقول المطلوبة
            '===========================
            If String.IsNullOrWhiteSpace(txtUser_Code.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال كود المستخدم.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtUser_Name.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال الاسم كامل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtUser_username.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال اسم المستخدم.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtUser_password.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال كلمة المرور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            '===========================
            ' 🔍 التحقق من عدم تكرار الكود
            '===========================
            If IsUserCodeExists(txtUser_Code.Text.Trim()) Then
                MessageBox.Show("⚠️ هذا الكود موجود بالفعل، لا يمكن تكراره.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            '===========================
            ' 🔌 بدء الاتصال
            '===========================
            Dim query As String =
                "INSERT INTO Users_TBL 
        (User_Code, User_Name, User_username, User_password, User_Stats, User_Note, RoleID, User_Barcode_path, User_photo_path)
        VALUES 
        (@User_Code, @User_Name, @User_username, @User_password, @User_Stats, @User_Note, @RoleID, @User_Barcode_path, @User_photo_path);"

            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@User_Code", txtUser_Code.Text.Trim())
                    cmd.Parameters.AddWithValue("@User_Name", txtUser_Name.Text.Trim())
                    cmd.Parameters.AddWithValue("@User_username", txtUser_username.Text.Trim())
                    cmd.Parameters.AddWithValue("@User_password", txtUser_password.Text.Trim())
                    cmd.Parameters.AddWithValue("@User_Stats", chkUser_Stats.Checked)
                    cmd.Parameters.AddWithValue("@User_Note", txtUser_Note.Text.Trim())
                    cmd.Parameters.AddWithValue("@RoleID", Convert.ToInt32(cmbRoleName.SelectedValue))
                    cmd.Parameters.AddWithValue("@User_Barcode_path",
                                                If(String.IsNullOrEmpty(User_Barcode_path), DBNull.Value, User_Barcode_path))
                    cmd.Parameters.AddWithValue("@User_photo_path",
                                                If(String.IsNullOrEmpty(User_photo_path), DBNull.Value, User_photo_path))

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            '===========================
            ' ✔ نجاح العملية
            '===========================
            MessageBox.Show("✅ تم إضافة المستخدم بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearFields()
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء إضافة المستخدم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ClearFields()
        User_photo_path = ""
        User_Barcode_path = ""
        cmbRoleName.SelectedValue = -1
        txtUser_Note.Clear()
        chkUser_Stats.Checked = False
        txtUser_password.Clear()
        txtUser_username.Clear()
        txtUser_Name.Clear()
        txtUser_Code.Clear()
        txtSearch.Clear()
        dgv_Users.ClearSelection()
        pic_Barcode.Image = Nothing ' تأكد من إضافة صورة افتراضية في الموارد
        pic_user.Image = Nothing ' تأكد من إضافة صورة افتراضية في الموارد

    End Sub

    Private Function IsUserCodeExists(customerCode As String, Optional excludeCustomerID As Integer = -1) As Boolean
        Dim exists As Boolean = False

        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Dim query As String = "SELECT COUNT(*) FROM Users_TBL WHERE User_Code = @User_Code"
                If excludeCustomerID <> -1 Then
                    query &= " AND CustomerID <> @id"
                End If

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@User_Code", customerCode)
                    If excludeCustomerID <> -1 Then
                        cmd.Parameters.AddWithValue("@id", excludeCustomerID)
                    End If

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    exists = (count > 0)
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء التحقق من الكود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return exists
    End Function

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearFields()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            ' التحقق من الحقول المطلوبة
            If String.IsNullOrWhiteSpace(txtUser_Code.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال كود المستخدم .", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If String.IsNullOrWhiteSpace(txtUser_Name.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال الاسم كامل .", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If String.IsNullOrWhiteSpace(txtUser_username.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال اسم المستخدم.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            'If IsUserCodeExists(txtUser_Code.Text.Trim()) Then
            '    MessageBox.Show("⚠️ هذا الكود موجود بالفعل، لا يمكن تكراره.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Return
            'End If



            Using cn As SqlConnection = DBModule.NewConn()
                Dim id As Integer = Convert.ToInt32(dgv_Users.SelectedRows(0).Cells("User_ID").Value)
                Dim query As String = "
        UPDATE Users_TBL
        SET 
            User_Code = @User_Code,
            User_Name = @User_Name,
            User_username = @User_username,
            User_password = @User_password,
            User_Stats = @User_Stats,
            User_Note = @User_Note,
            RoleID = @RoleID,
            User_Barcode_path = @User_Barcode_path,
            User_photo_path = @User_photo_path
        WHERE User_ID = @User_ID;"

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@User_ID", id)
                    cmd.Parameters.AddWithValue("@User_Code", txtUser_Code.Text.Trim())
                    cmd.Parameters.AddWithValue("@User_Name", txtUser_Name.Text.Trim())
                    cmd.Parameters.AddWithValue("@User_username", txtUser_username.Text.Trim())
                    cmd.Parameters.AddWithValue("@User_password", txtUser_password.Text.Trim())
                    cmd.Parameters.AddWithValue("@User_Stats", chkUser_Stats.Checked)
                    cmd.Parameters.AddWithValue("@User_Note", txtUser_Note.Text.Trim())
                    cmd.Parameters.AddWithValue("@RoleID", Convert.ToInt32(cmbRoleName.SelectedValue))
                    cmd.Parameters.AddWithValue("@User_Barcode_path", If(String.IsNullOrEmpty(User_Barcode_path), DBNull.Value, User_Barcode_path))
                    cmd.Parameters.AddWithValue("@User_photo_path", If(String.IsNullOrEmpty(User_photo_path), DBNull.Value, User_photo_path))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم تعديل بيانات المستخدم بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تعديل المستخدم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            ' التحقق من اختيار المستخدم
            If String.IsNullOrWhiteSpace(txtUser_Code.Text) Then
                MessageBox.Show("⚠️ يرجى اختيار المستخدم الذي تريد حذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تأكيد الحذف
            If MessageBox.Show("هل أنت متأكد من حذف هذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Using cn As SqlConnection = DBModule.NewConn()
                Dim id As Integer = Convert.ToInt32(dgv_Users.SelectedRows(0).Cells("User_ID").Value)
                Dim query As String = "DELETE FROM Users_TBL WHERE User_ID = @User_ID"

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@User_ID", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم حذف المستخدم بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حذف المستخدم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btn_barcode_new_Click(sender As Object, e As EventArgs) Handles btn_barcode_new.Click
        Try
            ' ----------------------------
            ' 1) جلب بيانات المستخدم
            ' ----------------------------
            Dim userID As Integer = Convert.ToInt32(dgv_Users.SelectedRows(0).Cells("User_ID").Value)
            Dim username As String = txtUser_username.Text.Trim()
            Dim password As String = txtUser_password.Text.Trim()
            Dim displayName As String = txtUser_Name.Text.Trim()

            ' ----------------------------
            ' 2) توليد الباركود النهائي
            ' ----------------------------
            Dim barcodeImage As Bitmap = GenerateBarcode(username, password, displayName)

            ' ----------------------------
            ' 3) حفظ الصورة
            ' ----------------------------
            Dim filePath As String = SaveBarcodeImage(userID, barcodeImage)

            ' ----------------------------
            ' 4) تحديث قاعدة البيانات
            ' ----------------------------
            UpdateBarcodePath(userID, filePath)

            ' ----------------------------
            ' 5) رسالة نجاح
            ' ----------------------------
            MessageBox.Show("✔ تم إنشاء الباركود بنجاح وتحديث المسار في قاعدة البيانات.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("❌ خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            LoadUsers()
            ClearFields()
        End Try
    End Sub
    Private Function GenerateBarcode(username As String, password As String, displayName As String) As Bitmap
        ' النص الذي سيدخل في الباركود
        Dim barcodeContent As String = username.Trim() & ":" & password.Trim()

        ' إعداد مولد الباركود
        Dim writer As New BarcodeWriter With {
        .Format = BarcodeFormat.CODE_128,
        .Options = New EncodingOptions With {
            .Width = 300,
            .Height = 100,
            .PureBarcode = True
        }
    }

        ' توليد صورة الباركود فقط
        Dim barcodeImage As Bitmap = writer.Write(barcodeContent)

        ' ========= إضافة نص أسفل الباركود ==========
        Dim finalHeight As Integer = barcodeImage.Height + 40
        Dim finalImage As New Bitmap(barcodeImage.Width, finalHeight)

        Using g As Graphics = Graphics.FromImage(finalImage)
            g.Clear(Color.White)

            ' رسم الباركود
            g.DrawImage(barcodeImage, 0, 0)

            ' اسم المستخدم أسفل الباركود
            Dim font As New Font("Arial", 12, FontStyle.Bold)
            Dim textSize As SizeF = g.MeasureString(displayName, font)
            Dim textX As Single = (finalImage.Width - textSize.Width) / 2
            Dim textY As Single = barcodeImage.Height + 5

            g.DrawString(displayName, font, Brushes.Black, textX, textY)
        End Using

        Return finalImage
    End Function
    Private Function SaveBarcodeImage(userID As Integer, barcodeImage As Bitmap) As String
        Dim folderPath As String = Path.Combine(Application.StartupPath, "Barcodes")
        If Not Directory.Exists(folderPath) Then Directory.CreateDirectory(folderPath)

        Dim filePath As String = Path.Combine(folderPath, $"barcode_{userID}.png")

        If File.Exists(filePath) Then File.Delete(filePath)

        barcodeImage.Save(filePath, Imaging.ImageFormat.Png)

        Return filePath
    End Function
    Private Sub UpdateBarcodePath(userID As Integer, path As String)
        Using cn As SqlConnection = DBModule.NewConn()
            Using cmd As New SqlCommand("UPDATE Users_TBL SET User_Barcode_path = @path WHERE User_ID = @id", cn)
                cmd.Parameters.AddWithValue("@path", path)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub btn_delet_barcode_Click(sender As Object, e As EventArgs) Handles btn_delet_barcode.Click
        Try
            ' التحقق من اختيار المستخدم
            If dgv_Users.SelectedRows.Count = 0 Then
                MessageBox.Show("⚠️ يرجى اختيار المستخدم أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim id As Integer = Convert.ToInt32(dgv_Users.SelectedRows(0).Cells("User_ID").Value)
            Dim filePath As String = Convert.ToString(dgv_Users.SelectedRows(0).Cells("User_Barcode_path").Value)

            ' تأكيد الحذف
            If MessageBox.Show("هل أنت متأكد من حذف الباركود لهذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            ' حذف الملف من المجلد إذا موجود
            If Not String.IsNullOrEmpty(filePath) AndAlso File.Exists(filePath) Then
                File.Delete(filePath)
            End If

            ' تحديث قاعدة البيانات لإزالة المسار
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlCommand("UPDATE Users_TBL SET User_Barcode_path = NULL WHERE User_ID = @userID", cn)
                    cmd.Parameters.AddWithValue("@userID", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم حذف الباركود ومساره من قاعدة البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show("❌ حدث خطأ أثناء حذف الباركود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click

        'Try
        '    ' توليد الباركود
        '    Dim barcode As New BarcodeWriter() With {
        '        .Format = BarcodeFormat.CODE_128,
        '        .Options = New ZXing.Common.EncodingOptions With {
        '            .Width = 250,
        '            .Height = 100,
        '            .PureBarcode = True ' إزالة النص أسفل الباركود
        '        }
        '    }

        '    ' دمج اسم المستخدم وكلمة المرور كنص الباركود
        '    Dim combinedText As String = txtUser_username.Text.Trim() & ":" & txtUser_password.Text.Trim()
        '    Using originalBarcode As Bitmap = barcode.Write(combinedText)
        '        ' نسخ الصورة لتفادي مشكلة الملف المفتوح
        '        Using barcodeImage As New Bitmap(originalBarcode)
        '            ' تحديد المجلد لحفظ الباركود
        '            Dim folderPath As String = Path.Combine(Application.StartupPath, "Barcodes")
        '            If Not Directory.Exists(folderPath) Then Directory.CreateDirectory(folderPath)

        '            ' الحصول على معرف المستخدم
        '            Dim id As Integer = Convert.ToInt32(dgv_Users.SelectedRows(0).Cells("User_ID").Value)
        '            Dim fileName As String = $"barcode_{id}.png"
        '            Dim filePath As String = Path.Combine(folderPath, fileName)

        '            ' حذف الملف القديم لو موجود
        '            If File.Exists(filePath) Then
        '                File.Delete(filePath)
        '            End If

        '            ' حفظ الصورة الجديدة
        '            barcodeImage.Save(filePath, Imaging.ImageFormat.Png)

        '            ' تحديث المسار في قاعدة البيانات
        '            Connect()
        '            Using cmd As New SqlCommand("UPDATE Users_TBL SET User_Barcode_path = @barcodePath WHERE User_ID = @userID", Conn)
        '                cmd.Parameters.AddWithValue("@barcodePath", filePath)
        '                cmd.Parameters.AddWithValue("@userID", id)
        '                cmd.ExecuteNonQuery()
        '            End Using
        '            Disconnect()
        '        End Using
        '    End Using

        '    MessageBox.Show("✅ تم إنشاء الباركود الجديد واستبداله بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Catch ex As Exception
        '    MessageBox.Show("❌ حدث خطأ أثناء حفظ الباركود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    LoadUsers()
        '    ClearFields()
        'End Try

        Try

            ' إنشاء مربع حوار لاختيار الصورة
            Dim ofd As New OpenFileDialog With {
                .Filter = "صور (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif",
                .Title = "اختر الصورة"
            }

            If ofd.ShowDialog() = DialogResult.OK Then
                ' المسار الأصلي للصورة
                Dim sourcePath As String = ofd.FileName

                ' مجلد الحفظ
                Dim photosFolder As String = Path.Combine(Application.StartupPath, "photos_user")

                ' إنشاء المجلد لو مش موجود
                If Not Directory.Exists(photosFolder) Then
                    Directory.CreateDirectory(photosFolder)
                End If

                ' اسم الصورة الجديدة (مثلاً حسب التاريخ والوقت لتجنب التكرار)
                Dim id As Integer = Convert.ToInt32(dgv_Users.SelectedRows(0).Cells("User_ID").Value)
                Dim newFileName As String = "user_" & id & Path.GetExtension(sourcePath)
                Dim destinationPath As String = Path.Combine(photosFolder, newFileName)

                ' نسخ الصورة
                File.Copy(sourcePath, destinationPath, True)
                Using cn As SqlConnection = DBModule.NewConn()
                    Using cmd As New SqlCommand("UPDATE Users_TBL SET User_photo_path = @User_photo_path WHERE User_ID = @userID", cn)
                        cmd.Parameters.AddWithValue("@User_photo_path", destinationPath)
                        cmd.Parameters.AddWithValue("@userID", id)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                ' عرض الصورة في PictureBox (لو عندك)

                pic_user.Image = System.Drawing.Image.FromFile(destinationPath)


                ' حفظ المسار الجديد في متغير
                Dim imagePath As String = destinationPath

                ' لو عايز تخزنها في TextBox مثلاً
                'txtImagePath.Text = imagePath

                MessageBox.Show("✅ تم حفظ الصورة بنجاح في المسار:" & vbCrLf & imagePath, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حفظ الصورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            LoadUsers()
            ClearFields()
        End Try
    End Sub

    Private Sub Users_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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
                LoadUsers()         ' إعادة تحميل الجدول مثلاً
                    ' إعادة تحميل الجدول مثلاً

            Case Keys.Escape
                Me.Close()              ' خروج من الفورم
        End Select
    End Sub

    Private Sub btn_barcode_print_Click(sender As Object, e As EventArgs) Handles btn_barcode_print.Click
        PrintUserBarcode()
    End Sub

    Private Sub PrintUserBarcode()
        Try
            ' ==============================
            ' 1) فحص القيم قبل الطباعة
            ' ==============================
            If String.IsNullOrWhiteSpace(txtUser_username.Text) Then
                MsgBox("من فضلك أدخل اسم المستخدم.", vbExclamation)
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUser_password.Text) Then
                MsgBox("من فضلك أدخل كلمة المرور.", vbExclamation)
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUser_Name.Text) Then
                MsgBox("من فضلك أدخل الاسم الكامل للمستخدم.", vbExclamation)
                Exit Sub
            End If

            ' ==============================
            ' 2) تكوين قيمة الباركود
            ' ==============================
            Dim username As String = txtUser_username.Text.Trim()
            Dim password As String = txtUser_password.Text.Trim()
            Dim fullName As String = txtUser_Name.Text.Trim()
            Dim barcodeValue As String = $"{username}:{password}"

            ' الفوتر (النص الذي يظهر أسفل من الإعدادات)
            Dim shopName = SettingsManager.GetSettingDual(SettingsKeys.ShopName, SettingsKeys.StoreName, "سستمك")
            Dim shopPhone = SettingsManager.GetSettingDual(SettingsKeys.ShopPhone, SettingsKeys.StorePhone, "")
            Dim footerText As String = If(Not String.IsNullOrWhiteSpace(shopPhone), $"{shopName} - {shopPhone}", shopName)

            ' ==============================
            ' 3) إعداد الطباعة (يقرأ اسم طابعة الباركود من الإعدادات)
            ' ==============================
            Dim barcodePrinterName As String = SettingsManager.GetSetting(SettingsKeys.BarcodePrinterName)
            If String.IsNullOrEmpty(barcodePrinterName) Then
                barcodePrinterName = SettingsManager.GetSettingDual(SettingsKeys.ThermalPrinterName, SettingsKeys.DefaultPrinterName, "")
            End If

            Dim pd As New PrintDocument()
            pd.PrinterSettings = New PrinterSettings With {
                .PrinterName = barcodePrinterName
            }

            pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
            pd.OriginAtMargins = False

            ' ==============================
            ' 4) حدث الطباعة
            ' ==============================
            AddHandler pd.PrintPage,
Sub(s, ev)
    Dim labelWidthPx As Integer = ev.PageBounds.Width
    Dim startY As Integer = 3

    ' ===== إعداد الباركود (ZXing) =====
    Dim writer As New ZXing.BarcodeWriter()
    writer.Format = ZXing.BarcodeFormat.CODE_128
    writer.Options = New ZXing.Common.EncodingOptions With {
        .Height = 60,
        .Width = labelWidthPx - 10,
        .Margin = 0,
        .PureBarcode = True
    }

    Dim barcodeImg As Bitmap = writer.Write(barcodeValue)

    ' رسم الباركود (محاذاة من اليمين كما في كودك)
    Dim barcodeX As Integer = (labelWidthPx - barcodeImg.Width) - 18
    ev.Graphics.DrawImage(barcodeImg, barcodeX, startY)

    ' ===== كتابة الاسم الكامل تحت الباركود =====
    Dim nameFont As New Font("Arial", 8, FontStyle.Bold)
    Dim textY As Single = startY + barcodeImg.Height + 5

    Dim nameSize As SizeF = ev.Graphics.MeasureString(fullName, nameFont)
    Dim nameX As Single = (labelWidthPx - nameSize.Width) - 45
    ev.Graphics.DrawString(fullName, nameFont, Brushes.Black, nameX, textY)

    ' ===== كتابة الفوتر تحت الاسم =====
    Dim footerFont As New Font("Arial", 7, FontStyle.Bold)
    Dim footerSize As SizeF = ev.Graphics.MeasureString(footerText, footerFont)
    Dim footerY As Single = textY + nameSize.Height + 2
    Dim footerX As Single = (labelWidthPx - footerSize.Width) - 20

    ev.Graphics.DrawString(footerText, footerFont, Brushes.Black, footerX, footerY)

    ev.HasMorePages = False
End Sub

            ' ==============================
            ' 5) الطباعة مباشرة
            ' ==============================
            pd.Print()

        Catch ex As Exception
            MsgBox("خطأ أثناء الطباعة: " & ex.Message)
        End Try
    End Sub




    'Public Sub SendRawToPrinter(printerName As String, data As String)
    '    Dim bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(data)
    '    RawPrinterHelper.SendBytesToPrinter(printerName, bytes, bytes.Length)
    'End Sub




    Private Sub datagridviewsetup()
        With dgv_Users
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
            .ColumnHeadersHeight = 70
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


            .Columns("RoleID").Visible = False
            .Columns("User_ID").Visible = False
            .Columns("User_photo_path").Visible = False

            ' ✅ عناوين الأعمدة
            .Columns("User_Code").HeaderText = "كود المستخدم"
            .Columns("User_Name").HeaderText = "الاسم كامل"
            .Columns("User_username").HeaderText = "اسم المستخدم"
            .Columns("User_password").HeaderText = "كلمة المرور"
            .Columns("User_Stats").HeaderText = "الحالة"
            .Columns("User_Note").HeaderText = "الملاحظات"
            .Columns("RoleName").HeaderText = "الموظف"
            .Columns("User_Barcode_path").HeaderText = "الباركود"

            ' الترتيب
            .Columns("User_Code").DisplayIndex = 0
            .Columns("User_Name").DisplayIndex = 1
            .Columns("User_username").DisplayIndex = 2
            .Columns("User_password").DisplayIndex = 3
            .Columns("RoleName").DisplayIndex = 4
            .Columns("User_Note").DisplayIndex = 5
            .Columns("User_Barcode_path").DisplayIndex = 6
            .Columns("User_Stats").DisplayIndex = 7
            '.Columns("Product_State").DisplayIndex = 8
            '.Columns("CustomerName").Width = 300
            '.Columns("IsActive").Width = 60


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
End Class