<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTreasuryTransactionsReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTreasuryTransactionsReport))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTotalWithdrawals = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalDeposits = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lbltitle = New System.Windows.Forms.Label()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.cmbUserFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvTransactions = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpTo = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFrom = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.cmbTypeFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTreasuryFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Guna2Panel1.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.lblTotalWithdrawals)
        Me.Guna2Panel1.Controls.Add(Me.Label8)
        Me.Guna2Panel1.Controls.Add(Me.lblTotalDeposits)
        Me.Guna2Panel1.Controls.Add(Me.Label5)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 886)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Guna2Panel1.Size = New System.Drawing.Size(1282, 64)
        Me.Guna2Panel1.TabIndex = 5644
        '
        'lblTotalWithdrawals
        '
        Me.lblTotalWithdrawals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalWithdrawals.BackColor = System.Drawing.Color.DimGray
        Me.lblTotalWithdrawals.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalWithdrawals.ForeColor = System.Drawing.Color.White
        Me.lblTotalWithdrawals.Location = New System.Drawing.Point(119, 9)
        Me.lblTotalWithdrawals.Name = "lblTotalWithdrawals"
        Me.lblTotalWithdrawals.Size = New System.Drawing.Size(268, 46)
        Me.lblTotalWithdrawals.TabIndex = 5651
        Me.lblTotalWithdrawals.Text = "إجمالي الإيداعات"
        Me.lblTotalWithdrawals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(393, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(268, 46)
        Me.Label8.TabIndex = 5650
        Me.Label8.Text = "إجمالي السحوبات"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalDeposits
        '
        Me.lblTotalDeposits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalDeposits.BackColor = System.Drawing.Color.DimGray
        Me.lblTotalDeposits.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDeposits.ForeColor = System.Drawing.Color.White
        Me.lblTotalDeposits.Location = New System.Drawing.Point(672, 9)
        Me.lblTotalDeposits.Name = "lblTotalDeposits"
        Me.lblTotalDeposits.Size = New System.Drawing.Size(268, 46)
        Me.lblTotalDeposits.TabIndex = 5649
        Me.lblTotalDeposits.Text = "إجمالي الإيداعات"
        Me.lblTotalDeposits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(946, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(268, 46)
        Me.Label5.TabIndex = 5648
        Me.Label5.Text = "إجمالي الإيداعات"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lbltitle)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1282, 70)
        Me.panelHeader.TabIndex = 5643
        '
        'lbltitle
        '
        Me.lbltitle.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitle.ForeColor = System.Drawing.Color.White
        Me.lbltitle.Location = New System.Drawing.Point(522, 9)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Size = New System.Drawing.Size(313, 42)
        Me.lbltitle.TabIndex = 6
        Me.lbltitle.Text = "حركات الخزن"
        Me.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.cmbUserFilter)
        Me.Guna2Panel2.Controls.Add(Me.Label6)
        Me.Guna2Panel2.Controls.Add(Me.dgvTransactions)
        Me.Guna2Panel2.Controls.Add(Me.btnReset)
        Me.Guna2Panel2.Controls.Add(Me.btnSearch)
        Me.Guna2Panel2.Controls.Add(Me.txtSearch)
        Me.Guna2Panel2.Controls.Add(Me.Label2)
        Me.Guna2Panel2.Controls.Add(Me.dtpTo)
        Me.Guna2Panel2.Controls.Add(Me.Label3)
        Me.Guna2Panel2.Controls.Add(Me.dtpFrom)
        Me.Guna2Panel2.Controls.Add(Me.cmbTypeFilter)
        Me.Guna2Panel2.Controls.Add(Me.Label1)
        Me.Guna2Panel2.Controls.Add(Me.cmbTreasuryFilter)
        Me.Guna2Panel2.Controls.Add(Me.Label4)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 70)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1282, 816)
        Me.Guna2Panel2.TabIndex = 5645
        '
        'cmbUserFilter
        '
        Me.cmbUserFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUserFilter.BackColor = System.Drawing.Color.Transparent
        Me.cmbUserFilter.BorderRadius = 8
        Me.cmbUserFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUserFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserFilter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbUserFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbUserFilter.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbUserFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbUserFilter.ItemHeight = 40
        Me.cmbUserFilter.Location = New System.Drawing.Point(972, 134)
        Me.cmbUserFilter.Name = "cmbUserFilter"
        Me.cmbUserFilter.Size = New System.Drawing.Size(285, 46)
        Me.cmbUserFilter.TabIndex = 5658
        Me.cmbUserFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1103, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 39)
        Me.Label6.TabIndex = 5657
        Me.Label6.Text = "المستخدم"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvTransactions
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransactions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTransactions.ColumnHeadersHeight = 4
        Me.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTransactions.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvTransactions.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransactions.Location = New System.Drawing.Point(0, 188)
        Me.dgvTransactions.Name = "dgvTransactions"
        Me.dgvTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvTransactions.RowHeadersVisible = False
        Me.dgvTransactions.Size = New System.Drawing.Size(1282, 628)
        Me.dgvTransactions.TabIndex = 5656
        Me.dgvTransactions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvTransactions.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvTransactions.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvTransactions.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvTransactions.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransactions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransactions.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvTransactions.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTransactions.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvTransactions.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvTransactions.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvTransactions.ThemeStyle.ReadOnly = False
        Me.dgvTransactions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvTransactions.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvTransactions.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTransactions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvTransactions.ThemeStyle.RowsStyle.Height = 22
        Me.dgvTransactions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransactions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'btnReset
        '
        Me.btnReset.Image = Global.WindowsApp1.My.Resources.Resources.loading_arrow
        Me.btnReset.Location = New System.Drawing.Point(119, 134)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(101, 49)
        Me.btnReset.TabIndex = 5655
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.WindowsApp1.My.Resources.Resources.search1
        Me.btnSearch.Location = New System.Drawing.Point(232, 133)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(101, 49)
        Me.btnSearch.TabIndex = 5654
        Me.btnSearch.UseVisualStyleBackColor = True
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
        Me.txtSearch.Location = New System.Drawing.Point(357, 133)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "ابحث عن خزنة"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(606, 49)
        Me.txtSearch.TabIndex = 5653
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(201, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 36)
        Me.Label2.TabIndex = 5652
        Me.Label2.Text = "التاريخ الي"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpTo
        '
        Me.dtpTo.BorderColor = System.Drawing.Color.Gray
        Me.dtpTo.BorderRadius = 8
        Me.dtpTo.BorderThickness = 3
        Me.dtpTo.Checked = True
        Me.dtpTo.FillColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(81, 45)
        Me.dtpTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(280, 46)
        Me.dtpTo.TabIndex = 5651
        Me.dtpTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dtpTo.Value = New Date(2026, 7, 11, 21, 31, 26, 773)
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(496, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 36)
        Me.Label3.TabIndex = 5650
        Me.Label3.Text = "التاريخ من"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrom
        '
        Me.dtpFrom.BorderColor = System.Drawing.Color.Gray
        Me.dtpFrom.BorderRadius = 8
        Me.dtpFrom.BorderThickness = 3
        Me.dtpFrom.Checked = True
        Me.dtpFrom.FillColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(376, 45)
        Me.dtpFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(280, 46)
        Me.dtpFrom.TabIndex = 5649
        Me.dtpFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dtpFrom.Value = New Date(2026, 7, 11, 21, 31, 26, 773)
        '
        'cmbTypeFilter
        '
        Me.cmbTypeFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTypeFilter.BackColor = System.Drawing.Color.Transparent
        Me.cmbTypeFilter.BorderRadius = 8
        Me.cmbTypeFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeFilter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTypeFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTypeFilter.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTypeFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbTypeFilter.ItemHeight = 40
        Me.cmbTypeFilter.Location = New System.Drawing.Point(683, 45)
        Me.cmbTypeFilter.Name = "cmbTypeFilter"
        Me.cmbTypeFilter.Size = New System.Drawing.Size(280, 46)
        Me.cmbTypeFilter.TabIndex = 5648
        Me.cmbTypeFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(806, -4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 46)
        Me.Label1.TabIndex = 5647
        Me.Label1.Text = "نوع الحركة"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTreasuryFilter
        '
        Me.cmbTreasuryFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTreasuryFilter.BackColor = System.Drawing.Color.Transparent
        Me.cmbTreasuryFilter.BorderRadius = 8
        Me.cmbTreasuryFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTreasuryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTreasuryFilter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasuryFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasuryFilter.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTreasuryFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbTreasuryFilter.ItemHeight = 40
        Me.cmbTreasuryFilter.Location = New System.Drawing.Point(979, 45)
        Me.cmbTreasuryFilter.Name = "cmbTreasuryFilter"
        Me.cmbTreasuryFilter.Size = New System.Drawing.Size(275, 46)
        Me.cmbTreasuryFilter.TabIndex = 5646
        Me.cmbTreasuryFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1147, -4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 46)
        Me.Label4.TabIndex = 5645
        Me.Label4.Text = "الخزنة"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmTreasuryTransactionsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 950)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTreasuryTransactionsReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Guna2Panel1.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Guna2Panel2.ResumeLayout(False)
        CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lbltitle As Label
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Public WithEvents cmbTypeFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label1 As Label
    Public WithEvents cmbTreasuryFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpTo As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFrom As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents btnReset As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblTotalWithdrawals As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTotalDeposits As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvTransactions As Guna.UI2.WinForms.Guna2DataGridView
    Public WithEvents cmbUserFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label6 As Label
End Class
