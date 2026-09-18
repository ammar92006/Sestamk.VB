<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayInvoice
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblInvoiceTitle = New System.Windows.Forms.Label()
        Me.dgvInvoiceDetails = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.colIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlPaymentMethods = New System.Windows.Forms.Panel()
        Me.btnCash = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCard = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSplit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrintReceipt = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPaymentMethods.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblInvoiceTitle
        '
        Me.lblInvoiceTitle.AutoSize = True
        Me.lblInvoiceTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblInvoiceTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblInvoiceTitle.Location = New System.Drawing.Point(10, 15)
        Me.lblInvoiceTitle.Name = "lblInvoiceTitle"
        Me.lblInvoiceTitle.Size = New System.Drawing.Size(161, 32)
        Me.lblInvoiceTitle.TabIndex = 0
        Me.lblInvoiceTitle.Text = "ملخص الفاتورة"
        '
        'dgvInvoiceDetails
        '
        Me.dgvInvoiceDetails.AllowUserToAddRows = False
        Me.dgvInvoiceDetails.AllowUserToDeleteRows = False
        Me.dgvInvoiceDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.dgvInvoiceDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.dgvInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIndex, Me.colProduct, Me.colSize, Me.colQty, Me.colPrice, Me.colTotal})
        Me.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(0, 50)
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.ReadOnly = True
        Me.dgvInvoiceDetails.RowHeadersVisible = False
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(600, 350)
        Me.dgvInvoiceDetails.TabIndex = 1
        '
        'colIndex
        '
        Me.colIndex.FillWeight = 5.0!
        Me.colIndex.HeaderText = "م"
        Me.colIndex.Name = "colIndex"
        Me.colIndex.ReadOnly = True
        '
        'colProduct
        '
        Me.colProduct.FillWeight = 35.0!
        Me.colProduct.HeaderText = "الصنف"
        Me.colProduct.Name = "colProduct"
        Me.colProduct.ReadOnly = True
        '
        'colSize
        '
        Me.colSize.FillWeight = 15.0!
        Me.colSize.HeaderText = "الحجم"
        Me.colSize.Name = "colSize"
        Me.colSize.ReadOnly = True
        '
        'colQty
        '
        Me.colQty.FillWeight = 10.0!
        Me.colQty.HeaderText = "الكمية"
        Me.colQty.Name = "colQty"
        Me.colQty.ReadOnly = True
        '
        'colPrice
        '
        Me.colPrice.FillWeight = 15.0!
        Me.colPrice.HeaderText = "السعر"
        Me.colPrice.Name = "colPrice"
        Me.colPrice.ReadOnly = True
        '
        'colTotal
        '
        Me.colTotal.FillWeight = 20.0!
        Me.colTotal.HeaderText = "الإجمالي"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        '
        'pnlPaymentMethods
        '
        Me.pnlPaymentMethods.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.pnlPaymentMethods.Controls.Add(Me.btnCash)
        Me.pnlPaymentMethods.Controls.Add(Me.btnCard)
        Me.pnlPaymentMethods.Controls.Add(Me.btnSplit)
        Me.pnlPaymentMethods.Controls.Add(Me.btnPrintReceipt)
        Me.pnlPaymentMethods.Controls.Add(Me.btnClose)
        Me.pnlPaymentMethods.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPaymentMethods.Location = New System.Drawing.Point(0, 520)
        Me.pnlPaymentMethods.Name = "pnlPaymentMethods"
        Me.pnlPaymentMethods.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlPaymentMethods.Size = New System.Drawing.Size(600, 180)
        Me.pnlPaymentMethods.TabIndex = 2
        '
        'btnCash
        '
        Me.btnCash.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnCash.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCash.ForeColor = System.Drawing.Color.White
        Me.btnCash.Location = New System.Drawing.Point(10, 20)
        Me.btnCash.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(120, 38)
        Me.btnCash.TabIndex = 0
        Me.btnCash.Text = "نقداً"
        '
        'btnCard
        '
        Me.btnCard.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnCard.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCard.ForeColor = System.Drawing.Color.White
        Me.btnCard.Location = New System.Drawing.Point(140, 20)
        Me.btnCard.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(120, 38)
        Me.btnCard.TabIndex = 1
        Me.btnCard.Text = "بطاقة"
        '
        'btnSplit
        '
        Me.btnSplit.FillColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnSplit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSplit.ForeColor = System.Drawing.Color.White
        Me.btnSplit.Location = New System.Drawing.Point(270, 20)
        Me.btnSplit.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSplit.Name = "btnSplit"
        Me.btnSplit.Size = New System.Drawing.Size(150, 38)
        Me.btnSplit.TabIndex = 2
        Me.btnSplit.Text = "تقسيم الفاتورة"
        '
        'btnPrintReceipt
        '
        Me.btnPrintReceipt.FillColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnPrintReceipt.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintReceipt.ForeColor = System.Drawing.Color.White
        Me.btnPrintReceipt.Location = New System.Drawing.Point(10, 80)
        Me.btnPrintReceipt.Margin = New System.Windows.Forms.Padding(5)
        Me.btnPrintReceipt.Name = "btnPrintReceipt"
        Me.btnPrintReceipt.Size = New System.Drawing.Size(120, 38)
        Me.btnPrintReceipt.TabIndex = 3
        Me.btnPrintReceipt.Text = "طباعة الإيصال"
        '
        'btnClose
        '
        Me.btnClose.FillColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(140, 80)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 38)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "إغلاق"
        '
        'frmPayInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(600, 700)
        Me.Controls.Add(Me.pnlPaymentMethods)
        Me.Controls.Add(Me.dgvInvoiceDetails)
        Me.Controls.Add(Me.lblInvoiceTitle)
        Me.Name = "frmPayInvoice"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "دفع الفاتورة"
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPaymentMethods.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblInvoiceTitle As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceDetails As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents colIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProduct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlPaymentMethods As System.Windows.Forms.Panel
    Friend WithEvents btnCash As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCard As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSplit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPrintReceipt As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
End Class
