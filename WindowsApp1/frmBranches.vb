Imports System.Data.SqlClient

Public Class frmBranches

    ' ──────────────────────────────────────────────────────────
    ' المتغير العام للـ Cache لحفظ الفروع في الذاكرة لتسريع البحث
    ' ──────────────────────────────────────────────────────────
    Private _cachedBranches As DataTable = Nothing
    'Private _searchTimer As New Timer() With {.Interval = 350}
    Dim x, y As Integer
    Dim newpoint As New Point

    ' 1. دالة تحميل وجلب بيانات الفروع للجدول وتخزينها في الكاش
    Private Sub LoadBranchesGrid(Optional filter As String = "", Optional field As String = "")
        Try
            ' إذا لم يكن هناك كاش مخزن أو طُلب تحميل كامل (الفلتر فارغ)
            If _cachedBranches Is Nothing OrElse (String.IsNullOrEmpty(filter) AndAlso String.IsNullOrEmpty(field)) Then
                Dim query As String = "SELECT BranchID, BranchCode, BranchName, ManagerEmployeeID, Phone, " &
                                      "       Mobile, Address, Notes, IsMainBranch, IsActive " &
                                      "FROM Branches " &
                                      "WHERE IsDeleted = 0 OR IsDeleted IS NULL"

                ' جلب البيانات عبر الدالة الاحترافية المعزولة في الموديول
                Dim freshDt As DataTable = DBModule.ExecuteQuery(query)

                If _cachedBranches IsNot Nothing Then _cachedBranches.Dispose()
                _cachedBranches = freshDt
            End If

            ' إذا كان الكاش فارغاً لسبب ما (مثل فشل الاتصال)، نخرج فوراً منعاً للـ Crash
            If _cachedBranches Is Nothing Then Exit Sub

            ' معالجة البحث والفلترة داخل الذاكرة (In-Memory Filtering)
            Dim dtToBind As DataTable = _cachedBranches

            If Not String.IsNullOrEmpty(filter) AndAlso Not String.IsNullOrEmpty(field) Then
                Dim columnName As String = ""
                Select Case field.Trim()
                    Case "اسم الفرع" : columnName = "BranchName"
                    Case "كود الفرع" : columnName = "BranchCode"
                    Case "العنوان" : columnName = "Address"
                    Case "رقم الهاتف" : columnName = "Phone"
                End Select

                If columnName <> "" AndAlso _cachedBranches.Columns.Contains(columnName) Then
                    Dim dv As New DataView(_cachedBranches)
                    Dim safeFilter As String = filter.Replace("'", "''")
                    dv.RowFilter = $"{columnName} LIKE '%{safeFilter}%'"
                    dtToBind = dv.ToTable()
                End If
            End If

            ' ربط الجدول بالـ DataGridView
            dgvBranches.DataSource = dtToBind

            ' 🔒 حماية التنسيقات وتأمين الأعمدة ضد الـ NullReferenceException
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

        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل وتصفية الفروع: " & ex.Message, "خطأ خطير", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. خط الدفاع الأول: دالة التحقق من المدخلات (Validation)
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
        tgIsMainBranch.Checked = False
        tgIsActive.Checked = True
        dgvBranches.ClearSelection()
        ' نقوم بتصفير الكومبو بوكس الخاص بالمدير إذا كنت مفعله
        If cmbManager.Items.Count > 0 Then cmbManager.SelectedIndex = -1
    End Sub

    ' حدث تحميل الفورم
    Private Sub frmBranches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' تهيئة كومبو بوكس البحث بالعناصر العربية
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.AddRange(New Object() {"اسم الفرع", "كود الفرع", "العنوان", "رقم الهاتف"})
        If cmbSearchField.Items.Count > 0 Then cmbSearchField.SelectedIndex = 0
        datagridviewsetup()
        ' شحن الجريد بالبيانات وتخزين الكاش
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

            ' تحديد المدير إذا تم تفعيله
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
                    MessageBox.Show("تم حفظ البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' 🔄 تصفير الكاش لإجبار النظام على جلب البيانات الجديدة من الداتابيز
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
        If dgvBranches.SelectedRows.Count = 0 Then Exit Sub
        If Not IsValidData() Then Exit Sub

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

                    ' 🔄 تصفير الكاش وإعادة جلب البيانات
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
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

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

                        ' 🔄 تحديث الكاش والـ UI
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

    ' 8. حدث تغيير النص في صندوق البحث التفاعلي (Live Search)
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        _searchTimer.Stop()
        Dim keyword As String = txtSearch.Text.Trim()

        ' إذا تم مسح نص البحث، نعرض الجدول كاملاً من الكاش فوراً
        If keyword.Length = 0 Then
            If _cachedBranches IsNot Nothing Then
                dgvBranches.DataSource = _cachedBranches
            Else
                LoadBranchesGrid()
            End If
            Exit Sub
        End If

        _searchTimer.Start()
    End Sub

    ' حدث الـ Tick للتايمر للفلترة بعد توقف الكتابة بـ 350ms
    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs) Handles _searchTimer.Tick
        _searchTimer.Stop()
        Dim keyword As String = txtSearch.Text.Trim()
        Dim field As String = If(cmbSearchField.SelectedItem?.ToString(), "")

        If keyword.Length > 0 AndAlso field <> "" Then
            LoadBranchesGrid(keyword, field)
            dgvBranches.ClearSelection()
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

            '---------------------------
            ' إعداد العنوان (Header)
            '---------------------------
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 70
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            '---------------------------
            ' إعداد الصفوف (Rows)
            '---------------------------
            .DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 55)
            .DefaultCellStyle.ForeColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180) ' لون أزرق أنيق عند التحديد
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5)
            '.RowTemplate.Height = 60

            '---------------------------
            ' الصفوف المتبادلة
            '---------------------------
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65)

            '---------------------------
            ' شكل الشبكة
            '---------------------------
            .GridColor = Color.FromArgb(80, 80, 80)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

            '---------------------------
            ' الإعدادات العامة
            '---------------------------
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

            ' ✅ ضبط النص في المنتصف داخل الخلايا
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .ColumnHeadersVisible = True

            '.Columns("Category_ID").Visible = False
            '.Columns("ColorID").Visible = False
            '.Columns("PrinterID").Visible = False
            '.Columns("CategoryTypeID").Visible = False
            '.Columns("Imagebase64").Visible = False
            '.Columns("IsDeleted").Visible = False

            '.Columns("CategoryCode").HeaderText = "كود الفئة"
            '.Columns("Category_NameAr").HeaderText = "اسم الفئة عربي"
            '.Columns("CategoryNameEn").HeaderText = "اسم الفئة إنجليزي"
            '.Columns("Description").HeaderText = "وصف القسم"
            '.Columns("IsActive").HeaderText = "الحالة"
            '.Columns("ColorName").HeaderText = "اللون"
            '.Columns("PrinterName").HeaderText = "الطابعه"
            '.Columns("TypeName").HeaderText = "نوع الفئة"


            '' الترتيب
            '.Columns("Product_ID").DisplayIndex = 0
            '.Columns("Product_Code").DisplayIndex = 1
            '.Columns("Category_NameAr").Width = 300
            '.Columns("Unit_Name").DisplayIndex = 3
            '.Columns("Category_Name").DisplayIndex = 4
            '.Columns("Partner_Name").DisplayIndex = 5
            '.Columns("CompanyName").DisplayIndex = 6
            '.Columns("Product_Note").DisplayIndex = 7
            '.Columns("Product_State").DisplayIndex = 8
            '.Columns("Category_ID").Width = 200
            '.Columns("Category_Name").Width = 400
            '.Columns("Description").Width = 400
            '.Columns("IsActive").Width = 60

            ' ✅ عرض الأعمدة بالتساوي
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .MultiSelect = False
        End With
    End Sub
End Class