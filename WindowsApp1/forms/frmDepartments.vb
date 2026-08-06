Imports System.Data.SqlClient

Public Class frmDepartments
    Private _cachedDepts As DataTable = Nothing
    Dim x, y As Integer
    Dim newpoint As New Point

    Private Sub LoadGrid(Optional filter As String = "", Optional field As String = "")
        Try
            If _cachedDepts Is Nothing OrElse (filter = "" AndAlso field = "") Then
                Dim query As String = "SELECT DepartmentID, DepartmentCode, DepartmentName, Notes, IsActive FROM Departments WHERE IsDeleted = 0"
                _cachedDepts = DBModule.ExecuteQuery(query)
            End If

            If _cachedDepts Is Nothing Then Exit Sub
            dgvDepartments.DataSource = _cachedDepts

            If dgvDepartments.Columns.Contains("DepartmentID") Then dgvDepartments.Columns("DepartmentID").Visible = False
            dgvDepartments.Columns("DepartmentCode").HeaderText = "كود القسم"
            dgvDepartments.Columns("DepartmentName").HeaderText = "اسم القسم"
            dgvDepartments.Columns("Notes").HeaderText = "ملاحظات"
            dgvDepartments.Columns("IsActive").HeaderText = "نشط"
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل الأقسام: " & ex.Message)
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
        tgStatus.Checked = True
        dgvDepartments.ClearSelection()
    End Sub

    Private Sub frmDepartments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
        datagridviewsetup(dgvDepartments)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub dgvDepartments_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDepartments.SelectionChanged
        If dgvDepartments.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvDepartments.SelectedRows(0)
        If row.Cells("DepartmentID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DepartmentID").Value) Then
            txtDepartmentCode.Text = row.Cells("DepartmentCode").Value.ToString()
            txtDepartmentName.Text = row.Cells("DepartmentName").Value.ToString()
            txtNotes.Text = row.Cells("Notes").Value.ToString()
            tgStatus.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
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
                    conn.Open() : cmd.ExecuteNonQuery()
                    _cachedDepts = Nothing : LoadGrid() : ClearFields()
                    MessageBox.Show("تم حفظ القسم بنجاح")
                Catch ex As Exception : MessageBox.Show(ex.Message) : End Try
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
                    conn.Open() : cmd.ExecuteNonQuery()
                    _cachedDepts = Nothing : LoadGrid() : ClearFields()
                    MessageBox.Show("تم التعديل بنجاح")
                Catch ex As Exception : MessageBox.Show(ex.Message) : End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvDepartments.SelectedRows.Count = 0 Then Exit Sub
        If MessageBox.Show("هل أنت متأكد من الحذف؟", "تأكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvDepartments.SelectedRows(0).Cells("DepartmentID").Value)
            Dim query As String = "UPDATE Departments SET IsDeleted = 1 WHERE DepartmentID = @ID"
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentID)
                    Try
                        conn.Open() : cmd.ExecuteNonQuery()
                        _cachedDepts = Nothing : LoadGrid() : ClearFields()
                    Catch ex As Exception : MessageBox.Show(ex.Message) : End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
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

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedDepts = Nothing
        LoadGrid()
    End Sub
End Class