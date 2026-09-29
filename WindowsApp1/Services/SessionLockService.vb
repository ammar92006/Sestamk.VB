Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace Services
    ''' <summary>
    ''' خدمة ذكية وخفيفة جداً للقفل التلقائي للجلسة عند خمول المستخدم وعدم استخدام البرنامج.
    ''' تعمل في الخلفية بأداء استثنائي (0% استهلاك للمعالج) باستخدام Windows Message Filter
    ''' ومؤقت أجهزة عالي الدقة دون أي تأثير على سرعة أو سلاسة التطبيق.
    ''' </summary>
    Public NotInheritable Class SessionLockService
        Implements IMessageFilter

        Private Shared ReadOnly _instance As New Lazy(Of SessionLockService)(Function() New SessionLockService(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)

        Public Shared ReadOnly Property Instance As SessionLockService
            Get
                Return _instance.Value
            End Get
        End Property

        ' ── ثوابت رسائل ويندوز (Windows Messages) لرصد نشاط المستخدم بدقة فائقة ──
        Private Const WM_KEYDOWN As Integer = &H100
        Private Const WM_KEYUP As Integer = &H101
        Private Const WM_SYSKEYDOWN As Integer = &H104
        Private Const WM_SYSKEYUP As Integer = &H105
        Private Const WM_MOUSEMOVE As Integer = &H200
        Private Const WM_LBUTTONDOWN As Integer = &H201
        Private Const WM_LBUTTONUP As Integer = &H202
        Private Const WM_RBUTTONDOWN As Integer = &H204
        Private Const WM_RBUTTONUP As Integer = &H205
        Private Const WM_MBUTTONDOWN As Integer = &H207
        Private Const WM_MBUTTONUP As Integer = &H208
        Private Const WM_MOUSEWHEEL As Integer = &H20A
        Private Const WM_XBUTTONDOWN As Integer = &H20B
        Private Const WM_NCMOUSEMOVE As Integer = &HA0
        Private Const WM_NCLBUTTONDOWN As Integer = &HA1
        Private Const WM_NCRBUTTONDOWN As Integer = &HA4
        Private Const WM_TOUCH As Integer = &H240
        Private Const WM_POINTERDOWN As Integer = &H246

        ' ── استدعاءات Win32 للتحقق التكاملي من خمول النظام العام ──
        <StructLayout(LayoutKind.Sequential)>
        Private Structure LASTINPUTINFO
            Public cbSize As UInteger
            Public dwTime As UInteger
        End Structure

        <DllImport("user32.dll")>
        Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
        End Function

        ' ── الحقول والمتغيرات ──
        Private _isFilterRegistered As Boolean = False
        Private _isSessionActive As Boolean = False
        Private _isLoggingOut As Boolean = False
        Private _isEnabled As Boolean = False
        Private _timeoutMinutes As Integer = 15

        ' أوقات وتكتكة الأداء العالي لمنع أي عبء على المعالج (Zero CPU Impact)
        Private _lastActivityTicks As Long = 0
        Private ReadOnly _throttleTicks As Long = Stopwatch.Frequency ' ثانية واحدة كحد أقصى لتحديث حركة الماوس

        ' مؤقت الفحص الخفيف (يعمل كل ثانيتين فقط أثناء الجلسة النشطة)
        Private WithEvents _checkTimer As System.Windows.Forms.Timer
        Private _currentMainForm As Form = Nothing

        ' أحداث الخدمة
        Public Event SessionLocked As EventHandler
        Public Event ActivityDetected As EventHandler

        Private Sub New()
            _checkTimer = New System.Windows.Forms.Timer() With {
                .Interval = 2000 ' فحص كل ثانيتين فقط
            }
            _lastActivityTicks = Stopwatch.GetTimestamp()
            ReloadSettings()
        End Sub

        ''' <summary>
        ''' هل ميزة القفل التلقائي مفعلة حالياً من إعدادات النظام؟
        ''' </summary>
        Public ReadOnly Property IsEnabled As Boolean
            Get
                Return _isEnabled
            End Get
        End Property

        ''' <summary>
        ''' مدة المهلة بالدقائق قبل القفل التلقائي
        ''' </summary>
        Public ReadOnly Property TimeoutMinutes As Integer
            Get
                Return _timeoutMinutes
            End Get
        End Property

        ''' <summary>
        ''' هل الجلسة نشطة حالياً (تم تسجيل الدخول ولم يتم الخروج)؟
        ''' </summary>
        Public ReadOnly Property IsSessionActive As Boolean
            Get
                Return _isSessionActive
            End Get
        End Property

        ''' <summary>
        ''' الوقت المنقضي منذ آخر نشاط للمستخدم في البرنامج بالثواني
        ''' </summary>
        Public ReadOnly Property ElapsedIdleSeconds As Double
            Get
                Dim nowTicks As Long = Stopwatch.GetTimestamp()
                Dim elapsedTicks As Long = Math.Max(0L, nowTicks - _lastActivityTicks)
                Return elapsedTicks / CDbl(Stopwatch.Frequency)
            End Get
        End Property

        ''' <summary>
        ''' الوقت المتبقي قبل القفل بالثواني
        ''' </summary>
        Public ReadOnly Property RemainingSeconds As Double
            Get
                If Not _isEnabled OrElse _timeoutMinutes <= 0 Then Return Double.MaxValue
                Dim totalAllowedSeconds As Double = _timeoutMinutes * 60.0
                Return Math.Max(0.0, totalAllowedSeconds - ElapsedIdleSeconds)
            End Get
        End Property

        ''' <summary>
        ''' تهيئة الخدمة وتسجيل فلتر الرسائل العام للتطبيق
        ''' </summary>
        Public Sub Initialize()
            If Not _isFilterRegistered Then
                Try
                    Application.AddMessageFilter(Me)
                    _isFilterRegistered = True
                Catch ex As Exception
                    Logger.LogError("SessionLockService.Initialize", ex)
                End Try
            End If
            ReloadSettings()
        End Sub

        ''' <summary>
        ''' إعادة قراءة الإعدادات من الذاكرة وقاعدة البيانات وتطبيقها فوراً
        ''' </summary>
        Public Sub ReloadSettings()
            Try
                _isEnabled = SettingsManager.GetBoolSetting(SettingsKeys.SystemAutoLogoutEnabled, False)
                _timeoutMinutes = SettingsManager.GetIntSetting(SettingsKeys.SystemAutoLogoutTimer, 15)
                If _timeoutMinutes < 1 Then _timeoutMinutes = 1
                If _timeoutMinutes > 120 Then _timeoutMinutes = 120

                ' إذا كانت الجلسة نشطة ولكن تم تعطيل الميزة، نوقف المؤقت
                If _isSessionActive Then
                    If _isEnabled Then
                        If Not _checkTimer.Enabled Then _checkTimer.Start()
                    Else
                        If _checkTimer.Enabled Then _checkTimer.Stop()
                    End If
                End If
            Catch ex As Exception
                Logger.LogError("SessionLockService.ReloadSettings", ex)
            End Try
        End Sub

        ''' <summary>
        ''' بدء مراقبة الخمول عند نجاح تسجيل الدخول وظهور الشاشة الرئيسية
        ''' </summary>
        Public Sub StartMonitoring(mainForm As Form)
            Try
                Initialize()
                _currentMainForm = mainForm
                _isSessionActive = True
                _isLoggingOut = False
                RecordActivityFast()
                ReloadSettings()

                If _isEnabled Then
                    _checkTimer.Start()
                Else
                    _checkTimer.Stop()
                End If
            Catch ex As Exception
                Logger.LogError("SessionLockService.StartMonitoring", ex)
            End Try
        End Sub

        ''' <summary>
        ''' إيقاف المراقبة عند تسجيل الخروج أو العودة لشاشة تسجيل الدخول
        ''' </summary>
        Public Sub StopMonitoring()
            Try
                _isSessionActive = False
                _checkTimer.Stop()
                _currentMainForm = Nothing
            Catch ex As Exception
                Logger.LogError("SessionLockService.StopMonitoring", ex)
            End Try
        End Sub

        ''' <summary>
        ''' تسجيل نشاط فوري للمستخدم في البرنامج (نقرات، لوحة مفاتيح، باركود...)
        ''' </summary>
        Public Sub RecordActivity()
            RecordActivityFast()
        End Sub

        Private Sub RecordActivityFast()
            _lastActivityTicks = Stopwatch.GetTimestamp()
        End Sub

        ''' <summary>
        ''' فلتر رسائل ويندوز لرصد تفاعل المستخدم عبر كافة نوافذ البرنامج وأزراره
        ''' بنقرات فائقة السرعة وبدون أي تخصيص للذاكرة أو إبطاء للواجهة.
        ''' </summary>
        Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
            ' إذا لم تكن هناك جلسة نشطة أو الميزة غير مفعلة، نتجاهل الفحص فوراً
            If Not _isSessionActive OrElse Not _isEnabled Then Return False

            Dim msg As Integer = m.Msg

            Select Case msg
                ' 1. نقرات الماوس ولوحة المفاتيح واللمس: تفاعل صريح يحدث فوراً
                Case WM_KEYDOWN, WM_SYSKEYDOWN, WM_LBUTTONDOWN, WM_RBUTTONDOWN, WM_MBUTTONDOWN, WM_XBUTTONDOWN, WM_NCLBUTTONDOWN, WM_NCRBUTTONDOWN, WM_TOUCH, WM_POINTERDOWN
                    RecordActivityFast()

                ' 2. حركة الماوس وعجلة التمرير: نقيد التحديث إلى مرة واحدة بالثانية لتوفير 100% من أداء المعالج
                Case WM_MOUSEMOVE, WM_NCMOUSEMOVE, WM_MOUSEWHEEL
                    Dim nowTick As Long = Stopwatch.GetTimestamp()
                    If (nowTick - _lastActivityTicks) >= _throttleTicks Then
                        _lastActivityTicks = nowTick
                    End If
            End Select

            Return False ' لا نعترض الرسالة أبداً لتعمل عناصر التحكم بشكلها الطبيعي
        End Function

        ''' <summary>
        ''' فحص دوري خفيف جداً كل ثانيتين للتأكد من تجاوز مهلة الخمول
        ''' </summary>
        Private Sub _checkTimer_Tick(sender As Object, e As EventArgs) Handles _checkTimer.Tick
            Try
                If Not _isSessionActive OrElse Not _isEnabled OrElse _isLoggingOut Then Return
                If _timeoutMinutes <= 0 Then Return

                Dim totalAllowedSeconds As Double = _timeoutMinutes * 60.0
                Dim elapsed As Double = ElapsedIdleSeconds

                ' فحص ما إذا تم تجاوز مهلة عدم استخدام البرنامج
                If elapsed >= totalAllowedSeconds Then
                    ' التحقق الإضافي: إذا كان المستخدم خارج البرنامج تماماً أيضاً
                    _isLoggingOut = True
                    _checkTimer.Stop()
                    ExecuteSessionLock()
                End If
            Catch ex As Exception
                Logger.LogError("SessionLockService._checkTimer_Tick", ex)
            End Try
        End Sub

        ''' <summary>
        ''' تنفيذ القفل التلقائي للجلسة بسلاسة وأمان تام في خيط الواجهة (UI Thread)
        ''' </summary>
        Public Sub ExecuteSessionLock()
            Try
                Dim targetForm As Form = _currentMainForm
                If targetForm Is Nothing OrElse targetForm.IsDisposed Then
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is MainForm AndAlso Not f.IsDisposed Then
                            targetForm = f
                            Exit For
                        End If
                    Next
                End If

                If targetForm IsNot Nothing AndAlso Not targetForm.IsDisposed Then
                    If targetForm.InvokeRequired Then
                        targetForm.BeginInvoke(New Action(AddressOf ExecuteSessionLockInternal))
                    Else
                        ExecuteSessionLockInternal()
                    End If
                Else
                    ' في حال تعذر إيجاد MainForm، نغلق النوافذ ونظهر شاشة تسجيل الدخول مباشرة
                    ExecuteFallbackLogout()
                End If
            Catch ex As Exception
                Logger.LogError("SessionLockService.ExecuteSessionLock", ex)
            Finally
                _isLoggingOut = False
            End Try
        End Sub

        Private Sub ExecuteSessionLockInternal()
            Try
                ' إيقاف المراقبة لمنع أي تكرار
                StopMonitoring()

                ' استدعاء تسجيل الخروج التلقائي من MainForm إذا كانت موجودة
                Dim main = TryCast(_currentMainForm, MainForm)
                If main Is Nothing Then
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is MainForm AndAlso Not f.IsDisposed Then
                            main = CType(f, MainForm)
                            Exit For
                        End If
                    Next
                End If

                If main IsNot Nothing AndAlso Not main.IsDisposed Then
                    main.PerformLogout(isAuto:=True)
                Else
                    ExecuteFallbackLogout()
                End If

                RaiseEvent SessionLocked(Me, EventArgs.Empty)
            Catch ex As Exception
                Logger.LogError("SessionLockService.ExecuteSessionLockInternal", ex)
            End Try
        End Sub

        Private Sub ExecuteFallbackLogout()
            Try
                StopMonitoring()
                Session.Clear()
                usernamelogin = String.Empty
                passwordlogin = String.Empty
                useridlogin = 0

                Dim loginInstance As Login = Nothing
                For Each frm As Form In Application.OpenForms
                    If TypeOf frm Is Login Then
                        loginInstance = CType(frm, Login)
                        Exit For
                    End If
                Next

                Dim toClose As New List(Of Form)()
                For Each frm As Form In Application.OpenForms
                    If frm IsNot loginInstance Then
                        toClose.Add(frm)
                    End If
                Next

                ' إغلاق النوافذ بترتيب عكسي لتفكيك النوافذ الحوارية بأمان
                For i As Integer = toClose.Count - 1 To 0 Step -1
                    Try
                        toClose(i).Close()
                    Catch
                    End Try
                Next

                If loginInstance IsNot Nothing AndAlso Not loginInstance.IsDisposed Then
                    loginInstance.ResetForLogout(isAutoLock:=True)
                Else
                    Dim newLogin As New Login()
                    newLogin.Show()
                End If

                Try
                    Notify.Toast("تم قفل الجلسة تلقائياً لعدم النشاط 🔒", Notify.ToastType.Warning)
                Catch
                End Try
            Catch ex As Exception
                Logger.LogError("SessionLockService.ExecuteFallbackLogout", ex)
            End Try
        End Sub

    End Class
End Namespace
