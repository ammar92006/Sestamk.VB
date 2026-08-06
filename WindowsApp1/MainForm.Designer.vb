<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.pn_natpar = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnTreasury = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Expenses = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Settings = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_backup = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Stock = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Reports = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Purchases = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Suppliers = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Sales = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Customer = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_ProductUnits = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Products = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_categories = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_Users = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pn_log_info = New System.Windows.Forms.Panel()
        Me.pic_user = New System.Windows.Forms.PictureBox()
        Me.lbl_RoleName = New System.Windows.Forms.Label()
        Me.lbl_log_name = New System.Windows.Forms.Label()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.pn_footer = New System.Windows.Forms.Panel()
        Me.btn_logout = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_dev_info = New DevExpress.XtraEditors.SimpleButton()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.LabelDeveloper = New System.Windows.Forms.Label()
        Me.pn_title = New System.Windows.Forms.Panel()
        Me.lblBadge = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.btnBell = New DevExpress.XtraEditors.SimpleButton()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.TimerClock = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.pnlNotifications = New System.Windows.Forms.Panel()
        Me.dgvLowStock = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlQuickActions = New System.Windows.Forms.Panel()
        Me.btn_Customer_Balance_Download = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_add_new_user = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_add_new_Categorie = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_add_new_supplier = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_add_new_customer = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_add_new_product = New Guna.UI2.WinForms.Guna2Button()
        Me.pn_natpar.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pn_log_info.SuspendLayout()
        CType(Me.pic_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pn_footer.SuspendLayout()
        Me.pn_title.SuspendLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.pnlNotifications.SuspendLayout()
        CType(Me.dgvLowStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.pnlQuickActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'pn_natpar
        '
        Me.pn_natpar.Controls.Add(Me.Panel3)
        Me.pn_natpar.Controls.Add(Me.Panel2)
        Me.pn_natpar.Controls.Add(Me.pn_log_info)
        Me.pn_natpar.Controls.Add(Me.Panel1)
        Me.pn_natpar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pn_natpar.Location = New System.Drawing.Point(0, 0)
        Me.pn_natpar.Name = "pn_natpar"
        Me.pn_natpar.Size = New System.Drawing.Size(360, 840)
        Me.pn_natpar.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnTreasury)
        Me.Panel3.Controls.Add(Me.btn_Expenses)
        Me.Panel3.Controls.Add(Me.btn_Settings)
        Me.Panel3.Controls.Add(Me.btn_backup)
        Me.Panel3.Controls.Add(Me.btn_Stock)
        Me.Panel3.Controls.Add(Me.btn_Reports)
        Me.Panel3.Controls.Add(Me.btn_Purchases)
        Me.Panel3.Controls.Add(Me.btn_Suppliers)
        Me.Panel3.Controls.Add(Me.btn_Sales)
        Me.Panel3.Controls.Add(Me.btn_Customer)
        Me.Panel3.Controls.Add(Me.btn_ProductUnits)
        Me.Panel3.Controls.Add(Me.btn_Products)
        Me.Panel3.Controls.Add(Me.btn_categories)
        Me.Panel3.Controls.Add(Me.btn_Users)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 389)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(360, 451)
        Me.Panel3.TabIndex = 4
        '
        'btnTreasury
        '
        Me.btnTreasury.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnTreasury.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTreasury.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTreasury.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTreasury.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnTreasury.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnTreasury.FillColor = System.Drawing.Color.Transparent
        Me.btnTreasury.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTreasury.ForeColor = System.Drawing.Color.White
        Me.btnTreasury.Image = Global.WindowsApp1.My.Resources.Resources.construction
        Me.btnTreasury.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnTreasury.ImageSize = New System.Drawing.Size(40, 40)
        Me.btnTreasury.Location = New System.Drawing.Point(0, 702)
        Me.btnTreasury.Name = "btnTreasury"
        Me.btnTreasury.Size = New System.Drawing.Size(343, 54)
        Me.btnTreasury.TabIndex = 14
        Me.btnTreasury.Text = "الخزن"
        '
        'btn_Expenses
        '
        Me.btn_Expenses.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Expenses.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Expenses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Expenses.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Expenses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Expenses.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Expenses.FillColor = System.Drawing.Color.Transparent
        Me.btn_Expenses.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Expenses.ForeColor = System.Drawing.Color.White
        Me.btn_Expenses.Image = Global.WindowsApp1.My.Resources.Resources.spending
        Me.btn_Expenses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Expenses.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Expenses.Location = New System.Drawing.Point(0, 648)
        Me.btn_Expenses.Name = "btn_Expenses"
        Me.btn_Expenses.Size = New System.Drawing.Size(343, 54)
        Me.btn_Expenses.TabIndex = 13
        Me.btn_Expenses.Text = "المصروفات"
        '
        'btn_Settings
        '
        Me.btn_Settings.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Settings.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Settings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Settings.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Settings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Settings.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Settings.FillColor = System.Drawing.Color.Transparent
        Me.btn_Settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Settings.ForeColor = System.Drawing.Color.White
        Me.btn_Settings.Image = Global.WindowsApp1.My.Resources.Resources.settings1
        Me.btn_Settings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Settings.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Settings.Location = New System.Drawing.Point(0, 594)
        Me.btn_Settings.Name = "btn_Settings"
        Me.btn_Settings.Size = New System.Drawing.Size(343, 54)
        Me.btn_Settings.TabIndex = 9
        Me.btn_Settings.Text = "الاعدادات"
        '
        'btn_backup
        '
        Me.btn_backup.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_backup.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_backup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_backup.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_backup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_backup.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_backup.FillColor = System.Drawing.Color.Transparent
        Me.btn_backup.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_backup.ForeColor = System.Drawing.Color.White
        Me.btn_backup.Image = Global.WindowsApp1.My.Resources.Resources.data_recovery1
        Me.btn_backup.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_backup.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_backup.Location = New System.Drawing.Point(0, 540)
        Me.btn_backup.Name = "btn_backup"
        Me.btn_backup.Size = New System.Drawing.Size(343, 54)
        Me.btn_backup.TabIndex = 8
        Me.btn_backup.Text = "النسخ الاحتياطي"
        '
        'btn_Stock
        '
        Me.btn_Stock.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Stock.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Stock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Stock.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Stock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Stock.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Stock.FillColor = System.Drawing.Color.Transparent
        Me.btn_Stock.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Stock.ForeColor = System.Drawing.Color.White
        Me.btn_Stock.Image = Global.WindowsApp1.My.Resources.Resources.inventory1
        Me.btn_Stock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Stock.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Stock.Location = New System.Drawing.Point(0, 486)
        Me.btn_Stock.Name = "btn_Stock"
        Me.btn_Stock.Size = New System.Drawing.Size(343, 54)
        Me.btn_Stock.TabIndex = 7
        Me.btn_Stock.Text = "المخزون"
        '
        'btn_Reports
        '
        Me.btn_Reports.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Reports.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Reports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Reports.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Reports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Reports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Reports.FillColor = System.Drawing.Color.Transparent
        Me.btn_Reports.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Reports.ForeColor = System.Drawing.Color.White
        Me.btn_Reports.Image = Global.WindowsApp1.My.Resources.Resources.financial_statement
        Me.btn_Reports.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Reports.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Reports.Location = New System.Drawing.Point(0, 432)
        Me.btn_Reports.Name = "btn_Reports"
        Me.btn_Reports.Size = New System.Drawing.Size(343, 54)
        Me.btn_Reports.TabIndex = 6
        Me.btn_Reports.Text = "التقارير"
        '
        'btn_Purchases
        '
        Me.btn_Purchases.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Purchases.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Purchases.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Purchases.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Purchases.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Purchases.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Purchases.FillColor = System.Drawing.Color.Transparent
        Me.btn_Purchases.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Purchases.ForeColor = System.Drawing.Color.White
        Me.btn_Purchases.Image = Global.WindowsApp1.My.Resources.Resources.shopping_cart1
        Me.btn_Purchases.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Purchases.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Purchases.Location = New System.Drawing.Point(0, 378)
        Me.btn_Purchases.Name = "btn_Purchases"
        Me.btn_Purchases.Size = New System.Drawing.Size(343, 54)
        Me.btn_Purchases.TabIndex = 11
        Me.btn_Purchases.Text = "المشتريات"
        '
        'btn_Suppliers
        '
        Me.btn_Suppliers.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Suppliers.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Suppliers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Suppliers.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Suppliers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Suppliers.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Suppliers.FillColor = System.Drawing.Color.Transparent
        Me.btn_Suppliers.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Suppliers.ForeColor = System.Drawing.Color.White
        Me.btn_Suppliers.Image = Global.WindowsApp1.My.Resources.Resources.supplier
        Me.btn_Suppliers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Suppliers.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Suppliers.Location = New System.Drawing.Point(0, 324)
        Me.btn_Suppliers.Name = "btn_Suppliers"
        Me.btn_Suppliers.Size = New System.Drawing.Size(343, 54)
        Me.btn_Suppliers.TabIndex = 5
        Me.btn_Suppliers.Text = "الموردين"
        '
        'btn_Sales
        '
        Me.btn_Sales.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Sales.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Sales.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Sales.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Sales.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Sales.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Sales.FillColor = System.Drawing.Color.Transparent
        Me.btn_Sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Sales.ForeColor = System.Drawing.Color.White
        Me.btn_Sales.Image = Global.WindowsApp1.My.Resources.Resources.sign
        Me.btn_Sales.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Sales.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Sales.Location = New System.Drawing.Point(0, 270)
        Me.btn_Sales.Name = "btn_Sales"
        Me.btn_Sales.Size = New System.Drawing.Size(343, 54)
        Me.btn_Sales.TabIndex = 12
        Me.btn_Sales.Text = "المبيعات"
        '
        'btn_Customer
        '
        Me.btn_Customer.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Customer.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Customer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Customer.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Customer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Customer.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Customer.FillColor = System.Drawing.Color.Transparent
        Me.btn_Customer.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Customer.ForeColor = System.Drawing.Color.White
        Me.btn_Customer.Image = Global.WindowsApp1.My.Resources.Resources.patient
        Me.btn_Customer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Customer.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Customer.Location = New System.Drawing.Point(0, 216)
        Me.btn_Customer.Name = "btn_Customer"
        Me.btn_Customer.Size = New System.Drawing.Size(343, 54)
        Me.btn_Customer.TabIndex = 4
        Me.btn_Customer.Text = "العملاء"
        '
        'btn_ProductUnits
        '
        Me.btn_ProductUnits.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_ProductUnits.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_ProductUnits.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_ProductUnits.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_ProductUnits.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_ProductUnits.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_ProductUnits.FillColor = System.Drawing.Color.Transparent
        Me.btn_ProductUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ProductUnits.ForeColor = System.Drawing.Color.White
        Me.btn_ProductUnits.Image = Global.WindowsApp1.My.Resources.Resources.unit__1_
        Me.btn_ProductUnits.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_ProductUnits.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_ProductUnits.Location = New System.Drawing.Point(0, 162)
        Me.btn_ProductUnits.Name = "btn_ProductUnits"
        Me.btn_ProductUnits.Size = New System.Drawing.Size(343, 54)
        Me.btn_ProductUnits.TabIndex = 3
        Me.btn_ProductUnits.Text = " الوحدات والاسعار"
        '
        'btn_Products
        '
        Me.btn_Products.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Products.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Products.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Products.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Products.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Products.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Products.FillColor = System.Drawing.Color.Transparent
        Me.btn_Products.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Products.ForeColor = System.Drawing.Color.White
        Me.btn_Products.Image = Global.WindowsApp1.My.Resources.Resources.products
        Me.btn_Products.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Products.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Products.Location = New System.Drawing.Point(0, 108)
        Me.btn_Products.Name = "btn_Products"
        Me.btn_Products.Size = New System.Drawing.Size(343, 54)
        Me.btn_Products.TabIndex = 2
        Me.btn_Products.Text = "المنتجات"
        '
        'btn_categories
        '
        Me.btn_categories.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_categories.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_categories.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_categories.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_categories.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_categories.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_categories.FillColor = System.Drawing.Color.Transparent
        Me.btn_categories.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_categories.ForeColor = System.Drawing.Color.White
        Me.btn_categories.Image = Global.WindowsApp1.My.Resources.Resources.pie_graph
        Me.btn_categories.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_categories.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_categories.Location = New System.Drawing.Point(0, 54)
        Me.btn_categories.Name = "btn_categories"
        Me.btn_categories.Size = New System.Drawing.Size(343, 54)
        Me.btn_categories.TabIndex = 1
        Me.btn_categories.Text = "الاقسام"
        '
        'btn_Users
        '
        Me.btn_Users.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Users.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Users.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Users.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Users.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Users.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Users.FillColor = System.Drawing.Color.Transparent
        Me.btn_Users.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Users.ForeColor = System.Drawing.Color.White
        Me.btn_Users.Image = Global.WindowsApp1.My.Resources.Resources.private_account
        Me.btn_Users.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_Users.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Users.Location = New System.Drawing.Point(0, 0)
        Me.btn_Users.Name = "btn_Users"
        Me.btn_Users.Size = New System.Drawing.Size(343, 54)
        Me.btn_Users.TabIndex = 10
        Me.btn_Users.Text = "المستخدمين"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 375)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(360, 14)
        Me.Panel2.TabIndex = 2
        '
        'pn_log_info
        '
        Me.pn_log_info.Controls.Add(Me.pic_user)
        Me.pn_log_info.Controls.Add(Me.lbl_RoleName)
        Me.pn_log_info.Controls.Add(Me.lbl_log_name)
        Me.pn_log_info.Controls.Add(Me.SimpleButton2)
        Me.pn_log_info.Dock = System.Windows.Forms.DockStyle.Top
        Me.pn_log_info.Location = New System.Drawing.Point(0, 75)
        Me.pn_log_info.Name = "pn_log_info"
        Me.pn_log_info.Size = New System.Drawing.Size(360, 300)
        Me.pn_log_info.TabIndex = 0
        '
        'pic_user
        '
        Me.pic_user.Image = Global.WindowsApp1.My.Resources.Resources._518348218_1434214821335102_4304040704815404944_n__1_1
        Me.pic_user.Location = New System.Drawing.Point(25, 11)
        Me.pic_user.Name = "pic_user"
        Me.pic_user.Size = New System.Drawing.Size(280, 200)
        Me.pic_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_user.TabIndex = 15
        Me.pic_user.TabStop = False
        '
        'lbl_RoleName
        '
        Me.lbl_RoleName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_RoleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RoleName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(164, Byte), Integer))
        Me.lbl_RoleName.Location = New System.Drawing.Point(53, 258)
        Me.lbl_RoleName.Name = "lbl_RoleName"
        Me.lbl_RoleName.Size = New System.Drawing.Size(221, 35)
        Me.lbl_RoleName.TabIndex = 14
        Me.lbl_RoleName.Text = "admin"
        Me.lbl_RoleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_log_name
        '
        Me.lbl_log_name.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_log_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_log_name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lbl_log_name.Location = New System.Drawing.Point(53, 215)
        Me.lbl_log_name.Name = "lbl_log_name"
        Me.lbl_log_name.Size = New System.Drawing.Size(221, 35)
        Me.lbl_log_name.TabIndex = 13
        Me.lbl_log_name.Text = "Ammar Ahmed"
        Me.lbl_log_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.AutoSize = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(310, 6)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.SimpleButton2.Size = New System.Drawing.Size(38, 36)
        Me.SimpleButton2.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.lblTime)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(360, 75)
        Me.Panel1.TabIndex = 1
        '
        'lblDate
        '
        Me.lblDate.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblDate.Location = New System.Drawing.Point(0, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDate.Size = New System.Drawing.Size(360, 40)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "Time Now"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime
        '
        Me.lblTime.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblTime.Location = New System.Drawing.Point(0, 40)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTime.Size = New System.Drawing.Size(360, 35)
        Me.lblTime.TabIndex = 4
        Me.lblTime.Text = "Time Now"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pn_footer
        '
        Me.pn_footer.Controls.Add(Me.btn_logout)
        Me.pn_footer.Controls.Add(Me.btn_dev_info)
        Me.pn_footer.Controls.Add(Me.lblVersion)
        Me.pn_footer.Controls.Add(Me.LabelDeveloper)
        Me.pn_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pn_footer.Location = New System.Drawing.Point(0, 840)
        Me.pn_footer.Name = "pn_footer"
        Me.pn_footer.Size = New System.Drawing.Size(1600, 60)
        Me.pn_footer.TabIndex = 2
        '
        'btn_logout
        '
        Me.btn_logout.BackColor = System.Drawing.Color.Transparent
        Me.btn_logout.BorderRadius = 10
        Me.btn_logout.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_logout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_logout.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_logout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_logout.FillColor = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.btn_logout.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_logout.ForeColor = System.Drawing.Color.White
        Me.btn_logout.Image = Global.WindowsApp1.My.Resources.Resources.logout
        Me.btn_logout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btn_logout.ImageSize = New System.Drawing.Size(30, 30)
        Me.btn_logout.Location = New System.Drawing.Point(1324, 12)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(221, 42)
        Me.btn_logout.TabIndex = 12
        Me.btn_logout.Text = "تسجيل خروج"
        Me.btn_logout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btn_dev_info
        '
        Me.btn_dev_info.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_dev_info.Appearance.Options.UseFont = True
        Me.btn_dev_info.AutoSize = True
        Me.btn_dev_info.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.info__1_
        Me.btn_dev_info.ImageOptions.SvgImageSize = New System.Drawing.Size(60, 60)
        Me.btn_dev_info.Location = New System.Drawing.Point(1874, 12)
        Me.btn_dev_info.Name = "btn_dev_info"
        Me.btn_dev_info.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_dev_info.Size = New System.Drawing.Size(38, 36)
        Me.btn_dev_info.TabIndex = 3
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.lblVersion.Location = New System.Drawing.Point(26, 8)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(196, 39)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "الإصدار الثاني"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelDeveloper
        '
        Me.LabelDeveloper.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelDeveloper.AutoSize = True
        Me.LabelDeveloper.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.LabelDeveloper.Location = New System.Drawing.Point(501, 12)
        Me.LabelDeveloper.Name = "LabelDeveloper"
        Me.LabelDeveloper.Size = New System.Drawing.Size(529, 39)
        Me.LabelDeveloper.TabIndex = 0
        Me.LabelDeveloper.Text = "تم تصميم هذا البرنامج بواسطة عمار احمد"
        Me.LabelDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pn_title
        '
        Me.pn_title.Controls.Add(Me.lblBadge)
        Me.pn_title.Controls.Add(Me.btnBell)
        Me.pn_title.Controls.Add(Me.pn_title_page)
        Me.pn_title.Controls.Add(Me.btn_min)
        Me.pn_title.Controls.Add(Me.btn_max)
        Me.pn_title.Controls.Add(Me.btn_close)
        Me.pn_title.Dock = System.Windows.Forms.DockStyle.Top
        Me.pn_title.Location = New System.Drawing.Point(360, 0)
        Me.pn_title.Name = "pn_title"
        Me.pn_title.Size = New System.Drawing.Size(1240, 75)
        Me.pn_title.TabIndex = 3
        '
        'lblBadge
        '
        Me.lblBadge.AutoSize = False
        Me.lblBadge.BackColor = System.Drawing.Color.Transparent
        Me.lblBadge.Location = New System.Drawing.Point(163, 15)
        Me.lblBadge.Name = "lblBadge"
        Me.lblBadge.Size = New System.Drawing.Size(22, 22)
        Me.lblBadge.TabIndex = 5
        Me.lblBadge.Text = "5"
        '
        'btnBell
        '
        Me.btnBell.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBell.Appearance.Options.UseFont = True
        Me.btnBell.AutoSize = True
        Me.btnBell.ImageOptions.SvgImage = CType(resources.GetObject("btnBell.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnBell.Location = New System.Drawing.Point(147, 15)
        Me.btnBell.Name = "btnBell"
        Me.btnBell.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnBell.Size = New System.Drawing.Size(38, 36)
        Me.btnBell.TabIndex = 4
        '
        'pn_title_page
        '
        Me.pn_title_page.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pn_title_page.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pn_title_page.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.pn_title_page.Location = New System.Drawing.Point(325, 11)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(899, 46)
        Me.pn_title_page.TabIndex = 3
        Me.pn_title_page.Text = "الحمد والرضا | Super Market Management System"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_min
        '
        Me.btn_min.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_min.Appearance.Options.UseFont = True
        Me.btn_min.AutoSize = True
        Me.btn_min.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_min.Location = New System.Drawing.Point(96, 15)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_min.Size = New System.Drawing.Size(38, 36)
        Me.btn_min.TabIndex = 2
        '
        'btn_max
        '
        Me.btn_max.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_max.Appearance.Options.UseFont = True
        Me.btn_max.AutoSize = True
        Me.btn_max.ImageOptions.SvgImage = CType(resources.GetObject("btn_max.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_max.Location = New System.Drawing.Point(52, 15)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_max.Size = New System.Drawing.Size(38, 36)
        Me.btn_max.TabIndex = 1
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(8, 15)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 0
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.White
        Me.PanelMain.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.Gemini_Generated_Image_n1mvatn1mvatn1mv
        Me.PanelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelMain.Controls.Add(Me.pnlNotifications)
        Me.PanelMain.Controls.Add(Me.pnlQuickActions)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(360, 75)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(3)
        Me.PanelMain.Size = New System.Drawing.Size(1240, 765)
        Me.PanelMain.TabIndex = 4
        '
        'pnlNotifications
        '
        Me.pnlNotifications.AutoScroll = True
        Me.pnlNotifications.BackColor = System.Drawing.Color.White
        Me.pnlNotifications.Controls.Add(Me.dgvLowStock)
        Me.pnlNotifications.Controls.Add(Me.Panel4)
        Me.pnlNotifications.Location = New System.Drawing.Point(0, 0)
        Me.pnlNotifications.Name = "pnlNotifications"
        Me.pnlNotifications.Size = New System.Drawing.Size(400, 450)
        Me.pnlNotifications.TabIndex = 6
        Me.pnlNotifications.Visible = False
        '
        'dgvLowStock
        '
        Me.dgvLowStock.AllowUserToAddRows = False
        Me.dgvLowStock.AllowUserToDeleteRows = False
        Me.dgvLowStock.AllowUserToResizeColumns = False
        Me.dgvLowStock.AllowUserToResizeRows = False
        Me.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLowStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLowStock.Location = New System.Drawing.Point(0, 41)
        Me.dgvLowStock.Name = "dgvLowStock"
        Me.dgvLowStock.ReadOnly = True
        Me.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLowStock.Size = New System.Drawing.Size(400, 409)
        Me.dgvLowStock.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(400, 41)
        Me.Panel4.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Window
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Image = Global.WindowsApp1.My.Resources.Resources.update
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(400, 41)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "تحديث"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pnlQuickActions
        '
        Me.pnlQuickActions.BackColor = System.Drawing.Color.Transparent
        Me.pnlQuickActions.Controls.Add(Me.btn_Customer_Balance_Download)
        Me.pnlQuickActions.Controls.Add(Me.btn_add_new_user)
        Me.pnlQuickActions.Controls.Add(Me.btn_add_new_Categorie)
        Me.pnlQuickActions.Controls.Add(Me.btn_add_new_supplier)
        Me.pnlQuickActions.Controls.Add(Me.btn_add_new_customer)
        Me.pnlQuickActions.Controls.Add(Me.btn_add_new_product)
        Me.pnlQuickActions.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlQuickActions.Location = New System.Drawing.Point(3, 3)
        Me.pnlQuickActions.Name = "pnlQuickActions"
        Me.pnlQuickActions.Size = New System.Drawing.Size(1232, 161)
        Me.pnlQuickActions.TabIndex = 3
        '
        'btn_Customer_Balance_Download
        '
        Me.btn_Customer_Balance_Download.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_Customer_Balance_Download.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_Customer_Balance_Download.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_Customer_Balance_Download.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_Customer_Balance_Download.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_Customer_Balance_Download.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Customer_Balance_Download.ForeColor = System.Drawing.Color.White
        Me.btn_Customer_Balance_Download.Image = Global.WindowsApp1.My.Resources.Resources._1486564407_plus_green_81521
        Me.btn_Customer_Balance_Download.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_Customer_Balance_Download.Location = New System.Drawing.Point(931, 80)
        Me.btn_Customer_Balance_Download.Name = "btn_Customer_Balance_Download"
        Me.btn_Customer_Balance_Download.Size = New System.Drawing.Size(298, 55)
        Me.btn_Customer_Balance_Download.TabIndex = 5
        Me.btn_Customer_Balance_Download.Text = "تنزيل رصيد عميل"
        '
        'btn_add_new_user
        '
        Me.btn_add_new_user.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_user.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_user.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_add_new_user.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_add_new_user.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_add_new_user.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_new_user.ForeColor = System.Drawing.Color.White
        Me.btn_add_new_user.Image = Global.WindowsApp1.My.Resources.Resources._1486564407_plus_green_81521
        Me.btn_add_new_user.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_add_new_user.Location = New System.Drawing.Point(497, 3)
        Me.btn_add_new_user.Name = "btn_add_new_user"
        Me.btn_add_new_user.Size = New System.Drawing.Size(262, 55)
        Me.btn_add_new_user.TabIndex = 4
        Me.btn_add_new_user.Text = "إضافة مستخدم جديد"
        '
        'btn_add_new_Categorie
        '
        Me.btn_add_new_Categorie.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_Categorie.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_Categorie.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_add_new_Categorie.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_add_new_Categorie.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_add_new_Categorie.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_new_Categorie.ForeColor = System.Drawing.Color.White
        Me.btn_add_new_Categorie.Image = Global.WindowsApp1.My.Resources.Resources._1486564407_plus_green_81521
        Me.btn_add_new_Categorie.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_add_new_Categorie.Location = New System.Drawing.Point(1011, 3)
        Me.btn_add_new_Categorie.Name = "btn_add_new_Categorie"
        Me.btn_add_new_Categorie.Size = New System.Drawing.Size(234, 55)
        Me.btn_add_new_Categorie.TabIndex = 3
        Me.btn_add_new_Categorie.Text = "إضافة قسم جديد"
        '
        'btn_add_new_supplier
        '
        Me.btn_add_new_supplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_supplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_supplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_add_new_supplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_add_new_supplier.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_add_new_supplier.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_new_supplier.ForeColor = System.Drawing.Color.White
        Me.btn_add_new_supplier.Image = Global.WindowsApp1.My.Resources.Resources._1486564407_plus_green_81521
        Me.btn_add_new_supplier.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_add_new_supplier.Location = New System.Drawing.Point(11, 3)
        Me.btn_add_new_supplier.Name = "btn_add_new_supplier"
        Me.btn_add_new_supplier.Size = New System.Drawing.Size(234, 55)
        Me.btn_add_new_supplier.TabIndex = 2
        Me.btn_add_new_supplier.Text = "اضافة مورد جديد"
        '
        'btn_add_new_customer
        '
        Me.btn_add_new_customer.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_customer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_customer.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_add_new_customer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_add_new_customer.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_add_new_customer.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_new_customer.ForeColor = System.Drawing.Color.White
        Me.btn_add_new_customer.Image = Global.WindowsApp1.My.Resources.Resources._1486564407_plus_green_81521
        Me.btn_add_new_customer.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_add_new_customer.Location = New System.Drawing.Point(254, 3)
        Me.btn_add_new_customer.Name = "btn_add_new_customer"
        Me.btn_add_new_customer.Size = New System.Drawing.Size(234, 55)
        Me.btn_add_new_customer.TabIndex = 1
        Me.btn_add_new_customer.Text = "اضافة عميل جديد"
        '
        'btn_add_new_product
        '
        Me.btn_add_new_product.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_product.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_new_product.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_add_new_product.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_add_new_product.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btn_add_new_product.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_new_product.ForeColor = System.Drawing.Color.White
        Me.btn_add_new_product.Image = Global.WindowsApp1.My.Resources.Resources._1486564407_plus_green_81521
        Me.btn_add_new_product.ImageSize = New System.Drawing.Size(40, 40)
        Me.btn_add_new_product.Location = New System.Drawing.Point(768, 2)
        Me.btn_add_new_product.Name = "btn_add_new_product"
        Me.btn_add_new_product.Size = New System.Drawing.Size(234, 55)
        Me.btn_add_new_product.TabIndex = 0
        Me.btn_add_new_product.Text = "اضافة منتج جديد"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1600, 900)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.pn_title)
        Me.Controls.Add(Me.pn_natpar)
        Me.Controls.Add(Me.pn_footer)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "MainForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الشاشة الرئيسية"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pn_natpar.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pn_log_info.ResumeLayout(False)
        Me.pn_log_info.PerformLayout()
        CType(Me.pic_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pn_footer.ResumeLayout(False)
        Me.pn_footer.PerformLayout()
        Me.pn_title.ResumeLayout(False)
        Me.pn_title.PerformLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.pnlNotifications.ResumeLayout(False)
        CType(Me.dgvLowStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.pnlQuickActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pn_natpar As Panel
    Friend WithEvents pn_footer As Panel
    Friend WithEvents pn_title As Panel
    Friend WithEvents PanelMain As Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelDeveloper As Label
    Friend WithEvents pn_title_page As Label
    Friend WithEvents pn_log_info As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn_Reports As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Suppliers As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Customer As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_ProductUnits As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Products As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_categories As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Stock As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_backup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Settings As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Users As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Purchases As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_Sales As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblVersion As Label
    Friend WithEvents btnBell As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents lblTime As Label
    Friend WithEvents TimerClock As Timer
    Friend WithEvents lblDate As Label
    Friend WithEvents btn_dev_info As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlQuickActions As Panel
    Friend WithEvents btn_add_new_user As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_add_new_Categorie As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_add_new_supplier As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_add_new_customer As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_add_new_product As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pic_user As PictureBox
    Friend WithEvents lbl_RoleName As Label
    Friend WithEvents lbl_log_name As Label
    Friend WithEvents btn_logout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblBadge As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents pnlNotifications As Panel
    Friend WithEvents dgvLowStock As DataGridView
    Friend WithEvents btn_Customer_Balance_Download As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents btn_Expenses As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTreasury As Guna.UI2.WinForms.Guna2Button
End Class
