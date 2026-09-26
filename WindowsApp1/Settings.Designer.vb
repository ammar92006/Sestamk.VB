<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.pnlTopBar = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnWinClose = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btnWinMax = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btnWinMin = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btnThemeToggle = New Guna.UI2.WinForms.Guna2Button()
        Me.lblTopTitle = New System.Windows.Forms.Label()
        Me.pnlSidebar = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlSidebarButtons = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnAbout = New Guna.UI2.WinForms.Guna2Button()
        Me.btnUpdatesSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnActivationSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNotificationsSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDataExportSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDatabaseSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnReceiptSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnScannerSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrinterSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSalesSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSystemSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlSidebarHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblSettingsSubtitle = New System.Windows.Forms.Label()
        Me.lblSettingsTitle = New System.Windows.Forms.Label()
        Me.panelMain = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlTopBar.SuspendLayout()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlSidebarButtons.SuspendLayout()
        Me.pnlSidebarHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'guna2BorderlessForm1
        '
        Me.guna2BorderlessForm1.BorderRadius = 15
        Me.guna2BorderlessForm1.ContainerControl = Me
        Me.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'pnlTopBar
        '
        Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.pnlTopBar.Controls.Add(Me.btnWinClose)
        Me.pnlTopBar.Controls.Add(Me.btnWinMax)
        Me.pnlTopBar.Controls.Add(Me.btnWinMin)
        Me.pnlTopBar.Controls.Add(Me.btnThemeToggle)
        Me.pnlTopBar.Controls.Add(Me.lblTopTitle)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(1600, 45)
        Me.pnlTopBar.TabIndex = 0
        '
        'btnWinClose
        '
        Me.btnWinClose.FillColor = System.Drawing.Color.Transparent
        Me.btnWinClose.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnWinClose.HoverState.IconColor = System.Drawing.Color.White
        Me.btnWinClose.IconColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnWinClose.Location = New System.Drawing.Point(5, 5)
        Me.btnWinClose.Name = "btnWinClose"
        Me.btnWinClose.Size = New System.Drawing.Size(40, 35)
        Me.btnWinClose.TabIndex = 3
        '
        'btnWinMax
        '
        Me.btnWinMax.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox
        Me.btnWinMax.FillColor = System.Drawing.Color.Transparent
        Me.btnWinMax.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnWinMax.HoverState.IconColor = System.Drawing.Color.White
        Me.btnWinMax.IconColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnWinMax.Location = New System.Drawing.Point(48, 5)
        Me.btnWinMax.Name = "btnWinMax"
        Me.btnWinMax.Size = New System.Drawing.Size(40, 35)
        Me.btnWinMax.TabIndex = 2
        '
        'btnWinMin
        '
        Me.btnWinMin.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btnWinMin.FillColor = System.Drawing.Color.Transparent
        Me.btnWinMin.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnWinMin.HoverState.IconColor = System.Drawing.Color.White
        Me.btnWinMin.IconColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnWinMin.Location = New System.Drawing.Point(91, 5)
        Me.btnWinMin.Name = "btnWinMin"
        Me.btnWinMin.Size = New System.Drawing.Size(40, 35)
        Me.btnWinMin.TabIndex = 1
        '
        'btnThemeToggle
        '
        Me.btnThemeToggle.BorderRadius = 8
        Me.btnThemeToggle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnThemeToggle.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnThemeToggle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnThemeToggle.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnThemeToggle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnThemeToggle.FillColor = System.Drawing.Color.Transparent
        Me.btnThemeToggle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnThemeToggle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnThemeToggle.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnThemeToggle.Location = New System.Drawing.Point(140, 5)
        Me.btnThemeToggle.Name = "btnThemeToggle"
        Me.btnThemeToggle.Size = New System.Drawing.Size(140, 35)
        Me.btnThemeToggle.TabIndex = 4
        Me.btnThemeToggle.Text = "🌙 وضع داكن"
        '
        'lblTopTitle
        '
        Me.lblTopTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTopTitle.AutoSize = True
        Me.lblTopTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTopTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblTopTitle.Location = New System.Drawing.Point(1420, 12)
        Me.lblTopTitle.Name = "lblTopTitle"
        Me.lblTopTitle.Size = New System.Drawing.Size(172, 20)
        Me.lblTopTitle.TabIndex = 0
        Me.lblTopTitle.Text = "لوحة التحكم في الإعدادات"
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.pnlSidebarButtons)
        Me.pnlSidebar.Controls.Add(Me.pnlSidebarHeader)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSidebar.Location = New System.Drawing.Point(1320, 45)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(280, 955)
        Me.pnlSidebar.TabIndex = 1
        '
        'pnlSidebarButtons
        '
        Me.pnlSidebarButtons.AutoScroll = True
        Me.pnlSidebarButtons.Controls.Add(Me.btnAbout)
        Me.pnlSidebarButtons.Controls.Add(Me.btnUpdatesSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnActivationSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnNotificationsSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnDataExportSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnDatabaseSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnReceiptSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnScannerSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnPrinterSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnSalesSettings)
        Me.pnlSidebarButtons.Controls.Add(Me.btnSystemSettings)
        Me.pnlSidebarButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSidebarButtons.Location = New System.Drawing.Point(0, 100)
        Me.pnlSidebarButtons.Name = "pnlSidebarButtons"
        Me.pnlSidebarButtons.Padding = New System.Windows.Forms.Padding(12, 10, 12, 20)
        Me.pnlSidebarButtons.Size = New System.Drawing.Size(280, 855)
        Me.pnlSidebarButtons.TabIndex = 1
        '
        'btnAbout
        '
        Me.btnAbout.BorderRadius = 10
        Me.btnAbout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnAbout.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnAbout.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnAbout.FillColor = System.Drawing.Color.Empty
        Me.btnAbout.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnAbout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnAbout.Image = Global.WindowsApp1.My.Resources.Resources.information1
        Me.btnAbout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnAbout.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnAbout.Location = New System.Drawing.Point(12, 610)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(256, 54)
        Me.btnAbout.TabIndex = 10
        Me.btnAbout.Text = "حول البرنامج"
        '
        'btnUpdatesSettings
        '
        Me.btnUpdatesSettings.BorderRadius = 10
        Me.btnUpdatesSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnUpdatesSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnUpdatesSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnUpdatesSettings.FillColor = System.Drawing.Color.Empty
        Me.btnUpdatesSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdatesSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnUpdatesSettings.Image = Global.WindowsApp1.My.Resources.Resources.update
        Me.btnUpdatesSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnUpdatesSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnUpdatesSettings.Location = New System.Drawing.Point(12, 550)
        Me.btnUpdatesSettings.Name = "btnUpdatesSettings"
        Me.btnUpdatesSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnUpdatesSettings.TabIndex = 9
        Me.btnUpdatesSettings.Text = "التحديثات والترقية"
        '
        'btnActivationSettings
        '
        Me.btnActivationSettings.BorderRadius = 10
        Me.btnActivationSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnActivationSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnActivationSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnActivationSettings.FillColor = System.Drawing.Color.Empty
        Me.btnActivationSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnActivationSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnActivationSettings.Image = Global.WindowsApp1.My.Resources.Resources.activation
        Me.btnActivationSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnActivationSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnActivationSettings.Location = New System.Drawing.Point(12, 490)
        Me.btnActivationSettings.Name = "btnActivationSettings"
        Me.btnActivationSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnActivationSettings.TabIndex = 8
        Me.btnActivationSettings.Text = "إدارة التفعيل"
        '
        'btnNotificationsSettings
        '
        Me.btnNotificationsSettings.BorderRadius = 10
        Me.btnNotificationsSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnNotificationsSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnNotificationsSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnNotificationsSettings.FillColor = System.Drawing.Color.Empty
        Me.btnNotificationsSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnNotificationsSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnNotificationsSettings.Image = Global.WindowsApp1.My.Resources.Resources.notification
        Me.btnNotificationsSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnNotificationsSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnNotificationsSettings.Location = New System.Drawing.Point(12, 430)
        Me.btnNotificationsSettings.Name = "btnNotificationsSettings"
        Me.btnNotificationsSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnNotificationsSettings.TabIndex = 7
        Me.btnNotificationsSettings.Text = "الإشعارات والتنبيهات"
        '
        'btnDataExportSettings
        '
        Me.btnDataExportSettings.BorderRadius = 10
        Me.btnDataExportSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnDataExportSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnDataExportSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnDataExportSettings.FillColor = System.Drawing.Color.Empty
        Me.btnDataExportSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnDataExportSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnDataExportSettings.Image = Global.WindowsApp1.My.Resources.Resources.data_processing
        Me.btnDataExportSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnDataExportSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnDataExportSettings.Location = New System.Drawing.Point(12, 370)
        Me.btnDataExportSettings.Name = "btnDataExportSettings"
        Me.btnDataExportSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnDataExportSettings.TabIndex = 6
        Me.btnDataExportSettings.Text = "تصدير واستيراد البيانات"
        '
        'btnDatabaseSettings
        '
        Me.btnDatabaseSettings.BorderRadius = 10
        Me.btnDatabaseSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnDatabaseSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnDatabaseSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnDatabaseSettings.FillColor = System.Drawing.Color.Empty
        Me.btnDatabaseSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnDatabaseSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnDatabaseSettings.Image = Global.WindowsApp1.My.Resources.Resources.database
        Me.btnDatabaseSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnDatabaseSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnDatabaseSettings.Location = New System.Drawing.Point(12, 310)
        Me.btnDatabaseSettings.Name = "btnDatabaseSettings"
        Me.btnDatabaseSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnDatabaseSettings.TabIndex = 5
        Me.btnDatabaseSettings.Text = "إعدادات قاعدة البيانات"
        '
        'btnReceiptSettings
        '
        Me.btnReceiptSettings.BorderRadius = 10
        Me.btnReceiptSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnReceiptSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnReceiptSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnReceiptSettings.FillColor = System.Drawing.Color.Empty
        Me.btnReceiptSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnReceiptSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnReceiptSettings.Image = Global.WindowsApp1.My.Resources.Resources.invoice
        Me.btnReceiptSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnReceiptSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnReceiptSettings.Location = New System.Drawing.Point(12, 250)
        Me.btnReceiptSettings.Name = "btnReceiptSettings"
        Me.btnReceiptSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnReceiptSettings.TabIndex = 4
        Me.btnReceiptSettings.Text = "إعدادات الفاتورة"
        '
        'btnScannerSettings
        '
        Me.btnScannerSettings.BorderRadius = 10
        Me.btnScannerSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnScannerSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnScannerSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnScannerSettings.FillColor = System.Drawing.Color.Empty
        Me.btnScannerSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnScannerSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnScannerSettings.Image = Global.WindowsApp1.My.Resources.Resources.barcode
        Me.btnScannerSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnScannerSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnScannerSettings.Location = New System.Drawing.Point(12, 190)
        Me.btnScannerSettings.Name = "btnScannerSettings"
        Me.btnScannerSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnScannerSettings.TabIndex = 3
        Me.btnScannerSettings.Text = "إعدادات الاسكنر"
        '
        'btnPrinterSettings
        '
        Me.btnPrinterSettings.BorderRadius = 10
        Me.btnPrinterSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnPrinterSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnPrinterSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnPrinterSettings.FillColor = System.Drawing.Color.Empty
        Me.btnPrinterSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrinterSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnPrinterSettings.Image = Global.WindowsApp1.My.Resources.Resources.print
        Me.btnPrinterSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnPrinterSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnPrinterSettings.Location = New System.Drawing.Point(12, 130)
        Me.btnPrinterSettings.Name = "btnPrinterSettings"
        Me.btnPrinterSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnPrinterSettings.TabIndex = 2
        Me.btnPrinterSettings.Text = "إعدادات الطابعة"
        '
        'btnSalesSettings
        '
        Me.btnSalesSettings.BorderRadius = 10
        Me.btnSalesSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnSalesSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnSalesSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnSalesSettings.FillColor = System.Drawing.Color.Empty
        Me.btnSalesSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalesSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnSalesSettings.Image = Global.WindowsApp1.My.Resources.Resources.discount__1_
        Me.btnSalesSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSalesSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnSalesSettings.Location = New System.Drawing.Point(12, 70)
        Me.btnSalesSettings.Name = "btnSalesSettings"
        Me.btnSalesSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnSalesSettings.TabIndex = 1
        Me.btnSalesSettings.Text = "إعدادات البيع"
        '
        'btnSystemSettings
        '
        Me.btnSystemSettings.BorderRadius = 10
        Me.btnSystemSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnSystemSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnSystemSettings.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnSystemSettings.FillColor = System.Drawing.Color.Empty
        Me.btnSystemSettings.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnSystemSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnSystemSettings.Image = Global.WindowsApp1.My.Resources.Resources.settings__3_
        Me.btnSystemSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSystemSettings.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnSystemSettings.Location = New System.Drawing.Point(12, 10)
        Me.btnSystemSettings.Name = "btnSystemSettings"
        Me.btnSystemSettings.Size = New System.Drawing.Size(256, 54)
        Me.btnSystemSettings.TabIndex = 0
        Me.btnSystemSettings.Text = " إعدادات النظام"
        '
        'pnlSidebarHeader
        '
        Me.pnlSidebarHeader.Controls.Add(Me.lblSettingsSubtitle)
        Me.pnlSidebarHeader.Controls.Add(Me.lblSettingsTitle)
        Me.pnlSidebarHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSidebarHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebarHeader.Name = "pnlSidebarHeader"
        Me.pnlSidebarHeader.Size = New System.Drawing.Size(280, 100)
        Me.pnlSidebarHeader.TabIndex = 0
        '
        'lblSettingsSubtitle
        '
        Me.lblSettingsSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSettingsSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblSettingsSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.lblSettingsSubtitle.Location = New System.Drawing.Point(20, 56)
        Me.lblSettingsSubtitle.Name = "lblSettingsSubtitle"
        Me.lblSettingsSubtitle.Size = New System.Drawing.Size(245, 25)
        Me.lblSettingsSubtitle.TabIndex = 1
        Me.lblSettingsSubtitle.Text = "إدارة إعدادات النظام"
        Me.lblSettingsSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSettingsTitle
        '
        Me.lblSettingsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSettingsTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblSettingsTitle.ForeColor = System.Drawing.Color.White
        Me.lblSettingsTitle.Location = New System.Drawing.Point(40, 14)
        Me.lblSettingsTitle.Name = "lblSettingsTitle"
        Me.lblSettingsTitle.Size = New System.Drawing.Size(225, 37)
        Me.lblSettingsTitle.TabIndex = 0
        Me.lblSettingsTitle.Text = "الإعدادات"
        Me.lblSettingsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelMain
        '
        Me.panelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 45)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(1320, 955)
        Me.panelMain.TabIndex = 2
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1600, 1000)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.pnlTopBar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Settings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الإعدادات"
        Me.pnlTopBar.ResumeLayout(False)
        Me.pnlTopBar.PerformLayout()
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebarButtons.ResumeLayout(False)
        Me.pnlSidebarHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents pnlTopBar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnWinClose As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btnWinMax As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btnWinMin As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btnThemeToggle As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTopTitle As System.Windows.Forms.Label
    Friend WithEvents pnlSidebar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlSidebarHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblSettingsTitle As System.Windows.Forms.Label
    Friend WithEvents lblSettingsSubtitle As System.Windows.Forms.Label
    Friend WithEvents pnlSidebarButtons As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnSystemSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSalesSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPrinterSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnScannerSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnReceiptSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDatabaseSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDataExportSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNotificationsSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnActivationSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnUpdatesSettings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAbout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents panelMain As Guna.UI2.WinForms.Guna2Panel
End Class
