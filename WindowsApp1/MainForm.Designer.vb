<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnLogout = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSupport = New Guna.UI2.WinForms.Guna2Button()
        Me.lbltitle = New System.Windows.Forms.Label()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSalesReturns = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator50 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnKds = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator51 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnWaste = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator52 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator53 = New System.Windows.Forms.ToolStripSeparator()
        Me.statusStripMain = New System.Windows.Forms.StatusStrip()
        Me.lblStatusUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusRole = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusBranch = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusShift = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusDateTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusDb = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlDashboard = New Guna.UI2.WinForms.Guna2Panel()
        Me.tlpMainContent = New System.Windows.Forms.TableLayoutPanel()
        Me.cardRecentInvoices = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgvRecentInvoices = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.colInvNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvPayment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlInvoicesHeader = New System.Windows.Forms.Panel()
        Me.btnViewAllInvoices = New Guna.UI2.WinForms.Guna2Button()
        Me.lblRecentInvoicesTitle = New System.Windows.Forms.Label()
        Me.cardAlerts = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlAlertsContainer = New System.Windows.Forms.Panel()
        Me.cardAlertBackup = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblAlertBackupDesc = New System.Windows.Forms.Label()
        Me.lblAlertBackupTitle = New System.Windows.Forms.Label()
        Me.cardAlertShift = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblAlertShiftDesc = New System.Windows.Forms.Label()
        Me.lblAlertShiftTitle = New System.Windows.Forms.Label()
        Me.cardAlertStock = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblAlertStockDesc = New System.Windows.Forms.Label()
        Me.lblAlertStockTitle = New System.Windows.Forms.Label()
        Me.pnlQuickButtons = New System.Windows.Forms.Panel()
        Me.tlpQuickBtns = New System.Windows.Forms.TableLayoutPanel()
        Me.btnQuickPOS = New Guna.UI2.WinForms.Guna2Button()
        Me.btnQuickProducts = New Guna.UI2.WinForms.Guna2Button()
        Me.btnQuickCustomers = New Guna.UI2.WinForms.Guna2Button()
        Me.btnQuickBackup = New Guna.UI2.WinForms.Guna2Button()
        Me.lblQuickTitle = New System.Windows.Forms.Label()
        Me.pnlAlertsHeader = New System.Windows.Forms.Panel()
        Me.lblAlertsTitle = New System.Windows.Forms.Label()
        Me.tlpStats = New System.Windows.Forms.TableLayoutPanel()
        Me.cardSales = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardSalesSub = New System.Windows.Forms.Label()
        Me.lblCardSalesVal = New System.Windows.Forms.Label()
        Me.lblCardSalesTitle = New System.Windows.Forms.Label()
        Me.picCardSales = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardPurchases = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardPurchasesSub = New System.Windows.Forms.Label()
        Me.lblCardPurchasesVal = New System.Windows.Forms.Label()
        Me.lblCardPurchasesTitle = New System.Windows.Forms.Label()
        Me.picCardPurchases = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardProfit = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardProfitSub = New System.Windows.Forms.Label()
        Me.lblCardProfitVal = New System.Windows.Forms.Label()
        Me.lblCardProfitTitle = New System.Windows.Forms.Label()
        Me.picCardProfit = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardProducts = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardProductsSub = New System.Windows.Forms.Label()
        Me.lblCardProductsVal = New System.Windows.Forms.Label()
        Me.lblCardProductsTitle = New System.Windows.Forms.Label()
        Me.picCardProducts = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardCustomers = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardCustomersSub = New System.Windows.Forms.Label()
        Me.lblCardCustomersVal = New System.Windows.Forms.Label()
        Me.lblCardCustomersTitle = New System.Windows.Forms.Label()
        Me.picCardCustomers = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardSuppliers = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardSuppliersSub = New System.Windows.Forms.Label()
        Me.lblCardSuppliersVal = New System.Windows.Forms.Label()
        Me.lblCardSuppliersTitle = New System.Windows.Forms.Label()
        Me.picCardSuppliers = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.pnlWelcome = New System.Windows.Forms.Panel()
        Me.btnRefreshDashboard = New Guna.UI2.WinForms.Guna2Button()
        Me.lblShiftDuration = New System.Windows.Forms.Label()
        Me.lblWelcomeSub = New System.Windows.Forms.Label()
        Me.lblWelcomeGreeting = New System.Windows.Forms.Label()
        Me.tmrClock = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDashboardRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnCategories = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnProducts = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmProductSizes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmProductAddons = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmKitchenComments = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparatorKitchenComments = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmDeliveryAreas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmDeliveryDrivers = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmShifts = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnShiftReports = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparatorShiftReports = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmBranches = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator37 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabControl1 = New Guna.UI2.WinForms.Guna2TabControl()
        Me.tabsystem = New System.Windows.Forms.TabPage()
        Me.tabCustomers = New System.Windows.Forms.TabPage()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnFrmCustomers = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFrmCustomerStatement = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCustomerBalanceDownload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabSuppliers = New System.Windows.Forms.TabPage()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabSales = New System.Windows.Forms.TabPage()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.btnfrmPOS = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFrmSalesReport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFrmDriverReport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabPurchases = New System.Windows.Forms.TabPage()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.btnfrmPurchases = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmPurchaseReports = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabStorage = New System.Windows.Forms.TabPage()
        Me.ToolStrip6 = New System.Windows.Forms.ToolStrip()
        Me.btnfrmTreasury = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFrmTreasuryTransfer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFrmTreasuryTransactionsReport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDeposit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator43 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnWithdraw = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator42 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabExpenses = New System.Windows.Forms.TabPage()
        Me.ToolStrip10 = New System.Windows.Forms.ToolStrip()
        Me.btnform_Expenses = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator40 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExpensesReportForm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator41 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabemployees = New System.Windows.Forms.TabPage()
        Me.ToolStrip7 = New System.Windows.Forms.ToolStrip()
        Me.btnfrmEmployees = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmJobTitles = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmDepartments = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmSalarySystems = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmSalaryPayment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabUsers = New System.Windows.Forms.TabPage()
        Me.ToolStrip11 = New System.Windows.Forms.ToolStrip()
        Me.btnfrmUsers = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmRolesAndPermissions = New System.Windows.Forms.ToolStripButton()
        Me.tabbackup = New System.Windows.Forms.TabPage()
        Me.ToolStrip8 = New System.Windows.Forms.ToolStrip()
        Me.btnBackups = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator38 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.ToolStripSet = New System.Windows.Forms.ToolStrip()
        Me.btnSettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmColors = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmPrinters = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmRestaurantSections = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmRestaurantTables = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmUnits = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmStores = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator44 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmStoreStock = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator45 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmRawMaterials = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator47 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnfrmRecipes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator46 = New System.Windows.Forms.ToolStripSeparator()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.statusStripMain.SuspendLayout()
        Me.pnlDashboard.SuspendLayout()
        Me.tlpMainContent.SuspendLayout()
        Me.cardRecentInvoices.SuspendLayout()
        CType(Me.dgvRecentInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInvoicesHeader.SuspendLayout()
        Me.cardAlerts.SuspendLayout()
        Me.pnlAlertsContainer.SuspendLayout()
        Me.cardAlertBackup.SuspendLayout()
        Me.cardAlertShift.SuspendLayout()
        Me.cardAlertStock.SuspendLayout()
        Me.pnlQuickButtons.SuspendLayout()
        Me.tlpQuickBtns.SuspendLayout()
        Me.pnlAlertsHeader.SuspendLayout()
        Me.tlpStats.SuspendLayout()
        Me.cardSales.SuspendLayout()
        CType(Me.picCardSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardPurchases.SuspendLayout()
        CType(Me.picCardPurchases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardProfit.SuspendLayout()
        CType(Me.picCardProfit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardProducts.SuspendLayout()
        CType(Me.picCardProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardCustomers.SuspendLayout()
        CType(Me.picCardCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardSuppliers.SuspendLayout()
        CType(Me.picCardSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWelcome.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabsystem.SuspendLayout()
        Me.tabCustomers.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.tabSuppliers.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.tabSales.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.tabPurchases.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.tabStorage.SuspendLayout()
        Me.ToolStrip6.SuspendLayout()
        Me.tabExpenses.SuspendLayout()
        Me.ToolStrip10.SuspendLayout()
        Me.tabemployees.SuspendLayout()
        Me.ToolStrip7.SuspendLayout()
        Me.tabUsers.SuspendLayout()
        Me.ToolStrip11.SuspendLayout()
        Me.tabbackup.SuspendLayout()
        Me.ToolStrip8.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.ToolStripSet.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btnLogout)
        Me.panelHeader.Controls.Add(Me.btnSupport)
        Me.panelHeader.Controls.Add(Me.lbltitle)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1434, 70)
        Me.panelHeader.TabIndex = 41
        '
        'lbltitle
        '
        Me.lbltitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltitle.BackColor = System.Drawing.Color.Transparent
        Me.lbltitle.Font = New System.Drawing.Font("Segoe UI", 32.0!, System.Drawing.FontStyle.Bold)
        Me.lbltitle.ForeColor = System.Drawing.Color.White
        Me.lbltitle.Location = New System.Drawing.Point(623, 1)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Size = New System.Drawing.Size(337, 61)
        Me.lbltitle.TabIndex = 5588
        Me.lbltitle.Text = "الشاشة الرئيسية"
        Me.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(103, 17)
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
        Me.btn_max.Location = New System.Drawing.Point(59, 17)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 4
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(15, 17)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 3
        '
        'btnLogout
        '
        Me.btnLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.BorderRadius = 8
        Me.btnLogout.BorderThickness = 1
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.Location = New System.Drawing.Point(1280, 16)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnLogout.Size = New System.Drawing.Size(140, 38)
        Me.btnLogout.TabIndex = 6
        Me.btnLogout.Text = "تسجيل خروج 🚪"
        '
        'btnSupport
        '
        Me.btnSupport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSupport.BorderRadius = 8
        Me.btnSupport.BorderThickness = 1
        Me.btnSupport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSupport.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSupport.Location = New System.Drawing.Point(1130, 16)
        Me.btnSupport.Name = "btnSupport"
        Me.btnSupport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSupport.Size = New System.Drawing.Size(140, 38)
        Me.btnSupport.TabIndex = 7
        Me.btnSupport.Text = "الدعم الفني 🎧"
        '
        'btnSalesReturns
        '
        Me.btnSalesReturns.AutoSize = False
        Me.btnSalesReturns.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalesReturns.ForeColor = System.Drawing.Color.Black
        Me.btnSalesReturns.Image = Global.WindowsApp1.My.Resources.Resources.order
        Me.btnSalesReturns.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalesReturns.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSalesReturns.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalesReturns.Name = "btnSalesReturns"
        Me.btnSalesReturns.Size = New System.Drawing.Size(150, 100)
        Me.btnSalesReturns.Text = "مرتجع المبيعات"
        Me.btnSalesReturns.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator50
        '
        Me.ToolStripSeparator50.AutoSize = False
        Me.ToolStripSeparator50.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator50.Name = "ToolStripSeparator50"
        Me.ToolStripSeparator50.Size = New System.Drawing.Size(10, 113)
        '
        'statusStripMain
        '
        Me.statusStripMain.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusUser, Me.sepStatus1, Me.lblStatusRole, Me.sepStatus2, Me.lblStatusBranch, Me.sepStatus3, Me.lblStatusShift, Me.sepStatus4, Me.lblStatusDateTime, Me.sepStatus5, Me.lblStatusDb, Me.sepStatus6, Me.lblStatusVersion})
        Me.statusStripMain.Location = New System.Drawing.Point(0, 878)
        Me.statusStripMain.Name = "statusStripMain"
        Me.statusStripMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.statusStripMain.Size = New System.Drawing.Size(1434, 22)
        Me.statusStripMain.TabIndex = 44
        Me.statusStripMain.Text = "statusStripMain"
        '
        'lblStatusUser
        '
        Me.lblStatusUser.Name = "lblStatusUser"
        Me.lblStatusUser.Size = New System.Drawing.Size(92, 17)
        Me.lblStatusUser.Text = "👤 المستخدم: -"
        '
        'sepStatus1
        '
        Me.sepStatus1.ForeColor = System.Drawing.Color.Gray
        Me.sepStatus1.Name = "sepStatus1"
        Me.sepStatus1.Size = New System.Drawing.Size(11, 17)
        Me.sepStatus1.Text = "|"
        '
        'lblStatusRole
        '
        Me.lblStatusRole.Name = "lblStatusRole"
        Me.lblStatusRole.Size = New System.Drawing.Size(84, 17)
        Me.lblStatusRole.Text = "🛡️ الصلاحية: -"
        '
        'sepStatus2
        '
        Me.sepStatus2.ForeColor = System.Drawing.Color.Gray
        Me.sepStatus2.Name = "sepStatus2"
        Me.sepStatus2.Size = New System.Drawing.Size(11, 17)
        Me.sepStatus2.Text = "|"
        '
        'lblStatusBranch
        '
        Me.lblStatusBranch.Name = "lblStatusBranch"
        Me.lblStatusBranch.Size = New System.Drawing.Size(69, 17)
        Me.lblStatusBranch.Text = "🏢 الفرع: -"
        '
        'sepStatus3
        '
        Me.sepStatus3.ForeColor = System.Drawing.Color.Gray
        Me.sepStatus3.Name = "sepStatus3"
        Me.sepStatus3.Size = New System.Drawing.Size(11, 17)
        Me.sepStatus3.Text = "|"
        '
        'lblStatusShift
        '
        Me.lblStatusShift.Name = "lblStatusShift"
        Me.lblStatusShift.Size = New System.Drawing.Size(78, 17)
        Me.lblStatusShift.Text = "⏰ الوردية: -"
        '
        'sepStatus4
        '
        Me.sepStatus4.ForeColor = System.Drawing.Color.Gray
        Me.sepStatus4.Name = "sepStatus4"
        Me.sepStatus4.Size = New System.Drawing.Size(11, 17)
        Me.sepStatus4.Text = "|"
        '
        'lblStatusDateTime
        '
        Me.lblStatusDateTime.Name = "lblStatusDateTime"
        Me.lblStatusDateTime.Size = New System.Drawing.Size(73, 17)
        Me.lblStatusDateTime.Text = "📅 التاريخ: -"
        '
        'sepStatus5
        '
        Me.sepStatus5.ForeColor = System.Drawing.Color.Gray
        Me.sepStatus5.Name = "sepStatus5"
        Me.sepStatus5.Size = New System.Drawing.Size(11, 17)
        Me.sepStatus5.Text = "|"
        '
        'lblStatusDb
        '
        Me.lblStatusDb.Name = "lblStatusDb"
        Me.lblStatusDb.Size = New System.Drawing.Size(144, 17)
        Me.lblStatusDb.Text = "🟢 قاعدة البيانات: متصل"
        '
        'sepStatus6
        '
        Me.sepStatus6.ForeColor = System.Drawing.Color.Gray
        Me.sepStatus6.Name = "sepStatus6"
        Me.sepStatus6.Size = New System.Drawing.Size(11, 17)
        Me.sepStatus6.Text = "|"
        '
        'lblStatusVersion
        '
        Me.lblStatusVersion.Name = "lblStatusVersion"
        Me.lblStatusVersion.Size = New System.Drawing.Size(41, 17)
        Me.lblStatusVersion.Text = "v2.5.0"
        '
        'pnlDashboard
        '
        Me.pnlDashboard.AutoScroll = True
        Me.pnlDashboard.Controls.Add(Me.tlpMainContent)
        Me.pnlDashboard.Controls.Add(Me.tlpStats)
        Me.pnlDashboard.Controls.Add(Me.pnlWelcome)
        Me.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDashboard.Location = New System.Drawing.Point(0, 317)
        Me.pnlDashboard.Name = "pnlDashboard"
        Me.pnlDashboard.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlDashboard.Size = New System.Drawing.Size(1434, 561)
        Me.pnlDashboard.TabIndex = 45
        '
        'tlpMainContent
        '
        Me.tlpMainContent.ColumnCount = 2
        Me.tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.0!))
        Me.tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0!))
        Me.tlpMainContent.Controls.Add(Me.cardRecentInvoices, 0, 0)
        Me.tlpMainContent.Controls.Add(Me.cardAlerts, 1, 0)
        Me.tlpMainContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMainContent.Location = New System.Drawing.Point(0, 175)
        Me.tlpMainContent.Name = "tlpMainContent"
        Me.tlpMainContent.Padding = New System.Windows.Forms.Padding(10, 4, 10, 6)
        Me.tlpMainContent.RowCount = 1
        Me.tlpMainContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMainContent.Size = New System.Drawing.Size(1434, 386)
        Me.tlpMainContent.TabIndex = 2
        '
        'cardRecentInvoices
        '
        Me.cardRecentInvoices.BorderRadius = 12
        Me.cardRecentInvoices.Controls.Add(Me.dgvRecentInvoices)
        Me.cardRecentInvoices.Controls.Add(Me.pnlInvoicesHeader)
        Me.cardRecentInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardRecentInvoices.Location = New System.Drawing.Point(554, 7)
        Me.cardRecentInvoices.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.cardRecentInvoices.Name = "cardRecentInvoices"
        Me.cardRecentInvoices.Padding = New System.Windows.Forms.Padding(10)
        Me.cardRecentInvoices.Size = New System.Drawing.Size(864, 370)
        Me.cardRecentInvoices.TabIndex = 0
        '
        'dgvRecentInvoices
        '
        Me.dgvRecentInvoices.AllowUserToAddRows = False
        Me.dgvRecentInvoices.AllowUserToDeleteRows = False
        Me.dgvRecentInvoices.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRecentInvoices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRecentInvoices.ColumnHeadersHeight = 32
        Me.dgvRecentInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInvNum, Me.colInvTime, Me.colInvCustomer, Me.colInvType, Me.colInvTotal, Me.colInvPayment})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRecentInvoices.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRecentInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRecentInvoices.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvRecentInvoices.Location = New System.Drawing.Point(10, 46)
        Me.dgvRecentInvoices.Name = "dgvRecentInvoices"
        Me.dgvRecentInvoices.ReadOnly = True
        Me.dgvRecentInvoices.RowHeadersVisible = False
        Me.dgvRecentInvoices.RowTemplate.Height = 28
        Me.dgvRecentInvoices.Size = New System.Drawing.Size(844, 314)
        Me.dgvRecentInvoices.TabIndex = 1
        Me.dgvRecentInvoices.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dgvRecentInvoices.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRecentInvoices.ThemeStyle.HeaderStyle.Height = 32
        Me.dgvRecentInvoices.ThemeStyle.ReadOnly = True
        Me.dgvRecentInvoices.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dgvRecentInvoices.ThemeStyle.RowsStyle.Height = 28
        '
        'colInvNum
        '
        Me.colInvNum.HeaderText = "رقم الفاتورة"
        Me.colInvNum.Name = "colInvNum"
        Me.colInvNum.ReadOnly = True
        '
        'colInvTime
        '
        Me.colInvTime.HeaderText = "الوقت"
        Me.colInvTime.Name = "colInvTime"
        Me.colInvTime.ReadOnly = True
        '
        'colInvCustomer
        '
        Me.colInvCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colInvCustomer.HeaderText = "العميل"
        Me.colInvCustomer.Name = "colInvCustomer"
        Me.colInvCustomer.ReadOnly = True
        '
        'colInvType
        '
        Me.colInvType.HeaderText = "نوع الطلب"
        Me.colInvType.Name = "colInvType"
        Me.colInvType.ReadOnly = True
        '
        'colInvTotal
        '
        Me.colInvTotal.HeaderText = "المبلغ"
        Me.colInvTotal.Name = "colInvTotal"
        Me.colInvTotal.ReadOnly = True
        '
        'colInvPayment
        '
        Me.colInvPayment.HeaderText = "الدفع"
        Me.colInvPayment.Name = "colInvPayment"
        Me.colInvPayment.ReadOnly = True
        '
        'pnlInvoicesHeader
        '
        Me.pnlInvoicesHeader.Controls.Add(Me.btnViewAllInvoices)
        Me.pnlInvoicesHeader.Controls.Add(Me.lblRecentInvoicesTitle)
        Me.pnlInvoicesHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInvoicesHeader.Location = New System.Drawing.Point(10, 10)
        Me.pnlInvoicesHeader.Name = "pnlInvoicesHeader"
        Me.pnlInvoicesHeader.Size = New System.Drawing.Size(844, 36)
        Me.pnlInvoicesHeader.TabIndex = 0
        '
        'btnViewAllInvoices
        '
        Me.btnViewAllInvoices.BorderRadius = 6
        Me.btnViewAllInvoices.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewAllInvoices.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewAllInvoices.ForeColor = System.Drawing.Color.White
        Me.btnViewAllInvoices.Location = New System.Drawing.Point(746, 3)
        Me.btnViewAllInvoices.Name = "btnViewAllInvoices"
        Me.btnViewAllInvoices.Size = New System.Drawing.Size(95, 28)
        Me.btnViewAllInvoices.TabIndex = 1
        Me.btnViewAllInvoices.Text = "عرض الكل "
        '
        'lblRecentInvoicesTitle
        '
        Me.lblRecentInvoicesTitle.AutoSize = True
        Me.lblRecentInvoicesTitle.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecentInvoicesTitle.Location = New System.Drawing.Point(5, 6)
        Me.lblRecentInvoicesTitle.Name = "lblRecentInvoicesTitle"
        Me.lblRecentInvoicesTitle.Size = New System.Drawing.Size(155, 21)
        Me.lblRecentInvoicesTitle.TabIndex = 0
        Me.lblRecentInvoicesTitle.Text = "📋 آخر فواتير المبيعات"
        '
        'cardAlerts
        '
        Me.cardAlerts.BorderRadius = 12
        Me.cardAlerts.Controls.Add(Me.pnlAlertsContainer)
        Me.cardAlerts.Controls.Add(Me.pnlQuickButtons)
        Me.cardAlerts.Controls.Add(Me.pnlAlertsHeader)
        Me.cardAlerts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardAlerts.Location = New System.Drawing.Point(16, 7)
        Me.cardAlerts.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.cardAlerts.Name = "cardAlerts"
        Me.cardAlerts.Padding = New System.Windows.Forms.Padding(10)
        Me.cardAlerts.Size = New System.Drawing.Size(526, 370)
        Me.cardAlerts.TabIndex = 1
        '
        'pnlAlertsContainer
        '
        Me.pnlAlertsContainer.AutoScroll = True
        Me.pnlAlertsContainer.Controls.Add(Me.cardAlertBackup)
        Me.pnlAlertsContainer.Controls.Add(Me.cardAlertShift)
        Me.pnlAlertsContainer.Controls.Add(Me.cardAlertStock)
        Me.pnlAlertsContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAlertsContainer.Location = New System.Drawing.Point(10, 46)
        Me.pnlAlertsContainer.Name = "pnlAlertsContainer"
        Me.pnlAlertsContainer.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        Me.pnlAlertsContainer.Size = New System.Drawing.Size(506, 228)
        Me.pnlAlertsContainer.TabIndex = 1
        '
        'cardAlertBackup
        '
        Me.cardAlertBackup.BorderRadius = 8
        Me.cardAlertBackup.Controls.Add(Me.lblAlertBackupDesc)
        Me.cardAlertBackup.Controls.Add(Me.lblAlertBackupTitle)
        Me.cardAlertBackup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardAlertBackup.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAlertBackup.Location = New System.Drawing.Point(0, 124)
        Me.cardAlertBackup.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.cardAlertBackup.Name = "cardAlertBackup"
        Me.cardAlertBackup.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.cardAlertBackup.Size = New System.Drawing.Size(506, 60)
        Me.cardAlertBackup.TabIndex = 2
        '
        'lblAlertBackupDesc
        '
        Me.lblAlertBackupDesc.AutoSize = True
        Me.lblAlertBackupDesc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertBackupDesc.ForeColor = System.Drawing.Color.Gray
        Me.lblAlertBackupDesc.Location = New System.Drawing.Point(11, 28)
        Me.lblAlertBackupDesc.Name = "lblAlertBackupDesc"
        Me.lblAlertBackupDesc.Size = New System.Drawing.Size(78, 15)
        Me.lblAlertBackupDesc.TabIndex = 1
        Me.lblAlertBackupDesc.Text = "جاري الفحص..."
        '
        'lblAlertBackupTitle
        '
        Me.lblAlertBackupTitle.AutoSize = True
        Me.lblAlertBackupTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertBackupTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblAlertBackupTitle.Location = New System.Drawing.Point(10, 6)
        Me.lblAlertBackupTitle.Name = "lblAlertBackupTitle"
        Me.lblAlertBackupTitle.Size = New System.Drawing.Size(153, 17)
        Me.lblAlertBackupTitle.TabIndex = 0
        Me.lblAlertBackupTitle.Text = "💾 النسخ الاحتياطي للنظام"
        '
        'cardAlertShift
        '
        Me.cardAlertShift.BorderRadius = 8
        Me.cardAlertShift.Controls.Add(Me.lblAlertShiftDesc)
        Me.cardAlertShift.Controls.Add(Me.lblAlertShiftTitle)
        Me.cardAlertShift.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardAlertShift.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAlertShift.Location = New System.Drawing.Point(0, 64)
        Me.cardAlertShift.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.cardAlertShift.Name = "cardAlertShift"
        Me.cardAlertShift.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.cardAlertShift.Size = New System.Drawing.Size(506, 60)
        Me.cardAlertShift.TabIndex = 1
        '
        'lblAlertShiftDesc
        '
        Me.lblAlertShiftDesc.AutoSize = True
        Me.lblAlertShiftDesc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertShiftDesc.ForeColor = System.Drawing.Color.Gray
        Me.lblAlertShiftDesc.Location = New System.Drawing.Point(11, 28)
        Me.lblAlertShiftDesc.Name = "lblAlertShiftDesc"
        Me.lblAlertShiftDesc.Size = New System.Drawing.Size(78, 15)
        Me.lblAlertShiftDesc.TabIndex = 1
        Me.lblAlertShiftDesc.Text = "جاري الفحص..."
        '
        'lblAlertShiftTitle
        '
        Me.lblAlertShiftTitle.AutoSize = True
        Me.lblAlertShiftTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertShiftTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblAlertShiftTitle.Location = New System.Drawing.Point(10, 6)
        Me.lblAlertShiftTitle.Name = "lblAlertShiftTitle"
        Me.lblAlertShiftTitle.Size = New System.Drawing.Size(130, 17)
        Me.lblAlertShiftTitle.TabIndex = 0
        Me.lblAlertShiftTitle.Text = "⏰ حالة الوردية الحالية"
        '
        'cardAlertStock
        '
        Me.cardAlertStock.BorderRadius = 8
        Me.cardAlertStock.Controls.Add(Me.lblAlertStockDesc)
        Me.cardAlertStock.Controls.Add(Me.lblAlertStockTitle)
        Me.cardAlertStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardAlertStock.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAlertStock.Location = New System.Drawing.Point(0, 4)
        Me.cardAlertStock.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.cardAlertStock.Name = "cardAlertStock"
        Me.cardAlertStock.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.cardAlertStock.Size = New System.Drawing.Size(506, 60)
        Me.cardAlertStock.TabIndex = 0
        '
        'lblAlertStockDesc
        '
        Me.lblAlertStockDesc.AutoSize = True
        Me.lblAlertStockDesc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertStockDesc.ForeColor = System.Drawing.Color.Gray
        Me.lblAlertStockDesc.Location = New System.Drawing.Point(11, 28)
        Me.lblAlertStockDesc.Name = "lblAlertStockDesc"
        Me.lblAlertStockDesc.Size = New System.Drawing.Size(78, 15)
        Me.lblAlertStockDesc.TabIndex = 1
        Me.lblAlertStockDesc.Text = "جاري الفحص..."
        '
        'lblAlertStockTitle
        '
        Me.lblAlertStockTitle.AutoSize = True
        Me.lblAlertStockTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertStockTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.lblAlertStockTitle.Location = New System.Drawing.Point(10, 6)
        Me.lblAlertStockTitle.Name = "lblAlertStockTitle"
        Me.lblAlertStockTitle.Size = New System.Drawing.Size(116, 17)
        Me.lblAlertStockTitle.TabIndex = 0
        Me.lblAlertStockTitle.Text = "⚠️ نواقص المخزون"
        '
        'pnlQuickButtons
        '
        Me.pnlQuickButtons.Controls.Add(Me.tlpQuickBtns)
        Me.pnlQuickButtons.Controls.Add(Me.lblQuickTitle)
        Me.pnlQuickButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlQuickButtons.Location = New System.Drawing.Point(10, 274)
        Me.pnlQuickButtons.Name = "pnlQuickButtons"
        Me.pnlQuickButtons.Size = New System.Drawing.Size(506, 86)
        Me.pnlQuickButtons.TabIndex = 2
        '
        'tlpQuickBtns
        '
        Me.tlpQuickBtns.ColumnCount = 4
        Me.tlpQuickBtns.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpQuickBtns.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpQuickBtns.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpQuickBtns.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpQuickBtns.Controls.Add(Me.btnQuickPOS, 0, 0)
        Me.tlpQuickBtns.Controls.Add(Me.btnQuickProducts, 1, 0)
        Me.tlpQuickBtns.Controls.Add(Me.btnQuickCustomers, 2, 0)
        Me.tlpQuickBtns.Controls.Add(Me.btnQuickBackup, 3, 0)
        Me.tlpQuickBtns.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlpQuickBtns.Location = New System.Drawing.Point(0, 32)
        Me.tlpQuickBtns.Name = "tlpQuickBtns"
        Me.tlpQuickBtns.RowCount = 1
        Me.tlpQuickBtns.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpQuickBtns.Size = New System.Drawing.Size(506, 54)
        Me.tlpQuickBtns.TabIndex = 1
        '
        'btnQuickPOS
        '
        Me.btnQuickPOS.BorderRadius = 8
        Me.btnQuickPOS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuickPOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuickPOS.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuickPOS.ForeColor = System.Drawing.Color.White
        Me.btnQuickPOS.Location = New System.Drawing.Point(383, 3)
        Me.btnQuickPOS.Name = "btnQuickPOS"
        Me.btnQuickPOS.Size = New System.Drawing.Size(120, 48)
        Me.btnQuickPOS.TabIndex = 0
        Me.btnQuickPOS.Text = "البيع (F1)"
        '
        'btnQuickProducts
        '
        Me.btnQuickProducts.BorderRadius = 8
        Me.btnQuickProducts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuickProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuickProducts.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuickProducts.ForeColor = System.Drawing.Color.White
        Me.btnQuickProducts.Location = New System.Drawing.Point(257, 3)
        Me.btnQuickProducts.Name = "btnQuickProducts"
        Me.btnQuickProducts.Size = New System.Drawing.Size(120, 48)
        Me.btnQuickProducts.TabIndex = 1
        Me.btnQuickProducts.Text = "الأصناف (F2)"
        '
        'btnQuickCustomers
        '
        Me.btnQuickCustomers.BorderRadius = 8
        Me.btnQuickCustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuickCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuickCustomers.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuickCustomers.ForeColor = System.Drawing.Color.White
        Me.btnQuickCustomers.Location = New System.Drawing.Point(131, 3)
        Me.btnQuickCustomers.Name = "btnQuickCustomers"
        Me.btnQuickCustomers.Size = New System.Drawing.Size(120, 48)
        Me.btnQuickCustomers.TabIndex = 2
        Me.btnQuickCustomers.Text = "العملاء (F3)"
        '
        'btnQuickBackup
        '
        Me.btnQuickBackup.BorderRadius = 8
        Me.btnQuickBackup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuickBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuickBackup.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuickBackup.ForeColor = System.Drawing.Color.White
        Me.btnQuickBackup.Location = New System.Drawing.Point(3, 3)
        Me.btnQuickBackup.Name = "btnQuickBackup"
        Me.btnQuickBackup.Size = New System.Drawing.Size(122, 48)
        Me.btnQuickBackup.TabIndex = 3
        Me.btnQuickBackup.Text = "نسخ (F4)"
        '
        'lblQuickTitle
        '
        Me.lblQuickTitle.AutoSize = True
        Me.lblQuickTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuickTitle.Location = New System.Drawing.Point(4, 6)
        Me.lblQuickTitle.Name = "lblQuickTitle"
        Me.lblQuickTitle.Size = New System.Drawing.Size(198, 17)
        Me.lblQuickTitle.TabIndex = 0
        Me.lblQuickTitle.Text = "⚡ وصول سريع للشاشات الرئيسية:"
        '
        'pnlAlertsHeader
        '
        Me.pnlAlertsHeader.Controls.Add(Me.lblAlertsTitle)
        Me.pnlAlertsHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAlertsHeader.Location = New System.Drawing.Point(10, 10)
        Me.pnlAlertsHeader.Name = "pnlAlertsHeader"
        Me.pnlAlertsHeader.Size = New System.Drawing.Size(506, 36)
        Me.pnlAlertsHeader.TabIndex = 0
        '
        'lblAlertsTitle
        '
        Me.lblAlertsTitle.AutoSize = True
        Me.lblAlertsTitle.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertsTitle.Location = New System.Drawing.Point(5, 6)
        Me.lblAlertsTitle.Name = "lblAlertsTitle"
        Me.lblAlertsTitle.Size = New System.Drawing.Size(195, 21)
        Me.lblAlertsTitle.TabIndex = 0
        Me.lblAlertsTitle.Text = "🔔 تنبيهات وإشعارات سريعة"
        '
        'tlpStats
        '
        Me.tlpStats.ColumnCount = 6
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpStats.Controls.Add(Me.cardSales, 0, 0)
        Me.tlpStats.Controls.Add(Me.cardPurchases, 1, 0)
        Me.tlpStats.Controls.Add(Me.cardProfit, 2, 0)
        Me.tlpStats.Controls.Add(Me.cardProducts, 3, 0)
        Me.tlpStats.Controls.Add(Me.cardCustomers, 4, 0)
        Me.tlpStats.Controls.Add(Me.cardSuppliers, 5, 0)
        Me.tlpStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpStats.Location = New System.Drawing.Point(0, 60)
        Me.tlpStats.Name = "tlpStats"
        Me.tlpStats.Padding = New System.Windows.Forms.Padding(10, 4, 10, 4)
        Me.tlpStats.RowCount = 1
        Me.tlpStats.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpStats.Size = New System.Drawing.Size(1434, 115)
        Me.tlpStats.TabIndex = 1
        '
        'cardSales
        '
        Me.cardSales.BorderRadius = 12
        Me.cardSales.Controls.Add(Me.lblCardSalesSub)
        Me.cardSales.Controls.Add(Me.lblCardSalesVal)
        Me.cardSales.Controls.Add(Me.lblCardSalesTitle)
        Me.cardSales.Controls.Add(Me.picCardSales)
        Me.cardSales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardSales.Location = New System.Drawing.Point(1195, 7)
        Me.cardSales.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.cardSales.Name = "cardSales"
        Me.cardSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardSales.Size = New System.Drawing.Size(223, 101)
        Me.cardSales.TabIndex = 0
        '
        'lblCardSalesSub
        '
        Me.lblCardSalesSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardSalesSub.AutoSize = True
        Me.lblCardSalesSub.BackColor = System.Drawing.Color.Transparent
        Me.lblCardSalesSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCardSalesSub.ForeColor = System.Drawing.Color.Gray
        Me.lblCardSalesSub.Location = New System.Drawing.Point(7, 75)
        Me.lblCardSalesSub.Name = "lblCardSalesSub"
        Me.lblCardSalesSub.Size = New System.Drawing.Size(45, 15)
        Me.lblCardSalesSub.TabIndex = 3
        Me.lblCardSalesSub.Text = "0 فاتورة"
        '
        'lblCardSalesVal
        '
        Me.lblCardSalesVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardSalesVal.BackColor = System.Drawing.Color.Transparent
        Me.lblCardSalesVal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardSalesVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblCardSalesVal.Location = New System.Drawing.Point(5, 38)
        Me.lblCardSalesVal.Name = "lblCardSalesVal"
        Me.lblCardSalesVal.Size = New System.Drawing.Size(210, 26)
        Me.lblCardSalesVal.TabIndex = 2
        Me.lblCardSalesVal.Text = "0.00 ر.س"
        Me.lblCardSalesVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCardSalesTitle
        '
        Me.lblCardSalesTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardSalesTitle.AutoSize = True
        Me.lblCardSalesTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblCardSalesTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardSalesTitle.Location = New System.Drawing.Point(9, 8)
        Me.lblCardSalesTitle.Name = "lblCardSalesTitle"
        Me.lblCardSalesTitle.Size = New System.Drawing.Size(85, 19)
        Me.lblCardSalesTitle.TabIndex = 1
        Me.lblCardSalesTitle.Text = "مبيعات اليوم"
        '
        'picCardSales
        '
        Me.picCardSales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCardSales.BackColor = System.Drawing.Color.Transparent
        Me.picCardSales.Image = Global.WindowsApp1.My.Resources.Resources.market_analysis
        Me.picCardSales.ImageRotate = 0!
        Me.picCardSales.Location = New System.Drawing.Point(175, 10)
        Me.picCardSales.Name = "picCardSales"
        Me.picCardSales.Size = New System.Drawing.Size(38, 38)
        Me.picCardSales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardSales.TabIndex = 0
        Me.picCardSales.TabStop = False
        '
        'cardPurchases
        '
        Me.cardPurchases.BorderRadius = 12
        Me.cardPurchases.Controls.Add(Me.lblCardPurchasesSub)
        Me.cardPurchases.Controls.Add(Me.lblCardPurchasesVal)
        Me.cardPurchases.Controls.Add(Me.lblCardPurchasesTitle)
        Me.cardPurchases.Controls.Add(Me.picCardPurchases)
        Me.cardPurchases.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardPurchases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardPurchases.Location = New System.Drawing.Point(960, 7)
        Me.cardPurchases.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.cardPurchases.Name = "cardPurchases"
        Me.cardPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardPurchases.Size = New System.Drawing.Size(223, 101)
        Me.cardPurchases.TabIndex = 1
        '
        'lblCardPurchasesSub
        '
        Me.lblCardPurchasesSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardPurchasesSub.AutoSize = True
        Me.lblCardPurchasesSub.BackColor = System.Drawing.Color.Transparent
        Me.lblCardPurchasesSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCardPurchasesSub.ForeColor = System.Drawing.Color.Gray
        Me.lblCardPurchasesSub.Location = New System.Drawing.Point(7, 75)
        Me.lblCardPurchasesSub.Name = "lblCardPurchasesSub"
        Me.lblCardPurchasesSub.Size = New System.Drawing.Size(45, 15)
        Me.lblCardPurchasesSub.TabIndex = 3
        Me.lblCardPurchasesSub.Text = "0 فاتورة"
        '
        'lblCardPurchasesVal
        '
        Me.lblCardPurchasesVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardPurchasesVal.BackColor = System.Drawing.Color.Transparent
        Me.lblCardPurchasesVal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardPurchasesVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.lblCardPurchasesVal.Location = New System.Drawing.Point(5, 38)
        Me.lblCardPurchasesVal.Name = "lblCardPurchasesVal"
        Me.lblCardPurchasesVal.Size = New System.Drawing.Size(210, 26)
        Me.lblCardPurchasesVal.TabIndex = 2
        Me.lblCardPurchasesVal.Text = "0.00 ر.س"
        Me.lblCardPurchasesVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCardPurchasesTitle
        '
        Me.lblCardPurchasesTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardPurchasesTitle.AutoSize = True
        Me.lblCardPurchasesTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblCardPurchasesTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardPurchasesTitle.Location = New System.Drawing.Point(9, 8)
        Me.lblCardPurchasesTitle.Name = "lblCardPurchasesTitle"
        Me.lblCardPurchasesTitle.Size = New System.Drawing.Size(96, 19)
        Me.lblCardPurchasesTitle.TabIndex = 1
        Me.lblCardPurchasesTitle.Text = "مشتريات اليوم"
        '
        'picCardPurchases
        '
        Me.picCardPurchases.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCardPurchases.BackColor = System.Drawing.Color.Transparent
        Me.picCardPurchases.Image = Global.WindowsApp1.My.Resources.Resources.purchaser
        Me.picCardPurchases.ImageRotate = 0!
        Me.picCardPurchases.Location = New System.Drawing.Point(175, 10)
        Me.picCardPurchases.Name = "picCardPurchases"
        Me.picCardPurchases.Size = New System.Drawing.Size(38, 38)
        Me.picCardPurchases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardPurchases.TabIndex = 0
        Me.picCardPurchases.TabStop = False
        '
        'cardProfit
        '
        Me.cardProfit.BorderRadius = 12
        Me.cardProfit.Controls.Add(Me.lblCardProfitSub)
        Me.cardProfit.Controls.Add(Me.lblCardProfitVal)
        Me.cardProfit.Controls.Add(Me.lblCardProfitTitle)
        Me.cardProfit.Controls.Add(Me.picCardProfit)
        Me.cardProfit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardProfit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardProfit.Location = New System.Drawing.Point(725, 7)
        Me.cardProfit.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.cardProfit.Name = "cardProfit"
        Me.cardProfit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardProfit.Size = New System.Drawing.Size(223, 101)
        Me.cardProfit.TabIndex = 2
        '
        'lblCardProfitSub
        '
        Me.lblCardProfitSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardProfitSub.AutoSize = True
        Me.lblCardProfitSub.BackColor = System.Drawing.Color.Transparent
        Me.lblCardProfitSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCardProfitSub.ForeColor = System.Drawing.Color.Gray
        Me.lblCardProfitSub.Location = New System.Drawing.Point(7, 75)
        Me.lblCardProfitSub.Name = "lblCardProfitSub"
        Me.lblCardProfitSub.Size = New System.Drawing.Size(110, 15)
        Me.lblCardProfitSub.TabIndex = 3
        Me.lblCardProfitSub.Text = "(مبيعات - مصروفات)"
        '
        'lblCardProfitVal
        '
        Me.lblCardProfitVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardProfitVal.BackColor = System.Drawing.Color.Transparent
        Me.lblCardProfitVal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardProfitVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblCardProfitVal.Location = New System.Drawing.Point(5, 38)
        Me.lblCardProfitVal.Name = "lblCardProfitVal"
        Me.lblCardProfitVal.Size = New System.Drawing.Size(210, 26)
        Me.lblCardProfitVal.TabIndex = 2
        Me.lblCardProfitVal.Text = "0.00 ر.س"
        Me.lblCardProfitVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCardProfitTitle
        '
        Me.lblCardProfitTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardProfitTitle.AutoSize = True
        Me.lblCardProfitTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblCardProfitTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardProfitTitle.Location = New System.Drawing.Point(9, 8)
        Me.lblCardProfitTitle.Name = "lblCardProfitTitle"
        Me.lblCardProfitTitle.Size = New System.Drawing.Size(123, 19)
        Me.lblCardProfitTitle.TabIndex = 1
        Me.lblCardProfitTitle.Text = "صافي النقدية اليوم"
        '
        'picCardProfit
        '
        Me.picCardProfit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCardProfit.BackColor = System.Drawing.Color.Transparent
        Me.picCardProfit.Image = Global.WindowsApp1.My.Resources.Resources.financial
        Me.picCardProfit.ImageRotate = 0!
        Me.picCardProfit.Location = New System.Drawing.Point(175, 10)
        Me.picCardProfit.Name = "picCardProfit"
        Me.picCardProfit.Size = New System.Drawing.Size(38, 38)
        Me.picCardProfit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardProfit.TabIndex = 0
        Me.picCardProfit.TabStop = False
        '
        'cardProducts
        '
        Me.cardProducts.BorderRadius = 12
        Me.cardProducts.Controls.Add(Me.lblCardProductsSub)
        Me.cardProducts.Controls.Add(Me.lblCardProductsVal)
        Me.cardProducts.Controls.Add(Me.lblCardProductsTitle)
        Me.cardProducts.Controls.Add(Me.picCardProducts)
        Me.cardProducts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardProducts.Location = New System.Drawing.Point(490, 7)
        Me.cardProducts.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.cardProducts.Name = "cardProducts"
        Me.cardProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardProducts.Size = New System.Drawing.Size(223, 101)
        Me.cardProducts.TabIndex = 3
        '
        'lblCardProductsSub
        '
        Me.lblCardProductsSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardProductsSub.AutoSize = True
        Me.lblCardProductsSub.BackColor = System.Drawing.Color.Transparent
        Me.lblCardProductsSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCardProductsSub.ForeColor = System.Drawing.Color.Gray
        Me.lblCardProductsSub.Location = New System.Drawing.Point(7, 75)
        Me.lblCardProductsSub.Name = "lblCardProductsSub"
        Me.lblCardProductsSub.Size = New System.Drawing.Size(70, 15)
        Me.lblCardProductsSub.TabIndex = 3
        Me.lblCardProductsSub.Text = "صنف مسجل"
        '
        'lblCardProductsVal
        '
        Me.lblCardProductsVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardProductsVal.BackColor = System.Drawing.Color.Transparent
        Me.lblCardProductsVal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardProductsVal.Location = New System.Drawing.Point(5, 38)
        Me.lblCardProductsVal.Name = "lblCardProductsVal"
        Me.lblCardProductsVal.Size = New System.Drawing.Size(210, 26)
        Me.lblCardProductsVal.TabIndex = 2
        Me.lblCardProductsVal.Text = "0"
        Me.lblCardProductsVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCardProductsTitle
        '
        Me.lblCardProductsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardProductsTitle.AutoSize = True
        Me.lblCardProductsTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblCardProductsTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardProductsTitle.Location = New System.Drawing.Point(9, 8)
        Me.lblCardProductsTitle.Name = "lblCardProductsTitle"
        Me.lblCardProductsTitle.Size = New System.Drawing.Size(104, 19)
        Me.lblCardProductsTitle.TabIndex = 1
        Me.lblCardProductsTitle.Text = "إجمالي الأصناف"
        '
        'picCardProducts
        '
        Me.picCardProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCardProducts.BackColor = System.Drawing.Color.Transparent
        Me.picCardProducts.Image = Global.WindowsApp1.My.Resources.Resources.product
        Me.picCardProducts.ImageRotate = 0!
        Me.picCardProducts.Location = New System.Drawing.Point(175, 10)
        Me.picCardProducts.Name = "picCardProducts"
        Me.picCardProducts.Size = New System.Drawing.Size(38, 38)
        Me.picCardProducts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardProducts.TabIndex = 0
        Me.picCardProducts.TabStop = False
        '
        'cardCustomers
        '
        Me.cardCustomers.BorderRadius = 12
        Me.cardCustomers.Controls.Add(Me.lblCardCustomersSub)
        Me.cardCustomers.Controls.Add(Me.lblCardCustomersVal)
        Me.cardCustomers.Controls.Add(Me.lblCardCustomersTitle)
        Me.cardCustomers.Controls.Add(Me.picCardCustomers)
        Me.cardCustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardCustomers.Location = New System.Drawing.Point(255, 7)
        Me.cardCustomers.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.cardCustomers.Name = "cardCustomers"
        Me.cardCustomers.Size = New System.Drawing.Size(223, 101)
        Me.cardCustomers.TabIndex = 4
        '
        'lblCardCustomersSub
        '
        Me.lblCardCustomersSub.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardCustomersSub.AutoSize = True
        Me.lblCardCustomersSub.BackColor = System.Drawing.Color.Transparent
        Me.lblCardCustomersSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCardCustomersSub.ForeColor = System.Drawing.Color.Gray
        Me.lblCardCustomersSub.Location = New System.Drawing.Point(8, 73)
        Me.lblCardCustomersSub.Name = "lblCardCustomersSub"
        Me.lblCardCustomersSub.Size = New System.Drawing.Size(68, 15)
        Me.lblCardCustomersSub.TabIndex = 3
        Me.lblCardCustomersSub.Text = "عميل مسجل"
        '
        'lblCardCustomersVal
        '
        Me.lblCardCustomersVal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardCustomersVal.BackColor = System.Drawing.Color.Transparent
        Me.lblCardCustomersVal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardCustomersVal.Location = New System.Drawing.Point(6, 44)
        Me.lblCardCustomersVal.Name = "lblCardCustomersVal"
        Me.lblCardCustomersVal.Size = New System.Drawing.Size(209, 26)
        Me.lblCardCustomersVal.TabIndex = 2
        Me.lblCardCustomersVal.Text = "0"
        '
        'lblCardCustomersTitle
        '
        Me.lblCardCustomersTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardCustomersTitle.AutoSize = True
        Me.lblCardCustomersTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblCardCustomersTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardCustomersTitle.Location = New System.Drawing.Point(10, 10)
        Me.lblCardCustomersTitle.Name = "lblCardCustomersTitle"
        Me.lblCardCustomersTitle.Size = New System.Drawing.Size(94, 19)
        Me.lblCardCustomersTitle.TabIndex = 1
        Me.lblCardCustomersTitle.Text = "إجمالي العملاء"
        '
        'picCardCustomers
        '
        Me.picCardCustomers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCardCustomers.BackColor = System.Drawing.Color.Transparent
        Me.picCardCustomers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.picCardCustomers.ImageRotate = 0!
        Me.picCardCustomers.Location = New System.Drawing.Point(175, 10)
        Me.picCardCustomers.Name = "picCardCustomers"
        Me.picCardCustomers.Size = New System.Drawing.Size(38, 38)
        Me.picCardCustomers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardCustomers.TabIndex = 0
        Me.picCardCustomers.TabStop = False
        '
        'cardSuppliers
        '
        Me.cardSuppliers.BorderRadius = 12
        Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersSub)
        Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersVal)
        Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersTitle)
        Me.cardSuppliers.Controls.Add(Me.picCardSuppliers)
        Me.cardSuppliers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardSuppliers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardSuppliers.Location = New System.Drawing.Point(16, 7)
        Me.cardSuppliers.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.cardSuppliers.Name = "cardSuppliers"
        Me.cardSuppliers.Size = New System.Drawing.Size(227, 101)
        Me.cardSuppliers.TabIndex = 5
        '
        'lblCardSuppliersSub
        '
        Me.lblCardSuppliersSub.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardSuppliersSub.AutoSize = True
        Me.lblCardSuppliersSub.BackColor = System.Drawing.Color.Transparent
        Me.lblCardSuppliersSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCardSuppliersSub.ForeColor = System.Drawing.Color.Gray
        Me.lblCardSuppliersSub.Location = New System.Drawing.Point(8, 73)
        Me.lblCardSuppliersSub.Name = "lblCardSuppliersSub"
        Me.lblCardSuppliersSub.Size = New System.Drawing.Size(65, 15)
        Me.lblCardSuppliersSub.TabIndex = 3
        Me.lblCardSuppliersSub.Text = "مورد مسجل"
        '
        'lblCardSuppliersVal
        '
        Me.lblCardSuppliersVal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardSuppliersVal.BackColor = System.Drawing.Color.Transparent
        Me.lblCardSuppliersVal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardSuppliersVal.Location = New System.Drawing.Point(6, 44)
        Me.lblCardSuppliersVal.Name = "lblCardSuppliersVal"
        Me.lblCardSuppliersVal.Size = New System.Drawing.Size(213, 26)
        Me.lblCardSuppliersVal.TabIndex = 2
        Me.lblCardSuppliersVal.Text = "0"
        '
        'lblCardSuppliersTitle
        '
        Me.lblCardSuppliersTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardSuppliersTitle.AutoSize = True
        Me.lblCardSuppliersTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblCardSuppliersTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardSuppliersTitle.Location = New System.Drawing.Point(10, 10)
        Me.lblCardSuppliersTitle.Name = "lblCardSuppliersTitle"
        Me.lblCardSuppliersTitle.Size = New System.Drawing.Size(104, 19)
        Me.lblCardSuppliersTitle.TabIndex = 1
        Me.lblCardSuppliersTitle.Text = "إجمالي الموردين"
        '
        'picCardSuppliers
        '
        Me.picCardSuppliers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCardSuppliers.BackColor = System.Drawing.Color.Transparent
        Me.picCardSuppliers.Image = Global.WindowsApp1.My.Resources.Resources.team
        Me.picCardSuppliers.ImageRotate = 0!
        Me.picCardSuppliers.Location = New System.Drawing.Point(179, 10)
        Me.picCardSuppliers.Name = "picCardSuppliers"
        Me.picCardSuppliers.Size = New System.Drawing.Size(38, 38)
        Me.picCardSuppliers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardSuppliers.TabIndex = 0
        Me.picCardSuppliers.TabStop = False
        '
        'pnlWelcome
        '
        Me.pnlWelcome.Controls.Add(Me.btnRefreshDashboard)
        Me.pnlWelcome.Controls.Add(Me.lblShiftDuration)
        Me.pnlWelcome.Controls.Add(Me.lblWelcomeSub)
        Me.pnlWelcome.Controls.Add(Me.lblWelcomeGreeting)
        Me.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlWelcome.Location = New System.Drawing.Point(0, 0)
        Me.pnlWelcome.Name = "pnlWelcome"
        Me.pnlWelcome.Padding = New System.Windows.Forms.Padding(15, 8, 15, 6)
        Me.pnlWelcome.Size = New System.Drawing.Size(1434, 60)
        Me.pnlWelcome.TabIndex = 0
        '
        'btnRefreshDashboard
        '
        Me.btnRefreshDashboard.BorderRadius = 8
        Me.btnRefreshDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefreshDashboard.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshDashboard.ForeColor = System.Drawing.Color.White
        Me.btnRefreshDashboard.Location = New System.Drawing.Point(18, 12)
        Me.btnRefreshDashboard.Name = "btnRefreshDashboard"
        Me.btnRefreshDashboard.Size = New System.Drawing.Size(140, 36)
        Me.btnRefreshDashboard.TabIndex = 2
        Me.btnRefreshDashboard.Text = "🔄 تحديث البيانات"
        '
        'lblShiftDuration
        '
        Me.lblShiftDuration.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftDuration.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblShiftDuration.Location = New System.Drawing.Point(1238, 21)
        Me.lblShiftDuration.Name = "lblShiftDuration"
        Me.lblShiftDuration.Size = New System.Drawing.Size(161, 19)
        Me.lblShiftDuration.TabIndex = 3
        Me.lblShiftDuration.Text = "⏱️ مدة الوردية: 00:00:00"
        '
        'lblWelcomeSub
        '
        Me.lblWelcomeSub.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcomeSub.ForeColor = System.Drawing.Color.Gray
        Me.lblWelcomeSub.Location = New System.Drawing.Point(967, 21)
        Me.lblWelcomeSub.Name = "lblWelcomeSub"
        Me.lblWelcomeSub.Size = New System.Drawing.Size(255, 17)
        Me.lblWelcomeSub.TabIndex = 1
        Me.lblWelcomeSub.Text = "لوحة التحكم السريعة ومؤشرات الأداء التشغيلية"
        '
        'lblWelcomeGreeting
        '
        Me.lblWelcomeGreeting.AutoSize = True
        Me.lblWelcomeGreeting.Font = New System.Drawing.Font("Segoe UI", 13.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcomeGreeting.Location = New System.Drawing.Point(15, 6)
        Me.lblWelcomeGreeting.Name = "lblWelcomeGreeting"
        Me.lblWelcomeGreeting.Size = New System.Drawing.Size(95, 25)
        Me.lblWelcomeGreeting.TabIndex = 0
        Me.lblWelcomeGreeting.Text = "أهلاً بك 👋"
        '
        'tmrClock
        '
        Me.tmrClock.Interval = 1000
        '
        'tmrDashboardRefresh
        '
        Me.tmrDashboardRefresh.Interval = 30000
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCategories, Me.ToolStripSeparator1, Me.btnProducts, Me.ToolStripSeparator9, Me.btnfrmProductSizes, Me.ToolStripSeparator7, Me.btnfrmProductAddons, Me.ToolStripSeparator5, Me.btnfrmKitchenComments, Me.ToolStripSeparatorKitchenComments, Me.btnfrmDeliveryAreas, Me.ToolStripSeparator4, Me.btnfrmDeliveryDrivers, Me.ToolStripSeparator3, Me.btnfrmShifts, Me.ToolStripSeparator36, Me.btnShiftReports, Me.ToolStripSeparatorShiftReports, Me.btnfrmBranches, Me.ToolStripSeparator37})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1420, 133)
        Me.ToolStrip1.TabIndex = 42
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnCategories
        '
        Me.btnCategories.AutoSize = False
        Me.btnCategories.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategories.ForeColor = System.Drawing.Color.Black
        Me.btnCategories.Image = Global.WindowsApp1.My.Resources.Resources.application
        Me.btnCategories.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCategories.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCategories.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCategories.Name = "btnCategories"
        Me.btnCategories.Size = New System.Drawing.Size(90, 100)
        Me.btnCategories.Text = "الفئات"
        Me.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(10, 113)
        '
        'btnProducts
        '
        Me.btnProducts.AutoSize = False
        Me.btnProducts.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProducts.ForeColor = System.Drawing.Color.Black
        Me.btnProducts.Image = Global.WindowsApp1.My.Resources.Resources.order
        Me.btnProducts.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProducts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnProducts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Size = New System.Drawing.Size(90, 100)
        Me.btnProducts.Text = "الاصناف"
        Me.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.AutoSize = False
        Me.ToolStripSeparator9.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmProductSizes
        '
        Me.btnfrmProductSizes.AutoSize = False
        Me.btnfrmProductSizes.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmProductSizes.ForeColor = System.Drawing.Color.Black
        Me.btnfrmProductSizes.Image = Global.WindowsApp1.My.Resources.Resources.product
        Me.btnfrmProductSizes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmProductSizes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmProductSizes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmProductSizes.Name = "btnfrmProductSizes"
        Me.btnfrmProductSizes.Size = New System.Drawing.Size(120, 100)
        Me.btnfrmProductSizes.Text = "احجام الاصناف"
        Me.btnfrmProductSizes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.AutoSize = False
        Me.ToolStripSeparator7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmProductAddons
        '
        Me.btnfrmProductAddons.AutoSize = False
        Me.btnfrmProductAddons.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmProductAddons.ForeColor = System.Drawing.Color.Black
        Me.btnfrmProductAddons.Image = Global.WindowsApp1.My.Resources.Resources.diet
        Me.btnfrmProductAddons.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmProductAddons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmProductAddons.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmProductAddons.Name = "btnfrmProductAddons"
        Me.btnfrmProductAddons.Size = New System.Drawing.Size(135, 100)
        Me.btnfrmProductAddons.Text = "اضافات الاصناف"
        Me.btnfrmProductAddons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.AutoSize = False
        Me.ToolStripSeparator5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmKitchenComments
        '
        Me.btnfrmKitchenComments.AutoSize = False
        Me.btnfrmKitchenComments.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmKitchenComments.ForeColor = System.Drawing.Color.Black
        Me.btnfrmKitchenComments.Image = Global.WindowsApp1.My.Resources.Resources.bubble_chat
        Me.btnfrmKitchenComments.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmKitchenComments.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmKitchenComments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmKitchenComments.Name = "btnfrmKitchenComments"
        Me.btnfrmKitchenComments.Size = New System.Drawing.Size(135, 100)
        Me.btnfrmKitchenComments.Text = "تعليقات المطبخ"
        Me.btnfrmKitchenComments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparatorKitchenComments
        '
        Me.ToolStripSeparatorKitchenComments.AutoSize = False
        Me.ToolStripSeparatorKitchenComments.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparatorKitchenComments.Name = "ToolStripSeparatorKitchenComments"
        Me.ToolStripSeparatorKitchenComments.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmDeliveryAreas
        '
        Me.btnfrmDeliveryAreas.AutoSize = False
        Me.btnfrmDeliveryAreas.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmDeliveryAreas.ForeColor = System.Drawing.Color.Black
        Me.btnfrmDeliveryAreas.Image = Global.WindowsApp1.My.Resources.Resources.location
        Me.btnfrmDeliveryAreas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmDeliveryAreas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmDeliveryAreas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmDeliveryAreas.Name = "btnfrmDeliveryAreas"
        Me.btnfrmDeliveryAreas.Size = New System.Drawing.Size(130, 100)
        Me.btnfrmDeliveryAreas.Text = "مناطق التوصيل"
        Me.btnfrmDeliveryAreas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmDeliveryDrivers
        '
        Me.btnfrmDeliveryDrivers.AutoSize = False
        Me.btnfrmDeliveryDrivers.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmDeliveryDrivers.ForeColor = System.Drawing.Color.Black
        Me.btnfrmDeliveryDrivers.Image = Global.WindowsApp1.My.Resources.Resources.delivery_bike__1_
        Me.btnfrmDeliveryDrivers.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmDeliveryDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmDeliveryDrivers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmDeliveryDrivers.Name = "btnfrmDeliveryDrivers"
        Me.btnfrmDeliveryDrivers.Size = New System.Drawing.Size(150, 100)
        Me.btnfrmDeliveryDrivers.Text = "طيارين الديليفري"
        Me.btnfrmDeliveryDrivers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmShifts
        '
        Me.btnfrmShifts.AutoSize = False
        Me.btnfrmShifts.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmShifts.ForeColor = System.Drawing.Color.Black
        Me.btnfrmShifts.Image = Global.WindowsApp1.My.Resources.Resources.scheduling
        Me.btnfrmShifts.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmShifts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmShifts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmShifts.Name = "btnfrmShifts"
        Me.btnfrmShifts.Size = New System.Drawing.Size(150, 100)
        Me.btnfrmShifts.Text = "الورديات"
        Me.btnfrmShifts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.AutoSize = False
        Me.ToolStripSeparator36.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        Me.ToolStripSeparator36.Size = New System.Drawing.Size(10, 113)
        '
        'btnShiftReports
        '
        Me.btnShiftReports.AutoSize = False
        Me.btnShiftReports.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShiftReports.ForeColor = System.Drawing.Color.Black
        Me.btnShiftReports.Image = Global.WindowsApp1.My.Resources.Resources.report
        Me.btnShiftReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnShiftReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnShiftReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShiftReports.Name = "btnShiftReports"
        Me.btnShiftReports.Size = New System.Drawing.Size(150, 100)
        Me.btnShiftReports.Text = "تقارير الورديات"
        Me.btnShiftReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparatorShiftReports
        '
        Me.ToolStripSeparatorShiftReports.AutoSize = False
        Me.ToolStripSeparatorShiftReports.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparatorShiftReports.Name = "ToolStripSeparatorShiftReports"
        Me.ToolStripSeparatorShiftReports.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmBranches
        '
        Me.btnfrmBranches.AutoSize = False
        Me.btnfrmBranches.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmBranches.ForeColor = System.Drawing.Color.Black
        Me.btnfrmBranches.Image = Global.WindowsApp1.My.Resources.Resources.branch
        Me.btnfrmBranches.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmBranches.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmBranches.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmBranches.Name = "btnfrmBranches"
        Me.btnfrmBranches.Size = New System.Drawing.Size(150, 100)
        Me.btnfrmBranches.Text = "الفروع"
        Me.btnfrmBranches.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator37
        '
        Me.ToolStripSeparator37.AutoSize = False
        Me.ToolStripSeparator37.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator37.Name = "ToolStripSeparator37"
        Me.ToolStripSeparator37.Size = New System.Drawing.Size(10, 113)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabsystem)
        Me.TabControl1.Controls.Add(Me.tabCustomers)
        Me.TabControl1.Controls.Add(Me.tabSuppliers)
        Me.TabControl1.Controls.Add(Me.tabSales)
        Me.TabControl1.Controls.Add(Me.tabPurchases)
        Me.TabControl1.Controls.Add(Me.tabStorage)
        Me.TabControl1.Controls.Add(Me.tabExpenses)
        Me.TabControl1.Controls.Add(Me.tabemployees)
        Me.TabControl1.Controls.Add(Me.tabUsers)
        Me.TabControl1.Controls.Add(Me.tabbackup)
        Me.TabControl1.Controls.Add(Me.tabSettings)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.ItemSize = New System.Drawing.Size(125, 100)
        Me.TabControl1.Location = New System.Drawing.Point(0, 70)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1434, 247)
        Me.TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty
        Me.TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TabControl1.TabButtonHoverState.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!)
        Me.TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White
        Me.TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty
        Me.TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.TabControl1.TabButtonIdleState.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!)
        Me.TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.White
        Me.TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty
        Me.TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TabControl1.TabButtonSelectedState.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!)
        Me.TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White
        Me.TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.Red
        Me.TabControl1.TabButtonSize = New System.Drawing.Size(125, 100)
        Me.TabControl1.TabIndex = 43
        Me.TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop
        '
        'tabsystem
        '
        Me.tabsystem.Controls.Add(Me.ToolStrip1)
        Me.tabsystem.Location = New System.Drawing.Point(4, 104)
        Me.tabsystem.Name = "tabsystem"
        Me.tabsystem.Padding = New System.Windows.Forms.Padding(3)
        Me.tabsystem.Size = New System.Drawing.Size(1426, 139)
        Me.tabsystem.TabIndex = 0
        Me.tabsystem.Text = "بيانات النظام"
        Me.tabsystem.UseVisualStyleBackColor = True
        '
        'tabCustomers
        '
        Me.tabCustomers.Controls.Add(Me.ToolStrip2)
        Me.tabCustomers.Location = New System.Drawing.Point(4, 104)
        Me.tabCustomers.Name = "tabCustomers"
        Me.tabCustomers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustomers.Size = New System.Drawing.Size(1426, 139)
        Me.tabCustomers.TabIndex = 1
        Me.tabCustomers.Text = "العملاء"
        Me.tabCustomers.UseVisualStyleBackColor = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFrmCustomers, Me.ToolStripSeparator2, Me.btnFrmCustomerStatement, Me.ToolStripSeparator18, Me.btnCustomerBalanceDownload, Me.ToolStripSeparator17, Me.ToolStripButton11})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1420, 133)
        Me.ToolStrip2.TabIndex = 43
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnFrmCustomers
        '
        Me.btnFrmCustomers.AutoSize = False
        Me.btnFrmCustomers.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFrmCustomers.ForeColor = System.Drawing.Color.Black
        Me.btnFrmCustomers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.btnFrmCustomers.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrmCustomers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFrmCustomers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFrmCustomers.Name = "btnFrmCustomers"
        Me.btnFrmCustomers.Size = New System.Drawing.Size(110, 100)
        Me.btnFrmCustomers.Text = "ادارة العملاء"
        Me.btnFrmCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(10, 113)
        '
        'btnFrmCustomerStatement
        '
        Me.btnFrmCustomerStatement.AutoSize = False
        Me.btnFrmCustomerStatement.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFrmCustomerStatement.ForeColor = System.Drawing.Color.Black
        Me.btnFrmCustomerStatement.Image = Global.WindowsApp1.My.Resources.Resources.active_user
        Me.btnFrmCustomerStatement.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrmCustomerStatement.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFrmCustomerStatement.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFrmCustomerStatement.Name = "btnFrmCustomerStatement"
        Me.btnFrmCustomerStatement.Size = New System.Drawing.Size(160, 100)
        Me.btnFrmCustomerStatement.Text = "كشف حساب عميل"
        Me.btnFrmCustomerStatement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.AutoSize = False
        Me.ToolStripSeparator18.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(10, 113)
        '
        'btnCustomerBalanceDownload
        '
        Me.btnCustomerBalanceDownload.AutoSize = False
        Me.btnCustomerBalanceDownload.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomerBalanceDownload.ForeColor = System.Drawing.Color.Black
        Me.btnCustomerBalanceDownload.Image = Global.WindowsApp1.My.Resources.Resources.active_user
        Me.btnCustomerBalanceDownload.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCustomerBalanceDownload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCustomerBalanceDownload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCustomerBalanceDownload.Name = "btnCustomerBalanceDownload"
        Me.btnCustomerBalanceDownload.Size = New System.Drawing.Size(160, 100)
        Me.btnCustomerBalanceDownload.Text = "سداد رصيد عميل"
        Me.btnCustomerBalanceDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.AutoSize = False
        Me.ToolStripButton11.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton11.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton11.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.ToolStripButton11.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolStripButton11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(110, 100)
        Me.ToolStripButton11.Text = "تقارير العملاء"
        Me.ToolStripButton11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.AutoSize = False
        Me.ToolStripSeparator17.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(10, 113)
        '
        'tabSuppliers
        '
        Me.tabSuppliers.Controls.Add(Me.ToolStrip3)
        Me.tabSuppliers.Location = New System.Drawing.Point(4, 104)
        Me.tabSuppliers.Name = "tabSuppliers"
        Me.tabSuppliers.Size = New System.Drawing.Size(1426, 139)
        Me.tabSuppliers.TabIndex = 2
        Me.tabSuppliers.Text = "الموردين"
        Me.tabSuppliers.UseVisualStyleBackColor = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AutoSize = False
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripSeparator11, Me.ToolStripButton4, Me.ToolStripSeparator12, Me.ToolStripButton5, Me.ToolStripSeparator13})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStrip3.TabIndex = 44
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.AutoSize = False
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton3.Image = Global.WindowsApp1.My.Resources.Resources.team
        Me.ToolStripButton3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(130, 100)
        Me.ToolStripButton3.Text = "ادارة الموردين"
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.AutoSize = False
        Me.ToolStripSeparator11.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(10, 113)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.AutoSize = False
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton4.Image = Global.WindowsApp1.My.Resources.Resources.active_user
        Me.ToolStripButton4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(160, 100)
        Me.ToolStripButton4.Text = "كشف حساب مورد"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.AutoSize = False
        Me.ToolStripSeparator12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(10, 113)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.AutoSize = False
        Me.ToolStripButton5.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton5.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton5.Image = Global.WindowsApp1.My.Resources.Resources.purchaser
        Me.ToolStripButton5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(110, 100)
        Me.ToolStripButton5.Text = "تقارير الموردين"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.AutoSize = False
        Me.ToolStripSeparator13.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(10, 113)
        '
        'tabSales
        '
        Me.tabSales.Controls.Add(Me.ToolStrip4)
        Me.tabSales.Location = New System.Drawing.Point(4, 104)
        Me.tabSales.Name = "tabSales"
        Me.tabSales.Size = New System.Drawing.Size(1426, 139)
        Me.tabSales.TabIndex = 3
        Me.tabSales.Text = "المبيعات"
        Me.tabSales.UseVisualStyleBackColor = True
        '
        'ToolStrip4
        '
        Me.ToolStrip4.AutoSize = False
        Me.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnfrmPOS, Me.ToolStripSeparator14, Me.btnSalesReturns, Me.ToolStripSeparator50, Me.btnFrmSalesReport, Me.ToolStripSeparator15, Me.btnFrmDriverReport, Me.ToolStripSeparator16, Me.btnKds, Me.ToolStripSeparator51, Me.btnWaste, Me.ToolStripSeparator52, Me.btnRes, Me.ToolStripSeparator53})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStrip4.TabIndex = 44
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'btnfrmPOS
        '
        Me.btnfrmPOS.AutoSize = False
        Me.btnfrmPOS.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmPOS.ForeColor = System.Drawing.Color.Black
        Me.btnfrmPOS.Image = Global.WindowsApp1.My.Resources.Resources.shopping_cart2
        Me.btnfrmPOS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmPOS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmPOS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmPOS.Name = "btnfrmPOS"
        Me.btnfrmPOS.Size = New System.Drawing.Size(110, 100)
        Me.btnfrmPOS.Text = "البيع"
        Me.btnfrmPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.AutoSize = False
        Me.ToolStripSeparator14.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(10, 113)
        '
        'btnFrmSalesReport
        '
        Me.btnFrmSalesReport.AutoSize = False
        Me.btnFrmSalesReport.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFrmSalesReport.ForeColor = System.Drawing.Color.Black
        Me.btnFrmSalesReport.Image = Global.WindowsApp1.My.Resources.Resources.market_analysis
        Me.btnFrmSalesReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrmSalesReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFrmSalesReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFrmSalesReport.Name = "btnFrmSalesReport"
        Me.btnFrmSalesReport.Size = New System.Drawing.Size(120, 100)
        Me.btnFrmSalesReport.Text = "تقارير البيع"
        Me.btnFrmSalesReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.AutoSize = False
        Me.ToolStripSeparator15.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(10, 113)
        '
        'btnFrmDriverReport
        '
        Me.btnFrmDriverReport.AutoSize = False
        Me.btnFrmDriverReport.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFrmDriverReport.ForeColor = System.Drawing.Color.Black
        Me.btnFrmDriverReport.Image = Global.WindowsApp1.My.Resources.Resources.report
        Me.btnFrmDriverReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrmDriverReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFrmDriverReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFrmDriverReport.Name = "btnFrmDriverReport"
        Me.btnFrmDriverReport.Size = New System.Drawing.Size(200, 100)
        Me.btnFrmDriverReport.Text = "تقارير طيارين الديلفيري"
        Me.btnFrmDriverReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.AutoSize = False
        Me.ToolStripSeparator16.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(10, 113)
        '
        'btnKds
        '
        Me.btnKds.AutoSize = False
        Me.btnKds.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKds.ForeColor = System.Drawing.Color.Black
        Me.btnKds.Image = Global.WindowsApp1.My.Resources.Resources.dinning_hall
        Me.btnKds.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnKds.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnKds.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnKds.Name = "btnKds"
        Me.btnKds.Size = New System.Drawing.Size(160, 100)
        Me.btnKds.Text = "شاشة المطبخ (KDS)"
        Me.btnKds.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator51
        '
        Me.ToolStripSeparator51.AutoSize = False
        Me.ToolStripSeparator51.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator51.Name = "ToolStripSeparator51"
        Me.ToolStripSeparator51.Size = New System.Drawing.Size(10, 113)
        '
        'btnWaste
        '
        Me.btnWaste.AutoSize = False
        Me.btnWaste.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWaste.ForeColor = System.Drawing.Color.Black
        Me.btnWaste.Image = Global.WindowsApp1.My.Resources.Resources.dinning_hall
        Me.btnWaste.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnWaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnWaste.Name = "btnWaste"
        Me.btnWaste.Size = New System.Drawing.Size(150, 100)
        Me.btnWaste.Text = "هالك وتالف المطبخ"
        Me.btnWaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator52
        '
        Me.ToolStripSeparator52.AutoSize = False
        Me.ToolStripSeparator52.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator52.Name = "ToolStripSeparator52"
        Me.ToolStripSeparator52.Size = New System.Drawing.Size(10, 113)
        '
        'btnRes
        '
        Me.btnRes.AutoSize = False
        Me.btnRes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRes.ForeColor = System.Drawing.Color.Black
        Me.btnRes.Image = Global.WindowsApp1.My.Resources.Resources.dining_room
        Me.btnRes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnRes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRes.Name = "btnRes"
        Me.btnRes.Size = New System.Drawing.Size(140, 100)
        Me.btnRes.Text = "حجوزات الصالة"
        Me.btnRes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator53
        '
        Me.ToolStripSeparator53.AutoSize = False
        Me.ToolStripSeparator53.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator53.Name = "ToolStripSeparator53"
        Me.ToolStripSeparator53.Size = New System.Drawing.Size(10, 113)
        '
        'tabPurchases
        '
        Me.tabPurchases.Controls.Add(Me.ToolStrip5)
        Me.tabPurchases.Location = New System.Drawing.Point(4, 104)
        Me.tabPurchases.Name = "tabPurchases"
        Me.tabPurchases.Size = New System.Drawing.Size(1426, 139)
        Me.tabPurchases.TabIndex = 4
        Me.tabPurchases.Text = "المشتريات"
        Me.tabPurchases.UseVisualStyleBackColor = True
        '
        'ToolStrip5
        '
        Me.ToolStrip5.AutoSize = False
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnfrmPurchases, Me.ToolStripSeparator19, Me.btnfrmPurchaseReports, Me.ToolStripSeparator20})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStrip5.TabIndex = 44
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'btnfrmPurchases
        '
        Me.btnfrmPurchases.AutoSize = False
        Me.btnfrmPurchases.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmPurchases.ForeColor = System.Drawing.Color.Black
        Me.btnfrmPurchases.Image = Global.WindowsApp1.My.Resources.Resources.shopping_cart__1_
        Me.btnfrmPurchases.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmPurchases.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmPurchases.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmPurchases.Name = "btnfrmPurchases"
        Me.btnfrmPurchases.Size = New System.Drawing.Size(200, 100)
        Me.btnfrmPurchases.Text = "فاتورة المشتريات"
        Me.btnfrmPurchases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.AutoSize = False
        Me.ToolStripSeparator19.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmPurchaseReports
        '
        Me.btnfrmPurchaseReports.AutoSize = False
        Me.btnfrmPurchaseReports.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmPurchaseReports.ForeColor = System.Drawing.Color.Black
        Me.btnfrmPurchaseReports.Image = Global.WindowsApp1.My.Resources.Resources.purchaser
        Me.btnfrmPurchaseReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmPurchaseReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmPurchaseReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmPurchaseReports.Name = "btnfrmPurchaseReports"
        Me.btnfrmPurchaseReports.Size = New System.Drawing.Size(200, 100)
        Me.btnfrmPurchaseReports.Text = "تقارير المشتريات"
        Me.btnfrmPurchaseReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.AutoSize = False
        Me.ToolStripSeparator20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(10, 113)
        '
        'tabStorage
        '
        Me.tabStorage.Controls.Add(Me.ToolStrip6)
        Me.tabStorage.Location = New System.Drawing.Point(4, 104)
        Me.tabStorage.Name = "tabStorage"
        Me.tabStorage.Size = New System.Drawing.Size(1426, 139)
        Me.tabStorage.TabIndex = 5
        Me.tabStorage.Text = "الخزن"
        Me.tabStorage.UseVisualStyleBackColor = True
        '
        'ToolStrip6
        '
        Me.ToolStrip6.AutoSize = False
        Me.ToolStrip6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnfrmTreasury, Me.ToolStripSeparator22, Me.btnFrmTreasuryTransfer, Me.ToolStripSeparator24, Me.btnFrmTreasuryTransactionsReport, Me.ToolStripSeparator33, Me.btnDeposit, Me.ToolStripSeparator43, Me.btnWithdraw, Me.ToolStripSeparator42})
        Me.ToolStrip6.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip6.Name = "ToolStrip6"
        Me.ToolStrip6.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStrip6.TabIndex = 44
        Me.ToolStrip6.Text = "ToolStrip6"
        '
        'btnfrmTreasury
        '
        Me.btnfrmTreasury.AutoSize = False
        Me.btnfrmTreasury.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmTreasury.ForeColor = System.Drawing.Color.Black
        Me.btnfrmTreasury.Image = Global.WindowsApp1.My.Resources.Resources.financial
        Me.btnfrmTreasury.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmTreasury.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmTreasury.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmTreasury.Name = "btnfrmTreasury"
        Me.btnfrmTreasury.Size = New System.Drawing.Size(110, 100)
        Me.btnfrmTreasury.Text = "ادارة الخزن"
        Me.btnfrmTreasury.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.AutoSize = False
        Me.ToolStripSeparator22.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(10, 113)
        '
        'btnFrmTreasuryTransfer
        '
        Me.btnFrmTreasuryTransfer.AutoSize = False
        Me.btnFrmTreasuryTransfer.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFrmTreasuryTransfer.ForeColor = System.Drawing.Color.Black
        Me.btnFrmTreasuryTransfer.Image = Global.WindowsApp1.My.Resources.Resources.exchange__1_
        Me.btnFrmTreasuryTransfer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrmTreasuryTransfer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFrmTreasuryTransfer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFrmTreasuryTransfer.Name = "btnFrmTreasuryTransfer"
        Me.btnFrmTreasuryTransfer.Size = New System.Drawing.Size(150, 100)
        Me.btnFrmTreasuryTransfer.Text = "تحويل بين الخزن"
        Me.btnFrmTreasuryTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.AutoSize = False
        Me.ToolStripSeparator24.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(10, 113)
        '
        'btnFrmTreasuryTransactionsReport
        '
        Me.btnFrmTreasuryTransactionsReport.AutoSize = False
        Me.btnFrmTreasuryTransactionsReport.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFrmTreasuryTransactionsReport.ForeColor = System.Drawing.Color.Black
        Me.btnFrmTreasuryTransactionsReport.Image = Global.WindowsApp1.My.Resources.Resources.web
        Me.btnFrmTreasuryTransactionsReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrmTreasuryTransactionsReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFrmTreasuryTransactionsReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFrmTreasuryTransactionsReport.Name = "btnFrmTreasuryTransactionsReport"
        Me.btnFrmTreasuryTransactionsReport.Size = New System.Drawing.Size(150, 100)
        Me.btnFrmTreasuryTransactionsReport.Text = "تقارير حركة الخزن"
        Me.btnFrmTreasuryTransactionsReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.AutoSize = False
        Me.ToolStripSeparator33.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(10, 113)
        '
        'btnDeposit
        '
        Me.btnDeposit.AutoSize = False
        Me.btnDeposit.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeposit.ForeColor = System.Drawing.Color.Black
        Me.btnDeposit.Image = Global.WindowsApp1.My.Resources.Resources.treasury
        Me.btnDeposit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDeposit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDeposit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeposit.Name = "btnDeposit"
        Me.btnDeposit.Size = New System.Drawing.Size(120, 100)
        Me.btnDeposit.Text = "ايداع"
        Me.btnDeposit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator43
        '
        Me.ToolStripSeparator43.AutoSize = False
        Me.ToolStripSeparator43.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator43.Name = "ToolStripSeparator43"
        Me.ToolStripSeparator43.Size = New System.Drawing.Size(10, 113)
        '
        'btnWithdraw
        '
        Me.btnWithdraw.AutoSize = False
        Me.btnWithdraw.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWithdraw.ForeColor = System.Drawing.Color.Black
        Me.btnWithdraw.Image = Global.WindowsApp1.My.Resources.Resources.treasury
        Me.btnWithdraw.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWithdraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnWithdraw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnWithdraw.Name = "btnWithdraw"
        Me.btnWithdraw.Size = New System.Drawing.Size(120, 100)
        Me.btnWithdraw.Text = "سحب"
        Me.btnWithdraw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator42
        '
        Me.ToolStripSeparator42.AutoSize = False
        Me.ToolStripSeparator42.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator42.Name = "ToolStripSeparator42"
        Me.ToolStripSeparator42.Size = New System.Drawing.Size(10, 113)
        '
        'tabExpenses
        '
        Me.tabExpenses.Controls.Add(Me.ToolStrip10)
        Me.tabExpenses.Location = New System.Drawing.Point(4, 104)
        Me.tabExpenses.Name = "tabExpenses"
        Me.tabExpenses.Size = New System.Drawing.Size(1426, 139)
        Me.tabExpenses.TabIndex = 6
        Me.tabExpenses.Text = "المصروفات"
        Me.tabExpenses.UseVisualStyleBackColor = True
        '
        'ToolStrip10
        '
        Me.ToolStrip10.AutoSize = False
        Me.ToolStrip10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip10.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnform_Expenses, Me.ToolStripSeparator40, Me.btnExpensesReportForm, Me.ToolStripSeparator41})
        Me.ToolStrip10.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip10.Name = "ToolStrip10"
        Me.ToolStrip10.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStrip10.TabIndex = 48
        Me.ToolStrip10.Text = "ToolStrip10"
        '
        'btnform_Expenses
        '
        Me.btnform_Expenses.AutoSize = False
        Me.btnform_Expenses.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnform_Expenses.ForeColor = System.Drawing.Color.Black
        Me.btnform_Expenses.Image = Global.WindowsApp1.My.Resources.Resources.backup
        Me.btnform_Expenses.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnform_Expenses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnform_Expenses.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnform_Expenses.Name = "btnform_Expenses"
        Me.btnform_Expenses.Size = New System.Drawing.Size(120, 100)
        Me.btnform_Expenses.Text = "المصروفات"
        Me.btnform_Expenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator40
        '
        Me.ToolStripSeparator40.AutoSize = False
        Me.ToolStripSeparator40.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator40.Name = "ToolStripSeparator40"
        Me.ToolStripSeparator40.Size = New System.Drawing.Size(10, 113)
        '
        'btnExpensesReportForm
        '
        Me.btnExpensesReportForm.AutoSize = False
        Me.btnExpensesReportForm.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpensesReportForm.ForeColor = System.Drawing.Color.Black
        Me.btnExpensesReportForm.Image = Global.WindowsApp1.My.Resources.Resources.color_palette
        Me.btnExpensesReportForm.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExpensesReportForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExpensesReportForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExpensesReportForm.Name = "btnExpensesReportForm"
        Me.btnExpensesReportForm.Size = New System.Drawing.Size(150, 100)
        Me.btnExpensesReportForm.Text = "تقارير المصروفات"
        Me.btnExpensesReportForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator41
        '
        Me.ToolStripSeparator41.AutoSize = False
        Me.ToolStripSeparator41.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator41.Name = "ToolStripSeparator41"
        Me.ToolStripSeparator41.Size = New System.Drawing.Size(10, 113)
        '
        'tabemployees
        '
        Me.tabemployees.Controls.Add(Me.ToolStrip7)
        Me.tabemployees.Location = New System.Drawing.Point(4, 104)
        Me.tabemployees.Name = "tabemployees"
        Me.tabemployees.Size = New System.Drawing.Size(1426, 139)
        Me.tabemployees.TabIndex = 7
        Me.tabemployees.Text = "الموظفين"
        Me.tabemployees.UseVisualStyleBackColor = True
        '
        'ToolStrip7
        '
        Me.ToolStrip7.AutoSize = False
        Me.ToolStrip7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnfrmEmployees, Me.ToolStripSeparator25, Me.btnfrmJobTitles, Me.ToolStripSeparator26, Me.btnfrmDepartments, Me.ToolStripSeparator27, Me.btnfrmSalarySystems, Me.ToolStripSeparator28, Me.btnfrmSalaryPayment, Me.ToolStripSeparator8})
        Me.ToolStrip7.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip7.Name = "ToolStrip7"
        Me.ToolStrip7.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStrip7.TabIndex = 45
        Me.ToolStrip7.Text = "ToolStrip7"
        '
        'btnfrmEmployees
        '
        Me.btnfrmEmployees.AutoSize = False
        Me.btnfrmEmployees.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmEmployees.ForeColor = System.Drawing.Color.Black
        Me.btnfrmEmployees.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.btnfrmEmployees.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmEmployees.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmEmployees.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmEmployees.Name = "btnfrmEmployees"
        Me.btnfrmEmployees.Size = New System.Drawing.Size(150, 100)
        Me.btnfrmEmployees.Text = "ادارة الموظفين"
        Me.btnfrmEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.AutoSize = False
        Me.ToolStripSeparator25.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmJobTitles
        '
        Me.btnfrmJobTitles.AutoSize = False
        Me.btnfrmJobTitles.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmJobTitles.ForeColor = System.Drawing.Color.Black
        Me.btnfrmJobTitles.Image = Global.WindowsApp1.My.Resources.Resources.artist
        Me.btnfrmJobTitles.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmJobTitles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmJobTitles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmJobTitles.Name = "btnfrmJobTitles"
        Me.btnfrmJobTitles.Size = New System.Drawing.Size(160, 100)
        Me.btnfrmJobTitles.Text = "المسميات الوظيفية"
        Me.btnfrmJobTitles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.AutoSize = False
        Me.ToolStripSeparator26.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmDepartments
        '
        Me.btnfrmDepartments.AutoSize = False
        Me.btnfrmDepartments.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmDepartments.ForeColor = System.Drawing.Color.Black
        Me.btnfrmDepartments.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.btnfrmDepartments.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmDepartments.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmDepartments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmDepartments.Name = "btnfrmDepartments"
        Me.btnfrmDepartments.Size = New System.Drawing.Size(110, 100)
        Me.btnfrmDepartments.Text = "الاقسام"
        Me.btnfrmDepartments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.AutoSize = False
        Me.ToolStripSeparator27.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmSalarySystems
        '
        Me.btnfrmSalarySystems.AutoSize = False
        Me.btnfrmSalarySystems.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmSalarySystems.ForeColor = System.Drawing.Color.Black
        Me.btnfrmSalarySystems.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.btnfrmSalarySystems.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmSalarySystems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmSalarySystems.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmSalarySystems.Name = "btnfrmSalarySystems"
        Me.btnfrmSalarySystems.Size = New System.Drawing.Size(110, 100)
        Me.btnfrmSalarySystems.Text = "انظمة الرواتب"
        Me.btnfrmSalarySystems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.AutoSize = False
        Me.ToolStripSeparator28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmSalaryPayment
        '
        Me.btnfrmSalaryPayment.AutoSize = False
        Me.btnfrmSalaryPayment.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmSalaryPayment.ForeColor = System.Drawing.Color.Black
        Me.btnfrmSalaryPayment.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.btnfrmSalaryPayment.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmSalaryPayment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmSalaryPayment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmSalaryPayment.Name = "btnfrmSalaryPayment"
        Me.btnfrmSalaryPayment.Size = New System.Drawing.Size(110, 100)
        Me.btnfrmSalaryPayment.Text = "صرف مرتب"
        Me.btnfrmSalaryPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AutoSize = False
        Me.ToolStripSeparator8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(10, 113)
        '
        'tabUsers
        '
        Me.tabUsers.Controls.Add(Me.ToolStrip11)
        Me.tabUsers.Location = New System.Drawing.Point(4, 104)
        Me.tabUsers.Name = "tabUsers"
        Me.tabUsers.Size = New System.Drawing.Size(1426, 139)
        Me.tabUsers.TabIndex = 10
        Me.tabUsers.Text = "المستخدمين"
        Me.tabUsers.UseVisualStyleBackColor = True
        '
        'ToolStrip11
        '
        Me.ToolStrip11.AutoSize = False
        Me.ToolStrip11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip11.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnfrmUsers, Me.ToolStripSeparator10, Me.btnfrmRolesAndPermissions})
        Me.ToolStrip11.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip11.Name = "ToolStrip11"
        Me.ToolStrip11.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStrip11.TabIndex = 46
        Me.ToolStrip11.Text = "ToolStrip11"
        '
        'btnfrmUsers
        '
        Me.btnfrmUsers.AutoSize = False
        Me.btnfrmUsers.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmUsers.ForeColor = System.Drawing.Color.Black
        Me.btnfrmUsers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.btnfrmUsers.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmUsers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmUsers.Name = "btnfrmUsers"
        Me.btnfrmUsers.Size = New System.Drawing.Size(150, 100)
        Me.btnfrmUsers.Text = "ادارة المستخدمين"
        Me.btnfrmUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.AutoSize = False
        Me.ToolStripSeparator10.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmRolesAndPermissions
        '
        Me.btnfrmRolesAndPermissions.AutoSize = False
        Me.btnfrmRolesAndPermissions.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmRolesAndPermissions.ForeColor = System.Drawing.Color.Black
        Me.btnfrmRolesAndPermissions.Image = Global.WindowsApp1.My.Resources.Resources.artist
        Me.btnfrmRolesAndPermissions.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmRolesAndPermissions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmRolesAndPermissions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmRolesAndPermissions.Name = "btnfrmRolesAndPermissions"
        Me.btnfrmRolesAndPermissions.Size = New System.Drawing.Size(160, 100)
        Me.btnfrmRolesAndPermissions.Text = "الأدوار والصلاحيات"
        Me.btnfrmRolesAndPermissions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tabbackup
        '
        Me.tabbackup.Controls.Add(Me.ToolStrip8)
        Me.tabbackup.Location = New System.Drawing.Point(4, 104)
        Me.tabbackup.Name = "tabbackup"
        Me.tabbackup.Size = New System.Drawing.Size(1426, 139)
        Me.tabbackup.TabIndex = 8
        Me.tabbackup.Text = "النسخ الاحتياطي"
        Me.tabbackup.UseVisualStyleBackColor = True
        '
        'ToolStrip8
        '
        Me.ToolStrip8.AutoSize = False
        Me.ToolStrip8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBackups, Me.ToolStripSeparator38})
        Me.ToolStrip8.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip8.Name = "ToolStrip8"
        Me.ToolStrip8.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStrip8.TabIndex = 47
        Me.ToolStrip8.Text = "ToolStrip8"
        '
        'btnBackups
        '
        Me.btnBackups.AutoSize = False
        Me.btnBackups.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackups.ForeColor = System.Drawing.Color.Black
        Me.btnBackups.Image = Global.WindowsApp1.My.Resources.Resources.backup
        Me.btnBackups.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBackups.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBackups.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBackups.Name = "btnBackups"
        Me.btnBackups.Size = New System.Drawing.Size(150, 100)
        Me.btnBackups.Text = "النسخ الاحتياطية"
        Me.btnBackups.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator38
        '
        Me.ToolStripSeparator38.AutoSize = False
        Me.ToolStripSeparator38.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator38.Name = "ToolStripSeparator38"
        Me.ToolStripSeparator38.Size = New System.Drawing.Size(10, 113)
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.ToolStripSet)
        Me.tabSettings.Location = New System.Drawing.Point(4, 104)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Size = New System.Drawing.Size(1426, 139)
        Me.tabSettings.TabIndex = 9
        Me.tabSettings.Text = "الاعدادات"
        Me.tabSettings.UseVisualStyleBackColor = True
        '
        'ToolStripSet
        '
        Me.ToolStripSet.AutoSize = False
        Me.ToolStripSet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripSet.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSettings, Me.ToolStripSeparator29, Me.btnfrmColors, Me.ToolStripSeparator30, Me.btnfrmPrinters, Me.ToolStripSeparator31, Me.btnfrmRestaurantSections, Me.ToolStripSeparator32, Me.btnfrmRestaurantTables, Me.ToolStripSeparator35, Me.btnfrmUnits, Me.ToolStripSeparator23, Me.btnfrmStores, Me.ToolStripSeparator44, Me.btnfrmStoreStock, Me.ToolStripSeparator45, Me.btnfrmRawMaterials, Me.ToolStripSeparator47, Me.btnfrmRecipes, Me.ToolStripSeparator46})
        Me.ToolStripSet.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripSet.Name = "ToolStripSet"
        Me.ToolStripSet.Size = New System.Drawing.Size(1426, 139)
        Me.ToolStripSet.TabIndex = 46
        Me.ToolStripSet.Text = "ToolStrip8"
        '
        'btnSettings
        '
        Me.btnSettings.AutoSize = False
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.Black
        Me.btnSettings.Image = Global.WindowsApp1.My.Resources.Resources.setting
        Me.btnSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(150, 100)
        Me.btnSettings.Text = "اعدادات البرنامج"
        Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.AutoSize = False
        Me.ToolStripSeparator29.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmColors
        '
        Me.btnfrmColors.AutoSize = False
        Me.btnfrmColors.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmColors.ForeColor = System.Drawing.Color.Black
        Me.btnfrmColors.Image = Global.WindowsApp1.My.Resources.Resources.color_palette
        Me.btnfrmColors.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmColors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmColors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmColors.Name = "btnfrmColors"
        Me.btnfrmColors.Size = New System.Drawing.Size(90, 100)
        Me.btnfrmColors.Text = "الالوان"
        Me.btnfrmColors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.AutoSize = False
        Me.ToolStripSeparator30.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmPrinters
        '
        Me.btnfrmPrinters.AutoSize = False
        Me.btnfrmPrinters.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmPrinters.ForeColor = System.Drawing.Color.Black
        Me.btnfrmPrinters.Image = Global.WindowsApp1.My.Resources.Resources.printer__1_
        Me.btnfrmPrinters.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmPrinters.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmPrinters.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmPrinters.Name = "btnfrmPrinters"
        Me.btnfrmPrinters.Size = New System.Drawing.Size(110, 100)
        Me.btnfrmPrinters.Text = "الطابعات"
        Me.btnfrmPrinters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.AutoSize = False
        Me.ToolStripSeparator31.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmRestaurantSections
        '
        Me.btnfrmRestaurantSections.AutoSize = False
        Me.btnfrmRestaurantSections.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmRestaurantSections.ForeColor = System.Drawing.Color.Black
        Me.btnfrmRestaurantSections.Image = Global.WindowsApp1.My.Resources.Resources.videos
        Me.btnfrmRestaurantSections.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmRestaurantSections.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmRestaurantSections.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmRestaurantSections.Name = "btnfrmRestaurantSections"
        Me.btnfrmRestaurantSections.Size = New System.Drawing.Size(130, 100)
        Me.btnfrmRestaurantSections.Text = "اقسام المطعم"
        Me.btnfrmRestaurantSections.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.AutoSize = False
        Me.ToolStripSeparator32.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmRestaurantTables
        '
        Me.btnfrmRestaurantTables.AutoSize = False
        Me.btnfrmRestaurantTables.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmRestaurantTables.ForeColor = System.Drawing.Color.Black
        Me.btnfrmRestaurantTables.Image = Global.WindowsApp1.My.Resources.Resources.round_table
        Me.btnfrmRestaurantTables.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmRestaurantTables.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmRestaurantTables.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmRestaurantTables.Name = "btnfrmRestaurantTables"
        Me.btnfrmRestaurantTables.Size = New System.Drawing.Size(130, 100)
        Me.btnfrmRestaurantTables.Text = "طاولات المطعم"
        Me.btnfrmRestaurantTables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.AutoSize = False
        Me.ToolStripSeparator35.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmUnits
        '
        Me.btnfrmUnits.AutoSize = False
        Me.btnfrmUnits.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmUnits.ForeColor = System.Drawing.Color.Black
        Me.btnfrmUnits.Image = Global.WindowsApp1.My.Resources.Resources.cubes
        Me.btnfrmUnits.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmUnits.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmUnits.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmUnits.Name = "btnfrmUnits"
        Me.btnfrmUnits.Size = New System.Drawing.Size(130, 100)
        Me.btnfrmUnits.Text = "إدارة الوحدات"
        Me.btnfrmUnits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.AutoSize = False
        Me.ToolStripSeparator23.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmStores
        '
        Me.btnfrmStores.AutoSize = False
        Me.btnfrmStores.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmStores.ForeColor = System.Drawing.Color.Black
        Me.btnfrmStores.Image = Global.WindowsApp1.My.Resources.Resources.in_stock
        Me.btnfrmStores.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmStores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmStores.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmStores.Name = "btnfrmStores"
        Me.btnfrmStores.Size = New System.Drawing.Size(130, 100)
        Me.btnfrmStores.Text = "إدارة المخازن"
        Me.btnfrmStores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator44
        '
        Me.ToolStripSeparator44.AutoSize = False
        Me.ToolStripSeparator44.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator44.Name = "ToolStripSeparator44"
        Me.ToolStripSeparator44.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmStoreStock
        '
        Me.btnfrmStoreStock.AutoSize = False
        Me.btnfrmStoreStock.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmStoreStock.ForeColor = System.Drawing.Color.Black
        Me.btnfrmStoreStock.Image = Global.WindowsApp1.My.Resources.Resources.stock
        Me.btnfrmStoreStock.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmStoreStock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmStoreStock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmStoreStock.Name = "btnfrmStoreStock"
        Me.btnfrmStoreStock.Size = New System.Drawing.Size(180, 100)
        Me.btnfrmStoreStock.Text = "المخزون"
        Me.btnfrmStoreStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator45
        '
        Me.ToolStripSeparator45.AutoSize = False
        Me.ToolStripSeparator45.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator45.Name = "ToolStripSeparator45"
        Me.ToolStripSeparator45.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmRawMaterials
        '
        Me.btnfrmRawMaterials.AutoSize = False
        Me.btnfrmRawMaterials.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmRawMaterials.ForeColor = System.Drawing.Color.Black
        Me.btnfrmRawMaterials.Image = Global.WindowsApp1.My.Resources.Resources.raw_materials
        Me.btnfrmRawMaterials.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmRawMaterials.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmRawMaterials.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmRawMaterials.Name = "btnfrmRawMaterials"
        Me.btnfrmRawMaterials.Size = New System.Drawing.Size(100, 100)
        Me.btnfrmRawMaterials.Text = "الخامات"
        Me.btnfrmRawMaterials.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator47
        '
        Me.ToolStripSeparator47.AutoSize = False
        Me.ToolStripSeparator47.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator47.Name = "ToolStripSeparator47"
        Me.ToolStripSeparator47.Size = New System.Drawing.Size(10, 113)
        '
        'btnfrmRecipes
        '
        Me.btnfrmRecipes.AutoSize = False
        Me.btnfrmRecipes.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfrmRecipes.ForeColor = System.Drawing.Color.Black
        Me.btnfrmRecipes.Image = Global.WindowsApp1.My.Resources.Resources.round_table
        Me.btnfrmRecipes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfrmRecipes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnfrmRecipes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfrmRecipes.Name = "btnfrmRecipes"
        Me.btnfrmRecipes.Size = New System.Drawing.Size(100, 100)
        Me.btnfrmRecipes.Text = "الريسيبي"
        Me.btnfrmRecipes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator46
        '
        Me.ToolStripSeparator46.AutoSize = False
        Me.ToolStripSeparator46.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripSeparator46.Name = "ToolStripSeparator46"
        Me.ToolStripSeparator46.Size = New System.Drawing.Size(10, 113)
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1434, 900)
        Me.Controls.Add(Me.pnlDashboard)
        Me.Controls.Add(Me.statusStripMain)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1200, 720)
        Me.Name = "MainForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.statusStripMain.ResumeLayout(False)
        Me.statusStripMain.PerformLayout()
        Me.pnlDashboard.ResumeLayout(False)
        Me.tlpMainContent.ResumeLayout(False)
        Me.cardRecentInvoices.ResumeLayout(False)
        CType(Me.dgvRecentInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInvoicesHeader.ResumeLayout(False)
        Me.pnlInvoicesHeader.PerformLayout()
        Me.cardAlerts.ResumeLayout(False)
        Me.pnlAlertsContainer.ResumeLayout(False)
        Me.cardAlertBackup.ResumeLayout(False)
        Me.cardAlertBackup.PerformLayout()
        Me.cardAlertShift.ResumeLayout(False)
        Me.cardAlertShift.PerformLayout()
        Me.cardAlertStock.ResumeLayout(False)
        Me.cardAlertStock.PerformLayout()
        Me.pnlQuickButtons.ResumeLayout(False)
        Me.pnlQuickButtons.PerformLayout()
        Me.tlpQuickBtns.ResumeLayout(False)
        Me.pnlAlertsHeader.ResumeLayout(False)
        Me.pnlAlertsHeader.PerformLayout()
        Me.tlpStats.ResumeLayout(False)
        Me.cardSales.ResumeLayout(False)
        Me.cardSales.PerformLayout()
        CType(Me.picCardSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardPurchases.ResumeLayout(False)
        Me.cardPurchases.PerformLayout()
        CType(Me.picCardPurchases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardProfit.ResumeLayout(False)
        Me.cardProfit.PerformLayout()
        CType(Me.picCardProfit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardProducts.ResumeLayout(False)
        Me.cardProducts.PerformLayout()
        CType(Me.picCardProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardCustomers.ResumeLayout(False)
        Me.cardCustomers.PerformLayout()
        CType(Me.picCardCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardSuppliers.ResumeLayout(False)
        Me.cardSuppliers.PerformLayout()
        CType(Me.picCardSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWelcome.ResumeLayout(False)
        Me.pnlWelcome.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabsystem.ResumeLayout(False)
        Me.tabCustomers.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tabSuppliers.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.tabSales.ResumeLayout(False)
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.tabPurchases.ResumeLayout(False)
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.tabStorage.ResumeLayout(False)
        Me.ToolStrip6.ResumeLayout(False)
        Me.ToolStrip6.PerformLayout()
        Me.tabExpenses.ResumeLayout(False)
        Me.ToolStrip10.ResumeLayout(False)
        Me.ToolStrip10.PerformLayout()
        Me.tabemployees.ResumeLayout(False)
        Me.ToolStrip7.ResumeLayout(False)
        Me.ToolStrip7.PerformLayout()
        Me.tabUsers.ResumeLayout(False)
        Me.ToolStrip11.ResumeLayout(False)
        Me.ToolStrip11.PerformLayout()
        Me.tabbackup.ResumeLayout(False)
        Me.ToolStrip8.ResumeLayout(False)
        Me.ToolStrip8.PerformLayout()
        Me.tabSettings.ResumeLayout(False)
        Me.ToolStripSet.ResumeLayout(False)
        Me.ToolStripSet.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbltitle As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnCategories As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TabControl1 As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents tabsystem As TabPage
    Friend WithEvents tabCustomers As TabPage
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents btnProducts As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents btnfrmProductSizes As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btnfrmProductAddons As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnfrmKitchenComments As ToolStripButton
    Friend WithEvents ToolStripSeparatorKitchenComments As ToolStripSeparator
    Friend WithEvents btnfrmDeliveryAreas As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnfrmDeliveryDrivers As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents btnFrmCustomers As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnFrmCustomerStatement As ToolStripButton
    Friend WithEvents ToolStripSeparator18 As ToolStripSeparator
    Friend WithEvents btnCustomerBalanceDownload As ToolStripButton
    Friend WithEvents ToolStripButton11 As ToolStripButton
    Friend WithEvents ToolStripSeparator17 As ToolStripSeparator
    Friend WithEvents tabSuppliers As TabPage
    Friend WithEvents tabSales As TabPage
    Friend WithEvents tabPurchases As TabPage
    Friend WithEvents tabStorage As TabPage
    Friend WithEvents tabExpenses As TabPage
    Friend WithEvents tabemployees As TabPage
    Friend WithEvents tabbackup As TabPage
    Friend WithEvents tabSettings As TabPage
    Friend WithEvents ToolStrip4 As ToolStrip
    Friend WithEvents btnfrmPOS As ToolStripButton
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents btnFrmSalesReport As ToolStripButton
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents btnFrmDriverReport As ToolStripButton
    Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents btnfrmPurchases As ToolStripButton
    Friend WithEvents ToolStripSeparator19 As ToolStripSeparator
    Friend WithEvents ToolStrip6 As ToolStrip
    Friend WithEvents btnfrmTreasury As ToolStripButton
    Friend WithEvents ToolStripSeparator22 As ToolStripSeparator
    Friend WithEvents btnFrmTreasuryTransfer As ToolStripButton
    Friend WithEvents ToolStripSeparator24 As ToolStripSeparator
    Friend WithEvents ToolStrip7 As ToolStrip
    Friend WithEvents btnfrmEmployees As ToolStripButton
    Friend WithEvents ToolStripSeparator25 As ToolStripSeparator
    Friend WithEvents btnfrmJobTitles As ToolStripButton
    Friend WithEvents ToolStripSeparator26 As ToolStripSeparator
    Friend WithEvents btnfrmDepartments As ToolStripButton
    Friend WithEvents ToolStripSeparator27 As ToolStripSeparator
    Friend WithEvents btnfrmSalarySystems As ToolStripButton
    Friend WithEvents ToolStripSeparator28 As ToolStripSeparator
    Friend WithEvents ToolStripSet As ToolStrip
    Friend WithEvents btnSettings As ToolStripButton
    Friend WithEvents ToolStripSeparator29 As ToolStripSeparator
    Friend WithEvents btnfrmColors As ToolStripButton
    Friend WithEvents ToolStripSeparator30 As ToolStripSeparator
    Friend WithEvents btnfrmPrinters As ToolStripButton
    Friend WithEvents ToolStripSeparator31 As ToolStripSeparator
    Friend WithEvents btnfrmRestaurantSections As ToolStripButton
    Friend WithEvents ToolStripSeparator32 As ToolStripSeparator
    Friend WithEvents btnFrmTreasuryTransactionsReport As ToolStripButton
    Friend WithEvents ToolStripSeparator33 As ToolStripSeparator
    Friend WithEvents btnfrmRestaurantTables As ToolStripButton
    Friend WithEvents ToolStripSeparator35 As ToolStripSeparator
    Friend WithEvents btnfrmShifts As ToolStripButton
    Friend WithEvents ToolStripSeparator36 As ToolStripSeparator
    Friend WithEvents btnShiftReports As ToolStripButton
    Friend WithEvents ToolStripSeparatorShiftReports As ToolStripSeparator
    Friend WithEvents btnfrmBranches As ToolStripButton
    Friend WithEvents ToolStripSeparator37 As ToolStripSeparator
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents ToolStrip10 As ToolStrip
    Friend WithEvents btnform_Expenses As ToolStripButton
    Friend WithEvents ToolStripSeparator40 As ToolStripSeparator
    Friend WithEvents btnExpensesReportForm As ToolStripButton
    Friend WithEvents ToolStripSeparator41 As ToolStripSeparator
    Friend WithEvents btnDeposit As ToolStripButton
    Friend WithEvents ToolStripSeparator43 As ToolStripSeparator
    Friend WithEvents btnWithdraw As ToolStripButton
    Friend WithEvents ToolStripSeparator42 As ToolStripSeparator
    Friend WithEvents btnfrmUnits As ToolStripButton
    Friend WithEvents ToolStripSeparator23 As ToolStripSeparator
    Friend WithEvents btnfrmStores As ToolStripButton
    Friend WithEvents ToolStripSeparator44 As ToolStripSeparator
    Friend WithEvents btnfrmStoreStock As ToolStripButton
    Friend WithEvents ToolStripSeparator45 As ToolStripSeparator
    Friend WithEvents btnfrmRecipes As ToolStripButton
    Friend WithEvents ToolStripSeparator46 As ToolStripSeparator
    Friend WithEvents btnfrmRawMaterials As ToolStripButton
    Friend WithEvents ToolStripSeparator47 As ToolStripSeparator
    Friend WithEvents ToolStrip8 As ToolStrip
    Friend WithEvents btnBackups As ToolStripButton
    Friend WithEvents ToolStripSeparator38 As ToolStripSeparator
    Friend WithEvents btnfrmSalaryPayment As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tabUsers As TabPage
    Friend WithEvents ToolStrip11 As ToolStrip
    Friend WithEvents btnfrmUsers As ToolStripButton
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents btnfrmRolesAndPermissions As ToolStripButton
    Friend WithEvents btnfrmPurchaseReports As ToolStripButton
    Friend WithEvents ToolStripSeparator20 As ToolStripSeparator
    Friend WithEvents btnSalesReturns As ToolStripButton
    Friend WithEvents ToolStripSeparator50 As ToolStripSeparator
    Friend WithEvents btnKds As ToolStripButton
    Friend WithEvents ToolStripSeparator51 As ToolStripSeparator
    Friend WithEvents btnWaste As ToolStripButton
    Friend WithEvents ToolStripSeparator52 As ToolStripSeparator
    Friend WithEvents btnRes As ToolStripButton
    Friend WithEvents ToolStripSeparator53 As ToolStripSeparator
    Friend WithEvents statusStripMain As StatusStrip
    Friend WithEvents lblStatusUser As ToolStripStatusLabel
    Friend WithEvents sepStatus1 As ToolStripStatusLabel
    Friend WithEvents lblStatusRole As ToolStripStatusLabel
    Friend WithEvents sepStatus2 As ToolStripStatusLabel
    Friend WithEvents lblStatusBranch As ToolStripStatusLabel
    Friend WithEvents sepStatus3 As ToolStripStatusLabel
    Friend WithEvents lblStatusShift As ToolStripStatusLabel
    Friend WithEvents sepStatus4 As ToolStripStatusLabel
    Friend WithEvents lblStatusDateTime As ToolStripStatusLabel
    Friend WithEvents sepStatus5 As ToolStripStatusLabel
    Friend WithEvents lblStatusDb As ToolStripStatusLabel
    Friend WithEvents sepStatus6 As ToolStripStatusLabel
    Friend WithEvents lblStatusVersion As ToolStripStatusLabel
    Friend WithEvents pnlDashboard As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlWelcome As Panel
    Friend WithEvents lblWelcomeGreeting As Label
    Friend WithEvents lblWelcomeSub As Label
    Friend WithEvents btnRefreshDashboard As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblShiftDuration As Label
    Friend WithEvents tlpStats As TableLayoutPanel
    Friend WithEvents cardSales As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardSalesTitle As Label
    Friend WithEvents lblCardSalesVal As Label
    Friend WithEvents lblCardSalesSub As Label
    Friend WithEvents picCardSales As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardPurchases As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardPurchasesTitle As Label
    Friend WithEvents lblCardPurchasesVal As Label
    Friend WithEvents lblCardPurchasesSub As Label
    Friend WithEvents picCardPurchases As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardProfit As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardProfitTitle As Label
    Friend WithEvents lblCardProfitVal As Label
    Friend WithEvents lblCardProfitSub As Label
    Friend WithEvents picCardProfit As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardProducts As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardProductsTitle As Label
    Friend WithEvents lblCardProductsVal As Label
    Friend WithEvents lblCardProductsSub As Label
    Friend WithEvents picCardProducts As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardCustomers As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardCustomersTitle As Label
    Friend WithEvents lblCardCustomersVal As Label
    Friend WithEvents lblCardCustomersSub As Label
    Friend WithEvents picCardCustomers As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardSuppliers As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardSuppliersTitle As Label
    Friend WithEvents lblCardSuppliersVal As Label
    Friend WithEvents lblCardSuppliersSub As Label
    Friend WithEvents picCardSuppliers As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents tlpMainContent As TableLayoutPanel
    Friend WithEvents cardRecentInvoices As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlInvoicesHeader As Panel
    Friend WithEvents lblRecentInvoicesTitle As Label
    Friend WithEvents btnViewAllInvoices As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgvRecentInvoices As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents colInvNum As DataGridViewTextBoxColumn
    Friend WithEvents colInvTime As DataGridViewTextBoxColumn
    Friend WithEvents colInvCustomer As DataGridViewTextBoxColumn
    Friend WithEvents colInvType As DataGridViewTextBoxColumn
    Friend WithEvents colInvTotal As DataGridViewTextBoxColumn
    Friend WithEvents colInvPayment As DataGridViewTextBoxColumn
    Friend WithEvents cardAlerts As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlAlertsHeader As Panel
    Friend WithEvents lblAlertsTitle As Label
    Friend WithEvents pnlAlertsContainer As Panel
    Friend WithEvents cardAlertStock As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblAlertStockTitle As Label
    Friend WithEvents lblAlertStockDesc As Label
    Friend WithEvents cardAlertShift As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblAlertShiftTitle As Label
    Friend WithEvents lblAlertShiftDesc As Label
    Friend WithEvents cardAlertBackup As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblAlertBackupTitle As Label
    Friend WithEvents lblAlertBackupDesc As Label
    Friend WithEvents pnlQuickButtons As Panel
    Friend WithEvents lblQuickTitle As Label
    Friend WithEvents tlpQuickBtns As TableLayoutPanel
    Friend WithEvents btnQuickPOS As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnQuickProducts As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnQuickCustomers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnQuickBackup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tmrClock As Timer
    Friend WithEvents tmrDashboardRefresh As Timer
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSupport As Guna.UI2.WinForms.Guna2Button
End Class