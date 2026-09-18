'Imports System.Data.SqlClient

'Public Class frmRecipes
'    Private _selectedRecipeID As Integer? = Nothing

'    Private Sub FillProductsAndMaterials()
'        Try
'            ' 1. تحميل الأصناف
'            Dim dtProducts As DataTable = DBModule.ExecuteQuery("SELECT Product_ID, ProductNameAr FROM Products WHERE (IsActive = 1) AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY ProductNameAr ASC")
'            If dtProducts IsNot Nothing Then
'                cmbProduct.DataSource = dtProducts
'                cmbProduct.DisplayMember = "ProductNameAr"
'                cmbProduct.ValueMember = "Product_ID"
'                cmbProduct.SelectedIndex = -1
'            End If

'            ' 2. تحميل الإضافات
'            Dim dtAddons As DataTable = DBModule.ExecuteQuery("SELECT AddonID, AddonNameAr FROM Addons WHERE (IsActive = 1) AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY AddonNameAr ASC")
'            If dtAddons IsNot Nothing Then
'                cmbAddon.DataSource = dtAddons
'                cmbAddon.DisplayMember = "AddonNameAr"
'                cmbAddon.ValueMember = "AddonID"
'                cmbAddon.SelectedIndex = -1
'            End If

'            ' 3. تحميل الخامات مع إظهار وحدتها
'            Dim dtMaterials As DataTable = DBModule.ExecuteQuery("SELECT R.MaterialID, R.MaterialName, U.UnitName, (R.MaterialName + ' [' + U.UnitName + ']') AS DisplayText FROM RawMaterials R INNER JOIN Units U ON R.UnitID = U.UnitID WHERE R.IsActive = 1 ORDER BY R.MaterialName ASC")
'            If dtMaterials IsNot Nothing Then
'                cmbMaterial.DataSource = dtMaterials
'                cmbMaterial.DisplayMember = "DisplayText"
'                cmbMaterial.ValueMember = "MaterialID"
'                cmbMaterial.SelectedIndex = -1
'            End If
'        Catch ex As Exception
'            MessageBox.Show("خطأ في تحميل القوائم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    ' فلترة الأحجام حسب الصنف المختار
'    Private Sub cmbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProduct.SelectedIndexChanged
'        If cmbProduct.SelectedValue IsNot Nothing AndAlso TypeOf cmbProduct.SelectedValue Is Integer Then
'            Dim prodID As Integer = Convert.ToInt32(cmbProduct.SelectedValue)

'            Dim query As String = "SELECT S.SizeID, S.SizeNameAr FROM Sizes S " &
'                                  "WHERE S.SizeID IN (SELECT SizeID FROM ProductSizes WHERE ProductID = " & prodID & ") " &
'                                  "AND (S.IsDeleted = 0 OR S.IsDeleted IS NULL)"
'            Dim dtSizes As DataTable = DBModule.ExecuteQuery(query)

'            cmbSize.DataSource = dtSizes
'            cmbSize.DisplayMember = "SizeNameAr"
'            cmbSize.ValueMember = "SizeID"
'            cmbSize.SelectedIndex = -1

'            LoadRecipesGrid(prodID)
'        Else
'            cmbSize.DataSource = Nothing
'            LoadRecipesGrid()
'        End If
'    End Sub

'    Private Sub cmbMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaterial.SelectedIndexChanged
'        If cmbMaterial.SelectedItem IsNot Nothing AndAlso TypeOf cmbMaterial.SelectedItem Is DataRowView Then
'            Dim drv As DataRowView = CType(cmbMaterial.SelectedItem, DataRowView)
'            lblUnitIndicator.Text = drv("UnitName").ToString()
'        Else
'            lblUnitIndicator.Text = "-"
'        End If
'    End Sub

'    Private Sub LoadRecipesGrid(Optional filterProductID As Integer? = Nothing)
'        Try
'            Dim query As String = "SELECT Rec.RecipeID, Rec.ProductID, P.ProductNameAr, Rec.SizeID, S.SizeNameAr, " &
'                                  "Rec.AddonID, A.AddonNameAr, Rec.MaterialID, R.MaterialName, Rec.Quantity, U.UnitName, Rec.Notes " &
'                                  "FROM Recipes Rec " &
'                                  "INNER JOIN Products P ON Rec.ProductID = P.Product_ID " &
'                                  "LEFT JOIN Sizes S ON Rec.SizeID = S.SizeID " &
'                                  "LEFT JOIN Addons A ON Rec.AddonID = A.AddonID " &
'                                  "INNER JOIN RawMaterials R ON Rec.MaterialID = R.MaterialID " &
'                                  "INNER JOIN Units U ON R.UnitID = U.UnitID "

'            If filterProductID.HasValue Then
'                query &= "WHERE Rec.ProductID = " & filterProductID.Value & " "
'            End If

'            query &= "ORDER BY P.ProductNameAr ASC, S.SizeNameAr ASC, R.MaterialName ASC"

'            Dim dt As DataTable = DBModule.ExecuteQuery(query)
'            dgvRecipes.DataSource = dt

'            Dim hiddenCols As String() = {"RecipeID", "ProductID", "SizeID", "AddonID", "MaterialID"}
'            For Each c In hiddenCols
'                If dgvRecipes.Columns.Contains(c) Then dgvRecipes.Columns(c).Visible = False
'            Next

'            If dgvRecipes.Columns.Contains("ProductNameAr") Then dgvRecipes.Columns("ProductNameAr").HeaderText = "الصنف"
'            If dgvRecipes.Columns.Contains("SizeNameAr") Then dgvRecipes.Columns("SizeNameAr").HeaderText = "الحجم"
'            If dgvRecipes.Columns.Contains("AddonNameAr") Then dgvRecipes.Columns("AddonNameAr").HeaderText = "الإضافة"
'            If dgvRecipes.Columns.Contains("MaterialName") Then dgvRecipes.Columns("MaterialName").HeaderText = "الخامة المخصومة"
'            If dgvRecipes.Columns.Contains("Quantity") Then dgvRecipes.Columns("Quantity").HeaderText = "الكمية"
'            If dgvRecipes.Columns.Contains("UnitName") Then dgvRecipes.Columns("UnitName").HeaderText = "الوحدة"
'            If dgvRecipes.Columns.Contains("Notes") Then dgvRecipes.Columns("Notes").HeaderText = "ملاحظات"
'        Catch ex As Exception
'            MessageBox.Show("خطأ في تحميل قائمة الريسيبي: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    Private Sub ClearFields(Optional keepProduct As Boolean = True)
'        _selectedRecipeID = Nothing
'        If Not keepProduct Then cmbProduct.SelectedIndex = -1
'        cmbSize.SelectedIndex = -1
'        cmbAddon.SelectedIndex = -1
'        cmbMaterial.SelectedIndex = -1
'        txtQuantity.Text = "0.0000"
'        txtNotes.Clear()
'        lblUnitIndicator.Text = "-"
'        dgvRecipes.ClearSelection()
'    End Sub

'    Private Sub frmRecipes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        FillProductsAndMaterials()
'        LoadRecipesGrid()
'        datagridviewsetup(dgvRecipes)
'        Dim Drag As New FormDragHelper(Me, panelHeader)
'    End Sub

'    Private Sub dgvRecipes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRecipes.SelectionChanged
'        If dgvRecipes.SelectedRows.Count = 0 Then Exit Sub
'        Dim row As DataGridViewRow = dgvRecipes.SelectedRows(0)

'        If row.Cells("RecipeID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("RecipeID").Value) Then
'            _selectedRecipeID = Convert.ToInt32(row.Cells("RecipeID").Value)
'            If Not IsDBNull(row.Cells("ProductID").Value) Then cmbProduct.SelectedValue = row.Cells("ProductID").Value
'            If Not IsDBNull(row.Cells("SizeID").Value) Then cmbSize.SelectedValue = row.Cells("SizeID").Value Else cmbSize.SelectedIndex = -1
'            If Not IsDBNull(row.Cells("AddonID").Value) Then cmbAddon.SelectedValue = row.Cells("AddonID").Value Else cmbAddon.SelectedIndex = -1
'            If Not IsDBNull(row.Cells("MaterialID").Value) Then cmbMaterial.SelectedValue = row.Cells("MaterialID").Value
'            txtQuantity.Text = If(IsDBNull(row.Cells("Quantity").Value), "0.0000", Convert.ToDecimal(row.Cells("Quantity").Value).ToString("0.0000"))
'            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
'        End If
'    End Sub

'    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
'        If cmbProduct.SelectedIndex = -1 Then
'            MessageBox.Show("يرجى اختيار الصنف الأساسي أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End If

'        If cmbMaterial.SelectedIndex = -1 Then
'            MessageBox.Show("يرجى اختيار الخامة المستهلكة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End If

'        Dim qty As Decimal = 0
'        If Not Decimal.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
'            MessageBox.Show("يرجى إدخال كمية استهلاك صحيحة أكبر من صفر!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            txtQuantity.Focus()
'            Exit Sub
'        End If

'        ' منع تكرار نفس الخامة لنفس الصنف والحجم والإضافة
'        Dim checkQuery As String = "SELECT COUNT(1) FROM Recipes WHERE MaterialID = @Mat " &
'                                   "AND ProductID = @Prod " &
'                                   "AND (SizeID = @Size OR (@Size IS NULL AND SizeID IS NULL)) " &
'                                   "AND (AddonID = @Addon OR (@Addon IS NULL AND AddonID IS NULL))"

'        Using conn As New SqlConnection(DBModule.ConnectionString)
'            Using cmdCheck As New SqlCommand(checkQuery, conn)
'                cmdCheck.Parameters.AddWithValue("@Mat", cmbMaterial.SelectedValue)
'                cmdCheck.Parameters.AddWithValue("@Prod", cmbProduct.SelectedValue)
'                cmdCheck.Parameters.AddWithValue("@Size", If(cmbSize.SelectedValue Is Nothing, DBNull.Value, cmbSize.SelectedValue))
'                cmdCheck.Parameters.AddWithValue("@Addon", If(cmbAddon.SelectedValue Is Nothing, DBNull.Value, cmbAddon.SelectedValue))
'                conn.Open()
'                Dim exists As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
'                If exists > 0 Then
'                    MessageBox.Show("هذه الخامة مسجلة مسبقاً لهذه التركيبة! يمكنك تعديل كميتها بدلاً من إضافتها مجدداً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                    Exit Sub
'                End If
'            End Using

'            Dim insertQuery As String = "INSERT INTO Recipes (ProductID, SizeID, AddonID, MaterialID, Quantity, Notes) " &
'                                        "VALUES (@ProductID, @SizeID, @AddonID, @MaterialID, @Quantity, @Notes)"
'            Using cmdInsert As New SqlCommand(insertQuery, conn)
'                cmdInsert.Parameters.AddWithValue("@ProductID", cmbProduct.SelectedValue)
'                cmdInsert.Parameters.AddWithValue("@SizeID", If(cmbSize.SelectedValue Is Nothing, DBNull.Value, cmbSize.SelectedValue))
'                cmdInsert.Parameters.AddWithValue("@AddonID", If(cmbAddon.SelectedValue Is Nothing, DBNull.Value, cmbAddon.SelectedValue))
'                cmdInsert.Parameters.AddWithValue("@MaterialID", cmbMaterial.SelectedValue)
'                cmdInsert.Parameters.AddWithValue("@Quantity", qty)
'                cmdInsert.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
'                cmdInsert.ExecuteNonQuery()
'            End Using
'        End Using

'        MessageBox.Show("تم حفظ المكون بالريسيبي بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        Dim currentProd As Integer? = If(cmbProduct.SelectedValue IsNot Nothing, Convert.ToInt32(cmbProduct.SelectedValue), CType(Nothing, Integer?))
'        LoadRecipesGrid(currentProd)
'        ClearFields(keepProduct:=True)
'    End Sub

'    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
'        If Not _selectedRecipeID.HasValue Then
'            MessageBox.Show("يرجى تحديد مكون من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End If

'        Dim qty As Decimal = 0
'        If Not Decimal.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
'            MessageBox.Show("يرجى إدخال كمية صحيحة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End If

'        Dim query As String = "UPDATE Recipes SET ProductID = @ProductID, SizeID = @SizeID, AddonID = @AddonID, " &
'                              "MaterialID = @MaterialID, Quantity = @Quantity, Notes = @Notes WHERE RecipeID = @RecipeID"

'        Using conn As New SqlConnection(DBModule.ConnectionString)
'            Using cmd As New SqlCommand(query, conn)
'                cmd.Parameters.AddWithValue("@RecipeID", _selectedRecipeID.Value)
'                cmd.Parameters.AddWithValue("@ProductID", cmbProduct.SelectedValue)
'                cmd.Parameters.AddWithValue("@SizeID", If(cmbSize.SelectedValue Is Nothing, DBNull.Value, cmbSize.SelectedValue))
'                cmd.Parameters.AddWithValue("@AddonID", If(cmbAddon.SelectedValue Is Nothing, DBNull.Value, cmbAddon.SelectedValue))
'                cmd.Parameters.AddWithValue("@MaterialID", cmbMaterial.SelectedValue)
'                cmd.Parameters.AddWithValue("@Quantity", qty)
'                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))

'                Try
'                    conn.Open()
'                    cmd.ExecuteNonQuery()
'                    MessageBox.Show("تم تعديل المكون بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    Dim currentProd As Integer? = If(cmbProduct.SelectedValue IsNot Nothing, Convert.ToInt32(cmbProduct.SelectedValue), CType(Nothing, Integer?))
'                    LoadRecipesGrid(currentProd)
'                    ClearFields(keepProduct:=True)
'                Catch ex As Exception
'                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                End Try
'            End Using
'        End Using
'    End Sub

'    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
'        If Not _selectedRecipeID.HasValue Then Exit Sub

'        If MessageBox.Show("هل أنت متأكد من حذف هذه الخامة من الريسيبي؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
'            Dim query As String = "DELETE FROM Recipes WHERE RecipeID = @ID"
'            Using conn As New SqlConnection(DBModule.ConnectionString)
'                Using cmd As New SqlCommand(query, conn)
'                    cmd.Parameters.AddWithValue("@ID", _selectedRecipeID.Value)
'                    conn.Open()
'                    cmd.ExecuteNonQuery()
'                    MessageBox.Show("تم الحذف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    Dim currentProd As Integer? = If(cmbProduct.SelectedValue IsNot Nothing, Convert.ToInt32(cmbProduct.SelectedValue), CType(Nothing, Integer?))
'                    LoadRecipesGrid(currentProd)
'                    ClearFields(keepProduct:=True)
'                End Using
'            End Using
'        End If
'    End Sub

'    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
'        ClearFields(keepProduct:=False)
'        LoadRecipesGrid()
'    End Sub

'    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
'        FillProductsAndMaterials()
'        LoadRecipesGrid()
'        ClearFields(keepProduct:=False)
'    End Sub

'    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
'        Close()
'    End Sub

'    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
'        FormHelper.ToggleMaximize(Me)
'    End Sub

'    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
'        FormHelper.Minimiz(Me)
'    End Sub
'End Class


Imports System.Data.SqlClient

Public Class frmRecipes

    Private _selectedRecipeID As Integer? = Nothing

    ' لمنع الأحداث من تنفيذ نفسها أثناء تحميل البيانات
    Private _suppressEvents As Boolean = False

    ' متغير حساب تكلفة الوجبة
    Private _currentRecipeTotalCost As Decimal = 0

    ' ---------------------------------------------------------
    ' Form Load
    ' ---------------------------------------------------------
    Private Sub frmRecipes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            SetupRecipeTypeCombo()

            FillProductsAndMaterials()

            PrepareInitialState()

            AddHandler btnAutoUpdateProductCost.Click, AddressOf ApplyRecipeCostToProduct

            LoadRecipesGrid()

            datagridviewsetup(dgvRecipes)

            Dim Drag As New FormDragHelper(Me, panelHeader)

        Catch ex As Exception

            MessageBox.Show(
                "حدث خطأ أثناء تحميل شاشة الريسيبي:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' تجهيز Combo نوع الوصفة
    ' ---------------------------------------------------------
    Private Sub SetupRecipeTypeCombo()

        _suppressEvents = True

        cmbRecipeType.Items.Clear()

        cmbRecipeType.Items.Add("الوصفة الأساسية")
        cmbRecipeType.Items.Add("حسب الحجم")
        cmbRecipeType.Items.Add("حسب الإضافة")
        cmbRecipeType.Items.Add("حسب الحجم والإضافة")

        cmbRecipeType.SelectedIndex = 0

        _suppressEvents = False

        ApplyRecipeTypeUI()

    End Sub

    ' ---------------------------------------------------------
    ' تحميل الأصناف والخامات والإضافات
    ' ---------------------------------------------------------
    Private Sub FillProductsAndMaterials()

        Try

            ' ==========================================
            ' الأصناف
            ' ==========================================
            Dim dtProducts As DataTable =
                DBModule.ExecuteQuery(
                    "SELECT Product_ID, ProductNameAr " &
                    "FROM Products " &
                    "WHERE IsActive = 1 " &
                    "AND (IsDeleted = 0 OR IsDeleted IS NULL) " &
                    "ORDER BY ProductNameAr ASC"
                )

            If dtProducts IsNot Nothing Then

                _suppressEvents = True

                cmbProduct.DataSource = dtProducts
                cmbProduct.DisplayMember = "ProductNameAr"
                cmbProduct.ValueMember = "Product_ID"
                cmbProduct.SelectedIndex = -1

                _suppressEvents = False

            End If

            ' ==========================================
            ' الإضافات
            ' ==========================================
            Dim dtAddons As DataTable =
                DBModule.ExecuteQuery(
                    "SELECT AddonID, AddonNameAr " &
                    "FROM Addons " &
                    "WHERE IsActive = 1 " &
                    "AND (IsDeleted = 0 OR IsDeleted IS NULL) " &
                    "ORDER BY AddonNameAr ASC"
                )

            If dtAddons IsNot Nothing Then

                _suppressEvents = True

                cmbAddon.DataSource = dtAddons
                cmbAddon.DisplayMember = "AddonNameAr"
                cmbAddon.ValueMember = "AddonID"
                cmbAddon.SelectedIndex = -1

                _suppressEvents = False

            End If

            ' ==========================================
            ' الخامات
            ' ==========================================
            'Dim dtMaterials As DataTable =
            '    DBModule.ExecuteQuery(
            '        "SELECT R.MaterialID, " &
            '        "R.MaterialName, " &
            '        "U.UnitName, " &
            '        "(R.MaterialName + ' [' + U.UnitName + ']') AS DisplayText " &
            '        "FROM RawMaterials R " &
            '        "INNER JOIN Units U ON R.UnitID = U.UnitID " &
            '        "WHERE R.IsActive = 1 " &
            '        "ORDER BY R.MaterialName ASC"
            '    )
            Dim dtMaterials As DataTable =
                DBModule.ExecuteQuery(
                    "SELECT R.MaterialID, " &
                    "R.MaterialName " &
                    "FROM RawMaterials R " &
                    "WHERE R.IsActive = 1 AND IsDeleted = 0 OR IsDeleted IS Null " &
                    "ORDER BY R.MaterialName ASC"
                )

            If dtMaterials IsNot Nothing Then

                _suppressEvents = True

                cmbMaterial.DataSource = dtMaterials
                cmbMaterial.DisplayMember = "MaterialName"
                cmbMaterial.ValueMember = "MaterialID"
                cmbMaterial.SelectedIndex = -1

                _suppressEvents = False

            End If

        Catch ex As Exception

            MessageBox.Show(
                "خطأ في تحميل القوائم:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' تجهيز الحالة الأولية
    ' ---------------------------------------------------------
    Private Sub PrepareInitialState()

        _suppressEvents = True

        cmbSize.DataSource = Nothing
        cmbAddon.SelectedIndex = -1
        cmbMaterial.SelectedIndex = -1
        cmbMaterialUnit.DataSource = Nothing

        txtQuantity.Text = "0.0000"
        txtNotes.Clear()

        lblUnitIndicator.Text = "-"
        lblConversionHint.Text = ""

        _selectedRecipeID = Nothing

        _suppressEvents = False

        ApplyRecipeTypeUI()

    End Sub

    ' ---------------------------------------------------------
    ' عند تغيير نوع الوصفة
    ' ---------------------------------------------------------
    Private Sub cmbRecipeType_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbRecipeType.SelectedIndexChanged

        If _suppressEvents Then Exit Sub

        ApplyRecipeTypeUI()

        _selectedRecipeID = Nothing

        LoadRecipesGrid()

    End Sub

    ' ---------------------------------------------------------
    ' التحكم في ظهور الحجم والإضافة
    ' ---------------------------------------------------------
    Private Sub ApplyRecipeTypeUI()

        If cmbRecipeType.SelectedIndex = -1 Then

            cmbSize.Visible = False
            cmbAddon.Visible = False
            lblSize.Visible = False
            lblAddon.Visible = False
            Exit Sub

        End If

        Select Case cmbRecipeType.SelectedIndex

            Case 0
                ' الوصفة الأساسية

                cmbSize.Visible = False
                cmbAddon.Visible = False
                lblSize.Visible = False
                lblAddon.Visible = False
                _suppressEvents = True

                cmbSize.SelectedIndex = -1
                cmbAddon.SelectedIndex = -1

                _suppressEvents = False

            Case 1
                ' حسب الحجم

                cmbSize.Visible = True
                cmbAddon.Visible = False
                lblSize.Visible = True
                lblAddon.Visible = False
                _suppressEvents = True

                cmbAddon.SelectedIndex = -1

                _suppressEvents = False

            Case 2
                ' حسب الإضافة

                cmbSize.Visible = False
                cmbAddon.Visible = True
                lblSize.Visible = False
                lblAddon.Visible = True
                _suppressEvents = True

                cmbSize.SelectedIndex = -1

                _suppressEvents = False

            Case 3
                ' حسب الحجم والإضافة

                cmbSize.Visible = True
                cmbAddon.Visible = True
                lblSize.Visible = True
                lblAddon.Visible = True

        End Select

    End Sub

    ' ---------------------------------------------------------
    ' تغيير الصنف
    ' ---------------------------------------------------------
    Private Sub cmbProduct_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbProduct.SelectedIndexChanged

        If _suppressEvents Then Exit Sub

        Dim productID As Integer

        If Not TryGetComboIntegerValue(cmbProduct, productID) Then

            _suppressEvents = True

            cmbSize.DataSource = Nothing
            cmbMaterialUnit.DataSource = Nothing

            _suppressEvents = False

            LoadRecipesGrid()

            Exit Sub

        End If

        LoadProductSizes(productID)

        LoadRecipesGrid()

    End Sub

    ' ---------------------------------------------------------
    ' تحميل أحجام الصنف
    ' ---------------------------------------------------------
    Private Sub LoadProductSizes(productID As Integer)

        Try

            Dim query As String =
                "SELECT S.SizeID, S.SizeNameAr " &
                "FROM Sizes S " &
                "WHERE S.SizeID IN " &
                "(SELECT SizeID FROM ProductSizes WHERE ProductID = @ProductID) " &
                "AND (S.IsDeleted = 0 OR S.IsDeleted IS NULL) " &
                "ORDER BY S.SizeNameAr ASC"

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(query, conn)

                    cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID

                    Dim dt As New DataTable()

                    Using da As New SqlDataAdapter(cmd)

                        da.Fill(dt)

                    End Using

                    _suppressEvents = True

                    cmbSize.DataSource = dt
                    cmbSize.DisplayMember = "SizeNameAr"
                    cmbSize.ValueMember = "SizeID"
                    cmbSize.SelectedIndex = -1

                    _suppressEvents = False

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "خطأ في تحميل أحجام الصنف:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' تغيير الحجم
    ' ---------------------------------------------------------
    Private Sub cmbSize_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbSize.SelectedIndexChanged

        If _suppressEvents Then Exit Sub

        LoadRecipesGrid()

    End Sub

    ' ---------------------------------------------------------
    ' تغيير الإضافة
    ' ---------------------------------------------------------
    Private Sub cmbAddon_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbAddon.SelectedIndexChanged

        If _suppressEvents Then Exit Sub

        LoadRecipesGrid()

    End Sub

    ' ---------------------------------------------------------
    ' عند اختيار خامة
    ' ---------------------------------------------------------
    Private Sub cmbMaterial_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbMaterial.SelectedIndexChanged

        If _suppressEvents Then Exit Sub

        Dim materialID As Integer

        If Not TryGetComboIntegerValue(cmbMaterial, materialID) Then

            _suppressEvents = True

            cmbMaterialUnit.DataSource = Nothing

            _suppressEvents = False

            lblUnitIndicator.Text = "-"
            lblConversionHint.Text = ""

            Exit Sub

        End If

        LoadMaterialUnits(materialID)

    End Sub

    ' ---------------------------------------------------------
    ' تحميل وحدات الخامة
    '
    ' الوحدة الأساسية = ConversionFactor = 1
    '
    ' مثال:
    ' جرام = 1
    ' كيلو = 1000
    ' شكارة = 25000
    ' ---------------------------------------------------------
    Private Sub LoadMaterialUnits(materialID As Integer)

        Try

            Dim query As String =
                "SELECT U.UnitID, 
                U.UnitName, 
                CAST(1 AS DECIMAL(18,6)) As ConversionFactor
                FROM RawMaterials RM 
                INNER JOIN Units U ON RM.UnitID = U.UnitID 
                WHERE RM.MaterialID = @MaterialID 

                UNION ALL 

                Select MU.UnitID, 
                U.UnitName,
                MU.ConversionFactor 
                From MaterialUnits MU 
                INNER JOIN Units U ON MU.UnitID = U.UnitID 
                INNER Join RawMaterials RM ON MU.MaterialID = RM.MaterialID 
                WHERE MU.MaterialID = @MaterialID 
                And MU.UnitID <> RM.UnitID 

                ORDER BY ConversionFactor ASC"

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(query, conn)

                    cmd.Parameters.Add("@MaterialID", SqlDbType.Int).Value = materialID

                    Dim dt As New DataTable()

                    Using da As New SqlDataAdapter(cmd)

                        da.Fill(dt)

                    End Using

                    _suppressEvents = True

                    cmbMaterialUnit.DataSource = dt
                    cmbMaterialUnit.DisplayMember = "UnitName"
                    cmbMaterialUnit.ValueMember = "UnitID"

                    If dt.Rows.Count > 0 Then

                        ' الوحدة الأساسية دائمًا أول اختيار عملي
                        cmbMaterialUnit.SelectedIndex = 0

                        lblUnitIndicator.Text = GetBaseUnitName(dt)
                        '"الوحدة الأساسية: " &

                        UpdateConversionHint()

                    Else

                        cmbMaterialUnit.SelectedIndex = -1

                        lblUnitIndicator.Text = "-"
                        lblConversionHint.Text = ""

                    End If

                    _suppressEvents = False

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "خطأ في تحميل وحدات الخامة:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' الحصول على اسم الوحدة الأساسية من DataTable
    ' لأن ConversionFactor = 1
    ' ---------------------------------------------------------
    Private Function GetBaseUnitName(dt As DataTable) As String

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Return "-"
        End If

        For Each row As DataRow In dt.Rows

            Dim factor As Decimal =
                Convert.ToDecimal(row("ConversionFactor"))

            If factor = 1D Then
                Return row("UnitName").ToString()
            End If

        Next

        Return dt.Rows(0)("UnitName").ToString()

    End Function

    ' ---------------------------------------------------------
    ' تغيير وحدة الإدخال
    ' ---------------------------------------------------------
    Private Sub cmbMaterialUnit_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbMaterialUnit.SelectedIndexChanged

        If _suppressEvents Then Exit Sub

        UpdateConversionHint()

    End Sub

    ' ---------------------------------------------------------
    ' تحديث النص الذي يوضح التحويل
    ' ---------------------------------------------------------
    Private Sub UpdateConversionHint()

        If cmbMaterialUnit.SelectedIndex = -1 Then

            lblConversionHint.Text = ""

            Exit Sub

        End If

        Dim drv As DataRowView =
            TryCast(cmbMaterialUnit.SelectedItem, DataRowView)

        If drv Is Nothing Then Exit Sub

        Dim factor As Decimal =
            Convert.ToDecimal(drv("ConversionFactor"))

        Dim unitName As String =
            drv("UnitName").ToString()

        Dim materialID As Integer

        If Not TryGetComboIntegerValue(cmbMaterial, materialID) Then
            Exit Sub
        End If

        Dim baseUnitName As String =
            GetMaterialBaseUnitName(materialID)

        If factor = 1D Then

            lblConversionHint.Text =
                "الوحدة الأساسية: " & baseUnitName

        Else

            lblConversionHint.Text =
                "1 " & unitName &
                " = " &
                factor.ToString("0.######") &
                " " &
                baseUnitName

        End If

    End Sub

    ' ---------------------------------------------------------
    ' جلب اسم الوحدة الأساسية للخامة
    ' ---------------------------------------------------------
    Private Function GetMaterialBaseUnitName(materialID As Integer) As String

        Try

            Dim query As String =
                "SELECT U.UnitName " &
                "FROM RawMaterials RM " &
                "INNER JOIN Units U ON RM.UnitID = U.UnitID " &
                "WHERE RM.MaterialID = @MaterialID"

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(query, conn)

                    cmd.Parameters.Add("@MaterialID", SqlDbType.Int).Value = materialID

                    conn.Open()

                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then

                        Return result.ToString()

                    End If

                End Using

            End Using

        Catch
        End Try

        Return "-"

    End Function

    ' ---------------------------------------------------------
    ' تحميل Recipe Grid
    ' ---------------------------------------------------------
    Private Sub LoadRecipesGrid()

        Try

            Dim productID As Integer

            If Not TryGetComboIntegerValue(cmbProduct, productID) Then

                dgvRecipes.DataSource = Nothing
                Exit Sub

            End If

            Dim query As String = " SELECT 
                Rec.RecipeID, 
                Rec.ProductID, 
                P.ProductNameAr, 
                Rec.SizeID, 
                S.SizeNameAr, 
                Rec.AddonID, 
                A.AddonNameAr, 
                Rec.MaterialID,
                R.MaterialName, 
                Rec.Quantity, 
                U.UnitName, 
                ISNULL(R.CostPrice, 0) AS MaterialUnitCost,
                ROUND(Rec.Quantity * ISNULL(R.CostPrice, 0), 4) AS TotalCost,
                Rec.Notes, 

                CASE 
                WHEN Rec.SizeID IS NOT NULL AND Rec.AddonID IS NOT NULL 
                THEN N'حسب الحجم والإضافة' 

                WHEN Rec.SizeID IS NOT NULL 
                THEN N'حسب الحجم' 

                WHEN Rec.AddonID IS NOT NULL 
                THEN N'حسب الإضافة' 

                ELSE N'الوصفة الأساسية' 
                END AS RecipeType, 

                CASE 
                WHEN S.SizeNameAr IS NOT NULL AND A.AddonNameAr IS NOT NULL 
                THEN S.SizeNameAr + N' + ' + A.AddonNameAr 

                WHEN S.SizeNameAr IS NOT NULL 
                THEN S.SizeNameAr 

                WHEN A.AddonNameAr IS NOT NULL 
                THEN A.AddonNameAr 

                ELSE N'-' 
                END AS RecipeDetails 

                FROM Recipes Rec 
                INNER JOIN Products P ON Rec.ProductID = P.Product_ID 
                LEFT JOIN Sizes S ON Rec.SizeID = S.SizeID 
                LEFT JOIN Addons A ON Rec.AddonID = A.AddonID 
                INNER JOIN RawMaterials R ON Rec.MaterialID = R.MaterialID 
                INNER JOIN Units U ON R.UnitID = U.UnitID 
                WHERE Rec.ProductID = @ProductID "

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand()

                    cmd.Connection = conn

                    cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID

                    ' ------------------------------------------
                    ' فلترة حسب نوع الوصفة
                    ' ------------------------------------------
                    Select Case cmbRecipeType.SelectedIndex

                        Case 0
                            ' الوصفة الأساسية - بدون حجم أو إضافة
                            query &=
                                "AND Rec.SizeID IS NULL " &
                                "AND Rec.AddonID IS NULL "

                        Case 1
                            ' حسب الحجم
                            Dim sizeID As Integer

                            If TryGetComboIntegerValue(cmbSize, sizeID) Then

                                query &=
                                    "AND Rec.SizeID = @SizeID " &
                                    "AND Rec.AddonID IS NULL "

                                cmd.Parameters.Add("@SizeID", SqlDbType.Int).Value = sizeID

                            Else
                                ' لم يختر حجم بعد - عرض الكل للصنف
                                query &=
                                    "AND Rec.SizeID IS NOT NULL " &
                                    "AND Rec.AddonID IS NULL "

                            End If

                        Case 2
                            ' حسب الإضافة
                            Dim addonID As Integer

                            If TryGetComboIntegerValue(cmbAddon, addonID) Then

                                query &=
                                    "AND Rec.SizeID IS NULL " &
                                    "AND Rec.AddonID = @AddonID "

                                cmd.Parameters.Add("@AddonID", SqlDbType.Int).Value = addonID

                            Else
                                ' لم يختر إضافة بعد - عرض الكل للصنف
                                query &=
                                    "AND Rec.SizeID IS NULL " &
                                    "AND Rec.AddonID IS NOT NULL "

                            End If

                        Case 3
                            ' حسب الحجم والإضافة
                            Dim sizeID As Integer
                            Dim addonID As Integer

                            If TryGetComboIntegerValue(cmbSize, sizeID) AndAlso
                               TryGetComboIntegerValue(cmbAddon, addonID) Then

                                query &=
                                    "AND Rec.SizeID = @SizeID " &
                                    "AND Rec.AddonID = @AddonID "

                                cmd.Parameters.Add("@SizeID", SqlDbType.Int).Value = sizeID
                                cmd.Parameters.Add("@AddonID", SqlDbType.Int).Value = addonID

                            ElseIf TryGetComboIntegerValue(cmbSize, sizeID) Then

                                query &=
                                    "AND Rec.SizeID = @SizeID " &
                                    "AND Rec.AddonID IS NOT NULL "

                                cmd.Parameters.Add("@SizeID", SqlDbType.Int).Value = sizeID

                            ElseIf TryGetComboIntegerValue(cmbAddon, addonID) Then

                                query &=
                                    "AND Rec.SizeID IS NOT NULL " &
                                    "AND Rec.AddonID = @AddonID "

                                cmd.Parameters.Add("@AddonID", SqlDbType.Int).Value = addonID

                            Else
                                ' عرض كل الريسيبي اللي ليها حجم وإضافة
                                query &=
                                    "AND Rec.SizeID IS NOT NULL " &
                                    "AND Rec.AddonID IS NOT NULL "

                            End If

                    End Select

                    query &=
                        "ORDER BY R.MaterialName ASC"

                    cmd.CommandText = query

                    Dim dt As New DataTable()

                    conn.Open()

                    Using da As New SqlDataAdapter(cmd)

                        da.Fill(dt)

                    End Using

                    dgvRecipes.DataSource = dt

                End Using

            End Using

            ConfigureRecipeGrid()
            CalculateRecipeFoodCost()

        Catch ex As Exception

            MessageBox.Show(
                "خطأ في تحميل قائمة الريسيبي:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' إعداد أعمدة الـGrid
    ' ---------------------------------------------------------
    Private Sub ConfigureRecipeGrid()

        Dim hiddenCols As String() = {
            "RecipeID",
            "ProductID",
            "SizeID",
            "AddonID",
            "MaterialID"
        }

        For Each columnName As String In hiddenCols

            If dgvRecipes.Columns.Contains(columnName) Then

                dgvRecipes.Columns(columnName).Visible = False

            End If

        Next

        If dgvRecipes.Columns.Contains("ProductNameAr") Then
            dgvRecipes.Columns("ProductNameAr").HeaderText = "الصنف"
        End If

        If dgvRecipes.Columns.Contains("RecipeType") Then
            dgvRecipes.Columns("RecipeType").HeaderText = "نوع الوصفة"
        End If

        If dgvRecipes.Columns.Contains("RecipeDetails") Then
            dgvRecipes.Columns("RecipeDetails").HeaderText = "الحجم / الإضافة"
        End If

        If dgvRecipes.Columns.Contains("SizeNameAr") Then
            dgvRecipes.Columns("SizeNameAr").Visible = False
        End If

        If dgvRecipes.Columns.Contains("AddonNameAr") Then
            dgvRecipes.Columns("AddonNameAr").Visible = False
        End If

        If dgvRecipes.Columns.Contains("MaterialName") Then
            dgvRecipes.Columns("MaterialName").HeaderText = "الخامة"
        End If

        If dgvRecipes.Columns.Contains("Quantity") Then
            dgvRecipes.Columns("Quantity").HeaderText = "الكمية الأساسية"
            dgvRecipes.Columns("Quantity").DefaultCellStyle.Format = "0.######"
        End If

        If dgvRecipes.Columns.Contains("UnitName") Then
            dgvRecipes.Columns("UnitName").HeaderText = "الوحدة الأساسية"
        End If

        If dgvRecipes.Columns.Contains("MaterialUnitCost") Then
            dgvRecipes.Columns("MaterialUnitCost").HeaderText = "تكلفة الوحدة"
            dgvRecipes.Columns("MaterialUnitCost").DefaultCellStyle.Format = "N2"
        End If

        If dgvRecipes.Columns.Contains("TotalCost") Then
            dgvRecipes.Columns("TotalCost").HeaderText = "إجمالي التكلفة"
            dgvRecipes.Columns("TotalCost").DefaultCellStyle.Format = "N2"
            dgvRecipes.Columns("TotalCost").DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            dgvRecipes.Columns("TotalCost").DefaultCellStyle.ForeColor = Color.ForestGreen
        End If

        If dgvRecipes.Columns.Contains("Notes") Then
            dgvRecipes.Columns("Notes").HeaderText = "ملاحظات"
        End If

    End Sub

    ' =========================================================
    ' حساب وعرض تكلفة الوجبة وهامش الربح ونسبة التكلفة (Food Cost %)
    ' =========================================================
    Private Sub CalculateRecipeFoodCost()
        Try

            Dim totalCost As Decimal = 0
            For Each row As DataGridViewRow In dgvRecipes.Rows
                If Not row.IsNewRow AndAlso row.Cells("TotalCost") IsNot Nothing AndAlso row.Cells("TotalCost").Value IsNot Nothing Then
                    Dim val As Decimal = 0
                    If Decimal.TryParse(row.Cells("TotalCost").Value.ToString(), val) Then
                        totalCost += val
                    End If
                End If
            Next
            _currentRecipeTotalCost = totalCost

            ' جلب سعر البيع للصنف / الحجم
            Dim salePrice As Decimal = 0
            Dim prodId As Integer = 0
            If TryGetComboIntegerValue(cmbProduct, prodId) AndAlso prodId > 0 Then
                Dim sizeId As Integer = 0
                If TryGetComboIntegerValue(cmbSize, sizeId) AndAlso sizeId > 0 Then
                    Dim obj = DBModule.ExecuteScalar($"SELECT TOP 1 SalePrice FROM ProductSizes WHERE ProductID = {prodId} AND SizeID = {sizeId}")
                    If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then salePrice = Convert.ToDecimal(obj)
                Else
                    Dim obj = DBModule.ExecuteScalar($"SELECT TOP 1 SalePrice FROM ProductSizes WHERE ProductID = {prodId} ORDER BY IsDefault DESC, ProductSizeID ASC")
                    If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                        salePrice = Convert.ToDecimal(obj)
                    Else
                        Dim obj2 = DBModule.ExecuteScalar($"SELECT TOP 1 BasePrice FROM Products WHERE Product_ID = {prodId}")
                        If obj2 IsNot Nothing AndAlso Not IsDBNull(obj2) Then salePrice = Convert.ToDecimal(obj2)
                    End If
                End If
            End If

            Dim margin As Decimal = salePrice - totalCost
            Dim costPct As Decimal = If(salePrice > 0, (totalCost / salePrice) * 100, 0)

            lblCostSummaryTotal.Text = $"تكلفة الوجبة: {totalCost:N2} ج"
            lblCostSummarySale.Text = $"سعر البيع: {salePrice:N2} ج"
            lblCostSummaryMargin.Text = $"هامش الربح: {margin:N2} ج"

            If salePrice > 0 Then
                If costPct <= 32 Then
                    lblCostSummaryPct.Text = $"نسبة التكلفة: {costPct:F1}% (ممتاز 🟢)"
                    lblCostSummaryPct.ForeColor = Color.FromArgb(16, 185, 129)
                    lblCostSummaryPct.BackColor = Color.FromArgb(16, 45, 35)
                ElseIf costPct <= 42 Then
                    lblCostSummaryPct.Text = $"نسبة التكلفة: {costPct:F1}% (معتدل 🟡)"
                    lblCostSummaryPct.ForeColor = Color.FromArgb(245, 158, 11)
                    lblCostSummaryPct.BackColor = Color.FromArgb(60, 45, 15)
                Else
                    lblCostSummaryPct.Text = $"نسبة التكلفة: {costPct:F1}% (مرتفع 🔴)"
                    lblCostSummaryPct.ForeColor = Color.FromArgb(239, 68, 68)
                    lblCostSummaryPct.BackColor = Color.FromArgb(60, 20, 20)
                End If
            Else
                lblCostSummaryPct.Text = "نسبة التكلفة: -"
                lblCostSummaryPct.ForeColor = Color.White
                lblCostSummaryPct.BackColor = Color.FromArgb(40, 45, 55)
            End If

        Catch ex As Exception
            Debug.WriteLine("CalculateRecipeFoodCost error: " & ex.Message)
        End Try
    End Sub

    Private Sub ApplyRecipeCostToProduct(sender As Object, e As EventArgs)
        Dim prodId As Integer = 0
        If Not TryGetComboIntegerValue(cmbProduct, prodId) OrElse prodId <= 0 Then
            MessageBox.Show("يرجى اختيار صنف أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If _currentRecipeTotalCost <= 0 Then
            MessageBox.Show("لا توجد تكلفة خامات محسوبة للوصفة لتحديثها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sizeId As Integer = 0
        Dim hasSize As Boolean = TryGetComboIntegerValue(cmbSize, sizeId) AndAlso sizeId > 0

        Dim repo As New POSRepository(DBModule.ConnectionString)
        If repo.UpdateProductSizeCostPrice(prodId, If(hasSize, CType(sizeId, Integer?), Nothing), _currentRecipeTotalCost) Then
            MessageBox.Show($"تم تحديث تكلفة الصنف بنجاح بقيمة: {_currentRecipeTotalCost:N2} ج", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("حدث خطأ أثناء تحديث تكلفة الصنف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ---------------------------------------------------------
    ' اختيار Row من الجدول
    ' ---------------------------------------------------------
    Private Sub dgvRecipes_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvRecipes.SelectionChanged

        If _suppressEvents Then Exit Sub

        If dgvRecipes.SelectedRows.Count = 0 Then Exit Sub

        Dim row As DataGridViewRow =
            dgvRecipes.SelectedRows(0)

        Try

            If row.Cells("RecipeID").Value Is Nothing OrElse
               IsDBNull(row.Cells("RecipeID").Value) Then Exit Sub

            _suppressEvents = True

            _selectedRecipeID =
                Convert.ToInt32(row.Cells("RecipeID").Value)

            ' ==========================================
            ' الصنف
            ' ==========================================
            cmbProduct.SelectedValue =
                Convert.ToInt32(row.Cells("ProductID").Value)

            ' ==========================================
            ' تحديد نوع الوصفة
            ' ==========================================
            Dim hasSize As Boolean =
                Not IsDBNull(row.Cells("SizeID").Value)

            Dim hasAddon As Boolean =
                Not IsDBNull(row.Cells("AddonID").Value)

            If hasSize AndAlso hasAddon Then

                cmbRecipeType.SelectedIndex = 3

            ElseIf hasSize Then

                cmbRecipeType.SelectedIndex = 1

            ElseIf hasAddon Then

                cmbRecipeType.SelectedIndex = 2

            Else

                cmbRecipeType.SelectedIndex = 0

            End If

            ApplyRecipeTypeUI()

            ' ==========================================
            ' الحجم
            ' ==========================================
            If hasSize Then

                cmbSize.SelectedValue =
                    Convert.ToInt32(row.Cells("SizeID").Value)

            Else

                cmbSize.SelectedIndex = -1

            End If

            ' ==========================================
            ' الإضافة
            ' ==========================================
            If hasAddon Then

                cmbAddon.SelectedValue =
                    Convert.ToInt32(row.Cells("AddonID").Value)

            Else

                cmbAddon.SelectedIndex = -1

            End If

            ' ==========================================
            ' الخامة
            ' ==========================================
            If Not IsDBNull(row.Cells("MaterialID").Value) Then

                cmbMaterial.SelectedValue =
                    Convert.ToInt32(row.Cells("MaterialID").Value)

            End If

            _suppressEvents = False

            ' ==========================================
            ' تحميل وحدات الخامة
            ' ==========================================
            Dim materialID As Integer

            If TryGetComboIntegerValue(cmbMaterial, materialID) Then

                LoadMaterialUnits(materialID)

            End If

            ' ==========================================
            ' عند التعديل سنعرض الكمية بالوحدة الأساسية
            ' لأن جدول Recipes يخزن الكمية بعد التحويل
            ' ==========================================
            txtQuantity.Text =
                If(
                    IsDBNull(row.Cells("Quantity").Value),
                    "0.0000",
                    Convert.ToDecimal(
                        row.Cells("Quantity").Value
                    ).ToString("0.######")
                )

            ' اختيار الوحدة الأساسية
            SelectBaseUnit()

            txtNotes.Text =
                If(
                    IsDBNull(row.Cells("Notes").Value),
                    "",
                    row.Cells("Notes").Value.ToString()
                )

        Catch ex As Exception

            _suppressEvents = False

            MessageBox.Show(
                "خطأ أثناء تحميل بيانات السطر:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' اختيار الوحدة الأساسية
    ' ---------------------------------------------------------
    Private Sub SelectBaseUnit()

        If cmbMaterialUnit.Items.Count = 0 Then Exit Sub

        Dim dt As DataTable =
            TryCast(cmbMaterialUnit.DataSource, DataTable)

        If dt Is Nothing Then Exit Sub

        For Each row As DataRow In dt.Rows

            If Convert.ToDecimal(row("ConversionFactor")) = 1D Then

                cmbMaterialUnit.SelectedValue =
                    Convert.ToInt32(row("UnitID"))

                Exit For

            End If

        Next

    End Sub

    ' ---------------------------------------------------------
    ' إضافة خامة للوصفة
    ' ---------------------------------------------------------
    Private Sub btnAdd_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAdd.Click

        If Not ValidateRecipeScope() Then Exit Sub

        Dim materialID As Integer

        If Not TryGetComboIntegerValue(cmbMaterial, materialID) Then

            MessageBox.Show(
                "يرجى اختيار الخامة أولاً.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Sub

        End If

        Dim inputQuantity As Decimal

        If Not Decimal.TryParse(
            txtQuantity.Text.Trim(),
            inputQuantity
        ) OrElse inputQuantity <= 0D Then

            MessageBox.Show(
                "يرجى إدخال كمية صحيحة أكبر من صفر.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtQuantity.Focus()

            Exit Sub

        End If

        Dim conversionFactor As Decimal

        If Not TryGetSelectedConversionFactor(conversionFactor) Then

            MessageBox.Show(
                "يرجى اختيار وحدة الاستخدام.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Sub

        End If

        ' ==========================================
        ' تحويل الكمية إلى الوحدة الأساسية
        ' ==========================================
        Dim baseQuantity As Decimal =
            inputQuantity * conversionFactor

        ' ==========================================
        ' منع التكرار
        ' ==========================================
        If RecipeMaterialExists(materialID, Nothing) Then

            MessageBox.Show(
                "هذه الخامة مضافة بالفعل إلى هذه الوصفة." &
                Environment.NewLine &
                "يمكنك تحديدها من الجدول ثم تعديل كميتها.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Sub

        End If

        Try

            Dim query As String =
                "INSERT INTO Recipes " &
                "(ProductID, SizeID, AddonID, MaterialID, Quantity, Notes) " &
                "VALUES " &
                "(@ProductID, @SizeID, @AddonID, @MaterialID, @Quantity, @Notes)"

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(query, conn)

                    AddRecipeParameters(cmd)

                    cmd.Parameters.Add("@MaterialID", SqlDbType.Int).Value =
                        materialID

                    Dim quantityParameter =
                        cmd.Parameters.Add("@Quantity", SqlDbType.Decimal)

                    quantityParameter.Precision = 18
                    quantityParameter.Scale = 6
                    quantityParameter.Value = baseQuantity

                    cmd.Parameters.Add(
                        "@Notes",
                        SqlDbType.NVarChar,
                        -1
                    ).Value =
                        If(
                            String.IsNullOrWhiteSpace(txtNotes.Text),
                            CType(DBNull.Value, Object),
                            txtNotes.Text.Trim()
                        )

                    conn.Open()

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "تمت إضافة الخامة إلى الوصفة بنجاح.",
                "نجاح",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            LoadRecipesGrid()

            ClearMaterialFields()

        Catch ex As Exception

            MessageBox.Show(
                "خطأ أثناء إضافة الخامة:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' تعديل خامة
    ' ---------------------------------------------------------
    Private Sub btnEdit_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEdit.Click

        If Not _selectedRecipeID.HasValue Then

            MessageBox.Show(
                "يرجى تحديد خامة من الجدول أولاً.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Sub

        End If

        If Not ValidateRecipeScope() Then Exit Sub

        Dim materialID As Integer

        If Not TryGetComboIntegerValue(cmbMaterial, materialID) Then

            MessageBox.Show(
                "يرجى اختيار الخامة.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Sub

        End If

        Dim inputQuantity As Decimal

        If Not Decimal.TryParse(
            txtQuantity.Text.Trim(),
            inputQuantity
        ) OrElse inputQuantity <= 0D Then

            MessageBox.Show(
                "يرجى إدخال كمية صحيحة أكبر من صفر.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Sub

        End If

        Dim conversionFactor As Decimal

        If Not TryGetSelectedConversionFactor(conversionFactor) Then

            MessageBox.Show(
                "يرجى اختيار وحدة الاستخدام.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Sub

        End If

        Dim baseQuantity As Decimal =
            inputQuantity * conversionFactor

        ' ==========================================
        ' منع تكرار الخامة مع استثناء السطر الحالي
        ' ==========================================
        If RecipeMaterialExists(
            materialID,
            _selectedRecipeID.Value
        ) Then

            MessageBox.Show(
                "هذه الخامة موجودة بالفعل في نفس الوصفة.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Sub

        End If

        Try

            Dim query As String =
                "UPDATE Recipes SET 
                 ProductID = @ProductID,
                 SizeID = @SizeID, 
                 AddonID = @AddonID, 
                 MaterialID = @MaterialID, 
                 Quantity = @Quantity, 
                 Notes = @Notes 
                 WHERE RecipeID = @RecipeID"

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(query, conn)

                    AddRecipeParameters(cmd)

                    cmd.Parameters.Add("@RecipeID", SqlDbType.Int).Value =
                        _selectedRecipeID.Value

                    cmd.Parameters.Add("@MaterialID", SqlDbType.Int).Value =
                        materialID

                    Dim quantityParameter =
                        cmd.Parameters.Add("@Quantity", SqlDbType.Decimal)

                    quantityParameter.Precision = 18
                    quantityParameter.Scale = 6
                    quantityParameter.Value = baseQuantity

                    cmd.Parameters.Add(
                        "@Notes",
                        SqlDbType.NVarChar,
                        -1
                    ).Value =
                        If(
                            String.IsNullOrWhiteSpace(txtNotes.Text),
                            CType(DBNull.Value, Object),
                            txtNotes.Text.Trim()
                        )

                    conn.Open()

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "تم تعديل الخامة بنجاح.",
                "نجاح",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            LoadRecipesGrid()

            ClearMaterialFields()

        Catch ex As Exception

            MessageBox.Show(
                "خطأ أثناء التعديل:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' حذف خامة من الوصفة
    ' ---------------------------------------------------------
    Private Sub btnDelete_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDelete.Click

        If Not _selectedRecipeID.HasValue Then Exit Sub

        If MessageBox.Show(
            "هل أنت متأكد من حذف هذه الخامة من الوصفة؟",
            "تأكيد الحذف",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        ) <> DialogResult.Yes Then

            Exit Sub

        End If

        Try

            Dim query As String =
                "DELETE FROM Recipes " &
                "WHERE RecipeID = @RecipeID"

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(query, conn)

                    cmd.Parameters.Add(
                        "@RecipeID",
                        SqlDbType.Int
                    ).Value =
                        _selectedRecipeID.Value

                    conn.Open()

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "تم حذف الخامة من الوصفة.",
                "نجاح",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            LoadRecipesGrid()

            ClearMaterialFields()

        Catch ex As Exception

            MessageBox.Show(
                "خطأ أثناء الحذف:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' منع تكرار الخامة داخل نفس Recipe Scope
    ' ---------------------------------------------------------
    Private Function RecipeMaterialExists(
        materialID As Integer,
        excludingRecipeID As Integer?
    ) As Boolean

        Try

            Dim query As String =
                "SELECT COUNT(1) " &
                "FROM Recipes " &
                "WHERE ProductID = @ProductID " &
                "AND MaterialID = @MaterialID "

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand()

                    cmd.Connection = conn

                    cmd.Parameters.Add(
                        "@ProductID",
                        SqlDbType.Int
                    ).Value =
                        GetProductID()

                    cmd.Parameters.Add(
                        "@MaterialID",
                        SqlDbType.Int
                    ).Value =
                        materialID

                    AddScopeConditions(
                        cmd,
                        query,
                        False
                    )

                    ' لا تمسح query من cmd.CommandText - query جاهزة من AddScopeConditions
                    If excludingRecipeID.HasValue Then

                        query &=
                            " AND RecipeID <> @ExcludeRecipeID "

                        cmd.Parameters.Add(
                            "@ExcludeRecipeID",
                            SqlDbType.Int
                        ).Value =
                            excludingRecipeID.Value

                    End If

                    cmd.CommandText = query

                    conn.Open()

                    Return Convert.ToInt32(
                        cmd.ExecuteScalar()
                    ) > 0

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "خطأ أثناء فحص تكرار الخامة:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return True

        End Try

    End Function

    ' ---------------------------------------------------------
    ' إضافة شروط Scope للـQuery
    ' ---------------------------------------------------------
    Private Sub AddScopeConditions(
        cmd As SqlCommand,
        ByRef query As String,
        addProduct As Boolean
    )

        If addProduct Then

            query &=
                " WHERE ProductID = @ProductID "

        End If

        Select Case cmbRecipeType.SelectedIndex

            Case 0

                query &=
                    " AND SizeID IS NULL " &
                    " AND AddonID IS NULL "

            Case 1

                Dim sizeID As Integer

                If TryGetComboIntegerValue(cmbSize, sizeID) Then

                    query &=
                        " AND SizeID = @CheckSizeID " &
                        " AND AddonID IS NULL "

                    cmd.Parameters.Add(
                        "@CheckSizeID",
                        SqlDbType.Int
                    ).Value =
                        sizeID

                Else

                    query &= " AND 1 = 0 "

                End If

            Case 2

                Dim addonID As Integer

                If TryGetComboIntegerValue(cmbAddon, addonID) Then

                    query &=
                        " AND SizeID IS NULL " &
                        " AND AddonID = @CheckAddonID "

                    cmd.Parameters.Add(
                        "@CheckAddonID",
                        SqlDbType.Int
                    ).Value =
                        addonID

                Else

                    query &= " AND 1 = 0 "

                End If

            Case 3

                Dim sizeID As Integer
                Dim addonID As Integer

                If TryGetComboIntegerValue(cmbSize, sizeID) AndAlso
                   TryGetComboIntegerValue(cmbAddon, addonID) Then

                    query &=
                        " AND SizeID = @CheckSizeID " &
                        " AND AddonID = @CheckAddonID "

                    cmd.Parameters.Add(
                        "@CheckSizeID",
                        SqlDbType.Int
                    ).Value =
                        sizeID

                    cmd.Parameters.Add(
                        "@CheckAddonID",
                        SqlDbType.Int
                    ).Value =
                        addonID

                Else

                    query &= " AND 1 = 0 "

                End If

        End Select

    End Sub

    ' ---------------------------------------------------------
    ' إضافة Parameters للصنف والحجم والإضافة
    ' ---------------------------------------------------------
    Private Sub AddRecipeParameters(cmd As SqlCommand)

        cmd.Parameters.Add(
            "@ProductID",
            SqlDbType.Int
        ).Value =
            GetProductID()

        Dim sizeID As Integer

        If ShouldUseSize() AndAlso
           TryGetComboIntegerValue(cmbSize, sizeID) Then

            cmd.Parameters.Add(
                "@SizeID",
                SqlDbType.Int
            ).Value =
                sizeID

        Else

            cmd.Parameters.Add(
                "@SizeID",
                SqlDbType.Int
            ).Value =
                DBNull.Value

        End If

        Dim addonID As Integer

        If ShouldUseAddon() AndAlso
           TryGetComboIntegerValue(cmbAddon, addonID) Then

            cmd.Parameters.Add(
                "@AddonID",
                SqlDbType.Int
            ).Value =
                addonID

        Else

            cmd.Parameters.Add(
                "@AddonID",
                SqlDbType.Int
            ).Value =
                DBNull.Value

        End If

    End Sub

    ' ---------------------------------------------------------
    ' التحقق من Scope الوصفة
    ' ---------------------------------------------------------
    Private Function ValidateRecipeScope() As Boolean

        Dim productID As Integer

        If Not TryGetComboIntegerValue(
            cmbProduct,
            productID
        ) Then

            MessageBox.Show(
                "يرجى اختيار الصنف أولاً.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Function

        End If

        If cmbRecipeType.SelectedIndex = -1 Then

            MessageBox.Show(
                "يرجى اختيار نوع الوصفة.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Exit Function

        End If

        If ShouldUseSize() Then

            Dim sizeID As Integer

            If Not TryGetComboIntegerValue(
                cmbSize,
                sizeID
            ) Then

                MessageBox.Show(
                    "يرجى اختيار الحجم.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Exit Function

            End If

        End If

        If ShouldUseAddon() Then

            Dim addonID As Integer

            If Not TryGetComboIntegerValue(
                cmbAddon,
                addonID
            ) Then

                MessageBox.Show(
                    "يرجى اختيار الإضافة.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Exit Function

            End If

        End If

        Return True

    End Function

    ' ---------------------------------------------------------
    ' هل تستخدم الحجم؟
    ' ---------------------------------------------------------
    Private Function ShouldUseSize() As Boolean

        Return cmbRecipeType.SelectedIndex = 1 OrElse
               cmbRecipeType.SelectedIndex = 3

    End Function

    ' ---------------------------------------------------------
    ' هل تستخدم الإضافة؟
    ' ---------------------------------------------------------
    Private Function ShouldUseAddon() As Boolean

        Return cmbRecipeType.SelectedIndex = 2 OrElse
               cmbRecipeType.SelectedIndex = 3

    End Function

    ' ---------------------------------------------------------
    ' الحصول على ProductID
    ' ---------------------------------------------------------
    Private Function GetProductID() As Integer

        Dim productID As Integer

        If TryGetComboIntegerValue(
            cmbProduct,
            productID
        ) Then

            Return productID

        End If

        Return 0

    End Function

    ' ---------------------------------------------------------
    ' الحصول على ConversionFactor المحدد
    ' ---------------------------------------------------------
    Private Function TryGetSelectedConversionFactor(
        ByRef factor As Decimal
    ) As Boolean

        factor = 0D

        If cmbMaterialUnit.SelectedIndex = -1 Then
            Return False
        End If

        Dim drv As DataRowView =
            TryCast(
                cmbMaterialUnit.SelectedItem,
                DataRowView
            )

        If drv Is Nothing Then
            Return False
        End If

        Try

            factor =
                Convert.ToDecimal(
                    drv("ConversionFactor")
                )

            Return factor > 0D

        Catch

            Return False

        End Try

    End Function

    ' ---------------------------------------------------------
    ' قراءة ComboBox Integer بأمان
    ' ---------------------------------------------------------
    Private Function TryGetComboIntegerValue(
        combo As ComboBox,
        ByRef value As Integer
    ) As Boolean

        value = 0

        If combo Is Nothing Then
            Return False
        End If

        If combo.SelectedIndex = -1 Then
            Return False
        End If

        If combo.SelectedValue Is Nothing OrElse
           combo.SelectedValue Is DBNull.Value Then

            Return False

        End If

        Try

            value =
                Convert.ToInt32(
                    combo.SelectedValue
                )

            Return True

        Catch

            Return False

        End Try

    End Function

    ' ---------------------------------------------------------
    ' تنظيف بيانات الخامة فقط
    '
    ' مهم:
    ' لا نمسح الصنف والحجم والإضافة
    ' حتى يقدر المستخدم يضيف عدة خامات بسرعة.
    ' ---------------------------------------------------------
    Private Sub ClearMaterialFields()

        _selectedRecipeID = Nothing

        _suppressEvents = True

        cmbMaterial.SelectedIndex = -1
        cmbMaterialUnit.DataSource = Nothing

        txtQuantity.Text = "0.0000"
        txtNotes.Clear()

        lblUnitIndicator.Text = "-"
        lblConversionHint.Text = ""

        _suppressEvents = False

        dgvRecipes.ClearSelection()

    End Sub

    ' ---------------------------------------------------------
    ' زر تفريغ
    ' ---------------------------------------------------------
    Private Sub btnClearFields_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClearFields.Click

        ClearMaterialFields()

    End Sub

    ' ---------------------------------------------------------
    ' زر Refresh
    ' ---------------------------------------------------------
    Private Sub btnRefresh_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRefresh.Click

        Try

            FillProductsAndMaterials()

            LoadRecipesGrid()

            ClearMaterialFields()

        Catch ex As Exception

            MessageBox.Show(
                "خطأ أثناء تحديث البيانات:" &
                Environment.NewLine &
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' ---------------------------------------------------------
    ' إغلاق
    ' ---------------------------------------------------------
    Private Sub btn_close_Click(
        sender As Object,
        e As EventArgs
    ) Handles btn_close.Click

        Close()

    End Sub

    ' ---------------------------------------------------------
    ' تكبير
    ' ---------------------------------------------------------
    Private Sub btn_max_Click(
        sender As Object,
        e As EventArgs
    ) Handles btn_max.Click

        FormHelper.ToggleMaximize(Me)

    End Sub

    ' ---------------------------------------------------------
    ' تصغير
    ' ---------------------------------------------------------
    Private Sub btn_min_Click(
        sender As Object,
        e As EventArgs
    ) Handles btn_min.Click

        FormHelper.Minimiz(Me)

    End Sub

End Class