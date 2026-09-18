Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCDatabaseSettings
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
            Me.cardServer = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardServerTitle = New System.Windows.Forms.Label()
            Me.lblDbServer = New System.Windows.Forms.Label()
            Me.txtDbServer = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.btnDetectServers = New Guna.UI2.WinForms.Guna2Button()
            Me.lblDbName = New System.Windows.Forms.Label()
            Me.txtDbName = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cardAuth = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardAuthTitle = New System.Windows.Forms.Label()
            Me.chkWindowsAuth = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.lblDbUser = New System.Windows.Forms.Label()
            Me.txtDbUser = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblDbPassword = New System.Windows.Forms.Label()
            Me.txtDbPassword = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cardStatus = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardStatusTitle = New System.Windows.Forms.Label()
            Me.btnTestDbConnection = New Guna.UI2.WinForms.Guna2Button()
            Me.lblDbStatus = New System.Windows.Forms.Label()
            Me.btnSaveDbSettings = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardServer.SuspendLayout()
            Me.cardAuth.SuspendLayout()
            Me.cardStatus.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardServer)
            Me.pnlMain.Controls.Add(Me.cardAuth)
            Me.pnlMain.Controls.Add(Me.cardStatus)
            Me.pnlMain.Controls.Add(Me.btnSaveDbSettings)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 720)
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
            Me.lblTitle.Text = "إعدادات قاعدة البيانات"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(600, 58)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(608, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "تكوين خادم SQL Server، اختبار الاتصال، والاكتشاف التلقائي للخوادم المتاحة"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardServer
            '
            Me.cardServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardServer.BackColor = System.Drawing.Color.Transparent
            Me.cardServer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardServer.BorderRadius = 12
            Me.cardServer.BorderThickness = 1
            Me.cardServer.Controls.Add(Me.lblCardServerTitle)
            Me.cardServer.Controls.Add(Me.lblDbServer)
            Me.cardServer.Controls.Add(Me.txtDbServer)
            Me.cardServer.Controls.Add(Me.btnDetectServers)
            Me.cardServer.Controls.Add(Me.lblDbName)
            Me.cardServer.Controls.Add(Me.txtDbName)
            Me.cardServer.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardServer.Location = New System.Drawing.Point(30, 95)
            Me.cardServer.Name = "cardServer"
            Me.cardServer.Size = New System.Drawing.Size(1178, 165)
            Me.cardServer.TabIndex = 2
            '
            'lblCardServerTitle
            '
            Me.lblCardServerTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardServerTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardServerTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardServerTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardServerTitle.Name = "lblCardServerTitle"
            Me.lblCardServerTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardServerTitle.TabIndex = 0
            Me.lblCardServerTitle.Text = "🗄️ خادم وقاعدة البيانات"
            Me.lblCardServerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDbServer
            '
            Me.lblDbServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbServer.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDbServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDbServer.Location = New System.Drawing.Point(970, 56)
            Me.lblDbServer.Name = "lblDbServer"
            Me.lblDbServer.Size = New System.Drawing.Size(180, 32)
            Me.lblDbServer.TabIndex = 1
            Me.lblDbServer.Text = "اسم خادم SQL (Server):"
            Me.lblDbServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDbServer
            '
            Me.txtDbServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDbServer.BackColor = System.Drawing.Color.Transparent
            Me.txtDbServer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtDbServer.BorderRadius = 8
            Me.txtDbServer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.txtDbServer.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDbServer.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDbServer.ForeColor = System.Drawing.Color.White
            Me.txtDbServer.ItemHeight = 32
            Me.txtDbServer.Location = New System.Drawing.Point(440, 52)
            Me.txtDbServer.Name = "txtDbServer"
            Me.txtDbServer.Size = New System.Drawing.Size(525, 38)
            Me.txtDbServer.TabIndex = 2
            '
            'btnDetectServers
            '
            Me.btnDetectServers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDetectServers.BorderRadius = 8
            Me.btnDetectServers.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnDetectServers.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnDetectServers.ForeColor = System.Drawing.Color.White
            Me.btnDetectServers.Location = New System.Drawing.Point(280, 52)
            Me.btnDetectServers.Name = "btnDetectServers"
            Me.btnDetectServers.Size = New System.Drawing.Size(145, 38)
            Me.btnDetectServers.TabIndex = 3
            Me.btnDetectServers.Text = "🔍 اكتشاف تلقائي"
            '
            'lblDbName
            '
            Me.lblDbName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbName.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDbName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDbName.Location = New System.Drawing.Point(970, 108)
            Me.lblDbName.Name = "lblDbName"
            Me.lblDbName.Size = New System.Drawing.Size(180, 32)
            Me.lblDbName.TabIndex = 4
            Me.lblDbName.Text = "اسم قاعدة البيانات:"
            Me.lblDbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDbName
            '
            Me.txtDbName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDbName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtDbName.BorderRadius = 8
            Me.txtDbName.DefaultText = "SestamkDB"
            Me.txtDbName.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDbName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDbName.ForeColor = System.Drawing.Color.White
            Me.txtDbName.Location = New System.Drawing.Point(280, 104)
            Me.txtDbName.Name = "txtDbName"
            Me.txtDbName.Size = New System.Drawing.Size(685, 38)
            Me.txtDbName.TabIndex = 5
            '
            'cardAuth
            '
            Me.cardAuth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardAuth.BackColor = System.Drawing.Color.Transparent
            Me.cardAuth.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardAuth.BorderRadius = 12
            Me.cardAuth.BorderThickness = 1
            Me.cardAuth.Controls.Add(Me.lblCardAuthTitle)
            Me.cardAuth.Controls.Add(Me.chkWindowsAuth)
            Me.cardAuth.Controls.Add(Me.lblDbUser)
            Me.cardAuth.Controls.Add(Me.txtDbUser)
            Me.cardAuth.Controls.Add(Me.lblDbPassword)
            Me.cardAuth.Controls.Add(Me.txtDbPassword)
            Me.cardAuth.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardAuth.Location = New System.Drawing.Point(30, 275)
            Me.cardAuth.Name = "cardAuth"
            Me.cardAuth.Size = New System.Drawing.Size(1178, 165)
            Me.cardAuth.TabIndex = 3
            '
            'lblCardAuthTitle
            '
            Me.lblCardAuthTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardAuthTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardAuthTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardAuthTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardAuthTitle.Name = "lblCardAuthTitle"
            Me.lblCardAuthTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardAuthTitle.TabIndex = 0
            Me.lblCardAuthTitle.Text = "🔐 مصادقة الدخول والتحقق"
            Me.lblCardAuthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkWindowsAuth
            '
            Me.chkWindowsAuth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkWindowsAuth.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkWindowsAuth.CheckedState.BorderRadius = 4
            Me.chkWindowsAuth.CheckedState.BorderThickness = 0
            Me.chkWindowsAuth.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkWindowsAuth.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkWindowsAuth.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkWindowsAuth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkWindowsAuth.Location = New System.Drawing.Point(680, 55)
            Me.chkWindowsAuth.Name = "chkWindowsAuth"
            Me.chkWindowsAuth.Size = New System.Drawing.Size(470, 30)
            Me.chkWindowsAuth.TabIndex = 1
            Me.chkWindowsAuth.Text = "استخدام مصادقة ويندوز التلقائية (Windows Authentication)"
            Me.chkWindowsAuth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkWindowsAuth.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkWindowsAuth.UncheckedState.BorderRadius = 4
            Me.chkWindowsAuth.UncheckedState.BorderThickness = 1
            Me.chkWindowsAuth.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            '
            'lblDbUser
            '
            Me.lblDbUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbUser.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDbUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDbUser.Location = New System.Drawing.Point(970, 108)
            Me.lblDbUser.Name = "lblDbUser"
            Me.lblDbUser.Size = New System.Drawing.Size(180, 32)
            Me.lblDbUser.TabIndex = 2
            Me.lblDbUser.Text = "اسم المستخدم (User):"
            Me.lblDbUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDbUser
            '
            Me.txtDbUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDbUser.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtDbUser.BorderRadius = 8
            Me.txtDbUser.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDbUser.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDbUser.ForeColor = System.Drawing.Color.White
            Me.txtDbUser.Location = New System.Drawing.Point(620, 104)
            Me.txtDbUser.Name = "txtDbUser"
            Me.txtDbUser.Size = New System.Drawing.Size(345, 38)
            Me.txtDbUser.TabIndex = 3
            '
            'lblDbPassword
            '
            Me.lblDbPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDbPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDbPassword.Location = New System.Drawing.Point(440, 108)
            Me.lblDbPassword.Name = "lblDbPassword"
            Me.lblDbPassword.Size = New System.Drawing.Size(160, 32)
            Me.lblDbPassword.TabIndex = 4
            Me.lblDbPassword.Text = "كلمة المرور (Password):"
            Me.lblDbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDbPassword
            '
            Me.txtDbPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDbPassword.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtDbPassword.BorderRadius = 8
            Me.txtDbPassword.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDbPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDbPassword.ForeColor = System.Drawing.Color.White
            Me.txtDbPassword.Location = New System.Drawing.Point(30, 104)
            Me.txtDbPassword.Name = "txtDbPassword"
            Me.txtDbPassword.Size = New System.Drawing.Size(400, 38)
            Me.txtDbPassword.TabIndex = 5
            Me.txtDbPassword.UseSystemPasswordChar = True
            '
            'cardStatus
            '
            Me.cardStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardStatus.BackColor = System.Drawing.Color.Transparent
            Me.cardStatus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardStatus.BorderRadius = 12
            Me.cardStatus.BorderThickness = 1
            Me.cardStatus.Controls.Add(Me.lblCardStatusTitle)
            Me.cardStatus.Controls.Add(Me.btnTestDbConnection)
            Me.cardStatus.Controls.Add(Me.lblDbStatus)
            Me.cardStatus.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardStatus.Location = New System.Drawing.Point(30, 455)
            Me.cardStatus.Name = "cardStatus"
            Me.cardStatus.Size = New System.Drawing.Size(1178, 120)
            Me.cardStatus.TabIndex = 4
            '
            'lblCardStatusTitle
            '
            Me.lblCardStatusTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardStatusTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardStatusTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardStatusTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardStatusTitle.Name = "lblCardStatusTitle"
            Me.lblCardStatusTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardStatusTitle.TabIndex = 0
            Me.lblCardStatusTitle.Text = "📡 حالة التحقق من الاتصال"
            Me.lblCardStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnTestDbConnection
            '
            Me.btnTestDbConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnTestDbConnection.BorderRadius = 8
            Me.btnTestDbConnection.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnTestDbConnection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnTestDbConnection.ForeColor = System.Drawing.Color.White
            Me.btnTestDbConnection.Location = New System.Drawing.Point(990, 55)
            Me.btnTestDbConnection.Name = "btnTestDbConnection"
            Me.btnTestDbConnection.Size = New System.Drawing.Size(160, 42)
            Me.btnTestDbConnection.TabIndex = 1
            Me.btnTestDbConnection.Text = "🔌 اختبار الاتصال"
            '
            'lblDbStatus
            '
            Me.lblDbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbStatus.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDbStatus.ForeColor = System.Drawing.Color.Gainsboro
            Me.lblDbStatus.Location = New System.Drawing.Point(30, 58)
            Me.lblDbStatus.Name = "lblDbStatus"
            Me.lblDbStatus.Size = New System.Drawing.Size(940, 36)
            Me.lblDbStatus.TabIndex = 2
            Me.lblDbStatus.Text = "اضغط «اختبار الاتصال» للتحقق من بيانات السيرفر وقاعدة البيانات"
            Me.lblDbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSaveDbSettings
            '
            Me.btnSaveDbSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSaveDbSettings.BorderRadius = 8
            Me.btnSaveDbSettings.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSaveDbSettings.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnSaveDbSettings.ForeColor = System.Drawing.Color.White
            Me.btnSaveDbSettings.Location = New System.Drawing.Point(958, 600)
            Me.btnSaveDbSettings.Name = "btnSaveDbSettings"
            Me.btnSaveDbSettings.Size = New System.Drawing.Size(250, 48)
            Me.btnSaveDbSettings.TabIndex = 5
            Me.btnSaveDbSettings.Text = "💾 حفظ إعدادات قاعدة البيانات"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnReset.BorderRadius = 8
            Me.btnReset.BorderThickness = 1
            Me.btnReset.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnReset.Location = New System.Drawing.Point(720, 600)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(220, 48)
            Me.btnReset.TabIndex = 6
            Me.btnReset.Text = "🔄 استعادة المحفوظ"
            '
            'btnClose
            '
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnClose.BorderRadius = 8
            Me.btnClose.BorderThickness = 1
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 600)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 48)
            Me.btnClose.TabIndex = 7
            Me.btnClose.Text = "❌ إغلاق"
            '
            'UCDatabaseSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCDatabaseSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 700)
            Me.pnlMain.ResumeLayout(False)
            Me.cardServer.ResumeLayout(False)
            Me.cardAuth.ResumeLayout(False)
            Me.cardAuth.PerformLayout()
            Me.cardStatus.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardServer As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardServerTitle As System.Windows.Forms.Label
        Friend WithEvents lblDbServer As System.Windows.Forms.Label
        Friend WithEvents txtDbServer As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnDetectServers As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblDbName As System.Windows.Forms.Label
        Friend WithEvents txtDbName As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents cardAuth As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardAuthTitle As System.Windows.Forms.Label
        Friend WithEvents chkWindowsAuth As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents lblDbUser As System.Windows.Forms.Label
        Friend WithEvents txtDbUser As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblDbPassword As System.Windows.Forms.Label
        Friend WithEvents txtDbPassword As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents cardStatus As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardStatusTitle As System.Windows.Forms.Label
        Friend WithEvents btnTestDbConnection As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblDbStatus As System.Windows.Forms.Label
        Friend WithEvents btnSaveDbSettings As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
