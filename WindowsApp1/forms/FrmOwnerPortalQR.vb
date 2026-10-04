Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports WindowsApp1.Services.Cloud

''' <summary>
''' نافذة مشاركة بوابة المالك والمشرف اللحظية عبر رمز QR ورابط الشبكة المحلية.
''' </summary>
Public Class FrmOwnerPortalQR

    Private _qrBitmap As Bitmap = Nothing

    Private Sub FrmOwnerPortalQR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)

        ' التأكد من تشغيل السيرفر المحلي
        If Not OwnerPortalServer.Instance.IsRunning Then
            OwnerPortalServer.Instance.StartServer(5055)
        End If

        Dim portalUrl = OwnerPortalServer.Instance.GetMobilePortalUrl()
        txtPortalUrl.Text = portalUrl

        ' توليد رمز QR عالي الدقة
        Try
            If _qrBitmap IsNot Nothing Then _qrBitmap.Dispose()
            _qrBitmap = QRCodeHelper.GenerateQRCode(portalUrl, 240, 240)
            If _qrBitmap IsNot Nothing Then
                picQRCode.Image = _qrBitmap
            End If
        Catch ex As Exception
            Logger.LogError("FrmOwnerPortalQR.GenerateQR", ex)
        End Try

        Try
            Dim drag As New FormDragHelper(Me, panelHeader)
        Catch
        End Try
    End Sub

    Private Sub btnCopyUrl_Click(sender As Object, e As EventArgs) Handles btnCopyUrl.Click
        Try
            Clipboard.SetText(txtPortalUrl.Text)
            Try
                Notify.Toast("تم نسخ رابط بوابة المالك بنجاح 📋", Notify.ToastType.Success)
            Catch
                SmartMessageBox.Show("تم نسخ الرابط إلى الحافظة بنجاح!", "نسخ الرابط", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Catch ex As Exception
            SmartMessageBox.Show("تعذر نسخ الرابط: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnOpenBrowser_Click(sender As Object, e As EventArgs) Handles btnOpenBrowser.Click
        Try
            Dim psi As New ProcessStartInfo(txtPortalUrl.Text) With {
                .UseShellExecute = True
            }
            Process.Start(psi)
        Catch ex As Exception
            SmartMessageBox.Show("تعذر فتح الرابط في المتصفح: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click, btnCloseHeader.Click
        Me.Close()
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        If _qrBitmap IsNot Nothing Then
            _qrBitmap.Dispose()
            _qrBitmap = Nothing
        End If
    End Sub

End Class
