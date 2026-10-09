<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKitchenComments
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvComments = New System.Windows.Forms.DataGridView()
        Me.grpInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.pnlActions = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClearFields = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.btnEdit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.tgStatus = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtCommentText = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblCommentText = New System.Windows.Forms.Label()
        Me.txtCommentCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblCommentCode = New System.Windows.Forms.Label()
        Me.txtSearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnMinimize = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.btnClose = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.lblTitle = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        CType(Me.dgvComments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInfo.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvComments
        '
        Me.dgvComments.AllowUserToAddRows = False
        Me.dgvComments.AllowUserToDeleteRows = False
        Me.dgvComments.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.dgvComments.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvComments.BackgroundColor = System.Drawing.Color.White
        Me.dgvComments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvComments.ColumnHeadersHeight = 38
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvComments.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComments.Location = New System.Drawing.Point(0, 290)
        Me.dgvComments.MultiSelect = False
        Me.dgvComments.Name = "dgvComments"
        Me.dgvComments.ReadOnly = True
        Me.dgvComments.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvComments.RowHeadersVisible = False
        Me.dgvComments.RowTemplate.Height = 36
        Me.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComments.Size = New System.Drawing.Size(950, 360)
        Me.dgvComments.TabIndex = 2
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.pnlActions)
        Me.grpInfo.Controls.Add(Me.tgStatus)
        Me.grpInfo.Controls.Add(Me.lblStatus)
        Me.grpInfo.Controls.Add(Me.txtCommentText)
        Me.grpInfo.Controls.Add(Me.lblCommentText)
        Me.grpInfo.Controls.Add(Me.txtCommentCode)
        Me.grpInfo.Controls.Add(Me.lblCommentCode)
        Me.grpInfo.Controls.Add(Me.txtSearch)
        Me.grpInfo.Controls.Add(Me.lblSearch)
        Me.grpInfo.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.grpInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.grpInfo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.grpInfo.Location = New System.Drawing.Point(0, 60)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpInfo.Size = New System.Drawing.Size(950, 230)
        Me.grpInfo.TabIndex = 1
        Me.grpInfo.Text = "بيانات تعليق المطبخ"
        Me.grpInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlActions
        '
        Me.pnlActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlActions.BackColor = System.Drawing.Color.Transparent
        Me.pnlActions.Controls.Add(Me.btnRefresh)
        Me.pnlActions.Controls.Add(Me.btnClearFields)
        Me.pnlActions.Controls.Add(Me.btnDelete)
        Me.pnlActions.Controls.Add(Me.btnEdit)
        Me.pnlActions.Controls.Add(Me.btnAdd)
        Me.pnlActions.Location = New System.Drawing.Point(20, 165)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(910, 50)
        Me.pnlActions.TabIndex = 8
        '
        'btnRefresh
        '
        Me.btnRefresh.BorderRadius = 8
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FillColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(10, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 40)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "تحديث 🔄"
        '
        'btnClearFields
        '
        Me.btnClearFields.BorderRadius = 8
        Me.btnClearFields.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearFields.FillColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.btnClearFields.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearFields.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnClearFields.Location = New System.Drawing.Point(140, 5)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(120, 40)
        Me.btnClearFields.TabIndex = 3
        Me.btnClearFields.Text = "تفريغ الحقول"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BorderRadius = 8
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(520, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 40)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "حذف 🗑️"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BorderRadius = 8
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(650, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(120, 40)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "تعديل ✏️"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BorderRadius = 8
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(780, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 40)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "إضافة ➕"
        '
        'tgStatus
        '
        Me.tgStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStatus.Checked = True
        Me.tgStatus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.tgStatus.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.tgStatus.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tgStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tgStatus.Location = New System.Drawing.Point(70, 75)
        Me.tgStatus.Name = "tgStatus"
        Me.tgStatus.Size = New System.Drawing.Size(50, 28)
        Me.tgStatus.TabIndex = 5
        Me.tgStatus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tgStatus.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tgStatus.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(125, 78)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 19)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "نشط:"
        '
        'txtCommentText
        '
        Me.txtCommentText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommentText.BorderRadius = 8
        Me.txtCommentText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCommentText.DefaultText = ""
        Me.txtCommentText.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.txtCommentText.ForeColor = System.Drawing.Color.Black
        Me.txtCommentText.Location = New System.Drawing.Point(200, 70)
        Me.txtCommentText.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCommentText.Name = "txtCommentText"
        Me.txtCommentText.PlaceholderText = "مثال: بدون سكر، شطة زيادة، مستوي جيداً..."
        Me.txtCommentText.SelectedText = ""
        Me.txtCommentText.Size = New System.Drawing.Size(450, 36)
        Me.txtCommentText.TabIndex = 3
        '
        'lblCommentText
        '
        Me.lblCommentText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCommentText.AutoSize = True
        Me.lblCommentText.BackColor = System.Drawing.Color.Transparent
        Me.lblCommentText.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCommentText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.lblCommentText.Location = New System.Drawing.Point(655, 78)
        Me.lblCommentText.Name = "lblCommentText"
        Me.lblCommentText.Size = New System.Drawing.Size(84, 19)
        Me.lblCommentText.TabIndex = 2
        Me.lblCommentText.Text = "نص التعليق *:"
        '
        'txtCommentCode
        '
        Me.txtCommentCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommentCode.BorderRadius = 8
        Me.txtCommentCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCommentCode.DefaultText = ""
        Me.txtCommentCode.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.txtCommentCode.ForeColor = System.Drawing.Color.Black
        Me.txtCommentCode.Location = New System.Drawing.Point(745, 70)
        Me.txtCommentCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCommentCode.Name = "txtCommentCode"
        Me.txtCommentCode.PlaceholderText = "تلقائي"
        Me.txtCommentCode.ReadOnly = True
        Me.txtCommentCode.SelectedText = ""
        Me.txtCommentCode.Size = New System.Drawing.Size(120, 36)
        Me.txtCommentCode.TabIndex = 1
        '
        'lblCommentCode
        '
        Me.lblCommentCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCommentCode.AutoSize = True
        Me.lblCommentCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCommentCode.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCommentCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.lblCommentCode.Location = New System.Drawing.Point(870, 78)
        Me.lblCommentCode.Name = "lblCommentCode"
        Me.lblCommentCode.Size = New System.Drawing.Size(43, 19)
        Me.lblCommentCode.TabIndex = 0
        Me.lblCommentCode.Text = "الكود *:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderRadius = 8
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.DefaultText = ""
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.Location = New System.Drawing.Point(20, 118)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "ابحث بالاسم أو الكود..."
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(845, 34)
        Me.txtSearch.TabIndex = 7
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.AutoSize = True
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(870, 125)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(39, 19)
        Me.lblSearch.TabIndex = 6
        Me.lblSearch.Text = "بحث:"
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btnMinimize)
        Me.panelHeader.Controls.Add(Me.btnClose)
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(950, 60)
        Me.panelHeader.TabIndex = 0
        '
        'btnMinimize
        '
        Me.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.btnMinimize.FillColor = System.Drawing.Color.Transparent
        Me.btnMinimize.IconColor = System.Drawing.Color.White
        Me.btnMinimize.Location = New System.Drawing.Point(50, 14)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(32, 32)
        Me.btnMinimize.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.FillColor = System.Drawing.Color.Transparent
        Me.btnClose.IconColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(12, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(32, 32)
        Me.btnClose.TabIndex = 2
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(797, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(124, 27)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "المطبخ تعليقات"
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 12
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = False
        '
        'frmKitchenComments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(950, 650)
        Me.Controls.Add(Me.dgvComments)
        Me.Controls.Add(Me.grpInfo)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmKitchenComments"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعليقات وملاحظات المطبخ"
        CType(Me.dgvComments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents btnMinimize As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents grpInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents lblCommentCode As System.Windows.Forms.Label
    Friend WithEvents txtCommentCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblCommentText As System.Windows.Forms.Label
    Friend WithEvents txtCommentText As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents tgStatus As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pnlActions As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClearFields As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgvComments As System.Windows.Forms.DataGridView
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
