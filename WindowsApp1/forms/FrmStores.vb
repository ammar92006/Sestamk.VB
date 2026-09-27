Imports System.Data.SqlClient

Public Class frmStores
    Private _cachedStores As DataTable = Nothing
    Private _isDeletedColumnExists As Boolean = False
    Private _storeCodeColumnExists As Boolean = False
    Private _notesColumnExists As Boolean = False
    Private _isActiveColumnExists As Boolean = False

    ' ──────────────────────────────────────────────────────────
    ' 1. دالة جلب البيانات من قاعدة البيانات وتحميلها في الجريد
    ' ──────────────────────────────────────────────────────────
    Private Sub LoadStoresGrid()
        Try
            ' أول استعلام لجلب البيانات ومعرفة الأعمدة المتاحة في الجدول
            Dim query As String = "SELECT * FROM Stores ORDER BY StoreID ASC"
            Dim dt As DataTable = DBModule.ExecuteQuery(query)

            If dt IsNot Nothing Then
                _cachedStores = dt

                ' فحص وجود الأعمدة في قاعدة البيانات لتنفيذ soft delete والإضافات بأمان
                _isDeletedColumnExists = _cachedStores.Columns.Contains("IsDeleted")
                _storeCodeColumnExists = _cachedStores.Columns.Contains("StoreCode")
                _notesColumnExists = _cachedStores.Columns.Contains("Notes")
                _isActiveColumnExists = _cachedStores.Columns.Contains("IsActive")

                ' تصفية الصفوف المحذوفة لو عمود IsDeleted موجود
                If _isDeletedColumnExists Then
                    _cachedStores.DefaultView.RowFilter = "(IsDeleted = 0 OR IsDeleted IS NULL)"
                Else
                    _cachedStores.DefaultView.RowFilter = ""
                End If

                dgvStores.DataSource = _cachedStores.DefaultView

                ' إعداد أسماء وإظهار الأعمدة باللغة العربية
                If dgvStores.Columns.Contains("StoreID") Then dgvStores.Columns("StoreID").Visible = False
                If dgvStores.Columns.Contains("IsDeleted") Then dgvStores.Columns("IsDeleted").Visible = False

                If _storeCodeColumnExists AndAlso dgvStores.Columns.Contains("StoreCode") Then
                    dgvStores.Columns("StoreCode").HeaderText = "كود المخزن"
                End If

                If dgvStores.Columns.Contains("StoreName") Then
                    dgvStores.Columns("StoreName").HeaderText = "اسم المخزن"
                End If

                If dgvStores.Columns.Contains("IsDefault") Then
                    dgvStores.Columns("IsDefault").HeaderText = "المخزن الافتراضي"
                End If

                If _notesColumnExists AndAlso dgvStores.Columns.Contains("Notes") Then
                    dgvStores.Columns("Notes").HeaderText = "ملاحظات"
                End If

                If _isActiveColumnExists AndAlso dgvStores.Columns.Contains("IsActive") Then
                    dgvStores.Columns("IsActive").HeaderText = "نشط"
                End If

                dgvStores.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل قائمة المخازن: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 2. دالة التحقق من المدخلات (Validation)
    ' ──────────────────────────────────────────────────────────
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtStoreName.Text) Then
            MessageBox.Show("عذراً، يجب إدخال اسم المخزن أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStoreName.Focus()
            Return False
        End If
        Return True
    End Function

    ' ──────────────────────────────────────────────────────────
    ' 3. توليد كود المخزن التلقائي
    ' ──────────────────────────────────────────────────────────
    Private Sub GenerateNextStoreCode()
        Try
            txtStoreCode.Text = GetNextCode("Stores", "StoreCode").ToString()
        Catch
            txtStoreCode.Text = "1"
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 4. تفريغ وتنظيف الحقول
    ' ──────────────────────────────────────────────────────────
    Private Sub ClearFields()
        txtStoreName.Clear()
        txtNotes.Clear()
        txtSearch.Clear()
        chkIsDefault.Checked = False
        tgStatus.Checked = True
        lstSuggestions.Visible = False

        If _cachedStores IsNot Nothing Then
            If _isDeletedColumnExists Then
                _cachedStores.DefaultView.RowFilter = "(IsDeleted = 0 OR IsDeleted IS NULL)"
            Else
                _cachedStores.DefaultView.RowFilter = ""
            End If
        End If

        dgvStores.ClearSelection()
        GenerateNextStoreCode()
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 5. حدث تحميل الفورم
    ' ──────────────────────────────────────────────────────────
    Private Sub frmStores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("اسم المخزن")
        cmbSearchField.Items.Add("كود المخزن")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        datagridviewsetup(dgvStores)
        EnableDoubleBuffer(dgvStores)

        LoadStoresGrid()
        ClearFields()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 6. التحديد من الجريد وعرض البيانات بالصناديق
    ' ──────────────────────────────────────────────────────────
    Private Sub dgvStores_SelectionChanged(sender As Object, e As EventArgs) Handles dgvStores.SelectionChanged
        If dgvStores.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvStores.SelectedRows(0)

        If row.Cells("StoreID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("StoreID").Value) Then
            If _storeCodeColumnExists AndAlso dgvStores.Columns.Contains("StoreCode") AndAlso Not IsDBNull(row.Cells("StoreCode").Value) Then
                txtStoreCode.Text = row.Cells("StoreCode").Value.ToString()
            Else
                txtStoreCode.Text = row.Cells("StoreID").Value.ToString()
            End If

            If dgvStores.Columns.Contains("StoreName") AndAlso Not IsDBNull(row.Cells("StoreName").Value) Then
                txtStoreName.Text = row.Cells("StoreName").Value.ToString()
            Else
                txtStoreName.Clear()
            End If

            If dgvStores.Columns.Contains("IsDefault") AndAlso Not IsDBNull(row.Cells("IsDefault").Value) Then
                chkIsDefault.Checked = Convert.ToBoolean(row.Cells("IsDefault").Value)
            Else
                chkIsDefault.Checked = False
            End If

            If _notesColumnExists AndAlso dgvStores.Columns.Contains("Notes") AndAlso Not IsDBNull(row.Cells("Notes").Value) Then
                txtNotes.Text = row.Cells("Notes").Value.ToString()
            Else
                txtNotes.Clear()
            End If

            If _isActiveColumnExists AndAlso dgvStores.Columns.Contains("IsActive") AndAlso Not IsDBNull(row.Cells("IsActive").Value) Then
                tgStatus.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
            Else
                tgStatus.Checked = True
            End If
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 7. إضافة مخزن جديد
    ' ──────────────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        ' لو اخترنا المخزن ده افتراضي، بنلغي الافتراضي من بقية المخازن
        If chkIsDefault.Checked Then
            DBModule.ExecuteNonQuery("UPDATE Stores SET IsDefault = 0")
        End If

        ' بناء استعلام الإضافة ديناميكياً بناءً على العمود المتوفر
        Dim fields As String = "StoreName, IsDefault"
        Dim values As String = "@Name, @IsDefault"

        If _storeCodeColumnExists Then
            fields &= ", StoreCode"
            values &= ", @Code"
        End If
        If _notesColumnExists Then
            fields &= ", Notes"
            values &= ", @Notes"
        End If
        If _isActiveColumnExists Then
            fields &= ", IsActive"
            values &= ", @IsActive"
        End If
        If _isDeletedColumnExists Then
            fields &= ", IsDeleted"
            values &= ", 0"
        End If

        Dim query As String = $"INSERT INTO Stores ({fields}) VALUES ({values})"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Name", txtStoreName.Text.Trim())
                cmd.Parameters.AddWithValue("@IsDefault", chkIsDefault.Checked)

                If _storeCodeColumnExists Then
                    cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtStoreCode.Text), GetNextCode("Stores", "StoreCode").ToString(), txtStoreCode.Text.Trim()))
                End If
                If _notesColumnExists Then
                    cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                End If
                If _isActiveColumnExists Then
                    cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                End If

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تمت إضافة المخزن بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedStores = Nothing
                    LoadStoresGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الإضافة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 8. تعديل بيانات المخزن
    ' ──────────────────────────────────────────────────────────
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvStores.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد المخزن المراد تعديله من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvStores.SelectedRows(0).Cells("StoreID").Value)

        ' لو اخترنا المخزن ده افتراضي، بنلغي الافتراضي من بقية المخازن
        If chkIsDefault.Checked Then
            DBModule.ExecuteNonQuery($"UPDATE Stores SET IsDefault = 0 WHERE StoreID <> {currentID}")
        End If

        Dim setClause As String = "StoreName = @Name, IsDefault = @IsDefault"

        If _storeCodeColumnExists Then setClause &= ", StoreCode = @Code"
        If _notesColumnExists Then setClause &= ", Notes = @Notes"
        If _isActiveColumnExists Then setClause &= ", IsActive = @IsActive"

        Dim query As String = $"UPDATE Stores SET {setClause} WHERE StoreID = @StoreID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StoreID", currentID)
                cmd.Parameters.AddWithValue("@Name", txtStoreName.Text.Trim())
                cmd.Parameters.AddWithValue("@IsDefault", chkIsDefault.Checked)

                If _storeCodeColumnExists Then
                    cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtStoreCode.Text), DBNull.Value, txtStoreCode.Text.Trim()))
                End If
                If _notesColumnExists Then
                    cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                End If
                If _isActiveColumnExists Then
                    cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                End If

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل بيانات المخزن بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedStores = Nothing
                    LoadStoresGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 9. حذف المخزن (Soft Delete / Hard Delete مع الأمان)
    ' ──────────────────────────────────────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvStores.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد المخزن المراد حذفه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("هل أنت متأكد من حذف هذا المخزن؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvStores.SelectedRows(0).Cells("StoreID").Value)
            Dim query As String = ""

            If _isDeletedColumnExists Then
                query = "UPDATE Stores SET IsDeleted = 1 WHERE StoreID = @ID"
            Else
                query = "DELETE FROM Stores WHERE StoreID = @ID"
            End If

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف المخزن بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedStores = Nothing
                        LoadStoresGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("لا يمكن حذف هذا المخزن لارتباطه بعمليات أو خامات مسجلة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 10. زر تفريغ الحقول
    ' ──────────────────────────────────────────────────────────
    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 11. زر التحديث
    ' ──────────────────────────────────────────────────────────
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedStores = Nothing
        LoadStoresGrid()
        ClearFields()
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 12. البحث المباشر والفلترة الملساء في الجداول والتلميحات
    ' ──────────────────────────────────────────────────────────
    Private Sub ApplySearchFilter()
        If _cachedStores Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم المخزن")

        Dim baseFilter As String = If(_isDeletedColumnExists, "(IsDeleted = 0 OR IsDeleted IS NULL)", "")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedStores.DefaultView.RowFilter = baseFilter
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود المخزن"
                If _storeCodeColumnExists Then
                    filterExpr = $"StoreCode LIKE '%{safeKeyword}%'"
                Else
                    filterExpr = $"CONVERT(StoreID, 'System.String') LIKE '%{safeKeyword}%'"
                End If
            Case "اسم المخزن"
                filterExpr = $"StoreName LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                If _notesColumnExists Then
                    filterExpr = $"Notes LIKE '%{safeKeyword}%'"
                Else
                    filterExpr = $"StoreName LIKE '%{safeKeyword}%'"
                End If
            Case Else ' الكل
                Dim conditions As New List(Of String)
                conditions.Add($"StoreName LIKE '%{safeKeyword}%'")
                If _storeCodeColumnExists Then conditions.Add($"StoreCode LIKE '%{safeKeyword}%'")
                If _notesColumnExists Then conditions.Add($"Notes LIKE '%{safeKeyword}%'")
                filterExpr = String.Join(" OR ", conditions.ToArray())
        End Select

        If Not String.IsNullOrEmpty(baseFilter) Then
            filterExpr = $"({baseFilter}) AND ({filterExpr})"
        End If

        _cachedStores.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedStores Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "StoreName"
        Select Case field
            Case "كود المخزن"
                colName = If(_storeCodeColumnExists, "StoreCode", "StoreID")
            Case "ملاحظات"
                colName = If(_notesColumnExists, "Notes", "StoreName")
            Case Else
                colName = "StoreName"
        End Select

        Dim matches As New List(Of String)()
        For Each row As DataRow In _cachedStores.Rows
            ' استبعاد الصفوف المحذوفة من الاقتراحات
            If _isDeletedColumnExists AndAlso Not row.IsNull("IsDeleted") AndAlso Convert.ToBoolean(row("IsDeleted")) Then
                Continue For
            End If

            If Not row.IsNull(colName) Then
                Dim val As String = row(colName).ToString()
                If val.ToLower().Contains(keyword.ToLower()) AndAlso Not matches.Contains(val) Then
                    matches.Add(val)
                End If
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

            If dgvStores.Rows.Count > 0 Then
                dgvStores.ClearSelection()
                dgvStores.Rows(0).Selected = True
            End If
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 13. أزرار النافذة والإغلاق والتحريك
    ' ──────────────────────────────────────────────────────────
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub
End Class