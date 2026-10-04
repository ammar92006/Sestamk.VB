Imports System.Linq
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Namespace Services.Updates
    ''' <summary>
    ''' خدمة فحص التحديثات الذكية في الخلفية (Background Update Monitor)
    ''' تعمل في الخلفية بدون أي تأثير نهائياً على أداء البرنامج أو واجهة المستخدم (0% CPU / 0ms UI blocking)
    ''' تتحقق تلقائياً من توفر تحديث جديد مخصص لقناة العميل (Public / Beta) عبر Supabase REST API
    ''' وتُشعر المستخدم فور إطلاق أي إصدار جديد أثناء تشغيله للبرنامج مع إمكانية الترقية الفورية.
    ''' </summary>
    Public NotInheritable Class BackgroundUpdateService
        Private Sub New()
        End Sub

        Private Shared _timer As System.Threading.Timer = Nothing
        Private Shared _isChecking As Integer = 0
        Private Shared _lastNotifiedVersion As String = ""
        Private Shared ReadOnly _httpClient As New HttpClient() With {.Timeout = TimeSpan.FromSeconds(6)}

        ''' <summary>
        ''' حدث يتم إطلاقه عند اكتشاف تحديث جديد متوافق مع القناة
        ''' </summary>
        Public Shared Event UpdateDetected(version As String, channel As String, manifestUrl As String, isMandatory As Boolean)

        ''' <summary>
        ''' بدء تشغيل خدمة المراقبة في الخلفية
        ''' تبدأ بعد 30 ثانية من إقلاع البرنامج لضمان سرعة الفتح، وتفحص دورياً كل 3 دقائق
        ''' </summary>
        Public Shared Sub StartMonitoring(Optional intervalMinutes As Integer = 3)
            Try
                If _timer IsNot Nothing Then Return ' الخدمة تعمل بالفعل

                Dim initialDelayMs = 30000 ' 30 ثانية انتظار أولي
                Dim intervalMs = Math.Max(60000, intervalMinutes * 60000) ' 3 دقائق افتراضياً

                _timer = New System.Threading.Timer(
                    AddressOf TimerCallback,
                    Nothing,
                    initialDelayMs,
                    intervalMs)

                Debug.WriteLine($"[BackgroundUpdateService] Started with interval: {intervalMinutes} min")
            Catch ex As Exception
                Debug.WriteLine("[BackgroundUpdateService] StartMonitoring error: " & ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' إيقاف خدمة المراقبة
        ''' </summary>
        Public Shared Sub StopMonitoring()
            Try
                If _timer IsNot Nothing Then
                    _timer.Dispose()
                    _timer = Nothing
                    Debug.WriteLine("[BackgroundUpdateService] Stopped.")
                End If
            Catch ex As Exception
                Debug.WriteLine("[BackgroundUpdateService] StopMonitoring error: " & ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' تشغيل فحص فوري في الخلفية
        ''' </summary>
        Public Shared Sub CheckNowAsync()
            Task.Run(Sub() CheckForUpdatesInternalAsync())
        End Sub

        Private Shared Sub TimerCallback(state As Object)
            Task.Run(Sub() CheckForUpdatesInternalAsync())
        End Sub

        Private Shared Async Sub CheckForUpdatesInternalAsync()
            ' 1. التحقق السريع من توفر الإنترنت (0ms / 0 bandwidth)
            If Not NetworkInterface.GetIsNetworkAvailable() Then Return

            ' 2. منع تشغيل أكثر من فحص متزامن
            If Interlocked.CompareExchange(_isChecking, 1, 0) <> 0 Then Return

            Try
                ' 3. قراءة قناة العميل الفعلية (Public أو Beta) من الكاش
                Dim userChannel = "public"
                Try
                    Dim cache = LicenseCache.Load()
                    If cache IsNot Nothing Then
                        Dim ch = Convert.ToString(cache("channel"))
                        If Not String.IsNullOrWhiteSpace(ch) Then
                            userChannel = ch.Trim().ToLowerInvariant()
                        End If
                    End If
                Catch __logEx As Exception
                    Logger.LogError("BackgroundUpdateService.vb:98", __logEx)
                End Try

                ' 4. استعلام REST سريع وخفيف جداً من Supabase (~500 بايت فقط)
                Dim url = $"{LicenseSettings.SupabaseUrl.TrimEnd("/"c)}/rest/v1/updates?channel=eq.{Uri.EscapeDataString(userChannel)}&is_active=eq.true&order=created_at.desc&limit=1"

                Using req As New HttpRequestMessage(HttpMethod.Get, url)
                    req.Headers.Add("apikey", LicenseSettings.PublishableKey)
                    req.Headers.Add("Authorization", "Bearer " & LicenseSettings.PublishableKey)
                    req.Headers.Add("User-Agent", "Sestamk-VB-Client")

                    Dim resp = Await _httpClient.SendAsync(req).ConfigureAwait(False)
                    If Not resp.IsSuccessStatusCode Then Return

                    Dim jsonStr = Await resp.Content.ReadAsStringAsync().ConfigureAwait(False)
                    If String.IsNullOrWhiteSpace(jsonStr) Then Return

                    Dim arr = JArray.Parse(jsonStr)
                    If arr.Count = 0 Then Return

                    Dim row = DirectCast(arr(0), JObject)
                    Dim serverVersion = Convert.ToString(row("version"))
                    If String.IsNullOrWhiteSpace(serverVersion) Then Return

                    ' 5. التحقق الصارم من أن الإصدار أحدث من الإصدار الحالي المثبت
                    Dim curVer As Version = Nothing
                    Dim srvVer As Version = Nothing
                    Dim cleanCur = Application.ProductVersion.TrimStart("v"c, "V"c)
                    Dim cleanSrv = serverVersion.TrimStart("v"c, "V"c)
                    Dim isNewer = False

                    If Version.TryParse(cleanCur, curVer) AndAlso Version.TryParse(cleanSrv, srvVer) Then
                        isNewer = (srvVer > curVer)
                    Else
                        isNewer = Not String.Equals(cleanCur, cleanSrv, StringComparison.OrdinalIgnoreCase)
                    End If

                    If Not isNewer Then Return

                    ' 6. منع تكرار الإشعار لنفس الإصدار في نفس الجلسة
                    If String.Equals(_lastNotifiedVersion, cleanSrv, StringComparison.OrdinalIgnoreCase) Then
                        Return
                    End If
                    _lastNotifiedVersion = cleanSrv

                    ' 7. استخراج تفاصيل التحديث
                    Dim manifestUrl = Convert.ToString(row("manifest_url"))
                    Dim isMandatory = False
                    If row("is_mandatory") IsNot Nothing Then
                        Boolean.TryParse(Convert.ToString(row("is_mandatory")), isMandatory)
                    End If

                    Dim channelNameUpper = userChannel.ToUpperInvariant()

                    ' 8. إطلاق حدث الإشعار للمشتركين
                    RaiseEvent UpdateDetected(cleanSrv, userChannel, manifestUrl, isMandatory)

                    ' 9. إرسال الإشعار إلى خيط الواجهة الرسومية (UI Thread)
                    DispatchToUI(Sub()
                                     ShowUpdateNotification(cleanSrv, channelNameUpper, manifestUrl, row, isMandatory)
                                 End Sub)
                End Using
            Catch ex As Exception
                ' في حال انقطاع الشبكة أو أي خطأ غير متوقع، يستمر البرنامج بدون أي مقاطعة
                Debug.WriteLine("[BackgroundUpdateService] Check error: " & ex.Message)
            Finally
                Interlocked.Exchange(_isChecking, 0)
            End Try
        End Sub

        Private Shared Sub ShowUpdateNotification(newVersion As String, channelName As String, manifestUrl As String, row As JObject, isMandatory As Boolean)
            Try
                Dim title = "🚀 تحديث جديد متوفر!"
                Dim message = $"يتوفر إصدار جديد من سستمك (v{newVersion}) لقناة {channelName}. انقر هنا للمعاينة والتحديث فوراً."

                If isMandatory Then
                    title = "⚠️ تحديث إلزامي متوفر!"
                    message = $"يتوفر تحديث إلزامي جديد (v{newVersion}) لقناة {channelName}. يرجى الترقية الآن لضمان استمرار الخدمة."
                End If

                ' عرض Toast تفاعلي قابل للنقر
                Notify.ToastWithAction(
                    title,
                    message,
                    Sub()
                        OpenUpdatePrompt(manifestUrl, row)
                    End Sub,
                    If(isMandatory, Notify.ToastType.Warning, Notify.ToastType.Info),
                    If(isMandatory, 15000, 10000))

                ' إضافة الإشعار أيضاً في مركز الإشعارات (الجرس) ليبقى محفوظاً ومتاحاً للمستخدم في أي وقت
                Try
                    NotificationManager.Instance.CreateNotification(
                        If(isMandatory, NotificationManager.NotificationType.Warning, NotificationManager.NotificationType.System),
                        title,
                        message,
                        If(isMandatory, NotificationManager.NotificationPriority.Critical, NotificationManager.NotificationPriority.High),
                        Nothing,
                        icon:="settings",
                        isActionable:=True,
                        actionType:="OpenUpdate",
                        actionData:=manifestUrl
                    )
                Catch exNotif As Exception
                    Debug.WriteLine("[BackgroundUpdateService] NotificationManager error: " & exNotif.Message)
                End Try

                ' إذا كان التحديث إلزامياً، يتم فتح نافذة التحديث مباشرة بعد فترة بسيطة إن لم يتفاعل
                If isMandatory Then
                    OpenUpdatePrompt(manifestUrl, row)
                End If
            Catch ex As Exception
                Debug.WriteLine("[BackgroundUpdateService] ShowUpdateNotification error: " & ex.Message)
            End Try
        End Sub

        Public Shared Async Sub OpenUpdatePrompt(Optional manifestUrl As String = "", Optional updateRow As JObject = Nothing)
            Try
                ' منع تكرار فتح النافذة إن كانت مفتوحة
                Dim openNotifier = Application.OpenForms.OfType(Of FormUpdateNotifier)().FirstOrDefault()
                If openNotifier IsNot Nothing AndAlso Not openNotifier.IsDisposed Then
                    openNotifier.BringToFront()
                    openNotifier.Focus()
                    Return
                End If

                Dim ownerForm As Form = Form.ActiveForm
                If ownerForm Is Nothing OrElse ownerForm.IsDisposed Then
                    ownerForm = Application.OpenForms.OfType(Of MainForm)().FirstOrDefault()
                End If

                Dim manifest As VbUpdateManifest = Nothing

                ' 1. محاولة جلب المانيفست المحدث من GitHub
                If Not String.IsNullOrWhiteSpace(manifestUrl) Then
                    Try
                        Using client As New HttpClient()
                            client.Timeout = TimeSpan.FromSeconds(8)
                            client.DefaultRequestHeaders.Add("User-Agent", "Sestamk-VB-Client")
                            Dim jsonStr = Await client.GetStringAsync(manifestUrl)
                            If Not String.IsNullOrWhiteSpace(jsonStr) Then
                                manifest = UpdateCoordinator.ParseManifest(JObject.Parse(jsonStr))
                            End If
                        End Using
                    Catch ex As Exception
                        Debug.WriteLine("[BackgroundUpdateService] Manifest fetch error: " & ex.Message)
                    End Try
                End If

                ' 2. خطة بديلة: بناء المانيفست مباشرة من بيانات Supabase
                If manifest Is Nothing AndAlso updateRow IsNot Nothing Then
                    manifest = UpdateCoordinator.ParseManifest(updateRow)
                End If

                If manifest IsNot Nothing Then
                    Using prompt As New FormUpdateNotifier(manifest)
                        If ownerForm IsNot Nothing AndAlso Not ownerForm.IsDisposed Then
                            prompt.ShowDialog(ownerForm)
                        Else
                            prompt.ShowDialog()
                        End If
                    End Using
                End If
            Catch ex As Exception
                Debug.WriteLine("[BackgroundUpdateService] OpenUpdatePrompt error: " & ex.Message)
            End Try
        End Sub

        Private Shared Sub DispatchToUI(action As Action)
            Try
                Dim targetForm As Form = Form.ActiveForm
                If targetForm Is Nothing OrElse targetForm.IsDisposed Then
                    targetForm = Application.OpenForms.OfType(Of MainForm)().FirstOrDefault()
                End If
                If targetForm Is Nothing OrElse targetForm.IsDisposed Then
                    targetForm = Application.OpenForms.Cast(Of Form)().FirstOrDefault(Function(f) f.Visible AndAlso Not f.IsDisposed)
                End If

                If targetForm IsNot Nothing AndAlso Not targetForm.IsDisposed Then
                    If targetForm.InvokeRequired Then
                        targetForm.BeginInvoke(action)
                    Else
                        action.Invoke()
                    End If
                Else
                    action.Invoke()
                End If
            Catch ex As Exception
                Debug.WriteLine("[BackgroundUpdateService] DispatchToUI error: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace
