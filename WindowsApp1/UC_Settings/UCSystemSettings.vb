Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات النظام الأساسية واللغة والنسخ الاحتياطي ومظهر النظام
    ''' </summary>
    Public Class UCSystemSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Private _selectedThemeMode As ThemeMode = ThemeMode.System

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCSystemSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadSettings()
            AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
        End Sub

        Private Sub UCSystemSettings_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
            RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
        End Sub

        Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
            UpdateThemeButtonsUI(_selectedThemeMode)
        End Sub

        Public Sub LoadSettings()
            Try
                ' اللغة والعملة
                Dim lang = SettingsManager.GetSettingOrDefault(SettingsKeys.SystemLanguage, "العربية")
                cmbLanguage.Text = lang

                Dim curr = SettingsManager.GetSettingOrDefault(SettingsKeys.CurrencyName, "جنيه مصري - ج.م")
                If curr = "ج.م (جنيه مصري)" Then curr = "جنيه مصري - ج.م"
                cmbCurrency.Text = curr

                ' النسخ الاحتياطي وبدء التشغيل
                tglAutoBackup.Checked = SettingsManager.GetBoolSetting(SettingsKeys.SystemAutoBackup, False)
                tglRunAtStartup.Checked = StartupManager.IsRunAtStartupEnabled() OrElse SettingsManager.GetBoolSetting(SettingsKeys.SystemRunAtStartup, False)
                txtMaxLoginAttempts.Text = SettingsManager.GetIntSetting(SettingsKeys.LoginMaxAttempts, 5).ToString()

                ' القفل التلقائي
                Dim isAutoLogout = SettingsManager.GetBoolSetting(SettingsKeys.SystemAutoLogoutEnabled, False)
                tglAutoLogout.Checked = isAutoLogout
                Dim logoutMinutes = SettingsManager.GetIntSetting(SettingsKeys.SystemAutoLogoutTimer, 15)
                If logoutMinutes < 1 Then logoutMinutes = 1
                If logoutMinutes > 120 Then logoutMinutes = 120
                txtAutoLogoutMinutes.Text = logoutMinutes.ToString()
                txtAutoLogoutMinutes.Enabled = isAutoLogout
                btnMinusMinutes.Enabled = isAutoLogout
                btnPlusMinutes.Enabled = isAutoLogout
                lblAutoLogoutTimer.Enabled = isAutoLogout

                ' مظهر النظام (تحديث حالة أزرار الوضع الفاتح والداكن والتلقائي)
                _selectedThemeMode = ThemeManager.Instance.CurrentMode
                UpdateThemeButtonsUI(_selectedThemeMode)

                ' مسار النسخ الاحتياطي
                txtBackupPath.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.SystemBackupPath, "")
            Catch ex As Exception
                MessageBox.Show("خطأ في تحميل إعدادات النظام: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnBrowseBackup_Click(sender As Object, e As EventArgs) Handles btnBrowseBackup.Click
            Using fbd As New FolderBrowserDialog()
                fbd.Description = "اختر مجلد حفظ النسخ الاحتياطية"
                If fbd.ShowDialog() = DialogResult.OK Then
                    txtBackupPath.Text = fbd.SelectedPath
                End If
            End Using
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                Dim attempts As Integer
                If Not Integer.TryParse(txtMaxLoginAttempts.Text.Trim(), attempts) OrElse attempts <= 0 Then
                    MessageBox.Show("يرجى إدخال عدد محاولات دخول صحيح (أكبر من 0)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtMaxLoginAttempts.Focus()
                    Return
                End If

                SettingsManager.SaveSetting(SettingsKeys.SystemLanguage, cmbLanguage.Text.Trim())

                Dim curVal = cmbCurrency.Text.Trim()
                Dim symbol = "ج.م"
                If curVal.Contains("ر.س") Then
                    symbol = "ر.س"
                ElseIf curVal.Contains("$") Then
                    symbol = "$"
                ElseIf curVal.Contains("د.إ") Then
                    symbol = "د.إ"
                End If
                SettingsManager.SaveSetting(SettingsKeys.CurrencyName, curVal)
                SettingsManager.SaveSetting(SettingsKeys.Currency, symbol)

                SettingsManager.SaveSetting(SettingsKeys.SystemAutoBackup, tglAutoBackup.Checked.ToString().ToLower())
                
                ' تطبيق بدء التشغيل التلقائي مع الويندوز وحفظه
                Dim runAtStartup = tglRunAtStartup.Checked
                StartupManager.SetRunAtStartup(runAtStartup)
                SettingsManager.SaveSetting(SettingsKeys.SystemRunAtStartup, runAtStartup.ToString().ToLower())
                
                Dim logoutMinutes As Integer
                If Not Integer.TryParse(txtAutoLogoutMinutes.Text.Trim(), logoutMinutes) OrElse logoutMinutes < 1 OrElse logoutMinutes > 120 Then
                    MessageBox.Show("يرجى إدخال مهلة زمنية صحيحة بالدقائق (بين 1 و 120 دقيقة)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAutoLogoutMinutes.Focus()
                    Return
                End If

                SettingsManager.SaveSetting(SettingsKeys.LoginMaxAttempts, attempts.ToString())
                SettingsManager.SaveSetting(SettingsKeys.SystemAutoLogoutEnabled, tglAutoLogout.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.SystemAutoLogoutTimer, logoutMinutes.ToString())
                SettingsManager.SaveSetting(SettingsKeys.SystemBackupPath, txtBackupPath.Text.Trim())

                ' تطبيق إعدادات القفل التلقائي للجلسة فوراً في الخلفية
                WindowsApp1.Services.SessionLockService.Instance.ReloadSettings()

                ' حفظ وتطبيق مظهر النظام الحالي
                ThemeManager.Instance.SetThemeMode(_selectedThemeMode)

                ' إظهار رسالة النجاح
                Try
                    Notify.Toast("تم حفظ إعدادات النظام بنجاح ✅", Notify.ToastType.Success)
                Catch
                    MessageBox.Show("✅ تم حفظ إعدادات النظام بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Catch ex As Exception
                MessageBox.Show("خطأ في حفظ إعدادات النظام: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''' <summary>
        ''' تحديث المظهر المرئي لأزرار الوضع الفاتح والداكن والتلقائي (حسب النظام)
        ''' </summary>
        Private Sub UpdateThemeButtonsUI(mode As ThemeMode)
            Try
                Dim isDark = ThemeManager.Instance.IsDark

                ' إعداد ألوان الحالة غير النشطة بناءً على ثيم التطبيق الحالي
                Dim inactiveFill As Color
                Dim inactiveFore As Color
                Dim inactiveBorder As Color
                Dim inactiveBorderThickness As Integer = 1

                If isDark Then
                    inactiveFill = Color.FromArgb(30, 36, 49)
                    inactiveFore = Color.FromArgb(156, 163, 175)
                    inactiveBorder = Color.FromArgb(75, 85, 99)
                Else
                    inactiveFill = Color.FromArgb(243, 244, 246)
                    inactiveFore = Color.FromArgb(107, 114, 128)
                    inactiveBorder = Color.FromArgb(209, 213, 219)
                End If

                ' ألوان الحالة النشطة
                Dim activeFill = Color.FromArgb(59, 130, 246)
                Dim activeFore = Color.White
                Dim activeBorderThickness = 0

                ' 1. زر الوضع الفاتح
                If mode = ThemeMode.Light Then
                    btnThemeLight.FillColor = activeFill
                    btnThemeLight.ForeColor = activeFore
                    btnThemeLight.BorderThickness = activeBorderThickness
                Else
                    btnThemeLight.FillColor = inactiveFill
                    btnThemeLight.ForeColor = inactiveFore
                    btnThemeLight.BorderColor = inactiveBorder
                    btnThemeLight.BorderThickness = inactiveBorderThickness
                End If

                ' 2. زر الوضع الداكن
                If mode = ThemeMode.Dark Then
                    btnThemeDark.FillColor = activeFill
                    btnThemeDark.ForeColor = activeFore
                    btnThemeDark.BorderThickness = activeBorderThickness
                Else
                    btnThemeDark.FillColor = inactiveFill
                    btnThemeDark.ForeColor = inactiveFore
                    btnThemeDark.BorderColor = inactiveBorder
                    btnThemeDark.BorderThickness = inactiveBorderThickness
                End If

                ' 3. زر الوضع التلقائي حسب النظام
                If mode = ThemeMode.System Then
                    btnThemeSystem.FillColor = activeFill
                    btnThemeSystem.ForeColor = activeFore
                    btnThemeSystem.BorderThickness = activeBorderThickness
                Else
                    btnThemeSystem.FillColor = inactiveFill
                    btnThemeSystem.ForeColor = inactiveFore
                    btnThemeSystem.BorderColor = inactiveBorder
                    btnThemeSystem.BorderThickness = inactiveBorderThickness
                End If
            Catch ex As Exception
                ' حماية أثناء التحديث أو الإغلاق
            End Try
        End Sub

        Private Sub btnThemeLight_Click(sender As Object, e As EventArgs) Handles btnThemeLight.Click
            _selectedThemeMode = ThemeMode.Light
            ThemeManager.Instance.SetThemeMode(ThemeMode.Light)
            UpdateThemeButtonsUI(ThemeMode.Light)
        End Sub

        Private Sub btnThemeDark_Click(sender As Object, e As EventArgs) Handles btnThemeDark.Click
            _selectedThemeMode = ThemeMode.Dark
            ThemeManager.Instance.SetThemeMode(ThemeMode.Dark)
            UpdateThemeButtonsUI(ThemeMode.Dark)
        End Sub

        Private Sub btnThemeSystem_Click(sender As Object, e As EventArgs) Handles btnThemeSystem.Click
            _selectedThemeMode = ThemeMode.System
            ThemeManager.Instance.SetThemeMode(ThemeMode.System)
            UpdateThemeButtonsUI(ThemeMode.System)
        End Sub

        Private Sub tglAutoLogout_CheckedChanged(sender As Object, e As EventArgs) Handles tglAutoLogout.CheckedChanged
            Dim isChecked = tglAutoLogout.Checked
            txtAutoLogoutMinutes.Enabled = isChecked
            btnMinusMinutes.Enabled = isChecked
            btnPlusMinutes.Enabled = isChecked
            lblAutoLogoutTimer.Enabled = isChecked
        End Sub

        Private Sub btnPlusMinutes_Click(sender As Object, e As EventArgs) Handles btnPlusMinutes.Click
            Dim val As Integer
            If Integer.TryParse(txtAutoLogoutMinutes.Text.Trim(), val) Then
                If val < 120 Then txtAutoLogoutMinutes.Text = (val + 1).ToString()
            Else
                txtAutoLogoutMinutes.Text = "15"
            End If
        End Sub

        Private Sub btnMinusMinutes_Click(sender As Object, e As EventArgs) Handles btnMinusMinutes.Click
            Dim val As Integer
            If Integer.TryParse(txtAutoLogoutMinutes.Text.Trim(), val) Then
                If val > 1 Then txtAutoLogoutMinutes.Text = (val - 1).ToString()
            Else
                txtAutoLogoutMinutes.Text = "15"
            End If
        End Sub

        Private Sub txtAutoLogoutMinutes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAutoLogoutMinutes.KeyPress
            ' السماح بالأرقام فقط وزر المسح (Backspace)
            If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If MessageBox.Show("هل أنت متأكد من استعادة القيم الافتراضية لإعدادات النظام؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                cmbLanguage.SelectedIndex = 0
                cmbCurrency.SelectedIndex = 0
                tglAutoBackup.Checked = False
                tglRunAtStartup.Checked = False
                txtMaxLoginAttempts.Text = "5"
                tglAutoLogout.Checked = False
                txtAutoLogoutMinutes.Text = "15"
                txtAutoLogoutMinutes.Enabled = False
                btnMinusMinutes.Enabled = False
                btnPlusMinutes.Enabled = False
                lblAutoLogoutTimer.Enabled = False
                txtBackupPath.Clear()

                ' إعادة الوضع إلى التلقائي الافتراضي
                _selectedThemeMode = ThemeMode.System
                ThemeManager.Instance.SetThemeMode(ThemeMode.System)
                UpdateThemeButtonsUI(ThemeMode.System)

                ' تحديث خدمة القفل التلقائي
                WindowsApp1.Services.SessionLockService.Instance.ReloadSettings()
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
