Namespace Global.WindowsApp1
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmKitchenWaste
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
            Me.tabControl = New System.Windows.Forms.TabControl()
            Me.tabNewWaste = New System.Windows.Forms.TabPage()
            Me.dgvCurrentItems = New System.Windows.Forms.DataGridView()
            Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblTicketTotal = New System.Windows.Forms.Label()
            Me.btnSaveWasteTicket = New System.Windows.Forms.Button()
            Me.btnClearCurrent = New System.Windows.Forms.Button()
            Me.pnlInputs = New System.Windows.Forms.Panel()
            Me.lblDateTitle = New System.Windows.Forms.Label()
            Me.dtpDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStoreTitle = New System.Windows.Forms.Label()
            Me.cmbStores = New System.Windows.Forms.ComboBox()
            Me.lblWasteTypeTitle = New System.Windows.Forms.Label()
            Me.cmbWasteType = New System.Windows.Forms.ComboBox()
            Me.lblMaterialTitle = New System.Windows.Forms.Label()
            Me.cmbMaterials = New System.Windows.Forms.ComboBox()
            Me.lblAvailableStock = New System.Windows.Forms.Label()
            Me.lblQtyTitle = New System.Windows.Forms.Label()
            Me.txtQuantity = New System.Windows.Forms.TextBox()
            Me.lblUnitDisplay = New System.Windows.Forms.Label()
            Me.lblUnitCostTitle = New System.Windows.Forms.Label()
            Me.txtUnitCost = New System.Windows.Forms.TextBox()
            Me.lblLineTotalCost = New System.Windows.Forms.Label()
            Me.lblStaffTitle = New System.Windows.Forms.Label()
            Me.txtResponsibleStaff = New System.Windows.Forms.TextBox()
            Me.lblReasonTitle = New System.Windows.Forms.Label()
            Me.txtReason = New System.Windows.Forms.TextBox()
            Me.btnAddItem = New System.Windows.Forms.Button()
            Me.tabWasteHistory = New System.Windows.Forms.TabPage()
            Me.dgvHistory = New System.Windows.Forms.DataGridView()
            Me.pnlHistBottom = New System.Windows.Forms.Panel()
            Me.lblHistoryTotalLoss = New System.Windows.Forms.Label()
            Me.pnlFilter = New System.Windows.Forms.Panel()
            Me.lblFrom = New System.Windows.Forms.Label()
            Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
            Me.lblTo = New System.Windows.Forms.Label()
            Me.dtpTo = New System.Windows.Forms.DateTimePicker()
            Me.lblType = New System.Windows.Forms.Label()
            Me.cmbHistoryType = New System.Windows.Forms.ComboBox()
            Me.btnFilterHistory = New System.Windows.Forms.Button()
            Me.panelHeader.SuspendLayout()
            Me.tabControl.SuspendLayout()
            Me.tabNewWaste.SuspendLayout()
            CType(Me.dgvCurrentItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBottom.SuspendLayout()
            Me.pnlInputs.SuspendLayout()
            Me.tabWasteHistory.SuspendLayout()
            CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlHistBottom.SuspendLayout()
            Me.pnlFilter.SuspendLayout()
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
            Me.panelHeader.Size = New System.Drawing.Size(1150, 55)
            Me.panelHeader.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.White
            Me.lblTitle.Location = New System.Drawing.Point(15, 14)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(462, 25)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "🗑️ إدارة الهالك والتالف في المطبخ (Kitchen Waste Control)"
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
            'tabControl
            '
            Me.tabControl.Controls.Add(Me.tabNewWaste)
            Me.tabControl.Controls.Add(Me.tabWasteHistory)
            Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabControl.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.tabControl.Location = New System.Drawing.Point(0, 55)
            Me.tabControl.Name = "tabControl"
            Me.tabControl.Padding = New System.Drawing.Point(15, 6)
            Me.tabControl.SelectedIndex = 0
            Me.tabControl.Size = New System.Drawing.Size(1150, 665)
            Me.tabControl.TabIndex = 1
            '
            'tabNewWaste
            '
            Me.tabNewWaste.BackColor = System.Drawing.Color.White
            Me.tabNewWaste.Controls.Add(Me.dgvCurrentItems)
            Me.tabNewWaste.Controls.Add(Me.pnlBottom)
            Me.tabNewWaste.Controls.Add(Me.pnlInputs)
            Me.tabNewWaste.Location = New System.Drawing.Point(4, 32)
            Me.tabNewWaste.Name = "tabNewWaste"
            Me.tabNewWaste.Padding = New System.Windows.Forms.Padding(15)
            Me.tabNewWaste.Size = New System.Drawing.Size(1142, 629)
            Me.tabNewWaste.TabIndex = 0
            Me.tabNewWaste.Text = "تسجيل إذن هالك وتالف جديد"
            '
            'dgvCurrentItems
            '
            Me.dgvCurrentItems.AllowUserToAddRows = False
            Me.dgvCurrentItems.BackgroundColor = System.Drawing.Color.White
            Me.dgvCurrentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvCurrentItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colQty, Me.colUnit, Me.colCost, Me.colTotal, Me.colNotes, Me.colDelete})
            Me.dgvCurrentItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvCurrentItems.Location = New System.Drawing.Point(15, 195)
            Me.dgvCurrentItems.Name = "dgvCurrentItems"
            Me.dgvCurrentItems.ReadOnly = True
            Me.dgvCurrentItems.RowTemplate.Height = 32
            Me.dgvCurrentItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvCurrentItems.Size = New System.Drawing.Size(1112, 359)
            Me.dgvCurrentItems.TabIndex = 1
            '
            'colName
            '
            Me.colName.HeaderText = "الخامة المهدورة"
            Me.colName.Name = "colName"
            Me.colName.ReadOnly = True
            Me.colName.Width = 250
            '
            'colQty
            '
            DataGridViewCellStyle1.Format = "0.####"
            Me.colQty.DefaultCellStyle = DataGridViewCellStyle1
            Me.colQty.HeaderText = "الكمية التالفة"
            Me.colQty.Name = "colQty"
            Me.colQty.ReadOnly = True
            Me.colQty.Width = 110
            '
            'colUnit
            '
            Me.colUnit.HeaderText = "الوحدة"
            Me.colUnit.Name = "colUnit"
            Me.colUnit.ReadOnly = True
            Me.colUnit.Width = 90
            '
            'colCost
            '
            DataGridViewCellStyle2.Format = "N2"
            Me.colCost.DefaultCellStyle = DataGridViewCellStyle2
            Me.colCost.HeaderText = "تكلفة الوحدة"
            Me.colCost.Name = "colCost"
            Me.colCost.ReadOnly = True
            Me.colCost.Width = 120
            '
            'colTotal
            '
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkRed
            DataGridViewCellStyle3.Format = "N2"
            Me.colTotal.DefaultCellStyle = DataGridViewCellStyle3
            Me.colTotal.HeaderText = "إجمالي الخسارة"
            Me.colTotal.Name = "colTotal"
            Me.colTotal.ReadOnly = True
            Me.colTotal.Width = 130
            '
            'colNotes
            '
            Me.colNotes.HeaderText = "ملاحظات"
            Me.colNotes.Name = "colNotes"
            Me.colNotes.ReadOnly = True
            Me.colNotes.Width = 250
            '
            'colDelete
            '
            Me.colDelete.HeaderText = "حذف"
            Me.colDelete.Name = "colDelete"
            Me.colDelete.ReadOnly = True
            Me.colDelete.Text = "🗑️"
            Me.colDelete.UseColumnTextForButtonValue = True
            Me.colDelete.Width = 60
            '
            'pnlBottom
            '
            Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.pnlBottom.Controls.Add(Me.lblTicketTotal)
            Me.pnlBottom.Controls.Add(Me.btnSaveWasteTicket)
            Me.pnlBottom.Controls.Add(Me.btnClearCurrent)
            Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottom.Location = New System.Drawing.Point(15, 554)
            Me.pnlBottom.Name = "pnlBottom"
            Me.pnlBottom.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
            Me.pnlBottom.Size = New System.Drawing.Size(1112, 60)
            Me.pnlBottom.TabIndex = 2
            '
            'lblTicketTotal
            '
            Me.lblTicketTotal.AutoSize = True
            Me.lblTicketTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblTicketTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
            Me.lblTicketTotal.Location = New System.Drawing.Point(20, 18)
            Me.lblTicketTotal.Name = "lblTicketTotal"
            Me.lblTicketTotal.Size = New System.Drawing.Size(262, 21)
            Me.lblTicketTotal.TabIndex = 0
            Me.lblTicketTotal.Text = "إجمالي الخسائر المالية للتذكرة: 0.00 ج"
            '
            'btnSaveWasteTicket
            '
            Me.btnSaveWasteTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnSaveWasteTicket.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.btnSaveWasteTicket.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSaveWasteTicket.FlatAppearance.BorderSize = 0
            Me.btnSaveWasteTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSaveWasteTicket.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnSaveWasteTicket.ForeColor = System.Drawing.Color.White
            Me.btnSaveWasteTicket.Location = New System.Drawing.Point(20, 10)
            Me.btnSaveWasteTicket.Name = "btnSaveWasteTicket"
            Me.btnSaveWasteTicket.Size = New System.Drawing.Size(300, 40)
            Me.btnSaveWasteTicket.TabIndex = 1
            Me.btnSaveWasteTicket.Text = "💾 ترحيل وحفظ إذن الهالك وخصم المخزن"
            Me.btnSaveWasteTicket.UseVisualStyleBackColor = False
            '
            'btnClearCurrent
            '
            Me.btnClearCurrent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnClearCurrent.BackColor = System.Drawing.Color.White
            Me.btnClearCurrent.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClearCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClearCurrent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnClearCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(95, Byte), Integer))
            Me.btnClearCurrent.Location = New System.Drawing.Point(330, 10)
            Me.btnClearCurrent.Name = "btnClearCurrent"
            Me.btnClearCurrent.Size = New System.Drawing.Size(110, 40)
            Me.btnClearCurrent.TabIndex = 2
            Me.btnClearCurrent.Text = "تفريغ القائمة"
            Me.btnClearCurrent.UseVisualStyleBackColor = False
            '
            'pnlInputs
            '
            Me.pnlInputs.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.pnlInputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlInputs.Controls.Add(Me.lblDateTitle)
            Me.pnlInputs.Controls.Add(Me.dtpDate)
            Me.pnlInputs.Controls.Add(Me.lblStoreTitle)
            Me.pnlInputs.Controls.Add(Me.cmbStores)
            Me.pnlInputs.Controls.Add(Me.lblWasteTypeTitle)
            Me.pnlInputs.Controls.Add(Me.cmbWasteType)
            Me.pnlInputs.Controls.Add(Me.lblMaterialTitle)
            Me.pnlInputs.Controls.Add(Me.cmbMaterials)
            Me.pnlInputs.Controls.Add(Me.lblAvailableStock)
            Me.pnlInputs.Controls.Add(Me.lblQtyTitle)
            Me.pnlInputs.Controls.Add(Me.txtQuantity)
            Me.pnlInputs.Controls.Add(Me.lblUnitDisplay)
            Me.pnlInputs.Controls.Add(Me.lblUnitCostTitle)
            Me.pnlInputs.Controls.Add(Me.txtUnitCost)
            Me.pnlInputs.Controls.Add(Me.lblLineTotalCost)
            Me.pnlInputs.Controls.Add(Me.lblStaffTitle)
            Me.pnlInputs.Controls.Add(Me.txtResponsibleStaff)
            Me.pnlInputs.Controls.Add(Me.lblReasonTitle)
            Me.pnlInputs.Controls.Add(Me.txtReason)
            Me.pnlInputs.Controls.Add(Me.btnAddItem)
            Me.pnlInputs.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlInputs.Location = New System.Drawing.Point(15, 15)
            Me.pnlInputs.Name = "pnlInputs"
            Me.pnlInputs.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlInputs.Size = New System.Drawing.Size(1112, 180)
            Me.pnlInputs.TabIndex = 0
            '
            'lblDateTitle
            '
            Me.lblDateTitle.AutoSize = True
            Me.lblDateTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblDateTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.lblDateTitle.Location = New System.Drawing.Point(20, 15)
            Me.lblDateTitle.Name = "lblDateTitle"
            Me.lblDateTitle.Size = New System.Drawing.Size(68, 15)
            Me.lblDateTitle.TabIndex = 0
            Me.lblDateTitle.Text = "تاريخ الهالك:"
            '
            'dtpDate
            '
            Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDate.Location = New System.Drawing.Point(105, 12)
            Me.dtpDate.Name = "dtpDate"
            Me.dtpDate.Size = New System.Drawing.Size(140, 25)
            Me.dtpDate.TabIndex = 1
            '
            'lblStoreTitle
            '
            Me.lblStoreTitle.AutoSize = True
            Me.lblStoreTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblStoreTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.lblStoreTitle.Location = New System.Drawing.Point(265, 15)
            Me.lblStoreTitle.Name = "lblStoreTitle"
            Me.lblStoreTitle.Size = New System.Drawing.Size(46, 15)
            Me.lblStoreTitle.TabIndex = 2
            Me.lblStoreTitle.Text = "المخزن:"
            '
            'cmbStores
            '
            Me.cmbStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStores.Location = New System.Drawing.Point(325, 12)
            Me.cmbStores.Name = "cmbStores"
            Me.cmbStores.Size = New System.Drawing.Size(160, 25)
            Me.cmbStores.TabIndex = 3
            '
            'lblWasteTypeTitle
            '
            Me.lblWasteTypeTitle.AutoSize = True
            Me.lblWasteTypeTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblWasteTypeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.lblWasteTypeTitle.Location = New System.Drawing.Point(505, 15)
            Me.lblWasteTypeTitle.Name = "lblWasteTypeTitle"
            Me.lblWasteTypeTitle.Size = New System.Drawing.Size(107, 15)
            Me.lblWasteTypeTitle.TabIndex = 4
            Me.lblWasteTypeTitle.Text = "نوع وتصنيف الهالك:"
            '
            'cmbWasteType
            '
            Me.cmbWasteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbWasteType.Items.AddRange(New Object() {"خامة تالفة / تالف إعداد", "سوء إعداد / خطأ طهي", "انتهاء صلاحية", "وجبة تالفة"})
            Me.cmbWasteType.Location = New System.Drawing.Point(635, 12)
            Me.cmbWasteType.Name = "cmbWasteType"
            Me.cmbWasteType.Size = New System.Drawing.Size(200, 25)
            Me.cmbWasteType.TabIndex = 5
            '
            'lblMaterialTitle
            '
            Me.lblMaterialTitle.AutoSize = True
            Me.lblMaterialTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblMaterialTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.lblMaterialTitle.Location = New System.Drawing.Point(20, 58)
            Me.lblMaterialTitle.Name = "lblMaterialTitle"
            Me.lblMaterialTitle.Size = New System.Drawing.Size(82, 15)
            Me.lblMaterialTitle.TabIndex = 6
            Me.lblMaterialTitle.Text = "الخامة المهدورة:"
            '
            'cmbMaterials
            '
            Me.cmbMaterials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbMaterials.Location = New System.Drawing.Point(105, 55)
            Me.cmbMaterials.Name = "cmbMaterials"
            Me.cmbMaterials.Size = New System.Drawing.Size(280, 25)
            Me.cmbMaterials.TabIndex = 7
            '
            'lblAvailableStock
            '
            Me.lblAvailableStock.AutoSize = True
            Me.lblAvailableStock.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblAvailableStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(95, Byte), Integer))
            Me.lblAvailableStock.Location = New System.Drawing.Point(400, 58)
            Me.lblAvailableStock.Name = "lblAvailableStock"
            Me.lblAvailableStock.Size = New System.Drawing.Size(76, 15)
            Me.lblAvailableStock.TabIndex = 8
            Me.lblAvailableStock.Text = "الرصيد: 0.00"
            '
            'lblQtyTitle
            '
            Me.lblQtyTitle.AutoSize = True
            Me.lblQtyTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblQtyTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.lblQtyTitle.Location = New System.Drawing.Point(520, 58)
            Me.lblQtyTitle.Name = "lblQtyTitle"
            Me.lblQtyTitle.Size = New System.Drawing.Size(74, 15)
            Me.lblQtyTitle.TabIndex = 9
            Me.lblQtyTitle.Text = "الكمية التالفة:"
            '
            'txtQuantity
            '
            Me.txtQuantity.Location = New System.Drawing.Point(605, 55)
            Me.txtQuantity.Name = "txtQuantity"
            Me.txtQuantity.Size = New System.Drawing.Size(80, 25)
            Me.txtQuantity.TabIndex = 10
            Me.txtQuantity.Text = "1"
            '
            'lblUnitDisplay
            '
            Me.lblUnitDisplay.AutoSize = True
            Me.lblUnitDisplay.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblUnitDisplay.ForeColor = System.Drawing.Color.Gray
            Me.lblUnitDisplay.Location = New System.Drawing.Point(690, 58)
            Me.lblUnitDisplay.Name = "lblUnitDisplay"
            Me.lblUnitDisplay.Size = New System.Drawing.Size(38, 15)
            Me.lblUnitDisplay.TabIndex = 11
            Me.lblUnitDisplay.Text = "الوحدة"
            '
            'lblUnitCostTitle
            '
            Me.lblUnitCostTitle.AutoSize = True
            Me.lblUnitCostTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblUnitCostTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.lblUnitCostTitle.Location = New System.Drawing.Point(750, 58)
            Me.lblUnitCostTitle.Name = "lblUnitCostTitle"
            Me.lblUnitCostTitle.Size = New System.Drawing.Size(68, 15)
            Me.lblUnitCostTitle.TabIndex = 12
            Me.lblUnitCostTitle.Text = "تكلفة الوحدة:"
            '
            'txtUnitCost
            '
            Me.txtUnitCost.Location = New System.Drawing.Point(830, 55)
            Me.txtUnitCost.Name = "txtUnitCost"
            Me.txtUnitCost.Size = New System.Drawing.Size(80, 25)
            Me.txtUnitCost.TabIndex = 13
            Me.txtUnitCost.Text = "0.00"
            '
            'lblLineTotalCost
            '
            Me.lblLineTotalCost.AutoSize = True
            Me.lblLineTotalCost.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblLineTotalCost.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.lblLineTotalCost.Location = New System.Drawing.Point(930, 57)
            Me.lblLineTotalCost.Name = "lblLineTotalCost"
            Me.lblLineTotalCost.Size = New System.Drawing.Size(107, 19)
            Me.lblLineTotalCost.TabIndex = 14
            Me.lblLineTotalCost.Text = "الخسارة: 0.00 ج"
            '
            'lblStaffTitle
            '
            Me.lblStaffTitle.AutoSize = True
            Me.lblStaffTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblStaffTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.lblStaffTitle.Location = New System.Drawing.Point(20, 102)
            Me.lblStaffTitle.Name = "lblStaffTitle"
            Me.lblStaffTitle.Size = New System.Drawing.Size(91, 15)
            Me.lblStaffTitle.TabIndex = 15
            Me.lblStaffTitle.Text = "الموظف المسؤول:"
            '
            'txtResponsibleStaff
            '
            Me.txtResponsibleStaff.Location = New System.Drawing.Point(125, 99)
            Me.txtResponsibleStaff.Name = "txtResponsibleStaff"
            Me.txtResponsibleStaff.Size = New System.Drawing.Size(200, 25)
            Me.txtResponsibleStaff.TabIndex = 16
            '
            'lblReasonTitle
            '
            Me.lblReasonTitle.AutoSize = True
            Me.lblReasonTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblReasonTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.lblReasonTitle.Location = New System.Drawing.Point(345, 102)
            Me.lblReasonTitle.Name = "lblReasonTitle"
            Me.lblReasonTitle.Size = New System.Drawing.Size(126, 15)
            Me.lblReasonTitle.TabIndex = 17
            Me.lblReasonTitle.Text = "سبب التلف / الملاحظات:"
            '
            'txtReason
            '
            Me.txtReason.Location = New System.Drawing.Point(490, 99)
            Me.txtReason.Name = "txtReason"
            Me.txtReason.Size = New System.Drawing.Size(380, 25)
            Me.txtReason.TabIndex = 18
            '
            'btnAddItem
            '
            Me.btnAddItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnAddItem.FlatAppearance.BorderSize = 0
            Me.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddItem.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnAddItem.ForeColor = System.Drawing.Color.White
            Me.btnAddItem.Location = New System.Drawing.Point(890, 96)
            Me.btnAddItem.Name = "btnAddItem"
            Me.btnAddItem.Size = New System.Drawing.Size(140, 34)
            Me.btnAddItem.TabIndex = 19
            Me.btnAddItem.Text = "➕ إضافة للقائمة"
            Me.btnAddItem.UseVisualStyleBackColor = False
            '
            'tabWasteHistory
            '
            Me.tabWasteHistory.BackColor = System.Drawing.Color.White
            Me.tabWasteHistory.Controls.Add(Me.dgvHistory)
            Me.tabWasteHistory.Controls.Add(Me.pnlHistBottom)
            Me.tabWasteHistory.Controls.Add(Me.pnlFilter)
            Me.tabWasteHistory.Location = New System.Drawing.Point(4, 32)
            Me.tabWasteHistory.Name = "tabWasteHistory"
            Me.tabWasteHistory.Padding = New System.Windows.Forms.Padding(15)
            Me.tabWasteHistory.Size = New System.Drawing.Size(1142, 629)
            Me.tabWasteHistory.TabIndex = 1
            Me.tabWasteHistory.Text = "سجل وتقارير خسائر الهالك"
            '
            'dgvHistory
            '
            Me.dgvHistory.AllowUserToAddRows = False
            Me.dgvHistory.BackgroundColor = System.Drawing.Color.White
            Me.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvHistory.Location = New System.Drawing.Point(15, 75)
            Me.dgvHistory.Name = "dgvHistory"
            Me.dgvHistory.ReadOnly = True
            Me.dgvHistory.RowTemplate.Height = 32
            Me.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvHistory.Size = New System.Drawing.Size(1112, 489)
            Me.dgvHistory.TabIndex = 1
            '
            'pnlHistBottom
            '
            Me.pnlHistBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.pnlHistBottom.Controls.Add(Me.lblHistoryTotalLoss)
            Me.pnlHistBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlHistBottom.Location = New System.Drawing.Point(15, 564)
            Me.pnlHistBottom.Name = "pnlHistBottom"
            Me.pnlHistBottom.Padding = New System.Windows.Forms.Padding(15, 12, 15, 12)
            Me.pnlHistBottom.Size = New System.Drawing.Size(1112, 50)
            Me.pnlHistBottom.TabIndex = 2
            '
            'lblHistoryTotalLoss
            '
            Me.lblHistoryTotalLoss.AutoSize = True
            Me.lblHistoryTotalLoss.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblHistoryTotalLoss.ForeColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
            Me.lblHistoryTotalLoss.Location = New System.Drawing.Point(20, 12)
            Me.lblHistoryTotalLoss.Name = "lblHistoryTotalLoss"
            Me.lblHistoryTotalLoss.Size = New System.Drawing.Size(342, 21)
            Me.lblHistoryTotalLoss.TabIndex = 0
            Me.lblHistoryTotalLoss.Text = "إجمالي الخسائر المالية للهالك خلال الفترة: 0.00 ج"
            '
            'pnlFilter
            '
            Me.pnlFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlFilter.Controls.Add(Me.lblFrom)
            Me.pnlFilter.Controls.Add(Me.dtpFrom)
            Me.pnlFilter.Controls.Add(Me.lblTo)
            Me.pnlFilter.Controls.Add(Me.dtpTo)
            Me.pnlFilter.Controls.Add(Me.lblType)
            Me.pnlFilter.Controls.Add(Me.cmbHistoryType)
            Me.pnlFilter.Controls.Add(Me.btnFilterHistory)
            Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilter.Location = New System.Drawing.Point(15, 15)
            Me.pnlFilter.Name = "pnlFilter"
            Me.pnlFilter.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlFilter.Size = New System.Drawing.Size(1112, 60)
            Me.pnlFilter.TabIndex = 0
            '
            'lblFrom
            '
            Me.lblFrom.AutoSize = True
            Me.lblFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblFrom.Location = New System.Drawing.Point(15, 18)
            Me.lblFrom.Name = "lblFrom"
            Me.lblFrom.Size = New System.Drawing.Size(55, 15)
            Me.lblFrom.TabIndex = 0
            Me.lblFrom.Text = "من تاريخ:"
            '
            'dtpFrom
            '
            Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFrom.Location = New System.Drawing.Point(80, 15)
            Me.dtpFrom.Name = "dtpFrom"
            Me.dtpFrom.Size = New System.Drawing.Size(130, 25)
            Me.dtpFrom.TabIndex = 1
            '
            'lblTo
            '
            Me.lblTo.AutoSize = True
            Me.lblTo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTo.Location = New System.Drawing.Point(225, 18)
            Me.lblTo.Name = "lblTo"
            Me.lblTo.Size = New System.Drawing.Size(53, 15)
            Me.lblTo.TabIndex = 2
            Me.lblTo.Text = "إلى تاريخ:"
            '
            'dtpTo
            '
            Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpTo.Location = New System.Drawing.Point(290, 15)
            Me.dtpTo.Name = "dtpTo"
            Me.dtpTo.Size = New System.Drawing.Size(130, 25)
            Me.dtpTo.TabIndex = 3
            '
            'lblType
            '
            Me.lblType.AutoSize = True
            Me.lblType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblType.Location = New System.Drawing.Point(435, 18)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(63, 15)
            Me.lblType.TabIndex = 4
            Me.lblType.Text = "نوع الهالك:"
            '
            'cmbHistoryType
            '
            Me.cmbHistoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbHistoryType.Items.AddRange(New Object() {"كل الأنواع", "خامة تالفة / تالف إعداد", "سوء إعداد / خطأ طهي", "انتهاء صلاحية", "وجبة تالفة"})
            Me.cmbHistoryType.Location = New System.Drawing.Point(510, 15)
            Me.cmbHistoryType.Name = "cmbHistoryType"
            Me.cmbHistoryType.Size = New System.Drawing.Size(160, 25)
            Me.cmbHistoryType.TabIndex = 5
            '
            'btnFilterHistory
            '
            Me.btnFilterHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
            Me.btnFilterHistory.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnFilterHistory.FlatAppearance.BorderSize = 0
            Me.btnFilterHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnFilterHistory.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnFilterHistory.ForeColor = System.Drawing.Color.White
            Me.btnFilterHistory.Location = New System.Drawing.Point(690, 14)
            Me.btnFilterHistory.Name = "btnFilterHistory"
            Me.btnFilterHistory.Size = New System.Drawing.Size(110, 32)
            Me.btnFilterHistory.TabIndex = 6
            Me.btnFilterHistory.Text = "🔍 بحث وفلترة"
            Me.btnFilterHistory.UseVisualStyleBackColor = False
            '
            'FrmKitchenWaste
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1150, 720)
            Me.Controls.Add(Me.tabControl)
            Me.Controls.Add(Me.panelHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.MinimumSize = New Size(950, 600)
            Me.Name = "FrmKitchenWaste"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "إدارة الهالك والتالف في المطبخ (Kitchen Waste Control)"
            Me.panelHeader.ResumeLayout(False)
            Me.panelHeader.PerformLayout()
            Me.tabControl.ResumeLayout(False)
            Me.tabNewWaste.ResumeLayout(False)
            CType(Me.dgvCurrentItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBottom.ResumeLayout(False)
            Me.pnlBottom.PerformLayout()
            Me.pnlInputs.ResumeLayout(False)
            Me.pnlInputs.PerformLayout()
            Me.tabWasteHistory.ResumeLayout(False)
            CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlHistBottom.ResumeLayout(False)
            Me.pnlHistBottom.PerformLayout()
            Me.pnlFilter.ResumeLayout(False)
            Me.pnlFilter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents panelHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents btnCloseForm As System.Windows.Forms.Button
        Friend WithEvents tabControl As System.Windows.Forms.TabControl
        Friend WithEvents tabNewWaste As System.Windows.Forms.TabPage
        Friend WithEvents tabWasteHistory As System.Windows.Forms.TabPage
        Friend WithEvents pnlInputs As System.Windows.Forms.Panel
        Friend WithEvents lblDateTitle As System.Windows.Forms.Label
        Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStoreTitle As System.Windows.Forms.Label
        Friend WithEvents cmbStores As System.Windows.Forms.ComboBox
        Friend WithEvents lblWasteTypeTitle As System.Windows.Forms.Label
        Friend WithEvents cmbWasteType As System.Windows.Forms.ComboBox
        Friend WithEvents lblMaterialTitle As System.Windows.Forms.Label
        Friend WithEvents cmbMaterials As System.Windows.Forms.ComboBox
        Friend WithEvents lblAvailableStock As System.Windows.Forms.Label
        Friend WithEvents lblQtyTitle As System.Windows.Forms.Label
        Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
        Friend WithEvents lblUnitDisplay As System.Windows.Forms.Label
        Friend WithEvents lblUnitCostTitle As System.Windows.Forms.Label
        Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
        Friend WithEvents lblLineTotalCost As System.Windows.Forms.Label
        Friend WithEvents lblStaffTitle As System.Windows.Forms.Label
        Friend WithEvents txtResponsibleStaff As System.Windows.Forms.TextBox
        Friend WithEvents lblReasonTitle As System.Windows.Forms.Label
        Friend WithEvents txtReason As System.Windows.Forms.TextBox
        Friend WithEvents btnAddItem As System.Windows.Forms.Button
        Friend WithEvents dgvCurrentItems As System.Windows.Forms.DataGridView
        Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colUnit As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colCost As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDelete As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblTicketTotal As System.Windows.Forms.Label
        Friend WithEvents btnSaveWasteTicket As System.Windows.Forms.Button
        Friend WithEvents btnClearCurrent As System.Windows.Forms.Button
        Friend WithEvents dgvHistory As System.Windows.Forms.DataGridView
        Friend WithEvents pnlHistBottom As System.Windows.Forms.Panel
        Friend WithEvents lblHistoryTotalLoss As System.Windows.Forms.Label
        Friend WithEvents pnlFilter As System.Windows.Forms.Panel
        Friend WithEvents lblFrom As System.Windows.Forms.Label
        Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblTo As System.Windows.Forms.Label
        Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents cmbHistoryType As System.Windows.Forms.ComboBox
        Friend WithEvents btnFilterHistory As System.Windows.Forms.Button
    End Class
End Namespace
