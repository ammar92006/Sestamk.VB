Imports System
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace Global.WindowsApp1
    Partial Class FrmSplitBill

        ' البيانات الممررة
        Private ReadOnly _totalAmount As Decimal
        Private ReadOnly _tableName As String
        Private ReadOnly _invoiceNumber As String

        ' النتائج المرتجعة
        Public Property IsFullySettled As Boolean = False
        Public Property GuestCount As Integer = 2
        Public Property TotalPaid As Decimal = 0

        Public Sub New()
            InitializeComponent()
            SetupEventHandlers()
        End Sub

        Public Sub New(totalAmount As Decimal, tableName As String, invoiceNumber As String)
            Me.New()
            _totalAmount = totalAmount
            _tableName = If(String.IsNullOrWhiteSpace(tableName), "طلب عام", tableName)
            _invoiceNumber = If(String.IsNullOrWhiteSpace(invoiceNumber), "فاتورة حالية", invoiceNumber)
            lblSubTitle.Text = $"الطاولة: {_tableName}   |   رقم الفاتورة: {_invoiceNumber}   |   إجمالي الفاتورة: {_totalAmount:N2} ج.م"
            lblKpiTotal.Text = $"{_totalAmount:N2} ج"
            lblKpiRemaining.Text = $"{_totalAmount:N2} ج"
            ApplySplitCalculation()
        End Sub

        Private Sub SetupEventHandlers()
            Dim pal = ThemeManager.Instance.CurrentPalette
            Me.BackColor = pal.Background
            panelHeader.BackColor = pal.SurfaceHeader
            pnlSplitControls.BackColor = pal.Surface
            rbEqualSplit.ForeColor = pal.TextPrimary
            lblGuestsCount.ForeColor = pal.TextSecondary
            numGuests.BackColor = pal.InputBackground
            numGuests.ForeColor = pal.TextPrimary
            rbCustomSplit.ForeColor = pal.TextPrimary
            pnlKpiContainer.BackColor = pal.Background
            pnlKpiTotal.BackColor = pal.Surface
            pnlKpiPerPerson.BackColor = pal.Surface
            pnlKpiPaid.BackColor = pal.Surface
            pnlKpiRemaining.BackColor = pal.Surface
            pnlBottomBar.BackColor = pal.Surface
            btnCancelForm.ForeColor = pal.TextSecondary
            btnCancelForm.BackColor = pal.Background
            btnCancelForm.FlatAppearance.BorderColor = pal.Border

            dgvSplits.BackgroundColor = pal.Background
            dgvSplits.GridColor = pal.GridBorder
            dgvSplits.ColumnHeadersDefaultCellStyle.BackColor = pal.GridHeaderBackground
            dgvSplits.ColumnHeadersDefaultCellStyle.ForeColor = pal.GridHeaderForeground
            dgvSplits.DefaultCellStyle.BackColor = pal.GridBackground
            dgvSplits.DefaultCellStyle.ForeColor = pal.GridForeground
            dgvSplits.DefaultCellStyle.SelectionBackColor = pal.GridSelectionBackground
            dgvSplits.DefaultCellStyle.SelectionForeColor = pal.GridSelectionForeground
            dgvSplits.AlternatingRowsDefaultCellStyle.BackColor = pal.GridAlternateBackground
            dgvSplits.AlternatingRowsDefaultCellStyle.ForeColor = pal.GridForeground
            dgvSplits.AlternatingRowsDefaultCellStyle.SelectionBackColor = pal.GridSelectionBackground
            dgvSplits.AlternatingRowsDefaultCellStyle.SelectionForeColor = pal.GridSelectionForeground

            AddHandler btnCloseForm.Click, Sub()
                                               Me.DialogResult = DialogResult.Cancel
                                               Me.Close()
                                           End Sub
            AddHandler btnApplySplit.Click, Sub() ApplySplitCalculation()
            AddHandler rbEqualSplit.CheckedChanged, Sub()
                                                        numGuests.Enabled = rbEqualSplit.Checked
                                                        btnApplySplit.PerformClick()
                                                    End Sub
            AddHandler rbCustomSplit.CheckedChanged, Sub()
                                                         numGuests.Enabled = rbEqualSplit.Checked
                                                         If rbCustomSplit.Checked Then
                                                             dgvSplits.Columns("colShare").ReadOnly = False
                                                         Else
                                                             dgvSplits.Columns("colShare").ReadOnly = True
                                                         End If
                                                     End Sub
            AddHandler numGuests.ValueChanged, Sub()
                                                   If rbEqualSplit.Checked Then ApplySplitCalculation()
                                               End Sub
            AddHandler btnPayAllCash.Click, Sub() PayAllCash()
            AddHandler btnPrintAllReceipts.Click, Sub() PrintAllSplitReceipts()
            AddHandler btnConfirmSettlement.Click, Sub() ConfirmSettlement()
            AddHandler btnCancelForm.Click, Sub()
                                                Me.DialogResult = DialogResult.Cancel
                                                Me.Close()
                                            End Sub
            AddHandler dgvSplits.CellContentClick, AddressOf DgvSplits_CellContentClick
            AddHandler dgvSplits.CellValueChanged, AddressOf DgvSplits_CellValueChanged

            Dim dragHelper As New FormDragHelper(Me, panelHeader)
        End Sub

        Private Sub ApplySplitCalculation()
            Dim count As Integer = CInt(numGuests.Value)
            If count < 2 Then count = 2
            GuestCount = count

            dgvSplits.Rows.Clear()

            ' حساب نصيب الفرد بالتساوي مع جبر فوارق القروش
            Dim standardShare As Decimal = Math.Floor((_totalAmount / count) * 100) / 100
            Dim allocatedSum As Decimal = 0

            For i As Integer = 1 To count
                Dim currentShare As Decimal
                If i = count Then
                    ' الفرد الأخير يأخذ باقي المبلغ تماماً لضبط الكسور بالسنت
                    currentShare = _totalAmount - allocatedSum
                Else
                    currentShare = standardShare
                    allocatedSum += currentShare
                End If

                Dim rowIndex = dgvSplits.Rows.Add(
                    i,
                    $"الضيف {i}",
                    currentShare,
                    "نقدي (كاش)",
                    0.00D,
                    currentShare,
                    "معلق ⏳"
                )

                dgvSplits.Rows(rowIndex).Cells("colStatus").Style.ForeColor = Color.FromArgb(234, 88, 12)
            Next

            lblKpiPerPerson.Text = $"{standardShare:N2} ج"
            RecalculateTotals()
        End Sub

        Private Sub RecalculateTotals()
            Dim totalPaidCalc As Decimal = 0
            Dim totalRemainingCalc As Decimal = 0

            For Each row As DataGridViewRow In dgvSplits.Rows
                Dim paidVal As Decimal = 0
                Dim remVal As Decimal = 0
                Decimal.TryParse(If(row.Cells("colPaid").Value, "0").ToString(), paidVal)
                Decimal.TryParse(If(row.Cells("colRemaining").Value, "0").ToString(), remVal)

                totalPaidCalc += paidVal
                totalRemainingCalc += remVal
            Next

            TotalPaid = totalPaidCalc
            lblKpiPaid.Text = $"{totalPaidCalc:N2} ج"
            lblKpiRemaining.Text = $"{totalRemainingCalc:N2} ج"

            If totalRemainingCalc <= 0.001D AndAlso totalPaidCalc >= _totalAmount - 0.05D Then
                lblKpiRemaining.ForeColor = Color.FromArgb(16, 185, 129)
                btnConfirmSettlement.Enabled = True
                btnConfirmSettlement.BackColor = Color.FromArgb(16, 185, 129)
            Else
                lblKpiRemaining.ForeColor = Color.FromArgb(239, 68, 68)
                btnConfirmSettlement.Enabled = False
                btnConfirmSettlement.BackColor = Color.FromArgb(148, 163, 184)
            End If
        End Sub

        Private Sub DgvSplits_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 Then Return

            Dim row = dgvSplits.Rows(e.RowIndex)
            Dim colName = dgvSplits.Columns(e.ColumnIndex).Name

            ' زر سداد الحصة
            If colName = "colBtnPay" Then
                Dim shareVal As Decimal = Convert.ToDecimal(row.Cells("colShare").Value)
                Dim paidVal As Decimal = Convert.ToDecimal(row.Cells("colPaid").Value)

                If paidVal >= shareVal Then
                    ' إذا كانت مسددة بالفعل، يتم إلغاء السداد للتعديل
                    Dim res = SmartMessageBox.Show($"الحصة مسددة بالفعل! هل ترغب في إلغاء سداد حصة ({row.Cells("colGuestName").Value})؟", "إلغاء السداد", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If res = DialogResult.Yes Then
                        row.Cells("colPaid").Value = 0.00D
                        row.Cells("colRemaining").Value = shareVal
                        row.Cells("colStatus").Value = "معلق ⏳"
                        row.Cells("colStatus").Style.ForeColor = Color.FromArgb(234, 88, 12)
                    End If
                Else
                    ' سداد كامل الحصة
                    row.Cells("colPaid").Value = shareVal
                    row.Cells("colRemaining").Value = 0.00D
                    row.Cells("colStatus").Value = "تم السداد 🟢"
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(16, 185, 129)
                End If
                RecalculateTotals()

                ' زر طباعة إيصال فردي
            ElseIf colName = "colBtnPrint" Then
                PrintSingleGuestReceipt(e.RowIndex)
            End If
        End Sub

        Private Sub DgvSplits_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 OrElse dgvSplits Is Nothing Then Return

            ' في حالة التقسيم اليدوي وتم تعديل المبلغ المطلوب
            If dgvSplits.Columns(e.ColumnIndex).Name = "colShare" Then
                Dim row = dgvSplits.Rows(e.RowIndex)
                Dim shareVal As Decimal = 0
                Decimal.TryParse(If(row.Cells("colShare").Value, "0").ToString(), shareVal)
                Dim paidVal As Decimal = 0
                Decimal.TryParse(If(row.Cells("colPaid").Value, "0").ToString(), paidVal)

                Dim remVal = Math.Max(0, shareVal - paidVal)
                row.Cells("colRemaining").Value = remVal
                If remVal = 0 AndAlso shareVal > 0 Then
                    row.Cells("colStatus").Value = "تم السداد 🟢"
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(16, 185, 129)
                Else
                    row.Cells("colStatus").Value = "معلق ⏳"
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(234, 88, 12)
                End If
                RecalculateTotals()
            End If
        End Sub

        Private Sub PayAllCash()
            For Each row As DataGridViewRow In dgvSplits.Rows
                Dim shareVal As Decimal = Convert.ToDecimal(row.Cells("colShare").Value)
                row.Cells("colMethod").Value = "نقدي (كاش)"
                row.Cells("colPaid").Value = shareVal
                row.Cells("colRemaining").Value = 0.00D
                row.Cells("colStatus").Value = "تم السداد 🟢"
                row.Cells("colStatus").Style.ForeColor = Color.FromArgb(16, 185, 129)
            Next
            RecalculateTotals()
            SmartMessageBox.Show("تم سداد جميع الحصص نقداً بنجاح! يمكنك الآن اعتماد الفاتورة.", "سداد كامل", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub PrintSingleGuestReceipt(rowIndex As Integer)
            Try
                Dim row = dgvSplits.Rows(rowIndex)
                Dim gNum As Integer = Convert.ToInt32(row.Cells("colIndex").Value)
                Dim gName As String = row.Cells("colGuestName").Value.ToString()
                Dim shareVal As Decimal = Convert.ToDecimal(row.Cells("colShare").Value)
                Dim paidVal As Decimal = Convert.ToDecimal(row.Cells("colPaid").Value)
                Dim methodStr As String = If(row.Cells("colMethod").Value IsNot Nothing, row.Cells("colMethod").Value.ToString(), "نقدي")

                If paidVal <= 0 Then
                    Dim ans = SmartMessageBox.Show($"حصة ({gName}) لم يتم سدادها بعد! هل تريد طباعة إيصال مطالبة غير مسدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If ans = DialogResult.No Then Return
                End If

                RestaurantPrintManager.PrintSplitReceipt(
                    _invoiceNumber,
                    gNum,
                    dgvSplits.Rows.Count,
                    gName,
                    shareVal,
                    paidVal,
                    methodStr,
                    _tableName,
                    _totalAmount
                )
            Catch ex As Exception
                Logger.LogError("PrintSingleGuestReceipt", ex)
            End Try
        End Sub

        Private Sub PrintAllSplitReceipts()
            For i As Integer = 0 To dgvSplits.Rows.Count - 1
                PrintSingleGuestReceipt(i)
            Next
        End Sub

        Private Sub ConfirmSettlement()
            Dim totalRem As Decimal = 0
            Decimal.TryParse(lblKpiRemaining.Text.Replace("ج", "").Trim(), totalRem)

            If totalRem > 0.05D Then
                SmartMessageBox.Show($"لا يمكن اعتماد إنهاء الفاتورة لوجود متبقي غير مسدد بقيمة: {totalRem:N2} ج.م!", "تنبيه السداد", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            IsFullySettled = True
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub
    End Class
End Namespace
