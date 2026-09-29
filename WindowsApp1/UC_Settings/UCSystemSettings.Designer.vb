Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCSystemSettings
        Inherits System.Windows.Forms.UserControl

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.cardLanguage = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardLanguageTitle = New System.Windows.Forms.Label()
            Me.lblLanguage = New System.Windows.Forms.Label()
            Me.cmbLanguage = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblCurrency = New System.Windows.Forms.Label()
            Me.cmbCurrency = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblTheme = New System.Windows.Forms.Label()
            Me.btnThemeLight = New Guna.UI2.WinForms.Guna2Button()
            Me.btnThemeDark = New Guna.UI2.WinForms.Guna2Button()
            Me.btnThemeSystem = New Guna.UI2.WinForms.Guna2Button()
            Me.cardBackup = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardBackupTitle = New System.Windows.Forms.Label()
            Me.lblAutoBackup = New System.Windows.Forms.Label()
            Me.tglAutoBackup = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblRunAtStartup = New System.Windows.Forms.Label()
            Me.tglRunAtStartup = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblMaxLoginAttempts = New System.Windows.Forms.Label()
            Me.txtMaxLoginAttempts = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cardAutoLogout = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardAutoLogoutTitle = New System.Windows.Forms.Label()
            Me.lblAutoLogout = New System.Windows.Forms.Label()
            Me.tglAutoLogout = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblAutoLogoutTimer = New System.Windows.Forms.Label()
            Me.btnMinusMinutes = New Guna.UI2.WinForms.Guna2Button()
            Me.txtAutoLogoutMinutes = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnPlusMinutes = New Guna.UI2.WinForms.Guna2Button()
            Me.cardPath = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardPathTitle = New System.Windows.Forms.Label()
            Me.lblBackupPath = New System.Windows.Forms.Label()
            Me.txtBackupPath = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnBrowseBackup = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardLanguage.SuspendLayout()
            Me.cardBackup.SuspendLayout()
            Me.cardAutoLogout.SuspendLayout()
            Me.cardPath.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardLanguage)
            Me.pnlMain.Controls.Add(Me.cardBackup)
            Me.pnlMain.Controls.Add(Me.cardAutoLogout)
            Me.pnlMain.Controls.Add(Me.cardPath)
            Me.pnlMain.Controls.Add(Me.btnSave)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 850)
            Me.pnlMain.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(850, 20)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(358, 35)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "إعدادات النظام"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(750, 58)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(458, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "إدارة الإعدادات العامة والأساسية للنظام"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardLanguage
            '
            Me.cardLanguage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardLanguage.BackColor = System.Drawing.Color.Transparent
            Me.cardLanguage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardLanguage.BorderRadius = 12
            Me.cardLanguage.BorderThickness = 1
            Me.cardLanguage.Controls.Add(Me.lblCardLanguageTitle)
            Me.cardLanguage.Controls.Add(Me.lblLanguage)
            Me.cardLanguage.Controls.Add(Me.cmbLanguage)
            Me.cardLanguage.Controls.Add(Me.lblCurrency)
            Me.cardLanguage.Controls.Add(Me.cmbCurrency)
            Me.cardLanguage.Controls.Add(Me.lblTheme)
            Me.cardLanguage.Controls.Add(Me.btnThemeLight)
            Me.cardLanguage.Controls.Add(Me.btnThemeDark)
            Me.cardLanguage.Controls.Add(Me.btnThemeSystem)
            Me.cardLanguage.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardLanguage.Location = New System.Drawing.Point(30, 95)
            Me.cardLanguage.Name = "cardLanguage"
            Me.cardLanguage.Size = New System.Drawing.Size(1178, 185)
            Me.cardLanguage.TabIndex = 2
            '
            'lblCardLanguageTitle
            '
            Me.lblCardLanguageTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardLanguageTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardLanguageTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardLanguageTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardLanguageTitle.Name = "lblCardLanguageTitle"
            Me.lblCardLanguageTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardLanguageTitle.TabIndex = 0
            Me.lblCardLanguageTitle.Text = "اللغة والمظهر والعملة"
            Me.lblCardLanguageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLanguage
            '
            Me.lblLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblLanguage.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblLanguage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblLanguage.Location = New System.Drawing.Point(990, 65)
            Me.lblLanguage.Name = "lblLanguage"
            Me.lblLanguage.Size = New System.Drawing.Size(160, 32)
            Me.lblLanguage.TabIndex = 1
            Me.lblLanguage.Text = "لغة النظام:"
            Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbLanguage
            '
            Me.cmbLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbLanguage.BackColor = System.Drawing.Color.Transparent
            Me.cmbLanguage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbLanguage.BorderRadius = 8
            Me.cmbLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbLanguage.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbLanguage.FocusedColor = System.Drawing.Color.Empty
            Me.cmbLanguage.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbLanguage.ForeColor = System.Drawing.Color.White
            Me.cmbLanguage.ItemHeight = 34
            Me.cmbLanguage.Items.AddRange(New Object() {"العربية", "English"})
            Me.cmbLanguage.Location = New System.Drawing.Point(710, 60)
            Me.cmbLanguage.Name = "cmbLanguage"
            Me.cmbLanguage.Size = New System.Drawing.Size(270, 40)
            Me.cmbLanguage.StartIndex = 0
            Me.cmbLanguage.TabIndex = 2
            '
            'lblCurrency
            '
            Me.lblCurrency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCurrency.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblCurrency.Location = New System.Drawing.Point(470, 65)
            Me.lblCurrency.Name = "lblCurrency"
            Me.lblCurrency.Size = New System.Drawing.Size(180, 32)
            Me.lblCurrency.TabIndex = 3
            Me.lblCurrency.Text = "العملة المحلية:"
            Me.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCurrency
            '
            Me.cmbCurrency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbCurrency.BackColor = System.Drawing.Color.Transparent
            Me.cmbCurrency.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbCurrency.BorderRadius = 8
            Me.cmbCurrency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCurrency.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbCurrency.FocusedColor = System.Drawing.Color.Empty
            Me.cmbCurrency.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbCurrency.ForeColor = System.Drawing.Color.White
            Me.cmbCurrency.ItemHeight = 34
            Me.cmbCurrency.Items.AddRange(New Object() {"جنيه مصري - ج.م", "ريال سعودي - ر.س", "دولار أمريكي - $", "درهم إماراتي - د.إ"})
            Me.cmbCurrency.Location = New System.Drawing.Point(190, 60)
            Me.cmbCurrency.Name = "cmbCurrency"
            Me.cmbCurrency.Size = New System.Drawing.Size(270, 40)
            Me.cmbCurrency.StartIndex = 0
            Me.cmbCurrency.TabIndex = 4
            '
            'lblTheme
            '
            Me.lblTheme.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTheme.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTheme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblTheme.Location = New System.Drawing.Point(990, 125)
            Me.lblTheme.Name = "lblTheme"
            Me.lblTheme.Size = New System.Drawing.Size(160, 32)
            Me.lblTheme.TabIndex = 5
            Me.lblTheme.Text = "مظهر النظام:"
            Me.lblTheme.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnThemeLight
            '
            Me.btnThemeLight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnThemeLight.BorderRadius = 8
            Me.btnThemeLight.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnThemeLight.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
            Me.btnThemeLight.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnThemeLight.ForeColor = System.Drawing.Color.White
            Me.btnThemeLight.Location = New System.Drawing.Point(760, 118)
            Me.btnThemeLight.Name = "btnThemeLight"
            Me.btnThemeLight.Size = New System.Drawing.Size(220, 44)
            Me.btnThemeLight.TabIndex = 6
            Me.btnThemeLight.Text = "☀️ الوضع الفاتح"
            '
            'btnThemeDark
            '
            Me.btnThemeDark.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnThemeDark.BorderRadius = 8
            Me.btnThemeDark.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnThemeDark.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer))
            Me.btnThemeDark.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnThemeDark.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.btnThemeDark.Location = New System.Drawing.Point(520, 118)
            Me.btnThemeDark.Name = "btnThemeDark"
            Me.btnThemeDark.Size = New System.Drawing.Size(220, 44)
            Me.btnThemeDark.TabIndex = 7
            Me.btnThemeDark.Text = "🌙 الوضع الداكن"
            '
            'btnThemeSystem
            '
            Me.btnThemeSystem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnThemeSystem.BorderRadius = 8
            Me.btnThemeSystem.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnThemeSystem.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer))
            Me.btnThemeSystem.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnThemeSystem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.btnThemeSystem.Location = New System.Drawing.Point(280, 118)
            Me.btnThemeSystem.Name = "btnThemeSystem"
            Me.btnThemeSystem.Size = New System.Drawing.Size(220, 44)
            Me.btnThemeSystem.TabIndex = 8
            Me.btnThemeSystem.Text = "💻 تلقائي (حسب النظام)"
            '
            'cardBackup
            '
            Me.cardBackup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardBackup.BackColor = System.Drawing.Color.Transparent
            Me.cardBackup.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardBackup.BorderRadius = 12
            Me.cardBackup.BorderThickness = 1
            Me.cardBackup.Controls.Add(Me.lblCardBackupTitle)
            Me.cardBackup.Controls.Add(Me.lblAutoBackup)
            Me.cardBackup.Controls.Add(Me.tglAutoBackup)
            Me.cardBackup.Controls.Add(Me.lblRunAtStartup)
            Me.cardBackup.Controls.Add(Me.tglRunAtStartup)
            Me.cardBackup.Controls.Add(Me.lblMaxLoginAttempts)
            Me.cardBackup.Controls.Add(Me.txtMaxLoginAttempts)
            Me.cardBackup.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardBackup.Location = New System.Drawing.Point(30, 305)
            Me.cardBackup.Name = "cardBackup"
            Me.cardBackup.Size = New System.Drawing.Size(1178, 155)
            Me.cardBackup.TabIndex = 3
            '
            'lblCardBackupTitle
            '
            Me.lblCardBackupTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardBackupTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardBackupTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardBackupTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardBackupTitle.Name = "lblCardBackupTitle"
            Me.lblCardBackupTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardBackupTitle.TabIndex = 0
            Me.lblCardBackupTitle.Text = "بدء التشغيل والأمان"
            Me.lblCardBackupTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAutoBackup
            '
            Me.lblAutoBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoBackup.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblAutoBackup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblAutoBackup.Location = New System.Drawing.Point(870, 60)
            Me.lblAutoBackup.Name = "lblAutoBackup"
            Me.lblAutoBackup.Size = New System.Drawing.Size(280, 30)
            Me.lblAutoBackup.TabIndex = 1
            Me.lblAutoBackup.Text = "النسخ الاحتياطي التلقائي اليومي:"
            Me.lblAutoBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglAutoBackup
            '
            Me.tglAutoBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglAutoBackup.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoBackup.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoBackup.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglAutoBackup.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglAutoBackup.Location = New System.Drawing.Point(790, 62)
            Me.tglAutoBackup.Name = "tglAutoBackup"
            Me.tglAutoBackup.Size = New System.Drawing.Size(65, 26)
            Me.tglAutoBackup.TabIndex = 2
            Me.tglAutoBackup.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglAutoBackup.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblRunAtStartup
            '
            Me.lblRunAtStartup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblRunAtStartup.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblRunAtStartup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblRunAtStartup.Location = New System.Drawing.Point(370, 60)
            Me.lblRunAtStartup.Name = "lblRunAtStartup"
            Me.lblRunAtStartup.Size = New System.Drawing.Size(280, 30)
            Me.lblRunAtStartup.TabIndex = 3
            Me.lblRunAtStartup.Text = "التشغيل مع إقلاع النظام:"
            Me.lblRunAtStartup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglRunAtStartup
            '
            Me.tglRunAtStartup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglRunAtStartup.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglRunAtStartup.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglRunAtStartup.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglRunAtStartup.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglRunAtStartup.Location = New System.Drawing.Point(290, 62)
            Me.tglRunAtStartup.Name = "tglRunAtStartup"
            Me.tglRunAtStartup.Size = New System.Drawing.Size(65, 26)
            Me.tglRunAtStartup.TabIndex = 4
            Me.tglRunAtStartup.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglRunAtStartup.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblMaxLoginAttempts
            '
            Me.lblMaxLoginAttempts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblMaxLoginAttempts.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblMaxLoginAttempts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblMaxLoginAttempts.Location = New System.Drawing.Point(870, 105)
            Me.lblMaxLoginAttempts.Name = "lblMaxLoginAttempts"
            Me.lblMaxLoginAttempts.Size = New System.Drawing.Size(280, 30)
            Me.lblMaxLoginAttempts.TabIndex = 5
            Me.lblMaxLoginAttempts.Text = "الحد الأقصى لمحاولات الدخول:"
            Me.lblMaxLoginAttempts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMaxLoginAttempts
            '
            Me.txtMaxLoginAttempts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtMaxLoginAttempts.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtMaxLoginAttempts.BorderRadius = 8
            Me.txtMaxLoginAttempts.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtMaxLoginAttempts.DefaultText = "5"
            Me.txtMaxLoginAttempts.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtMaxLoginAttempts.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtMaxLoginAttempts.ForeColor = System.Drawing.Color.White
            Me.txtMaxLoginAttempts.Location = New System.Drawing.Point(680, 100)
            Me.txtMaxLoginAttempts.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtMaxLoginAttempts.Name = "txtMaxLoginAttempts"
            Me.txtMaxLoginAttempts.PlaceholderText = ""
            Me.txtMaxLoginAttempts.SelectedText = ""
            Me.txtMaxLoginAttempts.Size = New System.Drawing.Size(175, 38)
            Me.txtMaxLoginAttempts.TabIndex = 6
            Me.txtMaxLoginAttempts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'cardAutoLogout
            '
            Me.cardAutoLogout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardAutoLogout.BackColor = System.Drawing.Color.Transparent
            Me.cardAutoLogout.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardAutoLogout.BorderRadius = 12
            Me.cardAutoLogout.BorderThickness = 1
            Me.cardAutoLogout.Controls.Add(Me.lblCardAutoLogoutTitle)
            Me.cardAutoLogout.Controls.Add(Me.lblAutoLogout)
            Me.cardAutoLogout.Controls.Add(Me.tglAutoLogout)
            Me.cardAutoLogout.Controls.Add(Me.lblAutoLogoutTimer)
            Me.cardAutoLogout.Controls.Add(Me.btnMinusMinutes)
            Me.cardAutoLogout.Controls.Add(Me.txtAutoLogoutMinutes)
            Me.cardAutoLogout.Controls.Add(Me.btnPlusMinutes)
            Me.cardAutoLogout.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardAutoLogout.Location = New System.Drawing.Point(30, 480)
            Me.cardAutoLogout.Name = "cardAutoLogout"
            Me.cardAutoLogout.Size = New System.Drawing.Size(1178, 125)
            Me.cardAutoLogout.TabIndex = 4
            '
            'lblCardAutoLogoutTitle
            '
            Me.lblCardAutoLogoutTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardAutoLogoutTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardAutoLogoutTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardAutoLogoutTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardAutoLogoutTitle.Name = "lblCardAutoLogoutTitle"
            Me.lblCardAutoLogoutTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardAutoLogoutTitle.TabIndex = 0
            Me.lblCardAutoLogoutTitle.Text = "القفل التلقائي للجلسة"
            Me.lblCardAutoLogoutTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAutoLogout
            '
            Me.lblAutoLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoLogout.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblAutoLogout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblAutoLogout.Location = New System.Drawing.Point(870, 62)
            Me.lblAutoLogout.Name = "lblAutoLogout"
            Me.lblAutoLogout.Size = New System.Drawing.Size(280, 30)
            Me.lblAutoLogout.TabIndex = 1
            Me.lblAutoLogout.Text = "تفعيل القفل التلقائي عند الخمول:"
            Me.lblAutoLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglAutoLogout
            '
            Me.tglAutoLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglAutoLogout.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoLogout.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoLogout.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglAutoLogout.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglAutoLogout.Location = New System.Drawing.Point(790, 64)
            Me.tglAutoLogout.Name = "tglAutoLogout"
            Me.tglAutoLogout.Size = New System.Drawing.Size(65, 26)
            Me.tglAutoLogout.TabIndex = 2
            Me.tglAutoLogout.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglAutoLogout.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblAutoLogoutTimer
            '
            Me.lblAutoLogoutTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoLogoutTimer.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblAutoLogoutTimer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblAutoLogoutTimer.Location = New System.Drawing.Point(390, 62)
            Me.lblAutoLogoutTimer.Name = "lblAutoLogoutTimer"
            Me.lblAutoLogoutTimer.Size = New System.Drawing.Size(240, 30)
            Me.lblAutoLogoutTimer.TabIndex = 3
            Me.lblAutoLogoutTimer.Text = "المهلة الزمنية (بالدقائق):"
            Me.lblAutoLogoutTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnMinusMinutes
            '
            Me.btnMinusMinutes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnMinusMinutes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnMinusMinutes.BorderRadius = 8
            Me.btnMinusMinutes.BorderThickness = 1
            Me.btnMinusMinutes.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMinusMinutes.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer))
            Me.btnMinusMinutes.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnMinusMinutes.ForeColor = System.Drawing.Color.White
            Me.btnMinusMinutes.Location = New System.Drawing.Point(175, 58)
            Me.btnMinusMinutes.Name = "btnMinusMinutes"
            Me.btnMinusMinutes.Size = New System.Drawing.Size(38, 38)
            Me.btnMinusMinutes.TabIndex = 4
            Me.btnMinusMinutes.Text = "−"
            '
            'txtAutoLogoutMinutes
            '
            Me.txtAutoLogoutMinutes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtAutoLogoutMinutes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtAutoLogoutMinutes.BorderRadius = 8
            Me.txtAutoLogoutMinutes.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtAutoLogoutMinutes.DefaultText = "15"
            Me.txtAutoLogoutMinutes.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtAutoLogoutMinutes.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.txtAutoLogoutMinutes.ForeColor = System.Drawing.Color.White
            Me.txtAutoLogoutMinutes.Location = New System.Drawing.Point(219, 58)
            Me.txtAutoLogoutMinutes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtAutoLogoutMinutes.Name = "txtAutoLogoutMinutes"
            Me.txtAutoLogoutMinutes.PlaceholderText = "15"
            Me.txtAutoLogoutMinutes.SelectedText = ""
            Me.txtAutoLogoutMinutes.Size = New System.Drawing.Size(110, 38)
            Me.txtAutoLogoutMinutes.TabIndex = 5
            Me.txtAutoLogoutMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnPlusMinutes
            '
            Me.btnPlusMinutes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPlusMinutes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnPlusMinutes.BorderRadius = 8
            Me.btnPlusMinutes.BorderThickness = 1
            Me.btnPlusMinutes.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPlusMinutes.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer))
            Me.btnPlusMinutes.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnPlusMinutes.ForeColor = System.Drawing.Color.White
            Me.btnPlusMinutes.Location = New System.Drawing.Point(335, 58)
            Me.btnPlusMinutes.Name = "btnPlusMinutes"
            Me.btnPlusMinutes.Size = New System.Drawing.Size(38, 38)
            Me.btnPlusMinutes.TabIndex = 6
            Me.btnPlusMinutes.Text = "+"
            '
            'cardPath
            '
            Me.cardPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardPath.BackColor = System.Drawing.Color.Transparent
            Me.cardPath.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardPath.BorderRadius = 12
            Me.cardPath.BorderThickness = 1
            Me.cardPath.Controls.Add(Me.lblCardPathTitle)
            Me.cardPath.Controls.Add(Me.lblBackupPath)
            Me.cardPath.Controls.Add(Me.txtBackupPath)
            Me.cardPath.Controls.Add(Me.btnBrowseBackup)
            Me.cardPath.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPath.Location = New System.Drawing.Point(30, 625)
            Me.cardPath.Name = "cardPath"
            Me.cardPath.Size = New System.Drawing.Size(1178, 130)
            Me.cardPath.TabIndex = 5
            '
            'lblCardPathTitle
            '
            Me.lblCardPathTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardPathTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardPathTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardPathTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardPathTitle.Name = "lblCardPathTitle"
            Me.lblCardPathTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardPathTitle.TabIndex = 0
            Me.lblCardPathTitle.Text = "مسار النسخ الاحتياطي"
            Me.lblCardPathTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBackupPath
            '
            Me.lblBackupPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBackupPath.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblBackupPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblBackupPath.Location = New System.Drawing.Point(990, 65)
            Me.lblBackupPath.Name = "lblBackupPath"
            Me.lblBackupPath.Size = New System.Drawing.Size(160, 32)
            Me.lblBackupPath.TabIndex = 1
            Me.lblBackupPath.Text = "مجلد الحفظ:"
            Me.lblBackupPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtBackupPath
            '
            Me.txtBackupPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtBackupPath.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtBackupPath.BorderRadius = 8
            Me.txtBackupPath.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtBackupPath.DefaultText = ""
            Me.txtBackupPath.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtBackupPath.Font = New System.Drawing.Font("Segoe UI", 10.5!)
            Me.txtBackupPath.ForeColor = System.Drawing.Color.White
            Me.txtBackupPath.Location = New System.Drawing.Point(190, 60)
            Me.txtBackupPath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtBackupPath.Name = "txtBackupPath"
            Me.txtBackupPath.PlaceholderText = ""
            Me.txtBackupPath.ReadOnly = True
            Me.txtBackupPath.SelectedText = ""
            Me.txtBackupPath.Size = New System.Drawing.Size(790, 38)
            Me.txtBackupPath.TabIndex = 2
            '
            'btnBrowseBackup
            '
            Me.btnBrowseBackup.BorderRadius = 8
            Me.btnBrowseBackup.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnBrowseBackup.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnBrowseBackup.ForeColor = System.Drawing.Color.White
            Me.btnBrowseBackup.Location = New System.Drawing.Point(30, 60)
            Me.btnBrowseBackup.Name = "btnBrowseBackup"
            Me.btnBrowseBackup.Size = New System.Drawing.Size(145, 38)
            Me.btnBrowseBackup.TabIndex = 3
            Me.btnBrowseBackup.Text = "استعراض..."
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BorderRadius = 10
            Me.btnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(958, 775)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(250, 48)
            Me.btnSave.TabIndex = 6
            Me.btnSave.Text = "💾  حفظ التغييرات"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnReset.BorderRadius = 10
            Me.btnReset.BorderThickness = 1
            Me.btnReset.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnReset.Location = New System.Drawing.Point(740, 775)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(195, 48)
            Me.btnReset.TabIndex = 7
            Me.btnReset.Text = "إلغاء التغييرات"
            '
            'btnClose
            '
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnClose.BorderRadius = 10
            Me.btnClose.BorderThickness = 1
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 775)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(130, 48)
            Me.btnClose.TabIndex = 8
            Me.btnClose.Text = "إغلاق"
            '
            'UCSystemSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCSystemSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 850)
            Me.pnlMain.ResumeLayout(False)
            Me.cardLanguage.ResumeLayout(False)
            Me.cardBackup.ResumeLayout(False)
            Me.cardAutoLogout.ResumeLayout(False)
            Me.cardPath.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardLanguage As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardLanguageTitle As System.Windows.Forms.Label
        Friend WithEvents lblLanguage As System.Windows.Forms.Label
        Friend WithEvents cmbLanguage As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblCurrency As System.Windows.Forms.Label
        Friend WithEvents cmbCurrency As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblTheme As System.Windows.Forms.Label
        Friend WithEvents btnThemeLight As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnThemeDark As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnThemeSystem As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardBackup As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardBackupTitle As System.Windows.Forms.Label
        Friend WithEvents lblAutoBackup As System.Windows.Forms.Label
        Friend WithEvents tglAutoBackup As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblRunAtStartup As System.Windows.Forms.Label
        Friend WithEvents tglRunAtStartup As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblMaxLoginAttempts As System.Windows.Forms.Label
        Friend WithEvents txtMaxLoginAttempts As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents cardAutoLogout As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardAutoLogoutTitle As System.Windows.Forms.Label
        Friend WithEvents lblAutoLogout As System.Windows.Forms.Label
        Friend WithEvents tglAutoLogout As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblAutoLogoutTimer As System.Windows.Forms.Label
        Friend WithEvents btnMinusMinutes As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents txtAutoLogoutMinutes As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnPlusMinutes As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardPath As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardPathTitle As System.Windows.Forms.Label
        Friend WithEvents lblBackupPath As System.Windows.Forms.Label
        Friend WithEvents txtBackupPath As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnBrowseBackup As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
