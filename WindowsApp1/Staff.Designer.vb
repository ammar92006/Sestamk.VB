<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Staff
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Staff))
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_max = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_close = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dgv_Staff = New System.Windows.Forms.DataGridView()
        Me.PanelControl1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNew = New Guna.UI2.WinForms.Guna2Button()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupControl12 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.chkbackupDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.chkbackupEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.chkbackupAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.chkbackupOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupControl11 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.chkSettingsDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.chkSettingsEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.chkSettingsAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.chkSettingsOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupControl6 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chkStockDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.chkStockEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkStockAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.chkStockOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupControl7 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chkReportsDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.chkReportsEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.chkReportsAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.chkReportsOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupControl8 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.chkPurchasesDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.chkPurchasesEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.chkPurchasesAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.chkPurchasesOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupControl9 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.chkSuppliersDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.chkSuppliersEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.chkSuppliersAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.chkSuppliersOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupControl10 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.chkSalesDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.chkSalesEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.chkSalesAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.chkSalesOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupControl5 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkCustomerDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.chkCustomerEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkCustomerAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkCustomerOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.grp_ProductUnits = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkProductUnitsDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkProductUnitsEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.chkProductUnitsAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkProductUnitsOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.GroupControl3 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkProductsDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkProductsEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkProductsAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkProductsOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.grp_Categories = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkCategoriesDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkCategoriesEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkCategoriesAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkCategoriesOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.grp_Users = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkUsersDelete = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkUsersEdit = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkUsersAdd = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkUsersOpen = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.txtUser_Note = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_clean = New Guna.UI2.WinForms.Guna2Button()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtUser_Name = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtUser_Code = New Guna.UI2.WinForms.Guna2TextBox()
        Me.panelHeader.SuspendLayout()
        CType(Me.dgv_Staff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.grpCustomerInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GroupControl12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl12.SuspendLayout()
        CType(Me.GroupControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl11.SuspendLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl7.SuspendLayout()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl8.SuspendLayout()
        CType(Me.GroupControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl9.SuspendLayout()
        CType(Me.GroupControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl10.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.grp_ProductUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_ProductUnits.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.grp_Categories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Categories.SuspendLayout()
        CType(Me.grp_Users, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Users.SuspendLayout()
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
        Me.panelHeader.Size = New System.Drawing.Size(1500, 70)
        Me.panelHeader.TabIndex = 71
        '
        'btn_min
        '
        Me.btn_min.AutoSize = True
        Me.btn_min.Location = New System.Drawing.Point(103, 17)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btn_min.FillColor = System.Drawing.Color.Transparent
        Me.btn_min.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_min.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_min.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.btn_min.TabIndex = 5
        '
        'btn_max
        '
        Me.btn_max.AutoSize = True
        Me.btn_max.Location = New System.Drawing.Point(59, 17)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox
        Me.btn_max.FillColor = System.Drawing.Color.Transparent
        Me.btn_max.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_max.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_max.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 4
        '
        'btn_close
        '
        Me.btn_close.AutoSize = True
        Me.btn_close.Location = New System.Drawing.Point(15, 17)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.FillColor = System.Drawing.Color.Transparent
        Me.btn_close.HoverState.FillColor = System.Drawing.Color.FromArgb(239, 68, 68)
        Me.btn_close.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_close.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 3
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("LBC", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(712, 10)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(238, 49)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "  الموظفين إدارة"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'dgv_Staff
        '
        Me.dgv_Staff.ColumnHeadersHeight = 70
        Me.dgv_Staff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Staff.Location = New System.Drawing.Point(0, 675)
        Me.dgv_Staff.Name = "dgv_Staff"
        Me.dgv_Staff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgv_Staff.RowTemplate.Height = 50
        Me.dgv_Staff.Size = New System.Drawing.Size(1500, 275)
        Me.dgv_Staff.TabIndex = 75
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnDelete)
        Me.PanelControl1.Controls.Add(Me.btnEdit)
        Me.PanelControl1.Controls.Add(Me.btnNew)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 70)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1500, 88)
        Me.PanelControl1.TabIndex = 76
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(313, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnDelete.Size = New System.Drawing.Size(348, 75)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف الموظف (F4)"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(680, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnEdit.Size = New System.Drawing.Size(385, 75)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "تعديل الموظف (F3)"
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(1071, 5)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnNew.Size = New System.Drawing.Size(403, 75)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "اضافة موظف جديد (F2)"
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.GroupBox1)
        Me.grpCustomerInfo.Controls.Add(Me.txtUser_Note)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.btn_clean)
        Me.grpCustomerInfo.Controls.Add(Me.cmbSearchField)
        Me.grpCustomerInfo.Controls.Add(Me.txtSearch)
        Me.grpCustomerInfo.Controls.Add(Me.txtUser_Name)
        Me.grpCustomerInfo.Controls.Add(Me.txtUser_Code)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 158)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1500, 517)
        Me.grpCustomerInfo.TabIndex = 77
        Me.grpCustomerInfo.Text = "بيانات المستخدم"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupControl12)
        Me.GroupBox1.Controls.Add(Me.GroupControl11)
        Me.GroupBox1.Controls.Add(Me.GroupControl6)
        Me.GroupBox1.Controls.Add(Me.GroupControl7)
        Me.GroupBox1.Controls.Add(Me.GroupControl8)
        Me.GroupBox1.Controls.Add(Me.GroupControl9)
        Me.GroupBox1.Controls.Add(Me.GroupControl10)
        Me.GroupBox1.Controls.Add(Me.GroupControl5)
        Me.GroupBox1.Controls.Add(Me.grp_ProductUnits)
        Me.GroupBox1.Controls.Add(Me.GroupControl3)
        Me.GroupBox1.Controls.Add(Me.grp_Categories)
        Me.GroupBox1.Controls.Add(Me.grp_Users)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1066, 402)
        Me.GroupBox1.TabIndex = 5564
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "صلاحيات الموظف"
        '
        'GroupControl12
        '
        Me.GroupControl12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl12.Controls.Add(Me.Label48)
        Me.GroupControl12.Controls.Add(Me.chkbackupDelete)
        Me.GroupControl12.Controls.Add(Me.Label49)
        Me.GroupControl12.Controls.Add(Me.chkbackupEdit)
        Me.GroupControl12.Controls.Add(Me.Label50)
        Me.GroupControl12.Controls.Add(Me.chkbackupAdd)
        Me.GroupControl12.Controls.Add(Me.Label51)
        Me.GroupControl12.Controls.Add(Me.chkbackupOpen)
        Me.GroupControl12.Location = New System.Drawing.Point(29, 204)
        Me.GroupControl12.Name = "GroupControl12"
        Me.GroupControl12.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl12.TabIndex = 5587
        Me.GroupControl12.Text = "النسخ الاحتياطي"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label48.Location = New System.Drawing.Point(24, 113)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(80, 27)
        Me.Label48.TabIndex = 7
        Me.Label48.Text = "الحذف"
        '
        'chkbackupDelete
        '
        Me.chkbackupDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkbackupDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkbackupDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkbackupDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkbackupDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkbackupDelete.Name = "chkbackupDelete"
        Me.chkbackupDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkbackupDelete.TabIndex = 6
        Me.chkbackupDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkbackupDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkbackupDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkbackupDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label49.Location = New System.Drawing.Point(24, 87)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(88, 27)
        Me.Label49.TabIndex = 5
        Me.Label49.Text = "التعديل"
        '
        'chkbackupEdit
        '
        Me.chkbackupEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkbackupEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkbackupEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkbackupEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkbackupEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkbackupEdit.Name = "chkbackupEdit"
        Me.chkbackupEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkbackupEdit.TabIndex = 4
        Me.chkbackupEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkbackupEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkbackupEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkbackupEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label50.Location = New System.Drawing.Point(24, 61)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(89, 27)
        Me.Label50.TabIndex = 3
        Me.Label50.Text = "الاضافة"
        '
        'chkbackupAdd
        '
        Me.chkbackupAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkbackupAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkbackupAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkbackupAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkbackupAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkbackupAdd.Name = "chkbackupAdd"
        Me.chkbackupAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkbackupAdd.TabIndex = 2
        Me.chkbackupAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkbackupAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkbackupAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkbackupAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label51.Location = New System.Drawing.Point(24, 35)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(86, 27)
        Me.Label51.TabIndex = 1
        Me.Label51.Text = "الدخول"
        '
        'chkbackupOpen
        '
        Me.chkbackupOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkbackupOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkbackupOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkbackupOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkbackupOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkbackupOpen.Name = "chkbackupOpen"
        Me.chkbackupOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkbackupOpen.TabIndex = 0
        Me.chkbackupOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkbackupOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkbackupOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkbackupOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupControl11
        '
        Me.GroupControl11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl11.Controls.Add(Me.Label44)
        Me.GroupControl11.Controls.Add(Me.chkSettingsDelete)
        Me.GroupControl11.Controls.Add(Me.Label45)
        Me.GroupControl11.Controls.Add(Me.chkSettingsEdit)
        Me.GroupControl11.Controls.Add(Me.Label46)
        Me.GroupControl11.Controls.Add(Me.chkSettingsAdd)
        Me.GroupControl11.Controls.Add(Me.Label47)
        Me.GroupControl11.Controls.Add(Me.chkSettingsOpen)
        Me.GroupControl11.Location = New System.Drawing.Point(31, 51)
        Me.GroupControl11.Name = "GroupControl11"
        Me.GroupControl11.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl11.TabIndex = 5586
        Me.GroupControl11.Text = "الاعدادات"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(24, 113)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(80, 27)
        Me.Label44.TabIndex = 7
        Me.Label44.Text = "الحذف"
        '
        'chkSettingsDelete
        '
        Me.chkSettingsDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSettingsDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSettingsDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSettingsDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSettingsDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkSettingsDelete.Name = "chkSettingsDelete"
        Me.chkSettingsDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkSettingsDelete.TabIndex = 6
        Me.chkSettingsDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSettingsDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSettingsDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSettingsDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label45.Location = New System.Drawing.Point(24, 87)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(88, 27)
        Me.Label45.TabIndex = 5
        Me.Label45.Text = "التعديل"
        '
        'chkSettingsEdit
        '
        Me.chkSettingsEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSettingsEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSettingsEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSettingsEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSettingsEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkSettingsEdit.Name = "chkSettingsEdit"
        Me.chkSettingsEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkSettingsEdit.TabIndex = 4
        Me.chkSettingsEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSettingsEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSettingsEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSettingsEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label46.Location = New System.Drawing.Point(24, 61)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(89, 27)
        Me.Label46.TabIndex = 3
        Me.Label46.Text = "الاضافة"
        '
        'chkSettingsAdd
        '
        Me.chkSettingsAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSettingsAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSettingsAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSettingsAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSettingsAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkSettingsAdd.Name = "chkSettingsAdd"
        Me.chkSettingsAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkSettingsAdd.TabIndex = 2
        Me.chkSettingsAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSettingsAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSettingsAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSettingsAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label47.Location = New System.Drawing.Point(24, 35)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(86, 27)
        Me.Label47.TabIndex = 1
        Me.Label47.Text = "الدخول"
        '
        'chkSettingsOpen
        '
        Me.chkSettingsOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSettingsOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSettingsOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSettingsOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSettingsOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkSettingsOpen.Name = "chkSettingsOpen"
        Me.chkSettingsOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkSettingsOpen.TabIndex = 0
        Me.chkSettingsOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSettingsOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSettingsOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSettingsOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupControl6
        '
        Me.GroupControl6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl6.Controls.Add(Me.Label24)
        Me.GroupControl6.Controls.Add(Me.chkStockDelete)
        Me.GroupControl6.Controls.Add(Me.Label25)
        Me.GroupControl6.Controls.Add(Me.chkStockEdit)
        Me.GroupControl6.Controls.Add(Me.Label26)
        Me.GroupControl6.Controls.Add(Me.chkStockAdd)
        Me.GroupControl6.Controls.Add(Me.Label27)
        Me.GroupControl6.Controls.Add(Me.chkStockOpen)
        Me.GroupControl6.Location = New System.Drawing.Point(198, 204)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl6.TabIndex = 5585
        Me.GroupControl6.Text = "المخزون"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(24, 113)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 27)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "الحذف"
        '
        'chkStockDelete
        '
        Me.chkStockDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkStockDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkStockDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkStockDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkStockDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkStockDelete.Name = "chkStockDelete"
        Me.chkStockDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkStockDelete.TabIndex = 6
        Me.chkStockDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkStockDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkStockDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkStockDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(24, 87)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 27)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "التعديل"
        '
        'chkStockEdit
        '
        Me.chkStockEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkStockEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkStockEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkStockEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkStockEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkStockEdit.Name = "chkStockEdit"
        Me.chkStockEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkStockEdit.TabIndex = 4
        Me.chkStockEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkStockEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkStockEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkStockEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(24, 61)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 27)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "الاضافة"
        '
        'chkStockAdd
        '
        Me.chkStockAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkStockAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkStockAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkStockAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkStockAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkStockAdd.Name = "chkStockAdd"
        Me.chkStockAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkStockAdd.TabIndex = 2
        Me.chkStockAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkStockAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkStockAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkStockAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.Location = New System.Drawing.Point(24, 35)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(86, 27)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "الدخول"
        '
        'chkStockOpen
        '
        Me.chkStockOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkStockOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkStockOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkStockOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkStockOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkStockOpen.Name = "chkStockOpen"
        Me.chkStockOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkStockOpen.TabIndex = 0
        Me.chkStockOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkStockOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkStockOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkStockOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupControl7
        '
        Me.GroupControl7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl7.Controls.Add(Me.Label28)
        Me.GroupControl7.Controls.Add(Me.chkReportsDelete)
        Me.GroupControl7.Controls.Add(Me.Label29)
        Me.GroupControl7.Controls.Add(Me.chkReportsEdit)
        Me.GroupControl7.Controls.Add(Me.Label30)
        Me.GroupControl7.Controls.Add(Me.chkReportsAdd)
        Me.GroupControl7.Controls.Add(Me.Label31)
        Me.GroupControl7.Controls.Add(Me.chkReportsOpen)
        Me.GroupControl7.Location = New System.Drawing.Point(367, 204)
        Me.GroupControl7.Name = "GroupControl7"
        Me.GroupControl7.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl7.TabIndex = 5584
        Me.GroupControl7.Text = "التقارير"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.Location = New System.Drawing.Point(24, 113)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 27)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "الحذف"
        '
        'chkReportsDelete
        '
        Me.chkReportsDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkReportsDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkReportsDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkReportsDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkReportsDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkReportsDelete.Name = "chkReportsDelete"
        Me.chkReportsDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkReportsDelete.TabIndex = 6
        Me.chkReportsDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkReportsDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkReportsDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkReportsDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label29.Location = New System.Drawing.Point(24, 87)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(88, 27)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "التعديل"
        '
        'chkReportsEdit
        '
        Me.chkReportsEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkReportsEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkReportsEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkReportsEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkReportsEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkReportsEdit.Name = "chkReportsEdit"
        Me.chkReportsEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkReportsEdit.TabIndex = 4
        Me.chkReportsEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkReportsEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkReportsEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkReportsEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(24, 61)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(89, 27)
        Me.Label30.TabIndex = 3
        Me.Label30.Text = "الاضافة"
        '
        'chkReportsAdd
        '
        Me.chkReportsAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkReportsAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkReportsAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkReportsAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkReportsAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkReportsAdd.Name = "chkReportsAdd"
        Me.chkReportsAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkReportsAdd.TabIndex = 2
        Me.chkReportsAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkReportsAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkReportsAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkReportsAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label31.Location = New System.Drawing.Point(24, 35)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(86, 27)
        Me.Label31.TabIndex = 1
        Me.Label31.Text = "الدخول"
        '
        'chkReportsOpen
        '
        Me.chkReportsOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkReportsOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkReportsOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkReportsOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkReportsOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkReportsOpen.Name = "chkReportsOpen"
        Me.chkReportsOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkReportsOpen.TabIndex = 0
        Me.chkReportsOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkReportsOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkReportsOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkReportsOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupControl8
        '
        Me.GroupControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl8.Controls.Add(Me.Label32)
        Me.GroupControl8.Controls.Add(Me.chkPurchasesDelete)
        Me.GroupControl8.Controls.Add(Me.Label33)
        Me.GroupControl8.Controls.Add(Me.chkPurchasesEdit)
        Me.GroupControl8.Controls.Add(Me.Label34)
        Me.GroupControl8.Controls.Add(Me.chkPurchasesAdd)
        Me.GroupControl8.Controls.Add(Me.Label35)
        Me.GroupControl8.Controls.Add(Me.chkPurchasesOpen)
        Me.GroupControl8.Location = New System.Drawing.Point(536, 204)
        Me.GroupControl8.Name = "GroupControl8"
        Me.GroupControl8.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl8.TabIndex = 5583
        Me.GroupControl8.Text = "المشريات"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label32.Location = New System.Drawing.Point(24, 113)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 27)
        Me.Label32.TabIndex = 7
        Me.Label32.Text = "الحذف"
        '
        'chkPurchasesDelete
        '
        Me.chkPurchasesDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchasesDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchasesDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchasesDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkPurchasesDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkPurchasesDelete.Name = "chkPurchasesDelete"
        Me.chkPurchasesDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkPurchasesDelete.TabIndex = 6
        Me.chkPurchasesDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchasesDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchasesDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchasesDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label33.Location = New System.Drawing.Point(24, 87)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 27)
        Me.Label33.TabIndex = 5
        Me.Label33.Text = "التعديل"
        '
        'chkPurchasesEdit
        '
        Me.chkPurchasesEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchasesEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchasesEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchasesEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkPurchasesEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkPurchasesEdit.Name = "chkPurchasesEdit"
        Me.chkPurchasesEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkPurchasesEdit.TabIndex = 4
        Me.chkPurchasesEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchasesEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchasesEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchasesEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label34.Location = New System.Drawing.Point(24, 61)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(89, 27)
        Me.Label34.TabIndex = 3
        Me.Label34.Text = "الاضافة"
        '
        'chkPurchasesAdd
        '
        Me.chkPurchasesAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchasesAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchasesAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchasesAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkPurchasesAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkPurchasesAdd.Name = "chkPurchasesAdd"
        Me.chkPurchasesAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkPurchasesAdd.TabIndex = 2
        Me.chkPurchasesAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchasesAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchasesAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchasesAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.Location = New System.Drawing.Point(24, 35)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(86, 27)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "الدخول"
        '
        'chkPurchasesOpen
        '
        Me.chkPurchasesOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchasesOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchasesOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchasesOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkPurchasesOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkPurchasesOpen.Name = "chkPurchasesOpen"
        Me.chkPurchasesOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkPurchasesOpen.TabIndex = 0
        Me.chkPurchasesOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchasesOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchasesOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchasesOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupControl9
        '
        Me.GroupControl9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl9.Controls.Add(Me.Label36)
        Me.GroupControl9.Controls.Add(Me.chkSuppliersDelete)
        Me.GroupControl9.Controls.Add(Me.Label37)
        Me.GroupControl9.Controls.Add(Me.chkSuppliersEdit)
        Me.GroupControl9.Controls.Add(Me.Label38)
        Me.GroupControl9.Controls.Add(Me.chkSuppliersAdd)
        Me.GroupControl9.Controls.Add(Me.Label39)
        Me.GroupControl9.Controls.Add(Me.chkSuppliersOpen)
        Me.GroupControl9.Location = New System.Drawing.Point(705, 204)
        Me.GroupControl9.Name = "GroupControl9"
        Me.GroupControl9.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl9.TabIndex = 5582
        Me.GroupControl9.Text = "الموردين"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.Location = New System.Drawing.Point(24, 113)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(80, 27)
        Me.Label36.TabIndex = 7
        Me.Label36.Text = "الحذف"
        '
        'chkSuppliersDelete
        '
        Me.chkSuppliersDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSuppliersDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSuppliersDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSuppliersDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSuppliersDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkSuppliersDelete.Name = "chkSuppliersDelete"
        Me.chkSuppliersDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkSuppliersDelete.TabIndex = 6
        Me.chkSuppliersDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSuppliersDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSuppliersDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSuppliersDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(24, 87)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(88, 27)
        Me.Label37.TabIndex = 5
        Me.Label37.Text = "التعديل"
        '
        'chkSuppliersEdit
        '
        Me.chkSuppliersEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSuppliersEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSuppliersEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSuppliersEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSuppliersEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkSuppliersEdit.Name = "chkSuppliersEdit"
        Me.chkSuppliersEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkSuppliersEdit.TabIndex = 4
        Me.chkSuppliersEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSuppliersEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSuppliersEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSuppliersEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(24, 61)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(89, 27)
        Me.Label38.TabIndex = 3
        Me.Label38.Text = "الاضافة"
        '
        'chkSuppliersAdd
        '
        Me.chkSuppliersAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSuppliersAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSuppliersAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSuppliersAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSuppliersAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkSuppliersAdd.Name = "chkSuppliersAdd"
        Me.chkSuppliersAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkSuppliersAdd.TabIndex = 2
        Me.chkSuppliersAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSuppliersAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSuppliersAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSuppliersAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label39.Location = New System.Drawing.Point(24, 35)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(86, 27)
        Me.Label39.TabIndex = 1
        Me.Label39.Text = "الدخول"
        '
        'chkSuppliersOpen
        '
        Me.chkSuppliersOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSuppliersOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSuppliersOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSuppliersOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSuppliersOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkSuppliersOpen.Name = "chkSuppliersOpen"
        Me.chkSuppliersOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkSuppliersOpen.TabIndex = 0
        Me.chkSuppliersOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSuppliersOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSuppliersOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSuppliersOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupControl10
        '
        Me.GroupControl10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl10.Controls.Add(Me.Label40)
        Me.GroupControl10.Controls.Add(Me.chkSalesDelete)
        Me.GroupControl10.Controls.Add(Me.Label41)
        Me.GroupControl10.Controls.Add(Me.chkSalesEdit)
        Me.GroupControl10.Controls.Add(Me.Label42)
        Me.GroupControl10.Controls.Add(Me.chkSalesAdd)
        Me.GroupControl10.Controls.Add(Me.Label43)
        Me.GroupControl10.Controls.Add(Me.chkSalesOpen)
        Me.GroupControl10.Location = New System.Drawing.Point(874, 204)
        Me.GroupControl10.Name = "GroupControl10"
        Me.GroupControl10.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl10.TabIndex = 5581
        Me.GroupControl10.Text = "المبيعات"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label40.Location = New System.Drawing.Point(24, 113)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(80, 27)
        Me.Label40.TabIndex = 7
        Me.Label40.Text = "الحذف"
        '
        'chkSalesDelete
        '
        Me.chkSalesDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSalesDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkSalesDelete.Name = "chkSalesDelete"
        Me.chkSalesDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkSalesDelete.TabIndex = 6
        Me.chkSalesDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.Location = New System.Drawing.Point(24, 87)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(88, 27)
        Me.Label41.TabIndex = 5
        Me.Label41.Text = "التعديل"
        '
        'chkSalesEdit
        '
        Me.chkSalesEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSalesEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkSalesEdit.Name = "chkSalesEdit"
        Me.chkSalesEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkSalesEdit.TabIndex = 4
        Me.chkSalesEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label42.Location = New System.Drawing.Point(24, 61)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(89, 27)
        Me.Label42.TabIndex = 3
        Me.Label42.Text = "الاضافة"
        '
        'chkSalesAdd
        '
        Me.chkSalesAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSalesAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkSalesAdd.Name = "chkSalesAdd"
        Me.chkSalesAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkSalesAdd.TabIndex = 2
        Me.chkSalesAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(24, 35)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(86, 27)
        Me.Label43.TabIndex = 1
        Me.Label43.Text = "الدخول"
        '
        'chkSalesOpen
        '
        Me.chkSalesOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSalesOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkSalesOpen.Name = "chkSalesOpen"
        Me.chkSalesOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkSalesOpen.TabIndex = 0
        Me.chkSalesOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupControl5
        '
        Me.GroupControl5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl5.Controls.Add(Me.Label20)
        Me.GroupControl5.Controls.Add(Me.chkCustomerDelete)
        Me.GroupControl5.Controls.Add(Me.Label21)
        Me.GroupControl5.Controls.Add(Me.chkCustomerEdit)
        Me.GroupControl5.Controls.Add(Me.Label22)
        Me.GroupControl5.Controls.Add(Me.chkCustomerAdd)
        Me.GroupControl5.Controls.Add(Me.Label23)
        Me.GroupControl5.Controls.Add(Me.chkCustomerOpen)
        Me.GroupControl5.Location = New System.Drawing.Point(198, 51)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl5.TabIndex = 5580
        Me.GroupControl5.Text = "العملاء"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(24, 113)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 27)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "الحذف"
        '
        'chkCustomerDelete
        '
        Me.chkCustomerDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCustomerDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCustomerDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCustomerDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkCustomerDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkCustomerDelete.Name = "chkCustomerDelete"
        Me.chkCustomerDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkCustomerDelete.TabIndex = 6
        Me.chkCustomerDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCustomerDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCustomerDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCustomerDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(24, 87)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 27)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "التعديل"
        '
        'chkCustomerEdit
        '
        Me.chkCustomerEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCustomerEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCustomerEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCustomerEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkCustomerEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkCustomerEdit.Name = "chkCustomerEdit"
        Me.chkCustomerEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkCustomerEdit.TabIndex = 4
        Me.chkCustomerEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCustomerEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCustomerEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCustomerEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(24, 61)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 27)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "الاضافة"
        '
        'chkCustomerAdd
        '
        Me.chkCustomerAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCustomerAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCustomerAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCustomerAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkCustomerAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkCustomerAdd.Name = "chkCustomerAdd"
        Me.chkCustomerAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkCustomerAdd.TabIndex = 2
        Me.chkCustomerAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCustomerAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCustomerAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCustomerAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(24, 35)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(86, 27)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "الدخول"
        '
        'chkCustomerOpen
        '
        Me.chkCustomerOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCustomerOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCustomerOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCustomerOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkCustomerOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkCustomerOpen.Name = "chkCustomerOpen"
        Me.chkCustomerOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkCustomerOpen.TabIndex = 0
        Me.chkCustomerOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCustomerOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCustomerOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCustomerOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'grp_ProductUnits
        '
        Me.grp_ProductUnits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ProductUnits.Controls.Add(Me.Label16)
        Me.grp_ProductUnits.Controls.Add(Me.chkProductUnitsDelete)
        Me.grp_ProductUnits.Controls.Add(Me.Label17)
        Me.grp_ProductUnits.Controls.Add(Me.chkProductUnitsEdit)
        Me.grp_ProductUnits.Controls.Add(Me.Label18)
        Me.grp_ProductUnits.Controls.Add(Me.chkProductUnitsAdd)
        Me.grp_ProductUnits.Controls.Add(Me.Label19)
        Me.grp_ProductUnits.Controls.Add(Me.chkProductUnitsOpen)
        Me.grp_ProductUnits.Location = New System.Drawing.Point(367, 51)
        Me.grp_ProductUnits.Name = "grp_ProductUnits"
        Me.grp_ProductUnits.Size = New System.Drawing.Size(163, 147)
        Me.grp_ProductUnits.TabIndex = 5579
        Me.grp_ProductUnits.Text = "الوحدات والأسعار"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(24, 113)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 27)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "الحذف"
        '
        'chkProductUnitsDelete
        '
        Me.chkProductUnitsDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductUnitsDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductUnitsDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductUnitsDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkProductUnitsDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkProductUnitsDelete.Name = "chkProductUnitsDelete"
        Me.chkProductUnitsDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkProductUnitsDelete.TabIndex = 6
        Me.chkProductUnitsDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductUnitsDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductUnitsDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductUnitsDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(24, 87)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 27)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "التعديل"
        '
        'chkProductUnitsEdit
        '
        Me.chkProductUnitsEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductUnitsEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductUnitsEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductUnitsEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkProductUnitsEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkProductUnitsEdit.Name = "chkProductUnitsEdit"
        Me.chkProductUnitsEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkProductUnitsEdit.TabIndex = 4
        Me.chkProductUnitsEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductUnitsEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductUnitsEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductUnitsEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(24, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 27)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "الاضافة"
        '
        'chkProductUnitsAdd
        '
        Me.chkProductUnitsAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductUnitsAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductUnitsAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductUnitsAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkProductUnitsAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkProductUnitsAdd.Name = "chkProductUnitsAdd"
        Me.chkProductUnitsAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkProductUnitsAdd.TabIndex = 2
        Me.chkProductUnitsAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductUnitsAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductUnitsAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductUnitsAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(24, 35)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 27)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "الدخول"
        '
        'chkProductUnitsOpen
        '
        Me.chkProductUnitsOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductUnitsOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductUnitsOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductUnitsOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkProductUnitsOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkProductUnitsOpen.Name = "chkProductUnitsOpen"
        Me.chkProductUnitsOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkProductUnitsOpen.TabIndex = 0
        Me.chkProductUnitsOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductUnitsOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductUnitsOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductUnitsOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'GroupControl3
        '
        Me.GroupControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl3.Controls.Add(Me.Label12)
        Me.GroupControl3.Controls.Add(Me.chkProductsDelete)
        Me.GroupControl3.Controls.Add(Me.Label13)
        Me.GroupControl3.Controls.Add(Me.chkProductsEdit)
        Me.GroupControl3.Controls.Add(Me.Label14)
        Me.GroupControl3.Controls.Add(Me.chkProductsAdd)
        Me.GroupControl3.Controls.Add(Me.Label15)
        Me.GroupControl3.Controls.Add(Me.chkProductsOpen)
        Me.GroupControl3.Location = New System.Drawing.Point(536, 51)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(163, 147)
        Me.GroupControl3.TabIndex = 5578
        Me.GroupControl3.Text = "المنتجات"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(24, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 27)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "الحذف"
        '
        'chkProductsDelete
        '
        Me.chkProductsDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductsDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductsDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductsDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkProductsDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkProductsDelete.Name = "chkProductsDelete"
        Me.chkProductsDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkProductsDelete.TabIndex = 6
        Me.chkProductsDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductsDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductsDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductsDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(24, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 27)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "التعديل"
        '
        'chkProductsEdit
        '
        Me.chkProductsEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductsEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductsEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductsEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkProductsEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkProductsEdit.Name = "chkProductsEdit"
        Me.chkProductsEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkProductsEdit.TabIndex = 4
        Me.chkProductsEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductsEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductsEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductsEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(24, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 27)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "الاضافة"
        '
        'chkProductsAdd
        '
        Me.chkProductsAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductsAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductsAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductsAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkProductsAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkProductsAdd.Name = "chkProductsAdd"
        Me.chkProductsAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkProductsAdd.TabIndex = 2
        Me.chkProductsAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductsAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductsAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductsAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(24, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 27)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "الدخول"
        '
        'chkProductsOpen
        '
        Me.chkProductsOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductsOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkProductsOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductsOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkProductsOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkProductsOpen.Name = "chkProductsOpen"
        Me.chkProductsOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkProductsOpen.TabIndex = 0
        Me.chkProductsOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductsOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkProductsOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkProductsOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'grp_Categories
        '
        Me.grp_Categories.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_Categories.Controls.Add(Me.Label8)
        Me.grp_Categories.Controls.Add(Me.chkCategoriesDelete)
        Me.grp_Categories.Controls.Add(Me.Label9)
        Me.grp_Categories.Controls.Add(Me.chkCategoriesEdit)
        Me.grp_Categories.Controls.Add(Me.Label10)
        Me.grp_Categories.Controls.Add(Me.chkCategoriesAdd)
        Me.grp_Categories.Controls.Add(Me.Label11)
        Me.grp_Categories.Controls.Add(Me.chkCategoriesOpen)
        Me.grp_Categories.Location = New System.Drawing.Point(705, 51)
        Me.grp_Categories.Name = "grp_Categories"
        Me.grp_Categories.Size = New System.Drawing.Size(163, 147)
        Me.grp_Categories.TabIndex = 5577
        Me.grp_Categories.Text = "الاقسام"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(24, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 27)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "الحذف"
        '
        'chkCategoriesDelete
        '
        Me.chkCategoriesDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCategoriesDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCategoriesDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCategoriesDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkCategoriesDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkCategoriesDelete.Name = "chkCategoriesDelete"
        Me.chkCategoriesDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkCategoriesDelete.TabIndex = 6
        Me.chkCategoriesDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCategoriesDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCategoriesDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCategoriesDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(24, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 27)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "التعديل"
        '
        'chkCategoriesEdit
        '
        Me.chkCategoriesEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCategoriesEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCategoriesEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCategoriesEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkCategoriesEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkCategoriesEdit.Name = "chkCategoriesEdit"
        Me.chkCategoriesEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkCategoriesEdit.TabIndex = 4
        Me.chkCategoriesEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCategoriesEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCategoriesEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCategoriesEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(24, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 27)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "الاضافة"
        '
        'chkCategoriesAdd
        '
        Me.chkCategoriesAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCategoriesAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCategoriesAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCategoriesAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkCategoriesAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkCategoriesAdd.Name = "chkCategoriesAdd"
        Me.chkCategoriesAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkCategoriesAdd.TabIndex = 2
        Me.chkCategoriesAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCategoriesAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCategoriesAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCategoriesAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(24, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 27)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "الدخول"
        '
        'chkCategoriesOpen
        '
        Me.chkCategoriesOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCategoriesOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkCategoriesOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCategoriesOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkCategoriesOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkCategoriesOpen.Name = "chkCategoriesOpen"
        Me.chkCategoriesOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkCategoriesOpen.TabIndex = 0
        Me.chkCategoriesOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCategoriesOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkCategoriesOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkCategoriesOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'grp_Users
        '
        Me.grp_Users.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_Users.Controls.Add(Me.Label7)
        Me.grp_Users.Controls.Add(Me.chkUsersDelete)
        Me.grp_Users.Controls.Add(Me.Label6)
        Me.grp_Users.Controls.Add(Me.chkUsersEdit)
        Me.grp_Users.Controls.Add(Me.Label5)
        Me.grp_Users.Controls.Add(Me.chkUsersAdd)
        Me.grp_Users.Controls.Add(Me.Label4)
        Me.grp_Users.Controls.Add(Me.chkUsersOpen)
        Me.grp_Users.Location = New System.Drawing.Point(874, 51)
        Me.grp_Users.Name = "grp_Users"
        Me.grp_Users.Size = New System.Drawing.Size(163, 147)
        Me.grp_Users.TabIndex = 5576
        Me.grp_Users.Text = "المستخدمين"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(24, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 27)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "الحذف"
        '
        'chkUsersDelete
        '
        Me.chkUsersDelete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUsersDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUsersDelete.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUsersDelete.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkUsersDelete.Location = New System.Drawing.Point(116, 116)
        Me.chkUsersDelete.Name = "chkUsersDelete"
        Me.chkUsersDelete.Size = New System.Drawing.Size(35, 20)
        Me.chkUsersDelete.TabIndex = 6
        Me.chkUsersDelete.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUsersDelete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUsersDelete.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUsersDelete.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(24, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 27)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "التعديل"
        '
        'chkUsersEdit
        '
        Me.chkUsersEdit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUsersEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUsersEdit.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUsersEdit.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkUsersEdit.Location = New System.Drawing.Point(116, 90)
        Me.chkUsersEdit.Name = "chkUsersEdit"
        Me.chkUsersEdit.Size = New System.Drawing.Size(35, 20)
        Me.chkUsersEdit.TabIndex = 4
        Me.chkUsersEdit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUsersEdit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUsersEdit.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUsersEdit.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(24, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 27)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "الاضافة"
        '
        'chkUsersAdd
        '
        Me.chkUsersAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUsersAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUsersAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUsersAdd.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkUsersAdd.Location = New System.Drawing.Point(116, 64)
        Me.chkUsersAdd.Name = "chkUsersAdd"
        Me.chkUsersAdd.Size = New System.Drawing.Size(35, 20)
        Me.chkUsersAdd.TabIndex = 2
        Me.chkUsersAdd.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUsersAdd.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUsersAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUsersAdd.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(24, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 27)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "الدخول"
        '
        'chkUsersOpen
        '
        Me.chkUsersOpen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUsersOpen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUsersOpen.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUsersOpen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkUsersOpen.Location = New System.Drawing.Point(116, 38)
        Me.chkUsersOpen.Name = "chkUsersOpen"
        Me.chkUsersOpen.Size = New System.Drawing.Size(35, 20)
        Me.chkUsersOpen.TabIndex = 0
        Me.chkUsersOpen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUsersOpen.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUsersOpen.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUsersOpen.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'txtUser_Note
        '
        Me.txtUser_Note.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_Note.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser_Note.DefaultText = ""
        Me.txtUser_Note.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser_Note.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser_Note.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Note.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Note.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Note.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser_Note.ForeColor = System.Drawing.Color.Black
        Me.txtUser_Note.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Note.Location = New System.Drawing.Point(1090, 302)
        Me.txtUser_Note.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser_Note.Multiline = True
        Me.txtUser_Note.Name = "txtUser_Note"
        Me.txtUser_Note.PlaceholderText = ""
        Me.txtUser_Note.SelectedText = ""
        Me.txtUser_Note.Size = New System.Drawing.Size(377, 143)
        Me.txtUser_Note.TabIndex = 5563
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(1321, 259)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 37)
        Me.Label3.TabIndex = 5558
        Me.Label3.Text = "الملاحظات"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(1290, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 37)
        Me.Label2.TabIndex = 5557
        Me.Label2.Text = "اسم الموظف"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(1292, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 37)
        Me.Label1.TabIndex = 5556
        Me.Label1.Text = "كود الموظف"
        '
        'btn_clean
        '
        Me.btn_clean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_clean.AutoSize = True
        Me.btn_clean.Location = New System.Drawing.Point(1225, 2)
        Me.btn_clean.Name = "btn_clean"
        Me.btn_clean.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_clean.Size = New System.Drawing.Size(38, 36)
        Me.btn_clean.TabIndex = 44
        '
        'cmbSearchField
        '
        Me.cmbSearchField.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSearchField.BackColor = System.Drawing.Color.Transparent
        Me.cmbSearchField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchField.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSearchField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSearchField.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbSearchField.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbSearchField.ItemHeight = 30
        Me.cmbSearchField.Location = New System.Drawing.Point(1071, 461)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(225, 36)
        Me.cmbSearchField.TabIndex = 2
        Me.cmbSearchField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(543, 454)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "ابحث عن موظف"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(522, 49)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUser_Name
        '
        Me.txtUser_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_Name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser_Name.DefaultText = ""
        Me.txtUser_Name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser_Name.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser_Name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Name.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser_Name.ForeColor = System.Drawing.Color.Black
        Me.txtUser_Name.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Name.Location = New System.Drawing.Point(1090, 194)
        Me.txtUser_Name.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser_Name.Name = "txtUser_Name"
        Me.txtUser_Name.PlaceholderText = ""
        Me.txtUser_Name.SelectedText = ""
        Me.txtUser_Name.Size = New System.Drawing.Size(377, 45)
        Me.txtUser_Name.TabIndex = 4
        Me.txtUser_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUser_Code
        '
        Me.txtUser_Code.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_Code.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser_Code.DefaultText = ""
        Me.txtUser_Code.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser_Code.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser_Code.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Code.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Code.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Code.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser_Code.ForeColor = System.Drawing.Color.Black
        Me.txtUser_Code.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Code.Location = New System.Drawing.Point(1090, 96)
        Me.txtUser_Code.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser_Code.Name = "txtUser_Code"
        Me.txtUser_Code.PlaceholderText = ""
        Me.txtUser_Code.ReadOnly = True
        Me.txtUser_Code.SelectedText = ""
        Me.txtUser_Code.Size = New System.Drawing.Size(377, 45)
        Me.txtUser_Code.TabIndex = 3
        Me.txtUser_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Staff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1500, 950)
        Me.Controls.Add(Me.dgv_Staff)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Staff"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Staff"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.dgv_Staff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GroupControl12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl12.ResumeLayout(False)
        Me.GroupControl12.PerformLayout()
        CType(Me.GroupControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl11.ResumeLayout(False)
        Me.GroupControl11.PerformLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        Me.GroupControl6.PerformLayout()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl7.ResumeLayout(False)
        Me.GroupControl7.PerformLayout()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl8.ResumeLayout(False)
        Me.GroupControl8.PerformLayout()
        CType(Me.GroupControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl9.ResumeLayout(False)
        Me.GroupControl9.PerformLayout()
        CType(Me.GroupControl10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl10.ResumeLayout(False)
        Me.GroupControl10.PerformLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        Me.GroupControl5.PerformLayout()
        CType(Me.grp_ProductUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_ProductUnits.ResumeLayout(False)
        Me.grp_ProductUnits.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.grp_Categories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Categories.ResumeLayout(False)
        Me.grp_Categories.PerformLayout()
        CType(Me.grp_Users, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Users.ResumeLayout(False)
        Me.grp_Users.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dgv_Staff As DataGridView
    Friend WithEvents PanelControl1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNew As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents txtUser_Note As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_clean As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtUser_Name As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtUser_Code As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupControl12 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label48 As Label
    Friend WithEvents chkbackupDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label49 As Label
    Friend WithEvents chkbackupEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label50 As Label
    Friend WithEvents chkbackupAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label51 As Label
    Friend WithEvents chkbackupOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents GroupControl11 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label44 As Label
    Friend WithEvents chkSettingsDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label45 As Label
    Friend WithEvents chkSettingsEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label46 As Label
    Friend WithEvents chkSettingsAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label47 As Label
    Friend WithEvents chkSettingsOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents GroupControl6 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label24 As Label
    Friend WithEvents chkStockDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label25 As Label
    Friend WithEvents chkStockEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label26 As Label
    Friend WithEvents chkStockAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label27 As Label
    Friend WithEvents chkStockOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents GroupControl7 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label28 As Label
    Friend WithEvents chkReportsDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label29 As Label
    Friend WithEvents chkReportsEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label30 As Label
    Friend WithEvents chkReportsAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label31 As Label
    Friend WithEvents chkReportsOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents GroupControl8 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label32 As Label
    Friend WithEvents chkPurchasesDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label33 As Label
    Friend WithEvents chkPurchasesEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label34 As Label
    Friend WithEvents chkPurchasesAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label35 As Label
    Friend WithEvents chkPurchasesOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents GroupControl9 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label36 As Label
    Friend WithEvents chkSuppliersDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label37 As Label
    Friend WithEvents chkSuppliersEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label38 As Label
    Friend WithEvents chkSuppliersAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label39 As Label
    Friend WithEvents chkSuppliersOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents GroupControl10 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label40 As Label
    Friend WithEvents chkSalesDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label41 As Label
    Friend WithEvents chkSalesEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label42 As Label
    Friend WithEvents chkSalesAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label43 As Label
    Friend WithEvents chkSalesOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents GroupControl5 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents chkCustomerDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label21 As Label
    Friend WithEvents chkCustomerEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label22 As Label
    Friend WithEvents chkCustomerAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label23 As Label
    Friend WithEvents chkCustomerOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents grp_ProductUnits As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents chkProductUnitsDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label17 As Label
    Friend WithEvents chkProductUnitsEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label18 As Label
    Friend WithEvents chkProductUnitsAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label19 As Label
    Friend WithEvents chkProductUnitsOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents GroupControl3 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkProductsDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label13 As Label
    Friend WithEvents chkProductsEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label14 As Label
    Friend WithEvents chkProductsAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label15 As Label
    Friend WithEvents chkProductsOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents grp_Categories As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chkCategoriesDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label9 As Label
    Friend WithEvents chkCategoriesEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label10 As Label
    Friend WithEvents chkCategoriesAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label11 As Label
    Friend WithEvents chkCategoriesOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents grp_Users As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chkUsersDelete As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label6 As Label
    Friend WithEvents chkUsersEdit As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label5 As Label
    Friend WithEvents chkUsersAdd As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label4 As Label
    Friend WithEvents chkUsersOpen As Guna.UI2.WinForms.Guna2ToggleSwitch
End Class
