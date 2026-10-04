<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmToastAdvanced
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
        Me.components = New System.ComponentModel.Container()
        Me.guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnExpand = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.lblIcon = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.progressBar = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.pnlAccent = New System.Windows.Forms.Panel()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.guna2Panel1.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'guna2Panel1
        '
        Me.guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.guna2Panel1.BorderRadius = 15
        Me.guna2Panel1.Controls.Add(Me.pnlButtons)
        Me.guna2Panel1.Controls.Add(Me.btnExpand)
        Me.guna2Panel1.Controls.Add(Me.btnClose)
        Me.guna2Panel1.Controls.Add(Me.picIcon)
        Me.guna2Panel1.Controls.Add(Me.lblIcon)
        Me.guna2Panel1.Controls.Add(Me.lblTitle)
        Me.guna2Panel1.Controls.Add(Me.lblMessage)
        Me.guna2Panel1.Controls.Add(Me.progressBar)
        Me.guna2Panel1.Controls.Add(Me.pnlAccent)
        Me.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.guna2Panel1.Name = "guna2Panel1"
        Me.guna2Panel1.ShadowDecoration.BorderRadius = 15
        Me.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.guna2Panel1.ShadowDecoration.Depth = 12
        Me.guna2Panel1.ShadowDecoration.Enabled = True
        Me.guna2Panel1.Size = New System.Drawing.Size(380, 110)
        Me.guna2Panel1.TabIndex = 0
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.Transparent
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 68)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(375, 42)
        Me.pnlButtons.TabIndex = 8
        Me.pnlButtons.Visible = False
        '
        'btnExpand
        '
        Me.btnExpand.BackColor = System.Drawing.Color.Transparent
        Me.btnExpand.BorderRadius = 5
        Me.btnExpand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExpand.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnExpand.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnExpand.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnExpand.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnExpand.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnExpand.Location = New System.Drawing.Point(41, 5)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(28, 28)
        Me.btnExpand.TabIndex = 7
        Me.btnExpand.Text = "▼"
        Me.btnExpand.Visible = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BorderRadius = 5
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnClose.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(7, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(28, 28)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "✕"
        '
        'picIcon
        '
        Me.picIcon.BackColor = System.Drawing.Color.Transparent
        Me.picIcon.Location = New System.Drawing.Point(322, 20)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(48, 48)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcon.TabIndex = 6
        Me.picIcon.TabStop = False
        Me.picIcon.Visible = False
        '
        'lblIcon
        '
        Me.lblIcon.BackColor = System.Drawing.Color.Transparent
        Me.lblIcon.Font = New System.Drawing.Font("Segoe UI Emoji", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblIcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblIcon.Location = New System.Drawing.Point(322, 22)
        Me.lblIcon.Name = "lblIcon"
        Me.lblIcon.Size = New System.Drawing.Size(48, 46)
        Me.lblIcon.TabIndex = 1
        Me.lblIcon.Text = "✓"
        Me.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(75, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitle.Size = New System.Drawing.Size(245, 25)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "عنوان الإشعار"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(10, 38)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(310, 25)
        Me.lblMessage.TabIndex = 3
        Me.lblMessage.Text = "محتوى الرسالة"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'progressBar
        '
        Me.progressBar.BackColor = System.Drawing.Color.Transparent
        Me.progressBar.BorderRadius = 3
        Me.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.progressBar.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.progressBar.Location = New System.Drawing.Point(0, 104)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.progressBar.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.progressBar.Size = New System.Drawing.Size(375, 6)
        Me.progressBar.TabIndex = 4
        Me.progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.progressBar.Visible = False
        '
        'pnlAccent
        '
        Me.pnlAccent.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.pnlAccent.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAccent.Location = New System.Drawing.Point(375, 0)
        Me.pnlAccent.Name = "pnlAccent"
        Me.pnlAccent.Size = New System.Drawing.Size(5, 110)
        Me.pnlAccent.TabIndex = 4
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 12
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'frmToastAdvanced
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(380, 110)
        Me.Controls.Add(Me.guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmToastAdvanced"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TopMost = True
        Me.guna2Panel1.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExpand As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblIcon As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents progressBar As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents pnlAccent As System.Windows.Forms.Panel
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
