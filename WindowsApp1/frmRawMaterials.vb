Imports System.Data.SqlClient
Imports DevExpress.Utils.Html.Internal

Public Class frmRawMaterials

    Private _cachedMaterials As DataTable = Nothing

    ' 1. تعبئة قائمة الوحدات
    Private Sub FillUnitsDropdown()
        Try
            Dim dt As DataTable = DBModule.ExecuteQuery("SELECT UnitID, UnitName FROM Units Where IsActive = 1 AND IsDeleted = 0")
            If dt IsNot Nothing Then
                cmbUnit.DataSource = dt
                cmbUnit.DisplayMember = "UnitName"
                cmbUnit.ValueMember = "UnitID"
                cmbUnit.SelectedIndex = -1
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading units: " & ex.Message)
        End Try
    End Sub

    ' زر الـ + لفتح شاشة الوحدات فرعياً وتحديث القائمة تلقائياً
    Private Sub btnAddUnitForm_Click(sender As Object, e As EventArgs) Handles btnAddUnitForm.Click
        Dim frm As New frmUnits()
        frm.ShowDialog()
        FillUnitsDropdown()
    End Sub

    ' 2. تحميل وجلب قائمة الخامات للجريد فيو (بدون المحذوفة ناعماً)
    Private Sub LoadMaterialsGrid(Optional filter As String = "", Optional field As String = "")
        Try
            If _cachedMaterials Is Nothing OrElse (String.IsNullOrEmpty(filter) AndAlso String.IsNullOrEmpty(field)) Then
                Dim query As String = "SELECT R.MaterialID, R.MaterialBarcode, R.MaterialName, R.UnitID, U.UnitName, " &
                                      "R.CostPrice, R.IsActive " &
                                      "FROM RawMaterials R " &
                                      "INNER JOIN Units U ON R.UnitID = U.UnitID " &
                                      "WHERE (R.IsDeleted = 0 OR R.IsDeleted IS NULL) " &
                                      "ORDER BY R.MaterialName ASC"
                _cachedMaterials = DBModule.ExecuteQuery(query)
            End If

            If _cachedMaterials Is Nothing Then Exit Sub

            Dim dtToBind As DataTable = _cachedMaterials

            ' البحث التفاعلي في الذاكرة
            If Not String.IsNullOrEmpty(filter) AndAlso Not String.IsNullOrEmpty(field) Then
                Dim col As String = ""
                Select Case field.Trim()
                    Case "الاسم" : col = "MaterialName"
                    Case "الباركود" : col = "MaterialBarcode"
                End Select

                If col <> "" AndAlso _cachedMaterials.Columns.Contains(col) Then
                    Dim dv As New DataView(_cachedMaterials)
                    dv.RowFilter = $"{col} LIKE '%{filter.Replace("'", "''")}%'"
                    dtToBind = dv.ToTable()
                End If
            End If

            dgvMaterials.DataSource = dtToBind

            If dgvMaterials.Columns.Contains("MaterialID") Then dgvMaterials.Columns("MaterialID").Visible = False
            If dgvMaterials.Columns.Contains("UnitID") Then dgvMaterials.Columns("UnitID").Visible = False

            If dgvMaterials.Columns.Contains("MaterialBarcode") Then dgvMaterials.Columns("MaterialBarcode").HeaderText = "الباركود"
            If dgvMaterials.Columns.Contains("MaterialName") Then dgvMaterials.Columns("MaterialName").HeaderText = "اسم الخامة"
            If dgvMaterials.Columns.Contains("UnitName") Then dgvMaterials.Columns("UnitName").HeaderText = "الوحدة"
            If dgvMaterials.Columns.Contains("CostPrice") Then dgvMaterials.Columns("CostPrice").HeaderText = "تكلفة الوحدة"
            If dgvMaterials.Columns.Contains("MinStock") Then dgvMaterials.Columns("MinStock").HeaderText = "حد الأمان"
            If dgvMaterials.Columns.Contains("IsActive") Then dgvMaterials.Columns("IsActive").HeaderText = "نشط"

        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل الخامات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        txtBarcode.Clear()
        txtMaterialName.Clear()
        cmbUnit.SelectedIndex = -1
        txtCostPrice.Text = "0.0000"
        'txtMinStock.Text = "0.000"
        tgStatus.Checked = True
        dgvMaterials.ClearSelection()
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtMaterialName.Text) Then
            SmartMessageBox.Show("يرجى إدخال اسم الخامة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaterialName.Focus()
            Return False
        End If
        If cmbUnit.SelectedIndex = -1 Then
            SmartMessageBox.Show("يرجى اختيار الوحدة الأساسية أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbUnit.Focus()
            Return False
        End If
        Dim cost As Decimal = 0
        If Not Decimal.TryParse(txtCostPrice.Text, cost) OrElse cost < 0 Then
            SmartMessageBox.Show("يرجى إدخال تكلفة وحدة أساسية صحيحة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCostPrice.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub frmRawMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.AddRange(New Object() {"الاسم", "الباركود"})
        cmbSearchField.SelectedIndex = 0

        FillUnitsDropdown()
        LoadMaterialsGrid()
        ClearFields()

        datagridviewsetup(dgvMaterials)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub dgvMaterials_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMaterials.SelectionChanged
        If dgvMaterials.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvMaterials.SelectedRows(0)

        If row.Cells("MaterialID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("MaterialID").Value) Then
            txtBarcode.Text = If(IsDBNull(row.Cells("MaterialBarcode").Value), "", row.Cells("MaterialBarcode").Value.ToString())
            txtMaterialName.Text = If(IsDBNull(row.Cells("MaterialName").Value), "", row.Cells("MaterialName").Value.ToString())
            txtCostPrice.Text = If(IsDBNull(row.Cells("CostPrice").Value), "0.0000", row.Cells("CostPrice").Value.ToString())
            'txtMinStock.Text = If(IsDBNull(row.Cells("MinStock").Value), "0.000", row.Cells("MinStock").Value.ToString())

            If Not IsDBNull(row.Cells("UnitID").Value) Then cmbUnit.SelectedValue = row.Cells("UnitID").Value
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' زر إضافة خامة جديدة
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim cost As Decimal = 0, minStk As Decimal = 0
        Decimal.TryParse(txtCostPrice.Text, cost)
        'Decimal.TryParse(txtMinStock.Text, minStk)

        ' IsDeleted = 0 عند الإضافة دائماً
        Dim query As String = "INSERT INTO RawMaterials (MaterialBarcode, MaterialName, UnitID, CostPrice,IsActive, IsDeleted) " &
                              "VALUES (@Barcode, @Name, @UnitID, @CostPrice,  @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrEmpty(txtBarcode.Text), DBNull.Value, txtBarcode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtMaterialName.Text.Trim())
                cmd.Parameters.AddWithValue("@UnitID", cmbUnit.SelectedValue)
                cmd.Parameters.AddWithValue("@CostPrice", cost)
                'cmd.Parameters.AddWithValue("@MinStock", minStk)
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    SmartMessageBox.Show("تم حفظ الخامة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedMaterials = Nothing
                    LoadMaterialsGrid()
                    ClearFields()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' زر تعديل خامة
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvMaterials.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvMaterials.SelectedRows(0).Cells("MaterialID").Value)
        Dim cost As Decimal = 0, minStk As Decimal = 0
        Decimal.TryParse(txtCostPrice.Text, cost)
        'Decimal.TryParse(txtMinStock.Text, minStk)

        Dim query As String = "UPDATE RawMaterials SET MaterialBarcode = @Barcode, MaterialName = @Name, UnitID = @UnitID, " &
                              "CostPrice = @CostPrice,  IsActive = @IsActive WHERE MaterialID = @MaterialID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@MaterialID", currentID)
                cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrEmpty(txtBarcode.Text), DBNull.Value, txtBarcode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtMaterialName.Text.Trim())
                cmd.Parameters.AddWithValue("@UnitID", cmbUnit.SelectedValue)
                cmd.Parameters.AddWithValue("@CostPrice", cost)
                'cmd.Parameters.AddWithValue("@MinStock", minStk)
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    SmartMessageBox.Show("تم تعديل الخامة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedMaterials = Nothing
                    LoadMaterialsGrid()
                    ClearFields()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadMaterialsGrid(txtSearch.Text.Trim(), cmbSearchField.SelectedItem?.ToString())
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedMaterials = Nothing
        LoadMaterialsGrid()
        ClearFields()
    End Sub

    Private Sub btnOpenUnitsConversion_Click(sender As Object, e As EventArgs) Handles btnOpenUnitsConversion.Click
        If dgvMaterials.SelectedRows.Count = 0 Then
            SmartMessageBox.Show("يرجى تحديد خامة من الجدول أولاً لضبط وحدات التحويل الخاصة بها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvMaterials.SelectedRows(0)
        Dim matID As Integer = Convert.ToInt32(row.Cells("MaterialID").Value)
        Dim matName As String = row.Cells("MaterialName").Value.ToString()
        Dim baseUnit As String = row.Cells("UnitName").Value.ToString()

        ' فتح الفورم وتمرير بيانات الخامة المحددة
        Dim frm As New frmMaterialUnits(matID, matName, baseUnit)
        frm.ShowDialog()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    ' ---------------------------------------------------------
    ' زر حذف خامة - حذف ناعم (Soft Delete)
    ' يضع IsDeleted = 1 ويوقف الخامة بدلاً من الحذف الفعلي
    ' ---------------------------------------------------------
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If dgvMaterials.SelectedRows.Count = 0 Then
            SmartMessageBox.Show(
                "يرجى تحديد خامة من الجدول أولاً.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvMaterials.SelectedRows(0)
        Dim materialID As Integer = Convert.ToInt32(row.Cells("MaterialID").Value)
        Dim materialName As String = row.Cells("MaterialName").Value.ToString()

        ' تأكيد الحذف
        Dim confirm As DialogResult = SmartMessageBox.Show(
            $"هل أنت متأكد من حذف الخامة ""{materialName}""؟" & Environment.NewLine &
            "سيتم إخفاؤها ولن تظهر في القوائم أو الوصفات.",
            "تأكيد الحذف",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If confirm <> DialogResult.Yes Then Exit Sub

        Try

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(
                    "UPDATE RawMaterials SET IsDeleted = 1, IsActive = 0 WHERE MaterialID = @ID",
                    conn
                )
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = materialID
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            SmartMessageBox.Show(
                $"تم حذف الخامة ""{materialName}"" بنجاح.",
                "تم الحذف",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            _cachedMaterials = Nothing
            LoadMaterialsGrid()
            ClearFields()

        Catch ex As Exception

            SmartMessageBox.Show(
                "خطأ أثناء الحذف:" & Environment.NewLine & ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub btnApplyAsBaseCost_Click(sender As Object, e As EventArgs) Handles btnApplyAsBaseCost.Click
        ' 1. التحقق من وجود خامة محددة أو محفوظة مسبقاً
        ' (استبدل _selectedMaterialID بالمتغير الخاص برقم الخامة في فورم الخامات لديك)

        If dgvMaterials.SelectedRows.Count = 0 Then Exit Sub
        Dim dgvrow As DataGridViewRow = dgvMaterials.SelectedRows(0)
        Dim _selectedMaterialID As Integer
        If dgvrow.Cells("MaterialID").Value IsNot Nothing AndAlso Not IsDBNull(dgvrow.Cells("MaterialID").Value) Then
            _selectedMaterialID = If(IsDBNull(dgvrow.Cells("MaterialID").Value), "", dgvrow.Cells("MaterialID").Value)
        End If

        If _selectedMaterialID <= 0 Then
            SmartMessageBox.Show("يرجى حفظ أو اختيار الخامة أولاً لتتمكن من احتساب التكلفة من وحداتها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' 2. جلب جميع الوحدات الكبرى المسجلة لهذه الخامة والتي لها سعر شراء ومعامل تحويل
            Dim query As String = "SELECT MU.UnitID, U.UnitName, MU.ConversionFactor, MU.PurchasePrice " &
                              "FROM MaterialUnits MU " &
                              "INNER JOIN Units U ON MU.UnitID = U.UnitID " &
                              "WHERE MU.MaterialID = @MatID AND MU.ConversionFactor > 0 AND MU.PurchasePrice > 0 " &
                              "ORDER BY MU.ConversionFactor DESC"

            Dim dtUnits As New DataTable()
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@MatID", _selectedMaterialID)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dtUnits)
                    End Using
                End Using
            End Using

            ' 3. في حالة عدم وجود وحدات أكبر بأسعار مسجلة
            If dtUnits.Rows.Count = 0 Then
                SmartMessageBox.Show("لم يتم العثور على وحدات كبرى مسجلة بأسعار شراء لهذه الخامة!" & vbCrLf &
                            "يرجى فتح شاشة وحدات التحويل وتسجيل وحدة (مثل: شكارة أو كرتونة) وتحديد سعر شرائها أولاً.",
                            "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' 4. إذا كانت هناك وحدة واحدة فقط: يتم الحساب ووضع الناتج فوراً
            If dtUnits.Rows.Count = 1 Then
                Dim row As DataRow = dtUnits.Rows(0)
                Dim unitName As String = row("UnitName").ToString()
                Dim factor As Decimal = Convert.ToDecimal(row("ConversionFactor"))
                Dim price As Decimal = Convert.ToDecimal(row("PurchasePrice"))
                Dim baseCost As Decimal = price / factor

                ' وضع القيمة المحسوبة في التيكست بوكس
                txtCostPrice.Text = baseCost.ToString("N4")

                SmartMessageBox.Show($"تم احتساب تكلفة الوحدة الأساسية بنجاح بناءً على:" & vbCrLf &
                            $"- الوحدة: {unitName}" & vbCrLf &
                            $"- سعر الشراء: {price:N2} ج" & vbCrLf &
                            $"- معامل التحويل: {factor:N2}" & vbCrLf &
                            $"- تكلفة الوحدة الأساسية: {baseCost:N4} ج" & vbCrLf & vbCrLf &
                            "اضغط على زر (حفظ) لاعتماد البيانات.",
                            "تم الاحتساب", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 5. إذا وُجد أكثر من وحدة: تظهر قائمة منبثقة سريعة ليختار منها المستخدم بضغطة واحدة
            Else
                Dim menuUnits As New ContextMenuStrip()

                For Each row As DataRow In dtUnits.Rows
                    Dim unitName As String = row("UnitName").ToString()
                    Dim factor As Decimal = Convert.ToDecimal(row("ConversionFactor"))
                    Dim price As Decimal = Convert.ToDecimal(row("PurchasePrice"))
                    Dim baseCost As Decimal = price / factor

                    ' نص السطر في القائمة المنبثقة
                    Dim itemText As String = $"وحدة: {unitName} | السعر: {price:N2} ج ⬅ (تكلفة الوحدة الأساسية: {baseCost:N4} ج)"
                    Dim menuItem As New ToolStripMenuItem(itemText)

                    ' عند الضغط على وحدة معينة من القائمة
                    AddHandler menuItem.Click, Sub(s, args)
                                                   txtCostPrice.Text = baseCost.ToString("N4")
                                                   SmartMessageBox.Show($"تم نقل التكلفة ({baseCost:N4} ج) إلى خانة التكلفة بنجاح بناءً على ({unitName})." & vbCrLf &
                                                              "اضغط على زر (حفظ) لاعتماد التعديل.", "تم التحديد", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                               End Sub

                    menuUnits.Items.Add(menuItem)
                Next

                ' إظهار القائمة تحت الزر مباشرة
                menuUnits.Show(btnApplyAsBaseCost, New Point(0, btnApplyAsBaseCost.Height))
            End If

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء جلب وحدات التحويل واحتساب التكلفة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class