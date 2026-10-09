<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployees
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployees))
        Me.dgvEmployees = New System.Windows.Forms.DataGridView()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2TabControl1 = New Guna.UI2.WinForms.Guna2TabControl()
        Me.tabPageBasic = New System.Windows.Forms.TabPage()
        Me.dtpBirthDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbGender = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAddress = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEmail = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPhone2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPhone = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNationalID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEnglishName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtArabicName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmployeeCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.tabPageJob = New System.Windows.Forms.TabPage()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbEmployeeStatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtFingerprintCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dtpContractEndDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpHireDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbJobTitle = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbDepartment = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbBranch = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnAddBranchesForm = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddDepartmentForm = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddJobTitleForm = New Guna.UI2.WinForms.Guna2Button()
        Me.tabPageSalary = New System.Windows.Forms.TabPage()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtOvertimeRate = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tgOvertimeAllowed = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtInsuranceAmount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tgInsuranceStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtOtherAllowance = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtHousingAllowance = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTransAllowance = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtBasicSalary = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbSalarySystem = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDailyWorkingHours = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dtpCheckOutTime = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpCheckInTime = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnAddSalarySystemForm = New Guna.UI2.WinForms.Guna2Button()
        Me.tabPageAttachments = New System.Windows.Forms.TabPage()
        Me.lblCvStatus = New System.Windows.Forms.Label()
        Me.picNationalBack = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.picNationalFront = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.btnRemovePhoto = New Guna.UI2.WinForms.Guna2Button()
        Me.btnUploadPhoto = New Guna.UI2.WinForms.Guna2Button()
        Me.picEmployee = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnUpdate = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me._searchTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.Guna2TabControl1.SuspendLayout()
        Me.tabPageBasic.SuspendLayout()
        Me.tabPageJob.SuspendLayout()
        Me.tabPageSalary.SuspendLayout()
        Me.tabPageAttachments.SuspendLayout()
        CType(Me.picNationalBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNationalFront, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEmployees
        '
        Me.dgvEmployees.AllowUserToResizeColumns = False
        Me.dgvEmployees.AllowUserToResizeRows = False
        Me.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEmployees.Location = New System.Drawing.Point(0, 460)
        Me.dgvEmployees.Name = "dgvEmployees"
        Me.dgvEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvEmployees.RowTemplate.Height = 40
        Me.dgvEmployees.Size = New System.Drawing.Size(1434, 340)
        Me.dgvEmployees.TabIndex = 40
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
        Me.panelHeader.Size = New System.Drawing.Size(1434, 70)
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
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(120, 44)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الموظفين"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'Guna2TabControl1
        '
        Me.Guna2TabControl1.Controls.Add(Me.tabPageBasic)
        Me.Guna2TabControl1.Controls.Add(Me.tabPageJob)
        Me.Guna2TabControl1.Controls.Add(Me.tabPageSalary)
        Me.Guna2TabControl1.Controls.Add(Me.tabPageAttachments)
        Me.Guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2TabControl1.ItemSize = New System.Drawing.Size(180, 40)
        Me.Guna2TabControl1.Location = New System.Drawing.Point(0, 70)
        Me.Guna2TabControl1.Name = "Guna2TabControl1"
        Me.Guna2TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Guna2TabControl1.SelectedIndex = 0
        Me.Guna2TabControl1.Size = New System.Drawing.Size(1434, 326)
        Me.Guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty
        Me.Guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Guna2TabControl1.TabButtonHoverState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.Guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White
        Me.Guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty
        Me.Guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Guna2TabControl1.TabButtonIdleState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.Guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.Guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty
        Me.Guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Guna2TabControl1.TabButtonSelectedState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.Guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White
        Me.Guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TabControl1.TabButtonSize = New System.Drawing.Size(180, 40)
        Me.Guna2TabControl1.TabIndex = 41
        Me.Guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop
        '
        'tabPageBasic
        '
        Me.tabPageBasic.Controls.Add(Me.dtpBirthDate)
        Me.tabPageBasic.Controls.Add(Me.Label10)
        Me.tabPageBasic.Controls.Add(Me.Label9)
        Me.tabPageBasic.Controls.Add(Me.cmbGender)
        Me.tabPageBasic.Controls.Add(Me.Label8)
        Me.tabPageBasic.Controls.Add(Me.txtAddress)
        Me.tabPageBasic.Controls.Add(Me.Label7)
        Me.tabPageBasic.Controls.Add(Me.txtEmail)
        Me.tabPageBasic.Controls.Add(Me.Label6)
        Me.tabPageBasic.Controls.Add(Me.txtPhone2)
        Me.tabPageBasic.Controls.Add(Me.Label5)
        Me.tabPageBasic.Controls.Add(Me.txtPhone)
        Me.tabPageBasic.Controls.Add(Me.Label4)
        Me.tabPageBasic.Controls.Add(Me.txtNationalID)
        Me.tabPageBasic.Controls.Add(Me.Label3)
        Me.tabPageBasic.Controls.Add(Me.txtEnglishName)
        Me.tabPageBasic.Controls.Add(Me.Label2)
        Me.tabPageBasic.Controls.Add(Me.txtArabicName)
        Me.tabPageBasic.Controls.Add(Me.Label1)
        Me.tabPageBasic.Controls.Add(Me.txtEmployeeCode)
        Me.tabPageBasic.Location = New System.Drawing.Point(4, 44)
        Me.tabPageBasic.Name = "tabPageBasic"
        Me.tabPageBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageBasic.Size = New System.Drawing.Size(1426, 278)
        Me.tabPageBasic.TabIndex = 0
        Me.tabPageBasic.Text = "البيانات الشخصية والأساسية"
        Me.tabPageBasic.UseVisualStyleBackColor = True
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.BorderRadius = 8
        Me.dtpBirthDate.Checked = True
        Me.dtpBirthDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpBirthDate.Location = New System.Drawing.Point(223, 162)
        Me.dtpBirthDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpBirthDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.Size = New System.Drawing.Size(240, 36)
        Me.dtpBirthDate.TabIndex = 5603
        Me.dtpBirthDate.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(473, 162)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 36)
        Me.Label10.TabIndex = 5602
        Me.Label10.Text = "تاريخ الميلاد"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(473, 212)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 36)
        Me.Label9.TabIndex = 5601
        Me.Label9.Text = "الجنس (ذكر / أنثى)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbGender
        '
        Me.cmbGender.BackColor = System.Drawing.Color.Transparent
        Me.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbGender.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbGender.ForeColor = System.Drawing.Color.Black
        Me.cmbGender.ItemHeight = 30
        Me.cmbGender.Location = New System.Drawing.Point(223, 212)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(240, 36)
        Me.cmbGender.TabIndex = 5600
        Me.cmbGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(473, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 36)
        Me.Label8.TabIndex = 5599
        Me.Label8.Text = "العنوان"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress
        '
        Me.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAddress.DefaultText = ""
        Me.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAddress.Location = New System.Drawing.Point(223, 112)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.PlaceholderText = ""
        Me.txtAddress.SelectedText = ""
        Me.txtAddress.Size = New System.Drawing.Size(240, 36)
        Me.txtAddress.TabIndex = 5598
        Me.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(473, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 36)
        Me.Label7.TabIndex = 5597
        Me.Label7.Text = "البريد الإلكتروني"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmail
        '
        Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmail.DefaultText = ""
        Me.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmail.Location = New System.Drawing.Point(223, 62)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.PlaceholderText = ""
        Me.txtEmail.SelectedText = ""
        Me.txtEmail.Size = New System.Drawing.Size(240, 36)
        Me.txtEmail.TabIndex = 5596
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(473, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 36)
        Me.Label6.TabIndex = 5595
        Me.Label6.Text = "رقم الهاتف 2"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPhone2
        '
        Me.txtPhone2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhone2.DefaultText = ""
        Me.txtPhone2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPhone2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPhone2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPhone2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtPhone2.ForeColor = System.Drawing.Color.Black
        Me.txtPhone2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPhone2.Location = New System.Drawing.Point(223, 12)
        Me.txtPhone2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.PlaceholderText = ""
        Me.txtPhone2.SelectedText = ""
        Me.txtPhone2.Size = New System.Drawing.Size(240, 36)
        Me.txtPhone2.TabIndex = 5594
        Me.txtPhone2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(1123, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 36)
        Me.Label5.TabIndex = 5593
        Me.Label5.Text = "رقم الهاتف *"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPhone
        '
        Me.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhone.DefaultText = ""
        Me.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtPhone.ForeColor = System.Drawing.Color.Black
        Me.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPhone.Location = New System.Drawing.Point(873, 212)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.PlaceholderText = ""
        Me.txtPhone.SelectedText = ""
        Me.txtPhone.Size = New System.Drawing.Size(240, 36)
        Me.txtPhone.TabIndex = 5592
        Me.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(1123, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 36)
        Me.Label4.TabIndex = 5591
        Me.Label4.Text = "الرقم القومي"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNationalID
        '
        Me.txtNationalID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNationalID.DefaultText = ""
        Me.txtNationalID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNationalID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNationalID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNationalID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNationalID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNationalID.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNationalID.ForeColor = System.Drawing.Color.Black
        Me.txtNationalID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNationalID.Location = New System.Drawing.Point(873, 162)
        Me.txtNationalID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNationalID.Name = "txtNationalID"
        Me.txtNationalID.PlaceholderText = ""
        Me.txtNationalID.SelectedText = ""
        Me.txtNationalID.Size = New System.Drawing.Size(240, 36)
        Me.txtNationalID.TabIndex = 5590
        Me.txtNationalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(1123, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 36)
        Me.Label3.TabIndex = 5589
        Me.Label3.Text = "الاسم انجليزي"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnglishName
        '
        Me.txtEnglishName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEnglishName.DefaultText = ""
        Me.txtEnglishName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtEnglishName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtEnglishName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEnglishName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEnglishName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEnglishName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtEnglishName.ForeColor = System.Drawing.Color.Black
        Me.txtEnglishName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEnglishName.Location = New System.Drawing.Point(873, 112)
        Me.txtEnglishName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEnglishName.Name = "txtEnglishName"
        Me.txtEnglishName.PlaceholderText = ""
        Me.txtEnglishName.SelectedText = ""
        Me.txtEnglishName.Size = New System.Drawing.Size(240, 36)
        Me.txtEnglishName.TabIndex = 5588
        Me.txtEnglishName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(1123, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 36)
        Me.Label2.TabIndex = 5587
        Me.Label2.Text = "الاسم عربي *"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtArabicName
        '
        Me.txtArabicName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtArabicName.DefaultText = ""
        Me.txtArabicName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtArabicName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtArabicName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtArabicName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtArabicName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtArabicName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtArabicName.ForeColor = System.Drawing.Color.Black
        Me.txtArabicName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtArabicName.Location = New System.Drawing.Point(873, 62)
        Me.txtArabicName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtArabicName.Name = "txtArabicName"
        Me.txtArabicName.PlaceholderText = ""
        Me.txtArabicName.SelectedText = ""
        Me.txtArabicName.Size = New System.Drawing.Size(240, 36)
        Me.txtArabicName.TabIndex = 5586
        Me.txtArabicName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(1123, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 36)
        Me.Label1.TabIndex = 5585
        Me.Label1.Text = "كود الموظف *"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmployeeCode.DefaultText = ""
        Me.txtEmployeeCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtEmployeeCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtEmployeeCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmployeeCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmployeeCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmployeeCode.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.txtEmployeeCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmployeeCode.Location = New System.Drawing.Point(873, 12)
        Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.PlaceholderText = ""
        Me.txtEmployeeCode.SelectedText = ""
        Me.txtEmployeeCode.Size = New System.Drawing.Size(240, 36)
        Me.txtEmployeeCode.TabIndex = 5584
        Me.txtEmployeeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tabPageJob
        '
        Me.tabPageJob.Controls.Add(Me.Label18)
        Me.tabPageJob.Controls.Add(Me.txtNotes)
        Me.tabPageJob.Controls.Add(Me.Label17)
        Me.tabPageJob.Controls.Add(Me.cmbEmployeeStatus)
        Me.tabPageJob.Controls.Add(Me.Label16)
        Me.tabPageJob.Controls.Add(Me.txtFingerprintCode)
        Me.tabPageJob.Controls.Add(Me.dtpContractEndDate)
        Me.tabPageJob.Controls.Add(Me.Label15)
        Me.tabPageJob.Controls.Add(Me.dtpHireDate)
        Me.tabPageJob.Controls.Add(Me.Label14)
        Me.tabPageJob.Controls.Add(Me.Label13)
        Me.tabPageJob.Controls.Add(Me.cmbJobTitle)
        Me.tabPageJob.Controls.Add(Me.Label12)
        Me.tabPageJob.Controls.Add(Me.cmbDepartment)
        Me.tabPageJob.Controls.Add(Me.Label11)
        Me.tabPageJob.Controls.Add(Me.cmbBranch)
        Me.tabPageJob.Controls.Add(Me.btnAddBranchesForm)
        Me.tabPageJob.Controls.Add(Me.btnAddDepartmentForm)
        Me.tabPageJob.Controls.Add(Me.btnAddJobTitleForm)
        Me.tabPageJob.Location = New System.Drawing.Point(4, 44)
        Me.tabPageJob.Name = "tabPageJob"
        Me.tabPageJob.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageJob.Size = New System.Drawing.Size(1426, 278)
        Me.tabPageJob.TabIndex = 1
        Me.tabPageJob.Text = "البيانات الوظيفية"
        Me.tabPageJob.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(1123, 196)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(140, 36)
        Me.Label18.TabIndex = 5613
        Me.Label18.Text = "الملاحظات"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotes.DefaultText = ""
        Me.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(223, 196)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(890, 72)
        Me.txtNotes.TabIndex = 5612
        Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(1123, 150)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(140, 36)
        Me.Label17.TabIndex = 5611
        Me.Label17.Text = "حالة الموظف"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbEmployeeStatus
        '
        Me.cmbEmployeeStatus.BackColor = System.Drawing.Color.Transparent
        Me.cmbEmployeeStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEmployeeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmployeeStatus.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbEmployeeStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbEmployeeStatus.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbEmployeeStatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEmployeeStatus.ItemHeight = 30
        Me.cmbEmployeeStatus.Location = New System.Drawing.Point(873, 150)
        Me.cmbEmployeeStatus.Name = "cmbEmployeeStatus"
        Me.cmbEmployeeStatus.Size = New System.Drawing.Size(240, 36)
        Me.cmbEmployeeStatus.TabIndex = 5610
        Me.cmbEmployeeStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(473, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(140, 36)
        Me.Label16.TabIndex = 5609
        Me.Label16.Text = "كود البصمة"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFingerprintCode
        '
        Me.txtFingerprintCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFingerprintCode.DefaultText = ""
        Me.txtFingerprintCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtFingerprintCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtFingerprintCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtFingerprintCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtFingerprintCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFingerprintCode.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtFingerprintCode.ForeColor = System.Drawing.Color.Black
        Me.txtFingerprintCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFingerprintCode.Location = New System.Drawing.Point(223, 104)
        Me.txtFingerprintCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFingerprintCode.Name = "txtFingerprintCode"
        Me.txtFingerprintCode.PlaceholderText = ""
        Me.txtFingerprintCode.SelectedText = ""
        Me.txtFingerprintCode.Size = New System.Drawing.Size(240, 36)
        Me.txtFingerprintCode.TabIndex = 5608
        Me.txtFingerprintCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpContractEndDate
        '
        Me.dtpContractEndDate.Checked = True
        Me.dtpContractEndDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpContractEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpContractEndDate.Location = New System.Drawing.Point(223, 58)
        Me.dtpContractEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpContractEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpContractEndDate.Name = "dtpContractEndDate"
        Me.dtpContractEndDate.Size = New System.Drawing.Size(240, 36)
        Me.dtpContractEndDate.TabIndex = 5607
        Me.dtpContractEndDate.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(473, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(140, 36)
        Me.Label15.TabIndex = 5606
        Me.Label15.Text = "تاريخ انتهاء العقد"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpHireDate
        '
        Me.dtpHireDate.Checked = True
        Me.dtpHireDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpHireDate.Location = New System.Drawing.Point(223, 12)
        Me.dtpHireDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpHireDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpHireDate.Name = "dtpHireDate"
        Me.dtpHireDate.Size = New System.Drawing.Size(240, 36)
        Me.dtpHireDate.TabIndex = 5605
        Me.dtpHireDate.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(473, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(140, 36)
        Me.Label14.TabIndex = 5604
        Me.Label14.Text = "تاريخ التعيين"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(1123, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 36)
        Me.Label13.TabIndex = 5602
        Me.Label13.Text = "المسمى الوظيفي *"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbJobTitle
        '
        Me.cmbJobTitle.BackColor = System.Drawing.Color.Transparent
        Me.cmbJobTitle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJobTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJobTitle.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbJobTitle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbJobTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbJobTitle.ForeColor = System.Drawing.Color.Black
        Me.cmbJobTitle.ItemHeight = 30
        Me.cmbJobTitle.Location = New System.Drawing.Point(873, 104)
        Me.cmbJobTitle.Name = "cmbJobTitle"
        Me.cmbJobTitle.Size = New System.Drawing.Size(240, 36)
        Me.cmbJobTitle.TabIndex = 5601
        Me.cmbJobTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(1123, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 36)
        Me.Label12.TabIndex = 5600
        Me.Label12.Text = "القسم *"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDepartment
        '
        Me.cmbDepartment.BackColor = System.Drawing.Color.Transparent
        Me.cmbDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDepartment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbDepartment.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbDepartment.ForeColor = System.Drawing.Color.Black
        Me.cmbDepartment.ItemHeight = 30
        Me.cmbDepartment.Location = New System.Drawing.Point(873, 58)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(240, 36)
        Me.cmbDepartment.TabIndex = 5599
        Me.cmbDepartment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(1123, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 36)
        Me.Label11.TabIndex = 5598
        Me.Label11.Text = "الفرع"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.Transparent
        Me.cmbBranch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBranch.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBranch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbBranch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbBranch.ForeColor = System.Drawing.Color.Black
        Me.cmbBranch.ItemHeight = 30
        Me.cmbBranch.Location = New System.Drawing.Point(873, 12)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(240, 36)
        Me.cmbBranch.TabIndex = 5597
        Me.cmbBranch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAddBranchesForm
        '
        Me.btnAddBranchesForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddBranchesForm.BorderRadius = 8
        Me.btnAddBranchesForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddBranchesForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddBranchesForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddBranchesForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddBranchesForm.FillColor = System.Drawing.Color.Empty
        Me.btnAddBranchesForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddBranchesForm.ForeColor = System.Drawing.Color.White
        Me.btnAddBranchesForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddBranchesForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddBranchesForm.Location = New System.Drawing.Point(827, 12)
        Me.btnAddBranchesForm.Name = "btnAddBranchesForm"
        Me.btnAddBranchesForm.Size = New System.Drawing.Size(38, 36)
        Me.btnAddBranchesForm.TabIndex = 5638
        '
        'btnAddDepartmentForm
        '
        Me.btnAddDepartmentForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddDepartmentForm.BorderRadius = 8
        Me.btnAddDepartmentForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddDepartmentForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddDepartmentForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddDepartmentForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddDepartmentForm.FillColor = System.Drawing.Color.Empty
        Me.btnAddDepartmentForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddDepartmentForm.ForeColor = System.Drawing.Color.White
        Me.btnAddDepartmentForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddDepartmentForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddDepartmentForm.Location = New System.Drawing.Point(827, 58)
        Me.btnAddDepartmentForm.Name = "btnAddDepartmentForm"
        Me.btnAddDepartmentForm.Size = New System.Drawing.Size(38, 36)
        Me.btnAddDepartmentForm.TabIndex = 5637
        '
        'btnAddJobTitleForm
        '
        Me.btnAddJobTitleForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddJobTitleForm.BorderRadius = 8
        Me.btnAddJobTitleForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddJobTitleForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddJobTitleForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddJobTitleForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddJobTitleForm.FillColor = System.Drawing.Color.Empty
        Me.btnAddJobTitleForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddJobTitleForm.ForeColor = System.Drawing.Color.White
        Me.btnAddJobTitleForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddJobTitleForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddJobTitleForm.Location = New System.Drawing.Point(827, 104)
        Me.btnAddJobTitleForm.Name = "btnAddJobTitleForm"
        Me.btnAddJobTitleForm.Size = New System.Drawing.Size(38, 36)
        Me.btnAddJobTitleForm.TabIndex = 5636
        '
        'tabPageSalary
        '
        Me.tabPageSalary.Controls.Add(Me.Label31)
        Me.tabPageSalary.Controls.Add(Me.tgStatus)
        Me.tabPageSalary.Controls.Add(Me.Label30)
        Me.tabPageSalary.Controls.Add(Me.txtOvertimeRate)
        Me.tabPageSalary.Controls.Add(Me.Label29)
        Me.tabPageSalary.Controls.Add(Me.tgOvertimeAllowed)
        Me.tabPageSalary.Controls.Add(Me.Label28)
        Me.tabPageSalary.Controls.Add(Me.txtInsuranceAmount)
        Me.tabPageSalary.Controls.Add(Me.Label27)
        Me.tabPageSalary.Controls.Add(Me.tgInsuranceStatus)
        Me.tabPageSalary.Controls.Add(Me.Label26)
        Me.tabPageSalary.Controls.Add(Me.txtOtherAllowance)
        Me.tabPageSalary.Controls.Add(Me.Label25)
        Me.tabPageSalary.Controls.Add(Me.txtHousingAllowance)
        Me.tabPageSalary.Controls.Add(Me.Label24)
        Me.tabPageSalary.Controls.Add(Me.txtTransAllowance)
        Me.tabPageSalary.Controls.Add(Me.Label23)
        Me.tabPageSalary.Controls.Add(Me.txtBasicSalary)
        Me.tabPageSalary.Controls.Add(Me.Label22)
        Me.tabPageSalary.Controls.Add(Me.cmbSalarySystem)
        Me.tabPageSalary.Controls.Add(Me.Label21)
        Me.tabPageSalary.Controls.Add(Me.txtDailyWorkingHours)
        Me.tabPageSalary.Controls.Add(Me.dtpCheckOutTime)
        Me.tabPageSalary.Controls.Add(Me.Label20)
        Me.tabPageSalary.Controls.Add(Me.dtpCheckInTime)
        Me.tabPageSalary.Controls.Add(Me.Label19)
        Me.tabPageSalary.Controls.Add(Me.btnAddSalarySystemForm)
        Me.tabPageSalary.Location = New System.Drawing.Point(4, 44)
        Me.tabPageSalary.Name = "tabPageSalary"
        Me.tabPageSalary.Size = New System.Drawing.Size(1426, 278)
        Me.tabPageSalary.TabIndex = 2
        Me.tabPageSalary.Text = "المواعيد والماليات"
        Me.tabPageSalary.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label31.Location = New System.Drawing.Point(1246, 212)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 36)
        Me.Label31.TabIndex = 5633
        Me.Label31.Text = "نشط"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tgStatus
        '
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Location = New System.Drawing.Point(1176, 216)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(60, 28)
        Me.tgStatus.TabIndex = 5632
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(306, 162)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(120, 36)
        Me.Label30.TabIndex = 5631
        Me.Label30.Text = "أجر الإضافي"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOvertimeRate
        '
        Me.txtOvertimeRate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOvertimeRate.DefaultText = ""
        Me.txtOvertimeRate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtOvertimeRate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtOvertimeRate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOvertimeRate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOvertimeRate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOvertimeRate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtOvertimeRate.ForeColor = System.Drawing.Color.Black
        Me.txtOvertimeRate.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOvertimeRate.Location = New System.Drawing.Point(76, 162)
        Me.txtOvertimeRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOvertimeRate.Name = "txtOvertimeRate"
        Me.txtOvertimeRate.PlaceholderText = ""
        Me.txtOvertimeRate.SelectedText = ""
        Me.txtOvertimeRate.Size = New System.Drawing.Size(220, 36)
        Me.txtOvertimeRate.TabIndex = 5630
        Me.txtOvertimeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label29.Location = New System.Drawing.Point(306, 112)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(120, 36)
        Me.Label29.TabIndex = 5629
        Me.Label29.Text = "وقت إضافي؟"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tgOvertimeAllowed
        '
        Me.tgOvertimeAllowed.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgOvertimeAllowed.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgOvertimeAllowed.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgOvertimeAllowed.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgOvertimeAllowed.Location = New System.Drawing.Point(236, 116)
        Me.tgOvertimeAllowed.Name = "tgOvertimeAllowed"
        Me.tgOvertimeAllowed.Size = New System.Drawing.Size(60, 28)
        Me.tgOvertimeAllowed.TabIndex = 5628
        Me.tgOvertimeAllowed.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgOvertimeAllowed.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgOvertimeAllowed.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgOvertimeAllowed.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label28.Location = New System.Drawing.Point(306, 62)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(120, 36)
        Me.Label28.TabIndex = 5627
        Me.Label28.Text = "قيمة التأمين"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInsuranceAmount
        '
        Me.txtInsuranceAmount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInsuranceAmount.DefaultText = ""
        Me.txtInsuranceAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtInsuranceAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtInsuranceAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInsuranceAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInsuranceAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInsuranceAmount.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtInsuranceAmount.ForeColor = System.Drawing.Color.Black
        Me.txtInsuranceAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInsuranceAmount.Location = New System.Drawing.Point(76, 62)
        Me.txtInsuranceAmount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtInsuranceAmount.Name = "txtInsuranceAmount"
        Me.txtInsuranceAmount.PlaceholderText = ""
        Me.txtInsuranceAmount.SelectedText = ""
        Me.txtInsuranceAmount.Size = New System.Drawing.Size(220, 36)
        Me.txtInsuranceAmount.TabIndex = 5626
        Me.txtInsuranceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label27.Location = New System.Drawing.Point(306, 12)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(120, 36)
        Me.Label27.TabIndex = 5625
        Me.Label27.Text = "مؤمن عليه؟"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tgInsuranceStatus
        '
        Me.tgInsuranceStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgInsuranceStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgInsuranceStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgInsuranceStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgInsuranceStatus.Location = New System.Drawing.Point(236, 16)
        Me.tgInsuranceStatus.Name = "tgInsuranceStatus"
        Me.tgInsuranceStatus.Size = New System.Drawing.Size(60, 28)
        Me.tgInsuranceStatus.TabIndex = 5624
        Me.tgInsuranceStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgInsuranceStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgInsuranceStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgInsuranceStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(776, 162)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(120, 36)
        Me.Label26.TabIndex = 5621
        Me.Label26.Text = "بدلات أخرى"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOtherAllowance
        '
        Me.txtOtherAllowance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOtherAllowance.DefaultText = ""
        Me.txtOtherAllowance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtOtherAllowance.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtOtherAllowance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOtherAllowance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOtherAllowance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOtherAllowance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtOtherAllowance.ForeColor = System.Drawing.Color.Black
        Me.txtOtherAllowance.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOtherAllowance.Location = New System.Drawing.Point(546, 162)
        Me.txtOtherAllowance.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOtherAllowance.Name = "txtOtherAllowance"
        Me.txtOtherAllowance.PlaceholderText = ""
        Me.txtOtherAllowance.SelectedText = ""
        Me.txtOtherAllowance.Size = New System.Drawing.Size(220, 36)
        Me.txtOtherAllowance.TabIndex = 5620
        Me.txtOtherAllowance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(776, 112)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(120, 36)
        Me.Label25.TabIndex = 5619
        Me.Label25.Text = "بدل السكن"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHousingAllowance
        '
        Me.txtHousingAllowance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHousingAllowance.DefaultText = ""
        Me.txtHousingAllowance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtHousingAllowance.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtHousingAllowance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtHousingAllowance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtHousingAllowance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtHousingAllowance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtHousingAllowance.ForeColor = System.Drawing.Color.Black
        Me.txtHousingAllowance.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtHousingAllowance.Location = New System.Drawing.Point(546, 112)
        Me.txtHousingAllowance.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtHousingAllowance.Name = "txtHousingAllowance"
        Me.txtHousingAllowance.PlaceholderText = ""
        Me.txtHousingAllowance.SelectedText = ""
        Me.txtHousingAllowance.Size = New System.Drawing.Size(220, 36)
        Me.txtHousingAllowance.TabIndex = 5618
        Me.txtHousingAllowance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(776, 62)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(120, 36)
        Me.Label24.TabIndex = 5617
        Me.Label24.Text = "بدل الانتقال"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTransAllowance
        '
        Me.txtTransAllowance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTransAllowance.DefaultText = ""
        Me.txtTransAllowance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTransAllowance.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTransAllowance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTransAllowance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTransAllowance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTransAllowance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTransAllowance.ForeColor = System.Drawing.Color.Black
        Me.txtTransAllowance.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTransAllowance.Location = New System.Drawing.Point(546, 62)
        Me.txtTransAllowance.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTransAllowance.Name = "txtTransAllowance"
        Me.txtTransAllowance.PlaceholderText = ""
        Me.txtTransAllowance.SelectedText = ""
        Me.txtTransAllowance.Size = New System.Drawing.Size(220, 36)
        Me.txtTransAllowance.TabIndex = 5616
        Me.txtTransAllowance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(776, 12)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 36)
        Me.Label23.TabIndex = 5615
        Me.Label23.Text = "الراتب الأساسي"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBasicSalary
        '
        Me.txtBasicSalary.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBasicSalary.DefaultText = ""
        Me.txtBasicSalary.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBasicSalary.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBasicSalary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBasicSalary.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBasicSalary.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBasicSalary.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtBasicSalary.ForeColor = System.Drawing.Color.Black
        Me.txtBasicSalary.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBasicSalary.Location = New System.Drawing.Point(546, 12)
        Me.txtBasicSalary.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBasicSalary.Name = "txtBasicSalary"
        Me.txtBasicSalary.PlaceholderText = ""
        Me.txtBasicSalary.SelectedText = ""
        Me.txtBasicSalary.Size = New System.Drawing.Size(220, 36)
        Me.txtBasicSalary.TabIndex = 5614
        Me.txtBasicSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(1246, 162)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(120, 36)
        Me.Label22.TabIndex = 5613
        Me.Label22.Text = "نظام الرواتب *"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSalarySystem
        '
        Me.cmbSalarySystem.BackColor = System.Drawing.Color.Transparent
        Me.cmbSalarySystem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSalarySystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalarySystem.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSalarySystem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSalarySystem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbSalarySystem.ForeColor = System.Drawing.Color.Black
        Me.cmbSalarySystem.ItemHeight = 30
        Me.cmbSalarySystem.Location = New System.Drawing.Point(1016, 162)
        Me.cmbSalarySystem.Name = "cmbSalarySystem"
        Me.cmbSalarySystem.Size = New System.Drawing.Size(220, 36)
        Me.cmbSalarySystem.TabIndex = 5612
        Me.cmbSalarySystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(1246, 112)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(120, 36)
        Me.Label21.TabIndex = 5611
        Me.Label21.Text = "ساعات العمل"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDailyWorkingHours
        '
        Me.txtDailyWorkingHours.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDailyWorkingHours.DefaultText = ""
        Me.txtDailyWorkingHours.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDailyWorkingHours.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDailyWorkingHours.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDailyWorkingHours.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDailyWorkingHours.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDailyWorkingHours.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDailyWorkingHours.ForeColor = System.Drawing.Color.Black
        Me.txtDailyWorkingHours.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDailyWorkingHours.Location = New System.Drawing.Point(1016, 112)
        Me.txtDailyWorkingHours.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDailyWorkingHours.Name = "txtDailyWorkingHours"
        Me.txtDailyWorkingHours.PlaceholderText = ""
        Me.txtDailyWorkingHours.SelectedText = ""
        Me.txtDailyWorkingHours.Size = New System.Drawing.Size(220, 36)
        Me.txtDailyWorkingHours.TabIndex = 5610
        Me.txtDailyWorkingHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpCheckOutTime
        '
        Me.dtpCheckOutTime.BorderRadius = 8
        Me.dtpCheckOutTime.Checked = True
        Me.dtpCheckOutTime.CustomFormat = "HH:mm:ss"
        Me.dtpCheckOutTime.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpCheckOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCheckOutTime.Location = New System.Drawing.Point(1016, 62)
        Me.dtpCheckOutTime.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpCheckOutTime.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpCheckOutTime.Name = "dtpCheckOutTime"
        Me.dtpCheckOutTime.ShowUpDown = True
        Me.dtpCheckOutTime.Size = New System.Drawing.Size(220, 36)
        Me.dtpCheckOutTime.TabIndex = 5607
        Me.dtpCheckOutTime.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(1246, 62)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 36)
        Me.Label20.TabIndex = 5606
        Me.Label20.Text = "وقت الانصراف"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpCheckInTime
        '
        Me.dtpCheckInTime.BorderRadius = 8
        Me.dtpCheckInTime.Checked = True
        Me.dtpCheckInTime.CustomFormat = "HH:mm:ss"
        Me.dtpCheckInTime.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCheckInTime.Location = New System.Drawing.Point(1016, 12)
        Me.dtpCheckInTime.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpCheckInTime.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpCheckInTime.Name = "dtpCheckInTime"
        Me.dtpCheckInTime.ShowUpDown = True
        Me.dtpCheckInTime.Size = New System.Drawing.Size(220, 36)
        Me.dtpCheckInTime.TabIndex = 5605
        Me.dtpCheckInTime.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(1246, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 36)
        Me.Label19.TabIndex = 5604
        Me.Label19.Text = "وقت الحضور"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAddSalarySystemForm
        '
        Me.btnAddSalarySystemForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddSalarySystemForm.BorderRadius = 8
        Me.btnAddSalarySystemForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddSalarySystemForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddSalarySystemForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddSalarySystemForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddSalarySystemForm.FillColor = System.Drawing.Color.Empty
        Me.btnAddSalarySystemForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddSalarySystemForm.ForeColor = System.Drawing.Color.White
        Me.btnAddSalarySystemForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddSalarySystemForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddSalarySystemForm.Location = New System.Drawing.Point(974, 162)
        Me.btnAddSalarySystemForm.Name = "btnAddSalarySystemForm"
        Me.btnAddSalarySystemForm.Size = New System.Drawing.Size(38, 36)
        Me.btnAddSalarySystemForm.TabIndex = 5634
        '
        'tabPageAttachments
        '
        Me.tabPageAttachments.Controls.Add(Me.lblCvStatus)
        Me.tabPageAttachments.Controls.Add(Me.picNationalBack)
        Me.tabPageAttachments.Controls.Add(Me.picNationalFront)
        Me.tabPageAttachments.Controls.Add(Me.btnRemovePhoto)
        Me.tabPageAttachments.Controls.Add(Me.btnUploadPhoto)
        Me.tabPageAttachments.Controls.Add(Me.picEmployee)
        Me.tabPageAttachments.Location = New System.Drawing.Point(4, 44)
        Me.tabPageAttachments.Name = "tabPageAttachments"
        Me.tabPageAttachments.Size = New System.Drawing.Size(1426, 278)
        Me.tabPageAttachments.TabIndex = 3
        Me.tabPageAttachments.Text = "المرفقات والصور"
        Me.tabPageAttachments.UseVisualStyleBackColor = True
        '
        'lblCvStatus
        '
        Me.lblCvStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblCvStatus.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCvStatus.Location = New System.Drawing.Point(588, 185)
        Me.lblCvStatus.Name = "lblCvStatus"
        Me.lblCvStatus.Size = New System.Drawing.Size(250, 36)
        Me.lblCvStatus.TabIndex = 5614
        Me.lblCvStatus.Text = "بطاقة الرقم القومي (الوجه / الظهر)"
        Me.lblCvStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picNationalBack
        '
        Me.picNationalBack.BorderRadius = 8
        Me.picNationalBack.FillColor = System.Drawing.Color.AliceBlue
        Me.picNationalBack.Image = Global.WindowsApp1.My.Resources.Resources._2013_634988045225330147_533_main
        Me.picNationalBack.ImageRotate = 0!
        Me.picNationalBack.Location = New System.Drawing.Point(116, 15)
        Me.picNationalBack.Name = "picNationalBack"
        Me.picNationalBack.Size = New System.Drawing.Size(250, 160)
        Me.picNationalBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picNationalBack.TabIndex = 5608
        Me.picNationalBack.TabStop = False
        '
        'picNationalFront
        '
        Me.picNationalFront.BorderRadius = 8
        Me.picNationalFront.FillColor = System.Drawing.Color.AliceBlue
        Me.picNationalFront.Image = Global.WindowsApp1.My.Resources.Resources._544
        Me.picNationalFront.ImageRotate = 0!
        Me.picNationalFront.Location = New System.Drawing.Point(588, 15)
        Me.picNationalFront.Name = "picNationalFront"
        Me.picNationalFront.Size = New System.Drawing.Size(250, 160)
        Me.picNationalFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picNationalFront.TabIndex = 5607
        Me.picNationalFront.TabStop = False
        '
        'btnRemovePhoto
        '
        Me.btnRemovePhoto.BackColor = System.Drawing.Color.Transparent
        Me.btnRemovePhoto.BorderColor = System.Drawing.Color.BurlyWood
        Me.btnRemovePhoto.BorderRadius = 6
        Me.btnRemovePhoto.BorderThickness = 1
        Me.btnRemovePhoto.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnRemovePhoto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnRemovePhoto.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnRemovePhoto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnRemovePhoto.FillColor = System.Drawing.Color.White
        Me.btnRemovePhoto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRemovePhoto.ForeColor = System.Drawing.Color.Black
        Me.btnRemovePhoto.Image = Global.WindowsApp1.My.Resources.Resources.delete__1_
        Me.btnRemovePhoto.Location = New System.Drawing.Point(1060, 185)
        Me.btnRemovePhoto.Name = "btnRemovePhoto"
        Me.btnRemovePhoto.Size = New System.Drawing.Size(75, 36)
        Me.btnRemovePhoto.TabIndex = 5606
        Me.btnRemovePhoto.Text = "حذف"
        '
        'btnUploadPhoto
        '
        Me.btnUploadPhoto.BackColor = System.Drawing.Color.Transparent
        Me.btnUploadPhoto.BorderColor = System.Drawing.Color.BurlyWood
        Me.btnUploadPhoto.BorderRadius = 6
        Me.btnUploadPhoto.BorderThickness = 1
        Me.btnUploadPhoto.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnUploadPhoto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnUploadPhoto.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnUploadPhoto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnUploadPhoto.FillColor = System.Drawing.Color.White
        Me.btnUploadPhoto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnUploadPhoto.ForeColor = System.Drawing.Color.Black
        Me.btnUploadPhoto.Image = Global.WindowsApp1.My.Resources.Resources.edit
        Me.btnUploadPhoto.Location = New System.Drawing.Point(1145, 185)
        Me.btnUploadPhoto.Name = "btnUploadPhoto"
        Me.btnUploadPhoto.Size = New System.Drawing.Size(75, 36)
        Me.btnUploadPhoto.TabIndex = 5605
        Me.btnUploadPhoto.Text = "رفع"
        '
        'picEmployee
        '
        Me.picEmployee.BorderRadius = 8
        Me.picEmployee.Image = Global.WindowsApp1.My.Resources.Resources.Gemini_Generated_Image_xxl0cixxl0cixxl0
        Me.picEmployee.ImageRotate = 0!
        Me.picEmployee.Location = New System.Drawing.Point(1060, 15)
        Me.picEmployee.Name = "picEmployee"
        Me.picEmployee.Size = New System.Drawing.Size(160, 160)
        Me.picEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picEmployee.TabIndex = 5604
        Me.picEmployee.TabStop = False
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.cmbSearchField)
        Me.Guna2Panel1.Controls.Add(Me.txtSearch)
        Me.Guna2Panel1.Controls.Add(Me.btnRefresh)
        Me.Guna2Panel1.Controls.Add(Me.btnClear)
        Me.Guna2Panel1.Controls.Add(Me.btnDelete)
        Me.Guna2Panel1.Controls.Add(Me.btnUpdate)
        Me.Guna2Panel1.Controls.Add(Me.btnAdd)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 396)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1434, 64)
        Me.Guna2Panel1.TabIndex = 5601
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
        Me.cmbSearchField.Location = New System.Drawing.Point(334, 4)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(165, 49)
        Me.cmbSearchField.TabIndex = 6
        Me.cmbSearchField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtSearch.Location = New System.Drawing.Point(6, 4)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "ابحث عن موظف"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(323, 49)
        Me.txtSearch.TabIndex = 5
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.btnRefresh.Location = New System.Drawing.Point(504, 6)
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
        Me.btnClear.Location = New System.Drawing.Point(689, 6)
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
        Me.btnDelete.Location = New System.Drawing.Point(874, 6)
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
        Me.btnUpdate.Location = New System.Drawing.Point(1059, 6)
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
        Me.btnAdd.Location = New System.Drawing.Point(1244, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(180, 45)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "اضافة"
        '
        '_searchTimer
        '
        Me._searchTimer.Interval = 300
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'frmEmployees
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1434, 800)
        Me.Controls.Add(Me.dgvEmployees)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Guna2TabControl1)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEmployees"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Guna2TabControl1.ResumeLayout(False)
        Me.tabPageBasic.ResumeLayout(False)
        Me.tabPageJob.ResumeLayout(False)
        Me.tabPageSalary.ResumeLayout(False)
        Me.tabPageAttachments.ResumeLayout(False)
        CType(Me.picNationalBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNationalFront, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvEmployees As DataGridView
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2TabControl1 As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents tabPageBasic As TabPage
    Friend WithEvents tabPageJob As TabPage
    Friend WithEvents tabPageSalary As TabPage
    Friend WithEvents tabPageAttachments As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmployeeCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNationalID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEnglishName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtArabicName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAddress As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtEmail As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPhone2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPhone As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dtpBirthDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbGender As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbBranch As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbJobTitle As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbDepartment As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents dtpHireDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbEmployeeStatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtFingerprintCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dtpContractEndDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents dtpCheckInTime As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label19 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtOtherAllowance As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtHousingAllowance As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtTransAllowance As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtBasicSalary As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cmbSalarySystem As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtDailyWorkingHours As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dtpCheckOutTime As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents tgInsuranceStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label31 As Label
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label30 As Label
    Friend WithEvents txtOvertimeRate As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents tgOvertimeAllowed As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label28 As Label
    Friend WithEvents txtInsuranceAmount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblCvStatus As Label
    Friend WithEvents picNationalBack As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents picNationalFront As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents btnRemovePhoto As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnUploadPhoto As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnUpdate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents _searchTimer As Timer
    Friend WithEvents btnAddBranchesForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddDepartmentForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddJobTitleForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddSalarySystemForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents picEmployee As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
