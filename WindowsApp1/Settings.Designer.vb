<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelDeveloper = New System.Windows.Forms.Label()
        Me._tips = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.cmbDefaultCustomer = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnIsDineInServiceFeePercent = New Guna.UI2.WinForms.Guna2Button()
        Me.txtDineInServiceFee = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbDefaultDriver = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbDefaultOrderType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.txtInvoiceItemsPerPage = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.pnlScannerAdvanced = New System.Windows.Forms.Panel()
        Me.txtScanTestResult = New System.Windows.Forms.TextBox()
        Me.lblScanTestHint = New System.Windows.Forms.Label()
        Me.cmbStopBits = New System.Windows.Forms.ComboBox()
        Me.lblStopBits = New System.Windows.Forms.Label()
        Me.cmbParity = New System.Windows.Forms.ComboBox()
        Me.lblParity = New System.Windows.Forms.Label()
        Me.cmbDataBits = New System.Windows.Forms.ComboBox()
        Me.lblDataBits = New System.Windows.Forms.Label()
        Me.cmbBaudRate = New System.Windows.Forms.ComboBox()
        Me.lblBaudRate = New System.Windows.Forms.Label()
        Me.lblScannerAdvTitle = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxEnabled = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.ComboBoxPorts = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnRefreshPorts = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCloseConnection = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTestConnection = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSavebarcode = New DevExpress.XtraEditors.SimpleButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnSaveDbSettings = New System.Windows.Forms.Button()
        Me.btnTestDbConnection = New System.Windows.Forms.Button()
        Me.lblDbStatus = New System.Windows.Forms.Label()
        Me.txtDbPassword = New System.Windows.Forms.TextBox()
        Me.txtDbUser = New System.Windows.Forms.TextBox()
        Me.txtDbName = New System.Windows.Forms.TextBox()
        Me.lblDbPassword = New System.Windows.Forms.Label()
        Me.lblDbUser = New System.Windows.Forms.Label()
        Me.chkWindowsAuth = New System.Windows.Forms.CheckBox()
        Me.lblDbName = New System.Windows.Forms.Label()
        Me.btnDetectServers = New System.Windows.Forms.Button()
        Me.txtDbServer = New System.Windows.Forms.ComboBox()
        Me.lblDbServer = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnBrowseLogo = New Guna.UI2.WinForms.Guna2Button()
        Me.txtLogoPath = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDeliveryText = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtFooterText = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtShopTax = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtShopAddress = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtShopPhone2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtShopPhone = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtShopName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnSaveGeneral = New System.Windows.Forms.Button()
        Me.btnTestThermal = New System.Windows.Forms.Button()
        Me.btnRefreshPrinters = New System.Windows.Forms.Button()
        Me.chkPrintPreview = New System.Windows.Forms.CheckBox()
        Me.chkPrintBarcode = New System.Windows.Forms.CheckBox()
        Me.chkPrintLogo = New System.Windows.Forms.CheckBox()
        Me.rbStyleAdvanced = New System.Windows.Forms.RadioButton()
        Me.rbStyleSimple = New System.Windows.Forms.RadioButton()
        Me.lblPrintStyle = New System.Windows.Forms.Label()
        Me.cmbNormalPrinter = New System.Windows.Forms.ComboBox()
        Me.lblNormalPrinter = New System.Windows.Forms.Label()
        Me.cmbThermalPrinter = New System.Windows.Forms.ComboBox()
        Me.lblThermalPrinter = New System.Windows.Forms.Label()
        Me.lblLogoHint = New System.Windows.Forms.Label()
        Me.picLogoPreview = New System.Windows.Forms.PictureBox()
        Me.lblPreview = New System.Windows.Forms.Label()
        Me.lblLogoPath = New System.Windows.Forms.Label()
        Me.lblDeliveryText = New System.Windows.Forms.Label()
        Me.lblFooterText = New System.Windows.Forms.Label()
        Me.lblShopTax = New System.Windows.Forms.Label()
        Me.lblShopAddress = New System.Windows.Forms.Label()
        Me.lblShopPhone2 = New System.Windows.Forms.Label()
        Me.lblShopPhone = New System.Windows.Forms.Label()
        Me.lblShopName = New System.Windows.Forms.Label()
        Me.public_set = New Guna.UI2.WinForms.Guna2TabControl()
        Me.cmbBranches = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbStores = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.pnlScannerAdvanced.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.picLogoPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.public_set.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.pn_title_page)
        Me.pnlHeader.Controls.Add(Me.btn_min)
        Me.pnlHeader.Controls.Add(Me.btn_max)
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1500, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'pn_title_page
        '
        Me.pn_title_page.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pn_title_page.AutoSize = True
        Me.pn_title_page.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pn_title_page.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.pn_title_page.Location = New System.Drawing.Point(672, 9)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(156, 46)
        Me.pn_title_page.TabIndex = 6
        Me.pn_title_page.Text = "الاعدادات"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(99, 18)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.btn_min.TabIndex = 5
        '
        'btn_max
        '
        Me.btn_max.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_max.Appearance.Options.UseFont = True
        Me.btn_max.AutoSize = True
        Me.btn_max.ImageOptions.SvgImage = CType(resources.GetObject("btn_max.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_max.Location = New System.Drawing.Point(55, 18)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 4
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.AutoSize = True
        Me.btnClose.ImageOptions.SvgImage = CType(resources.GetObject("btnClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnClose.Location = New System.Drawing.Point(11, 18)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnClose.Size = New System.Drawing.Size(38, 36)
        Me.btnClose.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelDeveloper)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 800)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1500, 50)
        Me.Panel2.TabIndex = 2
        '
        'LabelDeveloper
        '
        Me.LabelDeveloper.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelDeveloper.AutoSize = True
        Me.LabelDeveloper.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.LabelDeveloper.Location = New System.Drawing.Point(433, 3)
        Me.LabelDeveloper.Name = "LabelDeveloper"
        Me.LabelDeveloper.Size = New System.Drawing.Size(417, 31)
        Me.LabelDeveloper.TabIndex = 1
        Me.LabelDeveloper.Text = "تم تصميم هذا البرنامج بواسطة عمار احمد"
        Me.LabelDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_tips
        '
        Me._tips.AutoPopDelay = 6000
        Me._tips.InitialDelay = 300
        Me._tips.ReshowDelay = 100
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.cmbStores)
        Me.TabPage5.Controls.Add(Me.Label9)
        Me.TabPage5.Controls.Add(Me.cmbBranches)
        Me.TabPage5.Controls.Add(Me.Label8)
        Me.TabPage5.Controls.Add(Me.cmbDefaultCustomer)
        Me.TabPage5.Controls.Add(Me.btnIsDineInServiceFeePercent)
        Me.TabPage5.Controls.Add(Me.txtDineInServiceFee)
        Me.TabPage5.Controls.Add(Me.Label10)
        Me.TabPage5.Controls.Add(Me.cmbDefaultDriver)
        Me.TabPage5.Controls.Add(Me.Label7)
        Me.TabPage5.Controls.Add(Me.cmbDefaultOrderType)
        Me.TabPage5.Controls.Add(Me.Label5)
        Me.TabPage5.Controls.Add(Me.cmbTreasury)
        Me.TabPage5.Controls.Add(Me.Label6)
        Me.TabPage5.Controls.Add(Me.Label4)
        Me.TabPage5.Controls.Add(Me.Guna2Button1)
        Me.TabPage5.Controls.Add(Me.txtInvoiceItemsPerPage)
        Me.TabPage5.Controls.Add(Me.Label3)
        Me.TabPage5.Location = New System.Drawing.Point(4, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1272, 722)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "المبيعات"
        '
        'cmbDefaultCustomer
        '
        Me.cmbDefaultCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDefaultCustomer.BackColor = System.Drawing.Color.Transparent
        Me.cmbDefaultCustomer.BorderRadius = 8
        Me.cmbDefaultCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDefaultCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDefaultCustomer.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDefaultCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDefaultCustomer.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbDefaultCustomer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbDefaultCustomer.ItemHeight = 40
        Me.cmbDefaultCustomer.Location = New System.Drawing.Point(698, 104)
        Me.cmbDefaultCustomer.Name = "cmbDefaultCustomer"
        Me.cmbDefaultCustomer.Size = New System.Drawing.Size(306, 46)
        Me.cmbDefaultCustomer.TabIndex = 5654
        Me.cmbDefaultCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnIsDineInServiceFeePercent
        '
        Me.btnIsDineInServiceFeePercent.BackColor = System.Drawing.Color.Transparent
        Me.btnIsDineInServiceFeePercent.BorderRadius = 8
        Me.btnIsDineInServiceFeePercent.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnIsDineInServiceFeePercent.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnIsDineInServiceFeePercent.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnIsDineInServiceFeePercent.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnIsDineInServiceFeePercent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnIsDineInServiceFeePercent.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnIsDineInServiceFeePercent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnIsDineInServiceFeePercent.FillColor = System.Drawing.Color.Gainsboro
        Me.btnIsDineInServiceFeePercent.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnIsDineInServiceFeePercent.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.btnIsDineInServiceFeePercent.Location = New System.Drawing.Point(644, 185)
        Me.btnIsDineInServiceFeePercent.Name = "btnIsDineInServiceFeePercent"
        Me.btnIsDineInServiceFeePercent.Size = New System.Drawing.Size(48, 46)
        Me.btnIsDineInServiceFeePercent.TabIndex = 5653
        Me.btnIsDineInServiceFeePercent.Text = "%"
        '
        'txtDineInServiceFee
        '
        Me.txtDineInServiceFee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDineInServiceFee.BorderRadius = 6
        Me.txtDineInServiceFee.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDineInServiceFee.DefaultText = ""
        Me.txtDineInServiceFee.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDineInServiceFee.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDineInServiceFee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDineInServiceFee.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDineInServiceFee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDineInServiceFee.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDineInServiceFee.ForeColor = System.Drawing.Color.Black
        Me.txtDineInServiceFee.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDineInServiceFee.Location = New System.Drawing.Point(698, 185)
        Me.txtDineInServiceFee.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDineInServiceFee.Name = "txtDineInServiceFee"
        Me.txtDineInServiceFee.PlaceholderText = ""
        Me.txtDineInServiceFee.SelectedText = ""
        Me.txtDineInServiceFee.Size = New System.Drawing.Size(306, 46)
        Me.txtDineInServiceFee.TabIndex = 5652
        Me.txtDineInServiceFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1033, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(223, 36)
        Me.Label10.TabIndex = 5651
        Me.Label10.Text = "خدمة الصالة"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbDefaultDriver
        '
        Me.cmbDefaultDriver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDefaultDriver.BackColor = System.Drawing.Color.Transparent
        Me.cmbDefaultDriver.BorderRadius = 8
        Me.cmbDefaultDriver.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDefaultDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDefaultDriver.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDefaultDriver.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDefaultDriver.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbDefaultDriver.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbDefaultDriver.ItemHeight = 40
        Me.cmbDefaultDriver.Location = New System.Drawing.Point(698, 428)
        Me.cmbDefaultDriver.Name = "cmbDefaultDriver"
        Me.cmbDefaultDriver.Size = New System.Drawing.Size(306, 46)
        Me.cmbDefaultDriver.TabIndex = 5642
        Me.cmbDefaultDriver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1033, 433)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(223, 36)
        Me.Label7.TabIndex = 5641
        Me.Label7.Text = "الطيار الافتراضي"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbDefaultOrderType
        '
        Me.cmbDefaultOrderType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDefaultOrderType.BackColor = System.Drawing.Color.Transparent
        Me.cmbDefaultOrderType.BorderRadius = 8
        Me.cmbDefaultOrderType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDefaultOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDefaultOrderType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDefaultOrderType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDefaultOrderType.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbDefaultOrderType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbDefaultOrderType.ItemHeight = 40
        Me.cmbDefaultOrderType.Location = New System.Drawing.Point(698, 347)
        Me.cmbDefaultOrderType.Name = "cmbDefaultOrderType"
        Me.cmbDefaultOrderType.Size = New System.Drawing.Size(306, 46)
        Me.cmbDefaultOrderType.TabIndex = 5640
        Me.cmbDefaultOrderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1033, 352)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(223, 36)
        Me.Label5.TabIndex = 5639
        Me.Label5.Text = "نوع الطلب الافتراضي"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTreasury
        '
        Me.cmbTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbTreasury.BorderRadius = 8
        Me.cmbTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTreasury.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasury.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbTreasury.ItemHeight = 40
        Me.cmbTreasury.Location = New System.Drawing.Point(698, 266)
        Me.cmbTreasury.Name = "cmbTreasury"
        Me.cmbTreasury.Size = New System.Drawing.Size(306, 46)
        Me.cmbTreasury.TabIndex = 5638
        Me.cmbTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1033, 271)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(223, 36)
        Me.Label6.TabIndex = 5637
        Me.Label6.Text = "الخزنة الافتراضية"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1033, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(223, 36)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "العميل الافتراضي"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BorderRadius = 10
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(554, 658)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(262, 45)
        Me.Guna2Button1.TabIndex = 2
        Me.Guna2Button1.Text = "حفظ"
        '
        'txtInvoiceItemsPerPage
        '
        Me.txtInvoiceItemsPerPage.BorderRadius = 10
        Me.txtInvoiceItemsPerPage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvoiceItemsPerPage.DefaultText = "10"
        Me.txtInvoiceItemsPerPage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtInvoiceItemsPerPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtInvoiceItemsPerPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInvoiceItemsPerPage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInvoiceItemsPerPage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInvoiceItemsPerPage.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceItemsPerPage.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceItemsPerPage.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInvoiceItemsPerPage.Location = New System.Drawing.Point(698, 23)
        Me.txtInvoiceItemsPerPage.Margin = New System.Windows.Forms.Padding(5)
        Me.txtInvoiceItemsPerPage.Name = "txtInvoiceItemsPerPage"
        Me.txtInvoiceItemsPerPage.PlaceholderText = ""
        Me.txtInvoiceItemsPerPage.SelectedText = ""
        Me.txtInvoiceItemsPerPage.Size = New System.Drawing.Size(306, 46)
        Me.txtInvoiceItemsPerPage.TabIndex = 1
        Me.txtInvoiceItemsPerPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1033, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(223, 36)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "عدد اصناف صفحة الطباعة"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.pnlScannerAdvanced)
        Me.TabPage3.Controls.Add(Me.lblStatus)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.CheckBoxEnabled)
        Me.TabPage3.Controls.Add(Me.ComboBoxPorts)
        Me.TabPage3.Controls.Add(Me.btnRefreshPorts)
        Me.TabPage3.Controls.Add(Me.btnCloseConnection)
        Me.TabPage3.Controls.Add(Me.btnTestConnection)
        Me.TabPage3.Controls.Add(Me.btnSavebarcode)
        Me.TabPage3.Location = New System.Drawing.Point(4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1272, 722)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "scanner barcode"
        '
        'pnlScannerAdvanced
        '
        Me.pnlScannerAdvanced.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.pnlScannerAdvanced.Controls.Add(Me.txtScanTestResult)
        Me.pnlScannerAdvanced.Controls.Add(Me.lblScanTestHint)
        Me.pnlScannerAdvanced.Controls.Add(Me.cmbStopBits)
        Me.pnlScannerAdvanced.Controls.Add(Me.lblStopBits)
        Me.pnlScannerAdvanced.Controls.Add(Me.cmbParity)
        Me.pnlScannerAdvanced.Controls.Add(Me.lblParity)
        Me.pnlScannerAdvanced.Controls.Add(Me.cmbDataBits)
        Me.pnlScannerAdvanced.Controls.Add(Me.lblDataBits)
        Me.pnlScannerAdvanced.Controls.Add(Me.cmbBaudRate)
        Me.pnlScannerAdvanced.Controls.Add(Me.lblBaudRate)
        Me.pnlScannerAdvanced.Controls.Add(Me.lblScannerAdvTitle)
        Me.pnlScannerAdvanced.Location = New System.Drawing.Point(60, 150)
        Me.pnlScannerAdvanced.Name = "pnlScannerAdvanced"
        Me.pnlScannerAdvanced.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlScannerAdvanced.Size = New System.Drawing.Size(580, 450)
        Me.pnlScannerAdvanced.TabIndex = 18
        '
        'txtScanTestResult
        '
        Me.txtScanTestResult.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.txtScanTestResult.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtScanTestResult.ForeColor = System.Drawing.Color.LightGreen
        Me.txtScanTestResult.Location = New System.Drawing.Point(20, 265)
        Me.txtScanTestResult.Multiline = True
        Me.txtScanTestResult.Name = "txtScanTestResult"
        Me.txtScanTestResult.ReadOnly = True
        Me.txtScanTestResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScanTestResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtScanTestResult.Size = New System.Drawing.Size(540, 170)
        Me.txtScanTestResult.TabIndex = 10
        '
        'lblScanTestHint
        '
        Me.lblScanTestHint.AutoSize = True
        Me.lblScanTestHint.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblScanTestHint.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblScanTestHint.Location = New System.Drawing.Point(40, 235)
        Me.lblScanTestHint.Name = "lblScanTestHint"
        Me.lblScanTestHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblScanTestHint.Size = New System.Drawing.Size(389, 19)
        Me.lblScanTestHint.TabIndex = 9
        Me.lblScanTestHint.Text = "اضغط «اختبار الاتصال» ثم امسح أي باركود — ستظهر النتيجة هنا:"
        '
        'cmbStopBits
        '
        Me.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStopBits.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbStopBits.FormattingEnabled = True
        Me.cmbStopBits.Items.AddRange(New Object() {"One", "Two", "OnePointFive"})
        Me.cmbStopBits.Location = New System.Drawing.Point(110, 190)
        Me.cmbStopBits.Name = "cmbStopBits"
        Me.cmbStopBits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbStopBits.Size = New System.Drawing.Size(290, 29)
        Me.cmbStopBits.TabIndex = 8
        '
        'lblStopBits
        '
        Me.lblStopBits.AutoSize = True
        Me.lblStopBits.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblStopBits.ForeColor = System.Drawing.Color.White
        Me.lblStopBits.Location = New System.Drawing.Point(420, 194)
        Me.lblStopBits.Name = "lblStopBits"
        Me.lblStopBits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblStopBits.Size = New System.Drawing.Size(93, 21)
        Me.lblStopBits.TabIndex = 7
        Me.lblStopBits.Text = "بِتّات التوقّف:"
        '
        'cmbParity
        '
        Me.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbParity.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbParity.FormattingEnabled = True
        Me.cmbParity.Items.AddRange(New Object() {"None", "Even", "Odd", "Mark", "Space"})
        Me.cmbParity.Location = New System.Drawing.Point(110, 145)
        Me.cmbParity.Name = "cmbParity"
        Me.cmbParity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbParity.Size = New System.Drawing.Size(290, 29)
        Me.cmbParity.TabIndex = 6
        '
        'lblParity
        '
        Me.lblParity.AutoSize = True
        Me.lblParity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblParity.ForeColor = System.Drawing.Color.White
        Me.lblParity.Location = New System.Drawing.Point(420, 149)
        Me.lblParity.Name = "lblParity"
        Me.lblParity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblParity.Size = New System.Drawing.Size(118, 21)
        Me.lblParity.TabIndex = 5
        Me.lblParity.Text = "التماثل (Parity):"
        '
        'cmbDataBits
        '
        Me.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataBits.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbDataBits.FormattingEnabled = True
        Me.cmbDataBits.Items.AddRange(New Object() {"7", "8"})
        Me.cmbDataBits.Location = New System.Drawing.Point(110, 100)
        Me.cmbDataBits.Name = "cmbDataBits"
        Me.cmbDataBits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbDataBits.Size = New System.Drawing.Size(290, 29)
        Me.cmbDataBits.TabIndex = 4
        '
        'lblDataBits
        '
        Me.lblDataBits.AutoSize = True
        Me.lblDataBits.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDataBits.ForeColor = System.Drawing.Color.White
        Me.lblDataBits.Location = New System.Drawing.Point(420, 104)
        Me.lblDataBits.Name = "lblDataBits"
        Me.lblDataBits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDataBits.Size = New System.Drawing.Size(94, 21)
        Me.lblDataBits.TabIndex = 3
        Me.lblDataBits.Text = "بِتّات البيانات:"
        '
        'cmbBaudRate
        '
        Me.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBaudRate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbBaudRate.FormattingEnabled = True
        Me.cmbBaudRate.Items.AddRange(New Object() {"9600", "19200", "38400", "57600", "115200"})
        Me.cmbBaudRate.Location = New System.Drawing.Point(110, 55)
        Me.cmbBaudRate.Name = "cmbBaudRate"
        Me.cmbBaudRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbBaudRate.Size = New System.Drawing.Size(290, 29)
        Me.cmbBaudRate.TabIndex = 2
        '
        'lblBaudRate
        '
        Me.lblBaudRate.AutoSize = True
        Me.lblBaudRate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblBaudRate.ForeColor = System.Drawing.Color.White
        Me.lblBaudRate.Location = New System.Drawing.Point(420, 59)
        Me.lblBaudRate.Name = "lblBaudRate"
        Me.lblBaudRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblBaudRate.Size = New System.Drawing.Size(141, 21)
        Me.lblBaudRate.TabIndex = 1
        Me.lblBaudRate.Text = "سرعة النقل (Baud):"
        '
        'lblScannerAdvTitle
        '
        Me.lblScannerAdvTitle.AutoSize = True
        Me.lblScannerAdvTitle.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblScannerAdvTitle.ForeColor = System.Drawing.Color.White
        Me.lblScannerAdvTitle.Location = New System.Drawing.Point(360, 8)
        Me.lblScannerAdvTitle.Name = "lblScannerAdvTitle"
        Me.lblScannerAdvTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblScannerAdvTitle.Size = New System.Drawing.Size(178, 28)
        Me.lblScannerAdvTitle.TabIndex = 0
        Me.lblScannerAdvTitle.Text = "⚙️ إعدادات متقدمة"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(668, 270)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(399, 45)
        Me.lblStatus.TabIndex = 17
        Me.lblStatus.Text = "حالة Scanner"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1002, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 39)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "حالة Scanner"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(930, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 39)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "اختيار المنفذ (Port)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBoxEnabled
        '
        Me.CheckBoxEnabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxEnabled.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CheckBoxEnabled.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CheckBoxEnabled.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.CheckBoxEnabled.CheckedState.InnerColor = System.Drawing.Color.White
        Me.CheckBoxEnabled.Location = New System.Drawing.Point(1109, 271)
        Me.CheckBoxEnabled.Name = "CheckBoxEnabled"
        Me.CheckBoxEnabled.Size = New System.Drawing.Size(93, 44)
        Me.CheckBoxEnabled.TabIndex = 10
        Me.CheckBoxEnabled.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.CheckBoxEnabled.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.CheckBoxEnabled.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.CheckBoxEnabled.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'ComboBoxPorts
        '
        Me.ComboBoxPorts.BackColor = System.Drawing.Color.Transparent
        Me.ComboBoxPorts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPorts.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxPorts.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxPorts.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.ComboBoxPorts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.ComboBoxPorts.ItemHeight = 30
        Me.ComboBoxPorts.Location = New System.Drawing.Point(916, 86)
        Me.ComboBoxPorts.Name = "ComboBoxPorts"
        Me.ComboBoxPorts.Size = New System.Drawing.Size(322, 36)
        Me.ComboBoxPorts.TabIndex = 0
        Me.ComboBoxPorts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnRefreshPorts
        '
        Me.btnRefreshPorts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshPorts.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshPorts.Appearance.Options.UseFont = True
        Me.btnRefreshPorts.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.software_testing
        Me.btnRefreshPorts.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnRefreshPorts.Location = New System.Drawing.Point(588, 64)
        Me.btnRefreshPorts.Name = "btnRefreshPorts"
        Me.btnRefreshPorts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnRefreshPorts.Size = New System.Drawing.Size(322, 79)
        Me.btnRefreshPorts.TabIndex = 15
        Me.btnRefreshPorts.Text = "تحديث المنافذ"
        '
        'btnCloseConnection
        '
        Me.btnCloseConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCloseConnection.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseConnection.Appearance.Options.UseFont = True
        Me.btnCloseConnection.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.software_testing
        Me.btnCloseConnection.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnCloseConnection.Location = New System.Drawing.Point(236, 626)
        Me.btnCloseConnection.Name = "btnCloseConnection"
        Me.btnCloseConnection.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnCloseConnection.Size = New System.Drawing.Size(326, 75)
        Me.btnCloseConnection.TabIndex = 13
        Me.btnCloseConnection.Text = "غلق الباركود"
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTestConnection.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestConnection.Appearance.Options.UseFont = True
        Me.btnTestConnection.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.software_testing
        Me.btnTestConnection.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnTestConnection.Location = New System.Drawing.Point(568, 626)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnTestConnection.Size = New System.Drawing.Size(326, 75)
        Me.btnTestConnection.TabIndex = 12
        Me.btnTestConnection.Text = "اختبار الاتصال"
        '
        'btnSavebarcode
        '
        Me.btnSavebarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavebarcode.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavebarcode.Appearance.Options.UseFont = True
        Me.btnSavebarcode.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.file
        Me.btnSavebarcode.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnSavebarcode.Location = New System.Drawing.Point(900, 626)
        Me.btnSavebarcode.Name = "btnSavebarcode"
        Me.btnSavebarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSavebarcode.Size = New System.Drawing.Size(245, 75)
        Me.btnSavebarcode.TabIndex = 11
        Me.btnSavebarcode.Text = "حفظ"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.btnSaveDbSettings)
        Me.TabPage2.Controls.Add(Me.btnTestDbConnection)
        Me.TabPage2.Controls.Add(Me.lblDbStatus)
        Me.TabPage2.Controls.Add(Me.txtDbPassword)
        Me.TabPage2.Controls.Add(Me.txtDbUser)
        Me.TabPage2.Controls.Add(Me.txtDbName)
        Me.TabPage2.Controls.Add(Me.lblDbPassword)
        Me.TabPage2.Controls.Add(Me.lblDbUser)
        Me.TabPage2.Controls.Add(Me.chkWindowsAuth)
        Me.TabPage2.Controls.Add(Me.lblDbName)
        Me.TabPage2.Controls.Add(Me.btnDetectServers)
        Me.TabPage2.Controls.Add(Me.txtDbServer)
        Me.TabPage2.Controls.Add(Me.lblDbServer)
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1272, 722)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "قاعدة البيانات"
        '
        'btnSaveDbSettings
        '
        Me.btnSaveDbSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSaveDbSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveDbSettings.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveDbSettings.ForeColor = System.Drawing.Color.White
        Me.btnSaveDbSettings.Location = New System.Drawing.Point(552, 360)
        Me.btnSaveDbSettings.Name = "btnSaveDbSettings"
        Me.btnSaveDbSettings.Size = New System.Drawing.Size(240, 42)
        Me.btnSaveDbSettings.TabIndex = 12
        Me.btnSaveDbSettings.Text = "💾 حفظ إعدادات قاعدة البيانات"
        Me.btnSaveDbSettings.UseVisualStyleBackColor = False
        '
        'btnTestDbConnection
        '
        Me.btnTestDbConnection.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnTestDbConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestDbConnection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnTestDbConnection.ForeColor = System.Drawing.Color.White
        Me.btnTestDbConnection.Location = New System.Drawing.Point(822, 360)
        Me.btnTestDbConnection.Name = "btnTestDbConnection"
        Me.btnTestDbConnection.Size = New System.Drawing.Size(180, 42)
        Me.btnTestDbConnection.TabIndex = 11
        Me.btnTestDbConnection.Text = "🔌 اختبار الاتصال"
        Me.btnTestDbConnection.UseVisualStyleBackColor = False
        '
        'lblDbStatus
        '
        Me.lblDbStatus.AutoSize = True
        Me.lblDbStatus.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblDbStatus.ForeColor = System.Drawing.Color.LightGreen
        Me.lblDbStatus.Location = New System.Drawing.Point(722, 315)
        Me.lblDbStatus.Name = "lblDbStatus"
        Me.lblDbStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDbStatus.Size = New System.Drawing.Size(0, 25)
        Me.lblDbStatus.TabIndex = 10
        '
        'txtDbPassword
        '
        Me.txtDbPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtDbPassword.Location = New System.Drawing.Point(522, 247)
        Me.txtDbPassword.Name = "txtDbPassword"
        Me.txtDbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtDbPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDbPassword.Size = New System.Drawing.Size(490, 27)
        Me.txtDbPassword.TabIndex = 9
        '
        'txtDbUser
        '
        Me.txtDbUser.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtDbUser.Location = New System.Drawing.Point(522, 192)
        Me.txtDbUser.Name = "txtDbUser"
        Me.txtDbUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDbUser.Size = New System.Drawing.Size(490, 27)
        Me.txtDbUser.TabIndex = 7
        '
        'txtDbName
        '
        Me.txtDbName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtDbName.Location = New System.Drawing.Point(522, 92)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDbName.Size = New System.Drawing.Size(490, 27)
        Me.txtDbName.TabIndex = 4
        '
        'lblDbPassword
        '
        Me.lblDbPassword.AutoSize = True
        Me.lblDbPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDbPassword.ForeColor = System.Drawing.Color.White
        Me.lblDbPassword.Location = New System.Drawing.Point(1042, 250)
        Me.lblDbPassword.Name = "lblDbPassword"
        Me.lblDbPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDbPassword.Size = New System.Drawing.Size(87, 21)
        Me.lblDbPassword.TabIndex = 8
        Me.lblDbPassword.Text = "كلمة المرور:"
        '
        'lblDbUser
        '
        Me.lblDbUser.AutoSize = True
        Me.lblDbUser.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDbUser.ForeColor = System.Drawing.Color.White
        Me.lblDbUser.Location = New System.Drawing.Point(1042, 195)
        Me.lblDbUser.Name = "lblDbUser"
        Me.lblDbUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDbUser.Size = New System.Drawing.Size(106, 21)
        Me.lblDbUser.TabIndex = 6
        Me.lblDbUser.Text = "اسم المستخدم:"
        '
        'chkWindowsAuth
        '
        Me.chkWindowsAuth.AutoSize = True
        Me.chkWindowsAuth.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.chkWindowsAuth.ForeColor = System.Drawing.Color.White
        Me.chkWindowsAuth.Location = New System.Drawing.Point(722, 145)
        Me.chkWindowsAuth.Name = "chkWindowsAuth"
        Me.chkWindowsAuth.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkWindowsAuth.Size = New System.Drawing.Size(246, 24)
        Me.chkWindowsAuth.TabIndex = 5
        Me.chkWindowsAuth.Text = "استخدام Windows Authentication"
        Me.chkWindowsAuth.UseVisualStyleBackColor = True
        '
        'lblDbName
        '
        Me.lblDbName.AutoSize = True
        Me.lblDbName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDbName.ForeColor = System.Drawing.Color.White
        Me.lblDbName.Location = New System.Drawing.Point(1042, 95)
        Me.lblDbName.Name = "lblDbName"
        Me.lblDbName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDbName.Size = New System.Drawing.Size(132, 21)
        Me.lblDbName.TabIndex = 3
        Me.lblDbName.Text = "اسم قاعدة البيانات:"
        '
        'btnDetectServers
        '
        Me.btnDetectServers.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnDetectServers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetectServers.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDetectServers.ForeColor = System.Drawing.Color.White
        Me.btnDetectServers.Location = New System.Drawing.Point(347, 36)
        Me.btnDetectServers.Name = "btnDetectServers"
        Me.btnDetectServers.Size = New System.Drawing.Size(165, 30)
        Me.btnDetectServers.TabIndex = 2
        Me.btnDetectServers.Text = "🔍 اكتشاف تلقائي"
        Me.btnDetectServers.UseVisualStyleBackColor = False
        '
        'txtDbServer
        '
        Me.txtDbServer.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtDbServer.FormattingEnabled = True
        Me.txtDbServer.Location = New System.Drawing.Point(522, 37)
        Me.txtDbServer.Name = "txtDbServer"
        Me.txtDbServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDbServer.Size = New System.Drawing.Size(490, 28)
        Me.txtDbServer.TabIndex = 1
        '
        'lblDbServer
        '
        Me.lblDbServer.AutoSize = True
        Me.lblDbServer.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDbServer.ForeColor = System.Drawing.Color.White
        Me.lblDbServer.Location = New System.Drawing.Point(1042, 40)
        Me.lblDbServer.Name = "lblDbServer"
        Me.lblDbServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDbServer.Size = New System.Drawing.Size(118, 21)
        Me.lblDbServer.TabIndex = 0
        Me.lblDbServer.Text = "الخادم (Server):"
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.TabPage1.Controls.Add(Me.btnBrowseLogo)
        Me.TabPage1.Controls.Add(Me.txtLogoPath)
        Me.TabPage1.Controls.Add(Me.txtDeliveryText)
        Me.TabPage1.Controls.Add(Me.txtFooterText)
        Me.TabPage1.Controls.Add(Me.txtShopTax)
        Me.TabPage1.Controls.Add(Me.txtShopAddress)
        Me.TabPage1.Controls.Add(Me.txtShopPhone2)
        Me.TabPage1.Controls.Add(Me.txtShopPhone)
        Me.TabPage1.Controls.Add(Me.txtShopName)
        Me.TabPage1.Controls.Add(Me.btnSaveGeneral)
        Me.TabPage1.Controls.Add(Me.btnTestThermal)
        Me.TabPage1.Controls.Add(Me.btnRefreshPrinters)
        Me.TabPage1.Controls.Add(Me.chkPrintPreview)
        Me.TabPage1.Controls.Add(Me.chkPrintBarcode)
        Me.TabPage1.Controls.Add(Me.chkPrintLogo)
        Me.TabPage1.Controls.Add(Me.rbStyleAdvanced)
        Me.TabPage1.Controls.Add(Me.rbStyleSimple)
        Me.TabPage1.Controls.Add(Me.lblPrintStyle)
        Me.TabPage1.Controls.Add(Me.cmbNormalPrinter)
        Me.TabPage1.Controls.Add(Me.lblNormalPrinter)
        Me.TabPage1.Controls.Add(Me.cmbThermalPrinter)
        Me.TabPage1.Controls.Add(Me.lblThermalPrinter)
        Me.TabPage1.Controls.Add(Me.lblLogoHint)
        Me.TabPage1.Controls.Add(Me.picLogoPreview)
        Me.TabPage1.Controls.Add(Me.lblPreview)
        Me.TabPage1.Controls.Add(Me.lblLogoPath)
        Me.TabPage1.Controls.Add(Me.lblDeliveryText)
        Me.TabPage1.Controls.Add(Me.lblFooterText)
        Me.TabPage1.Controls.Add(Me.lblShopTax)
        Me.TabPage1.Controls.Add(Me.lblShopAddress)
        Me.TabPage1.Controls.Add(Me.lblShopPhone2)
        Me.TabPage1.Controls.Add(Me.lblShopPhone)
        Me.TabPage1.Controls.Add(Me.lblShopName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1272, 722)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "الاعدادات العامه"
        '
        'btnBrowseLogo
        '
        Me.btnBrowseLogo.BorderRadius = 6
        Me.btnBrowseLogo.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnBrowseLogo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnBrowseLogo.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnBrowseLogo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnBrowseLogo.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnBrowseLogo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnBrowseLogo.ForeColor = System.Drawing.Color.White
        Me.btnBrowseLogo.Location = New System.Drawing.Point(454, 334)
        Me.btnBrowseLogo.Name = "btnBrowseLogo"
        Me.btnBrowseLogo.Size = New System.Drawing.Size(197, 38)
        Me.btnBrowseLogo.TabIndex = 5593
        Me.btnBrowseLogo.Text = "تحديد مكان اللوجو"
        '
        'txtLogoPath
        '
        Me.txtLogoPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLogoPath.BorderRadius = 6
        Me.txtLogoPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLogoPath.DefaultText = ""
        Me.txtLogoPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtLogoPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtLogoPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtLogoPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtLogoPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtLogoPath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtLogoPath.ForeColor = System.Drawing.Color.Black
        Me.txtLogoPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtLogoPath.Location = New System.Drawing.Point(657, 336)
        Me.txtLogoPath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtLogoPath.Name = "txtLogoPath"
        Me.txtLogoPath.PlaceholderText = ""
        Me.txtLogoPath.SelectedText = ""
        Me.txtLogoPath.Size = New System.Drawing.Size(400, 36)
        Me.txtLogoPath.TabIndex = 5592
        Me.txtLogoPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDeliveryText
        '
        Me.txtDeliveryText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeliveryText.BorderRadius = 6
        Me.txtDeliveryText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeliveryText.DefaultText = ""
        Me.txtDeliveryText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDeliveryText.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDeliveryText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDeliveryText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDeliveryText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDeliveryText.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDeliveryText.ForeColor = System.Drawing.Color.Black
        Me.txtDeliveryText.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDeliveryText.Location = New System.Drawing.Point(657, 285)
        Me.txtDeliveryText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDeliveryText.Name = "txtDeliveryText"
        Me.txtDeliveryText.PlaceholderText = ""
        Me.txtDeliveryText.SelectedText = ""
        Me.txtDeliveryText.Size = New System.Drawing.Size(400, 36)
        Me.txtDeliveryText.TabIndex = 5591
        Me.txtDeliveryText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFooterText
        '
        Me.txtFooterText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFooterText.BorderRadius = 6
        Me.txtFooterText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFooterText.DefaultText = ""
        Me.txtFooterText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtFooterText.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtFooterText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtFooterText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtFooterText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtFooterText.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtFooterText.ForeColor = System.Drawing.Color.Black
        Me.txtFooterText.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtFooterText.Location = New System.Drawing.Point(657, 240)
        Me.txtFooterText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFooterText.Name = "txtFooterText"
        Me.txtFooterText.PlaceholderText = ""
        Me.txtFooterText.SelectedText = ""
        Me.txtFooterText.Size = New System.Drawing.Size(400, 36)
        Me.txtFooterText.TabIndex = 5590
        Me.txtFooterText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShopTax
        '
        Me.txtShopTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShopTax.BorderRadius = 6
        Me.txtShopTax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtShopTax.DefaultText = ""
        Me.txtShopTax.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtShopTax.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtShopTax.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopTax.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopTax.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopTax.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtShopTax.ForeColor = System.Drawing.Color.Black
        Me.txtShopTax.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopTax.Location = New System.Drawing.Point(657, 195)
        Me.txtShopTax.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtShopTax.Name = "txtShopTax"
        Me.txtShopTax.PlaceholderText = ""
        Me.txtShopTax.SelectedText = ""
        Me.txtShopTax.Size = New System.Drawing.Size(400, 36)
        Me.txtShopTax.TabIndex = 5589
        Me.txtShopTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShopAddress
        '
        Me.txtShopAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShopAddress.BorderRadius = 6
        Me.txtShopAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtShopAddress.DefaultText = ""
        Me.txtShopAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtShopAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtShopAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopAddress.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtShopAddress.ForeColor = System.Drawing.Color.Black
        Me.txtShopAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopAddress.Location = New System.Drawing.Point(657, 150)
        Me.txtShopAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtShopAddress.Name = "txtShopAddress"
        Me.txtShopAddress.PlaceholderText = ""
        Me.txtShopAddress.SelectedText = ""
        Me.txtShopAddress.Size = New System.Drawing.Size(400, 36)
        Me.txtShopAddress.TabIndex = 5588
        Me.txtShopAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShopPhone2
        '
        Me.txtShopPhone2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShopPhone2.BorderRadius = 6
        Me.txtShopPhone2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtShopPhone2.DefaultText = ""
        Me.txtShopPhone2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtShopPhone2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtShopPhone2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopPhone2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopPhone2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopPhone2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtShopPhone2.ForeColor = System.Drawing.Color.Black
        Me.txtShopPhone2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopPhone2.Location = New System.Drawing.Point(657, 105)
        Me.txtShopPhone2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtShopPhone2.Name = "txtShopPhone2"
        Me.txtShopPhone2.PlaceholderText = ""
        Me.txtShopPhone2.SelectedText = ""
        Me.txtShopPhone2.Size = New System.Drawing.Size(400, 36)
        Me.txtShopPhone2.TabIndex = 5587
        Me.txtShopPhone2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShopPhone
        '
        Me.txtShopPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShopPhone.BorderRadius = 6
        Me.txtShopPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtShopPhone.DefaultText = ""
        Me.txtShopPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtShopPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtShopPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopPhone.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtShopPhone.ForeColor = System.Drawing.Color.Black
        Me.txtShopPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopPhone.Location = New System.Drawing.Point(657, 59)
        Me.txtShopPhone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtShopPhone.Name = "txtShopPhone"
        Me.txtShopPhone.PlaceholderText = ""
        Me.txtShopPhone.SelectedText = ""
        Me.txtShopPhone.Size = New System.Drawing.Size(400, 36)
        Me.txtShopPhone.TabIndex = 5586
        Me.txtShopPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShopName
        '
        Me.txtShopName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShopName.BorderRadius = 6
        Me.txtShopName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtShopName.DefaultText = ""
        Me.txtShopName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtShopName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtShopName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtShopName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtShopName.ForeColor = System.Drawing.Color.Black
        Me.txtShopName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtShopName.Location = New System.Drawing.Point(657, 15)
        Me.txtShopName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtShopName.Name = "txtShopName"
        Me.txtShopName.PlaceholderText = ""
        Me.txtShopName.SelectedText = ""
        Me.txtShopName.Size = New System.Drawing.Size(400, 36)
        Me.txtShopName.TabIndex = 5585
        Me.txtShopName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSaveGeneral
        '
        Me.btnSaveGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSaveGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveGeneral.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveGeneral.ForeColor = System.Drawing.Color.White
        Me.btnSaveGeneral.Location = New System.Drawing.Point(383, 594)
        Me.btnSaveGeneral.Name = "btnSaveGeneral"
        Me.btnSaveGeneral.Size = New System.Drawing.Size(190, 40)
        Me.btnSaveGeneral.TabIndex = 36
        Me.btnSaveGeneral.Text = "💾 حفظ الاعدادات"
        Me.btnSaveGeneral.UseVisualStyleBackColor = False
        '
        'btnTestThermal
        '
        Me.btnTestThermal.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnTestThermal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestThermal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnTestThermal.ForeColor = System.Drawing.Color.White
        Me.btnTestThermal.Location = New System.Drawing.Point(603, 594)
        Me.btnTestThermal.Name = "btnTestThermal"
        Me.btnTestThermal.Size = New System.Drawing.Size(180, 40)
        Me.btnTestThermal.TabIndex = 35
        Me.btnTestThermal.Text = "🖨️ اختبار الحرارية"
        Me.btnTestThermal.UseVisualStyleBackColor = False
        Me.btnTestThermal.Visible = False
        '
        'btnRefreshPrinters
        '
        Me.btnRefreshPrinters.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnRefreshPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshPrinters.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshPrinters.ForeColor = System.Drawing.Color.White
        Me.btnRefreshPrinters.Location = New System.Drawing.Point(803, 594)
        Me.btnRefreshPrinters.Name = "btnRefreshPrinters"
        Me.btnRefreshPrinters.Size = New System.Drawing.Size(180, 40)
        Me.btnRefreshPrinters.TabIndex = 34
        Me.btnRefreshPrinters.Text = "🔄 تحديث الطابعات"
        Me.btnRefreshPrinters.UseVisualStyleBackColor = False
        Me.btnRefreshPrinters.Visible = False
        '
        'chkPrintPreview
        '
        Me.chkPrintPreview.AutoSize = True
        Me.chkPrintPreview.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.chkPrintPreview.ForeColor = System.Drawing.Color.Black
        Me.chkPrintPreview.Location = New System.Drawing.Point(429, 520)
        Me.chkPrintPreview.Name = "chkPrintPreview"
        Me.chkPrintPreview.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPrintPreview.Size = New System.Drawing.Size(185, 24)
        Me.chkPrintPreview.TabIndex = 33
        Me.chkPrintPreview.Text = "عرض معاينة قبل الطباعة"
        Me.chkPrintPreview.UseVisualStyleBackColor = True
        '
        'chkPrintBarcode
        '
        Me.chkPrintBarcode.AutoSize = True
        Me.chkPrintBarcode.Checked = True
        Me.chkPrintBarcode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintBarcode.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.chkPrintBarcode.ForeColor = System.Drawing.Color.Black
        Me.chkPrintBarcode.Location = New System.Drawing.Point(625, 520)
        Me.chkPrintBarcode.Name = "chkPrintBarcode"
        Me.chkPrintBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPrintBarcode.Size = New System.Drawing.Size(191, 24)
        Me.chkPrintBarcode.TabIndex = 32
        Me.chkPrintBarcode.Text = "طباعة الباركود مع الفاتورة"
        Me.chkPrintBarcode.UseVisualStyleBackColor = True
        '
        'chkPrintLogo
        '
        Me.chkPrintLogo.AutoSize = True
        Me.chkPrintLogo.Checked = True
        Me.chkPrintLogo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintLogo.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.chkPrintLogo.ForeColor = System.Drawing.Color.Black
        Me.chkPrintLogo.Location = New System.Drawing.Point(826, 520)
        Me.chkPrintLogo.Name = "chkPrintLogo"
        Me.chkPrintLogo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPrintLogo.Size = New System.Drawing.Size(183, 24)
        Me.chkPrintLogo.TabIndex = 31
        Me.chkPrintLogo.Text = "طباعة اللوجو مع الفاتورة"
        Me.chkPrintLogo.UseVisualStyleBackColor = True
        '
        'rbStyleAdvanced
        '
        Me.rbStyleAdvanced.AutoSize = True
        Me.rbStyleAdvanced.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.rbStyleAdvanced.ForeColor = System.Drawing.Color.Black
        Me.rbStyleAdvanced.Location = New System.Drawing.Point(668, 485)
        Me.rbStyleAdvanced.Name = "rbStyleAdvanced"
        Me.rbStyleAdvanced.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rbStyleAdvanced.Size = New System.Drawing.Size(76, 24)
        Me.rbStyleAdvanced.TabIndex = 30
        Me.rbStyleAdvanced.Text = "استيل 2"
        Me.rbStyleAdvanced.UseVisualStyleBackColor = True
        '
        'rbStyleSimple
        '
        Me.rbStyleSimple.AutoSize = True
        Me.rbStyleSimple.Checked = True
        Me.rbStyleSimple.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.rbStyleSimple.ForeColor = System.Drawing.Color.Black
        Me.rbStyleSimple.Location = New System.Drawing.Point(847, 488)
        Me.rbStyleSimple.Name = "rbStyleSimple"
        Me.rbStyleSimple.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rbStyleSimple.Size = New System.Drawing.Size(76, 24)
        Me.rbStyleSimple.TabIndex = 29
        Me.rbStyleSimple.TabStop = True
        Me.rbStyleSimple.Text = "استيل 1"
        Me.rbStyleSimple.UseVisualStyleBackColor = True
        '
        'lblPrintStyle
        '
        Me.lblPrintStyle.AutoSize = True
        Me.lblPrintStyle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrintStyle.ForeColor = System.Drawing.Color.Black
        Me.lblPrintStyle.Location = New System.Drawing.Point(1077, 488)
        Me.lblPrintStyle.Name = "lblPrintStyle"
        Me.lblPrintStyle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPrintStyle.Size = New System.Drawing.Size(93, 21)
        Me.lblPrintStyle.TabIndex = 28
        Me.lblPrintStyle.Text = "نمط الطباعة:"
        '
        'cmbNormalPrinter
        '
        Me.cmbNormalPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNormalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbNormalPrinter.FormattingEnabled = True
        Me.cmbNormalPrinter.Location = New System.Drawing.Point(657, 440)
        Me.cmbNormalPrinter.Name = "cmbNormalPrinter"
        Me.cmbNormalPrinter.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbNormalPrinter.Size = New System.Drawing.Size(400, 28)
        Me.cmbNormalPrinter.TabIndex = 27
        '
        'lblNormalPrinter
        '
        Me.lblNormalPrinter.AutoSize = True
        Me.lblNormalPrinter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormalPrinter.ForeColor = System.Drawing.Color.Black
        Me.lblNormalPrinter.Location = New System.Drawing.Point(1077, 443)
        Me.lblNormalPrinter.Name = "lblNormalPrinter"
        Me.lblNormalPrinter.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNormalPrinter.Size = New System.Drawing.Size(109, 21)
        Me.lblNormalPrinter.TabIndex = 26
        Me.lblNormalPrinter.Text = "الطابعة العادية:"
        '
        'cmbThermalPrinter
        '
        Me.cmbThermalPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbThermalPrinter.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbThermalPrinter.FormattingEnabled = True
        Me.cmbThermalPrinter.Location = New System.Drawing.Point(657, 395)
        Me.cmbThermalPrinter.Name = "cmbThermalPrinter"
        Me.cmbThermalPrinter.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbThermalPrinter.Size = New System.Drawing.Size(400, 28)
        Me.cmbThermalPrinter.TabIndex = 25
        '
        'lblThermalPrinter
        '
        Me.lblThermalPrinter.AutoSize = True
        Me.lblThermalPrinter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThermalPrinter.ForeColor = System.Drawing.Color.Black
        Me.lblThermalPrinter.Location = New System.Drawing.Point(1077, 398)
        Me.lblThermalPrinter.Name = "lblThermalPrinter"
        Me.lblThermalPrinter.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblThermalPrinter.Size = New System.Drawing.Size(115, 21)
        Me.lblThermalPrinter.TabIndex = 24
        Me.lblThermalPrinter.Text = "الطابعة الحرارية:"
        '
        'lblLogoHint
        '
        Me.lblLogoHint.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLogoHint.ForeColor = System.Drawing.Color.Orange
        Me.lblLogoHint.Location = New System.Drawing.Point(239, 188)
        Me.lblLogoHint.Name = "lblLogoHint"
        Me.lblLogoHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLogoHint.Size = New System.Drawing.Size(188, 68)
        Me.lblLogoHint.TabIndex = 23
        Me.lblLogoHint.Text = "💡 أفضل مقاس للّوجو:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "صورة مربّعة 300×300 بكسل" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(أو 200×200 على الأقل)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "بصيغة PNG" &
    " بخلفية بيضاء أو شفافة."
        Me.lblLogoHint.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'picLogoPreview
        '
        Me.picLogoPreview.BackColor = System.Drawing.Color.White
        Me.picLogoPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLogoPreview.Location = New System.Drawing.Point(113, 165)
        Me.picLogoPreview.Name = "picLogoPreview"
        Me.picLogoPreview.Size = New System.Drawing.Size(120, 120)
        Me.picLogoPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogoPreview.TabIndex = 22
        Me.picLogoPreview.TabStop = False
        '
        'lblPreview
        '
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPreview.ForeColor = System.Drawing.Color.Black
        Me.lblPreview.Location = New System.Drawing.Point(162, 145)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPreview.Size = New System.Drawing.Size(74, 15)
        Me.lblPreview.TabIndex = 21
        Me.lblPreview.Text = "معاينة اللوجو:"
        '
        'lblLogoPath
        '
        Me.lblLogoPath.AutoSize = True
        Me.lblLogoPath.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogoPath.ForeColor = System.Drawing.Color.Black
        Me.lblLogoPath.Location = New System.Drawing.Point(1077, 348)
        Me.lblLogoPath.Name = "lblLogoPath"
        Me.lblLogoPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLogoPath.Size = New System.Drawing.Size(90, 21)
        Me.lblLogoPath.TabIndex = 18
        Me.lblLogoPath.Text = "مسار اللوجو:"
        '
        'lblDeliveryText
        '
        Me.lblDeliveryText.AutoSize = True
        Me.lblDeliveryText.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeliveryText.ForeColor = System.Drawing.Color.Black
        Me.lblDeliveryText.Location = New System.Drawing.Point(1072, 300)
        Me.lblDeliveryText.Name = "lblDeliveryText"
        Me.lblDeliveryText.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDeliveryText.Size = New System.Drawing.Size(98, 21)
        Me.lblDeliveryText.TabIndex = 12
        Me.lblDeliveryText.Text = "نص التوصيل:"
        '
        'lblFooterText
        '
        Me.lblFooterText.AutoSize = True
        Me.lblFooterText.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFooterText.ForeColor = System.Drawing.Color.Black
        Me.lblFooterText.Location = New System.Drawing.Point(1072, 255)
        Me.lblFooterText.Name = "lblFooterText"
        Me.lblFooterText.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblFooterText.Size = New System.Drawing.Size(87, 21)
        Me.lblFooterText.TabIndex = 10
        Me.lblFooterText.Text = "نص التذييل:"
        '
        'lblShopTax
        '
        Me.lblShopTax.AutoSize = True
        Me.lblShopTax.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopTax.ForeColor = System.Drawing.Color.Black
        Me.lblShopTax.Location = New System.Drawing.Point(1072, 210)
        Me.lblShopTax.Name = "lblShopTax"
        Me.lblShopTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblShopTax.Size = New System.Drawing.Size(105, 21)
        Me.lblShopTax.TabIndex = 8
        Me.lblShopTax.Text = "الرقم الضريبي:"
        '
        'lblShopAddress
        '
        Me.lblShopAddress.AutoSize = True
        Me.lblShopAddress.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopAddress.ForeColor = System.Drawing.Color.Black
        Me.lblShopAddress.Location = New System.Drawing.Point(1072, 165)
        Me.lblShopAddress.Name = "lblShopAddress"
        Me.lblShopAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblShopAddress.Size = New System.Drawing.Size(60, 21)
        Me.lblShopAddress.TabIndex = 6
        Me.lblShopAddress.Text = "العنوان:"
        '
        'lblShopPhone2
        '
        Me.lblShopPhone2.AutoSize = True
        Me.lblShopPhone2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopPhone2.ForeColor = System.Drawing.Color.Black
        Me.lblShopPhone2.Location = New System.Drawing.Point(1072, 120)
        Me.lblShopPhone2.Name = "lblShopPhone2"
        Me.lblShopPhone2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblShopPhone2.Size = New System.Drawing.Size(96, 21)
        Me.lblShopPhone2.TabIndex = 4
        Me.lblShopPhone2.Text = "رقم الهاتف 2:"
        '
        'lblShopPhone
        '
        Me.lblShopPhone.AutoSize = True
        Me.lblShopPhone.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopPhone.ForeColor = System.Drawing.Color.Black
        Me.lblShopPhone.Location = New System.Drawing.Point(1072, 75)
        Me.lblShopPhone.Name = "lblShopPhone"
        Me.lblShopPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblShopPhone.Size = New System.Drawing.Size(96, 21)
        Me.lblShopPhone.TabIndex = 2
        Me.lblShopPhone.Text = "رقم الهاتف 1:"
        '
        'lblShopName
        '
        Me.lblShopName.AutoSize = True
        Me.lblShopName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopName.ForeColor = System.Drawing.Color.Black
        Me.lblShopName.Location = New System.Drawing.Point(1072, 30)
        Me.lblShopName.Name = "lblShopName"
        Me.lblShopName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblShopName.Size = New System.Drawing.Size(82, 21)
        Me.lblShopName.TabIndex = 0
        Me.lblShopName.Text = "اسم المحل:"
        '
        'public_set
        '
        Me.public_set.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.public_set.Controls.Add(Me.TabPage1)
        Me.public_set.Controls.Add(Me.TabPage2)
        Me.public_set.Controls.Add(Me.TabPage3)
        Me.public_set.Controls.Add(Me.TabPage5)
        Me.public_set.Dock = System.Windows.Forms.DockStyle.Fill
        Me.public_set.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.public_set.ItemSize = New System.Drawing.Size(220, 65)
        Me.public_set.Location = New System.Drawing.Point(0, 70)
        Me.public_set.Name = "public_set"
        Me.public_set.SelectedIndex = 0
        Me.public_set.ShowToolTips = True
        Me.public_set.Size = New System.Drawing.Size(1500, 730)
        Me.public_set.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty
        Me.public_set.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.public_set.TabButtonHoverState.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!)
        Me.public_set.TabButtonHoverState.ForeColor = System.Drawing.Color.White
        Me.public_set.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.public_set.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty
        Me.public_set.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.public_set.TabButtonIdleState.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!)
        Me.public_set.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.public_set.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.public_set.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty
        Me.public_set.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.public_set.TabButtonSelectedState.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!)
        Me.public_set.TabButtonSelectedState.ForeColor = System.Drawing.Color.White
        Me.public_set.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.public_set.TabButtonSize = New System.Drawing.Size(220, 65)
        Me.public_set.TabIndex = 1
        Me.public_set.TabMenuBackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.public_set.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.VerticalRight
        '
        'cmbBranches
        '
        Me.cmbBranches.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBranches.BackColor = System.Drawing.Color.Transparent
        Me.cmbBranches.BorderRadius = 8
        Me.cmbBranches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBranches.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBranches.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBranches.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbBranches.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbBranches.ItemHeight = 40
        Me.cmbBranches.Location = New System.Drawing.Point(698, 509)
        Me.cmbBranches.Name = "cmbBranches"
        Me.cmbBranches.Size = New System.Drawing.Size(306, 46)
        Me.cmbBranches.TabIndex = 5656
        Me.cmbBranches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1033, 514)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(223, 36)
        Me.Label8.TabIndex = 5655
        Me.Label8.Text = "الفرع الحالي"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbStores
        '
        Me.cmbStores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStores.BackColor = System.Drawing.Color.Transparent
        Me.cmbStores.BorderRadius = 8
        Me.cmbStores.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStores.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbStores.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbStores.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbStores.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbStores.ItemHeight = 40
        Me.cmbStores.Location = New System.Drawing.Point(698, 590)
        Me.cmbStores.Name = "cmbStores"
        Me.cmbStores.Size = New System.Drawing.Size(306, 46)
        Me.cmbStores.TabIndex = 5658
        Me.cmbStores.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(1033, 595)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(223, 36)
        Me.Label9.TabIndex = 5657
        Me.Label9.Text = "المخزن الحالي"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(1500, 850)
        Me.Controls.Add(Me.public_set)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.pnlScannerAdvanced.ResumeLayout(False)
        Me.pnlScannerAdvanced.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.picLogoPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.public_set.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pn_title_page As Label
    Friend WithEvents LabelDeveloper As Label

    Friend WithEvents _tips As ToolTip
    Friend WithEvents TabPage5 As TabPage
    Public WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtInvoiceItemsPerPage As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents pnlScannerAdvanced As Panel
    Friend WithEvents txtScanTestResult As TextBox
    Friend WithEvents lblScanTestHint As Label
    Friend WithEvents cmbStopBits As ComboBox
    Friend WithEvents lblStopBits As Label
    Friend WithEvents cmbParity As ComboBox
    Friend WithEvents lblParity As Label
    Friend WithEvents cmbDataBits As ComboBox
    Friend WithEvents lblDataBits As Label
    Friend WithEvents cmbBaudRate As ComboBox
    Friend WithEvents lblBaudRate As Label
    Friend WithEvents lblScannerAdvTitle As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBoxEnabled As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents ComboBoxPorts As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnRefreshPorts As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCloseConnection As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTestConnection As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSavebarcode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnSaveDbSettings As Button
    Friend WithEvents btnTestDbConnection As Button
    Friend WithEvents lblDbStatus As Label
    Friend WithEvents txtDbPassword As TextBox
    Friend WithEvents txtDbUser As TextBox
    Friend WithEvents txtDbName As TextBox
    Friend WithEvents lblDbPassword As Label
    Friend WithEvents lblDbUser As Label
    Friend WithEvents chkWindowsAuth As CheckBox
    Friend WithEvents lblDbName As Label
    Friend WithEvents btnDetectServers As Button
    Friend WithEvents txtDbServer As ComboBox
    Friend WithEvents lblDbServer As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnBrowseLogo As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtLogoPath As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtDeliveryText As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtFooterText As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtShopTax As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtShopAddress As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtShopPhone2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtShopPhone As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtShopName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSaveGeneral As Button
    Friend WithEvents btnTestThermal As Button
    Friend WithEvents btnRefreshPrinters As Button
    Friend WithEvents chkPrintPreview As CheckBox
    Friend WithEvents chkPrintBarcode As CheckBox
    Friend WithEvents chkPrintLogo As CheckBox
    Friend WithEvents rbStyleAdvanced As RadioButton
    Friend WithEvents rbStyleSimple As RadioButton
    Friend WithEvents lblPrintStyle As Label
    Friend WithEvents cmbNormalPrinter As ComboBox
    Friend WithEvents lblNormalPrinter As Label
    Friend WithEvents cmbThermalPrinter As ComboBox
    Friend WithEvents lblThermalPrinter As Label
    Friend WithEvents lblLogoHint As Label
    Friend WithEvents picLogoPreview As PictureBox
    Friend WithEvents lblPreview As Label
    Friend WithEvents lblLogoPath As Label
    Friend WithEvents lblDeliveryText As Label
    Friend WithEvents lblFooterText As Label
    Friend WithEvents lblShopTax As Label
    Friend WithEvents lblShopAddress As Label
    Friend WithEvents lblShopPhone2 As Label
    Friend WithEvents lblShopPhone As Label
    Friend WithEvents lblShopName As Label
    Friend WithEvents public_set As Guna.UI2.WinForms.Guna2TabControl
    Public WithEvents cmbDefaultDriver As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label7 As Label
    Public WithEvents cmbDefaultOrderType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnIsDineInServiceFeePercent As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtDineInServiceFee As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label10 As Label
    Public WithEvents cmbDefaultCustomer As Guna.UI2.WinForms.Guna2ComboBox
    Public WithEvents cmbStores As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label9 As Label
    Public WithEvents cmbBranches As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label8 As Label
End Class
