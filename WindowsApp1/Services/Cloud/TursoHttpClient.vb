Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading.Tasks
Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Services.Cloud

    ''' <summary>
    ''' Custom exception for Turso API errors.
    ''' استثناء مخصص لأخطاء واجهة برمجة تطبيقات Turso.
    ''' </summary>
    Public Class TursoException
        Inherits Exception

        Public Property StatusCode As Integer
        Public Property TursoMessage As String

        Public Sub New(message As String, statusCode As Integer, tursoMessage As String)
            MyBase.New(message)
            Me.StatusCode = statusCode
            Me.TursoMessage = tursoMessage
        End Sub
    End Class

    ''' <summary>
    ''' Core HTTP client for communicating with Turso's Hrana protocol v2 over HTTP.
    ''' العميل الأساسي للاتصال بقاعدة بيانات Turso عبر بروتوكول Hrana v2.
    ''' </summary>
    Public Class TursoHttpClient
        Implements IDisposable

        Private ReadOnly _httpClient As HttpClient
        Private ReadOnly _databaseUrl As String
        Private ReadOnly _authToken As String
        Private _isDisposed As Boolean = False

        ' إعداد TLS 1.2
        Shared Sub New()
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol Or SecurityProtocolType.Tls12
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the TursoHttpClient.
        ''' تهيئة كائن جديد من عميل Turso.
        ''' </summary>
        Public Sub New(databaseUrl As String, authToken As String)
            Me._authToken = authToken
            
            ' Normalize URL: convert libsql:// to https:// and append /v2/pipeline
            ' تسوية الرابط: تحويل libsql إلى https وإضافة مسار v2/pipeline
            If databaseUrl.StartsWith("libsql://") Then
                databaseUrl = "https://" & databaseUrl.Substring(9)
            End If
            
            If Not databaseUrl.EndsWith("/v2/pipeline") Then
                databaseUrl = databaseUrl.TrimEnd("/"c) & "/v2/pipeline"
            End If
            
            Me._databaseUrl = databaseUrl

            _httpClient = New HttpClient()
            _httpClient.Timeout = TimeSpan.FromSeconds(30)
            _httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", _authToken)
        End Sub

        ''' <summary>
        ''' Executes a SELECT query and returns a DataTable.
        ''' تنفيذ استعلام SELECT وإرجاع جدول بيانات.
        ''' </summary>
        Public Async Function ExecuteQueryAsync(sql As String, Optional args As Object() = Nothing) As Task(Of DataTable)
            Dim payload = BuildPipelinePayload(sql, args)
            Dim response = Await SendRequestAsync(payload).ConfigureAwait(False)

            Dim dataTable As New DataTable()
            
            Try
                ' Parse response
                ' استخراج الاستجابة
                Dim results = response("results")
                If results IsNot Nothing AndAlso results.Type = JTokenType.Array AndAlso results.Count > 0 Then
                    Dim resultObj = results(0)
                    If resultObj("type") IsNot Nothing AndAlso resultObj("type").ToString() = "ok" Then
                        Dim responseData = resultObj("response")
                        If responseData IsNot Nothing AndAlso responseData("result") IsNot Nothing Then
                            Dim result = responseData("result")
                            
                            ' إنشاء الأعمدة
                            Dim cols = result("cols")
                            If cols IsNot Nothing Then
                                For Each col In cols
                                    Dim colName = col("name")?.ToString()
                                    If Not String.IsNullOrEmpty(colName) AndAlso Not dataTable.Columns.Contains(colName) Then
                                        dataTable.Columns.Add(colName)
                                    Else
                                        dataTable.Columns.Add()
                                    End If
                                Next
                            End If
                            
                            ' إضافة الصفوف
                            Dim rows = result("rows")
                            If rows IsNot Nothing Then
                                For Each row In rows
                                    Dim dataRow = dataTable.NewRow()
                                    For i As Integer = 0 To dataTable.Columns.Count - 1
                                        dataRow(i) = ExtractHranaValue(row(i))
                                    Next
                                    dataTable.Rows.Add(dataRow)
                                Next
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw New Exception("Failed to parse query result. " & ex.Message, ex)
            End Try

            Return dataTable
        End Function

        ''' <summary>
        ''' Executes an INSERT/UPDATE/DELETE query and returns affected rows.
        ''' تنفيذ استعلام وتعديل البيانات وإرجاع عدد الصفوف المتأثرة.
        ''' </summary>
        Public Async Function ExecuteNonQueryAsync(sql As String, Optional args As Object() = Nothing) As Task(Of Integer)
            Dim payload = BuildPipelinePayload(sql, args)
            Dim response = Await SendRequestAsync(payload).ConfigureAwait(False)

            Try
                Dim results = response("results")
                If results IsNot Nothing AndAlso results.Type = JTokenType.Array AndAlso results.Count > 0 Then
                    Dim resultObj = results(0)
                    If resultObj("type") IsNot Nothing AndAlso resultObj("type").ToString() = "ok" Then
                        Dim responseData = resultObj("response")
                        If responseData IsNot Nothing AndAlso responseData("result") IsNot Nothing Then
                            Dim affectedRowCount = responseData("result")("affected_row_count")
                            If affectedRowCount IsNot Nothing Then
                                Return affectedRowCount.Value(Of Integer)()
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw New Exception("Failed to parse non-query result. " & ex.Message, ex)
            End Try

            Return 0
        End Function

        ''' <summary>
        ''' Executes a query and returns the first column of the first row.
        ''' تنفيذ استعلام وإرجاع القيمة الأولى في الصف الأول.
        ''' </summary>
        Public Async Function ExecuteScalarAsync(sql As String, Optional args As Object() = Nothing) As Task(Of Object)
            Dim payload = BuildPipelinePayload(sql, args)
            Dim response = Await SendRequestAsync(payload).ConfigureAwait(False)

            Try
                Dim results = response("results")
                If results IsNot Nothing AndAlso results.Type = JTokenType.Array AndAlso results.Count > 0 Then
                    Dim resultObj = results(0)
                    If resultObj("type") IsNot Nothing AndAlso resultObj("type").ToString() = "ok" Then
                        Dim responseData = resultObj("response")
                        If responseData IsNot Nothing AndAlso responseData("result") IsNot Nothing Then
                            Dim rows = responseData("result")("rows")
                            If rows IsNot Nothing AndAlso rows.HasValues AndAlso rows(0).HasValues Then
                                Return ExtractHranaValue(rows(0)(0))
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw New Exception("Failed to parse scalar result. " & ex.Message, ex)
            End Try

            Return Nothing
        End Function

        ''' <summary>
        ''' Executes an atomic transaction batch.
        ''' تنفيذ مجموعة من الاستعلامات كمعاملة واحدة.
        ''' </summary>
        Public Async Function ExecuteTransactionAsync(statements As IEnumerable(Of Tuple(Of String, Object()))) As Task(Of Boolean)
            If statements Is Nothing OrElse Not statements.Any() Then Return True

            Dim requests As New JArray()
            For Each stmt In statements
                Dim stmtObj As New JObject()
                stmtObj("sql") = stmt.Item1
                
                If stmt.Item2 IsNot Nothing AndAlso stmt.Item2.Length > 0 Then
                    Dim argsArray As New JArray()
                    For Each arg In stmt.Item2
                        argsArray.Add(ConvertToHranaArgs(arg))
                    Next
                    stmtObj("args") = argsArray
                End If

                Dim requestItem As New JObject()
                requestItem("type") = "execute"
                requestItem("stmt") = stmtObj
                requests.Add(requestItem)
            Next
            
            Dim payload As New JObject()
            payload("requests") = requests

            Try
                Dim response = Await SendRequestAsync(payload).ConfigureAwait(False)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Tests connectivity with SELECT 1.
        ''' اختبار الاتصال بقاعدة البيانات.
        ''' </summary>
        Public Async Function TestConnectionAsync() As Task(Of Boolean)
            Try
                Dim result = Await ExecuteScalarAsync("SELECT 1").ConfigureAwait(False)
                Return Convert.ToInt32(result) = 1
            Catch
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Builds JSON request body for Hrana v2.
        ''' بناء جسم الطلب بصيغة JSON لبروتوكول Hrana.
        ''' </summary>
        Private Function BuildPipelinePayload(sql As String, args As Object()) As JObject
            Dim stmt As New JObject()
            stmt("sql") = sql

            If args IsNot Nothing AndAlso args.Length > 0 Then
                Dim argsArray As New JArray()
                For Each arg In args
                    argsArray.Add(ConvertToHranaArgs(arg))
                Next
                stmt("args") = argsArray
            End If

            Dim requestItem As New JObject()
            requestItem("type") = "execute"
            requestItem("stmt") = stmt

            Dim requests As New JArray()
            requests.Add(requestItem)

            Dim payload As New JObject()
            payload("requests") = requests

            Return payload
        End Function

        ''' <summary>
        ''' Converts .NET types to Hrana typed args.
        ''' تحويل أنواع .NET إلى الأنواع المطلوبة في Hrana.
        ''' </summary>
        Private Function ConvertToHranaArgs(arg As Object) As JObject
            Dim result As New JObject()

            If arg Is Nothing OrElse IsDBNull(arg) Then
                result("type") = "null"
            ElseIf TypeOf arg Is Boolean Then
                result("type") = "integer"
                result("value") = If(DirectCast(arg, Boolean), "1", "0")
            ElseIf TypeOf arg Is Short OrElse TypeOf arg Is Integer OrElse TypeOf arg Is Long OrElse TypeOf arg Is SByte OrElse TypeOf arg Is UShort OrElse TypeOf arg Is UInteger OrElse TypeOf arg Is ULong Then
                result("type") = "integer"
                result("value") = arg.ToString()
            ElseIf TypeOf arg Is Single OrElse TypeOf arg Is Double OrElse TypeOf arg Is Decimal Then
                result("type") = "float"
                result("value") = Convert.ToDouble(arg)
            ElseIf TypeOf arg Is Byte() Then
                result("type") = "blob"
                result("base64") = Convert.ToBase64String(DirectCast(arg, Byte()))
            ElseIf TypeOf arg Is DateTime Then
                result("type") = "text"
                result("value") = DirectCast(arg, DateTime).ToString("O")
            ElseIf TypeOf arg Is Guid Then
                result("type") = "text"
                result("value") = arg.ToString()
            Else
                result("type") = "text"
                result("value") = arg.ToString()
            End If

            Return result
        End Function

        ''' <summary>
        ''' Parses Hrana response values back to .NET types.
        ''' تحويل القيم العائدة من Hrana إلى أنواع .NET.
        ''' </summary>
        Private Function ExtractHranaValue(token As JToken) As Object
            If token Is Nothing OrElse token.Type = JTokenType.Null Then Return DBNull.Value

            Dim typeStr = token("type")?.ToString()
            If String.IsNullOrEmpty(typeStr) Then Return DBNull.Value

            Select Case typeStr
                Case "null"
                    Return DBNull.Value
                Case "integer"
                    Dim val = token("value")?.ToString()
                    Dim intVal As Long
                    If Long.TryParse(val, intVal) Then Return intVal
                    Return val
                Case "float"
                    Dim val = token("value")
                    If val IsNot Nothing Then Return val.Value(Of Double)()
                    Return 0.0
                Case "text"
                    Return token("value")?.ToString()
                Case "blob"
                    Dim base64 = token("base64")?.ToString()
                    If Not String.IsNullOrEmpty(base64) Then
                        Return Convert.FromBase64String(base64)
                    End If
                    Return Nothing
                Case Else
                    Return token.ToString()
            End Select
        End Function

        ''' <summary>
        ''' Core HTTP POST with error handling and retry logic.
        ''' الإرسال الأساسي للطلب مع معالجة الأخطاء وإعادة المحاولة.
        ''' </summary>
        Private Async Function SendRequestAsync(payload As JObject) As Task(Of JObject)
            Dim jsonPayload = payload.ToString(Formatting.None)
            Dim maxAttempts As Integer = 3
            Dim delayMs As Integer = 500

            For attempt = 1 To maxAttempts
                Dim shouldRetry As Boolean = False
                Dim lastException As Exception = Nothing

                Try
                    Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")
                    Dim response = Await _httpClient.PostAsync(_databaseUrl, content).ConfigureAwait(False)

                    If response.IsSuccessStatusCode Then
                        Dim responseString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                        Return JObject.Parse(responseString)
                    Else
                        ' Handle HTTP errors
                        ' معالجة أخطاء HTTP
                        Dim statusCode = CInt(response.StatusCode)
                        Dim errorString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                        
                        If (statusCode = 429 OrElse statusCode >= 500) AndAlso attempt < maxAttempts Then
                            shouldRetry = True
                        Else
                            Dim tursoMsg As String = errorString
                            Try
                                Dim errObj = JObject.Parse(errorString)
                                If errObj("message") IsNot Nothing Then
                                    tursoMsg = errObj("message").ToString()
                                End If
                            Catch
                            End Try

                            Throw New TursoException($"Turso API Request failed with status {statusCode}: {tursoMsg}", statusCode, tursoMsg)
                        End If
                    End If
                Catch ex As TursoException
                    Throw
                Catch ex As HttpRequestException
                    If attempt < maxAttempts Then
                        shouldRetry = True
                        lastException = ex
                    Else
                        Throw New Exception("Network error while communicating with Turso API. خطأ في الشبكة.", ex)
                    End If
                End Try

                ' تأخير إعادة المحاولة خارج كتلة Catch (مطلوب في .NET Framework 4.8)
                If shouldRetry Then
                    Await Task.Delay(delayMs).ConfigureAwait(False)
                    delayMs *= 2 ' Exponential backoff - زيادة التأخير أضعاف
                    Continue For
                End If
            Next

            Throw New Exception("Max retry attempts reached. الوصول للحد الأقصى لمحاولات الاتصال.")
        End Function

        ' IDisposable Support
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not _isDisposed Then
                If disposing Then
                    If _httpClient IsNot Nothing Then
                        _httpClient.Dispose()
                    End If
                End If
                _isDisposed = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

    End Class
End Namespace
