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

    Private Sub btn_SaveProduct_Click(sender As Object, e As EventArgs) Handles btn_SaveProduct.Click
        Try
            ' ==== 1) التحقق من صحة البيانات قبل الإضافة ====
            If String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("❌ من فضلك أدخل اسم الصنف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(TextBox3.Text) Then
                MessageBox.Show("❌ من فضلك أدخل وصف الصنف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Exit Sub
            End If

            ' ==== 2) التحقق من عدم تكرار اسم الصنف ====
            Connect()
            Dim checkQuery As String = "SELECT COUNT(*) FROM Categories WHERE Category_Name = @Category_Name"
            Using checkCmd As New SqlCommand(checkQuery, Conn)
                checkCmd.Parameters.AddWithValue("@Category_Name", TextBox2.Text.Trim())

                Dim exists As Integer = CInt(checkCmd.ExecuteScalar())

                If exists > 0 Then
                    MessageBox.Show("⚠ الصنف موجود بالفعل، لا يمكن إضافته مرة أخرى.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End Using
            Disconnect()
            Connect()

            ' ==== 3) تنفيذ عملية الإضافة ====
            Dim insertQuery As String = "INSERT INTO Categories (Category_Name, Description)
                                 VALUES (@Category_Name, @Description)"

            Using insertCmd As New SqlCommand(insertQuery, Conn)
                insertCmd.Parameters.AddWithValue("@Category_Name", TextBox2.Text.Trim())
                insertCmd.Parameters.AddWithValue("@Description", TextBox3.Text.Trim())

                insertCmd.ExecuteNonQuery()
            End Using

            Disconnect()

            MessageBox.Show("✅ تم إضافة القسم بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

            TextBox2.Clear()
            TextBox3.Clear()
        Catch ex As Exception
            MessageBox.Show("⚠ حدث خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)



        End Try

    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class