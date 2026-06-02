<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Stock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stock))
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.cmbSearchField = New System.Windows.Forms.ComboBox()
        Me.lblLowStockCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStockID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Pic_Product = New System.Windows.Forms.PictureBox()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_delet = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_edit = New DevExpress.XtraEditors.SimpleButton()
        Me.DisplayStockQuantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtImagePath = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_clear = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_update = New Guna.UI2.WinForms.Guna2Button()
        Me.txtPartner_Name = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtCategoryName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtQty = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtMinQty = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtBaseUnitName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ProductCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Product, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.White
        Me.Guna2Panel1.Controls.Add(Me.Pic_Product)
        Me.Guna2Panel1.Controls.Add(Me.dgvProducts)
        Me.Guna2Panel1.Controls.Add(Me.lstSuggestions)
        Me.Guna2Panel1.Controls.Add(Me.cmbSearchField)
        Me.Guna2Panel1.Controls.Add(Me.lblLowStockCount)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.txtStockID)
        Me.Guna2Panel1.Controls.Add(Me.Label6)
        Me.Guna2Panel1.Controls.Add(Me.panelHeader)
        Me.Guna2Panel1.Controls.Add(Me.btn_delet)
        Me.Guna2Panel1.Controls.Add(Me.btn_edit)
        Me.Guna2Panel1.Controls.Add(Me.DisplayStockQuantity)
        Me.Guna2Panel1.Controls.Add(Me.txtImagePath)
        Me.Guna2Panel1.Controls.Add(Me.btn_clear)
        Me.Guna2Panel1.Controls.Add(Me.btn_update)
        Me.Guna2Panel1.Controls.Add(Me.txtPartner_Name)
        Me.Guna2Panel1.Controls.Add(Me.txtCategoryName)
        Me.Guna2Panel1.Controls.Add(Me.txtQty)
        Me.Guna2Panel1.Controls.Add(Me.txtMinQty)
        Me.Guna2Panel1.Controls.Add(Me.txtBaseUnitName)
        Me.Guna2Panel1.Controls.Add(Me.LabelControl3)
        Me.Guna2Panel1.Controls.Add(Me.txtProductName)
        Me.Guna2Panel1.Controls.Add(Me.LabelControl4)
        Me.Guna2Panel1.Controls.Add(Me.LabelControl2)
        Me.Guna2Panel1.Controls.Add(Me.ProductCode)
        Me.Guna2Panel1.Controls.Add(Me.LabelControl1)
        Me.Guna2Panel1.Controls.Add(Me.txtSearch)
        Me.Guna2Panel1.Controls.Add(Me.LabelControl5)
        Me.Guna2Panel1.Controls.Add(Me.LabelControl6)
        Me.Guna2Panel1.Controls.Add(Me.LabelControl7)
        Me.Guna2Panel1.Controls.Add(Me.LabelControl8)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Panel1.ForeColor = System.Drawing.Color.Black
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1600, 1075)
        Me.Guna2Panel1.TabIndex = 0
        '
        'dgvProducts
        '
        Me.dgvProducts.AllowDrop = True
        Me.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvProducts.Location = New System.Drawing.Point(0, 587)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvProducts.RowTemplate.Height = 40
        Me.dgvProducts.Size = New System.Drawing.Size(1600, 488)
        Me.dgvProducts.TabIndex = 5578
        '
        'lstSuggestions
        '
        Me.lstSuggestions.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lstSuggestions.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 25
        Me.lstSuggestions.Location = New System.Drawing.Point(597, 129)
        Me.lstSuggestions.Margin = New System.Windows.Forms.Padding(5)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.Size = New System.Drawing.Size(522, 154)
        Me.lstSuggestions.TabIndex = 5577
        '
        'cmbSearchField
        '
        Me.cmbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchField.FormattingEnabled = True
        Me.cmbSearchField.Location = New System.Drawing.Point(1127, 81)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(256, 40)
        Me.cmbSearchField.TabIndex = 5576
        '
        'lblLowStockCount
        '
        Me.lblLowStockCount.BackColor = System.Drawing.Color.DarkGray
        Me.lblLowStockCount.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLowStockCount.Location = New System.Drawing.Point(915, 527)
        Me.lblLowStockCount.Name = "lblLowStockCount"
        Me.lblLowStockCount.Size = New System.Drawing.Size(314, 57)
        Me.lblLowStockCount.TabIndex = 5575
        Me.lblLowStockCount.Text = " الغير متوفرة"
        Me.lblLowStockCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1265, 527)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(314, 57)
        Me.Label1.TabIndex = 5574
        Me.Label1.Text = "عدد المنتجات الغير متوفرة"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStockID
        '
        Me.txtStockID.BackColor = System.Drawing.Color.White
        Me.txtStockID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStockID.DefaultText = ""
        Me.txtStockID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtStockID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtStockID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtStockID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtStockID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStockID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockID.ForeColor = System.Drawing.Color.Black
        Me.txtStockID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStockID.Location = New System.Drawing.Point(1393, 78)
        Me.txtStockID.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtStockID.Name = "txtStockID"
        Me.txtStockID.PlaceholderText = ""
        Me.txtStockID.SelectedText = ""
        Me.txtStockID.Size = New System.Drawing.Size(201, 36)
        Me.txtStockID.TabIndex = 5572
        Me.txtStockID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(131, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(164, 37)
        Me.Label6.TabIndex = 5571
        Me.Label6.Text = "صورة المنتج"
        '
        'Pic_Product
        '
        Me.Pic_Product.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pic_Product.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Product.Location = New System.Drawing.Point(13, 126)
        Me.Pic_Product.Name = "Pic_Product"
        Me.Pic_Product.Size = New System.Drawing.Size(420, 320)
        Me.Pic_Product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pic_Product.TabIndex = 5570
        Me.Pic_Product.TabStop = False
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblTime)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1600, 70)
        Me.panelHeader.TabIndex = 145
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblTime.Location = New System.Drawing.Point(644, 4)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTime.Size = New System.Drawing.Size(318, 66)
        Me.lblTime.TabIndex = 7
        Me.lblTime.Text = "المخزون"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        'btn_delet
        '
        Me.btn_delet.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delet.Appearance.Options.UseFont = True
        Me.btn_delet.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources._1486564407_plus_green_81521
        Me.btn_delet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btn_delet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btn_delet.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_delet.Location = New System.Drawing.Point(439, 538)
        Me.btn_delet.Name = "btn_delet"
        Me.btn_delet.Size = New System.Drawing.Size(213, 41)
        Me.btn_delet.TabIndex = 144
        Me.btn_delet.Text = "حذف"
        '
        'btn_edit
        '
        Me.btn_edit.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_edit.Appearance.Options.UseFont = True
        Me.btn_edit.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources._1486564407_plus_green_81521
        Me.btn_edit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btn_edit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btn_edit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_edit.Location = New System.Drawing.Point(673, 538)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(213, 41)
        Me.btn_edit.TabIndex = 143
        Me.btn_edit.Text = "تعديل"
        '
        'DisplayStockQuantity
        '
        Me.DisplayStockQuantity.BackColor = System.Drawing.Color.White
        Me.DisplayStockQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DisplayStockQuantity.DefaultText = ""
        Me.DisplayStockQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.DisplayStockQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.DisplayStockQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.DisplayStockQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.DisplayStockQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DisplayStockQuantity.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayStockQuantity.ForeColor = System.Drawing.Color.Black
        Me.DisplayStockQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DisplayStockQuantity.Location = New System.Drawing.Point(1032, 419)
        Me.DisplayStockQuantity.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.DisplayStockQuantity.Name = "DisplayStockQuantity"
        Me.DisplayStockQuantity.PlaceholderText = ""
        Me.DisplayStockQuantity.ReadOnly = True
        Me.DisplayStockQuantity.SelectedText = ""
        Me.DisplayStockQuantity.Size = New System.Drawing.Size(328, 36)
        Me.DisplayStockQuantity.TabIndex = 141
        Me.DisplayStockQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtImagePath
        '
        Me.txtImagePath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImagePath.DefaultText = ""
        Me.txtImagePath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtImagePath.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtImagePath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtImagePath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtImagePath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtImagePath.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImagePath.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtImagePath.Location = New System.Drawing.Point(59, 399)
        Me.txtImagePath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.PlaceholderText = ""
        Me.txtImagePath.SelectedText = ""
        Me.txtImagePath.Size = New System.Drawing.Size(260, 34)
        Me.txtImagePath.TabIndex = 138
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_clear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_clear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_clear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_clear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_clear.FillColor = System.Drawing.Color.DarkGray
        Me.btn_clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.ForeColor = System.Drawing.Color.Black
        Me.btn_clear.Location = New System.Drawing.Point(15, 521)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(418, 58)
        Me.btn_clear.TabIndex = 135
        Me.btn_clear.Text = "تفريغ الحقول"
        '
        'btn_update
        '
        Me.btn_update.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_update.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_update.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_update.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_update.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_update.FillColor = System.Drawing.Color.DarkKhaki
        Me.btn_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_update.ForeColor = System.Drawing.Color.White
        Me.btn_update.Location = New System.Drawing.Point(439, 76)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(149, 49)
        Me.btn_update.TabIndex = 133
        Me.btn_update.Text = "تحديث البيانات"
        '
        'txtPartner_Name
        '
        Me.txtPartner_Name.BackColor = System.Drawing.Color.White
        Me.txtPartner_Name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPartner_Name.DefaultText = ""
        Me.txtPartner_Name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPartner_Name.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPartner_Name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPartner_Name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPartner_Name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPartner_Name.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartner_Name.ForeColor = System.Drawing.Color.Black
        Me.txtPartner_Name.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPartner_Name.Location = New System.Drawing.Point(444, 479)
        Me.txtPartner_Name.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtPartner_Name.Name = "txtPartner_Name"
        Me.txtPartner_Name.PlaceholderText = ""
        Me.txtPartner_Name.ReadOnly = True
        Me.txtPartner_Name.SelectedText = ""
        Me.txtPartner_Name.Size = New System.Drawing.Size(306, 36)
        Me.txtPartner_Name.TabIndex = 120
        Me.txtPartner_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCategoryName
        '
        Me.txtCategoryName.BackColor = System.Drawing.Color.White
        Me.txtCategoryName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoryName.DefaultText = ""
        Me.txtCategoryName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCategoryName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCategoryName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoryName.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryName.Location = New System.Drawing.Point(444, 420)
        Me.txtCategoryName.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.PlaceholderText = ""
        Me.txtCategoryName.ReadOnly = True
        Me.txtCategoryName.SelectedText = ""
        Me.txtCategoryName.Size = New System.Drawing.Size(306, 36)
        Me.txtCategoryName.TabIndex = 119
        Me.txtCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.Color.White
        Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQty.DefaultText = ""
        Me.txtQty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtQty.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtQty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQty.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.ForeColor = System.Drawing.Color.Black
        Me.txtQty.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQty.Location = New System.Drawing.Point(444, 361)
        Me.txtQty.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.PlaceholderText = ""
        Me.txtQty.SelectedText = ""
        Me.txtQty.Size = New System.Drawing.Size(306, 36)
        Me.txtQty.TabIndex = 118
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMinQty
        '
        Me.txtMinQty.BackColor = System.Drawing.Color.White
        Me.txtMinQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMinQty.DefaultText = ""
        Me.txtMinQty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtMinQty.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtMinQty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMinQty.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMinQty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMinQty.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinQty.ForeColor = System.Drawing.Color.Black
        Me.txtMinQty.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMinQty.Location = New System.Drawing.Point(444, 302)
        Me.txtMinQty.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtMinQty.Name = "txtMinQty"
        Me.txtMinQty.PlaceholderText = ""
        Me.txtMinQty.SelectedText = ""
        Me.txtMinQty.Size = New System.Drawing.Size(306, 36)
        Me.txtMinQty.TabIndex = 117
        Me.txtMinQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBaseUnitName
        '
        Me.txtBaseUnitName.BackColor = System.Drawing.Color.White
        Me.txtBaseUnitName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBaseUnitName.DefaultText = ""
        Me.txtBaseUnitName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBaseUnitName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBaseUnitName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBaseUnitName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBaseUnitName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBaseUnitName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaseUnitName.ForeColor = System.Drawing.Color.Black
        Me.txtBaseUnitName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBaseUnitName.Location = New System.Drawing.Point(1032, 479)
        Me.txtBaseUnitName.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtBaseUnitName.Name = "txtBaseUnitName"
        Me.txtBaseUnitName.PlaceholderText = ""
        Me.txtBaseUnitName.ReadOnly = True
        Me.txtBaseUnitName.SelectedText = ""
        Me.txtBaseUnitName.Size = New System.Drawing.Size(328, 36)
        Me.txtBaseUnitName.TabIndex = 116
        Me.txtBaseUnitName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl3.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl3.Location = New System.Drawing.Point(1369, 479)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(223, 36)
        Me.LabelControl3.TabIndex = 128
        Me.LabelControl3.Text = "الوحدة الأساسية"
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.Color.White
        Me.txtProductName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductName.DefaultText = ""
        Me.txtProductName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtProductName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtProductName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.ForeColor = System.Drawing.Color.Black
        Me.txtProductName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductName.Location = New System.Drawing.Point(1032, 361)
        Me.txtProductName.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.PlaceholderText = ""
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.SelectedText = ""
        Me.txtProductName.Size = New System.Drawing.Size(328, 36)
        Me.txtProductName.TabIndex = 114
        Me.txtProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl4.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl4.Location = New System.Drawing.Point(1369, 420)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(223, 36)
        Me.LabelControl4.TabIndex = 127
        Me.LabelControl4.Text = "المخزون المتوفر"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl2.Location = New System.Drawing.Point(1369, 361)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(223, 36)
        Me.LabelControl2.TabIndex = 126
        Me.LabelControl2.Text = "اسم المنتج"
        '
        'ProductCode
        '
        Me.ProductCode.BackColor = System.Drawing.Color.White
        Me.ProductCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ProductCode.DefaultText = ""
        Me.ProductCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.ProductCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ProductCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ProductCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ProductCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ProductCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductCode.ForeColor = System.Drawing.Color.Black
        Me.ProductCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ProductCode.Location = New System.Drawing.Point(1032, 302)
        Me.ProductCode.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.PlaceholderText = ""
        Me.ProductCode.ReadOnly = True
        Me.ProductCode.SelectedText = ""
        Me.ProductCode.Size = New System.Drawing.Size(328, 36)
        Me.ProductCode.TabIndex = 113
        Me.ProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl1.Location = New System.Drawing.Point(1369, 302)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(223, 36)
        Me.LabelControl1.TabIndex = 125
        Me.LabelControl1.Text = "كود المنتج"
        '
        'txtSearch
        '
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(597, 76)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = ""
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(522, 49)
        Me.txtSearch.TabIndex = 110
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl5.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl5.Location = New System.Drawing.Point(759, 479)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(264, 36)
        Me.LabelControl5.TabIndex = 132
        Me.LabelControl5.Text = "اسم المورد"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl6.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl6.Location = New System.Drawing.Point(759, 420)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(264, 36)
        Me.LabelControl6.TabIndex = 131
        Me.LabelControl6.Text = "القسم"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Appearance.Options.UseForeColor = True
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl7.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl7.Location = New System.Drawing.Point(759, 361)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(264, 36)
        Me.LabelControl7.TabIndex = 130
        Me.LabelControl7.Text = "الإجمالي (أساسية)"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Appearance.Options.UseForeColor = True
        Me.LabelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl8.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl8.Location = New System.Drawing.Point(759, 302)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(264, 36)
        Me.LabelControl8.TabIndex = 129
        Me.LabelControl8.Text = "حد الطلب الادني"
        '
        'Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1600, 1075)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Stock"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Product, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtImagePath As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_clear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_update As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtPartner_Name As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtCategoryName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtQty As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtMinQty As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtBaseUnitName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ProductCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DisplayStockQuantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_delet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_edit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTime As Label
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Pic_Product As PictureBox
    Friend WithEvents txtStockID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblLowStockCount As Label
    Friend WithEvents cmbSearchField As ComboBox
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents dgvProducts As DataGridView
End Class
