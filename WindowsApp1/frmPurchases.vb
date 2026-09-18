Imports System.Data.SqlClient

Public Class frmPurchases
    Private _dtItems As New DataTable()
    Private defaultTreasuryid As Integer

    Private Sub frmPurchases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitItemsTable()
        FillDropdowns()
        txtInvoiceNumber.Text = GetNextCode("PurchaseHeaders", "InvoiceNumber")
        dtpInvoiceDate.Value = DateTime.Now

        ' تعبئة طرق الدفع
        cmbPaymentType.Items.Clear()
        cmbPaymentType.Items.Add("نقدي")     ' CASH
        cmbPaymentType.Items.Add("آجل")      ' CREDIT
        cmbPaymentType.Items.Add("جزئي")     ' PARTIAL
        cmbPaymentType.SelectedIndex = 0     ' افتراضي: نقدي
        ApplyPaymentTypeUI()

        ' حقول الأرصدة والمبالغ للقراءة فقط
        txtDebit.ReadOnly = True
        txtCredit.ReadOnly = True
        txtDebit.Text = "0.00"
        txtCredit.Text = "0.00"
        txtTotalAmount.ReadOnly = True
        txtNetTotal.ReadOnly = True
        txtRemainingAmount.ReadOnly = True

        ' قراءة الفرع الحالي المحفوظ
        Dim defaultBranchID = If(SettingsManager.GetSetting("CurrentBranchID"), "")
        If Not String.IsNullOrEmpty(defaultBranchID) Then
            cmbBranches.SelectedValue = Convert.ToInt32(defaultBranchID)
        End If

        ' قراءة المخزن الحالي المحفوظ
        Dim defaultStoreID = If(SettingsManager.GetSetting("CurrentStoreID"), "")
        If Not String.IsNullOrEmpty(defaultStoreID) Then
            cmbStore.SelectedValue = Convert.ToInt32(defaultStoreID)
        End If

        datagridviewsetup(dgvInvoiceItems)

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ''' <summary>
    ''' تحديث واجهة الدفع بحسب الحالة المختارة
    ''' CASH   → المدفوع + الخزينة ظاهران  | المتبقي مخفي
    ''' CREDIT → المتبقي ظاهر              | المدفوع + الخزينة مخفيان
    ''' PARTIAL→ الكل ظاهر
    ''' </summary>
    Private Sub ApplyPaymentTypeUI()
        Select Case cmbPaymentType.SelectedIndex
            Case 0 ' نقدي - CASH
                ' المدفوع + الخزينة ظاهران | المتبقي مخفي
                txtPaidAmount.Visible = True
                lblPaidAmount.Visible = True
                cmbTreasury.Visible = True
                lblTreasury.Visible = True
                txtRemainingAmount.Visible = True
                lblRemainingAmount.Visible = True
                ' المدفوع = الإجمالي الصافي تلقائياً، المتبقي = صفر
                txtPaidAmount.Text = txtNetTotal.Text
                txtRemainingAmount.Text = "0.00"

            Case 1 ' آجل - CREDIT
                ' المتبقي ظاهر | المدفوع + الخزينة مخفيان
                txtPaidAmount.Visible = False
                lblPaidAmount.Visible = False
                cmbTreasury.Visible = False
                lblTreasury.Visible = False
                txtRemainingAmount.Visible = True
                lblRemainingAmount.Visible = True
                ' المدفوع = صفر، المتبقي = كامل الصافي
                txtPaidAmount.Text = "0.00"
                txtRemainingAmount.Text = txtNetTotal.Text
                cmbTreasury.SelectedIndex = -1

            Case 2 ' جزئي - PARTIAL
                ' الكل ظاهر
                txtPaidAmount.Visible = True
                lblPaidAmount.Visible = True
                cmbTreasury.Visible = True
                lblTreasury.Visible = True
                txtRemainingAmount.Visible = True
                lblRemainingAmount.Visible = True
                txtPaidAmount.Text = "0.00"
                CalculateTotals()
        End Select
    End Sub

    Private Sub cmbPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaymentType.SelectedIndexChanged
        ApplyPaymentTypeUI()
    End Sub

    Private Sub InitItemsTable()
        '_dtItems.Columns.Clear()
        '_dtItems.Columns.Add("MaterialID", GetType(Integer))
        '_dtItems.Columns.Add("MaterialName", GetType(String))
        '_dtItems.Columns.Add("UnitID", GetType(Integer))
        '_dtItems.Columns.Add("UnitName", GetType(String))
        '_dtItems.Columns.Add("ConversionFactor", GetType(Decimal))
        '_dtItems.Columns.Add("Quantity", GetType(Decimal))
        '_dtItems.Columns.Add("BaseQuantity", GetType(Decimal))
        '_dtItems.Columns.Add("UnitPrice", GetType(Decimal))
        '_dtItems.Columns.Add("TotalPrice", GetType(Decimal))

        _dtItems.Columns.Clear()
        _dtItems.Columns.Add("MaterialID", GetType(Integer))
        _dtItems.Columns.Add("MaterialName", GetType(String))
        _dtItems.Columns.Add("UnitID", GetType(Integer))
        _dtItems.Columns.Add("UnitName", GetType(String))
        _dtItems.Columns.Add("ConversionFactor", GetType(Decimal))
        _dtItems.Columns.Add("Quantity", GetType(Decimal))
        _dtItems.Columns.Add("BaseQuantity", GetType(Decimal))
        _dtItems.Columns.Add("UnitPrice", GetType(Decimal))
        _dtItems.Columns.Add("TotalPrice", GetType(Decimal))

        dgvInvoiceItems.DataSource = _dtItems

        ' إخفاء الأعمدة غير الضرورية للعرض
        dgvInvoiceItems.Columns("MaterialID").Visible = False
        dgvInvoiceItems.Columns("UnitID").Visible = False
        dgvInvoiceItems.Columns("ConversionFactor").Visible = False

        ' تسميات الأعمدة بالعربي
        dgvInvoiceItems.Columns("MaterialName").HeaderText = "الخامة"
        dgvInvoiceItems.Columns("UnitName").HeaderText = "الوحدة"
        dgvInvoiceItems.Columns("Quantity").HeaderText = "الكمية"
        dgvInvoiceItems.Columns("BaseQuantity").HeaderText = "الوارد الفعلي بالمخزن"
        dgvInvoiceItems.Columns("UnitPrice").HeaderText = "السعر"
        dgvInvoiceItems.Columns("TotalPrice").HeaderText = "الإجمالي"

        ' ترتيب العرض من اليمين لليسار (RTL) - مع RightToLeft=Yes
        ' DisplayIndex=0 → أقصى اليمين ، DisplayIndex=5 → أقصى اليسار
        dgvInvoiceItems.Columns("MaterialName").DisplayIndex = 0   ' الخامة        ← أقصى اليمين
        dgvInvoiceItems.Columns("UnitName").DisplayIndex = 1       ' الوحدة
        dgvInvoiceItems.Columns("Quantity").DisplayIndex = 2       ' الكمية
        dgvInvoiceItems.Columns("BaseQuantity").DisplayIndex = 3   ' الوارد الفعلي
        dgvInvoiceItems.Columns("UnitPrice").DisplayIndex = 4      ' السعر
        dgvInvoiceItems.Columns("TotalPrice").DisplayIndex = 5     ' الإجمالي      ← أقصى اليسار
    End Sub

    Private Sub FillDropdowns()
        ' 1. الموردين
        Dim dtSuppliers As DataTable = DBModule.ExecuteQuery("SELECT SupplierID, SupplierName FROM Suppliers WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL)")
        cmbSupplier.DataSource = dtSuppliers
        cmbSupplier.DisplayMember = "SupplierName"
        cmbSupplier.ValueMember = "SupplierID"
        cmbSupplier.SelectedIndex = -1

        ' 2. المخازن
        Dim dtStores As DataTable = DBModule.ExecuteQuery("SELECT StoreID, StoreName FROM Stores")
        cmbStore.DataSource = dtStores
        cmbStore.DisplayMember = "StoreName"
        cmbStore.ValueMember = "StoreID"
        cmbStore.SelectedIndex = If(dtStores.Rows.Count > 0, 0, -1)

        ' 3. الخامات
        Dim dtMaterials As DataTable = DBModule.ExecuteQuery("SELECT MaterialID, MaterialName FROM RawMaterials WHERE IsActive = 1")
        cmbMaterial.DataSource = dtMaterials
        cmbMaterial.DisplayMember = "MaterialName"
        cmbMaterial.ValueMember = "MaterialID"
        cmbMaterial.SelectedIndex = -1

        ' 4. الخزائن
        Dim dtTreasuries As DataTable = DBModule.ExecuteQuery("SELECT TreasuryID, TreasuryNameAr FROM Treasury WHERE IsActive = 1 AND IsDeleted = 0")
        cmbTreasury.DataSource = dtTreasuries
        cmbTreasury.DisplayMember = "TreasuryNameAr"
        cmbTreasury.ValueMember = "TreasuryID"

        defaultTreasuryid = If(SettingsManager.GetSetting("defaultTreasuryid"), -1)
        cmbTreasury.SelectedIndex = defaultTreasuryid
        ' 5. الفروع
        Dim dtBranches As DataTable = DBModule.ExecuteQuery("SELECT BranchID, BranchName FROM Branches WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY BranchName;")
        cmbBranches.DataSource = dtBranches
        cmbBranches.DisplayMember = "BranchName"
        cmbBranches.ValueMember = "BranchID"


    End Sub

    ' عند اختيار الخامة، يتم جلب كل الوحدات المتاحة لها (الأساسية + وحدات التحويل)
    'Private Sub cmbMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaterial.SelectedIndexChanged
    '    If cmbMaterial.SelectedValue IsNot Nothing AndAlso TypeOf cmbMaterial.SelectedValue Is Integer Then
    '        Dim matID As Integer = Convert.ToInt32(cmbMaterial.SelectedValue)

    '        Dim query As String = "SELECT U.UnitID, U.UnitName, 1.0000 AS ConversionFactor " &
    '                              "FROM RawMaterials R INNER JOIN Units U ON R.UnitID = U.UnitID WHERE R.MaterialID = " & matID & " " &
    '                              "UNION " &
    '                              "SELECT MU.UnitID, U.UnitName, MU.ConversionFactor " &
    '                              "FROM MaterialUnits MU INNER JOIN Units U ON MU.UnitID = U.UnitID WHERE MU.MaterialID = " & matID

    '        Dim dtUnits As DataTable = DBModule.ExecuteQuery(query)
    '        cmbUnit.DataSource = dtUnits
    '        cmbUnit.DisplayMember = "UnitName"
    '        cmbUnit.ValueMember = "UnitID"
    '        cmbUnit.SelectedIndex = If(dtUnits.Rows.Count > 0, 0, -1)
    '    Else
    '        cmbUnit.DataSource = Nothing
    '    End If
    'End Sub

    Private Sub cmbMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaterial.SelectedIndexChanged
        If cmbMaterial.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbMaterial.SelectedValue.ToString(), Nothing) Then
            Dim matID As Integer = Convert.ToInt32(cmbMaterial.SelectedValue)

            ' جلب الوحدة الأساسية مع سعر تكلفتها + وحدات التحويل مع سعر شرائها
            Dim query As String = "SELECT U.UnitID, U.UnitName, CAST(1.0000 AS DECIMAL(18, 4)) AS ConversionFactor, " &
                              "       ISNULL(R.CostPrice, 0.00) AS PurchasePrice " &
                              "FROM RawMaterials R " &
                              "INNER JOIN Units U ON R.UnitID = U.UnitID WHERE R.MaterialID = @MatID " &
                              "UNION ALL " &
                              "SELECT MU.UnitID, U.UnitName, MU.ConversionFactor, " &
                              "       ISNULL(MU.PurchasePrice, 0.00) AS PurchasePrice " &
                              "FROM MaterialUnits MU " &
                              "INNER JOIN Units U ON MU.UnitID = U.UnitID WHERE MU.MaterialID = @MatID " &
                              "ORDER BY ConversionFactor ASC"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@MatID", matID)
                    Dim dtUnits As New DataTable()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dtUnits)
                    End Using

                    cmbUnit.DataSource = dtUnits
                    cmbUnit.DisplayMember = "UnitName"
                    cmbUnit.ValueMember = "UnitID"

                    ' تحديد أول وحدة أو تفريغ الاختيار
                    If dtUnits.Rows.Count > 0 Then
                        cmbUnit.SelectedIndex = 0
                    Else
                        cmbUnit.SelectedIndex = -1
                        txtPrice.Text = "0.00"
                    End If
                End Using
            End Using
        Else
            cmbUnit.DataSource = Nothing
            txtPrice.Text = "0.00"
        End If
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If cmbMaterial.SelectedIndex = -1 OrElse cmbUnit.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار الخامة والوحدة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim qty As Decimal = 0, price As Decimal = 0
        If Not Decimal.TryParse(txtQuantity.Text.Trim(), qty) OrElse qty <= 0 Then
            MessageBox.Show("يرجى إدخال كمية صحيحة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not Decimal.TryParse(txtPrice.Text.Trim(), price) OrElse price <= 0 Then
            MessageBox.Show("يرجى إدخال سعر صحيح!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim drvUnit As DataRowView = CType(cmbUnit.SelectedItem, DataRowView)
        Dim factor As Decimal = Convert.ToDecimal(drvUnit("ConversionFactor"))
        Dim baseQty As Decimal = qty * factor
        Dim total As Decimal = qty * price

        Dim newRow As DataRow = _dtItems.NewRow()
        newRow("MaterialID") = Convert.ToInt32(cmbMaterial.SelectedValue)
        newRow("MaterialName") = cmbMaterial.Text
        newRow("UnitID") = Convert.ToInt32(cmbUnit.SelectedValue)
        newRow("UnitName") = cmbUnit.Text
        newRow("ConversionFactor") = factor
        newRow("Quantity") = qty
        newRow("BaseQuantity") = baseQty
        newRow("UnitPrice") = price
        newRow("TotalPrice") = total
        _dtItems.Rows.Add(newRow)

        CalculateTotals()
        txtQuantity.Clear()
        txtPrice.Clear()
        cmbMaterial.Focus()
    End Sub

    Private Sub CalculateTotals()
        Dim total As Decimal = 0
        For Each row As DataRow In _dtItems.Rows
            total += Convert.ToDecimal(row("TotalPrice"))
        Next

        txtTotalAmount.Text = total.ToString("N2")

        Dim discount As Decimal = 0
        Decimal.TryParse(txtDiscount.Text.Trim(), discount)

        Dim net As Decimal = total - discount
        If net < 0 Then net = 0
        txtNetTotal.Text = net.ToString("N2")

        ' حساب المدفوع والمتبقي بحسب طريقة الدفع
        Select Case cmbPaymentType.SelectedIndex
            Case 0 ' نقدي - CASH: المدفوع = الصافي كاملاً، المتبقي = صفر
                txtPaidAmount.Text = net.ToString("N2")
                txtRemainingAmount.Text = "0.00"

            Case 1 ' آجل - CREDIT: المدفوع = صفر، المتبقي = الصافي كاملاً
                txtPaidAmount.Text = "0.00"
                txtRemainingAmount.Text = net.ToString("N2")

            Case 2 ' جزئي - PARTIAL: المتبقي = الصافي - المدفوع المُدخَل
                Dim paid As Decimal = 0
                Decimal.TryParse(txtPaidAmount.Text.Trim(), paid)
                Dim remaining As Decimal = net - paid
                txtRemainingAmount.Text = remaining.ToString("N2")
        End Select
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged, txtPaidAmount.TextChanged
        CalculateTotals()
    End Sub

    Private Async Sub btnSaveInvoice_Click(sender As Object, e As EventArgs) Handles btnSaveInvoice.Click
        If cmbSupplier.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار المورد!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbStore.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار المخزن المستلم!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbPaymentType.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار طريقة الدفع!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If _dtItems.Rows.Count = 0 Then
            MessageBox.Show("الفاتورة فارغة، يرجى إضافة أصناف أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' تحديد كود طريقة الدفع
        Dim paymentCode As String
        Select Case cmbPaymentType.SelectedIndex
            Case 0 : paymentCode = "CASH"
            Case 1 : paymentCode = "CREDIT"
            Case 2 : paymentCode = "PARTIAL"
            Case Else : paymentCode = "CASH"
        End Select

        Dim paid As Decimal = 0
        Decimal.TryParse(txtPaidAmount.Text.Trim(), paid)

        ' التحقق من الخزينة عند وجود مبلغ نقدي مدفوع
        If paid > 0 AndAlso cmbTreasury.SelectedIndex = -1 Then
            MessageBox.Show("يرجى تحديد الخزينة التي تم الصرف منها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' التحقق من المبلغ الجزئي
        If paymentCode = "PARTIAL" AndAlso paid <= 0 Then
            MessageBox.Show("في حالة الدفع الجزئي، يرجى إدخال المبلغ المدفوع!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim supID As Integer = Convert.ToInt32(cmbSupplier.SelectedValue)
        Dim storeID As Integer = Convert.ToInt32(cmbStore.SelectedValue)
        Dim treasuryID As Integer? = If(cmbTreasury.SelectedValue IsNot Nothing AndAlso paid > 0, Convert.ToInt32(cmbTreasury.SelectedValue), CType(Nothing, Integer?))
        Dim invNumber As String = txtInvoiceNumber.Text.Trim()
        Dim netTotal As Decimal = Convert.ToDecimal(txtNetTotal.Text)
        Dim remaining As Decimal = Convert.ToDecimal(txtRemainingAmount.Text)

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Await conn.OpenAsync()
            Dim trans As SqlTransaction = conn.BeginTransaction()

            Try
                ' 1. حفظ رأس الفاتورة مع طريقة الدفع
                Dim sqlHeader As String = "INSERT INTO PurchaseHeaders (InvoiceNumber, SupplierID, StoreID, PurchaseDate, TotalAmount, Discount, NetTotal, PaidAmount, RemainingAmount, PaymentType, TreasuryID, Notes, UserID) " &
                                          "VALUES (@InvNo, @SupID, @StoreID, @Date, @Total, @Disc, @Net, @Paid, @Rem, @PayType, @TreasuryID, @Notes, 1); " &
                                          "SELECT SCOPE_IDENTITY();"

                Dim purchaseID As Integer = 0
                Using cmdH As New SqlCommand(sqlHeader, conn, trans)
                    cmdH.Parameters.AddWithValue("@InvNo", invNumber)
                    cmdH.Parameters.AddWithValue("@SupID", supID)
                    cmdH.Parameters.AddWithValue("@StoreID", storeID)
                    cmdH.Parameters.AddWithValue("@Date", dtpInvoiceDate.Value)
                    cmdH.Parameters.AddWithValue("@Total", Convert.ToDecimal(txtTotalAmount.Text))
                    cmdH.Parameters.AddWithValue("@Disc", Convert.ToDecimal(If(String.IsNullOrWhiteSpace(txtDiscount.Text), "0", txtDiscount.Text)))
                    cmdH.Parameters.AddWithValue("@Net", netTotal)
                    cmdH.Parameters.AddWithValue("@Paid", paid)
                    cmdH.Parameters.AddWithValue("@Rem", remaining)
                    cmdH.Parameters.AddWithValue("@PayType", paymentCode)
                    cmdH.Parameters.AddWithValue("@TreasuryID", If(treasuryID.HasValue, treasuryID.Value, DBNull.Value))
                    cmdH.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))

                    purchaseID = Convert.ToInt32(Await cmdH.ExecuteScalarAsync())
                End Using

                ' 2. حفظ التفاصيل وزيادة رصيد الخامات في المخزن المحدد بالوحدة الأساسية
                For Each r As DataRow In _dtItems.Rows
                    Dim matID As Integer = Convert.ToInt32(r("MaterialID"))
                    Dim unitID As Integer = Convert.ToInt32(r("UnitID"))
                    Dim qty As Decimal = Convert.ToDecimal(r("Quantity"))
                    Dim factor As Decimal = Convert.ToDecimal(r("ConversionFactor"))
                    Dim baseQty As Decimal = Convert.ToDecimal(r("BaseQuantity"))
                    Dim price As Decimal = Convert.ToDecimal(r("UnitPrice"))

                    ' أ) إدراج السطر
                    Dim sqlDetail As String = "INSERT INTO PurchaseDetails (PurchaseID, MaterialID, UnitID, Quantity, ConversionFactor, UnitPrice) " &
                                              "VALUES (@PurchID, @MatID, @UnitID, @Qty, @Factor, @Price)"
                    Using cmdD As New SqlCommand(sqlDetail, conn, trans)
                        cmdD.Parameters.AddWithValue("@PurchID", purchaseID)
                        cmdD.Parameters.AddWithValue("@MatID", matID)
                        cmdD.Parameters.AddWithValue("@UnitID", unitID)
                        cmdD.Parameters.AddWithValue("@Qty", qty)
                        cmdD.Parameters.AddWithValue("@Factor", factor)
                        cmdD.Parameters.AddWithValue("@Price", price)
                        Await cmdD.ExecuteNonQueryAsync()
                    End Using

                    ' ب) زيادة رصيد الخامة في المخزن بالوحدة الأساسية (BaseQuantity)
                    Dim sqlStock As String = "IF NOT EXISTS (SELECT 1 FROM StoreStock WHERE StoreID = @StoreID AND MaterialID = @MatID) " &
                                             "    INSERT INTO StoreStock (StoreID, MaterialID, CurrentStock) VALUES (@StoreID, @MatID, @BaseQty); " &
                                             "ELSE " &
                                             "    UPDATE StoreStock SET CurrentStock = CurrentStock + @BaseQty WHERE StoreID = @StoreID AND MaterialID = @MatID;"
                    Using cmdStock As New SqlCommand(sqlStock, conn, trans)
                        cmdStock.Parameters.AddWithValue("@StoreID", storeID)
                        cmdStock.Parameters.AddWithValue("@MatID", matID)
                        cmdStock.Parameters.AddWithValue("@BaseQty", baseQty)
                        Await cmdStock.ExecuteNonQueryAsync()
                    End Using

                    ' ج) تسجيل حركة توريد في StockMovements
                    Dim sqlMove As String = "INSERT INTO StockMovements (StoreID, MaterialID, MovementType, Quantity, ReferenceID, CreatedDate) " &
                                            "VALUES (@StoreID, @MatID, 'PURCHASE', @BaseQty, @Ref, GETDATE())"
                    Using cmdMove As New SqlCommand(sqlMove, conn, trans)
                        cmdMove.Parameters.AddWithValue("@StoreID", storeID)
                        cmdMove.Parameters.AddWithValue("@MatID", matID)
                        cmdMove.Parameters.AddWithValue("@BaseQty", baseQty)
                        cmdMove.Parameters.AddWithValue("@Ref", invNumber)
                        Await cmdMove.ExecuteNonQueryAsync()
                    End Using
                Next

                ' 3. تحديث حساب المورد بالمتبقي وتسجيل الحركة
                ' CurrentBalance يزداد بالمبلغ المتبقي (الآجل) فقط
                Dim sqlSupBal As String = "UPDATE Suppliers SET CurrentBalance = CurrentBalance + @Rem WHERE SupplierID = @SupID; " &
                                          "SELECT CurrentBalance FROM Suppliers WHERE SupplierID = @SupID;"
                Dim supNewBal As Decimal = 0
                Using cmdSup As New SqlCommand(sqlSupBal, conn, trans)
                    cmdSup.Parameters.AddWithValue("@Rem", remaining)
                    cmdSup.Parameters.AddWithValue("@SupID", supID)
                    supNewBal = Convert.ToDecimal(Await cmdSup.ExecuteScalarAsync())
                End Using

                ' تسجيل حركة المورد:
                ' الدائن (Credit) = صافي الفاتورة (مبلغ مستحق للمورد مقابل البضاعة)
                ' المدين (Debit) = المبلغ المسدد نقداً (ما دفعناه للمورد)
                Dim sqlSupTrans As String = "INSERT INTO SupplierTransactions (SupplierID, TransactionType, ReferenceNo, Debit, Credit, BalanceAfter, Notes, UserID) " &
                                            "VALUES (@SupID, 'PURCHASE', @Ref, @Debit, @Credit, @BalAfter, @Notes, 1)"
                Using cmdST As New SqlCommand(sqlSupTrans, conn, trans)
                    cmdST.Parameters.AddWithValue("@SupID", supID)
                    cmdST.Parameters.AddWithValue("@Ref", invNumber)
                    cmdST.Parameters.AddWithValue("@Debit", paid)
                    cmdST.Parameters.AddWithValue("@Credit", netTotal)
                    cmdST.Parameters.AddWithValue("@BalAfter", supNewBal)
                    cmdST.Parameters.AddWithValue("@Notes", $"فاتورة مشتريات رقم {invNumber}")
                    Await cmdST.ExecuteNonQueryAsync()
                End Using

                ' 4. خصم المسدد نقداً من الخزينة إن وجد
                If paid > 0 AndAlso treasuryID.HasValue Then
                    Await TreasuryService.AddTransactionAsync(
                        treasuryID:=treasuryID.Value,
                        transactionType:=TreasuryTransactionTypes.Expense,
                        amount:=paid,
                        isDeposit:=False,
                        referenceID:=purchaseID,
                        referenceNo:=invNumber,
                        notes:=$"سداد نقدي لفاتورة مشتريات رقم {invNumber}",
                        userID:=1,
                        cn:=conn,
                        trans:=trans
                    )
                End If

                trans.Commit()
                MessageBox.Show("تم حفظ فاتورة المشتريات وتوريد الأصناف للمخزن بنجاح!", "نجاح التوريد", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearForm()

            Catch ex As Exception
                trans.Rollback()
                MessageBox.Show("خطأ أثناء حفظ فاتورة المشتريات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        If dgvInvoiceItems.SelectedRows.Count > 0 Then
            dgvInvoiceItems.Rows.RemoveAt(dgvInvoiceItems.SelectedRows(0).Index)
            CalculateTotals()
        End If
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnit.SelectedIndexChanged
        If cmbMaterial.SelectedValue Is Nothing OrElse cmbUnit.SelectedValue Is Nothing Then
            txtPrice.Text = "0.00"
            Exit Sub
        End If

        Dim matID As Integer = 0
        Dim unitID As Integer = 0

        If Integer.TryParse(cmbMaterial.SelectedValue.ToString(), matID) AndAlso
       Integer.TryParse(cmbUnit.SelectedValue.ToString(), unitID) Then

            Try
                ' البحث عن السعر: إن كانت الوحدة في MaterialUnits نأخذ PurchasePrice، وإن كانت الأساسية نأخذ CostPrice
                Dim query As String = "IF EXISTS (SELECT 1 FROM MaterialUnits WHERE MaterialID = @MatID AND UnitID = @UnitID) " &
                                  "    SELECT ISNULL(PurchasePrice, 0.00) FROM MaterialUnits WHERE MaterialID = @MatID AND UnitID = @UnitID; " &
                                  "ELSE " &
                                  "    SELECT ISNULL(CostPrice, 0.00) FROM RawMaterials WHERE MaterialID = @MatID;"

                Using conn As New SqlConnection(DBModule.ConnectionString)
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@MatID", matID)
                        cmd.Parameters.AddWithValue("@UnitID", unitID)
                        conn.Open()

                        Dim result = cmd.ExecuteScalar()
                        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                            txtPrice.Text = Convert.ToDecimal(result).ToString("N2")
                        Else
                            txtPrice.Text = "0.00"
                        End If
                    End Using
                End Using
            Catch ex As Exception
                txtPrice.Text = "0.00"
            End Try
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    ' ══════════════════════════════════════════════════════════
    ' تفريغ الفورم بالكامل
    ' ══════════════════════════════════════════════════════════
    Private Sub ClearForm()
        ' 1. مسح جدول الأصناف
        _dtItems.Clear()

        ' 2. رقم فاتورة جديد + تاريخ اليوم
        txtInvoiceNumber.Text = GetNextCode("PurchaseHeaders", "InvoiceNumber")
        dtpInvoiceDate.Value = DateTime.Now

        ' 3. إعادة تعيين القوائم المنسدلة
        cmbSupplier.SelectedIndex = -1
        cmbStore.SelectedIndex = If(cmbStore.Items.Count > 0, 0, -1)
        cmbMaterial.SelectedIndex = -1
        cmbUnit.DataSource = Nothing
        cmbTreasury.SelectedIndex = -1

        ' 4. تفريغ حقول إدخال الصنف
        txtBarcode.Clear()
        txtQuantity.Clear()
        txtPrice.Clear()
        txtNotes.Clear()
        txtDiscount.Clear()

        ' 5. صفر المبالغ
        txtTotalAmount.Text = "0.00"
        txtNetTotal.Text = "0.00"
        txtPaidAmount.Text = "0.00"
        txtRemainingAmount.Text = "0.00"

        ' 6. تفريغ رصيد المورد
        txtDebit.Text = "0.00"
        txtCredit.Text = "0.00"

        ' 7. إعادة طريقة الدفع للنقدي
        cmbPaymentType.SelectedIndex = 0
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    ' ══════════════════════════════════════════════════════════
    ' عرض رصيد المورد (مدين / دائن) عند اختياره
    ' ══════════════════════════════════════════════════════════
    Private Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        If cmbSupplier.SelectedValue Is Nothing OrElse Not Integer.TryParse(cmbSupplier.SelectedValue.ToString(), Nothing) Then
            txtDebit.Text = "0.00"
            txtCredit.Text = "0.00"
            Exit Sub
        End If

        Try
            Dim supID As Integer = Convert.ToInt32(cmbSupplier.SelectedValue)
            Dim query As String = "SELECT ISNULL(CurrentBalance, 0) FROM Suppliers WHERE SupplierID = @SupID"

            Using conn As New System.Data.SqlClient.SqlConnection(DBModule.ConnectionString)
                Using cmd As New System.Data.SqlClient.SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@SupID", supID)
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Dim balance As Decimal = Convert.ToDecimal(result)

                        If balance > 0 Then
                            ' رصيد موجب = المورد له فلوس عندنا (دائن)
                            txtCredit.Text = balance.ToString("N2")
                            txtDebit.Text = "0.00"
                        ElseIf balance < 0 Then
                            ' رصيد سالب = نحن لنا فلوس عنده (مدين)
                            txtDebit.Text = Math.Abs(balance).ToString("N2")
                            txtCredit.Text = "0.00"
                        Else
                            txtDebit.Text = "0.00"
                            txtCredit.Text = "0.00"
                        End If
                    Else
                        txtDebit.Text = "0.00"
                        txtCredit.Text = "0.00"
                    End If
                End Using
            End Using
        Catch ex As Exception
            txtDebit.Text = "0.00"
            txtCredit.Text = "0.00"
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════════
    ' إدخال الخامة عن طريق الباركود
    ' ══════════════════════════════════════════════════════════
    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub
        e.SuppressKeyPress = True

        Dim barcode As String = txtBarcode.Text.Trim()
        If String.IsNullOrEmpty(barcode) Then Exit Sub

        Try
            ' البحث أولاً في الخامة الأساسية، أو في جدول الوحدات الإضافية MaterialUnits
            Dim query As String = "SELECT TOP 1 R.MaterialID, R.UnitID " &
                                  "FROM RawMaterials R " &
                                  "WHERE R.MaterialBarcode = @Barcode AND R.IsActive = 1 AND (R.IsDeleted = 0 OR R.IsDeleted IS NULL) " &
                                  "UNION ALL " &
                                  "SELECT TOP 1 MU.MaterialID, MU.UnitID " &
                                  "FROM MaterialUnits MU " &
                                  "INNER JOIN RawMaterials R ON MU.MaterialID = R.MaterialID " &
                                  "WHERE MU.Barcode = @Barcode AND R.IsActive = 1 AND (R.IsDeleted = 0 OR R.IsDeleted IS NULL)"

            Using conn As New System.Data.SqlClient.SqlConnection(DBModule.ConnectionString)
                Using cmd As New System.Data.SqlClient.SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Barcode", barcode)
                    conn.Open()
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim materialID As Integer = Convert.ToInt32(reader("MaterialID"))
                            Dim unitID As Integer = If(IsDBNull(reader("UnitID")), 0, Convert.ToInt32(reader("UnitID")))

                            ' تحديد الخامة في القائمة المنسدلة (وهذا يُحمّل وحداتها تلقائياً)
                            cmbMaterial.SelectedValue = materialID

                            ' إذا كان الباركود لوحدة محددة، نحددها
                            If unitID > 0 Then
                                cmbUnit.SelectedValue = unitID
                            End If

                            txtBarcode.Clear()
                            txtQuantity.Focus()
                            txtQuantity.SelectAll()
                        Else
                            MessageBox.Show("لم يتم العثور على خامة بهذا الباركود!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtBarcode.SelectAll()
                            txtBarcode.Focus()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء البحث بالباركود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class