Public Class chkpassword
    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.Checked Then
            password.PasswordChar = ""

        Else
            password.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkpassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class