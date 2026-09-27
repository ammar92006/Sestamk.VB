Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Class FormUpdateNotifier

    Private ReadOnly _manifest As VbUpdateManifest

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(manifest As VbUpdateManifest)
        Me.New()
        _manifest = manifest

        If manifest IsNot Nothing Then
            Dim verStr = If(String.IsNullOrWhiteSpace(manifest.Version), "1.0.0", manifest.Version.Trim())
            lblVersionBadge.Text = "v" & verStr.TrimStart("v"c)
            lblTitle.Text = "تحديث جديد متوفر: " & verStr

            If Not String.IsNullOrWhiteSpace(manifest.Notes) Then
                txtNotes.Text = manifest.Notes
            Else
                txtNotes.Text = "• تحسينات شاملة على أداء واستقرار النظام." & vbCrLf &
                                "• تحديث ومعالجة جداول قاعدة البيانات ذاتياً." & vbCrLf &
                                "• تحسين سرعة الاستجابة وأمان الاتصال بالسيرفرات."
            End If

            btnLater.Visible = Not manifest.Mandatory
            btnClose.Visible = Not manifest.Mandatory

            If manifest.Mandatory Then
                lblDeltaNotice.Text = "⚠️ هذا التحديث إلزامي لمتابعة العمل والتوافق مع السيرفر"
                lblDeltaNotice.ForeColor = Color.FromArgb(248, 113, 113)
                pnlDeltaNotice.FillColor = Color.FromArgb(69, 26, 26)
                pnlDeltaNotice.BorderColor = Color.FromArgb(239, 68, 68)
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click, btnLater.Click
        Close()
    End Sub

    Private Async Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If _manifest Is Nothing Then
            Close()
            Return
        End If

        btnUpdate.Enabled = False
        btnLater.Enabled = False
        btnClose.Enabled = False
        pnlProgress.Visible = True
        prgUpdate.Value = 0

        Dim progress = New Progress(Of Integer)(
            Sub(value)
                Dim safeVal = Math.Max(0, Math.Min(100, value))
                prgUpdate.Value = safeVal
                lblProgressStatus.Text = "جارٍ تنزيل ملفات التحديث... " & safeVal & "%"
            End Sub)

        lblProgressStatus.Text = "جارٍ الاتصال بسيرفر التحديثات وتنزيل الحزمة..."
        Dim errorMessage = Await UpdateCoordinator.DownloadAndLaunchAsync(_manifest, progress)
        If String.IsNullOrWhiteSpace(errorMessage) Then
            lblProgressStatus.Text = "تم التنزيل بنجاح! جارٍ تطبيق التحديث وإعادة التشغيل..."
            Await Task.Delay(1000)
            Application.Exit()
        Else
            MessageBox.Show(errorMessage, "فشل التحديث", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnUpdate.Enabled = True
            btnLater.Enabled = Not _manifest.Mandatory
            btnClose.Enabled = Not _manifest.Mandatory
            pnlProgress.Visible = False
        End If
    End Sub
End Class