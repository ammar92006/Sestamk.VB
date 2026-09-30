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
            Me.cardWebLinks = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardWebTitle = New System.Windows.Forms.Label()
            Me.lblCardWebSub = New System.Windows.Forms.Label()
            Me.btnWebHome = New Guna.UI2.WinForms.Guna2Button()
            Me.btnWebAbout = New Guna.UI2.WinForms.Guna2Button()
            Me.btnWebSupport = New Guna.UI2.WinForms.Guna2Button()
            Me.btnWebUpdates = New Guna.UI2.WinForms.Guna2Button()
            Me.btnWebTerms = New Guna.UI2.WinForms.Guna2Button()
            Me.btnWebPrivacy = New Guna.UI2.WinForms.Guna2Button()
            Me.btnWebAcademy = New Guna.UI2.WinForms.Guna2Button()
            Me.btnWebPortal = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardApp.SuspendLayout()
            Me.cardDev.SuspendLayout()
            Me.cardWebLinks.SuspendLayout()
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
            Me.pnlMain.Controls.Add(Me.cardWebLinks)
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
            Me.lblTitle.Location = New System.Drawing.Point(816, 20)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(358, 35)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "حول البرنامج والإصدار"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(566, 58)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(608, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "معلومات المنظومة، حقوق الملكية، وبيانات المطور والتواصل"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cardApp.Size = New System.Drawing.Size(1144, 175)
            Me.cardApp.TabIndex = 2
            '
            'lblAppName
            '
            Me.lblAppName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAppName.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblAppName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.lblAppName.Location = New System.Drawing.Point(516, 20)
            Me.lblAppName.Name = "lblAppName"
            Me.lblAppName.Size = New System.Drawing.Size(600, 36)
            Me.lblAppName.TabIndex = 0
            Me.lblAppName.Text = "سيستمك (Sestamk POS) — نظام نقاط البيع الشامل"
            Me.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblVersion
            '
            Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblVersion.ForeColor = System.Drawing.Color.Gainsboro
            Me.lblVersion.Location = New System.Drawing.Point(716, 62)
            Me.lblVersion.Name = "lblVersion"
            Me.lblVersion.Size = New System.Drawing.Size(400, 30)
            Me.lblVersion.TabIndex = 1
            Me.lblVersion.Text = "الإصدار: 1.0.0 Pro (نسخة سطح المكتب)"
            Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDescription
            '
            Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblDescription.Location = New System.Drawing.Point(30, 100)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(1086, 55)
            Me.lblDescription.TabIndex = 2
            Me.lblDescription.Text = "نظام متكامل لإدارة نقاط البيع والمطاعم والكافيهات والمتاجر، متابعة حركة المبيعات " &
    "والمخازن والخزائن، الفواتير الحرارية، وقارئات الباركود."
            Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cardDev.Size = New System.Drawing.Size(1144, 185)
            Me.cardDev.TabIndex = 3
            '
            'lblCardDevTitle
            '
            Me.lblCardDevTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardDevTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardDevTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardDevTitle.Location = New System.Drawing.Point(816, 15)
            Me.lblCardDevTitle.Name = "lblCardDevTitle"
            Me.lblCardDevTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardDevTitle.TabIndex = 0
            Me.lblCardDevTitle.Text = "👨‍💻 المطور والبرمجة"
            Me.lblCardDevTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDeveloper
            '
            Me.lblDeveloper.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDeveloper.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDeveloper.Location = New System.Drawing.Point(616, 55)
            Me.lblDeveloper.Name = "lblDeveloper"
            Me.lblDeveloper.Size = New System.Drawing.Size(500, 30)
            Me.lblDeveloper.TabIndex = 1
            Me.lblDeveloper.Text = "تم التصميم والبرمجة بواسطة: م / عمار أحمد"
            Me.lblDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblContact
            '
            Me.lblContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblContact.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblContact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblContact.Location = New System.Drawing.Point(616, 92)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(500, 30)
            Me.lblContact.TabIndex = 2
            Me.lblContact.Text = "للدعم الفني والاستفسار: 01500314353"
            Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRights
            '
            Me.lblRights.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblRights.Font = New System.Drawing.Font("Segoe UI", 10.5!)
            Me.lblRights.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.lblRights.Location = New System.Drawing.Point(616, 130)
            Me.lblRights.Name = "lblRights"
            Me.lblRights.Size = New System.Drawing.Size(500, 30)
            Me.lblRights.TabIndex = 3
            Me.lblRights.Text = "جميع الحقوق محفوظة © 2026 سيستمك (Sestamk)"
            Me.lblRights.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnClose
            '
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnClose.BorderRadius = 8
            Me.btnClose.BorderThickness = 1
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 725)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 48)
            Me.btnClose.TabIndex = 10
            Me.btnClose.Text = "❌ إغلاق"
            '
            'cardWebLinks
            '
            Me.cardWebLinks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardWebLinks.BackColor = System.Drawing.Color.Transparent
            Me.cardWebLinks.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardWebLinks.BorderRadius = 12
            Me.cardWebLinks.BorderThickness = 1
            Me.cardWebLinks.Controls.Add(Me.lblCardWebTitle)
            Me.cardWebLinks.Controls.Add(Me.lblCardWebSub)
            Me.cardWebLinks.Controls.Add(Me.btnWebHome)
            Me.cardWebLinks.Controls.Add(Me.btnWebAbout)
            Me.cardWebLinks.Controls.Add(Me.btnWebSupport)
            Me.cardWebLinks.Controls.Add(Me.btnWebUpdates)
            Me.cardWebLinks.Controls.Add(Me.btnWebTerms)
            Me.cardWebLinks.Controls.Add(Me.btnWebPrivacy)
            Me.cardWebLinks.Controls.Add(Me.btnWebAcademy)
            Me.cardWebLinks.Controls.Add(Me.btnWebPortal)
            Me.cardWebLinks.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardWebLinks.Location = New System.Drawing.Point(30, 485)
            Me.cardWebLinks.Name = "cardWebLinks"
            Me.cardWebLinks.Size = New System.Drawing.Size(1144, 215)
            Me.cardWebLinks.TabIndex = 4
            '
            'lblCardWebTitle
            '
            Me.lblCardWebTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardWebTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardWebTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardWebTitle.Location = New System.Drawing.Point(716, 16)
            Me.lblCardWebTitle.Name = "lblCardWebTitle"
            Me.lblCardWebTitle.Size = New System.Drawing.Size(403, 28)
            Me.lblCardWebTitle.TabIndex = 0
            Me.lblCardWebTitle.Text = "صفحات وخدمات موقع سستمك (sestamk.site.je)"
            Me.lblCardWebTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCardWebSub
            '
            Me.lblCardWebSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardWebSub.Font = New System.Drawing.Font("Segoe UI", 10.5!)
            Me.lblCardWebSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblCardWebSub.Location = New System.Drawing.Point(219, 48)
            Me.lblCardWebSub.Name = "lblCardWebSub"
            Me.lblCardWebSub.Size = New System.Drawing.Size(900, 24)
            Me.lblCardWebSub.TabIndex = 1
            Me.lblCardWebSub.Text = "تصفح الروابط المباشرة لخدمات النظام الرسمية، الدعم الفني، شروط الاستخدام، وسياسة " &
    "الخصوصية:"
            Me.lblCardWebSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnWebHome
            '
            Me.btnWebHome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWebHome.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnWebHome.BorderRadius = 8
            Me.btnWebHome.BorderThickness = 1
            Me.btnWebHome.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWebHome.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(54, Byte), Integer))
            Me.btnWebHome.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnWebHome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWebHome.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebHome.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebHome.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnWebHome.Location = New System.Drawing.Point(854, 85)
            Me.btnWebHome.Name = "btnWebHome"
            Me.btnWebHome.Size = New System.Drawing.Size(260, 46)
            Me.btnWebHome.TabIndex = 2
            Me.btnWebHome.Text = "الموقع الرسمي"
            '
            'btnWebAbout
            '
            Me.btnWebAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWebAbout.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnWebAbout.BorderRadius = 8
            Me.btnWebAbout.BorderThickness = 1
            Me.btnWebAbout.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWebAbout.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(54, Byte), Integer))
            Me.btnWebAbout.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnWebAbout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWebAbout.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebAbout.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebAbout.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnWebAbout.Location = New System.Drawing.Point(574, 85)
            Me.btnWebAbout.Name = "btnWebAbout"
            Me.btnWebAbout.Size = New System.Drawing.Size(260, 46)
            Me.btnWebAbout.TabIndex = 3
            Me.btnWebAbout.Text = "حول البرنامج (من نحن)"
            '
            'btnWebSupport
            '
            Me.btnWebSupport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWebSupport.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnWebSupport.BorderRadius = 8
            Me.btnWebSupport.BorderThickness = 1
            Me.btnWebSupport.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWebSupport.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(54, Byte), Integer))
            Me.btnWebSupport.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnWebSupport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWebSupport.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebSupport.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebSupport.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnWebSupport.Location = New System.Drawing.Point(294, 85)
            Me.btnWebSupport.Name = "btnWebSupport"
            Me.btnWebSupport.Size = New System.Drawing.Size(260, 46)
            Me.btnWebSupport.TabIndex = 4
            Me.btnWebSupport.Text = "الدعم الفني المباشر"
            '
            'btnWebUpdates
            '
            Me.btnWebUpdates.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWebUpdates.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnWebUpdates.BorderRadius = 8
            Me.btnWebUpdates.BorderThickness = 1
            Me.btnWebUpdates.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWebUpdates.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(54, Byte), Integer))
            Me.btnWebUpdates.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnWebUpdates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWebUpdates.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebUpdates.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebUpdates.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnWebUpdates.Location = New System.Drawing.Point(14, 85)
            Me.btnWebUpdates.Name = "btnWebUpdates"
            Me.btnWebUpdates.Size = New System.Drawing.Size(260, 46)
            Me.btnWebUpdates.TabIndex = 5
            Me.btnWebUpdates.Text = "سجل التحديثات"
            '
            'btnWebTerms
            '
            Me.btnWebTerms.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWebTerms.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnWebTerms.BorderRadius = 8
            Me.btnWebTerms.BorderThickness = 1
            Me.btnWebTerms.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWebTerms.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(54, Byte), Integer))
            Me.btnWebTerms.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnWebTerms.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWebTerms.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebTerms.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebTerms.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnWebTerms.Location = New System.Drawing.Point(854, 145)
            Me.btnWebTerms.Name = "btnWebTerms"
            Me.btnWebTerms.Size = New System.Drawing.Size(260, 46)
            Me.btnWebTerms.TabIndex = 6
            Me.btnWebTerms.Text = "شروط الاستخدام"
            '
            'btnWebPrivacy
            '
            Me.btnWebPrivacy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWebPrivacy.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnWebPrivacy.BorderRadius = 8
            Me.btnWebPrivacy.BorderThickness = 1
            Me.btnWebPrivacy.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWebPrivacy.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(54, Byte), Integer))
            Me.btnWebPrivacy.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnWebPrivacy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWebPrivacy.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebPrivacy.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebPrivacy.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnWebPrivacy.Location = New System.Drawing.Point(574, 145)
            Me.btnWebPrivacy.Name = "btnWebPrivacy"
            Me.btnWebPrivacy.Size = New System.Drawing.Size(260, 46)
            Me.btnWebPrivacy.TabIndex = 7
            Me.btnWebPrivacy.Text = "سياسة الخصوصية"
            '
            'btnWebAcademy
            '
            Me.btnWebAcademy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWebAcademy.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnWebAcademy.BorderRadius = 8
            Me.btnWebAcademy.BorderThickness = 1
            Me.btnWebAcademy.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWebAcademy.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(54, Byte), Integer))
            Me.btnWebAcademy.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnWebAcademy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWebAcademy.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebAcademy.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebAcademy.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnWebAcademy.Location = New System.Drawing.Point(294, 145)
            Me.btnWebAcademy.Name = "btnWebAcademy"
            Me.btnWebAcademy.Size = New System.Drawing.Size(260, 46)
            Me.btnWebAcademy.TabIndex = 8
            Me.btnWebAcademy.Text = "الأكاديمية والشروحات"
            '
            'btnWebPortal
            '
            Me.btnWebPortal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWebPortal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnWebPortal.BorderRadius = 8
            Me.btnWebPortal.BorderThickness = 1
            Me.btnWebPortal.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWebPortal.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(54, Byte), Integer))
            Me.btnWebPortal.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnWebPortal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWebPortal.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebPortal.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnWebPortal.HoverState.ForeColor = System.Drawing.Color.White
            Me.btnWebPortal.Location = New System.Drawing.Point(14, 145)
            Me.btnWebPortal.Name = "btnWebPortal"
            Me.btnWebPortal.Size = New System.Drawing.Size(260, 46)
            Me.btnWebPortal.TabIndex = 9
            Me.btnWebPortal.Text = "بوابة العملاء"
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
            Me.cardWebLinks.ResumeLayout(False)
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
        Friend WithEvents cardWebLinks As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardWebTitle As System.Windows.Forms.Label
        Friend WithEvents lblCardWebSub As System.Windows.Forms.Label
        Friend WithEvents btnWebHome As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnWebAbout As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnWebSupport As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnWebUpdates As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnWebTerms As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnWebPrivacy As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnWebAcademy As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnWebPortal As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
