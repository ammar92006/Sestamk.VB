Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' لوحة عرض الإشعارات المنسدلة من الهيدر
''' </summary>
Public Class NotificationPanel
    Inherits Guna.UI2.WinForms.Guna2Panel

    Private lblHeader As Label
    Private lblUnreadCount As Label
    Private btnMarkAllRead As Guna.UI2.WinForms.Guna2Button
    Private btnClearRead As Guna.UI2.WinForms.Guna2Button
    Private flpNotifications As FlowLayoutPanel
    Private lblEmpty As Label
    Private tmrRefresh As Timer

    Public Event NotificationClicked As EventHandler(Of NotificationClickedEventArgs)

    Public Sub New()
        InitializeComponents()
        LoadNotifications()

        ' تحديث تلقائي كل 30 ثانية
        tmrRefresh = New Timer With {.Interval = 30000}
        AddHandler tmrRefresh.Tick, AddressOf OnRefreshTimer
        tmrRefresh.Start()

        ' الاشتراك في أحداث الإشعارات
        AddHandler NotificationManager.Instance.NotificationReceived, AddressOf OnNotificationReceived
        AddHandler NotificationManager.Instance.NotificationRead, AddressOf OnNotificationRead
    End Sub

    Private Sub InitializeComponents()
        ' إعدادات اللوحة الرئيسية
        Me.Size = New Size(400, 550)
        Me.BorderRadius = 15
        Me.BorderThickness = 1
        Me.ShadowDecoration.Enabled = True
        Me.ShadowDecoration.Shadow = New Padding(0, 5, 10, 10)
        Me.ShadowDecoration.Depth = 20
        Me.Padding = New Padding(0)

        ' الهيدر
        Dim pnlHeader As New Guna.UI2.WinForms.Guna2Panel With {
            .Dock = DockStyle.Top,
            .Height = 60,
            .Padding = New Padding(15, 10, 15, 10)
        }

        lblHeader = New Label With {
            .Text = "الإشعارات",
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Dock = DockStyle.Left,
            .AutoSize = False,
            .Width = 120,
            .TextAlign = ContentAlignment.MiddleRight
        }

        lblUnreadCount = New Label With {
            .Text = "0",
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .AutoSize = True,
            .Padding = New Padding(8, 3, 8, 3)
        }
        lblUnreadCount.Location = New Point(lblHeader.Right + 5, 18)

        btnMarkAllRead = New Guna.UI2.WinForms.Guna2Button With {
            .Text = "قراءة الكل",
            .Size = New Size(90, 35),
            .Dock = DockStyle.Right,
            .BorderRadius = 8,
            .Font = New Font("Segoe UI", 8.5, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        AddHandler btnMarkAllRead.Click, AddressOf BtnMarkAllRead_Click

        btnClearRead = New Guna.UI2.WinForms.Guna2Button With {
            .Text = "🗑️",
            .Size = New Size(35, 35),
            .Dock = DockStyle.Right,
            .BorderRadius = 8,
            .Font = New Font("Segoe UI", 10),
            .Cursor = Cursors.Hand
        }
        AddHandler btnClearRead.Click, AddressOf BtnClearRead_Click

        pnlHeader.Controls.Add(btnClearRead)
        pnlHeader.Controls.Add(btnMarkAllRead)
        pnlHeader.Controls.Add(lblUnreadCount)
        pnlHeader.Controls.Add(lblHeader)

        ' منطقة الإشعارات
        flpNotifications = New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .Padding = New Padding(10, 5, 10, 10)
        }

        ' رسالة فارغة
        lblEmpty = New Label With {
            .Text = "لا توجد إشعارات جديدة 🔔",
            .Font = New Font("Segoe UI", 10),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Dock = DockStyle.Fill,
            .Visible = False
        }

        Me.Controls.Add(flpNotifications)
        Me.Controls.Add(lblEmpty)
        Me.Controls.Add(pnlHeader)
    End Sub

    ''' <summary>
    ''' تحميل الإشعارات من قاعدة البيانات
    ''' </summary>
    Public Sub LoadNotifications()
        Try
            flpNotifications.Controls.Clear()

            Dim dt As DataTable = NotificationManager.Instance.GetUnreadNotifications()

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                lblEmpty.Visible = False
                flpNotifications.Visible = True

                For Each row As DataRow In dt.Rows
                    Dim card As New NotificationCard(row)
                    AddHandler card.NotificationClicked, AddressOf OnNotificationCardClicked
                    flpNotifications.Controls.Add(card)
                Next

                ' تحديث عداد غير المقروء
                UpdateUnreadCount()
            Else
                lblEmpty.Visible = True
                flpNotifications.Visible = False
                lblUnreadCount.Text = "0"
            End If
        Catch ex As Exception
            Logger.LogError("NotificationPanel.LoadNotifications", ex)
        End Try
    End Sub

    ''' <summary>
    ''' تحديث عدد الإشعارات غير المقروءة
    ''' </summary>
    Private Sub UpdateUnreadCount()
        Try
            Dim count As Integer = NotificationManager.Instance.GetUnreadCount()
            lblUnreadCount.Text = count.ToString()
            lblUnreadCount.Visible = count > 0
        Catch ex As Exception
            Logger.LogError("NotificationPanel.UpdateUnreadCount", ex)
        End Try
    End Sub

    ''' <summary>
    ''' تطبيق الثيم
    ''' </summary>
    Public Sub ApplyTheme()
        Try
            Dim pal = ThemeManager.Instance.CurrentPalette
            If pal Is Nothing Then Return
            Dim isDark As Boolean = ThemeManager.Instance.IsDark

            Me.FillColor = If(isDark, Color.FromArgb(17, 22, 34), Color.White)
            Me.BorderColor = If(isDark, Color.FromArgb(38, 51, 72), pal.Border)

            lblHeader.ForeColor = If(isDark, Color.White, pal.TextPrimary)

            lblUnreadCount.BackColor = pal.Primary
            lblUnreadCount.ForeColor = Color.White

            lblEmpty.ForeColor = If(isDark, Color.FromArgb(148, 163, 184), pal.TextMuted)

            ' أزرار الهيدر
            btnMarkAllRead.FillColor = If(isDark, Color.FromArgb(30, 41, 59), Color.FromArgb(241, 245, 249))
            btnMarkAllRead.ForeColor = If(isDark, Color.White, pal.TextPrimary)
            btnMarkAllRead.HoverState.FillColor = pal.Primary
            btnMarkAllRead.HoverState.ForeColor = Color.White

            btnClearRead.FillColor = Color.Transparent
            btnClearRead.ForeColor = If(isDark, Color.FromArgb(209, 213, 219), pal.TextSecondary)
            btnClearRead.HoverState.FillColor = pal.DangerSubtleBackground
            btnClearRead.HoverState.ForeColor = pal.Danger

            ' تطبيق الثيم على كروت الإشعارات
            For Each ctrl As Control In flpNotifications.Controls
                If TypeOf ctrl Is NotificationCard Then
                    CType(ctrl, NotificationCard).ApplyTheme()
                End If
            Next
        Catch ex As Exception
            Logger.LogError("NotificationPanel.ApplyTheme", ex)
        End Try
    End Sub

    Private Sub BtnMarkAllRead_Click(sender As Object, e As EventArgs)
        If NotificationManager.Instance.MarkAllAsRead() Then
            LoadNotifications()
            Notify.Toast("تم وضع علامة مقروء على جميع الإشعارات ✅", Notify.ToastType.Success)
        End If
    End Sub

    Private Sub BtnClearRead_Click(sender As Object, e As EventArgs)
        If SmartMessageBox.Show("هل تريد حذف جميع الإشعارات المقروءة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If NotificationManager.Instance.DeleteAllRead() Then
                LoadNotifications()
                Notify.Toast("تم حذف الإشعارات المقروءة 🗑️", Notify.ToastType.Info)
            End If
        End If
    End Sub

    Private Sub OnNotificationCardClicked(sender As Object, e As NotificationClickedEventArgs)
        ' وضع علامة مقروء
        NotificationManager.Instance.MarkAsRead(e.NotificationId)

        ' إطلاق الحدث للمستمعين
        RaiseEvent NotificationClicked(Me, e)

        ' إعادة تحميل
        LoadNotifications()
    End Sub

    Private Sub OnNotificationReceived(sender As Object, e As NotificationEventArgs)
        ' إعادة تحميل عند وصول إشعار جديد
        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf LoadNotifications))
        Else
            LoadNotifications()
        End If
    End Sub

    Private Sub OnNotificationRead(sender As Object, e As NotificationEventArgs)
        ' تحديث العداد
        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateUnreadCount))
        Else
            UpdateUnreadCount()
        End If
    End Sub

    Private Sub OnRefreshTimer(sender As Object, e As EventArgs)
        LoadNotifications()
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If tmrRefresh IsNot Nothing Then
                tmrRefresh.Stop()
                tmrRefresh.Dispose()
            End If
            RemoveHandler NotificationManager.Instance.NotificationReceived, AddressOf OnNotificationReceived
            RemoveHandler NotificationManager.Instance.NotificationRead, AddressOf OnNotificationRead
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class

''' <summary>
''' كارت إشعار واحد
''' </summary>
Public Class NotificationCard
    Inherits Guna.UI2.WinForms.Guna2Panel

    Private _notificationId As Integer
    Private _actionType As String
    Private _actionData As String
    Private _defaultFillColor As Color = Color.FromArgb(248, 250, 252)
    Private _hoverFillColor As Color = Color.FromArgb(241, 245, 249)

    Public Event NotificationClicked As EventHandler(Of NotificationClickedEventArgs)

    Public Sub New(row As DataRow)
        _notificationId = Convert.ToInt32(row("NotificationID"))
        _actionType = If(IsDBNull(row("ActionType")), Nothing, row("ActionType").ToString())
        _actionData = If(IsDBNull(row("ActionData")), Nothing, row("ActionData").ToString())

        InitializeCard(row)
    End Sub

    Private Sub InitializeCard(row As DataRow)
        ' إعدادات الكارت
        Me.Height = 90
        Me.Width = 360
        Me.BorderRadius = 12
        Me.Margin = New Padding(0, 5, 0, 5)
        Me.Padding = New Padding(12)
        Me.Cursor = Cursors.Hand

        ' الأيقونة
        Dim picIcon As New Guna.UI2.WinForms.Guna2CirclePictureBox With {
            .Size = New Size(40, 40),
            .Location = New Point(Me.Width - 52, 12),
            .SizeMode = PictureBoxSizeMode.Zoom
        }

        ' تحديد الأيقونة حسب النوع
        Dim notifType As String = row("NotificationType").ToString()
        Try
            Select Case notifType.ToLower()
                Case "order" : picIcon.Image = My.Resources.Resources.cart__1_
                Case "error" : picIcon.Image = My.Resources.Resources.close
                Case "lowstock" : picIcon.Image = My.Resources.Resources.stock
                Case "printfailure" : picIcon.Image = My.Resources.Resources.printer
                Case Else : picIcon.Image = My.Resources.Resources.notification
            End Select
        Catch
            ' استخدام أيقونة افتراضية
            picIcon.Image = My.Resources.Resources.notification
        End Try

        ' العنوان
        Dim lblTitle As New Label With {
            .Text = row("Title").ToString(),
            .Font = New Font("Segoe UI", 9.5, FontStyle.Bold),
            .Location = New Point(12, 12),
            .AutoSize = False,
            .Width = Me.Width - 80,
            .Height = 20
        }

        ' الرسالة
        Dim lblMessage As New Label With {
            .Text = row("Message").ToString(),
            .Font = New Font("Segoe UI", 8.5),
            .Location = New Point(12, 36),
            .AutoSize = False,
            .Width = Me.Width - 80,
            .Height = 30
        }

        ' الوقت
        Dim createdAt As DateTime = Convert.ToDateTime(row("CreatedAt"))
        Dim lblTime As New Label With {
            .Text = GetRelativeTime(createdAt),
            .Font = New Font("Segoe UI", 7.5),
            .Location = New Point(12, 68),
            .AutoSize = True
        }

        ' إضافة العناصر
        Me.Controls.Add(picIcon)
        Me.Controls.Add(lblTitle)
        Me.Controls.Add(lblMessage)
        Me.Controls.Add(lblTime)

        ' ربط أحداث Hover
        HookHoverEvents(picIcon)
        HookHoverEvents(lblTitle)
        HookHoverEvents(lblMessage)
        HookHoverEvents(lblTime)

        ' حدث الضغط
        AddHandler Me.Click, AddressOf OnCardClick
        AddHandler lblTitle.Click, AddressOf OnCardClick
        AddHandler lblMessage.Click, AddressOf OnCardClick
        AddHandler lblTime.Click, AddressOf OnCardClick
        AddHandler picIcon.Click, AddressOf OnCardClick
    End Sub

    Private Sub OnCardClick(sender As Object, e As EventArgs)
        RaiseEvent NotificationClicked(Me, New NotificationClickedEventArgs With {
            .NotificationId = _notificationId,
            .ActionType = _actionType,
            .ActionData = _actionData
        })
    End Sub

    Private Sub HookHoverEvents(ctrl As Control)
        AddHandler ctrl.MouseEnter, Sub() Me.FillColor = _hoverFillColor
        AddHandler ctrl.MouseLeave, AddressOf OnChildMouseLeave
    End Sub

    Private Sub OnChildMouseLeave(sender As Object, e As EventArgs)
        If Not Me.ClientRectangle.Contains(Me.PointToClient(Cursor.Position)) Then
            Me.FillColor = _defaultFillColor
        End If
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        Me.FillColor = _hoverFillColor
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        If Not Me.ClientRectangle.Contains(Me.PointToClient(Cursor.Position)) Then
            Me.FillColor = _defaultFillColor
        End If
    End Sub

    Public Sub ApplyTheme()
        Try
            Dim pal = ThemeManager.Instance.CurrentPalette
            If pal Is Nothing Then Return
            Dim isDark As Boolean = ThemeManager.Instance.IsDark

            _defaultFillColor = If(isDark, Color.FromArgb(23, 30, 44), Color.FromArgb(248, 250, 252))
            _hoverFillColor = If(isDark, Color.FromArgb(30, 41, 59), Color.FromArgb(241, 245, 249))

            Me.FillColor = _defaultFillColor
            Me.BorderColor = If(isDark, Color.FromArgb(38, 51, 72), Color.FromArgb(226, 232, 240))
            Me.BorderThickness = 1

            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Label Then
                    Dim lbl As Label = CType(ctrl, Label)
                    If lbl.Font.Bold Then
                        lbl.ForeColor = If(isDark, Color.White, pal.TextPrimary)
                    Else
                        lbl.ForeColor = If(isDark, Color.FromArgb(203, 213, 225), pal.TextSecondary)
                    End If
                End If
            Next
        Catch ex As Exception
            Logger.LogError("NotificationCard.ApplyTheme", ex)
        End Try
    End Sub

    Private Function GetRelativeTime(dt As DateTime) As String
        Dim span As TimeSpan = DateTime.Now - dt

        If span.TotalMinutes < 1 Then
            Return "الآن"
        ElseIf span.TotalMinutes < 60 Then
            Return $"منذ {CInt(span.TotalMinutes)} دقيقة"
        ElseIf span.TotalHours < 24 Then
            Return $"منذ {CInt(span.TotalHours)} ساعة"
        ElseIf span.TotalDays < 7 Then
            Return $"منذ {CInt(span.TotalDays)} يوم"
        Else
            Return dt.ToString("dd/MM/yyyy")
        End If
    End Function
End Class

''' <summary>
''' معلومات حدث الضغط على الإشعار
''' </summary>
Public Class NotificationClickedEventArgs
    Inherits EventArgs

    Public Property NotificationId As Integer
    Public Property ActionType As String
    Public Property ActionData As String
End Class
