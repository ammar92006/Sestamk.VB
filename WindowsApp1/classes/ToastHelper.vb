Imports System.Drawing

''' <summary>
''' مساعد Wrapper للربط السريع بين الأنظمة القديمة والجديدة
''' </summary>
Public Module ToastHelper

    ''' <summary>
    ''' عرض إشعار سريع بأسلوب بسيط
    ''' </summary>
    Public Sub ShowToast(message As String, Optional type As ToastType = ToastType.Success)
        ToastManagerAdvanced.Show(New ToastModelAdvanced With {
            .Type = type,
            .Title = GetDefaultTitle(type),
            .Message = message
        })
    End Sub

    ''' <summary>
    ''' عرض إشعار مع عنوان ورسالة
    ''' </summary>
    Public Sub ShowToast(title As String, message As String, Optional type As ToastType = ToastType.Success)
        ToastManagerAdvanced.Show(New ToastModelAdvanced With {
            .Type = type,
            .Title = title,
            .Message = message
        })
    End Sub

    ''' <summary>
    ''' عرض إشعار نجاح سريع
    ''' </summary>
    Public Sub Success(message As String)
        ToastManagerAdvanced.ShowSuccess("تمت العملية بنجاح", message)
    End Sub

    ''' <summary>
    ''' عرض إشعار خطأ سريع
    ''' </summary>
    Public Sub [Error](message As String)
        ToastManagerAdvanced.ShowError("خطأ", message)
    End Sub

    ''' <summary>
    ''' عرض إشعار تحذير سريع
    ''' </summary>
    Public Sub Warning(message As String)
        ToastManagerAdvanced.ShowWarning("تنبيه", message)
    End Sub

    ''' <summary>
    ''' عرض إشعار معلومة سريع
    ''' </summary>
    Public Sub Info(message As String)
        ToastManagerAdvanced.ShowInfo("إشعار", message)
    End Sub

    ''' <summary>
    ''' عرض إشعار مع زر تأكيد
    ''' </summary>
    Public Sub ShowConfirmToast(title As String, message As String, onConfirm As Action, Optional onCancel As Action = Nothing)
        Dim model As New ToastModelAdvanced With {
            .Type = ToastType.Question,
            .Title = title,
            .Message = message,
            .Duration = 10000,
            .AutoClose = False
        }

        model.Buttons.Add(New ToastButton With {
            .Text = "نعم",
            .BackColor = Color.FromArgb(34, 197, 94),
            .Action = onConfirm
        })

        If onCancel IsNot Nothing Then
            model.Buttons.Add(New ToastButton With {
                .Text = "لا",
                .BackColor = Color.FromArgb(239, 68, 68),
                .Action = onCancel
            })
        End If

        ToastManagerAdvanced.Show(model)
    End Sub

    ''' <summary>
    ''' عرض إشعار مع إجراء عند النقر
    ''' </summary>
    Public Sub ShowActionToast(title As String, message As String, action As Action, Optional type As ToastType = ToastType.Info)
        ToastManagerAdvanced.Show(New ToastModelAdvanced With {
            .Type = type,
            .Title = title,
            .Message = message,
            .ClickAction = action,
            .Duration = 8000
        })
    End Sub

    ''' <summary>
    ''' عرض إشعار ثابت (لا يختفي تلقائياً)
    ''' </summary>
    Public Sub ShowStickyToast(title As String, message As String, Optional type As ToastType = ToastType.Info)
        ToastManagerAdvanced.Show(New ToastModelAdvanced With {
            .Type = type,
            .Title = title,
            .Message = message,
            .IsSticky = True,
            .AutoClose = False
        })
    End Sub

    ''' <summary>
    ''' عرض إشعار في موضع محدد
    ''' </summary>
    Public Sub ShowToastAt(title As String, message As String, position As ToastPosition, Optional type As ToastType = ToastType.Info)
        ToastManagerAdvanced.Show(New ToastModelAdvanced With {
            .Type = type,
            .Title = title,
            .Message = message,
            .Position = position
        })
    End Sub

    ''' <summary>
    ''' عرض إشعار مع Progress Bar
    ''' </summary>
    Public Sub ShowProgressToast(title As String, message As String, Optional type As ToastType = ToastType.Info)
        ToastManagerAdvanced.Show(New ToastModelAdvanced With {
            .Type = type,
            .Title = title,
            .Message = message,
            .ShowProgressBar = True,
            .Duration = 5000
        })
    End Sub

    ''' <summary>
    ''' الحصول على العنوان الافتراضي حسب النوع
    ''' </summary>
    Private Function GetDefaultTitle(type As ToastType) As String
        Select Case type
            Case ToastType.Success : Return "تمت العملية بنجاح"
            Case ToastType.Warning : Return "تنبيه"
            Case ToastType.Error : Return "خطأ"
            Case ToastType.Question : Return "سؤال"
            Case Else : Return "إشعار"
        End Select
    End Function

End Module
