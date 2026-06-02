Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop.Excel
Imports Org.BouncyCastle.Asn1.Cmp

Public Class form_Expenses
    Dim x, y As Integer
    Dim newpoint As New System.Drawing.Point

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
        If txtUserPassword.Text <> Session.CurrentUserPassword Then
            MessageBox.Show("فشل التحقق من الأمان. كلمة المرور غير صحيحة.", "دخول غير مصرح", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            MessageBox.Show("يرجى إدخال مبلغ صحيح أكبر من صفر.", "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Return False
        End If

        ' التحقق من اختيار التصنيف
        If String.IsNullOrWhiteSpace(cmbCategory.Text) Then
            MessageBox.Show("يرجى اختيار تصنيف المصروف.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Return False
        End If

        ' التحقق من إدخال الجهة المستلمة
        If String.IsNullOrWhiteSpace(txtPayee.Text) Then
            MessageBox.Show("يرجى إدخال اسم الجهة المستلمة (المحل/الشخص).", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPayee.Focus()
            Return False
        End If

        ' التحقق من اختيار طريقة الدفع
        If String.IsNullOrWhiteSpace(cmbPaymentMethod.Text) Then
            MessageBox.Show("يرجى اختيار طريقة الدفع.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPaymentMethod.Focus()
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
            MessageBox.Show("خطأ: نص الاتصال (ConnectionString) غير معرف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim query As String = "INSERT INTO Expenses (Expense_Date, Category, Amount, Payment_Method, Payee, Payment_Status, Notes, Created_By) " &
                             "VALUES (@Date, @Category, @Amount, @Method, @Payee, @Status, @Notes, @User)"

        ' 2. استخدام Using للاتصال لضمان إغلاقه وتحرير الموارد تلقائياً
        Using NewConn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, NewConn)

                ' تجهيز البارامترات
                With cmd.Parameters
                    Dim selectedDate As DateTime = CType(dtpDate.Value, DateTime)
                    .AddWithValue("@Date", selectedDate.Date)
                    .AddWithValue("@Category", cmbCategory.Text)

                    ' معالجة المبلغ للتأكد من أنه رقم صحيح
                    Dim amount As Decimal = 0
                    Decimal.TryParse(txtAmount.Text, amount)
                    .AddWithValue("@Amount", amount)

                    .AddWithValue("@Method", cmbPaymentMethod.Text)
                    .AddWithValue("@Payee", txtPayee.Text)
                    .AddWithValue("@Status", cmbStatus.Text)
                    .AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text))
                    .AddWithValue("@User", If(Session.CurrentUserfullName IsNot Nothing, Session.CurrentUserfullName, "Unknown"))
                End With

                Try
                    ' 3. فتح الاتصال بشكل غير متزامن
                    Await NewConn.OpenAsync()

                    ' 4. تنفيذ الاستعلام بشكل غير متزامن
                    Await cmd.ExecuteNonQueryAsync()

                    MessageBox.Show("تم حفظ البيانات بنجاح", "تأكيد الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' استدعاء دالة تفريغ الحقول
                    ResetForm()

                Catch ex As SqlException
                    MessageBox.Show($"خطأ في قاعدة البيانات: {ex.Message}", "خطأ فني", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show($"خطأ عام: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Function

    Private Sub form_Expenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDefaultValues()
        Dim gComboBoxes = {cmbCategory, cmbPaymentMethod, cmbStatus}

        dtpDate.Value = DateTime.Now
        For Each combo In gComboBoxes
            combo.DropDownStyle = ComboBoxStyle.DropDown
        Next
    End Sub

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

        dtpDate.Value = DateTime.Now
    End Sub

End Class