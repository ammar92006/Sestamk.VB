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
            Me.cardStatus = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardStatusTitle = New System.Windows.Forms.Label()
            Me.lblStatusHeader = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.lblStartDateHeader = New System.Windows.Forms.Label()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.lblExpiryDateHeader = New System.Windows.Forms.Label()
            Me.lblExpiryDate = New System.Windows.Forms.Label()
            Me.lblSerialHeader = New System.Windows.Forms.Label()
            Me.lblSerial = New System.Windows.Forms.Label()
            Me.lblHWIDHeader = New System.Windows.Forms.Label()
            Me.lblHWID = New System.Windows.Forms.Label()
            Me.btnCopyHWID = New Guna.UI2.WinForms.Guna2Button()
            Me.cardPlan = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardPlanTitle = New System.Windows.Forms.Label()
            Me.lblCompanyHeader = New System.Windows.Forms.Label()
            Me.lblCompanyName = New System.Windows.Forms.Label()
            Me.lblPlanHeader = New System.Windows.Forms.Label()
            Me.lblPlanName = New System.Windows.Forms.Label()
            Me.lblMaxDevicesHeader = New System.Windows.Forms.Label()
            Me.lblMaxDevices = New System.Windows.Forms.Label()
            Me.lblMaxUsersHeader = New System.Windows.Forms.Label()
            Me.lblMaxUsers = New System.Windows.Forms.Label()
            Me.lblPriceHeader = New System.Windows.Forms.Label()
            Me.lblPrice = New System.Windows.Forms.Label()
            Me.btnChangeSerial = New Guna.UI2.WinForms.Guna2Button()
            Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardStatus.SuspendLayout()
            Me.cardPlan.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardStatus)
            Me.pnlMain.Controls.Add(Me.cardPlan)
            Me.pnlMain.Controls.Add(Me.btnRefresh)
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
            Me.lblTitle.Text = "إدارة التفعيل والترخيص"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(700, 58)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(508, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "عرض تفاصيل الخطة وحالة الاشتراك وبصمة الجهاز وإدارة التفعيل"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardStatus
            '
            Me.cardStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardStatus.BackColor = System.Drawing.Color.Transparent
            Me.cardStatus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardStatus.BorderRadius = 14
            Me.cardStatus.BorderThickness = 1
            Me.cardStatus.Controls.Add(Me.lblCardStatusTitle)
            Me.cardStatus.Controls.Add(Me.lblStatusHeader)
            Me.cardStatus.Controls.Add(Me.lblStatus)
            Me.cardStatus.Controls.Add(Me.lblStartDateHeader)
            Me.cardStatus.Controls.Add(Me.lblStartDate)
            Me.cardStatus.Controls.Add(Me.lblExpiryDateHeader)
            Me.cardStatus.Controls.Add(Me.lblExpiryDate)
            Me.cardStatus.Controls.Add(Me.lblSerialHeader)
            Me.cardStatus.Controls.Add(Me.lblSerial)
            Me.cardStatus.Controls.Add(Me.lblHWIDHeader)
            Me.cardStatus.Controls.Add(Me.lblHWID)
            Me.cardStatus.Controls.Add(Me.btnCopyHWID)
            Me.cardStatus.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardStatus.Location = New System.Drawing.Point(30, 95)
            Me.cardStatus.Name = "cardStatus"
            Me.cardStatus.Size = New System.Drawing.Size(1178, 260)
            Me.cardStatus.TabIndex = 2
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
            Me.lblCardStatusTitle.Text = "معلومات الترخيص والحالة"
            Me.lblCardStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStatusHeader
            '
            Me.lblStatusHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStatusHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatusHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblStatusHeader.Location = New System.Drawing.Point(1000, 55)
            Me.lblStatusHeader.Name = "lblStatusHeader"
            Me.lblStatusHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblStatusHeader.TabIndex = 1
            Me.lblStatusHeader.Text = "حالة الاشتراك:"
            Me.lblStatusHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
            Me.lblStatus.Location = New System.Drawing.Point(750, 55)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(240, 25)
            Me.lblStatus.TabIndex = 2
            Me.lblStatus.Text = "جاري الفحص..."
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStartDateHeader
            '
            Me.lblStartDateHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStartDateHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblStartDateHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblStartDateHeader.Location = New System.Drawing.Point(450, 55)
            Me.lblStartDateHeader.Name = "lblStartDateHeader"
            Me.lblStartDateHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblStartDateHeader.TabIndex = 3
            Me.lblStartDateHeader.Text = "تاريخ البداية:"
            Me.lblStartDateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStartDate
            '
            Me.lblStartDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblStartDate.ForeColor = System.Drawing.Color.White
            Me.lblStartDate.Location = New System.Drawing.Point(200, 55)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(240, 25)
            Me.lblStartDate.TabIndex = 4
            Me.lblStartDate.Text = "-"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblExpiryDateHeader
            '
            Me.lblExpiryDateHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblExpiryDateHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblExpiryDateHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblExpiryDateHeader.Location = New System.Drawing.Point(1000, 95)
            Me.lblExpiryDateHeader.Name = "lblExpiryDateHeader"
            Me.lblExpiryDateHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblExpiryDateHeader.TabIndex = 5
            Me.lblExpiryDateHeader.Text = "تاريخ الانتهاء:"
            Me.lblExpiryDateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblExpiryDate
            '
            Me.lblExpiryDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblExpiryDate.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblExpiryDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblExpiryDate.Location = New System.Drawing.Point(750, 95)
            Me.lblExpiryDate.Name = "lblExpiryDate"
            Me.lblExpiryDate.Size = New System.Drawing.Size(240, 25)
            Me.lblExpiryDate.TabIndex = 6
            Me.lblExpiryDate.Text = "-"
            Me.lblExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSerialHeader
            '
            Me.lblSerialHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSerialHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblSerialHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblSerialHeader.Location = New System.Drawing.Point(1000, 140)
            Me.lblSerialHeader.Name = "lblSerialHeader"
            Me.lblSerialHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblSerialHeader.TabIndex = 7
            Me.lblSerialHeader.Text = "مفتاح التفعيل:"
            Me.lblSerialHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSerial
            '
            Me.lblSerial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSerial.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblSerial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(11, Byte), Integer))
            Me.lblSerial.Location = New System.Drawing.Point(30, 140)
            Me.lblSerial.Name = "lblSerial"
            Me.lblSerial.Size = New System.Drawing.Size(960, 25)
            Me.lblSerial.TabIndex = 8
            Me.lblSerial.Text = "-"
            Me.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblHWIDHeader
            '
            Me.lblHWIDHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblHWIDHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblHWIDHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblHWIDHeader.Location = New System.Drawing.Point(1000, 190)
            Me.lblHWIDHeader.Name = "lblHWIDHeader"
            Me.lblHWIDHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblHWIDHeader.TabIndex = 9
            Me.lblHWIDHeader.Text = "بصمة الجهاز (HWID):"
            Me.lblHWIDHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblHWID
            '
            Me.lblHWID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblHWID.Font = New System.Drawing.Font("Consolas", 10.0!)
            Me.lblHWID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblHWID.Location = New System.Drawing.Point(170, 190)
            Me.lblHWID.Name = "lblHWID"
            Me.lblHWID.Size = New System.Drawing.Size(820, 25)
            Me.lblHWID.TabIndex = 10
            Me.lblHWID.Text = "-"
            Me.lblHWID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCopyHWID
            '
            Me.btnCopyHWID.BorderRadius = 8
            Me.btnCopyHWID.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCopyHWID.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnCopyHWID.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnCopyHWID.ForeColor = System.Drawing.Color.White
            Me.btnCopyHWID.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnCopyHWID.Location = New System.Drawing.Point(30, 185)
            Me.btnCopyHWID.Name = "btnCopyHWID"
            Me.btnCopyHWID.Size = New System.Drawing.Size(125, 36)
            Me.btnCopyHWID.TabIndex = 11
            Me.btnCopyHWID.Text = "📋 نسخ البصمة"
            '
            'cardPlan
            '
            Me.cardPlan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardPlan.BackColor = System.Drawing.Color.Transparent
            Me.cardPlan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardPlan.BorderRadius = 14
            Me.cardPlan.BorderThickness = 1
            Me.cardPlan.Controls.Add(Me.lblCardPlanTitle)
            Me.cardPlan.Controls.Add(Me.lblCompanyHeader)
            Me.cardPlan.Controls.Add(Me.lblCompanyName)
            Me.cardPlan.Controls.Add(Me.lblPlanHeader)
            Me.cardPlan.Controls.Add(Me.lblPlanName)
            Me.cardPlan.Controls.Add(Me.lblMaxDevicesHeader)
            Me.cardPlan.Controls.Add(Me.lblMaxDevices)
            Me.cardPlan.Controls.Add(Me.lblMaxUsersHeader)
            Me.cardPlan.Controls.Add(Me.lblMaxUsers)
            Me.cardPlan.Controls.Add(Me.lblPriceHeader)
            Me.cardPlan.Controls.Add(Me.lblPrice)
            Me.cardPlan.Controls.Add(Me.btnChangeSerial)
            Me.cardPlan.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPlan.Location = New System.Drawing.Point(30, 370)
            Me.cardPlan.Name = "cardPlan"
            Me.cardPlan.Size = New System.Drawing.Size(1178, 250)
            Me.cardPlan.TabIndex = 3
            '
            'lblCardPlanTitle
            '
            Me.lblCardPlanTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardPlanTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardPlanTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardPlanTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardPlanTitle.Name = "lblCardPlanTitle"
            Me.lblCardPlanTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardPlanTitle.TabIndex = 0
            Me.lblCardPlanTitle.Text = "تفاصيل الخطة والاشتراك"
            Me.lblCardPlanTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCompanyHeader
            '
            Me.lblCompanyHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCompanyHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCompanyHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblCompanyHeader.Location = New System.Drawing.Point(1000, 55)
            Me.lblCompanyHeader.Name = "lblCompanyHeader"
            Me.lblCompanyHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblCompanyHeader.TabIndex = 1
            Me.lblCompanyHeader.Text = "اسم المنشأة:"
            Me.lblCompanyHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCompanyName
            '
            Me.lblCompanyName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCompanyName.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCompanyName.ForeColor = System.Drawing.Color.White
            Me.lblCompanyName.Location = New System.Drawing.Point(600, 55)
            Me.lblCompanyName.Name = "lblCompanyName"
            Me.lblCompanyName.Size = New System.Drawing.Size(390, 25)
            Me.lblCompanyName.TabIndex = 2
            Me.lblCompanyName.Text = "-"
            Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPlanHeader
            '
            Me.lblPlanHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPlanHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPlanHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblPlanHeader.Location = New System.Drawing.Point(450, 55)
            Me.lblPlanHeader.Name = "lblPlanHeader"
            Me.lblPlanHeader.Size = New System.Drawing.Size(120, 25)
            Me.lblPlanHeader.TabIndex = 3
            Me.lblPlanHeader.Text = "نوع الخطة:"
            Me.lblPlanHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPlanName
            '
            Me.lblPlanName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPlanName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblPlanName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(248, Byte), Integer))
            Me.lblPlanName.Location = New System.Drawing.Point(200, 55)
            Me.lblPlanName.Name = "lblPlanName"
            Me.lblPlanName.Size = New System.Drawing.Size(240, 25)
            Me.lblPlanName.TabIndex = 4
            Me.lblPlanName.Text = "-"
            Me.lblPlanName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMaxDevicesHeader
            '
            Me.lblMaxDevicesHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblMaxDevicesHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblMaxDevicesHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblMaxDevicesHeader.Location = New System.Drawing.Point(1000, 105)
            Me.lblMaxDevicesHeader.Name = "lblMaxDevicesHeader"
            Me.lblMaxDevicesHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblMaxDevicesHeader.TabIndex = 5
            Me.lblMaxDevicesHeader.Text = "الحد الأقصى للأجهزة:"
            Me.lblMaxDevicesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMaxDevices
            '
            Me.lblMaxDevices.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblMaxDevices.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblMaxDevices.ForeColor = System.Drawing.Color.White
            Me.lblMaxDevices.Location = New System.Drawing.Point(850, 105)
            Me.lblMaxDevices.Name = "lblMaxDevices"
            Me.lblMaxDevices.Size = New System.Drawing.Size(140, 25)
            Me.lblMaxDevices.TabIndex = 6
            Me.lblMaxDevices.Text = "-"
            Me.lblMaxDevices.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMaxUsersHeader
            '
            Me.lblMaxUsersHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblMaxUsersHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblMaxUsersHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblMaxUsersHeader.Location = New System.Drawing.Point(650, 105)
            Me.lblMaxUsersHeader.Name = "lblMaxUsersHeader"
            Me.lblMaxUsersHeader.Size = New System.Drawing.Size(170, 25)
            Me.lblMaxUsersHeader.TabIndex = 7
            Me.lblMaxUsersHeader.Text = "الحد الأقصى للمستخدمين:"
            Me.lblMaxUsersHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMaxUsers
            '
            Me.lblMaxUsers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblMaxUsers.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblMaxUsers.ForeColor = System.Drawing.Color.White
            Me.lblMaxUsers.Location = New System.Drawing.Point(500, 105)
            Me.lblMaxUsers.Name = "lblMaxUsers"
            Me.lblMaxUsers.Size = New System.Drawing.Size(140, 25)
            Me.lblMaxUsers.TabIndex = 8
            Me.lblMaxUsers.Text = "-"
            Me.lblMaxUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPriceHeader
            '
            Me.lblPriceHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPriceHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPriceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblPriceHeader.Location = New System.Drawing.Point(300, 105)
            Me.lblPriceHeader.Name = "lblPriceHeader"
            Me.lblPriceHeader.Size = New System.Drawing.Size(120, 25)
            Me.lblPriceHeader.TabIndex = 9
            Me.lblPriceHeader.Text = "التكلفة:"
            Me.lblPriceHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPrice
            '
            Me.lblPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPrice.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblPrice.ForeColor = System.Drawing.Color.White
            Me.lblPrice.Location = New System.Drawing.Point(50, 105)
            Me.lblPrice.Name = "lblPrice"
            Me.lblPrice.Size = New System.Drawing.Size(240, 25)
            Me.lblPrice.TabIndex = 10
            Me.lblPrice.Text = "-"
            Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnChangeSerial
            '
            Me.btnChangeSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnChangeSerial.BorderRadius = 10
            Me.btnChangeSerial.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnChangeSerial.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnChangeSerial.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnChangeSerial.ForeColor = System.Drawing.Color.White
            Me.btnChangeSerial.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
            Me.btnChangeSerial.Location = New System.Drawing.Point(880, 180)
            Me.btnChangeSerial.Name = "btnChangeSerial"
            Me.btnChangeSerial.Size = New System.Drawing.Size(270, 48)
            Me.btnChangeSerial.TabIndex = 11
            Me.btnChangeSerial.Text = "🔑 تغيير السيريال / إعادة التفعيل"
            '
            'btnRefresh
            '
            Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRefresh.BorderRadius = 10
            Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnRefresh.Location = New System.Drawing.Point(978, 650)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(230, 48)
            Me.btnRefresh.TabIndex = 4
            Me.btnRefresh.Text = "🔄 تحديث بيانات الترخيص"
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnClose.BorderRadius = 10
            Me.btnClose.BorderThickness = 1
            Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 650)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(130, 48)
            Me.btnClose.TabIndex = 5
            Me.btnClose.Text = "إغلاق"
            '
            'UCActivationSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCActivationSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 730)
            Me.pnlMain.ResumeLayout(False)
            Me.cardStatus.ResumeLayout(False)
            Me.cardPlan.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardStatus As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardStatusTitle As System.Windows.Forms.Label
        Friend WithEvents lblStatusHeader As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents lblStartDateHeader As System.Windows.Forms.Label
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents lblExpiryDateHeader As System.Windows.Forms.Label
        Friend WithEvents lblExpiryDate As System.Windows.Forms.Label
        Friend WithEvents lblSerialHeader As System.Windows.Forms.Label
        Friend WithEvents lblSerial As System.Windows.Forms.Label
        Friend WithEvents lblHWIDHeader As System.Windows.Forms.Label
        Friend WithEvents lblHWID As System.Windows.Forms.Label
        Friend WithEvents btnCopyHWID As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardPlan As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardPlanTitle As System.Windows.Forms.Label
        Friend WithEvents lblCompanyHeader As System.Windows.Forms.Label
        Friend WithEvents lblCompanyName As System.Windows.Forms.Label
        Friend WithEvents lblPlanHeader As System.Windows.Forms.Label
        Friend WithEvents lblPlanName As System.Windows.Forms.Label
        Friend WithEvents lblMaxDevicesHeader As System.Windows.Forms.Label
        Friend WithEvents lblMaxDevices As System.Windows.Forms.Label
        Friend WithEvents lblMaxUsersHeader As System.Windows.Forms.Label
        Friend WithEvents lblMaxUsers As System.Windows.Forms.Label
        Friend WithEvents lblPriceHeader As System.Windows.Forms.Label
        Friend WithEvents lblPrice As System.Windows.Forms.Label
        Friend WithEvents btnChangeSerial As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
