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
End Module