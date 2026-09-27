Imports System.Data.SqlClient

Public Class add_new_supplier
    Dim x, y As Integer
    Dim newpoint As New Point
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            ' التحقق من الحقول المطلوبة
            If String.IsNullOrWhiteSpace(txtSupplierCode.Text) OrElse String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال كود واسم العميل على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تحقق من وجود كود العميل مسبقًا
            If IsSupplierCodeExists(txtSupplierCode.Text.Trim()) Then
                MessageBox.Show("⚠️ هذا الكود موجود بالفعل، لا يمكن تكراره.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تنفيذ عملية الإضافة
            Using cn As SqlConnection = DBModule.NewConn()
                Dim query As String = "
            INSERT INTO Suppliers (SuppliersCode, SuppliersName, PhoneNumber, Address, Companyname, CurrentBalance, IsActive, Notes, CreatedAt)
            VALUES (@Code, @Name, @Phone, @Address, @Limit, @CurrentBalance, @Active, @Notes, GETDATE())"

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@Code", txtSupplierCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Limit", txtCompanyname.Text.Trim)
                    cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(If(String.IsNullOrEmpty(txtBalance.Text), 0, txtBalance.Text)))
                    cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم إضافة المورد بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()


        Catch ex As Exception
            Logger.LogError(ex)
            MessageBox.Show("حدث خطأ أثناء إضافة المورد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearFields()
        txtSupplierCode.Clear()
        txtSupplierName.Clear()
        txtUpdatedAt.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        txtCompanyname.Clear()
        txtBalance.Clear()
        chkActive.Checked = True
        txtNotes.Clear()
    End Sub
    Private Function IsSupplierCodeExists(SuppliersCode As String, Optional excludeCustomerID As Integer = -1) As Boolean
        Dim exists As Boolean = False

        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Dim query As String = "SELECT COUNT(*) FROM Suppliers WHERE SuppliersCode = @code"
                If excludeCustomerID <> -1 Then
                    query &= " AND SuppliersID <> @id"
                End If

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@code", SuppliersCode)
                    If excludeCustomerID <> -1 Then
                        cmd.Parameters.AddWithValue("@id", excludeCustomerID)
                    End If

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    exists = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError(ex)
            MessageBox.Show("حدث خطأ أثناء التحقق من الكود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return exists
    End Function

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearFields()
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lblTime.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lblTime.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub
End Class