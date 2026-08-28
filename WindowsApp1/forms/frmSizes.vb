Imports System.Data.SqlClient

Public Class frmSizes

    Private _cachedSizes As DataTable = Nothing

    ' 1. دالة تحميل وجلب الأحجام للجدول والتخزين في الذاكرة
    Private Sub LoadSizesGrid()
        Try
            If _cachedSizes Is Nothing Then
                Dim query As String = "SELECT SizeID, SizeCode, SizeNameAr, SizeNameEn, Notes, IsActive FROM Sizes WHERE IsDeleted = 0 OR IsDeleted IS NULL"
                _cachedSizes = DBModule.ExecuteQuery(query)
            End If

            If _cachedSizes Is Nothing Then Exit Sub
            dgvSizes.DataSource = _cachedSizes

            ' إخفاء المعرف
            If dgvSizes.Columns.Contains("SizeID") Then dgvSizes.Columns("SizeID").Visible = False

            ' تسمية الأعمدة بالعربية
            If dgvSizes.Columns.Contains("SizeCode") Then dgvSizes.Columns("SizeCode").HeaderText = "كود الحجم"
            If dgvSizes.Columns.Contains("SizeNameAr") Then dgvSizes.Columns("SizeNameAr").HeaderText = "اسم الحجم (عربي)"
            If dgvSizes.Columns.Contains("SizeNameEn") Then dgvSizes.Columns("SizeNameEn").HeaderText = "اسم الحجم (إنجليزي)"
            If dgvSizes.Columns.Contains("Notes") Then dgvSizes.Columns("Notes").HeaderText = "ملاحظات"
            If dgvSizes.Columns.Contains("IsActive") Then dgvSizes.Columns("IsActive").HeaderText = "نشط"
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل قائمة الأحجام: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. خط الدفاع الأول: دالة التحقق من صحة المدخلات
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtSizeNameAr.Text) Then
            MessageBox.Show("عذراً، يجب إدخال اسم الحجم بالعربي أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSizeNameAr.Focus()
            Return False
        End If
        Return True
    End Function

    ' 3. دالة تنظيف الحقول
    Private Sub ClearFields()
        'txtSizeCode.Clear()
        txtSizeCode.Text = GetNextCode("Sizes", "SizeCode")
        txtSizeNameAr.Clear()
        txtSizeNameEn.Clear()
        txtNotes.Clear()
        tgStatus.Checked = True
        dgvSizes.ClearSelection()
    End Sub

    Private Sub frmSizes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSizeCode.Text = GetNextCode("Sizes", "SizeCode")
        LoadSizesGrid()
        datagridviewsetup(dgvSizes)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' 4. عرض البيانات عند تحديد صف من الجدول
    Private Sub dgvSizes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSizes.SelectionChanged
        If dgvSizes.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvSizes.SelectedRows(0)

        If row.Cells("SizeID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("SizeID").Value) Then
            txtSizeCode.Text = If(IsDBNull(row.Cells("SizeCode").Value), "", row.Cells("SizeCode").Value.ToString())
            txtSizeNameAr.Text = If(IsDBNull(row.Cells("SizeNameAr").Value), "", row.Cells("SizeNameAr").Value.ToString())
            txtSizeNameEn.Text = If(IsDBNull(row.Cells("SizeNameEn").Value), "", row.Cells("SizeNameEn").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' 5. زر إضافة حجم جديد
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO Sizes (SizeCode, SizeNameAr, SizeNameEn, Notes, IsActive, IsDeleted) VALUES (@Code, @NameAr, @NameEn, @Notes, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtSizeCode.Text), DBNull.Value, txtSizeCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@NameAr", txtSizeNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@NameEn", If(String.IsNullOrEmpty(txtSizeNameEn.Text), DBNull.Value, txtSizeNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ الحجم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedSizes = Nothing
                    LoadSizesGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 6. زر تعديل حجم
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvSizes.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvSizes.SelectedRows(0).Cells("SizeID").Value)
        Dim query As String = "UPDATE Sizes SET SizeCode = @Code, SizeNameAr = @NameAr, SizeNameEn = @NameEn, Notes = @Notes, IsActive = @IsActive WHERE SizeID = @SizeID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SizeID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtSizeCode.Text), DBNull.Value, txtSizeCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@NameAr", txtSizeNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@NameEn", If(String.IsNullOrEmpty(txtSizeNameEn.Text), DBNull.Value, txtSizeNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل الحجم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedSizes = Nothing
                    LoadSizesGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. زر الحذف الناعم (Soft Delete)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvSizes.SelectedRows.Count = 0 Then Exit Sub

        If MessageBox.Show("هل أنت متأكد من حذف هذا الحجم؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvSizes.SelectedRows(0).Cells("SizeID").Value)
            Dim query As String = "UPDATE Sizes SET IsDeleted = 1 WHERE SizeID = @SizeID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@SizeID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الحجم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedSizes = Nothing
                        LoadSizesGrid()
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
        _cachedSizes = Nothing
        LoadSizesGrid()
        ClearFields()
    End Sub

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