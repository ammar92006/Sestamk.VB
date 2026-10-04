Imports System.Data.SqlClient

Public Class frmRolesAndPermissions

    Private _selectedRoleID As Integer? = Nothing
    Private _dragHelper As FormDragHelper = Nothing
    Private _isUpdatingSelectAll As Boolean = False

    Private Sub frmRolesAndPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' منع تحريك الفورم من المساحات البيضاء الفارغة وحصره في الهيدر فقط
        Guna2BorderlessForm1.DragForm = False
        _dragHelper = New FormDragHelper(Me, panelHeader)

        SetupPermissionsGrid()
        LoadRolesList()
        datagridviewsetup(dgvPermissions)
        dgvPermissions.ReadOnly = False
    End Sub

    ' 1. تهيئة أعمدة جدول الصلاحيات برمجياً (الصلاحيات الأربعة الأساسية فقط)
    Private Sub SetupPermissionsGrid()
        With dgvPermissions
            .AutoGenerateColumns = False
            .Columns.Clear()
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect

            ' الأعمدة التعريفية
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FormName", .DataPropertyName = "FormName", .Visible = False})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Category", .DataPropertyName = "Category", .HeaderText = "القسم", .ReadOnly = True, .Width = 140})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ScreenDisplayName", .DataPropertyName = "ScreenDisplayName", .HeaderText = "الشاشة / الوظيفة", .ReadOnly = True, .Width = 240})

            ' أعمدة الصلاحيات الأساسية (CheckBoxes)
            .Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "CanOpen", .DataPropertyName = "CanOpen", .HeaderText = "عرض/فتح", .Width = 85})
            .Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "CanAdd", .DataPropertyName = "CanAdd", .HeaderText = "إضافة", .Width = 80})
            .Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "CanEdit", .DataPropertyName = "CanEdit", .HeaderText = "تعديل", .Width = 80})
            .Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "CanDelete", .DataPropertyName = "CanDelete", .HeaderText = "حذف", .Width = 80})
        End With
    End Sub

    ' 2. تحميل قائمة الأدوار في الكومبوبوكس
    Private Sub LoadRolesList(Optional selectRoleID As Integer? = Nothing)
        Try
            Dim dt As DataTable = DBModule.ExecuteQuery("SELECT RoleID, RoleName, Description FROM Roles ORDER BY RoleID ASC")
            If dt IsNot Nothing Then
                cmbRole.DataSource = dt
                cmbRole.DisplayMember = "RoleName"
                cmbRole.ValueMember = "RoleID"

                If selectRoleID.HasValue Then
                    cmbRole.SelectedValue = selectRoleID.Value
                ElseIf dt.Rows.Count > 0 Then
                    cmbRole.SelectedIndex = 0
                Else
                    cmbRole.SelectedIndex = -1
                    _selectedRoleID = Nothing
                    txtRoleName.Clear()
                    txtRoleDescription.Clear()
                    dgvPermissions.DataSource = Nothing
                End If
            End If
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل الأدوار: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 3. عند تغيير الدور المختار من الكومبوبوكس
    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        If cmbRole.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbRole.SelectedValue.ToString(), Nothing) Then
            _selectedRoleID = Convert.ToInt32(cmbRole.SelectedValue)
            If TypeOf cmbRole.SelectedItem Is DataRowView Then
                Dim drv As DataRowView = CType(cmbRole.SelectedItem, DataRowView)
                txtRoleName.Text = drv("RoleName").ToString()
                txtRoleDescription.Text = If(IsDBNull(drv("Description")), "", drv("Description").ToString())
            End If
            LoadPermissionsForRole(_selectedRoleID.Value)
        End If
    End Sub

    ' 4. تحميل الصلاحيات الأربعة للدور المحدد
    Private Sub LoadPermissionsForRole(roleID As Integer)
        Try
            Dim query As String = "SELECT S.FormName, S.Category, S.ScreenDisplayName, " &
                                  "ISNULL(P.CanOpen, 0) AS CanOpen, " &
                                  "ISNULL(P.CanAdd, 0) AS CanAdd, " &
                                  "ISNULL(P.CanEdit, 0) AS CanEdit, " &
                                  "ISNULL(P.CanDelete, 0) AS CanDelete " &
                                  "FROM AppScreens S " &
                                  "LEFT JOIN Permissions P ON S.FormName = P.FormName AND P.RoleID = @RoleID " &
                                  "ORDER BY S.Category ASC, S.ScreenID ASC"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@RoleID", roleID)
                    Using da As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        dgvPermissions.DataSource = dt
                    End Using
                End Using
            End Using

            UpdateSelectAllState()
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل الصلاحيات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 5. حفظ الصلاحيات المعدلة للدور المختار مع تحديث اسم ووصف الدور
    Private Sub btnSavePermissions_Click(sender As Object, e As EventArgs) Handles btnSavePermissions.Click
        If Not _selectedRoleID.HasValue Then
            SmartMessageBox.Show("يرجى اختيار دور وظيفي أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        dgvPermissions.EndEdit()

        Using conn As New SqlConnection(DBModule.ConnectionString)
            conn.Open()
            Using trans As SqlTransaction = conn.BeginTransaction()
                Try
                    ' 1. تحديث اسم ووصف الدور المختار إذا تم تعديله
                    If Not String.IsNullOrWhiteSpace(txtRoleName.Text) Then
                        Dim updateRoleSql As String = "UPDATE Roles SET RoleName = @Name, Description = @Desc WHERE RoleID = @RoleID"
                        Using cmdRole As New SqlCommand(updateRoleSql, conn, trans)
                            cmdRole.Parameters.AddWithValue("@Name", txtRoleName.Text.Trim())
                            cmdRole.Parameters.AddWithValue("@Desc", If(String.IsNullOrWhiteSpace(txtRoleDescription.Text), DBNull.Value, txtRoleDescription.Text.Trim()))
                            cmdRole.Parameters.AddWithValue("@RoleID", _selectedRoleID.Value)
                            cmdRole.ExecuteNonQuery()
                        End Using
                    End If

                    ' 2. حفظ الصلاحيات الأربعة لكل شاشة
                    Dim permSql As String =
                        "IF EXISTS (SELECT 1 FROM Permissions WHERE RoleID = @RoleID AND FormName = @FormName) " &
                        "    UPDATE Permissions SET CanOpen = @CanOpen, CanAdd = @CanAdd, CanEdit = @CanEdit, CanDelete = @CanDelete " &
                        "    WHERE RoleID = @RoleID AND FormName = @FormName; " &
                        "ELSE " &
                        "    INSERT INTO Permissions (RoleID, FormName, CanOpen, CanAdd, CanEdit, CanDelete) " &
                        "    VALUES (@RoleID, @FormName, @CanOpen, @CanAdd, @CanEdit, @CanDelete);"

                    For Each row As DataGridViewRow In dgvPermissions.Rows
                        If row.IsNewRow Then Continue For

                        Using cmd As New SqlCommand(permSql, conn, trans)
                            cmd.Parameters.AddWithValue("@RoleID", _selectedRoleID.Value)
                            cmd.Parameters.AddWithValue("@FormName", row.Cells("FormName").Value.ToString())
                            cmd.Parameters.AddWithValue("@CanOpen", Convert.ToBoolean(row.Cells("CanOpen").Value))
                            cmd.Parameters.AddWithValue("@CanAdd", Convert.ToBoolean(row.Cells("CanAdd").Value))
                            cmd.Parameters.AddWithValue("@CanEdit", Convert.ToBoolean(row.Cells("CanEdit").Value))
                            cmd.Parameters.AddWithValue("@CanDelete", Convert.ToBoolean(row.Cells("CanDelete").Value))
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    trans.Commit()

                    ' إذا كان الدور المحفوظ هو دور المستخدم المسجل حالياً، نعيد تحميل الصلاحيات فوراً
                    If _selectedRoleID.HasValue AndAlso _selectedRoleID.Value = Session.CurrentRoleID Then
                        Session.LoadPermissions(Session.CurrentRoleID)
                    End If

                    SmartMessageBox.Show("تم حفظ الدور والصلاحيات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim currentID As Integer = _selectedRoleID.Value
                    LoadRolesList(currentID)
                Catch ex As Exception
                    trans.Rollback()
                    SmartMessageBox.Show("حدث خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 6. إضافة دور جديد
    Private Sub btnAddRole_Click(sender As Object, e As EventArgs) Handles btnAddRole.Click
        Dim roleName As String = txtRoleName.Text.Trim()
        If String.IsNullOrWhiteSpace(roleName) Then
            SmartMessageBox.Show("يرجى كتابة اسم الدور الجديد أولاً في خانة (اسم الدور)!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoleName.Focus()
            Exit Sub
        End If

        ' التحقق من عدم تكرار اسم الدور
        Dim checkSql As String = "SELECT COUNT(1) FROM Roles WHERE RoleName = @Name"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            conn.Open()
            Using cmdCheck As New SqlCommand(checkSql, conn)
                cmdCheck.Parameters.AddWithValue("@Name", roleName)
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0 Then
                    SmartMessageBox.Show("اسم الدور موجود بالفعل! يرجى اختيار اسم آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtRoleName.Focus()
                    Exit Sub
                End If
            End Using

            Dim insertSql As String = "INSERT INTO Roles (RoleName, Description) VALUES (@Name, @Desc); SELECT SCOPE_IDENTITY();"
            Using cmd As New SqlCommand(insertSql, conn)
                cmd.Parameters.AddWithValue("@Name", roleName)
                cmd.Parameters.AddWithValue("@Desc", If(String.IsNullOrWhiteSpace(txtRoleDescription.Text), DBNull.Value, txtRoleDescription.Text.Trim()))

                Try
                    Dim newID As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    SmartMessageBox.Show("تمت إضافة الدور بنجاح! يمكنك الآن تحديد صلاحياته ثم الضغط على (حفظ الصلاحيات).", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadRolesList(newID)
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء إضافة الدور: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. حذف دور وظيفي
    Private Sub btnDeleteRole_Click(sender As Object, e As EventArgs) Handles btnDeleteRole.Click
        If Not _selectedRoleID.HasValue Then
            SmartMessageBox.Show("يرجى اختيار دور لحذفه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If _selectedRoleID.Value = 1 Then
            SmartMessageBox.Show("لا يمكن حذف دور (مدير النظام) الأساسي لحماية البرنامج!", "محظور", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' التحقق من عدم وجود مستخدمين مسجلين بهذا الدور
        Dim userCountObj As Object = DBModule.ExecuteScalar($"SELECT COUNT(1) FROM Users_TBL WHERE RoleID = {_selectedRoleID.Value} AND (IsDeleted = 0 OR IsDeleted IS NULL)")
        Dim countUsers As Integer = If(userCountObj IsNot Nothing AndAlso Not IsDBNull(userCountObj), Convert.ToInt32(userCountObj), 0)
        If countUsers > 0 Then
            SmartMessageBox.Show($"لا يمكن حذف هذا الدور لوجود ({countUsers}) مستخدمين مرتبطين به حالياً! يرجى تغيير دور هؤلاء المستخدمين أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If SmartMessageBox.Show("هل أنت متأكد من حذف هذا الدور وكافة صلاحياته؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Using conn As New SqlConnection(DBModule.ConnectionString)
                conn.Open()
                Using trans As SqlTransaction = conn.BeginTransaction()
                    Try
                        ' حذف صلاحيات الدور أولاً لمنع البيانات اليتيمة
                        Using cmdPerm As New SqlCommand("DELETE FROM Permissions WHERE RoleID = @RoleID", conn, trans)
                            cmdPerm.Parameters.AddWithValue("@RoleID", _selectedRoleID.Value)
                            cmdPerm.ExecuteNonQuery()
                        End Using

                        ' حذف الدور من جدول الأدوار
                        Using cmdRole As New SqlCommand("DELETE FROM Roles WHERE RoleID = @RoleID", conn, trans)
                            cmdRole.Parameters.AddWithValue("@RoleID", _selectedRoleID.Value)
                            cmdRole.ExecuteNonQuery()
                        End Using

                        trans.Commit()
                        SmartMessageBox.Show("تم حذف الدور وصلاحياته بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _selectedRoleID = Nothing
                        txtRoleName.Clear()
                        txtRoleDescription.Clear()
                        LoadRolesList()
                    Catch ex As Exception
                        trans.Rollback()
                        SmartMessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' 8. كبسولة تحديد الكل أو إلغاء التحديد لكافة الصلاحيات
    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        If _isUpdatingSelectAll Then Exit Sub
        Dim state As Boolean = chkSelectAll.Checked
        For Each row As DataGridViewRow In dgvPermissions.Rows
            row.Cells("CanOpen").Value = state
            row.Cells("CanAdd").Value = state
            row.Cells("CanEdit").Value = state
            row.Cells("CanDelete").Value = state
        Next
    End Sub

    ' فحص ما إذا كانت كل الصلاحيات مفعلة لضبط حالة الكبسولة
    Private Sub UpdateSelectAllState()
        If dgvPermissions.Rows.Count = 0 Then
            _isUpdatingSelectAll = True
            chkSelectAll.Checked = False
            _isUpdatingSelectAll = False
            Exit Sub
        End If

        Dim allChecked As Boolean = True
        For Each row As DataGridViewRow In dgvPermissions.Rows
            If Not Convert.ToBoolean(row.Cells("CanOpen").Value) OrElse
               Not Convert.ToBoolean(row.Cells("CanAdd").Value) OrElse
               Not Convert.ToBoolean(row.Cells("CanEdit").Value) OrElse
               Not Convert.ToBoolean(row.Cells("CanDelete").Value) Then
                allChecked = False
                Exit For
            End If
        Next

        _isUpdatingSelectAll = True
        chkSelectAll.Checked = allChecked
        _isUpdatingSelectAll = False
    End Sub

    Private Sub dgvPermissions_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermissions.CellValueChanged
        If e.RowIndex >= 0 Then
            UpdateSelectAllState()
        End If
    End Sub

    Private Sub dgvPermissions_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvPermissions.CurrentCellDirtyStateChanged
        If dgvPermissions.IsCurrentCellDirty Then
            dgvPermissions.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
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