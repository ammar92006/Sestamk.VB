<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_new_product
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(add_new_product))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelDeveloper = New System.Windows.Forms.Label()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.btnNewCode = New DevExpress.XtraEditors.SimpleButton()
        Me.lblStatus = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.chkState = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_generate_barcode = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_scan_bar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_AddUnit = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtUnitNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtUnitBarcode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSalePrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPurchasePrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUnitQuantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnitName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dgvUnits = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.ColUnitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUnitQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPurchasePrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSalePrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtProductNote = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_SaveProduct = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Pic_Product = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbVendor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProductName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProductCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_clean = New DevExpress.XtraEditors.SimpleButton()
        Me.lblLang = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Guna2GroupBox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Product, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblLang)
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.pn_title_page)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1600, 65)
        Me.Panel1.TabIndex = 0
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(12, 12)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 5
        '
        'pn_title_page
        '
        Me.pn_title_page.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pn_title_page.AutoSize = True
        Me.pn_title_page.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pn_title_page.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.pn_title_page.Location = New System.Drawing.Point(699, 9)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(254, 46)
        Me.pn_title_page.TabIndex = 4
        Me.pn_title_page.Text = "اضافة منتج جديد"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelDeveloper)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 905)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1600, 65)
        Me.Panel2.TabIndex = 1
        '
        'LabelDeveloper
        '
        Me.LabelDeveloper.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelDeveloper.AutoSize = True
        Me.LabelDeveloper.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.LabelDeveloper.Location = New System.Drawing.Point(583, 11)
        Me.LabelDeveloper.Name = "LabelDeveloper"
        Me.LabelDeveloper.Size = New System.Drawing.Size(529, 39)
        Me.LabelDeveloper.TabIndex = 1
        Me.LabelDeveloper.Text = "تم تصميم هذا البرنامج بواسطة عمار احمد"
        Me.LabelDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.BorderColor = System.Drawing.Color.Black
        Me.Guna2GroupBox1.Controls.Add(Me.btnNewCode)
        Me.Guna2GroupBox1.Controls.Add(Me.lblStatus)
        Me.Guna2GroupBox1.Controls.Add(Me.chkState)
        Me.Guna2GroupBox1.Controls.Add(Me.GroupBox1)
        Me.Guna2GroupBox1.Controls.Add(Me.dgvUnits)
        Me.Guna2GroupBox1.Controls.Add(Me.txtProductNote)
        Me.Guna2GroupBox1.Controls.Add(Me.Label7)
        Me.Guna2GroupBox1.Controls.Add(Me.txtCompanyName)
        Me.Guna2GroupBox1.Controls.Add(Me.btn_SaveProduct)
        Me.Guna2GroupBox1.Controls.Add(Me.btnNew)
        Me.Guna2GroupBox1.Controls.Add(Me.Label6)
        Me.Guna2GroupBox1.Controls.Add(Me.Pic_Product)
        Me.Guna2GroupBox1.Controls.Add(Me.Label5)
        Me.Guna2GroupBox1.Controls.Add(Me.cmbVendor)
        Me.Guna2GroupBox1.Controls.Add(Me.Label4)
        Me.Guna2GroupBox1.Controls.Add(Me.cmbCategory)
        Me.Guna2GroupBox1.Controls.Add(Me.Label3)
        Me.Guna2GroupBox1.Controls.Add(Me.Label2)
        Me.Guna2GroupBox1.Controls.Add(Me.txtProductName)
        Me.Guna2GroupBox1.Controls.Add(Me.Label1)
        Me.Guna2GroupBox1.Controls.Add(Me.txtProductCode)
        Me.Guna2GroupBox1.Controls.Add(Me.btn_clean)
        Me.Guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(0, 65)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(1600, 840)
        Me.Guna2GroupBox1.TabIndex = 2
        Me.Guna2GroupBox1.Text = "بيانات المنتج"
        Me.Guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnNewCode
        '
        Me.btnNewCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewCode.ImageOptions.SvgImage = CType(resources.GetObject("btnNewCode.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnNewCode.Location = New System.Drawing.Point(967, 53)
        Me.btnNewCode.Name = "btnNewCode"
        Me.btnNewCode.Size = New System.Drawing.Size(40, 45)
        Me.btnNewCode.TabIndex = 5571
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = False
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(12, 329)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(222, 45)
        Me.lblStatus.TabIndex = 5570
        Me.lblStatus.Text = "نشط / غير نشط"
        Me.lblStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkState
        '
        Me.chkState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkState.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkState.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkState.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkState.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkState.Location = New System.Drawing.Point(240, 329)
        Me.chkState.Name = "chkState"
        Me.chkState.Size = New System.Drawing.Size(93, 44)
        Me.chkState.TabIndex = 5569
        Me.chkState.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkState.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkState.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkState.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_generate_barcode)
        Me.GroupBox1.Controls.Add(Me.btn_scan_bar)
        Me.GroupBox1.Controls.Add(Me.btn_AddUnit)
        Me.GroupBox1.Controls.Add(Me.Guna2HtmlLabel9)
        Me.GroupBox1.Controls.Add(Me.txtUnitNotes)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtUnitBarcode)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtSalePrice)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtPurchasePrice)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtUnitQuantity)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtUnitName)
        Me.GroupBox1.Location = New System.Drawing.Point(365, 271)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1223, 290)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات الوحدات والاسعار"
        '
        'btn_generate_barcode
        '
        Me.btn_generate_barcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_generate_barcode.ImageOptions.SvgImage = CType(resources.GetObject("btn_generate_barcode.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_generate_barcode.Location = New System.Drawing.Point(135, 52)
        Me.btn_generate_barcode.Name = "btn_generate_barcode"
        Me.btn_generate_barcode.Size = New System.Drawing.Size(40, 51)
        Me.btn_generate_barcode.TabIndex = 122
        '
        'btn_scan_bar
        '
        Me.btn_scan_bar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_scan_bar.ImageOptions.SvgImage = CType(resources.GetObject("btn_scan_bar.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_scan_bar.Location = New System.Drawing.Point(181, 51)
        Me.btn_scan_bar.Name = "btn_scan_bar"
        Me.btn_scan_bar.Size = New System.Drawing.Size(40, 51)
        Me.btn_scan_bar.TabIndex = 121
        '
        'btn_AddUnit
        '
        Me.btn_AddUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AddUnit.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AddUnit.Appearance.Options.UseFont = True
        Me.btn_AddUnit.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_to_cart
        Me.btn_AddUnit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btn_AddUnit.Location = New System.Drawing.Point(7, 51)
        Me.btn_AddUnit.Name = "btn_AddUnit"
        Me.btn_AddUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_AddUnit.Size = New System.Drawing.Size(122, 230)
        Me.btn_AddUnit.TabIndex = 120
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel9.AutoSize = False
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(504, 114)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(206, 36)
        Me.Guna2HtmlLabel9.TabIndex = 119
        Me.Guna2HtmlLabel9.Text = "الملاحظات"
        Me.Guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtUnitNotes
        '
        Me.txtUnitNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnitNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnitNotes.DefaultText = ""
        Me.txtUnitNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUnitNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUnitNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitNotes.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUnitNotes.ForeColor = System.Drawing.Color.Black
        Me.txtUnitNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitNotes.Location = New System.Drawing.Point(138, 159)
        Me.txtUnitNotes.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUnitNotes.Multiline = True
        Me.txtUnitNotes.Name = "txtUnitNotes"
        Me.txtUnitNotes.PlaceholderText = ""
        Me.txtUnitNotes.SelectedText = ""
        Me.txtUnitNotes.Size = New System.Drawing.Size(572, 113)
        Me.txtUnitNotes.TabIndex = 118
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(534, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(179, 41)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "الباركود"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtUnitBarcode
        '
        Me.txtUnitBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnitBarcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnitBarcode.DefaultText = ""
        Me.txtUnitBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUnitBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUnitBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitBarcode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUnitBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtUnitBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitBarcode.Location = New System.Drawing.Point(230, 51)
        Me.txtUnitBarcode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUnitBarcode.Name = "txtUnitBarcode"
        Me.txtUnitBarcode.PlaceholderText = ""
        Me.txtUnitBarcode.SelectedText = ""
        Me.txtUnitBarcode.Size = New System.Drawing.Size(299, 45)
        Me.txtUnitBarcode.TabIndex = 116
        Me.txtUnitBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(958, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(259, 41)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "سعر البيع"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
        Me.txtSalePrice.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtSalePrice.ForeColor = System.Drawing.Color.Black
        Me.txtSalePrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSalePrice.Location = New System.Drawing.Point(722, 224)
        Me.txtSalePrice.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSalePrice.Name = "txtSalePrice"
        Me.txtSalePrice.PlaceholderText = ""
        Me.txtSalePrice.SelectedText = ""
        Me.txtSalePrice.Size = New System.Drawing.Size(227, 45)
        Me.txtSalePrice.TabIndex = 114
        Me.txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(958, 163)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(259, 41)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "سعر الشراء"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtPurchasePrice
        '
        Me.txtPurchasePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPurchasePrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPurchasePrice.DefaultText = ""
        Me.txtPurchasePrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPurchasePrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPurchasePrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPurchasePrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPurchasePrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPurchasePrice.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtPurchasePrice.ForeColor = System.Drawing.Color.Black
        Me.txtPurchasePrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPurchasePrice.Location = New System.Drawing.Point(722, 159)
        Me.txtPurchasePrice.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPurchasePrice.Name = "txtPurchasePrice"
        Me.txtPurchasePrice.PlaceholderText = ""
        Me.txtPurchasePrice.SelectedText = ""
        Me.txtPurchasePrice.Size = New System.Drawing.Size(227, 45)
        Me.txtPurchasePrice.TabIndex = 112
        Me.txtPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(958, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(259, 41)
        Me.Label9.TabIndex = 111
        Me.Label9.Text = "عدد الوحدات التي داخلها"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtUnitQuantity
        '
        Me.txtUnitQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnitQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnitQuantity.DefaultText = ""
        Me.txtUnitQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUnitQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUnitQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitQuantity.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUnitQuantity.ForeColor = System.Drawing.Color.Black
        Me.txtUnitQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitQuantity.Location = New System.Drawing.Point(722, 102)
        Me.txtUnitQuantity.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUnitQuantity.Name = "txtUnitQuantity"
        Me.txtUnitQuantity.PlaceholderText = ""
        Me.txtUnitQuantity.SelectedText = ""
        Me.txtUnitQuantity.Size = New System.Drawing.Size(227, 45)
        Me.txtUnitQuantity.TabIndex = 110
        Me.txtUnitQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(958, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(259, 41)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "اسم الوحدة"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtUnitName
        '
        Me.txtUnitName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnitName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnitName.DefaultText = ""
        Me.txtUnitName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUnitName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUnitName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUnitName.ForeColor = System.Drawing.Color.Black
        Me.txtUnitName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitName.Location = New System.Drawing.Point(722, 51)
        Me.txtUnitName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUnitName.Name = "txtUnitName"
        Me.txtUnitName.PlaceholderText = ""
        Me.txtUnitName.SelectedText = ""
        Me.txtUnitName.Size = New System.Drawing.Size(227, 45)
        Me.txtUnitName.TabIndex = 108
        Me.txtUnitName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvUnits
        '
        Me.dgvUnits.AllowUserToAddRows = False
        Me.dgvUnits.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvUnits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvUnits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUnits.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUnits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvUnits.ColumnHeadersHeight = 4
        Me.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvUnits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColUnitName, Me.ColUnitQuantity, Me.ColBarcode, Me.ColPurchasePrice, Me.ColSalePrice, Me.ColNotes, Me.ColDelete})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUnits.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvUnits.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvUnits.Location = New System.Drawing.Point(12, 567)
        Me.dgvUnits.Name = "dgvUnits"
        '
        'ColUnitName
        '
        Me.ColUnitName.HeaderText = "اسم الوحدة"
        Me.ColUnitName.Name = "ColUnitName"
        Me.ColUnitName.ReadOnly = True
        '
        'ColUnitQuantity
        '
        Me.ColUnitQuantity.HeaderText = "كمية الوحدة"
        Me.ColUnitQuantity.Name = "ColUnitQuantity"
        Me.ColUnitQuantity.ReadOnly = True
        '
        'ColBarcode
        '
        Me.ColBarcode.HeaderText = "الباركود"
        Me.ColBarcode.Name = "ColBarcode"
        Me.ColBarcode.ReadOnly = True
        '
        'ColPurchasePrice
        '
        Me.ColPurchasePrice.HeaderText = "سعر الشراء"
        Me.ColPurchasePrice.Name = "ColPurchasePrice"
        Me.ColPurchasePrice.ReadOnly = True
        '
        'ColSalePrice
        '
        Me.ColSalePrice.HeaderText = "سعر البيع"
        Me.ColSalePrice.Name = "ColSalePrice"
        Me.ColSalePrice.ReadOnly = True
        '
        'ColNotes
        '
        Me.ColNotes.HeaderText = "ملاحظات"
        Me.ColNotes.Name = "ColNotes"
        Me.ColNotes.ReadOnly = True
        '
        'ColDelete
        '
        Me.ColDelete.FillWeight = 40.0!
        Me.ColDelete.HeaderText = "حذف"
        Me.ColDelete.Name = "ColDelete"
        Me.ColDelete.ReadOnly = True
        Me.ColDelete.Text = "❌"
        Me.ColDelete.UseColumnTextForButtonValue = True
        Me.dgvUnits.ReadOnly = True
        Me.dgvUnits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvUnits.RowHeadersVisible = False
        Me.dgvUnits.RowTemplate.Height = 40
        Me.dgvUnits.Size = New System.Drawing.Size(1576, 260)
        Me.dgvUnits.TabIndex = 78
        Me.dgvUnits.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvUnits.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvUnits.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvUnits.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvUnits.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvUnits.ThemeStyle.BackColor = System.Drawing.Color.Silver
        Me.dgvUnits.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvUnits.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvUnits.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvUnits.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvUnits.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvUnits.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvUnits.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvUnits.ThemeStyle.ReadOnly = True
        Me.dgvUnits.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvUnits.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvUnits.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvUnits.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvUnits.ThemeStyle.RowsStyle.Height = 40
        Me.dgvUnits.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvUnits.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'txtProductNote
        '
        Me.txtProductNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductNote.BorderColor = System.Drawing.Color.Black
        Me.txtProductNote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductNote.DefaultText = ""
        Me.txtProductNote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtProductNote.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtProductNote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductNote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductNote.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtProductNote.ForeColor = System.Drawing.Color.Black
        Me.txtProductNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductNote.Location = New System.Drawing.Point(365, 210)
        Me.txtProductNote.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtProductNote.Name = "txtProductNote"
        Me.txtProductNote.PlaceholderText = ""
        Me.txtProductNote.SelectedText = ""
        Me.txtProductNote.Size = New System.Drawing.Size(434, 45)
        Me.txtProductNote.TabIndex = 77
        Me.txtProductNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(808, 214)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 41)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "الملاحظات"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCompanyName.BorderColor = System.Drawing.Color.Black
        Me.txtCompanyName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCompanyName.DefaultText = ""
        Me.txtCompanyName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCompanyName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCompanyName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCompanyName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCompanyName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCompanyName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCompanyName.ForeColor = System.Drawing.Color.Black
        Me.txtCompanyName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCompanyName.Location = New System.Drawing.Point(365, 133)
        Me.txtCompanyName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.PlaceholderText = ""
        Me.txtCompanyName.ReadOnly = True
        Me.txtCompanyName.SelectedText = ""
        Me.txtCompanyName.Size = New System.Drawing.Size(434, 45)
        Me.txtCompanyName.TabIndex = 75
        Me.txtCompanyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_SaveProduct
        '
        Me.btn_SaveProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_SaveProduct.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SaveProduct.Appearance.Options.UseFont = True
        Me.btn_SaveProduct.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btn_SaveProduct.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btn_SaveProduct.Location = New System.Drawing.Point(12, 486)
        Me.btn_SaveProduct.Name = "btn_SaveProduct"
        Me.btn_SaveProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_SaveProduct.Size = New System.Drawing.Size(329, 75)
        Me.btn_SaveProduct.TabIndex = 74
        Me.btn_SaveProduct.Text = "اضافة المنتج (F2)"
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Appearance.Options.UseFont = True
        Me.btnNew.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btnNew.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnNew.Location = New System.Drawing.Point(12, 400)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnNew.Size = New System.Drawing.Size(329, 75)
        Me.btnNew.TabIndex = 73
        Me.btnNew.Text = "تحديد موقع الصورة"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(76, -4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 41)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "صورة المنتج"
        '
        'Pic_Product
        '
        Me.Pic_Product.BackColor = System.Drawing.Color.Transparent
        Me.Pic_Product.Image = Global.WindowsApp1.My.Resources.Resources.لا_يوجد_صورة_للمنتج
        Me.Pic_Product.Location = New System.Drawing.Point(10, 46)
        Me.Pic_Product.Name = "Pic_Product"
        Me.Pic_Product.Size = New System.Drawing.Size(329, 272)
        Me.Pic_Product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Product.TabIndex = 71
        Me.Pic_Product.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(804, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 41)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "اسم الشركة"
        '
        'cmbVendor
        '
        Me.cmbVendor.DropDownHeight = 200
        Me.cmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendor.FormattingEnabled = True
        Me.cmbVendor.IntegralHeight = False
        Me.cmbVendor.Location = New System.Drawing.Point(365, 53)
        Me.cmbVendor.MaxLength = 20
        Me.cmbVendor.Name = "cmbVendor"
        Me.cmbVendor.Size = New System.Drawing.Size(434, 48)
        Me.cmbVendor.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(836, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 41)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "المورد"
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownHeight = 200
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.IntegralHeight = False
        Me.cmbCategory.Location = New System.Drawing.Point(978, 207)
        Me.cmbCategory.MaxLength = 20
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(414, 48)
        Me.cmbCategory.TabIndex = 67
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(1413, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 41)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "القسم"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(1401, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 41)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "اسم المنتج"
        '
        'txtProductName
        '
        Me.txtProductName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductName.BorderColor = System.Drawing.Color.Black
        Me.txtProductName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductName.DefaultText = ""
        Me.txtProductName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtProductName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtProductName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtProductName.ForeColor = System.Drawing.Color.Black
        Me.txtProductName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductName.Location = New System.Drawing.Point(978, 130)
        Me.txtProductName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.PlaceholderText = ""
        Me.txtProductName.SelectedText = ""
        Me.txtProductName.Size = New System.Drawing.Size(414, 45)
        Me.txtProductName.TabIndex = 64
        Me.txtProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(1404, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 41)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "كود المنتج"
        '
        'txtProductCode
        '
        Me.txtProductCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductCode.BorderColor = System.Drawing.Color.Black
        Me.txtProductCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductCode.DefaultText = ""
        Me.txtProductCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtProductCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtProductCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtProductCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtProductCode.ForeColor = System.Drawing.Color.Black
        Me.txtProductCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtProductCode.Location = New System.Drawing.Point(1011, 53)
        Me.txtProductCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.PlaceholderText = ""
        Me.txtProductCode.SelectedText = ""
        Me.txtProductCode.Size = New System.Drawing.Size(381, 45)
        Me.txtProductCode.TabIndex = 62
        Me.txtProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_clean
        '
        Me.btn_clean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_clean.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clean.Appearance.Options.UseFont = True
        Me.btn_clean.AutoSize = True
        Me.btn_clean.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.eraser
        Me.btn_clean.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_clean.Location = New System.Drawing.Point(1391, 2)
        Me.btn_clean.Name = "btn_clean"
        Me.btn_clean.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_clean.Size = New System.Drawing.Size(38, 36)
        Me.btn_clean.TabIndex = 44
        '
        'lblLang
        '
        Me.lblLang.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblLang.Location = New System.Drawing.Point(449, 14)
        Me.lblLang.Name = "lblLang"
        Me.lblLang.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLang.Size = New System.Drawing.Size(137, 43)
        Me.lblLang.TabIndex = 11
        Me.lblLang.Text = "عربي"
        Me.lblLang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'add_new_product
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1600, 970)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "add_new_product"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة منتج جديد"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Guna2GroupBox1.ResumeLayout(False)
        Me.Guna2GroupBox1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvUnits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Product, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents pn_title_page As Label
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelDeveloper As Label
    Friend WithEvents btn_clean As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtProductNote As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCompanyName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_SaveProduct As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Pic_Product As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbVendor As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtProductName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProductCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvUnits As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents ColUnitName As DataGridViewTextBoxColumn
    Friend WithEvents ColUnitQuantity As DataGridViewTextBoxColumn
    Friend WithEvents ColBarcode As DataGridViewTextBoxColumn
    Friend WithEvents ColPurchasePrice As DataGridViewTextBoxColumn
    Friend WithEvents ColSalePrice As DataGridViewTextBoxColumn
    Friend WithEvents ColNotes As DataGridViewTextBoxColumn
    Friend WithEvents ColDelete As DataGridViewButtonColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_generate_barcode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_scan_bar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_AddUnit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtUnitNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtUnitBarcode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSalePrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPurchasePrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtUnitQuantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtUnitName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblStatus As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents chkState As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents btnNewCode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblLang As Label
End Class
