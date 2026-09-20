Imports System.Data.SqlClient

Public Class frmShifts

    Private _cachedShifts As DataTable = Nothing
    Private _activeShiftID As Integer? = Nothing

    ' 1. تعبئة قائمة الورديات المرجعية (التي أنشأتها في frmWorkShifts)
    Private Sub FillWorkShiftsDropdown()
        Try
            Dim dt As DataTable = DBModule.ExecuteQuery("SELECT WorkShiftID, WorkShiftName FROM WorkShifts WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL)")
            If dt IsNot Nothing Then
                cmbWorkShift.DataSource = dt
                cmbWorkShift.DisplayMember = "WorkShiftName"
                cmbWorkShift.ValueMember = "WorkShiftID"
                cmbWorkShift.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل قائمة الورديات المرجعية: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. زر الـ + الصغير لفتح فورم الورديات المرجعية فرعياً وتحديث الكومبو بوكس بعدها
    Private Sub btnAddWorkShiftForm_Click(sender As Object, e As EventArgs) Handles btnAddWorkShiftForm.Click
        Dim frm As New frmWorkShifts()
        frm.ShowDialog()
        FillWorkShiftsDropdown()
    End Sub

    ' 3. دالة جلب سجل الورديات وحساب الـ KPIs للوردية الشغالة حالياً
    Private Sub LoadShiftsGridAndActiveStatus()
        Try
            ' التحقق من وجود وردية مفتوحة حالياً (Status = 1)
            Dim dtActive As DataTable = DBModule.ExecuteQuery("SELECT TOP 1 * FROM Shifts WHERE Status = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL)")

            If dtActive IsNot Nothing AndAlso dtActive.Rows.Count > 0 Then
                Dim row As DataRow = dtActive.Rows(0)
                _activeShiftID = Convert.ToInt32(row("ShiftID"))

                ' عرض المبالغ الحالية في الكروت
                lblOpeningCash.Text = Convert.ToDecimal(row("OpeningCash")).ToString("N2")
                lblTotalSales.Text = Convert.ToDecimal(row("TotalSales")).ToString("N2")
                lblTotalExpenses.Text = Convert.ToDecimal(row("TotalExpenses")).ToString("N2")
                lblTotalIncomes.Text = Convert.ToDecimal(row("TotalIncomes")).ToString("N2")

                ' معادلة الكاش المفترض وجوده بالدرج = العهدة + مبيعات الكاش + المقبوضات - المصروفات - المرتجعات
                Dim expected As Decimal = Convert.ToDecimal(row("OpeningCash")) + Convert.ToDecimal(row("TotalSales")) + Convert.ToDecimal(row("TotalIncomes")) - Convert.ToDecimal(row("TotalExpenses")) - Convert.ToDecimal(row("TotalRefunds"))
                lblExpectedCash.Text = expected.ToString("N2")

                ' تفعيل زر الإغلاق وتعطيل الفتح وتحديث عنوان الشاشة ببيان الوردية الشغالة
                btnOpenShift.Enabled = False
                btnCloseShift.Enabled = True
                btnSuspendShift.Enabled = True ' إمكانية التعليق متاحة
                btnResumeShift.Enabled = False
                'Guna2HtmlLabel1.Text = "الورديات (الوردية الحالية: 🟢 مفتوحة)"
                If Not IsDBNull(row("WorkShiftID")) Then cmbWorkShift.SelectedValue = row("WorkShiftID")
            Else
                _activeShiftID = Nothing
                ResetKPICards()
                btnOpenShift.Enabled = True
                btnCloseShift.Enabled = False
                btnSuspendShift.Enabled = False
                btnResumeShift.Enabled = True ' إمكانية استكمال وردية معلقة من الجدول متاحة
                'Guna2HtmlLabel1.Text = "الورديات (لا توجد وردية مفتوحة)"
            End If

            ' تحميل سجل الورديات في الجريد فيو مع بيان حالة الوردية (شغالة / معلقة / مقفولة)
            Dim query As String = "SELECT S.ShiftID, S.ShiftNumber, S.WorkShiftID, W.WorkShiftName, S.OpenDateTime, S.CloseDateTime, " &
                                  "S.OpeningCash, S.ClosingCash, S.ExpectedCash, S.CashDifference, S.Status, " &
                                  "CASE WHEN S.Status = 1 THEN N' نشطة' WHEN S.Status = 3 THEN N' معلقة' ELSE N' مغلقة' END AS StatusName, " &
                                  "S.Notes, ISNULL(S.TotalSales, 0) AS TotalSales, ISNULL(S.TotalExpenses, 0) AS TotalExpenses, ISNULL(S.TotalIncomes, 0) AS TotalIncomes " &
                                  "FROM Shifts S " &
                                  "LEFT JOIN WorkShifts W ON S.WorkShiftID = W.WorkShiftID " &
                                  "WHERE S.IsDeleted = 0 OR S.IsDeleted IS NULL ORDER BY S.ShiftID DESC"

            _cachedShifts = DBModule.ExecuteQuery(query)
            If _cachedShifts IsNot Nothing Then
                dgvShiftsHistory.DataSource = _cachedShifts.DefaultView

                ' إخفاء الأعمدة غير المطلوبة
                If dgvShiftsHistory.Columns.Contains("ShiftID") Then dgvShiftsHistory.Columns("ShiftID").Visible = False
                If dgvShiftsHistory.Columns.Contains("WorkShiftID") Then dgvShiftsHistory.Columns("WorkShiftID").Visible = False
                If dgvShiftsHistory.Columns.Contains("Status") Then dgvShiftsHistory.Columns("Status").Visible = False
                If dgvShiftsHistory.Columns.Contains("Notes") Then dgvShiftsHistory.Columns("Notes").Visible = False
                If dgvShiftsHistory.Columns.Contains("TotalSales") Then dgvShiftsHistory.Columns("TotalSales").Visible = False
                If dgvShiftsHistory.Columns.Contains("TotalExpenses") Then dgvShiftsHistory.Columns("TotalExpenses").Visible = False
                If dgvShiftsHistory.Columns.Contains("TotalIncomes") Then dgvShiftsHistory.Columns("TotalIncomes").Visible = False

                ' تصغير حجم عمود رقم الوردية وإظهار حالة الوردية
                If dgvShiftsHistory.Columns.Contains("ShiftNumber") Then
                    dgvShiftsHistory.Columns("ShiftNumber").HeaderText = "رقم الوردية"
                    dgvShiftsHistory.Columns("ShiftNumber").FillWeight = 60
                End If
                If dgvShiftsHistory.Columns.Contains("StatusName") Then
                    dgvShiftsHistory.Columns("StatusName").HeaderText = "حالة الوردية"
                    dgvShiftsHistory.Columns("StatusName").FillWeight = 85
                End If
                If dgvShiftsHistory.Columns.Contains("WorkShiftName") Then
                    dgvShiftsHistory.Columns("WorkShiftName").HeaderText = "نوع الوردية"
                    dgvShiftsHistory.Columns("WorkShiftName").FillWeight = 85
                End If
                If dgvShiftsHistory.Columns.Contains("OpenDateTime") Then
                    dgvShiftsHistory.Columns("OpenDateTime").HeaderText = "تاريخ الفتح"
                    dgvShiftsHistory.Columns("OpenDateTime").FillWeight = 110
                End If
                If dgvShiftsHistory.Columns.Contains("CloseDateTime") Then
                    dgvShiftsHistory.Columns("CloseDateTime").HeaderText = "تاريخ الإغلاق"
                    dgvShiftsHistory.Columns("CloseDateTime").FillWeight = 110
                End If
                If dgvShiftsHistory.Columns.Contains("OpeningCash") Then
                    dgvShiftsHistory.Columns("OpeningCash").HeaderText = "العهدة"
                    dgvShiftsHistory.Columns("OpeningCash").FillWeight = 75
                End If
                If dgvShiftsHistory.Columns.Contains("ClosingCash") Then
                    dgvShiftsHistory.Columns("ClosingCash").HeaderText = "الجرد الفعلي"
                    dgvShiftsHistory.Columns("ClosingCash").FillWeight = 80
                End If
                If dgvShiftsHistory.Columns.Contains("ExpectedCash") Then
                    dgvShiftsHistory.Columns("ExpectedCash").HeaderText = "المفترض"
                    dgvShiftsHistory.Columns("ExpectedCash").FillWeight = 80
                End If
                If dgvShiftsHistory.Columns.Contains("CashDifference") Then
                    dgvShiftsHistory.Columns("CashDifference").HeaderText = "العجز/الزيادة"
                    dgvShiftsHistory.Columns("CashDifference").FillWeight = 85
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل بيانات الورديات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetKPICards()
        lblOpeningCash.Text = "0.00"
        lblTotalSales.Text = "0.00"
        lblTotalExpenses.Text = "0.00"
        lblTotalIncomes.Text = "0.00"
        lblExpectedCash.Text = "0.00"
        lblCashDifference.Text = "0.00"
        lblCashDifference.ForeColor = Color.Black
    End Sub

    ' 4. حدث تحميل الفورم
    Private Sub frmShifts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' تعبئة قائمة الأعمدة بالعربية للبحث المتقدم
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.Add("رقم الوردية")
        cmbSearchField.Items.Add("حالة الوردية")
        cmbSearchField.Items.Add("نوع الوردية")
        cmbSearchField.Items.Add("تاريخ الفتح")
        cmbSearchField.Items.Add("تاريخ الإغلاق")
        cmbSearchField.Items.Add("العهدة")
        cmbSearchField.Items.Add("الجرد الفعلي")
        cmbSearchField.Items.Add("المفترض")
        cmbSearchField.Items.Add("العجز/الزيادة")
        cmbSearchField.Items.Add("ملاحظات")
        cmbSearchField.Items.Add("الكل")
        cmbSearchField.SelectedIndex = 0

        FillWorkShiftsDropdown()
        LoadShiftsGridAndActiveStatus()
        datagridviewsetup(dgvShiftsHistory)
        SetupShiftsContextMenu()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' تلوين وتأكيد بيان حالة الوردية بداخل الجريد فيو
    Private Sub dgvShiftsHistory_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvShiftsHistory.CellFormatting
        If e.RowIndex >= 0 AndAlso dgvShiftsHistory.Columns(e.ColumnIndex).Name = "StatusName" AndAlso e.Value IsNot Nothing Then
            Dim valStr As String = e.Value.ToString()
            If valStr.Contains("مفتوحة") OrElse valStr.Contains("شغالة") Then
                e.CellStyle.ForeColor = Color.ForestGreen
                e.CellStyle.Font = New Font(dgvShiftsHistory.Font, FontStyle.Bold)
            ElseIf valStr.Contains("معلقة") Then
                e.CellStyle.ForeColor = Color.OrangeRed
                e.CellStyle.Font = New Font(dgvShiftsHistory.Font, FontStyle.Bold)
            Else
                e.CellStyle.ForeColor = Color.Gray
            End If
        End If
    End Sub

    ' 5. حدث تحديد صف من DataGridView وتعبئة عناصر التحكّم في الواجهة
    Private Sub dgvShiftsHistory_SelectionChanged(sender As Object, e As EventArgs) Handles dgvShiftsHistory.SelectionChanged
        If dgvShiftsHistory.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvShiftsHistory.SelectedRows(0)

        If row.Cells("ShiftID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ShiftID").Value) Then
            ' نوع الوردية
            If dgvShiftsHistory.Columns.Contains("WorkShiftID") AndAlso Not IsDBNull(row.Cells("WorkShiftID").Value) Then
                cmbWorkShift.SelectedValue = row.Cells("WorkShiftID").Value
            End If

            ' العهدة الافتتاحية
            If dgvShiftsHistory.Columns.Contains("OpeningCash") AndAlso Not IsDBNull(row.Cells("OpeningCash").Value) Then
                Dim openingVal As Decimal = Convert.ToDecimal(row.Cells("OpeningCash").Value)
                txtOpeningCash.Text = openingVal.ToString("0.00")
                lblOpeningCash.Text = openingVal.ToString("N2")
            End If

            ' النقدية المجرودة فعلياً
            If dgvShiftsHistory.Columns.Contains("ClosingCash") AndAlso Not IsDBNull(row.Cells("ClosingCash").Value) Then
                txtClosingCash.Text = Convert.ToDecimal(row.Cells("ClosingCash").Value).ToString("0.00")
            Else
                txtClosingCash.Clear()
            End If

            ' المبلغ المفترض وجوده
            If dgvShiftsHistory.Columns.Contains("ExpectedCash") AndAlso Not IsDBNull(row.Cells("ExpectedCash").Value) Then
                lblExpectedCash.Text = Convert.ToDecimal(row.Cells("ExpectedCash").Value).ToString("N2")
            End If

            ' العجز أو الزيادة وتلوينه
            If dgvShiftsHistory.Columns.Contains("CashDifference") AndAlso Not IsDBNull(row.Cells("CashDifference").Value) Then
                Dim diff As Decimal = Convert.ToDecimal(row.Cells("CashDifference").Value)
                lblCashDifference.Text = diff.ToString("N2")
                If diff < 0 Then
                    lblCashDifference.ForeColor = Color.Red
                ElseIf diff > 0 Then
                    lblCashDifference.ForeColor = Color.Green
                Else
                    lblCashDifference.ForeColor = Color.Black
                End If
            End If

            ' الملاحظات
            If dgvShiftsHistory.Columns.Contains("Notes") AndAlso Not IsDBNull(row.Cells("Notes").Value) Then
                txtNotes.Text = row.Cells("Notes").Value.ToString()
            Else
                txtNotes.Clear()
            End If

            ' المبيعات، المصروفات، المقبوضات
            If dgvShiftsHistory.Columns.Contains("TotalSales") AndAlso Not IsDBNull(row.Cells("TotalSales").Value) Then
                lblTotalSales.Text = Convert.ToDecimal(row.Cells("TotalSales").Value).ToString("N2")
            End If

            If dgvShiftsHistory.Columns.Contains("TotalExpenses") AndAlso Not IsDBNull(row.Cells("TotalExpenses").Value) Then
                lblTotalExpenses.Text = Convert.ToDecimal(row.Cells("TotalExpenses").Value).ToString("N2")
            End If

            If dgvShiftsHistory.Columns.Contains("TotalIncomes") AndAlso Not IsDBNull(row.Cells("TotalIncomes").Value) Then
                lblTotalIncomes.Text = Convert.ToDecimal(row.Cells("TotalIncomes").Value).ToString("N2")
            End If
        End If
    End Sub

    ' 6. زر فتح وردية جديدة
    Private Sub btnOpenShift_Click(sender As Object, e As EventArgs) Handles btnOpenShift.Click
        If _activeShiftID.HasValue Then
            MessageBox.Show("توجد وردية مفتوحة بالفعل! يجب إغلاق الوردية الحالية أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbWorkShift.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار الوردية المرجعية (صباحية/مسائية) أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim openingFloat As Decimal = 0
        Decimal.TryParse(txtOpeningCash.Text.Trim(), openingFloat)

        Dim shiftNum As String = "SH-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")
        Dim currentUserID As Integer = 1 ' معرّف المستخدم الحالي

        Dim query As String = "INSERT INTO Shifts (ShiftNumber, WorkShiftID, UserID, OpenDateTime, OpeningCash, Status, IsActive, IsDeleted) " &
                              "VALUES (@ShiftNum, @WorkShiftID, @UserID, GETDATE(), @OpeningCash, 1, 1, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ShiftNum", shiftNum)
                cmd.Parameters.AddWithValue("@WorkShiftID", cmbWorkShift.SelectedValue)
                cmd.Parameters.AddWithValue("@UserID", currentUserID)
                cmd.Parameters.AddWithValue("@OpeningCash", openingFloat)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم فتح الوردية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtOpeningCash.Clear()
                    LoadShiftsGridAndActiveStatus()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء فتح الوردية: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. حساب الفارق حيّاً (عجز أحمر / زيادة أخضر) فور إدخال النقدية الفعلية
    Private Sub txtClosingCash_TextChanged(sender As Object, e As EventArgs) Handles txtClosingCash.TextChanged
        Dim actualCash As Decimal = 0
        Dim expectedCash As Decimal = 0

        Decimal.TryParse(txtClosingCash.Text.Trim(), actualCash)
        Decimal.TryParse(lblExpectedCash.Text, expectedCash)

        Dim diff As Decimal = actualCash - expectedCash
        lblCashDifference.Text = diff.ToString("N2")

        If diff < 0 Then
            lblCashDifference.ForeColor = Color.Red
        ElseIf diff > 0 Then
            lblCashDifference.ForeColor = Color.Green
        Else
            lblCashDifference.ForeColor = Color.Black
        End If
    End Sub

    ' 8. زر إغلاق الوردية الحالية
    Private Sub btnCloseShift_Click(sender As Object, e As EventArgs) Handles btnCloseShift.Click
        If Not _activeShiftID.HasValue Then
            MessageBox.Show("لا توجد وردية مفتوحة لإغلاقها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtClosingCash.Text) Then
            MessageBox.Show("يرجى إدخال المبلغ المجرود فعلياً بالدرج قبل الإغلاق!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtClosingCash.Focus()
            Exit Sub
        End If

        Dim actualCash As Decimal = Convert.ToDecimal(txtClosingCash.Text.Trim())
        Dim expectedCash As Decimal = Convert.ToDecimal(lblExpectedCash.Text)
        Dim diff As Decimal = actualCash - expectedCash
        Dim currentUserID As Integer = 1

        If MessageBox.Show($"هل أنت متأكد من إغلاق الوردية؟" & vbCrLf &
                            $"المبلغ المفترض: {expectedCash:N2}" & vbCrLf &
                            $"المبلغ المجرود: {actualCash:N2}" & vbCrLf &
                            $"الفارق: {diff:N2}", "تأكيد الإغلاق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim query As String = "UPDATE Shifts SET CloseDateTime = GETDATE(), ClosingCash = @ActualCash, ExpectedCash = @ExpectedCash, " &
                                  "CashDifference = @Diff, Status = 2, ClosedByUserID = @ClosedBy, Notes = @Notes " &
                                  "WHERE ShiftID = @ShiftID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ShiftID", _activeShiftID.Value)
                    cmd.Parameters.AddWithValue("@ActualCash", actualCash)
                    cmd.Parameters.AddWithValue("@ExpectedCash", expectedCash)
                    cmd.Parameters.AddWithValue("@Diff", diff)
                    cmd.Parameters.AddWithValue("@ClosedBy", currentUserID)
                    cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))

                    Try
                        Dim closedShiftID As Integer = _activeShiftID.Value
                        Dim closeNotes As String = If(String.IsNullOrEmpty(txtNotes.Text), "", txtNotes.Text.Trim())

                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم إغلاق الوردية المالية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' طباعة تقرير تقفيل الوردية الحراري (Z-Report) تلقائياً
                        PrintZReportForShift(closedShiftID, actualCash, expectedCash, diff, closeNotes)

                        txtClosingCash.Clear()
                        txtNotes.Clear()
                        LoadShiftsGridAndActiveStatus()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء إغلاق الوردية: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' 9. البحث المتقدم وتوليد الاقتراحات
    Private Sub ApplySearchFilter()
        If _cachedShifts Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        Dim selectedField As String = If(cmbSearchField.SelectedItem IsNot Nothing, cmbSearchField.SelectedItem.ToString(), "رقم الوردية")

        If String.IsNullOrWhiteSpace(keyword) Then
            _cachedShifts.DefaultView.RowFilter = ""
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim safeKeyword As String = keyword.Replace("'", "''")
        Dim filterExpr As String = ""

        Select Case selectedField
            Case "رقم الوردية"
                filterExpr = $"ShiftNumber LIKE '%{safeKeyword}%'"
            Case "حالة الوردية"
                filterExpr = $"StatusName LIKE '%{safeKeyword}%'"
            Case "نوع الوردية"
                filterExpr = $"WorkShiftName LIKE '%{safeKeyword}%'"
            Case "تاريخ الفتح"
                filterExpr = $"CONVERT(OpenDateTime, 'System.String') LIKE '%{safeKeyword}%'"
            Case "تاريخ الإغلاق"
                filterExpr = $"CONVERT(CloseDateTime, 'System.String') LIKE '%{safeKeyword}%'"
            Case "العهدة"
                filterExpr = $"CONVERT(OpeningCash, 'System.String') LIKE '%{safeKeyword}%'"
            Case "الجرد الفعلي"
                filterExpr = $"CONVERT(ClosingCash, 'System.String') LIKE '%{safeKeyword}%'"
            Case "المفترض"
                filterExpr = $"CONVERT(ExpectedCash, 'System.String') LIKE '%{safeKeyword}%'"
            Case "العجز/الزيادة"
                filterExpr = $"CONVERT(CashDifference, 'System.String') LIKE '%{safeKeyword}%'"
            Case "ملاحظات"
                filterExpr = $"Notes LIKE '%{safeKeyword}%'"
            Case Else ' الكل
                filterExpr = $"ShiftNumber LIKE '%{safeKeyword}%' OR StatusName LIKE '%{safeKeyword}%' OR WorkShiftName LIKE '%{safeKeyword}%' OR Notes LIKE '%{safeKeyword}%' OR CONVERT(OpeningCash, 'System.String') LIKE '%{safeKeyword}%' OR CONVERT(ClosingCash, 'System.String') LIKE '%{safeKeyword}%' OR CONVERT(ExpectedCash, 'System.String') LIKE '%{safeKeyword}%' OR CONVERT(CashDifference, 'System.String') LIKE '%{safeKeyword}%'"
        End Select

        _cachedShifts.DefaultView.RowFilter = filterExpr
        PopulateSuggestions(selectedField, keyword)
    End Sub

    Private Sub PopulateSuggestions(field As String, keyword As String)
        lstSuggestions.Items.Clear()
        If _cachedShifts Is Nothing OrElse String.IsNullOrWhiteSpace(keyword) Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim colName As String = "ShiftNumber"
        Select Case field
            Case "حالة الوردية"
                colName = "StatusName"
            Case "نوع الوردية"
                colName = "WorkShiftName"
            Case "تاريخ الفتح"
                colName = "OpenDateTime"
            Case "تاريخ الإغلاق"
                colName = "CloseDateTime"
            Case "العهدة"
                colName = "OpeningCash"
            Case "الجرد الفعلي"
                colName = "ClosingCash"
            Case "المفترض"
                colName = "ExpectedCash"
            Case "العجز/الزيادة"
                colName = "CashDifference"
            Case "ملاحظات"
                colName = "Notes"
            Case Else
                colName = "ShiftNumber"
        End Select

        Dim matches As New List(Of String)()
        For Each row As DataRow In _cachedShifts.Rows
            If Not row.IsNull(colName) Then
                Dim val As String = row(colName).ToString()
                If val.ToLower().Contains(keyword.ToLower()) AndAlso Not matches.Contains(val) Then
                    matches.Add(val)
                End If
            End If
        Next

        If matches.Count > 0 Then
            lstSuggestions.Items.AddRange(matches.ToArray())
            lstSuggestions.BringToFront()
            lstSuggestions.Visible = True
        Else
            lstSuggestions.Visible = False
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearchFilter()
    End Sub

    Private Sub cmbSearchField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchField.SelectedIndexChanged
        ApplySearchFilter()
    End Sub

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        SelectSuggestion()
    End Sub

    Private Sub lstSuggestions_DoubleClick(sender As Object, e As EventArgs) Handles lstSuggestions.DoubleClick
        SelectSuggestion()
    End Sub

    Private Sub SelectSuggestion()
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txtSearch.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
            ApplySearchFilter()

            If dgvShiftsHistory.Rows.Count > 0 Then
                dgvShiftsHistory.ClearSelection()
                dgvShiftsHistory.Rows(0).Selected = True
            End If
        End If
    End Sub

    ' 10. زر تفريغ الحقول وزر التحديث
    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtOpeningCash.Clear()
        txtClosingCash.Clear()
        txtNotes.Clear()
        txtSearch.Clear()
        lstSuggestions.Visible = False
        cmbWorkShift.SelectedIndex = -1
        ResetKPICards()
        If dgvShiftsHistory.Rows.Count > 0 Then dgvShiftsHistory.ClearSelection()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadShiftsGridAndActiveStatus()
    End Sub

    ' 11. أزرار التحكم بالنافذة (إغلاق / تصغير / تكبير)
    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
    ' ==========================================
    ' زر تعليق الوردية الحالية
    ' ==========================================
    Private Sub btnSuspendShift_Click(sender As Object, e As EventArgs) Handles btnSuspendShift.Click
        ' 1. التحقق من وجود وردية نشطة مفتوحة حالياً
        If Not _activeShiftID.HasValue Then
            MessageBox.Show("لا توجد وردية نشطة حالياً لتعليقها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. تأكيد التعليق من المستخدم
        If MessageBox.Show("هل أنت متأكد من تعليق الوردية الحالية؟" & vbCrLf &
                        "سيتم إيقاف العمل عليها مؤقتاً ويمكنك استكمالها لاحقاً.",
                        "تأكيد تعليق الوردية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ' 3. تحديث حالة الوردية إلى معلقة (Status = 3)
            Dim query As String = "UPDATE Shifts SET Status = 3, Notes = ISNULL(Notes, '') + N' [تم التعليق بتاريخ " & DateTime.Now.ToString("yyyy-MM-dd HH:mm") & "]' WHERE ShiftID = @ShiftID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ShiftID", _activeShiftID.Value)

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()

                        ' 4. تفريغ الوردية المعلقة من كاش الذاكرة لمنع استخدامها في البيع
                        ShiftSession.ClearSession()

                        MessageBox.Show("تم تعليق الوردية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' 5. إعادة تحديث واجهة الورديات والجريد فيو
                        LoadShiftsGridAndActiveStatus()
                        ClearFields()

                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء تعليق الوردية: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub
    ' ==========================================
    ' زر استكمال الوردية المعلقة
    ' ==========================================
    Private Sub btnResumeShift_Click(sender As Object, e As EventArgs) Handles btnResumeShift.Click
        ' 1. التحقق من عدم وجود وردية مفتوحة ونشطة بالفعل
        If _activeShiftID.HasValue Then
            MessageBox.Show("توجد وردية نشطة بالفعل! يجب تعليقها أو إغلاقها أولاً قبل استكمال وردية أخرى.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. التأكد من تحديد وردية من DataGridView
        If dgvShiftsHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى تحديد الوردية المعلقة المراد استكمالها من الجدول أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvShiftsHistory.SelectedRows(0)
        Dim selectedShiftID As Integer = Convert.ToInt32(row.Cells("ShiftID").Value)
        Dim statusVal As Byte = Convert.ToByte(row.Cells("Status").Value)

        ' 3. التأكد من أن الوردية المحددة حالتها معلقة (Status = 3)
        If statusVal <> 3 Then
            MessageBox.Show("يمكنك استكمال الورديات المعلقة فقط!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 4. تأكيد الاستكمال
        If MessageBox.Show("هل تريد استكمال العمل على هذه الوردية الآن؟", "تأكيد الاستكمال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ' 5. تحويل حالة الوردية إلى نشطة (Status = 1)
            Dim query As String = "UPDATE Shifts SET Status = 1 WHERE ShiftID = @ShiftID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ShiftID", selectedShiftID)

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()

                        MessageBox.Show("تم استكمال الوردية بنجاح وأصبحت هي الوردية النشطة الآن!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' 6. تحديث الواجهة وتحميل الوردية المستكملة في الذاكرة (Cache)
                        LoadShiftsGridAndActiveStatus()
                        InitializeShiftSession()

                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء استكمال الوردية: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' =========================================================
    ' قائمة الخيارات المنبثقة لسجل الورديات
    ' =========================================================
    Private Sub SetupShiftsContextMenu()
        Dim cms As New ContextMenuStrip()
        cms.Font = New Font("Segoe UI", 10.5!, FontStyle.Bold)
        cms.RightToLeft = RightToLeft.Yes

        Dim itemPrint = cms.Items.Add("طباعة تقرير الوردية (Z-Report) على الطابعة الحرارية")
        AddHandler itemPrint.Click, Sub() PrintSelectedShiftZReport()

        dgvShiftsHistory.ContextMenuStrip = cms
    End Sub

    Private Sub PrintSelectedShiftZReport()
        If dgvShiftsHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار وردية من الجدول أولاً لطباعة تقريرها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row = dgvShiftsHistory.SelectedRows(0)
        If row.Cells("ShiftID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ShiftID").Value) Then
            Dim sID As Integer = Convert.ToInt32(row.Cells("ShiftID").Value)
            Dim actCash As Decimal = If(row.Cells("ClosingCash").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ClosingCash").Value), Convert.ToDecimal(row.Cells("ClosingCash").Value), 0D)
            Dim expCash As Decimal = If(row.Cells("ExpectedCash").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ExpectedCash").Value), Convert.ToDecimal(row.Cells("ExpectedCash").Value), 0D)
            Dim diff As Decimal = If(row.Cells("CashDifference").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("CashDifference").Value), Convert.ToDecimal(row.Cells("CashDifference").Value), 0D)
            Dim nts As String = If(row.Cells("Notes").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Notes").Value), row.Cells("Notes").Value.ToString(), "")

            PrintZReportForShift(sID, actCash, expCash, diff, nts)
        End If
    End Sub

    ' =========================================================
    ' جلب تفاصيل الوردية وتوليد وطباعة تقرير Z-Report الحراري
    ' =========================================================
    Public Sub PrintZReportForShift(shiftID As Integer, actualCash As Decimal, expectedCash As Decimal, diff As Decimal, closeNotes As String)
        Try
            Dim queryShift As String = "
                SELECT S.*, W.WorkShiftName, ISNULL(U.User_Name, N'كاشير') AS CashierName
                FROM Shifts S
                LEFT JOIN WorkShifts W ON S.WorkShiftID = W.WorkShiftID
                LEFT JOIN Users_TBL U ON S.UserID = U.User_ID
                WHERE S.ShiftID = @ShiftID;
            "
            Dim dtShift As DataTable = Nothing
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(queryShift, conn)
                    cmd.Parameters.AddWithValue("@ShiftID", shiftID)
                    Dim da As New SqlDataAdapter(cmd)
                    dtShift = New DataTable()
                    da.Fill(dtShift)
                End Using
            End Using

            If dtShift Is Nothing OrElse dtShift.Rows.Count = 0 Then Return
            Dim row = dtShift.Rows(0)

            Dim shiftNumber As String = row("ShiftNumber").ToString()
            Dim workShiftName As String = If(IsDBNull(row("WorkShiftName")), "وردية عامة", row("WorkShiftName").ToString())
            Dim cashierName As String = If(IsDBNull(row("CashierName")), "كاشير", row("CashierName").ToString())
            Dim openDate As DateTime = Convert.ToDateTime(row("OpenDateTime"))
            Dim closeDate As DateTime = If(IsDBNull(row("CloseDateTime")), DateTime.Now, Convert.ToDateTime(row("CloseDateTime")))
            Dim openingCash As Decimal = If(IsDBNull(row("OpeningCash")), 0D, Convert.ToDecimal(row("OpeningCash")))
            Dim totalSales As Decimal = If(IsDBNull(row("TotalSales")), 0D, Convert.ToDecimal(row("TotalSales")))
            Dim totalExpenses As Decimal = If(IsDBNull(row("TotalExpenses")), 0D, Convert.ToDecimal(row("TotalExpenses")))
            Dim totalRefunds As Decimal = If(IsDBNull(row("TotalRefunds")), 0D, Convert.ToDecimal(row("TotalRefunds")))

            Dim totalTakeaway As Decimal = 0D
            Dim totalDineIn As Decimal = 0D
            Dim totalDelivery As Decimal = 0D
            Dim deliveryFees As Decimal = 0D

            Dim querySales As String = "
                SELECT OrderType, SUM(NetTotal) AS TypeTotal, SUM(DeliveryFee) AS DeliveryTotal
                FROM SalesInvoices
                WHERE ShiftID = @ShiftID AND (IsDeleted = 0 OR IsDeleted IS NULL)
                GROUP BY OrderType;
            "
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(querySales, conn)
                    cmd.Parameters.AddWithValue("@ShiftID", shiftID)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim oType = Convert.ToByte(rdr("OrderType"))
                            Dim net = If(IsDBNull(rdr("TypeTotal")), 0D, Convert.ToDecimal(rdr("TypeTotal")))
                            Dim fee = If(IsDBNull(rdr("DeliveryTotal")), 0D, Convert.ToDecimal(rdr("DeliveryTotal")))

                            Select Case oType
                                Case 1 ' Takeaway
                                    totalTakeaway += net
                                Case 2 ' DineIn
                                    totalDineIn += net
                                Case 3 ' Delivery
                                    totalDelivery += net
                                    deliveryFees += fee
                            End Select
                        End While
                    End Using
                End Using
            End Using

            RestaurantPrintManager.PrintShiftZReport(shiftNumber, workShiftName, openDate, closeDate, cashierName,
                                                    openingCash, totalSales, totalDineIn, totalTakeaway, totalDelivery,
                                                    deliveryFees, totalExpenses, totalRefunds, expectedCash, actualCash,
                                                    diff, closeNotes)

        Catch ex As Exception
            Logger.LogError("PrintZReportForShift", ex)
            MessageBox.Show("حدث خطأ أثناء طباعة تقرير الوردية (Z-Report): " & ex.Message, "خطأ طباعة", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class