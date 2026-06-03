<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Purchases
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Purchases))
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_user_name = New System.Windows.Forms.Label()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_add_new_product = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSaveInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Guna2ToggleSwitch1 = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.btn_auto_pay = New System.Windows.Forms.Button()
        Me.cmbVendor = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txt_Invoice_ID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_add_product = New DevExpress.XtraEditors.SimpleButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_totelProduct = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lstCodeSuggestions = New System.Windows.Forms.ListBox()
        Me.lstNameSuggestions = New System.Windows.Forms.ListBox()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.cmb_Pay = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtQuantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbUnit = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProductCodeSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_purchase_price = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtProductNameSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtRemaining = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblRemaining = New System.Windows.Forms.Label()
        Me.txtPaid = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.txtTotalAfterDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalRequired = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSelectImage = New DevExpress.XtraEditors.SimpleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pic_purchases = New System.Windows.Forms.PictureBox()
        Me.txt_notes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_clean = New DevExpress.XtraEditors.SimpleButton()
        Me.dgv_Purchases = New System.Windows.Forms.DataGridView()
        Me.panelHeader.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        CType(Me.pic_purchases, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Purchases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.Label7)
        Me.panelHeader.Controls.Add(Me.lbl_user_name)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1600, 70)
        Me.panelHeader.TabIndex = 71
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(464, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(199, 53)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "اسم المستخدم"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_user_name
        '
        Me.lbl_user_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user_name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lbl_user_name.Location = New System.Drawing.Point(205, 9)
        Me.lbl_user_name.Name = "lbl_user_name"
        Me.lbl_user_name.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_user_name.Size = New System.Drawing.Size(242, 53)
        Me.lbl_user_name.TabIndex = 10
        Me.lbl_user_name.Text = "Time Now"
        Me.lbl_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(751, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(137, 44)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "المشتريات"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_add_new_product)
        Me.PanelControl1.Controls.Add(Me.btnDelete)
        Me.PanelControl1.Controls.Add(Me.btnEdit)
        Me.PanelControl1.Controls.Add(Me.btnSaveInvoice)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 70)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1600, 88)
        Me.PanelControl1.TabIndex = 74
        '
        'btn_add_new_product
        '
        Me.btn_add_new_product.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_add_new_product.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_new_product.Appearance.Options.UseFont = True
        Me.btn_add_new_product.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btn_add_new_product.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btn_add_new_product.Location = New System.Drawing.Point(10, 5)
        Me.btn_add_new_product.Name = "btn_add_new_product"
        Me.btn_add_new_product.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_add_new_product.Size = New System.Drawing.Size(403, 75)
        Me.btn_add_new_product.TabIndex = 3
        Me.btn_add_new_product.Text = "اضافة منتج جديد ()"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.user__1_1
        Me.btnDelete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnDelete.Location = New System.Drawing.Point(430, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnDelete.Size = New System.Drawing.Size(348, 75)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف الفاتورة (F4)"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Appearance.Options.UseFont = True
        Me.btnEdit.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.user1
        Me.btnEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnEdit.Location = New System.Drawing.Point(800, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnEdit.Size = New System.Drawing.Size(385, 75)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "مرتجعات الشراء"
        '
        'btnSaveInvoice
        '
        Me.btnSaveInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveInvoice.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveInvoice.Appearance.Options.UseFont = True
        Me.btnSaveInvoice.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btnSaveInvoice.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnSaveInvoice.Location = New System.Drawing.Point(1190, 5)
        Me.btnSaveInvoice.Name = "btnSaveInvoice"
        Me.btnSaveInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSaveInvoice.Size = New System.Drawing.Size(403, 75)
        Me.btnSaveInvoice.TabIndex = 0
        Me.btnSaveInvoice.Text = "اضافة فاتورة مشتريات (F2)"
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.Label8)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2ToggleSwitch1)
        Me.grpCustomerInfo.Controls.Add(Me.btn_auto_pay)
        Me.grpCustomerInfo.Controls.Add(Me.cmbVendor)
        Me.grpCustomerInfo.Controls.Add(Me.DateTimePicker1)
        Me.grpCustomerInfo.Controls.Add(Me.txt_Invoice_ID)
        Me.grpCustomerInfo.Controls.Add(Me.Label15)
        Me.grpCustomerInfo.Controls.Add(Me.btn_add_product)
        Me.grpCustomerInfo.Controls.Add(Me.Label16)
        Me.grpCustomerInfo.Controls.Add(Me.txt_totelProduct)
        Me.grpCustomerInfo.Controls.Add(Me.lstCodeSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.lstNameSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel9)
        Me.grpCustomerInfo.Controls.Add(Me.cmb_Pay)
        Me.grpCustomerInfo.Controls.Add(Me.Label14)
        Me.grpCustomerInfo.Controls.Add(Me.Label13)
        Me.grpCustomerInfo.Controls.Add(Me.txtQuantity)
        Me.grpCustomerInfo.Controls.Add(Me.Label12)
        Me.grpCustomerInfo.Controls.Add(Me.Label11)
        Me.grpCustomerInfo.Controls.Add(Me.cmbUnit)
        Me.grpCustomerInfo.Controls.Add(Me.Label10)
        Me.grpCustomerInfo.Controls.Add(Me.txtProductCodeSearch)
        Me.grpCustomerInfo.Controls.Add(Me.Label9)
        Me.grpCustomerInfo.Controls.Add(Me.txt_purchase_price)
        Me.grpCustomerInfo.Controls.Add(Me.txtProductNameSearch)
        Me.grpCustomerInfo.Controls.Add(Me.txtRemaining)
        Me.grpCustomerInfo.Controls.Add(Me.lblRemaining)
        Me.grpCustomerInfo.Controls.Add(Me.txtPaid)
        Me.grpCustomerInfo.Controls.Add(Me.lblPaid)
        Me.grpCustomerInfo.Controls.Add(Me.txtTotalAfterDiscount)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.txtDiscount)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.txtTotalRequired)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.btnSelectImage)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.pic_purchases)
        Me.grpCustomerInfo.Controls.Add(Me.txt_notes)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.btn_clean)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 158)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1600, 548)
        Me.grpCustomerInfo.TabIndex = 75
        Me.grpCustomerInfo.Text = "بيانات الفاتورة"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(398, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 33)
        Me.Label8.TabIndex = 5635
        Me.Label8.Text = "حفظ تلقائيا"
        '
        'Guna2ToggleSwitch1
        '
        Me.Guna2ToggleSwitch1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ToggleSwitch1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.Location = New System.Drawing.Point(530, 3)
        Me.Guna2ToggleSwitch1.Name = "Guna2ToggleSwitch1"
        Me.Guna2ToggleSwitch1.Size = New System.Drawing.Size(78, 32)
        Me.Guna2ToggleSwitch1.TabIndex = 5634
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
        Me.btn_auto_pay.Location = New System.Drawing.Point(322, 97)
        Me.btn_auto_pay.Name = "btn_auto_pay"
        Me.btn_auto_pay.Size = New System.Drawing.Size(90, 45)
        Me.btn_auto_pay.TabIndex = 5632
        Me.btn_auto_pay.Text = "OK"
        Me.btn_auto_pay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_auto_pay.UseVisualStyleBackColor = True
        '
        'cmbVendor
        '
        Me.cmbVendor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendor.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendor.FormattingEnabled = True
        Me.cmbVendor.ItemHeight = 24
        Me.cmbVendor.Location = New System.Drawing.Point(919, 107)
        Me.cmbVendor.MaxLength = 10
        Me.cmbVendor.Name = "cmbVendor"
        Me.cmbVendor.Size = New System.Drawing.Size(412, 32)
        Me.cmbVendor.TabIndex = 5626
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(919, 47)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(414, 40)
        Me.DateTimePicker1.TabIndex = 5625
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
        Me.txt_Invoice_ID.Location = New System.Drawing.Point(649, 1)
        Me.txt_Invoice_ID.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Invoice_ID.Name = "txt_Invoice_ID"
        Me.txt_Invoice_ID.PlaceholderText = ""
        Me.txt_Invoice_ID.ReadOnly = True
        Me.txt_Invoice_ID.SelectedText = ""
        Me.txt_Invoice_ID.Size = New System.Drawing.Size(215, 35)
        Me.txt_Invoice_ID.TabIndex = 5624
        Me.txt_Invoice_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(873, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(199, 35)
        Me.Label15.TabIndex = 5623
        Me.Label15.Text = "رقم الفاتورة"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_add_product
        '
        Me.btn_add_product.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_add_product.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_product.Appearance.Options.UseFont = True
        Me.btn_add_product.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.queue__2_
        Me.btn_add_product.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_add_product.Location = New System.Drawing.Point(3, 384)
        Me.btn_add_product.Name = "btn_add_product"
        Me.btn_add_product.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_add_product.Size = New System.Drawing.Size(159, 150)
        Me.btn_add_product.TabIndex = 5622
        Me.btn_add_product.Text = "اضافة"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(170, 349)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 29)
        Me.Label16.TabIndex = 5621
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
        Me.txt_totelProduct.Location = New System.Drawing.Point(170, 384)
        Me.txt_totelProduct.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_totelProduct.Name = "txt_totelProduct"
        Me.txt_totelProduct.PlaceholderText = ""
        Me.txt_totelProduct.ReadOnly = True
        Me.txt_totelProduct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_totelProduct.SelectedText = ""
        Me.txt_totelProduct.Size = New System.Drawing.Size(156, 49)
        Me.txt_totelProduct.TabIndex = 5620
        Me.txt_totelProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstCodeSuggestions
        '
        Me.lstCodeSuggestions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCodeSuggestions.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCodeSuggestions.FormattingEnabled = True
        Me.lstCodeSuggestions.ItemHeight = 25
        Me.lstCodeSuggestions.Location = New System.Drawing.Point(1349, 435)
        Me.lstCodeSuggestions.Name = "lstCodeSuggestions"
        Me.lstCodeSuggestions.Size = New System.Drawing.Size(243, 104)
        Me.lstCodeSuggestions.TabIndex = 5619
        '
        'lstNameSuggestions
        '
        Me.lstNameSuggestions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstNameSuggestions.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNameSuggestions.FormattingEnabled = True
        Me.lstNameSuggestions.ItemHeight = 25
        Me.lstNameSuggestions.Location = New System.Drawing.Point(815, 435)
        Me.lstNameSuggestions.Name = "lstNameSuggestions"
        Me.lstNameSuggestions.Size = New System.Drawing.Size(522, 104)
        Me.lstNameSuggestions.TabIndex = 5618
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel9.AutoSize = False
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(672, 215)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(206, 28)
        Me.Guna2HtmlLabel9.TabIndex = 5617
        Me.Guna2HtmlLabel9.Text = "الملاحظات"
        Me.Guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.BottomRight
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
        Me.cmb_Pay.Location = New System.Drawing.Point(324, 47)
        Me.cmb_Pay.Name = "cmb_Pay"
        Me.cmb_Pay.Size = New System.Drawing.Size(385, 36)
        Me.cmb_Pay.TabIndex = 5601
        Me.cmb_Pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(705, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(189, 36)
        Me.Label14.TabIndex = 5600
        Me.Label14.Text = "طريقة الدفع"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(330, 349)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(164, 29)
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
        Me.txtQuantity.Location = New System.Drawing.Point(330, 384)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.PlaceholderText = "ادخل سعر الكمية"
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
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(498, 349)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(164, 29)
        Me.Label12.TabIndex = 5592
        Me.Label12.Text = "سعر الشراء"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(672, 349)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 29)
        Me.Label11.TabIndex = 5591
        Me.Label11.Text = "الواحدات"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmbUnit
        '
        Me.cmbUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUnit.BackColor = System.Drawing.Color.Transparent
        Me.cmbUnit.BorderRadius = 2
        Me.cmbUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnit.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbUnit.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.cmbUnit.ForeColor = System.Drawing.Color.Black
        Me.cmbUnit.ItemHeight = 30
        Me.cmbUnit.Location = New System.Drawing.Point(666, 384)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(140, 36)
        Me.cmbUnit.TabIndex = 5590
        Me.cmbUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1349, 349)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(243, 29)
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
        Me.txtProductCodeSearch.Location = New System.Drawing.Point(1349, 384)
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
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(815, 349)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(522, 29)
        Me.Label9.TabIndex = 5587
        Me.Label9.Text = "اسم المنتج"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txt_purchase_price
        '
        Me.txt_purchase_price.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_purchase_price.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_purchase_price.DefaultText = ""
        Me.txt_purchase_price.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_purchase_price.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_purchase_price.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_purchase_price.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_purchase_price.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_purchase_price.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_purchase_price.ForeColor = System.Drawing.Color.Black
        Me.txt_purchase_price.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_purchase_price.Location = New System.Drawing.Point(498, 384)
        Me.txt_purchase_price.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_purchase_price.Name = "txt_purchase_price"
        Me.txt_purchase_price.PlaceholderText = ""
        Me.txt_purchase_price.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_purchase_price.SelectedText = ""
        Me.txt_purchase_price.Size = New System.Drawing.Size(164, 49)
        Me.txt_purchase_price.TabIndex = 5586
        Me.txt_purchase_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtProductNameSearch.Location = New System.Drawing.Point(815, 384)
        Me.txtProductNameSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtProductNameSearch.Name = "txtProductNameSearch"
        Me.txtProductNameSearch.PlaceholderText = "ابحث عن المنتج"
        Me.txtProductNameSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtProductNameSearch.SelectedText = ""
        Me.txtProductNameSearch.Size = New System.Drawing.Size(522, 49)
        Me.txtProductNameSearch.TabIndex = 5585
        Me.txtProductNameSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtRemaining.Location = New System.Drawing.Point(322, 161)
        Me.txtRemaining.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtRemaining.Name = "txtRemaining"
        Me.txtRemaining.PlaceholderText = ""
        Me.txtRemaining.ReadOnly = True
        Me.txtRemaining.SelectedText = ""
        Me.txtRemaining.Size = New System.Drawing.Size(414, 45)
        Me.txtRemaining.TabIndex = 5584
        Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRemaining
        '
        Me.lblRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemaining.BackColor = System.Drawing.Color.Transparent
        Me.lblRemaining.Location = New System.Drawing.Point(745, 165)
        Me.lblRemaining.Name = "lblRemaining"
        Me.lblRemaining.Size = New System.Drawing.Size(134, 36)
        Me.lblRemaining.TabIndex = 5583
        Me.lblRemaining.Text = "المتبقي"
        Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtPaid.Location = New System.Drawing.Point(414, 97)
        Me.txtPaid.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.PlaceholderText = ""
        Me.txtPaid.SelectedText = ""
        Me.txtPaid.Size = New System.Drawing.Size(322, 45)
        Me.txtPaid.TabIndex = 5582
        Me.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPaid
        '
        Me.lblPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPaid.BackColor = System.Drawing.Color.Transparent
        Me.lblPaid.Location = New System.Drawing.Point(745, 101)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(134, 36)
        Me.lblPaid.TabIndex = 5581
        Me.lblPaid.Text = "المدفوع"
        Me.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtTotalAfterDiscount.Location = New System.Drawing.Point(919, 293)
        Me.txtTotalAfterDiscount.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTotalAfterDiscount.Name = "txtTotalAfterDiscount"
        Me.txtTotalAfterDiscount.PlaceholderText = ""
        Me.txtTotalAfterDiscount.ReadOnly = True
        Me.txtTotalAfterDiscount.SelectedText = ""
        Me.txtTotalAfterDiscount.Size = New System.Drawing.Size(414, 45)
        Me.txtTotalAfterDiscount.TabIndex = 5580
        Me.txtTotalAfterDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(1342, 303)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(257, 36)
        Me.Label4.TabIndex = 5579
        Me.Label4.Text = "الاجمالي بعد الخصم"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtDiscount.Location = New System.Drawing.Point(919, 227)
        Me.txtDiscount.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.PlaceholderText = ""
        Me.txtDiscount.SelectedText = ""
        Me.txtDiscount.Size = New System.Drawing.Size(414, 45)
        Me.txtDiscount.TabIndex = 5578
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(1342, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(257, 36)
        Me.Label3.TabIndex = 5577
        Me.Label3.Text = "الخصم"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtTotalRequired.Location = New System.Drawing.Point(919, 161)
        Me.txtTotalRequired.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTotalRequired.Name = "txtTotalRequired"
        Me.txtTotalRequired.PlaceholderText = ""
        Me.txtTotalRequired.ReadOnly = True
        Me.txtTotalRequired.SelectedText = ""
        Me.txtTotalRequired.Size = New System.Drawing.Size(414, 45)
        Me.txtTotalRequired.TabIndex = 5576
        Me.txtTotalRequired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(1342, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(257, 36)
        Me.Label2.TabIndex = 5575
        Me.Label2.Text = "اجمالي الفاتورة"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(1342, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(257, 37)
        Me.Label1.TabIndex = 5572
        Me.Label1.Text = "تاريخ الفاتورة"
        '
        'btnSelectImage
        '
        Me.btnSelectImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectImage.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectImage.Appearance.Options.UseFont = True
        Me.btnSelectImage.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.new_hire
        Me.btnSelectImage.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnSelectImage.Location = New System.Drawing.Point(32, 276)
        Me.btnSelectImage.Name = "btnSelectImage"
        Me.btnSelectImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSelectImage.Size = New System.Drawing.Size(280, 68)
        Me.btnSelectImage.TabIndex = 5567
        Me.btnSelectImage.Text = "تحديد الصورة"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(59, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 33)
        Me.Label6.TabIndex = 5566
        Me.Label6.Text = "صورة الفاتورة"
        '
        'pic_purchases
        '
        Me.pic_purchases.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_purchases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_purchases.Location = New System.Drawing.Point(32, 46)
        Me.pic_purchases.Name = "pic_purchases"
        Me.pic_purchases.Size = New System.Drawing.Size(280, 224)
        Me.pic_purchases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_purchases.TabIndex = 5565
        Me.pic_purchases.TabStop = False
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
        Me.txt_notes.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_notes.ForeColor = System.Drawing.Color.Black
        Me.txt_notes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_notes.Location = New System.Drawing.Point(321, 245)
        Me.txt_notes.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_notes.Multiline = True
        Me.txt_notes.Name = "txt_notes"
        Me.txt_notes.PlaceholderText = ""
        Me.txt_notes.SelectedText = ""
        Me.txt_notes.Size = New System.Drawing.Size(557, 99)
        Me.txt_notes.TabIndex = 5563
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(1342, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(257, 36)
        Me.Label5.TabIndex = 5561
        Me.Label5.Text = "المورد"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'dgv_Purchases
        '
        Me.dgv_Purchases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_Purchases.ColumnHeadersHeight = 70
        Me.dgv_Purchases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Purchases.Location = New System.Drawing.Point(0, 706)
        Me.dgv_Purchases.Name = "dgv_Purchases"
        Me.dgv_Purchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgv_Purchases.RowTemplate.Height = 50
        Me.dgv_Purchases.Size = New System.Drawing.Size(1600, 354)
        Me.dgv_Purchases.TabIndex = 76
        '
        'Purchases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1600, 1060)
        Me.Controls.Add(Me.dgv_Purchases)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Purchases"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        CType(Me.pic_purchases, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Purchases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSaveInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents btnSelectImage As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents pic_purchases As PictureBox
    Friend WithEvents txt_notes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_clean As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTotalAfterDiscount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDiscount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTotalRequired As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtRemaining As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblRemaining As Label
    Friend WithEvents txtPaid As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblPaid As Label
    Friend WithEvents dgv_Purchases As DataGridView
    Friend WithEvents txt_purchase_price As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtProductNameSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cmbUnit As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtProductCodeSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtQuantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmb_Pay As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lstCodeSuggestions As ListBox
    Friend WithEvents lstNameSuggestions As ListBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_totelProduct As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_add_product As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_Invoice_ID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbl_user_name As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents cmbVendor As ComboBox
    Friend WithEvents btn_add_new_product As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_auto_pay As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Guna2ToggleSwitch1 As Guna.UI2.WinForms.Guna2ToggleSwitch
End Class
