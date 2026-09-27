Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq

Namespace Services

    Public Enum WhatsAppConnectionStatus
        Unknown
        Connecting
        QrReady
        Connected
        Disconnected
        ServiceDown
        AuthFailure
    End Enum

    ''' <summary>
    ''' خدمة التواصل المركزية مع محرك الواتساب (سحابياً أو محلياً)
    ''' مصممة لتكون خفيفة ومستقرة وغير مسببة لأي تجميد بالواجهة.
    ''' </summary>
    Public Class WhatsAppService

        Private Shared ReadOnly _http As New HttpClient() With {
            .Timeout = TimeSpan.FromSeconds(15)
        }

        Private Shared _cachedToken As String = Nothing
        Private Shared _tokenExpiry As DateTime = DateTime.MinValue
        Private Shared ReadOnly _tokenLock As New SemaphoreSlim(1, 1)

        Public Shared ReadOnly Property BaseUrl As String
            Get
                Dim url = SettingsManager.GetSetting(SettingsKeys.WhatsAppServerUrl)
                If String.IsNullOrWhiteSpace(url) Then
                    Return "http://127.0.0.1:3000"
                End If
                Return url.TrimEnd("/"c)
            End Get
        End Property

        Public Shared ReadOnly Property ApiSecret As String
            Get
                Dim secret = SettingsManager.GetSetting(SettingsKeys.WhatsAppApiSecret)
                If String.IsNullOrWhiteSpace(secret) Then
                    Return "40ddff3e42dce8ecae15405ba523f572e526c673e0b40051a8d67aee1bdab190"
                End If
                Return secret.Trim()
            End Get
        End Property

        Public Shared ReadOnly Property IsEnabled As Boolean
            Get
                Return SettingsManager.GetBoolSetting(SettingsKeys.WhatsAppEnabled, False)
            End Get
        End Property

        Public Shared ReadOnly Property Mode As String
            Get
                Dim m = SettingsManager.GetSetting(SettingsKeys.WhatsAppMode)
                If String.IsNullOrWhiteSpace(m) Then Return "Cloud"
                Return m
            End Get
        End Property

        ' ── مصادقة JWT والحصول على التوكن ────────────────────────────────────
        Private Shared Async Function GetValidTokenAsync(Optional ct As CancellationToken = Nothing) As Task(Of String)
            Await _tokenLock.WaitAsync(ct)
            Try
                If Not String.IsNullOrEmpty(_cachedToken) AndAlso DateTime.UtcNow < _tokenExpiry Then
                    Return _cachedToken
                End If

                Dim secret = ApiSecret
                If String.IsNullOrWhiteSpace(secret) Then
                    Return Nothing
                End If

                Dim jsonPayload = "{""secret"":""" & secret.Replace("""", "\""") & """}"
                Dim content = New StringContent(jsonPayload, Encoding.UTF8, "application/json")

                Dim resp = Await _http.PostAsync(BaseUrl & "/auth", content, ct)
                If resp.IsSuccessStatusCode Then
                    Dim body = Await resp.Content.ReadAsStringAsync()
                    Dim jo = JObject.Parse(body)
                    _cachedToken = jo("token")?.ToString()
                    _tokenExpiry = DateTime.UtcNow.AddMinutes(50)
                    Return _cachedToken
                End If
                Return Nothing
            Catch ex As Exception
                Return Nothing
            Finally
                _tokenLock.Release()
            End Try
        End Function

        ' ── فحص حالة الاتصال بالسيرفر والواتساب ───────────────────────────────
        Public Shared Async Function HealthCheckAsync(Optional ct As CancellationToken = Nothing) As Task(Of (ok As Boolean, status As String, mePhone As String))
            Try
                Dim resp = Await _http.GetAsync(BaseUrl & "/health", ct)
                If Not resp.IsSuccessStatusCode Then
                    Return (False, "ServiceDown", Nothing)
                End If

                Dim body = Await resp.Content.ReadAsStringAsync()
                Dim jo = JObject.Parse(body)
                Dim waStatus = If(jo("waStatus") IsNot Nothing, jo("waStatus").ToString(), "UNKNOWN")
                Dim mePhone = If(jo("me") IsNot Nothing, jo("me").ToString(), Nothing)
                Return (True, waStatus, mePhone)
            Catch ex As Exception
                Return (False, "ServiceDown", Nothing)
            End Try
        End Function

        ' ── جلب رمز الاستجابة السريع (QR Code Base64) ─────────────────────────
        Public Shared Async Function GetQrBase64Async(Optional ct As CancellationToken = Nothing) As Task(Of String)
            Try
                Dim req As New HttpRequestMessage(HttpMethod.Get, BaseUrl & "/qr")
                Dim token = Await GetValidTokenAsync(ct)
                If Not String.IsNullOrEmpty(token) Then
                    req.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)
                End If

                Dim resp = Await _http.SendAsync(req, ct)
                If Not resp.IsSuccessStatusCode Then
                    Return Nothing
                End If

                Dim body = Await resp.Content.ReadAsStringAsync()
                Dim jo = JObject.Parse(body)
                Return jo("qr")?.ToString()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' ── إرسال رسالة نصية ─────────────────────────────────────────────────
        Public Shared Async Function SendTextAsync(phone As String, message As String, Optional ct As CancellationToken = Nothing) As Task(Of (success As Boolean, [error] As String))
            Try
                Dim token = Await GetValidTokenAsync(ct)
                Dim jo As New JObject()
                jo("phone") = phone
                jo("message") = message

                Dim req As New HttpRequestMessage(HttpMethod.Post, BaseUrl & "/send") With {
                    .Content = New StringContent(jo.ToString(), Encoding.UTF8, "application/json")
                }
                If Not String.IsNullOrEmpty(token) Then
                    req.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)
                End If

                Dim resp = Await _http.SendAsync(req, ct)
                Dim body = Await resp.Content.ReadAsStringAsync()

                If resp.IsSuccessStatusCode Then
                    Return (True, Nothing)
                Else
                    Return (False, body)
                End If
            Catch ex As Exception
                Return (False, ex.Message)
            End Try
        End Function

        ' ── إرسال ملف / صورة / PDF ──────────────────────────────────────────
        Public Shared Async Function SendMediaAsync(phone As String, filePath As String, Optional caption As String = "", Optional ct As CancellationToken = Nothing) As Task(Of (success As Boolean, [error] As String))
            Try
                If Not File.Exists(filePath) Then
                    Return (False, "الملف غير موجود على الجهاز")
                End If

                Dim token = Await GetValidTokenAsync(ct)
                Dim fileBytes = File.ReadAllBytes(filePath)
                Dim base64 = Convert.ToBase64String(fileBytes)
                Dim fileName = Path.GetFileName(filePath)

                Dim jo As New JObject()
                jo("phone") = phone
                jo("fileName") = fileName
                jo("fileData") = base64
                jo("caption") = caption

                Dim req As New HttpRequestMessage(HttpMethod.Post, BaseUrl & "/send-media") With {
                    .Content = New StringContent(jo.ToString(), Encoding.UTF8, "application/json")
                }
                If Not String.IsNullOrEmpty(token) Then
                    req.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)
                End If

                Dim resp = Await _http.SendAsync(req, ct)
                Dim body = Await resp.Content.ReadAsStringAsync()

                If resp.IsSuccessStatusCode Then
                    Return (True, Nothing)
                Else
                    Return (False, body)
                End If
            Catch ex As Exception
                Return (False, ex.Message)
            End Try
        End Function

        ' ── إعادة تعيين / فك ربط الجلسة (Reset Session) ────────────────────────
        Public Shared Async Function ResetSessionAsync(Optional ct As CancellationToken = Nothing) As Task(Of Boolean)
            Try
                _cachedToken = Nothing
                Dim token = Await GetValidTokenAsync(ct)
                Dim req As New HttpRequestMessage(HttpMethod.Post, BaseUrl & "/reset")
                If Not String.IsNullOrEmpty(token) Then
                    req.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)
                End If
                Dim resp = Await _http.SendAsync(req, ct)
                Return resp.IsSuccessStatusCode
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
