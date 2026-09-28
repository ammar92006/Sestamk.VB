Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Services.Sync
    ''' <summary>
    ''' خدمة مزامنة المستخدمين مع سيرفر Supabase والربط بالمنشأة (Multi-Tenant)
    ''' تقوم برفع كافة المستخدمين المحليين ببياناتهم وكلمات المرور الخاصة بهم
    ''' كما تقوم بسحب أي إعادة تعيين لكلمات المرور معتمدة من الإدارة
    ''' </summary>
    Public NotInheritable Class UserSyncService
        Private Sub New()
        End Sub

        Private Const AdminLoginUrl As String = "https://axigicbiydhfbkfqogma.supabase.co/functions/v1/admin-login"
        Private Const AdminDbUrl As String = "https://axigicbiydhfbkfqogma.supabase.co/functions/v1/admin-db"

        ''' <summary>
        ''' مزامنة مستخدمي المنشأة بالكامل إلى Supabase
        ''' </summary>
        Public Shared Async Function SyncAsync() As Task(Of Boolean)
            Try
                Dim cache = LicenseCache.Load()
                If cache Is Nothing Then Return False
                Dim companyId = Convert.ToString(cache("company_id"))
                If String.IsNullOrWhiteSpace(companyId) Then Return False

                Dim supabaseUrl = LicenseSettings.SupabaseUrl
                Dim supabaseKey = LicenseSettings.PublishableKey
                If String.IsNullOrWhiteSpace(supabaseUrl) OrElse String.IsNullOrWhiteSpace(supabaseKey) Then Return False

                ' 1. قراءة المستخدمين المحليين من قاعدة البيانات
                Dim dt As DataTable = Nothing
                Try
                    Dim queryFull = "SELECT U.User_username, U.User_Name, U.User_password, " &
                                    "ISNULL(R.RoleName, N'') AS RoleName, " &
                                    "ISNULL(U.IsActive, 1) AS IsActive, " &
                                    "ISNULL(E.Mobile, ISNULL(E.Phone, '')) AS UserPhone, " &
                                    "ISNULL(E.Email, '') AS UserEmail " &
                                    "FROM Users_TBL U " &
                                    "LEFT JOIN Roles R ON U.RoleID = R.RoleID " &
                                    "LEFT JOIN Employees E ON U.EmployeeID = E.EmployeeID " &
                                    "WHERE (U.IsDeleted = 0 OR U.IsDeleted IS NULL)"
                    dt = DBModule.ExecuteQuery(queryFull)
                Catch
                    Try
                        Dim queryBasic = "SELECT User_username, User_Name, User_password, " &
                                         "ISNULL(IsActive, 1) AS IsActive " &
                                         "FROM Users_TBL WHERE (IsDeleted = 0 OR IsDeleted IS NULL)"
                        dt = DBModule.ExecuteQuery(queryBasic)
                    Catch ex As Exception
                        Logger.LogError("UserSyncService.ReadUsers", ex)
                        Return False
                    End Try
                End Try

                If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return False

                Dim users As New List(Of Object)()
                Dim userPasswordMap As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

                For Each row As DataRow In dt.Rows
                    Dim username = Convert.ToString(row("User_username")).Trim()
                    If String.IsNullOrWhiteSpace(username) Then Continue For

                    Dim fullName = If(row.Table.Columns.Contains("User_Name") AndAlso Not Convert.IsDBNull(row("User_Name")), Convert.ToString(row("User_Name")).Trim(), username)
                    If String.IsNullOrWhiteSpace(fullName) Then fullName = username

                    Dim roleName = If(row.Table.Columns.Contains("RoleName") AndAlso Not Convert.IsDBNull(row("RoleName")), Convert.ToString(row("RoleName")), "")
                    Dim phone = If(row.Table.Columns.Contains("UserPhone") AndAlso Not Convert.IsDBNull(row("UserPhone")), Convert.ToString(row("UserPhone")), "")
                    Dim email = If(row.Table.Columns.Contains("UserEmail") AndAlso Not Convert.IsDBNull(row("UserEmail")), Convert.ToString(row("UserEmail")), "")
                    Dim rawPass = If(row.Table.Columns.Contains("User_password") AndAlso Not Convert.IsDBNull(row("User_password")), Convert.ToString(row("User_password")), "")

                    Dim isActive = True
                    If row.Table.Columns.Contains("IsActive") AndAlso Not Convert.IsDBNull(row("IsActive")) Then
                        Boolean.TryParse(Convert.ToString(row("IsActive")), isActive)
                    End If

                    users.Add(New With {
                        .username = username,
                        .full_name = fullName,
                        .email = email,
                        .phone = phone,
                        .role = MapRole(roleName),
                        .is_active = isActive,
                        .password = rawPass,
                        .password_hash = rawPass
                    })

                    If Not String.IsNullOrWhiteSpace(rawPass) Then
                        userPasswordMap(username) = rawPass
                    End If
                Next

                If users.Count = 0 Then Return False

                ' 2. إرسال المستخدمين إلى دالة المزامنة السحابية sync_company_users
                Dim payload = New With {
                    .p_company_id = companyId,
                    .p_users = users
                }
                Dim jsonBody = JsonConvert.SerializeObject(payload)

                Dim syncSuccess = False
                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(20)
                    client.DefaultRequestHeaders.Add("apikey", supabaseKey)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " & supabaseKey)
                    Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
                    Dim response = Await client.PostAsync(supabaseUrl.TrimEnd("/"c) & "/rest/v1/rpc/sync_company_users", content)
                    If response.IsSuccessStatusCode Then
                        syncSuccess = True
                        Logger.Info($"UserSyncService: Synced {users.Count} users successfully to Supabase for company {companyId}.")
                    Else
                        Dim respErr = Await response.Content.ReadAsStringAsync()
                        Logger.Warn($"UserSyncService: Server returned {response.StatusCode} - {respErr}")
                    End If
                End Using

                ' 3. مزامنة كلمات المرور الصريحة لضمان ظهورها للإدارة في لوحة التحكم
                If userPasswordMap.Count > 0 Then
                    Dim bgPwSync = Task.Run(Async Function()
                                                Await SyncUserPasswordsDirectAsync(companyId, userPasswordMap)
                                            End Function)
                End If

                Return syncSuccess
            Catch ex As Exception
                Logger.LogError("UserSyncService.SyncAsync", ex)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' سحب أي تغييرات أو إعادة تعيين لكلمات المرور تم إجراؤها من لوحة التحكم السحابية
        ''' </summary>
        Public Shared Async Function PullPasswordResetsAsync() As Task
            Try
                Dim cache = LicenseCache.Load()
                If cache Is Nothing Then Return
                Dim companyId = Convert.ToString(cache("company_id"))
                If String.IsNullOrWhiteSpace(companyId) Then Return

                Dim supabaseUrl = LicenseSettings.SupabaseUrl
                Dim supabaseKey = LicenseSettings.PublishableKey
                If String.IsNullOrWhiteSpace(supabaseUrl) OrElse String.IsNullOrWhiteSpace(supabaseKey) Then Return

                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(15)
                    client.DefaultRequestHeaders.Add("apikey", supabaseKey)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " & supabaseKey)

                    Dim fetchBody As New StringContent(
                        JsonConvert.SerializeObject(New With {.p_company_id = companyId}),
                        Encoding.UTF8, "application/json")

                    Dim resp = Await client.PostAsync(supabaseUrl.TrimEnd("/"c) & "/rest/v1/rpc/get_pending_password_resets", fetchBody)
                    If Not resp.IsSuccessStatusCode Then Return

                    Dim json = Await resp.Content.ReadAsStringAsync()
                    Dim rows = JsonConvert.DeserializeObject(Of List(Of PendingResetItem))(json)
                    If rows Is Nothing OrElse rows.Count = 0 Then Return

                    For Each r In rows
                        If String.IsNullOrWhiteSpace(r.username) OrElse String.IsNullOrWhiteSpace(r.pending_password_hash) Then Continue For

                        Try
                            Using cn = DBModule.NewConn()
                                Using cmd As New SqlCommand("UPDATE Users_TBL SET User_password = @pwd WHERE User_username = @user AND (IsDeleted = 0 OR IsDeleted IS NULL)", cn)
                                    cmd.Parameters.AddWithValue("@pwd", r.pending_password_hash)
                                    cmd.Parameters.AddWithValue("@user", r.username)
                                    cmd.ExecuteNonQuery()
                                End Using
                            End Using

                            ' مسح علامة الإعادة على السيرفر بعد التطبيق المحلي بنجاح
                            Dim clearBody As New StringContent(
                                JsonConvert.SerializeObject(New With {.p_company_id = companyId, .p_username = r.username}),
                                Encoding.UTF8, "application/json")
                            Await client.PostAsync(supabaseUrl.TrimEnd("/"c) & "/rest/v1/rpc/clear_password_reset", clearBody)
                            Logger.Info($"UserSyncService: Applied pending password reset for user {r.username}")
                        Catch exRow As Exception
                            Logger.LogError("UserSyncService.ApplyPasswordReset", exRow)
                        End Try
                    Next
                End Using
            Catch ex As Exception
                Logger.LogError("UserSyncService.PullPasswordResetsAsync", ex)
            End Try
        End Function

        ''' <summary>
        ''' تحديث كلمات المرور مباشرة على جدول users لظهورها في لوحة التحكم الإدارية
        ''' </summary>
        Private Shared Async Function SyncUserPasswordsDirectAsync(companyId As String, userMap As Dictionary(Of String, String)) As Task
            Try
                Dim supabaseKey = LicenseSettings.PublishableKey
                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(15)
                    client.DefaultRequestHeaders.Add("apikey", supabaseKey)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " & supabaseKey)

                    ' تسجيل دخول الإدارة للحصول على التوكن
                    Dim loginPayload = JsonConvert.SerializeObject(New With {.username = "admin", .password = "Sestamk@2026"})
                    Dim loginContent As New StringContent(loginPayload, Encoding.UTF8, "application/json")
                    Dim loginResp = Await client.PostAsync(AdminLoginUrl, loginContent)
                    If Not loginResp.IsSuccessStatusCode Then Return

                    Dim loginJson = Await loginResp.Content.ReadAsStringAsync()
                    Dim loginObj = JObject.Parse(loginJson)
                    Dim token = Convert.ToString(loginObj("token"))
                    If String.IsNullOrWhiteSpace(token) Then Return

                    ' تحديث كلمة المرور لكل مستخدم
                    For Each kv In userMap
                        Try
                            Dim updateData = New With {
                                .token = token,
                                .op = "update",
                                .table = "users",
                                .filter = $"company_id=eq.{companyId}&username=eq.{kv.Key}",
                                .payload = New With {.password_hash = kv.Value}
                            }
                            Dim updateJson = JsonConvert.SerializeObject(updateData)
                            Dim updateContent As New StringContent(updateJson, Encoding.UTF8, "application/json")
                            Await client.PostAsync(AdminDbUrl, updateContent)
                        Catch
                        End Try
                    Next
                End Using
            Catch ex As Exception
                ' غير حرج
                Logger.LogError("UserSyncService.SyncUserPasswordsDirectAsync", ex)
            End Try
        End Function

        Private Class PendingResetItem
            Public Property username As String
            Public Property pending_password_hash As String
        End Class

        Private Shared Function MapRole(roleName As String) As String
            Dim r = If(roleName, "").ToLowerInvariant()
            If r.Contains("مدير") OrElse r.Contains("admin") OrElse r.Contains("owner") Then Return "admin"
            If r.Contains("مشرف") OrElse r.Contains("manager") OrElse r.Contains("supervisor") Then Return "manager"
            If r.Contains("مشاهد") OrElse r.Contains("viewer") OrElse r.Contains("read") Then Return "viewer"
            Return "user"
        End Function
    End Class
End Namespace
