Imports System.Data.SqlClient

Public Class add_new_Categorie

    Dim x, y As Integer
    Dim newpoint As New Point

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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If Not IsValidData() Then Exit Sub

            If InsertCategory() Then
                MessageBox.Show("تمت إضافة الفئة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' هنا تستدعي دالة تحديث الداتا جريد فيو لتظهر البيانات الجديدة
                ClearFields()
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الإضافة: " & ex.Message)
        End Try
    End Sub
    Private Function IsValidData() As Boolean
        ' 1. التحقق من كود الفئة
        If String.IsNullOrWhiteSpace(txtCategoryCode.Text) Then
            MessageBox.Show("عذراً، يجب إدخال كود الفئة أولاً!", "تنبيهvalidation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryCode.Focus()
            Return False
        End If

        ' 2. التحقق من اسم الفئة باللغة العربية
        If String.IsNullOrWhiteSpace(txtCategoryName.Text) Then
            MessageBox.Show("عذراً، يجب إدخال اسم الفئة باللغة العربية!", "تنبيهvalidation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryName.Focus()
            Return False
        End If

        ' 💡 يمكنك إضافة أي شروط إضافية هنا (مثل التأكد من اختيار لون أو طابعة إذا كانت إجبارية)

        ' إذا اجتازت البيانات كل الشروط ترجع الدالة True
        Return True
    End Function

    Private Function InsertCategory() As Boolean
        ' تأكد من تطابق أسماء الأعمدة في الجدول الخاص بك
        Dim query As String = "INSERT INTO Categories (CategoryCode, Category_NameAr, IsActive, ColorID, Imagebase64, IsDeleted) " &
                          "VALUES (@CategoryCode, @Category_NameAr, @IsActive, @ColorID, @Imagebase64, 0)"

        ' استخدام الخاصية الجاهزة ConnectionString من الـ DBModule الخاص بك
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                ' إضافة المعاملات (Parameters) بأمان
                cmd.Parameters.AddWithValue("@CategoryCode", If(String.IsNullOrEmpty(txtCategoryCode.Text), DBNull.Value, txtCategoryCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Category_NameAr", If(String.IsNullOrEmpty(txtCategoryName.Text), DBNull.Value, txtCategoryName.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                ' معاملات الـ ComboBoxes بناءً على الـ ValueMember
                cmd.Parameters.AddWithValue("@ColorID", If(cmbColor.SelectedValue Is Nothing, DBNull.Value, cmbColor.SelectedValue))

                ' تحويل الصورة وحفظها كـ Base64 عبر دالة الموديول الذكية
                Dim imgBase64 As String = DBModule.ImageToBase64(picCategory.Image)
                cmd.Parameters.AddWithValue("@Imagebase64", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                Try
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء إضافة الفئة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using
    End Function
    Private Sub ClearFields()
        ' --- تفريغ صناديق النصوص (TextBoxes) باستخدام .Clear() ---
        'txtCategoryCode.Clear()       ' كود الفئة
        txtCategoryCode.Text = GetNextCode("Categories", "CategoryCode")
        txtCategoryName.Clear()     ' اسم الفئة عربي

        ' --- إعادة تعيين القوائم المنسدلة (ComboBoxes) ---
        cmbColor.SelectedIndex = -1      ' لون الفئة

        ' --- إعادة تعيين زر الحالة (ToggleSwitch) ---
        tgStatus.Checked = False         ' حاله القسم
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class