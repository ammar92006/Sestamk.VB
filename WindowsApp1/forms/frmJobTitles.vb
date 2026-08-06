Imports System.Data.SqlClient

Public Class frmJobTitles
    Private _cachedJobs As DataTable = Nothing

    Private Sub FillDepartments()
        Dim dt As DataTable = DBModule.ExecuteQuery("SELECT DepartmentID, DepartmentName FROM Departments WHERE IsDeleted = 0")
        If dt IsNot Nothing Then
            cmbDepartment.DataSource = dt
            cmbDepartment.DisplayMember = "DepartmentName"
            cmbDepartment.ValueMember = "DepartmentID"
            cmbDepartment.SelectedIndex = -1
        End If
    End Sub

    Private Sub LoadGrid()
        Try
            If _cachedJobs Is Nothing Then
                Dim query As String = "SELECT J.JobTitleID, J.JobTitleCode, J.JobTitleName, J.Notes, J.IsActive, J.DepartmentID, D.DepartmentName " &
                                      "FROM JobTitles J LEFT JOIN Departments D ON J.DepartmentID = D.DepartmentID WHERE J.IsDeleted = 0"
                _cachedJobs = DBModule.ExecuteQuery(query)
            End If

            If _cachedJobs Is Nothing Then Exit Sub
            dgvJobTitles.DataSource = _cachedJobs

            If dgvJobTitles.Columns.Contains("JobTitleID") Then dgvJobTitles.Columns("JobTitleID").Visible = False
            If dgvJobTitles.Columns.Contains("DepartmentID") Then dgvJobTitles.Columns("DepartmentID").Visible = False

            dgvJobTitles.Columns("JobTitleCode").HeaderText = "كود الوظيفة"
            dgvJobTitles.Columns("JobTitleName").HeaderText = "المسمى الوظيفي"
            dgvJobTitles.Columns("DepartmentName").HeaderText = "القسم التابع له"
            dgvJobTitles.Columns("Notes").HeaderText = "ملاحظات"
            dgvJobTitles.Columns("IsActive").HeaderText = "نشط"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtJobTitleName.Text) Then
            MessageBox.Show("يرجى إدخال المسمى الوظيفي!") : Return False
        End If
        If cmbDepartment.SelectedIndex = -1 Then
            MessageBox.Show("يرجى تحديد القسم التابع له الوظيفة!") : Return False
        End If
        Return True
    End Function

    Private Sub ClearFields()
        txtJobTitleCode.Clear()
        txtJobTitleName.Clear()
        txtNotes.Clear()
        cmbDepartment.SelectedIndex = -1
        tgStatus.Checked = True
        dgvJobTitles.ClearSelection()
    End Sub

    Private Sub frmJobTitles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            txtJobTitleCode.Text = row.Cells("JobTitleCode").Value.ToString()
            txtJobTitleName.Text = row.Cells("JobTitleName").Value.ToString()
            txtNotes.Text = row.Cells("Notes").Value.ToString()
            tgStatus.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
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
                    MessageBox.Show("تم الحفظ بنجاح")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Using
        End Using
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