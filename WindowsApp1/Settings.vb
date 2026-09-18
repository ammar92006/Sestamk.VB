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
                                                           For Each uc In controlsCache.Values
                                                               ThemeManager.Instance.ApplyToControl(uc)
                                                           Next
                                                       End Sub

        LoadButtonIcons()

        ' تحميل الصفحة الافتراضية
        If _selectedSectionIndex = 1 OrElse _selectedSectionIndex = 5 Then
            btnDatabaseSettings.PerformClick()
        Else
            btnSystemSettings.PerformClick()
        End If
    End Sub

    Private Sub btnThemeToggle_Click(sender As Object, e As EventArgs) Handles btnThemeToggle.Click
        ThemeManager.Instance.ToggleTheme()
    End Sub

    Private Sub UpdateThemeToggleButton()
        If ThemeManager.Instance.CurrentTheme = AppTheme.Dark Then
            btnThemeToggle.Text = "☀️ وضع فاتح"
            btnThemeToggle.ForeColor = Color.FromArgb(250, 204, 21)
        Else
            btnThemeToggle.Text = "🌙 وضع داكن"
            btnThemeToggle.ForeColor = Color.FromArgb(71, 85, 105)
        End If
    End Sub

    Private Sub LoadButtonIcons()
        Try
            Dim baseDir = AppDomain.CurrentDomain.BaseDirectory
            Dim candidates = New String() {
                System.IO.Path.Combine(baseDir, "Resources"),
                System.IO.Path.Combine(baseDir, "..", "..", "Resources"),
                System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, "Resources"))
            }

            Dim resDir As String = Nothing
            For Each candidate In candidates
                If System.IO.Directory.Exists(candidate) Then
                    resDir = candidate
                    Exit For
                End If
            Next

            If Not String.IsNullOrEmpty(resDir) Then
                SetButtonIcon(btnSystemSettings, resDir, "settings__3_.png")
                SetButtonIcon(btnSalesSettings, resDir, "discount__1_.png")
                SetButtonIcon(btnPrinterSettings, resDir, "print.png")
                SetButtonIcon(btnScannerSettings, resDir, "barcode.png")
                SetButtonIcon(btnReceiptSettings, resDir, "invoice.png")
                SetButtonIcon(btnDatabaseSettings, resDir, "database.png")
                SetButtonIcon(btnNotificationsSettings, resDir, "notification.png")
                SetButtonIcon(btnAbout, resDir, "information1.png")
            End If
        Catch ex As Exception
            Debug.WriteLine("LoadButtonIcons error: " & ex.Message)
        End Try
    End Sub

    Private Sub SetButtonIcon(btn As Guna2Button, dir As String, filename As String)
        Try
            Dim path = System.IO.Path.Combine(dir, filename)
            If System.IO.File.Exists(path) Then
                Using fs As New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    Using img As Image = Image.FromStream(fs)
                        btn.Image = New Bitmap(img)
                        btn.ImageSize = New Size(26, 26)
                        btn.ImageAlign = HorizontalAlignment.Left
                    End Using
                End Using
            End If
        Catch
        End Try
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
            btnNotificationsSettings,
            btnAbout
        }

        For Each btn In buttons
            btn.Checked = (btn Is activeBtn)
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

    Private Sub btnNotificationsSettings_Click(sender As Object, e As EventArgs) Handles btnNotificationsSettings.Click
        SetActiveButton(btnNotificationsSettings)
        _selectedSectionIndex = 6
        LoadUserControl("NotificationsSettings", Function() New UCNotificationsSettings())
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        SetActiveButton(btnAbout)
        _selectedSectionIndex = 7
        LoadUserControl("About", Function() New UCAbout())
    End Sub

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