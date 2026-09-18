Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmSalesReport

    Private ReadOnly _repo As POSRepository

    Public Sub New()
        InitializeComponent()
        _repo = New POSRepository(DBModule.ConnectionString)
    End Sub

    Private Sub FrmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now

        cmbOrderType.Items.Clear()
        cmbOrderType.Items.AddRange(New Object() {"الكل", "تيك أوي", "صالة", "دليفري"})
        cmbOrderType.SelectedIndex = 0

        datagridviewsetup(dgvSales)
        SetupGrid()
        FilterSales()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub SetupGrid()
        dgvSales.Columns.Clear()
        dgvSales.AutoGenerateColumns = False
        dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSales.ReadOnly = True

        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colInvNum", .HeaderText = "رقم الفاتورة", .DataPropertyName = "InvoiceNumber", .Width = 130})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colDate", .HeaderText = "التاريخ والوقت", .DataPropertyName = "InvoiceDate", .Width = 140})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colType", .HeaderText = "نوع الطلب", .DataPropertyName = "OrderTypeName", .Width = 90})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colCustomer", .HeaderText = "العميل", .DataPropertyName = "CustomerName", .Width = 130})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTable", .HeaderText = "الطاولة", .DataPropertyName = "TableName", .Width = 80})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colDriver", .HeaderText = "الطيار", .DataPropertyName = "DriverName", .Width = 110})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colDeliveryFee", .HeaderText = "التوصيل", .DataPropertyName = "DeliveryFee", .Width = 80, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2"}})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNet", .HeaderText = "الصافي", .DataPropertyName = "NetTotal", .Width = 100, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2", .Font = New Font("Segoe UI", 9, FontStyle.Bold)}})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colPaid", .HeaderText = "المدفوع", .DataPropertyName = "PaidAmount", .Width = 90, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2"}})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colRemaining", .HeaderText = "المتبقي", .DataPropertyName = "RemainingAmount", .Width = 90, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2"}})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colPayType", .HeaderText = "الدفع", .DataPropertyName = "PaymentType", .Width = 80})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colShift", .HeaderText = "الوردية", .DataPropertyName = "ShiftNumber", .Width = 120})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colBranch", .HeaderText = "الفرع", .DataPropertyName = "BranchName", .Width = 110})
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colStore", .HeaderText = "المخزن", .DataPropertyName = "StoreName", .Width = 110})
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FilterSales()
    End Sub

    Private Sub FilterSales()
        Dim selectedType As Byte = CByte(cmbOrderType.SelectedIndex) ' 0 = الكل, 1 = تيك أوي, 2 = صالة, 3 = دليفري
        Dim dt As DataTable = _repo.GetSalesReport(dtpFrom.Value, dtpTo.Value, selectedType, 0)
        dgvSales.DataSource = dt

        ' تجميع المجاميع الكلية أسفل التقرير
        Dim sumNet As Decimal = 0
        Dim sumDiscount As Decimal = 0
        Dim sumPaid As Decimal = 0
        Dim sumRemaining As Decimal = 0

        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row("NetTotal")) Then sumNet += Convert.ToDecimal(row("NetTotal"))
            If dt.Columns.Contains("DiscountAmount") AndAlso Not IsDBNull(row("DiscountAmount")) Then
                sumDiscount += Convert.ToDecimal(row("DiscountAmount"))
            End If
            If Not IsDBNull(row("PaidAmount")) Then sumPaid += Convert.ToDecimal(row("PaidAmount"))
            If Not IsDBNull(row("RemainingAmount")) Then sumRemaining += Convert.ToDecimal(row("RemainingAmount"))
        Next

        lblTotalSalesSum.Text = sumNet.ToString("N2") & " ج"
        lblTotalDiscountSum.Text = sumDiscount.ToString("N2") & " ج"
        lblTotalPaidSum.Text = sumPaid.ToString("N2") & " ج"
        lblTotalRemainingSum.Text = sumRemaining.ToString("N2") & " ج"
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date

        cmbOrderType.SelectedIndex = 0

        datagridviewsetup(dgvSales)
        SetupGrid()
        FilterSales()
    End Sub
End Class