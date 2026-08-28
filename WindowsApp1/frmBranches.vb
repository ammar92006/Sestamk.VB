Imports System.Data.SqlClient

Public Class frmBranches

    ' ──────────────────────────────────────────────────────────
    ' المتغير العام للـ Cache لحفظ الفروع في الذاكرة لتسريع البحث
    ' ──────────────────────────────────────────────────────────
    Private _cachedBranches As DataTable = Nothing
    Dim x, y As Integer
    Dim newpoint As New Point

    ' 1. دالة تحميل وجلب بيانات الفروع للجدول وتخزينها في الكاش
    Private Sub LoadBranchesGrid()
        Try
            Dim query As String = "SELECT BranchID, BranchCode, BranchName, ManagerEmployeeID, Phone, " &
                                  "       Mobile, Address, Notes, IsMainBranch, IsActive " &
                                  "FROM Branches " &
                                  "WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY BranchName ASC"

            Dim dt As DataTable = DBModule.ExecuteQuery(query)
            _cachedBranches = dt

            If dt IsNot Nothing Then
                dgvBranches.DataSource = dt.DefaultView

                ' حماية التنسيقات وتأمين الأعمدة
                If dgvBranches.Columns.Contains("BranchID") Then dgvBranches.Columns("BranchID").Visible = False
                If dgvBranches.Columns.Contains("ManagerEmployeeID") Then dgvBranches.Columns("ManagerEmployeeID").Visible = False

                ' تسمية الأعمدة بالعربية
                If dgvBranches.Columns.Contains("BranchCode") Then dgvBranches.Columns("BranchCode").HeaderText = "كود الفرع"
                If dgvBranches.Columns.Contains("BranchName") Then dgvBranches.Columns("BranchName").HeaderText = "اسم الفرع"
                If dgvBranches.Columns.Contains("Phone") Then dgvBranches.Columns("Phone").HeaderText = "الهاتف الارضي"
                If dgvBranches.Columns.Contains("Mobile") Then dgvBranches.Columns("Mobile").HeaderText = "الموبايل"
                If dgvBranches.Columns.Contains("Address") Then dgvBranches.Columns("Address").HeaderText = "العنوان"
                If dgvBranches.Columns.Contains("Notes") Then dgvBranches.Columns("Notes").HeaderText = "ملاحظات"
                If dgvBranches.Columns.Contains("IsMainBranch") Then dgvBranches.Columns("IsMainBranch").HeaderText = "الفرع الرئيسي"

                If dgvBranches.Columns.Contains("IsActive") Then
                    dgvBranches.Columns("IsActive").HeaderText = "نشط"
                    dgvBranches.Columns("IsActive").Width = 60
                End If

                dgvBranches.ClearSelection()
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل بيانات الفروع: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. دالة التحقق من المدخلات (Validation)
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtBranchName.Text) Then
            MessageBox.Show("عذراً، يجب إدخال اسم الفرع أولاً!", "تنبيه الـ Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBranchName.Focus()
            Return False
        End If
        Return True
    End Function

    ' 3. دالة تنظيف الحقول
    Private Sub ClearFields()
        txtBranchCode.Clear()
        txtBranchName.Clear()
        txtPhone.Clear()
        txtMobile.Clear()
        txtAddress.Clear()
        txtNotes.Clear()
        txtSearch.Clear()
        lstSuggestions.Visible = False
        tgIsMainBranch.Checked = False
        tgIsActive.Checked = True
        dgvBranches.ClearSelection()
        If cmbManager.Items.Count > 0 Then cmbManager.SelectedIndex = -1
    End Sub

    ' حدث تحميل الفورم
    Private Sub frmBranches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.AddRange(New Object() {"اسم الفرع", "كود الفرع", "الهاتف الارضي", "الموبايل", "العنوان", "ملاحظات", "الكل"})
        If cmbSearchField.Items.Count > 0 Then cmbSearchField.SelectedIndex = 0

        datagridviewsetup()
        LoadBranchesGrid()
    End Sub

    ' 4. حدث التحديد التلقائي بأمان لعرض بيانات الفرع داخل أدوات الإدخال
    Private Sub dgvBranches_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBranches.SelectionChanged
        If dgvBranches.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvBranches.SelectedRows(0)

        If row.Cells("BranchID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("BranchID").Value) Then
            txtBranchCode.Text = If(IsDBNull(row.Cells("BranchCode").Value), "", row.Cells("BranchCode").Value.ToString())
            txtBranchName.Text = If(IsDBNull(row.Cells("BranchName").Value), "", row.Cells("BranchName").Value.ToString())
            txtPhone.Text = If(IsDBNull(row.Cells("Phone").Value), "", row.Cells("Phone").Value.ToString())
            txtMobile.Text = If(IsDBNull(row.Cells("Mobile").Value), "", row.Cells("Mobile").Value.ToString())
            txtAddress.Text = If(IsDBNull(row.Cells("Address").Value), "", row.Cells("Address").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())

            tgIsMainBranch.Checked = If(IsDBNull(row.Cells("IsMainBranch").Value), False, Convert.ToBoolean(row.Cells("IsMainBranch").Value))
            tgIsActive.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))

            If Not IsDBNull(row.Cells("ManagerEmployeeID").Value) Then
                cmbManager.SelectedValue = row.Cells("ManagerEmployeeID").Value
            Else
                cmbManager.SelectedIndex = -1
            End If
        End If
    End Sub

    ' 5. زر إضافة فرع جديد
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO Branches (BranchCode, BranchName, ManagerEmployeeID, Phone, Mobile, Address, Notes, IsMainBranch, IsActive, IsDeleted, CreatedAt) " &
                              "VALUES (@BranchCode, @BranchName, @ManagerEmployeeID, @Phone, @Mobile, @Address, @Notes, @IsMainBranch, @IsActive, 0, GETDATE())"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BranchCode", If(String.IsNullOrEmpty(txtBranchCode.Text), DBNull.Value, txtBranchCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@BranchName", txtBranchName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", If(String.IsNullOrEmpty(txtPhone.Text), DBNull.Value, txtPhone.Text.Trim()))
                cmd.Parameters.AddWithValue("@Mobile", If(String.IsNullOrEmpty(txtMobile.Text), DBNull.Value, txtMobile.Text.Trim()))
                cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrEmpty(txtAddress.Text), DBNull.Value, txtAddress.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsMainBranch", tgIsMainBranch.Checked)
                cmd.Parameters.AddWithValue("@IsActive", tgIsActive.Checked)
                cmd.Parameters.AddWithValue("@ManagerEmployeeID", If(cmbManager.SelectedValue Is Nothing, DBNull.Value, cmbManager.SelectedValue))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ بيانات الفرع بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    _cachedBranches = Nothing
                    LoadBranchesGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 6. زر تعديل بيانات الفرع
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvBranches.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvBranches.SelectedRows(0).Cells("BranchID").Value)
        Dim query As String = "UPDATE Branches SET BranchCode = @BranchCode, BranchName = @BranchName, ManagerEmployeeID = @ManagerEmployeeID, " &
                              "Phone = @Phone, Mobile = @Mobile, Address = @Address, Notes = @Notes, IsMainBranch = @IsMainBranch, IsActive = @IsActive " &
                              "WHERE BranchID = @BranchID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BranchID", currentID)
                cmd.Parameters.AddWithValue("@BranchCode", If(String.IsNullOrEmpty(txtBranchCode.Text), DBNull.Value, txtBranchCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@BranchName", txtBranchName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", If(String.IsNullOrEmpty(txtPhone.Text), DBNull.Value, txtPhone.Text.Trim()))
                cmd.Parameters.AddWithValue("@Mobile", If(String.IsNullOrEmpty(txtMobile.Text), DBNull.Value, txtMobile.Text.Trim()))
                cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrEmpty(txtAddress.Text), DBNull.Value, txtAddress.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsMainBranch", tgIsMainBranch.Checked)
                cmd.Parameters.AddWithValue("@IsActive", tgIsActive.Checked)
                cmd.Parameters.AddWithValue("@ManagerEmployeeID", If(cmbManager.SelectedValue Is Nothing, DBNull.Value, cmbManager.SelectedValue))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل بيانات الفرع بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    _cachedBranches = Nothing
                    LoadBranchesGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. زر الحذف الناعم (Soft Delete)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvBranches.SelectedRows.Count = 0 Then Exit Sub

        Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا الفرع؟", "تأكيد الحذف",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvBranches.SelectedRows(0).Cells("BranchID").Value)
            Dim query As String = "UPDATE Branches SET IsDeleted = 1 WHERE BranchID = @BranchID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BranchID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الفرع بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        _cachedBranches = Nothing
                        LoadBranchesGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' البحث المتقدم والفلترة المباشرة وقائمة الاقتراحات
    ' ──────────────────────────────────────────────────────────
    Private Sub ApplySearchFilter()
        If _cachedBranches Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "اسم الفرع")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedBranches.DefaultView.RowFilter = ""
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "كود الفرع"
                filterExpr = $"BranchCode LIKE '%{safeKeyword}%'"
            Case "اسم الفرع"
                filterExpr = $"BranchName LIKE '%{safeKeyword}%'"
            Case "الهاتف الارضي"
                filterExpr = $"Phone LIKE '%{safeKeyword}%'"
            Case "الموبايل"
                filterExpr = $"Mobile LIKE '%{safeKeyword}%'"
            Case "العنوان"
                filterExpr = $"Address LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                filterExpr = $"Notes LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"BranchName LIKE '%{safeKeyword}%' OR BranchCode LIKE '%{safeKeyword}%' OR Phone LIKE '%{safeKeyword}%' OR Mobile LIKE '%{safeKeyword}%' OR Address LIKE '%{safeKeyword}%' OR Notes LIKE '%{safeKeyword}%'"
        End Select

        _cachedBranches.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedBranches Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "BranchName"
        Select Case field
            Case "كود الفرع"
                colName = "BranchCode"
            Case "الهاتف الارضي"
                colName = "Phone"
            Case "الموبايل"
                colName = "Mobile"
            Case "العنوان"
                colName = "Address"
            Case "ملاحظات"
                colName = "Notes"
            Case Else
                colName = "BranchName"
        End Select

        Dim matches As New System.Collections.Generic.List(Of String)()
        For Each row As DataRow In _cachedBranches.Rows
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

            If dgvBranches.Rows.Count > 0 Then
                dgvBranches.ClearSelection()
                dgvBranches.Rows(0).Selected = True
            End If
        End If
    End Sub

    ' زر تفريغ الحقول
    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    ' زر التحديث المباشر
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedBranches = Nothing
        LoadBranchesGrid()
        ClearFields()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub datagridviewsetup()
        With dgvBranches
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .DefaultCellStyle.SelectionBackColor = Color.RoyalBlue

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 70
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            .DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 55)
            .DefaultCellStyle.ForeColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5)

            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65)

            .GridColor = Color.FromArgb(80, 80, 80)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

            .BackgroundColor = Color.FromArgb(30, 30, 35)
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False

            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .ColumnHeadersVisible = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .MultiSelect = False
        End With
    End Sub
End Class