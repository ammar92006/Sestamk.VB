<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOwnerPortalQR
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnCloseHeader = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlContainer = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlNavTabs = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnTabOwner = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTabWaiter = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTabKDS = New Guna.UI2.WinForms.Guna2Button()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.picQRCode = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblStatusBadge = New System.Windows.Forms.Label()
        Me.txtPortalUrl = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnCopyUrl = New Guna.UI2.WinForms.Guna2Button()
        Me.btnOpenBrowser = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.panelHeader.SuspendLayout()
        Me.pnlContainer.SuspendLayout()
        Me.pnlNavTabs.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 14
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btnCloseHeader)
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Padding = New System.Windows.Forms.Padding(16, 12, 16, 12)
        Me.panelHeader.Size = New System.Drawing.Size(480, 60)
        Me.panelHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(120, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(280, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📱 بوابات سستمك الذكية (Live)"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCloseHeader
        '
        Me.btnCloseHeader.BorderRadius = 8
        Me.btnCloseHeader.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCloseHeader.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnCloseHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCloseHeader.ForeColor = System.Drawing.Color.White
        Me.btnCloseHeader.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnCloseHeader.Location = New System.Drawing.Point(12, 12)
        Me.btnCloseHeader.Name = "btnCloseHeader"
        Me.btnCloseHeader.Size = New System.Drawing.Size(36, 36)
        Me.btnCloseHeader.TabIndex = 1
        Me.btnCloseHeader.Text = "✕"
        '
        'pnlContainer
        '
        Me.pnlContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlContainer.Controls.Add(Me.btnClose)
        Me.pnlContainer.Controls.Add(Me.btnOpenBrowser)
        Me.pnlContainer.Controls.Add(Me.btnCopyUrl)
        Me.pnlContainer.Controls.Add(Me.txtPortalUrl)
        Me.pnlContainer.Controls.Add(Me.lblStatusBadge)
        Me.pnlContainer.Controls.Add(Me.picQRCode)
        Me.pnlContainer.Controls.Add(Me.lblInstructions)
        Me.pnlContainer.Controls.Add(Me.pnlNavTabs)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 60)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Padding = New System.Windows.Forms.Padding(18)
        Me.pnlContainer.Size = New System.Drawing.Size(480, 580)
        Me.pnlContainer.TabIndex = 1
        '
        'pnlNavTabs
        '
        Me.pnlNavTabs.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.pnlNavTabs.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.pnlNavTabs.BorderRadius = 10
        Me.pnlNavTabs.BorderThickness = 1
        Me.pnlNavTabs.Controls.Add(Me.btnTabKDS)
        Me.pnlNavTabs.Controls.Add(Me.btnTabWaiter)
        Me.pnlNavTabs.Controls.Add(Me.btnTabOwner)
        Me.pnlNavTabs.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNavTabs.Location = New System.Drawing.Point(18, 18)
        Me.pnlNavTabs.Name = "pnlNavTabs"
        Me.pnlNavTabs.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlNavTabs.Size = New System.Drawing.Size(444, 46)
        Me.pnlNavTabs.TabIndex = 0
        '
        'btnTabOwner
        '
        Me.btnTabOwner.BorderRadius = 8
        Me.btnTabOwner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTabOwner.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnTabOwner.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnTabOwner.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnTabOwner.ForeColor = System.Drawing.Color.White
        Me.btnTabOwner.Location = New System.Drawing.Point(298, 4)
        Me.btnTabOwner.Name = "btnTabOwner"
        Me.btnTabOwner.Size = New System.Drawing.Size(142, 38)
        Me.btnTabOwner.TabIndex = 0
        Me.btnTabOwner.Text = "📱 بوابة المالك"
        '
        'btnTabWaiter
        '
        Me.btnTabWaiter.BorderRadius = 8
        Me.btnTabWaiter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTabWaiter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTabWaiter.FillColor = System.Drawing.Color.Transparent
        Me.btnTabWaiter.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnTabWaiter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnTabWaiter.Location = New System.Drawing.Point(146, 4)
        Me.btnTabWaiter.Name = "btnTabWaiter"
        Me.btnTabWaiter.Size = New System.Drawing.Size(152, 38)
        Me.btnTabWaiter.TabIndex = 1
        Me.btnTabWaiter.Text = "🍽️ تابلت الويتر"
        '
        'btnTabKDS
        '
        Me.btnTabKDS.BorderRadius = 8
        Me.btnTabKDS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTabKDS.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnTabKDS.FillColor = System.Drawing.Color.Transparent
        Me.btnTabKDS.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnTabKDS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnTabKDS.Location = New System.Drawing.Point(4, 4)
        Me.btnTabKDS.Name = "btnTabKDS"
        Me.btnTabKDS.Size = New System.Drawing.Size(142, 38)
        Me.btnTabKDS.TabIndex = 2
        Me.btnTabKDS.Text = "🧑‍🍳 شاشة المطبخ"
        '
        'lblInstructions
        '
        Me.lblInstructions.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInstructions.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.lblInstructions.Location = New System.Drawing.Point(18, 64)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblInstructions.Size = New System.Drawing.Size(444, 48)
        Me.lblInstructions.TabIndex = 1
        Me.lblInstructions.Text = "امسح الرمز بكاميرا هاتفك وأنت متصل بنفس شبكة الواي فاي لمتابعة مبيعات اليوم وإشغال" &
    " الصالة لحظة بلحظة:"
        Me.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picQRCode
        '
        Me.picQRCode.BorderRadius = 12
        Me.picQRCode.FillColor = System.Drawing.Color.White
        Me.picQRCode.ImageRotate = 0!
        Me.picQRCode.Location = New System.Drawing.Point(125, 120)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(230, 230)
        Me.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQRCode.TabIndex = 2
        Me.picQRCode.TabStop = False
        '
        'lblStatusBadge
        '
        Me.lblStatusBadge.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusBadge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.lblStatusBadge.Location = New System.Drawing.Point(18, 360)
        Me.lblStatusBadge.Name = "lblStatusBadge"
        Me.lblStatusBadge.Size = New System.Drawing.Size(444, 22)
        Me.lblStatusBadge.TabIndex = 3
        Me.lblStatusBadge.Text = "🟢 السيرفر يعمل ونشط على شبكة المطعم المحلية (Port 5055)"
        Me.lblStatusBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPortalUrl
        '
        Me.txtPortalUrl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.txtPortalUrl.BorderRadius = 8
        Me.txtPortalUrl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPortalUrl.DefaultText = "http://127.0.0.1:5055/"
        Me.txtPortalUrl.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtPortalUrl.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtPortalUrl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtPortalUrl.Location = New System.Drawing.Point(50, 390)
        Me.txtPortalUrl.Name = "txtPortalUrl"
        Me.txtPortalUrl.ReadOnly = True
        Me.txtPortalUrl.Size = New System.Drawing.Size(380, 38)
        Me.txtPortalUrl.TabIndex = 4
        Me.txtPortalUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCopyUrl
        '
        Me.btnCopyUrl.BorderRadius = 8
        Me.btnCopyUrl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopyUrl.FillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnCopyUrl.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCopyUrl.ForeColor = System.Drawing.Color.White
        Me.btnCopyUrl.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnCopyUrl.Location = New System.Drawing.Point(50, 440)
        Me.btnCopyUrl.Name = "btnCopyUrl"
        Me.btnCopyUrl.Size = New System.Drawing.Size(185, 42)
        Me.btnCopyUrl.TabIndex = 5
        Me.btnCopyUrl.Text = "📋 نسخ الرابط"
        '
        'btnOpenBrowser
        '
        Me.btnOpenBrowser.BorderRadius = 8
        Me.btnOpenBrowser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenBrowser.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnOpenBrowser.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnOpenBrowser.ForeColor = System.Drawing.Color.White
        Me.btnOpenBrowser.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnOpenBrowser.Location = New System.Drawing.Point(245, 440)
        Me.btnOpenBrowser.Name = "btnOpenBrowser"
        Me.btnOpenBrowser.Size = New System.Drawing.Size(185, 42)
        Me.btnOpenBrowser.TabIndex = 6
        Me.btnOpenBrowser.Text = "🌐 فتح في المتصفح"
        '
        'btnClose
        '
        Me.btnClose.BorderRadius = 8
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FillColor = System.Drawing.Color.Transparent
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnClose.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(170, 500)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(140, 32)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "إغلاق النافذة"
        '
        'FrmOwnerPortalQR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(480, 640)
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmOwnerPortalQR"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlNavTabs.ResumeLayout(False)
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnCloseHeader As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlContainer As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlNavTabs As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnTabOwner As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTabWaiter As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTabKDS As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblInstructions As Label
    Friend WithEvents picQRCode As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lblStatusBadge As Label
    Friend WithEvents txtPortalUrl As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnCopyUrl As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnOpenBrowser As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button

End Class
