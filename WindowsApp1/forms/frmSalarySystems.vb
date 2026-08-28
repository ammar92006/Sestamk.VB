Imports System.Data.SqlClient

Public Class frmSalarySystems
    Private _cachedSalaries As DataTable = Nothing

    Private Sub LoadGrid()
        Try
            Dim query As String = "SELECT SalarySystemID, SalarySystemCode, SalarySystemName, PaymentDays, Notes, IsActive FROM SalarySystems WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY SalarySystemName ASC"
            Dim dt As DataTable = DBModule.ExecuteQuery(query)
            _cachedSalaries = dt

            If dt IsNot Nothing Then
                dgvSalarySystems.DataSource = dt.DefaultView

                If dgvSalarySystems.Columns.Contains("SalarySystemID") Then dgvSalarySystems.Columns("SalarySystemID").Visible = False
                If dgvSalarySystems.Columns.Contains("SalarySystemCode") Then dgvSalarySystems.Columns("SalarySystemCode").HeaderText = "كود النظام"
                If dgvSalarySystems.Columns.Contains("SalarySystemName") Then dgvSalarySystems.Columns("SalarySystemName").HeaderText = "اسم نظام الرواتب"
                If dgvSalarySystems.Columns.Contains("PaymentDays") Then dgvSalarySystems.Columns("PaymentDays").HeaderText = "أيام الدورة المالية"
                If dgvSalarySystems.Columns.Contains("Notes") Then dgvSalarySystems.Columns("Notes").HeaderText = "ملاحظات"
                If dgvSalarySystems.Columns.Contains("IsActive") Then dgvSalarySystems.Columns("IsActive").HeaderText = "نشط"

                dgvSalarySystems.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل أنظمة الرواتب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtSalarySystemName.Text) Then
            MessageBox.Show("يرجى إدخال اسم نظام الرواتب!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub ClearFields()
        txtSalarySystemCode.Clear()
        txtSalarySystemName.Clear()
        txtPaymentDays.Text = "30"
        txtNotes.Clear()
        txtSearch.Clear()
        lstSuggestions.Visible = False
        tgStatus.Checked = True
        dgvSalarySystems.ClearSelection()
    End Sub

    Private Sub frmSalarySystems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("اسم نظام الرواتب")
        cmbSearchField.Items.Add("كود النظام")
        cmbSearchField.Items.Add("أيام الدورة المالية")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        LoadGrid()
        datagridviewsetup(dgvSalarySystems)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub dgvSalarySystems_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSalarySystems.SelectionChanged
        If dgvSalarySystems.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvSalarySystems.SelectedRows(0)
        If row.Cells("SalarySystemID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("SalarySystemID").Value) Then
            txtSalarySystemCode.Text = If(IsDBNull(row.Cells("SalarySystemCode").Value), "", row.Cells("SalarySystemCode").Value.ToString())
            txtSalarySystemName.Text = If(IsDBNull(row.Cells("SalarySystemName").Value), "", row.Cells("SalarySystemName").Value.ToString())
            txtPaymentDays.Text = If(IsDBNull(row.Cells("PaymentDays").Value), "30", row.Cells("PaymentDays").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub
        Dim query As String = "INSERT INTO SalarySystems (SalarySystemCode, SalarySystemName, PaymentDays, Notes, IsActive, IsDeleted) VALUES (@Code, @Name, @Days, @Notes, @IsActive, 0)"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtSalarySystemCode.Text), DBNull.Value, txtSalarySystemCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtSalarySystemName.Text.Trim())
                cmd.Parameters.AddWithValue("@Days", If(String.IsNullOrEmpty(txtPaymentDays.Text), 30, Convert.ToInt32(txtPaymentDays.Text)))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    _cachedSalaries = Nothing
                    LoadGrid()
                    ClearFields()
                    MessageBox.Show("تم حفظ نظام الرواتب بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvSalarySystems.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvSalarySystems.SelectedRows(0).Cells("SalarySystemID").Value)
        Dim query As String = "UPDATE SalarySystems SET SalarySystemCode=@Code, SalarySystemName=@Name, PaymentDays=@Days, Notes=@Notes, IsActive=@IsActive WHERE SalarySystemID=@ID"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtSalarySystemCode.Text), DBNull.Value, txtSalarySystemCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtSalarySystemName.Text.Trim())
                cmd.Parameters.AddWithValue("@Days", If(String.IsNullOrEmpty(txtPaymentDays.Text), 30, Convert.ToInt32(txtPaymentDays.Text)))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    _cachedSalaries = Nothing
                    LoadGrid()
                    ClearFields()
                    MessageBox.Show("تم تعديل نظام الرواتب بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvSalarySystems.SelectedRows.Count = 0 Then Exit Sub
        If MessageBox.Show("هل أنت متأكد من حذف هذا النظام؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvSalarySystems.SelectedRows(0).Cells("SalarySystemID").Value)
            Dim query As String = "UPDATE SalarySystems SET IsDeleted = 1 WHERE SalarySystemID = @ID"
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف نظام الرواتب بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedSalaries = Nothing
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
        _cachedSalaries = Nothing
        LoadGrid()
        ClearFields()
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' البحث المتقدم والفلترة المباشرة وقائمة الاقتراحات
    ' ──────────────────────────────────────────────────────────
    Private Sub ApplySearchFilter()
        If _cachedSalaries Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم نظام الرواتب")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedSalaries.DefaultView.RowFilter = ""
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود النظام"
                filterExpr = $"SalarySystemCode LIKE '%{safeKeyword}%'"
            Case "اسم نظام الرواتب"
                filterExpr = $"SalarySystemName LIKE '%{safeKeyword}%'"
            Case "أيام الدورة المالية"
                filterExpr = $"Convert(PaymentDays, 'System.String') LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                filterExpr = $"Notes LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"SalarySystemName LIKE '%{safeKeyword}%' OR SalarySystemCode LIKE '%{safeKeyword}%' OR Convert(PaymentDays, 'System.String') LIKE '%{safeKeyword}%' OR Notes LIKE '%{safeKeyword}%'"
        End Select

        _cachedSalaries.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedSalaries Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "SalarySystemName"
        Select Case field
            Case "كود النظام"
                colName = "SalarySystemCode"
            Case "أيام الدورة المالية"
                colName = "PaymentDays"
            Case "ملاحظات"
                colName = "Notes"
            Case Else
                colName = "SalarySystemName"
        End Select

        Dim matches As New System.Collections.Generic.List(Of String)()
        For Each row As DataRow In _cachedSalaries.Rows
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

            If dgvSalarySystems.Rows.Count > 0 Then
                dgvSalarySystems.ClearSelection()
                dgvSalarySystems.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class