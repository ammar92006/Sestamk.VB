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

''' <summary>
''' تفاصيل تقدم تنزيل حزمة التحديث (النسبة، السرعة، الحجم المحمل، الوقت المتبقي)
''' </summary>
Public Class VbDownloadProgressInfo
    Public Property Percentage As Integer = 0
    Public Property BytesReceived As Long = 0
    Public Property TotalBytes As Long = 0
    Public Property SpeedBytesPerSec As Double = 0
    Public Property SpeedFormatted As String = ""
    Public Property ProgressDetailFormatted As String = ""
    Public Property TimeRemainingFormatted As String = ""
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

    ''' <summary>
    ''' تنزيل حزمة التحديث وإطلاق أداة التثبيت مع تقدم بسيط بالنسبة المئوية (توافق رجعي).
    ''' </summary>
    Public Shared Async Function DownloadAndLaunchAsync(manifest As VbUpdateManifest, progress As IProgress(Of Integer)) As Task(Of String)
        Dim richProgress As IProgress(Of VbDownloadProgressInfo) = Nothing
        If progress IsNot Nothing Then
            richProgress = New Progress(Of VbDownloadProgressInfo)(Sub(p) progress.Report(p.Percentage))
        End If
        Return Await DownloadAndLaunchAsync(manifest, richProgress)
    End Function

    ''' <summary>
    ''' تنزيل حزمة التحديث وإطلاق أداة التثبيت مع إرسال تفاصيل التقدم والسرعة والوقت المتبقي لحظياً،
    ''' ودعم إعادة المحاولة التلقائية عند انقطاع الاتصال المؤقت (3 محاولات مع Backoff).
    ''' </summary>
    Public Shared Async Function DownloadAndLaunchAsync(manifest As VbUpdateManifest, progress As IProgress(Of VbDownloadProgressInfo)) As Task(Of String)
        If manifest Is Nothing OrElse Not Uri.IsWellFormedUriString(manifest.PackageUrl, UriKind.Absolute) OrElse Not manifest.PackageUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then
            Return "رابط حزمة التحديث غير صالح أو غير متوفر."
        End If

        ' أمان: التحقق من البصمة الرقمية SHA-256 إلزامي — الحزم بدون بصمة تُرفض ولا تُثبّت
        Dim hasSha = Not String.IsNullOrWhiteSpace(manifest.PackageSha256) AndAlso manifest.PackageSha256.Length = 64
        If Not hasSha Then
            Logger.LogError("UpdateCoordinator", New InvalidOperationException("حزمة التحديث " & manifest.Version & " لا تحتوي بصمة SHA-256 — تم رفض التثبيت."))
            Return "حزمة التحديث غير موقعة ببصمة رقمية (SHA-256) — تم رفض التحديث لأسباب أمنية."
        End If

        Dim updateDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "updates", manifest.Version)
        Directory.CreateDirectory(updateDir)
        Dim packagePath = Path.Combine(updateDir, "package.zip")

        Dim maxRetries As Integer = 3
        Dim attempt As Integer = 0
        Dim lastError As Exception = Nothing
        Dim retryDelayMs As Integer = 0

        While attempt < maxRetries
            If retryDelayMs > 0 Then
                Await Task.Delay(retryDelayMs)
                retryDelayMs = 0
            End If

            attempt += 1
            Try
                If File.Exists(packagePath) Then
                    Try
                        File.Delete(packagePath)
                    Catch
                    End Try
                End If

                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromMinutes(10)
                    client.DefaultRequestHeaders.Add("User-Agent", "Sestamk-VB-Client")

                    Using response = Await client.GetAsync(manifest.PackageUrl, HttpCompletionOption.ResponseHeadersRead)
                        response.EnsureSuccessStatusCode()

                        ' استخراج الحجم الفعلي للحزمة إن لم يكن محدداً مسبقاً
                        If manifest.PackageSize <= 0 AndAlso response.Content.Headers.ContentLength.HasValue Then
                            manifest.PackageSize = response.Content.Headers.ContentLength.Value
                        End If

                        Dim totalBytesExpected As Long = manifest.PackageSize

                        Using source = Await response.Content.ReadAsStreamAsync(),
                              target = New FileStream(packagePath, FileMode.Create, FileAccess.Write, FileShare.None),
                              hash = SHA256.Create()

                            Dim buffer(32767) As Byte ' 32 KB buffer لأداء وسرعة تنزيل أعلى
                            Dim totalRead As Long = 0
                            Dim sw = Stopwatch.StartNew()
                            Dim lastReportTime As Long = 0
                            Dim lastReportBytes As Long = 0

                            Do
                                Dim bytesRead = Await source.ReadAsync(buffer, 0, buffer.Length)
                                If bytesRead = 0 Then Exit Do

                                Await target.WriteAsync(buffer, 0, bytesRead)
                                If hasSha Then hash.TransformBlock(buffer, 0, bytesRead, Nothing, 0)
                                totalRead += bytesRead

                                Dim nowMs = sw.ElapsedMilliseconds
                                If progress IsNot Nothing AndAlso (nowMs - lastReportTime >= 150 OrElse (totalBytesExpected > 0 AndAlso totalRead >= totalBytesExpected)) Then
                                    Dim pct As Integer = 0
                                    If totalBytesExpected > 0 Then
                                        pct = CInt(Math.Min(99, Math.Max(0, (totalRead * 100L) / totalBytesExpected)))
                                    End If

                                    Dim deltaBytes = totalRead - lastReportBytes
                                    Dim deltaSec = Math.Max(0.05, (nowMs - lastReportTime) / 1000.0)
                                    Dim speedBytesSec As Double = deltaBytes / deltaSec

                                    Dim info As New VbDownloadProgressInfo With {
                                        .Percentage = pct,
                                        .BytesReceived = totalRead,
                                        .TotalBytes = totalBytesExpected,
                                        .SpeedBytesPerSec = speedBytesSec,
                                        .SpeedFormatted = FormatSpeed(speedBytesSec),
                                        .ProgressDetailFormatted = FormatProgressDetail(totalRead, totalBytesExpected),
                                        .TimeRemainingFormatted = FormatRemainingTime(totalRead, totalBytesExpected, speedBytesSec)
                                    }

                                    progress.Report(info)
                                    lastReportTime = nowMs
                                    lastReportBytes = totalRead
                                End If
                            Loop

                            ' التحقق النهائي من البصمة الرقمية SHA-256
                            If hasSha Then
                                hash.TransformFinalBlock(New Byte() {}, 0, 0)
                                Dim actual = BitConverter.ToString(hash.Hash).Replace("-", String.Empty).ToLowerInvariant()
                                If Not String.Equals(actual, manifest.PackageSha256, StringComparison.OrdinalIgnoreCase) Then
                                    target.Close()
                                    File.Delete(packagePath)
                                    Return "فشل التحقق من سلامة حزمة التحديث (عدم تطابق البصمة الرقمية SHA-256)."
                                End If
                            End If
                        End Using
                    End Using
                End Using

                ' التنزيل والتحقق تما بنجاح
                Exit While

            Catch ex As Exception
                lastError = ex
                If attempt < maxRetries Then
                    ' انتظار تصاعدي قبل إعادة المحاولة (1s, 2s...) يُنفَّذ خارج كتلة Catch
                    retryDelayMs = 1000 * attempt
                End If
            End Try
        End While

        If Not File.Exists(packagePath) Then
            Return "تعذر تنزيل حزمة التحديث بعد " & maxRetries & " محاولات: " & If(lastError IsNot Nothing, lastError.Message, "انقطع الاتصال بالسيرفر.")
        End If

        ' إعداد معلومات التحديث المعلق للأداة التنفيذية
        Try
            Dim pending = New JObject From {
                {"version", manifest.Version},
                {"package_path", packagePath},
                {"target_path", Application.StartupPath},
                {"main_exe", Application.ExecutablePath}
            }
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

            ' ══════════════════════════════════════════════════════════════════════════
            ' أمان: الأولوية لمشغّل محمي في %ProgramData%\Sestamk\runner (صلاحية المسؤولين فقط)،
            ' وإلا تشغيل الأداة من مجلد التثبيت المحمي نفسه مع تمرير --target الموثوق.
            ' ══════════════════════════════════════════════════════════════════════════
            Dim protectedRunner As String = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Sestamk", "runner", "update_runner.exe")

            Dim launchTarget As String = If(File.Exists(protectedRunner), protectedRunner, updater)
            Dim launchArgs As String = "--pending " & ChrW(34) & pendingPath & ChrW(34) &
                                       " --target " & ChrW(34) & Application.StartupPath & ChrW(34)

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

            If progress IsNot Nothing Then
                progress.Report(New VbDownloadProgressInfo With {
                    .Percentage = 100,
                    .BytesReceived = manifest.PackageSize,
                    .TotalBytes = manifest.PackageSize,
                    .SpeedFormatted = "",
                    .ProgressDetailFormatted = "اكتمل التنزيل بنجاح",
                    .TimeRemainingFormatted = "جاهز للتطبيق"
                })
            End If

            Return Nothing
        Catch ex As Exception
            Return "حدث خطأ أثناء تشغيل أداة التحديث: " & ex.Message
        End Try
    End Function

    Private Shared Function FormatSpeed(bytesPerSec As Double) As String
        If bytesPerSec <= 0 Then Return "0 ك.ب/ث"
        If bytesPerSec >= 1024.0 * 1024.0 Then
            Return (bytesPerSec / (1024.0 * 1024.0)).ToString("0.0") & " م.ب/ث"
        Else
            Return (bytesPerSec / 1024.0).ToString("0") & " ك.ب/ث"
        End If
    End Function

    Private Shared Function FormatProgressDetail(received As Long, total As Long) As String
        Dim rMb = (received / (1024.0 * 1024.0)).ToString("0.0")
        If total > 0 Then
            Dim tMb = (total / (1024.0 * 1024.0)).ToString("0.0")
            Return $"{rMb} من {tMb} ميجابايت"
        Else
            Return $"{rMb} ميجابايت"
        End If
    End Function

    Private Shared Function FormatRemainingTime(received As Long, total As Long, speed As Double) As String
        If total <= 0 OrElse speed <= 1024 OrElse received >= total Then Return ""
        Dim remainingBytes = total - received
        Dim seconds = remainingBytes / speed
        If seconds <= 1 Then Return "أقل من ثانية"
        If seconds < 60 Then Return $"متبقي حوالي {CInt(seconds)} ثانية"
        Dim mins = CInt(Math.Ceiling(seconds / 60.0))
        Return $"متبقي حوالي {mins} دقيقة"
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