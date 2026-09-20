Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Global.WindowsApp1
    Partial Class FrmTableReservations

        Private ReadOnly _repo As POSRepository
        Private _tablesList As List(Of RestaurantTableModel)
        Private _treasuriesList As DataTable

        Public Sub New()
            _repo = New POSRepository(DBModule.ConnectionString)
            InitializeComponent()
            SetupEventHandlers()
        End Sub

        Private Sub SetupEventHandlers()
            AddHandler btnCloseForm.Click, Sub() Me.Close()
            AddHandler btnSaveReservation.Click, Async Sub() Await SaveReservationAsync()
            AddHandler btnRefreshGrid.Click, Sub() LoadReservationsList()
            AddHandler btnCheckInSelected.Click, AddressOf CheckInSelectedReservation
            AddHandler btnCancelSelected.Click, AddressOf CancelSelectedReservation

            ThemeHelper.ApplyDataGridViewTheme(dgvReservations, ThemeManager.Instance.CurrentPalette)
            Dim drag As New FormDragHelper(Me, panelHeader)
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
