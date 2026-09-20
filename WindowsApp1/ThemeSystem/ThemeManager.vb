Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms

''' <summary>
''' المدير المركزي لنظام الثيمات (Theme Manager) — نمط Singleton.
''' مسؤول عن: إدارة الباليتة الحالية، التبديل بين الثيمات، الحفظ والاسترجاع الفوري،
''' وتطبيق الثيم على كافة الشاشات المفتوحة.
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
    Private _currentTheme As AppTheme = AppTheme.Light
    Private _currentPalette As ThemePalette = New LightThemePalette()
    Private _initialized As Boolean = False

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

    ' ── تغيير الثيم ────────────────────────────────────────────
    Public Sub SetTheme(theme As AppTheme)
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

        _currentTheme = theme
        _currentPalette = CreatePalette(theme)

        SaveTheme()

        RaiseEvent ThemeChanged(Me, _currentTheme, _currentPalette)
        ApplyToAllOpenForms()
    End Sub

    ''' <summary>التبديل الفوري بين Light و Dark.</summary>
    Public Sub ToggleTheme()
        If _currentTheme = AppTheme.Light Then
            SetTheme(AppTheme.Dark)
        Else
            SetTheme(AppTheme.Light)
        End If
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
            Return Path.Combine(Application.StartupPath, "theme.cfg")
        Catch
            Return ""
        End Try
    End Function

    Private Sub SaveTheme()
        ' 1. حفظ فوري في ملف محلي خفيف جداً لضمان القراءة الصامتة الفورية عند الإقلاع
        Try
            Dim cfgPath = GetLocalConfigPath()
            If Not String.IsNullOrEmpty(cfgPath) Then
                File.WriteAllText(cfgPath, _currentTheme.ToString())
            End If
        Catch ex As Exception
        End Try

        ' 2. مزامنة قاعدة البيانات في خلفية غير حاجبة
        Task.Run(Sub()
                     Try
                         SettingsManager.SaveSetting(SettingsKeys.AppTheme, _currentTheme.ToString())
                     Catch
                     End Try
                 End Sub)
    End Sub

    Private Sub LoadTheme()
        Dim loadedTheme As String = ""

        ' 1. قراءة سريعة من الملف المحلي
        Try
            Dim cfgPath = GetLocalConfigPath()
            If Not String.IsNullOrEmpty(cfgPath) AndAlso File.Exists(cfgPath) Then
                loadedTheme = File.ReadAllText(cfgPath).Trim()
            End If
        Catch
        End Try

        ' 2. إذا لم يوجد الملف المحلي، نجرب من إعدادات قاعدة البيانات
        If String.IsNullOrWhiteSpace(loadedTheme) Then
            Try
                loadedTheme = SettingsManager.GetSetting(SettingsKeys.AppTheme)
            Catch
            End Try
        End If

        ' 3. تفسير القيمة
        Dim parsed As AppTheme = AppTheme.Light
        If Not String.IsNullOrWhiteSpace(loadedTheme) Then
            If [Enum].TryParse(Of AppTheme)(loadedTheme, True, parsed) Then
                _currentTheme = parsed
            End If
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
