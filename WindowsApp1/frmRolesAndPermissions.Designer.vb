<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRolesAndPermissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRolesAndPermissions))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.cmbRole = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvPermissions = New System.Windows.Forms.DataGridView()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtRoleName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRoleDescription = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnSavePermissions = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddRole = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteRole = New Guna.UI2.WinForms.Guna2Button()
        Me.chkSelectAll = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader.SuspendLayout()
        CType(Me.dgvPermissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btnClose)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1200, 70)
        Me.panelHeader.TabIndex = 42
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
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.AutoSize = True
        Me.btnClose.ImageOptions.SvgImage = CType(resources.GetObject("btnClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnClose.Location = New System.Drawing.Point(15, 17)
        Me.btnClose.Name = "btn_close"
        Me.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnClose.Size = New System.Drawing.Size(38, 36)
        Me.btnClose.TabIndex = 3
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(534, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(209, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الأدوار والصلاحيات"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmbRole
        '
        Me.cmbRole.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRole.BackColor = System.Drawing.Color.Transparent
        Me.cmbRole.BorderRadius = 6
        Me.cmbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRole.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbRole.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbRole.ForeColor = System.Drawing.Color.Black
        Me.cmbRole.ItemHeight = 30
        Me.cmbRole.Location = New System.Drawing.Point(793, 113)
        Me.cmbRole.Name = "cmbRole"
        Me.cmbRole.Size = New System.Drawing.Size(280, 36)
        Me.cmbRole.TabIndex = 5634
        Me.cmbRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1079, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 36)
        Me.Label4.TabIndex = 5633
        Me.Label4.Text = "الدور الوظيفي"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvPermissions
        '
        Me.dgvPermissions.AllowUserToResizeColumns = False
        Me.dgvPermissions.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvPermissions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPermissions.BackgroundColor = System.Drawing.Color.White
        Me.dgvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPermissions.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvPermissions.Location = New System.Drawing.Point(0, 70)
        Me.dgvPermissions.Name = "dgvPermissions"
        Me.dgvPermissions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvPermissions.RowTemplate.Height = 35
        Me.dgvPermissions.Size = New System.Drawing.Size(780, 657)
        Me.dgvPermissions.TabIndex = 5644
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(1079, 173)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(116, 36)
        Me.Label23.TabIndex = 5646
        Me.Label23.Text = "اسم الدور *"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRoleName
        '
        Me.txtRoleName.BorderRadius = 6
        Me.txtRoleName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRoleName.DefaultText = ""
        Me.txtRoleName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtRoleName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRoleName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRoleName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRoleName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRoleName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtRoleName.ForeColor = System.Drawing.Color.Black
        Me.txtRoleName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRoleName.Location = New System.Drawing.Point(793, 173)
        Me.txtRoleName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRoleName.Name = "txtRoleName"
        Me.txtRoleName.PlaceholderText = ""
        Me.txtRoleName.SelectedText = ""
        Me.txtRoleName.Size = New System.Drawing.Size(280, 36)
        Me.txtRoleName.TabIndex = 5645
        Me.txtRoleName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(1079, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 36)
        Me.Label1.TabIndex = 5648
        Me.Label1.Text = "وصف الدور"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRoleDescription
        '
        Me.txtRoleDescription.BorderRadius = 6
        Me.txtRoleDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRoleDescription.DefaultText = ""
        Me.txtRoleDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtRoleDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRoleDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRoleDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRoleDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRoleDescription.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtRoleDescription.ForeColor = System.Drawing.Color.Black
        Me.txtRoleDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRoleDescription.Location = New System.Drawing.Point(793, 233)
        Me.txtRoleDescription.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRoleDescription.Multiline = True
        Me.txtRoleDescription.Name = "txtRoleDescription"
        Me.txtRoleDescription.PlaceholderText = ""
        Me.txtRoleDescription.SelectedText = ""
        Me.txtRoleDescription.Size = New System.Drawing.Size(280, 75)
        Me.txtRoleDescription.TabIndex = 5647
        Me.txtRoleDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSavePermissions
        '
        Me.btnSavePermissions.BorderRadius = 6
        Me.btnSavePermissions.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSavePermissions.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSavePermissions.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSavePermissions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSavePermissions.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSavePermissions.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSavePermissions.ForeColor = System.Drawing.Color.White
        Me.btnSavePermissions.Location = New System.Drawing.Point(925, 673)
        Me.btnSavePermissions.Name = "btnSavePermissions"
        Me.btnSavePermissions.Size = New System.Drawing.Size(128, 42)
        Me.btnSavePermissions.TabIndex = 5650
        Me.btnSavePermissions.Text = "حفظ الصلاحيات"
        '
        'btnAddRole
        '
        Me.btnAddRole.BorderRadius = 6
        Me.btnAddRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddRole.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnAddRole.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddRole.ForeColor = System.Drawing.Color.White
        Me.btnAddRole.Location = New System.Drawing.Point(1064, 673)
        Me.btnAddRole.Name = "btnAddRole"
        Me.btnAddRole.Size = New System.Drawing.Size(128, 42)
        Me.btnAddRole.TabIndex = 5649
        Me.btnAddRole.Text = "إضافة دور جديد"
        '
        'btnDeleteRole
        '
        Me.btnDeleteRole.BorderRadius = 6
        Me.btnDeleteRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteRole.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDeleteRole.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteRole.ForeColor = System.Drawing.Color.White
        Me.btnDeleteRole.Location = New System.Drawing.Point(786, 673)
        Me.btnDeleteRole.Name = "btnDeleteRole"
        Me.btnDeleteRole.Size = New System.Drawing.Size(128, 42)
        Me.btnDeleteRole.TabIndex = 5651
        Me.btnDeleteRole.Text = "حذف الدور"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSelectAll.CheckedState.BorderRadius = 0
        Me.chkSelectAll.CheckedState.BorderThickness = 0
        Me.chkSelectAll.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSelectAll.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSelectAll.Location = New System.Drawing.Point(1043, 328)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(154, 24)
        Me.chkSelectAll.TabIndex = 5653
        Me.chkSelectAll.Text = "تحديد كل الصلاحيات"
        Me.chkSelectAll.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSelectAll.UncheckedState.BorderRadius = 0
        Me.chkSelectAll.UncheckedState.BorderThickness = 0
        Me.chkSelectAll.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.DragForm = False
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'frmRolesAndPermissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 727)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.btnDeleteRole)
        Me.Controls.Add(Me.btnSavePermissions)
        Me.Controls.Add(Me.btnAddRole)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRoleDescription)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtRoleName)
        Me.Controls.Add(Me.dgvPermissions)
        Me.Controls.Add(Me.cmbRole)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmRolesAndPermissions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.dgvPermissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cmbRole As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvPermissions As DataGridView
    Friend WithEvents Label23 As Label
    Friend WithEvents txtRoleName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRoleDescription As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSavePermissions As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddRole As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteRole As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents chkSelectAll As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
