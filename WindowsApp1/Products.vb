Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DevExpress.Utils.About
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraEditors
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraRichEdit.Import.Html
Imports Guna.UI2.WinForms
Imports Microsoft.Office.Interop
Imports OfficeOpenXml
Imports ZXing

Public Class Products

    Private _searchTimer As New Timer() With {.Interval = 350}

    '    ' ✅ Cache: تخزين المنتجات في الذاكرة للبحث الفوري بدون DB
    '    '    O(n) بدلاً من رحلة شبكية في كل بحث
    Private _cachedProducts As DataTable = Nothing

    '    ' ✅ Flag: تهيئة أعمدة الـ DataGridView مرة واحدة فقط عند التحميل
    '    '    بدلاً من تنفيذ 15 عملية في كل DataBindingComplete
    '    Private _columnsConfigured As Boolean = False

    '    ' ✅ الـ SQL الأساسي في متغير مشترك لتجنب تكرار كتابته
    '    Private Const BASE_QUERY As String =
    '        "SELECT
    '            P.Product_ID,
    '            P.BaseUnit_ID,
    '            PU.Unit_Name,
    '            P.Product_Code,
    '            P.Product_Name,
    '            C.Category_Name,
    '            V.CompanyName,
    '            V.SuppliersName,
    '            P.Product_Image,
    '            P.Product_Note,
    '            P.Product_State
    '         FROM dbo.Products AS P
    '         LEFT JOIN dbo.Categories AS C ON P.Category_ID = C.Category_ID
    '         LEFT JOIN dbo.Suppliers AS V ON P.Partner_ID = V.SuppliersID
    '         LEFT JOIN dbo.ProductUnits AS PU ON PU.ProductUnit_ID = P.BaseUnit_ID"
    '#End Region


    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs)
        _searchTimer.Stop() ' نفِّذ مرة واحدة فقط

        Dim keyword As String = txtSearch.Text.Trim()
        If keyword.Length < 1 Then
            If _cachedProducts IsNot Nothing Then
                dgvProducts.DataSource = _cachedProducts
            Else
                LoadProductsGrid()
            End If
            lstSuggestions.Visible = False
            Return
        End If

        Dim field As String = If(cmbSearchField.SelectedItem?.ToString(), "")
        If field = "" Then Return

        ' [تحسين] البحث في الذاكرة - لا رحلة DB على الإطلاق
        LoadProductsGrid(keyword, field)
        UpdateSuggestionsFromCache(keyword, field)
        dgvProducts.ClearSelection()
    End Sub

    ' [تحسين #7] الاقتراحات من Cache في الذاكرة - لا DB إضافي
    Private Sub UpdateSuggestionsFromCache(keyword As String, field As String)
        lstSuggestions.Items.Clear()
        If _cachedProducts Is Nothing Then Return

        Dim columnName As String = GetColumnName(field)
        If String.IsNullOrEmpty(columnName) Then Return

        Dim shortCol As String = If(columnName.Contains("."c), columnName.Split("."c)(1), columnName)
        If Not _cachedProducts.Columns.Contains(shortCol) Then Return

        ' فلترة من الـ DataTable المخزنة في الذاكرة
        Dim suggestions = _cachedProducts.AsEnumerable().
            Where(Function(r) Not IsDBNull(r(shortCol)) AndAlso
                              r(shortCol).ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).
            Select(Function(r) r(shortCol).ToString()).
            Distinct().
            OrderBy(Function(s) s).
            Take(10). ' حد أقصى 10 اقتراحات لمنع إبطاء الـ UI
            ToList()

        If suggestions.Count > 0 Then
            lstSuggestions.Items.AddRange(suggestions.ToArray())
            lstSuggestions.Visible = True
        Else
            lstSuggestions.Visible = False
        End If
    End Sub

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txtSearch.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
        End If
    End Sub

    Private Sub cmbSearchField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchField.SelectedIndexChanged
        Dim keyword As String = txtSearch.Text.Trim()
        lstSuggestions.Items.Clear()

        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            If _cachedProducts IsNot Nothing Then
                dgvProducts.DataSource = _cachedProducts
            Else
                LoadProductsGrid()
            End If
            Return
        End If

        Dim field As String = cmbSearchField.SelectedItem?.ToString()
        If String.IsNullOrEmpty(field) Then Return

        LoadProductsGrid(keyword, field)
        UpdateSuggestionsFromCache(keyword, field)
    End Sub
    '#End Region

    '#Region "═══ دالة مساعدة: تحويل الحقل العربي لاسم العمود ═══"
    Private Function GetColumnName(field As String) As String
        Select Case field
            Case "الاسم عربي" : Return "ProductNameAr"
            Case "كود الصنف" : Return "ProductCode"
            Case "الاسم إنجليزي" : Return "ProductNameEn"
            Case "الفئة" : Return "Category_NameAr"
            Case "الوصف" : Return "Description"
            Case Else : Return ""
        End Select
    End Function
    '#End Region


    Dim x, y As Integer
    Dim newpoint As New Point

    Private Sub LoadProductsGrid(Optional filter As String = "", Optional field As String = "")
        Try
            ' 1. التحقق وجلب البيانات في الكاش إذا كان فارغاً
            If _cachedProducts Is Nothing OrElse (String.IsNullOrEmpty(filter) AndAlso String.IsNullOrEmpty(field)) Then
                Dim query As String = "SELECT P.Product_ID, P.ProductCode, P.ProductNameAr, P.ProductNameEn, P.Image, " &
                                  "P.Description, P.DiscountPercent, P.IsDiscountPercent, P.TaxPercent, P.IsTaxPercent, P.IsActive, P.PreparationTime, " &
                                  "P.Notes, P.Category_ID, Cat.Category_NameAr " &
                                  "FROM Products P " &
                                  "LEFT JOIN Categories Cat ON P.Category_ID = Cat.Category_ID " &
                                  "WHERE P.IsDeleted = 0 OR P.IsDeleted IS NULL"

                Dim freshDt As DataTable = DBModule.ExecuteQuery(query)

                If _cachedProducts IsNot Nothing Then _cachedProducts.Dispose()
                _cachedProducts = freshDt
            End If

            ' 🛑 خط دفاع أول: إذا كان الكاش لا يزال فارغاً بسبب فشل الاتصال، نخرج فوراً لمنع الـ Crash
            If _cachedProducts Is Nothing Then Exit Sub

            ' 2. معالجة التصفية والبحث في الذاكرة
            Dim dtToBind As DataTable = _cachedProducts

            If Not String.IsNullOrEmpty(filter) AndAlso Not String.IsNullOrEmpty(field) Then
                Dim columnName As String = ""
                Select Case field.Trim()
                    Case "كود الصنف" : columnName = "ProductCode"
                    Case "الاسم عربي" : columnName = "ProductNameAr"
                    Case "الاسم إنجليزي" : columnName = "ProductNameEn"
                    Case "الفئة" : columnName = "Category_NameAr"
                    Case "الوصف" : columnName = "Description"
                End Select

                If columnName <> "" AndAlso _cachedProducts.Columns.Contains(columnName) Then
                    Dim dv As New DataView(_cachedProducts)
                    Dim safeFilter As String = filter.Replace("'", "''")
                    dv.RowFilter = $"{columnName} LIKE '%{safeFilter}%'"
                    dtToBind = dv.ToTable()
                End If
            End If

            ' 3. ربط البيانات بالـ DataGridView
            dgvProducts.DataSource = dtToBind

            ' 🛑 حماية التنسيقات (تأمين الأعمدة ضد الـ NullReferenceException)
            ' نتحقق أولاً من وجود العمود قبل تعديل خصائصه

            Dim hiddenColumns As String() = {"Product_ID", "Category_ID", "Image", "IsDiscountPercent", "IsTaxPercent"}
            For Each col In hiddenColumns
                If dgvProducts.Columns.Contains(col) Then dgvProducts.Columns(col).Visible = False
            Next

            ' تغيير العناوين فقط للأعمدة الموجودة بالفعل في الجريد
            If dgvProducts.Columns.Contains("ProductCode") Then dgvProducts.Columns("ProductCode").HeaderText = "كود الصنف"
            If dgvProducts.Columns.Contains("ProductNameAr") Then dgvProducts.Columns("ProductNameAr").HeaderText = "الاسم عربي"
            If dgvProducts.Columns.Contains("ProductNameEn") Then dgvProducts.Columns("ProductNameEn").HeaderText = "الاسم إنجليزي"
            If dgvProducts.Columns.Contains("Category_NameAr") Then dgvProducts.Columns("Category_NameAr").HeaderText = "القسم/الفئة"
            If dgvProducts.Columns.Contains("DiscountPercent") Then dgvProducts.Columns("DiscountPercent").HeaderText = "الخصم"
            If dgvProducts.Columns.Contains("TaxPercent") Then dgvProducts.Columns("TaxPercent").HeaderText = "الضريبة"
            If dgvProducts.Columns.Contains("PreparationTime") Then dgvProducts.Columns("PreparationTime").HeaderText = "وقت التحضير"
            If dgvProducts.Columns.Contains("Description") Then dgvProducts.Columns("Description").HeaderText = "الوصف"

            If dgvProducts.Columns.Contains("IsActive") Then
                dgvProducts.Columns("IsActive").HeaderText = "نشط"
                dgvProducts.Columns("IsActive").Width = 60
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل وتصفية المنتجات: " & ex.Message, "خطأ خطير", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler _searchTimer.Tick, AddressOf SearchTimer_Tick
        FillCategoriesComboBox() ' ملء قائمة الأقسام أولاً
        LoadProductsGrid() ' عرض الأصناف
        datagridviewsetup()
        dtpPrepTime.Format = DateTimePickerFormat.Custom
        dtpPrepTime.CustomFormat = "HH:mm:ss" ' صيغة 24 ساعة (أو "hh:mm:ss tt" لصيغة AM/PM)
        dtpPrepTime.ShowUpDown = True ' إظهار أسهم للتحكم بالوقت بدلاً من النتيجة (Calendar)
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.AddRange(New Object() {
            "كود الصنف",
            "الاسم عربي",
            "الاسم إنجليزي",
            "الفئة",
            "الوصف"
        })
        txtProductCode.Text = GetNextCode("Products", "ProductCode")
        ' تحديد العنصر الأول كخيار افتراضي (الاسم عربي) لكي لا يظل فارغاً
        If cmbSearchField.Items.Count > 0 Then
            cmbSearchField.SelectedIndex = 0
        End If
    End Sub
    Private Sub FillCategoriesComboBox()
        Dim query As String = "SELECT Category_ID, Category_NameAr FROM Categories WHERE IsActive = 1 AND IsDeleted = 0 OR IsDeleted IS NULL"
        Dim dt As DataTable = DBModule.ExecuteQuery(query)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            cmbCategory.DataSource = dt
            cmbCategory.DisplayMember = "Category_NameAr"
            cmbCategory.ValueMember = "Category_ID"
            cmbCategory.SelectedIndex = -1
        End If
    End Sub
    ' 2. دالة التحقق من البيانات (Validation)
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtProductNameAr.Text) Then
            MessageBox.Show("يجب إدخال اسم الصنف بالعربي!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductNameAr.Focus()
            Return False
        End If
        If cmbCategory.SelectedIndex = -1 OrElse cmbCategory.SelectedValue Is Nothing Then
            MessageBox.Show("يرجى اختيار القسم التابع له الصنف!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Return False
        End If
        Return True
    End Function

    ' 3. دالة تنظيف الحقول
    Private Sub ClearFields()
        'txtProductCode.Clear()
        txtProductCode.Text = GetNextCode("Products", "ProductCode")
        txtProductNameAr.Clear()
        txtProductNameEn.Clear()
        txtDescription.Clear()
        txtDiscount.Text = "0"
        txtTax.Text = "0"
        txtNotes.Clear()
        dtpPrepTime.Text = "00:00:00"
        cmbCategory.SelectedIndex = -1
        picProduct.Image = Nothing
        tgStatus.Checked = True
        dgvProducts.ClearSelection()
        btnDiscountType.Checked = False
        btnTaxType.Checked = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub
    Private Sub datagridviewsetup()
        Main.datagridviewsetup(dgvProducts)
    End Sub
    ' 4. حدث التحديد التلقائي بأمان لعرض بيانات الصنف والصورة
    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If dgvProducts.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvProducts.SelectedRows(0)

        If row.Cells("Product_ID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Product_ID").Value) Then
            txtProductCode.Text = If(IsDBNull(row.Cells("ProductCode").Value), "", row.Cells("ProductCode").Value.ToString())
            txtProductNameAr.Text = If(IsDBNull(row.Cells("ProductNameAr").Value), "", row.Cells("ProductNameAr").Value.ToString())
            txtProductNameEn.Text = If(IsDBNull(row.Cells("ProductNameEn").Value), "", row.Cells("ProductNameEn").Value.ToString())
            txtDescription.Text = If(IsDBNull(row.Cells("Description").Value), "", row.Cells("Description").Value.ToString())
            txtDiscount.Text = If(IsDBNull(row.Cells("DiscountPercent").Value), "0", row.Cells("DiscountPercent").Value.ToString())
            txtTax.Text = If(IsDBNull(row.Cells("TaxPercent").Value), "0", row.Cells("TaxPercent").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            'txtPrepTime.Text = If(IsDBNull(row.Cells("PreparationTime").Value), "00:00:00", row.Cells("PreparationTime").Value.ToString())
            ' داخل دالة dgvProducts_SelectionChanged
            If Not IsDBNull(row.Cells("IsDiscountPercent").Value) Then
                btnDiscountType.Checked = Convert.ToBoolean(row.Cells("IsDiscountPercent").Value)
                ' هنا يمكنك تغيير لون الزر أو حالته البصرية ليطابق الـ Checked (مثلاً لون أخضر أو أزرق لو مفعل، ورمادي لو معطل)
            End If

            If Not IsDBNull(row.Cells("IsTaxPercent").Value) Then
                btnTaxType.Checked = Convert.ToBoolean(row.Cells("IsTaxPercent").Value)
            End If

            ' التعديل الخاص بعرض الوقت داخل دالة dgvProducts_SelectionChanged
            If Not IsDBNull(row.Cells("PreparationTime").Value) Then
                ' تحويل الـ TimeSpan القادم من قاعدة البيانات إلى DateTime ليقبله الكنترول
                Dim prepTime As TimeSpan = DirectCast(row.Cells("PreparationTime").Value, TimeSpan)
                dtpPrepTime.Value = DateTime.Today.Add(prepTime)
            Else
                dtpPrepTime.Value = DateTime.Today ' وقت افتراضي (00:00:00) في حال كان فارغاً
            End If

            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))

            ' تحديد القسم في الكومبو بوكس بناءً على الـ ID
            If Not IsDBNull(row.Cells("Category_ID").Value) Then
                cmbCategory.SelectedValue = row.Cells("Category_ID").Value
            Else
                cmbCategory.SelectedIndex = -1
            End If

            ' عرض الصورة المحولة من الـ Base64 بأمان
            If Not IsDBNull(row.Cells("Image").Value) AndAlso Not String.IsNullOrEmpty(row.Cells("Image").Value.ToString()) Then
                picProduct.Image = DBModule.Base64ToImage(row.Cells("Image").Value.ToString())
                picProduct.SizeMode = PictureBoxSizeMode.Zoom
            Else
                picProduct.Image = Nothing
            End If
        End If
    End Sub

    ' 5. زر إضافة صنف جديد
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO Products (ProductCode, ProductNameAr, ProductNameEn, Image, Description, DiscountPercent,IsDiscountPercent, TaxPercent,IsTaxPercent, IsActive, IsDeleted, PreparationTime, Notes, Category_ID) " &
                              "VALUES (@ProductCode, @ProductNameAr, @ProductNameEn, @Image, @Description, @DiscountPercent,@IsDiscountPercent, @TaxPercent,@IsTaxPercent, @IsActive, 0, @PreparationTime, @Notes, @Category_ID)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductCode", If(String.IsNullOrEmpty(txtProductCode.Text), DBNull.Value, txtProductCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@ProductNameAr", txtProductNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@ProductNameEn", If(String.IsNullOrEmpty(txtProductNameEn.Text), DBNull.Value, txtProductNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                'cmd.Parameters.AddWithValue("@DiscountPercent", If(String.IsNullOrEmpty(txtDiscount.Text), 0, Convert.ToDouble(txtDiscount.Text.Trim())))
                'cmd.Parameters.AddWithValue("@TaxPercent", If(String.IsNullOrEmpty(txtTax.Text), 0, txtTax.Text.Trim())) ' لو عدلته لـ float حوله لـ Convert.ToDouble
                ' 1. تمرير قيمة ونوع الخصم
                cmd.Parameters.AddWithValue("@DiscountPercent", If(String.IsNullOrEmpty(txtDiscount.Text), 0, Convert.ToDouble(txtDiscount.Text.Trim())))
                cmd.Parameters.AddWithValue("@IsDiscountPercent", btnDiscountType.Checked) ' حفظ حالة زر الخصم

                ' 2. تمرير قيمة ونوع الضريبة
                cmd.Parameters.AddWithValue("@TaxPercent", If(String.IsNullOrEmpty(txtTax.Text), 0, Convert.ToDouble(txtTax.Text.Trim())))
                cmd.Parameters.AddWithValue("@IsTaxPercent", btnTaxType.Checked) ' حفظ حالة زر الضريبة
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@Category_ID", cmbCategory.SelectedValue)

                '' وقت التحضير (Time)
                'Dim prepTime As TimeSpan
                'If TimeSpan.TryParse(txtPrepTime.Text, prepTime) Then
                '    cmd.Parameters.AddWithValue("@PreparationTime", prepTime)
                'Else
                '    cmd.Parameters.AddWithValue("@PreparationTime", DBNull.Value)
                'End If
                ' التعديل الخاص بالبارامتر داخل دالتي الحفظ والتعديل (Insert & Update)
                Dim selectedTime As TimeSpan = dtpPrepTime.Value.TimeOfDay
                cmd.Parameters.AddWithValue("@PreparationTime", selectedTime)

                ' حفظ الصورة كـ Base64
                Dim imgBase64 As String = DBModule.ImageToBase64(picProduct.Image)
                cmd.Parameters.AddWithValue("@Image", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ الصنف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadProductsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            ' 1. إعادة ملء الفئات المربوطة (في حال أضاف المستخدم فئات جديدة من الشاشة الأخرى)
            FillCategoriesComboBox()

            ' 2. إعادة تحميل داتا الأصناف بالكامل
            LoadProductsGrid()

            ' 3. تفريغ الحقول لتجنب التداخل
            ClearFields()

            MessageBox.Show("تم تحديث البيانات وجلب أحدث السجلات بنجاح!", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("حدثت مشكلة أثناء التحديث: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' 1. التحقق من تحديد صف من الجدول أولاً
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار الصنف المراد تعديله من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. خط الدفاع الأول: التحقق من صحة البيانات
        If Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)

        Dim query As String = "UPDATE Products SET ProductCode = @ProductCode, ProductNameAr = @ProductNameAr, " &
                              "ProductNameEn = @ProductNameEn, Image = @Image, Description = @Description, " &
                              "DiscountPercent = @DiscountPercent,IsDiscountPercent = @IsDiscountPercent, TaxPercent = @TaxPercent,IsTaxPercent = @IsTaxPercent, IsActive = @IsActive, " &
                              "PreparationTime = @PreparationTime, Notes = @Notes, Category_ID = @Category_ID " &
                              "WHERE Product_ID = @Product_ID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Product_ID", currentID)
                cmd.Parameters.AddWithValue("@ProductCode", If(String.IsNullOrEmpty(txtProductCode.Text), DBNull.Value, txtProductCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@ProductNameAr", txtProductNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@ProductNameEn", If(String.IsNullOrEmpty(txtProductNameEn.Text), DBNull.Value, txtProductNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                cmd.Parameters.AddWithValue("@DiscountPercent", If(String.IsNullOrEmpty(txtDiscount.Text), 0, Convert.ToDouble(txtDiscount.Text.Trim())))
                cmd.Parameters.AddWithValue("@IsDiscountPercent", btnDiscountType.Checked) ' حفظ حالة زر الخصم
                cmd.Parameters.AddWithValue("@TaxPercent", If(String.IsNullOrEmpty(txtTax.Text), 0, txtTax.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsTaxPercent", btnTaxType.Checked) ' حفظ حالة زر الضريبة
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@Category_ID", cmbCategory.SelectedValue)

                ' وقت التحضير من الـ Guna2DateTimePicker
                cmd.Parameters.AddWithValue("@PreparationTime", dtpPrepTime.Value.TimeOfDay)

                ' تحويل وصيانة الصورة كـ Base64
                Dim imgBase64 As String = DBModule.ImageToBase64(picProduct.Image)
                cmd.Parameters.AddWithValue("@Image", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل بيانات الصنف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadProductsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار الصنف المراد حذفه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' رسالة تأكيد لحماية صيانة البيانات من الأخطاء العفوية
        Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا الصنف؟ (حذف ناعم)", "تأكيد الحذف",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If result = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)
            Dim query As String = "UPDATE Products SET IsDeleted = 1 WHERE Product_ID = @Product_ID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Product_ID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الصنف بنجاح بنمط الحذف الناعم!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadProductsGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' إيقاف التايمر مؤقتاً عند كل ضغطة زر
        _searchTimer.Stop()

        Dim keyword As String = txtSearch.Text.Trim()

        ' إذا قام المستخدم بمسح نص البحث، أظهر كل البيانات فوراً من الكاش دون انتظار التايمر
        If keyword.Length = 0 Then
            If _cachedProducts IsNot Nothing Then
                dgvProducts.DataSource = _cachedProducts
            Else
                LoadProductsGrid()
            End If
            Return
        End If

        ' ابدأ العد التنازلي للتنفيذ بعد توقف الكتابة
        _searchTimer.Start()
    End Sub

    Private Sub btnAddCategoryForm_Click(sender As Object, e As EventArgs) Handles btnAddCategoryForm.Click
        Dim frm As New Categories()
        frm.ShowDialog()
        FillCategoriesComboBox()
    End Sub

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub
End Class


