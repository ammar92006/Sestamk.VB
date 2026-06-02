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
            ' تحميل إعدادات قاعدة البيانات من الملف قبل فتح أي فورم
            DBModule.LoadDbSettings()

            ' التحقق من الاتصال - لو فشل نفتح إعدادات قاعدة البيانات
            If Not DBModule.TestConnection() Then
                MessageBox.Show(
                    "تعذّر الاتصال بقاعدة البيانات." & vbCrLf &
                    "سيتم فتح نافذة الإعدادات لضبط بيانات الاتصال." & vbCrLf &
                    "بعد الحفظ سيتم إعادة تشغيل البرنامج تلقائياً.",
                    "مشكلة في الاتصال",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                Using settingsForm As New Settings()
                    ' الانتقال تلقائياً لتبويب قاعدة البيانات عند ظهور الفورم
                    AddHandler settingsForm.Shown,
                        Sub(s, ev) settingsForm.public_set.SelectedIndex = 1
                    settingsForm.ShowDialog()
                End Using

                ' إعادة تشغيل البرنامج بعد تعديل الإعدادات
                System.Windows.Forms.Application.Restart()
                e.Cancel = True
            End If
        End Sub
    End Class
End Namespace
