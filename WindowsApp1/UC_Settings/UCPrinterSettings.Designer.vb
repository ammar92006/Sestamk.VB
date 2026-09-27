Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCPrinterSettings
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
            Me.cardPrinters = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardPrintersTitle = New System.Windows.Forms.Label()
            Me.lblThermalPrinter = New System.Windows.Forms.Label()
            Me.cmbThermalPrinter = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.btnTestThermal = New Guna.UI2.WinForms.Guna2Button()
            Me.btnRefreshPrinters = New Guna.UI2.WinForms.Guna2Button()
            Me.lblKitchenPrinter = New System.Windows.Forms.Label()
            Me.cmbKitchenPrinter = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.btnTestKitchen = New Guna.UI2.WinForms.Guna2Button()
            Me.lblNormalPrinter = New System.Windows.Forms.Label()
            Me.cmbNormalPrinter = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblBarcodePrinter = New System.Windows.Forms.Label()
            Me.cmbBarcodePrinter = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.cardPaperSize = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardPaperSizeTitle = New System.Windows.Forms.Label()
            Me.lblPaperSize = New System.Windows.Forms.Label()
            Me.rbSize80 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblSize80 = New System.Windows.Forms.Label()
            Me.rbSize58 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblSize58 = New System.Windows.Forms.Label()
            Me.rbSizeA4 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblSizeA4 = New System.Windows.Forms.Label()
            Me.cardOptions = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardOptionsTitle = New System.Windows.Forms.Label()
            Me.chkPrintLogo = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.chkPrintBarcode = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.cmbBarcodeType = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.chkPrintPreview = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.lblAutoPrint = New System.Windows.Forms.Label()
            Me.tglAutoPrint = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblOpenDrawer = New System.Windows.Forms.Label()
            Me.tglOpenDrawer = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblCopies = New System.Windows.Forms.Label()
            Me.txtCopies = New Guna.UI2.WinForms.Guna2TextBox()
            Me.lblAutoPrintKitchen = New System.Windows.Forms.Label()
            Me.tglAutoPrintKitchen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblAutoPrintFollowUp = New System.Windows.Forms.Label()
            Me.tglAutoPrintFollowUp = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblKitchenDesign = New System.Windows.Forms.Label()
            Me.cmbKitchenDesign = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardPrinters.SuspendLayout()
            Me.cardPaperSize.SuspendLayout()
            Me.cardOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardPrinters)
            Me.pnlMain.Controls.Add(Me.cardPaperSize)
            Me.pnlMain.Controls.Add(Me.cardOptions)
            Me.pnlMain.Controls.Add(Me.btnSave)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 815)
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
            Me.lblTitle.Text = "إعدادات الطابعة والطباعة"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.lblSubtitle.Text = "إدارة طابعات الفواتير والتقارير، مقاس الورق، نمط الطباعة، والتحكم في درج النقدية"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardPrinters
            '
            Me.cardPrinters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardPrinters.BackColor = System.Drawing.Color.Transparent
            Me.cardPrinters.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardPrinters.BorderRadius = 12
            Me.cardPrinters.BorderThickness = 1
            Me.cardPrinters.Controls.Add(Me.lblCardPrintersTitle)
            Me.cardPrinters.Controls.Add(Me.lblThermalPrinter)
            Me.cardPrinters.Controls.Add(Me.cmbThermalPrinter)
            Me.cardPrinters.Controls.Add(Me.btnTestThermal)
            Me.cardPrinters.Controls.Add(Me.btnRefreshPrinters)
            Me.cardPrinters.Controls.Add(Me.lblKitchenPrinter)
            Me.cardPrinters.Controls.Add(Me.cmbKitchenPrinter)
            Me.cardPrinters.Controls.Add(Me.btnTestKitchen)
            Me.cardPrinters.Controls.Add(Me.lblNormalPrinter)
            Me.cardPrinters.Controls.Add(Me.cmbNormalPrinter)
            Me.cardPrinters.Controls.Add(Me.lblBarcodePrinter)
            Me.cardPrinters.Controls.Add(Me.cmbBarcodePrinter)
            Me.cardPrinters.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPrinters.Location = New System.Drawing.Point(30, 95)
            Me.cardPrinters.Name = "cardPrinters"
            Me.cardPrinters.Size = New System.Drawing.Size(1178, 280)
            Me.cardPrinters.TabIndex = 2
            '
            'lblCardPrintersTitle
            '
            Me.lblCardPrintersTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardPrintersTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardPrintersTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardPrintersTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardPrintersTitle.Name = "lblCardPrintersTitle"
            Me.lblCardPrintersTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardPrintersTitle.TabIndex = 0
            Me.lblCardPrintersTitle.Text = "🖨️ اختيار الطابعات الافتراضية"
            Me.lblCardPrintersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblThermalPrinter
            '
            Me.lblThermalPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblThermalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblThermalPrinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblThermalPrinter.Location = New System.Drawing.Point(970, 56)
            Me.lblThermalPrinter.Name = "lblThermalPrinter"
            Me.lblThermalPrinter.Size = New System.Drawing.Size(180, 32)
            Me.lblThermalPrinter.TabIndex = 1
            Me.lblThermalPrinter.Text = "طابعة الفواتير (حرارية):"
            Me.lblThermalPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbThermalPrinter
            '
            Me.cmbThermalPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbThermalPrinter.BackColor = System.Drawing.Color.Transparent
            Me.cmbThermalPrinter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbThermalPrinter.BorderRadius = 8
            Me.cmbThermalPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbThermalPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbThermalPrinter.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbThermalPrinter.FocusedColor = System.Drawing.Color.Empty
            Me.cmbThermalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbThermalPrinter.ForeColor = System.Drawing.Color.White
            Me.cmbThermalPrinter.ItemHeight = 32
            Me.cmbThermalPrinter.Location = New System.Drawing.Point(360, 52)
            Me.cmbThermalPrinter.Name = "cmbThermalPrinter"
            Me.cmbThermalPrinter.Size = New System.Drawing.Size(600, 38)
            Me.cmbThermalPrinter.TabIndex = 2
            '
            'btnTestThermal
            '
            Me.btnTestThermal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnTestThermal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnTestThermal.BorderRadius = 8
            Me.btnTestThermal.BorderThickness = 1
            Me.btnTestThermal.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnTestThermal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnTestThermal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnTestThermal.Location = New System.Drawing.Point(35, 52)
            Me.btnTestThermal.Name = "btnTestThermal"
            Me.btnTestThermal.Size = New System.Drawing.Size(150, 38)
            Me.btnTestThermal.TabIndex = 4
            Me.btnTestThermal.Text = "🖨️ تجربة الطباعة"
            '
            'btnRefreshPrinters
            '
            Me.btnRefreshPrinters.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRefreshPrinters.BorderRadius = 8
            Me.btnRefreshPrinters.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnRefreshPrinters.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnRefreshPrinters.ForeColor = System.Drawing.Color.White
            Me.btnRefreshPrinters.Location = New System.Drawing.Point(195, 52)
            Me.btnRefreshPrinters.Name = "btnRefreshPrinters"
            Me.btnRefreshPrinters.Size = New System.Drawing.Size(150, 38)
            Me.btnRefreshPrinters.TabIndex = 3
            Me.btnRefreshPrinters.Text = "🔄 تحديث القائمة"
            '
            'lblKitchenPrinter
            '
            Me.lblKitchenPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblKitchenPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblKitchenPrinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblKitchenPrinter.Location = New System.Drawing.Point(970, 110)
            Me.lblKitchenPrinter.Name = "lblKitchenPrinter"
            Me.lblKitchenPrinter.Size = New System.Drawing.Size(180, 32)
            Me.lblKitchenPrinter.TabIndex = 5
            Me.lblKitchenPrinter.Text = "طابعة المطبخ (KOT):"
            Me.lblKitchenPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbKitchenPrinter
            '
            Me.cmbKitchenPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbKitchenPrinter.BackColor = System.Drawing.Color.Transparent
            Me.cmbKitchenPrinter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbKitchenPrinter.BorderRadius = 8
            Me.cmbKitchenPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbKitchenPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbKitchenPrinter.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbKitchenPrinter.FocusedColor = System.Drawing.Color.Empty
            Me.cmbKitchenPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbKitchenPrinter.ForeColor = System.Drawing.Color.White
            Me.cmbKitchenPrinter.ItemHeight = 32
            Me.cmbKitchenPrinter.Location = New System.Drawing.Point(360, 106)
            Me.cmbKitchenPrinter.Name = "cmbKitchenPrinter"
            Me.cmbKitchenPrinter.Size = New System.Drawing.Size(600, 38)
            Me.cmbKitchenPrinter.TabIndex = 6
            '
            'btnTestKitchen
            '
            Me.btnTestKitchen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnTestKitchen.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnTestKitchen.BorderRadius = 8
            Me.btnTestKitchen.BorderThickness = 1
            Me.btnTestKitchen.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnTestKitchen.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnTestKitchen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnTestKitchen.Location = New System.Drawing.Point(35, 106)
            Me.btnTestKitchen.Name = "btnTestKitchen"
            Me.btnTestKitchen.Size = New System.Drawing.Size(150, 38)
            Me.btnTestKitchen.TabIndex = 7
            Me.btnTestKitchen.Text = "🍳 تجربة المطبخ"
            '
            'lblNormalPrinter
            '
            Me.lblNormalPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblNormalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblNormalPrinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblNormalPrinter.Location = New System.Drawing.Point(970, 164)
            Me.lblNormalPrinter.Name = "lblNormalPrinter"
            Me.lblNormalPrinter.Size = New System.Drawing.Size(180, 32)
            Me.lblNormalPrinter.TabIndex = 8
            Me.lblNormalPrinter.Text = "طابعة التقارير (A4):"
            Me.lblNormalPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbNormalPrinter
            '
            Me.cmbNormalPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbNormalPrinter.BackColor = System.Drawing.Color.Transparent
            Me.cmbNormalPrinter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbNormalPrinter.BorderRadius = 8
            Me.cmbNormalPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbNormalPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbNormalPrinter.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbNormalPrinter.FocusedColor = System.Drawing.Color.Empty
            Me.cmbNormalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbNormalPrinter.ForeColor = System.Drawing.Color.White
            Me.cmbNormalPrinter.ItemHeight = 32
            Me.cmbNormalPrinter.Location = New System.Drawing.Point(360, 160)
            Me.cmbNormalPrinter.Name = "cmbNormalPrinter"
            Me.cmbNormalPrinter.Size = New System.Drawing.Size(600, 38)
            Me.cmbNormalPrinter.TabIndex = 9
            '
            'lblBarcodePrinter
            '
            Me.lblBarcodePrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBarcodePrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblBarcodePrinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblBarcodePrinter.Location = New System.Drawing.Point(970, 218)
            Me.lblBarcodePrinter.Name = "lblBarcodePrinter"
            Me.lblBarcodePrinter.Size = New System.Drawing.Size(180, 32)
            Me.lblBarcodePrinter.TabIndex = 10
            Me.lblBarcodePrinter.Text = "طابعة الباركود (ملصقات):"
            Me.lblBarcodePrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbBarcodePrinter
            '
            Me.cmbBarcodePrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbBarcodePrinter.BackColor = System.Drawing.Color.Transparent
            Me.cmbBarcodePrinter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbBarcodePrinter.BorderRadius = 8
            Me.cmbBarcodePrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbBarcodePrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbBarcodePrinter.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbBarcodePrinter.FocusedColor = System.Drawing.Color.Empty
            Me.cmbBarcodePrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbBarcodePrinter.ForeColor = System.Drawing.Color.White
            Me.cmbBarcodePrinter.ItemHeight = 32
            Me.cmbBarcodePrinter.Location = New System.Drawing.Point(360, 214)
            Me.cmbBarcodePrinter.Name = "cmbBarcodePrinter"
            Me.cmbBarcodePrinter.Size = New System.Drawing.Size(600, 38)
            Me.cmbBarcodePrinter.TabIndex = 11
            '
            'cardPaperSize
            '
            Me.cardPaperSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardPaperSize.BackColor = System.Drawing.Color.Transparent
            Me.cardPaperSize.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardPaperSize.BorderRadius = 12
            Me.cardPaperSize.BorderThickness = 1
            Me.cardPaperSize.Controls.Add(Me.lblCardPaperSizeTitle)
            Me.cardPaperSize.Controls.Add(Me.lblPaperSize)
            Me.cardPaperSize.Controls.Add(Me.rbSize80)
            Me.cardPaperSize.Controls.Add(Me.lblSize80)
            Me.cardPaperSize.Controls.Add(Me.rbSize58)
            Me.cardPaperSize.Controls.Add(Me.lblSize58)
            Me.cardPaperSize.Controls.Add(Me.rbSizeA4)
            Me.cardPaperSize.Controls.Add(Me.lblSizeA4)
            Me.cardPaperSize.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPaperSize.Location = New System.Drawing.Point(30, 390)
            Me.cardPaperSize.Name = "cardPaperSize"
            Me.cardPaperSize.Size = New System.Drawing.Size(1178, 115)
            Me.cardPaperSize.TabIndex = 3
            '
            'lblCardPaperSizeTitle
            '
            Me.lblCardPaperSizeTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardPaperSizeTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardPaperSizeTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardPaperSizeTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardPaperSizeTitle.Name = "lblCardPaperSizeTitle"
            Me.lblCardPaperSizeTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardPaperSizeTitle.TabIndex = 0
            Me.lblCardPaperSizeTitle.Text = "📄 مقاس ورق الفاتورة"
            Me.lblCardPaperSizeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPaperSize
            '
            Me.lblPaperSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPaperSize.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPaperSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblPaperSize.Location = New System.Drawing.Point(970, 60)
            Me.lblPaperSize.Name = "lblPaperSize"
            Me.lblPaperSize.Size = New System.Drawing.Size(180, 30)
            Me.lblPaperSize.TabIndex = 1
            Me.lblPaperSize.Text = "مقاس ورق الفاتورة:"
            Me.lblPaperSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rbSize80
            '
            Me.rbSize80.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rbSize80.Checked = True
            Me.rbSize80.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbSize80.CheckedState.BorderThickness = 0
            Me.rbSize80.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbSize80.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rbSize80.Location = New System.Drawing.Point(935, 65)
            Me.rbSize80.Name = "rbSize80"
            Me.rbSize80.Size = New System.Drawing.Size(20, 20)
            Me.rbSize80.TabIndex = 2
            Me.rbSize80.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.rbSize80.UncheckedState.BorderThickness = 2
            Me.rbSize80.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rbSize80.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblSize80
            '
            Me.lblSize80.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSize80.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSize80.ForeColor = System.Drawing.Color.White
            Me.lblSize80.Location = New System.Drawing.Point(795, 60)
            Me.lblSize80.Name = "lblSize80"
            Me.lblSize80.Size = New System.Drawing.Size(130, 30)
            Me.lblSize80.TabIndex = 3
            Me.lblSize80.Text = "80 مم (قياسي)"
            Me.lblSize80.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rbSize58
            '
            Me.rbSize58.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rbSize58.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbSize58.CheckedState.BorderThickness = 0
            Me.rbSize58.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbSize58.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rbSize58.Location = New System.Drawing.Point(755, 65)
            Me.rbSize58.Name = "rbSize58"
            Me.rbSize58.Size = New System.Drawing.Size(20, 20)
            Me.rbSize58.TabIndex = 4
            Me.rbSize58.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.rbSize58.UncheckedState.BorderThickness = 2
            Me.rbSize58.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rbSize58.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblSize58
            '
            Me.lblSize58.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSize58.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSize58.ForeColor = System.Drawing.Color.White
            Me.lblSize58.Location = New System.Drawing.Point(625, 60)
            Me.lblSize58.Name = "lblSize58"
            Me.lblSize58.Size = New System.Drawing.Size(120, 30)
            Me.lblSize58.TabIndex = 5
            Me.lblSize58.Text = "58 مم (صغير)"
            Me.lblSize58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rbSizeA4
            '
            Me.rbSizeA4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rbSizeA4.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbSizeA4.CheckedState.BorderThickness = 0
            Me.rbSizeA4.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbSizeA4.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rbSizeA4.Location = New System.Drawing.Point(585, 65)
            Me.rbSizeA4.Name = "rbSizeA4"
            Me.rbSizeA4.Size = New System.Drawing.Size(20, 20)
            Me.rbSizeA4.TabIndex = 6
            Me.rbSizeA4.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.rbSizeA4.UncheckedState.BorderThickness = 2
            Me.rbSizeA4.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rbSizeA4.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblSizeA4
            '
            Me.lblSizeA4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSizeA4.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSizeA4.ForeColor = System.Drawing.Color.White
            Me.lblSizeA4.Location = New System.Drawing.Point(465, 60)
            Me.lblSizeA4.Name = "lblSizeA4"
            Me.lblSizeA4.Size = New System.Drawing.Size(110, 30)
            Me.lblSizeA4.TabIndex = 7
            Me.lblSizeA4.Text = "A4 (كبير)"
            Me.lblSizeA4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardOptions
            '
            Me.cardOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardOptions.BackColor = System.Drawing.Color.Transparent
            Me.cardOptions.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardOptions.BorderRadius = 12
            Me.cardOptions.BorderThickness = 1
            Me.cardOptions.Controls.Add(Me.lblCardOptionsTitle)
            Me.cardOptions.Controls.Add(Me.chkPrintLogo)
            Me.cardOptions.Controls.Add(Me.chkPrintBarcode)
            Me.cardOptions.Controls.Add(Me.cmbBarcodeType)
            Me.cardOptions.Controls.Add(Me.chkPrintPreview)
            Me.cardOptions.Controls.Add(Me.lblAutoPrint)
            Me.cardOptions.Controls.Add(Me.tglAutoPrint)
            Me.cardOptions.Controls.Add(Me.lblOpenDrawer)
            Me.cardOptions.Controls.Add(Me.tglOpenDrawer)
            Me.cardOptions.Controls.Add(Me.lblCopies)
            Me.cardOptions.Controls.Add(Me.txtCopies)
            Me.cardOptions.Controls.Add(Me.lblAutoPrintKitchen)
            Me.cardOptions.Controls.Add(Me.tglAutoPrintKitchen)
            Me.cardOptions.Controls.Add(Me.lblAutoPrintFollowUp)
            Me.cardOptions.Controls.Add(Me.tglAutoPrintFollowUp)
            Me.cardOptions.Controls.Add(Me.lblKitchenDesign)
            Me.cardOptions.Controls.Add(Me.cmbKitchenDesign)
            Me.cardOptions.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardOptions.Location = New System.Drawing.Point(30, 520)
            Me.cardOptions.Name = "cardOptions"
            Me.cardOptions.Size = New System.Drawing.Size(1178, 235)
            Me.cardOptions.TabIndex = 4
            '
            'lblCardOptionsTitle
            '
            Me.lblCardOptionsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardOptionsTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardOptionsTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardOptionsTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardOptionsTitle.Name = "lblCardOptionsTitle"
            Me.lblCardOptionsTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardOptionsTitle.TabIndex = 0
            Me.lblCardOptionsTitle.Text = "⚙️ خيارات الفاتورة ودرج النقدية"
            Me.lblCardOptionsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkPrintLogo
            '
            Me.chkPrintLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkPrintLogo.Checked = True
            Me.chkPrintLogo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPrintLogo.CheckedState.BorderRadius = 4
            Me.chkPrintLogo.CheckedState.BorderThickness = 0
            Me.chkPrintLogo.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPrintLogo.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPrintLogo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkPrintLogo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkPrintLogo.Location = New System.Drawing.Point(920, 58)
            Me.chkPrintLogo.Name = "chkPrintLogo"
            Me.chkPrintLogo.Size = New System.Drawing.Size(225, 30)
            Me.chkPrintLogo.TabIndex = 1
            Me.chkPrintLogo.Text = "طباعة الشعار على الفاتورة"
            Me.chkPrintLogo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkPrintLogo.UncheckedState.BorderRadius = 4
            Me.chkPrintLogo.UncheckedState.BorderThickness = 1
            Me.chkPrintLogo.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            '
            'chkPrintBarcode
            '
            Me.chkPrintBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkPrintBarcode.Checked = True
            Me.chkPrintBarcode.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPrintBarcode.CheckedState.BorderRadius = 4
            Me.chkPrintBarcode.CheckedState.BorderThickness = 0
            Me.chkPrintBarcode.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPrintBarcode.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPrintBarcode.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkPrintBarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkPrintBarcode.Location = New System.Drawing.Point(680, 58)
            Me.chkPrintBarcode.Name = "chkPrintBarcode"
            Me.chkPrintBarcode.Size = New System.Drawing.Size(225, 30)
            Me.chkPrintBarcode.TabIndex = 2
            Me.chkPrintBarcode.Text = "طباعة الباركود على الفاتورة"
            Me.chkPrintBarcode.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkPrintBarcode.UncheckedState.BorderRadius = 4
            Me.chkPrintBarcode.UncheckedState.BorderThickness = 1
            Me.chkPrintBarcode.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            '
            'cmbBarcodeType
            '
            Me.cmbBarcodeType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbBarcodeType.BackColor = System.Drawing.Color.Transparent
            Me.cmbBarcodeType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbBarcodeType.BorderRadius = 6
            Me.cmbBarcodeType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbBarcodeType.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbBarcodeType.FocusedColor = System.Drawing.Color.Empty
            Me.cmbBarcodeType.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.cmbBarcodeType.ForeColor = System.Drawing.Color.White
            Me.cmbBarcodeType.ItemHeight = 24
            Me.cmbBarcodeType.Items.AddRange(New Object() {"2D (QR Code)", "1D (Code 128)"})
            Me.cmbBarcodeType.Location = New System.Drawing.Point(510, 56)
            Me.cmbBarcodeType.Name = "cmbBarcodeType"
            Me.cmbBarcodeType.Size = New System.Drawing.Size(155, 30)
            Me.cmbBarcodeType.TabIndex = 3
            Me.cmbBarcodeType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'chkPrintPreview
            '
            Me.chkPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkPrintPreview.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPrintPreview.CheckedState.BorderRadius = 4
            Me.chkPrintPreview.CheckedState.BorderThickness = 0
            Me.chkPrintPreview.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkPrintPreview.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.chkPrintPreview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkPrintPreview.Location = New System.Drawing.Point(230, 58)
            Me.chkPrintPreview.Name = "chkPrintPreview"
            Me.chkPrintPreview.Size = New System.Drawing.Size(260, 30)
            Me.chkPrintPreview.TabIndex = 4
            Me.chkPrintPreview.Text = "معاينة الفاتورة قبل الطباعة"
            Me.chkPrintPreview.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkPrintPreview.UncheckedState.BorderRadius = 4
            Me.chkPrintPreview.UncheckedState.BorderThickness = 1
            Me.chkPrintPreview.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            '
            'lblAutoPrint
            '
            Me.lblAutoPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoPrint.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblAutoPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblAutoPrint.Location = New System.Drawing.Point(920, 115)
            Me.lblAutoPrint.Name = "lblAutoPrint"
            Me.lblAutoPrint.Size = New System.Drawing.Size(230, 30)
            Me.lblAutoPrint.TabIndex = 4
            Me.lblAutoPrint.Text = "طباعة تلقائية بعد كل بيع:"
            Me.lblAutoPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglAutoPrint
            '
            Me.tglAutoPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglAutoPrint.Checked = True
            Me.tglAutoPrint.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoPrint.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoPrint.Location = New System.Drawing.Point(845, 117)
            Me.tglAutoPrint.Name = "tglAutoPrint"
            Me.tglAutoPrint.Size = New System.Drawing.Size(65, 26)
            Me.tglAutoPrint.TabIndex = 5
            Me.tglAutoPrint.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglAutoPrint.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblOpenDrawer
            '
            Me.lblOpenDrawer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblOpenDrawer.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblOpenDrawer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblOpenDrawer.Location = New System.Drawing.Point(540, 115)
            Me.lblOpenDrawer.Name = "lblOpenDrawer"
            Me.lblOpenDrawer.Size = New System.Drawing.Size(260, 30)
            Me.lblOpenDrawer.TabIndex = 6
            Me.lblOpenDrawer.Text = "فتح درج النقدية تلقائياً عند السداد:"
            Me.lblOpenDrawer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglOpenDrawer
            '
            Me.tglOpenDrawer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglOpenDrawer.Checked = True
            Me.tglOpenDrawer.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglOpenDrawer.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglOpenDrawer.Location = New System.Drawing.Point(465, 117)
            Me.tglOpenDrawer.Name = "tglOpenDrawer"
            Me.tglOpenDrawer.Size = New System.Drawing.Size(65, 26)
            Me.tglOpenDrawer.TabIndex = 7
            Me.tglOpenDrawer.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglOpenDrawer.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblCopies
            '
            Me.lblCopies.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCopies.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCopies.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblCopies.Location = New System.Drawing.Point(240, 115)
            Me.lblCopies.Name = "lblCopies"
            Me.lblCopies.Size = New System.Drawing.Size(160, 30)
            Me.lblCopies.TabIndex = 8
            Me.lblCopies.Text = "عدد النسخ المطبوعة:"
            Me.lblCopies.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCopies
            '
            Me.txtCopies.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtCopies.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtCopies.BorderRadius = 8
            Me.txtCopies.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtCopies.DefaultText = "1"
            Me.txtCopies.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtCopies.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtCopies.ForeColor = System.Drawing.Color.White
            Me.txtCopies.Location = New System.Drawing.Point(120, 111)
            Me.txtCopies.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtCopies.Name = "txtCopies"
            Me.txtCopies.PlaceholderText = ""
            Me.txtCopies.SelectedText = ""
            Me.txtCopies.Size = New System.Drawing.Size(110, 38)
            Me.txtCopies.TabIndex = 9
            Me.txtCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblAutoPrintKitchen
            '
            Me.lblAutoPrintKitchen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoPrintKitchen.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblAutoPrintKitchen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblAutoPrintKitchen.Location = New System.Drawing.Point(920, 168)
            Me.lblAutoPrintKitchen.Name = "lblAutoPrintKitchen"
            Me.lblAutoPrintKitchen.Size = New System.Drawing.Size(230, 30)
            Me.lblAutoPrintKitchen.TabIndex = 10
            Me.lblAutoPrintKitchen.Text = "طباعة تلقائي طلب تجهيز المطبخ:"
            Me.lblAutoPrintKitchen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglAutoPrintKitchen
            '
            Me.tglAutoPrintKitchen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglAutoPrintKitchen.Checked = True
            Me.tglAutoPrintKitchen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoPrintKitchen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoPrintKitchen.Location = New System.Drawing.Point(845, 170)
            Me.tglAutoPrintKitchen.Name = "tglAutoPrintKitchen"
            Me.tglAutoPrintKitchen.Size = New System.Drawing.Size(65, 26)
            Me.tglAutoPrintKitchen.TabIndex = 11
            Me.tglAutoPrintKitchen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglAutoPrintKitchen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblAutoPrintFollowUp
            '
            Me.lblAutoPrintFollowUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoPrintFollowUp.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblAutoPrintFollowUp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblAutoPrintFollowUp.Location = New System.Drawing.Point(620, 168)
            Me.lblAutoPrintFollowUp.Name = "lblAutoPrintFollowUp"
            Me.lblAutoPrintFollowUp.Size = New System.Drawing.Size(210, 30)
            Me.lblAutoPrintFollowUp.TabIndex = 12
            Me.lblAutoPrintFollowUp.Text = "طباعة تلقائي طلب المتابعة:"
            Me.lblAutoPrintFollowUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglAutoPrintFollowUp
            '
            Me.tglAutoPrintFollowUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglAutoPrintFollowUp.Checked = True
            Me.tglAutoPrintFollowUp.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoPrintFollowUp.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglAutoPrintFollowUp.Location = New System.Drawing.Point(545, 170)
            Me.tglAutoPrintFollowUp.Name = "tglAutoPrintFollowUp"
            Me.tglAutoPrintFollowUp.Size = New System.Drawing.Size(65, 26)
            Me.tglAutoPrintFollowUp.TabIndex = 13
            Me.tglAutoPrintFollowUp.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglAutoPrintFollowUp.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblKitchenDesign
            '
            Me.lblKitchenDesign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblKitchenDesign.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblKitchenDesign.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblKitchenDesign.Location = New System.Drawing.Point(375, 168)
            Me.lblKitchenDesign.Name = "lblKitchenDesign"
            Me.lblKitchenDesign.Size = New System.Drawing.Size(155, 30)
            Me.lblKitchenDesign.TabIndex = 14
            Me.lblKitchenDesign.Text = "تصميم بون المطبخ:"
            Me.lblKitchenDesign.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbKitchenDesign
            '
            Me.cmbKitchenDesign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbKitchenDesign.BackColor = System.Drawing.Color.Transparent
            Me.cmbKitchenDesign.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbKitchenDesign.BorderRadius = 8
            Me.cmbKitchenDesign.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbKitchenDesign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbKitchenDesign.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbKitchenDesign.FocusedColor = System.Drawing.Color.Empty
            Me.cmbKitchenDesign.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.cmbKitchenDesign.ForeColor = System.Drawing.Color.White
            Me.cmbKitchenDesign.ItemHeight = 30
            Me.cmbKitchenDesign.Items.AddRange(New Object() {"التصميم 1 (كلاسيكي مدمج)", "التصميم 2 (حديث وبطاقات مقسمة)"})
            Me.cmbKitchenDesign.Location = New System.Drawing.Point(60, 164)
            Me.cmbKitchenDesign.Name = "cmbKitchenDesign"
            Me.cmbKitchenDesign.Size = New System.Drawing.Size(305, 36)
            Me.cmbKitchenDesign.StartIndex = 0
            Me.cmbKitchenDesign.TabIndex = 15
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BorderRadius = 8
            Me.btnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(978, 775)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(230, 48)
            Me.btnSave.TabIndex = 5
            Me.btnSave.Text = "💾 حفظ إعدادات الطابعة"
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
            Me.btnReset.Location = New System.Drawing.Point(740, 775)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(220, 48)
            Me.btnReset.TabIndex = 6
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
            Me.btnClose.Location = New System.Drawing.Point(30, 775)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 48)
            Me.btnClose.TabIndex = 7
            Me.btnClose.Text = "❌ إغلاق"
            '
            'UCPrinterSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCPrinterSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 805)
            Me.pnlMain.ResumeLayout(False)
            Me.cardPrinters.ResumeLayout(False)
            Me.cardPaperSize.ResumeLayout(False)
            Me.cardOptions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardPrinters As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardPrintersTitle As System.Windows.Forms.Label
        Friend WithEvents lblThermalPrinter As System.Windows.Forms.Label
        Friend WithEvents cmbThermalPrinter As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblKitchenPrinter As System.Windows.Forms.Label
        Friend WithEvents cmbKitchenPrinter As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnTestKitchen As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblNormalPrinter As System.Windows.Forms.Label
        Friend WithEvents cmbNormalPrinter As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblBarcodePrinter As System.Windows.Forms.Label
        Friend WithEvents cmbBarcodePrinter As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnRefreshPrinters As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnTestThermal As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardPaperSize As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardPaperSizeTitle As System.Windows.Forms.Label
        Friend WithEvents lblPaperSize As System.Windows.Forms.Label
        Friend WithEvents rbSize80 As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblSize80 As System.Windows.Forms.Label
        Friend WithEvents rbSize58 As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblSize58 As System.Windows.Forms.Label
        Friend WithEvents rbSizeA4 As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblSizeA4 As System.Windows.Forms.Label
        Friend WithEvents cardOptions As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardOptionsTitle As System.Windows.Forms.Label
        Friend WithEvents chkPrintLogo As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents chkPrintBarcode As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents cmbBarcodeType As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents chkPrintPreview As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents lblAutoPrint As System.Windows.Forms.Label
        Friend WithEvents tglAutoPrint As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblOpenDrawer As System.Windows.Forms.Label
        Friend WithEvents tglOpenDrawer As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblCopies As System.Windows.Forms.Label
        Friend WithEvents txtCopies As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents lblAutoPrintKitchen As System.Windows.Forms.Label
        Friend WithEvents tglAutoPrintKitchen As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblAutoPrintFollowUp As System.Windows.Forms.Label
        Friend WithEvents tglAutoPrintFollowUp As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblKitchenDesign As System.Windows.Forms.Label
        Friend WithEvents cmbKitchenDesign As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
