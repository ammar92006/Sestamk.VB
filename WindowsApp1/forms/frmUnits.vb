Imports System.Data.SqlClient

Public Class frmUnits
    Private _cachedUnits As DataTable = Nothing

    Private Sub LoadUnitsGrid()
        Try
            Dim query As String = "SELECT UnitID, UnitCode, UnitName,IsActive FROM Units Where IsDeleted = 0"
            _cachedUnits = DBModule.ExecuteQuery(query)
            dgvUnits.DataSource = _cachedUnits

            If dgvUnits.Columns.Contains("UnitID") Then dgvUnits.Columns("UnitID").Visible = False
            If dgvUnits.Columns.Contains("UnitCode") Then dgvUnits.Columns("UnitCode").HeaderText = "كود الوحدة"
            If dgvUnits.Columns.Contains("UnitName") Then dgvUnits.Columns("UnitName").HeaderText = "اسم الوحدة"
            If dgvUnits.Columns.Contains("IsActive") Then dgvUnits.Columns("IsActive").HeaderText = "حالة النشاط"
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل الوحدات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        LoadUnitsGrid()
        datagridviewsetup(dgvUnits)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)

        txtUnitCode.Text = GetNextCode("Units", "UnitCode")
    End Sub

    Private Sub dgvUnits_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUnits.SelectionChanged
        If dgvUnits.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvUnits.SelectedRows(0)
        If row.Cells("UnitID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("UnitID").Value) Then
            txtUnitCode.Text = row.Cells("UnitCode").Value.ToString()
            txtUnitName.Text = row.Cells("UnitName").Value.ToString()
            ' --- تعبئة زر الحالة (ToggleSwitch) ---
            If Not IsDBNull(row.Cells("IsActive").Value) Then
                tgStatus.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
            Else
                tgStatus.Checked = False
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtUnitName.Text) Then
            MessageBox.Show("يرجى إدخال اسم الوحدة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitName.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtUnitCode.Text) Then
            txtUnitCode.Text = GetNextCode("Units", "UnitCode").ToString()
        End If
        Dim query As String = "INSERT INTO Units (UnitCode,UnitName,IsActive) VALUES (@Code,@Name,@IsActive)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", txtUnitCode.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txtUnitName.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadUnitsGrid()
                    txtUnitName.Clear()
                    txtUnitCode.Text = GetNextCode("Units", "UnitCode")
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء إضافة الوحدة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUnits.SelectedRows.Count = 0 Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvUnits.SelectedRows(0).Cells("UnitID").Value)

        If MessageBox.Show("هل أنت متأكد من حذف هذه الوحدة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim query As String = "DELETE FROM Units WHERE UnitID = @ID"
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentID)

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        LoadUnitsGrid()
                        txtUnitCode.Text = GetNextCode("Units", "UnitCode")
                    Catch ex As Exception
                        MessageBox.Show("لا يمكن حذف الوحدة لارتباطها بخامات مسجلة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End Using
            End Using
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

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        'txtUnitCode.Clear()
        txtUnitCode.Text = GetNextCode("Units", "UnitCode")
        txtUnitName.Clear()
        tgStatus.Checked = True
        dgvUnits.ClearSelection()
    End Sub
End Class