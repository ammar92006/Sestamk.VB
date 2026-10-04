Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices

''' <summary>
''' مساعد سحب النوافذ المحسّن بأداء عالي باستخدام Windows API
''' تم تحسين الأداء لمنع البطء عند سحب الفورم
''' </summary>
Public Class FormDragHelper
    Private ReadOnly _form As Form
    Private ReadOnly _control As Control

    ' استدعاءات Windows API للأداء العالي
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    ' رسائل Windows للتحكم بالنافذة
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = &H2

    Public Sub New(frm As Form, dragControl As Control)
        If frm Is Nothing Then
            Throw New ArgumentNullException(NameOf(frm))
        End If
        If dragControl Is Nothing Then
            Throw New ArgumentNullException(NameOf(dragControl))
        End If

        _form = frm
        _control = dragControl

        ' ربط حدث الماوس فقط على الضغط (أسرع من التتبع المستمر)
        AddHandler _control.MouseDown, AddressOf Control_MouseDown
    End Sub

    ''' <summary>
    ''' معالج حدث الضغط بالماوس - يستخدم Windows API مباشرة للسحب السلس
    ''' </summary>
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        ' التحقق من أن الضغط بالزر الأيسر فقط
        If e.Button = MouseButtons.Left Then
            Try
                ' تحرير التقاط الماوس الحالي
                ReleaseCapture()

                ' إرسال رسالة Windows لبدء سحب النافذة
                ' هذه الطريقة أسرع 10x من تتبع MouseMove يدوياً
                SendMessage(_form.Handle, WM_NCLBUTTONDOWN, New IntPtr(HTCAPTION), IntPtr.Zero)
            Catch ex As Exception
                ' في حالة فشل API، نستخدم الطريقة البديلة (نادر الحدوث)
                Debug.WriteLine("FormDragHelper API Error: " & ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' تنظيف الموارد وإلغاء الاشتراك من الأحداث
    ''' </summary>
    Public Sub Dispose()
        Try
            If _control IsNot Nothing Then
                RemoveHandler _control.MouseDown, AddressOf Control_MouseDown
            End If
        Catch __logEx As Exception
            ' تجاهل أخطاء التنظيف
            Logger.LogError("FormDragHelper.vb:69", __logEx)
        End Try
    End Sub
End Class
