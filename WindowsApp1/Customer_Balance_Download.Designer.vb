<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Customer_Balance_Download
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btn_min = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_max = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_close = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.pnlTopBar = New Guna.UI2.WinForms.Guna2Panel()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cmbFilterType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblTotalDebtKpi = New System.Windows.Forms.Label()
        Me.lblTotalDebtTitle = New System.Windows.Forms.Label()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportExcel = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlLeftCard = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCustCardTitle = New System.Windows.Forms.Label()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.lblCustomerPhone = New System.Windows.Forms.Label()
        Me.lblBalanceDisplayTitle = New System.Windows.Forms.Label()
        Me.lblBalanceDisplay = New System.Windows.Forms.Label()
        Me.lblCreditLimitDisplay = New System.Windows.Forms.Label()
        Me.separator1 = New System.Windows.Forms.Label()
        Me.lblAmountTitle = New System.Windows.Forms.Label()
        Me.txtAmountPaid = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnPayFullDebt = New Guna.UI2.WinForms.Guna2Button()
        Me.lblTreasuryTitle = New System.Windows.Forms.Label()
        Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblNotesTitle = New System.Windows.Forms.Label()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnDoPayment = New Guna.UI2.WinForms.Guna2Button()
        Me.btnOpenStatement = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlGridArea = New System.Windows.Forms.Panel()
        Me.dgvCustomers = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.panelHeader.SuspendLayout()
        Me.pnlTopBar.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlLeftCard.SuspendLayout()
        Me.pnlGridArea.SuspendLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1260, 48)
        Me.panelHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(120, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1125, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "💳 سداد مديونيات وتنزيل أرصدة العملاء (سندات القبض)"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_min
        '
        Me.btn_min.Location = New System.Drawing.Point(82, 8)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btn_min.FillColor = System.Drawing.Color.Transparent
        Me.btn_min.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_min.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_min.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_min.Size = New System.Drawing.Size(32, 32)
        Me.btn_min.TabIndex = 3
        Me.btn_min.Text = "–"
        '
        'btn_max
        '
        Me.btn_max.Location = New System.Drawing.Point(46, 8)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox
        Me.btn_max.FillColor = System.Drawing.Color.Transparent
        Me.btn_max.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_max.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_max.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_max.Size = New System.Drawing.Size(32, 32)
        Me.btn_max.TabIndex = 2
        Me.btn_max.Text = "🗖"
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(10, 8)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.FillColor = System.Drawing.Color.Transparent
        Me.btn_close.HoverState.FillColor = System.Drawing.Color.FromArgb(239, 68, 68)
        Me.btn_close.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_close.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_close.Size = New System.Drawing.Size(32, 32)
        Me.btn_close.TabIndex = 1
        Me.btn_close.Text = "✕"
        '
        'pnlTopBar
        '
        Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlTopBar.Controls.Add(Me.btnExportExcel)
        Me.pnlTopBar.Controls.Add(Me.btnRefresh)
        Me.pnlTopBar.Controls.Add(Me.lblTotalDebtKpi)
        Me.pnlTopBar.Controls.Add(Me.lblTotalDebtTitle)
        Me.pnlTopBar.Controls.Add(Me.cmbFilterType)
        Me.pnlTopBar.Controls.Add(Me.txtSearch)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(0, 48)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(1260, 58)
        Me.pnlTopBar.TabIndex = 1
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderRadius = 6
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtSearch.Location = New System.Drawing.Point(850, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearch.PlaceholderText = "🔍 بحث فوري بالاسم، الكود، رقم الهاتف..."
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(395, 38)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbFilterType
        '
        Me.cmbFilterType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFilterType.BackColor = System.Drawing.Color.Transparent
        Me.cmbFilterType.BorderRadius = 6
        Me.cmbFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterType.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cmbFilterType.ForeColor = System.Drawing.Color.Black
        Me.cmbFilterType.ItemHeight = 30
        Me.cmbFilterType.Location = New System.Drawing.Point(640, 11)
        Me.cmbFilterType.Name = "cmbFilterType"
        Me.cmbFilterType.Size = New System.Drawing.Size(200, 36)
        Me.cmbFilterType.TabIndex = 1
        Me.cmbFilterType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalDebtTitle
        '
        Me.lblTotalDebtTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDebtTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.lblTotalDebtTitle.Location = New System.Drawing.Point(460, 18)
        Me.lblTotalDebtTitle.Name = "lblTotalDebtTitle"
        Me.lblTotalDebtTitle.Size = New System.Drawing.Size(160, 22)
        Me.lblTotalDebtTitle.TabIndex = 2
        Me.lblTotalDebtTitle.Text = "إجمالي مديونيات العملاء:"
        Me.lblTotalDebtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalDebtKpi
        '
        Me.lblTotalDebtKpi.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDebtKpi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblTotalDebtKpi.Location = New System.Drawing.Point(290, 16)
        Me.lblTotalDebtKpi.Name = "lblTotalDebtKpi"
        Me.lblTotalDebtKpi.Size = New System.Drawing.Size(170, 25)
        Me.lblTotalDebtKpi.TabIndex = 3
        Me.lblTotalDebtKpi.Text = "0.00 ج.م"
        Me.lblTotalDebtKpi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRefresh
        '
        Me.btnRefresh.BorderRadius = 6
        Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(150, 11)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 36)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "🔄 تحديث"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.BorderRadius = 6
        Me.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportExcel.ForeColor = System.Drawing.Color.White
        Me.btnExportExcel.Location = New System.Drawing.Point(15, 11)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(125, 36)
        Me.btnExportExcel.TabIndex = 5
        Me.btnExportExcel.Text = "📊 تصدير Excel"
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlGridArea)
        Me.pnlMain.Controls.Add(Me.pnlLeftCard)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 106)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlMain.Size = New System.Drawing.Size(1260, 614)
        Me.pnlMain.TabIndex = 2
        '
        'pnlLeftCard
        '
        Me.pnlLeftCard.BackColor = System.Drawing.Color.Transparent
        Me.pnlLeftCard.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pnlLeftCard.BorderRadius = 10
        Me.pnlLeftCard.BorderThickness = 1
        Me.pnlLeftCard.Controls.Add(Me.lblCustCardTitle)
        Me.pnlLeftCard.Controls.Add(Me.lblCustomerName)
        Me.pnlLeftCard.Controls.Add(Me.lblCustomerPhone)
        Me.pnlLeftCard.Controls.Add(Me.lblBalanceDisplayTitle)
        Me.pnlLeftCard.Controls.Add(Me.lblBalanceDisplay)
        Me.pnlLeftCard.Controls.Add(Me.lblCreditLimitDisplay)
        Me.pnlLeftCard.Controls.Add(Me.separator1)
        Me.pnlLeftCard.Controls.Add(Me.lblAmountTitle)
        Me.pnlLeftCard.Controls.Add(Me.txtAmountPaid)
        Me.pnlLeftCard.Controls.Add(Me.btnPayFullDebt)
        Me.pnlLeftCard.Controls.Add(Me.lblTreasuryTitle)
        Me.pnlLeftCard.Controls.Add(Me.cmbTreasury)
        Me.pnlLeftCard.Controls.Add(Me.lblNotesTitle)
        Me.pnlLeftCard.Controls.Add(Me.txtNotes)
        Me.pnlLeftCard.Controls.Add(Me.btnDoPayment)
        Me.pnlLeftCard.Controls.Add(Me.btnOpenStatement)
        Me.pnlLeftCard.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftCard.FillColor = System.Drawing.Color.White
        Me.pnlLeftCard.Location = New System.Drawing.Point(12, 12)
        Me.pnlLeftCard.Name = "pnlLeftCard"
        Me.pnlLeftCard.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlLeftCard.Size = New System.Drawing.Size(380, 590)
        Me.pnlLeftCard.TabIndex = 0
        '
        'lblCustCardTitle
        '
        Me.lblCustCardTitle.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblCustCardTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.lblCustCardTitle.Location = New System.Drawing.Point(15, 12)
        Me.lblCustCardTitle.Name = "lblCustCardTitle"
        Me.lblCustCardTitle.Size = New System.Drawing.Size(350, 25)
        Me.lblCustCardTitle.TabIndex = 0
        Me.lblCustCardTitle.Text = "بيانات العميل المحدد وسند القبض"
        Me.lblCustCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerName
        '
        Me.lblCustomerName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCustomerName.ForeColor = System.Drawing.Color.Black
        Me.lblCustomerName.Location = New System.Drawing.Point(15, 42)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(350, 28)
        Me.lblCustomerName.TabIndex = 1
        Me.lblCustomerName.Text = "يرجى تحديد عميل من الجدول"
        Me.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerPhone
        '
        Me.lblCustomerPhone.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblCustomerPhone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.lblCustomerPhone.Location = New System.Drawing.Point(15, 72)
        Me.lblCustomerPhone.Name = "lblCustomerPhone"
        Me.lblCustomerPhone.Size = New System.Drawing.Size(350, 20)
        Me.lblCustomerPhone.TabIndex = 2
        Me.lblCustomerPhone.Text = "الهاتف: ---  |  الكود: ---"
        Me.lblCustomerPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBalanceDisplayTitle
        '
        Me.lblBalanceDisplayTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblBalanceDisplayTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblBalanceDisplayTitle.Location = New System.Drawing.Point(235, 100)
        Me.lblBalanceDisplayTitle.Name = "lblBalanceDisplayTitle"
        Me.lblBalanceDisplayTitle.Size = New System.Drawing.Size(130, 25)
        Me.lblBalanceDisplayTitle.TabIndex = 3
        Me.lblBalanceDisplayTitle.Text = "الرصيد الحالي:"
        Me.lblBalanceDisplayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBalanceDisplay
        '
        Me.lblBalanceDisplay.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalanceDisplay.ForeColor = System.Drawing.Color.Black
        Me.lblBalanceDisplay.Location = New System.Drawing.Point(15, 96)
        Me.lblBalanceDisplay.Name = "lblBalanceDisplay"
        Me.lblBalanceDisplay.Size = New System.Drawing.Size(220, 32)
        Me.lblBalanceDisplay.TabIndex = 4
        Me.lblBalanceDisplay.Text = "0.00 ج.م"
        Me.lblBalanceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreditLimitDisplay
        '
        Me.lblCreditLimitDisplay.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreditLimitDisplay.ForeColor = System.Drawing.Color.Gray
        Me.lblCreditLimitDisplay.Location = New System.Drawing.Point(15, 130)
        Me.lblCreditLimitDisplay.Name = "lblCreditLimitDisplay"
        Me.lblCreditLimitDisplay.Size = New System.Drawing.Size(350, 20)
        Me.lblCreditLimitDisplay.TabIndex = 5
        Me.lblCreditLimitDisplay.Text = "سقف الائتمان: 0.00 ج.م"
        Me.lblCreditLimitDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'separator1
        '
        Me.separator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.separator1.Location = New System.Drawing.Point(15, 155)
        Me.separator1.Name = "separator1"
        Me.separator1.Size = New System.Drawing.Size(350, 1)
        Me.separator1.TabIndex = 6
        '
        'lblAmountTitle
        '
        Me.lblAmountTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblAmountTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblAmountTitle.Location = New System.Drawing.Point(195, 165)
        Me.lblAmountTitle.Name = "lblAmountTitle"
        Me.lblAmountTitle.Size = New System.Drawing.Size(170, 25)
        Me.lblAmountTitle.TabIndex = 7
        Me.lblAmountTitle.Text = "المبلغ المحصل / المدفوع:"
        Me.lblAmountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtAmountPaid.BorderRadius = 6
        Me.txtAmountPaid.BorderThickness = 2
        Me.txtAmountPaid.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.txtAmountPaid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtAmountPaid.Location = New System.Drawing.Point(150, 195)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAmountPaid.PlaceholderText = "0.00"
        Me.txtAmountPaid.SelectedText = ""
        Me.txtAmountPaid.Size = New System.Drawing.Size(215, 38)
        Me.txtAmountPaid.TabIndex = 8
        Me.txtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPayFullDebt
        '
        Me.btnPayFullDebt.BorderRadius = 6
        Me.btnPayFullDebt.FillColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnPayFullDebt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPayFullDebt.ForeColor = System.Drawing.Color.White
        Me.btnPayFullDebt.Location = New System.Drawing.Point(15, 195)
        Me.btnPayFullDebt.Name = "btnPayFullDebt"
        Me.btnPayFullDebt.Size = New System.Drawing.Size(125, 38)
        Me.btnPayFullDebt.TabIndex = 9
        Me.btnPayFullDebt.Text = "سداد كامل الدين"
        '
        'lblTreasuryTitle
        '
        Me.lblTreasuryTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTreasuryTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTreasuryTitle.Location = New System.Drawing.Point(195, 245)
        Me.lblTreasuryTitle.Name = "lblTreasuryTitle"
        Me.lblTreasuryTitle.Size = New System.Drawing.Size(170, 22)
        Me.lblTreasuryTitle.TabIndex = 10
        Me.lblTreasuryTitle.Text = "الخزينة المودع بها:"
        Me.lblTreasuryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTreasury
        '
        Me.cmbTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbTreasury.BorderRadius = 6
        Me.cmbTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTreasury.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTreasury.ForeColor = System.Drawing.Color.Black
        Me.cmbTreasury.ItemHeight = 28
        Me.cmbTreasury.Location = New System.Drawing.Point(15, 270)
        Me.cmbTreasury.Name = "cmbTreasury"
        Me.cmbTreasury.Size = New System.Drawing.Size(350, 34)
        Me.cmbTreasury.TabIndex = 11
        Me.cmbTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNotesTitle
        '
        Me.lblNotesTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblNotesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblNotesTitle.Location = New System.Drawing.Point(195, 315)
        Me.lblNotesTitle.Name = "lblNotesTitle"
        Me.lblNotesTitle.Size = New System.Drawing.Size(170, 22)
        Me.lblNotesTitle.TabIndex = 12
        Me.lblNotesTitle.Text = "ملاحظات السند:"
        Me.lblNotesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.BorderRadius = 6
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtNotes.Location = New System.Drawing.Point(15, 340)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNotes.PlaceholderText = "ملاحظات السند (اختياري)..."
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(350, 70)
        Me.txtNotes.TabIndex = 13
        Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDoPayment
        '
        Me.btnDoPayment.BorderRadius = 8
        Me.btnDoPayment.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnDoPayment.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnDoPayment.ForeColor = System.Drawing.Color.White
        Me.btnDoPayment.Location = New System.Drawing.Point(15, 430)
        Me.btnDoPayment.Name = "btnDoPayment"
        Me.btnDoPayment.Size = New System.Drawing.Size(350, 48)
        Me.btnDoPayment.TabIndex = 14
        Me.btnDoPayment.Text = "💳 تسجيل السداد وإصدار سند قبض"
        '
        'btnOpenStatement
        '
        Me.btnOpenStatement.BorderRadius = 8
        Me.btnOpenStatement.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnOpenStatement.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnOpenStatement.ForeColor = System.Drawing.Color.White
        Me.btnOpenStatement.Location = New System.Drawing.Point(15, 490)
        Me.btnOpenStatement.Name = "btnOpenStatement"
        Me.btnOpenStatement.Size = New System.Drawing.Size(350, 42)
        Me.btnOpenStatement.TabIndex = 15
        Me.btnOpenStatement.Text = "📄 عرض كشف حساب العميل"
        '
        'pnlGridArea
        '
        Me.pnlGridArea.Controls.Add(Me.dgvCustomers)
        Me.pnlGridArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGridArea.Location = New System.Drawing.Point(392, 12)
        Me.pnlGridArea.Name = "pnlGridArea"
        Me.pnlGridArea.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.pnlGridArea.Size = New System.Drawing.Size(856, 590)
        Me.pnlGridArea.TabIndex = 1
        '
        'dgvCustomers
        '
        Me.dgvCustomers.AllowUserToAddRows = False
        Me.dgvCustomers.AllowUserToDeleteRows = False
        Me.dgvCustomers.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dgvCustomers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCustomers.BackgroundColor = System.Drawing.Color.White
        Me.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCustomers.ColumnHeadersHeight = 40
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomers.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCustomers.EnableHeadersVisualStyles = False
        Me.dgvCustomers.GridColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvCustomers.Location = New System.Drawing.Point(10, 0)
        Me.dgvCustomers.MultiSelect = False
        Me.dgvCustomers.Name = "dgvCustomers"
        Me.dgvCustomers.ReadOnly = True
        Me.dgvCustomers.RowHeadersVisible = False
        Me.dgvCustomers.RowTemplate.Height = 36
        Me.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomers.Size = New System.Drawing.Size(846, 590)
        Me.dgvCustomers.TabIndex = 0
        Me.dgvCustomers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dgvCustomers.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvCustomers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvCustomers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.dgvCustomers.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.dgvCustomers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvCustomers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvCustomers.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dgvCustomers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvCustomers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.dgvCustomers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'Customer_Balance_Download
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1260, 720)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlTopBar)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Customer_Balance_Download"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سداد مديونيات وتنزيل أرصدة العملاء"
        Me.panelHeader.ResumeLayout(False)
        Me.pnlTopBar.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlLeftCard.ResumeLayout(False)
        Me.pnlGridArea.ResumeLayout(False)
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents pnlTopBar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cmbFilterType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblTotalDebtTitle As System.Windows.Forms.Label
    Friend WithEvents lblTotalDebtKpi As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportExcel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlLeftCard As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCustCardTitle As System.Windows.Forms.Label
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblCustomerPhone As System.Windows.Forms.Label
    Friend WithEvents lblBalanceDisplayTitle As System.Windows.Forms.Label
    Friend WithEvents lblBalanceDisplay As System.Windows.Forms.Label
    Friend WithEvents lblCreditLimitDisplay As System.Windows.Forms.Label
    Friend WithEvents separator1 As System.Windows.Forms.Label
    Friend WithEvents lblAmountTitle As System.Windows.Forms.Label
    Friend WithEvents txtAmountPaid As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnPayFullDebt As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTreasuryTitle As System.Windows.Forms.Label
    Friend WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblNotesTitle As System.Windows.Forms.Label
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnDoPayment As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnOpenStatement As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlGridArea As System.Windows.Forms.Panel
    Friend WithEvents dgvCustomers As Guna.UI2.WinForms.Guna2DataGridView

End Class
