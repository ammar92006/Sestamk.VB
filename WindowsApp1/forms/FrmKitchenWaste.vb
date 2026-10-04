Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Global.WindowsApp1
    Partial Class FrmKitchenWaste

        Private ReadOnly _repo As POSRepository
        Private _currentItems As New List(Of KitchenWasteDetailModel)()
        Private _dtMaterials As DataTable

        Public Sub New()
            _repo = New POSRepository(DBModule.ConnectionString)
            InitializeComponent()
            SetupEventHandlers()
        End Sub

        Private Sub SetupEventHandlers()
            AddHandler btnCloseForm.Click, Sub() Me.Close()
            AddHandler cmbStores.SelectedIndexChanged, Sub() LoadMaterialsList()
            AddHandler cmbMaterials.SelectedIndexChanged, AddressOf OnMaterialSelected
            AddHandler txtQuantity.TextChanged, AddressOf RecalculateLineTotal
            AddHandler txtUnitCost.TextChanged, AddressOf RecalculateLineTotal
            AddHandler btnAddItem.Click, AddressOf OnAddItemClick
            AddHandler btnSaveWasteTicket.Click, Async Sub() Await SaveWasteTicketAsync()
            AddHandler btnClearCurrent.Click, Sub()
                                                  _currentItems.Clear()
                                                  RefreshCurrentGrid()
                                              End Sub
            AddHandler btnFilterHistory.Click, Sub() LoadWasteHistory()

            ThemeHelper.ApplyDataGridViewTheme(dgvCurrentItems, ThemeManager.Instance.CurrentPalette)
            AddHandler dgvCurrentItems.CellContentClick, Sub(s, e)
                                                             If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvCurrentItems.Columns("colDelete").Index Then
                                                                 _currentItems.RemoveAt(e.RowIndex)
                                                                 RefreshCurrentGrid()
                                                             End If
                                                         End Sub

            Dim drag As New FormDragHelper(Me, panelHeader)
        End Sub

        Private Sub FrmKitchenWaste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ThemeManager.Instance.ApplyTheme(Me)
            LoadStoresDropdown()
            LoadMaterialsList()
            LoadWasteHistory()
        End Sub

        Private Sub LoadStoresDropdown()
            Try
                Dim dt = DBModule.ExecuteQuery("SELECT StoreID, StoreName FROM Stores WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY StoreName ASC;")
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    cmbStores.DataSource = dt
                    cmbStores.DisplayMember = "StoreName"
                    cmbStores.ValueMember = "StoreID"
                    cmbStores.SelectedIndex = 0
                End If
            Catch ex As Exception
                Logger.LogError("LoadStoresDropdown in FrmKitchenWaste", ex)
            End Try
        End Sub

        Private Sub LoadMaterialsList()
            Try
                Dim storeId As Integer = If(cmbStores.SelectedValue IsNot Nothing, Convert.ToInt32(cmbStores.SelectedValue), 1)
                _dtMaterials = _repo.GetRawMaterialsWithStock(storeId)

                cmbMaterials.DataSource = _dtMaterials
                cmbMaterials.DisplayMember = "MaterialName"
                cmbMaterials.ValueMember = "MaterialID"
                If _dtMaterials.Rows.Count > 0 Then
                    cmbMaterials.SelectedIndex = 0
                    OnMaterialSelected(Nothing, Nothing)
                End If
            Catch ex As Exception
                Logger.LogError("LoadMaterialsList in FrmKitchenWaste", ex)
            End Try
        End Sub

        Private Sub OnMaterialSelected(sender As Object, e As EventArgs)
            If cmbMaterials.SelectedItem IsNot Nothing AndAlso TypeOf cmbMaterials.SelectedItem Is DataRowView Then
                Dim drv As DataRowView = CType(cmbMaterials.SelectedItem, DataRowView)
                Dim unitName As String = drv("UnitName").ToString()
                Dim costPrice As Decimal = Convert.ToDecimal(drv("CostPrice"))
                Dim currentStock As Decimal = Convert.ToDecimal(drv("CurrentStock"))

                lblUnitDisplay.Text = unitName
                lblAvailableStock.Text = $"الرصيد الحالي: {currentStock:0.####} {unitName}"
                txtUnitCost.Text = costPrice.ToString("F2")
                RecalculateLineTotal(Nothing, Nothing)
            End If
        End Sub

        Private Sub RecalculateLineTotal(sender As Object, e As EventArgs)
            Dim qty As Decimal = 0
            Dim cost As Decimal = 0
            Decimal.TryParse(txtQuantity.Text, qty)
            Decimal.TryParse(txtUnitCost.Text, cost)

            Dim total = qty * cost
            lblLineTotalCost.Text = $"الخسارة: {total:N2} ج"
        End Sub

        Private Sub OnAddItemClick(sender As Object, e As EventArgs)
            If cmbMaterials.SelectedValue Is Nothing Then
                SmartMessageBox.Show("يرجى اختيار خامة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim qty As Decimal = 0
            If Not Decimal.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
                SmartMessageBox.Show("يرجى إدخال كمية تالفة صحيحة أكبر من صفر!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQuantity.Focus()
                Return
            End If

            Dim cost As Decimal = 0
            Decimal.TryParse(txtUnitCost.Text, cost)

            Dim drv As DataRowView = CType(cmbMaterials.SelectedItem, DataRowView)
            Dim matId As Integer = Convert.ToInt32(drv("MaterialID"))
            Dim matName As String = drv("MaterialName").ToString()
            Dim unitName As String = drv("UnitName").ToString()

            Dim item As New KitchenWasteDetailModel With {
                .MaterialID = matId,
                .ItemName = matName,
                .UnitName = unitName,
                .Quantity = qty,
                .UnitCost = cost,
                .TotalCost = qty * cost,
                .Notes = txtReason.Text.Trim()
            }

            _currentItems.Add(item)
            RefreshCurrentGrid()

            txtQuantity.Text = "1"
            txtReason.Clear()
        End Sub

        Private Sub RefreshCurrentGrid()
            dgvCurrentItems.Rows.Clear()
            Dim grandLoss As Decimal = 0

            For Each itm In _currentItems
                grandLoss += itm.TotalCost
                dgvCurrentItems.Rows.Add(itm.ItemName, itm.Quantity, itm.UnitName, itm.UnitCost, itm.TotalCost, itm.Notes)
            Next

            lblTicketTotal.Text = $"إجمالي الخسائر المالية للتذكرة: {grandLoss:N2} ج"
        End Sub

        Private Async Function SaveWasteTicketAsync() As Task
            If _currentItems.Count = 0 Then
                SmartMessageBox.Show("لا توجد أصناف في إذن الهالك لحفظها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim storeId As Integer = If(cmbStores.SelectedValue IsNot Nothing, Convert.ToInt32(cmbStores.SelectedValue), 1)
            Dim totalLoss As Decimal = _currentItems.Sum(Function(x) x.TotalCost)

            Dim confirm = SmartMessageBox.Show($"هل أنت متأكد من حفظ إذن الهالك بقيمة إجمالية {totalLoss:N2} ج وتأكيد خصم الخامات من المخزن؟", "تأكيد إذن الهالك", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm <> DialogResult.Yes Then Return

            Dim wasteTypeVal As KitchenWasteType = CType(cmbWasteType.SelectedIndex + 1, KitchenWasteType)
            Dim shiftIdVal As Integer? = If(ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, CType(Nothing, Integer?))

            Dim wasteModel As New KitchenWasteModel With {
                .WasteDate = dtpDate.Value,
                .WasteType = wasteTypeVal,
                .StoreID = storeId,
                .TotalLossAmount = totalLoss,
                .ShiftID = shiftIdVal,
                .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
                .ResponsibleStaffName = txtResponsibleStaff.Text.Trim(),
                .Reason = txtReason.Text.Trim()
            }

            For Each itm In _currentItems
                wasteModel.Details.Add(itm)
            Next

            btnSaveWasteTicket.Enabled = False
            Try
                Dim success = Await _repo.SaveKitchenWasteAsync(wasteModel)
                If success Then
                    Try
                        NotificationManager.Instance.NotifyKitchenWaste(wasteModel.WasteNumber)
                    Catch exNotif As Exception
                        Logger.LogError("FrmKitchenWaste.SaveWasteTicketAsync - Notification", exNotif)
                    End Try
                    SmartMessageBox.Show($"تم حفظ وترحيل إذن الهالك برقم: {wasteModel.WasteNumber} بنجاح، وتم تحديث أرصدة الخامات بالمخزن!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _currentItems.Clear()
                    RefreshCurrentGrid()
                    LoadMaterialsList()
                    LoadWasteHistory()
                Else
                    SmartMessageBox.Show("حدث خطأ أثناء حفظ إذن الهالك!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                Logger.LogError("SaveWasteTicketAsync", ex)
                SmartMessageBox.Show("خطأ غير متوقع: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                btnSaveWasteTicket.Enabled = True
            End Try
        End Function

        Private Sub LoadWasteHistory()
            Try
                Dim typeFilter As Byte = CByte(cmbHistoryType.SelectedIndex) ' 0 = الكل
                Dim dt = _repo.GetKitchenWasteReport(dtpFrom.Value, dtpTo.Value, wasteType:=typeFilter)

                dgvHistory.DataSource = dt
                datagridviewsetup(dgvHistory)

                If dgvHistory.Columns.Contains("WasteID") Then dgvHistory.Columns("WasteID").Visible = False
                If dgvHistory.Columns.Contains("WasteNumber") Then dgvHistory.Columns("WasteNumber").HeaderText = "رقم الإذن"
                If dgvHistory.Columns.Contains("WasteDate") Then dgvHistory.Columns("WasteDate").HeaderText = "تاريخ الهالك"
                If dgvHistory.Columns.Contains("WasteTypeName") Then dgvHistory.Columns("WasteTypeName").HeaderText = "نوع الهالك"
                If dgvHistory.Columns.Contains("StoreName") Then dgvHistory.Columns("StoreName").HeaderText = "المخزن"
                If dgvHistory.Columns.Contains("TotalLossAmount") Then
                    dgvHistory.Columns("TotalLossAmount").HeaderText = "قيمة الخسارة"
                    dgvHistory.Columns("TotalLossAmount").DefaultCellStyle.Format = "N2"
                    dgvHistory.Columns("TotalLossAmount").DefaultCellStyle.ForeColor = Color.DarkRed
                    dgvHistory.Columns("TotalLossAmount").DefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
                End If
                If dgvHistory.Columns.Contains("ResponsibleStaffName") Then dgvHistory.Columns("ResponsibleStaffName").HeaderText = "المسؤول"
                If dgvHistory.Columns.Contains("Reason") Then dgvHistory.Columns("Reason").HeaderText = "السبب"
                If dgvHistory.Columns.Contains("ItemsCount") Then dgvHistory.Columns("ItemsCount").HeaderText = "عدد الخامات"

                Dim totalHistLoss As Decimal = 0
                For Each row As DataRow In dt.Rows
                    totalHistLoss += Convert.ToDecimal(row("TotalLossAmount"))
                Next
                lblHistoryTotalLoss.Text = $"إجمالي الخسائر المالية للهالك خلال الفترة: {totalHistLoss:N2} ج"
            Catch ex As Exception
                Logger.LogError("LoadWasteHistory", ex)
            End Try
        End Sub
    End Class
End Namespace
