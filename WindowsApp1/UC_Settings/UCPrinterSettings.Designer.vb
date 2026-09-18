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
            Me.lblNormalPrinter = New System.Windows.Forms.Label()
            Me.cmbNormalPrinter = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.cardPaperSize = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardPaperSizeTitle = New System.Windows.Forms.Label()
            Me.lblPaperSize = New System.Windows.Forms.Label()
            Me.rbSize80 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblSize80 = New System.Windows.Forms.Label()
            Me.rbSize58 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblSize58 = New System.Windows.Forms.Label()
            Me.rbSizeA4 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblSizeA4 = New System.Windows.Forms.Label()
            Me.lblPrintStyle = New System.Windows.Forms.Label()
            Me.rbStyleSimple = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblStyleSimple = New System.Windows.Forms.Label()
            Me.rbStyleAdvanced = New Guna.UI2.WinForms.Guna2CustomRadioButton()
            Me.lblStyleAdvanced = New System.Windows.Forms.Label()
            Me.cardOptions = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardOptionsTitle = New System.Windows.Forms.Label()
            Me.chkPrintLogo = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.chkPrintBarcode = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.chkPrintPreview = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.lblAutoPrint = New System.Windows.Forms.Label()
            Me.tglAutoPrint = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblOpenDrawer = New System.Windows.Forms.Label()
            Me.tglOpenDrawer = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblCopies = New System.Windows.Forms.Label()
            Me.txtCopies = New Guna.UI2.WinForms.Guna2TextBox()
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
            Me.pnlMain.Size = New System.Drawing.Size(1238, 760)
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
            Me.lblSubtitle.Text = "إدارة طابعات الفواتير والتقارير، مقاس الورق، نمط الطباعة، والتحكم في درج النقدية"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cardPrinters.Controls.Add(Me.lblNormalPrinter)
            Me.cardPrinters.Controls.Add(Me.cmbNormalPrinter)
            Me.cardPrinters.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPrinters.Location = New System.Drawing.Point(30, 95)
            Me.cardPrinters.Name = "cardPrinters"
            Me.cardPrinters.Size = New System.Drawing.Size(1178, 175)
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
            Me.cmbThermalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbThermalPrinter.ForeColor = System.Drawing.Color.White
            Me.cmbThermalPrinter.ItemHeight = 32
            Me.cmbThermalPrinter.Location = New System.Drawing.Point(360, 52)
            Me.cmbThermalPrinter.Name = "cmbThermalPrinter"
            Me.cmbThermalPrinter.Size = New System.Drawing.Size(600, 38)
            Me.cmbThermalPrinter.TabIndex = 2
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
            'btnTestThermal
            '
            Me.btnTestThermal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnTestThermal.BorderRadius = 8
            Me.btnTestThermal.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnTestThermal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnTestThermal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnTestThermal.Location = New System.Drawing.Point(35, 52)
            Me.btnTestThermal.Name = "btnTestThermal"
            Me.btnTestThermal.Size = New System.Drawing.Size(150, 38)
            Me.btnTestThermal.TabIndex = 4
            Me.btnTestThermal.Text = "🖨️ تجربة الطباعة"
            '
            'lblNormalPrinter
            '
            Me.lblNormalPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblNormalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblNormalPrinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblNormalPrinter.Location = New System.Drawing.Point(970, 114)
            Me.lblNormalPrinter.Name = "lblNormalPrinter"
            Me.lblNormalPrinter.Size = New System.Drawing.Size(180, 32)
            Me.lblNormalPrinter.TabIndex = 5
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
            Me.cmbNormalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbNormalPrinter.ForeColor = System.Drawing.Color.White
            Me.cmbNormalPrinter.ItemHeight = 32
            Me.cmbNormalPrinter.Location = New System.Drawing.Point(360, 110)
            Me.cmbNormalPrinter.Name = "cmbNormalPrinter"
            Me.cmbNormalPrinter.Size = New System.Drawing.Size(600, 38)
            Me.cmbNormalPrinter.TabIndex = 6
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
            Me.cardPaperSize.Controls.Add(Me.lblPrintStyle)
            Me.cardPaperSize.Controls.Add(Me.rbStyleSimple)
            Me.cardPaperSize.Controls.Add(Me.lblStyleSimple)
            Me.cardPaperSize.Controls.Add(Me.rbStyleAdvanced)
            Me.cardPaperSize.Controls.Add(Me.lblStyleAdvanced)
            Me.cardPaperSize.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPaperSize.Location = New System.Drawing.Point(30, 285)
            Me.cardPaperSize.Name = "cardPaperSize"
            Me.cardPaperSize.Size = New System.Drawing.Size(1178, 175)
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
            Me.lblCardPaperSizeTitle.Text = "📄 مقاس الورق ونمط الطباعة"
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
            'lblPrintStyle
            '
            Me.lblPrintStyle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPrintStyle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPrintStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblPrintStyle.Location = New System.Drawing.Point(970, 115)
            Me.lblPrintStyle.Name = "lblPrintStyle"
            Me.lblPrintStyle.Size = New System.Drawing.Size(180, 30)
            Me.lblPrintStyle.TabIndex = 8
            Me.lblPrintStyle.Text = "نمط وتصميم الفاتورة:"
            Me.lblPrintStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rbStyleSimple
            '
            Me.rbStyleSimple.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rbStyleSimple.Checked = True
            Me.rbStyleSimple.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbStyleSimple.CheckedState.BorderThickness = 0
            Me.rbStyleSimple.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbStyleSimple.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rbStyleSimple.Location = New System.Drawing.Point(935, 120)
            Me.rbStyleSimple.Name = "rbStyleSimple"
            Me.rbStyleSimple.Size = New System.Drawing.Size(20, 20)
            Me.rbStyleSimple.TabIndex = 9
            Me.rbStyleSimple.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.rbStyleSimple.UncheckedState.BorderThickness = 2
            Me.rbStyleSimple.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rbStyleSimple.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblStyleSimple
            '
            Me.lblStyleSimple.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStyleSimple.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblStyleSimple.ForeColor = System.Drawing.Color.White
            Me.lblStyleSimple.Location = New System.Drawing.Point(765, 115)
            Me.lblStyleSimple.Name = "lblStyleSimple"
            Me.lblStyleSimple.Size = New System.Drawing.Size(160, 30)
            Me.lblStyleSimple.TabIndex = 10
            Me.lblStyleSimple.Text = "ستايل 1 (بسيط وواضح)"
            Me.lblStyleSimple.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rbStyleAdvanced
            '
            Me.rbStyleAdvanced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.rbStyleAdvanced.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbStyleAdvanced.CheckedState.BorderThickness = 0
            Me.rbStyleAdvanced.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.rbStyleAdvanced.CheckedState.InnerColor = System.Drawing.Color.White
            Me.rbStyleAdvanced.Location = New System.Drawing.Point(715, 120)
            Me.rbStyleAdvanced.Name = "rbStyleAdvanced"
            Me.rbStyleAdvanced.Size = New System.Drawing.Size(20, 20)
            Me.rbStyleAdvanced.TabIndex = 11
            Me.rbStyleAdvanced.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.rbStyleAdvanced.UncheckedState.BorderThickness = 2
            Me.rbStyleAdvanced.UncheckedState.FillColor = System.Drawing.Color.Transparent
            Me.rbStyleAdvanced.UncheckedState.InnerColor = System.Drawing.Color.Transparent
            '
            'lblStyleAdvanced
            '
            Me.lblStyleAdvanced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStyleAdvanced.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblStyleAdvanced.ForeColor = System.Drawing.Color.White
            Me.lblStyleAdvanced.Location = New System.Drawing.Point(545, 115)
            Me.lblStyleAdvanced.Name = "lblStyleAdvanced"
            Me.lblStyleAdvanced.Size = New System.Drawing.Size(160, 30)
            Me.lblStyleAdvanced.TabIndex = 12
            Me.lblStyleAdvanced.Text = "ستايل 2 (مفصل وشامل)"
            Me.lblStyleAdvanced.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cardOptions.Controls.Add(Me.chkPrintPreview)
            Me.cardOptions.Controls.Add(Me.lblAutoPrint)
            Me.cardOptions.Controls.Add(Me.tglAutoPrint)
            Me.cardOptions.Controls.Add(Me.lblOpenDrawer)
            Me.cardOptions.Controls.Add(Me.tglOpenDrawer)
            Me.cardOptions.Controls.Add(Me.lblCopies)
            Me.cardOptions.Controls.Add(Me.txtCopies)
            Me.cardOptions.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardOptions.Location = New System.Drawing.Point(30, 475)
            Me.cardOptions.Name = "cardOptions"
            Me.cardOptions.Size = New System.Drawing.Size(1178, 175)
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
            Me.chkPrintLogo.Location = New System.Drawing.Point(880, 58)
            Me.chkPrintLogo.Name = "chkPrintLogo"
            Me.chkPrintLogo.Size = New System.Drawing.Size(260, 30)
            Me.chkPrintLogo.TabIndex = 1
            Me.chkPrintLogo.Text = "طباعة الشعار على الفاتورة"
            Me.chkPrintLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.chkPrintBarcode.Location = New System.Drawing.Point(580, 58)
            Me.chkPrintBarcode.Name = "chkPrintBarcode"
            Me.chkPrintBarcode.Size = New System.Drawing.Size(260, 30)
            Me.chkPrintBarcode.TabIndex = 2
            Me.chkPrintBarcode.Text = "طباعة الباركود على الفاتورة"
            Me.chkPrintBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPrintBarcode.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.chkPrintBarcode.UncheckedState.BorderRadius = 4
            Me.chkPrintBarcode.UncheckedState.BorderThickness = 1
            Me.chkPrintBarcode.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
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
            Me.chkPrintPreview.Location = New System.Drawing.Point(280, 58)
            Me.chkPrintPreview.Name = "chkPrintPreview"
            Me.chkPrintPreview.Size = New System.Drawing.Size(260, 30)
            Me.chkPrintPreview.TabIndex = 3
            Me.chkPrintPreview.Text = "معاينة الفاتورة قبل الطباعة"
            Me.chkPrintPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.txtCopies.DefaultText = "1"
            Me.txtCopies.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtCopies.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.txtCopies.ForeColor = System.Drawing.Color.White
            Me.txtCopies.Location = New System.Drawing.Point(120, 111)
            Me.txtCopies.Name = "txtCopies"
            Me.txtCopies.Size = New System.Drawing.Size(110, 38)
            Me.txtCopies.TabIndex = 9
            Me.txtCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BorderRadius = 8
            Me.btnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(978, 670)
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
            Me.btnReset.Location = New System.Drawing.Point(740, 670)
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
            Me.btnClose.Location = New System.Drawing.Point(30, 670)
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
            Me.Size = New System.Drawing.Size(1238, 760)
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
        Friend WithEvents lblNormalPrinter As System.Windows.Forms.Label
        Friend WithEvents cmbNormalPrinter As Guna.UI2.WinForms.Guna2ComboBox
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
        Friend WithEvents lblPrintStyle As System.Windows.Forms.Label
        Friend WithEvents rbStyleSimple As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblStyleSimple As System.Windows.Forms.Label
        Friend WithEvents rbStyleAdvanced As Guna.UI2.WinForms.Guna2CustomRadioButton
        Friend WithEvents lblStyleAdvanced As System.Windows.Forms.Label
        Friend WithEvents cardOptions As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardOptionsTitle As System.Windows.Forms.Label
        Friend WithEvents chkPrintLogo As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents chkPrintBarcode As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents chkPrintPreview As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents lblAutoPrint As System.Windows.Forms.Label
        Friend WithEvents tglAutoPrint As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblOpenDrawer As System.Windows.Forms.Label
        Friend WithEvents tglOpenDrawer As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblCopies As System.Windows.Forms.Label
        Friend WithEvents txtCopies As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
