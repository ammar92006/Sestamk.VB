Imports Microsoft.Win32
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks

' Central contract shared with Sestamk_App. Never add a service_role key here.
Public NotInheritable Class LicenseSettings
    Public Const SupabaseUrl As String = "https://axigicbiydhfbkfqogma.supabase.co"
    Public Const PublishableKey As String = "sb_publishable__LRAn0WS56TL5LLa8Y3TLw_7yxI-UK7"
    Public Const CheckLicenseRpc As String = "check_license"
    Public Const ProductId As String = "sestamk-vb"
    Public Const OfflineCacheDays As Integer = 7
    Public Const GitHubRepo As String = "ammar92006/Sestamk.VB"
    Public Const DefaultManifestUrl As String = "https://github.com/ammar92006/Sestamk.VB/releases/latest/download/manifest.json"
    Public Const GitHubReleasesApiUrl As String = "https://api.github.com/repos/ammar92006/Sestamk.VB/releases"
End Class

Public NotInheritable Class HardwareFingerprint
    Private Sub New()
    End Sub

    Private Shared _cachedHwid As String = Nothing
    Private Shared _cachedOsInfo As String = Nothing
    Private Shared _cachedProcessorName As String = Nothing
    Private Shared _cachedRamGb As Integer = -1

    ' Matches Sestamk_App: SHA256(MachineGuid|CpuId|MotherboardSerial).
    Public Shared Function GetCurrent() As String
        If Not String.IsNullOrEmpty(_cachedHwid) Then Return _cachedHwid
        Try
            Dim raw = GetMachineGuid() & "|" & GetWmiValue("Win32_Processor", "ProcessorId") & "|" & GetWmiValue("Win32_BaseBoard", "SerialNumber")
            Using sha As SHA256 = SHA256.Create()
                _cachedHwid = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(raw))).Replace("-", String.Empty)
            End Using
        Catch
            _cachedHwid = "UNKNOWN_HWID"
        End Try
        Return _cachedHwid
    End Function

    Private Shared Function GetMachineGuid() As String
        Try
            Using key = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Cryptography")
                Return Convert.ToString(key.GetValue("MachineGuid"))
            End Using
        Catch
            Return "UNKNOWN_GUID"
        End Try
    End Function

    Private Shared Function GetWmiValue(className As String, propertyName As String) As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT " & propertyName & " FROM " & className)
                For Each item As ManagementObject In searcher.Get()
                    Return If(Convert.ToString(item(propertyName)), "UNKNOWN")
                Next
            End Using
        Catch
        End Try
        Return "UNKNOWN"
    End Function

    Public Shared Function GetOSInfo() As String
        If Not String.IsNullOrEmpty(_cachedOsInfo) Then Return _cachedOsInfo
        Dim val = GetWmiValue("Win32_OperatingSystem", "Caption")
        If Not String.IsNullOrEmpty(val) AndAlso val <> "UNKNOWN" Then
            _cachedOsInfo = val
        Else
            _cachedOsInfo = Environment.OSVersion.VersionString
        End If
        Return _cachedOsInfo
    End Function

    Public Shared Function GetProcessorName() As String
        If Not String.IsNullOrEmpty(_cachedProcessorName) Then Return _cachedProcessorName
        Dim val = GetWmiValue("Win32_Processor", "Name")
        If Not String.IsNullOrEmpty(val) AndAlso val <> "UNKNOWN" Then
            _cachedProcessorName = val
        Else
            _cachedProcessorName = "Unknown CPU"
        End If
        Return _cachedProcessorName
    End Function

    Public Shared Function GetRamGB() As Integer
        If _cachedRamGb >= 0 Then Return _cachedRamGb
        Try
            Using searcher As New ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem")
                For Each item As ManagementObject In searcher.Get()
                    Dim bytes = Convert.ToInt64(item("TotalPhysicalMemory"))
                    _cachedRamGb = CInt(bytes \ (1024L * 1024L * 1024L))
                    Return _cachedRamGb
                Next
            End Using
        Catch
        End Try
        _cachedRamGb = 0
        Return 0
    End Function
End Class

Public NotInheritable Class LicenseCache
    Private Sub New()
    End Sub

    Private Shared ReadOnly CachePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "vb-license.dat")
    Private Shared ReadOnly SharedAppCachePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "license.dat")

    Public Shared Sub Save(license As JObject)
        license("last_successful_sync_utc") = DateTime.UtcNow.ToString("O")
        Dim encrypted = ProtectedData.Protect(Encoding.UTF8.GetBytes(license.ToString(Formatting.None)), Nothing, DataProtectionScope.LocalMachine)
        Directory.CreateDirectory(Path.GetDirectoryName(CachePath))
        File.WriteAllBytes(CachePath, encrypted)
    End Sub

    Public Shared Function Load() As JObject
        Try
            Dim targetFile As String = Nothing
            If File.Exists(CachePath) Then
                targetFile = CachePath
            ElseIf File.Exists(SharedAppCachePath) Then
                targetFile = SharedAppCachePath
            End If

            If targetFile Is Nothing Then Return Nothing
            Dim plain = ProtectedData.Unprotect(File.ReadAllBytes(targetFile), Nothing, DataProtectionScope.LocalMachine)
            Return JObject.Parse(Encoding.UTF8.GetString(plain))
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Sub Delete()
        Try
            If File.Exists(CachePath) Then File.Delete(CachePath)
            If File.Exists(SharedAppCachePath) Then File.Delete(SharedAppCachePath)
        Catch
        End Try
    End Sub

    Public Shared Function IsOfflineAllowed(cache As JObject) As Boolean
        If cache Is Nothing Then Return False
        Dim expiresAt As DateTime
        Dim lastSync As DateTime
        If Not DateTime.TryParse(Convert.ToString(cache("expires_at")), expiresAt) OrElse expiresAt.Date < DateTime.Today Then Return False
        If Not DateTime.TryParse(Convert.ToString(cache("last_successful_sync_utc")), lastSync) Then Return False
        Return DateTime.UtcNow.Subtract(lastSync.ToUniversalTime()).TotalDays <= LicenseSettings.OfflineCacheDays
    End Function
End Class

Public Class LicenseCheckResult
    Public Property IsValid As Boolean
    Public Property RequiresActivation As Boolean
    Public Property IsOffline As Boolean
    Public Property Message As String
    Public Property Payload As JObject
End Class

Public NotInheritable Class LicenseBootstrapper
    Public Shared Event LicenseInvalidated(message As String)

    Shared Sub New()
        Try
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11
        Catch
        End Try
    End Sub

    Private Sub New()
    End Sub

    Public Shared Async Function CheckAsync(Optional forceOnlineCheck As Boolean = False) As Task(Of LicenseCheckResult)
        Dim cache = LicenseCache.Load()
        If cache Is Nothing OrElse String.IsNullOrWhiteSpace(Convert.ToString(cache("saved_serial"))) Then
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = "يرجى تفعيل البرنامج أولاً."}
        End If

        ' تسريع فوري: إذا كان الكاش المحلي صالحاً، يتم قبول الترخيص فوراً في 0ms بدون تجميد الشاشة
        If Not forceOnlineCheck AndAlso LicenseCache.IsOfflineAllowed(cache) Then
            Dim savedSerial = Convert.ToString(cache("saved_serial"))
            Dim bgLicenseCheck = Task.Run(Async Function()
                         Try
                             Dim bgResponse = Await RequestAsync(savedSerial)
                             If IsServerValid(bgResponse) Then
                                 bgResponse("saved_serial") = savedSerial
                                 LicenseCache.Save(bgResponse)
                             Else
                                 ' تم إيقاف أو إلغاء الترخيص على السيرفر
                                 LicenseCache.Delete()
                                 Dim revokedMsg = ReadMessage(bgResponse, "تم إيقاف أو انتهاء ترخيص البرنامج من السيرفر.")
                                 RaiseEvent LicenseInvalidated(revokedMsg)
                             End If
                         Catch
                             ' في حال انقطاع الاتصال أثناء الفحص الخلفي الصامت يستمر العمل بالكاش المسموح
                         End Try
                     End Function)

            Return New LicenseCheckResult With {.IsValid = True, .Payload = cache, .IsOffline = False}
        End If

        Try
            Dim response = Await RequestAsync(Convert.ToString(cache("saved_serial")))
            If IsServerValid(response) Then
                response("saved_serial") = Convert.ToString(cache("saved_serial"))
                LicenseCache.Save(response)
                Return New LicenseCheckResult With {.IsValid = True, .Payload = response}
            End If
            LicenseCache.Delete()
            Dim failMsg = ReadMessage(response, "تم إيقاف أو انتهاء الترخيص.")
            RaiseEvent LicenseInvalidated(failMsg)
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = failMsg}
        Catch ex As HttpRequestException
            If LicenseCache.IsOfflineAllowed(cache) Then Return New LicenseCheckResult With {.IsValid = True, .IsOffline = True, .Payload = cache, .Message = "تعمل النسخة مؤقتاً دون اتصال بالإنترنت."}
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = "يلزم الاتصال بالإنترنت للتحقق من الترخيص."}
        Catch ex As TaskCanceledException
            If LicenseCache.IsOfflineAllowed(cache) Then Return New LicenseCheckResult With {.IsValid = True, .IsOffline = True, .Payload = cache}
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = "انتهت مهلة التحقق من الترخيص."}
        Catch ex As Exception
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = "تعذر التحقق من الترخيص: " & ex.Message}
        End Try
    End Function

    Public Shared Async Function ActivateAsync(serial As String) As Task(Of LicenseCheckResult)
        If String.IsNullOrWhiteSpace(serial) Then Return New LicenseCheckResult With {.Message = "أدخل مفتاح التفعيل."}
        Try
            Dim response = Await RequestAsync(serial.Trim())
            If Not IsServerValid(response) Then Return New LicenseCheckResult With {.Message = ReadMessage(response, "مفتاح التفعيل غير صالح.")}
            response("saved_serial") = serial.Trim()
            LicenseCache.Save(response)
            Return New LicenseCheckResult With {.IsValid = True, .Payload = response, .Message = "تم تفعيل البرنامج بنجاح."}
        Catch ex As Exception
            Return New LicenseCheckResult With {.Message = "تعذر الاتصال بخدمة التفعيل: " & ex.Message}
        End Try
    End Function

    Private Shared Async Function RequestAsync(serial As String) As Task(Of JObject)
        Dim ramGb = HardwareFingerprint.GetRamGB()
        Dim payload As New Dictionary(Of String, Object) From {
            {"p_serial", serial},
            {"p_hwid", HardwareFingerprint.GetCurrent()},
            {"p_version", Application.ProductVersion},
            {"p_device_name", Environment.MachineName},
            {"p_os_info", HardwareFingerprint.GetOSInfo()},
            {"p_processor", HardwareFingerprint.GetProcessorName()},
            {"p_ram_gb", If(ramGb > 0, CObj(ramGb), Nothing)}
        }
        Dim jsonString = JsonConvert.SerializeObject(payload)
        Using client As New HttpClient()
            client.Timeout = TimeSpan.FromSeconds(12)
            client.DefaultRequestHeaders.Add("apikey", LicenseSettings.PublishableKey)
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " & LicenseSettings.PublishableKey)
            Dim content As New StringContent(jsonString, Encoding.UTF8, "application/json")
            Dim response = Await client.PostAsync(LicenseSettings.SupabaseUrl.TrimEnd("/"c) & "/rest/v1/rpc/" & LicenseSettings.CheckLicenseRpc, content)
            Dim text = Await response.Content.ReadAsStringAsync()
            If Not response.IsSuccessStatusCode Then Throw New HttpRequestException("الخدمة أعادت " & CInt(response.StatusCode) & ".")
            Return JObject.Parse(text)
        End Using
    End Function

    Private Shared Function IsServerValid(response As JObject) As Boolean
        Dim status = Convert.ToString(response("status"))
        Return String.Equals(status, "active", StringComparison.OrdinalIgnoreCase) OrElse String.Equals(status, "grace_period", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function ReadMessage(response As JObject, fallback As String) As String
        Dim message = Convert.ToString(response("message"))
        Return If(String.IsNullOrWhiteSpace(message), fallback, message)
    End Function
End Class