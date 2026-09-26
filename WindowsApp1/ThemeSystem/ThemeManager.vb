Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Microsoft.Win32

''' <summary>
''' المدير المركزي لنظام الثيمات (Theme Manager) — نمط Singleton.
''' مسؤول عن: إدارة الباليتة الحالية، التبديل بين الثيمات، الحفظ والاسترجاع الفوري،
''' وتطبيق الثيم على كافة الشاشات المفتوحة مع دعم المزامنة التلقائية مع نظام ويندوز.
''' </summary>
Public NotInheritable Class ThemeManager

    Private Shared _instance As ThemeManager
    Private Shared ReadOnly _lock As New Object()

    Public Shared ReadOnly Property Instance As ThemeManager
        Get
            If _instance Is Nothing Then
                SyncLock _lock
                    If _instance Is Nothing Then
                        _instance = New ThemeManager()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property

    Private Sub New()
    End Sub

    ' ── الحالة الحالية ─────────────────────────────────────────
    Private _currentMode As ThemeMode = ThemeMode.System
    Private _currentTheme As AppTheme = AppTheme.Light
    Private _currentPalette As ThemePalette = New LightThemePalette()
    Private _initialized As Boolean = False
    Private _systemThemeTimer As System.Windows.Forms.Timer = Nothing

    Public ReadOnly Property CurrentMode As ThemeMode
        Get
            Return _currentMode
        End Get
    End Property

    Public ReadOnly Property CurrentTheme As AppTheme
        Get
            Return _currentTheme
        End Get
    End Property

    Public ReadOnly Property CurrentPalette As ThemePalette
        Get
            Return _currentPalette
        End Get
    End Property

    Public ReadOnly Property Palette As ThemePalette
        Get
            Return _currentPalette
        End Get
    End Property

    Public ReadOnly Property IsDark As Boolean
        Get
            Return _currentTheme = AppTheme.Dark
        End Get
    End Property

    ' ── حدث تغيير الثيم ─────────────────────────────────────────
    Public Event ThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)

    ' ── تعقب النوافذ لتطبيق السمة عالمياً على أي Dialog أو Form منبثق ───
    Private ReadOnly _hookedForms As New HashSet(Of Form)()
    Private ReadOnly _hookLock As New Object()

    ' ── التهيئة عند بدء التشغيل ────────────────────────────────
    Public Sub Initialize()
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return
        If _initialized Then Return

        _initialized = True
        LoadTheme()

        ' الاستماع لتغييرات تفضيلات مظهر النظام في ويندوز لحظياً
        Try
            AddHandler SystemEvents.UserPreferenceChanged, AddressOf OnUserPreferenceChanged
        Catch ex As Exception
        End Try

        If _currentMode = ThemeMode.System Then
            StartSystemThemeMonitoring()
        End If

        ' هوك تلقائي شامل يضمن إكساء أي نافذة حوارية (Modal Dialog) أو شاشة جديدة تفتح عبر ShowDialog() أو Show()
        Try
            AddHandler Application.Idle, AddressOf OnApplicationIdle
            AddHandler Application.EnterThreadModal, AddressOf OnEnterThreadModal
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OnApplicationIdle(sender As Object, e As EventArgs)
        ApplyThemeToUnregisteredOpenForms()
    End Sub

    Private Sub OnEnterThreadModal(sender As Object, e As EventArgs)
        ApplyThemeToUnregisteredOpenForms()
    End Sub

    Private Sub ApplyThemeToUnregisteredOpenForms()
        Try
            If Application.OpenForms Is Nothing Then Return

            Dim unhooked As List(Of Form) = Nothing

            SyncLock _hookLock
                For Each frm As Form In Application.OpenForms
                    If frm IsNot Nothing AndAlso Not frm.IsDisposed AndAlso Not _hookedForms.Contains(frm) Then
                        If unhooked Is Nothing Then unhooked = New List(Of Form)()
                        unhooked.Add(frm)
                        _hookedForms.Add(frm)
                    End If
                Next
            End SyncLock

            If unhooked IsNot Nothing Then
                For Each frm In unhooked
                    Dim targetForm As Form = frm
                    AddHandler targetForm.FormClosed, Sub()
                                                          SyncLock _hookLock
                                                              _hookedForms.Remove(targetForm)
                                                          End SyncLock
                                                      End Sub

                    ' إعادة التطبيق أيضاً عند اكتمال حدث Shown لضمان تجاوز أي ألوان ثابتة قد تكون في Form_Load
                    AddHandler targetForm.Shown, Sub()
                                                     Try
                                                         ApplyTheme(targetForm)
                                                     Catch
                                                     End Try
                                                 End Sub

                    ApplyTheme(targetForm)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' ── تغيير وضع المظهر ──────────────────────────────────────
    ''' <summary>
    ''' تعيين وضع المظهر: فاتح، داكن، أو تلقائي حسب مظهر نظام ويندوز.
    ''' </summary>
    Public Sub SetThemeMode(mode As ThemeMode)
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

        _currentMode = mode
        Dim targetTheme As AppTheme

        If mode = ThemeMode.System Then
            targetTheme = GetWindowsTheme()
            StartSystemThemeMonitoring()
        Else
            StopSystemThemeMonitoring()
            targetTheme = If(mode = ThemeMode.Dark, AppTheme.Dark, AppTheme.Light)
        End If

        _currentTheme = targetTheme
        _currentPalette = CreatePalette(targetTheme)

        SaveTheme()

        RaiseEvent ThemeChanged(Me, _currentTheme, _currentPalette)
        ApplyToAllOpenForms()
    End Sub

    ''' <summary>
    ''' تعيين الثيم المباشر (للتوافق مع الاستدعاءات الحالية).
    ''' </summary>
    Public Sub SetTheme(theme As AppTheme)
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return
        SetThemeMode(If(theme = AppTheme.Dark, ThemeMode.Dark, ThemeMode.Light))
    End Sub

    ''' <summary>التبديل الفوري بين Light و Dark.</summary>
    Public Sub ToggleTheme()
        If _currentTheme = AppTheme.Light Then
            SetThemeMode(ThemeMode.Dark)
        Else
            SetThemeMode(ThemeMode.Light)
        End If
    End Sub

    ' ── كشف ومراقبة مظهر نظام ويندوز اللحظي ───────────────────
    ''' <summary>
    ''' قراءة مظهر نظام ويندوز مباشرة من سجل النظام (Registry).
    ''' </summary>
    Public Shared Function GetWindowsTheme() As AppTheme
        Try
            Using key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Themes\Personalize")
                If key IsNot Nothing Then
                    Dim val = key.GetValue("AppsUseLightTheme")
                    If val IsNot Nothing Then
                        Dim intVal As Integer = Convert.ToInt32(val)
                        Return If(intVal = 0, AppTheme.Dark, AppTheme.Light)
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
        Return AppTheme.Light
    End Function

    Private Sub StartSystemThemeMonitoring()
        Try
            If _systemThemeTimer Is Nothing Then
                _systemThemeTimer = New System.Windows.Forms.Timer()
                _systemThemeTimer.Interval = 2000
                AddHandler _systemThemeTimer.Tick, AddressOf OnSystemThemeTimerTick
            End If
            If Not _systemThemeTimer.Enabled Then
                _systemThemeTimer.Start()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub StopSystemThemeMonitoring()
        Try
            If _systemThemeTimer IsNot Nothing AndAlso _systemThemeTimer.Enabled Then
                _systemThemeTimer.Stop()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OnSystemThemeTimerTick(sender As Object, e As EventArgs)
        If _currentMode = ThemeMode.System Then
            CheckAndApplySystemTheme()
        End If
    End Sub

    Private Sub OnUserPreferenceChanged(sender As Object, e As UserPreferenceChangedEventArgs)
        If _currentMode = ThemeMode.System Then
            CheckAndApplySystemTheme()
        End If
    End Sub

    Private Sub CheckAndApplySystemTheme()
        Try
            If _currentMode <> ThemeMode.System Then Return
            Dim detected = GetWindowsTheme()
            If detected <> _currentTheme Then
                If Application.OpenForms IsNot Nothing AndAlso Application.OpenForms.Count > 0 Then
                    Dim mainForm = Application.OpenForms(0)
                    If mainForm IsNot Nothing AndAlso Not mainForm.IsDisposed Then
                        If mainForm.InvokeRequired Then
                            mainForm.BeginInvoke(Sub() ApplySystemThemeChange(detected))
                            Return
                        End If
                    End If
                End If
                ApplySystemThemeChange(detected)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ApplySystemThemeChange(newTheme As AppTheme)
        If _currentMode <> ThemeMode.System Then Return
        If _currentTheme = newTheme Then Return

        _currentTheme = newTheme
        _currentPalette = CreatePalette(newTheme)

        RaiseEvent ThemeChanged(Me, _currentTheme, _currentPalette)
        ApplyToAllOpenForms()
    End Sub

    ' ── تطبيق الثيم على فورم محدد ──────────────────────────────
    Public Sub ApplyTheme(frm As Form)
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return
        If frm Is Nothing OrElse frm.IsDisposed Then Return
        ThemeHelper.ApplyToForm(frm, _currentPalette)
    End Sub

    ''' <summary>تطبيق الثيم على عنصر تحكم واحد وكافة أبنائه.</summary>
    Public Sub ApplyToControl(ctrl As Control)
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return
        If ctrl Is Nothing OrElse ctrl.IsDisposed Then Return
        ThemeHelper.ApplyToControl(ctrl, _currentPalette)
    End Sub

    ' ── الحفظ والاسترجاع (محلي فوري + مزامنة قاعدة البيانات) ──
    Private Function GetLocalConfigPath() As String
        Try
            Dim appPath = Path.Combine(Application.StartupPath, "theme.cfg")
            If File.Exists(appPath) Then Return appPath

            Dim commonDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk")
            Dim commonPath = Path.Combine(commonDir, "theme.cfg")
            If File.Exists(commonPath) Then Return commonPath

            ' فحص إمكانية الكتابة في مجلد التطبيق
            Dim testFile = Path.Combine(Application.StartupPath, ".theme_test")
            File.WriteAllText(testFile, "1")
            File.Delete(testFile)
            Return appPath
        Catch
            Dim commonDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk")
            If Not Directory.Exists(commonDir) Then Directory.CreateDirectory(commonDir)
            Return Path.Combine(commonDir, "theme.cfg")
        End Try
    End Function

    Private Sub SaveTheme()
        ' 1. حفظ فوري في ملف محلي خفيف جداً لضمان القراءة الصامتة الفورية عند الإقلاع
        Try
            Dim cfgPath = GetLocalConfigPath()
            If Not String.IsNullOrEmpty(cfgPath) Then
                Try
                    Dim parentDir = Path.GetDirectoryName(cfgPath)
                    If Not Directory.Exists(parentDir) Then Directory.CreateDirectory(parentDir)
                    File.WriteAllText(cfgPath, _currentMode.ToString())
                Catch ex As UnauthorizedAccessException
                    Dim commonDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk")
                    If Not Directory.Exists(commonDir) Then Directory.CreateDirectory(commonDir)
                    File.WriteAllText(Path.Combine(commonDir, "theme.cfg"), _currentMode.ToString())
                End Try
            End If
        Catch ex As Exception
        End Try

        ' 2. مزامنة قاعدة البيانات في خلفية غير حاجبة
        Task.Run(Sub()
                     Try
                         SettingsManager.SaveSetting(SettingsKeys.AppTheme, _currentMode.ToString())
                     Catch
                     End Try
                 End Sub)
    End Sub

    Private Sub LoadTheme()
        Dim loadedTheme As String = ""

        ' 1. قراءة سريعة فورية من الملف المحلي (0ms)
        Try
            Dim cfgPath = GetLocalConfigPath()
            If Not String.IsNullOrEmpty(cfgPath) AndAlso File.Exists(cfgPath) Then
                loadedTheme = File.ReadAllText(cfgPath).Trim()
            End If
        Catch
        End Try

        ' 2. تفسير الوضع المحفوظ
        Dim parsedMode As ThemeMode
        If Not String.IsNullOrWhiteSpace(loadedTheme) AndAlso [Enum].TryParse(Of ThemeMode)(loadedTheme, True, parsedMode) Then
            _currentMode = parsedMode
        Else
            _currentMode = ThemeMode.System
            Try
                Dim cfgPath = GetLocalConfigPath()
                If Not String.IsNullOrEmpty(cfgPath) Then
                    File.WriteAllText(cfgPath, "System")
                End If
            Catch
            End Try
        End If

        ' 3. تحديد الثيم الفعلي المطبق
        If _currentMode = ThemeMode.System Then
            _currentTheme = GetWindowsTheme()
        ElseIf _currentMode = ThemeMode.Dark Then
            _currentTheme = AppTheme.Dark
        Else
            _currentTheme = AppTheme.Light
        End If

        _currentPalette = CreatePalette(_currentTheme)
    End Sub

    ' ── مصنع الباليتات ─────────────────────────────────────────
    Public Shared Function CreatePalette(theme As AppTheme) As ThemePalette
        Select Case theme
            Case AppTheme.Dark
                Return New DarkThemePalette()
            Case Else
                Return New LightThemePalette()
        End Select
    End Function

    ' ── تطبيق الثيم على كافة الفورمات المفتوحة حالياً ──────────
    Public Sub ApplyToAllOpenForms()
        Try
            Dim openFormsList As New List(Of Form)()
            For Each frm As Form In Application.OpenForms
                If frm IsNot Nothing AndAlso Not frm.IsDisposed Then
                    openFormsList.Add(frm)
                End If
            Next

            For Each frm In openFormsList
                Try
                    ThemeHelper.ApplyToForm(frm, _currentPalette)
                Catch
                End Try
            Next
        Catch ex As Exception
        End Try
    End Sub

End Class
