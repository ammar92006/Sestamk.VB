Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports WindowsApp1.Services.Cloud

''' <summary>
''' نافذة مشاركة بوابات سستمك الذكية (بوابة المالك، تابلت الويتر، شاشة المطبخ KDS) عبر رموز QR وروابط الشبكة المحلية.
''' </summary>
Public Class FrmOwnerPortalQR

    Private _qrBitmap As Bitmap = Nothing
    Private _currentTab As Integer = 0 ' 0 = Owner, 1 = Waiter, 2 = KDS

    Private Sub FrmOwnerPortalQR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)

        ' التأكد من تشغيل السيرفر المحلي
        If Not OwnerPortalServer.Instance.IsRunning Then
            OwnerPortalServer.Instance.StartServer(5055)
        End If

        SwitchTab(0)

        Try
            Dim drag As New FormDragHelper(Me, panelHeader)
        Catch
        End Try
    End Sub

    Private Sub SwitchTab(tabIndex As Integer)
        _currentTab = tabIndex

        Dim targetUrl As String = ""
        Dim instructionText As String = ""

        Dim activeColor = Color.FromArgb(37, 99, 235)
        Dim inactiveBg = Color.Transparent
        Dim inactiveFg = Color.FromArgb(148, 163, 184)

        ' إعادة ضبط أزرار التبويب
        btnTabOwner.FillColor = inactiveBg
        btnTabOwner.ForeColor = inactiveFg
        btnTabWaiter.FillColor = inactiveBg
        btnTabWaiter.ForeColor = inactiveFg
        btnTabKDS.FillColor = inactiveBg
        btnTabKDS.ForeColor = inactiveFg

        Select Case tabIndex
            Case 0 ' 📱 بوابة المالك
                btnTabOwner.FillColor = activeColor
                btnTabOwner.ForeColor = Color.White
                targetUrl = OwnerPortalServer.Instance.GetMobilePortalUrl()
                instructionText = "امسح الرمز بكاميرا هاتفك وأنت متصل بنفس شبكة الواي فاي لمتابعة مبيعات اليوم وإشغال الصالة والدرج لحظة بلحظة:"

            Case 1 ' 🍽️ تابلت الويتر
                btnTabWaiter.FillColor = Color.FromArgb(16, 185, 129)
                btnTabWaiter.ForeColor = Color.White
                targetUrl = OwnerPortalServer.Instance.GetWaiterPortalUrl()
                instructionText = "امسح الرمز بكاميرا هاتف أو تابلت الويتر لفتح شاشة أخذ الطلبات من الطاولات مباشرةً وإرسالها للمطبخ:"

            Case 2 ' 🧑‍🍳 شاشة المطبخ
                btnTabKDS.FillColor = Color.FromArgb(245, 158, 11)
                btnTabKDS.ForeColor = Color.White
                targetUrl = OwnerPortalServer.Instance.GetKdsPortalUrl()
                instructionText = "افتح هذا الرابط على شاشة التلفزيون الذكية (Smart TV) أو تابلت المطبخ لعرض وتحضير الطلبات وإنجازها:"
        End Select

        txtPortalUrl.Text = targetUrl
        lblInstructions.Text = instructionText

        ' توليد رمز QR عالي الدقة للرابط المستهدف
        Try
            If _qrBitmap IsNot Nothing Then _qrBitmap.Dispose()
            _qrBitmap = QRCodeHelper.GenerateQRCode(targetUrl, 230, 230)
            If _qrBitmap IsNot Nothing Then
                picQRCode.Image = _qrBitmap
            End If
        Catch ex As Exception
            Logger.LogError("FrmOwnerPortalQR.GenerateQR", ex)
        End Try
    End Sub

    Private Sub btnTabOwner_Click(sender As Object, e As EventArgs) Handles btnTabOwner.Click
        SwitchTab(0)
    End Sub

    Private Sub btnTabWaiter_Click(sender As Object, e As EventArgs) Handles btnTabWaiter.Click
        SwitchTab(1)
    End Sub

    Private Sub btnTabKDS_Click(sender As Object, e As EventArgs) Handles btnTabKDS.Click
        SwitchTab(2)
    End Sub

    Private Sub btnCopyUrl_Click(sender As Object, e As EventArgs) Handles btnCopyUrl.Click
        Try
            Clipboard.SetText(txtPortalUrl.Text)
            Try
                Notify.Toast("تم نسخ الرابط بنجاح 📋", Notify.ToastType.Success)
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
