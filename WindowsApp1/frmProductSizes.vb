Imports System.Data.SqlClient

Public Class frmProductSizes

    Private _cachedProductSizes As DataTable = Nothing
    ' علم لمنع الأحداث المتسلسلة أثناء تحميل البيانات
    Private _isLoading As Boolean = False

    ' 1. ملء قوائم الأصناف والأحجام المرجعية
    Private Sub FillDropdowns()
        Try
            _isLoading = True

            ' جلب الأصناف
            Dim dtProducts As DataTable = DBModule.ExecuteQuery("SELECT Product_ID, ProductNameAr FROM Products WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND (IsActive = 1 OR IsActive IS NULL) ORDER BY ProductNameAr")
            If dtProducts IsNot Nothing Then
                cmbProduct.DataSource = dtProducts
                cmbProduct.DisplayMember = "ProductNameAr"
                cmbProduct.ValueMember = "Product_ID"
                cmbProduct.SelectedIndex = -1
            End If

            ' جلب الأحجام العامة
            Dim dtSizes As DataTable = DBModule.ExecuteQuery("SELECT SizeID, SizeNameAr FROM Sizes WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND (IsActive = 1 OR IsActive IS NULL) ORDER BY SizeNameAr")
            If dtSizes IsNot Nothing Then
                cmbSize.DataSource = dtSizes
                cmbSize.DisplayMember = "SizeNameAr"
                cmbSize.ValueMember = "SizeID"
                cmbSize.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل القوائم: " & ex.Message)
        Finally
            _isLoading = False
        End Try
    End Sub

    ' 2. دالة تفريغ الحقول
    Private Sub ClearFields(Optional preserveProduct As Boolean = False)
        _isLoading = True
        Try
            If Not preserveProduct Then cmbProduct.SelectedIndex = -1
            cmbSize.SelectedIndex = -1
            txtCostPrice.Text = "0.00"
            txtSalePrice.Text = "0.00"
            txtBarcode.Clear()
            txtSortOrder.Text = "1"
            tgIsDefault.Checked = False
            tgStatus.Checked = True
            dgvProductSizes.ClearSelection()
        Finally
            _isLoading = False
        End Try
    End Sub

    ' 3. زر إضافة حجم للصنف
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cmbProduct.SelectedIndex = -1 OrElse cmbSize.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار الصنف والحجم أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "INSERT INTO ProductSizes (ProductID, SizeID, CostPrice, SalePrice, Barcode, IsDefault, SortOrder, IsActive, IsDeleted) " &
                              "VALUES (@ProductID, @SizeID, @CostPrice, @SalePrice, @Barcode, @IsDefault, @SortOrder, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductID", cmbProduct.SelectedValue)
                cmd.Parameters.AddWithValue("@SizeID", cmbSize.SelectedValue)
                cmd.Parameters.AddWithValue("@CostPrice", If(String.IsNullOrEmpty(txtCostPrice.Text), 0, Convert.ToDecimal(txtCostPrice.Text)))
                cmd.Parameters.AddWithValue("@SalePrice", If(String.IsNullOrEmpty(txtSalePrice.Text), 0, Convert.ToDecimal(txtSalePrice.Text)))
                cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrEmpty(txtBarcode.Text), DBNull.Value, txtBarcode.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsDefault", tgIsDefault.Checked)
                cmd.Parameters.AddWithValue("@SortOrder", If(String.IsNullOrEmpty(txtSortOrder.Text), 1, Convert.ToInt32(txtSortOrder.Text)))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ الحجم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadProductSizesGrid()
                    ClearFields(preserveProduct:=True)
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 4. زر تعديل الحجم للصنف
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvProductSizes.SelectedRows.Count = 0 Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvProductSizes.SelectedRows(0).Cells("ProductSizeID").Value)
        Dim query As String = "UPDATE ProductSizes SET SizeID = @SizeID, CostPrice = @CostPrice, SalePrice = @SalePrice, " &
                              "Barcode = @Barcode, IsDefault = @IsDefault, SortOrder = @SortOrder, IsActive = @IsActive " &
                              "WHERE ProductSizeID = @ProductSizeID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductSizeID", currentID)
                cmd.Parameters.AddWithValue("@SizeID", cmbSize.SelectedValue)
                cmd.Parameters.AddWithValue("@CostPrice", If(String.IsNullOrEmpty(txtCostPrice.Text), 0, Convert.ToDecimal(txtCostPrice.Text)))
                cmd.Parameters.AddWithValue("@SalePrice", If(String.IsNullOrEmpty(txtSalePrice.Text), 0, Convert.ToDecimal(txtSalePrice.Text)))
                cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrEmpty(txtBarcode.Text), DBNull.Value, txtBarcode.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsDefault", tgIsDefault.Checked)
                cmd.Parameters.AddWithValue("@SortOrder", If(String.IsNullOrEmpty(txtSortOrder.Text), 1, Convert.ToInt32(txtSortOrder.Text)))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل الحجم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadProductSizesGrid()
                    ClearFields(preserveProduct:=True)
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 5. زر الحذف الناعم للحجم (Soft Delete)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProductSizes.SelectedRows.Count = 0 Then Exit Sub

        If MessageBox.Show("هل أنت متأكد من رغبتك في إزالة هذا الحجم من الصنف؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvProductSizes.SelectedRows(0).Cells("ProductSizeID").Value)
            Dim query As String = "UPDATE ProductSizes SET IsDeleted = 1 WHERE ProductSizeID = @ProductSizeID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ProductSizeID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الحجم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadProductSizesGrid()
                        ClearFields(preserveProduct:=True)
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' زر فتح شاشة الأحجام العامة الإضافية
    Private Sub btnAddSizeForm_Click(sender As Object, e As EventArgs) Handles btnAddSizeForm.Click
        Dim frm As New frmSizes()
        frm.ShowDialog()
        FillDropdowns() ' إعادة شحن الكومبو بوكس بعد إضافة حجم جديد
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
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

    ' 6. دالة تحميل وجلب الأحجام (تعرض الكل افتراضياً أو بفلتر صنف معين)
    Private Sub LoadProductSizesGrid(Optional productID As Integer? = Nothing)
        _isLoading = True
        Try
            Dim query As String = "SELECT PS.ProductSizeID, PS.ProductID, P.ProductNameAr, PS.SizeID, S.SizeNameAr, " &
                                  "PS.CostPrice, PS.SalePrice, PS.Barcode, PS.IsDefault, PS.SortOrder, PS.IsActive " &
                                  "FROM ProductSizes PS " &
                                  "INNER JOIN Products P ON PS.ProductID = P.Product_ID " &
                                  "INNER JOIN Sizes S ON PS.SizeID = S.SizeID " &
                                  "WHERE (PS.IsDeleted = 0 OR PS.IsDeleted IS NULL) "

            ' إذا تم اختيار صنف معين من الكومبو بوكس، نقوم بتطبيق الشرط
            If productID.HasValue AndAlso productID.Value > 0 Then
                query &= $" AND PS.ProductID = {productID.Value} "
            End If

            query &= " ORDER BY P.ProductNameAr ASC, PS.SortOrder ASC"

            Dim dt As DataTable = DBModule.ExecuteQuery(query)
            _cachedProductSizes = dt
            dgvProductSizes.DataSource = dt

            ' إخفاء المعرفات
            If dgvProductSizes.Columns.Contains("ProductSizeID") Then dgvProductSizes.Columns("ProductSizeID").Visible = False
            If dgvProductSizes.Columns.Contains("ProductID") Then dgvProductSizes.Columns("ProductID").Visible = False
            If dgvProductSizes.Columns.Contains("SizeID") Then dgvProductSizes.Columns("SizeID").Visible = False

            ' تسمية الأعمدة بالعربية
            If dgvProductSizes.Columns.Contains("ProductNameAr") Then dgvProductSizes.Columns("ProductNameAr").HeaderText = "اسم الصنف"
            If dgvProductSizes.Columns.Contains("SizeNameAr") Then dgvProductSizes.Columns("SizeNameAr").HeaderText = "الحجم"
            If dgvProductSizes.Columns.Contains("CostPrice") Then dgvProductSizes.Columns("CostPrice").HeaderText = "التكلفة"
            If dgvProductSizes.Columns.Contains("SalePrice") Then dgvProductSizes.Columns("SalePrice").HeaderText = "سعر البيع"
            If dgvProductSizes.Columns.Contains("Barcode") Then dgvProductSizes.Columns("Barcode").HeaderText = "الباركود"
            If dgvProductSizes.Columns.Contains("IsDefault") Then dgvProductSizes.Columns("IsDefault").HeaderText = "افتراضي"
            If dgvProductSizes.Columns.Contains("SortOrder") Then dgvProductSizes.Columns("SortOrder").HeaderText = "الترتيب"
            If dgvProductSizes.Columns.Contains("IsActive") Then dgvProductSizes.Columns("IsActive").HeaderText = "نشط"
        Finally
            _isLoading = False
        End Try
    End Sub

    ' 7. حدث تحميل الفورم (Form_Load)
    Private Sub frmProductSizes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDropdowns()

        ' تحميل جميع الأحجام لكل الأصناف في الجريد فيو افتراضياً عند فتح الشاشة
        LoadProductSizesGrid()

        datagridviewsetup(dgvProductSizes)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' 8. حدث تغيير الصنف المختار في الكومبو بوكس
    Private Sub cmbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProduct.SelectedIndexChanged
        ' منع التنفيذ أثناء التحميل لتجنب الحلقة اللانهائية
        If _isLoading Then Exit Sub

        ' نتحقق من أن التغيير تم بواسطة اختيار إيجابي من المستخدم وليس تفريغ تلقائي
        If cmbProduct.SelectedValue IsNot Nothing AndAlso TypeOf cmbProduct.SelectedValue Is Integer Then
            Dim selectedProductID As Integer = Convert.ToInt32(cmbProduct.SelectedValue)
            LoadProductSizesGrid(selectedProductID)
        End If
    End Sub

    ' 9. حدث تحديد صف من الجدول
    Private Sub dgvProductSizes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductSizes.SelectionChanged
        ' منع التنفيذ أثناء التحميل لتجنب الحلقة اللانهائية والوصول لأعمدة غير جاهزة
        If _isLoading Then Exit Sub
        If dgvProductSizes.SelectedRows.Count = 0 Then Exit Sub
        If dgvProductSizes.Columns.Count = 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvProductSizes.SelectedRows(0)

        ' التأكد من وجود العمود والقيمة قبل الوصول إليها
        If Not dgvProductSizes.Columns.Contains("ProductSizeID") Then Exit Sub
        If row.Cells("ProductSizeID").Value Is Nothing OrElse IsDBNull(row.Cells("ProductSizeID").Value) Then Exit Sub

        _isLoading = True
        Try
            ' تعيين الصنف والحجم المحددين في الكومبو بوكس دون إعادة جلب الجريد
            If dgvProductSizes.Columns.Contains("ProductID") AndAlso Not IsDBNull(row.Cells("ProductID").Value) Then
                cmbProduct.SelectedValue = row.Cells("ProductID").Value
            End If
            If dgvProductSizes.Columns.Contains("SizeID") AndAlso Not IsDBNull(row.Cells("SizeID").Value) Then
                cmbSize.SelectedValue = row.Cells("SizeID").Value
            End If

            txtCostPrice.Text = If(IsDBNull(row.Cells("CostPrice").Value), "0.00", row.Cells("CostPrice").Value.ToString())
            txtSalePrice.Text = If(IsDBNull(row.Cells("SalePrice").Value), "0.00", row.Cells("SalePrice").Value.ToString())
            txtBarcode.Text = If(IsDBNull(row.Cells("Barcode").Value), "", row.Cells("Barcode").Value.ToString())
            txtSortOrder.Text = If(IsDBNull(row.Cells("SortOrder").Value), "1", row.Cells("SortOrder").Value.ToString())
            tgIsDefault.Checked = If(IsDBNull(row.Cells("IsDefault").Value), False, Convert.ToBoolean(row.Cells("IsDefault").Value))
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        Finally
            _isLoading = False
        End Try
    End Sub

    ' 10. زر التحديث وإعادة العرض العام للكل
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _isLoading = True
        cmbProduct.SelectedIndex = -1
        cmbSize.SelectedIndex = -1
        _isLoading = False

        LoadProductSizesGrid() ' يحمل كافة الأصناف وأحجامها بدون فلتر
        ClearFields()
    End Sub

    Private Sub btnAddProductForm_Click(sender As Object, e As EventArgs) Handles btnAddProductForm.Click
        Dim frm As New Products()
        frm.ShowDialog()
        FillDropdowns() ' إعادة شحن الكومبو بوكس بعد إضافة حجم جديد
    End Sub
End Class
