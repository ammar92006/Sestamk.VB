<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Backup
    Inherits BaseForm

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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.pnlTopBar = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTopTitle = New System.Windows.Forms.Label()
        Me.btnWinClose = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btnWinMax = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btnWinMin = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.pnlContainer = New Guna.UI2.WinForms.Guna2Panel()
        Me.cardTable = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgv_backup = New System.Windows.Forms.DataGridView()
        Me.lblTableTitle = New System.Windows.Forms.Label()
        Me.cardActions = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblActionsTitle = New System.Windows.Forms.Label()
        Me.btn_Backup = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Restore = New Guna.UI2.WinForms.Guna2Button()
        Me.btnOpenFolder = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.progressBackup = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.cardStats = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblStatsTitle = New System.Windows.Forms.Label()
        Me.lblLastBackupTitle = New System.Windows.Forms.Label()
        Me.lblLastBackup = New System.Windows.Forms.Label()
        Me.lblBackupCountTitle = New System.Windows.Forms.Label()
        Me.lblBackupCount = New System.Windows.Forms.Label()
        Me.lblDbSizeTitle = New System.Windows.Forms.Label()
        Me.lblDbSize = New System.Windows.Forms.Label()
        Me.pnlBottomBar = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblFooter = New System.Windows.Forms.Label()
        Me.pnlTopBar.SuspendLayout()
        Me.pnlContainer.SuspendLayout()
        Me.cardTable.SuspendLayout()
        CType(Me.dgv_backup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardActions.SuspendLayout()
        Me.cardStats.SuspendLayout()
        Me.pnlBottomBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 15
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'pnlTopBar
        '
        Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.pnlTopBar.Controls.Add(Me.lblTopTitle)
        Me.pnlTopBar.Controls.Add(Me.btnWinClose)
        Me.pnlTopBar.Controls.Add(Me.btnWinMax)
        Me.pnlTopBar.Controls.Add(Me.btnWinMin)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(1300, 50)
        Me.pnlTopBar.TabIndex = 0
        '
        'lblTopTitle
        '
        Me.lblTopTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTopTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTopTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.lblTopTitle.Location = New System.Drawing.Point(490, 7)
        Me.lblTopTitle.Name = "lblTopTitle"
        Me.lblTopTitle.Size = New System.Drawing.Size(330, 35)
        Me.lblTopTitle.TabIndex = 0
        Me.lblTopTitle.Text = "النسخ الاحتياطي"
        Me.lblTopTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnWinClose
        '
        Me.btnWinClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWinClose.BorderRadius = 4
        Me.btnWinClose.FillColor = System.Drawing.Color.Transparent
        Me.btnWinClose.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnWinClose.HoverState.IconColor = System.Drawing.Color.White
        Me.btnWinClose.IconColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnWinClose.Location = New System.Drawing.Point(10, 8)
        Me.btnWinClose.Name = "btnWinClose"
        Me.btnWinClose.Size = New System.Drawing.Size(40, 34)
        Me.btnWinClose.TabIndex = 3
        '
        'btnWinMax
        '
        Me.btnWinMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWinMax.BorderRadius = 4
        Me.btnWinMax.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox
        Me.btnWinMax.FillColor = System.Drawing.Color.Transparent
        Me.btnWinMax.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnWinMax.HoverState.IconColor = System.Drawing.Color.White
        Me.btnWinMax.IconColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnWinMax.Location = New System.Drawing.Point(54, 8)
        Me.btnWinMax.Name = "btnWinMax"
        Me.btnWinMax.Size = New System.Drawing.Size(40, 34)
        Me.btnWinMax.TabIndex = 2
        '
        'btnWinMin
        '
        Me.btnWinMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWinMin.BorderRadius = 4
        Me.btnWinMin.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btnWinMin.FillColor = System.Drawing.Color.Transparent
        Me.btnWinMin.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnWinMin.HoverState.IconColor = System.Drawing.Color.White
        Me.btnWinMin.IconColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnWinMin.Location = New System.Drawing.Point(98, 8)
        Me.btnWinMin.Name = "btnWinMin"
        Me.btnWinMin.Size = New System.Drawing.Size(40, 34)
        Me.btnWinMin.TabIndex = 1
        '
        'pnlContainer
        '
        Me.pnlContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.pnlContainer.Controls.Add(Me.cardTable)
        Me.pnlContainer.Controls.Add(Me.cardActions)
        Me.pnlContainer.Controls.Add(Me.cardStats)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 50)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Padding = New System.Windows.Forms.Padding(18)
        Me.pnlContainer.Size = New System.Drawing.Size(1300, 705)
        Me.pnlContainer.TabIndex = 1
        '
        'cardTable
        '
        Me.cardTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cardTable.BackColor = System.Drawing.Color.Transparent
        Me.cardTable.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardTable.BorderRadius = 12
        Me.cardTable.BorderThickness = 1
        Me.cardTable.Controls.Add(Me.dgv_backup)
        Me.cardTable.Controls.Add(Me.lblTableTitle)
        Me.cardTable.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cardTable.Location = New System.Drawing.Point(18, 205)
        Me.cardTable.Name = "cardTable"
        Me.cardTable.Padding = New System.Windows.Forms.Padding(16)
        Me.cardTable.Size = New System.Drawing.Size(1264, 482)
        Me.cardTable.TabIndex = 2
        '
        'dgv_backup
        '
        Me.dgv_backup.AllowUserToAddRows = False
        Me.dgv_backup.AllowUserToDeleteRows = False
        Me.dgv_backup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_backup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_backup.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgv_backup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_backup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv_backup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Padding = New System.Windows.Forms.Padding(4)
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_backup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgv_backup.ColumnHeadersHeight = 42
        Me.dgv_backup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_backup.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgv_backup.EnableHeadersVisualStyles = False
        Me.dgv_backup.GridColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.dgv_backup.Location = New System.Drawing.Point(16, 52)
        Me.dgv_backup.Name = "dgv_backup"
        Me.dgv_backup.ReadOnly = True
        Me.dgv_backup.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv_backup.RowHeadersVisible = False
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White
        Me.dgv_backup.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dgv_backup.RowTemplate.Height = 38
        Me.dgv_backup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_backup.Size = New System.Drawing.Size(1232, 414)
        Me.dgv_backup.TabIndex = 1
        '
        'lblTableTitle
        '
        Me.lblTableTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTableTitle.AutoSize = True
        Me.lblTableTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.lblTableTitle.Location = New System.Drawing.Point(1054, 15)
        Me.lblTableTitle.Name = "lblTableTitle"
        Me.lblTableTitle.Size = New System.Drawing.Size(177, 25)
        Me.lblTableTitle.TabIndex = 0
        Me.lblTableTitle.Text = "سجل النسخ الاحتياطية"
        '
        'cardActions
        '
        Me.cardActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cardActions.BackColor = System.Drawing.Color.Transparent
        Me.cardActions.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardActions.BorderRadius = 12
        Me.cardActions.BorderThickness = 1
        Me.cardActions.Controls.Add(Me.lblActionsTitle)
        Me.cardActions.Controls.Add(Me.btn_Backup)
        Me.cardActions.Controls.Add(Me.btn_Restore)
        Me.cardActions.Controls.Add(Me.btnOpenFolder)
        Me.cardActions.Controls.Add(Me.btnDelete)
        Me.cardActions.Controls.Add(Me.lblStatus)
        Me.cardActions.Controls.Add(Me.progressBackup)
        Me.cardActions.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cardActions.Location = New System.Drawing.Point(490, 18)
        Me.cardActions.Name = "cardActions"
        Me.cardActions.Size = New System.Drawing.Size(792, 175)
        Me.cardActions.TabIndex = 1
        '
        'lblActionsTitle
        '
        Me.lblActionsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActionsTitle.AutoSize = True
        Me.lblActionsTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblActionsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblActionsTitle.Location = New System.Drawing.Point(630, 14)
        Me.lblActionsTitle.Name = "lblActionsTitle"
        Me.lblActionsTitle.Size = New System.Drawing.Size(150, 21)
        Me.lblActionsTitle.TabIndex = 0
        Me.lblActionsTitle.Text = "إجراءات التحكم السريع"
        '
        'btn_Backup
        '
        Me.btn_Backup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Backup.BorderRadius = 8
        Me.btn_Backup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Backup.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btn_Backup.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.btn_Backup.ForeColor = System.Drawing.Color.White
        Me.btn_Backup.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btn_Backup.Location = New System.Drawing.Point(542, 48)
        Me.btn_Backup.Name = "btn_Backup"
        Me.btn_Backup.Size = New System.Drawing.Size(234, 52)
        Me.btn_Backup.TabIndex = 1
        Me.btn_Backup.Text = "أخذ نسخة احتياطية"
        '
        'btn_Restore
        '
        Me.btn_Restore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Restore.BorderRadius = 8
        Me.btn_Restore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Restore.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btn_Restore.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.btn_Restore.ForeColor = System.Drawing.Color.White
        Me.btn_Restore.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btn_Restore.Location = New System.Drawing.Point(292, 48)
        Me.btn_Restore.Name = "btn_Restore"
        Me.btn_Restore.Size = New System.Drawing.Size(234, 52)
        Me.btn_Restore.TabIndex = 2
        Me.btn_Restore.Text = "استعادة النسخة المحددة"
        '
        'btnOpenFolder
        '
        Me.btnOpenFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenFolder.BorderRadius = 8
        Me.btnOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenFolder.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnOpenFolder.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnOpenFolder.ForeColor = System.Drawing.Color.White
        Me.btnOpenFolder.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.btnOpenFolder.Location = New System.Drawing.Point(152, 48)
        Me.btnOpenFolder.Name = "btnOpenFolder"
        Me.btnOpenFolder.Size = New System.Drawing.Size(124, 52)
        Me.btnOpenFolder.TabIndex = 3
        Me.btnOpenFolder.Text = "فتح المجلد"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BorderRadius = 8
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FillColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnDelete.Location = New System.Drawing.Point(16, 48)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 52)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "حذف النسخة"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(16, 115)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(760, 24)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "جاهز للعمل..."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'progressBackup
        '
        Me.progressBackup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressBackup.BorderRadius = 3
        Me.progressBackup.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.progressBackup.Location = New System.Drawing.Point(16, 148)
        Me.progressBackup.Name = "progressBackup"
        Me.progressBackup.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.progressBackup.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.progressBackup.Size = New System.Drawing.Size(760, 8)
        Me.progressBackup.TabIndex = 6
        Me.progressBackup.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.progressBackup.Visible = False
        '
        'cardStats
        '
        Me.cardStats.BackColor = System.Drawing.Color.Transparent
        Me.cardStats.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardStats.BorderRadius = 12
        Me.cardStats.BorderThickness = 1
        Me.cardStats.Controls.Add(Me.lblStatsTitle)
        Me.cardStats.Controls.Add(Me.lblLastBackupTitle)
        Me.cardStats.Controls.Add(Me.lblLastBackup)
        Me.cardStats.Controls.Add(Me.lblBackupCountTitle)
        Me.cardStats.Controls.Add(Me.lblBackupCount)
        Me.cardStats.Controls.Add(Me.lblDbSizeTitle)
        Me.cardStats.Controls.Add(Me.lblDbSize)
        Me.cardStats.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cardStats.Location = New System.Drawing.Point(18, 18)
        Me.cardStats.Name = "cardStats"
        Me.cardStats.Size = New System.Drawing.Size(456, 175)
        Me.cardStats.TabIndex = 0
        '
        'lblStatsTitle
        '
        Me.lblStatsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatsTitle.AutoSize = True
        Me.lblStatsTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblStatsTitle.Location = New System.Drawing.Point(308, 14)
        Me.lblStatsTitle.Name = "lblStatsTitle"
        Me.lblStatsTitle.Size = New System.Drawing.Size(136, 21)
        Me.lblStatsTitle.TabIndex = 0
        Me.lblStatsTitle.Text = "بيانات النظام الحالية"
        '
        'lblLastBackupTitle
        '
        Me.lblLastBackupTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastBackupTitle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.lblLastBackupTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.lblLastBackupTitle.Location = New System.Drawing.Point(260, 48)
        Me.lblLastBackupTitle.Name = "lblLastBackupTitle"
        Me.lblLastBackupTitle.Size = New System.Drawing.Size(180, 24)
        Me.lblLastBackupTitle.TabIndex = 1
        Me.lblLastBackupTitle.Text = "آخر عملية نسخ:"
        Me.lblLastBackupTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastBackup
        '
        Me.lblLastBackup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastBackup.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastBackup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.lblLastBackup.Location = New System.Drawing.Point(16, 48)
        Me.lblLastBackup.Name = "lblLastBackup"
        Me.lblLastBackup.Size = New System.Drawing.Size(238, 24)
        Me.lblLastBackup.TabIndex = 2
        Me.lblLastBackup.Text = "غير متوفر"
        Me.lblLastBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBackupCountTitle
        '
        Me.lblBackupCountTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBackupCountTitle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.lblBackupCountTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.lblBackupCountTitle.Location = New System.Drawing.Point(260, 84)
        Me.lblBackupCountTitle.Name = "lblBackupCountTitle"
        Me.lblBackupCountTitle.Size = New System.Drawing.Size(180, 24)
        Me.lblBackupCountTitle.TabIndex = 3
        Me.lblBackupCountTitle.Text = "عدد النسخ المتوفرة:"
        Me.lblBackupCountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBackupCount
        '
        Me.lblBackupCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBackupCount.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBackupCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.lblBackupCount.Location = New System.Drawing.Point(16, 84)
        Me.lblBackupCount.Name = "lblBackupCount"
        Me.lblBackupCount.Size = New System.Drawing.Size(238, 24)
        Me.lblBackupCount.TabIndex = 4
        Me.lblBackupCount.Text = "0"
        Me.lblBackupCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDbSizeTitle
        '
        Me.lblDbSizeTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDbSizeTitle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.lblDbSizeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.lblDbSizeTitle.Location = New System.Drawing.Point(260, 120)
        Me.lblDbSizeTitle.Name = "lblDbSizeTitle"
        Me.lblDbSizeTitle.Size = New System.Drawing.Size(180, 24)
        Me.lblDbSizeTitle.TabIndex = 5
        Me.lblDbSizeTitle.Text = "حجم قاعدة البيانات:"
        Me.lblDbSizeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDbSize
        '
        Me.lblDbSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDbSize.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDbSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.lblDbSize.Location = New System.Drawing.Point(16, 120)
        Me.lblDbSize.Name = "lblDbSize"
        Me.lblDbSize.Size = New System.Drawing.Size(238, 24)
        Me.lblDbSize.TabIndex = 6
        Me.lblDbSize.Text = "0.00 MB"
        Me.lblDbSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlBottomBar
        '
        Me.pnlBottomBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.pnlBottomBar.Controls.Add(Me.lblFooter)
        Me.pnlBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottomBar.Location = New System.Drawing.Point(0, 755)
        Me.pnlBottomBar.Name = "pnlBottomBar"
        Me.pnlBottomBar.Size = New System.Drawing.Size(1300, 45)
        Me.pnlBottomBar.TabIndex = 2
        '
        'lblFooter
        '
        Me.lblFooter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFooter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblFooter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.lblFooter.Location = New System.Drawing.Point(100, 10)
        Me.lblFooter.Name = "lblFooter"
        Me.lblFooter.Size = New System.Drawing.Size(1100, 25)
        Me.lblFooter.TabIndex = 0
        Me.lblFooter.Text = "نظام سستمك لإدارة المبيعات والمخازن — مركز إدارة قواعد البيانات والنسخ الاحتياطي"
        Me.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Backup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1300, 800)
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.pnlBottomBar)
        Me.Controls.Add(Me.pnlTopBar)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Backup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "النسخ الاحتياطي"
        Me.pnlTopBar.ResumeLayout(False)
        Me.pnlContainer.ResumeLayout(False)
        Me.cardTable.ResumeLayout(False)
        Me.cardTable.PerformLayout()
        CType(Me.dgv_backup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardActions.ResumeLayout(False)
        Me.cardActions.PerformLayout()
        Me.cardStats.ResumeLayout(False)
        Me.cardStats.PerformLayout()
        Me.pnlBottomBar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents pnlTopBar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTopTitle As System.Windows.Forms.Label
    Friend WithEvents btnWinClose As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btnWinMax As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btnWinMin As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents pnlContainer As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents cardStats As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblStatsTitle As System.Windows.Forms.Label
    Friend WithEvents lblLastBackupTitle As System.Windows.Forms.Label
    Friend WithEvents lblLastBackup As System.Windows.Forms.Label
    Friend WithEvents lblBackupCountTitle As System.Windows.Forms.Label
    Friend WithEvents lblBackupCount As System.Windows.Forms.Label
    Friend WithEvents lblDbSizeTitle As System.Windows.Forms.Label
    Friend WithEvents lblDbSize As System.Windows.Forms.Label
    Friend WithEvents cardActions As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblActionsTitle As System.Windows.Forms.Label
    Friend WithEvents btn_Backup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Restore As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnOpenFolder As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents progressBackup As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents cardTable As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTableTitle As System.Windows.Forms.Label
    Friend WithEvents dgv_backup As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBottomBar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblFooter As System.Windows.Forms.Label
End Class
