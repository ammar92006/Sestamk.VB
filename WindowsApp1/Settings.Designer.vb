<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.public_set = New Guna.UI2.WinForms.Guna2TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRefreshPorts = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCloseConnection = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTestConnection = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSavebarcode = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckBoxEnabled = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.ComboBoxPorts = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelDeveloper = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.public_set.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.pn_title_page)
        Me.pnlHeader.Controls.Add(Me.btn_min)
        Me.pnlHeader.Controls.Add(Me.btn_max)
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1500, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'pn_title_page
        '
        Me.pn_title_page.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pn_title_page.AutoSize = True
        Me.pn_title_page.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pn_title_page.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.pn_title_page.Location = New System.Drawing.Point(672, 9)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(156, 46)
        Me.pn_title_page.TabIndex = 6
        Me.pn_title_page.Text = "الاعدادات"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(99, 18)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.btn_min.TabIndex = 5
        '
        'btn_max
        '
        Me.btn_max.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_max.Appearance.Options.UseFont = True
        Me.btn_max.AutoSize = True
        Me.btn_max.ImageOptions.SvgImage = CType(resources.GetObject("btn_max.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_max.Location = New System.Drawing.Point(55, 18)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 4
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.AutoSize = True
        Me.btnClose.ImageOptions.SvgImage = CType(resources.GetObject("btnClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnClose.Location = New System.Drawing.Point(11, 18)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnClose.Size = New System.Drawing.Size(38, 36)
        Me.btnClose.TabIndex = 3
        '
        'public_set
        '
        Me.public_set.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.public_set.Controls.Add(Me.TabPage1)
        Me.public_set.Controls.Add(Me.TabPage2)
        Me.public_set.Controls.Add(Me.TabPage4)
        Me.public_set.Controls.Add(Me.TabPage3)
        Me.public_set.Dock = System.Windows.Forms.DockStyle.Fill
        Me.public_set.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.public_set.ItemSize = New System.Drawing.Size(220, 65)
        Me.public_set.Location = New System.Drawing.Point(0, 70)
        Me.public_set.Name = "public_set"
        Me.public_set.SelectedIndex = 0
        Me.public_set.ShowToolTips = True
        Me.public_set.Size = New System.Drawing.Size(1500, 730)
        Me.public_set.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty
        Me.public_set.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.public_set.TabButtonHoverState.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!)
        Me.public_set.TabButtonHoverState.ForeColor = System.Drawing.Color.White
        Me.public_set.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.public_set.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty
        Me.public_set.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.public_set.TabButtonIdleState.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!)
        Me.public_set.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.public_set.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.public_set.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty
        Me.public_set.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.public_set.TabButtonSelectedState.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!)
        Me.public_set.TabButtonSelectedState.ForeColor = System.Drawing.Color.White
        Me.public_set.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.public_set.TabButtonSize = New System.Drawing.Size(220, 65)
        Me.public_set.TabIndex = 1
        Me.public_set.TabMenuBackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.public_set.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.VerticalRight
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1272, 722)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "الاعدادات العامه"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1272, 722)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "قاعدة البيانات"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.lblStatus)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.btnRefreshPorts)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.btnCloseConnection)
        Me.TabPage3.Controls.Add(Me.btnTestConnection)
        Me.TabPage3.Controls.Add(Me.btnSavebarcode)
        Me.TabPage3.Controls.Add(Me.CheckBoxEnabled)
        Me.TabPage3.Controls.Add(Me.ComboBoxPorts)
        Me.TabPage3.Location = New System.Drawing.Point(4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1272, 722)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "scanner barcode"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.TabPage4.Location = New System.Drawing.Point(4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1272, 722)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "طابعة الباركود"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(668, 270)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(399, 45)
        Me.lblStatus.TabIndex = 17
        Me.lblStatus.Text = "حالة Scanner"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1002, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 39)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "حالة Scanner"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRefreshPorts
        '
        Me.btnRefreshPorts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshPorts.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshPorts.Appearance.Options.UseFont = True
        Me.btnRefreshPorts.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.software_testing
        Me.btnRefreshPorts.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnRefreshPorts.Location = New System.Drawing.Point(588, 64)
        Me.btnRefreshPorts.Name = "btnRefreshPorts"
        Me.btnRefreshPorts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnRefreshPorts.Size = New System.Drawing.Size(322, 79)
        Me.btnRefreshPorts.TabIndex = 15
        Me.btnRefreshPorts.Text = "تحديث المنافذ"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(930, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 39)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "اختيار المنفذ (Port)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCloseConnection
        '
        Me.btnCloseConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCloseConnection.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseConnection.Appearance.Options.UseFont = True
        Me.btnCloseConnection.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.software_testing
        Me.btnCloseConnection.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnCloseConnection.Location = New System.Drawing.Point(236, 626)
        Me.btnCloseConnection.Name = "btnCloseConnection"
        Me.btnCloseConnection.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnCloseConnection.Size = New System.Drawing.Size(326, 75)
        Me.btnCloseConnection.TabIndex = 13
        Me.btnCloseConnection.Text = "غلق الباركود"
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTestConnection.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestConnection.Appearance.Options.UseFont = True
        Me.btnTestConnection.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.software_testing
        Me.btnTestConnection.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnTestConnection.Location = New System.Drawing.Point(568, 626)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnTestConnection.Size = New System.Drawing.Size(326, 75)
        Me.btnTestConnection.TabIndex = 12
        Me.btnTestConnection.Text = "اختبار الاتصال"
        '
        'btnSavebarcode
        '
        Me.btnSavebarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavebarcode.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavebarcode.Appearance.Options.UseFont = True
        Me.btnSavebarcode.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.file
        Me.btnSavebarcode.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnSavebarcode.Location = New System.Drawing.Point(900, 626)
        Me.btnSavebarcode.Name = "btnSavebarcode"
        Me.btnSavebarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSavebarcode.Size = New System.Drawing.Size(245, 75)
        Me.btnSavebarcode.TabIndex = 11
        Me.btnSavebarcode.Text = "حفظ"
        '
        'CheckBoxEnabled
        '
        Me.CheckBoxEnabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxEnabled.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CheckBoxEnabled.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CheckBoxEnabled.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.CheckBoxEnabled.CheckedState.InnerColor = System.Drawing.Color.White
        Me.CheckBoxEnabled.Location = New System.Drawing.Point(1109, 271)
        Me.CheckBoxEnabled.Name = "CheckBoxEnabled"
        Me.CheckBoxEnabled.Size = New System.Drawing.Size(93, 44)
        Me.CheckBoxEnabled.TabIndex = 10
        Me.CheckBoxEnabled.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.CheckBoxEnabled.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.CheckBoxEnabled.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.CheckBoxEnabled.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'ComboBoxPorts
        '
        Me.ComboBoxPorts.BackColor = System.Drawing.Color.Transparent
        Me.ComboBoxPorts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPorts.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxPorts.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxPorts.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.ComboBoxPorts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.ComboBoxPorts.ItemHeight = 30
        Me.ComboBoxPorts.Location = New System.Drawing.Point(916, 86)
        Me.ComboBoxPorts.Name = "ComboBoxPorts"
        Me.ComboBoxPorts.Size = New System.Drawing.Size(322, 36)
        Me.ComboBoxPorts.TabIndex = 0
        Me.ComboBoxPorts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelDeveloper)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 800)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1500, 50)
        Me.Panel2.TabIndex = 2
        '
        'LabelDeveloper
        '
        Me.LabelDeveloper.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelDeveloper.AutoSize = True
        Me.LabelDeveloper.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.LabelDeveloper.Location = New System.Drawing.Point(433, 3)
        Me.LabelDeveloper.Name = "LabelDeveloper"
        Me.LabelDeveloper.Size = New System.Drawing.Size(529, 39)
        Me.LabelDeveloper.TabIndex = 1
        Me.LabelDeveloper.Text = "تم تصميم هذا البرنامج بواسطة عمار احمد"
        Me.LabelDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1500, 850)
        Me.Controls.Add(Me.public_set)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.public_set.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents public_set As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ComboBoxPorts As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pn_title_page As Label
    Friend WithEvents CheckBoxEnabled As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents btnSavebarcode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTestConnection As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCloseConnection As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelDeveloper As Label
    Friend WithEvents btnRefreshPorts As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label2 As Label
End Class
