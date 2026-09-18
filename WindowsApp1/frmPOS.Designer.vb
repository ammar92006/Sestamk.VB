<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPOS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOS))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblUser_fullName = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCurrentShift = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel8 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel7 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel6 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.flpProducts = New System.Windows.Forms.FlowLayoutPanel()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnclear = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel21 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnSelectCustomer = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel22 = New Guna.UI2.WinForms.Guna2Panel()
        Me.txtCustomer = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnPendingInvoices = New Guna.UI2.WinForms.Guna2Button()
        Me.btntables = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteRow = New Guna.UI2.WinForms.Guna2Button()
        Me.btnHoldInvoice = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPay = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel20 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel24 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel26 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.Guna2Panel13 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel15 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel19 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.Guna2Panel18 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblDineInFee = New System.Windows.Forms.Label()
        Me.Guna2Panel14 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel17 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblDeliveryFee = New System.Windows.Forms.Label()
        Me.Guna2Panel16 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Guna2Panel11 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnDelivery = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDineIn = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTakeaway = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel12 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblOrderTypeStatus = New System.Windows.Forms.Label()
        Me.Guna2Panel10 = New Guna.UI2.WinForms.Guna2Panel()
        Me.dgvInvoice = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Panel9 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblInvoiceNumber = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.flpCategories = New System.Windows.Forms.FlowLayoutPanel()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnAddCategoryForm = New Guna.UI2.WinForms.Guna2Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlCategoryGridToolbar = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblRowValue = New System.Windows.Forms.Label()
        Me.lblRowTitle = New System.Windows.Forms.Label()
        Me.pnlColRowSep = New System.Windows.Forms.Panel()
        Me.lblColValue = New System.Windows.Forms.Label()
        Me.lblColTitle = New System.Windows.Forms.Label()
        Me.btnDecCol = New Guna.UI2.WinForms.Guna2Button()
        Me.btnIncCol = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDecRow = New Guna.UI2.WinForms.Guna2Button()
        Me.btnIncRow = New Guna.UI2.WinForms.Guna2Button()
        Me.panelHeader.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        Me.Guna2Panel3.SuspendLayout()
        Me.Guna2Panel21.SuspendLayout()
        Me.Guna2Panel22.SuspendLayout()
        Me.Guna2Panel20.SuspendLayout()
        Me.Guna2Panel24.SuspendLayout()
        Me.Guna2Panel26.SuspendLayout()
        Me.Guna2Panel13.SuspendLayout()
        Me.Guna2Panel15.SuspendLayout()
        Me.Guna2Panel19.SuspendLayout()
        Me.Guna2Panel18.SuspendLayout()
        Me.Guna2Panel14.SuspendLayout()
        Me.Guna2Panel17.SuspendLayout()
        Me.Guna2Panel16.SuspendLayout()
        Me.Guna2Panel11.SuspendLayout()
        Me.Guna2Panel12.SuspendLayout()
        Me.Guna2Panel10.SuspendLayout()
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel9.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2Panel4.SuspendLayout()
        Me.pnlCategoryGridToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblDateTime)
        Me.panelHeader.Controls.Add(Me.Label10)
        Me.panelHeader.Controls.Add(Me.lblUser_fullName)
        Me.panelHeader.Controls.Add(Me.Label8)
        Me.panelHeader.Controls.Add(Me.lblCurrentShift)
        Me.panelHeader.Controls.Add(Me.Label4)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1450, 70)
        Me.panelHeader.TabIndex = 40
        '
        'lblDateTime
        '
        Me.lblDateTime.BackColor = System.Drawing.Color.Transparent
        Me.lblDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(261, 15)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(260, 36)
        Me.lblDateTime.TabIndex = 5594
        Me.lblDateTime.Text = "-------------"
        Me.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(527, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 36)
        Me.Label10.TabIndex = 5593
        Me.Label10.Text = "الوقت والتاريخ"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUser_fullName
        '
        Me.lblUser_fullName.BackColor = System.Drawing.Color.Transparent
        Me.lblUser_fullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUser_fullName.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblUser_fullName.ForeColor = System.Drawing.Color.White
        Me.lblUser_fullName.Location = New System.Drawing.Point(797, 15)
        Me.lblUser_fullName.Name = "lblUser_fullName"
        Me.lblUser_fullName.Size = New System.Drawing.Size(186, 36)
        Me.lblUser_fullName.TabIndex = 5592
        Me.lblUser_fullName.Text = "-------------"
        Me.lblUser_fullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(989, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 36)
        Me.Label8.TabIndex = 5591
        Me.Label8.Text = "المستخدم"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentShift
        '
        Me.lblCurrentShift.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentShift.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentShift.ForeColor = System.Drawing.Color.White
        Me.lblCurrentShift.Location = New System.Drawing.Point(1137, 15)
        Me.lblCurrentShift.Name = "lblCurrentShift"
        Me.lblCurrentShift.Size = New System.Drawing.Size(144, 36)
        Me.lblCurrentShift.TabIndex = 5590
        Me.lblCurrentShift.Text = "-------------"
        Me.lblCurrentShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1287, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 36)
        Me.Label4.TabIndex = 5589
        Me.Label4.Text = "الوردية الحالية"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(718, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(53, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "البيع"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.BorderColor = System.Drawing.Color.Silver
        Me.Guna2Panel2.Controls.Add(Me.flpProducts)
        Me.Guna2Panel2.Controls.Add(Me.Guna2Panel1)
        Me.Guna2Panel2.Controls.Add(Me.Guna2Panel8)
        Me.Guna2Panel2.Controls.Add(Me.Guna2Panel7)
        Me.Guna2Panel2.Controls.Add(Me.Guna2Panel6)
        Me.Guna2Panel2.Controls.Add(Me.Guna2Panel5)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 70)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(850, 830)
        Me.Guna2Panel2.TabIndex = 42
        '
        'Guna2Panel8
        '
        Me.Guna2Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Guna2Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2Panel8.Location = New System.Drawing.Point(0, 10)
        Me.Guna2Panel8.Name = "Guna2Panel8"
        Me.Guna2Panel8.Size = New System.Drawing.Size(10, 810)
        Me.Guna2Panel8.TabIndex = 5
        '
        'Guna2Panel7
        '
        Me.Guna2Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Guna2Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel7.Location = New System.Drawing.Point(0, 820)
        Me.Guna2Panel7.Name = "Guna2Panel7"
        Me.Guna2Panel7.Size = New System.Drawing.Size(840, 10)
        Me.Guna2Panel7.TabIndex = 4
        '
        'Guna2Panel6
        '
        Me.Guna2Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Guna2Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Guna2Panel6.Location = New System.Drawing.Point(840, 10)
        Me.Guna2Panel6.Name = "Guna2Panel6"
        Me.Guna2Panel6.Size = New System.Drawing.Size(10, 820)
        Me.Guna2Panel6.TabIndex = 3
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Guna2Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.Size = New System.Drawing.Size(850, 10)
        Me.Guna2Panel5.TabIndex = 2
        '
        'flpProducts
        '
        Me.flpProducts.AutoScroll = True
        Me.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpProducts.Location = New System.Drawing.Point(10, 10)
        Me.flpProducts.Name = "flpProducts"
        Me.flpProducts.Padding = New System.Windows.Forms.Padding(15)
        Me.flpProducts.Size = New System.Drawing.Size(830, 595)
        Me.flpProducts.TabIndex = 1
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.Controls.Add(Me.btnclear)
        Me.Guna2Panel3.Controls.Add(Me.Guna2Panel21)
        Me.Guna2Panel3.Controls.Add(Me.btnPendingInvoices)
        Me.Guna2Panel3.Controls.Add(Me.btntables)
        Me.Guna2Panel3.Controls.Add(Me.btnDeleteRow)
        Me.Guna2Panel3.Controls.Add(Me.btnHoldInvoice)
        Me.Guna2Panel3.Controls.Add(Me.btnPay)
        Me.Guna2Panel3.Controls.Add(Me.Guna2Panel20)
        Me.Guna2Panel3.Controls.Add(Me.Guna2Panel13)
        Me.Guna2Panel3.Controls.Add(Me.Guna2Panel11)
        Me.Guna2Panel3.Controls.Add(Me.Guna2Panel10)
        Me.Guna2Panel3.Controls.Add(Me.Guna2Panel9)
        Me.Guna2Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Guna2Panel3.Location = New System.Drawing.Point(850, 70)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.Size = New System.Drawing.Size(600, 830)
        Me.Guna2Panel3.TabIndex = 43
        '
        'btnclear
        '
        Me.btnclear.BorderRadius = 8
        Me.btnclear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnclear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnclear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnclear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnclear.FillColor = System.Drawing.Color.Crimson
        Me.btnclear.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnclear.ForeColor = System.Drawing.Color.White
        Me.btnclear.Image = Global.WindowsApp1.My.Resources.Resources.clear__1_
        Me.btnclear.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnclear.Location = New System.Drawing.Point(12, 773)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(169, 45)
        Me.btnclear.TabIndex = 13
        Me.btnclear.Text = "تفريغ"
        '
        'Guna2Panel21
        '
        Me.Guna2Panel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Guna2Panel21.Controls.Add(Me.btnSelectCustomer)
        Me.Guna2Panel21.Controls.Add(Me.Guna2Panel22)
        Me.Guna2Panel21.Controls.Add(Me.Label6)
        Me.Guna2Panel21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel21.Location = New System.Drawing.Point(0, 664)
        Me.Guna2Panel21.Name = "Guna2Panel21"
        Me.Guna2Panel21.Size = New System.Drawing.Size(600, 55)
        Me.Guna2Panel21.TabIndex = 12
        '
        'btnSelectCustomer
        '
        Me.btnSelectCustomer.BorderRadius = 8
        Me.btnSelectCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSelectCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSelectCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSelectCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSelectCustomer.FillColor = System.Drawing.Color.LightSlateGray
        Me.btnSelectCustomer.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnSelectCustomer.ForeColor = System.Drawing.Color.White
        Me.btnSelectCustomer.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnSelectCustomer.Location = New System.Drawing.Point(15, 5)
        Me.btnSelectCustomer.Name = "btnSelectCustomer"
        Me.btnSelectCustomer.Size = New System.Drawing.Size(186, 45)
        Me.btnSelectCustomer.TabIndex = 5594
        Me.btnSelectCustomer.Text = "تحديد"
        '
        'Guna2Panel22
        '
        Me.Guna2Panel22.Controls.Add(Me.txtCustomer)
        Me.Guna2Panel22.Dock = System.Windows.Forms.DockStyle.Right
        Me.Guna2Panel22.Location = New System.Drawing.Point(209, 0)
        Me.Guna2Panel22.Name = "Guna2Panel22"
        Me.Guna2Panel22.Size = New System.Drawing.Size(266, 55)
        Me.Guna2Panel22.TabIndex = 5593
        '
        'txtCustomer
        '
        Me.txtCustomer.BorderColor = System.Drawing.Color.Silver
        Me.txtCustomer.BorderRadius = 8
        Me.txtCustomer.BorderThickness = 3
        Me.txtCustomer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomer.DefaultText = ""
        Me.txtCustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomer.FillColor = System.Drawing.Color.Gray
        Me.txtCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomer.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtCustomer.ForeColor = System.Drawing.Color.White
        Me.txtCustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomer.Location = New System.Drawing.Point(13, 6)
        Me.txtCustomer.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.PlaceholderText = ""
        Me.txtCustomer.SelectedText = ""
        Me.txtCustomer.Size = New System.Drawing.Size(247, 43)
        Me.txtCustomer.TabIndex = 0
        Me.txtCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(475, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 55)
        Me.Label6.TabIndex = 5592
        Me.Label6.Text = "العميل"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPendingInvoices
        '
        Me.btnPendingInvoices.BorderRadius = 8
        Me.btnPendingInvoices.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPendingInvoices.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPendingInvoices.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPendingInvoices.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPendingInvoices.FillColor = System.Drawing.Color.DarkSlateGray
        Me.btnPendingInvoices.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnPendingInvoices.ForeColor = System.Drawing.Color.White
        Me.btnPendingInvoices.Image = Global.WindowsApp1.My.Resources.Resources.pause
        Me.btnPendingInvoices.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnPendingInvoices.Location = New System.Drawing.Point(187, 773)
        Me.btnPendingInvoices.Name = "btnPendingInvoices"
        Me.btnPendingInvoices.Size = New System.Drawing.Size(200, 45)
        Me.btnPendingInvoices.TabIndex = 11
        Me.btnPendingInvoices.Text = "الفواتير المعلقة"
        '
        'btntables
        '
        Me.btntables.BorderRadius = 8
        Me.btntables.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btntables.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btntables.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btntables.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btntables.FillColor = System.Drawing.Color.DarkSlateGray
        Me.btntables.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btntables.ForeColor = System.Drawing.Color.White
        Me.btntables.Image = Global.WindowsApp1.My.Resources.Resources.dining_room
        Me.btntables.ImageSize = New System.Drawing.Size(32, 32)
        Me.btntables.Location = New System.Drawing.Point(394, 773)
        Me.btntables.Name = "btntables"
        Me.btntables.Size = New System.Drawing.Size(200, 45)
        Me.btntables.TabIndex = 10
        Me.btntables.Text = "الطاولات"
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.BorderRadius = 8
        Me.btnDeleteRow.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteRow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteRow.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteRow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteRow.FillColor = System.Drawing.Color.Crimson
        Me.btnDeleteRow.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteRow.ForeColor = System.Drawing.Color.White
        Me.btnDeleteRow.Image = Global.WindowsApp1.My.Resources.Resources.clear__1_
        Me.btnDeleteRow.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDeleteRow.Location = New System.Drawing.Point(12, 722)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(169, 45)
        Me.btnDeleteRow.TabIndex = 9
        Me.btnDeleteRow.Text = "حذف"
        '
        'btnHoldInvoice
        '
        Me.btnHoldInvoice.BorderRadius = 8
        Me.btnHoldInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnHoldInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnHoldInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnHoldInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnHoldInvoice.FillColor = System.Drawing.Color.PowderBlue
        Me.btnHoldInvoice.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnHoldInvoice.ForeColor = System.Drawing.Color.White
        Me.btnHoldInvoice.Image = Global.WindowsApp1.My.Resources.Resources.hold
        Me.btnHoldInvoice.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnHoldInvoice.Location = New System.Drawing.Point(187, 722)
        Me.btnHoldInvoice.Name = "btnHoldInvoice"
        Me.btnHoldInvoice.Size = New System.Drawing.Size(200, 45)
        Me.btnHoldInvoice.TabIndex = 8
        Me.btnHoldInvoice.Text = "تعليق"
        '
        'btnPay
        '
        Me.btnPay.BorderRadius = 8
        Me.btnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPay.FillColor = System.Drawing.Color.LightGreen
        Me.btnPay.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnPay.ForeColor = System.Drawing.Color.White
        Me.btnPay.Image = Global.WindowsApp1.My.Resources.Resources.payment
        Me.btnPay.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnPay.Location = New System.Drawing.Point(393, 722)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(200, 45)
        Me.btnPay.TabIndex = 7
        Me.btnPay.Text = "دفع"
        '
        'Guna2Panel20
        '
        Me.Guna2Panel20.Controls.Add(Me.Guna2Panel24)
        Me.Guna2Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel20.Location = New System.Drawing.Point(0, 618)
        Me.Guna2Panel20.Name = "Guna2Panel20"
        Me.Guna2Panel20.Size = New System.Drawing.Size(600, 46)
        Me.Guna2Panel20.TabIndex = 6
        '
        'Guna2Panel24
        '
        Me.Guna2Panel24.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Guna2Panel24.Controls.Add(Me.Guna2Panel26)
        Me.Guna2Panel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel24.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel24.Name = "Guna2Panel24"
        Me.Guna2Panel24.Size = New System.Drawing.Size(600, 46)
        Me.Guna2Panel24.TabIndex = 1
        '
        'Guna2Panel26
        '
        Me.Guna2Panel26.Controls.Add(Me.Label25)
        Me.Guna2Panel26.Controls.Add(Me.lblGrandTotal)
        Me.Guna2Panel26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel26.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel26.Name = "Guna2Panel26"
        Me.Guna2Panel26.Size = New System.Drawing.Size(600, 46)
        Me.Guna2Panel26.TabIndex = 6
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(311, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(289, 46)
        Me.Label25.TabIndex = 5591
        Me.Label25.Text = "الاجمالي"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGrandTotal.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGrandTotal.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblGrandTotal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrandTotal.Location = New System.Drawing.Point(0, 0)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(311, 46)
        Me.lblGrandTotal.TabIndex = 5592
        Me.lblGrandTotal.Text = "-------------"
        Me.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel13
        '
        Me.Guna2Panel13.Controls.Add(Me.Guna2Panel15)
        Me.Guna2Panel13.Controls.Add(Me.Guna2Panel14)
        Me.Guna2Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel13.Location = New System.Drawing.Point(0, 552)
        Me.Guna2Panel13.Name = "Guna2Panel13"
        Me.Guna2Panel13.Size = New System.Drawing.Size(600, 66)
        Me.Guna2Panel13.TabIndex = 5
        '
        'Guna2Panel15
        '
        Me.Guna2Panel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Guna2Panel15.Controls.Add(Me.Guna2Panel19)
        Me.Guna2Panel15.Controls.Add(Me.Guna2Panel18)
        Me.Guna2Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel15.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel15.Name = "Guna2Panel15"
        Me.Guna2Panel15.Size = New System.Drawing.Size(337, 66)
        Me.Guna2Panel15.TabIndex = 2
        '
        'Guna2Panel19
        '
        Me.Guna2Panel19.Controls.Add(Me.Label17)
        Me.Guna2Panel19.Controls.Add(Me.lblTax)
        Me.Guna2Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel19.Location = New System.Drawing.Point(0, 32)
        Me.Guna2Panel19.Name = "Guna2Panel19"
        Me.Guna2Panel19.Size = New System.Drawing.Size(337, 32)
        Me.Guna2Panel19.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(192, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(145, 32)
        Me.Label17.TabIndex = 5591
        Me.Label17.Text = "الضريبة"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTax
        '
        Me.lblTax.BackColor = System.Drawing.Color.Transparent
        Me.lblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTax.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTax.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTax.ForeColor = System.Drawing.Color.White
        Me.lblTax.Location = New System.Drawing.Point(0, 0)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(192, 32)
        Me.lblTax.TabIndex = 5592
        Me.lblTax.Text = "-------------"
        Me.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel18
        '
        Me.Guna2Panel18.Controls.Add(Me.Label15)
        Me.Guna2Panel18.Controls.Add(Me.lblDineInFee)
        Me.Guna2Panel18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel18.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel18.Name = "Guna2Panel18"
        Me.Guna2Panel18.Size = New System.Drawing.Size(337, 32)
        Me.Guna2Panel18.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(192, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(145, 32)
        Me.Label15.TabIndex = 5591
        Me.Label15.Text = "خدمة الصالة"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDineInFee
        '
        Me.lblDineInFee.BackColor = System.Drawing.Color.Transparent
        Me.lblDineInFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDineInFee.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblDineInFee.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDineInFee.ForeColor = System.Drawing.Color.White
        Me.lblDineInFee.Location = New System.Drawing.Point(0, 0)
        Me.lblDineInFee.Name = "lblDineInFee"
        Me.lblDineInFee.Size = New System.Drawing.Size(192, 32)
        Me.lblDineInFee.TabIndex = 5592
        Me.lblDineInFee.Text = "-------------"
        Me.lblDineInFee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel14
        '
        Me.Guna2Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Guna2Panel14.Controls.Add(Me.Guna2Panel17)
        Me.Guna2Panel14.Controls.Add(Me.Guna2Panel16)
        Me.Guna2Panel14.Dock = System.Windows.Forms.DockStyle.Right
        Me.Guna2Panel14.Location = New System.Drawing.Point(337, 0)
        Me.Guna2Panel14.Name = "Guna2Panel14"
        Me.Guna2Panel14.Size = New System.Drawing.Size(263, 66)
        Me.Guna2Panel14.TabIndex = 1
        '
        'Guna2Panel17
        '
        Me.Guna2Panel17.Controls.Add(Me.Label13)
        Me.Guna2Panel17.Controls.Add(Me.lblDeliveryFee)
        Me.Guna2Panel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel17.Location = New System.Drawing.Point(0, 32)
        Me.Guna2Panel17.Name = "Guna2Panel17"
        Me.Guna2Panel17.Size = New System.Drawing.Size(263, 32)
        Me.Guna2Panel17.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(132, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(131, 32)
        Me.Label13.TabIndex = 5591
        Me.Label13.Text = "الدليفري"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDeliveryFee
        '
        Me.lblDeliveryFee.BackColor = System.Drawing.Color.Transparent
        Me.lblDeliveryFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDeliveryFee.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblDeliveryFee.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDeliveryFee.ForeColor = System.Drawing.Color.White
        Me.lblDeliveryFee.Location = New System.Drawing.Point(0, 0)
        Me.lblDeliveryFee.Name = "lblDeliveryFee"
        Me.lblDeliveryFee.Size = New System.Drawing.Size(132, 32)
        Me.lblDeliveryFee.TabIndex = 5592
        Me.lblDeliveryFee.Text = "-------------"
        Me.lblDeliveryFee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel16
        '
        Me.Guna2Panel16.Controls.Add(Me.Label12)
        Me.Guna2Panel16.Controls.Add(Me.lblSubTotal)
        Me.Guna2Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel16.Name = "Guna2Panel16"
        Me.Guna2Panel16.Size = New System.Drawing.Size(263, 32)
        Me.Guna2Panel16.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(132, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 32)
        Me.Label12.TabIndex = 5591
        Me.Label12.Text = "الصافي"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSubTotal
        '
        Me.lblSubTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubTotal.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblSubTotal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblSubTotal.ForeColor = System.Drawing.Color.White
        Me.lblSubTotal.Location = New System.Drawing.Point(0, 0)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(132, 32)
        Me.lblSubTotal.TabIndex = 5592
        Me.lblSubTotal.Text = "-------------"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel11
        '
        Me.Guna2Panel11.Controls.Add(Me.btnDelivery)
        Me.Guna2Panel11.Controls.Add(Me.btnDineIn)
        Me.Guna2Panel11.Controls.Add(Me.btnTakeaway)
        Me.Guna2Panel11.Controls.Add(Me.Guna2Panel12)
        Me.Guna2Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel11.Location = New System.Drawing.Point(0, 388)
        Me.Guna2Panel11.Name = "Guna2Panel11"
        Me.Guna2Panel11.Size = New System.Drawing.Size(600, 164)
        Me.Guna2Panel11.TabIndex = 4
        '
        'btnDelivery
        '
        Me.btnDelivery.BorderRadius = 8
        Me.btnDelivery.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.btnDelivery.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelivery.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelivery.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelivery.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelivery.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelivery.ForeColor = System.Drawing.Color.White
        Me.btnDelivery.Image = Global.WindowsApp1.My.Resources.Resources.delivery_bike
        Me.btnDelivery.ImageOffset = New System.Drawing.Point(20, -18)
        Me.btnDelivery.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnDelivery.Location = New System.Drawing.Point(3, 53)
        Me.btnDelivery.Name = "btnDelivery"
        Me.btnDelivery.Size = New System.Drawing.Size(189, 104)
        Me.btnDelivery.TabIndex = 6
        Me.btnDelivery.Text = "دليفري"
        Me.btnDelivery.TextOffset = New System.Drawing.Point(-15, 30)
        '
        'btnDineIn
        '
        Me.btnDineIn.BorderRadius = 8
        Me.btnDineIn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.btnDineIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDineIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDineIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDineIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDineIn.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnDineIn.ForeColor = System.Drawing.Color.White
        Me.btnDineIn.Image = Global.WindowsApp1.My.Resources.Resources.dinning_hall
        Me.btnDineIn.ImageOffset = New System.Drawing.Point(13, -18)
        Me.btnDineIn.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnDineIn.Location = New System.Drawing.Point(204, 53)
        Me.btnDineIn.Name = "btnDineIn"
        Me.btnDineIn.Size = New System.Drawing.Size(189, 104)
        Me.btnDineIn.TabIndex = 5
        Me.btnDineIn.Text = "صالة"
        Me.btnDineIn.TextOffset = New System.Drawing.Point(-15, 30)
        '
        'btnTakeaway
        '
        Me.btnTakeaway.BorderRadius = 8
        Me.btnTakeaway.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.btnTakeaway.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTakeaway.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTakeaway.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTakeaway.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnTakeaway.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnTakeaway.ForeColor = System.Drawing.Color.White
        Me.btnTakeaway.Image = Global.WindowsApp1.My.Resources.Resources.take_away
        Me.btnTakeaway.ImageOffset = New System.Drawing.Point(20, -18)
        Me.btnTakeaway.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnTakeaway.Location = New System.Drawing.Point(405, 53)
        Me.btnTakeaway.Name = "btnTakeaway"
        Me.btnTakeaway.Size = New System.Drawing.Size(189, 104)
        Me.btnTakeaway.TabIndex = 4
        Me.btnTakeaway.Text = "تيك اوي"
        Me.btnTakeaway.TextOffset = New System.Drawing.Point(-15, 30)
        '
        'Guna2Panel12
        '
        Me.Guna2Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Guna2Panel12.Controls.Add(Me.lblOrderTypeStatus)
        Me.Guna2Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel12.Name = "Guna2Panel12"
        Me.Guna2Panel12.Size = New System.Drawing.Size(600, 50)
        Me.Guna2Panel12.TabIndex = 3
        '
        'lblOrderTypeStatus
        '
        Me.lblOrderTypeStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderTypeStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOrderTypeStatus.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrderTypeStatus.ForeColor = System.Drawing.Color.White
        Me.lblOrderTypeStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblOrderTypeStatus.Name = "lblOrderTypeStatus"
        Me.lblOrderTypeStatus.Size = New System.Drawing.Size(600, 50)
        Me.lblOrderTypeStatus.TabIndex = 5588
        Me.lblOrderTypeStatus.Text = "نوع الطلب"
        Me.lblOrderTypeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Guna2Panel10
        '
        Me.Guna2Panel10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Guna2Panel10.Controls.Add(Me.dgvInvoice)
        Me.Guna2Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel10.Location = New System.Drawing.Point(0, 56)
        Me.Guna2Panel10.Name = "Guna2Panel10"
        Me.Guna2Panel10.Size = New System.Drawing.Size(600, 332)
        Me.Guna2Panel10.TabIndex = 3
        '
        'dgvInvoice
        '
        Me.dgvInvoice.AllowUserToAddRows = False
        Me.dgvInvoice.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dgvInvoice.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvInvoice.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInvoice.ColumnHeadersHeight = 4
        Me.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInvoice.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoice.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvInvoice.Location = New System.Drawing.Point(0, 0)
        Me.dgvInvoice.Name = "dgvInvoice"
        Me.dgvInvoice.ReadOnly = True
        Me.dgvInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvInvoice.RowHeadersVisible = False
        Me.dgvInvoice.RowTemplate.Height = 40
        Me.dgvInvoice.Size = New System.Drawing.Size(600, 332)
        Me.dgvInvoice.TabIndex = 5611
        Me.dgvInvoice.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvInvoice.ThemeStyle.BackColor = System.Drawing.Color.Silver
        Me.dgvInvoice.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvInvoice.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvInvoice.ThemeStyle.ReadOnly = True
        Me.dgvInvoice.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvInvoice.ThemeStyle.RowsStyle.Height = 40
        '
        'Guna2Panel9
        '
        Me.Guna2Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Guna2Panel9.Controls.Add(Me.lblInvoiceNumber)
        Me.Guna2Panel9.Controls.Add(Me.Label2)
        Me.Guna2Panel9.Controls.Add(Me.Label1)
        Me.Guna2Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel9.Name = "Guna2Panel9"
        Me.Guna2Panel9.Size = New System.Drawing.Size(600, 56)
        Me.Guna2Panel9.TabIndex = 2
        '
        'lblInvoiceNumber
        '
        Me.lblInvoiceNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoiceNumber.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblInvoiceNumber.ForeColor = System.Drawing.Color.White
        Me.lblInvoiceNumber.Location = New System.Drawing.Point(12, 10)
        Me.lblInvoiceNumber.Name = "lblInvoiceNumber"
        Me.lblInvoiceNumber.Size = New System.Drawing.Size(94, 36)
        Me.lblInvoiceNumber.TabIndex = 5634
        Me.lblInvoiceNumber.Text = "0"
        Me.lblInvoiceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(112, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 36)
        Me.Label2.TabIndex = 5589
        Me.Label2.Text = "رقم الفاتورة"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(318, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 36)
        Me.Label1.TabIndex = 5588
        Me.Label1.Text = "الاصناف"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.flpCategories)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Panel4)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel1.Location = New System.Drawing.Point(10, 605)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(830, 215)
        Me.Guna2Panel1.TabIndex = 41
        '
        'flpCategories
        '
        Me.flpCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpCategories.Location = New System.Drawing.Point(0, 56)
        Me.flpCategories.Name = "flpCategories"
        Me.flpCategories.Padding = New System.Windows.Forms.Padding(10)
        Me.flpCategories.Size = New System.Drawing.Size(830, 159)
        Me.flpCategories.TabIndex = 0
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Guna2Panel4.Controls.Add(Me.pnlCategoryGridToolbar)
        Me.Guna2Panel4.Controls.Add(Me.btnAddCategoryForm)
        Me.Guna2Panel4.Controls.Add(Me.Label3)
        Me.Guna2Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.Size = New System.Drawing.Size(830, 56)
        Me.Guna2Panel4.TabIndex = 1
        '
        'btnAddCategoryForm
        '
        Me.btnAddCategoryForm.BackColor = System.Drawing.Color.Transparent
        Me.btnAddCategoryForm.BorderRadius = 8
        Me.btnAddCategoryForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddCategoryForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddCategoryForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddCategoryForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddCategoryForm.FillColor = System.Drawing.Color.Empty
        Me.btnAddCategoryForm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddCategoryForm.ForeColor = System.Drawing.Color.White
        Me.btnAddCategoryForm.Image = Global.WindowsApp1.My.Resources.Resources.add2
        Me.btnAddCategoryForm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddCategoryForm.Location = New System.Drawing.Point(677, 8)
        Me.btnAddCategoryForm.Name = "btnAddCategoryForm"
        Me.btnAddCategoryForm.Size = New System.Drawing.Size(40, 36)
        Me.btnAddCategoryForm.TabIndex = 5607
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(723, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 36)
        Me.Label3.TabIndex = 5588
        Me.Label3.Text = "الفئات"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCategoryGridToolbar
        '
        Me.pnlCategoryGridToolbar.BackColor = System.Drawing.Color.Transparent
        Me.pnlCategoryGridToolbar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.pnlCategoryGridToolbar.BorderRadius = 6
        Me.pnlCategoryGridToolbar.BorderThickness = 1
        Me.pnlCategoryGridToolbar.Controls.Add(Me.btnIncRow)
        Me.pnlCategoryGridToolbar.Controls.Add(Me.lblRowValue)
        Me.pnlCategoryGridToolbar.Controls.Add(Me.btnDecRow)
        Me.pnlCategoryGridToolbar.Controls.Add(Me.lblColTitle)
        Me.pnlCategoryGridToolbar.Controls.Add(Me.lblRowTitle)
        Me.pnlCategoryGridToolbar.Controls.Add(Me.pnlColRowSep)
        Me.pnlCategoryGridToolbar.Controls.Add(Me.btnIncCol)
        Me.pnlCategoryGridToolbar.Controls.Add(Me.lblColValue)
        Me.pnlCategoryGridToolbar.Controls.Add(Me.btnDecCol)
        Me.pnlCategoryGridToolbar.FillColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.pnlCategoryGridToolbar.Location = New System.Drawing.Point(12, 9)
        Me.pnlCategoryGridToolbar.Name = "pnlCategoryGridToolbar"
        Me.pnlCategoryGridToolbar.Size = New System.Drawing.Size(320, 38)
        Me.pnlCategoryGridToolbar.TabIndex = 2
        '
        'lblRowTitle
        '
        Me.lblRowTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblRowTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblRowTitle.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblRowTitle.Location = New System.Drawing.Point(239, 7)
        Me.lblRowTitle.Name = "lblRowTitle"
        Me.lblRowTitle.Size = New System.Drawing.Size(59, 26)
        Me.lblRowTitle.TabIndex = 5
        Me.lblRowTitle.Text = "الصفوف:"
        Me.lblRowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnIncRow
        '
        Me.btnIncRow.BorderRadius = 4
        Me.btnIncRow.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnIncRow.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnIncRow.ForeColor = System.Drawing.Color.White
        Me.btnIncRow.Location = New System.Drawing.Point(211, 7)
        Me.btnIncRow.Name = "btnIncRow"
        Me.btnIncRow.Size = New System.Drawing.Size(24, 24)
        Me.btnIncRow.TabIndex = 6
        Me.btnIncRow.Text = "+"
        '
        'lblRowValue
        '
        Me.lblRowValue.BackColor = System.Drawing.Color.Transparent
        Me.lblRowValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblRowValue.ForeColor = System.Drawing.Color.White
        Me.lblRowValue.Location = New System.Drawing.Point(181, 7)
        Me.lblRowValue.Name = "lblRowValue"
        Me.lblRowValue.Size = New System.Drawing.Size(24, 26)
        Me.lblRowValue.TabIndex = 7
        Me.lblRowValue.Text = "2"
        Me.lblRowValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDecRow
        '
        Me.btnDecRow.BorderRadius = 4
        Me.btnDecRow.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnDecRow.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDecRow.ForeColor = System.Drawing.Color.White
        Me.btnDecRow.Location = New System.Drawing.Point(153, 7)
        Me.btnDecRow.Name = "btnDecRow"
        Me.btnDecRow.Size = New System.Drawing.Size(24, 24)
        Me.btnDecRow.TabIndex = 8
        Me.btnDecRow.Text = "-"
        '
        'pnlColRowSep
        '
        Me.pnlColRowSep.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.pnlColRowSep.Location = New System.Drawing.Point(148, 7)
        Me.pnlColRowSep.Name = "pnlColRowSep"
        Me.pnlColRowSep.Size = New System.Drawing.Size(1, 24)
        Me.pnlColRowSep.TabIndex = 4
        '
        'lblColTitle
        '
        Me.lblColTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblColTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblColTitle.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblColTitle.Location = New System.Drawing.Point(96, 7)
        Me.lblColTitle.Name = "lblColTitle"
        Me.lblColTitle.Size = New System.Drawing.Size(47, 26)
        Me.lblColTitle.TabIndex = 0
        Me.lblColTitle.Text = "الأعمدة:"
        Me.lblColTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnIncCol
        '
        Me.btnIncCol.BorderRadius = 4
        Me.btnIncCol.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnIncCol.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnIncCol.ForeColor = System.Drawing.Color.White
        Me.btnIncCol.Location = New System.Drawing.Point(67, 7)
        Me.btnIncCol.Name = "btnIncCol"
        Me.btnIncCol.Size = New System.Drawing.Size(24, 24)
        Me.btnIncCol.TabIndex = 1
        Me.btnIncCol.Text = "+"
        '
        'lblColValue
        '
        Me.lblColValue.BackColor = System.Drawing.Color.Transparent
        Me.lblColValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblColValue.ForeColor = System.Drawing.Color.White
        Me.lblColValue.Location = New System.Drawing.Point(37, 7)
        Me.lblColValue.Name = "lblColValue"
        Me.lblColValue.Size = New System.Drawing.Size(24, 26)
        Me.lblColValue.TabIndex = 2
        Me.lblColValue.Text = "4"
        Me.lblColValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDecCol
        '
        Me.btnDecCol.BorderRadius = 4
        Me.btnDecCol.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnDecCol.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDecCol.ForeColor = System.Drawing.Color.White
        Me.btnDecCol.Location = New System.Drawing.Point(8, 7)
        Me.btnDecCol.Name = "btnDecCol"
        Me.btnDecCol.Size = New System.Drawing.Size(24, 24)
        Me.btnDecCol.TabIndex = 3
        Me.btnDecCol.Text = "-"
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmPOS
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1450, 900)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.Guna2Panel3)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPOS"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نظام نقاط البيع"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel3.ResumeLayout(False)
        Me.Guna2Panel21.ResumeLayout(False)
        Me.Guna2Panel22.ResumeLayout(False)
        Me.Guna2Panel20.ResumeLayout(False)
        Me.Guna2Panel24.ResumeLayout(False)
        Me.Guna2Panel26.ResumeLayout(False)
        Me.Guna2Panel13.ResumeLayout(False)
        Me.Guna2Panel15.ResumeLayout(False)
        Me.Guna2Panel19.ResumeLayout(False)
        Me.Guna2Panel18.ResumeLayout(False)
        Me.Guna2Panel14.ResumeLayout(False)
        Me.Guna2Panel17.ResumeLayout(False)
        Me.Guna2Panel16.ResumeLayout(False)
        Me.Guna2Panel11.ResumeLayout(False)
        Me.Guna2Panel12.ResumeLayout(False)
        Me.Guna2Panel10.ResumeLayout(False)
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel9.ResumeLayout(False)
        Me.pnlCategoryGridToolbar.ResumeLayout(False)
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents flpCategories As FlowLayoutPanel
    Friend WithEvents flpProducts As FlowLayoutPanel
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2Panel8 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel7 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel6 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel9 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblInvoiceNumber As Label
    Friend WithEvents Guna2Panel10 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel11 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dgvInvoice As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents btnAddCategoryForm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTakeaway As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel12 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblOrderTypeStatus As Label
    Friend WithEvents btnDelivery As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDineIn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblDateTime As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblUser_fullName As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblCurrentShift As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Guna2Panel13 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel15 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel14 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblSubTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Guna2Panel19 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents Guna2Panel18 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents lblDineInFee As Label
    Friend WithEvents Guna2Panel17 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents lblDeliveryFee As Label
    Friend WithEvents Guna2Panel16 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnPay As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel20 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel24 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel26 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label25 As Label
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents btnHoldInvoice As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteRow As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btntables As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPendingInvoices As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2Panel21 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnSelectCustomer As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel22 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtCustomer As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnclear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlCategoryGridToolbar As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblColTitle As Label
    Friend WithEvents btnDecCol As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblColValue As Label
    Friend WithEvents btnIncCol As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlColRowSep As Panel
    Friend WithEvents lblRowTitle As Label
    Friend WithEvents btnDecRow As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblRowValue As Label
    Friend WithEvents btnIncRow As Guna.UI2.WinForms.Guna2Button
End Class
