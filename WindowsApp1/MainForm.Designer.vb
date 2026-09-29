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
        Dim dgvCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dgvCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        ' Header Controls
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.picLogo = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lbltitle = New System.Windows.Forms.Label()
        Me.lblProBadge = New Guna.UI2.WinForms.Guna2Button()
        Me.txtGlobalSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblHeaderBranch = New System.Windows.Forms.Label()
        Me.lblStatusUserRole = New System.Windows.Forms.Label()
        Me.btnSupport = New Guna.UI2.WinForms.Guna2Button()
        Me.btnLogout = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_min = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_max = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_close = New Guna.UI2.WinForms.Guna2Button()

        ' Sidebar Controls
        Me.pnlSidebar = New Guna.UI2.WinForms.Guna2Panel()
        Me.flpNav = New System.Windows.Forms.FlowLayoutPanel()
        Me.navDashboard = New Guna.UI2.WinForms.Guna2Button()
        Me.navSales = New Guna.UI2.WinForms.Guna2Button()
        Me.navSystem = New Guna.UI2.WinForms.Guna2Button()
        Me.navInventory = New Guna.UI2.WinForms.Guna2Button()
        Me.navPurchases = New Guna.UI2.WinForms.Guna2Button()
        Me.navCustomers = New Guna.UI2.WinForms.Guna2Button()
        Me.navSuppliers = New Guna.UI2.WinForms.Guna2Button()
        Me.navTreasury = New Guna.UI2.WinForms.Guna2Button()
        Me.navExpenses = New Guna.UI2.WinForms.Guna2Button()
        Me.navEmployees = New Guna.UI2.WinForms.Guna2Button()
        Me.navUsers = New Guna.UI2.WinForms.Guna2Button()
        Me.navSettings = New Guna.UI2.WinForms.Guna2Button()

        ' Status Bar
        Me.statusStripMain = New System.Windows.Forms.StatusStrip()
        Me.lblStatusDb = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusRole = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusBranch = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusShift = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusDateTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusVersion = New System.Windows.Forms.ToolStripStatusLabel()

        ' Main Container & Views
        Me.pnlMainContainer = New System.Windows.Forms.Panel()
        Me.viewDashboard = New System.Windows.Forms.Panel()
        Me.pnlWelcome = New System.Windows.Forms.Panel()
        Me.lblWelcomeGreeting = New System.Windows.Forms.Label()
        Me.lblWelcomeSub = New System.Windows.Forms.Label()
        Me.lblShiftDuration = New System.Windows.Forms.Label()
        Me.btnRefreshDashboard = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlDashboardBody = New System.Windows.Forms.Panel()
        Me.pnlQuickButtons = New System.Windows.Forms.Panel()
        Me.lblQuickTitle = New System.Windows.Forms.Label()
        Me.tlpQuickBtns = New System.Windows.Forms.TableLayoutPanel()
        Me.btnQuickPOS = New Guna.UI2.WinForms.Guna2Button()
        Me.btnQuickProducts = New Guna.UI2.WinForms.Guna2Button()
        Me.btnQuickCustomers = New Guna.UI2.WinForms.Guna2Button()
        Me.btnQuickBackup = New Guna.UI2.WinForms.Guna2Button()
        Me.tlpStats = New System.Windows.Forms.TableLayoutPanel()
        Me.cardSales = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardSalesTitle = New System.Windows.Forms.Label()
        Me.lblCardSalesVal = New System.Windows.Forms.Label()
        Me.lblCardSalesSub = New System.Windows.Forms.Label()
        Me.picCardSales = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardPurchases = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardPurchasesTitle = New System.Windows.Forms.Label()
        Me.lblCardPurchasesVal = New System.Windows.Forms.Label()
        Me.lblCardPurchasesSub = New System.Windows.Forms.Label()
        Me.picCardPurchases = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardProfit = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardProfitTitle = New System.Windows.Forms.Label()
        Me.lblCardProfitVal = New System.Windows.Forms.Label()
        Me.lblCardProfitSub = New System.Windows.Forms.Label()
        Me.picCardProfit = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardProducts = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardProductsTitle = New System.Windows.Forms.Label()
        Me.lblCardProductsVal = New System.Windows.Forms.Label()
        Me.lblCardProductsSub = New System.Windows.Forms.Label()
        Me.picCardProducts = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardCustomers = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardCustomersTitle = New System.Windows.Forms.Label()
        Me.lblCardCustomersVal = New System.Windows.Forms.Label()
        Me.lblCardCustomersSub = New System.Windows.Forms.Label()
        Me.picCardCustomers = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cardSuppliers = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardSuppliersTitle = New System.Windows.Forms.Label()
        Me.lblCardSuppliersVal = New System.Windows.Forms.Label()
        Me.lblCardSuppliersSub = New System.Windows.Forms.Label()
        Me.picCardSuppliers = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.tlpMainContent = New System.Windows.Forms.TableLayoutPanel()
        Me.cardRecentInvoices = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlInvoicesHeader = New System.Windows.Forms.Panel()
        Me.lblRecentInvoicesTitle = New System.Windows.Forms.Label()
        Me.btnViewAllInvoices = New Guna.UI2.WinForms.Guna2Button()
        Me.dgvRecentInvoices = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.colInvNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvPayment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cardAlerts = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlAlertsHeader = New System.Windows.Forms.Panel()
        Me.lblAlertsTitle = New System.Windows.Forms.Label()
        Me.pnlAlertsContainer = New System.Windows.Forms.Panel()
        Me.cardAlertStock = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblAlertStockTitle = New System.Windows.Forms.Label()
        Me.lblAlertStockDesc = New System.Windows.Forms.Label()
        Me.cardAlertShift = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblAlertShiftTitle = New System.Windows.Forms.Label()
        Me.lblAlertShiftDesc = New System.Windows.Forms.Label()
        Me.cardAlertBackup = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblAlertBackupTitle = New System.Windows.Forms.Label()
        Me.lblAlertBackupDesc = New System.Windows.Forms.Label()
        Me.tmrClock = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDashboardRefresh = New System.Windows.Forms.Timer(Me.components)

        ' View: Sales
        Me.viewSales = New System.Windows.Forms.Panel()
        Me.pnlHeaderSales = New System.Windows.Forms.Panel()
        Me.picHeaderSales = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleSales = New System.Windows.Forms.Label()
        Me.lblDescSales = New System.Windows.Forms.Label()
        Me.btnBackSales = New Guna.UI2.WinForms.Guna2Button()
        Me.flpSales = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnfrmPOS = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSalesReturns = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFrmSalesReport = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFrmDriverReport = New Guna.UI2.WinForms.Guna2Button()
        Me.btnKds = New Guna.UI2.WinForms.Guna2Button()
        Me.btnWaste = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRes = New Guna.UI2.WinForms.Guna2Button()

        ' View: System
        Me.viewSystem = New System.Windows.Forms.Panel()
        Me.pnlHeaderSystem = New System.Windows.Forms.Panel()
        Me.picHeaderSystem = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleSystem = New System.Windows.Forms.Label()
        Me.lblDescSystem = New System.Windows.Forms.Label()
        Me.btnBackSystem = New Guna.UI2.WinForms.Guna2Button()
        Me.flpSystem = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnCategories = New Guna.UI2.WinForms.Guna2Button()
        Me.btnProducts = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmProductSizes = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmProductAddons = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmKitchenComments = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmDeliveryAreas = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmDeliveryDrivers = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmShifts = New Guna.UI2.WinForms.Guna2Button()
        Me.btnShiftReports = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmBranches = New Guna.UI2.WinForms.Guna2Button()

        ' View: Inventory
        Me.viewInventory = New System.Windows.Forms.Panel()
        Me.pnlHeaderInventory = New System.Windows.Forms.Panel()
        Me.picHeaderInventory = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleInventory = New System.Windows.Forms.Label()
        Me.lblDescInventory = New System.Windows.Forms.Label()
        Me.btnBackInventory = New Guna.UI2.WinForms.Guna2Button()
        Me.flpInventory = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnfrmStoreStock = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmRawMaterials = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmRecipes = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmStores = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmUnits = New Guna.UI2.WinForms.Guna2Button()

        ' View: Purchases
        Me.viewPurchases = New System.Windows.Forms.Panel()
        Me.pnlHeaderPurchases = New System.Windows.Forms.Panel()
        Me.picHeaderPurchases = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitlePurchases = New System.Windows.Forms.Label()
        Me.lblDescPurchases = New System.Windows.Forms.Label()
        Me.btnBackPurchases = New Guna.UI2.WinForms.Guna2Button()
        Me.flpPurchases = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnfrmPurchases = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmPurchaseReports = New Guna.UI2.WinForms.Guna2Button()

        ' View: Customers
        Me.viewCustomers = New System.Windows.Forms.Panel()
        Me.pnlHeaderCustomers = New System.Windows.Forms.Panel()
        Me.picHeaderCustomers = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleCustomers = New System.Windows.Forms.Label()
        Me.lblDescCustomers = New System.Windows.Forms.Label()
        Me.btnBackCustomers = New Guna.UI2.WinForms.Guna2Button()
        Me.flpCustomers = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnFrmCustomers = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFrmCustomerStatement = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCustomerBalanceDownload = New Guna.UI2.WinForms.Guna2Button()
        Me.ToolStripButton11 = New Guna.UI2.WinForms.Guna2Button()

        ' View: Suppliers
        Me.viewSuppliers = New System.Windows.Forms.Panel()
        Me.pnlHeaderSuppliers = New System.Windows.Forms.Panel()
        Me.picHeaderSuppliers = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleSuppliers = New System.Windows.Forms.Label()
        Me.lblDescSuppliers = New System.Windows.Forms.Label()
        Me.btnBackSuppliers = New Guna.UI2.WinForms.Guna2Button()
        Me.flpSuppliers = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStripButton3 = New Guna.UI2.WinForms.Guna2Button()
        Me.ToolStripButton4 = New Guna.UI2.WinForms.Guna2Button()
        Me.ToolStripButton5 = New Guna.UI2.WinForms.Guna2Button()

        ' View: Treasury
        Me.viewTreasury = New System.Windows.Forms.Panel()
        Me.pnlHeaderTreasury = New System.Windows.Forms.Panel()
        Me.picHeaderTreasury = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleTreasury = New System.Windows.Forms.Label()
        Me.lblDescTreasury = New System.Windows.Forms.Label()
        Me.btnBackTreasury = New Guna.UI2.WinForms.Guna2Button()
        Me.flpTreasury = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnfrmTreasury = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFrmTreasuryTransfer = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeposit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnWithdraw = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFrmTreasuryTransactionsReport = New Guna.UI2.WinForms.Guna2Button()

        ' View: Expenses
        Me.viewExpenses = New System.Windows.Forms.Panel()
        Me.pnlHeaderExpenses = New System.Windows.Forms.Panel()
        Me.picHeaderExpenses = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleExpenses = New System.Windows.Forms.Label()
        Me.lblDescExpenses = New System.Windows.Forms.Label()
        Me.btnBackExpenses = New Guna.UI2.WinForms.Guna2Button()
        Me.flpExpenses = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnform_Expenses = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExpensesReportForm = New Guna.UI2.WinForms.Guna2Button()

        ' View: Employees
        Me.viewEmployees = New System.Windows.Forms.Panel()
        Me.pnlHeaderEmployees = New System.Windows.Forms.Panel()
        Me.picHeaderEmployees = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleEmployees = New System.Windows.Forms.Label()
        Me.lblDescEmployees = New System.Windows.Forms.Label()
        Me.btnBackEmployees = New Guna.UI2.WinForms.Guna2Button()
        Me.flpEmployees = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnfrmEmployees = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmJobTitles = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmDepartments = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmSalarySystems = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmSalaryPayment = New Guna.UI2.WinForms.Guna2Button()

        ' View: Users
        Me.viewUsers = New System.Windows.Forms.Panel()
        Me.pnlHeaderUsers = New System.Windows.Forms.Panel()
        Me.picHeaderUsers = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleUsers = New System.Windows.Forms.Label()
        Me.lblDescUsers = New System.Windows.Forms.Label()
        Me.btnBackUsers = New Guna.UI2.WinForms.Guna2Button()
        Me.flpUsers = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnfrmUsers = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmRolesAndPermissions = New Guna.UI2.WinForms.Guna2Button()

        ' View: Settings
        Me.viewSettings = New System.Windows.Forms.Panel()
        Me.pnlHeaderSettings = New System.Windows.Forms.Panel()
        Me.picHeaderSettings = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblTitleSettings = New System.Windows.Forms.Label()
        Me.lblDescSettings = New System.Windows.Forms.Label()
        Me.btnBackSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.flpSettings = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmPrinters = New Guna.UI2.WinForms.Guna2Button()
        Me.btnBackups = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmRestaurantSections = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmRestaurantTables = New Guna.UI2.WinForms.Guna2Button()
        Me.btnfrmColors = New Guna.UI2.WinForms.Guna2Button()

        Me.panelHeader.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSidebar.SuspendLayout()
        Me.flpNav.SuspendLayout()
        Me.statusStripMain.SuspendLayout()
        Me.pnlMainContainer.SuspendLayout()
        Me.viewDashboard.SuspendLayout()
        Me.pnlWelcome.SuspendLayout()
        Me.pnlDashboardBody.SuspendLayout()
        Me.pnlQuickButtons.SuspendLayout()
        Me.tlpQuickBtns.SuspendLayout()
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
        Me.tlpMainContent.SuspendLayout()
        Me.cardRecentInvoices.SuspendLayout()
        Me.pnlInvoicesHeader.SuspendLayout()
        CType(Me.dgvRecentInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardAlerts.SuspendLayout()
        Me.pnlAlertsHeader.SuspendLayout()
        Me.pnlAlertsContainer.SuspendLayout()
        Me.cardAlertStock.SuspendLayout()
        Me.cardAlertShift.SuspendLayout()
        Me.cardAlertBackup.SuspendLayout()
        Me.viewSales.SuspendLayout()
        Me.pnlHeaderSales.SuspendLayout()
        CType(Me.picHeaderSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpSales.SuspendLayout()
        Me.viewSystem.SuspendLayout()
        Me.pnlHeaderSystem.SuspendLayout()
        CType(Me.picHeaderSystem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpSystem.SuspendLayout()
        Me.viewInventory.SuspendLayout()
        Me.pnlHeaderInventory.SuspendLayout()
        CType(Me.picHeaderInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpInventory.SuspendLayout()
        Me.viewPurchases.SuspendLayout()
        Me.pnlHeaderPurchases.SuspendLayout()
        CType(Me.picHeaderPurchases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpPurchases.SuspendLayout()
        Me.viewCustomers.SuspendLayout()
        Me.pnlHeaderCustomers.SuspendLayout()
        CType(Me.picHeaderCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpCustomers.SuspendLayout()
        Me.viewSuppliers.SuspendLayout()
        Me.pnlHeaderSuppliers.SuspendLayout()
        CType(Me.picHeaderSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpSuppliers.SuspendLayout()
        Me.viewTreasury.SuspendLayout()
        Me.pnlHeaderTreasury.SuspendLayout()
        CType(Me.picHeaderTreasury, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpTreasury.SuspendLayout()
        Me.viewExpenses.SuspendLayout()
        Me.pnlHeaderExpenses.SuspendLayout()
        CType(Me.picHeaderExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpExpenses.SuspendLayout()
        Me.viewEmployees.SuspendLayout()
        Me.pnlHeaderEmployees.SuspendLayout()
        CType(Me.picHeaderEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpEmployees.SuspendLayout()
        Me.viewUsers.SuspendLayout()
        Me.pnlHeaderUsers.SuspendLayout()
        CType(Me.picHeaderUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpUsers.SuspendLayout()
        Me.viewSettings.SuspendLayout()
        Me.pnlHeaderSettings.SuspendLayout()
        CType(Me.picHeaderSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpSettings.SuspendLayout()
        Me.SuspendLayout()

        ' =================== panelHeader ===================
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Height = 56
        Me.panelHeader.FillColor = System.Drawing.Color.FromArgb(17, 22, 34)
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Controls.Add(Me.lblHeaderBranch)
        Me.panelHeader.Controls.Add(Me.txtGlobalSearch)
        Me.panelHeader.Controls.Add(Me.lblProBadge)
        Me.panelHeader.Controls.Add(Me.lbltitle)
        Me.panelHeader.Controls.Add(Me.picLogo)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btnLogout)
        Me.panelHeader.Controls.Add(Me.btnSupport)
        Me.panelHeader.Controls.Add(Me.lblStatusUserRole)
        Me.panelHeader.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)

        ' picLogo
        Me.picLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.picLogo.Width = 36
        Me.picLogo.Height = 36
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Image = Global.WindowsApp1.My.Resources.Resources.restaurant_building
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.Margin = New System.Windows.Forms.Padding(5)

        ' lbltitle
        Me.lbltitle.AutoSize = True
        Me.lbltitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbltitle.BackColor = System.Drawing.Color.Transparent
        Me.lbltitle.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lbltitle.ForeColor = System.Drawing.Color.White
        Me.lbltitle.Text = "سستمك POS لإدارة المطاعم"
        Me.lbltitle.Padding = New System.Windows.Forms.Padding(10, 8, 10, 0)
        Me.lbltitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' lblProBadge
        Me.lblProBadge.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblProBadge.Width = 85
        Me.lblProBadge.BorderRadius = 10
        Me.lblProBadge.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.lblProBadge.ForeColor = System.Drawing.Color.White
        Me.lblProBadge.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblProBadge.Text = "PRO EDITION"
        Me.lblProBadge.Margin = New System.Windows.Forms.Padding(10, 8, 10, 8)

        ' txtGlobalSearch
        Me.txtGlobalSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtGlobalSearch.Width = 300
        Me.txtGlobalSearch.BorderRadius = 10
        Me.txtGlobalSearch.BorderColor = System.Drawing.Color.FromArgb(38, 51, 72)
        Me.txtGlobalSearch.FillColor = System.Drawing.Color.FromArgb(23, 30, 44)
        Me.txtGlobalSearch.ForeColor = System.Drawing.Color.White
        Me.txtGlobalSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.txtGlobalSearch.PlaceholderText = "بحث سريع في الشاشات (Ctrl+K)..."
        Me.txtGlobalSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGlobalSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtGlobalSearch.IconLeft = Global.WindowsApp1.My.Resources.Resources.search
        Me.txtGlobalSearch.IconLeftSize = New System.Drawing.Size(16, 16)
        Me.txtGlobalSearch.Margin = New System.Windows.Forms.Padding(12, 3, 12, 3)

        ' lblHeaderBranch
        Me.lblHeaderBranch.AutoSize = True
        Me.lblHeaderBranch.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblHeaderBranch.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderBranch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.lblHeaderBranch.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.lblHeaderBranch.Text = "الفرع الرئيسي"
        Me.lblHeaderBranch.Padding = New System.Windows.Forms.Padding(0, 10, 10, 0)
        Me.lblHeaderBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btn_close
        Me.btn_close.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_close.Width = 38
        Me.btn_close.BorderRadius = 8
        Me.btn_close.FillColor = System.Drawing.Color.Transparent
        Me.btn_close.ForeColor = System.Drawing.Color.White
        Me.btn_close.HoverState.FillColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btn_close.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_close.Text = "✕"

        ' btn_max
        Me.btn_max.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_max.Width = 38
        Me.btn_max.BorderRadius = 8
        Me.btn_max.FillColor = System.Drawing.Color.Transparent
        Me.btn_max.ForeColor = System.Drawing.Color.White
        Me.btn_max.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btn_max.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_max.Text = "▢"

        ' btn_min
        Me.btn_min.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_min.Width = 38
        Me.btn_min.BorderRadius = 8
        Me.btn_min.FillColor = System.Drawing.Color.Transparent
        Me.btn_min.ForeColor = System.Drawing.Color.White
        Me.btn_min.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btn_min.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_min.Text = "—"

        ' btnLogout
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLogout.Width = 95
        Me.btnLogout.BorderRadius = 8
        Me.btnLogout.FillColor = System.Drawing.Color.FromArgb(50, 20, 25)
        Me.btnLogout.ForeColor = System.Drawing.Color.FromArgb(254, 202, 202)
        Me.btnLogout.BorderThickness = 1
        Me.btnLogout.BorderColor = System.Drawing.Color.FromArgb(127, 29, 29)
        Me.btnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnLogout.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.Text = "  خروج"
        Me.btnLogout.Image = Global.WindowsApp1.My.Resources.Resources.logout
        Me.btnLogout.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnLogout.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(6, 2, 6, 2)

        ' btnSupport
        Me.btnSupport.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSupport.Width = 105
        Me.btnSupport.BorderRadius = 8
        Me.btnSupport.FillColor = System.Drawing.Color.FromArgb(20, 35, 55)
        Me.btnSupport.ForeColor = System.Drawing.Color.FromArgb(186, 230, 253)
        Me.btnSupport.BorderThickness = 1
        Me.btnSupport.BorderColor = System.Drawing.Color.FromArgb(3, 105, 161)
        Me.btnSupport.HoverState.FillColor = System.Drawing.Color.FromArgb(2, 132, 199)
        Me.btnSupport.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnSupport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSupport.Text = "  دعم فني"
        Me.btnSupport.Image = Global.WindowsApp1.My.Resources.Resources.customer_support
        Me.btnSupport.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnSupport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSupport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSupport.Margin = New System.Windows.Forms.Padding(6, 2, 6, 2)

        ' lblStatusUserRole
        Me.lblStatusUserRole.AutoSize = True
        Me.lblStatusUserRole.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblStatusUserRole.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusUserRole.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusUserRole.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253)
        Me.lblStatusUserRole.Text = "المدير العام (مدير النظام)"
        Me.lblStatusUserRole.Padding = New System.Windows.Forms.Padding(8, 10, 8, 0)
        Me.lblStatusUserRole.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' =================== pnlSidebar ===================
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSidebar.Width = 220
        Me.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(17, 22, 34)
        Me.pnlSidebar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlSidebar.Controls.Add(Me.flpNav)

        ' flpNav
        Me.flpNav.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpNav.WrapContents = False
        Me.flpNav.AutoScroll = True
        Me.flpNav.Padding = New System.Windows.Forms.Padding(6, 10, 6, 10)
        Me.flpNav.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' navDashboard
        Me.navDashboard.Name = "navDashboard"
        Me.navDashboard.Size = New System.Drawing.Size(190, 42)
        Me.navDashboard.BorderRadius = 10
        Me.navDashboard.FillColor = System.Drawing.Color.Transparent
        Me.navDashboard.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navDashboard.HoverState.ForeColor = System.Drawing.Color.White
        Me.navDashboard.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navDashboard.Text = "   لوحة التحكم"
        Me.navDashboard.Image = Global.WindowsApp1.My.Resources.Resources.market_analysis
        Me.navDashboard.ImageSize = New System.Drawing.Size(22, 22)
        Me.navDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navDashboard.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navDashboard.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navDashboard)

        ' navSales
        Me.navSales.Name = "navSales"
        Me.navSales.Size = New System.Drawing.Size(190, 42)
        Me.navSales.BorderRadius = 10
        Me.navSales.FillColor = System.Drawing.Color.Transparent
        Me.navSales.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navSales.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navSales.HoverState.ForeColor = System.Drawing.Color.White
        Me.navSales.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navSales.Text = "   المبيعات والصالة"
        Me.navSales.Image = Global.WindowsApp1.My.Resources.Resources.cart__1_
        Me.navSales.ImageSize = New System.Drawing.Size(22, 22)
        Me.navSales.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navSales.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navSales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navSales)

        ' navSystem
        Me.navSystem.Name = "navSystem"
        Me.navSystem.Size = New System.Drawing.Size(190, 42)
        Me.navSystem.BorderRadius = 10
        Me.navSystem.FillColor = System.Drawing.Color.Transparent
        Me.navSystem.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navSystem.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navSystem.HoverState.ForeColor = System.Drawing.Color.White
        Me.navSystem.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navSystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navSystem.Text = "   بيانات المنيو والنظام"
        Me.navSystem.Image = Global.WindowsApp1.My.Resources.Resources.category
        Me.navSystem.ImageSize = New System.Drawing.Size(22, 22)
        Me.navSystem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navSystem.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navSystem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navSystem)

        ' navInventory
        Me.navInventory.Name = "navInventory"
        Me.navInventory.Size = New System.Drawing.Size(190, 42)
        Me.navInventory.BorderRadius = 10
        Me.navInventory.FillColor = System.Drawing.Color.Transparent
        Me.navInventory.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navInventory.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navInventory.HoverState.ForeColor = System.Drawing.Color.White
        Me.navInventory.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navInventory.Text = "   المخازن والريسيبي"
        Me.navInventory.Image = Global.WindowsApp1.My.Resources.Resources.stock
        Me.navInventory.ImageSize = New System.Drawing.Size(22, 22)
        Me.navInventory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navInventory.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navInventory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navInventory)

        ' navPurchases
        Me.navPurchases.Name = "navPurchases"
        Me.navPurchases.Size = New System.Drawing.Size(190, 42)
        Me.navPurchases.BorderRadius = 10
        Me.navPurchases.FillColor = System.Drawing.Color.Transparent
        Me.navPurchases.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navPurchases.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navPurchases.HoverState.ForeColor = System.Drawing.Color.White
        Me.navPurchases.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navPurchases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navPurchases.Text = "   المشتريات والتوريدات"
        Me.navPurchases.Image = Global.WindowsApp1.My.Resources.Resources.shopping
        Me.navPurchases.ImageSize = New System.Drawing.Size(22, 22)
        Me.navPurchases.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navPurchases.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navPurchases.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navPurchases)

        ' navCustomers
        Me.navCustomers.Name = "navCustomers"
        Me.navCustomers.Size = New System.Drawing.Size(190, 42)
        Me.navCustomers.BorderRadius = 10
        Me.navCustomers.FillColor = System.Drawing.Color.Transparent
        Me.navCustomers.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navCustomers.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navCustomers.HoverState.ForeColor = System.Drawing.Color.White
        Me.navCustomers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navCustomers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navCustomers.Text = "   العملاء والحسابات"
        Me.navCustomers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.navCustomers.ImageSize = New System.Drawing.Size(22, 22)
        Me.navCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navCustomers.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navCustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navCustomers)

        ' navSuppliers
        Me.navSuppliers.Name = "navSuppliers"
        Me.navSuppliers.Size = New System.Drawing.Size(190, 42)
        Me.navSuppliers.BorderRadius = 10
        Me.navSuppliers.FillColor = System.Drawing.Color.Transparent
        Me.navSuppliers.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navSuppliers.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navSuppliers.HoverState.ForeColor = System.Drawing.Color.White
        Me.navSuppliers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navSuppliers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navSuppliers.Text = "   الموردين والشركات"
        Me.navSuppliers.Image = Global.WindowsApp1.My.Resources.Resources.supplier
        Me.navSuppliers.ImageSize = New System.Drawing.Size(22, 22)
        Me.navSuppliers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navSuppliers.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navSuppliers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navSuppliers)

        ' navTreasury
        Me.navTreasury.Name = "navTreasury"
        Me.navTreasury.Size = New System.Drawing.Size(190, 42)
        Me.navTreasury.BorderRadius = 10
        Me.navTreasury.FillColor = System.Drawing.Color.Transparent
        Me.navTreasury.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navTreasury.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navTreasury.HoverState.ForeColor = System.Drawing.Color.White
        Me.navTreasury.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navTreasury.Text = "   الخزينة والسيولة"
        Me.navTreasury.Image = Global.WindowsApp1.My.Resources.Resources.treasury
        Me.navTreasury.ImageSize = New System.Drawing.Size(22, 22)
        Me.navTreasury.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navTreasury.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navTreasury.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navTreasury)

        ' navExpenses
        Me.navExpenses.Name = "navExpenses"
        Me.navExpenses.Size = New System.Drawing.Size(190, 42)
        Me.navExpenses.BorderRadius = 10
        Me.navExpenses.FillColor = System.Drawing.Color.Transparent
        Me.navExpenses.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navExpenses.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navExpenses.HoverState.ForeColor = System.Drawing.Color.White
        Me.navExpenses.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navExpenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navExpenses.Text = "   المصروفات اليومية"
        Me.navExpenses.Image = Global.WindowsApp1.My.Resources.Resources.discount
        Me.navExpenses.ImageSize = New System.Drawing.Size(22, 22)
        Me.navExpenses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navExpenses.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navExpenses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navExpenses)

        ' navEmployees
        Me.navEmployees.Name = "navEmployees"
        Me.navEmployees.Size = New System.Drawing.Size(190, 42)
        Me.navEmployees.BorderRadius = 10
        Me.navEmployees.FillColor = System.Drawing.Color.Transparent
        Me.navEmployees.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navEmployees.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navEmployees.HoverState.ForeColor = System.Drawing.Color.White
        Me.navEmployees.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navEmployees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navEmployees.Text = "   الموظفين والرواتب"
        Me.navEmployees.Image = Global.WindowsApp1.My.Resources.Resources.staff
        Me.navEmployees.ImageSize = New System.Drawing.Size(22, 22)
        Me.navEmployees.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navEmployees.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navEmployees.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navEmployees)

        ' navUsers
        Me.navUsers.Name = "navUsers"
        Me.navUsers.Size = New System.Drawing.Size(190, 42)
        Me.navUsers.BorderRadius = 10
        Me.navUsers.FillColor = System.Drawing.Color.Transparent
        Me.navUsers.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navUsers.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navUsers.HoverState.ForeColor = System.Drawing.Color.White
        Me.navUsers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navUsers.Text = "   المستخدمين والأمان"
        Me.navUsers.Image = Global.WindowsApp1.My.Resources.Resources.lock
        Me.navUsers.ImageSize = New System.Drawing.Size(22, 22)
        Me.navUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navUsers.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navUsers)

        ' navSettings
        Me.navSettings.Name = "navSettings"
        Me.navSettings.Size = New System.Drawing.Size(190, 42)
        Me.navSettings.BorderRadius = 10
        Me.navSettings.FillColor = System.Drawing.Color.Transparent
        Me.navSettings.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219)
        Me.navSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.navSettings.HoverState.ForeColor = System.Drawing.Color.White
        Me.navSettings.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.navSettings.Text = "   الإعدادات والنسخ"
        Me.navSettings.Image = Global.WindowsApp1.My.Resources.Resources.settings__3_
        Me.navSettings.ImageSize = New System.Drawing.Size(22, 22)
        Me.navSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navSettings.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpNav.Controls.Add(Me.navSettings)

        ' =================== statusStripMain ===================
        Me.statusStripMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.statusStripMain.Height = 28
        Me.statusStripMain.BackColor = System.Drawing.Color.FromArgb(13, 16, 23)
        Me.statusStripMain.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.statusStripMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.statusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusDb, Me.sepStatus1, Me.lblStatusUser, Me.sepStatus2, Me.lblStatusRole, Me.sepStatus3, Me.lblStatusBranch, Me.sepStatus4, Me.lblStatusShift, Me.sepStatus5, Me.lblStatusDateTime, Me.sepStatus6, Me.lblStatusVersion})
        Me.lblStatusDb.Text = "قاعدة البيانات: متصل ولحظي"
        Me.sepStatus1.Text = " | "
        Me.lblStatusUser.Text = "المستخدم: المدير العام"
        Me.sepStatus2.Text = " | "
        Me.lblStatusRole.Text = "الصلاحية: مدير نظام"
        Me.sepStatus3.Text = " | "
        Me.lblStatusBranch.Text = "الفرع: الفرع الرئيسي"
        Me.sepStatus4.Text = " | "
        Me.lblStatusShift.Text = "الوردية: وردية الصباح"
        Me.sepStatus5.Text = " | "
        Me.lblStatusDateTime.Text = "التاريخ والوقت"
        Me.sepStatus6.Text = " | "
        Me.lblStatusVersion.Text = "النسخة: v1.2.5 PRO"

        ' =================== pnlMainContainer ===================
        Me.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(11, 14, 20)
        Me.pnlMainContainer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlMainContainer.Controls.Add(Me.viewDashboard)
        Me.pnlMainContainer.Controls.Add(Me.viewSettings)
        Me.pnlMainContainer.Controls.Add(Me.viewUsers)
        Me.pnlMainContainer.Controls.Add(Me.viewEmployees)
        Me.pnlMainContainer.Controls.Add(Me.viewExpenses)
        Me.pnlMainContainer.Controls.Add(Me.viewTreasury)
        Me.pnlMainContainer.Controls.Add(Me.viewSuppliers)
        Me.pnlMainContainer.Controls.Add(Me.viewCustomers)
        Me.pnlMainContainer.Controls.Add(Me.viewPurchases)
        Me.pnlMainContainer.Controls.Add(Me.viewInventory)
        Me.pnlMainContainer.Controls.Add(Me.viewSystem)
        Me.pnlMainContainer.Controls.Add(Me.viewSales)

        ' =================== viewDashboard ===================
        Me.viewDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewDashboard.AutoScroll = True
        Me.viewDashboard.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewDashboard.Controls.Add(Me.pnlDashboardBody)
        Me.viewDashboard.Controls.Add(Me.pnlWelcome)

        ' pnlWelcome
        Me.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlWelcome.Height = 65
        Me.pnlWelcome.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlWelcome.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlWelcome.Controls.Add(Me.lblWelcomeGreeting)
        Me.pnlWelcome.Controls.Add(Me.lblWelcomeSub)
        Me.pnlWelcome.Controls.Add(Me.lblShiftDuration)
        Me.pnlWelcome.Controls.Add(Me.btnRefreshDashboard)

        Me.lblWelcomeGreeting.AutoSize = True
        Me.lblWelcomeGreeting.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblWelcomeGreeting.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblWelcomeGreeting.ForeColor = System.Drawing.Color.White
        Me.lblWelcomeGreeting.Text = "صباح الخير، المدير العام"
        Me.lblWelcomeGreeting.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblWelcomeSub.AutoSize = True
        Me.lblWelcomeSub.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblWelcomeSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblWelcomeSub.Text = "لوحة المؤشرات والعمليات اليومية لنظام نقاط البيع"
        Me.lblWelcomeSub.Padding = New System.Windows.Forms.Padding(0, 5, 20, 0)
        Me.lblWelcomeSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnRefreshDashboard.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnRefreshDashboard.Width = 145
        Me.btnRefreshDashboard.BorderRadius = 8
        Me.btnRefreshDashboard.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnRefreshDashboard.ForeColor = System.Drawing.Color.White
        Me.btnRefreshDashboard.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshDashboard.Text = "  تحديث البيانات"
        Me.btnRefreshDashboard.Image = Global.WindowsApp1.My.Resources.Resources.sync
        Me.btnRefreshDashboard.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnRefreshDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnRefreshDashboard.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnRefreshDashboard.Cursor = System.Windows.Forms.Cursors.Hand

        Me.lblShiftDuration.AutoSize = True
        Me.lblShiftDuration.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblShiftDuration.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblShiftDuration.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153)
        Me.lblShiftDuration.Text = "مدة الوردية: 02:51:30"
        Me.lblShiftDuration.Padding = New System.Windows.Forms.Padding(15, 8, 15, 0)
        Me.lblShiftDuration.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' pnlDashboardBody
        Me.pnlDashboardBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDashboardBody.AutoScroll = True
        Me.pnlDashboardBody.Padding = New System.Windows.Forms.Padding(20, 0, 20, 20)
        Me.pnlDashboardBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlDashboardBody.Controls.Add(Me.tlpMainContent)
        Me.pnlDashboardBody.Controls.Add(Me.tlpStats)
        Me.pnlDashboardBody.Controls.Add(Me.pnlQuickButtons)

        ' pnlQuickButtons
        Me.pnlQuickButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlQuickButtons.Height = 90
        Me.pnlQuickButtons.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlQuickButtons.Controls.Add(Me.tlpQuickBtns)
        Me.pnlQuickButtons.Controls.Add(Me.lblQuickTitle)
        Me.lblQuickTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblQuickTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQuickTitle.ForeColor = System.Drawing.Color.White
        Me.lblQuickTitle.Text = "عمليات الوصول السريع:"
        Me.lblQuickTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblQuickTitle.Height = 25

        Me.tlpQuickBtns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpQuickBtns.ColumnCount = 4
        Me.tlpQuickBtns.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tlpQuickBtns.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpQuickBtns.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpQuickBtns.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpQuickBtns.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpQuickBtns.Controls.Add(Me.btnQuickPOS, 0, 0)
        Me.tlpQuickBtns.Controls.Add(Me.btnQuickProducts, 1, 0)
        Me.tlpQuickBtns.Controls.Add(Me.btnQuickCustomers, 2, 0)
        Me.tlpQuickBtns.Controls.Add(Me.btnQuickBackup, 3, 0)

        Me.btnQuickPOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuickPOS.BorderRadius = 10
        Me.btnQuickPOS.BorderThickness = 1
        Me.btnQuickPOS.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnQuickPOS.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnQuickPOS.ForeColor = System.Drawing.Color.White
        Me.btnQuickPOS.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnQuickPOS.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnQuickPOS.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnQuickPOS.Text = "  شاشة البيع (كاشير F1)"
        Me.btnQuickPOS.Image = Global.WindowsApp1.My.Resources.Resources.cart__1_
        Me.btnQuickPOS.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnQuickPOS.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnQuickPOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnQuickPOS.Margin = New System.Windows.Forms.Padding(5)
        Me.btnQuickPOS.Cursor = System.Windows.Forms.Cursors.Hand

        Me.btnQuickProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuickProducts.BorderRadius = 10
        Me.btnQuickProducts.BorderThickness = 1
        Me.btnQuickProducts.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnQuickProducts.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnQuickProducts.ForeColor = System.Drawing.Color.White
        Me.btnQuickProducts.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnQuickProducts.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnQuickProducts.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnQuickProducts.Text = "  قائمة الأصناف (F2)"
        Me.btnQuickProducts.Image = Global.WindowsApp1.My.Resources.Resources.products
        Me.btnQuickProducts.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnQuickProducts.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnQuickProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnQuickProducts.Margin = New System.Windows.Forms.Padding(5)
        Me.btnQuickProducts.Cursor = System.Windows.Forms.Cursors.Hand

        Me.btnQuickCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuickCustomers.BorderRadius = 10
        Me.btnQuickCustomers.BorderThickness = 1
        Me.btnQuickCustomers.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnQuickCustomers.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnQuickCustomers.ForeColor = System.Drawing.Color.White
        Me.btnQuickCustomers.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnQuickCustomers.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnQuickCustomers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnQuickCustomers.Text = "  دليل العملاء (F3)"
        Me.btnQuickCustomers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.btnQuickCustomers.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnQuickCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnQuickCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnQuickCustomers.Margin = New System.Windows.Forms.Padding(5)
        Me.btnQuickCustomers.Cursor = System.Windows.Forms.Cursors.Hand

        Me.btnQuickBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuickBackup.BorderRadius = 10
        Me.btnQuickBackup.BorderThickness = 1
        Me.btnQuickBackup.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnQuickBackup.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnQuickBackup.ForeColor = System.Drawing.Color.White
        Me.btnQuickBackup.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnQuickBackup.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnQuickBackup.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnQuickBackup.Text = "  النسخ الاحتياطي (F4)"
        Me.btnQuickBackup.Image = Global.WindowsApp1.My.Resources.Resources.backup
        Me.btnQuickBackup.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnQuickBackup.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnQuickBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnQuickBackup.Margin = New System.Windows.Forms.Padding(5)
        Me.btnQuickBackup.Cursor = System.Windows.Forms.Cursors.Hand

        ' =================== tlpStats ===================
        Me.tlpStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpStats.Height = 115
        Me.tlpStats.ColumnCount = 6
        Me.tlpStats.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
        Me.tlpStats.Controls.Add(Me.cardSales, 0, 0)
        Me.tlpStats.Controls.Add(Me.cardPurchases, 1, 0)
        Me.tlpStats.Controls.Add(Me.cardProfit, 2, 0)
        Me.tlpStats.Controls.Add(Me.cardProducts, 3, 0)
        Me.tlpStats.Controls.Add(Me.cardCustomers, 4, 0)
        Me.tlpStats.Controls.Add(Me.cardSuppliers, 5, 0)
        Me.tlpStats.Margin = New System.Windows.Forms.Padding(0, 10, 0, 10)

        ' cardSales
        Me.cardSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardSales.BorderRadius = 12
        Me.cardSales.BorderThickness = 1
        Me.cardSales.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardSales.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.cardSales.Margin = New System.Windows.Forms.Padding(5)
        Me.cardSales.Padding = New System.Windows.Forms.Padding(10)
        Me.cardSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardSales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardSales.Controls.Add(Me.lblCardSalesSub)
        Me.cardSales.Controls.Add(Me.lblCardSalesVal)
        Me.cardSales.Controls.Add(Me.lblCardSalesTitle)
        Me.cardSales.Controls.Add(Me.picCardSales)
        Me.picCardSales.Dock = System.Windows.Forms.DockStyle.Left
        Me.picCardSales.Size = New System.Drawing.Size(28, 28)
        Me.picCardSales.Image = Global.WindowsApp1.My.Resources.Resources.cart__1_
        Me.picCardSales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardSales.Visible = True
        Me.lblCardSalesTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardSalesTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Me.lblCardSalesTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblCardSalesTitle.Text = "مبيعات اليوم"
        Me.lblCardSalesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardSalesVal.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardSalesVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardSalesVal.ForeColor = System.Drawing.Color.White
        Me.lblCardSalesVal.Text = "0.00 جنية"
        Me.lblCardSalesVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardSalesSub.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardSalesSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.lblCardSalesSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCardSalesSub.Text = "0 فاتورة اليوم"
        Me.lblCardSalesSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' cardPurchases
        Me.cardPurchases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardPurchases.BorderRadius = 12
        Me.cardPurchases.BorderThickness = 1
        Me.cardPurchases.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardPurchases.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.cardPurchases.Margin = New System.Windows.Forms.Padding(5)
        Me.cardPurchases.Padding = New System.Windows.Forms.Padding(10)
        Me.cardPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardPurchases.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardPurchases.Controls.Add(Me.lblCardPurchasesSub)
        Me.cardPurchases.Controls.Add(Me.lblCardPurchasesVal)
        Me.cardPurchases.Controls.Add(Me.lblCardPurchasesTitle)
        Me.cardPurchases.Controls.Add(Me.picCardPurchases)
        Me.picCardPurchases.Dock = System.Windows.Forms.DockStyle.Left
        Me.picCardPurchases.Size = New System.Drawing.Size(28, 28)
        Me.picCardPurchases.Image = Global.WindowsApp1.My.Resources.Resources.shopping
        Me.picCardPurchases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardPurchases.Visible = True
        Me.lblCardPurchasesTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardPurchasesTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Me.lblCardPurchasesTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblCardPurchasesTitle.Text = "مشتريات اليوم"
        Me.lblCardPurchasesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardPurchasesVal.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardPurchasesVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardPurchasesVal.ForeColor = System.Drawing.Color.White
        Me.lblCardPurchasesVal.Text = "0.00 جنية"
        Me.lblCardPurchasesVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardPurchasesSub.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardPurchasesSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.lblCardPurchasesSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCardPurchasesSub.Text = "0 فاتورة توريد"
        Me.lblCardPurchasesSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' cardProfit
        Me.cardProfit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardProfit.BorderRadius = 12
        Me.cardProfit.BorderThickness = 1
        Me.cardProfit.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardProfit.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.cardProfit.Margin = New System.Windows.Forms.Padding(5)
        Me.cardProfit.Padding = New System.Windows.Forms.Padding(10)
        Me.cardProfit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardProfit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardProfit.Controls.Add(Me.lblCardProfitSub)
        Me.cardProfit.Controls.Add(Me.lblCardProfitVal)
        Me.cardProfit.Controls.Add(Me.lblCardProfitTitle)
        Me.cardProfit.Controls.Add(Me.picCardProfit)
        Me.picCardProfit.Dock = System.Windows.Forms.DockStyle.Left
        Me.picCardProfit.Size = New System.Drawing.Size(28, 28)
        Me.picCardProfit.Image = Global.WindowsApp1.My.Resources.Resources.financial
        Me.picCardProfit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardProfit.Visible = True
        Me.lblCardProfitTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardProfitTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Me.lblCardProfitTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblCardProfitTitle.Text = "صافي الأرباح"
        Me.lblCardProfitTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardProfitVal.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardProfitVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardProfitVal.ForeColor = System.Drawing.Color.White
        Me.lblCardProfitVal.Text = "0.00 جنية"
        Me.lblCardProfitVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardProfitSub.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardProfitSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.lblCardProfitSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCardProfitSub.Text = "(المبيعات - المصروفات)"
        Me.lblCardProfitSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' cardProducts
        Me.cardProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardProducts.BorderRadius = 12
        Me.cardProducts.BorderThickness = 1
        Me.cardProducts.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardProducts.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.cardProducts.Margin = New System.Windows.Forms.Padding(5)
        Me.cardProducts.Padding = New System.Windows.Forms.Padding(10)
        Me.cardProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardProducts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardProducts.Controls.Add(Me.lblCardProductsSub)
        Me.cardProducts.Controls.Add(Me.lblCardProductsVal)
        Me.cardProducts.Controls.Add(Me.lblCardProductsTitle)
        Me.cardProducts.Controls.Add(Me.picCardProducts)
        Me.picCardProducts.Dock = System.Windows.Forms.DockStyle.Left
        Me.picCardProducts.Size = New System.Drawing.Size(28, 28)
        Me.picCardProducts.Image = Global.WindowsApp1.My.Resources.Resources.products
        Me.picCardProducts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardProducts.Visible = True
        Me.lblCardProductsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardProductsTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Me.lblCardProductsTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblCardProductsTitle.Text = "إجمالي الأصناف"
        Me.lblCardProductsTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardProductsVal.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardProductsVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardProductsVal.ForeColor = System.Drawing.Color.White
        Me.lblCardProductsVal.Text = "0"
        Me.lblCardProductsVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardProductsSub.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardProductsSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.lblCardProductsSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCardProductsSub.Text = "صنف مسجل بالنظام"
        Me.lblCardProductsSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' cardCustomers
        Me.cardCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardCustomers.BorderRadius = 12
        Me.cardCustomers.BorderThickness = 1
        Me.cardCustomers.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardCustomers.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.cardCustomers.Margin = New System.Windows.Forms.Padding(5)
        Me.cardCustomers.Padding = New System.Windows.Forms.Padding(10)
        Me.cardCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardCustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardCustomers.Controls.Add(Me.lblCardCustomersSub)
        Me.cardCustomers.Controls.Add(Me.lblCardCustomersVal)
        Me.cardCustomers.Controls.Add(Me.lblCardCustomersTitle)
        Me.cardCustomers.Controls.Add(Me.picCardCustomers)
        Me.picCardCustomers.Dock = System.Windows.Forms.DockStyle.Left
        Me.picCardCustomers.Size = New System.Drawing.Size(28, 28)
        Me.picCardCustomers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.picCardCustomers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardCustomers.Visible = True
        Me.lblCardCustomersTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardCustomersTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Me.lblCardCustomersTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblCardCustomersTitle.Text = "إجمالي العملاء"
        Me.lblCardCustomersTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardCustomersVal.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardCustomersVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardCustomersVal.ForeColor = System.Drawing.Color.White
        Me.lblCardCustomersVal.Text = "0"
        Me.lblCardCustomersVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardCustomersSub.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardCustomersSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.lblCardCustomersSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCardCustomersSub.Text = "عميل مسجل"
        Me.lblCardCustomersSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' cardSuppliers
        Me.cardSuppliers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardSuppliers.BorderRadius = 12
        Me.cardSuppliers.BorderThickness = 1
        Me.cardSuppliers.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardSuppliers.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.cardSuppliers.Margin = New System.Windows.Forms.Padding(5)
        Me.cardSuppliers.Padding = New System.Windows.Forms.Padding(10)
        Me.cardSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardSuppliers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersSub)
        Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersVal)
        Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersTitle)
        Me.cardSuppliers.Controls.Add(Me.picCardSuppliers)
        Me.picCardSuppliers.Dock = System.Windows.Forms.DockStyle.Left
        Me.picCardSuppliers.Size = New System.Drawing.Size(28, 28)
        Me.picCardSuppliers.Image = Global.WindowsApp1.My.Resources.Resources.supplier
        Me.picCardSuppliers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCardSuppliers.Visible = True
        Me.lblCardSuppliersTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardSuppliersTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Me.lblCardSuppliersTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblCardSuppliersTitle.Text = "إجمالي الموردين"
        Me.lblCardSuppliersTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardSuppliersVal.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardSuppliersVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardSuppliersVal.ForeColor = System.Drawing.Color.White
        Me.lblCardSuppliersVal.Text = "0"
        Me.lblCardSuppliersVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCardSuppliersSub.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardSuppliersSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.lblCardSuppliersSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCardSuppliersSub.Text = "مورد وشركة"
        Me.lblCardSuppliersSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' =================== tlpMainContent ===================
        Me.tlpMainContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpMainContent.Height = 360
        Me.tlpMainContent.ColumnCount = 2
        Me.tlpMainContent.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpMainContent.Controls.Add(Me.cardRecentInvoices, 0, 0)
        Me.tlpMainContent.Controls.Add(Me.cardAlerts, 1, 0)
        Me.tlpMainContent.Margin = New System.Windows.Forms.Padding(0, 10, 0, 10)

        ' cardRecentInvoices
        Me.cardRecentInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardRecentInvoices.BorderRadius = 12
        Me.cardRecentInvoices.BorderThickness = 1
        Me.cardRecentInvoices.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardRecentInvoices.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.cardRecentInvoices.Padding = New System.Windows.Forms.Padding(12)
        Me.cardRecentInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardRecentInvoices.Controls.Add(Me.dgvRecentInvoices)
        Me.cardRecentInvoices.Controls.Add(Me.pnlInvoicesHeader)
        Me.cardRecentInvoices.Margin = New System.Windows.Forms.Padding(5)

        ' pnlInvoicesHeader
        Me.pnlInvoicesHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInvoicesHeader.Height = 35
        Me.pnlInvoicesHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlInvoicesHeader.Controls.Add(Me.lblRecentInvoicesTitle)
        Me.pnlInvoicesHeader.Controls.Add(Me.btnViewAllInvoices)
        Me.lblRecentInvoicesTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblRecentInvoicesTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecentInvoicesTitle.ForeColor = System.Drawing.Color.White
        Me.lblRecentInvoicesTitle.Text = "آخر فواتير المبيعات الصادرة"
        Me.lblRecentInvoicesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnViewAllInvoices.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnViewAllInvoices.Width = 110
        Me.btnViewAllInvoices.BorderRadius = 6
        Me.btnViewAllInvoices.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnViewAllInvoices.ForeColor = System.Drawing.Color.White
        Me.btnViewAllInvoices.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.btnViewAllInvoices.Text = "عرض الكل ↗"
        Me.btnViewAllInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnViewAllInvoices.Cursor = System.Windows.Forms.Cursors.Hand

        ' dgvRecentInvoices
        Me.dgvRecentInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRecentInvoices.BackgroundColor = System.Drawing.Color.FromArgb(16, 21, 30)
        Me.dgvRecentInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRecentInvoices.AllowUserToAddRows = False
        Me.dgvRecentInvoices.AllowUserToDeleteRows = False
        Me.dgvRecentInvoices.ReadOnly = True
        Me.dgvRecentInvoices.RowHeadersVisible = False
        Me.dgvRecentInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecentInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvRecentInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInvNum, Me.colInvTime, Me.colInvCustomer, Me.colInvType, Me.colInvTotal, Me.colInvPayment})
        Me.colInvNum.HeaderText = "رقم الفاتورة"
        Me.colInvNum.Width = 90
        Me.colInvTime.HeaderText = "الوقت"
        Me.colInvTime.Width = 65
        Me.colInvCustomer.HeaderText = "العميل"
        Me.colInvCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colInvType.HeaderText = "النوع"
        Me.colInvType.Width = 75
        Me.colInvTotal.HeaderText = "الإجمالي"
        Me.colInvTotal.Width = 85
        Me.colInvPayment.HeaderText = "طريقة الدفع"
        Me.colInvPayment.Width = 85

        ' cardAlerts
        Me.cardAlerts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardAlerts.BorderRadius = 12
        Me.cardAlerts.BorderThickness = 1
        Me.cardAlerts.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardAlerts.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.cardAlerts.Padding = New System.Windows.Forms.Padding(12)
        Me.cardAlerts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardAlerts.Controls.Add(Me.pnlAlertsContainer)
        Me.cardAlerts.Controls.Add(Me.pnlAlertsHeader)
        Me.cardAlerts.Margin = New System.Windows.Forms.Padding(5)

        ' pnlAlertsHeader
        Me.pnlAlertsHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAlertsHeader.Height = 35
        Me.pnlAlertsHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlAlertsHeader.Controls.Add(Me.lblAlertsTitle)
        Me.lblAlertsTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblAlertsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlertsTitle.ForeColor = System.Drawing.Color.White
        Me.lblAlertsTitle.Text = "تنبيهات وحالة النظام"
        Me.lblAlertsTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' pnlAlertsContainer
        Me.pnlAlertsContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAlertsContainer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlAlertsContainer.Controls.Add(Me.cardAlertBackup)
        Me.pnlAlertsContainer.Controls.Add(Me.cardAlertShift)
        Me.pnlAlertsContainer.Controls.Add(Me.cardAlertStock)

        ' cardAlertStock
        Me.cardAlertStock.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAlertStock.Height = 70
        Me.cardAlertStock.BorderRadius = 8
        Me.cardAlertStock.BorderThickness = 1
        Me.cardAlertStock.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardAlertStock.FillColor = System.Drawing.Color.FromArgb(16, 21, 30)
        Me.cardAlertStock.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.cardAlertStock.Padding = New System.Windows.Forms.Padding(10)
        Me.cardAlertStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardAlertStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardAlertStock.Controls.Add(Me.lblAlertStockDesc)
        Me.cardAlertStock.Controls.Add(Me.lblAlertStockTitle)
        Me.lblAlertStockTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlertStockTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlertStockTitle.ForeColor = System.Drawing.Color.White
        Me.lblAlertStockTitle.Text = "المخزون سليم"
        Me.lblAlertStockTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAlertStockDesc.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlertStockDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblAlertStockDesc.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblAlertStockDesc.Text = "لا توجد أصناف تحت حد الطلب الأدنى حالياً"
        Me.lblAlertStockDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' cardAlertShift
        Me.cardAlertShift.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAlertShift.Height = 70
        Me.cardAlertShift.BorderRadius = 8
        Me.cardAlertShift.BorderThickness = 1
        Me.cardAlertShift.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardAlertShift.FillColor = System.Drawing.Color.FromArgb(16, 21, 30)
        Me.cardAlertShift.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.cardAlertShift.Padding = New System.Windows.Forms.Padding(10)
        Me.cardAlertShift.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardAlertShift.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardAlertShift.Controls.Add(Me.lblAlertShiftDesc)
        Me.cardAlertShift.Controls.Add(Me.lblAlertShiftTitle)
        Me.lblAlertShiftTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlertShiftTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlertShiftTitle.ForeColor = System.Drawing.Color.White
        Me.lblAlertShiftTitle.Text = "الوردية النشطة"
        Me.lblAlertShiftTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAlertShiftDesc.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlertShiftDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblAlertShiftDesc.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblAlertShiftDesc.Text = "الوردية مفتوحة وتعمل بكفاءة"
        Me.lblAlertShiftDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' cardAlertBackup
        Me.cardAlertBackup.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAlertBackup.Height = 70
        Me.cardAlertBackup.BorderRadius = 8
        Me.cardAlertBackup.BorderThickness = 1
        Me.cardAlertBackup.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.cardAlertBackup.FillColor = System.Drawing.Color.FromArgb(16, 21, 30)
        Me.cardAlertBackup.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.cardAlertBackup.Padding = New System.Windows.Forms.Padding(10)
        Me.cardAlertBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cardAlertBackup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardAlertBackup.Controls.Add(Me.lblAlertBackupDesc)
        Me.cardAlertBackup.Controls.Add(Me.lblAlertBackupTitle)
        Me.lblAlertBackupTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlertBackupTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlertBackupTitle.ForeColor = System.Drawing.Color.White
        Me.lblAlertBackupTitle.Text = "النسخ الاحتياطي"
        Me.lblAlertBackupTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAlertBackupDesc.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlertBackupDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblAlertBackupDesc.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblAlertBackupDesc.Text = "النظام مؤمن بنسخ احتياطي مجدول"
        Me.lblAlertBackupDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' =================== viewSales ===================
        Me.viewSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewSales.AutoScroll = True
        Me.viewSales.Padding = New System.Windows.Forms.Padding(20)
        Me.viewSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewSales.Controls.Add(Me.flpSales)
        Me.viewSales.Controls.Add(Me.pnlHeaderSales)

        ' pnlHeaderSales
        Me.pnlHeaderSales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderSales.Height = 60
        Me.pnlHeaderSales.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderSales.Controls.Add(Me.btnBackSales)
        Me.pnlHeaderSales.Controls.Add(Me.lblDescSales)
        Me.pnlHeaderSales.Controls.Add(Me.lblTitleSales)
        Me.pnlHeaderSales.Controls.Add(Me.picHeaderSales)

        ' picHeaderSales
        Me.picHeaderSales.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderSales.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderSales.Image = Global.WindowsApp1.My.Resources.Resources.cart__1_
        Me.picHeaderSales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleSales.AutoSize = True
        Me.lblTitleSales.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleSales.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleSales.ForeColor = System.Drawing.Color.White
        Me.lblTitleSales.Text = "قسم المبيعات وإدارة الصالة"
        Me.lblTitleSales.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescSales.AutoSize = True
        Me.lblDescSales.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescSales.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescSales.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescSales.Text = "نظام الكاشير السريع، المطبخ KDS، الطاولات والحجوزات، المرتجعات وتقارير المبيعات"
        Me.lblDescSales.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackSales.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackSales.Width = 145
        Me.btnBackSales.BorderRadius = 8
        Me.btnBackSales.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackSales.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackSales.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackSales.Text = "  العودة للرئيسية"
        Me.btnBackSales.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackSales.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackSales.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackSales.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpSales
        Me.flpSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpSales.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpSales.WrapContents = True
        Me.flpSales.AutoScroll = True
        Me.flpSales.Padding = New System.Windows.Forms.Padding(10)
        Me.flpSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnfrmPOS
        Me.btnfrmPOS.Name = "btnfrmPOS"
        Me.btnfrmPOS.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmPOS.BorderRadius = 12
        Me.btnfrmPOS.BorderThickness = 1
        Me.btnfrmPOS.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmPOS.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmPOS.ForeColor = System.Drawing.Color.White
        Me.btnfrmPOS.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmPOS.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmPOS.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmPOS.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmPOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmPOS.Text = "شاشة البيع الكاشير (POS F1)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "طلبات الصالة والدليفري والتيك أواي"
        Me.btnfrmPOS.Image = Global.WindowsApp1.My.Resources.Resources.cart__1_
        Me.btnfrmPOS.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmPOS.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmPOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmPOS.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmPOS.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmPOS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSales.Controls.Add(Me.btnfrmPOS)

        ' btnSalesReturns
        Me.btnSalesReturns.Name = "btnSalesReturns"
        Me.btnSalesReturns.Size = New System.Drawing.Size(340, 95)
        Me.btnSalesReturns.BorderRadius = 12
        Me.btnSalesReturns.BorderThickness = 1
        Me.btnSalesReturns.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnSalesReturns.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnSalesReturns.ForeColor = System.Drawing.Color.White
        Me.btnSalesReturns.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnSalesReturns.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnSalesReturns.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnSalesReturns.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnSalesReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnSalesReturns.Text = "مرتجع المبيعات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "استرجاع واستبدال الفواتير والأصناف"
        Me.btnSalesReturns.Image = Global.WindowsApp1.My.Resources.Resources.exchange__1_
        Me.btnSalesReturns.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnSalesReturns.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSalesReturns.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSalesReturns.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnSalesReturns.Margin = New System.Windows.Forms.Padding(8)
        Me.btnSalesReturns.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSales.Controls.Add(Me.btnSalesReturns)

        ' btnFrmSalesReport
        Me.btnFrmSalesReport.Name = "btnFrmSalesReport"
        Me.btnFrmSalesReport.Size = New System.Drawing.Size(340, 95)
        Me.btnFrmSalesReport.BorderRadius = 12
        Me.btnFrmSalesReport.BorderThickness = 1
        Me.btnFrmSalesReport.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnFrmSalesReport.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnFrmSalesReport.ForeColor = System.Drawing.Color.White
        Me.btnFrmSalesReport.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnFrmSalesReport.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnFrmSalesReport.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnFrmSalesReport.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFrmSalesReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnFrmSalesReport.Text = "تقارير المبيعات والأرباح" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تحليل المبيعات والأصناف الأكثر طلباً"
        Me.btnFrmSalesReport.Image = Global.WindowsApp1.My.Resources.Resources.report
        Me.btnFrmSalesReport.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnFrmSalesReport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnFrmSalesReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnFrmSalesReport.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnFrmSalesReport.Margin = New System.Windows.Forms.Padding(8)
        Me.btnFrmSalesReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSales.Controls.Add(Me.btnFrmSalesReport)

        ' btnFrmDriverReport
        Me.btnFrmDriverReport.Name = "btnFrmDriverReport"
        Me.btnFrmDriverReport.Size = New System.Drawing.Size(340, 95)
        Me.btnFrmDriverReport.BorderRadius = 12
        Me.btnFrmDriverReport.BorderThickness = 1
        Me.btnFrmDriverReport.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnFrmDriverReport.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnFrmDriverReport.ForeColor = System.Drawing.Color.White
        Me.btnFrmDriverReport.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnFrmDriverReport.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnFrmDriverReport.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnFrmDriverReport.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFrmDriverReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnFrmDriverReport.Text = "تقارير طيارين الديليفري" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "حسابات وأوردرات وعمولات الطيارين"
        Me.btnFrmDriverReport.Image = Global.WindowsApp1.My.Resources.Resources.delivery_bike__1_
        Me.btnFrmDriverReport.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnFrmDriverReport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnFrmDriverReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnFrmDriverReport.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnFrmDriverReport.Margin = New System.Windows.Forms.Padding(8)
        Me.btnFrmDriverReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSales.Controls.Add(Me.btnFrmDriverReport)

        ' btnKds
        Me.btnKds.Name = "btnKds"
        Me.btnKds.Size = New System.Drawing.Size(340, 95)
        Me.btnKds.BorderRadius = 12
        Me.btnKds.BorderThickness = 1
        Me.btnKds.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnKds.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnKds.ForeColor = System.Drawing.Color.White
        Me.btnKds.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnKds.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnKds.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnKds.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnKds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnKds.Text = "شاشة عرض المطبخ (KDS)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تحضير الطلبات في المطبخ لحظياً"
        Me.btnKds.Image = Global.WindowsApp1.My.Resources.Resources.dining_room
        Me.btnKds.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnKds.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnKds.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnKds.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnKds.Margin = New System.Windows.Forms.Padding(8)
        Me.btnKds.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSales.Controls.Add(Me.btnKds)

        ' btnWaste
        Me.btnWaste.Name = "btnWaste"
        Me.btnWaste.Size = New System.Drawing.Size(340, 95)
        Me.btnWaste.BorderRadius = 12
        Me.btnWaste.BorderThickness = 1
        Me.btnWaste.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnWaste.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnWaste.ForeColor = System.Drawing.Color.White
        Me.btnWaste.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnWaste.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnWaste.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnWaste.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnWaste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnWaste.Text = "هالك وتالف المطبخ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تسجيل الهدر والتالف أثناء التشغيل"
        Me.btnWaste.Image = Global.WindowsApp1.My.Resources.Resources.bin
        Me.btnWaste.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnWaste.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnWaste.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnWaste.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnWaste.Margin = New System.Windows.Forms.Padding(8)
        Me.btnWaste.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSales.Controls.Add(Me.btnWaste)

        ' btnRes
        Me.btnRes.Name = "btnRes"
        Me.btnRes.Size = New System.Drawing.Size(340, 95)
        Me.btnRes.BorderRadius = 12
        Me.btnRes.BorderThickness = 1
        Me.btnRes.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnRes.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnRes.ForeColor = System.Drawing.Color.White
        Me.btnRes.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnRes.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnRes.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnRes.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnRes.Text = "طاولات وحجوزات الصالة" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "متابعة الطاولات الشاغرة والمحجوزة"
        Me.btnRes.Image = Global.WindowsApp1.My.Resources.Resources.round_table
        Me.btnRes.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnRes.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnRes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnRes.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnRes.Margin = New System.Windows.Forms.Padding(8)
        Me.btnRes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSales.Controls.Add(Me.btnRes)

        ' =================== viewSystem ===================
        Me.viewSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewSystem.AutoScroll = True
        Me.viewSystem.Padding = New System.Windows.Forms.Padding(20)
        Me.viewSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewSystem.Controls.Add(Me.flpSystem)
        Me.viewSystem.Controls.Add(Me.pnlHeaderSystem)

        ' pnlHeaderSystem
        Me.pnlHeaderSystem.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderSystem.Height = 60
        Me.pnlHeaderSystem.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderSystem.Controls.Add(Me.btnBackSystem)
        Me.pnlHeaderSystem.Controls.Add(Me.lblDescSystem)
        Me.pnlHeaderSystem.Controls.Add(Me.lblTitleSystem)
        Me.pnlHeaderSystem.Controls.Add(Me.picHeaderSystem)

        ' picHeaderSystem
        Me.picHeaderSystem.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderSystem.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderSystem.Image = Global.WindowsApp1.My.Resources.Resources.category
        Me.picHeaderSystem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleSystem.AutoSize = True
        Me.lblTitleSystem.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleSystem.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleSystem.ForeColor = System.Drawing.Color.White
        Me.lblTitleSystem.Text = "قسم بيانات المنيو والنظام"
        Me.lblTitleSystem.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescSystem.AutoSize = True
        Me.lblDescSystem.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescSystem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescSystem.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescSystem.Text = "تعريف الفئات، الوجبات، الأسعار، الإضافات، تعليقات المطبخ ومناطق التوصيل"
        Me.lblDescSystem.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackSystem.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackSystem.Width = 145
        Me.btnBackSystem.BorderRadius = 8
        Me.btnBackSystem.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackSystem.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackSystem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackSystem.Text = "  العودة للرئيسية"
        Me.btnBackSystem.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackSystem.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackSystem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackSystem.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpSystem
        Me.flpSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpSystem.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpSystem.WrapContents = True
        Me.flpSystem.AutoScroll = True
        Me.flpSystem.Padding = New System.Windows.Forms.Padding(10)
        Me.flpSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnCategories
        Me.btnCategories.Name = "btnCategories"
        Me.btnCategories.Size = New System.Drawing.Size(340, 95)
        Me.btnCategories.BorderRadius = 12
        Me.btnCategories.BorderThickness = 1
        Me.btnCategories.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnCategories.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnCategories.ForeColor = System.Drawing.Color.White
        Me.btnCategories.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnCategories.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnCategories.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnCategories.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCategories.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnCategories.Text = "تصنيفات المنيو" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "أقسام وقوائم الطعام والمشروبات"
        Me.btnCategories.Image = Global.WindowsApp1.My.Resources.Resources.category
        Me.btnCategories.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCategories.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnCategories.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnCategories.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnCategories.Margin = New System.Windows.Forms.Padding(8)
        Me.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnCategories)

        ' btnProducts
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Size = New System.Drawing.Size(340, 95)
        Me.btnProducts.BorderRadius = 12
        Me.btnProducts.BorderThickness = 1
        Me.btnProducts.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnProducts.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnProducts.ForeColor = System.Drawing.Color.White
        Me.btnProducts.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnProducts.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnProducts.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnProducts.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnProducts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnProducts.Text = "قائمة الأصناف والوجبات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "إضافة وتعديل الوجبات والأسعار"
        Me.btnProducts.Image = Global.WindowsApp1.My.Resources.Resources.products
        Me.btnProducts.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnProducts.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnProducts.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnProducts.Margin = New System.Windows.Forms.Padding(8)
        Me.btnProducts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnProducts)

        ' btnfrmProductSizes
        Me.btnfrmProductSizes.Name = "btnfrmProductSizes"
        Me.btnfrmProductSizes.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmProductSizes.BorderRadius = 12
        Me.btnfrmProductSizes.BorderThickness = 1
        Me.btnfrmProductSizes.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmProductSizes.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmProductSizes.ForeColor = System.Drawing.Color.White
        Me.btnfrmProductSizes.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmProductSizes.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmProductSizes.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmProductSizes.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmProductSizes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmProductSizes.Text = "أحجام الأصناف والأسعار" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تعريف الأحجام والأسعار لكل صنف"
        Me.btnfrmProductSizes.Image = Global.WindowsApp1.My.Resources.Resources.options
        Me.btnfrmProductSizes.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmProductSizes.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmProductSizes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmProductSizes.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmProductSizes.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmProductSizes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnfrmProductSizes)

        ' btnfrmProductAddons
        Me.btnfrmProductAddons.Name = "btnfrmProductAddons"
        Me.btnfrmProductAddons.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmProductAddons.BorderRadius = 12
        Me.btnfrmProductAddons.BorderThickness = 1
        Me.btnfrmProductAddons.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmProductAddons.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmProductAddons.ForeColor = System.Drawing.Color.White
        Me.btnfrmProductAddons.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmProductAddons.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmProductAddons.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmProductAddons.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmProductAddons.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmProductAddons.Text = "إضافات ومشروبات الأصناف" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "إدارة الصوصات والإضافات الجانبية"
        Me.btnfrmProductAddons.Image = Global.WindowsApp1.My.Resources.Resources.diet
        Me.btnfrmProductAddons.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmProductAddons.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmProductAddons.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmProductAddons.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmProductAddons.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmProductAddons.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnfrmProductAddons)

        ' btnfrmKitchenComments
        Me.btnfrmKitchenComments.Name = "btnfrmKitchenComments"
        Me.btnfrmKitchenComments.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmKitchenComments.BorderRadius = 12
        Me.btnfrmKitchenComments.BorderThickness = 1
        Me.btnfrmKitchenComments.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmKitchenComments.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmKitchenComments.ForeColor = System.Drawing.Color.White
        Me.btnfrmKitchenComments.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmKitchenComments.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmKitchenComments.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmKitchenComments.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmKitchenComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmKitchenComments.Text = "تعليقات وملاحظات المطبخ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تعليمات وتفضيلات طهي الوجبات"
        Me.btnfrmKitchenComments.Image = Global.WindowsApp1.My.Resources.Resources.bubble_chat
        Me.btnfrmKitchenComments.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmKitchenComments.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmKitchenComments.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmKitchenComments.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmKitchenComments.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmKitchenComments.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnfrmKitchenComments)

        ' btnfrmDeliveryAreas
        Me.btnfrmDeliveryAreas.Name = "btnfrmDeliveryAreas"
        Me.btnfrmDeliveryAreas.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmDeliveryAreas.BorderRadius = 12
        Me.btnfrmDeliveryAreas.BorderThickness = 1
        Me.btnfrmDeliveryAreas.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmDeliveryAreas.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmDeliveryAreas.ForeColor = System.Drawing.Color.White
        Me.btnfrmDeliveryAreas.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmDeliveryAreas.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmDeliveryAreas.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmDeliveryAreas.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmDeliveryAreas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmDeliveryAreas.Text = "مناطق ورسوم التوصيل" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تحديد أسعار التوصيل ومناطق الخدمة"
        Me.btnfrmDeliveryAreas.Image = Global.WindowsApp1.My.Resources.Resources.location
        Me.btnfrmDeliveryAreas.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmDeliveryAreas.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmDeliveryAreas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmDeliveryAreas.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmDeliveryAreas.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmDeliveryAreas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnfrmDeliveryAreas)

        ' btnfrmDeliveryDrivers
        Me.btnfrmDeliveryDrivers.Name = "btnfrmDeliveryDrivers"
        Me.btnfrmDeliveryDrivers.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmDeliveryDrivers.BorderRadius = 12
        Me.btnfrmDeliveryDrivers.BorderThickness = 1
        Me.btnfrmDeliveryDrivers.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmDeliveryDrivers.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmDeliveryDrivers.ForeColor = System.Drawing.Color.White
        Me.btnfrmDeliveryDrivers.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmDeliveryDrivers.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmDeliveryDrivers.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmDeliveryDrivers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmDeliveryDrivers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmDeliveryDrivers.Text = "طيارين ومناديب التوصيل" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ملفات كباتن الديليفري والتواصل"
        Me.btnfrmDeliveryDrivers.Image = Global.WindowsApp1.My.Resources.Resources.delivery_bike
        Me.btnfrmDeliveryDrivers.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmDeliveryDrivers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmDeliveryDrivers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmDeliveryDrivers.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmDeliveryDrivers.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmDeliveryDrivers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnfrmDeliveryDrivers)

        ' btnfrmShifts
        Me.btnfrmShifts.Name = "btnfrmShifts"
        Me.btnfrmShifts.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmShifts.BorderRadius = 12
        Me.btnfrmShifts.BorderThickness = 1
        Me.btnfrmShifts.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmShifts.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmShifts.ForeColor = System.Drawing.Color.White
        Me.btnfrmShifts.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmShifts.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmShifts.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmShifts.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmShifts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmShifts.Text = "الورديات ومواعيد العمل" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تحديد مواعيد ورديات الصباح والمساء"
        Me.btnfrmShifts.Image = Global.WindowsApp1.My.Resources.Resources.scheduling
        Me.btnfrmShifts.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmShifts.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmShifts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmShifts.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmShifts.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmShifts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnfrmShifts)

        ' btnShiftReports
        Me.btnShiftReports.Name = "btnShiftReports"
        Me.btnShiftReports.Size = New System.Drawing.Size(340, 95)
        Me.btnShiftReports.BorderRadius = 12
        Me.btnShiftReports.BorderThickness = 1
        Me.btnShiftReports.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnShiftReports.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnShiftReports.ForeColor = System.Drawing.Color.White
        Me.btnShiftReports.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnShiftReports.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnShiftReports.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnShiftReports.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnShiftReports.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnShiftReports.Text = "تقارير الورديات والإقفال" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "كشوفات إغلاق الوردية والعجز والزيادة"
        Me.btnShiftReports.Image = Global.WindowsApp1.My.Resources.Resources.document
        Me.btnShiftReports.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnShiftReports.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnShiftReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnShiftReports.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnShiftReports.Margin = New System.Windows.Forms.Padding(8)
        Me.btnShiftReports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnShiftReports)

        ' btnfrmBranches
        Me.btnfrmBranches.Name = "btnfrmBranches"
        Me.btnfrmBranches.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmBranches.BorderRadius = 12
        Me.btnfrmBranches.BorderThickness = 1
        Me.btnfrmBranches.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmBranches.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmBranches.ForeColor = System.Drawing.Color.White
        Me.btnfrmBranches.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmBranches.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmBranches.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmBranches.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmBranches.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmBranches.Text = "فروع المطعم" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "إدارة بيانات الفروع ونقاط البيع"
        Me.btnfrmBranches.Image = Global.WindowsApp1.My.Resources.Resources.branch
        Me.btnfrmBranches.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmBranches.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmBranches.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmBranches.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmBranches.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmBranches.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSystem.Controls.Add(Me.btnfrmBranches)

        ' =================== viewInventory ===================
        Me.viewInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewInventory.AutoScroll = True
        Me.viewInventory.Padding = New System.Windows.Forms.Padding(20)
        Me.viewInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewInventory.Controls.Add(Me.flpInventory)
        Me.viewInventory.Controls.Add(Me.pnlHeaderInventory)

        ' pnlHeaderInventory
        Me.pnlHeaderInventory.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderInventory.Height = 60
        Me.pnlHeaderInventory.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderInventory.Controls.Add(Me.btnBackInventory)
        Me.pnlHeaderInventory.Controls.Add(Me.lblDescInventory)
        Me.pnlHeaderInventory.Controls.Add(Me.lblTitleInventory)
        Me.pnlHeaderInventory.Controls.Add(Me.picHeaderInventory)

        ' picHeaderInventory
        Me.picHeaderInventory.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderInventory.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderInventory.Image = Global.WindowsApp1.My.Resources.Resources.stock
        Me.picHeaderInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleInventory.AutoSize = True
        Me.lblTitleInventory.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleInventory.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleInventory.ForeColor = System.Drawing.Color.White
        Me.lblTitleInventory.Text = "قسم المخازن والخامات والريسيبي"
        Me.lblTitleInventory.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescInventory.AutoSize = True
        Me.lblDescInventory.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescInventory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescInventory.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescInventory.Text = "جرد المخزون، مستلزمات التشغيل، المواد الخام، الريسيبي وتكاليف الوجبات"
        Me.lblDescInventory.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackInventory.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackInventory.Width = 145
        Me.btnBackInventory.BorderRadius = 8
        Me.btnBackInventory.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackInventory.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackInventory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackInventory.Text = "  العودة للرئيسية"
        Me.btnBackInventory.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackInventory.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackInventory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackInventory.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpInventory
        Me.flpInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpInventory.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpInventory.WrapContents = True
        Me.flpInventory.AutoScroll = True
        Me.flpInventory.Padding = New System.Windows.Forms.Padding(10)
        Me.flpInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnfrmStoreStock
        Me.btnfrmStoreStock.Name = "btnfrmStoreStock"
        Me.btnfrmStoreStock.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmStoreStock.BorderRadius = 12
        Me.btnfrmStoreStock.BorderThickness = 1
        Me.btnfrmStoreStock.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmStoreStock.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmStoreStock.ForeColor = System.Drawing.Color.White
        Me.btnfrmStoreStock.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmStoreStock.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmStoreStock.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmStoreStock.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmStoreStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmStoreStock.Text = "أرصدة المخزون والجرد" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "متابعة الكميات وتنبيهات النواقص"
        Me.btnfrmStoreStock.Image = Global.WindowsApp1.My.Resources.Resources.in_stock
        Me.btnfrmStoreStock.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmStoreStock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmStoreStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmStoreStock.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmStoreStock.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmStoreStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpInventory.Controls.Add(Me.btnfrmStoreStock)

        ' btnfrmRawMaterials
        Me.btnfrmRawMaterials.Name = "btnfrmRawMaterials"
        Me.btnfrmRawMaterials.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmRawMaterials.BorderRadius = 12
        Me.btnfrmRawMaterials.BorderThickness = 1
        Me.btnfrmRawMaterials.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmRawMaterials.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmRawMaterials.ForeColor = System.Drawing.Color.White
        Me.btnfrmRawMaterials.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmRawMaterials.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmRawMaterials.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmRawMaterials.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmRawMaterials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmRawMaterials.Text = "المواد الخام والمستلزمات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "اللحوم والدواجن ومواد التغليف"
        Me.btnfrmRawMaterials.Image = Global.WindowsApp1.My.Resources.Resources.raw_materials
        Me.btnfrmRawMaterials.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmRawMaterials.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmRawMaterials.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmRawMaterials.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmRawMaterials.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmRawMaterials.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpInventory.Controls.Add(Me.btnfrmRawMaterials)

        ' btnfrmRecipes
        Me.btnfrmRecipes.Name = "btnfrmRecipes"
        Me.btnfrmRecipes.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmRecipes.BorderRadius = 12
        Me.btnfrmRecipes.BorderThickness = 1
        Me.btnfrmRecipes.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmRecipes.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmRecipes.ForeColor = System.Drawing.Color.White
        Me.btnfrmRecipes.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmRecipes.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmRecipes.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmRecipes.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmRecipes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmRecipes.Text = "الريسيبي وتصنيع المكونات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ربط الوجبات بالخامات لخصم الهالك"
        Me.btnfrmRecipes.Image = Global.WindowsApp1.My.Resources.Resources.cubes
        Me.btnfrmRecipes.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmRecipes.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmRecipes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmRecipes.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmRecipes.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmRecipes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpInventory.Controls.Add(Me.btnfrmRecipes)

        ' btnfrmStores
        Me.btnfrmStores.Name = "btnfrmStores"
        Me.btnfrmStores.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmStores.BorderRadius = 12
        Me.btnfrmStores.BorderThickness = 1
        Me.btnfrmStores.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmStores.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmStores.ForeColor = System.Drawing.Color.White
        Me.btnfrmStores.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmStores.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmStores.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmStores.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmStores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmStores.Text = "إدارة المخازن والمستودعات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "المخزن الرئيسي والمطبخ والبار"
        Me.btnfrmStores.Image = Global.WindowsApp1.My.Resources.Resources.box
        Me.btnfrmStores.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmStores.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmStores.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmStores.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmStores.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmStores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpInventory.Controls.Add(Me.btnfrmStores)

        ' btnfrmUnits
        Me.btnfrmUnits.Name = "btnfrmUnits"
        Me.btnfrmUnits.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmUnits.BorderRadius = 12
        Me.btnfrmUnits.BorderThickness = 1
        Me.btnfrmUnits.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmUnits.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmUnits.ForeColor = System.Drawing.Color.White
        Me.btnfrmUnits.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmUnits.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmUnits.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmUnits.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmUnits.Text = "وحدات القياس والتحويل" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "كيلو، جرام، لتر، كرتونة، علبة"
        Me.btnfrmUnits.Image = Global.WindowsApp1.My.Resources.Resources.unit
        Me.btnfrmUnits.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmUnits.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmUnits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmUnits.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmUnits.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmUnits.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpInventory.Controls.Add(Me.btnfrmUnits)

        ' =================== viewPurchases ===================
        Me.viewPurchases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewPurchases.AutoScroll = True
        Me.viewPurchases.Padding = New System.Windows.Forms.Padding(20)
        Me.viewPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewPurchases.Controls.Add(Me.flpPurchases)
        Me.viewPurchases.Controls.Add(Me.pnlHeaderPurchases)

        ' pnlHeaderPurchases
        Me.pnlHeaderPurchases.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderPurchases.Height = 60
        Me.pnlHeaderPurchases.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderPurchases.Controls.Add(Me.btnBackPurchases)
        Me.pnlHeaderPurchases.Controls.Add(Me.lblDescPurchases)
        Me.pnlHeaderPurchases.Controls.Add(Me.lblTitlePurchases)
        Me.pnlHeaderPurchases.Controls.Add(Me.picHeaderPurchases)

        ' picHeaderPurchases
        Me.picHeaderPurchases.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderPurchases.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderPurchases.Image = Global.WindowsApp1.My.Resources.Resources.shopping
        Me.picHeaderPurchases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitlePurchases.AutoSize = True
        Me.lblTitlePurchases.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitlePurchases.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitlePurchases.ForeColor = System.Drawing.Color.White
        Me.lblTitlePurchases.Text = "قسم المشتريات والتوريدات"
        Me.lblTitlePurchases.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitlePurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescPurchases.AutoSize = True
        Me.lblDescPurchases.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescPurchases.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescPurchases.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescPurchases.Text = "فواتير الشراء، توريدات الخامات، وحسابات المشتريات الشهرية"
        Me.lblDescPurchases.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackPurchases.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackPurchases.Width = 145
        Me.btnBackPurchases.BorderRadius = 8
        Me.btnBackPurchases.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackPurchases.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackPurchases.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackPurchases.Text = "  العودة للرئيسية"
        Me.btnBackPurchases.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackPurchases.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackPurchases.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackPurchases.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpPurchases
        Me.flpPurchases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpPurchases.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpPurchases.WrapContents = True
        Me.flpPurchases.AutoScroll = True
        Me.flpPurchases.Padding = New System.Windows.Forms.Padding(10)
        Me.flpPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnfrmPurchases
        Me.btnfrmPurchases.Name = "btnfrmPurchases"
        Me.btnfrmPurchases.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmPurchases.BorderRadius = 12
        Me.btnfrmPurchases.BorderThickness = 1
        Me.btnfrmPurchases.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmPurchases.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmPurchases.ForeColor = System.Drawing.Color.White
        Me.btnfrmPurchases.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmPurchases.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmPurchases.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmPurchases.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmPurchases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmPurchases.Text = "فاتورة مشتريات جديدة" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "توريد خامات ومستلزمات من الموردين"
        Me.btnfrmPurchases.Image = Global.WindowsApp1.My.Resources.Resources.shopping
        Me.btnfrmPurchases.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmPurchases.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmPurchases.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmPurchases.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmPurchases.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpPurchases.Controls.Add(Me.btnfrmPurchases)

        ' btnfrmPurchaseReports
        Me.btnfrmPurchaseReports.Name = "btnfrmPurchaseReports"
        Me.btnfrmPurchaseReports.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmPurchaseReports.BorderRadius = 12
        Me.btnfrmPurchaseReports.BorderThickness = 1
        Me.btnfrmPurchaseReports.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmPurchaseReports.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmPurchaseReports.ForeColor = System.Drawing.Color.White
        Me.btnfrmPurchaseReports.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmPurchaseReports.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmPurchaseReports.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmPurchaseReports.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmPurchaseReports.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmPurchaseReports.Text = "تقارير المشتريات والصرف" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تحليل تكاليف المشتريات وفواتير الموردين"
        Me.btnfrmPurchaseReports.Image = Global.WindowsApp1.My.Resources.Resources.financial
        Me.btnfrmPurchaseReports.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmPurchaseReports.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmPurchaseReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmPurchaseReports.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmPurchaseReports.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmPurchaseReports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpPurchases.Controls.Add(Me.btnfrmPurchaseReports)

        ' =================== viewCustomers ===================
        Me.viewCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewCustomers.AutoScroll = True
        Me.viewCustomers.Padding = New System.Windows.Forms.Padding(20)
        Me.viewCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewCustomers.Controls.Add(Me.flpCustomers)
        Me.viewCustomers.Controls.Add(Me.pnlHeaderCustomers)

        ' pnlHeaderCustomers
        Me.pnlHeaderCustomers.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderCustomers.Height = 60
        Me.pnlHeaderCustomers.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderCustomers.Controls.Add(Me.btnBackCustomers)
        Me.pnlHeaderCustomers.Controls.Add(Me.lblDescCustomers)
        Me.pnlHeaderCustomers.Controls.Add(Me.lblTitleCustomers)
        Me.pnlHeaderCustomers.Controls.Add(Me.picHeaderCustomers)

        ' picHeaderCustomers
        Me.picHeaderCustomers.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderCustomers.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderCustomers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.picHeaderCustomers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleCustomers.AutoSize = True
        Me.lblTitleCustomers.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleCustomers.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleCustomers.ForeColor = System.Drawing.Color.White
        Me.lblTitleCustomers.Text = "قسم العملاء والحسابات والآجل"
        Me.lblTitleCustomers.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescCustomers.AutoSize = True
        Me.lblDescCustomers.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescCustomers.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescCustomers.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescCustomers.Text = "سجل العملاء، كشوفات الحساب، سداد المديونيات وتقارير المبيعات الآجلة"
        Me.lblDescCustomers.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackCustomers.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackCustomers.Width = 145
        Me.btnBackCustomers.BorderRadius = 8
        Me.btnBackCustomers.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackCustomers.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackCustomers.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackCustomers.Text = "  العودة للرئيسية"
        Me.btnBackCustomers.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackCustomers.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackCustomers.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpCustomers
        Me.flpCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpCustomers.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpCustomers.WrapContents = True
        Me.flpCustomers.AutoScroll = True
        Me.flpCustomers.Padding = New System.Windows.Forms.Padding(10)
        Me.flpCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnFrmCustomers
        Me.btnFrmCustomers.Name = "btnFrmCustomers"
        Me.btnFrmCustomers.Size = New System.Drawing.Size(340, 95)
        Me.btnFrmCustomers.BorderRadius = 12
        Me.btnFrmCustomers.BorderThickness = 1
        Me.btnFrmCustomers.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnFrmCustomers.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnFrmCustomers.ForeColor = System.Drawing.Color.White
        Me.btnFrmCustomers.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnFrmCustomers.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnFrmCustomers.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnFrmCustomers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFrmCustomers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnFrmCustomers.Text = "دليل العملاء والعناوين" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "بيانات العملاء وأرقام الهواتف والعناوين"
        Me.btnFrmCustomers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.btnFrmCustomers.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnFrmCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnFrmCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnFrmCustomers.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnFrmCustomers.Margin = New System.Windows.Forms.Padding(8)
        Me.btnFrmCustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpCustomers.Controls.Add(Me.btnFrmCustomers)

        ' btnFrmCustomerStatement
        Me.btnFrmCustomerStatement.Name = "btnFrmCustomerStatement"
        Me.btnFrmCustomerStatement.Size = New System.Drawing.Size(340, 95)
        Me.btnFrmCustomerStatement.BorderRadius = 12
        Me.btnFrmCustomerStatement.BorderThickness = 1
        Me.btnFrmCustomerStatement.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnFrmCustomerStatement.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnFrmCustomerStatement.ForeColor = System.Drawing.Color.White
        Me.btnFrmCustomerStatement.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnFrmCustomerStatement.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnFrmCustomerStatement.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnFrmCustomerStatement.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFrmCustomerStatement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnFrmCustomerStatement.Text = "كشف حساب عميل" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "حركات الفواتير والمدفوعات والرصيد"
        Me.btnFrmCustomerStatement.Image = Global.WindowsApp1.My.Resources.Resources.invoice
        Me.btnFrmCustomerStatement.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnFrmCustomerStatement.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnFrmCustomerStatement.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnFrmCustomerStatement.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnFrmCustomerStatement.Margin = New System.Windows.Forms.Padding(8)
        Me.btnFrmCustomerStatement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpCustomers.Controls.Add(Me.btnFrmCustomerStatement)

        ' btnCustomerBalanceDownload
        Me.btnCustomerBalanceDownload.Name = "btnCustomerBalanceDownload"
        Me.btnCustomerBalanceDownload.Size = New System.Drawing.Size(340, 95)
        Me.btnCustomerBalanceDownload.BorderRadius = 12
        Me.btnCustomerBalanceDownload.BorderThickness = 1
        Me.btnCustomerBalanceDownload.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnCustomerBalanceDownload.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnCustomerBalanceDownload.ForeColor = System.Drawing.Color.White
        Me.btnCustomerBalanceDownload.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnCustomerBalanceDownload.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnCustomerBalanceDownload.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnCustomerBalanceDownload.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCustomerBalanceDownload.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnCustomerBalanceDownload.Text = "سداد رصيد عميل (سند قبض)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تحصيل مديونية وإيداعها في الخزينة"
        Me.btnCustomerBalanceDownload.Image = Global.WindowsApp1.My.Resources.Resources.payment
        Me.btnCustomerBalanceDownload.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCustomerBalanceDownload.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnCustomerBalanceDownload.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnCustomerBalanceDownload.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnCustomerBalanceDownload.Margin = New System.Windows.Forms.Padding(8)
        Me.btnCustomerBalanceDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpCustomers.Controls.Add(Me.btnCustomerBalanceDownload)

        ' ToolStripButton11
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(340, 95)
        Me.ToolStripButton11.BorderRadius = 12
        Me.ToolStripButton11.BorderThickness = 1
        Me.ToolStripButton11.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.ToolStripButton11.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.ToolStripButton11.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton11.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.ToolStripButton11.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.ToolStripButton11.HoverState.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton11.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolStripButton11.Text = "تقارير مديونيات العملاء" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "حصر العملاء الآجل ومواعيد التحصيل"
        Me.ToolStripButton11.Image = Global.WindowsApp1.My.Resources.Resources.graph
        Me.ToolStripButton11.ImageSize = New System.Drawing.Size(32, 32)
        Me.ToolStripButton11.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ToolStripButton11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripButton11.TextOffset = New System.Drawing.Point(5, 0)
        Me.ToolStripButton11.Margin = New System.Windows.Forms.Padding(8)
        Me.ToolStripButton11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpCustomers.Controls.Add(Me.ToolStripButton11)

        ' =================== viewSuppliers ===================
        Me.viewSuppliers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewSuppliers.AutoScroll = True
        Me.viewSuppliers.Padding = New System.Windows.Forms.Padding(20)
        Me.viewSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewSuppliers.Controls.Add(Me.flpSuppliers)
        Me.viewSuppliers.Controls.Add(Me.pnlHeaderSuppliers)

        ' pnlHeaderSuppliers
        Me.pnlHeaderSuppliers.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderSuppliers.Height = 60
        Me.pnlHeaderSuppliers.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderSuppliers.Controls.Add(Me.btnBackSuppliers)
        Me.pnlHeaderSuppliers.Controls.Add(Me.lblDescSuppliers)
        Me.pnlHeaderSuppliers.Controls.Add(Me.lblTitleSuppliers)
        Me.pnlHeaderSuppliers.Controls.Add(Me.picHeaderSuppliers)

        ' picHeaderSuppliers
        Me.picHeaderSuppliers.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderSuppliers.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderSuppliers.Image = Global.WindowsApp1.My.Resources.Resources.supplier
        Me.picHeaderSuppliers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleSuppliers.AutoSize = True
        Me.lblTitleSuppliers.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleSuppliers.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleSuppliers.ForeColor = System.Drawing.Color.White
        Me.lblTitleSuppliers.Text = "قسم الموردين والشركات والآجل"
        Me.lblTitleSuppliers.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescSuppliers.AutoSize = True
        Me.lblDescSuppliers.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescSuppliers.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescSuppliers.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescSuppliers.Text = "دليل الشركات الموردة، مسيرات الدفعات، وكشوفات الحسابات والآجل"
        Me.lblDescSuppliers.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackSuppliers.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackSuppliers.Width = 145
        Me.btnBackSuppliers.BorderRadius = 8
        Me.btnBackSuppliers.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackSuppliers.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackSuppliers.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackSuppliers.Text = "  العودة للرئيسية"
        Me.btnBackSuppliers.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackSuppliers.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackSuppliers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackSuppliers.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpSuppliers
        Me.flpSuppliers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpSuppliers.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpSuppliers.WrapContents = True
        Me.flpSuppliers.AutoScroll = True
        Me.flpSuppliers.Padding = New System.Windows.Forms.Padding(10)
        Me.flpSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' ToolStripButton3
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(340, 95)
        Me.ToolStripButton3.BorderRadius = 12
        Me.ToolStripButton3.BorderThickness = 1
        Me.ToolStripButton3.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.ToolStripButton3.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton3.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.ToolStripButton3.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.ToolStripButton3.HoverState.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolStripButton3.Text = "دليل الموردين والشركات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "بيانات الموردين وشركات الأغذية"
        Me.ToolStripButton3.Image = Global.WindowsApp1.My.Resources.Resources.supplier
        Me.ToolStripButton3.ImageSize = New System.Drawing.Size(32, 32)
        Me.ToolStripButton3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ToolStripButton3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripButton3.TextOffset = New System.Drawing.Point(5, 0)
        Me.ToolStripButton3.Margin = New System.Windows.Forms.Padding(8)
        Me.ToolStripButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSuppliers.Controls.Add(Me.ToolStripButton3)

        ' ToolStripButton4
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(340, 95)
        Me.ToolStripButton4.BorderRadius = 12
        Me.ToolStripButton4.BorderThickness = 1
        Me.ToolStripButton4.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.ToolStripButton4.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton4.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.ToolStripButton4.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.ToolStripButton4.HoverState.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolStripButton4.Text = "كشف حساب مورد" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "سجل التوريدات والمبالغ المستحقة"
        Me.ToolStripButton4.Image = Global.WindowsApp1.My.Resources.Resources.file
        Me.ToolStripButton4.ImageSize = New System.Drawing.Size(32, 32)
        Me.ToolStripButton4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ToolStripButton4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripButton4.TextOffset = New System.Drawing.Point(5, 0)
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(8)
        Me.ToolStripButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSuppliers.Controls.Add(Me.ToolStripButton4)

        ' ToolStripButton5
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(340, 95)
        Me.ToolStripButton5.BorderRadius = 12
        Me.ToolStripButton5.BorderThickness = 1
        Me.ToolStripButton5.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.ToolStripButton5.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.ToolStripButton5.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton5.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.ToolStripButton5.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.ToolStripButton5.HoverState.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton5.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolStripButton5.Text = "تقارير الموردين والآجل" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "جدول التزامات الدفع والديون المستحقة"
        Me.ToolStripButton5.Image = Global.WindowsApp1.My.Resources.Resources.market_analysis
        Me.ToolStripButton5.ImageSize = New System.Drawing.Size(32, 32)
        Me.ToolStripButton5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ToolStripButton5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripButton5.TextOffset = New System.Drawing.Point(5, 0)
        Me.ToolStripButton5.Margin = New System.Windows.Forms.Padding(8)
        Me.ToolStripButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSuppliers.Controls.Add(Me.ToolStripButton5)

        ' =================== viewTreasury ===================
        Me.viewTreasury.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewTreasury.AutoScroll = True
        Me.viewTreasury.Padding = New System.Windows.Forms.Padding(20)
        Me.viewTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewTreasury.Controls.Add(Me.flpTreasury)
        Me.viewTreasury.Controls.Add(Me.pnlHeaderTreasury)

        ' pnlHeaderTreasury
        Me.pnlHeaderTreasury.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderTreasury.Height = 60
        Me.pnlHeaderTreasury.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderTreasury.Controls.Add(Me.btnBackTreasury)
        Me.pnlHeaderTreasury.Controls.Add(Me.lblDescTreasury)
        Me.pnlHeaderTreasury.Controls.Add(Me.lblTitleTreasury)
        Me.pnlHeaderTreasury.Controls.Add(Me.picHeaderTreasury)

        ' picHeaderTreasury
        Me.picHeaderTreasury.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderTreasury.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderTreasury.Image = Global.WindowsApp1.My.Resources.Resources.treasury
        Me.picHeaderTreasury.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleTreasury.AutoSize = True
        Me.lblTitleTreasury.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleTreasury.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleTreasury.ForeColor = System.Drawing.Color.White
        Me.lblTitleTreasury.Text = "قسم الخزينة والسيولة النقدية"
        Me.lblTitleTreasury.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescTreasury.AutoSize = True
        Me.lblDescTreasury.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescTreasury.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescTreasury.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescTreasury.Text = "إدارة الخزن، التحويلات المالية، سندات القبض والصرف، وحركات النقدية"
        Me.lblDescTreasury.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackTreasury.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackTreasury.Width = 145
        Me.btnBackTreasury.BorderRadius = 8
        Me.btnBackTreasury.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackTreasury.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackTreasury.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackTreasury.Text = "  العودة للرئيسية"
        Me.btnBackTreasury.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackTreasury.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackTreasury.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackTreasury.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpTreasury
        Me.flpTreasury.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpTreasury.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpTreasury.WrapContents = True
        Me.flpTreasury.AutoScroll = True
        Me.flpTreasury.Padding = New System.Windows.Forms.Padding(10)
        Me.flpTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnfrmTreasury
        Me.btnfrmTreasury.Name = "btnfrmTreasury"
        Me.btnfrmTreasury.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmTreasury.BorderRadius = 12
        Me.btnfrmTreasury.BorderThickness = 1
        Me.btnfrmTreasury.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmTreasury.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmTreasury.ForeColor = System.Drawing.Color.White
        Me.btnfrmTreasury.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmTreasury.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmTreasury.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmTreasury.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmTreasury.Text = "إدارة الخزن والبنوك" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "خزينة الكاشير والرئيسية والحسابات"
        Me.btnfrmTreasury.Image = Global.WindowsApp1.My.Resources.Resources.treasury
        Me.btnfrmTreasury.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmTreasury.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmTreasury.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmTreasury.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmTreasury.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpTreasury.Controls.Add(Me.btnfrmTreasury)

        ' btnFrmTreasuryTransfer
        Me.btnFrmTreasuryTransfer.Name = "btnFrmTreasuryTransfer"
        Me.btnFrmTreasuryTransfer.Size = New System.Drawing.Size(340, 95)
        Me.btnFrmTreasuryTransfer.BorderRadius = 12
        Me.btnFrmTreasuryTransfer.BorderThickness = 1
        Me.btnFrmTreasuryTransfer.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnFrmTreasuryTransfer.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnFrmTreasuryTransfer.ForeColor = System.Drawing.Color.White
        Me.btnFrmTreasuryTransfer.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnFrmTreasuryTransfer.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnFrmTreasuryTransfer.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnFrmTreasuryTransfer.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFrmTreasuryTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnFrmTreasuryTransfer.Text = "تحويل نقدي بين الخزن" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "مناقلة سيولة نقدية بين الخزن وتوثيقها"
        Me.btnFrmTreasuryTransfer.Image = Global.WindowsApp1.My.Resources.Resources.exchange
        Me.btnFrmTreasuryTransfer.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnFrmTreasuryTransfer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnFrmTreasuryTransfer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnFrmTreasuryTransfer.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnFrmTreasuryTransfer.Margin = New System.Windows.Forms.Padding(8)
        Me.btnFrmTreasuryTransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpTreasury.Controls.Add(Me.btnFrmTreasuryTransfer)

        ' btnDeposit
        Me.btnDeposit.Name = "btnDeposit"
        Me.btnDeposit.Size = New System.Drawing.Size(340, 95)
        Me.btnDeposit.BorderRadius = 12
        Me.btnDeposit.BorderThickness = 1
        Me.btnDeposit.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnDeposit.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnDeposit.ForeColor = System.Drawing.Color.White
        Me.btnDeposit.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnDeposit.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnDeposit.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnDeposit.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnDeposit.Text = "إيداع نقدي (سند قبض)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "إدخال سيولة إضافية وتحديد جهة الإيداع"
        Me.btnDeposit.Image = Global.WindowsApp1.My.Resources.Resources.deposit
        Me.btnDeposit.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDeposit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnDeposit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnDeposit.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnDeposit.Margin = New System.Windows.Forms.Padding(8)
        Me.btnDeposit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpTreasury.Controls.Add(Me.btnDeposit)

        ' btnWithdraw
        Me.btnWithdraw.Name = "btnWithdraw"
        Me.btnWithdraw.Size = New System.Drawing.Size(340, 95)
        Me.btnWithdraw.BorderRadius = 12
        Me.btnWithdraw.BorderThickness = 1
        Me.btnWithdraw.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnWithdraw.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnWithdraw.ForeColor = System.Drawing.Color.White
        Me.btnWithdraw.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnWithdraw.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnWithdraw.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnWithdraw.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnWithdraw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnWithdraw.Text = "سحب نقدي (سند صرف)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "سحب سيولة نقدية وتوثيق المسوغ"
        Me.btnWithdraw.Image = Global.WindowsApp1.My.Resources.Resources.paper
        Me.btnWithdraw.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnWithdraw.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnWithdraw.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnWithdraw.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnWithdraw.Margin = New System.Windows.Forms.Padding(8)
        Me.btnWithdraw.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpTreasury.Controls.Add(Me.btnWithdraw)

        ' btnFrmTreasuryTransactionsReport
        Me.btnFrmTreasuryTransactionsReport.Name = "btnFrmTreasuryTransactionsReport"
        Me.btnFrmTreasuryTransactionsReport.Size = New System.Drawing.Size(340, 95)
        Me.btnFrmTreasuryTransactionsReport.BorderRadius = 12
        Me.btnFrmTreasuryTransactionsReport.BorderThickness = 1
        Me.btnFrmTreasuryTransactionsReport.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnFrmTreasuryTransactionsReport.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnFrmTreasuryTransactionsReport.ForeColor = System.Drawing.Color.White
        Me.btnFrmTreasuryTransactionsReport.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnFrmTreasuryTransactionsReport.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnFrmTreasuryTransactionsReport.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnFrmTreasuryTransactionsReport.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFrmTreasuryTransactionsReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnFrmTreasuryTransactionsReport.Text = "تقرير حركة الخزينة والرصيد" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ميزان النقدية اليومي والأرصدة الدفترية"
        Me.btnFrmTreasuryTransactionsReport.Image = Global.WindowsApp1.My.Resources.Resources.financial
        Me.btnFrmTreasuryTransactionsReport.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnFrmTreasuryTransactionsReport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnFrmTreasuryTransactionsReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnFrmTreasuryTransactionsReport.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnFrmTreasuryTransactionsReport.Margin = New System.Windows.Forms.Padding(8)
        Me.btnFrmTreasuryTransactionsReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpTreasury.Controls.Add(Me.btnFrmTreasuryTransactionsReport)

        ' =================== viewExpenses ===================
        Me.viewExpenses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewExpenses.AutoScroll = True
        Me.viewExpenses.Padding = New System.Windows.Forms.Padding(20)
        Me.viewExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewExpenses.Controls.Add(Me.flpExpenses)
        Me.viewExpenses.Controls.Add(Me.pnlHeaderExpenses)

        ' pnlHeaderExpenses
        Me.pnlHeaderExpenses.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderExpenses.Height = 60
        Me.pnlHeaderExpenses.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderExpenses.Controls.Add(Me.btnBackExpenses)
        Me.pnlHeaderExpenses.Controls.Add(Me.lblDescExpenses)
        Me.pnlHeaderExpenses.Controls.Add(Me.lblTitleExpenses)
        Me.pnlHeaderExpenses.Controls.Add(Me.picHeaderExpenses)

        ' picHeaderExpenses
        Me.picHeaderExpenses.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderExpenses.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderExpenses.Image = Global.WindowsApp1.My.Resources.Resources.discount
        Me.picHeaderExpenses.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleExpenses.AutoSize = True
        Me.lblTitleExpenses.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleExpenses.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleExpenses.ForeColor = System.Drawing.Color.White
        Me.lblTitleExpenses.Text = "قسم المصروفات التشغيلية واليومية"
        Me.lblTitleExpenses.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescExpenses.AutoSize = True
        Me.lblDescExpenses.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescExpenses.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescExpenses.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescExpenses.Text = "تسجيل النثريات، فواتير المرافق، الإيجارات، ومصروفات التشغيل المباشرة"
        Me.lblDescExpenses.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackExpenses.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackExpenses.Width = 145
        Me.btnBackExpenses.BorderRadius = 8
        Me.btnBackExpenses.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackExpenses.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackExpenses.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackExpenses.Text = "  العودة للرئيسية"
        Me.btnBackExpenses.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackExpenses.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackExpenses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackExpenses.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpExpenses
        Me.flpExpenses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpExpenses.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpExpenses.WrapContents = True
        Me.flpExpenses.AutoScroll = True
        Me.flpExpenses.Padding = New System.Windows.Forms.Padding(10)
        Me.flpExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnform_Expenses
        Me.btnform_Expenses.Name = "btnform_Expenses"
        Me.btnform_Expenses.Size = New System.Drawing.Size(340, 95)
        Me.btnform_Expenses.BorderRadius = 12
        Me.btnform_Expenses.BorderThickness = 1
        Me.btnform_Expenses.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnform_Expenses.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnform_Expenses.ForeColor = System.Drawing.Color.White
        Me.btnform_Expenses.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnform_Expenses.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnform_Expenses.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnform_Expenses.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnform_Expenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnform_Expenses.Text = "تسجيل مصروف جديد" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "صرف نثريات وخصمها من خزينة الوردية"
        Me.btnform_Expenses.Image = Global.WindowsApp1.My.Resources.Resources.money
        Me.btnform_Expenses.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnform_Expenses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnform_Expenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnform_Expenses.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnform_Expenses.Margin = New System.Windows.Forms.Padding(8)
        Me.btnform_Expenses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpExpenses.Controls.Add(Me.btnform_Expenses)

        ' btnExpensesReportForm
        Me.btnExpensesReportForm.Name = "btnExpensesReportForm"
        Me.btnExpensesReportForm.Size = New System.Drawing.Size(340, 95)
        Me.btnExpensesReportForm.BorderRadius = 12
        Me.btnExpensesReportForm.BorderThickness = 1
        Me.btnExpensesReportForm.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnExpensesReportForm.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnExpensesReportForm.ForeColor = System.Drawing.Color.White
        Me.btnExpensesReportForm.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnExpensesReportForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnExpensesReportForm.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnExpensesReportForm.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnExpensesReportForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnExpensesReportForm.Text = "تقارير المصروفات الشهرية" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "مقارنة بنود الصرف ومسوغات الإنفاق"
        Me.btnExpensesReportForm.Image = Global.WindowsApp1.My.Resources.Resources.report
        Me.btnExpensesReportForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnExpensesReportForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnExpensesReportForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnExpensesReportForm.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnExpensesReportForm.Margin = New System.Windows.Forms.Padding(8)
        Me.btnExpensesReportForm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpExpenses.Controls.Add(Me.btnExpensesReportForm)

        ' =================== viewEmployees ===================
        Me.viewEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewEmployees.AutoScroll = True
        Me.viewEmployees.Padding = New System.Windows.Forms.Padding(20)
        Me.viewEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewEmployees.Controls.Add(Me.flpEmployees)
        Me.viewEmployees.Controls.Add(Me.pnlHeaderEmployees)

        ' pnlHeaderEmployees
        Me.pnlHeaderEmployees.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderEmployees.Height = 60
        Me.pnlHeaderEmployees.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderEmployees.Controls.Add(Me.btnBackEmployees)
        Me.pnlHeaderEmployees.Controls.Add(Me.lblDescEmployees)
        Me.pnlHeaderEmployees.Controls.Add(Me.lblTitleEmployees)
        Me.pnlHeaderEmployees.Controls.Add(Me.picHeaderEmployees)

        ' picHeaderEmployees
        Me.picHeaderEmployees.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderEmployees.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderEmployees.Image = Global.WindowsApp1.My.Resources.Resources.staff
        Me.picHeaderEmployees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleEmployees.AutoSize = True
        Me.lblTitleEmployees.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleEmployees.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleEmployees.ForeColor = System.Drawing.Color.White
        Me.lblTitleEmployees.Text = "قسم شؤون الموظفين والرواتب"
        Me.lblTitleEmployees.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescEmployees.AutoSize = True
        Me.lblDescEmployees.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescEmployees.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescEmployees.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescEmployees.Text = "ملفات العاملين، الشيفات، الويترز، السلف، مسير الرواتب والمكافآت"
        Me.lblDescEmployees.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackEmployees.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackEmployees.Width = 145
        Me.btnBackEmployees.BorderRadius = 8
        Me.btnBackEmployees.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackEmployees.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackEmployees.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackEmployees.Text = "  العودة للرئيسية"
        Me.btnBackEmployees.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackEmployees.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackEmployees.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackEmployees.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpEmployees
        Me.flpEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpEmployees.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpEmployees.WrapContents = True
        Me.flpEmployees.AutoScroll = True
        Me.flpEmployees.Padding = New System.Windows.Forms.Padding(10)
        Me.flpEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnfrmEmployees
        Me.btnfrmEmployees.Name = "btnfrmEmployees"
        Me.btnfrmEmployees.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmEmployees.BorderRadius = 12
        Me.btnfrmEmployees.BorderThickness = 1
        Me.btnfrmEmployees.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmEmployees.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmEmployees.ForeColor = System.Drawing.Color.White
        Me.btnfrmEmployees.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmEmployees.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmEmployees.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmEmployees.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmEmployees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmEmployees.Text = "إدارة الموظفين والعاملين" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "سجل العاملين والرواتب والعقود"
        Me.btnfrmEmployees.Image = Global.WindowsApp1.My.Resources.Resources.staff
        Me.btnfrmEmployees.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmEmployees.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmEmployees.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmEmployees.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmEmployees.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpEmployees.Controls.Add(Me.btnfrmEmployees)

        ' btnfrmJobTitles
        Me.btnfrmJobTitles.Name = "btnfrmJobTitles"
        Me.btnfrmJobTitles.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmJobTitles.BorderRadius = 12
        Me.btnfrmJobTitles.BorderThickness = 1
        Me.btnfrmJobTitles.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmJobTitles.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmJobTitles.ForeColor = System.Drawing.Color.White
        Me.btnfrmJobTitles.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmJobTitles.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmJobTitles.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmJobTitles.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmJobTitles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmJobTitles.Text = "المسميات الوظيفية" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "كاشير، شيف، ويتر، ديليفري، مدير"
        Me.btnfrmJobTitles.Image = Global.WindowsApp1.My.Resources.Resources.new_hire
        Me.btnfrmJobTitles.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmJobTitles.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmJobTitles.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmJobTitles.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmJobTitles.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmJobTitles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpEmployees.Controls.Add(Me.btnfrmJobTitles)

        ' btnfrmDepartments
        Me.btnfrmDepartments.Name = "btnfrmDepartments"
        Me.btnfrmDepartments.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmDepartments.BorderRadius = 12
        Me.btnfrmDepartments.BorderThickness = 1
        Me.btnfrmDepartments.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmDepartments.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmDepartments.ForeColor = System.Drawing.Color.White
        Me.btnfrmDepartments.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmDepartments.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmDepartments.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmDepartments.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmDepartments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmDepartments.Text = "الأقسام الإدارية" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "المطبخ والصالة والديليفري والإدارة"
        Me.btnfrmDepartments.Image = Global.WindowsApp1.My.Resources.Resources.team
        Me.btnfrmDepartments.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmDepartments.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmDepartments.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmDepartments.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmDepartments.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmDepartments.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpEmployees.Controls.Add(Me.btnfrmDepartments)

        ' btnfrmSalarySystems
        Me.btnfrmSalarySystems.Name = "btnfrmSalarySystems"
        Me.btnfrmSalarySystems.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmSalarySystems.BorderRadius = 12
        Me.btnfrmSalarySystems.BorderThickness = 1
        Me.btnfrmSalarySystems.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmSalarySystems.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmSalarySystems.ForeColor = System.Drawing.Color.White
        Me.btnfrmSalarySystems.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmSalarySystems.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmSalarySystems.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmSalarySystems.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmSalarySystems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmSalarySystems.Text = "أنظمة الرواتب والعمولات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "راتب شهري، يوميات، نسبة مبيعات"
        Me.btnfrmSalarySystems.Image = Global.WindowsApp1.My.Resources.Resources.data_processing
        Me.btnfrmSalarySystems.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmSalarySystems.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmSalarySystems.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmSalarySystems.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmSalarySystems.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmSalarySystems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpEmployees.Controls.Add(Me.btnfrmSalarySystems)

        ' btnfrmSalaryPayment
        Me.btnfrmSalaryPayment.Name = "btnfrmSalaryPayment"
        Me.btnfrmSalaryPayment.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmSalaryPayment.BorderRadius = 12
        Me.btnfrmSalaryPayment.BorderThickness = 1
        Me.btnfrmSalaryPayment.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmSalaryPayment.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmSalaryPayment.ForeColor = System.Drawing.Color.White
        Me.btnfrmSalaryPayment.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmSalaryPayment.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmSalaryPayment.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmSalaryPayment.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmSalaryPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmSalaryPayment.Text = "صرف الرواتب والسلف" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تسليم المرتبات وتوثيق السلف"
        Me.btnfrmSalaryPayment.Image = Global.WindowsApp1.My.Resources.Resources.pay__1_
        Me.btnfrmSalaryPayment.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmSalaryPayment.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmSalaryPayment.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmSalaryPayment.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmSalaryPayment.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmSalaryPayment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpEmployees.Controls.Add(Me.btnfrmSalaryPayment)

        ' =================== viewUsers ===================
        Me.viewUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewUsers.AutoScroll = True
        Me.viewUsers.Padding = New System.Windows.Forms.Padding(20)
        Me.viewUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewUsers.Controls.Add(Me.flpUsers)
        Me.viewUsers.Controls.Add(Me.pnlHeaderUsers)

        ' pnlHeaderUsers
        Me.pnlHeaderUsers.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderUsers.Height = 60
        Me.pnlHeaderUsers.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderUsers.Controls.Add(Me.btnBackUsers)
        Me.pnlHeaderUsers.Controls.Add(Me.lblDescUsers)
        Me.pnlHeaderUsers.Controls.Add(Me.lblTitleUsers)
        Me.pnlHeaderUsers.Controls.Add(Me.picHeaderUsers)

        ' picHeaderUsers
        Me.picHeaderUsers.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderUsers.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderUsers.Image = Global.WindowsApp1.My.Resources.Resources.lock
        Me.picHeaderUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleUsers.AutoSize = True
        Me.lblTitleUsers.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleUsers.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleUsers.ForeColor = System.Drawing.Color.White
        Me.lblTitleUsers.Text = "قسم المستخدمين والصلاحيات والأمان"
        Me.lblTitleUsers.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescUsers.AutoSize = True
        Me.lblDescUsers.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescUsers.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescUsers.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescUsers.Text = "حسابات الدخول، كلمات المرور، مصفوفة الصلاحيات، وتأمين النظام"
        Me.lblDescUsers.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackUsers.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackUsers.Width = 145
        Me.btnBackUsers.BorderRadius = 8
        Me.btnBackUsers.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackUsers.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackUsers.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackUsers.Text = "  العودة للرئيسية"
        Me.btnBackUsers.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackUsers.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackUsers.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpUsers
        Me.flpUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpUsers.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpUsers.WrapContents = True
        Me.flpUsers.AutoScroll = True
        Me.flpUsers.Padding = New System.Windows.Forms.Padding(10)
        Me.flpUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnfrmUsers
        Me.btnfrmUsers.Name = "btnfrmUsers"
        Me.btnfrmUsers.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmUsers.BorderRadius = 12
        Me.btnfrmUsers.BorderThickness = 1
        Me.btnfrmUsers.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmUsers.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmUsers.ForeColor = System.Drawing.Color.White
        Me.btnfrmUsers.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmUsers.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmUsers.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmUsers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmUsers.Text = "إدارة حسابات المستخدمين" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "إنشاء وتعديل حسابات الكاشير والمشرفين"
        Me.btnfrmUsers.Image = Global.WindowsApp1.My.Resources.Resources.user
        Me.btnfrmUsers.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmUsers.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmUsers.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpUsers.Controls.Add(Me.btnfrmUsers)

        ' btnfrmRolesAndPermissions
        Me.btnfrmRolesAndPermissions.Name = "btnfrmRolesAndPermissions"
        Me.btnfrmRolesAndPermissions.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmRolesAndPermissions.BorderRadius = 12
        Me.btnfrmRolesAndPermissions.BorderThickness = 1
        Me.btnfrmRolesAndPermissions.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmRolesAndPermissions.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmRolesAndPermissions.ForeColor = System.Drawing.Color.White
        Me.btnfrmRolesAndPermissions.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmRolesAndPermissions.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmRolesAndPermissions.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmRolesAndPermissions.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmRolesAndPermissions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmRolesAndPermissions.Text = "الأدوار ومصفوفة الصلاحيات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "صلاحيات الخصم والإلغاء والتقارير"
        Me.btnfrmRolesAndPermissions.Image = Global.WindowsApp1.My.Resources.Resources.lock
        Me.btnfrmRolesAndPermissions.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmRolesAndPermissions.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmRolesAndPermissions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmRolesAndPermissions.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmRolesAndPermissions.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmRolesAndPermissions.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpUsers.Controls.Add(Me.btnfrmRolesAndPermissions)

        ' =================== viewSettings ===================
        Me.viewSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewSettings.AutoScroll = True
        Me.viewSettings.Padding = New System.Windows.Forms.Padding(20)
        Me.viewSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.viewSettings.Controls.Add(Me.flpSettings)
        Me.viewSettings.Controls.Add(Me.pnlHeaderSettings)

        ' pnlHeaderSettings
        Me.pnlHeaderSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderSettings.Height = 60
        Me.pnlHeaderSettings.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlHeaderSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlHeaderSettings.Controls.Add(Me.btnBackSettings)
        Me.pnlHeaderSettings.Controls.Add(Me.lblDescSettings)
        Me.pnlHeaderSettings.Controls.Add(Me.lblTitleSettings)
        Me.pnlHeaderSettings.Controls.Add(Me.picHeaderSettings)

        ' picHeaderSettings
        Me.picHeaderSettings.Dock = System.Windows.Forms.DockStyle.Right
        Me.picHeaderSettings.Size = New System.Drawing.Size(36, 36)
        Me.picHeaderSettings.Image = Global.WindowsApp1.My.Resources.Resources.settings__3_
        Me.picHeaderSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

        Me.lblTitleSettings.AutoSize = True
        Me.lblTitleSettings.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitleSettings.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleSettings.ForeColor = System.Drawing.Color.White
        Me.lblTitleSettings.Text = "قسم إعدادات النظام والطابعات والنسخ"
        Me.lblTitleSettings.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.lblTitleSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.lblDescSettings.AutoSize = True
        Me.lblDescSettings.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDescSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescSettings.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblDescSettings.Text = "إعدادات الفواتير، الطابعات والبونات، توزيع الطاولات، والنسخ الاحتياطي"
        Me.lblDescSettings.Padding = New System.Windows.Forms.Padding(0, 9, 15, 0)
        Me.lblDescSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        Me.btnBackSettings.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBackSettings.Width = 145
        Me.btnBackSettings.BorderRadius = 8
        Me.btnBackSettings.FillColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnBackSettings.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
        Me.btnBackSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackSettings.Text = "  العودة للرئيسية"
        Me.btnBackSettings.Image = Global.WindowsApp1.My.Resources.Resources.arrow
        Me.btnBackSettings.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnBackSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackSettings.Cursor = System.Windows.Forms.Cursors.Hand

        ' flpSettings
        Me.flpSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpSettings.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpSettings.WrapContents = True
        Me.flpSettings.AutoScroll = True
        Me.flpSettings.Padding = New System.Windows.Forms.Padding(10)
        Me.flpSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes

        ' btnSettings
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(340, 95)
        Me.btnSettings.BorderRadius = 12
        Me.btnSettings.BorderThickness = 1
        Me.btnSettings.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnSettings.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnSettings.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnSettings.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnSettings.Text = "لوحة إعدادات النظام" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "الضريبة والعملة والهوية التجارية"
        Me.btnSettings.Image = Global.WindowsApp1.My.Resources.Resources.setting
        Me.btnSettings.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSettings.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(8)
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSettings.Controls.Add(Me.btnSettings)

        ' btnfrmPrinters
        Me.btnfrmPrinters.Name = "btnfrmPrinters"
        Me.btnfrmPrinters.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmPrinters.BorderRadius = 12
        Me.btnfrmPrinters.BorderThickness = 1
        Me.btnfrmPrinters.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmPrinters.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmPrinters.ForeColor = System.Drawing.Color.White
        Me.btnfrmPrinters.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmPrinters.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmPrinters.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmPrinters.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmPrinters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmPrinters.Text = "إعدادات الطابعات والبونات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "طابعات الكاشير والمطبخ والبار"
        Me.btnfrmPrinters.Image = Global.WindowsApp1.My.Resources.Resources.printer
        Me.btnfrmPrinters.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmPrinters.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmPrinters.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmPrinters.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmPrinters.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmPrinters.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSettings.Controls.Add(Me.btnfrmPrinters)

        ' btnBackups
        Me.btnBackups.Name = "btnBackups"
        Me.btnBackups.Size = New System.Drawing.Size(340, 95)
        Me.btnBackups.BorderRadius = 12
        Me.btnBackups.BorderThickness = 1
        Me.btnBackups.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnBackups.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnBackups.ForeColor = System.Drawing.Color.White
        Me.btnBackups.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnBackups.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnBackups.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnBackups.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnBackups.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnBackups.Text = "النسخ الاحتياطي والأمان" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "أخذ واستعادة النسخ الاحتياطية"
        Me.btnBackups.Image = Global.WindowsApp1.My.Resources.Resources.backup
        Me.btnBackups.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnBackups.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnBackups.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBackups.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnBackups.Margin = New System.Windows.Forms.Padding(8)
        Me.btnBackups.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSettings.Controls.Add(Me.btnBackups)

        ' btnfrmRestaurantSections
        Me.btnfrmRestaurantSections.Name = "btnfrmRestaurantSections"
        Me.btnfrmRestaurantSections.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmRestaurantSections.BorderRadius = 12
        Me.btnfrmRestaurantSections.BorderThickness = 1
        Me.btnfrmRestaurantSections.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmRestaurantSections.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmRestaurantSections.ForeColor = System.Drawing.Color.White
        Me.btnfrmRestaurantSections.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmRestaurantSections.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmRestaurantSections.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmRestaurantSections.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmRestaurantSections.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmRestaurantSections.Text = "أقسام المطعم" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "صالة العائلات، الأفراد، التيك أواي"
        Me.btnfrmRestaurantSections.Image = Global.WindowsApp1.My.Resources.Resources.dinning_hall
        Me.btnfrmRestaurantSections.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmRestaurantSections.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmRestaurantSections.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmRestaurantSections.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmRestaurantSections.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmRestaurantSections.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSettings.Controls.Add(Me.btnfrmRestaurantSections)

        ' btnfrmRestaurantTables
        Me.btnfrmRestaurantTables.Name = "btnfrmRestaurantTables"
        Me.btnfrmRestaurantTables.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmRestaurantTables.BorderRadius = 12
        Me.btnfrmRestaurantTables.BorderThickness = 1
        Me.btnfrmRestaurantTables.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmRestaurantTables.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmRestaurantTables.ForeColor = System.Drawing.Color.White
        Me.btnfrmRestaurantTables.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmRestaurantTables.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmRestaurantTables.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmRestaurantTables.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmRestaurantTables.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmRestaurantTables.Text = "طاولات المطعم وتوزيعها" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تسمية وتوزيع طاولات الصالة"
        Me.btnfrmRestaurantTables.Image = Global.WindowsApp1.My.Resources.Resources.round_table
        Me.btnfrmRestaurantTables.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmRestaurantTables.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmRestaurantTables.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmRestaurantTables.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmRestaurantTables.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmRestaurantTables.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSettings.Controls.Add(Me.btnfrmRestaurantTables)

        ' btnfrmColors
        Me.btnfrmColors.Name = "btnfrmColors"
        Me.btnfrmColors.Size = New System.Drawing.Size(340, 95)
        Me.btnfrmColors.BorderRadius = 12
        Me.btnfrmColors.BorderThickness = 1
        Me.btnfrmColors.BorderColor = System.Drawing.Color.FromArgb(35, 45, 63)
        Me.btnfrmColors.FillColor = System.Drawing.Color.FromArgb(20, 25, 36)
        Me.btnfrmColors.ForeColor = System.Drawing.Color.White
        Me.btnfrmColors.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnfrmColors.HoverState.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.btnfrmColors.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnfrmColors.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnfrmColors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnfrmColors.Text = "ألوان ومظهر الشاشات" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تخصيص ثيم وألوان شاشات النظام"
        Me.btnfrmColors.Image = Global.WindowsApp1.My.Resources.Resources.color_palette
        Me.btnfrmColors.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnfrmColors.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnfrmColors.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnfrmColors.TextOffset = New System.Drawing.Point(5, 0)
        Me.btnfrmColors.Margin = New System.Windows.Forms.Padding(8)
        Me.btnfrmColors.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flpSettings.Controls.Add(Me.btnfrmColors)

        ' =================== MainForm ===================
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1400, 850)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.KeyPreview = True
        Me.DoubleBuffered = True
        Me.Controls.Add(Me.pnlMainContainer)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.statusStripMain)
        Me.Controls.Add(Me.panelHeader)

        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSidebar.ResumeLayout(False)
        Me.flpNav.ResumeLayout(False)
        Me.statusStripMain.ResumeLayout(False)
        Me.statusStripMain.PerformLayout()
        Me.pnlMainContainer.ResumeLayout(False)
        Me.viewDashboard.ResumeLayout(False)
        Me.pnlWelcome.ResumeLayout(False)
        Me.pnlWelcome.PerformLayout()
        Me.pnlDashboardBody.ResumeLayout(False)
        Me.pnlQuickButtons.ResumeLayout(False)
        Me.tlpQuickBtns.ResumeLayout(False)
        Me.tlpStats.ResumeLayout(False)
        Me.cardSales.ResumeLayout(False)
        CType(Me.picCardSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardPurchases.ResumeLayout(False)
        CType(Me.picCardPurchases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardProfit.ResumeLayout(False)
        CType(Me.picCardProfit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardProducts.ResumeLayout(False)
        CType(Me.picCardProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardCustomers.ResumeLayout(False)
        CType(Me.picCardCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardSuppliers.ResumeLayout(False)
        CType(Me.picCardSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMainContent.ResumeLayout(False)
        Me.cardRecentInvoices.ResumeLayout(False)
        Me.pnlInvoicesHeader.ResumeLayout(False)
        CType(Me.dgvRecentInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardAlerts.ResumeLayout(False)
        Me.pnlAlertsHeader.ResumeLayout(False)
        Me.pnlAlertsContainer.ResumeLayout(False)
        Me.cardAlertStock.ResumeLayout(False)
        Me.cardAlertShift.ResumeLayout(False)
        Me.cardAlertBackup.ResumeLayout(False)
        Me.viewSales.ResumeLayout(False)
        Me.pnlHeaderSales.ResumeLayout(False)
        Me.pnlHeaderSales.PerformLayout()
        CType(Me.picHeaderSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpSales.ResumeLayout(False)
        Me.viewSystem.ResumeLayout(False)
        Me.pnlHeaderSystem.ResumeLayout(False)
        Me.pnlHeaderSystem.PerformLayout()
        CType(Me.picHeaderSystem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpSystem.ResumeLayout(False)
        Me.viewInventory.ResumeLayout(False)
        Me.pnlHeaderInventory.ResumeLayout(False)
        Me.pnlHeaderInventory.PerformLayout()
        CType(Me.picHeaderInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpInventory.ResumeLayout(False)
        Me.viewPurchases.ResumeLayout(False)
        Me.pnlHeaderPurchases.ResumeLayout(False)
        Me.pnlHeaderPurchases.PerformLayout()
        CType(Me.picHeaderPurchases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpPurchases.ResumeLayout(False)
        Me.viewCustomers.ResumeLayout(False)
        Me.pnlHeaderCustomers.ResumeLayout(False)
        Me.pnlHeaderCustomers.PerformLayout()
        CType(Me.picHeaderCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpCustomers.ResumeLayout(False)
        Me.viewSuppliers.ResumeLayout(False)
        Me.pnlHeaderSuppliers.ResumeLayout(False)
        Me.pnlHeaderSuppliers.PerformLayout()
        CType(Me.picHeaderSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpSuppliers.ResumeLayout(False)
        Me.viewTreasury.ResumeLayout(False)
        Me.pnlHeaderTreasury.ResumeLayout(False)
        Me.pnlHeaderTreasury.PerformLayout()
        CType(Me.picHeaderTreasury, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpTreasury.ResumeLayout(False)
        Me.viewExpenses.ResumeLayout(False)
        Me.pnlHeaderExpenses.ResumeLayout(False)
        Me.pnlHeaderExpenses.PerformLayout()
        CType(Me.picHeaderExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpExpenses.ResumeLayout(False)
        Me.viewEmployees.ResumeLayout(False)
        Me.pnlHeaderEmployees.ResumeLayout(False)
        Me.pnlHeaderEmployees.PerformLayout()
        CType(Me.picHeaderEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpEmployees.ResumeLayout(False)
        Me.viewUsers.ResumeLayout(False)
        Me.pnlHeaderUsers.ResumeLayout(False)
        Me.pnlHeaderUsers.PerformLayout()
        CType(Me.picHeaderUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpUsers.ResumeLayout(False)
        Me.viewSettings.ResumeLayout(False)
        Me.pnlHeaderSettings.ResumeLayout(False)
        Me.pnlHeaderSettings.PerformLayout()
        CType(Me.picHeaderSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpSettings.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    ' Declarations
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents picLogo As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lbltitle As System.Windows.Forms.Label
    Friend WithEvents lblProBadge As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtGlobalSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblHeaderBranch As System.Windows.Forms.Label
    Friend WithEvents lblStatusUserRole As System.Windows.Forms.Label
    Friend WithEvents btnSupport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2Button

    Friend WithEvents pnlSidebar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents flpNav As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents navDashboard As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navSales As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navSystem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navInventory As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navPurchases As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navCustomers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navSuppliers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navTreasury As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navExpenses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navEmployees As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navUsers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navSettings As Guna.UI2.WinForms.Guna2Button

    Friend WithEvents statusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatusDb As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusRole As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusBranch As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusShift As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusDateTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusVersion As System.Windows.Forms.ToolStripStatusLabel

    Friend WithEvents pnlMainContainer As System.Windows.Forms.Panel
    Friend WithEvents viewDashboard As System.Windows.Forms.Panel
    Friend WithEvents pnlWelcome As System.Windows.Forms.Panel
    Friend WithEvents lblWelcomeGreeting As System.Windows.Forms.Label
    Friend WithEvents lblWelcomeSub As System.Windows.Forms.Label
    Friend WithEvents lblShiftDuration As System.Windows.Forms.Label
    Friend WithEvents btnRefreshDashboard As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlDashboardBody As System.Windows.Forms.Panel
    Friend WithEvents pnlQuickButtons As System.Windows.Forms.Panel
    Friend WithEvents lblQuickTitle As System.Windows.Forms.Label
    Friend WithEvents tlpQuickBtns As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnQuickPOS As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnQuickProducts As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnQuickCustomers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnQuickBackup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tlpStats As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cardSales As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardSalesTitle As System.Windows.Forms.Label
    Friend WithEvents lblCardSalesVal As System.Windows.Forms.Label
    Friend WithEvents lblCardSalesSub As System.Windows.Forms.Label
    Friend WithEvents picCardSales As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardPurchases As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardPurchasesTitle As System.Windows.Forms.Label
    Friend WithEvents lblCardPurchasesVal As System.Windows.Forms.Label
    Friend WithEvents lblCardPurchasesSub As System.Windows.Forms.Label
    Friend WithEvents picCardPurchases As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardProfit As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardProfitTitle As System.Windows.Forms.Label
    Friend WithEvents lblCardProfitVal As System.Windows.Forms.Label
    Friend WithEvents lblCardProfitSub As System.Windows.Forms.Label
    Friend WithEvents picCardProfit As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardProducts As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardProductsTitle As System.Windows.Forms.Label
    Friend WithEvents lblCardProductsVal As System.Windows.Forms.Label
    Friend WithEvents lblCardProductsSub As System.Windows.Forms.Label
    Friend WithEvents picCardProducts As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardCustomers As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardCustomersTitle As System.Windows.Forms.Label
    Friend WithEvents lblCardCustomersVal As System.Windows.Forms.Label
    Friend WithEvents lblCardCustomersSub As System.Windows.Forms.Label
    Friend WithEvents picCardCustomers As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents cardSuppliers As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardSuppliersTitle As System.Windows.Forms.Label
    Friend WithEvents lblCardSuppliersVal As System.Windows.Forms.Label
    Friend WithEvents lblCardSuppliersSub As System.Windows.Forms.Label
    Friend WithEvents picCardSuppliers As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents tlpMainContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cardRecentInvoices As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlInvoicesHeader As System.Windows.Forms.Panel
    Friend WithEvents lblRecentInvoicesTitle As System.Windows.Forms.Label
    Friend WithEvents btnViewAllInvoices As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgvRecentInvoices As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents colInvNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvCustomer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvPayment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cardAlerts As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlAlertsHeader As System.Windows.Forms.Panel
    Friend WithEvents lblAlertsTitle As System.Windows.Forms.Label
    Friend WithEvents pnlAlertsContainer As System.Windows.Forms.Panel
    Friend WithEvents cardAlertStock As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblAlertStockTitle As System.Windows.Forms.Label
    Friend WithEvents lblAlertStockDesc As System.Windows.Forms.Label
    Friend WithEvents cardAlertShift As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblAlertShiftTitle As System.Windows.Forms.Label
    Friend WithEvents lblAlertShiftDesc As System.Windows.Forms.Label
    Friend WithEvents cardAlertBackup As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblAlertBackupTitle As System.Windows.Forms.Label
    Friend WithEvents lblAlertBackupDesc As System.Windows.Forms.Label
    Friend WithEvents tmrClock As System.Windows.Forms.Timer
    Friend WithEvents tmrDashboardRefresh As System.Windows.Forms.Timer

    ' View Sales
    Friend WithEvents viewSales As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderSales As System.Windows.Forms.Panel
    Friend WithEvents picHeaderSales As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleSales As System.Windows.Forms.Label
    Friend WithEvents lblDescSales As System.Windows.Forms.Label
    Friend WithEvents btnBackSales As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpSales As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnfrmPOS As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSalesReturns As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFrmSalesReport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFrmDriverReport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnKds As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnWaste As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRes As Guna.UI2.WinForms.Guna2Button

    ' View System
    Friend WithEvents viewSystem As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderSystem As System.Windows.Forms.Panel
    Friend WithEvents picHeaderSystem As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleSystem As System.Windows.Forms.Label
    Friend WithEvents lblDescSystem As System.Windows.Forms.Label
    Friend WithEvents btnBackSystem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpSystem As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCategories As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnProducts As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmProductSizes As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmProductAddons As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmKitchenComments As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmDeliveryAreas As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmDeliveryDrivers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmShifts As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnShiftReports As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmBranches As Guna.UI2.WinForms.Guna2Button

    ' View Inventory
    Friend WithEvents viewInventory As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderInventory As System.Windows.Forms.Panel
    Friend WithEvents picHeaderInventory As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleInventory As System.Windows.Forms.Label
    Friend WithEvents lblDescInventory As System.Windows.Forms.Label
    Friend WithEvents btnBackInventory As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpInventory As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnfrmStoreStock As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmRawMaterials As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmRecipes As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmStores As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmUnits As Guna.UI2.WinForms.Guna2Button

    ' View Purchases
    Friend WithEvents viewPurchases As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderPurchases As System.Windows.Forms.Panel
    Friend WithEvents picHeaderPurchases As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitlePurchases As System.Windows.Forms.Label
    Friend WithEvents lblDescPurchases As System.Windows.Forms.Label
    Friend WithEvents btnBackPurchases As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpPurchases As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnfrmPurchases As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmPurchaseReports As Guna.UI2.WinForms.Guna2Button

    ' View Customers
    Friend WithEvents viewCustomers As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderCustomers As System.Windows.Forms.Panel
    Friend WithEvents picHeaderCustomers As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleCustomers As System.Windows.Forms.Label
    Friend WithEvents lblDescCustomers As System.Windows.Forms.Label
    Friend WithEvents btnBackCustomers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpCustomers As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnFrmCustomers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFrmCustomerStatement As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCustomerBalanceDownload As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ToolStripButton11 As Guna.UI2.WinForms.Guna2Button

    ' View Suppliers
    Friend WithEvents viewSuppliers As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderSuppliers As System.Windows.Forms.Panel
    Friend WithEvents picHeaderSuppliers As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleSuppliers As System.Windows.Forms.Label
    Friend WithEvents lblDescSuppliers As System.Windows.Forms.Label
    Friend WithEvents btnBackSuppliers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpSuppliers As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ToolStripButton3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ToolStripButton4 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ToolStripButton5 As Guna.UI2.WinForms.Guna2Button

    ' View Treasury
    Friend WithEvents viewTreasury As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderTreasury As System.Windows.Forms.Panel
    Friend WithEvents picHeaderTreasury As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleTreasury As System.Windows.Forms.Label
    Friend WithEvents lblDescTreasury As System.Windows.Forms.Label
    Friend WithEvents btnBackTreasury As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpTreasury As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnfrmTreasury As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFrmTreasuryTransfer As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeposit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnWithdraw As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFrmTreasuryTransactionsReport As Guna.UI2.WinForms.Guna2Button

    ' View Expenses
    Friend WithEvents viewExpenses As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderExpenses As System.Windows.Forms.Panel
    Friend WithEvents picHeaderExpenses As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleExpenses As System.Windows.Forms.Label
    Friend WithEvents lblDescExpenses As System.Windows.Forms.Label
    Friend WithEvents btnBackExpenses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpExpenses As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnform_Expenses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExpensesReportForm As Guna.UI2.WinForms.Guna2Button

    ' View Employees
    Friend WithEvents viewEmployees As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderEmployees As System.Windows.Forms.Panel
    Friend WithEvents picHeaderEmployees As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleEmployees As System.Windows.Forms.Label
    Friend WithEvents lblDescEmployees As System.Windows.Forms.Label
    Friend WithEvents btnBackEmployees As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpEmployees As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnfrmEmployees As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmJobTitles As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmDepartments As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmSalarySystems As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmSalaryPayment As Guna.UI2.WinForms.Guna2Button

    ' View Users
    Friend WithEvents viewUsers As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderUsers As System.Windows.Forms.Panel
    Friend WithEvents picHeaderUsers As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleUsers As System.Windows.Forms.Label
    Friend WithEvents lblDescUsers As System.Windows.Forms.Label
    Friend WithEvents btnBackUsers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpUsers As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnfrmUsers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmRolesAndPermissions As Guna.UI2.WinForms.Guna2Button

    ' View Settings
    Friend WithEvents viewSettings As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderSettings As System.Windows.Forms.Panel
    Friend WithEvents picHeaderSettings As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblTitleSettings As System.Windows.Forms.Label
    Friend WithEvents lblDescSettings As System.Windows.Forms.Label
    Friend WithEvents btnBackSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpSettings As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmPrinters As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnBackups As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmRestaurantSections As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmRestaurantTables As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnfrmColors As Guna.UI2.WinForms.Guna2Button

End Class