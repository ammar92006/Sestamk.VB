Namespace Global.WindowsApp1
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmTableReservations
        Inherits System.Windows.Forms.Form

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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.panelHeader = New System.Windows.Forms.Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.btnCloseForm = New System.Windows.Forms.Button()
            Me.pnlNewReservation = New System.Windows.Forms.Panel()
            Me.lblSectionTitle = New System.Windows.Forms.Label()
            Me.lblTableTitle = New System.Windows.Forms.Label()
            Me.cmbTables = New System.Windows.Forms.ComboBox()
            Me.lblCustomerNameTitle = New System.Windows.Forms.Label()
            Me.txtCustomerName = New System.Windows.Forms.TextBox()
            Me.lblCustomerPhoneTitle = New System.Windows.Forms.Label()
            Me.txtCustomerPhone = New System.Windows.Forms.TextBox()
            Me.lblGuestsTitle = New System.Windows.Forms.Label()
            Me.numGuests = New System.Windows.Forms.NumericUpDown()
            Me.lblDateTimeTitle = New System.Windows.Forms.Label()
            Me.pnlDateTime = New System.Windows.Forms.Panel()
            Me.dtpReservationDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpReservationTime = New System.Windows.Forms.DateTimePicker()
            Me.lblDepositTitle = New System.Windows.Forms.Label()
            Me.txtDeposit = New System.Windows.Forms.TextBox()
            Me.lblTreasuryTitle = New System.Windows.Forms.Label()
            Me.cmbTreasury = New System.Windows.Forms.ComboBox()
            Me.lblNotesTitle = New System.Windows.Forms.Label()
            Me.txtNotes = New System.Windows.Forms.TextBox()
            Me.btnSaveReservation = New System.Windows.Forms.Button()
            Me.pnlHistoryContainer = New System.Windows.Forms.Panel()
            Me.dgvReservations = New System.Windows.Forms.DataGridView()
            Me.colResID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTableID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colResNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTable = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colGuests = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDeposit = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlBottomActions = New System.Windows.Forms.Panel()
            Me.btnCheckInSelected = New System.Windows.Forms.Button()
            Me.btnCancelSelected = New System.Windows.Forms.Button()
            Me.pnlTopBar = New System.Windows.Forms.Panel()
            Me.lblTodayCount = New System.Windows.Forms.Label()
            Me.lblTotalDeposits = New System.Windows.Forms.Label()
            Me.lblFilterDateTitle = New System.Windows.Forms.Label()
            Me.dtpFilterDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStatusTitle = New System.Windows.Forms.Label()
            Me.cmbFilterStatus = New System.Windows.Forms.ComboBox()
            Me.btnRefreshGrid = New System.Windows.Forms.Button()
            Me.panelHeader.SuspendLayout()
            Me.pnlNewReservation.SuspendLayout()
            CType(Me.numGuests, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDateTime.SuspendLayout()
            Me.pnlHistoryContainer.SuspendLayout()
            CType(Me.dgvReservations, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBottomActions.SuspendLayout()
            Me.pnlTopBar.SuspendLayout()
            Me.SuspendLayout()
            '
            'panelHeader
            '
            Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
            Me.panelHeader.Controls.Add(Me.lblTitle)
            Me.panelHeader.Controls.Add(Me.btnCloseForm)
            Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelHeader.Location = New System.Drawing.Point(0, 0)
            Me.panelHeader.Name = "panelHeader"
            Me.panelHeader.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
            Me.panelHeader.Size = New System.Drawing.Size(1180, 55)
            Me.panelHeader.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.White
            Me.lblTitle.Location = New System.Drawing.Point(15, 14)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(465, 25)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "📅 إدارة حجوزات طاولات الصالة والعربون (Table Reservations)"
            '
            'btnCloseForm
            '
            Me.btnCloseForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnCloseForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
            Me.btnCloseForm.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCloseForm.FlatAppearance.BorderSize = 0
            Me.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCloseForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnCloseForm.ForeColor = System.Drawing.Color.White
            Me.btnCloseForm.Location = New System.Drawing.Point(15, 10)
            Me.btnCloseForm.Name = "btnCloseForm"
            Me.btnCloseForm.Size = New System.Drawing.Size(40, 34)
            Me.btnCloseForm.TabIndex = 1
            Me.btnCloseForm.Text = "✕"
            Me.btnCloseForm.UseVisualStyleBackColor = False
            '
            'pnlNewReservation
            '
            Me.pnlNewReservation.BackColor = System.Drawing.Color.White
            Me.pnlNewReservation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlNewReservation.Controls.Add(Me.lblSectionTitle)
            Me.pnlNewReservation.Controls.Add(Me.lblTableTitle)
            Me.pnlNewReservation.Controls.Add(Me.cmbTables)
            Me.pnlNewReservation.Controls.Add(Me.lblCustomerNameTitle)
            Me.pnlNewReservation.Controls.Add(Me.txtCustomerName)
            Me.pnlNewReservation.Controls.Add(Me.lblCustomerPhoneTitle)
            Me.pnlNewReservation.Controls.Add(Me.txtCustomerPhone)
            Me.pnlNewReservation.Controls.Add(Me.lblGuestsTitle)
            Me.pnlNewReservation.Controls.Add(Me.numGuests)
            Me.pnlNewReservation.Controls.Add(Me.lblDateTimeTitle)
            Me.pnlNewReservation.Controls.Add(Me.pnlDateTime)
            Me.pnlNewReservation.Controls.Add(Me.lblDepositTitle)
            Me.pnlNewReservation.Controls.Add(Me.txtDeposit)
            Me.pnlNewReservation.Controls.Add(Me.lblTreasuryTitle)
            Me.pnlNewReservation.Controls.Add(Me.cmbTreasury)
            Me.pnlNewReservation.Controls.Add(Me.lblNotesTitle)
            Me.pnlNewReservation.Controls.Add(Me.txtNotes)
            Me.pnlNewReservation.Controls.Add(Me.btnSaveReservation)
            Me.pnlNewReservation.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlNewReservation.Location = New System.Drawing.Point(810, 55)
            Me.pnlNewReservation.Name = "pnlNewReservation"
            Me.pnlNewReservation.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlNewReservation.Size = New System.Drawing.Size(370, 665)
            Me.pnlNewReservation.TabIndex = 1
            '
            'lblSectionTitle
            '
            Me.lblSectionTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblSectionTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblSectionTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.lblSectionTitle.Location = New System.Drawing.Point(15, 15)
            Me.lblSectionTitle.Name = "lblSectionTitle"
            Me.lblSectionTitle.Size = New System.Drawing.Size(338, 30)
            Me.lblSectionTitle.TabIndex = 0
            Me.lblSectionTitle.Text = "📝 تسجيل حجز طاولة جديد"
            '
            'lblTableTitle
            '
            Me.lblTableTitle.AutoSize = True
            Me.lblTableTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblTableTitle.Location = New System.Drawing.Point(15, 45)
            Me.lblTableTitle.Name = "lblTableTitle"
            Me.lblTableTitle.Size = New System.Drawing.Size(117, 15)
            Me.lblTableTitle.TabIndex = 1
            Me.lblTableTitle.Text = "الطاولة المستهدفة *:"
            '
            'cmbTables
            '
            Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTables.Location = New System.Drawing.Point(15, 67)
            Me.cmbTables.Name = "cmbTables"
            Me.cmbTables.Size = New System.Drawing.Size(335, 25)
            Me.cmbTables.TabIndex = 2
            '
            'lblCustomerNameTitle
            '
            Me.lblCustomerNameTitle.AutoSize = True
            Me.lblCustomerNameTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblCustomerNameTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblCustomerNameTitle.Location = New System.Drawing.Point(15, 101)
            Me.lblCustomerNameTitle.Name = "lblCustomerNameTitle"
            Me.lblCustomerNameTitle.Size = New System.Drawing.Size(83, 15)
            Me.lblCustomerNameTitle.TabIndex = 3
            Me.lblCustomerNameTitle.Text = "اسم العميل *:"
            '
            'txtCustomerName
            '
            Me.txtCustomerName.Location = New System.Drawing.Point(15, 123)
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.Size = New System.Drawing.Size(335, 25)
            Me.txtCustomerName.TabIndex = 4
            '
            'lblCustomerPhoneTitle
            '
            Me.lblCustomerPhoneTitle.AutoSize = True
            Me.lblCustomerPhoneTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblCustomerPhoneTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblCustomerPhoneTitle.Location = New System.Drawing.Point(15, 157)
            Me.lblCustomerPhoneTitle.Name = "lblCustomerPhoneTitle"
            Me.lblCustomerPhoneTitle.Size = New System.Drawing.Size(117, 15)
            Me.lblCustomerPhoneTitle.TabIndex = 5
            Me.lblCustomerPhoneTitle.Text = "رقم هاتف العميل *:"
            '
            'txtCustomerPhone
            '
            Me.txtCustomerPhone.Location = New System.Drawing.Point(15, 179)
            Me.txtCustomerPhone.Name = "txtCustomerPhone"
            Me.txtCustomerPhone.Size = New System.Drawing.Size(335, 25)
            Me.txtCustomerPhone.TabIndex = 6
            '
            'lblGuestsTitle
            '
            Me.lblGuestsTitle.AutoSize = True
            Me.lblGuestsTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblGuestsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblGuestsTitle.Location = New System.Drawing.Point(15, 213)
            Me.lblGuestsTitle.Name = "lblGuestsTitle"
            Me.lblGuestsTitle.Size = New System.Drawing.Size(117, 15)
            Me.lblGuestsTitle.TabIndex = 7
            Me.lblGuestsTitle.Text = "عدد الأفراد / الضيوف:"
            '
            'numGuests
            '
            Me.numGuests.Location = New System.Drawing.Point(15, 235)
            Me.numGuests.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
            Me.numGuests.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numGuests.Name = "numGuests"
            Me.numGuests.Size = New System.Drawing.Size(335, 25)
            Me.numGuests.TabIndex = 8
            Me.numGuests.Value = New Decimal(New Integer() {2, 0, 0, 0})
            '
            'lblDateTimeTitle
            '
            Me.lblDateTimeTitle.AutoSize = True
            Me.lblDateTimeTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblDateTimeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblDateTimeTitle.Location = New System.Drawing.Point(15, 269)
            Me.lblDateTimeTitle.Name = "lblDateTimeTitle"
            Me.lblDateTimeTitle.Size = New System.Drawing.Size(189, 15)
            Me.lblDateTimeTitle.TabIndex = 9
            Me.lblDateTimeTitle.Text = "موعد وتوقيت الحضور المستهدف *:"
            '
            'pnlDateTime
            '
            Me.pnlDateTime.Controls.Add(Me.dtpReservationDate)
            Me.pnlDateTime.Controls.Add(Me.dtpReservationTime)
            Me.pnlDateTime.Location = New System.Drawing.Point(15, 291)
            Me.pnlDateTime.Name = "pnlDateTime"
            Me.pnlDateTime.Size = New System.Drawing.Size(335, 28)
            Me.pnlDateTime.TabIndex = 10
            '
            'dtpReservationDate
            '
            Me.dtpReservationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpReservationDate.Location = New System.Drawing.Point(175, 0)
            Me.dtpReservationDate.Name = "dtpReservationDate"
            Me.dtpReservationDate.Size = New System.Drawing.Size(160, 25)
            Me.dtpReservationDate.TabIndex = 0
            '
            'dtpReservationTime
            '
            Me.dtpReservationTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
            Me.dtpReservationTime.Location = New System.Drawing.Point(0, 0)
            Me.dtpReservationTime.Name = "dtpReservationTime"
            Me.dtpReservationTime.ShowUpDown = True
            Me.dtpReservationTime.Size = New System.Drawing.Size(160, 25)
            Me.dtpReservationTime.TabIndex = 1
            '
            'lblDepositTitle
            '
            Me.lblDepositTitle.AutoSize = True
            Me.lblDepositTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblDepositTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblDepositTitle.Location = New System.Drawing.Point(15, 325)
            Me.lblDepositTitle.Name = "lblDepositTitle"
            Me.lblDepositTitle.Size = New System.Drawing.Size(157, 15)
            Me.lblDepositTitle.TabIndex = 11
            Me.lblDepositTitle.Text = "مبلغ العربون المدفوع (إن وجد):"
            '
            'txtDeposit
            '
            Me.txtDeposit.Location = New System.Drawing.Point(15, 347)
            Me.txtDeposit.Name = "txtDeposit"
            Me.txtDeposit.Size = New System.Drawing.Size(335, 25)
            Me.txtDeposit.TabIndex = 12
            Me.txtDeposit.Text = "0.00"
            '
            'lblTreasuryTitle
            '
            Me.lblTreasuryTitle.AutoSize = True
            Me.lblTreasuryTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTreasuryTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblTreasuryTitle.Location = New System.Drawing.Point(15, 381)
            Me.lblTreasuryTitle.Name = "lblTreasuryTitle"
            Me.lblTreasuryTitle.Size = New System.Drawing.Size(135, 15)
            Me.lblTreasuryTitle.TabIndex = 13
            Me.lblTreasuryTitle.Text = "الخزينة المستلمة للعربون:"
            '
            'cmbTreasury
            '
            Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTreasury.Location = New System.Drawing.Point(15, 403)
            Me.cmbTreasury.Name = "cmbTreasury"
            Me.cmbTreasury.Size = New System.Drawing.Size(335, 25)
            Me.cmbTreasury.TabIndex = 14
            '
            'lblNotesTitle
            '
            Me.lblNotesTitle.AutoSize = True
            Me.lblNotesTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblNotesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblNotesTitle.Location = New System.Drawing.Point(15, 437)
            Me.lblNotesTitle.Name = "lblNotesTitle"
            Me.lblNotesTitle.Size = New System.Drawing.Size(176, 15)
            Me.lblNotesTitle.TabIndex = 15
            Me.lblNotesTitle.Text = "ملاحظات خاصة (مناسبة / تزيين):"
            '
            'txtNotes
            '
            Me.txtNotes.Location = New System.Drawing.Point(15, 459)
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(335, 50)
            Me.txtNotes.TabIndex = 16
            '
            'btnSaveReservation
            '
            Me.btnSaveReservation.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnSaveReservation.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSaveReservation.FlatAppearance.BorderSize = 0
            Me.btnSaveReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSaveReservation.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnSaveReservation.ForeColor = System.Drawing.Color.White
            Me.btnSaveReservation.Location = New System.Drawing.Point(15, 520)
            Me.btnSaveReservation.Name = "btnSaveReservation"
            Me.btnSaveReservation.Size = New System.Drawing.Size(335, 42)
            Me.btnSaveReservation.TabIndex = 17
            Me.btnSaveReservation.Text = "💾 تأكيد الحجز وإيداع العربون"
            Me.btnSaveReservation.UseVisualStyleBackColor = False
            '
            'pnlHistoryContainer
            '
            Me.pnlHistoryContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.pnlHistoryContainer.Controls.Add(Me.dgvReservations)
            Me.pnlHistoryContainer.Controls.Add(Me.pnlBottomActions)
            Me.pnlHistoryContainer.Controls.Add(Me.pnlTopBar)
            Me.pnlHistoryContainer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlHistoryContainer.Location = New System.Drawing.Point(0, 55)
            Me.pnlHistoryContainer.Name = "pnlHistoryContainer"
            Me.pnlHistoryContainer.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlHistoryContainer.Size = New System.Drawing.Size(810, 665)
            Me.pnlHistoryContainer.TabIndex = 2
            '
            'dgvReservations
            '
            Me.dgvReservations.AllowUserToAddRows = False
            Me.dgvReservations.BackgroundColor = System.Drawing.Color.White
            Me.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvReservations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colResID, Me.colTableID, Me.colResNum, Me.colTable, Me.colCustomer, Me.colPhone, Me.colGuests, Me.colDateTime, Me.colDeposit, Me.colStatus, Me.colNotes})
            Me.dgvReservations.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvReservations.Location = New System.Drawing.Point(15, 105)
            Me.dgvReservations.Name = "dgvReservations"
            Me.dgvReservations.ReadOnly = True
            Me.dgvReservations.RowTemplate.Height = 35
            Me.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvReservations.Size = New System.Drawing.Size(780, 490)
            Me.dgvReservations.TabIndex = 1
            '
            'colResID
            '
            Me.colResID.HeaderText = "ResID"
            Me.colResID.Name = "colResID"
            Me.colResID.ReadOnly = True
            Me.colResID.Visible = False
            '
            'colTableID
            '
            Me.colTableID.HeaderText = "TableID"
            Me.colTableID.Name = "colTableID"
            Me.colTableID.ReadOnly = True
            Me.colTableID.Visible = False
            '
            'colResNum
            '
            Me.colResNum.HeaderText = "رقم الحجز"
            Me.colResNum.Name = "colResNum"
            Me.colResNum.ReadOnly = True
            Me.colResNum.Width = 140
            '
            'colTable
            '
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.colTable.DefaultCellStyle = DataGridViewCellStyle1
            Me.colTable.HeaderText = "الطاولة"
            Me.colTable.Name = "colTable"
            Me.colTable.ReadOnly = True
            Me.colTable.Width = 110
            '
            'colCustomer
            '
            Me.colCustomer.HeaderText = "العميل"
            Me.colCustomer.Name = "colCustomer"
            Me.colCustomer.ReadOnly = True
            Me.colCustomer.Width = 150
            '
            'colPhone
            '
            Me.colPhone.HeaderText = "الهاتف"
            Me.colPhone.Name = "colPhone"
            Me.colPhone.ReadOnly = True
            Me.colPhone.Width = 120
            '
            'colGuests
            '
            Me.colGuests.HeaderText = "الأفراد"
            Me.colGuests.Name = "colGuests"
            Me.colGuests.ReadOnly = True
            Me.colGuests.Width = 70
            '
            'colDateTime
            '
            Me.colDateTime.HeaderText = "موعد الحضور"
            Me.colDateTime.Name = "colDateTime"
            Me.colDateTime.ReadOnly = True
            Me.colDateTime.Width = 130
            '
            'colDeposit
            '
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen
            DataGridViewCellStyle2.Format = "N2"
            Me.colDeposit.DefaultCellStyle = DataGridViewCellStyle2
            Me.colDeposit.HeaderText = "العربون"
            Me.colDeposit.Name = "colDeposit"
            Me.colDeposit.ReadOnly = True
            Me.colDeposit.Width = 90
            '
            'colStatus
            '
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.colStatus.DefaultCellStyle = DataGridViewCellStyle3
            Me.colStatus.HeaderText = "الحالة"
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            Me.colStatus.Width = 110
            '
            'colNotes
            '
            Me.colNotes.HeaderText = "ملاحظات"
            Me.colNotes.Name = "colNotes"
            Me.colNotes.ReadOnly = True
            Me.colNotes.Width = 180
            '
            'pnlBottomActions
            '
            Me.pnlBottomActions.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.pnlBottomActions.Controls.Add(Me.btnCheckInSelected)
            Me.pnlBottomActions.Controls.Add(Me.btnCancelSelected)
            Me.pnlBottomActions.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottomActions.Location = New System.Drawing.Point(15, 595)
            Me.pnlBottomActions.Name = "pnlBottomActions"
            Me.pnlBottomActions.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlBottomActions.Size = New System.Drawing.Size(780, 55)
            Me.pnlBottomActions.TabIndex = 2
            '
            'btnCheckInSelected
            '
            Me.btnCheckInSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCheckInSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnCheckInSelected.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCheckInSelected.FlatAppearance.BorderSize = 0
            Me.btnCheckInSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCheckInSelected.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnCheckInSelected.ForeColor = System.Drawing.Color.White
            Me.btnCheckInSelected.Location = New System.Drawing.Point(555, 9)
            Me.btnCheckInSelected.Name = "btnCheckInSelected"
            Me.btnCheckInSelected.Size = New System.Drawing.Size(210, 36)
            Me.btnCheckInSelected.TabIndex = 0
            Me.btnCheckInSelected.Text = "🛎️ تسكين الحجز المحدد الآن"
            Me.btnCheckInSelected.UseVisualStyleBackColor = False
            '
            'btnCancelSelected
            '
            Me.btnCancelSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancelSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.btnCancelSelected.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCancelSelected.FlatAppearance.BorderSize = 0
            Me.btnCancelSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancelSelected.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnCancelSelected.ForeColor = System.Drawing.Color.White
            Me.btnCancelSelected.Location = New System.Drawing.Point(335, 9)
            Me.btnCancelSelected.Name = "btnCancelSelected"
            Me.btnCancelSelected.Size = New System.Drawing.Size(210, 36)
            Me.btnCancelSelected.TabIndex = 1
            Me.btnCancelSelected.Text = "❌ إلغاء الحجز وإتاحة الطاولة"
            Me.btnCancelSelected.UseVisualStyleBackColor = False
            '
            'pnlTopBar
            '
            Me.pnlTopBar.BackColor = System.Drawing.Color.White
            Me.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlTopBar.Controls.Add(Me.lblTodayCount)
            Me.pnlTopBar.Controls.Add(Me.lblTotalDeposits)
            Me.pnlTopBar.Controls.Add(Me.lblFilterDateTitle)
            Me.pnlTopBar.Controls.Add(Me.dtpFilterDate)
            Me.pnlTopBar.Controls.Add(Me.lblStatusTitle)
            Me.pnlTopBar.Controls.Add(Me.cmbFilterStatus)
            Me.pnlTopBar.Controls.Add(Me.btnRefreshGrid)
            Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTopBar.Location = New System.Drawing.Point(15, 15)
            Me.pnlTopBar.Name = "pnlTopBar"
            Me.pnlTopBar.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTopBar.Size = New System.Drawing.Size(780, 90)
            Me.pnlTopBar.TabIndex = 0
            '
            'lblTodayCount
            '
            Me.lblTodayCount.AutoSize = True
            Me.lblTodayCount.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblTodayCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblTodayCount.Location = New System.Drawing.Point(20, 12)
            Me.lblTodayCount.Name = "lblTodayCount"
            Me.lblTodayCount.Size = New System.Drawing.Size(167, 19)
            Me.lblTodayCount.TabIndex = 0
            Me.lblTodayCount.Text = "حجوزات التاريخ المحدد: 0"
            '
            'lblTotalDeposits
            '
            Me.lblTotalDeposits.AutoSize = True
            Me.lblTotalDeposits.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblTotalDeposits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.lblTotalDeposits.Location = New System.Drawing.Point(260, 12)
            Me.lblTotalDeposits.Name = "lblTotalDeposits"
            Me.lblTotalDeposits.Size = New System.Drawing.Size(217, 19)
            Me.lblTotalDeposits.TabIndex = 1
            Me.lblTotalDeposits.Text = "إجمالي العربونات المحصلة: 0.00 ج"
            '
            'lblFilterDateTitle
            '
            Me.lblFilterDateTitle.AutoSize = True
            Me.lblFilterDateTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblFilterDateTitle.Location = New System.Drawing.Point(20, 52)
            Me.lblFilterDateTitle.Name = "lblFilterDateTitle"
            Me.lblFilterDateTitle.Size = New System.Drawing.Size(107, 15)
            Me.lblFilterDateTitle.TabIndex = 2
            Me.lblFilterDateTitle.Text = "عرض حجوزات تاريخ:"
            '
            'dtpFilterDate
            '
            Me.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFilterDate.Location = New System.Drawing.Point(150, 48)
            Me.dtpFilterDate.Name = "dtpFilterDate"
            Me.dtpFilterDate.Size = New System.Drawing.Size(140, 25)
            Me.dtpFilterDate.TabIndex = 3
            '
            'lblStatusTitle
            '
            Me.lblStatusTitle.AutoSize = True
            Me.lblStatusTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblStatusTitle.Location = New System.Drawing.Point(310, 52)
            Me.lblStatusTitle.Name = "lblStatusTitle"
            Me.lblStatusTitle.Size = New System.Drawing.Size(40, 15)
            Me.lblStatusTitle.TabIndex = 4
            Me.lblStatusTitle.Text = "الحالة:"
            '
            'cmbFilterStatus
            '
            Me.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFilterStatus.Items.AddRange(New Object() {"الكل", "مؤكد 🟡", "تم التسكين 🔴", "ملغي ⚪", "لم يحضر ❌"})
            Me.cmbFilterStatus.Location = New System.Drawing.Point(360, 48)
            Me.cmbFilterStatus.Name = "cmbFilterStatus"
            Me.cmbFilterStatus.Size = New System.Drawing.Size(140, 25)
            Me.cmbFilterStatus.TabIndex = 5
            '
            'btnRefreshGrid
            '
            Me.btnRefreshGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer))
            Me.btnRefreshGrid.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefreshGrid.FlatAppearance.BorderSize = 0
            Me.btnRefreshGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRefreshGrid.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnRefreshGrid.ForeColor = System.Drawing.Color.White
            Me.btnRefreshGrid.Location = New System.Drawing.Point(520, 47)
            Me.btnRefreshGrid.Name = "btnRefreshGrid"
            Me.btnRefreshGrid.Size = New System.Drawing.Size(95, 30)
            Me.btnRefreshGrid.TabIndex = 6
            Me.btnRefreshGrid.Text = "🔄 تحديث"
            Me.btnRefreshGrid.UseVisualStyleBackColor = False
            '
            'FrmTableReservations
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1180, 720)
            Me.Controls.Add(Me.pnlHistoryContainer)
            Me.Controls.Add(Me.pnlNewReservation)
            Me.Controls.Add(Me.panelHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.MinimumSize = New Size(980, 600)
            Me.Name = "FrmTableReservations"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "إدارة حجوزات طاولات الصالة (Table Reservations)"
            Me.panelHeader.ResumeLayout(False)
            Me.panelHeader.PerformLayout()
            Me.pnlNewReservation.ResumeLayout(False)
            Me.pnlNewReservation.PerformLayout()
            CType(Me.numGuests, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDateTime.ResumeLayout(False)
            Me.pnlHistoryContainer.ResumeLayout(False)
            CType(Me.dgvReservations, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBottomActions.ResumeLayout(False)
            Me.pnlTopBar.ResumeLayout(False)
            Me.pnlTopBar.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents panelHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents btnCloseForm As System.Windows.Forms.Button
        Friend WithEvents pnlNewReservation As System.Windows.Forms.Panel
        Friend WithEvents lblSectionTitle As System.Windows.Forms.Label
        Friend WithEvents lblTableTitle As System.Windows.Forms.Label
        Friend WithEvents cmbTables As System.Windows.Forms.ComboBox
        Friend WithEvents lblCustomerNameTitle As System.Windows.Forms.Label
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomerPhoneTitle As System.Windows.Forms.Label
        Friend WithEvents txtCustomerPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblGuestsTitle As System.Windows.Forms.Label
        Friend WithEvents numGuests As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblDateTimeTitle As System.Windows.Forms.Label
        Friend WithEvents pnlDateTime As System.Windows.Forms.Panel
        Friend WithEvents dtpReservationDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpReservationTime As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDepositTitle As System.Windows.Forms.Label
        Friend WithEvents txtDeposit As System.Windows.Forms.TextBox
        Friend WithEvents lblTreasuryTitle As System.Windows.Forms.Label
        Friend WithEvents cmbTreasury As System.Windows.Forms.ComboBox
        Friend WithEvents lblNotesTitle As System.Windows.Forms.Label
        Friend WithEvents txtNotes As System.Windows.Forms.TextBox
        Friend WithEvents btnSaveReservation As System.Windows.Forms.Button
        Friend WithEvents pnlHistoryContainer As System.Windows.Forms.Panel
        Friend WithEvents dgvReservations As System.Windows.Forms.DataGridView
        Friend WithEvents colResID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTableID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colResNum As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTable As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colCustomer As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colGuests As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDeposit As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnlBottomActions As System.Windows.Forms.Panel
        Friend WithEvents btnCheckInSelected As System.Windows.Forms.Button
        Friend WithEvents btnCancelSelected As System.Windows.Forms.Button
        Friend WithEvents pnlTopBar As System.Windows.Forms.Panel
        Friend WithEvents lblTodayCount As System.Windows.Forms.Label
        Friend WithEvents lblTotalDeposits As System.Windows.Forms.Label
        Friend WithEvents lblFilterDateTitle As System.Windows.Forms.Label
        Friend WithEvents dtpFilterDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStatusTitle As System.Windows.Forms.Label
        Friend WithEvents cmbFilterStatus As System.Windows.Forms.ComboBox
        Friend WithEvents btnRefreshGrid As System.Windows.Forms.Button
    End Class
End Namespace
