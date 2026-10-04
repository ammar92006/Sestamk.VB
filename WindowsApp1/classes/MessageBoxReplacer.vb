Imports System.Windows.Forms

''' <summary>
''' محول تلقائي لتحويل جميع MessageBox إلى Toast
''' يُضاف في بداية كل ملف أو في Imports العامة
''' </summary>
Public Module MessageBoxReplacer

    ''' <summary>
    ''' تفعيل/إيقاف استخدام Toast بدلاً من MessageBox
    ''' </summary>
    Public UseToastInsteadOfMessageBox As Boolean = True



    ''' <summary>
    ''' دالة مساعدة لعرض رسائل Success سريعة
    ''' </summary>
    Public Sub ShowSuccess(message As String)
        ToastHelper.Success(message)
    End Sub

    ''' <summary>
    ''' دالة مساعدة لعرض رسائل Error سريعة
    ''' </summary>
    Public Sub ShowError(message As String)
        ToastHelper.Error(message)
    End Sub

    ''' <summary>
    ''' دالة مساعدة لعرض رسائل Warning سريعة
    ''' </summary>
    Public Sub ShowWarning(message As String)
        ToastHelper.Warning(message)
    End Sub

    ''' <summary>
    ''' دالة مساعدة لعرض رسائل Info سريعة
    ''' </summary>
    Public Sub ShowInfo(message As String)
        ToastHelper.Info(message)
    End Sub

    ''' <summary>
    ''' دالة تأكيد سريعة
    ''' </summary>
    Public Function Confirm(message As String, Optional title As String = "تأكيد") As Boolean
        Dim result As DialogResult = SmartMessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return result = DialogResult.Yes
    End Function

End Module
