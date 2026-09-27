Imports System.Data.SqlClient

Public Class frmRestaurantTables

    Private _cachedTables As DataTable = Nothing

    ' 1. ملء قائمة أقسام المطعم
    Private Sub FillSectionsDropdown()
        Try
            Dim dt As DataTable = DBModule.ExecuteQuery("SELECT SectionID, SectionName FROM RestaurantSections WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL)")
            If dt IsNot Nothing Then
                cmbSection.DataSource = dt
                cmbSection.DisplayMember = "SectionName"
                cmbSection.ValueMember = "SectionID"
                cmbSection.SelectedIndex = -1
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading sections: " & ex.Message)
        End Try
    End Sub

    ' 2. زر الـ + الصغير لفتح فورم الأقسام فرعياً وتحديث القائمة تلقائياً
    Private Sub btnAddSectionForm_Click(sender As Object, e As EventArgs) Handles btnAddSectionForm.Click
        Dim frm As New frmRestaurantSections()
        frm.ShowDialog()
        FillSectionsDropdown()
    End Sub

    ' 3. تحميل وتصفية الطاولات في الجدول
    Private Sub LoadTablesGrid(Optional sectionID As Integer? = Nothing)
        Try
            Dim query As String = "SELECT T.TableID, T.TableNumber, T.TableName, T.SectionID, S.SectionName, " &
                                  "T.ChairsCount, T.TableStatus, T.Notes, T.IsActive " &
                                  "FROM RestaurantTables T " &
                                  "INNER JOIN RestaurantSections S ON T.SectionID = S.SectionID " &
                                  "WHERE (T.IsDeleted = 0 OR T.IsDeleted IS NULL)"

            If sectionID.HasValue AndAlso sectionID.Value > 0 Then
                query &= $" AND T.SectionID = {sectionID.Value}"
            End If

            query &= " ORDER BY S.SectionName ASC, T.TableNumber ASC"

            Dim dt As DataTable = DBModule.ExecuteQuery(query)
            _cachedTables = dt
            If dt IsNot Nothing Then
                dgvTables.DataSource = dt.DefaultView

                If dgvTables.Columns.Contains("TableID") Then dgvTables.Columns("TableID").Visible = False
                If dgvTables.Columns.Contains("SectionID") Then dgvTables.Columns("SectionID").Visible = False

                If dgvTables.Columns.Contains("TableNumber") Then dgvTables.Columns("TableNumber").HeaderText = "كود/رقم الطاولة"
                If dgvTables.Columns.Contains("TableName") Then dgvTables.Columns("TableName").HeaderText = "اسم الطاولة"
                If dgvTables.Columns.Contains("SectionName") Then dgvTables.Columns("SectionName").HeaderText = "القسم / الدور"
                If dgvTables.Columns.Contains("ChairsCount") Then dgvTables.Columns("ChairsCount").HeaderText = "عدد المقاعد"
                If dgvTables.Columns.Contains("TableStatus") Then dgvTables.Columns("TableStatus").HeaderText = "الحالة"
                If dgvTables.Columns.Contains("Notes") Then dgvTables.Columns("Notes").HeaderText = "ملاحظات"
                If dgvTables.Columns.Contains("IsActive") Then dgvTables.Columns("IsActive").HeaderText = "نشط"
                dgvTables.ClearSelection()
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل بيانات الطاولات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 4. تفريغ الحقول
    Private Sub ClearFields(Optional preserveSection As Boolean = False)
        txtTableNumber.Text = GetNextCode("RestaurantTables", "TableNumber").ToString()
        txtTableName.Clear()
        If Not preserveSection Then cmbSection.SelectedIndex = -1
        txtChairsCount.Text = "4"
        txtNotes.Clear()
        txtSearch.Clear()
        lstSuggestions.Visible = False
        tgStatus.Checked = True
        dgvTables.ClearSelection()
    End Sub

    ' 5. التحقق من صحة البيانات
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtTableNumber.Text) OrElse cmbSection.SelectedIndex = -1 Then
            MessageBox.Show("يرجى إدخال رقم الطاولة وااختيار القسم أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    ' 6. حدث تحميل الفورم
    Private Sub frmRestaurantTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        ' تعبئة قائمة الأعمدة بالعربية للبحث المتقدم
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("اسم الطاولة")
        cmbSearchField.Items.Add("كود الطاولة")
        cmbSearchField.Items.Add("القسم / الدور")
        cmbSearchField.Items.Add("عدد المقاعد")
        cmbSearchField.Items.Add("الحالة")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        FillSectionsDropdown()
        datagridviewsetup(dgvTables)
        LoadTablesGrid()
        ClearFields()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' 7. حدث اختيار صف من الجدول
    Private Sub dgvTables_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTables.SelectionChanged
        If dgvTables.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvTables.SelectedRows(0)

        If row.Cells("TableID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("TableID").Value) Then
            txtTableNumber.Text = If(IsDBNull(row.Cells("TableNumber").Value), "", row.Cells("TableNumber").Value.ToString())
            txtTableName.Text = If(IsDBNull(row.Cells("TableName").Value), "", row.Cells("TableName").Value.ToString())
            txtChairsCount.Text = If(IsDBNull(row.Cells("ChairsCount").Value), "4", row.Cells("ChairsCount").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())

            If Not IsDBNull(row.Cells("SectionID").Value) Then cmbSection.SelectedValue = row.Cells("SectionID").Value
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' 8. زر إضافة طاولة جديدة
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO RestaurantTables " &
                              "(TableNumber, TableName, SectionID, ChairsCount, Notes, IsActive) " &
                              "VALUES (@TableNumber, @TableName, @SectionID, @ChairsCount, @Notes, @IsActive)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@TableNumber", If(String.IsNullOrEmpty(txtTableNumber.Text), GetNextCode("RestaurantTables", "TableNumber").ToString(), txtTableNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@TableName", txtTableName.Text.Trim())
                cmd.Parameters.AddWithValue("@SectionID", If(cmbSection.SelectedValue Is Nothing, DBNull.Value, cmbSection.SelectedValue))
                cmd.Parameters.AddWithValue("@ChairsCount", If(String.IsNullOrEmpty(txtChairsCount.Text), DBNull.Value, txtChairsCount.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ الطاولة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedTables = Nothing
                    LoadTablesGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 9. زر تعديل بيانات طاولة
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvTables.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvTables.SelectedRows(0).Cells("TableID").Value)
        Dim query As String = "UPDATE RestaurantTables SET " &
                              "TableNumber = @TableNumber, " &
                              "TableName = @TableName, " &
                              "SectionID = @SectionID, " &
                              "ChairsCount = @ChairsCount, " &
                              "Notes = @Notes, " &
                              "IsActive = @IsActive " &
                              "WHERE TableID = @TableID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@TableNumber", If(String.IsNullOrEmpty(txtTableNumber.Text), DBNull.Value, txtTableNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@TableName", txtTableName.Text.Trim())
                cmd.Parameters.AddWithValue("@SectionID", If(cmbSection.SelectedValue Is Nothing, DBNull.Value, cmbSection.SelectedValue))
                cmd.Parameters.AddWithValue("@ChairsCount", If(String.IsNullOrEmpty(txtChairsCount.Text), DBNull.Value, txtChairsCount.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                cmd.Parameters.AddWithValue("@TableID", currentID)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل الطاولة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedTables = Nothing
                    LoadTablesGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 10. زر حذف طاولة (Soft Delete)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvTables.SelectedRows.Count = 0 Then Exit Sub

        If MessageBox.Show("هل أنت متأكد من حذف هذه الطاولة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvTables.SelectedRows(0).Cells("TableID").Value)
            Dim query As String = "UPDATE RestaurantTables SET IsDeleted = 1 WHERE TableID = @TableID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@TableID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الطاولة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedTables = Nothing
                        LoadTablesGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' 11. تفريغ الحقول وتحديث البيانات
    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedTables = Nothing
        LoadTablesGrid()
        ClearFields()
    End Sub

    ' 12. البحث المتقدم وتوليد الاقتراحات
    Private Sub ApplySearchFilter()
        If _cachedTables Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم الطاولة")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedTables.DefaultView.RowFilter = ""
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود الطاولة"
                filterExpr = $"TableNumber LIKE '%{safeKeyword}%'"
            Case "اسم الطاولة"
                filterExpr = $"TableName LIKE '%{safeKeyword}%'"
            Case "القسم / الدور"
                filterExpr = $"SectionName LIKE '%{safeKeyword}%'"
            Case "عدد المقاعد"
                filterExpr = $"CONVERT(ChairsCount, 'System.String') LIKE '%{safeKeyword}%'"
            Case "الحالة"
                filterExpr = $"CONVERT(TableStatus, 'System.String') LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                filterExpr = $"Notes LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"TableName LIKE '%{safeKeyword}%' OR TableNumber LIKE '%{safeKeyword}%' OR SectionName LIKE '%{safeKeyword}%' OR Notes LIKE '%{safeKeyword}%' OR CONVERT(ChairsCount, 'System.String') LIKE '%{safeKeyword}%'"
        End Select

        _cachedTables.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedTables Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "TableName"
        Select Case field
            Case "كود الطاولة"
                colName = "TableNumber"
            Case "القسم / الدور"
                colName = "SectionName"
            Case "عدد المقاعد"
                colName = "ChairsCount"
            Case "الحالة"
                colName = "TableStatus"
            Case "ملاحظات"
                colName = "Notes"
            Case Else
                colName = "TableName"
        End Select

        Dim matches As New List(Of String)()
        For Each row As DataRow In _cachedTables.Rows
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

            If dgvTables.Rows.Count > 0 Then
                dgvTables.ClearSelection()
                dgvTables.Rows(0).Selected = True
            End If
        End If
    End Sub

    ' 13. أزرار النافذة (إغلاق / تصغير / تكبير)
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click, SimpleButton3.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click, SimpleButton2.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click, SimpleButton1.Click
        FormHelper.Minimiz(Me)
    End Sub

End Class