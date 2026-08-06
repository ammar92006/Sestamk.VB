<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblShiftInfo = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.cmbOrderType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbCustomer = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnAddCustomer = New Guna.UI2.WinForms.Guna2Button()
        Me.txtTableNo = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtSearchProduct = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnlFooter = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblSubTotalTitle = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.lblDiscountTitle = New System.Windows.Forms.Label()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.lblTaxTitle = New System.Windows.Forms.Label()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.lblNetTotalTitle = New System.Windows.Forms.Label()
        Me.lblNetTotal = New System.Windows.Forms.Label()
        Me.btnPayCash = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPayVisa = New Guna.UI2.WinForms.Guna2Button()
        Me.btnHoldInvoice = New Guna.UI2.WinForms.Guna2Button()
        Me.btnGetHeldInvoices = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancelInvoice = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlTouchMenu = New System.Windows.Forms.Panel()
        Me.pnlProductsFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlCategoriesFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlInvoiceGrid = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgvInvoiceDetails = New System.Windows.Forms.DataGridView()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAddons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblInvoiceHeader = New System.Windows.Forms.Label()
        Me.pnlQtyStrip = New System.Windows.Forms.Panel()
        Me.btnQtyMinus = New Guna.UI2.WinForms.Guna2Button()
        Me.btnQtyPlus = New Guna.UI2.WinForms.Guna2Button()
        Me.btnChangeQty = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddAddonToItem = New Guna.UI2.WinForms.Guna2Button()
        Me.tmrClock = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHeader.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlTouchMenu.SuspendLayout()
        Me.pnlInvoiceGrid.SuspendLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlQtyStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblShiftInfo)
        Me.pnlHeader.Controls.Add(Me.lblDateTime)
        Me.pnlHeader.Controls.Add(Me.cmbOrderType)
        Me.pnlHeader.Controls.Add(Me.cmbCustomer)
        Me.pnlHeader.Controls.Add(Me.btnAddCustomer)
        Me.pnlHeader.Controls.Add(Me.txtTableNo)
        Me.pnlHeader.Controls.Add(Me.txtSearchProduct)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.FillColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1280, 65)
        Me.pnlHeader.TabIndex = 2
        '
        'lblShiftInfo
        '
        Me.lblShiftInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShiftInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblShiftInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblShiftInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.lblShiftInfo.Location = New System.Drawing.Point(820, 10)
        Me.lblShiftInfo.Name = "lblShiftInfo"
        Me.lblShiftInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblShiftInfo.Size = New System.Drawing.Size(350, 44)
        Me.lblShiftInfo.TabIndex = 10
        Me.lblShiftInfo.Text = "الوردية: صباحية  |  المستخدم: Admin"
        Me.lblShiftInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateTime.BackColor = System.Drawing.Color.Transparent
        Me.lblDateTime.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.lblDateTime.Location = New System.Drawing.Point(1180, 10)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDateTime.Size = New System.Drawing.Size(90, 44)
        Me.lblDateTime.TabIndex = 11
        Me.lblDateTime.Text = "00:00"
        Me.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbOrderType
        '
        Me.cmbOrderType.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.cmbOrderType.BorderRadius = 6
        Me.cmbOrderType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrderType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.cmbOrderType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.cmbOrderType.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbOrderType.ForeColor = System.Drawing.Color.White
        Me.cmbOrderType.ItemHeight = 36
        Me.cmbOrderType.Items.AddRange(New Object() {"صالة", "تيك أواي", "توصيل"})
        Me.cmbOrderType.Location = New System.Drawing.Point(10, 12)
        Me.cmbOrderType.Name = "cmbOrderType"
        Me.cmbOrderType.Size = New System.Drawing.Size(165, 42)
        Me.cmbOrderType.TabIndex = 1
        '
        'cmbCustomer
        '
        Me.cmbCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.cmbCustomer.BorderRadius = 6
        Me.cmbCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomer.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.cmbCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.cmbCustomer.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.White
        Me.cmbCustomer.ItemHeight = 36
        Me.cmbCustomer.Location = New System.Drawing.Point(185, 12)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(200, 42)
        Me.cmbCustomer.TabIndex = 2
        '
        'btnAddCustomer
        '
        Me.btnAddCustomer.BorderRadius = 20
        Me.btnAddCustomer.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnAddCustomer.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddCustomer.ForeColor = System.Drawing.Color.White
        Me.btnAddCustomer.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnAddCustomer.Location = New System.Drawing.Point(393, 12)
        Me.btnAddCustomer.Name = "btnAddCustomer"
        Me.btnAddCustomer.Size = New System.Drawing.Size(42, 42)
        Me.btnAddCustomer.TabIndex = 3
        Me.btnAddCustomer.Text = "+"
        '
        'txtTableNo
        '
        Me.txtTableNo.BorderRadius = 6
        Me.txtTableNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTableNo.DefaultText = ""
        Me.txtTableNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.txtTableNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.txtTableNo.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtTableNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtTableNo.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTableNo.ForeColor = System.Drawing.Color.White
        Me.txtTableNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.txtTableNo.Location = New System.Drawing.Point(445, 12)
        Me.txtTableNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTableNo.Name = "txtTableNo"
        Me.txtTableNo.PlaceholderText = "رقم الطاولة"
        Me.txtTableNo.SelectedText = ""
        Me.txtTableNo.Size = New System.Drawing.Size(120, 42)
        Me.txtTableNo.TabIndex = 4
        Me.txtTableNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSearchProduct
        '
        Me.txtSearchProduct.BorderRadius = 6
        Me.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearchProduct.DefaultText = ""
        Me.txtSearchProduct.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtSearchProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtSearchProduct.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSearchProduct.ForeColor = System.Drawing.Color.White
        Me.txtSearchProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.txtSearchProduct.Location = New System.Drawing.Point(575, 12)
        Me.txtSearchProduct.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSearchProduct.Name = "txtSearchProduct"
        Me.txtSearchProduct.PlaceholderText = "🔍 بحث سريع عن منتج..."
        Me.txtSearchProduct.SelectedText = ""
        Me.txtSearchProduct.Size = New System.Drawing.Size(235, 42)
        Me.txtSearchProduct.TabIndex = 5
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.pnlFooter.Controls.Add(Me.lblSubTotalTitle)
        Me.pnlFooter.Controls.Add(Me.lblSubTotal)
        Me.pnlFooter.Controls.Add(Me.lblDiscountTitle)
        Me.pnlFooter.Controls.Add(Me.lblDiscount)
        Me.pnlFooter.Controls.Add(Me.lblTaxTitle)
        Me.pnlFooter.Controls.Add(Me.lblTax)
        Me.pnlFooter.Controls.Add(Me.lblNetTotalTitle)
        Me.pnlFooter.Controls.Add(Me.lblNetTotal)
        Me.pnlFooter.Controls.Add(Me.btnPayCash)
        Me.pnlFooter.Controls.Add(Me.btnPayVisa)
        Me.pnlFooter.Controls.Add(Me.btnHoldInvoice)
        Me.pnlFooter.Controls.Add(Me.btnGetHeldInvoices)
        Me.pnlFooter.Controls.Add(Me.btnCancelInvoice)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.pnlFooter.Location = New System.Drawing.Point(0, 655)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(1280, 145)
        Me.pnlFooter.TabIndex = 1
        '
        'lblSubTotalTitle
        '
        Me.lblSubTotalTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotalTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTotalTitle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblSubTotalTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.lblSubTotalTitle.Location = New System.Drawing.Point(1080, 8)
        Me.lblSubTotalTitle.Name = "lblSubTotalTitle"
        Me.lblSubTotalTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSubTotalTitle.Size = New System.Drawing.Size(100, 22)
        Me.lblSubTotalTitle.TabIndex = 50
        Me.lblSubTotalTitle.Text = "المجموع:"
        Me.lblSubTotalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTotal.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblSubTotal.ForeColor = System.Drawing.Color.White
        Me.lblSubTotal.Location = New System.Drawing.Point(1160, 8)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSubTotal.Size = New System.Drawing.Size(110, 22)
        Me.lblSubTotal.TabIndex = 51
        Me.lblSubTotal.Text = "0.00"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiscountTitle
        '
        Me.lblDiscountTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiscountTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblDiscountTitle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDiscountTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.lblDiscountTitle.Location = New System.Drawing.Point(1080, 36)
        Me.lblDiscountTitle.Name = "lblDiscountTitle"
        Me.lblDiscountTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDiscountTitle.Size = New System.Drawing.Size(100, 22)
        Me.lblDiscountTitle.TabIndex = 52
        Me.lblDiscountTitle.Text = "الخصم:"
        Me.lblDiscountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDiscount
        '
        Me.lblDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiscount.BackColor = System.Drawing.Color.Transparent
        Me.lblDiscount.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.lblDiscount.Location = New System.Drawing.Point(1160, 36)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDiscount.Size = New System.Drawing.Size(110, 22)
        Me.lblDiscount.TabIndex = 53
        Me.lblDiscount.Text = "0.00"
        Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTaxTitle
        '
        Me.lblTaxTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTaxTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTaxTitle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTaxTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.lblTaxTitle.Location = New System.Drawing.Point(1080, 64)
        Me.lblTaxTitle.Name = "lblTaxTitle"
        Me.lblTaxTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTaxTitle.Size = New System.Drawing.Size(100, 22)
        Me.lblTaxTitle.TabIndex = 54
        Me.lblTaxTitle.Text = "الضريبة:"
        Me.lblTaxTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTax
        '
        Me.lblTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTax.BackColor = System.Drawing.Color.Transparent
        Me.lblTax.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTax.ForeColor = System.Drawing.Color.White
        Me.lblTax.Location = New System.Drawing.Point(1160, 64)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTax.Size = New System.Drawing.Size(110, 22)
        Me.lblTax.TabIndex = 55
        Me.lblTax.Text = "0.00"
        Me.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNetTotalTitle
        '
        Me.lblNetTotalTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNetTotalTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblNetTotalTitle.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblNetTotalTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblNetTotalTitle.Location = New System.Drawing.Point(1040, 92)
        Me.lblNetTotalTitle.Name = "lblNetTotalTitle"
        Me.lblNetTotalTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNetTotalTitle.Size = New System.Drawing.Size(140, 40)
        Me.lblNetTotalTitle.TabIndex = 56
        Me.lblNetTotalTitle.Text = "الصافي الكلي:"
        Me.lblNetTotalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNetTotal
        '
        Me.lblNetTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNetTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblNetTotal.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblNetTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblNetTotal.Location = New System.Drawing.Point(1155, 88)
        Me.lblNetTotal.Name = "lblNetTotal"
        Me.lblNetTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNetTotal.Size = New System.Drawing.Size(115, 46)
        Me.lblNetTotal.TabIndex = 57
        Me.lblNetTotal.Text = "0.00"
        Me.lblNetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPayCash
        '
        Me.btnPayCash.BorderRadius = 10
        Me.btnPayCash.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnPayCash.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPayCash.ForeColor = System.Drawing.Color.White
        Me.btnPayCash.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnPayCash.Location = New System.Drawing.Point(10, 10)
        Me.btnPayCash.Name = "btnPayCash"
        Me.btnPayCash.PressedColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnPayCash.Size = New System.Drawing.Size(145, 55)
        Me.btnPayCash.TabIndex = 60
        Me.btnPayCash.Text = "💰  نقداً"
        '
        'btnPayVisa
        '
        Me.btnPayVisa.BorderRadius = 10
        Me.btnPayVisa.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnPayVisa.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPayVisa.ForeColor = System.Drawing.Color.White
        Me.btnPayVisa.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnPayVisa.Location = New System.Drawing.Point(165, 10)
        Me.btnPayVisa.Name = "btnPayVisa"
        Me.btnPayVisa.PressedColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.btnPayVisa.Size = New System.Drawing.Size(145, 55)
        Me.btnPayVisa.TabIndex = 61
        Me.btnPayVisa.Text = "💳  فيزا"
        '
        'btnHoldInvoice
        '
        Me.btnHoldInvoice.BorderRadius = 10
        Me.btnHoldInvoice.FillColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.btnHoldInvoice.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnHoldInvoice.ForeColor = System.Drawing.Color.White
        Me.btnHoldInvoice.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnHoldInvoice.Location = New System.Drawing.Point(320, 10)
        Me.btnHoldInvoice.Name = "btnHoldInvoice"
        Me.btnHoldInvoice.PressedColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.btnHoldInvoice.Size = New System.Drawing.Size(135, 50)
        Me.btnHoldInvoice.TabIndex = 62
        Me.btnHoldInvoice.Text = "⏸  تعليق"
        '
        'btnGetHeldInvoices
        '
        Me.btnGetHeldInvoices.BorderRadius = 10
        Me.btnGetHeldInvoices.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnGetHeldInvoices.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnGetHeldInvoices.ForeColor = System.Drawing.Color.White
        Me.btnGetHeldInvoices.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnGetHeldInvoices.Location = New System.Drawing.Point(465, 10)
        Me.btnGetHeldInvoices.Name = "btnGetHeldInvoices"
        Me.btnGetHeldInvoices.PressedColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnGetHeldInvoices.Size = New System.Drawing.Size(155, 50)
        Me.btnGetHeldInvoices.TabIndex = 63
        Me.btnGetHeldInvoices.Text = "📋  المعلقة"
        '
        'btnCancelInvoice
        '
        Me.btnCancelInvoice.BorderRadius = 10
        Me.btnCancelInvoice.FillColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnCancelInvoice.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancelInvoice.ForeColor = System.Drawing.Color.White
        Me.btnCancelInvoice.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnCancelInvoice.Location = New System.Drawing.Point(630, 10)
        Me.btnCancelInvoice.Name = "btnCancelInvoice"
        Me.btnCancelInvoice.PressedColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnCancelInvoice.Size = New System.Drawing.Size(135, 50)
        Me.btnCancelInvoice.TabIndex = 64
        Me.btnCancelInvoice.Text = "✖  إلغاء"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlTouchMenu)
        Me.pnlMain.Controls.Add(Me.pnlInvoiceGrid)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 65)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1280, 590)
        Me.pnlMain.TabIndex = 0
        '
        'pnlTouchMenu
        '
        Me.pnlTouchMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.pnlTouchMenu.Controls.Add(Me.pnlProductsFlow)
        Me.pnlTouchMenu.Controls.Add(Me.pnlCategoriesFlow)
        Me.pnlTouchMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTouchMenu.Location = New System.Drawing.Point(490, 0)
        Me.pnlTouchMenu.Name = "pnlTouchMenu"
        Me.pnlTouchMenu.Size = New System.Drawing.Size(790, 590)
        Me.pnlTouchMenu.TabIndex = 0
        '
        'pnlProductsFlow
        '
        Me.pnlProductsFlow.AutoScroll = True
        Me.pnlProductsFlow.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.pnlProductsFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProductsFlow.Location = New System.Drawing.Point(0, 0)
        Me.pnlProductsFlow.Name = "pnlProductsFlow"
        Me.pnlProductsFlow.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlProductsFlow.Size = New System.Drawing.Size(572, 590)
        Me.pnlProductsFlow.TabIndex = 0
        '
        'pnlCategoriesFlow
        '
        Me.pnlCategoriesFlow.AutoScroll = True
        Me.pnlCategoriesFlow.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.pnlCategoriesFlow.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCategoriesFlow.Location = New System.Drawing.Point(572, 0)
        Me.pnlCategoriesFlow.Name = "pnlCategoriesFlow"
        Me.pnlCategoriesFlow.Padding = New System.Windows.Forms.Padding(8, 10, 8, 10)
        Me.pnlCategoriesFlow.Size = New System.Drawing.Size(218, 590)
        Me.pnlCategoriesFlow.TabIndex = 1
        Me.pnlCategoriesFlow.WrapContents = False
        '
        'pnlInvoiceGrid
        '
        Me.pnlInvoiceGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.pnlInvoiceGrid.Controls.Add(Me.dgvInvoiceDetails)
        Me.pnlInvoiceGrid.Controls.Add(Me.lblInvoiceHeader)
        Me.pnlInvoiceGrid.Controls.Add(Me.pnlQtyStrip)
        Me.pnlInvoiceGrid.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlInvoiceGrid.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.pnlInvoiceGrid.Location = New System.Drawing.Point(0, 0)
        Me.pnlInvoiceGrid.Name = "pnlInvoiceGrid"
        Me.pnlInvoiceGrid.Size = New System.Drawing.Size(490, 590)
        Me.pnlInvoiceGrid.TabIndex = 1
        '
        'dgvInvoiceDetails
        '
        Me.dgvInvoiceDetails.AllowUserToAddRows = False
        Me.dgvInvoiceDetails.AllowUserToDeleteRows = False
        Me.dgvInvoiceDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.dgvInvoiceDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.dgvInvoiceDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoiceDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvInvoiceDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.dgvInvoiceDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInvoiceDetails.ColumnHeadersHeight = 45
        Me.dgvInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInvoiceDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemName, Me.colSize, Me.colPrice, Me.colQty, Me.colAddons, Me.colTotal, Me.colDelete})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInvoiceDetails.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceDetails.GridColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(0, 42)
        Me.dgvInvoiceDetails.MultiSelect = False
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvInvoiceDetails.RowHeadersVisible = False
        Me.dgvInvoiceDetails.RowTemplate.Height = 42
        Me.dgvInvoiceDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvInvoiceDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(490, 490)
        Me.dgvInvoiceDetails.TabIndex = 1
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.FillWeight = 28.0!
        Me.colItemName.HeaderText = "المنتج"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        '
        'colSize
        '
        Me.colSize.DataPropertyName = "SizeName"
        Me.colSize.FillWeight = 12.0!
        Me.colSize.HeaderText = "الحجم"
        Me.colSize.Name = "colSize"
        Me.colSize.ReadOnly = True
        '
        'colPrice
        '
        Me.colPrice.DataPropertyName = "Price"
        Me.colPrice.FillWeight = 12.0!
        Me.colPrice.HeaderText = "السعر"
        Me.colPrice.Name = "colPrice"
        Me.colPrice.ReadOnly = True
        '
        'colQty
        '
        Me.colQty.DataPropertyName = "Qty"
        Me.colQty.FillWeight = 10.0!
        Me.colQty.HeaderText = "الكمية"
        Me.colQty.Name = "colQty"
        '
        'colAddons
        '
        Me.colAddons.DataPropertyName = "Addons"
        Me.colAddons.FillWeight = 18.0!
        Me.colAddons.HeaderText = "إضافات"
        Me.colAddons.Name = "colAddons"
        Me.colAddons.ReadOnly = True
        '
        'colTotal
        '
        Me.colTotal.DataPropertyName = "Total"
        Me.colTotal.FillWeight = 12.0!
        Me.colTotal.HeaderText = "الإجمالي"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        '
        'colDelete
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(50, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        Me.colDelete.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDelete.FillWeight = 8.0!
        Me.colDelete.HeaderText = "حذف"
        Me.colDelete.Name = "colDelete"
        Me.colDelete.Text = "✖"
        Me.colDelete.UseColumnTextForButtonValue = True
        '
        'lblInvoiceHeader
        '
        Me.lblInvoiceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblInvoiceHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInvoiceHeader.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblInvoiceHeader.ForeColor = System.Drawing.Color.White
        Me.lblInvoiceHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblInvoiceHeader.Name = "lblInvoiceHeader"
        Me.lblInvoiceHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblInvoiceHeader.Size = New System.Drawing.Size(490, 42)
        Me.lblInvoiceHeader.TabIndex = 0
        Me.lblInvoiceHeader.Text = "   🧾  فاتورة المبيعات"
        Me.lblInvoiceHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlQtyStrip
        '
        Me.pnlQtyStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.pnlQtyStrip.Controls.Add(Me.btnQtyMinus)
        Me.pnlQtyStrip.Controls.Add(Me.btnQtyPlus)
        Me.pnlQtyStrip.Controls.Add(Me.btnChangeQty)
        Me.pnlQtyStrip.Controls.Add(Me.btnAddAddonToItem)
        Me.pnlQtyStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlQtyStrip.Location = New System.Drawing.Point(0, 532)
        Me.pnlQtyStrip.Name = "pnlQtyStrip"
        Me.pnlQtyStrip.Size = New System.Drawing.Size(490, 58)
        Me.pnlQtyStrip.TabIndex = 2
        '
        'btnQtyMinus
        '
        Me.btnQtyMinus.BorderRadius = 8
        Me.btnQtyMinus.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnQtyMinus.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnQtyMinus.ForeColor = System.Drawing.Color.White
        Me.btnQtyMinus.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnQtyMinus.Location = New System.Drawing.Point(6, 6)
        Me.btnQtyMinus.Name = "btnQtyMinus"
        Me.btnQtyMinus.Size = New System.Drawing.Size(68, 44)
        Me.btnQtyMinus.TabIndex = 70
        Me.btnQtyMinus.Text = "−"
        '
        'btnQtyPlus
        '
        Me.btnQtyPlus.BorderRadius = 8
        Me.btnQtyPlus.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnQtyPlus.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnQtyPlus.ForeColor = System.Drawing.Color.White
        Me.btnQtyPlus.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnQtyPlus.Location = New System.Drawing.Point(82, 6)
        Me.btnQtyPlus.Name = "btnQtyPlus"
        Me.btnQtyPlus.Size = New System.Drawing.Size(68, 44)
        Me.btnQtyPlus.TabIndex = 71
        Me.btnQtyPlus.Text = "+"
        '
        'btnChangeQty
        '
        Me.btnChangeQty.BorderRadius = 8
        Me.btnChangeQty.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnChangeQty.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnChangeQty.ForeColor = System.Drawing.Color.White
        Me.btnChangeQty.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnChangeQty.Location = New System.Drawing.Point(158, 6)
        Me.btnChangeQty.Name = "btnChangeQty"
        Me.btnChangeQty.Size = New System.Drawing.Size(110, 44)
        Me.btnChangeQty.TabIndex = 72
        Me.btnChangeQty.Text = "🔢 الكمية"
        '
        'btnAddAddonToItem
        '
        Me.btnAddAddonToItem.BorderRadius = 8
        Me.btnAddAddonToItem.FillColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.btnAddAddonToItem.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnAddAddonToItem.ForeColor = System.Drawing.Color.White
        Me.btnAddAddonToItem.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnAddAddonToItem.Location = New System.Drawing.Point(276, 6)
        Me.btnAddAddonToItem.Name = "btnAddAddonToItem"
        Me.btnAddAddonToItem.Size = New System.Drawing.Size(130, 44)
        Me.btnAddAddonToItem.TabIndex = 73
        Me.btnAddAddonToItem.Text = "➕ إضافة صنف"
        '
        'tmrClock
        '
        Me.tmrClock.Enabled = True
        Me.tmrClock.Interval = 1000
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1280, 800)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPOS"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نقطة البيع"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlTouchMenu.ResumeLayout(False)
        Me.pnlInvoiceGrid.ResumeLayout(False)
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlQtyStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    '── Field declarations ───────────────────────────────────────────
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlFooter As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlInvoiceGrid As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlQtyStrip As System.Windows.Forms.Panel
    Friend WithEvents pnlTouchMenu As System.Windows.Forms.Panel
    Friend WithEvents pnlCategoriesFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlProductsFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblShiftInfo As System.Windows.Forms.Label
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents cmbOrderType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmbCustomer As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnAddCustomer As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtTableNo As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtSearchProduct As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblInvoiceHeader As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAddons As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnQtyMinus As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnQtyPlus As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnChangeQty As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddAddonToItem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblSubTotalTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents lblDiscountTitle As System.Windows.Forms.Label
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
    Friend WithEvents lblTaxTitle As System.Windows.Forms.Label
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents lblNetTotalTitle As System.Windows.Forms.Label
    Friend WithEvents lblNetTotal As System.Windows.Forms.Label
    Friend WithEvents btnPayCash As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPayVisa As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnHoldInvoice As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnGetHeldInvoices As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancelInvoice As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tmrClock As System.Windows.Forms.Timer

End Class
