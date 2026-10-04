<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectTable
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
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.btnCloseHeader = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMaximizeHeader = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlKPIs = New Guna.UI2.WinForms.Guna2Panel()
        Me.tlpKPIs = New System.Windows.Forms.TableLayoutPanel()
        Me.cardTotal = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTotalVal = New System.Windows.Forms.Label()
        Me.lblTotalTitle = New System.Windows.Forms.Label()
        Me.cardOccupancy = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblOccupancyVal = New System.Windows.Forms.Label()
        Me.lblOccupancyTitle = New System.Windows.Forms.Label()
        Me.cardActiveTab = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblActiveTabVal = New System.Windows.Forms.Label()
        Me.lblActiveTabTitle = New System.Windows.Forms.Label()
        Me.cardFree = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblFreeVal = New System.Windows.Forms.Label()
        Me.lblFreeTitle = New System.Windows.Forms.Label()
        Me.cardOccupied = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblOccupiedVal = New System.Windows.Forms.Label()
        Me.lblOccupiedTitle = New System.Windows.Forms.Label()
        Me.cardReserved = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblReservedVal = New System.Windows.Forms.Label()
        Me.lblReservedTitle = New System.Windows.Forms.Label()
        Me.pnlControls = New Guna.UI2.WinForms.Guna2Panel()
        Me.flpSections = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlSearchFilter = New Guna.UI2.WinForms.Guna2Panel()
        Me.txtSearchTable = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnFilterAll = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFilterFree = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFilterOccupied = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFilterReserved = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlContent = New Guna.UI2.WinForms.Guna2Panel()
        Me.flpTables = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelBottom = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnCancel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefreshManual = New Guna.UI2.WinForms.Guna2Button()
        Me.lblFooterInfo = New System.Windows.Forms.Label()
        Me.tmrLive = New System.Windows.Forms.Timer(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.pnlKPIs.SuspendLayout()
        Me.tlpKPIs.SuspendLayout()
        Me.cardTotal.SuspendLayout()
        Me.cardOccupancy.SuspendLayout()
        Me.cardActiveTab.SuspendLayout()
        Me.cardFree.SuspendLayout()
        Me.cardOccupied.SuspendLayout()
        Me.cardReserved.SuspendLayout()
        Me.pnlControls.SuspendLayout()
        Me.pnlSearchFilter.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.panelBottom.SuspendLayout()
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
        Me.panelHeader.Controls.Add(Me.btnMaximizeHeader)
        Me.panelHeader.Controls.Add(Me.lblSubtitle)
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.panelHeader.Size = New System.Drawing.Size(1120, 68)
        Me.panelHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(820, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(280, 28)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "🍽️ خريطة وإدارة طاولات الصالة"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.BackColor = System.Drawing.Color.Transparent
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(740, 40)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(360, 15)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "متابعة إشغال الصالة، الحسابات المفتوحة، وتسكين الحجوزات لحظياً"
        Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCloseHeader
        '
        Me.btnCloseHeader.BorderRadius = 8
        Me.btnCloseHeader.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCloseHeader.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnCloseHeader.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCloseHeader.ForeColor = System.Drawing.Color.White
        Me.btnCloseHeader.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnCloseHeader.Location = New System.Drawing.Point(16, 14)
        Me.btnCloseHeader.Name = "btnCloseHeader"
        Me.btnCloseHeader.Size = New System.Drawing.Size(42, 40)
        Me.btnCloseHeader.TabIndex = 3
        Me.btnCloseHeader.Text = "✕"
        '
        'btnMaximizeHeader
        '
        Me.btnMaximizeHeader.BorderRadius = 8
        Me.btnMaximizeHeader.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMaximizeHeader.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnMaximizeHeader.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnMaximizeHeader.ForeColor = System.Drawing.Color.White
        Me.btnMaximizeHeader.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnMaximizeHeader.Location = New System.Drawing.Point(64, 14)
        Me.btnMaximizeHeader.Name = "btnMaximizeHeader"
        Me.btnMaximizeHeader.Size = New System.Drawing.Size(42, 40)
        Me.btnMaximizeHeader.TabIndex = 2
        Me.btnMaximizeHeader.Text = "🗖"
        '
        'pnlKPIs
        '
        Me.pnlKPIs.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlKPIs.Controls.Add(Me.tlpKPIs)
        Me.pnlKPIs.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlKPIs.Location = New System.Drawing.Point(0, 68)
        Me.pnlKPIs.Name = "pnlKPIs"
        Me.pnlKPIs.Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
        Me.pnlKPIs.Size = New System.Drawing.Size(1120, 84)
        Me.pnlKPIs.TabIndex = 1
        '
        'tlpKPIs
        '
        Me.tlpKPIs.ColumnCount = 6
        Me.tlpKPIs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpKPIs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpKPIs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpKPIs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.33333!))
        Me.tlpKPIs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.33333!))
        Me.tlpKPIs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpKPIs.Controls.Add(Me.cardTotal, 0, 0)
        Me.tlpKPIs.Controls.Add(Me.cardOccupancy, 1, 0)
        Me.tlpKPIs.Controls.Add(Me.cardActiveTab, 2, 0)
        Me.tlpKPIs.Controls.Add(Me.cardFree, 3, 0)
        Me.tlpKPIs.Controls.Add(Me.cardOccupied, 4, 0)
        Me.tlpKPIs.Controls.Add(Me.cardReserved, 5, 0)
        Me.tlpKPIs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpKPIs.Location = New System.Drawing.Point(16, 8)
        Me.tlpKPIs.Name = "tlpKPIs"
        Me.tlpKPIs.RowCount = 1
        Me.tlpKPIs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpKPIs.Size = New System.Drawing.Size(1088, 68)
        Me.tlpKPIs.TabIndex = 0
        '
        'cardTotal
        '
        Me.cardTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.cardTotal.BorderRadius = 10
        Me.cardTotal.BorderThickness = 1
        Me.cardTotal.Controls.Add(Me.lblTotalVal)
        Me.cardTotal.Controls.Add(Me.lblTotalTitle)
        Me.cardTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardTotal.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardTotal.Location = New System.Drawing.Point(911, 3)
        Me.cardTotal.Name = "cardTotal"
        Me.cardTotal.Padding = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.cardTotal.Size = New System.Drawing.Size(174, 62)
        Me.cardTotal.TabIndex = 0
        '
        'lblTotalTitle
        '
        Me.lblTotalTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTotalTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblTotalTitle.Location = New System.Drawing.Point(8, 6)
        Me.lblTotalTitle.Name = "lblTotalTitle"
        Me.lblTotalTitle.Size = New System.Drawing.Size(158, 18)
        Me.lblTotalTitle.TabIndex = 0
        Me.lblTotalTitle.Text = "📊 طاولات الصالة"
        Me.lblTotalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalVal
        '
        Me.lblTotalVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalVal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalVal.ForeColor = System.Drawing.Color.White
        Me.lblTotalVal.Location = New System.Drawing.Point(8, 24)
        Me.lblTotalVal.Name = "lblTotalVal"
        Me.lblTotalVal.Size = New System.Drawing.Size(158, 32)
        Me.lblTotalVal.TabIndex = 1
        Me.lblTotalVal.Text = "0 طاولة"
        Me.lblTotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cardOccupancy
        '
        Me.cardOccupancy.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.cardOccupancy.BorderRadius = 10
        Me.cardOccupancy.BorderThickness = 1
        Me.cardOccupancy.Controls.Add(Me.lblOccupancyVal)
        Me.cardOccupancy.Controls.Add(Me.lblOccupancyTitle)
        Me.cardOccupancy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardOccupancy.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardOccupancy.Location = New System.Drawing.Point(730, 3)
        Me.cardOccupancy.Name = "cardOccupancy"
        Me.cardOccupancy.Padding = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.cardOccupancy.Size = New System.Drawing.Size(175, 62)
        Me.cardOccupancy.TabIndex = 1
        '
        'lblOccupancyTitle
        '
        Me.lblOccupancyTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblOccupancyTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblOccupancyTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblOccupancyTitle.Location = New System.Drawing.Point(8, 6)
        Me.lblOccupancyTitle.Name = "lblOccupancyTitle"
        Me.lblOccupancyTitle.Size = New System.Drawing.Size(159, 18)
        Me.lblOccupancyTitle.TabIndex = 0
        Me.lblOccupancyTitle.Text = "📈 نسبة الإشغال"
        Me.lblOccupancyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOccupancyVal
        '
        Me.lblOccupancyVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOccupancyVal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblOccupancyVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.lblOccupancyVal.Location = New System.Drawing.Point(8, 24)
        Me.lblOccupancyVal.Name = "lblOccupancyVal"
        Me.lblOccupancyVal.Size = New System.Drawing.Size(159, 32)
        Me.lblOccupancyVal.TabIndex = 1
        Me.lblOccupancyVal.Text = "0%"
        Me.lblOccupancyVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cardActiveTab
        '
        Me.cardActiveTab.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.cardActiveTab.BorderRadius = 10
        Me.cardActiveTab.BorderThickness = 1
        Me.cardActiveTab.Controls.Add(Me.lblActiveTabVal)
        Me.cardActiveTab.Controls.Add(Me.lblActiveTabTitle)
        Me.cardActiveTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardActiveTab.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardActiveTab.Location = New System.Drawing.Point(513, 3)
        Me.cardActiveTab.Name = "cardActiveTab"
        Me.cardActiveTab.Padding = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.cardActiveTab.Size = New System.Drawing.Size(211, 62)
        Me.cardActiveTab.TabIndex = 2
        '
        'lblActiveTabTitle
        '
        Me.lblActiveTabTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblActiveTabTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblActiveTabTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblActiveTabTitle.Location = New System.Drawing.Point(8, 6)
        Me.lblActiveTabTitle.Name = "lblActiveTabTitle"
        Me.lblActiveTabTitle.Size = New System.Drawing.Size(195, 18)
        Me.lblActiveTabTitle.TabIndex = 0
        Me.lblActiveTabTitle.Text = "💰 مبيعات الصالة الجارية"
        Me.lblActiveTabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblActiveTabVal
        '
        Me.lblActiveTabVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblActiveTabVal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblActiveTabVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.lblActiveTabVal.Location = New System.Drawing.Point(8, 24)
        Me.lblActiveTabVal.Name = "lblActiveTabVal"
        Me.lblActiveTabVal.Size = New System.Drawing.Size(195, 32)
        Me.lblActiveTabVal.TabIndex = 1
        Me.lblActiveTabVal.Text = "0.00 ج.م"
        Me.lblActiveTabVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cardFree
        '
        Me.cardFree.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.cardFree.BorderRadius = 10
        Me.cardFree.BorderThickness = 1
        Me.cardFree.Controls.Add(Me.lblFreeVal)
        Me.cardFree.Controls.Add(Me.lblFreeTitle)
        Me.cardFree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardFree.FillColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.cardFree.Location = New System.Drawing.Point(347, 3)
        Me.cardFree.Name = "cardFree"
        Me.cardFree.Padding = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.cardFree.Size = New System.Drawing.Size(160, 62)
        Me.cardFree.TabIndex = 3
        '
        'lblFreeTitle
        '
        Me.lblFreeTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFreeTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblFreeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.lblFreeTitle.Location = New System.Drawing.Point(8, 6)
        Me.lblFreeTitle.Name = "lblFreeTitle"
        Me.lblFreeTitle.Size = New System.Drawing.Size(144, 18)
        Me.lblFreeTitle.TabIndex = 0
        Me.lblFreeTitle.Text = "🟢 متاحة"
        Me.lblFreeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFreeVal
        '
        Me.lblFreeVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFreeVal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblFreeVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.lblFreeVal.Location = New System.Drawing.Point(8, 24)
        Me.lblFreeVal.Name = "lblFreeVal"
        Me.lblFreeVal.Size = New System.Drawing.Size(144, 32)
        Me.lblFreeVal.TabIndex = 1
        Me.lblFreeVal.Text = "0"
        Me.lblFreeVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cardOccupied
        '
        Me.cardOccupied.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cardOccupied.BorderRadius = 10
        Me.cardOccupied.BorderThickness = 1
        Me.cardOccupied.Controls.Add(Me.lblOccupiedVal)
        Me.cardOccupied.Controls.Add(Me.lblOccupiedTitle)
        Me.cardOccupied.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardOccupied.FillColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.cardOccupied.Location = New System.Drawing.Point(181, 3)
        Me.cardOccupied.Name = "cardOccupied"
        Me.cardOccupied.Padding = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.cardOccupied.Size = New System.Drawing.Size(160, 62)
        Me.cardOccupied.TabIndex = 4
        '
        'lblOccupiedTitle
        '
        Me.lblOccupiedTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblOccupiedTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblOccupiedTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.lblOccupiedTitle.Location = New System.Drawing.Point(8, 6)
        Me.lblOccupiedTitle.Name = "lblOccupiedTitle"
        Me.lblOccupiedTitle.Size = New System.Drawing.Size(144, 18)
        Me.lblOccupiedTitle.TabIndex = 0
        Me.lblOccupiedTitle.Text = "🔴 مشغولة"
        Me.lblOccupiedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOccupiedVal
        '
        Me.lblOccupiedVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOccupiedVal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblOccupiedVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblOccupiedVal.Location = New System.Drawing.Point(8, 24)
        Me.lblOccupiedVal.Name = "lblOccupiedVal"
        Me.lblOccupiedVal.Size = New System.Drawing.Size(144, 32)
        Me.lblOccupiedVal.TabIndex = 1
        Me.lblOccupiedVal.Text = "0"
        Me.lblOccupiedVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cardReserved
        '
        Me.cardReserved.BorderColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.cardReserved.BorderRadius = 10
        Me.cardReserved.BorderThickness = 1
        Me.cardReserved.Controls.Add(Me.lblReservedVal)
        Me.cardReserved.Controls.Add(Me.lblReservedTitle)
        Me.cardReserved.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardReserved.FillColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.cardReserved.Location = New System.Drawing.Point(3, 3)
        Me.cardReserved.Name = "cardReserved"
        Me.cardReserved.Padding = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.cardReserved.Size = New System.Drawing.Size(172, 62)
        Me.cardReserved.TabIndex = 5
        '
        'lblReservedTitle
        '
        Me.lblReservedTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblReservedTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblReservedTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lblReservedTitle.Location = New System.Drawing.Point(8, 6)
        Me.lblReservedTitle.Name = "lblReservedTitle"
        Me.lblReservedTitle.Size = New System.Drawing.Size(156, 18)
        Me.lblReservedTitle.TabIndex = 0
        Me.lblReservedTitle.Text = "🟡 محجوزة"
        Me.lblReservedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReservedVal
        '
        Me.lblReservedVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblReservedVal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblReservedVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.lblReservedVal.Location = New System.Drawing.Point(8, 24)
        Me.lblReservedVal.Name = "lblReservedVal"
        Me.lblReservedVal.Size = New System.Drawing.Size(156, 32)
        Me.lblReservedVal.TabIndex = 1
        Me.lblReservedVal.Text = "0"
        Me.lblReservedVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlControls
        '
        Me.pnlControls.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.pnlControls.Controls.Add(Me.flpSections)
        Me.pnlControls.Controls.Add(Me.pnlSearchFilter)
        Me.pnlControls.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlControls.Location = New System.Drawing.Point(0, 152)
        Me.pnlControls.Name = "pnlControls"
        Me.pnlControls.Padding = New System.Windows.Forms.Padding(16, 6, 16, 6)
        Me.pnlControls.Size = New System.Drawing.Size(1120, 105)
        Me.pnlControls.TabIndex = 2
        '
        'pnlSearchFilter
        '
        Me.pnlSearchFilter.Controls.Add(Me.btnFilterReserved)
        Me.pnlSearchFilter.Controls.Add(Me.btnFilterOccupied)
        Me.pnlSearchFilter.Controls.Add(Me.btnFilterFree)
        Me.pnlSearchFilter.Controls.Add(Me.btnFilterAll)
        Me.pnlSearchFilter.Controls.Add(Me.txtSearchTable)
        Me.pnlSearchFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearchFilter.Location = New System.Drawing.Point(16, 6)
        Me.pnlSearchFilter.Name = "pnlSearchFilter"
        Me.pnlSearchFilter.Size = New System.Drawing.Size(1088, 44)
        Me.pnlSearchFilter.TabIndex = 0
        '
        'txtSearchTable
        '
        Me.txtSearchTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchTable.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.txtSearchTable.BorderRadius = 8
        Me.txtSearchTable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearchTable.DefaultText = ""
        Me.txtSearchTable.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtSearchTable.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearchTable.ForeColor = System.Drawing.Color.White
        Me.txtSearchTable.Location = New System.Drawing.Point(748, 4)
        Me.txtSearchTable.Name = "txtSearchTable"
        Me.txtSearchTable.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.txtSearchTable.PlaceholderText = "🔍 ابحث برقم أو اسم الطاولة..."
        Me.txtSearchTable.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSearchTable.Size = New System.Drawing.Size(340, 36)
        Me.txtSearchTable.TabIndex = 0
        '
        'btnFilterAll
        '
        Me.btnFilterAll.BorderRadius = 8
        Me.btnFilterAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFilterAll.FillColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnFilterAll.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFilterAll.ForeColor = System.Drawing.Color.White
        Me.btnFilterAll.Location = New System.Drawing.Point(310, 4)
        Me.btnFilterAll.Name = "btnFilterAll"
        Me.btnFilterAll.Size = New System.Drawing.Size(95, 36)
        Me.btnFilterAll.TabIndex = 1
        Me.btnFilterAll.Text = "الكل"
        '
        'btnFilterFree
        '
        Me.btnFilterFree.BorderRadius = 8
        Me.btnFilterFree.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFilterFree.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnFilterFree.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFilterFree.ForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.btnFilterFree.Location = New System.Drawing.Point(205, 4)
        Me.btnFilterFree.Name = "btnFilterFree"
        Me.btnFilterFree.Size = New System.Drawing.Size(100, 36)
        Me.btnFilterFree.TabIndex = 2
        Me.btnFilterFree.Text = "🟢 المتاحة"
        '
        'btnFilterOccupied
        '
        Me.btnFilterOccupied.BorderRadius = 8
        Me.btnFilterOccupied.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFilterOccupied.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnFilterOccupied.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFilterOccupied.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.btnFilterOccupied.Location = New System.Drawing.Point(95, 4)
        Me.btnFilterOccupied.Name = "btnFilterOccupied"
        Me.btnFilterOccupied.Size = New System.Drawing.Size(105, 36)
        Me.btnFilterOccupied.TabIndex = 3
        Me.btnFilterOccupied.Text = "🔴 المشغولة"
        '
        'btnFilterReserved
        '
        Me.btnFilterReserved.BorderRadius = 8
        Me.btnFilterReserved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFilterReserved.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnFilterReserved.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnFilterReserved.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.btnFilterReserved.Location = New System.Drawing.Point(0, 4)
        Me.btnFilterReserved.Name = "btnFilterReserved"
        Me.btnFilterReserved.Size = New System.Drawing.Size(90, 36)
        Me.btnFilterReserved.TabIndex = 4
        Me.btnFilterReserved.Text = "🟡 المحجوزة"
        '
        'flpSections
        '
        Me.flpSections.AutoScroll = True
        Me.flpSections.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpSections.Location = New System.Drawing.Point(16, 50)
        Me.flpSections.Name = "flpSections"
        Me.flpSections.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        Me.flpSections.Size = New System.Drawing.Size(1088, 49)
        Me.flpSections.TabIndex = 1
        Me.flpSections.WrapContents = False
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.flpTables)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 257)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(16, 12, 16, 12)
        Me.pnlContent.Size = New System.Drawing.Size(1120, 413)
        Me.pnlContent.TabIndex = 3
        '
        'flpTables
        '
        Me.flpTables.AutoScroll = True
        Me.flpTables.BackColor = System.Drawing.Color.Transparent
        Me.flpTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpTables.Location = New System.Drawing.Point(16, 12)
        Me.flpTables.Name = "flpTables"
        Me.flpTables.Padding = New System.Windows.Forms.Padding(6)
        Me.flpTables.Size = New System.Drawing.Size(1088, 389)
        Me.flpTables.TabIndex = 0
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.panelBottom.Controls.Add(Me.lblFooterInfo)
        Me.panelBottom.Controls.Add(Me.btnRefreshManual)
        Me.panelBottom.Controls.Add(Me.btnCancel)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(0, 670)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.panelBottom.Size = New System.Drawing.Size(1120, 62)
        Me.panelBottom.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.BorderRadius = 8
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnCancel.Location = New System.Drawing.Point(16, 11)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(140, 40)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "إلغاء وإغلاق"
        '
        'btnRefreshManual
        '
        Me.btnRefreshManual.BorderRadius = 8
        Me.btnRefreshManual.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefreshManual.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnRefreshManual.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshManual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnRefreshManual.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.btnRefreshManual.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnRefreshManual.Location = New System.Drawing.Point(164, 11)
        Me.btnRefreshManual.Name = "btnRefreshManual"
        Me.btnRefreshManual.Size = New System.Drawing.Size(130, 40)
        Me.btnRefreshManual.TabIndex = 1
        Me.btnRefreshManual.Text = "🔄 تحديث فوري"
        '
        'lblFooterInfo
        '
        Me.lblFooterInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFooterInfo.AutoSize = True
        Me.lblFooterInfo.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.lblFooterInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblFooterInfo.Location = New System.Drawing.Point(520, 22)
        Me.lblFooterInfo.Name = "lblFooterInfo"
        Me.lblFooterInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblFooterInfo.Size = New System.Drawing.Size(580, 17)
        Me.lblFooterInfo.TabIndex = 2
        Me.lblFooterInfo.Text = "💡 اضغط على أي طاولة مشغولة لفتح حسابها، أو طاولة متاحة لبدء طلب جديد، أو محجوزة لتسكينها فوراً."
        '
        'tmrLive
        '
        Me.tmrLive.Interval = 10000
        '
        'FrmSelectTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1120, 732)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlControls)
        Me.Controls.Add(Me.pnlKPIs)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSelectTable"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.pnlKPIs.ResumeLayout(False)
        Me.tlpKPIs.ResumeLayout(False)
        Me.cardTotal.ResumeLayout(False)
        Me.cardOccupancy.ResumeLayout(False)
        Me.cardActiveTab.ResumeLayout(False)
        Me.cardFree.ResumeLayout(False)
        Me.cardOccupied.ResumeLayout(False)
        Me.cardReserved.ResumeLayout(False)
        Me.pnlControls.ResumeLayout(False)
        Me.pnlSearchFilter.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.panelBottom.ResumeLayout(False)
        Me.panelBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnCloseHeader As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMaximizeHeader As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlKPIs As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents tlpKPIs As TableLayoutPanel
    Friend WithEvents cardTotal As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTotalTitle As Label
    Friend WithEvents lblTotalVal As Label
    Friend WithEvents cardOccupancy As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblOccupancyTitle As Label
    Friend WithEvents lblOccupancyVal As Label
    Friend WithEvents cardActiveTab As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblActiveTabTitle As Label
    Friend WithEvents lblActiveTabVal As Label
    Friend WithEvents cardFree As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblFreeTitle As Label
    Friend WithEvents lblFreeVal As Label
    Friend WithEvents cardOccupied As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblOccupiedTitle As Label
    Friend WithEvents lblOccupiedVal As Label
    Friend WithEvents cardReserved As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblReservedTitle As Label
    Friend WithEvents lblReservedVal As Label
    Friend WithEvents pnlControls As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlSearchFilter As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtSearchTable As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnFilterAll As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFilterFree As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFilterOccupied As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFilterReserved As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpSections As FlowLayoutPanel
    Friend WithEvents pnlContent As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents flpTables As FlowLayoutPanel
    Friend WithEvents panelBottom As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRefreshManual As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblFooterInfo As Label
    Friend WithEvents tmrLive As Timer

End Class
