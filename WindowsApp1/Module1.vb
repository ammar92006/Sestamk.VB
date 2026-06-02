Module Settingsall
    ' ⚠️ بيانات المدير لم تعد ثابتة لشخص واحد — تُحمّل من الإعدادات (AppSettings)
    ' عبر LoadAdminCredentials() عند بدء التشغيل، ويضبطها كل نشاط من معالج أول تشغيل.
    ' القيم هنا مجرد احتياطي افتراضي لأول تشغيل قبل التهيئة وللتوافق مع النسخ القديمة.
    Public usernameadmin As String = "ammar"
    Public passwordadmin As String = "1515"
    Public DeviceName As String
    Public useridlogin As Integer
    Public usernamelogin As String
    Public passwordlogin As String
    Public idclientmoney As Integer
    Public clientmoney As Integer

    ''' <summary>تحميل بيانات حساب المدير من الإعدادات (لو موجودة) لاستخدامها في تسجيل الدخول</summary>
    Public Sub LoadAdminCredentials()
        Try
            Dim u = SettingsManager.GetSetting(SettingsKeys.AdminUsername)
            Dim p = SettingsManager.GetSetting(SettingsKeys.AdminPassword)
            If Not String.IsNullOrWhiteSpace(u) Then usernameadmin = u
            If Not String.IsNullOrWhiteSpace(p) Then passwordadmin = p
        Catch ex As Exception
            Debug.WriteLine("LoadAdminCredentials: " & ex.Message)
        End Try
    End Sub
End Module
