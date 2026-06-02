<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Sales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sales))
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtQuantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbUnit = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProductCodeSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSalePrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtProductNameSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtRemaining = New Guna.UI2.WinForms.Guna2TextBox()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnToggleScanner = New DevExpress.XtraEditors.SimpleButton()
        Me.Button1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Sales_Returns = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSaveInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.lblRemaining = New System.Windows.Forms.Label()
        Me.txt_Customer_Code = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.btn_Invoice_Edit = New Guna.UI2.WinForms.Guna2Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Guna2ToggleSwitch1 = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.btn_auto_pay = New System.Windows.Forms.Button()
        Me.Pic_Logo = New System.Windows.Forms.PictureBox()
        Me.btn_money = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_free_profit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Guna2TextBox2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.check_Stats = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.lbl_Debit = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtDebit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lbl_Credit = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtCredit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnToggleDiscount = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_search_Customer_name = New System.Windows.Forms.Button()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txt_notes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_search_Customer_ID = New System.Windows.Forms.Button()
        Me.lstCodeSuggestions = New System.Windows.Forms.ListBox()
        Me.lstNameSuggestions = New System.Windows.Forms.ListBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_totelProduct = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_Customer_Balance = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lbl_Customer_Balance = New System.Windows.Forms.Label()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.txtTotalAfterDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblTotalAfter = New System.Windows.Forms.Label()
        Me.txtPaid = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.cmb_Pay = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Invoice_ID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_add_product = New DevExpress.XtraEditors.SimpleButton()
        Me.txtTotalRequired = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblTotalBefore = New System.Windows.Forms.Label()
        Me.txt_Customer_Name = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_clean = New DevExpress.XtraEditors.SimpleButton()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblLang = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbl_user_name = New System.Windows.Forms.Label()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        CType(Me.Pic_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(333, 374)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(164, 33)
        Me.Label13.TabIndex = 5594
        Me.Label13.Text = "الكمية"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQuantity.DefaultText = ""
        Me.txtQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQuantity.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.ForeColor = System.Drawing.Color.Black
        Me.txtQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQuantity.Location = New System.Drawing.Point(333, 413)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.PlaceholderText = "ادخل الكمية"
        Me.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQuantity.SelectedText = ""
        Me.txtQuantity.Size = New System.Drawing.Size(164, 49)
        Me.txtQuantity.TabIndex = 5593
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(503, 374)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(148, 33)
        Me.Label12.TabIndex = 5592
        Me.Label12.Text = "سعر البيع"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(657, 374)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(163, 33)
        Me.Label11.TabIndex = 5591
        Me.Label11.Text = "الواحدات"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmbUnit
        '
        Me.cmbUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUnit.BackColor = System.Drawing.Color.White
        Me.cmbUnit.BorderRadius = 2
        Me.cmbUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnit.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbUnit.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.cmbUnit.ForeColor = System.Drawing.Color.Black
        Me.cmbUnit.ItemHeight = 30
        Me.cmbUnit.Location = New System.Drawing.Point(657, 413)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(163, 36)
        Me.cmbUnit.TabIndex = 5590
        Me.cmbUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1351, 374)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(243, 33)
        Me.Label10.TabIndex = 5589
        Me.Label10.Text = "كود المنتج"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtProductCodeSearch
        '
        Me.txtProductCodeSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductCodeSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductCodeSearch.DefaultText = ""
        Me.txtProductCodeSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtProductCodeSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtProductCodeSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductCodeSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductCodeSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductCodeSearch.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductCodeSearch.ForeColor = System.Drawing.Color.Black
        Me.txtProductCodeSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductCodeSearch.Location = New System.Drawing.Point(1351, 413)
        Me.txtProductCodeSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtProductCodeSearch.Name = "txtProductCodeSearch"
        Me.txtProductCodeSearch.PlaceholderText = ""
        Me.txtProductCodeSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtProductCodeSearch.SelectedText = ""
        Me.txtProductCodeSearch.Size = New System.Drawing.Size(243, 49)
        Me.txtProductCodeSearch.TabIndex = 5588
        Me.txtProductCodeSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(826, 374)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(522, 33)
        Me.Label9.TabIndex = 5587
        Me.Label9.Text = "اسم المنتج"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtSalePrice
        '
        Me.txtSalePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSalePrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSalePrice.DefaultText = ""
        Me.txtSalePrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSalePrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSalePrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSalePrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSalePrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSalePrice.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalePrice.ForeColor = System.Drawing.Color.Black
        Me.txtSalePrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSalePrice.Location = New System.Drawing.Point(503, 413)
        Me.txtSalePrice.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSalePrice.Name = "txtSalePrice"
        Me.txtSalePrice.PlaceholderText = ""
        Me.txtSalePrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSalePrice.SelectedText = ""
        Me.txtSalePrice.Size = New System.Drawing.Size(148, 49)
        Me.txtSalePrice.TabIndex = 5586
        Me.txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProductNameSearch
        '
        Me.txtProductNameSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductNameSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductNameSearch.DefaultText = ""
        Me.txtProductNameSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtProductNameSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtProductNameSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductNameSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductNameSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductNameSearch.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductNameSearch.ForeColor = System.Drawing.Color.Black
        Me.txtProductNameSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductNameSearch.Location = New System.Drawing.Point(826, 413)
        Me.txtProductNameSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtProductNameSearch.Name = "txtProductNameSearch"
        Me.txtProductNameSearch.PlaceholderText = "ابحث عن المنتج"
        Me.txtProductNameSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtProductNameSearch.SelectedText = ""
        Me.txtProductNameSearch.Size = New System.Drawing.Size(522, 49)
        Me.txtProductNameSearch.TabIndex = 5585
        Me.txtProductNameSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeight = 70
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 680)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowTemplate.Height = 50
        Me.DataGridView1.Size = New System.Drawing.Size(1600, 420)
        Me.DataGridView1.TabIndex = 80
        '
        'txtRemaining
        '
        Me.txtRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemaining.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRemaining.DefaultText = ""
        Me.txtRemaining.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtRemaining.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRemaining.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRemaining.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRemaining.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemaining.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtRemaining.ForeColor = System.Drawing.Color.Black
        Me.txtRemaining.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemaining.Location = New System.Drawing.Point(352, 258)
        Me.txtRemaining.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtRemaining.Name = "txtRemaining"
        Me.txtRemaining.PlaceholderText = ""
        Me.txtRemaining.ReadOnly = True
        Me.txtRemaining.SelectedText = ""
        Me.txtRemaining.Size = New System.Drawing.Size(414, 45)
        Me.txtRemaining.TabIndex = 5584
        Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnToggleScanner)
        Me.PanelControl1.Controls.Add(Me.Button1)
        Me.PanelControl1.Controls.Add(Me.btnDelete)
        Me.PanelControl1.Controls.Add(Me.btn_Sales_Returns)
        Me.PanelControl1.Controls.Add(Me.btnSaveInvoice)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 70)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1600, 68)
        Me.PanelControl1.TabIndex = 78
        '
        'btnToggleScanner
        '
        Me.btnToggleScanner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToggleScanner.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToggleScanner.Appearance.Options.UseFont = True
        Me.btnToggleScanner.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.scanner
        Me.btnToggleScanner.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnToggleScanner.Location = New System.Drawing.Point(2, 5)
        Me.btnToggleScanner.Name = "btnToggleScanner"
        Me.btnToggleScanner.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnToggleScanner.Size = New System.Drawing.Size(269, 57)
        Me.btnToggleScanner.TabIndex = 4
        Me.btnToggleScanner.Text = "تشغيل الاسكنر"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Appearance.Options.UseFont = True
        Me.Button1.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.user__1_1
        Me.Button1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(280, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button1.Size = New System.Drawing.Size(318, 57)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "طباعة الفاتورة (F5)"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.user__1_1
        Me.btnDelete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnDelete.Location = New System.Drawing.Point(600, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnDelete.Size = New System.Drawing.Size(298, 57)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف الفاتورة (F4)"
        '
        'btn_Sales_Returns
        '
        Me.btn_Sales_Returns.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Sales_Returns.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Sales_Returns.Appearance.Options.UseFont = True
        Me.btn_Sales_Returns.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.user1
        Me.btn_Sales_Returns.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_Sales_Returns.Location = New System.Drawing.Point(900, 5)
        Me.btn_Sales_Returns.Name = "btn_Sales_Returns"
        Me.btn_Sales_Returns.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_Sales_Returns.Size = New System.Drawing.Size(339, 57)
        Me.btn_Sales_Returns.TabIndex = 1
        Me.btn_Sales_Returns.Text = "مرتجعات البيع (F3)"
        '
        'btnSaveInvoice
        '
        Me.btnSaveInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveInvoice.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveInvoice.Appearance.Options.UseFont = True
        Me.btnSaveInvoice.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btnSaveInvoice.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnSaveInvoice.Location = New System.Drawing.Point(1250, 5)
        Me.btnSaveInvoice.Name = "btnSaveInvoice"
        Me.btnSaveInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSaveInvoice.Size = New System.Drawing.Size(333, 57)
        Me.btnSaveInvoice.TabIndex = 0
        Me.btnSaveInvoice.Text = "حفظ  الفاتورة (F2)"
        '
        'txtDiscount
        '
        Me.txtDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscount.DefaultText = ""
        Me.txtDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscount.Location = New System.Drawing.Point(353, 49)
        Me.txtDiscount.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.PlaceholderText = ""
        Me.txtDiscount.SelectedText = ""
        Me.txtDiscount.Size = New System.Drawing.Size(339, 45)
        Me.txtDiscount.TabIndex = 5580
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDiscount
        '
        Me.lblDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiscount.BackColor = System.Drawing.Color.Transparent
        Me.lblDiscount.Location = New System.Drawing.Point(689, 51)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(262, 45)
        Me.lblDiscount.TabIndex = 5579
        Me.lblDiscount.Text = "الخصم"
        Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRemaining
        '
        Me.lblRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemaining.BackColor = System.Drawing.Color.Transparent
        Me.lblRemaining.Location = New System.Drawing.Point(775, 258)
        Me.lblRemaining.Name = "lblRemaining"
        Me.lblRemaining.Size = New System.Drawing.Size(141, 45)
        Me.lblRemaining.TabIndex = 5583
        Me.lblRemaining.Text = "المتبقي"
        Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Customer_Code
        '
        Me.txt_Customer_Code.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Customer_Code.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Customer_Code.DefaultText = ""
        Me.txt_Customer_Code.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Customer_Code.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Customer_Code.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Customer_Code.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Customer_Code.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Customer_Code.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Customer_Code.ForeColor = System.Drawing.Color.Black
        Me.txt_Customer_Code.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Customer_Code.Location = New System.Drawing.Point(1025, 87)
        Me.txt_Customer_Code.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Customer_Code.Name = "txt_Customer_Code"
        Me.txt_Customer_Code.PlaceholderText = ""
        Me.txt_Customer_Code.SelectedText = ""
        Me.txt_Customer_Code.Size = New System.Drawing.Size(349, 41)
        Me.txt_Customer_Code.TabIndex = 5582
        Me.txt_Customer_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(1374, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(210, 41)
        Me.Label8.TabIndex = 5581
        Me.Label8.Text = "كود العميل"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.btn_Invoice_Edit)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2ToggleSwitch1)
        Me.grpCustomerInfo.Controls.Add(Me.btn_auto_pay)
        Me.grpCustomerInfo.Controls.Add(Me.Pic_Logo)
        Me.grpCustomerInfo.Controls.Add(Me.btn_money)
        Me.grpCustomerInfo.Controls.Add(Me.txt_free_profit)
        Me.grpCustomerInfo.Controls.Add(Me.Button2)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2TextBox2)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2TextBox1)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.check_Stats)
        Me.grpCustomerInfo.Controls.Add(Me.lbl_Debit)
        Me.grpCustomerInfo.Controls.Add(Me.txtDebit)
        Me.grpCustomerInfo.Controls.Add(Me.lbl_Credit)
        Me.grpCustomerInfo.Controls.Add(Me.txtCredit)
        Me.grpCustomerInfo.Controls.Add(Me.btnToggleDiscount)
        Me.grpCustomerInfo.Controls.Add(Me.btn_search_Customer_name)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel9)
        Me.grpCustomerInfo.Controls.Add(Me.txt_notes)
        Me.grpCustomerInfo.Controls.Add(Me.btn_search_Customer_ID)
        Me.grpCustomerInfo.Controls.Add(Me.lstCodeSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.lstNameSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.Label16)
        Me.grpCustomerInfo.Controls.Add(Me.txt_totelProduct)
        Me.grpCustomerInfo.Controls.Add(Me.txt_Customer_Balance)
        Me.grpCustomerInfo.Controls.Add(Me.lbl_Customer_Balance)
        Me.grpCustomerInfo.Controls.Add(Me.lstSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.txtTotalAfterDiscount)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalAfter)
        Me.grpCustomerInfo.Controls.Add(Me.txtPaid)
        Me.grpCustomerInfo.Controls.Add(Me.lblPaid)
        Me.grpCustomerInfo.Controls.Add(Me.cmb_Pay)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.txt_Invoice_ID)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.btn_add_product)
        Me.grpCustomerInfo.Controls.Add(Me.Label13)
        Me.grpCustomerInfo.Controls.Add(Me.txtQuantity)
        Me.grpCustomerInfo.Controls.Add(Me.Label12)
        Me.grpCustomerInfo.Controls.Add(Me.Label11)
        Me.grpCustomerInfo.Controls.Add(Me.cmbUnit)
        Me.grpCustomerInfo.Controls.Add(Me.Label10)
        Me.grpCustomerInfo.Controls.Add(Me.txtProductCodeSearch)
        Me.grpCustomerInfo.Controls.Add(Me.Label9)
        Me.grpCustomerInfo.Controls.Add(Me.txtSalePrice)
        Me.grpCustomerInfo.Controls.Add(Me.txtProductNameSearch)
        Me.grpCustomerInfo.Controls.Add(Me.txtRemaining)
        Me.grpCustomerInfo.Controls.Add(Me.lblRemaining)
        Me.grpCustomerInfo.Controls.Add(Me.txt_Customer_Code)
        Me.grpCustomerInfo.Controls.Add(Me.Label8)
        Me.grpCustomerInfo.Controls.Add(Me.txtDiscount)
        Me.grpCustomerInfo.Controls.Add(Me.lblDiscount)
        Me.grpCustomerInfo.Controls.Add(Me.txtTotalRequired)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalBefore)
        Me.grpCustomerInfo.Controls.Add(Me.txt_Customer_Name)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.btn_clean)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 138)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1600, 542)
        Me.grpCustomerInfo.TabIndex = 79
        Me.grpCustomerInfo.Text = "بيانات الفاتورة"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_Invoice_Edit
        '
        Me.btn_Invoice_Edit.BackColor = System.Drawing.Color.Transparent
        Me.btn_Invoice_Edit.BorderRadius = 12
        Me.btn_Invoice_Edit.BorderThickness = 1
        Me.btn_Invoice_Edit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Invoice_Edit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Invoice_Edit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Invoice_Edit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Invoice_Edit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_Invoice_Edit.ForeColor = System.Drawing.Color.White
        Me.btn_Invoice_Edit.Location = New System.Drawing.Point(1168, 3)
        Me.btn_Invoice_Edit.Name = "btn_Invoice_Edit"
        Me.btn_Invoice_Edit.Size = New System.Drawing.Size(180, 30)
        Me.btn_Invoice_Edit.TabIndex = 5634
        Me.btn_Invoice_Edit.Text = "تعديل بيانات الفاتورة"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(562, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 33)
        Me.Label4.TabIndex = 5633
        Me.Label4.Text = "حفظ تلقائيا"
        '
        'Guna2ToggleSwitch1
        '
        Me.Guna2ToggleSwitch1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ToggleSwitch1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.Location = New System.Drawing.Point(694, 4)
        Me.Guna2ToggleSwitch1.Name = "Guna2ToggleSwitch1"
        Me.Guna2ToggleSwitch1.Size = New System.Drawing.Size(78, 32)
        Me.Guna2ToggleSwitch1.TabIndex = 5632
        Me.Guna2ToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2ToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2ToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'btn_auto_pay
        '
        Me.btn_auto_pay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_auto_pay.Image = Global.WindowsApp1.My.Resources.Resources.pay__1_
        Me.btn_auto_pay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_auto_pay.Location = New System.Drawing.Point(352, 200)
        Me.btn_auto_pay.Name = "btn_auto_pay"
        Me.btn_auto_pay.Size = New System.Drawing.Size(90, 45)
        Me.btn_auto_pay.TabIndex = 5631
        Me.btn_auto_pay.Text = "OK"
        Me.btn_auto_pay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_auto_pay.UseVisualStyleBackColor = True
        '
        'Pic_Logo
        '
        Me.Pic_Logo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pic_Logo.Image = Global.WindowsApp1.My.Resources.Resources.logo_app
        Me.Pic_Logo.Location = New System.Drawing.Point(3, 47)
        Me.Pic_Logo.Name = "Pic_Logo"
        Me.Pic_Logo.Size = New System.Drawing.Size(343, 182)
        Me.Pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Logo.TabIndex = 5630
        Me.Pic_Logo.TabStop = False
        '
        'btn_money
        '
        Me.btn_money.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_money.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_money.Appearance.Options.UseFont = True
        Me.btn_money.AutoSize = True
        Me.btn_money.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.money_stack
        Me.btn_money.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_money.Location = New System.Drawing.Point(87, 2)
        Me.btn_money.Name = "btn_money"
        Me.btn_money.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_money.Size = New System.Drawing.Size(38, 36)
        Me.btn_money.TabIndex = 5629
        '
        'txt_free_profit
        '
        Me.txt_free_profit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_free_profit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_free_profit.DefaultText = ""
        Me.txt_free_profit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_free_profit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_free_profit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_free_profit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_free_profit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_free_profit.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_free_profit.ForeColor = System.Drawing.Color.Black
        Me.txt_free_profit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_free_profit.Location = New System.Drawing.Point(281, 488)
        Me.txt_free_profit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_free_profit.Name = "txt_free_profit"
        Me.txt_free_profit.PlaceholderForeColor = System.Drawing.Color.Transparent
        Me.txt_free_profit.PlaceholderText = ""
        Me.txt_free_profit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_free_profit.SelectedText = ""
        Me.txt_free_profit.Size = New System.Drawing.Size(62, 49)
        Me.txt_free_profit.TabIndex = 5627
        Me.txt_free_profit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(171, 485)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 52)
        Me.Button2.TabIndex = 5628
        Me.Button2.Text = "اضافة"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Guna2TextBox2
        '
        Me.Guna2TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Guna2TextBox2.DefaultText = ""
        Me.Guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2TextBox2.ForeColor = System.Drawing.Color.Black
        Me.Guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox2.Location = New System.Drawing.Point(353, 488)
        Me.Guna2TextBox2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Guna2TextBox2.Name = "Guna2TextBox2"
        Me.Guna2TextBox2.PlaceholderText = "القيمة"
        Me.Guna2TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Guna2TextBox2.SelectedText = ""
        Me.Guna2TextBox2.Size = New System.Drawing.Size(158, 49)
        Me.Guna2TextBox2.TabIndex = 5626
        Me.Guna2TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2TextBox1
        '
        Me.Guna2TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Guna2TextBox1.DefaultText = ""
        Me.Guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2TextBox1.ForeColor = System.Drawing.Color.Black
        Me.Guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.Location = New System.Drawing.Point(516, 487)
        Me.Guna2TextBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Guna2TextBox1.Name = "Guna2TextBox1"
        Me.Guna2TextBox1.PlaceholderText = "الاسم"
        Me.Guna2TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Guna2TextBox1.SelectedText = ""
        Me.Guna2TextBox1.Size = New System.Drawing.Size(305, 49)
        Me.Guna2TextBox1.TabIndex = 5625
        Me.Guna2TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(214, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(240, 33)
        Me.Label3.TabIndex = 5624
        Me.Label3.Text = "ارسال الفاتورة للعميل"
        '
        'check_Stats
        '
        Me.check_Stats.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.check_Stats.BackColor = System.Drawing.Color.Transparent
        Me.check_Stats.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.check_Stats.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.check_Stats.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.check_Stats.CheckedState.InnerColor = System.Drawing.Color.White
        Me.check_Stats.Location = New System.Drawing.Point(460, 5)
        Me.check_Stats.Name = "check_Stats"
        Me.check_Stats.Size = New System.Drawing.Size(78, 32)
        Me.check_Stats.TabIndex = 5623
        Me.check_Stats.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.check_Stats.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.check_Stats.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.check_Stats.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'lbl_Debit
        '
        Me.lbl_Debit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Debit.AutoSize = False
        Me.lbl_Debit.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Debit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Debit.ForeColor = System.Drawing.Color.Black
        Me.lbl_Debit.Location = New System.Drawing.Point(7, 144)
        Me.lbl_Debit.Name = "lbl_Debit"
        Me.lbl_Debit.Size = New System.Drawing.Size(162, 36)
        Me.lbl_Debit.TabIndex = 5622
        Me.lbl_Debit.Text = "مديون"
        Me.lbl_Debit.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Debit.Visible = False
        '
        'txtDebit
        '
        Me.txtDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDebit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDebit.DefaultText = ""
        Me.txtDebit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDebit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDebit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDebit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDebit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDebit.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtDebit.ForeColor = System.Drawing.Color.Black
        Me.txtDebit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDebit.Location = New System.Drawing.Point(7, 185)
        Me.txtDebit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.PlaceholderText = ""
        Me.txtDebit.ReadOnly = True
        Me.txtDebit.SelectedText = ""
        Me.txtDebit.Size = New System.Drawing.Size(162, 45)
        Me.txtDebit.TabIndex = 5621
        Me.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDebit.Visible = False
        '
        'lbl_Credit
        '
        Me.lbl_Credit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Credit.AutoSize = False
        Me.lbl_Credit.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Credit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Credit.ForeColor = System.Drawing.Color.Black
        Me.lbl_Credit.Location = New System.Drawing.Point(179, 144)
        Me.lbl_Credit.Name = "lbl_Credit"
        Me.lbl_Credit.Size = New System.Drawing.Size(162, 36)
        Me.lbl_Credit.TabIndex = 5620
        Me.lbl_Credit.Text = "دائن"
        Me.lbl_Credit.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Credit.Visible = False
        '
        'txtCredit
        '
        Me.txtCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCredit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCredit.DefaultText = ""
        Me.txtCredit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCredit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCredit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCredit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCredit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCredit.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCredit.ForeColor = System.Drawing.Color.Black
        Me.txtCredit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCredit.Location = New System.Drawing.Point(179, 185)
        Me.txtCredit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.PlaceholderText = ""
        Me.txtCredit.ReadOnly = True
        Me.txtCredit.SelectedText = ""
        Me.txtCredit.Size = New System.Drawing.Size(162, 45)
        Me.txtCredit.TabIndex = 5619
        Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCredit.Visible = False
        '
        'btnToggleDiscount
        '
        Me.btnToggleDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToggleDiscount.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToggleDiscount.Appearance.Options.UseFont = True
        Me.btnToggleDiscount.AutoSize = True
        Me.btnToggleDiscount.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.gift
        Me.btnToggleDiscount.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnToggleDiscount.Location = New System.Drawing.Point(5, 2)
        Me.btnToggleDiscount.Name = "btnToggleDiscount"
        Me.btnToggleDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnToggleDiscount.Size = New System.Drawing.Size(38, 36)
        Me.btnToggleDiscount.TabIndex = 5618
        '
        'btn_search_Customer_name
        '
        Me.btn_search_Customer_name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_search_Customer_name.Image = Global.WindowsApp1.My.Resources.Resources.search1
        Me.btn_search_Customer_name.Location = New System.Drawing.Point(957, 133)
        Me.btn_search_Customer_name.Name = "btn_search_Customer_name"
        Me.btn_search_Customer_name.Size = New System.Drawing.Size(66, 45)
        Me.btn_search_Customer_name.TabIndex = 5617
        Me.btn_search_Customer_name.UseVisualStyleBackColor = True
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel9.AutoSize = False
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(125, 235)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(206, 29)
        Me.Guna2HtmlLabel9.TabIndex = 5616
        Me.Guna2HtmlLabel9.Text = "الملاحظات"
        Me.Guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txt_notes
        '
        Me.txt_notes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_notes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_notes.DefaultText = ""
        Me.txt_notes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_notes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_notes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_notes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_notes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_notes.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txt_notes.ForeColor = System.Drawing.Color.Black
        Me.txt_notes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_notes.Location = New System.Drawing.Point(15, 266)
        Me.txt_notes.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_notes.Multiline = True
        Me.txt_notes.Name = "txt_notes"
        Me.txt_notes.PlaceholderText = ""
        Me.txt_notes.SelectedText = ""
        Me.txt_notes.Size = New System.Drawing.Size(316, 108)
        Me.txt_notes.TabIndex = 5615
        '
        'btn_search_Customer_ID
        '
        Me.btn_search_Customer_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_search_Customer_ID.Image = Global.WindowsApp1.My.Resources.Resources.search1
        Me.btn_search_Customer_ID.Location = New System.Drawing.Point(957, 87)
        Me.btn_search_Customer_ID.Name = "btn_search_Customer_ID"
        Me.btn_search_Customer_ID.Size = New System.Drawing.Size(66, 41)
        Me.btn_search_Customer_ID.TabIndex = 5613
        Me.btn_search_Customer_ID.UseVisualStyleBackColor = True
        '
        'lstCodeSuggestions
        '
        Me.lstCodeSuggestions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCodeSuggestions.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCodeSuggestions.FormattingEnabled = True
        Me.lstCodeSuggestions.ItemHeight = 22
        Me.lstCodeSuggestions.Location = New System.Drawing.Point(1354, 465)
        Me.lstCodeSuggestions.Name = "lstCodeSuggestions"
        Me.lstCodeSuggestions.Size = New System.Drawing.Size(243, 70)
        Me.lstCodeSuggestions.TabIndex = 5610
        '
        'lstNameSuggestions
        '
        Me.lstNameSuggestions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstNameSuggestions.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNameSuggestions.FormattingEnabled = True
        Me.lstNameSuggestions.ItemHeight = 22
        Me.lstNameSuggestions.Location = New System.Drawing.Point(826, 465)
        Me.lstNameSuggestions.Name = "lstNameSuggestions"
        Me.lstNameSuggestions.Size = New System.Drawing.Size(522, 70)
        Me.lstNameSuggestions.TabIndex = 5609
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(171, 374)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 33)
        Me.Label16.TabIndex = 5608
        Me.Label16.Text = "الاجمالي"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txt_totelProduct
        '
        Me.txt_totelProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_totelProduct.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_totelProduct.DefaultText = ""
        Me.txt_totelProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_totelProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_totelProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_totelProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_totelProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_totelProduct.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totelProduct.ForeColor = System.Drawing.Color.Black
        Me.txt_totelProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_totelProduct.Location = New System.Drawing.Point(171, 413)
        Me.txt_totelProduct.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_totelProduct.Name = "txt_totelProduct"
        Me.txt_totelProduct.PlaceholderText = ""
        Me.txt_totelProduct.ReadOnly = True
        Me.txt_totelProduct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_totelProduct.SelectedText = ""
        Me.txt_totelProduct.Size = New System.Drawing.Size(156, 49)
        Me.txt_totelProduct.TabIndex = 5607
        Me.txt_totelProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Customer_Balance
        '
        Me.txt_Customer_Balance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Customer_Balance.BorderRadius = 2
        Me.txt_Customer_Balance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Customer_Balance.DefaultText = ""
        Me.txt_Customer_Balance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Customer_Balance.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Customer_Balance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Customer_Balance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Customer_Balance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Customer_Balance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Customer_Balance.ForeColor = System.Drawing.Color.Black
        Me.txt_Customer_Balance.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Customer_Balance.Location = New System.Drawing.Point(58, 92)
        Me.txt_Customer_Balance.Margin = New System.Windows.Forms.Padding(9)
        Me.txt_Customer_Balance.Name = "txt_Customer_Balance"
        Me.txt_Customer_Balance.PlaceholderText = ""
        Me.txt_Customer_Balance.ReadOnly = True
        Me.txt_Customer_Balance.SelectedText = ""
        Me.txt_Customer_Balance.Size = New System.Drawing.Size(279, 49)
        Me.txt_Customer_Balance.TabIndex = 5606
        Me.txt_Customer_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_Customer_Balance.Visible = False
        '
        'lbl_Customer_Balance
        '
        Me.lbl_Customer_Balance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Customer_Balance.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Customer_Balance.Location = New System.Drawing.Point(86, 42)
        Me.lbl_Customer_Balance.Name = "lbl_Customer_Balance"
        Me.lbl_Customer_Balance.Size = New System.Drawing.Size(251, 41)
        Me.lbl_Customer_Balance.TabIndex = 5605
        Me.lbl_Customer_Balance.Text = "رصيد العميل الحالي"
        Me.lbl_Customer_Balance.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbl_Customer_Balance.Visible = False
        '
        'lstSuggestions
        '
        Me.lstSuggestions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSuggestions.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 29
        Me.lstSuggestions.Location = New System.Drawing.Point(960, 183)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.Size = New System.Drawing.Size(414, 120)
        Me.lstSuggestions.TabIndex = 5604
        '
        'txtTotalAfterDiscount
        '
        Me.txtTotalAfterDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAfterDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalAfterDiscount.DefaultText = ""
        Me.txtTotalAfterDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotalAfterDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotalAfterDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalAfterDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalAfterDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalAfterDiscount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalAfterDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtTotalAfterDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalAfterDiscount.Location = New System.Drawing.Point(353, 100)
        Me.txtTotalAfterDiscount.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTotalAfterDiscount.Name = "txtTotalAfterDiscount"
        Me.txtTotalAfterDiscount.PlaceholderText = ""
        Me.txtTotalAfterDiscount.ReadOnly = True
        Me.txtTotalAfterDiscount.SelectedText = ""
        Me.txtTotalAfterDiscount.Size = New System.Drawing.Size(339, 45)
        Me.txtTotalAfterDiscount.TabIndex = 5603
        Me.txtTotalAfterDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalAfter
        '
        Me.lblTotalAfter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAfter.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAfter.Location = New System.Drawing.Point(689, 100)
        Me.lblTotalAfter.Name = "lblTotalAfter"
        Me.lblTotalAfter.Size = New System.Drawing.Size(262, 45)
        Me.lblTotalAfter.TabIndex = 5602
        Me.lblTotalAfter.Text = "الاجمالي بعد الخصم"
        Me.lblTotalAfter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPaid
        '
        Me.txtPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaid.DefaultText = ""
        Me.txtPaid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPaid.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPaid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaid.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtPaid.ForeColor = System.Drawing.Color.Black
        Me.txtPaid.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaid.Location = New System.Drawing.Point(445, 200)
        Me.txtPaid.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.PlaceholderText = ""
        Me.txtPaid.SelectedText = ""
        Me.txtPaid.Size = New System.Drawing.Size(321, 45)
        Me.txtPaid.TabIndex = 5601
        Me.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPaid
        '
        Me.lblPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPaid.BackColor = System.Drawing.Color.Transparent
        Me.lblPaid.Location = New System.Drawing.Point(775, 200)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(141, 45)
        Me.lblPaid.TabIndex = 5600
        Me.lblPaid.Text = "المدفوع"
        Me.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_Pay
        '
        Me.cmb_Pay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_Pay.BackColor = System.Drawing.Color.Transparent
        Me.cmb_Pay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_Pay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Pay.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmb_Pay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmb_Pay.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmb_Pay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmb_Pay.ItemHeight = 30
        Me.cmb_Pay.Location = New System.Drawing.Point(352, 154)
        Me.cmb_Pay.Name = "cmb_Pay"
        Me.cmb_Pay.Size = New System.Drawing.Size(385, 36)
        Me.cmb_Pay.TabIndex = 5599
        Me.cmb_Pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(733, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(189, 45)
        Me.Label5.TabIndex = 5598
        Me.Label5.Text = "طريقة الدفع"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Invoice_ID
        '
        Me.txt_Invoice_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Invoice_ID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Invoice_ID.DefaultText = ""
        Me.txt_Invoice_ID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Invoice_ID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Invoice_ID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Invoice_ID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Invoice_ID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Invoice_ID.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Invoice_ID.ForeColor = System.Drawing.Color.Black
        Me.txt_Invoice_ID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Invoice_ID.Location = New System.Drawing.Point(960, 47)
        Me.txt_Invoice_ID.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Invoice_ID.Name = "txt_Invoice_ID"
        Me.txt_Invoice_ID.PlaceholderText = ""
        Me.txt_Invoice_ID.ReadOnly = True
        Me.txt_Invoice_ID.SelectedText = ""
        Me.txt_Invoice_ID.Size = New System.Drawing.Size(414, 34)
        Me.txt_Invoice_ID.TabIndex = 5597
        Me.txt_Invoice_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(1374, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 34)
        Me.Label1.TabIndex = 5596
        Me.Label1.Text = "رقم الفاتورة"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_add_product
        '
        Me.btn_add_product.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_add_product.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_product.Appearance.Options.UseFont = True
        Me.btn_add_product.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.queue__2_
        Me.btn_add_product.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_add_product.Location = New System.Drawing.Point(7, 413)
        Me.btn_add_product.Name = "btn_add_product"
        Me.btn_add_product.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_add_product.Size = New System.Drawing.Size(159, 123)
        Me.btn_add_product.TabIndex = 5595
        Me.btn_add_product.Text = "اضافة"
        '
        'txtTotalRequired
        '
        Me.txtTotalRequired.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalRequired.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalRequired.DefaultText = ""
        Me.txtTotalRequired.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotalRequired.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotalRequired.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalRequired.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalRequired.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalRequired.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalRequired.ForeColor = System.Drawing.Color.Black
        Me.txtTotalRequired.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalRequired.Location = New System.Drawing.Point(960, 311)
        Me.txtTotalRequired.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTotalRequired.Name = "txtTotalRequired"
        Me.txtTotalRequired.PlaceholderText = ""
        Me.txtTotalRequired.ReadOnly = True
        Me.txtTotalRequired.SelectedText = ""
        Me.txtTotalRequired.Size = New System.Drawing.Size(414, 45)
        Me.txtTotalRequired.TabIndex = 5578
        Me.txtTotalRequired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalBefore
        '
        Me.lblTotalBefore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalBefore.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalBefore.Location = New System.Drawing.Point(1378, 311)
        Me.lblTotalBefore.Name = "lblTotalBefore"
        Me.lblTotalBefore.Size = New System.Drawing.Size(210, 45)
        Me.lblTotalBefore.TabIndex = 5577
        Me.lblTotalBefore.Text = "اجمالي الفاتورة"
        Me.lblTotalBefore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Customer_Name
        '
        Me.txt_Customer_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Customer_Name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Customer_Name.DefaultText = ""
        Me.txt_Customer_Name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Customer_Name.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Customer_Name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Customer_Name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Customer_Name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Customer_Name.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Customer_Name.ForeColor = System.Drawing.Color.Black
        Me.txt_Customer_Name.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Customer_Name.Location = New System.Drawing.Point(1025, 133)
        Me.txt_Customer_Name.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Customer_Name.Name = "txt_Customer_Name"
        Me.txt_Customer_Name.PlaceholderText = ""
        Me.txt_Customer_Name.SelectedText = ""
        Me.txt_Customer_Name.Size = New System.Drawing.Size(349, 45)
        Me.txt_Customer_Name.TabIndex = 5576
        Me.txt_Customer_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(1374, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 45)
        Me.Label2.TabIndex = 5575
        Me.Label2.Text = "اسم العميل"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_clean
        '
        Me.btn_clean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_clean.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clean.Appearance.Options.UseFont = True
        Me.btn_clean.AutoSize = True
        Me.btn_clean.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.eraser
        Me.btn_clean.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_clean.Location = New System.Drawing.Point(1360, 2)
        Me.btn_clean.Name = "btn_clean"
        Me.btn_clean.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_clean.Size = New System.Drawing.Size(38, 36)
        Me.btn_clean.TabIndex = 44
        '
        'Timer2
        '
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
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblDate.Location = New System.Drawing.Point(1229, 9)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDate.Size = New System.Drawing.Size(371, 53)
        Me.lblDate.TabIndex = 7
        Me.lblDate.Text = "Time Now"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblTime.Location = New System.Drawing.Point(911, 9)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTime.Size = New System.Drawing.Size(318, 53)
        Me.lblTime.TabIndex = 6
        Me.lblTime.Text = "Time Now"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblLang)
        Me.panelHeader.Controls.Add(Me.Label14)
        Me.panelHeader.Controls.Add(Me.lbl_user_name)
        Me.panelHeader.Controls.Add(Me.lblTime)
        Me.panelHeader.Controls.Add(Me.lblDate)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1600, 70)
        Me.panelHeader.TabIndex = 77
        '
        'lblLang
        '
        Me.lblLang.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblLang.Location = New System.Drawing.Point(154, 10)
        Me.lblLang.Name = "lblLang"
        Me.lblLang.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLang.Size = New System.Drawing.Size(137, 43)
        Me.lblLang.TabIndex = 10
        Me.lblLang.Text = "عربي"
        Me.lblLang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(556, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(199, 53)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "اسم المستخدم"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_user_name
        '
        Me.lbl_user_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user_name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lbl_user_name.Location = New System.Drawing.Point(297, 9)
        Me.lbl_user_name.Name = "lbl_user_name"
        Me.lbl_user_name.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_user_name.Size = New System.Drawing.Size(242, 53)
        Me.lbl_user_name.TabIndex = 8
        Me.lbl_user_name.Text = "Time Now"
        Me.lbl_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(802, 9)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(111, 44)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "المبيعات"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.AutoSize = True
        Me.SimpleButton1.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.eraser
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 686)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SimpleButton1.Size = New System.Drawing.Size(38, 36)
        Me.SimpleButton1.TabIndex = 81
        '
        'Sales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1600, 1100)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.panelHeader)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Sales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        CType(Me.Pic_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents btnSaveInvoice As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents btn_add_product As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents Label13 As Label
	Friend WithEvents txtQuantity As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents Label12 As Label
	Friend WithEvents Label11 As Label
	Friend WithEvents cmbUnit As Guna.UI2.WinForms.Guna2ComboBox
	Friend WithEvents Label10 As Label
	Friend WithEvents txtProductCodeSearch As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents Label9 As Label
	Friend WithEvents txtSalePrice As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents txtProductNameSearch As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents btn_Sales_Returns As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents txtRemaining As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
	Friend WithEvents Button1 As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents txtDiscount As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents lblDiscount As Label
	Friend WithEvents lblRemaining As Label
	Friend WithEvents txt_Customer_Code As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents Label8 As Label
	Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
	Friend WithEvents txt_Invoice_ID As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents txtTotalRequired As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents lblTotalBefore As Label
	Friend WithEvents txt_Customer_Name As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents btn_clean As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents txtPaid As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents lblPaid As Label
	Friend WithEvents cmb_Pay As Guna.UI2.WinForms.Guna2ComboBox
	Friend WithEvents Label5 As Label
	Friend WithEvents txtTotalAfterDiscount As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents lblTotalAfter As Label
	Friend WithEvents lstSuggestions As ListBox
	Friend WithEvents Timer2 As Timer
	Friend WithEvents txt_Customer_Balance As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents lbl_Customer_Balance As Label
	Friend WithEvents Label16 As Label
	Friend WithEvents txt_totelProduct As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents btnToggleScanner As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents lstNameSuggestions As ListBox
	Friend WithEvents lstCodeSuggestions As ListBox
	Friend WithEvents btn_search_Customer_ID As Button
	Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
	Friend WithEvents txt_notes As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents btn_search_Customer_name As Button
	Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents lblDate As Label
	Friend WithEvents lblTime As Label
	Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
	Friend WithEvents Label14 As Label
	Friend WithEvents lbl_user_name As Label
	Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
	Friend WithEvents btnToggleDiscount As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents lbl_Debit As Guna.UI2.WinForms.Guna2HtmlLabel
	Friend WithEvents txtDebit As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents lbl_Credit As Guna.UI2.WinForms.Guna2HtmlLabel
	Friend WithEvents txtCredit As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents check_Stats As Guna.UI2.WinForms.Guna2ToggleSwitch
	Friend WithEvents Button2 As Button
	Friend WithEvents Guna2TextBox2 As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents txt_free_profit As Guna.UI2.WinForms.Guna2TextBox
	Friend WithEvents btn_money As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents Pic_Logo As PictureBox
	Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents btn_auto_pay As Button
	Friend WithEvents lblLang As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Guna2ToggleSwitch1 As Guna.UI2.WinForms.Guna2ToggleSwitch
    Public WithEvents btn_Invoice_Edit As Guna.UI2.WinForms.Guna2Button
End Class
