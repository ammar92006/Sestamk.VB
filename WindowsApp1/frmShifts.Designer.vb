<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShifts
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShifts))
        Me.dgvShiftsHistory = New System.Windows.Forms.DataGridView()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.lblTotalIncomes = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblCashDifference = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtClosingCash = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblExpectedCash = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalExpenses = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalSales = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblOpeningCash = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbWorkShift = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnCloseShift = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClearFields = New Guna.UI2.WinForms.Guna2Button()
        Me.btnOpenShift = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtOpeningCash = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cmbOpenUser = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblOpenUserTitle = New System.Windows.Forms.Label()
        Me.cmbCloseUser = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblCloseUserTitle = New System.Windows.Forms.Label()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.btnAddWorkShiftForm = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.btnSuspendShift = New Guna.UI2.WinForms.Guna2Button()
        Me.btnResumeShift = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.dgvShiftsHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvShiftsHistory
        '
        Me.dgvShiftsHistory.AllowUserToResizeColumns = False
        Me.dgvShiftsHistory.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvShiftsHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShiftsHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvShiftsHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShiftsHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShiftsHistory.Location = New System.Drawing.Point(0, 436)
        Me.dgvShiftsHistory.Name = "dgvShiftsHistory"
        Me.dgvShiftsHistory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvShiftsHistory.RowTemplate.Height = 35
        Me.dgvShiftsHistory.Size = New System.Drawing.Size(1331, 345)
        Me.dgvShiftsHistory.TabIndex = 44
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalIncomes)
        Me.grpCustomerInfo.Controls.Add(Me.Label11)
        Me.grpCustomerInfo.Controls.Add(Me.Label9)
        Me.grpCustomerInfo.Controls.Add(Me.txtNotes)
        Me.grpCustomerInfo.Controls.Add(Me.lblCashDifference)
        Me.grpCustomerInfo.Controls.Add(Me.Label10)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.txtClosingCash)
        Me.grpCustomerInfo.Controls.Add(Me.lblExpectedCash)
        Me.grpCustomerInfo.Controls.Add(Me.Label8)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalExpenses)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.lblTotalSales)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.lblOpeningCash)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.btnAddWorkShiftForm)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.cmbWorkShift)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2Panel1)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.cmbSearchField)
        Me.grpCustomerInfo.Controls.Add(Me.lstSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.txtSearch)
        Me.grpCustomerInfo.Controls.Add(Me.txtOpeningCash)
        Me.grpCustomerInfo.Controls.Add(Me.cmbOpenUser)
        Me.grpCustomerInfo.Controls.Add(Me.lblOpenUserTitle)
        Me.grpCustomerInfo.Controls.Add(Me.cmbCloseUser)
        Me.grpCustomerInfo.Controls.Add(Me.lblCloseUserTitle)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 70)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1331, 375)
        Me.grpCustomerInfo.TabIndex = 43
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalIncomes
        '
        Me.lblTotalIncomes.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalIncomes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIncomes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalIncomes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalIncomes.Location = New System.Drawing.Point(939, 270)
        Me.lblTotalIncomes.Name = "lblTotalIncomes"
        Me.lblTotalIncomes.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalIncomes.TabIndex = 5641
        Me.lblTotalIncomes.Text = "0.00"
        Me.lblTotalIncomes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(1195, 270)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(143, 36)
        Me.Label11.TabIndex = 5640
        Me.Label11.Text = "إجمالي المقبوضات"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(805, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 36)
        Me.Label9.TabIndex = 5639
        Me.Label9.Text = "ملاحظات الإغلاق"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(550, 270)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(250, 42)
        Me.txtNotes.TabIndex = 5638
        Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCashDifference
        '
        Me.lblCashDifference.BackColor = System.Drawing.Color.Transparent
        Me.lblCashDifference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCashDifference.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCashDifference.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblCashDifference.Location = New System.Drawing.Point(550, 225)
        Me.lblCashDifference.Name = "lblCashDifference"
        Me.lblCashDifference.Size = New System.Drawing.Size(250, 36)
        Me.lblCashDifference.TabIndex = 5637
        Me.lblCashDifference.Text = "0.00"
        Me.lblCashDifference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(802, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 36)
        Me.Label10.TabIndex = 5636
        Me.Label10.Text = "العجز"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCloseUser
        '
        Me.cmbCloseUser.BackColor = System.Drawing.Color.Transparent
        Me.cmbCloseUser.BorderRadius = 6
        Me.cmbCloseUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCloseUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCloseUser.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbCloseUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbCloseUser.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbCloseUser.ForeColor = System.Drawing.Color.Black
        Me.cmbCloseUser.ItemHeight = 30
        Me.cmbCloseUser.Location = New System.Drawing.Point(550, 180)
        Me.cmbCloseUser.Name = "cmbCloseUser"
        Me.cmbCloseUser.Size = New System.Drawing.Size(250, 36)
        Me.cmbCloseUser.TabIndex = 5635
        Me.cmbCloseUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCloseUserTitle
        '
        Me.lblCloseUserTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblCloseUserTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCloseUserTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblCloseUserTitle.Location = New System.Drawing.Point(802, 180)
        Me.lblCloseUserTitle.Name = "lblCloseUserTitle"
        Me.lblCloseUserTitle.Size = New System.Drawing.Size(127, 36)
        Me.lblCloseUserTitle.TabIndex = 5636
        Me.lblCloseUserTitle.Text = "مسؤول الإغلاق"
        Me.lblCloseUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(802, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 36)
        Me.Label6.TabIndex = 5635
        Me.Label6.Text = "النقدية المجرودة فعلياً *"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtClosingCash
        '
        Me.txtClosingCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClosingCash.BorderRadius = 6
        Me.txtClosingCash.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClosingCash.DefaultText = ""
        Me.txtClosingCash.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtClosingCash.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtClosingCash.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtClosingCash.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtClosingCash.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtClosingCash.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtClosingCash.ForeColor = System.Drawing.Color.Black
        Me.txtClosingCash.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtClosingCash.Location = New System.Drawing.Point(550, 135)
        Me.txtClosingCash.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtClosingCash.Name = "txtClosingCash"
        Me.txtClosingCash.PlaceholderText = ""
        Me.txtClosingCash.SelectedText = ""
        Me.txtClosingCash.Size = New System.Drawing.Size(250, 36)
        Me.txtClosingCash.TabIndex = 5634
        Me.txtClosingCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblExpectedCash
        '
        Me.lblExpectedCash.BackColor = System.Drawing.Color.Transparent
        Me.lblExpectedCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExpectedCash.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblExpectedCash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblExpectedCash.Location = New System.Drawing.Point(550, 92)
        Me.lblExpectedCash.Name = "lblExpectedCash"
        Me.lblExpectedCash.Size = New System.Drawing.Size(250, 36)
        Me.lblExpectedCash.TabIndex = 5633
        Me.lblExpectedCash.Text = "0.00"
        Me.lblExpectedCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(802, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 36)
        Me.Label8.TabIndex = 5632
        Me.Label8.Text = "المبلغ"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalExpenses
        '
        Me.lblTotalExpenses.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalExpenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalExpenses.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalExpenses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalExpenses.Location = New System.Drawing.Point(939, 225)
        Me.lblTotalExpenses.Name = "lblTotalExpenses"
        Me.lblTotalExpenses.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalExpenses.TabIndex = 5631
        Me.lblTotalExpenses.Text = "0.00"
        Me.lblTotalExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1195, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 36)
        Me.Label3.TabIndex = 5630
        Me.Label3.Text = "إجمالي المصروفات"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalSales
        '
        Me.lblTotalSales.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalSales.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalSales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTotalSales.Location = New System.Drawing.Point(939, 180)
        Me.lblTotalSales.Name = "lblTotalSales"
        Me.lblTotalSales.Size = New System.Drawing.Size(250, 36)
        Me.lblTotalSales.TabIndex = 5629
        Me.lblTotalSales.Text = "0.00"
        Me.lblTotalSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1195, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 36)
        Me.Label4.TabIndex = 5628
        Me.Label4.Text = "مبيعات النقدية"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOpeningCash
        '
        Me.lblOpeningCash.BackColor = System.Drawing.Color.Transparent
        Me.lblOpeningCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpeningCash.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblOpeningCash.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblOpeningCash.Location = New System.Drawing.Point(939, 135)
        Me.lblOpeningCash.Name = "lblOpeningCash"
        Me.lblOpeningCash.Size = New System.Drawing.Size(250, 36)
        Me.lblOpeningCash.TabIndex = 5627
        Me.lblOpeningCash.Text = "0.00"
        Me.lblOpeningCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblOpeningCash.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(1195, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 36)
        Me.Label7.TabIndex = 5626
        Me.Label7.Text = "العهدة الافتتاحية"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Visible = False
        '
        'cmbOpenUser
        '
        Me.cmbOpenUser.BackColor = System.Drawing.Color.Transparent
        Me.cmbOpenUser.BorderRadius = 6
        Me.cmbOpenUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOpenUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOpenUser.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbOpenUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbOpenUser.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbOpenUser.ForeColor = System.Drawing.Color.Black
        Me.cmbOpenUser.ItemHeight = 30
        Me.cmbOpenUser.Location = New System.Drawing.Point(939, 135)
        Me.cmbOpenUser.Name = "cmbOpenUser"
        Me.cmbOpenUser.Size = New System.Drawing.Size(250, 36)
        Me.cmbOpenUser.TabIndex = 4
        Me.cmbOpenUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOpenUserTitle
        '
        Me.lblOpenUserTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblOpenUserTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblOpenUserTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblOpenUserTitle.Location = New System.Drawing.Point(1195, 135)
        Me.lblOpenUserTitle.Name = "lblOpenUserTitle"
        Me.lblOpenUserTitle.Size = New System.Drawing.Size(143, 36)
        Me.lblOpenUserTitle.TabIndex = 5626
        Me.lblOpenUserTitle.Text = "مسؤول الفتح"
        Me.lblOpenUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Label5.Text = "اختيار الوردية *"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbWorkShift
        '
        Me.cmbWorkShift.BackColor = System.Drawing.Color.Transparent
        Me.cmbWorkShift.BorderRadius = 6
        Me.cmbWorkShift.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbWorkShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWorkShift.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbWorkShift.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbWorkShift.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbWorkShift.ForeColor = System.Drawing.Color.Black
        Me.cmbWorkShift.ItemHeight = 30
        Me.cmbWorkShift.Location = New System.Drawing.Point(939, 45)
        Me.cmbWorkShift.Name = "cmbWorkShift"
        Me.cmbWorkShift.Size = New System.Drawing.Size(250, 36)
        Me.cmbWorkShift.TabIndex = 5621
        Me.cmbWorkShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.Controls.Add(Me.btnResumeShift)
        Me.Guna2Panel1.Controls.Add(Me.btnSuspendShift)
        Me.Guna2Panel1.Controls.Add(Me.btnCloseShift)
        Me.Guna2Panel1.Controls.Add(Me.btnRefresh)
        Me.Guna2Panel1.Controls.Add(Me.btnClearFields)
        Me.Guna2Panel1.Controls.Add(Me.btnOpenShift)
        Me.Guna2Panel1.Location = New System.Drawing.Point(146, 316)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1103, 46)
        Me.Guna2Panel1.TabIndex = 5600
        '
        'btnCloseShift
        '
        Me.btnCloseShift.BorderRadius = 6
        Me.btnCloseShift.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCloseShift.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCloseShift.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCloseShift.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCloseShift.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnCloseShift.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCloseShift.ForeColor = System.Drawing.Color.White
        Me.btnCloseShift.Location = New System.Drawing.Point(604, 5)
        Me.btnCloseShift.Name = "btnCloseShift"
        Me.btnCloseShift.Size = New System.Drawing.Size(134, 38)
        Me.btnCloseShift.TabIndex = 5627
        Me.btnCloseShift.Text = "إغلاق الوردية"
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
        Me.btnRefresh.Location = New System.Drawing.Point(11, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(134, 38)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "تحديث"
        '
        'btnClearFields
        '
        Me.btnClearFields.BorderRadius = 6
        Me.btnClearFields.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFields.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFields.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearFields.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearFields.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearFields.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearFields.ForeColor = System.Drawing.Color.White
        Me.btnClearFields.Location = New System.Drawing.Point(783, 5)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(134, 38)
        Me.btnClearFields.TabIndex = 3
        Me.btnClearFields.Text = "تفريغ الحقول"
        '
        'btnOpenShift
        '
        Me.btnOpenShift.BorderRadius = 6
        Me.btnOpenShift.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnOpenShift.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnOpenShift.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnOpenShift.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnOpenShift.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnOpenShift.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnOpenShift.ForeColor = System.Drawing.Color.White
        Me.btnOpenShift.Location = New System.Drawing.Point(962, 5)
        Me.btnOpenShift.Name = "btnOpenShift"
        Me.btnOpenShift.Size = New System.Drawing.Size(134, 38)
        Me.btnOpenShift.TabIndex = 5624
        Me.btnOpenShift.Text = "فتح الوردية"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1195, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 36)
        Me.Label1.TabIndex = 5583
        Me.Label1.Text = "بداية الوردية"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.lstSuggestions.Size = New System.Drawing.Size(436, 140)
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
        'txtOpeningCash
        '
        Me.txtOpeningCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpeningCash.BorderRadius = 6
        Me.txtOpeningCash.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOpeningCash.DefaultText = ""
        Me.txtOpeningCash.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtOpeningCash.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtOpeningCash.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOpeningCash.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOpeningCash.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtOpeningCash.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtOpeningCash.ForeColor = System.Drawing.Color.Black
        Me.txtOpeningCash.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtOpeningCash.Location = New System.Drawing.Point(939, 90)
        Me.txtOpeningCash.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtOpeningCash.Name = "txtOpeningCash"
        Me.txtOpeningCash.PlaceholderText = ""
        Me.txtOpeningCash.SelectedText = ""
        Me.txtOpeningCash.Size = New System.Drawing.Size(250, 36)
        Me.txtOpeningCash.TabIndex = 3
        Me.txtOpeningCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.panelHeader.TabIndex = 42
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
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(643, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(97, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الورديات"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnAddWorkShiftForm
        '
        Me.btnAddWorkShiftForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddWorkShiftForm.BorderRadius = 6
        Me.btnAddWorkShiftForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddWorkShiftForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddWorkShiftForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddWorkShiftForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddWorkShiftForm.FillColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnAddWorkShiftForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddWorkShiftForm.ForeColor = System.Drawing.Color.White
        Me.btnAddWorkShiftForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddWorkShiftForm.Location = New System.Drawing.Point(895, 45)
        Me.btnAddWorkShiftForm.Name = "btnAddWorkShiftForm"
        Me.btnAddWorkShiftForm.Size = New System.Drawing.Size(36, 36)
        Me.btnAddWorkShiftForm.TabIndex = 5623
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'btnSuspendShift
        '
        Me.btnSuspendShift.BorderRadius = 6
        Me.btnSuspendShift.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSuspendShift.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSuspendShift.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSuspendShift.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSuspendShift.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSuspendShift.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSuspendShift.ForeColor = System.Drawing.Color.White
        Me.btnSuspendShift.Location = New System.Drawing.Point(425, 5)
        Me.btnSuspendShift.Name = "btnSuspendShift"
        Me.btnSuspendShift.Size = New System.Drawing.Size(134, 38)
        Me.btnSuspendShift.TabIndex = 5628
        Me.btnSuspendShift.Text = "تعليق الوردية"
        '
        'btnResumeShift
        '
        Me.btnResumeShift.BorderRadius = 6
        Me.btnResumeShift.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnResumeShift.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnResumeShift.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnResumeShift.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnResumeShift.FillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnResumeShift.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnResumeShift.ForeColor = System.Drawing.Color.White
        Me.btnResumeShift.Location = New System.Drawing.Point(190, 5)
        Me.btnResumeShift.Name = "btnResumeShift"
        Me.btnResumeShift.Size = New System.Drawing.Size(190, 38)
        Me.btnResumeShift.TabIndex = 5629
        Me.btnResumeShift.Text = "استكمال الوردية المعلقة"
        '
        'frmShifts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1331, 781)
        Me.Controls.Add(Me.dgvShiftsHistory)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmShifts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmShifts"
        CType(Me.dgvShiftsHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvShiftsHistory As DataGridView
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClearFields As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtOpeningCash As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnAddWorkShiftForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbWorkShift As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnCloseShift As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label7 As Label
    Friend WithEvents btnOpenShift As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblExpectedCash As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTotalExpenses As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalSales As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblOpeningCash As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtClosingCash As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblCashDifference As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblTotalIncomes As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnSuspendShift As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents btnResumeShift As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cmbOpenUser As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblOpenUserTitle As Label
    Friend WithEvents cmbCloseUser As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblCloseUserTitle As Label
End Class
