Imports System.Data.SqlClient

Public Class frmSalaryPayment
    Private _activeShiftID As Integer? = ShiftSession.CurrentShift.ShiftID
    Private defaultTreasuryid As Integer
    Private Sub frmSalaryPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMonths()
        InitDropdowns()
        'CheckActiveShift()
        LoadSalaryHistory()
        Dim Drag As New FormDragHelper(Me, panelHeader)
        datagridviewsetup(dgvSalaries)

        defaultTreasuryid = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)
        If defaultTreasuryid > 0 Then
            cmbTreasury.SelectedValue = defaultTreasuryid
        ElseIf cmbTreasury.Items.Count > 0 Then
            cmbTreasury.SelectedIndex = 0
        End If
    End Sub

    Private Sub InitDropdowns()
        Try
            ' 1. تعبئة قائمة الموظفين
            Dim dtEmp As DataTable = DBModule.ExecuteQuery("SELECT EmployeeID, ArabicName, BasicSalary FROM Employees WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY ArabicName ASC")
            If dtEmp IsNot Nothing Then
                cmbEmployee.DataSource = dtEmp
                cmbEmployee.DisplayMember = "ArabicName"
                cmbEmployee.ValueMember = "EmployeeID"
                cmbEmployee.SelectedIndex = -1
            End If

            ' 2. تعبئة قائمة الخزائن
            Dim dtTreasury As DataTable = DBModule.ExecuteQuery("SELECT TreasuryID, TreasuryNameAr FROM Treasury WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY TreasuryNameAr ASC")
            If dtTreasury IsNot Nothing Then
                cmbTreasury.DataSource = dtTreasury
                cmbTreasury.DisplayMember = "TreasuryNameAr"
                cmbTreasury.ValueMember = "TreasuryID"
                cmbTreasury.SelectedIndex = -1
            End If

            nudYear.Minimum = 2000
            nudYear.Maximum = 2100
            nudYear.Value = DateTime.Now.Year

        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل القوائم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadMonths()
        Dim months As New List(Of Object) From {
        New With {.Name = "يناير", .Value = 1},
        New With {.Name = "فبراير", .Value = 2},
        New With {.Name = "مارس", .Value = 3},
        New With {.Name = "أبريل", .Value = 4},
        New With {.Name = "مايو", .Value = 5},
        New With {.Name = "يونيو", .Value = 6},
        New With {.Name = "يوليو", .Value = 7},
        New With {.Name = "أغسطس", .Value = 8},
        New With {.Name = "سبتمبر", .Value = 9},
        New With {.Name = "أكتوبر", .Value = 10},
        New With {.Name = "نوفمبر", .Value = 11},
        New With {.Name = "ديسمبر", .Value = 12}
    }

        cmbMonth.DataSource = months
        cmbMonth.DisplayMember = "Name"
        cmbMonth.ValueMember = "Value"
        cmbMonth.SelectedValue = DateTime.Now.Month
    End Sub
    ' فحص الوردية المفتوحة وربط الخزينة الافتراضية بها
    'Private Sub CheckActiveShift()
    '    Try
    '        Dim dt As DataTable = DBModule.ExecuteQuery("SELECT TOP 1 ShiftID, TreasuryID FROM Shifts WHERE Status = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY ShiftID DESC")
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            '_activeShiftID = Convert.ToInt32(dt.Rows(0)("ShiftID"))
    '            '_activeShiftID = ShiftSession.CurrentShift.ShiftID

    '            ' تحديد خزينة الوردية الحالية تلقائياً إن وجدت
    '            If Not IsDBNull(dt.Rows(0)("TreasuryID")) Then
    '                cmbTreasury.SelectedValue = Convert.ToInt32(dt.Rows(0)("TreasuryID"))
    '            End If
    '        Else
    '            '_activeShiftID = Nothing
    '        End If
    '    Catch ex As Exception
    '        Debug.WriteLine("Error checking shift: " & ex.Message)
    '    End Try
    'End Sub

    ' عند اختيار الموظف يُجلب راتبه الأساسي تلقائياً
    Private Sub cmbEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmployee.SelectedIndexChanged
        If cmbEmployee.SelectedItem IsNot Nothing AndAlso TypeOf cmbEmployee.SelectedItem Is DataRowView Then
            Dim row As DataRowView = CType(cmbEmployee.SelectedItem, DataRowView)
            Dim salary As Decimal = If(IsDBNull(row("BasicSalary")), 0, Convert.ToDecimal(row("BasicSalary")))
            txtBasicSalary.Text = salary.ToString("N2")
        Else
            txtBasicSalary.Text = "0.00"
        End If
        CalculateNetSalary()
    End Sub

    ' حساب الصافي تلقائياً وفورياً
    Private Sub txtCalculations_TextChanged(sender As Object, e As EventArgs) Handles txtAllowances.TextChanged, txtDeductions.TextChanged, txtAdvances.TextChanged
        CalculateNetSalary()
    End Sub

    Private Sub CalculateNetSalary()
        Dim basic As Decimal = 0
        Dim allowances As Decimal = 0
        Dim deductions As Decimal = 0
        Dim advances As Decimal = 0

        Decimal.TryParse(txtBasicSalary.Text, basic)
        Decimal.TryParse(txtAllowances.Text, allowances)
        Decimal.TryParse(txtDeductions.Text, deductions)
        Decimal.TryParse(txtAdvances.Text, advances)

        Dim net As Decimal = (basic + allowances) - (deductions + advances)
        If net < 0 Then net = 0
        lblNetSalary.Text = net.ToString("N2")
    End Sub

    ' زر حفظ وصرف الراتب وتحديث الخزينة والوردية
    Private Async Sub btnSaveAndPay_Click(sender As Object, e As EventArgs) Handles btnSaveAndPay.Click
        If cmbEmployee.SelectedIndex = -1 Then
            SmartMessageBox.Show("يرجى اختيار الموظف أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbTreasury.SelectedIndex = -1 Then
            SmartMessageBox.Show("يرجى تحديد الخزينة التي سيتم صرف المرتب منها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTreasury.Focus()
            Exit Sub
        End If

        Dim netSalary As Decimal = 0
        Decimal.TryParse(lblNetSalary.Text, netSalary)
        If netSalary <= 0 Then
            SmartMessageBox.Show("صافي الراتب المستحق يجب أن يكون أكبر من صفر!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'CheckActiveShift()
        If Not _activeShiftID.HasValue Then
            If SmartMessageBox.Show("تنبيه: لا توجد وردية مفتوحة حالياً بالدرج، هل تريد الصرف مباشرة من الخزينة المحددة فقط؟", "تأكيد الصرف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim empID As Integer = Convert.ToInt32(cmbEmployee.SelectedValue)
        Dim selectedTreasuryID As Integer = Convert.ToInt32(cmbTreasury.SelectedValue)
        Dim basic As Decimal = Convert.ToDecimal(txtBasicSalary.Text)
        Dim allowances As Decimal = 0, deductions As Decimal = 0, advances As Decimal = 0
        Decimal.TryParse(txtAllowances.Text, allowances)
        Decimal.TryParse(txtDeductions.Text, deductions)
        Decimal.TryParse(txtAdvances.Text, advances)

        Dim generatedNumber As String = "SAL-" & DateTime.Now.ToString("yyyyMM") & "-" & DateTime.Now.ToString("HHmmss")
        Dim currentUserID As Integer = 1 ' استبدله بـ CurrentUser.UserID حسب مشروعك

        Using con As New SqlConnection(DBModule.ConnectionString)
            Await con.OpenAsync()
            Dim trans As SqlTransaction = con.BeginTransaction()

            Try
                ' 1. تسجيل سند صرف الراتب والحصول على الـ PaymentID
                Dim sqlPay As String = "INSERT INTO SalaryPayments (PaymentNumber, EmployeeID, TreasuryID, ShiftID, PaymentDate, " &
                                       "SalaryMonth, SalaryYear, BasicSalary, Allowances, Deductions, Advances, NetSalary, Notes, PaidByUserID) " &
                                       "VALUES (@Number, @EmpID, @TreasuryID, @ShiftID, @Date, @Month, @Year, @Basic, @Allowances, @Deductions, @Advances, @Net, @Notes, @UserID); " &
                                       "SELECT SCOPE_IDENTITY();"

                Dim newPaymentID As Integer = 0
                Using cmdPay As New SqlCommand(sqlPay, con, trans)
                    cmdPay.Parameters.AddWithValue("@Number", generatedNumber)
                    cmdPay.Parameters.AddWithValue("@EmpID", empID)
                    cmdPay.Parameters.AddWithValue("@TreasuryID", selectedTreasuryID)
                    cmdPay.Parameters.AddWithValue("@ShiftID", If(_activeShiftID.HasValue, _activeShiftID.Value, DBNull.Value))
                    cmdPay.Parameters.AddWithValue("@Date", dtpPaymentDate.Value)
                    cmdPay.Parameters.AddWithValue("@Month", Convert.ToInt32(cmbMonth.SelectedValue))
                    cmdPay.Parameters.AddWithValue("@Year", Convert.ToInt32(nudYear.Value))
                    cmdPay.Parameters.AddWithValue("@Basic", basic)
                    cmdPay.Parameters.AddWithValue("@Allowances", allowances)
                    cmdPay.Parameters.AddWithValue("@Deductions", deductions)
                    cmdPay.Parameters.AddWithValue("@Advances", advances)
                    cmdPay.Parameters.AddWithValue("@Net", netSalary)
                    cmdPay.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                    cmdPay.Parameters.AddWithValue("@UserID", currentUserID)

                    Dim result = Await cmdPay.ExecuteScalarAsync()
                    newPaymentID = Convert.ToInt32(result)
                End Using

                ' 2. تسجيل حركة الخزنة تلقائياً (حركة سحب/صرف نقدي) عبر TreasuryService
                Await TreasuryService.AddTransactionAsync(
                    treasuryID:=selectedTreasuryID,
                    transactionType:=TreasuryTransactionTypes.Expense, ' أو TreasuryTransactionTypes.Salary
                    amount:=netSalary,
                    isDeposit:=False,                                  ' False لسحب وصرف المبلغ من رصيد الخزينة
                    referenceID:=newPaymentID,
                    referenceNo:=generatedNumber,
                    notes:=$"صرف راتب الموظف: {cmbEmployee.Text} عن شهر {cmbMonth.Text}/{nudYear.Value}",
                    userID:=currentUserID,
                    cn:=con,
                    trans:=trans
                )

                ' 3. في حالة وجود وردية مفتوحة: خصم المبلغ تلقائياً من مصروفات الوردية الحالية
                If _activeShiftID.HasValue Then
                    Dim sqlShift As String = "UPDATE Shifts SET TotalExpenses = TotalExpenses + @Amount WHERE ShiftID = @ShiftID;"
                    Using cmdShift As New SqlCommand(sqlShift, con, trans)
                        cmdShift.Parameters.AddWithValue("@Amount", netSalary)
                        cmdShift.Parameters.AddWithValue("@ShiftID", _activeShiftID.Value)
                        Await cmdShift.ExecuteNonQueryAsync()
                    End Using
                End If

                trans.Commit()
                SmartMessageBox.Show($"تم صرف راتب الموظف ({cmbEmployee.Text}) بنجاح بمبلغ {netSalary:N2} ج.م وتم خصمه من الخزينة!", "نجاح الصرف", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearInputs()
                LoadSalaryHistory()

            Catch ex As Exception
                trans.Rollback()
                SmartMessageBox.Show("حدث خطأ أثناء تسجيل وصرف الراتب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LoadSalaryHistory()
        Try
            Dim query As String = "SELECT SP.PaymentID, SP.PaymentNumber, E.ArabicName, T.TreasuryNameAr AS TreasuryName, SP.PaymentDate, " &
                                  "SP.SalaryMonth, SP.SalaryYear, SP.NetSalary, SP.Notes " &
                                  "FROM SalaryPayments SP " &
                                  "INNER JOIN Employees E ON SP.EmployeeID = E.EmployeeID " &
                                  "INNER JOIN Treasury T ON SP.TreasuryID = T.TreasuryID " &
                                  "ORDER BY SP.PaymentID DESC"

            Dim dt As DataTable = DBModule.ExecuteQuery(query)
            dgvSalaries.DataSource = dt

            If dgvSalaries.Columns.Contains("PaymentID") Then dgvSalaries.Columns("PaymentID").Visible = False
            If dgvSalaries.Columns.Contains("PaymentNumber") Then dgvSalaries.Columns("PaymentNumber").HeaderText = "رقم السند"
            If dgvSalaries.Columns.Contains("ArabicName") Then dgvSalaries.Columns("ArabicName").HeaderText = "الموظف"
            If dgvSalaries.Columns.Contains("TreasuryName") Then dgvSalaries.Columns("TreasuryName").HeaderText = "الخزينة المنصرف منها"
            If dgvSalaries.Columns.Contains("PaymentDate") Then dgvSalaries.Columns("PaymentDate").HeaderText = "تاريخ الصرف"
            If dgvSalaries.Columns.Contains("SalaryMonth") Then dgvSalaries.Columns("SalaryMonth").HeaderText = "الشهر"
            If dgvSalaries.Columns.Contains("SalaryYear") Then dgvSalaries.Columns("SalaryYear").HeaderText = "السنة"
            If dgvSalaries.Columns.Contains("NetSalary") Then dgvSalaries.Columns("NetSalary").HeaderText = "الصافي المصروف"
            If dgvSalaries.Columns.Contains("Notes") Then dgvSalaries.Columns("Notes").HeaderText = "ملاحظات"

        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل سجل الرواتب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearInputs()
        cmbEmployee.SelectedIndex = -1
        txtBasicSalary.Text = "0.00"
        txtAllowances.Text = "0.00"
        txtDeductions.Text = "0.00"
        txtAdvances.Text = "0.00"
        lblNetSalary.Text = "0.00"
        txtNotes.Clear()
        'CheckActiveShift()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInputs()
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