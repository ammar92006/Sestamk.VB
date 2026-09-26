<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShiftReports
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShiftReports))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.grpFilters = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.lblReportMode = New System.Windows.Forms.Label()
        Me.cmbReportMode = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.cmbShiftFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.cmbUserFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatusFilter = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.dtpFrom = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpTo = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnSearch = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportExcel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrint = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlKPIs = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTotalSalesSum = New System.Windows.Forms.Label()
        Me.lblTotalSalesTitle = New System.Windows.Forms.Label()
        Me.lblTotalCashSum = New System.Windows.Forms.Label()
        Me.lblTotalCashTitle = New System.Windows.Forms.Label()
        Me.lblTotalVisaSum = New System.Windows.Forms.Label()
        Me.lblTotalVisaTitle = New System.Windows.Forms.Label()
        Me.lblTotalExpensesSum = New System.Windows.Forms.Label()
        Me.lblTotalExpensesTitle = New System.Windows.Forms.Label()
        Me.lblNetIncomeSum = New System.Windows.Forms.Label()
        Me.lblNetIncomeTitle = New System.Windows.Forms.Label()
        Me.lblTotalDifferenceSum = New System.Windows.Forms.Label()
        Me.lblTotalDiffTitle = New System.Windows.Forms.Label()
        Me.lblRecordsCount = New System.Windows.Forms.Label()
        Me.lblRecordsCountTitle = New System.Windows.Forms.Label()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.panelHeader.SuspendLayout()
        Me.grpFilters.SuspendLayout()
        Me.pnlKPIs.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 12
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.lblHeaderTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1300, 65)
        Me.panelHeader.TabIndex = 0
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(103, 14)
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
        Me.btn_max.Location = New System.Drawing.Point(59, 14)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 4
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(15, 14)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 3
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeaderTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(300, 14)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(700, 36)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "تقارير الوردية والتحليلات الشاملة"
        Me.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.lblReportMode)
        Me.grpFilters.Controls.Add(Me.cmbReportMode)
        Me.grpFilters.Controls.Add(Me.lblShift)
        Me.grpFilters.Controls.Add(Me.cmbShiftFilter)
        Me.grpFilters.Controls.Add(Me.lblUser)
        Me.grpFilters.Controls.Add(Me.cmbUserFilter)
        Me.grpFilters.Controls.Add(Me.lblStatus)
        Me.grpFilters.Controls.Add(Me.cmbStatusFilter)
        Me.grpFilters.Controls.Add(Me.lblFrom)
        Me.grpFilters.Controls.Add(Me.dtpFrom)
        Me.grpFilters.Controls.Add(Me.lblTo)
        Me.grpFilters.Controls.Add(Me.dtpTo)
        Me.grpFilters.Controls.Add(Me.txtSearch)
        Me.grpFilters.Controls.Add(Me.btnSearch)
        Me.grpFilters.Controls.Add(Me.btnRefresh)
        Me.grpFilters.Controls.Add(Me.btnExportExcel)
        Me.grpFilters.Controls.Add(Me.btnExportPdf)
        Me.grpFilters.Controls.Add(Me.btnPrint)
        Me.grpFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFilters.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.grpFilters.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpFilters.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.grpFilters.Location = New System.Drawing.Point(0, 65)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpFilters.Size = New System.Drawing.Size(1300, 205)
        Me.grpFilters.TabIndex = 1
        Me.grpFilters.Text = "خيارات الفرز ومعايير التقرير"
        Me.grpFilters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblReportMode
        '
        Me.lblReportMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReportMode.BackColor = System.Drawing.Color.Transparent
        Me.lblReportMode.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblReportMode.Location = New System.Drawing.Point(1200, 48)
        Me.lblReportMode.Name = "lblReportMode"
        Me.lblReportMode.Size = New System.Drawing.Size(90, 32)
        Me.lblReportMode.TabIndex = 10
        Me.lblReportMode.Text = "نوع التقرير:"
        Me.lblReportMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbReportMode
        '
        Me.cmbReportMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbReportMode.BackColor = System.Drawing.Color.Transparent
        Me.cmbReportMode.BorderRadius = 6
        Me.cmbReportMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbReportMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportMode.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbReportMode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbReportMode.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.cmbReportMode.ForeColor = System.Drawing.Color.Black
        Me.cmbReportMode.ItemHeight = 28
        Me.cmbReportMode.Location = New System.Drawing.Point(950, 46)
        Me.cmbReportMode.Name = "cmbReportMode"
        Me.cmbReportMode.Size = New System.Drawing.Size(245, 34)
        Me.cmbReportMode.TabIndex = 0
        Me.cmbReportMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblShift
        '
        Me.lblShift.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblShift.Location = New System.Drawing.Point(860, 48)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(85, 32)
        Me.lblShift.TabIndex = 11
        Me.lblShift.Text = "الوردية:"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbShiftFilter
        '
        Me.cmbShiftFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbShiftFilter.BackColor = System.Drawing.Color.Transparent
        Me.cmbShiftFilter.BorderRadius = 6
        Me.cmbShiftFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbShiftFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShiftFilter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbShiftFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbShiftFilter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbShiftFilter.ForeColor = System.Drawing.Color.Black
        Me.cmbShiftFilter.ItemHeight = 28
        Me.cmbShiftFilter.Location = New System.Drawing.Point(620, 46)
        Me.cmbShiftFilter.Name = "cmbShiftFilter"
        Me.cmbShiftFilter.Size = New System.Drawing.Size(235, 34)
        Me.cmbShiftFilter.TabIndex = 1
        Me.cmbShiftFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblUser.Location = New System.Drawing.Point(525, 48)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(90, 32)
        Me.lblUser.TabIndex = 12
        Me.lblUser.Text = "المستخدم:"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbUserFilter
        '
        Me.cmbUserFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUserFilter.BackColor = System.Drawing.Color.Transparent
        Me.cmbUserFilter.BorderRadius = 6
        Me.cmbUserFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUserFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserFilter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbUserFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbUserFilter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbUserFilter.ForeColor = System.Drawing.Color.Black
        Me.cmbUserFilter.ItemHeight = 28
        Me.cmbUserFilter.Location = New System.Drawing.Point(315, 46)
        Me.cmbUserFilter.Name = "cmbUserFilter"
        Me.cmbUserFilter.Size = New System.Drawing.Size(205, 34)
        Me.cmbUserFilter.TabIndex = 2
        Me.cmbUserFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.Location = New System.Drawing.Point(220, 48)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(90, 32)
        Me.lblStatus.TabIndex = 13
        Me.lblStatus.Text = "حالة الوردية:"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbStatusFilter
        '
        Me.cmbStatusFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStatusFilter.BackColor = System.Drawing.Color.Transparent
        Me.cmbStatusFilter.BorderRadius = 6
        Me.cmbStatusFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusFilter.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbStatusFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbStatusFilter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbStatusFilter.ForeColor = System.Drawing.Color.Black
        Me.cmbStatusFilter.ItemHeight = 28
        Me.cmbStatusFilter.Location = New System.Drawing.Point(15, 46)
        Me.cmbStatusFilter.Name = "cmbStatusFilter"
        Me.cmbStatusFilter.Size = New System.Drawing.Size(200, 34)
        Me.cmbStatusFilter.TabIndex = 3
        Me.cmbStatusFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFrom
        '
        Me.lblFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFrom.BackColor = System.Drawing.Color.Transparent
        Me.lblFrom.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblFrom.Location = New System.Drawing.Point(1200, 96)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(90, 32)
        Me.lblFrom.TabIndex = 14
        Me.lblFrom.Text = "من تاريخ:"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrom
        '
        Me.dtpFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFrom.BorderRadius = 6
        Me.dtpFrom.Checked = True
        Me.dtpFrom.CustomFormat = "yyyy/MM/dd"
        Me.dtpFrom.FillColor = System.Drawing.Color.White
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(950, 95)
        Me.dtpFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(245, 34)
        Me.dtpFrom.TabIndex = 4
        Me.dtpFrom.Value = New Date(2026, 1, 1, 0, 0, 0, 0)
        '
        'lblTo
        '
        Me.lblTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTo.BackColor = System.Drawing.Color.Transparent
        Me.lblTo.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblTo.Location = New System.Drawing.Point(860, 96)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(85, 32)
        Me.lblTo.TabIndex = 15
        Me.lblTo.Text = "إلى تاريخ:"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.BorderRadius = 6
        Me.dtpTo.Checked = True
        Me.dtpTo.CustomFormat = "yyyy/MM/dd"
        Me.dtpTo.FillColor = System.Drawing.Color.White
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(620, 95)
        Me.dtpTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(235, 34)
        Me.dtpTo.TabIndex = 5
        Me.dtpTo.Value = New Date(2026, 1, 1, 0, 0, 0, 0)
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderRadius = 6
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtSearch.Location = New System.Drawing.Point(15, 95)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "🔍 اكتب هنا للبحث الفوري في النتائج المعروضة (اسم الصنف، العميل، رقم الفاتورة، الكاشير...)"
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(595, 34)
        Me.txtSearch.TabIndex = 6
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BorderRadius = 6
        Me.btnSearch.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(1090, 148)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(195, 42)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "🔍 عرض التقرير والفرز"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BorderRadius = 6
        Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(885, 148)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(195, 42)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "🔄 إعادة ضبط / تحديث"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportExcel.BorderRadius = 6
        Me.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportExcel.ForeColor = System.Drawing.Color.White
        Me.btnExportExcel.Location = New System.Drawing.Point(680, 148)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(195, 42)
        Me.btnExportExcel.TabIndex = 9
        Me.btnExportExcel.Text = "📊 تصدير إلى Excel"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BorderRadius = 6
        Me.btnPrint.FillColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(475, 148)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(195, 42)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "🖨️ طباعة التقرير"
        '
        'btnExportPdf
        '
        Me.btnExportPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportPdf.BorderRadius = 6
        Me.btnExportPdf.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnExportPdf.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportPdf.ForeColor = System.Drawing.Color.White
        Me.btnExportPdf.Location = New System.Drawing.Point(270, 148)
        Me.btnExportPdf.Name = "btnExportPdf"
        Me.btnExportPdf.Size = New System.Drawing.Size(195, 42)
        Me.btnExportPdf.TabIndex = 11
        Me.btnExportPdf.Text = "📄 تصدير إلى PDF"
        '
        'pnlKPIs
        '
        Me.pnlKPIs.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlKPIs.Controls.Add(Me.lblTotalSalesSum)
        Me.pnlKPIs.Controls.Add(Me.lblTotalSalesTitle)
        Me.pnlKPIs.Controls.Add(Me.lblTotalCashSum)
        Me.pnlKPIs.Controls.Add(Me.lblTotalCashTitle)
        Me.pnlKPIs.Controls.Add(Me.lblTotalVisaSum)
        Me.pnlKPIs.Controls.Add(Me.lblTotalVisaTitle)
        Me.pnlKPIs.Controls.Add(Me.lblTotalExpensesSum)
        Me.pnlKPIs.Controls.Add(Me.lblTotalExpensesTitle)
        Me.pnlKPIs.Controls.Add(Me.lblNetIncomeSum)
        Me.pnlKPIs.Controls.Add(Me.lblNetIncomeTitle)
        Me.pnlKPIs.Controls.Add(Me.lblTotalDifferenceSum)
        Me.pnlKPIs.Controls.Add(Me.lblTotalDiffTitle)
        Me.pnlKPIs.Controls.Add(Me.lblRecordsCount)
        Me.pnlKPIs.Controls.Add(Me.lblRecordsCountTitle)
        Me.pnlKPIs.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlKPIs.Location = New System.Drawing.Point(0, 270)
        Me.pnlKPIs.Name = "pnlKPIs"
        Me.pnlKPIs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlKPIs.Size = New System.Drawing.Size(1300, 68)
        Me.pnlKPIs.TabIndex = 2
        '
        'lblTotalSalesTitle
        '
        Me.lblTotalSalesTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalSalesTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalSalesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblTotalSalesTitle.Location = New System.Drawing.Point(1135, 6)
        Me.lblTotalSalesTitle.Name = "lblTotalSalesTitle"
        Me.lblTotalSalesTitle.Size = New System.Drawing.Size(155, 20)
        Me.lblTotalSalesTitle.TabIndex = 0
        Me.lblTotalSalesTitle.Text = "إجمالي المبيعات"
        Me.lblTotalSalesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSalesSum
        '
        Me.lblTotalSalesSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalSalesSum.BackColor = System.Drawing.Color.White
        Me.lblTotalSalesSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalSalesSum.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalSalesSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblTotalSalesSum.Location = New System.Drawing.Point(1135, 29)
        Me.lblTotalSalesSum.Name = "lblTotalSalesSum"
        Me.lblTotalSalesSum.Size = New System.Drawing.Size(155, 30)
        Me.lblTotalSalesSum.TabIndex = 1
        Me.lblTotalSalesSum.Text = "0.00"
        Me.lblTotalSalesSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalCashTitle
        '
        Me.lblTotalCashTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCashTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCashTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblTotalCashTitle.Location = New System.Drawing.Point(955, 6)
        Me.lblTotalCashTitle.Name = "lblTotalCashTitle"
        Me.lblTotalCashTitle.Size = New System.Drawing.Size(155, 20)
        Me.lblTotalCashTitle.TabIndex = 2
        Me.lblTotalCashTitle.Text = "مبيعات الكاش"
        Me.lblTotalCashTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalCashSum
        '
        Me.lblTotalCashSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCashSum.BackColor = System.Drawing.Color.White
        Me.lblTotalCashSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCashSum.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCashSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblTotalCashSum.Location = New System.Drawing.Point(955, 29)
        Me.lblTotalCashSum.Name = "lblTotalCashSum"
        Me.lblTotalCashSum.Size = New System.Drawing.Size(155, 30)
        Me.lblTotalCashSum.TabIndex = 3
        Me.lblTotalCashSum.Text = "0.00"
        Me.lblTotalCashSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalVisaTitle
        '
        Me.lblTotalVisaTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalVisaTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalVisaTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblTotalVisaTitle.Location = New System.Drawing.Point(775, 6)
        Me.lblTotalVisaTitle.Name = "lblTotalVisaTitle"
        Me.lblTotalVisaTitle.Size = New System.Drawing.Size(155, 20)
        Me.lblTotalVisaTitle.TabIndex = 4
        Me.lblTotalVisaTitle.Text = "مبيعات الفيزا"
        Me.lblTotalVisaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalVisaSum
        '
        Me.lblTotalVisaSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalVisaSum.BackColor = System.Drawing.Color.White
        Me.lblTotalVisaSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalVisaSum.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalVisaSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.lblTotalVisaSum.Location = New System.Drawing.Point(775, 29)
        Me.lblTotalVisaSum.Name = "lblTotalVisaSum"
        Me.lblTotalVisaSum.Size = New System.Drawing.Size(155, 30)
        Me.lblTotalVisaSum.TabIndex = 5
        Me.lblTotalVisaSum.Text = "0.00"
        Me.lblTotalVisaSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalExpensesTitle
        '
        Me.lblTotalExpensesTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalExpensesTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalExpensesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblTotalExpensesTitle.Location = New System.Drawing.Point(595, 6)
        Me.lblTotalExpensesTitle.Name = "lblTotalExpensesTitle"
        Me.lblTotalExpensesTitle.Size = New System.Drawing.Size(155, 20)
        Me.lblTotalExpensesTitle.TabIndex = 6
        Me.lblTotalExpensesTitle.Text = "إجمالي المصروفات"
        Me.lblTotalExpensesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalExpensesSum
        '
        Me.lblTotalExpensesSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalExpensesSum.BackColor = System.Drawing.Color.White
        Me.lblTotalExpensesSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalExpensesSum.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalExpensesSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblTotalExpensesSum.Location = New System.Drawing.Point(595, 29)
        Me.lblTotalExpensesSum.Name = "lblTotalExpensesSum"
        Me.lblTotalExpensesSum.Size = New System.Drawing.Size(155, 30)
        Me.lblTotalExpensesSum.TabIndex = 7
        Me.lblTotalExpensesSum.Text = "0.00"
        Me.lblTotalExpensesSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNetIncomeTitle
        '
        Me.lblNetIncomeTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNetIncomeTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblNetIncomeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblNetIncomeTitle.Location = New System.Drawing.Point(415, 6)
        Me.lblNetIncomeTitle.Name = "lblNetIncomeTitle"
        Me.lblNetIncomeTitle.Size = New System.Drawing.Size(155, 20)
        Me.lblNetIncomeTitle.TabIndex = 8
        Me.lblNetIncomeTitle.Text = "صافي النقدية / الإيراد"
        Me.lblNetIncomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNetIncomeSum
        '
        Me.lblNetIncomeSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNetIncomeSum.BackColor = System.Drawing.Color.White
        Me.lblNetIncomeSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNetIncomeSum.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblNetIncomeSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.lblNetIncomeSum.Location = New System.Drawing.Point(415, 29)
        Me.lblNetIncomeSum.Name = "lblNetIncomeSum"
        Me.lblNetIncomeSum.Size = New System.Drawing.Size(155, 30)
        Me.lblNetIncomeSum.TabIndex = 9
        Me.lblNetIncomeSum.Text = "0.00"
        Me.lblNetIncomeSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalDiffTitle
        '
        Me.lblTotalDiffTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalDiffTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDiffTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblTotalDiffTitle.Location = New System.Drawing.Point(235, 6)
        Me.lblTotalDiffTitle.Name = "lblTotalDiffTitle"
        Me.lblTotalDiffTitle.Size = New System.Drawing.Size(155, 20)
        Me.lblTotalDiffTitle.TabIndex = 10
        Me.lblTotalDiffTitle.Text = "فارق الدرج (عجز/زيادة)"
        Me.lblTotalDiffTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalDifferenceSum
        '
        Me.lblTotalDifferenceSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalDifferenceSum.BackColor = System.Drawing.Color.White
        Me.lblTotalDifferenceSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDifferenceSum.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDifferenceSum.ForeColor = System.Drawing.Color.Black
        Me.lblTotalDifferenceSum.Location = New System.Drawing.Point(235, 29)
        Me.lblTotalDifferenceSum.Name = "lblTotalDifferenceSum"
        Me.lblTotalDifferenceSum.Size = New System.Drawing.Size(155, 30)
        Me.lblTotalDifferenceSum.TabIndex = 11
        Me.lblTotalDifferenceSum.Text = "0.00"
        Me.lblTotalDifferenceSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecordsCountTitle
        '
        Me.lblRecordsCountTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecordsCountTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblRecordsCountTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblRecordsCountTitle.Location = New System.Drawing.Point(15, 6)
        Me.lblRecordsCountTitle.Name = "lblRecordsCountTitle"
        Me.lblRecordsCountTitle.Size = New System.Drawing.Size(195, 20)
        Me.lblRecordsCountTitle.TabIndex = 12
        Me.lblRecordsCountTitle.Text = "عدد السجلات / العمليات"
        Me.lblRecordsCountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecordsCount
        '
        Me.lblRecordsCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecordsCount.BackColor = System.Drawing.Color.White
        Me.lblRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecordsCount.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblRecordsCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblRecordsCount.Location = New System.Drawing.Point(15, 29)
        Me.lblRecordsCount.Name = "lblRecordsCount"
        Me.lblRecordsCount.Size = New System.Drawing.Size(195, 30)
        Me.lblRecordsCount.TabIndex = 13
        Me.lblRecordsCount.Text = "0"
        Me.lblRecordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dgvReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReport.BackgroundColor = System.Drawing.Color.White
        Me.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReport.ColumnHeadersHeight = 38
        Me.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReport.EnableHeadersVisualStyles = False
        Me.dgvReport.Location = New System.Drawing.Point(0, 338)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvReport.RowHeadersVisible = False
        Me.dgvReport.RowTemplate.Height = 35
        Me.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReport.Size = New System.Drawing.Size(1300, 442)
        Me.dgvReport.TabIndex = 3
        '
        'FrmShiftReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1300, 780)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlKPIs)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmShiftReports"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقارير الوردية والتحليلات الشاملة"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.grpFilters.ResumeLayout(False)
        Me.pnlKPIs.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents grpFilters As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents lblReportMode As Label
    Friend WithEvents cmbReportMode As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblShift As Label
    Friend WithEvents cmbShiftFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblUser As Label
    Friend WithEvents cmbUserFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbStatusFilter As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblFrom As Label
    Friend WithEvents dtpFrom As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents lblTo As Label
    Friend WithEvents dtpTo As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSearch As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportExcel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportPdf As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPrint As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlKPIs As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTotalSalesSum As Label
    Friend WithEvents lblTotalSalesTitle As Label
    Friend WithEvents lblTotalCashSum As Label
    Friend WithEvents lblTotalCashTitle As Label
    Friend WithEvents lblTotalVisaSum As Label
    Friend WithEvents lblTotalVisaTitle As Label
    Friend WithEvents lblTotalExpensesSum As Label
    Friend WithEvents lblTotalExpensesTitle As Label
    Friend WithEvents lblNetIncomeSum As Label
    Friend WithEvents lblNetIncomeTitle As Label
    Friend WithEvents lblTotalDifferenceSum As Label
    Friend WithEvents lblTotalDiffTitle As Label
    Friend WithEvents lblRecordsCount As Label
    Friend WithEvents lblRecordsCountTitle As Label
    Friend WithEvents dgvReport As DataGridView
End Class
