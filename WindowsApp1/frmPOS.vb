'Public Class frmPOS
'    Private _repo As POSRepository



'    ' متغيرات حفظ معلومات نوع الطلب المختار
'    Public Enum OrderType
'        Takeaway = 1
'        DineIn = 2
'        Delivery = 3
'    End Enum


'    Public Property CurrentOrderType As OrderType = OrderType.Takeaway
'    Public Property SelectedTableID As Integer? = Nothing
'    Public Property SelectedTableName As String = ""
'    Public Property SelectedDriverID As Integer? = Nothing
'    Public Property SelectedDriverName As String = ""
'    Public Property DeliveryFee As Decimal = 0
'    Public Property CurrentCustomer As CustomerModel

'    'Dim currentShiftID As Integer = ShiftManager.CurrentShift.ShiftID
'    'Dim currentTreasuryID As Integer = ShiftManager.CurrentShift.TreasuryID

'    ' إرسال currentShiftID لجدول الفواتير (Invoices/Sales)

'    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        _repo = New POSRepository(DBModule.ConnectionString)
'        LoadCategories()
'        datagridviewsetup(dgvInvoice)
'        SetupInvoiceGrid()
'        Dim Drag0 As FormDragHelper = New FormDragHelper(Me, panelHeader)
'        Dim Drag1 As FormDragHelper = New FormDragHelper(Me, Guna2HtmlLabel1)
'        Dim Drag2 As FormDragHelper = New FormDragHelper(Me, Label8)
'        Dim Drag4 As FormDragHelper = New FormDragHelper(Me, lblCurrentShift)
'        Dim Drag5 As FormDragHelper = New FormDragHelper(Me, Label4)
'        Dim Drag6 As FormDragHelper = New FormDragHelper(Me, Label10)
'        Dim Drag7 As FormDragHelper = New FormDragHelper(Me, lblDateTime)
'        If Session.CurrentUserfullName IsNot Nothing AndAlso String.IsNullOrEmpty(Session.CurrentUserfullName) = False Then
'            lblUser_fullName.Text = Session.CurrentUserfullName
'        End If

'        Timer1.Start()
'        ' ضبط التيك أوي كاختيار افتراضي
'        btnTakeaway.Checked = True
'        CurrentOrderType = OrderType.Takeaway
'    End Sub

'    Private Sub frmPOS_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
'        If Not CheckAndEnsureActiveShift() Then
'            ' لو مفيش وردية والكاشير رفض يفتح وردية أو قفل الشاشة بدون فتح وردية
'            ' نستخدم BeginInvoke حتى تكتمل جميع الأحداث المتعلقة بظهور الفورم (مثل Guna2 ShadowForm) قبل الإغلاق
'            Me.BeginInvoke(Sub() Me.Close())
'        Else
'            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
'                lblCurrentShift.Text = ShiftSession.CurrentShift.WorkShiftName
'            End If
'        End If
'    End Sub

'   
'    ' ==========================================
'    ' 1. رسم الأقسام داخل flpCategories
'    ' ==========================================
'    Private Sub LoadCategories()
'        Dim categories = _repo.GetCategories()

'        flpCategories.SuspendLayout()
'        Try
'            flpCategories.Controls.Clear()

'            For Each cat As CategoryModel In categories
'                Dim card As New UCCategoryCard With {
'                    .Width = 130,
'                    .Height = 140,
'                    .Category = cat
'                }

'                ' استلام حدث الضغط على القسم
'                AddHandler card.CategoryClicked, AddressOf CategoryCard_Click

'                flpCategories.Controls.Add(card)
'            Next
'        Finally
'            flpCategories.ResumeLayout()
'        End Try
'    End Sub

'    ' عند الضغط على كارت قسم
'    Private Sub CategoryCard_Click(category As CategoryModel)
'        ' جلب أصناف هذا القسم ورسمها
'        LoadProducts(category.Category_ID)
'    End Sub


'    ' ==========================================
'    ' 2. رسم الأصناف داخل flpProducts
'    ' ==========================================
'    Private Sub LoadProducts(categoryID As Integer)
'        Dim products = _repo.GetProductsByCategoryID(categoryID)

'        flpProducts.SuspendLayout()
'        Try
'            flpProducts.Controls.Clear()

'            For Each prod As ProductModel In products
'                Dim card As New UCProductCard With {
'                    .Width = 140,
'                    .Height = 150,
'                    .Product = prod
'                }

'                ' استلام حدث الضغط على الصنف
'                AddHandler card.ProductClicked, AddressOf ProductCard_Click

'                flpProducts.Controls.Add(card)
'            Next
'        Finally
'            flpProducts.ResumeLayout()
'        End Try
'    End Sub

'    ' ==========================================
'    ' حدث الضغط على كارت الصنف في شاشة البيع
'    ' ==========================================
'    Private Sub ProductCard_Click(product As ProductModel)

'        ' 1. فتح فورم خيارات الصنف (الأحجام والإضافات) كـ Dialog
'        Using frmOptions As New FrmProductOptions(product, _repo)

'            ' 2. التحقق مما إذا كان الكاشير قد ضغط على زر "إضافة" (DialogResult.OK)
'            If frmOptions.ShowDialog() = DialogResult.OK Then

'                ' 3. استلام كافة العناصر المختارة ببيانات الأحجام والإضافات وإضافتها للفاتورة
'                For Each selectedItem In frmOptions.ResultOrderItems
'                    AddItemToInvoice(selectedItem)
'                Next

'            End If

'        End Using

'    End Sub
'    ' ==========================================
'    ' دالة إدراج العنصر المختار داخل الفاتورة
'    ' ==========================================
'    Private Sub AddItemToInvoice(item As OrderItemModel)
'        ' 1. نص الحجم
'        Dim sizeName As String = If(item.SelectedSize IsNot Nothing, item.SelectedSize.SizeInfo.SizeNameAr, "عادي")

'        ' 2. نص الإضافات
'        Dim addonsList As New List(Of String)
'        For Each addon In item.SelectedAddons
'            addonsList.Add(addon.AddonInfo.AddonNameAr)
'        Next
'        Dim addonsText As String = If(addonsList.Count > 0, String.Join(", ", addonsList), "-")

'        ' 3. حساب سعر القطعة الواحدة (حجم + إضافات)
'        Dim baseSizePrice As Decimal = If(item.SelectedSize IsNot Nothing, item.SelectedSize.SalePrice, 0)
'        Dim addonsTotalPrice As Decimal = 0
'        For Each addon In item.SelectedAddons
'            addonsTotalPrice += addon.SalePrice
'        Next
'        Dim singleUnitPrice As Decimal = baseSizePrice + addonsTotalPrice

'        ' 4. إضافة الصف للجدول
'        Dim rowIndex As Integer = dgvInvoice.Rows.Add(
'        dgvInvoice.Rows.Count + 1, ' الرقم التسلسلي
'        item.ProductName,
'        sizeName,
'        addonsText,
'        singleUnitPrice,
'        item.Quantity,
'        item.TotalPrice,
'        item.Notes,
'        item.Product_ID
'    )

'        ' 5. إعادة تحديث الإجمالي الكلي للفاتورة
'        CalculateInvoiceGrandTotal()
'    End Sub

'    ' دالة حاسبة للإجمالي العام أسفل الشاشة
'    Private Sub CalculateInvoiceGrandTotal()
'        Dim grandTotal As Decimal = 0

'        For Each row As DataGridViewRow In dgvInvoice.Rows
'            grandTotal += Convert.ToDecimal(row.Cells("colTotalPrice").Value)
'        Next

'        ' lblGrandTotal.Text = grandTotal.ToString("N2") & " EGP"
'    End Sub

'    

'    Private Sub btnAddCategoryForm_Click(sender As Object, e As EventArgs) Handles btnAddCategoryForm.Click
'        Dim frm As New Categories()
'        frm.ShowDialog()
'        LoadCategories()
'    End Sub



'    Private Sub btnDineIn_Click(sender As Object, e As EventArgs) Handles btnDineIn.Click
'        CurrentOrderType = OrderType.DineIn
'        SelectedDriverID = Nothing
'        SelectedDriverName = ""
'        DeliveryFee = 0
'        lblDeliveryFee.Text = 0.00
'        ' فتح فورم الطاولات
'        Using frmTables As New FrmSelectTable(_repo)
'            If frmTables.ShowDialog() = DialogResult.OK Then

'                ' حفظ بيانات الطاولة المختارة
'                SelectedTableID = frmTables.SelectedTableID
'                SelectedTableName = frmTables.SelectedTableName

'                lblOrderTypeStatus.Text = "نوع الطلب: صالة | الطاولة: " & SelectedTableName

'                CalculateInvoiceGrandTotal()
'            Else
'                ' في حالة الإلغاء نرجع للتيك أوي افتراضياً
'                btnTakeaway.Checked = True
'                btnTakeaway_Click(Nothing, Nothing)
'            End If
'        End Using
'    End Sub








'    
'    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click

'    End Sub

'    'Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
'    '    ' =========================================================
'    '    ' 1. التحققات الأساسية قبل فتح شاشة الدفع (Validation)
'    '    ' =========================================================

'    '    ' أ) التأكد من أن الفاتورة ليست فارغة
'    '    If dgvInvoice.Rows.Count = 0 Then
'    '        MessageBox.Show("لا يمكن إتمام عملية الدفع بفاتورة فارغة! برجاء إضافة أصناف أولاً.",
'    '                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    '        Return
'    '    End If

'    '    ' ب) التحقق من تحديد الطاولة إذا كان نوع الطلب (صالة)
'    '    If CurrentOrderType = OrderType.DineIn AndAlso Not SelectedTableID.HasValue Then
'    '        MessageBox.Show("برجاء تحديد رقم الطاولة أولاً لطلبات الصالة!",
'    '                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    '        Return
'    '    End If

'    '    ' ج) التحقق من العميل والطيار إذا كان نوع الطلب (دليفري)
'    '    If CurrentOrderType = OrderType.Delivery Then
'    '        If CurrentCustomer Is Nothing Then
'    '            MessageBox.Show("برجاء تحديد بيانات العميل أولاً لطلبات الدليفري!",
'    '                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    '            Return
'    '        End If

'    '        If Not SelectedDriverID.HasValue Then
'    '            MessageBox.Show("برجاء تحديد طيار التوصيل أولاً لطلبات الدليفري!",
'    '                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    '            Return
'    '        End If
'    '    End If


'    '    ' =========================================================
'    '    ' 2. حساب إجمالي الفاتورة مع رسوم التوصيل
'    '    ' =========================================================
'    '    Dim itemsTotal As Decimal = GetInvoiceTotalFromGrid()
'    '    Dim finalInvoiceTotal As Decimal = itemsTotal

'    '    ' إضافة رسوم التوصيل إذا كان نوع الطلب دليفري
'    '    If CurrentOrderType = OrderType.Delivery Then
'    '        finalInvoiceTotal += DeliveryFee
'    '    End If


'    '    ' =========================================================
'    '    ' 3. فتح شاشة الدفع السريع تمرير البيانات واستقبال النتائج
'    '    ' =========================================================
'    '    Using frmPay As New FrmQuickPayment(finalInvoiceTotal, CurrentCustomer)

'    '        If frmPay.ShowDialog() = DialogResult.OK Then

'    '            ' استلام نتائج الحسابات من شاشة الدفع
'    '            Dim totalBeforeDiscount As Decimal = frmPay.FinalGrandTotal ' الإجمالي قبل الخصم
'    '            Dim totalDiscount As Decimal = frmPay.TotalDiscount        ' إجمالي الخصم (افتراضي + يدوي)
'    '            Dim netTotal As Decimal = frmPay.NetTotal                  ' الصافي بعد الخصم
'    '            Dim paidAmount As Decimal = frmPay.PaidAmount              ' المدفوع
'    '            Dim remainingAmount As Decimal = frmPay.RemainingAmount    ' المتبقي على العميل
'    '            Dim treasuryID As Integer = frmPay.SelectedTreasuryID      ' الخزنة المختارة
'    '            Dim isCredit As Boolean = frmPay.IsCreditOrder             ' هل الفاتورة آجل؟

'    '            ' =========================================================
'    '            ' 4. عرض ملخص النتيجة مؤقتاً (لحين برمجة الحفظ في الداتا بيز)
'    '            ' =========================================================
'    '            Dim payTypeStr As String = If(isCredit, "آجل", "نقدي")

'    '            MessageBox.Show("تم تأكيد بيانات الدفع بنجاح!" & vbCrLf &
'    '                        "طريقة الدفع: " & payTypeStr & vbCrLf &
'    '                        "الإجمالي الأصلي: " & totalBeforeDiscount.ToString("N2") & " ج" & vbCrLf &
'    '                        "إجمالي الخصم: " & totalDiscount.ToString("N2") & " ج" & vbCrLf &
'    '                        "الصافي المطلوب: " & netTotal.ToString("N2") & " ج" & vbCrLf &
'    '                        "المدفوع: " & paidAmount.ToString("N2") & " ج" & vbCrLf &
'    '                        "المتبقي: " & remainingAmount.ToString("N2") & " ج",
'    '                        "عملية الدفع", MessageBoxButtons.OK, MessageBoxIcon.Information)

'    '            ' الخطوة القادمة: استدعاء دالة حفظ الفاتورة في قاعدة البيانات والطباعة
'    '            ' SaveInvoiceToDatabase(...)

'    '        End If

'    '    End Using

'    'End Sub



'    ' =========================================================
'    ' 1. دالة تفريغ الشاشة وإعادتها للوضع الافتراضي بالكامل
'    ' =========================================================
'    Private Sub ResetPOSForm()
'        ' أ) مسح جميع الصفوف من DataGridView الفاتورة
'        dgvInvoice.Rows.Clear()

'        ' ب) تفريغ اختيار العميل والطاولة والطيار ورسوم التوصيل
'        CurrentCustomer = Nothing
'        txtCustomer.Text = ""
'        SelectedTableID = Nothing
'        SelectedTableName = ""
'        SelectedDriverID = Nothing
'        SelectedDriverName = ""
'        DeliveryFee = 0
'        lblDeliveryFee.Text = "0.00"

'        ' ج) إعادة نوع الطلب للتيك أوي
'        btnTakeaway.Checked = True
'        CurrentOrderType = OrderType.Takeaway
'        lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"

'        ' د) حساب المجموع الكلي من جديد (ليكون 0.00)
'        CalculateInvoiceGrandTotal()
'    End Sub

'    ' =========================================================
'    ' 2. تحديث حدث btnPay_Click للحفظ الفعلي في الداتا بيز
'    ' =========================================================
'    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

'        ' 1. التحققات الأساسية
'        If dgvInvoice.Rows.Count = 0 Then
'            MessageBox.Show("لا يمكن إتمام عملية الدفع بفاتورة فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Return
'        End If

'        If CurrentOrderType = OrderType.DineIn AndAlso Not SelectedTableID.HasValue Then
'            MessageBox.Show("برجاء تحديد رقم الطاولة أولاً لطلبات الصالة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Return
'        End If

'        If CurrentOrderType = OrderType.Delivery Then
'            If CurrentCustomer Is Nothing Then
'                MessageBox.Show("برجاء تحديد بيانات العميل أولاً لطلبات الدليفري!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                Return
'            End If

'            If Not SelectedDriverID.HasValue Then
'                MessageBox.Show("برجاء تحديد طيار التوصيل أولاً لطلبات الدليفري!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                Return
'            End If
'        End If

'        ' 2. حساب الإجمالي
'        Dim itemsTotal As Decimal = GetInvoiceTotalFromGrid()
'        Dim finalInvoiceTotal As Decimal = itemsTotal
'        If CurrentOrderType = OrderType.Delivery Then finalInvoiceTotal += DeliveryFee

'        ' 3. فتح شاشة الدفع السريع
'        Using frmPay As New FrmQuickPayment(finalInvoiceTotal, CurrentCustomer)
'            If frmPay.ShowDialog() = DialogResult.OK Then

'                ' 4. تجهيز كائن الفاتورة للحفظ
'                Dim invoice As New InvoiceModel With {
'                    .OrderType = CByte(CurrentOrderType),
'                    .ShiftID = ShiftSession.CurrentShift.ShiftID,
'                    .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
'                    .CustomerID = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerID, CType(Nothing, Integer?)),
'                    .TableID = SelectedTableID,
'                    .DriverID = SelectedDriverID,
'                    .DeliveryFee = DeliveryFee,
'                    .TotalBeforeDiscount = frmPay.FinalGrandTotal,
'                    .DiscountAmount = frmPay.TotalDiscount,
'                    .NetTotal = frmPay.NetTotal,
'                    .PaidAmount = frmPay.PaidAmount,
'                    .RemainingAmount = frmPay.RemainingAmount,
'                    .IsCredit = frmPay.IsCreditOrder,
'                    .TreasuryID = If(frmPay.SelectedTreasuryID > 0, frmPay.SelectedTreasuryID, CType(Nothing, Integer?))
'                }

'                ' إدراج تفاصيل الأسطر من DataGridView
'                For Each row As DataGridViewRow In dgvInvoice.Rows
'                    If Not row.IsNewRow Then
'                        invoice.Details.Add(New InvoiceDetailModel With {
'                            .ProductID = Convert.ToInt32(row.Cells("colProductID").Value),
'                            .ProductName = row.Cells("colProductName").Value.ToString(),
'                            .SizeName = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), ""),
'                            .AddonsText = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), ""),
'                            .UnitPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value),
'                            .Quantity = Convert.ToInt32(row.Cells("colQuantity").Value),
'                            .TotalPrice = Convert.ToDecimal(row.Cells("colTotalPrice").Value),
'                            .Notes = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")
'                        })
'                    End If
'                Next

'                Try
'                    ' 5. حفظ الفاتورة في الداتا بيز
'                    Dim savedInvNum As String = _repo.SaveInvoice(invoice)

'                    MessageBox.Show("تم حفظ الفاتورة بنجاح برقم: " & savedInvNum, "حفظ الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information)

'                    ' 6. تفريغ الشاشة لتكون جاهزة للفاتورة التالية
'                    ResetPOSForm()

'                Catch ex As Exception
'                    MessageBox.Show("حدث خطأ أثناء حفظ الفاتورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                End Try

'            End If
'        End Using

'    End Sub

'    ' =========================================================
'    ' 3. زر تعليق الفاتورة الحالي (btnHoldInvoice)
'    ' =========================================================
'    Private Sub btnHoldInvoice_Click(sender As Object, e As EventArgs) Handles btnHoldInvoice.Click
'        If dgvInvoice.Rows.Count = 0 Then
'            MessageBox.Show("لا يمكن تعليق فاتورة فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Return
'        End If

'        ' تجميع تفاصيل الأسطر بأسلوب نصي مبسط
'        Dim itemsList As New List(Of String)
'        For Each row As DataGridViewRow In dgvInvoice.Rows
'            If Not row.IsNewRow Then
'                Dim pID As String = row.Cells("colProductID").Value.ToString()
'                Dim pName As String = row.Cells("colProductName").Value.ToString()
'                Dim sz As String = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), "")
'                Dim ad As String = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), "")
'                Dim pr As String = row.Cells("colUnitPrice").Value.ToString()
'                Dim qty As String = row.Cells("colQuantity").Value.ToString()
'                Dim tot As String = row.Cells("colTotalPrice").Value.ToString()
'                Dim nt As String = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")

'                itemsList.Add($"{pID}|{pName}|{sz}|{ad}|{pr}|{qty}|{tot}|{nt}")
'            End If
'        Next

'        Dim jsonItems As String = String.Join("~", itemsList)

'        ' تجهيز كائن الفاتورة المعلقة
'        Dim pendingInv As New PendingInvoiceModel With {
'            .ShiftID = ShiftSession.CurrentShift.ShiftID,
'            .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
'            .OrderType = CByte(CurrentOrderType),
'            .CustomerID = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerID, CType(Nothing, Integer?)),
'            .CustomerName = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerName, ""),
'            .TableID = SelectedTableID,
'            .TableName = SelectedTableName,
'            .DriverID = SelectedDriverID,
'            .DriverName = SelectedDriverName,
'            .DeliveryFee = DeliveryFee,
'            .InvoiceJSON = jsonItems,
'            .TotalAmount = GetInvoiceTotalFromGrid()
'        }

'        If _repo.SavePendingInvoice(pendingInv) Then
'            MessageBox.Show("تم تعليق الفاتورة بنجاح!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            ResetPOSForm()
'        End If
'    End Sub

'    ' =========================================================
'    ' 4. زر عرض واسترجاع الفواتير المعلقة (btnPendingInvoices)
'    ' =========================================================
'    Private Sub btnPendingInvoices_Click(sender As Object, e As EventArgs) Handles btnPendingInvoices.Click
'        Using frmPending As New FrmPendingInvoices(_repo)
'            If frmPending.ShowDialog() = DialogResult.OK Then

'                Dim pendingItem = frmPending.SelectedPendingInvoice
'                If pendingItem IsNot Nothing Then

'                    ' أ) تفريغ الشاشة الحالية أولاً
'                    ResetPOSForm()

'                    ' ب) استرجاع نوع الطلب والبيانات
'                    CurrentOrderType = CType(pendingItem.OrderType, OrderType)
'                    Select Case CurrentOrderType
'                        Case OrderType.Takeaway
'                            btnTakeaway.Checked = True
'                        Case OrderType.DineIn
'                            btnDineIn.Checked = True
'                            SelectedTableID = pendingItem.TableID
'                            SelectedTableName = pendingItem.TableName
'                            lblOrderTypeStatus.Text = "نوع الطلب: صالة | الطاولة: " & SelectedTableName
'                        Case OrderType.Delivery
'                            btnDelivery.Checked = True
'                            SelectedDriverID = pendingItem.DriverID
'                            SelectedDriverName = pendingItem.DriverName
'                            DeliveryFee = pendingItem.DeliveryFee
'                            lblDeliveryFee.Text = DeliveryFee.ToString("N2")
'                            lblOrderTypeStatus.Text = "نوع الطلب: دليفري | الطيار: " & SelectedDriverName
'                    End Select

'                    ' ج) استرجاع تفاصيل الأسطر
'                    Dim rowsData() As String = pendingItem.InvoiceJSON.Split("~"c)
'                    For Each rData In rowsData
'                        Dim parts() As String = rData.Split("|"c)
'                        If parts.Length >= 8 Then
'                            dgvInvoice.Rows.Add(
'                                dgvInvoice.Rows.Count + 1,
'                                parts(1), ' ProductName
'                                parts(2), ' Size
'                                parts(3), ' Addons
'                                Convert.ToDecimal(parts(4)), ' Price
'                                Convert.ToInt32(parts(5)),   ' Qty
'                                Convert.ToDecimal(parts(6)), ' Total
'                                parts(7), ' Notes
'                                Convert.ToInt32(parts(0))    ' ProductID
'                            )
'                        End If
'                    Next

'                    CalculateInvoiceGrandTotal()

'                    ' د) إغلاق الفاتورة المعلقة من الداتا بيز بعد استرجاعها
'                    _repo.DeletePendingInvoice(pendingItem.PendingID)

'                End If

'            End If
'        End Using
'    End Sub

'    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
'        ResetPOSForm()
'    End Sub
'End Class


Public Class frmPOS
    Private _repo As POSRepository

    Public Enum OrderType
        Takeaway = 1
        DineIn = 2
        Delivery = 3
    End Enum

    Public Property CurrentOrderType As OrderType = OrderType.Takeaway
    Public Property SelectedTableID As Integer? = Nothing
    Public Property SelectedTableName As String = ""
    Public Property SelectedDriverID As Integer? = Nothing
    Public Property SelectedDriverName As String = ""
    Public Property DeliveryFee As Decimal = 0
    Public Property IsDineInServiceFeePercent As Boolean = If(SettingsManager.GetSetting("IsDineInServiceFeePercent"), "false")
    Public Property DineInServiceFee As Decimal = If(SettingsManager.GetSetting("DineInServiceFee"), "0")
    Public Property TaxAmount As Decimal = 0
    Public Property CurrentCustomer As CustomerModel

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _repo = New POSRepository(DBModule.ConnectionString)
        LoadCategories()
        datagridviewsetup(dgvInvoice)
        SetupInvoiceGrid()
        Dim Drag0 As FormDragHelper = New FormDragHelper(Me, panelHeader)
        Dim Drag1 As FormDragHelper = New FormDragHelper(Me, Guna2HtmlLabel1)
        Dim Drag2 As FormDragHelper = New FormDragHelper(Me, Label8)
        Dim Drag3 As FormDragHelper = New FormDragHelper(Me, lblUser_fullName)
        Dim Drag4 As FormDragHelper = New FormDragHelper(Me, lblCurrentShift)
        Dim Drag5 As FormDragHelper = New FormDragHelper(Me, Label4)
        Dim Drag6 As FormDragHelper = New FormDragHelper(Me, Label10)
        Dim Drag7 As FormDragHelper = New FormDragHelper(Me, lblDateTime)
        If Session.CurrentUserfullName IsNot Nothing AndAlso String.IsNullOrEmpty(Session.CurrentUserfullName) = False Then
            lblUser_fullName.Text = Session.CurrentUserfullName
        End If

        Timer1.Start()
        btnTakeaway.Checked = True
        CurrentOrderType = OrderType.Takeaway

        ApplyDefaultPOSSettings()
        ' تحديث رقم الفاتورة القادمة
        UpdateNextInvoiceNumber()
    End Sub
    Private Sub frmPOS_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not CheckAndEnsureActiveShift() Then
            ' لو مفيش وردية والكاشير رفض يفتح وردية أو قفل الشاشة بدون فتح وردية
            ' نستخدم BeginInvoke حتى تكتمل جميع الأحداث المتعلقة بظهور الفورم (مثل Guna2 ShadowForm) قبل الإغلاق
            Me.BeginInvoke(Sub() Me.Close())
        Else
            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                lblCurrentShift.Text = ShiftSession.CurrentShift.WorkShiftName
            End If
        End If
    End Sub
    Private Sub ApplyDefaultPOSSettings()
        Try
            ' =========================================================
            ' 1. تعيين نوع الطلب الافتراضي
            ' =========================================================
            Dim defaultOrderTypeVal As String = If(SettingsManager.GetSetting("DefaultOrderType"), "1")
            Dim orderTypeInt As Integer = 1
            Integer.TryParse(defaultOrderTypeVal, orderTypeInt)

            Select Case orderTypeInt
                Case 2 ' صالة
                    btnDineIn.Checked = True
                    CurrentOrderType = OrderType.DineIn
                    lblOrderTypeStatus.Text = "نوع الطلب: صالة"
                Case 3 ' دليفري
                    btnDelivery.Checked = True
                    CurrentOrderType = OrderType.Delivery
                    lblOrderTypeStatus.Text = "نوع الطلب: دليفري"
                    ApplyDefaultDriver() ' تعيين الطيار الافتراضي ورسوم التوصيل تلقائياً
                Case Else ' تيك أوي (1)
                    btnTakeaway.Checked = True
                    CurrentOrderType = OrderType.Takeaway
                    lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"
            End Select

            ' =========================================================
            ' 2. تعيين العميل الافتراضي
            ' =========================================================
            Dim defaultCustIDStr As String = If(SettingsManager.GetSetting("DefaultCustomerID"), "")
            Dim custID As Integer = 0

            If Integer.TryParse(defaultCustIDStr, custID) AndAlso custID > 0 Then
                Dim activeCustomers = _repo.GetActiveCustomers()
                Dim defaultCust = activeCustomers.FirstOrDefault(Function(c) c.CustomerID = custID)

                If defaultCust IsNot Nothing Then
                    CurrentCustomer = defaultCust
                    txtCustomer.Text = defaultCust.CustomerName
                End If
            End If

        Catch ex As Exception
            ' في حال حدوث أي خطأ نرجع للقيم الأساسية
            btnTakeaway.Checked = True
            CurrentOrderType = OrderType.Takeaway
        End Try
    End Sub
    Private Sub ApplyDefaultDriver()
        Try
            Dim defaultDriverIDStr As String = If(SettingsManager.GetSetting("DefaultDriverID"), "")
            Dim drvID As Integer = 0

            If Integer.TryParse(defaultDriverIDStr, drvID) AndAlso drvID > 0 Then
                Dim activeDrivers = _repo.GetActiveDeliveryDrivers()
                Dim defaultDrv = activeDrivers.FirstOrDefault(Function(d) d.DriverID = drvID)

                If defaultDrv IsNot Nothing Then
                    SelectedDriverID = defaultDrv.DriverID
                    SelectedDriverName = defaultDrv.DriverName
                    DeliveryFee = defaultDrv.DeliveryFeeValue

                    lblOrderTypeStatus.Text = "نوع الطلب: دليفري | الطيار: " & SelectedDriverName & " | خدمة التوصيل: " & DeliveryFee.ToString("N2")
                    lblDeliveryFee.Text = DeliveryFee.ToString("N2")
                    CalculatePOSGrandTotal()
                End If
            End If
        Catch ex As Exception
            ' في حال عدم العثور على الطيار الافتراضي
        End Try
    End Sub
    '=========================================================
    ' دالة التحقق من الوردية وتوجيه المستخدم لشاشة الورديات
    ' =========================================================
    Private Function CheckAndEnsureActiveShift() As Boolean

        ' أ) التأكد أولاً من تحميل حالة الوردية من الداتا بيز للذاكرة
        InitializeShiftSession()

        ' ب) لو فيه وردية نشطة ومفتوحة (Status = 1) نرجع True فوراً
        If ShiftSession.HasActiveShift Then
            Return True
        End If

        ' ج) لو مفيش وردية مفتوحة نطلع الـ MessageBox
        Dim msgResult As DialogResult = MessageBox.Show(
        "لا توجد وردية مفتوحة حالياً!" & vbCrLf & "هل تريد فتح وردية جديدة الآن للتمكن من البيع؟",
        "تنبيه الوردية الحالية",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.RightAlign
    )

        ' د) لو داس Yes نفتح فورم الورديات
        If msgResult = DialogResult.Yes Then

            Using frm As New frmShifts()
                frm.ShowDialog()
            End Using

            ' بعد ما يقفل فورم الورديات، بنفحص تاني هل فتح وردية بالفعل ولا لأ
            InitializeShiftSession()

            If ShiftSession.HasActiveShift Then
                MessageBox.Show("تم التعرف على الوردية الجديدة بنجاح! يمكنك البدء بالبيع الآن.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                MessageBox.Show("لم يتم فتح وردية نشطة، سيتم إغلاق شاشة البيع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
                Exit Function
            End If

        Else
            ' لو داس No بنرجع False عشان نقفل شاشة البيع
            Return False
        End If


    End Function
    Private Sub SetupInvoiceGrid()
        ' ==========================================
        ' 1. الخصائص العامة للجدول (UX & Behavior)
        ' ==========================================
        dgvInvoice.Columns.Clear()
        dgvInvoice.AutoGenerateColumns = False
        dgvInvoice.AllowUserToAddRows = False
        dgvInvoice.AllowUserToDeleteRows = False
        dgvInvoice.AllowUserToResizeRows = False
        dgvInvoice.ReadOnly = True
        dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInvoice.MultiSelect = False
        dgvInvoice.RowHeadersVisible = False

        ' السماح بالـ Scroll أفقي ورأسي
        dgvInvoice.ScrollBars = ScrollBars.Both

        ' منع الـ DataGridView من توزيع الأعمدة تلقائياً على عرض الشاشة
        dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' جعل النص الطويل ينزل على أكثر من سطر
        dgvInvoice.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        ' ضبط ارتفاع الصف تلقائياً حسب النص
        dgvInvoice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ' ==========================================
        ' 2. إنشاء الأعمدة وتحديد الترتيب والعرض
        ' ==========================================

        ' 1. مسلسل (#)
        Dim colIndex As New DataGridViewTextBoxColumn With {
        .Name = "colIndex",
        .HeaderText = "#",
        .Width = 35,
        .SortMode = DataGridViewColumnSortMode.NotSortable,
        .Visible = False
    }
        colIndex.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' 2. اسم الصنف
        Dim colProductName As New DataGridViewTextBoxColumn With {
        .Name = "colProductName",
        .HeaderText = "الصنف",
        .Width = 100,
        .SortMode = DataGridViewColumnSortMode.NotSortable
    }
        colProductName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' 3. الحجم
        Dim colSize As New DataGridViewTextBoxColumn With {
        .Name = "colSize",
        .HeaderText = "الحجم",
        .Width = 90,
        .SortMode = DataGridViewColumnSortMode.NotSortable
    }
        colSize.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' 4. الإضافات
        Dim colAddons As New DataGridViewTextBoxColumn With {
        .Name = "colAddons",
        .HeaderText = "الإضافات",
        .Width = 130,
        .SortMode = DataGridViewColumnSortMode.NotSortable
    }
        colAddons.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' 5. سعر القطعة
        Dim colUnitPrice As New DataGridViewTextBoxColumn With {
        .Name = "colUnitPrice",
        .HeaderText = "السعر",
        .Width = 80,
        .SortMode = DataGridViewColumnSortMode.NotSortable
    }
        colUnitPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colUnitPrice.DefaultCellStyle.Format = "N2"

        ' 6. الكمية
        Dim colQuantity As New DataGridViewTextBoxColumn With {
        .Name = "colQuantity",
        .HeaderText = "الكمية",
        .Width = 80,
        .SortMode = DataGridViewColumnSortMode.NotSortable
    }
        colQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' 7. السعر الإجمالي
        Dim colTotalPrice As New DataGridViewTextBoxColumn With {
        .Name = "colTotalPrice",
        .HeaderText = "الإجمالي",
        .Width = 100,
        .SortMode = DataGridViewColumnSortMode.NotSortable
    }
        colTotalPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colTotalPrice.DefaultCellStyle.Format = "N2"

        ' 8. ملاحظات
        Dim colNotes As New DataGridViewTextBoxColumn With {
        .Name = "colNotes",
        .HeaderText = "ملاحظات",
        .Width = 100,
        .SortMode = DataGridViewColumnSortMode.NotSortable
    }
        colNotes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' 9. ProductID (مخفي للبرمجة والحفظ)
        Dim colProductID As New DataGridViewTextBoxColumn With {
        .Name = "colProductID",
        .HeaderText = "ProductID",
        .Visible = False
    }

        ' ==========================================
        ' 3. إضافة الأعمدة إلى DataGridView بالترتيب
        ' ==========================================
        dgvInvoice.Columns.AddRange(New DataGridViewColumn() {
        colIndex,
        colProductName,
        colSize,
        colAddons,
        colUnitPrice,
        colQuantity,
        colTotalPrice,
        colNotes,
        colProductID
    })
    End Sub
    '==========================================
    ' 1. رسم الأقسام داخل flpCategories
    ' ==========================================
    Private Sub LoadCategories()
        Dim categories = _repo.GetCategories()

        flpCategories.SuspendLayout()
        Try
            flpCategories.Controls.Clear()

            For Each cat As CategoryModel In categories
                Dim card As New UCCategoryCard With {
                    .Width = 130,
                    .Height = 140,
                    .Category = cat
                }

                ' استلام حدث الضغط على القسم
                AddHandler card.CategoryClicked, AddressOf CategoryCard_Click

                flpCategories.Controls.Add(card)
            Next
        Finally
            flpCategories.ResumeLayout()
        End Try
    End Sub

    ' عند الضغط على كارت قسم
    Private Sub CategoryCard_Click(category As CategoryModel)
        ' جلب أصناف هذا القسم ورسمها
        LoadProducts(category.Category_ID)
    End Sub


    ' ==========================================
    ' 2. رسم الأصناف داخل flpProducts
    ' ==========================================
    Private Sub LoadProducts(categoryID As Integer)
        Dim products = _repo.GetProductsByCategoryID(categoryID)

        flpProducts.SuspendLayout()
        Try
            flpProducts.Controls.Clear()

            For Each prod As ProductModel In products
                Dim card As New UCProductCard With {
                    .Width = 140,
                    .Height = 150,
                    .Product = prod
                }

                ' استلام حدث الضغط على الصنف
                AddHandler card.ProductClicked, AddressOf ProductCard_Click

                flpProducts.Controls.Add(card)
            Next
        Finally
            flpProducts.ResumeLayout()
        End Try
    End Sub

    ' ==========================================
    ' حدث الضغط على كارت الصنف في شاشة البيع
    ' ==========================================
    Private Sub ProductCard_Click(product As ProductModel)

        ' 1. فتح فورم خيارات الصنف (الأحجام والإضافات) كـ Dialog
        Using frmOptions As New FrmProductOptions(product, _repo)

            ' 2. التحقق مما إذا كان الكاشير قد ضغط على زر "إضافة" (DialogResult.OK)
            If frmOptions.ShowDialog() = DialogResult.OK Then

                ' 3. استلام كافة العناصر المختارة ببيانات الأحجام والإضافات وإضافتها للفاتورة
                For Each selectedItem In frmOptions.ResultOrderItems
                    AddItemToInvoice(selectedItem)
                Next

            End If

        End Using

    End Sub
    ' =========================================================
    ' دالة جلب وعرض رقم الفاتورة الحالي المتسلسل
    ' =========================================================
    Private Sub UpdateNextInvoiceNumber()
        If _repo IsNot Nothing Then
            Dim nextNum As String = _repo.GetNextInvoiceNumber()
            lblInvoiceNumber.Text = nextNum ' Label رقم الفاتورة بأعلى الشاشة
        End If
    End Sub

    ' =========================================================
    ' الدالة المركزية للحسابات الشاملة لكل العوامل والعملات
    ' =========================================================
    Private Sub CalculatePOSGrandTotal()
        Dim itemsTotal As Decimal = 0

        ' 1. مجموع الأصناف في الجدول
        For Each row As DataGridViewRow In dgvInvoice.Rows
            If row.Cells("colTotalPrice").Value IsNot Nothing Then
                Dim rowVal As Decimal = 0
                Decimal.TryParse(row.Cells("colTotalPrice").Value.ToString(), rowVal)
                itemsTotal += rowVal
            End If
        Next

        ' 2. عرض الصافي الأولي
        lblSubTotal.Text = itemsTotal.ToString("N2")
        DineInServiceFee = If(SettingsManager.GetSetting("DineInServiceFee"), "0")
        Dim IsPercent As Boolean = If(SettingsManager.GetSetting("IsDineInServiceFeePercent"), "false")
        ' 3. تحديد رسوم الدليفري ورسوم الصالة والضريبة
        Dim currentDelivery As Decimal = If(CurrentOrderType = OrderType.Delivery, DeliveryFee, 0)
        Dim currentDineInFee As Decimal
        If IsPercent Then
            currentDineInFee = If(CurrentOrderType = OrderType.DineIn, itemsTotal * DineInServiceFee / 100, 0)
            lblDineInFee.Text = itemsTotal * DineInServiceFee / 100 & $"({DineInServiceFee}%)"
        Else
            currentDineInFee = If(CurrentOrderType = OrderType.DineIn, DineInServiceFee, 0)
            lblDineInFee.Text = currentDineInFee.ToString("N2")
        End If

        lblDeliveryFee.Text = currentDelivery.ToString("N2")
        'lblDineInFee.Text = currentDineInFee.ToString("N2")
        lblTax.Text = TaxAmount.ToString("N2")

        ' 4. حساب الإجمالي النهائي (مع مراعاة السوالب والعمليات الحسابية المتقاطعة)
        Dim finalGrandTotal As Decimal = itemsTotal + currentDelivery + currentDineInFee + TaxAmount

        ' منع أي قيم سالبة غير منطقية
        If finalGrandTotal < 0 Then finalGrandTotal = 0

        lblGrandTotal.Text = finalGrandTotal.ToString("N2") & " EGP"
    End Sub

    Private Sub AddItemToInvoice(item As OrderItemModel)
        Dim sizeName As String = If(item.SelectedSize IsNot Nothing, item.SelectedSize.SizeInfo.SizeNameAr, "عادي")
        Dim addonsList As New List(Of String)
        For Each addon In item.SelectedAddons
            addonsList.Add(addon.AddonInfo.AddonNameAr)
        Next
        Dim addonsText As String = If(addonsList.Count > 0, String.Join(", ", addonsList), "-")

        Dim baseSizePrice As Decimal = If(item.SelectedSize IsNot Nothing, item.SelectedSize.SalePrice, 0)
        Dim addonsTotalPrice As Decimal = 0
        For Each addon In item.SelectedAddons
            addonsTotalPrice += addon.SalePrice
        Next
        Dim singleUnitPrice As Decimal = baseSizePrice + addonsTotalPrice

        dgvInvoice.Rows.Add(
            dgvInvoice.Rows.Count + 1,
            item.ProductName,
            sizeName,
            addonsText,
            singleUnitPrice,
            item.Quantity,
            item.TotalPrice,
            item.Notes,
            item.Product_ID
        )

        ' تحديث الحسابات الشاملة فور إضافة صنف
        CalculatePOSGrandTotal()
    End Sub

    ' =========================================================
    ' زر تعليق الفاتورة المحدث مع دعم الـ JSON وقفل الطاولة
    ' =========================================================
    Private Sub btnHoldInvoice_Click(sender As Object, e As EventArgs) Handles btnHoldInvoice.Click
        If dgvInvoice.Rows.Count = 0 Then
            MessageBox.Show("لا يمكن تعليق فاتورة فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' للطلبات الدليفري يجب تحديد العميل والطيار
        If CurrentOrderType = OrderType.Delivery Then
            If CurrentCustomer Is Nothing Then
                MessageBox.Show("برجاء تحديد العميل أولاً لطلبات الدليفري قبل تعليق الفاتورة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnSelectCustomer.Focus()
                Return
            End If
            If Not SelectedDriverID.HasValue Then
                MessageBox.Show("برجاء تحديد طيار التوصيل أولاً لطلبات الدليفري!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        ' تجهيز قائمة أسطر الفاتورة لتحويلها لـ JSON احترافي
        Dim itemsList As New List(Of InvoiceDetailModel)
        For Each row As DataGridViewRow In dgvInvoice.Rows
            If Not row.IsNewRow Then
                itemsList.Add(New InvoiceDetailModel With {
                    .ProductID = Convert.ToInt32(row.Cells("colProductID").Value),
                    .ProductName = row.Cells("colProductName").Value.ToString(),
                    .SizeName = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), ""),
                    .AddonsText = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), ""),
                    .UnitPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value),
                    .Quantity = Convert.ToInt32(row.Cells("colQuantity").Value),
                    .TotalPrice = Convert.ToDecimal(row.Cells("colTotalPrice").Value),
                    .Notes = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")
                })
            End If
        Next

        Dim jsonItems As String = Newtonsoft.Json.JsonConvert.SerializeObject(itemsList)
        Dim custName As String = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerName, "عميل نقدي")
        Dim custID As Integer? = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerID, CType(Nothing, Integer?))

        Dim pendingInv As New PendingInvoiceModel With {
            .ShiftID = If(ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, 1),
            .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
            .OrderType = CByte(CurrentOrderType),
            .CustomerID = custID,
            .CustomerName = custName,
            .TableID = SelectedTableID,
            .TableName = SelectedTableName,
            .DriverID = SelectedDriverID,
            .DriverName = SelectedDriverName,
            .DeliveryFee = DeliveryFee,
            .InvoiceJSON = jsonItems,
            .TotalAmount = GetInvoiceTotalFromGrid()
        }

        If _repo.SavePendingInvoice(pendingInv) Then

            ' إذا كان نوع الطلب صالة -> تغيير حالة الطاولة إلى مشغولة (2) في الداتا بيز
            If CurrentOrderType = OrderType.DineIn AndAlso SelectedTableID.HasValue Then
                _repo.UpdateTableStatus(SelectedTableID.Value, 2) ' 2 = مشغولة/حجز معلق
            End If

            MessageBox.Show("تم تعليق الفاتورة بنجاح!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ResetPOSForm()
            UpdateNextInvoiceNumber() ' تغيير وتحديث رقم الفاتورة القادمة
        End If
    End Sub

    ' =========================================================
    ' دالة مساعدة لحساب مجموع أسطر الفاتورة من DataGridView
    ' =========================================================
    Private Function GetInvoiceTotalFromGrid() As Decimal
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvInvoice.Rows
            If row.Cells("colTotalPrice").Value IsNot Nothing Then
                total += Convert.ToDecimal(row.Cells("colTotalPrice").Value)
            End If
        Next
        Return total
    End Function

    ' =========================================================
    ' استرجاع الفواتير المعلقة وإعادة فتح الطاولة والعميل
    ' =========================================================
    Private Sub btnPendingInvoices_Click(sender As Object, e As EventArgs) Handles btnPendingInvoices.Click
        Using frmPending As New FrmPendingInvoices(_repo)
            If frmPending.ShowDialog() = DialogResult.OK Then

                Dim pendingItem = frmPending.SelectedPendingInvoice
                If pendingItem IsNot Nothing Then

                    ResetPOSForm()

                    ' 1. استرجاع العميل وتعبئة حقل الاسم إذا وُجد
                    If pendingItem.CustomerID.HasValue AndAlso pendingItem.CustomerID.Value > 0 Then
                        CurrentCustomer = New CustomerModel With {
                            .CustomerID = pendingItem.CustomerID.Value,
                            .CustomerName = pendingItem.CustomerName
                        }
                        txtCustomer.Text = CurrentCustomer.CustomerName
                    ElseIf Not String.IsNullOrWhiteSpace(pendingItem.CustomerName) AndAlso pendingItem.CustomerName <> "عميل نقدي" Then
                        txtCustomer.Text = pendingItem.CustomerName
                    End If

                    ' 2. استرجاع نوع الطلب والطاولات
                    CurrentOrderType = CType(pendingItem.OrderType, OrderType)
                    Select Case CurrentOrderType
                        Case OrderType.Takeaway
                            btnTakeaway.Checked = True
                            lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"
                        Case OrderType.DineIn
                            btnDineIn.Checked = True
                            SelectedTableID = pendingItem.TableID
                            SelectedTableName = pendingItem.TableName
                            lblOrderTypeStatus.Text = "نوع الطلب: صالة | الطاولة: " & SelectedTableName
                        Case OrderType.Delivery
                            btnDelivery.Checked = True
                            SelectedDriverID = pendingItem.DriverID
                            SelectedDriverName = pendingItem.DriverName
                            DeliveryFee = pendingItem.DeliveryFee
                            lblDeliveryFee.Text = DeliveryFee.ToString("N2")
                            lblOrderTypeStatus.Text = "نوع الطلب: دليفري | الطيار: " & SelectedDriverName
                    End Select

                    ' 3. إعادة تحميل الأسطر عبر فك الـ JSON (مع دعم الصيغة القديمة للتوافقية)
                    If Not String.IsNullOrWhiteSpace(pendingItem.InvoiceJSON) Then
                        If pendingItem.InvoiceJSON.Trim().StartsWith("[") Then
                            Try
                                Dim items = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of InvoiceDetailModel))(pendingItem.InvoiceJSON)
                                If items IsNot Nothing Then
                                    For Each itm In items
                                        dgvInvoice.Rows.Add(
                                            dgvInvoice.Rows.Count + 1,
                                            itm.ProductName,
                                            itm.SizeName,
                                            itm.AddonsText,
                                            itm.UnitPrice,
                                            itm.Quantity,
                                            itm.TotalPrice,
                                            itm.Notes,
                                            itm.ProductID
                                        )
                                    Next
                                End If
                            Catch ex As Exception
                                ' خطأ في فك الـ JSON
                            End Try
                        Else
                            ' توافقية مع الفواتير المعلقة القديمة بنظام الـ Delimiter
                            Dim rowsData() As String = pendingItem.InvoiceJSON.Split("~"c)
                            For Each rData In rowsData
                                Dim parts() As String = rData.Split("|"c)
                                If parts.Length >= 8 Then
                                    dgvInvoice.Rows.Add(
                                        dgvInvoice.Rows.Count + 1,
                                        parts(1),
                                        parts(2),
                                        parts(3),
                                        Convert.ToDecimal(parts(4)),
                                        Convert.ToInt32(parts(5)),
                                        Convert.ToDecimal(parts(6)),
                                        parts(7),
                                        Convert.ToInt32(parts(0))
                                    )
                                End If
                            Next
                        End If
                    End If

                    CalculatePOSGrandTotal()

                    ' إغلاق الفاتورة المعلقة من الداتا بيز بعد استرجاعها للشاشة
                    _repo.DeletePendingInvoice(pendingItem.PendingID)

                End If

            End If
        End Using
    End Sub

    Private Sub btnDelivery_Click(sender As Object, e As EventArgs) Handles btnDelivery.Click
        CurrentOrderType = OrderType.Delivery
        SelectedTableID = Nothing
        SelectedTableName = ""
        ' فتح فورم اختيار الطيار
        Using frmDriver As New FrmSelectDriver(_repo)
            If frmDriver.ShowDialog() = DialogResult.OK Then

                ' استلام الطيار المختار
                Dim driver As DeliveryDriverModel = frmDriver.SelectedDriver

                If driver IsNot Nothing Then
                    ' حفظ البيانات
                    SelectedDriverID = driver.DriverID
                    SelectedDriverName = driver.DriverName
                    DeliveryFee = driver.DeliveryFeeValue

                    ' تحديث شاشة العرض
                    lblOrderTypeStatus.Text = "نوع الطلب: دليفري | الطيار: " & driver.DriverName & " | خدمة التوصيل: " & driver.DeliveryFeeValue.ToString("N2")
                    lblDeliveryFee.Text = driver.DeliveryFeeValue.ToString("N2")
                    CalculatePOSGrandTotal()
                End If

            Else
                ' لو أغلقت الشاشة بدون اختيار طيار يرجع تيك أوي
                btnTakeaway.Checked = True
                btnTakeaway_Click(Nothing, Nothing)
            End If
        End Using
    End Sub

    Private Sub btnTakeaway_Click(sender As Object, e As EventArgs) Handles btnTakeaway.Click
        CurrentOrderType = OrderType.Takeaway

        ' تفريغ بيانات الصالة والدليفري
        SelectedTableID = Nothing
        SelectedTableName = ""
        SelectedDriverID = Nothing
        SelectedDriverName = ""
        DeliveryFee = 0
        lblDeliveryFee.Text = "0.00"
        lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"
        CalculatePOSGrandTotal()
    End Sub

    ' =========================================================
    ' زر الدفع ومراجعة الشروط قبل الفتح
    ' =========================================================
    Private Async Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

        If dgvInvoice.Rows.Count = 0 Then
            MessageBox.Show("لا يمكن إتمام عملية الدفع بفاتورة فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' التحقق من طلبات الصالة
        If CurrentOrderType = OrderType.DineIn AndAlso Not SelectedTableID.HasValue Then
            MessageBox.Show("برجاء تحديد رقم الطاولة أولاً لطلبات الصالة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' التحقق من طلبات الدليفري
        If CurrentOrderType = OrderType.Delivery Then
            If CurrentCustomer Is Nothing Then
                MessageBox.Show("برجاء تحديد بيانات العميل أولاً لطلبات الدليفري!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnSelectCustomer.Focus()
                Return
            End If

            If Not SelectedDriverID.HasValue Then
                MessageBox.Show("برجاء تحديد طيار التوصيل أولاً لطلبات الدليفري!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        CalculatePOSGrandTotal()
        Dim itemsTotal As Decimal = GetInvoiceTotalFromGrid()
        Dim finalInvoiceTotal As Decimal = itemsTotal
        If CurrentOrderType = OrderType.Delivery Then finalInvoiceTotal += DeliveryFee

        Using frmPay As New FrmQuickPayment(finalInvoiceTotal, CurrentCustomer)
            If frmPay.ShowDialog() = DialogResult.OK Then

                Dim custID As Integer? = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerID, CType(Nothing, Integer?))

                'Dim invoice As New InvoiceModel With {
                '    .OrderType = CByte(CurrentOrderType),
                '    .ShiftID = If(ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, 1),
                '    .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
                '    .CustomerID = custID,
                '    .TableID = SelectedTableID,
                '    .DriverID = SelectedDriverID,
                '    .DeliveryFee = DeliveryFee,
                '    .TotalBeforeDiscount = frmPay.FinalGrandTotal,
                '    .DiscountAmount = frmPay.TotalDiscount,
                '    .NetTotal = frmPay.NetTotal,
                '    .PaidAmount = frmPay.PaidAmount,
                '    .RemainingAmount = frmPay.RemainingAmount,
                '    .IsCredit = frmPay.IsCreditOrder,
                '    .TreasuryID = If(frmPay.SelectedTreasuryID > 0, frmPay.SelectedTreasuryID, CType(Nothing, Integer?))
                '}

                ' جلب الفرع والمخزن الحاليين من الإعدادات
                Dim currentBranchID As Integer = Convert.ToInt32(If(SettingsManager.GetSetting("CurrentBranchID"), "1"))
                Dim currentStoreID As Integer = Convert.ToInt32(If(SettingsManager.GetSetting("CurrentStoreID"), "1"))

                Dim invoice As New InvoiceModel With {
                    .OrderType = CByte(CurrentOrderType),
                    .ShiftID = ShiftSession.CurrentShift.ShiftID,
                    .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
                    .CustomerID = CurrentCustomer.CustomerID,
                    .TableID = SelectedTableID,
                    .DriverID = SelectedDriverID,
                    .BranchID = currentBranchID,
                    .StoreID = currentStoreID,
                    .DeliveryFee = DeliveryFee,
                    .TotalBeforeDiscount = frmPay.FinalGrandTotal,
                    .DiscountAmount = frmPay.TotalDiscount,
                    .NetTotal = frmPay.NetTotal,
                    .PaidAmount = frmPay.PaidAmount,
                    .RemainingAmount = frmPay.RemainingAmount,
                    .IsCredit = frmPay.IsCreditOrder,
                    .TreasuryID = If(frmPay.SelectedTreasuryID > 0, frmPay.SelectedTreasuryID, CType(Nothing, Integer?))
                }

                For Each row As DataGridViewRow In dgvInvoice.Rows
                    If Not row.IsNewRow Then
                        invoice.Details.Add(New InvoiceDetailModel With {
                            .ProductID = Convert.ToInt32(row.Cells("colProductID").Value),
                            .ProductName = row.Cells("colProductName").Value.ToString(),
                            .SizeName = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), ""),
                            .AddonsText = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), ""),
                            .UnitPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value),
                            .Quantity = Convert.ToInt32(row.Cells("colQuantity").Value),
                            .TotalPrice = Convert.ToDecimal(row.Cells("colTotalPrice").Value),
                            .Notes = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")
                        })
                    End If
                Next

                Try
                    Dim savedInvNum As String = Await _repo.SaveInvoiceAsync(invoice)
                    ' تحديث الذاكرة الحالية للوردية فوراً
                    If ShiftSession.HasActiveShift Then
                        ShiftSession.CurrentShift.TotalSales += invoice.PaidAmount
                        ShiftSession.CurrentShift.TotalOrders += 1
                    End If
                    ' إذا كانت الفاتورة صالة، يتم تحرير الطاولة وإرجاع حالتها متاحة (1)
                    If CurrentOrderType = OrderType.DineIn AndAlso SelectedTableID.HasValue Then
                        _repo.UpdateTableStatus(SelectedTableID.Value, 1) ' 1 = متاحة
                    End If

                    MessageBox.Show("تم حفظ الفاتورة بنجاح برقم: " & savedInvNum, "حفظ الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ResetPOSForm()
                    UpdateNextInvoiceNumber() ' تحديث رقم الفاتورة القادمة تلقائياً

                Catch ex As Exception
                    MessageBox.Show("حدث خطأ أثناء حفظ الفاتورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If
        End Using

    End Sub

    ' =========================================================
    ' تفريغ الشاشة وإتاحة الفاتورة التالية
    ' =========================================================
    Private Sub ResetPOSForm()
        dgvInvoice.Rows.Clear()

        CurrentCustomer = Nothing
        txtCustomer.Text = ""
        SelectedTableID = Nothing
        SelectedTableName = ""
        SelectedDriverID = Nothing
        SelectedDriverName = ""
        DeliveryFee = 0
        DineInServiceFee = 0
        TaxAmount = 0

        ApplyDefaultPOSSettings()

        btnTakeaway.Checked = True
        CurrentOrderType = OrderType.Takeaway
        lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"

        CalculatePOSGrandTotal()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        ResetPOSForm()
    End Sub

    ' =========================================================
    ' زر حذف صنف محدد من الفاتورة
    ' =========================================================
    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click
        If dgvInvoice.CurrentRow IsNot Nothing AndAlso Not dgvInvoice.CurrentRow.IsNewRow Then
            Dim prodName As String = If(dgvInvoice.CurrentRow.Cells("colProductName").Value IsNot Nothing, dgvInvoice.CurrentRow.Cells("colProductName").Value.ToString(), "هذا الصنف")
            dgvInvoice.Rows.Remove(dgvInvoice.CurrentRow)

            ' إعادة ترقيم المسلسل
            For i As Integer = 0 To dgvInvoice.Rows.Count - 1
                dgvInvoice.Rows(i).Cells("colIndex").Value = i + 1
            Next

            CalculatePOSGrandTotal()
        Else
            MessageBox.Show("برجاء اختيار الصنف المراد حذفه من جدول الفاتورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' =========================================================
    ' التحكم السريع في الكميات (+ / - / حذف بالزر)
    ' =========================================================
    Private Sub UpdateRowQuantity(rowIndex As Integer, delta As Integer)
        If rowIndex >= 0 AndAlso rowIndex < dgvInvoice.Rows.Count Then
            Dim row = dgvInvoice.Rows(rowIndex)
            Dim currentQty As Integer = Convert.ToInt32(row.Cells("colQuantity").Value)
            Dim newQty As Integer = currentQty + delta

            If newQty <= 0 Then
                dgvInvoice.Rows.RemoveAt(rowIndex)
            Else
                Dim unitPrice As Decimal = Convert.ToDecimal(row.Cells("colUnitPrice").Value)
                row.Cells("colQuantity").Value = newQty
                row.Cells("colTotalPrice").Value = unitPrice * newQty
            End If

            For i As Integer = 0 To dgvInvoice.Rows.Count - 1
                dgvInvoice.Rows(i).Cells("colIndex").Value = i + 1
            Next

            CalculatePOSGrandTotal()
        End If
    End Sub

    Private Sub dgvInvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvInvoice.KeyDown
        If dgvInvoice.CurrentRow IsNot Nothing AndAlso Not dgvInvoice.CurrentRow.IsNewRow Then
            If e.KeyCode = Keys.Delete Then
                btnDeleteRow_Click(Nothing, Nothing)
                e.Handled = True
            ElseIf e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus Then
                UpdateRowQuantity(dgvInvoice.CurrentRow.Index, +1)
                e.Handled = True
            ElseIf e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
                UpdateRowQuantity(dgvInvoice.CurrentRow.Index, -1)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvInvoice_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' الضغط المزدوج على سطر الصنف يزود الكمية بمقدار 1
            UpdateRowQuantity(e.RowIndex, +1)
        End If
    End Sub

    Private Sub btnAddCategoryForm_Click(sender As Object, e As EventArgs) Handles btnAddCategoryForm.Click
        Dim frm As New Categories()
        frm.ShowDialog()
        LoadCategories()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd - hh:mm:ss tt")
    End Sub

    Private Sub btnSelectCustomer_Click(sender As Object, e As EventArgs) Handles btnSelectCustomer.Click
        Using frmSelect As New FrmSelectCustomer(_repo)
            If frmSelect.ShowDialog() = DialogResult.OK Then
                CurrentCustomer = frmSelect.SelectedCustomer
                txtCustomer.Text = CurrentCustomer.CustomerName
            End If
        End Using
    End Sub

    Private Sub btntables_Click(sender As Object, e As EventArgs) Handles btntables.Click
        Dim frmRT As New frmRestaurantTables
        frmRT.ShowDialog()
    End Sub

    Private Sub btnDineIn_Click(sender As Object, e As EventArgs) Handles btnDineIn.Click
        CurrentOrderType = OrderType.DineIn
        SelectedDriverID = Nothing
        SelectedDriverName = ""
        DeliveryFee = 0
        lblDeliveryFee.Text = "0.00"

        Using frmTables As New FrmSelectTable(_repo)
            If frmTables.ShowDialog() = DialogResult.OK Then
                SelectedTableID = frmTables.SelectedTableID
                SelectedTableName = frmTables.SelectedTableName
                lblOrderTypeStatus.Text = "نوع الطلب: صالة | الطاولة: " & SelectedTableName
                CalculatePOSGrandTotal()
            Else
                btnTakeaway.Checked = True
                btnTakeaway_Click(Nothing, Nothing)
            End If
        End Using
    End Sub
End Class