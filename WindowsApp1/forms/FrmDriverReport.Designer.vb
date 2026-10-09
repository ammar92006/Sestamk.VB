<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDriverReport
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle_Total As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle_Fee As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle_Status As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDriverReport))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvDriverReport = New System.Windows.Forms.DataGridView()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDriver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNetDueToRestaurant = New System.Windows.Forms.Label()
        Me.lblTotalDeliveryFees = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalOrdersCash = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTo = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnSettle = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSearch = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.lblTotalOrdersCount = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbDrivers = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.dtpFrom = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbStatus = New Guna.UI2.WinForms.Guna2ComboBox()
        CType(Me.dgvDriverReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.grpCustomerInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(420, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 36)
        Me.Label6.TabIndex = 5649
        Me.Label6.Text = "صافي المحل"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDriverReport
        '
        Me.dgvDriverReport.AllowUserToAddRows = False
        Me.dgvDriverReport.AllowUserToDeleteRows = False
        Me.dgvDriverReport.AllowUserToResizeColumns = False
        Me.dgvDriverReport.AllowUserToResizeRows = False
        Me.dgvDriverReport.AutoGenerateColumns = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvDriverReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDriverReport.BackgroundColor = System.Drawing.Color.White
        Me.dgvDriverReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDriverReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDate, Me.colDriver, Me.colPhone, Me.colInvNum, Me.colCustomer, Me.colOrderTotal, Me.colFee, Me.colStatus, Me.colShift})
        Me.dgvDriverReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDriverReport.Location = New System.Drawing.Point(0, 323)
        Me.dgvDriverReport.MultiSelect = False
        Me.dgvDriverReport.Name = "dgvDriverReport"
        Me.dgvDriverReport.ReadOnly = True
        Me.dgvDriverReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvDriverReport.RowTemplate.Height = 35
        Me.dgvDriverReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDriverReport.Size = New System.Drawing.Size(1331, 431)
        Me.dgvDriverReport.TabIndex = 53
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "TransactionDate"
        Me.colDate.HeaderText = "التاريخ والوقت"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Width = 140
        '
        'colDriver
        '
        Me.colDriver.DataPropertyName = "DriverName"
        Me.colDriver.HeaderText = "اسم الطيار"
        Me.colDriver.Name = "colDriver"
        Me.colDriver.ReadOnly = True
        Me.colDriver.Width = 130
        '
        'colPhone
        '
        Me.colPhone.DataPropertyName = "Phone"
        Me.colPhone.HeaderText = "رقم الموبايل"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.ReadOnly = True
        Me.colPhone.Width = 110
        '
        'colInvNum
        '
        Me.colInvNum.DataPropertyName = "InvoiceNumber"
        Me.colInvNum.HeaderText = "رقم الفاتورة"
        Me.colInvNum.Name = "colInvNum"
        Me.colInvNum.ReadOnly = True
        Me.colInvNum.Width = 130
        '
        'colCustomer
        '
        Me.colCustomer.DataPropertyName = "CustomerName"
        Me.colCustomer.HeaderText = "العميل"
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.ReadOnly = True
        Me.colCustomer.Width = 130
        '
        'colOrderTotal
        '
        DataGridViewCellStyle_Total.Format = "N2"
        Me.colOrderTotal.DefaultCellStyle = DataGridViewCellStyle_Total
        Me.colOrderTotal.DataPropertyName = "OrderTotal"
        Me.colOrderTotal.HeaderText = "قيمة الفاتورة"
        Me.colOrderTotal.Name = "colOrderTotal"
        Me.colOrderTotal.ReadOnly = True
        Me.colOrderTotal.Width = 110
        '
        'colFee
        '
        DataGridViewCellStyle_Fee.Format = "N2"
        DataGridViewCellStyle_Fee.ForeColor = System.Drawing.Color.ForestGreen
        Me.colFee.DefaultCellStyle = DataGridViewCellStyle_Fee
        Me.colFee.DataPropertyName = "DeliveryFee"
        Me.colFee.HeaderText = "عمولة التوصيل"
        Me.colFee.Name = "colFee"
        Me.colFee.ReadOnly = True
        Me.colFee.Width = 100
        '
        'colStatus
        '
        DataGridViewCellStyle_Status.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.colStatus.DefaultCellStyle = DataGridViewCellStyle_Status
        Me.colStatus.DataPropertyName = "SettleStatus"
        Me.colStatus.HeaderText = "حالة التوريد"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.Width = 120
        '
        'colShift
        '
        Me.colShift.DataPropertyName = "ShiftNumber"
        Me.colShift.HeaderText = "الوردية"
        Me.colShift.Name = "colShift"
        Me.colShift.ReadOnly = True
        Me.colShift.Width = 120
        '
        'lblNetDueToRestaurant
        '
        Me.lblNetDueToRestaurant.BackColor = System.Drawing.Color.Transparent
        Me.lblNetDueToRestaurant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNetDueToRestaurant.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNetDueToRestaurant.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblNetDueToRestaurant.Location = New System.Drawing.Point(168, 138)
        Me.lblNetDueToRestaurant.Name = "lblNetDueToRestaurant"
        Me.lblNetDueToRestaurant.Size = New System.Drawing.Size(250, 36)
        Me.lblNetDueToRestaurant.TabIndex = 5650
        Me.lblNetDueToRestaurant.Text = "0.00"
        Me.lblNetDueToRestaurant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalDeliveryFees
        '
        Me.lblTotalDeliveryFees.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalDeliveryFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDeliveryFees.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDeliveryFees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalDeliveryFees.Location = New System.Drawing.Point(168, 93)
        Me.lblTotalDeliveryFees.Name = "lblTotalDeliveryFees"
        Me.lblTotalDeliveryFees.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalDeliveryFees.TabIndex = 5648
        Me.lblTotalDeliveryFees.Text = "0.00"
        Me.lblTotalDeliveryFees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(420, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 36)
        Me.Label7.TabIndex = 5647
        Me.Label7.Text = "اجمالي العموله"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalOrdersCash
        '
        Me.lblTotalOrdersCash.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalOrdersCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalOrdersCash.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalOrdersCash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalOrdersCash.Location = New System.Drawing.Point(553, 137)
        Me.lblTotalOrdersCash.Name = "lblTotalOrdersCash"
        Me.lblTotalOrdersCash.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalOrdersCash.TabIndex = 5646
        Me.lblTotalOrdersCash.Text = "0.00"
        Me.lblTotalOrdersCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(805, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 36)
        Me.Label4.TabIndex = 5645
        Me.Label4.Text = "اجمالي الطلبات"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpTo
        '
        Me.dtpTo.BorderRadius = 8
        Me.dtpTo.Checked = True
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpTo.Location = New System.Drawing.Point(938, 138)
        Me.dtpTo.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpTo.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(240, 36)
        Me.dtpTo.TabIndex = 5644
        Me.dtpTo.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(1188, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 36)
        Me.Label2.TabIndex = 5643
        Me.Label2.Text = "تاريخ النهاية"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.Controls.Add(Me.btnSettle)
        Me.Guna2Panel1.Controls.Add(Me.btnRefresh)
        Me.Guna2Panel1.Controls.Add(Me.btnSearch)
        Me.Guna2Panel1.Location = New System.Drawing.Point(77, 190)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1175, 55)
        Me.Guna2Panel1.TabIndex = 5640
        '
        'btnSettle
        '
        Me.btnSettle.BorderRadius = 6
        Me.btnSettle.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSettle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSettle.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSettle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSettle.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSettle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSettle.ForeColor = System.Drawing.Color.White
        Me.btnSettle.Location = New System.Drawing.Point(633, 9)
        Me.btnSettle.Name = "btnSettle"
        Me.btnSettle.Size = New System.Drawing.Size(176, 38)
        Me.btnSettle.TabIndex = 5
        Me.btnSettle.Text = "تصفية حساب الطيار"
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
        Me.btnRefresh.Location = New System.Drawing.Point(295, 9)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(110, 38)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "تحديث"
        '
        'btnSearch
        '
        Me.btnSearch.BorderRadius = 6
        Me.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearch.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(461, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 38)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "بحث"
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'lblTotalOrdersCount
        '
        Me.lblTotalOrdersCount.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalOrdersCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalOrdersCount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalOrdersCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalOrdersCount.Location = New System.Drawing.Point(553, 93)
        Me.lblTotalOrdersCount.Name = "lblTotalOrdersCount"
        Me.lblTotalOrdersCount.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalOrdersCount.TabIndex = 5637
        Me.lblTotalOrdersCount.Text = "0.00"
        Me.lblTotalOrdersCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(1195, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 36)
        Me.Label5.TabIndex = 5622
        Me.Label5.Text = "الطيار"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDrivers
        '
        Me.cmbDrivers.BackColor = System.Drawing.Color.Transparent
        Me.cmbDrivers.BorderRadius = 6
        Me.cmbDrivers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDrivers.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbDrivers.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbDrivers.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbDrivers.ForeColor = System.Drawing.Color.Black
        Me.cmbDrivers.ItemHeight = 30
        Me.cmbDrivers.Location = New System.Drawing.Point(939, 45)
        Me.cmbDrivers.Name = "cmbDrivers"
        Me.cmbDrivers.Size = New System.Drawing.Size(250, 36)
        Me.cmbDrivers.TabIndex = 5621
        Me.cmbDrivers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.panelHeader.Size = New System.Drawing.Size(1331, 70)
        Me.panelHeader.TabIndex = 51
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
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(544, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(259, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الديليفري طيارين تقارير"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(805, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 36)
        Me.Label10.TabIndex = 5636
        Me.Label10.Text = "عدد الطلبات"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.dtpFrom)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.cmbStatus)
        Me.grpCustomerInfo.Controls.Add(Me.lblNetDueToRestaurant)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalDeliveryFees)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalOrdersCash)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.dtpTo)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2Panel1)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalOrdersCount)
        Me.grpCustomerInfo.Controls.Add(Me.Label10)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.cmbDrivers)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 70)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1331, 253)
        Me.grpCustomerInfo.TabIndex = 52
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFrom
        '
        Me.dtpFrom.BorderRadius = 8
        Me.dtpFrom.Checked = True
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpFrom.Location = New System.Drawing.Point(938, 94)
        Me.dtpFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(240, 36)
        Me.dtpFrom.TabIndex = 5654
        Me.dtpFrom.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(1188, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 36)
        Me.Label3.TabIndex = 5653
        Me.Label3.Text = "تاريخ النهاية"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(794, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 36)
        Me.Label1.TabIndex = 5652
        Me.Label1.Text = "الحالة"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbStatus
        '
        Me.cmbStatus.BackColor = System.Drawing.Color.Transparent
        Me.cmbStatus.BorderRadius = 6
        Me.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbStatus.ForeColor = System.Drawing.Color.Black
        Me.cmbStatus.ItemHeight = 30
        Me.cmbStatus.Location = New System.Drawing.Point(538, 45)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(250, 36)
        Me.cmbStatus.TabIndex = 5651
        Me.cmbStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmDriverReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1331, 754)
        Me.Controls.Add(Me.dgvDriverReport)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmDriverReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvDriverReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents dgvDriverReport As DataGridView
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colDriver As DataGridViewTextBoxColumn
    Friend WithEvents colPhone As DataGridViewTextBoxColumn
    Friend WithEvents colInvNum As DataGridViewTextBoxColumn
    Friend WithEvents colCustomer As DataGridViewTextBoxColumn
    Friend WithEvents colOrderTotal As DataGridViewTextBoxColumn
    Friend WithEvents colFee As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colShift As DataGridViewTextBoxColumn
    Friend WithEvents lblNetDueToRestaurant As Label
    Friend WithEvents lblTotalDeliveryFees As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTotalOrdersCash As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTo As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSearch As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents dtpFrom As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbStatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblTotalOrdersCount As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbDrivers As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnSettle As Guna.UI2.WinForms.Guna2Button
End Class
