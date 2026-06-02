Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            ' تحميل إعدادات قاعدة البيانات المحفوظة من الملف قبل فتح أي فورم
            DBModule.LoadDbSettings()

            ' محاولة اتصال تلقائية صامتة:
            ' 1) تجرّب الإعدادات المحفوظة. 2) تكتشف خوادم SQL المثبتة وتجرّبها.
            ' بدون أي رسالة مزعجة للمستخدم في الحالة الطبيعية.
            If DBModule.TryAutoConnect() Then
                ' تحميل بيانات المدير المهيّأة لهذا النشاط
                Settingsall.LoadAdminCredentials()
                ' معالج أول تشغيل (يظهر مرة واحدة فقط لكل نشاط)
                ShowFirstRunIfNeeded()
                Exit Sub
            End If

            ' فشل الاتصال نهائياً → نفتح الإعدادات مباشرة على تبويب قاعدة البيانات
            ' (بدون MessageBox) ليضبطها المستخدم يدوياً إذا رغب.
            Using settingsForm As New Settings()
                AddHandler settingsForm.Shown,
                    Sub(s, ev) settingsForm.public_set.SelectedIndex = 1
                settingsForm.ShowDialog()
            End Using

            ' بعد إغلاق الإعدادات: لو الاتصال بقى ناجحاً نعيد التشغيل لتطبيق
            ' الإعدادات الجديدة على كل الفورمات، وإلا نُلغي بدء التشغيل بهدوء.
            If DBModule.TestConnection() Then
                System.Windows.Forms.Application.Restart()
            End If
            e.Cancel = True
        End Sub

        ''' <summary>عرض معالج أول تشغيل إذا لم تكتمل التهيئة بعد</summary>
        Private Sub ShowFirstRunIfNeeded()
            Try
                If SettingsManager.GetBoolSetting(SettingsKeys.SetupCompleted, False) Then Exit Sub

                Using wiz As New FirstRunSetup()
                    wiz.ShowDialog()
                End Using

                ' إعادة تحميل بيانات المدير بعد التهيئة
                Settingsall.LoadAdminCredentials()
            Catch ex As Exception
                ' لا نعطّل بدء التشغيل لو فشل المعالج لأي سبب
                Debug.WriteLine("ShowFirstRunIfNeeded: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace
