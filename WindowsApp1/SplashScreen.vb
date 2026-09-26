Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports WindowsApp1.Services

Public Class SplashScreen

    Private Const FadeTime As Integer = 300
    Private Const AnimationInterval As Integer = 15

    Private _initializationCompleted As Boolean = False
    Private _currentProgress As Integer = 0
    Private _targetProgress As Integer = 0

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0.0

        Try
            If picLogo IsNot Nothing AndAlso picLogo.Image Is Nothing Then
                picLogo.Image = My.Resources.Resources.loge
            End If
        Catch ex As Exception
            Debug.WriteLine("Splash logo load error: " & ex.Message)
        End Try

        Timer1.Interval = AnimationInterval
        Timer2.Interval = AnimationInterval

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0

        lblPercent.Text = "0%"

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.None

        ' بدء مؤقت التلاشي والأنيميشن
        Timer1.Start()

        ' تشغيل عملية فحص وتهيئة النظام غير المتزامنة في الخلفية
        Dim initTask = InitializeApplicationAsync()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' تأثير التلاشي للداخل (Fade In)
        If Me.Opacity < 1.0 Then
            Dim OpacityIncrease As Double = 1.0 / (FadeTime / AnimationInterval)
            Me.Opacity += OpacityIncrease
            If Me.Opacity > 1.0 Then Me.Opacity = 1.0
        End If

        ' حركة ناعمة لشريط التقدم نحو القيمة المستهدفة
        If _currentProgress < _targetProgress Then
            _currentProgress = Math.Min(100, _currentProgress + 2)
            ProgressBar1.Value = _currentProgress
            lblPercent.Text = _currentProgress.ToString() & "%"
        End If

        ' إذا اكتملت التهيئة ووصل شريط التقدم إلى 100%
        If _initializationCompleted AndAlso _currentProgress >= 100 Then
            Timer1.Stop()
            Timer2.Start()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ' مرحلة التلاشي للخارج (Fade Out)
        If Me.Opacity > 0.0 Then
            Dim OpacityDecrease As Double = 1.0 / (FadeTime / AnimationInterval)
            Me.Opacity -= OpacityDecrease
            If Me.Opacity < 0.0 Then Me.Opacity = 0.0
        Else
            Timer2.Stop()

            ' فحص ما إذا كانت شاشة تسجيل الدخول مفتوحة بالفعل لمنع تكرار النوافذ
            Dim loginAlreadyOpen As Boolean = False
            For Each f As Form In Application.OpenForms
                If TypeOf f Is Login AndAlso Not f.IsDisposed Then
                    loginAlreadyOpen = True
                    f.Show()
                    f.BringToFront()
                    Exit For
                End If
            Next

            If Not loginAlreadyOpen Then
                Dim mainForm As New Login()
                mainForm.Show()
            End If

            Me.Hide()
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' دورة الفحص الذكية وبدء التشغيل غير المتزامنة
    ''' تفحص محرك LocalDB وتشغله وتتحقق من الجداول دون أي تجميد للواجهة
    ''' </summary>
    Private Async Function InitializeApplicationAsync() As Task
        Try
            ' ── الخطوة 1: فحص إعدادات ومحرك قاعدة البيانات ──
            UpdateStatus("جاري فحص إعدادات ومحرك قاعدة البيانات...", 20)
            Await Task.Delay(250)

            DBModule.LoadDbSettings()

            ' ── الخطوة 2: فحص وتشغيل محرك LocalDB إن كان مفعلاً ──
            Dim isLocalDbMode = (DBModule.dbEngineType = "localdb" OrElse DBModule.server.ToLower().Contains("(localdb)"))

            If isLocalDbMode Then
                UpdateStatus("جاري فحص وتشغيل محرك SQL Server LocalDB...", 45)

                ' التحقق من تثبيت محرك LocalDB
                If Not LocalDbManager.IsLocalDbInstalled() Then
                    ' المحرك غير مثبت: نبحث عن حزمة التثبيت المرفقة
                    Dim msiPath = LocalDbManager.FindLocalDbMsiInstaller()
                    If Not String.IsNullOrEmpty(msiPath) Then
                        Dim ask = MessageBox.Show("محرك SQL Server LocalDB غير مثبت على هذا الجهاز." & vbCrLf &
                                                  "تم العثور على حزمة التثبيت المرفقة. هل تريد تثبيت المحرك الآن تلقائياً؟",
                                                  "تثبيت محرك قاعدة البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If ask = DialogResult.Yes Then
                            UpdateStatus("جاري تثبيت محرك LocalDB صامتاً، يرجى الانتظار...", 50)
                            Dim installed = Await LocalDbManager.InstallLocalDbSilentlyAsync(msiPath)
                            If Not installed Then
                                MessageBox.Show("تعذر تثبيت محرك LocalDB تلقائياً. يرجى تثبيت ملف SqlLocalDB.msi كمسؤول.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End If
                End If

                ' التأكد من إنشاء وتشغيل الـ Instance
                If LocalDbManager.IsLocalDbInstalled() Then
                    Await LocalDbManager.EnsureInstanceRunningAsync(DBModule.localDbInstanceName)
                End If
            End If

            ' ── الخطوة 3: اختبار الاتصال بقاعدة البيانات ──
            UpdateStatus("جاري الاتصال بقاعدة البيانات...", 70)
            Await Task.Delay(200)

            Dim connected = Await Task.Run(Function() DBModule.TestConnection())
            If Not connected Then
                ' تجربة الاتصال التلقائي الصامت
                connected = Await Task.Run(Function() DBModule.TryAutoConnect())
            End If

            ' ── الخطوة 4: فحص وترقيع هيكل الجداول وتحميل البيانات ──
            If connected Then
                UpdateStatus("فحص الجداول والبيانات وتكامل النظام...", 85)
                Try
                    Dim maintService As New DatabaseMaintenanceService(DBModule.ConnectionString)
                    Await maintService.CheckAndRepairDatabaseAsync()
                Catch exMaint As Exception
                    Debug.WriteLine("Splash maintenance error: " & exMaint.Message)
                End Try

                ' تحميل بيانات المدير المهيّأة لهذا النشاط
                Settingsall.LoadAdminCredentials()

                ' تهيئة خدمة المزامنة السحابية وتتبع التغييرات في الخلفية
                Try
                    Dim syncInitTask = Task.Run(Async Function()
                                                    Await Services.Cloud.CloudSyncService.Instance.InitializeAsync().ConfigureAwait(False)
                                                End Function)
                Catch exSync As Exception
                    Debug.WriteLine("Splash CloudSync init error: " & exSync.Message)
                End Try

                ' معالج أول تشغيل (يظهر فقط إذا كان تثبيتاً جديداً)
                Try
                    StartupManager.ShowFirstRunIfNeeded()
                Catch exFirstRun As Exception
                    Debug.WriteLine("Splash first run error: " & exFirstRun.Message)
                End Try
            Else
                UpdateStatus("تعذر الاتصال المباشر، جاري المتابعة...", 85)
                Dim msg As String =
                    "تعذر الاتصال التلقائي بقاعدة البيانات." & vbCrLf & vbCrLf &
                    "• إذا كان هذا أول تشغيل على جهاز جديد، يمكنك ضبط الاتصال أو تهيئة محرك LocalDB الداخلي من شاشة الإعدادات." & vbCrLf &
                    "• هل ترغب في فتح شاشة إعدادات قاعدة البيانات الآن؟"

                Dim choice = MessageBox.Show(msg, "إعداد الاتصال بقاعدة البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If choice = DialogResult.Yes Then
                    Global.WindowsApp1.Settings.OpenDatabaseSettings(databaseOnly:=True)
                    If DBModule.TestConnection() Then
                        Settingsall.LoadAdminCredentials()
                    End If
                End If
            End If

            ' ── الخطوة 5: اكتمال التهيئة بنجاح ──
            UpdateStatus("تم تجهيز النظام بنجاح! جاري فتح البرنامج...", 100)
            Await Task.Delay(350)

        Catch ex As Exception
            Debug.WriteLine("InitializeApplicationAsync error: " & ex.Message)
            UpdateStatus("جاري فتح البرنامج...", 100)
        Finally
            _initializationCompleted = True
        End Try
    End Function

    Private Sub UpdateStatus(message As String, progressPercent As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateStatus(message, progressPercent))
            Return
        End If

        Label5.Text = message
        _targetProgress = Math.Min(100, Math.Max(_currentProgress, progressPercent))
    End Sub

End Class