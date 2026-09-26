Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmConfirmMessage

    Public Property CustomerID As Integer = 0
    Public Property CustomerCode As String = ""
    Public Property CustomerName As String = ""
    Public Property BalanceBefore As Decimal = 0
    Public Property AmountPaid As Decimal = 0
    Public Property BalanceAfter As Decimal = 0
    Public Property TargetTreasuryID As Integer = 0
    Public Property TreasuryName As String = ""
    Public Property Notes As String = ""
    Public Property EnteredPassword As String = ""

    Private Sub frmConfirmMessage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim drag As New FormDragHelper(Me, pnlHeader)

            lblCustomerName.Text = If(String.IsNullOrWhiteSpace(CustomerName), "عميل غير محدد", CustomerName)
            If Not String.IsNullOrWhiteSpace(CustomerCode) Then
                lblCustomerName.Text &= $" ({CustomerCode})"
            End If

            If BalanceBefore < 0 Then
                lblBalanceBefore.Text = $"{Math.Abs(BalanceBefore):N2} ج.م (مدين - عليه)"
                lblBalanceBefore.ForeColor = Color.FromArgb(231, 76, 60)
            ElseIf BalanceBefore > 0 Then
                lblBalanceBefore.Text = $"{BalanceBefore:N2} ج.م (دائن - له)"
                lblBalanceBefore.ForeColor = Color.FromArgb(39, 174, 96)
            Else
                lblBalanceBefore.Text = "0.00 ج.م (متزن)"
                lblBalanceBefore.ForeColor = Color.Black
            End If

            lblAmountPaid.Text = $"{AmountPaid:N2} ج.م"

            If BalanceAfter < 0 Then
                lblBalanceAfter.Text = $"{Math.Abs(BalanceAfter):N2} ج.م (مدين - عليه)"
                lblBalanceAfter.ForeColor = Color.FromArgb(231, 76, 60)
            ElseIf BalanceAfter > 0 Then
                lblBalanceAfter.Text = $"{BalanceAfter:N2} ج.م (دائن - له)"
                lblBalanceAfter.ForeColor = Color.FromArgb(39, 174, 96)
            Else
                lblBalanceAfter.Text = "0.00 ج.م (خالص تماماً)"
                lblBalanceAfter.ForeColor = Color.FromArgb(39, 174, 96)
            End If

            If Not String.IsNullOrWhiteSpace(TreasuryName) Then
                lblTreasury.Text = TreasuryName
            ElseIf TargetTreasuryID > 0 Then
                lblTreasury.Text = $"خزينة رقم #{TargetTreasuryID}"
            Else
                lblTreasury.Text = "الخزينة الافتراضية"
            End If

            txtNotes.Text = Notes

            If String.IsNullOrEmpty(Session.CurrentUserPassword) Then
                lblPasswordTitle.Visible = False
                txtPassword.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء تحميل بيانات السند: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        EnteredPassword = txtPassword.Text.Trim()

        ' التحقق من كلمة السر إذا كان للمستخدم كلمة سر مسجلة
        If Not String.IsNullOrEmpty(Session.CurrentUserPassword) AndAlso txtPassword.Visible Then
            If EnteredPassword <> Session.CurrentUserPassword Then
                MessageBox.Show("كلمة المرور غير صحيحة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                txtPassword.SelectAll()
                Exit Sub
            End If
        End If

        btnOK.Enabled = False
        btnCancel.Enabled = False

        Try
            Dim finalNotes As String = txtNotes.Text.Trim()
            Await SavePaymentToDatabaseAsync(CustomerID, CustomerCode, CustomerName, BalanceBefore, AmountPaid, BalanceAfter, finalNotes, TargetTreasuryID)

            MessageBox.Show("✅ تم تسجيل سند القبض وإيداع المبلغ في الخزينة وتحديث كشف حساب العميل بنجاح!", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("فشلت عملية حفظ سند القبض: " & ex.Message, "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnOK.Enabled = True
            btnCancel.Enabled = True
        End Try
    End Sub

    Private Async Function SavePaymentToDatabaseAsync(custID As Integer, code As String, client As String, oldB As Decimal, pay As Decimal, newB As Decimal, notesText As String, treasuryID As Integer) As Task
        Using cn As New SqlConnection(DBModule.ConnectionString)
            Await cn.OpenAsync()

            Using trans As SqlTransaction = cn.BeginTransaction()
                Try
                    Dim currentUserID As Integer = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1)
                    Dim currentUserName As String = If(Not String.IsNullOrEmpty(Session.CurrentUserfullName), Session.CurrentUserfullName, "المستخدم")

                    ' 1. تسجيل السجل في CustomerTransactions لظهوره في كشف الحساب
                    Dim receiptRefNo As String = $"REC-{DateTime.Now:yyyyMMdd}-{DateTime.Now:HHmmss}"
                    Dim currentShiftID As Object = If(ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, CType(DBNull.Value, Object))
                    Dim sqlCustTrans As String = "
                        INSERT INTO CustomerTransactions 
                        (TransactionDate, CustomerID, InvoiceID, BranchID, TransactionType, Debit, Credit, BalanceAfter, Notes, ShiftID, UserID, CreatedAt)
                        VALUES 
                        (GETDATE(), @CustomerID, NULL, 1, N'سند قبض', 0, @Credit, @BalanceAfter, @Notes, @ShiftID, @UserID, GETDATE());
                    "
                    Using cmdTrans As New SqlCommand(sqlCustTrans, cn, trans)
                        cmdTrans.Parameters.AddWithValue("@CustomerID", custID)
                        cmdTrans.Parameters.AddWithValue("@Credit", pay)
                        cmdTrans.Parameters.AddWithValue("@BalanceAfter", newB)
                        cmdTrans.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(notesText), $"سند قبض نقدي ({receiptRefNo})", $"{notesText} ({receiptRefNo})"))
                        cmdTrans.Parameters.AddWithValue("@ShiftID", currentShiftID)
                        cmdTrans.Parameters.AddWithValue("@UserID", currentUserID)
                        cmdTrans.ExecuteNonQuery()
                    End Using

                    ' 2. تسجيل السجل في CustomerBalanceLog (للسجل التاريخي)
                    Dim sqlLog As String = "
                        INSERT INTO CustomerBalanceLog 
                        (CustomerID, CustomerCode, CustomerName, OldBalance, PaidAmount, NewBalance, Notes, UserName, ActionDate)
                        VALUES 
                        (@CustomerID, @CustomerCode, @CustomerName, @OldBalance, @PaidAmount, @NewBalance, @Notes, @UserName, GETDATE());
                    "
                    Using cmdLog As New SqlCommand(sqlLog, cn, trans)
                        cmdLog.Parameters.AddWithValue("@CustomerID", custID)
                        cmdLog.Parameters.AddWithValue("@CustomerCode", code)
                        cmdLog.Parameters.AddWithValue("@CustomerName", client)
                        cmdLog.Parameters.AddWithValue("@OldBalance", oldB)
                        cmdLog.Parameters.AddWithValue("@PaidAmount", pay)
                        cmdLog.Parameters.AddWithValue("@NewBalance", newB)
                        cmdLog.Parameters.AddWithValue("@Notes", notesText)
                        cmdLog.Parameters.AddWithValue("@UserName", currentUserName)
                        cmdLog.ExecuteNonQuery()
                    End Using

                    ' 3. تحديث الرصيد في جدول Customers بالـ CustomerID
                    Dim sqlUpdateCustomer As String = "UPDATE Customers SET CurrentBalance = @CurrentBalance, LastTransactionDate = GETDATE(), updated_at = SYSUTCDATETIME() WHERE CustomerID = @CustomerID;"
                    Using cmdCust As New SqlCommand(sqlUpdateCustomer, cn, trans)
                        cmdCust.Parameters.AddWithValue("@CurrentBalance", newB)
                        cmdCust.Parameters.AddWithValue("@CustomerID", custID)
                        cmdCust.ExecuteNonQuery()
                    End Using

                    ' 4. تسجيل حركة إيداع الخزينة
                    If treasuryID > 0 AndAlso pay > 0 Then
                        Await TreasuryService.AddTransactionAsync(
                            treasuryID:=treasuryID,
                            transactionType:=TreasuryTransactionTypes.CustomerReceipt,
                            amount:=pay,
                            isDeposit:=True,
                            referenceID:=0,
                            referenceNo:=receiptRefNo,
                            notes:=$"سند قبض من العميل: {client} - {notesText}",
                            userID:=currentUserID,
                            cn:=cn,
                            trans:=trans
                        )
                    End If

                    ' 5. تحديث نقديات الوردية الحالية إن وجدت
                    If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing AndAlso pay > 0 Then
                        Dim activeShiftID As Integer = ShiftSession.CurrentShift.ShiftID
                        Dim sqlShift As String = "UPDATE Shifts SET TotalSales = ISNULL(TotalSales, 0) + @Pay WHERE ShiftID = @ShiftID;"
                        Using cmdShift As New SqlCommand(sqlShift, cn, trans)
                            cmdShift.Parameters.AddWithValue("@Pay", pay)
                            cmdShift.Parameters.AddWithValue("@ShiftID", activeShiftID)
                            cmdShift.ExecuteNonQuery()
                        End Using
                        ShiftSession.CurrentShift.TotalSales += pay
                    End If

                    trans.Commit()

                Catch ex As Exception
                    Try
                        trans.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return True
        ElseIf keyData = Keys.Enter AndAlso Not txtNotes.Focused Then
            btnOK.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class