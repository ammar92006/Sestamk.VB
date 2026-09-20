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
            UpdateThemeButtonsUI(theme)
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
                tglAutoLogout.Checked = SettingsManager.GetBoolSetting(SettingsKeys.SystemAutoLogoutEnabled, False)
                Dim logoutMinutes = SettingsManager.GetIntSetting(SettingsKeys.SystemAutoLogoutTimer, 15)
                If logoutMinutes >= numAutoLogoutMinutes.Minimum AndAlso logoutMinutes <= numAutoLogoutMinutes.Maximum Then
                    numAutoLogoutMinutes.Value = logoutMinutes
                End If

                ' مظهر النظام (تحديث حالة أزرار الوضع الفاتح والداكن)
                UpdateThemeButtonsUI(ThemeManager.Instance.CurrentTheme)

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
                
                SettingsManager.SaveSetting(SettingsKeys.LoginMaxAttempts, attempts.ToString())
                SettingsManager.SaveSetting(SettingsKeys.SystemAutoLogoutEnabled, tglAutoLogout.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.SystemAutoLogoutTimer, CInt(numAutoLogoutMinutes.Value).ToString())
                SettingsManager.SaveSetting(SettingsKeys.SystemBackupPath, txtBackupPath.Text.Trim())

                ' حفظ وتطبيق مظهر النظام الحالي
                Dim selectedTheme = If(tglTheme.Checked, AppTheme.Dark, AppTheme.Light)
                ThemeManager.Instance.SetTheme(selectedTheme)

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
        ''' تحديث المظهر المرئي لأزرار الوضع الفاتح والداكن ومفتاح التبديل
        ''' </summary>
        Private Sub UpdateThemeButtonsUI(theme As AppTheme)
            Try
                RemoveHandler tglTheme.CheckedChanged, AddressOf tglTheme_CheckedChanged

                If theme = AppTheme.Dark Then
                    tglTheme.Checked = True

                    ' زر الوضع الداكن نشط (Active)
                    btnThemeDark.FillColor = Color.FromArgb(59, 130, 246)
                    btnThemeDark.ForeColor = Color.White
                    btnThemeDark.BorderThickness = 0

                    ' زر الوضع الفاتح غير نشط (Inactive)
                    btnThemeLight.FillColor = Color.FromArgb(30, 36, 49)
                    btnThemeLight.ForeColor = Color.FromArgb(156, 163, 175)
                    btnThemeLight.BorderColor = Color.FromArgb(75, 85, 99)
                    btnThemeLight.BorderThickness = 1
                Else
                    tglTheme.Checked = False

                    ' زر الوضع الفاتح نشط (Active)
                    btnThemeLight.FillColor = Color.FromArgb(43, 91, 132)
                    btnThemeLight.ForeColor = Color.White
                    btnThemeLight.BorderThickness = 0

                    ' زر الوضع الداكن غير نشط (Inactive)
                    btnThemeDark.FillColor = Color.FromArgb(243, 244, 246)
                    btnThemeDark.ForeColor = Color.FromArgb(107, 114, 128)
                    btnThemeDark.BorderColor = Color.FromArgb(209, 213, 219)
                    btnThemeDark.BorderThickness = 1
                End If
            Catch ex As Exception
                ' حماية أثناء التحديث أو الإغلاق
            Finally
                AddHandler tglTheme.CheckedChanged, AddressOf tglTheme_CheckedChanged
            End Try
        End Sub

        Private Sub btnThemeLight_Click(sender As Object, e As EventArgs) Handles btnThemeLight.Click
            ThemeManager.Instance.SetTheme(AppTheme.Light)
            UpdateThemeButtonsUI(AppTheme.Light)
        End Sub

        Private Sub btnThemeDark_Click(sender As Object, e As EventArgs) Handles btnThemeDark.Click
            ThemeManager.Instance.SetTheme(AppTheme.Dark)
            UpdateThemeButtonsUI(AppTheme.Dark)
        End Sub

        Private Sub tglTheme_CheckedChanged(sender As Object, e As EventArgs) Handles tglTheme.CheckedChanged
            Dim targetTheme = If(tglTheme.Checked, AppTheme.Dark, AppTheme.Light)
            If ThemeManager.Instance.CurrentTheme <> targetTheme Then
                ThemeManager.Instance.SetTheme(targetTheme)
                UpdateThemeButtonsUI(targetTheme)
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
                numAutoLogoutMinutes.Value = 15
                txtBackupPath.Clear()

                ' إعادة الوضع إلى الفاتح الافتراضي
                ThemeManager.Instance.SetTheme(AppTheme.Light)
                UpdateThemeButtonsUI(AppTheme.Light)
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
