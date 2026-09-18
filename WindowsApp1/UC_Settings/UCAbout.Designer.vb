Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCAbout
        Inherits System.Windows.Forms.UserControl

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

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.cardApp = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblAppName = New System.Windows.Forms.Label()
            Me.lblVersion = New System.Windows.Forms.Label()
            Me.lblDescription = New System.Windows.Forms.Label()
            Me.cardDev = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardDevTitle = New System.Windows.Forms.Label()
            Me.lblDeveloper = New System.Windows.Forms.Label()
            Me.lblContact = New System.Windows.Forms.Label()
            Me.lblRights = New System.Windows.Forms.Label()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardApp.SuspendLayout()
            Me.cardDev.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardApp)
            Me.pnlMain.Controls.Add(Me.cardDev)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 560)
            Me.pnlMain.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(850, 20)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(358, 35)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "حول البرنامج والإصدار"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(600, 58)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(608, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "معلومات المنظومة، حقوق الملكية، وبيانات المطور والتواصل"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardApp
            '
            Me.cardApp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardApp.BackColor = System.Drawing.Color.Transparent
            Me.cardApp.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardApp.BorderRadius = 12
            Me.cardApp.BorderThickness = 1
            Me.cardApp.Controls.Add(Me.lblAppName)
            Me.cardApp.Controls.Add(Me.lblVersion)
            Me.cardApp.Controls.Add(Me.lblDescription)
            Me.cardApp.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardApp.Location = New System.Drawing.Point(30, 95)
            Me.cardApp.Name = "cardApp"
            Me.cardApp.Size = New System.Drawing.Size(1178, 175)
            Me.cardApp.TabIndex = 2
            '
            'lblAppName
            '
            Me.lblAppName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAppName.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblAppName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.lblAppName.Location = New System.Drawing.Point(550, 20)
            Me.lblAppName.Name = "lblAppName"
            Me.lblAppName.Size = New System.Drawing.Size(600, 36)
            Me.lblAppName.TabIndex = 0
            Me.lblAppName.Text = "سيستمك (Sestamk POS) — نظام نقاط البيع الشامل"
            Me.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblVersion
            '
            Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblVersion.ForeColor = System.Drawing.Color.Gainsboro
            Me.lblVersion.Location = New System.Drawing.Point(750, 62)
            Me.lblVersion.Name = "lblVersion"
            Me.lblVersion.Size = New System.Drawing.Size(400, 30)
            Me.lblVersion.TabIndex = 1
            Me.lblVersion.Text = "الإصدار: 1.0.0 Pro (نسخة سطح المكتب)"
            Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDescription
            '
            Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblDescription.Location = New System.Drawing.Point(30, 100)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(1120, 55)
            Me.lblDescription.TabIndex = 2
            Me.lblDescription.Text = "نظام متكامل لإدارة نقاط البيع والمطاعم والكافيهات والمتاجر، متابعة حركة المبيعات" & _
    " والمخازن والخزائن، الفواتير الحرارية، وقارئات الباركود."
            Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cardDev
            '
            Me.cardDev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardDev.BackColor = System.Drawing.Color.Transparent
            Me.cardDev.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardDev.BorderRadius = 12
            Me.cardDev.BorderThickness = 1
            Me.cardDev.Controls.Add(Me.lblCardDevTitle)
            Me.cardDev.Controls.Add(Me.lblDeveloper)
            Me.cardDev.Controls.Add(Me.lblContact)
            Me.cardDev.Controls.Add(Me.lblRights)
            Me.cardDev.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardDev.Location = New System.Drawing.Point(30, 285)
            Me.cardDev.Name = "cardDev"
            Me.cardDev.Size = New System.Drawing.Size(1178, 185)
            Me.cardDev.TabIndex = 3
            '
            'lblCardDevTitle
            '
            Me.lblCardDevTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardDevTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardDevTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardDevTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardDevTitle.Name = "lblCardDevTitle"
            Me.lblCardDevTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardDevTitle.TabIndex = 0
            Me.lblCardDevTitle.Text = "👨‍💻 المطور والبرمجة"
            Me.lblCardDevTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDeveloper
            '
            Me.lblDeveloper.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDeveloper.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDeveloper.Location = New System.Drawing.Point(650, 55)
            Me.lblDeveloper.Name = "lblDeveloper"
            Me.lblDeveloper.Size = New System.Drawing.Size(500, 30)
            Me.lblDeveloper.TabIndex = 1
            Me.lblDeveloper.Text = "تم التصميم والبرمجة بواسطة: م / عمار أحمد"
            Me.lblDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblContact
            '
            Me.lblContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblContact.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblContact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblContact.Location = New System.Drawing.Point(650, 92)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(500, 30)
            Me.lblContact.TabIndex = 2
            Me.lblContact.Text = "للدعم الفني والاستفسار: 01091523321"
            Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRights
            '
            Me.lblRights.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblRights.Font = New System.Drawing.Font("Segoe UI", 10.5!)
            Me.lblRights.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.lblRights.Location = New System.Drawing.Point(650, 130)
            Me.lblRights.Name = "lblRights"
            Me.lblRights.Size = New System.Drawing.Size(500, 30)
            Me.lblRights.TabIndex = 3
            Me.lblRights.Text = "جميع الحقوق محفوظة © 2026 سيستمك (Sestamk)"
            Me.lblRights.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnClose
            '
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnClose.BorderRadius = 8
            Me.btnClose.BorderThickness = 1
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 490)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 48)
            Me.btnClose.TabIndex = 4
            Me.btnClose.Text = "❌ إغلاق"
            '
            'UCAbout
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCAbout"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 560)
            Me.pnlMain.ResumeLayout(False)
            Me.cardApp.ResumeLayout(False)
            Me.cardDev.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardApp As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblAppName As System.Windows.Forms.Label
        Friend WithEvents lblVersion As System.Windows.Forms.Label
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents cardDev As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardDevTitle As System.Windows.Forms.Label
        Friend WithEvents lblDeveloper As System.Windows.Forms.Label
        Friend WithEvents lblContact As System.Windows.Forms.Label
        Friend WithEvents lblRights As System.Windows.Forms.Label
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
