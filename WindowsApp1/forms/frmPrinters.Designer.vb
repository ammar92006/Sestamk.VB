<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrinters
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrinters))
        Me.dgvPrinters = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrinterName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeletePrinter = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEditPrinter = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddPrinter = New Guna.UI2.WinForms.Guna2Button()
        Me.cmbWindowsPrinters = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNote = New Guna.UI2.WinForms.Guna2TextBox()
        CType(Me.dgvPrinters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPrinters
        '
        Me.dgvPrinters.AllowUserToAddRows = False
        Me.dgvPrinters.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvPrinters.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrinters.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrinters.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPrinters.ColumnHeadersHeight = 4
        Me.dgvPrinters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPrinters.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPrinters.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvPrinters.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPrinters.Location = New System.Drawing.Point(0, 322)
        Me.dgvPrinters.Name = "dgvPrinters"
        Me.dgvPrinters.ReadOnly = True
        Me.dgvPrinters.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvPrinters.RowHeadersVisible = False
        Me.dgvPrinters.RowTemplate.Height = 40
        Me.dgvPrinters.Size = New System.Drawing.Size(1205, 251)
        Me.dgvPrinters.TabIndex = 5607
        Me.dgvPrinters.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPrinters.ThemeStyle.BackColor = System.Drawing.Color.Silver
        Me.dgvPrinters.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPrinters.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvPrinters.ThemeStyle.ReadOnly = True
        Me.dgvPrinters.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPrinters.ThemeStyle.RowsStyle.Height = 40
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 573)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1205, 65)
        Me.Panel2.TabIndex = 5606
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.pn_title_page)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1205, 65)
        Me.Panel1.TabIndex = 5605
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
        Me.pn_title_page.Location = New System.Drawing.Point(573, 9)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(142, 46)
        Me.pn_title_page.TabIndex = 4
        Me.pn_title_page.Text = "الطابعات"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(1043, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 33)
        Me.Label1.TabIndex = 5609
        Me.Label1.Text = "اختار الطابعة"
        '
        'txtPrinterName
        '
        Me.txtPrinterName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrinterName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrinterName.DefaultText = ""
        Me.txtPrinterName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPrinterName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPrinterName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPrinterName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPrinterName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPrinterName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrinterName.ForeColor = System.Drawing.Color.Black
        Me.txtPrinterName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPrinterName.Location = New System.Drawing.Point(745, 137)
        Me.txtPrinterName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.PlaceholderText = ""
        Me.txtPrinterName.SelectedText = ""
        Me.txtPrinterName.Size = New System.Drawing.Size(292, 39)
        Me.txtPrinterName.TabIndex = 5608
        Me.txtPrinterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnClear)
        Me.Guna2Panel1.Controls.Add(Me.btnDeletePrinter)
        Me.Guna2Panel1.Controls.Add(Me.btnEditPrinter)
        Me.Guna2Panel1.Controls.Add(Me.btnAddPrinter)
        Me.Guna2Panel1.Location = New System.Drawing.Point(214, 254)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(785, 63)
        Me.Guna2Panel1.TabIndex = 5610
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
        'btnDeletePrinter
        '
        Me.btnDeletePrinter.BorderRadius = 8
        Me.btnDeletePrinter.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeletePrinter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeletePrinter.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeletePrinter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeletePrinter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeletePrinter.ForeColor = System.Drawing.Color.White
        Me.btnDeletePrinter.Location = New System.Drawing.Point(201, 10)
        Me.btnDeletePrinter.Name = "btnDeletePrinter"
        Me.btnDeletePrinter.Size = New System.Drawing.Size(180, 45)
        Me.btnDeletePrinter.TabIndex = 2
        Me.btnDeletePrinter.Text = "حذف"
        '
        'btnEditPrinter
        '
        Me.btnEditPrinter.BorderRadius = 8
        Me.btnEditPrinter.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnEditPrinter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnEditPrinter.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnEditPrinter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnEditPrinter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnEditPrinter.ForeColor = System.Drawing.Color.White
        Me.btnEditPrinter.Location = New System.Drawing.Point(395, 10)
        Me.btnEditPrinter.Name = "btnEditPrinter"
        Me.btnEditPrinter.Size = New System.Drawing.Size(180, 45)
        Me.btnEditPrinter.TabIndex = 1
        Me.btnEditPrinter.Text = "تعديل"
        '
        'btnAddPrinter
        '
        Me.btnAddPrinter.BorderRadius = 8
        Me.btnAddPrinter.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddPrinter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddPrinter.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddPrinter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddPrinter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddPrinter.ForeColor = System.Drawing.Color.White
        Me.btnAddPrinter.Location = New System.Drawing.Point(589, 10)
        Me.btnAddPrinter.Name = "btnAddPrinter"
        Me.btnAddPrinter.Size = New System.Drawing.Size(180, 45)
        Me.btnAddPrinter.TabIndex = 0
        Me.btnAddPrinter.Text = "اضافة"
        '
        'cmbWindowsPrinters
        '
        Me.cmbWindowsPrinters.BackColor = System.Drawing.Color.Transparent
        Me.cmbWindowsPrinters.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbWindowsPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWindowsPrinters.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbWindowsPrinters.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbWindowsPrinters.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbWindowsPrinters.ForeColor = System.Drawing.Color.Black
        Me.cmbWindowsPrinters.ItemHeight = 42
        Me.cmbWindowsPrinters.Location = New System.Drawing.Point(745, 79)
        Me.cmbWindowsPrinters.Name = "cmbWindowsPrinters"
        Me.cmbWindowsPrinters.Size = New System.Drawing.Size(292, 48)
        Me.cmbWindowsPrinters.TabIndex = 5611
        Me.cmbWindowsPrinters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(1067, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 33)
        Me.Label2.TabIndex = 5612
        Me.Label2.Text = "اسم المنفذ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(655, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 33)
        Me.Label6.TabIndex = 5621
        Me.Label6.Text = "نشط"
        '
        'tgStatus
        '
        Me.tgStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Location = New System.Drawing.Point(328, 76)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(93, 44)
        Me.tgStatus.TabIndex = 5620
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(595, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 33)
        Me.Label5.TabIndex = 5619
        Me.Label5.Text = "الملاحظات"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNote.DefaultText = ""
        Me.txtNote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNote.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNote.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtNote.ForeColor = System.Drawing.Color.Black
        Me.txtNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNote.Location = New System.Drawing.Point(328, 165)
        Me.txtNote.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.PlaceholderText = ""
        Me.txtNote.SelectedText = ""
        Me.txtNote.Size = New System.Drawing.Size(392, 80)
        Me.txtNote.TabIndex = 5618
        '
        'frmPrinters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 638)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tgStatus)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbWindowsPrinters)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPrinterName)
        Me.Controls.Add(Me.dgvPrinters)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPrinters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvPrinters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvPrinters As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pn_title_page As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPrinterName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeletePrinter As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEditPrinter As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddPrinter As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cmbWindowsPrinters As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNote As Guna.UI2.WinForms.Guna2TextBox
End Class
