Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Win32

''' <summary>
''' وحدة إدارة التشغيل التلقائي للبرنامج مع إقلاع نظام التشغيل Windows.
''' تعتمد على سجل النظام (Registry) للمستخدم الحالي (HKCU) لضمان العمل دون الحاجة لصلاحيات مدير النظام (No Admin required).
''' كما تتوافق مع إدارة مهام ويندوز 10 و11 (StartupApproved).
''' </summary>
Public Module StartupManager

    Private Const RunKeyPath As String = "Software\Microsoft\Windows\CurrentVersion\Run"
    Private Const StartupApprovedKeyPath As String = "Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run"
    Private Const AppRunKeyName As String = "Sestamk"

    ' بايتات التمكين والتعطيل الخاصة بـ Windows Task Manager (StartupApproved)
    Private ReadOnly EnabledBytes As Byte() = {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Private ReadOnly DisabledBytes As Byte() = {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    ''' <summary>
    ''' التحقق مما إذا كان تشغيل التطبيق مفعلاً مع بدء تشغيل الويندوز
    ''' </summary>
    ''' <returns>True إذا كان مسجلاً ومُمكناً، False خلاف ذلك</returns>
    Public Function IsRunAtStartupEnabled() As Boolean
        Try
            Using runKey = Registry.CurrentUser.OpenSubKey(RunKeyPath, False)
                If runKey Is Nothing Then Return False

                Dim regValue = runKey.GetValue(AppRunKeyName)
                If regValue Is Nothing Then Return False

                Dim regValueStr = regValue.ToString().Trim().Trim(""""c)
                If String.IsNullOrEmpty(regValueStr) Then Return False

                ' التحقق من حالة إدارة المهام (Task Manager StartupApproved)
                Using approvedKey = Registry.CurrentUser.OpenSubKey(StartupApprovedKeyPath, False)
                    If approvedKey IsNot Nothing Then
                        Dim approvedVal = TryCast(approvedKey.GetValue(AppRunKeyName), Byte())
                        If approvedVal IsNot Nothing AndAlso approvedVal.Length > 0 Then
                            ' البايت الأول الفردي (مثل 3 أو 1) يعني أنه معطل من إدارة المهام
                            If (approvedVal(0) And 1) = 1 Then
                                Return False
                            End If
                        End If
                    End If
                End Using

                Return True
            End Using
        Catch ex As Exception
            Logger.LogError("StartupManager.IsRunAtStartupEnabled", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' تفعيل أو تعطيل بدء التشغيل التلقائي مع إقلاع نظام الويندوز
    ''' </summary>
    ''' <param name="enable">True للتفعيل، False للتعطيل</param>
    ''' <returns>True إذا تمت العملية بنجاح</returns>
    Public Function SetRunAtStartup(enable As Boolean) As Boolean
        Try
            ' 1) ضبط مفتاح التشغيل في سجل النظام HKCU\...\Run
            Using runKey = Registry.CurrentUser.OpenSubKey(RunKeyPath, True)
                If runKey Is Nothing Then Return False

                If enable Then
                    ' مسار البرنامج محاطاً بعلامات اقتباس لدعم المسارات التي بها مسافات
                    Dim exePath As String = """" & Application.ExecutablePath & """"
                    runKey.SetValue(AppRunKeyName, exePath, RegistryValueKind.String)
                Else
                    If runKey.GetValue(AppRunKeyName) IsNot Nothing Then
                        runKey.DeleteValue(AppRunKeyName, False)
                    End If
                End If
            End Using

            ' 2) ضبط أو تنظيف حالة إدارة المهام في StartupApproved\Run (Windows 10 / 11)
            Try
                Using approvedKey = Registry.CurrentUser.CreateSubKey(StartupApprovedKeyPath, RegistryKeyPermissionCheck.ReadWriteSubTree)
                    If approvedKey IsNot Nothing Then
                        If enable Then
                            approvedKey.SetValue(AppRunKeyName, EnabledBytes, RegistryValueKind.Binary)
                        Else
                            If approvedKey.GetValue(AppRunKeyName) IsNot Nothing Then
                                approvedKey.DeleteValue(AppRunKeyName, False)
                            End If
                        End If
                    End If
                End Using
            Catch exApproved As Exception
                ' مفتاح StartupApproved ثانوي ولا يمنع نجاح التسجيل في Run على النسخ القديمة
                Logger.LogError("StartupManager.SetRunAtStartup (StartupApproved)", exApproved)
            End Try

            ' 3) في حالة التعطيل: إزالة أي اختصار قديم في مجلد بدء التشغيل إن وُجد
            If Not enable Then
                Try
                    Dim startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                    Dim lnkPath = Path.Combine(startupFolder, "Sestamk.lnk")
                    If File.Exists(lnkPath) Then
                        File.Delete(lnkPath)
                    End If
                Catch __logEx As Exception
                    Logger.LogError("StartupManager.vb:104", __logEx)
                End Try
            End If

            Return True
        Catch ex As Exception
            Logger.LogError("StartupManager.SetRunAtStartup", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' مزامنة إعداد بدء التشغيل مع إعدادات قاعدة البيانات عند فتح البرنامج.
    ''' يضمن تحديث مسار الملف التنفيذي تلقائياً إذا تغيّر موقع مجلد البرنامج أو بعد التحديث.
    ''' </summary>
    Public Sub SyncStartupSetting()
        Try
            Dim dbSetting = SettingsManager.GetSetting(SettingsKeys.SystemRunAtStartup)
            If String.IsNullOrEmpty(dbSetting) Then Exit Sub

            Dim shouldRun As Boolean = (dbSetting.Trim().ToLower() = "true" OrElse dbSetting.Trim() = "1")
            Dim isRegistered = IsRunAtStartupEnabled()

            If shouldRun Then
                ' التحقق من تطابق المسار المسجل مع المسار الحالي
                Dim needsUpdate As Boolean = Not isRegistered
                If Not needsUpdate Then
                    Using runKey = Registry.CurrentUser.OpenSubKey(RunKeyPath, False)
                        If runKey IsNot Nothing Then
                            Dim val = runKey.GetValue(AppRunKeyName)
                            Dim valStr = If(val IsNot Nothing, val.ToString().Trim().Trim(""""c), "")
                            If Not String.Equals(valStr, Application.ExecutablePath, StringComparison.OrdinalIgnoreCase) Then
                                needsUpdate = True
                            End If
                        End If
                    End Using
                End If

                If needsUpdate Then
                    SetRunAtStartup(True)
                End If
            ElseIf Not shouldRun AndAlso isRegistered Then
                SetRunAtStartup(False)
            End If
        Catch ex As Exception
            Logger.LogError("StartupManager.SyncStartupSetting", ex)
        End Try
    End Sub

    ''' <summary>عرض معالج أول تشغيل فقط على تثبيت جديد فعلاً (غير مهيّأ)</summary>
    Public Sub ShowFirstRunIfNeeded()
        Try
            If SettingsManager.GetBoolSetting(SettingsKeys.SetupCompleted, False) Then Exit Sub

            ' مهم: التثبيتات القديمة/المهيّأة (اسم محل موجود أو فيه مستخدمين)
            ' يجب ألا يظهر لها المعالج. نعتبرها مكتملة ونعلّمها لمنع تكرار الفحص.
            If IsBusinessAlreadyConfigured() Then
                Try
                    SettingsManager.SaveSetting(SettingsKeys.SetupCompleted, "true")
                Catch __logEx As Exception
                    Logger.LogError("StartupManager.vb:164", __logEx)
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
        Catch __logEx As Exception
            Logger.LogError("StartupManager.vb:193", __logEx)
        End Try
        Return False
    End Function

End Module
