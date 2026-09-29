Imports System.Data.SqlClient

Public Class frmUnits
    Private _cachedUnits As DataTable = Nothing

    ' ──────────────────────────────────────────────────────────
    ' 1. تحميل وجلب قائمة الوحدات للجدول
    ' ──────────────────────────────────────────────────────────
    Private Sub LoadUnitsGrid()
        Try
            If _cachedUnits Is Nothing Then
                Dim query As String = "SELECT UnitID, UnitCode, UnitName, IsActive, IsDeleted FROM Units WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY UnitID DESC"
                _cachedUnits = DBModule.ExecuteQuery(query)
            End If

            If _cachedUnits Is Nothing Then Exit Sub
            dgvUnits.DataSource = _cachedUnits

            ' إخفاء المعرف الرئيسي وعمود الحذف
            If dgvUnits.Columns.Contains("UnitID") Then dgvUnits.Columns("UnitID").Visible = False
            If dgvUnits.Columns.Contains("IsDeleted") Then dgvUnits.Columns("IsDeleted").Visible = False

            ' تنسيق وعنونة الأعمدة
            If dgvUnits.Columns.Contains("UnitCode") Then
                dgvUnits.Columns("UnitCode").HeaderText = "كود الوحدة"
                dgvUnits.Columns("UnitCode").Width = 140
                dgvUnits.Columns("UnitCode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If dgvUnits.Columns.Contains("UnitName") Then
                dgvUnits.Columns("UnitName").HeaderText = "اسم الوحدة"
                dgvUnits.Columns("UnitName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            If dgvUnits.Columns.Contains("IsActive") Then
                dgvUnits.Columns("IsActive").HeaderText = "الحالة"
                dgvUnits.Columns("IsActive").Width = 100
                dgvUnits.Columns("IsActive").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل الوحدات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 2. حدث تحميل الفورم
    ' ──────────────────────────────────────────────────────────
    Private Sub frmUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        ' إعداد حقول البحث
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("اسم الوحدة")
        cmbSearchField.Items.Add("كود الوحدة")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        ' إعداد قائمة المقترحات
        lstSuggestions.Visible = False
        lstSuggestions.BringToFront()
        lstSuggestions.BackColor = Color.White
        lstSuggestions.ForeColor = Color.FromArgb(40, 40, 40)
        lstSuggestions.BorderStyle = BorderStyle.FixedSingle

        ' تفعيل سلاسة الجدول وتنسيقه
        DBModule.EnableDoubleBuffer(dgvUnits)
        datagridviewsetup(dgvUnits)

        ' تفعيل سحب النافذة
        Dim Drag As New FormDragHelper(Me, panelHeader)

        ' تحميل البيانات وتفريغ الحقول
        LoadUnitsGrid()
        ClearFields()
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 3. التحقق من صحة المدخلات ومنع التكرار
    ' ──────────────────────────────────────────────────────────
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtUnitName.Text) Then
            MessageBox.Show("يرجى إدخال اسم الوحدة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtUnitCode.Text) Then
            txtUnitCode.Text = GetNextCode("Units", "UnitCode").ToString()
        End If

        Return True
    End Function

    Private Function IsDuplicateUnitName(name As String, Optional excludeUnitID As Integer = 0) As Boolean
        Try
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Dim query As String = "SELECT COUNT(*) FROM Units WHERE UnitName = @Name AND (IsDeleted = 0 OR IsDeleted IS NULL) AND UnitID <> @ID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", name.Trim())
                    cmd.Parameters.AddWithValue("@ID", excludeUnitID)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    ' فحص ما إذا كانت الوحدة مرتبطة بأي عمليات في النظام لمنع مشاكل التكامل
    Private Function IsUnitInUse(unitID As Integer, unitName As String) As Boolean
        Try
            Using conn As New SqlConnection(DBModule.ConnectionString)
                conn.Open()

                ' 1. فحص الخامات المسجلة بالوحدة الأساسية
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM RawMaterials WHERE UnitID = @ID AND (IsDeleted = 0 OR IsDeleted IS NULL)", conn)
                    cmd.Parameters.AddWithValue("@ID", unitID)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then Return True
                End Using

                ' 2. فحص وحدات تحويل الخامات
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM MaterialUnits WHERE UnitID = @ID", conn)
                    cmd.Parameters.AddWithValue("@ID", unitID)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then Return True
                End Using

                ' 3. فحص وحدات المنتجات
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM ProductUnits WHERE (UnitID = @ID OR Unit_Name = @Name)", conn)
                    cmd.Parameters.AddWithValue("@ID", unitID)
                    cmd.Parameters.AddWithValue("@Name", unitName)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then Return True
                End Using

                ' 4. فحص أرصدة المخازن
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM StoreStock WHERE MinUnitID = @ID OR MaxUnitID = @ID", conn)
                    cmd.Parameters.AddWithValue("@ID", unitID)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then Return True
                End Using

                ' 5. فحص مكونات الوصفات
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM Recipes WHERE UnitID = @ID", conn)
                    cmd.Parameters.AddWithValue("@ID", unitID)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then Return True
                End Using
            End Using
        Catch
            ' في حال عدم توفر أحد الجداول لا نعيق الإجراء
        End Try
        Return False
    End Function

    ' ──────────────────────────────────────────────────────────
    ' 4. عرض بيانات الوحدة المحددة في الحقول
    ' ──────────────────────────────────────────────────────────
    Private Sub dgvUnits_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUnits.SelectionChanged
        If dgvUnits.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvUnits.SelectedRows(0)
        If row.Cells("UnitID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("UnitID").Value) Then
            txtUnitCode.Text = If(row.Cells("UnitCode").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("UnitCode").Value), row.Cells("UnitCode").Value.ToString(), "")
            txtUnitName.Text = If(row.Cells("UnitName").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("UnitName").Value), row.Cells("UnitName").Value.ToString(), "")

            ' تعبئة زر الحالة
            If Not IsDBNull(row.Cells("IsActive").Value) Then
                tgStatus.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
            Else
                tgStatus.Checked = False
            End If
        End If
    End Sub

    Private Sub dgvUnits_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUnits.CellClick
        If e.RowIndex >= 0 Then
            dgvUnits_SelectionChanged(sender, EventArgs.Empty)
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 5. زر إضافة وحدة جديدة
    ' ──────────────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        ' منع تكرار اسم الوحدة
        If IsDuplicateUnitName(txtUnitName.Text.Trim()) Then
            MessageBox.Show("اسم الوحدة مسجل مسبقاً! يرجى إدخال اسم آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitName.Focus()
            Exit Sub
        End If

        Dim query As String = "INSERT INTO Units (UnitCode, UnitName, IsActive, IsDeleted) VALUES (@Code, @Name, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtUnitCode.Text), GetNextCode("Units", "UnitCode").ToString(), txtUnitCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtUnitName.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تمت إضافة الوحدة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedUnits = Nothing
                    LoadUnitsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء إضافة الوحدة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 6. زر تعديل الوحدة المحددة
    ' ──────────────────────────────────────────────────────────
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvUnits.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد الوحدة المراد تعديلها من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvUnits.SelectedRows(0).Cells("UnitID").Value)

        ' منع تكرار اسم الوحدة لوحدة أخرى
        If IsDuplicateUnitName(txtUnitName.Text.Trim(), currentID) Then
            MessageBox.Show("اسم الوحدة مسجل مسبقاً لوحدة أخرى! يرجى إدخال اسم مختلف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitName.Focus()
            Exit Sub
        End If

        Dim query As String = "UPDATE Units SET UnitCode = @Code, UnitName = @Name, IsActive = @IsActive WHERE UnitID = @ID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentID)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtUnitCode.Text), DBNull.Value, txtUnitCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtUnitName.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل الوحدة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedUnits = Nothing
                    LoadUnitsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء تعديل الوحدة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 7. زر حذف الوحدة (حذف ناعم آمن Soft Delete)
    ' ──────────────────────────────────────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUnits.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد الوحدة المراد حذفها من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim currentID As Integer = Convert.ToInt32(dgvUnits.SelectedRows(0).Cells("UnitID").Value)
        Dim unitName As String = If(dgvUnits.SelectedRows(0).Cells("UnitName").Value IsNot Nothing, dgvUnits.SelectedRows(0).Cells("UnitName").Value.ToString(), "")

        If MessageBox.Show($"هل أنت متأكد من حذف الوحدة ({unitName})؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        ' فحص ارتباط الوحدة
        If IsUnitInUse(currentID, unitName) Then
            MessageBox.Show("لا يمكن حذف هذه الوحدة لأنها مرتبطة بخامات أو منتجات أو أرصدة مسجلة بالنظام!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "UPDATE Units SET IsDeleted = 1 WHERE UnitID = @ID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentID)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حذف الوحدة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedUnits = Nothing
                    LoadUnitsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء حذف الوحدة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 8. أزرار تفريغ الحقول والتحديث
    ' ──────────────────────────────────────────────────────────
    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedUnits = Nothing
        txtSearch.Clear()
        lstSuggestions.Visible = False
        LoadUnitsGrid()
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtUnitCode.Text = GetNextCode("Units", "UnitCode")
        txtUnitName.Clear()
        tgStatus.Checked = True
        txtSearch.Clear()
        lstSuggestions.Visible = False

        If _cachedUnits IsNot Nothing Then
            _cachedUnits.DefaultView.RowFilter = "(IsDeleted = 0 OR IsDeleted IS NULL)"
        End If

        dgvUnits.ClearSelection()
        txtUnitName.Focus()
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 9. البحث والفلترة وقائمة المقترحات
    ' ──────────────────────────────────────────────────────────
    Private Sub ApplySearchFilter()
        If _cachedUnits Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم الوحدة")
        Dim baseFilter As String = "(IsDeleted = 0 OR IsDeleted IS NULL)"

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedUnits.DefaultView.RowFilter = baseFilter
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود الوحدة"
                filterExpr = $"UnitCode LIKE '%{safeKeyword}%'"
            Case "اسم الوحدة"
                filterExpr = $"UnitName LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"(UnitName LIKE '%{safeKeyword}%' OR UnitCode LIKE '%{safeKeyword}%')"
        End Select

        _cachedUnits.DefaultView.RowFilter = $"({baseFilter}) AND ({filterExpr})"
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedUnits Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = If(field = "كود الوحدة", "UnitCode", "UnitName")
        Dim matches As New List(Of String)()

        For Each row As DataRow In _cachedUnits.Rows
            If Not row.IsNull("IsDeleted") AndAlso Convert.ToBoolean(row("IsDeleted")) Then
                Continue For
            End If

            If field = "الكل" Then
                If Not row.IsNull("UnitName") Then
                    Dim valName As String = row("UnitName").ToString()
                    If valName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 AndAlso Not matches.Contains(valName) Then
                        matches.Add(valName)
                    End If
                End If
                If Not row.IsNull("UnitCode") Then
                    Dim valCode As String = row("UnitCode").ToString()
                    If valCode.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 AndAlso Not matches.Contains(valCode) Then
                        matches.Add(valCode)
                    End If
                End If
            Else
                If _cachedUnits.Columns.Contains(colName) AndAlso Not row.IsNull(colName) Then
                    Dim val As String = row(colName).ToString()
                    If val.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 AndAlso Not matches.Contains(val) Then
                        matches.Add(val)
                    End If
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

            If dgvUnits.Rows.Count > 0 Then
                dgvUnits.ClearSelection()
                dgvUnits.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Down AndAlso lstSuggestions.Visible AndAlso lstSuggestions.Items.Count > 0 Then
            lstSuggestions.Focus()
            lstSuggestions.SelectedIndex = 0
            e.Handled = True
        ElseIf e.KeyCode = Keys.Escape Then
            lstSuggestions.Visible = False
            e.Handled = True
        End If
    End Sub

    Private Sub lstSuggestions_KeyDown(sender As Object, e As KeyEventArgs) Handles lstSuggestions.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectSuggestion()
            e.Handled = True
        ElseIf e.KeyCode = Keys.Escape Then
            lstSuggestions.Visible = False
            txtSearch.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtUnitName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnitName.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgvUnits.SelectedRows.Count > 0 Then
                btnEdit.PerformClick()
            Else
                btnAdd.PerformClick()
            End If
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' 10. أزرار التحكم بالنافذة
    ' ──────────────────────────────────────────────────────────
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