Imports System.Data.SqlClient

Public Class frmConfirmMessage
    Dim x, y As Integer
    Dim newpoint As New Point
    Public CustomerName As String
    Public BalanceBefore As Decimal
    Public AmountPaid As Decimal
    Public BalanceAfter As Decimal
    Public Notes As String

    Public EnteredPassword As String = ""

    Private Sub frmConfirmMessage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' عرض اسم العميل
        txtCustomerName.Text = CustomerName

        ' عرض الرصيد قبل (دائن/مدين)
        If BalanceBefore < 0 Then
            txtBalanceBefore.Text = "مديون " & Math.Abs(BalanceBefore)
        Else
            txtBalanceBefore.Text = "دائن " & BalanceBefore
        End If

        ' المبلغ المدفوع
        txtAmountPaid.Text = AmountPaid.ToString() & " جنيه"

        ' الرصيد بعد العملية
        If BalanceAfter < 0 Then
            txtBalanceAfter.Text = "مديون " & Math.Abs(BalanceAfter)
        Else
            txtBalanceAfter.Text = "دائن " & BalanceAfter
        End If

        txtNotes.Text = Notes
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        EnteredPassword = txtPassword.Text
        ' التحقق من كلمة السر
        If txtPassword.Text <> CurrentUserPassword Then
            MsgBox("كلمة السر غير صحيحة!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        '------------------------------
        ' حفظ بيانات العملية في قاعدة البيانات
        '------------------------------
        SavePaymentToDatabase(CustomerName, BalanceBefore, AmountPaid, BalanceAfter, Notes)

        MsgBox("تم تسجيل عملية الدفع بنجاح!", MsgBoxStyle.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

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

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub SavePaymentToDatabase(client As String, oldB As Decimal, pay As Decimal, newB As Decimal, notes As String)

        Dim sql As String =
        "INSERT INTO CustomerBalanceLog (CustomerID, CustomerCode, CustomerName, OldBalance,PaidAmount,NewBalance, Notes,UserName, ActionDate)
         VALUES (@CustomerID, @CustomerCode, @CustomerName, @OldBalance,@PaidAmount,@NewBalance, @Notes,@UserName, GETDATE())"
        Connect()

        Using cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@CustomerID", "")
            cmd.Parameters.AddWithValue("@CustomerCode", "")
            cmd.Parameters.AddWithValue("@CustomerName", client)
            cmd.Parameters.AddWithValue("@OldBalance", oldB)
            cmd.Parameters.AddWithValue("@PaidAmount", pay)
            cmd.Parameters.AddWithValue("@NewBalance", newB)
            cmd.Parameters.AddWithValue("@Notes", notes)
            cmd.Parameters.AddWithValue("@UserName", Convert.ToString(Session.CurrentUserName))
            cmd.ExecuteNonQuery()
        End Using

        ' تحديث الرصيد في جدول العملاء
        Dim sql2 As String = "UPDATE Customers SET CurrentBalance = @CurrentBalance WHERE CustomerName = @CustomerName"

        Using cmd2 As New SqlCommand(sql2, Conn)
            cmd2.Parameters.AddWithValue("@CurrentBalance", newB)
            cmd2.Parameters.AddWithValue("@CustomerName", client)
            cmd2.ExecuteNonQuery()
        End Using

    End Sub

End Class