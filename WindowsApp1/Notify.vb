Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' نظام الإشعارات والتنبيهات الموحد (Toast) المتوافق تماماً مع Sestamk_App.
''' يعرض كروت إشعارات عصرية داكنة بستايل Guna2 تنزلق بسلاسة أسفل يمين الشاشة.
''' </summary>
Public Module Notify

    Public Enum ToastType
        Info
        Success
        [Warning]
        [Error]
    End Enum

    ''' <summary>
    ''' إشعار سريع يختفي تلقائياً مع تحديد الرسالة والنوع والمدة
    ''' </summary>
    Public Sub Toast(message As String, Optional type As ToastType = ToastType.Success, Optional ms As Integer = 3800)
        Dim defaultTitle As String
        Select Case type
            Case ToastType.Success : defaultTitle = "تمت العملية بنجاح"
            Case ToastType.Warning : defaultTitle = "تنبيه"
            Case ToastType.[Error] : defaultTitle = "خطأ"
            Case Else : defaultTitle = "إشعار"
        End Select

        Toast(defaultTitle, message, type, ms)
    End Sub

    ''' <summary>
    ''' إشعار مخصص مع عنوان ورسالة ونوع ومدة
    ''' </summary>
    Public Sub Toast(title As String, message As String, Optional type As ToastType = ToastType.Success, Optional ms As Integer = 3800)
        Try
            ' تشغيل الصوت إذا كان مفعلاً في الإعدادات
            PlayNotificationSound(type)

            Dim model As New ToastModel With {
                .Type = type,
                .Title = title,
                .Message = message,
                .Duration = ms
            }
            ToastManager.Show(model)
        Catch __logEx As Exception
            Logger.LogError("Notify.vb:47", __logEx)
        End Try
    End Sub

    ''' <summary>
    ''' إشعار مخصص مع إجراء تفاعلي قابل للنقر (Click Action)
    ''' </summary>
    Public Sub ToastWithAction(title As String, message As String, action As Action, Optional type As ToastType = ToastType.Info, Optional ms As Integer = 10000)
        Try
            PlayNotificationSound(type)

            Dim model As New ToastModel With {
                .Type = type,
                .Title = title,
                .Message = message,
                .Duration = ms,
                .ClickAction = action
            }
            ToastManager.Show(model)
        Catch __logEx As Exception
            Logger.LogError("Notify.vb:67", __logEx)
        End Try
    End Sub

    Public Sub ShowSuccess(message As String, Optional title As String = "تمت العملية بنجاح")
        Toast(title, message, ToastType.Success)
    End Sub

    Public Sub ShowWarning(message As String, Optional title As String = "تنبيه")
        Toast(title, message, ToastType.Warning)
    End Sub

    Public Sub ShowError(message As String, Optional title As String = "خطأ")
        Toast(title, message, ToastType.[Error])
    End Sub

    Public Sub ShowInfo(message As String, Optional title As String = "إشعار")
        Toast(title, message, ToastType.Info)
    End Sub

    Public Sub CloseAll()
        ToastManager.CloseAll()
    End Sub

    Private Sub PlayNotificationSound(type As ToastType)
        Try
            If type = ToastType.Success OrElse type = ToastType.Info Then
                If SettingsManager.GetBoolSetting(SettingsKeys.NotificationNewOrderSound, True) Then
                    System.Media.SystemSounds.Asterisk.Play()
                End If
            ElseIf type = ToastType.Warning OrElse type = ToastType.[Error] Then
                If SettingsManager.GetBoolSetting(SettingsKeys.NotificationErrorSound, True) Then
                    System.Media.SystemSounds.Exclamation.Play()
                End If
            End If
        Catch __logEx As Exception
            Logger.LogError("Notify.vb:103", __logEx)
        End Try
    End Sub

    ''' <summary>رسالة تأكيد (نعم/لا) موحّدة — ترجع True لو وافق المستخدم</summary>
    Public Function Confirm(message As String, Optional title As String = "تأكيد") As Boolean
        ' استخدام Toast بدلاً من MessageBox
        Return MessageBoxReplacer.Confirm(message, title)
    End Function

    ''' <summary>رسالة خطأ موحّدة (للأخطاء التي يجب أن يراها المستخدم)</summary>
    Public Sub [Error](message As String, Optional title As String = "خطأ")
        ' استخدام Toast بدلاً من MessageBox
        ToastHelper.ShowToast(title, message, ToastType.Error)
    End Sub

End Module
