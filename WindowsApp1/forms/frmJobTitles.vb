Imports System.Data.SqlClient

Public Class frmJobTitles
    Private _cachedJobs As DataTable = Nothing

    Private Sub FillDepartments()
        Dim dt As DataTable = DBModule.ExecuteQuery("SELECT DepartmentID, DepartmentName FROM Departments WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY DepartmentName ASC")
        If dt IsNot Nothing Then
            cmbDepartment.DataSource = dt
            cmbDepartment.DisplayMember = "DepartmentName"
            cmbDepartment.ValueMember = "DepartmentID"
            cmbDepartment.SelectedIndex = -1
        End If
    End Sub

    Private Sub LoadGrid()
        Try
            Dim query As String = "SELECT J.JobTitleID, J.JobTitleCode, J.JobTitleName, J.Notes, J.IsActive, J.DepartmentID, D.DepartmentName " &
                                  "FROM JobTitles J LEFT JOIN Departments D ON J.DepartmentID = D.DepartmentID WHERE J.IsDeleted = 0 OR J.IsDeleted IS NULL ORDER BY J.JobTitleName ASC"
            Dim dt As DataTable = DBModule.ExecuteQuery(query)
            _cachedJobs = dt

            If dt IsNot Nothing Then
                dgvJobTitles.DataSource = dt.DefaultView

                If dgvJobTitles.Columns.Contains("JobTitleID") Then dgvJobTitles.Columns("JobTitleID").Visible = False
                If dgvJobTitles.Columns.Contains("DepartmentID") Then dgvJobTitles.Columns("DepartmentID").Visible = False

                If dgvJobTitles.Columns.Contains("JobTitleCode") Then dgvJobTitles.Columns("JobTitleCode").HeaderText = "كود الوظيفة"
                If dgvJobTitles.Columns.Contains("JobTitleName") Then dgvJobTitles.Columns("JobTitleName").HeaderText = "المسمى الوظيفي"
                If dgvJobTitles.Columns.Contains("DepartmentName") Then dgvJobTitles.Columns("DepartmentName").HeaderText = "القسم التابع له"
                If dgvJobTitles.Columns.Contains("Notes") Then dgvJobTitles.Columns("Notes").HeaderText = "ملاحظات"
                If dgvJobTitles.Columns.Contains("IsActive") Then dgvJobTitles.Columns("IsActive").HeaderText = "نشط"

                dgvJobTitles.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل المسميات الوظيفية: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtJobTitleName.Text) Then
            MessageBox.Show("يرجى إدخال المسمى الوظيفي!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cmbDepartment.SelectedIndex = -1 Then
            MessageBox.Show("يرجى تحديد القسم التابع له الوظيفة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub ClearFields()
        txtJobTitleCode.Clear()
        txtJobTitleName.Clear()
        txtNotes.Clear()
        txtSearch.Clear()
        lstSuggestions.Visible = False
        cmbDepartment.SelectedIndex = -1
        tgStatus.Checked = True
        dgvJobTitles.ClearSelection()
    End Sub

    Private Sub frmJobTitles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("المسمى الوظيفي")
        cmbSearchField.Items.Add("كود الوظيفة")
        cmbSearchField.Items.Add("القسم التابع له")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        FillDepartments()
        LoadGrid()
        datagridviewsetup(dgvJobTitles)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub dgvJobTitles_SelectionChanged(sender As Object, e As EventArgs) Handles dgvJobTitles.SelectionChanged
        If dgvJobTitles.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvJobTitles.SelectedRows(0)
        If row.Cells("JobTitleID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("JobTitleID").Value) Then
            txtJobTitleCode.Text = If(IsDBNull(row.Cells("JobTitleCode").Value), "", row.Cells("JobTitleCode").Value.ToString())
            txtJobTitleName.Text = If(IsDBNull(row.Cells("JobTitleName").Value), "", row.Cells("JobTitleName").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
            If Not IsDBNull(row.Cells("DepartmentID").Value) Then cmbDepartment.SelectedValue = row.Cells("DepartmentID").Value Else cmbDepartment.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub
        Dim query As String = "INSERT INTO JobTitles (JobTitleCode, JobTitleName, DepartmentID, Notes, IsActive, IsDeleted) VALUES (@Code, @Name, @DeptID, @Notes, @IsActive, 0)"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtJobTitleCode.Text), DBNull.Value, txtJobTitleCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtJobTitleName.Text.Trim())
                cmd.Parameters.AddWithValue("@DeptID", cmbDepartment.SelectedValue)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    _cachedJobs = Nothing
                    LoadGrid()
                    ClearFields()
                    MessageBox.Show("تم حفظ الوظيفة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvJobTitles.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvJobTitles.SelectedRows(0).Cells("JobTitleID").Value)
        Dim query As String = "UPDATE JobTitles SET JobTitleCode=@Code, JobTitleName=@Name, DepartmentID=@DeptID, Notes=@Notes, IsActive=@IsActive WHERE JobTitleID=@ID"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtJobTitleCode.Text), DBNull.Value, txtJobTitleCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtJobTitleName.Text.Trim())
                cmd.Parameters.AddWithValue("@DeptID", cmbDepartment.SelectedValue)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    _cachedJobs = Nothing
                    LoadGrid()
                    ClearFields()
                    MessageBox.Show("تم تعديل الوظيفة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvJobTitles.SelectedRows.Count = 0 Then Exit Sub
        If MessageBox.Show("هل أنت متأكد من حذف هذه الوظيفة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvJobTitles.SelectedRows(0).Cells("JobTitleID").Value)
            Dim query As String = "UPDATE JobTitles SET IsDeleted = 1 WHERE JobTitleID = @ID"
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الوظيفة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedJobs = Nothing
                        LoadGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedJobs = Nothing
        LoadGrid()
        ClearFields()
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' البحث المتقدم والفلترة المباشرة وقائمة الاقتراحات
    ' ──────────────────────────────────────────────────────────
    Private Sub ApplySearchFilter()
        If _cachedJobs Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "المسمى الوظيفي")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedJobs.DefaultView.RowFilter = ""
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود الوظيفة"
                filterExpr = $"JobTitleCode LIKE '%{safeKeyword}%'"
            Case "المسمى الوظيفي"
                filterExpr = $"JobTitleName LIKE '%{safeKeyword}%'"
            Case "القسم التابع له"
                filterExpr = $"DepartmentName LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                filterExpr = $"Notes LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"JobTitleName LIKE '%{safeKeyword}%' OR JobTitleCode LIKE '%{safeKeyword}%' OR DepartmentName LIKE '%{safeKeyword}%' OR Notes LIKE '%{safeKeyword}%'"
        End Select

        _cachedJobs.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedJobs Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "JobTitleName"
        Select Case field
            Case "كود الوظيفة"
                colName = "JobTitleCode"
            Case "القسم التابع له"
                colName = "DepartmentName"
            Case "ملاحظات"
                colName = "Notes"
            Case Else
                colName = "JobTitleName"
        End Select

        Dim matches As New System.Collections.Generic.List(Of String)()
        For Each row As DataRow In _cachedJobs.Rows
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

            If dgvJobTitles.Rows.Count > 0 Then
                dgvJobTitles.ClearSelection()
                dgvJobTitles.Rows(0).Selected = True
            End If
        End If
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

End Class