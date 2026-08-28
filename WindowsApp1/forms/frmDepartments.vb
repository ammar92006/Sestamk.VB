Imports System.Data.SqlClient

Public Class frmDepartments
    Private _cachedDepts As DataTable = Nothing

    Private Sub LoadGrid()
        Try
            Dim query As String = "SELECT DepartmentID, DepartmentCode, DepartmentName, Notes, IsActive FROM Departments WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY DepartmentName ASC"
            Dim dt As DataTable = DBModule.ExecuteQuery(query)
            _cachedDepts = dt

            If dt IsNot Nothing Then
                dgvDepartments.DataSource = dt.DefaultView

                If dgvDepartments.Columns.Contains("DepartmentID") Then dgvDepartments.Columns("DepartmentID").Visible = False
                If dgvDepartments.Columns.Contains("DepartmentCode") Then dgvDepartments.Columns("DepartmentCode").HeaderText = "كود القسم"
                If dgvDepartments.Columns.Contains("DepartmentName") Then dgvDepartments.Columns("DepartmentName").HeaderText = "اسم القسم"
                If dgvDepartments.Columns.Contains("Notes") Then dgvDepartments.Columns("Notes").HeaderText = "ملاحظات"
                If dgvDepartments.Columns.Contains("IsActive") Then dgvDepartments.Columns("IsActive").HeaderText = "نشط"

                dgvDepartments.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل الأقسام: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtDepartmentName.Text) Then
            MessageBox.Show("عذراً، يجب إدخال اسم القسم أولاً!", "تنبيه الـ Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDepartmentName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ClearFields()
        txtDepartmentCode.Clear()
        txtDepartmentName.Clear()
        txtNotes.Clear()
        txtSearch.Clear()
        lstSuggestions.Visible = False
        tgStatus.Checked = True
        dgvDepartments.ClearSelection()
    End Sub

    Private Sub frmDepartments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("اسم القسم")
        cmbSearchField.Items.Add("كود القسم")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        datagridviewsetup(dgvDepartments)
        LoadGrid()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub dgvDepartments_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDepartments.SelectionChanged
        If dgvDepartments.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvDepartments.SelectedRows(0)
        If row.Cells("DepartmentID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DepartmentID").Value) Then
            txtDepartmentCode.Text = If(IsDBNull(row.Cells("DepartmentCode").Value), "", row.Cells("DepartmentCode").Value.ToString())
            txtDepartmentName.Text = If(IsDBNull(row.Cells("DepartmentName").Value), "", row.Cells("DepartmentName").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub
        Dim query As String = "INSERT INTO Departments (DepartmentCode, DepartmentName, Notes, IsActive, IsDeleted) VALUES (@Code, @Name, @Notes, @IsActive, 0)"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtDepartmentCode.Text), DBNull.Value, txtDepartmentCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtDepartmentName.Text.Trim())
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    _cachedDepts = Nothing
                    LoadGrid()
                    ClearFields()
                    MessageBox.Show("تم حفظ القسم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvDepartments.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvDepartments.SelectedRows(0).Cells("DepartmentID").Value)
        Dim query As String = "UPDATE Departments SET DepartmentCode=@Code, DepartmentName=@Name, Notes=@Notes, IsActive=@IsActive WHERE DepartmentID=@ID"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtDepartmentCode.Text), DBNull.Value, txtDepartmentCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtDepartmentName.Text.Trim())
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    _cachedDepts = Nothing
                    LoadGrid()
                    ClearFields()
                    MessageBox.Show("تم تعديل القسم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvDepartments.SelectedRows.Count = 0 Then Exit Sub
        If MessageBox.Show("هل أنت متأكد من حذف هذا القسم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvDepartments.SelectedRows(0).Cells("DepartmentID").Value)
            Dim query As String = "UPDATE Departments SET IsDeleted = 1 WHERE DepartmentID = @ID"
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف القسم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedDepts = Nothing
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
        _cachedDepts = Nothing
        LoadGrid()
        ClearFields()
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' البحث المتقدم والفلترة المباشرة وقائمة الاقتراحات
    ' ──────────────────────────────────────────────────────────
    Private Sub ApplySearchFilter()
        If _cachedDepts Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم القسم")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedDepts.DefaultView.RowFilter = ""
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود القسم"
                filterExpr = $"DepartmentCode LIKE '%{safeKeyword}%'"
            Case "اسم القسم"
                filterExpr = $"DepartmentName LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                filterExpr = $"Notes LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"DepartmentName LIKE '%{safeKeyword}%' OR DepartmentCode LIKE '%{safeKeyword}%' OR Notes LIKE '%{safeKeyword}%'"
        End Select

        _cachedDepts.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedDepts Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "DepartmentName"
        Select Case field
            Case "كود القسم"
                colName = "DepartmentCode"
            Case "ملاحظات"
                colName = "Notes"
            Case Else
                colName = "DepartmentName"
        End Select

        Dim matches As New System.Collections.Generic.List(Of String)()
        For Each row As DataRow In _cachedDepts.Rows
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

            If dgvDepartments.Rows.Count > 0 Then
                dgvDepartments.ClearSelection()
                dgvDepartments.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub
End Class