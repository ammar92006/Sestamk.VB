Imports System.Data.SqlClient
Imports System.IO

Public Class frmEmployees

    ' =========================================================================
    ' Private Cache & Window Drag Variables
    ' =========================================================================
    Private _cachedEmployees As DataTable = Nothing
    Private _isLoadingData As Boolean = False
    Private x As Integer, y As Integer
    Private newpoint As New Point

    ' =========================================================================
    ' 1. Form Load Event
    ' =========================================================================
    Private Sub frmEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Setup Search Criteria Dropdown
            cmbSearchField.Items.Clear()
            cmbSearchField.Items.AddRange(New Object() {"الاسم عربي", "كود الموظف", "رقم الهاتف", "القسم", "المسمى الوظيفي", "الرقم القومي"})
            If cmbSearchField.Items.Count > 0 Then cmbSearchField.SelectedIndex = 0

            ' Setup DataGridView Styles & Options
            SetupDataGridViewStyle()

            ' Fill Static / Dynamic ComboBoxes
            FillDropdowns()

            ' Load Grid Data (Initial DB Fetch)
            LoadEmployeesGrid()

            ' Setup Form Dragging Helper if available
            Dim drag As New FormDragHelper(Me, panelHeader)
            Dim drag2 As New FormDragHelper(Me, Guna2HtmlLabel1)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تحميل شاشة الموظفين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================================
    ' 2. Fill Dropdowns
    ' =========================================================================
    Private Sub FillDropdowns()
        Try
            ' 1. Fill Departments
            Dim dtDept As DataTable = DBModule.ExecuteQuery("SELECT DepartmentID, DepartmentName FROM Departments WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY DepartmentName")
            If dtDept IsNot Nothing Then
                cmbDepartment.DataSource = dtDept
                cmbDepartment.DisplayMember = "DepartmentName"
                cmbDepartment.ValueMember = "DepartmentID"
                cmbDepartment.SelectedIndex = -1
            End If

            ' 2. Fill Salary Systems
            Dim dtSalary As DataTable = DBModule.ExecuteQuery("SELECT SalarySystemID, SalarySystemName FROM SalarySystems WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY SalarySystemName")
            If dtSalary IsNot Nothing Then
                cmbSalarySystem.DataSource = dtSalary
                cmbSalarySystem.DisplayMember = "SalarySystemName"
                cmbSalarySystem.ValueMember = "SalarySystemID"
                cmbSalarySystem.SelectedIndex = -1
            End If

            ' 3. Fill Branches
            Dim dtBranch As DataTable = DBModule.ExecuteQuery("SELECT BranchID, BranchName FROM Branches WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY BranchName")
            If dtBranch IsNot Nothing Then
                cmbBranch.DataSource = dtBranch
                cmbBranch.DisplayMember = "BranchName"
                cmbBranch.ValueMember = "BranchID"
                cmbBranch.SelectedIndex = -1
            End If

            ' 4. Fill Gender ComboBox if empty
            If cmbGender.Items.Count = 0 Then
                cmbGender.Items.AddRange(New Object() {"ذكر", "أنثى"})
            End If
            cmbGender.SelectedIndex = -1

            ' 5. Fill Employee Status ComboBox if empty
            If cmbEmployeeStatus.Items.Count = 0 Then
                cmbEmployeeStatus.Items.AddRange(New Object() {"على رأس العمل", "إجازة", "موقوف", "مستقيل", "مفصول"})
            End If
            cmbEmployeeStatus.SelectedIndex = -1

        Catch ex As Exception
            Debug.WriteLine("Error Filling Dropdowns: " & ex.Message)
        End Try
    End Sub

    ' =========================================================================
    ' 3. Cascading ComboBox: Filter JobTitles by Department
    ' =========================================================================
    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged
        Try
            If cmbDepartment.SelectedValue Is Nothing OrElse IsDBNull(cmbDepartment.SelectedValue) OrElse Not IsNumeric(cmbDepartment.SelectedValue) Then
                cmbJobTitle.DataSource = Nothing
                cmbJobTitle.SelectedIndex = -1
                Exit Sub
            End If

            Dim deptID As Integer = Convert.ToInt32(cmbDepartment.SelectedValue)
            Dim query As String = "SELECT JobTitleID, JobTitleName FROM JobTitles WHERE DepartmentID = @DeptID AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY JobTitleName"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@DeptID", deptID)
                    Dim dtJobs As New DataTable()
                    Using da As New SqlDataAdapter(cmd)
                        conn.Open()
                        da.Fill(dtJobs)
                    End Using

                    cmbJobTitle.DataSource = dtJobs
                    cmbJobTitle.DisplayMember = "JobTitleName"
                    cmbJobTitle.ValueMember = "JobTitleID"
                    cmbJobTitle.SelectedIndex = -1
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error loading JobTitles: " & ex.Message)
        End Try
    End Sub

    ' =========================================================================
    ' 4. Data Loading & In-Memory DataView Filtering (Cache Pattern)
    ' =========================================================================
    Private Sub LoadEmployeesGrid(Optional filter As String = "", Optional field As String = "")
        Try
            ' Cache checking: Execute main SELECT SQL query once when _cachedEmployees is null
            If _cachedEmployees Is Nothing OrElse (String.IsNullOrEmpty(filter) AndAlso String.IsNullOrEmpty(field)) Then
                Dim query As String = "SELECT E.EmployeeID, E.EmployeeCode, E.ArabicName, E.EnglishName, E.NationalID, " &
                                      "E.Phone, E.Phone2, E.Email, E.Address, E.BirthDate, E.Gender, " &
                                      "E.BranchID, B.BranchName, " &
                                      "E.DepartmentID, D.DepartmentName, " &
                                      "E.JobTitleID, J.JobTitleName, " &
                                      "E.HireDate, E.ContractEndDate, E.FingerprintCode, E.EmployeeStatus, E.Notes, " &
                                      "E.CheckInTime, E.CheckOutTime, E.DailyWorkingHours, " &
                                      "E.SalarySystemID, S.SalarySystemName, " &
                                      "E.BasicSalary, E.TransportationAllowance, E.HousingAllowance, E.OtherAllowances, " &
                                      "E.InsuranceStatus, E.InsuranceAmount, E.OvertimeAllowed, E.OvertimeRate, " &
                                      "E.IsActive, E.IsDeleted, " &
                                      "E.PersonalPhoto, E.NationalIDPhotofront, E.NationalIDPhotoback " &
                                      "FROM Employees E " &
                                      "LEFT JOIN Branches B ON E.BranchID = B.BranchID " &
                                      "LEFT JOIN Departments D ON E.DepartmentID = D.DepartmentID " &
                                      "LEFT JOIN JobTitles J ON E.JobTitleID = J.JobTitleID " &
                                      "LEFT JOIN SalarySystems S ON E.SalarySystemID = S.SalarySystemID " &
                                      "WHERE E.IsDeleted = 0 OR E.IsDeleted IS NULL " &
                                      "ORDER BY E.EmployeeID DESC"

                Using conn As New SqlConnection(DBModule.ConnectionString)
                    Using cmd As New SqlCommand(query, conn)
                        Using da As New SqlDataAdapter(cmd)
                            Dim dt As New DataTable()
                            conn.Open()
                            da.Fill(dt)
                            If _cachedEmployees IsNot Nothing Then _cachedEmployees.Dispose()
                            _cachedEmployees = dt
                        End Using
                    End Using
                End Using
            End If

            If _cachedEmployees Is Nothing Then Exit Sub

            Dim dtToBind As DataTable = _cachedEmployees

            ' In-Memory Filtering via DataView
            If Not String.IsNullOrEmpty(filter) AndAlso Not String.IsNullOrEmpty(field) Then
                Dim columnName As String = ""
                Select Case field.Trim()
                    Case "الاسم عربي" : columnName = "ArabicName"
                    Case "كود الموظف" : columnName = "EmployeeCode"
                    Case "رقم الهاتف" : columnName = "Phone"
                    Case "القسم" : columnName = "DepartmentName"
                    Case "المسمى الوظيفي" : columnName = "JobTitleName"
                    Case "الرقم القومي" : columnName = "NationalID"
                End Select

                If columnName <> "" AndAlso _cachedEmployees.Columns.Contains(columnName) Then
                    Dim dv As New DataView(_cachedEmployees)
                    Dim safeFilter As String = filter.Replace("'", "''")
                    dv.RowFilter = $"[{columnName}] LIKE '%{safeFilter}%'"
                    dtToBind = dv.ToTable()
                End If
            End If

            _isLoadingData = True
            dgvEmployees.DataSource = dtToBind

            ' Column Visibility & Header Formatting
            FormatGridColumns()

            _isLoadingData = False
            dgvEmployees.ClearSelection()

        Catch ex As Exception
            _isLoadingData = False
            MessageBox.Show("خطأ في تحميل بيانات الموظفين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGridColumns()
        If dgvEmployees.Columns.Count = 0 Then Exit Sub

        ' Hide IDs, binary/base64 columns, and detailed fields from direct grid view
        Dim hiddenCols As String() = {
            "EmployeeID", "BranchID", "DepartmentID", "JobTitleID", "SalarySystemID",
            "EnglishName", "NationalID", "Phone2", "Email", "Address", "BirthDate", "Gender",
            "HireDate", "ContractEndDate", "FingerprintCode", "EmployeeStatus", "Notes",
            "DailyWorkingHours", "TransportationAllowance", "HousingAllowance", "OtherAllowances",
            "InsuranceStatus", "InsuranceAmount", "OvertimeAllowed", "OvertimeRate",
            "PersonalPhoto", "NationalIDPhotofront", "NationalIDPhotoback", "IsDeleted"
        }

        For Each col In hiddenCols
            If dgvEmployees.Columns.Contains(col) Then dgvEmployees.Columns(col).Visible = False
        Next

        ' Set Arabic Headers for visible grid columns
        If dgvEmployees.Columns.Contains("EmployeeCode") Then dgvEmployees.Columns("EmployeeCode").HeaderText = "الكود"
        If dgvEmployees.Columns.Contains("ArabicName") Then dgvEmployees.Columns("ArabicName").HeaderText = "اسم الموظف"
        If dgvEmployees.Columns.Contains("Phone") Then dgvEmployees.Columns("Phone").HeaderText = "رقم الهاتف"
        If dgvEmployees.Columns.Contains("BranchName") Then dgvEmployees.Columns("BranchName").HeaderText = "الفرع"
        If dgvEmployees.Columns.Contains("DepartmentName") Then dgvEmployees.Columns("DepartmentName").HeaderText = "القسم"
        If dgvEmployees.Columns.Contains("JobTitleName") Then dgvEmployees.Columns("JobTitleName").HeaderText = "المسمى الوظيفي"
        If dgvEmployees.Columns.Contains("SalarySystemName") Then dgvEmployees.Columns("SalarySystemName").HeaderText = "نظام الراتب"
        If dgvEmployees.Columns.Contains("BasicSalary") Then dgvEmployees.Columns("BasicSalary").HeaderText = "الراتب الأساسي"
        If dgvEmployees.Columns.Contains("CheckInTime") Then dgvEmployees.Columns("CheckInTime").HeaderText = "الحضور"
        If dgvEmployees.Columns.Contains("CheckOutTime") Then dgvEmployees.Columns("CheckOutTime").HeaderText = "الانصراف"
        If dgvEmployees.Columns.Contains("IsActive") Then dgvEmployees.Columns("IsActive").HeaderText = "الحالة"
    End Sub

    ' =========================================================================
    ' 5. Debounced Live Search Events
    ' =========================================================================
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        _searchTimer.Stop()
        _searchTimer.Interval = 350
        _searchTimer.Start()
    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs) Handles _searchTimer.Tick
        _searchTimer.Stop()
        Dim keyword As String = txtSearch.Text.Trim()
        Dim field As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "")
        LoadEmployeesGrid(keyword, field)
    End Sub

    ' =========================================================================
    ' 6. DataGrid Selection Changed - Map Row Cells Back to Controls
    ' =========================================================================
    Private Sub dgvEmployees_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmployees.SelectionChanged
        If _isLoadingData OrElse dgvEmployees.SelectedRows.Count = 0 Then Exit Sub

        Try
            Dim row As DataGridViewRow = dgvEmployees.SelectedRows(0)
            If row.Cells("EmployeeID").Value Is Nothing OrElse IsDBNull(row.Cells("EmployeeID").Value) Then Exit Sub

            ' Tab 1 - Personal Details
            txtEmployeeCode.Text = GetCellString(row, "EmployeeCode")
            txtArabicName.Text = GetCellString(row, "ArabicName")
            txtEnglishName.Text = GetCellString(row, "EnglishName")
            txtNationalID.Text = GetCellString(row, "NationalID")
            txtPhone.Text = GetCellString(row, "Phone")
            txtPhone2.Text = GetCellString(row, "Phone2")
            txtEmail.Text = GetCellString(row, "Email")
            txtAddress.Text = GetCellString(row, "Address")
            SetDatePickerValue(dtpBirthDate, row.Cells("BirthDate").Value)
            SetGenderControl(row.Cells("Gender").Value)

            ' Tab 2 - Employment Details
            SetComboSelectedValue(cmbBranch, row.Cells("BranchID").Value)

            ' Set Department first, which triggers cmbDepartment_SelectedIndexChanged to load job titles
            SetComboSelectedValue(cmbDepartment, row.Cells("DepartmentID").Value)
            SetComboSelectedValue(cmbJobTitle, row.Cells("JobTitleID").Value)

            SetDatePickerValue(dtpHireDate, row.Cells("HireDate").Value)
            SetDatePickerValue(dtpContractEndDate, row.Cells("ContractEndDate").Value)
            txtFingerprintCode.Text = GetCellString(row, "FingerprintCode")
            SetEmployeeStatusControl(row.Cells("EmployeeStatus").Value)
            txtNotes.Text = GetCellString(row, "Notes")

            ' Tab 3 - Salary & Timing
            SetTimePickerValue(dtpCheckInTime, row.Cells("CheckInTime").Value)
            SetTimePickerValue(dtpCheckOutTime, row.Cells("CheckOutTime").Value)
            txtDailyWorkingHours.Text = GetCellString(row, "DailyWorkingHours")
            SetComboSelectedValue(cmbSalarySystem, row.Cells("SalarySystemID").Value)
            txtBasicSalary.Text = GetCellString(row, "BasicSalary")
            txtTransAllowance.Text = GetCellString(row, "TransportationAllowance")
            txtHousingAllowance.Text = GetCellString(row, "HousingAllowance")
            txtOtherAllowance.Text = GetCellString(row, "OtherAllowances")

            tgInsuranceStatus.Checked = GetCellBool(row, "InsuranceStatus", False)
            txtInsuranceAmount.Text = GetCellString(row, "InsuranceAmount")
            tgOvertimeAllowed.Checked = GetCellBool(row, "OvertimeAllowed", False)
            txtOvertimeRate.Text = GetCellString(row, "OvertimeRate")
            tgStatus.Checked = GetCellBool(row, "IsActive", True)

            ' Tab 4 - Base64 Images Mapping
            picEmployee.Image = DBModule.Base64ToImage(GetCellString(row, "PersonalPhoto"))
            picNationalFront.Image = DBModule.Base64ToImage(GetCellString(row, "NationalIDPhotofront"))
            picNationalBack.Image = DBModule.Base64ToImage(GetCellString(row, "NationalIDPhotoback"))

        Catch ex As Exception
            Debug.WriteLine("Error in SelectionChanged: " & ex.Message)
        End Try
    End Sub

    ' Helper Data Extraction Utilities
    Private Function GetCellString(row As DataGridViewRow, colName As String) As String
        If row.DataGridView.Columns.Contains(colName) AndAlso row.Cells(colName).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(colName).Value) Then
            Return row.Cells(colName).Value.ToString()
        End If
        Return ""
    End Function

    Private Function GetCellBool(row As DataGridViewRow, colName As String, defaultValue As Boolean) As Boolean
        If row.DataGridView.Columns.Contains(colName) AndAlso row.Cells(colName).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(colName).Value) Then
            Dim b As Boolean
            If Boolean.TryParse(row.Cells(colName).Value.ToString(), b) Then
                Return b
            End If
        End If
        Return defaultValue
    End Function

    Private Sub SetDatePickerValue(dtp As Guna.UI2.WinForms.Guna2DateTimePicker, value As Object)
        If value IsNot Nothing AndAlso Not IsDBNull(value) AndAlso IsDate(value) Then
            dtp.Value = Convert.ToDateTime(value)
        Else
            dtp.Value = DateTime.Now
        End If
    End Sub

    Private Sub SetTimePickerValue(dtp As Guna.UI2.WinForms.Guna2DateTimePicker, value As Object)
        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
            If TypeOf value Is TimeSpan Then
                Dim ts As TimeSpan = CType(value, TimeSpan)
                dtp.Value = DateTime.Today.Add(ts)
            ElseIf IsDate(value) Then
                dtp.Value = Convert.ToDateTime(value)
            End If
        Else
            dtp.Value = DateTime.Now
        End If
    End Sub

    Private Sub SetComboSelectedValue(cmb As Guna.UI2.WinForms.Guna2ComboBox, value As Object)
        If cmb.DataSource IsNot Nothing AndAlso value IsNot Nothing AndAlso Not IsDBNull(value) Then
            cmb.SelectedValue = value
        Else
            cmb.SelectedIndex = -1
        End If
    End Sub

    Private Sub SetGenderControl(val As Object)
        If val IsNot Nothing AndAlso Not IsDBNull(val) AndAlso IsNumeric(val) Then
            Dim g As Integer = Convert.ToInt32(val)
            If g = 1 Then cmbGender.SelectedItem = "ذكر" : Exit Sub
            If g = 2 Then cmbGender.SelectedItem = "أنثى" : Exit Sub
        End If
        cmbGender.SelectedIndex = -1
    End Sub

    Private Sub SetEmployeeStatusControl(val As Object)
        If val IsNot Nothing AndAlso Not IsDBNull(val) AndAlso IsNumeric(val) Then
            Dim st As Integer = Convert.ToInt32(val)
            Select Case st
                Case 1 : cmbEmployeeStatus.SelectedItem = "على رأس العمل" : Exit Sub
                Case 2 : cmbEmployeeStatus.SelectedItem = "إجازة" : Exit Sub
                Case 3 : cmbEmployeeStatus.SelectedItem = "مستقيل" : Exit Sub
                Case 4 : cmbEmployeeStatus.SelectedItem = "موقوف" : Exit Sub
                Case 5 : cmbEmployeeStatus.SelectedItem = "مفصول" : Exit Sub
            End Select
        End If
        cmbEmployeeStatus.SelectedIndex = -1
    End Sub

    ' =========================================================================
    ' 7. Robust Data Validation
    ' =========================================================================
    Private Function IsValidData() As Boolean
        ' 1. Validate Employee Code (Auto-generate if empty)
        If String.IsNullOrWhiteSpace(txtEmployeeCode.Text) Then
            txtEmployeeCode.Text = GenerateAutoEmployeeCode()
        End If

        ' 2. Validate Arabic Name (Required NOT NULL in DB)
        If String.IsNullOrWhiteSpace(txtArabicName.Text) Then
            MessageBox.Show("عذراً، يجب إدخال اسم الموظف باللغة العربية!", "تنبيه الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Guna2TabControl1.SelectedTab = tabPageBasic
            txtArabicName.Focus()
            Return False
        End If

        ' 3. Validate National ID format if entered
        If Not String.IsNullOrWhiteSpace(txtNationalID.Text) AndAlso Not IsNumeric(txtNationalID.Text.Trim()) Then
            MessageBox.Show("عذراً، الرقم القومي يجب أن يتكون من أرقام فقط!", "تنبيه الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Guna2TabControl1.SelectedTab = tabPageBasic
            txtNationalID.Focus()
            Return False
        End If

        ' 4. Validate Email format if entered
        If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
            Dim emailStr As String = txtEmail.Text.Trim()
            If Not (emailStr.Contains("@") AndAlso emailStr.Contains(".")) Then
                MessageBox.Show("عذراً، صيغة البريد الإلكتروني غير صحيحة!", "تنبيه الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Guna2TabControl1.SelectedTab = tabPageBasic
                txtEmail.Focus()
                Return False
            End If
        End If

        ' 5. Validate Department Selection
        If cmbDepartment.SelectedValue Is Nothing OrElse IsDBNull(cmbDepartment.SelectedValue) OrElse Not IsNumeric(cmbDepartment.SelectedValue) Then
            MessageBox.Show("عذراً، يجب اختيار القسم التابع له الموظف!", "تنبيه الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Guna2TabControl1.SelectedTab = tabPageJob
            cmbDepartment.Focus()
            Return False
        End If

        ' 6. Validate Financial Numbers Format if entered
        Dim numFields As Tuple(Of Guna.UI2.WinForms.Guna2TextBox, String)() = {
            Tuple.Create(txtBasicSalary, "الراتب الأساسي"),
            Tuple.Create(txtTransAllowance, "بدل الانتقال"),
            Tuple.Create(txtHousingAllowance, "بدل السكن"),
            Tuple.Create(txtOtherAllowance, "البدلات الأخرى"),
            Tuple.Create(txtInsuranceAmount, "مبلغ التأمين"),
            Tuple.Create(txtOvertimeRate, "معدل الإضافي"),
            Tuple.Create(txtDailyWorkingHours, "ساعات العمل اليومية")
        }

        For Each item In numFields
            If Not String.IsNullOrWhiteSpace(item.Item1.Text) AndAlso Not IsNumeric(item.Item1.Text.Trim()) Then
                MessageBox.Show($"عذراً، قيمة [{item.Item2}] يجب أن تكون رقماً صحياً أو عشرياً!", "تنبيه الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Guna2TabControl1.SelectedTab = tabPageSalary
                item.Item1.Focus()
                Return False
            End If
        Next

        Return True
    End Function

    Private Function GenerateAutoEmployeeCode() As String
        Try
            Dim dt As DataTable = DBModule.ExecuteQuery("SELECT ISNULL(MAX(EmployeeID), 0) + 1 FROM Employees")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)(0)) Then
                Dim nextId As Integer = Convert.ToInt32(dt.Rows(0)(0))
                Return "EMP-" & nextId.ToString("D4")
            End If
        Catch ex As Exception
            Debug.WriteLine("Error generating employee code: " & ex.Message)
        End Try
        Return "EMP-" & DateTime.Now.ToString("yyMMddHHmmss")
    End Function

    ' =========================================================================
    ' 8. Clear Fields Helper
    ' =========================================================================
    Private Sub ClearFields()
        ' Reset TextBoxes
        txtEmployeeCode.Clear()
        txtArabicName.Clear()
        txtEnglishName.Clear()
        txtNationalID.Clear()
        txtPhone.Clear()
        txtPhone2.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        txtFingerprintCode.Clear()
        txtNotes.Clear()
        txtDailyWorkingHours.Clear()
        txtBasicSalary.Clear()
        txtTransAllowance.Clear()
        txtHousingAllowance.Clear()
        txtOtherAllowance.Clear()
        txtInsuranceAmount.Clear()
        txtOvertimeRate.Clear()

        ' Reset ComboBoxes
        cmbGender.SelectedIndex = -1
        cmbBranch.SelectedIndex = -1
        cmbDepartment.SelectedIndex = -1
        cmbJobTitle.DataSource = Nothing
        cmbJobTitle.SelectedIndex = -1
        cmbEmployeeStatus.SelectedIndex = -1
        cmbSalarySystem.SelectedIndex = -1

        ' Reset Date/Time Pickers
        dtpBirthDate.Value = DateTime.Now
        dtpHireDate.Value = DateTime.Now
        dtpContractEndDate.Value = DateTime.Now
        dtpCheckInTime.Value = DateTime.Today.AddHours(9)
        dtpCheckOutTime.Value = DateTime.Today.AddHours(17)

        ' Reset Toggle Switches
        tgInsuranceStatus.Checked = False
        tgOvertimeAllowed.Checked = False
        tgStatus.Checked = True

        ' Reset PictureBoxes
        picEmployee.Image = Nothing
        picNationalFront.Image = Nothing
        picNationalBack.Image = Nothing

        ' Clear Selection safely
        dgvEmployees.ClearSelection()

        ' Auto Generate New Code for convenience
        txtEmployeeCode.Text = GenerateAutoEmployeeCode()

        ' Select First Tab
        Guna2TabControl1.SelectedTab = tabPageBasic
    End Sub

    ' =========================================================================
    ' 9. CRUD Operations (INSERT, UPDATE, SOFT DELETE)
    ' =========================================================================

    ' --- ADD / INSERT ---
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO Employees (" &
            "EmployeeCode, ArabicName, EnglishName, NationalID, Phone, Phone2, Email, Address, BirthDate, Gender, " &
            "BranchID, DepartmentID, JobTitleID, HireDate, ContractEndDate, FingerprintCode, EmployeeStatus, Notes, " &
            "CheckInTime, CheckOutTime, DailyWorkingHours, SalarySystemID, BasicSalary, TransportationAllowance, " &
            "HousingAllowance, OtherAllowances, InsuranceStatus, InsuranceAmount, OvertimeAllowed, OvertimeRate, " &
            "IsActive, IsDeleted, PersonalPhoto, NationalIDPhotofront, NationalIDPhotoback" &
            ") VALUES (" &
            "@EmployeeCode, @ArabicName, @EnglishName, @NationalID, @Phone, @Phone2, @Email, @Address, @BirthDate, @Gender, " &
            "@BranchID, @DepartmentID, @JobTitleID, @HireDate, @ContractEndDate, @FingerprintCode, @EmployeeStatus, @Notes, " &
            "@CheckInTime, @CheckOutTime, @DailyWorkingHours, @SalarySystemID, @BasicSalary, @TransportationAllowance, " &
            "@HousingAllowance, @OtherAllowances, @InsuranceStatus, @InsuranceAmount, @OvertimeAllowed, @OvertimeRate, " &
            "@IsActive, 0, @PersonalPhoto, @NationalIDPhotofront, @NationalIDPhotoback)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                AddEmployeeParameters(cmd)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    ' Invalidate cache and reload
                    _cachedEmployees = Nothing
                    LoadEmployeesGrid()
                    ClearFields()

                    MessageBox.Show("تمت إضافة الموظف بنجاح 🟢", "نجاح الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("حدث خطأ أثناء إضافة الموظف: " & ex.Message, "خطأ SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' --- EDIT / UPDATE ---
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("الرجاء اختيار الموظف المراد تعديل بياناته من القائمة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsValidData() Then Exit Sub

        Dim selectedRow As DataGridViewRow = dgvEmployees.SelectedRows(0)
        Dim empID As Integer = Convert.ToInt32(selectedRow.Cells("EmployeeID").Value)

        Dim query As String = "UPDATE Employees SET " &
            "EmployeeCode = @EmployeeCode, ArabicName = @ArabicName, EnglishName = @EnglishName, NationalID = @NationalID, " &
            "Phone = @Phone, Phone2 = @Phone2, Email = @Email, Address = @Address, BirthDate = @BirthDate, Gender = @Gender, " &
            "BranchID = @BranchID, DepartmentID = @DepartmentID, JobTitleID = @JobTitleID, HireDate = @HireDate, " &
            "ContractEndDate = @ContractEndDate, FingerprintCode = @FingerprintCode, EmployeeStatus = @EmployeeStatus, Notes = @Notes, " &
            "CheckInTime = @CheckInTime, CheckOutTime = @CheckOutTime, DailyWorkingHours = @DailyWorkingHours, SalarySystemID = @SalarySystemID, " &
            "BasicSalary = @BasicSalary, TransportationAllowance = @TransportationAllowance, HousingAllowance = @HousingAllowance, " &
            "OtherAllowances = @OtherAllowances, InsuranceStatus = @InsuranceStatus, InsuranceAmount = @InsuranceAmount, " &
            "OvertimeAllowed = @OvertimeAllowed, OvertimeRate = @OvertimeRate, IsActive = @IsActive, " &
            "PersonalPhoto = @PersonalPhoto, NationalIDPhotofront = @NationalIDPhotofront, NationalIDPhotoback = @NationalIDPhotoback " &
            "WHERE EmployeeID = @EmployeeID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@EmployeeID", empID)
                AddEmployeeParameters(cmd)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    ' Invalidate cache and reload
                    _cachedEmployees = Nothing
                    LoadEmployeesGrid()
                    ClearFields()

                    MessageBox.Show("تم تحديث بيانات الموظف بنجاح 🟢", "نجاح التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("حدث خطأ أثناء تعديل بيانات الموظف: " & ex.Message, "خطأ SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' --- SOFT DELETE ---
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("الرجاء اختيار الموظف المراد حذفه من القائمة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim empName As String = GetCellString(dgvEmployees.SelectedRows(0), "ArabicName")
        If MessageBox.Show($"هل أنت متأكد من حذف الموظف [{empName}]؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim empID As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("EmployeeID").Value)
            Dim query As String = "UPDATE Employees SET IsDeleted = 1 WHERE EmployeeID = @EmployeeID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@EmployeeID", empID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()

                        ' Invalidate cache and reload
                        _cachedEmployees = Nothing
                        LoadEmployeesGrid()
                        ClearFields()

                        MessageBox.Show("تم حذف الموظف بنجاح 🗑️", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' Helper to populate command parameters with strict DB schema compliance (NO NULL errors)
    Private Sub AddEmployeeParameters(cmd As SqlCommand)
        cmd.Parameters.AddWithValue("@EmployeeCode", If(String.IsNullOrWhiteSpace(txtEmployeeCode.Text), GenerateAutoEmployeeCode(), txtEmployeeCode.Text.Trim()))
        cmd.Parameters.AddWithValue("@ArabicName", txtArabicName.Text.Trim())
        cmd.Parameters.AddWithValue("@EnglishName", GetDbValue(txtEnglishName.Text))
        cmd.Parameters.AddWithValue("@NationalID", GetDbValue(txtNationalID.Text))
        cmd.Parameters.AddWithValue("@Phone", GetDbValue(txtPhone.Text))
        cmd.Parameters.AddWithValue("@Phone2", GetDbValue(txtPhone2.Text))
        cmd.Parameters.AddWithValue("@Email", GetDbValue(txtEmail.Text))
        cmd.Parameters.AddWithValue("@Address", GetDbValue(txtAddress.Text))
        cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value.Date)
        cmd.Parameters.AddWithValue("@Gender", GetGenderDbValue())

        cmd.Parameters.AddWithValue("@BranchID", GetDbComboValue(cmbBranch))
        cmd.Parameters.AddWithValue("@DepartmentID", GetDbComboValue(cmbDepartment))
        cmd.Parameters.AddWithValue("@JobTitleID", GetDbComboValue(cmbJobTitle))
        cmd.Parameters.AddWithValue("@HireDate", dtpHireDate.Value.Date)
        cmd.Parameters.AddWithValue("@ContractEndDate", dtpContractEndDate.Value.Date)
        cmd.Parameters.AddWithValue("@FingerprintCode", GetDbValue(txtFingerprintCode.Text))
        cmd.Parameters.AddWithValue("@EmployeeStatus", GetEmployeeStatusDbValue())
        cmd.Parameters.AddWithValue("@Notes", GetDbValue(txtNotes.Text))

        cmd.Parameters.AddWithValue("@CheckInTime", dtpCheckInTime.Value.TimeOfDay)
        cmd.Parameters.AddWithValue("@CheckOutTime", dtpCheckOutTime.Value.TimeOfDay)
        cmd.Parameters.AddWithValue("@DailyWorkingHours", GetDbNullableDecimal(txtDailyWorkingHours.Text))

        cmd.Parameters.AddWithValue("@SalarySystemID", GetDbComboValue(cmbSalarySystem))

        ' Financial Fields: NOT NULL in DB schema with DEFAULT 0.00 -> Never send NULL!
        cmd.Parameters.AddWithValue("@BasicSalary", GetDbNotNullDecimal(txtBasicSalary.Text))
        cmd.Parameters.AddWithValue("@TransportationAllowance", GetDbNotNullDecimal(txtTransAllowance.Text))
        cmd.Parameters.AddWithValue("@HousingAllowance", GetDbNotNullDecimal(txtHousingAllowance.Text))
        cmd.Parameters.AddWithValue("@OtherAllowances", GetDbNotNullDecimal(txtOtherAllowance.Text))

        cmd.Parameters.AddWithValue("@InsuranceStatus", tgInsuranceStatus.Checked)
        cmd.Parameters.AddWithValue("@InsuranceAmount", GetDbNotNullDecimal(txtInsuranceAmount.Text))
        cmd.Parameters.AddWithValue("@OvertimeAllowed", tgOvertimeAllowed.Checked)
        cmd.Parameters.AddWithValue("@OvertimeRate", GetDbNotNullDecimal(txtOvertimeRate.Text))
        cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

        ' Base64 Image Conversions
        cmd.Parameters.AddWithValue("@PersonalPhoto", GetDbValue(DBModule.ImageToBase64(picEmployee.Image)))
        cmd.Parameters.AddWithValue("@NationalIDPhotofront", GetDbValue(DBModule.ImageToBase64(picNationalFront.Image)))
        cmd.Parameters.AddWithValue("@NationalIDPhotoback", GetDbValue(DBModule.ImageToBase64(picNationalBack.Image)))
    End Sub

    Private Function GetGenderDbValue() As Object
        If cmbGender.Text.Trim() = "ذكر" Then Return CByte(1)
        If cmbGender.Text.Trim() = "أنثى" Then Return CByte(2)
        Return DBNull.Value
    End Function

    Private Function GetEmployeeStatusDbValue() As Object
        Select Case cmbEmployeeStatus.Text.Trim()
            Case "على رأس العمل", "يعمل" : Return CByte(1)
            Case "إجازة" : Return CByte(2)
            Case "مستقيل" : Return CByte(3)
            Case "موقوف" : Return CByte(4)
            Case "مفصول" : Return CByte(5)
            Case Else : Return CByte(1)
        End Select
    End Function

    Private Function GetDbValue(str As String) As Object
        If String.IsNullOrWhiteSpace(str) Then Return DBNull.Value
        Return str.Trim()
    End Function

    Private Function GetDbComboValue(cmb As Guna.UI2.WinForms.Guna2ComboBox) As Object
        If cmb.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmb.SelectedValue) AndAlso IsNumeric(cmb.SelectedValue) Then
            Return Convert.ToInt32(cmb.SelectedValue)
        End If
        Return DBNull.Value
    End Function

    ' Returns 0.00D for NOT NULL Decimal columns if input is empty or invalid
    Private Function GetDbNotNullDecimal(str As String, Optional defaultValue As Decimal = 0D) As Decimal
        If String.IsNullOrWhiteSpace(str) Then Return defaultValue
        Dim val As Decimal
        If Decimal.TryParse(str.Trim(), val) Then
            Return val
        End If
        Return defaultValue
    End Function

    ' Returns DBNull.Value for NULLABLE Decimal columns if input is empty
    Private Function GetDbNullableDecimal(str As String) As Object
        If String.IsNullOrWhiteSpace(str) Then Return DBNull.Value
        Dim val As Decimal
        If Decimal.TryParse(str.Trim(), val) Then
            Return val
        End If
        Return DBNull.Value
    End Function

    Private Function GetDbDecimalValue(str As String) As Object
        Dim val As Decimal
        If Decimal.TryParse(str, val) Then
            Return val
        End If
        Return DBNull.Value
    End Function

    ' =========================================================================
    ' 10. Clear & Refresh Button Handlers
    ' =========================================================================
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedEmployees = Nothing
        txtSearch.Clear()
        LoadEmployeesGrid()
    End Sub

    ' =========================================================================
    ' 11. Image Upload & Remove Helper Handlers
    ' =========================================================================
    Private Sub btnUploadPhoto_Click(sender As Object, e As EventArgs) Handles btnUploadPhoto.Click
        UploadImageToPictureBox(picEmployee)
    End Sub

    Private Sub btnRemovePhoto_Click(sender As Object, e As EventArgs) Handles btnRemovePhoto.Click
        picEmployee.Image = Nothing
    End Sub

    Private Sub picNationalFront_Click(sender As Object, e As EventArgs) Handles picNationalFront.Click
        UploadImageToPictureBox(picNationalFront)
    End Sub

    Private Sub picNationalBack_Click(sender As Object, e As EventArgs) Handles picNationalBack.Click
        UploadImageToPictureBox(picNationalBack)
    End Sub

    Private Sub UploadImageToPictureBox(pic As Guna.UI2.WinForms.Guna2PictureBox)
        Using ofd As New OpenFileDialog()
            ofd.Filter = "ملفات الصور (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
            ofd.Title = "اختر صورة"
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Using tempImg As Image = Image.FromFile(ofd.FileName)
                        pic.Image = New Bitmap(tempImg)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("خطأ في تحميل الصورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    ' =========================================================================
    ' 12. Quick Add Modal Dialog Forms Buttons
    ' =========================================================================
    Private Sub btnAddDepartmentForm_Click(sender As Object, e As EventArgs) Handles btnAddDepartmentForm.Click
        Dim frm As New frmDepartments()
        frm.ShowDialog()
        FillDropdowns()
    End Sub

    Private Sub btnAddJobTitleForm_Click(sender As Object, e As EventArgs) Handles btnAddJobTitleForm.Click
        Dim frm As New frmJobTitles()
        frm.ShowDialog()
        If cmbDepartment.SelectedValue IsNot Nothing Then
            cmbDepartment_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnAddSalarySystemForm_Click(sender As Object, e As EventArgs) Handles btnAddSalarySystemForm.Click
        Dim frm As New frmSalarySystems()
        frm.ShowDialog()
        FillDropdowns()
    End Sub

    Private Sub btnAddBranchesForm_Click(sender As Object, e As EventArgs) Handles btnAddBranchesForm.Click
        Dim frm As New frmBranches()
        frm.ShowDialog()
        FillDropdowns()
    End Sub

    ' =========================================================================
    ' 13. UI Layout & DataGridView Styling
    ' =========================================================================
    Private Sub SetupDataGridViewStyle()
        DBModule.EnableDoubleBuffer(dgvEmployees)
        Main.datagridviewsetup(dgvEmployees)
    End Sub

    ' =========================================================================
    ' 14. Title Bar Window Management
    ' =========================================================================
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        Else
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        Me.WindowState = FormWindowState.Minimized
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

End Class