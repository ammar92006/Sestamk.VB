<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStoreStock
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStoreStock))
        Me.dgvStock = New System.Windows.Forms.DataGridView()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.cmbMaxUnit = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbMinUnit = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblStockStatus = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCurrentStock = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMaxStock = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cmbMaterial = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbStore = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMinStock = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDisplayedStock = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClearFields = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.cmbSearchField = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lstSuggestions = New System.Windows.Forms.ListBox()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_min = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_max = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerInfo.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvStock
        '
        Me.dgvStock.AllowUserToResizeColumns = False
        Me.dgvStock.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvStock.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStock.BackgroundColor = System.Drawing.Color.White
        Me.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStock.Location = New System.Drawing.Point(0, 340)
        Me.dgvStock.Name = "dgvStock"
        Me.dgvStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvStock.RowTemplate.Height = 40
        Me.dgvStock.Size = New System.Drawing.Size(1311, 510)
        Me.dgvStock.TabIndex = 47
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.cmbMaxUnit)
        Me.grpCustomerInfo.Controls.Add(Me.cmbMinUnit)
        Me.grpCustomerInfo.Controls.Add(Me.lblStockStatus)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.txtCurrentStock)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.txtMaxStock)
        Me.grpCustomerInfo.Controls.Add(Me.cmbMaterial)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.cmbStore)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.txtMinStock)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.txtDisplayedStock)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2Panel1)
        Me.grpCustomerInfo.Controls.Add(Me.cmbSearchField)
        Me.grpCustomerInfo.Controls.Add(Me.lstSuggestions)
        Me.grpCustomerInfo.Controls.Add(Me.txtSearch)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 70)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1311, 270)
        Me.grpCustomerInfo.TabIndex = 46
        Me.grpCustomerInfo.Text = "البيانات"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbMaxUnit
        '
        Me.cmbMaxUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMaxUnit.BackColor = System.Drawing.Color.Transparent
        Me.cmbMaxUnit.BorderRadius = 6
        Me.cmbMaxUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMaxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaxUnit.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMaxUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMaxUnit.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbMaxUnit.ForeColor = System.Drawing.Color.Black
        Me.cmbMaxUnit.ItemHeight = 30
        Me.cmbMaxUnit.Location = New System.Drawing.Point(620, 138)
        Me.cmbMaxUnit.Name = "cmbMaxUnit"
        Me.cmbMaxUnit.Size = New System.Drawing.Size(128, 36)
        Me.cmbMaxUnit.TabIndex = 5621
        Me.cmbMaxUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbMinUnit
        '
        Me.cmbMinUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMinUnit.BackColor = System.Drawing.Color.Transparent
        Me.cmbMinUnit.BorderRadius = 6
        Me.cmbMinUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMinUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMinUnit.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMinUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbMinUnit.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbMinUnit.ForeColor = System.Drawing.Color.Black
        Me.cmbMinUnit.ItemHeight = 30
        Me.cmbMinUnit.Location = New System.Drawing.Point(620, 92)
        Me.cmbMinUnit.Name = "cmbMinUnit"
        Me.cmbMinUnit.Size = New System.Drawing.Size(128, 36)
        Me.cmbMinUnit.TabIndex = 5620
        Me.cmbMinUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStockStatus
        '
        Me.lblStockStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStockStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStockStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStockStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblStockStatus.Location = New System.Drawing.Point(983, 197)
        Me.lblStockStatus.Name = "lblStockStatus"
        Me.lblStockStatus.Size = New System.Drawing.Size(219, 36)
        Me.lblStockStatus.TabIndex = 5618
        Me.lblStockStatus.Text = "---"
        Me.lblStockStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(1220, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 36)
        Me.Label7.TabIndex = 5617
        Me.Label7.Text = "الحالة"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(1206, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 36)
        Me.Label6.TabIndex = 5616
        Me.Label6.Text = "الرصيد الحالي"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCurrentStock
        '
        Me.txtCurrentStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrentStock.BorderRadius = 6
        Me.txtCurrentStock.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCurrentStock.DefaultText = ""
        Me.txtCurrentStock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCurrentStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCurrentStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCurrentStock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCurrentStock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCurrentStock.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCurrentStock.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentStock.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtCurrentStock.Location = New System.Drawing.Point(957, 92)
        Me.txtCurrentStock.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCurrentStock.Name = "txtCurrentStock"
        Me.txtCurrentStock.PlaceholderText = ""
        Me.txtCurrentStock.SelectedText = ""
        Me.txtCurrentStock.Size = New System.Drawing.Size(245, 36)
        Me.txtCurrentStock.TabIndex = 5615
        Me.txtCurrentStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(870, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 36)
        Me.Label4.TabIndex = 5614
        Me.Label4.Text = "الحد الأقصى"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMaxStock
        '
        Me.txtMaxStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMaxStock.BorderRadius = 6
        Me.txtMaxStock.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMaxStock.DefaultText = ""
        Me.txtMaxStock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtMaxStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtMaxStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMaxStock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMaxStock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtMaxStock.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtMaxStock.ForeColor = System.Drawing.Color.Black
        Me.txtMaxStock.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtMaxStock.Location = New System.Drawing.Point(754, 138)
        Me.txtMaxStock.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMaxStock.Name = "txtMaxStock"
        Me.txtMaxStock.PlaceholderText = ""
        Me.txtMaxStock.SelectedText = ""
        Me.txtMaxStock.Size = New System.Drawing.Size(110, 36)
        Me.txtMaxStock.TabIndex = 5613
        Me.txtMaxStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.cmbMaterial.Location = New System.Drawing.Point(620, 46)
        Me.cmbMaterial.Name = "cmbMaterial"
        Me.cmbMaterial.Size = New System.Drawing.Size(245, 36)
        Me.cmbMaterial.TabIndex = 5611
        Me.cmbMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(870, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 36)
        Me.Label2.TabIndex = 5610
        Me.Label2.Text = "الخامة"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.cmbStore.Location = New System.Drawing.Point(957, 46)
        Me.cmbStore.Name = "cmbStore"
        Me.cmbStore.Size = New System.Drawing.Size(245, 36)
        Me.cmbStore.TabIndex = 5609
        Me.cmbStore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1206, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 36)
        Me.Label1.TabIndex = 5608
        Me.Label1.Text = "المخزن"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(870, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 36)
        Me.Label5.TabIndex = 5607
        Me.Label5.Text = "الحد الأدنى"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMinStock
        '
        Me.txtMinStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMinStock.BorderRadius = 6
        Me.txtMinStock.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMinStock.DefaultText = ""
        Me.txtMinStock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtMinStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtMinStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMinStock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtMinStock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtMinStock.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtMinStock.ForeColor = System.Drawing.Color.Black
        Me.txtMinStock.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtMinStock.Location = New System.Drawing.Point(754, 92)
        Me.txtMinStock.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMinStock.Name = "txtMinStock"
        Me.txtMinStock.PlaceholderText = ""
        Me.txtMinStock.SelectedText = ""
        Me.txtMinStock.Size = New System.Drawing.Size(110, 36)
        Me.txtMinStock.TabIndex = 5606
        Me.txtMinStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1206, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 36)
        Me.Label3.TabIndex = 5605
        Me.Label3.Text = "الكمية المتوفرة"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDisplayedStock
        '
        Me.txtDisplayedStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDisplayedStock.BorderRadius = 6
        Me.txtDisplayedStock.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDisplayedStock.DefaultText = ""
        Me.txtDisplayedStock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDisplayedStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDisplayedStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDisplayedStock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDisplayedStock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDisplayedStock.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDisplayedStock.ForeColor = System.Drawing.Color.Black
        Me.txtDisplayedStock.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDisplayedStock.Location = New System.Drawing.Point(957, 138)
        Me.txtDisplayedStock.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDisplayedStock.Name = "txtDisplayedStock"
        Me.txtDisplayedStock.PlaceholderText = ""
        Me.txtDisplayedStock.SelectedText = ""
        Me.txtDisplayedStock.Size = New System.Drawing.Size(245, 36)
        Me.txtDisplayedStock.TabIndex = 5604
        Me.txtDisplayedStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.Controls.Add(Me.btnRefresh)
        Me.Guna2Panel1.Controls.Add(Me.btnClearFields)
        Me.Guna2Panel1.Controls.Add(Me.btnDelete)
        Me.Guna2Panel1.Controls.Add(Me.btnEdit)
        Me.Guna2Panel1.Controls.Add(Me.btnAdd)
        Me.Guna2Panel1.Location = New System.Drawing.Point(375, 197)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(580, 55)
        Me.Guna2Panel1.TabIndex = 5600
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
        Me.btnRefresh.Location = New System.Drawing.Point(8, 9)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 38)
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
        Me.btnClearFields.Location = New System.Drawing.Point(118, 9)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(116, 38)
        Me.btnClearFields.TabIndex = 3
        Me.btnClearFields.Text = "تفريغ الحقول"
        '
        'btnDelete
        '
        Me.btnDelete.BorderRadius = 6
        Me.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDelete.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(240, 9)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 38)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف"
        '
        'btnEdit
        '
        Me.btnEdit.BorderRadius = 6
        Me.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnEdit.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(350, 9)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 38)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "تعديل"
        '
        'btnAdd
        '
        Me.btnAdd.BorderRadius = 6
        Me.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(460, 9)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 38)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "إضافة"
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
        Me.cmbSearchField.Size = New System.Drawing.Size(154, 36)
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
        Me.lstSuggestions.Size = New System.Drawing.Size(436, 106)
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
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
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
        Me.panelHeader.Size = New System.Drawing.Size(1311, 70)
        Me.panelHeader.TabIndex = 48
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
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(600, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(152, 39)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = " الفروع مخزون"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmStoreStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1311, 850)
        Me.Controls.Add(Me.dgvStock)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmStoreStock"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStoreStock"
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvStock As DataGridView
    Friend WithEvents dgvStoreStock As DataGridView
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClearFields As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cmbSearchField As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lstSuggestions As ListBox
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cmbStore As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbMaterial As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDisplayedStock As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMinStock As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_min As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_max As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCurrentStock As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMaxStock As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblStockStatus As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbMinUnit As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmbMaxUnit As Guna.UI2.WinForms.Guna2ComboBox
End Class
