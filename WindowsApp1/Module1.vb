Module Settingsall
    ' ⚠️ بيانات المدير تُحمّل حصرياً من الإعدادات (AppSettings) عبر LoadAdminCredentials()
    ' عند بدء التشغيل. لا توجد بيانات افتراضية مشفرة في الكود المصدري.
    ' إذا لم تُوجد إعدادات محفوظة، يُفرض على المستخدم إنشاء حساب مدير في أول تشغيل.
    Public usernameadmin As String = ""
    ''' <summary>تجزئة PBKDF2 لكلمة مرور المدير (تُحمّل من الإعدادات) — لا تُخزن كلمة المرور نفسها</summary>
    Public passwordadminHash As String = ""
    Public DeviceName As String
    Public useridlogin As Integer
    Public usernamelogin As String
    ''' <summary>مهمل — لا تخزن كلمة المرور في المتغيرات العامة (يُنظف عند تسجيل الخروج)</summary>
    Public passwordlogin As String
    Public idclientmoney As Integer
    Public clientmoney As Integer

    ''' <summary>تحميل بيانات حساب المدير من الإعدادات — يُستدعى عند بدء التشغيل.
    ''' يقرأ التجزئة (AdminPasswordHash)؛ وإن وُجد نص صريح قديم (AdminPassword) يرقّيه تلقائياً ويمسح النص الصريح.</summary>
    Public Sub LoadAdminCredentials()
        Try
            Dim u = SettingsManager.GetSetting(SettingsKeys.AdminUsername)
            If Not String.IsNullOrWhiteSpace(u) Then usernameadmin = u

            Dim h = SettingsManager.GetSetting(SettingsKeys.AdminPasswordHash)
            If Not String.IsNullOrWhiteSpace(h) Then
                passwordadminHash = h
            Else
                ' ترقية التثبيتات القديمة: تحويل النص الصريح المحفوظ إلى تجزئة ثم مسحه
                Dim legacyP = SettingsManager.GetSetting(SettingsKeys.AdminPassword)
                If Not String.IsNullOrWhiteSpace(legacyP) Then
                    passwordadminHash = PasswordHasher.Hash(legacyP)
                    SettingsManager.SaveSetting(SettingsKeys.AdminPasswordHash, passwordadminHash)
                    SettingsManager.SaveSetting(SettingsKeys.AdminPassword, "")
                End If
            End If
        Catch ex As Exception
            Logger.LogError("LoadAdminCredentials", ex)
        End Try
    End Sub
End Module
