Imports System.Data.SqlClient

Public Class add_new_customer
    Dim x, y As Integer
    Dim newpoint As New Point

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub
    Private Function IsCustomerCodeExists(customerCode As String, Optional excludeCustomerID As Integer = -1) As Boolean
        Dim exists As Boolean = False

        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Dim query As String = "SELECT COUNT(*) FROM Customers WHERE CustomerCode = @code"
                If excludeCustomerID <> -1 Then
                    query &= " AND CustomerID <> @id"
                End If

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@code", customerCode)
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
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            ' التحقق من الحقول المطلوبة
            If String.IsNullOrWhiteSpace(txtCustomerCode.Text) OrElse String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال كود واسم العميل على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تحقق من وجود كود العميل مسبقًا
            If IsCustomerCodeExists(txtCustomerCode.Text.Trim()) Then
                MessageBox.Show("⚠️ هذا الكود موجود بالفعل، لا يمكن تكراره.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' تنفيذ عملية الإضافة
            Using cn As SqlConnection = DBModule.NewConn()
                Dim query As String = "
            INSERT INTO Customers (CustomerCode, CustomerName, PhoneNumber, Address, CreditLimit, CurrentBalance, IsActive, Notes, CreatedAt)
            VALUES (@Code, @Name, @Phone, @Address, @Limit, @CurrentBalance, @Active, @Notes, GETDATE())"

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@Code", txtCustomerCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Limit", nudCreditLimit.Value)
                    cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(If(String.IsNullOrEmpty(txtBalance.Text), 0, txtBalance.Text)))
                    cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ تم إضافة العميل بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()

        Catch ex As Exception
            Logger.LogError(ex)
            MessageBox.Show("حدث خطأ أثناء إضافة العميل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearFields()
        txtCustomerCode.Clear()
        txtCustomerName.Clear()
        txtUpdatedAt.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        nudCreditLimit.Value = 0
        txtBalance.Clear()
        chkActive.Checked = False
        txtNotes.Clear()
    End Sub

    Private Sub chkActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkActive.CheckedChanged
        If chkActive.Checked Then
            lblStatus.Text = "نشط"
            lblStatus.ForeColor = Color.Green
        Else
            lblStatus.Text = "نشط غير"
            lblStatus.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class