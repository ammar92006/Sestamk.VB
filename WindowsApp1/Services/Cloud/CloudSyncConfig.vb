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
    End Class
End Namespace
