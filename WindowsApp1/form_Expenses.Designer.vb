<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_Expenses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_Expenses))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.cmbPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtUserPassword = New System.Windows.Forms.TextBox()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPayee = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnToggleDiscount = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_clean = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1.SuspendLayout()
        Me.grpCustomerInfo.SuspendLayout()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_min)
        Me.Panel1.Controls.Add(Me.btn_max)
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 75)
        Me.Panel1.TabIndex = 0
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(100, 19)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.btn_min.TabIndex = 8
        '
        'btn_max
        '
        Me.btn_max.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_max.Appearance.Options.UseFont = True
        Me.btn_max.AutoSize = True
        Me.btn_max.ImageOptions.SvgImage = CType(resources.GetObject("btn_max.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_max.Location = New System.Drawing.Point(56, 19)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 7
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(12, 19)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(405, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 54)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "المصروفات"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 595)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1000, 75)
        Me.Panel2.TabIndex = 1
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.cmbTreasury)
        Me.grpCustomerInfo.Controls.Add(Me.Label8)
        Me.grpCustomerInfo.Controls.Add(Me.dtpDate)
        Me.grpCustomerInfo.Controls.Add(Me.cmbStatus)
        Me.grpCustomerInfo.Controls.Add(Me.cmbCategory)
        Me.grpCustomerInfo.Controls.Add(Me.cmbPaymentMethod)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel4)
        Me.grpCustomerInfo.Controls.Add(Me.txtUserPassword)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel9)
        Me.grpCustomerInfo.Controls.Add(Me.txtNotes)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.txtPayee)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.txtAmount)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.btnToggleDiscount)
        Me.grpCustomerInfo.Controls.Add(Me.btn_clean)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 75)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1000, 445)
        Me.grpCustomerInfo.TabIndex = 80
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTreasury
        '
        Me.cmbTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTreasury.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasury.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbTreasury.ItemHeight = 40
        Me.cmbTreasury.Location = New System.Drawing.Point(15, 296)
        Me.cmbTreasury.Name = "cmbTreasury"
        Me.cmbTreasury.Size = New System.Drawing.Size(323, 46)
        Me.cmbTreasury.TabIndex = 5641
        Me.cmbTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(344, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 46)
        Me.Label8.TabIndex = 5640
        Me.Label8.Text = "الخزنة"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpDate
        '
        Me.dtpDate.BackColor = System.Drawing.Color.Transparent
        Me.dtpDate.BorderRadius = 10
        Me.dtpDate.Checked = True
        Me.dtpDate.FillColor = System.Drawing.Color.Silver
        Me.dtpDate.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpDate.Location = New System.Drawing.Point(478, 50)
        Me.dtpDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(315, 41)
        Me.dtpDate.TabIndex = 5639
        Me.dtpDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dtpDate.Value = New Date(2026, 3, 27, 2, 8, 57, 279)
        '
        'cmbStatus
        '
        Me.cmbStatus.ForeColor = System.Drawing.Color.Black
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(478, 370)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(315, 41)
        Me.cmbStatus.TabIndex = 5638
        '
        'cmbCategory
        '
        Me.cmbCategory.ForeColor = System.Drawing.Color.Black
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(478, 178)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(315, 41)
        Me.cmbCategory.TabIndex = 5637
        '
        'cmbPaymentMethod
        '
        Me.cmbPaymentMethod.ForeColor = System.Drawing.Color.Black
        Me.cmbPaymentMethod.FormattingEnabled = True
        Me.cmbPaymentMethod.Location = New System.Drawing.Point(478, 114)
        Me.cmbPaymentMethod.Name = "cmbPaymentMethod"
        Me.cmbPaymentMethod.Size = New System.Drawing.Size(315, 41)
        Me.cmbPaymentMethod.TabIndex = 5636
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel4.AutoSize = False
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(152, 340)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(317, 36)
        Me.Guna2HtmlLabel4.TabIndex = 5635
        Me.Guna2HtmlLabel4.Text = "الباسورد"
        Me.Guna2HtmlLabel4.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtUserPassword
        '
        Me.txtUserPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserPassword.ForeColor = System.Drawing.Color.Black
        Me.txtUserPassword.Location = New System.Drawing.Point(15, 382)
        Me.txtUserPassword.Name = "txtUserPassword"
        Me.txtUserPassword.Size = New System.Drawing.Size(454, 38)
        Me.txtUserPassword.TabIndex = 5634
        Me.txtUserPassword.UseSystemPasswordChar = True
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel9.AutoSize = False
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(263, 49)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(206, 29)
        Me.Guna2HtmlLabel9.TabIndex = 5632
        Me.Guna2HtmlLabel9.Text = "الملاحظات"
        Me.Guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
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
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(15, 80)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(454, 195)
        Me.txtNotes.TabIndex = 5631
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(799, 370)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(189, 36)
        Me.Label7.TabIndex = 5629
        Me.Label7.Text = "حاله الدفع"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPayee
        '
        Me.txtPayee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPayee.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPayee.DefaultText = ""
        Me.txtPayee.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPayee.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPayee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPayee.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPayee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPayee.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtPayee.ForeColor = System.Drawing.Color.Black
        Me.txtPayee.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPayee.Location = New System.Drawing.Point(478, 302)
        Me.txtPayee.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPayee.Name = "txtPayee"
        Me.txtPayee.PlaceholderText = ""
        Me.txtPayee.SelectedText = ""
        Me.txtPayee.Size = New System.Drawing.Size(315, 40)
        Me.txtPayee.TabIndex = 5628
        Me.txtPayee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(799, 306)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(189, 36)
        Me.Label6.TabIndex = 5627
        Me.Label6.Text = "جهه الدفع"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAmount
        '
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.Location = New System.Drawing.Point(478, 236)
        Me.txtAmount.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(315, 40)
        Me.txtAmount.TabIndex = 5626
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(799, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 36)
        Me.Label4.TabIndex = 5625
        Me.Label4.Text = "المدفوع"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(799, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 36)
        Me.Label3.TabIndex = 5623
        Me.Label3.Text = "التصنيف"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(799, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(189, 36)
        Me.Label2.TabIndex = 5621
        Me.Label2.Text = "طريقة الدفع"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(799, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(189, 36)
        Me.Label5.TabIndex = 5620
        Me.Label5.Text = "التاريخ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnToggleDiscount
        '
        Me.btnToggleDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToggleDiscount.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToggleDiscount.Appearance.Options.UseFont = True
        Me.btnToggleDiscount.AutoSize = True
        Me.btnToggleDiscount.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.gift
        Me.btnToggleDiscount.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnToggleDiscount.Location = New System.Drawing.Point(-595, 2)
        Me.btnToggleDiscount.Name = "btnToggleDiscount"
        Me.btnToggleDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnToggleDiscount.Size = New System.Drawing.Size(38, 36)
        Me.btnToggleDiscount.TabIndex = 5618
        '
        'btn_clean
        '
        Me.btn_clean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_clean.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clean.Appearance.Options.UseFont = True
        Me.btn_clean.AutoSize = True
        Me.btn_clean.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.eraser
        Me.btn_clean.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_clean.Location = New System.Drawing.Point(859, 3)
        Me.btn_clean.Name = "btn_clean"
        Me.btn_clean.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_clean.Size = New System.Drawing.Size(38, 36)
        Me.btn_clean.TabIndex = 44
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnSave.Location = New System.Drawing.Point(404, 526)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSave.Size = New System.Drawing.Size(313, 57)
        Me.btnSave.TabIndex = 5634
        Me.btnSave.Text = "حفظ "
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnCancel.Location = New System.Drawing.Point(740, 526)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnCancel.Size = New System.Drawing.Size(248, 57)
        Me.btnCancel.TabIndex = 5635
        Me.btnCancel.Text = "الغاء"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.SimpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(15, 526)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SimpleButton1.Size = New System.Drawing.Size(383, 57)
        Me.SimpleButton1.TabIndex = 5636
        Me.SimpleButton1.Text = "عرض المصروفات السابقه"
        '
        'form_Expenses
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1000, 670)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "form_Expenses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "المصروفات"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents btnToggleDiscount As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_clean As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAmount As NumericUpDown
    Friend WithEvents txtPayee As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtUserPassword As TextBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents cmbPaymentMethod As ComboBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtpDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Public WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label8 As Label
End Class
