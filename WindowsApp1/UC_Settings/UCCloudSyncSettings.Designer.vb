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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()

        ' ── بطاقة حالة المزامنة اللحظية وشريط التقدم ──
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
        Me.prgSyncProgress = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.lblSyncProgressText = New System.Windows.Forms.Label()

        ' ── بطاقة أجهزة المنشأة المتزامنة داخل نفس الشركة ──
        Me.cardDevices = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitleDevices = New System.Windows.Forms.Label()
        Me.lblDevicesHint = New System.Windows.Forms.Label()
        Me.lblDevicesCount = New System.Windows.Forms.Label()
        Me.btnRefreshDevices = New Guna.UI2.WinForms.Guna2Button()
        Me.dgvDevices = New Guna.UI2.WinForms.Guna2DataGridView()

        ' ── بطاقة قاعدة بيانات المنشأة السحابية ──
        Me.cardConnection = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitleConnection = New System.Windows.Forms.Label()
        Me.lblCompanyInfo = New System.Windows.Forms.Label()
        Me.lblTursoUrlLabel = New System.Windows.Forms.Label()
        Me.txtTursoUrl = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblAuthTokenLabel = New System.Windows.Forms.Label()
        Me.txtAuthToken = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnToggleTokenVisibility = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTestConnection = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSyncFromLicense = New Guna.UI2.WinForms.Guna2Button()
        Me.lblConnectionResult = New System.Windows.Forms.Label()

        ' ── بطاقة خيارات المزامنة ──
        Me.cardSyncConfig = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitleConfig = New System.Windows.Forms.Label()
        Me.toggleSyncEnabled = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.lblToggleSyncEnabled = New System.Windows.Forms.Label()
        Me.lblSyncIntervalLabel = New System.Windows.Forms.Label()
        Me.txtSyncInterval = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblSyncIntervalHint = New System.Windows.Forms.Label()

        ' ── بطاقة تفاصيل المنصة (مخفية) ──
        Me.cardPlatform = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitlePlatform = New System.Windows.Forms.Label()
        Me.lblPlatformHint = New System.Windows.Forms.Label()
        Me.lblPlatformTokenLabel = New System.Windows.Forms.Label()
        Me.txtPlatformToken = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblOrgSlugLabel = New System.Windows.Forms.Label()
        Me.txtOrgSlug = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblDbNameLabel = New System.Windows.Forms.Label()
        Me.txtDbName = New Guna.UI2.WinForms.Guna2TextBox()

        ' ── بطاقة سجل المزامنة ──
        Me.cardSyncLog = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitleLog = New System.Windows.Forms.Label()
        Me.dgvSyncLog = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.btnClearLog = New Guna.UI2.WinForms.Guna2Button()

        ' ── شريط الإجراءات ──
        Me.pnlActions = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
        Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()

        Me.pnlMain.SuspendLayout()
        Me.cardSyncStatus.SuspendLayout()
        Me.pnlStatusRow.SuspendLayout()
        Me.cardDevices.SuspendLayout()
        CType(Me.dgvDevices, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlMain.Size = New System.Drawing.Size(1000, 1400)
        Me.pnlMain.TabIndex = 0

        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(235, 235, 240)
        Me.lblTitle.Location = New System.Drawing.Point(30, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(940, 45)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "المزامنة السحابية (Cloud Synchronization)"

        '
        'lblSubtitle
        '
        Me.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180)
        Me.lblSubtitle.Location = New System.Drawing.Point(30, 65)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(940, 35)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "إدارة المزامنة اللحظية ومراقبة حالة الاتصال مع السحابة وأجهزة المنشأة"

        '
        'cardSyncStatus
        '
        Me.cardSyncStatus.BackColor = System.Drawing.Color.Transparent
        Me.cardSyncStatus.BorderColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.cardSyncStatus.BorderRadius = 12
        Me.cardSyncStatus.BorderThickness = 1
        Me.cardSyncStatus.Controls.Add(Me.lblSyncProgressText)
        Me.cardSyncStatus.Controls.Add(Me.prgSyncProgress)
        Me.cardSyncStatus.Controls.Add(Me.btnRefreshStatus)
        Me.cardSyncStatus.Controls.Add(Me.btnSyncNow)
        Me.cardSyncStatus.Controls.Add(Me.pnlStatusRow)
        Me.cardSyncStatus.Controls.Add(Me.lblCardTitleStatus)
        Me.cardSyncStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardSyncStatus.FillColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.cardSyncStatus.Location = New System.Drawing.Point(30, 100)
        Me.cardSyncStatus.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardSyncStatus.Name = "cardSyncStatus"
        Me.cardSyncStatus.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardSyncStatus.Size = New System.Drawing.Size(940, 195)
        Me.cardSyncStatus.TabIndex = 2

        '
        'lblCardTitleStatus
        '
        Me.lblCardTitleStatus.AutoSize = True
        Me.lblCardTitleStatus.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleStatus.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleStatus.Location = New System.Drawing.Point(700, 15)
        Me.lblCardTitleStatus.Name = "lblCardTitleStatus"
        Me.lblCardTitleStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleStatus.Size = New System.Drawing.Size(220, 25)
        Me.lblCardTitleStatus.TabIndex = 0
        Me.lblCardTitleStatus.Text = "📊 حالة المزامنة اللحظية"

        '
        'pnlStatusRow
        '
        Me.pnlStatusRow.BackColor = System.Drawing.Color.FromArgb(17, 24, 39)
        Me.pnlStatusRow.Controls.Add(Me.lblSyncStatusLabel)
        Me.pnlStatusRow.Controls.Add(Me.lblSyncStatus)
        Me.pnlStatusRow.Controls.Add(Me.lblLastSyncLabel)
        Me.pnlStatusRow.Controls.Add(Me.lblLastSyncTime)
        Me.pnlStatusRow.Controls.Add(Me.lblPendingLabel)
        Me.pnlStatusRow.Controls.Add(Me.lblPendingChanges)
        Me.pnlStatusRow.Location = New System.Drawing.Point(20, 50)
        Me.pnlStatusRow.Name = "pnlStatusRow"
        Me.pnlStatusRow.Padding = New System.Windows.Forms.Padding(12, 10, 12, 10)
        Me.pnlStatusRow.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlStatusRow.Size = New System.Drawing.Size(900, 52)
        Me.pnlStatusRow.TabIndex = 1

        '
        'lblSyncStatusLabel
        '
        Me.lblSyncStatusLabel.AutoSize = True
        Me.lblSyncStatusLabel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblSyncStatusLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblSyncStatusLabel.Location = New System.Drawing.Point(840, 6)
        Me.lblSyncStatusLabel.Margin = New System.Windows.Forms.Padding(4, 6, 2, 0)
        Me.lblSyncStatusLabel.Name = "lblSyncStatusLabel"
        Me.lblSyncStatusLabel.Size = New System.Drawing.Size(48, 20)
        Me.lblSyncStatusLabel.TabIndex = 0
        Me.lblSyncStatusLabel.Text = "الحالة:"

        '
        'lblSyncStatus
        '
        Me.lblSyncStatus.AutoSize = True
        Me.lblSyncStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSyncStatus.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129)
        Me.lblSyncStatus.Location = New System.Drawing.Point(740, 5)
        Me.lblSyncStatus.Margin = New System.Windows.Forms.Padding(2, 5, 25, 0)
        Me.lblSyncStatus.Name = "lblSyncStatus"
        Me.lblSyncStatus.Size = New System.Drawing.Size(71, 21)
        Me.lblSyncStatus.TabIndex = 1
        Me.lblSyncStatus.Text = "مفعّل وجاهز"

        '
        'lblLastSyncLabel
        '
        Me.lblLastSyncLabel.AutoSize = True
        Me.lblLastSyncLabel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastSyncLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblLastSyncLabel.Location = New System.Drawing.Point(645, 6)
        Me.lblLastSyncLabel.Margin = New System.Windows.Forms.Padding(4, 6, 2, 0)
        Me.lblLastSyncLabel.Name = "lblLastSyncLabel"
        Me.lblLastSyncLabel.Size = New System.Drawing.Size(80, 20)
        Me.lblLastSyncLabel.TabIndex = 2
        Me.lblLastSyncLabel.Text = "آخر مزامنة:"

        '
        'lblLastSyncTime
        '
        Me.lblLastSyncTime.AutoSize = True
        Me.lblLastSyncTime.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblLastSyncTime.ForeColor = System.Drawing.Color.White
        Me.lblLastSyncTime.Location = New System.Drawing.Point(540, 5)
        Me.lblLastSyncTime.Margin = New System.Windows.Forms.Padding(2, 5, 25, 0)
        Me.lblLastSyncTime.Name = "lblLastSyncTime"
        Me.lblLastSyncTime.Size = New System.Drawing.Size(65, 21)
        Me.lblLastSyncTime.TabIndex = 3
        Me.lblLastSyncTime.Text = "لم تتم بعد"

        '
        'lblPendingLabel
        '
        Me.lblPendingLabel.AutoSize = True
        Me.lblPendingLabel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblPendingLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblPendingLabel.Location = New System.Drawing.Point(415, 6)
        Me.lblPendingLabel.Margin = New System.Windows.Forms.Padding(4, 6, 2, 0)
        Me.lblPendingLabel.Name = "lblPendingLabel"
        Me.lblPendingLabel.Size = New System.Drawing.Size(107, 20)
        Me.lblPendingLabel.TabIndex = 4
        Me.lblPendingLabel.Text = "تغييرات معلقة:"

        '
        'lblPendingChanges
        '
        Me.lblPendingChanges.AutoSize = True
        Me.lblPendingChanges.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblPendingChanges.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11)
        Me.lblPendingChanges.Location = New System.Drawing.Point(365, 4)
        Me.lblPendingChanges.Margin = New System.Windows.Forms.Padding(2, 4, 15, 0)
        Me.lblPendingChanges.Name = "lblPendingChanges"
        Me.lblPendingChanges.Size = New System.Drawing.Size(22, 25)
        Me.lblPendingChanges.TabIndex = 5
        Me.lblPendingChanges.Text = "0"

        '
        'btnSyncNow
        '
        Me.btnSyncNow.BorderRadius = 10
        Me.btnSyncNow.FillColor = System.Drawing.Color.FromArgb(16, 185, 129)
        Me.btnSyncNow.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSyncNow.ForeColor = System.Drawing.Color.White
        Me.btnSyncNow.HoverState.FillColor = System.Drawing.Color.FromArgb(5, 150, 105)
        Me.btnSyncNow.Location = New System.Drawing.Point(710, 115)
        Me.btnSyncNow.Name = "btnSyncNow"
        Me.btnSyncNow.Size = New System.Drawing.Size(210, 44)
        Me.btnSyncNow.TabIndex = 2
        Me.btnSyncNow.Text = "🔄 مزامنة السحابة الآن"

        '
        'btnRefreshStatus
        '
        Me.btnRefreshStatus.BorderRadius = 10
        Me.btnRefreshStatus.FillColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.btnRefreshStatus.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshStatus.ForeColor = System.Drawing.Color.White
        Me.btnRefreshStatus.HoverState.FillColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnRefreshStatus.Location = New System.Drawing.Point(555, 115)
        Me.btnRefreshStatus.Name = "btnRefreshStatus"
        Me.btnRefreshStatus.Size = New System.Drawing.Size(145, 44)
        Me.btnRefreshStatus.TabIndex = 3
        Me.btnRefreshStatus.Text = "↻ تحديث الحالة"

        '
        'lblSyncProgressText
        '
        Me.lblSyncProgressText.AutoSize = True
        Me.lblSyncProgressText.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSyncProgressText.ForeColor = System.Drawing.Color.FromArgb(56, 189, 248)
        Me.lblSyncProgressText.Location = New System.Drawing.Point(20, 120)
        Me.lblSyncProgressText.Name = "lblSyncProgressText"
        Me.lblSyncProgressText.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSyncProgressText.Size = New System.Drawing.Size(0, 17)
        Me.lblSyncProgressText.TabIndex = 6
        Me.lblSyncProgressText.Visible = False

        '
        'prgSyncProgress
        '
        Me.prgSyncProgress.BorderRadius = 5
        Me.prgSyncProgress.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.prgSyncProgress.Location = New System.Drawing.Point(20, 168)
        Me.prgSyncProgress.Name = "prgSyncProgress"
        Me.prgSyncProgress.ProgressColor = System.Drawing.Color.FromArgb(16, 185, 129)
        Me.prgSyncProgress.ProgressColor2 = System.Drawing.Color.FromArgb(56, 189, 248)
        Me.prgSyncProgress.Size = New System.Drawing.Size(900, 10)
        Me.prgSyncProgress.TabIndex = 7
        Me.prgSyncProgress.Visible = False

        '
        'cardDevices
        '
        Me.cardDevices.BackColor = System.Drawing.Color.Transparent
        Me.cardDevices.BorderColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.cardDevices.BorderRadius = 12
        Me.cardDevices.BorderThickness = 1
        Me.cardDevices.Controls.Add(Me.dgvDevices)
        Me.cardDevices.Controls.Add(Me.btnRefreshDevices)
        Me.cardDevices.Controls.Add(Me.lblDevicesCount)
        Me.cardDevices.Controls.Add(Me.lblDevicesHint)
        Me.cardDevices.Controls.Add(Me.lblCardTitleDevices)
        Me.cardDevices.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardDevices.FillColor = System.Drawing.Color.FromArgb(24, 26, 33)
        Me.cardDevices.Location = New System.Drawing.Point(30, 310)
        Me.cardDevices.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardDevices.Name = "cardDevices"
        Me.cardDevices.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardDevices.Size = New System.Drawing.Size(940, 310)
        Me.cardDevices.TabIndex = 3

        '
        'lblCardTitleDevices
        '
        Me.lblCardTitleDevices.AutoSize = True
        Me.lblCardTitleDevices.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleDevices.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleDevices.Location = New System.Drawing.Point(460, 15)
        Me.lblCardTitleDevices.Name = "lblCardTitleDevices"
        Me.lblCardTitleDevices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleDevices.Size = New System.Drawing.Size(460, 25)
        Me.lblCardTitleDevices.TabIndex = 0
        Me.lblCardTitleDevices.Text = "🖥️ أجهزة المنشأة المتزامنة (Company Synced Devices)"

        '
        'lblDevicesHint
        '
        Me.lblDevicesHint.AutoSize = True
        Me.lblDevicesHint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblDevicesHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDevicesHint.Location = New System.Drawing.Point(360, 42)
        Me.lblDevicesHint.Name = "lblDevicesHint"
        Me.lblDevicesHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDevicesHint.Size = New System.Drawing.Size(560, 17)
        Me.lblDevicesHint.TabIndex = 1
        Me.lblDevicesHint.Text = "مراقبة كافة أجهزة الكاشير والويتر التابعة لنفس الشركة وموعد آخر مزامنة تم تسجيلها لكل جهاز"

        '
        'lblDevicesCount
        '
        Me.lblDevicesCount.AutoSize = True
        Me.lblDevicesCount.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblDevicesCount.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129)
        Me.lblDevicesCount.Location = New System.Drawing.Point(20, 18)
        Me.lblDevicesCount.Name = "lblDevicesCount"
        Me.lblDevicesCount.Size = New System.Drawing.Size(110, 19)
        Me.lblDevicesCount.TabIndex = 2
        Me.lblDevicesCount.Text = "1 أجهزة مسجلة"

        '
        'btnRefreshDevices
        '
        Me.btnRefreshDevices.BorderRadius = 8
        Me.btnRefreshDevices.FillColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.btnRefreshDevices.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshDevices.ForeColor = System.Drawing.Color.White
        Me.btnRefreshDevices.HoverState.FillColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnRefreshDevices.Location = New System.Drawing.Point(145, 12)
        Me.btnRefreshDevices.Name = "btnRefreshDevices"
        Me.btnRefreshDevices.Size = New System.Drawing.Size(130, 36)
        Me.btnRefreshDevices.TabIndex = 3
        Me.btnRefreshDevices.Text = "🔄 تحديث الأجهزة"

        '
        'dgvDevices
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.dgvDevices.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDevices.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True
        Me.dgvDevices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDevices.ColumnHeadersHeight = 36
        Me.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85)
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False
        Me.dgvDevices.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDevices.GridColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.dgvDevices.Location = New System.Drawing.Point(20, 70)
        Me.dgvDevices.Name = "dgvDevices"
        Me.dgvDevices.ReadOnly = True
        Me.dgvDevices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvDevices.RowHeadersVisible = False
        Me.dgvDevices.Size = New System.Drawing.Size(900, 225)
        Me.dgvDevices.TabIndex = 4
        Me.dgvDevices.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.dgvDevices.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.dgvDevices.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.dgvDevices.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.dgvDevices.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.dgvDevices.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvDevices.ThemeStyle.HeaderStyle.Height = 36
        Me.dgvDevices.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.dgvDevices.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dgvDevices.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvDevices.ThemeStyle.RowsStyle.Height = 32
        Me.dgvDevices.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85)

        '
        'cardConnection
        '
        Me.cardConnection.BackColor = System.Drawing.Color.Transparent
        Me.cardConnection.BorderColor = System.Drawing.Color.FromArgb(45, 48, 58)
        Me.cardConnection.BorderRadius = 12
        Me.cardConnection.BorderThickness = 1
        Me.cardConnection.Controls.Add(Me.lblCompanyInfo)
        Me.cardConnection.Controls.Add(Me.btnSyncFromLicense)
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
        Me.cardConnection.Location = New System.Drawing.Point(30, 635)
        Me.cardConnection.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardConnection.Name = "cardConnection"
        Me.cardConnection.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardConnection.Size = New System.Drawing.Size(940, 150)
        Me.cardConnection.TabIndex = 4

        '
        'lblCardTitleConnection
        '
        Me.lblCardTitleConnection.AutoSize = True
        Me.lblCardTitleConnection.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleConnection.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleConnection.Location = New System.Drawing.Point(460, 15)
        Me.lblCardTitleConnection.Name = "lblCardTitleConnection"
        Me.lblCardTitleConnection.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleConnection.Size = New System.Drawing.Size(460, 25)
        Me.lblCardTitleConnection.TabIndex = 0
        Me.lblCardTitleConnection.Text = "🏢 قاعدة البيانات السحابية للمنشأة (Online Database)"

        '
        'lblTursoUrlLabel
        '
        Me.lblTursoUrlLabel.AutoSize = True
        Me.lblTursoUrlLabel.Location = New System.Drawing.Point(670, 70)
        Me.lblTursoUrlLabel.Name = "lblTursoUrlLabel"
        Me.lblTursoUrlLabel.Size = New System.Drawing.Size(100, 20)
        Me.lblTursoUrlLabel.Visible = False

        '
        'txtTursoUrl
        '
        Me.txtTursoUrl.Location = New System.Drawing.Point(150, 60)
        Me.txtTursoUrl.Name = "txtTursoUrl"
        Me.txtTursoUrl.Size = New System.Drawing.Size(500, 36)
        Me.txtTursoUrl.Visible = False

        '
        'lblAuthTokenLabel
        '
        Me.lblAuthTokenLabel.AutoSize = True
        Me.lblAuthTokenLabel.Location = New System.Drawing.Point(670, 120)
        Me.lblAuthTokenLabel.Name = "lblAuthTokenLabel"
        Me.lblAuthTokenLabel.Size = New System.Drawing.Size(100, 20)
        Me.lblAuthTokenLabel.Visible = False

        '
        'txtAuthToken
        '
        Me.txtAuthToken.Location = New System.Drawing.Point(200, 115)
        Me.txtAuthToken.Name = "txtAuthToken"
        Me.txtAuthToken.Size = New System.Drawing.Size(450, 36)
        Me.txtAuthToken.Visible = False

        '
        'btnToggleTokenVisibility
        '
        Me.btnToggleTokenVisibility.Location = New System.Drawing.Point(150, 115)
        Me.btnToggleTokenVisibility.Name = "btnToggleTokenVisibility"
        Me.btnToggleTokenVisibility.Size = New System.Drawing.Size(42, 36)
        Me.btnToggleTokenVisibility.Visible = False

        '
        'btnTestConnection
        '
        Me.btnTestConnection.BorderRadius = 10
        Me.btnTestConnection.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnTestConnection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnTestConnection.ForeColor = System.Drawing.Color.White
        Me.btnTestConnection.HoverState.FillColor = System.Drawing.Color.FromArgb(29, 78, 216)
        Me.btnTestConnection.Location = New System.Drawing.Point(20, 50)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(160, 42)
        Me.btnTestConnection.TabIndex = 6
        Me.btnTestConnection.Text = "⚡ فحص الاتصال"

        '
        'lblCompanyInfo
        '
        Me.lblCompanyInfo.AutoSize = True
        Me.lblCompanyInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyInfo.ForeColor = System.Drawing.Color.FromArgb(56, 189, 248)
        Me.lblCompanyInfo.Location = New System.Drawing.Point(360, 48)
        Me.lblCompanyInfo.Name = "lblCompanyInfo"
        Me.lblCompanyInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCompanyInfo.Size = New System.Drawing.Size(550, 21)
        Me.lblCompanyInfo.TabIndex = 8
        Me.lblCompanyInfo.Text = "المنشأة: جاري التحقق من الترخيص..."

        '
        'btnSyncFromLicense
        '
        Me.btnSyncFromLicense.BorderRadius = 10
        Me.btnSyncFromLicense.FillColor = System.Drawing.Color.FromArgb(13, 148, 136)
        Me.btnSyncFromLicense.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSyncFromLicense.ForeColor = System.Drawing.Color.White
        Me.btnSyncFromLicense.HoverState.FillColor = System.Drawing.Color.FromArgb(15, 118, 110)
        Me.btnSyncFromLicense.Location = New System.Drawing.Point(190, 50)
        Me.btnSyncFromLicense.Name = "btnSyncFromLicense"
        Me.btnSyncFromLicense.Size = New System.Drawing.Size(160, 42)
        Me.btnSyncFromLicense.TabIndex = 9
        Me.btnSyncFromLicense.Text = "🔄 ربط بالترخيص"
        Me.btnSyncFromLicense.Visible = True

        '
        'lblConnectionResult
        '
        Me.lblConnectionResult.AutoSize = True
        Me.lblConnectionResult.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblConnectionResult.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128)
        Me.lblConnectionResult.Location = New System.Drawing.Point(360, 85)
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
        Me.cardSyncConfig.Location = New System.Drawing.Point(30, 800)
        Me.cardSyncConfig.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardSyncConfig.Name = "cardSyncConfig"
        Me.cardSyncConfig.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardSyncConfig.Size = New System.Drawing.Size(940, 150)
        Me.cardSyncConfig.TabIndex = 5

        '
        'lblCardTitleConfig
        '
        Me.lblCardTitleConfig.AutoSize = True
        Me.lblCardTitleConfig.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleConfig.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleConfig.Location = New System.Drawing.Point(550, 15)
        Me.lblCardTitleConfig.Name = "lblCardTitleConfig"
        Me.lblCardTitleConfig.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleConfig.Size = New System.Drawing.Size(370, 25)
        Me.lblCardTitleConfig.TabIndex = 0
        Me.lblCardTitleConfig.Text = "⚙️ خيارات وإعدادات المزامنة التلقائية"

        '
        'toggleSyncEnabled
        '
        Me.toggleSyncEnabled.CheckedState.BorderColor = System.Drawing.Color.FromArgb(16, 185, 129)
        Me.toggleSyncEnabled.CheckedState.FillColor = System.Drawing.Color.FromArgb(16, 185, 129)
        Me.toggleSyncEnabled.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.toggleSyncEnabled.CheckedState.InnerColor = System.Drawing.Color.White
        Me.toggleSyncEnabled.Location = New System.Drawing.Point(860, 50)
        Me.toggleSyncEnabled.Name = "toggleSyncEnabled"
        Me.toggleSyncEnabled.Size = New System.Drawing.Size(50, 24)
        Me.toggleSyncEnabled.TabIndex = 1
        Me.toggleSyncEnabled.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149)
        Me.toggleSyncEnabled.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149)

        '
        'lblToggleSyncEnabled
        '
        Me.lblToggleSyncEnabled.AutoSize = True
        Me.lblToggleSyncEnabled.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblToggleSyncEnabled.ForeColor = System.Drawing.Color.White
        Me.lblToggleSyncEnabled.Location = New System.Drawing.Point(580, 50)
        Me.lblToggleSyncEnabled.Name = "lblToggleSyncEnabled"
        Me.lblToggleSyncEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblToggleSyncEnabled.Size = New System.Drawing.Size(260, 21)
        Me.lblToggleSyncEnabled.TabIndex = 2
        Me.lblToggleSyncEnabled.Text = "المزامنة التلقائية بالخلفية دون تعطيل الكاشير"

        '
        'lblSyncIntervalLabel
        '
        Me.lblSyncIntervalLabel.AutoSize = True
        Me.lblSyncIntervalLabel.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblSyncIntervalLabel.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.lblSyncIntervalLabel.Location = New System.Drawing.Point(680, 95)
        Me.lblSyncIntervalLabel.Name = "lblSyncIntervalLabel"
        Me.lblSyncIntervalLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSyncIntervalLabel.Size = New System.Drawing.Size(180, 21)
        Me.lblSyncIntervalLabel.TabIndex = 3
        Me.lblSyncIntervalLabel.Text = "الفاصل الزمني للمزامنة:"

        '
        'txtSyncInterval
        '
        Me.txtSyncInterval.BorderRadius = 8
        Me.txtSyncInterval.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSyncInterval.DefaultText = "30"
        Me.txtSyncInterval.FillColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtSyncInterval.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSyncInterval.ForeColor = System.Drawing.Color.White
        Me.txtSyncInterval.Location = New System.Drawing.Point(580, 88)
        Me.txtSyncInterval.Name = "txtSyncInterval"
        Me.txtSyncInterval.Size = New System.Drawing.Size(85, 36)
        Me.txtSyncInterval.TabIndex = 4
        Me.txtSyncInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center

        '
        'lblSyncIntervalHint
        '
        Me.lblSyncIntervalHint.AutoSize = True
        Me.lblSyncIntervalHint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblSyncIntervalHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblSyncIntervalHint.Location = New System.Drawing.Point(260, 96)
        Me.lblSyncIntervalHint.Name = "lblSyncIntervalHint"
        Me.lblSyncIntervalHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSyncIntervalHint.Size = New System.Drawing.Size(280, 17)
        Me.lblSyncIntervalHint.TabIndex = 5
        Me.lblSyncIntervalHint.Text = "ثانية  (القيمة الموصى بها: 30 إلى 60 ثانية)"

        '
        'cardPlatform
        '
        Me.cardPlatform.Location = New System.Drawing.Point(30, 965)
        Me.cardPlatform.Name = "cardPlatform"
        Me.cardPlatform.Size = New System.Drawing.Size(940, 10)
        Me.cardPlatform.Visible = False

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
        Me.cardSyncLog.Location = New System.Drawing.Point(30, 990)
        Me.cardSyncLog.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.cardSyncLog.Name = "cardSyncLog"
        Me.cardSyncLog.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.cardSyncLog.Size = New System.Drawing.Size(940, 360)
        Me.cardSyncLog.TabIndex = 6

        '
        'lblCardTitleLog
        '
        Me.lblCardTitleLog.AutoSize = True
        Me.lblCardTitleLog.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitleLog.ForeColor = System.Drawing.Color.White
        Me.lblCardTitleLog.Location = New System.Drawing.Point(440, 15)
        Me.lblCardTitleLog.Name = "lblCardTitleLog"
        Me.lblCardTitleLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardTitleLog.Size = New System.Drawing.Size(480, 25)
        Me.lblCardTitleLog.TabIndex = 0
        Me.lblCardTitleLog.Text = "📋 سجل حركات المزامنة الحية (Live Sync Log)"

        '
        'btnClearLog
        '
        Me.btnClearLog.BorderRadius = 8
        Me.btnClearLog.FillColor = System.Drawing.Color.FromArgb(239, 68, 68)
        Me.btnClearLog.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnClearLog.ForeColor = System.Drawing.Color.White
        Me.btnClearLog.HoverState.FillColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnClearLog.Location = New System.Drawing.Point(20, 12)
        Me.btnClearLog.Name = "btnClearLog"
        Me.btnClearLog.Size = New System.Drawing.Size(140, 38)
        Me.btnClearLog.TabIndex = 1
        Me.btnClearLog.Text = "🗑️ مسح السجل"

        '
        'dgvSyncLog
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.dgvSyncLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSyncLog.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True
        Me.dgvSyncLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSyncLog.ColumnHeadersHeight = 36
        Me.dgvSyncLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85)
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False
        Me.dgvSyncLog.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSyncLog.GridColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.dgvSyncLog.Location = New System.Drawing.Point(20, 58)
        Me.dgvSyncLog.Name = "dgvSyncLog"
        Me.dgvSyncLog.ReadOnly = True
        Me.dgvSyncLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvSyncLog.RowHeadersVisible = False
        Me.dgvSyncLog.Size = New System.Drawing.Size(900, 280)
        Me.dgvSyncLog.TabIndex = 2
        Me.dgvSyncLog.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.dgvSyncLog.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.dgvSyncLog.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvSyncLog.ThemeStyle.HeaderStyle.Height = 36
        Me.dgvSyncLog.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.dgvSyncLog.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dgvSyncLog.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvSyncLog.ThemeStyle.RowsStyle.Height = 32
        Me.dgvSyncLog.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85)

        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.Transparent
        Me.pnlActions.Controls.Add(Me.btnClose)
        Me.pnlActions.Controls.Add(Me.btnReset)
        Me.pnlActions.Controls.Add(Me.btnSave)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActions.Location = New System.Drawing.Point(30, 1365)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(940, 70)
        Me.pnlActions.TabIndex = 7

        '
        'btnSave
        '
        Me.btnSave.BorderRadius = 10
        Me.btnSave.FillColor = System.Drawing.Color.FromArgb(13, 148, 136)
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(15, 118, 110)
        Me.btnSave.Location = New System.Drawing.Point(740, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(180, 46)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "💾 حفظ الإعدادات"

        '
        'btnReset
        '
        Me.btnReset.BorderRadius = 10
        Me.btnReset.FillColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.HoverState.FillColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnReset.Location = New System.Drawing.Point(585, 12)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(145, 46)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "↺ إعادة ضبط"

        '
        'btnClose
        '
        Me.btnClose.BorderRadius = 10
        Me.btnClose.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.btnClose.Location = New System.Drawing.Point(20, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 46)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "إغلاق"

        '
        'pnlMain Controls Add
        '
        Me.pnlMain.Controls.Add(Me.pnlActions)
        Me.pnlMain.Controls.Add(Me.cardSyncLog)
        Me.pnlMain.Controls.Add(Me.cardSyncConfig)
        Me.pnlMain.Controls.Add(Me.cardConnection)
        Me.pnlMain.Controls.Add(Me.cardDevices)
        Me.pnlMain.Controls.Add(Me.cardSyncStatus)
        Me.pnlMain.Controls.Add(Me.lblSubtitle)
        Me.pnlMain.Controls.Add(Me.lblTitle)

        Me.Controls.Add(Me.pnlMain)
        Me.Name = "UCCloudSyncSettings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(1000, 950)

        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.cardSyncStatus.ResumeLayout(False)
        Me.cardSyncStatus.PerformLayout()
        Me.pnlStatusRow.ResumeLayout(False)
        Me.pnlStatusRow.PerformLayout()
        Me.cardDevices.ResumeLayout(False)
        Me.cardDevices.PerformLayout()
        CType(Me.dgvDevices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardConnection.ResumeLayout(False)
        Me.cardConnection.PerformLayout()
        Me.cardSyncConfig.ResumeLayout(False)
        Me.cardSyncConfig.PerformLayout()
        Me.cardPlatform.ResumeLayout(False)
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
    Friend WithEvents prgSyncProgress As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents lblSyncProgressText As System.Windows.Forms.Label

    Friend WithEvents cardDevices As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardTitleDevices As System.Windows.Forms.Label
    Friend WithEvents lblDevicesHint As System.Windows.Forms.Label
    Friend WithEvents lblDevicesCount As System.Windows.Forms.Label
    Friend WithEvents btnRefreshDevices As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgvDevices As Guna.UI2.WinForms.Guna2DataGridView
    
    Friend WithEvents cardConnection As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardTitleConnection As System.Windows.Forms.Label
    Friend WithEvents lblTursoUrlLabel As System.Windows.Forms.Label
    Friend WithEvents txtTursoUrl As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblAuthTokenLabel As System.Windows.Forms.Label
    Friend WithEvents txtAuthToken As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnToggleTokenVisibility As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTestConnection As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSyncFromLicense As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblCompanyInfo As System.Windows.Forms.Label
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
