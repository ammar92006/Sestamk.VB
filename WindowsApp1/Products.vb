Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports Guna.UI2.WinForms

Public Class Products

    Private _searchTimer As New Timer() With {.Interval = 300}
    Private _cachedProducts As DataTable = Nothing
    Private _isLoading As Boolean = False
    Private _dragHelper As FormDragHelper

    ' ═══════════════════════════════════════════════════════════
    ' 1. التحميل والتهيئة
    ' ═══════════════════════════════════════════════════════════
    Private Sub Products_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _isLoading = True

            ' تفعيل سحب النافذة
            _dragHelper = New FormDragHelper(Me, panelHeader)

            ' تهيئة تايمر البحث
            AddHandler _searchTimer.Tick, AddressOf SearchTimer_Tick

            ' ضبط التنسيق للجدول ووقت التحضير
            datagridviewsetup()
            dtpPrepTime.Format = DateTimePickerFormat.Custom
            dtpPrepTime.CustomFormat = "HH:mm:ss"
            dtpPrepTime.ShowUpDown = True

            ' تعبئة القوائم
            FillCategoriesComboBox()
            FillUnitsComboBox()

            ' إعداد عناصر تصفية البحث
            cmbSearchField.SelectedIndex = 0
            cmbStockFilter.SelectedIndex = 0

            ' جلب كود الصنف التالي تلقائياً
            txtProductCode.Text = GetNextProductCode()

            ' تحميل الأصناف وعرضها
            LoadProductsGrid()

        Catch ex As Exception
            Logger.LogError("Products_Load", ex)
        Finally
            _isLoading = False
        End Try
    End Sub

    Private Sub datagridviewsetup()
        Main.datagridviewsetup(dgvProducts)
    End Sub

    ' ═══════════════════════════════════════════════════════════
    ' 2. ملء القوائم (الأقسام والوحدات)
    ' ═══════════════════════════════════════════════════════════
    Private Sub FillCategoriesComboBox()
        Try
            Dim query As String = "SELECT Category_ID, Category_NameAr FROM Categories WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND (IsActive = 1 OR IsActive IS NULL) ORDER BY Category_NameAr"
            Dim dt As DataTable = DBModule.ExecuteQuery(query)

            If dt IsNot Nothing Then
                ' كومبو بوكس إدخال الصنف
                cmbCategory.DataSource = dt.Copy()
                cmbCategory.DisplayMember = "Category_NameAr"
                cmbCategory.ValueMember = "Category_ID"
                cmbCategory.SelectedIndex = -1

                ' كومبو بوكس فلتر البحث فوق الجدول
                Dim dtFilter As DataTable = dt.Copy()
                Dim allRow As DataRow = dtFilter.NewRow()
                allRow("Category_ID") = 0
                allRow("Category_NameAr") = "جميع الأقسام"
                dtFilter.Rows.InsertAt(allRow, 0)

                cmbFilterCategory.DataSource = dtFilter
                cmbFilterCategory.DisplayMember = "Category_NameAr"
                cmbFilterCategory.ValueMember = "Category_ID"
                cmbFilterCategory.SelectedIndex = 0
            End If
        Catch ex As Exception
            Logger.LogError("FillCategoriesComboBox", ex)
        End Try
    End Sub

    Private Sub FillUnitsComboBox()
        Try
            Dim dtUnits As DataTable = DBModule.ExecuteQuery("SELECT UnitName FROM Units WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND (IsActive = 1 OR IsActive IS NULL) ORDER BY UnitName")
            If dtUnits IsNot Nothing AndAlso dtUnits.Rows.Count > 0 Then
                cmbUnit.Items.Clear()
                For Each r As DataRow In dtUnits.Rows
                    cmbUnit.Items.Add(r("UnitName").ToString())
                Next
            End If

            If cmbUnit.Items.Count = 0 Then
                cmbUnit.Items.AddRange(New Object() {"قطعة", "علبة", "كجم", "جرام", "لتر", "مل", "وجبة", "متر", "كرتونة"})
            End If

            If cmbUnit.Items.Count > 0 Then cmbUnit.SelectedIndex = 0
        Catch ex As Exception
            Logger.LogError("FillUnitsComboBox", ex)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════
    ' 3. تحميل وعرض جدول الأصناف مع حساب الإحصائيات (KPIs)
    ' ═══════════════════════════════════════════════════════════
    Private Sub LoadProductsGrid(Optional filter As String = "", Optional field As String = "", Optional categoryID As Integer = 0, Optional stockState As Integer = 0)
        Try
            ' 1. استعلام كامل بكل بيانات الصنف
            Dim query As String = "
                SELECT 
                    P.Product_ID, 
                    ISNULL(P.ProductCode, '') AS ProductCode, 
                    ISNULL(P.Barcode, '') AS Barcode, 
                    P.ProductNameAr, 
                    ISNULL(P.ProductNameEn, '') AS ProductNameEn, 
                    ISNULL(P.SalePrice, 0) AS SalePrice, 
                    ISNULL(P.CostPrice, 0) AS CostPrice, 
                    ISNULL(P.Quantity, 0) AS Quantity, 
                    ISNULL(P.MinQuantity, 0) AS MinQuantity, 
                    ISNULL(P.Unit, N'قطعة') AS Unit, 
                    ISNULL(Cat.Category_NameAr, N'عام') AS Category_NameAr, 
                    ISNULL(P.DiscountPercent, 0) AS DiscountPercent, 
                    ISNULL(P.IsDiscountPercent, 1) AS IsDiscountPercent, 
                    ISNULL(P.TaxPercent, 0) AS TaxPercent, 
                    ISNULL(P.IsTaxPercent, 1) AS IsTaxPercent, 
                    P.PreparationTime, 
                    ISNULL(P.Description, '') AS Description, 
                    ISNULL(P.Notes, '') AS Notes, 
                    P.Image, 
                    ISNULL(P.IsActive, 1) AS IsActive,
                    ISNULL(P.IsDirect, 1) AS IsDirect,
                    P.Category_ID
                FROM Products P 
                LEFT JOIN Categories Cat ON P.Category_ID = Cat.Category_ID 
                WHERE (P.IsDeleted = 0 OR P.IsDeleted IS NULL)
                ORDER BY P.ProductNameAr ASC;"

            Dim dt As DataTable = DBModule.ExecuteQuery(query)
            If dt Is Nothing Then Exit Sub

            _cachedProducts = dt

            ' 2. تحديث الإحصائيات السريعة (KPIs)
            UpdateKpis(dt)

            ' 3. تطبيق الفلترة
            ApplyFilters()

        Catch ex As Exception
            Logger.LogError("LoadProductsGrid", ex)
            MessageBox.Show("خطأ أثناء تحميل المنتجات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyFilters()
        If _cachedProducts Is Nothing Then Exit Sub

        Dim filterExpr As New List(Of String)()

        ' أ) نص البحث
        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        Dim field As String = If(cmbSearchField.SelectedItem?.ToString(), "")

        If Not String.IsNullOrEmpty(keyword) Then
            Select Case field
                Case "الاسم عربي"
                    filterExpr.Add($"ProductNameAr LIKE '%{keyword}%'")
                Case "كود الصنف"
                    filterExpr.Add($"ProductCode LIKE '%{keyword}%'")
                Case "الباركود"
                    filterExpr.Add($"Barcode LIKE '%{keyword}%'")
                Case "الاسم إنجليزي"
                    filterExpr.Add($"ProductNameEn LIKE '%{keyword}%'")
                Case "الفئة"
                    filterExpr.Add($"Category_NameAr LIKE '%{keyword}%'")
                Case "الوصف"
                    filterExpr.Add($"Description LIKE '%{keyword}%'")
                Case Else
                    filterExpr.Add($"(ProductNameAr LIKE '%{keyword}%' OR ProductCode LIKE '%{keyword}%' OR Barcode LIKE '%{keyword}%')")
            End Select
        End If

        ' ب) فلتر القسم
        If cmbFilterCategory.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbFilterCategory.SelectedValue) Then
            Dim catID As Integer = Convert.ToInt32(cmbFilterCategory.SelectedValue)
            If catID > 0 Then
                filterExpr.Add($"Category_ID = {catID}")
            End If
        End If

        ' ج) فلتر حالة المخزون ونظام البيع
        Select Case cmbStockFilter.SelectedIndex
            Case 1 ' المتوفر فقط
                filterExpr.Add("Quantity > 0")
            Case 2 ' تحت حد الطلب / نواقص
                filterExpr.Add("Quantity <= MinQuantity")
            Case 3 ' غير النشطة
                filterExpr.Add("IsActive = 0")
            Case 4 ' الأصناف المباشرة فقط
                filterExpr.Add("IsDirect = 1")
            Case 5 ' أصناف متعددة الأحجام
                filterExpr.Add("IsDirect = 0")
        End Select

        Dim dv As New DataView(_cachedProducts)
        If filterExpr.Count > 0 Then
            dv.RowFilter = String.Join(" AND ", filterExpr)
        End If

        dgvProducts.DataSource = dv

        ' ضبط رؤوس الأعمدة وإخفاء الحقول غير المرئية
        ConfigureGridColumns()
    End Sub

    Private Sub ConfigureGridColumns()
        If dgvProducts.Columns.Count = 0 Then Exit Sub

        ' إخفاء الأعمدة الفنية
        Dim hiddenCols() As String = {"Product_ID", "Category_ID", "Image", "IsDiscountPercent", "IsTaxPercent", "Description", "Notes"}
        For Each col In hiddenCols
            If dgvProducts.Columns.Contains(col) Then dgvProducts.Columns(col).Visible = False
        Next

        ' تسميات الأعمدة وتنسيقات الأرقام
        If dgvProducts.Columns.Contains("ProductCode") Then
            With dgvProducts.Columns("ProductCode")
                .HeaderText = "كود الصنف"
                .Width = 110
            End With
        End If

        If dgvProducts.Columns.Contains("Barcode") Then
            With dgvProducts.Columns("Barcode")
                .HeaderText = "الباركود"
                .Width = 130
            End With
        End If

        If dgvProducts.Columns.Contains("ProductNameAr") Then
            With dgvProducts.Columns("ProductNameAr")
                .HeaderText = "اسم الصنف (عربي)"
                .Width = 220
            End With
        End If

        If dgvProducts.Columns.Contains("Category_NameAr") Then
            With dgvProducts.Columns("Category_NameAr")
                .HeaderText = "القسم / الفئة"
                .Width = 130
            End With
        End If

        If dgvProducts.Columns.Contains("SalePrice") Then
            With dgvProducts.Columns("SalePrice")
                .HeaderText = "سعر البيع"
                .DefaultCellStyle.Format = "N2"
                .Width = 100
            End With
        End If

        If dgvProducts.Columns.Contains("CostPrice") Then
            With dgvProducts.Columns("CostPrice")
                .HeaderText = "سعر التكلفة"
                .DefaultCellStyle.Format = "N2"
                .Width = 100
            End With
        End If

        If dgvProducts.Columns.Contains("Quantity") Then
            With dgvProducts.Columns("Quantity")
                .HeaderText = "الكمية"
                .DefaultCellStyle.Format = "N0"
                .Width = 90
            End With
        End If

        If dgvProducts.Columns.Contains("MinQuantity") Then
            With dgvProducts.Columns("MinQuantity")
                .HeaderText = "حد الطلب"
                .DefaultCellStyle.Format = "N0"
                .Width = 90
            End With
        End If

        If dgvProducts.Columns.Contains("Unit") Then
            With dgvProducts.Columns("Unit")
                .HeaderText = "الوحدة"
                .Width = 80
            End With
        End If

        If dgvProducts.Columns.Contains("DiscountPercent") Then
            With dgvProducts.Columns("DiscountPercent")
                .HeaderText = "الخصم"
                .Width = 80
            End With
        End If

        If dgvProducts.Columns.Contains("TaxPercent") Then
            With dgvProducts.Columns("TaxPercent")
                .HeaderText = "الضريبة"
                .Width = 80
            End With
        End If

        If dgvProducts.Columns.Contains("PreparationTime") Then
            With dgvProducts.Columns("PreparationTime")
                .HeaderText = "وقت التحضير"
                .Width = 100
            End With
        End If

        If dgvProducts.Columns.Contains("IsDirect") Then
            With dgvProducts.Columns("IsDirect")
                .HeaderText = "نظام البيع"
                .Width = 110
            End With
        End If

        If dgvProducts.Columns.Contains("IsActive") Then
            With dgvProducts.Columns("IsActive")
                .HeaderText = "نشط"
                .Width = 65
            End With
        End If
    End Sub

    ' تلوين صفوف النواقص وتنسيق نوع البيع تلقائياً
    Private Sub dgvProducts_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProducts.CellFormatting
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvProducts.Rows.Count Then Exit Sub
        Dim row As DataGridViewRow = dgvProducts.Rows(e.RowIndex)

        Try
            If dgvProducts.Columns(e.ColumnIndex).Name = "IsDirect" AndAlso e.Value IsNot Nothing Then
                Dim isDirect As Boolean = Convert.ToBoolean(e.Value)
                If isDirect Then
                    e.Value = "⚡ مباشر"
                    e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129)
                Else
                    e.Value = "📏 متعدد الأحجام"
                    e.CellStyle.ForeColor = Color.FromArgb(99, 102, 241)
                End If
                e.FormattingApplied = True
            End If

            Dim qty As Decimal = Convert.ToDecimal(If(row.Cells("Quantity").Value, 0))
            Dim minQty As Decimal = Convert.ToDecimal(If(row.Cells("MinQuantity").Value, 0))
            Dim isActive As Boolean = Convert.ToBoolean(If(row.Cells("IsActive").Value, True))

            If Not isActive Then
                row.DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184)
            ElseIf minQty > 0 AndAlso qty <= minQty Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242) ' خلفية وردية خفيفة للنواقص
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 202, 202)
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateKpis(dt As DataTable)
        If dt Is Nothing Then Exit Sub

        Dim totalCount As Integer = dt.Rows.Count
        Dim activeCount As Integer = 0
        Dim lowStockCount As Integer = 0

        For Each r As DataRow In dt.Rows
            Dim isActive As Boolean = Convert.ToBoolean(If(IsDBNull(r("IsActive")), True, r("IsActive")))
            Dim qty As Decimal = Convert.ToDecimal(If(IsDBNull(r("Quantity")), 0, r("Quantity")))
            Dim minQty As Decimal = Convert.ToDecimal(If(IsDBNull(r("MinQuantity")), 0, r("MinQuantity")))

            If isActive Then activeCount += 1
            If minQty > 0 AndAlso qty <= minQty Then lowStockCount += 1
        Next

        lblTotalProducts.Text = $"📦 إجمالي الأصناف: {totalCount:N0}"
        lblActiveProducts.Text = $"✅ الأصناف النشطة: {activeCount:N0}"
        lblLowStockProducts.Text = $"⚠️ نواقص وتحت الطلب: {lowStockCount:N0}"
    End Sub

    ' ═══════════════════════════════════════════════════════════
    ' 4. عرض بيانات الصنف المحدد في الحقول
    ' ═══════════════════════════════════════════════════════════
    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If _isLoading OrElse dgvProducts.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvProducts.SelectedRows(0)

        Try
            txtProductCode.Text = row.Cells("ProductCode").Value?.ToString()
            txtBarcode.Text = row.Cells("Barcode").Value?.ToString()
            txtProductNameAr.Text = row.Cells("ProductNameAr").Value?.ToString()
            txtProductNameEn.Text = row.Cells("ProductNameEn").Value?.ToString()

            ' القسم
            If Not IsDBNull(row.Cells("Category_ID").Value) Then
                cmbCategory.SelectedValue = row.Cells("Category_ID").Value
            Else
                cmbCategory.SelectedIndex = -1
            End If

            ' الوحدة
            Dim unitVal As String = row.Cells("Unit").Value?.ToString()
            If Not String.IsNullOrEmpty(unitVal) Then
                cmbUnit.Text = unitVal
            End If

            ' الأسعار والكميات
            Dim salePrice As Decimal = Convert.ToDecimal(If(row.Cells("SalePrice").Value, 0))
            Dim costPrice As Decimal = Convert.ToDecimal(If(row.Cells("CostPrice").Value, 0))
            txtSalePrice.Text = salePrice.ToString("N2")
            txtCostPrice.Text = costPrice.ToString("N2")

            Dim qty As Decimal = Convert.ToDecimal(If(row.Cells("Quantity").Value, 0))
            Dim minQty As Decimal = Convert.ToDecimal(If(row.Cells("MinQuantity").Value, 0))
            txtQuantity.Text = qty.ToString("N0")
            txtMinQuantity.Text = minQty.ToString("N0")

            ' الخصم والضريبة
            txtDiscount.Text = If(IsDBNull(row.Cells("DiscountPercent").Value), "0", row.Cells("DiscountPercent").Value.ToString())
            btnDiscountType.Checked = If(IsDBNull(row.Cells("IsDiscountPercent").Value), True, Convert.ToBoolean(row.Cells("IsDiscountPercent").Value))
            btnDiscountType.Text = If(btnDiscountType.Checked, "%", "ج.م")

            txtTax.Text = If(IsDBNull(row.Cells("TaxPercent").Value), "0", row.Cells("TaxPercent").Value.ToString())
            btnTaxType.Checked = If(IsDBNull(row.Cells("IsTaxPercent").Value), True, Convert.ToBoolean(row.Cells("IsTaxPercent").Value))
            btnTaxType.Text = If(btnTaxType.Checked, "%", "ج.م")

            ' وقت التحضير
            If Not IsDBNull(row.Cells("PreparationTime").Value) Then
                Dim prepTime As TimeSpan = DirectCast(row.Cells("PreparationTime").Value, TimeSpan)
                dtpPrepTime.Value = DateTime.Today.Add(prepTime)
            Else
                dtpPrepTime.Value = DateTime.Today
            End If

            ' الحالة
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), True, Convert.ToBoolean(row.Cells("IsActive").Value))
            lblStatus.Text = If(tgStatus.Checked, "نشط", "معطل")
            lblStatus.ForeColor = If(tgStatus.Checked, Color.FromArgb(16, 185, 129), Color.FromArgb(239, 68, 68))

            ' نظام البيع (صنف مباشر أم بأحجام)
            Dim isDirectVal As Boolean = If(IsDBNull(row.Cells("IsDirect").Value), True, Convert.ToBoolean(row.Cells("IsDirect").Value))
            tgIsDirect.Checked = isDirectVal
            UpdateDirectModeDisplay(isDirectVal)

            ' الوصف والملاحظات
            txtDescription.Text = row.Cells("Description").Value?.ToString()
            txtNotes.Text = row.Cells("Notes").Value?.ToString()

            ' الصورة
            Dim imgBase64 As String = row.Cells("Image").Value?.ToString()
            If Not String.IsNullOrEmpty(imgBase64) Then
                picProduct.Image = DBModule.Base64ToImage(imgBase64)
            Else
                picProduct.Image = Nothing
            End If

            ' حساب هامش الربح
            CalculateProfitMargin()

        Catch ex As Exception
            Logger.LogError("dgvProducts_SelectionChanged", ex)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════
    ' 5. عمليات الإضافة، التعديل، والحذف
    ' ═══════════════════════════════════════════════════════════
    Private Function ValidateProductInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtProductNameAr.Text) Then
            MessageBox.Show("يرجى إدخال اسم الصنف باللغة العربية!", "بيان ناقص", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductNameAr.Focus()
            Return False
        End If

        If cmbCategory.SelectedIndex = -1 OrElse cmbCategory.SelectedValue Is Nothing Then
            MessageBox.Show("يرجى اختيار القسم أو الفئة التابع لها الصنف!", "بيان ناقص", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Return False
        End If

        Dim salePrice As Decimal = 0
        If Not Decimal.TryParse(txtSalePrice.Text, salePrice) OrElse salePrice < 0 Then
            MessageBox.Show("يرجى إدخال سعر بيع صحيح!", "قيمة خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSalePrice.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateProductInputs() Then Exit Sub

        Try
            Dim code As String = txtProductCode.Text.Trim()
            If String.IsNullOrEmpty(code) Then code = GetNextProductCode()

            Dim barcode As String = txtBarcode.Text.Trim()
            If Not String.IsNullOrEmpty(barcode) Then
                Dim chkBarcode = DBModule.ExecuteScalar($"SELECT COUNT(1) FROM Products WHERE Barcode = N'{barcode.Replace("'", "''")}' AND (IsDeleted = 0 OR IsDeleted IS NULL)")
                If chkBarcode IsNot Nothing AndAlso Convert.ToInt32(chkBarcode) > 0 Then
                    MessageBox.Show("هذا الباركود مسجل لصنف آخر بالفعل!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtBarcode.Focus()
                    Exit Sub
                End If
            End If

            Dim salePrice As Decimal = Convert.ToDecimal(If(String.IsNullOrEmpty(txtSalePrice.Text), 0, txtSalePrice.Text))
            Dim costPrice As Decimal = Convert.ToDecimal(If(String.IsNullOrEmpty(txtCostPrice.Text), 0, txtCostPrice.Text))
            Dim quantity As Decimal = Convert.ToDecimal(If(String.IsNullOrEmpty(txtQuantity.Text), 0, txtQuantity.Text))
            Dim minQuantity As Decimal = Convert.ToDecimal(If(String.IsNullOrEmpty(txtMinQuantity.Text), 0, txtMinQuantity.Text))
            Dim unitName As String = If(String.IsNullOrEmpty(cmbUnit.Text), "قطعة", cmbUnit.Text.Trim())
            Dim imgBase64 As String = DBModule.ImageToBase64(picProduct.Image)

            Dim sqlInsert As String = "
                INSERT INTO Products 
                (ProductCode, Barcode, ProductNameAr, ProductNameEn, ProductName, 
                 SalePrice, CostPrice, BasePrice, Quantity, MinQuantity, Unit, 
                 Category_ID, CategoryID, Description, DiscountPercent, IsDiscountPercent, 
                 TaxPercent, IsTaxPercent, PreparationTime, IsActive, IsDirect, IsDeleted, 
                 Notes, Image, CreatedAt, updated_at) 
                VALUES 
                (@ProductCode, @Barcode, @ProductNameAr, @ProductNameEn, @ProductNameAr, 
                 @SalePrice, @CostPrice, @SalePrice, @Quantity, @MinQuantity, @Unit, 
                 @Category_ID, @Category_ID, @Description, @DiscountPercent, @IsDiscountPercent, 
                 @TaxPercent, @IsTaxPercent, @PreparationTime, @IsActive, @IsDirect, 0, 
                 @Notes, @Image, GETDATE(), SYSUTCDATETIME());"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(sqlInsert, conn)
                    cmd.Parameters.AddWithValue("@ProductCode", If(String.IsNullOrEmpty(code), DBNull.Value, code))
                    cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrEmpty(barcode), DBNull.Value, barcode))
                    cmd.Parameters.AddWithValue("@ProductNameAr", txtProductNameAr.Text.Trim())
                    cmd.Parameters.AddWithValue("@ProductNameEn", If(String.IsNullOrEmpty(txtProductNameEn.Text), DBNull.Value, txtProductNameEn.Text.Trim()))
                    cmd.Parameters.AddWithValue("@SalePrice", salePrice)
                    cmd.Parameters.AddWithValue("@CostPrice", costPrice)
                    cmd.Parameters.AddWithValue("@Quantity", quantity)
                    cmd.Parameters.AddWithValue("@MinQuantity", minQuantity)
                    cmd.Parameters.AddWithValue("@Unit", unitName)
                    cmd.Parameters.AddWithValue("@Category_ID", cmbCategory.SelectedValue)
                    cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                    cmd.Parameters.AddWithValue("@DiscountPercent", Convert.ToDouble(If(String.IsNullOrEmpty(txtDiscount.Text), 0, txtDiscount.Text)))
                    cmd.Parameters.AddWithValue("@IsDiscountPercent", btnDiscountType.Checked)
                    cmd.Parameters.AddWithValue("@TaxPercent", Convert.ToDouble(If(String.IsNullOrEmpty(txtTax.Text), 0, txtTax.Text)))
                    cmd.Parameters.AddWithValue("@IsTaxPercent", btnTaxType.Checked)
                    cmd.Parameters.AddWithValue("@PreparationTime", dtpPrepTime.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                    cmd.Parameters.AddWithValue("@IsDirect", tgIsDirect.Checked)
                    cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Image", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("تم إضافة الصنف بنجاح!", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProductsGrid()
            ClearFields()

        Catch ex As Exception
            Logger.LogError("btnAdd_Click", ex)
            MessageBox.Show("خطأ أثناء إضافة الصنف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار الصنف المراد تعديله من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateProductInputs() Then Exit Sub

        Try
            Dim currentID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)
            Dim barcode As String = txtBarcode.Text.Trim()

            If Not String.IsNullOrEmpty(barcode) Then
                Dim chkBarcode = DBModule.ExecuteScalar($"SELECT COUNT(1) FROM Products WHERE Barcode = N'{barcode.Replace("'", "''")}' AND Product_ID <> {currentID} AND (IsDeleted = 0 OR IsDeleted IS NULL)")
                If chkBarcode IsNot Nothing AndAlso Convert.ToInt32(chkBarcode) > 0 Then
                    MessageBox.Show("هذا الباركود مسجل لصنف آخر بالفعل!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtBarcode.Focus()
                    Exit Sub
                End If
            End If

            Dim salePrice As Decimal = Convert.ToDecimal(If(String.IsNullOrEmpty(txtSalePrice.Text), 0, txtSalePrice.Text))
            Dim costPrice As Decimal = Convert.ToDecimal(If(String.IsNullOrEmpty(txtCostPrice.Text), 0, txtCostPrice.Text))
            Dim quantity As Decimal = Convert.ToDecimal(If(String.IsNullOrEmpty(txtQuantity.Text), 0, txtQuantity.Text))
            Dim minQuantity As Decimal = Convert.ToDecimal(If(String.IsNullOrEmpty(txtMinQuantity.Text), 0, txtMinQuantity.Text))
            Dim unitName As String = If(String.IsNullOrEmpty(cmbUnit.Text), "قطعة", cmbUnit.Text.Trim())
            Dim imgBase64 As String = DBModule.ImageToBase64(picProduct.Image)

            Dim sqlUpdate As String = "
                UPDATE Products SET 
                    ProductCode = @ProductCode, 
                    Barcode = @Barcode, 
                    ProductNameAr = @ProductNameAr, 
                    ProductName = @ProductNameAr, 
                    ProductNameEn = @ProductNameEn, 
                    SalePrice = @SalePrice, 
                    BasePrice = @SalePrice,
                    CostPrice = @CostPrice, 
                    Quantity = @Quantity, 
                    MinQuantity = @MinQuantity, 
                    Unit = @Unit, 
                    Category_ID = @Category_ID, 
                    CategoryID = @Category_ID,
                    Description = @Description, 
                    DiscountPercent = @DiscountPercent, 
                    IsDiscountPercent = @IsDiscountPercent, 
                    TaxPercent = @TaxPercent, 
                    IsTaxPercent = @IsTaxPercent, 
                    PreparationTime = @PreparationTime, 
                    IsActive = @IsActive, 
                    IsDirect = @IsDirect,
                    Notes = @Notes, 
                    Image = @Image, 
                    updated_at = SYSUTCDATETIME() 
                WHERE Product_ID = @Product_ID;"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(sqlUpdate, conn)
                    cmd.Parameters.AddWithValue("@Product_ID", currentID)
                    cmd.Parameters.AddWithValue("@ProductCode", If(String.IsNullOrEmpty(txtProductCode.Text), DBNull.Value, txtProductCode.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrEmpty(barcode), DBNull.Value, barcode))
                    cmd.Parameters.AddWithValue("@ProductNameAr", txtProductNameAr.Text.Trim())
                    cmd.Parameters.AddWithValue("@ProductNameEn", If(String.IsNullOrEmpty(txtProductNameEn.Text), DBNull.Value, txtProductNameEn.Text.Trim()))
                    cmd.Parameters.AddWithValue("@SalePrice", salePrice)
                    cmd.Parameters.AddWithValue("@CostPrice", costPrice)
                    cmd.Parameters.AddWithValue("@Quantity", quantity)
                    cmd.Parameters.AddWithValue("@MinQuantity", minQuantity)
                    cmd.Parameters.AddWithValue("@Unit", unitName)
                    cmd.Parameters.AddWithValue("@Category_ID", cmbCategory.SelectedValue)
                    cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                    cmd.Parameters.AddWithValue("@DiscountPercent", Convert.ToDouble(If(String.IsNullOrEmpty(txtDiscount.Text), 0, txtDiscount.Text)))
                    cmd.Parameters.AddWithValue("@IsDiscountPercent", btnDiscountType.Checked)
                    cmd.Parameters.AddWithValue("@TaxPercent", Convert.ToDouble(If(String.IsNullOrEmpty(txtTax.Text), 0, txtTax.Text)))
                    cmd.Parameters.AddWithValue("@IsTaxPercent", btnTaxType.Checked)
                    cmd.Parameters.AddWithValue("@PreparationTime", dtpPrepTime.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                    cmd.Parameters.AddWithValue("@IsDirect", tgIsDirect.Checked)
                    cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Image", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("تم تعديل بيانات الصنف بنجاح!", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProductsGrid()

        Catch ex As Exception
            Logger.LogError("btnEdit_Click", ex)
            MessageBox.Show("خطأ أثناء تعديل الصنف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد الصنف المراد حذفه من الجدول!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim prodName As String = dgvProducts.SelectedRows(0).Cells("ProductNameAr").Value?.ToString()
        Dim result = MessageBox.Show($"هل أنت متأكد من رغبتك في حذف الصنف '{prodName}'؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim currentID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)
                Dim sqlDelete As String = "UPDATE Products SET IsDeleted = 1, IsActive = 0, updated_at = SYSUTCDATETIME() WHERE Product_ID = @Product_ID;"

                Using conn As New SqlConnection(DBModule.ConnectionString)
                    Using cmd As New SqlCommand(sqlDelete, conn)
                        cmd.Parameters.AddWithValue("@Product_ID", currentID)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("تم حذف الصنف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProductsGrid()
                ClearFields()

            Catch ex As Exception
                Logger.LogError("btnDelete_Click", ex)
                MessageBox.Show("خطأ أثناء حذف الصنف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearFields()
        _isLoading = True
        Try
            txtProductCode.Text = GetNextProductCode()
            txtBarcode.Clear()
            txtProductNameAr.Clear()
            txtProductNameEn.Clear()
            cmbCategory.SelectedIndex = -1
            If cmbUnit.Items.Count > 0 Then cmbUnit.SelectedIndex = 0
            txtSalePrice.Text = "0.00"
            txtCostPrice.Text = "0.00"
            txtQuantity.Text = "0"
            txtMinQuantity.Text = "0"
            txtDiscount.Text = "0"
            btnDiscountType.Checked = True
            btnDiscountType.Text = "%"
            txtTax.Text = "0"
            btnTaxType.Checked = True
            btnTaxType.Text = "%"
            dtpPrepTime.Value = DateTime.Today
            tgStatus.Checked = True
            lblStatus.Text = "نشط"
            lblStatus.ForeColor = Color.FromArgb(16, 185, 129)
            tgIsDirect.Checked = True
            UpdateDirectModeDisplay(True)
            txtDescription.Clear()
            txtNotes.Clear()
            picProduct.Image = Nothing
            lblProfitMargin.Text = "هامش الربح المتوقع: 0.00 ج.م (0%)"
            dgvProducts.ClearSelection()
        Finally
            _isLoading = False
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        FillCategoriesComboBox()
        FillUnitsComboBox()
        LoadProductsGrid()
        ClearFields()
    End Sub

    Private Function GetNextProductCode() As String
        Try
            Return Main.GetNextCode("Products", "ProductCode").ToString()
        Catch
            Return "PROD-001"
        End Try
    End Function

    ' ═══════════════════════════════════════════════════════════
    ' 6. البحث والتصفية والاقتراحات
    ' ═══════════════════════════════════════════════════════════
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        _searchTimer.Stop()
        If txtSearch.Text.Trim().Length = 0 Then
            lstSuggestions.Visible = False
            ApplyFilters()
        Else
            _searchTimer.Start()
        End If
    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs)
        _searchTimer.Stop()
        ApplyFilters()
        UpdateSuggestions()
    End Sub

    Private Sub cmbSearchField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchField.SelectedIndexChanged
        If Not _isLoading Then ApplyFilters()
    End Sub

    Private Sub cmbFilterCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterCategory.SelectedIndexChanged
        If Not _isLoading Then ApplyFilters()
    End Sub

    Private Sub cmbStockFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStockFilter.SelectedIndexChanged
        If Not _isLoading Then ApplyFilters()
    End Sub

    Private Sub UpdateSuggestions()
        Dim keyword As String = txtSearch.Text.Trim()
        lstSuggestions.Items.Clear()
        If _cachedProducts Is Nothing OrElse keyword.Length < 1 Then
            lstSuggestions.Visible = False
            Return
        End If

        Try
            Dim suggestions = _cachedProducts.AsEnumerable().
                Where(Function(r) r("ProductNameAr").ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).
                Select(Function(r) r("ProductNameAr").ToString()).
                Distinct().Take(8).ToList()

            If suggestions.Count > 0 Then
                lstSuggestions.Items.AddRange(suggestions.ToArray())
                lstSuggestions.Visible = True
                lstSuggestions.BringToFront()
            Else
                lstSuggestions.Visible = False
            End If
        Catch
            lstSuggestions.Visible = False
        End Try
    End Sub

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txtSearch.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
        End If
    End Sub

    ' ═══════════════════════════════════════════════════════════
    ' 7. التحكم في الصور والباركود والحالة والربح
    ' ═══════════════════════════════════════════════════════════
    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            ofd.Title = "اختر صورة الصنف"
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    picProduct.Image = Image.FromFile(ofd.FileName)
                    picProduct.SizeMode = PictureBoxSizeMode.Zoom
                Catch ex As Exception
                    MessageBox.Show("تعذر تحميل الصورة المختارة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnDeleteImage_Click(sender As Object, e As EventArgs) Handles btnDeleteImage.Click
        picProduct.Image = Nothing
    End Sub

    Private Sub btnGenBarcode_Click(sender As Object, e As EventArgs) Handles btnGenBarcode.Click
        Dim rnd As New Random()
        txtBarcode.Text = "622" & DateTime.Now.ToString("yyMMdd") & rnd.Next(1000, 9999).ToString()
    End Sub

    Private Sub tgStatus_CheckedChanged(sender As Object, e As EventArgs) Handles tgStatus.CheckedChanged
        lblStatus.Text = If(tgStatus.Checked, "نشط", "معطل")
        lblStatus.ForeColor = If(tgStatus.Checked, Color.FromArgb(16, 185, 129), Color.FromArgb(239, 68, 68))
    End Sub

    Private Sub tgIsDirect_CheckedChanged(sender As Object, e As EventArgs) Handles tgIsDirect.CheckedChanged
        UpdateDirectModeDisplay(tgIsDirect.Checked)
    End Sub

    Private Sub UpdateDirectModeDisplay(isDirect As Boolean)
        If isDirect Then
            lblDirectStatus.Text = "⚡ صنف مباشر: يُضاف إلى فاتورة المبيعات فوراً بنقرة واحدة (بدون شاشة أحجام أو خيارات)"
            lblDirectStatus.ForeColor = Color.FromArgb(16, 185, 129)
            btnSetupSizesQuick.Visible = False
        Else
            lblDirectStatus.Text = "📏 صنف متعدد الأحجام / خيارات: تفتح نافذة اختيار الحجم والإضافات عند النقر عليه في المبيعات"
            lblDirectStatus.ForeColor = Color.FromArgb(99, 102, 241)
            btnSetupSizesQuick.Visible = True
        End If
    End Sub

    Private Sub btnSetupSizesQuick_Click(sender As Object, e As EventArgs) Handles btnSetupSizesQuick.Click
        Dim frm As New frmProductSizes()
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim selectedID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)
            frm.cmbProduct.SelectedValue = selectedID
        End If
        frm.StartPosition = FormStartPosition.CenterParent
        frm.ShowDialog(Me)
        LoadProductsGrid()
    End Sub

    Private Sub btnDiscountType_Click(sender As Object, e As EventArgs) Handles btnDiscountType.Click
        btnDiscountType.Text = If(btnDiscountType.Checked, "%", "ج.م")
    End Sub

    Private Sub btnTaxType_Click(sender As Object, e As EventArgs) Handles btnTaxType.Click
        btnTaxType.Text = If(btnTaxType.Checked, "%", "ج.م")
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtSalePrice.TextChanged, txtCostPrice.TextChanged
        CalculateProfitMargin()
    End Sub

    Private Sub CalculateProfitMargin()
        Dim sale As Decimal = 0
        Dim cost As Decimal = 0
        Decimal.TryParse(txtSalePrice.Text, sale)
        Decimal.TryParse(txtCostPrice.Text, cost)

        Dim profit As Decimal = sale - cost
        Dim marginPct As Decimal = If(sale > 0, (profit / sale) * 100, 0)

        If profit >= 0 Then
            lblProfitMargin.Text = $"هامش الربح المتوقع: {profit:N2} ج.م ({marginPct:N1}%)"
            lblProfitMargin.ForeColor = Color.FromArgb(16, 185, 129)
        Else
            lblProfitMargin.Text = $"تحذير: خسارة متوقعة! {profit:N2} ج.م ({marginPct:N1}%)"
            lblProfitMargin.ForeColor = Color.FromArgb(239, 68, 68)
        End If
    End Sub

    ' ═══════════════════════════════════════════════════════════
    ' 8. إدارة الأحجام، الإضافات، الفئات، والتصدير
    ' ═══════════════════════════════════════════════════════════
    Private Sub btnAddCategoryForm_Click(sender As Object, e As EventArgs) Handles btnAddCategoryForm.Click
        Dim frm As New Categories()
        frm.ShowDialog()
        FillCategoriesComboBox()
    End Sub

    Private Sub btnManageSizes_Click(sender As Object, e As EventArgs) Handles btnManageSizes.Click
        Dim frm As New frmProductSizes()
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim selectedID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)
            frm.cmbProduct.SelectedValue = selectedID
        End If
        frm.ShowDialog()
        LoadProductsGrid()
    End Sub

    Private Sub btnManageAddons_Click(sender As Object, e As EventArgs) Handles btnManageAddons.Click
        Dim frm As New frmProductAddons()
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim selectedID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)
            frm.cmbProduct.SelectedValue = selectedID
        End If
        frm.ShowDialog()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvProducts.Rows.Count = 0 Then
            MessageBox.Show("لا توجد أصناف معروضة لتصديرها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "ملف إكسيل Excel Workbook (*.xlsx)|*.xlsx"
            sfd.FileName = $"دليل_الأصناف_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Using wb As New XLWorkbook()
                        Dim ws = wb.Worksheets.Add("الأصناف والمنتجات")
                        ws.RightToLeft = True

                        ' العنوان الرئيسي
                        ws.Cell(1, 1).Value = "دليل وقائمة الأصناف والمنتجات"
                        ws.Range(1, 1, 1, 11).Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        ws.Cell(2, 1).Value = $"تاريخ التصدير: {DateTime.Now:yyyy-MM-dd HH:mm}"
                        ws.Range(2, 1, 2, 11).Merge().Style.Font.SetItalic().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)

                        ' العناوين
                        Dim headers() As String = {"كود الصنف", "الباركود", "اسم الصنف", "القسم / الفئة", "نظام البيع", "سعر البيع", "سعر التكلفة", "الكمية الحالية", "حد الطلب", "الوحدة", "الحالة"}
                        For c = 0 To headers.Length - 1
                            ws.Cell(4, c + 1).Value = headers(c)
                            ws.Cell(4, c + 1).Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromHtml("#1e293b")).Font.SetFontColor(XLColor.White)
                            ws.Cell(4, c + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        Next

                        ' كتابة البيانات
                        Dim rowNum As Integer = 5
                        For Each dgvRow As DataGridViewRow In dgvProducts.Rows
                            ws.Cell(rowNum, 1).Value = dgvRow.Cells("ProductCode").Value?.ToString()
                            ws.Cell(rowNum, 2).Value = dgvRow.Cells("Barcode").Value?.ToString()
                            ws.Cell(rowNum, 3).Value = dgvRow.Cells("ProductNameAr").Value?.ToString()
                            ws.Cell(rowNum, 4).Value = dgvRow.Cells("Category_NameAr").Value?.ToString()
                            ws.Cell(rowNum, 5).Value = If(Convert.ToBoolean(If(dgvRow.Cells("IsDirect").Value, True)), "مباشر", "متعدد الأحجام")
                            ws.Cell(rowNum, 6).Value = Convert.ToDecimal(If(dgvRow.Cells("SalePrice").Value, 0))
                            ws.Cell(rowNum, 7).Value = Convert.ToDecimal(If(dgvRow.Cells("CostPrice").Value, 0))
                            ws.Cell(rowNum, 8).Value = Convert.ToDecimal(If(dgvRow.Cells("Quantity").Value, 0))
                            ws.Cell(rowNum, 9).Value = Convert.ToDecimal(If(dgvRow.Cells("MinQuantity").Value, 0))
                            ws.Cell(rowNum, 10).Value = dgvRow.Cells("Unit").Value?.ToString()
                            ws.Cell(rowNum, 11).Value = If(Convert.ToBoolean(If(dgvRow.Cells("IsActive").Value, True)), "نشط", "معطل")

                            ' تنسيق العملات والكميات
                            ws.Cell(rowNum, 6).Style.NumberFormat.Format = "#,##0.00"
                            ws.Cell(rowNum, 7).Style.NumberFormat.Format = "#,##0.00"
                            ws.Cell(rowNum, 8).Style.NumberFormat.Format = "#,##0"
                            ws.Cell(rowNum, 9).Style.NumberFormat.Format = "#,##0"

                            rowNum += 1
                        Next

                        ws.Columns().AdjustToContents()
                        wb.SaveAs(sfd.FileName)
                    End Using

                    MessageBox.Show("تم تصدير ملف الإكسيل بنجاح!", "تم التصدير", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    Logger.LogError("btnExportExcel_Click", ex)
                    MessageBox.Show("خطأ أثناء تصدير الإكسيل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    ' ═══════════════════════════════════════════════════════════
    ' 9. أزرار التحكم بالنافذة واختصارات لوحة المفاتيح
    ' ═══════════════════════════════════════════════════════════
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Products_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                btnAdd.PerformClick()
            Case Keys.F2
                btnEdit.PerformClick()
            Case Keys.F3
                btnDelete.PerformClick()
            Case Keys.F5
                btnRefresh.PerformClick()
            Case Keys.Escape
                btnClear.PerformClick()
        End Select
    End Sub

End Class
