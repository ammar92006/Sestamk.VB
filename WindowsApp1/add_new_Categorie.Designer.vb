<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_new_Categorie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(add_new_Categorie))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCategoryCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCategoryName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cmbColor = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDeleteImage = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSelectImage = New Guna.UI2.WinForms.Guna2Button()
        Me.picCategory = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClearFields = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel1.SuspendLayout()
        CType(Me.picCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(885, 68)
        Me.Panel1.TabIndex = 0
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(14, 17)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 398)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(885, 48)
        Me.Panel2.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(775, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 36)
        Me.Label6.TabIndex = 5618
        Me.Label6.Text = "كود الفئة *"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCategoryCode
        '
        Me.txtCategoryCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategoryCode.BorderRadius = 6
        Me.txtCategoryCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoryCode.DefaultText = ""
        Me.txtCategoryCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCategoryCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCategoryCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCategoryCode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCategoryCode.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCategoryCode.Location = New System.Drawing.Point(526, 86)
        Me.txtCategoryCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCategoryCode.Name = "txtCategoryCode"
        Me.txtCategoryCode.PlaceholderText = ""
        Me.txtCategoryCode.SelectedText = ""
        Me.txtCategoryCode.Size = New System.Drawing.Size(245, 36)
        Me.txtCategoryCode.TabIndex = 5617
        Me.txtCategoryCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(775, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 36)
        Me.Label1.TabIndex = 5620
        Me.Label1.Text = "اسم الفئة *"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCategoryName
        '
        Me.txtCategoryName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategoryName.BorderRadius = 6
        Me.txtCategoryName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoryName.DefaultText = ""
        Me.txtCategoryName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCategoryName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCategoryName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCategoryName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCategoryName.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCategoryName.Location = New System.Drawing.Point(526, 144)
        Me.txtCategoryName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.PlaceholderText = ""
        Me.txtCategoryName.SelectedText = ""
        Me.txtCategoryName.Size = New System.Drawing.Size(245, 36)
        Me.txtCategoryName.TabIndex = 5619
        Me.txtCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbColor
        '
        Me.cmbColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbColor.BackColor = System.Drawing.Color.Transparent
        Me.cmbColor.BorderRadius = 6
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbColor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbColor.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbColor.ForeColor = System.Drawing.Color.Black
        Me.cmbColor.ItemHeight = 30
        Me.cmbColor.Location = New System.Drawing.Point(526, 202)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(245, 36)
        Me.cmbColor.TabIndex = 5622
        Me.cmbColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(775, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 36)
        Me.Label2.TabIndex = 5621
        Me.Label2.Text = "لون الفئة"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btnDeleteImage.Location = New System.Drawing.Point(330, 191)
        Me.btnDeleteImage.Name = "btnDeleteImage"
        Me.btnDeleteImage.Size = New System.Drawing.Size(65, 95)
        Me.btnDeleteImage.TabIndex = 5625
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
        Me.btnSelectImage.Location = New System.Drawing.Point(330, 86)
        Me.btnSelectImage.Name = "btnSelectImage"
        Me.btnSelectImage.Size = New System.Drawing.Size(65, 95)
        Me.btnSelectImage.TabIndex = 5624
        '
        'picCategory
        '
        Me.picCategory.BorderRadius = 8
        Me.picCategory.ImageRotate = 0!
        Me.picCategory.Location = New System.Drawing.Point(24, 86)
        Me.picCategory.Name = "picCategory"
        Me.picCategory.Size = New System.Drawing.Size(300, 200)
        Me.picCategory.TabIndex = 5623
        Me.picCategory.TabStop = False
        '
        'tgStatus
        '
        Me.tgStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Location = New System.Drawing.Point(423, 252)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(70, 34)
        Me.tgStatus.TabIndex = 5627
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(409, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 36)
        Me.Label3.TabIndex = 5628
        Me.Label3.Text = "حاله الفئة"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(340, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 36)
        Me.Label4.TabIndex = 5619
        Me.Label4.Text = "اضافة فئة جديدة"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClearFields
        '
        Me.btnClearFields.BorderRadius = 6
        Me.btnClearFields.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFields.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFields.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearFields.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearFields.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearFields.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearFields.ForeColor = System.Drawing.Color.White
        Me.btnClearFields.Location = New System.Drawing.Point(216, 315)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(210, 77)
        Me.btnClearFields.TabIndex = 5630
        Me.btnClearFields.Text = "عرض الفئات"
        '
        'btnAdd
        '
        Me.btnAdd.BorderRadius = 6
        Me.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(456, 315)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(210, 77)
        Me.btnAdd.TabIndex = 5629
        Me.btnAdd.Text = "إضافة"
        '
        'add_new_Categorie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 446)
        Me.Controls.Add(Me.btnClearFields)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tgStatus)
        Me.Controls.Add(Me.btnDeleteImage)
        Me.Controls.Add(Me.btnSelectImage)
        Me.Controls.Add(Me.picCategory)
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCategoryName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCategoryCode)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "add_new_Categorie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "add_new_Categorie"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCategoryCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCategoryName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cmbColor As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnDeleteImage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSelectImage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents picCategory As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnClearFields As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
End Class
