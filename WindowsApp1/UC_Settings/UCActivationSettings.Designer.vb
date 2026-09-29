Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCActivationSettings
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
            Me.cardHero = New Guna.UI2.WinForms.Guna2Panel()
            Me.pnlStatusBadge = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.lblHeroCompany = New System.Windows.Forms.Label()
            Me.lblHeroPlan = New System.Windows.Forms.Label()
            Me.lblHeroExpiry = New System.Windows.Forms.Label()
            Me.lblHeroGrace = New System.Windows.Forms.Label()
            Me.cardStatus = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardStatusTitle = New System.Windows.Forms.Label()
            Me.lblSerialHeader = New System.Windows.Forms.Label()
            Me.pnlSerialBox = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnCopySerial = New Guna.UI2.WinForms.Guna2Button()
            Me.lblSerial = New System.Windows.Forms.Label()
            Me.lblStartDateHeader = New System.Windows.Forms.Label()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.lblExpiryDateHeader = New System.Windows.Forms.Label()
            Me.lblExpiryDate = New System.Windows.Forms.Label()
            Me.lblGracePeriodHeader = New System.Windows.Forms.Label()
            Me.lblGracePeriod = New System.Windows.Forms.Label()
            Me.lblPlanHeader = New System.Windows.Forms.Label()
            Me.lblPlanName = New System.Windows.Forms.Label()
            Me.lblChannelHeader = New System.Windows.Forms.Label()
            Me.lblChannel = New System.Windows.Forms.Label()
            Me.lblPriceHeader = New System.Windows.Forms.Label()
            Me.lblPrice = New System.Windows.Forms.Label()
            Me.lblLastSyncHeader = New System.Windows.Forms.Label()
            Me.lblLastSync = New System.Windows.Forms.Label()
            Me.cardPlan = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardPlanTitle = New System.Windows.Forms.Label()
            Me.lblCompanyHeader = New System.Windows.Forms.Label()
            Me.lblCompanyName = New System.Windows.Forms.Label()
            Me.lblCompanyIdHeader = New System.Windows.Forms.Label()
            Me.pnlCompanyIdBox = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnCopyCompanyId = New Guna.UI2.WinForms.Guna2Button()
            Me.lblCompanyId = New System.Windows.Forms.Label()
            Me.lblHWIDHeader = New System.Windows.Forms.Label()
            Me.pnlHwidBox = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnCopyHWID = New Guna.UI2.WinForms.Guna2Button()
            Me.lblHWID = New System.Windows.Forms.Label()
            Me.lblMaxDevicesHeader = New System.Windows.Forms.Label()
            Me.lblMaxDevices = New System.Windows.Forms.Label()
            Me.lblMaxUsersHeader = New System.Windows.Forms.Label()
            Me.lblMaxUsers = New System.Windows.Forms.Label()
            Me.lblDeviceStatusHeader = New System.Windows.Forms.Label()
            Me.pnlDeviceStatusBox = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblDeviceStatus = New System.Windows.Forms.Label()
            Me.pnlBottomBar = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
            Me.btnChangeSerial = New Guna.UI2.WinForms.Guna2Button()
            Me.btnCheckUpdate = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardHero.SuspendLayout()
            Me.pnlStatusBadge.SuspendLayout()
            Me.cardStatus.SuspendLayout()
            Me.pnlSerialBox.SuspendLayout()
            Me.cardPlan.SuspendLayout()
            Me.pnlCompanyIdBox.SuspendLayout()
            Me.pnlHwidBox.SuspendLayout()
            Me.pnlDeviceStatusBox.SuspendLayout()
            Me.pnlBottomBar.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardHero)
            Me.pnlMain.Controls.Add(Me.cardStatus)
            Me.pnlMain.Controls.Add(Me.cardPlan)
            Me.pnlMain.Controls.Add(Me.pnlBottomBar)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 785)
            Me.pnlMain.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(660, 16)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(558, 35)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "إدارة التفعيل والترخيص السحابي"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(400, 52)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(818, 24)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "متابعة حالة الاشتراك السحابي، تفاصيل الخطة، وصلاحية بصمة هذا الجهاز ومزامنة المست" &
    "خدمين"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardHero
            '
            Me.cardHero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardHero.BackColor = System.Drawing.Color.Transparent
            Me.cardHero.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardHero.BorderRadius = 12
            Me.cardHero.BorderThickness = 1
            Me.cardHero.Controls.Add(Me.pnlStatusBadge)
            Me.cardHero.Controls.Add(Me.lblHeroCompany)
            Me.cardHero.Controls.Add(Me.lblHeroPlan)
            Me.cardHero.Controls.Add(Me.lblHeroExpiry)
            Me.cardHero.Controls.Add(Me.lblHeroGrace)
            Me.cardHero.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cardHero.Location = New System.Drawing.Point(20, 85)
            Me.cardHero.Name = "cardHero"
            Me.cardHero.Size = New System.Drawing.Size(1198, 88)
            Me.cardHero.TabIndex = 1
            '
            'pnlStatusBadge
            '
            Me.pnlStatusBadge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlStatusBadge.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.pnlStatusBadge.BorderRadius = 10
            Me.pnlStatusBadge.BorderThickness = 1
            Me.pnlStatusBadge.Controls.Add(Me.lblStatus)
            Me.pnlStatusBadge.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.pnlStatusBadge.Location = New System.Drawing.Point(928, 18)
            Me.pnlStatusBadge.Name = "pnlStatusBadge"
            Me.pnlStatusBadge.Size = New System.Drawing.Size(250, 52)
            Me.pnlStatusBadge.TabIndex = 0
            '
            'lblStatus
            '
            Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
            Me.lblStatus.Location = New System.Drawing.Point(0, 0)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(250, 52)
            Me.lblStatus.TabIndex = 0
            Me.lblStatus.Text = "● الترخيص نشط ومصرّح به"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblHeroCompany
            '
            Me.lblHeroCompany.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblHeroCompany.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblHeroCompany.ForeColor = System.Drawing.Color.White
            Me.lblHeroCompany.Location = New System.Drawing.Point(480, 18)
            Me.lblHeroCompany.Name = "lblHeroCompany"
            Me.lblHeroCompany.Size = New System.Drawing.Size(430, 26)
            Me.lblHeroCompany.TabIndex = 1
            Me.lblHeroCompany.Text = "الشركة المرخصة: -"
            Me.lblHeroCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblHeroPlan
            '
            Me.lblHeroPlan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblHeroPlan.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblHeroPlan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(253, Byte), Integer))
            Me.lblHeroPlan.Location = New System.Drawing.Point(480, 48)
            Me.lblHeroPlan.Name = "lblHeroPlan"
            Me.lblHeroPlan.Size = New System.Drawing.Size(430, 22)
            Me.lblHeroPlan.TabIndex = 2
            Me.lblHeroPlan.Text = "الخطة: BASIC  |  قناة عامة مستقرة (PUBLIC)"
            Me.lblHeroPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblHeroExpiry
            '
            Me.lblHeroExpiry.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblHeroExpiry.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblHeroExpiry.Location = New System.Drawing.Point(20, 18)
            Me.lblHeroExpiry.Name = "lblHeroExpiry"
            Me.lblHeroExpiry.Size = New System.Drawing.Size(440, 26)
            Me.lblHeroExpiry.TabIndex = 3
            Me.lblHeroExpiry.Text = "تاريخ الانتهاء: -"
            Me.lblHeroExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblHeroGrace
            '
            Me.lblHeroGrace.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblHeroGrace.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.lblHeroGrace.Location = New System.Drawing.Point(20, 48)
            Me.lblHeroGrace.Name = "lblHeroGrace"
            Me.lblHeroGrace.Size = New System.Drawing.Size(440, 22)
            Me.lblHeroGrace.TabIndex = 4
            Me.lblHeroGrace.Text = "فترة السماح: -"
            Me.lblHeroGrace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardStatus
            '
            Me.cardStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardStatus.BackColor = System.Drawing.Color.Transparent
            Me.cardStatus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardStatus.BorderRadius = 12
            Me.cardStatus.BorderThickness = 1
            Me.cardStatus.Controls.Add(Me.lblCardStatusTitle)
            Me.cardStatus.Controls.Add(Me.lblSerialHeader)
            Me.cardStatus.Controls.Add(Me.pnlSerialBox)
            Me.cardStatus.Controls.Add(Me.lblStartDateHeader)
            Me.cardStatus.Controls.Add(Me.lblStartDate)
            Me.cardStatus.Controls.Add(Me.lblExpiryDateHeader)
            Me.cardStatus.Controls.Add(Me.lblExpiryDate)
            Me.cardStatus.Controls.Add(Me.lblGracePeriodHeader)
            Me.cardStatus.Controls.Add(Me.lblGracePeriod)
            Me.cardStatus.Controls.Add(Me.lblPlanHeader)
            Me.cardStatus.Controls.Add(Me.lblPlanName)
            Me.cardStatus.Controls.Add(Me.lblChannelHeader)
            Me.cardStatus.Controls.Add(Me.lblChannel)
            Me.cardStatus.Controls.Add(Me.lblPriceHeader)
            Me.cardStatus.Controls.Add(Me.lblPrice)
            Me.cardStatus.Controls.Add(Me.lblLastSyncHeader)
            Me.cardStatus.Controls.Add(Me.lblLastSync)
            Me.cardStatus.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardStatus.Location = New System.Drawing.Point(628, 185)
            Me.cardStatus.Name = "cardStatus"
            Me.cardStatus.Size = New System.Drawing.Size(590, 485)
            Me.cardStatus.TabIndex = 2
            '
            'lblCardStatusTitle
            '
            Me.lblCardStatusTitle.Font = New System.Drawing.Font("Segoe UI", 12.5!, System.Drawing.FontStyle.Bold)
            Me.lblCardStatusTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardStatusTitle.Location = New System.Drawing.Point(20, 16)
            Me.lblCardStatusTitle.Name = "lblCardStatusTitle"
            Me.lblCardStatusTitle.Size = New System.Drawing.Size(550, 26)
            Me.lblCardStatusTitle.TabIndex = 0
            Me.lblCardStatusTitle.Text = "🔑 تفاصيل الترخيص ومفتاح التفعيل"
            Me.lblCardStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSerialHeader
            '
            Me.lblSerialHeader.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblSerialHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSerialHeader.Location = New System.Drawing.Point(20, 54)
            Me.lblSerialHeader.Name = "lblSerialHeader"
            Me.lblSerialHeader.Size = New System.Drawing.Size(550, 20)
            Me.lblSerialHeader.TabIndex = 1
            Me.lblSerialHeader.Text = "مفتاح الترخيص (Serial Key):"
            Me.lblSerialHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlSerialBox
            '
            Me.pnlSerialBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.pnlSerialBox.BorderRadius = 8
            Me.pnlSerialBox.BorderThickness = 1
            Me.pnlSerialBox.Controls.Add(Me.btnCopySerial)
            Me.pnlSerialBox.Controls.Add(Me.lblSerial)
            Me.pnlSerialBox.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(29, Byte), Integer))
            Me.pnlSerialBox.Location = New System.Drawing.Point(20, 78)
            Me.pnlSerialBox.Name = "pnlSerialBox"
            Me.pnlSerialBox.Size = New System.Drawing.Size(550, 46)
            Me.pnlSerialBox.TabIndex = 2
            '
            'btnCopySerial
            '
            Me.btnCopySerial.BorderRadius = 6
            Me.btnCopySerial.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCopySerial.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnCopySerial.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnCopySerial.ForeColor = System.Drawing.Color.White
            Me.btnCopySerial.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnCopySerial.Location = New System.Drawing.Point(8, 7)
            Me.btnCopySerial.Name = "btnCopySerial"
            Me.btnCopySerial.Size = New System.Drawing.Size(84, 32)
            Me.btnCopySerial.TabIndex = 1
            Me.btnCopySerial.Text = "📋 نسخ"
            '
            'lblSerial
            '
            Me.lblSerial.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblSerial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
            Me.lblSerial.Location = New System.Drawing.Point(100, 6)
            Me.lblSerial.Name = "lblSerial"
            Me.lblSerial.Size = New System.Drawing.Size(438, 34)
            Me.lblSerial.TabIndex = 0
            Me.lblSerial.Text = "SSTM-PRO-2026517"
            Me.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStartDateHeader
            '
            Me.lblStartDateHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblStartDateHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblStartDateHeader.Location = New System.Drawing.Point(300, 138)
            Me.lblStartDateHeader.Name = "lblStartDateHeader"
            Me.lblStartDateHeader.Size = New System.Drawing.Size(270, 20)
            Me.lblStartDateHeader.TabIndex = 3
            Me.lblStartDateHeader.Text = "تاريخ التفعيل (البداية):"
            Me.lblStartDateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblStartDate
            '
            Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblStartDate.ForeColor = System.Drawing.Color.White
            Me.lblStartDate.Location = New System.Drawing.Point(300, 160)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(270, 26)
            Me.lblStartDate.TabIndex = 4
            Me.lblStartDate.Text = "-"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblExpiryDateHeader
            '
            Me.lblExpiryDateHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblExpiryDateHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblExpiryDateHeader.Location = New System.Drawing.Point(20, 138)
            Me.lblExpiryDateHeader.Name = "lblExpiryDateHeader"
            Me.lblExpiryDateHeader.Size = New System.Drawing.Size(260, 20)
            Me.lblExpiryDateHeader.TabIndex = 5
            Me.lblExpiryDateHeader.Text = "تاريخ الانتهاء:"
            Me.lblExpiryDateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblExpiryDate
            '
            Me.lblExpiryDate.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblExpiryDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblExpiryDate.Location = New System.Drawing.Point(20, 160)
            Me.lblExpiryDate.Name = "lblExpiryDate"
            Me.lblExpiryDate.Size = New System.Drawing.Size(260, 26)
            Me.lblExpiryDate.TabIndex = 6
            Me.lblExpiryDate.Text = "-"
            Me.lblExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGracePeriodHeader
            '
            Me.lblGracePeriodHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblGracePeriodHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblGracePeriodHeader.Location = New System.Drawing.Point(300, 202)
            Me.lblGracePeriodHeader.Name = "lblGracePeriodHeader"
            Me.lblGracePeriodHeader.Size = New System.Drawing.Size(270, 20)
            Me.lblGracePeriodHeader.TabIndex = 7
            Me.lblGracePeriodHeader.Text = "فترة السماح:"
            Me.lblGracePeriodHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGracePeriod
            '
            Me.lblGracePeriod.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblGracePeriod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.lblGracePeriod.Location = New System.Drawing.Point(300, 224)
            Me.lblGracePeriod.Name = "lblGracePeriod"
            Me.lblGracePeriod.Size = New System.Drawing.Size(270, 26)
            Me.lblGracePeriod.TabIndex = 8
            Me.lblGracePeriod.Text = "3 أيام"
            Me.lblGracePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPlanHeader
            '
            Me.lblPlanHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblPlanHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblPlanHeader.Location = New System.Drawing.Point(20, 202)
            Me.lblPlanHeader.Name = "lblPlanHeader"
            Me.lblPlanHeader.Size = New System.Drawing.Size(260, 20)
            Me.lblPlanHeader.TabIndex = 9
            Me.lblPlanHeader.Text = "نوع الخطة:"
            Me.lblPlanHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPlanName
            '
            Me.lblPlanName.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblPlanName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(248, Byte), Integer))
            Me.lblPlanName.Location = New System.Drawing.Point(20, 224)
            Me.lblPlanName.Name = "lblPlanName"
            Me.lblPlanName.Size = New System.Drawing.Size(260, 26)
            Me.lblPlanName.TabIndex = 10
            Me.lblPlanName.Text = "PRO"
            Me.lblPlanName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblChannelHeader
            '
            Me.lblChannelHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblChannelHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblChannelHeader.Location = New System.Drawing.Point(300, 266)
            Me.lblChannelHeader.Name = "lblChannelHeader"
            Me.lblChannelHeader.Size = New System.Drawing.Size(270, 20)
            Me.lblChannelHeader.TabIndex = 11
            Me.lblChannelHeader.Text = "قناة التحديث:"
            Me.lblChannelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblChannel
            '
            Me.lblChannel.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblChannel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
            Me.lblChannel.Location = New System.Drawing.Point(300, 288)
            Me.lblChannel.Name = "lblChannel"
            Me.lblChannel.Size = New System.Drawing.Size(270, 26)
            Me.lblChannel.TabIndex = 12
            Me.lblChannel.Text = "قناة عامة مستقرة (PUBLIC)"
            Me.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPriceHeader
            '
            Me.lblPriceHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblPriceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblPriceHeader.Location = New System.Drawing.Point(20, 266)
            Me.lblPriceHeader.Name = "lblPriceHeader"
            Me.lblPriceHeader.Size = New System.Drawing.Size(260, 20)
            Me.lblPriceHeader.TabIndex = 13
            Me.lblPriceHeader.Text = "قيمة الاشتراك:"
            Me.lblPriceHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPrice
            '
            Me.lblPrice.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPrice.ForeColor = System.Drawing.Color.White
            Me.lblPrice.Location = New System.Drawing.Point(20, 288)
            Me.lblPrice.Name = "lblPrice"
            Me.lblPrice.Size = New System.Drawing.Size(260, 26)
            Me.lblPrice.TabIndex = 14
            Me.lblPrice.Text = "0.00 ج.م"
            Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLastSyncHeader
            '
            Me.lblLastSyncHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblLastSyncHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblLastSyncHeader.Location = New System.Drawing.Point(20, 332)
            Me.lblLastSyncHeader.Name = "lblLastSyncHeader"
            Me.lblLastSyncHeader.Size = New System.Drawing.Size(550, 20)
            Me.lblLastSyncHeader.TabIndex = 15
            Me.lblLastSyncHeader.Text = "آخر مزامنة واتصال سحابي:"
            Me.lblLastSyncHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLastSync
            '
            Me.lblLastSync.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblLastSync.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
            Me.lblLastSync.Location = New System.Drawing.Point(20, 354)
            Me.lblLastSync.Name = "lblLastSync"
            Me.lblLastSync.Size = New System.Drawing.Size(550, 26)
            Me.lblLastSync.TabIndex = 16
            Me.lblLastSync.Text = "نشط ومحدث لحظياً"
            Me.lblLastSync.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardPlan
            '
            Me.cardPlan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardPlan.BackColor = System.Drawing.Color.Transparent
            Me.cardPlan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardPlan.BorderRadius = 12
            Me.cardPlan.BorderThickness = 1
            Me.cardPlan.Controls.Add(Me.lblCardPlanTitle)
            Me.cardPlan.Controls.Add(Me.lblCompanyHeader)
            Me.cardPlan.Controls.Add(Me.lblCompanyName)
            Me.cardPlan.Controls.Add(Me.lblCompanyIdHeader)
            Me.cardPlan.Controls.Add(Me.pnlCompanyIdBox)
            Me.cardPlan.Controls.Add(Me.lblHWIDHeader)
            Me.cardPlan.Controls.Add(Me.pnlHwidBox)
            Me.cardPlan.Controls.Add(Me.lblMaxDevicesHeader)
            Me.cardPlan.Controls.Add(Me.lblMaxDevices)
            Me.cardPlan.Controls.Add(Me.lblMaxUsersHeader)
            Me.cardPlan.Controls.Add(Me.lblMaxUsers)
            Me.cardPlan.Controls.Add(Me.lblDeviceStatusHeader)
            Me.cardPlan.Controls.Add(Me.pnlDeviceStatusBox)
            Me.cardPlan.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPlan.Location = New System.Drawing.Point(20, 185)
            Me.cardPlan.Name = "cardPlan"
            Me.cardPlan.Size = New System.Drawing.Size(590, 485)
            Me.cardPlan.TabIndex = 3
            '
            'lblCardPlanTitle
            '
            Me.lblCardPlanTitle.Font = New System.Drawing.Font("Segoe UI", 12.5!, System.Drawing.FontStyle.Bold)
            Me.lblCardPlanTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardPlanTitle.Location = New System.Drawing.Point(20, 16)
            Me.lblCardPlanTitle.Name = "lblCardPlanTitle"
            Me.lblCardPlanTitle.Size = New System.Drawing.Size(550, 26)
            Me.lblCardPlanTitle.TabIndex = 0
            Me.lblCardPlanTitle.Text = "🏢 بيانات الشركة وبصمة الجهاز"
            Me.lblCardPlanTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCompanyHeader
            '
            Me.lblCompanyHeader.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblCompanyHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblCompanyHeader.Location = New System.Drawing.Point(20, 54)
            Me.lblCompanyHeader.Name = "lblCompanyHeader"
            Me.lblCompanyHeader.Size = New System.Drawing.Size(550, 20)
            Me.lblCompanyHeader.TabIndex = 1
            Me.lblCompanyHeader.Text = "اسم الشركة:"
            Me.lblCompanyHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCompanyName
            '
            Me.lblCompanyName.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
            Me.lblCompanyName.ForeColor = System.Drawing.Color.White
            Me.lblCompanyName.Location = New System.Drawing.Point(20, 76)
            Me.lblCompanyName.Name = "lblCompanyName"
            Me.lblCompanyName.Size = New System.Drawing.Size(550, 26)
            Me.lblCompanyName.TabIndex = 2
            Me.lblCompanyName.Text = "-"
            Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCompanyIdHeader
            '
            Me.lblCompanyIdHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblCompanyIdHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblCompanyIdHeader.Location = New System.Drawing.Point(20, 108)
            Me.lblCompanyIdHeader.Name = "lblCompanyIdHeader"
            Me.lblCompanyIdHeader.Size = New System.Drawing.Size(550, 20)
            Me.lblCompanyIdHeader.TabIndex = 3
            Me.lblCompanyIdHeader.Text = "معرّف الشركة (Company ID):"
            Me.lblCompanyIdHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlCompanyIdBox
            '
            Me.pnlCompanyIdBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.pnlCompanyIdBox.BorderRadius = 8
            Me.pnlCompanyIdBox.BorderThickness = 1
            Me.pnlCompanyIdBox.Controls.Add(Me.btnCopyCompanyId)
            Me.pnlCompanyIdBox.Controls.Add(Me.lblCompanyId)
            Me.pnlCompanyIdBox.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(29, Byte), Integer))
            Me.pnlCompanyIdBox.Location = New System.Drawing.Point(20, 130)
            Me.pnlCompanyIdBox.Name = "pnlCompanyIdBox"
            Me.pnlCompanyIdBox.Size = New System.Drawing.Size(550, 42)
            Me.pnlCompanyIdBox.TabIndex = 4
            '
            'btnCopyCompanyId
            '
            Me.btnCopyCompanyId.BorderRadius = 6
            Me.btnCopyCompanyId.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCopyCompanyId.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnCopyCompanyId.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.btnCopyCompanyId.ForeColor = System.Drawing.Color.White
            Me.btnCopyCompanyId.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnCopyCompanyId.Location = New System.Drawing.Point(6, 6)
            Me.btnCopyCompanyId.Name = "btnCopyCompanyId"
            Me.btnCopyCompanyId.Size = New System.Drawing.Size(110, 30)
            Me.btnCopyCompanyId.TabIndex = 1
            Me.btnCopyCompanyId.Text = "📋 نسخ الكود"
            '
            'lblCompanyId
            '
            Me.lblCompanyId.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblCompanyId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblCompanyId.Location = New System.Drawing.Point(125, 6)
            Me.lblCompanyId.Name = "lblCompanyId"
            Me.lblCompanyId.Size = New System.Drawing.Size(415, 30)
            Me.lblCompanyId.TabIndex = 0
            Me.lblCompanyId.Text = "-"
            Me.lblCompanyId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblHWIDHeader
            '
            Me.lblHWIDHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblHWIDHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblHWIDHeader.Location = New System.Drawing.Point(20, 180)
            Me.lblHWIDHeader.Name = "lblHWIDHeader"
            Me.lblHWIDHeader.Size = New System.Drawing.Size(550, 20)
            Me.lblHWIDHeader.TabIndex = 5
            Me.lblHWIDHeader.Text = "بصمة هذا الجهاز (HWID):"
            Me.lblHWIDHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlHwidBox
            '
            Me.pnlHwidBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.pnlHwidBox.BorderRadius = 8
            Me.pnlHwidBox.BorderThickness = 1
            Me.pnlHwidBox.Controls.Add(Me.btnCopyHWID)
            Me.pnlHwidBox.Controls.Add(Me.lblHWID)
            Me.pnlHwidBox.FillColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(28, Byte), Integer))
            Me.pnlHwidBox.Location = New System.Drawing.Point(20, 202)
            Me.pnlHwidBox.Name = "pnlHwidBox"
            Me.pnlHwidBox.Size = New System.Drawing.Size(550, 48)
            Me.pnlHwidBox.TabIndex = 6
            '
            'btnCopyHWID
            '
            Me.btnCopyHWID.BorderRadius = 6
            Me.btnCopyHWID.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCopyHWID.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnCopyHWID.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.btnCopyHWID.ForeColor = System.Drawing.Color.White
            Me.btnCopyHWID.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(115, Byte), Integer))
            Me.btnCopyHWID.Location = New System.Drawing.Point(6, 8)
            Me.btnCopyHWID.Name = "btnCopyHWID"
            Me.btnCopyHWID.Size = New System.Drawing.Size(110, 32)
            Me.btnCopyHWID.TabIndex = 1
            Me.btnCopyHWID.Text = "📋 نسخ البصمة"
            '
            'lblHWID
            '
            Me.lblHWID.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHWID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(253, Byte), Integer))
            Me.lblHWID.Location = New System.Drawing.Point(125, 4)
            Me.lblHWID.Name = "lblHWID"
            Me.lblHWID.Size = New System.Drawing.Size(415, 40)
            Me.lblHWID.TabIndex = 0
            Me.lblHWID.Text = "-"
            Me.lblHWID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMaxDevicesHeader
            '
            Me.lblMaxDevicesHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblMaxDevicesHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblMaxDevicesHeader.Location = New System.Drawing.Point(300, 262)
            Me.lblMaxDevicesHeader.Name = "lblMaxDevicesHeader"
            Me.lblMaxDevicesHeader.Size = New System.Drawing.Size(270, 20)
            Me.lblMaxDevicesHeader.TabIndex = 7
            Me.lblMaxDevicesHeader.Text = "الحد الأقصى للأجهزة:"
            Me.lblMaxDevicesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMaxDevices
            '
            Me.lblMaxDevices.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblMaxDevices.ForeColor = System.Drawing.Color.White
            Me.lblMaxDevices.Location = New System.Drawing.Point(300, 284)
            Me.lblMaxDevices.Name = "lblMaxDevices"
            Me.lblMaxDevices.Size = New System.Drawing.Size(270, 26)
            Me.lblMaxDevices.TabIndex = 8
            Me.lblMaxDevices.Text = "-"
            Me.lblMaxDevices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMaxUsersHeader
            '
            Me.lblMaxUsersHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblMaxUsersHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblMaxUsersHeader.Location = New System.Drawing.Point(20, 262)
            Me.lblMaxUsersHeader.Name = "lblMaxUsersHeader"
            Me.lblMaxUsersHeader.Size = New System.Drawing.Size(260, 20)
            Me.lblMaxUsersHeader.TabIndex = 9
            Me.lblMaxUsersHeader.Text = "الحد الأقصى للمستخدمين:"
            Me.lblMaxUsersHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMaxUsers
            '
            Me.lblMaxUsers.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblMaxUsers.ForeColor = System.Drawing.Color.White
            Me.lblMaxUsers.Location = New System.Drawing.Point(20, 284)
            Me.lblMaxUsers.Name = "lblMaxUsers"
            Me.lblMaxUsers.Size = New System.Drawing.Size(260, 26)
            Me.lblMaxUsers.TabIndex = 10
            Me.lblMaxUsers.Text = "-"
            Me.lblMaxUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDeviceStatusHeader
            '
            Me.lblDeviceStatusHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblDeviceStatusHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblDeviceStatusHeader.Location = New System.Drawing.Point(20, 322)
            Me.lblDeviceStatusHeader.Name = "lblDeviceStatusHeader"
            Me.lblDeviceStatusHeader.Size = New System.Drawing.Size(550, 20)
            Me.lblDeviceStatusHeader.TabIndex = 11
            Me.lblDeviceStatusHeader.Text = "بيانات هذا الجهاز والتطبيق:"
            Me.lblDeviceStatusHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlDeviceStatusBox
            '
            Me.pnlDeviceStatusBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(72, Byte), Integer))
            Me.pnlDeviceStatusBox.BorderRadius = 8
            Me.pnlDeviceStatusBox.BorderThickness = 1
            Me.pnlDeviceStatusBox.Controls.Add(Me.lblDeviceStatus)
            Me.pnlDeviceStatusBox.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(29, Byte), Integer))
            Me.pnlDeviceStatusBox.Location = New System.Drawing.Point(20, 344)
            Me.pnlDeviceStatusBox.Name = "pnlDeviceStatusBox"
            Me.pnlDeviceStatusBox.Size = New System.Drawing.Size(550, 42)
            Me.pnlDeviceStatusBox.TabIndex = 12
            '
            'lblDeviceStatus
            '
            Me.lblDeviceStatus.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblDeviceStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblDeviceStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
            Me.lblDeviceStatus.Location = New System.Drawing.Point(0, 0)
            Me.lblDeviceStatus.Name = "lblDeviceStatus"
            Me.lblDeviceStatus.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
            Me.lblDeviceStatus.Size = New System.Drawing.Size(550, 42)
            Me.lblDeviceStatus.TabIndex = 0
            Me.lblDeviceStatus.Text = "الجهاز: نشط ومصرّح بالعمل ✅"
            Me.lblDeviceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlBottomBar
            '
            Me.pnlBottomBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlBottomBar.BackColor = System.Drawing.Color.Transparent
            Me.pnlBottomBar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.pnlBottomBar.BorderRadius = 12
            Me.pnlBottomBar.BorderThickness = 1
            Me.pnlBottomBar.Controls.Add(Me.btnRefresh)
            Me.pnlBottomBar.Controls.Add(Me.btnChangeSerial)
            Me.pnlBottomBar.Controls.Add(Me.btnCheckUpdate)
            Me.pnlBottomBar.Controls.Add(Me.btnClose)
            Me.pnlBottomBar.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.pnlBottomBar.Location = New System.Drawing.Point(20, 685)
            Me.pnlBottomBar.Name = "pnlBottomBar"
            Me.pnlBottomBar.Size = New System.Drawing.Size(1198, 62)
            Me.pnlBottomBar.TabIndex = 4
            '
            'btnRefresh
            '
            Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRefresh.BorderRadius = 8
            Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnRefresh.Location = New System.Drawing.Point(928, 9)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(250, 44)
            Me.btnRefresh.TabIndex = 0
            Me.btnRefresh.Text = "🔄 فحص وتحديث الترخيص"
            '
            'btnChangeSerial
            '
            Me.btnChangeSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnChangeSerial.BorderRadius = 8
            Me.btnChangeSerial.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnChangeSerial.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnChangeSerial.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnChangeSerial.ForeColor = System.Drawing.Color.White
            Me.btnChangeSerial.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
            Me.btnChangeSerial.Location = New System.Drawing.Point(678, 9)
            Me.btnChangeSerial.Name = "btnChangeSerial"
            Me.btnChangeSerial.Size = New System.Drawing.Size(235, 44)
            Me.btnChangeSerial.TabIndex = 1
            Me.btnChangeSerial.Text = "🔑 تغيير مفتاح الترخيص"
            '
            'btnCheckUpdate
            '
            Me.btnCheckUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCheckUpdate.BorderRadius = 8
            Me.btnCheckUpdate.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCheckUpdate.FillColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(229, Byte), Integer))
            Me.btnCheckUpdate.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnCheckUpdate.ForeColor = System.Drawing.Color.White
            Me.btnCheckUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(202, Byte), Integer))
            Me.btnCheckUpdate.Location = New System.Drawing.Point(428, 9)
            Me.btnCheckUpdate.Name = "btnCheckUpdate"
            Me.btnCheckUpdate.Size = New System.Drawing.Size(235, 44)
            Me.btnCheckUpdate.TabIndex = 2
            Me.btnCheckUpdate.Text = "🚀 البحث عن تحديثات للبرنامج"
            '
            'btnClose
            '
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnClose.BorderRadius = 8
            Me.btnClose.BorderThickness = 1
            Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnClose.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(18, 9)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 44)
            Me.btnClose.TabIndex = 3
            Me.btnClose.Text = "✕ إغلاق النافذة"
            '
            'UCActivationSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCActivationSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 785)
            Me.pnlMain.ResumeLayout(False)
            Me.cardHero.ResumeLayout(False)
            Me.pnlStatusBadge.ResumeLayout(False)
            Me.cardStatus.ResumeLayout(False)
            Me.pnlSerialBox.ResumeLayout(False)
            Me.cardPlan.ResumeLayout(False)
            Me.pnlCompanyIdBox.ResumeLayout(False)
            Me.pnlHwidBox.ResumeLayout(False)
            Me.pnlDeviceStatusBox.ResumeLayout(False)
            Me.pnlBottomBar.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardHero As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents pnlStatusBadge As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents lblHeroCompany As System.Windows.Forms.Label
        Friend WithEvents lblHeroPlan As System.Windows.Forms.Label
        Friend WithEvents lblHeroExpiry As System.Windows.Forms.Label
        Friend WithEvents lblHeroGrace As System.Windows.Forms.Label
        Friend WithEvents cardStatus As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardStatusTitle As System.Windows.Forms.Label
        Friend WithEvents lblSerialHeader As System.Windows.Forms.Label
        Friend WithEvents pnlSerialBox As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblSerial As System.Windows.Forms.Label
        Friend WithEvents btnCopySerial As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblStartDateHeader As System.Windows.Forms.Label
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents lblExpiryDateHeader As System.Windows.Forms.Label
        Friend WithEvents lblExpiryDate As System.Windows.Forms.Label
        Friend WithEvents lblGracePeriodHeader As System.Windows.Forms.Label
        Friend WithEvents lblGracePeriod As System.Windows.Forms.Label
        Friend WithEvents lblPlanHeader As System.Windows.Forms.Label
        Friend WithEvents lblPlanName As System.Windows.Forms.Label
        Friend WithEvents lblChannelHeader As System.Windows.Forms.Label
        Friend WithEvents lblChannel As System.Windows.Forms.Label
        Friend WithEvents lblPriceHeader As System.Windows.Forms.Label
        Friend WithEvents lblPrice As System.Windows.Forms.Label
        Friend WithEvents lblLastSyncHeader As System.Windows.Forms.Label
        Friend WithEvents lblLastSync As System.Windows.Forms.Label
        Friend WithEvents cardPlan As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardPlanTitle As System.Windows.Forms.Label
        Friend WithEvents lblCompanyHeader As System.Windows.Forms.Label
        Friend WithEvents lblCompanyName As System.Windows.Forms.Label
        Friend WithEvents lblCompanyIdHeader As System.Windows.Forms.Label
        Friend WithEvents pnlCompanyIdBox As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCompanyId As System.Windows.Forms.Label
        Friend WithEvents btnCopyCompanyId As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblHWIDHeader As System.Windows.Forms.Label
        Friend WithEvents pnlHwidBox As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblHWID As System.Windows.Forms.Label
        Friend WithEvents btnCopyHWID As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblMaxDevicesHeader As System.Windows.Forms.Label
        Friend WithEvents lblMaxDevices As System.Windows.Forms.Label
        Friend WithEvents lblMaxUsersHeader As System.Windows.Forms.Label
        Friend WithEvents lblMaxUsers As System.Windows.Forms.Label
        Friend WithEvents lblDeviceStatusHeader As System.Windows.Forms.Label
        Friend WithEvents pnlDeviceStatusBox As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblDeviceStatus As System.Windows.Forms.Label
        Friend WithEvents pnlBottomBar As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnChangeSerial As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnCheckUpdate As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
