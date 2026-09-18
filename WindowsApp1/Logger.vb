Imports System.IO
Imports System.Runtime.CompilerServices

''' <summary>
''' نظام تسجيل شامل للبرنامج — يحل محل MsgBox في معظم الحالات.
''' يدعم مستويات متعددة (Debug, Info, Warning, Error, Critical)
''' ويوفر دوال مساعدة لعرض إشعارات Toast بدل الرسائل المزعجة.
''' 
''' الاستخدام:
'''   Logger.Info("تم حفظ الفاتورة بنجاح")                    ' تسجيل فقط
'''   Logger.Warn("المخزون منخفض", "المنتجات")                 ' تسجيل مع سياق
'''   Logger.LogAndNotify("تم الحفظ", Notify.ToastType.Success) ' تسجيل + Toast
'''   Logger.LogError("SaveInvoice", ex)                        ' تسجيل خطأ مع Stack Trace
'''   Logger.Critical("فشل الاتصال", ex)                       ' تسجيل + رسالة للمستخدم
''' </summary>
Public Module Logger

    ' ── المستويات ──
    Public Enum LogLevel
        Debug = 0
        Info = 1
        Warning = 2
        [Error] = 3
        Critical = 4
    End Enum

    ' ── الإعدادات ──
    Private ReadOnly LogDir As String = Path.Combine(Application.StartupPath, "logs")
    Private ReadOnly _lock As New Object()
    Private Const MAX_LOG_DAYS As Integer = 30  ' عدد الأيام للاحتفاظ بالملفات
    Private _lastCleanup As Date = Date.MinValue

    ' ── الحد الأدنى للتسجيل (يمكن تغييره عند التشغيل) ──
    Public Property MinLevel As LogLevel = LogLevel.Debug

    ' ══════════════════════════════════════════════════════════
    ' الدوال الأساسية للتسجيل حسب المستوى
    ' ══════════════════════════════════════════════════════════

    ''' <summary>تسجيل رسالة تصحيح (للمطورين فقط)</summary>
    Public Sub LogDebug(message As String,
                        <CallerMemberName> Optional caller As String = "",
                        <CallerFilePath> Optional filePath As String = "")
        WriteLog(LogLevel.Debug, message, caller, filePath)
    End Sub

    ''' <summary>تسجيل معلومة عامة</summary>
    Public Sub Info(message As String,
                    <CallerMemberName> Optional caller As String = "",
                    <CallerFilePath> Optional filePath As String = "")
        WriteLog(LogLevel.Info, message, caller, filePath)
    End Sub

    ''' <summary>تسجيل تحذير</summary>
    Public Sub Warn(message As String,
                    <CallerMemberName> Optional caller As String = "",
                    <CallerFilePath> Optional filePath As String = "")
        WriteLog(LogLevel.Warning, message, caller, filePath)
    End Sub

    ''' <summary>تسجيل خطأ مع Exception</summary>
    Public Sub LogError(context As String, ex As Exception,
                        <CallerMemberName> Optional caller As String = "",
                        <CallerFilePath> Optional filePath As String = "")
        Dim msg As String =
            "Context : " & context & vbCrLf &
            "Message : " & ex.Message & vbCrLf &
            "Source  : " & If(ex.Source, "") & vbCrLf &
            "Stack   : " & vbCrLf & If(ex.StackTrace, "")

        ' تسجيل InnerException لو موجود
        If ex.InnerException IsNot Nothing Then
            msg &= vbCrLf & "Inner   : " & ex.InnerException.Message
        End If

        WriteLog(LogLevel.[Error], msg, caller, filePath)
    End Sub

    ''' <summary>تسجيل خطأ مع Exception مباشرة (يستخرج السياق تلقائياً)</summary>
    Public Sub LogError(ex As Exception,
                        <CallerMemberName> Optional caller As String = "",
                        <CallerFilePath> Optional filePath As String = "")
        LogError(If(String.IsNullOrEmpty(caller), "Error", caller), ex, caller, filePath)
    End Sub

    ''' <summary>تسجيل خطأ حرج — يُسجّل ويعرض رسالة للمستخدم</summary>
    Public Sub Critical(message As String, Optional ex As Exception = Nothing,
                        <CallerMemberName> Optional caller As String = "",
                        <CallerFilePath> Optional filePath As String = "")
        Dim fullMsg As String = message
        If ex IsNot Nothing Then
            fullMsg &= vbCrLf & "Exception: " & ex.Message
            If ex.InnerException IsNot Nothing Then
                fullMsg &= vbCrLf & "Inner: " & ex.InnerException.Message
            End If
            fullMsg &= vbCrLf & "Stack: " & If(ex.StackTrace, "")
        End If

        WriteLog(LogLevel.Critical, fullMsg, caller, filePath)

        ' عرض رسالة للمستخدم (الأخطاء الحرجة فقط تستحق MessageBox)
        Try
            MessageBox.Show(
                message & If(ex IsNot Nothing, vbCrLf & ex.Message, ""),
                "خطأ حرج",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════════
    ' دوال مع إشعارات (بديل MsgBox)
    ' ══════════════════════════════════════════════════════════

    ''' <summary>
    ''' تسجيل + عرض Toast إشعار هادئ (بديل MsgBox للرسائل الروتينية)
    ''' </summary>
    Public Sub LogAndNotify(message As String,
                            Optional toastType As Notify.ToastType = Notify.ToastType.Info,
                            Optional level As LogLevel = LogLevel.Info,
                            <CallerMemberName> Optional caller As String = "",
                            <CallerFilePath> Optional filePath As String = "")
        WriteLog(level, message, caller, filePath)
        Try
            Notify.Toast(message, toastType)
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' تسجيل + عرض MessageBox (للأخطاء التي يجب أن يراها المستخدم)
    ''' </summary>
    Public Sub LogAndShow(message As String,
                          Optional title As String = "تنبيه",
                          Optional icon As MessageBoxIcon = MessageBoxIcon.Warning,
                          Optional level As LogLevel = LogLevel.[Error],
                          <CallerMemberName> Optional caller As String = "",
                          <CallerFilePath> Optional filePath As String = "")
        WriteLog(level, message, caller, filePath)
        Try
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon)
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' تسجيل خطأ + عرض Toast خطأ (بديل MsgBox للأخطاء غير الحرجة)
    ''' </summary>
    Public Sub LogErrorAndNotify(context As String, ex As Exception,
                                 Optional userMessage As String = "",
                                 <CallerMemberName> Optional caller As String = "",
                                 <CallerFilePath> Optional filePath As String = "")
        LogError(context, ex, caller, filePath)
        Try
            Dim display As String = If(String.IsNullOrEmpty(userMessage),
                                      "حدث خطأ: " & ex.Message, userMessage)
            Notify.Toast(display, Notify.ToastType.[Error], 4000)
        Catch
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════════
    ' معلومات مسار ملف اللوج (للدعم الفني)
    ' ══════════════════════════════════════════════════════════

    ''' <summary>مسار ملف اللوج لليوم الحالي</summary>
    Public ReadOnly Property TodayLogPath As String
        Get
            Return Path.Combine(LogDir, "app_" & DateTime.Now.ToString("yyyy-MM-dd") & ".log")
        End Get
    End Property

    ''' <summary>مسار مجلد اللوجات</summary>
    Public ReadOnly Property LogDirectory As String
        Get
            Return LogDir
        End Get
    End Property

    ' ══════════════════════════════════════════════════════════
    ' الكتابة الفعلية في الملف (Thread-Safe)
    ' ══════════════════════════════════════════════════════════

    Private Sub WriteLog(level As LogLevel, message As String,
                         caller As String, filePath As String)
        If level < MinLevel Then Return

        Try
            SyncLock _lock
                If Not Directory.Exists(LogDir) Then Directory.CreateDirectory(LogDir)

                ' استخراج اسم الملف بدون المسار الكامل
                Dim source As String = ""
                If Not String.IsNullOrEmpty(filePath) Then
                    source = Path.GetFileNameWithoutExtension(filePath)
                End If
                If Not String.IsNullOrEmpty(caller) Then
                    source = If(source <> "", source & ".", "") & caller
                End If

                Dim levelTag As String = GetLevelTag(level)
                Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")

                Dim line As String =
                    $"[{timestamp}] [{levelTag}]" &
                    If(source <> "", $" [{source}]", "") &
                    $" {message}" & vbCrLf

                ' فاصل بصري للأخطاء والحرجة
                If level >= LogLevel.[Error] Then
                    line = "──────────────────────────────────────────" & vbCrLf & line
                End If

                File.AppendAllText(TodayLogPath, line)

                ' تنظيف الملفات القديمة (مرة واحدة في اليوم)
                If _lastCleanup.Date <> DateTime.Now.Date Then
                    _lastCleanup = DateTime.Now
                    CleanOldLogs()
                End If
            End SyncLock
        Catch
            ' التسجيل يجب ألا يُسبب خطأً بدوره
        End Try
    End Sub

    Private Function GetLevelTag(level As LogLevel) As String
        Select Case level
            Case LogLevel.Debug : Return "DEBUG"
            Case LogLevel.Info : Return "INFO "
            Case LogLevel.Warning : Return "WARN "
            Case LogLevel.[Error] : Return "ERROR"
            Case LogLevel.Critical : Return "CRIT "
            Case Else : Return "?????" 
        End Select
    End Function

    ' ══════════════════════════════════════════════════════════
    ' تنظيف ملفات اللوج القديمة
    ' ══════════════════════════════════════════════════════════

    Private Sub CleanOldLogs()
        Try
            Dim cutoff As Date = DateTime.Now.AddDays(-MAX_LOG_DAYS)
            For Each f As String In Directory.GetFiles(LogDir, "*.log")
                Try
                    If File.GetLastWriteTime(f) < cutoff Then
                        File.Delete(f)
                    End If
                Catch
                    ' تجاهل — قد يكون الملف مقفل
                End Try
            Next
        Catch
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════════
    ' دالة مساعدة للتوافق مع الكود القديم (LogInfo)
    ' ══════════════════════════════════════════════════════════

    ''' <summary>تسجيل معلومة — متوافق مع الاستدعاءات القديمة</summary>
    Public Sub LogInfo(message As String)
        WriteLog(LogLevel.Info, message, "", "")
    End Sub

End Module
