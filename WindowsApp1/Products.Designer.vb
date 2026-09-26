<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Products
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Products))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.pnlSearch = New Guna.UI2.WinForms.Guna2Panel()
        Me.cmbStockFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbFilterCategory = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.grpProductInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.pnlActions = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.dtpPrepTime = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnTaxType = New Guna.UI2.WinForms.Guna2Button()
        Me.txtTax = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnDiscountType = New Guna.UI2.WinForms.Guna2Button()
        Me.txtDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblProfitMargin = New System.Windows.Forms.Label()
        Me.txtMinQuantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnlDirectMode = New Guna.UI2.WinForms.Guna2Panel()
        Me.tgIsDirect = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.lblDirectTitle = New System.Windows.Forms.Label()
        Me.lblDirectStatus = New System.Windows.Forms.Label()
        Me.btnSetupSizesQuick = New Guna.UI2.WinForms.Guna2Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtQuantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCostPrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSalePrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbUnit = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnAddCategoryForm = New Guna.UI2.WinForms.Guna2Button()
        Me.cmbCategory = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProductNameEn = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProductNameAr = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGenBarcode = New Guna.UI2.WinForms.Guna2Button()
        Me.txtBarcode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtProductCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescription = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDeleteImage = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSelectImage = New Guna.UI2.WinForms.Guna2Button()
        Me.picProduct = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.pnlStats = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnExportExcel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnManageAddons = New Guna.UI2.WinForms.Guna2Button()
        Me.btnManageSizes = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.lblLowStockProducts = New System.Windows.Forms.Label()
        Me.lblActiveProducts = New System.Windows.Forms.Label()
        Me.lblTotalProducts = New System.Windows.Forms.Label()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
        Me.grpProductInfo.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.pnlDirectMode.SuspendLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStats.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lstSuggestions)
        Me.Panel1.Controls.Add(Me.dgvProducts)
        Me.Panel1.Controls.Add(Me.pnlSearch)
        Me.Panel1.Controls.Add(Me.grpProductInfo)
        Me.Panel1.Controls.Add(Me.pnlStats)
        Me.Panel1.Controls.Add(Me.panelHeader)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1600, 950)
        Me.Panel1.TabIndex = 0
        '
        'dgvProducts
        '
        Me.dgvProducts.AllowUserToAddRows = False
        Me.dgvProducts.AllowUserToDeleteRows = False
        Me.dgvProducts.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvProducts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProducts.BackgroundColor = System.Drawing.Color.White
        Me.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProducts.ColumnHeadersHeight = 42
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProducts.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProducts.EnableHeadersVisualStyles = False
        Me.dgvProducts.GridColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvProducts.Location = New System.Drawing.Point(0, 565)
        Me.dgvProducts.MultiSelect = False
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvProducts.RowHeadersVisible = False
        Me.dgvProducts.RowTemplate.Height = 36
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(1600, 385)
        Me.dgvProducts.TabIndex = 129
        '
        'lstSuggestions
        '
        Me.lstSuggestions.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 20
        Me.lstSuggestions.Location = New System.Drawing.Point(1090, 560)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lstSuggestions.Size = New System.Drawing.Size(490, 104)
        Me.lstSuggestions.TabIndex = 135
        Me.lstSuggestions.Visible = False
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.pnlSearch.BorderThickness = 1
        Me.pnlSearch.Controls.Add(Me.cmbStockFilter)
        Me.pnlSearch.Controls.Add(Me.cmbFilterCategory)
        Me.pnlSearch.Controls.Add(Me.cmbSearchField)
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Location = New System.Drawing.Point(0, 510)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Padding = New System.Windows.Forms.Padding(12, 6, 12, 6)
        Me.pnlSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlSearch.Size = New System.Drawing.Size(1600, 55)
        Me.pnlSearch.TabIndex = 133
        '
        'cmbStockFilter
        '
        Me.cmbStockFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbStockFilter.BackColor = System.Drawing.Color.Transparent
        Me.cmbStockFilter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.cmbStockFilter.BorderRadius = 6
        Me.cmbStockFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStockFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStockFilter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbStockFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbStockFilter.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.cmbStockFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cmbStockFilter.ItemHeight = 30
        Me.cmbStockFilter.Items.AddRange(New Object() {"جميع حالات المخزون", "المتوفر فقط (>0)", "تحت حد الطلب / نواقص", "الأصناف غير النشطة", "الأصناف المباشرة فقط ⚡", "أصناف متعددة الأحجام 📏"})
        Me.cmbStockFilter.Location = New System.Drawing.Point(20, 8)
        Me.cmbStockFilter.Name = "cmbStockFilter"
        Me.cmbStockFilter.Size = New System.Drawing.Size(220, 36)
        Me.cmbStockFilter.StartIndex = 0
        Me.cmbStockFilter.TabIndex = 4
        '
        'cmbFilterCategory
        '
        Me.cmbFilterCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbFilterCategory.BackColor = System.Drawing.Color.Transparent
        Me.cmbFilterCategory.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.cmbFilterCategory.BorderRadius = 6
        Me.cmbFilterCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterCategory.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbFilterCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbFilterCategory.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.cmbFilterCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cmbFilterCategory.ItemHeight = 30
        Me.cmbFilterCategory.Location = New System.Drawing.Point(250, 8)
        Me.cmbFilterCategory.Name = "cmbFilterCategory"
        Me.cmbFilterCategory.Size = New System.Drawing.Size(220, 36)
        Me.cmbFilterCategory.TabIndex = 3
        '
        'cmbSearchField
        '
        Me.cmbSearchField.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSearchField.BackColor = System.Drawing.Color.Transparent
        Me.cmbSearchField.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.cmbSearchField.BorderRadius = 6
        Me.cmbSearchField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchField.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbSearchField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbSearchField.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.cmbSearchField.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cmbSearchField.ItemHeight = 30
        Me.cmbSearchField.Items.AddRange(New Object() {"الاسم عربي", "كود الصنف", "الباركود", "الاسم إنجليزي", "الفئة", "الوصف"})
        Me.cmbSearchField.Location = New System.Drawing.Point(900, 8)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(180, 36)
        Me.cmbSearchField.StartIndex = 0
        Me.cmbSearchField.TabIndex = 2
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtSearch.BorderRadius = 6
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(1090, 8)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "🔍 بحث فوري بالاسم، الكود، الباركود، الفئة..."
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(490, 38)
        Me.txtSearch.TabIndex = 1
        '
        'grpProductInfo
        '
        Me.grpProductInfo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.grpProductInfo.BorderRadius = 8
        Me.grpProductInfo.Controls.Add(Me.pnlDirectMode)
        Me.grpProductInfo.Controls.Add(Me.pnlActions)
        Me.grpProductInfo.Controls.Add(Me.lblStatus)
        Me.grpProductInfo.Controls.Add(Me.tgStatus)
        Me.grpProductInfo.Controls.Add(Me.dtpPrepTime)
        Me.grpProductInfo.Controls.Add(Me.Label10)
        Me.grpProductInfo.Controls.Add(Me.btnTaxType)
        Me.grpProductInfo.Controls.Add(Me.txtTax)
        Me.grpProductInfo.Controls.Add(Me.Label9)
        Me.grpProductInfo.Controls.Add(Me.btnDiscountType)
        Me.grpProductInfo.Controls.Add(Me.txtDiscount)
        Me.grpProductInfo.Controls.Add(Me.Label8)
        Me.grpProductInfo.Controls.Add(Me.lblProfitMargin)
        Me.grpProductInfo.Controls.Add(Me.txtMinQuantity)
        Me.grpProductInfo.Controls.Add(Me.Label14)
        Me.grpProductInfo.Controls.Add(Me.txtQuantity)
        Me.grpProductInfo.Controls.Add(Me.Label13)
        Me.grpProductInfo.Controls.Add(Me.txtCostPrice)
        Me.grpProductInfo.Controls.Add(Me.Label12)
        Me.grpProductInfo.Controls.Add(Me.txtSalePrice)
        Me.grpProductInfo.Controls.Add(Me.Label11)
        Me.grpProductInfo.Controls.Add(Me.cmbUnit)
        Me.grpProductInfo.Controls.Add(Me.Label15)
        Me.grpProductInfo.Controls.Add(Me.btnAddCategoryForm)
        Me.grpProductInfo.Controls.Add(Me.cmbCategory)
        Me.grpProductInfo.Controls.Add(Me.Label7)
        Me.grpProductInfo.Controls.Add(Me.txtProductNameEn)
        Me.grpProductInfo.Controls.Add(Me.Label3)
        Me.grpProductInfo.Controls.Add(Me.txtProductNameAr)
        Me.grpProductInfo.Controls.Add(Me.Label2)
        Me.grpProductInfo.Controls.Add(Me.btnGenBarcode)
        Me.grpProductInfo.Controls.Add(Me.txtBarcode)
        Me.grpProductInfo.Controls.Add(Me.Label16)
        Me.grpProductInfo.Controls.Add(Me.txtProductCode)
        Me.grpProductInfo.Controls.Add(Me.Label1)
        Me.grpProductInfo.Controls.Add(Me.txtNotes)
        Me.grpProductInfo.Controls.Add(Me.Label6)
        Me.grpProductInfo.Controls.Add(Me.txtDescription)
        Me.grpProductInfo.Controls.Add(Me.Label4)
        Me.grpProductInfo.Controls.Add(Me.btnDeleteImage)
        Me.grpProductInfo.Controls.Add(Me.btnSelectImage)
        Me.grpProductInfo.Controls.Add(Me.picProduct)
        Me.grpProductInfo.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.grpProductInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpProductInfo.FillColor = System.Drawing.Color.White
        Me.grpProductInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.grpProductInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.grpProductInfo.Location = New System.Drawing.Point(0, 95)
        Me.grpProductInfo.Name = "grpProductInfo"
        Me.grpProductInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpProductInfo.Size = New System.Drawing.Size(1600, 415)
        Me.grpProductInfo.TabIndex = 128
        Me.grpProductInfo.Text = "بيانات الصنف والأسعار والمخزون"
        Me.grpProductInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlDirectMode
        '
        Me.pnlDirectMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDirectMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlDirectMode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.pnlDirectMode.BorderRadius = 8
        Me.pnlDirectMode.BorderThickness = 1
        Me.pnlDirectMode.Controls.Add(Me.btnSetupSizesQuick)
        Me.pnlDirectMode.Controls.Add(Me.lblDirectStatus)
        Me.pnlDirectMode.Controls.Add(Me.lblDirectTitle)
        Me.pnlDirectMode.Controls.Add(Me.tgIsDirect)
        Me.pnlDirectMode.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlDirectMode.Location = New System.Drawing.Point(12, 302)
        Me.pnlDirectMode.Name = "pnlDirectMode"
        Me.pnlDirectMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlDirectMode.Size = New System.Drawing.Size(1576, 46)
        Me.pnlDirectMode.TabIndex = 5626
        '
        'tgIsDirect
        '
        Me.tgIsDirect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgIsDirect.Checked = True
        Me.tgIsDirect.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.tgIsDirect.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.tgIsDirect.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgIsDirect.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgIsDirect.Location = New System.Drawing.Point(1505, 10)
        Me.tgIsDirect.Name = "tgIsDirect"
        Me.tgIsDirect.Size = New System.Drawing.Size(55, 26)
        Me.tgIsDirect.TabIndex = 0
        Me.tgIsDirect.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.tgIsDirect.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.tgIsDirect.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgIsDirect.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'lblDirectTitle
        '
        Me.lblDirectTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDirectTitle.AutoSize = True
        Me.lblDirectTitle.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblDirectTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblDirectTitle.Location = New System.Drawing.Point(1375, 13)
        Me.lblDirectTitle.Name = "lblDirectTitle"
        Me.lblDirectTitle.Size = New System.Drawing.Size(115, 19)
        Me.lblDirectTitle.TabIndex = 1
        Me.lblDirectTitle.Text = "هل الصنف مباشر؟"
        '
        'lblDirectStatus
        '
        Me.lblDirectStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDirectStatus.AutoSize = True
        Me.lblDirectStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDirectStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblDirectStatus.Location = New System.Drawing.Point(620, 14)
        Me.lblDirectStatus.Name = "lblDirectStatus"
        Me.lblDirectStatus.Size = New System.Drawing.Size(535, 19)
        Me.lblDirectStatus.TabIndex = 2
        Me.lblDirectStatus.Text = "⚡ صنف مباشر: يُضاف إلى فاتورة المبيعات فوراً بنقرة واحدة (بدون شاشة أحجام أو خيارات)"
        '
        'btnSetupSizesQuick
        '
        Me.btnSetupSizesQuick.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSetupSizesQuick.BorderRadius = 6
        Me.btnSetupSizesQuick.FillColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.btnSetupSizesQuick.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnSetupSizesQuick.ForeColor = System.Drawing.Color.White
        Me.btnSetupSizesQuick.Location = New System.Drawing.Point(12, 7)
        Me.btnSetupSizesQuick.Name = "btnSetupSizesQuick"
        Me.btnSetupSizesQuick.Size = New System.Drawing.Size(140, 32)
        Me.btnSetupSizesQuick.TabIndex = 3
        Me.btnSetupSizesQuick.Text = "📏 إدارة أحجام الصنف"
        Me.btnSetupSizesQuick.Visible = False
        '
        'pnlActions
        '
        Me.pnlActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlActions.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlActions.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.pnlActions.BorderRadius = 6
        Me.pnlActions.BorderThickness = 1
        Me.pnlActions.Controls.Add(Me.btnClear)
        Me.pnlActions.Controls.Add(Me.btnDelete)
        Me.pnlActions.Controls.Add(Me.btnEdit)
        Me.pnlActions.Controls.Add(Me.btnAdd)
        Me.pnlActions.Location = New System.Drawing.Point(12, 355)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlActions.Size = New System.Drawing.Size(1576, 52)
        Me.pnlActions.TabIndex = 130
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BorderRadius = 6
        Me.btnClear.FillColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(920, 7)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(150, 38)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "🧹 تفريغ الحقول (Esc)"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BorderRadius = 6
        Me.btnDelete.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(1080, 7)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(150, 38)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "🗑️ حذف الصنف (F3)"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BorderRadius = 6
        Me.btnEdit.FillColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(1240, 7)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(150, 38)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "✏️ حفظ التعديل (F2)"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BorderRadius = 6
        Me.btnAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(1400, 7)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(165, 38)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "➕ إضافة صنف جديد (F1)"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(620, 240)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 19)
        Me.lblStatus.TabIndex = 5625
        Me.lblStatus.Text = "نشط"
        '
        'tgStatus
        '
        Me.tgStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStatus.Checked = True
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Location = New System.Drawing.Point(670, 237)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(55, 26)
        Me.tgStatus.TabIndex = 5613
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'dtpPrepTime
        '
        Me.dtpPrepTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpPrepTime.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.dtpPrepTime.BorderRadius = 6
        Me.dtpPrepTime.BorderThickness = 1
        Me.dtpPrepTime.Checked = True
        Me.dtpPrepTime.FillColor = System.Drawing.Color.White
        Me.dtpPrepTime.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.dtpPrepTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpPrepTime.Location = New System.Drawing.Point(740, 233)
        Me.dtpPrepTime.Name = "dtpPrepTime"
        Me.dtpPrepTime.Size = New System.Drawing.Size(125, 34)
        Me.dtpPrepTime.TabIndex = 130
        Me.dtpPrepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dtpPrepTime.Value = New Date(2026, 1, 1, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(785, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 19)
        Me.Label10.TabIndex = 5624
        Me.Label10.Text = "وقت التحضير"
        '
        'btnTaxType
        '
        Me.btnTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTaxType.BorderRadius = 6
        Me.btnTaxType.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnTaxType.Checked = True
        Me.btnTaxType.FillColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnTaxType.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTaxType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnTaxType.Location = New System.Drawing.Point(880, 233)
        Me.btnTaxType.Name = "btnTaxType"
        Me.btnTaxType.Size = New System.Drawing.Size(42, 34)
        Me.btnTaxType.TabIndex = 5615
        Me.btnTaxType.Text = "%"
        '
        'txtTax
        '
        Me.txtTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTax.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtTax.BorderRadius = 6
        Me.txtTax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTax.DefaultText = "0"
        Me.txtTax.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtTax.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtTax.Location = New System.Drawing.Point(928, 233)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.PlaceholderText = "0"
        Me.txtTax.SelectedText = ""
        Me.txtTax.Size = New System.Drawing.Size(75, 34)
        Me.txtTax.TabIndex = 11
        Me.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(950, 209)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 19)
        Me.Label9.TabIndex = 5623
        Me.Label9.Text = "الضريبة"
        '
        'btnDiscountType
        '
        Me.btnDiscountType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDiscountType.BorderRadius = 6
        Me.btnDiscountType.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnDiscountType.Checked = True
        Me.btnDiscountType.FillColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnDiscountType.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDiscountType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnDiscountType.Location = New System.Drawing.Point(1015, 233)
        Me.btnDiscountType.Name = "btnDiscountType"
        Me.btnDiscountType.Size = New System.Drawing.Size(42, 34)
        Me.btnDiscountType.TabIndex = 5614
        Me.btnDiscountType.Text = "%"
        '
        'txtDiscount
        '
        Me.txtDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscount.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtDiscount.BorderRadius = 6
        Me.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscount.DefaultText = "0"
        Me.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtDiscount.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtDiscount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtDiscount.Location = New System.Drawing.Point(1063, 233)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.PlaceholderText = "0"
        Me.txtDiscount.SelectedText = ""
        Me.txtDiscount.Size = New System.Drawing.Size(75, 34)
        Me.txtDiscount.TabIndex = 10
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(1090, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 19)
        Me.Label8.TabIndex = 5622
        Me.Label8.Text = "الخصم"
        '
        'lblProfitMargin
        '
        Me.lblProfitMargin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProfitMargin.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblProfitMargin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblProfitMargin.Location = New System.Drawing.Point(1150, 273)
        Me.lblProfitMargin.Name = "lblProfitMargin"
        Me.lblProfitMargin.Size = New System.Drawing.Size(430, 22)
        Me.lblProfitMargin.TabIndex = 5621
        Me.lblProfitMargin.Text = "هامش الربح المتوقع: 0.00 ج.م (0%)"
        Me.lblProfitMargin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMinQuantity
        '
        Me.txtMinQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMinQuantity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtMinQuantity.BorderRadius = 6
        Me.txtMinQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMinQuantity.DefaultText = "0"
        Me.txtMinQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtMinQuantity.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMinQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtMinQuantity.Location = New System.Drawing.Point(1150, 233)
        Me.txtMinQuantity.Name = "txtMinQuantity"
        Me.txtMinQuantity.PlaceholderText = "0"
        Me.txtMinQuantity.SelectedText = ""
        Me.txtMinQuantity.Size = New System.Drawing.Size(100, 34)
        Me.txtMinQuantity.TabIndex = 9
        Me.txtMinQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(1185, 209)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 19)
        Me.Label14.TabIndex = 5620
        Me.Label14.Text = "حد الطلب"
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtQuantity.BorderRadius = 6
        Me.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQuantity.DefaultText = "0"
        Me.txtQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtQuantity.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtQuantity.Location = New System.Drawing.Point(1260, 233)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.PlaceholderText = "0"
        Me.txtQuantity.SelectedText = ""
        Me.txtQuantity.Size = New System.Drawing.Size(100, 34)
        Me.txtQuantity.TabIndex = 8
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(1265, 209)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 19)
        Me.Label13.TabIndex = 5619
        Me.Label13.Text = "الكمية المتوفرة"
        '
        'txtCostPrice
        '
        Me.txtCostPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCostPrice.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtCostPrice.BorderRadius = 6
        Me.txtCostPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCostPrice.DefaultText = "0.00"
        Me.txtCostPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtCostPrice.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCostPrice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtCostPrice.Location = New System.Drawing.Point(1370, 233)
        Me.txtCostPrice.Name = "txtCostPrice"
        Me.txtCostPrice.PlaceholderText = "0.00"
        Me.txtCostPrice.SelectedText = ""
        Me.txtCostPrice.Size = New System.Drawing.Size(100, 34)
        Me.txtCostPrice.TabIndex = 7
        Me.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(1390, 209)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 19)
        Me.Label12.TabIndex = 5618
        Me.Label12.Text = "سعر التكلفة"
        '
        'txtSalePrice
        '
        Me.txtSalePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSalePrice.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtSalePrice.BorderRadius = 6
        Me.txtSalePrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSalePrice.DefaultText = "0.00"
        Me.txtSalePrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtSalePrice.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSalePrice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtSalePrice.Location = New System.Drawing.Point(1480, 233)
        Me.txtSalePrice.Name = "txtSalePrice"
        Me.txtSalePrice.PlaceholderText = "0.00"
        Me.txtSalePrice.SelectedText = ""
        Me.txtSalePrice.Size = New System.Drawing.Size(100, 34)
        Me.txtSalePrice.TabIndex = 6
        Me.txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(1510, 209)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 19)
        Me.Label11.TabIndex = 5617
        Me.Label11.Text = "سعر البيع *"
        '
        'cmbUnit
        '
        Me.cmbUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUnit.BackColor = System.Drawing.Color.Transparent
        Me.cmbUnit.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.cmbUnit.BorderRadius = 6
        Me.cmbUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUnit.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbUnit.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.cmbUnit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cmbUnit.ItemHeight = 28
        Me.cmbUnit.Items.AddRange(New Object() {"قطعة", "علبة", "كجم", "جرام", "لتر", "مل", "وجبة", "متر", "كرتونة"})
        Me.cmbUnit.Location = New System.Drawing.Point(620, 163)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(130, 34)
        Me.cmbUnit.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(705, 139)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 19)
        Me.Label15.TabIndex = 5616
        Me.Label15.Text = "الوحدة"
        '
        'btnAddCategoryForm
        '
        Me.btnAddCategoryForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCategoryForm.BorderRadius = 6
        Me.btnAddCategoryForm.FillColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnAddCategoryForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddCategoryForm.ForeColor = System.Drawing.Color.White
        Me.btnAddCategoryForm.Location = New System.Drawing.Point(758, 163)
        Me.btnAddCategoryForm.Name = "btnAddCategoryForm"
        Me.btnAddCategoryForm.Size = New System.Drawing.Size(36, 34)
        Me.btnAddCategoryForm.TabIndex = 5612
        Me.btnAddCategoryForm.Text = "+"
        '
        'cmbCategory
        '
        Me.cmbCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCategory.BackColor = System.Drawing.Color.Transparent
        Me.cmbCategory.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.cmbCategory.BorderRadius = 6
        Me.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbCategory.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cmbCategory.ItemHeight = 28
        Me.cmbCategory.Location = New System.Drawing.Point(800, 163)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(185, 34)
        Me.cmbCategory.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(905, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 19)
        Me.Label7.TabIndex = 5611
        Me.Label7.Text = "القسم/الفئة *"
        '
        'txtProductNameEn
        '
        Me.txtProductNameEn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductNameEn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtProductNameEn.BorderRadius = 6
        Me.txtProductNameEn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductNameEn.DefaultText = ""
        Me.txtProductNameEn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtProductNameEn.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProductNameEn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtProductNameEn.Location = New System.Drawing.Point(995, 163)
        Me.txtProductNameEn.Name = "txtProductNameEn"
        Me.txtProductNameEn.PlaceholderText = "Product Name (En)"
        Me.txtProductNameEn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtProductNameEn.SelectedText = ""
        Me.txtProductNameEn.Size = New System.Drawing.Size(200, 34)
        Me.txtProductNameEn.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1110, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 19)
        Me.Label3.TabIndex = 5610
        Me.Label3.Text = "الاسم إنجليزي"
        '
        'txtProductNameAr
        '
        Me.txtProductNameAr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductNameAr.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtProductNameAr.BorderRadius = 6
        Me.txtProductNameAr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductNameAr.DefaultText = ""
        Me.txtProductNameAr.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtProductNameAr.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProductNameAr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtProductNameAr.Location = New System.Drawing.Point(1205, 163)
        Me.txtProductNameAr.Name = "txtProductNameAr"
        Me.txtProductNameAr.PlaceholderText = "اسم الصنف بالعربي"
        Me.txtProductNameAr.SelectedText = ""
        Me.txtProductNameAr.Size = New System.Drawing.Size(375, 34)
        Me.txtProductNameAr.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1495, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 19)
        Me.Label2.TabIndex = 5609
        Me.Label2.Text = "الاسم عربي *"
        '
        'btnGenBarcode
        '
        Me.btnGenBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenBarcode.BorderRadius = 6
        Me.btnGenBarcode.FillColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnGenBarcode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnGenBarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnGenBarcode.Location = New System.Drawing.Point(1115, 93)
        Me.btnGenBarcode.Name = "btnGenBarcode"
        Me.btnGenBarcode.Size = New System.Drawing.Size(65, 34)
        Me.btnGenBarcode.TabIndex = 5608
        Me.btnGenBarcode.Text = "توليد"
        '
        'txtBarcode
        '
        Me.txtBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBarcode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtBarcode.BorderRadius = 6
        Me.txtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBarcode.DefaultText = ""
        Me.txtBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtBarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtBarcode.Location = New System.Drawing.Point(1185, 93)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.PlaceholderText = "امسح أو اكتب الباركود"
        Me.txtBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBarcode.SelectedText = ""
        Me.txtBarcode.Size = New System.Drawing.Size(200, 34)
        Me.txtBarcode.TabIndex = 1
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(1335, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 19)
        Me.Label16.TabIndex = 5607
        Me.Label16.Text = "الباركود"
        '
        'txtProductCode
        '
        Me.txtProductCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtProductCode.BorderRadius = 6
        Me.txtProductCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductCode.DefaultText = ""
        Me.txtProductCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtProductCode.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProductCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtProductCode.Location = New System.Drawing.Point(1395, 93)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.PlaceholderText = "تلقائي"
        Me.txtProductCode.ReadOnly = True
        Me.txtProductCode.SelectedText = ""
        Me.txtProductCode.Size = New System.Drawing.Size(185, 34)
        Me.txtProductCode.TabIndex = 0
        Me.txtProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1510, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 19)
        Me.Label1.TabIndex = 5606
        Me.Label1.Text = "كود الصنف"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtNotes.BorderRadius = 6
        Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotes.DefaultText = ""
        Me.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(215, 195)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = "ملاحظات إضافية..."
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(390, 72)
        Me.txtNotes.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(545, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 19)
        Me.Label6.TabIndex = 5605
        Me.Label6.Text = "الملاحظات"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtDescription.BorderRadius = 6
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescription.DefaultText = ""
        Me.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtDescription.Location = New System.Drawing.Point(215, 93)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.PlaceholderText = "وصف مختصر لمكونات أو تفاصيل الصنف..."
        Me.txtDescription.SelectedText = ""
        Me.txtDescription.Size = New System.Drawing.Size(390, 72)
        Me.txtDescription.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(555, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 19)
        Me.Label4.TabIndex = 5604
        Me.Label4.Text = "الوصف"
        '
        'btnDeleteImage
        '
        Me.btnDeleteImage.BorderRadius = 6
        Me.btnDeleteImage.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnDeleteImage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteImage.ForeColor = System.Drawing.Color.White
        Me.btnDeleteImage.Location = New System.Drawing.Point(15, 233)
        Me.btnDeleteImage.Name = "btnDeleteImage"
        Me.btnDeleteImage.Size = New System.Drawing.Size(85, 34)
        Me.btnDeleteImage.TabIndex = 5603
        Me.btnDeleteImage.Text = "🗑️ إزالة"
        '
        'btnSelectImage
        '
        Me.btnSelectImage.BorderRadius = 6
        Me.btnSelectImage.FillColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnSelectImage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSelectImage.ForeColor = System.Drawing.Color.White
        Me.btnSelectImage.Location = New System.Drawing.Point(105, 233)
        Me.btnSelectImage.Name = "btnSelectImage"
        Me.btnSelectImage.Size = New System.Drawing.Size(90, 34)
        Me.btnSelectImage.TabIndex = 5602
        Me.btnSelectImage.Text = "📷 صورة"
        '
        'picProduct
        '
        Me.picProduct.BorderRadius = 8
        Me.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProduct.FillColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.picProduct.ImageRotate = 0!
        Me.picProduct.Location = New System.Drawing.Point(15, 75)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(180, 150)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 127
        Me.picProduct.TabStop = False
        '
        'pnlStats
        '
        Me.pnlStats.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlStats.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.pnlStats.BorderThickness = 1
        Me.pnlStats.Controls.Add(Me.btnExportExcel)
        Me.pnlStats.Controls.Add(Me.btnManageAddons)
        Me.pnlStats.Controls.Add(Me.btnManageSizes)
        Me.pnlStats.Controls.Add(Me.btnRefresh)
        Me.pnlStats.Controls.Add(Me.lblLowStockProducts)
        Me.pnlStats.Controls.Add(Me.lblActiveProducts)
        Me.pnlStats.Controls.Add(Me.lblTotalProducts)
        Me.pnlStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStats.Location = New System.Drawing.Point(0, 48)
        Me.pnlStats.Name = "pnlStats"
        Me.pnlStats.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlStats.Size = New System.Drawing.Size(1600, 47)
        Me.pnlStats.TabIndex = 132
        '
        'btnExportExcel
        '
        Me.btnExportExcel.BorderRadius = 6
        Me.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportExcel.ForeColor = System.Drawing.Color.White
        Me.btnExportExcel.Location = New System.Drawing.Point(20, 6)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(145, 34)
        Me.btnExportExcel.TabIndex = 6
        Me.btnExportExcel.Text = "📊 تصدير Excel"
        '
        'btnManageAddons
        '
        Me.btnManageAddons.BorderRadius = 6
        Me.btnManageAddons.FillColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnManageAddons.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnManageAddons.ForeColor = System.Drawing.Color.White
        Me.btnManageAddons.Location = New System.Drawing.Point(175, 6)
        Me.btnManageAddons.Name = "btnManageAddons"
        Me.btnManageAddons.Size = New System.Drawing.Size(155, 34)
        Me.btnManageAddons.TabIndex = 5
        Me.btnManageAddons.Text = "➕ إضافات الصنف"
        '
        'btnManageSizes
        '
        Me.btnManageSizes.BorderRadius = 6
        Me.btnManageSizes.FillColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.btnManageSizes.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnManageSizes.ForeColor = System.Drawing.Color.White
        Me.btnManageSizes.Location = New System.Drawing.Point(340, 6)
        Me.btnManageSizes.Name = "btnManageSizes"
        Me.btnManageSizes.Size = New System.Drawing.Size(165, 34)
        Me.btnManageSizes.TabIndex = 4
        Me.btnManageSizes.Text = "📏 الأحجام والأسعار"
        '
        'btnRefresh
        '
        Me.btnRefresh.BorderRadius = 6
        Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(515, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(110, 34)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "🔄 تحديث"
        '
        'lblLowStockProducts
        '
        Me.lblLowStockProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLowStockProducts.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblLowStockProducts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.lblLowStockProducts.Location = New System.Drawing.Point(920, 10)
        Me.lblLowStockProducts.Name = "lblLowStockProducts"
        Me.lblLowStockProducts.Size = New System.Drawing.Size(200, 26)
        Me.lblLowStockProducts.TabIndex = 2
        Me.lblLowStockProducts.Text = "⚠️ نواقص وتحت الطلب: 0"
        Me.lblLowStockProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblActiveProducts
        '
        Me.lblActiveProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActiveProducts.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblActiveProducts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblActiveProducts.Location = New System.Drawing.Point(1150, 10)
        Me.lblActiveProducts.Name = "lblActiveProducts"
        Me.lblActiveProducts.Size = New System.Drawing.Size(180, 26)
        Me.lblActiveProducts.TabIndex = 1
        Me.lblActiveProducts.Text = "✅ الأصناف النشطة: 0"
        Me.lblActiveProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalProducts
        '
        Me.lblTotalProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalProducts.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalProducts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblTotalProducts.Location = New System.Drawing.Point(1360, 10)
        Me.lblTotalProducts.Name = "lblTotalProducts"
        Me.lblTotalProducts.Size = New System.Drawing.Size(220, 26)
        Me.lblTotalProducts.TabIndex = 0
        Me.lblTotalProducts.Text = "📦 إجمالي الأصناف: 0"
        Me.lblTotalProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblTime)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1600, 48)
        Me.panelHeader.TabIndex = 127
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblTime.ForeColor = System.Drawing.Color.White
        Me.lblTime.Location = New System.Drawing.Point(140, 9)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTime.Size = New System.Drawing.Size(1440, 30)
        Me.lblTime.TabIndex = 7
        Me.lblTime.Text = "📦 دليل وإدارة الأصناف والمنتجات"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_min.Appearance.ForeColor = System.Drawing.Color.White
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.Appearance.Options.UseForeColor = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(92, 8)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_min.Size = New System.Drawing.Size(32, 32)
        Me.btn_min.TabIndex = 5
        '
        'btn_max
        '
        Me.btn_max.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_max.Appearance.ForeColor = System.Drawing.Color.White
        Me.btn_max.Appearance.Options.UseFont = True
        Me.btn_max.Appearance.Options.UseForeColor = True
        Me.btn_max.ImageOptions.SvgImage = CType(resources.GetObject("btn_max.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_max.Location = New System.Drawing.Point(52, 8)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(32, 32)
        Me.btn_max.TabIndex = 4
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_close.Appearance.ForeColor = System.Drawing.Color.White
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.Appearance.Options.UseForeColor = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(12, 8)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(32, 32)
        Me.btn_close.TabIndex = 3
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Products
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1600, 950)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Products"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Products"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.grpProductInfo.ResumeLayout(False)
        Me.grpProductInfo.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlDirectMode.ResumeLayout(False)
        Me.pnlDirectMode.PerformLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStats.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTime As Label
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents grpProductInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents btnDeleteImage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSelectImage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents picProduct As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents pnlActions As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDescription As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProductNameEn As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtProductNameAr As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtProductCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtTax As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtDiscount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cmbCategory As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpPrepTime As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents btnTaxType As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDiscountType As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddCategoryForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtBarcode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnGenBarcode As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtSalePrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCostPrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtQuantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMinQuantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbUnit As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents lblProfitMargin As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents pnlStats As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTotalProducts As Label
    Friend WithEvents lblActiveProducts As Label
    Friend WithEvents lblLowStockProducts As Label
    Friend WithEvents btnExportExcel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnManageSizes As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnManageAddons As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlSearch As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents cmbStockFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmbFilterCategory As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents pnlDirectMode As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents tgIsDirect As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents lblDirectTitle As Label
    Friend WithEvents lblDirectStatus As Label
    Friend WithEvents btnSetupSizesQuick As Guna.UI2.WinForms.Guna2Button
End Class
