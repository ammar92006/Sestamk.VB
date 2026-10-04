Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

''' <summary>
''' مدير Toast متطور مع جميع الميزات الاحترافية
''' </summary>
Public NotInheritable class ToastManagerAdvanced
    Private Sub New()
    End Sub

    Private Shared ReadOnly _visibleToasts As New List(Of frmToastAdvanced)()
    Private Shared ReadOnly _queue As New List(Of ToastModelAdvanced)()
    Private Shared ReadOnly _groups As New Dictionary(Of String, ToastGroup)()
    Private Shared ReadOnly _lock As New Object()
    Private Shared _animationTimer As Timer
    Private Shared _maxVisibleToasts As Integer = 5
    Private Shared _spacing As Integer = 10
    Private Shared _animationSpeed As Integer = 20

    ' الإعدادات الافتراضية
    Private Shared _defaultPosition As ToastPosition = ToastPosition.BottomRight
    Private Shared _defaultAnimation As ToastAnimation = ToastAnimation.SlideWithBounce
    Private Shared _defaultDuration As Integer = 3800

    Shared Sub New()
        _animationTimer = New Timer() With {.Interval = 15}
        AddHandler _animationTimer.Tick, AddressOf AnimationTick
        _animationTimer.Start()

        ' تحميل الإعدادات من قاعدة البيانات
        LoadSettingsFromDatabase()
    End Sub

    ''' <summary>
    ''' تحميل إعدادات Toast من قاعدة البيانات
    ''' </summary>
    Private Shared Sub LoadSettingsFromDatabase()
        Try
            _defaultPosition = CType(SettingsManager.GetIntSetting(SettingsKeys.NotificationPosition, 0), ToastPosition)
            _defaultAnimation = CType(SettingsManager.GetIntSetting(SettingsKeys.NotificationAnimation, 4), ToastAnimation)
            _defaultDuration = SettingsManager.GetIntSetting(SettingsKeys.NotificationDuration, 3800)
            _maxVisibleToasts = SettingsManager.GetIntSetting(SettingsKeys.NotificationMaxVisible, 5)
        Catch ex As Exception
            Logger.LogError("ToastManagerAdvanced.LoadSettings", ex)
        End Try
    End Sub

    ''' <summary>
    ''' إعادة تحميل الإعدادات
    ''' </summary>
    Public Shared Sub ReloadSettings()
        LoadSettingsFromDatabase()
    End Sub

    ''' <summary>
    ''' عرض إشعار متطور
    ''' </summary>
    Public Shared Sub Show(model As ToastModelAdvanced)
        If model Is Nothing Then Return

        ' تطبيق الإعدادات الافتراضية إذا لم يتم تحديدها
        If model.Position = ToastPosition.BottomRight AndAlso _defaultPosition <> ToastPosition.BottomRight Then
            model.Position = _defaultPosition
        End If
        If model.Animation = ToastAnimation.SlideWithBounce AndAlso _defaultAnimation <> ToastAnimation.SlideWithBounce Then
            model.Animation = _defaultAnimation
        End If
        If model.Duration = 3800 AndAlso _defaultDuration <> 3800 Then
            model.Duration = _defaultDuration
        End If

        ' إذا كان الاستدعاء من ثريد خلفي
        If Application.OpenForms.Count > 0 Then
            Dim mainForm = Application.OpenForms(0)
            If mainForm IsNot Nothing AndAlso mainForm.InvokeRequired Then
                mainForm.BeginInvoke(New Action(Sub() Show(model)))
                Return
            End If
        End If

        SyncLock _lock
            ' معالجة التجميع
            If model.CanStack AndAlso Not String.IsNullOrWhiteSpace(model.GroupKey) Then
                HandleGroupedToast(model)
                Return
            End If

            ' إضافة للقائمة إذا وصل الحد الأقصى
            If _visibleToasts.Count >= _maxVisibleToasts Then
                ' إزالة الإشعارات منخفضة الأولوية أولاً إذا كان الجديد عالي الأولوية
                If model.Priority = ToastPriority.Critical Then
                    RemoveLowestPriorityToast()
                Else
                    _queue.Add(model)
                    _queue.Sort(Function(a, b) b.Priority.CompareTo(a.Priority))
                    Return
                End If
            End If

            CreateToast(model)
        End SyncLock
    End Sub

    ''' <summary>
    ''' معالجة الإشعارات المجمعة
    ''' </summary>
    Private Shared Sub HandleGroupedToast(model As ToastModelAdvanced)
        If Not _groups.ContainsKey(model.GroupKey) Then
            _groups(model.GroupKey) = New ToastGroup With {
                .GroupKey = model.GroupKey
            }
        End If

        Dim group = _groups(model.GroupKey)
        group.Toasts.Add(model)

        ' تحديث الإشعار المعروض
        If group.DisplayedToast IsNot Nothing Then
            ' إيجاد الـ toast المعروض وتحديثه
            Dim displayedForm = _visibleToasts.FirstOrDefault(Function(t) t.Model.Id = group.DisplayedToast.Id)
            If displayedForm IsNot Nothing Then
                displayedForm.UpdateGroupCount(group.Count)
            End If
        Else
            ' إنشاء أول toast للمجموعة
            group.DisplayedToast = model
            model.Title = $"{model.Title} ({group.Count})"
            CreateToast(model)
        End If
    End Sub

    ''' <summary>
    ''' إزالة إشعار بأقل أولوية
    ''' </summary>
    Private Shared Sub RemoveLowestPriorityToast()
        Dim lowestPriority = _visibleToasts.OrderBy(Function(t) t.Model.Priority).FirstOrDefault()
        If lowestPriority IsNot Nothing Then
            lowestPriority.StartClose()
        End If
    End Sub

    ''' <summary>
    ''' إنشاء نموذج Toast جديد
    ''' </summary>
    Private Shared Sub CreateToast(model As ToastModelAdvanced)
        Try
            Dim toastForm As New frmToastAdvanced(model)

            ' تحديد الشاشة المستهدفة
            Dim targetScreen As Screen = Screen.PrimaryScreen
            If Application.OpenForms.Count > 0 AndAlso Application.OpenForms(0).Visible Then
                targetScreen = Screen.FromControl(Application.OpenForms(0))
            End If

            ' حساب الموضع بناءً على Position
            Dim position = CalculateToastPosition(model, toastForm.Size, targetScreen)
            toastForm.Location = position.StartLocation
            toastForm.TargetLocation = position.TargetLocation

            _visibleToasts.Add(toastForm)
            UpdateLayout(targetScreen)

            ' تشغيل الصوت
            ToastSoundManager.PlayToastSound(model)

            toastForm.Show()

        Catch ex As Exception
            Logger.LogError("ToastManagerAdvanced.CreateToast", ex)
        End Try
    End Sub

    ''' <summary>
    ''' حساب موضع Toast على الشاشة
    ''' </summary>
    Private Shared Function CalculateToastPosition(
        model As ToastModelAdvanced,
        toastSize As Size,
        screen As Screen
    ) As (StartLocation As Point, TargetLocation As Point)

        Dim margin As Integer = 20
        Dim workArea = screen.WorkingArea
        Dim targetX, targetY As Integer
        Dim startX, startY As Integer

        Select Case model.Position
            Case ToastPosition.BottomRight
                targetX = workArea.Right - toastSize.Width - margin
                targetY = workArea.Bottom - margin
                startX = targetX
                startY = workArea.Bottom + toastSize.Height

            Case ToastPosition.BottomLeft
                targetX = workArea.Left + margin
                targetY = workArea.Bottom - margin
                startX = targetX
                startY = workArea.Bottom + toastSize.Height

            Case ToastPosition.BottomCenter
                targetX = workArea.Left + (workArea.Width - toastSize.Width) \ 2
                targetY = workArea.Bottom - margin
                startX = targetX
                startY = workArea.Bottom + toastSize.Height

            Case ToastPosition.TopRight
                targetX = workArea.Right - toastSize.Width - margin
                targetY = workArea.Top + margin
                startX = targetX
                startY = workArea.Top - toastSize.Height

            Case ToastPosition.TopLeft
                targetX = workArea.Left + margin
                targetY = workArea.Top + margin
                startX = targetX
                startY = workArea.Top - toastSize.Height

            Case ToastPosition.TopCenter
                targetX = workArea.Left + (workArea.Width - toastSize.Width) \ 2
                targetY = workArea.Top + margin
                startX = targetX
                startY = workArea.Top - toastSize.Height

            Case ToastPosition.Center
                targetX = workArea.Left + (workArea.Width - toastSize.Width) \ 2
                targetY = workArea.Top + (workArea.Height - toastSize.Height) \ 2
                startX = targetX
                startY = targetY
                ' للوسط نبدأ بشفافية 0

            Case Else
                targetX = workArea.Right - toastSize.Width - margin
                targetY = workArea.Bottom - margin
                startX = targetX
                startY = workArea.Bottom + toastSize.Height
        End Select

        Return (New Point(startX, startY), New Point(targetX, targetY))
    End Function

    ''' <summary>
    ''' تحديث تخطيط جميع الإشعارات المرئية
    ''' </summary>
    Private Shared Sub UpdateLayout(Optional scr As Screen = Nothing)
        If scr Is Nothing Then
            scr = Screen.PrimaryScreen
            If Application.OpenForms.Count > 0 AndAlso Application.OpenForms(0).Visible Then
                scr = Screen.FromControl(Application.OpenForms(0))
            End If
        End If

        Dim margin As Integer = 20
        Dim workArea = scr.WorkingArea

        ' تجميع حسب الموضع
        Dim grouped = _visibleToasts.GroupBy(Function(t) t.Model.Position)

        For Each group In grouped
            Dim position = group.Key
            Dim toastsList = group.ToList()

            Select Case position
                Case ToastPosition.BottomRight, ToastPosition.BottomLeft, ToastPosition.BottomCenter
                    ' البناء من الأسفل للأعلى
                    Dim y As Integer = workArea.Bottom - margin
                    For i As Integer = toastsList.Count - 1 To 0 Step -1
                        Dim tst As frmToastAdvanced = toastsList(i)
                        If tst IsNot Nothing AndAlso Not tst.IsDisposed Then
                            y -= tst.Height
                            Dim newTarget = tst.TargetLocation
                            newTarget.Y = y
                            tst.TargetLocation = newTarget
                            y -= _spacing
                        End If
                    Next

                Case ToastPosition.TopRight, ToastPosition.TopLeft, ToastPosition.TopCenter
                    ' البناء من الأعلى للأسفل
                    Dim y As Integer = workArea.Top + margin
                    For Each tst As frmToastAdvanced In toastsList
                        If tst IsNot Nothing AndAlso Not tst.IsDisposed Then
                            Dim newTarget = tst.TargetLocation
                            newTarget.Y = y
                            tst.TargetLocation = newTarget
                            y += tst.Height + _spacing
                        End If
                    Next
            End Select
        Next
    End Sub

    ''' <summary>
    ''' مؤقت الأنيميشن الرئيسي
    ''' </summary>
    Private Shared Sub AnimationTick(sender As Object, e As EventArgs)
        SyncLock _lock
            If _visibleToasts.Count = 0 Then Return

            For i As Integer = _visibleToasts.Count - 1 To 0 Step -1
                If i >= _visibleToasts.Count Then Continue For

                Dim toast As frmToastAdvanced = _visibleToasts(i)

                If toast Is Nothing OrElse toast.IsDisposed OrElse Not toast.IsHandleCreated Then
                    _visibleToasts.RemoveAt(i)
                    Continue For
                End If

                ' تحديث الأنيميشن
                toast.UpdateAnimation()

                ' فحص انتهاء الوقت
                If toast.IsClosing AndAlso toast.Opacity <= 0 Then
                    toast.Close()
                    toast.Dispose()
                    _visibleToasts.RemoveAt(i)
                    UpdateLayout()

                    ' تشغيل التالي من القائمة
                    If _queue.Count > 0 Then
                        Dim nextModel = _queue(0)
                        _queue.RemoveAt(0)
                        CreateToast(nextModel)
                    End If
                End If
            Next
        End SyncLock
    End Sub

    ''' <summary>
    ''' عرض سريع - Success
    ''' </summary>
    Public Shared Sub ShowSuccess(title As String, message As String, Optional duration As Integer = 3800)
        Show(New ToastModelAdvanced With {
            .Type = ToastType.Success,
            .Title = title,
            .Message = message,
            .Duration = duration
        })
    End Sub

    ''' <summary>
    ''' عرض سريع - Error
    ''' </summary>
    Public Shared Sub ShowError(title As String, message As String, Optional duration As Integer = 5000)
        Show(New ToastModelAdvanced With {
            .Type = ToastType.Error,
            .Title = title,
            .Message = message,
            .Duration = duration,
            .Priority = ToastPriority.High
        })
    End Sub

    ''' <summary>
    ''' عرض سريع - Warning
    ''' </summary>
    Public Shared Sub ShowWarning(title As String, message As String, Optional duration As Integer = 4000)
        Show(New ToastModelAdvanced With {
            .Type = ToastType.Warning,
            .Title = title,
            .Message = message,
            .Duration = duration,
            .Priority = ToastPriority.Normal
        })
    End Sub

    ''' <summary>
    ''' عرض سريع - Info
    ''' </summary>
    Public Shared Sub ShowInfo(title As String, message As String, Optional duration As Integer = 3800)
        Show(New ToastModelAdvanced With {
            .Type = ToastType.Info,
            .Title = title,
            .Message = message,
            .Duration = duration
        })
    End Sub

    ''' <summary>
    ''' إغلاق جميع الإشعارات
    ''' </summary>
    Public Shared Sub CloseAll()
        SyncLock _lock
            For Each tst As frmToastAdvanced In _visibleToasts.ToList()
                Try
                    tst.Close()
                    tst.Dispose()
                Catch __logEx As Exception
                    Logger.LogError("ToastManagerAdvanced.vb:391", __logEx)
                End Try
            Next
            _visibleToasts.Clear()
            _queue.Clear()
            _groups.Clear()
        End SyncLock
    End Sub

    ''' <summary>
    ''' إغلاق إشعارات مجموعة معينة
    ''' </summary>
    Public Shared Sub CloseGroup(groupKey As String)
        If String.IsNullOrWhiteSpace(groupKey) Then Return

        SyncLock _lock
            Dim toastsToClose = _visibleToasts.Where(Function(t) t.Model.GroupKey = groupKey).ToList()
            For Each tst As frmToastAdvanced In toastsToClose
                tst.StartClose()
            Next

            If _groups.ContainsKey(groupKey) Then
                _groups.Remove(groupKey)
            End If
        End SyncLock
    End Sub

    ''' <summary>
    ''' الحصول على عدد الإشعارات المرئية
    ''' </summary>
    Public Shared Function GetVisibleCount() As Integer
        SyncLock _lock
            Return _visibleToasts.Count
        End SyncLock
    End Function

    ''' <summary>
    ''' الحصول على عدد الإشعارات في الانتظار
    ''' </summary>
    Public Shared Function GetQueueCount() As Integer
        SyncLock _lock
            Return _queue.Count
        End SyncLock
    End Function
End Class
