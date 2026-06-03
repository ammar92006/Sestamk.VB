Imports System.IO

''' <summary>
''' مُسجّل أخطاء بسيط: يكتب الأخطاء في ملف نصّي داخل مجلد البرنامج (logs)
''' حتى يمكن تشخيص أي مشكلة لاحقاً بدون إزعاج المستخدم برسائل تقنية.
''' </summary>
Public Module Logger

    Private ReadOnly LogDir As String = Path.Combine(Application.StartupPath, "logs")

    Public Sub LogError(context As String, ex As Exception)
        Try
            If Not Directory.Exists(LogDir) Then Directory.CreateDirectory(LogDir)
            Dim filePath As String = Path.Combine(LogDir, "error_" & DateTime.Now.ToString("yyyy-MM-dd") & ".log")
            Dim line As String =
                "──────────────────────────────────────────" & vbCrLf &
                "[" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "] " & context & vbCrLf &
                "Message: " & ex.Message & vbCrLf &
                "Source : " & If(ex.Source, "") & vbCrLf &
                "Stack  : " & vbCrLf & If(ex.StackTrace, "") & vbCrLf
            File.AppendAllText(filePath, line)
        Catch
            ' لا شيء — التسجيل يجب ألا يُسبب خطأً بدوره
        End Try
    End Sub

    Public Sub LogInfo(message As String)
        Try
            If Not Directory.Exists(LogDir) Then Directory.CreateDirectory(LogDir)
            Dim filePath As String = Path.Combine(LogDir, "info_" & DateTime.Now.ToString("yyyy-MM-dd") & ".log")
            File.AppendAllText(filePath, "[" & DateTime.Now.ToString("HH:mm:ss") & "] " & message & vbCrLf)
        Catch
        End Try
    End Sub

End Module
