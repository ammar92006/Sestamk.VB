Namespace Global.WindowsApp1
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmSplitBill
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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.panelHeader = New System.Windows.Forms.Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblSubTitle = New System.Windows.Forms.Label()
            Me.btnCloseForm = New System.Windows.Forms.Button()
            Me.pnlSplitControls = New System.Windows.Forms.Panel()
            Me.rbEqualSplit = New System.Windows.Forms.RadioButton()
            Me.lblGuestsCount = New System.Windows.Forms.Label()
            Me.numGuests = New System.Windows.Forms.NumericUpDown()
            Me.rbCustomSplit = New System.Windows.Forms.RadioButton()
            Me.btnApplySplit = New System.Windows.Forms.Button()
            Me.pnlKpiContainer = New System.Windows.Forms.Panel()
            Me.pnlKpiTotal = New System.Windows.Forms.Panel()
            Me.lblKpiTotalTitle = New System.Windows.Forms.Label()
            Me.lblKpiTotal = New System.Windows.Forms.Label()
            Me.pnlKpiPerPerson = New System.Windows.Forms.Panel()
            Me.lblKpiPerPersonTitle = New System.Windows.Forms.Label()
            Me.lblKpiPerPerson = New System.Windows.Forms.Label()
            Me.pnlKpiPaid = New System.Windows.Forms.Panel()
            Me.lblKpiPaidTitle = New System.Windows.Forms.Label()
            Me.lblKpiPaid = New System.Windows.Forms.Label()
            Me.pnlKpiRemaining = New System.Windows.Forms.Panel()
            Me.lblKpiRemainingTitle = New System.Windows.Forms.Label()
            Me.lblKpiRemaining = New System.Windows.Forms.Label()
            Me.pnlBottomBar = New System.Windows.Forms.Panel()
            Me.btnPayAllCash = New System.Windows.Forms.Button()
            Me.pnlSpacer = New System.Windows.Forms.Panel()
            Me.btnPrintAllReceipts = New System.Windows.Forms.Button()
            Me.btnConfirmSettlement = New System.Windows.Forms.Button()
            Me.pnlSpacerLeft = New System.Windows.Forms.Panel()
            Me.btnCancelForm = New System.Windows.Forms.Button()
            Me.dgvSplits = New System.Windows.Forms.DataGridView()
            Me.colIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colGuestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colShare = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMethod = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.colPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRemaining = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colBtnPay = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.colBtnPrint = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.panelHeader.SuspendLayout()
            Me.pnlSplitControls.SuspendLayout()
            CType(Me.numGuests, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlKpiContainer.SuspendLayout()
            Me.pnlKpiTotal.SuspendLayout()
            Me.pnlKpiPerPerson.SuspendLayout()
            Me.pnlKpiPaid.SuspendLayout()
            Me.pnlKpiRemaining.SuspendLayout()
            Me.pnlBottomBar.SuspendLayout()
            CType(Me.dgvSplits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'panelHeader
            '
            Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
            Me.panelHeader.Controls.Add(Me.lblTitle)
            Me.panelHeader.Controls.Add(Me.lblSubTitle)
            Me.panelHeader.Controls.Add(Me.btnCloseForm)
            Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelHeader.Location = New System.Drawing.Point(0, 0)
            Me.panelHeader.Name = "panelHeader"
            Me.panelHeader.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
            Me.panelHeader.Size = New System.Drawing.Size(1000, 60)
            Me.panelHeader.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.White
            Me.lblTitle.Location = New System.Drawing.Point(15, 8)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(370, 25)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "👥 تقسيم الفاتورة وسداد الحصص (Split Bill)"
            '
            'lblSubTitle
            '
            Me.lblSubTitle.AutoSize = True
            Me.lblSubTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
            Me.lblSubTitle.Location = New System.Drawing.Point(15, 33)
            Me.lblSubTitle.Name = "lblSubTitle"
            Me.lblSubTitle.Size = New System.Drawing.Size(380, 17)
            Me.lblSubTitle.TabIndex = 1
            Me.lblSubTitle.Text = "الطاولة: طلب عام   |   رقم الفاتورة: فاتورة حالية   |   إجمالي الفاتورة: 0.00 ج.م"
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
            Me.btnCloseForm.Location = New System.Drawing.Point(15, 12)
            Me.btnCloseForm.Name = "btnCloseForm"
            Me.btnCloseForm.Size = New System.Drawing.Size(40, 34)
            Me.btnCloseForm.TabIndex = 2
            Me.btnCloseForm.Text = "✕"
            Me.btnCloseForm.UseVisualStyleBackColor = False
            '
            'pnlSplitControls
            '
            Me.pnlSplitControls.BackColor = System.Drawing.Color.White
            Me.pnlSplitControls.Controls.Add(Me.rbEqualSplit)
            Me.pnlSplitControls.Controls.Add(Me.lblGuestsCount)
            Me.pnlSplitControls.Controls.Add(Me.numGuests)
            Me.pnlSplitControls.Controls.Add(Me.rbCustomSplit)
            Me.pnlSplitControls.Controls.Add(Me.btnApplySplit)
            Me.pnlSplitControls.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlSplitControls.Location = New System.Drawing.Point(0, 60)
            Me.pnlSplitControls.Name = "pnlSplitControls"
            Me.pnlSplitControls.Padding = New System.Windows.Forms.Padding(15, 12, 15, 10)
            Me.pnlSplitControls.Size = New System.Drawing.Size(1000, 65)
            Me.pnlSplitControls.TabIndex = 1
            '
            'rbEqualSplit
            '
            Me.rbEqualSplit.AutoSize = True
            Me.rbEqualSplit.Checked = True
            Me.rbEqualSplit.Cursor = System.Windows.Forms.Cursors.Hand
            Me.rbEqualSplit.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.rbEqualSplit.Location = New System.Drawing.Point(20, 18)
            Me.rbEqualSplit.Name = "rbEqualSplit"
            Me.rbEqualSplit.Size = New System.Drawing.Size(182, 23)
            Me.rbEqualSplit.TabIndex = 0
            Me.rbEqualSplit.TabStop = True
            Me.rbEqualSplit.Text = "تقسيم بالتساوي على الأفراد"
            Me.rbEqualSplit.UseVisualStyleBackColor = True
            '
            'lblGuestsCount
            '
            Me.lblGuestsCount.AutoSize = True
            Me.lblGuestsCount.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblGuestsCount.Location = New System.Drawing.Point(235, 20)
            Me.lblGuestsCount.Name = "lblGuestsCount"
            Me.lblGuestsCount.Size = New System.Drawing.Size(76, 19)
            Me.lblGuestsCount.TabIndex = 1
            Me.lblGuestsCount.Text = "عدد الأفراد:"
            '
            'numGuests
            '
            Me.numGuests.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.numGuests.Location = New System.Drawing.Point(320, 16)
            Me.numGuests.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
            Me.numGuests.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
            Me.numGuests.Name = "numGuests"
            Me.numGuests.Size = New System.Drawing.Size(70, 27)
            Me.numGuests.TabIndex = 2
            Me.numGuests.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.numGuests.Value = New Decimal(New Integer() {2, 0, 0, 0})
            '
            'rbCustomSplit
            '
            Me.rbCustomSplit.AutoSize = True
            Me.rbCustomSplit.Cursor = System.Windows.Forms.Cursors.Hand
            Me.rbCustomSplit.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.rbCustomSplit.Location = New System.Drawing.Point(420, 18)
            Me.rbCustomSplit.Name = "rbCustomSplit"
            Me.rbCustomSplit.Size = New System.Drawing.Size(186, 23)
            Me.rbCustomSplit.TabIndex = 3
            Me.rbCustomSplit.Text = "تقسيم يدوي / مبالغ مخصصة"
            Me.rbCustomSplit.UseVisualStyleBackColor = True
            '
            'btnApplySplit
            '
            Me.btnApplySplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnApplySplit.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnApplySplit.FlatAppearance.BorderSize = 0
            Me.btnApplySplit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnApplySplit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnApplySplit.ForeColor = System.Drawing.Color.White
            Me.btnApplySplit.Location = New System.Drawing.Point(650, 15)
            Me.btnApplySplit.Name = "btnApplySplit"
            Me.btnApplySplit.Size = New System.Drawing.Size(140, 34)
            Me.btnApplySplit.TabIndex = 4
            Me.btnApplySplit.Text = "⚡ توزيع الحصص"
            Me.btnApplySplit.UseVisualStyleBackColor = False
            '
            'pnlKpiContainer
            '
            Me.pnlKpiContainer.Controls.Add(Me.pnlKpiTotal)
            Me.pnlKpiContainer.Controls.Add(Me.pnlKpiPerPerson)
            Me.pnlKpiContainer.Controls.Add(Me.pnlKpiPaid)
            Me.pnlKpiContainer.Controls.Add(Me.pnlKpiRemaining)
            Me.pnlKpiContainer.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlKpiContainer.Location = New System.Drawing.Point(0, 125)
            Me.pnlKpiContainer.Name = "pnlKpiContainer"
            Me.pnlKpiContainer.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
            Me.pnlKpiContainer.Size = New System.Drawing.Size(1000, 75)
            Me.pnlKpiContainer.TabIndex = 2
            '
            'pnlKpiTotal
            '
            Me.pnlKpiTotal.BackColor = System.Drawing.Color.White
            Me.pnlKpiTotal.Controls.Add(Me.lblKpiTotalTitle)
            Me.pnlKpiTotal.Controls.Add(Me.lblKpiTotal)
            Me.pnlKpiTotal.Location = New System.Drawing.Point(15, 10)
            Me.pnlKpiTotal.Name = "pnlKpiTotal"
            Me.pnlKpiTotal.Padding = New System.Windows.Forms.Padding(8)
            Me.pnlKpiTotal.Size = New System.Drawing.Size(225, 55)
            Me.pnlKpiTotal.TabIndex = 0
            '
            'lblKpiTotalTitle
            '
            Me.lblKpiTotalTitle.AutoSize = True
            Me.lblKpiTotalTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblKpiTotalTitle.Location = New System.Drawing.Point(8, 6)
            Me.lblKpiTotalTitle.Name = "lblKpiTotalTitle"
            Me.lblKpiTotalTitle.Size = New System.Drawing.Size(78, 15)
            Me.lblKpiTotalTitle.TabIndex = 0
            Me.lblKpiTotalTitle.Text = "إجمالي الفاتورة"
            '
            'lblKpiTotal
            '
            Me.lblKpiTotal.AutoSize = True
            Me.lblKpiTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.lblKpiTotal.Location = New System.Drawing.Point(8, 24)
            Me.lblKpiTotal.Name = "lblKpiTotal"
            Me.lblKpiTotal.Size = New System.Drawing.Size(61, 21)
            Me.lblKpiTotal.TabIndex = 1
            Me.lblKpiTotal.Text = "0.00 ج"
            '
            'pnlKpiPerPerson
            '
            Me.pnlKpiPerPerson.BackColor = System.Drawing.Color.White
            Me.pnlKpiPerPerson.Controls.Add(Me.lblKpiPerPersonTitle)
            Me.pnlKpiPerPerson.Controls.Add(Me.lblKpiPerPerson)
            Me.pnlKpiPerPerson.Location = New System.Drawing.Point(255, 10)
            Me.pnlKpiPerPerson.Name = "pnlKpiPerPerson"
            Me.pnlKpiPerPerson.Padding = New System.Windows.Forms.Padding(8)
            Me.pnlKpiPerPerson.Size = New System.Drawing.Size(225, 55)
            Me.pnlKpiPerPerson.TabIndex = 1
            '
            'lblKpiPerPersonTitle
            '
            Me.lblKpiPerPersonTitle.AutoSize = True
            Me.lblKpiPerPersonTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblKpiPerPersonTitle.Location = New System.Drawing.Point(8, 6)
            Me.lblKpiPerPersonTitle.Name = "lblKpiPerPersonTitle"
            Me.lblKpiPerPersonTitle.Size = New System.Drawing.Size(63, 15)
            Me.lblKpiPerPersonTitle.TabIndex = 0
            Me.lblKpiPerPersonTitle.Text = "نصيب الفرد"
            '
            'lblKpiPerPerson
            '
            Me.lblKpiPerPerson.AutoSize = True
            Me.lblKpiPerPerson.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiPerPerson.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblKpiPerPerson.Location = New System.Drawing.Point(8, 24)
            Me.lblKpiPerPerson.Name = "lblKpiPerPerson"
            Me.lblKpiPerPerson.Size = New System.Drawing.Size(61, 21)
            Me.lblKpiPerPerson.TabIndex = 1
            Me.lblKpiPerPerson.Text = "0.00 ج"
            '
            'pnlKpiPaid
            '
            Me.pnlKpiPaid.BackColor = System.Drawing.Color.White
            Me.pnlKpiPaid.Controls.Add(Me.lblKpiPaidTitle)
            Me.pnlKpiPaid.Controls.Add(Me.lblKpiPaid)
            Me.pnlKpiPaid.Location = New System.Drawing.Point(495, 10)
            Me.pnlKpiPaid.Name = "pnlKpiPaid"
            Me.pnlKpiPaid.Padding = New System.Windows.Forms.Padding(8)
            Me.pnlKpiPaid.Size = New System.Drawing.Size(225, 55)
            Me.pnlKpiPaid.TabIndex = 2
            '
            'lblKpiPaidTitle
            '
            Me.lblKpiPaidTitle.AutoSize = True
            Me.lblKpiPaidTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblKpiPaidTitle.Location = New System.Drawing.Point(8, 6)
            Me.lblKpiPaidTitle.Name = "lblKpiPaidTitle"
            Me.lblKpiPaidTitle.Size = New System.Drawing.Size(76, 15)
            Me.lblKpiPaidTitle.TabIndex = 0
            Me.lblKpiPaidTitle.Text = "إجمالي المسدد"
            '
            'lblKpiPaid
            '
            Me.lblKpiPaid.AutoSize = True
            Me.lblKpiPaid.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiPaid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.lblKpiPaid.Location = New System.Drawing.Point(8, 24)
            Me.lblKpiPaid.Name = "lblKpiPaid"
            Me.lblKpiPaid.Size = New System.Drawing.Size(61, 21)
            Me.lblKpiPaid.TabIndex = 1
            Me.lblKpiPaid.Text = "0.00 ج"
            '
            'pnlKpiRemaining
            '
            Me.pnlKpiRemaining.BackColor = System.Drawing.Color.White
            Me.pnlKpiRemaining.Controls.Add(Me.lblKpiRemainingTitle)
            Me.pnlKpiRemaining.Controls.Add(Me.lblKpiRemaining)
            Me.pnlKpiRemaining.Location = New System.Drawing.Point(735, 10)
            Me.pnlKpiRemaining.Name = "pnlKpiRemaining"
            Me.pnlKpiRemaining.Padding = New System.Windows.Forms.Padding(8)
            Me.pnlKpiRemaining.Size = New System.Drawing.Size(225, 55)
            Me.pnlKpiRemaining.TabIndex = 3
            '
            'lblKpiRemainingTitle
            '
            Me.lblKpiRemainingTitle.AutoSize = True
            Me.lblKpiRemainingTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblKpiRemainingTitle.Location = New System.Drawing.Point(8, 6)
            Me.lblKpiRemainingTitle.Name = "lblKpiRemainingTitle"
            Me.lblKpiRemainingTitle.Size = New System.Drawing.Size(72, 15)
            Me.lblKpiRemainingTitle.TabIndex = 0
            Me.lblKpiRemainingTitle.Text = "المتبقي الكلي"
            '
            'lblKpiRemaining
            '
            Me.lblKpiRemaining.AutoSize = True
            Me.lblKpiRemaining.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiRemaining.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
            Me.lblKpiRemaining.Location = New System.Drawing.Point(8, 24)
            Me.lblKpiRemaining.Name = "lblKpiRemaining"
            Me.lblKpiRemaining.Size = New System.Drawing.Size(61, 21)
            Me.lblKpiRemaining.TabIndex = 1
            Me.lblKpiRemaining.Text = "0.00 ج"
            '
            'pnlBottomBar
            '
            Me.pnlBottomBar.BackColor = System.Drawing.Color.White
            Me.pnlBottomBar.Controls.Add(Me.btnPayAllCash)
            Me.pnlBottomBar.Controls.Add(Me.pnlSpacer)
            Me.pnlBottomBar.Controls.Add(Me.btnPrintAllReceipts)
            Me.pnlBottomBar.Controls.Add(Me.btnConfirmSettlement)
            Me.pnlBottomBar.Controls.Add(Me.pnlSpacerLeft)
            Me.pnlBottomBar.Controls.Add(Me.btnCancelForm)
            Me.pnlBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottomBar.Location = New System.Drawing.Point(0, 615)
            Me.pnlBottomBar.Name = "pnlBottomBar"
            Me.pnlBottomBar.Padding = New System.Windows.Forms.Padding(15, 12, 15, 12)
            Me.pnlBottomBar.Size = New System.Drawing.Size(1000, 65)
            Me.pnlBottomBar.TabIndex = 3
            '
            'btnPayAllCash
            '
            Me.btnPayAllCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(233, Byte), Integer))
            Me.btnPayAllCash.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPayAllCash.Dock = System.Windows.Forms.DockStyle.Right
            Me.btnPayAllCash.FlatAppearance.BorderSize = 0
            Me.btnPayAllCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPayAllCash.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnPayAllCash.ForeColor = System.Drawing.Color.White
            Me.btnPayAllCash.Location = New System.Drawing.Point(785, 12)
            Me.btnPayAllCash.Name = "btnPayAllCash"
            Me.btnPayAllCash.Size = New System.Drawing.Size(200, 41)
            Me.btnPayAllCash.TabIndex = 0
            Me.btnPayAllCash.Text = "💵 سداد جميع الحصص نقداً"
            Me.btnPayAllCash.UseVisualStyleBackColor = False
            '
            'pnlSpacer
            '
            Me.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlSpacer.Location = New System.Drawing.Point(775, 12)
            Me.pnlSpacer.Name = "pnlSpacer"
            Me.pnlSpacer.Size = New System.Drawing.Size(10, 41)
            Me.pnlSpacer.TabIndex = 1
            '
            'btnPrintAllReceipts
            '
            Me.btnPrintAllReceipts.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnPrintAllReceipts.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPrintAllReceipts.Dock = System.Windows.Forms.DockStyle.Right
            Me.btnPrintAllReceipts.FlatAppearance.BorderSize = 0
            Me.btnPrintAllReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPrintAllReceipts.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnPrintAllReceipts.ForeColor = System.Drawing.Color.White
            Me.btnPrintAllReceipts.Location = New System.Drawing.Point(585, 12)
            Me.btnPrintAllReceipts.Name = "btnPrintAllReceipts"
            Me.btnPrintAllReceipts.Size = New System.Drawing.Size(190, 41)
            Me.btnPrintAllReceipts.TabIndex = 2
            Me.btnPrintAllReceipts.Text = "🖨️ طباعة إيصالات للجميع"
            Me.btnPrintAllReceipts.UseVisualStyleBackColor = False
            '
            'btnConfirmSettlement
            '
            Me.btnConfirmSettlement.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            Me.btnConfirmSettlement.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnConfirmSettlement.Dock = System.Windows.Forms.DockStyle.Left
            Me.btnConfirmSettlement.Enabled = False
            Me.btnConfirmSettlement.FlatAppearance.BorderSize = 0
            Me.btnConfirmSettlement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnConfirmSettlement.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnConfirmSettlement.ForeColor = System.Drawing.Color.White
            Me.btnConfirmSettlement.Location = New System.Drawing.Point(140, 12)
            Me.btnConfirmSettlement.Name = "btnConfirmSettlement"
            Me.btnConfirmSettlement.Size = New System.Drawing.Size(230, 41)
            Me.btnConfirmSettlement.TabIndex = 3
            Me.btnConfirmSettlement.Text = "✅ اعتماد السداد وإنهاء الفاتورة"
            Me.btnConfirmSettlement.UseVisualStyleBackColor = False
            '
            'pnlSpacerLeft
            '
            Me.pnlSpacerLeft.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlSpacerLeft.Location = New System.Drawing.Point(130, 12)
            Me.pnlSpacerLeft.Name = "pnlSpacerLeft"
            Me.pnlSpacerLeft.Size = New System.Drawing.Size(10, 41)
            Me.pnlSpacerLeft.TabIndex = 4
            '
            'btnCancelForm
            '
            Me.btnCancelForm.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCancelForm.Dock = System.Windows.Forms.DockStyle.Left
            Me.btnCancelForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancelForm.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnCancelForm.Location = New System.Drawing.Point(15, 12)
            Me.btnCancelForm.Name = "btnCancelForm"
            Me.btnCancelForm.Size = New System.Drawing.Size(115, 41)
            Me.btnCancelForm.TabIndex = 5
            Me.btnCancelForm.Text = "✕ إلغاء / تراجع"
            Me.btnCancelForm.UseVisualStyleBackColor = True
            '
            'dgvSplits
            '
            Me.dgvSplits.AllowUserToAddRows = False
            Me.dgvSplits.AllowUserToDeleteRows = False
            Me.dgvSplits.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvSplits.ColumnHeadersHeight = 42
            Me.dgvSplits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvSplits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIndex, Me.colGuestName, Me.colShare, Me.colMethod, Me.colPaid, Me.colRemaining, Me.colStatus, Me.colBtnPay, Me.colBtnPrint})
            Me.dgvSplits.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvSplits.EnableHeadersVisualStyles = False
            Me.dgvSplits.Location = New System.Drawing.Point(0, 200)
            Me.dgvSplits.Name = "dgvSplits"
            Me.dgvSplits.RowHeadersVisible = False
            Me.dgvSplits.RowTemplate.Height = 42
            Me.dgvSplits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dgvSplits.Size = New System.Drawing.Size(1000, 415)
            Me.dgvSplits.TabIndex = 4
            '
            'colIndex
            '
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.colIndex.DefaultCellStyle = DataGridViewCellStyle1
            Me.colIndex.HeaderText = "#"
            Me.colIndex.Name = "colIndex"
            Me.colIndex.ReadOnly = True
            Me.colIndex.Width = 45
            '
            'colGuestName
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.colGuestName.DefaultCellStyle = DataGridViewCellStyle2
            Me.colGuestName.HeaderText = "اسم الضيف / الفرد"
            Me.colGuestName.Name = "colGuestName"
            Me.colGuestName.Width = 160
            '
            'colShare
            '
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle3.Format = "N2"
            Me.colShare.DefaultCellStyle = DataGridViewCellStyle3
            Me.colShare.HeaderText = "المبلغ المطلوب (ج)"
            Me.colShare.Name = "colShare"
            Me.colShare.ReadOnly = True
            Me.colShare.Width = 130
            '
            'colMethod
            '
            Me.colMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.colMethod.HeaderText = "طريقة الدفع"
            Me.colMethod.Items.AddRange(New Object() {"نقدي (كاش)", "بطاقة / فيزا", "أخرى"})
            Me.colMethod.Name = "colMethod"
            Me.colMethod.Width = 130
            '
            'colPaid
            '
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            DataGridViewCellStyle4.Format = "N2"
            Me.colPaid.DefaultCellStyle = DataGridViewCellStyle4
            Me.colPaid.HeaderText = "المسدد (ج)"
            Me.colPaid.Name = "colPaid"
            Me.colPaid.ReadOnly = True
            Me.colPaid.Width = 120
            '
            'colRemaining
            '
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
            DataGridViewCellStyle5.Format = "N2"
            Me.colRemaining.DefaultCellStyle = DataGridViewCellStyle5
            Me.colRemaining.HeaderText = "المتبقي (ج)"
            Me.colRemaining.Name = "colRemaining"
            Me.colRemaining.ReadOnly = True
            Me.colRemaining.Width = 120
            '
            'colStatus
            '
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.colStatus.DefaultCellStyle = DataGridViewCellStyle6
            Me.colStatus.HeaderText = "الحالة"
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            Me.colStatus.Width = 110
            '
            'colBtnPay
            '
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
            Me.colBtnPay.DefaultCellStyle = DataGridViewCellStyle7
            Me.colBtnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.colBtnPay.HeaderText = "سداد الحصة"
            Me.colBtnPay.Name = "colBtnPay"
            Me.colBtnPay.Text = "💵 سداد"
            Me.colBtnPay.UseColumnTextForButtonValue = True
            Me.colBtnPay.Width = 90
            '
            'colBtnPrint
            '
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(241, Byte), Integer))
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
            Me.colBtnPrint.DefaultCellStyle = DataGridViewCellStyle8
            Me.colBtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.colBtnPrint.HeaderText = "إيصال"
            Me.colBtnPrint.Name = "colBtnPrint"
            Me.colBtnPrint.Text = "🖨️ طباعة"
            Me.colBtnPrint.UseColumnTextForButtonValue = True
            Me.colBtnPrint.Width = 80
            '
            'FrmSplitBill
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1000, 680)
            Me.Controls.Add(Me.dgvSplits)
            Me.Controls.Add(Me.pnlBottomBar)
            Me.Controls.Add(Me.pnlKpiContainer)
            Me.Controls.Add(Me.pnlSplitControls)
            Me.Controls.Add(Me.panelHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.MinimumSize = New Size(900, 580)
            Me.Name = "FrmSplitBill"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "تقسيم الفاتورة (Split Bill)"
            Me.panelHeader.ResumeLayout(False)
            Me.panelHeader.PerformLayout()
            Me.pnlSplitControls.ResumeLayout(False)
            Me.pnlSplitControls.PerformLayout()
            CType(Me.numGuests, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlKpiContainer.ResumeLayout(False)
            Me.pnlKpiTotal.ResumeLayout(False)
            Me.pnlKpiTotal.PerformLayout()
            Me.pnlKpiPerPerson.ResumeLayout(False)
            Me.pnlKpiPerPerson.PerformLayout()
            Me.pnlKpiPaid.ResumeLayout(False)
            Me.pnlKpiPaid.PerformLayout()
            Me.pnlKpiRemaining.ResumeLayout(False)
            Me.pnlKpiRemaining.PerformLayout()
            Me.pnlBottomBar.ResumeLayout(False)
            CType(Me.dgvSplits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents panelHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubTitle As System.Windows.Forms.Label
        Friend WithEvents btnCloseForm As System.Windows.Forms.Button
        Friend WithEvents pnlSplitControls As System.Windows.Forms.Panel
        Friend WithEvents rbEqualSplit As System.Windows.Forms.RadioButton
        Friend WithEvents lblGuestsCount As System.Windows.Forms.Label
        Friend WithEvents numGuests As System.Windows.Forms.NumericUpDown
        Friend WithEvents rbCustomSplit As System.Windows.Forms.RadioButton
        Friend WithEvents btnApplySplit As System.Windows.Forms.Button
        Friend WithEvents pnlKpiContainer As System.Windows.Forms.Panel
        Friend WithEvents pnlKpiTotal As System.Windows.Forms.Panel
        Friend WithEvents lblKpiTotalTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiTotal As System.Windows.Forms.Label
        Friend WithEvents pnlKpiPerPerson As System.Windows.Forms.Panel
        Friend WithEvents lblKpiPerPersonTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiPerPerson As System.Windows.Forms.Label
        Friend WithEvents pnlKpiPaid As System.Windows.Forms.Panel
        Friend WithEvents lblKpiPaidTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiPaid As System.Windows.Forms.Label
        Friend WithEvents pnlKpiRemaining As System.Windows.Forms.Panel
        Friend WithEvents lblKpiRemainingTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiRemaining As System.Windows.Forms.Label
        Friend WithEvents pnlBottomBar As System.Windows.Forms.Panel
        Friend WithEvents btnPayAllCash As System.Windows.Forms.Button
        Friend WithEvents pnlSpacer As System.Windows.Forms.Panel
        Friend WithEvents btnPrintAllReceipts As System.Windows.Forms.Button
        Friend WithEvents btnConfirmSettlement As System.Windows.Forms.Button
        Friend WithEvents pnlSpacerLeft As System.Windows.Forms.Panel
        Friend WithEvents btnCancelForm As System.Windows.Forms.Button
        Friend WithEvents dgvSplits As System.Windows.Forms.DataGridView
        Friend WithEvents colIndex As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colGuestName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colShare As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMethod As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents colPaid As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRemaining As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colBtnPay As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents colBtnPrint As System.Windows.Forms.DataGridViewButtonColumn
    End Class
End Namespace
