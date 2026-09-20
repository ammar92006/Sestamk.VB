Namespace Global.WindowsApp1
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmKitchenDisplay
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
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.pnlHeaderCenter = New System.Windows.Forms.Panel()
        Me.lblClock = New System.Windows.Forms.Label()
        Me.pnlHeaderRight = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblDelayedBadge = New System.Windows.Forms.Label()
        Me.lblActiveCountBadge = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlHeaderLeft = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnCloseForm = New System.Windows.Forms.Button()
        Me.btnFullscreen = New System.Windows.Forms.Button()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnSoundToggle = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlFilterContainer = New System.Windows.Forms.Panel()
        Me.pnlLegend = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblLegNormal = New System.Windows.Forms.Label()
        Me.lblLegWarning = New System.Windows.Forms.Label()
        Me.lblLegDelayed = New System.Windows.Forms.Label()
        Me.pnlFilters = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbStation = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblFilterStation = New System.Windows.Forms.Label()
        Me.cmbOrderType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblFilterType = New System.Windows.Forms.Label()
        Me.flowOrders = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblEmptyNotice = New System.Windows.Forms.Label()
        Me.tmrSeconds = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.pnlHeaderCenter.SuspendLayout()
        Me.pnlHeaderRight.SuspendLayout()
        Me.pnlHeaderLeft.SuspendLayout()
        Me.pnlFilterContainer.SuspendLayout()
        Me.pnlLegend.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.pnlHeaderCenter)
        Me.panelHeader.Controls.Add(Me.pnlHeaderRight)
        Me.panelHeader.Controls.Add(Me.pnlHeaderLeft)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1200, 62)
        Me.panelHeader.TabIndex = 0
        '
        'pnlHeaderCenter
        '
        Me.pnlHeaderCenter.Controls.Add(Me.lblClock)
        Me.pnlHeaderCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeaderCenter.Location = New System.Drawing.Point(495, 0)
        Me.pnlHeaderCenter.Name = "pnlHeaderCenter"
        Me.pnlHeaderCenter.Size = New System.Drawing.Size(255, 62)
        Me.pnlHeaderCenter.TabIndex = 2
        '
        'lblClock
        '
        Me.lblClock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClock.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblClock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblClock.Location = New System.Drawing.Point(0, 0)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(255, 62)
        Me.lblClock.TabIndex = 0
        Me.lblClock.Text = "00:00:00"
        Me.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlHeaderRight
        '
        Me.pnlHeaderRight.AutoSize = True
        Me.pnlHeaderRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlHeaderRight.Controls.Add(Me.lblDelayedBadge)
        Me.pnlHeaderRight.Controls.Add(Me.lblActiveCountBadge)
        Me.pnlHeaderRight.Controls.Add(Me.lblTitle)
        Me.pnlHeaderRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeaderRight.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
        Me.pnlHeaderRight.Location = New System.Drawing.Point(750, 0)
        Me.pnlHeaderRight.Name = "pnlHeaderRight"
        Me.pnlHeaderRight.Padding = New System.Windows.Forms.Padding(12, 13, 15, 13)
        Me.pnlHeaderRight.Size = New System.Drawing.Size(450, 62)
        Me.pnlHeaderRight.TabIndex = 1
        Me.pnlHeaderRight.WrapContents = False
        '
        'lblDelayedBadge
        '
        Me.lblDelayedBadge.AutoSize = True
        Me.lblDelayedBadge.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lblDelayedBadge.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblDelayedBadge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblDelayedBadge.Location = New System.Drawing.Point(3, 14)
        Me.lblDelayedBadge.Margin = New System.Windows.Forms.Padding(3, 1, 8, 0)
        Me.lblDelayedBadge.Name = "lblDelayedBadge"
        Me.lblDelayedBadge.Padding = New System.Windows.Forms.Padding(8, 5, 8, 5)
        Me.lblDelayedBadge.Size = New System.Drawing.Size(76, 27)
        Me.lblDelayedBadge.TabIndex = 2
        Me.lblDelayedBadge.Text = "0 متأخرة"
        Me.lblDelayedBadge.Visible = False
        '
        'lblActiveCountBadge
        '
        Me.lblActiveCountBadge.AutoSize = True
        Me.lblActiveCountBadge.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblActiveCountBadge.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblActiveCountBadge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.lblActiveCountBadge.Location = New System.Drawing.Point(90, 14)
        Me.lblActiveCountBadge.Margin = New System.Windows.Forms.Padding(3, 1, 10, 0)
        Me.lblActiveCountBadge.Name = "lblActiveCountBadge"
        Me.lblActiveCountBadge.Padding = New System.Windows.Forms.Padding(8, 5, 8, 5)
        Me.lblActiveCountBadge.Size = New System.Drawing.Size(107, 27)
        Me.lblActiveCountBadge.TabIndex = 1
        Me.lblActiveCountBadge.Text = "0 طلبات نشطة"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 13.5!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(210, 13)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(176, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "شاشة المطبخ (KDS)"
        '
        'pnlHeaderLeft
        '
        Me.pnlHeaderLeft.AutoSize = True
        Me.pnlHeaderLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlHeaderLeft.Controls.Add(Me.btnCloseForm)
        Me.pnlHeaderLeft.Controls.Add(Me.btnFullscreen)
        Me.pnlHeaderLeft.Controls.Add(Me.btnHistory)
        Me.pnlHeaderLeft.Controls.Add(Me.btnSoundToggle)
        Me.pnlHeaderLeft.Controls.Add(Me.btnRefresh)
        Me.pnlHeaderLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlHeaderLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderLeft.Name = "pnlHeaderLeft"
        Me.pnlHeaderLeft.Padding = New System.Windows.Forms.Padding(12, 13, 12, 13)
        Me.pnlHeaderLeft.Size = New System.Drawing.Size(495, 62)
        Me.pnlHeaderLeft.TabIndex = 0
        Me.pnlHeaderLeft.WrapContents = False
        '
        'btnCloseForm
        '
        Me.btnCloseForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.btnCloseForm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCloseForm.FlatAppearance.BorderSize = 0
        Me.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseForm.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCloseForm.ForeColor = System.Drawing.Color.White
        Me.btnCloseForm.Location = New System.Drawing.Point(3, 16)
        Me.btnCloseForm.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.btnCloseForm.Name = "btnCloseForm"
        Me.btnCloseForm.Size = New System.Drawing.Size(75, 34)
        Me.btnCloseForm.TabIndex = 0
        Me.btnCloseForm.Text = "✕ خروج"
        Me.btnCloseForm.UseVisualStyleBackColor = False
        '
        'btnFullscreen
        '
        Me.btnFullscreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnFullscreen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFullscreen.FlatAppearance.BorderSize = 0
        Me.btnFullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFullscreen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnFullscreen.ForeColor = System.Drawing.Color.White
        Me.btnFullscreen.Location = New System.Drawing.Point(86, 16)
        Me.btnFullscreen.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.btnFullscreen.Name = "btnFullscreen"
        Me.btnFullscreen.Size = New System.Drawing.Size(85, 34)
        Me.btnFullscreen.TabIndex = 1
        Me.btnFullscreen.Text = "⛶ تكبير"
        Me.btnFullscreen.UseVisualStyleBackColor = False
        '
        'btnHistory
        '
        Me.btnHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHistory.FlatAppearance.BorderSize = 0
        Me.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnHistory.ForeColor = System.Drawing.Color.White
        Me.btnHistory.Location = New System.Drawing.Point(179, 16)
        Me.btnHistory.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(102, 34)
        Me.btnHistory.TabIndex = 2
        Me.btnHistory.Text = "الأرشيف (Recall)"
        Me.btnHistory.UseVisualStyleBackColor = False
        '
        'btnSoundToggle
        '
        Me.btnSoundToggle.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnSoundToggle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSoundToggle.FlatAppearance.BorderSize = 0
        Me.btnSoundToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSoundToggle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSoundToggle.ForeColor = System.Drawing.Color.White
        Me.btnSoundToggle.Location = New System.Drawing.Point(289, 16)
        Me.btnSoundToggle.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.btnSoundToggle.Name = "btnSoundToggle"
        Me.btnSoundToggle.Size = New System.Drawing.Size(95, 34)
        Me.btnSoundToggle.TabIndex = 3
        Me.btnSoundToggle.Text = "🔔 الصوت"
        Me.btnSoundToggle.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(392, 16)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(78, 34)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "🔄 تحديث"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'pnlFilterContainer
        '
        Me.pnlFilterContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.pnlFilterContainer.Controls.Add(Me.pnlLegend)
        Me.pnlFilterContainer.Controls.Add(Me.pnlFilters)
        Me.pnlFilterContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilterContainer.Location = New System.Drawing.Point(0, 62)
        Me.pnlFilterContainer.Name = "pnlFilterContainer"
        Me.pnlFilterContainer.Padding = New System.Windows.Forms.Padding(12, 6, 12, 6)
        Me.pnlFilterContainer.Size = New System.Drawing.Size(1200, 48)
        Me.pnlFilterContainer.TabIndex = 1
        '
        'pnlLegend
        '
        Me.pnlLegend.AutoSize = True
        Me.pnlLegend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlLegend.Controls.Add(Me.lblLegNormal)
        Me.pnlLegend.Controls.Add(Me.lblLegWarning)
        Me.pnlLegend.Controls.Add(Me.lblLegDelayed)
        Me.pnlLegend.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLegend.Location = New System.Drawing.Point(12, 6)
        Me.pnlLegend.Name = "pnlLegend"
        Me.pnlLegend.Size = New System.Drawing.Size(262, 36)
        Me.pnlLegend.TabIndex = 1
        Me.pnlLegend.WrapContents = False
        '
        'lblLegNormal
        '
        Me.lblLegNormal.AutoSize = True
        Me.lblLegNormal.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblLegNormal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.lblLegNormal.Location = New System.Drawing.Point(3, 8)
        Me.lblLegNormal.Margin = New System.Windows.Forms.Padding(3, 8, 8, 0)
        Me.lblLegNormal.Name = "lblLegNormal"
        Me.lblLegNormal.Size = New System.Drawing.Size(78, 15)
        Me.lblLegNormal.TabIndex = 0
        Me.lblLegNormal.Text = "🟢 عادي < 5د"
        '
        'lblLegWarning
        '
        Me.lblLegWarning.AutoSize = True
        Me.lblLegWarning.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblLegWarning.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.lblLegWarning.Location = New System.Drawing.Point(92, 8)
        Me.lblLegWarning.Margin = New System.Windows.Forms.Padding(3, 8, 8, 0)
        Me.lblLegWarning.Name = "lblLegWarning"
        Me.lblLegWarning.Size = New System.Drawing.Size(78, 15)
        Me.lblLegWarning.TabIndex = 1
        Me.lblLegWarning.Text = "🟠 انتظار 5-12د"
        '
        'lblLegDelayed
        '
        Me.lblLegDelayed.AutoSize = True
        Me.lblLegDelayed.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblLegDelayed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblLegDelayed.Location = New System.Drawing.Point(181, 8)
        Me.lblLegDelayed.Margin = New System.Windows.Forms.Padding(3, 8, 8, 0)
        Me.lblLegDelayed.Name = "lblLegDelayed"
        Me.lblLegDelayed.Size = New System.Drawing.Size(78, 15)
        Me.lblLegDelayed.TabIndex = 2
        Me.lblLegDelayed.Text = "🔴 متأخر > 12د"
        '
        'pnlFilters
        '
        Me.pnlFilters.AutoSize = True
        Me.pnlFilters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFilters.Controls.Add(Me.cmbStation)
        Me.pnlFilters.Controls.Add(Me.lblFilterStation)
        Me.pnlFilters.Controls.Add(Me.cmbOrderType)
        Me.pnlFilters.Controls.Add(Me.lblFilterType)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlFilters.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
        Me.pnlFilters.Location = New System.Drawing.Point(674, 6)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(514, 36)
        Me.pnlFilters.TabIndex = 0
        Me.pnlFilters.WrapContents = False
        '
        'cmbStation
        '
        Me.cmbStation.BackColor = System.Drawing.Color.Transparent
        Me.cmbStation.BorderColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.cmbStation.BorderRadius = 5
        Me.cmbStation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStation.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.cmbStation.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbStation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbStation.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbStation.ForeColor = System.Drawing.Color.White
        Me.cmbStation.ItemHeight = 26
        Me.cmbStation.Items.AddRange(New Object() {"الكل", "مطبخ", "شواية", "بيتزا", "مشروبات"})
        Me.cmbStation.Location = New System.Drawing.Point(3, 2)
        Me.cmbStation.Margin = New System.Windows.Forms.Padding(3, 2, 8, 0)
        Me.cmbStation.Name = "cmbStation"
        Me.cmbStation.Size = New System.Drawing.Size(145, 32)
        Me.cmbStation.StartIndex = 0
        Me.cmbStation.TabIndex = 3
        '
        'lblFilterStation
        '
        Me.lblFilterStation.AutoSize = True
        Me.lblFilterStation.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFilterStation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblFilterStation.Location = New System.Drawing.Point(159, 8)
        Me.lblFilterStation.Margin = New System.Windows.Forms.Padding(3, 8, 14, 0)
        Me.lblFilterStation.Name = "lblFilterStation"
        Me.lblFilterStation.Size = New System.Drawing.Size(96, 17)
        Me.lblFilterStation.TabIndex = 2
        Me.lblFilterStation.Text = "المحطة / القسم:"
        '
        'cmbOrderType
        '
        Me.cmbOrderType.BackColor = System.Drawing.Color.Transparent
        Me.cmbOrderType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.cmbOrderType.BorderRadius = 5
        Me.cmbOrderType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrderType.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.cmbOrderType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbOrderType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.cmbOrderType.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbOrderType.ForeColor = System.Drawing.Color.White
        Me.cmbOrderType.ItemHeight = 26
        Me.cmbOrderType.Items.AddRange(New Object() {"الكل", "صالة", "تيك أوي", "دليفري"})
        Me.cmbOrderType.Location = New System.Drawing.Point(272, 2)
        Me.cmbOrderType.Margin = New System.Windows.Forms.Padding(3, 2, 8, 0)
        Me.cmbOrderType.Name = "cmbOrderType"
        Me.cmbOrderType.Size = New System.Drawing.Size(130, 32)
        Me.cmbOrderType.StartIndex = 0
        Me.cmbOrderType.TabIndex = 1
        '
        'lblFilterType
        '
        Me.lblFilterType.AutoSize = True
        Me.lblFilterType.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFilterType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblFilterType.Location = New System.Drawing.Point(413, 8)
        Me.lblFilterType.Margin = New System.Windows.Forms.Padding(3, 8, 0, 0)
        Me.lblFilterType.Name = "lblFilterType"
        Me.lblFilterType.Size = New System.Drawing.Size(66, 17)
        Me.lblFilterType.TabIndex = 0
        Me.lblFilterType.Text = "نوع الطلب:"
        '
        'flowOrders
        '
        Me.flowOrders.AutoScroll = True
        Me.flowOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.flowOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowOrders.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowOrders.Location = New System.Drawing.Point(0, 110)
        Me.flowOrders.Name = "flowOrders"
        Me.flowOrders.Padding = New System.Windows.Forms.Padding(12)
        Me.flowOrders.Size = New System.Drawing.Size(1200, 640)
        Me.flowOrders.TabIndex = 2
        '
        'lblEmptyNotice
        '
        Me.lblEmptyNotice.BackColor = System.Drawing.Color.Transparent
        Me.lblEmptyNotice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEmptyNotice.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmptyNotice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblEmptyNotice.Location = New System.Drawing.Point(0, 110)
        Me.lblEmptyNotice.Name = "lblEmptyNotice"
        Me.lblEmptyNotice.Size = New System.Drawing.Size(1200, 640)
        Me.lblEmptyNotice.TabIndex = 3
        Me.lblEmptyNotice.Text = "لا توجد طلبات نشطة في المطبخ حالياً" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "سيتم عرض الطلبات الجديدة تلقائياً فور تسجيلها من الكاشير"
        Me.lblEmptyNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEmptyNotice.Visible = False
        '
        'tmrSeconds
        '
        Me.tmrSeconds.Interval = 1000
        '
        'tmrPoll
        '
        Me.tmrPoll.Interval = 3500
        '
        'FrmKitchenDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 750)
        Me.Controls.Add(Me.lblEmptyNotice)
        Me.Controls.Add(Me.flowOrders)
        Me.Controls.Add(Me.pnlFilterContainer)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(950, 600)
        Me.Name = "FrmKitchenDisplay"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "شاشة المطبخ (KDS)"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.pnlHeaderCenter.ResumeLayout(False)
        Me.pnlHeaderRight.ResumeLayout(False)
        Me.pnlHeaderRight.PerformLayout()
        Me.pnlHeaderLeft.ResumeLayout(False)
        Me.pnlFilterContainer.ResumeLayout(False)
        Me.pnlFilterContainer.PerformLayout()
        Me.pnlLegend.ResumeLayout(False)
        Me.pnlLegend.PerformLayout()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderCenter As System.Windows.Forms.Panel
    Friend WithEvents lblClock As System.Windows.Forms.Label
    Friend WithEvents pnlHeaderRight As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblDelayedBadge As System.Windows.Forms.Label
    Friend WithEvents lblActiveCountBadge As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlHeaderLeft As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCloseForm As System.Windows.Forms.Button
    Friend WithEvents btnFullscreen As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents btnSoundToggle As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents pnlFilterContainer As System.Windows.Forms.Panel
    Friend WithEvents pnlLegend As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblLegNormal As System.Windows.Forms.Label
    Friend WithEvents lblLegWarning As System.Windows.Forms.Label
    Friend WithEvents lblLegDelayed As System.Windows.Forms.Label
    Friend WithEvents pnlFilters As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbStation As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblFilterStation As System.Windows.Forms.Label
    Friend WithEvents cmbOrderType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblFilterType As System.Windows.Forms.Label
    Friend WithEvents flowOrders As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblEmptyNotice As System.Windows.Forms.Label
    Friend WithEvents tmrSeconds As System.Windows.Forms.Timer
    Friend WithEvents tmrPoll As System.Windows.Forms.Timer
End Class
End Namespace
