<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Categories
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Categories))
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.btnAddColorForm = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddPrinterForm = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddTypeForm = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteImage = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSelectImage = New Guna.UI2.WinForms.Guna2Button()
        Me.picCategory = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnUpdate = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbPrinter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtDescription = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbColor = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCategoryNameEn = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCategoryNameAr = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.txtItemsCount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtCategoryCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dvg_Categories = New System.Windows.Forms.DataGridView()
        Me.Guna2AnimateWindow1 = New Guna.UI2.WinForms.Guna2AnimateWindow(Me.components)
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.grpCustomerInfo.SuspendLayout()
        CType(Me.picCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.dvg_Categories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.panelHeader.TabIndex = 1
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
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(716, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(81, 44)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الفئات"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.btnAddColorForm)
        Me.grpCustomerInfo.Controls.Add(Me.btnAddPrinterForm)
        Me.grpCustomerInfo.Controls.Add(Me.btnAddTypeForm)
        Me.grpCustomerInfo.Controls.Add(Me.btnDeleteImage)
        Me.grpCustomerInfo.Controls.Add(Me.btnSelectImage)
        Me.grpCustomerInfo.Controls.Add(Me.picCategory)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2Panel1)
        Me.grpCustomerInfo.Controls.Add(Me.tgStatus)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.Label8)
        Me.grpCustomerInfo.Controls.Add(Me.cmbType)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.cmbPrinter)
        Me.grpCustomerInfo.Controls.Add(Me.txtDescription)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.cmbColor)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.txtCategoryNameEn)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.txtCategoryNameAr)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.lblPaid)
        Me.grpCustomerInfo.Controls.Add(Me.txtItemsCount)
        Me.grpCustomerInfo.Controls.Add(Me.cmbSearchField)
        Me.grpCustomerInfo.Controls.Add(Me.lstSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.txtSearch)
        Me.grpCustomerInfo.Controls.Add(Me.txtCategoryCode)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 70)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1427, 505)
        Me.grpCustomerInfo.TabIndex = 37
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAddColorForm
        '
        Me.btnAddColorForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddColorForm.BorderRadius = 8
        Me.btnAddColorForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddColorForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddColorForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddColorForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddColorForm.FillColor = System.Drawing.Color.Empty
        Me.btnAddColorForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddColorForm.ForeColor = System.Drawing.Color.White
        Me.btnAddColorForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddColorForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddColorForm.Location = New System.Drawing.Point(1230, 246)
        Me.btnAddColorForm.Name = "btnAddColorForm"
        Me.btnAddColorForm.Size = New System.Drawing.Size(40, 48)
        Me.btnAddColorForm.TabIndex = 5606
        '
        'btnAddPrinterForm
        '
        Me.btnAddPrinterForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddPrinterForm.BorderRadius = 8
        Me.btnAddPrinterForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddPrinterForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddPrinterForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddPrinterForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddPrinterForm.FillColor = System.Drawing.Color.Empty
        Me.btnAddPrinterForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddPrinterForm.ForeColor = System.Drawing.Color.White
        Me.btnAddPrinterForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddPrinterForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddPrinterForm.Location = New System.Drawing.Point(1230, 300)
        Me.btnAddPrinterForm.Name = "btnAddPrinterForm"
        Me.btnAddPrinterForm.Size = New System.Drawing.Size(40, 48)
        Me.btnAddPrinterForm.TabIndex = 5605
        '
        'btnAddTypeForm
        '
        Me.btnAddTypeForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddTypeForm.BorderRadius = 8
        Me.btnAddTypeForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddTypeForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddTypeForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddTypeForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddTypeForm.FillColor = System.Drawing.Color.Empty
        Me.btnAddTypeForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddTypeForm.ForeColor = System.Drawing.Color.White
        Me.btnAddTypeForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddTypeForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddTypeForm.Location = New System.Drawing.Point(1230, 354)
        Me.btnAddTypeForm.Name = "btnAddTypeForm"
        Me.btnAddTypeForm.Size = New System.Drawing.Size(40, 48)
        Me.btnAddTypeForm.TabIndex = 5604
        '
        'btnDeleteImage
        '
        Me.btnDeleteImage.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteImage.BorderColor = System.Drawing.Color.BurlyWood
        Me.btnDeleteImage.BorderRadius = 8
        Me.btnDeleteImage.BorderThickness = 1
        Me.btnDeleteImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteImage.FillColor = System.Drawing.Color.White
        Me.btnDeleteImage.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteImage.ForeColor = System.Drawing.Color.White
        Me.btnDeleteImage.Image = Global.WindowsApp1.My.Resources.Resources.delete__1_
        Me.btnDeleteImage.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnDeleteImage.Location = New System.Drawing.Point(845, 204)
        Me.btnDeleteImage.Name = "btnDeleteImage"
        Me.btnDeleteImage.Size = New System.Drawing.Size(65, 95)
        Me.btnDeleteImage.TabIndex = 5603
        '
        'btnSelectImage
        '
        Me.btnSelectImage.BackColor = System.Drawing.Color.Transparent
        Me.btnSelectImage.BorderColor = System.Drawing.Color.BurlyWood
        Me.btnSelectImage.BorderRadius = 8
        Me.btnSelectImage.BorderThickness = 1
        Me.btnSelectImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSelectImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSelectImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSelectImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSelectImage.FillColor = System.Drawing.Color.White
        Me.btnSelectImage.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSelectImage.ForeColor = System.Drawing.Color.White
        Me.btnSelectImage.Image = Global.WindowsApp1.My.Resources.Resources.edit
        Me.btnSelectImage.ImageOffset = New System.Drawing.Point(2, 0)
        Me.btnSelectImage.ImageSize = New System.Drawing.Size(50, 50)
        Me.btnSelectImage.Location = New System.Drawing.Point(845, 99)
        Me.btnSelectImage.Name = "btnSelectImage"
        Me.btnSelectImage.Size = New System.Drawing.Size(65, 95)
        Me.btnSelectImage.TabIndex = 5602
        '
        'picCategory
        '
        Me.picCategory.BorderRadius = 8
        Me.picCategory.ImageRotate = 0!
        Me.picCategory.Location = New System.Drawing.Point(539, 99)
        Me.picCategory.Name = "picCategory"
        Me.picCategory.Size = New System.Drawing.Size(300, 200)
        Me.picCategory.TabIndex = 5601
        Me.picCategory.TabStop = False
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnRefresh)
        Me.Guna2Panel1.Controls.Add(Me.btnClear)
        Me.Guna2Panel1.Controls.Add(Me.btnDelete)
        Me.Guna2Panel1.Controls.Add(Me.btnUpdate)
        Me.Guna2Panel1.Controls.Add(Me.btnAdd)
        Me.Guna2Panel1.Location = New System.Drawing.Point(90, 412)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1287, 78)
        Me.Guna2Panel1.TabIndex = 5600
        '
        'btnRefresh
        '
        Me.btnRefresh.BorderRadius = 8
        Me.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(68, 17)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(180, 45)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "تحديث"
        '
        'btnClear
        '
        Me.btnClear.BorderRadius = 8
        Me.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(316, 17)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(180, 45)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "تفريغ الحقول"
        '
        'btnDelete
        '
        Me.btnDelete.BorderRadius = 8
        Me.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(564, 17)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(180, 45)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف"
        '
        'btnUpdate
        '
        Me.btnUpdate.BorderRadius = 8
        Me.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(812, 17)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(180, 45)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "تعديل"
        '
        'btnAdd
        '
        Me.btnAdd.BorderRadius = 8
        Me.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(1060, 17)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(180, 45)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "اضافة"
        '
        'tgStatus
        '
        Me.tgStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Location = New System.Drawing.Point(746, 358)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(93, 44)
        Me.tgStatus.TabIndex = 5599
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(726, 314)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 33)
        Me.Label4.TabIndex = 5598
        Me.Label4.Text = "حاله الفئة"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(1276, 362)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 33)
        Me.Label8.TabIndex = 5596
        Me.Label8.Text = "نوع الفئة"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.Transparent
        Me.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbType.ForeColor = System.Drawing.Color.Black
        Me.cmbType.ItemHeight = 42
        Me.cmbType.Location = New System.Drawing.Point(914, 354)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(311, 48)
        Me.cmbType.TabIndex = 5595
        Me.cmbType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(1285, 308)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 33)
        Me.Label7.TabIndex = 5594
        Me.Label7.Text = "الطابعه"
        '
        'cmbPrinter
        '
        Me.cmbPrinter.BackColor = System.Drawing.Color.Transparent
        Me.cmbPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbPrinter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbPrinter.ForeColor = System.Drawing.Color.Black
        Me.cmbPrinter.ItemHeight = 42
        Me.cmbPrinter.Location = New System.Drawing.Point(914, 300)
        Me.cmbPrinter.Name = "cmbPrinter"
        Me.cmbPrinter.Size = New System.Drawing.Size(311, 48)
        Me.cmbPrinter.TabIndex = 5593
        Me.cmbPrinter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescription.DefaultText = ""
        Me.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDescription.Location = New System.Drawing.Point(914, 195)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.PlaceholderText = ""
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.SelectedText = ""
        Me.txtDescription.Size = New System.Drawing.Size(311, 45)
        Me.txtDescription.TabIndex = 5592
        Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(1263, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 33)
        Me.Label6.TabIndex = 5591
        Me.Label6.Text = "وصف الفئة"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(1277, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 33)
        Me.Label5.TabIndex = 5590
        Me.Label5.Text = "لون الفئة"
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.Color.Transparent
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbColor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbColor.ForeColor = System.Drawing.Color.Black
        Me.cmbColor.ItemHeight = 42
        Me.cmbColor.Location = New System.Drawing.Point(914, 246)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(311, 48)
        Me.cmbColor.TabIndex = 5588
        Me.cmbColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(1230, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 33)
        Me.Label3.TabIndex = 5587
        Me.Label3.Text = "اسم الفئة إنجليزي"
        '
        'txtCategoryNameEn
        '
        Me.txtCategoryNameEn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategoryNameEn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoryNameEn.DefaultText = ""
        Me.txtCategoryNameEn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCategoryNameEn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCategoryNameEn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryNameEn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryNameEn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryNameEn.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCategoryNameEn.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryNameEn.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryNameEn.Location = New System.Drawing.Point(914, 144)
        Me.txtCategoryNameEn.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCategoryNameEn.Name = "txtCategoryNameEn"
        Me.txtCategoryNameEn.PlaceholderText = ""
        Me.txtCategoryNameEn.ReadOnly = True
        Me.txtCategoryNameEn.SelectedText = ""
        Me.txtCategoryNameEn.Size = New System.Drawing.Size(311, 45)
        Me.txtCategoryNameEn.TabIndex = 5586
        Me.txtCategoryNameEn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(1242, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 33)
        Me.Label2.TabIndex = 5585
        Me.Label2.Text = "اسم الفئة عربي"
        '
        'txtCategoryNameAr
        '
        Me.txtCategoryNameAr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategoryNameAr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoryNameAr.DefaultText = ""
        Me.txtCategoryNameAr.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCategoryNameAr.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCategoryNameAr.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryNameAr.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryNameAr.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryNameAr.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCategoryNameAr.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryNameAr.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryNameAr.Location = New System.Drawing.Point(914, 93)
        Me.txtCategoryNameAr.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCategoryNameAr.Name = "txtCategoryNameAr"
        Me.txtCategoryNameAr.PlaceholderText = ""
        Me.txtCategoryNameAr.ReadOnly = True
        Me.txtCategoryNameAr.SelectedText = ""
        Me.txtCategoryNameAr.Size = New System.Drawing.Size(311, 45)
        Me.txtCategoryNameAr.TabIndex = 5584
        Me.txtCategoryNameAr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(1277, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 33)
        Me.Label1.TabIndex = 5583
        Me.Label1.Text = "كود الفئة"
        '
        'lblPaid
        '
        Me.lblPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPaid.BackColor = System.Drawing.Color.Transparent
        Me.lblPaid.Location = New System.Drawing.Point(539, 308)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(162, 44)
        Me.lblPaid.TabIndex = 5582
        Me.lblPaid.Text = "عدد الاصناف"
        Me.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtItemsCount
        '
        Me.txtItemsCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemsCount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItemsCount.DefaultText = ""
        Me.txtItemsCount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtItemsCount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtItemsCount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtItemsCount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtItemsCount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtItemsCount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtItemsCount.ForeColor = System.Drawing.Color.Black
        Me.txtItemsCount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtItemsCount.Location = New System.Drawing.Point(539, 358)
        Me.txtItemsCount.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtItemsCount.Name = "txtItemsCount"
        Me.txtItemsCount.PlaceholderText = ""
        Me.txtItemsCount.SelectedText = ""
        Me.txtItemsCount.Size = New System.Drawing.Size(162, 45)
        Me.txtItemsCount.TabIndex = 45
        Me.txtItemsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbSearchField
        '
        Me.cmbSearchField.BackColor = System.Drawing.Color.Transparent
        Me.cmbSearchField.BorderRadius = 8
        Me.cmbSearchField.BorderThickness = 2
        Me.cmbSearchField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchField.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSearchField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSearchField.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbSearchField.ForeColor = System.Drawing.Color.Black
        Me.cmbSearchField.ItemHeight = 43
        Me.cmbSearchField.Location = New System.Drawing.Point(539, 43)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(300, 49)
        Me.cmbSearchField.TabIndex = 2
        Me.cmbSearchField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstSuggestions
        '
        Me.lstSuggestions.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lstSuggestions.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 25
        Me.lstSuggestions.Location = New System.Drawing.Point(11, 99)
        Me.lstSuggestions.Margin = New System.Windows.Forms.Padding(5)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.Size = New System.Drawing.Size(522, 304)
        Me.lstSuggestions.TabIndex = 37
        '
        'txtSearch
        '
        Me.txtSearch.BorderRadius = 8
        Me.txtSearch.BorderThickness = 2
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(11, 43)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "ابحث عن فئة"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(522, 49)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCategoryCode
        '
        Me.txtCategoryCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategoryCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoryCode.DefaultText = ""
        Me.txtCategoryCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCategoryCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCategoryCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCategoryCode.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryCode.Location = New System.Drawing.Point(914, 43)
        Me.txtCategoryCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCategoryCode.Name = "txtCategoryCode"
        Me.txtCategoryCode.PlaceholderText = ""
        Me.txtCategoryCode.SelectedText = ""
        Me.txtCategoryCode.Size = New System.Drawing.Size(311, 45)
        Me.txtCategoryCode.TabIndex = 3
        Me.txtCategoryCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dvg_Categories
        '
        Me.dvg_Categories.AllowUserToResizeColumns = False
        Me.dvg_Categories.AllowUserToResizeRows = False
        Me.dvg_Categories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvg_Categories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dvg_Categories.Location = New System.Drawing.Point(0, 575)
        Me.dvg_Categories.Name = "dvg_Categories"
        Me.dvg_Categories.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dvg_Categories.RowTemplate.Height = 40
        Me.dvg_Categories.Size = New System.Drawing.Size(1427, 325)
        Me.dvg_Categories.TabIndex = 38
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Categories
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1427, 900)
        Me.Controls.Add(Me.dvg_Categories)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Categories"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        CType(Me.picCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.dvg_Categories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtCategoryCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dvg_Categories As DataGridView
    Friend WithEvents txtItemsCount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblPaid As Label
    Friend WithEvents Guna2AnimateWindow1 As Guna.UI2.WinForms.Guna2AnimateWindow
    Friend WithEvents cmbColor As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCategoryNameEn As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCategoryNameAr As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbPrinter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtDescription As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents picCategory As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnUpdate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteImage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSelectImage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddTypeForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddColorForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddPrinterForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
