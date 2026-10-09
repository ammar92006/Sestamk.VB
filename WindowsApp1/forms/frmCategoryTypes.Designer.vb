<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategoryTypes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCategoryTypes))
        Me.dgvCategoryTypes = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_close = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnDeleteType = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEditType = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddType = New Guna.UI2.WinForms.Guna2Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTypeCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTypeName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.btnClearFields = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        CType(Me.dgvCategoryTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCategoryTypes
        '
        Me.dgvCategoryTypes.AllowUserToAddRows = False
        Me.dgvCategoryTypes.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvCategoryTypes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCategoryTypes.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCategoryTypes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCategoryTypes.ColumnHeadersHeight = 4
        Me.dgvCategoryTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCategoryTypes.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCategoryTypes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvCategoryTypes.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCategoryTypes.Location = New System.Drawing.Point(0, 276)
        Me.dgvCategoryTypes.Name = "dgvCategoryTypes"
        Me.dgvCategoryTypes.ReadOnly = True
        Me.dgvCategoryTypes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvCategoryTypes.RowHeadersVisible = False
        Me.dgvCategoryTypes.RowTemplate.Height = 40
        Me.dgvCategoryTypes.Size = New System.Drawing.Size(915, 251)
        Me.dgvCategoryTypes.TabIndex = 5610
        Me.dgvCategoryTypes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvCategoryTypes.ThemeStyle.BackColor = System.Drawing.Color.Silver
        Me.dgvCategoryTypes.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCategoryTypes.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvCategoryTypes.ThemeStyle.ReadOnly = True
        Me.dgvCategoryTypes.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCategoryTypes.ThemeStyle.RowsStyle.Height = 40
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 527)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(915, 65)
        Me.Panel2.TabIndex = 5609
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.pn_title_page)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(915, 65)
        Me.Panel1.TabIndex = 5608
        '
        'btn_close
        '
        Me.btn_close.AutoSize = True
        Me.btn_close.Location = New System.Drawing.Point(12, 12)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.FillColor = System.Drawing.Color.Transparent
        Me.btn_close.HoverState.FillColor = System.Drawing.Color.FromArgb(239, 68, 68)
        Me.btn_close.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_close.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
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
        Me.pn_title_page.Location = New System.Drawing.Point(366, 9)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(188, 46)
        Me.pn_title_page.TabIndex = 4
        Me.pn_title_page.Text = "أنواع الفئات"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnClearFields)
        Me.Guna2Panel1.Controls.Add(Me.btnDeleteType)
        Me.Guna2Panel1.Controls.Add(Me.btnEditType)
        Me.Guna2Panel1.Controls.Add(Me.btnAddType)
        Me.Guna2Panel1.Location = New System.Drawing.Point(70, 207)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(785, 63)
        Me.Guna2Panel1.TabIndex = 5611
        '
        'btnDeleteType
        '
        Me.btnDeleteType.BorderRadius = 8
        Me.btnDeleteType.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteType.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteType.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteType.ForeColor = System.Drawing.Color.White
        Me.btnDeleteType.Location = New System.Drawing.Point(201, 10)
        Me.btnDeleteType.Name = "btnDeleteType"
        Me.btnDeleteType.Size = New System.Drawing.Size(180, 45)
        Me.btnDeleteType.TabIndex = 2
        Me.btnDeleteType.Text = "حذف"
        '
        'btnEditType
        '
        Me.btnEditType.BorderRadius = 8
        Me.btnEditType.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnEditType.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnEditType.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnEditType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnEditType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnEditType.ForeColor = System.Drawing.Color.White
        Me.btnEditType.Location = New System.Drawing.Point(395, 10)
        Me.btnEditType.Name = "btnEditType"
        Me.btnEditType.Size = New System.Drawing.Size(180, 45)
        Me.btnEditType.TabIndex = 1
        Me.btnEditType.Text = "تعديل"
        '
        'btnAddType
        '
        Me.btnAddType.BorderRadius = 8
        Me.btnAddType.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddType.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddType.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddType.ForeColor = System.Drawing.Color.White
        Me.btnAddType.Location = New System.Drawing.Point(589, 10)
        Me.btnAddType.Name = "btnAddType"
        Me.btnAddType.Size = New System.Drawing.Size(180, 45)
        Me.btnAddType.TabIndex = 0
        Me.btnAddType.Text = "اضافة"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(780, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 33)
        Me.Label2.TabIndex = 5614
        Me.Label2.Text = "كود النوع *"
        '
        'txtTypeCode
        '
        Me.txtTypeCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTypeCode.BorderRadius = 5
        Me.txtTypeCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTypeCode.DefaultText = ""
        Me.txtTypeCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTypeCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTypeCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTypeCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTypeCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTypeCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtTypeCode.ForeColor = System.Drawing.Color.Black
        Me.txtTypeCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTypeCode.Location = New System.Drawing.Point(479, 87)
        Me.txtTypeCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTypeCode.Name = "txtTypeCode"
        Me.txtTypeCode.PlaceholderText = ""
        Me.txtTypeCode.SelectedText = ""
        Me.txtTypeCode.Size = New System.Drawing.Size(292, 39)
        Me.txtTypeCode.TabIndex = 5613
        Me.txtTypeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(355, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 33)
        Me.Label1.TabIndex = 5616
        Me.Label1.Text = "اسم النوع *"
        '
        'txtTypeName
        '
        Me.txtTypeName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTypeName.BorderRadius = 5
        Me.txtTypeName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTypeName.DefaultText = ""
        Me.txtTypeName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTypeName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTypeName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTypeName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTypeName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTypeName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtTypeName.ForeColor = System.Drawing.Color.Black
        Me.txtTypeName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTypeName.Location = New System.Drawing.Point(54, 87)
        Me.txtTypeName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTypeName.Name = "txtTypeName"
        Me.txtTypeName.PlaceholderText = ""
        Me.txtTypeName.SelectedText = ""
        Me.txtTypeName.Size = New System.Drawing.Size(292, 39)
        Me.txtTypeName.TabIndex = 5615
        Me.txtTypeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(419, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 33)
        Me.Label6.TabIndex = 5623
        Me.Label6.Text = "نشط"
        '
        'tgStatus
        '
        Me.tgStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Location = New System.Drawing.Point(295, 150)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(93, 44)
        Me.tgStatus.TabIndex = 5622
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
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
        Me.btnClearFields.Image = Global.WindowsApp1.My.Resources.Resources.cleaning
        Me.btnClearFields.Location = New System.Drawing.Point(7, 10)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(180, 45)
        Me.btnClearFields.TabIndex = 3
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'frmCategoryTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 592)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tgStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTypeName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTypeCode)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.dgvCategoryTypes)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCategoryTypes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvCategoryTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvCategoryTypes As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents pn_title_page As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClearFields As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteType As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEditType As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddType As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTypeCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTypeName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
