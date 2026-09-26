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
                If manifest Is Nothing Then Return

                Dim manifestVer As Version = Nothing
                Dim currentVer As Version = Nothing
                If Version.TryParse(manifest.Version, manifestVer) AndAlso Version.TryParse(Application.ProductVersion, currentVer) Then
                    If manifestVer <= currentVer Then Return
                ElseIf String.Equals(manifest.Version, Application.ProductVersion, StringComparison.OrdinalIgnoreCase) Then
                    Return
                End If

                If owner IsNot Nothing AndAlso TypeOf owner Is Control AndAlso DirectCast(owner, Control).InvokeRequired Then
                    DirectCast(owner, Control).Invoke(Sub()
                                                          Using prompt As New FormUpdateNotifier(manifest)
                                                              prompt.ShowDialog(owner)
                                                          End Using
                                                      End Sub)
                Else
                    Using prompt As New FormUpdateNotifier(manifest)
                        prompt.ShowDialog(owner)
                    End Using
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine("Update check skipped: " & ex.Message)
        End Try
    End Function

    Public Shared Async Function DownloadAndLaunchAsync(manifest As VbUpdateManifest, progress As IProgress(Of Integer)) As Task(Of String)
        If manifest Is Nothing OrElse Not Uri.IsWellFormedUriString(manifest.PackageUrl, UriKind.Absolute) OrElse Not manifest.PackageUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then Return "رابط حزمة التحديث غير صالح أو غير متوفر."
        
        Dim hasSha = Not String.IsNullOrWhiteSpace(manifest.PackageSha256) AndAlso manifest.PackageSha256.Length = 64

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
                        If hasSha Then hash.TransformBlock(buffer, 0, read, Nothing, 0)
                        total += read
                        If manifest.PackageSize > 0 Then progress.Report(CInt(Math.Min(99, total * 100 / manifest.PackageSize)))
                    Loop

                    If hasSha Then
                        hash.TransformFinalBlock(New Byte() {}, 0, 0)
                        Dim actual = BitConverter.ToString(hash.Hash).Replace("-", String.Empty).ToLowerInvariant()
                        If Not String.Equals(actual, manifest.PackageSha256, StringComparison.OrdinalIgnoreCase) Then
                            File.Delete(packagePath)
                            Return "فشل التحقق من سلامة حزمة التحديث (عدم تطابق البصمة الرقمية)."
                        End If
                    End If
                End Using
            End Using

            Dim pending = New JObject From {{"version", manifest.Version}, {"package_path", packagePath}, {"target_path", Application.StartupPath}, {"main_exe", Application.ExecutablePath}}
            Dim pendingPath = Path.Combine(updateDir, "pending-update.json")
            File.WriteAllText(pendingPath, pending.ToString())

            Dim updater = Path.Combine(Application.StartupPath, "tools", "Sestamk.VB.Updater.exe")
            If Not File.Exists(updater) Then
                Dim fallback = Path.Combine(Application.StartupPath, "Sestamk.VB.Updater.exe")
                If File.Exists(fallback) Then
                    updater = fallback
                Else
                    Return "أداة تطبيق التحديث غير موجودة ضمن ملفات البرنامج."
                End If
            End If

            Process.Start(New ProcessStartInfo(updater, "--pending " & ChrW(34) & pendingPath & ChrW(34)) With {.UseShellExecute = True})
            progress.Report(100)
            Return Nothing
        Catch ex As Exception
            Return "تعذر تنزيل التحديث: " & ex.Message
        End Try
    End Function

    Public Shared Function ParseManifest(json As JObject) As VbUpdateManifest
        If json Is Nothing Then Return Nothing

        ' التحقق من توافق المنتج إذا كان محدداً
        Dim prod = Convert.ToString(If(json("product"), json("Product")))
        If Not String.IsNullOrEmpty(prod) AndAlso Not String.Equals(prod, LicenseSettings.ProductId, StringComparison.OrdinalIgnoreCase) AndAlso Not prod.ToLower().Contains("sestamk") Then
            Return Nothing
        End If

        Dim versionText = Convert.ToString(If(json("version"), json("Version")))
        If String.IsNullOrWhiteSpace(versionText) Then Return Nothing

        Dim channelText = Convert.ToString(If(json("channel"), json("Channel")))
        Dim isMandatory = Convert.ToBoolean(If(json("mandatory"), json("IsMandatory")))

        ' تجميع الملاحظات
        Dim notes = Convert.ToString(If(json("notes"), json("Notes")))
        If String.IsNullOrWhiteSpace(notes) Then
            Dim whatsNewToken = If(json("whats_new"), json("WhatsNew"))
            If whatsNewToken IsNot Nothing AndAlso whatsNewToken.Type = JTokenType.Array Then
                Dim sb As New StringBuilder()
                For Each item In whatsNewToken
                    sb.AppendLine("• " & Convert.ToString(item))
                Next
                notes = sb.ToString().TrimEnd()
            End If
        End If

        ' استخراج معلومات الحزمة
        Dim pkgUrl As String = Nothing
        Dim pkgSha As String = Nothing
        Dim pkgSize As Long = 0

        Dim packageObj = TryCast(If(json("package"), json("Package")), JObject)
        If packageObj IsNot Nothing Then
            pkgUrl = Convert.ToString(If(packageObj("url"), packageObj("Url")))
            pkgSha = Convert.ToString(If(packageObj("sha256"), packageObj("Sha256")))
            pkgSize = CLng(Val(Convert.ToString(If(packageObj("size"), packageObj("Size")))))
        End If

        If String.IsNullOrWhiteSpace(pkgUrl) Then
            pkgUrl = Convert.ToString(If(json("PackageUrl"), If(json("FullVersionUrl"), json("package_url"))))
        End If
        If String.IsNullOrWhiteSpace(pkgSha) Then
            pkgSha = Convert.ToString(If(json("PackageSha256"), json("sha256")))
        End If
        If pkgSize <= 0 Then
            pkgSize = CLng(Val(Convert.ToString(If(json("PackageSize"), If(json("FullVersionSizeBytes"), json("DownloadSizeBytes"))))))
        End If

        ' إذا كان الرابط مفقوداً أو فارغاً لا نقبل المانيفست لحماية البرنامج
        If String.IsNullOrWhiteSpace(pkgUrl) Then
            Return Nothing
        End If

        Return New VbUpdateManifest With {
            .Product = LicenseSettings.ProductId,
            .Version = versionText,
            .Channel = channelText,
            .Mandatory = isMandatory,
            .Notes = notes,
            .PackageUrl = pkgUrl,
            .PackageSha256 = pkgSha,
            .PackageSize = pkgSize
        }
    End Function
End Class