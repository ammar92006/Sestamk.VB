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
        _title.Text = "يتوفر تحديث جديد: " & manifest.Version
        _notes.Text = If(String.IsNullOrWhiteSpace(manifest.Notes), "لا توجد ملاحظات إصدار.", manifest.Notes)
        _later.Visible = Not manifest.Mandatory
    End Sub

    Private Sub _later_Click(sender As Object, e As EventArgs) Handles _later.Click
        Close()
    End Sub

    Private Async Sub _update_Click(sender As Object, e As EventArgs) Handles _update.Click
        _update.Enabled = False
        _later.Enabled = False
        _progress.Visible = True
        Dim progress = New Progress(Of Integer)(Sub(value) _progress.Value = Math.Max(0, Math.Min(100, value)))
        Dim errorMessage = Await UpdateCoordinator.DownloadAndLaunchAsync(_manifest, progress)
        If String.IsNullOrWhiteSpace(errorMessage) Then
            Application.Exit()
        Else
            MessageBox.Show(errorMessage, "فشل التحديث", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _update.Enabled = True
            _later.Enabled = Not _manifest.Mandatory
        End If
    End Sub
End Class