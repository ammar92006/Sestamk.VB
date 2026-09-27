Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class frmUsers

    Private _cachedUsers As DataTable = Nothing
    Private _currentBase64Image As String = ""
    Private Shared _dbColumnsEnsured As Boolean = False

    Private Sub EnsureDatabaseColumns()
        If _dbColumnsEnsured Then Exit Sub
        Try
            Using conn As New SqlConnection(DBModule.ConnectionString)
                conn.Open()
                Dim sql As String =
                    "BEGIN TRY " &
                    "    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users_TBL' AND COLUMN_NAME = 'UserPhotobase64' AND (CHARACTER_MAXIMUM_LENGTH <> -1 OR CHARACTER_MAXIMUM_LENGTH IS NULL)) " &
                    "    BEGIN " &
                    "        ALTER TABLE Users_TBL ALTER COLUMN UserPhotobase64 NVARCHAR(MAX); " &
                    "    END " &
                    "END TRY BEGIN CATCH END CATCH; " &
                    "BEGIN TRY " &
                    "    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users_TBL' AND COLUMN_NAME = 'User_Note' AND (CHARACTER_MAXIMUM_LENGTH <> -1 OR CHARACTER_MAXIMUM_LENGTH IS NULL)) " &
                    "    BEGIN " &
                    "        ALTER TABLE Users_TBL ALTER COLUMN User_Note NVARCHAR(MAX); " &
                    "    END " &
                    "END TRY BEGIN CATCH END CATCH;"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                End Using
                _dbColumnsEnsured = True
            End Using
        Catch ex As Exception
            Debug.WriteLine("EnsureDatabaseColumns Error: " & ex.Message)
        End Try
    End Sub

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        EnsureDatabaseColumns()

        ' إعداد حقول البحث في الكومبوبوكس
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.AddRange(New Object() {
            "الاسم الكامل",
            "اسم الدخول",
            "كود المستخدم",
            "الدور / الصلاحية",
            "الباركود"
        })
        cmbSearchField.SelectedIndex = 0

        ' إعداد كلمة المرور كنقاط افتراضياً
        txtPassword.UseSystemPasswordChar = True
        btnTogglePassword.Checked = False

        FillDropdowns()
        LoadUsersGrid()
        ClearFields()
        txtUserCode.Text = GetNextCode("Users_TBL", "User_Code")
        Dim Drag As New FormDragHelper(Me, panelHeader)
        datagridviewsetup(dgvUsers)

    End Sub

    Private Sub FillDropdowns()
        Try
            ' 1. تعبئة الأدوار من جدول Roles
            Dim dtRoles As DataTable = DBModule.ExecuteQuery("SELECT RoleID, RoleName FROM Roles ORDER BY RoleID ASC")
            If dtRoles IsNot Nothing Then
                cmbRole.DataSource = dtRoles
                cmbRole.DisplayMember = "RoleName"
                cmbRole.ValueMember = "RoleID"
                cmbRole.SelectedIndex = -1
            End If

            ' 2. تعبئة الموظفين من جدول Employees
            Dim dtEmployees As DataTable = DBModule.ExecuteQuery("SELECT EmployeeID, ArabicName FROM Employees WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY ArabicName ASC")
            If dtEmployees IsNot Nothing Then
                cmbEmployee.DataSource = dtEmployees
                cmbEmployee.DisplayMember = "ArabicName"
                cmbEmployee.ValueMember = "EmployeeID"
                cmbEmployee.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل القوائم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUsersGrid(Optional filterText As String = "")
        Try
            Dim query As String = "SELECT U.User_ID, U.User_Code, U.User_Name, U.User_username, U.User_password, " &
                                  "U.RoleID, R.RoleName, U.EmployeeID, E.ArabicName AS EmployeeName, " &
                                  "U.UserBarcode, U.UserPhotobase64, U.IsActive, U.User_Note " &
                                  "FROM Users_TBL U " &
                                  "LEFT JOIN Roles R ON U.RoleID = R.RoleID " &
                                  "LEFT JOIN Employees E ON U.EmployeeID = E.EmployeeID " &
                                  "WHERE (U.IsDeleted = 0 OR U.IsDeleted IS NULL) "

            If Not String.IsNullOrWhiteSpace(filterText) Then
                query &= $"AND (U.User_Name LIKE '%{filterText.Replace("'", "''")}%' OR U.User_username LIKE '%{filterText.Replace("'", "''")}%' OR U.User_Code LIKE '%{filterText.Replace("'", "''")}%') "
            End If

            query &= "ORDER BY U.User_ID DESC"

            _cachedUsers = DBModule.ExecuteQuery(query)
            dgvUsers.DataSource = _cachedUsers

            ' إخفاء الحقول غير الأساسية في العرض
            Dim hiddenCols As String() = {"User_ID", "User_password", "RoleID", "EmployeeID", "UserPhotobase64", "User_Note"}
            For Each c In hiddenCols
                If dgvUsers.Columns.Contains(c) Then dgvUsers.Columns(c).Visible = False
            Next

            If dgvUsers.Columns.Contains("User_Code") Then dgvUsers.Columns("User_Code").HeaderText = "كود المستخدم"
            If dgvUsers.Columns.Contains("User_Name") Then dgvUsers.Columns("User_Name").HeaderText = "الاسم الكامل"
            If dgvUsers.Columns.Contains("User_username") Then dgvUsers.Columns("User_username").HeaderText = "اسم الدخول"
            If dgvUsers.Columns.Contains("RoleName") Then dgvUsers.Columns("RoleName").HeaderText = "الدور / الصلاحية"
            If dgvUsers.Columns.Contains("EmployeeName") Then dgvUsers.Columns("EmployeeName").HeaderText = "الموظف المرتبط"
            If dgvUsers.Columns.Contains("UserBarcode") Then dgvUsers.Columns("UserBarcode").HeaderText = "الباركود"
            If dgvUsers.Columns.Contains("IsActive") Then dgvUsers.Columns("IsActive").HeaderText = "نشط"

        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل المستخدمين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' البحث المتقدم السريع في الكاش
    ' =========================================================
    Private Sub ApplySearch()
        If _cachedUsers Is Nothing Then Exit Sub

        Dim searchText As String = txtSearch.Text.Trim()
        Dim searchField As String = If(cmbSearchField.SelectedItem?.ToString(), "الاسم الكامل")

        If String.IsNullOrEmpty(searchText) Then
            dgvUsers.DataSource = _cachedUsers
            Exit Sub
        End If

        Dim escaped As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]")
        Dim dv As New DataView(_cachedUsers)

        Select Case searchField
            Case "الاسم الكامل"
                dv.RowFilter = $"User_Name LIKE '%{escaped}%'"
            Case "اسم الدخول"
                dv.RowFilter = $"User_username LIKE '%{escaped}%'"
            Case "كود المستخدم"
                dv.RowFilter = $"User_Code LIKE '%{escaped}%'"
            Case "الدور / الصلاحية"
                dv.RowFilter = $"RoleName LIKE '%{escaped}%'"
            Case "الباركود"
                dv.RowFilter = $"UserBarcode LIKE '%{escaped}%'"
            Case Else
                dv.RowFilter = $"User_Name LIKE '%{escaped}%' OR User_username LIKE '%{escaped}%' OR User_Code LIKE '%{escaped}%'"
        End Select

        dgvUsers.DataSource = dv.ToTable()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearch()
    End Sub

    Private Sub cmbSearchField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchField.SelectedIndexChanged
        ApplySearch()
    End Sub

    ' =========================================================
    ' زر إظهار / إخفاء كلمة المرور
    ' =========================================================
    Private Sub btnTogglePassword_Click(sender As Object, e As EventArgs) Handles btnTogglePassword.Click
        ' عند تفعيل الزر (Checked = True) تظهر كلمة المرور
        ' وعند إلغاء التفعيل تعود كلمة المرور كنقاط
        txtPassword.UseSystemPasswordChar = Not btnTogglePassword.Checked
    End Sub

    Private Sub dgvUsers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUsers.SelectionChanged
        If dgvUsers.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvUsers.SelectedRows(0)

        If row.Cells("User_ID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("User_ID").Value) Then
            txtUserCode.Text = If(IsDBNull(row.Cells("User_Code").Value), "", row.Cells("User_Code").Value.ToString())
            txtFullName.Text = If(IsDBNull(row.Cells("User_Name").Value), "", row.Cells("User_Name").Value.ToString())
            txtUsername.Text = If(IsDBNull(row.Cells("User_username").Value), "", row.Cells("User_username").Value.ToString())
            txtPassword.Text = If(IsDBNull(row.Cells("User_password").Value), "", row.Cells("User_password").Value.ToString())
            txtBarcode.Text = If(IsDBNull(row.Cells("UserBarcode").Value), "", row.Cells("UserBarcode").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("User_Note").Value), "", row.Cells("User_Note").Value.ToString())

            ' إعادة تعيين إخفاء كلمة المرور كنقاط عند كل تحديد
            txtPassword.UseSystemPasswordChar = True
            btnTogglePassword.Checked = False

            If Not IsDBNull(row.Cells("RoleID").Value) Then cmbRole.SelectedValue = row.Cells("RoleID").Value Else cmbRole.SelectedIndex = -1
            If Not IsDBNull(row.Cells("EmployeeID").Value) Then cmbEmployee.SelectedValue = row.Cells("EmployeeID").Value Else cmbEmployee.SelectedIndex = -1

            tgIsActive.Checked = If(IsDBNull(row.Cells("IsActive").Value), True, Convert.ToBoolean(row.Cells("IsActive").Value))

            ' عرض الصورة المحفوظة بتنسيق Base64
            If Not IsDBNull(row.Cells("UserPhotobase64").Value) AndAlso Not String.IsNullOrWhiteSpace(row.Cells("UserPhotobase64").Value.ToString()) Then
                _currentBase64Image = row.Cells("UserPhotobase64").Value.ToString()
                picUser.Image = Base64ToImage(_currentBase64Image)
            Else
                _currentBase64Image = ""
                picUser.Image = Nothing
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInputs() Then Exit Sub

        EnsureDatabaseColumns()

        ' التحقق من عدم تكرار اسم الدخول (Username)
        Dim checkSql As String = "SELECT COUNT(1) FROM Users_TBL WHERE User_username = @Username AND (IsDeleted = 0 OR IsDeleted IS NULL)"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            conn.Open()
            Using cmdCheck As New SqlCommand(checkSql, conn)
                cmdCheck.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0 Then
                    MessageBox.Show("اسم الدخول مستخدم بالفعل! اختر اسماً آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUsername.Focus()
                    Exit Sub
                End If
            End Using

            Dim query As String = "INSERT INTO Users_TBL (User_Code, User_Name, User_username, User_password, RoleID, " &
                                  "EmployeeID, UserBarcode, UserPhotobase64, IsActive, IsDeleted, User_Note) " &
                                  "VALUES (@Code, @Name, @Username, @Password, @RoleID, @EmpID, @Barcode, @Photo, @IsActive, 0, @Note)"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtUserCode.Text), GetNextCode("Users_TBL", "User_Code").ToString(), txtUserCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim())
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim())
                cmd.Parameters.AddWithValue("@RoleID", cmbRole.SelectedValue)
                cmd.Parameters.AddWithValue("@EmpID", If(cmbEmployee.SelectedValue Is Nothing, DBNull.Value, cmbEmployee.SelectedValue))
                cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrWhiteSpace(txtBarcode.Text), DBNull.Value, txtBarcode.Text.Trim()))
                cmd.Parameters.Add("@Photo", SqlDbType.NVarChar, -1).Value = If(String.IsNullOrWhiteSpace(_currentBase64Image), DBNull.Value, _currentBase64Image)
                cmd.Parameters.AddWithValue("@IsActive", tgIsActive.Checked)
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar, -1).Value = If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim())

                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تمت إضافة المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadUsersGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء إضافة المستخدم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvUsers.SelectedRows.Count = 0 Then Exit Sub
        If Not ValidateInputs() Then Exit Sub

        EnsureDatabaseColumns()

        Dim currentUserID As Object = dgvUsers.SelectedRows(0).Cells("User_ID").Value

        Using conn As New SqlConnection(DBModule.ConnectionString)
            conn.Open()

            ' التحقق من عدم تكرار اسم الدخول لمستخدم آخر
            Dim checkSql As String = "SELECT COUNT(1) FROM Users_TBL WHERE User_username = @Username AND User_ID <> @ID AND (IsDeleted = 0 OR IsDeleted IS NULL)"
            Using cmdCheck As New SqlCommand(checkSql, conn)
                cmdCheck.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                cmdCheck.Parameters.AddWithValue("@ID", currentUserID)
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0 Then
                    MessageBox.Show("اسم الدخول مستخدم بالفعل لمستخدم آخر! اختر اسماً آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUsername.Focus()
                    Exit Sub
                End If
            End Using

            Dim query As String = "UPDATE Users_TBL SET User_Code = @Code, User_Name = @Name, User_username = @Username, " &
                                  "User_password = @Password, RoleID = @RoleID, EmployeeID = @EmpID, UserBarcode = @Barcode, " &
                                  "UserPhotobase64 = @Photo, IsActive = @IsActive, User_Note = @Note WHERE User_ID = @ID"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentUserID)
                cmd.Parameters.AddWithValue("@Code", txtUserCode.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim())
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim())
                cmd.Parameters.AddWithValue("@RoleID", cmbRole.SelectedValue)
                cmd.Parameters.AddWithValue("@EmpID", If(cmbEmployee.SelectedValue Is Nothing, DBNull.Value, cmbEmployee.SelectedValue))
                cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrWhiteSpace(txtBarcode.Text), DBNull.Value, txtBarcode.Text.Trim()))
                cmd.Parameters.Add("@Photo", SqlDbType.NVarChar, -1).Value = If(String.IsNullOrWhiteSpace(_currentBase64Image), DBNull.Value, _currentBase64Image)
                cmd.Parameters.AddWithValue("@IsActive", tgIsActive.Checked)
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar, -1).Value = If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim())

                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل بيانات المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadUsersGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء تعديل المستخدم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUsers.SelectedRows.Count = 0 Then Exit Sub

        If MessageBox.Show("هل أنت متأكد من تعطيل/حذف هذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentUserID As Object = dgvUsers.SelectedRows(0).Cells("User_ID").Value
            Dim query As String = "UPDATE Users_TBL SET IsDeleted = 1, IsActive = 0 WHERE User_ID = @ID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", currentUserID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadUsersGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub btnUploadPic_Click(sender As Object, e As EventArgs) Handles btnUploadPic.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                Using originalImg As Image = Image.FromFile(ofd.FileName)
                    picUser.Image = New Bitmap(originalImg)
                    _currentBase64Image = ImageToBase64(picUser.Image, 200, 200)
                End Using
            End If
        End Using
    End Sub

    Private Sub btnRemovePic_Click(sender As Object, e As EventArgs) Handles btnRemovePic.Click
        picUser.Image = Nothing
        _currentBase64Image = ""
    End Sub

    ' تحويل الصورة إلى Base64 مع تغيير الحجم وتحديد جودة الـ JPEG لتجنب تضخم حجم قاعدة البيانات والبطء
    Private Function ImageToBase64(img As Image, Optional maxWidth As Integer = 200, Optional maxHeight As Integer = 200) As String
        If img Is Nothing Then Return ""
        Try
            Dim newW As Integer = img.Width
            Dim newH As Integer = img.Height

            If newW > maxWidth OrElse newH > maxHeight Then
                Dim ratioX As Double = maxWidth / CDbl(img.Width)
                Dim ratioY As Double = maxHeight / CDbl(img.Height)
                Dim ratio As Double = Math.Min(ratioX, ratioY)
                newW = Math.Max(1, CInt(img.Width * ratio))
                newH = Math.Max(1, CInt(img.Height * ratio))
            End If

            Using bmp As New Bitmap(newW, newH)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(img, 0, 0, newW, newH)
                End Using

                Using ms As New MemoryStream()
                    Dim jpgEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
                    If jpgEncoder IsNot Nothing Then
                        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                        Dim myEncoderParameters As New EncoderParameters(1)
                        myEncoderParameters.Param(0) = New EncoderParameter(myEncoder, 70L)
                        bmp.Save(ms, jpgEncoder, myEncoderParameters)
                    Else
                        bmp.Save(ms, ImageFormat.Jpeg)
                    End If
                    Return Convert.ToBase64String(ms.ToArray())
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("ImageToBase64 Error: " & ex.Message)
            Return ""
        End Try
    End Function

    Private Function GetEncoder(format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()
        For Each codec As ImageCodecInfo In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next
        Return Nothing
    End Function

    Private Function Base64ToImage(base64 As String) As Image
        Try
            Dim bytes As Byte() = Convert.FromBase64String(base64)
            Using ms As New MemoryStream(bytes)
                Return Image.FromStream(ms)
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtUserCode.Text) Then
            txtUserCode.Text = GetNextCode("Users_TBL", "User_Code").ToString()
        End If

        If String.IsNullOrWhiteSpace(txtFullName.Text) OrElse String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("يرجى ملء الحقول الإلزامية: (الاسم، اسم الدخول، كلمة المرور)!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbRole.SelectedIndex = -1 Then
            MessageBox.Show("يرجى تحديد دور المستخدم / الصلاحية!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRole.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtUserCode.Text = GetNextCode("Users_TBL", "User_Code")
        txtFullName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtPassword.UseSystemPasswordChar = True
        btnTogglePassword.Checked = False
        txtBarcode.Clear()
        txtNotes.Clear()
        cmbRole.SelectedIndex = -1
        cmbEmployee.SelectedIndex = -1
        tgIsActive.Checked = True
        picUser.Image = Nothing
        _currentBase64Image = ""
        dgvUsers.ClearSelection()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

End Class