'Imports System.Data.SqlClient

'Public Class FrmSuppliers
'    Private ReadOnly _connString As String = "Server=.;Database=RestaurantDB;Trusted_Connection=True;"
'    Private _selectedSupplierId As Integer = 0
'    Private ReadOnly _currentUserId As Integer = 1

'    Private Sub FrmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        LoadSuppliersGrid()
'        ClearForm()
'    End Sub

'    Private Sub LoadSuppliersGrid(Optional search As String = "")
'        Using conn As New SqlConnection(_connString)
'            Dim query As String = "SELECT SupplierID, SupplierCode, SupplierName, Phone1, CurrentBalance, IsActive " &
'                                 "FROM Suppliers " &
'                                 "WHERE SupplierName LIKE @search OR Phone1 LIKE @search OR SupplierCode LIKE @search " &
'                                 "ORDER BY SupplierID DESC"
'            Using cmd As New SqlCommand(query, conn)
'                cmd.Parameters.AddWithValue("@search", $"%{search}%")
'                Dim adapter As New SqlDataAdapter(cmd)
'                Dim dt As New DataTable()
'                adapter.Fill(dt)
'                dgvSuppliers.DataSource = dt
'                FormatSuppliersGrid()
'            End Using
'        End Using
'    End Sub

'    Private Sub FormatSuppliersGrid()
'        If dgvSuppliers.Columns("SupplierID") IsNot Nothing Then dgvSuppliers.Columns("SupplierID").Visible = False
'        If dgvSuppliers.Columns("SupplierCode") IsNot Nothing Then dgvSuppliers.Columns("SupplierCode").HeaderText = "الكود"
'        If dgvSuppliers.Columns("SupplierName") IsNot Nothing Then dgvSuppliers.Columns("SupplierName").HeaderText = "اسم المورد"
'        If dgvSuppliers.Columns("Phone1") IsNot Nothing Then dgvSuppliers.Columns("Phone1").HeaderText = "الهاتف"
'        If dgvSuppliers.Columns("CurrentBalance") IsNot Nothing Then
'            dgvSuppliers.Columns("CurrentBalance").HeaderText = "الرصيد الحالي"
'            dgvSuppliers.Columns("CurrentBalance").DefaultCellStyle.Format = "N2"
'        End If
'    End Sub

'    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
'        LoadSuppliersGrid(txtSearch.Text.Trim())
'    End Sub

'    Private Sub dgvSuppliers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSuppliers.SelectionChanged
'        If dgvSuppliers.CurrentRow IsNot Nothing AndAlso dgvSuppliers.CurrentRow.Cells("SupplierID").Value IsNot DBNull.Value Then
'            _selectedSupplierId = Convert.ToInt32(dgvSuppliers.CurrentRow.Cells("SupplierID").Value)
'            BindSupplierDetails(_selectedSupplierId)
'        End If
'    End Sub

'    Private Sub BindSupplierDetails(supplierId As Integer)
'        Using conn As New SqlConnection(_connString)
'            Dim query As String = "SELECT * FROM Suppliers WHERE SupplierID = @id"
'            Using cmd As New SqlCommand(query, conn)
'                cmd.Parameters.AddWithValue("@id", supplierId)
'                conn.Open()
'                Dim reader As SqlDataReader = cmd.ExecuteReader()
'                If reader.Read() Then
'                    lblSupplierID.Text = reader("SupplierID").ToString()
'                    txtSupplierCode.Text = reader("SupplierCode").ToString()
'                    txtSupplierName.Text = reader("SupplierName").ToString()
'                    txtPhone1.Text = reader("Phone1").ToString()
'                    txtPhone2.Text = If(reader("Phone2") Is DBNull.Value, "", reader("Phone2").ToString())
'                    txtEmail.Text = If(reader("Email") Is DBNull.Value, "", reader("Email").ToString())
'                    txtAddress.Text = If(reader("Address") Is DBNull.Value, "", reader("Address").ToString())

'                    numOpeningBalance.Value = Convert.ToDecimal(reader("OpeningBalance"))
'                    numOpeningBalance.Enabled = False ' منع التعديل بعد الحفظ الأول

'                    Dim curBalance As Decimal = Convert.ToDecimal(reader("CurrentBalance"))
'                    lblCurrentBalance.Text = curBalance.ToString("N2")
'                    lblCurrentBalance.ForeColor = If(curBalance > 0, Color.DarkRed, Color.DarkGreen)

'                    'numCreditLimit.Value = Convert.ToDecimal(reader("CreditLimit"))
'                    txtNotes.Text = If(reader("Notes") Is DBNull.Value, "", reader("Notes").ToString())
'                    chkIsActive.Checked = Convert.ToBoolean(reader("IsActive"))
'                End If
'            End Using
'        End Using
'    End Sub

'    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
'        If String.IsNullOrWhiteSpace(txtSupplierName.Text) OrElse String.IsNullOrWhiteSpace(txtPhone1.Text) Then
'            MessageBox.Show("يرجى إدخال اسم المورد ورقم الهاتف الرئيسي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Return
'        End If

'        Using conn As New SqlConnection(_connString)
'            conn.Open()
'            Dim trans As SqlTransaction = conn.BeginTransaction()

'            Try
'                If _selectedSupplierId = 0 Then
'                    ' إضافة جديد
'                    Dim code As String = If(String.IsNullOrWhiteSpace(txtSupplierCode.Text), "SUP-" & DateTime.Now.Ticks.ToString().Substring(12), txtSupplierCode.Text)
'                    Dim insertQuery As String = "INSERT INTO Suppliers (SupplierCode, SupplierName, Phone1, Phone2, Email, Address, OpeningBalance, CurrentBalance, CreditLimit, Notes, IsActive) " &
'                        "VALUES (@Code, @Name, @Phone1, @Phone2, @Email, @Address, @OpeningBal, @OpeningBal, @CreditLimit, @Notes, @IsActive); SELECT SCOPE_IDENTITY();"

'                    Dim newId As Integer = 0
'                    Using cmd As New SqlCommand(insertQuery, conn, trans)
'                        AddParams(cmd, code)
'                        newId = Convert.ToInt32(cmd.ExecuteScalar())
'                    End Using

'                    ' تسجيل حركة رصيد افتتاحي إذا وجد
'                    If numOpeningBalance.Value <> 0 Then
'                        Dim txQuery As String = "INSERT INTO SupplierTransactions (SupplierID, TransactionType, ReferenceType, CreditAmount, DebitAmount, BalanceAfter, Notes, CreatedByUserID) " &
'                            "VALUES (@SupplierID, N'رصيد افتتاحي', 'OpeningBalance', @Credit, @Debit, @BalanceAfter, N'رصيد افتتاحي عند الإنشاء', @UserID);"

'                        Using txCmd As New SqlCommand(txQuery, conn, trans)
'                            Dim credit As Decimal = If(numOpeningBalance.Value > 0, numOpeningBalance.Value, 0)
'                            Dim debit As Decimal = If(numOpeningBalance.Value < 0, Math.Abs(numOpeningBalance.Value), 0)

'                            txCmd.Parameters.AddWithValue("@SupplierID", newId)
'                            txCmd.Parameters.AddWithValue("@Credit", credit)
'                            txCmd.Parameters.AddWithValue("@Debit", debit)
'                            txCmd.Parameters.AddWithValue("@BalanceAfter", numOpeningBalance.Value)
'                            txCmd.Parameters.AddWithValue("@UserID", _currentUserId)
'                            txCmd.ExecuteNonQuery()
'                        End Using
'                    End If
'                Else
'                    ' تعديل قائم
'                    Dim updateQuery As String = "UPDATE Suppliers SET SupplierCode=@Code, SupplierName=@Name, Phone1=@Phone1, Phone2=@Phone2, Email=@Email, Address=@Address, CreditLimit=@CreditLimit, Notes=@Notes, IsActive=@IsActive, UpdatedAt=GETDATE() WHERE SupplierID=@SupplierID;"
'                    Using cmd As New SqlCommand(updateQuery, conn, trans)
'                        cmd.Parameters.AddWithValue("@SupplierID", _selectedSupplierId)
'                        AddParams(cmd, txtSupplierCode.Text)
'                        cmd.ExecuteNonQuery()
'                    End Using
'                End If

'                trans.Commit()
'                MessageBox.Show("تم حفظ البيانات بنجاح.", "تمت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                LoadSuppliersGrid()
'                ClearForm()
'            Catch ex As Exception
'                trans.Rollback()
'                MessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            End Try
'        End Using
'    End Sub

'    Private Sub AddParams(cmd As SqlCommand, code As String)
'        cmd.Parameters.AddWithValue("@Code", code)
'        cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim())
'        cmd.Parameters.AddWithValue("@Phone1", txtPhone1.Text.Trim())
'        cmd.Parameters.AddWithValue("@Phone2", If(String.IsNullOrEmpty(txtPhone2.Text), CObj(DBNull.Value), txtPhone2.Text.Trim()))
'        cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrEmpty(txtEmail.Text), CObj(DBNull.Value), txtEmail.Text.Trim()))
'        cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrEmpty(txtAddress.Text), CObj(DBNull.Value), txtAddress.Text.Trim()))
'        cmd.Parameters.AddWithValue("@OpeningBal", numOpeningBalance.Value)
'        'cmd.Parameters.AddWithValue("@CreditLimit", numCreditLimit.Value)
'        cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), CObj(DBNull.Value), txtNotes.Text.Trim()))
'        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked)
'    End Sub

'    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
'        ClearForm()
'    End Sub

'    Private Sub ClearForm()
'        _selectedSupplierId = 0
'        lblSupplierID.Text = "0"
'        txtSupplierCode.Text = String.Empty
'        txtSupplierName.Text = String.Empty
'        txtPhone1.Text = String.Empty
'        txtPhone2.Text = String.Empty
'        txtEmail.Text = String.Empty
'        txtAddress.Text = String.Empty
'        numOpeningBalance.Value = 0
'        numOpeningBalance.Enabled = True
'        'numCreditLimit.Value = 0
'        lblCurrentBalance.Text = "0.00"
'        lblCurrentBalance.ForeColor = Color.Black
'        txtNotes.Text = String.Empty
'        chkIsActive.Checked = True
'    End Sub

'    ' فتح شاشة كشف الحساب والحركات المخصصة
'    Private Sub btnOpenStatement_Click(sender As Object, e As EventArgs) Handles btnOpenStatement.Click
'        If _selectedSupplierId = 0 Then
'            MessageBox.Show("يرجى اختيار مورد أولاً لعرض حركاته.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Return
'        End If

'        Dim frm As New FrmSupplierTransactions(_selectedSupplierId, txtSupplierName.Text)
'        frm.ShowDialog()
'        ' إعادة تحميل البيانات تحديثاً للرصيد بعد أي سداد في الشاشة الثانية
'        BindSupplierDetails(_selectedSupplierId)
'        LoadSuppliersGrid(txtSearch.Text)
'    End Sub
'End Class



Imports System.Data.SqlClient

Public Class frmSuppliers
    Private _cachedSuppliers As DataTable = Nothing

    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliersGrid()
        ClearFields()

        datagridviewsetup(dgvSuppliers)

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub LoadSuppliersGrid(Optional search As String = "")
        Try
            Dim query As String = "SELECT SupplierID, SupplierCode, SupplierName, Phone, Address, CurrentBalance, IsActive, Notes " &
                                  "FROM Suppliers WHERE IsDeleted = 0 OR IsDeleted IS NULL "

            If Not String.IsNullOrWhiteSpace(search) Then
                query &= $"AND (SupplierName LIKE '%{search.Replace("'", "''")}%' OR SupplierCode LIKE '%{search.Replace("'", "''")}%' OR Phone LIKE '%{search.Replace("'", "''")}%') "
            End If

            query &= "ORDER BY SupplierID DESC"

            _cachedSuppliers = DBModule.ExecuteQuery(query)
            dgvSuppliers.DataSource = _cachedSuppliers

            If dgvSuppliers.Columns.Contains("SupplierID") Then dgvSuppliers.Columns("SupplierID").Visible = False
            If dgvSuppliers.Columns.Contains("SupplierCode") Then dgvSuppliers.Columns("SupplierCode").HeaderText = "كود المورد"
            If dgvSuppliers.Columns.Contains("SupplierName") Then dgvSuppliers.Columns("SupplierName").HeaderText = "اسم المورد"
            If dgvSuppliers.Columns.Contains("Phone") Then dgvSuppliers.Columns("Phone").HeaderText = "الهاتف"
            If dgvSuppliers.Columns.Contains("Address") Then dgvSuppliers.Columns("Address").HeaderText = "العنوان"
            If dgvSuppliers.Columns.Contains("CurrentBalance") Then dgvSuppliers.Columns("CurrentBalance").HeaderText = "الرصيد المستحق"
            If dgvSuppliers.Columns.Contains("IsActive") Then dgvSuppliers.Columns("IsActive").HeaderText = "نشط"
            If dgvSuppliers.Columns.Contains("Notes") Then dgvSuppliers.Columns("Notes").HeaderText = "ملاحظات"

        Catch ex As Exception
            MessageBox.Show("خطأ في جلب بيانات الموردين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvSuppliers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSuppliers.SelectionChanged
        If dgvSuppliers.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvSuppliers.SelectedRows(0)

        If row.Cells("SupplierID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("SupplierID").Value) Then
            txtSupplierCode.Text = row.Cells("SupplierCode").Value.ToString()
            txtSupplierName.Text = row.Cells("SupplierName").Value.ToString()
            txtPhone.Text = If(IsDBNull(row.Cells("Phone").Value), "", row.Cells("Phone").Value.ToString())
            txtAddress.Text = If(IsDBNull(row.Cells("Address").Value), "", row.Cells("Address").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgIsActive.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
            lblBalance.Text = Convert.ToDecimal(row.Cells("CurrentBalance").Value).ToString("N2")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MessageBox.Show("يرجى إدخال اسم المورد أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "INSERT INTO Suppliers (SupplierCode, SupplierName, Phone, Address, Notes, IsActive, IsDeleted) " &
                              "VALUES (@Code, @Name, @Phone, @Address, @Notes, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtSupplierCode.Text), "SUP-" & DateTime.Now.ToString("mmss"), txtSupplierCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", If(String.IsNullOrWhiteSpace(txtPhone.Text), DBNull.Value, txtPhone.Text.Trim()))
                cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrWhiteSpace(txtAddress.Text), DBNull.Value, txtAddress.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgIsActive.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ بيانات المورد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadSuppliersGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvSuppliers.SelectedRows.Count = 0 Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvSuppliers.SelectedRows(0).Cells("SupplierID").Value)

        Dim query As String = "UPDATE Suppliers SET SupplierCode = @Code, SupplierName = @Name, Phone = @Phone, " &
                              "Address = @Address, Notes = @Notes, IsActive = @IsActive WHERE SupplierID = @ID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", currentID)
                cmd.Parameters.AddWithValue("@Code", txtSupplierCode.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", If(String.IsNullOrWhiteSpace(txtPhone.Text), DBNull.Value, txtPhone.Text.Trim()))
                cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrWhiteSpace(txtAddress.Text), DBNull.Value, txtAddress.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgIsActive.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل بيانات المورد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadSuppliersGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvSuppliers.SelectedRows.Count = 0 Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvSuppliers.SelectedRows(0).Cells("SupplierID").Value)
        Dim balance As Decimal = Convert.ToDecimal(dgvSuppliers.SelectedRows(0).Cells("CurrentBalance").Value)

        If balance <> 0 Then
            MessageBox.Show("لا يمكن حذف المورد نظراً لوجود رصيد مالي معلق بحسابه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("هل أنت متأكد من حذف هذا المورد؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DBModule.ExecuteNonQuery($"UPDATE Suppliers SET IsDeleted = 1 WHERE SupplierID = {currentID}")
            LoadSuppliersGrid()
            ClearFields()
        End If
    End Sub

    ' فتح شاشة حركات الموردين وكشف الحساب مباشرة
    Private Sub btnOpenAccountStatement_Click(sender As Object, e As EventArgs) Handles btnOpenAccountStatement.Click
        If dgvSuppliers.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد مورد من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim supID As Integer = Convert.ToInt32(dgvSuppliers.SelectedRows(0).Cells("SupplierID").Value)
        Dim supName As String = dgvSuppliers.SelectedRows(0).Cells("SupplierName").Value.ToString()

        Dim frm As New FrmSupplierTransactions(supID, supName)
        frm.ShowDialog()
        LoadSuppliersGrid()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadSuppliersGrid(txtSearch.Text.Trim())
    End Sub

    Private Sub ClearFields()
        txtSupplierCode.Text = GetNextCode("Suppliers", "SupplierCode")
        txtSupplierName.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        txtNotes.Clear()
        lblBalance.Text = "0.00"
        tgIsActive.Checked = True
        dgvSuppliers.ClearSelection()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
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