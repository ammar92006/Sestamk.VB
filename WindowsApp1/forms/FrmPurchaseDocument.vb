Public Class FrmPurchaseDocument
    Public Sub New()
        InitializeComponent()
        datagridviewsetup(invoiceGrid)
        Dim drag As New FormDragHelper(Me, panelHeader)
        AddHandler btnClose.Click, Sub() Close()
        AddHandler btnMax.Click, Sub() FormHelper.ToggleMaximize(Me)
        AddHandler btnMin.Click, Sub() FormHelper.Minimiz(Me)
        AddHandler btnPrint.Click, Sub() PurchaseDocumentHelper.RunSafely(Sub() PurchaseDocumentHelper.PrintGrid(invoiceGrid, invoiceSummary.Text))
        AddHandler btnExport.Click, Sub() PurchaseDocumentHelper.RunSafely(Sub() PurchaseDocumentHelper.ExportGrid(invoiceGrid, "فاتورة مشتريات", invoiceSummary.Text))
    End Sub

    Public Sub New(summary As String, items As DataTable)
        Me.New()
        invoiceSummary.Text = summary
        invoiceGrid.DataSource = items
    End Sub
End Class
