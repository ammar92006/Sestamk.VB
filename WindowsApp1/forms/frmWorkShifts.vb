Imports System.Data.SqlClient

Public Class frmWorkShifts
    Private _cachedWorkShifts As DataTable = Nothing

    ' 1. دالة تحميل وجلب بيانات الورديات
    Private Sub LoadWorkShiftsGrid()
        Try
            If _cachedWorkShifts Is Nothing Then
                Dim query As String = "SELECT WorkShiftID, WorkShiftCode, WorkShiftName, StartTime, EndTime, Notes, IsActive " &
                                      "FROM WorkShifts WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY WorkShiftID DESC"
                _cachedWorkShifts = DBModule.ExecuteQuery(query)
            End If

            If _cachedWorkShifts Is Nothing Then Exit Sub

            dgvWorkShifts.DataSource = _cachedWorkShifts.DefaultView

            If dgvWorkShifts.Columns.Contains("WorkShiftID") Then dgvWorkShifts.Columns("WorkShiftID").Visible = False

            If dgvWorkShifts.Columns.Contains("WorkShiftCode") Then dgvWorkShifts.Columns("WorkShiftCode").HeaderText = "كود الوردية"
            If dgvWorkShifts.Columns.Contains("WorkShiftName") Then dgvWorkShifts.Columns("WorkShiftName").HeaderText = "اسم الوردية"
            If dgvWorkShifts.Columns.Contains("StartTime") Then dgvWorkShifts.Columns("StartTime").HeaderText = "وقت البدء"
            If dgvWorkShifts.Columns.Contains("EndTime") Then dgvWorkShifts.Columns("EndTime").HeaderText = "وقت الانتهاء"
            If dgvWorkShifts.Columns.Contains("Notes") Then dgvWorkShifts.Columns("Notes").HeaderText = "ملاحظات"
            If dgvWorkShifts.Columns.Contains("IsActive") Then dgvWorkShifts.Columns("IsActive").HeaderText = "نشط"
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل بيانات الورديات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. دالة التحقق من صحة المدخلات
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtWorkShiftName.Text) Then
            MessageBox.Show("يرجى كتابة اسم الوردية أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWorkShiftName.Focus()
            Return False
        End If
        Return True
    End Function

    ' 3. دالة تفريغ الحقول
    Private Sub ClearFields()
        txtWorkShiftCode.Clear()
        txtWorkShiftName.Clear()
        dtpStartTime.Value = DateTime.Today.AddHours(8)
        dtpEndTime.Value = DateTime.Today.AddHours(16)
        txtNotes.Clear()
        tgStatus.Checked = True
        dgvWorkShifts.ClearSelection()
        txtSearch.Clear()
        lstSuggestions.Visible = False
    End Sub

    ' 4. حدث تحميل الفورم
    Private Sub frmWorkShifts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        ' تعبئة قائمة البحث المتقدم بأسماء الأعمدة بالعربية
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("اسم الوردية")
        cmbSearchField.Items.Add("كود الوردية")
        cmbSearchField.Items.Add("وقت البدء")
        cmbSearchField.Items.Add("وقت الانتهاء")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        LoadWorkShiftsGrid()

        datagridviewsetup(dgvWorkShifts)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' 5. عرض البيانات عند تحديد صف من الجدول
    Private Sub dgvWorkShifts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvWorkShifts.SelectionChanged
        If dgvWorkShifts.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvWorkShifts.SelectedRows(0)

        If row.Cells("WorkShiftID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("WorkShiftID").Value) Then
            txtWorkShiftCode.Text = If(IsDBNull(row.Cells("WorkShiftCode").Value), "", row.Cells("WorkShiftCode").Value.ToString())
            txtWorkShiftName.Text = If(IsDBNull(row.Cells("WorkShiftName").Value), "", row.Cells("WorkShiftName").Value.ToString())

            If Not IsDBNull(row.Cells("StartTime").Value) Then
                If TypeOf row.Cells("StartTime").Value Is TimeSpan Then
                    Dim ts As TimeSpan = CType(row.Cells("StartTime").Value, TimeSpan)
                    dtpStartTime.Value = DateTime.Today.Add(ts)
                Else
                    Dim dt As DateTime
                    If DateTime.TryParse(row.Cells("StartTime").Value.ToString(), dt) Then
                        dtpStartTime.Value = dt
                    End If
                End If
            End If

            If Not IsDBNull(row.Cells("EndTime").Value) Then
                If TypeOf row.Cells("EndTime").Value Is TimeSpan Then
                    Dim ts As TimeSpan = CType(row.Cells("EndTime").Value, TimeSpan)
                    dtpEndTime.Value = DateTime.Today.Add(ts)
                Else
                    Dim dt As DateTime
                    If DateTime.TryParse(row.Cells("EndTime").Value.ToString(), dt) Then
                        dtpEndTime.Value = dt
                    End If
                End If
            End If

            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' 6. زر إضافة وردية جديدة
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO WorkShifts (WorkShiftCode, WorkShiftName, StartTime, EndTime, Notes, IsActive, IsDeleted, CreatedAt) " &
                              "VALUES (@Code, @Name, @StartTime, @EndTime, @Notes, @IsActive, 0, GETDATE())"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtWorkShiftCode.Text), DBNull.Value, txtWorkShiftCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtWorkShiftName.Text.Trim())
                cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = dtpStartTime.Value.TimeOfDay
                cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = dtpEndTime.Value.TimeOfDay
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ الوردية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedWorkShifts = Nothing
                    LoadWorkShiftsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. زر تعديل بيانات وردية
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvWorkShifts.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد الوردية المراد تعديلها من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvWorkShifts.SelectedRows(0).Cells("WorkShiftID").Value)
        Dim query As String = "UPDATE WorkShifts SET WorkShiftCode = @Code, WorkShiftName = @Name, StartTime = @StartTime, " &
                              "EndTime = @EndTime, Notes = @Notes, IsActive = @IsActive WHERE WorkShiftID = @WorkShiftID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@WorkShiftID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtWorkShiftCode.Text), DBNull.Value, txtWorkShiftCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtWorkShiftName.Text.Trim())
                cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = dtpStartTime.Value.TimeOfDay
                cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = dtpEndTime.Value.TimeOfDay
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل الوردية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedWorkShifts = Nothing
                    LoadWorkShiftsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    ' 8. زر الحذف الناعم (Soft Delete)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvWorkShifts.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد الوردية المراد حذفها من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("هل أنت متأكد من حذف هذه الوردية؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvWorkShifts.SelectedRows(0).Cells("WorkShiftID").Value)
            Dim query As String = "UPDATE WorkShifts SET IsDeleted = 1 WHERE WorkShiftID = @WorkShiftID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@WorkShiftID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الوردية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedWorkShifts = Nothing
                        LoadWorkShiftsGrid()
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
        _cachedWorkShifts = Nothing
        LoadWorkShiftsGrid()
        ClearFields()
    End Sub
    ' 10. البحث المتقدم وتوليد الاقتراحات
    Private Sub ApplySearchFilter()
        If _cachedWorkShifts Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم الوردية")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedWorkShifts.DefaultView.RowFilter = ""
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود الوردية"
                filterExpr = $"WorkShiftCode LIKE '%{safeKeyword}%'"
            Case "اسم الوردية"
                filterExpr = $"WorkShiftName LIKE '%{safeKeyword}%'"
            Case "وقت البدء"
                filterExpr = $"CONVERT(StartTime, 'System.String') LIKE '%{safeKeyword}%'"
            Case "وقت الانتهاء"
                filterExpr = $"CONVERT(EndTime, 'System.String') LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                filterExpr = $"Notes LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"WorkShiftName LIKE '%{safeKeyword}%' OR WorkShiftCode LIKE '%{safeKeyword}%' OR Notes LIKE '%{safeKeyword}%' OR CONVERT(StartTime, 'System.String') LIKE '%{safeKeyword}%' OR CONVERT(EndTime, 'System.String') LIKE '%{safeKeyword}%'"
        End Select

        _cachedWorkShifts.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub
    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedWorkShifts Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "WorkShiftName"
        Select Case field
            Case "كود الوردية"
                colName = "WorkShiftCode"
            Case "وقت البدء"
                colName = "StartTime"
            Case "وقت الانتهاء"
                colName = "EndTime"
            Case "ملاحظات"
                colName = "Notes"
            Case Else
                colName = "WorkShiftName"
        End Select

        Dim matches As New List(Of String)()
        For Each row As DataRow In _cachedWorkShifts.Rows
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

            If dgvWorkShifts.Rows.Count > 0 Then
                dgvWorkShifts.ClearSelection()
                dgvWorkShifts.Rows(0).Selected = True
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