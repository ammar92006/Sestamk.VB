<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormActivation
    Inherits BaseForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormActivation))
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.LabelDeveloper = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLicense = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_Staff = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.lblHWID = New System.Windows.Forms.Label()
        Me.btnCopyHwid = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSupport = New Guna.UI2.WinForms.Guna2Button()
        Me.progressActivation = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.panelHeader.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panelHeader.Size = New System.Drawing.Size(700, 70)
        Me.panelHeader.TabIndex = 71
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
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("LBC", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(240, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(218, 49)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "تفعيل البرنامج"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.LabelDeveloper)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 580)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Guna2Panel1.Size = New System.Drawing.Size(700, 70)
        Me.Guna2Panel1.TabIndex = 72
        '
        'LabelDeveloper
        '
        Me.LabelDeveloper.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelDeveloper.AutoSize = True
        Me.LabelDeveloper.Font = New System.Drawing.Font("LBC", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.LabelDeveloper.Location = New System.Drawing.Point(120, 15)
        Me.LabelDeveloper.Name = "LabelDeveloper"
        Me.LabelDeveloper.Size = New System.Drawing.Size(460, 35)
        Me.LabelDeveloper.TabIndex = 1
        Me.LabelDeveloper.Text = "تم تصميم هذا البرنامج بواسطة عمار احمد"
        Me.LabelDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("LBC", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(542, 380)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 31)
        Me.Label4.TabIndex = 5562
        Me.Label4.Text = "رقم التفعيل:"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'txtLicense
        '
        Me.txtLicense.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLicense.DefaultText = ""
        Me.txtLicense.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtLicense.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtLicense.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtLicense.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtLicense.ForeColor = System.Drawing.Color.Black
        Me.txtLicense.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtLicense.Location = New System.Drawing.Point(40, 375)
        Me.txtLicense.Margin = New System.Windows.Forms.Padding(5)
        Me.txtLicense.Name = "txtLicense"
        Me.txtLicense.PlaceholderText = ""
        Me.txtLicense.SelectedText = ""
        Me.txtLicense.Size = New System.Drawing.Size(490, 45)
        Me.txtLicense.TabIndex = 5561
        Me.txtLicense.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_Staff
        '
        Me.btn_Staff.Appearance.Font = New System.Drawing.Font("LBC", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Staff.Appearance.Options.UseFont = True
        Me.btn_Staff.ImageOptions.Image = CType(resources.GetObject("btn_Staff.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_Staff.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_Staff.Location = New System.Drawing.Point(180, 440)
        Me.btn_Staff.Name = "btn_Staff"
        Me.btn_Staff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_Staff.Size = New System.Drawing.Size(340, 60)
        Me.btn_Staff.TabIndex = 5563
        Me.btn_Staff.Text = "تفعيل"
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'picQRCode
        '
        Me.picQRCode.Location = New System.Drawing.Point(250, 90)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(200, 200)
        Me.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQRCode.TabIndex = 5564
        Me.picQRCode.TabStop = False
        Me.picQRCode.BackColor = System.Drawing.Color.White
        '
        'lblHWID
        '
        Me.lblHWID.Font = New System.Drawing.Font("Consolas", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHWID.ForeColor = System.Drawing.Color.White
        Me.lblHWID.Location = New System.Drawing.Point(150, 310)
        Me.lblHWID.Name = "lblHWID"
        Me.lblHWID.Size = New System.Drawing.Size(400, 40)
        Me.lblHWID.TabIndex = 5565
        Me.lblHWID.Text = "HWID-XXXX-XXXX"
        Me.lblHWID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCopyHwid
        '
        Me.btnCopyHwid.Appearance.Font = New System.Drawing.Font("LBC", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyHwid.Appearance.Options.UseFont = True
        Me.btnCopyHwid.ImageOptions.SvgImage = CType(resources.GetObject("btnCopyHwid.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnCopyHwid.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.btnCopyHwid.Location = New System.Drawing.Point(40, 310)
        Me.btnCopyHwid.Name = "btnCopyHwid"
        Me.btnCopyHwid.Size = New System.Drawing.Size(100, 40)
        Me.btnCopyHwid.TabIndex = 5566
        Me.btnCopyHwid.Text = "نسخ"
        '
        'btnSupport
        '
        Me.btnSupport.BorderRadius = 5
        Me.btnSupport.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSupport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSupport.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSupport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSupport.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.btnSupport.Font = New System.Drawing.Font("LBC", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupport.ForeColor = System.Drawing.Color.White
        Me.btnSupport.Location = New System.Drawing.Point(180, 510)
        Me.btnSupport.Name = "btnSupport"
        Me.btnSupport.Size = New System.Drawing.Size(340, 45)
        Me.btnSupport.TabIndex = 5567
        Me.btnSupport.Text = "الدعم الفني (WhatsApp)"
        '
        'progressActivation
        '
        Me.progressActivation.Location = New System.Drawing.Point(0, 70)
        Me.progressActivation.Name = "progressActivation"
        Me.progressActivation.Size = New System.Drawing.Size(700, 5)
        Me.progressActivation.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressActivation.TabIndex = 5568
        Me.progressActivation.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.progressActivation.Visible = False
        '
        'FormActivation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(700, 650)
        Me.Controls.Add(Me.progressActivation)
        Me.Controls.Add(Me.btnSupport)
        Me.Controls.Add(Me.btnCopyHwid)
        Me.Controls.Add(Me.lblHWID)
        Me.Controls.Add(Me.picQRCode)
        Me.Controls.Add(Me.btn_Staff)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtLicense)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormActivation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تفعيل البرنامج"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents LabelDeveloper As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLicense As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_Staff As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents picQRCode As PictureBox
    Friend WithEvents lblHWID As Label
    Friend WithEvents btnCopyHwid As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSupport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents progressActivation As Guna.UI2.WinForms.Guna2ProgressBar
End Class
