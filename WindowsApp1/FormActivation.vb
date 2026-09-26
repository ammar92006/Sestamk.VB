Public Class FormActivation
    Dim x, y As Integer
    Dim newpoint As New Point
    Private _hwid As String

    Protected Overrides Sub ApplyCustomTheme()
        MyBase.ApplyCustomTheme()
        Try
            Dim palette = ThemeManager.Instance.Palette
            If palette Is Nothing Then Return

            If ThemeManager.Instance.IsDark Then
                Me.BackColor = Color.FromArgb(20, 24, 33)
                panelHeader.BackColor = Color.FromArgb(26, 31, 43)
                Guna2Panel1.BackColor = Color.FromArgb(26, 31, 43)
                Label4.ForeColor = Color.FromArgb(243, 244, 246)
                lblHWID.ForeColor = Color.FromArgb(56, 189, 248)
                LabelDeveloper.ForeColor = Color.FromArgb(156, 163, 175)
            Else
                Me.BackColor = Color.FromArgb(243, 244, 246)
                panelHeader.BackColor = Color.White
                Guna2Panel1.BackColor = Color.White
                Label4.ForeColor = Color.FromArgb(17, 24, 39)
                lblHWID.ForeColor = Color.FromArgb(37, 99, 235)
                LabelDeveloper.ForeColor = Color.FromArgb(107, 114, 128)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormActivation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ApplyCustomTheme()

            ' Get Hardware ID
            _hwid = HardwareFingerprint.GetCurrent()
            lblHWID.Text = _hwid

            ' Generate QR Code using native QRCodeHelper (ZXing)
            picQRCode.Image = QRCodeHelper.GenerateQRCode(_hwid, 200, 200)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ في توليد بصمة الجهاز: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btn_Staff_Click(sender As Object, e As EventArgs) Handles btn_Staff.Click
        btn_Staff.Enabled = False
        progressActivation.Visible = True
        Try
            Dim result = Await LicenseBootstrapper.ActivateAsync(txtLicense.Text)
            If result.IsValid Then
                Notify.Toast(result.Message, Notify.ToastType.Success)
                DialogResult = DialogResult.OK
                Close()
            Else
                MessageBox.Show(result.Message, "فشل التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            btn_Staff.Enabled = True
            progressActivation.Visible = False
        End Try
    End Sub

    Private Sub btnCopyHwid_Click(sender As Object, e As EventArgs) Handles btnCopyHwid.Click
        If Not String.IsNullOrEmpty(_hwid) Then
            Clipboard.SetText(_hwid)
            Notify.Toast("تم نسخ المعرف بنجاح ✅", Notify.ToastType.Success)
        End If
    End Sub

    Private Sub btnSupport_Click(sender As Object, e As EventArgs) Handles btnSupport.Click
        Try
            Process.Start(New ProcessStartInfo("https://wa.me/201281637066") With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("تعذر فتح رابط الدعم الفني", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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