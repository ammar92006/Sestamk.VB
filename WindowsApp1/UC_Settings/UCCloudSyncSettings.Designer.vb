Namespace UC_Settings
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCCloudSyncSettings
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        
        Me.cardSyncStatus = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitleStatus = New System.Windows.Forms.Label()
        Me.pnlStatusRow = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSyncStatusLabel = New System.Windows.Forms.Label()
        Me.lblSyncStatus = New System.Windows.Forms.Label()
        Me.lblLastSyncLabel = New System.Windows.Forms.Label()
        Me.lblLastSyncTime = New System.Windows.Forms.Label()
        Me.lblPendingLabel = New System.Windows.Forms.Label()
        Me.lblPendingChanges = New System.Windows.Forms.Label()
        Me.btnSyncNow = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefreshStatus = New Guna.UI2.WinForms.Guna2Button()
        
        Me.cardConnection = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitleConnection = New System.Windows.Forms.Label()
        Me.lblTursoUrlLabel = New System.Windows.Forms.Label()
        Me.txtTursoUrl = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblAuthTokenLabel = New System.Windows.Forms.Label()
        Me.txtAuthToken = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnToggleTokenVisibility = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTestConnection = New Guna.UI2.WinForms.Guna2Button()
        Me.lblConnectionResult = New System.Windows.Forms.Label()
        
        Me.cardSyncConfig = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitleConfig = New System.Windows.Forms.Label()
        Me.toggleSyncEnabled = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.lblToggleSyncEnabled = New System.Windows.Forms.Label()
        Me.lblSyncIntervalLabel = New System.Windows.Forms.Label()
        Me.txtSyncInterval = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblSyncIntervalHint = New System.Windows.Forms.Label()
        
        Me.cardPlatform = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitlePlatform = New System.Windows.Forms.Label()
        Me.lblPlatformHint = New System.Windows.Forms.Label()
        Me.lblPlatformTokenLabel = New System.Windows.Forms.Label()
        Me.txtPlatformToken = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblOrgSlugLabel = New System.Windows.Forms.Label()
        Me.txtOrgSlug = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblDbNameLabel = New System.Windows.Forms.Label()
        Me.txtDbName = New Guna.UI2.WinForms.Guna2TextBox()
        
        Me.cardSyncLog = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitleLog = New System.Windows.Forms.Label()
        Me.dgvSyncLog = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.btnClearLog = New Guna.UI2.WinForms.Guna2Button()
        
        Me.pnlActions = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
        Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()

        Me.pnlMain.SuspendLayout()
        Me.cardSyncStatus.SuspendLayout()
        Me.pnlStatusRow.SuspendLayout()
        Me.cardConnection.SuspendLayout()
        Me.cardSyncConfig.SuspendLayout()
        Me.cardPlatform.SuspendLayout()
        Me.cardSyncLog.SuspendLayout()
        CType(Me.dgvSyncLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActions.SuspendLayout()
        Me.SuspendLayout()
        
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(13, 15, 20)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlMain.Size = New System.Drawing.Size(1000, 1100)
        Me.pnlMain.TabIndex = 0
        
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(235, 235, 240)
        Me.lblTitle.Location = New System.Drawing.Point(30, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(940, 50)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "المزامنة السحابية"
        
        '
        'lblSubtitle
        '
        Me.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblSubtitle.Location = New System.Drawing.Point(30, 70)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(940, 35)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "إدارة المزامنة مع السحابة ومراقبة حالة الاتصال"
        
        '
        'cardSyncStatus
        '
        Me.cardSyncStatus.BackColor = System.Drawing.Color.Transparent
        Me.cardSyncStatus.BorderColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.cardSyncStatus.BorderRadius = 12
        Me.cardSyncStatus.BorderThickness = 1
        Me.cardSyncStatus.Controls.Add(Me.btnRefreshStatus)
        Me.cardSyncStatus.Controls.Add(Me.btnSyncNow)
        Me.cardSyncStatus.Controls.Add(Me.pnlStatusRow)
        Me.cardSyncStatus.Controls.Add(Me.lblCardTitleStatus)
        Me.cardSyncStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardSyncStatus.FillColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.cardSyncStatus.Location = New System.Drawing.Point(30, 105)
        Me.cardSyncStatus.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardSyncStatus.Name = "cardSyncStatus"
        Me.cardSyncStatus.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardSyncStatus.Size = New System.Drawing.Size(940, 180)
        Me.cardSyncStatus.TabIndex = 2
        
        '
        'lblCardTitleStatus
        '
        Me.lblCardTitleStatus.AutoSize = True
        Me.lblCardTitleStatus.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleStatus.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleStatus.Location = New System.Drawing.Point(800, 15)
        Me.lblCardTitleStatus.Name = "lblCardTitleStatus"
        Me.lblCardTitleStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleStatus.Size = New System.Drawing.Size(120, 25)
        Me.lblCardTitleStatus.TabIndex = 0
        Me.lblCardTitleStatus.Text = "حالة المزامنة"
        
        '
        'pnlStatusRow
        '
        Me.pnlStatusRow.Controls.Add(Me.lblSyncStatusLabel)
        Me.pnlStatusRow.Controls.Add(Me.lblSyncStatus)
        Me.pnlStatusRow.Controls.Add(Me.lblLastSyncLabel)
        Me.pnlStatusRow.Controls.Add(Me.lblLastSyncTime)
        Me.pnlStatusRow.Controls.Add(Me.lblPendingLabel)
        Me.pnlStatusRow.Controls.Add(Me.lblPendingChanges)
        Me.pnlStatusRow.Location = New System.Drawing.Point(20, 60)
        Me.pnlStatusRow.Name = "pnlStatusRow"
        Me.pnlStatusRow.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlStatusRow.Size = New System.Drawing.Size(900, 40)
        Me.pnlStatusRow.TabIndex = 1
        
        '
        'lblSyncStatusLabel
        '
        Me.lblSyncStatusLabel.AutoSize = True
        Me.lblSyncStatusLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblSyncStatusLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblSyncStatusLabel.Location = New System.Drawing.Point(830, 8)
        Me.lblSyncStatusLabel.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.lblSyncStatusLabel.Name = "lblSyncStatusLabel"
        Me.lblSyncStatusLabel.Size = New System.Drawing.Size(51, 21)
        Me.lblSyncStatusLabel.TabIndex = 0
        Me.lblSyncStatusLabel.Text = "الحالة:"
        
        '
        'lblSyncStatus
        '
        Me.lblSyncStatus.AutoSize = True
        Me.lblSyncStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSyncStatus.ForeColor = System.Drawing.Color.FromArgb(158, 158, 158)
        Me.lblSyncStatus.Location = New System.Drawing.Point(740, 8)
        Me.lblSyncStatus.Margin = New System.Windows.Forms.Padding(3, 8, 30, 0)
        Me.lblSyncStatus.Name = "lblSyncStatus"
        Me.lblSyncStatus.Size = New System.Drawing.Size(71, 21)
        Me.lblSyncStatus.TabIndex = 1
        Me.lblSyncStatus.Text = "غير مهيأ"
        
        '
        'lblLastSyncLabel
        '
        Me.lblLastSyncLabel.AutoSize = True
        Me.lblLastSyncLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblLastSyncLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblLastSyncLabel.Location = New System.Drawing.Point(620, 8)
        Me.lblLastSyncLabel.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.lblLastSyncLabel.Name = "lblLastSyncLabel"
        Me.lblLastSyncLabel.Size = New System.Drawing.Size(89, 21)
        Me.lblLastSyncLabel.TabIndex = 2
        Me.lblLastSyncLabel.Text = "آخر مزامنة:"
        
        '
        'lblLastSyncTime
        '
        Me.lblLastSyncTime.AutoSize = True
        Me.lblLastSyncTime.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastSyncTime.ForeColor = System.Drawing.Color.White
        Me.lblLastSyncTime.Location = New System.Drawing.Point(550, 8)
        Me.lblLastSyncTime.Margin = New System.Windows.Forms.Padding(3, 8, 30, 0)
        Me.lblLastSyncTime.Name = "lblLastSyncTime"
        Me.lblLastSyncTime.Size = New System.Drawing.Size(31, 21)
        Me.lblLastSyncTime.TabIndex = 3
        Me.lblLastSyncTime.Text = "---"
        
        '
        'lblPendingLabel
        '
        Me.lblPendingLabel.AutoSize = True
        Me.lblPendingLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblPendingLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblPendingLabel.Location = New System.Drawing.Point(400, 8)
        Me.lblPendingLabel.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.lblPendingLabel.Name = "lblPendingLabel"
        Me.lblPendingLabel.Size = New System.Drawing.Size(107, 21)
        Me.lblPendingLabel.TabIndex = 4
        Me.lblPendingLabel.Text = "تغييرات معلقة:"
        
        '
        'lblPendingChanges
        '
        Me.lblPendingChanges.AutoSize = True
        Me.lblPendingChanges.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPendingChanges.ForeColor = System.Drawing.Color.White
        Me.lblPendingChanges.Location = New System.Drawing.Point(350, 8)
        Me.lblPendingChanges.Margin = New System.Windows.Forms.Padding(3, 8, 30, 0)
        Me.lblPendingChanges.Name = "lblPendingChanges"
        Me.lblPendingChanges.Size = New System.Drawing.Size(19, 21)
        Me.lblPendingChanges.TabIndex = 5
        Me.lblPendingChanges.Text = "0"
        
        '
        'btnSyncNow
        '
        Me.btnSyncNow.BorderRadius = 10
        Me.btnSyncNow.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSyncNow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSyncNow.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169)
        Me.btnSyncNow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141)
        Me.btnSyncNow.FillColor = System.Drawing.Color.FromArgb(56, 142, 60)
        Me.btnSyncNow.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSyncNow.ForeColor = System.Drawing.Color.White
        Me.btnSyncNow.Location = New System.Drawing.Point(740, 115)
        Me.btnSyncNow.Name = "btnSyncNow"
        Me.btnSyncNow.Size = New System.Drawing.Size(180, 42)
        Me.btnSyncNow.TabIndex = 2
        Me.btnSyncNow.Text = "🔄 مزامنة الآن"
        
        '
        'btnRefreshStatus
        '
        Me.btnRefreshStatus.BorderRadius = 10
        Me.btnRefreshStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnRefreshStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnRefreshStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169)
        Me.btnRefreshStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141)
        Me.btnRefreshStatus.FillColor = System.Drawing.Color.FromArgb(66, 66, 90)
        Me.btnRefreshStatus.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshStatus.ForeColor = System.Drawing.Color.White
        Me.btnRefreshStatus.Location = New System.Drawing.Point(600, 115)
        Me.btnRefreshStatus.Name = "btnRefreshStatus"
        Me.btnRefreshStatus.Size = New System.Drawing.Size(120, 42)
        Me.btnRefreshStatus.TabIndex = 3
        Me.btnRefreshStatus.Text = "تحديث"
        
        '
        'cardConnection
        '
        Me.cardConnection.BackColor = System.Drawing.Color.Transparent
        Me.cardConnection.BorderColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.cardConnection.BorderRadius = 12
        Me.cardConnection.BorderThickness = 1
        Me.cardConnection.Controls.Add(Me.lblConnectionResult)
        Me.cardConnection.Controls.Add(Me.btnTestConnection)
        Me.cardConnection.Controls.Add(Me.btnToggleTokenVisibility)
        Me.cardConnection.Controls.Add(Me.txtAuthToken)
        Me.cardConnection.Controls.Add(Me.lblAuthTokenLabel)
        Me.cardConnection.Controls.Add(Me.txtTursoUrl)
        Me.cardConnection.Controls.Add(Me.lblTursoUrlLabel)
        Me.cardConnection.Controls.Add(Me.lblCardTitleConnection)
        Me.cardConnection.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardConnection.FillColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.cardConnection.Location = New System.Drawing.Point(30, 285)
        Me.cardConnection.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardConnection.Name = "cardConnection"
        Me.cardConnection.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardConnection.Size = New System.Drawing.Size(940, 250)
        Me.cardConnection.TabIndex = 3
        
        '
        'lblCardTitleConnection
        '
        Me.lblCardTitleConnection.AutoSize = True
        Me.lblCardTitleConnection.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleConnection.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleConnection.Location = New System.Drawing.Point(700, 15)
        Me.lblCardTitleConnection.Name = "lblCardTitleConnection"
        Me.lblCardTitleConnection.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleConnection.Size = New System.Drawing.Size(220, 25)
        Me.lblCardTitleConnection.TabIndex = 0
        Me.lblCardTitleConnection.Text = "إعدادات الاتصال بالسحابة"
        
        '
        'lblTursoUrlLabel
        '
        Me.lblTursoUrlLabel.AutoSize = True
        Me.lblTursoUrlLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblTursoUrlLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblTursoUrlLabel.Location = New System.Drawing.Point(670, 70)
        Me.lblTursoUrlLabel.Name = "lblTursoUrlLabel"
        Me.lblTursoUrlLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTursoUrlLabel.Size = New System.Drawing.Size(250, 21)
        Me.lblTursoUrlLabel.TabIndex = 1
        Me.lblTursoUrlLabel.Text = "رابط قاعدة البيانات (Database URL):"
        
        '
        'txtTursoUrl
        '
        Me.txtTursoUrl.BorderRadius = 8
        Me.txtTursoUrl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTursoUrl.DefaultText = ""
        Me.txtTursoUrl.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208)
        Me.txtTursoUrl.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226)
        Me.txtTursoUrl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtTursoUrl.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtTursoUrl.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtTursoUrl.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtTursoUrl.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtTursoUrl.Location = New System.Drawing.Point(150, 60)
        Me.txtTursoUrl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTursoUrl.Name = "txtTursoUrl"
        Me.txtTursoUrl.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTursoUrl.PlaceholderText = "https://db-name.turso.io"
        Me.txtTursoUrl.SelectedText = ""
        Me.txtTursoUrl.Size = New System.Drawing.Size(500, 42)
        Me.txtTursoUrl.TabIndex = 2
        
        '
        'lblAuthTokenLabel
        '
        Me.lblAuthTokenLabel.AutoSize = True
        Me.lblAuthTokenLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblAuthTokenLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblAuthTokenLabel.Location = New System.Drawing.Point(670, 125)
        Me.lblAuthTokenLabel.Name = "lblAuthTokenLabel"
        Me.lblAuthTokenLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAuthTokenLabel.Size = New System.Drawing.Size(200, 21)
        Me.lblAuthTokenLabel.TabIndex = 3
        Me.lblAuthTokenLabel.Text = "رمز المصادقة (Auth Token):"
        
        '
        'txtAuthToken
        '
        Me.txtAuthToken.BorderRadius = 8
        Me.txtAuthToken.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAuthToken.DefaultText = ""
        Me.txtAuthToken.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208)
        Me.txtAuthToken.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226)
        Me.txtAuthToken.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtAuthToken.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtAuthToken.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtAuthToken.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtAuthToken.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtAuthToken.Location = New System.Drawing.Point(200, 115)
        Me.txtAuthToken.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAuthToken.Name = "txtAuthToken"
        Me.txtAuthToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtAuthToken.PlaceholderText = "eyJhbGciOi..."
        Me.txtAuthToken.SelectedText = ""
        Me.txtAuthToken.Size = New System.Drawing.Size(450, 42)
        Me.txtAuthToken.TabIndex = 4
        Me.txtAuthToken.UseSystemPasswordChar = True
        
        '
        'btnToggleTokenVisibility
        '
        Me.btnToggleTokenVisibility.BorderRadius = 8
        Me.btnToggleTokenVisibility.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnToggleTokenVisibility.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnToggleTokenVisibility.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169)
        Me.btnToggleTokenVisibility.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141)
        Me.btnToggleTokenVisibility.FillColor = System.Drawing.Color.FromArgb(66, 66, 90)
        Me.btnToggleTokenVisibility.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.btnToggleTokenVisibility.ForeColor = System.Drawing.Color.White
        Me.btnToggleTokenVisibility.Location = New System.Drawing.Point(150, 115)
        Me.btnToggleTokenVisibility.Name = "btnToggleTokenVisibility"
        Me.btnToggleTokenVisibility.Size = New System.Drawing.Size(42, 42)
        Me.btnToggleTokenVisibility.TabIndex = 5
        Me.btnToggleTokenVisibility.Text = "👁"
        
        '
        'btnTestConnection
        '
        Me.btnTestConnection.BorderRadius = 10
        Me.btnTestConnection.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTestConnection.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTestConnection.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169)
        Me.btnTestConnection.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141)
        Me.btnTestConnection.FillColor = System.Drawing.Color.FromArgb(33, 150, 243)
        Me.btnTestConnection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnTestConnection.ForeColor = System.Drawing.Color.White
        Me.btnTestConnection.Location = New System.Drawing.Point(740, 185)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(180, 42)
        Me.btnTestConnection.TabIndex = 6
        Me.btnTestConnection.Text = "🔗 اختبار الاتصال"
        
        '
        'lblConnectionResult
        '
        Me.lblConnectionResult.AutoSize = True
        Me.lblConnectionResult.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblConnectionResult.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblConnectionResult.Location = New System.Drawing.Point(400, 195)
        Me.lblConnectionResult.Name = "lblConnectionResult"
        Me.lblConnectionResult.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblConnectionResult.Size = New System.Drawing.Size(0, 20)
        Me.lblConnectionResult.TabIndex = 7
        
        '
        'cardSyncConfig
        '
        Me.cardSyncConfig.BackColor = System.Drawing.Color.Transparent
        Me.cardSyncConfig.BorderColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.cardSyncConfig.BorderRadius = 12
        Me.cardSyncConfig.BorderThickness = 1
        Me.cardSyncConfig.Controls.Add(Me.lblSyncIntervalHint)
        Me.cardSyncConfig.Controls.Add(Me.txtSyncInterval)
        Me.cardSyncConfig.Controls.Add(Me.lblSyncIntervalLabel)
        Me.cardSyncConfig.Controls.Add(Me.lblToggleSyncEnabled)
        Me.cardSyncConfig.Controls.Add(Me.toggleSyncEnabled)
        Me.cardSyncConfig.Controls.Add(Me.lblCardTitleConfig)
        Me.cardSyncConfig.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardSyncConfig.FillColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.cardSyncConfig.Location = New System.Drawing.Point(30, 535)
        Me.cardSyncConfig.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardSyncConfig.Name = "cardSyncConfig"
        Me.cardSyncConfig.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardSyncConfig.Size = New System.Drawing.Size(940, 160)
        Me.cardSyncConfig.TabIndex = 4
        
        '
        'lblCardTitleConfig
        '
        Me.lblCardTitleConfig.AutoSize = True
        Me.lblCardTitleConfig.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleConfig.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleConfig.Location = New System.Drawing.Point(770, 15)
        Me.lblCardTitleConfig.Name = "lblCardTitleConfig"
        Me.lblCardTitleConfig.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleConfig.Size = New System.Drawing.Size(150, 25)
        Me.lblCardTitleConfig.TabIndex = 0
        Me.lblCardTitleConfig.Text = "إعدادات المزامنة"
        
        '
        'toggleSyncEnabled
        '
        Me.toggleSyncEnabled.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.toggleSyncEnabled.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.toggleSyncEnabled.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.toggleSyncEnabled.CheckedState.InnerColor = System.Drawing.Color.White
        Me.toggleSyncEnabled.Location = New System.Drawing.Point(860, 60)
        Me.toggleSyncEnabled.Name = "toggleSyncEnabled"
        Me.toggleSyncEnabled.Size = New System.Drawing.Size(50, 24)
        Me.toggleSyncEnabled.TabIndex = 1
        Me.toggleSyncEnabled.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149)
        Me.toggleSyncEnabled.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149)
        Me.toggleSyncEnabled.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.toggleSyncEnabled.UncheckedState.InnerColor = System.Drawing.Color.White
        
        '
        'lblToggleSyncEnabled
        '
        Me.lblToggleSyncEnabled.AutoSize = True
        Me.lblToggleSyncEnabled.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblToggleSyncEnabled.ForeColor = System.Drawing.Color.White
        Me.lblToggleSyncEnabled.Location = New System.Drawing.Point(680, 60)
        Me.lblToggleSyncEnabled.Name = "lblToggleSyncEnabled"
        Me.lblToggleSyncEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblToggleSyncEnabled.Size = New System.Drawing.Size(160, 21)
        Me.lblToggleSyncEnabled.TabIndex = 2
        Me.lblToggleSyncEnabled.Text = "تفعيل المزامنة التلقائية"
        
        '
        'lblSyncIntervalLabel
        '
        Me.lblSyncIntervalLabel.AutoSize = True
        Me.lblSyncIntervalLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblSyncIntervalLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblSyncIntervalLabel.Location = New System.Drawing.Point(680, 110)
        Me.lblSyncIntervalLabel.Name = "lblSyncIntervalLabel"
        Me.lblSyncIntervalLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSyncIntervalLabel.Size = New System.Drawing.Size(180, 21)
        Me.lblSyncIntervalLabel.TabIndex = 3
        Me.lblSyncIntervalLabel.Text = "فاصل المزامنة (بالثانية):"
        
        '
        'txtSyncInterval
        '
        Me.txtSyncInterval.BorderRadius = 8
        Me.txtSyncInterval.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSyncInterval.DefaultText = "30"
        Me.txtSyncInterval.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208)
        Me.txtSyncInterval.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226)
        Me.txtSyncInterval.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtSyncInterval.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtSyncInterval.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtSyncInterval.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtSyncInterval.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtSyncInterval.Location = New System.Drawing.Point(550, 102)
        Me.txtSyncInterval.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSyncInterval.Name = "txtSyncInterval"
        Me.txtSyncInterval.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSyncInterval.PlaceholderText = ""
        Me.txtSyncInterval.SelectedText = ""
        Me.txtSyncInterval.Size = New System.Drawing.Size(100, 36)
        Me.txtSyncInterval.TabIndex = 4
        
        '
        'lblSyncIntervalHint
        '
        Me.lblSyncIntervalHint.AutoSize = True
        Me.lblSyncIntervalHint.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblSyncIntervalHint.ForeColor = System.Drawing.Color.FromArgb(120, 120, 140)
        Me.lblSyncIntervalHint.Location = New System.Drawing.Point(340, 110)
        Me.lblSyncIntervalHint.Name = "lblSyncIntervalHint"
        Me.lblSyncIntervalHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSyncIntervalHint.Size = New System.Drawing.Size(190, 20)
        Me.lblSyncIntervalHint.TabIndex = 5
        Me.lblSyncIntervalHint.Text = "القيمة الموصى بها: 30 ثانية"
        
        '
        'cardPlatform
        '
        Me.cardPlatform.BackColor = System.Drawing.Color.Transparent
        Me.cardPlatform.BorderColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.cardPlatform.BorderRadius = 12
        Me.cardPlatform.BorderThickness = 1
        Me.cardPlatform.Controls.Add(Me.txtDbName)
        Me.cardPlatform.Controls.Add(Me.lblDbNameLabel)
        Me.cardPlatform.Controls.Add(Me.txtOrgSlug)
        Me.cardPlatform.Controls.Add(Me.lblOrgSlugLabel)
        Me.cardPlatform.Controls.Add(Me.txtPlatformToken)
        Me.cardPlatform.Controls.Add(Me.lblPlatformTokenLabel)
        Me.cardPlatform.Controls.Add(Me.lblPlatformHint)
        Me.cardPlatform.Controls.Add(Me.lblCardTitlePlatform)
        Me.cardPlatform.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardPlatform.FillColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.cardPlatform.Location = New System.Drawing.Point(30, 695)
        Me.cardPlatform.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardPlatform.Name = "cardPlatform"
        Me.cardPlatform.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardPlatform.Size = New System.Drawing.Size(940, 200)
        Me.cardPlatform.TabIndex = 5
        
        '
        'lblCardTitlePlatform
        '
        Me.lblCardTitlePlatform.AutoSize = True
        Me.lblCardTitlePlatform.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitlePlatform.ForeColor = System.Drawing.Color.White
        Me.lblCardTitlePlatform.Location = New System.Drawing.Point(700, 15)
        Me.lblCardTitlePlatform.Name = "lblCardTitlePlatform"
        Me.lblCardTitlePlatform.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitlePlatform.Size = New System.Drawing.Size(220, 25)
        Me.lblCardTitlePlatform.TabIndex = 0
        Me.lblCardTitlePlatform.Text = "إعدادات المنصة (متقدم)"
        
        '
        'lblPlatformHint
        '
        Me.lblPlatformHint.AutoSize = True
        Me.lblPlatformHint.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblPlatformHint.ForeColor = System.Drawing.Color.FromArgb(255, 183, 77)
        Me.lblPlatformHint.Location = New System.Drawing.Point(400, 18)
        Me.lblPlatformHint.Name = "lblPlatformHint"
        Me.lblPlatformHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPlatformHint.Size = New System.Drawing.Size(280, 20)
        Me.lblPlatformHint.TabIndex = 1
        Me.lblPlatformHint.Text = "يتم تهيئة هذه الإعدادات تلقائياً عند تفعيل البرنامج. لا تغيرها إلا للضرورة."
        
        '
        'lblPlatformTokenLabel
        '
        Me.lblPlatformTokenLabel.AutoSize = True
        Me.lblPlatformTokenLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblPlatformTokenLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblPlatformTokenLabel.Location = New System.Drawing.Point(670, 70)
        Me.lblPlatformTokenLabel.Name = "lblPlatformTokenLabel"
        Me.lblPlatformTokenLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPlatformTokenLabel.Size = New System.Drawing.Size(230, 21)
        Me.lblPlatformTokenLabel.TabIndex = 2
        Me.lblPlatformTokenLabel.Text = "رمز المنصة (Platform Token):"
        
        '
        'txtPlatformToken
        '
        Me.txtPlatformToken.BorderRadius = 8
        Me.txtPlatformToken.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlatformToken.DefaultText = ""
        Me.txtPlatformToken.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208)
        Me.txtPlatformToken.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226)
        Me.txtPlatformToken.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtPlatformToken.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtPlatformToken.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtPlatformToken.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPlatformToken.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtPlatformToken.Location = New System.Drawing.Point(150, 60)
        Me.txtPlatformToken.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPlatformToken.Name = "txtPlatformToken"
        Me.txtPlatformToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPlatformToken.PlaceholderText = ""
        Me.txtPlatformToken.SelectedText = ""
        Me.txtPlatformToken.Size = New System.Drawing.Size(500, 42)
        Me.txtPlatformToken.TabIndex = 3
        Me.txtPlatformToken.UseSystemPasswordChar = True
        
        '
        'lblOrgSlugLabel
        '
        Me.lblOrgSlugLabel.AutoSize = True
        Me.lblOrgSlugLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblOrgSlugLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblOrgSlugLabel.Location = New System.Drawing.Point(670, 125)
        Me.lblOrgSlugLabel.Name = "lblOrgSlugLabel"
        Me.lblOrgSlugLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblOrgSlugLabel.Size = New System.Drawing.Size(180, 21)
        Me.lblOrgSlugLabel.TabIndex = 4
        Me.lblOrgSlugLabel.Text = "اسم المؤسسة (Organization):"
        
        '
        'txtOrgSlug
        '
        Me.txtOrgSlug.BorderRadius = 8
        Me.txtOrgSlug.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOrgSlug.DefaultText = ""
        Me.txtOrgSlug.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208)
        Me.txtOrgSlug.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226)
        Me.txtOrgSlug.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtOrgSlug.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtOrgSlug.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtOrgSlug.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtOrgSlug.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtOrgSlug.Location = New System.Drawing.Point(350, 115)
        Me.txtOrgSlug.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOrgSlug.Name = "txtOrgSlug"
        Me.txtOrgSlug.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOrgSlug.PlaceholderText = ""
        Me.txtOrgSlug.SelectedText = ""
        Me.txtOrgSlug.Size = New System.Drawing.Size(300, 42)
        Me.txtOrgSlug.TabIndex = 5
        
        '
        'lblDbNameLabel
        '
        Me.lblDbNameLabel.AutoSize = True
        Me.lblDbNameLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDbNameLabel.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblDbNameLabel.Location = New System.Drawing.Point(200, 125)
        Me.lblDbNameLabel.Name = "lblDbNameLabel"
        Me.lblDbNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDbNameLabel.Size = New System.Drawing.Size(140, 21)
        Me.lblDbNameLabel.TabIndex = 6
        Me.lblDbNameLabel.Text = "اسم قاعدة البيانات:"
        
        '
        'txtDbName
        '
        Me.txtDbName.BorderRadius = 8
        Me.txtDbName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDbName.DefaultText = ""
        Me.txtDbName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208)
        Me.txtDbName.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226)
        Me.txtDbName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtDbName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138)
        Me.txtDbName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtDbName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtDbName.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255)
        Me.txtDbName.Location = New System.Drawing.Point(30, 115)
        Me.txtDbName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDbName.PlaceholderText = ""
        Me.txtDbName.SelectedText = ""
        Me.txtDbName.Size = New System.Drawing.Size(150, 42)
        Me.txtDbName.TabIndex = 7
        
        '
        'cardSyncLog
        '
        Me.cardSyncLog.BackColor = System.Drawing.Color.Transparent
        Me.cardSyncLog.BorderColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.cardSyncLog.BorderRadius = 12
        Me.cardSyncLog.BorderThickness = 1
        Me.cardSyncLog.Controls.Add(Me.dgvSyncLog)
        Me.cardSyncLog.Controls.Add(Me.btnClearLog)
        Me.cardSyncLog.Controls.Add(Me.lblCardTitleLog)
        Me.cardSyncLog.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardSyncLog.FillColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.cardSyncLog.Location = New System.Drawing.Point(30, 895)
        Me.cardSyncLog.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardSyncLog.Name = "cardSyncLog"
        Me.cardSyncLog.Padding = New System.Windows.Forms.Padding(20, 50, 20, 20)
        Me.cardSyncLog.Size = New System.Drawing.Size(940, 250)
        Me.cardSyncLog.TabIndex = 6
        
        '
        'lblCardTitleLog
        '
        Me.lblCardTitleLog.AutoSize = True
        Me.lblCardTitleLog.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleLog.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleLog.Location = New System.Drawing.Point(800, 15)
        Me.lblCardTitleLog.Name = "lblCardTitleLog"
        Me.lblCardTitleLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleLog.Size = New System.Drawing.Size(120, 25)
        Me.lblCardTitleLog.TabIndex = 0
        Me.lblCardTitleLog.Text = "سجل المزامنة"
        
        '
        'btnClearLog
        '
        Me.btnClearLog.BorderRadius = 8
        Me.btnClearLog.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearLog.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearLog.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169)
        Me.btnClearLog.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141)
        Me.btnClearLog.FillColor = System.Drawing.Color.FromArgb(66, 66, 90)
        Me.btnClearLog.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnClearLog.ForeColor = System.Drawing.Color.White
        Me.btnClearLog.Location = New System.Drawing.Point(20, 10)
        Me.btnClearLog.Name = "btnClearLog"
        Me.btnClearLog.Size = New System.Drawing.Size(140, 38)
        Me.btnClearLog.TabIndex = 1
        Me.btnClearLog.Text = "مسح السجل"
        
        '
        'dgvSyncLog
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(33, 35, 43)
        Me.dgvSyncLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSyncLog.BackgroundColor = System.Drawing.Color.FromArgb(24, 26, 33)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(45, 48, 58)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True
        Me.dgvSyncLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSyncLog.ColumnHeadersHeight = 30
        Me.dgvSyncLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(24, 26, 33)
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(235, 235, 240)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(55, 58, 68)
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False
        Me.dgvSyncLog.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSyncLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSyncLog.GridColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.dgvSyncLog.Location = New System.Drawing.Point(20, 50)
        Me.dgvSyncLog.Name = "dgvSyncLog"
        Me.dgvSyncLog.ReadOnly = True
        Me.dgvSyncLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvSyncLog.RowHeadersVisible = False
        Me.dgvSyncLog.Size = New System.Drawing.Size(900, 180)
        Me.dgvSyncLog.TabIndex = 2
        Me.dgvSyncLog.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(33, 35, 43)
        Me.dgvSyncLog.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvSyncLog.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvSyncLog.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvSyncLog.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvSyncLog.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.dgvSyncLog.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.Height = 30
        Me.dgvSyncLog.ThemeStyle.ReadOnly = True
        Me.dgvSyncLog.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.dgvSyncLog.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvSyncLog.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgvSyncLog.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(235, 235, 240)
        Me.dgvSyncLog.ThemeStyle.RowsStyle.Height = 22
        Me.dgvSyncLog.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(55, 58, 68)
        Me.dgvSyncLog.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White
        
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.Transparent
        Me.pnlActions.Controls.Add(Me.btnClose)
        Me.pnlActions.Controls.Add(Me.btnReset)
        Me.pnlActions.Controls.Add(Me.btnSave)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActions.Location = New System.Drawing.Point(30, 1145)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(940, 70)
        Me.pnlActions.TabIndex = 7
        
        '
        'btnSave
        '
        Me.btnSave.BorderRadius = 10
        Me.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169)
        Me.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141)
        Me.btnSave.FillColor = System.Drawing.Color.FromArgb(0, 137, 123)
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(740, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(180, 46)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "💾 حفظ الإعدادات"
        
        '
        'btnReset
        '
        Me.btnReset.BorderRadius = 10
        Me.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169)
        Me.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141)
        Me.btnReset.FillColor = System.Drawing.Color.FromArgb(66, 66, 90)
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(560, 15)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(160, 46)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "إعادة ضبط"
        
        '
        'btnClose
        '
        Me.btnClose.BorderRadius = 10
        Me.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169)
        Me.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141)
        Me.btnClose.FillColor = System.Drawing.Color.FromArgb(183, 28, 28)
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(20, 15)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(130, 46)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "إغلاق"

        '
        'UCCloudSyncSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(13, 15, 20)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "UCCloudSyncSettings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(1000, 1100)
        
        Me.pnlMain.Controls.Add(Me.pnlActions)
        Me.pnlMain.Controls.Add(Me.cardSyncLog)
        Me.pnlMain.Controls.Add(Me.cardPlatform)
        Me.pnlMain.Controls.Add(Me.cardSyncConfig)
        Me.pnlMain.Controls.Add(Me.cardConnection)
        Me.pnlMain.Controls.Add(Me.cardSyncStatus)
        Me.pnlMain.Controls.Add(Me.lblSubtitle)
        Me.pnlMain.Controls.Add(Me.lblTitle)

        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.cardSyncStatus.ResumeLayout(False)
        Me.cardSyncStatus.PerformLayout()
        Me.pnlStatusRow.ResumeLayout(False)
        Me.pnlStatusRow.PerformLayout()
        Me.cardConnection.ResumeLayout(False)
        Me.cardConnection.PerformLayout()
        Me.cardSyncConfig.ResumeLayout(False)
        Me.cardSyncConfig.PerformLayout()
        Me.cardPlatform.ResumeLayout(False)
        Me.cardPlatform.PerformLayout()
        Me.cardSyncLog.ResumeLayout(False)
        Me.cardSyncLog.PerformLayout()
        CType(Me.dgvSyncLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    
    Friend WithEvents cardSyncStatus As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardTitleStatus As System.Windows.Forms.Label
    Friend WithEvents pnlStatusRow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblSyncStatusLabel As System.Windows.Forms.Label
    Friend WithEvents lblSyncStatus As System.Windows.Forms.Label
    Friend WithEvents lblLastSyncLabel As System.Windows.Forms.Label
    Friend WithEvents lblLastSyncTime As System.Windows.Forms.Label
    Friend WithEvents lblPendingLabel As System.Windows.Forms.Label
    Friend WithEvents lblPendingChanges As System.Windows.Forms.Label
    Friend WithEvents btnSyncNow As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRefreshStatus As Guna.UI2.WinForms.Guna2Button
    
    Friend WithEvents cardConnection As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardTitleConnection As System.Windows.Forms.Label
    Friend WithEvents lblTursoUrlLabel As System.Windows.Forms.Label
    Friend WithEvents txtTursoUrl As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblAuthTokenLabel As System.Windows.Forms.Label
    Friend WithEvents txtAuthToken As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnToggleTokenVisibility As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTestConnection As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblConnectionResult As System.Windows.Forms.Label
    
    Friend WithEvents cardSyncConfig As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardTitleConfig As System.Windows.Forms.Label
    Friend WithEvents toggleSyncEnabled As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents lblToggleSyncEnabled As System.Windows.Forms.Label
    Friend WithEvents lblSyncIntervalLabel As System.Windows.Forms.Label
    Friend WithEvents txtSyncInterval As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblSyncIntervalHint As System.Windows.Forms.Label
    
    Friend WithEvents cardPlatform As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardTitlePlatform As System.Windows.Forms.Label
    Friend WithEvents lblPlatformHint As System.Windows.Forms.Label
    Friend WithEvents lblPlatformTokenLabel As System.Windows.Forms.Label
    Friend WithEvents txtPlatformToken As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblOrgSlugLabel As System.Windows.Forms.Label
    Friend WithEvents txtOrgSlug As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblDbNameLabel As System.Windows.Forms.Label
    Friend WithEvents txtDbName As Guna.UI2.WinForms.Guna2TextBox
    
    Friend WithEvents cardSyncLog As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardTitleLog As System.Windows.Forms.Label
    Friend WithEvents dgvSyncLog As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents btnClearLog As Guna.UI2.WinForms.Guna2Button
    
    Friend WithEvents pnlActions As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button

End Class
End Namespace
