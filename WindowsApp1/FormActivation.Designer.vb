<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormActivation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(Me.components)
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.pnlContainer = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlFooter = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblDeveloper = New System.Windows.Forms.Label()
        Me.cardActivationInput = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnCheckOnline = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Staff = New Guna.UI2.WinForms.Guna2Button()
        Me.lblStatusMessage = New System.Windows.Forms.Label()
        Me.btnPaste = New Guna.UI2.WinForms.Guna2Button()
        Me.txtLicense = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblLicenseDesc = New System.Windows.Forms.Label()
        Me.lblLicenseTitle = New System.Windows.Forms.Label()
        Me.cardHardwareID = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnSupport = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCopyHwid = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlHwidBox = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblHWID = New System.Windows.Forms.Label()
        Me.lblHwidDesc = New System.Windows.Forms.Label()
        Me.lblHwidTitle = New System.Windows.Forms.Label()
        Me.pnlQrContainer = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblQrHint = New System.Windows.Forms.Label()
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.progressActivation = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblStatusBadge = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_min = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_close = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnHeaderIcon = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlContainer.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.cardActivationInput.SuspendLayout()
        Me.cardHardwareID.SuspendLayout()
        Me.pnlHwidBox.SuspendLayout()
        Me.pnlQrContainer.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 18
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'Guna2ShadowForm1
        '
        Me.Guna2ShadowForm1.BorderRadius = 18
        Me.Guna2ShadowForm1.TargetForm = Me
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2DragControl1.TargetControl = Me.panelHeader
        Me.Guna2DragControl1.UseTransparentDrag = True
        '
        'pnlContainer
        '
        Me.pnlContainer.BackColor = System.Drawing.Color.Transparent
        Me.pnlContainer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.pnlContainer.BorderRadius = 18
        Me.pnlContainer.BorderThickness = 1
        Me.pnlContainer.Controls.Add(Me.pnlFooter)
        Me.pnlContainer.Controls.Add(Me.cardActivationInput)
        Me.pnlContainer.Controls.Add(Me.cardHardwareID)
        Me.pnlContainer.Controls.Add(Me.progressActivation)
        Me.pnlContainer.Controls.Add(Me.panelHeader)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(720, 590)
        Me.pnlContainer.TabIndex = 0
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.Transparent
        Me.pnlFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.pnlFooter.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.pnlFooter.CustomBorderThickness = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.pnlFooter.Controls.Add(Me.lblDeveloper)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.pnlFooter.Location = New System.Drawing.Point(0, 546)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(720, 44)
        Me.pnlFooter.TabIndex = 4
        '
        'lblDeveloper
        '
        Me.lblDeveloper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDeveloper.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblDeveloper.Location = New System.Drawing.Point(0, 0)
        Me.lblDeveloper.Name = "lblDeveloper"
        Me.lblDeveloper.Size = New System.Drawing.Size(720, 44)
        Me.lblDeveloper.TabIndex = 0
        Me.lblDeveloper.Text = "نظام سستمك لإدارة المطاعم ونقاط البيع | تم التطوير بواسطة م. عمار أحمد - 01281637066"
        Me.lblDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cardActivationInput
        '
        Me.cardActivationInput.BackColor = System.Drawing.Color.Transparent
        Me.cardActivationInput.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardActivationInput.BorderRadius = 14
        Me.cardActivationInput.BorderThickness = 1
        Me.cardActivationInput.Controls.Add(Me.btnCheckOnline)
        Me.cardActivationInput.Controls.Add(Me.btn_Staff)
        Me.cardActivationInput.Controls.Add(Me.lblStatusMessage)
        Me.cardActivationInput.Controls.Add(Me.btnPaste)
        Me.cardActivationInput.Controls.Add(Me.txtLicense)
        Me.cardActivationInput.Controls.Add(Me.lblLicenseDesc)
        Me.cardActivationInput.Controls.Add(Me.lblLicenseTitle)
        Me.cardActivationInput.FillColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.cardActivationInput.Location = New System.Drawing.Point(18, 304)
        Me.cardActivationInput.Name = "cardActivationInput"
        Me.cardActivationInput.Size = New System.Drawing.Size(684, 228)
        Me.cardActivationInput.TabIndex = 3
        '
        'btnCheckOnline
        '
        Me.btnCheckOnline.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnCheckOnline.BorderRadius = 10
        Me.btnCheckOnline.BorderThickness = 1
        Me.btnCheckOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckOnline.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnCheckOnline.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCheckOnline.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.btnCheckOnline.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnCheckOnline.Location = New System.Drawing.Point(20, 154)
        Me.btnCheckOnline.Name = "btnCheckOnline"
        Me.btnCheckOnline.Size = New System.Drawing.Size(180, 52)
        Me.btnCheckOnline.TabIndex = 6
        Me.btnCheckOnline.Text = "فحص السيرفر أونلاين"
        '
        'btn_Staff
        '
        Me.btn_Staff.BorderRadius = 10
        Me.btn_Staff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Staff.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btn_Staff.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_Staff.ForeColor = System.Drawing.Color.White
        Me.btn_Staff.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btn_Staff.Location = New System.Drawing.Point(210, 154)
        Me.btn_Staff.Name = "btn_Staff"
        Me.btn_Staff.Size = New System.Drawing.Size(454, 52)
        Me.btn_Staff.TabIndex = 5
        Me.btn_Staff.Text = "تأكيد وتفعيل الترخيص الآن"
        '
        'lblStatusMessage
        '
        Me.lblStatusMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblStatusMessage.Location = New System.Drawing.Point(20, 118)
        Me.lblStatusMessage.Name = "lblStatusMessage"
        Me.lblStatusMessage.Size = New System.Drawing.Size(644, 24)
        Me.lblStatusMessage.TabIndex = 4
        Me.lblStatusMessage.Text = "يتم فحص وتأكيد التفعيل بشكل فوري عبر خادم التراخيص السحابي المعتمد"
        Me.lblStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPaste
        '
        Me.btnPaste.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnPaste.BorderRadius = 10
        Me.btnPaste.BorderThickness = 1
        Me.btnPaste.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPaste.FillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnPaste.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnPaste.ForeColor = System.Drawing.Color.White
        Me.btnPaste.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPaste.Location = New System.Drawing.Point(20, 66)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(130, 46)
        Me.btnPaste.TabIndex = 3
        Me.btnPaste.Text = "لصق الكود"
        '
        'txtLicense
        '
        Me.txtLicense.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.txtLicense.BorderRadius = 10
        Me.txtLicense.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLicense.DefaultText = ""
        Me.txtLicense.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.txtLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.txtLicense.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.txtLicense.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtLicense.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtLicense.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtLicense.ForeColor = System.Drawing.Color.White
        Me.txtLicense.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtLicense.Location = New System.Drawing.Point(160, 66)
        Me.txtLicense.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLicense.Name = "txtLicense"
        Me.txtLicense.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.txtLicense.PlaceholderText = "XXXXX-XXXXX-XXXXX-XXXXX"
        Me.txtLicense.SelectedText = ""
        Me.txtLicense.Size = New System.Drawing.Size(504, 46)
        Me.txtLicense.TabIndex = 2
        Me.txtLicense.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLicenseDesc
        '
        Me.lblLicenseDesc.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblLicenseDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblLicenseDesc.Location = New System.Drawing.Point(20, 38)
        Me.lblLicenseDesc.Name = "lblLicenseDesc"
        Me.lblLicenseDesc.Size = New System.Drawing.Size(644, 20)
        Me.lblLicenseDesc.TabIndex = 1
        Me.lblLicenseDesc.Text = "الصق أو اكتب كود التفعيل المستلم بدقة لتفعيل نسختك فوريًا:"
        Me.lblLicenseDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLicenseTitle
        '
        Me.lblLicenseTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblLicenseTitle.ForeColor = System.Drawing.Color.White
        Me.lblLicenseTitle.Location = New System.Drawing.Point(20, 14)
        Me.lblLicenseTitle.Name = "lblLicenseTitle"
        Me.lblLicenseTitle.Size = New System.Drawing.Size(644, 24)
        Me.lblLicenseTitle.TabIndex = 0
        Me.lblLicenseTitle.Text = "كود الترخيص والتفعيل (License Key)"
        Me.lblLicenseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cardHardwareID
        '
        Me.cardHardwareID.BackColor = System.Drawing.Color.Transparent
        Me.cardHardwareID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardHardwareID.BorderRadius = 14
        Me.cardHardwareID.BorderThickness = 1
        Me.cardHardwareID.Controls.Add(Me.btnSupport)
        Me.cardHardwareID.Controls.Add(Me.btnCopyHwid)
        Me.cardHardwareID.Controls.Add(Me.pnlHwidBox)
        Me.cardHardwareID.Controls.Add(Me.lblHwidDesc)
        Me.cardHardwareID.Controls.Add(Me.lblHwidTitle)
        Me.cardHardwareID.Controls.Add(Me.pnlQrContainer)
        Me.cardHardwareID.FillColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.cardHardwareID.Location = New System.Drawing.Point(18, 92)
        Me.cardHardwareID.Name = "cardHardwareID"
        Me.cardHardwareID.Size = New System.Drawing.Size(684, 202)
        Me.cardHardwareID.TabIndex = 2
        '
        'btnSupport
        '
        Me.btnSupport.BorderRadius = 10
        Me.btnSupport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSupport.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.btnSupport.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnSupport.ForeColor = System.Drawing.Color.White
        Me.btnSupport.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnSupport.Location = New System.Drawing.Point(164, 130)
        Me.btnSupport.Name = "btnSupport"
        Me.btnSupport.Size = New System.Drawing.Size(246, 44)
        Me.btnSupport.TabIndex = 5
        Me.btnSupport.Text = "إرسال للدعم الفني (WhatsApp)"
        '
        'btnCopyHwid
        '
        Me.btnCopyHwid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnCopyHwid.BorderRadius = 10
        Me.btnCopyHwid.BorderThickness = 1
        Me.btnCopyHwid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopyHwid.FillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnCopyHwid.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCopyHwid.ForeColor = System.Drawing.Color.White
        Me.btnCopyHwid.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnCopyHwid.Location = New System.Drawing.Point(420, 130)
        Me.btnCopyHwid.Name = "btnCopyHwid"
        Me.btnCopyHwid.Size = New System.Drawing.Size(248, 44)
        Me.btnCopyHwid.TabIndex = 4
        Me.btnCopyHwid.Text = "نسخ معرف الجهاز"
        '
        'pnlHwidBox
        '
        Me.pnlHwidBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.pnlHwidBox.BorderRadius = 10
        Me.pnlHwidBox.BorderThickness = 1
        Me.pnlHwidBox.Controls.Add(Me.lblHWID)
        Me.pnlHwidBox.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlHwidBox.Location = New System.Drawing.Point(164, 64)
        Me.pnlHwidBox.Name = "pnlHwidBox"
        Me.pnlHwidBox.Size = New System.Drawing.Size(504, 56)
        Me.pnlHwidBox.TabIndex = 3
        '
        'lblHWID
        '
        Me.lblHWID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHWID.Font = New System.Drawing.Font("Consolas", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblHWID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.lblHWID.Location = New System.Drawing.Point(0, 0)
        Me.lblHWID.Name = "lblHWID"
        Me.lblHWID.Size = New System.Drawing.Size(504, 56)
        Me.lblHWID.TabIndex = 0
        Me.lblHWID.Text = "HWID-XXXX-XXXX-XXXX-XXXX"
        Me.lblHWID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHwidDesc
        '
        Me.lblHwidDesc.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblHwidDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblHwidDesc.Location = New System.Drawing.Point(164, 38)
        Me.lblHwidDesc.Name = "lblHwidDesc"
        Me.lblHwidDesc.Size = New System.Drawing.Size(504, 20)
        Me.lblHwidDesc.TabIndex = 2
        Me.lblHwidDesc.Text = "معرّف رقمي فريد خاص بهذا الجهاز، شاركه مع الدعم الفني لإصدار وتثبيت ترخيصك:"
        Me.lblHwidDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHwidTitle
        '
        Me.lblHwidTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblHwidTitle.ForeColor = System.Drawing.Color.White
        Me.lblHwidTitle.Location = New System.Drawing.Point(164, 14)
        Me.lblHwidTitle.Name = "lblHwidTitle"
        Me.lblHwidTitle.Size = New System.Drawing.Size(504, 24)
        Me.lblHwidTitle.TabIndex = 1
        Me.lblHwidTitle.Text = "معرّف بصمة الجهاز (Hardware ID)"
        Me.lblHwidTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlQrContainer
        '
        Me.pnlQrContainer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.pnlQrContainer.BorderRadius = 12
        Me.pnlQrContainer.BorderThickness = 1
        Me.pnlQrContainer.Controls.Add(Me.lblQrHint)
        Me.pnlQrContainer.Controls.Add(Me.picQRCode)
        Me.pnlQrContainer.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlQrContainer.Location = New System.Drawing.Point(16, 16)
        Me.pnlQrContainer.Name = "pnlQrContainer"
        Me.pnlQrContainer.Size = New System.Drawing.Size(136, 170)
        Me.pnlQrContainer.TabIndex = 0
        '
        'lblQrHint
        '
        Me.lblQrHint.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblQrHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblQrHint.Location = New System.Drawing.Point(4, 130)
        Me.lblQrHint.Name = "lblQrHint"
        Me.lblQrHint.Size = New System.Drawing.Size(128, 28)
        Me.lblQrHint.TabIndex = 1
        Me.lblQrHint.Text = "مسح سريع للهاتف"
        Me.lblQrHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picQRCode
        '
        Me.picQRCode.BackColor = System.Drawing.Color.White
        Me.picQRCode.Location = New System.Drawing.Point(12, 12)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(112, 112)
        Me.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQRCode.TabIndex = 0
        Me.picQRCode.TabStop = False
        '
        'progressActivation
        '
        Me.progressActivation.BorderRadius = 2
        Me.progressActivation.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.progressActivation.Location = New System.Drawing.Point(0, 78)
        Me.progressActivation.Name = "progressActivation"
        Me.progressActivation.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.progressActivation.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.progressActivation.Size = New System.Drawing.Size(720, 5)
        Me.progressActivation.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressActivation.TabIndex = 1
        Me.progressActivation.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.progressActivation.Visible = False
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.Transparent
        Me.panelHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.panelHeader.BorderThickness = 1
        Me.panelHeader.Controls.Add(Me.lblStatusBadge)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.lblSubtitle)
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Controls.Add(Me.btnHeaderIcon)
        Me.panelHeader.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.panelHeader.CustomBorderThickness = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.FillColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(720, 78)
        Me.panelHeader.TabIndex = 0
        '
        'lblStatusBadge
        '
        Me.lblStatusBadge.BorderRadius = 8
        Me.lblStatusBadge.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatusBadge.FillColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.lblStatusBadge.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusBadge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblStatusBadge.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.lblStatusBadge.HoverState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblStatusBadge.Location = New System.Drawing.Point(96, 24)
        Me.lblStatusBadge.Name = "lblStatusBadge"
        Me.lblStatusBadge.Size = New System.Drawing.Size(100, 30)
        Me.lblStatusBadge.TabIndex = 5
        Me.lblStatusBadge.Text = "يلزم التفعيل"
        '
        'btn_min
        '
        Me.btn_min.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btn_min.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_min.FillColor = System.Drawing.Color.Transparent
        Me.btn_min.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_min.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_min.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_min.Location = New System.Drawing.Point(52, 14)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.Size = New System.Drawing.Size(34, 34)
        Me.btn_min.TabIndex = 4
        '
        'btn_close
        '
        Me.btn_close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_close.FillColor = System.Drawing.Color.Transparent
        Me.btn_close.HoverState.FillColor = System.Drawing.Color.FromArgb(239, 68, 68)
        Me.btn_close.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_close.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_close.Location = New System.Drawing.Point(14, 14)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(34, 34)
        Me.btn_close.TabIndex = 3
        '
        'lblSubtitle
        '
        Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(210, 44)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(430, 22)
        Me.lblSubtitle.TabIndex = 2
        Me.lblSubtitle.Text = "أدخل مفتاح الترخيص المعتمد أو شارك معرّف الجهاز مع خدمة العملاء للتفعيل الفوري"
        Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 13.5!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(210, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(430, 28)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "تفعيل ترخيص سستمك - Sestamk POS"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnHeaderIcon
        '
        Me.btnHeaderIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHeaderIcon.BorderRadius = 23
        Me.btnHeaderIcon.DisabledState.BorderColor = System.Drawing.Color.Transparent
        Me.btnHeaderIcon.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent
        Me.btnHeaderIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnHeaderIcon.DisabledState.ForeColor = System.Drawing.Color.White
        Me.btnHeaderIcon.Enabled = False
        Me.btnHeaderIcon.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnHeaderIcon.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.btnHeaderIcon.ForeColor = System.Drawing.Color.White
        Me.btnHeaderIcon.Location = New System.Drawing.Point(656, 16)
        Me.btnHeaderIcon.Name = "btnHeaderIcon"
        Me.btnHeaderIcon.Size = New System.Drawing.Size(46, 46)
        Me.btnHeaderIcon.TabIndex = 0
        Me.btnHeaderIcon.Text = "★"
        '
        'FormActivation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(720, 590)
        Me.Controls.Add(Me.pnlContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormActivation"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تفعيل البرنامج"
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlFooter.ResumeLayout(False)
        Me.cardActivationInput.ResumeLayout(False)
        Me.cardHardwareID.ResumeLayout(False)
        Me.pnlHwidBox.ResumeLayout(False)
        Me.pnlQrContainer.ResumeLayout(False)
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents pnlContainer As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnHeaderIcon As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents lblStatusBadge As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents progressActivation As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents cardHardwareID As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlQrContainer As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents picQRCode As PictureBox
    Friend WithEvents lblQrHint As Label
    Friend WithEvents lblHwidTitle As Label
    Friend WithEvents lblHwidDesc As Label
    Friend WithEvents pnlHwidBox As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblHWID As Label
    Friend WithEvents btnCopyHwid As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSupport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cardActivationInput As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblLicenseTitle As Label
    Friend WithEvents lblLicenseDesc As Label
    Friend WithEvents txtLicense As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnPaste As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblStatusMessage As Label
    Friend WithEvents btn_Staff As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCheckOnline As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlFooter As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblDeveloper As Label
End Class
