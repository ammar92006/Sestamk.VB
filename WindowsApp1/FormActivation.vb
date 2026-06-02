Imports Newtonsoft.Json.Linq

Public Class FormActivation
    Dim x, y As Integer
    Dim newpoint As New Point
    Private Sub btn_Staff_Click(sender As Object, e As EventArgs) Handles btn_Staff.Click
        Dim key As String = txtLicense.Text.Trim()
        Dim hwid As String = CheckActivation.GetHWID()

        ' محاولة التفعيل (يتحقق من الإنترنت أو fallback على الملف المحلي)
        Dim isOnline As Boolean = False
        Dim result As JObject = Nothing

        Try
            ' تحقق من الإنترنت
            If My.Computer.Network.IsAvailable Then
                ' استخدم الدالة العامة IsActivated مع تحديث الملف
                result = CheckActivation.ValidateLicenseOnline(key, hwid)
                isOnline = True
            End If
        Catch
            isOnline = False
        End Try

        ' افحص النتيجة
        Dim success As Boolean = False
        Dim valid As Boolean = False
        Dim signature As String = ""

        If isOnline AndAlso result IsNot Nothing Then
            success = result("success").ToObject(Of Boolean)
            valid = If(result("payload")?("valid") IsNot Nothing, result("payload")("valid").ToObject(Of Boolean), False)
            signature = If(result("signature") IsNot Nothing, result("signature").ToString(), "")
        Else
            ' لو مفيش نت، افحص الملف المحلي فقط
            Dim saved = CheckActivation.LoadActivationFile()
            If saved.Item1 IsNot Nothing AndAlso saved.Item2 IsNot Nothing Then
                success = True
                valid = True
                signature = saved.Item2
            End If
        End If

        ' إذا التفعيل ناجح
        If success AndAlso valid Then
            ' حفظ الملف المشفر (لو متاح signature من السيرفر)
            If signature <> "" Then
                CheckActivation.SaveActivationFile(key, signature)
            End If

            MsgBox("تم تفعيل البرنامج بنجاح!", vbInformation)
            Me.Close()
        Else
            MsgBox("مفتاح غير صحيح أو غير مفعل!", vbCritical)
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub
    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub
End Class