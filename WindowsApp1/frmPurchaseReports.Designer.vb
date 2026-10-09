<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPurchaseReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchaseReports))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dgvReport = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
        Me.rbItemsDetails = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.rbInvoicesSummary = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSearch = New Guna.UI2.WinForms.Guna2Button()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbMaterial = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbPaymentType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbStore = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSupplier = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.dtpTo = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFrom = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblInvoiceCount = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTotalRemaining = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblNetTotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotalDiscount = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btnClose)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1400, 70)
        Me.panelHeader.TabIndex = 47
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
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(635, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(191, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "المشتريات تقارير "
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'dgvReport
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReport.ColumnHeadersHeight = 4
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReport.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReport.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvReport.Location = New System.Drawing.Point(0, 258)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvReport.RowHeadersVisible = False
        Me.dgvReport.RowTemplate.Height = 40
        Me.dgvReport.Size = New System.Drawing.Size(1400, 442)
        Me.dgvReport.TabIndex = 5656
        Me.dgvReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvReport.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvReport.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvReport.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvReport.ThemeStyle.RowsStyle.Height = 40
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnReset)
        Me.Guna2Panel1.Controls.Add(Me.rbItemsDetails)
        Me.Guna2Panel1.Controls.Add(Me.rbInvoicesSummary)
        Me.Guna2Panel1.Controls.Add(Me.Label5)
        Me.Guna2Panel1.Controls.Add(Me.btnEdit)
        Me.Guna2Panel1.Controls.Add(Me.btnSearch)
        Me.Guna2Panel1.Controls.Add(Me.txtSearch)
        Me.Guna2Panel1.Controls.Add(Me.Label6)
        Me.Guna2Panel1.Controls.Add(Me.cmbMaterial)
        Me.Guna2Panel1.Controls.Add(Me.Label16)
        Me.Guna2Panel1.Controls.Add(Me.cmbPaymentType)
        Me.Guna2Panel1.Controls.Add(Me.Label4)
        Me.Guna2Panel1.Controls.Add(Me.cmbStore)
        Me.Guna2Panel1.Controls.Add(Me.Label2)
        Me.Guna2Panel1.Controls.Add(Me.cmbSupplier)
        Me.Guna2Panel1.Controls.Add(Me.dtpTo)
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Controls.Add(Me.dtpFrom)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 70)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1400, 188)
        Me.Guna2Panel1.TabIndex = 5657
        '
        'btnReset
        '
        Me.btnReset.BorderRadius = 6
        Me.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnReset.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(20, 33)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(300, 36)
        Me.btnReset.TabIndex = 5674
        Me.btnReset.Text = "تفريغ الحقول"
        '
        'rbItemsDetails
        '
        Me.rbItemsDetails.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbItemsDetails.CheckedState.BorderThickness = 0
        Me.rbItemsDetails.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbItemsDetails.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbItemsDetails.CheckedState.InnerOffset = -4
        Me.rbItemsDetails.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.rbItemsDetails.Location = New System.Drawing.Point(661, 121)
        Me.rbItemsDetails.Name = "rbItemsDetails"
        Me.rbItemsDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rbItemsDetails.Size = New System.Drawing.Size(120, 36)
        Me.rbItemsDetails.TabIndex = 5673
        Me.rbItemsDetails.Text = "تفاصيل الفواتير"
        Me.rbItemsDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbItemsDetails.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbItemsDetails.UncheckedState.BorderThickness = 2
        Me.rbItemsDetails.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbItemsDetails.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'rbInvoicesSummary
        '
        Me.rbInvoicesSummary.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbInvoicesSummary.CheckedState.BorderThickness = 0
        Me.rbInvoicesSummary.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbInvoicesSummary.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbInvoicesSummary.CheckedState.InnerOffset = -4
        Me.rbInvoicesSummary.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.rbInvoicesSummary.Location = New System.Drawing.Point(797, 121)
        Me.rbInvoicesSummary.Name = "rbInvoicesSummary"
        Me.rbInvoicesSummary.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rbInvoicesSummary.Size = New System.Drawing.Size(104, 36)
        Me.rbInvoicesSummary.TabIndex = 5672
        Me.rbInvoicesSummary.Text = "إجمالي الفواتير"
        Me.rbInvoicesSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbInvoicesSummary.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbInvoicesSummary.UncheckedState.BorderThickness = 2
        Me.rbInvoicesSummary.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbInvoicesSummary.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(907, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 36)
        Me.Label5.TabIndex = 5671
        Me.Label5.Text = "نوع العرض"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btnEdit.Location = New System.Drawing.Point(20, 77)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(300, 36)
        Me.btnEdit.TabIndex = 5670
        Me.btnEdit.Text = "تعديل"
        '
        'btnSearch
        '
        Me.btnSearch.BorderRadius = 6
        Me.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearch.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(20, 121)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(300, 36)
        Me.btnSearch.TabIndex = 5669
        Me.btnSearch.Text = "بحث"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderRadius = 6
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(326, 121)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "بحث عام"
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(329, 36)
        Me.txtSearch.TabIndex = 5668
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(1269, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 36)
        Me.Label6.TabIndex = 5667
        Me.Label6.Text = "الخامة"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMaterial
        '
        Me.cmbMaterial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMaterial.BackColor = System.Drawing.Color.Transparent
        Me.cmbMaterial.BorderRadius = 6
        Me.cmbMaterial.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaterial.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMaterial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMaterial.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMaterial.ForeColor = System.Drawing.Color.Black
        Me.cmbMaterial.ItemHeight = 30
        Me.cmbMaterial.Location = New System.Drawing.Point(1023, 121)
        Me.cmbMaterial.Name = "cmbMaterial"
        Me.cmbMaterial.Size = New System.Drawing.Size(240, 36)
        Me.cmbMaterial.TabIndex = 5666
        Me.cmbMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(549, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 36)
        Me.Label16.TabIndex = 5665
        Me.Label16.Text = "نوع السداد"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPaymentType
        '
        Me.cmbPaymentType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPaymentType.BackColor = System.Drawing.Color.Transparent
        Me.cmbPaymentType.BorderRadius = 6
        Me.cmbPaymentType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbPaymentType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbPaymentType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPaymentType.ForeColor = System.Drawing.Color.Black
        Me.cmbPaymentType.ItemHeight = 30
        Me.cmbPaymentType.Location = New System.Drawing.Point(326, 65)
        Me.cmbPaymentType.Name = "cmbPaymentType"
        Me.cmbPaymentType.Size = New System.Drawing.Size(217, 36)
        Me.cmbPaymentType.TabIndex = 5664
        Me.cmbPaymentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(907, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 36)
        Me.Label4.TabIndex = 5663
        Me.Label4.Text = "المخزن"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbStore
        '
        Me.cmbStore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStore.BackColor = System.Drawing.Color.Transparent
        Me.cmbStore.BorderRadius = 6
        Me.cmbStore.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStore.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbStore.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbStore.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStore.ForeColor = System.Drawing.Color.Black
        Me.cmbStore.ItemHeight = 30
        Me.cmbStore.Location = New System.Drawing.Point(661, 66)
        Me.cmbStore.Name = "cmbStore"
        Me.cmbStore.Size = New System.Drawing.Size(240, 36)
        Me.cmbStore.TabIndex = 5662
        Me.cmbStore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1269, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 36)
        Me.Label2.TabIndex = 5661
        Me.Label2.Text = "المورد"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbSupplier
        '
        Me.cmbSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSupplier.BackColor = System.Drawing.Color.Transparent
        Me.cmbSupplier.BorderRadius = 6
        Me.cmbSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSupplier.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSupplier.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupplier.ForeColor = System.Drawing.Color.Black
        Me.cmbSupplier.ItemHeight = 30
        Me.cmbSupplier.Location = New System.Drawing.Point(1023, 66)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(240, 36)
        Me.cmbSupplier.TabIndex = 5660
        Me.cmbSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpTo
        '
        Me.dtpTo.BorderRadius = 8
        Me.dtpTo.Checked = True
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpTo.Location = New System.Drawing.Point(661, 16)
        Me.dtpTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(240, 36)
        Me.dtpTo.TabIndex = 5659
        Me.dtpTo.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(907, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 36)
        Me.Label3.TabIndex = 5658
        Me.Label3.Text = "تاريخ نهاية"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpFrom
        '
        Me.dtpFrom.BorderRadius = 8
        Me.dtpFrom.Checked = True
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpFrom.Location = New System.Drawing.Point(1023, 16)
        Me.dtpFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(240, 36)
        Me.dtpFrom.TabIndex = 5657
        Me.dtpFrom.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1269, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 36)
        Me.Label1.TabIndex = 5656
        Me.Label1.Text = "تاريخ بداية"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.lblInvoiceCount)
        Me.Guna2Panel2.Controls.Add(Me.Label13)
        Me.Guna2Panel2.Controls.Add(Me.lblTotalRemaining)
        Me.Guna2Panel2.Controls.Add(Me.Label12)
        Me.Guna2Panel2.Controls.Add(Me.lblTotalPaid)
        Me.Guna2Panel2.Controls.Add(Me.Label11)
        Me.Guna2Panel2.Controls.Add(Me.lblNetTotal)
        Me.Guna2Panel2.Controls.Add(Me.Label9)
        Me.Guna2Panel2.Controls.Add(Me.lblTotalDiscount)
        Me.Guna2Panel2.Controls.Add(Me.Label8)
        Me.Guna2Panel2.Controls.Add(Me.lblTotalAmount)
        Me.Guna2Panel2.Controls.Add(Me.Label10)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 700)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1400, 100)
        Me.Guna2Panel2.TabIndex = 5658
        '
        'lblInvoiceCount
        '
        Me.lblInvoiceCount.BackColor = System.Drawing.Color.Transparent
        Me.lblInvoiceCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoiceCount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblInvoiceCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblInvoiceCount.Location = New System.Drawing.Point(412, 55)
        Me.lblInvoiceCount.Name = "lblInvoiceCount"
        Me.lblInvoiceCount.Size = New System.Drawing.Size(154, 36)
        Me.lblInvoiceCount.TabIndex = 5653
        Me.lblInvoiceCount.Text = "0"
        Me.lblInvoiceCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(572, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(169, 36)
        Me.Label13.TabIndex = 5652
        Me.Label13.Text = "عدد الفواتير"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRemaining
        '
        Me.lblTotalRemaining.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalRemaining.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalRemaining.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalRemaining.Location = New System.Drawing.Point(747, 55)
        Me.lblTotalRemaining.Name = "lblTotalRemaining"
        Me.lblTotalRemaining.Size = New System.Drawing.Size(154, 36)
        Me.lblTotalRemaining.TabIndex = 5651
        Me.lblTotalRemaining.Text = "0"
        Me.lblTotalRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(907, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 36)
        Me.Label12.TabIndex = 5650
        Me.Label12.Text = "إجمالي المتبقي"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalPaid.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalPaid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalPaid.Location = New System.Drawing.Point(1052, 55)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.Size = New System.Drawing.Size(154, 36)
        Me.lblTotalPaid.TabIndex = 5649
        Me.lblTotalPaid.Text = "0"
        Me.lblTotalPaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(1212, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(169, 36)
        Me.Label11.TabIndex = 5648
        Me.Label11.Text = "إجمالي المدفوع"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNetTotal
        '
        Me.lblNetTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblNetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNetTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNetTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblNetTotal.Location = New System.Drawing.Point(412, 12)
        Me.lblNetTotal.Name = "lblNetTotal"
        Me.lblNetTotal.Size = New System.Drawing.Size(154, 36)
        Me.lblNetTotal.TabIndex = 5647
        Me.lblNetTotal.Text = "0"
        Me.lblNetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(572, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 36)
        Me.Label9.TabIndex = 5646
        Me.Label9.Text = "إجمالي الفاتورة بعد الخصم"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalDiscount
        '
        Me.lblTotalDiscount.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDiscount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDiscount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalDiscount.Location = New System.Drawing.Point(747, 12)
        Me.lblTotalDiscount.Name = "lblTotalDiscount"
        Me.lblTotalDiscount.Size = New System.Drawing.Size(154, 36)
        Me.lblTotalDiscount.TabIndex = 5645
        Me.lblTotalDiscount.Text = "0"
        Me.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(907, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 36)
        Me.Label8.TabIndex = 5644
        Me.Label8.Text = "إجمالي الخصم"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalAmount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalAmount.Location = New System.Drawing.Point(1052, 12)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(154, 36)
        Me.lblTotalAmount.TabIndex = 5643
        Me.lblTotalAmount.Text = "0"
        Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1212, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(169, 36)
        Me.Label10.TabIndex = 5615
        Me.Label10.Text = "إجمالي المشتريات"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'frmPurchaseReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1400, 800)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPurchaseReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel2.ResumeLayout(False)
        Me.balancesMode = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.balancesMode.Name = "balancesMode"
        Me.balancesMode.Text = "أرصدة الموردين الحالية (كل الفترات)"
        Me.balancesMode.Size = New System.Drawing.Size(300, 38)
        Me.balancesMode.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewPurchase = New Guna.UI2.WinForms.Guna2Button()
        Me.btnViewPurchase.Name = "btnViewPurchase"
        Me.btnViewPurchase.Text = "استعراض الفاتورة"
        Me.btnViewPurchase.Size = New System.Drawing.Size(185, 38)
        Me.btnViewPurchase.BorderRadius = 6
        Me.btnViewPurchase.FillColor = System.Drawing.Color.FromArgb(43, 132, 185)
        Me.btnViewPurchase.ForeColor = System.Drawing.Color.White
        Me.btnViewPurchase.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintReport = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Text = "طباعة التقرير"
        Me.btnPrintReport.Size = New System.Drawing.Size(158, 38)
        Me.btnPrintReport.BorderRadius = 6
        Me.btnPrintReport.FillColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.btnPrintReport.ForeColor = System.Drawing.Color.White
        Me.btnPrintReport.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportReport = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportReport.Name = "btnExportReport"
        Me.btnExportReport.Text = "تصدير Excel"
        Me.btnExportReport.Size = New System.Drawing.Size(158, 38)
        Me.btnExportReport.BorderRadius = 6
        Me.btnExportReport.FillColor = System.Drawing.Color.FromArgb(22, 160, 133)
        Me.btnExportReport.ForeColor = System.Drawing.Color.White
        Me.btnExportReport.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.reportActions = New System.Windows.Forms.FlowLayoutPanel()
        Me.reportActions.Name = "reportActions"
        Me.reportActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.reportActions.Height = 58
        Me.reportActions.Padding = New System.Windows.Forms.Padding(8)
        Me.reportActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.reportActions.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.reportActions.Controls.AddRange(New System.Windows.Forms.Control() {Me.balancesMode, Me.btnViewPurchase, Me.btnPrintReport, Me.btnExportReport})
        Me.Controls.Add(Me.reportActions)
        Me.reportActions.SendToBack()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dgvReport As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents rbItemsDetails As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents rbInvoicesSummary As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSearch As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbMaterial As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbPaymentType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbStore As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbSupplier As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents dtpTo As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFrom As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents lblTotalDiscount As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblNetTotal As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTotalPaid As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblTotalRemaining As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblInvoiceCount As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm

    Friend WithEvents balancesMode As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents btnViewPurchase As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPrintReport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportReport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents reportActions As System.Windows.Forms.FlowLayoutPanel
End Class
