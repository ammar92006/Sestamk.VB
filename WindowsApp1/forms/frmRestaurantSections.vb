Imports System.Data.SqlClient

Public Class frmRestaurantSections
    Private _cachedSections As DataTable = Nothing

    ' 1. دالة تحميل وجلب بيانات أقسام / أدوار المطعم
    Private Sub LoadSectionsGrid()
        Try
            If _cachedSections Is Nothing Then
                Dim query As String = "SELECT SectionID, SectionCode, SectionName, TablesCount, Notes, IsActive " &
                                      "FROM RestaurantSections WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY SectionID DESC"
                _cachedSections = DBModule.ExecuteQuery(query)
            End If

            If _cachedSections Is Nothing Then Exit Sub

            dgvRestaurantSections.DataSource = _cachedSections

            If dgvRestaurantSections.Columns.Contains("SectionID") Then dgvRestaurantSections.Columns("SectionID").Visible = False

            If dgvRestaurantSections.Columns.Contains("SectionCode") Then dgvRestaurantSections.Columns("SectionCode").HeaderText = "كود القسم"
            If dgvRestaurantSections.Columns.Contains("SectionName") Then dgvRestaurantSections.Columns("SectionName").HeaderText = "اسم القسم / الدور"
            If dgvRestaurantSections.Columns.Contains("TablesCount") Then dgvRestaurantSections.Columns("TablesCount").HeaderText = "عدد الطاولات"
            If dgvRestaurantSections.Columns.Contains("Notes") Then dgvRestaurantSections.Columns("Notes").HeaderText = "ملاحظات"
            If dgvRestaurantSections.Columns.Contains("IsActive") Then dgvRestaurantSections.Columns("IsActive").HeaderText = "نشط"
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل بيانات أقسام المطعم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. دالة التحقق من صحة المدخلات
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtSectionName.Text) Then
            MessageBox.Show("يرجى كتابة اسم القسم أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSectionName.Focus()
            Return False
        End If
        Return True
    End Function

    ' 3. دالة تفريغ الحقول
    Private Sub ClearFields()
        txtSectionCode.Clear()
        txtSectionName.Clear()
        txtNotes.Clear()
        tgStatus.Checked = True
        dgvRestaurantSections.ClearSelection()
        txtSearch.Clear()
        lstSuggestions.Visible = False
    End Sub

    ' 4. حدث تحميل الفورم
    Private Sub frmRestaurantSections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        ' تعبئة قائمة البحث المتقدم بأسماء الأعمدة بالعربية
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("اسم القسم")
        cmbSearchField.Items.Add("كود القسم")
        cmbSearchField.Items.Add("عدد الطاولات")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        datagridviewsetup(dgvRestaurantSections)
        LoadSectionsGrid()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' 5. عرض البيانات عند تحديد صف من الجدول
    Private Sub dgvRestaurantSections_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRestaurantSections.SelectionChanged
        If dgvRestaurantSections.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvRestaurantSections.SelectedRows(0)

        If row.Cells("SectionID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("SectionID").Value) Then
            txtSectionCode.Text = If(IsDBNull(row.Cells("SectionCode").Value), "", row.Cells("SectionCode").Value.ToString())
            txtSectionName.Text = If(IsDBNull(row.Cells("SectionName").Value), "", row.Cells("SectionName").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' 6. زر إضافة قسم جديد
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO RestaurantSections (SectionCode, SectionName, TablesCount, Notes, IsActive, IsDeleted, CreatedAt) " &
                              "VALUES (@Code, @Name, 0, @Notes, @IsActive, 0, GETDATE())"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtSectionCode.Text), DBNull.Value, txtSectionCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtSectionName.Text.Trim())
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ القسم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedSections = Nothing
                    LoadSectionsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. زر تعديل بيانات قسم
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvRestaurantSections.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد القسم المراد تعديله من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvRestaurantSections.SelectedRows(0).Cells("SectionID").Value)
        Dim query As String = "UPDATE RestaurantSections SET SectionCode = @Code, SectionName = @Name, Notes = @Notes, " &
                              "IsActive = @IsActive WHERE SectionID = @SectionID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SectionID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtSectionCode.Text), DBNull.Value, txtSectionCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtSectionName.Text.Trim())
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل القسم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedSections = Nothing
                    LoadSectionsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 8. زر الحذف الناعم (Soft Delete)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvRestaurantSections.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد القسم المراد حذفه من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("هل أنت متأكد من حذف هذا القسم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvRestaurantSections.SelectedRows(0).Cells("SectionID").Value)
            Dim query As String = "UPDATE RestaurantSections SET IsDeleted = 1 WHERE SectionID = @SectionID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@SectionID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف القسم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedSections = Nothing
                        LoadSectionsGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' 9. تفريغ الحقول وتحديث البيانات
    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedSections = Nothing
        LoadSectionsGrid()
        ClearFields()
    End Sub

    ' 10. البحث المتقدم وتوليد الاقتراحات
    Private Sub ApplySearchFilter()
        If _cachedSections Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم القسم")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedSections.DefaultView.RowFilter = ""
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود القسم"
                filterExpr = $"SectionCode LIKE '%{safeKeyword}%'"
            Case "اسم القسم"
                filterExpr = $"SectionName LIKE '%{safeKeyword}%'"
            Case "عدد الطاولات"
                filterExpr = $"CONVERT(TablesCount, 'System.String') LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                filterExpr = $"Notes LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"SectionName LIKE '%{safeKeyword}%' OR SectionCode LIKE '%{safeKeyword}%' OR Notes LIKE '%{safeKeyword}%' OR CONVERT(TablesCount, 'System.String') LIKE '%{safeKeyword}%'"
        End Select

        _cachedSections.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedSections Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "SectionName"
        Select Case field
            Case "كود القسم"
                colName = "SectionCode"
            Case "عدد الطاولات"
                colName = "TablesCount"
            Case "ملاحظات"
                colName = "Notes"
            Case Else
                colName = "SectionName"
        End Select

        Dim matches As New List(Of String)()
        For Each row As DataRow In _cachedSections.Rows
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

            If dgvRestaurantSections.Rows.Count > 0 Then
                dgvRestaurantSections.ClearSelection()
                dgvRestaurantSections.Rows(0).Selected = True
            End If
        End If
    End Sub

    ' 11. أزرار التحكم بالنافذة (إغلاق / تصغير / تكبير)
    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class