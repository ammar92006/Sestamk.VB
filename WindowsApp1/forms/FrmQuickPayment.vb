Imports System
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

Public Class FrmQuickPayment

    ' ==========================================
    ' المتغيرات الممررة من شاشة البيع
    ' ==========================================
    Private ReadOnly _totalAmount As Decimal
    Private ReadOnly _customer As CustomerModel

    ' ==========================================
    ' النتائج المرتجعة لشاشة البيع
    ' ==========================================
    Public Property FinalGrandTotal As Decimal = 0     ' المجموع الكلي قبل الخصم
    Public Property TotalDiscount As Decimal = 0        ' إجمالي الخصم (افتراضي + إضافي)
    Public Property NetTotal As Decimal = 0             ' الإجمالي بعد الخصم
    Public Property PaidAmount As Decimal = 0           ' المبلغ المدفوع الفعلي للفاتورة
    Public Property RemainingAmount As Decimal = 0      ' المتبقي على العميل كمديونية
    Public Property ChangeAmount As Decimal = 0         ' الباقي المردود للعميل (الصرف)
    Public Property SelectedTreasuryID As Integer = 0   ' الخزنة المختارة
    Public Property IsCreditOrder As Boolean = False    ' هل الدفع آجل؟

    Private defaultTreasuryid As Integer = -1

    ' ==========================================
    ' Constructor
    ' ==========================================
    Public Sub New(totalAmount As Decimal, customer As CustomerModel)
        InitializeComponent()
        _totalAmount = totalAmount
        _customer = customer
    End Sub

    Private Async Sub FrmQuickPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)

        ' 1. عرض المجموع الكلي
        FinalGrandTotal = _totalAmount
        lblGrandTotal.Text = _totalAmount.ToString("N2")

        ' 2. عرض الرصيد السابق والخصم الافتراضي للعميل
        LoadCustomerInfo()

        ' 3. تحميل الخزائن في ComboBox
        Await LoadTreasuriesAsync()

        ' 4. ضبط طريقة الدفع الافتراضية (نقدي)
        rdoCash.Checked = True
        txtPaidInput.Text = "0"

        ' 5. ربط أزرار الآلة الحاسبة
        RegisterNumPadEvents()

        ' 6. أول عملية حسابية تلقائية
        CalculateAll()

        Dim defaultIdSetting = SettingsManager.GetSetting("defaultTreasuryid")
        defaultTreasuryid = If(IsNumeric(defaultIdSetting), Convert.ToInt32(defaultIdSetting), -1)
        If defaultTreasuryid >= 0 AndAlso defaultTreasuryid < cmbTreasury.Items.Count Then
            cmbTreasury.SelectedIndex = defaultTreasuryid
        End If
        Dim Drag As New FormDragHelper(Me, panelHeader)
    End Sub

    Private Async Function LoadTreasuriesAsync() As Task
        Try
            Dim dt As New DataTable()
            Using cn As SqlConnection = Await NewConnAsync()
                Const sql As String = "SELECT TreasuryID, TreasuryNameAr FROM Treasury WHERE IsActive = 1 AND IsDeleted = 0"
                Using da As New SqlDataAdapter(sql, cn)
                    Await Task.Run(Sub() da.Fill(dt))
                End Using
            End Using
            cmbTreasury.DataSource = dt
            cmbTreasury.DisplayMember = "TreasuryNameAr"
            cmbTreasury.ValueMember = "TreasuryID"
            Dim defaultIdSetting = SettingsManager.GetSetting("defaultTreasuryid")
            defaultTreasuryid = If(IsNumeric(defaultIdSetting), Convert.ToInt32(defaultIdSetting), -1)
            If defaultTreasuryid >= 0 AndAlso defaultTreasuryid < cmbTreasury.Items.Count Then
                cmbTreasury.SelectedIndex = defaultTreasuryid
            End If
        Catch ex As Exception
            Logger.LogError("FrmQuickPayment.LoadTreasuriesAsync", ex)
        End Try
    End Function

    ' ==========================================
    ' 1. تحميل بيانات العميل (الرصيد والخصم الافتراضي وحد الائتمان)
    ' ==========================================
    Private Sub LoadCustomerInfo()
        If _customer IsNot Nothing Then
            ' أ) الرصيد السابق (السالب = مدين/عليه، الموجب = دائن/له)
            Dim prevBalance As Decimal = If(_customer.CurrentBalance.HasValue, _customer.CurrentBalance.Value, 0)
            If prevBalance < 0 Then
                lblPreviousBalance.Text = Math.Abs(prevBalance).ToString("N2") & " (مدين/عليه)"
                lblPreviousBalance.ForeColor = Color.Crimson
            ElseIf prevBalance > 0 Then
                lblPreviousBalance.Text = prevBalance.ToString("N2") & " (دائن/له)"
                lblPreviousBalance.ForeColor = Color.ForestGreen
            Else
                lblPreviousBalance.Text = "0.00 (خالص)"
                lblPreviousBalance.ForeColor = ThemeManager.Instance.CurrentPalette.TextPrimary
            End If

            ' ب) الخصم الافتراضي للعميل
            Dim discVal As Double = If(_customer.DiscountPercent.HasValue, _customer.DiscountPercent.Value, 0)
            Dim isPercent As Boolean = If(_customer.IsDiscountPercent.HasValue, _customer.IsDiscountPercent.Value, False)

            If isPercent Then
                lblDefaultDiscount.Text = discVal.ToString("N0") & " %"
            Else
                lblDefaultDiscount.Text = discVal.ToString("N2")
            End If
        Else
            lblPreviousBalance.Text = "0.00"
            lblPreviousBalance.ForeColor = ThemeManager.Instance.CurrentPalette.TextPrimary
            lblDefaultDiscount.Text = "0"
        End If
    End Sub

    ' ==========================================
    ' 2. حسابات الخصم والإجمالي والمدفوع والمتبقي/الباقي
    ' ==========================================
    Private Sub CalculateAll()
        ' أ) حساب الخصم الافتراضي للعميل
        Dim customerDefaultDiscount As Decimal = 0
        If _customer IsNot Nothing AndAlso _customer.DiscountPercent.HasValue Then
            Dim discVal As Decimal = Convert.ToDecimal(_customer.DiscountPercent.Value)
            Dim isPercent As Boolean = If(_customer.IsDiscountPercent.HasValue, _customer.IsDiscountPercent.Value, False)

            If isPercent Then
                customerDefaultDiscount = Math.Round(_totalAmount * (discVal / 100D), 2)
                lblDefaultDiscount.Text = $"{customerDefaultDiscount:N2} ({discVal:N0}%)"
            Else
                customerDefaultDiscount = discVal
                lblDefaultDiscount.Text = $"{customerDefaultDiscount:N2}"
            End If
        End If

        ' ب) حساب الخصم اليدوي الإضافي من الـ TextBox
        Dim manualDiscount As Decimal = 0
        Decimal.TryParse(txtDiscount.Text.Trim(), manualDiscount)

        ' إجمالي الخصم (بحيث لا يتجاوز الإجمالي الكلي)
        TotalDiscount = customerDefaultDiscount + manualDiscount
        If TotalDiscount > _totalAmount Then TotalDiscount = _totalAmount

        ' ج) الإجمالي المطلوب بعد الخصم
        NetTotal = _totalAmount - TotalDiscount
        If NetTotal < 0 Then NetTotal = 0
        lblNetTotal.Text = NetTotal.ToString("N2")

        ' د) حساب المدفوع والمتبقي / الباقي وتحديث العرض اللوني بوضوح تام
        If rdoCredit.Checked Then
            ' الدفع آجل بالكامل
            PaidAmount = 0
            RemainingAmount = NetTotal
            ChangeAmount = 0
            txtPaidInput.Enabled = False
            txtPaidInput.Text = "0"

            lblPaid.Text = "0.00"
            lblPaid.ForeColor = ThemeManager.Instance.CurrentPalette.TextPrimary

            Label6.Text = "متبقي الفاتورة (آجل)"
            Label6.ForeColor = Color.Crimson
            lblRemaining.Text = RemainingAmount.ToString("N2")
            lblRemaining.ForeColor = Color.Crimson

        Else
            ' الدفع نقدي
            txtPaidInput.Enabled = True
            Dim inputPaid As Decimal = 0
            Decimal.TryParse(txtPaidInput.Text.Trim(), inputPaid)

            If inputPaid >= NetTotal Then
                ' تم سداد كامل قيمة الفاتورة أو أكثر
                PaidAmount = NetTotal
                RemainingAmount = 0
                ChangeAmount = inputPaid - NetTotal

                lblPaid.Text = inputPaid.ToString("N2")
                lblPaid.ForeColor = ThemeManager.Instance.CurrentPalette.TextPrimary

                If ChangeAmount > 0 Then
                    Label6.Text = "الباقي للعميل"
                    Label6.ForeColor = Color.ForestGreen
                    lblRemaining.Text = ChangeAmount.ToString("N2")
                    lblRemaining.ForeColor = Color.ForestGreen
                Else
                    Label6.Text = "المتبقي على العميل"
                    Label6.ForeColor = ThemeManager.Instance.CurrentPalette.TextPrimary
                    lblRemaining.Text = "0.00 (خالص)"
                    lblRemaining.ForeColor = ThemeManager.Instance.CurrentPalette.TextPrimary
                End If
            Else
                ' دفع جزء وتبقى جزء كمديونية آجلة
                PaidAmount = inputPaid
                RemainingAmount = NetTotal - inputPaid
                ChangeAmount = 0

                lblPaid.Text = PaidAmount.ToString("N2")
                lblPaid.ForeColor = ThemeManager.Instance.CurrentPalette.TextPrimary

                Label6.Text = "المتبقي على العميل"
                Label6.ForeColor = Color.Crimson
                lblRemaining.Text = RemainingAmount.ToString("N2")
                lblRemaining.ForeColor = Color.Crimson
            End If
        End If
    End Sub

    ' ==========================================
    ' 3. منطق التحقق من حد الائتمان ومديونية العميل
    ' ==========================================
    Private Function ValidateCreditLimit() As Boolean
        ' 1. إذا كان المبلغ خالصاً بالكامل، فالعملية مقبولة فوراً
        If RemainingAmount <= 0 Then
            Return True
        End If

        ' 2. في حالة وجود متبقي، يجب أن يكون هناك عميل مسجل
        If _customer Is Nothing Then
            MessageBox.Show(
                "⚠️ تنبيه:" & vbCrLf &
                "لا يمكن ترك متبقي على الفاتورة لعميل نقدي غير مسجل!" & vbCrLf & vbCrLf &
                "برجاء سداد كامل المبلغ المطلوب أو اختيار عميل مسجل أولاً من شاشة البيع.",
                "غير مسموح بالآجل", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' 3. فحص صلاحية البيع الآجل للعميل (AllowCredit)
        Dim allowCredit As Boolean = If(_customer.AllowCredit.HasValue, _customer.AllowCredit.Value, False)
        If Not allowCredit Then
            MessageBox.Show(
                $"⚠️ تنبيه خاص بالعميل: [{_customer.CustomerName}]" & vbCrLf & vbCrLf &
                "هذا العميل غير مسموح له بالتعامل الآجل أو ترك متبقي (خاصية البيع الآجل معطلة في حسابه)." & vbCrLf &
                "يرجى سداد كامل قيمة الفاتورة نقداً.",
                "البيع الآجل غير مسموح", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' 4. فحص سقف حد الائتمان (CreditLimit)
        ' في النظام: الرصيد السالب (-) = مدين/عليه، والرصيد الموجب (+) = دائن/له
        Dim creditLimit As Decimal = If(_customer.CreditLimit.HasValue, _customer.CreditLimit.Value, 0)
        Dim currentBalance As Decimal = If(_customer.CurrentBalance.HasValue, _customer.CurrentBalance.Value, 0)

        ' الرصيد المتوقع بعد خصم متبقي الفاتورة
        Dim projectedBalance As Decimal = currentBalance - RemainingAmount

        ' إذا كان الرصيد المتوقع سالباً، فالمديونية الفعلية هي القيمة المطلقة
        Dim totalProjectedDebt As Decimal = If(projectedBalance < 0, Math.Abs(projectedBalance), 0D)

        If creditLimit > 0 AndAlso totalProjectedDebt > creditLimit Then
            Dim currentDebt As Decimal = If(currentBalance < 0, Math.Abs(currentBalance), 0D)
            Dim currentCredit As Decimal = If(currentBalance > 0, currentBalance, 0D)
            Dim availableCreditBefore As Decimal = If(currentBalance >= 0, creditLimit + currentCredit, Math.Max(0, creditLimit - currentDebt))
            Dim exceededAmount As Decimal = totalProjectedDebt - creditLimit

            Dim msg As String =
                "❌ لا يمكن إتمام وحفظ الفاتورة:" & vbCrLf &
                "مديونية العميل ستتجاوز سقف حد الائتمان المسموح به!" & vbCrLf & vbCrLf &
                $"👤 اسم العميل: {_customer.CustomerName}" & vbCrLf &
                $"💳 حد الائتمان المسموح: {creditLimit:N2} ج.م" & vbCrLf &
                $"📊 المديونية السابقة: {currentDebt:N2} ج.م" & vbCrLf &
                $"🟢 المتاح قبل الفاتورة من حد الائتمان: {availableCreditBefore:N2} ج.م" & vbCrLf &
                $"━━━━━━━━━━━━━━━━━━━━━━━━━━━━" & vbCrLf &
                $"🧾 صافي متبقي هذه الفاتورة: {RemainingAmount:N2} ج.م" & vbCrLf &
                $"🔴 إجمالي المديونية بعد الفاتورة: {totalProjectedDebt:N2} ج.م" & vbCrLf &
                $"⚠️ المبلغ المتجاوز لحد الائتمان: {exceededAmount:N2} ج.م" & vbCrLf & vbCrLf &
                "يرجى سداد مبلغ نقدي أكبر لتغطية الفارق أو مراجعة إدارة الحسابات لزيادة حد الائتمان."

            MessageBox.Show(msg, "تجاوز حد الائتمان المسموح", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Return True
    End Function

    ' ==========================================
    ' 4. أزرار الفئات النقدية السريعة (+10, +50, +100, +200)
    ' ==========================================
    Private Sub btnPlus10_Click(sender As Object, e As EventArgs) Handles btnPlus10.Click
        AddQuickCash(10)
    End Sub

    Private Sub btnPlus50_Click(sender As Object, e As EventArgs) Handles btnPlus50.Click
        AddQuickCash(50)
    End Sub

    Private Sub btnPlus100_Click(sender As Object, e As EventArgs) Handles btnPlus100.Click
        AddQuickCash(100)
    End Sub

    Private Sub btnPlus200_Click(sender As Object, e As EventArgs) Handles btnPlus200.Click
        AddQuickCash(200)
    End Sub

    Private Sub AddQuickCash(amount As Decimal)
        If rdoCredit.Checked Then Return

        Dim currentVal As Decimal = 0
        Decimal.TryParse(txtPaidInput.Text, currentVal)
        txtPaidInput.Text = (currentVal + amount).ToString()
        CalculateAll()
    End Sub

    ' ==========================================
    ' 5. زر المبلغ بالظبط
    ' ==========================================
    Private Sub btnExactAmount_Click(sender As Object, e As EventArgs) Handles btnExactAmount.Click
        If rdoCredit.Checked Then Return

        txtPaidInput.Text = NetTotal.ToString()
        CalculateAll()
    End Sub

    ' ==========================================
    ' 6. أزرار الآلة الحاسبة (NumPad)
    ' ==========================================
    Private Sub RegisterNumPadEvents()
        Dim numButtons() As Guna2Button = {btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnDot}
        For Each btn In numButtons
            AddHandler btn.Click, AddressOf NumButton_Click
        Next
    End Sub

    Private Sub NumButton_Click(sender As Object, e As EventArgs)
        If rdoCredit.Checked Then Return

        Dim btn = CType(sender, Guna2Button)
        Dim digit As String = btn.Text.Trim()

        If txtPaidInput.Text = "0" AndAlso digit <> "." Then
            txtPaidInput.Text = digit
        Else
            If digit = "." AndAlso txtPaidInput.Text.Contains(".") Then Return
            txtPaidInput.Text &= digit
        End If

        CalculateAll()
    End Sub

    Private Sub btnClearInput_Click(sender As Object, e As EventArgs) Handles btnClearInput.Click
        txtPaidInput.Text = "0"
        CalculateAll()
    End Sub

    ' ==========================================
    ' 7. التغييرات عند كتابة الخصم اليدوي أو المبلغ المدفوع
    ' ==========================================
    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        CalculateAll()
    End Sub

    Private Sub txtPaidInput_TextChanged(sender As Object, e As EventArgs) Handles txtPaidInput.TextChanged
        CalculateAll()
    End Sub

    ' ==========================================
    ' 8. أزرار طريقة الدفع (نقدي / آجل)
    ' ==========================================
    Private Sub rdoCash_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCash.CheckedChanged
        IsCreditOrder = Not rdoCash.Checked
        CalculateAll()
    End Sub

    Private Sub rdoCredit_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCredit.CheckedChanged
        IsCreditOrder = rdoCredit.Checked

        If rdoCredit.Checked AndAlso _customer Is Nothing Then
            MessageBox.Show("عفواً! لا يمكن اختيار البيع الآجل لعميل نقدي/افتراضي غير مسجل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rdoCash.Checked = True
            Return
        End If

        CalculateAll()
    End Sub

    ' ==========================================
    ' 9. زر إلغاء
    ' ==========================================
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btn_close.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' ==========================================
    ' 10. زر تأكيد الدفع مع التحقق من حد الائتمان
    ' ==========================================
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        CalculateAll()

        ' مراجعة حد الائتمان ومنع الحفظ إذا تم تجاوزه
        If Not ValidateCreditLimit() Then
            Return
        End If

        IsCreditOrder = (RemainingAmount > 0) OrElse rdoCredit.Checked

        If cmbTreasury.SelectedValue IsNot Nothing Then
            SelectedTreasuryID = Convert.ToInt32(cmbTreasury.SelectedValue)
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class