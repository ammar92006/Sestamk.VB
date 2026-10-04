Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

''' <summary>
''' شاشة خريطة ومراقبة طاولات الصالة التفاعلية الذكية (Smart Visual Floor Plan and Live Table Monitor).
''' تحاكي كبرى الأنظمة العالمية (Toast POS / Foodics):
'''   • مراقبة حية لنسبة إشغال الصالة وإجمالي المبيعات المفتوحة لحظة بلحظة.
'''   • عرض الوقت المنقضي لجلوس كل عميل (Elapsed Seated Time) بدقة الدقيقة.
'''   • عرض قيمة الحساب الجاري المفتوح على الطاولة، وبيانات الحجوزات والعربونات.
'''   • فلترة سريعة وبحث فوري وتحديث تلقائي دوري كل 10 ثوان دون مقاطعة الكاشير.
''' </summary>
Public Class FrmSelectTable

    Private ReadOnly _repo As POSRepository
    Private _selectedSectionID As Integer? = Nothing
    Private _statusFilter As Byte = 0 ' 0 = الكل, 1 = متاحة, 2 = مشغولة, 3 = محجوزة
    Private _searchTerm As String = ""
    Private _isRefreshing As Boolean = False
    Private _cachedTables As New List(Of RestaurantTableModel)()
    Private _activePendingMap As New Dictionary(Of Integer, PendingInvoiceModel)()
    Private _activeReservationMap As New Dictionary(Of Integer, TableReservationModel)()

    ' البيانات المرتجعة للـ frmPOS
    Public Property SelectedTableID As Integer
    Public Property SelectedTableName As String
    Public Property IsOccupiedSelected As Boolean = False
    Public Property ActiveReservation As TableReservationModel = Nothing
    Public Property HasActiveReservation As Boolean = False

    Public Sub New(repo As POSRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub FrmSelectTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)

        ' دعم سحب النافذة عبر الهيدر
        Try
            Dim drag As New FormDragHelper(Me, panelHeader)
        Catch
        End Try

        LoadSections()
        RefreshData()

        ' تفعيل مؤقت المراقبة الحية (كل 10 ثوانٍ)
        tmrLive.Interval = 10000
        tmrLive.Start()
    End Sub

    ' =========================================================
    ' 1. رسم أزرار الأقسام (Sections Bar)
    ' =========================================================
    Private Sub LoadSections()
        flpSections.Controls.Clear()

        ' زر عرض الكل
        Dim btnAll As New Guna2Button With {
            .Text = "🌟 كل الصالة",
            .Tag = 0,
            .Width = 120,
            .Height = 38,
            .BorderRadius = 8,
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        }
        ApplySectionButtonStyle(btnAll, _selectedSectionID Is Nothing OrElse _selectedSectionID = 0)
        AddHandler btnAll.Click, AddressOf SectionButton_Click
        flpSections.Controls.Add(btnAll)

        Dim sections = _repo.GetRestaurantSections()
        If sections IsNot Nothing Then
            For Each sec In sections
                Dim isSelected As Boolean = (_selectedSectionID.HasValue AndAlso _selectedSectionID.Value = sec.SectionID)
                Dim btn As New Guna2Button With {
                    .Text = "📍 " & sec.SectionName,
                    .Tag = sec.SectionID,
                    .Width = 135,
                    .Height = 38,
                    .BorderRadius = 8,
                    .Cursor = Cursors.Hand,
                    .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
                }
                ApplySectionButtonStyle(btn, isSelected)
                AddHandler btn.Click, AddressOf SectionButton_Click
                flpSections.Controls.Add(btn)
            Next
        End If
    End Sub

    Private Sub ApplySectionButtonStyle(btn As Guna2Button, isSelected As Boolean)
        Dim pal = ThemeManager.Instance.CurrentPalette
        If isSelected Then
            btn.FillColor = Color.FromArgb(59, 130, 246)
            btn.ForeColor = Color.White
            btn.BorderThickness = 0
        Else
            btn.FillColor = Color.FromArgb(30, 41, 59)
            btn.ForeColor = Color.FromArgb(203, 213, 225)
            btn.BorderColor = Color.FromArgb(51, 65, 85)
            btn.BorderThickness = 1
        End If
    End Sub

    Private Sub SectionButton_Click(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Guna2Button)
        Dim sectionID As Integer = Convert.ToInt32(btn.Tag)

        If sectionID = 0 Then
            _selectedSectionID = Nothing
        Else
            _selectedSectionID = sectionID
        End If

        For Each ctrl As Control In flpSections.Controls
            If TypeOf ctrl Is Guna2Button Then
                Dim sBtn = CType(ctrl, Guna2Button)
                Dim sID As Integer = Convert.ToInt32(sBtn.Tag)
                Dim active As Boolean = (sID = 0 AndAlso (_selectedSectionID Is Nothing OrElse _selectedSectionID = 0)) OrElse (_selectedSectionID.HasValue AndAlso _selectedSectionID.Value = sID)
                ApplySectionButtonStyle(sBtn, active)
            End If
        Next

        RefreshData()
    End Sub

    ' =========================================================
    ' 2. جلب البيانات اللحظية وتحديث الإحصائيات (Live Monitoring)
    ' =========================================================
    Private Sub RefreshData()
        If _isRefreshing Then Return
        _isRefreshing = True

        Try
            ' 1) جلب طاولات القسم المحدد
            _cachedTables = _repo.GetRestaurantTables(_selectedSectionID)
            If _cachedTables Is Nothing Then _cachedTables = New List(Of RestaurantTableModel)()

            ' 2) جلب الفواتير المعلقة النشطة للطاولات لحساب الحسابات الجارية وأوقات الجلوس
            _activePendingMap.Clear()
            Dim pendingList = _repo.GetPendingInvoices()
            If pendingList IsNot Nothing Then
                For Each p In pendingList
                    If p.TableID.HasValue AndAlso p.TableID.Value > 0 AndAlso Not _activePendingMap.ContainsKey(p.TableID.Value) Then
                        _activePendingMap.Add(p.TableID.Value, p)
                    End If
                Next
            End If

            ' 3) جلب بيانات الحجوزات النشطة للطاولات المحجوزة
            _activeReservationMap.Clear()
            For Each tbl In _cachedTables
                If tbl.TableStatus = 3 Then
                    Dim resv = _repo.GetActiveReservationForTable(tbl.TableID)
                    If resv IsNot Nothing Then
                        _activeReservationMap(tbl.TableID) = resv
                    End If
                End If
            Next

            ' 4) حساب المؤشرات الحية لبطاقات الـ KPI
            Dim totalCount As Integer = _cachedTables.Count
            Dim freeCount As Integer = _cachedTables.Where(Function(t) t.TableStatus = 1).Count()
            Dim occupiedCount As Integer = _cachedTables.Where(Function(t) t.TableStatus = 2).Count()
            Dim reservedCount As Integer = _cachedTables.Where(Function(t) t.TableStatus = 3).Count()

            Dim totalActiveMoney As Decimal = 0D
            For Each p In _activePendingMap.Values
                totalActiveMoney += p.TotalAmount
            Next

            Dim occupancyPct As Integer = If(totalCount > 0, CInt(Math.Round((occupiedCount * 100.0) / totalCount)), 0)

            lblTotalVal.Text = $"{totalCount} طاولة"
            lblOccupancyVal.Text = $"{occupancyPct}%"
            lblActiveTabVal.Text = $"{totalActiveMoney:N2} ج.م"
            lblFreeVal.Text = freeCount.ToString()
            lblOccupiedVal.Text = occupiedCount.ToString()
            lblReservedVal.Text = reservedCount.ToString()

            ' 5) رسم بطاقات الطاولات التفاعلية
            RenderTableCards()

        Catch ex As Exception
            Logger.LogError("FrmSelectTable.RefreshData", ex)
        Finally
            _isRefreshing = False
        End Try
    End Sub

    ' =========================================================
    ' 3. رسم بطاقات الطاولات التفاعلية (World-Class Interactive Cards)
    ' =========================================================
    Private Sub RenderTableCards()
        flpTables.SuspendLayout()
        flpTables.Controls.Clear()

        ' تصفية الطاولات حسب البحث والحالة
        Dim filtered = _cachedTables.AsEnumerable()

        If _statusFilter > 0 Then
            filtered = filtered.Where(Function(t) t.TableStatus = _statusFilter)
        End If

        If Not String.IsNullOrWhiteSpace(_searchTerm) Then
            Dim term = _searchTerm.Trim()
            filtered = filtered.Where(Function(t)
                                          Dim name = If(t.TableName, "")
                                          Dim num = If(t.TableNumber, "")
                                          Return name.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                                 num.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0
                                      End Function)
        End If

        Dim displayList = filtered.ToList()

        If displayList.Count = 0 Then
            Dim pnlEmpty As New Guna2Panel With {
                .Size = New Size(flpTables.Width - 30, 200),
                .FillColor = Color.Transparent
            }
            Dim lblEmpty As New Label With {
                .Text = "لا توجد طاولات مطابقة للمعايير المحددة." & vbCrLf & "جرب تغيير القسم أو تصفية الحالة.",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter
            }
            pnlEmpty.Controls.Add(lblEmpty)
            flpTables.Controls.Add(pnlEmpty)
            flpTables.ResumeLayout(True)
            Return
        End If

        For Each tbl In displayList
            Dim card = CreateTableCard(tbl)
            flpTables.Controls.Add(card)
        Next

        flpTables.ResumeLayout(True)
    End Sub

    ''' <summary>
    ''' إنشاء بطاقة الطاولة التفاعلية المضيئة وفق معايير أنظمة المطاعم العالمية.
    ''' </summary>
    Private Function CreateTableCard(tbl As RestaurantTableModel) As Control
        Dim displayName As String = If(Not String.IsNullOrWhiteSpace(tbl.TableName), tbl.TableName, "طاولة " & tbl.TableNumber)
        Dim sectionName As String = If(tbl.SectionInfo IsNot Nothing, tbl.SectionInfo.SectionName, "")

        Dim card As New Guna2Panel With {
            .Width = 205,
            .Height = 150,
            .BorderRadius = 14,
            .BorderThickness = 2,
            .Margin = New Padding(8),
            .Cursor = Cursors.Hand,
            .Tag = tbl
        }

        Dim statusColor As Color
        Dim cardBg As Color
        Dim statusBadgeText As String
        Dim middleText1 As String = ""
        Dim middleText2 As String = ""
        Dim middleColor1 As Color = Color.White
        Dim middleColor2 As Color = Color.FromArgb(148, 163, 184)
        Dim actionText As String = ""

        Select Case tbl.TableStatus
            Case 1 ' 🟢 مـتـاحـة (Free)
                statusColor = Color.FromArgb(16, 185, 129) ' Emerald 500
                cardBg = Color.FromArgb(15, 30, 35)
                statusBadgeText = "🟢 مـتـاحـة"
                middleText1 = "جاهزة للاستقبال ✓"
                middleColor1 = Color.FromArgb(52, 211, 153)
                middleText2 = "لا توجد طلبات جارية"
                actionText = "➕ فتح طلب جديد"

            Case 2 ' 🔴 مـشـغـولـة (Occupied with active tab)
                statusColor = Color.FromArgb(239, 68, 68) ' Rose 500
                cardBg = Color.FromArgb(35, 20, 26)
                statusBadgeText = "🔴 مـشـغـولـة"

                Dim pending As PendingInvoiceModel = Nothing
                _activePendingMap.TryGetValue(tbl.TableID, pending)

                If pending IsNot Nothing Then
                    Dim elapsedMinutes = Math.Max(0, CInt((DateTime.Now - pending.PendingDate).TotalMinutes))
                    Dim timeStr = If(elapsedMinutes < 60, $"{elapsedMinutes} دقيقة", $"{elapsedMinutes \ 60} س {elapsedMinutes Mod 60} د")
                    middleText1 = $"💰 {pending.TotalAmount:N2} ج.م"
                    middleColor1 = Color.FromArgb(250, 204, 21) ' Yellow

                    Dim timerColor = If(elapsedMinutes < 30, "🟢", If(elapsedMinutes < 60, "🟡", "🔴"))
                    middleText2 = $"{timerColor} جالس منذ {timeStr}"
                    middleColor2 = Color.FromArgb(248, 113, 113)
                    If Not String.IsNullOrWhiteSpace(pending.CustomerName) Then
                        actionText = $"👤 {pending.CustomerName}"
                    Else
                        actionText = "📋 فتح الحساب / إضافة طلبات"
                    End If
                Else
                    middleText1 = "طلب صالة مفتوح"
                    middleText2 = "الحساب قيد الإعداد"
                    actionText = "فتح الحساب"
                End If

            Case 3 ' 🟡 مـحـجـوزة (Reserved)
                statusColor = Color.FromArgb(245, 158, 11) ' Amber 500
                cardBg = Color.FromArgb(35, 28, 15)
                statusBadgeText = "🟡 مـحـجـوزة"

                Dim resv As TableReservationModel = Nothing
                _activeReservationMap.TryGetValue(tbl.TableID, resv)

                If resv IsNot Nothing Then
                    middleText1 = $"👤 {resv.CustomerName}"
                    middleColor1 = Color.FromArgb(253, 230, 138)
                    Dim depStr = If(resv.DepositAmount > 0, $"عربون: {resv.DepositAmount:N0} ج.م", "بلا عربون")
                    middleText2 = $"🕒 {resv.ReservationDateTime:hh:mm tt} • {depStr}"
                    actionText = "⚡ تسكين الحجز وبدء الطلب"
                Else
                    middleText1 = "حجز صالة مؤكد"
                    middleText2 = "موعد وصول العميل"
                    actionText = "تسكين الحجز"
                End If

            Case Else
                statusColor = Color.FromArgb(100, 116, 139)
                cardBg = Color.FromArgb(24, 30, 42)
                statusBadgeText = "معطلة"
                middleText1 = "غير متاحة للخدمة"
                actionText = "-"
        End Select

        card.BorderColor = statusColor
        card.FillColor = cardBg

        ' 1. شريط رأس الطاولة (الاسم + المقاعد)
        Dim pnlTop As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 36,
            .BackColor = Color.Transparent,
            .Padding = New Padding(10, 6, 10, 0)
        }

        Dim lblName As New Label With {
            .Text = "🍽️ " & displayName,
            .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
            .ForeColor = Color.White,
            .Dock = DockStyle.Right,
            .AutoSize = True
        }

        Dim lblChairs As New Label With {
            .Text = $"🪑 {tbl.ChairsCount}",
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(148, 163, 184),
            .Dock = DockStyle.Left,
            .AutoSize = True
        }

        pnlTop.Controls.Add(lblName)
        pnlTop.Controls.Add(lblChairs)

        ' 2. جسم البطاقة (الحالة والمبالغ والأوقات)
        Dim pnlBody As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.Transparent,
            .Padding = New Padding(8, 2, 8, 2)
        }

        Dim lblBadge As New Label With {
            .Text = statusBadgeText,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = statusColor,
            .Dock = DockStyle.Top,
            .Height = 18,
            .TextAlign = ContentAlignment.TopRight
        }

        Dim lblMid1 As New Label With {
            .Text = middleText1,
            .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
            .ForeColor = middleColor1,
            .Dock = DockStyle.Top,
            .Height = 26,
            .TextAlign = ContentAlignment.MiddleRight,
            .AutoEllipsis = True
        }

        Dim lblMid2 As New Label With {
            .Text = middleText2,
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular),
            .ForeColor = middleColor2,
            .Dock = DockStyle.Top,
            .Height = 20,
            .TextAlign = ContentAlignment.MiddleRight,
            .AutoEllipsis = True
        }

        pnlBody.Controls.Add(lblMid2)
        pnlBody.Controls.Add(lblMid1)
        pnlBody.Controls.Add(lblBadge)

        ' 3. شريط الإجراء السفلي
        Dim pnlBottomCard As New Guna2Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 32,
            .FillColor = Color.FromArgb(30, 0, 0, 0),
            .BorderRadius = 8,
            .Margin = New Padding(4)
        }

        Dim lblAction As New Label With {
            .Text = actionText,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(226, 232, 240),
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter,
            .AutoEllipsis = True
        }
        pnlBottomCard.Controls.Add(lblAction)

        card.Controls.Add(pnlBody)
        card.Controls.Add(pnlBottomCard)
        card.Controls.Add(pnlTop)

        ' تفويض حدث النقر لكافة عناصر البطاقة
        WireCardClick(card, tbl)
        For Each child As Control In card.Controls
            WireCardClick(child, tbl)
            For Each subChild As Control In child.Controls
                WireCardClick(subChild, tbl)
            Next
        Next

        Return card
    End Function

    Private Sub WireCardClick(ctrl As Control, tbl As RestaurantTableModel)
        AddHandler ctrl.Click, Sub(s, e) HandleTableSelected(tbl)
    End Sub

    ' =========================================================
    ' 4. معالجة اختيار الطاولة (نفس منطق POS الأصلي مع ميزات ذكية)
    ' =========================================================
    Private Sub HandleTableSelected(tbl As RestaurantTableModel)
        Dim displayName As String = If(Not String.IsNullOrWhiteSpace(tbl.TableName), tbl.TableName, "طاولة " & tbl.TableNumber)

        If tbl.TableStatus = 2 Then
            ' طاولة مشغولة
            Dim pending As PendingInvoiceModel = Nothing
            _activePendingMap.TryGetValue(tbl.TableID, pending)

            Dim amountStr = If(pending IsNot Nothing, $"إجمالي الحساب المفتوح: {pending.TotalAmount:N2} ج.م", "")
            Dim res As DialogResult = SmartMessageBox.Show(
                $"الطاولة ({displayName}) مشغولة حالياً وبها طلب مفتوح!" & vbCrLf &
                amountStr & vbCrLf & vbCrLf &
                "هل تريد فتح الطلب الحالي لإضافة أصناف أخرى أو إتمام وسداد الحساب؟",
                "طاولة مشغولة", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If res = DialogResult.No Then Return
            IsOccupiedSelected = True

        ElseIf tbl.TableStatus = 3 Then
            ' طاولة محجوزة
            Dim resv As TableReservationModel = Nothing
            _activeReservationMap.TryGetValue(tbl.TableID, resv)
            If resv Is Nothing Then resv = _repo.GetActiveReservationForTable(tbl.TableID)

            If resv IsNot Nothing Then
                Dim depStr = If(resv.DepositAmount > 0, $"{resv.DepositAmount:N2} ج.م", "بدون عربون")
                Dim msg = $"الطاولة ({displayName}) محجوزة للعميل:" & vbCrLf &
                          $"👤 العميل: {resv.CustomerName}" & vbCrLf &
                          $"📞 الهاتف: {resv.CustomerPhone}" & vbCrLf &
                          $"👥 عدد الأفراد: {resv.GuestCount}" & vbCrLf &
                          $"🕒 الموعد: {resv.ReservationDateTime:yyyy/MM/dd HH:mm}" & vbCrLf &
                          $"💰 العربون المدفوع: {depStr}" & vbCrLf & vbCrLf &
                          "هل تريد تسكين العميل الآن وبدء طلبه (مع خصم العربون تلقائياً من الفاتورة)؟"

                Dim dlgRes = SmartMessageBox.Show(msg, "تسكين حجز الطاولة", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dlgRes = DialogResult.No Then Return

                ' تحديث حالة الحجز إلى Seated وحالة الطاولة إلى مشغولة
                _repo.CheckInReservation(resv.ReservationID, tbl.TableID)
                ActiveReservation = resv
                HasActiveReservation = True
            End If
            IsOccupiedSelected = False
        Else
            IsOccupiedSelected = False
        End If

        SelectedTableID = tbl.TableID
        SelectedTableName = displayName

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' =========================================================
    ' 5. البحث السريع والفلترة الحية
    ' =========================================================
    Private Sub txtSearchTable_TextChanged(sender As Object, e As EventArgs) Handles txtSearchTable.TextChanged
        _searchTerm = txtSearchTable.Text
        RenderTableCards()
    End Sub

    Private Sub btnFilterAll_Click(sender As Object, e As EventArgs) Handles btnFilterAll.Click
        SetStatusFilter(0)
    End Sub

    Private Sub btnFilterFree_Click(sender As Object, e As EventArgs) Handles btnFilterFree.Click
        SetStatusFilter(1)
    End Sub

    Private Sub btnFilterOccupied_Click(sender As Object, e As EventArgs) Handles btnFilterOccupied.Click
        SetStatusFilter(2)
    End Sub

    Private Sub btnFilterReserved_Click(sender As Object, e As EventArgs) Handles btnFilterReserved.Click
        SetStatusFilter(3)
    End Sub

    Private Sub SetStatusFilter(status As Byte)
        _statusFilter = status
        UpdateFilterButtons()
        RenderTableCards()
    End Sub

    Private Sub UpdateFilterButtons()
        Dim activeColor = Color.FromArgb(59, 130, 246)
        Dim inactiveBg = Color.FromArgb(30, 41, 59)
        Dim inactiveFg = Color.FromArgb(148, 163, 184)

        btnFilterAll.FillColor = If(_statusFilter = 0, activeColor, inactiveBg)
        btnFilterAll.ForeColor = If(_statusFilter = 0, Color.White, inactiveFg)

        btnFilterFree.FillColor = If(_statusFilter = 1, Color.FromArgb(16, 185, 129), inactiveBg)
        btnFilterFree.ForeColor = If(_statusFilter = 1, Color.White, Color.FromArgb(167, 243, 208))

        btnFilterOccupied.FillColor = If(_statusFilter = 2, Color.FromArgb(239, 68, 68), inactiveBg)
        btnFilterOccupied.ForeColor = If(_statusFilter = 2, Color.White, Color.FromArgb(254, 202, 202))

        btnFilterReserved.FillColor = If(_statusFilter = 3, Color.FromArgb(245, 158, 11), inactiveBg)
        btnFilterReserved.ForeColor = If(_statusFilter = 3, Color.White, Color.FromArgb(253, 230, 138))
    End Sub

    Private Sub btnRefreshManual_Click(sender As Object, e As EventArgs) Handles btnRefreshManual.Click
        RefreshData()
        Try
            Notify.Toast("تم تحديث حالة طاولات الصالة لحظياً 🔄", Notify.ToastType.Success)
        Catch
        End Try
    End Sub

    Private Sub tmrLive_Tick(sender As Object, e As EventArgs) Handles tmrLive.Tick
        RefreshData()
    End Sub

    ' أزرار التحكم بالنافذة
    Private Sub btnCloseHeader_Click(sender As Object, e As EventArgs) Handles btnCloseHeader.Click, btnCancel.Click
        tmrLive.Stop()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnMaximizeHeader_Click(sender As Object, e As EventArgs) Handles btnMaximizeHeader.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            btnMaximizeHeader.Text = "🗖"
        Else
            Me.WindowState = FormWindowState.Maximized
            btnMaximizeHeader.Text = "🗗"
        End If
    End Sub

End Class
