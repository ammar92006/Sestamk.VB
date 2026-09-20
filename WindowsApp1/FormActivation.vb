Public Class FormActivation
    Dim x, y As Integer
    Dim newpoint As New Point

    Private Async Sub btn_Staff_Click(sender As Object, e As EventArgs) Handles btn_Staff.Click
        btn_Staff.Enabled = False
        Try
            Dim result = Await LicenseBootstrapper.ActivateAsync(txtLicense.Text)
            If result.IsValid Then
                MessageBox.Show(result.Message, "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = DialogResult.OK
                Close()
            Else
                MessageBox.Show(result.Message, "فشل التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            btn_Staff.Enabled = True
        End Try
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        WindowState = If(WindowState = FormWindowState.Maximized, FormWindowState.Normal, FormWindowState.Maximized)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Location = newpoint
        End If
    End Sub

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Location.X
        y = Control.MousePosition.Y - Location.Y
    End Sub
End Class