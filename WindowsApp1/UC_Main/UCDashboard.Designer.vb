Namespace UC_Main
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCDashboard
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlWelcome = New System.Windows.Forms.Panel()
            Me.lblWelcomeGreeting = New System.Windows.Forms.Label()
            Me.lblWelcomeSub = New System.Windows.Forms.Label()
            Me.lblShiftDuration = New System.Windows.Forms.Label()
            Me.btnRefreshDashboard = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlDashboardBody = New System.Windows.Forms.Panel()
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
            Me.lblRecentInvoicesTitle = New System.Windows.Forms.Label()
            Me.btnViewAllInvoices = New Guna.UI2.WinForms.Guna2Button()
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
            Me.pnlQuickButtons = New System.Windows.Forms.Panel()
            Me.tlpQuickBtns = New System.Windows.Forms.TableLayoutPanel()
            Me.btnQuickPOS = New Guna.UI2.WinForms.Guna2Button()
            Me.btnQuickProducts = New Guna.UI2.WinForms.Guna2Button()
            Me.btnQuickCustomers = New Guna.UI2.WinForms.Guna2Button()
            Me.btnQuickBackup = New Guna.UI2.WinForms.Guna2Button()
            Me.lblQuickTitle = New System.Windows.Forms.Label()
            Me.pnlWelcome.SuspendLayout()
            Me.pnlDashboardBody.SuspendLayout()
            Me.tlpMainContent.SuspendLayout()
            Me.cardRecentInvoices.SuspendLayout()
            CType(Me.dgvRecentInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlInvoicesHeader.SuspendLayout()
            Me.cardAlerts.SuspendLayout()
            Me.pnlAlertsContainer.SuspendLayout()
            Me.cardAlertBackup.SuspendLayout()
            Me.cardAlertShift.SuspendLayout()
            Me.cardAlertStock.SuspendLayout()
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
            Me.pnlQuickButtons.SuspendLayout()
            Me.tlpQuickBtns.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlWelcome
            '
            Me.pnlWelcome.Controls.Add(Me.lblWelcomeGreeting)
            Me.pnlWelcome.Controls.Add(Me.lblWelcomeSub)
            Me.pnlWelcome.Controls.Add(Me.lblShiftDuration)
            Me.pnlWelcome.Controls.Add(Me.btnRefreshDashboard)
            Me.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlWelcome.Location = New System.Drawing.Point(0, 0)
            Me.pnlWelcome.Name = "pnlWelcome"
            Me.pnlWelcome.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
            Me.pnlWelcome.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.pnlWelcome.Size = New System.Drawing.Size(1180, 65)
            Me.pnlWelcome.TabIndex = 0
            '
            'lblWelcomeGreeting
            '
            Me.lblWelcomeGreeting.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblWelcomeGreeting.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblWelcomeGreeting.ForeColor = System.Drawing.Color.White
            Me.lblWelcomeGreeting.Location = New System.Drawing.Point(623, 10)
            Me.lblWelcomeGreeting.Name = "lblWelcomeGreeting"
            Me.lblWelcomeGreeting.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblWelcomeGreeting.Size = New System.Drawing.Size(266, 45)
            Me.lblWelcomeGreeting.TabIndex = 0
            Me.lblWelcomeGreeting.Text = "صباح الخير، المدير العام"
            Me.lblWelcomeGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblWelcomeSub
            '
            Me.lblWelcomeSub.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblWelcomeSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblWelcomeSub.Location = New System.Drawing.Point(889, 10)
            Me.lblWelcomeSub.Name = "lblWelcomeSub"
            Me.lblWelcomeSub.Padding = New System.Windows.Forms.Padding(0, 5, 20, 0)
            Me.lblWelcomeSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblWelcomeSub.Size = New System.Drawing.Size(271, 45)
            Me.lblWelcomeSub.TabIndex = 1
            Me.lblWelcomeSub.Text = "لوحة المؤشرات والعمليات اليومية لنظام نقاط البيع"
            Me.lblWelcomeSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblShiftDuration
            '
            Me.lblShiftDuration.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblShiftDuration.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblShiftDuration.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
            Me.lblShiftDuration.Location = New System.Drawing.Point(165, 10)
            Me.lblShiftDuration.Name = "lblShiftDuration"
            Me.lblShiftDuration.Padding = New System.Windows.Forms.Padding(15, 8, 15, 0)
            Me.lblShiftDuration.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblShiftDuration.Size = New System.Drawing.Size(175, 45)
            Me.lblShiftDuration.TabIndex = 2
            Me.lblShiftDuration.Text = "الوردية: جار التحميل..."
            Me.lblShiftDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnRefreshDashboard
            '
            Me.btnRefreshDashboard.BackColor = System.Drawing.Color.Transparent
            Me.btnRefreshDashboard.BorderRadius = 8
            Me.btnRefreshDashboard.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefreshDashboard.Dock = System.Windows.Forms.DockStyle.Left
            Me.btnRefreshDashboard.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnRefreshDashboard.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnRefreshDashboard.ForeColor = System.Drawing.Color.White
            Me.btnRefreshDashboard.Image = Global.WindowsApp1.My.Resources.Resources.sync
            Me.btnRefreshDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnRefreshDashboard.ImageSize = New System.Drawing.Size(18, 18)
            Me.btnRefreshDashboard.Location = New System.Drawing.Point(20, 10)
            Me.btnRefreshDashboard.Name = "btnRefreshDashboard"
            Me.btnRefreshDashboard.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnRefreshDashboard.Size = New System.Drawing.Size(145, 45)
            Me.btnRefreshDashboard.TabIndex = 3
            Me.btnRefreshDashboard.Text = "  تحديث البيانات"
            '
            'pnlDashboardBody
            '
            Me.pnlDashboardBody.AutoScroll = True
            Me.pnlDashboardBody.Controls.Add(Me.tlpMainContent)
            Me.pnlDashboardBody.Controls.Add(Me.tlpStats)
            Me.pnlDashboardBody.Controls.Add(Me.pnlQuickButtons)
            Me.pnlDashboardBody.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlDashboardBody.Location = New System.Drawing.Point(0, 65)
            Me.pnlDashboardBody.Name = "pnlDashboardBody"
            Me.pnlDashboardBody.Padding = New System.Windows.Forms.Padding(20, 0, 20, 20)
            Me.pnlDashboardBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.pnlDashboardBody.Size = New System.Drawing.Size(1180, 693)
            Me.pnlDashboardBody.TabIndex = 1
            '
            'tlpMainContent
            '
            Me.tlpMainContent.ColumnCount = 2
            Me.tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
            Me.tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
            Me.tlpMainContent.Controls.Add(Me.cardRecentInvoices, 0, 0)
            Me.tlpMainContent.Controls.Add(Me.cardAlerts, 1, 0)
            Me.tlpMainContent.Dock = System.Windows.Forms.DockStyle.Top
            Me.tlpMainContent.Location = New System.Drawing.Point(20, 205)
            Me.tlpMainContent.Margin = New System.Windows.Forms.Padding(0, 10, 0, 10)
            Me.tlpMainContent.Name = "tlpMainContent"
            Me.tlpMainContent.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.tlpMainContent.Size = New System.Drawing.Size(1140, 360)
            Me.tlpMainContent.TabIndex = 0
            '
            'cardRecentInvoices
            '
            Me.cardRecentInvoices.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardRecentInvoices.BorderRadius = 12
            Me.cardRecentInvoices.BorderThickness = 1
            Me.cardRecentInvoices.Controls.Add(Me.dgvRecentInvoices)
            Me.cardRecentInvoices.Controls.Add(Me.pnlInvoicesHeader)
            Me.cardRecentInvoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardRecentInvoices.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardRecentInvoices.Location = New System.Drawing.Point(404, 5)
            Me.cardRecentInvoices.Margin = New System.Windows.Forms.Padding(5)
            Me.cardRecentInvoices.Name = "cardRecentInvoices"
            Me.cardRecentInvoices.Padding = New System.Windows.Forms.Padding(12)
            Me.cardRecentInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardRecentInvoices.Size = New System.Drawing.Size(731, 350)
            Me.cardRecentInvoices.TabIndex = 0
            '
            'dgvRecentInvoices
            '
            Me.dgvRecentInvoices.AllowUserToAddRows = False
            Me.dgvRecentInvoices.AllowUserToDeleteRows = False
            Me.dgvRecentInvoices.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
            DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRecentInvoices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvRecentInvoices.ColumnHeadersHeight = 50
            Me.dgvRecentInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            Me.dgvRecentInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInvNum, Me.colInvTime, Me.colInvCustomer, Me.colInvType, Me.colInvTotal, Me.colInvPayment})
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvRecentInvoices.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvRecentInvoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvRecentInvoices.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.dgvRecentInvoices.Location = New System.Drawing.Point(12, 47)
            Me.dgvRecentInvoices.Name = "dgvRecentInvoices"
            Me.dgvRecentInvoices.ReadOnly = True
            Me.dgvRecentInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.dgvRecentInvoices.RowHeadersVisible = False
            Me.dgvRecentInvoices.Size = New System.Drawing.Size(707, 291)
            Me.dgvRecentInvoices.TabIndex = 0
            Me.dgvRecentInvoices.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.dgvRecentInvoices.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!)
            Me.dgvRecentInvoices.ThemeStyle.HeaderStyle.Height = 50
            Me.dgvRecentInvoices.ThemeStyle.ReadOnly = True
            Me.dgvRecentInvoices.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!)
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
            Me.colInvType.HeaderText = "النوع"
            Me.colInvType.Name = "colInvType"
            Me.colInvType.ReadOnly = True
            '
            'colInvTotal
            '
            Me.colInvTotal.HeaderText = "الإجمالي"
            Me.colInvTotal.Name = "colInvTotal"
            Me.colInvTotal.ReadOnly = True
            '
            'colInvPayment
            '
            Me.colInvPayment.HeaderText = "طريقة الدفع"
            Me.colInvPayment.Name = "colInvPayment"
            Me.colInvPayment.ReadOnly = True
            '
            'pnlInvoicesHeader
            '
            Me.pnlInvoicesHeader.Controls.Add(Me.lblRecentInvoicesTitle)
            Me.pnlInvoicesHeader.Controls.Add(Me.btnViewAllInvoices)
            Me.pnlInvoicesHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlInvoicesHeader.Location = New System.Drawing.Point(12, 12)
            Me.pnlInvoicesHeader.Name = "pnlInvoicesHeader"
            Me.pnlInvoicesHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.pnlInvoicesHeader.Size = New System.Drawing.Size(707, 35)
            Me.pnlInvoicesHeader.TabIndex = 1
            '
            'lblRecentInvoicesTitle
            '
            Me.lblRecentInvoicesTitle.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblRecentInvoicesTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblRecentInvoicesTitle.ForeColor = System.Drawing.Color.White
            Me.lblRecentInvoicesTitle.Location = New System.Drawing.Point(607, 0)
            Me.lblRecentInvoicesTitle.Name = "lblRecentInvoicesTitle"
            Me.lblRecentInvoicesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblRecentInvoicesTitle.Size = New System.Drawing.Size(100, 35)
            Me.lblRecentInvoicesTitle.TabIndex = 0
            Me.lblRecentInvoicesTitle.Text = "آخر فواتير المبيعات الصادرة"
            '
            'btnViewAllInvoices
            '
            Me.btnViewAllInvoices.BorderRadius = 6
            Me.btnViewAllInvoices.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnViewAllInvoices.Dock = System.Windows.Forms.DockStyle.Left
            Me.btnViewAllInvoices.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnViewAllInvoices.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.btnViewAllInvoices.ForeColor = System.Drawing.Color.White
            Me.btnViewAllInvoices.Location = New System.Drawing.Point(0, 0)
            Me.btnViewAllInvoices.Name = "btnViewAllInvoices"
            Me.btnViewAllInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnViewAllInvoices.Size = New System.Drawing.Size(110, 35)
            Me.btnViewAllInvoices.TabIndex = 1
            Me.btnViewAllInvoices.Text = "عرض الكل ↗"
            '
            'cardAlerts
            '
            Me.cardAlerts.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardAlerts.BorderRadius = 12
            Me.cardAlerts.BorderThickness = 1
            Me.cardAlerts.Controls.Add(Me.pnlAlertsContainer)
            Me.cardAlerts.Controls.Add(Me.pnlAlertsHeader)
            Me.cardAlerts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardAlerts.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardAlerts.Location = New System.Drawing.Point(5, 5)
            Me.cardAlerts.Margin = New System.Windows.Forms.Padding(5)
            Me.cardAlerts.Name = "cardAlerts"
            Me.cardAlerts.Padding = New System.Windows.Forms.Padding(12)
            Me.cardAlerts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardAlerts.Size = New System.Drawing.Size(389, 350)
            Me.cardAlerts.TabIndex = 1
            '
            'pnlAlertsContainer
            '
            Me.pnlAlertsContainer.Controls.Add(Me.cardAlertBackup)
            Me.pnlAlertsContainer.Controls.Add(Me.cardAlertShift)
            Me.pnlAlertsContainer.Controls.Add(Me.cardAlertStock)
            Me.pnlAlertsContainer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlAlertsContainer.Location = New System.Drawing.Point(12, 47)
            Me.pnlAlertsContainer.Name = "pnlAlertsContainer"
            Me.pnlAlertsContainer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.pnlAlertsContainer.Size = New System.Drawing.Size(365, 291)
            Me.pnlAlertsContainer.TabIndex = 0
            '
            'cardAlertBackup
            '
            Me.cardAlertBackup.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardAlertBackup.BorderRadius = 8
            Me.cardAlertBackup.BorderThickness = 1
            Me.cardAlertBackup.Controls.Add(Me.lblAlertBackupDesc)
            Me.cardAlertBackup.Controls.Add(Me.lblAlertBackupTitle)
            Me.cardAlertBackup.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardAlertBackup.Dock = System.Windows.Forms.DockStyle.Top
            Me.cardAlertBackup.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.cardAlertBackup.Location = New System.Drawing.Point(0, 140)
            Me.cardAlertBackup.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
            Me.cardAlertBackup.Name = "cardAlertBackup"
            Me.cardAlertBackup.Padding = New System.Windows.Forms.Padding(10)
            Me.cardAlertBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardAlertBackup.Size = New System.Drawing.Size(365, 70)
            Me.cardAlertBackup.TabIndex = 0
            '
            'lblAlertBackupDesc
            '
            Me.lblAlertBackupDesc.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblAlertBackupDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
            Me.lblAlertBackupDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblAlertBackupDesc.Location = New System.Drawing.Point(10, 33)
            Me.lblAlertBackupDesc.Name = "lblAlertBackupDesc"
            Me.lblAlertBackupDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblAlertBackupDesc.Size = New System.Drawing.Size(345, 23)
            Me.lblAlertBackupDesc.TabIndex = 0
            Me.lblAlertBackupDesc.Text = "النظام مؤمن بنسخ احتياطي مجدول"
            '
            'lblAlertBackupTitle
            '
            Me.lblAlertBackupTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblAlertBackupTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblAlertBackupTitle.ForeColor = System.Drawing.Color.White
            Me.lblAlertBackupTitle.Location = New System.Drawing.Point(10, 10)
            Me.lblAlertBackupTitle.Name = "lblAlertBackupTitle"
            Me.lblAlertBackupTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblAlertBackupTitle.Size = New System.Drawing.Size(345, 23)
            Me.lblAlertBackupTitle.TabIndex = 1
            Me.lblAlertBackupTitle.Text = "النسخ الاحتياطي"
            '
            'cardAlertShift
            '
            Me.cardAlertShift.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardAlertShift.BorderRadius = 8
            Me.cardAlertShift.BorderThickness = 1
            Me.cardAlertShift.Controls.Add(Me.lblAlertShiftDesc)
            Me.cardAlertShift.Controls.Add(Me.lblAlertShiftTitle)
            Me.cardAlertShift.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardAlertShift.Dock = System.Windows.Forms.DockStyle.Top
            Me.cardAlertShift.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.cardAlertShift.Location = New System.Drawing.Point(0, 70)
            Me.cardAlertShift.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
            Me.cardAlertShift.Name = "cardAlertShift"
            Me.cardAlertShift.Padding = New System.Windows.Forms.Padding(10)
            Me.cardAlertShift.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardAlertShift.Size = New System.Drawing.Size(365, 70)
            Me.cardAlertShift.TabIndex = 1
            '
            'lblAlertShiftDesc
            '
            Me.lblAlertShiftDesc.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblAlertShiftDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
            Me.lblAlertShiftDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblAlertShiftDesc.Location = New System.Drawing.Point(10, 33)
            Me.lblAlertShiftDesc.Name = "lblAlertShiftDesc"
            Me.lblAlertShiftDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblAlertShiftDesc.Size = New System.Drawing.Size(345, 23)
            Me.lblAlertShiftDesc.TabIndex = 0
            Me.lblAlertShiftDesc.Text = "الوردية مفتوحة وتعمل بكفاءة"
            '
            'lblAlertShiftTitle
            '
            Me.lblAlertShiftTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblAlertShiftTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblAlertShiftTitle.ForeColor = System.Drawing.Color.White
            Me.lblAlertShiftTitle.Location = New System.Drawing.Point(10, 10)
            Me.lblAlertShiftTitle.Name = "lblAlertShiftTitle"
            Me.lblAlertShiftTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblAlertShiftTitle.Size = New System.Drawing.Size(345, 23)
            Me.lblAlertShiftTitle.TabIndex = 1
            Me.lblAlertShiftTitle.Text = "الوردية النشطة"
            '
            'cardAlertStock
            '
            Me.cardAlertStock.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardAlertStock.BorderRadius = 8
            Me.cardAlertStock.BorderThickness = 1
            Me.cardAlertStock.Controls.Add(Me.lblAlertStockDesc)
            Me.cardAlertStock.Controls.Add(Me.lblAlertStockTitle)
            Me.cardAlertStock.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardAlertStock.Dock = System.Windows.Forms.DockStyle.Top
            Me.cardAlertStock.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
            Me.cardAlertStock.Location = New System.Drawing.Point(0, 0)
            Me.cardAlertStock.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
            Me.cardAlertStock.Name = "cardAlertStock"
            Me.cardAlertStock.Padding = New System.Windows.Forms.Padding(10)
            Me.cardAlertStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardAlertStock.Size = New System.Drawing.Size(365, 70)
            Me.cardAlertStock.TabIndex = 2
            '
            'lblAlertStockDesc
            '
            Me.lblAlertStockDesc.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblAlertStockDesc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
            Me.lblAlertStockDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblAlertStockDesc.Location = New System.Drawing.Point(10, 33)
            Me.lblAlertStockDesc.Name = "lblAlertStockDesc"
            Me.lblAlertStockDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblAlertStockDesc.Size = New System.Drawing.Size(345, 23)
            Me.lblAlertStockDesc.TabIndex = 0
            Me.lblAlertStockDesc.Text = "لا توجد أصناف تحت حد الطلب الأدنى حالياً"
            '
            'lblAlertStockTitle
            '
            Me.lblAlertStockTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblAlertStockTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblAlertStockTitle.ForeColor = System.Drawing.Color.White
            Me.lblAlertStockTitle.Location = New System.Drawing.Point(10, 10)
            Me.lblAlertStockTitle.Name = "lblAlertStockTitle"
            Me.lblAlertStockTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblAlertStockTitle.Size = New System.Drawing.Size(345, 23)
            Me.lblAlertStockTitle.TabIndex = 1
            Me.lblAlertStockTitle.Text = "المخزون سليم"
            '
            'pnlAlertsHeader
            '
            Me.pnlAlertsHeader.Controls.Add(Me.lblAlertsTitle)
            Me.pnlAlertsHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlAlertsHeader.Location = New System.Drawing.Point(12, 12)
            Me.pnlAlertsHeader.Name = "pnlAlertsHeader"
            Me.pnlAlertsHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.pnlAlertsHeader.Size = New System.Drawing.Size(365, 35)
            Me.pnlAlertsHeader.TabIndex = 1
            '
            'lblAlertsTitle
            '
            Me.lblAlertsTitle.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblAlertsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblAlertsTitle.ForeColor = System.Drawing.Color.White
            Me.lblAlertsTitle.Location = New System.Drawing.Point(265, 0)
            Me.lblAlertsTitle.Name = "lblAlertsTitle"
            Me.lblAlertsTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblAlertsTitle.Size = New System.Drawing.Size(100, 35)
            Me.lblAlertsTitle.TabIndex = 0
            Me.lblAlertsTitle.Text = "تنبيهات وحالة النظام"
            '
            'tlpStats
            '
            Me.tlpStats.ColumnCount = 6
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
            Me.tlpStats.Dock = System.Windows.Forms.DockStyle.Top
            Me.tlpStats.Location = New System.Drawing.Point(20, 90)
            Me.tlpStats.Margin = New System.Windows.Forms.Padding(0, 10, 0, 10)
            Me.tlpStats.Name = "tlpStats"
            Me.tlpStats.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.tlpStats.Size = New System.Drawing.Size(1140, 115)
            Me.tlpStats.TabIndex = 1
            '
            'cardSales
            '
            Me.cardSales.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardSales.BorderRadius = 12
            Me.cardSales.BorderThickness = 1
            Me.cardSales.Controls.Add(Me.lblCardSalesSub)
            Me.cardSales.Controls.Add(Me.lblCardSalesVal)
            Me.cardSales.Controls.Add(Me.lblCardSalesTitle)
            Me.cardSales.Controls.Add(Me.picCardSales)
            Me.cardSales.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardSales.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardSales.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardSales.Location = New System.Drawing.Point(956, 5)
            Me.cardSales.Margin = New System.Windows.Forms.Padding(5)
            Me.cardSales.Name = "cardSales"
            Me.cardSales.Padding = New System.Windows.Forms.Padding(10)
            Me.cardSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardSales.Size = New System.Drawing.Size(179, 105)
            Me.cardSales.TabIndex = 0
            '
            'lblCardSalesSub
            '
            Me.lblCardSalesSub.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardSalesSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
            Me.lblCardSalesSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblCardSalesSub.Location = New System.Drawing.Point(38, 56)
            Me.lblCardSalesSub.Name = "lblCardSalesSub"
            Me.lblCardSalesSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardSalesSub.Size = New System.Drawing.Size(131, 23)
            Me.lblCardSalesSub.TabIndex = 0
            Me.lblCardSalesSub.Text = "0 فاتورة اليوم"
            '
            'lblCardSalesVal
            '
            Me.lblCardSalesVal.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardSalesVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardSalesVal.ForeColor = System.Drawing.Color.White
            Me.lblCardSalesVal.Location = New System.Drawing.Point(38, 33)
            Me.lblCardSalesVal.Name = "lblCardSalesVal"
            Me.lblCardSalesVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardSalesVal.Size = New System.Drawing.Size(131, 23)
            Me.lblCardSalesVal.TabIndex = 1
            Me.lblCardSalesVal.Text = "0.00 جنية"
            '
            'lblCardSalesTitle
            '
            Me.lblCardSalesTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardSalesTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblCardSalesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblCardSalesTitle.Location = New System.Drawing.Point(38, 10)
            Me.lblCardSalesTitle.Name = "lblCardSalesTitle"
            Me.lblCardSalesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardSalesTitle.Size = New System.Drawing.Size(131, 23)
            Me.lblCardSalesTitle.TabIndex = 2
            Me.lblCardSalesTitle.Text = "مبيعات اليوم"
            '
            'picCardSales
            '
            Me.picCardSales.Dock = System.Windows.Forms.DockStyle.Left
            Me.picCardSales.Image = Global.WindowsApp1.My.Resources.Resources.nav_sales_restaurant_3d
            Me.picCardSales.ImageRotate = 0!
            Me.picCardSales.Location = New System.Drawing.Point(10, 10)
            Me.picCardSales.Name = "picCardSales"
            Me.picCardSales.Size = New System.Drawing.Size(28, 85)
            Me.picCardSales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picCardSales.TabIndex = 3
            Me.picCardSales.TabStop = False
            '
            'cardPurchases
            '
            Me.cardPurchases.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardPurchases.BorderRadius = 12
            Me.cardPurchases.BorderThickness = 1
            Me.cardPurchases.Controls.Add(Me.lblCardPurchasesSub)
            Me.cardPurchases.Controls.Add(Me.lblCardPurchasesVal)
            Me.cardPurchases.Controls.Add(Me.lblCardPurchasesTitle)
            Me.cardPurchases.Controls.Add(Me.picCardPurchases)
            Me.cardPurchases.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardPurchases.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardPurchases.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardPurchases.Location = New System.Drawing.Point(767, 5)
            Me.cardPurchases.Margin = New System.Windows.Forms.Padding(5)
            Me.cardPurchases.Name = "cardPurchases"
            Me.cardPurchases.Padding = New System.Windows.Forms.Padding(10)
            Me.cardPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardPurchases.Size = New System.Drawing.Size(179, 105)
            Me.cardPurchases.TabIndex = 1
            '
            'lblCardPurchasesSub
            '
            Me.lblCardPurchasesSub.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardPurchasesSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
            Me.lblCardPurchasesSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblCardPurchasesSub.Location = New System.Drawing.Point(38, 56)
            Me.lblCardPurchasesSub.Name = "lblCardPurchasesSub"
            Me.lblCardPurchasesSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardPurchasesSub.Size = New System.Drawing.Size(131, 23)
            Me.lblCardPurchasesSub.TabIndex = 0
            Me.lblCardPurchasesSub.Text = "0 فاتورة توريد"
            '
            'lblCardPurchasesVal
            '
            Me.lblCardPurchasesVal.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardPurchasesVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardPurchasesVal.ForeColor = System.Drawing.Color.White
            Me.lblCardPurchasesVal.Location = New System.Drawing.Point(38, 33)
            Me.lblCardPurchasesVal.Name = "lblCardPurchasesVal"
            Me.lblCardPurchasesVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardPurchasesVal.Size = New System.Drawing.Size(131, 23)
            Me.lblCardPurchasesVal.TabIndex = 1
            Me.lblCardPurchasesVal.Text = "0.00 جنية"
            '
            'lblCardPurchasesTitle
            '
            Me.lblCardPurchasesTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardPurchasesTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblCardPurchasesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblCardPurchasesTitle.Location = New System.Drawing.Point(38, 10)
            Me.lblCardPurchasesTitle.Name = "lblCardPurchasesTitle"
            Me.lblCardPurchasesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardPurchasesTitle.Size = New System.Drawing.Size(131, 23)
            Me.lblCardPurchasesTitle.TabIndex = 2
            Me.lblCardPurchasesTitle.Text = "مشتريات اليوم"
            '
            'picCardPurchases
            '
            Me.picCardPurchases.Dock = System.Windows.Forms.DockStyle.Left
            Me.picCardPurchases.Image = Global.WindowsApp1.My.Resources.Resources.nav_purchases_cart_3d
            Me.picCardPurchases.ImageRotate = 0!
            Me.picCardPurchases.Location = New System.Drawing.Point(10, 10)
            Me.picCardPurchases.Name = "picCardPurchases"
            Me.picCardPurchases.Size = New System.Drawing.Size(28, 85)
            Me.picCardPurchases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picCardPurchases.TabIndex = 3
            Me.picCardPurchases.TabStop = False
            '
            'cardProfit
            '
            Me.cardProfit.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardProfit.BorderRadius = 12
            Me.cardProfit.BorderThickness = 1
            Me.cardProfit.Controls.Add(Me.lblCardProfitSub)
            Me.cardProfit.Controls.Add(Me.lblCardProfitVal)
            Me.cardProfit.Controls.Add(Me.lblCardProfitTitle)
            Me.cardProfit.Controls.Add(Me.picCardProfit)
            Me.cardProfit.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardProfit.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardProfit.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardProfit.Location = New System.Drawing.Point(578, 5)
            Me.cardProfit.Margin = New System.Windows.Forms.Padding(5)
            Me.cardProfit.Name = "cardProfit"
            Me.cardProfit.Padding = New System.Windows.Forms.Padding(10)
            Me.cardProfit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardProfit.Size = New System.Drawing.Size(179, 105)
            Me.cardProfit.TabIndex = 2
            '
            'lblCardProfitSub
            '
            Me.lblCardProfitSub.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardProfitSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
            Me.lblCardProfitSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblCardProfitSub.Location = New System.Drawing.Point(38, 56)
            Me.lblCardProfitSub.Name = "lblCardProfitSub"
            Me.lblCardProfitSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardProfitSub.Size = New System.Drawing.Size(131, 23)
            Me.lblCardProfitSub.TabIndex = 0
            Me.lblCardProfitSub.Text = "(المبيعات - المصروفات)"
            '
            'lblCardProfitVal
            '
            Me.lblCardProfitVal.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardProfitVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardProfitVal.ForeColor = System.Drawing.Color.White
            Me.lblCardProfitVal.Location = New System.Drawing.Point(38, 33)
            Me.lblCardProfitVal.Name = "lblCardProfitVal"
            Me.lblCardProfitVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardProfitVal.Size = New System.Drawing.Size(131, 23)
            Me.lblCardProfitVal.TabIndex = 1
            Me.lblCardProfitVal.Text = "0.00 جنية"
            '
            'lblCardProfitTitle
            '
            Me.lblCardProfitTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardProfitTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblCardProfitTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblCardProfitTitle.Location = New System.Drawing.Point(38, 10)
            Me.lblCardProfitTitle.Name = "lblCardProfitTitle"
            Me.lblCardProfitTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardProfitTitle.Size = New System.Drawing.Size(131, 23)
            Me.lblCardProfitTitle.TabIndex = 2
            Me.lblCardProfitTitle.Text = "صافي الأرباح"
            '
            'picCardProfit
            '
            Me.picCardProfit.Dock = System.Windows.Forms.DockStyle.Left
            Me.picCardProfit.Image = Global.WindowsApp1.My.Resources.Resources.nav_treasury_money_3d
            Me.picCardProfit.ImageRotate = 0!
            Me.picCardProfit.Location = New System.Drawing.Point(10, 10)
            Me.picCardProfit.Name = "picCardProfit"
            Me.picCardProfit.Size = New System.Drawing.Size(28, 85)
            Me.picCardProfit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picCardProfit.TabIndex = 3
            Me.picCardProfit.TabStop = False
            '
            'cardProducts
            '
            Me.cardProducts.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardProducts.BorderRadius = 12
            Me.cardProducts.BorderThickness = 1
            Me.cardProducts.Controls.Add(Me.lblCardProductsSub)
            Me.cardProducts.Controls.Add(Me.lblCardProductsVal)
            Me.cardProducts.Controls.Add(Me.lblCardProductsTitle)
            Me.cardProducts.Controls.Add(Me.picCardProducts)
            Me.cardProducts.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardProducts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardProducts.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardProducts.Location = New System.Drawing.Point(389, 5)
            Me.cardProducts.Margin = New System.Windows.Forms.Padding(5)
            Me.cardProducts.Name = "cardProducts"
            Me.cardProducts.Padding = New System.Windows.Forms.Padding(10)
            Me.cardProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardProducts.Size = New System.Drawing.Size(179, 105)
            Me.cardProducts.TabIndex = 3
            '
            'lblCardProductsSub
            '
            Me.lblCardProductsSub.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardProductsSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
            Me.lblCardProductsSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblCardProductsSub.Location = New System.Drawing.Point(38, 56)
            Me.lblCardProductsSub.Name = "lblCardProductsSub"
            Me.lblCardProductsSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardProductsSub.Size = New System.Drawing.Size(131, 23)
            Me.lblCardProductsSub.TabIndex = 0
            Me.lblCardProductsSub.Text = "صنف مسجل بالنظام"
            '
            'lblCardProductsVal
            '
            Me.lblCardProductsVal.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardProductsVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardProductsVal.ForeColor = System.Drawing.Color.White
            Me.lblCardProductsVal.Location = New System.Drawing.Point(38, 33)
            Me.lblCardProductsVal.Name = "lblCardProductsVal"
            Me.lblCardProductsVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardProductsVal.Size = New System.Drawing.Size(131, 23)
            Me.lblCardProductsVal.TabIndex = 1
            Me.lblCardProductsVal.Text = "0"
            '
            'lblCardProductsTitle
            '
            Me.lblCardProductsTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardProductsTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblCardProductsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblCardProductsTitle.Location = New System.Drawing.Point(38, 10)
            Me.lblCardProductsTitle.Name = "lblCardProductsTitle"
            Me.lblCardProductsTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardProductsTitle.Size = New System.Drawing.Size(131, 23)
            Me.lblCardProductsTitle.TabIndex = 2
            Me.lblCardProductsTitle.Text = "إجمالي الأصناف"
            '
            'picCardProducts
            '
            Me.picCardProducts.Dock = System.Windows.Forms.DockStyle.Left
            Me.picCardProducts.Image = Global.WindowsApp1.My.Resources.Resources.products
            Me.picCardProducts.ImageRotate = 0!
            Me.picCardProducts.Location = New System.Drawing.Point(10, 10)
            Me.picCardProducts.Name = "picCardProducts"
            Me.picCardProducts.Size = New System.Drawing.Size(28, 85)
            Me.picCardProducts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picCardProducts.TabIndex = 3
            Me.picCardProducts.TabStop = False
            '
            'cardCustomers
            '
            Me.cardCustomers.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardCustomers.BorderRadius = 12
            Me.cardCustomers.BorderThickness = 1
            Me.cardCustomers.Controls.Add(Me.lblCardCustomersSub)
            Me.cardCustomers.Controls.Add(Me.lblCardCustomersVal)
            Me.cardCustomers.Controls.Add(Me.lblCardCustomersTitle)
            Me.cardCustomers.Controls.Add(Me.picCardCustomers)
            Me.cardCustomers.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardCustomers.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardCustomers.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardCustomers.Location = New System.Drawing.Point(200, 5)
            Me.cardCustomers.Margin = New System.Windows.Forms.Padding(5)
            Me.cardCustomers.Name = "cardCustomers"
            Me.cardCustomers.Padding = New System.Windows.Forms.Padding(10)
            Me.cardCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardCustomers.Size = New System.Drawing.Size(179, 105)
            Me.cardCustomers.TabIndex = 4
            '
            'lblCardCustomersSub
            '
            Me.lblCardCustomersSub.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardCustomersSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
            Me.lblCardCustomersSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblCardCustomersSub.Location = New System.Drawing.Point(38, 56)
            Me.lblCardCustomersSub.Name = "lblCardCustomersSub"
            Me.lblCardCustomersSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardCustomersSub.Size = New System.Drawing.Size(131, 23)
            Me.lblCardCustomersSub.TabIndex = 0
            Me.lblCardCustomersSub.Text = "عميل مسجل"
            '
            'lblCardCustomersVal
            '
            Me.lblCardCustomersVal.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardCustomersVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardCustomersVal.ForeColor = System.Drawing.Color.White
            Me.lblCardCustomersVal.Location = New System.Drawing.Point(38, 33)
            Me.lblCardCustomersVal.Name = "lblCardCustomersVal"
            Me.lblCardCustomersVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardCustomersVal.Size = New System.Drawing.Size(131, 23)
            Me.lblCardCustomersVal.TabIndex = 1
            Me.lblCardCustomersVal.Text = "0"
            '
            'lblCardCustomersTitle
            '
            Me.lblCardCustomersTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardCustomersTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblCardCustomersTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblCardCustomersTitle.Location = New System.Drawing.Point(38, 10)
            Me.lblCardCustomersTitle.Name = "lblCardCustomersTitle"
            Me.lblCardCustomersTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardCustomersTitle.Size = New System.Drawing.Size(131, 23)
            Me.lblCardCustomersTitle.TabIndex = 2
            Me.lblCardCustomersTitle.Text = "إجمالي العملاء"
            '
            'picCardCustomers
            '
            Me.picCardCustomers.Dock = System.Windows.Forms.DockStyle.Left
            Me.picCardCustomers.Image = Global.WindowsApp1.My.Resources.Resources.nav_customers_clients_3d
            Me.picCardCustomers.ImageRotate = 0!
            Me.picCardCustomers.Location = New System.Drawing.Point(10, 10)
            Me.picCardCustomers.Name = "picCardCustomers"
            Me.picCardCustomers.Size = New System.Drawing.Size(28, 85)
            Me.picCardCustomers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picCardCustomers.TabIndex = 3
            Me.picCardCustomers.TabStop = False
            '
            'cardSuppliers
            '
            Me.cardSuppliers.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.cardSuppliers.BorderRadius = 12
            Me.cardSuppliers.BorderThickness = 1
            Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersSub)
            Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersVal)
            Me.cardSuppliers.Controls.Add(Me.lblCardSuppliersTitle)
            Me.cardSuppliers.Controls.Add(Me.picCardSuppliers)
            Me.cardSuppliers.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cardSuppliers.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardSuppliers.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.cardSuppliers.Location = New System.Drawing.Point(5, 5)
            Me.cardSuppliers.Margin = New System.Windows.Forms.Padding(5)
            Me.cardSuppliers.Name = "cardSuppliers"
            Me.cardSuppliers.Padding = New System.Windows.Forms.Padding(10)
            Me.cardSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.cardSuppliers.Size = New System.Drawing.Size(185, 105)
            Me.cardSuppliers.TabIndex = 5
            '
            'lblCardSuppliersSub
            '
            Me.lblCardSuppliersSub.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardSuppliersSub.Font = New System.Drawing.Font("Segoe UI", 7.5!)
            Me.lblCardSuppliersSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblCardSuppliersSub.Location = New System.Drawing.Point(38, 56)
            Me.lblCardSuppliersSub.Name = "lblCardSuppliersSub"
            Me.lblCardSuppliersSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardSuppliersSub.Size = New System.Drawing.Size(137, 23)
            Me.lblCardSuppliersSub.TabIndex = 0
            Me.lblCardSuppliersSub.Text = "مورد وشركة"
            '
            'lblCardSuppliersVal
            '
            Me.lblCardSuppliersVal.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardSuppliersVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardSuppliersVal.ForeColor = System.Drawing.Color.White
            Me.lblCardSuppliersVal.Location = New System.Drawing.Point(38, 33)
            Me.lblCardSuppliersVal.Name = "lblCardSuppliersVal"
            Me.lblCardSuppliersVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardSuppliersVal.Size = New System.Drawing.Size(137, 23)
            Me.lblCardSuppliersVal.TabIndex = 1
            Me.lblCardSuppliersVal.Text = "0"
            '
            'lblCardSuppliersTitle
            '
            Me.lblCardSuppliersTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCardSuppliersTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblCardSuppliersTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblCardSuppliersTitle.Location = New System.Drawing.Point(38, 10)
            Me.lblCardSuppliersTitle.Name = "lblCardSuppliersTitle"
            Me.lblCardSuppliersTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblCardSuppliersTitle.Size = New System.Drawing.Size(137, 23)
            Me.lblCardSuppliersTitle.TabIndex = 2
            Me.lblCardSuppliersTitle.Text = "إجمالي الموردين"
            '
            'picCardSuppliers
            '
            Me.picCardSuppliers.Dock = System.Windows.Forms.DockStyle.Left
            Me.picCardSuppliers.Image = Global.WindowsApp1.My.Resources.Resources.nav_suppliers_truck_3d
            Me.picCardSuppliers.ImageRotate = 0!
            Me.picCardSuppliers.Location = New System.Drawing.Point(10, 10)
            Me.picCardSuppliers.Name = "picCardSuppliers"
            Me.picCardSuppliers.Size = New System.Drawing.Size(28, 85)
            Me.picCardSuppliers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picCardSuppliers.TabIndex = 3
            Me.picCardSuppliers.TabStop = False
            '
            'pnlQuickButtons
            '
            Me.pnlQuickButtons.Controls.Add(Me.tlpQuickBtns)
            Me.pnlQuickButtons.Controls.Add(Me.lblQuickTitle)
            Me.pnlQuickButtons.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlQuickButtons.Location = New System.Drawing.Point(20, 0)
            Me.pnlQuickButtons.Name = "pnlQuickButtons"
            Me.pnlQuickButtons.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.pnlQuickButtons.Size = New System.Drawing.Size(1140, 90)
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
            Me.tlpQuickBtns.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tlpQuickBtns.Location = New System.Drawing.Point(0, 36)
            Me.tlpQuickBtns.Name = "tlpQuickBtns"
            Me.tlpQuickBtns.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.tlpQuickBtns.Size = New System.Drawing.Size(1140, 54)
            Me.tlpQuickBtns.TabIndex = 0
            '
            'btnQuickPOS
            '
            Me.btnQuickPOS.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.btnQuickPOS.BorderRadius = 10
            Me.btnQuickPOS.BorderThickness = 1
            Me.btnQuickPOS.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickPOS.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickPOS.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.btnQuickPOS.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnQuickPOS.ForeColor = System.Drawing.Color.White
            Me.btnQuickPOS.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnQuickPOS.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnQuickPOS.Image = Global.WindowsApp1.My.Resources.Resources.nav_sales_restaurant_3d
            Me.btnQuickPOS.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnQuickPOS.ImageSize = New System.Drawing.Size(24, 24)
            Me.btnQuickPOS.Location = New System.Drawing.Point(860, 5)
            Me.btnQuickPOS.Margin = New System.Windows.Forms.Padding(5)
            Me.btnQuickPOS.Name = "btnQuickPOS"
            Me.btnQuickPOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnQuickPOS.Size = New System.Drawing.Size(275, 55)
            Me.btnQuickPOS.TabIndex = 0
            Me.btnQuickPOS.Text = "  شاشة البيع (كاشير F1)"
            '
            'btnQuickProducts
            '
            Me.btnQuickProducts.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.btnQuickProducts.BorderRadius = 10
            Me.btnQuickProducts.BorderThickness = 1
            Me.btnQuickProducts.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickProducts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickProducts.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.btnQuickProducts.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnQuickProducts.ForeColor = System.Drawing.Color.White
            Me.btnQuickProducts.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnQuickProducts.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnQuickProducts.Image = Global.WindowsApp1.My.Resources.Resources.products
            Me.btnQuickProducts.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnQuickProducts.ImageSize = New System.Drawing.Size(24, 24)
            Me.btnQuickProducts.Location = New System.Drawing.Point(575, 5)
            Me.btnQuickProducts.Margin = New System.Windows.Forms.Padding(5)
            Me.btnQuickProducts.Name = "btnQuickProducts"
            Me.btnQuickProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnQuickProducts.Size = New System.Drawing.Size(275, 55)
            Me.btnQuickProducts.TabIndex = 1
            Me.btnQuickProducts.Text = "  قائمة الأصناف (F2)"
            '
            'btnQuickCustomers
            '
            Me.btnQuickCustomers.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.btnQuickCustomers.BorderRadius = 10
            Me.btnQuickCustomers.BorderThickness = 1
            Me.btnQuickCustomers.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickCustomers.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickCustomers.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.btnQuickCustomers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnQuickCustomers.ForeColor = System.Drawing.Color.White
            Me.btnQuickCustomers.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnQuickCustomers.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnQuickCustomers.Image = Global.WindowsApp1.My.Resources.Resources.nav_customers_clients_3d
            Me.btnQuickCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnQuickCustomers.ImageSize = New System.Drawing.Size(24, 24)
            Me.btnQuickCustomers.Location = New System.Drawing.Point(290, 5)
            Me.btnQuickCustomers.Margin = New System.Windows.Forms.Padding(5)
            Me.btnQuickCustomers.Name = "btnQuickCustomers"
            Me.btnQuickCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnQuickCustomers.Size = New System.Drawing.Size(275, 55)
            Me.btnQuickCustomers.TabIndex = 2
            Me.btnQuickCustomers.Text = "  دليل العملاء (F3)"
            '
            'btnQuickBackup
            '
            Me.btnQuickBackup.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(63, Byte), Integer))
            Me.btnQuickBackup.BorderRadius = 10
            Me.btnQuickBackup.BorderThickness = 1
            Me.btnQuickBackup.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickBackup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickBackup.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(36, Byte), Integer))
            Me.btnQuickBackup.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnQuickBackup.ForeColor = System.Drawing.Color.White
            Me.btnQuickBackup.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnQuickBackup.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnQuickBackup.Image = Global.WindowsApp1.My.Resources.Resources.backup
            Me.btnQuickBackup.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnQuickBackup.ImageSize = New System.Drawing.Size(24, 24)
            Me.btnQuickBackup.Location = New System.Drawing.Point(5, 5)
            Me.btnQuickBackup.Margin = New System.Windows.Forms.Padding(5)
            Me.btnQuickBackup.Name = "btnQuickBackup"
            Me.btnQuickBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.btnQuickBackup.Size = New System.Drawing.Size(275, 55)
            Me.btnQuickBackup.TabIndex = 3
            Me.btnQuickBackup.Text = "  النسخ الاحتياطي (F4)"
            '
            'lblQuickTitle
            '
            Me.lblQuickTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblQuickTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblQuickTitle.ForeColor = System.Drawing.Color.White
            Me.lblQuickTitle.Location = New System.Drawing.Point(0, 0)
            Me.lblQuickTitle.Name = "lblQuickTitle"
            Me.lblQuickTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.lblQuickTitle.Size = New System.Drawing.Size(1140, 36)
            Me.lblQuickTitle.TabIndex = 1
            Me.lblQuickTitle.Text = "عمليات الوصول السريع:"
            Me.lblQuickTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'UCDashboard
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.Controls.Add(Me.pnlDashboardBody)
            Me.Controls.Add(Me.pnlWelcome)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.Name = "UCDashboard"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1180, 758)
            Me.pnlWelcome.ResumeLayout(False)
            Me.pnlDashboardBody.ResumeLayout(False)
            Me.tlpMainContent.ResumeLayout(False)
            Me.cardRecentInvoices.ResumeLayout(False)
            CType(Me.dgvRecentInvoices, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlInvoicesHeader.ResumeLayout(False)
            Me.cardAlerts.ResumeLayout(False)
            Me.pnlAlertsContainer.ResumeLayout(False)
            Me.cardAlertBackup.ResumeLayout(False)
            Me.cardAlertShift.ResumeLayout(False)
            Me.cardAlertStock.ResumeLayout(False)
            Me.pnlAlertsHeader.ResumeLayout(False)
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
            Me.pnlQuickButtons.ResumeLayout(False)
            Me.tlpQuickBtns.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlWelcome As System.Windows.Forms.Panel
        Friend WithEvents lblWelcomeGreeting As System.Windows.Forms.Label
        Friend WithEvents lblWelcomeSub As System.Windows.Forms.Label
        Friend WithEvents lblShiftDuration As System.Windows.Forms.Label
        Friend WithEvents btnRefreshDashboard As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents pnlDashboardBody As System.Windows.Forms.Panel
        Friend WithEvents pnlQuickButtons As System.Windows.Forms.Panel
        Friend WithEvents tlpQuickBtns As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents btnQuickPOS As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnQuickProducts As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnQuickCustomers As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnQuickBackup As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblQuickTitle As System.Windows.Forms.Label
        Friend WithEvents tlpStats As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents cardSales As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardSalesSub As System.Windows.Forms.Label
        Friend WithEvents lblCardSalesVal As System.Windows.Forms.Label
        Friend WithEvents lblCardSalesTitle As System.Windows.Forms.Label
        Friend WithEvents picCardSales As Guna.UI2.WinForms.Guna2PictureBox
        Friend WithEvents cardPurchases As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardPurchasesSub As System.Windows.Forms.Label
        Friend WithEvents lblCardPurchasesVal As System.Windows.Forms.Label
        Friend WithEvents lblCardPurchasesTitle As System.Windows.Forms.Label
        Friend WithEvents picCardPurchases As Guna.UI2.WinForms.Guna2PictureBox
        Friend WithEvents cardProfit As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardProfitSub As System.Windows.Forms.Label
        Friend WithEvents lblCardProfitVal As System.Windows.Forms.Label
        Friend WithEvents lblCardProfitTitle As System.Windows.Forms.Label
        Friend WithEvents picCardProfit As Guna.UI2.WinForms.Guna2PictureBox
        Friend WithEvents cardProducts As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardProductsSub As System.Windows.Forms.Label
        Friend WithEvents lblCardProductsVal As System.Windows.Forms.Label
        Friend WithEvents lblCardProductsTitle As System.Windows.Forms.Label
        Friend WithEvents picCardProducts As Guna.UI2.WinForms.Guna2PictureBox
        Friend WithEvents cardCustomers As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardCustomersSub As System.Windows.Forms.Label
        Friend WithEvents lblCardCustomersVal As System.Windows.Forms.Label
        Friend WithEvents lblCardCustomersTitle As System.Windows.Forms.Label
        Friend WithEvents picCardCustomers As Guna.UI2.WinForms.Guna2PictureBox
        Friend WithEvents cardSuppliers As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardSuppliersSub As System.Windows.Forms.Label
        Friend WithEvents lblCardSuppliersVal As System.Windows.Forms.Label
        Friend WithEvents lblCardSuppliersTitle As System.Windows.Forms.Label
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
        Friend WithEvents cardAlertBackup As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblAlertBackupDesc As System.Windows.Forms.Label
        Friend WithEvents lblAlertBackupTitle As System.Windows.Forms.Label
        Friend WithEvents cardAlertShift As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblAlertShiftDesc As System.Windows.Forms.Label
        Friend WithEvents lblAlertShiftTitle As System.Windows.Forms.Label
        Friend WithEvents cardAlertStock As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblAlertStockDesc As System.Windows.Forms.Label
        Friend WithEvents lblAlertStockTitle As System.Windows.Forms.Label
    End Class
End Namespace
