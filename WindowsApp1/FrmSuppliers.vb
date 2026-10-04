Imports System.Data.SqlClient

Public Class frmSuppliers
    Private _cachedSuppliers As DataTable = Nothing

    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler btnExportSuppliers.Click, Async Sub()
                                    Try
                                        Using dialog As New SaveFileDialog With {.Filter = "Excel (*.xlsx)|*.xlsx", .FileName = "الموردين.xlsx"}
                                            If dialog.ShowDialog(Me) = DialogResult.OK Then
                                                If Not Await Services.DataExportImportService.ExportSingleToExcelAsync("Suppliers", dialog.FileName, Nothing) Then Throw New Exception("تعذر تصدير الموردين.")
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        SmartMessageBox.Show(ex.Message)
                                    End Try
                                End Sub
        LoadSuppliersGrid()
        ClearFields()

        datagridviewsetup(dgvSuppliers)

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub LoadSuppliersGrid(Optional search As String = "")
        Try
            Dim query As String = "SELECT SupplierID, SupplierCode, SupplierName, Phone, Address, CurrentBalance, IsActive, Notes " &
                                  "FROM Suppliers WHERE (IsDeleted = 0 OR IsDeleted IS NULL) "

            ' باراميترز بدل الدمج النصي (منع SQL Injection)
            Dim params As New Dictionary(Of String, Object)
            If Not String.IsNullOrWhiteSpace(search) Then
                query &= "AND (SupplierName LIKE @Search OR SupplierCode LIKE @Search OR Phone LIKE @Search) "
                params("@Search") = "%" & search & "%"
            End If

            query &= "ORDER BY SupplierID DESC"

            _cachedSuppliers = DBModule.ExecuteQuery(query, params)
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
            SmartMessageBox.Show("خطأ في جلب بيانات الموردين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            openingInput.Enabled = False
            Try
                Dim totals = SupplierAccountingService.GetBalances(CInt(row.Cells("SupplierID").Value))
                If totals.Rows.Count > 0 Then
                    Dim t = totals.Rows(0)
                    supplierTotals.Text = "مشتريات: " & CDec(t("المشتريات")).ToString("N2") & " | مسدد: " & CDec(t("المسدد")).ToString("N2") & " | الرصيد: " & CDec(t("الرصيد الحالي")).ToString("N2")
                End If
            Catch ex As Exception
                supplierTotals.Text = "تعذر تحميل إجماليات المورد"
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            SmartMessageBox.Show("يرجى إدخال اسم المورد أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierName.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtPhone.Text) Then
            SmartMessageBox.Show("يرجى إدخال رقم الهاتف للمورد!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Exit Sub
        End If

        Dim query As String = "INSERT INTO Suppliers (SupplierCode, SupplierName, Phone, Address, Notes, IsActive, IsDeleted, OpeningBalance, CurrentBalance) " &
                              "VALUES (@Code, @Name, @Phone, @Address, @Notes, @IsActive, 0, @Opening, @Opening); SELECT CAST(SCOPE_IDENTITY() AS int);"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrWhiteSpace(txtSupplierCode.Text), GetNextCode("Suppliers", "SupplierCode").ToString(), txtSupplierCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", If(String.IsNullOrWhiteSpace(txtPhone.Text), DBNull.Value, txtPhone.Text.Trim()))
                cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrWhiteSpace(txtAddress.Text), DBNull.Value, txtAddress.Text.Trim()))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgIsActive.Checked)

                Try
                    SupplierAccountingService.DemandPermission("FrmSuppliers", "CanAdd")
                    If Not openingInput.Enabled Then Throw New ArgumentException("اضغط تفريغ الحقول قبل إضافة مورد جديد.")
                    cmd.Parameters.AddWithValue("@Opening", openingInput.Value)
                    conn.Open()
                    Using tx = conn.BeginTransaction()
                        cmd.Transaction = tx
                        Try
                            Dim supplierID = CInt(cmd.ExecuteScalar())
                            If openingInput.Value <> 0D Then
                                Using movement As New SqlCommand("INSERT INTO SupplierTransactions(SupplierID,TransactionType,Debit,Credit,BalanceBefore,BalanceAfter,Notes,UserID) VALUES(@ID,'OPENING_BALANCE',@Debit,@Credit,0,@Balance,N'رصيد افتتاحي عند الإنشاء',@User)", conn, tx)
                                    movement.Parameters.AddWithValue("@ID", supplierID)
                                    movement.Parameters.AddWithValue("@Debit", Math.Max(-openingInput.Value, 0D))
                                    movement.Parameters.AddWithValue("@Credit", Math.Max(openingInput.Value, 0D))
                                    movement.Parameters.AddWithValue("@Balance", openingInput.Value)
                                    movement.Parameters.AddWithValue("@User", Session.CurrentUserID)
                                    movement.ExecuteNonQuery()
                                End Using
                            End If
                            tx.Commit()
                        Catch
                            tx.Rollback()
                            Throw
                        End Try
                    End Using
                    SmartMessageBox.Show("تم حفظ بيانات المورد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadSuppliersGrid()
                    ClearFields()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvSuppliers.SelectedRows.Count = 0 Then Exit Sub
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            SmartMessageBox.Show("يرجى إدخال اسم المورد أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierName.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtPhone.Text) Then
            SmartMessageBox.Show("يرجى إدخال رقم الهاتف للمورد!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Exit Sub
        End If
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
                    SupplierAccountingService.DemandPermission("FrmSuppliers", "CanEdit")
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    SmartMessageBox.Show("تم تعديل بيانات المورد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadSuppliersGrid()
                    ClearFields()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvSuppliers.SelectedRows.Count = 0 Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvSuppliers.SelectedRows(0).Cells("SupplierID").Value)
        Dim balance As Decimal = Convert.ToDecimal(dgvSuppliers.SelectedRows(0).Cells("CurrentBalance").Value)

        If balance <> 0 Then
            SmartMessageBox.Show("لا يمكن حذف المورد نظراً لوجود رصيد مالي معلق بحسابه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If SmartMessageBox.Show("هل أنت متأكد من حذف هذا المورد؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                SupplierAccountingService.DemandPermission("FrmSuppliers", "CanDelete")
                Using cn As New SqlConnection(DBModule.ConnectionString), cmd As New SqlCommand("UPDATE Suppliers SET IsDeleted=1 WHERE SupplierID=@ID AND CurrentBalance=0", cn)
                    cmd.Parameters.AddWithValue("@ID", currentID)
                    cn.Open()
                    If cmd.ExecuteNonQuery() <> 1 Then Throw New Exception("تغير رصيد المورد؛ حدّث البيانات وأعد المحاولة.")
                End Using
            Catch ex As Exception
                SmartMessageBox.Show(ex.Message)
                Return
            End Try
            LoadSuppliersGrid()
            ClearFields()
        End If
    End Sub

    ' فتح شاشة حركات الموردين وكشف الحساب مباشرة
    Private Sub btnOpenAccountStatement_Click(sender As Object, e As EventArgs) Handles btnOpenAccountStatement.Click
        If dgvSuppliers.SelectedRows.Count = 0 Then
            SmartMessageBox.Show("يرجى تحديد مورد من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim supID As Integer = Convert.ToInt32(dgvSuppliers.SelectedRows(0).Cells("SupplierID").Value)
        Dim supName As String = dgvSuppliers.SelectedRows(0).Cells("SupplierName").Value.ToString()

        If Not Session.HasPermission("FrmSupplierTransactions", "CanOpen") Then
            SmartMessageBox.Show("ليس لديك صلاحية فتح كشف حساب المورد.")
            Return
        End If
        Using frm As New FrmSupplierTransactions(supID, supName)
            frm.ShowDialog(Me)
        End Using
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
        openingInput.Value = 0
        openingInput.Enabled = True
        supplierTotals.Text = ""
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