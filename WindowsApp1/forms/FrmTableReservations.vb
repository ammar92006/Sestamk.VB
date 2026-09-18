Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Global.WindowsApp1
    Public Class FrmTableReservations
        Inherits Form

        Private ReadOnly _repo As POSRepository
        Private _tablesList As List(Of RestaurantTableModel)
        Private _treasuriesList As DataTable

        ' عناصر الواجهة
        Private panelHeader As Panel
        Private lblTitle As Label
        Private btnCloseForm As Button

        ' نموذج الإدخال (تسجيل حجز جديد)
        Private pnlNewReservation As Panel
        Private cmbTables As ComboBox
        Private txtCustomerName As TextBox
        Private txtCustomerPhone As TextBox
        Private numGuests As NumericUpDown
        Private dtpReservationDate As DateTimePicker
        Private dtpReservationTime As DateTimePicker
        Private txtDeposit As TextBox
        Private cmbTreasury As ComboBox
        Private txtNotes As TextBox
        Private btnSaveReservation As Button
        Private btnClearFields As Button

        ' قسم عرض الحجوزات والفلترة
        Private pnlHistoryContainer As Panel
        Private dtpFilterDate As DateTimePicker
        Private cmbFilterStatus As ComboBox
        Private btnRefreshGrid As Button
        Private dgvReservations As DataGridView
        Private lblTodayCount As Label
        Private lblTotalDeposits As Label
        Private btnCheckInSelected As Button
        Private btnCancelSelected As Button

        Public Sub New()
            _repo = New POSRepository(DBModule.ConnectionString)
            InitializeComponentsCustom()
        End Sub

        Private Sub InitializeComponentsCustom()
            Me.Text = "إدارة حجوزات طاولات الصالة (Table Reservations)"
            Me.ClientSize = New Size(1180, 720)
            Me.MinimumSize = New Size(980, 600)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.FormBorderStyle = FormBorderStyle.None
            Me.RightToLeft = RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.BackColor = Color.FromArgb(245, 247, 250)
            Me.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)

            ' 1. الهيدر
            panelHeader = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 55,
                .BackColor = Color.FromArgb(33, 42, 57),
                .Padding = New Padding(15, 0, 15, 0)
            }

            lblTitle = New Label With {
                .Text = "📅 إدارة حجوزات طاولات الصالة والعربون (Table Reservations)",
                .Font = New Font("Segoe UI", 13.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .AutoSize = True,
                .Location = New Point(15, 14)
            }
            panelHeader.Controls.Add(lblTitle)

            btnCloseForm = New Button With {
                .Text = "✕",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(220, 53, 69),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(40, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(15, 10),
                .Cursor = Cursors.Hand
            }
            btnCloseForm.FlatAppearance.BorderSize = 0
            AddHandler btnCloseForm.Click, Sub() Me.Close()
            panelHeader.Controls.Add(btnCloseForm)
            Me.Controls.Add(panelHeader)

            ' 2. التقسيم الرئيسي: نموذج الإدخال (يمين) + جدول الحجوزات (يسار/وسط)
            pnlNewReservation = New Panel With {
                .Dock = DockStyle.Right,
                .Width = 370,
                .BackColor = Color.White,
                .BorderStyle = BorderStyle.FixedSingle,
                .Padding = New Padding(15)
            }
            Me.Controls.Add(pnlNewReservation)

            pnlHistoryContainer = New Panel With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.FromArgb(248, 250, 252),
                .Padding = New Padding(15)
            }
            Me.Controls.Add(pnlHistoryContainer)
            pnlHistoryContainer.BringToFront()

            SetupNewReservationPanel()
            SetupHistoryPanel()

            Dim drag As New FormDragHelper(Me, panelHeader)
        End Sub

        ' =========================================================
        ' إعداد نموذج تسجيل حجز جديد
        ' =========================================================
        Private Sub SetupNewReservationPanel()
            Dim lblSectionTitle As New Label With {
                .Text = "📝 تسجيل حجز طاولة جديد",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(30, 41, 59),
                .Dock = DockStyle.Top,
                .Height = 35
            }
            pnlNewReservation.Controls.Add(lblSectionTitle)

            Dim y As Integer = 45
            Dim AddField = Sub(labelText As String, ctrl As Control, height As Integer)
                               Dim lbl As New Label With {
                                   .Text = labelText,
                                   .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                                   .ForeColor = Color.FromArgb(71, 85, 105),
                                   .Location = New Point(15, y),
                                   .AutoSize = True
                               }
                               pnlNewReservation.Controls.Add(lbl)
                               ctrl.Location = New Point(15, y + 22)
                               ctrl.Width = 335
                               pnlNewReservation.Controls.Add(ctrl)
                               y += height + 28
                           End Sub

            cmbTables = New ComboBox With {.DropDownStyle = ComboBoxStyle.DropDownList}
            AddField("الطاولة المستهدفة *:", cmbTables, 28)

            txtCustomerName = New TextBox()
            AddField("اسم العميل *:", txtCustomerName, 26)

            txtCustomerPhone = New TextBox()
            AddField("رقم هاتف العميل *:", txtCustomerPhone, 26)

            numGuests = New NumericUpDown With {.Minimum = 1, .Maximum = 50, .Value = 2}
            AddField("عدد الأفراد / الضيوف:", numGuests, 26)

            Dim pnlDateTime As New Panel With {.Width = 335, .Height = 28}
            dtpReservationDate = New DateTimePicker With {.Format = DateTimePickerFormat.Short, .Width = 160, .Location = New Point(175, 0)}
            dtpReservationTime = New DateTimePicker With {.Format = DateTimePickerFormat.Time, .ShowUpDown = True, .Width = 160, .Location = New Point(0, 0)}
            pnlDateTime.Controls.Add(dtpReservationDate)
            pnlDateTime.Controls.Add(dtpReservationTime)
            AddField("موعد وتوقيت الحضور المستهدف *:", pnlDateTime, 28)

            txtDeposit = New TextBox With {.Text = "0.00"}
            AddField("مبلغ العربون المدفوع (إن وجد):", txtDeposit, 26)

            cmbTreasury = New ComboBox With {.DropDownStyle = ComboBoxStyle.DropDownList}
            AddField("الخزينة المستلمة للعربون:", cmbTreasury, 28)

            txtNotes = New TextBox With {.Multiline = True, .Height = 50}
            AddField("ملاحظات خاصة (مناسبة / تزيين):", txtNotes, 50)

            btnSaveReservation = New Button With {
                .Text = "💾 تأكيد الحجز وإيداع العربون",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(16, 149, 105),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(335, 42),
                .Location = New Point(15, y + 5),
                .Cursor = Cursors.Hand
            }
            btnSaveReservation.FlatAppearance.BorderSize = 0
            AddHandler btnSaveReservation.Click, Async Sub() Await SaveReservationAsync()
            pnlNewReservation.Controls.Add(btnSaveReservation)
        End Sub

        ' =========================================================
        ' إعداد لوحة عرض الحجوزات والفلترة
        ' =========================================================
        Private Sub SetupHistoryPanel()
            ' شريط علوي للفلترة والإحصائيات
            Dim pnlTopBar As New Panel With {
                .Dock = DockStyle.Top,
                .Height = 90,
                .BackColor = Color.White,
                .BorderStyle = BorderStyle.FixedSingle,
                .Padding = New Padding(12)
            }

            ' إحصائيات سريعة
            lblTodayCount = New Label With {
                .Text = "حجوزات التاريخ المحدد: 0",
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(37, 99, 235),
                .AutoSize = True,
                .Location = New Point(20, 12)
            }
            pnlTopBar.Controls.Add(lblTodayCount)

            lblTotalDeposits = New Label With {
                .Text = "إجمالي العربونات المحصلة: 0.00 ج",
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(16, 149, 105),
                .AutoSize = True,
                .Location = New Point(260, 12)
            }
            pnlTopBar.Controls.Add(lblTotalDeposits)

            ' الفلاتر
            Dim lblFilterDateTitle As New Label With {.Text = "عرض حجوزات تاريخ:", .AutoSize = True, .Location = New Point(20, 52), .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}
            pnlTopBar.Controls.Add(lblFilterDateTitle)
            dtpFilterDate = New DateTimePicker With {.Location = New Point(150, 48), .Width = 140, .Format = DateTimePickerFormat.Short, .Value = DateTime.Now.Date}
            pnlTopBar.Controls.Add(dtpFilterDate)

            Dim lblStatusTitle As New Label With {.Text = "الحالة:", .AutoSize = True, .Location = New Point(310, 52), .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}
            pnlTopBar.Controls.Add(lblStatusTitle)
            cmbFilterStatus = New ComboBox With {.Location = New Point(360, 48), .Width = 140, .DropDownStyle = ComboBoxStyle.DropDownList}
            cmbFilterStatus.Items.AddRange(New Object() {"الكل", "مؤكد 🟡", "تم التسكين 🔴", "ملغي ⚪", "لم يحضر ❌"})
            cmbFilterStatus.SelectedIndex = 0
            pnlTopBar.Controls.Add(cmbFilterStatus)

            btnRefreshGrid = New Button With {
                .Text = "🔄 تحديث",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(50, 55, 65),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(95, 30),
                .Location = New Point(520, 47),
                .Cursor = Cursors.Hand
            }
            btnRefreshGrid.FlatAppearance.BorderSize = 0
            AddHandler btnRefreshGrid.Click, Sub() LoadReservationsList()
            pnlTopBar.Controls.Add(btnRefreshGrid)

            pnlHistoryContainer.Controls.Add(pnlTopBar)

            ' شريط أزرار الإجراءات السريعة بالأسفل
            Dim pnlBottomActions As New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 55,
                .BackColor = Color.FromArgb(241, 245, 249),
                .Padding = New Padding(12)
            }

            btnCheckInSelected = New Button With {
                .Text = "🛎️ تسكين الحجز المحدد الآن",
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(37, 99, 235),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(210, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(15, 9),
                .Cursor = Cursors.Hand
            }
            btnCheckInSelected.FlatAppearance.BorderSize = 0
            AddHandler btnCheckInSelected.Click, AddressOf CheckInSelectedReservation
            pnlBottomActions.Controls.Add(btnCheckInSelected)

            btnCancelSelected = New Button With {
                .Text = "❌ إلغاء الحجز وإتاحة الطاولة",
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(220, 38, 38),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(210, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(235, 9),
                .Cursor = Cursors.Hand
            }
            btnCancelSelected.FlatAppearance.BorderSize = 0
            AddHandler btnCancelSelected.Click, AddressOf CancelSelectedReservation
            pnlBottomActions.Controls.Add(btnCancelSelected)

            pnlHistoryContainer.Controls.Add(pnlBottomActions)

            ' جدول الحجوزات
            dgvReservations = New DataGridView With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = Color.White,
                .AllowUserToAddRows = False,
                .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .RowTemplate = New DataGridViewRow With {.Height = 35}
            }
            pnlHistoryContainer.Controls.Add(dgvReservations)
            dgvReservations.BringToFront()

            SetupReservationsGridColumns()
        End Sub

        Private Sub SetupReservationsGridColumns()
            dgvReservations.Columns.Clear()
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colResID", .Visible = False})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTableID", .Visible = False})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colResNum", .HeaderText = "رقم الحجز", .Width = 140})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTable", .HeaderText = "الطاولة", .Width = 110, .DefaultCellStyle = New DataGridViewCellStyle With {.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)}})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colCustomer", .HeaderText = "العميل", .Width = 150})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colPhone", .HeaderText = "الهاتف", .Width = 120})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colGuests", .HeaderText = "الأفراد", .Width = 70})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colDateTime", .HeaderText = "موعد الحضور", .Width = 130})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colDeposit", .HeaderText = "العربون", .Width = 90, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2", .ForeColor = Color.ForestGreen, .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colStatus", .HeaderText = "الحالة", .Width = 110, .DefaultCellStyle = New DataGridViewCellStyle With {.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}})
            dgvReservations.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNotes", .HeaderText = "ملاحظات", .Width = 180})
            ThemeHelper.ApplyDataGridViewTheme(dgvReservations, ThemeManager.Instance.CurrentPalette)
        End Sub

        Private Sub FrmTableReservations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ThemeManager.Instance.ApplyTheme(Me)
            LoadDropdowns()
            LoadReservationsList()
        End Sub

        Private Sub LoadDropdowns()
            Try
                ' 1. الطاولات
                _tablesList = _repo.GetRestaurantTables(Nothing)
                Dim dtTbl As New DataTable()
                dtTbl.Columns.Add("TableID", GetType(Integer))
                dtTbl.Columns.Add("DisplayText", GetType(String))

                For Each t In _tablesList
                    dtTbl.Rows.Add(t.TableID, $"{t.TableName} (سعة {t.ChairsCount} أفراد)")
                Next
                cmbTables.DataSource = dtTbl
                cmbTables.DisplayMember = "DisplayText"
                cmbTables.ValueMember = "TableID"

                ' 2. الخزائن
                _treasuriesList = DBModule.ExecuteQuery("SELECT TreasuryID, TreasuryNameAr FROM Treasury WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND IsActive = 1;")
                If _treasuriesList IsNot Nothing AndAlso _treasuriesList.Rows.Count > 0 Then
                    cmbTreasury.DataSource = _treasuriesList
                    cmbTreasury.DisplayMember = "TreasuryNameAr"
                    cmbTreasury.ValueMember = "TreasuryID"
                    cmbTreasury.SelectedIndex = 0
                End If
            Catch ex As Exception
                Logger.LogError("LoadDropdowns in FrmTableReservations", ex)
            End Try
        End Sub

        Private Sub LoadReservationsList()
            Try
                Dim statusParam As Byte = CByte(cmbFilterStatus.SelectedIndex)
                Dim list = _repo.GetTableReservations(dtpFilterDate.Value, dtpFilterDate.Value, statusParam)

                dgvReservations.Rows.Clear()
                Dim totalDep As Decimal = 0

                For Each res In list
                    totalDep += res.DepositAmount
                    dgvReservations.Rows.Add(
                        res.ReservationID,
                        res.TableID,
                        res.ReservationNumber,
                        res.TableName,
                        res.CustomerName,
                        res.CustomerPhone,
                        res.GuestCount,
                        res.ReservationDateTime.ToString("yyyy/MM/dd HH:mm"),
                        res.DepositAmount,
                        res.StatusName,
                        res.Notes
                    )
                Next

                lblTodayCount.Text = $"حجوزات التاريخ المحدد: {list.Count}"
                lblTotalDeposits.Text = $"إجمالي العربونات المحصلة: {totalDep:N2} ج"
            Catch ex As Exception
                Logger.LogError("LoadReservationsList", ex)
            End Try
        End Sub

        Private Async Function SaveReservationAsync() As Task
            If cmbTables.SelectedValue Is Nothing Then
                MessageBox.Show("يرجى اختيار طاولة للحجز!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
                MessageBox.Show("يرجى إدخال اسم العميل!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerName.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtCustomerPhone.Text) Then
                MessageBox.Show("يرجى إدخال رقم هاتف العميل!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerPhone.Focus()
                Return
            End If

            Dim depositVal As Decimal = 0
            Decimal.TryParse(txtDeposit.Text, depositVal)

            Dim targetDateTime As DateTime = dtpReservationDate.Value.Date.Add(dtpReservationTime.Value.TimeOfDay)
            Dim selectedTableId As Integer = Convert.ToInt32(cmbTables.SelectedValue)
            Dim selectedTableName As String = cmbTables.Text

            Dim treasuryIdVal As Integer? = If(cmbTreasury.SelectedValue IsNot Nothing, Convert.ToInt32(cmbTreasury.SelectedValue), CType(Nothing, Integer?))

            Dim resModel As New TableReservationModel With {
                .TableID = selectedTableId,
                .TableName = selectedTableName,
                .CustomerName = txtCustomerName.Text.Trim(),
                .CustomerPhone = txtCustomerPhone.Text.Trim(),
                .GuestCount = CInt(numGuests.Value),
                .ReservationDateTime = targetDateTime,
                .DepositAmount = depositVal,
                .TreasuryID = treasuryIdVal,
                .Status = ReservationStatus.Confirmed,
                .Notes = txtNotes.Text.Trim(),
                .CreatedByUserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1)
            }

            btnSaveReservation.Enabled = False
            Try
                Dim success = Await _repo.SaveTableReservationAsync(resModel)
                If success Then
                    MessageBox.Show($"تم تأكيد الحجز بنجاح برقم: {resModel.ReservationNumber}، وتم تغيير حالة الطاولة إلى محجوزة وإيداع العربون في الخزينة!", "نجاح الحجز", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearInputs()
                    LoadReservationsList()
                Else
                    MessageBox.Show("حدث خطأ أثناء حفظ الحجز!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                Logger.LogError("SaveReservationAsync", ex)
            Finally
                btnSaveReservation.Enabled = True
            End Try
        End Function

        Private Sub CheckInSelectedReservation(sender As Object, e As EventArgs)
            If dgvReservations.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد حجز من القائمة لتسكينه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row = dgvReservations.SelectedRows(0)
            Dim resId = Convert.ToInt32(row.Cells("colResID").Value)
            Dim tblId = Convert.ToInt32(row.Cells("colTableID").Value)
            Dim custName = row.Cells("colCustomer").Value.ToString()

            If MessageBox.Show($"هل ترغب في تسكين العميل: {custName} الآن على الطاولة وتحويلها إلى مشغولة؟", "تأكيد التسكين", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If _repo.CheckInReservation(resId, tblId) Then
                    MessageBox.Show("تم تسكين العميل بنجاح وأصبحت الطاولة مشغولة!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadReservationsList()
                End If
            End If
        End Sub

        Private Sub CancelSelectedReservation(sender As Object, e As EventArgs)
            If dgvReservations.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد حجز من القائمة لإلغائه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row = dgvReservations.SelectedRows(0)
            Dim resId = Convert.ToInt32(row.Cells("colResID").Value)
            Dim tblId = Convert.ToInt32(row.Cells("colTableID").Value)
            Dim custName = row.Cells("colCustomer").Value.ToString()

            If MessageBox.Show($"هل أنت متأكد من إلغاء حجز العميل: {custName} وإتاحة الطاولة مجدداً؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If _repo.CancelReservation(resId, tblId) Then
                    MessageBox.Show("تم إلغاء الحجز بنجاح وأصبحت الطاولة متاحة!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadReservationsList()
                End If
            End If
        End Sub

        Private Sub ClearInputs()
            txtCustomerName.Clear()
            txtCustomerPhone.Clear()
            txtDeposit.Text = "0.00"
            txtNotes.Clear()
            numGuests.Value = 2
        End Sub
    End Class
End Namespace
