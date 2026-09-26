Imports System
Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Services.Cloud

    ''' <summary>
    ''' Data class representing Turso Database Information.
    ''' صنف بيانات يمثل معلومات قاعدة بيانات Turso.
    ''' </summary>
    Public Class TursoDbInfo
        Public Property Name As String
        Public Property DbId As String
        Public Property Hostname As String
        
        ''' <summary>
        ''' Computed property to get the HTTP URL.
        ''' خاصية محسوبة للحصول على رابط HTTP.
        ''' </summary>
        Public ReadOnly Property HttpUrl As String
            Get
                If String.IsNullOrEmpty(Hostname) Then Return String.Empty
                Return $"https://{Hostname}"
            End Get
        End Property
    End Class

    ''' <summary>
    ''' Client for Turso's Platform API to manage databases programmatically.
    ''' عميل لواجهة برمجة تطبيقات منصة Turso لإدارة قواعد البيانات.
    ''' </summary>
    Public Class TursoPlatformClient
        Implements IDisposable

        Private ReadOnly _httpClient As HttpClient
        Private ReadOnly _organizationSlug As String
        Private ReadOnly _baseUrl As String = "https://api.turso.tech/v1"
        Private _isDisposed As Boolean = False

        ''' <summary>
        ''' Initializes a new instance of the TursoPlatformClient.
        ''' تهيئة كائن جديد من عميل منصة Turso.
        ''' </summary>
        Public Sub New(platformToken As String, organizationSlug As String)
            Me._organizationSlug = organizationSlug
            
            _httpClient = New HttpClient()
            _httpClient.Timeout = TimeSpan.FromSeconds(30)
            _httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", platformToken)
        End Sub

        ''' <summary>
        ''' Creates a new Turso database.
        ''' إنشاء قاعدة بيانات جديدة.
        ''' </summary>
        Public Async Function CreateDatabaseAsync(dbName As String, Optional group As String = "default") As Task(Of TursoDbInfo)
            Dim url = $"{_baseUrl}/organizations/{_organizationSlug}/databases"
            
            Dim payload As New JObject()
            payload("name") = dbName
            payload("group") = group
            
            Dim content As New StringContent(payload.ToString(), Encoding.UTF8, "application/json")
            
            Dim response = Await _httpClient.PostAsync(url, content).ConfigureAwait(False)
            Dim responseString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            
            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Failed to create database: {response.StatusCode} - {responseString}")
            End If
            
            Dim jsonObj = JObject.Parse(responseString)
            Dim dbObj = jsonObj("database")
            
            If dbObj IsNot Nothing Then
                Return New TursoDbInfo() With {
                    .Name = dbObj("name")?.ToString(),
                    .DbId = dbObj("database_id")?.ToString(),
                    .Hostname = dbObj("hostname")?.ToString()
                }
            End If
            
            Return Nothing
        End Function

        ''' <summary>
        ''' Creates an authentication token for a database.
        ''' إنشاء رمز مصادقة لقاعدة البيانات.
        ''' </summary>
        Public Async Function CreateAuthTokenAsync(dbName As String, Optional expiration As String = "none", Optional authorization As String = "full-access") As Task(Of String)
            Dim url = $"{_baseUrl}/organizations/{_organizationSlug}/databases/{dbName}/auth/tokens?expiration={expiration}&authorization={authorization}"
            
            Dim content As New StringContent(String.Empty, Encoding.UTF8, "application/json")
            
            Dim response = Await _httpClient.PostAsync(url, content).ConfigureAwait(False)
            Dim responseString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            
            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Failed to create auth token: {response.StatusCode} - {responseString}")
            End If
            
            Dim jsonObj = JObject.Parse(responseString)
            Return jsonObj("jwt")?.ToString()
        End Function

        ''' <summary>
        ''' Lists all databases in the organization.
        ''' عرض جميع قواعد البيانات في المنظمة.
        ''' </summary>
        Public Async Function ListDatabasesAsync() As Task(Of List(Of TursoDbInfo))
            Dim url = $"{_baseUrl}/organizations/{_organizationSlug}/databases"
            
            Dim response = Await _httpClient.GetAsync(url).ConfigureAwait(False)
            Dim responseString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            
            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Failed to list databases: {response.StatusCode} - {responseString}")
            End If
            
            Dim resultList As New List(Of TursoDbInfo)()
            Dim jsonObj = JObject.Parse(responseString)
            Dim dbs = jsonObj("databases")
            
            If dbs IsNot Nothing AndAlso dbs.Type = JTokenType.Array Then
                For Each dbObj In dbs
                    resultList.Add(New TursoDbInfo() With {
                        .Name = dbObj("name")?.ToString(),
                        .DbId = dbObj("database_id")?.ToString(),
                        .Hostname = dbObj("hostname")?.ToString()
                    })
                Next
            End If
            
            Return resultList
        End Function

        ''' <summary>
        ''' Gets information for a specific database.
        ''' الحصول على معلومات قاعدة بيانات محددة.
        ''' </summary>
        Public Async Function GetDatabaseInfoAsync(dbName As String) As Task(Of TursoDbInfo)
            Dim url = $"{_baseUrl}/organizations/{_organizationSlug}/databases/{dbName}"
            
            Dim response = Await _httpClient.GetAsync(url).ConfigureAwait(False)
            Dim responseString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            
            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Failed to get database info: {response.StatusCode} - {responseString}")
            End If
            
            Dim jsonObj = JObject.Parse(responseString)
            Dim dbObj = jsonObj("database")
            
            If dbObj IsNot Nothing Then
                Return New TursoDbInfo() With {
                    .Name = dbObj("name")?.ToString(),
                    .DbId = dbObj("database_id")?.ToString(),
                    .Hostname = dbObj("hostname")?.ToString()
                }
            End If
            
            Return Nothing
        End Function

        ''' <summary>
        ''' Deletes a specific database.
        ''' حذف قاعدة بيانات محددة.
        ''' </summary>
        Public Async Function DeleteDatabaseAsync(dbName As String) As Task(Of Boolean)
            Dim url = $"{_baseUrl}/organizations/{_organizationSlug}/databases/{dbName}"
            
            Dim response = Await _httpClient.DeleteAsync(url).ConfigureAwait(False)
            
            If response.IsSuccessStatusCode Then
                Return True
            End If
            
            Dim responseString = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
            Throw New Exception($"Failed to delete database: {response.StatusCode} - {responseString}")
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
