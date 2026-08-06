<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProductAddons
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductAddons))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClearFields = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbProduct = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.dgvProductAddons = New System.Windows.Forms.DataGridView()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.tgIsDefault = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSortOrder = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSalePrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCostPrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAddon = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddAddonForm = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddProductForm = New Guna.UI2.WinForms.Guna2Button()
        Me.panelHeader.SuspendLayout()
        CType(Me.dgvProductAddons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClearFields
        '
        Me.btnClearFields.BorderRadius = 6
        Me.btnClearFields.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFields.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFields.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearFields.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearFields.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearFields.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearFields.ForeColor = System.Drawing.Color.White
        Me.btnClearFields.Location = New System.Drawing.Point(461, 6)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(209, 38)
        Me.btnClearFields.TabIndex = 3
        Me.btnClearFields.Text = "تفريغ الحقول"
        '
        'btnRefresh
        '
        Me.btnRefresh.BorderRadius = 6
        Me.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(232, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(199, 38)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "تحديث"
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1427, 70)
        Me.panelHeader.TabIndex = 42
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
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(640, 16)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(146, 32)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الاصناف اضافات"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtSearch
        '
        Me.txtSearch.BorderRadius = 6
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(3, 49)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "البحث..."
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(316, 36)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tgStatus
        '
        Me.tgStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Location = New System.Drawing.Point(417, 150)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(70, 30)
        Me.tgStatus.TabIndex = 5599
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(497, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 36)
        Me.Label4.TabIndex = 5598
        Me.Label4.Text = "نشط"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(1344, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 36)
        Me.Label5.TabIndex = 5590
        Me.Label5.Text = "الصنف"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbProduct
        '
        Me.cmbProduct.BackColor = System.Drawing.Color.Transparent
        Me.cmbProduct.BorderRadius = 6
        Me.cmbProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProduct.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbProduct.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbProduct.ForeColor = System.Drawing.Color.Black
        Me.cmbProduct.ItemHeight = 30
        Me.cmbProduct.Location = New System.Drawing.Point(1088, 50)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(250, 36)
        Me.cmbProduct.TabIndex = 5588
        Me.cmbProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbSearchField
        '
        Me.cmbSearchField.BackColor = System.Drawing.Color.Transparent
        Me.cmbSearchField.BorderRadius = 6
        Me.cmbSearchField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchField.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSearchField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSearchField.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbSearchField.ForeColor = System.Drawing.Color.Black
        Me.cmbSearchField.ItemHeight = 30
        Me.cmbSearchField.Location = New System.Drawing.Point(325, 49)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(202, 36)
        Me.cmbSearchField.TabIndex = 2
        Me.cmbSearchField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'lstSuggestions
        '
        Me.lstSuggestions.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lstSuggestions.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 17
        Me.lstSuggestions.Location = New System.Drawing.Point(3, 90)
        Me.lstSuggestions.Margin = New System.Windows.Forms.Padding(4)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.Size = New System.Drawing.Size(316, 89)
        Me.lstSuggestions.TabIndex = 37
        Me.lstSuggestions.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BorderRadius = 6
        Me.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelete.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(700, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(199, 38)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف"
        '
        'dgvProductAddons
        '
        Me.dgvProductAddons.AllowUserToResizeColumns = False
        Me.dgvProductAddons.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvProductAddons.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductAddons.BackgroundColor = System.Drawing.Color.White
        Me.dgvProductAddons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductAddons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductAddons.Location = New System.Drawing.Point(0, 305)
        Me.dgvProductAddons.Name = "dgvProductAddons"
        Me.dgvProductAddons.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvProductAddons.RowTemplate.Height = 35
        Me.dgvProductAddons.Size = New System.Drawing.Size(1427, 595)
        Me.dgvProductAddons.TabIndex = 44
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.btnAddProductForm)
        Me.grpCustomerInfo.Controls.Add(Me.tgIsDefault)
        Me.grpCustomerInfo.Controls.Add(Me.Label8)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.txtSortOrder)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.txtSalePrice)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.txtCostPrice)
        Me.grpCustomerInfo.Controls.Add(Me.btnAddAddonForm)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.cmbAddon)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2Panel1)
        Me.grpCustomerInfo.Controls.Add(Me.tgStatus)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.cmbProduct)
        Me.grpCustomerInfo.Controls.Add(Me.cmbSearchField)
        Me.grpCustomerInfo.Controls.Add(Me.lstSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.txtSearch)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 70)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1427, 235)
        Me.grpCustomerInfo.TabIndex = 43
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tgIsDefault
        '
        Me.tgIsDefault.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgIsDefault.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.tgIsDefault.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.tgIsDefault.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgIsDefault.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgIsDefault.Location = New System.Drawing.Point(417, 100)
        Me.tgIsDefault.Name = "tgIsDefault"
        Me.tgIsDefault.Size = New System.Drawing.Size(70, 30)
        Me.tgIsDefault.TabIndex = 5619
        Me.tgIsDefault.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgIsDefault.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgIsDefault.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgIsDefault.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(497, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 36)
        Me.Label8.TabIndex = 5618
        Me.Label8.Text = "الافتراضي"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(758, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 36)
        Me.Label7.TabIndex = 5617
        Me.Label7.Text = "الترتيب"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSortOrder
        '
        Me.txtSortOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSortOrder.BorderRadius = 6
        Me.txtSortOrder.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSortOrder.DefaultText = ""
        Me.txtSortOrder.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSortOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSortOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSortOrder.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSortOrder.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSortOrder.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSortOrder.ForeColor = System.Drawing.Color.Black
        Me.txtSortOrder.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSortOrder.Location = New System.Drawing.Point(622, 50)
        Me.txtSortOrder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSortOrder.Name = "txtSortOrder"
        Me.txtSortOrder.PlaceholderText = ""
        Me.txtSortOrder.SelectedText = ""
        Me.txtSortOrder.Size = New System.Drawing.Size(130, 36)
        Me.txtSortOrder.TabIndex = 5616
        Me.txtSortOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(974, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 36)
        Me.Label3.TabIndex = 5613
        Me.Label3.Text = "سعر البيع"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSalePrice
        '
        Me.txtSalePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSalePrice.BorderRadius = 6
        Me.txtSalePrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSalePrice.DefaultText = ""
        Me.txtSalePrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSalePrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSalePrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSalePrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSalePrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSalePrice.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSalePrice.ForeColor = System.Drawing.Color.Black
        Me.txtSalePrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSalePrice.Location = New System.Drawing.Point(826, 100)
        Me.txtSalePrice.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSalePrice.Name = "txtSalePrice"
        Me.txtSalePrice.PlaceholderText = ""
        Me.txtSalePrice.SelectedText = ""
        Me.txtSalePrice.Size = New System.Drawing.Size(142, 36)
        Me.txtSalePrice.TabIndex = 5612
        Me.txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(974, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 36)
        Me.Label2.TabIndex = 5611
        Me.Label2.Text = "التكلفة"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCostPrice
        '
        Me.txtCostPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCostPrice.BorderRadius = 6
        Me.txtCostPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCostPrice.DefaultText = ""
        Me.txtCostPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCostPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCostPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCostPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCostPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCostPrice.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCostPrice.ForeColor = System.Drawing.Color.Black
        Me.txtCostPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCostPrice.Location = New System.Drawing.Point(826, 50)
        Me.txtCostPrice.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCostPrice.Name = "txtCostPrice"
        Me.txtCostPrice.PlaceholderText = ""
        Me.txtCostPrice.SelectedText = ""
        Me.txtCostPrice.Size = New System.Drawing.Size(142, 36)
        Me.txtCostPrice.TabIndex = 5610
        Me.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1344, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 36)
        Me.Label1.TabIndex = 5608
        Me.Label1.Text = "الإضافة"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbAddon
        '
        Me.cmbAddon.BackColor = System.Drawing.Color.Transparent
        Me.cmbAddon.BorderRadius = 6
        Me.cmbAddon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAddon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAddon.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbAddon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbAddon.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbAddon.ForeColor = System.Drawing.Color.Black
        Me.cmbAddon.ItemHeight = 30
        Me.cmbAddon.Location = New System.Drawing.Point(1088, 100)
        Me.cmbAddon.Name = "cmbAddon"
        Me.cmbAddon.Size = New System.Drawing.Size(250, 36)
        Me.cmbAddon.TabIndex = 5607
        Me.cmbAddon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.Controls.Add(Me.btnRefresh)
        Me.Guna2Panel1.Controls.Add(Me.btnClearFields)
        Me.Guna2Panel1.Controls.Add(Me.btnDelete)
        Me.Guna2Panel1.Controls.Add(Me.btnEdit)
        Me.Guna2Panel1.Controls.Add(Me.btnAdd)
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 187)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1427, 48)
        Me.Guna2Panel1.TabIndex = 5600
        '
        'btnEdit
        '
        Me.btnEdit.BorderRadius = 6
        Me.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnEdit.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(929, 6)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(199, 38)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "تعديل"
        '
        'btnAdd
        '
        Me.btnAdd.BorderRadius = 6
        Me.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(1158, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(199, 38)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "إضافة"
        '
        'btnAddAddonForm
        '
        Me.btnAddAddonForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddAddonForm.BorderRadius = 6
        Me.btnAddAddonForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddAddonForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddAddonForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddAddonForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddAddonForm.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnAddAddonForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddAddonForm.ForeColor = System.Drawing.Color.White
        Me.btnAddAddonForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddAddonForm.Location = New System.Drawing.Point(1046, 100)
        Me.btnAddAddonForm.Name = "btnAddAddonForm"
        Me.btnAddAddonForm.Size = New System.Drawing.Size(36, 36)
        Me.btnAddAddonForm.TabIndex = 5609
        '
        'btnAddProductForm
        '
        Me.btnAddProductForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddProductForm.BorderRadius = 6
        Me.btnAddProductForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddProductForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddProductForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddProductForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddProductForm.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnAddProductForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddProductForm.ForeColor = System.Drawing.Color.White
        Me.btnAddProductForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddProductForm.Location = New System.Drawing.Point(1046, 50)
        Me.btnAddProductForm.Name = "btnAddProductForm"
        Me.btnAddProductForm.Size = New System.Drawing.Size(36, 36)
        Me.btnAddProductForm.TabIndex = 5620
        '
        'frmProductAddons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1427, 900)
        Me.Controls.Add(Me.dgvProductAddons)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmProductAddons"
        Me.Text = "frmProductAddons"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.dgvProductAddons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClearFields As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddAddonForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbProduct As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents dgvProductAddons As DataGridView
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents tgIsDefault As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSortOrder As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSalePrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCostPrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbAddon As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents btnAddProductForm As Guna.UI2.WinForms.Guna2Button
End Class
