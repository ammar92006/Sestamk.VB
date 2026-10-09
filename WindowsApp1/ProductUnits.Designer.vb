<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductUnits
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
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_max = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btn_close = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_update = New Guna.UI2.WinForms.Guna2Button()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.txt_ProductCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_generate_barcode = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_scan_bar = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2DateTimePicker1 = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.btnSearchByID = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSearchByName = New Guna.UI2.WinForms.Guna2Button()
        Me.txt_Barcode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Notes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Sale_Price = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Purchase_Price = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Product_Name = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Unit_Quantity = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Unit_Name = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Product_ID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProductUnit_ID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.txt_PrintCount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_clear = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_print = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_delete = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_edit = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_add = New Guna.UI2.WinForms.Guna2Button()
        Me.dgv_ProductUnits = New System.Windows.Forms.DataGridView()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        Me.Guna2GroupBox1.SuspendLayout()
        Me.Guna2Panel3.SuspendLayout()
        CType(Me.dgv_ProductUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.btn_min)
        Me.Guna2Panel1.Controls.Add(Me.btn_max)
        Me.Guna2Panel1.Controls.Add(Me.btn_Close)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1500, 65)
        Me.Guna2Panel1.TabIndex = 0
        '
        'btn_min
        '
        Me.btn_min.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btn_min.FillColor = System.Drawing.Color.Transparent
        Me.btn_min.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_min.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_min.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_min.Location = New System.Drawing.Point(152, 9)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.Size = New System.Drawing.Size(64, 45)
        Me.btn_min.TabIndex = 3
        '
        'btn_max
        '
        Me.btn_max.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox
        Me.btn_max.FillColor = System.Drawing.Color.Transparent
        Me.btn_max.HoverState.FillColor = System.Drawing.Color.FromArgb(55, 65, 81)
        Me.btn_max.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_max.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_max.Location = New System.Drawing.Point(82, 9)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.Size = New System.Drawing.Size(64, 45)
        Me.btn_max.TabIndex = 2
        '
        'btn_Close
        '
        Me.btn_Close.FillColor = System.Drawing.Color.Transparent
        Me.btn_Close.HoverState.FillColor = System.Drawing.Color.FromArgb(239, 68, 68)
        Me.btn_Close.HoverState.IconColor = System.Drawing.Color.White
        Me.btn_Close.IconColor = System.Drawing.Color.FromArgb(156, 163, 175)
        Me.btn_Close.Location = New System.Drawing.Point(12, 9)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(64, 45)
        Me.btn_Close.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(578, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 43)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "الوحدات والاسعار"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.BackColor = System.Drawing.Color.White
        Me.Guna2Panel2.Controls.Add(Me.btn_update)
        Me.Guna2Panel2.Controls.Add(Me.cmbSearchField)
        Me.Guna2Panel2.Controls.Add(Me.txtSearch)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 65)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1500, 59)
        Me.Guna2Panel2.TabIndex = 1
        '
        'btn_update
        '
        Me.btn_update.BorderRadius = 10
        Me.btn_update.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_update.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_update.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_update.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_update.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.btn_update.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_update.ForeColor = System.Drawing.Color.White
        Me.btn_update.Image = Global.WindowsApp1.My.Resources.Resources.search2
        Me.btn_update.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn_update.Location = New System.Drawing.Point(247, 7)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(180, 45)
        Me.btn_update.TabIndex = 4
        Me.btn_update.Text = "تحديث"
        '
        'cmbSearchField
        '
        Me.cmbSearchField.BackColor = System.Drawing.Color.Transparent
        Me.cmbSearchField.BorderRadius = 5
        Me.cmbSearchField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchField.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSearchField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSearchField.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchField.ForeColor = System.Drawing.Color.Black
        Me.cmbSearchField.ItemHeight = 38
        Me.cmbSearchField.Location = New System.Drawing.Point(1073, 7)
        Me.cmbSearchField.Name = "cmbSearchField"
        Me.cmbSearchField.Size = New System.Drawing.Size(260, 44)
        Me.cmbSearchField.TabIndex = 1
        Me.cmbSearchField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSearch
        '
        Me.txtSearch.BorderRadius = 5
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(436, 7)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = ""
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(631, 44)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.Controls.Add(Me.txt_ProductCode)
        Me.Guna2GroupBox1.Controls.Add(Me.Label11)
        Me.Guna2GroupBox1.Controls.Add(Me.btn_generate_barcode)
        Me.Guna2GroupBox1.Controls.Add(Me.btn_scan_bar)
        Me.Guna2GroupBox1.Controls.Add(Me.Guna2DateTimePicker1)
        Me.Guna2GroupBox1.Controls.Add(Me.btnSearchByID)
        Me.Guna2GroupBox1.Controls.Add(Me.btnSearchByName)
        Me.Guna2GroupBox1.Controls.Add(Me.txt_Barcode)
        Me.Guna2GroupBox1.Controls.Add(Me.Label10)
        Me.Guna2GroupBox1.Controls.Add(Me.Notes)
        Me.Guna2GroupBox1.Controls.Add(Me.Label9)
        Me.Guna2GroupBox1.Controls.Add(Me.Sale_Price)
        Me.Guna2GroupBox1.Controls.Add(Me.Label6)
        Me.Guna2GroupBox1.Controls.Add(Me.Purchase_Price)
        Me.Guna2GroupBox1.Controls.Add(Me.Label7)
        Me.Guna2GroupBox1.Controls.Add(Me.txt_Product_Name)
        Me.Guna2GroupBox1.Controls.Add(Me.Label8)
        Me.Guna2GroupBox1.Controls.Add(Me.Unit_Quantity)
        Me.Guna2GroupBox1.Controls.Add(Me.Label5)
        Me.Guna2GroupBox1.Controls.Add(Me.Unit_Name)
        Me.Guna2GroupBox1.Controls.Add(Me.Label4)
        Me.Guna2GroupBox1.Controls.Add(Me.Product_ID)
        Me.Guna2GroupBox1.Controls.Add(Me.Label3)
        Me.Guna2GroupBox1.Controls.Add(Me.ProductUnit_ID)
        Me.Guna2GroupBox1.Controls.Add(Me.Label2)
        Me.Guna2GroupBox1.Controls.Add(Me.lstSuggestions)
        Me.Guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(0, 124)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(1500, 379)
        Me.Guna2GroupBox1.TabIndex = 2
        Me.Guna2GroupBox1.Text = "البيانات"
        Me.Guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ProductCode
        '
        Me.txt_ProductCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_ProductCode.BorderRadius = 5
        Me.txt_ProductCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_ProductCode.DefaultText = ""
        Me.txt_ProductCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_ProductCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_ProductCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_ProductCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_ProductCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_ProductCode.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ProductCode.ForeColor = System.Drawing.Color.Black
        Me.txt_ProductCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_ProductCode.Location = New System.Drawing.Point(1108, 107)
        Me.txt_ProductCode.Margin = New System.Windows.Forms.Padding(5)
        Me.txt_ProductCode.Name = "txt_ProductCode"
        Me.txt_ProductCode.PlaceholderText = ""
        Me.txt_ProductCode.SelectedText = ""
        Me.txt_ProductCode.Size = New System.Drawing.Size(225, 40)
        Me.txt_ProductCode.TabIndex = 25
        Me.txt_ProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(421, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(174, 40)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "تاريخ الصلاحية"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_generate_barcode
        '
        Me.btn_generate_barcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_generate_barcode.BorderRadius = 10
        Me.btn_generate_barcode.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_generate_barcode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_generate_barcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_generate_barcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_generate_barcode.FillColor = System.Drawing.Color.DarkGray
        Me.btn_generate_barcode.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generate_barcode.ForeColor = System.Drawing.Color.White
        Me.btn_generate_barcode.Image = Global.WindowsApp1.My.Resources.Resources.add
        Me.btn_generate_barcode.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn_generate_barcode.Location = New System.Drawing.Point(4, 55)
        Me.btn_generate_barcode.Name = "btn_generate_barcode"
        Me.btn_generate_barcode.Size = New System.Drawing.Size(53, 40)
        Me.btn_generate_barcode.TabIndex = 23
        '
        'btn_scan_bar
        '
        Me.btn_scan_bar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_scan_bar.BorderRadius = 10
        Me.btn_scan_bar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_scan_bar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_scan_bar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_scan_bar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_scan_bar.FillColor = System.Drawing.Color.DarkGray
        Me.btn_scan_bar.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_scan_bar.ForeColor = System.Drawing.Color.White
        Me.btn_scan_bar.Image = Global.WindowsApp1.My.Resources.Resources.scan
        Me.btn_scan_bar.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn_scan_bar.Location = New System.Drawing.Point(60, 55)
        Me.btn_scan_bar.Name = "btn_scan_bar"
        Me.btn_scan_bar.Size = New System.Drawing.Size(53, 40)
        Me.btn_scan_bar.TabIndex = 22
        '
        'Guna2DateTimePicker1
        '
        Me.Guna2DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2DateTimePicker1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2DateTimePicker1.BorderRadius = 5
        Me.Guna2DateTimePicker1.Checked = True
        Me.Guna2DateTimePicker1.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Guna2DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Guna2DateTimePicker1.Location = New System.Drawing.Point(118, 119)
        Me.Guna2DateTimePicker1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.Guna2DateTimePicker1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.Guna2DateTimePicker1.Name = "Guna2DateTimePicker1"
        Me.Guna2DateTimePicker1.Size = New System.Drawing.Size(295, 40)
        Me.Guna2DateTimePicker1.TabIndex = 21
        Me.Guna2DateTimePicker1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Guna2DateTimePicker1.Value = New Date(2026, 3, 31, 4, 37, 2, 227)
        '
        'btnSearchByID
        '
        Me.btnSearchByID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchByID.BorderRadius = 10
        Me.btnSearchByID.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchByID.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchByID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearchByID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearchByID.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.btnSearchByID.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchByID.ForeColor = System.Drawing.Color.White
        Me.btnSearchByID.Image = Global.WindowsApp1.My.Resources.Resources.search2
        Me.btnSearchByID.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnSearchByID.Location = New System.Drawing.Point(1051, 107)
        Me.btnSearchByID.Name = "btnSearchByID"
        Me.btnSearchByID.Size = New System.Drawing.Size(53, 40)
        Me.btnSearchByID.TabIndex = 19
        '
        'btnSearchByName
        '
        Me.btnSearchByName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchByName.BorderRadius = 10
        Me.btnSearchByName.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchByName.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchByName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearchByName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearchByName.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.btnSearchByName.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchByName.ForeColor = System.Drawing.Color.White
        Me.btnSearchByName.Image = Global.WindowsApp1.My.Resources.Resources.search2
        Me.btnSearchByName.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnSearchByName.Location = New System.Drawing.Point(546, 55)
        Me.btnSearchByName.Name = "btnSearchByName"
        Me.btnSearchByName.Size = New System.Drawing.Size(53, 40)
        Me.btnSearchByName.TabIndex = 18
        '
        'txt_Barcode
        '
        Me.txt_Barcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Barcode.BorderRadius = 5
        Me.txt_Barcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Barcode.DefaultText = ""
        Me.txt_Barcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Barcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Barcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Barcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Barcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Barcode.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Barcode.ForeColor = System.Drawing.Color.Black
        Me.txt_Barcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Barcode.Location = New System.Drawing.Point(118, 55)
        Me.txt_Barcode.Margin = New System.Windows.Forms.Padding(5)
        Me.txt_Barcode.Name = "txt_Barcode"
        Me.txt_Barcode.PlaceholderText = ""
        Me.txt_Barcode.SelectedText = ""
        Me.txt_Barcode.Size = New System.Drawing.Size(295, 40)
        Me.txt_Barcode.TabIndex = 17
        Me.txt_Barcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(421, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 40)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "الباركود"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Notes
        '
        Me.Notes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Notes.BorderRadius = 5
        Me.Notes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Notes.DefaultText = ""
        Me.Notes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Notes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Notes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Notes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Notes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Notes.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes.ForeColor = System.Drawing.Color.Black
        Me.Notes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Notes.Location = New System.Drawing.Point(603, 215)
        Me.Notes.Margin = New System.Windows.Forms.Padding(5)
        Me.Notes.Multiline = True
        Me.Notes.Name = "Notes"
        Me.Notes.PlaceholderText = ""
        Me.Notes.SelectedText = ""
        Me.Notes.Size = New System.Drawing.Size(282, 127)
        Me.Notes.TabIndex = 15
        Me.Notes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(893, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 40)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "الملاحظات"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Sale_Price
        '
        Me.Sale_Price.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sale_Price.BorderRadius = 5
        Me.Sale_Price.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Sale_Price.DefaultText = ""
        Me.Sale_Price.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Sale_Price.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Sale_Price.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Sale_Price.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Sale_Price.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Sale_Price.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sale_Price.ForeColor = System.Drawing.Color.Black
        Me.Sale_Price.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Sale_Price.Location = New System.Drawing.Point(603, 159)
        Me.Sale_Price.Margin = New System.Windows.Forms.Padding(5)
        Me.Sale_Price.Name = "Sale_Price"
        Me.Sale_Price.PlaceholderText = ""
        Me.Sale_Price.SelectedText = ""
        Me.Sale_Price.Size = New System.Drawing.Size(282, 40)
        Me.Sale_Price.TabIndex = 13
        Me.Sale_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(893, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 40)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "سعر البيع"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Purchase_Price
        '
        Me.Purchase_Price.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Purchase_Price.BorderRadius = 5
        Me.Purchase_Price.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Purchase_Price.DefaultText = ""
        Me.Purchase_Price.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Purchase_Price.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Purchase_Price.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Purchase_Price.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Purchase_Price.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Purchase_Price.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Purchase_Price.ForeColor = System.Drawing.Color.Black
        Me.Purchase_Price.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Purchase_Price.Location = New System.Drawing.Point(603, 107)
        Me.Purchase_Price.Margin = New System.Windows.Forms.Padding(5)
        Me.Purchase_Price.Name = "Purchase_Price"
        Me.Purchase_Price.PlaceholderText = ""
        Me.Purchase_Price.SelectedText = ""
        Me.Purchase_Price.Size = New System.Drawing.Size(282, 40)
        Me.Purchase_Price.TabIndex = 11
        Me.Purchase_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(893, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(150, 40)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "سعر الشراء"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_Product_Name
        '
        Me.txt_Product_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Product_Name.BorderRadius = 5
        Me.txt_Product_Name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Product_Name.DefaultText = ""
        Me.txt_Product_Name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Product_Name.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Product_Name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Product_Name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Product_Name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Product_Name.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Product_Name.ForeColor = System.Drawing.Color.Black
        Me.txt_Product_Name.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Product_Name.Location = New System.Drawing.Point(603, 55)
        Me.txt_Product_Name.Margin = New System.Windows.Forms.Padding(5)
        Me.txt_Product_Name.Name = "txt_Product_Name"
        Me.txt_Product_Name.PlaceholderText = ""
        Me.txt_Product_Name.SelectedText = ""
        Me.txt_Product_Name.Size = New System.Drawing.Size(282, 40)
        Me.txt_Product_Name.TabIndex = 9
        Me.txt_Product_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(893, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(150, 40)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "اسم المنتج"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Unit_Quantity
        '
        Me.Unit_Quantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Unit_Quantity.BorderRadius = 5
        Me.Unit_Quantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Unit_Quantity.DefaultText = ""
        Me.Unit_Quantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Unit_Quantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Unit_Quantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Unit_Quantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Unit_Quantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Unit_Quantity.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unit_Quantity.ForeColor = System.Drawing.Color.Black
        Me.Unit_Quantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Unit_Quantity.Location = New System.Drawing.Point(1051, 242)
        Me.Unit_Quantity.Margin = New System.Windows.Forms.Padding(5)
        Me.Unit_Quantity.Name = "Unit_Quantity"
        Me.Unit_Quantity.PlaceholderText = ""
        Me.Unit_Quantity.SelectedText = ""
        Me.Unit_Quantity.Size = New System.Drawing.Size(282, 40)
        Me.Unit_Quantity.TabIndex = 7
        Me.Unit_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(1341, 215)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 96)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "الوحدات الصغيرة التي داخلها"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Unit_Name
        '
        Me.Unit_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Unit_Name.BorderRadius = 5
        Me.Unit_Name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Unit_Name.DefaultText = ""
        Me.Unit_Name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Unit_Name.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Unit_Name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Unit_Name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Unit_Name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Unit_Name.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unit_Name.ForeColor = System.Drawing.Color.Black
        Me.Unit_Name.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Unit_Name.Location = New System.Drawing.Point(1051, 159)
        Me.Unit_Name.Margin = New System.Windows.Forms.Padding(5)
        Me.Unit_Name.Name = "Unit_Name"
        Me.Unit_Name.PlaceholderText = ""
        Me.Unit_Name.SelectedText = ""
        Me.Unit_Name.Size = New System.Drawing.Size(282, 40)
        Me.Unit_Name.TabIndex = 5
        Me.Unit_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1341, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 40)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "اسم الوحدة"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Product_ID
        '
        Me.Product_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Product_ID.BorderRadius = 5
        Me.Product_ID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Product_ID.DefaultText = ""
        Me.Product_ID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Product_ID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Product_ID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Product_ID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Product_ID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Product_ID.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Product_ID.ForeColor = System.Drawing.Color.Black
        Me.Product_ID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Product_ID.Location = New System.Drawing.Point(1108, 107)
        Me.Product_ID.Margin = New System.Windows.Forms.Padding(5)
        Me.Product_ID.Name = "Product_ID"
        Me.Product_ID.PlaceholderText = ""
        Me.Product_ID.SelectedText = ""
        Me.Product_ID.Size = New System.Drawing.Size(225, 40)
        Me.Product_ID.TabIndex = 3
        Me.Product_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1341, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 40)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "كود المنتج"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductUnit_ID
        '
        Me.ProductUnit_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProductUnit_ID.BorderRadius = 5
        Me.ProductUnit_ID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ProductUnit_ID.DefaultText = ""
        Me.ProductUnit_ID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.ProductUnit_ID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ProductUnit_ID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ProductUnit_ID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ProductUnit_ID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ProductUnit_ID.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductUnit_ID.ForeColor = System.Drawing.Color.Black
        Me.ProductUnit_ID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ProductUnit_ID.Location = New System.Drawing.Point(1051, 55)
        Me.ProductUnit_ID.Margin = New System.Windows.Forms.Padding(5)
        Me.ProductUnit_ID.Name = "ProductUnit_ID"
        Me.ProductUnit_ID.PlaceholderText = ""
        Me.ProductUnit_ID.SelectedText = ""
        Me.ProductUnit_ID.Size = New System.Drawing.Size(282, 40)
        Me.ProductUnit_ID.TabIndex = 1
        Me.ProductUnit_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1341, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 40)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "كود الوحدة"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstSuggestions
        '
        Me.lstSuggestions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSuggestions.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSuggestions.FormattingEnabled = True
        Me.lstSuggestions.ItemHeight = 16
        Me.lstSuggestions.Location = New System.Drawing.Point(603, 98)
        Me.lstSuggestions.Name = "lstSuggestions"
        Me.lstSuggestions.Size = New System.Drawing.Size(282, 100)
        Me.lstSuggestions.TabIndex = 20
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.Controls.Add(Me.txt_PrintCount)
        Me.Guna2Panel3.Controls.Add(Me.btn_clear)
        Me.Guna2Panel3.Controls.Add(Me.btn_print)
        Me.Guna2Panel3.Controls.Add(Me.btn_delete)
        Me.Guna2Panel3.Controls.Add(Me.btn_edit)
        Me.Guna2Panel3.Controls.Add(Me.btn_add)
        Me.Guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel3.Location = New System.Drawing.Point(0, 503)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.Size = New System.Drawing.Size(1500, 77)
        Me.Guna2Panel3.TabIndex = 3
        '
        'txt_PrintCount
        '
        Me.txt_PrintCount.BorderRadius = 5
        Me.txt_PrintCount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_PrintCount.DefaultText = "1"
        Me.txt_PrintCount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_PrintCount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_PrintCount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_PrintCount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_PrintCount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_PrintCount.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PrintCount.ForeColor = System.Drawing.Color.Black
        Me.txt_PrintCount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_PrintCount.Location = New System.Drawing.Point(229, 13)
        Me.txt_PrintCount.Margin = New System.Windows.Forms.Padding(5)
        Me.txt_PrintCount.Name = "txt_PrintCount"
        Me.txt_PrintCount.PlaceholderText = ""
        Me.txt_PrintCount.SelectedText = ""
        Me.txt_PrintCount.Size = New System.Drawing.Size(83, 56)
        Me.txt_PrintCount.TabIndex = 21
        Me.txt_PrintCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_clear
        '
        Me.btn_clear.BorderRadius = 10
        Me.btn_clear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_clear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_clear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_clear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_clear.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btn_clear.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.btn_clear.ForeColor = System.Drawing.Color.White
        Me.btn_clear.Image = Global.WindowsApp1.My.Resources.Resources.clear
        Me.btn_clear.ImageOffset = New System.Drawing.Point(-10, 0)
        Me.btn_clear.ImageSize = New System.Drawing.Size(50, 50)
        Me.btn_clear.Location = New System.Drawing.Point(12, 13)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(180, 56)
        Me.btn_clear.TabIndex = 4
        Me.btn_clear.Text = "تفريغ"
        '
        'btn_print
        '
        Me.btn_print.BorderRadius = 10
        Me.btn_print.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_print.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_print.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_print.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_print.FillColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_print.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.btn_print.ForeColor = System.Drawing.Color.White
        Me.btn_print.Image = Global.WindowsApp1.My.Resources.Resources.print
        Me.btn_print.ImageSize = New System.Drawing.Size(50, 50)
        Me.btn_print.Location = New System.Drawing.Point(320, 13)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(240, 56)
        Me.btn_print.TabIndex = 3
        Me.btn_print.Text = "طباعة الباركود"
        '
        'btn_delete
        '
        Me.btn_delete.BorderRadius = 10
        Me.btn_delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_delete.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.btn_delete.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.btn_delete.ForeColor = System.Drawing.Color.White
        Me.btn_delete.Image = Global.WindowsApp1.My.Resources.Resources.delete2
        Me.btn_delete.ImageSize = New System.Drawing.Size(50, 45)
        Me.btn_delete.Location = New System.Drawing.Point(688, 13)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(180, 56)
        Me.btn_delete.TabIndex = 2
        Me.btn_delete.Text = "حذف"
        '
        'btn_edit
        '
        Me.btn_edit.BorderRadius = 10
        Me.btn_edit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_edit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_edit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_edit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_edit.FillColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.btn_edit.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.btn_edit.ForeColor = System.Drawing.Color.White
        Me.btn_edit.Image = Global.WindowsApp1.My.Resources.Resources.pencil
        Me.btn_edit.ImageSize = New System.Drawing.Size(50, 50)
        Me.btn_edit.Location = New System.Drawing.Point(996, 13)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(180, 56)
        Me.btn_edit.TabIndex = 1
        Me.btn_edit.Text = "تعديل"
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.Color.Transparent
        Me.btn_add.BorderRadius = 10
        Me.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_add.FillColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_add.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add.ForeColor = System.Drawing.Color.White
        Me.btn_add.Image = Global.WindowsApp1.My.Resources.Resources.add_button
        Me.btn_add.ImageSize = New System.Drawing.Size(50, 50)
        Me.btn_add.Location = New System.Drawing.Point(1304, 13)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(180, 56)
        Me.btn_add.TabIndex = 0
        Me.btn_add.Text = "اضافة"
        '
        'dgv_ProductUnits
        '
        Me.dgv_ProductUnits.AllowUserToAddRows = False
        Me.dgv_ProductUnits.AllowUserToDeleteRows = False
        Me.dgv_ProductUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ProductUnits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ProductUnits.Location = New System.Drawing.Point(0, 580)
        Me.dgv_ProductUnits.Name = "dgv_ProductUnits"
        Me.dgv_ProductUnits.ReadOnly = True
        Me.dgv_ProductUnits.RowTemplate.Height = 40
        Me.dgv_ProductUnits.RowTemplate.ReadOnly = True
        Me.dgv_ProductUnits.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ProductUnits.Size = New System.Drawing.Size(1500, 320)
        Me.dgv_ProductUnits.TabIndex = 4
        '
        'ProductUnits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1500, 900)
        Me.Controls.Add(Me.dgv_ProductUnits)
        Me.Controls.Add(Me.Guna2Panel3)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductUnits"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2GroupBox1.ResumeLayout(False)
        Me.Guna2Panel3.ResumeLayout(False)
        CType(Me.dgv_ProductUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_close As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_min As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btn_max As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ProductUnit_ID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_add As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_update As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_clear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_print As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_delete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_edit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgv_ProductUnits As DataGridView
    Friend WithEvents Sale_Price As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Purchase_Price As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_Product_Name As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Unit_Quantity As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Unit_Name As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Product_ID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_Barcode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Notes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnSearchByName As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSearchByID As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txt_PrintCount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2DateTimePicker1 As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents btn_generate_barcode As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_scan_bar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_ProductCode As Guna.UI2.WinForms.Guna2TextBox
End Class
