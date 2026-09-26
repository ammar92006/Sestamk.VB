Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Threading
Imports System.Threading.Tasks

Namespace Services.Cloud
    ''' <summary>
    ''' مراقب حالة الشبكة والاتصال بالإنترنت (Network Monitor for Cloud Sync)
    ''' </summary>
    Public NotInheritable Class NetworkMonitor
        Private Shared ReadOnly _httpClient As New HttpClient()
        Private Shared _cachedIsOnline As Boolean = False
        Private Shared _lastCheckTime As DateTime = DateTime.MinValue
        Private Shared ReadOnly _cacheDuration As TimeSpan = TimeSpan.FromSeconds(10)
        Private Shared _monitoringTimer As Timer

        ' حدث عند تغير حالة الاتصال (Event triggered on connectivity change)
        Public Shared Event ConnectivityChanged(isOnline As Boolean)

        Shared Sub New()
            _httpClient.Timeout = TimeSpan.FromSeconds(5) ' مهلة 5 ثواني (5 seconds timeout)
        End Sub

        ''' <summary>
        ''' التحقق من الاتصال بالإنترنت بشكل غير متزامن (Check internet connection asynchronously)
        ''' </summary>
        Public Shared Async Function IsOnlineAsync() As Task(Of Boolean)
            ' التحقق من ذاكرة التخزين المؤقت (Check cache first)
            If (DateTime.Now - _lastCheckTime) < _cacheDuration Then
                Return _cachedIsOnline
            End If

            Dim result As Boolean = False

            Try
                ' 1. التحقق المبدئي من واجهة الشبكة (Initial check via NetworkInterface)
                If NetworkInterface.GetIsNetworkAvailable() Then
                    ' 2. إرسال طلب HTTP للتأكد من الاتصال الفعلي (Verify actual connection via HTTP HEAD)
                    Dim request As New HttpRequestMessage(HttpMethod.Head, "https://api.turso.tech")
                    Using response = Await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(False)
                        result = response.IsSuccessStatusCode
                    End Using
                End If
            Catch ex As Exception
                ' حدث خطأ أثناء التحقق، نعتبر الجهاز غير متصل (Error checking network, consider offline)
                result = False
            End Try

            ' تحديث ذاكرة التخزين المؤقت وإطلاق الحدث إذا تغيرت الحالة (Update cache and raise event if changed)
            Dim statusChanged As Boolean = (result <> _cachedIsOnline)
            _cachedIsOnline = result
            _lastCheckTime = DateTime.Now

            If statusChanged AndAlso _lastCheckTime <> DateTime.MinValue Then
                RaiseEvent ConnectivityChanged(_cachedIsOnline)
            End If

            Return _cachedIsOnline
        End Function

        ''' <summary>
        ''' التحقق المتزامن من حالة الاتصال باستخدام ذاكرة التخزين المؤقت (Synchronous check using cached result)
        ''' </summary>
        Public Shared Function IsOnline() As Boolean
            Return _cachedIsOnline
        End Function

        ''' <summary>
        ''' بدء المراقبة الدورية للاتصال (Start periodic monitoring)
        ''' </summary>
        ''' <param name="intervalMs">الفترة الزمنية بالملي ثانية (Interval in milliseconds)</param>
        Public Shared Sub StartMonitoring(intervalMs As Integer)
            StopMonitoring() ' إيقاف أي مراقبة سابقة (Stop any existing monitoring)

            _monitoringTimer = New Timer(
                Async Sub(state)
                    Await IsOnlineAsync().ConfigureAwait(False)
                End Sub,
                Nothing,
                0,
                intervalMs)
        End Sub

        ''' <summary>
        ''' إيقاف المراقبة الدورية (Stop periodic monitoring)
        ''' </summary>
        Public Shared Sub StopMonitoring()
            If _monitoringTimer IsNot Nothing Then
                _monitoringTimer.Dispose()
                _monitoringTimer = Nothing
            End If
        End Sub
    End Class
End Namespace
