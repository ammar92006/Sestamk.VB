Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmKitchenComments

    Private _cachedComments As DataTable = Nothing

    Private Sub frmKitchenComments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        DBModule.EnsureKitchenCommentsTable()
        ApplyTheme()
        AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged

        LoadCommentsGrid()
        ClearFields()

        Dim drag As New FormDragHelper(Me, panelHeader)
        Dim drag2 As New FormDragHelper(Me, lblTitle)
    End Sub

    Private Sub frmKitchenComments_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
    End Sub

    Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
        ApplyTheme()
    End Sub

    Private Sub ApplyTheme()
        Try
            Dim isDark = ThemeManager.Instance.IsDark
            Dim pal = ThemeManager.Instance.Palette

            Me.BackColor = pal.Background
            panelHeader.FillColor = If(isDark, pal.SurfaceHeader, Color.FromArgb(30, 41, 59))
            lblTitle.ForeColor = Color.White

            grpInfo.FillColor = If(isDark, pal.Surface, Color.FromArgb(248, 250, 252))
            grpInfo.CustomBorderColor = pal.Border
            grpInfo.ForeColor = pal.TextPrimary

            lblCommentCode.ForeColor = pal.TextSecondary
            lblCommentText.ForeColor = pal.TextSecondary
            lblStatus.ForeColor = pal.TextSecondary
            lblSearch.ForeColor = pal.TextSecondary

            txtCommentCode.FillColor = pal.InputBackground
            txtCommentCode.ForeColor = pal.TextPrimary
            txtCommentCode.BorderColor = pal.Border

            txtCommentText.FillColor = pal.InputBackground
            txtCommentText.ForeColor = pal.TextPrimary
            txtCommentText.BorderColor = pal.Border

            txtSearch.FillColor = pal.InputBackground
            txtSearch.ForeColor = pal.TextPrimary
            txtSearch.BorderColor = pal.Border

            If dgvComments IsNot Nothing Then
                dgvComments.BackgroundColor = pal.Background
                dgvComments.DefaultCellStyle.BackColor = pal.Surface
                dgvComments.DefaultCellStyle.ForeColor = pal.TextPrimary
                dgvComments.DefaultCellStyle.SelectionBackColor = pal.Primary
                dgvComments.DefaultCellStyle.SelectionForeColor = Color.White
                dgvComments.AlternatingRowsDefaultCellStyle.BackColor = If(isDark, Color.FromArgb(20, 24, 33), Color.FromArgb(242, 244, 247))
                dgvComments.ColumnHeadersDefaultCellStyle.BackColor = If(isDark, Color.FromArgb(30, 36, 50), Color.FromArgb(241, 245, 249))
                dgvComments.ColumnHeadersDefaultCellStyle.ForeColor = pal.TextPrimary
                dgvComments.GridColor = pal.Border
            End If
        Catch ex As Exception
            Logger.LogError("frmKitchenComments.ApplyTheme", ex)
        End Try
    End Sub

    Public Sub LoadCommentsGrid(Optional searchTerm As String = "")
        Try
            Dim query As String
            If String.IsNullOrWhiteSpace(searchTerm) Then
                query = "SELECT CommentID, CommentCode, CommentText, IsActive, CreatedAt FROM KitchenComments WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY CommentID DESC"
                _cachedComments = DBModule.ExecuteQuery(query)
            Else
                query = "SELECT CommentID, CommentCode, CommentText, IsActive, CreatedAt FROM KitchenComments WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND (CommentText LIKE @search OR CommentCode LIKE @search) ORDER BY CommentID DESC"
                Using conn As New SqlConnection(DBModule.ConnectionString)
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@search", "%" & searchTerm.Trim() & "%")
                        Using da As New SqlDataAdapter(cmd)
                            _cachedComments = New DataTable()
                            da.Fill(_cachedComments)
                        End Using
                    End Using
                End Using
            End If

            If _cachedComments Is Nothing Then Exit Sub
            dgvComments.DataSource = _cachedComments

            If dgvComments.Columns.Contains("CommentID") Then dgvComments.Columns("CommentID").Visible = False

            If dgvComments.Columns.Contains("CommentCode") Then
                dgvComments.Columns("CommentCode").HeaderText = "كود التعليق"
                dgvComments.Columns("CommentCode").FillWeight = 25
            End If

            If dgvComments.Columns.Contains("CommentText") Then
                dgvComments.Columns("CommentText").HeaderText = "نص التعليق / الملاحظة"
                dgvComments.Columns("CommentText").FillWeight = 50
            End If

            If dgvComments.Columns.Contains("IsActive") Then
                dgvComments.Columns("IsActive").HeaderText = "نشط"
                dgvComments.Columns("IsActive").FillWeight = 15
            End If

            If dgvComments.Columns.Contains("CreatedAt") Then
                dgvComments.Columns("CreatedAt").HeaderText = "تاريخ الإضافة"
                dgvComments.Columns("CreatedAt").DefaultCellStyle.Format = "yyyy/MM/dd HH:mm"
                dgvComments.Columns("CreatedAt").FillWeight = 25
            End If

            dgvComments.ClearSelection()
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل قائمة تعليقات المطبخ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtCommentCode.Text) Then
            txtCommentCode.Text = GetNextCommentCode()
        End If
        If String.IsNullOrWhiteSpace(txtCommentText.Text) Then
            SmartMessageBox.Show("عذراً، يجب كتابة نص التعليق أو الملاحظة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCommentText.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ClearFields()
        txtCommentCode.Text = GetNextCommentCode()
        txtCommentText.Clear()
        tgStatus.Checked = True
        txtSearch.Clear()
        dgvComments.ClearSelection()
        txtCommentText.Focus()
    End Sub

    Private Function GetNextCommentCode() As String
        Try
            Return GetNextCode("KitchenComments", "CommentCode").ToString()
        Catch
            Return "1"
        End Try
    End Function

    Private Sub dgvComments_SelectionChanged(sender As Object, e As EventArgs) Handles dgvComments.SelectionChanged
        If dgvComments.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvComments.SelectedRows(0)

        If row.Cells("CommentID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("CommentID").Value) Then
            txtCommentCode.Text = If(IsDBNull(row.Cells("CommentCode").Value), "", row.Cells("CommentCode").Value.ToString())
            txtCommentText.Text = If(IsDBNull(row.Cells("CommentText").Value), "", row.Cells("CommentText").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), True, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO KitchenComments (CommentCode, CommentText, IsActive, IsDeleted, CreatedAt) VALUES (@Code, @Text, @IsActive, 0, GETDATE())"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtCommentCode.Text), GetNextCode("KitchenComments", "CommentCode").ToString(), txtCommentCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Text", txtCommentText.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    Notify.Toast("تم حفظ تعليق المطبخ بنجاح ✅", Notify.ToastType.Success)
                    _cachedComments = Nothing
                    LoadCommentsGrid()
                    ClearFields()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvComments.SelectedRows.Count = 0 OrElse Not IsValidData() Then
            SmartMessageBox.Show("يرجى تحديد تعليق من الجدول لتعديله!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim currentID As Integer = Convert.ToInt32(dgvComments.SelectedRows(0).Cells("CommentID").Value)
        Dim query As String = "UPDATE KitchenComments SET CommentCode = @Code, CommentText = @Text, IsActive = @IsActive WHERE CommentID = @ID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtCommentCode.Text), DBNull.Value, txtCommentCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Text", txtCommentText.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    Notify.Toast("تم تعديل التعليق بنجاح ✅", Notify.ToastType.Success)
                    _cachedComments = Nothing
                    LoadCommentsGrid()
                    ClearFields()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvComments.SelectedRows.Count = 0 Then
            SmartMessageBox.Show("يرجى تحديد تعليق من الجدول لحذفه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim commentText = dgvComments.SelectedRows(0).Cells("CommentText").Value?.ToString()
        If SmartMessageBox.Show($"هل أنت متأكد من حذف تعليق المطبخ [{commentText}]؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvComments.SelectedRows(0).Cells("CommentID").Value)
            Dim query As String = "UPDATE KitchenComments SET IsDeleted = 1 WHERE CommentID = @ID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        Notify.Toast("تم حذف التعليق بنجاح 🗑️", Notify.ToastType.Success)
                        _cachedComments = Nothing
                        LoadCommentsGrid()
                        ClearFields()
                    Catch ex As Exception
                        SmartMessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedComments = Nothing
        LoadCommentsGrid()
        ClearFields()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadCommentsGrid(txtSearch.Text.Trim())
    End Sub

End Class
