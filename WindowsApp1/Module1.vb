Module Settingsall
    ' ⚠️ بيانات المدير تُحمّل حصرياً من الإعدادات (AppSettings) عبر LoadAdminCredentials()
    ' عند بدء التشغيل. لا توجد بيانات افتراضية مشفرة في الكود المصدري.
    ' إذا لم تُوجد إعدادات محفوظة، يُفرض على المستخدم إنشاء حساب مدير في أول تشغيل.
    Public usernameadmin As String = ""
    Public passwordadmin As String = ""
    Public DeviceName As String
    Public useridlogin As Integer
    Public usernamelogin As String
    Public passwordlogin As String
    Public idclientmoney As Integer
    Public clientmoney As Integer

    ''' <summary>تحميل بيانات حساب المدير من الإعدادات — يُستدعى عند بدء التشغيل</summary>
    Public Sub LoadAdminCredentials()
        Try
            Dim u = SettingsManager.GetSetting(SettingsKeys.AdminUsername)
            Dim p = SettingsManager.GetSetting(SettingsKeys.AdminPassword)
            If Not String.IsNullOrWhiteSpace(u) Then usernameadmin = u
            If Not String.IsNullOrWhiteSpace(p) Then passwordadmin = p
        Catch ex As Exception
            Logger.LogError("LoadAdminCredentials", ex)
        End Try
    End Sub
End Module
