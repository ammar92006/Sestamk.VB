Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace Global.WindowsApp1
    Public Class FrmSplitBill
        Inherits Form

        ' البيانات الممررة
        Private ReadOnly _totalAmount As Decimal
        Private ReadOnly _tableName As String
        Private ReadOnly _invoiceNumber As String

        ' النتائج المرتجعة
        Public Property IsFullySettled As Boolean = False
        Public Property GuestCount As Integer = 2
        Public Property TotalPaid As Decimal = 0

        ' عناصر الواجهة
        Private panelHeader As Panel
        Private lblTitle As Label
        Private lblSubTitle As Label
        Private btnCloseForm As Button

        ' عناصر التحكم في التقسيم
        Private pnlSplitControls As Panel
        Private rbEqualSplit As RadioButton
        Private rbCustomSplit As RadioButton
        Private numGuests As NumericUpDown
        Private lblGuestsCount As Label
        Private btnApplySplit As Button

        ' بطاقات المؤشرات (KPIs)
        Private pnlKpiContainer As Panel
        Private lblKpiTotal As Label
        Private lblKpiPerPerson As Label
        Private lblKpiPaid As Label
        Private lblKpiRemaining As Label

        ' جدول الحصص
        Private dgvSplits As DataGridView

        ' أزرار الإجراءات السفلية
        Private pnlBottomBar As Panel
        Private btnPayAllCash As Button
        Private btnPrintAllReceipts As Button
        Private btnConfirmSettlement As Button
        Private btnCancelForm As Button

        Public Sub New(totalAmount As Decimal, tableName As String, invoiceNumber As String)
            _totalAmount = totalAmount
            _tableName = If(String.IsNullOrWhiteSpace(tableName), "طلب عام", tableName)
            _invoiceNumber = If(String.IsNullOrWhiteSpace(invoiceNumber), "فاتورة حالية", invoiceNumber)

            InitializeComponentsCustom()
        End Sub

        Private Sub InitializeComponentsCustom()
            Dim pal = ThemeManager.Instance.CurrentPalette

            Me.Text = "تقسيم الفاتورة (Split Bill)"
            Me.ClientSize = New Size(1000, 680)
            Me.MinimumSize = New Size(900, 580)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.FormBorderStyle = FormBorderStyle.None
            Me.RightToLeft = RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.BackColor = pal.Background
            Me.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)

            ' 1. الهيدر
            panelHeader = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 60,
                .BackColor = pal.SurfaceHeader,
                .Padding = New Padding(15, 0, 15, 0)
            }

            lblTitle = New Label With {
                .Text = "👥 تقسيم الفاتورة وسداد الحصص (Split Bill)",
                .Font = New Font("Segoe UI", 13.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .AutoSize = True,
                .Location = New Point(15, 8)
            }
            panelHeader.Controls.Add(lblTitle)

            lblSubTitle = New Label With {
                .Text = $"الطاولة: {_tableName}   |   رقم الفاتورة: {_invoiceNumber}   |   إجمالي الفاتورة: {_totalAmount:N2} ج.م",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(203, 213, 225),
                .AutoSize = True,
                .Location = New Point(15, 33)
            }
            panelHeader.Controls.Add(lblSubTitle)

            btnCloseForm = New Button With {
                .Text = "✕",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(220, 53, 69),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(40, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(15, 12),
                .Cursor = Cursors.Hand
            }
            btnCloseForm.FlatAppearance.BorderSize = 0
            AddHandler btnCloseForm.Click, Sub()
                                              Me.DialogResult = DialogResult.Cancel
                                              Me.Close()
                                          End Sub
            panelHeader.Controls.Add(btnCloseForm)
            Me.Controls.Add(panelHeader)

            ' 2. لوحة خيارات التقسيم
            pnlSplitControls = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 65,
                .BackColor = pal.Surface,
                .Padding = New Padding(15, 12, 15, 10)
            }

            rbEqualSplit = New RadioButton With {
                .Text = "تقسيم بالتساوي على الأفراد",
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = pal.TextPrimary,
                .Checked = True,
                .AutoSize = True,
                .Location = New Point(20, 18),
                .Cursor = Cursors.Hand
            }
            pnlSplitControls.Controls.Add(rbEqualSplit)

            lblGuestsCount = New Label With {
                .Text = "عدد الأفراد:",
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = pal.TextSecondary,
                .AutoSize = True,
                .Location = New Point(235, 20)
            }
            pnlSplitControls.Controls.Add(lblGuestsCount)

            numGuests = New NumericUpDown With {
                .Minimum = 2,
                .Maximum = 30,
                .Value = 2,
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .Size = New Size(70, 32),
                .Location = New Point(320, 16),
                .TextAlign = HorizontalAlignment.Center,
                .BackColor = pal.InputBackground,
                .ForeColor = pal.TextPrimary
            }
            pnlSplitControls.Controls.Add(numGuests)

            rbCustomSplit = New RadioButton With {
                .Text = "تقسيم يدوي / مبالغ مخصصة",
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = pal.TextPrimary,
                .Checked = False,
                .AutoSize = True,
                .Location = New Point(420, 18),
                .Cursor = Cursors.Hand
            }
            pnlSplitControls.Controls.Add(rbCustomSplit)

            btnApplySplit = New Button With {
                .Text = "⚡ توزيع الحصص",
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(37, 99, 235),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(140, 34),
                .Location = New Point(650, 15),
                .Cursor = Cursors.Hand
            }
            btnApplySplit.FlatAppearance.BorderSize = 0
            AddHandler btnApplySplit.Click, Sub() ApplySplitCalculation()
            pnlSplitControls.Controls.Add(btnApplySplit)

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

            Me.Controls.Add(pnlSplitControls)

            ' 3. شريط مؤشرات الحسابات (KPIs)
            pnlKpiContainer = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 75,
                .BackColor = pal.Background,
                .Padding = New Padding(15, 10, 15, 10)
            }

            Dim cardWidth As Integer = 225
            lblKpiTotal = CreateKpiCard("إجمالي الفاتورة", $"{_totalAmount:N2} ج", If(ThemeManager.Instance.CurrentTheme = AppTheme.Dark, Color.White, Color.FromArgb(30, 41, 59)), New Point(15, 10), cardWidth)
            lblKpiPerPerson = CreateKpiCard("نصيب الفرد", $"{(_totalAmount / 2):N2} ج", Color.FromArgb(37, 99, 235), New Point(255, 10), cardWidth)
            lblKpiPaid = CreateKpiCard("إجمالي المسدد", "0.00 ج", Color.FromArgb(16, 185, 129), New Point(495, 10), cardWidth)
            lblKpiRemaining = CreateKpiCard("المتبقي الكلي", $"{_totalAmount:N2} ج", Color.FromArgb(239, 68, 68), New Point(735, 10), cardWidth)

            pnlKpiContainer.Controls.Add(lblKpiTotal.Parent)
            pnlKpiContainer.Controls.Add(lblKpiPerPerson.Parent)
            pnlKpiContainer.Controls.Add(lblKpiPaid.Parent)
            pnlKpiContainer.Controls.Add(lblKpiRemaining.Parent)

            Me.Controls.Add(pnlKpiContainer)

            ' 4. شريط الأزرار السفلية
            pnlBottomBar = New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 65,
                .BackColor = pal.Surface,
                .Padding = New Padding(15, 12, 15, 12)
            }

            btnPayAllCash = New Button With {
                .Text = "💵 سداد جميع الحصص نقداً",
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(14, 165, 233),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(200, 40),
                .Dock = DockStyle.Right,
                .Cursor = Cursors.Hand
            }
            btnPayAllCash.FlatAppearance.BorderSize = 0
            AddHandler btnPayAllCash.Click, Sub() PayAllCash()
            pnlBottomBar.Controls.Add(btnPayAllCash)

            Dim pnlSpacer As New Panel With {.Dock = DockStyle.Right, .Width = 10}
            pnlBottomBar.Controls.Add(pnlSpacer)

            btnPrintAllReceipts = New Button With {
                .Text = "🖨️ طباعة إيصالات للجميع",
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(99, 102, 241),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(190, 40),
                .Dock = DockStyle.Right,
                .Cursor = Cursors.Hand
            }
            btnPrintAllReceipts.FlatAppearance.BorderSize = 0
            AddHandler btnPrintAllReceipts.Click, Sub() PrintAllSplitReceipts()
            pnlBottomBar.Controls.Add(btnPrintAllReceipts)

            btnConfirmSettlement = New Button With {
                .Text = "✅ اعتماد السداد وإنهاء الفاتورة",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(16, 185, 129),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(230, 40),
                .Dock = DockStyle.Left,
                .Cursor = Cursors.Hand,
                .Enabled = False
            }
            btnConfirmSettlement.FlatAppearance.BorderSize = 0
            AddHandler btnConfirmSettlement.Click, Sub() ConfirmSettlement()
            pnlBottomBar.Controls.Add(btnConfirmSettlement)

            Dim pnlSpacerLeft As New Panel With {.Dock = DockStyle.Left, .Width = 10}
            pnlBottomBar.Controls.Add(pnlSpacerLeft)

            btnCancelForm = New Button With {
                .Text = "✕ إلغاء / تراجع",
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = pal.TextSecondary,
                .BackColor = pal.Background,
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(130, 40),
                .Dock = DockStyle.Left,
                .Cursor = Cursors.Hand
            }
            btnCancelForm.FlatAppearance.BorderColor = pal.Border
            AddHandler btnCancelForm.Click, Sub()
                                               Me.DialogResult = DialogResult.Cancel
                                               Me.Close()
                                           End Sub
            pnlBottomBar.Controls.Add(btnCancelForm)

            Me.Controls.Add(pnlBottomBar)

            ' 5. جدول الحصص (DataGridView)
            SetupSplitsGrid()

            ' تطبيق أول تقسيم افتراضي
            ApplySplitCalculation()

            ' إمكانية السحب من الهيدر
            Dim dragHelper As New FormDragHelper(Me, panelHeader)
        End Sub

        Private Function CreateKpiCard(title As String, initialVal As String, accentColor As Color, loc As Point, w As Integer) As Label
            Dim pal = ThemeManager.Instance.CurrentPalette
            Dim card As New Panel With {
                .Location = loc,
                .Size = New Size(w, 55),
                .BackColor = pal.Surface,
                .Padding = New Padding(8)
            }

            Dim lblT As New Label With {
                .Text = title,
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .ForeColor = pal.TextSecondary,
                .Dock = DockStyle.Top,
                .Height = 16
            }

            Dim lblV As New Label With {
                .Text = initialVal,
                .Font = New Font("Segoe UI", 12.5F, FontStyle.Bold),
                .ForeColor = accentColor,
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleLeft
            }

            card.Controls.Add(lblV)
            card.Controls.Add(lblT)
            Return lblV
        End Function

        Private Sub SetupSplitsGrid()
            Dim pal = ThemeManager.Instance.CurrentPalette
            dgvSplits = New DataGridView With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = pal.Background,
                .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False,
                .AllowUserToDeleteRows = False,
                .RowHeadersVisible = False,
                .SelectionMode = DataGridViewSelectionMode.CellSelect,
                .RowTemplate = New DataGridViewRow With {.Height = 42},
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular),
                .EnableHeadersVisualStyles = False,
                .GridColor = pal.GridBorder
            }

            dgvSplits.ColumnHeadersDefaultCellStyle.BackColor = pal.GridHeaderBackground
            dgvSplits.ColumnHeadersDefaultCellStyle.ForeColor = pal.GridHeaderForeground
            dgvSplits.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            dgvSplits.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSplits.ColumnHeadersHeight = 42

            dgvSplits.DefaultCellStyle.BackColor = pal.GridBackground
            dgvSplits.DefaultCellStyle.ForeColor = pal.GridForeground
            dgvSplits.DefaultCellStyle.SelectionBackColor = pal.GridSelectionBackground
            dgvSplits.DefaultCellStyle.SelectionForeColor = pal.GridSelectionForeground

            dgvSplits.AlternatingRowsDefaultCellStyle.BackColor = pal.GridAlternateBackground
            dgvSplits.AlternatingRowsDefaultCellStyle.ForeColor = pal.GridForeground
            dgvSplits.AlternatingRowsDefaultCellStyle.SelectionBackColor = pal.GridSelectionBackground
            dgvSplits.AlternatingRowsDefaultCellStyle.SelectionForeColor = pal.GridSelectionForeground

            dgvSplits.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "colIndex",
                .HeaderText = "#",
                .Width = 45,
                .ReadOnly = True,
                .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
            })

            dgvSplits.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "colGuestName",
                .HeaderText = "اسم الضيف / الفرد",
                .Width = 160,
                .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleLeft}
            })

            dgvSplits.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "colShare",
                .HeaderText = "المبلغ المطلوب (ج)",
                .Width = 130,
                .ReadOnly = True,
                .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleRight, .Format = "N2", .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)}
            })

            Dim colMethod As New DataGridViewComboBoxColumn With {
                .Name = "colMethod",
                .HeaderText = "طريقة الدفع",
                .Width = 130,
                .FlatStyle = FlatStyle.Flat
            }
            colMethod.Items.AddRange("نقدي (كاش)", "بطاقة / فيزا", "أخرى")
            dgvSplits.Columns.Add(colMethod)

            dgvSplits.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "colPaid",
                .HeaderText = "المسدد (ج)",
                .Width = 120,
                .ReadOnly = True,
                .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleRight, .Format = "N2", .ForeColor = Color.FromArgb(16, 185, 129), .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)}
            })

            dgvSplits.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "colRemaining",
                .HeaderText = "المتبقي (ج)",
                .Width = 120,
                .ReadOnly = True,
                .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleRight, .Format = "N2", .ForeColor = Color.FromArgb(239, 68, 68), .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)}
            })

            dgvSplits.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "colStatus",
                .HeaderText = "الحالة",
                .Width = 110,
                .ReadOnly = True,
                .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter, .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)}
            })

            Dim colBtnPay As New DataGridViewButtonColumn With {
                .Name = "colBtnPay",
                .HeaderText = "سداد الحصة",
                .Width = 90,
                .Text = "💵 سداد",
                .UseColumnTextForButtonValue = True,
                .FlatStyle = FlatStyle.Flat
            }
            colBtnPay.DefaultCellStyle.BackColor = Color.FromArgb(16, 185, 129)
            colBtnPay.DefaultCellStyle.ForeColor = Color.White
            colBtnPay.DefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            dgvSplits.Columns.Add(colBtnPay)

            Dim colBtnPrint As New DataGridViewButtonColumn With {
                .Name = "colBtnPrint",
                .HeaderText = "إيصال",
                .Width = 80,
                .Text = "🖨️ طباعة",
                .UseColumnTextForButtonValue = True,
                .FlatStyle = FlatStyle.Flat
            }
            colBtnPrint.DefaultCellStyle.BackColor = Color.FromArgb(99, 102, 241)
            colBtnPrint.DefaultCellStyle.ForeColor = Color.White
            colBtnPrint.DefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            dgvSplits.Columns.Add(colBtnPrint)

            AddHandler dgvSplits.CellContentClick, AddressOf DgvSplits_CellContentClick
            AddHandler dgvSplits.CellValueChanged, AddressOf DgvSplits_CellValueChanged

            Me.Controls.Add(dgvSplits)
            dgvSplits.BringToFront()
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
                    Dim res = MessageBox.Show($"الحصة مسددة بالفعل! هل ترغب في إلغاء سداد حصة ({row.Cells("colGuestName").Value})؟", "إلغاء السداد", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("تم سداد جميع الحصص نقداً بنجاح! يمكنك الآن اعتماد الفاتورة.", "سداد كامل", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    Dim ans = MessageBox.Show($"حصة ({gName}) لم يتم سدادها بعد! هل تريد طباعة إيصال مطالبة غير مسدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
                MessageBox.Show($"لا يمكن اعتماد إنهاء الفاتورة لوجود متبقي غير مسدد بقيمة: {totalRem:N2} ج.م!", "تنبيه السداد", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            IsFullySettled = True
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub
    End Class
End Namespace
