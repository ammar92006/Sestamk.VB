<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchases
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchases))
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_max = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_min = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBarcode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtDebit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCredit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnDeleteItem = New Guna.UI2.WinForms.Guna2Button()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnAddItem = New Guna.UI2.WinForms.Guna2Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtQuantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbUnit = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbMaterial = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblTreasury = New System.Windows.Forms.Label()
        Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblStore = New System.Windows.Forms.Label()
        Me.cmbStore = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSupplier = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpInvoiceDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInvoiceNumber = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbPaymentType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnSaveInvoice = New Guna.UI2.WinForms.Guna2Button()
        Me.lblRemainingAmount = New System.Windows.Forms.Label()
        Me.txtRemainingAmount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblPaidAmount = New System.Windows.Forms.Label()
        Me.txtPaidAmount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNetTotal = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dgvInvoiceItems = New System.Windows.Forms.DataGridView()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBranches = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.panelHeader.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        CType(Me.dgvInvoiceItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.AutoSize = True
        Me.btnClose.Location = New System.Drawing.Point(15, 17)
        Me.btnClose.Name = "btn_close"
        Me.btnClose.Size = New System.Drawing.Size(38, 36)
        Me.btnClose.TabIndex = 3
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
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btnClose)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1345, 70)
        Me.panelHeader.TabIndex = 46
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(608, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(195, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = " المشتريات فاتورة"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.Label5)
        Me.Guna2Panel1.Controls.Add(Me.cmbBranches)
        Me.Guna2Panel1.Controls.Add(Me.Label4)
        Me.Guna2Panel1.Controls.Add(Me.txtBarcode)
        Me.Guna2Panel1.Controls.Add(Me.txtDebit)
        Me.Guna2Panel1.Controls.Add(Me.Label18)
        Me.Guna2Panel1.Controls.Add(Me.txtCredit)
        Me.Guna2Panel1.Controls.Add(Me.Label19)
        Me.Guna2Panel1.Controls.Add(Me.Label17)
        Me.Guna2Panel1.Controls.Add(Me.Label15)
        Me.Guna2Panel1.Controls.Add(Me.btnDeleteItem)
        Me.Guna2Panel1.Controls.Add(Me.txtNotes)
        Me.Guna2Panel1.Controls.Add(Me.btnAddItem)
        Me.Guna2Panel1.Controls.Add(Me.Label9)
        Me.Guna2Panel1.Controls.Add(Me.txtPrice)
        Me.Guna2Panel1.Controls.Add(Me.Label8)
        Me.Guna2Panel1.Controls.Add(Me.txtQuantity)
        Me.Guna2Panel1.Controls.Add(Me.Label7)
        Me.Guna2Panel1.Controls.Add(Me.cmbUnit)
        Me.Guna2Panel1.Controls.Add(Me.Label6)
        Me.Guna2Panel1.Controls.Add(Me.cmbMaterial)
        Me.Guna2Panel1.Controls.Add(Me.lblTreasury)
        Me.Guna2Panel1.Controls.Add(Me.cmbTreasury)
        Me.Guna2Panel1.Controls.Add(Me.lblStore)
        Me.Guna2Panel1.Controls.Add(Me.cmbStore)
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Controls.Add(Me.cmbSupplier)
        Me.Guna2Panel1.Controls.Add(Me.Label2)
        Me.Guna2Panel1.Controls.Add(Me.dtpInvoiceDate)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.txtInvoiceNumber)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 70)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1345, 294)
        Me.Guna2Panel1.TabIndex = 5613
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1182, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 36)
        Me.Label4.TabIndex = 5659
        Me.Label4.Text = "الباركود"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBarcode
        '
        Me.txtBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBarcode.BorderRadius = 6
        Me.txtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBarcode.DefaultText = ""
        Me.txtBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtBarcode.Location = New System.Drawing.Point(1182, 242)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.PlaceholderText = ""
        Me.txtBarcode.SelectedText = ""
        Me.txtBarcode.Size = New System.Drawing.Size(136, 36)
        Me.txtBarcode.TabIndex = 5658
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDebit
        '
        Me.txtDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDebit.BorderRadius = 6
        Me.txtDebit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDebit.DefaultText = "0"
        Me.txtDebit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDebit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDebit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDebit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDebit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDebit.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDebit.ForeColor = System.Drawing.Color.Black
        Me.txtDebit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDebit.Location = New System.Drawing.Point(14, 76)
        Me.txtDebit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.PlaceholderText = ""
        Me.txtDebit.SelectedText = ""
        Me.txtDebit.Size = New System.Drawing.Size(108, 36)
        Me.txtDebit.TabIndex = 5657
        Me.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(14, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 36)
        Me.Label18.TabIndex = 5656
        Me.Label18.Text = "مدين"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCredit
        '
        Me.txtCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCredit.BorderRadius = 6
        Me.txtCredit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCredit.DefaultText = "0"
        Me.txtCredit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCredit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCredit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCredit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCredit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCredit.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCredit.ForeColor = System.Drawing.Color.Black
        Me.txtCredit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCredit.Location = New System.Drawing.Point(128, 76)
        Me.txtCredit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.PlaceholderText = ""
        Me.txtCredit.SelectedText = ""
        Me.txtCredit.Size = New System.Drawing.Size(108, 36)
        Me.txtCredit.TabIndex = 5655
        Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(128, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 36)
        Me.Label19.TabIndex = 5654
        Me.Label19.Text = "دائن"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(14, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(222, 36)
        Me.Label17.TabIndex = 5640
        Me.Label17.Text = "رصيد المورد"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(508, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 36)
        Me.Label15.TabIndex = 5639
        Me.Label15.Text = "الملاحظات"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDeleteItem
        '
        Me.btnDeleteItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteItem.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteItem.BorderRadius = 6
        Me.btnDeleteItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteItem.FillColor = System.Drawing.Color.Brown
        Me.btnDeleteItem.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteItem.ForeColor = System.Drawing.Color.White
        Me.btnDeleteItem.Location = New System.Drawing.Point(169, 242)
        Me.btnDeleteItem.Name = "btnDeleteItem"
        Me.btnDeleteItem.Size = New System.Drawing.Size(112, 36)
        Me.btnDeleteItem.TabIndex = 5631
        Me.btnDeleteItem.Text = "حذف"
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
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(272, 16)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(230, 84)
        Me.txtNotes.TabIndex = 5638
        Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAddItem
        '
        Me.btnAddItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddItem.BackColor = System.Drawing.Color.Transparent
        Me.btnAddItem.BorderRadius = 6
        Me.btnAddItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddItem.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnAddItem.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddItem.ForeColor = System.Drawing.Color.White
        Me.btnAddItem.Location = New System.Drawing.Point(287, 242)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(219, 36)
        Me.btnAddItem.TabIndex = 5630
        Me.btnAddItem.Text = "إضافة +"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(514, 202)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 36)
        Me.Label9.TabIndex = 5629
        Me.Label9.Text = "السعر *"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrice.BorderRadius = 6
        Me.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrice.DefaultText = ""
        Me.txtPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPrice.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPrice.ForeColor = System.Drawing.Color.Black
        Me.txtPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPrice.Location = New System.Drawing.Point(514, 242)
        Me.txtPrice.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.PlaceholderText = ""
        Me.txtPrice.SelectedText = ""
        Me.txtPrice.Size = New System.Drawing.Size(136, 36)
        Me.txtPrice.TabIndex = 5628
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(655, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 36)
        Me.Label8.TabIndex = 5627
        Me.Label8.Text = "الكمية *"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.BorderRadius = 6
        Me.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQuantity.DefaultText = ""
        Me.txtQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtQuantity.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtQuantity.ForeColor = System.Drawing.Color.Black
        Me.txtQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtQuantity.Location = New System.Drawing.Point(655, 242)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.PlaceholderText = ""
        Me.txtQuantity.SelectedText = ""
        Me.txtQuantity.Size = New System.Drawing.Size(136, 36)
        Me.txtQuantity.TabIndex = 5626
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(796, 202)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 36)
        Me.Label7.TabIndex = 5625
        Me.Label7.Text = "وحدة الشراء *"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbUnit
        '
        Me.cmbUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUnit.BackColor = System.Drawing.Color.Transparent
        Me.cmbUnit.BorderRadius = 6
        Me.cmbUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnit.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbUnit.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbUnit.ForeColor = System.Drawing.Color.Black
        Me.cmbUnit.ItemHeight = 30
        Me.cmbUnit.Location = New System.Drawing.Point(796, 242)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(136, 36)
        Me.cmbUnit.TabIndex = 5624
        Me.cmbUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(937, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(240, 36)
        Me.Label6.TabIndex = 5623
        Me.Label6.Text = "الخامة *"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMaterial
        '
        Me.cmbMaterial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMaterial.BackColor = System.Drawing.Color.Transparent
        Me.cmbMaterial.BorderRadius = 6
        Me.cmbMaterial.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaterial.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMaterial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMaterial.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbMaterial.ForeColor = System.Drawing.Color.Black
        Me.cmbMaterial.ItemHeight = 30
        Me.cmbMaterial.Location = New System.Drawing.Point(937, 242)
        Me.cmbMaterial.Name = "cmbMaterial"
        Me.cmbMaterial.Size = New System.Drawing.Size(240, 36)
        Me.cmbMaterial.TabIndex = 5622
        Me.cmbMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTreasury
        '
        Me.lblTreasury.BackColor = System.Drawing.Color.Transparent
        Me.lblTreasury.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblTreasury.Location = New System.Drawing.Point(854, 136)
        Me.lblTreasury.Name = "lblTreasury"
        Me.lblTreasury.Size = New System.Drawing.Size(110, 36)
        Me.lblTreasury.TabIndex = 5621
        Me.lblTreasury.Text = "الخزنة *"
        Me.lblTreasury.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTreasury
        '
        Me.cmbTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbTreasury.BorderRadius = 6
        Me.cmbTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTreasury.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbTreasury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbTreasury.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbTreasury.ForeColor = System.Drawing.Color.Black
        Me.cmbTreasury.ItemHeight = 30
        Me.cmbTreasury.Location = New System.Drawing.Point(608, 136)
        Me.cmbTreasury.Name = "cmbTreasury"
        Me.cmbTreasury.Size = New System.Drawing.Size(240, 36)
        Me.cmbTreasury.TabIndex = 5620
        Me.cmbTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStore
        '
        Me.lblStore.BackColor = System.Drawing.Color.Transparent
        Me.lblStore.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStore.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblStore.Location = New System.Drawing.Point(854, 16)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(110, 36)
        Me.lblStore.TabIndex = 5619
        Me.lblStore.Text = "المخزن *"
        Me.lblStore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbStore
        '
        Me.cmbStore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStore.BackColor = System.Drawing.Color.Transparent
        Me.cmbStore.BorderRadius = 6
        Me.cmbStore.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStore.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbStore.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbStore.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbStore.ForeColor = System.Drawing.Color.Black
        Me.cmbStore.ItemHeight = 30
        Me.cmbStore.Location = New System.Drawing.Point(608, 16)
        Me.cmbStore.Name = "cmbStore"
        Me.cmbStore.Size = New System.Drawing.Size(240, 36)
        Me.cmbStore.TabIndex = 5618
        Me.cmbStore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1216, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 36)
        Me.Label3.TabIndex = 5617
        Me.Label3.Text = "المورد *"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbSupplier
        '
        Me.cmbSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSupplier.BackColor = System.Drawing.Color.Transparent
        Me.cmbSupplier.BorderRadius = 6
        Me.cmbSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSupplier.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSupplier.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbSupplier.ForeColor = System.Drawing.Color.Black
        Me.cmbSupplier.ItemHeight = 30
        Me.cmbSupplier.Location = New System.Drawing.Point(970, 136)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(240, 36)
        Me.cmbSupplier.TabIndex = 5616
        Me.cmbSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1216, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 36)
        Me.Label2.TabIndex = 5615
        Me.Label2.Text = "التاريخ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.dtpInvoiceDate.BorderRadius = 8
        Me.dtpInvoiceDate.BorderThickness = 3
        Me.dtpInvoiceDate.Checked = True
        Me.dtpInvoiceDate.FillColor = System.Drawing.Color.Empty
        Me.dtpInvoiceDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(970, 76)
        Me.dtpInvoiceDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpInvoiceDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(240, 36)
        Me.dtpInvoiceDate.TabIndex = 5614
        Me.dtpInvoiceDate.Value = New Date(2026, 7, 31, 2, 46, 1, 333)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1216, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 36)
        Me.Label1.TabIndex = 5613
        Me.Label1.Text = "رقم الفاتورة *"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvoiceNumber.BorderRadius = 6
        Me.txtInvoiceNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvoiceNumber.DefaultText = ""
        Me.txtInvoiceNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtInvoiceNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtInvoiceNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInvoiceNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInvoiceNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtInvoiceNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtInvoiceNumber.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(970, 16)
        Me.txtInvoiceNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.PlaceholderText = ""
        Me.txtInvoiceNumber.SelectedText = ""
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(240, 36)
        Me.txtInvoiceNumber.TabIndex = 5612
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.btnClear)
        Me.Guna2Panel2.Controls.Add(Me.Label16)
        Me.Guna2Panel2.Controls.Add(Me.cmbPaymentType)
        Me.Guna2Panel2.Controls.Add(Me.btnSaveInvoice)
        Me.Guna2Panel2.Controls.Add(Me.lblRemainingAmount)
        Me.Guna2Panel2.Controls.Add(Me.txtRemainingAmount)
        Me.Guna2Panel2.Controls.Add(Me.lblPaidAmount)
        Me.Guna2Panel2.Controls.Add(Me.txtPaidAmount)
        Me.Guna2Panel2.Controls.Add(Me.Label12)
        Me.Guna2Panel2.Controls.Add(Me.txtNetTotal)
        Me.Guna2Panel2.Controls.Add(Me.Label11)
        Me.Guna2Panel2.Controls.Add(Me.txtDiscount)
        Me.Guna2Panel2.Controls.Add(Me.Label10)
        Me.Guna2Panel2.Controls.Add(Me.txtTotalAmount)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 700)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1345, 100)
        Me.Guna2Panel2.TabIndex = 5614
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(645, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 36)
        Me.Label16.TabIndex = 5642
        Me.Label16.Text = "نوع السداد"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPaymentType
        '
        Me.cmbPaymentType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPaymentType.BackColor = System.Drawing.Color.Transparent
        Me.cmbPaymentType.BorderRadius = 6
        Me.cmbPaymentType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbPaymentType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbPaymentType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbPaymentType.ForeColor = System.Drawing.Color.Black
        Me.cmbPaymentType.ItemHeight = 30
        Me.cmbPaymentType.Location = New System.Drawing.Point(422, 55)
        Me.cmbPaymentType.Name = "cmbPaymentType"
        Me.cmbPaymentType.Size = New System.Drawing.Size(217, 36)
        Me.cmbPaymentType.TabIndex = 5641
        Me.cmbPaymentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSaveInvoice
        '
        Me.btnSaveInvoice.BorderRadius = 6
        Me.btnSaveInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveInvoice.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnSaveInvoice.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveInvoice.ForeColor = System.Drawing.Color.White
        Me.btnSaveInvoice.Location = New System.Drawing.Point(12, 12)
        Me.btnSaveInvoice.Name = "btnSaveInvoice"
        Me.btnSaveInvoice.Size = New System.Drawing.Size(336, 76)
        Me.btnSaveInvoice.TabIndex = 5640
        Me.btnSaveInvoice.Text = "حفظ"
        '
        'lblRemainingAmount
        '
        Me.lblRemainingAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblRemainingAmount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblRemainingAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblRemainingAmount.Location = New System.Drawing.Point(899, 55)
        Me.lblRemainingAmount.Name = "lblRemainingAmount"
        Me.lblRemainingAmount.Size = New System.Drawing.Size(92, 36)
        Me.lblRemainingAmount.TabIndex = 5637
        Me.lblRemainingAmount.Text = "المتبقي"
        Me.lblRemainingAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRemainingAmount
        '
        Me.txtRemainingAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemainingAmount.BorderRadius = 6
        Me.txtRemainingAmount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRemainingAmount.DefaultText = ""
        Me.txtRemainingAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtRemainingAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRemainingAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRemainingAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRemainingAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtRemainingAmount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtRemainingAmount.ForeColor = System.Drawing.Color.Black
        Me.txtRemainingAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtRemainingAmount.Location = New System.Drawing.Point(757, 55)
        Me.txtRemainingAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRemainingAmount.Name = "txtRemainingAmount"
        Me.txtRemainingAmount.PlaceholderText = ""
        Me.txtRemainingAmount.SelectedText = ""
        Me.txtRemainingAmount.Size = New System.Drawing.Size(136, 36)
        Me.txtRemainingAmount.TabIndex = 5636
        Me.txtRemainingAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPaidAmount
        '
        Me.lblPaidAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblPaidAmount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaidAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblPaidAmount.Location = New System.Drawing.Point(1157, 55)
        Me.lblPaidAmount.Name = "lblPaidAmount"
        Me.lblPaidAmount.Size = New System.Drawing.Size(92, 36)
        Me.lblPaidAmount.TabIndex = 5635
        Me.lblPaidAmount.Text = "المدفوع"
        Me.lblPaidAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPaidAmount
        '
        Me.txtPaidAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaidAmount.BorderRadius = 6
        Me.txtPaidAmount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaidAmount.DefaultText = ""
        Me.txtPaidAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPaidAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPaidAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaidAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaidAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPaidAmount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPaidAmount.ForeColor = System.Drawing.Color.Black
        Me.txtPaidAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPaidAmount.Location = New System.Drawing.Point(997, 55)
        Me.txtPaidAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPaidAmount.Name = "txtPaidAmount"
        Me.txtPaidAmount.PlaceholderText = ""
        Me.txtPaidAmount.SelectedText = ""
        Me.txtPaidAmount.Size = New System.Drawing.Size(154, 36)
        Me.txtPaidAmount.TabIndex = 5634
        Me.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(582, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(169, 36)
        Me.Label12.TabIndex = 5633
        Me.Label12.Text = "إجمالي الفاتورة بعد الخصم"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNetTotal
        '
        Me.txtNetTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNetTotal.BorderRadius = 6
        Me.txtNetTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNetTotal.DefaultText = ""
        Me.txtNetTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNetTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNetTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNetTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNetTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtNetTotal.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNetTotal.ForeColor = System.Drawing.Color.Black
        Me.txtNetTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtNetTotal.Location = New System.Drawing.Point(422, 12)
        Me.txtNetTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNetTotal.Name = "txtNetTotal"
        Me.txtNetTotal.PlaceholderText = ""
        Me.txtNetTotal.SelectedText = ""
        Me.txtNetTotal.Size = New System.Drawing.Size(154, 36)
        Me.txtNetTotal.TabIndex = 5632
        Me.txtNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(899, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 36)
        Me.Label11.TabIndex = 5631
        Me.Label11.Text = "الخصم"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDiscount
        '
        Me.txtDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscount.BorderRadius = 6
        Me.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscount.DefaultText = ""
        Me.txtDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDiscount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDiscount.Location = New System.Drawing.Point(757, 11)
        Me.txtDiscount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.PlaceholderText = ""
        Me.txtDiscount.SelectedText = ""
        Me.txtDiscount.Size = New System.Drawing.Size(136, 36)
        Me.txtDiscount.TabIndex = 5630
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1157, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(169, 36)
        Me.Label10.TabIndex = 5615
        Me.Label10.Text = "إجمالي الفاتورة قبل الخصم"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAmount.BorderRadius = 6
        Me.txtTotalAmount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalAmount.DefaultText = ""
        Me.txtTotalAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotalAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotalAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtTotalAmount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtTotalAmount.ForeColor = System.Drawing.Color.Black
        Me.txtTotalAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtTotalAmount.Location = New System.Drawing.Point(997, 11)
        Me.txtTotalAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.PlaceholderText = ""
        Me.txtTotalAmount.SelectedText = ""
        Me.txtTotalAmount.Size = New System.Drawing.Size(154, 36)
        Me.txtTotalAmount.TabIndex = 5614
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvInvoiceItems
        '
        Me.dgvInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceItems.Location = New System.Drawing.Point(0, 364)
        Me.dgvInvoiceItems.Name = "dgvInvoiceItems"
        Me.dgvInvoiceItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvInvoiceItems.RowTemplate.Height = 40
        Me.dgvInvoiceItems.Size = New System.Drawing.Size(1345, 336)
        Me.dgvInvoiceItems.TabIndex = 5615
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'btnClear
        '
        Me.btnClear.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.btnClear.BorderRadius = 6
        Me.btnClear.BorderThickness = 3
        Me.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.FillColor = System.Drawing.Color.Empty
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Image = Global.WindowsApp1.My.Resources.Resources.clear__2_
        Me.btnClear.ImageSize = New System.Drawing.Size(60, 64)
        Me.btnClear.Location = New System.Drawing.Point(354, 20)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(62, 61)
        Me.btnClear.TabIndex = 5643
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(854, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 36)
        Me.Label5.TabIndex = 5661
        Me.Label5.Text = "الفرع"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbBranches
        '
        Me.cmbBranches.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBranches.BackColor = System.Drawing.Color.Transparent
        Me.cmbBranches.BorderRadius = 6
        Me.cmbBranches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBranches.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbBranches.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbBranches.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbBranches.ForeColor = System.Drawing.Color.Black
        Me.cmbBranches.ItemHeight = 30
        Me.cmbBranches.Location = New System.Drawing.Point(608, 76)
        Me.cmbBranches.Name = "cmbBranches"
        Me.cmbBranches.Size = New System.Drawing.Size(240, 36)
        Me.cmbBranches.TabIndex = 5660
        Me.cmbBranches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmPurchases
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1345, 800)
        Me.Controls.Add(Me.dgvInvoiceItems)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPurchases"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel2.ResumeLayout(False)
        CType(Me.dgvInvoiceItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnLookupPurchases = New Guna.UI2.WinForms.Guna2Button()
        Me.btnLookupPurchases.Name = "btnLookupPurchases"
        Me.btnLookupPurchases.Text = "بحث الفواتير السابقة"
        Me.btnLookupPurchases.Size = New System.Drawing.Size(210, 38)
        Me.btnLookupPurchases.BorderRadius = 6
        Me.btnLookupPurchases.FillColor = System.Drawing.Color.FromArgb(43, 132, 185)
        Me.btnLookupPurchases.ForeColor = System.Drawing.Color.White
        Me.btnLookupPurchases.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintLastPurchase = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrintLastPurchase.Name = "btnPrintLastPurchase"
        Me.btnPrintLastPurchase.Text = "عرض / طباعة آخر فاتورة"
        Me.btnPrintLastPurchase.Size = New System.Drawing.Size(230, 38)
        Me.btnPrintLastPurchase.BorderRadius = 6
        Me.btnPrintLastPurchase.FillColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.btnPrintLastPurchase.ForeColor = System.Drawing.Color.White
        Me.btnPrintLastPurchase.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.updateCost = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.updateCost.Name = "updateCost"
        Me.updateCost.Text = "تحديث تكلفة الخامات بآخر شراء (بعد الخصم)"
        Me.updateCost.Size = New System.Drawing.Size(360, 38)
        Me.updateCost.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.updateCost.Checked = True
        Me.purchaseActions = New System.Windows.Forms.FlowLayoutPanel()
        Me.purchaseActions.Name = "purchaseActions"
        Me.purchaseActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.purchaseActions.Height = 58
        Me.purchaseActions.Padding = New System.Windows.Forms.Padding(8)
        Me.purchaseActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.purchaseActions.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.purchaseActions.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLookupPurchases, Me.btnPrintLastPurchase, Me.updateCost})
        Me.Controls.Add(Me.purchaseActions)
        Me.purchaseActions.SendToBack()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtQuantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbUnit As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbMaterial As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblTreasury As Label
    Friend WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblStore As Label
    Friend WithEvents cmbStore As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbSupplier As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpInvoiceDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtInvoiceNumber As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnDeleteItem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddItem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblRemainingAmount As Label
    Friend WithEvents txtRemainingAmount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblPaidAmount As Label
    Friend WithEvents txtPaidAmount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtNetTotal As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDiscount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTotalAmount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSaveInvoice As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbPaymentType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgvInvoiceItems As DataGridView
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Label17 As Label
    Friend WithEvents txtDebit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCredit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBarcode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbBranches As Guna.UI2.WinForms.Guna2ComboBox

    Friend WithEvents btnLookupPurchases As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPrintLastPurchase As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents updateCost As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents purchaseActions As System.Windows.Forms.FlowLayoutPanel
End Class
