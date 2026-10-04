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
    Public Property Title As String
    Public Property Notes As String
    Public Property WhatsNew As New List(Of String)()
    Public Property PackageUrl As String
    Public Property PackageSha256 As String
    Public Property PackageSize As Long
    Public Property InstallerSize As Long
End Class

Public NotInheritable Class UpdateCoordinator
    Private Sub New()
    End Sub

    Public Shared Async Function CheckAndPromptAsync(license As JObject, owner As IWin32Window) As Task(Of Boolean)
        ' التحقق من الترخيص وقناة المستخدم
        If license Is Nothing Then Return False

        Dim isUpdateAvailable = False
        Dim availToken = license("update_available")
        If availToken IsNot Nothing Then
            Boolean.TryParse(Convert.ToString(availToken), isUpdateAvailable)
        End If

        ' إذا كان السيرفر يفيد بعدم وجود تحديث متوفر لهذه القناة والترخيص، نتوقف فوراً
        If Not isUpdateAvailable Then Return False

        Dim userChannel = Convert.ToString(license("channel"))
        If String.IsNullOrWhiteSpace(userChannel) Then userChannel = "public"
        userChannel = userChannel.Trim().ToLowerInvariant()

        Dim manifestUrl As String = Convert.ToString(license.SelectToken("update.manifest_url"))
        If String.IsNullOrWhiteSpace(manifestUrl) Then Return False

        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(15)
                client.DefaultRequestHeaders.Add("User-Agent", "Sestamk-VB-Client")
                Dim json = Await client.GetStringAsync(manifestUrl)
                Dim manifest = ParseManifest(JObject.Parse(json))
                If manifest Is Nothing Then Return False

                ' التحقق الصارم من تطابق قناة التحديث مع قناة الترخيص (Beta vs Public)
                Dim manifestChannel = If(String.IsNullOrWhiteSpace(manifest.Channel), "public", manifest.Channel.Trim().ToLowerInvariant())
                If Not String.Equals(manifestChannel, userChannel, StringComparison.OrdinalIgnoreCase) Then
                    Debug.WriteLine($"Update ignored due to channel mismatch: manifest channel '{manifestChannel}' vs user channel '{userChannel}'")
                    Return False
                End If

                Dim manifestVer As Version = Nothing
                Dim currentVer As Version = Nothing
                If Version.TryParse(manifest.Version, manifestVer) AndAlso Version.TryParse(Application.ProductVersion, currentVer) Then
                    If manifestVer <= currentVer Then Return False
                ElseIf String.Equals(manifest.Version, Application.ProductVersion, StringComparison.OrdinalIgnoreCase) Then
                    Return False
                End If

                ' في حال لم يتم تحديد حجم الحزمة في المانيفست، نقرأ الحجم من بيانات السيرفر
                If manifest.PackageSize <= 0 Then
                    Dim serverSizeBytes = CLng(Val(Convert.ToString(license.SelectToken("update.delta_size_bytes"))))
                    If serverSizeBytes > 0 Then manifest.PackageSize = serverSizeBytes
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
                Return True
            End Using
        Catch ex As Exception
            Debug.WriteLine("Update check skipped: " & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Async Function DownloadAndLaunchAsync(manifest As VbUpdateManifest, progress As IProgress(Of Integer)) As Task(Of String)
        If manifest Is Nothing OrElse Not Uri.IsWellFormedUriString(manifest.PackageUrl, UriKind.Absolute) OrElse Not manifest.PackageUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then Return "رابط حزمة التحديث غير صالح أو غير متوفر."

        ' أمان: التحقق من البصمة الرقمية SHA-256 إلزامي — الحزم بدون بصمة تُرفض ولا تُثبّت
        Dim hasSha = Not String.IsNullOrWhiteSpace(manifest.PackageSha256) AndAlso manifest.PackageSha256.Length = 64
        If Not hasSha Then
            Logger.LogError("UpdateCoordinator", New InvalidOperationException("حزمة التحديث " & manifest.Version & " لا تحتوي بصمة SHA-256 — تم رفض التثبيت."))
            Return "حزمة التحديث غير موقعة ببصمة رقمية (SHA-256) — تم رفض التحديث لأسباب أمنية."
        End If

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

            Dim updaterCandidates As String() = {
                Path.Combine(Application.StartupPath, "tools", "update.exe"),
                Path.Combine(Application.StartupPath, "tools", "Sestamk.VB.Updater.exe"),
                Path.Combine(Application.StartupPath, "update.exe"),
                Path.Combine(Application.StartupPath, "Sestamk.VB.Updater.exe")
            }
            Dim updater As String = updaterCandidates.FirstOrDefault(Function(p) File.Exists(p))
            If String.IsNullOrEmpty(updater) Then
                Return "أداة تطبيق التحديث (update.exe) غير موجودة ضمن ملفات البرنامج."
            End If

            ' تشغيل الأداة عبر مشغل خارجي في ProgramData لتجنب قفل أي ملف داخل مجلد البرنامج
            Dim launchTarget As String = updater
            Dim launchArgs As String = "--pending " & ChrW(34) & pendingPath & ChrW(34)
            Try
                Dim runnerDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "updates", "runner")
                Directory.CreateDirectory(runnerDir)
                Dim externalRunner = Path.Combine(runnerDir, "update_runner.exe")
                File.Copy(updater, externalRunner, True)
                launchTarget = externalRunner
                launchArgs = "--shadow-runner --pending " & ChrW(34) & pendingPath & ChrW(34)
            Catch __logEx As Exception
                ' في حال تعذر النسخ يتم التشغيل المباشر من مسار الأداة الأصلي
                Logger.LogError("UpdateCoordinator.vb:160", __logEx)
            End Try

            Dim psi As New ProcessStartInfo(launchTarget, launchArgs) With {
                .UseShellExecute = True,
                .Verb = "runas"
            }
            Try
                Process.Start(psi)
            Catch
                psi.Verb = ""
                Process.Start(psi)
            End Try
            progress.Report(100)
            Return Nothing
        Catch ex As Exception
            Return "تعذر تنزيل التحديث: " & ex.Message
        End Try
    End Function

    Public Shared Function ParseManifest(json As JObject) As VbUpdateManifest
        If json Is Nothing Then Return Nothing

        ' التحقق من توافق المنتج (يجب أن يكون sestamk-vb حصراً لمنع خلط تحديثات C# مع VB)
        Dim prod = Convert.ToString(If(json("product"), json("Product")))
        If Not String.IsNullOrEmpty(prod) AndAlso Not String.Equals(prod, LicenseSettings.ProductId, StringComparison.OrdinalIgnoreCase) Then
            Return Nothing
        End If

        Dim versionText = Convert.ToString(If(json("version"), json("Version")))
        If String.IsNullOrWhiteSpace(versionText) Then Return Nothing

        Dim channelText = Convert.ToString(If(json("channel"), json("Channel")))
        Dim isMandatory = Convert.ToBoolean(If(json("mandatory"), json("IsMandatory")))

        ' تجميع الملاحظات
        Dim whatsNewList As New List(Of String)()
        Dim whatsNewToken = If(json("whats_new"), json("WhatsNew"))
        If whatsNewToken IsNot Nothing AndAlso whatsNewToken.Type = JTokenType.Array Then
            For Each item In whatsNewToken
                Dim s = Convert.ToString(item)
                If Not String.IsNullOrWhiteSpace(s) Then whatsNewList.Add(s.Trim())
            Next
        End If

        Dim notes = Convert.ToString(If(json("notes"), json("Notes")))
        If String.IsNullOrWhiteSpace(notes) AndAlso whatsNewList.Count > 0 Then
            Dim sb As New StringBuilder()
            For Each item In whatsNewList
                sb.AppendLine("• " & item)
            Next
            notes = sb.ToString().TrimEnd()
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

        ' حماية قصوى: منع أي حزمة موجهة لمستودع C#
        If Not String.IsNullOrEmpty(pkgUrl) AndAlso pkgUrl.IndexOf("/ammar92006/Sestamk/", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso pkgUrl.IndexOf("/ammar92006/Sestamk.VB/", StringComparison.OrdinalIgnoreCase) < 0 Then
            Return Nothing
        End If

        ' إذا كان الرابط مفقوداً أو فارغاً لا نقبل المانيفست لحماية البرنامج
        If String.IsNullOrWhiteSpace(pkgUrl) Then
            Return Nothing
        End If

        Dim title = Convert.ToString(If(json("title"), json("Title")))
        Dim instSize As Long = 0
        Dim installerObj = TryCast(If(json("installer"), json("Installer")), JObject)
        If installerObj IsNot Nothing Then
            instSize = CLng(Val(Convert.ToString(If(installerObj("size"), installerObj("Size")))))
        End If

        Return New VbUpdateManifest With {
            .Product = LicenseSettings.ProductId,
            .Version = versionText,
            .Channel = channelText,
            .Mandatory = isMandatory,
            .Title = title,
            .Notes = notes,
            .WhatsNew = whatsNewList,
            .PackageUrl = pkgUrl,
            .PackageSha256 = pkgSha,
            .PackageSize = pkgSize,
            .InstallerSize = instSize
        }
    End Function
End Class