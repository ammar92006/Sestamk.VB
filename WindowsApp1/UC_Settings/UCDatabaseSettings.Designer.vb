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
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.cardEngine = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardEngineTitle = New System.Windows.Forms.Label()
            Me.btnSelectLocalDb = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSelectServer = New Guna.UI2.WinForms.Guna2Button()
            Me.cardLocalDb = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardLocalDbTitle = New System.Windows.Forms.Label()
            Me.btnInitLocalDatabase = New Guna.UI2.WinForms.Guna2Button()
            Me.lblLocalDbStatusText = New System.Windows.Forms.Label()
            Me.btnStartLocalDb = New Guna.UI2.WinForms.Guna2Button()
            Me.btnStopLocalDb = New Guna.UI2.WinForms.Guna2Button()
            Me.btnCheckLocalDb = New Guna.UI2.WinForms.Guna2Button()
            Me.btnInstallLocalDb = New Guna.UI2.WinForms.Guna2Button()
            Me.chkAttachDb = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.txtAttachDbPath = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnBrowseMdf = New Guna.UI2.WinForms.Guna2Button()
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
            Me.cardMaintenance = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardMaintenanceTitle = New System.Windows.Forms.Label()
            Me.lblCardMaintenanceSubtitle = New System.Windows.Forms.Label()
            Me.btnRunMaintenance = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClearLog = New Guna.UI2.WinForms.Guna2Button()
            Me.prgMaintenance = New Guna.UI2.WinForms.Guna2ProgressBar()
            Me.lblMaintenanceProgress = New System.Windows.Forms.Label()
            Me.txtMaintenanceLog = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cardReset = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardResetTitle = New System.Windows.Forms.Label()
            Me.lblCardResetSubtitle = New System.Windows.Forms.Label()
            Me.btnResetTransactional = New Guna.UI2.WinForms.Guna2Button()
            Me.btnRefreshStats = New Guna.UI2.WinForms.Guna2Button()
            Me.dgvTables = New Guna.UI2.WinForms.Guna2DataGridView()
            Me.colTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDisplayName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRecordCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colResetAction = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.btnSaveDbSettings = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardEngine.SuspendLayout()
            Me.cardLocalDb.SuspendLayout()
            Me.cardServer.SuspendLayout()
            Me.cardAuth.SuspendLayout()
            Me.cardStatus.SuspendLayout()
            Me.cardMaintenance.SuspendLayout()
            Me.cardReset.SuspendLayout()
            CType(Me.dgvTables, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardEngine)
            Me.pnlMain.Controls.Add(Me.cardLocalDb)
            Me.pnlMain.Controls.Add(Me.cardServer)
            Me.pnlMain.Controls.Add(Me.cardAuth)
            Me.pnlMain.Controls.Add(Me.cardStatus)
            Me.pnlMain.Controls.Add(Me.cardMaintenance)
            Me.pnlMain.Controls.Add(Me.cardReset)
            Me.pnlMain.Controls.Add(Me.btnSaveDbSettings)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 700)
            Me.pnlMain.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(833, 20)
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
            Me.lblSubtitle.Location = New System.Drawing.Point(483, 58)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(708, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "تكوين خادم SQL Server أو LocalDB الخفيف، الفحص والترقيع الذاتي، وتهيئة الجداول"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardEngine
            '
            Me.cardEngine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardEngine.BackColor = System.Drawing.Color.Transparent
            Me.cardEngine.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardEngine.BorderRadius = 12
            Me.cardEngine.BorderThickness = 1
            Me.cardEngine.Controls.Add(Me.lblCardEngineTitle)
            Me.cardEngine.Controls.Add(Me.btnSelectLocalDb)
            Me.cardEngine.Controls.Add(Me.btnSelectServer)
            Me.cardEngine.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardEngine.Location = New System.Drawing.Point(30, 95)
            Me.cardEngine.Name = "cardEngine"
            Me.cardEngine.Size = New System.Drawing.Size(1144, 85)
            Me.cardEngine.TabIndex = 2
            '
            'lblCardEngineTitle
            '
            Me.lblCardEngineTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardEngineTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardEngineTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardEngineTitle.Location = New System.Drawing.Point(886, 26)
            Me.lblCardEngineTitle.Name = "lblCardEngineTitle"
            Me.lblCardEngineTitle.Size = New System.Drawing.Size(230, 28)
            Me.lblCardEngineTitle.TabIndex = 0
            Me.lblCardEngineTitle.Text = "نمط التشغيل:"
            Me.lblCardEngineTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSelectLocalDb
            '
            Me.btnSelectLocalDb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSelectLocalDb.BorderRadius = 8
            Me.btnSelectLocalDb.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.btnSelectLocalDb.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnSelectLocalDb.ForeColor = System.Drawing.Color.White
            Me.btnSelectLocalDb.Location = New System.Drawing.Point(506, 20)
            Me.btnSelectLocalDb.Name = "btnSelectLocalDb"
            Me.btnSelectLocalDb.Size = New System.Drawing.Size(360, 44)
            Me.btnSelectLocalDb.TabIndex = 1
            Me.btnSelectLocalDb.Text = "SQL Server LocalDB"
            '
            'btnSelectServer
            '
            Me.btnSelectServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSelectServer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnSelectServer.BorderRadius = 8
            Me.btnSelectServer.BorderThickness = 1
            Me.btnSelectServer.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnSelectServer.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnSelectServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnSelectServer.Location = New System.Drawing.Point(146, 20)
            Me.btnSelectServer.Name = "btnSelectServer"
            Me.btnSelectServer.Size = New System.Drawing.Size(340, 44)
            Me.btnSelectServer.TabIndex = 2
            Me.btnSelectServer.Text = "SQL Server Network"
            '
            'cardLocalDb
            '
            Me.cardLocalDb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardLocalDb.BackColor = System.Drawing.Color.Transparent
            Me.cardLocalDb.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardLocalDb.BorderRadius = 12
            Me.cardLocalDb.BorderThickness = 1
            Me.cardLocalDb.Controls.Add(Me.lblCardLocalDbTitle)
            Me.cardLocalDb.Controls.Add(Me.btnInitLocalDatabase)
            Me.cardLocalDb.Controls.Add(Me.lblLocalDbStatusText)
            Me.cardLocalDb.Controls.Add(Me.btnStartLocalDb)
            Me.cardLocalDb.Controls.Add(Me.btnStopLocalDb)
            Me.cardLocalDb.Controls.Add(Me.btnCheckLocalDb)
            Me.cardLocalDb.Controls.Add(Me.btnInstallLocalDb)
            Me.cardLocalDb.Controls.Add(Me.chkAttachDb)
            Me.cardLocalDb.Controls.Add(Me.txtAttachDbPath)
            Me.cardLocalDb.Controls.Add(Me.btnBrowseMdf)
            Me.cardLocalDb.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardLocalDb.Location = New System.Drawing.Point(30, 195)
            Me.cardLocalDb.Name = "cardLocalDb"
            Me.cardLocalDb.Size = New System.Drawing.Size(1144, 175)
            Me.cardLocalDb.TabIndex = 3
            '
            'lblCardLocalDbTitle
            '
            Me.lblCardLocalDbTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardLocalDbTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardLocalDbTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardLocalDbTitle.Location = New System.Drawing.Point(816, 15)
            Me.lblCardLocalDbTitle.Name = "lblCardLocalDbTitle"
            Me.lblCardLocalDbTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardLocalDbTitle.TabIndex = 0
            Me.lblCardLocalDbTitle.Text = "إدارة محرك LocalDB الداخلي"
            Me.lblCardLocalDbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnInitLocalDatabase
            '
            Me.btnInitLocalDatabase.BorderRadius = 8
            Me.btnInitLocalDatabase.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.btnInitLocalDatabase.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnInitLocalDatabase.ForeColor = System.Drawing.Color.White
            Me.btnInitLocalDatabase.Location = New System.Drawing.Point(20, 10)
            Me.btnInitLocalDatabase.Name = "btnInitLocalDatabase"
            Me.btnInitLocalDatabase.Size = New System.Drawing.Size(340, 34)
            Me.btnInitLocalDatabase.TabIndex = 1
            Me.btnInitLocalDatabase.Text = "تثبيت وتهيئة قاعدة بيانات LocalDB"
            '
            'lblLocalDbStatusText
            '
            Me.lblLocalDbStatusText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblLocalDbStatusText.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblLocalDbStatusText.ForeColor = System.Drawing.Color.LightGreen
            Me.lblLocalDbStatusText.Location = New System.Drawing.Point(539, 52)
            Me.lblLocalDbStatusText.Name = "lblLocalDbStatusText"
            Me.lblLocalDbStatusText.Size = New System.Drawing.Size(579, 32)
            Me.lblLocalDbStatusText.TabIndex = 2
            Me.lblLocalDbStatusText.Text = "جاري فحص حالة محرك LocalDB..."
            Me.lblLocalDbStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnStartLocalDb
            '
            Me.btnStartLocalDb.BorderRadius = 8
            Me.btnStartLocalDb.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.btnStartLocalDb.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnStartLocalDb.ForeColor = System.Drawing.Color.White
            Me.btnStartLocalDb.Location = New System.Drawing.Point(409, 50)
            Me.btnStartLocalDb.Name = "btnStartLocalDb"
            Me.btnStartLocalDb.Size = New System.Drawing.Size(120, 36)
            Me.btnStartLocalDb.TabIndex = 3
            Me.btnStartLocalDb.Text = "▶️ تشغيل"
            '
            'btnStopLocalDb
            '
            Me.btnStopLocalDb.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnStopLocalDb.BorderRadius = 8
            Me.btnStopLocalDb.BorderThickness = 1
            Me.btnStopLocalDb.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnStopLocalDb.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnStopLocalDb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnStopLocalDb.Location = New System.Drawing.Point(279, 50)
            Me.btnStopLocalDb.Name = "btnStopLocalDb"
            Me.btnStopLocalDb.Size = New System.Drawing.Size(120, 36)
            Me.btnStopLocalDb.TabIndex = 4
            Me.btnStopLocalDb.Text = "⏹️ إيقاف"
            '
            'btnCheckLocalDb
            '
            Me.btnCheckLocalDb.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnCheckLocalDb.BorderRadius = 8
            Me.btnCheckLocalDb.BorderThickness = 1
            Me.btnCheckLocalDb.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnCheckLocalDb.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnCheckLocalDb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnCheckLocalDb.Location = New System.Drawing.Point(169, 50)
            Me.btnCheckLocalDb.Name = "btnCheckLocalDb"
            Me.btnCheckLocalDb.Size = New System.Drawing.Size(100, 36)
            Me.btnCheckLocalDb.TabIndex = 5
            Me.btnCheckLocalDb.Text = "🔄 فحص"
            '
            'btnInstallLocalDb
            '
            Me.btnInstallLocalDb.BorderRadius = 8
            Me.btnInstallLocalDb.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnInstallLocalDb.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnInstallLocalDb.ForeColor = System.Drawing.Color.White
            Me.btnInstallLocalDb.Location = New System.Drawing.Point(20, 50)
            Me.btnInstallLocalDb.Name = "btnInstallLocalDb"
            Me.btnInstallLocalDb.Size = New System.Drawing.Size(139, 36)
            Me.btnInstallLocalDb.TabIndex = 6
            Me.btnInstallLocalDb.Text = "تثبيت المحرك"
            '
            'chkAttachDb
            '
            Me.chkAttachDb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkAttachDb.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkAttachDb.CheckedState.BorderRadius = 4
            Me.chkAttachDb.CheckedState.BorderThickness = 0
            Me.chkAttachDb.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkAttachDb.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.chkAttachDb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkAttachDb.Location = New System.Drawing.Point(806, 110)
            Me.chkAttachDb.Name = "chkAttachDb"
            Me.chkAttachDb.Size = New System.Drawing.Size(310, 30)
            Me.chkAttachDb.TabIndex = 7
            Me.chkAttachDb.Text = "ربط ملف قاعدة بيانات مخصص (.mdf) مباشرة "
            Me.chkAttachDb.UncheckedState.BorderRadius = 0
            Me.chkAttachDb.UncheckedState.BorderThickness = 0
            '
            'txtAttachDbPath
            '
            Me.txtAttachDbPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtAttachDbPath.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtAttachDbPath.BorderRadius = 8
            Me.txtAttachDbPath.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtAttachDbPath.DefaultText = ""
            Me.txtAttachDbPath.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtAttachDbPath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtAttachDbPath.ForeColor = System.Drawing.Color.White
            Me.txtAttachDbPath.Location = New System.Drawing.Point(200, 107)
            Me.txtAttachDbPath.Name = "txtAttachDbPath"
            Me.txtAttachDbPath.PlaceholderText = ""
            Me.txtAttachDbPath.SelectedText = ""
            Me.txtAttachDbPath.Size = New System.Drawing.Size(600, 36)
            Me.txtAttachDbPath.TabIndex = 8
            '
            'btnBrowseMdf
            '
            Me.btnBrowseMdf.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnBrowseMdf.BorderRadius = 8
            Me.btnBrowseMdf.BorderThickness = 1
            Me.btnBrowseMdf.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnBrowseMdf.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnBrowseMdf.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnBrowseMdf.Location = New System.Drawing.Point(20, 107)
            Me.btnBrowseMdf.Name = "btnBrowseMdf"
            Me.btnBrowseMdf.Size = New System.Drawing.Size(174, 36)
            Me.btnBrowseMdf.TabIndex = 9
            Me.btnBrowseMdf.Text = "استعراض..."
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
            Me.cardServer.Location = New System.Drawing.Point(30, 385)
            Me.cardServer.Name = "cardServer"
            Me.cardServer.Size = New System.Drawing.Size(1144, 165)
            Me.cardServer.TabIndex = 4
            '
            'lblCardServerTitle
            '
            Me.lblCardServerTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardServerTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardServerTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardServerTitle.Location = New System.Drawing.Point(816, 15)
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
            Me.lblDbServer.Location = New System.Drawing.Point(936, 56)
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
            Me.txtDbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.txtDbServer.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDbServer.FocusedColor = System.Drawing.Color.Empty
            Me.txtDbServer.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDbServer.ForeColor = System.Drawing.Color.White
            Me.txtDbServer.ItemHeight = 32
            Me.txtDbServer.Location = New System.Drawing.Point(406, 52)
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
            Me.btnDetectServers.Location = New System.Drawing.Point(214, 52)
            Me.btnDetectServers.Name = "btnDetectServers"
            Me.btnDetectServers.Size = New System.Drawing.Size(177, 38)
            Me.btnDetectServers.TabIndex = 3
            Me.btnDetectServers.Text = " اكتشاف تلقائي"
            '
            'lblDbName
            '
            Me.lblDbName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbName.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDbName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDbName.Location = New System.Drawing.Point(936, 108)
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
            Me.txtDbName.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtDbName.DefaultText = "SestamkDB"
            Me.txtDbName.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDbName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDbName.ForeColor = System.Drawing.Color.White
            Me.txtDbName.Location = New System.Drawing.Point(214, 104)
            Me.txtDbName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtDbName.Name = "txtDbName"
            Me.txtDbName.PlaceholderText = ""
            Me.txtDbName.SelectedText = ""
            Me.txtDbName.Size = New System.Drawing.Size(717, 38)
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
            Me.cardAuth.Location = New System.Drawing.Point(30, 565)
            Me.cardAuth.Name = "cardAuth"
            Me.cardAuth.Size = New System.Drawing.Size(1144, 165)
            Me.cardAuth.TabIndex = 5
            '
            'lblCardAuthTitle
            '
            Me.lblCardAuthTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardAuthTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardAuthTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardAuthTitle.Location = New System.Drawing.Point(816, 15)
            Me.lblCardAuthTitle.Name = "lblCardAuthTitle"
            Me.lblCardAuthTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardAuthTitle.TabIndex = 0
            Me.lblCardAuthTitle.Text = "🔐 بيانات المصادقة والدخول"
            Me.lblCardAuthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkWindowsAuth
            '
            Me.chkWindowsAuth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkWindowsAuth.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkWindowsAuth.CheckedState.BorderRadius = 4
            Me.chkWindowsAuth.CheckedState.BorderThickness = 0
            Me.chkWindowsAuth.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkWindowsAuth.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkWindowsAuth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkWindowsAuth.Location = New System.Drawing.Point(766, 55)
            Me.chkWindowsAuth.Name = "chkWindowsAuth"
            Me.chkWindowsAuth.Size = New System.Drawing.Size(350, 30)
            Me.chkWindowsAuth.TabIndex = 1
            Me.chkWindowsAuth.Text = "استخدام مصادقة ويندوز (Windows Authentication)"
            Me.chkWindowsAuth.UncheckedState.BorderRadius = 0
            Me.chkWindowsAuth.UncheckedState.BorderThickness = 0
            '
            'lblDbUser
            '
            Me.lblDbUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbUser.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDbUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDbUser.Location = New System.Drawing.Point(936, 108)
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
            Me.txtDbUser.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtDbUser.DefaultText = ""
            Me.txtDbUser.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDbUser.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDbUser.ForeColor = System.Drawing.Color.White
            Me.txtDbUser.Location = New System.Drawing.Point(586, 104)
            Me.txtDbUser.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtDbUser.Name = "txtDbUser"
            Me.txtDbUser.PlaceholderText = ""
            Me.txtDbUser.SelectedText = ""
            Me.txtDbUser.Size = New System.Drawing.Size(345, 38)
            Me.txtDbUser.TabIndex = 3
            '
            'lblDbPassword
            '
            Me.lblDbPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDbPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDbPassword.Location = New System.Drawing.Point(406, 108)
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
            Me.txtDbPassword.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtDbPassword.DefaultText = ""
            Me.txtDbPassword.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDbPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDbPassword.ForeColor = System.Drawing.Color.White
            Me.txtDbPassword.Location = New System.Drawing.Point(30, 104)
            Me.txtDbPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtDbPassword.Name = "txtDbPassword"
            Me.txtDbPassword.PlaceholderText = ""
            Me.txtDbPassword.SelectedText = ""
            Me.txtDbPassword.Size = New System.Drawing.Size(366, 38)
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
            Me.cardStatus.Location = New System.Drawing.Point(30, 745)
            Me.cardStatus.Name = "cardStatus"
            Me.cardStatus.Size = New System.Drawing.Size(1144, 120)
            Me.cardStatus.TabIndex = 6
            '
            'lblCardStatusTitle
            '
            Me.lblCardStatusTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardStatusTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardStatusTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardStatusTitle.Location = New System.Drawing.Point(816, 15)
            Me.lblCardStatusTitle.Name = "lblCardStatusTitle"
            Me.lblCardStatusTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardStatusTitle.TabIndex = 0
            Me.lblCardStatusTitle.Text = "📡 حالة التحقق من الاتصال"
            Me.lblCardStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnTestDbConnection
            '
            Me.btnTestDbConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnTestDbConnection.BorderRadius = 8
            Me.btnTestDbConnection.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnTestDbConnection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnTestDbConnection.ForeColor = System.Drawing.Color.White
            Me.btnTestDbConnection.Location = New System.Drawing.Point(956, 55)
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
            Me.lblDbStatus.Size = New System.Drawing.Size(906, 36)
            Me.lblDbStatus.TabIndex = 2
            Me.lblDbStatus.Text = "اضغط «اختبار الاتصال» أو استخدم «تثبيت وتهيئة قاعدة بيانات LocalDB» للبدء الفوري"
            Me.lblDbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardMaintenance
            '
            Me.cardMaintenance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardMaintenance.BackColor = System.Drawing.Color.Transparent
            Me.cardMaintenance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardMaintenance.BorderRadius = 12
            Me.cardMaintenance.BorderThickness = 1
            Me.cardMaintenance.Controls.Add(Me.lblCardMaintenanceTitle)
            Me.cardMaintenance.Controls.Add(Me.lblCardMaintenanceSubtitle)
            Me.cardMaintenance.Controls.Add(Me.btnRunMaintenance)
            Me.cardMaintenance.Controls.Add(Me.btnClearLog)
            Me.cardMaintenance.Controls.Add(Me.prgMaintenance)
            Me.cardMaintenance.Controls.Add(Me.lblMaintenanceProgress)
            Me.cardMaintenance.Controls.Add(Me.txtMaintenanceLog)
            Me.cardMaintenance.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardMaintenance.Location = New System.Drawing.Point(30, 880)
            Me.cardMaintenance.Name = "cardMaintenance"
            Me.cardMaintenance.Size = New System.Drawing.Size(1144, 330)
            Me.cardMaintenance.TabIndex = 7
            '
            'lblCardMaintenanceTitle
            '
            Me.lblCardMaintenanceTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardMaintenanceTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardMaintenanceTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardMaintenanceTitle.Location = New System.Drawing.Point(796, 15)
            Me.lblCardMaintenanceTitle.Name = "lblCardMaintenanceTitle"
            Me.lblCardMaintenanceTitle.Size = New System.Drawing.Size(320, 28)
            Me.lblCardMaintenanceTitle.TabIndex = 0
            Me.lblCardMaintenanceTitle.Text = "فحص وصيانة هيكل قاعدة البيانات "
            Me.lblCardMaintenanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCardMaintenanceSubtitle
            '
            Me.lblCardMaintenanceSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardMaintenanceSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblCardMaintenanceSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblCardMaintenanceSubtitle.Location = New System.Drawing.Point(586, 45)
            Me.lblCardMaintenanceSubtitle.Name = "lblCardMaintenanceSubtitle"
            Me.lblCardMaintenanceSubtitle.Size = New System.Drawing.Size(530, 25)
            Me.lblCardMaintenanceSubtitle.TabIndex = 1
            Me.lblCardMaintenanceSubtitle.Text = "فحص الجداول والأعمدة وتطبيق الترقيعات التلقائية الآمنة دون فقدان أي بيانات سابقة"
            Me.lblCardMaintenanceSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnRunMaintenance
            '
            Me.btnRunMaintenance.BorderRadius = 8
            Me.btnRunMaintenance.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.btnRunMaintenance.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnRunMaintenance.ForeColor = System.Drawing.Color.White
            Me.btnRunMaintenance.Location = New System.Drawing.Point(30, 20)
            Me.btnRunMaintenance.Name = "btnRunMaintenance"
            Me.btnRunMaintenance.Size = New System.Drawing.Size(250, 42)
            Me.btnRunMaintenance.TabIndex = 2
            Me.btnRunMaintenance.Text = "فحص وإصلاح الهيكل تلقائياً"
            '
            'btnClearLog
            '
            Me.btnClearLog.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnClearLog.BorderRadius = 8
            Me.btnClearLog.BorderThickness = 1
            Me.btnClearLog.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnClearLog.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnClearLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClearLog.Location = New System.Drawing.Point(290, 20)
            Me.btnClearLog.Name = "btnClearLog"
            Me.btnClearLog.Size = New System.Drawing.Size(100, 42)
            Me.btnClearLog.TabIndex = 3
            Me.btnClearLog.Text = "مسح السجل"
            '
            'prgMaintenance
            '
            Me.prgMaintenance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.prgMaintenance.BorderRadius = 4
            Me.prgMaintenance.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.prgMaintenance.Location = New System.Drawing.Point(30, 75)
            Me.prgMaintenance.Name = "prgMaintenance"
            Me.prgMaintenance.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.prgMaintenance.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.prgMaintenance.Size = New System.Drawing.Size(1084, 10)
            Me.prgMaintenance.TabIndex = 4
            Me.prgMaintenance.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
            '
            'lblMaintenanceProgress
            '
            Me.lblMaintenanceProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblMaintenanceProgress.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblMaintenanceProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblMaintenanceProgress.Location = New System.Drawing.Point(30, 92)
            Me.lblMaintenanceProgress.Name = "lblMaintenanceProgress"
            Me.lblMaintenanceProgress.Size = New System.Drawing.Size(1084, 22)
            Me.lblMaintenanceProgress.TabIndex = 5
            Me.lblMaintenanceProgress.Text = "جاهز لبدء الفحص والتزامن الذاتي"
            Me.lblMaintenanceProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMaintenanceLog
            '
            Me.txtMaintenanceLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtMaintenanceLog.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtMaintenanceLog.BorderRadius = 8
            Me.txtMaintenanceLog.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtMaintenanceLog.DefaultText = ""
            Me.txtMaintenanceLog.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(24, Byte), Integer))
            Me.txtMaintenanceLog.Font = New System.Drawing.Font("Consolas", 10.0!)
            Me.txtMaintenanceLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.txtMaintenanceLog.Location = New System.Drawing.Point(30, 120)
            Me.txtMaintenanceLog.Multiline = True
            Me.txtMaintenanceLog.Name = "txtMaintenanceLog"
            Me.txtMaintenanceLog.PlaceholderText = ""
            Me.txtMaintenanceLog.ReadOnly = True
            Me.txtMaintenanceLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtMaintenanceLog.SelectedText = ""
            Me.txtMaintenanceLog.Size = New System.Drawing.Size(1084, 190)
            Me.txtMaintenanceLog.TabIndex = 6
            '
            'cardReset
            '
            Me.cardReset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardReset.BackColor = System.Drawing.Color.Transparent
            Me.cardReset.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardReset.BorderRadius = 12
            Me.cardReset.BorderThickness = 1
            Me.cardReset.Controls.Add(Me.lblCardResetTitle)
            Me.cardReset.Controls.Add(Me.lblCardResetSubtitle)
            Me.cardReset.Controls.Add(Me.btnResetTransactional)
            Me.cardReset.Controls.Add(Me.btnRefreshStats)
            Me.cardReset.Controls.Add(Me.dgvTables)
            Me.cardReset.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardReset.Location = New System.Drawing.Point(30, 1225)
            Me.cardReset.Name = "cardReset"
            Me.cardReset.Size = New System.Drawing.Size(1144, 420)
            Me.cardReset.TabIndex = 8
            '
            'lblCardResetTitle
            '
            Me.lblCardResetTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardResetTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardResetTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardResetTitle.Location = New System.Drawing.Point(716, 15)
            Me.lblCardResetTitle.Name = "lblCardResetTitle"
            Me.lblCardResetTitle.Size = New System.Drawing.Size(400, 28)
            Me.lblCardResetTitle.TabIndex = 0
            Me.lblCardResetTitle.Text = "تهيئة وتصفير جداول البيانات"
            Me.lblCardResetTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCardResetSubtitle
            '
            Me.lblCardResetSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardResetSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblCardResetSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblCardResetSubtitle.Location = New System.Drawing.Point(539, 45)
            Me.lblCardResetSubtitle.Name = "lblCardResetSubtitle"
            Me.lblCardResetSubtitle.Size = New System.Drawing.Size(577, 25)
            Me.lblCardResetSubtitle.TabIndex = 1
            Me.lblCardResetSubtitle.Text = "تفريغ الجداول وتصفير العداد التلقائي (Reseed) مع معالجة قيود المفاتيح الأجنبية بأ" &
    "مان"
            Me.lblCardResetSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnResetTransactional
            '
            Me.btnResetTransactional.BorderRadius = 8
            Me.btnResetTransactional.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
            Me.btnResetTransactional.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnResetTransactional.ForeColor = System.Drawing.Color.White
            Me.btnResetTransactional.Location = New System.Drawing.Point(30, 20)
            Me.btnResetTransactional.Name = "btnResetTransactional"
            Me.btnResetTransactional.Size = New System.Drawing.Size(310, 42)
            Me.btnResetTransactional.TabIndex = 2
            Me.btnResetTransactional.Text = "تصفير حركات المبيعات والمشتريات والخزينة"
            '
            'btnRefreshStats
            '
            Me.btnRefreshStats.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnRefreshStats.BorderRadius = 8
            Me.btnRefreshStats.BorderThickness = 1
            Me.btnRefreshStats.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnRefreshStats.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnRefreshStats.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnRefreshStats.Location = New System.Drawing.Point(350, 20)
            Me.btnRefreshStats.Name = "btnRefreshStats"
            Me.btnRefreshStats.Size = New System.Drawing.Size(140, 42)
            Me.btnRefreshStats.TabIndex = 3
            Me.btnRefreshStats.Text = "تحديث الإحصائيات"
            '
            'dgvTables
            '
            Me.dgvTables.AllowUserToAddRows = False
            Me.dgvTables.AllowUserToDeleteRows = False
            Me.dgvTables.AllowUserToResizeRows = False
            Me.dgvTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvTables.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(50, Byte), Integer))
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(50, Byte), Integer))
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvTables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvTables.ColumnHeadersHeight = 36
            Me.dgvTables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTableName, Me.colDisplayName, Me.colType, Me.colRecordCount, Me.colResetAction})
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(68, Byte), Integer))
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
            DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvTables.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvTables.GridColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.dgvTables.Location = New System.Drawing.Point(30, 75)
            Me.dgvTables.Name = "dgvTables"
            Me.dgvTables.ReadOnly = True
            Me.dgvTables.RowHeadersVisible = False
            Me.dgvTables.RowTemplate.Height = 38
            Me.dgvTables.Size = New System.Drawing.Size(1084, 325)
            Me.dgvTables.TabIndex = 4
            Me.dgvTables.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.dgvTables.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.dgvTables.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(50, Byte), Integer))
            Me.dgvTables.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.dgvTables.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvTables.ThemeStyle.HeaderStyle.Height = 36
            Me.dgvTables.ThemeStyle.ReadOnly = True
            Me.dgvTables.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.dgvTables.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.dgvTables.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White
            Me.dgvTables.ThemeStyle.RowsStyle.Height = 38
            Me.dgvTables.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(68, Byte), Integer))
            Me.dgvTables.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White
            '
            'colTableName
            '
            Me.colTableName.DataPropertyName = "TableName"
            Me.colTableName.HeaderText = "الجدول"
            Me.colTableName.Name = "colTableName"
            Me.colTableName.ReadOnly = True
            '
            'colDisplayName
            '
            Me.colDisplayName.DataPropertyName = "DisplayNameAr"
            Me.colDisplayName.HeaderText = "الوصف / الاستخدام"
            Me.colDisplayName.Name = "colDisplayName"
            Me.colDisplayName.ReadOnly = True
            '
            'colType
            '
            Me.colType.HeaderText = "طبيعة البيانات"
            Me.colType.Name = "colType"
            Me.colType.ReadOnly = True
            '
            'colRecordCount
            '
            Me.colRecordCount.DataPropertyName = "RecordCount"
            Me.colRecordCount.HeaderText = "عدد السجلات"
            Me.colRecordCount.Name = "colRecordCount"
            Me.colRecordCount.ReadOnly = True
            '
            'colResetAction
            '
            Me.colResetAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.colResetAction.HeaderText = "إجراء التهيئة"
            Me.colResetAction.Name = "colResetAction"
            Me.colResetAction.ReadOnly = True
            Me.colResetAction.Text = "🧹 تهيئة الجدول"
            Me.colResetAction.UseColumnTextForButtonValue = True
            '
            'btnSaveDbSettings
            '
            Me.btnSaveDbSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSaveDbSettings.BorderRadius = 8
            Me.btnSaveDbSettings.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSaveDbSettings.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnSaveDbSettings.ForeColor = System.Drawing.Color.White
            Me.btnSaveDbSettings.Location = New System.Drawing.Point(924, 1665)
            Me.btnSaveDbSettings.Name = "btnSaveDbSettings"
            Me.btnSaveDbSettings.Size = New System.Drawing.Size(250, 48)
            Me.btnSaveDbSettings.TabIndex = 9
            Me.btnSaveDbSettings.Text = "حفظ إعدادات قاعدة البيانات"
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
            Me.btnReset.Location = New System.Drawing.Point(686, 1665)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(220, 48)
            Me.btnReset.TabIndex = 10
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
            Me.btnClose.Location = New System.Drawing.Point(30, 1665)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 48)
            Me.btnClose.TabIndex = 11
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
            Me.cardEngine.ResumeLayout(False)
            Me.cardLocalDb.ResumeLayout(False)
            Me.cardServer.ResumeLayout(False)
            Me.cardAuth.ResumeLayout(False)
            Me.cardStatus.ResumeLayout(False)
            Me.cardMaintenance.ResumeLayout(False)
            Me.cardReset.ResumeLayout(False)
            CType(Me.dgvTables, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardEngine As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardEngineTitle As System.Windows.Forms.Label
        Friend WithEvents btnSelectLocalDb As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSelectServer As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardLocalDb As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardLocalDbTitle As System.Windows.Forms.Label
        Friend WithEvents btnInitLocalDatabase As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblLocalDbStatusText As System.Windows.Forms.Label
        Friend WithEvents btnStartLocalDb As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnStopLocalDb As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnCheckLocalDb As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnInstallLocalDb As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents chkAttachDb As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents txtAttachDbPath As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnBrowseMdf As Guna.UI2.WinForms.Guna2Button
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
        Friend WithEvents cardMaintenance As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardMaintenanceTitle As System.Windows.Forms.Label
        Friend WithEvents lblCardMaintenanceSubtitle As System.Windows.Forms.Label
        Friend WithEvents btnRunMaintenance As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClearLog As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents prgMaintenance As Guna.UI2.WinForms.Guna2ProgressBar
        Friend WithEvents lblMaintenanceProgress As System.Windows.Forms.Label
        Friend WithEvents txtMaintenanceLog As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents cardReset As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardResetTitle As System.Windows.Forms.Label
        Friend WithEvents lblCardResetSubtitle As System.Windows.Forms.Label
        Friend WithEvents btnResetTransactional As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnRefreshStats As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents dgvTables As Guna.UI2.WinForms.Guna2DataGridView
        Friend WithEvents btnSaveDbSettings As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents colTableName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDisplayName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colType As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRecordCount As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colResetAction As System.Windows.Forms.DataGridViewButtonColumn
    End Class
End Namespace
