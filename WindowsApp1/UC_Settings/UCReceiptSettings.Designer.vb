Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCReceiptSettings
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
            Me.cardShopInfo = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardShopInfoTitle = New System.Windows.Forms.Label()
            Me.lblShopName = New System.Windows.Forms.Label()
            Me.txtShopName = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblShopTax = New System.Windows.Forms.Label()
            Me.txtShopTax = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblShopPhone = New System.Windows.Forms.Label()
            Me.txtShopPhone = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblShopPhone2 = New System.Windows.Forms.Label()
            Me.txtShopPhone2 = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblShopAddress = New System.Windows.Forms.Label()
            Me.txtShopAddress = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cardLogo = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardLogoTitle = New System.Windows.Forms.Label()
            Me.lblLogoPath = New System.Windows.Forms.Label()
            Me.txtLogoPath = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnBrowseLogo = New Guna.UI2.WinForms.Guna2Button()
            Me.picLogoPreview = New System.Windows.Forms.PictureBox()
            Me.lblShowLogo = New System.Windows.Forms.Label()
            Me.tglShowLogo = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.cardDesign = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardDesignTitle = New System.Windows.Forms.Label()
            Me.lblFontSize = New System.Windows.Forms.Label()
            Me.cmbFontSize = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblReceiptStyle = New System.Windows.Forms.Label()
            Me.cmbReceiptStyle = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblShowTax = New System.Windows.Forms.Label()
            Me.tglShowTax = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblShowDiscount = New System.Windows.Forms.Label()
            Me.tglShowDiscount = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblShowCashier = New System.Windows.Forms.Label()
            Me.tglShowCashier = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.cardFooter = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardFooterTitle = New System.Windows.Forms.Label()
            Me.lblFooterText = New System.Windows.Forms.Label()
            Me.txtFooterText = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblDeliveryText = New System.Windows.Forms.Label()
            Me.txtDeliveryText = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardShopInfo.SuspendLayout()
            Me.cardLogo.SuspendLayout()
            CType(Me.picLogoPreview, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardDesign.SuspendLayout()
            Me.cardFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardShopInfo)
            Me.pnlMain.Controls.Add(Me.cardLogo)
            Me.pnlMain.Controls.Add(Me.cardDesign)
            Me.pnlMain.Controls.Add(Me.cardFooter)
            Me.pnlMain.Controls.Add(Me.btnSave)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 920)
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
            Me.lblTitle.Text = "إعدادات الفاتورة وبيانات المؤسسة"
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
            Me.lblSubtitle.Text = "تخصيص بيانات المتجر، الشعار، حجم الخط، تصميم الفاتورة، ونصوص الترحيب والتذييل"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardShopInfo
            '
            Me.cardShopInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardShopInfo.BackColor = System.Drawing.Color.Transparent
            Me.cardShopInfo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardShopInfo.BorderRadius = 12
            Me.cardShopInfo.BorderThickness = 1
            Me.cardShopInfo.Controls.Add(Me.lblCardShopInfoTitle)
            Me.cardShopInfo.Controls.Add(Me.lblShopName)
            Me.cardShopInfo.Controls.Add(Me.txtShopName)
            Me.cardShopInfo.Controls.Add(Me.lblShopTax)
            Me.cardShopInfo.Controls.Add(Me.txtShopTax)
            Me.cardShopInfo.Controls.Add(Me.lblShopPhone)
            Me.cardShopInfo.Controls.Add(Me.txtShopPhone)
            Me.cardShopInfo.Controls.Add(Me.lblShopPhone2)
            Me.cardShopInfo.Controls.Add(Me.txtShopPhone2)
            Me.cardShopInfo.Controls.Add(Me.lblShopAddress)
            Me.cardShopInfo.Controls.Add(Me.txtShopAddress)
            Me.cardShopInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardShopInfo.Location = New System.Drawing.Point(30, 95)
            Me.cardShopInfo.Name = "cardShopInfo"
            Me.cardShopInfo.Size = New System.Drawing.Size(1178, 210)
            Me.cardShopInfo.TabIndex = 2
            '
            'lblCardShopInfoTitle
            '
            Me.lblCardShopInfoTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardShopInfoTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardShopInfoTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardShopInfoTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardShopInfoTitle.Name = "lblCardShopInfoTitle"
            Me.lblCardShopInfoTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardShopInfoTitle.TabIndex = 0
            Me.lblCardShopInfoTitle.Text = "🏪 بيانات المحل / المتجر"
            Me.lblCardShopInfoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblShopName
            '
            Me.lblShopName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShopName.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShopName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShopName.Location = New System.Drawing.Point(970, 56)
            Me.lblShopName.Name = "lblShopName"
            Me.lblShopName.Size = New System.Drawing.Size(180, 32)
            Me.lblShopName.TabIndex = 1
            Me.lblShopName.Text = "اسم المحل / النشاط:"
            Me.lblShopName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShopName
            '
            Me.txtShopName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtShopName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtShopName.BorderRadius = 8
            Me.txtShopName.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtShopName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtShopName.ForeColor = System.Drawing.Color.White
            Me.txtShopName.Location = New System.Drawing.Point(620, 52)
            Me.txtShopName.Name = "txtShopName"
            Me.txtShopName.Size = New System.Drawing.Size(345, 38)
            Me.txtShopName.TabIndex = 2
            '
            'lblShopTax
            '
            Me.lblShopTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShopTax.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShopTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShopTax.Location = New System.Drawing.Point(440, 56)
            Me.lblShopTax.Name = "lblShopTax"
            Me.lblShopTax.Size = New System.Drawing.Size(160, 32)
            Me.lblShopTax.TabIndex = 3
            Me.lblShopTax.Text = "الرقم الضريبي:"
            Me.lblShopTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShopTax
            '
            Me.txtShopTax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtShopTax.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtShopTax.BorderRadius = 8
            Me.txtShopTax.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtShopTax.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtShopTax.ForeColor = System.Drawing.Color.White
            Me.txtShopTax.Location = New System.Drawing.Point(30, 52)
            Me.txtShopTax.Name = "txtShopTax"
            Me.txtShopTax.Size = New System.Drawing.Size(400, 38)
            Me.txtShopTax.TabIndex = 4
            '
            'lblShopPhone
            '
            Me.lblShopPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShopPhone.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShopPhone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShopPhone.Location = New System.Drawing.Point(970, 106)
            Me.lblShopPhone.Name = "lblShopPhone"
            Me.lblShopPhone.Size = New System.Drawing.Size(180, 32)
            Me.lblShopPhone.TabIndex = 5
            Me.lblShopPhone.Text = "رقم الهاتف 1:"
            Me.lblShopPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShopPhone
            '
            Me.txtShopPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtShopPhone.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtShopPhone.BorderRadius = 8
            Me.txtShopPhone.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtShopPhone.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtShopPhone.ForeColor = System.Drawing.Color.White
            Me.txtShopPhone.Location = New System.Drawing.Point(620, 102)
            Me.txtShopPhone.Name = "txtShopPhone"
            Me.txtShopPhone.Size = New System.Drawing.Size(345, 38)
            Me.txtShopPhone.TabIndex = 6
            '
            'lblShopPhone2
            '
            Me.lblShopPhone2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShopPhone2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShopPhone2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShopPhone2.Location = New System.Drawing.Point(440, 106)
            Me.lblShopPhone2.Name = "lblShopPhone2"
            Me.lblShopPhone2.Size = New System.Drawing.Size(160, 32)
            Me.lblShopPhone2.TabIndex = 7
            Me.lblShopPhone2.Text = "رقم الهاتف 2:"
            Me.lblShopPhone2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShopPhone2
            '
            Me.txtShopPhone2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtShopPhone2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtShopPhone2.BorderRadius = 8
            Me.txtShopPhone2.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtShopPhone2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtShopPhone2.ForeColor = System.Drawing.Color.White
            Me.txtShopPhone2.Location = New System.Drawing.Point(30, 102)
            Me.txtShopPhone2.Name = "txtShopPhone2"
            Me.txtShopPhone2.Size = New System.Drawing.Size(400, 38)
            Me.txtShopPhone2.TabIndex = 8
            '
            'lblShopAddress
            '
            Me.lblShopAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShopAddress.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShopAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShopAddress.Location = New System.Drawing.Point(970, 156)
            Me.lblShopAddress.Name = "lblShopAddress"
            Me.lblShopAddress.Size = New System.Drawing.Size(180, 32)
            Me.lblShopAddress.TabIndex = 9
            Me.lblShopAddress.Text = "العنوان:"
            Me.lblShopAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShopAddress
            '
            Me.txtShopAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtShopAddress.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtShopAddress.BorderRadius = 8
            Me.txtShopAddress.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtShopAddress.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtShopAddress.ForeColor = System.Drawing.Color.White
            Me.txtShopAddress.Location = New System.Drawing.Point(30, 152)
            Me.txtShopAddress.Name = "txtShopAddress"
            Me.txtShopAddress.Size = New System.Drawing.Size(935, 38)
            Me.txtShopAddress.TabIndex = 10
            '
            'cardLogo
            '
            Me.cardLogo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardLogo.BackColor = System.Drawing.Color.Transparent
            Me.cardLogo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardLogo.BorderRadius = 12
            Me.cardLogo.BorderThickness = 1
            Me.cardLogo.Controls.Add(Me.lblCardLogoTitle)
            Me.cardLogo.Controls.Add(Me.lblLogoPath)
            Me.cardLogo.Controls.Add(Me.txtLogoPath)
            Me.cardLogo.Controls.Add(Me.btnBrowseLogo)
            Me.cardLogo.Controls.Add(Me.picLogoPreview)
            Me.cardLogo.Controls.Add(Me.lblShowLogo)
            Me.cardLogo.Controls.Add(Me.tglShowLogo)
            Me.cardLogo.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardLogo.Location = New System.Drawing.Point(30, 320)
            Me.cardLogo.Name = "cardLogo"
            Me.cardLogo.Size = New System.Drawing.Size(1178, 155)
            Me.cardLogo.TabIndex = 3
            '
            'lblCardLogoTitle
            '
            Me.lblCardLogoTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardLogoTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardLogoTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardLogoTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardLogoTitle.Name = "lblCardLogoTitle"
            Me.lblCardLogoTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardLogoTitle.TabIndex = 0
            Me.lblCardLogoTitle.Text = "🖼️ شعار الفاتورة (Logo)"
            Me.lblCardLogoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLogoPath
            '
            Me.lblLogoPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblLogoPath.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblLogoPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblLogoPath.Location = New System.Drawing.Point(970, 56)
            Me.lblLogoPath.Name = "lblLogoPath"
            Me.lblLogoPath.Size = New System.Drawing.Size(180, 32)
            Me.lblLogoPath.TabIndex = 1
            Me.lblLogoPath.Text = "مسار صورة الشعار:"
            Me.lblLogoPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLogoPath
            '
            Me.txtLogoPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtLogoPath.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtLogoPath.BorderRadius = 8
            Me.txtLogoPath.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtLogoPath.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtLogoPath.ForeColor = System.Drawing.Color.White
            Me.txtLogoPath.Location = New System.Drawing.Point(340, 52)
            Me.txtLogoPath.Name = "txtLogoPath"
            Me.txtLogoPath.Size = New System.Drawing.Size(625, 38)
            Me.txtLogoPath.TabIndex = 2
            '
            'btnBrowseLogo
            '
            Me.btnBrowseLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnBrowseLogo.BorderRadius = 8
            Me.btnBrowseLogo.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnBrowseLogo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnBrowseLogo.ForeColor = System.Drawing.Color.White
            Me.btnBrowseLogo.Location = New System.Drawing.Point(195, 52)
            Me.btnBrowseLogo.Name = "btnBrowseLogo"
            Me.btnBrowseLogo.Size = New System.Drawing.Size(135, 38)
            Me.btnBrowseLogo.TabIndex = 3
            Me.btnBrowseLogo.Text = "📂 استعراض..."
            '
            'picLogoPreview
            '
            Me.picLogoPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.picLogoPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.picLogoPreview.Location = New System.Drawing.Point(30, 25)
            Me.picLogoPreview.Name = "picLogoPreview"
            Me.picLogoPreview.Size = New System.Drawing.Size(145, 110)
            Me.picLogoPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picLogoPreview.TabIndex = 4
            Me.picLogoPreview.TabStop = False
            '
            'lblShowLogo
            '
            Me.lblShowLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShowLogo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShowLogo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShowLogo.Location = New System.Drawing.Point(900, 106)
            Me.lblShowLogo.Name = "lblShowLogo"
            Me.lblShowLogo.Size = New System.Drawing.Size(250, 32)
            Me.lblShowLogo.TabIndex = 5
            Me.lblShowLogo.Text = "طباعة الشعار أعلى الفاتورة:"
            Me.lblShowLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglShowLogo
            '
            Me.tglShowLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglShowLogo.Checked = True
            Me.tglShowLogo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglShowLogo.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglShowLogo.Location = New System.Drawing.Point(820, 108)
            Me.tglShowLogo.Name = "tglShowLogo"
            Me.tglShowLogo.Size = New System.Drawing.Size(65, 26)
            Me.tglShowLogo.TabIndex = 6
            Me.tglShowLogo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglShowLogo.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'cardDesign
            '
            Me.cardDesign.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardDesign.BackColor = System.Drawing.Color.Transparent
            Me.cardDesign.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardDesign.BorderRadius = 12
            Me.cardDesign.BorderThickness = 1
            Me.cardDesign.Controls.Add(Me.lblCardDesignTitle)
            Me.cardDesign.Controls.Add(Me.lblFontSize)
            Me.cardDesign.Controls.Add(Me.cmbFontSize)
            Me.cardDesign.Controls.Add(Me.lblReceiptStyle)
            Me.cardDesign.Controls.Add(Me.cmbReceiptStyle)
            Me.cardDesign.Controls.Add(Me.lblShowTax)
            Me.cardDesign.Controls.Add(Me.tglShowTax)
            Me.cardDesign.Controls.Add(Me.lblShowDiscount)
            Me.cardDesign.Controls.Add(Me.tglShowDiscount)
            Me.cardDesign.Controls.Add(Me.lblShowCashier)
            Me.cardDesign.Controls.Add(Me.tglShowCashier)
            Me.cardDesign.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardDesign.Location = New System.Drawing.Point(30, 490)
            Me.cardDesign.Name = "cardDesign"
            Me.cardDesign.Size = New System.Drawing.Size(1178, 165)
            Me.cardDesign.TabIndex = 4
            '
            'lblCardDesignTitle
            '
            Me.lblCardDesignTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardDesignTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardDesignTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardDesignTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardDesignTitle.Name = "lblCardDesignTitle"
            Me.lblCardDesignTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardDesignTitle.TabIndex = 0
            Me.lblCardDesignTitle.Text = "🎨 تصميم وهيئة الفاتورة"
            Me.lblCardDesignTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFontSize
            '
            Me.lblFontSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblFontSize.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblFontSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblFontSize.Location = New System.Drawing.Point(970, 56)
            Me.lblFontSize.Name = "lblFontSize"
            Me.lblFontSize.Size = New System.Drawing.Size(180, 32)
            Me.lblFontSize.TabIndex = 1
            Me.lblFontSize.Text = "حجم خط الفاتورة:"
            Me.lblFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbFontSize
            '
            Me.cmbFontSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbFontSize.BackColor = System.Drawing.Color.Transparent
            Me.cmbFontSize.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbFontSize.BorderRadius = 8
            Me.cmbFontSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFontSize.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbFontSize.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbFontSize.ForeColor = System.Drawing.Color.White
            Me.cmbFontSize.ItemHeight = 32
            Me.cmbFontSize.Items.AddRange(New Object() {"صغير (7pt)", "متوسط (8.5pt)", "كبير (10pt)", "كبير جداً (12pt)"})
            Me.cmbFontSize.Location = New System.Drawing.Point(620, 52)
            Me.cmbFontSize.Name = "cmbFontSize"
            Me.cmbFontSize.Size = New System.Drawing.Size(345, 38)
            Me.cmbFontSize.StartIndex = 1
            Me.cmbFontSize.TabIndex = 2
            '
            'lblReceiptStyle
            '
            Me.lblReceiptStyle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblReceiptStyle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblReceiptStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblReceiptStyle.Location = New System.Drawing.Point(440, 56)
            Me.lblReceiptStyle.Name = "lblReceiptStyle"
            Me.lblReceiptStyle.Size = New System.Drawing.Size(160, 32)
            Me.lblReceiptStyle.TabIndex = 3
            Me.lblReceiptStyle.Text = "تخطيط الفاتورة:"
            Me.lblReceiptStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbReceiptStyle
            '
            Me.cmbReceiptStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbReceiptStyle.BackColor = System.Drawing.Color.Transparent
            Me.cmbReceiptStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbReceiptStyle.BorderRadius = 8
            Me.cmbReceiptStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbReceiptStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbReceiptStyle.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbReceiptStyle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbReceiptStyle.ForeColor = System.Drawing.Color.White
            Me.cmbReceiptStyle.ItemHeight = 32
            Me.cmbReceiptStyle.Items.AddRange(New Object() {"الكلاسيكي البسيط (Classic)", "الجدولي المنظم (Grid Excel)"})
            Me.cmbReceiptStyle.Location = New System.Drawing.Point(30, 52)
            Me.cmbReceiptStyle.Name = "cmbReceiptStyle"
            Me.cmbReceiptStyle.Size = New System.Drawing.Size(400, 38)
            Me.cmbReceiptStyle.StartIndex = 0
            Me.cmbReceiptStyle.TabIndex = 4
            '
            'lblShowTax
            '
            Me.lblShowTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShowTax.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShowTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShowTax.Location = New System.Drawing.Point(950, 110)
            Me.lblShowTax.Name = "lblShowTax"
            Me.lblShowTax.Size = New System.Drawing.Size(200, 30)
            Me.lblShowTax.TabIndex = 5
            Me.lblShowTax.Text = "إظهار تفاصيل الضريبة:"
            Me.lblShowTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglShowTax
            '
            Me.tglShowTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglShowTax.Checked = True
            Me.tglShowTax.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglShowTax.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglShowTax.Location = New System.Drawing.Point(870, 112)
            Me.tglShowTax.Name = "tglShowTax"
            Me.tglShowTax.Size = New System.Drawing.Size(65, 26)
            Me.tglShowTax.TabIndex = 6
            Me.tglShowTax.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglShowTax.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblShowDiscount
            '
            Me.lblShowDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShowDiscount.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShowDiscount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShowDiscount.Location = New System.Drawing.Point(640, 110)
            Me.lblShowDiscount.Name = "lblShowDiscount"
            Me.lblShowDiscount.Size = New System.Drawing.Size(180, 30)
            Me.lblShowDiscount.TabIndex = 7
            Me.lblShowDiscount.Text = "إظهار قيمة الخصم:"
            Me.lblShowDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglShowDiscount
            '
            Me.tglShowDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglShowDiscount.Checked = True
            Me.tglShowDiscount.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglShowDiscount.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglShowDiscount.Location = New System.Drawing.Point(560, 112)
            Me.tglShowDiscount.Name = "tglShowDiscount"
            Me.tglShowDiscount.Size = New System.Drawing.Size(65, 26)
            Me.tglShowDiscount.TabIndex = 8
            Me.tglShowDiscount.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglShowDiscount.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblShowCashier
            '
            Me.lblShowCashier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblShowCashier.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblShowCashier.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblShowCashier.Location = New System.Drawing.Point(320, 110)
            Me.lblShowCashier.Name = "lblShowCashier"
            Me.lblShowCashier.Size = New System.Drawing.Size(180, 30)
            Me.lblShowCashier.TabIndex = 9
            Me.lblShowCashier.Text = "إظهار اسم الكاشير:"
            Me.lblShowCashier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglShowCashier
            '
            Me.tglShowCashier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglShowCashier.Checked = True
            Me.tglShowCashier.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglShowCashier.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglShowCashier.Location = New System.Drawing.Point(240, 112)
            Me.tglShowCashier.Name = "tglShowCashier"
            Me.tglShowCashier.Size = New System.Drawing.Size(65, 26)
            Me.tglShowCashier.TabIndex = 10
            Me.tglShowCashier.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglShowCashier.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'cardFooter
            '
            Me.cardFooter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardFooter.BackColor = System.Drawing.Color.Transparent
            Me.cardFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardFooter.BorderRadius = 12
            Me.cardFooter.BorderThickness = 1
            Me.cardFooter.Controls.Add(Me.lblCardFooterTitle)
            Me.cardFooter.Controls.Add(Me.lblFooterText)
            Me.cardFooter.Controls.Add(Me.txtFooterText)
            Me.cardFooter.Controls.Add(Me.lblDeliveryText)
            Me.cardFooter.Controls.Add(Me.txtDeliveryText)
            Me.cardFooter.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardFooter.Location = New System.Drawing.Point(30, 670)
            Me.cardFooter.Name = "cardFooter"
            Me.cardFooter.Size = New System.Drawing.Size(1178, 160)
            Me.cardFooter.TabIndex = 5
            '
            'lblCardFooterTitle
            '
            Me.lblCardFooterTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardFooterTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardFooterTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardFooterTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardFooterTitle.Name = "lblCardFooterTitle"
            Me.lblCardFooterTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardFooterTitle.TabIndex = 0
            Me.lblCardFooterTitle.Text = "📝 نصوص التذييل والتوصيل"
            Me.lblCardFooterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFooterText
            '
            Me.lblFooterText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblFooterText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblFooterText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblFooterText.Location = New System.Drawing.Point(970, 56)
            Me.lblFooterText.Name = "lblFooterText"
            Me.lblFooterText.Size = New System.Drawing.Size(180, 32)
            Me.lblFooterText.TabIndex = 1
            Me.lblFooterText.Text = "رسالة التذييل والترحيب:"
            Me.lblFooterText.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFooterText
            '
            Me.txtFooterText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtFooterText.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtFooterText.BorderRadius = 8
            Me.txtFooterText.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtFooterText.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtFooterText.ForeColor = System.Drawing.Color.White
            Me.txtFooterText.Location = New System.Drawing.Point(30, 52)
            Me.txtFooterText.Name = "txtFooterText"
            Me.txtFooterText.Size = New System.Drawing.Size(935, 38)
            Me.txtFooterText.TabIndex = 2
            '
            'lblDeliveryText
            '
            Me.lblDeliveryText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDeliveryText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDeliveryText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDeliveryText.Location = New System.Drawing.Point(970, 106)
            Me.lblDeliveryText.Name = "lblDeliveryText"
            Me.lblDeliveryText.Size = New System.Drawing.Size(180, 32)
            Me.lblDeliveryText.TabIndex = 3
            Me.lblDeliveryText.Text = "ملاحظة خدمة التوصيل:"
            Me.lblDeliveryText.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDeliveryText
            '
            Me.txtDeliveryText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDeliveryText.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtDeliveryText.BorderRadius = 8
            Me.txtDeliveryText.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDeliveryText.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDeliveryText.ForeColor = System.Drawing.Color.White
            Me.txtDeliveryText.Location = New System.Drawing.Point(30, 102)
            Me.txtDeliveryText.Name = "txtDeliveryText"
            Me.txtDeliveryText.Size = New System.Drawing.Size(935, 38)
            Me.txtDeliveryText.TabIndex = 4
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BorderRadius = 8
            Me.btnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(978, 850)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(230, 48)
            Me.btnSave.TabIndex = 6
            Me.btnSave.Text = "💾 حفظ إعدادات الفاتورة"
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
            Me.btnReset.Location = New System.Drawing.Point(740, 850)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(220, 48)
            Me.btnReset.TabIndex = 7
            Me.btnReset.Text = "🔄 استعادة الافتراضي"
            '
            'btnClose
            '
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnClose.BorderRadius = 8
            Me.btnClose.BorderThickness = 1
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 850)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 48)
            Me.btnClose.TabIndex = 8
            Me.btnClose.Text = "❌ إغلاق"
            '
            'UCReceiptSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCReceiptSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 920)
            Me.pnlMain.ResumeLayout(False)
            Me.cardShopInfo.ResumeLayout(False)
            Me.cardLogo.ResumeLayout(False)
            CType(Me.picLogoPreview, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardDesign.ResumeLayout(False)
            Me.cardFooter.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardShopInfo As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardShopInfoTitle As System.Windows.Forms.Label
        Friend WithEvents lblShopName As System.Windows.Forms.Label
        Friend WithEvents txtShopName As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblShopPhone As System.Windows.Forms.Label
        Friend WithEvents txtShopPhone As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblShopPhone2 As System.Windows.Forms.Label
        Friend WithEvents txtShopPhone2 As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblShopAddress As System.Windows.Forms.Label
        Friend WithEvents txtShopAddress As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblShopTax As System.Windows.Forms.Label
        Friend WithEvents txtShopTax As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents cardLogo As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardLogoTitle As System.Windows.Forms.Label
        Friend WithEvents lblLogoPath As System.Windows.Forms.Label
        Friend WithEvents txtLogoPath As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnBrowseLogo As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents picLogoPreview As System.Windows.Forms.PictureBox
        Friend WithEvents lblShowLogo As System.Windows.Forms.Label
        Friend WithEvents tglShowLogo As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents cardDesign As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardDesignTitle As System.Windows.Forms.Label
        Friend WithEvents lblFontSize As System.Windows.Forms.Label
        Friend WithEvents cmbFontSize As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblReceiptStyle As System.Windows.Forms.Label
        Friend WithEvents cmbReceiptStyle As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblShowTax As System.Windows.Forms.Label
        Friend WithEvents tglShowTax As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblShowDiscount As System.Windows.Forms.Label
        Friend WithEvents tglShowDiscount As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblShowCashier As System.Windows.Forms.Label
        Friend WithEvents tglShowCashier As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents cardFooter As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardFooterTitle As System.Windows.Forms.Label
        Friend WithEvents lblFooterText As System.Windows.Forms.Label
        Friend WithEvents txtFooterText As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblDeliveryText As System.Windows.Forms.Label
        Friend WithEvents txtDeliveryText As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
