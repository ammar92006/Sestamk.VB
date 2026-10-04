Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Guna.UI2.WinForms
Imports WindowsApp1.Customer

Public Class FrmCustomers

    Private ReadOnly _repo As POSRepository
    Private _selectedCustomerID As Integer = 0
    Private _cachedCustomers As List(Of CustomerModel) = Nothing
    Private _isLoadingOrClearing As Boolean = False

    Public Sub New()
        ' 1. تهيئة الـ Repository أولاً قبل InitializeComponent لمنع استدعاء أحداث الضوابط قبل إعداد الـ repo
        _repo = New POSRepository(DBModule.ConnectionString)
        InitializeComponent()
    End Sub

    ' 2. تشغيل مع تمرير الـ repo لو محتاجه من شاشة البيع مثلاً
    Public Sub New(repo As POSRepository)
        _repo = If(repo, New POSRepository(DBModule.ConnectionString))
        InitializeComponent()
    End Sub

    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' تعبئة قائمة الأعمدة بالعربية للبحث المتقدم
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("اسم العميل")
        cmbSearchField.Items.Add("كود العميل")
        cmbSearchField.Items.Add("رقم الموبايل")
        cmbSearchField.Items.Add("هاتف إضافي")
        cmbSearchField.Items.Add("العنوان")
        cmbSearchField.Items.Add("البريد الإلكتروني")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0
        txtCustomerCode.Text = GetNextCode("Customers", "CustomerCode")
        datagridviewsetup(dgvCustomers)
        SetupGrid()
        LoadAreasComboBox()
        RefreshData()
        ClearFields()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' =========================================================
    ' 1. إعدادات الشبكة (DataGridView Setup)
    ' تم نقل تعريف وتنسيق الأعمدة إلى الديزاينر FrmCustomers.Designer.vb
    ' =========================================================
    Private Sub SetupGrid()
        dgvCustomers.AutoGenerateColumns = False
    End Sub

    ' تحميل قائمة المناطق
    Private Sub LoadAreasComboBox()
        Try
            If _repo Is Nothing Then Return
            Dim areas = _repo.GetDeliveryAreas()
            cmbAreas.DataSource = areas
            cmbAreas.DisplayMember = "AreaName"
            cmbAreas.ValueMember = "AreaID"
            cmbAreas.SelectedIndex = -1
        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء تحميل المناطق: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' تحديث الجدول من قاعدة البيانات
    Private Sub RefreshData(Optional query As String = "")
        If _repo Is Nothing Then Return
        _cachedCustomers = _repo.GetAllCustomers("")
        ApplySearchFilter()
    End Sub

    ' =========================================================
    ' 2. دالة التحقق من البيانات قبل الحفظ والتعديل (Validation)
    ' =========================================================
    Private Function ValidateInput() As Boolean
        ' 0. كود العميل
        If String.IsNullOrWhiteSpace(txtCustomerCode.Text) Then
            txtCustomerCode.Text = GetNextCode("Customers", "CustomerCode").ToString()
        End If

        ' أ) اسم العميل
        If String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
            SmartMessageBox.Show("برجاء إدخال اسم العميل!", "تنبيه validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustomerName.Focus()
            Return False
        End If

        ' ب) رقم الموبايل
        If String.IsNullOrWhiteSpace(txtPhone1.Text) Then
            SmartMessageBox.Show("برجاء إدخال رقم الهاتف الرئيسي!", "تنبيه validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone1.Focus()
            Return False
        End If

        ' ج) التحقق من تكرار رقم الموبايل
        If _repo.IsPhoneExists(txtPhone1.Text, _selectedCustomerID) Then
            SmartMessageBox.Show("رقم الهاتف هذا مسجل لعميل آخر بالفعل!", "تنبيه تكرار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone1.Focus()
            Return False
        End If

        ' د) نسبة الخصم
        Dim discount As Double
        If Not String.IsNullOrWhiteSpace(txtDiscountPercent.Text) AndAlso Not Double.TryParse(txtDiscountPercent.Text, discount) Then
            SmartMessageBox.Show("برجاء إدخال نسبة خصم صحيحة!", "تنبيه validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDiscountPercent.Focus()
            Return False
        End If

        Return True
    End Function

    ' =========================================================
    ' 3. زر الإضافة (ADD)
    ' =========================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInput() Then Return

        Dim cust As New CustomerModel With {
            .CustomerCode = txtCustomerCode.Text.Trim(),
            .CustomerName = txtCustomerName.Text.Trim(),
            .Phone1 = txtPhone1.Text.Trim(),
            .Phone2 = txtPhone2.Text.Trim(),
            .Email = txtEmail.Text.Trim(),
            .Address = txtAddress.Text.Trim(),
            .AreaID = If(cmbAreas.SelectedValue IsNot Nothing, Convert.ToInt32(cmbAreas.SelectedValue), CType(Nothing, Integer?)),
            .IsDiscountPercent = btnIsDiscountPercent.Checked,
            .DiscountPercent = If(Double.TryParse(txtDiscountPercent.Text, Nothing), Convert.ToDouble(txtDiscountPercent.Text), 0),
            .Notes = txtNotes.Text.Trim(),
            .IsActive = chkIsActive.Checked
        }

        If _repo.AddCustomer(cust) Then
            SmartMessageBox.Show("تمت إضافة العميل بنجاح!", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshData()
            ClearFields()
        Else
            SmartMessageBox.Show("حدث خطأ أثناء حفظ العميل!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' =========================================================
    ' 4. زر التعديل (UPDATE)
    ' =========================================================
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If _selectedCustomerID = 0 Then
            SmartMessageBox.Show("برجاء تحديد عميل من الجدول أولاً للتعديل!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInput() Then Return

        Dim cust As New CustomerModel With {
            .CustomerID = _selectedCustomerID,
            .CustomerCode = txtCustomerCode.Text.Trim(),
            .CustomerName = txtCustomerName.Text.Trim(),
            .Phone1 = txtPhone1.Text.Trim(),
            .Phone2 = txtPhone2.Text.Trim(),
            .Email = txtEmail.Text.Trim(),
            .Address = txtAddress.Text.Trim(),
            .AreaID = If(cmbAreas.SelectedValue IsNot Nothing, Convert.ToInt32(cmbAreas.SelectedValue), CType(Nothing, Integer?)),
            .IsDiscountPercent = btnIsDiscountPercent.Checked,
            .DiscountPercent = If(Double.TryParse(txtDiscountPercent.Text, Nothing), Convert.ToDouble(txtDiscountPercent.Text), 0),
            .Notes = txtNotes.Text.Trim(),
            .IsActive = chkIsActive.Checked
        }

        If _repo.UpdateCustomer(cust) Then
            SmartMessageBox.Show("تم تعديل بيانات العميل بنجاح!", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshData()
            ClearFields()
        Else
            SmartMessageBox.Show("حدث خطأ أثناء تعديل بيانات العميل!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' =========================================================
    ' 5. زر الحذف الناعم (SOFT DELETE)
    ' =========================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _selectedCustomerID = 0 Then
            SmartMessageBox.Show("برجاء تحديد العميل المراد حذفه من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = SmartMessageBox.Show("هل أنت تأكد من نقل هذا العميل لسلة المحذوفات؟", "تأكيد الحذف الناعم", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            If _repo.SoftDeleteCustomer(_selectedCustomerID) Then
                SmartMessageBox.Show("تم حذف العميل بنجاح!", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RefreshData()
                ClearFields()
            Else
                SmartMessageBox.Show("حدث خطأ أثناء تنفيذ عملية الحذف!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    ' =========================================================
    ' 6. زر التفريغ (CLEAR)
    ' =========================================================
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        _isLoadingOrClearing = True
        Try
            _selectedCustomerID = 0
            'txtCustomerCode.Text = ""
            txtCustomerCode.Text = GetNextCode("Customers", "CustomerCode")
            txtCustomerName.Text = ""
            txtPhone1.Text = ""
            txtPhone2.Text = ""
            txtEmail.Text = ""
            txtAddress.Text = ""
            txtDiscountPercent.Text = "0"
            lblCurrentBalance.Text = "0"
            txtCredit.Text = "0"
            txtDebit.Text = "0"
            txtNotes.Text = ""
            txtSearch.Text = ""
            lstSuggestions.Visible = False
            chkIsActive.Checked = True
            btnIsDiscountPercent.Checked = False

            ' إلغاء تحديد الجدول لمنع إعادة اختيار العميل مجدداً
            dgvCustomers.ClearSelection()

            ' تفريغ Guna2ComboBox بالكامل
            cmbAreas.SelectedIndex = -1

            ' إعادة تفعيل الأزرار
            btnAdd.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        Finally
            _isLoadingOrClearing = False
        End Try
    End Sub

    ' =========================================================
    ' 7. زر التحديث (REFRESH)
    ' =========================================================
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Text = ""
        RefreshData()
        ClearFields()
    End Sub

    ' =========================================================
    ' 8. اختيار عميل من الجدول واقتباس بياناته (Selection)
    ' =========================================================
    Private Sub dgvCustomers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCustomers.SelectionChanged
        If _isLoadingOrClearing Then Return

        If dgvCustomers.SelectedRows.Count > 0 AndAlso dgvCustomers.CurrentRow IsNot Nothing AndAlso dgvCustomers.CurrentRow.DataBoundItem IsNot Nothing Then
            Dim cust = CType(dgvCustomers.CurrentRow.DataBoundItem, CustomerModel)

            _selectedCustomerID = cust.CustomerID
            txtCustomerCode.Text = cust.CustomerCode
            txtCustomerName.Text = cust.CustomerName
            lblCurrentBalance.Text = cust.CurrentBalance
            txtPhone1.Text = cust.Phone1
            txtPhone2.Text = cust.Phone2
            txtEmail.Text = cust.Email
            txtAddress.Text = cust.Address
            txtDiscountPercent.Text = If(cust.DiscountPercent.HasValue, cust.DiscountPercent.Value.ToString(), "0")
            txtNotes.Text = cust.Notes
            chkIsActive.Checked = If(cust.IsActive.HasValue, cust.IsActive.Value, True)

            If cust.AreaID.HasValue Then
                cmbAreas.SelectedValue = cust.AreaID.Value
            Else
                cmbAreas.SelectedIndex = -1
            End If

            If cust.IsDiscountPercent.HasValue Then
                btnIsDiscountPercent.Checked = cust.IsDiscountPercent.Value
            Else
                btnIsDiscountPercent.Checked = True
            End If

            ' التحكم في تفعيل الأزرار
            btnAdd.Enabled = False
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    ' =========================================================
    ' 9. البحث اللحظي المتقدم وقائمة الاقتراحات التلقائية
    ' =========================================================
    Private Sub ApplySearchFilter()
        If _cachedCustomers Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم العميل")

        If String.IsNullOrWhiteSpace(keyword) Then
            dgvCustomers.DataSource = _cachedCustomers
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim kwLower As String = keyword.ToLower()
        Dim filteredList As New List(Of CustomerModel)()

        For Each c In _cachedCustomers
            Dim isMatch As Boolean = False
            Select Case selectedField
                Case "كود العميل"
                    isMatch = c.CustomerCode IsNot Nothing AndAlso c.CustomerCode.ToLower().Contains(kwLower)
                Case "اسم العميل"
                    isMatch = c.CustomerName IsNot Nothing AndAlso c.CustomerName.ToLower().Contains(kwLower)
                Case "رقم الموبايل"
                    isMatch = (c.Phone1 IsNot Nothing AndAlso c.Phone1.ToLower().Contains(kwLower)) OrElse (c.Phone2 IsNot Nothing AndAlso c.Phone2.ToLower().Contains(kwLower))
                Case "هاتف إضافي"
                    isMatch = c.Phone2 IsNot Nothing AndAlso c.Phone2.ToLower().Contains(kwLower)
                Case "العنوان"
                    isMatch = c.Address IsNot Nothing AndAlso c.Address.ToLower().Contains(kwLower)
                Case "البريد الإلكتروني"
                    isMatch = c.Email IsNot Nothing AndAlso c.Email.ToLower().Contains(kwLower)
                Case "ملاحظات"
                    isMatch = c.Notes IsNot Nothing AndAlso c.Notes.ToLower().Contains(kwLower)
                Case Else ' الكل
                    isMatch = (c.CustomerName IsNot Nothing AndAlso c.CustomerName.ToLower().Contains(kwLower)) OrElse
                              (c.CustomerCode IsNot Nothing AndAlso c.CustomerCode.ToLower().Contains(kwLower)) OrElse
                              (c.Phone1 IsNot Nothing AndAlso c.Phone1.ToLower().Contains(kwLower)) OrElse
                              (c.Phone2 IsNot Nothing AndAlso c.Phone2.ToLower().Contains(kwLower)) OrElse
                              (c.Address IsNot Nothing AndAlso c.Address.ToLower().Contains(kwLower)) OrElse
                              (c.Email IsNot Nothing AndAlso c.Email.ToLower().Contains(kwLower)) OrElse
                              (c.Notes IsNot Nothing AndAlso c.Notes.ToLower().Contains(kwLower))
            End Select

            If isMatch Then filteredList.Add(c)
        Next

        dgvCustomers.DataSource = filteredList
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedCustomers Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim kwLower As String = keyword.ToLower()
        Dim matches As New List(Of String)()

        For Each c In _cachedCustomers
            Dim val As String = ""
            Select Case field
                Case "كود العميل"
                    val = c.CustomerCode
                Case "رقم الموبايل"
                    val = c.Phone1
                Case "هاتف إضافي"
                    val = c.Phone2
                Case "العنوان"
                    val = c.Address
                Case "البريد الإلكتروني"
                    val = c.Email
                Case "ملاحظات"
                    val = c.Notes
                Case Else
                    val = c.CustomerName
            End Select

            If Not String.IsNullOrWhiteSpace(val) AndAlso val.ToLower().Contains(kwLower) AndAlso Not matches.Contains(val) Then
                matches.Add(val)
            End If
        Next

        If matches.Count > 0 Then
            lstSuggestions.Items.AddRange(matches.ToArray())
            lstSuggestions.BringToFront()
            lstSuggestions.Visible = True
        Else
            lstSuggestions.Visible = False
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearchFilter()
    End Sub

    Private Sub cmbSearchField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchField.SelectedIndexChanged
        ApplySearchFilter()
    End Sub

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        SelectSuggestion()
    End Sub

    Private Sub lstSuggestions_DoubleClick(sender As Object, e As EventArgs) Handles lstSuggestions.DoubleClick
        SelectSuggestion()
    End Sub

    Private Sub SelectSuggestion()
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txtSearch.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
            ApplySearchFilter()

            If dgvCustomers.Rows.Count > 0 Then
                dgvCustomers.ClearSelection()
                dgvCustomers.Rows(0).Selected = True
            End If
        End If
    End Sub

    ' =========================================================
    ' 10. أزرار التحكم بالنافذة
    ' =========================================================
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub UpdateBalanceFields(
        source As BalanceSource,
        lblCurrentBalance As Label,
        txtDebit As Guna2TextBox,
        txtCredit As Guna2TextBox)

        Dim balance As Decimal = 0
        Dim debit As Decimal = 0
        Dim credit As Decimal = 0

        Decimal.TryParse(lblCurrentBalance.Text.Trim(), balance)
        Decimal.TryParse(txtDebit.Text.Trim(), debit)
        Decimal.TryParse(txtCredit.Text.Trim(), credit)

        Select Case source

            Case BalanceSource.Balance
                If balance < 0 Then
                    txtDebit.Text = Math.Abs(balance).ToString()
                    txtCredit.Text = "0.00"
                Else
                    txtDebit.Text = "0.00"
                    txtCredit.Text = balance.ToString()
                End If

            Case BalanceSource.Debit
                txtCredit.Text = "0.00"
                lblCurrentBalance.Text = (-Math.Abs(debit)).ToString()

            Case BalanceSource.Credit
                txtDebit.Text = "0.00"
                lblCurrentBalance.Text = Math.Abs(credit).ToString()

        End Select
    End Sub

    Private Sub lblCurrentBalance_TextChanged(sender As Object, e As EventArgs) Handles lblCurrentBalance.TextChanged
        UpdateBalanceFields(BalanceSource.Balance, lblCurrentBalance, txtDebit, txtCredit)
    End Sub

End Class