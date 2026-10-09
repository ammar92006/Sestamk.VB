<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSupplierTransactions
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmSupplierTransactions))
        Me.SuspendLayout()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Height = 70
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.headerTitle = New System.Windows.Forms.Label()
        Me.headerTitle.Name = "headerTitle"
        Me.headerTitle.Text = "كشف حساب المورد وسندات السداد"
        Me.headerTitle.Size = New System.Drawing.Size(100, 38)
        Me.headerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.headerTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.headerTitle.ForeColor = System.Drawing.Color.White
        Me.headerTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_close = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_close.Name = "btn_close"
        Me.btn_close.FillColor = System.Drawing.Color.Transparent
        Me.btn_close.HoverState.FillColor = System.Drawing.Color.FromArgb(239, 68, 68)
        Me.btn_close.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_close.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_close.Location = New System.Drawing.Point(15, 17)
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_max = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_max.Name = "btn_max"
        Me.btn_max.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox
        Me.btn_max.FillColor = System.Drawing.Color.Transparent
        Me.btn_max.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_max.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_max.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_max.Location = New System.Drawing.Point(59, 17)
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_min = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_min.Name = "btn_min"
        Me.btn_min.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btn_min.FillColor = System.Drawing.Color.Transparent
        Me.btn_min.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_min.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_min.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_min.Location = New System.Drawing.Point(103, 17)
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.filters = New System.Windows.Forms.FlowLayoutPanel()
        Me.filters.Name = "filters"
        Me.filters.Dock = System.Windows.Forms.DockStyle.Top
        Me.filters.Height = 155
        Me.filters.Padding = New System.Windows.Forms.Padding(16, 12, 16, 6)
        Me.filters.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.filters.BackColor = System.Drawing.Color.FromArgb(247, 248, 250)
        Me.payment = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.payment.Name = "payment"
        Me.payment.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.payment.Height = 150
        Me.payment.Text = "تسجيل سداد للمورد"
        Me.payment.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.payment.CustomBorderColor = System.Drawing.Color.FromArgb(214, 219, 223)
        Me.payment.ForeColor = System.Drawing.Color.FromArgb(40,40,40)
        Me.paymentFields = New System.Windows.Forms.FlowLayoutPanel()
        Me.paymentFields.Name = "paymentFields"
        Me.paymentFields.BackColor = System.Drawing.Color.Transparent
        Me.paymentFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paymentFields.Padding = New System.Windows.Forms.Padding(12, 45, 12, 8)
        Me.paymentFields.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.supplierCaption = New System.Windows.Forms.Label()
        Me.supplierCaption.Name = "supplierCaption"
        Me.supplierCaption.Text = "المورد"
        Me.supplierCaption.Size = New System.Drawing.Size(70, 38)
        Me.supplierCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.supplierCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.supplierCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.fromCaption = New System.Windows.Forms.Label()
        Me.fromCaption.Name = "fromCaption"
        Me.fromCaption.Text = "من تاريخ"
        Me.fromCaption.Size = New System.Drawing.Size(80, 38)
        Me.fromCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.fromCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.fromCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.toCaption = New System.Windows.Forms.Label()
        Me.toCaption.Name = "toCaption"
        Me.toCaption.Text = "إلى تاريخ"
        Me.toCaption.Size = New System.Drawing.Size(80, 38)
        Me.toCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.toCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.toCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.typeCaption = New System.Windows.Forms.Label()
        Me.typeCaption.Name = "typeCaption"
        Me.typeCaption.Text = "نوع الحركة"
        Me.typeCaption.Size = New System.Drawing.Size(90, 38)
        Me.typeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.typeCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.typeCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.treasuryCaption = New System.Windows.Forms.Label()
        Me.treasuryCaption.Name = "treasuryCaption"
        Me.treasuryCaption.Text = "الخزينة"
        Me.treasuryCaption.Size = New System.Drawing.Size(70, 38)
        Me.treasuryCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.treasuryCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.treasuryCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.methodCaption = New System.Windows.Forms.Label()
        Me.methodCaption.Name = "methodCaption"
        Me.methodCaption.Text = "طريقة الدفع"
        Me.methodCaption.Size = New System.Drawing.Size(90, 38)
        Me.methodCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.methodCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.methodCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.amountCaption = New System.Windows.Forms.Label()
        Me.amountCaption.Name = "amountCaption"
        Me.amountCaption.Text = "المبلغ"
        Me.amountCaption.Size = New System.Drawing.Size(65, 38)
        Me.amountCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.amountCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.amountCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.notesCaption = New System.Windows.Forms.Label()
        Me.notesCaption.Name = "notesCaption"
        Me.notesCaption.Text = "البيان"
        Me.notesCaption.Size = New System.Drawing.Size(65, 38)
        Me.notesCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.notesCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.notesCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.supplierBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.supplierBox.Name = "supplierBox"
        Me.supplierBox.Size = New System.Drawing.Size(260,36)
        Me.supplierBox.BorderRadius = 6
        Me.supplierBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.supplierBox.Font = New System.Drawing.Font("Segoe UI",10.0!)
        Me.supplierBox.ForeColor = System.Drawing.Color.Black
        Me.supplierBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.supplierBox.ItemHeight = 30
        Me.treasuryBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.treasuryBox.Name = "treasuryBox"
        Me.treasuryBox.Size = New System.Drawing.Size(215,36)
        Me.treasuryBox.BorderRadius = 6
        Me.treasuryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.treasuryBox.Font = New System.Drawing.Font("Segoe UI",10.0!)
        Me.treasuryBox.ForeColor = System.Drawing.Color.Black
        Me.treasuryBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.treasuryBox.ItemHeight = 30
        Me.methodBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.methodBox.Name = "methodBox"
        Me.methodBox.Size = New System.Drawing.Size(140,36)
        Me.methodBox.BorderRadius = 6
        Me.methodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.methodBox.Font = New System.Drawing.Font("Segoe UI",10.0!)
        Me.methodBox.ForeColor = System.Drawing.Color.Black
        Me.methodBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.methodBox.ItemHeight = 30
        Me.typeBox = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.typeBox.Name = "typeBox"
        Me.typeBox.Size = New System.Drawing.Size(210,36)
        Me.typeBox.BorderRadius = 6
        Me.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.typeBox.Font = New System.Drawing.Font("Segoe UI",10.0!)
        Me.typeBox.ForeColor = System.Drawing.Color.Black
        Me.typeBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.typeBox.ItemHeight = 30
        Me.fromPicker = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.fromPicker.Name = "fromPicker"
        Me.fromPicker.Size = New System.Drawing.Size(190,36)
        Me.fromPicker.BorderRadius = 6
        Me.fromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.fromPicker.FillColor = System.Drawing.Color.White
        Me.fromPicker.Font = New System.Drawing.Font("Segoe UI",10.0!)
        Me.fromPicker.Checked = True
        Me.toPicker = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.toPicker.Name = "toPicker"
        Me.toPicker.Size = New System.Drawing.Size(190,36)
        Me.toPicker.BorderRadius = 6
        Me.toPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.toPicker.FillColor = System.Drawing.Color.White
        Me.toPicker.Font = New System.Drawing.Font("Segoe UI",10.0!)
        Me.toPicker.Checked = True
        Me.amountBox = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.amountBox.Name = "amountBox"
        Me.amountBox.Size = New System.Drawing.Size(160,36)
        Me.amountBox.DecimalPlaces = 2
        Me.amountBox.Maximum = 999999999D
        Me.amountBox.BorderRadius = 6
        Me.amountBox.Font = New System.Drawing.Font("Segoe UI",11.0!)
        Me.amountBox.ForeColor = System.Drawing.Color.Black
        Me.notesBox = New Guna.UI2.WinForms.Guna2TextBox()
        Me.notesBox.Name = "notesBox"
        Me.notesBox.Size = New System.Drawing.Size(245,36)
        Me.notesBox.MaxLength = 250
        Me.notesBox.BorderRadius = 6
        Me.notesBox.Font = New System.Drawing.Font("Segoe UI",10.0!)
        Me.notesBox.ForeColor = System.Drawing.Color.Black
        Me.btnRefreshStatement = New Guna.UI2.WinForms.Guna2Button()
        Me.btnRefreshStatement.Name = "btnRefreshStatement"
        Me.btnRefreshStatement.Text = "عرض الكشف"
        Me.btnRefreshStatement.Size = New System.Drawing.Size(158, 38)
        Me.btnRefreshStatement.BorderRadius = 6
        Me.btnRefreshStatement.FillColor = System.Drawing.Color.FromArgb(43, 132, 185)
        Me.btnRefreshStatement.ForeColor = System.Drawing.Color.White
        Me.btnRefreshStatement.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintStatement = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrintStatement.Name = "btnPrintStatement"
        Me.btnPrintStatement.Text = "طباعة الكشف"
        Me.btnPrintStatement.Size = New System.Drawing.Size(158, 38)
        Me.btnPrintStatement.BorderRadius = 6
        Me.btnPrintStatement.FillColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.btnPrintStatement.ForeColor = System.Drawing.Color.White
        Me.btnPrintStatement.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportStatement = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExportStatement.Name = "btnExportStatement"
        Me.btnExportStatement.Text = "تصدير Excel"
        Me.btnExportStatement.Size = New System.Drawing.Size(158, 38)
        Me.btnExportStatement.BorderRadius = 6
        Me.btnExportStatement.FillColor = System.Drawing.Color.FromArgb(22, 160, 133)
        Me.btnExportStatement.ForeColor = System.Drawing.Color.White
        Me.btnExportStatement.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddPayment = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddPayment.Name = "btnAddPayment"
        Me.btnAddPayment.Text = "تسجيل سداد"
        Me.btnAddPayment.Size = New System.Drawing.Size(180, 38)
        Me.btnAddPayment.BorderRadius = 6
        Me.btnAddPayment.FillColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnAddPayment.ForeColor = System.Drawing.Color.White
        Me.btnAddPayment.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.balanceLabel = New System.Windows.Forms.Label()
        Me.balanceLabel.Name = "balanceLabel"
        Me.balanceLabel.Text = "الرصيد الحالي: 0.00"
        Me.balanceLabel.Size = New System.Drawing.Size(400, 38)
        Me.balanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.balanceLabel.Font = New System.Drawing.Font("Segoe UI",12.0!,System.Drawing.FontStyle.Bold)
        Me.balanceLabel.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.balanceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.balanceLabel.BackColor = System.Drawing.Color.White
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.grid.Name = "grid"
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.BackgroundColor = System.Drawing.Color.White
        Me.grid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grid.ReadOnly = True
        Me.grid.AllowUserToAddRows = False
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.borderless = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.borderless.ContainerControl = Me
        Me.borderless.BorderRadius = 8
        Me.borderless.DockIndicatorTransparencyValue = 0.6R
        Me.borderless.TransparentWhileDrag = False
        Me.panelHeader.Controls.AddRange(New System.Windows.Forms.Control() {Me.headerTitle, Me.btn_close, Me.btn_max, Me.btn_min})
        Me.filters.Controls.AddRange(New System.Windows.Forms.Control() {Me.supplierCaption, Me.supplierBox, Me.fromCaption, Me.fromPicker, Me.toCaption, Me.toPicker, Me.typeCaption, Me.typeBox, Me.btnRefreshStatement, Me.btnPrintStatement, Me.btnExportStatement, Me.balanceLabel})
        Me.paymentFields.Controls.AddRange(New System.Windows.Forms.Control() {Me.treasuryCaption, Me.treasuryBox, Me.methodCaption, Me.methodBox, Me.amountCaption, Me.amountBox, Me.notesCaption, Me.notesBox, Me.btnAddPayment})
        Me.payment.Controls.AddRange(New System.Windows.Forms.Control() {Me.paymentFields})
        Me.headerTitle.SendToBack()
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grid, Me.payment, Me.filters, Me.panelHeader})
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1380, 819)
        Me.MinimumSize = New System.Drawing.Size(1100, 700)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Name = "FrmSupplierTransactions"
        Me.Text = "كشف حساب المورد وسندات السداد"
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents headerTitle As System.Windows.Forms.Label
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents filters As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents payment As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents paymentFields As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents supplierCaption As System.Windows.Forms.Label
    Friend WithEvents fromCaption As System.Windows.Forms.Label
    Friend WithEvents toCaption As System.Windows.Forms.Label
    Friend WithEvents typeCaption As System.Windows.Forms.Label
    Friend WithEvents treasuryCaption As System.Windows.Forms.Label
    Friend WithEvents methodCaption As System.Windows.Forms.Label
    Friend WithEvents amountCaption As System.Windows.Forms.Label
    Friend WithEvents notesCaption As System.Windows.Forms.Label
    Friend WithEvents supplierBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents treasuryBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents methodBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents typeBox As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents fromPicker As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents toPicker As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents amountBox As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents notesBox As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnRefreshStatement As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPrintStatement As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExportStatement As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddPayment As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents balanceLabel As System.Windows.Forms.Label
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents borderless As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
