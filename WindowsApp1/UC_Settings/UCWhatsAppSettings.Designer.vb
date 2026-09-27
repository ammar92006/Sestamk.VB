Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCWhatsAppSettings
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
            Me.lblStatusLabel = New System.Windows.Forms.Label()
            Me.lblStatusBadge = New System.Windows.Forms.Label()
            Me.lblPhoneLabel = New System.Windows.Forms.Label()
            Me.lblConnectedPhone = New System.Windows.Forms.Label()
            Me.picQRCode = New System.Windows.Forms.PictureBox()
            Me.lblQrHint = New System.Windows.Forms.Label()
            Me.btnConnect = New Guna.UI2.WinForms.Guna2Button()
            Me.btnResetSession = New Guna.UI2.WinForms.Guna2Button()
            Me.cardMode = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardModeTitle = New System.Windows.Forms.Label()
            Me.rdoModeCloud = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblModeCloud = New System.Windows.Forms.Label()
            Me.rdoModeLocal = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblModeLocal = New System.Windows.Forms.Label()
            Me.lblServerUrl = New System.Windows.Forms.Label()
            Me.txtServerUrl = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnPresetCloud = New Guna.UI2.WinForms.Guna2Button()
            Me.btnPresetLocal = New Guna.UI2.WinForms.Guna2Button()
            Me.lblApiSecret = New System.Windows.Forms.Label()
            Me.txtApiSecret = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cardAutoSend = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardAutoSendTitle = New System.Windows.Forms.Label()
            Me.lblAutoSend = New System.Windows.Forms.Label()
            Me.tglAutoSend = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblFormatTitle = New System.Windows.Forms.Label()
            Me.rdoFormatText = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblFormatText = New System.Windows.Forms.Label()
            Me.rdoFormatImage = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblFormatImage = New System.Windows.Forms.Label()
            Me.rdoFormatPdf = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblFormatPdf = New System.Windows.Forms.Label()
            Me.cardTemplates = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardTemplatesTitle = New System.Windows.Forms.Label()
            Me.lblWelcomeTemplate = New System.Windows.Forms.Label()
            Me.txtWelcomeTemplate = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblInvoiceTemplate = New System.Windows.Forms.Label()
            Me.txtInvoiceTemplate = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cardTest = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardTestTitle = New System.Windows.Forms.Label()
            Me.lblTestPhone = New System.Windows.Forms.Label()
            Me.txtTestPhone = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblTestMsg = New System.Windows.Forms.Label()
            Me.txtTestMsg = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnSendTest = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardStatus.SuspendLayout()
            CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardMode.SuspendLayout()
            Me.cardAutoSend.SuspendLayout()
            Me.cardTemplates.SuspendLayout()
            Me.cardTest.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardStatus)
            Me.pnlMain.Controls.Add(Me.cardMode)
            Me.pnlMain.Controls.Add(Me.cardAutoSend)
            Me.pnlMain.Controls.Add(Me.cardTemplates)
            Me.pnlMain.Controls.Add(Me.cardTest)
            Me.pnlMain.Controls.Add(Me.btnSave)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Padding = New System.Windows.Forms.Padding(20, 10, 20, 40)
            Me.pnlMain.Size = New System.Drawing.Size(1238, 900)
            Me.pnlMain.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.White
            Me.lblTitle.Location = New System.Drawing.Point(970, 15)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(228, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "إعدادات خدمة الواتساب"
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.AutoSize = True
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(820, 48)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(378, 19)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "ربط الحساب وإرسال الفواتير ورسائل المتابعة تلقائياً للعملاء عبر واتساب"
            '
            'cardStatus
            '
            Me.cardStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardStatus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.cardStatus.BorderRadius = 12
            Me.cardStatus.BorderThickness = 1
            Me.cardStatus.Controls.Add(Me.lblCardStatusTitle)
            Me.cardStatus.Controls.Add(Me.lblStatusLabel)
            Me.cardStatus.Controls.Add(Me.lblStatusBadge)
            Me.cardStatus.Controls.Add(Me.lblPhoneLabel)
            Me.cardStatus.Controls.Add(Me.lblConnectedPhone)
            Me.cardStatus.Controls.Add(Me.picQRCode)
            Me.cardStatus.Controls.Add(Me.lblQrHint)
            Me.cardStatus.Controls.Add(Me.btnConnect)
            Me.cardStatus.Controls.Add(Me.btnResetSession)
            Me.cardStatus.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardStatus.Location = New System.Drawing.Point(20, 80)
            Me.cardStatus.Name = "cardStatus"
            Me.cardStatus.Size = New System.Drawing.Size(1178, 220)
            Me.cardStatus.TabIndex = 2
            '
            'lblCardStatusTitle
            '
            Me.lblCardStatusTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardStatusTitle.AutoSize = True
            Me.lblCardStatusTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblCardStatusTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardStatusTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblCardStatusTitle.Location = New System.Drawing.Point(920, 15)
            Me.lblCardStatusTitle.Name = "lblCardStatusTitle"
            Me.lblCardStatusTitle.Size = New System.Drawing.Size(238, 21)
            Me.lblCardStatusTitle.TabIndex = 0
            Me.lblCardStatusTitle.Text = "📡 حالة الاتصال بحساب الواتساب"
            '
            'lblStatusLabel
            '
            Me.lblStatusLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStatusLabel.AutoSize = True
            Me.lblStatusLabel.BackColor = System.Drawing.Color.Transparent
            Me.lblStatusLabel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblStatusLabel.Location = New System.Drawing.Point(1050, 55)
            Me.lblStatusLabel.Name = "lblStatusLabel"
            Me.lblStatusLabel.Size = New System.Drawing.Size(100, 20)
            Me.lblStatusLabel.TabIndex = 1
            Me.lblStatusLabel.Text = "الحالة الحالية:"
            '
            'lblStatusBadge
            '
            Me.lblStatusBadge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStatusBadge.AutoSize = True
            Me.lblStatusBadge.BackColor = System.Drawing.Color.Transparent
            Me.lblStatusBadge.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatusBadge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(8, Byte), Integer))
            Me.lblStatusBadge.Location = New System.Drawing.Point(880, 55)
            Me.lblStatusBadge.Name = "lblStatusBadge"
            Me.lblStatusBadge.Size = New System.Drawing.Size(130, 21)
            Me.lblStatusBadge.TabIndex = 2
            Me.lblStatusBadge.Text = "في انتظار الفحص..."
            '
            'lblPhoneLabel
            '
            Me.lblPhoneLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPhoneLabel.AutoSize = True
            Me.lblPhoneLabel.BackColor = System.Drawing.Color.Transparent
            Me.lblPhoneLabel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblPhoneLabel.Location = New System.Drawing.Point(1030, 95)
            Me.lblPhoneLabel.Name = "lblPhoneLabel"
            Me.lblPhoneLabel.Size = New System.Drawing.Size(120, 20)
            Me.lblPhoneLabel.TabIndex = 3
            Me.lblPhoneLabel.Text = "الحساب المقترن:"
            '
            'lblConnectedPhone
            '
            Me.lblConnectedPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblConnectedPhone.AutoSize = True
            Me.lblConnectedPhone.BackColor = System.Drawing.Color.Transparent
            Me.lblConnectedPhone.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblConnectedPhone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblConnectedPhone.Location = New System.Drawing.Point(880, 95)
            Me.lblConnectedPhone.Name = "lblConnectedPhone"
            Me.lblConnectedPhone.Size = New System.Drawing.Size(30, 20)
            Me.lblConnectedPhone.TabIndex = 4
            Me.lblConnectedPhone.Text = "---"
            '
            'picQRCode
            '
            Me.picQRCode.BackColor = System.Drawing.Color.White
            Me.picQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.picQRCode.Location = New System.Drawing.Point(30, 15)
            Me.picQRCode.Name = "picQRCode"
            Me.picQRCode.Size = New System.Drawing.Size(180, 180)
            Me.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picQRCode.TabIndex = 5
            Me.picQRCode.TabStop = False
            '
            'lblQrHint
            '
            Me.lblQrHint.AutoSize = True
            Me.lblQrHint.BackColor = System.Drawing.Color.Transparent
            Me.lblQrHint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblQrHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblQrHint.Location = New System.Drawing.Point(220, 25)
            Me.lblQrHint.Name = "lblQrHint"
            Me.lblQrHint.Size = New System.Drawing.Size(260, 15)
            Me.lblQrHint.TabIndex = 6
            Me.lblQrHint.Text = "افتح واتساب > الأجهزة المرتبطة > امسح رمز الـ QR"
            '
            'btnConnect
            '
            Me.btnConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnConnect.BorderRadius = 8
            Me.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnConnect.FillColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnConnect.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnConnect.ForeColor = System.Drawing.Color.White
            Me.btnConnect.Location = New System.Drawing.Point(950, 150)
            Me.btnConnect.Name = "btnConnect"
            Me.btnConnect.Size = New System.Drawing.Size(200, 42)
            Me.btnConnect.TabIndex = 7
            Me.btnConnect.Text = "فحص وتحديث الاتصال 🔄"
            '
            'btnResetSession
            '
            Me.btnResetSession.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnResetSession.BorderRadius = 8
            Me.btnResetSession.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnResetSession.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
            Me.btnResetSession.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnResetSession.ForeColor = System.Drawing.Color.White
            Me.btnResetSession.Location = New System.Drawing.Point(730, 150)
            Me.btnResetSession.Name = "btnResetSession"
            Me.btnResetSession.Size = New System.Drawing.Size(200, 42)
            Me.btnResetSession.TabIndex = 8
            Me.btnResetSession.Text = "فك الارتباط / إعادة تهيئة 🔓"
            '
            'cardMode
            '
            Me.cardMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardMode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.cardMode.BorderRadius = 12
            Me.cardMode.BorderThickness = 1
            Me.cardMode.Controls.Add(Me.lblCardModeTitle)
            Me.cardMode.Controls.Add(Me.rdoModeCloud)
            Me.cardMode.Controls.Add(Me.lblModeCloud)
            Me.cardMode.Controls.Add(Me.rdoModeLocal)
            Me.cardMode.Controls.Add(Me.lblModeLocal)
            Me.cardMode.Controls.Add(Me.lblServerUrl)
            Me.cardMode.Controls.Add(Me.txtServerUrl)
            Me.cardMode.Controls.Add(Me.btnPresetCloud)
            Me.cardMode.Controls.Add(Me.btnPresetLocal)
            Me.cardMode.Controls.Add(Me.lblApiSecret)
            Me.cardMode.Controls.Add(Me.txtApiSecret)
            Me.cardMode.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardMode.Location = New System.Drawing.Point(20, 315)
            Me.cardMode.Name = "cardMode"
            Me.cardMode.Size = New System.Drawing.Size(1178, 175)
            Me.cardMode.TabIndex = 3
            '
            'lblCardModeTitle
            '
            Me.lblCardModeTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardModeTitle.AutoSize = True
            Me.lblCardModeTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblCardModeTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardModeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblCardModeTitle.Location = New System.Drawing.Point(920, 15)
            Me.lblCardModeTitle.Name = "lblCardModeTitle"
            Me.lblCardModeTitle.Size = New System.Drawing.Size(238, 21)
            Me.lblCardModeTitle.TabIndex = 0
            Me.lblCardModeTitle.Text = "☁️ نمط الاتصال وبيانات السيرفر"
            '
            'rdoModeCloud
            '
            Me.rdoModeCloud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rdoModeCloud.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoModeCloud.CheckedState.BorderThickness = 0
            Me.rdoModeCloud.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoModeCloud.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rdoModeCloud.Location = New System.Drawing.Point(1135, 45)
            Me.rdoModeCloud.Name = "rdoModeCloud"
            Me.rdoModeCloud.Size = New System.Drawing.Size(22, 22)
            Me.rdoModeCloud.TabIndex = 1
            Me.rdoModeCloud.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
            Me.rdoModeCloud.UncheckedState.BorderThickness = 2
            Me.rdoModeCloud.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rdoModeCloud.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblModeCloud
            '
            Me.lblModeCloud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblModeCloud.AutoSize = True
            Me.lblModeCloud.BackColor = System.Drawing.Color.Transparent
            Me.lblModeCloud.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblModeCloud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblModeCloud.Location = New System.Drawing.Point(920, 46)
            Me.lblModeCloud.Name = "lblModeCloud"
            Me.lblModeCloud.Size = New System.Drawing.Size(210, 20)
            Me.lblModeCloud.TabIndex = 2
            Me.lblModeCloud.Text = "سيرفر سحابي (Cloud - موصى به)"
            '
            'rdoModeLocal
            '
            Me.rdoModeLocal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rdoModeLocal.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoModeLocal.CheckedState.BorderThickness = 0
            Me.rdoModeLocal.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoModeLocal.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rdoModeLocal.Location = New System.Drawing.Point(860, 45)
            Me.rdoModeLocal.Name = "rdoModeLocal"
            Me.rdoModeLocal.Size = New System.Drawing.Size(22, 22)
            Me.rdoModeLocal.TabIndex = 3
            Me.rdoModeLocal.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
            Me.rdoModeLocal.UncheckedState.BorderThickness = 2
            Me.rdoModeLocal.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rdoModeLocal.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblModeLocal
            '
            Me.lblModeLocal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblModeLocal.AutoSize = True
            Me.lblModeLocal.BackColor = System.Drawing.Color.Transparent
            Me.lblModeLocal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblModeLocal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblModeLocal.Location = New System.Drawing.Point(670, 46)
            Me.lblModeLocal.Name = "lblModeLocal"
            Me.lblModeLocal.Size = New System.Drawing.Size(185, 20)
            Me.lblModeLocal.TabIndex = 4
            Me.lblModeLocal.Text = "سيرفر محلي على جهاز الكاشير"
            '
            'lblServerUrl
            '
            Me.lblServerUrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblServerUrl.AutoSize = True
            Me.lblServerUrl.BackColor = System.Drawing.Color.Transparent
            Me.lblServerUrl.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblServerUrl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblServerUrl.Location = New System.Drawing.Point(1040, 85)
            Me.lblServerUrl.Name = "lblServerUrl"
            Me.lblServerUrl.Size = New System.Drawing.Size(115, 19)
            Me.lblServerUrl.TabIndex = 5
            Me.lblServerUrl.Text = "عنوان السيرفر (URL):"
            '
            'txtServerUrl
            '
            Me.txtServerUrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtServerUrl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtServerUrl.BorderRadius = 6
            Me.txtServerUrl.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.txtServerUrl.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtServerUrl.ForeColor = System.Drawing.Color.White
            Me.txtServerUrl.Location = New System.Drawing.Point(450, 80)
            Me.txtServerUrl.Name = "txtServerUrl"
            Me.txtServerUrl.Size = New System.Drawing.Size(580, 36)
            Me.txtServerUrl.TabIndex = 6
            '
            'btnPresetCloud
            '
            Me.btnPresetCloud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPresetCloud.BorderRadius = 6
            Me.btnPresetCloud.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnPresetCloud.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnPresetCloud.ForeColor = System.Drawing.Color.White
            Me.btnPresetCloud.Location = New System.Drawing.Point(290, 80)
            Me.btnPresetCloud.Name = "btnPresetCloud"
            Me.btnPresetCloud.Size = New System.Drawing.Size(150, 36)
            Me.btnPresetCloud.TabIndex = 7
            Me.btnPresetCloud.Text = "افتراضي سحابي ☁️"
            '
            'btnPresetLocal
            '
            Me.btnPresetLocal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPresetLocal.BorderRadius = 6
            Me.btnPresetLocal.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnPresetLocal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnPresetLocal.ForeColor = System.Drawing.Color.White
            Me.btnPresetLocal.Location = New System.Drawing.Point(130, 80)
            Me.btnPresetLocal.Name = "btnPresetLocal"
            Me.btnPresetLocal.Size = New System.Drawing.Size(150, 36)
            Me.btnPresetLocal.TabIndex = 8
            Me.btnPresetLocal.Text = "افتراضي محلي (3000)"
            '
            'lblApiSecret
            '
            Me.lblApiSecret.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblApiSecret.AutoSize = True
            Me.lblApiSecret.BackColor = System.Drawing.Color.Transparent
            Me.lblApiSecret.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblApiSecret.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblApiSecret.Location = New System.Drawing.Point(1040, 130)
            Me.lblApiSecret.Name = "lblApiSecret"
            Me.lblApiSecret.Size = New System.Drawing.Size(117, 19)
            Me.lblApiSecret.TabIndex = 9
            Me.lblApiSecret.Text = "مفتاح الأمان (Secret):"
            '
            'txtApiSecret
            '
            Me.txtApiSecret.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtApiSecret.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtApiSecret.BorderRadius = 6
            Me.txtApiSecret.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.txtApiSecret.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtApiSecret.ForeColor = System.Drawing.Color.White
            Me.txtApiSecret.Location = New System.Drawing.Point(450, 125)
            Me.txtApiSecret.Name = "txtApiSecret"
            Me.txtApiSecret.Size = New System.Drawing.Size(580, 36)
            Me.txtApiSecret.TabIndex = 10
            '
            'cardAutoSend
            '
            Me.cardAutoSend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardAutoSend.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.cardAutoSend.BorderRadius = 12
            Me.cardAutoSend.BorderThickness = 1
            Me.cardAutoSend.Controls.Add(Me.lblCardAutoSendTitle)
            Me.cardAutoSend.Controls.Add(Me.lblAutoSend)
            Me.cardAutoSend.Controls.Add(Me.tglAutoSend)
            Me.cardAutoSend.Controls.Add(Me.lblFormatTitle)
            Me.cardAutoSend.Controls.Add(Me.rdoFormatText)
            Me.cardAutoSend.Controls.Add(Me.lblFormatText)
            Me.cardAutoSend.Controls.Add(Me.rdoFormatImage)
            Me.cardAutoSend.Controls.Add(Me.lblFormatImage)
            Me.cardAutoSend.Controls.Add(Me.rdoFormatPdf)
            Me.cardAutoSend.Controls.Add(Me.lblFormatPdf)
            Me.cardAutoSend.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardAutoSend.Location = New System.Drawing.Point(20, 505)
            Me.cardAutoSend.Name = "cardAutoSend"
            Me.cardAutoSend.Size = New System.Drawing.Size(1178, 115)
            Me.cardAutoSend.TabIndex = 4
            '
            'lblCardAutoSendTitle
            '
            Me.lblCardAutoSendTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardAutoSendTitle.AutoSize = True
            Me.lblCardAutoSendTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblCardAutoSendTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardAutoSendTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblCardAutoSendTitle.Location = New System.Drawing.Point(920, 15)
            Me.lblCardAutoSendTitle.Name = "lblCardAutoSendTitle"
            Me.lblCardAutoSendTitle.Size = New System.Drawing.Size(238, 21)
            Me.lblCardAutoSendTitle.TabIndex = 0
            Me.lblCardAutoSendTitle.Text = "🧾 إرسال الفواتير التلقائي للعملاء"
            '
            'lblAutoSend
            '
            Me.lblAutoSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoSend.AutoSize = True
            Me.lblAutoSend.BackColor = System.Drawing.Color.Transparent
            Me.lblAutoSend.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblAutoSend.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblAutoSend.Location = New System.Drawing.Point(820, 48)
            Me.lblAutoSend.Name = "lblAutoSend"
            Me.lblAutoSend.Size = New System.Drawing.Size(280, 20)
            Me.lblAutoSend.TabIndex = 1
            Me.lblAutoSend.Text = "إرسال الفاتورة تلقائياً للعميل عند إتمام وحفظ البيع"
            '
            'tglAutoSend
            '
            Me.tglAutoSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglAutoSend.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.tglAutoSend.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.tglAutoSend.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglAutoSend.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglAutoSend.Location = New System.Drawing.Point(1110, 46)
            Me.tglAutoSend.Name = "tglAutoSend"
            Me.tglAutoSend.Size = New System.Drawing.Size(45, 24)
            Me.tglAutoSend.TabIndex = 2
            Me.tglAutoSend.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
            Me.tglAutoSend.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.tglAutoSend.UncheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglAutoSend.UncheckedState.InnerColor = System.Drawing.Color.White
            '
            'lblFormatTitle
            '
            Me.lblFormatTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblFormatTitle.AutoSize = True
            Me.lblFormatTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblFormatTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblFormatTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblFormatTitle.Location = New System.Drawing.Point(1030, 80)
            Me.lblFormatTitle.Name = "lblFormatTitle"
            Me.lblFormatTitle.Size = New System.Drawing.Size(126, 19)
            Me.lblFormatTitle.TabIndex = 3
            Me.lblFormatTitle.Text = "صيغة إرسال الفاتورة:"
            '
            'rdoFormatText
            '
            Me.rdoFormatText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rdoFormatText.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoFormatText.CheckedState.BorderThickness = 0
            Me.rdoFormatText.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoFormatText.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rdoFormatText.Location = New System.Drawing.Point(990, 80)
            Me.rdoFormatText.Name = "rdoFormatText"
            Me.rdoFormatText.Size = New System.Drawing.Size(20, 20)
            Me.rdoFormatText.TabIndex = 4
            Me.rdoFormatText.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
            Me.rdoFormatText.UncheckedState.BorderThickness = 2
            Me.rdoFormatText.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rdoFormatText.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblFormatText
            '
            Me.lblFormatText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblFormatText.AutoSize = True
            Me.lblFormatText.BackColor = System.Drawing.Color.Transparent
            Me.lblFormatText.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblFormatText.ForeColor = System.Drawing.Color.White
            Me.lblFormatText.Location = New System.Drawing.Point(860, 81)
            Me.lblFormatText.Name = "lblFormatText"
            Me.lblFormatText.Size = New System.Drawing.Size(126, 19)
            Me.lblFormatText.TabIndex = 5
            Me.lblFormatText.Text = "رسالة نصية مفصلة 📝"
            '
            'rdoFormatImage
            '
            Me.rdoFormatImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rdoFormatImage.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoFormatImage.CheckedState.BorderThickness = 0
            Me.rdoFormatImage.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoFormatImage.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rdoFormatImage.Location = New System.Drawing.Point(815, 80)
            Me.rdoFormatImage.Name = "rdoFormatImage"
            Me.rdoFormatImage.Size = New System.Drawing.Size(20, 20)
            Me.rdoFormatImage.TabIndex = 6
            Me.rdoFormatImage.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
            Me.rdoFormatImage.UncheckedState.BorderThickness = 2
            Me.rdoFormatImage.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rdoFormatImage.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblFormatImage
            '
            Me.lblFormatImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblFormatImage.AutoSize = True
            Me.lblFormatImage.BackColor = System.Drawing.Color.Transparent
            Me.lblFormatImage.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblFormatImage.ForeColor = System.Drawing.Color.White
            Me.lblFormatImage.Location = New System.Drawing.Point(710, 81)
            Me.lblFormatImage.Name = "lblFormatImage"
            Me.lblFormatImage.Size = New System.Drawing.Size(100, 19)
            Me.lblFormatImage.TabIndex = 7
            Me.lblFormatImage.Text = "صورة الفاتورة 🖼️"
            '
            'rdoFormatPdf
            '
            Me.rdoFormatPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rdoFormatPdf.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoFormatPdf.CheckedState.BorderThickness = 0
            Me.rdoFormatPdf.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.rdoFormatPdf.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rdoFormatPdf.Location = New System.Drawing.Point(665, 80)
            Me.rdoFormatPdf.Name = "rdoFormatPdf"
            Me.rdoFormatPdf.Size = New System.Drawing.Size(20, 20)
            Me.rdoFormatPdf.TabIndex = 8
            Me.rdoFormatPdf.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
            Me.rdoFormatPdf.UncheckedState.BorderThickness = 2
            Me.rdoFormatPdf.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rdoFormatPdf.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblFormatPdf
            '
            Me.lblFormatPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblFormatPdf.AutoSize = True
            Me.lblFormatPdf.BackColor = System.Drawing.Color.Transparent
            Me.lblFormatPdf.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblFormatPdf.ForeColor = System.Drawing.Color.White
            Me.lblFormatPdf.Location = New System.Drawing.Point(565, 81)
            Me.lblFormatPdf.Name = "lblFormatPdf"
            Me.lblFormatPdf.Size = New System.Drawing.Size(95, 19)
            Me.lblFormatPdf.TabIndex = 9
            Me.lblFormatPdf.Text = "مستند PDF 📄"
            '
            'cardTemplates
            '
            Me.cardTemplates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardTemplates.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.cardTemplates.BorderRadius = 12
            Me.cardTemplates.BorderThickness = 1
            Me.cardTemplates.Controls.Add(Me.lblCardTemplatesTitle)
            Me.cardTemplates.Controls.Add(Me.lblWelcomeTemplate)
            Me.cardTemplates.Controls.Add(Me.txtWelcomeTemplate)
            Me.cardTemplates.Controls.Add(Me.lblInvoiceTemplate)
            Me.cardTemplates.Controls.Add(Me.txtInvoiceTemplate)
            Me.cardTemplates.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardTemplates.Location = New System.Drawing.Point(20, 635)
            Me.cardTemplates.Name = "cardTemplates"
            Me.cardTemplates.Size = New System.Drawing.Size(1178, 175)
            Me.cardTemplates.TabIndex = 5
            '
            'lblCardTemplatesTitle
            '
            Me.lblCardTemplatesTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardTemplatesTitle.AutoSize = True
            Me.lblCardTemplatesTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblCardTemplatesTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardTemplatesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblCardTemplatesTitle.Location = New System.Drawing.Point(920, 15)
            Me.lblCardTemplatesTitle.Name = "lblCardTemplatesTitle"
            Me.lblCardTemplatesTitle.Size = New System.Drawing.Size(238, 21)
            Me.lblCardTemplatesTitle.TabIndex = 0
            Me.lblCardTemplatesTitle.Text = "💬 قوالب الرسائل الجاهزة"
            '
            'lblWelcomeTemplate
            '
            Me.lblWelcomeTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblWelcomeTemplate.AutoSize = True
            Me.lblWelcomeTemplate.BackColor = System.Drawing.Color.Transparent
            Me.lblWelcomeTemplate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblWelcomeTemplate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblWelcomeTemplate.Location = New System.Drawing.Point(980, 48)
            Me.lblWelcomeTemplate.Name = "lblWelcomeTemplate"
            Me.lblWelcomeTemplate.Size = New System.Drawing.Size(175, 19)
            Me.lblWelcomeTemplate.TabIndex = 1
            Me.lblWelcomeTemplate.Text = "رسالة الترحيب بالعميل الجديد:"
            '
            'txtWelcomeTemplate
            '
            Me.txtWelcomeTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtWelcomeTemplate.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtWelcomeTemplate.BorderRadius = 6
            Me.txtWelcomeTemplate.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.txtWelcomeTemplate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtWelcomeTemplate.ForeColor = System.Drawing.Color.White
            Me.txtWelcomeTemplate.Location = New System.Drawing.Point(610, 75)
            Me.txtWelcomeTemplate.Multiline = True
            Me.txtWelcomeTemplate.Name = "txtWelcomeTemplate"
            Me.txtWelcomeTemplate.Size = New System.Drawing.Size(545, 80)
            Me.txtWelcomeTemplate.TabIndex = 2
            '
            'lblInvoiceTemplate
            '
            Me.lblInvoiceTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblInvoiceTemplate.AutoSize = True
            Me.lblInvoiceTemplate.BackColor = System.Drawing.Color.Transparent
            Me.lblInvoiceTemplate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblInvoiceTemplate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblInvoiceTemplate.Location = New System.Drawing.Point(230, 48)
            Me.lblInvoiceTemplate.Name = "lblInvoiceTemplate"
            Me.lblInvoiceTemplate.Size = New System.Drawing.Size(355, 19)
            Me.lblInvoiceTemplate.TabIndex = 3
            Me.lblInvoiceTemplate.Text = "نص رسالة الفاتورة ({CustomerName}, {InvoiceNo}, {Total}):"
            '
            'txtInvoiceTemplate
            '
            Me.txtInvoiceTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtInvoiceTemplate.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtInvoiceTemplate.BorderRadius = 6
            Me.txtInvoiceTemplate.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.txtInvoiceTemplate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.txtInvoiceTemplate.ForeColor = System.Drawing.Color.White
            Me.txtInvoiceTemplate.Location = New System.Drawing.Point(40, 75)
            Me.txtInvoiceTemplate.Multiline = True
            Me.txtInvoiceTemplate.Name = "txtInvoiceTemplate"
            Me.txtInvoiceTemplate.Size = New System.Drawing.Size(545, 80)
            Me.txtInvoiceTemplate.TabIndex = 4
            '
            'cardTest
            '
            Me.cardTest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardTest.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.cardTest.BorderRadius = 12
            Me.cardTest.BorderThickness = 1
            Me.cardTest.Controls.Add(Me.lblCardTestTitle)
            Me.cardTest.Controls.Add(Me.lblTestPhone)
            Me.cardTest.Controls.Add(Me.txtTestPhone)
            Me.cardTest.Controls.Add(Me.lblTestMsg)
            Me.cardTest.Controls.Add(Me.txtTestMsg)
            Me.cardTest.Controls.Add(Me.btnSendTest)
            Me.cardTest.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardTest.Location = New System.Drawing.Point(20, 825)
            Me.cardTest.Name = "cardTest"
            Me.cardTest.Size = New System.Drawing.Size(1178, 110)
            Me.cardTest.TabIndex = 6
            '
            'lblCardTestTitle
            '
            Me.lblCardTestTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardTestTitle.AutoSize = True
            Me.lblCardTestTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblCardTestTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardTestTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblCardTestTitle.Location = New System.Drawing.Point(920, 15)
            Me.lblCardTestTitle.Name = "lblCardTestTitle"
            Me.lblCardTestTitle.Size = New System.Drawing.Size(238, 21)
            Me.lblCardTestTitle.TabIndex = 0
            Me.lblCardTestTitle.Text = "🧪 تجربة إرسال رسالة سريعة"
            '
            'lblTestPhone
            '
            Me.lblTestPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTestPhone.AutoSize = True
            Me.lblTestPhone.BackColor = System.Drawing.Color.Transparent
            Me.lblTestPhone.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblTestPhone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblTestPhone.Location = New System.Drawing.Point(1075, 55)
            Me.lblTestPhone.Name = "lblTestPhone"
            Me.lblTestPhone.Size = New System.Drawing.Size(80, 19)
            Me.lblTestPhone.TabIndex = 1
            Me.lblTestPhone.Text = "رقم المستلم:"
            '
            'txtTestPhone
            '
            Me.txtTestPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTestPhone.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtTestPhone.BorderRadius = 6
            Me.txtTestPhone.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.txtTestPhone.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtTestPhone.ForeColor = System.Drawing.Color.White
            Me.txtTestPhone.Location = New System.Drawing.Point(860, 50)
            Me.txtTestPhone.Name = "txtTestPhone"
            Me.txtTestPhone.PlaceholderText = "مثال: 201012345678"
            Me.txtTestPhone.Size = New System.Drawing.Size(210, 36)
            Me.txtTestPhone.TabIndex = 2
            '
            'lblTestMsg
            '
            Me.lblTestMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTestMsg.AutoSize = True
            Me.lblTestMsg.BackColor = System.Drawing.Color.Transparent
            Me.lblTestMsg.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblTestMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblTestMsg.Location = New System.Drawing.Point(770, 55)
            Me.lblTestMsg.Name = "lblTestMsg"
            Me.lblTestMsg.Size = New System.Drawing.Size(78, 19)
            Me.lblTestMsg.TabIndex = 3
            Me.lblTestMsg.Text = "نص الرسالة:"
            '
            'txtTestMsg
            '
            Me.txtTestMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTestMsg.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtTestMsg.BorderRadius = 6
            Me.txtTestMsg.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.txtTestMsg.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtTestMsg.ForeColor = System.Drawing.Color.White
            Me.txtTestMsg.Location = New System.Drawing.Point(260, 50)
            Me.txtTestMsg.Name = "txtTestMsg"
            Me.txtTestMsg.PlaceholderText = "رسالة تجريبية من نظام سيستمك لنقاط البيع"
            Me.txtTestMsg.Size = New System.Drawing.Size(500, 36)
            Me.txtTestMsg.TabIndex = 4
            '
            'btnSendTest
            '
            Me.btnSendTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSendTest.BorderRadius = 6
            Me.btnSendTest.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSendTest.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.btnSendTest.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSendTest.ForeColor = System.Drawing.Color.White
            Me.btnSendTest.Location = New System.Drawing.Point(70, 50)
            Me.btnSendTest.Name = "btnSendTest"
            Me.btnSendTest.Size = New System.Drawing.Size(170, 36)
            Me.btnSendTest.TabIndex = 5
            Me.btnSendTest.Text = "إرسال تجربة الآن 🚀"
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BorderRadius = 8
            Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(998, 955)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(200, 45)
            Me.btnSave.TabIndex = 7
            Me.btnSave.Text = "حفظ الإعدادات 💾"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnReset.BorderRadius = 8
            Me.btnReset.BorderThickness = 1
            Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnReset.FillColor = System.Drawing.Color.Transparent
            Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnReset.Location = New System.Drawing.Point(828, 955)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(160, 45)
            Me.btnReset.TabIndex = 8
            Me.btnReset.Text = "استعادة الافتراضي ↩"
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnClose.BorderRadius = 8
            Me.btnClose.BorderThickness = 1
            Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClose.FillColor = System.Drawing.Color.Transparent
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(20, 955)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(120, 45)
            Me.btnClose.TabIndex = 9
            Me.btnClose.Text = "إغلاق ✕"
            '
            'UCWhatsAppSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Name = "UCWhatsAppSettings"
            Me.Size = New System.Drawing.Size(1238, 1020)
            Me.pnlMain.ResumeLayout(False)
            Me.pnlMain.PerformLayout()
            Me.cardStatus.ResumeLayout(False)
            Me.cardStatus.PerformLayout()
            CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardMode.ResumeLayout(False)
            Me.cardMode.PerformLayout()
            Me.cardAutoSend.ResumeLayout(False)
            Me.cardAutoSend.PerformLayout()
            Me.cardTemplates.ResumeLayout(False)
            Me.cardTemplates.PerformLayout()
            Me.cardTest.ResumeLayout(False)
            Me.cardTest.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardStatus As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardStatusTitle As System.Windows.Forms.Label
        Friend WithEvents lblStatusLabel As System.Windows.Forms.Label
        Friend WithEvents lblStatusBadge As System.Windows.Forms.Label
        Friend WithEvents lblPhoneLabel As System.Windows.Forms.Label
        Friend WithEvents lblConnectedPhone As System.Windows.Forms.Label
        Friend WithEvents picQRCode As System.Windows.Forms.PictureBox
        Friend WithEvents lblQrHint As System.Windows.Forms.Label
        Friend WithEvents btnConnect As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnResetSession As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardMode As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardModeTitle As System.Windows.Forms.Label
        Friend WithEvents rdoModeCloud As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblModeCloud As System.Windows.Forms.Label
        Friend WithEvents rdoModeLocal As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblModeLocal As System.Windows.Forms.Label
        Friend WithEvents lblServerUrl As System.Windows.Forms.Label
        Friend WithEvents txtServerUrl As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnPresetCloud As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnPresetLocal As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblApiSecret As System.Windows.Forms.Label
        Friend WithEvents txtApiSecret As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents cardAutoSend As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardAutoSendTitle As System.Windows.Forms.Label
        Friend WithEvents lblAutoSend As System.Windows.Forms.Label
        Friend WithEvents tglAutoSend As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblFormatTitle As System.Windows.Forms.Label
        Friend WithEvents rdoFormatText As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblFormatText As System.Windows.Forms.Label
        Friend WithEvents rdoFormatImage As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblFormatImage As System.Windows.Forms.Label
        Friend WithEvents rdoFormatPdf As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblFormatPdf As System.Windows.Forms.Label
        Friend WithEvents cardTemplates As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardTemplatesTitle As System.Windows.Forms.Label
        Friend WithEvents lblWelcomeTemplate As System.Windows.Forms.Label
        Friend WithEvents txtWelcomeTemplate As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblInvoiceTemplate As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceTemplate As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents cardTest As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardTestTitle As System.Windows.Forms.Label
        Friend WithEvents lblTestPhone As System.Windows.Forms.Label
        Friend WithEvents txtTestPhone As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblTestMsg As System.Windows.Forms.Label
        Friend WithEvents txtTestMsg As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnSendTest As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
