Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCSalesSettings
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
            Me.cardOrderTypes = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardOrderTypesTitle = New System.Windows.Forms.Label()
            Me.lblDineIn = New System.Windows.Forms.Label()
            Me.tglDineIn = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblTakeaway = New System.Windows.Forms.Label()
            Me.tglTakeaway = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblDelivery = New System.Windows.Forms.Label()
            Me.tglDelivery = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblDefaultOrderType = New System.Windows.Forms.Label()
            Me.cmbDefaultOrderType = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.cardTaxDiscount = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardTaxDiscountTitle = New System.Windows.Forms.Label()
            Me.lblEnableTax = New System.Windows.Forms.Label()
            Me.tglEnableTax = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblTaxPercent = New System.Windows.Forms.Label()
            Me.txtTaxPercent = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblEnableDiscount = New System.Windows.Forms.Label()
            Me.tglEnableDiscount = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblDiscountPercent = New System.Windows.Forms.Label()
            Me.txtDiscountPercent = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblDineInFee = New System.Windows.Forms.Label()
            Me.txtDineInServiceFee = New Guna.UI2.WinForms.Guna2TextBox()
            Me.btnIsDineInServiceFeePercent = New Guna.UI2.WinForms.Guna2Button()
            Me.lblInvoiceItemsPerPage = New System.Windows.Forms.Label()
            Me.txtInvoiceItemsPerPage = New Guna.UI2.WinForms.Guna2TextBox()
            Me.cardDefaults = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardDefaultsTitle = New System.Windows.Forms.Label()
            Me.lblBranches = New System.Windows.Forms.Label()
            Me.cmbBranches = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblStores = New System.Windows.Forms.Label()
            Me.cmbStores = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblTreasury = New System.Windows.Forms.Label()
            Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cmbDefaultCustomer = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblDriver = New System.Windows.Forms.Label()
            Me.cmbDefaultDriver = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.cardPayment = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardPaymentTitle = New System.Windows.Forms.Label()
            Me.chkPaymentCash = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.chkPaymentVisa = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.chkPaymentMaster = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.chkPaymentMada = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardOrderTypes.SuspendLayout()
            Me.cardTaxDiscount.SuspendLayout()
            Me.cardDefaults.SuspendLayout()
            Me.cardPayment.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardOrderTypes)
            Me.pnlMain.Controls.Add(Me.cardTaxDiscount)
            Me.pnlMain.Controls.Add(Me.cardDefaults)
            Me.pnlMain.Controls.Add(Me.cardPayment)
            Me.pnlMain.Controls.Add(Me.btnSave)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 1050)
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
            Me.lblTitle.Text = "إعدادات البيع"
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
            Me.lblSubtitle.Text = "تحديد سلوك الكاشير، أنواع الطلبات، الضرائب، والخزائن الافتراضية"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardOrderTypes
            '
            Me.cardOrderTypes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardOrderTypes.BackColor = System.Drawing.Color.Transparent
            Me.cardOrderTypes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardOrderTypes.BorderRadius = 12
            Me.cardOrderTypes.BorderThickness = 1
            Me.cardOrderTypes.Controls.Add(Me.lblCardOrderTypesTitle)
            Me.cardOrderTypes.Controls.Add(Me.lblDineIn)
            Me.cardOrderTypes.Controls.Add(Me.tglDineIn)
            Me.cardOrderTypes.Controls.Add(Me.lblTakeaway)
            Me.cardOrderTypes.Controls.Add(Me.tglTakeaway)
            Me.cardOrderTypes.Controls.Add(Me.lblDelivery)
            Me.cardOrderTypes.Controls.Add(Me.tglDelivery)
            Me.cardOrderTypes.Controls.Add(Me.lblDefaultOrderType)
            Me.cardOrderTypes.Controls.Add(Me.cmbDefaultOrderType)
            Me.cardOrderTypes.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardOrderTypes.Location = New System.Drawing.Point(30, 95)
            Me.cardOrderTypes.Name = "cardOrderTypes"
            Me.cardOrderTypes.Size = New System.Drawing.Size(1178, 175)
            Me.cardOrderTypes.TabIndex = 2
            '
            'lblCardOrderTypesTitle
            '
            Me.lblCardOrderTypesTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardOrderTypesTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardOrderTypesTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardOrderTypesTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardOrderTypesTitle.Name = "lblCardOrderTypesTitle"
            Me.lblCardOrderTypesTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardOrderTypesTitle.TabIndex = 0
            Me.lblCardOrderTypesTitle.Text = "📋 أنواع الطلبات"
            Me.lblCardOrderTypesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDineIn
            '
            Me.lblDineIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDineIn.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDineIn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDineIn.Location = New System.Drawing.Point(990, 60)
            Me.lblDineIn.Name = "lblDineIn"
            Me.lblDineIn.Size = New System.Drawing.Size(160, 30)
            Me.lblDineIn.TabIndex = 1
            Me.lblDineIn.Text = "طلب صالة:"
            Me.lblDineIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglDineIn
            '
            Me.tglDineIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglDineIn.Checked = True
            Me.tglDineIn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglDineIn.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglDineIn.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglDineIn.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglDineIn.Location = New System.Drawing.Point(910, 62)
            Me.tglDineIn.Name = "tglDineIn"
            Me.tglDineIn.Size = New System.Drawing.Size(65, 26)
            Me.tglDineIn.TabIndex = 2
            Me.tglDineIn.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglDineIn.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblTakeaway
            '
            Me.lblTakeaway.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTakeaway.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTakeaway.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblTakeaway.Location = New System.Drawing.Point(680, 60)
            Me.lblTakeaway.Name = "lblTakeaway"
            Me.lblTakeaway.Size = New System.Drawing.Size(160, 30)
            Me.lblTakeaway.TabIndex = 3
            Me.lblTakeaway.Text = "طلب سفري:"
            Me.lblTakeaway.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglTakeaway
            '
            Me.tglTakeaway.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglTakeaway.Checked = True
            Me.tglTakeaway.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglTakeaway.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglTakeaway.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglTakeaway.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglTakeaway.Location = New System.Drawing.Point(600, 62)
            Me.tglTakeaway.Name = "tglTakeaway"
            Me.tglTakeaway.Size = New System.Drawing.Size(65, 26)
            Me.tglTakeaway.TabIndex = 4
            Me.tglTakeaway.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglTakeaway.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblDelivery
            '
            Me.lblDelivery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDelivery.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDelivery.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDelivery.Location = New System.Drawing.Point(370, 60)
            Me.lblDelivery.Name = "lblDelivery"
            Me.lblDelivery.Size = New System.Drawing.Size(160, 30)
            Me.lblDelivery.TabIndex = 5
            Me.lblDelivery.Text = "طلب توصيل:"
            Me.lblDelivery.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglDelivery
            '
            Me.tglDelivery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglDelivery.Checked = True
            Me.tglDelivery.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglDelivery.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglDelivery.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglDelivery.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglDelivery.Location = New System.Drawing.Point(290, 62)
            Me.tglDelivery.Name = "tglDelivery"
            Me.tglDelivery.Size = New System.Drawing.Size(65, 26)
            Me.tglDelivery.TabIndex = 6
            Me.tglDelivery.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglDelivery.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblDefaultOrderType
            '
            Me.lblDefaultOrderType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDefaultOrderType.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDefaultOrderType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDefaultOrderType.Location = New System.Drawing.Point(920, 118)
            Me.lblDefaultOrderType.Name = "lblDefaultOrderType"
            Me.lblDefaultOrderType.Size = New System.Drawing.Size(230, 32)
            Me.lblDefaultOrderType.TabIndex = 7
            Me.lblDefaultOrderType.Text = "نوع الطلب الافتراضي للكاشير:"
            Me.lblDefaultOrderType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbDefaultOrderType
            '
            Me.cmbDefaultOrderType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbDefaultOrderType.BackColor = System.Drawing.Color.Transparent
            Me.cmbDefaultOrderType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbDefaultOrderType.BorderRadius = 8
            Me.cmbDefaultOrderType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbDefaultOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbDefaultOrderType.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbDefaultOrderType.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbDefaultOrderType.ForeColor = System.Drawing.Color.White
            Me.cmbDefaultOrderType.ItemHeight = 34
            Me.cmbDefaultOrderType.Location = New System.Drawing.Point(540, 113)
            Me.cmbDefaultOrderType.Name = "cmbDefaultOrderType"
            Me.cmbDefaultOrderType.Size = New System.Drawing.Size(360, 40)
            Me.cmbDefaultOrderType.TabIndex = 8
            '
            'cardTaxDiscount
            '
            Me.cardTaxDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardTaxDiscount.BackColor = System.Drawing.Color.Transparent
            Me.cardTaxDiscount.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardTaxDiscount.BorderRadius = 12
            Me.cardTaxDiscount.BorderThickness = 1
            Me.cardTaxDiscount.Controls.Add(Me.lblCardTaxDiscountTitle)
            Me.cardTaxDiscount.Controls.Add(Me.lblEnableTax)
            Me.cardTaxDiscount.Controls.Add(Me.tglEnableTax)
            Me.cardTaxDiscount.Controls.Add(Me.lblTaxPercent)
            Me.cardTaxDiscount.Controls.Add(Me.txtTaxPercent)
            Me.cardTaxDiscount.Controls.Add(Me.lblEnableDiscount)
            Me.cardTaxDiscount.Controls.Add(Me.tglEnableDiscount)
            Me.cardTaxDiscount.Controls.Add(Me.lblDiscountPercent)
            Me.cardTaxDiscount.Controls.Add(Me.txtDiscountPercent)
            Me.cardTaxDiscount.Controls.Add(Me.lblDineInFee)
            Me.cardTaxDiscount.Controls.Add(Me.txtDineInServiceFee)
            Me.cardTaxDiscount.Controls.Add(Me.btnIsDineInServiceFeePercent)
            Me.cardTaxDiscount.Controls.Add(Me.lblInvoiceItemsPerPage)
            Me.cardTaxDiscount.Controls.Add(Me.txtInvoiceItemsPerPage)
            Me.cardTaxDiscount.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardTaxDiscount.Location = New System.Drawing.Point(30, 290)
            Me.cardTaxDiscount.Name = "cardTaxDiscount"
            Me.cardTaxDiscount.Size = New System.Drawing.Size(1178, 220)
            Me.cardTaxDiscount.TabIndex = 3
            '
            'lblCardTaxDiscountTitle
            '
            Me.lblCardTaxDiscountTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardTaxDiscountTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardTaxDiscountTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardTaxDiscountTitle.Location = New System.Drawing.Point(820, 15)
            Me.lblCardTaxDiscountTitle.Name = "lblCardTaxDiscountTitle"
            Me.lblCardTaxDiscountTitle.Size = New System.Drawing.Size(330, 28)
            Me.lblCardTaxDiscountTitle.TabIndex = 0
            Me.lblCardTaxDiscountTitle.Text = "💰 الضرائب والخصومات ورسوم الخدمة"
            Me.lblCardTaxDiscountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblEnableTax
            '
            Me.lblEnableTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblEnableTax.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblEnableTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblEnableTax.Location = New System.Drawing.Point(990, 60)
            Me.lblEnableTax.Name = "lblEnableTax"
            Me.lblEnableTax.Size = New System.Drawing.Size(160, 30)
            Me.lblEnableTax.TabIndex = 1
            Me.lblEnableTax.Text = "تفعيل ضريبة القيمة المضافة:"
            Me.lblEnableTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglEnableTax
            '
            Me.tglEnableTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglEnableTax.Checked = True
            Me.tglEnableTax.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglEnableTax.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglEnableTax.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglEnableTax.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglEnableTax.Location = New System.Drawing.Point(910, 62)
            Me.tglEnableTax.Name = "tglEnableTax"
            Me.tglEnableTax.Size = New System.Drawing.Size(65, 26)
            Me.tglEnableTax.TabIndex = 2
            Me.tglEnableTax.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglEnableTax.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblTaxPercent
            '
            Me.lblTaxPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxPercent.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTaxPercent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblTaxPercent.Location = New System.Drawing.Point(710, 60)
            Me.lblTaxPercent.Name = "lblTaxPercent"
            Me.lblTaxPercent.Size = New System.Drawing.Size(170, 30)
            Me.lblTaxPercent.TabIndex = 3
            Me.lblTaxPercent.Text = "نسبة الضريبة (%):"
            Me.lblTaxPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTaxPercent
            '
            Me.txtTaxPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxPercent.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtTaxPercent.BorderRadius = 8
            Me.txtTaxPercent.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtTaxPercent.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtTaxPercent.ForeColor = System.Drawing.Color.White
            Me.txtTaxPercent.Location = New System.Drawing.Point(540, 56)
            Me.txtTaxPercent.Name = "txtTaxPercent"
            Me.txtTaxPercent.Size = New System.Drawing.Size(155, 38)
            Me.txtTaxPercent.TabIndex = 4
            Me.txtTaxPercent.Text = "14"
            Me.txtTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblEnableDiscount
            '
            Me.lblEnableDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblEnableDiscount.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblEnableDiscount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblEnableDiscount.Location = New System.Drawing.Point(990, 115)
            Me.lblEnableDiscount.Name = "lblEnableDiscount"
            Me.lblEnableDiscount.Size = New System.Drawing.Size(160, 30)
            Me.lblEnableDiscount.TabIndex = 5
            Me.lblEnableDiscount.Text = "إتاحة الخصم على الفاتورة:"
            Me.lblEnableDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglEnableDiscount
            '
            Me.tglEnableDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglEnableDiscount.Checked = True
            Me.tglEnableDiscount.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglEnableDiscount.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglEnableDiscount.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglEnableDiscount.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglEnableDiscount.Location = New System.Drawing.Point(910, 117)
            Me.tglEnableDiscount.Name = "tglEnableDiscount"
            Me.tglEnableDiscount.Size = New System.Drawing.Size(65, 26)
            Me.tglEnableDiscount.TabIndex = 6
            Me.tglEnableDiscount.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglEnableDiscount.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblDiscountPercent
            '
            Me.lblDiscountPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDiscountPercent.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDiscountPercent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDiscountPercent.Location = New System.Drawing.Point(710, 115)
            Me.lblDiscountPercent.Name = "lblDiscountPercent"
            Me.lblDiscountPercent.Size = New System.Drawing.Size(170, 30)
            Me.lblDiscountPercent.TabIndex = 7
            Me.lblDiscountPercent.Text = "الخصم الافتراضي (%):"
            Me.lblDiscountPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDiscountPercent
            '
            Me.txtDiscountPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDiscountPercent.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtDiscountPercent.BorderRadius = 8
            Me.txtDiscountPercent.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDiscountPercent.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDiscountPercent.ForeColor = System.Drawing.Color.White
            Me.txtDiscountPercent.Location = New System.Drawing.Point(540, 111)
            Me.txtDiscountPercent.Name = "txtDiscountPercent"
            Me.txtDiscountPercent.Size = New System.Drawing.Size(155, 38)
            Me.txtDiscountPercent.TabIndex = 8
            Me.txtDiscountPercent.Text = "0"
            Me.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblDineInFee
            '
            Me.lblDineInFee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDineInFee.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDineInFee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDineInFee.Location = New System.Drawing.Point(950, 168)
            Me.lblDineInFee.Name = "lblDineInFee"
            Me.lblDineInFee.Size = New System.Drawing.Size(200, 30)
            Me.lblDineInFee.TabIndex = 9
            Me.lblDineInFee.Text = "رسوم خدمة الصالة:"
            Me.lblDineInFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDineInServiceFee
            '
            Me.txtDineInServiceFee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDineInServiceFee.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtDineInServiceFee.BorderRadius = 8
            Me.txtDineInServiceFee.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtDineInServiceFee.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtDineInServiceFee.ForeColor = System.Drawing.Color.White
            Me.txtDineInServiceFee.Location = New System.Drawing.Point(790, 164)
            Me.txtDineInServiceFee.Name = "txtDineInServiceFee"
            Me.txtDineInServiceFee.Size = New System.Drawing.Size(145, 38)
            Me.txtDineInServiceFee.TabIndex = 10
            Me.txtDineInServiceFee.Text = "0"
            Me.txtDineInServiceFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnIsDineInServiceFeePercent
            '
            Me.btnIsDineInServiceFeePercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnIsDineInServiceFeePercent.BorderRadius = 8
            Me.btnIsDineInServiceFeePercent.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
            Me.btnIsDineInServiceFeePercent.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnIsDineInServiceFeePercent.CheckedState.ForeColor = System.Drawing.Color.White
            Me.btnIsDineInServiceFeePercent.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnIsDineInServiceFeePercent.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnIsDineInServiceFeePercent.ForeColor = System.Drawing.Color.White
            Me.btnIsDineInServiceFeePercent.Location = New System.Drawing.Point(650, 164)
            Me.btnIsDineInServiceFeePercent.Name = "btnIsDineInServiceFeePercent"
            Me.btnIsDineInServiceFeePercent.Size = New System.Drawing.Size(125, 38)
            Me.btnIsDineInServiceFeePercent.TabIndex = 11
            Me.btnIsDineInServiceFeePercent.Text = "كنسبة مئوية %"
            '
            'lblInvoiceItemsPerPage
            '
            Me.lblInvoiceItemsPerPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblInvoiceItemsPerPage.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblInvoiceItemsPerPage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblInvoiceItemsPerPage.Location = New System.Drawing.Point(440, 168)
            Me.lblInvoiceItemsPerPage.Name = "lblInvoiceItemsPerPage"
            Me.lblInvoiceItemsPerPage.Size = New System.Drawing.Size(190, 30)
            Me.lblInvoiceItemsPerPage.TabIndex = 12
            Me.lblInvoiceItemsPerPage.Text = "عدد أصناف الصفحة:"
            Me.lblInvoiceItemsPerPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInvoiceItemsPerPage
            '
            Me.txtInvoiceItemsPerPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtInvoiceItemsPerPage.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtInvoiceItemsPerPage.BorderRadius = 8
            Me.txtInvoiceItemsPerPage.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtInvoiceItemsPerPage.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtInvoiceItemsPerPage.ForeColor = System.Drawing.Color.White
            Me.txtInvoiceItemsPerPage.Location = New System.Drawing.Point(290, 164)
            Me.txtInvoiceItemsPerPage.Name = "txtInvoiceItemsPerPage"
            Me.txtInvoiceItemsPerPage.Size = New System.Drawing.Size(140, 38)
            Me.txtInvoiceItemsPerPage.TabIndex = 13
            Me.txtInvoiceItemsPerPage.Text = "25"
            Me.txtInvoiceItemsPerPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'cardDefaults
            '
            Me.cardDefaults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardDefaults.BackColor = System.Drawing.Color.Transparent
            Me.cardDefaults.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardDefaults.BorderRadius = 12
            Me.cardDefaults.BorderThickness = 1
            Me.cardDefaults.Controls.Add(Me.lblCardDefaultsTitle)
            Me.cardDefaults.Controls.Add(Me.lblBranches)
            Me.cardDefaults.Controls.Add(Me.cmbBranches)
            Me.cardDefaults.Controls.Add(Me.lblStores)
            Me.cardDefaults.Controls.Add(Me.cmbStores)
            Me.cardDefaults.Controls.Add(Me.lblTreasury)
            Me.cardDefaults.Controls.Add(Me.cmbTreasury)
            Me.cardDefaults.Controls.Add(Me.lblCustomer)
            Me.cardDefaults.Controls.Add(Me.cmbDefaultCustomer)
            Me.cardDefaults.Controls.Add(Me.lblDriver)
            Me.cardDefaults.Controls.Add(Me.cmbDefaultDriver)
            Me.cardDefaults.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardDefaults.Location = New System.Drawing.Point(30, 530)
            Me.cardDefaults.Name = "cardDefaults"
            Me.cardDefaults.Size = New System.Drawing.Size(1178, 230)
            Me.cardDefaults.TabIndex = 4
            '
            'lblCardDefaultsTitle
            '
            Me.lblCardDefaultsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardDefaultsTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardDefaultsTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardDefaultsTitle.Location = New System.Drawing.Point(820, 15)
            Me.lblCardDefaultsTitle.Name = "lblCardDefaultsTitle"
            Me.lblCardDefaultsTitle.Size = New System.Drawing.Size(330, 28)
            Me.lblCardDefaultsTitle.TabIndex = 0
            Me.lblCardDefaultsTitle.Text = "🏢 الخيارات الافتراضية للفروع والمخازن"
            Me.lblCardDefaultsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBranches
            '
            Me.lblBranches.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBranches.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblBranches.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblBranches.Location = New System.Drawing.Point(970, 60)
            Me.lblBranches.Name = "lblBranches"
            Me.lblBranches.Size = New System.Drawing.Size(180, 30)
            Me.lblBranches.TabIndex = 1
            Me.lblBranches.Text = "الفرع الافتراضي:"
            Me.lblBranches.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbBranches
            '
            Me.cmbBranches.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbBranches.BackColor = System.Drawing.Color.Transparent
            Me.cmbBranches.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbBranches.BorderRadius = 8
            Me.cmbBranches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbBranches.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbBranches.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbBranches.ForeColor = System.Drawing.Color.White
            Me.cmbBranches.ItemHeight = 34
            Me.cmbBranches.Location = New System.Drawing.Point(640, 56)
            Me.cmbBranches.Name = "cmbBranches"
            Me.cmbBranches.Size = New System.Drawing.Size(315, 40)
            Me.cmbBranches.TabIndex = 2
            '
            'lblStores
            '
            Me.lblStores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStores.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblStores.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblStores.Location = New System.Drawing.Point(460, 60)
            Me.lblStores.Name = "lblStores"
            Me.lblStores.Size = New System.Drawing.Size(160, 30)
            Me.lblStores.TabIndex = 3
            Me.lblStores.Text = "المخزن الافتراضي:"
            Me.lblStores.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbStores
            '
            Me.cmbStores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbStores.BackColor = System.Drawing.Color.Transparent
            Me.cmbStores.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbStores.BorderRadius = 8
            Me.cmbStores.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStores.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbStores.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbStores.ForeColor = System.Drawing.Color.White
            Me.cmbStores.ItemHeight = 34
            Me.cmbStores.Location = New System.Drawing.Point(130, 56)
            Me.cmbStores.Name = "cmbStores"
            Me.cmbStores.Size = New System.Drawing.Size(315, 40)
            Me.cmbStores.TabIndex = 4
            '
            'lblTreasury
            '
            Me.lblTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTreasury.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblTreasury.Location = New System.Drawing.Point(970, 115)
            Me.lblTreasury.Name = "lblTreasury"
            Me.lblTreasury.Size = New System.Drawing.Size(180, 30)
            Me.lblTreasury.TabIndex = 5
            Me.lblTreasury.Text = "الخزينة الافتراضية:"
            Me.lblTreasury.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbTreasury
            '
            Me.cmbTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbTreasury.BackColor = System.Drawing.Color.Transparent
            Me.cmbTreasury.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbTreasury.BorderRadius = 8
            Me.cmbTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTreasury.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbTreasury.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbTreasury.ForeColor = System.Drawing.Color.White
            Me.cmbTreasury.ItemHeight = 34
            Me.cmbTreasury.Location = New System.Drawing.Point(640, 111)
            Me.cmbTreasury.Name = "cmbTreasury"
            Me.cmbTreasury.Size = New System.Drawing.Size(315, 40)
            Me.cmbTreasury.TabIndex = 6
            '
            'lblCustomer
            '
            Me.lblCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCustomer.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblCustomer.Location = New System.Drawing.Point(460, 115)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(160, 30)
            Me.lblCustomer.TabIndex = 7
            Me.lblCustomer.Text = "العميل الافتراضي:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbDefaultCustomer
            '
            Me.cmbDefaultCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbDefaultCustomer.BackColor = System.Drawing.Color.Transparent
            Me.cmbDefaultCustomer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbDefaultCustomer.BorderRadius = 8
            Me.cmbDefaultCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbDefaultCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbDefaultCustomer.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbDefaultCustomer.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbDefaultCustomer.ForeColor = System.Drawing.Color.White
            Me.cmbDefaultCustomer.ItemHeight = 34
            Me.cmbDefaultCustomer.Location = New System.Drawing.Point(130, 111)
            Me.cmbDefaultCustomer.Name = "cmbDefaultCustomer"
            Me.cmbDefaultCustomer.Size = New System.Drawing.Size(315, 40)
            Me.cmbDefaultCustomer.TabIndex = 8
            '
            'lblDriver
            '
            Me.lblDriver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDriver.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDriver.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDriver.Location = New System.Drawing.Point(970, 170)
            Me.lblDriver.Name = "lblDriver"
            Me.lblDriver.Size = New System.Drawing.Size(180, 30)
            Me.lblDriver.TabIndex = 9
            Me.lblDriver.Text = "الطيار الافتراضي:"
            Me.lblDriver.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbDefaultDriver
            '
            Me.cmbDefaultDriver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbDefaultDriver.BackColor = System.Drawing.Color.Transparent
            Me.cmbDefaultDriver.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbDefaultDriver.BorderRadius = 8
            Me.cmbDefaultDriver.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbDefaultDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbDefaultDriver.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbDefaultDriver.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbDefaultDriver.ForeColor = System.Drawing.Color.White
            Me.cmbDefaultDriver.ItemHeight = 34
            Me.cmbDefaultDriver.Location = New System.Drawing.Point(640, 166)
            Me.cmbDefaultDriver.Name = "cmbDefaultDriver"
            Me.cmbDefaultDriver.Size = New System.Drawing.Size(315, 40)
            Me.cmbDefaultDriver.TabIndex = 10
            '
            'cardPayment
            '
            Me.cardPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardPayment.BackColor = System.Drawing.Color.Transparent
            Me.cardPayment.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardPayment.BorderRadius = 12
            Me.cardPayment.BorderThickness = 1
            Me.cardPayment.Controls.Add(Me.lblCardPaymentTitle)
            Me.cardPayment.Controls.Add(Me.chkPaymentCash)
            Me.cardPayment.Controls.Add(Me.chkPaymentVisa)
            Me.cardPayment.Controls.Add(Me.chkPaymentMaster)
            Me.cardPayment.Controls.Add(Me.chkPaymentMada)
            Me.cardPayment.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPayment.Location = New System.Drawing.Point(30, 780)
            Me.cardPayment.Name = "cardPayment"
            Me.cardPayment.Size = New System.Drawing.Size(1178, 125)
            Me.cardPayment.TabIndex = 5
            '
            'lblCardPaymentTitle
            '
            Me.lblCardPaymentTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardPaymentTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardPaymentTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardPaymentTitle.Location = New System.Drawing.Point(820, 15)
            Me.lblCardPaymentTitle.Name = "lblCardPaymentTitle"
            Me.lblCardPaymentTitle.Size = New System.Drawing.Size(330, 28)
            Me.lblCardPaymentTitle.TabIndex = 0
            Me.lblCardPaymentTitle.Text = "💳 طرق الدفع المتاحة"
            Me.lblCardPaymentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkPaymentCash
            '
            Me.chkPaymentCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkPaymentCash.Checked = True
            Me.chkPaymentCash.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPaymentCash.CheckedState.BorderRadius = 4
            Me.chkPaymentCash.CheckedState.BorderThickness = 0
            Me.chkPaymentCash.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPaymentCash.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPaymentCash.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkPaymentCash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkPaymentCash.Location = New System.Drawing.Point(950, 60)
            Me.chkPaymentCash.Name = "chkPaymentCash"
            Me.chkPaymentCash.Size = New System.Drawing.Size(180, 34)
            Me.chkPaymentCash.TabIndex = 1
            Me.chkPaymentCash.Text = "نقدي (كاش)"
            Me.chkPaymentCash.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkPaymentCash.UncheckedState.BorderRadius = 4
            Me.chkPaymentCash.UncheckedState.BorderThickness = 1
            Me.chkPaymentCash.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            '
            'chkPaymentVisa
            '
            Me.chkPaymentVisa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkPaymentVisa.Checked = True
            Me.chkPaymentVisa.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPaymentVisa.CheckedState.BorderRadius = 4
            Me.chkPaymentVisa.CheckedState.BorderThickness = 0
            Me.chkPaymentVisa.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPaymentVisa.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPaymentVisa.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkPaymentVisa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkPaymentVisa.Location = New System.Drawing.Point(720, 60)
            Me.chkPaymentVisa.Name = "chkPaymentVisa"
            Me.chkPaymentVisa.Size = New System.Drawing.Size(180, 34)
            Me.chkPaymentVisa.TabIndex = 2
            Me.chkPaymentVisa.Text = "فيزا (Visa)"
            Me.chkPaymentVisa.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkPaymentVisa.UncheckedState.BorderRadius = 4
            Me.chkPaymentVisa.UncheckedState.BorderThickness = 1
            Me.chkPaymentVisa.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            '
            'chkPaymentMaster
            '
            Me.chkPaymentMaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkPaymentMaster.Checked = True
            Me.chkPaymentMaster.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPaymentMaster.CheckedState.BorderRadius = 4
            Me.chkPaymentMaster.CheckedState.BorderThickness = 0
            Me.chkPaymentMaster.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPaymentMaster.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPaymentMaster.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkPaymentMaster.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkPaymentMaster.Location = New System.Drawing.Point(480, 60)
            Me.chkPaymentMaster.Name = "chkPaymentMaster"
            Me.chkPaymentMaster.Size = New System.Drawing.Size(190, 34)
            Me.chkPaymentMaster.TabIndex = 3
            Me.chkPaymentMaster.Text = "ماستركارد (MasterCard)"
            Me.chkPaymentMaster.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkPaymentMaster.UncheckedState.BorderRadius = 4
            Me.chkPaymentMaster.UncheckedState.BorderThickness = 1
            Me.chkPaymentMaster.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            '
            'chkPaymentMada
            '
            Me.chkPaymentMada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkPaymentMada.Checked = True
            Me.chkPaymentMada.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPaymentMada.CheckedState.BorderRadius = 4
            Me.chkPaymentMada.CheckedState.BorderThickness = 0
            Me.chkPaymentMada.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPaymentMada.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPaymentMada.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkPaymentMada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkPaymentMada.Location = New System.Drawing.Point(250, 60)
            Me.chkPaymentMada.Name = "chkPaymentMada"
            Me.chkPaymentMada.Size = New System.Drawing.Size(180, 34)
            Me.chkPaymentMada.TabIndex = 4
            Me.chkPaymentMada.Text = "مدى (Mada)"
            Me.chkPaymentMada.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkPaymentMada.UncheckedState.BorderRadius = 4
            Me.chkPaymentMada.UncheckedState.BorderThickness = 1
            Me.chkPaymentMada.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BorderRadius = 10
            Me.btnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(958, 930)
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
            Me.btnReset.Location = New System.Drawing.Point(740, 930)
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
            Me.btnClose.Location = New System.Drawing.Point(30, 930)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(130, 48)
            Me.btnClose.TabIndex = 8
            Me.btnClose.Text = "إغلاق"
            '
            'UCSalesSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCSalesSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 1050)
            Me.pnlMain.ResumeLayout(False)
            Me.cardOrderTypes.ResumeLayout(False)
            Me.cardTaxDiscount.ResumeLayout(False)
            Me.cardDefaults.ResumeLayout(False)
            Me.cardPayment.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardOrderTypes As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardOrderTypesTitle As System.Windows.Forms.Label
        Friend WithEvents lblDineIn As System.Windows.Forms.Label
        Friend WithEvents tglDineIn As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblTakeaway As System.Windows.Forms.Label
        Friend WithEvents tglTakeaway As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblDelivery As System.Windows.Forms.Label
        Friend WithEvents tglDelivery As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblDefaultOrderType As System.Windows.Forms.Label
        Friend WithEvents cmbDefaultOrderType As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents cardTaxDiscount As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardTaxDiscountTitle As System.Windows.Forms.Label
        Friend WithEvents lblEnableTax As System.Windows.Forms.Label
        Friend WithEvents tglEnableTax As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblTaxPercent As System.Windows.Forms.Label
        Friend WithEvents txtTaxPercent As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblEnableDiscount As System.Windows.Forms.Label
        Friend WithEvents tglEnableDiscount As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblDiscountPercent As System.Windows.Forms.Label
        Friend WithEvents txtDiscountPercent As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblDineInFee As System.Windows.Forms.Label
        Friend WithEvents txtDineInServiceFee As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnIsDineInServiceFeePercent As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblInvoiceItemsPerPage As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceItemsPerPage As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents cardDefaults As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardDefaultsTitle As System.Windows.Forms.Label
        Friend WithEvents lblBranches As System.Windows.Forms.Label
        Friend WithEvents cmbBranches As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblStores As System.Windows.Forms.Label
        Friend WithEvents cmbStores As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblTreasury As System.Windows.Forms.Label
        Friend WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cmbDefaultCustomer As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblDriver As System.Windows.Forms.Label
        Friend WithEvents cmbDefaultDriver As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents cardPayment As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardPaymentTitle As System.Windows.Forms.Label
        Friend WithEvents chkPaymentCash As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents chkPaymentVisa As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents chkPaymentMaster As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents chkPaymentMada As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
