<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBranches
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBranches))
        Me.dgvBranches = New System.Windows.Forms.DataGridView()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.tgIsActive = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtAddress = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnDeleteImage = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSelectImage = New Guna.UI2.WinForms.Guna2Button()
        Me.picCategory = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClearFields = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.tgIsMainBranch = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbManager = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMobile = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPhone = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBranchName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtBranchCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me._searchTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvBranches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        CType(Me.picCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvBranches
        '
        Me.dgvBranches.AllowUserToResizeColumns = False
        Me.dgvBranches.AllowUserToResizeRows = False
        Me.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBranches.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBranches.Location = New System.Drawing.Point(0, 575)
        Me.dgvBranches.Name = "dgvBranches"
        Me.dgvBranches.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvBranches.RowTemplate.Height = 40
        Me.dgvBranches.Size = New System.Drawing.Size(1427, 325)
        Me.dgvBranches.TabIndex = 41
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.tgIsActive)
        Me.grpCustomerInfo.Controls.Add(Me.Label9)
        Me.grpCustomerInfo.Controls.Add(Me.txtNotes)
        Me.grpCustomerInfo.Controls.Add(Me.txtAddress)
        Me.grpCustomerInfo.Controls.Add(Me.btnDeleteImage)
        Me.grpCustomerInfo.Controls.Add(Me.btnSelectImage)
        Me.grpCustomerInfo.Controls.Add(Me.picCategory)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2Panel1)
        Me.grpCustomerInfo.Controls.Add(Me.tgIsMainBranch)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.Label8)
        Me.grpCustomerInfo.Controls.Add(Me.cmbManager)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.txtMobile)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.txtPhone)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.txtBranchName)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.cmbSearchField)
        Me.grpCustomerInfo.Controls.Add(Me.lstSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.txtSearch)
        Me.grpCustomerInfo.Controls.Add(Me.txtBranchCode)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 70)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1427, 505)
        Me.grpCustomerInfo.TabIndex = 40
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tgIsActive
        '
        Me.tgIsActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgIsActive.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgIsActive.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgIsActive.Location = New System.Drawing.Point(562, 358)
        Me.tgIsActive.Name = "tgIsActive"
        Me.tgIsActive.Size = New System.Drawing.Size(93, 44)
        Me.tgIsActive.TabIndex = 5610
        Me.tgIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgIsActive.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgIsActive.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(542, 314)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(145, 33)
        Me.Label9.TabIndex = 5609
        Me.Label9.Text = "نشط / معطل"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotes.DefaultText = ""
        Me.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(914, 300)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(311, 45)
        Me.txtNotes.TabIndex = 5608
        Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAddress.DefaultText = ""
        Me.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAddress.Location = New System.Drawing.Point(914, 246)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.PlaceholderText = ""
        Me.txtAddress.SelectedText = ""
        Me.txtAddress.Size = New System.Drawing.Size(311, 45)
        Me.txtAddress.TabIndex = 5607
        Me.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.Guna2Panel1.Controls.Add(Me.btnClearFields)
        Me.Guna2Panel1.Controls.Add(Me.btnDelete)
        Me.Guna2Panel1.Controls.Add(Me.btnEdit)
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
        'btnClearFields
        '
        Me.btnClearFields.BorderRadius = 8
        Me.btnClearFields.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFields.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFields.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearFields.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearFields.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearFields.ForeColor = System.Drawing.Color.White
        Me.btnClearFields.Location = New System.Drawing.Point(316, 17)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(180, 45)
        Me.btnClearFields.TabIndex = 3
        Me.btnClearFields.Text = "تفريغ الحقول"
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
        'btnEdit
        '
        Me.btnEdit.BorderRadius = 8
        Me.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(812, 17)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(180, 45)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "تعديل"
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
        'tgIsMainBranch
        '
        Me.tgIsMainBranch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgIsMainBranch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgIsMainBranch.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgIsMainBranch.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgIsMainBranch.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgIsMainBranch.Location = New System.Drawing.Point(746, 358)
        Me.tgIsMainBranch.Name = "tgIsMainBranch"
        Me.tgIsMainBranch.Size = New System.Drawing.Size(93, 44)
        Me.tgIsMainBranch.TabIndex = 5599
        Me.tgIsMainBranch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgIsMainBranch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgIsMainBranch.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgIsMainBranch.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(726, 314)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 33)
        Me.Label4.TabIndex = 5598
        Me.Label4.Text = "الفرع الرئيسي"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(1263, 362)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 33)
        Me.Label8.TabIndex = 5596
        Me.Label8.Text = "مدير الفرع"
        '
        'cmbManager
        '
        Me.cmbManager.BackColor = System.Drawing.Color.Transparent
        Me.cmbManager.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManager.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbManager.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbManager.ForeColor = System.Drawing.Color.Black
        Me.cmbManager.ItemHeight = 42
        Me.cmbManager.Location = New System.Drawing.Point(914, 354)
        Me.cmbManager.Name = "cmbManager"
        Me.cmbManager.Size = New System.Drawing.Size(311, 48)
        Me.cmbManager.TabIndex = 5595
        Me.cmbManager.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(1271, 308)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 33)
        Me.Label7.TabIndex = 5594
        Me.Label7.Text = "ملاحظات"
        '
        'txtMobile
        '
        Me.txtMobile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMobile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMobile.DefaultText = ""
        Me.txtMobile.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtMobile.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtMobile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMobile.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMobile.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMobile.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtMobile.ForeColor = System.Drawing.Color.Black
        Me.txtMobile.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMobile.Location = New System.Drawing.Point(914, 195)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.PlaceholderText = ""
        Me.txtMobile.SelectedText = ""
        Me.txtMobile.Size = New System.Drawing.Size(311, 45)
        Me.txtMobile.TabIndex = 5592
        Me.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(1279, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 33)
        Me.Label6.TabIndex = 5591
        Me.Label6.Text = "الموبايل"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(1283, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 33)
        Me.Label5.TabIndex = 5590
        Me.Label5.Text = "العنوان"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(1234, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 33)
        Me.Label3.TabIndex = 5587
        Me.Label3.Text = "التليفون الأرضي"
        '
        'txtPhone
        '
        Me.txtPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhone.DefaultText = ""
        Me.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtPhone.ForeColor = System.Drawing.Color.Black
        Me.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPhone.Location = New System.Drawing.Point(914, 144)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.PlaceholderText = ""
        Me.txtPhone.SelectedText = ""
        Me.txtPhone.Size = New System.Drawing.Size(311, 45)
        Me.txtPhone.TabIndex = 5586
        Me.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(1267, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 33)
        Me.Label2.TabIndex = 5585
        Me.Label2.Text = "اسم الفرع"
        '
        'txtBranchName
        '
        Me.txtBranchName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBranchName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBranchName.DefaultText = ""
        Me.txtBranchName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBranchName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBranchName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBranchName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBranchName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBranchName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtBranchName.ForeColor = System.Drawing.Color.Black
        Me.txtBranchName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBranchName.Location = New System.Drawing.Point(914, 93)
        Me.txtBranchName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtBranchName.Name = "txtBranchName"
        Me.txtBranchName.PlaceholderText = ""
        Me.txtBranchName.SelectedText = ""
        Me.txtBranchName.Size = New System.Drawing.Size(311, 45)
        Me.txtBranchName.TabIndex = 5584
        Me.txtBranchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(1268, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 33)
        Me.Label1.TabIndex = 5583
        Me.Label1.Text = "كود الفرع"
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
        Me.txtSearch.PlaceholderText = "ابحث عن فرع"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(522, 49)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBranchCode
        '
        Me.txtBranchCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBranchCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBranchCode.DefaultText = ""
        Me.txtBranchCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBranchCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBranchCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBranchCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBranchCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBranchCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtBranchCode.ForeColor = System.Drawing.Color.Black
        Me.txtBranchCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBranchCode.Location = New System.Drawing.Point(914, 43)
        Me.txtBranchCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.PlaceholderText = ""
        Me.txtBranchCode.SelectedText = ""
        Me.txtBranchCode.Size = New System.Drawing.Size(311, 45)
        Me.txtBranchCode.TabIndex = 3
        Me.txtBranchCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.panelHeader.TabIndex = 39
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
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(91, 44)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الفروع"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        '_searchTimer
        '
        Me._searchTimer.Interval = 300
        '
        'frmBranches
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1427, 900)
        Me.Controls.Add(Me.dgvBranches)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmBranches"
        Me.Text = "frmBranches"
        CType(Me.dgvBranches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        CType(Me.picCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvBranches As DataGridView
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents btnDeleteImage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSelectImage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents picCategory As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClearFields As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tgIsMainBranch As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbManager As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMobile As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPhone As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBranchName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtBranchCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtAddress As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tgIsActive As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label9 As Label
    Friend WithEvents _searchTimer As Timer
End Class
