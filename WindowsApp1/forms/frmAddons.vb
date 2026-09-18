Imports System.Data.SqlClient

Public Class frmAddons

    Private _cachedAddons As DataTable = Nothing

    ' 1. دالة تحميل وجلب قائمة الإضافات العامة للجدول والتخزين في الذاكرة
    Private Sub LoadAddonsGrid()
        Try
            If _cachedAddons Is Nothing Then
                Dim query As String = "SELECT AddonID, AddonCode, AddonNameAr, AddonNameEn, IsActive FROM Addons WHERE IsDeleted = 0 OR IsDeleted IS NULL"
                _cachedAddons = DBModule.ExecuteQuery(query)
            End If

            If _cachedAddons Is Nothing Then Exit Sub
            dgvAddons.DataSource = _cachedAddons

            ' إخفاء المعرف الرئيسي
            If dgvAddons.Columns.Contains("AddonID") Then dgvAddons.Columns("AddonID").Visible = False

            ' تسمية الأعمدة بالعربية
            If dgvAddons.Columns.Contains("AddonCode") Then dgvAddons.Columns("AddonCode").HeaderText = "كود الإضافة"
            If dgvAddons.Columns.Contains("AddonNameAr") Then dgvAddons.Columns("AddonNameAr").HeaderText = "اسم الإضافة (عربي)"
            If dgvAddons.Columns.Contains("AddonNameEn") Then dgvAddons.Columns("AddonNameEn").HeaderText = "اسم الإضافة (إنجليزي)"
            If dgvAddons.Columns.Contains("IsActive") Then dgvAddons.Columns("IsActive").HeaderText = "نشط"
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل قائمة الإضافات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. خط الدفاع الأول: دالة التحقق من صحة البيانات
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtAddonNameAr.Text) Then
            MessageBox.Show("عذراً، يجب إدخال اسم الإضافة بالعربي أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddonNameAr.Focus()
            Return False
        End If
        Return True
    End Function

    ' 3. دالة تنظيف وتفريغ الحقول
    Private Sub ClearFields()
        'txtAddonCode.Clear()
        txtAddonCode.Text = GetNextCode("Addons", "AddonCode")
        txtAddonNameAr.Clear()
        txtAddonNameEn.Clear()
        tgStatus.Checked = True
        dgvAddons.ClearSelection()
    End Sub

    ' حدث تحميل الشاشة
    Private Sub frmAddons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        LoadAddonsGrid()
        txtAddonCode.Text = GetNextCode("Addons", "AddonCode")
        datagridviewsetup(dgvAddons)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' 4. عرض البيانات بأمان داخل الحقول عند الضغط على صف في الجدول
    Private Sub dgvAddons_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAddons.SelectionChanged
        If dgvAddons.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvAddons.SelectedRows(0)

        If row.Cells("AddonID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("AddonID").Value) Then
            txtAddonCode.Text = If(IsDBNull(row.Cells("AddonCode").Value), "", row.Cells("AddonCode").Value.ToString())
            txtAddonNameAr.Text = If(IsDBNull(row.Cells("AddonNameAr").Value), "", row.Cells("AddonNameAr").Value.ToString())
            txtAddonNameEn.Text = If(IsDBNull(row.Cells("AddonNameEn").Value), "", row.Cells("AddonNameEn").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' 5. زر إضافة إضافة جديدة
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO Addons (AddonCode, AddonNameAr, AddonNameEn, IsActive, IsDeleted) VALUES (@Code, @NameAr, @NameEn, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtAddonCode.Text), DBNull.Value, txtAddonCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@NameAr", txtAddonNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@NameEn", If(String.IsNullOrEmpty(txtAddonNameEn.Text), DBNull.Value, txtAddonNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ الإضافة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedAddons = Nothing
                    LoadAddonsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 6. زر تعديل الإضافة
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvAddons.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvAddons.SelectedRows(0).Cells("AddonID").Value)
        Dim query As String = "UPDATE Addons SET AddonCode = @Code, AddonNameAr = @NameAr, AddonNameEn = @NameEn, IsActive = @IsActive WHERE AddonID = @AddonID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AddonID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtAddonCode.Text), DBNull.Value, txtAddonCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@NameAr", txtAddonNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@NameEn", If(String.IsNullOrEmpty(txtAddonNameEn.Text), DBNull.Value, txtAddonNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedAddons = Nothing
                    LoadAddonsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. زر الحذف الناعم (Soft Delete)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAddons.SelectedRows.Count = 0 Then Exit Sub

        If MessageBox.Show("هل أنت متأكد من حذف هذه الإضافة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvAddons.SelectedRows(0).Cells("AddonID").Value)
            Dim query As String = "UPDATE Addons SET IsDeleted = 1 WHERE AddonID = @AddonID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@AddonID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الإضافة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedAddons = Nothing
                        LoadAddonsGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' زر تفريغ الحقول
    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    ' زر إعادة التحميل والتحديث
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedAddons = Nothing
        LoadAddonsGrid()
        ClearFields()
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