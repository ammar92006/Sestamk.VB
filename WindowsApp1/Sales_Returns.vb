Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class Sales_Returns

    Private ReadOnly _repo As POSRepository
    Private _currentLoadedInvoice As InvoiceModel = Nothing
    Private _currentCustomerID As Integer? = Nothing
    Private _currentCustomerName As String = "عميل نقدي عام"
    Private _currentCustomerBalance As Decimal = 0
    Private _isUpdatingGridInternally As Boolean = False
    Private _lastSavedReturnNumber As String = ""

    Public Sub New()
        InitializeComponent()
        _repo = New POSRepository(DBModule.ConnectionString)
    End Sub

    Private Async Sub Sales_Returns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim drag As New FormDragHelper(Me, panelHeader)

            ' تطبيق الثيم العام
            ThemeManager.Instance.ApplyTheme(Me)
            ThemeHelper.ApplyDataGridViewTheme(dgvReturnItems, ThemeManager.Instance.CurrentPalette)

            ' تهيئة القوائم المنسدلة
            cmbRefundMethod.Items.Clear()
            cmbRefundMethod.Items.Add("نقدي من الدرج / الخزينة")
            cmbRefundMethod.Items.Add("إضافة إلى حساب العميل")
            cmbRefundMethod.Items.Add("فيزا / شبكة")
            cmbRefundMethod.SelectedIndex = 0

            cmbReturnReason.Items.Clear()
            cmbReturnReason.Items.Add("رغبة العميل")
            cmbReturnReason.Items.Add("صنف تالف / غير مطابق")
            cmbReturnReason.Items.Add("خطأ في تسجيل الطلب")
            cmbReturnReason.Items.Add("تأخر في تحضير الطلب")
            cmbReturnReason.Items.Add("أخرى")
            cmbReturnReason.SelectedIndex = 0

            Await LoadTreasuriesAsync()
            ClearForm()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء فتح شاشة المرتجعات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' تحميل الخزائن المتاحة
    ' =========================================================
    Private Async Function LoadTreasuriesAsync() As Task
        Try
            Dim dt As New DataTable()
            Using cn As SqlConnection = Await NewConnAsync()
                Const sql As String = "SELECT TreasuryID, TreasuryNameAr FROM Treasury WHERE IsActive = 1 AND IsDeleted = 0 ORDER BY TreasuryID;"
                Using da As New SqlDataAdapter(sql, cn)
                    Await Task.Run(Sub() da.Fill(dt))
                End Using
            End Using

            cmbTreasury.DataSource = dt
            cmbTreasury.DisplayMember = "TreasuryNameAr"
            cmbTreasury.ValueMember = "TreasuryID"

            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing AndAlso ShiftSession.CurrentShift.TreasuryID.HasValue AndAlso ShiftSession.CurrentShift.TreasuryID.Value > 0 Then
                cmbTreasury.SelectedValue = ShiftSession.CurrentShift.TreasuryID.Value
            Else
                Dim defTreasuryID = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)
                If defTreasuryID > 0 Then cmbTreasury.SelectedValue = defTreasuryID
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء تحميل بيانات الخزائن: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' =========================================================
    ' تفريغ الشاشة لعملية جديدة
    ' =========================================================
    Private Sub ClearForm()
        _currentLoadedInvoice = Nothing
        _currentCustomerID = Nothing
        _currentCustomerName = "عميل نقدي عام"
        _currentCustomerBalance = 0

        txtInvoiceSearch.Clear()
        txtItemSearch.Clear()
        txtReturnNotes.Clear()
        lblInvoiceInfo.Text = "لم يتم تحديد فاتورة بعد. ادخل رقم الفاتورة أو اضف أصناف حرة للإرجاع."
        lblCustomerHeader.Text = "العميل: عميل نقدي عام"
        lblCustomerBalance.Text = "الرصيد: 0.00 ج.م"

        dgvReturnItems.Rows.Clear()
        RecalculateTotals()

        txtInvoiceSearch.Focus()
    End Sub

    Private Sub btnNewReturn_Click(sender As Object, e As EventArgs) Handles btnNewReturn.Click
        ClearForm()
    End Sub

    ' =========================================================
    ' البحث عن فاتورة مبيعات برقم الفاتورة
    ' =========================================================
    Private Sub btnSearchInvoice_Click(sender As Object, e As EventArgs) Handles btnSearchInvoice.Click
        SearchInvoice()
    End Sub

    Private Sub txtInvoiceSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInvoiceSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchInvoice()
        End If
    End Sub

    Private Sub SearchInvoice()
        Dim invNum As String = txtInvoiceSearch.Text.Trim()
        If String.IsNullOrWhiteSpace(invNum) Then
            MessageBox.Show("يرجى إدخال أو مسح رقم الفاتورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInvoiceSearch.Focus()
            Exit Sub
        End If

        Try
            Dim inv As InvoiceModel = _repo.GetInvoiceByNumber(invNum)
            If inv Is Nothing Then
                MessageBox.Show($"لم يتم العثور على أي فاتورة مبيعات بالرقم: {invNum}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtInvoiceSearch.SelectAll()
                txtInvoiceSearch.Focus()
                Exit Sub
            End If

            LoadInvoiceIntoReturn(inv)

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء جلب الفاتورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadInvoiceIntoReturn(inv As InvoiceModel)
        _currentLoadedInvoice = inv
        _currentCustomerID = inv.CustomerID

        ' جلب بيانات العميل المحدثة
        If inv.CustomerID.HasValue AndAlso inv.CustomerID.Value > 0 Then
            LoadCustomerInfo(inv.CustomerID.Value)
        Else
            _currentCustomerName = "عميل نقدي عام"
            _currentCustomerBalance = 0
            lblCustomerHeader.Text = "العميل: عميل نقدي عام"
            lblCustomerBalance.Text = "الرصيد: 0.00 ج.م"
        End If

        Dim orderTypeName As String = "تيك أوي"
        Select Case inv.OrderType
            Case 1 : orderTypeName = "تيك أوي"
            Case 2 : orderTypeName = "صالة"
            Case 3 : orderTypeName = "دليفري"
        End Select

        lblInvoiceInfo.Text = $"فاتورة #{inv.InvoiceNumber}  |  التاريخ: {inv.InvoiceDate:yyyy/MM/dd HH:mm}  |  النوع: {orderTypeName}  |  الصافي المدفوع: {inv.NetTotal:N2} ج.م  |  الخصم: {inv.DiscountAmount:N2} ج.م"

        ' ملء شبكة الأصناف
        _isUpdatingGridInternally = True
        dgvReturnItems.Rows.Clear()

        For Each det As InvoiceDetailModel In inv.Details
            Dim rowIndex As Integer = dgvReturnItems.Rows.Add()
            Dim row As DataGridViewRow = dgvReturnItems.Rows(rowIndex)

            row.Cells("colSelect").Value = True
            row.Cells("colProductID").Value = det.ProductID
            row.Cells("colSizeID").Value = 0
            row.Cells("colAddonID").Value = 0
            row.Cells("colProductName").Value = det.ProductName
            row.Cells("colSizeName").Value = det.SizeName
            row.Cells("colAddonsText").Value = det.AddonsText
            row.Cells("colUnitPrice").Value = det.UnitPrice
            row.Cells("colOriginalQty").Value = det.Quantity
            row.Cells("colReturnQty").Value = det.Quantity
            row.Cells("colTotalPrice").Value = det.Quantity * det.UnitPrice
            row.Cells("colRestoreStock").Value = True
            row.Cells("colItemNotes").Value = ""
        Next

        _isUpdatingGridInternally = False
        RecalculateTotals()
    End Sub

    Private Sub LoadCustomerInfo(custID As Integer)
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Const sql As String = "SELECT CustomerName, CustomerCode, CurrentBalance FROM Customers WHERE CustomerID = @ID;"
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ID", custID)
                conn.Open()
                Using rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        _currentCustomerName = rdr("CustomerName").ToString()
                        _currentCustomerBalance = Convert.ToDecimal(rdr("CurrentBalance"))

                        lblCustomerHeader.Text = $"العميل: {_currentCustomerName} ({rdr("CustomerCode")})"
                        If _currentCustomerBalance < 0 Then
                            lblCustomerBalance.Text = $"الرصيد: {Math.Abs(_currentCustomerBalance):N2} ج.م (مدين)"
                            lblCustomerBalance.ForeColor = Color.FromArgb(231, 76, 60)
                        ElseIf _currentCustomerBalance > 0 Then
                            lblCustomerBalance.Text = $"الرصيد: {_currentCustomerBalance:N2} ج.م (دائن)"
                            lblCustomerBalance.ForeColor = Color.FromArgb(39, 174, 96)
                        Else
                            lblCustomerBalance.Text = "الرصيد: 0.00 ج.م"
                            lblCustomerBalance.ForeColor = Color.Gray
                        End If
                    End If
                End Using
            End Using
        End Using
    End Sub

    ' =========================================================
    ' إضافة صنف حر للإرجاع (بدون فاتورة محددة مسبقاً)
    ' =========================================================
    Private Sub txtItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            AddFreeItemFromSearch()
        End If
    End Sub

    Private Sub AddFreeItemFromSearch()
        Dim queryText As String = txtItemSearch.Text.Trim()
        If String.IsNullOrWhiteSpace(queryText) Then Exit Sub

        Try
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Const sql As String = "
                    SELECT TOP 1 ProductID, ProductNameAr, SalePrice, Barcode 
                    FROM Products 
                    WHERE (ProductNameAr LIKE @Q OR Barcode = @ExactQ OR ProductCode = @ExactQ) 
                      AND IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL);"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Q", "%" & queryText & "%")
                    cmd.Parameters.AddWithValue("@ExactQ", queryText)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Dim pID As Integer = Convert.ToInt32(rdr("ProductID"))
                            Dim pName As String = rdr("ProductNameAr").ToString()
                            Dim pPrice As Decimal = Convert.ToDecimal(rdr("SalePrice"))

                            ' فحص ما إذا كان الصنف مضافاً مسبقاً بالجدول
                            Dim foundRow As DataGridViewRow = Nothing
                            For Each row As DataGridViewRow In dgvReturnItems.Rows
                                If Convert.ToInt32(row.Cells("colProductID").Value) = pID Then
                                    foundRow = row
                                    Exit For
                                End If
                            Next

                            If foundRow IsNot Nothing Then
                                Dim currentRet As Decimal = Convert.ToDecimal(foundRow.Cells("colReturnQty").Value)
                                foundRow.Cells("colReturnQty").Value = currentRet + 1
                                foundRow.Cells("colTotalPrice").Value = (currentRet + 1) * Convert.ToDecimal(foundRow.Cells("colUnitPrice").Value)
                                foundRow.Cells("colSelect").Value = True
                            Else
                                Dim rIdx As Integer = dgvReturnItems.Rows.Add()
                                Dim newRow As DataGridViewRow = dgvReturnItems.Rows(rIdx)
                                newRow.Cells("colSelect").Value = True
                                newRow.Cells("colProductID").Value = pID
                                newRow.Cells("colSizeID").Value = 0
                                newRow.Cells("colAddonID").Value = 0
                                newRow.Cells("colProductName").Value = pName
                                newRow.Cells("colSizeName").Value = "-"
                                newRow.Cells("colAddonsText").Value = "-"
                                newRow.Cells("colUnitPrice").Value = pPrice
                                newRow.Cells("colOriginalQty").Value = 999 ' حر
                                newRow.Cells("colReturnQty").Value = 1
                                newRow.Cells("colTotalPrice").Value = pPrice
                                newRow.Cells("colRestoreStock").Value = True
                                newRow.Cells("colItemNotes").Value = "إرجاع صنف حر"
                            End If

                            txtItemSearch.Clear()
                            RecalculateTotals()
                        Else
                            MessageBox.Show($"لم يتم العثور على أي صنف مطابق لـ: {queryText}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء البحث عن الصنف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' إرجاع كامل الفاتورة بنقرة زر واحدة
    ' =========================================================
    Private Sub btnReturnAll_Click(sender As Object, e As EventArgs) Handles btnReturnAll.Click
        If dgvReturnItems.Rows.Count = 0 Then Exit Sub

        _isUpdatingGridInternally = True
        For Each row As DataGridViewRow In dgvReturnItems.Rows
            row.Cells("colSelect").Value = True
            row.Cells("colReturnQty").Value = row.Cells("colOriginalQty").Value
            Dim uPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value)
            Dim qty = Convert.ToDecimal(row.Cells("colReturnQty").Value)
            row.Cells("colTotalPrice").Value = qty * uPrice
        Next
        _isUpdatingGridInternally = False
        RecalculateTotals()
    End Sub

    ' =========================================================
    ' تفاعل الجدول وإعادة الحساب
    ' =========================================================
    Private Sub dgvReturnItems_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReturnItems.CellValueChanged
        If _isUpdatingGridInternally OrElse e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvReturnItems.Rows(e.RowIndex)

        If e.ColumnIndex = dgvReturnItems.Columns("colReturnQty").Index Then
            Dim retQty As Decimal = 0
            Dim origQty As Decimal = Convert.ToDecimal(row.Cells("colOriginalQty").Value)

            If Not Decimal.TryParse(Convert.ToString(row.Cells("colReturnQty").Value), retQty) OrElse retQty < 0 Then
                retQty = 1
                row.Cells("colReturnQty").Value = retQty
            End If

            If retQty > origQty AndAlso origQty < 999 Then
                MessageBox.Show($"الكمية المرتجعة لا يمكن أن تزيد عن الكمية المباعة في الفاتورة ({origQty})!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                retQty = origQty
                row.Cells("colReturnQty").Value = retQty
            End If

            Dim uPrice As Decimal = Convert.ToDecimal(row.Cells("colUnitPrice").Value)
            row.Cells("colTotalPrice").Value = retQty * uPrice

            If retQty > 0 Then
                row.Cells("colSelect").Value = True
            Else
                row.Cells("colSelect").Value = False
            End If
        End If

        RecalculateTotals()
    End Sub

    Private Sub dgvReturnItems_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvReturnItems.CurrentCellDirtyStateChanged
        If dgvReturnItems.IsCurrentCellDirty Then
            dgvReturnItems.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub RecalculateTotals()
        Dim totalReturnBeforeDisc As Decimal = 0

        For Each row As DataGridViewRow In dgvReturnItems.Rows
            Dim isSelected = Convert.ToBoolean(row.Cells("colSelect").Value)
            If isSelected Then
                Dim rowTotal As Decimal = 0
                If Decimal.TryParse(Convert.ToString(row.Cells("colTotalPrice").Value), rowTotal) Then
                    totalReturnBeforeDisc += rowTotal
                End If
            End If
        Next

        ' حساب الخصم المسترد بنسبة وتناسب إذا كانت الفاتورة الأصلية بها خصم
        Dim discountDeducted As Decimal = 0
        If _currentLoadedInvoice IsNot Nothing AndAlso _currentLoadedInvoice.TotalBeforeDiscount > 0 AndAlso _currentLoadedInvoice.DiscountAmount > 0 Then
            Dim discountRatio As Decimal = _currentLoadedInvoice.DiscountAmount / _currentLoadedInvoice.TotalBeforeDiscount
            discountDeducted = Math.Round(totalReturnBeforeDisc * discountRatio, 2)
        End If

        Dim netRefund As Decimal = Math.Max(0, totalReturnBeforeDisc - discountDeducted)

        lblTotalReturnBeforeDisc.Text = $"{totalReturnBeforeDisc:N2} ج.م"
        lblDiscountDeduction.Text = $"{discountDeducted:N2} ج.م"
        lblNetRefund.Text = $"{netRefund:N2} ج.م"
    End Sub

    ' =========================================================
    ' حفظ وتثبيت المرتجع بالكامل
    ' =========================================================
    Private Async Sub btnSaveReturn_Click(sender As Object, e As EventArgs) Handles btnSaveReturn.Click
        ' 1. التحقق من وجود أصناف مختارة للإرجاع
        Dim selectedRows As New List(Of DataGridViewRow)()
        For Each row As DataGridViewRow In dgvReturnItems.Rows
            If Convert.ToBoolean(row.Cells("colSelect").Value) AndAlso Convert.ToDecimal(row.Cells("colReturnQty").Value) > 0 Then
                selectedRows.Add(row)
            End If
        Next

        If selectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد صنف واحد على الأقل بكمية مرتجعة صحيحة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim totalBeforeDisc As Decimal = 0
        Decimal.TryParse(lblTotalReturnBeforeDisc.Text.Replace("ج.م", "").Trim(), totalBeforeDisc)

        Dim discountVal As Decimal = 0
        Decimal.TryParse(lblDiscountDeduction.Text.Replace("ج.م", "").Trim(), discountVal)

        Dim netRefund As Decimal = 0
        Decimal.TryParse(lblNetRefund.Text.Replace("ج.م", "").Trim(), netRefund)

        Dim refundMethod As String = cmbRefundMethod.SelectedItem?.ToString()
        If String.IsNullOrEmpty(refundMethod) Then refundMethod = "نقدي من الدرج / الخزينة"

        If refundMethod = "إضافة إلى حساب العميل" AndAlso (Not _currentCustomerID.HasValue OrElse _currentCustomerID.Value <= 0) Then
            MessageBox.Show("لا يمكن إضافة المرتجع لحساب العميل لأن الفاتورة مسجلة لعميل نقدي عام. يرجى اختيار الصرف النقدي أو ربط الفاتورة بعميل محدد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRefundMethod.Focus()
            Exit Sub
        End If

        If cmbTreasury.SelectedValue Is Nothing AndAlso refundMethod = "نقدي من الدرج / الخزينة" Then
            MessageBox.Show("يرجى اختيار الخزينة التي سيتم صرف المرتجع منها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTreasury.Focus()
            Exit Sub
        End If

        Dim selectedTreasuryID As Integer = If(cmbTreasury.SelectedValue IsNot Nothing, Convert.ToInt32(cmbTreasury.SelectedValue), 1)
        Dim returnReason As String = cmbReturnReason.Text
        Dim returnNotes As String = txtReturnNotes.Text.Trim()

        ' تأكيد العملية من المستخدم
        Dim confirmMsg As String = $"هل أنت متأكد من حفظ مرتجع المبيعات بقيمة إجمالية {netRefund:N2} ج.م بطريقة: [{refundMethod}]؟"
        If MessageBox.Show(confirmMsg, "تأكيد المرتجع", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        btnSaveReturn.Enabled = False

        Try
            Dim newReturnNum As String = Await SaveReturnTransactionAsync(selectedRows, totalBeforeDisc, discountVal, netRefund, refundMethod, selectedTreasuryID, returnReason, returnNotes)
            _lastSavedReturnNumber = newReturnNum

            MessageBox.Show($"✅ تم حفظ فاتورة المرتجع رقم [{newReturnNum}] بنجاح، وتحديث المخزون والخزينة وحساب الوردية والعميل.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' اقتراح طباعة الإيصال
            If MessageBox.Show("هل ترغب في طباعة إيصال المرتجع الآن؟", "طباعة الإيصال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                PrintReturnReceipt(newReturnNum, selectedRows, netRefund, refundMethod)
            End If

            ClearForm()

        Catch ex As Exception
            MessageBox.Show("فشلت عملية حفظ المرتجع: " & ex.Message, "خطأ في قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnSaveReturn.Enabled = True
        End Try
    End Sub

    Private Async Function SaveReturnTransactionAsync(selectedRows As List(Of DataGridViewRow), totalBeforeDisc As Decimal, discountVal As Decimal, netRefund As Decimal, refundMethod As String, treasuryID As Integer, reason As String, notes As String) As Task(Of String)
        Dim returnNumber As String = $"RET-{DateTime.Now:yyyyMMdd}-{DateTime.Now:HHmmss}"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Await conn.OpenAsync()

            Using trans As SqlTransaction = conn.BeginTransaction()
                Try
                    Dim currentShiftID As Integer = If(ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, 1)
                    Dim currentUserID As Integer = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1)
                    Dim currentStoreID As Integer = 1
                    Integer.TryParse(SettingsManager.GetSettingOrDefault("CurrentStoreID", "1"), currentStoreID)

                    Dim origInvNum As String = If(_currentLoadedInvoice IsNot Nothing, _currentLoadedInvoice.InvoiceNumber, "صنف حر")
                    Dim finalNotes As String = $"مرتجع مبيعات للفاتورة #{origInvNum} | السبب: {reason}"
                    If Not String.IsNullOrEmpty(notes) Then finalNotes &= " | " & notes

                    ' 1. تسجيل فاتورة المرتجع في SalesInvoices بقيم سالبة للتكامل مع التقارير
                    Dim sqlInv As String = "
                        INSERT INTO SalesInvoices 
                        (InvoiceNumber, InvoiceDate, OrderType, ShiftID, UserID, CustomerID, BranchID, StoreID, 
                         DeliveryFee, TotalBeforeDiscount, DiscountAmount, NetTotal, PaidAmount, RemainingAmount, 
                         IsCredit, TreasuryID, PaymentType, Notes, IsActive, IsDeleted, CreatedAt)
                        VALUES 
                        (@InvNum, GETDATE(), @OrderType, @ShiftID, @UserID, @CustID, 1, @StoreID, 
                         0, @TotalBefore, @Discount, @NetTotal, @Paid, 0, 
                         @IsCredit, @TreasuryID, @PayType, @Notes, 1, 0, GETDATE());
                        SELECT SCOPE_IDENTITY();
                    "

                    Dim newInvoiceID As Integer = 0
                    Using cmdInv As New SqlCommand(sqlInv, conn, trans)
                        cmdInv.Parameters.AddWithValue("@InvNum", returnNumber)
                        cmdInv.Parameters.AddWithValue("@OrderType", If(_currentLoadedInvoice IsNot Nothing, _currentLoadedInvoice.OrderType, CByte(1)))
                        cmdInv.Parameters.AddWithValue("@ShiftID", currentShiftID)
                        cmdInv.Parameters.AddWithValue("@UserID", currentUserID)
                        cmdInv.Parameters.AddWithValue("@CustID", If(_currentCustomerID.HasValue, _currentCustomerID.Value, CType(DBNull.Value, Object)))
                        cmdInv.Parameters.AddWithValue("@StoreID", currentStoreID)
                        cmdInv.Parameters.AddWithValue("@TotalBefore", -totalBeforeDisc)
                        cmdInv.Parameters.AddWithValue("@Discount", -discountVal)
                        cmdInv.Parameters.AddWithValue("@NetTotal", -netRefund)
                        cmdInv.Parameters.AddWithValue("@Paid", If(refundMethod <> "إضافة إلى حساب العميل", -netRefund, 0))
                        cmdInv.Parameters.AddWithValue("@IsCredit", (refundMethod = "إضافة إلى حساب العميل"))
                        cmdInv.Parameters.AddWithValue("@TreasuryID", If(refundMethod = "نقدي من الدرج / الخزينة", treasuryID, CType(DBNull.Value, Object)))
                        cmdInv.Parameters.AddWithValue("@PayType", "مرتجع - " & refundMethod)
                        cmdInv.Parameters.AddWithValue("@Notes", finalNotes)

                        Dim obj = cmdInv.ExecuteScalar()
                        newInvoiceID = Convert.ToInt32(obj)
                    End Using

                    ' 2. تسجيل تفاصيل الأصناف المرتجعة وإعادة خامات الريسيبي
                    For Each row In selectedRows
                        Dim pID As Integer = Convert.ToInt32(row.Cells("colProductID").Value)
                        Dim pName As String = row.Cells("colProductName").Value.ToString()
                        Dim sName As String = row.Cells("colSizeName").Value?.ToString()
                        Dim addons As String = row.Cells("colAddonsText").Value?.ToString()
                        Dim uPrice As Decimal = Convert.ToDecimal(row.Cells("colUnitPrice").Value)
                        Dim rQty As Decimal = Convert.ToDecimal(row.Cells("colReturnQty").Value)
                        Dim rTotal As Decimal = Convert.ToDecimal(row.Cells("colTotalPrice").Value)
                        Dim shouldRestoreStock As Boolean = Convert.ToBoolean(row.Cells("colRestoreStock").Value)
                        Dim itemNote As String = row.Cells("colItemNotes").Value?.ToString()

                        Dim sqlDet As String = "
                            INSERT INTO SalesInvoiceDetails 
                            (InvoiceID, ProductID, ProductName, SizeName, AddonsText, UnitPrice, Quantity, TotalPrice, Notes)
                            VALUES 
                            (@InvID, @ProductID, @ProductName, @SizeName, @AddonsText, @UnitPrice, @Quantity, @TotalPrice, @Notes);
                        "
                        Using cmdDet As New SqlCommand(sqlDet, conn, trans)
                            cmdDet.Parameters.AddWithValue("@InvID", newInvoiceID)
                            cmdDet.Parameters.AddWithValue("@ProductID", pID)
                            cmdDet.Parameters.AddWithValue("@ProductName", pName)
                            cmdDet.Parameters.AddWithValue("@SizeName", If(String.IsNullOrEmpty(sName), DBNull.Value, sName))
                            cmdDet.Parameters.AddWithValue("@AddonsText", If(String.IsNullOrEmpty(addons), DBNull.Value, addons))
                            cmdDet.Parameters.AddWithValue("@UnitPrice", uPrice)
                            cmdDet.Parameters.AddWithValue("@Quantity", -rQty)
                            cmdDet.Parameters.AddWithValue("@TotalPrice", -rTotal)
                            cmdDet.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(itemNote), "مرتجع", itemNote))
                            cmdDet.ExecuteNonQuery()
                        End Using

                        ' إعادة خامات ومخزون الصنف إن تم تحديد ذلك
                        If shouldRestoreStock Then
                            Try
                                InventoryDeductionManager.RestoreItemRecipe(conn, trans, currentStoreID, pID, Nothing, Nothing, rQty, returnNumber)
                            Catch exStock As Exception
                                Debug.WriteLine("Stock restore error: " & exStock.Message)
                            End Try
                        End If
                    Next

                    ' 3. في حالة الصرف النقدي: تحديث نقديات الوردية وصرف من الخزينة
                    If refundMethod = "نقدي من الدرج / الخزينة" AndAlso netRefund > 0 Then
                        ' تحديث إجمالي مرتجعات الوردية في الداتا بيز
                        Dim sqlShift As String = "UPDATE Shifts SET TotalRefunds = ISNULL(TotalRefunds, 0) + @Ref WHERE ShiftID = @ShiftID;"
                        Using cmdShift As New SqlCommand(sqlShift, conn, trans)
                            cmdShift.Parameters.AddWithValue("@Ref", netRefund)
                            cmdShift.Parameters.AddWithValue("@ShiftID", currentShiftID)
                            cmdShift.ExecuteNonQuery()
                        End Using

                        ' تحديث كائن الوردية في الرام
                        If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing AndAlso ShiftSession.CurrentShift.ShiftID = currentShiftID Then
                            ShiftSession.CurrentShift.TotalRefunds += netRefund
                        End If

                        ' تسجيل حركة صرف نقدية في الخزينة
                        Await TreasuryService.AddTransactionAsync(
                            treasuryID:=treasuryID,
                            transactionType:=TreasuryTransactionTypes.Expense,
                            amount:=netRefund,
                            isDeposit:=False,
                            referenceID:=newInvoiceID,
                            referenceNo:=returnNumber,
                            notes:=$"صرف مرتجع مبيعات إيصال #{returnNumber} للفاتورة #{origInvNum}",
                            userID:=currentUserID,
                            cn:=conn,
                            trans:=trans
                        )
                    End If

                    ' 4. في حالة إضافة المرتجع لحساب العميل (تنزيل من مديونيته)
                    If refundMethod = "إضافة إلى حساب العميل" AndAlso _currentCustomerID.HasValue AndAlso netRefund > 0 Then
                        Dim newBalance As Decimal = _currentCustomerBalance + netRefund

                        ' تحديث رصيد العميل
                        Dim sqlCust As String = "UPDATE Customers SET CurrentBalance = @NewBal, LastTransactionDate = GETDATE(), updated_at = SYSUTCDATETIME() WHERE CustomerID = @CID;"
                        Using cmdCust As New SqlCommand(sqlCust, conn, trans)
                            cmdCust.Parameters.AddWithValue("@NewBal", newBalance)
                            cmdCust.Parameters.AddWithValue("@CID", _currentCustomerID.Value)
                            cmdCust.ExecuteNonQuery()
                        End Using

                        ' تسجيل حركة كشف حساب العميل
                        Dim sqlCustTrans As String = "
                            INSERT INTO CustomerTransactions 
                            (TransactionDate, CustomerID, InvoiceID, BranchID, TransactionType, Debit, Credit, BalanceAfter, Notes, ShiftID, UserID, CreatedAt)
                            VALUES 
                            (GETDATE(), @CID, @InvoiceID, 1, N'مرتجع مبيعات', 0, @Credit, @BalanceAfter, @Notes, @ShiftID, @UserID, GETDATE());
                        "
                        Using cmdTrans As New SqlCommand(sqlCustTrans, conn, trans)
                            cmdTrans.Parameters.AddWithValue("@CID", _currentCustomerID.Value)
                            cmdTrans.Parameters.AddWithValue("@InvoiceID", newInvoiceID)
                            cmdTrans.Parameters.AddWithValue("@Credit", netRefund)
                            cmdTrans.Parameters.AddWithValue("@BalanceAfter", newBalance)
                            cmdTrans.Parameters.AddWithValue("@Notes", $"مرتجع مبيعات للفاتورة #{origInvNum} ({returnNumber})")
                            cmdTrans.Parameters.AddWithValue("@ShiftID", currentShiftID)
                            cmdTrans.Parameters.AddWithValue("@UserID", currentUserID)
                            cmdTrans.ExecuteNonQuery()
                        End Using
                    End If

                    trans.Commit()

                Catch ex As Exception
                    Try
                        trans.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using

        Return returnNumber
    End Function

    ' =========================================================
    ' طباعة إيصال المرتجع
    ' =========================================================
    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click
        If String.IsNullOrEmpty(_lastSavedReturnNumber) Then
            MessageBox.Show("لم يتم حفظ أي مرتجع بعد لطباعة إيصاله!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedRows As New List(Of DataGridViewRow)()
        For Each row As DataGridViewRow In dgvReturnItems.Rows
            If Convert.ToBoolean(row.Cells("colSelect").Value) Then selectedRows.Add(row)
        Next

        Dim netRefund As Decimal = 0
        Decimal.TryParse(lblNetRefund.Text.Replace("ج.م", "").Trim(), netRefund)

        PrintReturnReceipt(_lastSavedReturnNumber, selectedRows, netRefund, cmbRefundMethod.Text)
    End Sub

    Private Sub PrintReturnReceipt(retNum As String, rows As List(Of DataGridViewRow), netVal As Decimal, payType As String)
        Try
            Dim doc As New Printing.PrintDocument()
            AddHandler doc.PrintPage,
                Sub(s, ev)
                    Dim g As Graphics = ev.Graphics
                    Dim fontTitle As New Font("Segoe UI", 13, FontStyle.Bold)
                    Dim fontHeader As New Font("Segoe UI", 9.5!, FontStyle.Bold)
                    Dim fontBody As New Font("Segoe UI", 8.5!, FontStyle.Regular)
                    Dim sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    Dim sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}

                    Dim y As Single = 20
                    Dim w As Single = ev.MarginBounds.Width
                    Dim leftM As Single = ev.MarginBounds.Left

                    g.DrawString("سستمك لنقاط البيع والمطاعم", fontHeader, Brushes.Gray, New RectangleF(leftM, y, w, 20), sfCenter)
                    y += 24
                    g.DrawString("إيصال مرتجع مبيعات", fontTitle, Brushes.Black, New RectangleF(leftM, y, w, 25), sfCenter)
                    y += 30

                    g.DrawLine(Pens.Gray, leftM, y, leftM + w, y)
                    y += 8

                    Dim infoText As String = $"رقم الإيصال: {retNum}" & vbCrLf &
                                            $"التاريخ: {DateTime.Now:yyyy/MM/dd HH:mm}" & vbCrLf &
                                            $"العميل: {_currentCustomerName}" & vbCrLf &
                                            $"طريقة الصرف: {payType}"
                    g.DrawString(infoText, fontBody, Brushes.Black, New RectangleF(leftM, y, w, 65), sfRight)
                    y += 70

                    g.DrawLine(Pens.Gray, leftM, y, leftM + w, y)
                    y += 8

                    ' رسم رؤوس الأصناف
                    g.DrawString("الصنف", fontHeader, Brushes.Black, New RectangleF(leftM + w * 0.45!, y, w * 0.55!, 20), sfRight)
                    g.DrawString("الكمية", fontHeader, Brushes.Black, New RectangleF(leftM + w * 0.25!, y, w * 0.2!, 20), sfCenter)
                    g.DrawString("الإجمالي", fontHeader, Brushes.Black, New RectangleF(leftM, y, w * 0.25!, 20), sfCenter)
                    y += 22

                    g.DrawLine(Pens.LightGray, leftM, y, leftM + w, y)
                    y += 5

                    For Each r In rows
                        Dim pName = r.Cells("colProductName").Value?.ToString()
                        Dim qty = r.Cells("colReturnQty").Value?.ToString()
                        Dim total = Convert.ToDecimal(r.Cells("colTotalPrice").Value).ToString("N2")

                        g.DrawString(pName, fontBody, Brushes.Black, New RectangleF(leftM + w * 0.45!, y, w * 0.55!, 18), sfRight)
                        g.DrawString(qty, fontBody, Brushes.Black, New RectangleF(leftM + w * 0.25!, y, w * 0.2!, 18), sfCenter)
                        g.DrawString(total, fontBody, Brushes.Black, New RectangleF(leftM, y, w * 0.25!, 18), sfCenter)
                        y += 20
                    Next

                    y += 10
                    g.DrawLine(Pens.Gray, leftM, y, leftM + w, y)
                    y += 8

                    g.DrawString($"صافي المبلغ المسترد: {netVal:N2} ج.م", fontTitle, Brushes.Black, New RectangleF(leftM, y, w, 25), sfCenter)
                    y += 30

                    g.DrawString("شكراً لتعاملكم معنا", fontBody, Brushes.Gray, New RectangleF(leftM, y, w, 20), sfCenter)
                    ev.HasMorePages = False
                End Sub

            Dim prev As New PrintPreviewDialog()
            prev.Document = doc
            prev.WindowState = FormWindowState.Normal
            prev.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء معاينة الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' أزرار الهيدر
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.Close()
            Return True
        ElseIf keyData = Keys.F10 Then
            btnSaveReturn.PerformClick()
            Return True
        ElseIf keyData = Keys.F5 Then
            btnNewReturn.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class