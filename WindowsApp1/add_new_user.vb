Imports System.Data.SqlClient

Public Class add_new_user
    Dim x, y As Integer
    Dim newpoint As New Point
    Private User_Barcode_path As String = ""
    Private User_photo_path As String = ""
    Private Sub LoadStaff()
        Try
            Dim cmd_LoadStaff As SqlCommand
            Dim da_LoadStaff As SqlDataAdapter
            Dim dt_LoadStaff As DataTable
            Connect()
            cmd_LoadStaff = New SqlCommand("SELECT RoleID, RoleName FROM Roles ORDER BY RoleID", Conn)
            da_LoadStaff = New SqlDataAdapter(cmd_LoadStaff)
            dt_LoadStaff = New DataTable
            da_LoadStaff.Fill(dt_LoadStaff)
            cmbRoleName.DataSource = dt_LoadStaff
            cmbRoleName.DisplayMember = "RoleName"
            cmbRoleName.ValueMember = "RoleID"
            cmbRoleName.SelectedIndex = -1
            cmbRoleName.TextAlign = HorizontalAlignment.Center

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
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
            Connect()

            Dim query As String =
                "INSERT INTO Users_TBL 
        (User_Code, User_Name, User_username, User_password, User_Stats, User_Note, RoleID, User_Barcode_path, User_photo_path)
        VALUES 
        (@User_Code, @User_Name, @User_username, @User_password, @User_Stats, @User_Note, @RoleID, @User_Barcode_path, @User_photo_path);"

            Using cmd As New SqlCommand(query, Conn)

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

            '===========================
            ' ✔ نجاح العملية
            '===========================
            MessageBox.Show("✅ تم إضافة المستخدم بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearFields()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء إضافة المستخدم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub
    Private Function IsUserCodeExists(customerCode As String, Optional excludeCustomerID As Integer = -1) As Boolean
        Dim exists As Boolean = False

        Try
            Connect()

            Dim query As String = "SELECT COUNT(*) FROM Users_TBL WHERE User_Code = @User_Code"
            If excludeCustomerID <> -1 Then
                query &= " AND CustomerID <> @id"
            End If

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@User_Code", customerCode)
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
    Private Sub ClearFields()
        User_photo_path = ""
        User_Barcode_path = ""
        cmbRoleName.SelectedValue = -1
        txtUser_Note.Clear()
        chkUser_Stats.Checked = True
        txtUser_password.Clear()
        txtUser_username.Clear()
        txtUser_Name.Clear()
        txtUser_Code.Clear()
        pic_Barcode.Image = Nothing ' تأكد من إضافة صورة افتراضية في الموارد
        pic_user.Image = Nothing ' تأكد من إضافة صورة افتراضية في الموارد

    End Sub

    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click
        Try

            ' إنشاء مربع حوار لاختيار الصورة
            Dim ofd As New OpenFileDialog With {
                .Filter = "صور (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif",
                .Title = "اختر الصورة"
            }

            If ofd.ShowDialog() = DialogResult.OK Then
                ' المسار الأصلي للصورة
                'Dim sourcePath As String = ofd.FileName
                User_photo_path = ofd.FileName
                ' مجلد الحفظ
                'Dim photosFolder As String = Path.Combine(System.Windows.Forms.Application.StartupPath, "photos_purchases")

                '' إنشاء المجلد لو مش موجود
                'If Not Directory.Exists(photosFolder) Then
                '    Directory.CreateDirectory(photosFolder)
                'End If

                '' اسم الصورة الجديدة (مثلاً حسب التاريخ والوقت لتجنب التكرار)
                'Dim id As Integer = Convert.ToInt32(txt_Invoice_ID.Text)
                'Dim newFileName As String = "purchases_" & id & Path.GetExtension(sourcePath)
                'Dim destinationPath As String = Path.Combine(photosFolder, newFileName)

                '' نسخ الصورة
                'File.Copy(sourcePath, destinationPath, True)
                'Using Conn

                '    Connect()
                '    Using cmd As New SqlCommand("UPDATE Products SET purchases_Image = @purchases_Image WHERE Product_ID = @Product_ID", Conn)
                '        cmd.Parameters.AddWithValue("@purchases_Image", destinationPath)
                '        cmd.Parameters.AddWithValue("@Product_ID", id)
                '        cmd.ExecuteNonQuery()
                '    End Using
                '    Disconnect()
                'End Using
                ' عرض الصورة في PictureBox (لو عندك)

                'pic_purchases.Image = System.Drawing.Image.FromFile(sourcePath)
                ' تحميل الصورة بدون أن يحدث Lock للملف
                If pic_user.Image IsNot Nothing Then
                    pic_user.Image.Dispose()
                    pic_user.Image = Nothing
                End If

                Using img As System.Drawing.Image = System.Drawing.Image.FromFile(User_photo_path)
                    pic_user.Image = New Bitmap(img)  ' ← نسخ الصورة (Clone)
                End Using


                '' حفظ المسار الجديد في متغير
                'Dim imagePath As String = destinationPath

                ' لو عايز تخزنها في TextBox مثلاً
                'txtImagePath.Text = imagePath

                MessageBox.Show("✅ تم تحديد الصورة بنجاح:" & vbCrLf, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حفظ الصورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'LoadProducts()
            'ClearAllFields()
            'ClearAllFields()
        End Try
    End Sub

    Private Sub chkUser_Stats_CheckedChanged(sender As Object, e As EventArgs) Handles chkUser_Stats.CheckedChanged
        If chkUser_Stats.Checked Then
            lblStatus.Text = "نشط"
            lblStatus.ForeColor = Color.Green
        Else
            lblStatus.Text = "نشط غير"
            lblStatus.ForeColor = Color.Red
        End If
    End Sub

    Private Sub add_new_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStaff()
        chkUser_Stats.Checked = True
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class