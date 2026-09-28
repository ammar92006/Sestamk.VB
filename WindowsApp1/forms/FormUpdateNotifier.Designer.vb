<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUpdateNotifier
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
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(Me.components)
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.lblVersionBadge = New Guna.UI2.WinForms.Guna2Button()
        Me.lblSizeBadge = New Guna.UI2.WinForms.Guna2Button()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnHeaderIcon = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlContainer = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlFooter = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnLater = New Guna.UI2.WinForms.Guna2Button()
        Me.btnUpdate = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlProgress = New Guna.UI2.WinForms.Guna2Panel()
        Me.prgUpdate = New Guna.UI2.WinForms.Guna2ProgressBar()
        Me.lblProgressStatus = New System.Windows.Forms.Label()
        Me.pnlDeltaNotice = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblDeltaNotice = New System.Windows.Forms.Label()
        Me.cardNotes = New Guna.UI2.WinForms.Guna2Panel()
        Me.pnlNotesList = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblSizeInCard = New Guna.UI2.WinForms.Guna2Button()
        Me.lblNotesHeader = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContainer.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.pnlProgress.SuspendLayout()
        Me.pnlDeltaNotice.SuspendLayout()
        Me.cardNotes.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 18
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Guna2ShadowForm1
        '
        Me.Guna2ShadowForm1.BorderRadius = 18
        Me.Guna2ShadowForm1.TargetForm = Me
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2DragControl1.TargetControl = Me.pnlHeader
        Me.Guna2DragControl1.UseTransparentDrag = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.pnlHeader.BorderThickness = 1
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Controls.Add(Me.lblVersionBadge)
        Me.pnlHeader.Controls.Add(Me.lblSizeBadge)
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.btnHeaderIcon)
        Me.pnlHeader.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.pnlHeader.CustomBorderThickness = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.FillColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(580, 80)
        Me.pnlHeader.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BorderRadius = 6
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FillColor = System.Drawing.Color.Transparent
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnClose.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(12, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(32, 32)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "✕"
        '
        'lblVersionBadge
        '
        Me.lblVersionBadge.BorderRadius = 8
        Me.lblVersionBadge.DisabledState.BorderColor = System.Drawing.Color.Transparent
        Me.lblVersionBadge.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent
        Me.lblVersionBadge.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lblVersionBadge.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblVersionBadge.Enabled = False
        Me.lblVersionBadge.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lblVersionBadge.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblVersionBadge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblVersionBadge.Location = New System.Drawing.Point(52, 25)
        Me.lblVersionBadge.Name = "lblVersionBadge"
        Me.lblVersionBadge.Size = New System.Drawing.Size(84, 30)
        Me.lblVersionBadge.TabIndex = 3
        Me.lblVersionBadge.Text = "v--"
        '
        'lblSizeBadge
        '
        Me.lblSizeBadge.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblSizeBadge.BorderRadius = 8
        Me.lblSizeBadge.BorderThickness = 1
        Me.lblSizeBadge.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblSizeBadge.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent
        Me.lblSizeBadge.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblSizeBadge.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.lblSizeBadge.Enabled = False
        Me.lblSizeBadge.FillColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblSizeBadge.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSizeBadge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.lblSizeBadge.Location = New System.Drawing.Point(142, 25)
        Me.lblSizeBadge.Name = "lblSizeBadge"
        Me.lblSizeBadge.Size = New System.Drawing.Size(96, 30)
        Me.lblSizeBadge.TabIndex = 5
        Me.lblSizeBadge.Text = "📦 --"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(245, 42)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(265, 32)
        Me.lblSubtitle.TabIndex = 2
        Me.lblSubtitle.Text = "يتوفر إصدار أحدث يتضمن ميزات وتحديثات لقاعدة البيانات"
        Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(245, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(265, 26)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "تحديث جديد متوفر للنظام"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnHeaderIcon
        '
        Me.btnHeaderIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHeaderIcon.BorderRadius = 23
        Me.btnHeaderIcon.DisabledState.BorderColor = System.Drawing.Color.Transparent
        Me.btnHeaderIcon.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent
        Me.btnHeaderIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnHeaderIcon.DisabledState.ForeColor = System.Drawing.Color.White
        Me.btnHeaderIcon.Enabled = False
        Me.btnHeaderIcon.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnHeaderIcon.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnHeaderIcon.ForeColor = System.Drawing.Color.White
        Me.btnHeaderIcon.Location = New System.Drawing.Point(518, 17)
        Me.btnHeaderIcon.Name = "btnHeaderIcon"
        Me.btnHeaderIcon.Size = New System.Drawing.Size(46, 46)
        Me.btnHeaderIcon.TabIndex = 0
        Me.btnHeaderIcon.Text = "🚀"
        '
        'pnlContainer
        '
        Me.pnlContainer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.pnlContainer.BorderRadius = 18
        Me.pnlContainer.BorderThickness = 1
        Me.pnlContainer.Controls.Add(Me.pnlFooter)
        Me.pnlContainer.Controls.Add(Me.pnlProgress)
        Me.pnlContainer.Controls.Add(Me.pnlDeltaNotice)
        Me.pnlContainer.Controls.Add(Me.cardNotes)
        Me.pnlContainer.Controls.Add(Me.pnlHeader)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(580, 480)
        Me.pnlContainer.TabIndex = 0
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.Transparent
        Me.pnlFooter.Controls.Add(Me.btnLater)
        Me.pnlFooter.Controls.Add(Me.btnUpdate)
        Me.pnlFooter.Location = New System.Drawing.Point(20, 408)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(540, 56)
        Me.pnlFooter.TabIndex = 4
        '
        'btnLater
        '
        Me.btnLater.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLater.BorderRadius = 10
        Me.btnLater.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLater.FillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnLater.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLater.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.btnLater.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnLater.Location = New System.Drawing.Point(205, 6)
        Me.btnLater.Name = "btnLater"
        Me.btnLater.Size = New System.Drawing.Size(125, 44)
        Me.btnLater.TabIndex = 1
        Me.btnLater.Text = "تذكيري لاحقاً"
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.BorderRadius = 10
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnUpdate.Location = New System.Drawing.Point(340, 6)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(195, 44)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "⬇️ تحديث الآن"
        '
        'pnlProgress
        '
        Me.pnlProgress.BackColor = System.Drawing.Color.Transparent
        Me.pnlProgress.Controls.Add(Me.prgUpdate)
        Me.pnlProgress.Controls.Add(Me.lblProgressStatus)
        Me.pnlProgress.Location = New System.Drawing.Point(20, 360)
        Me.pnlProgress.Name = "pnlProgress"
        Me.pnlProgress.Size = New System.Drawing.Size(540, 42)
        Me.pnlProgress.TabIndex = 3
        Me.pnlProgress.Visible = False
        '
        'prgUpdate
        '
        Me.prgUpdate.BorderRadius = 5
        Me.prgUpdate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.prgUpdate.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.prgUpdate.Location = New System.Drawing.Point(0, 30)
        Me.prgUpdate.Name = "prgUpdate"
        Me.prgUpdate.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.prgUpdate.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.prgUpdate.Size = New System.Drawing.Size(540, 12)
        Me.prgUpdate.TabIndex = 1
        Me.prgUpdate.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        '
        'lblProgressStatus
        '
        Me.lblProgressStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProgressStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblProgressStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblProgressStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblProgressStatus.Name = "lblProgressStatus"
        Me.lblProgressStatus.Size = New System.Drawing.Size(540, 20)
        Me.lblProgressStatus.TabIndex = 0
        Me.lblProgressStatus.Text = "جارٍ تحميل حزمة التحديث... 0%"
        Me.lblProgressStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDeltaNotice
        '
        Me.pnlDeltaNotice.BackColor = System.Drawing.Color.Transparent
        Me.pnlDeltaNotice.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pnlDeltaNotice.BorderRadius = 8
        Me.pnlDeltaNotice.BorderThickness = 1
        Me.pnlDeltaNotice.Controls.Add(Me.lblDeltaNotice)
        Me.pnlDeltaNotice.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.pnlDeltaNotice.Location = New System.Drawing.Point(20, 318)
        Me.pnlDeltaNotice.Name = "pnlDeltaNotice"
        Me.pnlDeltaNotice.Size = New System.Drawing.Size(540, 36)
        Me.pnlDeltaNotice.TabIndex = 2
        '
        'lblDeltaNotice
        '
        Me.lblDeltaNotice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDeltaNotice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDeltaNotice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblDeltaNotice.Location = New System.Drawing.Point(0, 0)
        Me.lblDeltaNotice.Name = "lblDeltaNotice"
        Me.lblDeltaNotice.Size = New System.Drawing.Size(540, 36)
        Me.lblDeltaNotice.TabIndex = 0
        Me.lblDeltaNotice.Text = "⚡ تحديث ذكي وسريع: يتم تنزيل وتحديث الملفات الجديدة فقط دون الحاجة لإعادة التثبيت" &
    ""
        Me.lblDeltaNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cardNotes
        '
        Me.cardNotes.BackColor = System.Drawing.Color.Transparent
        Me.cardNotes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cardNotes.BorderRadius = 12
        Me.cardNotes.BorderThickness = 1
        Me.cardNotes.Controls.Add(Me.pnlNotesList)
        Me.cardNotes.Controls.Add(Me.txtNotes)
        Me.cardNotes.Controls.Add(Me.lblSizeInCard)
        Me.cardNotes.Controls.Add(Me.lblNotesHeader)
        Me.cardNotes.FillColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.cardNotes.Location = New System.Drawing.Point(20, 95)
        Me.cardNotes.Name = "cardNotes"
        Me.cardNotes.Size = New System.Drawing.Size(540, 215)
        Me.cardNotes.TabIndex = 1
        '
        'pnlNotesList
        '
        Me.pnlNotesList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlNotesList.AutoScroll = True
        Me.pnlNotesList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlNotesList.Location = New System.Drawing.Point(15, 42)
        Me.pnlNotesList.Name = "pnlNotesList"
        Me.pnlNotesList.Size = New System.Drawing.Size(510, 158)
        Me.pnlNotesList.TabIndex = 0
        Me.pnlNotesList.WrapContents = False
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.txtNotes.BorderRadius = 8
        Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotes.DefaultText = ""
        Me.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtNotes.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtNotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(15, 42)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.ReadOnly = True
        Me.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(510, 158)
        Me.txtNotes.TabIndex = 1
        Me.txtNotes.Visible = False
        '
        'lblSizeInCard
        '
        Me.lblSizeInCard.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblSizeInCard.BorderRadius = 6
        Me.lblSizeInCard.BorderThickness = 1
        Me.lblSizeInCard.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblSizeInCard.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent
        Me.lblSizeInCard.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblSizeInCard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.lblSizeInCard.Enabled = False
        Me.lblSizeInCard.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblSizeInCard.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSizeInCard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.lblSizeInCard.Location = New System.Drawing.Point(15, 10)
        Me.lblSizeInCard.Name = "lblSizeInCard"
        Me.lblSizeInCard.Size = New System.Drawing.Size(165, 26)
        Me.lblSizeInCard.TabIndex = 2
        Me.lblSizeInCard.Text = "📦 الحجم: --"
        '
        'lblNotesHeader
        '
        Me.lblNotesHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotesHeader.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblNotesHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblNotesHeader.Location = New System.Drawing.Point(185, 11)
        Me.lblNotesHeader.Name = "lblNotesHeader"
        Me.lblNotesHeader.Size = New System.Drawing.Size(340, 24)
        Me.lblNotesHeader.TabIndex = 0
        Me.lblNotesHeader.Text = "أبرز التحسينات والإضافات في هذا الإصدار:"
        Me.lblNotesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormUpdateNotifier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(580, 480)
        Me.Controls.Add(Me.pnlContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUpdateNotifier"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تحديث سيستمك"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlProgress.ResumeLayout(False)
        Me.pnlDeltaNotice.ResumeLayout(False)
        Me.cardNotes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents pnlContainer As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnHeaderIcon As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents lblVersionBadge As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblSizeBadge As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cardNotes As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblNotesHeader As System.Windows.Forms.Label
    Friend WithEvents lblSizeInCard As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlNotesList As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pnlDeltaNotice As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblDeltaNotice As System.Windows.Forms.Label
    Friend WithEvents pnlProgress As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblProgressStatus As System.Windows.Forms.Label
    Friend WithEvents prgUpdate As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents pnlFooter As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnUpdate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLater As Guna.UI2.WinForms.Guna2Button
End Class
