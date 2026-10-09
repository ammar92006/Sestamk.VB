<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Reports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reports))
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_update = New Guna.UI2.WinForms.Guna2Button()
        Me.SimpleButton1 = New Guna.UI2.WinForms.Guna2Button()
        Me.SimpleButton2 = New Guna.UI2.WinForms.Guna2Button()
        Me.SimpleButton3 = New Guna.UI2.WinForms.Guna2Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbl_user_name = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btn_min = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_max = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_close = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.lblHeader = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.tpSales = New System.Windows.Forms.TabPage()
        Me.btn_show_pirfit = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_inv_delete = New System.Windows.Forms.Button()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txt_Total_Profit_dgv = New System.Windows.Forms.TextBox()
        Me.txt_sum_col = New System.Windows.Forms.TextBox()
        Me.cboColumns = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dgvSales = New System.Windows.Forms.DataGridView()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.chkSalesDetails = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.chkSalesDate = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.dtSalesTo = New System.Windows.Forms.DateTimePicker()
        Me.dtSalesFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnSearchSales = New Guna.UI2.WinForms.Guna2Button()
        Me.lblPay = New System.Windows.Forms.Label()
        Me.cboSalesPay = New System.Windows.Forms.ComboBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.cboSalesUser = New System.Windows.Forms.ComboBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.cboSalesCustomer = New System.Windows.Forms.ComboBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.TabPurchases = New System.Windows.Forms.TabPage()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dgvPurchase = New System.Windows.Forms.DataGridView()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.chkPurchaseDetails = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.chkPurchaseDate = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.dtPurchaseTo = New System.Windows.Forms.DateTimePicker()
        Me.dtPurchaseFrom = New System.Windows.Forms.DateTimePicker()
        Me.btn_inv_purchases_del = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPurchasePay = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPurchaseUser = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPurchaseSupplier = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSearchPurchase = New Guna.UI2.WinForms.Guna2Button()
        Me.TabStockMovement = New System.Windows.Forms.TabPage()
        Me.dgvStock = New System.Windows.Forms.DataGridView()
        Me.tabInvoiceDetails = New System.Windows.Forms.TabPage()
        Me.btn_edit_sale = New System.Windows.Forms.Button()
        Me.txt_Total_Profit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtCustomerPhone = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCopies = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_Invoice_type = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_Payment_Method = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtUser = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtNet = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblTotalAfter = New System.Windows.Forms.Label()
        Me.txtPaid = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtRemaining = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblRemaining = New System.Windows.Forms.Label()
        Me.txtDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.txtTotal = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblTotalBefore = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpInvDate = New System.Windows.Forms.DateTimePicker()
        Me.txtInvID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_Customer_Code = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dgvInvoiceDetails = New System.Windows.Forms.DataGridView()
        Me.btnSendInvoiceWhatsApp = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrint = New Guna.UI2.WinForms.Guna2Button()
        Me.TabSupplier = New System.Windows.Forms.TabPage()
        Me.txtSupplier_Num = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtCopies2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_Invoice_type2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txt_Payment_Method2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtUser2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtNet2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtPaid2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtRemaining2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtDiscount2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtTotal2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.dtpInvDate2 = New System.Windows.Forms.DateTimePicker()
        Me.txtInvID2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtSupplierCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtSupplierName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.dgvInvoiceDetailsPurchase = New System.Windows.Forms.DataGridView()
        Me.btn_sand_supplier = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_purchases_print = New Guna.UI2.WinForms.Guna2Button()
        Me.txtSalesSearch = New System.Windows.Forms.TabPage()
        Me.dgv_balance_download = New System.Windows.Forms.DataGridView()
        Me.TabReports = New Guna.UI2.WinForms.Guna2TabControl()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.tpSales.SuspendLayout()
        CType(Me.dgvSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPurchases.SuspendLayout()
        CType(Me.dgvPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabStockMovement.SuspendLayout()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInvoiceDetails.SuspendLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSupplier.SuspendLayout()
        CType(Me.dgvInvoiceDetailsPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.txtSalesSearch.SuspendLayout()
        CType(Me.dgv_balance_download, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabReports.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btn_update)
        Me.panelHeader.Controls.Add(Me.SimpleButton1)
        Me.panelHeader.Controls.Add(Me.SimpleButton2)
        Me.panelHeader.Controls.Add(Me.SimpleButton3)
        Me.panelHeader.Controls.Add(Me.Label14)
        Me.panelHeader.Controls.Add(Me.lbl_user_name)
        Me.panelHeader.Controls.Add(Me.lblTime)
        Me.panelHeader.Controls.Add(Me.lblDate)
        Me.panelHeader.Controls.Add(Me.btn_min)
        Me.panelHeader.Controls.Add(Me.btn_max)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.lblHeader)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1600, 70)
        Me.panelHeader.TabIndex = 78
        '
        'btn_update
        '
        Me.btn_update.AutoSize = True
        Me.btn_update.Location = New System.Drawing.Point(144, 17)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(38, 36)
        Me.btn_update.TabIndex = 13
        '
        'SimpleButton1
        '
        Me.SimpleButton1.AutoSize = True
        Me.SimpleButton1.Location = New System.Drawing.Point(100, 17)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(38, 36)
        Me.SimpleButton1.TabIndex = 12
        '
        'SimpleButton2
        '
        Me.SimpleButton2.AutoSize = True
        Me.SimpleButton2.Location = New System.Drawing.Point(56, 17)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(38, 36)
        Me.SimpleButton2.TabIndex = 11
        '
        'SimpleButton3
        '
        Me.SimpleButton3.AutoSize = True
        Me.SimpleButton3.Location = New System.Drawing.Point(12, 17)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(38, 36)
        Me.SimpleButton3.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(468, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(199, 53)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "اسم المستخدم"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_user_name
        '
        Me.lbl_user_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user_name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lbl_user_name.Location = New System.Drawing.Point(209, 9)
        Me.lbl_user_name.Name = "lbl_user_name"
        Me.lbl_user_name.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_user_name.Size = New System.Drawing.Size(242, 53)
        Me.lbl_user_name.TabIndex = 8
        Me.lbl_user_name.Text = "Time Now"
        Me.lbl_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblTime.Location = New System.Drawing.Point(956, 9)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTime.Size = New System.Drawing.Size(318, 53)
        Me.lblTime.TabIndex = 6
        Me.lblTime.Text = "Time Now"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblDate.Location = New System.Drawing.Point(1280, 9)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDate.Size = New System.Drawing.Size(308, 53)
        Me.lblDate.TabIndex = 7
        Me.lblDate.Text = "Time Now"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btn_min.Size = New System.Drawing.Size(10, 20)
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
        Me.btn_max.Size = New System.Drawing.Size(10, 20)
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
        Me.btn_close.Size = New System.Drawing.Size(10, 20)
        Me.btn_close.TabIndex = 3
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(745, 9)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(102, 44)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "التقارير"
        Me.lblHeader.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'tpSales
        '
        Me.tpSales.Controls.Add(Me.btn_show_pirfit)
        Me.tpSales.Controls.Add(Me.btn_inv_delete)
        Me.tpSales.Controls.Add(Me.Label39)
        Me.tpSales.Controls.Add(Me.txt_Total_Profit_dgv)
        Me.tpSales.Controls.Add(Me.txt_sum_col)
        Me.tpSales.Controls.Add(Me.cboColumns)
        Me.tpSales.Controls.Add(Me.Guna2HtmlLabel2)
        Me.tpSales.Controls.Add(Me.dgvSales)
        Me.tpSales.Controls.Add(Me.Guna2HtmlLabel1)
        Me.tpSales.Controls.Add(Me.chkSalesDetails)
        Me.tpSales.Controls.Add(Me.chkSalesDate)
        Me.tpSales.Controls.Add(Me.dtSalesTo)
        Me.tpSales.Controls.Add(Me.dtSalesFrom)
        Me.tpSales.Controls.Add(Me.btnSearchSales)
        Me.tpSales.Controls.Add(Me.lblPay)
        Me.tpSales.Controls.Add(Me.cboSalesPay)
        Me.tpSales.Controls.Add(Me.lblUser)
        Me.tpSales.Controls.Add(Me.cboSalesUser)
        Me.tpSales.Controls.Add(Me.lblCustomer)
        Me.tpSales.Controls.Add(Me.cboSalesCustomer)
        Me.tpSales.Controls.Add(Me.lblTo)
        Me.tpSales.Controls.Add(Me.lblFrom)
        Me.tpSales.Location = New System.Drawing.Point(4, 64)
        Me.tpSales.Name = "tpSales"
        Me.tpSales.Size = New System.Drawing.Size(1592, 762)
        Me.tpSales.TabIndex = 5
        Me.tpSales.Text = "المبيعات"
        Me.tpSales.UseVisualStyleBackColor = True
        '
        'btn_show_pirfit
        '
        Me.btn_show_pirfit.BorderRadius = 10
        Me.btn_show_pirfit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_show_pirfit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_show_pirfit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_show_pirfit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_show_pirfit.FillColor = System.Drawing.Color.Silver
        Me.btn_show_pirfit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_show_pirfit.ForeColor = System.Drawing.Color.White
        Me.btn_show_pirfit.Image = Global.WindowsApp1.My.Resources.Resources.show
        Me.btn_show_pirfit.ImageSize = New System.Drawing.Size(64, 64)
        Me.btn_show_pirfit.Location = New System.Drawing.Point(208, 708)
        Me.btn_show_pirfit.Name = "btn_show_pirfit"
        Me.btn_show_pirfit.Size = New System.Drawing.Size(94, 45)
        Me.btn_show_pirfit.TabIndex = 46
        '
        'btn_inv_delete
        '
        Me.btn_inv_delete.Image = Global.WindowsApp1.My.Resources.Resources.delete1
        Me.btn_inv_delete.Location = New System.Drawing.Point(14, 155)
        Me.btn_inv_delete.Name = "btn_inv_delete"
        Me.btn_inv_delete.Size = New System.Drawing.Size(106, 71)
        Me.btn_inv_delete.TabIndex = 45
        Me.btn_inv_delete.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(632, 708)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(318, 44)
        Me.Label39.TabIndex = 44
        Me.Label39.Text = "الربح الصافي"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label39.Visible = False
        '
        'txt_Total_Profit_dgv
        '
        Me.txt_Total_Profit_dgv.Location = New System.Drawing.Point(308, 708)
        Me.txt_Total_Profit_dgv.Name = "txt_Total_Profit_dgv"
        Me.txt_Total_Profit_dgv.Size = New System.Drawing.Size(318, 44)
        Me.txt_Total_Profit_dgv.TabIndex = 43
        Me.txt_Total_Profit_dgv.Visible = False
        '
        'txt_sum_col
        '
        Me.txt_sum_col.Location = New System.Drawing.Point(971, 708)
        Me.txt_sum_col.Name = "txt_sum_col"
        Me.txt_sum_col.Size = New System.Drawing.Size(232, 44)
        Me.txt_sum_col.TabIndex = 41
        '
        'cboColumns
        '
        Me.cboColumns.BackColor = System.Drawing.Color.Transparent
        Me.cboColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColumns.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboColumns.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboColumns.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cboColumns.ForeColor = System.Drawing.Color.Black
        Me.cboColumns.ItemHeight = 35
        Me.cboColumns.Location = New System.Drawing.Point(1209, 710)
        Me.cboColumns.Name = "cboColumns"
        Me.cboColumns.Size = New System.Drawing.Size(217, 41)
        Me.cboColumns.TabIndex = 40
        Me.cboColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel2.AutoSize = False
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(546, 197)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(222, 45)
        Me.Guna2HtmlLabel2.TabIndex = 38
        Me.Guna2HtmlLabel2.Text = "الفاتورة تفاصيل"
        Me.Guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvSales
        '
        Me.dgvSales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSales.ColumnHeadersHeight = 65
        Me.dgvSales.Location = New System.Drawing.Point(7, 248)
        Me.dgvSales.Name = "dgvSales"
        Me.dgvSales.RowTemplate.Height = 40
        Me.dgvSales.Size = New System.Drawing.Size(1576, 454)
        Me.dgvSales.TabIndex = 39
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.AutoSize = False
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(546, 139)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(222, 45)
        Me.Guna2HtmlLabel1.TabIndex = 36
        Me.Guna2HtmlLabel1.Text = "التاريخ"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkSalesDetails
        '
        Me.chkSalesDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSalesDetails.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesDetails.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesDetails.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesDetails.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSalesDetails.Location = New System.Drawing.Point(774, 197)
        Me.chkSalesDetails.Name = "chkSalesDetails"
        Me.chkSalesDetails.Size = New System.Drawing.Size(93, 44)
        Me.chkSalesDetails.TabIndex = 37
        Me.chkSalesDetails.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesDetails.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesDetails.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesDetails.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'chkSalesDate
        '
        Me.chkSalesDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSalesDate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesDate.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkSalesDate.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesDate.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkSalesDate.Location = New System.Drawing.Point(774, 139)
        Me.chkSalesDate.Name = "chkSalesDate"
        Me.chkSalesDate.Size = New System.Drawing.Size(93, 44)
        Me.chkSalesDate.TabIndex = 35
        Me.chkSalesDate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesDate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkSalesDate.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkSalesDate.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'dtSalesTo
        '
        Me.dtSalesTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtSalesTo.Location = New System.Drawing.Point(126, 16)
        Me.dtSalesTo.Name = "dtSalesTo"
        Me.dtSalesTo.Size = New System.Drawing.Size(417, 44)
        Me.dtSalesTo.TabIndex = 19
        '
        'dtSalesFrom
        '
        Me.dtSalesFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtSalesFrom.Location = New System.Drawing.Point(873, 16)
        Me.dtSalesFrom.Name = "dtSalesFrom"
        Me.dtSalesFrom.Size = New System.Drawing.Size(386, 44)
        Me.dtSalesFrom.TabIndex = 18
        '
        'btnSearchSales
        '
        Me.btnSearchSales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchSales.Location = New System.Drawing.Point(126, 155)
        Me.btnSearchSales.Name = "btnSearchSales"
        Me.btnSearchSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSearchSales.Size = New System.Drawing.Size(403, 71)
        Me.btnSearchSales.TabIndex = 16
        Me.btnSearchSales.Text = "بحث"
        '
        'lblPay
        '
        Me.lblPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPay.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPay.ForeColor = System.Drawing.Color.Black
        Me.lblPay.Location = New System.Drawing.Point(1265, 155)
        Me.lblPay.Name = "lblPay"
        Me.lblPay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPay.Size = New System.Drawing.Size(318, 53)
        Me.lblPay.TabIndex = 15
        Me.lblPay.Text = "طريقة الدفع"
        Me.lblPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboSalesPay
        '
        Me.cboSalesPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSalesPay.FormattingEnabled = True
        Me.cboSalesPay.Location = New System.Drawing.Point(873, 155)
        Me.cboSalesPay.Name = "cboSalesPay"
        Me.cboSalesPay.Size = New System.Drawing.Size(386, 45)
        Me.cboSalesPay.TabIndex = 14
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Location = New System.Drawing.Point(549, 82)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUser.Size = New System.Drawing.Size(318, 53)
        Me.lblUser.TabIndex = 13
        Me.lblUser.Text = "اسم المستخدم"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboSalesUser
        '
        Me.cboSalesUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSalesUser.FormattingEnabled = True
        Me.cboSalesUser.Location = New System.Drawing.Point(126, 82)
        Me.cboSalesUser.Name = "cboSalesUser"
        Me.cboSalesUser.Size = New System.Drawing.Size(417, 45)
        Me.cboSalesUser.TabIndex = 12
        '
        'lblCustomer
        '
        Me.lblCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.Black
        Me.lblCustomer.Location = New System.Drawing.Point(1265, 83)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCustomer.Size = New System.Drawing.Size(318, 53)
        Me.lblCustomer.TabIndex = 11
        Me.lblCustomer.Text = "اسم العميل"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboSalesCustomer
        '
        Me.cboSalesCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSalesCustomer.FormattingEnabled = True
        Me.cboSalesCustomer.Location = New System.Drawing.Point(873, 83)
        Me.cboSalesCustomer.Name = "cboSalesCustomer"
        Me.cboSalesCustomer.Size = New System.Drawing.Size(386, 45)
        Me.cboSalesCustomer.TabIndex = 10
        '
        'lblTo
        '
        Me.lblTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTo.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.ForeColor = System.Drawing.Color.Black
        Me.lblTo.Location = New System.Drawing.Point(549, 11)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTo.Size = New System.Drawing.Size(318, 53)
        Me.lblTo.TabIndex = 9
        Me.lblTo.Text = "إلى تاريخ"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFrom
        '
        Me.lblFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFrom.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.ForeColor = System.Drawing.Color.Black
        Me.lblFrom.Location = New System.Drawing.Point(1265, 8)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrom.Size = New System.Drawing.Size(318, 53)
        Me.lblFrom.TabIndex = 7
        Me.lblFrom.Text = "من تاريخ"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPurchases
        '
        Me.TabPurchases.Controls.Add(Me.Guna2HtmlLabel3)
        Me.TabPurchases.Controls.Add(Me.dgvPurchase)
        Me.TabPurchases.Controls.Add(Me.Guna2HtmlLabel4)
        Me.TabPurchases.Controls.Add(Me.chkPurchaseDetails)
        Me.TabPurchases.Controls.Add(Me.chkPurchaseDate)
        Me.TabPurchases.Controls.Add(Me.dtPurchaseTo)
        Me.TabPurchases.Controls.Add(Me.dtPurchaseFrom)
        Me.TabPurchases.Controls.Add(Me.btn_inv_purchases_del)
        Me.TabPurchases.Controls.Add(Me.Label1)
        Me.TabPurchases.Controls.Add(Me.cboPurchasePay)
        Me.TabPurchases.Controls.Add(Me.Label2)
        Me.TabPurchases.Controls.Add(Me.cboPurchaseUser)
        Me.TabPurchases.Controls.Add(Me.Label3)
        Me.TabPurchases.Controls.Add(Me.cboPurchaseSupplier)
        Me.TabPurchases.Controls.Add(Me.Label4)
        Me.TabPurchases.Controls.Add(Me.Label5)
        Me.TabPurchases.Controls.Add(Me.btnSearchPurchase)
        Me.TabPurchases.Location = New System.Drawing.Point(4, 64)
        Me.TabPurchases.Name = "TabPurchases"
        Me.TabPurchases.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPurchases.Size = New System.Drawing.Size(1592, 762)
        Me.TabPurchases.TabIndex = 1
        Me.TabPurchases.Text = "تقارير المشتريات"
        Me.TabPurchases.UseVisualStyleBackColor = True
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel3.AutoSize = False
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(546, 194)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(222, 45)
        Me.Guna2HtmlLabel3.TabIndex = 54
        Me.Guna2HtmlLabel3.Text = "الفاتورة تفاصيل"
        Me.Guna2HtmlLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvPurchase
        '
        Me.dgvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPurchase.Location = New System.Drawing.Point(20, 245)
        Me.dgvPurchase.Name = "dgvPurchase"
        Me.dgvPurchase.RowTemplate.Height = 40
        Me.dgvPurchase.Size = New System.Drawing.Size(1576, 509)
        Me.dgvPurchase.TabIndex = 55
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel4.AutoSize = False
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(546, 136)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(222, 45)
        Me.Guna2HtmlLabel4.TabIndex = 52
        Me.Guna2HtmlLabel4.Text = "التاريخ"
        Me.Guna2HtmlLabel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkPurchaseDetails
        '
        Me.chkPurchaseDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPurchaseDetails.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchaseDetails.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchaseDetails.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchaseDetails.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkPurchaseDetails.Location = New System.Drawing.Point(774, 194)
        Me.chkPurchaseDetails.Name = "chkPurchaseDetails"
        Me.chkPurchaseDetails.Size = New System.Drawing.Size(93, 44)
        Me.chkPurchaseDetails.TabIndex = 53
        Me.chkPurchaseDetails.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchaseDetails.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchaseDetails.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchaseDetails.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'chkPurchaseDate
        '
        Me.chkPurchaseDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPurchaseDate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchaseDate.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPurchaseDate.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchaseDate.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkPurchaseDate.Location = New System.Drawing.Point(774, 136)
        Me.chkPurchaseDate.Name = "chkPurchaseDate"
        Me.chkPurchaseDate.Size = New System.Drawing.Size(93, 44)
        Me.chkPurchaseDate.TabIndex = 51
        Me.chkPurchaseDate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchaseDate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkPurchaseDate.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkPurchaseDate.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'dtPurchaseTo
        '
        Me.dtPurchaseTo.Location = New System.Drawing.Point(158, 14)
        Me.dtPurchaseTo.Name = "dtPurchaseTo"
        Me.dtPurchaseTo.Size = New System.Drawing.Size(386, 44)
        Me.dtPurchaseTo.TabIndex = 50
        '
        'dtPurchaseFrom
        '
        Me.dtPurchaseFrom.Location = New System.Drawing.Point(874, 14)
        Me.dtPurchaseFrom.Name = "dtPurchaseFrom"
        Me.dtPurchaseFrom.Size = New System.Drawing.Size(386, 44)
        Me.dtPurchaseFrom.TabIndex = 49
        '
        'btn_inv_purchases_del
        '
        Me.btn_inv_purchases_del.Image = Global.WindowsApp1.My.Resources.Resources.delete1
        Me.btn_inv_purchases_del.Location = New System.Drawing.Point(56, 153)
        Me.btn_inv_purchases_del.Name = "btn_inv_purchases_del"
        Me.btn_inv_purchases_del.Size = New System.Drawing.Size(106, 71)
        Me.btn_inv_purchases_del.TabIndex = 56
        Me.btn_inv_purchases_del.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1265, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(318, 53)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "طريقة الدفع"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPurchasePay
        '
        Me.cboPurchasePay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPurchasePay.FormattingEnabled = True
        Me.cboPurchasePay.Location = New System.Drawing.Point(873, 153)
        Me.cboPurchasePay.Name = "cboPurchasePay"
        Me.cboPurchasePay.Size = New System.Drawing.Size(386, 45)
        Me.cboPurchasePay.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(549, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(318, 53)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "اسم المستخدم"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPurchaseUser
        '
        Me.cboPurchaseUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPurchaseUser.FormattingEnabled = True
        Me.cboPurchaseUser.Location = New System.Drawing.Point(157, 80)
        Me.cboPurchaseUser.Name = "cboPurchaseUser"
        Me.cboPurchaseUser.Size = New System.Drawing.Size(386, 45)
        Me.cboPurchaseUser.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(1265, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(318, 53)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "اسم المورد"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPurchaseSupplier
        '
        Me.cboPurchaseSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPurchaseSupplier.FormattingEnabled = True
        Me.cboPurchaseSupplier.Location = New System.Drawing.Point(873, 81)
        Me.cboPurchaseSupplier.Name = "cboPurchaseSupplier"
        Me.cboPurchaseSupplier.Size = New System.Drawing.Size(386, 45)
        Me.cboPurchaseSupplier.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(549, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(318, 53)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "إلى تاريخ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(1265, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(318, 53)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "من تاريخ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSearchPurchase
        '
        Me.btnSearchPurchase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchPurchase.Location = New System.Drawing.Point(165, 153)
        Me.btnSearchPurchase.Name = "btnSearchPurchase"
        Me.btnSearchPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSearchPurchase.Size = New System.Drawing.Size(350, 71)
        Me.btnSearchPurchase.TabIndex = 48
        Me.btnSearchPurchase.Text = "بحث"
        '
        'TabStockMovement
        '
        Me.TabStockMovement.Controls.Add(Me.dgvStock)
        Me.TabStockMovement.Location = New System.Drawing.Point(4, 64)
        Me.TabStockMovement.Name = "TabStockMovement"
        Me.TabStockMovement.Size = New System.Drawing.Size(1592, 762)
        Me.TabStockMovement.TabIndex = 2
        Me.TabStockMovement.Text = "حركة المخزون"
        Me.TabStockMovement.UseVisualStyleBackColor = True
        '
        'dgvStock
        '
        Me.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStock.Location = New System.Drawing.Point(0, 0)
        Me.dgvStock.Name = "dgvStock"
        Me.dgvStock.RowTemplate.Height = 40
        Me.dgvStock.Size = New System.Drawing.Size(1592, 762)
        Me.dgvStock.TabIndex = 71
        '
        'tabInvoiceDetails
        '
        Me.tabInvoiceDetails.Controls.Add(Me.btn_edit_sale)
        Me.tabInvoiceDetails.Controls.Add(Me.txt_Total_Profit)
        Me.tabInvoiceDetails.Controls.Add(Me.Label24)
        Me.tabInvoiceDetails.Controls.Add(Me.txtCustomerPhone)
        Me.tabInvoiceDetails.Controls.Add(Me.Label25)
        Me.tabInvoiceDetails.Controls.Add(Me.txtCopies)
        Me.tabInvoiceDetails.Controls.Add(Me.txt_Invoice_type)
        Me.tabInvoiceDetails.Controls.Add(Me.Label23)
        Me.tabInvoiceDetails.Controls.Add(Me.txt_Payment_Method)
        Me.tabInvoiceDetails.Controls.Add(Me.txtUser)
        Me.tabInvoiceDetails.Controls.Add(Me.Label22)
        Me.tabInvoiceDetails.Controls.Add(Me.txtNet)
        Me.tabInvoiceDetails.Controls.Add(Me.lblTotalAfter)
        Me.tabInvoiceDetails.Controls.Add(Me.txtPaid)
        Me.tabInvoiceDetails.Controls.Add(Me.lblPaid)
        Me.tabInvoiceDetails.Controls.Add(Me.Label21)
        Me.tabInvoiceDetails.Controls.Add(Me.txtRemaining)
        Me.tabInvoiceDetails.Controls.Add(Me.lblRemaining)
        Me.tabInvoiceDetails.Controls.Add(Me.txtDiscount)
        Me.tabInvoiceDetails.Controls.Add(Me.lblDiscount)
        Me.tabInvoiceDetails.Controls.Add(Me.txtTotal)
        Me.tabInvoiceDetails.Controls.Add(Me.lblTotalBefore)
        Me.tabInvoiceDetails.Controls.Add(Me.Label20)
        Me.tabInvoiceDetails.Controls.Add(Me.dtpInvDate)
        Me.tabInvoiceDetails.Controls.Add(Me.txtInvID)
        Me.tabInvoiceDetails.Controls.Add(Me.Label17)
        Me.tabInvoiceDetails.Controls.Add(Me.txt_Customer_Code)
        Me.tabInvoiceDetails.Controls.Add(Me.Label18)
        Me.tabInvoiceDetails.Controls.Add(Me.txtCustomerName)
        Me.tabInvoiceDetails.Controls.Add(Me.Label19)
        Me.tabInvoiceDetails.Controls.Add(Me.dgvInvoiceDetails)
        Me.tabInvoiceDetails.Controls.Add(Me.btnSendInvoiceWhatsApp)
        Me.tabInvoiceDetails.Controls.Add(Me.btnPrint)
        Me.tabInvoiceDetails.Location = New System.Drawing.Point(4, 64)
        Me.tabInvoiceDetails.Name = "tabInvoiceDetails"
        Me.tabInvoiceDetails.Size = New System.Drawing.Size(1592, 762)
        Me.tabInvoiceDetails.TabIndex = 3
        Me.tabInvoiceDetails.Text = "فاتورة بيع"
        Me.tabInvoiceDetails.UseVisualStyleBackColor = True
        '
        'btn_edit_sale
        '
        Me.btn_edit_sale.Location = New System.Drawing.Point(8, 342)
        Me.btn_edit_sale.Name = "btn_edit_sale"
        Me.btn_edit_sale.Size = New System.Drawing.Size(251, 59)
        Me.btn_edit_sale.TabIndex = 5650
        Me.btn_edit_sale.Text = "تعديل"
        Me.btn_edit_sale.UseVisualStyleBackColor = True
        '
        'txt_Total_Profit
        '
        Me.txt_Total_Profit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Total_Profit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Total_Profit.DefaultText = ""
        Me.txt_Total_Profit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Total_Profit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Total_Profit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Total_Profit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Total_Profit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Total_Profit.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Total_Profit.ForeColor = System.Drawing.Color.Black
        Me.txt_Total_Profit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Total_Profit.Location = New System.Drawing.Point(932, 331)
        Me.txt_Total_Profit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Total_Profit.Name = "txt_Total_Profit"
        Me.txt_Total_Profit.PlaceholderText = ""
        Me.txt_Total_Profit.ReadOnly = True
        Me.txt_Total_Profit.SelectedText = ""
        Me.txt_Total_Profit.Size = New System.Drawing.Size(414, 45)
        Me.txt_Total_Profit.TabIndex = 5649
        Me.txt_Total_Profit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(1351, 330)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(238, 45)
        Me.Label24.TabIndex = 5648
        Me.Label24.Text = "الربح الصافي"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCustomerPhone
        '
        Me.txtCustomerPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomerPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomerPhone.DefaultText = ""
        Me.txtCustomerPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCustomerPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCustomerPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerPhone.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCustomerPhone.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerPhone.Location = New System.Drawing.Point(268, 331)
        Me.txtCustomerPhone.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCustomerPhone.Name = "txtCustomerPhone"
        Me.txtCustomerPhone.PlaceholderText = ""
        Me.txtCustomerPhone.SelectedText = ""
        Me.txtCustomerPhone.Size = New System.Drawing.Size(414, 45)
        Me.txtCustomerPhone.TabIndex = 5647
        Me.txtCustomerPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(691, 331)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(141, 45)
        Me.Label25.TabIndex = 5646
        Me.Label25.Text = "رقم الهاتف"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCopies
        '
        Me.txtCopies.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCopies.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCopies.DefaultText = ""
        Me.txtCopies.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCopies.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCopies.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCopies.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCopies.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCopies.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCopies.ForeColor = System.Drawing.Color.Black
        Me.txtCopies.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCopies.Location = New System.Drawing.Point(8, 200)
        Me.txtCopies.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCopies.Name = "txtCopies"
        Me.txtCopies.PlaceholderText = ""
        Me.txtCopies.SelectedText = ""
        Me.txtCopies.Size = New System.Drawing.Size(251, 45)
        Me.txtCopies.TabIndex = 5644
        Me.txtCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Invoice_type
        '
        Me.txt_Invoice_type.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Invoice_type.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Invoice_type.DefaultText = ""
        Me.txt_Invoice_type.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Invoice_type.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Invoice_type.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Invoice_type.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Invoice_type.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Invoice_type.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Invoice_type.ForeColor = System.Drawing.Color.Black
        Me.txt_Invoice_type.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Invoice_type.Location = New System.Drawing.Point(11, 73)
        Me.txt_Invoice_type.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Invoice_type.Name = "txt_Invoice_type"
        Me.txt_Invoice_type.PlaceholderText = ""
        Me.txt_Invoice_type.SelectedText = ""
        Me.txt_Invoice_type.Size = New System.Drawing.Size(248, 45)
        Me.txt_Invoice_type.TabIndex = 5642
        Me.txt_Invoice_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(22, 17)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(244, 45)
        Me.Label23.TabIndex = 5641
        Me.Label23.Text = "نوع الفاتورة"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Payment_Method
        '
        Me.txt_Payment_Method.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Payment_Method.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Payment_Method.DefaultText = ""
        Me.txt_Payment_Method.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Payment_Method.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Payment_Method.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Payment_Method.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Payment_Method.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Payment_Method.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Payment_Method.ForeColor = System.Drawing.Color.Black
        Me.txt_Payment_Method.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Payment_Method.Location = New System.Drawing.Point(268, 153)
        Me.txt_Payment_Method.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Payment_Method.Name = "txt_Payment_Method"
        Me.txt_Payment_Method.PlaceholderText = ""
        Me.txt_Payment_Method.ReadOnly = True
        Me.txt_Payment_Method.SelectedText = ""
        Me.txt_Payment_Method.Size = New System.Drawing.Size(414, 45)
        Me.txt_Payment_Method.TabIndex = 5640
        Me.txt_Payment_Method.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUser
        '
        Me.txtUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser.DefaultText = ""
        Me.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser.ForeColor = System.Drawing.Color.Black
        Me.txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser.Location = New System.Drawing.Point(932, 118)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.PlaceholderText = ""
        Me.txtUser.SelectedText = ""
        Me.txtUser.Size = New System.Drawing.Size(414, 45)
        Me.txtUser.TabIndex = 5639
        Me.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(1346, 123)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(238, 45)
        Me.Label22.TabIndex = 5638
        Me.Label22.Text = "اسم المستخدم"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNet
        '
        Me.txtNet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNet.DefaultText = ""
        Me.txtNet.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNet.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNet.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNet.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtNet.ForeColor = System.Drawing.Color.Black
        Me.txtNet.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNet.Location = New System.Drawing.Point(932, 277)
        Me.txtNet.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtNet.Name = "txtNet"
        Me.txtNet.PlaceholderText = ""
        Me.txtNet.ReadOnly = True
        Me.txtNet.SelectedText = ""
        Me.txtNet.Size = New System.Drawing.Size(414, 45)
        Me.txtNet.TabIndex = 5637
        Me.txtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalAfter
        '
        Me.lblTotalAfter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAfter.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAfter.Location = New System.Drawing.Point(604, 85)
        Me.lblTotalAfter.Name = "lblTotalAfter"
        Me.lblTotalAfter.Size = New System.Drawing.Size(325, 45)
        Me.lblTotalAfter.TabIndex = 5636
        Me.lblTotalAfter.Text = "الاجمالي بعد الخصم"
        Me.lblTotalAfter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPaid
        '
        Me.txtPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaid.DefaultText = ""
        Me.txtPaid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPaid.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPaid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaid.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtPaid.ForeColor = System.Drawing.Color.Black
        Me.txtPaid.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaid.Location = New System.Drawing.Point(268, 213)
        Me.txtPaid.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.PlaceholderText = ""
        Me.txtPaid.SelectedText = ""
        Me.txtPaid.Size = New System.Drawing.Size(414, 45)
        Me.txtPaid.TabIndex = 5635
        Me.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPaid
        '
        Me.lblPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPaid.BackColor = System.Drawing.Color.Transparent
        Me.lblPaid.Location = New System.Drawing.Point(691, 213)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(141, 45)
        Me.lblPaid.TabIndex = 5634
        Me.lblPaid.Text = "المدفوع"
        Me.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(691, 153)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(226, 45)
        Me.Label21.TabIndex = 5632
        Me.Label21.Text = "طريقة الدفع"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRemaining
        '
        Me.txtRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemaining.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRemaining.DefaultText = ""
        Me.txtRemaining.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtRemaining.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRemaining.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRemaining.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRemaining.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemaining.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtRemaining.ForeColor = System.Drawing.Color.Black
        Me.txtRemaining.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemaining.Location = New System.Drawing.Point(268, 276)
        Me.txtRemaining.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtRemaining.Name = "txtRemaining"
        Me.txtRemaining.PlaceholderText = ""
        Me.txtRemaining.ReadOnly = True
        Me.txtRemaining.SelectedText = ""
        Me.txtRemaining.Size = New System.Drawing.Size(414, 45)
        Me.txtRemaining.TabIndex = 5631
        Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRemaining
        '
        Me.lblRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemaining.BackColor = System.Drawing.Color.Transparent
        Me.lblRemaining.Location = New System.Drawing.Point(691, 276)
        Me.lblRemaining.Name = "lblRemaining"
        Me.lblRemaining.Size = New System.Drawing.Size(141, 45)
        Me.lblRemaining.TabIndex = 5630
        Me.lblRemaining.Text = "المتبقي"
        Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDiscount
        '
        Me.txtDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscount.DefaultText = ""
        Me.txtDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscount.Location = New System.Drawing.Point(268, 16)
        Me.txtDiscount.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.PlaceholderText = ""
        Me.txtDiscount.SelectedText = ""
        Me.txtDiscount.Size = New System.Drawing.Size(339, 45)
        Me.txtDiscount.TabIndex = 5629
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDiscount
        '
        Me.lblDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiscount.BackColor = System.Drawing.Color.Transparent
        Me.lblDiscount.Location = New System.Drawing.Point(604, 18)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(262, 45)
        Me.lblDiscount.TabIndex = 5628
        Me.lblDiscount.Text = "الخصم"
        Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotal.DefaultText = ""
        Me.txtTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotal.Location = New System.Drawing.Point(268, 85)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.PlaceholderText = ""
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.SelectedText = ""
        Me.txtTotal.Size = New System.Drawing.Size(327, 45)
        Me.txtTotal.TabIndex = 5627
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalBefore
        '
        Me.lblTotalBefore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalBefore.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalBefore.Location = New System.Drawing.Point(1351, 276)
        Me.lblTotalBefore.Name = "lblTotalBefore"
        Me.lblTotalBefore.Size = New System.Drawing.Size(238, 45)
        Me.lblTotalBefore.TabIndex = 5626
        Me.lblTotalBefore.Text = "اجمالي الفاتورة"
        Me.lblTotalBefore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(1352, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(238, 45)
        Me.Label20.TabIndex = 5625
        Me.Label20.Text = "تاريخ الفاتورة"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpInvDate
        '
        Me.dtpInvDate.Location = New System.Drawing.Point(932, 13)
        Me.dtpInvDate.Name = "dtpInvDate"
        Me.dtpInvDate.Size = New System.Drawing.Size(414, 44)
        Me.dtpInvDate.TabIndex = 5624
        '
        'txtInvID
        '
        Me.txtInvID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvID.DefaultText = ""
        Me.txtInvID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtInvID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtInvID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInvID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInvID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInvID.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtInvID.ForeColor = System.Drawing.Color.Black
        Me.txtInvID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInvID.Location = New System.Drawing.Point(932, 67)
        Me.txtInvID.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtInvID.Name = "txtInvID"
        Me.txtInvID.PlaceholderText = ""
        Me.txtInvID.SelectedText = ""
        Me.txtInvID.Size = New System.Drawing.Size(414, 45)
        Me.txtInvID.TabIndex = 5623
        Me.txtInvID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(1346, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(238, 45)
        Me.Label17.TabIndex = 5622
        Me.Label17.Text = "رقم الفاتورة"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Customer_Code
        '
        Me.txt_Customer_Code.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Customer_Code.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Customer_Code.DefaultText = ""
        Me.txt_Customer_Code.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Customer_Code.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Customer_Code.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Customer_Code.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Customer_Code.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Customer_Code.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Customer_Code.ForeColor = System.Drawing.Color.Black
        Me.txt_Customer_Code.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Customer_Code.Location = New System.Drawing.Point(932, 169)
        Me.txt_Customer_Code.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Customer_Code.Name = "txt_Customer_Code"
        Me.txt_Customer_Code.PlaceholderText = ""
        Me.txt_Customer_Code.SelectedText = ""
        Me.txt_Customer_Code.Size = New System.Drawing.Size(414, 45)
        Me.txt_Customer_Code.TabIndex = 5621
        Me.txt_Customer_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(1346, 174)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(238, 45)
        Me.Label18.TabIndex = 5620
        Me.Label18.Text = "كود العميل"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomerName.DefaultText = ""
        Me.txtCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCustomerName.ForeColor = System.Drawing.Color.Black
        Me.txtCustomerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerName.Location = New System.Drawing.Point(932, 220)
        Me.txtCustomerName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.PlaceholderText = ""
        Me.txtCustomerName.SelectedText = ""
        Me.txtCustomerName.Size = New System.Drawing.Size(414, 45)
        Me.txtCustomerName.TabIndex = 5619
        Me.txtCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(1346, 225)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(238, 45)
        Me.Label19.TabIndex = 5618
        Me.Label19.Text = "اسم العميل"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvInvoiceDetails
        '
        Me.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInvoiceDetails.ColumnHeadersHeight = 65
        Me.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(0, 407)
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.RowTemplate.Height = 40
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(1592, 355)
        Me.dgvInvoiceDetails.TabIndex = 40
        '
        'btnSendInvoiceWhatsApp
        '
        Me.btnSendInvoiceWhatsApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendInvoiceWhatsApp.Location = New System.Drawing.Point(8, 123)
        Me.btnSendInvoiceWhatsApp.Name = "btnSendInvoiceWhatsApp"
        Me.btnSendInvoiceWhatsApp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSendInvoiceWhatsApp.Size = New System.Drawing.Size(251, 71)
        Me.btnSendInvoiceWhatsApp.TabIndex = 5645
        Me.btnSendInvoiceWhatsApp.Text = "ارسال للعميل "
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(8, 250)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnPrint.Size = New System.Drawing.Size(251, 71)
        Me.btnPrint.TabIndex = 5643
        Me.btnPrint.Text = "طباعة"
        '
        'TabSupplier
        '
        Me.TabSupplier.Controls.Add(Me.txtSupplier_Num)
        Me.TabSupplier.Controls.Add(Me.Label6)
        Me.TabSupplier.Controls.Add(Me.Guna2TextBox1)
        Me.TabSupplier.Controls.Add(Me.Label26)
        Me.TabSupplier.Controls.Add(Me.txtCopies2)
        Me.TabSupplier.Controls.Add(Me.txt_Invoice_type2)
        Me.TabSupplier.Controls.Add(Me.Label27)
        Me.TabSupplier.Controls.Add(Me.txt_Payment_Method2)
        Me.TabSupplier.Controls.Add(Me.txtUser2)
        Me.TabSupplier.Controls.Add(Me.Label28)
        Me.TabSupplier.Controls.Add(Me.txtNet2)
        Me.TabSupplier.Controls.Add(Me.Label29)
        Me.TabSupplier.Controls.Add(Me.txtPaid2)
        Me.TabSupplier.Controls.Add(Me.Label30)
        Me.TabSupplier.Controls.Add(Me.Label31)
        Me.TabSupplier.Controls.Add(Me.txtRemaining2)
        Me.TabSupplier.Controls.Add(Me.Label32)
        Me.TabSupplier.Controls.Add(Me.txtDiscount2)
        Me.TabSupplier.Controls.Add(Me.Label33)
        Me.TabSupplier.Controls.Add(Me.txtTotal2)
        Me.TabSupplier.Controls.Add(Me.Label34)
        Me.TabSupplier.Controls.Add(Me.Label35)
        Me.TabSupplier.Controls.Add(Me.dtpInvDate2)
        Me.TabSupplier.Controls.Add(Me.txtInvID2)
        Me.TabSupplier.Controls.Add(Me.Label36)
        Me.TabSupplier.Controls.Add(Me.txtSupplierCode)
        Me.TabSupplier.Controls.Add(Me.Label37)
        Me.TabSupplier.Controls.Add(Me.txtSupplierName)
        Me.TabSupplier.Controls.Add(Me.Label38)
        Me.TabSupplier.Controls.Add(Me.dgvInvoiceDetailsPurchase)
        Me.TabSupplier.Controls.Add(Me.btn_sand_supplier)
        Me.TabSupplier.Controls.Add(Me.btn_purchases_print)
        Me.TabSupplier.Location = New System.Drawing.Point(4, 64)
        Me.TabSupplier.Name = "TabSupplier"
        Me.TabSupplier.Size = New System.Drawing.Size(1592, 762)
        Me.TabSupplier.TabIndex = 4
        Me.TabSupplier.Text = "فاتورة مشتريات"
        Me.TabSupplier.UseVisualStyleBackColor = True
        '
        'txtSupplier_Num
        '
        Me.txtSupplier_Num.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier_Num.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSupplier_Num.DefaultText = ""
        Me.txtSupplier_Num.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSupplier_Num.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSupplier_Num.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSupplier_Num.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSupplier_Num.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSupplier_Num.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtSupplier_Num.ForeColor = System.Drawing.Color.Black
        Me.txtSupplier_Num.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSupplier_Num.Location = New System.Drawing.Point(928, 277)
        Me.txtSupplier_Num.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSupplier_Num.Name = "txtSupplier_Num"
        Me.txtSupplier_Num.PlaceholderText = ""
        Me.txtSupplier_Num.SelectedText = ""
        Me.txtSupplier_Num.Size = New System.Drawing.Size(414, 45)
        Me.txtSupplier_Num.TabIndex = 5679
        Me.txtSupplier_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(1348, 277)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(206, 55)
        Me.Label6.TabIndex = 5678
        Me.Label6.Text = "رقم الهاتف"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2TextBox1
        '
        Me.Guna2TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Guna2TextBox1.DefaultText = ""
        Me.Guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2TextBox1.ForeColor = System.Drawing.Color.Black
        Me.Guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.Location = New System.Drawing.Point(264, 336)
        Me.Guna2TextBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Guna2TextBox1.Name = "Guna2TextBox1"
        Me.Guna2TextBox1.PlaceholderText = ""
        Me.Guna2TextBox1.SelectedText = ""
        Me.Guna2TextBox1.Size = New System.Drawing.Size(414, 45)
        Me.Guna2TextBox1.TabIndex = 5677
        Me.Guna2TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(687, 336)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(141, 45)
        Me.Label26.TabIndex = 5676
        Me.Label26.Text = "رقم الهاتف"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCopies2
        '
        Me.txtCopies2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCopies2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCopies2.DefaultText = ""
        Me.txtCopies2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCopies2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCopies2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCopies2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCopies2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCopies2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCopies2.ForeColor = System.Drawing.Color.Black
        Me.txtCopies2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCopies2.Location = New System.Drawing.Point(4, 205)
        Me.txtCopies2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtCopies2.Name = "txtCopies2"
        Me.txtCopies2.PlaceholderText = ""
        Me.txtCopies2.SelectedText = ""
        Me.txtCopies2.Size = New System.Drawing.Size(251, 45)
        Me.txtCopies2.TabIndex = 5674
        Me.txtCopies2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Invoice_type2
        '
        Me.txt_Invoice_type2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Invoice_type2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Invoice_type2.DefaultText = ""
        Me.txt_Invoice_type2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Invoice_type2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Invoice_type2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Invoice_type2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Invoice_type2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Invoice_type2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Invoice_type2.ForeColor = System.Drawing.Color.Black
        Me.txt_Invoice_type2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Invoice_type2.Location = New System.Drawing.Point(7, 78)
        Me.txt_Invoice_type2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Invoice_type2.Name = "txt_Invoice_type2"
        Me.txt_Invoice_type2.PlaceholderText = ""
        Me.txt_Invoice_type2.SelectedText = ""
        Me.txt_Invoice_type2.Size = New System.Drawing.Size(248, 45)
        Me.txt_Invoice_type2.TabIndex = 5672
        Me.txt_Invoice_type2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(18, 22)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(244, 45)
        Me.Label27.TabIndex = 5671
        Me.Label27.Text = "نوع الفاتورة"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Payment_Method2
        '
        Me.txt_Payment_Method2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Payment_Method2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Payment_Method2.DefaultText = ""
        Me.txt_Payment_Method2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Payment_Method2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Payment_Method2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Payment_Method2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Payment_Method2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Payment_Method2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Payment_Method2.ForeColor = System.Drawing.Color.Black
        Me.txt_Payment_Method2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Payment_Method2.Location = New System.Drawing.Point(264, 158)
        Me.txt_Payment_Method2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt_Payment_Method2.Name = "txt_Payment_Method2"
        Me.txt_Payment_Method2.PlaceholderText = ""
        Me.txt_Payment_Method2.ReadOnly = True
        Me.txt_Payment_Method2.SelectedText = ""
        Me.txt_Payment_Method2.Size = New System.Drawing.Size(414, 45)
        Me.txt_Payment_Method2.TabIndex = 5670
        Me.txt_Payment_Method2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUser2
        '
        Me.txtUser2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser2.DefaultText = ""
        Me.txtUser2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser2.ForeColor = System.Drawing.Color.Black
        Me.txtUser2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser2.Location = New System.Drawing.Point(928, 123)
        Me.txtUser2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser2.Name = "txtUser2"
        Me.txtUser2.PlaceholderText = ""
        Me.txtUser2.SelectedText = ""
        Me.txtUser2.Size = New System.Drawing.Size(414, 45)
        Me.txtUser2.TabIndex = 5669
        Me.txtUser2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(1342, 128)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(238, 45)
        Me.Label28.TabIndex = 5668
        Me.Label28.Text = "اسم المستخدم"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNet2
        '
        Me.txtNet2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNet2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNet2.DefaultText = ""
        Me.txtNet2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNet2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNet2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNet2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNet2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNet2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtNet2.ForeColor = System.Drawing.Color.Black
        Me.txtNet2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNet2.Location = New System.Drawing.Point(928, 333)
        Me.txtNet2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtNet2.Name = "txtNet2"
        Me.txtNet2.PlaceholderText = ""
        Me.txtNet2.ReadOnly = True
        Me.txtNet2.SelectedText = ""
        Me.txtNet2.Size = New System.Drawing.Size(414, 45)
        Me.txtNet2.TabIndex = 5667
        Me.txtNet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(600, 90)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(325, 45)
        Me.Label29.TabIndex = 5666
        Me.Label29.Text = "الاجمالي بعد الخصم"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPaid2
        '
        Me.txtPaid2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaid2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaid2.DefaultText = ""
        Me.txtPaid2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPaid2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPaid2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaid2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaid2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaid2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtPaid2.ForeColor = System.Drawing.Color.Black
        Me.txtPaid2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaid2.Location = New System.Drawing.Point(264, 218)
        Me.txtPaid2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPaid2.Name = "txtPaid2"
        Me.txtPaid2.PlaceholderText = ""
        Me.txtPaid2.SelectedText = ""
        Me.txtPaid2.Size = New System.Drawing.Size(414, 45)
        Me.txtPaid2.TabIndex = 5665
        Me.txtPaid2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(687, 218)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(141, 45)
        Me.Label30.TabIndex = 5664
        Me.Label30.Text = "المدفوع"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Location = New System.Drawing.Point(687, 158)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(226, 45)
        Me.Label31.TabIndex = 5663
        Me.Label31.Text = "طريقة الدفع"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRemaining2
        '
        Me.txtRemaining2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemaining2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRemaining2.DefaultText = ""
        Me.txtRemaining2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtRemaining2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtRemaining2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRemaining2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtRemaining2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemaining2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtRemaining2.ForeColor = System.Drawing.Color.Black
        Me.txtRemaining2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemaining2.Location = New System.Drawing.Point(264, 281)
        Me.txtRemaining2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtRemaining2.Name = "txtRemaining2"
        Me.txtRemaining2.PlaceholderText = ""
        Me.txtRemaining2.ReadOnly = True
        Me.txtRemaining2.SelectedText = ""
        Me.txtRemaining2.Size = New System.Drawing.Size(414, 45)
        Me.txtRemaining2.TabIndex = 5662
        Me.txtRemaining2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Location = New System.Drawing.Point(687, 281)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(141, 45)
        Me.Label32.TabIndex = 5661
        Me.Label32.Text = "المتبقي"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDiscount2
        '
        Me.txtDiscount2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscount2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscount2.DefaultText = ""
        Me.txtDiscount2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDiscount2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDiscount2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscount2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtDiscount2.ForeColor = System.Drawing.Color.Black
        Me.txtDiscount2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscount2.Location = New System.Drawing.Point(264, 21)
        Me.txtDiscount2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtDiscount2.Name = "txtDiscount2"
        Me.txtDiscount2.PlaceholderText = ""
        Me.txtDiscount2.SelectedText = ""
        Me.txtDiscount2.Size = New System.Drawing.Size(339, 45)
        Me.txtDiscount2.TabIndex = 5660
        Me.txtDiscount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Location = New System.Drawing.Point(600, 23)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(262, 45)
        Me.Label33.TabIndex = 5659
        Me.Label33.Text = "الخصم"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotal2
        '
        Me.txtTotal2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotal2.DefaultText = ""
        Me.txtTotal2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotal2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotal2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotal2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotal2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotal2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotal2.ForeColor = System.Drawing.Color.Black
        Me.txtTotal2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotal2.Location = New System.Drawing.Point(264, 90)
        Me.txtTotal2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtTotal2.Name = "txtTotal2"
        Me.txtTotal2.PlaceholderText = ""
        Me.txtTotal2.ReadOnly = True
        Me.txtTotal2.SelectedText = ""
        Me.txtTotal2.Size = New System.Drawing.Size(327, 45)
        Me.txtTotal2.TabIndex = 5658
        Me.txtTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Location = New System.Drawing.Point(1347, 332)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(238, 45)
        Me.Label34.TabIndex = 5657
        Me.Label34.Text = "اجمالي الفاتورة"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Location = New System.Drawing.Point(1348, 26)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(238, 45)
        Me.Label35.TabIndex = 5656
        Me.Label35.Text = "تاريخ الفاتورة"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpInvDate2
        '
        Me.dtpInvDate2.Location = New System.Drawing.Point(929, 18)
        Me.dtpInvDate2.Name = "dtpInvDate2"
        Me.dtpInvDate2.Size = New System.Drawing.Size(414, 44)
        Me.dtpInvDate2.TabIndex = 5655
        '
        'txtInvID2
        '
        Me.txtInvID2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvID2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvID2.DefaultText = ""
        Me.txtInvID2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtInvID2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtInvID2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInvID2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtInvID2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInvID2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtInvID2.ForeColor = System.Drawing.Color.Black
        Me.txtInvID2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInvID2.Location = New System.Drawing.Point(928, 72)
        Me.txtInvID2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtInvID2.Name = "txtInvID2"
        Me.txtInvID2.PlaceholderText = ""
        Me.txtInvID2.SelectedText = ""
        Me.txtInvID2.Size = New System.Drawing.Size(414, 45)
        Me.txtInvID2.TabIndex = 5654
        Me.txtInvID2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Location = New System.Drawing.Point(1342, 77)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(238, 45)
        Me.Label36.TabIndex = 5653
        Me.Label36.Text = "رقم الفاتورة"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSupplierCode
        '
        Me.txtSupplierCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplierCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSupplierCode.DefaultText = ""
        Me.txtSupplierCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSupplierCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSupplierCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSupplierCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSupplierCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSupplierCode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtSupplierCode.ForeColor = System.Drawing.Color.Black
        Me.txtSupplierCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSupplierCode.Location = New System.Drawing.Point(928, 174)
        Me.txtSupplierCode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.PlaceholderText = ""
        Me.txtSupplierCode.SelectedText = ""
        Me.txtSupplierCode.Size = New System.Drawing.Size(414, 45)
        Me.txtSupplierCode.TabIndex = 5652
        Me.txtSupplierCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Location = New System.Drawing.Point(1342, 179)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(238, 45)
        Me.Label37.TabIndex = 5651
        Me.Label37.Text = "كود المورد"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplierName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSupplierName.DefaultText = ""
        Me.txtSupplierName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSupplierName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSupplierName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSupplierName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSupplierName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSupplierName.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtSupplierName.ForeColor = System.Drawing.Color.Black
        Me.txtSupplierName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSupplierName.Location = New System.Drawing.Point(928, 225)
        Me.txtSupplierName.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.PlaceholderText = ""
        Me.txtSupplierName.SelectedText = ""
        Me.txtSupplierName.Size = New System.Drawing.Size(414, 45)
        Me.txtSupplierName.TabIndex = 5650
        Me.txtSupplierName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Location = New System.Drawing.Point(1342, 230)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(238, 45)
        Me.Label38.TabIndex = 5649
        Me.Label38.Text = "اسم المورد"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvInvoiceDetailsPurchase
        '
        Me.dgvInvoiceDetailsPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInvoiceDetailsPurchase.ColumnHeadersHeight = 65
        Me.dgvInvoiceDetailsPurchase.Location = New System.Drawing.Point(8, 390)
        Me.dgvInvoiceDetailsPurchase.Name = "dgvInvoiceDetailsPurchase"
        Me.dgvInvoiceDetailsPurchase.RowTemplate.Height = 40
        Me.dgvInvoiceDetailsPurchase.Size = New System.Drawing.Size(1576, 364)
        Me.dgvInvoiceDetailsPurchase.TabIndex = 5648
        '
        'btn_sand_supplier
        '
        Me.btn_sand_supplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_sand_supplier.Location = New System.Drawing.Point(4, 128)
        Me.btn_sand_supplier.Name = "SimpleButton4"
        Me.btn_sand_supplier.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_sand_supplier.Size = New System.Drawing.Size(251, 71)
        Me.btn_sand_supplier.TabIndex = 5675
        Me.btn_sand_supplier.Text = "ارسال للمورد "
        '
        'btn_purchases_print
        '
        Me.btn_purchases_print.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_purchases_print.Location = New System.Drawing.Point(4, 255)
        Me.btn_purchases_print.Name = "SimpleButton5"
        Me.btn_purchases_print.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_purchases_print.Size = New System.Drawing.Size(251, 71)
        Me.btn_purchases_print.TabIndex = 5673
        Me.btn_purchases_print.Text = "طباعة"
        '
        'txtSalesSearch
        '
        Me.txtSalesSearch.Controls.Add(Me.dgv_balance_download)
        Me.txtSalesSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesSearch.Location = New System.Drawing.Point(4, 64)
        Me.txtSalesSearch.Name = "txtSalesSearch"
        Me.txtSalesSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.txtSalesSearch.Size = New System.Drawing.Size(1592, 762)
        Me.txtSalesSearch.TabIndex = 0
        Me.txtSalesSearch.Text = "تنزيل الرصيد"
        Me.txtSalesSearch.UseVisualStyleBackColor = True
        '
        'dgv_balance_download
        '
        Me.dgv_balance_download.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_balance_download.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_balance_download.Location = New System.Drawing.Point(3, 21)
        Me.dgv_balance_download.Name = "dgv_balance_download"
        Me.dgv_balance_download.RowTemplate.Height = 30
        Me.dgv_balance_download.Size = New System.Drawing.Size(1576, 733)
        Me.dgv_balance_download.TabIndex = 87
        '
        'TabReports
        '
        Me.TabReports.Controls.Add(Me.txtSalesSearch)
        Me.TabReports.Controls.Add(Me.TabSupplier)
        Me.TabReports.Controls.Add(Me.tabInvoiceDetails)
        Me.TabReports.Controls.Add(Me.TabStockMovement)
        Me.TabReports.Controls.Add(Me.TabPurchases)
        Me.TabReports.Controls.Add(Me.tpSales)
        Me.TabReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabReports.ItemSize = New System.Drawing.Size(255, 60)
        Me.TabReports.Location = New System.Drawing.Point(0, 70)
        Me.TabReports.Name = "TabReports"
        Me.TabReports.SelectedIndex = 0
        Me.TabReports.Size = New System.Drawing.Size(1600, 830)
        Me.TabReports.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty
        Me.TabReports.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TabReports.TabButtonHoverState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.TabReports.TabButtonHoverState.ForeColor = System.Drawing.Color.White
        Me.TabReports.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TabReports.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty
        Me.TabReports.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.TabReports.TabButtonIdleState.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabReports.TabButtonIdleState.ForeColor = System.Drawing.Color.White
        Me.TabReports.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.TabReports.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty
        Me.TabReports.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TabReports.TabButtonSelectedState.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabReports.TabButtonSelectedState.ForeColor = System.Drawing.Color.White
        Me.TabReports.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabReports.TabButtonSize = New System.Drawing.Size(255, 60)
        Me.TabReports.TabIndex = 82
        Me.TabReports.TabMenuBackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.TabReports.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop
        Me.TabReports.TabStop = False
        '
        'Timer1
        '
        '
        'Reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1600, 900)
        Me.Controls.Add(Me.TabReports)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Reports"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reports"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.tpSales.ResumeLayout(False)
        Me.tpSales.PerformLayout()
        CType(Me.dgvSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPurchases.ResumeLayout(False)
        CType(Me.dgvPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabStockMovement.ResumeLayout(False)
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInvoiceDetails.ResumeLayout(False)
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSupplier.ResumeLayout(False)
        CType(Me.dgvInvoiceDetailsPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.txtSalesSearch.ResumeLayout(False)
        CType(Me.dgv_balance_download, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabReports.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents lbl_user_name As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents lblHeader As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents SimpleButton1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents SimpleButton2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents SimpleButton3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tpSales As TabPage
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dgvSales As DataGridView
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents chkSalesDetails As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents chkSalesDate As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents dtSalesTo As DateTimePicker
    Friend WithEvents dtSalesFrom As DateTimePicker
    Friend WithEvents lblPay As Label
    Friend WithEvents cboSalesPay As ComboBox
    Friend WithEvents lblUser As Label
    Friend WithEvents cboSalesUser As ComboBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents cboSalesCustomer As ComboBox
    Friend WithEvents lblTo As Label
    Friend WithEvents lblFrom As Label
    Friend WithEvents TabPurchases As TabPage
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dgvPurchase As DataGridView
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents chkPurchaseDetails As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents chkPurchaseDate As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents dtPurchaseTo As DateTimePicker
    Friend WithEvents dtPurchaseFrom As DateTimePicker
    Friend WithEvents btnSearchPurchase As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPurchasePay As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPurchaseUser As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboPurchaseSupplier As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TabStockMovement As TabPage
    Friend WithEvents dgvStock As DataGridView
    Friend WithEvents tabInvoiceDetails As TabPage
    Friend WithEvents dgvInvoiceDetails As DataGridView
    Friend WithEvents TabSupplier As TabPage
    Friend WithEvents txtSalesSearch As TabPage
    Friend WithEvents dgv_balance_download As DataGridView
    Friend WithEvents TabReports As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents txtInvID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txt_Customer_Code As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCustomerName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents dtpInvDate As DateTimePicker
    Friend WithEvents txtNet As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblTotalAfter As Label
    Friend WithEvents txtPaid As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblPaid As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtRemaining As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblRemaining As Label
    Friend WithEvents txtDiscount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblDiscount As Label
    Friend WithEvents txtTotal As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblTotalBefore As Label
    Friend WithEvents txtUser As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txt_Payment_Method As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txt_Invoice_type As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtCopies As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnPrint As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSendInvoiceWhatsApp As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtCustomerPhone As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents btn_sand_supplier As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtCopies2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_purchases_print As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txt_Invoice_type2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txt_Payment_Method2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtUser2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtNet2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtPaid2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents txtRemaining2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtDiscount2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtTotal2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents dtpInvDate2 As DateTimePicker
    Friend WithEvents txtInvID2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtSupplierCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents txtSupplierName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents dgvInvoiceDetailsPurchase As DataGridView
    Friend WithEvents cboColumns As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txt_sum_col As TextBox
    Friend WithEvents btn_update As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txt_Total_Profit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents txt_Total_Profit_dgv As TextBox
    Public WithEvents btnSearchSales As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_inv_delete As Button
    Friend WithEvents btn_inv_purchases_del As Button
    Friend WithEvents txtSupplier_Num As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btn_edit_sale As Button
    Friend WithEvents btn_show_pirfit As Guna.UI2.WinForms.Guna2Button
End Class


' Reports.Designer.vb
