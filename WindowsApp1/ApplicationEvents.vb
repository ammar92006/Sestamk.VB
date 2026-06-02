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
            If DBModule.TryAutoConnect() Then Exit Sub

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
    End Class
End Namespace
