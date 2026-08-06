Imports System.Data.SqlClient

Public Class frmConfirmMessage
    Dim x, y As Integer
    Dim newpoint As New Point
    Public CustomerName As String
    Public BalanceBefore As Decimal
    Public AmountPaid As Decimal
    Public BalanceAfter As Decimal
    Public Notes As String
    Public TargetTreasuryID As Integer
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

    'Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
    '    EnteredPassword = txtPassword.Text
    '    ' التحقق من كلمة السر
    '    If txtPassword.Text <> CurrentUserPassword Then
    '        MsgBox("كلمة السر غير صحيحة!", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If

    '    '------------------------------
    '    ' حفظ بيانات العملية في قاعدة البيانات
    '    '------------------------------
    '    SavePaymentToDatabase(CustomerName, BalanceBefore, AmountPaid, BalanceAfter, Notes)

    '    MsgBox("تم تسجيل عملية الدفع بنجاح!", MsgBoxStyle.Information)

    '    Me.DialogResult = DialogResult.OK
    '    Me.Close()
    'End Sub



    Private Async Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        EnteredPassword = txtPassword.Text
        ' التحقق من كلمة السر
        If txtPassword.Text <> CurrentUserPassword Then
            MsgBox("كلمة السر غير صحيحة!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ' تعطيل الزر مؤقتاً لمنع النقرات المتكررة
        btnOK.Enabled = False

        Try
            '------------------------------
            ' حفظ بيانات العملية في قاعدة البيانات متضمناً حركة الخزنة
            '------------------------------
            Await SavePaymentToDatabaseAsync(CustomerName, BalanceBefore, AmountPaid, BalanceAfter, Notes, TargetTreasuryID)

            MsgBox("تم تسجيل عملية الدفع وتحديث حساب الخزنة بنجاح!", MsgBoxStyle.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("فشلت العملية: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            btnOK.Enabled = True
        End Try
    End Sub

    Private Async Function SavePaymentToDatabaseAsync(client As String, oldB As Decimal, pay As Decimal, newB As Decimal, notes As String, treasuryID As Integer) As Task

        ' الاستعلامات الخاصة بالعميل
        Dim sqlLog As String = "INSERT INTO CustomerBalanceLog (CustomerID, CustomerCode, CustomerName, OldBalance, PaidAmount, NewBalance, Notes, UserName, ActionDate) " &
                           "VALUES (@CustomerID, @CustomerCode, @CustomerName, @OldBalance, @PaidAmount, @NewBalance, @Notes, @UserName, GETDATE())"

        Dim sqlUpdateCustomer As String = "UPDATE Customers SET CurrentBalance = @CurrentBalance WHERE CustomerName = @CustomerName"

        ' نقوم بفتح الاتصال وبدء المعاملة (Transaction)
        Connect() ' استدعاء دالة الاتصال الخاصة بك لفح لـ Conn

        Using trans As SqlTransaction = Conn.BeginTransaction()
            Try
                ' 1. حفظ السجل في الـ Log الخاص بالعملاء
                Using cmdLog As New SqlCommand(sqlLog, Conn, trans)
                    cmdLog.Parameters.AddWithValue("@CustomerID", "")
                    cmdLog.Parameters.AddWithValue("@CustomerCode", "")
                    cmdLog.Parameters.AddWithValue("@CustomerName", client)
                    cmdLog.Parameters.AddWithValue("@OldBalance", oldB)
                    cmdLog.Parameters.AddWithValue("@PaidAmount", pay)
                    cmdLog.Parameters.AddWithValue("@NewBalance", newB)
                    cmdLog.Parameters.AddWithValue("@Notes", notes)
                    cmdLog.Parameters.AddWithValue("@UserName", Convert.ToString(Session.CurrentUserName))

                    cmdLog.ExecuteNonQuery()
                End Using

                ' 2. تحديث الرصيد في جدول العملاء
                Using cmdCust As New SqlCommand(sqlUpdateCustomer, Conn, trans)
                    cmdCust.Parameters.AddWithValue("@CurrentBalance", newB)
                    cmdCust.Parameters.AddWithValue("@CustomerName", client)

                    cmdCust.ExecuteNonQuery()
                End Using

                ' 3. تسجيل حركة إيداع المال في الخزنة المحددة وتحديث رصيدها تلقائياً
                Await TreasuryService.AddTransactionAsync(
                treasuryID:=treasuryID,
                transactionType:=TreasuryTransactionTypes.CustomerReceipt, ' القيمة 4 من الـ Enum الخاص بك لـ سند قبض عميل
                amount:=pay,
                isDeposit:=True, ' حركة إيداع مال بالخزنة
                referenceID:=0,
                referenceNo:="سند قبض",
                notes:="سند قبض من العميل: " & client & " - " & notes,
                userID:=Session.CurrentUserID,
                cn:=Conn,
                trans:=trans
            )

                ' إذا تمت جميع الخطوات بنجاح تام، نثبت المعاملة في قاعدة البيانات
                trans.Commit()

            Catch ex As Exception
                ' في حال حدوث أي خطأ، نتراجع عن كل الخطوات السابقة كأن شيئاً لم يكن
                trans.Rollback()
                Throw New Exception(ex.Message)
            End Try
        End Using
    End Function

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