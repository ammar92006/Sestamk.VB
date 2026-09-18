Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCScannerSettings
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
            Me.cardPort = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardPortTitle = New System.Windows.Forms.Label()
            Me.lblPort = New System.Windows.Forms.Label()
            Me.ComboBoxPorts = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.btnRefreshPorts = New Guna.UI2.WinForms.Guna2Button()
            Me.lblEnabled = New System.Windows.Forms.Label()
            Me.CheckBoxEnabled = New Guna.UI2.WinForms.Guna2ToggleSwitch()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.cardAdvanced = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardAdvancedTitle = New System.Windows.Forms.Label()
            Me.lblBaudRate = New System.Windows.Forms.Label()
            Me.cmbBaudRate = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblDataBits = New System.Windows.Forms.Label()
            Me.cmbDataBits = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblParity = New System.Windows.Forms.Label()
            Me.cmbParity = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblStopBits = New System.Windows.Forms.Label()
            Me.cmbStopBits = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.cardTest = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardTestTitle = New System.Windows.Forms.Label()
            Me.lblScanTestHint = New System.Windows.Forms.Label()
            Me.btnTestConnection = New Guna.UI2.WinForms.Guna2Button()
            Me.btnCloseConnection = New Guna.UI2.WinForms.Guna2Button()
            Me.txtScanTestResult = New System.Windows.Forms.TextBox()
            Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
            Me.btnReset = New Guna.UI2.WinForms.Guna2Button()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardPort.SuspendLayout()
            Me.cardAdvanced.SuspendLayout()
            Me.cardTest.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardPort)
            Me.pnlMain.Controls.Add(Me.cardAdvanced)
            Me.pnlMain.Controls.Add(Me.cardTest)
            Me.pnlMain.Controls.Add(Me.btnSave)
            Me.pnlMain.Controls.Add(Me.btnReset)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 760)
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
            Me.lblTitle.Text = "إعدادات قارئ الباركود (الاسكنر)"
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
            Me.lblSubtitle.Text = "تهيئة منفذ الاتصال التسلسلي (COM Port) واختبار القراءة الحيّة للباركود"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardPort
            '
            Me.cardPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardPort.BackColor = System.Drawing.Color.Transparent
            Me.cardPort.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardPort.BorderRadius = 12
            Me.cardPort.BorderThickness = 1
            Me.cardPort.Controls.Add(Me.lblCardPortTitle)
            Me.cardPort.Controls.Add(Me.lblPort)
            Me.cardPort.Controls.Add(Me.ComboBoxPorts)
            Me.cardPort.Controls.Add(Me.btnRefreshPorts)
            Me.cardPort.Controls.Add(Me.lblEnabled)
            Me.cardPort.Controls.Add(Me.CheckBoxEnabled)
            Me.cardPort.Controls.Add(Me.lblStatus)
            Me.cardPort.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardPort.Location = New System.Drawing.Point(30, 95)
            Me.cardPort.Name = "cardPort"
            Me.cardPort.Size = New System.Drawing.Size(1178, 160)
            Me.cardPort.TabIndex = 2
            '
            'lblCardPortTitle
            '
            Me.lblCardPortTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardPortTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardPortTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardPortTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardPortTitle.Name = "lblCardPortTitle"
            Me.lblCardPortTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardPortTitle.TabIndex = 0
            Me.lblCardPortTitle.Text = "🔌 المنفذ وحالة القارئ"
            Me.lblCardPortTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPort
            '
            Me.lblPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPort.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblPort.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblPort.Location = New System.Drawing.Point(970, 56)
            Me.lblPort.Name = "lblPort"
            Me.lblPort.Size = New System.Drawing.Size(180, 32)
            Me.lblPort.TabIndex = 1
            Me.lblPort.Text = "منفذ الاتصال (Port):"
            Me.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ComboBoxPorts
            '
            Me.ComboBoxPorts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxPorts.BackColor = System.Drawing.Color.Transparent
            Me.ComboBoxPorts.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.ComboBoxPorts.BorderRadius = 8
            Me.ComboBoxPorts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ComboBoxPorts.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.ComboBoxPorts.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.ComboBoxPorts.ForeColor = System.Drawing.Color.White
            Me.ComboBoxPorts.ItemHeight = 32
            Me.ComboBoxPorts.Location = New System.Drawing.Point(700, 52)
            Me.ComboBoxPorts.Name = "ComboBoxPorts"
            Me.ComboBoxPorts.Size = New System.Drawing.Size(260, 38)
            Me.ComboBoxPorts.TabIndex = 2
            '
            'btnRefreshPorts
            '
            Me.btnRefreshPorts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRefreshPorts.BorderRadius = 8
            Me.btnRefreshPorts.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnRefreshPorts.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnRefreshPorts.ForeColor = System.Drawing.Color.White
            Me.btnRefreshPorts.Location = New System.Drawing.Point(540, 52)
            Me.btnRefreshPorts.Name = "btnRefreshPorts"
            Me.btnRefreshPorts.Size = New System.Drawing.Size(145, 38)
            Me.btnRefreshPorts.TabIndex = 3
            Me.btnRefreshPorts.Text = "🔄 تحديث المنافذ"
            '
            'lblEnabled
            '
            Me.lblEnabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblEnabled.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblEnabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblEnabled.Location = New System.Drawing.Point(360, 56)
            Me.lblEnabled.Name = "lblEnabled"
            Me.lblEnabled.Size = New System.Drawing.Size(160, 32)
            Me.lblEnabled.TabIndex = 4
            Me.lblEnabled.Text = "تفعيل الاسكنر:"
            Me.lblEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CheckBoxEnabled
            '
            Me.CheckBoxEnabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxEnabled.Checked = True
            Me.CheckBoxEnabled.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.CheckBoxEnabled.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.CheckBoxEnabled.Location = New System.Drawing.Point(280, 58)
            Me.CheckBoxEnabled.Name = "CheckBoxEnabled"
            Me.CheckBoxEnabled.Size = New System.Drawing.Size(65, 26)
            Me.CheckBoxEnabled.TabIndex = 5
            Me.CheckBoxEnabled.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.CheckBoxEnabled.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatus.ForeColor = System.Drawing.Color.LightGreen
            Me.lblStatus.Location = New System.Drawing.Point(30, 108)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(1120, 30)
            Me.lblStatus.TabIndex = 6
            Me.lblStatus.Text = "حالة الاسكنر: جاهز للاستخدام ✅"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cardAdvanced
            '
            Me.cardAdvanced.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardAdvanced.BackColor = System.Drawing.Color.Transparent
            Me.cardAdvanced.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardAdvanced.BorderRadius = 12
            Me.cardAdvanced.BorderThickness = 1
            Me.cardAdvanced.Controls.Add(Me.lblCardAdvancedTitle)
            Me.cardAdvanced.Controls.Add(Me.lblBaudRate)
            Me.cardAdvanced.Controls.Add(Me.cmbBaudRate)
            Me.cardAdvanced.Controls.Add(Me.lblDataBits)
            Me.cardAdvanced.Controls.Add(Me.cmbDataBits)
            Me.cardAdvanced.Controls.Add(Me.lblParity)
            Me.cardAdvanced.Controls.Add(Me.cmbParity)
            Me.cardAdvanced.Controls.Add(Me.lblStopBits)
            Me.cardAdvanced.Controls.Add(Me.cmbStopBits)
            Me.cardAdvanced.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardAdvanced.Location = New System.Drawing.Point(30, 270)
            Me.cardAdvanced.Name = "cardAdvanced"
            Me.cardAdvanced.Size = New System.Drawing.Size(1178, 120)
            Me.cardAdvanced.TabIndex = 3
            '
            'lblCardAdvancedTitle
            '
            Me.lblCardAdvancedTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardAdvancedTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardAdvancedTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardAdvancedTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardAdvancedTitle.Name = "lblCardAdvancedTitle"
            Me.lblCardAdvancedTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardAdvancedTitle.TabIndex = 0
            Me.lblCardAdvancedTitle.Text = "⚙️ الإعدادات المتقدمة للمنفذ"
            Me.lblCardAdvancedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaudRate
            '
            Me.lblBaudRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBaudRate.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblBaudRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblBaudRate.Location = New System.Drawing.Point(1000, 56)
            Me.lblBaudRate.Name = "lblBaudRate"
            Me.lblBaudRate.Size = New System.Drawing.Size(150, 32)
            Me.lblBaudRate.TabIndex = 1
            Me.lblBaudRate.Text = "سرعة النقل (Baud):"
            Me.lblBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbBaudRate
            '
            Me.cmbBaudRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbBaudRate.BackColor = System.Drawing.Color.Transparent
            Me.cmbBaudRate.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbBaudRate.BorderRadius = 8
            Me.cmbBaudRate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbBaudRate.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbBaudRate.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbBaudRate.ForeColor = System.Drawing.Color.White
            Me.cmbBaudRate.ItemHeight = 32
            Me.cmbBaudRate.Items.AddRange(New Object() {"9600", "19200", "38400", "57600", "115200"})
            Me.cmbBaudRate.Location = New System.Drawing.Point(850, 52)
            Me.cmbBaudRate.Name = "cmbBaudRate"
            Me.cmbBaudRate.Size = New System.Drawing.Size(140, 38)
            Me.cmbBaudRate.StartIndex = 0
            Me.cmbBaudRate.TabIndex = 2
            '
            'lblDataBits
            '
            Me.lblDataBits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDataBits.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblDataBits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblDataBits.Location = New System.Drawing.Point(700, 56)
            Me.lblDataBits.Name = "lblDataBits"
            Me.lblDataBits.Size = New System.Drawing.Size(130, 32)
            Me.lblDataBits.TabIndex = 3
            Me.lblDataBits.Text = "بتات البيانات:"
            Me.lblDataBits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbDataBits
            '
            Me.cmbDataBits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbDataBits.BackColor = System.Drawing.Color.Transparent
            Me.cmbDataBits.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbDataBits.BorderRadius = 8
            Me.cmbDataBits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbDataBits.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbDataBits.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbDataBits.ForeColor = System.Drawing.Color.White
            Me.cmbDataBits.ItemHeight = 32
            Me.cmbDataBits.Items.AddRange(New Object() {"8", "7"})
            Me.cmbDataBits.Location = New System.Drawing.Point(570, 52)
            Me.cmbDataBits.Name = "cmbDataBits"
            Me.cmbDataBits.Size = New System.Drawing.Size(120, 38)
            Me.cmbDataBits.StartIndex = 0
            Me.cmbDataBits.TabIndex = 4
            '
            'lblParity
            '
            Me.lblParity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblParity.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblParity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblParity.Location = New System.Drawing.Point(420, 56)
            Me.lblParity.Name = "lblParity"
            Me.lblParity.Size = New System.Drawing.Size(130, 32)
            Me.lblParity.TabIndex = 5
            Me.lblParity.Text = "التماثل (Parity):"
            Me.lblParity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbParity
            '
            Me.cmbParity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbParity.BackColor = System.Drawing.Color.Transparent
            Me.cmbParity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbParity.BorderRadius = 8
            Me.cmbParity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbParity.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbParity.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbParity.ForeColor = System.Drawing.Color.White
            Me.cmbParity.ItemHeight = 32
            Me.cmbParity.Items.AddRange(New Object() {"None", "Even", "Odd", "Mark", "Space"})
            Me.cmbParity.Location = New System.Drawing.Point(280, 52)
            Me.cmbParity.Name = "cmbParity"
            Me.cmbParity.Size = New System.Drawing.Size(130, 38)
            Me.cmbParity.StartIndex = 0
            Me.cmbParity.TabIndex = 6
            '
            'lblStopBits
            '
            Me.lblStopBits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblStopBits.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblStopBits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblStopBits.Location = New System.Drawing.Point(140, 56)
            Me.lblStopBits.Name = "lblStopBits"
            Me.lblStopBits.Size = New System.Drawing.Size(120, 32)
            Me.lblStopBits.TabIndex = 7
            Me.lblStopBits.Text = "بتات التوقف:"
            Me.lblStopBits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbStopBits
            '
            Me.cmbStopBits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbStopBits.BackColor = System.Drawing.Color.Transparent
            Me.cmbStopBits.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbStopBits.BorderRadius = 8
            Me.cmbStopBits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStopBits.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.cmbStopBits.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.cmbStopBits.ForeColor = System.Drawing.Color.White
            Me.cmbStopBits.ItemHeight = 32
            Me.cmbStopBits.Items.AddRange(New Object() {"One", "Two", "OnePointFive"})
            Me.cmbStopBits.Location = New System.Drawing.Point(20, 52)
            Me.cmbStopBits.Name = "cmbStopBits"
            Me.cmbStopBits.Size = New System.Drawing.Size(110, 38)
            Me.cmbStopBits.StartIndex = 0
            Me.cmbStopBits.TabIndex = 8
            '
            'cardTest
            '
            Me.cardTest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardTest.BackColor = System.Drawing.Color.Transparent
            Me.cardTest.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardTest.BorderRadius = 12
            Me.cardTest.BorderThickness = 1
            Me.cardTest.Controls.Add(Me.lblCardTestTitle)
            Me.cardTest.Controls.Add(Me.lblScanTestHint)
            Me.cardTest.Controls.Add(Me.btnTestConnection)
            Me.cardTest.Controls.Add(Me.btnCloseConnection)
            Me.cardTest.Controls.Add(Me.txtScanTestResult)
            Me.cardTest.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardTest.Location = New System.Drawing.Point(30, 405)
            Me.cardTest.Name = "cardTest"
            Me.cardTest.Size = New System.Drawing.Size(1178, 245)
            Me.cardTest.TabIndex = 4
            '
            'lblCardTestTitle
            '
            Me.lblCardTestTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardTestTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardTestTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardTestTitle.Location = New System.Drawing.Point(850, 15)
            Me.lblCardTestTitle.Name = "lblCardTestTitle"
            Me.lblCardTestTitle.Size = New System.Drawing.Size(300, 28)
            Me.lblCardTestTitle.TabIndex = 0
            Me.lblCardTestTitle.Text = "🔬 اختبار القراءة الحيّة"
            Me.lblCardTestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblScanTestHint
            '
            Me.lblScanTestHint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblScanTestHint.Font = New System.Drawing.Font("Segoe UI", 10.5!)
            Me.lblScanTestHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblScanTestHint.Location = New System.Drawing.Point(400, 48)
            Me.lblScanTestHint.Name = "lblScanTestHint"
            Me.lblScanTestHint.Size = New System.Drawing.Size(750, 24)
            Me.lblScanTestHint.TabIndex = 1
            Me.lblScanTestHint.Text = "اضغط «اختبار الاتصال» ثم قم بمسح أي باركود لتظهر النتيجة الفورية هنا:"
            Me.lblScanTestHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnTestConnection
            '
            Me.btnTestConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnTestConnection.BorderRadius = 8
            Me.btnTestConnection.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnTestConnection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnTestConnection.ForeColor = System.Drawing.Color.White
            Me.btnTestConnection.Location = New System.Drawing.Point(990, 85)
            Me.btnTestConnection.Name = "btnTestConnection"
            Me.btnTestConnection.Size = New System.Drawing.Size(160, 42)
            Me.btnTestConnection.TabIndex = 2
            Me.btnTestConnection.Text = "🔌 اختبار الاتصال"
            '
            'btnCloseConnection
            '
            Me.btnCloseConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCloseConnection.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
            Me.btnCloseConnection.BorderRadius = 8
            Me.btnCloseConnection.BorderThickness = 1
            Me.btnCloseConnection.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.btnCloseConnection.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnCloseConnection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnCloseConnection.Location = New System.Drawing.Point(990, 140)
            Me.btnCloseConnection.Name = "btnCloseConnection"
            Me.btnCloseConnection.Size = New System.Drawing.Size(160, 42)
            Me.btnCloseConnection.TabIndex = 3
            Me.btnCloseConnection.Text = "⏹ إيقاف التجربة"
            '
            'txtScanTestResult
            '
            Me.txtScanTestResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtScanTestResult.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(33, Byte), Integer))
            Me.txtScanTestResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtScanTestResult.Font = New System.Drawing.Font("Consolas", 11.0!, System.Drawing.FontStyle.Bold)
            Me.txtScanTestResult.ForeColor = System.Drawing.Color.LightGreen
            Me.txtScanTestResult.Location = New System.Drawing.Point(30, 85)
            Me.txtScanTestResult.Multiline = True
            Me.txtScanTestResult.Name = "txtScanTestResult"
            Me.txtScanTestResult.ReadOnly = True
            Me.txtScanTestResult.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.txtScanTestResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtScanTestResult.Size = New System.Drawing.Size(935, 135)
            Me.txtScanTestResult.TabIndex = 4
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BorderRadius = 8
            Me.btnSave.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(978, 675)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(230, 48)
            Me.btnSave.TabIndex = 5
            Me.btnSave.Text = "💾 حفظ إعدادات الاسكنر"
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
            Me.btnReset.Location = New System.Drawing.Point(740, 675)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(220, 48)
            Me.btnReset.TabIndex = 6
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
            Me.btnClose.Location = New System.Drawing.Point(30, 675)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(140, 48)
            Me.btnClose.TabIndex = 7
            Me.btnClose.Text = "❌ إغلاق"
            '
            'UCScannerSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCScannerSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 760)
            Me.pnlMain.ResumeLayout(False)
            Me.cardPort.ResumeLayout(False)
            Me.cardAdvanced.ResumeLayout(False)
            Me.cardTest.ResumeLayout(False)
            Me.cardTest.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardPort As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardPortTitle As System.Windows.Forms.Label
        Friend WithEvents lblPort As System.Windows.Forms.Label
        Friend WithEvents ComboBoxPorts As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnRefreshPorts As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblEnabled As System.Windows.Forms.Label
        Friend WithEvents CheckBoxEnabled As Guna.UI2.WinForms.Guna2ToggleSwitch
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents cardAdvanced As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardAdvancedTitle As System.Windows.Forms.Label
        Friend WithEvents lblBaudRate As System.Windows.Forms.Label
        Friend WithEvents cmbBaudRate As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblDataBits As System.Windows.Forms.Label
        Friend WithEvents cmbDataBits As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblParity As System.Windows.Forms.Label
        Friend WithEvents cmbParity As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblStopBits As System.Windows.Forms.Label
        Friend WithEvents cmbStopBits As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents cardTest As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardTestTitle As System.Windows.Forms.Label
        Friend WithEvents lblScanTestHint As System.Windows.Forms.Label
        Friend WithEvents btnTestConnection As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnCloseConnection As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents txtScanTestResult As System.Windows.Forms.TextBox
        Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnReset As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    End Class
End Namespace
