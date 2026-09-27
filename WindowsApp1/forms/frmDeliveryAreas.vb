Imports System.Data.SqlClient

Public Class frmDeliveryAreas

    Private _cachedAreas As DataTable = Nothing

    Private Sub LoadAreasGrid()
        Try
            If _cachedAreas Is Nothing Then
                Dim query As String = "SELECT AreaID, AreaCode, AreaName, Notes, IsActive " &
                                      "FROM DeliveryAreas WHERE IsDeleted = 0 OR IsDeleted IS NULL"
                _cachedAreas = DBModule.ExecuteQuery(query)
            End If

            If _cachedAreas Is Nothing Then Exit Sub
            dgvDeliveryAreas.DataSource = _cachedAreas

            If dgvDeliveryAreas.Columns.Contains("AreaID") Then dgvDeliveryAreas.Columns("AreaID").Visible = False

            If dgvDeliveryAreas.Columns.Contains("AreaCode") Then dgvDeliveryAreas.Columns("AreaCode").HeaderText = "كود المنطقة"
            If dgvDeliveryAreas.Columns.Contains("AreaName") Then dgvDeliveryAreas.Columns("AreaName").HeaderText = "اسم المنطقة"
            If dgvDeliveryAreas.Columns.Contains("DefaultDeliveryFee") Then dgvDeliveryAreas.Columns("DefaultDeliveryFee").HeaderText = "سعر التوصيل"
            If dgvDeliveryAreas.Columns.Contains("Notes") Then dgvDeliveryAreas.Columns("Notes").HeaderText = "ملاحظات"
            If dgvDeliveryAreas.Columns.Contains("IsActive") Then dgvDeliveryAreas.Columns("IsActive").HeaderText = "نشط"
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل قائمة المناطق: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtAreaCode.Text) Then
            txtAreaCode.Text = GetNextCode("DeliveryAreas", "AreaCode").ToString()
        End If
        If String.IsNullOrWhiteSpace(txtAreaName.Text) Then
            MessageBox.Show("يرجى إدخال اسم المنطقة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAreaName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ClearFields()
        txtAreaCode.Text = GetNextCode("DeliveryAreas", "AreaCode").ToString()
        txtAreaName.Clear()
        txtNotes.Clear()
        tgStatus.Checked = True
        dgvDeliveryAreas.ClearSelection()
    End Sub

    Private Sub frmDeliveryAreas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        LoadAreasGrid()
        ClearFields()
        datagridviewsetup(dgvDeliveryAreas)

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub dgvDeliveryAreas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDeliveryAreas.SelectionChanged
        If dgvDeliveryAreas.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvDeliveryAreas.SelectedRows(0)

        If row.Cells("AreaID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("AreaID").Value) Then
            txtAreaCode.Text = If(IsDBNull(row.Cells("AreaCode").Value), "", row.Cells("AreaCode").Value.ToString())
            txtAreaName.Text = If(IsDBNull(row.Cells("AreaName").Value), "", row.Cells("AreaName").Value.ToString())
            'txtDefaultDeliveryFee.Text = If(IsDBNull(row.Cells("DefaultDeliveryFee").Value), "0.00", row.Cells("DefaultDeliveryFee").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO DeliveryAreas (AreaCode, AreaName, Notes, IsActive, IsDeleted) " &
                              "VALUES (@Code, @Name,  @Notes, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtAreaCode.Text), GetNextCode("DeliveryAreas", "AreaCode").ToString(), txtAreaCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtAreaName.Text.Trim())
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ المنطقة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedAreas = Nothing
                    LoadAreasGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvDeliveryAreas.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvDeliveryAreas.SelectedRows(0).Cells("AreaID").Value)

        Dim query As String = "UPDATE DeliveryAreas SET AreaCode = @Code, AreaName = @Name, " &
                              "Notes = @Notes, IsActive = @IsActive WHERE AreaID = @ID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtAreaCode.Text), GetNextCode("DeliveryAreas", "AreaCode").ToString(), txtAreaCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtAreaName.Text.Trim())

                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل المنطقة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedAreas = Nothing
                    LoadAreasGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvDeliveryAreas.SelectedRows.Count = 0 Then Exit Sub

        If MessageBox.Show("هل أنت متأكد من حذف هذه المنطقة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvDeliveryAreas.SelectedRows(0).Cells("AreaID").Value)
            Dim query As String = "UPDATE DeliveryAreas SET IsDeleted = 1 WHERE AreaID = @ID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف المنطقة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedAreas = Nothing
                        LoadAreasGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedAreas = Nothing
        LoadAreasGrid()
        ClearFields()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub
End Class