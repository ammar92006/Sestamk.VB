Imports System.Diagnostics

Module ServerManager

    Public NodeProcess As Process = Nothing

    ' تشغيل السيرفر
    Public Sub StartServer()

        If NodeProcess IsNot Nothing AndAlso Not NodeProcess.HasExited Then Exit Sub

        Dim p As New ProcessStartInfo()
        p.FileName = "C:\Program Files\nodejs\node.exe"
        p.Arguments = "index.js"
        p.WorkingDirectory = Application.StartupPath + "\whatsapp-server"
        p.CreateNoWindow = True
        p.UseShellExecute = False
        p.WindowStyle = ProcessWindowStyle.Hidden

        NodeProcess = Process.Start(p)
    End Sub

    ' إيقاف السيرفر
    Public Sub StopServer()

        Try
            If NodeProcess IsNot Nothing AndAlso Not NodeProcess.HasExited Then
                NodeProcess.Kill()
                NodeProcess.WaitForExit(2000)
                NodeProcess = Nothing
            End If
        Catch __logEx As Exception
            Logger.LogError("ServerManager.vb:32", __logEx)
        End Try

    End Sub

End Module
