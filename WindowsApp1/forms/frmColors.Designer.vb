<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColors
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmColors))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteColor = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEditColor = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddColor = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvColors = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtColorCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtColorName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHexCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRGB = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Guna2Panel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvColors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnClear)
        Me.Guna2Panel1.Controls.Add(Me.btnDeleteColor)
        Me.Guna2Panel1.Controls.Add(Me.btnEditColor)
        Me.Guna2Panel1.Controls.Add(Me.btnAddColor)
        Me.Guna2Panel1.Location = New System.Drawing.Point(188, 282)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(785, 63)
        Me.Guna2Panel1.TabIndex = 5601
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
        Me.btnClear.Image = Global.WindowsApp1.My.Resources.Resources.cleaning
        Me.btnClear.Location = New System.Drawing.Point(7, 10)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(180, 45)
        Me.btnClear.TabIndex = 3
        '
        'btnDeleteColor
        '
        Me.btnDeleteColor.BorderRadius = 8
        Me.btnDeleteColor.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteColor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteColor.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteColor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteColor.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteColor.ForeColor = System.Drawing.Color.White
        Me.btnDeleteColor.Location = New System.Drawing.Point(201, 10)
        Me.btnDeleteColor.Name = "btnDeleteColor"
        Me.btnDeleteColor.Size = New System.Drawing.Size(180, 45)
        Me.btnDeleteColor.TabIndex = 2
        Me.btnDeleteColor.Text = "حذف"
        '
        'btnEditColor
        '
        Me.btnEditColor.BorderRadius = 8
        Me.btnEditColor.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnEditColor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnEditColor.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnEditColor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnEditColor.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnEditColor.ForeColor = System.Drawing.Color.White
        Me.btnEditColor.Location = New System.Drawing.Point(395, 10)
        Me.btnEditColor.Name = "btnEditColor"
        Me.btnEditColor.Size = New System.Drawing.Size(180, 45)
        Me.btnEditColor.TabIndex = 1
        Me.btnEditColor.Text = "تعديل"
        '
        'btnAddColor
        '
        Me.btnAddColor.BorderRadius = 8
        Me.btnAddColor.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddColor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddColor.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddColor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddColor.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddColor.ForeColor = System.Drawing.Color.White
        Me.btnAddColor.Location = New System.Drawing.Point(589, 10)
        Me.btnAddColor.Name = "btnAddColor"
        Me.btnAddColor.Size = New System.Drawing.Size(180, 45)
        Me.btnAddColor.TabIndex = 0
        Me.btnAddColor.Text = "اضافة"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.pn_title_page)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1148, 65)
        Me.Panel1.TabIndex = 5602
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
        Me.pn_title_page.Location = New System.Drawing.Point(510, 9)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(113, 46)
        Me.pn_title_page.TabIndex = 4
        Me.pn_title_page.Text = "الالوان"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 609)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1148, 65)
        Me.Panel2.TabIndex = 5603
        '
        'dgvColors
        '
        Me.dgvColors.AllowUserToAddRows = False
        Me.dgvColors.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvColors.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvColors.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvColors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvColors.ColumnHeadersHeight = 4
        Me.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvColors.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvColors.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvColors.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvColors.Location = New System.Drawing.Point(0, 349)
        Me.dgvColors.Name = "dgvColors"
        Me.dgvColors.ReadOnly = True
        Me.dgvColors.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvColors.RowHeadersVisible = False
        Me.dgvColors.RowTemplate.Height = 40
        Me.dgvColors.Size = New System.Drawing.Size(1148, 260)
        Me.dgvColors.TabIndex = 5604
        Me.dgvColors.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvColors.ThemeStyle.BackColor = System.Drawing.Color.Silver
        Me.dgvColors.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvColors.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvColors.ThemeStyle.ReadOnly = True
        Me.dgvColors.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvColors.ThemeStyle.RowsStyle.Height = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(982, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 33)
        Me.Label1.TabIndex = 5606
        Me.Label1.Text = "كود اللون"
        '
        'txtColorCode
        '
        Me.txtColorCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtColorCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtColorCode.DefaultText = ""
        Me.txtColorCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtColorCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtColorCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtColorCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtColorCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtColorCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtColorCode.ForeColor = System.Drawing.Color.Black
        Me.txtColorCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtColorCode.Location = New System.Drawing.Point(707, 74)
        Me.txtColorCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtColorCode.Name = "txtColorCode"
        Me.txtColorCode.PlaceholderText = ""
        Me.txtColorCode.SelectedText = ""
        Me.txtColorCode.Size = New System.Drawing.Size(266, 39)
        Me.txtColorCode.TabIndex = 5605
        Me.txtColorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(982, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 33)
        Me.Label2.TabIndex = 5608
        Me.Label2.Text = "اسم اللون"
        '
        'txtColorName
        '
        Me.txtColorName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtColorName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtColorName.DefaultText = ""
        Me.txtColorName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtColorName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtColorName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtColorName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtColorName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtColorName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtColorName.ForeColor = System.Drawing.Color.Black
        Me.txtColorName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtColorName.Location = New System.Drawing.Point(707, 125)
        Me.txtColorName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtColorName.Name = "txtColorName"
        Me.txtColorName.PlaceholderText = ""
        Me.txtColorName.SelectedText = ""
        Me.txtColorName.Size = New System.Drawing.Size(266, 39)
        Me.txtColorName.TabIndex = 5607
        Me.txtColorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(982, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 33)
        Me.Label3.TabIndex = 5610
        Me.Label3.Text = " Hexكود الـ "
        '
        'txtHexCode
        '
        Me.txtHexCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHexCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHexCode.DefaultText = ""
        Me.txtHexCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtHexCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtHexCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtHexCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtHexCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtHexCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtHexCode.ForeColor = System.Drawing.Color.Black
        Me.txtHexCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtHexCode.Location = New System.Drawing.Point(707, 176)
        Me.txtHexCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtHexCode.Name = "txtHexCode"
        Me.txtHexCode.PlaceholderText = ""
        Me.txtHexCode.SelectedText = ""
        Me.txtHexCode.Size = New System.Drawing.Size(266, 39)
        Me.txtHexCode.TabIndex = 5609
        Me.txtHexCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(543, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 33)
        Me.Label4.TabIndex = 5612
        Me.Label4.Text = "RGB"
        '
        'txtRGB
        '
        Me.txtRGB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRGB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRGB.DefaultText = ""
        Me.txtRGB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtRGB.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRGB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRGB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRGB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRGB.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtRGB.ForeColor = System.Drawing.Color.Black
        Me.txtRGB.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRGB.Location = New System.Drawing.Point(232, 74)
        Me.txtRGB.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtRGB.Name = "txtRGB"
        Me.txtRGB.PlaceholderText = ""
        Me.txtRGB.SelectedText = ""
        Me.txtRGB.Size = New System.Drawing.Size(302, 39)
        Me.txtRGB.TabIndex = 5611
        Me.txtRGB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtNotes.Location = New System.Drawing.Point(232, 179)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(392, 80)
        Me.txtNotes.TabIndex = 5613
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(499, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 33)
        Me.Label5.TabIndex = 5614
        Me.Label5.Text = "الملاحظات"
        '
        'tgStatus
        '
        Me.tgStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Location = New System.Drawing.Point(74, 203)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(93, 44)
        Me.tgStatus.TabIndex = 5616
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(77, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 33)
        Me.Label6.TabIndex = 5617
        Me.Label6.Text = "نشط"
        '
        'frmColors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1148, 674)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tgStatus)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRGB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtHexCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtColorName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtColorCode)
        Me.Controls.Add(Me.dgvColors)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmColors"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvColors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnDeleteColor As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEditColor As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddColor As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pn_title_page As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvColors As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtColorCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtColorName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtHexCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRGB As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label6 As Label
End Class
