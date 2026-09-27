Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports ClosedXML.Excel

Public Class FrmSupplierTransactions

    Private _initialSupplierId As Integer = 0
    Private _initialSupplierName As String = ""
    Private _isLoading As Boolean = False

    ''' <summary>
    ''' المنشئ الافتراضي المطلوب لفتح الشاشة من القائمة الرئيسية دون أخطاء Reflection
    ''' </summary>
    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' منشئ مخصص لفتح كشف الحساب لمورد محدد مباشرة من شاشة الموردين
    ''' </summary>
    Public Sub New(supplierId As Integer, Optional supplierName As String = "")
        InitializeComponent()
        _initialSupplierId = supplierId
        _initialSupplierName = supplierName
    End Sub

    Private Async Sub FrmSupplierTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _isLoading = True

            ' تفعيل سحب النافذة
            Dim drag As New FormDragHelper(Me, panelHeader)

            ' تطبيق الثيم العام وتنسيق الجدول
            ThemeManager.Instance.ApplyTheme(Me)
            datagridviewsetup(grid)

            ' ضبط التواريخ الافتراضية (من أول الشهر الحالي حتى اليوم)
            fromPicker.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            toPicker.Value = DateTime.Now

            ' تعبئة أنواع الحركات
            typeBox.Items.Clear()
            typeBox.Items.Add("جميع الحركات")
            typeBox.Items.Add("فاتورة شراء")
            typeBox.Items.Add("سداد دفعة")
            typeBox.Items.Add("رصيد افتتاحي")
            typeBox.Items.Add("مردودات مشتريات")
            typeBox.SelectedIndex = 0

            ' تعبئة طرق الدفع
            methodBox.Items.Clear()
            methodBox.Items.AddRange(New String() {"نقدي", "تحويل بنكي", "شيك", "أخرى"})
            methodBox.SelectedIndex = 0

            ' تحميل الخزائن والموردين
            Await LoadTreasuriesAsync()
            LoadSuppliers()

            _isLoading = False

            ' تحميل الكشف للمورد المختار
            If supplierBox.SelectedIndex >= 0 Then
                LoadStatement()
            End If

        Catch ex As Exception
            _isLoading = False
            MessageBox.Show("خطأ أثناء تحميل شاشة كشف حساب المورد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSuppliers()
        Try
            Dim dt As DataTable = DBModule.ExecuteQuery("SELECT SupplierID, SupplierName FROM Suppliers WHERE IsDeleted = 0 OR IsDeleted IS NULL ORDER BY SupplierName ASC")
            supplierBox.DataSource = dt
            supplierBox.DisplayMember = "SupplierName"
            supplierBox.ValueMember = "SupplierID"

            If _initialSupplierId > 0 Then
                supplierBox.SelectedValue = _initialSupplierId
            ElseIf dt.Rows.Count > 0 Then
                supplierBox.SelectedIndex = 0
            Else
                supplierBox.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في جلب بيانات الموردين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Function LoadTreasuriesAsync() As Task
        Try
            Dim dt As New DataTable()
            Using cn As SqlConnection = Await DBModule.NewConnAsync()
                Const sql As String = "SELECT TreasuryID, TreasuryNameAr FROM Treasury WHERE IsActive = 1 AND IsDeleted = 0 ORDER BY TreasuryID;"
                Using da As New SqlDataAdapter(sql, cn)
                    Await Task.Run(Sub() da.Fill(dt))
                End Using
            End Using

            treasuryBox.DataSource = dt
            treasuryBox.DisplayMember = "TreasuryNameAr"
            treasuryBox.ValueMember = "TreasuryID"

            Dim defTreasuryID As Integer = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)
            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing AndAlso ShiftSession.CurrentShift.TreasuryID.HasValue AndAlso ShiftSession.CurrentShift.TreasuryID.Value > 0 Then
                treasuryBox.SelectedValue = ShiftSession.CurrentShift.TreasuryID.Value
            ElseIf defTreasuryID > 0 Then
                treasuryBox.SelectedValue = defTreasuryID
            ElseIf treasuryBox.Items.Count > 0 Then
                treasuryBox.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء جلب الخزائن: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub supplierBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles supplierBox.SelectedIndexChanged
        If Not _isLoading AndAlso supplierBox.SelectedIndex >= 0 Then
            LoadStatement()
        End If
    End Sub

    Private Sub btnRefreshStatement_Click(sender As Object, e As EventArgs) Handles btnRefreshStatement.Click
        LoadStatement()
    End Sub

    ''' <summary>
    ''' جلب وعرض كشف الحساب التفصيلي مع الرصيد السابق وحساب المجاميع
    ''' </summary>
    Public Sub LoadStatement()
        If supplierBox.SelectedValue Is Nothing OrElse Not Integer.TryParse(supplierBox.SelectedValue.ToString(), Nothing) Then
            Return
        End If

        Dim supID As Integer = Convert.ToInt32(supplierBox.SelectedValue)
        Dim fromDate As DateTime = fromPicker.Value.Date
        Dim toDate As DateTime = toPicker.Value.Date.AddDays(1).AddSeconds(-1)

        Try
            ' 1. احتساب الرصيد السابق قبل تاريخ البداية
            Dim prevBalance As Decimal = 0
            Dim sqlPrev As String = "SELECT ISNULL(SUM(Credit - Debit), 0) FROM SupplierTransactions WHERE SupplierID = @SupID AND TransactionDate < @FromDate"
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmdPrev As New SqlCommand(sqlPrev, cn)
                    cmdPrev.Parameters.AddWithValue("@SupID", supID)
                    cmdPrev.Parameters.AddWithValue("@FromDate", fromDate)
                    prevBalance = Convert.ToDecimal(cmdPrev.ExecuteScalar())
                End Using
            End Using

            ' 2. جلب الحركات داخل الفترة
            Dim filterType As String = ""
            If typeBox.SelectedIndex = 1 Then
                filterType = " AND TransactionType = 'PURCHASE'"
            ElseIf typeBox.SelectedIndex = 2 Then
                filterType = " AND TransactionType = 'PAYMENT'"
            ElseIf typeBox.SelectedIndex = 3 Then
                filterType = " AND TransactionType = 'OPENING_BALANCE'"
            ElseIf typeBox.SelectedIndex = 4 Then
                filterType = " AND TransactionType = 'RETURN'"
            End If

            Dim sqlTx As String = "SELECT TransactionID, TransactionDate, TransactionType, ISNULL(ReferenceNo, '-') AS ReferenceNo, " &
                                  "       Credit, Debit, BalanceAfter, ISNULL(Notes, '') AS Notes " &
                                  "FROM SupplierTransactions " &
                                  "WHERE SupplierID = @SupID AND TransactionDate BETWEEN @FromDate AND @ToDate " & filterType & " " &
                                  "ORDER BY TransactionDate ASC, TransactionID ASC"

            Dim dtRaw As New DataTable()
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmdTx As New SqlCommand(sqlTx, cn)
                    cmdTx.Parameters.AddWithValue("@SupID", supID)
                    cmdTx.Parameters.AddWithValue("@FromDate", fromDate)
                    cmdTx.Parameters.AddWithValue("@ToDate", toDate)
                    Using da As New SqlDataAdapter(cmdTx)
                        da.Fill(dtRaw)
                    End Using
                End Using
            End Using

            ' 3. بناء جدول العرض مع سطر الرصيد السابق والتراكمي
            Dim dtDisplay As New DataTable()
            dtDisplay.Columns.Add("TransactionID", GetType(String))
            dtDisplay.Columns.Add("TransactionDate", GetType(String))
            dtDisplay.Columns.Add("TransactionTypeDisplay", GetType(String))
            dtDisplay.Columns.Add("ReferenceNo", GetType(String))
            dtDisplay.Columns.Add("Credit", GetType(Decimal))
            dtDisplay.Columns.Add("Debit", GetType(Decimal))
            dtDisplay.Columns.Add("BalanceRunning", GetType(Decimal))
            dtDisplay.Columns.Add("Notes", GetType(String))

            ' إضافة سطر الرصيد السابق أولاً
            Dim rowPrev As DataRow = dtDisplay.NewRow()
            rowPrev("TransactionID") = "-"
            rowPrev("TransactionDate") = fromDate.ToString("yyyy-MM-dd")
            rowPrev("TransactionTypeDisplay") = "رصيد سابق"
            rowPrev("ReferenceNo") = "-"
            rowPrev("Credit") = 0D
            rowPrev("Debit") = 0D
            rowPrev("BalanceRunning") = prevBalance
            rowPrev("Notes") = "الرصيد التراكمي المستحق قبل بداية الفترة المختارة"
            dtDisplay.Rows.Add(rowPrev)

            Dim runningBal As Decimal = prevBalance
            Dim totalCredit As Decimal = 0
            Dim totalDebit As Decimal = 0

            For Each r As DataRow In dtRaw.Rows
                Dim cr As Decimal = Convert.ToDecimal(r("Credit"))
                Dim db As Decimal = Convert.ToDecimal(r("Debit"))
                Dim tType As String = r("TransactionType").ToString()

                Dim typeAr As String = tType
                Select Case tType
                    Case "PURCHASE" : typeAr = "فاتورة شراء"
                    Case "PAYMENT" : typeAr = "سداد دفعة"
                    Case "OPENING_BALANCE" : typeAr = "رصيد افتتاحي"
                    Case "RETURN" : typeAr = "مردودات مشتريات"
                End Select

                runningBal += (cr - db)
                totalCredit += cr
                totalDebit += db

                Dim rowNew As DataRow = dtDisplay.NewRow()
                rowNew("TransactionID") = r("TransactionID").ToString()
                rowNew("TransactionDate") = Convert.ToDateTime(r("TransactionDate")).ToString("yyyy-MM-dd HH:mm")
                rowNew("TransactionTypeDisplay") = typeAr
                rowNew("ReferenceNo") = r("ReferenceNo").ToString()
                rowNew("Credit") = cr
                rowNew("Debit") = db
                rowNew("BalanceRunning") = runningBal
                rowNew("Notes") = r("Notes").ToString()
                dtDisplay.Rows.Add(rowNew)
            Next

            grid.DataSource = dtDisplay
            FormatGrid()

            ' 4. جلب الرصيد الإجمالي الفعلي للمورد وتحديث بطاقة الرصيد
            Dim curBalanceActual As Decimal = 0
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmdBal As New SqlCommand("SELECT ISNULL(CurrentBalance, 0) FROM Suppliers WHERE SupplierID = @ID", cn)
                    cmdBal.Parameters.AddWithValue("@ID", supID)
                    curBalanceActual = Convert.ToDecimal(cmdBal.ExecuteScalar())
                End Using
            End Using

            If curBalanceActual > 0 Then
                balanceLabel.Text = $"الرصيد الحالي المستحق للمورد: {curBalanceActual:N2} ج (دائن - له علينا)"
                balanceLabel.ForeColor = Color.DarkRed
            ElseIf curBalanceActual < 0 Then
                balanceLabel.Text = $"الرصيد الحالي (مدين): {Math.Abs(curBalanceActual):N2} ج (لنا عنده)"
                balanceLabel.ForeColor = Color.DarkGreen
            Else
                balanceLabel.Text = "الرصيد الحالي: 0.00 ج (الحساب خالص)"
                balanceLabel.ForeColor = Color.Black
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء استخراج كشف الحساب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If grid.Columns.Count = 0 Then Exit Sub

        If grid.Columns.Contains("TransactionID") Then grid.Columns("TransactionID").HeaderText = "رقم الحركة"
        If grid.Columns.Contains("TransactionDate") Then grid.Columns("TransactionDate").HeaderText = "التاريخ"
        If grid.Columns.Contains("TransactionTypeDisplay") Then grid.Columns("TransactionTypeDisplay").HeaderText = "نوع الحركة"
        If grid.Columns.Contains("ReferenceNo") Then grid.Columns("ReferenceNo").HeaderText = "رقم المرجع / الفاتورة"
        If grid.Columns.Contains("Credit") Then
            grid.Columns("Credit").HeaderText = "دائن (+بضاعة/لنا عليه)"
            grid.Columns("Credit").DefaultCellStyle.Format = "N2"
        End If
        If grid.Columns.Contains("Debit") Then
            grid.Columns("Debit").HeaderText = "مدين (-مسدد)"
            grid.Columns("Debit").DefaultCellStyle.Format = "N2"
        End If
        If grid.Columns.Contains("BalanceRunning") Then
            grid.Columns("BalanceRunning").HeaderText = "الرصيد التراكمي"
            grid.Columns("BalanceRunning").DefaultCellStyle.Format = "N2"
        End If
        If grid.Columns.Contains("Notes") Then grid.Columns("Notes").HeaderText = "البيان / ملاحظات"
    End Sub

    ''' <summary>
    ''' تسجيل سداد دفعة للمورد وتحديث رصيد الخزينة وحساب المورد بدقة ذرية
    ''' </summary>
    Private Async Sub btnAddPayment_Click(sender As Object, e As EventArgs) Handles btnAddPayment.Click
        If supplierBox.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار المورد أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If amountBox.Value <= 0 Then
            MessageBox.Show("يرجى إدخال مبلغ سداد صحيح أكبر من الصفر!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            amountBox.Focus()
            Exit Sub
        End If

        If treasuryBox.SelectedIndex = -1 Then
            MessageBox.Show("يرجى اختيار الخزينة التي سيتم الصرف منها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            treasuryBox.Focus()
            Exit Sub
        End If

        Dim supID As Integer = Convert.ToInt32(supplierBox.SelectedValue)
        Dim supName As String = supplierBox.Text
        Dim treasuryID As Integer = Convert.ToInt32(treasuryBox.SelectedValue)
        Dim amount As Decimal = amountBox.Value
        Dim method As String = methodBox.SelectedItem.ToString()
        Dim noteText As String = If(String.IsNullOrWhiteSpace(notesBox.Text), $"سداد دفعة نقدية للمورد: {supName}", notesBox.Text.Trim())
        Dim paymentRef As String = "PAY-" & DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim currentUserId As Integer = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1)

        If MessageBox.Show($"هل أنت متأكد من تسجيل سداد مبلغ ({amount:N2} ج) للمورد ({supName}) وصرفه من خزينة ({treasuryBox.Text})؟", "تأكيد السداد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Await conn.OpenAsync()
            Dim trans As SqlTransaction = conn.BeginTransaction()

            Try
                ' 1. جلب الرصيد الحالي للمورد بقفل التحديث
                Dim balBefore As Decimal = 0
                Const sqlGetBal As String = "SELECT CurrentBalance FROM Suppliers WITH (UPDLOCK) WHERE SupplierID = @SupID"
                Using cmdGetBal As New SqlCommand(sqlGetBal, conn, trans)
                    cmdGetBal.Parameters.AddWithValue("@SupID", supID)
                    balBefore = Convert.ToDecimal(Await cmdGetBal.ExecuteScalarAsync())
                End Using

                Dim balAfter As Decimal = balBefore - amount

                ' 2. إدراج الحركة في SupplierTransactions
                Const sqlInsertTx As String = "INSERT INTO SupplierTransactions (SupplierID, TransactionType, ReferenceNo, Debit, Credit, BalanceBefore, BalanceAfter, TransactionDate, TreasuryID, Notes, UserID) " &
                                              "VALUES (@SupID, 'PAYMENT', @Ref, @Debit, 0.00, @BalBefore, @BalAfter, GETDATE(), @TreasuryID, @Notes, @UserID);"
                Using cmdTx As New SqlCommand(sqlInsertTx, conn, trans)
                    cmdTx.Parameters.AddWithValue("@SupID", supID)
                    cmdTx.Parameters.AddWithValue("@Ref", paymentRef)
                    cmdTx.Parameters.AddWithValue("@Debit", amount)
                    cmdTx.Parameters.AddWithValue("@BalBefore", balBefore)
                    cmdTx.Parameters.AddWithValue("@BalAfter", balAfter)
                    cmdTx.Parameters.AddWithValue("@TreasuryID", treasuryID)
                    cmdTx.Parameters.AddWithValue("@Notes", noteText)
                    cmdTx.Parameters.AddWithValue("@UserID", currentUserId)
                    Await cmdTx.ExecuteNonQueryAsync()
                End Using

                ' 3. تحديث رصيد المورد
                Const sqlUpdateBal As String = "UPDATE Suppliers SET CurrentBalance = @NewBal WHERE SupplierID = @SupID"
                Using cmdUp As New SqlCommand(sqlUpdateBal, conn, trans)
                    cmdUp.Parameters.AddWithValue("@NewBal", balAfter)
                    cmdUp.Parameters.AddWithValue("@SupID", supID)
                    Await cmdUp.ExecuteNonQueryAsync()
                End Using

                ' 4. خصم المبلغ من الخزينة عبر TreasuryService
                Await TreasuryService.AddTransactionAsync(
                    treasuryID:=treasuryID,
                    transactionType:=TreasuryTransactionTypes.SupplierPayment,
                    amount:=amount,
                    isDeposit:=False,
                    referenceID:=Nothing,
                    referenceNo:=paymentRef,
                    notes:=noteText,
                    userID:=currentUserId,
                    cn:=conn,
                    trans:=trans
                )

                trans.Commit()

                MessageBox.Show("تم تسجيل عملية السداد بنجاح وخصم المبلغ من الخزينة وتحديث رصيد المورد!", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information)

                amountBox.Value = 0
                notesBox.Clear()
                LoadStatement()

            Catch ex As Exception
                trans.Rollback()
                MessageBox.Show("حدث خطأ أثناء حفظ حركة السداد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' تصدير كشف الحساب الحالي إلى ملف Excel احترافي
    ''' </summary>
    Private Sub btnExportStatement_Click(sender As Object, e As EventArgs) Handles btnExportStatement.Click
        If grid.Rows.Count = 0 Then
            MessageBox.Show("لا توجد بيانات لتصديرها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx"
            sfd.FileName = $"كشف_حساب_مورد_{supplierBox.Text.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                Using wb As New XLWorkbook()
                    Dim ws = wb.Worksheets.Add("كشف الحساب")
                    ws.RightToLeft = True

                    ' الترويسة
                    ws.Cell("A1").Value = "كشف حساب المورد: " & supplierBox.Text
                    ws.Cell("A1").Style.Font.Bold = True
                    ws.Cell("A1").Style.Font.FontSize = 16
                    ws.Range("A1:H1").Merge()

                    ws.Cell("A2").Value = $"الفترة من: {fromPicker.Value:yyyy-MM-dd} إلى: {toPicker.Value:yyyy-MM-dd}"
                    ws.Cell("A2").Style.Font.FontSize = 12
                    ws.Range("A2:H2").Merge()

                    ' عناوين الأعمدة
                    Dim colIndex As Integer = 1
                    For Each col As DataGridViewColumn In grid.Columns
                        If col.Visible Then
                            ws.Cell(4, colIndex).Value = col.HeaderText
                            ws.Cell(4, colIndex).Style.Font.Bold = True
                            ws.Cell(4, colIndex).Style.Fill.BackgroundColor = XLColor.FromHtml("#2B84B9")
                            ws.Cell(4, colIndex).Style.Font.FontColor = XLColor.White
                            colIndex += 1
                        End If
                    Next

                    ' صفوف البيانات
                    Dim rowIndex As Integer = 5
                    For Each row As DataGridViewRow In grid.Rows
                        colIndex = 1
                        For Each col As DataGridViewColumn In grid.Columns
                            If col.Visible Then
                                ws.Cell(rowIndex, colIndex).Value = If(row.Cells(col.Index).Value, "").ToString()
                                colIndex += 1
                            End If
                        Next
                        rowIndex += 1
                    Next

                    ws.Columns().AdjustToContents()
                    wb.SaveAs(sfd.FileName)

                    MessageBox.Show("تم تصدير كشف الحساب إلى Excel بنجاح!", "نجاح التصدير", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء تصدير ملف Excel: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' طباعة كشف الحساب
    ''' </summary>
    Private Sub btnPrintStatement_Click(sender As Object, e As EventArgs) Handles btnPrintStatement.Click
        If grid.Rows.Count = 0 Then
            MessageBox.Show("لا توجد بيانات للطباعة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim printDoc As New Printing.PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintStatementPage
            Dim preview As New PrintPreviewDialog()
            preview.Document = printDoc
            preview.WindowState = FormWindowState.Maximized
            preview.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء تهيئة الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintStatementPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim g = e.Graphics
        Dim fontHeader As New Font("Segoe UI", 16, FontStyle.Bold)
        Dim fontSub As New Font("Segoe UI", 11, FontStyle.Bold)
        Dim fontRegular As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim fontBold As New Font("Segoe UI", 9, FontStyle.Bold)

        Dim y As Integer = 40
        Dim formatCenter As New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim formatRight As New StringFormat() With {.Alignment = StringAlignment.Far}

        ' العنوان الرئيسي
        g.DrawString("كشف حساب مورد", fontHeader, Brushes.Black, e.PageBounds.Width / 2, y, formatCenter)
        y += 35
        g.DrawString($"المورد: {supplierBox.Text}  |  الفترة: {fromPicker.Value:yyyy-MM-dd} إلى {toPicker.Value:yyyy-MM-dd}", fontSub, Brushes.Black, e.PageBounds.Width / 2, y, formatCenter)
        y += 25
        g.DrawString(balanceLabel.Text, fontSub, Brushes.DarkBlue, e.PageBounds.Width / 2, y, formatCenter)
        y += 35

        ' خط فاصل
        g.DrawLine(Pens.Gray, 40, y, e.PageBounds.Width - 40, y)
        y += 10

        ' رؤوس الأعمدة
        Dim colWidths() As Integer = {70, 110, 90, 90, 80, 80, 90, 140}
        Dim colHeaders() As String = {"رقم", "التاريخ", "النوع", "المرجع", "دائن", "مدين", "الرصيد", "البيان"}
        Dim x As Integer = e.PageBounds.Width - 50

        For i As Integer = 0 To colHeaders.Length - 1
            x -= colWidths(i)
            g.FillRectangle(Brushes.LightGray, x, y, colWidths(i), 25)
            g.DrawRectangle(Pens.Gray, x, y, colWidths(i), 25)
            g.DrawString(colHeaders(i), fontBold, Brushes.Black, x + colWidths(i) / 2, y + 4, formatCenter)
        Next
        y += 25

        ' طباعة الصفوف
        For Each row As DataGridViewRow In grid.Rows
            If y > e.PageBounds.Height - 60 Then
                e.HasMorePages = True
                Return
            End If

            x = e.PageBounds.Width - 50
            Dim values() As String = {
                If(row.Cells("TransactionID").Value, "").ToString(),
                If(row.Cells("TransactionDate").Value, "").ToString(),
                If(row.Cells("TransactionTypeDisplay").Value, "").ToString(),
                If(row.Cells("ReferenceNo").Value, "").ToString(),
                Convert.ToDecimal(If(row.Cells("Credit").Value, 0)).ToString("N2"),
                Convert.ToDecimal(If(row.Cells("Debit").Value, 0)).ToString("N2"),
                Convert.ToDecimal(If(row.Cells("BalanceRunning").Value, 0)).ToString("N2"),
                If(row.Cells("Notes").Value, "").ToString()
            }

            For i As Integer = 0 To values.Length - 1
                x -= colWidths(i)
                g.DrawRectangle(Pens.LightGray, x, y, colWidths(i), 22)
                g.DrawString(values(i), fontRegular, Brushes.Black, x + 4, y + 3)
            Next
            y += 22
        Next

        e.HasMorePages = False
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
