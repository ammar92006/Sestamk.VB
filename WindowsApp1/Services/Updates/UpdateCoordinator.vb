Imports Newtonsoft.Json.Linq
Imports System.Diagnostics
Imports System.IO
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class VbUpdateManifest
    Public Property Product As String
    Public Property Version As String
    Public Property Channel As String
    Public Property Mandatory As Boolean
    Public Property Notes As String
    Public Property PackageUrl As String
    Public Property PackageSha256 As String
    Public Property PackageSize As Long
End Class

Public NotInheritable Class UpdateCoordinator
    Private Sub New()
    End Sub

    Public Shared Async Function CheckAndPromptAsync(license As JObject, owner As IWin32Window) As Task
        If license Is Nothing OrElse Not Convert.ToBoolean(license("update_available")) Then Return
        Dim manifestUrl = Convert.ToString(license.SelectToken("update.manifest_url"))
        If String.IsNullOrWhiteSpace(manifestUrl) Then Return
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(15)
                Dim json = Await client.GetStringAsync(manifestUrl)
                Dim manifest = ParseManifest(JObject.Parse(json))
                If manifest Is Nothing OrElse New Version(manifest.Version) <= New Version(Application.ProductVersion) Then Return
                Using prompt As New FormUpdateNotifier(manifest)
                    prompt.ShowDialog(owner)
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Update check skipped: " & ex.Message)
        End Try
    End Function

    Public Shared Async Function DownloadAndLaunchAsync(manifest As VbUpdateManifest, progress As IProgress(Of Integer)) As Task(Of String)
        If manifest Is Nothing OrElse Not Uri.IsWellFormedUriString(manifest.PackageUrl, UriKind.Absolute) OrElse Not manifest.PackageUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then Return "رابط حزمة التحديث غير صالح."
        If String.IsNullOrWhiteSpace(manifest.PackageSha256) OrElse manifest.PackageSha256.Length <> 64 Then Return "ملف التحديث لا يحتوي على بصمة تحقق صحيحة."

        Dim updateDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "updates", manifest.Version)
        Directory.CreateDirectory(updateDir)
        Dim packagePath = Path.Combine(updateDir, "package.zip")
        Try
            Using client As New HttpClient(), response = Await client.GetAsync(manifest.PackageUrl, HttpCompletionOption.ResponseHeadersRead)
                response.EnsureSuccessStatusCode()
                Using source = Await response.Content.ReadAsStreamAsync(), target = New FileStream(packagePath, FileMode.Create, FileAccess.Write, FileShare.None), hash = SHA256.Create()
                    Dim buffer(8191) As Byte
                    Dim total As Long = 0
                    Do
                        Dim read = Await source.ReadAsync(buffer, 0, buffer.Length)
                        If read = 0 Then Exit Do
                        Await target.WriteAsync(buffer, 0, read)
                        hash.TransformBlock(buffer, 0, read, Nothing, 0)
                        total += read
                        If manifest.PackageSize > 0 Then progress.Report(CInt(Math.Min(99, total * 100 / manifest.PackageSize)))
                    Loop
                    hash.TransformFinalBlock(New Byte() {}, 0, 0)
                    Dim actual = BitConverter.ToString(hash.Hash).Replace("-", String.Empty).ToLowerInvariant()
                    If Not String.Equals(actual, manifest.PackageSha256, StringComparison.OrdinalIgnoreCase) Then
                        File.Delete(packagePath)
                        Return "فشل التحقق من سلامة حزمة التحديث."
                    End If
                End Using
            End Using

            Dim pending = New JObject From {{"version", manifest.Version}, {"package_path", packagePath}, {"target_path", Application.StartupPath}, {"main_exe", Application.ExecutablePath}}
            Dim pendingPath = Path.Combine(updateDir, "pending-update.json")
            File.WriteAllText(pendingPath, pending.ToString())
            Dim updater = Path.Combine(Application.StartupPath, "tools", "Sestamk.VB.Updater.exe")
            If Not File.Exists(updater) Then Return "أداة تطبيق التحديث غير موجودة ضمن ملفات البرنامج."
            Process.Start(New ProcessStartInfo(updater, "--pending " & ChrW(34) & pendingPath & ChrW(34)) With {.UseShellExecute = True})
            progress.Report(100)
            Return Nothing
        Catch ex As Exception
            Return "تعذر تنزيل التحديث: " & ex.Message
        End Try
    End Function

    Private Shared Function ParseManifest(json As JObject) As VbUpdateManifest
        If Not String.Equals(Convert.ToString(json("product")), LicenseSettings.ProductId, StringComparison.OrdinalIgnoreCase) Then Return Nothing
        Dim package = TryCast(json("package"), JObject)
        If package Is Nothing Then Return Nothing
        Dim versionText = Convert.ToString(json("version"))
        Dim parsed As Version
        If Not Version.TryParse(versionText, parsed) Then Return Nothing
        Return New VbUpdateManifest With {.Product = LicenseSettings.ProductId, .Version = versionText, .Channel = Convert.ToString(json("channel")), .Mandatory = Convert.ToBoolean(json("mandatory")), .Notes = Convert.ToString(json("notes")), .PackageUrl = Convert.ToString(package("url")), .PackageSha256 = Convert.ToString(package("sha256")), .PackageSize = CLng(Val(Convert.ToString(package("size"))))}
    End Function
End Class