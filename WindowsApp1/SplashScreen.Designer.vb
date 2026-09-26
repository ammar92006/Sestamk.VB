<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlTopGlow = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlLogoEmblem = New Guna.UI2.WinForms.Guna2Panel()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitleEnglish = New System.Windows.Forms.Label()
        Me.lblSubtitleArabic = New System.Windows.Forms.Label()
        Me.pnlBadgeVersion = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.pnlLoadingBox = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.pnlFooter = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlLogoEmblem.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBadgeVersion.SuspendLayout()
        Me.pnlLoadingBox.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 20
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 15
        '
        'Timer2
        '
        Me.Timer2.Interval = 15
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlTopGlow)
        Me.pnlMain.Controls.Add(Me.pnlLogoEmblem)
        Me.pnlMain.Controls.Add(Me.lblTitleEnglish)
        Me.pnlMain.Controls.Add(Me.lblSubtitleArabic)
        Me.pnlMain.Controls.Add(Me.pnlBadgeVersion)
        Me.pnlMain.Controls.Add(Me.pnlLoadingBox)
        Me.pnlMain.Controls.Add(Me.pnlFooter)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(700, 440)
        Me.pnlMain.TabIndex = 0
        '
        'pnlTopGlow
        '
        Me.pnlTopGlow.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopGlow.FillColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlTopGlow.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopGlow.Name = "pnlTopGlow"
        Me.pnlTopGlow.Size = New System.Drawing.Size(700, 10)
        Me.pnlTopGlow.TabIndex = 0
        '
        'pnlLogoEmblem
        '
        Me.pnlLogoEmblem.BackColor = System.Drawing.Color.Transparent
        Me.pnlLogoEmblem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlLogoEmblem.BorderRadius = 24
        Me.pnlLogoEmblem.BorderThickness = 1
        Me.pnlLogoEmblem.Controls.Add(Me.picLogo)
        Me.pnlLogoEmblem.FillColor = System.Drawing.Color.White
        Me.pnlLogoEmblem.Location = New System.Drawing.Point(265, 30)
        Me.pnlLogoEmblem.Name = "pnlLogoEmblem"
        Me.pnlLogoEmblem.Size = New System.Drawing.Size(170, 160)
        Me.pnlLogoEmblem.TabIndex = 1
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Image = Global.WindowsApp1.My.Resources.Resources.loge
        Me.picLogo.Location = New System.Drawing.Point(15, 10)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(140, 140)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 0
        Me.picLogo.TabStop = False
        '
        'lblTitleEnglish
        '
        Me.lblTitleEnglish.BackColor = System.Drawing.Color.Transparent
        Me.lblTitleEnglish.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleEnglish.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.lblTitleEnglish.Location = New System.Drawing.Point(50, 204)
        Me.lblTitleEnglish.Name = "lblTitleEnglish"
        Me.lblTitleEnglish.Size = New System.Drawing.Size(600, 22)
        Me.lblTitleEnglish.TabIndex = 2
        Me.lblTitleEnglish.Text = "SESTAMK POS & ERP SYSTEMS"
        Me.lblTitleEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTitleEnglish.UseMnemonic = False
        '
        'lblSubtitleArabic
        '
        Me.lblSubtitleArabic.BackColor = System.Drawing.Color.Transparent
        Me.lblSubtitleArabic.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitleArabic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.lblSubtitleArabic.Location = New System.Drawing.Point(50, 230)
        Me.lblSubtitleArabic.Name = "lblSubtitleArabic"
        Me.lblSubtitleArabic.Size = New System.Drawing.Size(600, 24)
        Me.lblSubtitleArabic.TabIndex = 3
        Me.lblSubtitleArabic.Text = "نظام متكامل لإدارة نقاط البيع والمطاعم والمخازن"
        Me.lblSubtitleArabic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSubtitleArabic.UseMnemonic = False
        '
        'pnlBadgeVersion
        '
        Me.pnlBadgeVersion.BackColor = System.Drawing.Color.Transparent
        Me.pnlBadgeVersion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlBadgeVersion.BorderRadius = 12
        Me.pnlBadgeVersion.BorderThickness = 2
        Me.pnlBadgeVersion.Controls.Add(Me.lblVersion)
        Me.pnlBadgeVersion.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.pnlBadgeVersion.Location = New System.Drawing.Point(270, 264)
        Me.pnlBadgeVersion.Name = "pnlBadgeVersion"
        Me.pnlBadgeVersion.Size = New System.Drawing.Size(160, 28)
        Me.pnlBadgeVersion.TabIndex = 4
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblVersion.Location = New System.Drawing.Point(0, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(160, 28)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "الإصدار V 2.0 • 2026"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblVersion.UseMnemonic = False
        '
        'pnlLoadingBox
        '
        Me.pnlLoadingBox.BackColor = System.Drawing.Color.Transparent
        Me.pnlLoadingBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlLoadingBox.BorderRadius = 14
        Me.pnlLoadingBox.BorderThickness = 1
        Me.pnlLoadingBox.Controls.Add(Me.Label5)
        Me.pnlLoadingBox.Controls.Add(Me.lblPercent)
        Me.pnlLoadingBox.Controls.Add(Me.ProgressBar1)
        Me.pnlLoadingBox.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.pnlLoadingBox.Location = New System.Drawing.Point(60, 308)
        Me.pnlLoadingBox.Name = "pnlLoadingBox"
        Me.pnlLoadingBox.Size = New System.Drawing.Size(580, 72)
        Me.pnlLoadingBox.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(120, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(440, 24)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "جاري تشغيل البرنامج وتهيئة قاعدة البيانات..."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.UseMnemonic = False
        '
        'lblPercent
        '
        Me.lblPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblPercent.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPercent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.lblPercent.Location = New System.Drawing.Point(16, 12)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPercent.Size = New System.Drawing.Size(80, 24)
        Me.lblPercent.TabIndex = 1
        Me.lblPercent.Text = "0%"
        Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPercent.UseMnemonic = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BorderRadius = 4
        Me.ProgressBar1.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 44)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ProgressBar1.Size = New System.Drawing.Size(548, 8)
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.Transparent
        Me.pnlFooter.Controls.Add(Me.Label2)
        Me.pnlFooter.Controls.Add(Me.lblCopyright)
        Me.pnlFooter.Location = New System.Drawing.Point(60, 396)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(580, 26)
        Me.pnlFooter.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(290, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(290, 26)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "تصميم وتطوير: م / عمار أحمد"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.UseMnemonic = False
        '
        'lblCopyright
        '
        Me.lblCopyright.BackColor = System.Drawing.Color.Transparent
        Me.lblCopyright.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCopyright.Location = New System.Drawing.Point(0, 0)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCopyright.Size = New System.Drawing.Size(280, 26)
        Me.lblCopyright.TabIndex = 1
        Me.lblCopyright.Text = "جميع الحقوق محفوظة © سستمك 2026"
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCopyright.UseMnemonic = False
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(700, 440)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SplashScreen"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سستمك - جاري التحميل"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlLogoEmblem.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBadgeVersion.ResumeLayout(False)
        Me.pnlLoadingBox.ResumeLayout(False)
        Me.pnlFooter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlTopGlow As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlLogoEmblem As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lblTitleEnglish As Label
    Friend WithEvents lblSubtitleArabic As Label
    Friend WithEvents pnlBadgeVersion As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblVersion As Label
    Friend WithEvents pnlLoadingBox As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPercent As Label
    Friend WithEvents ProgressBar1 As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents pnlFooter As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblCopyright As Label
End Class
