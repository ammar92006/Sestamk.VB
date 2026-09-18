<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCCategoryCard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pnlColor = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCategoryName = New System.Windows.Forms.Label()
        Me.picCategory = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.pnlColor.SuspendLayout()
        CType(Me.picCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlColor
        '
        Me.pnlColor.Controls.Add(Me.lblCategoryName)
        Me.pnlColor.Controls.Add(Me.picCategory)
        Me.pnlColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlColor.Location = New System.Drawing.Point(0, 0)
        Me.pnlColor.Name = "pnlColor"
        Me.pnlColor.Size = New System.Drawing.Size(150, 150)
        Me.pnlColor.TabIndex = 0
        '
        'lblCategoryName
        '
        Me.lblCategoryName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCategoryName.BackColor = System.Drawing.Color.DarkGray
        Me.lblCategoryName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCategoryName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblCategoryName.Location = New System.Drawing.Point(18, 96)
        Me.lblCategoryName.Name = "lblCategoryName"
        Me.lblCategoryName.Size = New System.Drawing.Size(114, 49)
        Me.lblCategoryName.TabIndex = 5588
        Me.lblCategoryName.Text = "اسم الحجم انجليزي"
        Me.lblCategoryName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picCategory
        '
        Me.picCategory.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picCategory.FillColor = System.Drawing.Color.Empty
        Me.picCategory.ImageRotate = 0!
        Me.picCategory.Location = New System.Drawing.Point(18, 10)
        Me.picCategory.Name = "picCategory"
        Me.picCategory.Size = New System.Drawing.Size(114, 77)
        Me.picCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCategory.TabIndex = 0
        Me.picCategory.TabStop = False
        '
        'UCCategoryCard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.pnlColor)
        Me.Name = "UCCategoryCard"
        Me.pnlColor.ResumeLayout(False)
        CType(Me.picCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlColor As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents picCategory As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblCategoryName As Label
End Class
