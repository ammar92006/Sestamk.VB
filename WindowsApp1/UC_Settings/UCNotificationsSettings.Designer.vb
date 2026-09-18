Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCNotificationsSettings
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
            Me.cardSounds = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardSoundsTitle = New System.Windows.Forms.Label()
            Me.lblOrderSound = New System.Windows.Forms.Label()
            Me.tglOrderSound = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblErrorSound = New System.Windows.Forms.Label()
            Me.tglErrorSound = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.cardAlerts = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardAlertsTitle = New System.Windows.Forms.Label()
            Me.lblLowStock = New System.Windows.Forms.Label()
            Me.tglLowStock = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblPrintFailure = New System.Windows.Forms.Label()
            Me.tglPrintFailure = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardSounds.SuspendLayout()
            Me.cardAlerts.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardSounds)
            Me.pnlMain.Controls.Add(Me.cardAlerts)
            Me.pnlMain.Controls.Add(Me.btnSave)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 520)
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
            Me.lblTitle.Text = "الإشعارات والتنبيهات الصوتية"
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
            Me.lblSubtitle.Text = "التحكم في أصوات العمليات وتنبيهات نفاذ المخزون وأعطال الطباعة"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardSounds
            '
            Me.cardSounds.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardSounds.BackColor = System.Drawing.Color.Transparent
            Me.cardSounds.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardSounds.BorderRadius = 12
            Me.cardSounds.BorderThickness = 1
            Me.cardSounds.Controls.Add(Me.lblCardSoundsTitle)
            Me.cardSounds.Controls.Add(Me.lblOrderSound)
            Me.cardSounds.Controls.Add(Me.tglOrderSound)
            Me.cardSounds.Controls.Add(Me.lblErrorSound)
            Me.cardSounds.Controls.Add(Me.tglErrorSound)
            Me.cardSounds.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardSounds.Location = New System.Drawing.Point(30, 95)
            Me.cardSounds.Name = "cardSounds"
            Me.cardSounds.Size = New System.Drawing.Size(1178, 125)
            Me.cardSounds.TabIndex = 2
            '
            'lblCardSoundsTitle
            '
            Me.lblCardSoundsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardSoundsTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardSoundsTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardSoundsTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardSoundsTitle.Name = "lblCardSoundsTitle"
            Me.lblCardSoundsTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardSoundsTitle.TabIndex = 0
            Me.lblCardSoundsTitle.Text = "🔊 أصوات وتنبيهات النظام"
            Me.lblCardSoundsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOrderSound
            '
            Me.lblOrderSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblOrderSound.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblOrderSound.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblOrderSound.Location = New System.Drawing.Point(860, 56)
            Me.lblOrderSound.Name = "lblOrderSound"
            Me.lblOrderSound.Size = New System.Drawing.Size(290, 32)
            Me.lblOrderSound.TabIndex = 1
            Me.lblOrderSound.Text = "تشغيل صوت عند تسجيل طلب جديد:"
            Me.lblOrderSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglOrderSound
            '
            Me.tglOrderSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglOrderSound.Checked = True
            Me.tglOrderSound.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglOrderSound.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglOrderSound.Location = New System.Drawing.Point(780, 58)
            Me.tglOrderSound.Name = "tglOrderSound"
            Me.tglOrderSound.Size = New System.Drawing.Size(65, 26)
            Me.tglOrderSound.TabIndex = 2
            Me.tglOrderSound.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglOrderSound.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblErrorSound
            '
            Me.lblErrorSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblErrorSound.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblErrorSound.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblErrorSound.Location = New System.Drawing.Point(440, 56)
            Me.lblErrorSound.Name = "lblErrorSound"
            Me.lblErrorSound.Size = New System.Drawing.Size(290, 32)
            Me.lblErrorSound.TabIndex = 3
            Me.lblErrorSound.Text = "تشغيل صوت تحذير عند حدوث خطأ:"
            Me.lblErrorSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglErrorSound
            '
            Me.tglErrorSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglErrorSound.Checked = True
            Me.tglErrorSound.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglErrorSound.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglErrorSound.Location = New System.Drawing.Point(360, 58)
            Me.tglErrorSound.Name = "tglErrorSound"
            Me.tglErrorSound.Size = New System.Drawing.Size(65, 26)
            Me.tglErrorSound.TabIndex = 4
            Me.tglErrorSound.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglErrorSound.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'cardAlerts
            '
            Me.cardAlerts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardAlerts.BackColor = System.Drawing.Color.Transparent
            Me.cardAlerts.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardAlerts.BorderRadius = 12
            Me.cardAlerts.BorderThickness = 1
            Me.cardAlerts.Controls.Add(Me.lblCardAlertsTitle)
            Me.cardAlerts.Controls.Add(Me.lblLowStock)
            Me.cardAlerts.Controls.Add(Me.tglLowStock)
            Me.cardAlerts.Controls.Add(Me.lblPrintFailure)
            Me.cardAlerts.Controls.Add(Me.tglPrintFailure)
            Me.cardAlerts.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardAlerts.Location = New System.Drawing.Point(30, 235)
            Me.cardAlerts.Name = "cardAlerts"
            Me.cardAlerts.Size = New System.Drawing.Size(1178, 125)
            Me.cardAlerts.TabIndex = 3
            '
            'lblCardAlertsTitle
            '
            Me.lblCardAlertsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardAlertsTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardAlertsTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardAlertsTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardAlertsTitle.Name = "lblCardAlertsTitle"
            Me.lblCardAlertsTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardAlertsTitle.TabIndex = 0
            Me.lblCardAlertsTitle.Text = "⚠️ التنبيهات والتحذيرات"
            Me.lblCardAlertsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLowStock
            '
            Me.lblLowStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblLowStock.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblLowStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblLowStock.Location = New System.Drawing.Point(860, 56)
            Me.lblLowStock.Name = "lblLowStock"
            Me.lblLowStock.Size = New System.Drawing.Size(290, 32)
            Me.lblLowStock.TabIndex = 1
            Me.lblLowStock.Text = "إشعار عند اقتراب نفاذ المخزون:"
            Me.lblLowStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglLowStock
            '
            Me.tglLowStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglLowStock.Checked = True
            Me.tglLowStock.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglLowStock.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglLowStock.Location = New System.Drawing.Point(780, 58)
            Me.tglLowStock.Name = "tglLowStock"
            Me.tglLowStock.Size = New System.Drawing.Size(65, 26)
            Me.tglLowStock.TabIndex = 2
            Me.tglLowStock.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglLowStock.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblPrintFailure
            '
            Me.lblPrintFailure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPrintFailure.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPrintFailure.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblPrintFailure.Location = New System.Drawing.Point(440, 56)
            Me.lblPrintFailure.Name = "lblPrintFailure"
            Me.lblPrintFailure.Size = New System.Drawing.Size(290, 32)
            Me.lblPrintFailure.TabIndex = 3
            Me.lblPrintFailure.Text = "تنبيه فوري عند تعطل أو فشل الطباعة:"
            Me.lblPrintFailure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tglPrintFailure
            '
            Me.tglPrintFailure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tglPrintFailure.Checked = True
            Me.tglPrintFailure.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglPrintFailure.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.tglPrintFailure.Location = New System.Drawing.Point(360, 58)
            Me.tglPrintFailure.Name = "tglPrintFailure"
            Me.tglPrintFailure.Size = New System.Drawing.Size(65, 26)
            Me.tglPrintFailure.TabIndex = 4
            Me.tglPrintFailure.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.tglPrintFailure.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BorderRadius = 8
            Me.btnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(978, 385)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(230, 48)
            Me.btnSave.TabIndex = 4
            Me.btnSave.Text = "💾 حفظ الإعدادات"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnReset.BorderRadius = 8
            Me.btnReset.BorderThickness = 1
            Me.btnReset.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnReset.Location = New System.Drawing.Point(740, 385)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(220, 48)
            Me.btnReset.TabIndex = 5
            Me.btnReset.Text = "🔄 استعادة الافتراضي"
            '
            'btnClose
            '
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnClose.BorderRadius = 8
            Me.btnClose.BorderThickness = 1
            Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 385)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 48)
            Me.btnClose.TabIndex = 6
            Me.btnClose.Text = "❌ إغلاق"
            '
            'UCNotificationsSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCNotificationsSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 470)
            Me.pnlMain.ResumeLayout(False)
            Me.cardSounds.ResumeLayout(False)
            Me.cardAlerts.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardSounds As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardSoundsTitle As System.Windows.Forms.Label
        Friend WithEvents lblOrderSound As System.Windows.Forms.Label
        Friend WithEvents tglOrderSound As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblErrorSound As System.Windows.Forms.Label
        Friend WithEvents tglErrorSound As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents cardAlerts As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardAlertsTitle As System.Windows.Forms.Label
        Friend WithEvents lblLowStock As System.Windows.Forms.Label
        Friend WithEvents tglLowStock As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblPrintFailure As System.Windows.Forms.Label
        Friend WithEvents tglPrintFailure As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
