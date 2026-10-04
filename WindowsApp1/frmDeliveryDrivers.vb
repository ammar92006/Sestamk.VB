Imports System.Data.SqlClient

Public Class frmDeliveryDrivers

    Private _cachedDrivers As DataTable = Nothing

    ' 1. تعبئة القوائم المنسدلة (نوع المركبة + الموظفين)
    Private Sub FillDropdowns()
        Try
            ' تعبئة نوع المركبة
            cmbVehicleType.Items.Clear()
            cmbVehicleType.Items.AddRange(New Object() {"موتوسيكل", "فيسبا", "سكوتر", "سيارة", "عجلة/دراجة", "أخرى"})
            cmbVehicleType.SelectedIndex = -1

            ' تعبئة معايير البحث
            cmbSearchField.Items.Clear()
            cmbSearchField.Items.AddRange(New Object() {"الاسم", "الكود", "الهاتف"})
            cmbSearchField.SelectedIndex = 0

            ' تعبئة الموظفين المرتبطين
            Dim dt As DataTable = DBModule.ExecuteQuery("SELECT EmployeeID, ArabicName FROM Employees WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL)")
            If dt IsNot Nothing Then
                cmbEmployee.DataSource = dt
                cmbEmployee.DisplayMember = "ArabicName"
                cmbEmployee.ValueMember = "EmployeeID"
                cmbEmployee.SelectedIndex = -1
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading dropdowns for drivers: " & ex.Message)
        End Try
    End Sub
    ' دالة جلب المناطق المتاحة
    Private Sub FillAreasDropdown()
        Try
            Dim dt As DataTable = DBModule.ExecuteQuery("SELECT AreaID, AreaName FROM DeliveryAreas WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL)")
            If dt IsNot Nothing Then
                cmbArea.DataSource = dt
                cmbArea.DisplayMember = "AreaName"
                cmbArea.ValueMember = "AreaID"
                cmbArea.SelectedIndex = -1
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading areas: " & ex.Message)
        End Try
    End Sub

    ' 2. تحميل الجريد فيو مع الدعم للـ Live Search والتخزين في الذاكرة
    Private Sub LoadDriversGrid(Optional filter As String = "", Optional field As String = "")
        Try
            If _cachedDrivers Is Nothing OrElse (String.IsNullOrEmpty(filter) AndAlso String.IsNullOrEmpty(field)) Then
                Dim query As String = "SELECT D.DriverID, D.DriverCode, D.DriverName, D.Phone, D.VehicleType, D.VehiclePlateNumber, " &
                                      "D.IsPercentage, D.DeliveryFeeValue, D.DriverStatus,D.AreaID, D.IsActive, D.EmployeeID, D.Notes, D.NationalID, D.LicenseNumber " &
                                      "FROM DeliveryDrivers D WHERE D.IsDeleted = 0 OR D.IsDeleted IS NULL"

                _cachedDrivers = DBModule.ExecuteQuery(query)
            End If

            If _cachedDrivers Is Nothing Then Exit Sub

            Dim dtToBind As DataTable = _cachedDrivers

            ' الفلترة التفاعلية في الذاكرة
            If Not String.IsNullOrEmpty(filter) AndAlso Not String.IsNullOrEmpty(field) Then
                Dim col As String = ""
                Select Case field.Trim()
                    Case "الاسم" : col = "DriverName"
                    Case "الكود" : col = "DriverCode"
                    Case "الهاتف" : col = "Phone"
                End Select

                If col <> "" AndAlso _cachedDrivers.Columns.Contains(col) Then
                    Dim dv As New DataView(_cachedDrivers)
                    dv.RowFilter = $"{col} LIKE '%{filter.Replace("'", "''")}%'"
                    dtToBind = dv.ToTable()
                End If
            End If

            dgvDrivers.DataSource = dtToBind

            ' إخفاء الحقول غير الأساسية في العرض المباشر
            Dim hiddenCols As String() = {"DriverID", "EmployeeID", "Notes", "NationalID", "LicenseNumber", "DriverStatus"}
            For Each c In hiddenCols
                If dgvDrivers.Columns.Contains(c) Then dgvDrivers.Columns(c).Visible = False
            Next

            ' تسمية الأعمدة بالعربية
            If dgvDrivers.Columns.Contains("DriverCode") Then dgvDrivers.Columns("DriverCode").HeaderText = "كود الطيار"
            If dgvDrivers.Columns.Contains("DriverName") Then dgvDrivers.Columns("DriverName").HeaderText = "اسم الطيار"
            If dgvDrivers.Columns.Contains("Phone") Then dgvDrivers.Columns("Phone").HeaderText = "الهاتف"
            If dgvDrivers.Columns.Contains("VehicleType") Then dgvDrivers.Columns("VehicleType").HeaderText = "نوع المركبة"
            If dgvDrivers.Columns.Contains("VehiclePlateNumber") Then dgvDrivers.Columns("VehiclePlateNumber").HeaderText = "رقم اللوحة"
            If dgvDrivers.Columns.Contains("DeliveryFeeValue") Then dgvDrivers.Columns("DeliveryFeeValue").HeaderText = "العمولة"
            If dgvDrivers.Columns.Contains("IsPercentage") Then dgvDrivers.Columns("IsPercentage").HeaderText = "نسبة %"
            If dgvDrivers.Columns.Contains("IsActive") Then dgvDrivers.Columns("IsActive").HeaderText = "نشط"

        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل قائمة الطيارين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 3. دالة تفريغ الحقول
    Private Sub ClearFields()
        txtDriverCode.Text = GetNextCode("DeliveryDrivers", "DriverCode").ToString()
        txtDriverName.Clear()
        txtPhone.Clear()
        txtNationalID.Clear()
        txtLicenseNumber.Clear()
        cmbVehicleType.SelectedIndex = -1
        cmbArea.SelectedIndex = -1
        txtVehiclePlateNumber.Clear()
        txtDeliveryFeeValue.Text = "0.00"

        ' زرار الـ Toggle العادي (btnTogglePercentage): Checked = True تعني نسبة %
        btnTogglePercentage.Checked = False
        UpdatePercentageButtonVisuals()

        cmbEmployee.SelectedIndex = -1
        txtNotes.Clear()
        tgStatus.Checked = True
        dgvDrivers.ClearSelection()
    End Sub

    ' تحديث المظهر البصري لزر التوجل للتوضيح للمستخدم
    Private Sub UpdatePercentageButtonVisuals()
        If btnTogglePercentage.Checked Then
            btnTogglePercentage.Text = "% نسبة"
            btnTogglePercentage.FillColor = Color.FromArgb(39, 174, 96) ' أخضر عند تفعيل النسبة
        Else
            btnTogglePercentage.Text = "ج.م ثابت"
            btnTogglePercentage.FillColor = Color.FromArgb(41, 128, 185) ' أزرق عند اختيار المبلغ الثابت
        End If
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtDriverCode.Text) Then
            txtDriverCode.Text = GetNextCode("DeliveryDrivers", "DriverCode").ToString()
        End If
        If String.IsNullOrWhiteSpace(txtDriverName.Text) OrElse String.IsNullOrWhiteSpace(txtPhone.Text) Then
            SmartMessageBox.Show("يرجى كتابة اسم الطيار ورقم الهاتف كحد أدنى!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub frmDeliveryDrivers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDropdowns()
        LoadDriversGrid()
        FillAreasDropdown()
        datagridviewsetup(dgvDrivers)

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' 4. حدث الضغط على زر الـ Toggle لتغيير المظهر ديناميكياً
    Private Sub btnTogglePercentage_Click(sender As Object, e As EventArgs) Handles btnTogglePercentage.Click
        UpdatePercentageButtonVisuals()
    End Sub

    ' 5. عرض البيانات عند تحديد طيار من الجدول
    Private Sub dgvDrivers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDrivers.SelectionChanged
        If dgvDrivers.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvDrivers.SelectedRows(0)

        If row.Cells("DriverID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("DriverID").Value) Then
            txtDriverCode.Text = If(IsDBNull(row.Cells("DriverCode").Value), "", row.Cells("DriverCode").Value.ToString())
            txtDriverName.Text = If(IsDBNull(row.Cells("DriverName").Value), "", row.Cells("DriverName").Value.ToString())
            txtPhone.Text = If(IsDBNull(row.Cells("Phone").Value), "", row.Cells("Phone").Value.ToString())
            cmbVehicleType.Text = If(IsDBNull(row.Cells("VehicleType").Value), "", row.Cells("VehicleType").Value.ToString())
            txtVehiclePlateNumber.Text = If(IsDBNull(row.Cells("VehiclePlateNumber").Value), "", row.Cells("VehiclePlateNumber").Value.ToString())
            txtDeliveryFeeValue.Text = If(IsDBNull(row.Cells("DeliveryFeeValue").Value), "0.00", row.Cells("DeliveryFeeValue").Value.ToString())
            txtNationalID.Text = If(IsDBNull(row.Cells("NationalID").Value), "", row.Cells("NationalID").Value.ToString())
            txtLicenseNumber.Text = If(IsDBNull(row.Cells("LicenseNumber").Value), "", row.Cells("LicenseNumber").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            If Not IsDBNull(row.Cells("AreaID").Value) Then cmbArea.SelectedValue = row.Cells("AreaID").Value Else cmbArea.SelectedIndex = -1
            ' تعيين حالة زرار الـ Toggle العادي
            btnTogglePercentage.Checked = If(IsDBNull(row.Cells("IsPercentage").Value), False, Convert.ToBoolean(row.Cells("IsPercentage").Value))
            UpdatePercentageButtonVisuals()

            If Not IsDBNull(row.Cells("EmployeeID").Value) Then cmbEmployee.SelectedValue = row.Cells("EmployeeID").Value Else cmbEmployee.SelectedIndex = -1
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' 6. زر إضافة طيار جديد
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim feeVal As Decimal = 0
        Decimal.TryParse(txtDeliveryFeeValue.Text, feeVal)

        Dim query As String = "INSERT INTO DeliveryDrivers (DriverCode, DriverName, Phone, NationalID, EmployeeID, LicenseNumber, " &
                              "VehicleType, VehiclePlateNumber, IsPercentage, DeliveryFeeValue,AreaID, DriverStatus, Notes, IsActive, IsDeleted) " &
                              "VALUES (@Code, @Name, @Phone, @NationalID, @EmployeeID, @LicenseNumber, " &
                              "@VehicleType, @PlateNumber, @IsPercentage, @FeeValue,@AreaID, 1, @Notes, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtDriverCode.Text), GetNextCode("DeliveryDrivers", "DriverCode").ToString(), txtDriverCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtDriverName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                cmd.Parameters.AddWithValue("@NationalID", If(String.IsNullOrEmpty(txtNationalID.Text), DBNull.Value, txtNationalID.Text.Trim()))
                cmd.Parameters.AddWithValue("@EmployeeID", If(cmbEmployee.SelectedValue Is Nothing, DBNull.Value, cmbEmployee.SelectedValue))
                cmd.Parameters.AddWithValue("@LicenseNumber", If(String.IsNullOrEmpty(txtLicenseNumber.Text), DBNull.Value, txtLicenseNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@VehicleType", If(cmbVehicleType.SelectedItem Is Nothing, DBNull.Value, cmbVehicleType.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@PlateNumber", If(String.IsNullOrEmpty(txtVehiclePlateNumber.Text), DBNull.Value, txtVehiclePlateNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsPercentage", btnTogglePercentage.Checked)
                cmd.Parameters.AddWithValue("@FeeValue", feeVal)
                cmd.Parameters.AddWithValue("@AreaID", If(cmbArea.SelectedValue Is Nothing, DBNull.Value, cmbArea.SelectedValue))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    SmartMessageBox.Show("تم حفظ بيانات الطيار بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedDrivers = Nothing
                    LoadDriversGrid()
                    ClearFields()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. زر تعديل طيار
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvDrivers.SelectedRows.Count = 0 OrElse Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvDrivers.SelectedRows(0).Cells("DriverID").Value)
        Dim feeVal As Decimal = 0
        Decimal.TryParse(txtDeliveryFeeValue.Text, feeVal)

        Dim query As String = "UPDATE DeliveryDrivers SET DriverCode=@Code, DriverName=@Name, Phone=@Phone, NationalID=@NationalID, " &
                              "EmployeeID=@EmployeeID, LicenseNumber=@LicenseNumber, VehicleType=@VehicleType, " &
                              "VehiclePlateNumber=@PlateNumber, IsPercentage=@IsPercentage, DeliveryFeeValue=@FeeValue, AreaID=@AreaID, " &
                              "Notes=@Notes, IsActive=@IsActive WHERE DriverID=@DriverID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@DriverID", currentID)
                cmd.Parameters.AddWithValue("@Code", txtDriverCode.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txtDriverName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                cmd.Parameters.AddWithValue("@NationalID", If(String.IsNullOrEmpty(txtNationalID.Text), DBNull.Value, txtNationalID.Text.Trim()))
                cmd.Parameters.AddWithValue("@EmployeeID", If(cmbEmployee.SelectedValue Is Nothing, DBNull.Value, cmbEmployee.SelectedValue))
                cmd.Parameters.AddWithValue("@LicenseNumber", If(String.IsNullOrEmpty(txtLicenseNumber.Text), DBNull.Value, txtLicenseNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@VehicleType", If(cmbVehicleType.SelectedItem Is Nothing, DBNull.Value, cmbVehicleType.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@PlateNumber", If(String.IsNullOrEmpty(txtVehiclePlateNumber.Text), DBNull.Value, txtVehiclePlateNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsPercentage", btnTogglePercentage.Checked)
                cmd.Parameters.AddWithValue("@FeeValue", feeVal)
                cmd.Parameters.AddWithValue("@AreaID", If(cmbArea.SelectedValue Is Nothing, DBNull.Value, cmbArea.SelectedValue))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    SmartMessageBox.Show("تم تعديل بيانات الطيار بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _cachedDrivers = Nothing
                    LoadDriversGrid()
                    ClearFields()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 8. زر الحذف الناعم (Soft Delete)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvDrivers.SelectedRows.Count = 0 Then Exit Sub

        If SmartMessageBox.Show("هل أنت متأكد من حذف هذا الطيار؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvDrivers.SelectedRows(0).Cells("DriverID").Value)
            Dim query As String = "UPDATE DeliveryDrivers SET IsDeleted = 1 WHERE DriverID = @DriverID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@DriverID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        SmartMessageBox.Show("تم حذف الطيار بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _cachedDrivers = Nothing
                        LoadDriversGrid()
                        ClearFields()
                    Catch ex As Exception
                        SmartMessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' 9. البحث التفاعلي (Live Search)
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim filter As String = txtSearch.Text.Trim()
        Dim field As String = If(cmbSearchField.SelectedItem?.ToString(), "")
        LoadDriversGrid(filter, field)
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _cachedDrivers = Nothing
        LoadDriversGrid()
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

    Private Sub btnAddAreaForm_Click(sender As Object, e As EventArgs) Handles btnAddAreaForm.Click
        Dim frm As New frmDeliveryAreas()
        frm.ShowDialog()
        FillAreasDropdown() ' إعادة شحن الكومبو بوكس بالمنطقة الجديدة تلقائياً
    End Sub
End Class