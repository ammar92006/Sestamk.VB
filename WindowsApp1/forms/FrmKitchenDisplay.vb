Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Media
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

Namespace Global.WindowsApp1
    Public Class FrmKitchenDisplay
        Inherits Form

        Private ReadOnly _repo As POSRepository
        Private ReadOnly _displayedOrders As New Dictionary(Of Integer, OrderCardControl)()
        Private _soundEnabled As Boolean = True
        Private _isHistoryMode As Boolean = False
        Private _currentOrderTypeFilter As Byte = 0 ' 0 = الكل
        Private _currentStationFilter As String = "الكل"

        ' أدوات واجهة المستخدم
        Private panelHeader As Panel
        Private lblTitle As Label
        Private lblActiveCountBadge As Label
        Private pnlFilterContainer As Panel
        Private flowOrders As FlowLayoutPanel
        Private btnSoundToggle As Button
        Private btnRefresh As Button
        Private btnHistory As Button
        Private btnFullscreen As Button
        Private btnCloseForm As Button
        Private cmbOrderType As ComboBox
        Private cmbStation As ComboBox
        Private lblEmptyNotice As Label

        Private tmrSeconds As Timer
        Private tmrPoll As Timer
        Private _isPolling As Boolean = False

        Public Sub New()
            _repo = New POSRepository(DBModule.ConnectionString)
            InitializeComponentsCustom()
        End Sub

        Private Sub InitializeComponentsCustom()
            Me.Text = "شاشة المطبخ الذكية (KDS) - نظام إدارة المطاعم"
            Me.ClientSize = New Size(1200, 750)
            Me.MinimumSize = New Size(900, 600)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.FormBorderStyle = FormBorderStyle.None
            Me.RightToLeft = RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.BackColor = Color.FromArgb(24, 26, 31)
            Me.ForeColor = Color.White
            Me.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)

            ' 1. الهيدر العلوي
            panelHeader = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 70,
                .BackColor = Color.FromArgb(32, 35, 42),
                .Padding = New Padding(15, 10, 15, 10)
            }

            lblTitle = New Label With {
                .Text = "🍳 شاشة المطبخ الرقمية (KDS)",
                .Font = New Font("Segoe UI", 15.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(240, 243, 246),
                .AutoSize = True,
                .Location = New Point(15, 18)
            }
            panelHeader.Controls.Add(lblTitle)

            lblActiveCountBadge = New Label With {
                .Text = "0 طلبات قيد التحضير",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(16, 185, 129),
                .BackColor = Color.FromArgb(16, 45, 35),
                .Padding = New Padding(8, 4, 8, 4),
                .AutoSize = True,
                .Location = New Point(320, 18)
            }
            panelHeader.Controls.Add(lblActiveCountBadge)

            ' أزرار التحكم بالنافذة
            btnCloseForm = New Button With {
                .Text = "✕",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(220, 53, 69),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(40, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(15, 17),
                .Cursor = Cursors.Hand
            }
            btnCloseForm.FlatAppearance.BorderSize = 0
            AddHandler btnCloseForm.Click, Sub() Me.Close()
            panelHeader.Controls.Add(btnCloseForm)

            btnFullscreen = New Button With {
                .Text = "⛶ ملء الشاشة",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(50, 55, 65),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(110, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(65, 17),
                .Cursor = Cursors.Hand
            }
            btnFullscreen.FlatAppearance.BorderSize = 0
            AddHandler btnFullscreen.Click, AddressOf ToggleFullscreen
            panelHeader.Controls.Add(btnFullscreen)

            btnHistory = New Button With {
                .Text = "📜 المنتهية (Recall)",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(50, 55, 65),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(130, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(185, 17),
                .Cursor = Cursors.Hand
            }
            btnHistory.FlatAppearance.BorderSize = 0
            AddHandler btnHistory.Click, AddressOf ToggleHistoryMode
            panelHeader.Controls.Add(btnHistory)

            btnSoundToggle = New Button With {
                .Text = "🔔 الصوت: مفعل",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(40, 70, 60),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(120, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(325, 17),
                .Cursor = Cursors.Hand
            }
            btnSoundToggle.FlatAppearance.BorderSize = 0
            AddHandler btnSoundToggle.Click, AddressOf ToggleSound
            panelHeader.Controls.Add(btnSoundToggle)

            btnRefresh = New Button With {
                .Text = "🔄 تحديث",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(50, 55, 65),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(90, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(455, 17),
                .Cursor = Cursors.Hand
            }
            btnRefresh.FlatAppearance.BorderSize = 0
            AddHandler btnRefresh.Click, Async Sub() Await LoadActiveOrdersAsync()
            panelHeader.Controls.Add(btnRefresh)

            Me.Controls.Add(panelHeader)

            ' 2. شريط الفلترة أسفل الهيدر
            pnlFilterContainer = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 46,
                .BackColor = Color.FromArgb(26, 29, 35),
                .Padding = New Padding(15, 6, 15, 6)
            }

            Dim lblFilterType As New Label With {
                .Text = "تصفية بنوع الطلب:",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(170, 175, 185),
                .AutoSize = True,
                .Location = New Point(20, 12)
            }
            pnlFilterContainer.Controls.Add(lblFilterType)

            cmbOrderType = New ComboBox With {
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Font = New Font("Segoe UI", 10.0F),
                .BackColor = Color.FromArgb(40, 44, 52),
                .ForeColor = Color.White,
                .Location = New Point(140, 8),
                .Width = 140
            }
            cmbOrderType.Items.AddRange(New Object() {"الكل", "صالة", "تيك أوي", "دليفري"})
            cmbOrderType.SelectedIndex = 0
            AddHandler cmbOrderType.SelectedIndexChanged, Async Sub()
                                                              Select Case cmbOrderType.SelectedIndex
                                                                  Case 0 : _currentOrderTypeFilter = 0
                                                                  Case 1 : _currentOrderTypeFilter = 2 ' صالة
                                                                  Case 2 : _currentOrderTypeFilter = 1 ' تيك أوي
                                                                  Case 3 : _currentOrderTypeFilter = 3 ' دليفري
                                                              End Select
                                                              Await LoadActiveOrdersAsync()
                                                          End Sub
            pnlFilterContainer.Controls.Add(cmbOrderType)

            Dim lblFilterStation As New Label With {
                .Text = "المحطة / القسم:",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(170, 175, 185),
                .AutoSize = True,
                .Location = New Point(310, 12)
            }
            pnlFilterContainer.Controls.Add(lblFilterStation)

            cmbStation = New ComboBox With {
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Font = New Font("Segoe UI", 10.0F),
                .BackColor = Color.FromArgb(40, 44, 52),
                .ForeColor = Color.White,
                .Location = New Point(415, 8),
                .Width = 160
            }
            cmbStation.Items.AddRange(New Object() {"الكل", "مطبخ", "شواية", "بيتزا", "مشروبات"})
            cmbStation.SelectedIndex = 0
            AddHandler cmbStation.SelectedIndexChanged, Async Sub()
                                                            _currentStationFilter = cmbStation.Text
                                                            Await LoadActiveOrdersAsync()
                                                        End Sub
            pnlFilterContainer.Controls.Add(cmbStation)

            Me.Controls.Add(pnlFilterContainer)

            ' 3. لوحة عرض بطاقات الطلبات FlowLayoutPanel
            flowOrders = New FlowLayoutPanel With {
                .Dock = DockStyle.Fill,
                .AutoScroll = True,
                .WrapContents = True,
                .Padding = New Padding(15),
                .BackColor = Color.FromArgb(20, 22, 26)
            }
            Me.Controls.Add(flowOrders)

            ' رسالة الشاشة فارغة
            lblEmptyNotice = New Label With {
                .Text = "لا توجد طلبات نشطة في المطبخ حالياً ✅" & vbCrLf & "سيتم تحديث الشاشة تلقائياً فور تسجيل طلب جديد",
                .Font = New Font("Segoe UI", 16.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(100, 110, 125),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Dock = DockStyle.Fill,
                .Visible = False
            }
            Me.Controls.Add(lblEmptyNotice)
            lblEmptyNotice.BringToFront()

            ' 4. تجهيز المؤقتات
            tmrSeconds = New Timer With {.Interval = 1000}
            AddHandler tmrSeconds.Tick, AddressOf OnSecondsTick
            tmrSeconds.Start()

            tmrPoll = New Timer With {.Interval = 4000}
            AddHandler tmrPoll.Tick, Async Sub() Await PollNewOrdersAsync()
            tmrPoll.Start()

            ' دعم السحب بالفأرة للهيدر
            Dim drag As New FormDragHelper(Me, panelHeader)
        End Sub

        Private Async Sub FrmKitchenDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Await LoadActiveOrdersAsync()
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
                Dim orders = Await Task.Run(Function() _repo.GetActiveKitchenOrders(_currentOrderTypeFilter, _currentStationFilter))
                flowOrders.SuspendLayout()
                flowOrders.Controls.Clear()
                _displayedOrders.Clear()

                If orders Is Nothing OrElse orders.Count = 0 Then
                    lblEmptyNotice.Visible = True
                    lblActiveCountBadge.Text = "0 طلبات قيد التحضير"
                    lblActiveCountBadge.BackColor = Color.FromArgb(30, 35, 45)
                    lblActiveCountBadge.ForeColor = Color.FromArgb(150, 160, 175)
                Else
                    lblEmptyNotice.Visible = False
                    lblActiveCountBadge.Text = orders.Count & " طلبات قيد التحضير"
                    lblActiveCountBadge.BackColor = Color.FromArgb(16, 45, 35)
                    lblActiveCountBadge.ForeColor = Color.FromArgb(16, 185, 129)

                    For Each order In orders
                        Dim card = CreateOrderCard(order, isHistory:=False)
                        _displayedOrders(order.KitchenOrderID) = card
                        flowOrders.Controls.Add(card)
                    Next
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
                        Dim newCard = CreateOrderCard(order, isHistory:=False)
                        _displayedOrders(order.KitchenOrderID) = newCard
                        flowOrders.Controls.Add(newCard)
                        hasNewOrder = True
                    End If
                Next

                If hasNewOrder AndAlso _soundEnabled Then
                    PlayNotificationSound()
                End If

                ' تحديث شارة العدد
                If _displayedOrders.Count = 0 Then
                    lblEmptyNotice.Visible = True
                    lblActiveCountBadge.Text = "0 طلبات قيد التحضير"
                Else
                    lblEmptyNotice.Visible = False
                    lblActiveCountBadge.Text = _displayedOrders.Count & " طلبات قيد التحضير"
                End If
            Catch ex As Exception
                Debug.WriteLine("PollNewOrdersAsync error: " & ex.Message)
            Finally
                _isPolling = False
            End Try
        End Function

        ' =========================================================
        ' مؤقت الثواني لتحديث العدادات الملونة
        ' =========================================================
        Private Sub OnSecondsTick(sender As Object, e As EventArgs)
            If _isHistoryMode Then Return
            For Each kvp In _displayedOrders
                kvp.Value.UpdateTimerUI()
            Next
        End Sub

        ' =========================================================
        ' إنشاء بطاقة الطلب (Order Card Control)
        ' =========================================================
        Private Function CreateOrderCard(order As KitchenOrderModel, isHistory As Boolean) As OrderCardControl
            Dim card As New OrderCardControl(order, _repo, isHistory)
            AddHandler card.OrderBumped, Sub(orderId)
                                             If _displayedOrders.ContainsKey(orderId) Then
                                                 Dim c = _displayedOrders(orderId)
                                                 flowOrders.Controls.Remove(c)
                                                 c.Dispose()
                                                 _displayedOrders.Remove(orderId)
                                                 lblActiveCountBadge.Text = _displayedOrders.Count & " طلبات قيد التحضير"
                                                 If _displayedOrders.Count = 0 Then lblEmptyNotice.Visible = True
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
                Dim orders = Await Task.Run(Function() _repo.GetRecentBumpedOrders(25))
                flowOrders.SuspendLayout()
                flowOrders.Controls.Clear()
                _displayedOrders.Clear()

                If orders Is Nothing OrElse orders.Count = 0 Then
                    lblEmptyNotice.Text = "لا توجد طلبات منتهية مؤخراً للاسترجاع"
                    lblEmptyNotice.Visible = True
                    lblActiveCountBadge.Text = "أرشيف الطلبات المنتهية"
                Else
                    lblEmptyNotice.Visible = False
                    lblActiveCountBadge.Text = orders.Count & " طلبات منتهية"
                    For Each order In orders
                        Dim card = CreateOrderCard(order, isHistory:=True)
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
            If _isHistoryMode Then
                btnHistory.Text = "⬅ العودة للنشطة"
                btnHistory.BackColor = Color.FromArgb(180, 80, 30)
                lblTitle.Text = "📜 أرشيف طلبات المطبخ المنتهية حديثاً"
                pnlFilterContainer.Visible = False
                Await LoadHistoryOrdersAsync()
            Else
                btnHistory.Text = "📜 المنتهية (Recall)"
                btnHistory.BackColor = Color.FromArgb(50, 55, 65)
                lblTitle.Text = "🍳 شاشة المطبخ الرقمية (KDS)"
                pnlFilterContainer.Visible = True
                lblEmptyNotice.Text = "لا توجد طلبات نشطة في المطبخ حالياً ✅" & vbCrLf & "سيتم تحديث الشاشة تلقائياً فور تسجيل طلب جديد"
                Await LoadActiveOrdersAsync()
            End If
        End Sub

        Private Sub ToggleSound(sender As Object, e As EventArgs)
            _soundEnabled = Not _soundEnabled
            If _soundEnabled Then
                btnSoundToggle.Text = "🔔 الصوت: مفعل"
                btnSoundToggle.BackColor = Color.FromArgb(40, 70, 60)
            Else
                btnSoundToggle.Text = "🔕 الصوت: معطل"
                btnSoundToggle.BackColor = Color.FromArgb(70, 45, 45)
            End If
        End Sub

        Private Sub ToggleFullscreen(sender As Object, e As EventArgs)
            If Me.WindowState = FormWindowState.Maximized AndAlso Me.FormBorderStyle = FormBorderStyle.None Then
                Me.WindowState = FormWindowState.Normal
                btnFullscreen.Text = "⛶ ملء الشاشة"
            Else
                Me.WindowState = FormWindowState.Maximized
                btnFullscreen.Text = "🗗 تصغير"
            End If
        End Sub

        Private Sub PlayNotificationSound()
            Try
                SystemSounds.Asterisk.Play()
            Catch
            End Try
        End Sub

        Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
            tmrSeconds.Stop()
            tmrPoll.Stop()
            MyBase.OnFormClosing(e)
        End Sub
    End Class

    ' =========================================================
    ' بطاقة الطلب التفاعلية داخل شاشة المطبخ (OrderCardControl)
    ' =========================================================
    Public Class OrderCardControl
        Inherits Panel

        Public ReadOnly Order As KitchenOrderModel
        Private ReadOnly _repo As POSRepository
        Private ReadOnly _isHistory As Boolean

        Public Event OrderBumped(orderId As Integer)
        Public Event OrderRecalled(orderId As Integer)

        Private pnlHeader As Panel
        Private lblOrderNum As Label
        Private lblOrderType As Label
        Private lblTimer As Label
        Private lblServerName As Label
        Private pnlItemsList As Panel
        Private btnAction As Button
        Private btnStartPrep As Button

        Public Sub New(order As KitchenOrderModel, repo As POSRepository, isHistory As Boolean)
            Me.Order = order
            Me._repo = repo
            Me._isHistory = isHistory

            InitializeCard()
        End Sub

        Private Sub InitializeCard()
            Me.Width = 320
            Me.Margin = New Padding(10)
            Me.BackColor = Color.FromArgb(32, 36, 43)
            Me.RightToLeft = RightToLeft.Yes

            ' 1. هيدر البطاقة
            pnlHeader = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 65,
                .Padding = New Padding(10, 6, 10, 6)
            }

            lblOrderType = New Label With {
                .Text = Order.OrderTypeDisplay,
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = Color.White,
                .AutoSize = True,
                .Location = New Point(10, 8)
            }
            pnlHeader.Controls.Add(lblOrderType)

            lblTimer = New Label With {
                .Text = If(_isHistory, "منجز", Order.ElapsedFormatted),
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .AutoSize = True,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(230, 8)
            }
            pnlHeader.Controls.Add(lblTimer)

            lblOrderNum = New Label With {
                .Text = $"طلب: {Order.OrderNumber} | {Order.CreatedAt:HH:mm}",
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(220, 225, 230),
                .AutoSize = True,
                .Location = New Point(10, 36)
            }
            pnlHeader.Controls.Add(lblOrderNum)

            lblServerName = New Label With {
                .Text = If(String.IsNullOrEmpty(Order.ServerName), "", "👤 " & Order.ServerName),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(200, 210, 220),
                .AutoSize = True,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .Location = New Point(180, 36)
            }
            pnlHeader.Controls.Add(lblServerName)

            Me.Controls.Add(pnlHeader)

            ' 2. قائمة الأصناف
            pnlItemsList = New Panel With {
                .Dock = DockStyle.Top,
                .AutoSize = True,
                .Padding = New Padding(10, 8, 10, 8)
            }

            Dim yPos As Integer = 8
            For Each item In Order.Items
                Dim currentItem = item
                Dim pnlRow As New Panel With {
                    .Width = 295,
                    .Location = New Point(8, yPos),
                    .BackColor = Color.FromArgb(38, 42, 50),
                    .Padding = New Padding(6),
                    .Margin = New Padding(0, 0, 0, 4)
                }

                Dim chkItem As New CheckBox With {
                    .Text = $"{currentItem.Quantity}x  {currentItem.ProductName}",
                    .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                    .ForeColor = If(currentItem.IsCompleted, Color.Gray, Color.White),
                    .Checked = currentItem.IsCompleted,
                    .AutoSize = True,
                    .Location = New Point(6, 4),
                    .Cursor = Cursors.Hand
                }
                If currentItem.IsCompleted Then
                    chkItem.Font = New Font("Segoe UI", 10.0F, FontStyle.Strikeout)
                End If

                AddHandler chkItem.CheckedChanged, Sub()
                                                       currentItem.IsCompleted = chkItem.Checked
                                                       If chkItem.Checked Then
                                                           chkItem.Font = New Font("Segoe UI", 10.0F, FontStyle.Strikeout)
                                                           chkItem.ForeColor = Color.Gray
                                                       Else
                                                           chkItem.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
                                                           chkItem.ForeColor = Color.White
                                                       End If
                                                       Task.Run(Sub() _repo.ToggleKitchenItemStatus(currentItem.DetailID, chkItem.Checked))
                                                   End Sub
                pnlRow.Controls.Add(chkItem)

                Dim subY As Integer = 28
                ' الحجم
                If Not String.IsNullOrEmpty(currentItem.SizeName) Then
                    Dim lblSize As New Label With {
                        .Text = "الحجم: " & currentItem.SizeName,
                        .Font = New Font("Segoe UI", 8.5F),
                        .ForeColor = Color.FromArgb(160, 175, 195),
                        .AutoSize = True,
                        .Location = New Point(25, subY)
                    }
                    pnlRow.Controls.Add(lblSize)
                    subY += 18
                End If

                ' الإضافات
                If Not String.IsNullOrEmpty(currentItem.AddonsText) Then
                    Dim lblAddons As New Label With {
                        .Text = "+ " & currentItem.AddonsText,
                        .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                        .ForeColor = Color.FromArgb(245, 158, 11),
                        .AutoSize = True,
                        .Location = New Point(25, subY)
                    }
                    pnlRow.Controls.Add(lblAddons)
                    subY += 18
                End If

                ' الملاحظات الخاصة (بدون بصل، سبايسي)
                If Not String.IsNullOrEmpty(currentItem.Notes) Then
                    Dim lblNote As New Label With {
                        .Text = "⚠️ " & currentItem.Notes,
                        .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                        .ForeColor = Color.FromArgb(239, 68, 68),
                        .AutoSize = True,
                        .Location = New Point(25, subY)
                    }
                    pnlRow.Controls.Add(lblNote)
                    subY += 20
                End If

                pnlRow.Height = subY + 6
                pnlItemsList.Controls.Add(pnlRow)
                yPos += pnlRow.Height + 5
            Next

            ' ملاحظات الطلب العامة
            If Not String.IsNullOrEmpty(Order.Notes) Then
                Dim lblOrderNotes As New Label With {
                    .Text = "ملاحظة: " & Order.Notes,
                    .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                    .ForeColor = Color.FromArgb(255, 215, 0),
                    .AutoSize = True,
                    .Location = New Point(10, yPos)
                }
                pnlItemsList.Controls.Add(lblOrderNotes)
                yPos += 24
            End If

            pnlItemsList.Height = yPos + 10
            Me.Controls.Add(pnlItemsList)

            ' 3. أزرار التحكم بالبطاقة في الأسفل
            Dim pnlBottom As New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 48,
                .Padding = New Padding(8, 4, 8, 6)
            }

            If _isHistory Then
                btnAction = New Button With {
                    .Text = "↩ استرجاع للمطبخ (Recall)",
                    .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                    .ForeColor = Color.White,
                    .BackColor = Color.FromArgb(217, 119, 6),
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
                    .Text = "✓ تم التجهيز والتسليم (Bump)",
                    .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                    .ForeColor = Color.White,
                    .BackColor = Color.FromArgb(16, 149, 105),
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

            Me.Controls.Add(pnlBottom)

            UpdateHeaderColor()
            Me.Height = pnlHeader.Height + pnlItemsList.Height + pnlBottom.Height + 10
        End Sub

        Public Sub UpdateTimerUI()
            If _isHistory Then Return
            lblTimer.Text = Order.ElapsedFormatted
            UpdateHeaderColor()
        End Sub

        Private Sub UpdateHeaderColor()
            If _isHistory Then
                pnlHeader.BackColor = Color.FromArgb(55, 60, 70)
                Return
            End If

            Dim totalSec = Order.ElapsedSeconds
            If totalSec < 300 Then
                ' 🟢 أقل من 5 دقائق: أخضر (طلب جديد هادئ)
                pnlHeader.BackColor = Color.FromArgb(16, 120, 85)
            ElseIf totalSec < 720 Then
                ' 🟠 من 5 إلى 12 دقيقة: برتقالي (تحذير اقتراب التأخير)
                pnlHeader.BackColor = Color.FromArgb(190, 110, 15)
            Else
                ' 🔴 أكثر من 12 دقيقة: أحمر (متأخر جداً)
                pnlHeader.BackColor = Color.FromArgb(185, 28, 28)
            End If
        End Sub
    End Class
End Namespace
