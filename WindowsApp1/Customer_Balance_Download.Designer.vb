<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Customer_Balance_Download
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Customer_Balance_Download))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.Guna2HtmlLabel13 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtDebit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel10 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtCredit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtBalance = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dgvCustomers = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtAmountPaid = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtCustomerName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtCustomerCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.nudCreditLimit = New System.Windows.Forms.NumericUpDown()
        Me.cmbSearchField = New System.Windows.Forms.ComboBox()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.btnDoPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCreditLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_min)
        Me.Panel1.Controls.Add(Me.btn_max)
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.pn_title_page)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1492, 69)
        Me.Panel1.TabIndex = 0
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(99, 12)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.btn_min.TabIndex = 7
        '
        'btn_max
        '
        Me.btn_max.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_max.Appearance.Options.UseFont = True
        Me.btn_max.AutoSize = True
        Me.btn_max.ImageOptions.SvgImage = CType(resources.GetObject("btn_max.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_max.Location = New System.Drawing.Point(55, 12)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 6
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(11, 12)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 5
        '
        'pn_title_page
        '
        Me.pn_title_page.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pn_title_page.AutoSize = True
        Me.pn_title_page.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pn_title_page.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.pn_title_page.Location = New System.Drawing.Point(678, 8)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(271, 46)
        Me.pn_title_page.TabIndex = 4
        Me.pn_title_page.Text = "تنزيل رصيد عميل"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2HtmlLabel13
        '
        Me.Guna2HtmlLabel13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel13.AutoSize = False
        Me.Guna2HtmlLabel13.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel13.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel13.Location = New System.Drawing.Point(774, 187)
        Me.Guna2HtmlLabel13.Name = "Guna2HtmlLabel13"
        Me.Guna2HtmlLabel13.Size = New System.Drawing.Size(157, 36)
        Me.Guna2HtmlLabel13.TabIndex = 54
        Me.Guna2HtmlLabel13.Text = "مديون"
        Me.Guna2HtmlLabel13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDebit
        '
        Me.txtDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDebit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDebit.DefaultText = ""
        Me.txtDebit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDebit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDebit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDebit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDebit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDebit.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtDebit.ForeColor = System.Drawing.Color.Black
        Me.txtDebit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDebit.Location = New System.Drawing.Point(774, 232)
        Me.txtDebit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.PlaceholderText = ""
        Me.txtDebit.SelectedText = ""
        Me.txtDebit.Size = New System.Drawing.Size(157, 45)
        Me.txtDebit.TabIndex = 53
        Me.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel10
        '
        Me.Guna2HtmlLabel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel10.AutoSize = False
        Me.Guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel10.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel10.Location = New System.Drawing.Point(612, 187)
        Me.Guna2HtmlLabel10.Name = "Guna2HtmlLabel10"
        Me.Guna2HtmlLabel10.Size = New System.Drawing.Size(159, 36)
        Me.Guna2HtmlLabel10.TabIndex = 52
        Me.Guna2HtmlLabel10.Text = "دائن"
        Me.Guna2HtmlLabel10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCredit
        '
        Me.txtCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCredit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCredit.DefaultText = ""
        Me.txtCredit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCredit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCredit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCredit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCredit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCredit.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCredit.ForeColor = System.Drawing.Color.Black
        Me.txtCredit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCredit.Location = New System.Drawing.Point(612, 232)
        Me.txtCredit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.PlaceholderText = ""
        Me.txtCredit.SelectedText = ""
        Me.txtCredit.Size = New System.Drawing.Size(159, 45)
        Me.txtCredit.TabIndex = 51
        Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel6.AutoSize = False
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(22, 183)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(386, 36)
        Me.Guna2HtmlLabel6.TabIndex = 50
        Me.Guna2HtmlLabel6.Text = "الحالي الرصيد"
        Me.Guna2HtmlLabel6.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtBalance
        '
        Me.txtBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBalance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBalance.DefaultText = ""
        Me.txtBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtBalance.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBalance.Location = New System.Drawing.Point(22, 232)
        Me.txtBalance.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.PlaceholderText = ""
        Me.txtBalance.SelectedText = ""
        Me.txtBalance.Size = New System.Drawing.Size(386, 45)
        Me.txtBalance.TabIndex = 49
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvCustomers
        '
        Me.dgvCustomers.AllowUserToAddRows = False
        Me.dgvCustomers.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvCustomers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCustomers.ColumnHeadersHeight = 4
        Me.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomers.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvCustomers.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCustomers.Location = New System.Drawing.Point(0, 538)
        Me.dgvCustomers.Name = "dgvCustomers"
        Me.dgvCustomers.ReadOnly = True
        Me.dgvCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvCustomers.RowHeadersVisible = False
        Me.dgvCustomers.RowTemplate.Height = 40
        Me.dgvCustomers.Size = New System.Drawing.Size(1492, 384)
        Me.dgvCustomers.TabIndex = 55
        Me.dgvCustomers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvCustomers.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvCustomers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvCustomers.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvCustomers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCustomers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCustomers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCustomers.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCustomers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvCustomers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvCustomers.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvCustomers.ThemeStyle.ReadOnly = True
        Me.dgvCustomers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvCustomers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvCustomers.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCustomers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvCustomers.ThemeStyle.RowsStyle.Height = 40
        Me.dgvCustomers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCustomers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'lstSuggestions
        '
        Me.lstSuggestions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSuggestions.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lstSuggestions.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 25
        Me.lstSuggestions.Location = New System.Drawing.Point(955, 145)
        Me.lstSuggestions.Margin = New System.Windows.Forms.Padding(5)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.Size = New System.Drawing.Size(522, 379)
        Me.lstSuggestions.TabIndex = 58
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(955, 85)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "ابحث عن عميل"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(522, 49)
        Me.txtSearch.TabIndex = 56
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.AutoSize = False
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(25, 317)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(322, 36)
        Me.Guna2HtmlLabel1.TabIndex = 60
        Me.Guna2HtmlLabel1.Text = "الدفع مبلغ"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmountPaid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAmountPaid.DefaultText = ""
        Me.txtAmountPaid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAmountPaid.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAmountPaid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAmountPaid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAmountPaid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAmountPaid.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtAmountPaid.ForeColor = System.Drawing.Color.Black
        Me.txtAmountPaid.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAmountPaid.Location = New System.Drawing.Point(20, 362)
        Me.txtAmountPaid.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.PlaceholderText = ".....اكتب مبلغ الدفع"
        Me.txtAmountPaid.SelectedText = ""
        Me.txtAmountPaid.Size = New System.Drawing.Size(302, 45)
        Me.txtAmountPaid.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(331, 362)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 39)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "جنيه"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel9.AutoSize = False
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(441, 371)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(286, 36)
        Me.Guna2HtmlLabel9.TabIndex = 63
        Me.Guna2HtmlLabel9.Text = "الملاحظات"
        Me.Guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotes.DefaultText = ""
        Me.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(437, 416)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(494, 113)
        Me.txtNotes.TabIndex = 62
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel3.AutoSize = False
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(22, 85)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(317, 36)
        Me.Guna2HtmlLabel3.TabIndex = 67
        Me.Guna2HtmlLabel3.Text = "العميل اسم"
        Me.Guna2HtmlLabel3.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomerName.DefaultText = ""
        Me.txtCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCustomerName.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerName.Location = New System.Drawing.Point(22, 126)
        Me.txtCustomerName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.PlaceholderText = ""
        Me.txtCustomerName.SelectedText = ""
        Me.txtCustomerName.Size = New System.Drawing.Size(386, 45)
        Me.txtCustomerName.TabIndex = 65
        Me.txtCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomerCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomerCode.DefaultText = ""
        Me.txtCustomerCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCustomerCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCustomerCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCustomerCode.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerCode.Location = New System.Drawing.Point(417, 138)
        Me.txtCustomerCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.PlaceholderText = ""
        Me.txtCustomerCode.SelectedText = ""
        Me.txtCustomerCode.Size = New System.Drawing.Size(212, 45)
        Me.txtCustomerCode.TabIndex = 64
        Me.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel7
        '
        Me.Guna2HtmlLabel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel7.AutoSize = False
        Me.Guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel7.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel7.Location = New System.Drawing.Point(417, 192)
        Me.Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Me.Guna2HtmlLabel7.Size = New System.Drawing.Size(186, 36)
        Me.Guna2HtmlLabel7.TabIndex = 69
        Me.Guna2HtmlLabel7.Text = "الائتمان حد"
        Me.Guna2HtmlLabel7.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'nudCreditLimit
        '
        Me.nudCreditLimit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudCreditLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudCreditLimit.Location = New System.Drawing.Point(417, 233)
        Me.nudCreditLimit.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.nudCreditLimit.Name = "nudCreditLimit"
        Me.nudCreditLimit.Size = New System.Drawing.Size(186, 44)
        Me.nudCreditLimit.TabIndex = 68
        Me.nudCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbSearchField
        '
        Me.cmbSearchField.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchField.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchField.FormattingEnabled = True
        Me.cmbSearchField.Location = New System.Drawing.Point(704, 85)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(242, 45)
        Me.cmbSearchField.TabIndex = 70
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel2.AutoSize = False
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(417, 89)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(212, 36)
        Me.Guna2HtmlLabel2.TabIndex = 71
        Me.Guna2HtmlLabel2.Text = "العميل كود"
        Me.Guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDoPayment
        '
        Me.btnDoPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDoPayment.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoPayment.Appearance.Options.UseFont = True
        Me.btnDoPayment.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btnDoPayment.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnDoPayment.Location = New System.Drawing.Point(17, 454)
        Me.btnDoPayment.Name = "btnDoPayment"
        Me.btnDoPayment.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnDoPayment.Size = New System.Drawing.Size(391, 75)
        Me.btnDoPayment.TabIndex = 72
        Me.btnDoPayment.Text = "تسجيل الدفع"
        '
        'cmbTreasury
        '
        Me.cmbTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbTreasury.BorderRadius = 8
        Me.cmbTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTreasury.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasury.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbTreasury.ItemHeight = 40
        Me.cmbTreasury.Location = New System.Drawing.Point(551, 307)
        Me.cmbTreasury.Name = "cmbTreasury"
        Me.cmbTreasury.Size = New System.Drawing.Size(380, 46)
        Me.cmbTreasury.TabIndex = 5648
        Me.cmbTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(412, 307)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 46)
        Me.Label4.TabIndex = 5647
        Me.Label4.Text = "الخزنة"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Customer_Balance_Download
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1492, 922)
        Me.Controls.Add(Me.cmbTreasury)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDoPayment)
        Me.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Controls.Add(Me.cmbSearchField)
        Me.Controls.Add(Me.Guna2HtmlLabel7)
        Me.Controls.Add(Me.nudCreditLimit)
        Me.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.txtCustomerCode)
        Me.Controls.Add(Me.Guna2HtmlLabel9)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Controls.Add(Me.txtAmountPaid)
        Me.Controls.Add(Me.lstSuggestions)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dgvCustomers)
        Me.Controls.Add(Me.Guna2HtmlLabel13)
        Me.Controls.Add(Me.txtDebit)
        Me.Controls.Add(Me.Guna2HtmlLabel10)
        Me.Controls.Add(Me.txtCredit)
        Me.Controls.Add(Me.Guna2HtmlLabel6)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Customer_Balance_Download"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCreditLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pn_title_page As Label
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel13 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtDebit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel10 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtCredit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtBalance As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvCustomers As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtAmountPaid As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtCustomerName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtCustomerCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents nudCreditLimit As NumericUpDown
    Friend WithEvents cmbSearchField As ComboBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnDoPayment As DevExpress.XtraEditors.SimpleButton
    Public WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label4 As Label
End Class
