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

        Public Class LocalUserInfo
            Public Property UserId As Integer
            Public Property UserCode As String = ""
            Public Property Username As String = ""
            Public Property FullName As String = ""
            Public Property Password As String = ""
            Public Property Role As String = "user"
            Public Property RoleName As String = ""
            Public Property Phone As String = ""
            Public Property Email As String = ""
            Public Property Barcode As String = ""
            Public Property Notes As String = ""
            Public Property IsActive As Boolean = True
        End Class

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

                ' 1. قراءة المستخدمين المحليين من قاعدة البيانات باستعلام شامل وآمن
                Dim dt As DataTable = Nothing
                Try
                    Dim queryFull As String =
                        "SELECT U.User_ID, " &
                        "       ISNULL(U.User_Code, '') AS User_Code, " &
                        "       ISNULL(U.User_Name, U.User_username) AS FullName, " &
                        "       U.User_username, " &
                        "       ISNULL(U.User_password, '') AS User_password, " &
                        "       ISNULL(U.UserBarcode, '') AS UserBarcode, " &
                        "       ISNULL(U.User_Note, '') AS User_Note, " &
                        "       U.RoleID, " &
                        "       ISNULL(R.RoleName, ISNULL(U.User_Role, N'مستخدم')) AS RoleName, " &
                        "       ISNULL(U.IsActive, 1) AS IsActive, " &
                        "       ISNULL(E.Phone, ISNULL(E.Phone2, '')) AS Phone, " &
                        "       ISNULL(E.Email, '') AS Email " &
                        "FROM Users_TBL U " &
                        "LEFT JOIN Roles R ON U.RoleID = R.RoleID " &
                        "LEFT JOIN Employees E ON U.EmployeeID = E.EmployeeID " &
                        "WHERE (U.IsDeleted = 0 OR U.IsDeleted IS NULL)"
                    dt = DBModule.ExecuteQuery(queryFull)
                Catch exFull As Exception
                    Logger.Warn("UserSyncService: queryFull failed, trying fallback: " & exFull.Message)
                    Try
                        Dim queryFallback As String =
                            "SELECT U.User_ID, " &
                            "       ISNULL(U.User_Code, '') AS User_Code, " &
                            "       ISNULL(U.User_Name, U.User_username) AS FullName, " &
                            "       U.User_username, " &
                            "       ISNULL(U.User_password, '') AS User_password, " &
                            "       ISNULL(U.UserBarcode, '') AS UserBarcode, " &
                            "       ISNULL(U.User_Note, '') AS User_Note, " &
                            "       ISNULL(U.User_Role, N'مستخدم') AS RoleName, " &
                            "       ISNULL(U.IsActive, 1) AS IsActive, " &
                            "       '' AS Phone, " &
                            "       '' AS Email " &
                            "FROM Users_TBL U " &
                            "WHERE (U.IsDeleted = 0 OR U.IsDeleted IS NULL)"
                        dt = DBModule.ExecuteQuery(queryFallback)
                    Catch ex As Exception
                        Logger.LogError("UserSyncService.ReadUsers", ex)
                        Return False
                    End Try
                End Try

                If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return False

                Dim userList As New List(Of LocalUserInfo)()
                Dim rpcUsersPayload As New List(Of Object)()

                For Each row As DataRow In dt.Rows
                    Dim username = Convert.ToString(row("User_username")).Trim()
                    If String.IsNullOrWhiteSpace(username) Then Continue For

                    Dim u As New LocalUserInfo()
                    u.Username = username

                    If row.Table.Columns.Contains("FullName") AndAlso Not Convert.IsDBNull(row("FullName")) Then
                        u.FullName = Convert.ToString(row("FullName")).Trim()
                    ElseIf row.Table.Columns.Contains("User_Name") AndAlso Not Convert.IsDBNull(row("User_Name")) Then
                        u.FullName = Convert.ToString(row("User_Name")).Trim()
                    End If
                    If String.IsNullOrWhiteSpace(u.FullName) Then u.FullName = username

                    If row.Table.Columns.Contains("User_password") AndAlso Not Convert.IsDBNull(row("User_password")) Then
                        u.Password = Convert.ToString(row("User_password")).Trim()
                    End If

                    Dim rawRole = ""
                    If row.Table.Columns.Contains("RoleName") AndAlso Not Convert.IsDBNull(row("RoleName")) Then
                        rawRole = Convert.ToString(row("RoleName"))
                    ElseIf row.Table.Columns.Contains("User_Role") AndAlso Not Convert.IsDBNull(row("User_Role")) Then
                        rawRole = Convert.ToString(row("User_Role"))
                    End If
                    u.RoleName = rawRole
                    u.Role = MapRole(rawRole)

                    If row.Table.Columns.Contains("Phone") AndAlso Not Convert.IsDBNull(row("Phone")) Then
                        u.Phone = Convert.ToString(row("Phone")).Trim()
                    End If

                    If row.Table.Columns.Contains("Email") AndAlso Not Convert.IsDBNull(row("Email")) Then
                        u.Email = Convert.ToString(row("Email")).Trim()
                    End If

                    If row.Table.Columns.Contains("User_Code") AndAlso Not Convert.IsDBNull(row("User_Code")) Then
                        u.UserCode = Convert.ToString(row("User_Code")).Trim()
                    End If

                    If row.Table.Columns.Contains("UserBarcode") AndAlso Not Convert.IsDBNull(row("UserBarcode")) Then
                        u.Barcode = Convert.ToString(row("UserBarcode")).Trim()
                    End If

                    If row.Table.Columns.Contains("User_Note") AndAlso Not Convert.IsDBNull(row("User_Note")) Then
                        u.Notes = Convert.ToString(row("User_Note")).Trim()
                    End If

                    u.IsActive = True
                    If row.Table.Columns.Contains("IsActive") AndAlso Not Convert.IsDBNull(row("IsActive")) Then
                        Boolean.TryParse(Convert.ToString(row("IsActive")), u.IsActive)
                    End If

                    userList.Add(u)

                    ' تجهيز بيانات دالة المزامنة السحابية sync_company_users
                    rpcUsersPayload.Add(New With {
                        .username = u.Username,
                        .full_name = u.FullName,
                        .email = u.Email,
                        .phone = u.Phone,
                        .role = u.Role,
                        .is_active = u.IsActive,
                        .password = u.Password,
                        .password_hash = u.Password
                    })
                Next

                If userList.Count = 0 Then Return False

                ' 2. إرسال المستخدمين إلى دالة المزامنة السحابية sync_company_users
                Dim payload = New With {
                    .p_company_id = companyId,
                    .p_users = rpcUsersPayload
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
                        Logger.Info($"UserSyncService: Synced {userList.Count} users successfully to Supabase for company {companyId}.")
                    Else
                        Dim respErr = Await response.Content.ReadAsStringAsync()
                        Logger.Warn($"UserSyncService: Server returned {response.StatusCode} - {respErr}")
                    End If
                End Using

                ' 3. مزامنة كلمات المرور والتفاصيل الصريحة لضمان ظهورها للإدارة في لوحة التحكم
                Dim bgPwSync = Task.Run(Async Function()
                                            Await SyncUserDetailsDirectAsync(companyId, userList)
                                        End Function)

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
        ''' تحديث كلمات المرور والبيانات كاملة مباشرة على جدول users لظهورها في لوحة التحكم الإدارية
        ''' </summary>
        Private Shared Async Function SyncUserDetailsDirectAsync(companyId As String, users As List(Of LocalUserInfo)) As Task
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

                    ' تحديث كل مستخدم بالحقول المتوفرة في جدول users
                    For Each u In users
                        Try
                            Dim changes As New Dictionary(Of String, Object) From {
                                {"password_hash", u.Password},
                                {"full_name", u.FullName},
                                {"role", u.Role},
                                {"is_active", u.IsActive}
                            }
                            If Not String.IsNullOrWhiteSpace(u.Phone) Then changes("phone") = u.Phone
                            If Not String.IsNullOrWhiteSpace(u.Email) Then changes("email") = u.Email

                            Dim updateData = New With {
                                .token = token,
                                .op = "update",
                                .table = "users",
                                .filter = $"company_id=eq.{companyId}&username=eq.{u.Username}",
                                .payload = changes
                            }
                            Dim updateJson = JsonConvert.SerializeObject(updateData)
                            Dim updateContent As New StringContent(updateJson, Encoding.UTF8, "application/json")
                            Await client.PostAsync(AdminDbUrl, updateContent)
                        Catch
                        End Try
                    Next
                End Using
            Catch ex As Exception
                Logger.LogError("UserSyncService.SyncUserDetailsDirectAsync", ex)
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
