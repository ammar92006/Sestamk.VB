Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop.Excel
Imports Org.BouncyCastle.Asn1.Cmp

Public Class form_Expenses
    Dim x, y As Integer
    Dim newpoint As New System.Drawing.Point
    Private defaultTreasuryid As Integer = -1

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click

        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub form_Expenses_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Panel1.MouseMove, Label1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub form_Expenses_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel1.MouseDown, Label1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized

    End Sub

    Private Function ValidateSecurity() As Boolean
        ' مقارنة عبر تجزئة PBKDF2 المخزنة في الجلسة (لا تخزن كلمة المرور نفسها)
        If Not PasswordHasher.Verify(txtUserPassword.Text, Session.CurrentUserPasswordHash) Then
            SmartMessageBox.Show("فشل التحقق من الأمان. كلمة المرور غير صحيحة.", "دخول غير مصرح", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        Return True
    End Function

    Private Sub LoadDefaultValues()
        ' مقترحات تصنيفات المصاريف
        cmbCategory.Items.AddRange(New String() {"طعام وشراب", "مواصلات", "سكن وإيجار", "فواتير (كهرباء/ماء)", "صحة وعلاج", "ترفيه", "تسوق", "أخرى"})

        ' مقترحات طرق الدفع
        cmbPaymentMethod.Items.AddRange(New String() {"نقدي", "كاش"})

        ' مقترحات حالة الدفع
        cmbStatus.Items.AddRange(New String() {"مدفوع", "آجل (لم يدفع)", "قيد الانتظار"})
    End Sub
    Private Function ValidateInputs() As Boolean
        ' التحقق من إدخال المبلغ وصحته
        Dim amount As Decimal
        If Not Decimal.TryParse(txtAmount.Text, amount) OrElse amount <= 0 Then
            SmartMessageBox.Show("يرجى إدخال مبلغ صحيح أكبر من صفر.", "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Return False
        End If

        ' التحقق من اختيار التصنيف
        If String.IsNullOrWhiteSpace(cmbCategory.Text) Then
            SmartMessageBox.Show("يرجى اختيار تصنيف المصروف.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Return False
        End If

        ' التحقق من إدخال الجهة المستلمة
        If String.IsNullOrWhiteSpace(txtPayee.Text) Then
            SmartMessageBox.Show("يرجى إدخال اسم الجهة المستلمة (المحل/الشخص).", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPayee.Focus()
            Return False
        End If

        ' التحقق من اختيار طريقة الدفع
        If String.IsNullOrWhiteSpace(cmbPaymentMethod.Text) Then
            SmartMessageBox.Show("يرجى اختيار طريقة الدفع.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPaymentMethod.Focus()
            Return False
        End If
        ' التحقق من اختيار الخزنة
        If cmbTreasury.SelectedValue Is Nothing Then
            SmartMessageBox.Show("يرجى اختيار الخزنة المراد الصرف منها.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTreasury.Focus()
            Return False
        End If
        Return True
    End Function

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateSecurity() Then Return
        If Not ValidateInputs() Then Return

        Await SaveExpenseAsync()
    End Sub

    Private Async Function SaveExpenseAsync() As Task
        ' 1. تأكد أولاً أن نص الاتصال ليس فارغاً
        If String.IsNullOrEmpty(ConnectionString) Then
            SmartMessageBox.Show("خطأ: نص الاتصال (ConnectionString) غير معرف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim currentShiftID As Integer? = If(ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, CType(Nothing, Integer?))

        Dim query As String = "INSERT INTO Expenses (Expense_Date, Category, Amount, Payment_Method, Payee, Payment_Status, Notes, Created_By, TreasuryID, ShiftID, UserID) " &
                         "VALUES (@Date, @Category, @Amount, @Method, @Payee, @Status, @Notes, @User, @TreasuryID, @ShiftID, @UserID)"

        ' استخدام Using لضمان إغلاق الاتصال وتحرير الموارد
        Using NewConn As New SqlConnection(ConnectionString)
            Await NewConn.OpenAsync()

            ' 🛑 بدء الـ Transaction لحماية العملية المزدوجة
            Using trans As SqlTransaction = NewConn.BeginTransaction()
                Using cmd As New SqlCommand(query, NewConn, trans)

                    ' تجهيز بارامترات فاتورة المصروف
                    With cmd.Parameters
                        Dim selectedDate As DateTime = CType(dtpDate.Value, DateTime)
                        .AddWithValue("@Date", selectedDate.Date)
                        .AddWithValue("@Category", cmbCategory.Text)

                        Dim amount As Decimal = 0
                        Decimal.TryParse(txtAmount.Text, amount)
                        .AddWithValue("@Amount", amount)

                        .AddWithValue("@Method", cmbPaymentMethod.Text)
                        .AddWithValue("@Payee", txtPayee.Text)
                        .AddWithValue("@Status", cmbStatus.Text)
                        .AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text))
                        .AddWithValue("@User", If(Session.CurrentUserfullName IsNot Nothing, Session.CurrentUserfullName, "Unknown"))
                        .AddWithValue("@TreasuryID", Convert.ToInt32(cmbTreasury.SelectedValue))
                        .AddWithValue("@ShiftID", If(currentShiftID.HasValue, currentShiftID.Value, CType(DBNull.Value, Object)))
                        .AddWithValue("@UserID", If(Session.CurrentUserID > 0, Session.CurrentUserID, CType(DBNull.Value, Object)))
                    End With

                    Try
                        ' أولاً: حفظ سجل المصروف في جدول الـ Expenses
                        Await cmd.ExecuteNonQueryAsync()

                        ' ثانياً: تسجيل حركة السحب من الخزنة المحددة وتحديث رصيدها تلقائياً
                        Dim expenseAmount As Decimal = 0
                        Decimal.TryParse(txtAmount.Text, expenseAmount)

                        Await TreasuryService.AddTransactionAsync(
                        treasuryID:=Convert.ToInt32(cmbTreasury.SelectedValue),
                        transactionType:=TreasuryTransactionTypes.Expense, ' القيمة 6 من الـ Enum الخاص بك للمصروفات
                        amount:=expenseAmount,
                        isDeposit:=False, ' سحب من الخزنة
                        referenceID:=0,
                        referenceNo:=txtPayee.Text.Trim(),
                        notes:=cmbCategory.Text & " - " & txtNotes.Text.Trim(),
                        userID:=Session.CurrentUserID,
                        cn:=NewConn,
                        trans:=trans
                    )

                        ' ثالثاً: تحديث إجمالي مصروفات الوردية الحالية في قاعدة البيانات والذاكرة
                        If currentShiftID.HasValue AndAlso expenseAmount > 0 Then
                            Dim queryShiftExp As String = "UPDATE Shifts SET TotalExpenses = ISNULL(TotalExpenses, 0) + @Exp WHERE ShiftID = @ShiftID;"
                            Using cmdShift As New SqlCommand(queryShiftExp, NewConn, trans)
                                cmdShift.Parameters.AddWithValue("@Exp", expenseAmount)
                                cmdShift.Parameters.AddWithValue("@ShiftID", currentShiftID.Value)
                                Await cmdShift.ExecuteNonQueryAsync()
                            End Using

                            ' إجماليات الوردية في القاعدة هي المصدر الوحيد (v1.3.0)
                        End If

                        ' إذا نجحت العمليات نقوم بالتثبيت النهائي
                        trans.Commit()

                        Try
                            Dim notesStr As String = If(Not String.IsNullOrWhiteSpace(txtNotes.Text), " - " & txtNotes.Text.Trim(), "")
                            Dim expDesc As String = cmbCategory.Text & notesStr
                            NotificationManager.Instance.NotifyExpense("تسجيل مصروف جديد 💸", $"تم تسجيل مصروف بقيمة {expenseAmount:N2} ج.م ({expDesc})")
                        Catch exNotif As Exception
                            Logger.LogError("form_Expenses.btnSave_Click - Notification", exNotif)
                        End Try

                        SmartMessageBox.Show("تم حفظ بيانات المصروف وخصمه من الخزنة بنجاح", "تأكيد الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' استدعاء دالة تفريغ الحقول
                        ResetForm()

                    Catch ex As SqlException
                        trans.Rollback()
                        SmartMessageBox.Show($"خطأ في قاعدة البيانات: {ex.Message}", "خطأ فني", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Catch ex As Exception
                        trans.Rollback()
                        ' هنا ستظهر رسالة "عذراً، لا يمكن إتمام العملية نظراً لعدم وجود رصيد كافٍ في الخزنة" في حال حدوثها
                        SmartMessageBox.Show(ex.Message, "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End Using
    End Function

    Private Async Sub form_Expenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadDefaultValues()
        'Dim gComboBoxes = {cmbCategory, cmbPaymentMethod, cmbStatus}

        'dtpDate.Value = DateTime.Now
        'For Each combo In gComboBoxes
        '    combo.DropDownStyle = ComboBoxStyle.DropDown
        'Next


        LoadDefaultValues()
        Dim gComboBoxes = {cmbCategory, cmbPaymentMethod, cmbStatus, cmbTreasury} ' ⬅️ أضفنا الكومبو الجديد هنا

        dtpDate.Value = DateTime.Now
        For Each combo In gComboBoxes
            combo.DropDownStyle = ComboBoxStyle.DropDownList ' 💡 يفضل DropDownList لضمان عدم إدخال اسم خزنة غير موجود
        Next

        ' ⬅️ استدعاء دالة تعبئة الخزن بشكل غير متزامن
        Await LoadTreasuriesAsync()
    End Sub
    Private Async Function LoadTreasuriesAsync() As Task

        Try

            Dim dt As New System.Data.DataTable()

            Using cn As SqlConnection = Await NewConnAsync()

                Const sql As String =
                    "
                    SELECT
                    TreasuryID,
                    TreasuryNameAr
                    FROM Treasury
                    WHERE IsActive = 1
                    AND IsDeleted = 0
                    "

                Using da As New SqlDataAdapter(sql, cn)

                    Await Task.Run(Sub() da.Fill(dt))

                End Using

            End Using
            cmbTreasury.DataSource = dt
            cmbTreasury.DisplayMember = "TreasuryNameAr"
            cmbTreasury.ValueMember = "TreasuryID"
            defaultTreasuryid = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)
            If defaultTreasuryid > 0 Then
                cmbTreasury.SelectedValue = defaultTreasuryid
            ElseIf cmbTreasury.Items.Count > 0 Then
                cmbTreasury.SelectedIndex = 0
            End If

        Catch ex As Exception

            SmartMessageBox.Show(ex.Message)

        End Try

    End Function

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ResetForm()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        DBModule.OpenSingleForm(Of ExpensesReportForm)()
    End Sub

    Private Sub ResetForm()
        txtAmount.Value = 0
        txtPayee.Clear()
        txtNotes.Clear()
        txtUserPassword.Clear()

        cmbCategory.Text = ""
        cmbPaymentMethod.Text = ""
        cmbStatus.Text = ""

        cmbCategory.SelectedIndex = -1
        cmbPaymentMethod.SelectedIndex = -1
        cmbStatus.SelectedIndex = -1
        cmbTreasury.SelectedIndex = -1
        dtpDate.Value = DateTime.Now
    End Sub

End Class