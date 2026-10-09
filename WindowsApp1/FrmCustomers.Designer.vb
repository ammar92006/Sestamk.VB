<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCustomers))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.chkIsActive = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtCustomerCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnOpenStatement = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnUpdate = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.dgvCustomers = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCurrentBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIsActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.txtDiscountPercent = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbAreas = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblCurrentBalance = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAddress = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPhone2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPhone1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCredit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDebit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnIsDiscountPercent = New Guna.UI2.WinForms.Guna2Button()
        Me.panelHeader.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(103, 17)
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
        Me.btn_max.Location = New System.Drawing.Point(59, 17)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 4
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(643, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(78, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "العملاء"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1380, 70)
        Me.panelHeader.TabIndex = 45
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(15, 17)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 3
        '
        'chkIsActive
        '
        Me.chkIsActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.chkIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.chkIsActive.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkIsActive.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkIsActive.Location = New System.Drawing.Point(447, 125)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(70, 30)
        Me.chkIsActive.TabIndex = 5599
        Me.chkIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkIsActive.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkIsActive.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(523, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 30)
        Me.Label4.TabIndex = 5598
        Me.Label4.Text = "حالة الحساب"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.BorderRadius = 6
        Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotes.DefaultText = ""
        Me.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(92, 207)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(516, 36)
        Me.txtNotes.TabIndex = 5592
        Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(498, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 36)
        Me.Label6.TabIndex = 5591
        Me.Label6.Text = "ملاحظات"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1235, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 36)
        Me.Label1.TabIndex = 5583
        Me.Label1.Text = "كود العميل *"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbSearchField
        '
        Me.cmbSearchField.BackColor = System.Drawing.Color.Transparent
        Me.cmbSearchField.BorderRadius = 6
        Me.cmbSearchField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchField.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSearchField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSearchField.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbSearchField.ForeColor = System.Drawing.Color.Black
        Me.cmbSearchField.ItemHeight = 30
        Me.cmbSearchField.Location = New System.Drawing.Point(445, 45)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(172, 36)
        Me.cmbSearchField.TabIndex = 2
        Me.cmbSearchField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstSuggestions
        '
        Me.lstSuggestions.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lstSuggestions.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 17
        Me.lstSuggestions.Location = New System.Drawing.Point(4, 84)
        Me.lstSuggestions.Margin = New System.Windows.Forms.Padding(4)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.Size = New System.Drawing.Size(436, 106)
        Me.lstSuggestions.TabIndex = 37
        Me.lstSuggestions.Visible = False
        '
        'txtSearch
        '
        Me.txtSearch.BorderRadius = 6
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(4, 45)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "البحث..."
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(436, 36)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomerCode.BorderRadius = 6
        Me.txtCustomerCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomerCode.DefaultText = ""
        Me.txtCustomerCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCustomerCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCustomerCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCustomerCode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCustomerCode.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCustomerCode.Location = New System.Drawing.Point(1022, 45)
        Me.txtCustomerCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.PlaceholderText = ""
        Me.txtCustomerCode.SelectedText = ""
        Me.txtCustomerCode.Size = New System.Drawing.Size(207, 36)
        Me.txtCustomerCode.TabIndex = 3
        Me.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.Controls.Add(Me.btnOpenStatement)
        Me.Guna2Panel1.Controls.Add(Me.btnRefresh)
        Me.Guna2Panel1.Controls.Add(Me.btnClear)
        Me.Guna2Panel1.Controls.Add(Me.btnDelete)
        Me.Guna2Panel1.Controls.Add(Me.btnUpdate)
        Me.Guna2Panel1.Controls.Add(Me.btnAdd)
        Me.Guna2Panel1.Location = New System.Drawing.Point(92, 250)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1175, 55)
        Me.Guna2Panel1.TabIndex = 5600
        '
        'btnOpenStatement
        '
        Me.btnOpenStatement.BorderRadius = 6
        Me.btnOpenStatement.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnOpenStatement.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnOpenStatement.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnOpenStatement.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnOpenStatement.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnOpenStatement.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnOpenStatement.ForeColor = System.Drawing.Color.White
        Me.btnOpenStatement.Location = New System.Drawing.Point(169, 10)
        Me.btnOpenStatement.Name = "btnOpenStatement"
        Me.btnOpenStatement.Size = New System.Drawing.Size(120, 38)
        Me.btnOpenStatement.TabIndex = 5
        Me.btnOpenStatement.Text = "كشف الحساب"
        '
        'btnRefresh
        '
        Me.btnRefresh.BorderRadius = 6
        Me.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(295, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(110, 38)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "تحديث"
        '
        'btnClear
        '
        Me.btnClear.BorderRadius = 6
        Me.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(417, 10)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(120, 38)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "تفريغ الحقول"
        '
        'btnDelete
        '
        Me.btnDelete.BorderRadius = 6
        Me.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelete.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(549, 10)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(110, 38)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف"
        '
        'btnUpdate
        '
        Me.btnUpdate.BorderRadius = 6
        Me.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnUpdate.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(671, 10)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(110, 38)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "تعديل"
        '
        'btnAdd
        '
        Me.btnAdd.BorderRadius = 6
        Me.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(793, 10)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(158, 38)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "إضافة مورد جديد"
        '
        'dgvCustomers
        '
        Me.dgvCustomers.AllowUserToAddRows = False
        Me.dgvCustomers.AllowUserToDeleteRows = False
        Me.dgvCustomers.AllowUserToResizeColumns = False
        Me.dgvCustomers.AllowUserToResizeRows = False
        Me.dgvCustomers.AutoGenerateColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvCustomers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomers.BackgroundColor = System.Drawing.Color.White
        Me.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colCode, Me.colName, Me.colCurrentBalance, Me.colPhone1, Me.colPhone2, Me.colAddress, Me.colIsActive})
        Me.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCustomers.Location = New System.Drawing.Point(0, 383)
        Me.dgvCustomers.MultiSelect = False
        Me.dgvCustomers.Name = "dgvCustomers"
        Me.dgvCustomers.ReadOnly = True
        Me.dgvCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvCustomers.RowTemplate.Height = 35
        Me.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomers.Size = New System.Drawing.Size(1380, 436)
        Me.dgvCustomers.TabIndex = 47
        '
        'colID
        '
        Me.colID.DataPropertyName = "CustomerID"
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'colCode
        '
        Me.colCode.DataPropertyName = "CustomerCode"
        Me.colCode.HeaderText = "الكود"
        Me.colCode.Name = "colCode"
        Me.colCode.ReadOnly = True
        Me.colCode.Width = 80
        '
        'colName
        '
        Me.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colName.DataPropertyName = "CustomerName"
        Me.colName.HeaderText = "اسم العميل"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        '
        'colCurrentBalance
        '
        Me.colCurrentBalance.DataPropertyName = "CurrentBalance"
        Me.colCurrentBalance.HeaderText = "رصيد العميل"
        Me.colCurrentBalance.Name = "colCurrentBalance"
        Me.colCurrentBalance.ReadOnly = True
        Me.colCurrentBalance.Width = 80
        '
        'colPhone1
        '
        Me.colPhone1.DataPropertyName = "Phone1"
        Me.colPhone1.HeaderText = "رقم الموبايل"
        Me.colPhone1.Name = "colPhone1"
        Me.colPhone1.ReadOnly = True
        Me.colPhone1.Width = 110
        '
        'colPhone2
        '
        Me.colPhone2.DataPropertyName = "Phone2"
        Me.colPhone2.HeaderText = "هاتف إضافي"
        Me.colPhone2.Name = "colPhone2"
        Me.colPhone2.ReadOnly = True
        Me.colPhone2.Width = 110
        '
        'colAddress
        '
        Me.colAddress.DataPropertyName = "Address"
        Me.colAddress.HeaderText = "العنوان"
        Me.colAddress.Name = "colAddress"
        Me.colAddress.ReadOnly = True
        Me.colAddress.Width = 150
        '
        'colIsActive
        '
        Me.colIsActive.DataPropertyName = "IsActive"
        Me.colIsActive.HeaderText = "نشط"
        Me.colIsActive.Name = "colIsActive"
        Me.colIsActive.ReadOnly = True
        Me.colIsActive.Width = 60
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.btnIsDiscountPercent)
        Me.grpCustomerInfo.Controls.Add(Me.txtDebit)
        Me.grpCustomerInfo.Controls.Add(Me.Label13)
        Me.grpCustomerInfo.Controls.Add(Me.txtCredit)
        Me.grpCustomerInfo.Controls.Add(Me.Label11)
        Me.grpCustomerInfo.Controls.Add(Me.txtDiscountPercent)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.cmbAreas)
        Me.grpCustomerInfo.Controls.Add(Me.lblCurrentBalance)
        Me.grpCustomerInfo.Controls.Add(Me.Label12)
        Me.grpCustomerInfo.Controls.Add(Me.Label10)
        Me.grpCustomerInfo.Controls.Add(Me.Label9)
        Me.grpCustomerInfo.Controls.Add(Me.txtAddress)
        Me.grpCustomerInfo.Controls.Add(Me.Label8)
        Me.grpCustomerInfo.Controls.Add(Me.txtEmail)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.txtCustomerName)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.txtPhone2)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.txtPhone1)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2Panel1)
        Me.grpCustomerInfo.Controls.Add(Me.chkIsActive)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.txtNotes)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.cmbSearchField)
        Me.grpCustomerInfo.Controls.Add(Me.lstSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.txtSearch)
        Me.grpCustomerInfo.Controls.Add(Me.txtCustomerCode)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 70)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1380, 313)
        Me.grpCustomerInfo.TabIndex = 46
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscountPercent
        '
        Me.txtDiscountPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscountPercent.BorderRadius = 6
        Me.txtDiscountPercent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscountPercent.DefaultText = ""
        Me.txtDiscountPercent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDiscountPercent.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDiscountPercent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscountPercent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscountPercent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDiscountPercent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDiscountPercent.ForeColor = System.Drawing.Color.Black
        Me.txtDiscountPercent.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDiscountPercent.Location = New System.Drawing.Point(696, 165)
        Me.txtDiscountPercent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDiscountPercent.Name = "txtDiscountPercent"
        Me.txtDiscountPercent.PlaceholderText = ""
        Me.txtDiscountPercent.SelectedText = ""
        Me.txtDiscountPercent.Size = New System.Drawing.Size(207, 36)
        Me.txtDiscountPercent.TabIndex = 5645
        Me.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(906, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 36)
        Me.Label5.TabIndex = 5644
        Me.Label5.Text = "منطقة التوصيل"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbAreas
        '
        Me.cmbAreas.BackColor = System.Drawing.Color.Transparent
        Me.cmbAreas.BorderRadius = 6
        Me.cmbAreas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreas.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbAreas.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbAreas.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbAreas.ForeColor = System.Drawing.Color.Black
        Me.cmbAreas.ItemHeight = 30
        Me.cmbAreas.Location = New System.Drawing.Point(641, 45)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(262, 36)
        Me.cmbAreas.TabIndex = 5643
        Me.cmbAreas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCurrentBalance
        '
        Me.lblCurrentBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentBalance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblCurrentBalance.Location = New System.Drawing.Point(1022, 209)
        Me.lblCurrentBalance.Name = "lblCurrentBalance"
        Me.lblCurrentBalance.Size = New System.Drawing.Size(207, 36)
        Me.lblCurrentBalance.TabIndex = 5642
        Me.lblCurrentBalance.Text = "0"
        Me.lblCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(1235, 209)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 36)
        Me.Label12.TabIndex = 5641
        Me.Label12.Text = "الرصيد الحالي"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(906, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 36)
        Me.Label10.TabIndex = 5639
        Me.Label10.Text = "الخصم الافتراضي"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(904, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 36)
        Me.Label9.TabIndex = 5638
        Me.Label9.Text = "العنوان"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress.BorderRadius = 6
        Me.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAddress.DefaultText = ""
        Me.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtAddress.Location = New System.Drawing.Point(641, 125)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.PlaceholderText = ""
        Me.txtAddress.SelectedText = ""
        Me.txtAddress.Size = New System.Drawing.Size(262, 36)
        Me.txtAddress.TabIndex = 5637
        Me.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(904, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 36)
        Me.Label8.TabIndex = 5636
        Me.Label8.Text = "البريد الإلكتروني"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.BorderRadius = 6
        Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmail.DefaultText = ""
        Me.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtEmail.Location = New System.Drawing.Point(641, 85)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.PlaceholderText = ""
        Me.txtEmail.SelectedText = ""
        Me.txtEmail.Size = New System.Drawing.Size(262, 36)
        Me.txtEmail.TabIndex = 5635
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(1235, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 36)
        Me.Label7.TabIndex = 5634
        Me.Label7.Text = "اسم العميل *"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomerName.BorderRadius = 6
        Me.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomerName.DefaultText = ""
        Me.txtCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCustomerName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCustomerName.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCustomerName.Location = New System.Drawing.Point(1022, 86)
        Me.txtCustomerName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.PlaceholderText = ""
        Me.txtCustomerName.SelectedText = ""
        Me.txtCustomerName.Size = New System.Drawing.Size(207, 36)
        Me.txtCustomerName.TabIndex = 5633
        Me.txtCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1235, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 36)
        Me.Label3.TabIndex = 5632
        Me.Label3.Text = "رقم الموبايل الإضافي"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPhone2
        '
        Me.txtPhone2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPhone2.BorderRadius = 6
        Me.txtPhone2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhone2.DefaultText = ""
        Me.txtPhone2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPhone2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPhone2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPhone2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPhone2.ForeColor = System.Drawing.Color.Black
        Me.txtPhone2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPhone2.Location = New System.Drawing.Point(1022, 168)
        Me.txtPhone2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.PlaceholderText = ""
        Me.txtPhone2.SelectedText = ""
        Me.txtPhone2.Size = New System.Drawing.Size(207, 36)
        Me.txtPhone2.TabIndex = 5631
        Me.txtPhone2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1235, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 36)
        Me.Label2.TabIndex = 5630
        Me.Label2.Text = "رقم الموبايل الأساسي *"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPhone1
        '
        Me.txtPhone1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPhone1.BorderRadius = 6
        Me.txtPhone1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhone1.DefaultText = ""
        Me.txtPhone1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPhone1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPhone1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPhone1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPhone1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPhone1.ForeColor = System.Drawing.Color.Black
        Me.txtPhone1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPhone1.Location = New System.Drawing.Point(1022, 127)
        Me.txtPhone1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.PlaceholderText = ""
        Me.txtPhone1.SelectedText = ""
        Me.txtPhone1.Size = New System.Drawing.Size(207, 36)
        Me.txtPhone1.TabIndex = 5629
        Me.txtPhone1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(926, 209)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 36)
        Me.Label11.TabIndex = 5646
        Me.Label11.Text = "دائن"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCredit
        '
        Me.txtCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCredit.BorderRadius = 6
        Me.txtCredit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCredit.DefaultText = ""
        Me.txtCredit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCredit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCredit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCredit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCredit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCredit.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCredit.ForeColor = System.Drawing.Color.Black
        Me.txtCredit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCredit.Location = New System.Drawing.Point(812, 209)
        Me.txtCredit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.PlaceholderText = ""
        Me.txtCredit.SelectedText = ""
        Me.txtCredit.Size = New System.Drawing.Size(108, 36)
        Me.txtCredit.TabIndex = 5647
        Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDebit
        '
        Me.txtDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDebit.BorderRadius = 6
        Me.txtDebit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDebit.DefaultText = ""
        Me.txtDebit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDebit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDebit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDebit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDebit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDebit.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDebit.ForeColor = System.Drawing.Color.Black
        Me.txtDebit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDebit.Location = New System.Drawing.Point(643, 209)
        Me.txtDebit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.PlaceholderText = ""
        Me.txtDebit.SelectedText = ""
        Me.txtDebit.Size = New System.Drawing.Size(108, 36)
        Me.txtDebit.TabIndex = 5649
        Me.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(757, 209)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 36)
        Me.Label13.TabIndex = 5648
        Me.Label13.Text = "مدين"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnIsDiscountPercent
        '
        Me.btnIsDiscountPercent.BackColor = System.Drawing.Color.Transparent
        Me.btnIsDiscountPercent.BorderRadius = 8
        Me.btnIsDiscountPercent.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton
        Me.btnIsDiscountPercent.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnIsDiscountPercent.CheckedState.ForeColor = System.Drawing.Color.White
        Me.btnIsDiscountPercent.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnIsDiscountPercent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnIsDiscountPercent.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnIsDiscountPercent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnIsDiscountPercent.FillColor = System.Drawing.Color.Gainsboro
        Me.btnIsDiscountPercent.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnIsDiscountPercent.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.btnIsDiscountPercent.Location = New System.Drawing.Point(643, 165)
        Me.btnIsDiscountPercent.Name = "btnIsDiscountPercent"
        Me.btnIsDiscountPercent.Size = New System.Drawing.Size(48, 36)
        Me.btnIsDiscountPercent.TabIndex = 5650
        Me.btnIsDiscountPercent.Text = "%"
        '
        'FrmCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1380, 819)
        Me.Controls.Add(Me.dgvCustomers)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCustomers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkIsActive As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtCustomerCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnOpenStatement As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnUpdate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgvCustomers As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colCode As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colCurrentBalance As DataGridViewTextBoxColumn
    Friend WithEvents colPhone1 As DataGridViewTextBoxColumn
    Friend WithEvents colPhone2 As DataGridViewTextBoxColumn
    Friend WithEvents colAddress As DataGridViewTextBoxColumn
    Friend WithEvents colIsActive As DataGridViewCheckBoxColumn
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents lblCurrentBalance As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAddress As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEmail As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCustomerName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPhone2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPhone1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbAreas As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtDiscountPercent As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDebit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCredit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnIsDiscountPercent As Guna.UI2.WinForms.Guna2Button
End Class
