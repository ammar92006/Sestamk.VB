Imports System.Windows.Forms

''' <summary>
''' بديل ذكي لـ MessageBox يستخدم Toast Notification تلقائياً
''' يحافظ على نفس الـ API للتوافق الكامل
''' </summary>
Public Module SmartMessageBox

    ''' <summary>
    ''' عرض رسالة (بديل MessageBox.Show)
    ''' </summary>
    Public Function Show(text As String) As DialogResult
        ToastHelper.ShowToast(text, ToastType.Info)
        Return DialogResult.OK
    End Function

    ''' <summary>
    ''' عرض رسالة مع عنوان
    ''' </summary>
    Public Function Show(text As String, caption As String) As DialogResult
        ToastHelper.ShowToast(caption, text, ToastType.Info)
        Return DialogResult.OK
    End Function

    ''' <summary>
    ''' عرض رسالة مع عنوان وأزرار
    ''' </summary>
    Public Function Show(text As String, caption As String, buttons As MessageBoxButtons) As DialogResult
        Return ShowWithButtons(text, caption, buttons, MessageBoxIcon.None)
    End Function

    ''' <summary>
    ''' عرض رسالة مع عنوان وأزرار وأيقونة
    ''' </summary>
    Public Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
        Return ShowWithButtons(text, caption, buttons, icon)
    End Function

    ''' <summary>
    ''' عرض رسالة مع عنوان وأزرار وأيقونة وزر افتراضي
    ''' </summary>
    Public Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton) As DialogResult
        If buttons = MessageBoxButtons.OK Then
            Return ShowWithButtons(text, caption, buttons, icon)
        Else
            Return MessageBox.Show(text, caption, buttons, icon, defaultButton)
        End If
    End Function

    ''' <summary>
    ''' عرض رسالة مع خيارات متقدمة
    ''' </summary>
    Public Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton, options As MessageBoxOptions) As DialogResult
        If buttons = MessageBoxButtons.OK Then
            Return ShowWithButtons(text, caption, buttons, icon)
        Else
            Return MessageBox.Show(text, caption, buttons, icon, defaultButton, options)
        End If
    End Function

    ' ── Overloads مع IWin32Window owner ──

    Public Function Show(owner As IWin32Window, text As String) As DialogResult
        Return Show(text)
    End Function

    Public Function Show(owner As IWin32Window, text As String, caption As String) As DialogResult
        Return Show(text, caption)
    End Function

    Public Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons) As DialogResult
        If buttons = MessageBoxButtons.OK Then
            Return Show(text, caption, buttons)
        Else
            Return MessageBox.Show(owner, text, caption, buttons)
        End If
    End Function

    Public Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
        If buttons = MessageBoxButtons.OK Then
            Return ShowWithButtons(text, caption, buttons, icon)
        Else
            Return MessageBox.Show(owner, text, caption, buttons, icon)
        End If
    End Function

    Public Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton) As DialogResult
        If buttons = MessageBoxButtons.OK Then
            Return ShowWithButtons(text, caption, buttons, icon)
        Else
            Return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton)
        End If
    End Function

    Public Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton, options As MessageBoxOptions) As DialogResult
        If buttons = MessageBoxButtons.OK Then
            Return ShowWithButtons(text, caption, buttons, icon)
        Else
            Return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options)
        End If
    End Function

    ''' <summary>
    ''' المعالج الرئيسي للرسائل مع الأزرار
    ''' </summary>
    Private Function ShowWithButtons(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
        If buttons = MessageBoxButtons.OK Then
            Dim toastType As ToastType = GetToastTypeFromIcon(icon)
            ToastHelper.ShowToast(caption, text, toastType)
            Return DialogResult.OK
        Else
            ' الرسائل التي تتطلب قراراً من المستخدم (نعم/لا، إلغاء، إعادة المحاولة) تتطلب نافذة مشروطة Modal
            Return MessageBox.Show(text, caption, buttons, icon)
        End If
    End Function

    ''' <summary>
    ''' تحويل أيقونة MessageBox إلى ToastType
    ''' </summary>
    Private Function GetToastTypeFromIcon(icon As MessageBoxIcon) As ToastType
        Select Case icon
            Case MessageBoxIcon.Information, MessageBoxIcon.Asterisk
                Return ToastType.Info
            Case MessageBoxIcon.Warning, MessageBoxIcon.Exclamation
                Return ToastType.Warning
            Case MessageBoxIcon.Error, MessageBoxIcon.Hand, MessageBoxIcon.Stop
                Return ToastType.Error
            Case MessageBoxIcon.Question
                Return ToastType.Question
            Case Else
                Return ToastType.Info
        End Select
    End Function

    ''' <summary>
    ''' عرض Toast مع أزرار OK/Cancel
    ''' </summary>
    Private Function ShowOKCancelToast(caption As String, text As String, toastType As ToastType) As DialogResult
        Dim result As DialogResult = DialogResult.Cancel
        Dim resultSet As Boolean = False

        Dim model As New ToastModelAdvanced With {
            .Type = toastType,
            .Title = caption,
            .Message = text,
            .Duration = 10000,
            .AutoClose = False,
            .Position = ToastPosition.Center
        }

        model.Buttons.Add(New ToastButton With {
            .Text = "موافق",
            .BackColor = Color.FromArgb(34, 197, 94),
            .Action = Sub()
                          result = DialogResult.OK
                          resultSet = True
                      End Sub
        })

        model.Buttons.Add(New ToastButton With {
            .Text = "إلغاء",
            .BackColor = Color.FromArgb(125, 137, 149),
            .Action = Sub()
                          result = DialogResult.Cancel
                          resultSet = True
                      End Sub
        })

        ToastManagerAdvanced.Show(model)

        ' انتظار قصير للسماح بالتفاعل
        System.Threading.Thread.Sleep(100)

        ' إذا لم يتم التفاعل، نرجع Cancel
        Return If(resultSet, result, DialogResult.Cancel)
    End Function

    ''' <summary>
    ''' عرض Toast مع أزرار Yes/No
    ''' </summary>
    Private Function ShowYesNoToast(caption As String, text As String, toastType As ToastType) As DialogResult
        Dim result As DialogResult = DialogResult.No
        Dim resultSet As Boolean = False

        Dim model As New ToastModelAdvanced With {
            .Type = toastType,
            .Title = caption,
            .Message = text,
            .Duration = 10000,
            .AutoClose = False,
            .Position = ToastPosition.Center
        }

        model.Buttons.Add(New ToastButton With {
            .Text = "نعم",
            .BackColor = Color.FromArgb(34, 197, 94),
            .Action = Sub()
                          result = DialogResult.Yes
                          resultSet = True
                      End Sub
        })

        model.Buttons.Add(New ToastButton With {
            .Text = "لا",
            .BackColor = Color.FromArgb(239, 68, 68),
            .Action = Sub()
                          result = DialogResult.No
                          resultSet = True
                      End Sub
        })

        ToastManagerAdvanced.Show(model)
        System.Threading.Thread.Sleep(100)
        Return If(resultSet, result, DialogResult.No)
    End Function

    ''' <summary>
    ''' عرض Toast مع أزرار Yes/No/Cancel
    ''' </summary>
    Private Function ShowYesNoCancelToast(caption As String, text As String, toastType As ToastType) As DialogResult
        Dim result As DialogResult = DialogResult.Cancel
        Dim resultSet As Boolean = False

        Dim model As New ToastModelAdvanced With {
            .Type = toastType,
            .Title = caption,
            .Message = text,
            .Duration = 15000,
            .AutoClose = False,
            .Position = ToastPosition.Center,
            .Width = 400
        }

        model.Buttons.Add(New ToastButton With {
            .Text = "نعم",
            .BackColor = Color.FromArgb(34, 197, 94),
            .Action = Sub()
                          result = DialogResult.Yes
                          resultSet = True
                      End Sub
        })

        model.Buttons.Add(New ToastButton With {
            .Text = "لا",
            .BackColor = Color.FromArgb(239, 68, 68),
            .Action = Sub()
                          result = DialogResult.No
                          resultSet = True
                      End Sub
        })

        model.Buttons.Add(New ToastButton With {
            .Text = "إلغاء",
            .BackColor = Color.FromArgb(125, 137, 149),
            .Action = Sub()
                          result = DialogResult.Cancel
                          resultSet = True
                      End Sub
        })

        ToastManagerAdvanced.Show(model)
        System.Threading.Thread.Sleep(100)
        Return If(resultSet, result, DialogResult.Cancel)
    End Function

    ''' <summary>
    ''' عرض Toast مع أزرار Retry/Cancel
    ''' </summary>
    Private Function ShowRetryCancelToast(caption As String, text As String, toastType As ToastType) As DialogResult
        Dim result As DialogResult = DialogResult.Cancel
        Dim resultSet As Boolean = False

        Dim model As New ToastModelAdvanced With {
            .Type = toastType,
            .Title = caption,
            .Message = text,
            .Duration = 10000,
            .AutoClose = False,
            .Position = ToastPosition.Center
        }

        model.Buttons.Add(New ToastButton With {
            .Text = "إعادة المحاولة",
            .BackColor = Color.FromArgb(59, 130, 246),
            .Action = Sub()
                          result = DialogResult.Retry
                          resultSet = True
                      End Sub
        })

        model.Buttons.Add(New ToastButton With {
            .Text = "إلغاء",
            .BackColor = Color.FromArgb(125, 137, 149),
            .Action = Sub()
                          result = DialogResult.Cancel
                          resultSet = True
                      End Sub
        })

        ToastManagerAdvanced.Show(model)
        System.Threading.Thread.Sleep(100)
        Return If(resultSet, result, DialogResult.Cancel)
    End Function

    ''' <summary>
    ''' عرض Toast مع أزرار Abort/Retry/Ignore
    ''' </summary>
    Private Function ShowAbortRetryIgnoreToast(caption As String, text As String, toastType As ToastType) As DialogResult
        Dim result As DialogResult = DialogResult.Abort
        Dim resultSet As Boolean = False

        Dim model As New ToastModelAdvanced With {
            .Type = toastType,
            .Title = caption,
            .Message = text,
            .Duration = 15000,
            .AutoClose = False,
            .Position = ToastPosition.Center,
            .Width = 420
        }

        model.Buttons.Add(New ToastButton With {
            .Text = "إيقاف",
            .BackColor = Color.FromArgb(239, 68, 68),
            .Action = Sub()
                          result = DialogResult.Abort
                          resultSet = True
                      End Sub
        })

        model.Buttons.Add(New ToastButton With {
            .Text = "إعادة",
            .BackColor = Color.FromArgb(59, 130, 246),
            .Action = Sub()
                          result = DialogResult.Retry
                          resultSet = True
                      End Sub
        })

        model.Buttons.Add(New ToastButton With {
            .Text = "تجاهل",
            .BackColor = Color.FromArgb(125, 137, 149),
            .Action = Sub()
                          result = DialogResult.Ignore
                          resultSet = True
                      End Sub
        })

        ToastManagerAdvanced.Show(model)
        System.Threading.Thread.Sleep(100)
        Return If(resultSet, result, DialogResult.Abort)
    End Function

    ''' <summary>
    ''' عرض رسالة MessageBox حقيقية (للحالات الحرجة فقط)
    ''' </summary>
    Public Function ShowReal(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
        Return MessageBox.Show(text, caption, buttons, icon)
    End Function

End Module
