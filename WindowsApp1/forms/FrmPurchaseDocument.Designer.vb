<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPurchaseDocument
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(frmPurchases))
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.headerTitle = New System.Windows.Forms.Label()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMax = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMin = New DevExpress.XtraEditors.SimpleButton()
        Me.invoiceSummary = New System.Windows.Forms.Label()
        Me.invoiceGrid = New System.Windows.Forms.DataGridView()
        Me.actions = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPrint = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExport = New Guna.UI2.WinForms.Guna2Button()
        Me.borderless = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.SuspendLayout()
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Height = 70
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.panelHeader.Name = "panelHeader"
        Me.headerTitle.Text = "استعراض فاتورة المشتريات"
        Me.headerTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.headerTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.headerTitle.ForeColor = System.Drawing.Color.White
        Me.headerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnClose.Location = New System.Drawing.Point(15, 17)
        Me.btnClose.Size = New System.Drawing.Size(38, 36)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnClose.ImageOptions.SvgImage = CType(resources.GetObject("btnClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnMax.Location = New System.Drawing.Point(59, 17)
        Me.btnMax.Size = New System.Drawing.Size(38, 36)
        Me.btnMax.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnMax.ImageOptions.SvgImage = CType(resources.GetObject("btn_max.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnMin.Location = New System.Drawing.Point(103, 17)
        Me.btnMin.Size = New System.Drawing.Size(38, 36)
        Me.btnMin.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnMin.ImageOptions.SvgImage = CType(resources.GetObject("btn_min.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.panelHeader.Controls.AddRange(New System.Windows.Forms.Control() {Me.headerTitle, Me.btnClose, Me.btnMax, Me.btnMin})
        Me.headerTitle.SendToBack()
        Me.invoiceSummary.Dock = System.Windows.Forms.DockStyle.Top
        Me.invoiceSummary.Height = 155
        Me.invoiceSummary.Padding = New System.Windows.Forms.Padding(16)
        Me.invoiceSummary.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.invoiceSummary.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.invoiceSummary.BackColor = System.Drawing.Color.FromArgb(247, 248, 250)
        Me.invoiceGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.invoiceGrid.BackgroundColor = System.Drawing.Color.White
        Me.invoiceGrid.ReadOnly = True
        Me.invoiceGrid.AllowUserToAddRows = False
        Me.invoiceGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.actions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.actions.Height = 58
        Me.actions.Padding = New System.Windows.Forms.Padding(8)
        Me.actions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnPrint.Text = "طباعة الفاتورة"
        Me.btnPrint.Size = New System.Drawing.Size(180, 38)
        Me.btnPrint.BorderRadius = 6
        Me.btnPrint.FillColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnExport.Text = "تصدير Excel"
        Me.btnExport.Size = New System.Drawing.Size(180, 38)
        Me.btnExport.BorderRadius = 6
        Me.btnExport.FillColor = System.Drawing.Color.FromArgb(22, 160, 133)
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.actions.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrint, Me.btnExport})
        Me.borderless.ContainerControl = Me
        Me.borderless.BorderRadius = 8
        Me.borderless.DockIndicatorTransparencyValue = 0.6R
        Me.borderless.TransparentWhileDrag = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.invoiceGrid, Me.actions, Me.invoiceSummary, Me.panelHeader})
        Me.ClientSize = New System.Drawing.Size(1250, 760)
        Me.MinimumSize = New System.Drawing.Size(1000, 650)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Name = "FrmPurchaseDocument"
        Me.Text = "استعراض فاتورة المشتريات"
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents headerTitle As System.Windows.Forms.Label
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMax As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents invoiceSummary As System.Windows.Forms.Label
    Friend WithEvents invoiceGrid As System.Windows.Forms.DataGridView
    Friend WithEvents actions As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPrint As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExport As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents borderless As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
