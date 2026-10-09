<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sales_Returns
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
        Me.txtInvoiceSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnSearchInvoice = New Guna.UI2.WinForms.Guna2Button()
        Me.txtItemSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnReturnAll = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNewReturn = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlGridArea = New System.Windows.Forms.Panel()
        Me.pnlInvoiceInfo = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblInvoiceInfo = New System.Windows.Forms.Label()
        Me.dgvReturnItems = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSizeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAddonID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSizeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAddonsText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOriginalQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRestoreStock = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colItemNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlSummaryCard = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCardTitle = New System.Windows.Forms.Label()
        Me.lblCustomerHeader = New System.Windows.Forms.Label()
        Me.lblCustomerBalance = New System.Windows.Forms.Label()
        Me.separator1 = New System.Windows.Forms.Label()
        Me.lblTotalReturnBeforeDiscTitle = New System.Windows.Forms.Label()
        Me.lblTotalReturnBeforeDisc = New System.Windows.Forms.Label()
        Me.lblDiscountDeductionTitle = New System.Windows.Forms.Label()
        Me.lblDiscountDeduction = New System.Windows.Forms.Label()
        Me.separator2 = New System.Windows.Forms.Label()
        Me.lblNetRefundTitle = New System.Windows.Forms.Label()
        Me.lblNetRefund = New System.Windows.Forms.Label()
        Me.lblRefundMethodTitle = New System.Windows.Forms.Label()
        Me.cmbRefundMethod = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblTreasuryTitle = New System.Windows.Forms.Label()
        Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblReasonTitle = New System.Windows.Forms.Label()
        Me.cmbReturnReason = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblNotesTitle = New System.Windows.Forms.Label()
        Me.txtReturnNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnSaveReturn = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrintReceipt = New Guna.UI2.WinForms.Guna2Button()
        Me.panelHeader.SuspendLayout()
        Me.pnlTopBar.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlGridArea.SuspendLayout()
        Me.pnlInvoiceInfo.SuspendLayout()
        CType(Me.dgvReturnItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSummaryCard.SuspendLayout()
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
        Me.panelHeader.Size = New System.Drawing.Size(1280, 48)
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
        Me.lblTitle.Size = New System.Drawing.Size(1145, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "🔄 إدارة مرتجعات المبيعات (إرجاع فواتير وأصناف متقدم)"
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
        Me.pnlTopBar.Controls.Add(Me.btnNewReturn)
        Me.pnlTopBar.Controls.Add(Me.btnReturnAll)
        Me.pnlTopBar.Controls.Add(Me.txtItemSearch)
        Me.pnlTopBar.Controls.Add(Me.btnSearchInvoice)
        Me.pnlTopBar.Controls.Add(Me.txtInvoiceSearch)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(0, 48)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(1280, 58)
        Me.pnlTopBar.TabIndex = 1
        '
        'txtInvoiceSearch
        '
        Me.txtInvoiceSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvoiceSearch.BorderRadius = 6
        Me.txtInvoiceSearch.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.txtInvoiceSearch.Location = New System.Drawing.Point(920, 10)
        Me.txtInvoiceSearch.Name = "txtInvoiceSearch"
        Me.txtInvoiceSearch.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtInvoiceSearch.PlaceholderText = "🔍 ادخل أو امسح باركود الفاتورة واضغط Enter..."
        Me.txtInvoiceSearch.SelectedText = ""
        Me.txtInvoiceSearch.Size = New System.Drawing.Size(345, 38)
        Me.txtInvoiceSearch.TabIndex = 0
        Me.txtInvoiceSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSearchInvoice
        '
        Me.btnSearchInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchInvoice.BorderRadius = 6
        Me.btnSearchInvoice.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnSearchInvoice.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearchInvoice.ForeColor = System.Drawing.Color.White
        Me.btnSearchInvoice.Location = New System.Drawing.Point(795, 10)
        Me.btnSearchInvoice.Name = "btnSearchInvoice"
        Me.btnSearchInvoice.Size = New System.Drawing.Size(115, 38)
        Me.btnSearchInvoice.TabIndex = 1
        Me.btnSearchInvoice.Text = "🔍 جلب الفاتورة"
        '
        'txtItemSearch
        '
        Me.txtItemSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemSearch.BorderRadius = 6
        Me.txtItemSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtItemSearch.Location = New System.Drawing.Point(435, 10)
        Me.txtItemSearch.Name = "txtItemSearch"
        Me.txtItemSearch.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtItemSearch.PlaceholderText = "🔍 إضافة صنف حر للإرجاع (اسم / باركود)..."
        Me.txtItemSearch.SelectedText = ""
        Me.txtItemSearch.Size = New System.Drawing.Size(345, 38)
        Me.txtItemSearch.TabIndex = 2
        Me.txtItemSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnReturnAll
        '
        Me.btnReturnAll.BorderRadius = 6
        Me.btnReturnAll.FillColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReturnAll.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnReturnAll.ForeColor = System.Drawing.Color.White
        Me.btnReturnAll.Location = New System.Drawing.Point(170, 10)
        Me.btnReturnAll.Name = "btnReturnAll"
        Me.btnReturnAll.Size = New System.Drawing.Size(155, 38)
        Me.btnReturnAll.TabIndex = 3
        Me.btnReturnAll.Text = "✔ إرجاع كامل الفاتورة"
        '
        'btnNewReturn
        '
        Me.btnNewReturn.BorderRadius = 6
        Me.btnNewReturn.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnNewReturn.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNewReturn.ForeColor = System.Drawing.Color.White
        Me.btnNewReturn.Location = New System.Drawing.Point(15, 10)
        Me.btnNewReturn.Name = "btnNewReturn"
        Me.btnNewReturn.Size = New System.Drawing.Size(145, 38)
        Me.btnNewReturn.TabIndex = 4
        Me.btnNewReturn.Text = "🔄 عملية جديدة"
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlGridArea)
        Me.pnlMain.Controls.Add(Me.pnlSummaryCard)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 106)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlMain.Size = New System.Drawing.Size(1280, 634)
        Me.pnlMain.TabIndex = 2
        '
        'pnlSummaryCard
        '
        Me.pnlSummaryCard.BackColor = System.Drawing.Color.Transparent
        Me.pnlSummaryCard.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pnlSummaryCard.BorderRadius = 10
        Me.pnlSummaryCard.BorderThickness = 1
        Me.pnlSummaryCard.Controls.Add(Me.lblCardTitle)
        Me.pnlSummaryCard.Controls.Add(Me.lblCustomerHeader)
        Me.pnlSummaryCard.Controls.Add(Me.lblCustomerBalance)
        Me.pnlSummaryCard.Controls.Add(Me.separator1)
        Me.pnlSummaryCard.Controls.Add(Me.lblTotalReturnBeforeDiscTitle)
        Me.pnlSummaryCard.Controls.Add(Me.lblTotalReturnBeforeDisc)
        Me.pnlSummaryCard.Controls.Add(Me.lblDiscountDeductionTitle)
        Me.pnlSummaryCard.Controls.Add(Me.lblDiscountDeduction)
        Me.pnlSummaryCard.Controls.Add(Me.separator2)
        Me.pnlSummaryCard.Controls.Add(Me.lblNetRefundTitle)
        Me.pnlSummaryCard.Controls.Add(Me.lblNetRefund)
        Me.pnlSummaryCard.Controls.Add(Me.lblRefundMethodTitle)
        Me.pnlSummaryCard.Controls.Add(Me.cmbRefundMethod)
        Me.pnlSummaryCard.Controls.Add(Me.lblTreasuryTitle)
        Me.pnlSummaryCard.Controls.Add(Me.cmbTreasury)
        Me.pnlSummaryCard.Controls.Add(Me.lblReasonTitle)
        Me.pnlSummaryCard.Controls.Add(Me.cmbReturnReason)
        Me.pnlSummaryCard.Controls.Add(Me.lblNotesTitle)
        Me.pnlSummaryCard.Controls.Add(Me.txtReturnNotes)
        Me.pnlSummaryCard.Controls.Add(Me.btnSaveReturn)
        Me.pnlSummaryCard.Controls.Add(Me.btnPrintReceipt)
        Me.pnlSummaryCard.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSummaryCard.FillColor = System.Drawing.Color.White
        Me.pnlSummaryCard.Location = New System.Drawing.Point(12, 12)
        Me.pnlSummaryCard.Name = "pnlSummaryCard"
        Me.pnlSummaryCard.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlSummaryCard.Size = New System.Drawing.Size(370, 610)
        Me.pnlSummaryCard.TabIndex = 0
        '
        'lblCardTitle
        '
        Me.lblCardTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.lblCardTitle.Location = New System.Drawing.Point(12, 10)
        Me.lblCardTitle.Name = "lblCardTitle"
        Me.lblCardTitle.Size = New System.Drawing.Size(345, 24)
        Me.lblCardTitle.TabIndex = 0
        Me.lblCardTitle.Text = "بيانات الاسترداد والعميل"
        Me.lblCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerHeader
        '
        Me.lblCustomerHeader.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblCustomerHeader.ForeColor = System.Drawing.Color.Black
        Me.lblCustomerHeader.Location = New System.Drawing.Point(12, 38)
        Me.lblCustomerHeader.Name = "lblCustomerHeader"
        Me.lblCustomerHeader.Size = New System.Drawing.Size(345, 22)
        Me.lblCustomerHeader.TabIndex = 1
        Me.lblCustomerHeader.Text = "العميل: عميل نقدي عام"
        Me.lblCustomerHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerBalance
        '
        Me.lblCustomerBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCustomerBalance.ForeColor = System.Drawing.Color.Gray
        Me.lblCustomerBalance.Location = New System.Drawing.Point(12, 62)
        Me.lblCustomerBalance.Name = "lblCustomerBalance"
        Me.lblCustomerBalance.Size = New System.Drawing.Size(345, 18)
        Me.lblCustomerBalance.TabIndex = 2
        Me.lblCustomerBalance.Text = "الرصيد: 0.00 ج.م"
        Me.lblCustomerBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'separator1
        '
        Me.separator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.separator1.Location = New System.Drawing.Point(12, 85)
        Me.separator1.Name = "separator1"
        Me.separator1.Size = New System.Drawing.Size(345, 1)
        Me.separator1.TabIndex = 3
        '
        'lblTotalReturnBeforeDiscTitle
        '
        Me.lblTotalReturnBeforeDiscTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalReturnBeforeDiscTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblTotalReturnBeforeDiscTitle.Location = New System.Drawing.Point(215, 95)
        Me.lblTotalReturnBeforeDiscTitle.Name = "lblTotalReturnBeforeDiscTitle"
        Me.lblTotalReturnBeforeDiscTitle.Size = New System.Drawing.Size(140, 22)
        Me.lblTotalReturnBeforeDiscTitle.TabIndex = 4
        Me.lblTotalReturnBeforeDiscTitle.Text = "إجمالي الأصناف:"
        Me.lblTotalReturnBeforeDiscTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalReturnBeforeDisc
        '
        Me.lblTotalReturnBeforeDisc.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalReturnBeforeDisc.ForeColor = System.Drawing.Color.Black
        Me.lblTotalReturnBeforeDisc.Location = New System.Drawing.Point(12, 95)
        Me.lblTotalReturnBeforeDisc.Name = "lblTotalReturnBeforeDisc"
        Me.lblTotalReturnBeforeDisc.Size = New System.Drawing.Size(200, 22)
        Me.lblTotalReturnBeforeDisc.TabIndex = 5
        Me.lblTotalReturnBeforeDisc.Text = "0.00 ج.م"
        Me.lblTotalReturnBeforeDisc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiscountDeductionTitle
        '
        Me.lblDiscountDeductionTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblDiscountDeductionTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblDiscountDeductionTitle.Location = New System.Drawing.Point(215, 122)
        Me.lblDiscountDeductionTitle.Name = "lblDiscountDeductionTitle"
        Me.lblDiscountDeductionTitle.Size = New System.Drawing.Size(140, 22)
        Me.lblDiscountDeductionTitle.TabIndex = 6
        Me.lblDiscountDeductionTitle.Text = "خصم مسترد:"
        Me.lblDiscountDeductionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDiscountDeduction
        '
        Me.lblDiscountDeduction.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblDiscountDeduction.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.lblDiscountDeduction.Location = New System.Drawing.Point(12, 122)
        Me.lblDiscountDeduction.Name = "lblDiscountDeduction"
        Me.lblDiscountDeduction.Size = New System.Drawing.Size(200, 22)
        Me.lblDiscountDeduction.TabIndex = 7
        Me.lblDiscountDeduction.Text = "0.00 ج.م"
        Me.lblDiscountDeduction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'separator2
        '
        Me.separator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.separator2.Location = New System.Drawing.Point(12, 150)
        Me.separator2.Name = "separator2"
        Me.separator2.Size = New System.Drawing.Size(345, 1)
        Me.separator2.TabIndex = 8
        '
        'lblNetRefundTitle
        '
        Me.lblNetRefundTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblNetRefundTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblNetRefundTitle.Location = New System.Drawing.Point(195, 160)
        Me.lblNetRefundTitle.Name = "lblNetRefundTitle"
        Me.lblNetRefundTitle.Size = New System.Drawing.Size(160, 28)
        Me.lblNetRefundTitle.TabIndex = 9
        Me.lblNetRefundTitle.Text = "صافي المرتجع المسترد:"
        Me.lblNetRefundTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNetRefund
        '
        Me.lblNetRefund.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblNetRefund.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblNetRefund.Location = New System.Drawing.Point(12, 155)
        Me.lblNetRefund.Name = "lblNetRefund"
        Me.lblNetRefund.Size = New System.Drawing.Size(185, 35)
        Me.lblNetRefund.TabIndex = 10
        Me.lblNetRefund.Text = "0.00 ج.م"
        Me.lblNetRefund.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRefundMethodTitle
        '
        Me.lblRefundMethodTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblRefundMethodTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblRefundMethodTitle.Location = New System.Drawing.Point(195, 200)
        Me.lblRefundMethodTitle.Name = "lblRefundMethodTitle"
        Me.lblRefundMethodTitle.Size = New System.Drawing.Size(160, 22)
        Me.lblRefundMethodTitle.TabIndex = 11
        Me.lblRefundMethodTitle.Text = "طريقة صرف المرتجع:"
        Me.lblRefundMethodTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbRefundMethod
        '
        Me.cmbRefundMethod.BackColor = System.Drawing.Color.Transparent
        Me.cmbRefundMethod.BorderRadius = 6
        Me.cmbRefundMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRefundMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRefundMethod.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cmbRefundMethod.ForeColor = System.Drawing.Color.Black
        Me.cmbRefundMethod.ItemHeight = 28
        Me.cmbRefundMethod.Location = New System.Drawing.Point(12, 225)
        Me.cmbRefundMethod.Name = "cmbRefundMethod"
        Me.cmbRefundMethod.Size = New System.Drawing.Size(345, 34)
        Me.cmbRefundMethod.TabIndex = 12
        Me.cmbRefundMethod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTreasuryTitle
        '
        Me.lblTreasuryTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTreasuryTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTreasuryTitle.Location = New System.Drawing.Point(195, 268)
        Me.lblTreasuryTitle.Name = "lblTreasuryTitle"
        Me.lblTreasuryTitle.Size = New System.Drawing.Size(160, 22)
        Me.lblTreasuryTitle.TabIndex = 13
        Me.lblTreasuryTitle.Text = "الخزينة المنصرف منها:"
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
        Me.cmbTreasury.Location = New System.Drawing.Point(12, 292)
        Me.cmbTreasury.Name = "cmbTreasury"
        Me.cmbTreasury.Size = New System.Drawing.Size(345, 34)
        Me.cmbTreasury.TabIndex = 14
        Me.cmbTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblReasonTitle
        '
        Me.lblReasonTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblReasonTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblReasonTitle.Location = New System.Drawing.Point(195, 335)
        Me.lblReasonTitle.Name = "lblReasonTitle"
        Me.lblReasonTitle.Size = New System.Drawing.Size(160, 22)
        Me.lblReasonTitle.TabIndex = 15
        Me.lblReasonTitle.Text = "سبب الإرجاع الرئيسي:"
        Me.lblReasonTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbReturnReason
        '
        Me.cmbReturnReason.BackColor = System.Drawing.Color.Transparent
        Me.cmbReturnReason.BorderRadius = 6
        Me.cmbReturnReason.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbReturnReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReturnReason.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbReturnReason.ForeColor = System.Drawing.Color.Black
        Me.cmbReturnReason.ItemHeight = 28
        Me.cmbReturnReason.Location = New System.Drawing.Point(12, 358)
        Me.cmbReturnReason.Name = "cmbReturnReason"
        Me.cmbReturnReason.Size = New System.Drawing.Size(345, 34)
        Me.cmbReturnReason.TabIndex = 16
        Me.cmbReturnReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNotesTitle
        '
        Me.lblNotesTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblNotesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblNotesTitle.Location = New System.Drawing.Point(195, 400)
        Me.lblNotesTitle.Name = "lblNotesTitle"
        Me.lblNotesTitle.Size = New System.Drawing.Size(160, 20)
        Me.lblNotesTitle.TabIndex = 17
        Me.lblNotesTitle.Text = "ملاحظات إضافية:"
        Me.lblNotesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReturnNotes
        '
        Me.txtReturnNotes.BorderRadius = 6
        Me.txtReturnNotes.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtReturnNotes.Location = New System.Drawing.Point(12, 422)
        Me.txtReturnNotes.Multiline = True
        Me.txtReturnNotes.Name = "txtReturnNotes"
        Me.txtReturnNotes.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtReturnNotes.PlaceholderText = "ملاحظات إضافية على المرتجع (اختياري)..."
        Me.txtReturnNotes.SelectedText = ""
        Me.txtReturnNotes.Size = New System.Drawing.Size(345, 60)
        Me.txtReturnNotes.TabIndex = 18
        Me.txtReturnNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSaveReturn
        '
        Me.btnSaveReturn.BorderRadius = 8
        Me.btnSaveReturn.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnSaveReturn.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveReturn.ForeColor = System.Drawing.Color.White
        Me.btnSaveReturn.Location = New System.Drawing.Point(12, 495)
        Me.btnSaveReturn.Name = "btnSaveReturn"
        Me.btnSaveReturn.Size = New System.Drawing.Size(345, 48)
        Me.btnSaveReturn.TabIndex = 19
        Me.btnSaveReturn.Text = "✔ تأكيد وحفظ المرتجع (F10)"
        '
        'btnPrintReceipt
        '
        Me.btnPrintReceipt.BorderRadius = 8
        Me.btnPrintReceipt.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnPrintReceipt.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnPrintReceipt.ForeColor = System.Drawing.Color.White
        Me.btnPrintReceipt.Location = New System.Drawing.Point(12, 552)
        Me.btnPrintReceipt.Name = "btnPrintReceipt"
        Me.btnPrintReceipt.Size = New System.Drawing.Size(345, 42)
        Me.btnPrintReceipt.TabIndex = 20
        Me.btnPrintReceipt.Text = "🖨️ طباعة إيصال المرتجع"
        '
        'pnlGridArea
        '
        Me.pnlGridArea.Controls.Add(Me.dgvReturnItems)
        Me.pnlGridArea.Controls.Add(Me.pnlInvoiceInfo)
        Me.pnlGridArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGridArea.Location = New System.Drawing.Point(382, 12)
        Me.pnlGridArea.Name = "pnlGridArea"
        Me.pnlGridArea.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.pnlGridArea.Size = New System.Drawing.Size(886, 610)
        Me.pnlGridArea.TabIndex = 1
        '
        'pnlInvoiceInfo
        '
        Me.pnlInvoiceInfo.BackColor = System.Drawing.Color.Transparent
        Me.pnlInvoiceInfo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pnlInvoiceInfo.BorderRadius = 8
        Me.pnlInvoiceInfo.BorderThickness = 1
        Me.pnlInvoiceInfo.Controls.Add(Me.lblInvoiceInfo)
        Me.pnlInvoiceInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInvoiceInfo.FillColor = System.Drawing.Color.White
        Me.pnlInvoiceInfo.Location = New System.Drawing.Point(10, 0)
        Me.pnlInvoiceInfo.Name = "pnlInvoiceInfo"
        Me.pnlInvoiceInfo.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlInvoiceInfo.Size = New System.Drawing.Size(876, 48)
        Me.pnlInvoiceInfo.TabIndex = 0
        '
        'lblInvoiceInfo
        '
        Me.lblInvoiceInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInvoiceInfo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInvoiceInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.lblInvoiceInfo.Location = New System.Drawing.Point(10, 10)
        Me.lblInvoiceInfo.Name = "lblInvoiceInfo"
        Me.lblInvoiceInfo.Size = New System.Drawing.Size(856, 28)
        Me.lblInvoiceInfo.TabIndex = 0
        Me.lblInvoiceInfo.Text = "لم يتم تحديد فاتورة بعد. ادخل رقم الفاتورة أو اضف أصناف حرة للإرجاع."
        Me.lblInvoiceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvReturnItems
        '
        Me.dgvReturnItems.AllowUserToAddRows = False
        Me.dgvReturnItems.AllowUserToDeleteRows = False
        Me.dgvReturnItems.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dgvReturnItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReturnItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReturnItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvReturnItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReturnItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvReturnItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReturnItems.ColumnHeadersHeight = 40
        Me.dgvReturnItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colProductID, Me.colSizeID, Me.colAddonID, Me.colProductName, Me.colSizeName, Me.colAddonsText, Me.colUnitPrice, Me.colOriginalQty, Me.colReturnQty, Me.colTotalPrice, Me.colRestoreStock, Me.colItemNotes})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReturnItems.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReturnItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReturnItems.EnableHeadersVisualStyles = False
        Me.dgvReturnItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvReturnItems.Location = New System.Drawing.Point(10, 48)
        Me.dgvReturnItems.MultiSelect = False
        Me.dgvReturnItems.Name = "dgvReturnItems"
        Me.dgvReturnItems.RowHeadersVisible = False
        Me.dgvReturnItems.RowTemplate.Height = 36
        Me.dgvReturnItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvReturnItems.Size = New System.Drawing.Size(876, 562)
        Me.dgvReturnItems.TabIndex = 1
        '
        'colSelect
        '
        Me.colSelect.FillWeight = 45.0!
        Me.colSelect.HeaderText = "إرجاع؟"
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Width = 50
        '
        'colProductID
        '
        Me.colProductID.HeaderText = "ProductID"
        Me.colProductID.Name = "colProductID"
        Me.colProductID.Visible = False
        '
        'colSizeID
        '
        Me.colSizeID.HeaderText = "SizeID"
        Me.colSizeID.Name = "colSizeID"
        Me.colSizeID.Visible = False
        '
        'colAddonID
        '
        Me.colAddonID.HeaderText = "AddonID"
        Me.colAddonID.Name = "colAddonID"
        Me.colAddonID.Visible = False
        '
        'colProductName
        '
        Me.colProductName.FillWeight = 160.0!
        Me.colProductName.HeaderText = "اسم الصنف"
        Me.colProductName.Name = "colProductName"
        Me.colProductName.ReadOnly = True
        '
        'colSizeName
        '
        Me.colSizeName.FillWeight = 75.0!
        Me.colSizeName.HeaderText = "الحجم"
        Me.colSizeName.Name = "colSizeName"
        Me.colSizeName.ReadOnly = True
        '
        'colAddonsText
        '
        Me.colAddonsText.FillWeight = 90.0!
        Me.colAddonsText.HeaderText = "الإضافات"
        Me.colAddonsText.Name = "colAddonsText"
        Me.colAddonsText.ReadOnly = True
        '
        'colUnitPrice
        '
        Me.colUnitPrice.FillWeight = 70.0!
        Me.colUnitPrice.HeaderText = "السعر"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        '
        'colOriginalQty
        '
        Me.colOriginalQty.FillWeight = 65.0!
        Me.colOriginalQty.HeaderText = "المباع"
        Me.colOriginalQty.Name = "colOriginalQty"
        Me.colOriginalQty.ReadOnly = True
        '
        'colReturnQty
        '
        Me.colReturnQty.FillWeight = 75.0!
        Me.colReturnQty.HeaderText = "المرتجع"
        Me.colReturnQty.Name = "colReturnQty"
        '
        'colTotalPrice
        '
        Me.colTotalPrice.FillWeight = 85.0!
        Me.colTotalPrice.HeaderText = "الإجمالي"
        Me.colTotalPrice.Name = "colTotalPrice"
        Me.colTotalPrice.ReadOnly = True
        '
        'colRestoreStock
        '
        Me.colRestoreStock.FillWeight = 70.0!
        Me.colRestoreStock.HeaderText = "إرجاع مخزن"
        Me.colRestoreStock.Name = "colRestoreStock"
        '
        'colItemNotes
        '
        Me.colItemNotes.FillWeight = 110.0!
        Me.colItemNotes.HeaderText = "سبب الإرجاع"
        Me.colItemNotes.Name = "colItemNotes"
        '
        'Sales_Returns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1280, 740)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlTopBar)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Sales_Returns"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "إدارة مرتجعات المبيعات"
        Me.panelHeader.ResumeLayout(False)
        Me.pnlTopBar.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlGridArea.ResumeLayout(False)
        Me.pnlInvoiceInfo.ResumeLayout(False)
        CType(Me.dgvReturnItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSummaryCard.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents pnlTopBar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtInvoiceSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSearchInvoice As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtItemSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnReturnAll As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNewReturn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlGridArea As System.Windows.Forms.Panel
    Friend WithEvents pnlInvoiceInfo As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblInvoiceInfo As System.Windows.Forms.Label
    Friend WithEvents dgvReturnItems As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents pnlSummaryCard As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCardTitle As System.Windows.Forms.Label
    Friend WithEvents lblCustomerHeader As System.Windows.Forms.Label
    Friend WithEvents lblCustomerBalance As System.Windows.Forms.Label
    Friend WithEvents separator1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalReturnBeforeDiscTitle As System.Windows.Forms.Label
    Friend WithEvents lblTotalReturnBeforeDisc As System.Windows.Forms.Label
    Friend WithEvents lblDiscountDeductionTitle As System.Windows.Forms.Label
    Friend WithEvents lblDiscountDeduction As System.Windows.Forms.Label
    Friend WithEvents separator2 As System.Windows.Forms.Label
    Friend WithEvents lblNetRefundTitle As System.Windows.Forms.Label
    Friend WithEvents lblNetRefund As System.Windows.Forms.Label
    Friend WithEvents lblRefundMethodTitle As System.Windows.Forms.Label
    Friend WithEvents cmbRefundMethod As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblTreasuryTitle As System.Windows.Forms.Label
    Friend WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblReasonTitle As System.Windows.Forms.Label
    Friend WithEvents cmbReturnReason As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblNotesTitle As System.Windows.Forms.Label
    Friend WithEvents txtReturnNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSaveReturn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPrintReceipt As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents colSelect As DataGridViewCheckBoxColumn
    Friend WithEvents colProductID As DataGridViewTextBoxColumn
    Friend WithEvents colSizeID As DataGridViewTextBoxColumn
    Friend WithEvents colAddonID As DataGridViewTextBoxColumn
    Friend WithEvents colProductName As DataGridViewTextBoxColumn
    Friend WithEvents colSizeName As DataGridViewTextBoxColumn
    Friend WithEvents colAddonsText As DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As DataGridViewTextBoxColumn
    Friend WithEvents colOriginalQty As DataGridViewTextBoxColumn
    Friend WithEvents colReturnQty As DataGridViewTextBoxColumn
    Friend WithEvents colTotalPrice As DataGridViewTextBoxColumn
    Friend WithEvents colRestoreStock As DataGridViewCheckBoxColumn
    Friend WithEvents colItemNotes As DataGridViewTextBoxColumn

End Class
