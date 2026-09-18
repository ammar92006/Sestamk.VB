Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Global.WindowsApp1
    Public Class FrmKitchenWaste
        Inherits Form

        Private ReadOnly _repo As POSRepository
        Private _currentItems As New List(Of KitchenWasteDetailModel)()
        Private _dtMaterials As DataTable

        ' عناصر واجهة المستخدم
        Private panelHeader As Panel
        Private lblTitle As Label
        Private btnCloseForm As Button
        Private tabControl As TabControl
        Private tabNewWaste As TabPage
        Private tabWasteHistory As TabPage

        ' عناصر تبويب تسجيل الهالك
        Private dtpDate As DateTimePicker
        Private cmbStores As ComboBox
        Private cmbWasteType As ComboBox
        Private cmbMaterials As ComboBox
        Private txtQuantity As TextBox
        Private txtUnitCost As TextBox
        Private lblAvailableStock As Label
        Private lblUnitDisplay As Label
        Private lblLineTotalCost As Label
        Private txtResponsibleStaff As TextBox
        Private txtReason As TextBox
        Private btnAddItem As Button
        Private dgvCurrentItems As DataGridView
        Private lblTicketTotal As Label
        Private btnSaveWasteTicket As Button
        Private btnClearCurrent As Button

        ' عناصر تبويب سجل وتقارير الهالك
        Private dtpFrom As DateTimePicker
        Private dtpTo As DateTimePicker
        Private cmbHistoryStore As ComboBox
        Private cmbHistoryType As ComboBox
        Private btnFilterHistory As Button
        Private dgvHistory As DataGridView
        Private lblHistoryTotalLoss As Label

        Public Sub New()
            _repo = New POSRepository(DBModule.ConnectionString)
            InitializeComponentsCustom()
        End Sub

        Private Sub InitializeComponentsCustom()
            Me.Text = "إدارة الهالك والتالف في المطبخ (Kitchen Waste Control)"
            Me.ClientSize = New Size(1150, 720)
            Me.MinimumSize = New Size(950, 600)
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
                .Text = "🗑️ إدارة الهالك والتالف في المطبخ (Kitchen Waste Control)",
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

            ' 2. التبويبات
            tabControl = New TabControl With {
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .Padding = New Point(15, 6)
            }

            tabNewWaste = New TabPage("تسجيل إذن هالك وتالف جديد")
            tabWasteHistory = New TabPage("سجل وتقارير خسائر الهالك")
            tabControl.TabPages.Add(tabNewWaste)
            tabControl.TabPages.Add(tabWasteHistory)
            Me.Controls.Add(tabControl)

            SetupNewWasteTab()
            SetupWasteHistoryTab()

            Dim drag As New FormDragHelper(Me, panelHeader)
        End Sub

        ' =========================================================
        ' إعداد تبويب تسجيل إذن هالك جديد
        ' =========================================================
        Private Sub SetupNewWasteTab()
            tabNewWaste.BackColor = Color.White
            tabNewWaste.Padding = New Padding(15)

            ' لوحة البيانات الأساسية
            Dim pnlInputs As New Panel With {
                .Dock = DockStyle.Top,
                .Height = 180,
                .BackColor = Color.FromArgb(248, 250, 252),
                .BorderStyle = BorderStyle.FixedSingle,
                .Padding = New Padding(10)
            }

            Dim MakeLabel = Function(text As String, x As Integer, y As Integer) As Label
                                Dim lbl As New Label With {
                                    .Text = text,
                                    .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                                    .ForeColor = Color.FromArgb(50, 60, 75),
                                    .AutoSize = True,
                                    .Location = New Point(x, y)
                                }
                                pnlInputs.Controls.Add(lbl)
                                Return lbl
                            End Function

            ' السطر 1
            MakeLabel("تاريخ الهالك:", 20, 15)
            dtpDate = New DateTimePicker With {.Location = New Point(105, 12), .Width = 140, .Format = DateTimePickerFormat.Short}
            pnlInputs.Controls.Add(dtpDate)

            MakeLabel("المخزن:", 265, 15)
            cmbStores = New ComboBox With {.Location = New Point(325, 12), .Width = 160, .DropDownStyle = ComboBoxStyle.DropDownList}
            AddHandler cmbStores.SelectedIndexChanged, Sub() LoadMaterialsList()
            pnlInputs.Controls.Add(cmbStores)

            MakeLabel("نوع وتصنيف الهالك:", 505, 15)
            cmbWasteType = New ComboBox With {.Location = New Point(635, 12), .Width = 200, .DropDownStyle = ComboBoxStyle.DropDownList}
            cmbWasteType.Items.AddRange(New Object() {"خامة تالفة / تالف إعداد", "سوء إعداد / خطأ طهي", "انتهاء صلاحية", "وجبة تالفة"})
            cmbWasteType.SelectedIndex = 0
            pnlInputs.Controls.Add(cmbWasteType)

            ' السطر 2: اختيار الخامة والكمية والتكلفة
            MakeLabel("الخامة المهدورة:", 20, 58)
            cmbMaterials = New ComboBox With {.Location = New Point(105, 55), .Width = 280, .DropDownStyle = ComboBoxStyle.DropDownList}
            AddHandler cmbMaterials.SelectedIndexChanged, AddressOf OnMaterialSelected
            pnlInputs.Controls.Add(cmbMaterials)

            lblAvailableStock = New Label With {
                .Text = "الرصيد: 0.00",
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(70, 80, 95),
                .AutoSize = True,
                .Location = New Point(400, 58)
            }
            pnlInputs.Controls.Add(lblAvailableStock)

            MakeLabel("الكمية التالفة:", 520, 58)
            txtQuantity = New TextBox With {.Location = New Point(605, 55), .Width = 80, .Text = "1"}
            AddHandler txtQuantity.TextChanged, AddressOf RecalculateLineTotal
            pnlInputs.Controls.Add(txtQuantity)

            lblUnitDisplay = New Label With {.Text = "الوحدة", .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .ForeColor = Color.Gray, .AutoSize = True, .Location = New Point(690, 58)}
            pnlInputs.Controls.Add(lblUnitDisplay)

            MakeLabel("تكلفة الوحدة:", 750, 58)
            txtUnitCost = New TextBox With {.Location = New Point(830, 55), .Width = 80, .Text = "0.00"}
            AddHandler txtUnitCost.TextChanged, AddressOf RecalculateLineTotal
            pnlInputs.Controls.Add(txtUnitCost)

            lblLineTotalCost = New Label With {
                .Text = "الخسارة: 0.00 ج",
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(220, 38, 38),
                .AutoSize = True,
                .Location = New Point(930, 57)
            }
            pnlInputs.Controls.Add(lblLineTotalCost)

            ' السطر 3: الموظف والسبب وزر الإضافة
            MakeLabel("الموظف المسؤول:", 20, 102)
            txtResponsibleStaff = New TextBox With {.Location = New Point(125, 99), .Width = 200}
            pnlInputs.Controls.Add(txtResponsibleStaff)

            MakeLabel("سبب التلف / الملاحظات:", 345, 102)
            txtReason = New TextBox With {.Location = New Point(490, 99), .Width = 380}
            pnlInputs.Controls.Add(txtReason)

            btnAddItem = New Button With {
                .Text = "➕ إضافة للقائمة",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(16, 149, 105),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(140, 34),
                .Location = New Point(890, 96),
                .Cursor = Cursors.Hand
            }
            btnAddItem.FlatAppearance.BorderSize = 0
            AddHandler btnAddItem.Click, AddressOf OnAddItemClick
            pnlInputs.Controls.Add(btnAddItem)

            tabNewWaste.Controls.Add(pnlInputs)

            ' شريط الإجمالي وأزرار الحفظ في الأسفل
            Dim pnlBottom As New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 60,
                .BackColor = Color.FromArgb(241, 245, 249),
                .Padding = New Padding(15, 10, 15, 10)
            }

            lblTicketTotal = New Label With {
                .Text = "إجمالي الخسائر المالية للتذكرة: 0.00 ج",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(185, 28, 28),
                .AutoSize = True,
                .Location = New Point(20, 18)
            }
            pnlBottom.Controls.Add(lblTicketTotal)

            btnSaveWasteTicket = New Button With {
                .Text = "💾 ترحيل وحفظ إذن الهالك وخصم المخزن",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(220, 38, 38),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(300, 40),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(20, 10),
                .Cursor = Cursors.Hand
            }
            btnSaveWasteTicket.FlatAppearance.BorderSize = 0
            AddHandler btnSaveWasteTicket.Click, Async Sub() Await SaveWasteTicketAsync()
            pnlBottom.Controls.Add(btnSaveWasteTicket)

            btnClearCurrent = New Button With {
                .Text = "تفريغ القائمة",
                .Font = New Font("Segoe UI", 10.0F),
                .ForeColor = Color.FromArgb(70, 80, 95),
                .BackColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(110, 40),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(330, 10),
                .Cursor = Cursors.Hand
            }
            AddHandler btnClearCurrent.Click, Sub()
                                                  _currentItems.Clear()
                                                  RefreshCurrentGrid()
                                              End Sub
            pnlBottom.Controls.Add(btnClearCurrent)

            tabNewWaste.Controls.Add(pnlBottom)

            ' جدول الأصناف الحالية
            dgvCurrentItems = New DataGridView With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = Color.White,
                .AllowUserToAddRows = False,
                .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .RowTemplate = New DataGridViewRow With {.Height = 32}
            }
            tabNewWaste.Controls.Add(dgvCurrentItems)
            dgvCurrentItems.BringToFront()

            SetupCurrentGridColumns()
        End Sub

        Private Sub SetupCurrentGridColumns()
            dgvCurrentItems.Columns.Clear()
            dgvCurrentItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colName", .HeaderText = "الخامة المهدورة", .Width = 250})
            dgvCurrentItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colQty", .HeaderText = "الكمية التالفة", .Width = 110, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "0.####"}})
            dgvCurrentItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colUnit", .HeaderText = "الوحدة", .Width = 90})
            dgvCurrentItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colCost", .HeaderText = "تكلفة الوحدة", .Width = 120, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2"}})
            dgvCurrentItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTotal", .HeaderText = "إجمالي الخسارة", .Width = 130, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .ForeColor = Color.DarkRed}})
            dgvCurrentItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNotes", .HeaderText = "ملاحظات", .Width = 250})

            Dim btnCol As New DataGridViewButtonColumn With {
                .Name = "colDelete",
                .HeaderText = "حذف",
                .Text = "🗑️",
                .UseColumnTextForButtonValue = True,
                .Width = 60
            }
            dgvCurrentItems.Columns.Add(btnCol)
            ThemeHelper.ApplyDataGridViewTheme(dgvCurrentItems, ThemeManager.Instance.CurrentPalette)

            AddHandler dgvCurrentItems.CellContentClick, Sub(s, e)
                                                             If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvCurrentItems.Columns("colDelete").Index Then
                                                                 _currentItems.RemoveAt(e.RowIndex)
                                                                 RefreshCurrentGrid()
                                                             End If
                                                         End Sub
        End Sub

        ' =========================================================
        ' إعداد تبويب سجل وتقارير الهالك
        ' =========================================================
        Private Sub SetupWasteHistoryTab()
            tabWasteHistory.BackColor = Color.White
            tabWasteHistory.Padding = New Padding(15)

            Dim pnlFilter As New Panel With {
                .Dock = DockStyle.Top,
                .Height = 60,
                .BackColor = Color.FromArgb(248, 250, 252),
                .BorderStyle = BorderStyle.FixedSingle,
                .Padding = New Padding(10)
            }

            Dim lblFrom As New Label With {.Text = "من تاريخ:", .AutoSize = True, .Location = New Point(15, 18), .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}
            pnlFilter.Controls.Add(lblFrom)
            dtpFrom = New DateTimePicker With {.Location = New Point(80, 15), .Width = 130, .Format = DateTimePickerFormat.Short, .Value = DateTime.Now.Date.AddDays(-7)}
            pnlFilter.Controls.Add(dtpFrom)

            Dim lblTo As New Label With {.Text = "إلى تاريخ:", .AutoSize = True, .Location = New Point(225, 18), .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}
            pnlFilter.Controls.Add(lblTo)
            dtpTo = New DateTimePicker With {.Location = New Point(290, 15), .Width = 130, .Format = DateTimePickerFormat.Short, .Value = DateTime.Now}
            pnlFilter.Controls.Add(dtpTo)

            Dim lblType As New Label With {.Text = "نوع الهالك:", .AutoSize = True, .Location = New Point(435, 18), .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}
            pnlFilter.Controls.Add(lblType)
            cmbHistoryType = New ComboBox With {.Location = New Point(510, 15), .Width = 160, .DropDownStyle = ComboBoxStyle.DropDownList}
            cmbHistoryType.Items.AddRange(New Object() {"كل الأنواع", "خامة تالفة / تالف إعداد", "سوء إعداد / خطأ طهي", "انتهاء صلاحية", "وجبة تالفة"})
            cmbHistoryType.SelectedIndex = 0
            pnlFilter.Controls.Add(cmbHistoryType)

            btnFilterHistory = New Button With {
                .Text = "🔍 بحث وفلترة",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(33, 42, 57),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(110, 32),
                .Location = New Point(690, 14),
                .Cursor = Cursors.Hand
            }
            btnFilterHistory.FlatAppearance.BorderSize = 0
            AddHandler btnFilterHistory.Click, Sub() LoadWasteHistory()
            pnlFilter.Controls.Add(btnFilterHistory)

            tabWasteHistory.Controls.Add(pnlFilter)

            ' شريط الإجمالي في الأسفل
            Dim pnlHistBottom As New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 50,
                .BackColor = Color.FromArgb(241, 245, 249),
                .Padding = New Padding(15, 12, 15, 12)
            }

            lblHistoryTotalLoss = New Label With {
                .Text = "إجمالي الخسائر المالية للهالك خلال الفترة: 0.00 ج",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(185, 28, 28),
                .AutoSize = True,
                .Location = New Point(20, 12)
            }
            pnlHistBottom.Controls.Add(lblHistoryTotalLoss)
            tabWasteHistory.Controls.Add(pnlHistBottom)

            ' جدول السجل
            dgvHistory = New DataGridView With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = Color.White,
                .AllowUserToAddRows = False,
                .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .RowTemplate = New DataGridViewRow With {.Height = 32}
            }
            tabWasteHistory.Controls.Add(dgvHistory)
            dgvHistory.BringToFront()
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
                MessageBox.Show("يرجى اختيار خامة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim qty As Decimal = 0
            If Not Decimal.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
                MessageBox.Show("يرجى إدخال كمية تالفة صحيحة أكبر من صفر!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                MessageBox.Show("لا توجد أصناف في إذن الهالك لحفظها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim storeId As Integer = If(cmbStores.SelectedValue IsNot Nothing, Convert.ToInt32(cmbStores.SelectedValue), 1)
            Dim totalLoss As Decimal = _currentItems.Sum(Function(x) x.TotalCost)

            Dim confirm = MessageBox.Show($"هل أنت متأكد من حفظ إذن الهالك بقيمة إجمالية {totalLoss:N2} ج وتأكيد خصم الخامات من المخزن؟", "تأكيد إذن الهالك", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
                    MessageBox.Show($"تم حفظ وترحيل إذن الهالك برقم: {wasteModel.WasteNumber} بنجاح، وتم تحديث أرصدة الخامات بالمخزن!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _currentItems.Clear()
                    RefreshCurrentGrid()
                    LoadMaterialsList()
                    LoadWasteHistory()
                Else
                    MessageBox.Show("حدث خطأ أثناء حفظ إذن الهالك!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                Logger.LogError("SaveWasteTicketAsync", ex)
                MessageBox.Show("خطأ غير متوقع: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
