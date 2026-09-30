Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Public Enum ToastPriority
    Low = 0
    Normal = 1
    High = 2
    Critical = 3
End Enum

Public Class ToastModel
    Public Property Id As Guid = Guid.NewGuid()
    Public Property Type As Notify.ToastType = Notify.ToastType.Success
    Public Property Priority As ToastPriority = ToastPriority.Normal
    Public Property Title As String
    Public Property Message As String
    Public Property Duration As Integer = 3800
    Public Property AutoClose As Boolean = True
    Public Property CreatedAt As DateTime = DateTime.Now
    Public Property ClickAction As Action = Nothing
End Class

Public Class ToastOptions
    Public Property MaxVisibleToasts As Integer = 5
    Public Property Spacing As Integer = 10
    Public Property MarginBottom As Integer = 20
    Public Property MarginRight As Integer = 20
    Public Property AnimationInterval As Integer = 15
    Public Property AnimationSpeed As Integer = 20
    Public Property FadeSpeed As Double = 0.08
End Class

Public NotInheritable Class ToastManager
    Private Sub New()
    End Sub

    Private Shared ReadOnly _visibleToasts As New List(Of frmToast)()
    Private Shared ReadOnly _queue As New List(Of ToastModel)()
    Private Shared ReadOnly _lock As New Object()
    Private Shared _options As New ToastOptions()
    Private Shared _animationTimer As System.Windows.Forms.Timer

    Shared Sub New()
        _animationTimer = New System.Windows.Forms.Timer() With {
            .Interval = _options.AnimationInterval
        }
        AddHandler _animationTimer.Tick, AddressOf AnimationTick
        _animationTimer.Start()
    End Sub

    Public Shared Sub Configure(options As ToastOptions)
        If options IsNot Nothing Then
            _options = options
            _animationTimer.Interval = _options.AnimationInterval
        End If
    End Sub

    Public Shared Sub Show(model As ToastModel)
        If model Is Nothing Then Return

        ' إذا كان الاستدعاء من ثريد خلفي، نحوله للواجهة الرسومية
        If Application.OpenForms.Count > 0 Then
            Dim mainForm = Application.OpenForms(0)
            If mainForm IsNot Nothing AndAlso mainForm.InvokeRequired Then
                mainForm.BeginInvoke(New Action(Sub() Show(model)))
                Return
            End If
        End If

        SyncLock _lock
            If _visibleToasts.Count >= _options.MaxVisibleToasts Then
                _queue.Add(model)
                _queue.Sort(Function(a, b) b.Priority.CompareTo(a.Priority))
                Return
            End If

            CreateToast(model)
        End SyncLock
    End Sub

    Public Shared Sub Show(type As Notify.ToastType, title As String, message As String, Optional duration As Integer = 3800)
        Show(New ToastModel With {
            .Type = type,
            .Title = title,
            .Message = message,
            .Duration = duration
        })
    End Sub

    Private Shared Sub CreateToast(model As ToastModel)
        Try
            Dim toastItem As New frmToast(model)

            Dim targetScreen As Screen = Screen.PrimaryScreen
            If Application.OpenForms.Count > 0 AndAlso Application.OpenForms(0).Visible Then
                targetScreen = Screen.FromControl(Application.OpenForms(0))
            End If

            Dim x As Integer = targetScreen.WorkingArea.Right - toastItem.Width - _options.MarginRight
            toastItem.Left = x
            toastItem.Top = targetScreen.WorkingArea.Bottom + toastItem.Height ' البدء تحت الشاشة لانزلاق ناعم

            _visibleToasts.Add(toastItem)
            UpdateLayout(targetScreen)

            toastItem.Show()
        Catch
        End Try
    End Sub

    Private Shared Sub UpdateLayout(Optional scr As Screen = Nothing)
        If scr Is Nothing Then
            scr = Screen.PrimaryScreen
            If Application.OpenForms.Count > 0 AndAlso Application.OpenForms(0).Visible Then
                scr = Screen.FromControl(Application.OpenForms(0))
            End If
        End If

        Dim y As Integer = scr.WorkingArea.Bottom - _options.MarginBottom

        For Each toastItem As frmToast In _visibleToasts
            If toastItem IsNot Nothing AndAlso Not toastItem.IsDisposed Then
                y -= toastItem.Height
                toastItem.TargetY = y
                y -= _options.Spacing
            End If
        Next
    End Sub

    Private Shared Sub AnimationTick(sender As Object, e As EventArgs)
        SyncLock _lock
            If _visibleToasts.Count = 0 Then Return

            For i As Integer = _visibleToasts.Count - 1 To 0 Step -1
                If i >= _visibleToasts.Count Then Continue For

                Dim toastItem As frmToast = _visibleToasts(i)

                If toastItem Is Nothing OrElse toastItem.IsDisposed OrElse Not toastItem.IsHandleCreated Then
                    _visibleToasts.RemoveAt(i)
                    Continue For
                End If

                ' 1) حركة الانزلاق العمودي (Slide Animation)
                If toastItem.Top < toastItem.TargetY Then
                    toastItem.Top = Math.Min(toastItem.Top + _options.AnimationSpeed, toastItem.TargetY)
                ElseIf toastItem.Top > toastItem.TargetY Then
                    toastItem.Top = Math.Max(toastItem.Top - _options.AnimationSpeed, toastItem.TargetY)
                End If

                ' 2) التلاشي للظهور (Fade In)
                If Not toastItem.IsClosing AndAlso toastItem.Opacity < 1.0 Then
                    toastItem.Opacity = Math.Min(toastItem.Opacity + _options.FadeSpeed, 1.0)
                End If

                ' 3) فحص انتهاء وقت الإشعار (مع مراعاة عدم الإغلاق إذا كان الماوس فوقه)
                If Not toastItem.IsClosing AndAlso toastItem.Model.AutoClose AndAlso Not toastItem.IsPaused Then
                    If (DateTime.Now - toastItem.Model.CreatedAt).TotalMilliseconds >= toastItem.Model.Duration Then
                        toastItem.IsClosing = True
                    End If
                End If

                ' 4) التلاشي للإخفاء (Fade Out)
                If toastItem.IsClosing Then
                    toastItem.Opacity -= _options.FadeSpeed

                    If toastItem.Opacity <= 0 Then
                        toastItem.Close()
                        toastItem.Dispose()
                        _visibleToasts.RemoveAt(i)
                        UpdateLayout()

                        ' تشغيل التوست التالي من قائمة الانتظار
                        If _queue.Count > 0 Then
                            Dim nextModel = _queue(0)
                            _queue.RemoveAt(0)
                            CreateToast(nextModel)
                        End If
                    End If
                End If
            Next
        End SyncLock
    End Sub

    Public Shared Sub CloseAll()
        SyncLock _lock
            For Each toastItem As frmToast In _visibleToasts.ToList()
                Try
                    toastItem.Close()
                    toastItem.Dispose()
                Catch
                End Try
            Next
            _visibleToasts.Clear()
            _queue.Clear()
        End SyncLock
    End Sub

    Public Shared Sub ShowSuccess(title As String, message As String)
        Show(New ToastModel With {.Type = Notify.ToastType.Success, .Title = title, .Message = message})
    End Sub

    Public Shared Sub ShowSuccess(message As String)
        Show(New ToastModel With {.Type = Notify.ToastType.Success, .Title = "تمت العملية بنجاح", .Message = message})
    End Sub

    Public Shared Sub ShowWarning(title As String, message As String)
        Show(New ToastModel With {.Type = Notify.ToastType.Warning, .Title = title, .Message = message})
    End Sub

    Public Shared Sub ShowWarning(message As String)
        Show(New ToastModel With {.Type = Notify.ToastType.Warning, .Title = "تنبيه", .Message = message})
    End Sub

    Public Shared Sub ShowError(title As String, message As String)
        Show(New ToastModel With {.Type = Notify.ToastType.[Error], .Title = title, .Message = message})
    End Sub

    Public Shared Sub ShowError(message As String)
        Show(New ToastModel With {.Type = Notify.ToastType.[Error], .Title = "خطأ", .Message = message})
    End Sub

    Public Shared Sub ShowInfo(title As String, message As String)
        Show(New ToastModel With {.Type = Notify.ToastType.Info, .Title = title, .Message = message})
    End Sub

    Public Shared Sub ShowInfo(message As String)
        Show(New ToastModel With {.Type = Notify.ToastType.Info, .Title = "إشعار", .Message = message})
    End Sub

End Class
