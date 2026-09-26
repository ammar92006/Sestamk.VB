Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Guna.UI2.WinForms
Imports WindowsApp1.UC_Settings

''' <summary>
''' نافذة الإعدادات الرئيسية للنظام المبنية بهيكل الشريط الجانبي الحديث (Sidebar Navigation)
''' وتستضيف عناصر التحكم الفرعية (UserControls) مع التخزين المؤقت (Caching).
''' </summary>
Public Class Settings

    Private ReadOnly controlsCache As New Dictionary(Of String, UserControl)()
    Private _selectedSectionIndex As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)
        UpdateThemeToggleButton()

        AddHandler ThemeManager.Instance.ThemeChanged, Sub(s, theme, palette)
                                                           UpdateThemeToggleButton()
                                                           ThemeManager.Instance.ApplyTheme(Me)
                                                           For Each uc In controlsCache.Values
                                                               ThemeManager.Instance.ApplyToControl(uc)
                                                           Next
                                                           Dim currentActive = GetCurrentActiveButton()
                                                           If currentActive IsNot Nothing Then
                                                               SetActiveButton(currentActive)
                                                           End If
                                                       End Sub

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, pnlTopBar)

        If _databaseSettingsOnly Then
            ApplyDatabaseSettingsOnlyMode()
        End If

        ' تحميل الصفحة الافتراضية
        If _databaseSettingsOnly OrElse _selectedSectionIndex = 1 OrElse _selectedSectionIndex = 5 Then
            btnDatabaseSettings.PerformClick()
        Else
            btnSystemSettings.PerformClick()
        End If
    End Sub

    Private Sub btnThemeToggle_Click(sender As Object, e As EventArgs) Handles btnThemeToggle.Click
        ThemeManager.Instance.ToggleTheme()
    End Sub

    Private Sub UpdateThemeToggleButton()
        Dim isDark = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
        btnThemeToggle.BorderRadius = 16
        btnThemeToggle.BorderThickness = 1

        If isDark Then
            btnThemeToggle.Text = "☀️ وضع فاتح"
            btnThemeToggle.ForeColor = Color.FromArgb(254, 240, 138)
            btnThemeToggle.FillColor = Color.FromArgb(30, 41, 59)
            btnThemeToggle.BorderColor = Color.FromArgb(71, 85, 105)
            btnThemeToggle.HoverState.FillColor = Color.FromArgb(51, 65, 85)
        Else
            btnThemeToggle.Text = "🌙 وضع داكن"
            btnThemeToggle.ForeColor = Color.FromArgb(51, 65, 85)
            btnThemeToggle.FillColor = Color.FromArgb(241, 245, 249)
            btnThemeToggle.BorderColor = Color.FromArgb(203, 213, 225)
            btnThemeToggle.HoverState.FillColor = Color.FromArgb(226, 232, 240)
        End If
    End Sub

    ''' <summary>
    ''' تحميل وعرض UserControl مع التخزين المؤقت لمنع إعادة الإنشاء
    ''' </summary>
    Private Sub LoadUserControl(key As String, createFunc As Func(Of UserControl))
        panelMain.SuspendLayout()
        Try
            If Not controlsCache.ContainsKey(key) Then
                Dim control = createFunc()
                control.Dock = DockStyle.Fill

                ' ربط طلب الإغلاق إذا كان الـ UC يطبق ICloseRequest
                Dim closeable = TryCast(control, ICloseRequest)
                If closeable IsNot Nothing Then
                    AddHandler closeable.CloseRequested, Sub() Me.Close()
                End If

                ThemeManager.Instance.ApplyToControl(control)

                controlsCache(key) = control
                panelMain.Controls.Add(control)
            End If

            ' إخفاء الكل وإظهار النشط
            For Each ctrl As Control In panelMain.Controls
                ctrl.Visible = False
            Next

            Dim activeControl = controlsCache(key)
            activeControl.Visible = True
            activeControl.BringToFront()
        Finally
            panelMain.ResumeLayout(True)
        End Try
    End Sub

    Private Function GetCurrentActiveButton() As Guna2Button
        Select Case _selectedSectionIndex
            Case 0 : Return btnSystemSettings
            Case 1 : Return btnSalesSettings
            Case 2 : Return btnPrinterSettings
            Case 3 : Return btnScannerSettings
            Case 4 : Return btnReceiptSettings
            Case 5 : Return btnDatabaseSettings
            Case 6 : Return btnDataExportSettings
            Case 7 : Return btnNotificationsSettings
            Case 8 : Return btnActivationSettings
            Case 9 : Return btnUpdatesSettings
            Case 10 : Return btnAbout
            Case Else : Return btnSystemSettings
        End Select
    End Function

    ''' <summary>
    ''' ضبط حالة الأزرار الجانبية لتأكيد تمييز الزر النشط فقط
    ''' </summary>
    Private Sub SetActiveButton(activeBtn As Guna2Button)
        Dim buttons = New Guna2Button() {
            btnSystemSettings,
            btnSalesSettings,
            btnPrinterSettings,
            btnScannerSettings,
            btnReceiptSettings,
            btnDatabaseSettings,
            btnDataExportSettings,
            btnNotificationsSettings,
            btnActivationSettings,
            btnUpdatesSettings,
            btnAbout
        }

        Dim palette = ThemeManager.Instance.CurrentPalette
        For Each btn In buttons
            Dim isActive As Boolean = (btn Is activeBtn)
            btn.Checked = isActive
            If isActive Then
                btn.FillColor = palette.NavSelected
                btn.ForeColor = palette.NavSelectedText
            Else
                btn.FillColor = Color.Transparent
                btn.ForeColor = palette.NavText
            End If
        Next
    End Sub

    Private Sub btnSystemSettings_Click(sender As Object, e As EventArgs) Handles btnSystemSettings.Click
        SetActiveButton(btnSystemSettings)
        _selectedSectionIndex = 0
        LoadUserControl("SystemSettings", Function() New UCSystemSettings())
    End Sub

    Private Sub btnSalesSettings_Click(sender As Object, e As EventArgs) Handles btnSalesSettings.Click
        SetActiveButton(btnSalesSettings)
        _selectedSectionIndex = 1
        LoadUserControl("SalesSettings", Function() New UCSalesSettings())
    End Sub

    Private Sub btnPrinterSettings_Click(sender As Object, e As EventArgs) Handles btnPrinterSettings.Click
        SetActiveButton(btnPrinterSettings)
        _selectedSectionIndex = 2
        LoadUserControl("PrinterSettings", Function() New UCPrinterSettings())
    End Sub

    Private Sub btnScannerSettings_Click(sender As Object, e As EventArgs) Handles btnScannerSettings.Click
        SetActiveButton(btnScannerSettings)
        _selectedSectionIndex = 3
        LoadUserControl("ScannerSettings", Function() New UCScannerSettings())
    End Sub

    Private Sub btnReceiptSettings_Click(sender As Object, e As EventArgs) Handles btnReceiptSettings.Click
        SetActiveButton(btnReceiptSettings)
        _selectedSectionIndex = 4
        LoadUserControl("ReceiptSettings", Function() New UCReceiptSettings())
    End Sub

    Private Sub btnDatabaseSettings_Click(sender As Object, e As EventArgs) Handles btnDatabaseSettings.Click
        SetActiveButton(btnDatabaseSettings)
        _selectedSectionIndex = 5
        LoadUserControl("DatabaseSettings", Function() New UCDatabaseSettings())
    End Sub

    Private Sub btnDataExportSettings_Click(sender As Object, e As EventArgs) Handles btnDataExportSettings.Click
        SetActiveButton(btnDataExportSettings)
        _selectedSectionIndex = 6
        LoadUserControl("DataExportSettings", Function() New UCDataExportSettings())
    End Sub

    Private Sub btnNotificationsSettings_Click(sender As Object, e As EventArgs) Handles btnNotificationsSettings.Click
        SetActiveButton(btnNotificationsSettings)
        _selectedSectionIndex = 7
        LoadUserControl("NotificationsSettings", Function() New UCNotificationsSettings())
    End Sub

    Private Sub btnActivationSettings_Click(sender As Object, e As EventArgs) Handles btnActivationSettings.Click
        SetActiveButton(btnActivationSettings)
        _selectedSectionIndex = 8
        LoadUserControl("ActivationSettings", Function() New UCActivationSettings())
    End Sub

    Private Sub btnUpdatesSettings_Click(sender As Object, e As EventArgs) Handles btnUpdatesSettings.Click
        SetActiveButton(btnUpdatesSettings)
        _selectedSectionIndex = 9
        LoadUserControl("UpdatesSettings", Function() New UCUpdatesSettings())
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        SetActiveButton(btnAbout)
        _selectedSectionIndex = 10
        LoadUserControl("About", Function() New UCAbout())
    End Sub

    ' ─────────────────────────────────────────────────────────────
    ' نمط قفل إعدادات قاعدة البيانات (Database Settings Only Mode)
    ' ─────────────────────────────────────────────────────────────

    Private _databaseSettingsOnly As Boolean = False

    ''' <summary>
    ''' تفعيل نمط القفل على إعدادات قاعدة البيانات فقط مع إخفاء باقي أقسام النظام
    ''' لمنع التلاعب بالإعدادات قبل تسجيل الدخول.
    ''' </summary>
    Public Property DatabaseSettingsOnly As Boolean
        Get
            Return _databaseSettingsOnly
        End Get
        Set(value As Boolean)
            _databaseSettingsOnly = value
            If value Then
                ApplyDatabaseSettingsOnlyMode()
            End If
        End Set
    End Property

    ''' <summary>
    ''' تطبيق القفل على قسم قاعدة البيانات وإخفاء الأزرار الأخرى
    ''' </summary>
    Public Sub ApplyDatabaseSettingsOnlyMode()
        Try
            btnSystemSettings.Visible = False
            btnSalesSettings.Visible = False
            btnPrinterSettings.Visible = False
            btnScannerSettings.Visible = False
            btnReceiptSettings.Visible = False
            btnDataExportSettings.Visible = False
            btnNotificationsSettings.Visible = False
            btnActivationSettings.Visible = False
            btnUpdatesSettings.Visible = False
            btnAbout.Visible = True

            lblSettingsTitle.Text = "إعدادات قاعدة البيانات"
            lblSettingsSubtitle.Text = "تهيئة وضبط اتصال الخادم وقاعدة البيانات"

            _selectedSectionIndex = 5
            If IsHandleCreated Then
                btnDatabaseSettings.PerformClick()
            End If
        Catch ex As Exception
            Debug.WriteLine("ApplyDatabaseSettingsOnlyMode error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' دالة مساعدة ثابتة لفتح فورم الإعدادات موجهاً ومقفولاً على قسم قاعدة البيانات
    ''' </summary>
    Public Shared Function OpenDatabaseSettings(Optional owner As Form = Nothing, Optional databaseOnly As Boolean = True) As DialogResult
        Using frm As New Settings()
            frm.DatabaseSettingsOnly = databaseOnly
            frm.SelectedSectionIndex = 5
            AddHandler frm.Shown, Sub(s, ev)
                                      If databaseOnly Then frm.ApplyDatabaseSettingsOnlyMode()
                                      frm.btnDatabaseSettings.PerformClick()
                                  End Sub
            If owner IsNot Nothing Then
                Return frm.ShowDialog(owner)
            Else
                Return frm.ShowDialog()
            End If
        End Using
    End Function

    ' ─────────────────────────────────────────────────────────────
    ' التوافق مع الكود الخارجي (مثل ApplicationEvents.vb)
    ' ─────────────────────────────────────────────────────────────

    Public Property SelectedSectionIndex As Integer
        Get
            Return _selectedSectionIndex
        End Get
        Set(value As Integer)
            _selectedSectionIndex = value
            Select Case value
                Case 1, 5
                    If IsHandleCreated Then
                        btnDatabaseSettings.PerformClick()
                    End If
                Case Else
                    If IsHandleCreated Then
                        btnSystemSettings.PerformClick()
                    End If
            End Select
        End Set
    End Property

    ''' <summary>
    ''' خاصية توافقية لكي يعمل كود ApplicationEvents.vb القديم
    ''' settingsForm.public_set.SelectedIndex = 1
    ''' بدون أي خطأ أو تعديل إلزامي خارجي.
    ''' </summary>
    Public ReadOnly Property public_set As SettingsTabShim
        Get
            Return New SettingsTabShim(Me)
        End Get
    End Property

    Public Class SettingsTabShim
        Private ReadOnly _form As Settings

        Public Sub New(form As Settings)
            _form = form
        End Sub

        Public Property SelectedIndex As Integer
            Get
                Return _form.SelectedSectionIndex
            End Get
            Set(value As Integer)
                _form.SelectedSectionIndex = value
            End Set
        End Property
    End Class

End Class