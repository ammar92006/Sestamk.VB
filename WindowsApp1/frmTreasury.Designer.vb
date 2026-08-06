<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTreasury
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTreasury))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnael_main = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgvTreasury = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.btnTreasuryTransactionsReport = New Guna.UI2.WinForms.Guna2Button()
        Me.btnOpenTransferForm = New Guna.UI2.WinForms.Guna2Button()
        Me.btnWithdraw = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeposit = New Guna.UI2.WinForms.Guna2Button()
        Me.txtOpeningBalance = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_clean = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel12 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtModifiedDate = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel11 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtCreatedDate = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cmbSearchBy = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtDescription = New Guna.UI2.WinForms.Guna2TextBox()
        Me.chkIsActive = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Guna2HtmlLabel8 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtCurrentBalance = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtTreasuryNameAr = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtTreasuryCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pn_nav = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnUpdate = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel1.SuspendLayout()
        Me.pnael_main.SuspendLayout()
        CType(Me.dgvTreasury, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        Me.pn_nav.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 850)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1600, 50)
        Me.Panel2.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_min)
        Me.Panel1.Controls.Add(Me.btn_max)
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1600, 75)
        Me.Panel1.TabIndex = 2
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(100, 19)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.btn_min.TabIndex = 8
        '
        'btn_max
        '
        Me.btn_max.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_max.Appearance.Options.UseFont = True
        Me.btn_max.AutoSize = True
        Me.btn_max.ImageOptions.SvgImage = CType(resources.GetObject("btn_max.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_max.Location = New System.Drawing.Point(56, 19)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 7
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(12, 19)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(724, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 54)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "الخزن"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnael_main
        '
        Me.pnael_main.Controls.Add(Me.dgvTreasury)
        Me.pnael_main.Controls.Add(Me.grpCustomerInfo)
        Me.pnael_main.Controls.Add(Me.pn_nav)
        Me.pnael_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnael_main.Location = New System.Drawing.Point(0, 75)
        Me.pnael_main.Name = "pnael_main"
        Me.pnael_main.Size = New System.Drawing.Size(1600, 775)
        Me.pnael_main.TabIndex = 4
        '
        'dgvTreasury
        '
        Me.dgvTreasury.AllowUserToAddRows = False
        Me.dgvTreasury.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvTreasury.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTreasury.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTreasury.ColumnHeadersHeight = 4
        Me.dgvTreasury.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTreasury.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTreasury.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTreasury.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTreasury.Location = New System.Drawing.Point(0, 482)
        Me.dgvTreasury.Name = "dgvTreasury"
        Me.dgvTreasury.ReadOnly = True
        Me.dgvTreasury.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvTreasury.RowHeadersVisible = False
        Me.dgvTreasury.RowTemplate.Height = 40
        Me.dgvTreasury.Size = New System.Drawing.Size(1600, 293)
        Me.dgvTreasury.TabIndex = 37
        Me.dgvTreasury.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvTreasury.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvTreasury.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvTreasury.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvTreasury.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvTreasury.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvTreasury.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTreasury.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTreasury.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvTreasury.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTreasury.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvTreasury.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvTreasury.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvTreasury.ThemeStyle.ReadOnly = True
        Me.dgvTreasury.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvTreasury.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvTreasury.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTreasury.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvTreasury.ThemeStyle.RowsStyle.Height = 40
        Me.dgvTreasury.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTreasury.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.btnTreasuryTransactionsReport)
        Me.grpCustomerInfo.Controls.Add(Me.btnOpenTransferForm)
        Me.grpCustomerInfo.Controls.Add(Me.btnWithdraw)
        Me.grpCustomerInfo.Controls.Add(Me.btnDeposit)
        Me.grpCustomerInfo.Controls.Add(Me.txtOpeningBalance)
        Me.grpCustomerInfo.Controls.Add(Me.btn_clean)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel12)
        Me.grpCustomerInfo.Controls.Add(Me.txtModifiedDate)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel11)
        Me.grpCustomerInfo.Controls.Add(Me.txtCreatedDate)
        Me.grpCustomerInfo.Controls.Add(Me.cmbSearchBy)
        Me.grpCustomerInfo.Controls.Add(Me.lstSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.txtSearch)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel9)
        Me.grpCustomerInfo.Controls.Add(Me.txtDescription)
        Me.grpCustomerInfo.Controls.Add(Me.chkIsActive)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel8)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel7)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel6)
        Me.grpCustomerInfo.Controls.Add(Me.txtCurrentBalance)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel3)
        Me.grpCustomerInfo.Controls.Add(Me.txtTreasuryNameAr)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel2)
        Me.grpCustomerInfo.Controls.Add(Me.txtTreasuryCode)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 72)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1600, 410)
        Me.grpCustomerInfo.TabIndex = 2
        Me.grpCustomerInfo.Text = "بيانات الخزنة"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTreasuryTransactionsReport
        '
        Me.btnTreasuryTransactionsReport.BorderRadius = 10
        Me.btnTreasuryTransactionsReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTreasuryTransactionsReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTreasuryTransactionsReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTreasuryTransactionsReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnTreasuryTransactionsReport.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTreasuryTransactionsReport.ForeColor = System.Drawing.Color.White
        Me.btnTreasuryTransactionsReport.Image = Global.WindowsApp1.My.Resources.Resources.delete__1_
        Me.btnTreasuryTransactionsReport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnTreasuryTransactionsReport.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnTreasuryTransactionsReport.Location = New System.Drawing.Point(590, 339)
        Me.btnTreasuryTransactionsReport.Name = "btnTreasuryTransactionsReport"
        Me.btnTreasuryTransactionsReport.Size = New System.Drawing.Size(239, 58)
        Me.btnTreasuryTransactionsReport.TabIndex = 58
        Me.btnTreasuryTransactionsReport.Text = "حركات الخزن"
        Me.btnTreasuryTransactionsReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnOpenTransferForm
        '
        Me.btnOpenTransferForm.BorderRadius = 10
        Me.btnOpenTransferForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnOpenTransferForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnOpenTransferForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnOpenTransferForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnOpenTransferForm.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenTransferForm.ForeColor = System.Drawing.Color.White
        Me.btnOpenTransferForm.Image = Global.WindowsApp1.My.Resources.Resources.exchange
        Me.btnOpenTransferForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnOpenTransferForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnOpenTransferForm.Location = New System.Drawing.Point(590, 265)
        Me.btnOpenTransferForm.Name = "btnOpenTransferForm"
        Me.btnOpenTransferForm.Size = New System.Drawing.Size(239, 58)
        Me.btnOpenTransferForm.TabIndex = 57
        Me.btnOpenTransferForm.Text = "تحويل بين الخزن"
        Me.btnOpenTransferForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnWithdraw
        '
        Me.btnWithdraw.BorderRadius = 10
        Me.btnWithdraw.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnWithdraw.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnWithdraw.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnWithdraw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnWithdraw.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWithdraw.ForeColor = System.Drawing.Color.White
        Me.btnWithdraw.Image = Global.WindowsApp1.My.Resources.Resources.deposit__1_
        Me.btnWithdraw.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnWithdraw.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnWithdraw.Location = New System.Drawing.Point(590, 191)
        Me.btnWithdraw.Name = "btnWithdraw"
        Me.btnWithdraw.Size = New System.Drawing.Size(239, 58)
        Me.btnWithdraw.TabIndex = 56
        Me.btnWithdraw.Text = "سحب"
        Me.btnWithdraw.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnDeposit
        '
        Me.btnDeposit.BorderRadius = 10
        Me.btnDeposit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeposit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeposit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeposit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeposit.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeposit.ForeColor = System.Drawing.Color.White
        Me.btnDeposit.Image = Global.WindowsApp1.My.Resources.Resources.deposit
        Me.btnDeposit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnDeposit.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDeposit.Location = New System.Drawing.Point(590, 117)
        Me.btnDeposit.Name = "btnDeposit"
        Me.btnDeposit.Size = New System.Drawing.Size(239, 58)
        Me.btnDeposit.TabIndex = 55
        Me.btnDeposit.Text = "ايداع"
        Me.btnDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'txtOpeningBalance
        '
        Me.txtOpeningBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpeningBalance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOpeningBalance.DefaultText = ""
        Me.txtOpeningBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtOpeningBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtOpeningBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOpeningBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOpeningBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOpeningBalance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
        Me.txtOpeningBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOpeningBalance.Location = New System.Drawing.Point(838, 93)
        Me.txtOpeningBalance.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtOpeningBalance.Name = "txtOpeningBalance"
        Me.txtOpeningBalance.PlaceholderText = ""
        Me.txtOpeningBalance.SelectedText = ""
        Me.txtOpeningBalance.Size = New System.Drawing.Size(316, 45)
        Me.txtOpeningBalance.TabIndex = 54
        Me.txtOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_clean
        '
        Me.btn_clean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_clean.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clean.Appearance.Options.UseFont = True
        Me.btn_clean.AutoSize = True
        Me.btn_clean.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.eraser
        Me.btn_clean.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_clean.Location = New System.Drawing.Point(1375, 3)
        Me.btn_clean.Name = "btn_clean"
        Me.btn_clean.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_clean.Size = New System.Drawing.Size(38, 36)
        Me.btn_clean.TabIndex = 44
        '
        'Guna2HtmlLabel12
        '
        Me.Guna2HtmlLabel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel12.AutoSize = False
        Me.Guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel12.Location = New System.Drawing.Point(82, 315)
        Me.Guna2HtmlLabel12.Name = "Guna2HtmlLabel12"
        Me.Guna2HtmlLabel12.Size = New System.Drawing.Size(206, 36)
        Me.Guna2HtmlLabel12.TabIndex = 41
        Me.Guna2HtmlLabel12.Text = "تعديل اخر تاريخ"
        Me.Guna2HtmlLabel12.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModifiedDate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtModifiedDate.DefaultText = ""
        Me.txtModifiedDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtModifiedDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtModifiedDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtModifiedDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtModifiedDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtModifiedDate.Location = New System.Drawing.Point(6, 356)
        Me.txtModifiedDate.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.PlaceholderText = ""
        Me.txtModifiedDate.ReadOnly = True
        Me.txtModifiedDate.SelectedText = ""
        Me.txtModifiedDate.Size = New System.Drawing.Size(282, 45)
        Me.txtModifiedDate.TabIndex = 40
        Me.txtModifiedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel11
        '
        Me.Guna2HtmlLabel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel11.AutoSize = False
        Me.Guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel11.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel11.Location = New System.Drawing.Point(353, 315)
        Me.Guna2HtmlLabel11.Name = "Guna2HtmlLabel11"
        Me.Guna2HtmlLabel11.Size = New System.Drawing.Size(229, 36)
        Me.Guna2HtmlLabel11.TabIndex = 39
        Me.Guna2HtmlLabel11.Text = "الاضافة تاريخ"
        Me.Guna2HtmlLabel11.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreatedDate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCreatedDate.DefaultText = ""
        Me.txtCreatedDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCreatedDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCreatedDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCreatedDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCreatedDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCreatedDate.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCreatedDate.Location = New System.Drawing.Point(300, 356)
        Me.txtCreatedDate.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.PlaceholderText = ""
        Me.txtCreatedDate.ReadOnly = True
        Me.txtCreatedDate.SelectedText = ""
        Me.txtCreatedDate.Size = New System.Drawing.Size(282, 45)
        Me.txtCreatedDate.TabIndex = 38
        Me.txtCreatedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.cmbSearchBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchBy.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSearchBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSearchBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbSearchBy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbSearchBy.ItemHeight = 42
        Me.cmbSearchBy.Location = New System.Drawing.Point(590, 48)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(227, 48)
        Me.cmbSearchBy.TabIndex = 2
        Me.cmbSearchBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstSuggestions
        '
        Me.lstSuggestions.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lstSuggestions.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 25
        Me.lstSuggestions.Location = New System.Drawing.Point(5, 100)
        Me.lstSuggestions.Margin = New System.Windows.Forms.Padding(5)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.Size = New System.Drawing.Size(577, 204)
        Me.lstSuggestions.TabIndex = 37
        '
        'txtSearch
        '
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(5, 48)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "ابحث عن خزنة"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(577, 49)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel9.AutoSize = False
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(944, 245)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(210, 36)
        Me.Guna2HtmlLabel9.TabIndex = 33
        Me.Guna2HtmlLabel9.Text = "الوصف"
        Me.Guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescription.DefaultText = ""
        Me.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDescription.Location = New System.Drawing.Point(838, 285)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.PlaceholderText = ""
        Me.txtDescription.SelectedText = ""
        Me.txtDescription.Size = New System.Drawing.Size(316, 113)
        Me.txtDescription.TabIndex = 10
        '
        'chkIsActive
        '
        Me.chkIsActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkIsActive.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkIsActive.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkIsActive.Location = New System.Drawing.Point(1160, 285)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(93, 44)
        Me.chkIsActive.TabIndex = 9
        Me.chkIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkIsActive.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkIsActive.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Guna2HtmlLabel8
        '
        Me.Guna2HtmlLabel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel8.AutoSize = False
        Me.Guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel8.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel8.Location = New System.Drawing.Point(1401, 285)
        Me.Guna2HtmlLabel8.Name = "Guna2HtmlLabel8"
        Me.Guna2HtmlLabel8.Size = New System.Drawing.Size(172, 42)
        Me.Guna2HtmlLabel8.TabIndex = 30
        Me.Guna2HtmlLabel8.Text = "الحالة"
        Me.Guna2HtmlLabel8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'Guna2HtmlLabel7
        '
        Me.Guna2HtmlLabel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel7.AutoSize = False
        Me.Guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel7.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel7.Location = New System.Drawing.Point(944, 52)
        Me.Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Me.Guna2HtmlLabel7.Size = New System.Drawing.Size(210, 36)
        Me.Guna2HtmlLabel7.TabIndex = 29
        Me.Guna2HtmlLabel7.Text = "الافتتاحي الرصيد"
        Me.Guna2HtmlLabel7.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel6.AutoSize = False
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(944, 145)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(210, 36)
        Me.Guna2HtmlLabel6.TabIndex = 28
        Me.Guna2HtmlLabel6.Text = "الحالي الرصيد"
        Me.Guna2HtmlLabel6.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtCurrentBalance
        '
        Me.txtCurrentBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrentBalance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCurrentBalance.DefaultText = ""
        Me.txtCurrentBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCurrentBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCurrentBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCurrentBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCurrentBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCurrentBalance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentBalance.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCurrentBalance.Location = New System.Drawing.Point(838, 186)
        Me.txtCurrentBalance.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCurrentBalance.Name = "txtCurrentBalance"
        Me.txtCurrentBalance.PlaceholderText = ""
        Me.txtCurrentBalance.SelectedText = ""
        Me.txtCurrentBalance.Size = New System.Drawing.Size(316, 45)
        Me.txtCurrentBalance.TabIndex = 8
        Me.txtCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel3.AutoSize = False
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(1368, 145)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(206, 36)
        Me.Guna2HtmlLabel3.TabIndex = 21
        Me.Guna2HtmlLabel3.Text = "الخزنة اسم"
        Me.Guna2HtmlLabel3.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtTreasuryNameAr
        '
        Me.txtTreasuryNameAr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTreasuryNameAr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTreasuryNameAr.DefaultText = ""
        Me.txtTreasuryNameAr.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTreasuryNameAr.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTreasuryNameAr.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTreasuryNameAr.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTreasuryNameAr.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTreasuryNameAr.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtTreasuryNameAr.ForeColor = System.Drawing.Color.Black
        Me.txtTreasuryNameAr.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTreasuryNameAr.Location = New System.Drawing.Point(1160, 186)
        Me.txtTreasuryNameAr.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTreasuryNameAr.Name = "txtTreasuryNameAr"
        Me.txtTreasuryNameAr.PlaceholderText = ""
        Me.txtTreasuryNameAr.SelectedText = ""
        Me.txtTreasuryNameAr.Size = New System.Drawing.Size(414, 45)
        Me.txtTreasuryNameAr.TabIndex = 4
        Me.txtTreasuryNameAr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel2.AutoSize = False
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(1368, 52)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(206, 36)
        Me.Guna2HtmlLabel2.TabIndex = 19
        Me.Guna2HtmlLabel2.Text = "الخزنة كود"
        Me.Guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtTreasuryCode
        '
        Me.txtTreasuryCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTreasuryCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTreasuryCode.DefaultText = ""
        Me.txtTreasuryCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTreasuryCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTreasuryCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTreasuryCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTreasuryCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTreasuryCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtTreasuryCode.ForeColor = System.Drawing.Color.Black
        Me.txtTreasuryCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTreasuryCode.Location = New System.Drawing.Point(1160, 93)
        Me.txtTreasuryCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTreasuryCode.Name = "txtTreasuryCode"
        Me.txtTreasuryCode.PlaceholderText = ""
        Me.txtTreasuryCode.SelectedText = ""
        Me.txtTreasuryCode.Size = New System.Drawing.Size(414, 45)
        Me.txtTreasuryCode.TabIndex = 3
        Me.txtTreasuryCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pn_nav
        '
        Me.pn_nav.Controls.Add(Me.btnRefresh)
        Me.pn_nav.Controls.Add(Me.btnClear)
        Me.pn_nav.Controls.Add(Me.btnDelete)
        Me.pn_nav.Controls.Add(Me.btnUpdate)
        Me.pn_nav.Controls.Add(Me.btnAdd)
        Me.pn_nav.Dock = System.Windows.Forms.DockStyle.Top
        Me.pn_nav.Location = New System.Drawing.Point(0, 0)
        Me.pn_nav.Name = "pn_nav"
        Me.pn_nav.Size = New System.Drawing.Size(1600, 72)
        Me.pn_nav.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.BorderRadius = 10
        Me.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnRefresh.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Image = Global.WindowsApp1.My.Resources.Resources.loading_arrow1
        Me.btnRefresh.ImageOffset = New System.Drawing.Point(-15, 0)
        Me.btnRefresh.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnRefresh.Location = New System.Drawing.Point(24, 7)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(225, 58)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "تحديث"
        '
        'btnClear
        '
        Me.btnClear.BorderRadius = 10
        Me.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Image = Global.WindowsApp1.My.Resources.Resources.cleaning
        Me.btnClear.ImageOffset = New System.Drawing.Point(-15, 0)
        Me.btnClear.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClear.Location = New System.Drawing.Point(355, 7)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(225, 58)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "تفريغ"
        '
        'btnDelete
        '
        Me.btnDelete.BorderRadius = 10
        Me.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Image = Global.WindowsApp1.My.Resources.Resources.delete__1_
        Me.btnDelete.ImageOffset = New System.Drawing.Point(-15, 0)
        Me.btnDelete.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDelete.Location = New System.Drawing.Point(686, 7)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(225, 58)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف"
        '
        'btnUpdate
        '
        Me.btnUpdate.BorderRadius = 10
        Me.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Image = Global.WindowsApp1.My.Resources.Resources.edit
        Me.btnUpdate.ImageOffset = New System.Drawing.Point(-15, 0)
        Me.btnUpdate.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnUpdate.Location = New System.Drawing.Point(1017, 7)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(225, 58)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "تعديل"
        '
        'btnAdd
        '
        Me.btnAdd.BorderRadius = 10
        Me.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Image = Global.WindowsApp1.My.Resources.Resources.add__2_
        Me.btnAdd.ImageOffset = New System.Drawing.Point(-15, 0)
        Me.btnAdd.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAdd.Location = New System.Drawing.Point(1348, 7)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(225, 58)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "اضافة"
        '
        'frmTreasury
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1600, 900)
        Me.Controls.Add(Me.pnael_main)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTreasury"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTreasury"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnael_main.ResumeLayout(False)
        CType(Me.dgvTreasury, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        Me.pn_nav.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents pnael_main As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pn_nav As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnUpdate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents btn_clean As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel12 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtModifiedDate As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel11 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtCreatedDate As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cmbSearchBy As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtDescription As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents chkIsActive As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Guna2HtmlLabel8 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtCurrentBalance As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtTreasuryNameAr As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtTreasuryCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvTreasury As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents txtOpeningBalance As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnTreasuryTransactionsReport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnOpenTransferForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnWithdraw As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeposit As Guna.UI2.WinForms.Guna2Button
End Class
