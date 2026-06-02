Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Security.Cryptography
Imports System.Management

Module CheckActivation

    ' ===== إعدادات =====
    Private ReadOnly activationFile As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\sys.dat"
    Private ReadOnly aesKey As String = "MySuperSecretKey123!" ' غيّره لمفتاحك السري
    Private ReadOnly apiUrl As String = "https://cxcbyoepjbphylyvwhgw.supabase.co/functions/v1/validate-license" ' رابط API
    Private ReadOnly serviceRoleKey As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImN4Y2J5b2VwamJwaHlseXZ3aGd3Iiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc2MzMwODAzMywiZXhwIjoyMDc4ODg0MDMzfQ.kpu9TDIL5q0PDhaabto3qEK2K5h-8H6Ob3k8miMNmhw" ' مفتاح SERVICE_ROLE_KEY_CUSTOM من Supabase

    ' ===== 1) GET HWID =====
    Public Function GetHWID() As String
        Try
            Dim cpu As String = ""
            For Each mo As ManagementObject In New ManagementClass("Win32_Processor").GetInstances()
                cpu = mo("ProcessorId").ToString()
                Exit For
            Next
            Return cpu
        Catch
            Return "UNKNOWN"
        End Try
    End Function

    ' ===== 2) AES ENCRYPT =====
    Public Function EncryptText(text As String, key As String) As String
        Using aes As Aes = Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32, "0"))
            aes.IV = Encoding.UTF8.GetBytes("1234567890123456")
            Dim encryptor = aes.CreateEncryptor()
            Dim bytes = Encoding.UTF8.GetBytes(text)
            Dim encrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length)
            Return Convert.ToBase64String(encrypted)
        End Using
    End Function

    ' ===== 3) AES DECRYPT =====
    Public Function DecryptText(cipher As String, key As String) As String
        Using aes As Aes = Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32, "0"))
            aes.IV = Encoding.UTF8.GetBytes("1234567890123456")
            Dim decryptor = aes.CreateDecryptor()
            Dim data = Convert.FromBase64String(cipher)
            Dim decrypted = decryptor.TransformFinalBlock(data, 0, data.Length)
            Return Encoding.UTF8.GetString(decrypted)
        End Using
    End Function

    ' ===== 4) SAVE LICENSE FILE =====
    Public Sub SaveActivationFile(licenseKey As String, signature As String)
        Try
            Dim content As String = $"{licenseKey}|{signature}"
            Dim encrypted As String = EncryptText(content, aesKey)

            ' لو الملف موجود، ازيل الخصائص القديمة
            If IO.File.Exists(activationFile) Then
                Dim oldInfo As New IO.FileInfo(activationFile)
                oldInfo.Attributes = IO.FileAttributes.Normal
            End If

            ' اكتب الملف
            IO.File.WriteAllText(activationFile, encrypted)

            ' اخفاء الملف بعد الكتابة
            Dim info As New IO.FileInfo(activationFile)
            info.Attributes = IO.FileAttributes.Hidden Or IO.FileAttributes.System
        Catch ex As Exception
            MsgBox("Error saving activation file: " & ex.Message)
        End Try
    End Sub


    ' ===== 5) LOAD LICENSE FILE =====
    Public Function LoadActivationFile() As (String, String)
        If Not IO.File.Exists(activationFile) Then Return (Nothing, Nothing)
        Try
            Dim encrypted As String = IO.File.ReadAllText(activationFile)
            Dim decrypted As String = DecryptText(encrypted, aesKey)
            Dim parts = decrypted.Split("|"c)
            Return (parts(0), parts(1))
        Catch
            Return (Nothing, Nothing)
        End Try
    End Function

    ' ===== 6) CHECK INTERNET CONNECTION =====
    ' [FIX] حُذفت الدالة HasInternetConnection - كانت تفتح اتصال HTTP
    '       لـ google.com بدون Timeout = حجب لمدة قد تصل إلى دقائق.
    '       بدلاً من ذلك نعتمد على Timeout القصير في ValidateLicenseOnline
    '       نفسها (5 ثواني) وإن فشل نرجع للملف المحلي.

    ' ===== 7) CALL API AND VALIDATE =====
    Public Function ValidateLicenseOnline(licenseKey As String, hwid As String) As JObject
        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(apiUrl), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.Headers.Add("Authorization", "Bearer " & serviceRoleKey)
            ' [FIX] إضافة Timeout قصير لمنع تجمد البرنامج عند بطء الشبكة
            request.Timeout = 5000           ' 5 ثواني لإنشاء الاتصال + إرسال الطلب
            request.ReadWriteTimeout = 5000  ' 5 ثواني لقراءة الرد

            Dim jsonData = JsonConvert.SerializeObject(New With {
                .license_key = licenseKey,
                .hwid = hwid
            })
            Dim bytes = Encoding.UTF8.GetBytes(jsonData)
            Using stream = request.GetRequestStream()
                stream.Write(bytes, 0, bytes.Length)
            End Using

            Using response = CType(request.GetResponse(), HttpWebResponse)
                Using reader As New IO.StreamReader(response.GetResponseStream())
                    Dim result As String = reader.ReadToEnd()
                    Return JObject.Parse(result)
                End Using
            End Using
        Catch
            Return JObject.Parse("{""success"":false,""payload"":{""valid"":false},""message"":""Server unreachable""}")
        End Try
    End Function

    ' ===== 8) MAIN CHECK FUNCTION =====
    ' [FIX] حُذف شرط HasInternetConnection (كان حجب مزدوج).
    '       الآن نحاول التحقق Online مباشرة مع Timeout 5 ثواني،
    '       وإن فشل (server unreachable) نعود تلقائياً للملف المحلي.
    Public Function IsActivated() As Boolean
        Dim hwid = GetHWID()
        Dim saved = LoadActivationFile()

        ' محاولة التحقق Online (مع Timeout)
        If saved.Item1 IsNot Nothing Then
            Try
                Dim result = ValidateLicenseOnline(saved.Item1, hwid)
                Dim success = result("success").ToObject(Of Boolean)
                Dim valid = If(result("payload")?("valid") IsNot Nothing,
                               result("payload")("valid").ToObject(Of Boolean), False)

                If success AndAlso valid Then
                    ' حدث الملف المحلي بالتوقيع الجديد
                    Try
                        SaveActivationFile(saved.Item1, result("signature").ToString())
                    Catch
                    End Try
                    Return True
                End If

                ' لو الـ message يدل على عدم وصول السيرفر، نعود للملف المحلي
                Dim msg As String = If(result("message")?.ToString(), "")
                If Not String.IsNullOrEmpty(msg) AndAlso msg.Contains("unreachable") Then
                    ' fallback للملف المحلي بالأسفل
                Else
                    ' السيرفر رد بـ "غير صالح" صراحة
                    Return False
                End If
            Catch
                ' أي خطأ آخر → fallback للملف المحلي
            End Try
        End If

        ' fallback: الاعتماد على الملف المحلي
        If saved.Item1 IsNot Nothing AndAlso saved.Item2 IsNot Nothing Then
            Return True
        End If

        Return False
    End Function
    ' ===== 9) CHECK ACTIVATION IN BACKGROUND =====
    ' [FIX] حُذف شرط HasInternetConnection (كان حجب مزدوج).
    '       نحاول التحقق مباشرة. أي خطأ في الشبكة → True (لا نقفل البرنامج).
    Public Function CheckActivationBackground() As Boolean
        Try
            Dim hwid = GetHWID()
            Dim saved = LoadActivationFile()

            If saved.Item1 Is Nothing Then
                Return False
            End If

            Dim result As JObject
            Try
                result = ValidateLicenseOnline(saved.Item1, hwid)
            Catch
                Return True ' فشل الاتصال → لا نقفل
            End Try

            Dim msg As String = If(result("message")?.ToString(), "")
            If Not String.IsNullOrEmpty(msg) AndAlso msg.Contains("unreachable") Then
                Return True ' السيرفر غير قابل للوصول → لا نقفل
            End If

            Dim success = result("success").ToObject(Of Boolean)
            Dim valid = If(result("payload")?("valid") IsNot Nothing,
                       result("payload")("valid").ToObject(Of Boolean),
                       False)

            Return (success AndAlso valid)

        Catch
            Return True ' أي خطأ → ما نقفلش البرنامج
        End Try
    End Function

End Module
