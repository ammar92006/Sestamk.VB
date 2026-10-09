<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalesReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSalesReport))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle_Delivery As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle_Net As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle_Paid As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle_Rem As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_min = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_max = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_close = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbOrderType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSearch = New Guna.UI2.WinForms.Guna2Button()
        Me.lblTotalSalesSum = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.lblTotalPaidSum = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalDiscountSum = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTo = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrom = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgvSales = New System.Windows.Forms.DataGridView()
        Me.colInvNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDriver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeliveryFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemaining = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBranch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.lblTotalRemainingSum = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.panelHeader.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.dgvSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_min
        '
        Me.btn_min.AutoSize = True
        Me.btn_min.Location = New System.Drawing.Point(103, 17)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btn_min.FillColor = System.Drawing.Color.Transparent
        Me.btn_min.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_min.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_min.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.btn_min.TabIndex = 5
        '
        'btn_max
        '
        Me.btn_max.AutoSize = True
        Me.btn_max.Location = New System.Drawing.Point(59, 17)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox
        Me.btn_max.FillColor = System.Drawing.Color.Transparent
        Me.btn_max.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_max.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_max.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 4
        '
        'btn_close
        '
        Me.btn_close.AutoSize = True
        Me.btn_close.Location = New System.Drawing.Point(15, 17)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.FillColor = System.Drawing.Color.Transparent
        Me.btn_close.HoverState.FillColor = System.Drawing.Color.FromArgb(239, 68, 68)
        Me.btn_close.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_close.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 3
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(574, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(171, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "المبيعات تقارير"
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
        Me.panelHeader.Size = New System.Drawing.Size(1331, 70)
        Me.panelHeader.TabIndex = 48
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
        Me.Label5.Text = "نوع الطلب"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbOrderType
        '
        Me.cmbOrderType.BackColor = System.Drawing.Color.Transparent
        Me.cmbOrderType.BorderRadius = 6
        Me.cmbOrderType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrderType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbOrderType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbOrderType.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbOrderType.ForeColor = System.Drawing.Color.Black
        Me.cmbOrderType.ItemHeight = 30
        Me.cmbOrderType.Location = New System.Drawing.Point(939, 45)
        Me.cmbOrderType.Name = "cmbOrderType"
        Me.cmbOrderType.Size = New System.Drawing.Size(250, 36)
        Me.cmbOrderType.TabIndex = 5621
        Me.cmbOrderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.btnSearch.Location = New System.Drawing.Point(417, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 38)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "بحث"
        '
        'lblTotalSalesSum
        '
        Me.lblTotalSalesSum.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalSalesSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalSalesSum.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalSalesSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalSalesSum.Location = New System.Drawing.Point(553, 93)
        Me.lblTotalSalesSum.Name = "lblTotalSalesSum"
        Me.lblTotalSalesSum.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalSalesSum.TabIndex = 5637
        Me.lblTotalSalesSum.Text = "0.00"
        Me.lblTotalSalesSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label10.Text = "مدين (عليه)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'lblTotalPaidSum
        '
        Me.lblTotalPaidSum.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPaidSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalPaidSum.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalPaidSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalPaidSum.Location = New System.Drawing.Point(168, 93)
        Me.lblTotalPaidSum.Name = "lblTotalPaidSum"
        Me.lblTotalPaidSum.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalPaidSum.TabIndex = 5648
        Me.lblTotalPaidSum.Text = "0.00"
        Me.lblTotalPaidSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label7.Text = "اجمالي المدفوع"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalDiscountSum
        '
        Me.lblTotalDiscountSum.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalDiscountSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDiscountSum.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDiscountSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalDiscountSum.Location = New System.Drawing.Point(553, 137)
        Me.lblTotalDiscountSum.Name = "lblTotalDiscountSum"
        Me.lblTotalDiscountSum.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalDiscountSum.TabIndex = 5646
        Me.lblTotalDiscountSum.Text = "0.00"
        Me.lblTotalDiscountSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label4.Text = "اجمالي الخصم"
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
        'dtpFrom
        '
        Me.dtpFrom.BorderRadius = 8
        Me.dtpFrom.Checked = True
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpFrom.Location = New System.Drawing.Point(938, 93)
        Me.dtpFrom.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(240, 36)
        Me.dtpFrom.TabIndex = 5642
        Me.dtpFrom.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(1188, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 36)
        Me.Label1.TabIndex = 5641
        Me.Label1.Text = "تاريخ البداية"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.Controls.Add(Me.btnRefresh)
        Me.Guna2Panel1.Controls.Add(Me.btnSearch)
        Me.Guna2Panel1.Location = New System.Drawing.Point(77, 190)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1175, 55)
        Me.Guna2Panel1.TabIndex = 5640
        '
        'dgvSales
        '
        Me.dgvSales.AllowUserToAddRows = False
        Me.dgvSales.AllowUserToDeleteRows = False
        Me.dgvSales.AllowUserToResizeColumns = False
        Me.dgvSales.AllowUserToResizeRows = False
        Me.dgvSales.AutoGenerateColumns = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvSales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSales.BackgroundColor = System.Drawing.Color.White
        Me.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInvNum, Me.colDate, Me.colType, Me.colCustomer, Me.colTable, Me.colDriver, Me.colDeliveryFee, Me.colNet, Me.colPaid, Me.colRemaining, Me.colPayType, Me.colShift, Me.colBranch, Me.colStore})
        Me.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSales.Location = New System.Drawing.Point(0, 323)
        Me.dgvSales.MultiSelect = False
        Me.dgvSales.Name = "dgvSales"
        Me.dgvSales.ReadOnly = True
        Me.dgvSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvSales.RowTemplate.Height = 35
        Me.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSales.Size = New System.Drawing.Size(1331, 431)
        Me.dgvSales.TabIndex = 50
        '
        'colInvNum
        '
        Me.colInvNum.DataPropertyName = "InvoiceNumber"
        Me.colInvNum.HeaderText = "رقم الفاتورة"
        Me.colInvNum.Name = "colInvNum"
        Me.colInvNum.ReadOnly = True
        Me.colInvNum.Width = 130
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "InvoiceDate"
        Me.colDate.HeaderText = "التاريخ والوقت"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Width = 140
        '
        'colType
        '
        Me.colType.DataPropertyName = "OrderTypeName"
        Me.colType.HeaderText = "نوع الطلب"
        Me.colType.Name = "colType"
        Me.colType.ReadOnly = True
        Me.colType.Width = 90
        '
        'colCustomer
        '
        Me.colCustomer.DataPropertyName = "CustomerName"
        Me.colCustomer.HeaderText = "العميل"
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.ReadOnly = True
        Me.colCustomer.Width = 130
        '
        'colTable
        '
        Me.colTable.DataPropertyName = "TableName"
        Me.colTable.HeaderText = "الطاولة"
        Me.colTable.Name = "colTable"
        Me.colTable.ReadOnly = True
        Me.colTable.Width = 80
        '
        'colDriver
        '
        Me.colDriver.DataPropertyName = "DriverName"
        Me.colDriver.HeaderText = "الطيار"
        Me.colDriver.Name = "colDriver"
        Me.colDriver.ReadOnly = True
        Me.colDriver.Width = 110
        '
        'colDeliveryFee
        '
        DataGridViewCellStyle_Delivery.Format = "N2"
        Me.colDeliveryFee.DefaultCellStyle = DataGridViewCellStyle_Delivery
        Me.colDeliveryFee.DataPropertyName = "DeliveryFee"
        Me.colDeliveryFee.HeaderText = "التوصيل"
        Me.colDeliveryFee.Name = "colDeliveryFee"
        Me.colDeliveryFee.ReadOnly = True
        Me.colDeliveryFee.Width = 80
        '
        'colNet
        '
        DataGridViewCellStyle_Net.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle_Net.Format = "N2"
        Me.colNet.DefaultCellStyle = DataGridViewCellStyle_Net
        Me.colNet.DataPropertyName = "NetTotal"
        Me.colNet.HeaderText = "الصافي"
        Me.colNet.Name = "colNet"
        Me.colNet.ReadOnly = True
        Me.colNet.Width = 100
        '
        'colPaid
        '
        DataGridViewCellStyle_Paid.Format = "N2"
        Me.colPaid.DefaultCellStyle = DataGridViewCellStyle_Paid
        Me.colPaid.DataPropertyName = "PaidAmount"
        Me.colPaid.HeaderText = "المدفوع"
        Me.colPaid.Name = "colPaid"
        Me.colPaid.ReadOnly = True
        Me.colPaid.Width = 90
        '
        'colRemaining
        '
        DataGridViewCellStyle_Rem.Format = "N2"
        Me.colRemaining.DefaultCellStyle = DataGridViewCellStyle_Rem
        Me.colRemaining.DataPropertyName = "RemainingAmount"
        Me.colRemaining.HeaderText = "المتبقي"
        Me.colRemaining.Name = "colRemaining"
        Me.colRemaining.ReadOnly = True
        Me.colRemaining.Width = 90
        '
        'colPayType
        '
        Me.colPayType.DataPropertyName = "PaymentType"
        Me.colPayType.HeaderText = "الدفع"
        Me.colPayType.Name = "colPayType"
        Me.colPayType.ReadOnly = True
        Me.colPayType.Width = 80
        '
        'colShift
        '
        Me.colShift.DataPropertyName = "ShiftNumber"
        Me.colShift.HeaderText = "الوردية"
        Me.colShift.Name = "colShift"
        Me.colShift.ReadOnly = True
        Me.colShift.Width = 120
        '
        'colBranch
        '
        Me.colBranch.DataPropertyName = "BranchName"
        Me.colBranch.HeaderText = "الفرع"
        Me.colBranch.Name = "colBranch"
        Me.colBranch.ReadOnly = True
        Me.colBranch.Width = 110
        '
        'colStore
        '
        Me.colStore.DataPropertyName = "StoreName"
        Me.colStore.HeaderText = "المخزن"
        Me.colStore.Name = "colStore"
        Me.colStore.ReadOnly = True
        Me.colStore.Width = 110
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalRemainingSum)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalPaidSum)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalDiscountSum)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.dtpTo)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.dtpFrom)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2Panel1)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalSalesSum)
        Me.grpCustomerInfo.Controls.Add(Me.Label10)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.cmbOrderType)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 70)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1331, 253)
        Me.grpCustomerInfo.TabIndex = 49
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalRemainingSum
        '
        Me.lblTotalRemainingSum.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalRemainingSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalRemainingSum.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalRemainingSum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalRemainingSum.Location = New System.Drawing.Point(168, 138)
        Me.lblTotalRemainingSum.Name = "lblTotalRemainingSum"
        Me.lblTotalRemainingSum.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalRemainingSum.TabIndex = 5650
        Me.lblTotalRemainingSum.Text = "0.00"
        Me.lblTotalRemainingSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label6.Text = "اجمالي المتبقي"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmSalesReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1331, 754)
        Me.Controls.Add(Me.dgvSales)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSalesReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSalesReport"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.dgvSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbOrderType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSearch As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTotalSalesSum As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents dgvSales As DataGridView
    Friend WithEvents colInvNum As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colType As DataGridViewTextBoxColumn
    Friend WithEvents colCustomer As DataGridViewTextBoxColumn
    Friend WithEvents colTable As DataGridViewTextBoxColumn
    Friend WithEvents colDriver As DataGridViewTextBoxColumn
    Friend WithEvents colDeliveryFee As DataGridViewTextBoxColumn
    Friend WithEvents colNet As DataGridViewTextBoxColumn
    Friend WithEvents colPaid As DataGridViewTextBoxColumn
    Friend WithEvents colRemaining As DataGridViewTextBoxColumn
    Friend WithEvents colPayType As DataGridViewTextBoxColumn
    Friend WithEvents colShift As DataGridViewTextBoxColumn
    Friend WithEvents colBranch As DataGridViewTextBoxColumn
    Friend WithEvents colStore As DataGridViewTextBoxColumn
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents lblTotalRemainingSum As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotalPaidSum As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTotalDiscountSum As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTo As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFrom As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
End Class
