<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMaterialUnits
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaterialUnits))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblMaterialName = New System.Windows.Forms.Label()
        Me.cmbUnit = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConversionFactor = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblBaseUnitHint = New System.Windows.Forms.Label()
        Me.txtBarcode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPurchasePrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvMaterialUnits = New System.Windows.Forms.DataGridView()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClearFields = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteUnit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddUnit = New Guna.UI2.WinForms.Guna2Button()
        Me.panelHeader.SuspendLayout()
        CType(Me.dgvMaterialUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btnClose)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1067, 70)
        Me.panelHeader.TabIndex = 46
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.AutoSize = True
        Me.btnClose.ImageOptions.SvgImage = CType(resources.GetObject("btnClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnClose.Location = New System.Drawing.Point(15, 17)
        Me.btnClose.Name = "btn_close"
        Me.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnClose.Size = New System.Drawing.Size(38, 36)
        Me.btnClose.TabIndex = 3
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(458, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(190, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = " التحويل معاملات "
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblMaterialName
        '
        Me.lblMaterialName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMaterialName.BackColor = System.Drawing.Color.Transparent
        Me.lblMaterialName.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblMaterialName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblMaterialName.Location = New System.Drawing.Point(379, 73)
        Me.lblMaterialName.Name = "lblMaterialName"
        Me.lblMaterialName.Size = New System.Drawing.Size(676, 36)
        Me.lblMaterialName.TabIndex = 5584
        Me.lblMaterialName.Text = " الخامة"
        Me.lblMaterialName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbUnit
        '
        Me.cmbUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUnit.BackColor = System.Drawing.Color.Transparent
        Me.cmbUnit.BorderRadius = 6
        Me.cmbUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnit.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbUnit.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbUnit.ForeColor = System.Drawing.Color.Black
        Me.cmbUnit.ItemHeight = 30
        Me.cmbUnit.Location = New System.Drawing.Point(770, 114)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(199, 36)
        Me.cmbUnit.TabIndex = 5605
        Me.cmbUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(975, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 36)
        Me.Label5.TabIndex = 5604
        Me.Label5.Text = "الوحدة *"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(975, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 36)
        Me.Label1.TabIndex = 5606
        Me.Label1.Text = "المعامل *"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConversionFactor
        '
        Me.txtConversionFactor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConversionFactor.BorderRadius = 6
        Me.txtConversionFactor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConversionFactor.DefaultText = ""
        Me.txtConversionFactor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtConversionFactor.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtConversionFactor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtConversionFactor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtConversionFactor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtConversionFactor.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtConversionFactor.ForeColor = System.Drawing.Color.Black
        Me.txtConversionFactor.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtConversionFactor.Location = New System.Drawing.Point(770, 157)
        Me.txtConversionFactor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtConversionFactor.Name = "txtConversionFactor"
        Me.txtConversionFactor.PlaceholderText = ""
        Me.txtConversionFactor.SelectedText = ""
        Me.txtConversionFactor.Size = New System.Drawing.Size(199, 36)
        Me.txtConversionFactor.TabIndex = 5607
        Me.txtConversionFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBaseUnitHint
        '
        Me.lblBaseUnitHint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBaseUnitHint.BackColor = System.Drawing.Color.Transparent
        Me.lblBaseUnitHint.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBaseUnitHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblBaseUnitHint.Location = New System.Drawing.Point(694, 157)
        Me.lblBaseUnitHint.Name = "lblBaseUnitHint"
        Me.lblBaseUnitHint.Size = New System.Drawing.Size(70, 36)
        Me.lblBaseUnitHint.TabIndex = 5612
        Me.lblBaseUnitHint.Text = "الوحدة"
        Me.lblBaseUnitHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBarcode
        '
        Me.txtBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBarcode.BorderRadius = 6
        Me.txtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBarcode.DefaultText = ""
        Me.txtBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtBarcode.Location = New System.Drawing.Point(379, 114)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.PlaceholderText = ""
        Me.txtBarcode.SelectedText = ""
        Me.txtBarcode.Size = New System.Drawing.Size(199, 36)
        Me.txtBarcode.TabIndex = 5614
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(584, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 36)
        Me.Label2.TabIndex = 5613
        Me.Label2.Text = "الباركود"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPurchasePrice
        '
        Me.txtPurchasePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPurchasePrice.BorderRadius = 6
        Me.txtPurchasePrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPurchasePrice.DefaultText = ""
        Me.txtPurchasePrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPurchasePrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPurchasePrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPurchasePrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPurchasePrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPurchasePrice.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPurchasePrice.ForeColor = System.Drawing.Color.Black
        Me.txtPurchasePrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPurchasePrice.Location = New System.Drawing.Point(379, 158)
        Me.txtPurchasePrice.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPurchasePrice.Name = "txtPurchasePrice"
        Me.txtPurchasePrice.PlaceholderText = ""
        Me.txtPurchasePrice.SelectedText = ""
        Me.txtPurchasePrice.Size = New System.Drawing.Size(199, 36)
        Me.txtPurchasePrice.TabIndex = 5616
        Me.txtPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(584, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 36)
        Me.Label3.TabIndex = 5615
        Me.Label3.Text = "سعر الشراء"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvMaterialUnits
        '
        Me.dgvMaterialUnits.AllowUserToResizeColumns = False
        Me.dgvMaterialUnits.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvMaterialUnits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMaterialUnits.BackgroundColor = System.Drawing.Color.White
        Me.dgvMaterialUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaterialUnits.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvMaterialUnits.Location = New System.Drawing.Point(0, 253)
        Me.dgvMaterialUnits.Name = "dgvMaterialUnits"
        Me.dgvMaterialUnits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvMaterialUnits.RowTemplate.Height = 35
        Me.dgvMaterialUnits.Size = New System.Drawing.Size(1067, 397)
        Me.dgvMaterialUnits.TabIndex = 5617
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.Controls.Add(Me.btnClearFields)
        Me.Guna2Panel1.Controls.Add(Me.btnDeleteUnit)
        Me.Guna2Panel1.Controls.Add(Me.btnEdit)
        Me.Guna2Panel1.Controls.Add(Me.btnAddUnit)
        Me.Guna2Panel1.Location = New System.Drawing.Point(260, 201)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(518, 47)
        Me.Guna2Panel1.TabIndex = 5618
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
        Me.btnClearFields.Location = New System.Drawing.Point(10, 6)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(133, 38)
        Me.btnClearFields.TabIndex = 3
        Me.btnClearFields.Text = "تفريغ الحقول"
        '
        'btnDeleteUnit
        '
        Me.btnDeleteUnit.BorderRadius = 6
        Me.btnDeleteUnit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteUnit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteUnit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteUnit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteUnit.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDeleteUnit.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteUnit.ForeColor = System.Drawing.Color.White
        Me.btnDeleteUnit.Location = New System.Drawing.Point(166, 6)
        Me.btnDeleteUnit.Name = "btnDeleteUnit"
        Me.btnDeleteUnit.Size = New System.Drawing.Size(100, 38)
        Me.btnDeleteUnit.TabIndex = 2
        Me.btnDeleteUnit.Text = "حذف"
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
        Me.btnEdit.Location = New System.Drawing.Point(289, 6)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 38)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "تعديل"
        '
        'btnAddUnit
        '
        Me.btnAddUnit.BorderRadius = 6
        Me.btnAddUnit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddUnit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddUnit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddUnit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddUnit.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnAddUnit.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddUnit.ForeColor = System.Drawing.Color.White
        Me.btnAddUnit.Location = New System.Drawing.Point(412, 6)
        Me.btnAddUnit.Name = "btnAddUnit"
        Me.btnAddUnit.Size = New System.Drawing.Size(100, 38)
        Me.btnAddUnit.TabIndex = 0
        Me.btnAddUnit.Text = "إضافة"
        '
        'frmMaterialUnits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 650)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.dgvMaterialUnits)
        Me.Controls.Add(Me.txtPurchasePrice)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblBaseUnitHint)
        Me.Controls.Add(Me.txtConversionFactor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbUnit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblMaterialName)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMaterialUnits"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.dgvMaterialUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblMaterialName As Label
    Friend WithEvents cmbUnit As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtConversionFactor As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblBaseUnitHint As Label
    Friend WithEvents txtBarcode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPurchasePrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvMaterialUnits As DataGridView
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClearFields As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteUnit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddUnit As Guna.UI2.WinForms.Guna2Button
End Class
