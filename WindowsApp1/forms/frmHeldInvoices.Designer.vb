<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHeldInvoices
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

        '── Controls ─────────────────────────────────────────────────
        Me.pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblHeldTitle = New System.Windows.Forms.Label()
        Me.pnlSplit = New System.Windows.Forms.Panel()
        Me.pnlHeldList = New System.Windows.Forms.Panel()
        Me.lblHeldListTitle = New System.Windows.Forms.Label()
        Me.dgvHeldInvoices = New System.Windows.Forms.DataGridView()
        Me.colHeldID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHeldCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHeldTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHeldTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlHeldDetails = New System.Windows.Forms.Panel()
        Me.lblHeldDetailsTitle = New System.Windows.Forms.Label()
        Me.dgvHeldDetails = New System.Windows.Forms.DataGridView()
        Me.colDetItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlHeldActions = New System.Windows.Forms.Panel()
        Me.btnRestoreInvoice = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteHeldInvoice = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCloseHeld = New Guna.UI2.WinForms.Guna2Button()

        CType(Me.dgvHeldInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHeldDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlSplit.SuspendLayout()
        Me.pnlHeldList.SuspendLayout()
        Me.pnlHeldDetails.SuspendLayout()
        Me.pnlHeldActions.SuspendLayout()
        Me.SuspendLayout()

        ' ═══════════════════════════════════════════════════════════
        '  pnlHeader  —  60px
        ' ═══════════════════════════════════════════════════════════
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.FillColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(900, 60)
        Me.pnlHeader.ShadowDecoration.Enabled = False
        Me.pnlHeader.Controls.Add(Me.lblHeldTitle)

        '  lblHeldTitle
        Me.lblHeldTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblHeldTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeldTitle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblHeldTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeldTitle.Name = "lblHeldTitle"
        Me.lblHeldTitle.Size = New System.Drawing.Size(900, 60)
        Me.lblHeldTitle.TabIndex = 0
        Me.lblHeldTitle.Text = "⏸  الفواتير المعلقة"
        Me.lblHeldTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ═══════════════════════════════════════════════════════════
        '  pnlHeldActions  —  72px bottom
        ' ═══════════════════════════════════════════════════════════
        Me.pnlHeldActions.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.pnlHeldActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlHeldActions.Name = "pnlHeldActions"
        Me.pnlHeldActions.Size = New System.Drawing.Size(900, 72)
        Me.pnlHeldActions.Controls.Add(Me.btnRestoreInvoice)
        Me.pnlHeldActions.Controls.Add(Me.btnDeleteHeldInvoice)
        Me.pnlHeldActions.Controls.Add(Me.btnCloseHeld)

        '  btnRestoreInvoice  —  Green
        Me.btnRestoreInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRestoreInvoice.BorderRadius = 10
        Me.btnRestoreInvoice.FillColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnRestoreInvoice.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnRestoreInvoice.ForeColor = System.Drawing.Color.White
        Me.btnRestoreInvoice.HoverState.FillColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.btnRestoreInvoice.PressedColor = System.Drawing.Color.FromArgb(25, 135, 65)
        Me.btnRestoreInvoice.Location = New System.Drawing.Point(10, 12)
        Me.btnRestoreInvoice.Name = "btnRestoreInvoice"
        Me.btnRestoreInvoice.Size = New System.Drawing.Size(220, 48)
        Me.btnRestoreInvoice.TabIndex = 90
        Me.btnRestoreInvoice.Text = "▶  استرجاع الفاتورة"
        Me.btnRestoreInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '  btnDeleteHeldInvoice  —  Red
        Me.btnDeleteHeldInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteHeldInvoice.BorderRadius = 10
        Me.btnDeleteHeldInvoice.FillColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.btnDeleteHeldInvoice.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnDeleteHeldInvoice.ForeColor = System.Drawing.Color.White
        Me.btnDeleteHeldInvoice.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 100, 84)
        Me.btnDeleteHeldInvoice.PressedColor = System.Drawing.Color.FromArgb(180, 45, 35)
        Me.btnDeleteHeldInvoice.Location = New System.Drawing.Point(240, 12)
        Me.btnDeleteHeldInvoice.Name = "btnDeleteHeldInvoice"
        Me.btnDeleteHeldInvoice.Size = New System.Drawing.Size(200, 48)
        Me.btnDeleteHeldInvoice.TabIndex = 91
        Me.btnDeleteHeldInvoice.Text = "🗑  حذف الفاتورة"
        Me.btnDeleteHeldInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '  btnCloseHeld  —  Dark
        Me.btnCloseHeld.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCloseHeld.BorderRadius = 10
        Me.btnCloseHeld.FillColor = System.Drawing.Color.FromArgb(52, 73, 94)
        Me.btnCloseHeld.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCloseHeld.ForeColor = System.Drawing.Color.White
        Me.btnCloseHeld.HoverState.FillColor = System.Drawing.Color.FromArgb(72, 100, 130)
        Me.btnCloseHeld.PressedColor = System.Drawing.Color.FromArgb(35, 50, 65)
        Me.btnCloseHeld.Location = New System.Drawing.Point(450, 12)
        Me.btnCloseHeld.Name = "btnCloseHeld"
        Me.btnCloseHeld.Size = New System.Drawing.Size(160, 48)
        Me.btnCloseHeld.TabIndex = 92
        Me.btnCloseHeld.Text = "✖  إغلاق"
        Me.btnCloseHeld.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ═══════════════════════════════════════════════════════════
        '  pnlSplit  —  Split container for two grids
        ' ═══════════════════════════════════════════════════════════
        Me.pnlSplit.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.pnlSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSplit.Name = "pnlSplit"
        Me.pnlSplit.Controls.Add(Me.pnlHeldDetails)
        Me.pnlSplit.Controls.Add(Me.pnlHeldList)

        ' ═══════════════════════════════════════════════════════════
        '  pnlHeldList  —  Left DGV (Docked Left, 420px)
        ' ═══════════════════════════════════════════════════════════
        Me.pnlHeldList.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.pnlHeldList.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlHeldList.Name = "pnlHeldList"
        Me.pnlHeldList.Size = New System.Drawing.Size(420, 428)
        Me.pnlHeldList.Controls.Add(Me.dgvHeldInvoices)
        Me.pnlHeldList.Controls.Add(Me.lblHeldListTitle)

        '  lblHeldListTitle
        Me.lblHeldListTitle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblHeldListTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHeldListTitle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblHeldListTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeldListTitle.Name = "lblHeldListTitle"
        Me.lblHeldListTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblHeldListTitle.Size = New System.Drawing.Size(420, 36)
        Me.lblHeldListTitle.TabIndex = 0
        Me.lblHeldListTitle.Text = "قائمة الفواتير المعلقة"
        Me.lblHeldListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '  dgvHeldInvoices
        Me.dgvHeldInvoices.AllowUserToAddRows = False
        Me.dgvHeldInvoices.AllowUserToDeleteRows = False
        Me.dgvHeldInvoices.AllowUserToResizeRows = False
        Me.dgvHeldInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHeldInvoices.BackgroundColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.dgvHeldInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvHeldInvoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvHeldInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Dim heldHdrStyle As New System.Windows.Forms.DataGridViewCellStyle()
        heldHdrStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        heldHdrStyle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        heldHdrStyle.ForeColor = System.Drawing.Color.White
        heldHdrStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        heldHdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.dgvHeldInvoices.ColumnHeadersDefaultCellStyle = heldHdrStyle
        Me.dgvHeldInvoices.ColumnHeadersHeight = 40
        Me.dgvHeldInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Dim heldRowStyle As New System.Windows.Forms.DataGridViewCellStyle()
        heldRowStyle.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        heldRowStyle.ForeColor = System.Drawing.Color.White
        heldRowStyle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        heldRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        heldRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(39, 174, 96)
        heldRowStyle.SelectionForeColor = System.Drawing.Color.White
        Me.dgvHeldInvoices.DefaultCellStyle = heldRowStyle
        Dim heldAltStyle As New System.Windows.Forms.DataGridViewCellStyle()
        heldAltStyle.BackColor = System.Drawing.Color.FromArgb(42, 42, 62)
        Me.dgvHeldInvoices.AlternatingRowsDefaultCellStyle = heldAltStyle
        Me.dgvHeldInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHeldInvoices.GridColor = System.Drawing.Color.FromArgb(60, 60, 80)
        Me.dgvHeldInvoices.MultiSelect = False
        Me.dgvHeldInvoices.Name = "dgvHeldInvoices"
        Me.dgvHeldInvoices.ReadOnly = True
        Me.dgvHeldInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvHeldInvoices.RowHeadersVisible = False
        Me.dgvHeldInvoices.RowTemplate.Height = 42
        Me.dgvHeldInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHeldInvoices.TabIndex = 1

        '  Columns for dgvHeldInvoices
        Me.colHeldID.DataPropertyName = "HeldID"
        Me.colHeldID.HeaderText = "رقم"
        Me.colHeldID.Name = "colHeldID"
        Me.colHeldID.FillWeight = 15

        Me.colHeldCustomer.DataPropertyName = "CustomerName"
        Me.colHeldCustomer.HeaderText = "العميل"
        Me.colHeldCustomer.Name = "colHeldCustomer"
        Me.colHeldCustomer.FillWeight = 35

        Me.colHeldTime.DataPropertyName = "HoldTime"
        Me.colHeldTime.HeaderText = "الوقت"
        Me.colHeldTime.Name = "colHeldTime"
        Me.colHeldTime.FillWeight = 28

        Me.colHeldTotal.DataPropertyName = "Total"
        Me.colHeldTotal.HeaderText = "الإجمالي"
        Me.colHeldTotal.Name = "colHeldTotal"
        Me.colHeldTotal.FillWeight = 22

        Me.dgvHeldInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {
            Me.colHeldID, Me.colHeldCustomer, Me.colHeldTime, Me.colHeldTotal})

        ' ═══════════════════════════════════════════════════════════
        '  pnlHeldDetails  —  Right DGV (Fills remaining space)
        ' ═══════════════════════════════════════════════════════════
        Me.pnlHeldDetails.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.pnlHeldDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeldDetails.Name = "pnlHeldDetails"
        Me.pnlHeldDetails.Controls.Add(Me.dgvHeldDetails)
        Me.pnlHeldDetails.Controls.Add(Me.lblHeldDetailsTitle)

        '  lblHeldDetailsTitle
        Me.lblHeldDetailsTitle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblHeldDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHeldDetailsTitle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblHeldDetailsTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeldDetailsTitle.Name = "lblHeldDetailsTitle"
        Me.lblHeldDetailsTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblHeldDetailsTitle.Size = New System.Drawing.Size(480, 36)
        Me.lblHeldDetailsTitle.TabIndex = 0
        Me.lblHeldDetailsTitle.Text = "تفاصيل الفاتورة المحددة"
        Me.lblHeldDetailsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '  dgvHeldDetails
        Me.dgvHeldDetails.AllowUserToAddRows = False
        Me.dgvHeldDetails.AllowUserToDeleteRows = False
        Me.dgvHeldDetails.AllowUserToResizeRows = False
        Me.dgvHeldDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHeldDetails.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.dgvHeldDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvHeldDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvHeldDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Dim detHdrStyle As New System.Windows.Forms.DataGridViewCellStyle()
        detHdrStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        detHdrStyle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        detHdrStyle.ForeColor = System.Drawing.Color.White
        detHdrStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        detHdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.dgvHeldDetails.ColumnHeadersDefaultCellStyle = detHdrStyle
        Me.dgvHeldDetails.ColumnHeadersHeight = 40
        Me.dgvHeldDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Dim detRowStyle As New System.Windows.Forms.DataGridViewCellStyle()
        detRowStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        detRowStyle.ForeColor = System.Drawing.Color.White
        detRowStyle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        detRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        detRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185)
        detRowStyle.SelectionForeColor = System.Drawing.Color.White
        Me.dgvHeldDetails.DefaultCellStyle = detRowStyle
        Dim detAltStyle As New System.Windows.Forms.DataGridViewCellStyle()
        detAltStyle.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.dgvHeldDetails.AlternatingRowsDefaultCellStyle = detAltStyle
        Me.dgvHeldDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHeldDetails.GridColor = System.Drawing.Color.FromArgb(60, 60, 80)
        Me.dgvHeldDetails.MultiSelect = False
        Me.dgvHeldDetails.Name = "dgvHeldDetails"
        Me.dgvHeldDetails.ReadOnly = True
        Me.dgvHeldDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvHeldDetails.RowHeadersVisible = False
        Me.dgvHeldDetails.RowTemplate.Height = 40
        Me.dgvHeldDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHeldDetails.TabIndex = 1

        '  Columns for dgvHeldDetails
        Me.colDetItem.DataPropertyName = "ItemName"
        Me.colDetItem.HeaderText = "المنتج"
        Me.colDetItem.Name = "colDetItem"
        Me.colDetItem.FillWeight = 35

        Me.colDetSize.DataPropertyName = "SizeName"
        Me.colDetSize.HeaderText = "الحجم"
        Me.colDetSize.Name = "colDetSize"
        Me.colDetSize.FillWeight = 15

        Me.colDetQty.DataPropertyName = "Qty"
        Me.colDetQty.HeaderText = "الكمية"
        Me.colDetQty.Name = "colDetQty"
        Me.colDetQty.FillWeight = 15

        Me.colDetPrice.DataPropertyName = "Price"
        Me.colDetPrice.HeaderText = "السعر"
        Me.colDetPrice.Name = "colDetPrice"
        Me.colDetPrice.FillWeight = 17

        Me.colDetTotal.DataPropertyName = "Total"
        Me.colDetTotal.HeaderText = "الإجمالي"
        Me.colDetTotal.Name = "colDetTotal"
        Me.colDetTotal.FillWeight = 18

        Me.dgvHeldDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {
            Me.colDetItem, Me.colDetSize, Me.colDetQty, Me.colDetPrice, Me.colDetTotal})

        ' ═══════════════════════════════════════════════════════════
        '  frmHeldInvoices  —  Form properties
        ' ═══════════════════════════════════════════════════════════
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.ClientSize = New System.Drawing.Size(900, 560)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHeldInvoices"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "الفواتير المعلقة"

        Me.Controls.Add(Me.pnlSplit)
        Me.Controls.Add(Me.pnlHeldActions)
        Me.Controls.Add(Me.pnlHeader)

        CType(Me.dgvHeldInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHeldDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlSplit.ResumeLayout(False)
        Me.pnlHeldList.ResumeLayout(False)
        Me.pnlHeldDetails.ResumeLayout(False)
        Me.pnlHeldActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    '── Field declarations ───────────────────────────────────────────
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblHeldTitle As System.Windows.Forms.Label
    Friend WithEvents pnlSplit As System.Windows.Forms.Panel
    Friend WithEvents pnlHeldList As System.Windows.Forms.Panel
    Friend WithEvents lblHeldListTitle As System.Windows.Forms.Label
    Friend WithEvents dgvHeldInvoices As System.Windows.Forms.DataGridView
    Friend WithEvents colHeldID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHeldCustomer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHeldTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHeldTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlHeldDetails As System.Windows.Forms.Panel
    Friend WithEvents lblHeldDetailsTitle As System.Windows.Forms.Label
    Friend WithEvents dgvHeldDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colDetItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlHeldActions As System.Windows.Forms.Panel
    Friend WithEvents btnRestoreInvoice As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteHeldInvoice As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCloseHeld As Guna.UI2.WinForms.Guna2Button

End Class
