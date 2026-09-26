Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        ''' <summary>
        ''' معالج الأخطاء غير المتوقّعة: بدل أن يُغلق البرنامج فجأة، نسجّل الخطأ
        ''' ونعرض رسالة عربية ودّية ونترك المستخدم يكمل عمله إن أمكن.
        ''' لو حدث الخطأ قبل فتح أي نافذة، نغلق البرنامج لمنع بقائه في الخلفية.
        ''' </summary>
        Private Sub MyApplication_UnhandledException(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try
                Logger.LogError("UnhandledException", e.Exception)
            Catch
            End Try
            Try
                Dim errorDetails As String = If(e.Exception IsNot Nothing, vbCrLf & "التفاصيل: " & e.Exception.Message, "")
                MessageBox.Show(
                    "حدث خطأ غير متوقّع، وتم تسجيله تلقائياً." & vbCrLf &
                    "يمكنك متابعة العمل، وإن تكرّر الخطأ أعد تشغيل البرنامج." & errorDetails,
                    "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Catch
            End Try

            ' منع إغلاق البرنامج فقط إذا كانت هناك نوافذ مفتوحة فعلاً
            ' أما إذا حدث الخطأ أثناء الإقلاع وقبل ظهور أي نافذة فيجب إنهاء العملية فوراً لمنع بقاء عملية معلقة في الخلفية
            If System.Windows.Forms.Application.OpenForms.Count > 0 Then
                e.ExitApplication = False
            Else
                e.ExitApplication = True
            End If
        End Sub

        ''' <summary>
        ''' عند محاولة فتح البرنامج مرة ثانية وهو يعمل بالفعل، نجلب النافذة النشطة للأمام
        ''' </summary>
        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            Try
                e.BringToForeground = True
                Dim targetForm As Form = If(MainForm IsNot Nothing AndAlso Not MainForm.IsDisposed, MainForm, Nothing)
                If targetForm Is Nothing AndAlso System.Windows.Forms.Application.OpenForms.Count > 0 Then
                    targetForm = System.Windows.Forms.Application.OpenForms(System.Windows.Forms.Application.OpenForms.Count - 1)
                End If
                If targetForm IsNot Nothing Then
                    If targetForm.WindowState = FormWindowState.Minimized Then
                        targetForm.WindowState = FormWindowState.Normal
                    End If
                    targetForm.Activate()
                    targetForm.BringToFront()
                End If
            Catch
            End Try
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Try
                ' تهيئة نظام الـ Theme قبل فتح أي فورم لضمان عدم حدوث وميض في الألوان
                ThemeManager.Instance.Initialize()

                ' مزامنة إعداد التشغيل التلقائي مع إقلاع النظام
                StartupManager.SyncStartupSetting()
            Catch ex As Exception
                Try
                    Logger.LogError("MyApplication_Startup", ex)
                Catch
                End Try
            End Try
        End Sub
    End Class
End Namespace
