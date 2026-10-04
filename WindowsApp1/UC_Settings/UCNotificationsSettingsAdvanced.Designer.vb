<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCNotificationsSettingsAdvanced
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
        Me.grpTest = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.btnTestExpandable = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTestWithButtons = New Guna.UI2.WinForms.Guna2Button()
        Me.lblTestType = New System.Windows.Forms.Label()
        Me.cmbTestType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnTestToast = New Guna.UI2.WinForms.Guna2Button()
        Me.grpSound = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.btnTestCustomSound = New Guna.UI2.WinForms.Guna2Button()
        Me.btnBrowseSound = New Guna.UI2.WinForms.Guna2Button()
        Me.txtCustomSoundPath = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblCustomSound = New System.Windows.Forms.Label()
        Me.pnlSoundOptions = New System.Windows.Forms.Panel()
        Me.chkPrintFailAlert = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.chkLowStockAlert = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.chkErrorSound = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.chkNewOrderSound = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.chkSoundEnabled = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.grpAppearance = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.chkStackSimilar = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.chkShowProgressBar = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.lblMaxVisible = New System.Windows.Forms.Label()
        Me.numMaxVisible = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.numDuration = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.lblAnimation = New System.Windows.Forms.Label()
        Me.cmbAnimation = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.cmbPosition = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnResetDefaults = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.grpTest.SuspendLayout()
        Me.grpSound.SuspendLayout()
        Me.pnlSoundOptions.SuspendLayout()
        Me.grpAppearance.SuspendLayout()
        CType(Me.numMaxVisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Controls.Add(Me.grpTest)
        Me.pnlMain.Controls.Add(Me.grpSound)
        Me.pnlMain.Controls.Add(Me.grpAppearance)
        Me.pnlMain.Controls.Add(Me.pnlButtons)
        Me.pnlMain.Controls.Add(Me.lblTitle)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlMain.Size = New System.Drawing.Size(900, 700)
        Me.pnlMain.TabIndex = 0
        '
        'grpTest
        '
        Me.grpTest.BorderRadius = 10
        Me.grpTest.Controls.Add(Me.btnTestExpandable)
        Me.grpTest.Controls.Add(Me.btnTestWithButtons)
        Me.grpTest.Controls.Add(Me.lblTestType)
        Me.grpTest.Controls.Add(Me.cmbTestType)
        Me.grpTest.Controls.Add(Me.btnTestToast)
        Me.grpTest.CustomBorderColor = Color.FromArgb(59, 130, 246)
        Me.grpTest.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTest.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpTest.ForeColor = System.Drawing.Color.White
        Me.grpTest.Location = New System.Drawing.Point(20, 550)
        Me.grpTest.Name = "grpTest"
        Me.grpTest.Size = New System.Drawing.Size(860, 180)
        Me.grpTest.TabIndex = 4
        Me.grpTest.Text = "اختبار الإشعارات"
        '
        'btnTestExpandable
        '
        Me.btnTestExpandable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTestExpandable.BorderRadius = 8
        Me.btnTestExpandable.FillColor = Color.FromArgb(168, 85, 247)
        Me.btnTestExpandable.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTestExpandable.ForeColor = System.Drawing.Color.White
        Me.btnTestExpandable.Location = New System.Drawing.Point(40, 120)
        Me.btnTestExpandable.Name = "btnTestExpandable"
        Me.btnTestExpandable.Size = New System.Drawing.Size(180, 40)
        Me.btnTestExpandable.TabIndex = 7
        Me.btnTestExpandable.Text = "اختبار قابل للتوسيع"
        '
        'btnTestWithButtons
        '
        Me.btnTestWithButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTestWithButtons.BorderRadius = 8
        Me.btnTestWithButtons.FillColor = Color.FromArgb(245, 158, 11)
        Me.btnTestWithButtons.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTestWithButtons.ForeColor = System.Drawing.Color.White
        Me.btnTestWithButtons.Location = New System.Drawing.Point(240, 120)
        Me.btnTestWithButtons.Name = "btnTestWithButtons"
        Me.btnTestWithButtons.Size = New System.Drawing.Size(180, 40)
        Me.btnTestWithButtons.TabIndex = 6
        Me.btnTestWithButtons.Text = "اختبار مع أزرار"
        '
        'lblTestType
        '
        Me.lblTestType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTestType.AutoSize = True
        Me.lblTestType.BackColor = System.Drawing.Color.Transparent
        Me.lblTestType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTestType.Location = New System.Drawing.Point(760, 60)
        Me.lblTestType.Name = "lblTestType"
        Me.lblTestType.Size = New System.Drawing.Size(80, 19)
        Me.lblTestType.TabIndex = 5
        Me.lblTestType.Text = "نوع الإشعار:"
        '
        'cmbTestType
        '
        Me.cmbTestType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTestType.BackColor = System.Drawing.Color.Transparent
        Me.cmbTestType.BorderRadius = 8
        Me.cmbTestType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTestType.FocusedColor = Color.FromArgb(94, 148, 255)
        Me.cmbTestType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbTestType.ForeColor = System.Drawing.Color.Black
        Me.cmbTestType.ItemHeight = 30
        Me.cmbTestType.Items.AddRange(New Object() {"نجاح", "معلومة", "تحذير", "خطأ", "سؤال"})
        Me.cmbTestType.Location = New System.Drawing.Point(540, 55)
        Me.cmbTestType.Name = "cmbTestType"
        Me.cmbTestType.Size = New System.Drawing.Size(200, 36)
        Me.cmbTestType.TabIndex = 4
        Me.cmbTestType.SelectedIndex = 0
        '
        'btnTestToast
        '
        Me.btnTestToast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTestToast.BorderRadius = 8
        Me.btnTestToast.FillColor = Color.FromArgb(34, 197, 94)
        Me.btnTestToast.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTestToast.ForeColor = System.Drawing.Color.White
        Me.btnTestToast.Location = New System.Drawing.Point(440, 120)
        Me.btnTestToast.Name = "btnTestToast"
        Me.btnTestToast.Size = New System.Drawing.Size(180, 40)
        Me.btnTestToast.TabIndex = 3
        Me.btnTestToast.Text = "اختبار الإشعار"
        '
        'grpSound
        '
        Me.grpSound.BorderRadius = 10
        Me.grpSound.Controls.Add(Me.btnTestCustomSound)
        Me.grpSound.Controls.Add(Me.btnBrowseSound)
        Me.grpSound.Controls.Add(Me.txtCustomSoundPath)
        Me.grpSound.Controls.Add(Me.lblCustomSound)
        Me.grpSound.Controls.Add(Me.pnlSoundOptions)
        Me.grpSound.Controls.Add(Me.chkSoundEnabled)
        Me.grpSound.CustomBorderColor = Color.FromArgb(59, 130, 246)
        Me.grpSound.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpSound.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpSound.ForeColor = System.Drawing.Color.White
        Me.grpSound.Location = New System.Drawing.Point(20, 330)
        Me.grpSound.Name = "grpSound"
        Me.grpSound.Size = New System.Drawing.Size(860, 220)
        Me.grpSound.TabIndex = 3
        Me.grpSound.Text = "إعدادات الأصوات"
        '
        'btnTestCustomSound
        '
        Me.btnTestCustomSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTestCustomSound.BorderRadius = 8
        Me.btnTestCustomSound.FillColor = Color.FromArgb(34, 197, 94)
        Me.btnTestCustomSound.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTestCustomSound.ForeColor = System.Drawing.Color.White
        Me.btnTestCustomSound.Location = New System.Drawing.Point(40, 165)
        Me.btnTestCustomSound.Name = "btnTestCustomSound"
        Me.btnTestCustomSound.Size = New System.Drawing.Size(120, 35)
        Me.btnTestCustomSound.TabIndex = 5
        Me.btnTestCustomSound.Text = "تجربة الصوت"
        '
        'btnBrowseSound
        '
        Me.btnBrowseSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseSound.BorderRadius = 8
        Me.btnBrowseSound.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBrowseSound.ForeColor = System.Drawing.Color.White
        Me.btnBrowseSound.Location = New System.Drawing.Point(180, 165)
        Me.btnBrowseSound.Name = "btnBrowseSound"
        Me.btnBrowseSound.Size = New System.Drawing.Size(120, 35)
        Me.btnBrowseSound.TabIndex = 4
        Me.btnBrowseSound.Text = "استعراض..."
        '
        'txtCustomSoundPath
        '
        Me.txtCustomSoundPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomSoundPath.BorderRadius = 8
        Me.txtCustomSoundPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomSoundPath.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtCustomSoundPath.Location = New System.Drawing.Point(320, 165)
        Me.txtCustomSoundPath.Name = "txtCustomSoundPath"
        Me.txtCustomSoundPath.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCustomSoundPath.PlaceholderText = "مسار ملف الصوت المخصص"
        Me.txtCustomSoundPath.ReadOnly = True
        Me.txtCustomSoundPath.SelectedText = ""
        Me.txtCustomSoundPath.Size = New System.Drawing.Size(420, 36)
        Me.txtCustomSoundPath.TabIndex = 3
        '
        'lblCustomSound
        '
        Me.lblCustomSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCustomSound.AutoSize = True
        Me.lblCustomSound.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomSound.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCustomSound.Location = New System.Drawing.Point(750, 173)
        Me.lblCustomSound.Name = "lblCustomSound"
        Me.lblCustomSound.Size = New System.Drawing.Size(90, 19)
        Me.lblCustomSound.TabIndex = 2
        Me.lblCustomSound.Text = "صوت مخصص:"
        '
        'pnlSoundOptions
        '
        Me.pnlSoundOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSoundOptions.BackColor = System.Drawing.Color.Transparent
        Me.pnlSoundOptions.Controls.Add(Me.chkPrintFailAlert)
        Me.pnlSoundOptions.Controls.Add(Me.chkLowStockAlert)
        Me.pnlSoundOptions.Controls.Add(Me.chkErrorSound)
        Me.pnlSoundOptions.Controls.Add(Me.chkNewOrderSound)
        Me.pnlSoundOptions.Location = New System.Drawing.Point(40, 80)
        Me.pnlSoundOptions.Name = "pnlSoundOptions"
        Me.pnlSoundOptions.Size = New System.Drawing.Size(800, 70)
        Me.pnlSoundOptions.TabIndex = 1
        '
        'chkPrintFailAlert
        '
        Me.chkPrintFailAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPrintFailAlert.AutoSize = True
        Me.chkPrintFailAlert.CheckedState.BorderColor = Color.FromArgb(94, 148, 255)
        Me.chkPrintFailAlert.CheckedState.BorderRadius = 2
        Me.chkPrintFailAlert.CheckedState.BorderThickness = 0
        Me.chkPrintFailAlert.CheckedState.FillColor = Color.FromArgb(94, 148, 255)
        Me.chkPrintFailAlert.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkPrintFailAlert.Location = New System.Drawing.Point(470, 40)
        Me.chkPrintFailAlert.Name = "chkPrintFailAlert"
        Me.chkPrintFailAlert.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPrintFailAlert.Size = New System.Drawing.Size(120, 23)
        Me.chkPrintFailAlert.TabIndex = 3
        Me.chkPrintFailAlert.Text = "تنبيه فشل الطباعة"
        Me.chkPrintFailAlert.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149)
        Me.chkPrintFailAlert.UncheckedState.BorderRadius = 2
        Me.chkPrintFailAlert.UncheckedState.BorderThickness = 0
        Me.chkPrintFailAlert.UncheckedState.FillColor = Color.FromArgb(125, 137, 149)
        '
        'chkLowStockAlert
        '
        Me.chkLowStockAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLowStockAlert.AutoSize = True
        Me.chkLowStockAlert.CheckedState.BorderColor = Color.FromArgb(94, 148, 255)
        Me.chkLowStockAlert.CheckedState.BorderRadius = 2
        Me.chkLowStockAlert.CheckedState.BorderThickness = 0
        Me.chkLowStockAlert.CheckedState.FillColor = Color.FromArgb(94, 148, 255)
        Me.chkLowStockAlert.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkLowStockAlert.Location = New System.Drawing.Point(650, 40)
        Me.chkLowStockAlert.Name = "chkLowStockAlert"
        Me.chkLowStockAlert.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkLowStockAlert.Size = New System.Drawing.Size(120, 23)
        Me.chkLowStockAlert.TabIndex = 2
        Me.chkLowStockAlert.Text = "تنبيه نفاذ المخزون"
        Me.chkLowStockAlert.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149)
        Me.chkLowStockAlert.UncheckedState.BorderRadius = 2
        Me.chkLowStockAlert.UncheckedState.BorderThickness = 0
        Me.chkLowStockAlert.UncheckedState.FillColor = Color.FromArgb(125, 137, 149)
        '
        'chkErrorSound
        '
        Me.chkErrorSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkErrorSound.AutoSize = True
        Me.chkErrorSound.CheckedState.BorderColor = Color.FromArgb(94, 148, 255)
        Me.chkErrorSound.CheckedState.BorderRadius = 2
        Me.chkErrorSound.CheckedState.BorderThickness = 0
        Me.chkErrorSound.CheckedState.FillColor = Color.FromArgb(94, 148, 255)
        Me.chkErrorSound.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkErrorSound.Location = New System.Drawing.Point(650, 10)
        Me.chkErrorSound.Name = "chkErrorSound"
        Me.chkErrorSound.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkErrorSound.Size = New System.Drawing.Size(100, 23)
        Me.chkErrorSound.TabIndex = 1
        Me.chkErrorSound.Text = "صوت الأخطاء"
        Me.chkErrorSound.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149)
        Me.chkErrorSound.UncheckedState.BorderRadius = 2
        Me.chkErrorSound.UncheckedState.BorderThickness = 0
        Me.chkErrorSound.UncheckedState.FillColor = Color.FromArgb(125, 137, 149)
        '
        'chkNewOrderSound
        '
        Me.chkNewOrderSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNewOrderSound.AutoSize = True
        Me.chkNewOrderSound.CheckedState.BorderColor = Color.FromArgb(94, 148, 255)
        Me.chkNewOrderSound.CheckedState.BorderRadius = 2
        Me.chkNewOrderSound.CheckedState.BorderThickness = 0
        Me.chkNewOrderSound.CheckedState.FillColor = Color.FromArgb(94, 148, 255)
        Me.chkNewOrderSound.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkNewOrderSound.Location = New System.Drawing.Point(470, 10)
        Me.chkNewOrderSound.Name = "chkNewOrderSound"
        Me.chkNewOrderSound.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkNewOrderSound.Size = New System.Drawing.Size(130, 23)
        Me.chkNewOrderSound.TabIndex = 0
        Me.chkNewOrderSound.Text = "صوت الطلبات الجديدة"
        Me.chkNewOrderSound.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149)
        Me.chkNewOrderSound.UncheckedState.BorderRadius = 2
        Me.chkNewOrderSound.UncheckedState.BorderThickness = 0
        Me.chkNewOrderSound.UncheckedState.FillColor = Color.FromArgb(125, 137, 149)
        '
        'chkSoundEnabled
        '
        Me.chkSoundEnabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSoundEnabled.AutoSize = True
        Me.chkSoundEnabled.BackColor = System.Drawing.Color.Transparent
        Me.chkSoundEnabled.CheckedState.BorderColor = Color.FromArgb(94, 148, 255)
        Me.chkSoundEnabled.CheckedState.BorderRadius = 2
        Me.chkSoundEnabled.CheckedState.BorderThickness = 0
        Me.chkSoundEnabled.CheckedState.FillColor = Color.FromArgb(94, 148, 255)
        Me.chkSoundEnabled.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkSoundEnabled.Location = New System.Drawing.Point(700, 50)
        Me.chkSoundEnabled.Name = "chkSoundEnabled"
        Me.chkSoundEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkSoundEnabled.Size = New System.Drawing.Size(120, 23)
        Me.chkSoundEnabled.TabIndex = 0
        Me.chkSoundEnabled.Text = "تفعيل الأصوات"
        Me.chkSoundEnabled.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149)
        Me.chkSoundEnabled.UncheckedState.BorderRadius = 2
        Me.chkSoundEnabled.UncheckedState.BorderThickness = 0
        Me.chkSoundEnabled.UncheckedState.FillColor = Color.FromArgb(125, 137, 149)
        '
        'grpAppearance
        '
        Me.grpAppearance.BorderRadius = 10
        Me.grpAppearance.Controls.Add(Me.chkStackSimilar)
        Me.grpAppearance.Controls.Add(Me.chkShowProgressBar)
        Me.grpAppearance.Controls.Add(Me.lblMaxVisible)
        Me.grpAppearance.Controls.Add(Me.numMaxVisible)
        Me.grpAppearance.Controls.Add(Me.lblDuration)
        Me.grpAppearance.Controls.Add(Me.numDuration)
        Me.grpAppearance.Controls.Add(Me.lblAnimation)
        Me.grpAppearance.Controls.Add(Me.cmbAnimation)
        Me.grpAppearance.Controls.Add(Me.lblPosition)
        Me.grpAppearance.Controls.Add(Me.cmbPosition)
        Me.grpAppearance.CustomBorderColor = Color.FromArgb(59, 130, 246)
        Me.grpAppearance.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpAppearance.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpAppearance.ForeColor = System.Drawing.Color.White
        Me.grpAppearance.Location = New System.Drawing.Point(20, 70)
        Me.grpAppearance.Name = "grpAppearance"
        Me.grpAppearance.Size = New System.Drawing.Size(860, 260)
        Me.grpAppearance.TabIndex = 2
        Me.grpAppearance.Text = "المظهر والحركة"
        '
        'chkStackSimilar
        '
        Me.chkStackSimilar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkStackSimilar.AutoSize = True
        Me.chkStackSimilar.BackColor = System.Drawing.Color.Transparent
        Me.chkStackSimilar.CheckedState.BorderColor = Color.FromArgb(94, 148, 255)
        Me.chkStackSimilar.CheckedState.BorderRadius = 2
        Me.chkStackSimilar.CheckedState.BorderThickness = 0
        Me.chkStackSimilar.CheckedState.FillColor = Color.FromArgb(94, 148, 255)
        Me.chkStackSimilar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkStackSimilar.Location = New System.Drawing.Point(660, 215)
        Me.chkStackSimilar.Name = "chkStackSimilar"
        Me.chkStackSimilar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkStackSimilar.Size = New System.Drawing.Size(160, 23)
        Me.chkStackSimilar.TabIndex = 9
        Me.chkStackSimilar.Text = "تجميع الإشعارات المتشابهة"
        Me.chkStackSimilar.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149)
        Me.chkStackSimilar.UncheckedState.BorderRadius = 2
        Me.chkStackSimilar.UncheckedState.BorderThickness = 0
        Me.chkStackSimilar.UncheckedState.FillColor = Color.FromArgb(125, 137, 149)
        '
        'chkShowProgressBar
        '
        Me.chkShowProgressBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowProgressBar.AutoSize = True
        Me.chkShowProgressBar.BackColor = System.Drawing.Color.Transparent
        Me.chkShowProgressBar.CheckedState.BorderColor = Color.FromArgb(94, 148, 255)
        Me.chkShowProgressBar.CheckedState.BorderRadius = 2
        Me.chkShowProgressBar.CheckedState.BorderThickness = 0
        Me.chkShowProgressBar.CheckedState.FillColor = Color.FromArgb(94, 148, 255)
        Me.chkShowProgressBar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkShowProgressBar.Location = New System.Drawing.Point(400, 215)
        Me.chkShowProgressBar.Name = "chkShowProgressBar"
        Me.chkShowProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkShowProgressBar.Size = New System.Drawing.Size(140, 23)
        Me.chkShowProgressBar.TabIndex = 8
        Me.chkShowProgressBar.Text = "إظهار شريط التقدم"
        Me.chkShowProgressBar.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149)
        Me.chkShowProgressBar.UncheckedState.BorderRadius = 2
        Me.chkShowProgressBar.UncheckedState.BorderThickness = 0
        Me.chkShowProgressBar.UncheckedState.FillColor = Color.FromArgb(125, 137, 149)
        '
        'lblMaxVisible
        '
        Me.lblMaxVisible.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMaxVisible.AutoSize = True
        Me.lblMaxVisible.BackColor = System.Drawing.Color.Transparent
        Me.lblMaxVisible.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblMaxVisible.Location = New System.Drawing.Point(680, 175)
        Me.lblMaxVisible.Name = "lblMaxVisible"
        Me.lblMaxVisible.Size = New System.Drawing.Size(140, 19)
        Me.lblMaxVisible.TabIndex = 7
        Me.lblMaxVisible.Text = "الحد الأقصى للإشعارات:"
        '
        'numMaxVisible
        '
        Me.numMaxVisible.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numMaxVisible.BackColor = System.Drawing.Color.Transparent
        Me.numMaxVisible.BorderRadius = 8
        Me.numMaxVisible.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.numMaxVisible.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.numMaxVisible.Location = New System.Drawing.Point(540, 168)
        Me.numMaxVisible.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numMaxVisible.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMaxVisible.Name = "numMaxVisible"
        Me.numMaxVisible.Size = New System.Drawing.Size(120, 36)
        Me.numMaxVisible.TabIndex = 6
        Me.numMaxVisible.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lblDuration
        '
        Me.lblDuration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDuration.AutoSize = True
        Me.lblDuration.BackColor = System.Drawing.Color.Transparent
        Me.lblDuration.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDuration.Location = New System.Drawing.Point(710, 129)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(110, 19)
        Me.lblDuration.TabIndex = 5
        Me.lblDuration.Text = "مدة العرض (ملي ث):"
        '
        'numDuration
        '
        Me.numDuration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numDuration.BackColor = System.Drawing.Color.Transparent
        Me.numDuration.BorderRadius = 8
        Me.numDuration.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.numDuration.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.numDuration.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numDuration.Location = New System.Drawing.Point(540, 122)
        Me.numDuration.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.numDuration.Minimum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numDuration.Name = "numDuration"
        Me.numDuration.Size = New System.Drawing.Size(150, 36)
        Me.numDuration.TabIndex = 4
        Me.numDuration.Value = New Decimal(New Integer() {3800, 0, 0, 0})
        '
        'lblAnimation
        '
        Me.lblAnimation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAnimation.AutoSize = True
        Me.lblAnimation.BackColor = System.Drawing.Color.Transparent
        Me.lblAnimation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblAnimation.Location = New System.Drawing.Point(750, 85)
        Me.lblAnimation.Name = "lblAnimation"
        Me.lblAnimation.Size = New System.Drawing.Size(70, 19)
        Me.lblAnimation.TabIndex = 3
        Me.lblAnimation.Text = "الأنيميشن:"
        '
        'cmbAnimation
        '
        Me.cmbAnimation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAnimation.BackColor = System.Drawing.Color.Transparent
        Me.cmbAnimation.BorderRadius = 8
        Me.cmbAnimation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnimation.FocusedColor = Color.FromArgb(94, 148, 255)
        Me.cmbAnimation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbAnimation.ForeColor = System.Drawing.Color.Black
        Me.cmbAnimation.ItemHeight = 30
        Me.cmbAnimation.Items.AddRange(New Object() {"انزلاق", "تلاشي", "تكبير", "ارتداد", "انزلاق مع ارتداد"})
        Me.cmbAnimation.Location = New System.Drawing.Point(540, 78)
        Me.cmbAnimation.Name = "cmbAnimation"
        Me.cmbAnimation.Size = New System.Drawing.Size(200, 36)
        Me.cmbAnimation.TabIndex = 2
        Me.cmbAnimation.SelectedIndex = 4
        '
        'lblPosition
        '
        Me.lblPosition.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPosition.AutoSize = True
        Me.lblPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblPosition.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPosition.Location = New System.Drawing.Point(730, 48)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(90, 19)
        Me.lblPosition.TabIndex = 1
        Me.lblPosition.Text = "موضع العرض:"
        '
        'cmbPosition
        '
        Me.cmbPosition.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPosition.BackColor = System.Drawing.Color.Transparent
        Me.cmbPosition.BorderRadius = 8
        Me.cmbPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPosition.FocusedColor = Color.FromArgb(94, 148, 255)
        Me.cmbPosition.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbPosition.ForeColor = System.Drawing.Color.Black
        Me.cmbPosition.ItemHeight = 30
        Me.cmbPosition.Items.AddRange(New Object() {"أسفل اليمين", "أسفل اليسار", "أسفل الوسط", "أعلى اليمين", "أعلى اليسار", "أعلى الوسط", "الوسط"})
        Me.cmbPosition.Location = New System.Drawing.Point(540, 41)
        Me.cmbPosition.Name = "cmbPosition"
        Me.cmbPosition.Size = New System.Drawing.Size(180, 36)
        Me.cmbPosition.TabIndex = 0
        Me.cmbPosition.SelectedIndex = 0
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnResetDefaults)
        Me.pnlButtons.Controls.Add(Me.btnSave)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(20, 750)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(860, 60)
        Me.pnlButtons.TabIndex = 1
        '
        'btnResetDefaults
        '
        Me.btnResetDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetDefaults.BorderRadius = 10
        Me.btnResetDefaults.FillColor = Color.FromArgb(125, 137, 149)
        Me.btnResetDefaults.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnResetDefaults.ForeColor = System.Drawing.Color.White
        Me.btnResetDefaults.Location = New System.Drawing.Point(540, 10)
        Me.btnResetDefaults.Name = "btnResetDefaults"
        Me.btnResetDefaults.Size = New System.Drawing.Size(150, 45)
        Me.btnResetDefaults.TabIndex = 1
        Me.btnResetDefaults.Text = "استعادة الافتراضي"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BorderRadius = 10
        Me.btnSave.FillColor = Color.FromArgb(34, 197, 94)
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(710, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 45)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "حفظ الإعدادات"
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitle.Size = New System.Drawing.Size(860, 50)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "⚙️ إعدادات الإشعارات المتطورة"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UCNotificationsSettingsAdvanced
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "UCNotificationsSettingsAdvanced"
        Me.Size = New System.Drawing.Size(900, 700)
        Me.pnlMain.ResumeLayout(False)
        Me.grpTest.ResumeLayout(False)
        Me.grpTest.PerformLayout()
        Me.grpSound.ResumeLayout(False)
        Me.grpSound.PerformLayout()
        Me.pnlSoundOptions.ResumeLayout(False)
        Me.pnlSoundOptions.PerformLayout()
        Me.grpAppearance.ResumeLayout(False)
        Me.grpAppearance.PerformLayout()
        CType(Me.numMaxVisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnResetDefaults As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents grpAppearance As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents cmbPosition As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblAnimation As System.Windows.Forms.Label
    Friend WithEvents cmbAnimation As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents numDuration As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents lblMaxVisible As System.Windows.Forms.Label
    Friend WithEvents numMaxVisible As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents chkShowProgressBar As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents chkStackSimilar As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents grpSound As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents chkSoundEnabled As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents pnlSoundOptions As System.Windows.Forms.Panel
    Friend WithEvents chkNewOrderSound As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents chkErrorSound As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents chkLowStockAlert As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents chkPrintFailAlert As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents lblCustomSound As System.Windows.Forms.Label
    Friend WithEvents txtCustomSoundPath As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnBrowseSound As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTestCustomSound As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents grpTest As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents btnTestToast As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTestType As System.Windows.Forms.Label
    Friend WithEvents cmbTestType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnTestWithButtons As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTestExpandable As Guna.UI2.WinForms.Guna2Button
End Class
