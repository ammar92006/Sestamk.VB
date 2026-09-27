<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalaryPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalaryPayment))
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.cmbEmployee = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpPaymentDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMonth = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtBasicSalary = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAllowances = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dgvSalaries = New System.Windows.Forms.DataGridView()
        Me.nudYear = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDeductions = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAdvances = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblNetSalary = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSaveAndPay = New Guna.UI2.WinForms.Guna2Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.panelHeader.SuspendLayout()
        CType(Me.dgvSalaries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panelHeader.Size = New System.Drawing.Size(1086, 70)
        Me.panelHeader.TabIndex = 40
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
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(474, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(151, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الرواتب صرف "
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmbEmployee
        '
        Me.cmbEmployee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEmployee.BackColor = System.Drawing.Color.Transparent
        Me.cmbEmployee.BorderRadius = 6
        Me.cmbEmployee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmployee.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbEmployee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbEmployee.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbEmployee.ForeColor = System.Drawing.Color.Black
        Me.cmbEmployee.ItemHeight = 30
        Me.cmbEmployee.Location = New System.Drawing.Point(703, 95)
        Me.cmbEmployee.Name = "cmbEmployee"
        Me.cmbEmployee.Size = New System.Drawing.Size(245, 36)
        Me.cmbEmployee.TabIndex = 5613
        Me.cmbEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(954, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 36)
        Me.Label2.TabIndex = 5612
        Me.Label2.Text = "اختيار الموظف *"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTreasury
        '
        Me.cmbTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbTreasury.BorderRadius = 6
        Me.cmbTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTreasury.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbTreasury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbTreasury.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbTreasury.ForeColor = System.Drawing.Color.Black
        Me.cmbTreasury.ItemHeight = 30
        Me.cmbTreasury.Location = New System.Drawing.Point(703, 137)
        Me.cmbTreasury.Name = "cmbTreasury"
        Me.cmbTreasury.Size = New System.Drawing.Size(245, 36)
        Me.cmbTreasury.TabIndex = 5615
        Me.cmbTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(954, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 36)
        Me.Label1.TabIndex = 5614
        Me.Label1.Text = "اختيار الخزنة *"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.BorderRadius = 8
        Me.dtpPaymentDate.Checked = True
        Me.dtpPaymentDate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpPaymentDate.Location = New System.Drawing.Point(703, 179)
        Me.dtpPaymentDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpPaymentDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.Size = New System.Drawing.Size(245, 36)
        Me.dtpPaymentDate.TabIndex = 5616
        Me.dtpPaymentDate.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(954, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 36)
        Me.Label3.TabIndex = 5617
        Me.Label3.Text = "تاريخ الصرف"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMonth
        '
        Me.cmbMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMonth.BackColor = System.Drawing.Color.Transparent
        Me.cmbMonth.BorderRadius = 6
        Me.cmbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMonth.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbMonth.ForeColor = System.Drawing.Color.Black
        Me.cmbMonth.ItemHeight = 30
        Me.cmbMonth.Location = New System.Drawing.Point(703, 228)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(245, 36)
        Me.cmbMonth.TabIndex = 5619
        Me.cmbMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(954, 228)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 36)
        Me.Label4.TabIndex = 5618
        Me.Label4.Text = "شهر الراتب *"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(954, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 36)
        Me.Label5.TabIndex = 5620
        Me.Label5.Text = "سنة الراتب *"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(552, 95)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(143, 36)
        Me.Label23.TabIndex = 5622
        Me.Label23.Text = "الراتب الأساسي"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBasicSalary
        '
        Me.txtBasicSalary.BorderRadius = 6
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
        Me.txtBasicSalary.Location = New System.Drawing.Point(300, 95)
        Me.txtBasicSalary.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBasicSalary.Name = "txtBasicSalary"
        Me.txtBasicSalary.PlaceholderText = ""
        Me.txtBasicSalary.SelectedText = ""
        Me.txtBasicSalary.Size = New System.Drawing.Size(245, 36)
        Me.txtBasicSalary.TabIndex = 5621
        Me.txtBasicSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(552, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 36)
        Me.Label6.TabIndex = 5624
        Me.Label6.Text = "الحوافز والمكافآت"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAllowances
        '
        Me.txtAllowances.BorderRadius = 6
        Me.txtAllowances.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAllowances.DefaultText = ""
        Me.txtAllowances.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAllowances.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAllowances.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAllowances.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAllowances.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAllowances.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtAllowances.ForeColor = System.Drawing.Color.Black
        Me.txtAllowances.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAllowances.Location = New System.Drawing.Point(300, 139)
        Me.txtAllowances.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAllowances.Name = "txtAllowances"
        Me.txtAllowances.PlaceholderText = ""
        Me.txtAllowances.SelectedText = ""
        Me.txtAllowances.Size = New System.Drawing.Size(245, 36)
        Me.txtAllowances.TabIndex = 5623
        Me.txtAllowances.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvSalaries
        '
        Me.dgvSalaries.AllowUserToResizeColumns = False
        Me.dgvSalaries.AllowUserToResizeRows = False
        Me.dgvSalaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalaries.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvSalaries.Location = New System.Drawing.Point(0, 312)
        Me.dgvSalaries.Name = "dgvSalaries"
        Me.dgvSalaries.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvSalaries.RowTemplate.Height = 40
        Me.dgvSalaries.Size = New System.Drawing.Size(1086, 400)
        Me.dgvSalaries.TabIndex = 5625
        '
        'nudYear
        '
        Me.nudYear.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.nudYear.Location = New System.Drawing.Point(703, 270)
        Me.nudYear.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.nudYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.nudYear.Name = "nudYear"
        Me.nudYear.Size = New System.Drawing.Size(245, 27)
        Me.nudYear.TabIndex = 5626
        Me.nudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudYear.Value = New Decimal(New Integer() {2026, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(552, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 36)
        Me.Label7.TabIndex = 5628
        Me.Label7.Text = "الخصومات والغيابات"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDeductions
        '
        Me.txtDeductions.BorderRadius = 6
        Me.txtDeductions.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeductions.DefaultText = ""
        Me.txtDeductions.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDeductions.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDeductions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDeductions.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDeductions.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDeductions.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDeductions.ForeColor = System.Drawing.Color.Black
        Me.txtDeductions.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDeductions.Location = New System.Drawing.Point(300, 183)
        Me.txtDeductions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDeductions.Name = "txtDeductions"
        Me.txtDeductions.PlaceholderText = ""
        Me.txtDeductions.SelectedText = ""
        Me.txtDeductions.Size = New System.Drawing.Size(245, 36)
        Me.txtDeductions.TabIndex = 5627
        Me.txtDeductions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(552, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 36)
        Me.Label8.TabIndex = 5630
        Me.Label8.Text = "السلف السابقة"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAdvances
        '
        Me.txtAdvances.BorderRadius = 6
        Me.txtAdvances.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAdvances.DefaultText = ""
        Me.txtAdvances.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAdvances.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAdvances.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAdvances.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAdvances.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAdvances.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtAdvances.ForeColor = System.Drawing.Color.Black
        Me.txtAdvances.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAdvances.Location = New System.Drawing.Point(300, 227)
        Me.txtAdvances.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAdvances.Name = "txtAdvances"
        Me.txtAdvances.PlaceholderText = ""
        Me.txtAdvances.SelectedText = ""
        Me.txtAdvances.Size = New System.Drawing.Size(245, 36)
        Me.txtAdvances.TabIndex = 5629
        Me.txtAdvances.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNetSalary
        '
        Me.lblNetSalary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNetSalary.BackColor = System.Drawing.Color.Transparent
        Me.lblNetSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNetSalary.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNetSalary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblNetSalary.Location = New System.Drawing.Point(300, 270)
        Me.lblNetSalary.Name = "lblNetSalary"
        Me.lblNetSalary.Size = New System.Drawing.Size(245, 36)
        Me.lblNetSalary.TabIndex = 5632
        Me.lblNetSalary.Text = "---"
        Me.lblNetSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(552, 270)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 36)
        Me.Label9.TabIndex = 5631
        Me.Label9.Text = "الصافي المستحق"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClear
        '
        Me.btnClear.BorderRadius = 6
        Me.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(12, 269)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(133, 38)
        Me.btnClear.TabIndex = 5634
        Me.btnClear.Text = "تفريغ الحقول"
        '
        'btnSaveAndPay
        '
        Me.btnSaveAndPay.BorderRadius = 6
        Me.btnSaveAndPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveAndPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveAndPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveAndPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveAndPay.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnSaveAndPay.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveAndPay.ForeColor = System.Drawing.Color.White
        Me.btnSaveAndPay.Location = New System.Drawing.Point(160, 269)
        Me.btnSaveAndPay.Name = "btnSaveAndPay"
        Me.btnSaveAndPay.Size = New System.Drawing.Size(133, 38)
        Me.btnSaveAndPay.TabIndex = 5633
        Me.btnSaveAndPay.Text = "حفظ"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(195, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 36)
        Me.Label10.TabIndex = 5636
        Me.Label10.Text = "ملاحظات"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.BorderRadius = 6
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
        Me.txtNotes.Location = New System.Drawing.Point(13, 142)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(280, 120)
        Me.txtNotes.TabIndex = 5635
        Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmSalaryPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 712)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSaveAndPay)
        Me.Controls.Add(Me.lblNetSalary)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAdvances)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDeductions)
        Me.Controls.Add(Me.nudYear)
        Me.Controls.Add(Me.dgvSalaries)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAllowances)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtBasicSalary)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpPaymentDate)
        Me.Controls.Add(Me.cmbTreasury)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEmployee)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSalaryPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.dgvSalaries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cmbEmployee As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpPaymentDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMonth As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtBasicSalary As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAllowances As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvSalaries As DataGridView
    Friend WithEvents nudYear As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDeductions As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAdvances As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblNetSalary As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSaveAndPay As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
End Class
