Imports System.Data.SqlClient
Imports DevExpress.XtraLayout.Customization

Public Class Staff
    Dim x, y As Integer
    Dim newpoint As New Point
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        datagridviewsetup()
    End Sub

    Private Sub Staff_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
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

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Staff_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub datagridviewsetup()
        With dgv_Staff
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
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
            .AllowUserToResizeRows = True
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False

            ' ✅ ضبط النص في المنتصف داخل الخلايا
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' ✅ إظهار عناوين الأعمدة (لو كانت مخفية)
            .ColumnHeadersVisible = True

            Dim query As String = "SELECT R.RoleID,
                                          R.RoleName,
                                          R.Description,
                                          Per.PermissionID,
                                          Per.FormName,
                                          Per.CanOpen,
                                          Per.CanAdd,
                                          Per.CanEdit,
                                          Per.CanDelete
                                          FROM dbo.Roles AS R
                                          LEFT JOIN Permissions AS Per ON Per.RoleID = R.RoleID"

            .Columns("PermissionID").Visible = False
            .Columns("FormName").Visible = False
            .Columns("CanOpen").Visible = False
            .Columns("CanAdd").Visible = False
            .Columns("CanEdit").Visible = False
            .Columns("CanDelete").Visible = False

            '' ✅ عناوين الأعمدة
            .Columns("RoleID").HeaderText = "كود الموظف"
            .Columns("RoleName").HeaderText = "اسم الموظف"
            .Columns("Description").HeaderText = "الملاحظات"
            '.Columns("User_password").HeaderText = "كلمة المرور"
            '.Columns("User_Stats").HeaderText = "الحالة"
            '.Columns("User_Note").HeaderText = "الملاحظات"
            '.Columns("RoleName").HeaderText = "الموظف"
            '.Columns("User_Barcode_path").HeaderText = "الباركود"

            '' الترتيب
            '.Columns("User_Code").DisplayIndex = 0
            '.Columns("User_Name").DisplayIndex = 1
            '.Columns("User_username").DisplayIndex = 2
            '.Columns("User_password").DisplayIndex = 3
            '.Columns("RoleName").DisplayIndex = 4
            '.Columns("User_Note").DisplayIndex = 5
            '.Columns("User_Barcode_path").DisplayIndex = 6
            '.Columns("User_Stats").DisplayIndex = 7
            '.Columns("Product_State").DisplayIndex = 8
            '.Columns("CustomerName").Width = 300
            '.Columns("IsActive").Width = 60


            ' ✅ عرض الأعمدة بالتساوي
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '' ✅ تحسين مظهر الصفوف
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
            '.DefaultCellStyle.Font = New Font("Segoe UI", 14)
            '.DefaultCellStyle.ForeColor = Color.Black
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255)
            '.DefaultCellStyle.SelectionForeColor = Color.White

            '' ✅ تحسين عناوين الأعمدة
            '.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            '.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 102, 153)
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.EnableHeadersVisualStyles = False   ' ← لازم False علشان التنسيق يبان فعلاً

            '' ✅ حدود الصفوف والخلايا
            '.GridColor = Color.LightGray
            '.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            '.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            '.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            ' ✅ شكل جميل للصفوف
            '.RowTemplate.Height = 100
            .MultiSelect = False
            RemoveDuplicateRowsByID(dgv_Staff, "RoleID")

        End With
    End Sub

    Private Sub LoadUsers(Optional filter As String = "", Optional field As String = "")
        Using Conn
            Dim query As String = "SELECT R.RoleID,
                                          R.RoleName,
                                          R.Description,
                                          Per.PermissionID,
                                          Per.FormName,
                                          Per.CanOpen,
                                          Per.CanAdd,
                                          Per.CanEdit,
                                          Per.CanDelete
                                          FROM dbo.Roles AS R
                                          LEFT JOIN Permissions AS Per ON Per.RoleID = R.RoleID"
            Connect()





            If filter <> "" Then
                Dim columnName As String = ""
                Select Case field
                    Case "كود المستخدم"
                        columnName = "User_Code"
                    Case "الاسم كامل"
                        columnName = "User_Name"
                    Case "اسم المستخدم"
                        columnName = "User_username"
                    Case "كلمة المرور"
                        columnName = "User_password"
                    Case "الحالة"
                        columnName = "User_Stats"
                    Case "الملاحظات"
                        columnName = "User_Note"
                    Case "الموظف"
                        columnName = "RoleName"
                End Select

                If columnName <> "" Then
                    query &= $" WHERE {columnName} LIKE @filter"
                End If
            End If

            Dim cmd As New SqlCommand(query, Conn)
            If filter <> "" Then cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgv_Staff.DataSource = dt
            Disconnect()
        End Using



    End Sub

    Private Sub dgv_Staff_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Staff.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgv_Staff.Rows(e.RowIndex)
            Dim roleId As Integer = Convert.ToInt32(selectedRow.Cells("RoleID").Value)

            Dim query As String = "
            SELECT Per.FormName, Per.CanOpen, Per.CanAdd, Per.CanEdit, Per.CanDelete , RoleName ,Description
            FROM Permissions AS Per
            LEFT JOIN Roles AS R ON Per.RoleID = R.RoleID
            WHERE Per.RoleID = @roleId "

            Try
                Connect()
                Dim cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@roleId", roleId)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                Dim RoleName As String = selectedRow.Cells("RoleName").Value.ToString()
                Dim Description As String = selectedRow.Cells("Description").Value.ToString()

                ' فرغ كل الزرار الأول

                ClearAllPermissionControls()
                txtUser_Code.Text = roleId
                txtUser_Name.Text = RoleName
                txtUser_Note.Text = Description
                ' حلقة لكل فورم
                For Each row As DataRow In dt.Rows
                    Dim formName As String = row("FormName").ToString()


                    Select Case formName
                        Case "Users"
                            chkUsersOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkUsersAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkUsersEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkUsersDelete.Checked = Convert.ToBoolean(row("CanDelete"))

                        Case "Categories"
                            chkCategoriesOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkCategoriesAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkCategoriesEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkCategoriesDelete.Checked = Convert.ToBoolean(row("CanDelete"))

                        Case "Products"
                            chkProductsOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkProductsAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkProductsEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkProductsDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "ProductUnits"
                            chkProductUnitsOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkProductUnitsAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkProductUnitsEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkProductUnitsDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "Customer"
                            chkCustomerOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkCustomerAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkCustomerEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkCustomerDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "Sales"
                            chkSalesOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkSalesAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkSalesEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkSalesDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "Suppliers"
                            chkSuppliersOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkSuppliersAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkSuppliersEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkSuppliersDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "Purchases"
                            chkPurchasesOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkPurchasesAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkPurchasesEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkPurchasesDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "Reports"
                            chkReportsOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkReportsAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkReportsEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkReportsDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "Stock"
                            chkStockOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkStockAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkStockEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkStockDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "backup"
                            chkbackupOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkbackupAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkbackupEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkbackupDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                        Case "Settings"
                            chkSettingsOpen.Checked = Convert.ToBoolean(row("CanOpen"))
                            chkSettingsAdd.Checked = Convert.ToBoolean(row("CanAdd"))
                            chkSettingsEdit.Checked = Convert.ToBoolean(row("CanEdit"))
                            chkSettingsDelete.Checked = Convert.ToBoolean(row("CanDelete"))
                    End Select
                Next
            Catch ex As Exception
                MessageBox.Show("حدث خطأ أثناء جلب الصلاحيات: " & ex.Message)
            Finally
                Disconnect()
            End Try
        End If
    End Sub
    Private Sub ClearAllPermissionControls()
        txtUser_Code.Clear()
        txtUser_Name.Clear()
        txtUser_Note.Clear()
        dgv_Staff.ClearSelection()
        ' Users
        chkUsersOpen.Checked = False
        chkUsersAdd.Checked = False
        chkUsersEdit.Checked = False
        chkUsersDelete.Checked = False

        ' Categories
        chkCategoriesOpen.Checked = False
        chkCategoriesAdd.Checked = False
        chkCategoriesEdit.Checked = False
        chkCategoriesDelete.Checked = False

        ' Products
        chkProductsOpen.Checked = False
        chkProductsAdd.Checked = False
        chkProductsEdit.Checked = False
        chkProductsDelete.Checked = False

        ' ProductUnits
        chkProductUnitsOpen.Checked = False
        chkProductUnitsAdd.Checked = False
        chkProductUnitsEdit.Checked = False
        chkProductUnitsDelete.Checked = False

        ' Customer
        chkCustomerOpen.Checked = False
        chkCustomerAdd.Checked = False
        chkCustomerEdit.Checked = False
        chkCustomerDelete.Checked = False

        ' Sales
        chkSalesOpen.Checked = False
        chkSalesAdd.Checked = False
        chkSalesEdit.Checked = False
        chkSalesDelete.Checked = False

        ' Suppliers
        chkSuppliersOpen.Checked = False
        chkSuppliersAdd.Checked = False
        chkSuppliersEdit.Checked = False
        chkSuppliersDelete.Checked = False

        ' Purchases
        chkPurchasesOpen.Checked = False
        chkPurchasesAdd.Checked = False
        chkPurchasesEdit.Checked = False
        chkPurchasesDelete.Checked = False

        ' Reports
        chkReportsOpen.Checked = False
        chkReportsAdd.Checked = False
        chkReportsEdit.Checked = False
        chkReportsDelete.Checked = False

        ' Stock
        chkStockOpen.Checked = False
        chkStockAdd.Checked = False
        chkStockEdit.Checked = False
        chkStockDelete.Checked = False

        ' backup
        chkbackupOpen.Checked = False
        chkbackupAdd.Checked = False
        chkbackupEdit.Checked = False
        chkbackupDelete.Checked = False

        ' Settings
        chkSettingsOpen.Checked = False
        chkSettingsAdd.Checked = False
        chkSettingsEdit.Checked = False
        chkSettingsDelete.Checked = False
    End Sub


    Private Sub RemoveDuplicateRowsByID(dgv As DataGridView, idColumnName As String)
        Dim seenIDs As New HashSet(Of String)()

        ' نستخدم قائمة مؤقتة علشان نحذف بعد ما نخلص اللوب
        Dim rowsToRemove As New List(Of DataGridViewRow)()

        For Each row As DataGridViewRow In dgv.Rows
            ' تجاهل الصفوف الجديدة الفارغة
            If row.IsNewRow Then Continue For

            ' ناخد قيمة الـ ID
            Dim idValue As String = Convert.ToString(row.Cells(idColumnName).Value)

            ' لو القيمة اتشوفت قبل كده → نحذفها
            If seenIDs.Contains(idValue) Then
                rowsToRemove.Add(row)
            Else
                seenIDs.Add(idValue)
            End If
        Next

        ' نحذف الصفوف المكررة بعد انتهاء اللوب
        For Each row As DataGridViewRow In rowsToRemove
            dgv.Rows.Remove(row)
        Next
    End Sub
    Private Sub AddRoleWithPermissions()
        Try
            ' التحقق من البيانات المطلوبة
            If String.IsNullOrWhiteSpace(txtUser_Name.Text) Then
                MessageBox.Show("يرجى إدخال اسم الدور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Connect()

            ' أولاً: إضافة الدور في جدول Roles
            Dim insertRoleQuery As String = "
            INSERT INTO Roles (RoleName, Description)
            OUTPUT INSERTED.RoleID
            VALUES (@RoleName, @Description)"

            Dim cmdRole As New SqlCommand(insertRoleQuery, Conn)
            cmdRole.Parameters.AddWithValue("@RoleName", txtUser_Name.Text)
            cmdRole.Parameters.AddWithValue("@Description", txtUser_Note.Text)

            Dim newRoleId As Integer = Convert.ToInt32(cmdRole.ExecuteScalar())

            ' ثانيًا: إضافة الصلاحيات لهذا الدور
            Dim insertPermissionQuery As String = "
            INSERT INTO Permissions (RoleID, FormName, CanOpen, CanAdd, CanEdit, CanDelete)
            VALUES (@RoleID, @FormName, @CanOpen, @CanAdd, @CanEdit, @CanDelete)"

            Dim cmdPermission As New SqlCommand(insertPermissionQuery, Conn)
            cmdPermission.Parameters.Add("@RoleID", SqlDbType.Int).Value = newRoleId
            cmdPermission.Parameters.Add("@FormName", SqlDbType.NVarChar)
            cmdPermission.Parameters.Add("@CanOpen", SqlDbType.Bit)
            cmdPermission.Parameters.Add("@CanAdd", SqlDbType.Bit)
            cmdPermission.Parameters.Add("@CanEdit", SqlDbType.Bit)
            cmdPermission.Parameters.Add("@CanDelete", SqlDbType.Bit)

            ' تكرار على كل الشيك بوكس حسب النماذج
            For Each formPermission In GetAllFormPermissions()
                cmdPermission.Parameters("@FormName").Value = formPermission.FormName
                cmdPermission.Parameters("@CanOpen").Value = formPermission.CanOpen
                cmdPermission.Parameters("@CanAdd").Value = formPermission.CanAdd
                cmdPermission.Parameters("@CanEdit").Value = formPermission.CanEdit
                cmdPermission.Parameters("@CanDelete").Value = formPermission.CanDelete
                cmdPermission.ExecuteNonQuery()
            Next

            MessageBox.Show("✅ تم إضافة الدور والصلاحيات بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء الإضافة: " & ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub
    Private Sub UpdateRoleAndPermissions()
        Try
            If String.IsNullOrWhiteSpace(txtUser_Code.Text) Then
                MessageBox.Show("يرجى اختيار الدور المراد تعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim roleId As Integer = Convert.ToInt32(txtUser_Code.Text)
            Connect()

            ' تحديث بيانات الدور
            Dim updateRoleQuery As String = "
            UPDATE Roles SET RoleName = @RoleName, Description = @Description WHERE RoleID = @RoleID"
            Dim cmdRole As New SqlCommand(updateRoleQuery, Conn)
            cmdRole.Parameters.AddWithValue("@RoleName", txtUser_Name.Text)
            cmdRole.Parameters.AddWithValue("@Description", txtUser_Note.Text)
            cmdRole.Parameters.AddWithValue("@RoleID", roleId)
            cmdRole.ExecuteNonQuery()

            ' حذف الصلاحيات القديمة
            Dim deleteQuery As String = "DELETE FROM Permissions WHERE RoleID = @RoleID"
            Dim cmdDel As New SqlCommand(deleteQuery, Conn)
            cmdDel.Parameters.AddWithValue("@RoleID", roleId)
            cmdDel.ExecuteNonQuery()

            ' إعادة إدخال الصلاحيات
            Dim insertPermissionQuery As String = "
            INSERT INTO Permissions (RoleID, FormName, CanOpen, CanAdd, CanEdit, CanDelete)
            VALUES (@RoleID, @FormName, @CanOpen, @CanAdd, @CanEdit, @CanDelete)"

            Dim cmdPermission As New SqlCommand(insertPermissionQuery, Conn)
            cmdPermission.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleId
            cmdPermission.Parameters.Add("@FormName", SqlDbType.NVarChar)
            cmdPermission.Parameters.Add("@CanOpen", SqlDbType.Bit)
            cmdPermission.Parameters.Add("@CanAdd", SqlDbType.Bit)
            cmdPermission.Parameters.Add("@CanEdit", SqlDbType.Bit)
            cmdPermission.Parameters.Add("@CanDelete", SqlDbType.Bit)

            For Each formPermission In GetAllFormPermissions()
                cmdPermission.Parameters("@FormName").Value = formPermission.FormName
                cmdPermission.Parameters("@CanOpen").Value = formPermission.CanOpen
                cmdPermission.Parameters("@CanAdd").Value = formPermission.CanAdd
                cmdPermission.Parameters("@CanEdit").Value = formPermission.CanEdit
                cmdPermission.Parameters("@CanDelete").Value = formPermission.CanDelete
                cmdPermission.ExecuteNonQuery()
            Next

            MessageBox.Show("✅ تم تحديث الدور والصلاحيات بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء التعديل: " & ex.Message)
        Finally
            Disconnect()
        End Try


    End Sub
    Private Sub DeleteRoleAndPermissions()
        Try
            If String.IsNullOrWhiteSpace(txtUser_Code.Text) Then
                MessageBox.Show("يرجى اختيار الدور المراد حذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If MessageBox.Show("هل أنت متأكد من حذف هذا الدور وجميع صلاحياته؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Dim roleId As Integer = Convert.ToInt32(txtUser_Code.Text)
            Connect()

            ' حذف الصلاحيات
            Dim delPerm As New SqlCommand("DELETE FROM Permissions WHERE RoleID = @RoleID", Conn)
            delPerm.Parameters.AddWithValue("@RoleID", roleId)
            delPerm.ExecuteNonQuery()

            ' حذف الدور
            Dim delRole As New SqlCommand("DELETE FROM Roles WHERE RoleID = @RoleID", Conn)
            delRole.Parameters.AddWithValue("@RoleID", roleId)
            delRole.ExecuteNonQuery()

            ClearAllPermissionControls()
            txtUser_Code.Clear()
            txtUser_Name.Clear()
            txtUser_Note.Clear()

            MessageBox.Show("🗑️ تم حذف الدور وجميع صلاحياته بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        AddRoleWithPermissions()
        ClearAllPermissionControls()
        LoadUsers()
        datagridviewsetup()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        UpdateRoleAndPermissions()
        ClearAllPermissionControls()
        LoadUsers()
        datagridviewsetup()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteRoleAndPermissions()
        ClearAllPermissionControls()
        LoadUsers()
        datagridviewsetup()
    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearAllPermissionControls()
    End Sub

    Private Function GetAllFormPermissions() As List(Of (FormName As String, CanOpen As Boolean, CanAdd As Boolean, CanEdit As Boolean, CanDelete As Boolean))
        Dim list As New List(Of (String, Boolean, Boolean, Boolean, Boolean))()

        list.Add(("Users", chkUsersOpen.Checked, chkUsersAdd.Checked, chkUsersEdit.Checked, chkUsersDelete.Checked))
        list.Add(("Categories", chkCategoriesOpen.Checked, chkCategoriesAdd.Checked, chkCategoriesEdit.Checked, chkCategoriesDelete.Checked))
        list.Add(("Products", chkProductsOpen.Checked, chkProductsAdd.Checked, chkProductsEdit.Checked, chkProductsDelete.Checked))
        list.Add(("ProductUnits", chkProductUnitsOpen.Checked, chkProductUnitsAdd.Checked, chkProductUnitsEdit.Checked, chkProductUnitsDelete.Checked))
        list.Add(("Customer", chkCustomerOpen.Checked, chkCustomerAdd.Checked, chkCustomerEdit.Checked, chkCustomerDelete.Checked))
        list.Add(("Sales", chkSalesOpen.Checked, chkSalesAdd.Checked, chkSalesEdit.Checked, chkSalesDelete.Checked))
        list.Add(("Suppliers", chkSuppliersOpen.Checked, chkSuppliersAdd.Checked, chkSuppliersEdit.Checked, chkSuppliersDelete.Checked))
        list.Add(("Purchases", chkPurchasesOpen.Checked, chkPurchasesAdd.Checked, chkPurchasesEdit.Checked, chkPurchasesDelete.Checked))
        list.Add(("Reports", chkReportsOpen.Checked, chkReportsAdd.Checked, chkReportsEdit.Checked, chkReportsDelete.Checked))
        list.Add(("Stock", chkStockOpen.Checked, chkStockAdd.Checked, chkStockEdit.Checked, chkStockDelete.Checked))
        list.Add(("backup", chkbackupOpen.Checked, chkbackupAdd.Checked, chkbackupEdit.Checked, chkbackupDelete.Checked))
        list.Add(("Settings", chkSettingsOpen.Checked, chkSettingsAdd.Checked, chkSettingsEdit.Checked, chkSettingsDelete.Checked))

        Return list
    End Function

End Class