<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LowStockProducts
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
        Me.pnlNotifications = New System.Windows.Forms.Panel()
        Me.DGV_LowStock = New System.Windows.Forms.DataGridView()
        Me.pnlNotifications.SuspendLayout()
        CType(Me.DGV_LowStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlNotifications
        '
        Me.pnlNotifications.AutoScroll = True
        Me.pnlNotifications.BackColor = System.Drawing.Color.White
        Me.pnlNotifications.Controls.Add(Me.DGV_LowStock)
        Me.pnlNotifications.Location = New System.Drawing.Point(75, 69)
        Me.pnlNotifications.Name = "pnlNotifications"
        Me.pnlNotifications.Size = New System.Drawing.Size(200, 100)
        Me.pnlNotifications.TabIndex = 0
        '
        'DGV_LowStock
        '
        Me.DGV_LowStock.AllowUserToAddRows = False
        Me.DGV_LowStock.AllowUserToDeleteRows = False
        Me.DGV_LowStock.AllowUserToResizeColumns = False
        Me.DGV_LowStock.AllowUserToResizeRows = False
        Me.DGV_LowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_LowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_LowStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_LowStock.Location = New System.Drawing.Point(0, 0)
        Me.DGV_LowStock.Name = "DGV_LowStock"
        Me.DGV_LowStock.ReadOnly = True
        Me.DGV_LowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_LowStock.Size = New System.Drawing.Size(200, 100)
        Me.DGV_LowStock.TabIndex = 0
        '
        'frm_LowStockProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 450)
        Me.Controls.Add(Me.pnlNotifications)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_LowStockProducts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frm_LowStockProducts"
        Me.pnlNotifications.ResumeLayout(False)
        CType(Me.DGV_LowStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlNotifications As Panel
    Friend WithEvents DGV_LowStock As DataGridView
End Class
