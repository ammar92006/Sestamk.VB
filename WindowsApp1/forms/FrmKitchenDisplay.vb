Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Media
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Global.WindowsApp1
    Partial Class FrmKitchenDisplay

        Private ReadOnly _repo As POSRepository
        Private ReadOnly _displayedOrders As New Dictionary(Of Integer, OrderCardControl)()
        Private _soundEnabled As Boolean = True
        Private _isHistoryMode As Boolean = False
        Private _currentOrderTypeFilter As Byte = 0 ' 0 = الكل
        Private _currentStationFilter As String = "الكل"
        Private _isPolling As Boolean = False

        Public Sub New()
            _repo = New POSRepository(DBModule.ConnectionString)
            InitializeComponent()
            SetupEventHandlers()
        End Sub

        Private Sub SetupEventHandlers()
            AddHandler btnCloseForm.Click, Sub() Me.Close()
            AddHandler btnFullscreen.Click, AddressOf ToggleFullscreen
            AddHandler btnHistory.Click, AddressOf ToggleHistoryMode
            AddHandler btnSoundToggle.Click, AddressOf ToggleSound
            AddHandler btnRefresh.Click, Async Sub() Await LoadActiveOrdersAsync()

            AddHandler cmbOrderType.SelectedIndexChanged, Async Sub()
                                                              Select Case cmbOrderType.SelectedIndex
                                                                  Case 0 : _currentOrderTypeFilter = 0
                                                                  Case 1 : _currentOrderTypeFilter = 2 ' صالة
                                                                  Case 2 : _currentOrderTypeFilter = 1 ' تيك أوي
                                                                  Case 3 : _currentOrderTypeFilter = 3 ' دليفري
                                                                  Case Else : _currentOrderTypeFilter = 0
                                                              End Select
                                                              Await LoadActiveOrdersAsync()
                                                          End Sub

            AddHandler cmbStation.SelectedIndexChanged, Async Sub()
                                                            _currentStationFilter = cmbStation.Text
                                                            Await LoadActiveOrdersAsync()
                                                        End Sub

            AddHandler tmrSeconds.Tick, AddressOf OnSecondsTick
            AddHandler tmrPoll.Tick, Async Sub() Await PollNewOrdersAsync()

            ' استماع لتغييرات الثيم الحية
            AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged

            tmrSeconds.Start()
            tmrPoll.Start()

            ' دعم سحب النافذة عبر الهيدر
            Try
                Dim drag As New FormDragHelper(Me, panelHeader)
            Catch __logEx As Exception
                Logger.LogError("FrmKitchenDisplay.vb:62", __logEx)
            End Try
        End Sub

        Private Async Sub FrmKitchenDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ApplyTheme()
            UpdateClock()
            Await LoadActiveOrdersAsync()
        End Sub

        Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
            If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return
            If Me.InvokeRequired Then
                Me.BeginInvoke(New MethodInvoker(AddressOf ApplyTheme))
            Else
                ApplyTheme()
            End If
        End Sub

        ' =========================================================
        ' تطبيق ثيم النظام (فاتح / داكن) بدقة وجمالية
        ' =========================================================
        Public Sub ApplyTheme()
            Try
                Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
                Dim pal = ThemeManager.Instance.CurrentPalette

                If isDark Then
                    ' الثيم الداكن (Dark Theme)
                    Me.BackColor = pal.Background
                    flowOrders.BackColor = pal.Background
                    panelHeader.BackColor = pal.SurfaceHeader
                    pnlFilterContainer.BackColor = pal.SurfaceHeader
                    lblTitle.ForeColor = pal.TextOnDark
                    lblClock.ForeColor = pal.TextSecondary

                    ' الأزرار العلوية
                    Dim btnBg = pal.SurfaceSecondary
                    Dim btnFg = pal.TextPrimary
                    btnFullscreen.BackColor = btnBg : btnFullscreen.ForeColor = btnFg
                    btnHistory.BackColor = If(_isHistoryMode, pal.Warning, btnBg) : btnHistory.ForeColor = pal.TextOnPrimary
                    btnSoundToggle.BackColor = If(_soundEnabled, btnBg, pal.DangerSubtleBackground) : btnSoundToggle.ForeColor = If(_soundEnabled, btnFg, pal.DangerSubtleForeground)
                    btnRefresh.BackColor = btnBg : btnRefresh.ForeColor = btnFg

                    ' فلاتر البحث
                    cmbOrderType.FillColor = pal.InputBackground
                    cmbOrderType.BorderColor = pal.InputBorder
                    cmbOrderType.ForeColor = pal.InputForeground
                    cmbStation.FillColor = pal.InputBackground
                    cmbStation.BorderColor = pal.InputBorder
                    cmbStation.ForeColor = pal.InputForeground
                    lblFilterType.ForeColor = pal.TextSecondary
                    lblFilterStation.ForeColor = pal.TextSecondary

                    lblEmptyNotice.ForeColor = pal.TextMuted
                Else
                    ' الثيم الفاتح (Light Theme)
                    Me.BackColor = pal.BackgroundSecondary
                    flowOrders.BackColor = pal.BackgroundSecondary
                    panelHeader.BackColor = pal.Surface
                    pnlFilterContainer.BackColor = pal.Surface
                    lblTitle.ForeColor = pal.TextPrimary
                    lblClock.ForeColor = pal.TextSecondary

                    ' الأزرار العلوية
                    Dim btnBg = pal.SurfaceSecondary
                    Dim btnFg = pal.TextPrimary
                    btnFullscreen.BackColor = btnBg : btnFullscreen.ForeColor = btnFg
                    btnHistory.BackColor = If(_isHistoryMode, pal.Warning, btnBg) : btnHistory.ForeColor = If(_isHistoryMode, pal.WarningText, btnFg)
                    btnSoundToggle.BackColor = If(_soundEnabled, btnBg, pal.DangerSubtleBackground) : btnSoundToggle.ForeColor = If(_soundEnabled, btnFg, pal.DangerSubtleForeground)
                    btnRefresh.BackColor = btnBg : btnRefresh.ForeColor = btnFg

                    ' فلاتر البحث
                    cmbOrderType.FillColor = pal.InputBackground
                    cmbOrderType.BorderColor = pal.InputBorder
                    cmbOrderType.ForeColor = pal.InputForeground
                    cmbStation.FillColor = pal.InputBackground
                    cmbStation.BorderColor = pal.InputBorder
                    cmbStation.ForeColor = pal.InputForeground
                    lblFilterType.ForeColor = pal.TextSecondary
                    lblFilterStation.ForeColor = pal.TextSecondary

                    lblEmptyNotice.ForeColor = pal.TextMuted
                End If

                ' تحديث كل البطاقات المعروضة
                For Each card In _displayedOrders.Values
                    card.ApplyTheme(isDark)
                Next
            Catch ex As Exception
                Logger.LogError("FrmKitchenDisplay.ApplyTheme", ex)
            End Try
        End Sub

        Private Sub UpdateClock()
            Dim now = DateTime.Now
            Dim ampm = If(now.Hour >= 12, "م", "ص")
            Dim hour12 = now.ToString("hh")
            lblClock.Text = $"{hour12}:{now:mm:ss} {ampm}"
        End Sub

        ' =========================================================
        ' تحميل وعرض الطلبات النشطة
        ' =========================================================
        Private Async Function LoadActiveOrdersAsync() As Task
            If _isHistoryMode Then
                Await LoadHistoryOrdersAsync()
                Return
            End If

            Try
                Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
                Dim orders = Await Task.Run(Function() _repo.GetActiveKitchenOrders(_currentOrderTypeFilter, _currentStationFilter))
                flowOrders.SuspendLayout()
                flowOrders.Controls.Clear()
                _displayedOrders.Clear()

                If orders Is Nothing OrElse orders.Count = 0 Then
                    lblEmptyNotice.Visible = True
                    lblActiveCountBadge.Text = "0 طلبات نشطة"
                    lblDelayedBadge.Visible = False
                Else
                    lblEmptyNotice.Visible = False
                    lblActiveCountBadge.Text = orders.Count & " طلبات نشطة"

                    Dim delayedCount As Integer = 0
                    For Each order In orders
                        Dim card = CreateOrderCard(order, isHistory:=False, isDark:=isDark)
                        _displayedOrders(order.KitchenOrderID) = card
                        flowOrders.Controls.Add(card)
                        If order.IsOverdue Then
                            delayedCount += 1
                        End If
                    Next

                    If delayedCount > 0 Then
                        lblDelayedBadge.Text = delayedCount & " متأخرة"
                        lblDelayedBadge.Visible = True
                    Else
                        lblDelayedBadge.Visible = False
                    End If
                End If
            Catch ex As Exception
                Logger.LogError("LoadActiveOrdersAsync", ex)
            Finally
                flowOrders.ResumeLayout()
            End Try
        End Function

        ' =========================================================
        ' الاستعلام الدوري (Background Polling) لإضافة أوردرات جديدة
        ' =========================================================
        Private Async Function PollNewOrdersAsync() As Task
            If _isPolling OrElse _isHistoryMode Then Return
            _isPolling = True
            Try
                Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
                Dim latestOrders = Await Task.Run(Function() _repo.GetActiveKitchenOrders(_currentOrderTypeFilter, _currentStationFilter))
                If latestOrders Is Nothing Then Return

                Dim latestIds As New HashSet(Of Integer)(latestOrders.Select(Function(x) x.KitchenOrderID))
                Dim currentDisplayedIds As New List(Of Integer)(_displayedOrders.Keys)

                ' 1. حذف البطاقات التي تم تسليمها أو إلغاؤها من طرف آخر
                For Each id In currentDisplayedIds
                    If Not latestIds.Contains(id) Then
                        If _displayedOrders.ContainsKey(id) Then
                            Dim cardToRemove = _displayedOrders(id)
                            flowOrders.Controls.Remove(cardToRemove)
                            cardToRemove.Dispose()
                            _displayedOrders.Remove(id)
                        End If
                    End If
                Next

                ' 2. إضافة الأوردرات الجديدة التي لم تكن معروضة
                Dim hasNewOrder As Boolean = False
                For Each order In latestOrders
                    If Not _displayedOrders.ContainsKey(order.KitchenOrderID) Then
                        Dim newCard = CreateOrderCard(order, isHistory:=False, isDark:=isDark)
                        _displayedOrders(order.KitchenOrderID) = newCard
                        flowOrders.Controls.Add(newCard)
                        hasNewOrder = True
                    End If
                Next

                If hasNewOrder AndAlso _soundEnabled Then
                    PlayNotificationSound()
                End If

                ' تحديث شارات العدد
                UpdateOrderBadges()
            Catch ex As Exception
                Debug.WriteLine("PollNewOrdersAsync error: " & ex.Message)
            Finally
                _isPolling = False
            End Try
        End Function

        Private Sub UpdateOrderBadges()
            If _displayedOrders.Count = 0 Then
                lblEmptyNotice.Visible = True
                lblActiveCountBadge.Text = "0 طلبات نشطة"
                lblDelayedBadge.Visible = False
            Else
                lblEmptyNotice.Visible = False
                lblActiveCountBadge.Text = _displayedOrders.Count & " طلبات نشطة"

                Dim delayedCount = _displayedOrders.Values.Where(Function(c) c.Order.IsOverdue).Count()
                If delayedCount > 0 Then
                    lblDelayedBadge.Text = delayedCount & " متأخرة"
                    lblDelayedBadge.Visible = True
                Else
                    lblDelayedBadge.Visible = False
                End If
            End If
        End Sub

        ' =========================================================
        ' مؤقت الثواني لتحديث العدادات والساعة الحية
        ' =========================================================
        Private Sub OnSecondsTick(sender As Object, e As EventArgs)
            UpdateClock()
            If _isHistoryMode Then Return

            Dim delayedCount As Integer = 0
            For Each kvp In _displayedOrders
                kvp.Value.UpdateTimerUI()
                If kvp.Value.Order.IsOverdue Then
                    delayedCount += 1
                End If
            Next

            If delayedCount > 0 Then
                lblDelayedBadge.Text = delayedCount & " متأخرة"
                lblDelayedBadge.Visible = True
            Else
                lblDelayedBadge.Visible = False
            End If
        End Sub

        ' =========================================================
        ' إنشاء بطاقة الطلب (Order Card Control)
        ' =========================================================
        Private Function CreateOrderCard(order As KitchenOrderModel, isHistory As Boolean, isDark As Boolean) As OrderCardControl
            Dim card As New OrderCardControl(order, _repo, isHistory, isDark)
            AddHandler card.OrderBumped, Sub(orderId)
                                             If _displayedOrders.ContainsKey(orderId) Then
                                                 Dim c = _displayedOrders(orderId)
                                                 flowOrders.Controls.Remove(c)
                                                 c.Dispose()
                                                 _displayedOrders.Remove(orderId)
                                                 UpdateOrderBadges()
                                             End If
                                         End Sub
            AddHandler card.OrderRecalled, Async Sub(orderId)
                                               Await LoadActiveOrdersAsync()
                                           End Sub
            Return card
        End Function

        ' =========================================================
        ' عرض الطلبات المنتهية مؤخراً (Recall Mode)
        ' =========================================================
        Private Async Function LoadHistoryOrdersAsync() As Task
            Try
                Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
                Dim orders = Await Task.Run(Function() _repo.GetRecentBumpedOrders(30))
                flowOrders.SuspendLayout()
                flowOrders.Controls.Clear()
                _displayedOrders.Clear()

                If orders Is Nothing OrElse orders.Count = 0 Then
                    lblEmptyNotice.Text = "لا توجد طلبات منتهية مؤخراً في الأرشيف"
                    lblEmptyNotice.Visible = True
                    lblActiveCountBadge.Text = "أرشيف الطلبات"
                    lblDelayedBadge.Visible = False
                Else
                    lblEmptyNotice.Visible = False
                    lblActiveCountBadge.Text = orders.Count & " طلبات مسلّمة"
                    lblDelayedBadge.Visible = False
                    For Each order In orders
                        Dim card = CreateOrderCard(order, isHistory:=True, isDark:=isDark)
                        flowOrders.Controls.Add(card)
                    Next
                End If
            Catch ex As Exception
                Logger.LogError("LoadHistoryOrdersAsync", ex)
            Finally
                flowOrders.ResumeLayout()
            End Try
        End Function

        Private Async Sub ToggleHistoryMode(sender As Object, e As EventArgs)
            _isHistoryMode = Not _isHistoryMode
            Dim isDark = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
            If _isHistoryMode Then
                btnHistory.Text = "العودة للنشطة"
                btnHistory.BackColor = Color.FromArgb(180, 83, 9)
                btnHistory.ForeColor = Color.White
                lblTitle.Text = "أرشيف طلبات المطبخ المنتهية"
                pnlFilterContainer.Visible = False
                Await LoadHistoryOrdersAsync()
            Else
                btnHistory.Text = "الأرشيف (Recall)"
                btnHistory.BackColor = If(isDark, Color.FromArgb(55, 65, 81), Color.FromArgb(241, 245, 249))
                btnHistory.ForeColor = If(isDark, Color.White, Color.FromArgb(30, 41, 59))
                lblTitle.Text = "شاشة المطبخ (KDS)"
                pnlFilterContainer.Visible = True
                lblEmptyNotice.Text = "لا توجد طلبات نشطة في المطبخ حالياً" & vbCrLf & "سيتم عرض الطلبات الجديدة تلقائياً فور تسجيلها من الكاشير"
                Await LoadActiveOrdersAsync()
            End If
        End Sub

        Private Sub ToggleSound(sender As Object, e As EventArgs)
            _soundEnabled = Not _soundEnabled
            Dim isDark = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
            If _soundEnabled Then
                btnSoundToggle.Text = "🔔 الصوت"
                btnSoundToggle.BackColor = If(isDark, Color.FromArgb(55, 65, 81), Color.FromArgb(241, 245, 249))
                btnSoundToggle.ForeColor = If(isDark, Color.White, Color.FromArgb(30, 41, 59))
            Else
                btnSoundToggle.Text = "🔕 كتم الصوت"
                btnSoundToggle.BackColor = If(isDark, Color.FromArgb(120, 30, 30), Color.FromArgb(254, 226, 226))
                btnSoundToggle.ForeColor = If(isDark, Color.White, Color.FromArgb(185, 28, 28))
            End If
        End Sub

        Private Sub ToggleFullscreen(sender As Object, e As EventArgs)
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
                btnFullscreen.Text = "⛶ تكبير"
            Else
                Me.WindowState = FormWindowState.Maximized
                btnFullscreen.Text = "🗗 استعادة"
            End If
        End Sub

        Private Sub PlayNotificationSound()
            Try
                SystemSounds.Asterisk.Play()
            Catch __logEx As Exception
                Logger.LogError("FrmKitchenDisplay.vb:404", __logEx)
            End Try
        End Sub

        Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
            tmrSeconds.Stop()
            tmrPoll.Stop()
            RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
            MyBase.OnFormClosing(e)
        End Sub
    End Class

    ' =========================================================
    ' بطاقة الطلب التفاعلية الاحترافية (OrderCardControl)
    ' =========================================================
    Public Class OrderCardControl
        Inherits Panel

        Public ReadOnly Order As KitchenOrderModel
        Private ReadOnly _repo As POSRepository
        Private ReadOnly _isHistory As Boolean
        Private _isDark As Boolean = True

        Public Event OrderBumped(orderId As Integer)
        Public Event OrderRecalled(orderId As Integer)

        ' عناصر الهيدر العلوي
        Private pnlTopSection As Panel
        Private pnlTypeBanner As Panel
        Private lblTypeBadge As Label
        Private lblTablePill As Label
        Private lblCustomer As Label

        ' تفاصيل الطلب والتوقيت
        Private pnlHeader As Panel
        Private pnlHeaderRow1 As Panel
        Private pnlHeaderRow2 As Panel
        Private lblOrderNum As Label
        Private lblExpectedTime As Label
        Private lblTimer As Label
        Private lblServerTime As Label
        Private lblOverdueStatus As Label

        ' قائمة الأصناف
        Private pnlItemsList As Panel
        Private pnlBottom As Panel
        Private btnAction As Button
        Private _itemRows As New List(Of ItemRowWrapper)()

        Private Class ItemRowWrapper
            Public Property PanelRow As Panel
            Public Property LblQty As Label
            Public Property LblName As Label
            Public Property ChkDone As CheckBox
            Public Property Item As KitchenOrderItemModel
        End Class

        Public Sub New(order As KitchenOrderModel, repo As POSRepository, isHistory As Boolean, isDark As Boolean)
            Me.Order = order
            Me._repo = repo
            Me._isHistory = isHistory
            Me._isDark = isDark

            InitializeCard()
        End Sub

        Private Sub InitializeCard()
            Me.Width = 330
            Me.Margin = New Padding(8)
            Me.RightToLeft = RightToLeft.Yes

            ' ─────────────────────────────────────────────────────────
            ' 1. الحاوية العلوية (Top Section: شريط نوع الطلب + هيدر التوقيت)
            ' ─────────────────────────────────────────────────────────
            pnlTopSection = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 84,
                .BackColor = Color.Transparent
            }

            ' أ) شريط نوع الطلب والوجهة (Type & Destination Banner)
            pnlTypeBanner = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 34,
                .Padding = New Padding(8, 4, 8, 4)
            }

            ' تحديد لون وهوية شريط نوع الطلب
            Select Case Order.OrderType
                Case 2 ' صالة (Dine-In)
                    pnlTypeBanner.BackColor = Color.FromArgb(79, 70, 229) ' Royal Indigo
                Case 1 ' تيك أوي (Takeaway)
                    pnlTypeBanner.BackColor = Color.FromArgb(13, 148, 136) ' Teal / Emerald
                Case 3 ' دليفري (Delivery)
                    pnlTypeBanner.BackColor = Color.FromArgb(234, 88, 12) ' Warm Orange
                Case Else
                    pnlTypeBanner.BackColor = Color.FromArgb(71, 85, 105)
            End Select

            ' اسم العميل (على اليسار) إن وجد
            lblCustomer = New Label With {
                .Dock = DockStyle.Left,
                .AutoSize = False,
                .Width = 140,
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(248, 250, 252),
                .TextAlign = ContentAlignment.MiddleLeft,
                .AutoEllipsis = True
            }
            If Not String.IsNullOrWhiteSpace(Order.CustomerName) AndAlso Order.CustomerName.Trim() <> "عميل نقدي" Then
                lblCustomer.Text = $"👤 {Order.CustomerName.Trim()}"
            Else
                lblCustomer.Text = ""
            End If
            pnlTypeBanner.Controls.Add(lblCustomer)

            ' شارة الطاولة لعميل الصالة
            lblTablePill = New Label With {
                .Dock = DockStyle.Right,
                .AutoSize = True,
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(254, 240, 138), ' Yellow / Gold highlight
                .TextAlign = ContentAlignment.MiddleRight
            }
            If Order.OrderType = 2 AndAlso Not String.IsNullOrWhiteSpace(Order.TableName) Then
                lblTablePill.Text = $" | طاولة: {Order.TableName.Trim()}"
            Else
                lblTablePill.Text = ""
            End If
            pnlTypeBanner.Controls.Add(lblTablePill)

            ' نوع الطلب (على اليمين)
            lblTypeBadge = New Label With {
                .Dock = DockStyle.Right,
                .AutoSize = True,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .TextAlign = ContentAlignment.MiddleRight
            }
            Select Case Order.OrderType
                Case 2 : lblTypeBadge.Text = "🍽️ صالة"
                Case 1 : lblTypeBadge.Text = "🛍️ سفري (تيك أوي)"
                Case 3 : lblTypeBadge.Text = "🛵 دليفري (توصيل)"
                Case Else : lblTypeBadge.Text = "طلب محلي"
            End Select
            pnlTypeBanner.Controls.Add(lblTypeBadge)

            pnlTopSection.Controls.Add(pnlTypeBanner)

            ' ب) هيدر رقم الطلب والعداد والوقت المتوقع
            pnlHeader = New Panel With {
                .Dock = DockStyle.Fill,
                .Padding = New Padding(8, 4, 8, 4)
            }

            ' الصف الأول من الهيدر (رقم الطلب يمين، العداد والوقت المتوقع يسار)
            pnlHeaderRow1 = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 26,
                .BackColor = Color.Transparent
            }

            lblTimer = New Label With {
                .Dock = DockStyle.Left,
                .Width = 80,
                .Text = If(_isHistory, "منجز ✓", Order.ElapsedFormatted),
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(45, 0, 0, 0),
                .TextAlign = ContentAlignment.MiddleCenter
            }
            pnlHeaderRow1.Controls.Add(lblTimer)

            lblExpectedTime = New Label With {
                .Dock = DockStyle.Left,
                .Width = 72,
                .Text = $"⏱️ {Order.EstimatedPrepFormatted}",
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(226, 232, 240),
                .BackColor = Color.FromArgb(30, 0, 0, 0),
                .TextAlign = ContentAlignment.MiddleCenter
            }
            pnlHeaderRow1.Controls.Add(lblExpectedTime)

            lblOrderNum = New Label With {
                .Dock = DockStyle.Fill,
                .Text = $"طلب #{Order.OrderNumber}",
                .Font = New Font("Segoe UI", 11.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .TextAlign = ContentAlignment.MiddleRight,
                .AutoEllipsis = True
            }
            pnlHeaderRow1.Controls.Add(lblOrderNum)
            pnlHeader.Controls.Add(pnlHeaderRow1)

            ' الصف الثاني من الهيدر (حالة التأخير يسار، الكاشير ووقت التسجيل يمين)
            pnlHeaderRow2 = New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 20,
                .BackColor = Color.Transparent
            }

            lblOverdueStatus = New Label With {
                .Dock = DockStyle.Left,
                .Width = 110,
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(239, 68, 68),
                .TextAlign = ContentAlignment.MiddleLeft,
                .AutoEllipsis = True,
                .Visible = False
            }
            pnlHeaderRow2.Controls.Add(lblOverdueStatus)

            Dim cashierText = If(String.IsNullOrEmpty(Order.ServerName), $"{Order.CreatedAt:HH:mm}", $"{Order.CreatedAt:HH:mm} | {Order.ServerName}")
            lblServerTime = New Label With {
                .Dock = DockStyle.Fill,
                .Text = cashierText,
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(203, 213, 225),
                .TextAlign = ContentAlignment.MiddleRight,
                .AutoEllipsis = True
            }
            pnlHeaderRow2.Controls.Add(lblServerTime)
            pnlHeader.Controls.Add(pnlHeaderRow2)

            pnlTopSection.Controls.Add(pnlHeader)
            pnlTypeBanner.BringToFront()

            ' ─────────────────────────────────────────────────────────
            ' 2. قائمة الأصناف (Items List)
            ' ─────────────────────────────────────────────────────────
            pnlItemsList = New Panel With {
                .Dock = DockStyle.Top,
                .AutoSize = True,
                .Padding = New Padding(8, 6, 8, 6)
            }

            Dim yPos As Integer = 6
            _itemRows.Clear()

            For Each item In Order.Items
                Dim currentItem = item
                Dim pnlRow As New Panel With {
                    .Width = 314,
                    .Location = New Point(8, yPos),
                    .Margin = New Padding(0, 0, 0, 4)
                }

                ' مربع الاختيار لإتمام الصنف (على اليسار)
                Dim chkDone As New CheckBox With {
                    .Checked = currentItem.IsCompleted,
                    .Size = New Size(22, 22),
                    .Location = New Point(6, 5),
                    .Cursor = Cursors.Hand
                }
                pnlRow.Controls.Add(chkDone)

                ' شارة الكمية (على اليمين 1x أو 2x)
                Dim lblQty As New Label With {
                    .Text = $"{currentItem.Quantity}x",
                    .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Size = New Size(34, 24),
                    .Location = New Point(274, 4)
                }
                pnlRow.Controls.Add(lblQty)

                ' اسم الصنف مع وقت تحضيره الفردي إن وجد
                Dim displayName As String = currentItem.ProductName
                If currentItem.PrepMinutes > 0 Then
                    displayName &= $" (⏱️ {currentItem.PrepMinutes}د)"
                End If

                Dim lblItemName As New Label With {
                    .Text = displayName,
                    .Font = If(currentItem.IsCompleted, New Font("Segoe UI", 9.5F, FontStyle.Strikeout), New Font("Segoe UI", 9.5F, FontStyle.Bold)),
                    .Location = New Point(32, 4),
                    .Size = New Size(238, 24),
                    .TextAlign = ContentAlignment.MiddleRight,
                    .AutoEllipsis = True
                }
                pnlRow.Controls.Add(lblItemName)

                Dim subY As Integer = 28

                ' الحجم (فقط إذا لم يكن فارغاً أو "-")
                Dim hasSize = Not String.IsNullOrWhiteSpace(currentItem.SizeName) AndAlso currentItem.SizeName.Trim() <> "-"
                If hasSize Then
                    Dim lblSize As New Label With {
                        .Text = "الحجم: " & currentItem.SizeName.Trim(),
                        .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                        .ForeColor = Color.FromArgb(100, 116, 139),
                        .Location = New Point(32, subY),
                        .Size = New Size(238, 18),
                        .TextAlign = ContentAlignment.MiddleRight,
                        .AutoEllipsis = True
                    }
                    pnlRow.Controls.Add(lblSize)
                    subY += 18
                End If

                ' الإضافات (فقط إذا لم تكن فارغة أو "-")
                Dim hasAddons = Not String.IsNullOrWhiteSpace(currentItem.AddonsText) AndAlso currentItem.AddonsText.Trim() <> "-" AndAlso currentItem.AddonsText.Trim() <> "+"
                If hasAddons Then
                    Dim lblAddons As New Label With {
                        .Text = "+ " & currentItem.AddonsText.Trim(),
                        .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                        .ForeColor = Color.FromArgb(217, 119, 6),
                        .Location = New Point(32, subY),
                        .Size = New Size(238, 18),
                        .TextAlign = ContentAlignment.MiddleRight,
                        .AutoEllipsis = True
                    }
                    pnlRow.Controls.Add(lblAddons)
                    subY += 18
                End If

                ' الملاحظات الخاصة بالصنف
                Dim hasNotes = Not String.IsNullOrWhiteSpace(currentItem.Notes) AndAlso currentItem.Notes.Trim() <> "-"
                If hasNotes Then
                    Dim lblNotes As New Label With {
                        .Text = "ملاحظة: " & currentItem.Notes.Trim(),
                        .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                        .ForeColor = Color.FromArgb(220, 38, 38),
                        .Location = New Point(32, subY),
                        .Size = New Size(238, 18),
                        .TextAlign = ContentAlignment.MiddleRight,
                        .AutoEllipsis = True
                    }
                    pnlRow.Controls.Add(lblNotes)
                    subY += 19
                End If

                pnlRow.Height = subY + 6

                ' حفظ المرجع لتحديث ألوان الثيم
                Dim wrapper As New ItemRowWrapper With {
                    .PanelRow = pnlRow,
                    .LblQty = lblQty,
                    .LblName = lblItemName,
                    .ChkDone = chkDone,
                    .Item = currentItem
                }
                _itemRows.Add(wrapper)

                ' تفاعل النقر على مربع الإنجاز
                AddHandler chkDone.CheckedChanged, Sub()
                                                       currentItem.IsCompleted = chkDone.Checked
                                                       UpdateRowCompletedUI(wrapper)
                                                       Task.Run(Sub() _repo.ToggleKitchenItemStatus(currentItem.DetailID, chkDone.Checked))
                                                   End Sub

                pnlItemsList.Controls.Add(pnlRow)
                yPos += pnlRow.Height + 4
            Next

            ' ملاحظات الطلب العامة
            If Not String.IsNullOrEmpty(Order.Notes) Then
                Dim pnlNotes As New Panel With {
                    .Width = 314,
                    .Location = New Point(8, yPos),
                    .BackColor = If(_isDark, Color.FromArgb(39, 32, 20), Color.FromArgb(254, 243, 199)),
                    .Padding = New Padding(6)
                }
                Dim lblOrderNotes As New Label With {
                    .Text = "📌 ملاحظة: " & Order.Notes,
                    .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                    .ForeColor = If(_isDark, Color.FromArgb(252, 211, 77), Color.FromArgb(180, 83, 9)),
                    .AutoSize = True,
                    .Location = New Point(6, 4)
                }
                pnlNotes.Controls.Add(lblOrderNotes)
                pnlNotes.Height = lblOrderNotes.Height + 10
                pnlItemsList.Controls.Add(pnlNotes)
                yPos += pnlNotes.Height + 4
            End If

            pnlItemsList.Height = yPos + 6

            ' ─────────────────────────────────────────────────────────
            ' 3. أزرار التحكم بالبطاقة في الأسفل (Bump / Recall)
            ' ─────────────────────────────────────────────────────────
            pnlBottom = New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 46,
                .Padding = New Padding(8, 5, 8, 5)
            }

            If _isHistory Then
                btnAction = New Button With {
                    .Text = "↩ استرجاع للتحضير (Recall)",
                    .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                    .ForeColor = Color.White,
                    .BackColor = Color.FromArgb(180, 83, 9),
                    .FlatStyle = FlatStyle.Flat,
                    .Dock = DockStyle.Fill,
                    .Cursor = Cursors.Hand
                }
                btnAction.FlatAppearance.BorderSize = 0
                AddHandler btnAction.Click, Sub()
                                                If _repo.RecallKitchenOrder(Order.KitchenOrderID) Then
                                                    RaiseEvent OrderRecalled(Order.KitchenOrderID)
                                                End If
                                            End Sub
                pnlBottom.Controls.Add(btnAction)
            Else
                btnAction = New Button With {
                    .Text = "✓ إتمام وتسليم الطلب (Bump)",
                    .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                    .ForeColor = Color.White,
                    .BackColor = Color.FromArgb(5, 150, 105),
                    .FlatStyle = FlatStyle.Flat,
                    .Dock = DockStyle.Fill,
                    .Cursor = Cursors.Hand
                }
                btnAction.FlatAppearance.BorderSize = 0
                AddHandler btnAction.Click, Sub()
                                                If _repo.UpdateKitchenOrderStatus(Order.KitchenOrderID, KitchenOrderStatus.Bumped) Then
                                                    RaiseEvent OrderBumped(Order.KitchenOrderID)
                                                End If
                                            End Sub
                pnlBottom.Controls.Add(btnAction)
            End If

            ' 4. إضافة الحاويات للبطاقة بالترتيب الرأسي السليم
            Me.Controls.Add(pnlItemsList)
            Me.Controls.Add(pnlBottom)
            Me.Controls.Add(pnlTopSection)

            pnlTopSection.SendToBack()
            pnlBottom.SendToBack()

            ApplyTheme(_isDark)
            UpdateHeaderColor()
            Me.Height = pnlTopSection.Height + pnlItemsList.Height + pnlBottom.Height + 6
        End Sub

        Private Sub UpdateRowCompletedUI(wrapper As ItemRowWrapper)
            If wrapper.ChkDone.Checked Then
                wrapper.LblName.Font = New Font("Segoe UI", 9.5F, FontStyle.Strikeout)
                If _isDark Then
                    wrapper.LblName.ForeColor = Color.FromArgb(100, 116, 139)
                    wrapper.PanelRow.BackColor = Color.FromArgb(20, 24, 32)
                    wrapper.LblQty.BackColor = Color.FromArgb(28, 34, 44)
                    wrapper.LblQty.ForeColor = Color.FromArgb(148, 163, 184)
                Else
                    wrapper.LblName.ForeColor = Color.FromArgb(148, 163, 184)
                    wrapper.PanelRow.BackColor = Color.FromArgb(241, 245, 249)
                    wrapper.LblQty.BackColor = Color.FromArgb(226, 232, 240)
                    wrapper.LblQty.ForeColor = Color.FromArgb(100, 116, 139)
                End If
            Else
                wrapper.LblName.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
                If _isDark Then
                    wrapper.LblName.ForeColor = Color.White
                    wrapper.PanelRow.BackColor = Color.FromArgb(34, 40, 52)
                    wrapper.LblQty.BackColor = Color.FromArgb(51, 65, 85)
                    wrapper.LblQty.ForeColor = Color.White
                Else
                    wrapper.LblName.ForeColor = Color.FromArgb(15, 23, 42)
                    wrapper.PanelRow.BackColor = Color.White
                    wrapper.LblQty.BackColor = Color.FromArgb(226, 232, 240)
                    wrapper.LblQty.ForeColor = Color.FromArgb(15, 23, 42)
                End If
            End If
        End Sub

        Public Sub ApplyTheme(isDark As Boolean)
            _isDark = isDark
            If isDark Then
                Me.BackColor = Color.FromArgb(31, 41, 55)
                pnlItemsList.BackColor = Color.FromArgb(17, 24, 39)
                pnlBottom.BackColor = Color.FromArgb(17, 24, 39)
            Else
                Me.BackColor = Color.White
                pnlItemsList.BackColor = Color.FromArgb(248, 250, 252)
                pnlBottom.BackColor = Color.FromArgb(248, 250, 252)
            End If

            For Each wrapper In _itemRows
                UpdateRowCompletedUI(wrapper)
            Next

            UpdateHeaderColor()
            Me.Invalidate()
        End Sub

        Public Sub UpdateTimerUI()
            If _isHistory Then Return
            UpdateHeaderColor()
        End Sub

        Private Sub UpdateHeaderColor()
            If _isHistory Then
                pnlHeader.BackColor = If(_isDark, Color.FromArgb(45, 55, 72), Color.FromArgb(241, 245, 249))
                lblTimer.BackColor = Color.FromArgb(75, 85, 99)
                lblTimer.ForeColor = Color.White
                lblTimer.Text = "منجز ✓"
                lblExpectedTime.Text = $"⏱️ {Order.EstimatedPrepFormatted}"
                lblOverdueStatus.Visible = False
                Return
            End If

            lblExpectedTime.Text = $"⏱️ {Order.EstimatedPrepFormatted}"

            If Order.IsOverdue Then
                ' 🔴 متأخر عن وقت التحضير المتوقع
                lblTimer.BackColor = Color.FromArgb(220, 38, 38)
                lblTimer.ForeColor = Color.White
                lblTimer.Text = $"{Order.ElapsedFormatted} ⚠️"
                pnlHeader.BackColor = If(_isDark, Color.FromArgb(69, 10, 10), Color.FromArgb(254, 226, 226))
                lblOrderNum.ForeColor = If(_isDark, Color.FromArgb(254, 202, 202), Color.FromArgb(185, 28, 28))
                lblOverdueStatus.Text = $"متأخر (+{Order.OverdueMinutes}د)"
                lblOverdueStatus.ForeColor = Color.FromArgb(239, 68, 68)
                lblOverdueStatus.Visible = True
            ElseIf Order.PrepProgressRatio >= 0.75 Then
                ' 🟠 اقتراب مهلة التحضير (>75%)
                lblTimer.BackColor = Color.FromArgb(217, 119, 6)
                lblTimer.ForeColor = Color.White
                lblTimer.Text = Order.ElapsedFormatted
                pnlHeader.BackColor = If(_isDark, Color.FromArgb(67, 34, 4), Color.FromArgb(254, 243, 199))
                lblOrderNum.ForeColor = If(_isDark, Color.FromArgb(253, 230, 138), Color.FromArgb(180, 83, 9))
                lblOverdueStatus.Text = "اقتراب المهلة"
                lblOverdueStatus.ForeColor = Color.FromArgb(245, 158, 11)
                lblOverdueStatus.Visible = True
            Else
                ' 🟢 في الوقت الطبيعي المتوقع
                lblTimer.BackColor = Color.FromArgb(5, 150, 105)
                lblTimer.ForeColor = Color.White
                lblTimer.Text = Order.ElapsedFormatted
                pnlHeader.BackColor = If(_isDark, Color.FromArgb(6, 44, 34), Color.FromArgb(209, 250, 229))
                lblOrderNum.ForeColor = If(_isDark, Color.FromArgb(167, 243, 208), Color.FromArgb(6, 95, 70))
                lblOverdueStatus.Text = "في الموعد"
                lblOverdueStatus.ForeColor = Color.FromArgb(16, 185, 129)
                lblOverdueStatus.Visible = False
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim borderColor = If(_isDark, Color.FromArgb(55, 65, 81), Color.FromArgb(203, 213, 225))
            Using p As New Pen(borderColor, 1)
                e.Graphics.DrawRectangle(p, 0, 0, Me.Width - 1, Me.Height - 1)
            End Using
        End Sub
    End Class
End Namespace
