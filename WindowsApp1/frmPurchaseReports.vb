Imports System.Data.SqlClient

Public Class frmPurchaseReports
    Public Property ShowSupplierBalances As Boolean
    Private reportsReady As Boolean


    Private Sub frmPurchaseReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ضبط التواريخ: من أول يوم في الشهر الحالي حتى اليوم
        dtpFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpTo.Value = DateTime.Now

        AddHandler balancesMode.CheckedChanged, Sub()
                                                   ShowSupplierBalances = balancesMode.Checked
                                                   Label13.Text = If(balancesMode.Checked, "عدد الموردين", "عدد الفواتير")
                                                   Label12.Text = If(balancesMode.Checked, "صافي أرصدة الموردين", "إجمالي المتبقي")
                                                   Label9.Text = If(balancesMode.Checked, "إجمالي الأرصدة الافتتاحية", "إجمالي الفاتورة بعد الخصم")
                                                   Label8.Text = If(balancesMode.Checked, "فروق تاريخية غير مسجلة", "إجمالي الخصم")
                                                   dtpFrom.Enabled = Not balancesMode.Checked
                                                   dtpTo.Enabled = Not balancesMode.Checked
                                                   cmbStore.Enabled = Not balancesMode.Checked
                                                   cmbPaymentType.Enabled = Not balancesMode.Checked
                                                   rbInvoicesSummary.Enabled = Not balancesMode.Checked
                                                   rbItemsDetails.Enabled = Not balancesMode.Checked
                                                   cmbMaterial.Enabled = Not balancesMode.Checked AndAlso rbItemsDetails.Checked
                                                   LoadReport()
                                               End Sub
        AddHandler btnPrintReport.Click, Sub() PurchaseDocumentHelper.RunSafely(Sub() PurchaseDocumentHelper.PrintGrid(dgvReport, If(balancesMode.Checked, "أرصدة الموردين الحالية", "تقرير المشتريات من " & dtpFrom.Value.ToString("yyyy-MM-dd") & " إلى " & dtpTo.Value.ToString("yyyy-MM-dd"))))
        AddHandler btnExportReport.Click, Sub() PurchaseDocumentHelper.RunSafely(Sub() PurchaseDocumentHelper.ExportGrid(dgvReport, "تقرير الموردين والمشتريات"))
        AddHandler btnViewPurchase.Click, Sub() PurchaseDocumentHelper.RunSafely(Sub()
                                                                        If Not balancesMode.Checked AndAlso rbInvoicesSummary.Checked AndAlso dgvReport.CurrentRow IsNot Nothing Then
                                                                            PurchaseDocumentHelper.ShowInvoice(Me, CInt(dgvReport.CurrentRow.Cells("PurchaseID").Value))
                                                                        Else
                                                                            MessageBox.Show("اختر فاتورة من تقرير إجمالي الفواتير.")
                                                                        End If
                                                                    End Sub)
        FillFilterDropdowns()
        rbInvoicesSummary.Checked = True

        ' تنسيق الجدول
        datagridviewsetup(dgvReport)

        ' تشغيل البحث الأولي
        reportsReady = True
        balancesMode.Checked = ShowSupplierBalances
        LoadReport()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ''' <summary>
    ''' تعبئة القوائم المنسدلة وإضافة خيار [الكل] في البداية
    ''' </summary>
    Private Sub FillFilterDropdowns()
        Try
            ' 1. الموردين
            Dim dtSuppliers As DataTable = DBModule.ExecuteQuery("SELECT SupplierID, SupplierName FROM Suppliers WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY SupplierName ASC")
            Dim drSup As DataRow = dtSuppliers.NewRow()
            drSup("SupplierID") = 0
            drSup("SupplierName") = "--- كل الموردين ---"
            dtSuppliers.Rows.InsertAt(drSup, 0)
            cmbSupplier.DataSource = dtSuppliers
            cmbSupplier.DisplayMember = "SupplierName"
            cmbSupplier.ValueMember = "SupplierID"
            cmbSupplier.SelectedIndex = 0

            ' 2. المخازن
            Dim dtStores As DataTable = DBModule.ExecuteQuery("SELECT StoreID, StoreName FROM Stores ORDER BY StoreName ASC")
            Dim drStore As DataRow = dtStores.NewRow()
            drStore("StoreID") = 0
            drStore("StoreName") = "--- كل المخازن ---"
            dtStores.Rows.InsertAt(drStore, 0)
            cmbStore.DataSource = dtStores
            cmbStore.DisplayMember = "StoreName"
            cmbStore.ValueMember = "StoreID"
            cmbStore.SelectedIndex = 0

            ' 3. الخامات
            Dim dtMaterials As DataTable = DBModule.ExecuteQuery("SELECT MaterialID, MaterialName FROM RawMaterials ORDER BY MaterialName ASC")
            Dim drMat As DataRow = dtMaterials.NewRow()
            drMat("MaterialID") = 0
            drMat("MaterialName") = "--- كل الخامات ---"
            dtMaterials.Rows.InsertAt(drMat, 0)
            cmbMaterial.DataSource = dtMaterials
            cmbMaterial.DisplayMember = "MaterialName"
            cmbMaterial.ValueMember = "MaterialID"
            cmbMaterial.SelectedIndex = 0

            ' 4. طرق السداد
            cmbPaymentType.Items.Clear()
            cmbPaymentType.Items.Add("--- كل طرق الدفع ---")
            cmbPaymentType.Items.Add("CASH")
            cmbPaymentType.Items.Add("CREDIT")
            cmbPaymentType.Items.Add("PARTIAL")
            cmbPaymentType.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("خطأ في جلب بيانات الفلاتر: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' جلب وتحميل التقرير بناءً على نوع العرض والفلاتر المحددة
    ''' </summary>
    Private Sub LoadReport()
        If Not reportsReady Then Return
        Try
            If balancesMode.Checked Then
                Dim supplierID As Integer = 0
                If cmbSupplier.SelectedValue IsNot Nothing Then Integer.TryParse(cmbSupplier.SelectedValue.ToString(), supplierID)
                Dim balances = SupplierAccountingService.GetBalances(supplierID, txtSearch.Text.Trim())
                dgvReport.DataSource = balances
                For Each name As String In {"الرصيد الافتتاحي", "المشتريات", "المسدد", "الرصيد الحالي", "فرق تاريخي غير مسجل"}
                    dgvReport.Columns(name).DefaultCellStyle.Format = "N2"
                Next
                lblTotalAmount.Text = balances.AsEnumerable().Sum(Function(r) CDec(r("المشتريات"))).ToString("N2")
                lblNetTotal.Text = balances.AsEnumerable().Sum(Function(r) CDec(r("الرصيد الافتتاحي"))).ToString("N2")
                lblTotalDiscount.Text = balances.AsEnumerable().Sum(Function(r) CDec(r("فرق تاريخي غير مسجل"))).ToString("N2")
                lblTotalPaid.Text = balances.AsEnumerable().Sum(Function(r) CDec(r("المسدد"))).ToString("N2")
                lblTotalRemaining.Text = balances.AsEnumerable().Sum(Function(r) CDec(r("الرصيد الحالي"))).ToString("N2")
                lblInvoiceCount.Text = balances.Rows.Count.ToString()
                Return
            End If
            If dtpFrom.Value.Date > dtpTo.Value.Date Then Throw New ArgumentException("راجع ترتيب تاريخ البداية والنهاية.")
            Dim fromDate As DateTime = dtpFrom.Value.Date
            Dim toDate As DateTime = dtpTo.Value.Date.AddDays(1) ' لنهاية اليوم المختار

            Dim supID As Integer = If(cmbSupplier.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbSupplier.SelectedValue.ToString(), Nothing), Convert.ToInt32(cmbSupplier.SelectedValue), 0)
            Dim storeID As Integer = If(cmbStore.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbStore.SelectedValue.ToString(), Nothing), Convert.ToInt32(cmbStore.SelectedValue), 0)
            Dim matID As Integer = If(cmbMaterial.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbMaterial.SelectedValue.ToString(), Nothing), Convert.ToInt32(cmbMaterial.SelectedValue), 0)
            Dim payType As String = If(cmbPaymentType.SelectedIndex > 0, cmbPaymentType.SelectedItem.ToString(), "")
            Dim searchTxt As String = txtSearch.Text.Trim()

            Dim dtResult As New DataTable()

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand()
                    cmd.Connection = conn

                    ' إضافة الباراميترات الثابتة
                    cmd.Parameters.AddWithValue("@FromDate", fromDate)
                    cmd.Parameters.AddWithValue("@ToDate", toDate)

                    ' تقرير 1: إجمالي الفواتير
                    If rbInvoicesSummary.Checked Then
                        Dim sql As String = "SELECT H.PurchaseID, H.InvoiceNumber, H.PurchaseDate, " &
                                            "       S.SupplierName, ISNULL(B.BranchName, '---') AS BranchName, ST.StoreName, " &
                                            "       H.TotalAmount, H.Discount, H.NetTotal, H.PaidAmount, H.RemainingAmount, " &
                                            "       H.PaymentType, ISNULL(T.TreasuryNameAr, '---') AS TreasuryName, H.Notes " &
                                            "FROM PurchaseHeaders H " &
                                            "INNER JOIN Suppliers S ON H.SupplierID = S.SupplierID " &
                                            "INNER JOIN Stores ST ON H.StoreID = ST.StoreID " &
                                            "LEFT JOIN Branches B ON H.BranchID = B.BranchID " &
                                            "LEFT JOIN Treasury T ON H.TreasuryID = T.TreasuryID " &
                                            "WHERE ISNULL(H.IsDeleted,0)=0 AND H.PurchaseDate >= @FromDate AND H.PurchaseDate < @ToDate "

                        If supID > 0 Then
                            sql &= " AND H.SupplierID = @SupID "
                            cmd.Parameters.AddWithValue("@SupID", supID)
                        End If

                        If storeID > 0 Then
                            sql &= " AND H.StoreID = @StoreID "
                            cmd.Parameters.AddWithValue("@StoreID", storeID)
                        End If

                        If Not String.IsNullOrEmpty(payType) Then
                            sql &= " AND H.PaymentType = @PayType "
                            cmd.Parameters.AddWithValue("@PayType", payType)
                        End If

                        If Not String.IsNullOrEmpty(searchTxt) Then
                            sql &= " AND (H.InvoiceNumber LIKE @Search OR S.SupplierName LIKE @Search OR H.Notes LIKE @Search OR B.BranchName LIKE @Search) "
                            cmd.Parameters.AddWithValue("@Search", "%" & searchTxt & "%")
                        End If

                        sql &= " ORDER BY H.PurchaseDate DESC, H.PurchaseID DESC"
                        cmd.CommandText = sql

                        ' تقرير 2: تفصيلي بالخامات والأصناف
                    Else
                        Dim sql As String = "SELECT D.DetailID, H.InvoiceNumber, H.PurchaseDate, S.SupplierName, ISNULL(B.BranchName, '---') AS BranchName, ST.StoreName, " &
                                            "       M.MaterialName, U.UnitName, D.Quantity, D.ConversionFactor, " &
                                            "       D.Quantity*D.ConversionFactor AS ActualBaseQuantity, D.UnitPrice, D.BaseUnitCost, D.Quantity*D.UnitPrice AS TotalPrice " &
                                            "FROM PurchaseDetails D " &
                                            "INNER JOIN PurchaseHeaders H ON D.PurchaseID = H.PurchaseID " &
                                            "INNER JOIN RawMaterials M ON D.MaterialID = M.MaterialID " &
                                            "INNER JOIN Units U ON D.UnitID = U.UnitID " &
                                            "INNER JOIN Suppliers S ON H.SupplierID = S.SupplierID " &
                                            "INNER JOIN Stores ST ON H.StoreID = ST.StoreID " &
                                            "LEFT JOIN Branches B ON H.BranchID = B.BranchID " &
                                            "WHERE ISNULL(H.IsDeleted,0)=0 AND H.PurchaseDate >= @FromDate AND H.PurchaseDate < @ToDate "

                        If supID > 0 Then
                            sql &= " AND H.SupplierID = @SupID "
                            cmd.Parameters.AddWithValue("@SupID", supID)
                        End If

                        If storeID > 0 Then
                            sql &= " AND H.StoreID = @StoreID "
                            cmd.Parameters.AddWithValue("@StoreID", storeID)
                        End If

                        If matID > 0 Then
                            sql &= " AND D.MaterialID = @MatID "
                            cmd.Parameters.AddWithValue("@MatID", matID)
                        End If

                        If Not String.IsNullOrEmpty(payType) Then
                            sql &= " AND H.PaymentType = @PayType "
                            cmd.Parameters.AddWithValue("@PayType", payType)
                        End If

                        If Not String.IsNullOrEmpty(searchTxt) Then
                            sql &= " AND (H.InvoiceNumber LIKE @Search OR S.SupplierName LIKE @Search OR M.MaterialName LIKE @Search OR B.BranchName LIKE @Search) "
                            cmd.Parameters.AddWithValue("@Search", "%" & searchTxt & "%")
                        End If

                        sql &= " ORDER BY H.PurchaseDate DESC, D.DetailID DESC"
                        cmd.CommandText = sql
                    End If

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dtResult)
                    End Using
                End Using
            End Using

            dgvReport.DataSource = dtResult
            FormatReportGrid()
            CalculateReportTotals(dtResult)

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء استخراج التقرير: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' تنسيق وترتيب أعمدة الجدول بحسب نوع التقرير المعروض
    ''' </summary>
    Private Sub FormatReportGrid()
        If dgvReport.Columns.Count = 0 Then Exit Sub

        If rbInvoicesSummary.Checked Then
            If dgvReport.Columns.Contains("PurchaseID") Then dgvReport.Columns("PurchaseID").Visible = False

            dgvReport.Columns("InvoiceNumber").HeaderText = "رقم الفاتورة"
            dgvReport.Columns("PurchaseDate").HeaderText = "تاريخ الشراء"
            dgvReport.Columns("SupplierName").HeaderText = "المورد"
            If dgvReport.Columns.Contains("BranchName") Then dgvReport.Columns("BranchName").HeaderText = "الفرع"
            dgvReport.Columns("StoreName").HeaderText = "المخزن"
            dgvReport.Columns("TotalAmount").HeaderText = "الإجمالي"
            dgvReport.Columns("Discount").HeaderText = "الخصم"
            dgvReport.Columns("NetTotal").HeaderText = "الصافي"
            dgvReport.Columns("PaidAmount").HeaderText = "المدفوع"
            dgvReport.Columns("RemainingAmount").HeaderText = "المتبقي (آجل)"
            dgvReport.Columns("PaymentType").HeaderText = "طريقة الدفع"
            dgvReport.Columns("TreasuryName").HeaderText = "الخزينة"
            dgvReport.Columns("Notes").HeaderText = "ملاحظات"

            ' تنسيقات
            dgvReport.Columns("PurchaseDate").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
            dgvReport.Columns("TotalAmount").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("Discount").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("NetTotal").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("PaidAmount").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("RemainingAmount").DefaultCellStyle.Format = "N2"

            ' ترتيب من اليمين لليسار (RTL) - تقرير الفواتير
            dgvReport.Columns("InvoiceNumber").DisplayIndex = 0    ' رقم الفاتورة   ← أقصى اليمين
            dgvReport.Columns("PurchaseDate").DisplayIndex = 1     ' تاريخ الشراء
            dgvReport.Columns("SupplierName").DisplayIndex = 2     ' المورد
            Dim colIdx As Integer = 3
            If dgvReport.Columns.Contains("BranchName") Then
                dgvReport.Columns("BranchName").DisplayIndex = colIdx
                colIdx += 1
            End If
            dgvReport.Columns("StoreName").DisplayIndex = colIdx
            colIdx += 1
            dgvReport.Columns("TotalAmount").DisplayIndex = colIdx
            colIdx += 1
            dgvReport.Columns("Discount").DisplayIndex = colIdx
            colIdx += 1
            dgvReport.Columns("NetTotal").DisplayIndex = colIdx
            colIdx += 1
            dgvReport.Columns("PaidAmount").DisplayIndex = colIdx
            colIdx += 1
            dgvReport.Columns("RemainingAmount").DisplayIndex = colIdx
            colIdx += 1
            dgvReport.Columns("PaymentType").DisplayIndex = colIdx
            colIdx += 1
            dgvReport.Columns("TreasuryName").DisplayIndex = colIdx
            colIdx += 1
            dgvReport.Columns("Notes").DisplayIndex = colIdx           ' ملاحظات        ← أقصى اليسار

        Else
            If dgvReport.Columns.Contains("DetailID") Then dgvReport.Columns("DetailID").Visible = False

            dgvReport.Columns("InvoiceNumber").HeaderText = "رقم الفاتورة"
            dgvReport.Columns("PurchaseDate").HeaderText = "التاريخ"
            dgvReport.Columns("SupplierName").HeaderText = "المورد"
            If dgvReport.Columns.Contains("BranchName") Then dgvReport.Columns("BranchName").HeaderText = "الفرع"
            dgvReport.Columns("StoreName").HeaderText = "المخزن"
            dgvReport.Columns("MaterialName").HeaderText = "الخامة"
            dgvReport.Columns("UnitName").HeaderText = "الوحدة"
            dgvReport.Columns("Quantity").HeaderText = "الكمية المشتراة"
            dgvReport.Columns("ConversionFactor").HeaderText = "معامل التحويل"
            dgvReport.Columns("ActualBaseQuantity").HeaderText = "الوارد الفعلي بالمخزن"
            dgvReport.Columns("UnitPrice").HeaderText = "سعر الوحدة"
            dgvReport.Columns("BaseUnitCost").HeaderText = "تكلفة الوحدة الأساسية"
            dgvReport.Columns("TotalPrice").HeaderText = "إجمالي السطر"

            ' تنسيقات
            dgvReport.Columns("PurchaseDate").DefaultCellStyle.Format = "yyyy-MM-dd"
            dgvReport.Columns("Quantity").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("ConversionFactor").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("ActualBaseQuantity").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("UnitPrice").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("BaseUnitCost").DefaultCellStyle.Format = "N4"
            dgvReport.Columns("TotalPrice").DefaultCellStyle.Format = "N2"

            ' ترتيب من اليمين لليسار (RTL) - تقرير التفاصيل
            dgvReport.Columns("InvoiceNumber").DisplayIndex = 0         ' رقم الفاتورة          ← أقصى اليمين
            dgvReport.Columns("PurchaseDate").DisplayIndex = 1          ' التاريخ
            dgvReport.Columns("SupplierName").DisplayIndex = 2          ' المورد
            Dim colIdx2 As Integer = 3
            If dgvReport.Columns.Contains("BranchName") Then
                dgvReport.Columns("BranchName").DisplayIndex = colIdx2
                colIdx2 += 1
            End If
            dgvReport.Columns("StoreName").DisplayIndex = colIdx2
            colIdx2 += 1
            dgvReport.Columns("MaterialName").DisplayIndex = colIdx2
            colIdx2 += 1
            dgvReport.Columns("UnitName").DisplayIndex = colIdx2
            colIdx2 += 1
            dgvReport.Columns("Quantity").DisplayIndex = colIdx2
            colIdx2 += 1
            dgvReport.Columns("ConversionFactor").DisplayIndex = colIdx2
            colIdx2 += 1
            dgvReport.Columns("ActualBaseQuantity").DisplayIndex = colIdx2
            colIdx2 += 1
            dgvReport.Columns("UnitPrice").DisplayIndex = colIdx2
            colIdx2 += 1
            dgvReport.Columns("BaseUnitCost").DisplayIndex = colIdx2
            colIdx2 += 1
            dgvReport.Columns("TotalPrice").DisplayIndex = colIdx2           ' إجمالي السطر          ← أقصى اليسار
        End If
    End Sub

    ''' <summary>
    ''' احتساب الإجماليات السريعة وتحديث الـ KPI Cards في أسفل الشاشة
    ''' </summary>
    Private Sub CalculateReportTotals(dt As DataTable)
        Dim totalAmount As Decimal = 0
        Dim discount As Decimal = 0
        Dim netTotal As Decimal = 0
        Dim paid As Decimal = 0
        Dim remaining As Decimal = 0
        Dim count As Integer = 0

        If rbInvoicesSummary.Checked Then
            count = dt.Rows.Count
            For Each row As DataRow In dt.Rows
                totalAmount += Convert.ToDecimal(row("TotalAmount"))
                discount += Convert.ToDecimal(row("Discount"))
                netTotal += Convert.ToDecimal(row("NetTotal"))
                paid += Convert.ToDecimal(row("PaidAmount"))
                remaining += Convert.ToDecimal(row("RemainingAmount"))
            Next
        Else
            ' في حالة تقرير التفاصيل
            For Each row As DataRow In dt.Rows
                totalAmount += Convert.ToDecimal(row("TotalPrice"))
            Next
            netTotal = totalAmount
            count = dt.Rows.Count
        End If

        ' تحديث الـ Labels في الواجهة
        lblTotalAmount.Text = totalAmount.ToString("N2") & " ج"
        lblTotalDiscount.Text = discount.ToString("N2") & " ج"
        lblNetTotal.Text = netTotal.ToString("N2") & " ج"
        lblTotalPaid.Text = paid.ToString("N2") & " ج"
        lblTotalRemaining.Text = remaining.ToString("N2") & " ج"
        lblInvoiceCount.Text = count.ToString()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub

    Private Sub rbReportType_CheckedChanged(sender As Object, e As EventArgs) Handles rbInvoicesSummary.CheckedChanged, rbItemsDetails.CheckedChanged
        ' تفعيل فلتر الخامة فقط عند اختيار تقرير تفاصيل الأصناف
        cmbMaterial.Enabled = rbItemsDetails.Checked
        If rbInvoicesSummary.Checked Then cmbMaterial.SelectedIndex = 0
        LoadReport()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        balancesMode.Checked = False
        dtpFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpTo.Value = DateTime.Now
        cmbSupplier.SelectedIndex = 0
        cmbStore.SelectedIndex = 0
        cmbMaterial.SelectedIndex = 0
        cmbPaymentType.SelectedIndex = 0
        txtSearch.Clear()
        rbInvoicesSummary.Checked = True
        LoadReport()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadReport()
            e.SuppressKeyPress = True
        End If
    End Sub

    ''' <summary>
    ''' عند الضغط مرتين على فاتورة في تقرير الإجماليات، يمكن عرض أصنافها فوراً
    ''' </summary>
    Private Sub dgvReport_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellDoubleClick
        If e.RowIndex >= 0 AndAlso rbInvoicesSummary.Checked AndAlso Not balancesMode.Checked Then
            Dim invNumber As String = dgvReport.Rows(e.RowIndex).Cells("InvoiceNumber").Value.ToString()
            txtSearch.Text = invNumber
            rbItemsDetails.Checked = True ' الانتقال لتقرير تفاصيل هذه الفاتورة
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub
End Class