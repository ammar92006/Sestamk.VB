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
        ''' </summary>
        Private Sub MyApplication_UnhandledException(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try
                Logger.LogError("UnhandledException", e.Exception)
            Catch
            End Try
            Try
                MessageBox.Show(
                    "حدث خطأ غير متوقّع، وتم تسجيله تلقائياً." & vbCrLf &
                    "يمكنك متابعة العمل، وإن تكرّر الخطأ أعد تشغيل البرنامج.",
                    "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Catch
            End Try
            ' منع إغلاق البرنامج بسبب الخطأ
            e.ExitApplication = False
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            ' تهيئة نظام الـ Theme قبل فتح أي فورم لضمان عدم حدوث وميض في الألوان
            ThemeManager.Instance.Initialize()

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

        ''' <summary>عرض معالج أول تشغيل فقط على تثبيت جديد فعلاً (غير مهيّأ)</summary>
        Private Sub ShowFirstRunIfNeeded()
            Try
                If SettingsManager.GetBoolSetting(SettingsKeys.SetupCompleted, False) Then Exit Sub

                ' مهم: التثبيتات القديمة/المهيّأة (اسم محل موجود أو فيه مستخدمين)
                ' يجب ألا يظهر لها المعالج. نعتبرها مكتملة ونعلّمها لمنع تكرار الفحص.
                If IsBusinessAlreadyConfigured() Then
                    Try
                        SettingsManager.SaveSetting(SettingsKeys.SetupCompleted, "true")
                    Catch
                    End Try
                    Exit Sub
                End If

                Using wiz As New FirstRunSetup()
                    wiz.ShowDialog()
                End Using

                ' إعادة تحميل بيانات المدير بعد التهيئة
                Settingsall.LoadAdminCredentials()
            Catch ex As Exception
                ' لا نعطّل بدء التشغيل لو فشل المعالج لأي سبب
                Logger.LogError("ShowFirstRunIfNeeded", ex)
            End Try
        End Sub

        ''' <summary>هل النشاط مهيّأ مسبقاً؟ (اسم محل محفوظ أو يوجد مستخدمون)</summary>
        Private Function IsBusinessAlreadyConfigured() As Boolean
            Try
                If Not String.IsNullOrWhiteSpace(SettingsManager.GetSetting(SettingsKeys.ShopName)) Then Return True

                Using cn = DBModule.NewConn()
                    Using cmd As New System.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM Users_TBL", cn)
                        cmd.CommandTimeout = 8
                        If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then Return True
                    End Using
                End Using
            Catch
            End Try
            Return False
        End Function
    End Class
End Namespace
