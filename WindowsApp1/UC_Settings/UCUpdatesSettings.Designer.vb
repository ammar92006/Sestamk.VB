Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCUpdatesSettings
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
            Me.cardStatus = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardStatusTitle = New System.Windows.Forms.Label()
            Me.lblCurrentVersionHeader = New System.Windows.Forms.Label()
            Me.lblCurrentVersion = New System.Windows.Forms.Label()
            Me.lblChannelHeader = New System.Windows.Forms.Label()
            Me.lblChannel = New System.Windows.Forms.Label()
            Me.lblLatestVersionHeader = New System.Windows.Forms.Label()
            Me.lblLatestVersion = New System.Windows.Forms.Label()
            Me.lblLatestDateHeader = New System.Windows.Forms.Label()
            Me.lblLatestUpdateDate = New System.Windows.Forms.Label()
            Me.lblAutoUpdate = New System.Windows.Forms.Label()
            Me.tglAutoUpdate = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.btnCheckForUpdates = New Guna.UI2.WinForms.Guna2Button()
            Me.cardHistory = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardHistoryTitle = New System.Windows.Forms.Label()
            Me.flpUpdateHistory = New Guna.UI2.WinForms.Guna2Panel()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardStatus.SuspendLayout()
            Me.cardHistory.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardStatus)
            Me.pnlMain.Controls.Add(Me.cardHistory)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 900)
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
            Me.lblTitle.Text = "التحديثات والترقية"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(700, 58)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(508, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "التحقق من التحديثات وإدارة الترقية وسجل الإصدارات"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardStatus
            '
            Me.cardStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardStatus.BackColor = System.Drawing.Color.Transparent
            Me.cardStatus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardStatus.BorderRadius = 14
            Me.cardStatus.BorderThickness = 1
            Me.cardStatus.Controls.Add(Me.lblCardStatusTitle)
            Me.cardStatus.Controls.Add(Me.lblCurrentVersionHeader)
            Me.cardStatus.Controls.Add(Me.lblCurrentVersion)
            Me.cardStatus.Controls.Add(Me.lblChannelHeader)
            Me.cardStatus.Controls.Add(Me.lblChannel)
            Me.cardStatus.Controls.Add(Me.lblLatestVersionHeader)
            Me.cardStatus.Controls.Add(Me.lblLatestVersion)
            Me.cardStatus.Controls.Add(Me.lblLatestDateHeader)
            Me.cardStatus.Controls.Add(Me.lblLatestUpdateDate)
            Me.cardStatus.Controls.Add(Me.lblAutoUpdate)
            Me.cardStatus.Controls.Add(Me.tglAutoUpdate)
            Me.cardStatus.Controls.Add(Me.btnCheckForUpdates)
            Me.cardStatus.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardStatus.Location = New System.Drawing.Point(30, 95)
            Me.cardStatus.Name = "cardStatus"
            Me.cardStatus.Size = New System.Drawing.Size(1178, 195)
            Me.cardStatus.TabIndex = 2
            '
            'lblCardStatusTitle
            '
            Me.lblCardStatusTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardStatusTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardStatusTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardStatusTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardStatusTitle.Name = "lblCardStatusTitle"
            Me.lblCardStatusTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardStatusTitle.TabIndex = 0
            Me.lblCardStatusTitle.Text = "معلومات الإصدار والقناة"
            Me.lblCardStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrentVersionHeader
            '
            Me.lblCurrentVersionHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrentVersionHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCurrentVersionHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblCurrentVersionHeader.Location = New System.Drawing.Point(1000, 55)
            Me.lblCurrentVersionHeader.Name = "lblCurrentVersionHeader"
            Me.lblCurrentVersionHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblCurrentVersionHeader.TabIndex = 1
            Me.lblCurrentVersionHeader.Text = "الإصدار الحالي:"
            Me.lblCurrentVersionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrentVersion
            '
            Me.lblCurrentVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrentVersion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblCurrentVersion.ForeColor = System.Drawing.Color.White
            Me.lblCurrentVersion.Location = New System.Drawing.Point(820, 55)
            Me.lblCurrentVersion.Name = "lblCurrentVersion"
            Me.lblCurrentVersion.Size = New System.Drawing.Size(170, 25)
            Me.lblCurrentVersion.TabIndex = 2
            Me.lblCurrentVersion.Text = "1.0.0.0"
            Me.lblCurrentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblChannelHeader
            '
            Me.lblChannelHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblChannelHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblChannelHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblChannelHeader.Location = New System.Drawing.Point(620, 55)
            Me.lblChannelHeader.Name = "lblChannelHeader"
            Me.lblChannelHeader.Size = New System.Drawing.Size(140, 25)
            Me.lblChannelHeader.TabIndex = 3
            Me.lblChannelHeader.Text = "قناة التحديث:"
            Me.lblChannelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblChannel
            '
            Me.lblChannel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblChannel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblChannel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(248, Byte), Integer))
            Me.lblChannel.Location = New System.Drawing.Point(460, 55)
            Me.lblChannel.Name = "lblChannel"
            Me.lblChannel.Size = New System.Drawing.Size(150, 25)
            Me.lblChannel.TabIndex = 4
            Me.lblChannel.Text = "PUBLIC"
            Me.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLatestVersionHeader
            '
            Me.lblLatestVersionHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblLatestVersionHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblLatestVersionHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblLatestVersionHeader.Location = New System.Drawing.Point(1000, 95)
            Me.lblLatestVersionHeader.Name = "lblLatestVersionHeader"
            Me.lblLatestVersionHeader.Size = New System.Drawing.Size(150, 25)
            Me.lblLatestVersionHeader.TabIndex = 5
            Me.lblLatestVersionHeader.Text = "أحدث إصدار متاح:"
            Me.lblLatestVersionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLatestVersion
            '
            Me.lblLatestVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblLatestVersion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblLatestVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.lblLatestVersion.Location = New System.Drawing.Point(820, 95)
            Me.lblLatestVersion.Name = "lblLatestVersion"
            Me.lblLatestVersion.Size = New System.Drawing.Size(170, 25)
            Me.lblLatestVersion.TabIndex = 6
            Me.lblLatestVersion.Text = "-"
            Me.lblLatestVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLatestDateHeader
            '
            Me.lblLatestDateHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblLatestDateHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblLatestDateHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblLatestDateHeader.Location = New System.Drawing.Point(620, 95)
            Me.lblLatestDateHeader.Name = "lblLatestDateHeader"
            Me.lblLatestDateHeader.Size = New System.Drawing.Size(140, 25)
            Me.lblLatestDateHeader.TabIndex = 7
            Me.lblLatestDateHeader.Text = "تاريخ الإصدار:"
            Me.lblLatestDateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLatestUpdateDate
            '
            Me.lblLatestUpdateDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblLatestUpdateDate.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblLatestUpdateDate.ForeColor = System.Drawing.Color.White
            Me.lblLatestUpdateDate.Location = New System.Drawing.Point(460, 95)
            Me.lblLatestUpdateDate.Name = "lblLatestUpdateDate"
            Me.lblLatestUpdateDate.Size = New System.Drawing.Size(150, 25)
            Me.lblLatestUpdateDate.TabIndex = 8
            Me.lblLatestUpdateDate.Text = "-"
            Me.lblLatestUpdateDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAutoUpdate
            '
            Me.lblAutoUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAutoUpdate.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblAutoUpdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblAutoUpdate.Location = New System.Drawing.Point(1000, 145)
            Me.lblAutoUpdate.Name = "lblAutoUpdate"
            Me.lblAutoUpdate.Size = New System.Drawing.Size(150, 25)
            Me.lblAutoUpdate.TabIndex = 9
            Me.lblAutoUpdate.Text = "تحديث تلقائي:"
            Me.lblAutoUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglAutoUpdate
            '
            Me.tglAutoUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglAutoUpdate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
            Me.tglAutoUpdate.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
            Me.tglAutoUpdate.CheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglAutoUpdate.CheckedState.InnerColor = System.Drawing.Color.White
            Me.tglAutoUpdate.Cursor = System.Windows.Forms.Cursors.Hand
            Me.tglAutoUpdate.Location = New System.Drawing.Point(920, 143)
            Me.tglAutoUpdate.Name = "tglAutoUpdate"
            Me.tglAutoUpdate.Size = New System.Drawing.Size(65, 28)
            Me.tglAutoUpdate.TabIndex = 10
            Me.tglAutoUpdate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglAutoUpdate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.tglAutoUpdate.UncheckedState.InnerBorderColor = System.Drawing.Color.White
            Me.tglAutoUpdate.UncheckedState.InnerColor = System.Drawing.Color.White
            '
            'btnCheckForUpdates
            '
            Me.btnCheckForUpdates.BorderRadius = 10
            Me.btnCheckForUpdates.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCheckForUpdates.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnCheckForUpdates.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnCheckForUpdates.ForeColor = System.Drawing.Color.White
            Me.btnCheckForUpdates.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
            Me.btnCheckForUpdates.Location = New System.Drawing.Point(30, 130)
            Me.btnCheckForUpdates.Name = "btnCheckForUpdates"
            Me.btnCheckForUpdates.Size = New System.Drawing.Size(220, 45)
            Me.btnCheckForUpdates.TabIndex = 11
            Me.btnCheckForUpdates.Text = "🔍 فحص التحديثات"
            '
            'cardHistory
            '
            Me.cardHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardHistory.BackColor = System.Drawing.Color.Transparent
            Me.cardHistory.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardHistory.BorderRadius = 14
            Me.cardHistory.BorderThickness = 1
            Me.cardHistory.Controls.Add(Me.lblCardHistoryTitle)
            Me.cardHistory.Controls.Add(Me.flpUpdateHistory)
            Me.cardHistory.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardHistory.Location = New System.Drawing.Point(30, 310)
            Me.cardHistory.Name = "cardHistory"
            Me.cardHistory.Size = New System.Drawing.Size(1178, 500)
            Me.cardHistory.TabIndex = 3
            '
            'lblCardHistoryTitle
            '
            Me.lblCardHistoryTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardHistoryTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardHistoryTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardHistoryTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardHistoryTitle.Name = "lblCardHistoryTitle"
            Me.lblCardHistoryTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardHistoryTitle.TabIndex = 0
            Me.lblCardHistoryTitle.Text = "سجل التحديثات والإصدارات السابقة"
            Me.lblCardHistoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'flpUpdateHistory
            '
            Me.flpUpdateHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.flpUpdateHistory.AutoScroll = True
            Me.flpUpdateHistory.BackColor = System.Drawing.Color.Transparent
            Me.flpUpdateHistory.Location = New System.Drawing.Point(20, 55)
            Me.flpUpdateHistory.Name = "flpUpdateHistory"
            Me.flpUpdateHistory.Padding = New System.Windows.Forms.Padding(10)
            Me.flpUpdateHistory.Size = New System.Drawing.Size(1138, 425)
            Me.flpUpdateHistory.TabIndex = 1
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnClose.BorderRadius = 10
            Me.btnClose.BorderThickness = 1
            Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 830)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(130, 48)
            Me.btnClose.TabIndex = 4
            Me.btnClose.Text = "إغلاق"
            '
            'UCUpdatesSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCUpdatesSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 900)
            Me.pnlMain.ResumeLayout(False)
            Me.cardStatus.ResumeLayout(False)
            Me.cardHistory.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardStatus As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardStatusTitle As System.Windows.Forms.Label
        Friend WithEvents lblCurrentVersionHeader As System.Windows.Forms.Label
        Friend WithEvents lblCurrentVersion As System.Windows.Forms.Label
        Friend WithEvents lblChannelHeader As System.Windows.Forms.Label
        Friend WithEvents lblChannel As System.Windows.Forms.Label
        Friend WithEvents lblLatestVersionHeader As System.Windows.Forms.Label
        Friend WithEvents lblLatestVersion As System.Windows.Forms.Label
        Friend WithEvents lblLatestDateHeader As System.Windows.Forms.Label
        Friend WithEvents lblLatestUpdateDate As System.Windows.Forms.Label
        Friend WithEvents lblAutoUpdate As System.Windows.Forms.Label
        Friend WithEvents tglAutoUpdate As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents btnCheckForUpdates As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardHistory As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardHistoryTitle As System.Windows.Forms.Label
        Friend WithEvents flpUpdateHistory As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
