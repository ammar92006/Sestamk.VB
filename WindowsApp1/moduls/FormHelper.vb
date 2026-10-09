Public Module FormHelper

    ''' <summary>
    ''' تبديل حالة الفورم بين Normal و Maximized
    ''' </summary>
    Public Sub ToggleMaximize(frm As Form)

        If frm.WindowState = FormWindowState.Maximized Then
            frm.WindowState = FormWindowState.Normal
        Else
            frm.WindowState = FormWindowState.Maximized
        End If

    End Sub
    Public Sub Minimiz(frm As Form)
        frm.WindowState = FormWindowState.Minimized
    End Sub

    ''' <summary>
    ''' تفعيل تقنية الرسم المزدوج (Double Buffering) في الذاكرة الرسومية لكافة عناصر الفورم لمنع الوميض وتسريع الفتح والغلق
    ''' </summary>
    Public Sub EnableDoubleBuffering(ctrl As Control)
        If ctrl Is Nothing OrElse ctrl.IsDisposed Then Return
        Try
            Dim prop = GetType(Control).GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            If prop IsNot Nothing Then
                prop.SetValue(ctrl, True, Nothing)
            End If

            For Each child As Control In ctrl.Controls
                EnableDoubleBuffering(child)
            Next
        Catch
        End Try
    End Sub
End Module