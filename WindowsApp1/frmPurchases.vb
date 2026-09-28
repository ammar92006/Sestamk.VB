Imports System.Data.SqlClient

Public Class frmPurchases
    Private _dtItems As New DataTable()
    Private defaultTreasuryid As Integer
    Private savingInvoice As Boolean
    Private lastPurchaseID As Integer

    Private Sub frmPurchases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler btnLookupPurchases.Click, Sub() PurchaseDocumentHelper.RunSafely(Sub()
                                                                          SupplierAccountingService.DemandPermission("frmPurchaseReports", "CanOpen")
                                                                          Using report As New frmPurchaseReports()
                                                                              report.ShowDialog(Me)
                                                                          End Using
                                                                      End Sub)
        AddHandler btnPrintLastPurchase.Click, Sub() PurchaseDocumentHelper.RunSafely(Sub()
                                                                         If lastPurchaseID <= 0 Then Throw New ArgumentException("احفظ فاتورة أو افتح الفواتير السابقة أولاً.")
                                                                         PurchaseDocumentHelper.ShowInvoice(Me, lastPurchaseID)
                                                                     End Sub)
        AddHandler FormClosing, Sub(sender2, args)
                                    If savingInvoice Then args.Cancel = True
                                End Sub
        SupplierAccountingService.EnsurePurchaseHeadersBranchColumn()
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

        defaultTreasuryid = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)
        If defaultTreasuryid > 0 Then
            cmbTreasury.SelectedValue = defaultTreasuryid
        ElseIf cmbTreasury.Items.Count > 0 Then
            cmbTreasury.SelectedIndex = 0
        End If
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
        If factor <= 0D Then
            MessageBox.Show("معامل تحويل الوحدة غير صالح.")
            Return
        End If
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
        If savingInvoice Then Return
        If Session.CurrentUserID <= 0 OrElse Not Session.HasPermission("frmPurchases", "CanAdd") Then
            MessageBox.Show("ليس لديك صلاحية إضافة فاتورة مشتريات.")
            Return
        End If
        If cmbSupplier.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار المورد!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbStore.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار المخزن المستلم!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbBranches.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار الفرع!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        Dim branchID As Integer? = If(cmbBranches.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbBranches.SelectedValue.ToString(), Nothing), Convert.ToInt32(cmbBranches.SelectedValue), CType(Nothing, Integer?))
        Dim treasuryID As Integer? = If(cmbTreasury.SelectedValue IsNot Nothing AndAlso paid > 0, Convert.ToInt32(cmbTreasury.SelectedValue), CType(Nothing, Integer?))
        Dim invNumber As String = txtInvoiceNumber.Text.Trim()
        Dim netTotal As Decimal = Convert.ToDecimal(txtNetTotal.Text)
        Dim remaining As Decimal = Convert.ToDecimal(txtRemainingAmount.Text)

        Dim total As Decimal = 0D
        For Each row As DataRow In _dtItems.Rows
            If CDec(row("Quantity")) <= 0 OrElse CDec(row("UnitPrice")) <= 0 OrElse CDec(row("ConversionFactor")) <= 0 Then
                MessageBox.Show("راجع كميات وأسعار ومعاملات تحويل الأصناف.")
                Return
            End If
            total += CDec(row("Quantity")) * CDec(row("UnitPrice"))
        Next
        Dim discount As Decimal
        If Not Decimal.TryParse(If(String.IsNullOrWhiteSpace(txtDiscount.Text), "0", txtDiscount.Text), discount) OrElse discount < 0 OrElse discount > total Then
            MessageBox.Show("الخصم يجب أن يكون بين صفر وإجمالي الفاتورة.")
            Return
        End If
        netTotal = Decimal.Round(total - discount, 2, MidpointRounding.AwayFromZero)
        If paymentCode = "CASH" Then paid = netTotal
        If paymentCode = "CREDIT" Then paid = 0D
        If paid < 0D OrElse paid > netTotal OrElse Decimal.Round(paid, 2) <> paid Then
            MessageBox.Show("المبلغ المدفوع غير صالح أو يتجاوز صافي الفاتورة.")
            Return
        End If
        remaining = netTotal - paid
        If String.IsNullOrWhiteSpace(invNumber) OrElse invNumber.Length > 50 Then
            MessageBox.Show("أدخل رقم فاتورة لا يتجاوز 50 حرفاً.")
            Return
        End If
        savingInvoice = True
        Me.Enabled = False
        Try
            lastPurchaseID = Await SupplierAccountingService.SavePurchaseAsync(invNumber, supID, storeID, dtpInvoiceDate.Value, discount, paid, paymentCode, treasuryID, txtNotes.Text.Trim(), _dtItems.Copy(), updateCost.Checked, branchID)
            MessageBox.Show("تم حفظ فاتورة المشتريات وتوريد الأصناف للمخزن بنجاح!", "نجاح التوريد")
            Try
                ClearForm()
            Catch ex As Exception
                MessageBox.Show("تم الحفظ، لكن تعذر تهيئة فاتورة جديدة: " & ex.Message)
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "تعذر حفظ الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            savingInvoice = False
            Me.Enabled = True
        End Try
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
        Dim defaultBranchID = If(SettingsManager.GetSetting("CurrentBranchID"), "")
        If Not String.IsNullOrEmpty(defaultBranchID) AndAlso cmbBranches.Items.Count > 0 Then
            cmbBranches.SelectedValue = Convert.ToInt32(defaultBranchID)
        ElseIf cmbBranches.Items.Count > 0 Then
            cmbBranches.SelectedIndex = 0
        End If
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