<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblHeaderBranch = New System.Windows.Forms.Label()
        Me.txtGlobalSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblProBadge = New Guna.UI2.WinForms.Guna2Button()
        Me.lbltitle = New System.Windows.Forms.Label()
        Me.picLogo = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.btnLogout = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSupport = New Guna.UI2.WinForms.Guna2Button()
        Me.lblStatusUserRole = New System.Windows.Forms.Label()
        Me.btn_min = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_max = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_close = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlSidebar = New Guna.UI2.WinForms.Guna2Panel()
        Me.flpNav = New System.Windows.Forms.FlowLayoutPanel()
        Me.navDashboard = New Guna.UI2.WinForms.Guna2Button()
        Me.navSales = New Guna.UI2.WinForms.Guna2Button()
        Me.navSystem = New Guna.UI2.WinForms.Guna2Button()
        Me.navInventory = New Guna.UI2.WinForms.Guna2Button()
        Me.navPurchases = New Guna.UI2.WinForms.Guna2Button()
        Me.navCustomers = New Guna.UI2.WinForms.Guna2Button()
        Me.navSuppliers = New Guna.UI2.WinForms.Guna2Button()
        Me.navTreasury = New Guna.UI2.WinForms.Guna2Button()
        Me.navExpenses = New Guna.UI2.WinForms.Guna2Button()
        Me.navEmployees = New Guna.UI2.WinForms.Guna2Button()
        Me.navUsers = New Guna.UI2.WinForms.Guna2Button()
        Me.navSettings = New Guna.UI2.WinForms.Guna2Button()
        Me.statusStripMain = New System.Windows.Forms.StatusStrip()
        Me.lblStatusDb = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusRole = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusBranch = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusShift = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusDateTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sepStatus6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlMainContainer = New System.Windows.Forms.Panel()
        Me.tmrClock = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDashboardRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.panelHeader.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSidebar.SuspendLayout()
        Me.flpNav.SuspendLayout()
        Me.statusStripMain.SuspendLayout()
        Me.pnlMainContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.Controls.Add(Me.lblHeaderBranch)
        Me.panelHeader.Controls.Add(Me.txtGlobalSearch)
        Me.panelHeader.Controls.Add(Me.lblProBadge)
        Me.panelHeader.Controls.Add(Me.lbltitle)
        Me.panelHeader.Controls.Add(Me.picLogo)
        Me.panelHeader.Controls.Add(Me.btnLogout)
        Me.panelHeader.Controls.Add(Me.btnSupport)
        Me.panelHeader.Controls.Add(Me.lblStatusUserRole)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.FillColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1400, 70)
        Me.panelHeader.TabIndex = 3
        '
        'lblHeaderBranch
        '
        Me.lblHeaderBranch.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderBranch.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblHeaderBranch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHeaderBranch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.lblHeaderBranch.Location = New System.Drawing.Point(579, 8)
        Me.lblHeaderBranch.Name = "lblHeaderBranch"
        Me.lblHeaderBranch.Padding = New System.Windows.Forms.Padding(0, 10, 10, 0)
        Me.lblHeaderBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblHeaderBranch.Size = New System.Drawing.Size(159, 54)
        Me.lblHeaderBranch.TabIndex = 0
        Me.lblHeaderBranch.Text = "الفرع الرئيسي"
        Me.lblHeaderBranch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtGlobalSearch
        '
        Me.txtGlobalSearch.BackColor = System.Drawing.Color.Transparent
        Me.txtGlobalSearch.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.txtGlobalSearch.BorderRadius = 10
        Me.txtGlobalSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlobalSearch.DefaultText = ""
        Me.txtGlobalSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtGlobalSearch.FillColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.txtGlobalSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGlobalSearch.ForeColor = System.Drawing.Color.White
        Me.txtGlobalSearch.IconLeft = Global.WindowsApp1.My.Resources.Resources.search
        Me.txtGlobalSearch.IconLeftSize = New System.Drawing.Size(16, 16)
        Me.txtGlobalSearch.Location = New System.Drawing.Point(738, 8)
        Me.txtGlobalSearch.Margin = New System.Windows.Forms.Padding(12, 3, 12, 3)
        Me.txtGlobalSearch.Name = "txtGlobalSearch"
        Me.txtGlobalSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.txtGlobalSearch.PlaceholderText = "بحث سريع في الشاشات (Ctrl+K)..."
        Me.txtGlobalSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtGlobalSearch.SelectedText = ""
        Me.txtGlobalSearch.Size = New System.Drawing.Size(300, 54)
        Me.txtGlobalSearch.TabIndex = 1
        '
        'lblProBadge
        '
        Me.lblProBadge.BackColor = System.Drawing.Color.Transparent
        Me.lblProBadge.BorderRadius = 10
        Me.lblProBadge.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblProBadge.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblProBadge.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblProBadge.ForeColor = System.Drawing.Color.White
        Me.lblProBadge.Location = New System.Drawing.Point(1038, 8)
        Me.lblProBadge.Margin = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.lblProBadge.Name = "lblProBadge"
        Me.lblProBadge.Size = New System.Drawing.Size(85, 54)
        Me.lblProBadge.TabIndex = 2
        Me.lblProBadge.Text = "PRO EDITION"
        '
        'lbltitle
        '
        Me.lbltitle.AutoSize = True
        Me.lbltitle.BackColor = System.Drawing.Color.Transparent
        Me.lbltitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbltitle.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lbltitle.ForeColor = System.Drawing.Color.White
        Me.lbltitle.Location = New System.Drawing.Point(1123, 8)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Padding = New System.Windows.Forms.Padding(10, 8, 10, 0)
        Me.lbltitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbltitle.Size = New System.Drawing.Size(214, 29)
        Me.lbltitle.TabIndex = 3
        Me.lbltitle.Text = "سستمك POS لإدارة المطاعم"
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.picLogo.Image = Global.WindowsApp1.My.Resources.Resources.restaurant_building
        Me.picLogo.ImageRotate = 0!
        Me.picLogo.Location = New System.Drawing.Point(1337, 8)
        Me.picLogo.Margin = New System.Windows.Forms.Padding(5)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(53, 54)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 4
        Me.picLogo.TabStop = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.Transparent
        Me.btnLogout.BorderColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnLogout.BorderRadius = 8
        Me.btnLogout.BorderThickness = 1
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLogout.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.btnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnLogout.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Image = Global.WindowsApp1.My.Resources.Resources.logout
        Me.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnLogout.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnLogout.Location = New System.Drawing.Point(417, 8)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnLogout.Size = New System.Drawing.Size(123, 54)
        Me.btnLogout.TabIndex = 8
        Me.btnLogout.Text = "  خروج"
        '
        'btnSupport
        '
        Me.btnSupport.BackColor = System.Drawing.Color.Transparent
        Me.btnSupport.BorderColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.btnSupport.BorderRadius = 8
        Me.btnSupport.BorderThickness = 1
        Me.btnSupport.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSupport.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnSupport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSupport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.btnSupport.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnSupport.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnSupport.Image = Global.WindowsApp1.My.Resources.Resources.customer_support
        Me.btnSupport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSupport.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnSupport.Location = New System.Drawing.Point(285, 8)
        Me.btnSupport.Margin = New System.Windows.Forms.Padding(6, 2, 6, 2)
        Me.btnSupport.Name = "btnSupport"
        Me.btnSupport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSupport.Size = New System.Drawing.Size(132, 54)
        Me.btnSupport.TabIndex = 9
        Me.btnSupport.Text = "  دعم فني"
        '
        'lblStatusUserRole
        '
        Me.lblStatusUserRole.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusUserRole.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblStatusUserRole.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusUserRole.ForeColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblStatusUserRole.Location = New System.Drawing.Point(139, 8)
        Me.lblStatusUserRole.Name = "lblStatusUserRole"
        Me.lblStatusUserRole.Padding = New System.Windows.Forms.Padding(8, 10, 8, 0)
        Me.lblStatusUserRole.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblStatusUserRole.Size = New System.Drawing.Size(146, 54)
        Me.lblStatusUserRole.TabIndex = 10
        Me.lblStatusUserRole.Text = "المدير العام (مدير النظام)"
        Me.lblStatusUserRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_min
        '
        Me.btn_min.BackColor = System.Drawing.Color.Transparent
        Me.btn_min.BorderRadius = 8
        Me.btn_min.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_min.FillColor = System.Drawing.Color.Transparent
        Me.btn_min.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_min.ForeColor = System.Drawing.Color.White
        Me.btn_min.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btn_min.Location = New System.Drawing.Point(101, 8)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.Size = New System.Drawing.Size(38, 54)
        Me.btn_min.TabIndex = 7
        Me.btn_min.Text = "—"
        '
        'btn_max
        '
        Me.btn_max.BackColor = System.Drawing.Color.Transparent
        Me.btn_max.BorderRadius = 8
        Me.btn_max.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_max.FillColor = System.Drawing.Color.Transparent
        Me.btn_max.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_max.ForeColor = System.Drawing.Color.White
        Me.btn_max.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btn_max.Location = New System.Drawing.Point(63, 8)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.Size = New System.Drawing.Size(38, 54)
        Me.btn_max.TabIndex = 6
        Me.btn_max.Text = "▢"
        '
        'btn_close
        '
        Me.btn_close.BackColor = System.Drawing.Color.Transparent
        Me.btn_close.BorderRadius = 8
        Me.btn_close.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_close.FillColor = System.Drawing.Color.Transparent
        Me.btn_close.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_close.ForeColor = System.Drawing.Color.White
        Me.btn_close.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_close.Location = New System.Drawing.Point(10, 8)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(53, 54)
        Me.btn_close.TabIndex = 5
        Me.btn_close.Text = "✕"
        '
        'pnlSidebar
        '
        Me.pnlSidebar.Controls.Add(Me.flpNav)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.pnlSidebar.Location = New System.Drawing.Point(1180, 70)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlSidebar.Size = New System.Drawing.Size(220, 758)
        Me.pnlSidebar.TabIndex = 1
        '
        'flpNav
        '
        Me.flpNav.AutoScroll = True
        Me.flpNav.Controls.Add(Me.navDashboard)
        Me.flpNav.Controls.Add(Me.navSales)
        Me.flpNav.Controls.Add(Me.navSystem)
        Me.flpNav.Controls.Add(Me.navInventory)
        Me.flpNav.Controls.Add(Me.navPurchases)
        Me.flpNav.Controls.Add(Me.navCustomers)
        Me.flpNav.Controls.Add(Me.navSuppliers)
        Me.flpNav.Controls.Add(Me.navTreasury)
        Me.flpNav.Controls.Add(Me.navExpenses)
        Me.flpNav.Controls.Add(Me.navEmployees)
        Me.flpNav.Controls.Add(Me.navUsers)
        Me.flpNav.Controls.Add(Me.navSettings)
        Me.flpNav.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpNav.Location = New System.Drawing.Point(0, 0)
        Me.flpNav.Name = "flpNav"
        Me.flpNav.Padding = New System.Windows.Forms.Padding(6, 10, 6, 10)
        Me.flpNav.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.flpNav.Size = New System.Drawing.Size(220, 758)
        Me.flpNav.TabIndex = 0
        Me.flpNav.WrapContents = False
        '
        'navDashboard
        '
        Me.navDashboard.BorderRadius = 10
        Me.navDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navDashboard.FillColor = System.Drawing.Color.Transparent
        Me.navDashboard.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navDashboard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navDashboard.HoverState.ForeColor = System.Drawing.Color.White
        Me.navDashboard.Image = Global.WindowsApp1.My.Resources.Resources.market_analysis
        Me.navDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navDashboard.ImageSize = New System.Drawing.Size(22, 22)
        Me.navDashboard.Location = New System.Drawing.Point(16, 13)
        Me.navDashboard.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navDashboard.Name = "navDashboard"
        Me.navDashboard.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navDashboard.Size = New System.Drawing.Size(190, 42)
        Me.navDashboard.TabIndex = 0
        Me.navDashboard.Text = "   لوحة التحكم"
        Me.navDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navSales
        '
        Me.navSales.BorderRadius = 10
        Me.navSales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navSales.FillColor = System.Drawing.Color.Transparent
        Me.navSales.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navSales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navSales.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navSales.HoverState.ForeColor = System.Drawing.Color.White
        Me.navSales.Image = Global.WindowsApp1.My.Resources.Resources.cart__1_
        Me.navSales.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navSales.ImageSize = New System.Drawing.Size(22, 22)
        Me.navSales.Location = New System.Drawing.Point(16, 61)
        Me.navSales.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navSales.Name = "navSales"
        Me.navSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navSales.Size = New System.Drawing.Size(190, 42)
        Me.navSales.TabIndex = 1
        Me.navSales.Text = "   المبيعات والصالة"
        Me.navSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navSystem
        '
        Me.navSystem.BorderRadius = 10
        Me.navSystem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navSystem.FillColor = System.Drawing.Color.Transparent
        Me.navSystem.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navSystem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navSystem.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navSystem.HoverState.ForeColor = System.Drawing.Color.White
        Me.navSystem.Image = Global.WindowsApp1.My.Resources.Resources.category
        Me.navSystem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navSystem.ImageSize = New System.Drawing.Size(22, 22)
        Me.navSystem.Location = New System.Drawing.Point(16, 109)
        Me.navSystem.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navSystem.Name = "navSystem"
        Me.navSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navSystem.Size = New System.Drawing.Size(190, 42)
        Me.navSystem.TabIndex = 2
        Me.navSystem.Text = "   بيانات المنيو والنظام"
        Me.navSystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navInventory
        '
        Me.navInventory.BorderRadius = 10
        Me.navInventory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navInventory.FillColor = System.Drawing.Color.Transparent
        Me.navInventory.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navInventory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navInventory.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navInventory.HoverState.ForeColor = System.Drawing.Color.White
        Me.navInventory.Image = Global.WindowsApp1.My.Resources.Resources.stock
        Me.navInventory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navInventory.ImageSize = New System.Drawing.Size(22, 22)
        Me.navInventory.Location = New System.Drawing.Point(16, 157)
        Me.navInventory.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navInventory.Name = "navInventory"
        Me.navInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navInventory.Size = New System.Drawing.Size(190, 42)
        Me.navInventory.TabIndex = 3
        Me.navInventory.Text = "   المخازن والريسيبي"
        Me.navInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navPurchases
        '
        Me.navPurchases.BorderRadius = 10
        Me.navPurchases.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navPurchases.FillColor = System.Drawing.Color.Transparent
        Me.navPurchases.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navPurchases.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navPurchases.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navPurchases.HoverState.ForeColor = System.Drawing.Color.White
        Me.navPurchases.Image = Global.WindowsApp1.My.Resources.Resources.shopping
        Me.navPurchases.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navPurchases.ImageSize = New System.Drawing.Size(22, 22)
        Me.navPurchases.Location = New System.Drawing.Point(16, 205)
        Me.navPurchases.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navPurchases.Name = "navPurchases"
        Me.navPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navPurchases.Size = New System.Drawing.Size(190, 42)
        Me.navPurchases.TabIndex = 4
        Me.navPurchases.Text = "   المشتريات والتوريدات"
        Me.navPurchases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navCustomers
        '
        Me.navCustomers.BorderRadius = 10
        Me.navCustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navCustomers.FillColor = System.Drawing.Color.Transparent
        Me.navCustomers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navCustomers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navCustomers.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navCustomers.HoverState.ForeColor = System.Drawing.Color.White
        Me.navCustomers.Image = Global.WindowsApp1.My.Resources.Resources.client
        Me.navCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navCustomers.ImageSize = New System.Drawing.Size(22, 22)
        Me.navCustomers.Location = New System.Drawing.Point(16, 253)
        Me.navCustomers.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navCustomers.Name = "navCustomers"
        Me.navCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navCustomers.Size = New System.Drawing.Size(190, 42)
        Me.navCustomers.TabIndex = 5
        Me.navCustomers.Text = "   العملاء والحسابات"
        Me.navCustomers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navSuppliers
        '
        Me.navSuppliers.BorderRadius = 10
        Me.navSuppliers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navSuppliers.FillColor = System.Drawing.Color.Transparent
        Me.navSuppliers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navSuppliers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navSuppliers.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navSuppliers.HoverState.ForeColor = System.Drawing.Color.White
        Me.navSuppliers.Image = Global.WindowsApp1.My.Resources.Resources.supplier
        Me.navSuppliers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navSuppliers.ImageSize = New System.Drawing.Size(22, 22)
        Me.navSuppliers.Location = New System.Drawing.Point(16, 301)
        Me.navSuppliers.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navSuppliers.Name = "navSuppliers"
        Me.navSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navSuppliers.Size = New System.Drawing.Size(190, 42)
        Me.navSuppliers.TabIndex = 6
        Me.navSuppliers.Text = "   الموردين والشركات"
        Me.navSuppliers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navTreasury
        '
        Me.navTreasury.BorderRadius = 10
        Me.navTreasury.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navTreasury.FillColor = System.Drawing.Color.Transparent
        Me.navTreasury.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navTreasury.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navTreasury.HoverState.ForeColor = System.Drawing.Color.White
        Me.navTreasury.Image = Global.WindowsApp1.My.Resources.Resources.treasury
        Me.navTreasury.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navTreasury.ImageSize = New System.Drawing.Size(22, 22)
        Me.navTreasury.Location = New System.Drawing.Point(16, 349)
        Me.navTreasury.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navTreasury.Name = "navTreasury"
        Me.navTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navTreasury.Size = New System.Drawing.Size(190, 42)
        Me.navTreasury.TabIndex = 7
        Me.navTreasury.Text = "   الخزينة والسيولة"
        Me.navTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navExpenses
        '
        Me.navExpenses.BorderRadius = 10
        Me.navExpenses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navExpenses.FillColor = System.Drawing.Color.Transparent
        Me.navExpenses.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navExpenses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navExpenses.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navExpenses.HoverState.ForeColor = System.Drawing.Color.White
        Me.navExpenses.Image = Global.WindowsApp1.My.Resources.Resources.discount
        Me.navExpenses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navExpenses.ImageSize = New System.Drawing.Size(22, 22)
        Me.navExpenses.Location = New System.Drawing.Point(16, 397)
        Me.navExpenses.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navExpenses.Name = "navExpenses"
        Me.navExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navExpenses.Size = New System.Drawing.Size(190, 42)
        Me.navExpenses.TabIndex = 8
        Me.navExpenses.Text = "   المصروفات اليومية"
        Me.navExpenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navEmployees
        '
        Me.navEmployees.BorderRadius = 10
        Me.navEmployees.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navEmployees.FillColor = System.Drawing.Color.Transparent
        Me.navEmployees.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navEmployees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navEmployees.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navEmployees.HoverState.ForeColor = System.Drawing.Color.White
        Me.navEmployees.Image = Global.WindowsApp1.My.Resources.Resources.staff
        Me.navEmployees.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navEmployees.ImageSize = New System.Drawing.Size(22, 22)
        Me.navEmployees.Location = New System.Drawing.Point(16, 445)
        Me.navEmployees.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navEmployees.Name = "navEmployees"
        Me.navEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navEmployees.Size = New System.Drawing.Size(190, 42)
        Me.navEmployees.TabIndex = 9
        Me.navEmployees.Text = "   الموظفين والرواتب"
        Me.navEmployees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navUsers
        '
        Me.navUsers.BorderRadius = 10
        Me.navUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navUsers.FillColor = System.Drawing.Color.Transparent
        Me.navUsers.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navUsers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navUsers.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navUsers.HoverState.ForeColor = System.Drawing.Color.White
        Me.navUsers.Image = Global.WindowsApp1.My.Resources.Resources.lock
        Me.navUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navUsers.ImageSize = New System.Drawing.Size(22, 22)
        Me.navUsers.Location = New System.Drawing.Point(16, 493)
        Me.navUsers.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navUsers.Name = "navUsers"
        Me.navUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navUsers.Size = New System.Drawing.Size(190, 42)
        Me.navUsers.TabIndex = 10
        Me.navUsers.Text = "   المستخدمين والأمان"
        Me.navUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'navSettings
        '
        Me.navSettings.BorderRadius = 10
        Me.navSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.navSettings.FillColor = System.Drawing.Color.Transparent
        Me.navSettings.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.navSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.navSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.navSettings.HoverState.ForeColor = System.Drawing.Color.White
        Me.navSettings.Image = Global.WindowsApp1.My.Resources.Resources.settings__3_
        Me.navSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.navSettings.ImageSize = New System.Drawing.Size(22, 22)
        Me.navSettings.Location = New System.Drawing.Point(16, 541)
        Me.navSettings.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.navSettings.Name = "navSettings"
        Me.navSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.navSettings.Size = New System.Drawing.Size(190, 42)
        Me.navSettings.TabIndex = 11
        Me.navSettings.Text = "   الإعدادات والنسخ"
        Me.navSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'statusStripMain
        '
        Me.statusStripMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.statusStripMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.statusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusDb, Me.sepStatus1, Me.lblStatusUser, Me.sepStatus2, Me.lblStatusRole, Me.sepStatus3, Me.lblStatusBranch, Me.sepStatus4, Me.lblStatusShift, Me.sepStatus5, Me.lblStatusDateTime, Me.sepStatus6, Me.lblStatusVersion})
        Me.statusStripMain.Location = New System.Drawing.Point(0, 828)
        Me.statusStripMain.Name = "statusStripMain"
        Me.statusStripMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.statusStripMain.Size = New System.Drawing.Size(1400, 22)
        Me.statusStripMain.TabIndex = 2
        '
        'lblStatusDb
        '
        Me.lblStatusDb.Name = "lblStatusDb"
        Me.lblStatusDb.Size = New System.Drawing.Size(151, 17)
        Me.lblStatusDb.Text = "قاعدة البيانات: متصل ولحظي"
        '
        'sepStatus1
        '
        Me.sepStatus1.Name = "sepStatus1"
        Me.sepStatus1.Size = New System.Drawing.Size(16, 17)
        Me.sepStatus1.Text = " | "
        '
        'lblStatusUser
        '
        Me.lblStatusUser.Name = "lblStatusUser"
        Me.lblStatusUser.Size = New System.Drawing.Size(117, 17)
        Me.lblStatusUser.Text = "المستخدم: المدير العام"
        '
        'sepStatus2
        '
        Me.sepStatus2.Name = "sepStatus2"
        Me.sepStatus2.Size = New System.Drawing.Size(16, 17)
        Me.sepStatus2.Text = " | "
        '
        'lblStatusRole
        '
        Me.lblStatusRole.Name = "lblStatusRole"
        Me.lblStatusRole.Size = New System.Drawing.Size(105, 17)
        Me.lblStatusRole.Text = "الصلاحية: مدير نظام"
        '
        'sepStatus3
        '
        Me.sepStatus3.Name = "sepStatus3"
        Me.sepStatus3.Size = New System.Drawing.Size(16, 17)
        Me.sepStatus3.Text = " | "
        '
        'lblStatusBranch
        '
        Me.lblStatusBranch.Name = "lblStatusBranch"
        Me.lblStatusBranch.Size = New System.Drawing.Size(102, 17)
        Me.lblStatusBranch.Text = "الفرع: الفرع الرئيسي"
        '
        'sepStatus4
        '
        Me.sepStatus4.Name = "sepStatus4"
        Me.sepStatus4.Size = New System.Drawing.Size(16, 17)
        Me.sepStatus4.Text = " | "
        '
        'lblStatusShift
        '
        Me.lblStatusShift.Name = "lblStatusShift"
        Me.lblStatusShift.Size = New System.Drawing.Size(108, 17)
        Me.lblStatusShift.Text = "الوردية: وردية الصباح"
        '
        'sepStatus5
        '
        Me.sepStatus5.Name = "sepStatus5"
        Me.sepStatus5.Size = New System.Drawing.Size(16, 17)
        Me.sepStatus5.Text = " | "
        '
        'lblStatusDateTime
        '
        Me.lblStatusDateTime.Name = "lblStatusDateTime"
        Me.lblStatusDateTime.Size = New System.Drawing.Size(77, 17)
        Me.lblStatusDateTime.Text = "التاريخ والوقت"
        '
        'sepStatus6
        '
        Me.sepStatus6.Name = "sepStatus6"
        Me.sepStatus6.Size = New System.Drawing.Size(16, 17)
        Me.sepStatus6.Text = " | "
        '
        'lblStatusVersion
        '
        Me.lblStatusVersion.Name = "lblStatusVersion"
        Me.lblStatusVersion.Size = New System.Drawing.Size(103, 17)
        Me.lblStatusVersion.Text = "النسخة: v1.2.5 PRO"
        '
        'pnlMainContainer
        '
        Me.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainContainer.Location = New System.Drawing.Point(0, 70)
        Me.pnlMainContainer.Name = "pnlMainContainer"
        Me.pnlMainContainer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlMainContainer.Size = New System.Drawing.Size(1180, 758)
        Me.pnlMainContainer.TabIndex = 0
        '
        'tmrClock
        '
        Me.tmrClock.Interval = 1000
        '
        'tmrDashboardRefresh
        '
        Me.tmrDashboardRefresh.Interval = 180000
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1400, 850)
        Me.Controls.Add(Me.pnlMainContainer)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.statusStripMain)
        Me.Controls.Add(Me.panelHeader)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSidebar.ResumeLayout(False)
        Me.flpNav.ResumeLayout(False)
        Me.statusStripMain.ResumeLayout(False)
        Me.statusStripMain.PerformLayout()
        Me.pnlMainContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' Declarations
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents picLogo As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents lbltitle As System.Windows.Forms.Label
    Friend WithEvents lblProBadge As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtGlobalSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblHeaderBranch As System.Windows.Forms.Label
    Friend WithEvents lblStatusUserRole As System.Windows.Forms.Label
    Friend WithEvents btnSupport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2Button

    Friend WithEvents pnlSidebar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents flpNav As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents navDashboard As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navSales As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navSystem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navInventory As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navPurchases As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navCustomers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navSuppliers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navTreasury As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navExpenses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navEmployees As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navUsers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents navSettings As Guna.UI2.WinForms.Guna2Button

    Friend WithEvents statusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatusDb As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusRole As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusBranch As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusShift As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusDateTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sepStatus6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusVersion As System.Windows.Forms.ToolStripStatusLabel

    Friend WithEvents pnlMainContainer As System.Windows.Forms.Panel
    Friend WithEvents tmrClock As System.Windows.Forms.Timer
    Friend WithEvents tmrDashboardRefresh As System.Windows.Forms.Timer

End Class