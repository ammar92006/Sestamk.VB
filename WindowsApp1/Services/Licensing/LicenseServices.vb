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
    Public Shared ReadOnly Property SupabaseUrl As String
        Get
            Dim val = System.Configuration.ConfigurationManager.AppSettings("Supabase:Url")
            If String.IsNullOrWhiteSpace(val) Then Return "https://axigicbiydhfbkfqogma.supabase.co"
            Return val
        End Get
    End Property

    Public Shared ReadOnly Property PublishableKey As String  
        Get
            Dim val = System.Configuration.ConfigurationManager.AppSettings("Supabase:PublishableKey")
            If String.IsNullOrWhiteSpace(val) Then Return "sb_publishable__LRAn0WS56TL5LLa8Y3TLw_7yxI-UK7"
            Return val
        End Get
    End Property
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
            Using baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                Using key = baseKey.OpenSubKey("SOFTWARE\Microsoft\Cryptography")
                    If key IsNot Nothing Then
                        Dim val = Convert.ToString(key.GetValue("MachineGuid"))
                        If Not String.IsNullOrWhiteSpace(val) Then Return val
                    End If
                End Using
            End Using
        Catch
        End Try
        Try
            Using key = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Cryptography")
                If key IsNot Nothing Then
                    Dim val = Convert.ToString(key.GetValue("MachineGuid"))
                    If Not String.IsNullOrWhiteSpace(val) Then Return val
                End If
            End Using
        Catch
        End Try
        Return "UNKNOWN_GUID"
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

    Private Shared ReadOnly PrimaryCachePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "vb-license.dat")
    Private Shared ReadOnly SharedAppCachePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "license.dat")
    Private Shared ReadOnly LocalAppCachePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sestamk", "vb-license.dat")
    Private Shared ReadOnly RoamingAppCachePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sestamk", "vb-license.dat")
    Private Const RegistryKeyPath As String = "Software\Sestamk\License"

    Public Shared Sub Save(license As JObject)
        If license Is Nothing Then Return
        Try
            ' الحفاظ التام على السيريال المحفوظ وعدم تركه يضيع أبداً
            Dim currentSerial = Convert.ToString(license("saved_serial"))
            If String.IsNullOrWhiteSpace(currentSerial) Then
                Dim old = Load()
                If old IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Convert.ToString(old("saved_serial"))) Then
                    license("saved_serial") = Convert.ToString(old("saved_serial")).Trim()
                End If
            End If

            license("last_successful_sync_utc") = DateTime.UtcNow.ToString("O", System.Globalization.CultureInfo.InvariantCulture)
            license("last_successful_sync") = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)

            Dim jsonBytes = Encoding.UTF8.GetBytes(license.ToString(Formatting.None))
            Dim encrypted = ProtectedData.Protect(jsonBytes, Nothing, DataProtectionScope.LocalMachine)

            ' 1) الحفظ في المجلد العام المشترك (ProgramData)
            Try
                Directory.CreateDirectory(Path.GetDirectoryName(PrimaryCachePath))
                File.WriteAllBytes(PrimaryCachePath, encrypted)
            Catch
            End Try

            ' 2) الحفظ في مجلد LocalAppData الخاص بالمستخدم الحالي
            Try
                Directory.CreateDirectory(Path.GetDirectoryName(LocalAppCachePath))
                File.WriteAllBytes(LocalAppCachePath, encrypted)
            Catch
            End Try

            ' 3) الحفظ في مجلد Roaming AppData
            Try
                Directory.CreateDirectory(Path.GetDirectoryName(RoamingAppCachePath))
                File.WriteAllBytes(RoamingAppCachePath, encrypted)
            Catch
            End Try

            ' 4) الحفظ الاحتياطي في سجل النظام (Registry HKCU)
            Try
                Using regKey = Registry.CurrentUser.CreateSubKey(RegistryKeyPath)
                    If regKey IsNot Nothing Then
                        regKey.SetValue("EncryptedPayload", Convert.ToBase64String(encrypted))
                        Dim s = Convert.ToString(license("saved_serial"))
                        If Not String.IsNullOrWhiteSpace(s) Then regKey.SetValue("SavedSerial", s.Trim())
                    End If
                End Using
            Catch
            End Try

            ' 5) الحفظ الاحتياطي في سجل النظام (Registry HKLM) إن توفرت الصلاحيات
            Try
                Using baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                    Using regKey = baseKey.CreateSubKey(RegistryKeyPath)
                        If regKey IsNot Nothing Then
                            regKey.SetValue("EncryptedPayload", Convert.ToBase64String(encrypted))
                            Dim s = Convert.ToString(license("saved_serial"))
                            If Not String.IsNullOrWhiteSpace(s) Then regKey.SetValue("SavedSerial", s.Trim())
                        End If
                    End Using
                End Using
            Catch
            End Try

        Catch ex As Exception
            Logger.LogError("LicenseCache.Save", ex)
        End Try
    End Sub

    Public Shared Function Load() As JObject
        Dim candidates As String() = {PrimaryCachePath, LocalAppCachePath, RoamingAppCachePath, SharedAppCachePath}
        Dim foundObject As JObject = Nothing

        ' فحص مسارات الملفات أولاً
        For Each filePath In candidates
            Try
                If File.Exists(filePath) Then
                    Dim raw = File.ReadAllBytes(filePath)
                    Dim plain = ProtectedData.Unprotect(raw, Nothing, DataProtectionScope.LocalMachine)
                    Dim obj = JObject.Parse(Encoding.UTF8.GetString(plain))
                    If obj IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Convert.ToString(obj("saved_serial"))) Then
                        foundObject = obj
                        Exit For
                    ElseIf obj IsNot Nothing AndAlso foundObject Is Nothing Then
                        foundObject = obj
                    End If
                End If
            Catch
            End Try
        Next

        ' إذا لم يوجد بالملفات، فحص سجل النظام HKCU
        If foundObject Is Nothing Then
            Try
                Using regKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath)
                    If regKey IsNot Nothing Then
                        Dim b64 = Convert.ToString(regKey.GetValue("EncryptedPayload"))
                        If Not String.IsNullOrWhiteSpace(b64) Then
                            Dim raw = Convert.FromBase64String(b64)
                            Dim plain = ProtectedData.Unprotect(raw, Nothing, DataProtectionScope.LocalMachine)
                            foundObject = JObject.Parse(Encoding.UTF8.GetString(plain))
                        Else
                            Dim savedSerial = Convert.ToString(regKey.GetValue("SavedSerial"))
                            If Not String.IsNullOrWhiteSpace(savedSerial) Then
                                foundObject = New JObject From {{"saved_serial", savedSerial.Trim()}, {"status", "active"}}
                            End If
                        End If
                    End If
                End Using
            Catch
            End Try
        End If

        ' إذا لم يوجد، فحص سجل النظام HKLM
        If foundObject Is Nothing Then
            Try
                Using baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                    Using regKey = baseKey.OpenSubKey(RegistryKeyPath)
                        If regKey IsNot Nothing Then
                            Dim b64 = Convert.ToString(regKey.GetValue("EncryptedPayload"))
                            If Not String.IsNullOrWhiteSpace(b64) Then
                                Dim raw = Convert.FromBase64String(b64)
                                Dim plain = ProtectedData.Unprotect(raw, Nothing, DataProtectionScope.LocalMachine)
                                foundObject = JObject.Parse(Encoding.UTF8.GetString(plain))
                            End If
                        End If
                    End Using
                End Using
            Catch
            End Try
        End If

        ' التوافق التلقائي الذاتي والترقية مع النظام القديم (sys.dat)
        If foundObject Is Nothing Then
            Try
                Dim legacyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sys.dat")
                If File.Exists(legacyPath) Then
                    Dim enc = File.ReadAllText(legacyPath)
                    Using aes As Aes = Aes.Create()
                        aes.Key = Encoding.UTF8.GetBytes("MySuperSecretKey123!".PadRight(32, "0"c))
                        aes.IV = Encoding.UTF8.GetBytes("1234567890123456")
                        Using decryptor = aes.CreateDecryptor()
                            Dim cipherBytes = Convert.FromBase64String(enc)
                            Dim plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length)
                            Dim legacyText = Encoding.UTF8.GetString(plainBytes)
                            Dim parts = legacyText.Split("|"c)
                            If parts.Length > 0 AndAlso Not String.IsNullOrWhiteSpace(parts(0)) Then
                                foundObject = New JObject From {
                                    {"saved_serial", parts(0).Trim()},
                                    {"status", "active"},
                                    {"expires_at", DateTime.Today.AddYears(1).ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}
                                }
                            End If
                        End Using
                    End Using
                End If
            Catch
            End Try
        End If

        ' المعالجة التلقائية الذاتية (Self-Healing): إذا وجد في مكان واحد ولم يوجد في باقي الأماكن نقوم بمزامنته فوراً
        If foundObject IsNot Nothing Then
            Try
                Dim needHealing = Not File.Exists(PrimaryCachePath) OrElse Not File.Exists(LocalAppCachePath)
                If needHealing Then
                    Save(foundObject)
                End If
            Catch
            End Try
        End If

        Return foundObject
    End Function

    Public Shared Sub Delete(Optional keepSerial As Boolean = True)
        Try
            If keepSerial Then
                Dim obj = Load()
                If obj IsNot Nothing Then
                    obj("status") = "inactive"
                    Save(obj)
                    Return
                End If
            End If

            If File.Exists(PrimaryCachePath) Then File.Delete(PrimaryCachePath)
            If File.Exists(LocalAppCachePath) Then File.Delete(LocalAppCachePath)
            If File.Exists(RoamingAppCachePath) Then File.Delete(RoamingAppCachePath)
            If File.Exists(SharedAppCachePath) Then File.Delete(SharedAppCachePath)

            Try
                Using regKey = Registry.CurrentUser.OpenSubKey("Software\Sestamk", True)
                    If regKey IsNot Nothing Then regKey.DeleteSubKeyTree("License", False)
                End Using
            Catch
            End Try
        Catch
        End Try
    End Sub

    Public Shared Function IsOfflineAllowed(cache As JObject) As Boolean
        If cache Is Nothing Then Return False
        Dim status = Convert.ToString(cache("status")).ToLowerInvariant()
        If status <> "active" AndAlso status <> "grace_period" Then Return False

        Dim expiresAt As DateTime
        Dim expStr = Convert.ToString(cache("expires_at"))
        If DateTime.TryParse(expStr, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, expiresAt) OrElse DateTime.TryParse(expStr, expiresAt) Then
            Dim graceDays = 0
            Dim graceToken = cache("grace_days")
            If graceToken IsNot Nothing Then Integer.TryParse(Convert.ToString(graceToken), graceDays)
            Dim effectiveExpiry = expiresAt.Date.AddDays(graceDays)
            If DateTime.Today > effectiveExpiry Then Return False
        End If

        Dim lastSync As DateTime
        Dim syncStr = Convert.ToString(If(cache("last_successful_sync_utc"), cache("last_successful_sync")))
        If DateTime.TryParse(syncStr, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, lastSync) OrElse DateTime.TryParse(syncStr, lastSync) Then
            If DateTime.UtcNow.Subtract(lastSync.ToUniversalTime()).TotalDays > LicenseSettings.OfflineCacheDays Then
                Return False
            End If
        End If

        Return True
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

        Dim savedSerial = Convert.ToString(cache("saved_serial")).Trim()

        ' تسريع فوري: إذا كان الكاش المحلي صالحاً، يتم قبول الترخيص فوراً في 0ms بدون تجميد الشاشة
        If Not forceOnlineCheck AndAlso LicenseCache.IsOfflineAllowed(cache) Then
            Dim bgLicenseCheck = Task.Run(Async Function()
                         Try
                             Dim bgResponse = Await RequestAsync(savedSerial)
                             If IsServerValid(bgResponse) Then
                                 bgResponse("saved_serial") = savedSerial
                                 LicenseCache.Save(bgResponse)
                             Else
                                 Dim st = Convert.ToString(bgResponse("status")).ToLowerInvariant()
                                 If st = "revoked" OrElse st = "blocked" OrElse st = "expired" Then
                                     bgResponse("saved_serial") = savedSerial
                                     LicenseCache.Save(bgResponse)
                                     Dim revokedMsg = ReadMessage(bgResponse, "تم إيقاف أو انتهاء ترخيص البرنامج من السيرفر.")
                                     RaiseEvent LicenseInvalidated(revokedMsg)
                                 End If
                             End If
                         Catch
                             ' في حال انقطاع الاتصال أو بطء الشبكة في الخلفية، يستمر العمل دون تعطيل
                         End Try
                     End Function)

            Return New LicenseCheckResult With {.IsValid = True, .Payload = cache, .IsOffline = False}
        End If

        Try
            Dim response = Await RequestAsync(savedSerial)
            If IsServerValid(response) Then
                response("saved_serial") = savedSerial
                LicenseCache.Save(response)
                Return New LicenseCheckResult With {.IsValid = True, .Payload = response}
            End If

            ' الترخيص غير ساري حالياً على السيرفر - نحفظ الحالة مع بقاء السيريال محفوظاً دائماً
            response("saved_serial") = savedSerial
            LicenseCache.Save(response)
            Dim failMsg = ReadMessage(response, "تم إيقاف أو انتهاء الترخيص.")
            RaiseEvent LicenseInvalidated(failMsg)
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = failMsg, .Payload = response}
        Catch ex As HttpRequestException
            If LicenseCache.IsOfflineAllowed(cache) Then
                Return New LicenseCheckResult With {.IsValid = True, .IsOffline = True, .Payload = cache, .Message = "تعمل النسخة مؤقتاً دون اتصال بالإنترنت."}
            End If
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = "يلزم الاتصال بالإنترنت للتحقق من الترخيص.", .Payload = cache}
        Catch ex As TaskCanceledException
            If LicenseCache.IsOfflineAllowed(cache) Then
                Return New LicenseCheckResult With {.IsValid = True, .IsOffline = True, .Payload = cache}
            End If
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = "انتهت مهلة التحقق من الترخيص.", .Payload = cache}
        Catch ex As Exception
            If LicenseCache.IsOfflineAllowed(cache) Then
                Return New LicenseCheckResult With {.IsValid = True, .IsOffline = True, .Payload = cache}
            End If
            Return New LicenseCheckResult With {.RequiresActivation = True, .Message = "تعذر التحقق من الترخيص: " & ex.Message, .Payload = cache}
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