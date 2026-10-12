Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Newtonsoft.Json
Imports System.Windows.Forms

Namespace Services.Cloud
    ''' <summary>
    ''' إعدادات المزامنة السحابية (Cloud Sync Settings)
    ''' </summary>
    Public Class CloudSyncSettings
        Public Property TursoUrl As String
        Public Property AuthToken As String
        Public Property PlatformToken As String
        Public Property OrganizationSlug As String
        Public Property DatabaseName As String
        Public Property DeviceId As String
        Public Property SyncIntervalSeconds As Integer = 30
        Public Property IsSyncEnabled As Boolean
        Public Property LastSyncUtc As String
        Public Property CompanyName As String
        Public Property LicenseSerial As String
        Public Property IsAutoManaged As Boolean = True

        ''' <summary>
        ''' أخذ نسخة مطابقة من الإعدادات (Clone settings)
        ''' </summary>
        Public Function Clone() As CloudSyncSettings
            Dim json = JsonConvert.SerializeObject(Me)
            Return JsonConvert.DeserializeObject(Of CloudSyncSettings)(json)
        End Function
    End Class

    ''' <summary>
    ''' مدير إعدادات المزامنة السحابية (Cloud Sync Config Manager)
    ''' يقوم بحفظ واسترجاع الإعدادات مشفرة (Manages encrypted storage and retrieval of config)
    ''' </summary>
    Public NotInheritable Class CloudSyncConfig
        Private Shared ReadOnly FileName As String = "cloud-sync.dat"

        Private Sub New()
            ' يمنع إنشاء كائن من هذه الفئة (Prevent instantiation)
        End Sub

        ''' <summary>
        ''' الحصول على مسار ملف الإعدادات (Get config file path)
        ''' </summary>
        Private Shared Function GetConfigPath() As String
            Dim programData As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
            Dim appFolder As String = Path.Combine(programData, "Sestamk")

            Try
                If Not Directory.Exists(appFolder) Then
                    Directory.CreateDirectory(appFolder)
                End If
                Return Path.Combine(appFolder, FileName)
            Catch ex As Exception
                ' في حالة فشل إنشاء المجلد، نستخدم مسار التطبيق (Fallback to StartupPath)
                Return Path.Combine(Application.StartupPath, FileName)
            End Try
        End Function

        ''' <summary>
        ''' حفظ الإعدادات مشفرة (Save encrypted settings)
        ''' </summary>
        Public Shared Sub Save(config As CloudSyncSettings)
            Try
                If config Is Nothing Then Throw New ArgumentNullException(NameOf(config))

                Dim json As String = JsonConvert.SerializeObject(config)
                Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(json)

                ' تشفير البيانات (Encrypt data using DPAPI)
                Dim encryptedBytes As Byte() = ProtectedData.Protect(jsonBytes, Nothing, DataProtectionScope.LocalMachine)

                Dim filePath As String = GetConfigPath()
                File.WriteAllBytes(filePath, encryptedBytes)
            Catch ex As Exception
                ' خطأ في حفظ الإعدادات (Error saving config)
                Throw New Exception("فشل في حفظ إعدادات المزامنة السحابية (Failed to save cloud sync config)", ex)
            End Try
        End Sub

        ''' <summary>
        ''' استرجاع الإعدادات مفكوكة التشفير (Load decrypted settings)
        ''' </summary>
        Public Shared Function Load() As CloudSyncSettings
            Dim filePath As String = GetConfigPath()

            If Not File.Exists(filePath) Then
                Return Nothing
            End If

            Try
                Dim encryptedBytes As Byte() = File.ReadAllBytes(filePath)

                ' فك تشفير البيانات (Decrypt data using DPAPI)
                Dim jsonBytes As Byte() = ProtectedData.Unprotect(encryptedBytes, Nothing, DataProtectionScope.LocalMachine)
                Dim json As String = Encoding.UTF8.GetString(jsonBytes)

                Return JsonConvert.DeserializeObject(Of CloudSyncSettings)(json)
            Catch ex As CryptographicException
                ' فشل فك التشفير، قد يكون بسبب تغيير الجهاز (Decryption failed, possibly different machine)
                Return Nothing
            Catch ex As Exception
                ' خطأ آخر في قراءة الإعدادات (Other errors reading config)
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' حذف ملف الإعدادات (Delete config file)
        ''' </summary>
        Public Shared Sub Delete()
            Dim filePath As String = GetConfigPath()
            If File.Exists(filePath) Then
                Try
                    File.Delete(filePath)
                Catch ex As Exception
                    ' تجاهل الأخطاء البسيطة (Ignore minor errors)
                    Logger.LogError("CloudSyncConfig.vb:116", ex)
                End Try
            End If
        End Sub

        ''' <summary>
        ''' التحقق مما إذا كانت الإعدادات مهيأة (Check if configured)
        ''' </summary>
        Public Shared Function IsConfigured() As Boolean
            Dim config As CloudSyncSettings = Load()
            If config Is Nothing Then Return False

            Return Not String.IsNullOrWhiteSpace(config.TursoUrl) AndAlso
                   Not String.IsNullOrWhiteSpace(config.AuthToken)
        End Function

        ''' <summary>
        ''' الحصول على معرف الجهاز أو إنشاؤه (Get existing DeviceId or create a new one)
        ''' </summary>
        Public Shared Function GetOrCreateDeviceId() As String
            Dim config As CloudSyncSettings = Load()

            If config IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(config.DeviceId) Then
                Return config.DeviceId
            End If

            If config Is Nothing Then
                config = New CloudSyncSettings()
            End If

            ' إنشاء معرف جديد (Create new GUID)
            config.DeviceId = Guid.NewGuid().ToString()
            Save(config)

            Return config.DeviceId
        End Function

        Public Const DefaultPlatformToken As String = "eyJhbGciOiJFZERTQSIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI2ZHl2cjhaREVmR1JxZkkwUVROYi1nIiwib3JnX2lkIjoxMDAwMjcwNzY0fQ.T7xu9pB8EjGfwxr0_oAQkeqewG1KKaegYKyU2L3VScOUBb2vKLaMXTFvPBkVP0Bx-pLm6cZmsyJ1cxeOgw4GBQ"
        Public Const DefaultOrgSlug As String = "sestamk"

        ''' <summary>
        ''' التأكد من إعداد المزامنة وربطها تلقائياً بقاعدة بيانات الشركة السحابية بناءً على الترخيص
        ''' </summary>
        Public Shared Async Function EnsureConfigFromLicenseAsync() As Task(Of Boolean)
            Try
                Dim lic = LicenseCache.Load()
                If lic Is Nothing Then Return False

                Dim serial = Convert.ToString(lic("saved_serial"))?.Trim()
                Dim compName = Convert.ToString(If(lic("company_name"), lic("shop_name")))?.Trim()
                If String.IsNullOrWhiteSpace(serial) Then Return False

                Dim currentConfig = Load()
                If currentConfig Is Nothing Then
                    currentConfig = New CloudSyncSettings()
                    currentConfig.DeviceId = GetOrCreateDeviceId()
                End If

                ' إذا كانت الإعدادات مهيأة بالفعل ومطابقة لنفس السيريال، نتأكد فقط من حفظ اسم المنشأة
                If IsConfigured() AndAlso String.Equals(currentConfig.LicenseSerial, serial, StringComparison.OrdinalIgnoreCase) Then
                    If String.IsNullOrWhiteSpace(currentConfig.CompanyName) Then
                        currentConfig.CompanyName = compName
                        Save(currentConfig)
                    End If
                    Return True
                End If

                ' إذا وُجدت بيانات الرابط والتوكن مباشرة في كاش الترخيص
                Dim licTursoUrl = Convert.ToString(lic("turso_db_url"))
                Dim licTursoToken = Convert.ToString(lic("turso_auth_token"))

                If Not String.IsNullOrWhiteSpace(licTursoUrl) AndAlso Not String.IsNullOrWhiteSpace(licTursoToken) Then
                    currentConfig.TursoUrl = licTursoUrl.Trim()
                    currentConfig.AuthToken = licTursoToken.Trim()
                    currentConfig.CompanyName = compName
                    currentConfig.LicenseSerial = serial
                    currentConfig.IsSyncEnabled = True
                    Save(currentConfig)
                    Return True
                End If

                ' التجهيز التلقائي لقاعدة بيانات الشركة عبر Platform API
                Dim cleanSerial = System.Text.RegularExpressions.Regex.Replace(serial.ToLowerInvariant(), "[^a-z0-9]", "-").Trim("-"c)
                If cleanSerial.Length > 20 Then cleanSerial = cleanSerial.Substring(0, 20).TrimEnd("-"c)
                Dim dbName = $"comp-{cleanSerial}"

                Using platformClient As New TursoPlatformClient(DefaultPlatformToken, DefaultOrgSlug)
                    Dim dbInfo = Await platformClient.GetOrCreateDatabaseAsync(dbName).ConfigureAwait(False)
                    If dbInfo Is Nothing OrElse String.IsNullOrWhiteSpace(dbInfo.HttpUrl) Then
                        Return False
                    End If

                    Dim authToken = Await platformClient.CreateAuthTokenAsync(dbName).ConfigureAwait(False)
                    If String.IsNullOrWhiteSpace(authToken) Then
                        Return False
                    End If

                    currentConfig.TursoUrl = dbInfo.HttpUrl
                    currentConfig.AuthToken = authToken
                    currentConfig.DatabaseName = dbName
                    currentConfig.OrganizationSlug = DefaultOrgSlug
                    currentConfig.PlatformToken = DefaultPlatformToken
                    currentConfig.CompanyName = compName
                    currentConfig.LicenseSerial = serial
                    currentConfig.IsSyncEnabled = True
                    currentConfig.IsAutoManaged = True
                    Save(currentConfig)

                    ' تجهيز الهيكل السحابي للجديد
                    Try
                        Using tursoClient As New TursoHttpClient(dbInfo.HttpUrl, authToken)
                            Dim builder As New TursoSchemaBuilder()
                            Await builder.EnsureRemoteSchemaAsync(tursoClient).ConfigureAwait(False)
                        End Using
                    Catch exSchema As Exception
                        Logger.LogError("CloudSyncConfig.EnsureSchema", exSchema)
                    End Try

                    Return True
                End Using
            Catch ex As Exception
                Logger.LogError("CloudSyncConfig.EnsureConfigFromLicenseAsync", ex)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' استرجاع قائمة جميع أجهزة المنشأة المسجلة في السحابة وتوقيت آخر مزامنة لكل جهاز
        ''' </summary>
        Public Shared Async Function GetCompanyDevicesAsync() As Task(Of List(Of CompanyDeviceModel))
            Dim result As New List(Of CompanyDeviceModel)()
            Dim config = Load()
            If config Is Nothing OrElse Not IsConfigured() Then Return result

            Dim currentDevId = GetOrCreateDeviceId()

            Try
                Using client As New TursoHttpClient(config.TursoUrl, config.AuthToken)
                    Dim dt = Await client.ExecuteQueryAsync("SELECT [device_id], [device_name], [app_version], [os_info], [last_sync_utc], [total_pushed], [total_pulled] FROM [_SyncDevices] ORDER BY [last_sync_utc] DESC").ConfigureAwait(False)

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        For Each row As DataRow In dt.Rows
                            Dim dId = Convert.ToString(row("device_id"))
                            Dim dev As New CompanyDeviceModel With {
                                .DeviceId = dId,
                                .DeviceName = Convert.ToString(row("device_name")),
                                .AppVersion = Convert.ToString(row("app_version")),
                                .OsInfo = Convert.ToString(row("os_info")),
                                .LastSyncUtc = Convert.ToString(row("last_sync_utc")),
                                .TotalPushed = If(row.IsNull("total_pushed"), 0, Convert.ToInt64(row("total_pushed"))),
                                .TotalPulled = If(row.IsNull("total_pulled"), 0, Convert.ToInt64(row("total_pulled"))),
                                .IsCurrentDevice = String.Equals(dId, currentDevId, StringComparison.OrdinalIgnoreCase)
                            }
                            result.Add(dev)
                        Next
                    End If
                End Using
            Catch ex As Exception
                Logger.LogError("CloudSyncConfig.GetCompanyDevicesAsync", ex)
            End Try

            ' إذا لم يتوفر بعد سجلات في السحابة، نضيف الجهاز الحالي افتراضياً
            If result.Count = 0 Then
                result.Add(New CompanyDeviceModel With {
                    .DeviceId = currentDevId,
                    .DeviceName = Environment.MachineName & " (الكاشير الحالي)",
                    .AppVersion = Application.ProductVersion,
                    .OsInfo = Environment.OSVersion.ToString(),
                    .LastSyncUtc = DateTime.UtcNow.ToString("o"),
                    .IsCurrentDevice = True
                })
            End If

            Return result
        End Function
    End Class
End Namespace
