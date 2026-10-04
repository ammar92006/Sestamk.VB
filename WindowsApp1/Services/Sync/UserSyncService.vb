Imports System.Collections.Concurrent
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Services.Sync
    ''' <summary>
    ''' خدمة مزامنة المستخدمين التلقائية وثنائية الاتجاه مع سيرفر Supabase والربط بالمنشأة (Multi-Tenant)
    ''' تعمل في الخلفية بدون التأثير نهائياً على أداء البرنامج أو واجهة المستخدم
    ''' تقوم بسحب أي تعديلات تم إجراؤها من لوحة تحكم Supabase (كلمات المرور، الأسماء، التفعيل، الصلاحيات) إلى البرنامج المحلي
    ''' كما تقوم برفع كافة المستخدمين المحليين لضمان التطابق الكامل، وتتحقق من توفر الإنترنت قبل أي محاولة
    ''' </summary>
    Public NotInheritable Class UserSyncService
        Private Sub New()
        End Sub

        Private Const AdminLoginUrl As String = "https://axigicbiydhfbkfqogma.supabase.co/functions/v1/admin-login"
        Private Const AdminDbUrl As String = "https://axigicbiydhfbkfqogma.supabase.co/functions/v1/admin-db"

        ' مؤقت المزامنة المستمرة في الخلفية
        Private Shared _backgroundTimer As System.Threading.Timer = Nothing
        Private Shared _isSyncing As Integer = 0
        Private Shared _cachedAdminToken As String = ""
        Private Shared _tokenExpiresAt As DateTime = DateTime.MinValue
        Private Shared _lastAdminConfigWarnAt As DateTime = DateTime.MinValue

        ' ذاكرة لتتبع آخر حالة متزامنة لمنع تكرار الكتابة واكتشاف جهة التعديل
        Private Shared ReadOnly _lastSyncedStates As New ConcurrentDictionary(Of String, SyncedUserState)(StringComparer.OrdinalIgnoreCase)

        ''' <summary>
        ''' حدث يتم إطلاقه عند تحديث أو إضافة أي مستخدم محلياً من السحابة
        ''' </summary>
        Public Shared Event UsersUpdated()

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
            Public Property EmployeeId As Integer = 0
            Public Property PhotoBase64 As String = ""
            Public Property IsActive As Boolean = True
            Public Property IsDeleted As Boolean = False
        End Class

        Private Class CloudUserInfo
            Public Property id As String
            Public Property company_id As String
            Public Property username As String
            Public Property password_hash As String
            Public Property full_name As String
            Public Property email As String
            Public Property phone As String
            Public Property role As String
            Public Property avatar_url As String
            Public Property is_active As Boolean?
            Public Property updated_at As String
        End Class

        Private Class SyncedUserState
            Public Property Username As String = ""
            Public Property Password As String = ""
            Public Property FullName As String = ""
            Public Property Role As String = ""
            Public Property PhotoBase64 As String = ""
            Public Property IsActive As Boolean = True
        End Class

        ''' <summary>
        ''' التحقق الفوري والسريع من توفر اتصال بالإنترنت دون أي حجز للموارد
        ''' </summary>
        Public Shared Function IsInternetAvailable() As Boolean
            Try
                If Not NetworkInterface.GetIsNetworkAvailable() Then
                    Return False
                End If
                Return True
            Catch
                Return False
            End Try
        End Function

        ''' <summary>
        ''' بدء تشغيل مؤقت المزامنة في الخلفية بفترة زمنية محددة (افتراضياً كل 25 ثانية)
        ''' بدء تشغيل مؤقت المزامنة في الخلفية بفترة زمنية محددة (افتراضياً كل 25 ثانية)
        ''' يتم تشغيله على خيوط ThreadPool الخلفية دون أي تأثير على أداء الواجهة
        ''' </summary>
        Public Shared Sub StartBackgroundSync(Optional intervalSeconds As Integer = 25)
            Try
                If _backgroundTimer IsNot Nothing Then Return

                Dim intervalMs = Math.Max(10, intervalSeconds) * 1000
                _backgroundTimer = New System.Threading.Timer(AddressOf OnTimerTick, Nothing, 3000, intervalMs)
                Logger.Info($"UserSyncService: Background sync timer started with {intervalSeconds}s interval.")
            Catch ex As Exception
                Logger.LogError("UserSyncService.StartBackgroundSync", ex)
            End Try
        End Sub

        Private Shared Sub OnTimerTick(state As Object)
            Dim t = Task.Run(Async Function()
                                 Try
                                     Await SyncCycleAsync().ConfigureAwait(False)
                                 Catch ex As Exception
                                     Logger.LogDebug($"UserSyncService.TimerCallback: {ex.Message}")
                                 End Try
                             End Function)
        End Sub

        ''' <summary>
        ''' إيقاف مؤقت المزامنة في الخلفية
        ''' </summary>
        Public Shared Sub StopBackgroundSync()
            Try
                If _backgroundTimer IsNot Nothing Then
                    _backgroundTimer.Dispose()
                    _backgroundTimer = Nothing
                    Logger.Info("UserSyncService: Background sync timer stopped.")
                End If
            Catch __logEx As Exception
                Logger.LogError("UserSyncService.vb:133", __logEx)
            End Try
        End Sub

        ''' <summary>
        ''' دورة المزامنة الكاملة (ثنائية الاتجاه) في الخلفية:
        ''' 1. التحقق من الإنترنت
        ''' 2. سحب التعديلات من Supabase أولاً لتطبيق أي تغييرات تمت من السحابة
        ''' 3. رفع أي مستخدمين أو تعديلات محلية جديدة إلى Supabase
        ''' 4. معالجة طلبات إعادة تعيين كلمات المرور
        ''' </summary>
        Public Shared Async Function SyncCycleAsync() As Task(Of Boolean)
            ' 1. لا تفعل شيئاً إذا لم يكن هناك إنترنت
            If Not IsInternetAvailable() Then
                Return False
            End If

            ' 2. منع التداخل: إذا كانت هناك دورة مزامنة جارية حالياً، اخرج فوراً
            If Interlocked.CompareExchange(_isSyncing, 1, 0) <> 0 Then
                Return False
            End If

            Try
                Dim cache = LicenseCache.Load()
                If cache Is Nothing Then Return False
                Dim companyId = Convert.ToString(cache("company_id"))
                If String.IsNullOrWhiteSpace(companyId) Then Return False

                Dim supabaseUrl = LicenseSettings.SupabaseUrl
                Dim supabaseKey = LicenseSettings.PublishableKey
                If String.IsNullOrWhiteSpace(supabaseUrl) OrElse String.IsNullOrWhiteSpace(supabaseKey) Then Return False

                ' 3. سحب التعديلات من Supabase أولاً (Pull) وتحديث البيانات المحلية
                Dim pullSuccess = Await PullUsersFromSupabaseAsync(companyId).ConfigureAwait(False)

                ' 4. رفع المستخدمين المحليين (Push) لكافة المستخدمين دون استثناء
                Dim pushSuccess = Await PushLocalUsersAsync(companyId).ConfigureAwait(False)

                ' 5. معالجة طلبات إعادة تعيين كلمات المرور المعلقة
                Await PullPasswordResetsAsync().ConfigureAwait(False)

                Return pullSuccess OrElse pushSuccess
            Catch ex As Exception
                Logger.LogDebug($"UserSyncService.SyncCycleAsync: {ex.Message}")
                Return False
            Finally
                Interlocked.Exchange(_isSyncing, 0)
            End Try
        End Function

        ''' <summary>
        ''' استدعاء يدوي أو عند الطلب لدورة المزامنة
        ''' </summary>
        Public Shared Async Function SyncAsync() As Task(Of Boolean)
            Return Await SyncCycleAsync().ConfigureAwait(False)
        End Function

        ''' <summary>
        ''' سحب المستخدمين من Supabase ومطابقتهم مع قاعدة البيانات المحلية:
        ''' - إذا تم تعديل كلمة المرور أو الاسم أو الصلاحية أو التفعيل على Supabase يتم تحديثها محلياً فوراً
        ''' - إذا تمت إضافة مستخدم جديد على Supabase يتم إدراجه في قاعدة البيانات المحلية
        ''' </summary>
        Public Shared Async Function PullUsersFromSupabaseAsync(companyId As String) As Task(Of Boolean)
            Try
                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(8)
                    client.DefaultRequestHeaders.Add("apikey", LicenseSettings.PublishableKey)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " & LicenseSettings.PublishableKey)

                    Dim cloudUsers = Await FetchCloudUsersAsync(client, companyId).ConfigureAwait(False)
                    If cloudUsers Is Nothing OrElse cloudUsers.Count = 0 Then Return False

                    ' جلب كافة المستخدمين المحليين
                    Dim localUsers = ReadAllLocalUsers()
                    Dim localDict As New Dictionary(Of String, LocalUserInfo)(StringComparer.OrdinalIgnoreCase)
                    For Each lu In localUsers
                        If Not String.IsNullOrWhiteSpace(lu.Username) Then
                            localDict(lu.Username.Trim()) = lu
                        End If
                    Next

                    Dim localModified = False

                    For Each cu In cloudUsers
                        If cu Is Nothing OrElse String.IsNullOrWhiteSpace(cu.username) Then Continue For
                        Dim uname = cu.username.Trim()
                        Dim cloudPass = If(cu.password_hash, "").Trim()
                        Dim cloudName = If(cu.full_name, "").Trim()
                        Dim cloudRole = If(cu.role, "user").Trim()
                        Dim cloudActive = If(cu.is_active.HasValue, cu.is_active.Value, True)
                        Dim cloudAvatar = If(cu.avatar_url, "").Trim()

                        Dim lastSynced As SyncedUserState = Nothing
                        Dim hasLastSynced = _lastSyncedStates.TryGetValue(uname, lastSynced)

                        If localDict.ContainsKey(uname) Then
                            Dim lu = localDict(uname)
                            Dim cloudChanged = False
                            Dim localChanged = False

                            If hasLastSynced Then
                                If Not String.IsNullOrEmpty(cloudPass) AndAlso cloudPass <> lastSynced.Password Then cloudChanged = True
                                If cloudName <> lastSynced.FullName Then cloudChanged = True
                                If cloudActive <> lastSynced.IsActive Then cloudChanged = True
                                If cloudRole <> lastSynced.Role Then cloudChanged = True
                                If cloudAvatar <> lastSynced.PhotoBase64 Then cloudChanged = True

                                If lu.Password <> lastSynced.Password Then localChanged = True
                                If lu.FullName <> lastSynced.FullName Then localChanged = True
                                If lu.IsActive <> lastSynced.IsActive Then localChanged = True
                                If lu.Role <> lastSynced.Role Then localChanged = True
                                If lu.PhotoBase64 <> lastSynced.PhotoBase64 Then localChanged = True
                            Else
                                ' عند أول تشغيل، إذا وُجد فرق بين السحابة والمحلي، نعتمد السحابة
                                If Not String.IsNullOrEmpty(cloudPass) AndAlso cloudPass <> lu.Password Then cloudChanged = True
                                If Not String.IsNullOrEmpty(cloudName) AndAlso cloudName <> lu.FullName Then cloudChanged = True
                                If cloudActive <> lu.IsActive Then cloudChanged = True
                                If Not String.IsNullOrEmpty(cloudAvatar) AndAlso cloudAvatar <> lu.PhotoBase64 Then cloudChanged = True
                            End If

                            ' إذا حدث التغيير على Supabase (أو عند التعارض) يتم تحديث السجل المحلي
                            If cloudChanged AndAlso (Not localChanged OrElse Not hasLastSynced) Then
                                UpdateLocalUser(lu.UserId, lu.EmployeeId, uname, cloudPass, cloudName, cloudRole, cloudActive, cu.phone, cu.email, cloudAvatar)
                                localModified = True
                                _lastSyncedStates(uname) = New SyncedUserState With {
                                    .Username = uname,
                                    .Password = If(String.IsNullOrEmpty(cloudPass), lu.Password, cloudPass),
                                    .FullName = If(String.IsNullOrEmpty(cloudName), lu.FullName, cloudName),
                                    .Role = cloudRole,
                                    .PhotoBase64 = If(String.IsNullOrEmpty(cloudAvatar), lu.PhotoBase64, cloudAvatar),
                                    .IsActive = cloudActive
                                }
                            Else
                                ' في حال التطابق
                                _lastSyncedStates(uname) = New SyncedUserState With {
                                    .Username = uname,
                                    .Password = lu.Password,
                                    .FullName = lu.FullName,
                                    .Role = lu.Role,
                                    .PhotoBase64 = lu.PhotoBase64,
                                    .IsActive = lu.IsActive
                                }
                            End If
                        Else
                            ' مستخدم جديد مضاف من Supabase ولم ينزل في المحلي بعد
                            InsertLocalUser(uname, cloudPass, cloudName, cloudRole, cloudActive, cu.phone, cu.email, cloudAvatar)
                            localModified = True
                            _lastSyncedStates(uname) = New SyncedUserState With {
                                .Username = uname,
                                .Password = cloudPass,
                                .FullName = cloudName,
                                .Role = cloudRole,
                                .PhotoBase64 = cloudAvatar,
                                .IsActive = cloudActive
                            }
                        End If
                    Next

                    If localModified Then
                        NotifyFormsUserListChanged()
                    End If

                    Return True
                End Using
            Catch ex As Exception
                Logger.LogDebug($"UserSyncService.PullUsersFromSupabaseAsync: {ex.Message}")
                Return False
            End Try
        End Function

        ''' <summary>
        ''' رفع كافة المستخدمين المحليين إلى Supabase دون أي شروط استبعاد (يشمل الجميع)
        ''' </summary>
        Public Shared Async Function PushLocalUsersAsync(companyId As String) As Task(Of Boolean)
            Try
                Dim localUsers = ReadAllLocalUsers()
                If localUsers.Count = 0 Then Return False

                Dim supabaseUrl = LicenseSettings.SupabaseUrl
                Dim supabaseKey = LicenseSettings.PublishableKey

                Dim rpcUsersPayload As New List(Of Object)()
                For Each u In localUsers
                    Dim effectiveActive = (u.IsActive AndAlso Not u.IsDeleted)
                    rpcUsersPayload.Add(New With {
                        .username = u.Username,
                        .full_name = u.FullName,
                        .email = u.Email,
                        .phone = u.Phone,
                        .role = u.Role,
                        .is_active = effectiveActive,
                        .password = u.Password,
                        .password_hash = u.Password,
                        .avatar_url = If(String.IsNullOrWhiteSpace(u.PhotoBase64), Nothing, u.PhotoBase64)
                    })
                Next

                Dim payload = New With {
                    .p_company_id = companyId,
                    .p_users = rpcUsersPayload
                }
                Dim jsonBody = JsonConvert.SerializeObject(payload)

                Dim syncSuccess = False
                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(8)
                    client.DefaultRequestHeaders.Add("apikey", supabaseKey)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " & supabaseKey)
                    Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
                    Dim response = Await client.PostAsync(supabaseUrl.TrimEnd("/"c) & "/rest/v1/rpc/sync_company_users", content).ConfigureAwait(False)
                    If response.IsSuccessStatusCode Then
                        syncSuccess = True
                    End If
                End Using

                ' تحديث كلمات المرور والتفاصيل المباشرة لجدول users لضمان ظهورها للإدارة
                Await SyncUserDetailsDirectAsync(companyId, localUsers).ConfigureAwait(False)

                For Each u In localUsers
                    _lastSyncedStates(u.Username) = New SyncedUserState With {
                        .Username = u.Username,
                        .Password = u.Password,
                        .FullName = u.FullName,
                        .Role = u.Role,
                        .PhotoBase64 = u.PhotoBase64,
                        .IsActive = (u.IsActive AndAlso Not u.IsDeleted)
                    }
                Next

                Return syncSuccess
            Catch ex As Exception
                Logger.LogDebug($"UserSyncService.PushLocalUsersAsync: {ex.Message}")
                Return False
            End Try
        End Function

        ''' <summary>
        ''' قراءة جميع المستخدمين من قاعدة البيانات المحلية دون أي شرط حذف (شامل الكل)
        ''' </summary>
        Public Shared Function ReadAllLocalUsers() As List(Of LocalUserInfo)
            Dim userList As New List(Of LocalUserInfo)()
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
                    "       ISNULL(U.UserPhotobase64, '') AS PhotoBase64, " &
                    "       U.RoleID, " &
                    "       ISNULL(U.EmployeeID, 0) AS EmployeeID, " &
                    "       ISNULL(R.RoleName, ISNULL(U.User_Role, N'مستخدم')) AS RoleName, " &
                    "       ISNULL(U.IsActive, 1) AS IsActive, " &
                    "       ISNULL(U.IsDeleted, 0) AS IsDeleted, " &
                    "       ISNULL(E.Phone, ISNULL(E.Phone2, '')) AS Phone, " &
                    "       ISNULL(E.Email, '') AS Email " &
                    "FROM Users_TBL U " &
                    "LEFT JOIN Roles R ON U.RoleID = R.RoleID " &
                    "LEFT JOIN Employees E ON U.EmployeeID = E.EmployeeID " &
                    "ORDER BY U.User_ID"
                dt = DBModule.ExecuteQuery(queryFull)
            Catch exFull As Exception
                Try
                    Dim queryFallback As String =
                        "SELECT U.User_ID, " &
                        "       ISNULL(U.User_Code, '') AS User_Code, " &
                        "       ISNULL(U.User_Name, U.User_username) AS FullName, " &
                        "       U.User_username, " &
                        "       ISNULL(U.User_password, '') AS User_password, " &
                        "       ISNULL(U.UserBarcode, '') AS UserBarcode, " &
                        "       ISNULL(U.User_Note, '') AS User_Note, " &
                        "       ISNULL(U.UserPhotobase64, '') AS PhotoBase64, " &
                        "       ISNULL(U.User_Role, N'مستخدم') AS RoleName, " &
                        "       ISNULL(U.IsActive, 1) AS IsActive, " &
                        "       ISNULL(U.IsDeleted, 0) AS IsDeleted, " &
                        "       0 AS EmployeeID, " &
                        "       '' AS Phone, " &
                        "       '' AS Email " &
                        "FROM Users_TBL U " &
                        "ORDER BY U.User_ID"
                    dt = DBModule.ExecuteQuery(queryFallback)
                Catch ex As Exception
                    Logger.LogError("UserSyncService.ReadAllLocalUsers", ex)
                    Return userList
                End Try
            End Try

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return userList

            For Each row As DataRow In dt.Rows
                Dim username = Convert.ToString(row("User_username")).Trim()
                If String.IsNullOrWhiteSpace(username) Then Continue For

                Dim u As New LocalUserInfo()
                u.Username = username
                u.UserId = Convert.ToInt32(row("User_ID"))

                If row.Table.Columns.Contains("FullName") AndAlso Not Convert.IsDBNull(row("FullName")) Then
                    u.FullName = Convert.ToString(row("FullName")).Trim()
                ElseIf row.Table.Columns.Contains("User_Name") AndAlso Not Convert.IsDBNull(row("User_Name")) Then
                    u.FullName = Convert.ToString(row("User_Name")).Trim()
                End If
                If String.IsNullOrWhiteSpace(u.FullName) Then u.FullName = username

                If row.Table.Columns.Contains("User_password") AndAlso Not Convert.IsDBNull(row("User_password")) Then
                    u.Password = Convert.ToString(row("User_password")).Trim()
                End If

                ' أمان: لا تُغادر أي كلمة مرور نصاً صريحاً هذا الجهاز أبداً.
                ' الترحيل هنا لمرة واحدة لكل مستخدم: تُجزَّأ (PBKDF2) وتُكتب محلياً،
                ' فترسل للسحابة تجزئة والأجهزة الأخرى تتحقق بها دون معرفة النص الأصلي.
                If Not String.IsNullOrWhiteSpace(u.Password) AndAlso Not PasswordHasher.IsHashed(u.Password) Then
                    Try
                        Dim migratedHash = PasswordHasher.Hash(u.Password)
                        Using cnMig = DBModule.NewConn()
                            Using cmdMig As New SqlCommand("UPDATE Users_TBL SET User_password = @h WHERE User_ID = @id", cnMig)
                                cmdMig.Parameters.AddWithValue("@h", migratedHash)
                                cmdMig.Parameters.AddWithValue("@id", u.UserId)
                                cnMig.Open()
                                cmdMig.ExecuteNonQuery()
                            End Using
                        End Using
                        u.Password = migratedHash
                        Logger.LogInfo($"UserSyncService: تمت ترقية كلمة مرور المستخدم [{u.Username}] إلى تجزئة PBKDF2 أثناء المزامنة")
                    Catch exMig As Exception
                        Logger.LogError("UserSyncService.MigratePlaintextPassword", exMig)
                        u.Password = String.Empty ' فشل الترحيل: لا يُرسل النص الصريح مهما كان
                    End Try
                End If

                Dim rawRole = ""
                If row.Table.Columns.Contains("RoleName") AndAlso Not Convert.IsDBNull(row("RoleName")) Then
                    rawRole = Convert.ToString(row("RoleName"))
                ElseIf row.Table.Columns.Contains("User_Role") AndAlso Not Convert.IsDBNull(row("User_Role")) Then
                    rawRole = Convert.ToString(row("User_Role"))
                End If
                u.RoleName = rawRole
                u.Role = MapRole(rawRole)

                If row.Table.Columns.Contains("PhotoBase64") AndAlso Not Convert.IsDBNull(row("PhotoBase64")) Then
                    u.PhotoBase64 = Convert.ToString(row("PhotoBase64")).Trim()
                ElseIf row.Table.Columns.Contains("UserPhotobase64") AndAlso Not Convert.IsDBNull(row("UserPhotobase64")) Then
                    u.PhotoBase64 = Convert.ToString(row("UserPhotobase64")).Trim()
                End If

                If row.Table.Columns.Contains("Phone") AndAlso Not Convert.IsDBNull(row("Phone")) Then
                    u.Phone = Convert.ToString(row("Phone")).Trim()
                End If

                If row.Table.Columns.Contains("Email") AndAlso Not Convert.IsDBNull(row("Email")) Then
                    u.Email = Convert.ToString(row("Email")).Trim()
                End If

                If row.Table.Columns.Contains("EmployeeID") AndAlso Not Convert.IsDBNull(row("EmployeeID")) Then
                    Integer.TryParse(Convert.ToString(row("EmployeeID")), u.EmployeeId)
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

                u.IsDeleted = False
                If row.Table.Columns.Contains("IsDeleted") AndAlso Not Convert.IsDBNull(row("IsDeleted")) Then
                    Boolean.TryParse(Convert.ToString(row("IsDeleted")), u.IsDeleted)
                End If

                userList.Add(u)
            Next

            Return userList
        End Function

        ''' <summary>
        ''' تحديث بيانات المستخدم محلياً بناءً على ما ورد من Supabase
        ''' </summary>
        Private Shared Sub UpdateLocalUser(userId As Integer, employeeId As Integer, username As String, newPass As String, newName As String, newRole As String, isActive As Boolean, Optional phone As String = Nothing, Optional email As String = Nothing, Optional photoBase64 As String = Nothing)
            Try
                Using cn = DBModule.NewConn()
                    Dim roleName = MapToRoleName(newRole)
                    Dim roleId = GetRoleId(roleName, cn)

                    Dim sql = "UPDATE Users_TBL SET " &
                              "User_Name = @name, " &
                              "User_Role = @roleName, " &
                              "IsActive = @isActive, " &
                              "IsDeleted = 0 "
                    Dim pwdToStore = SanitizeIncomingPassword(newPass)
                    If Not String.IsNullOrWhiteSpace(pwdToStore) Then
                        sql &= ", User_password = @pwd "
                    End If
                    If roleId > 0 Then
                        sql &= ", RoleID = @roleId "
                    End If
                    If photoBase64 IsNot Nothing Then
                        sql &= ", UserPhotobase64 = @photo "
                    End If
                    sql &= "WHERE LOWER(User_username) = LOWER(@user)"

                    Using cmd As New SqlCommand(sql, cn)
                        cmd.Parameters.AddWithValue("@name", If(String.IsNullOrWhiteSpace(newName), username, newName))
                        cmd.Parameters.AddWithValue("@roleName", roleName)
                        cmd.Parameters.AddWithValue("@isActive", isActive)
                        cmd.Parameters.AddWithValue("@user", username)
                        If Not String.IsNullOrWhiteSpace(pwdToStore) Then
                            cmd.Parameters.AddWithValue("@pwd", pwdToStore)
                        End If
                        If roleId > 0 Then
                            cmd.Parameters.AddWithValue("@roleId", roleId)
                        End If
                        If photoBase64 IsNot Nothing Then
                            cmd.Parameters.Add("@photo", SqlDbType.NVarChar, -1).Value = If(String.IsNullOrWhiteSpace(photoBase64), DBNull.Value, photoBase64)
                        End If
                        cmd.ExecuteNonQuery()
                    End Using

                    ' إذا كان هناك موظف مرتبط، تحديث الهاتف والإيميل
                    If employeeId > 0 AndAlso (Not String.IsNullOrWhiteSpace(phone) OrElse Not String.IsNullOrWhiteSpace(email)) Then
                        Try
                            Dim empSql = "UPDATE Employees SET "
                            Dim hasEmpFields = False
                            If Not String.IsNullOrWhiteSpace(phone) Then
                                empSql &= "Phone = @phone "
                                hasEmpFields = True
                            End If
                            If Not String.IsNullOrWhiteSpace(email) Then
                                If hasEmpFields Then empSql &= ", "
                                empSql &= "Email = @email "
                                hasEmpFields = True
                            End If
                            empSql &= "WHERE EmployeeID = @empId"

                            If hasEmpFields Then
                                Using empCmd As New SqlCommand(empSql, cn)
                                    If Not String.IsNullOrWhiteSpace(phone) Then empCmd.Parameters.AddWithValue("@phone", phone)
                                    If Not String.IsNullOrWhiteSpace(email) Then empCmd.Parameters.AddWithValue("@email", email)
                                    empCmd.Parameters.AddWithValue("@empId", employeeId)
                                    empCmd.ExecuteNonQuery()
                                End Using
                            End If
                        Catch __logEx As Exception
                            Logger.LogError("UserSyncService.vb:567", __logEx)
                        End Try
                    End If
                End Using
                Logger.Info($"UserSyncService: Synced user '{username}' from Supabase into local database.")
            Catch ex As Exception
                Logger.LogError($"UserSyncService.UpdateLocalUser({username})", ex)
            End Try
        End Sub

        ''' <summary>
        ''' أمان كلمات المرور: لا يجوز أن تُخزَّن أي قيمة غير مجزأة (نص صريح) في قاعدة المستخدمين المحلية.
        ''' أي قيمة قادمة من السحابة ليست بصيغة PBKDF2$ تُجزَّأ قبل الكتابة، فتبقى قابلة للتحقق
        ''' عبر PasswordHasher.Verify عند الدخول دون معرفة النص الأصلي.
        ''' </summary>
        Private Shared Function SanitizeIncomingPassword(value As String) As String
            If String.IsNullOrWhiteSpace(value) Then Return String.Empty
            If PasswordHasher.IsHashed(value) Then Return value
            Return PasswordHasher.Hash(value)
        End Function

        ''' <summary>
        ''' إضافة مستخدم جديد محلياً ورد من Supabase
        ''' </summary>
        Private Shared Sub InsertLocalUser(username As String, password As String, fullName As String, role As String, isActive As Boolean, phone As String, email As String, Optional photoBase64 As String = Nothing)
            Try
                Using cn = DBModule.NewConn()
                    Dim nextCode = GetNextUserCode(cn)
                    Dim roleName = MapToRoleName(role)
                    Dim roleId = GetRoleId(roleName, cn)

                    Dim sql = "INSERT INTO Users_TBL (User_Code, User_Name, User_username, User_password, User_Role, RoleID, IsActive, IsDeleted, UserPhotobase64, CreatedAt) " &
                              "VALUES (@code, @name, @uname, @pwd, @roleName, @roleId, @isActive, 0, @photo, GETDATE())"

                    Using cmd As New SqlCommand(sql, cn)
                        cmd.Parameters.AddWithValue("@code", nextCode)
                        cmd.Parameters.AddWithValue("@name", If(String.IsNullOrWhiteSpace(fullName), username, fullName))
                        cmd.Parameters.AddWithValue("@uname", username)
                        cmd.Parameters.AddWithValue("@pwd", SanitizeIncomingPassword(If(String.IsNullOrWhiteSpace(password), "123456", password)))
                        cmd.Parameters.AddWithValue("@roleName", roleName)
                        If roleId > 0 Then
                            cmd.Parameters.AddWithValue("@roleId", roleId)
                        Else
                            cmd.Parameters.AddWithValue("@roleId", DBNull.Value)
                        End If
                        cmd.Parameters.AddWithValue("@isActive", isActive)
                        cmd.Parameters.Add("@photo", SqlDbType.NVarChar, -1).Value = If(String.IsNullOrWhiteSpace(photoBase64), DBNull.Value, photoBase64)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                Logger.Info($"UserSyncService: Inserted new local user '{username}' from Supabase.")
            Catch ex As Exception
                Logger.LogError($"UserSyncService.InsertLocalUser({username})", ex)
            End Try
        End Sub

        Private Shared Function GetNextUserCode(cn As SqlConnection) As String
            Try
                Dim sql = "SELECT ISNULL(MAX(CASE WHEN ISNUMERIC(User_Code) = 1 THEN CAST(User_Code AS INT) ELSE 0 END), 0) + 1 FROM Users_TBL"
                Using cmd As New SqlCommand(sql, cn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        Return result.ToString()
                    End If
                End Using
            Catch __logEx As Exception
                Logger.LogError("UserSyncService.vb:622", __logEx)
            End Try
            Return "1"
        End Function

        Private Shared Function GetRoleId(roleName As String, cn As SqlConnection) As Integer
            Try
                Dim sql = "SELECT TOP 1 RoleID FROM Roles WHERE RoleName = @r OR RoleName LIKE @rLike"
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@r", roleName)
                    cmd.Parameters.AddWithValue("@rLike", "%" & roleName.Split(" "c)(0) & "%")
                    Dim res = cmd.ExecuteScalar()
                    If res IsNot Nothing AndAlso Not Convert.IsDBNull(res) Then
                        Return Convert.ToInt32(res)
                    End If
                End Using
            Catch __logEx As Exception
                Logger.LogError("UserSyncService.vb:639", __logEx)
            End Try
            Return 1
        End Function

        Private Shared Function MapToRoleName(role As String) As String
            Select Case If(role, "").ToLowerInvariant()
                Case "admin", "owner"
                    Return "مدير النظام"
                Case "manager", "supervisor"
                    Return "مشرف"
                Case "viewer"
                    Return "مشاهد"
                Case Else
                    Return "مستخدم"
            End Select
        End Function

        Private Shared Function MapRole(roleName As String) As String
            Dim r = If(roleName, "").ToLowerInvariant()
            If r.Contains("مدير") OrElse r.Contains("admin") OrElse r.Contains("owner") Then Return "admin"
            If r.Contains("مشرف") OrElse r.Contains("manager") OrElse r.Contains("supervisor") Then Return "manager"
            If r.Contains("مشاهد") OrElse r.Contains("viewer") OrElse r.Contains("read") Then Return "viewer"
            Return "user"
        End Function

        ''' <summary>
        ''' إشعار شاشات البرنامج المفتوحة (مثل شاشة الدخول وشاشة المستخدمين) بتحديث القائمة في خيط الواجهة
        ''' </summary>
        Private Shared Sub NotifyFormsUserListChanged()
            Try
                RaiseEvent UsersUpdated()

                If Application.OpenForms IsNot Nothing Then
                    For Each f As Form In Application.OpenForms
                        If f Is Nothing OrElse f.IsDisposed Then Continue For

                        If TypeOf f Is Global.WindowsApp1.Login Then
                            Dim lf = DirectCast(f, Global.WindowsApp1.Login)
                            Try
                                lf.BeginInvoke(Sub() lf.FillUsersComboBox(showPromptOnError:=False))
                            Catch __logEx As Exception
                                Logger.LogError("UserSyncService.vb:681", __logEx)
                            End Try
                        ElseIf TypeOf f Is Global.WindowsApp1.frmUsers Then
                            Dim uf = DirectCast(f, Global.WindowsApp1.frmUsers)
                            Try
                                uf.BeginInvoke(Sub() uf.LoadUsersGrid())
                            Catch __logEx As Exception
                                Logger.LogError("UserSyncService.vb:688", __logEx)
                            End Try
                        End If
                    Next
                End If
            Catch ex As Exception
                Logger.LogDebug($"UserSyncService.NotifyForms: {ex.Message}")
            End Try
        End Sub

        ''' <summary>
        ''' جلب مستخدمي المنشأة من جدول users في Supabase عبر دالة admin-db
        ''' </summary>
        Private Shared Async Function FetchCloudUsersAsync(client As HttpClient, companyId As String) As Task(Of List(Of CloudUserInfo))
            Try
                Dim token = Await GetAdminTokenAsync(client).ConfigureAwait(False)
                If String.IsNullOrWhiteSpace(token) Then Return Nothing

                Dim queryData = New With {
                    .token = token,
                    .op = "select",
                    .table = "users",
                    .filter = $"company_id=eq.{companyId}"
                }
                Dim queryJson = JsonConvert.SerializeObject(queryData)
                Dim queryContent As New StringContent(queryJson, Encoding.UTF8, "application/json")
                Dim resp = Await client.PostAsync(AdminDbUrl, queryContent).ConfigureAwait(False)
                If resp.IsSuccessStatusCode Then
                    Dim json = Await resp.Content.ReadAsStringAsync().ConfigureAwait(False)
                    Return JsonConvert.DeserializeObject(Of List(Of CloudUserInfo))(json)
                ElseIf resp.StatusCode = System.Net.HttpStatusCode.Unauthorized Then
                    _cachedAdminToken = ""
                    _tokenExpiresAt = DateTime.MinValue
                End If
            Catch ex As Exception
                Logger.LogDebug($"UserSyncService.FetchCloudUsers: {ex.Message}")
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' الحصول على توكن الإدارة مع التخزين المؤقت لتجنب تكرار الاتصال غير الضروري.
        ''' أمان: بيانات الإدارة تُقرأ من App.config (مفاتيح Sync:AdminUsername / Sync:AdminPassword)
        ''' ولا تُكتب في الكود المصدري إطلاقاً. إن لم توجد، تتخطى المزامنة الإدارية وتسجل خطأ.
        ''' </summary>
        Private Shared Async Function GetAdminTokenAsync(client As HttpClient) As Task(Of String)
            If Not String.IsNullOrWhiteSpace(_cachedAdminToken) AndAlso DateTime.UtcNow < _tokenExpiresAt Then
                Return _cachedAdminToken
            End If

            Dim adminUser = System.Configuration.ConfigurationManager.AppSettings("Sync:AdminUsername")
            Dim adminPass = System.Configuration.ConfigurationManager.AppSettings("Sync:AdminPassword")
            If String.IsNullOrWhiteSpace(adminUser) OrElse String.IsNullOrWhiteSpace(adminPass) Then
                ' التحذير يُسجل مرة واحدة يومياً فقط — التكرار كل 25 ثانية كان يضخم ملف اللوج
                If (DateTime.UtcNow - _lastAdminConfigWarnAt) >= TimeSpan.FromHours(24) Then
                    _lastAdminConfigWarnAt = DateTime.UtcNow
                    Logger.LogWarning("UserSyncService.GetAdminToken", "إعدادات المزامنة الإدارية غير مكتملة (Sync:AdminUsername / Sync:AdminPassword في App.config) — تم تخطي المزامنة الإدارية.")
                End If
                Return Nothing
            End If

            Try
                Dim loginPayload = JsonConvert.SerializeObject(New With {.username = adminUser, .password = adminPass})
                Dim loginContent As New StringContent(loginPayload, Encoding.UTF8, "application/json")
                Dim loginResp = Await client.PostAsync(AdminLoginUrl, loginContent).ConfigureAwait(False)
                If loginResp.IsSuccessStatusCode Then
                    Dim loginJson = Await loginResp.Content.ReadAsStringAsync().ConfigureAwait(False)
                    Dim loginObj = JObject.Parse(loginJson)
                    Dim token = Convert.ToString(loginObj("token"))
                    If Not String.IsNullOrWhiteSpace(token) Then
                        _cachedAdminToken = token
                        _tokenExpiresAt = DateTime.UtcNow.AddHours(2)
                        Return token
                    End If
                End If
            Catch ex As Exception
                Logger.LogDebug($"UserSyncService.GetAdminToken: {ex.Message}")
            End Try

            Return Nothing
        End Function

        ''' <summary>
        ''' تحديث كلمات المرور والبيانات كاملة مباشرة على جدول users لظهورها في لوحة التحكم الإدارية
        ''' </summary>
        Private Shared Async Function SyncUserDetailsDirectAsync(companyId As String, users As List(Of LocalUserInfo)) As Task
            Try
                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(8)
                    client.DefaultRequestHeaders.Add("apikey", LicenseSettings.PublishableKey)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " & LicenseSettings.PublishableKey)

                    Dim token = Await GetAdminTokenAsync(client).ConfigureAwait(False)
                    If String.IsNullOrWhiteSpace(token) Then Return

                    For Each u In users
                        Try
                            Dim effectiveActive = (u.IsActive AndAlso Not u.IsDeleted)
                            Dim changes As New Dictionary(Of String, Object) From {
                                {"password_hash", u.Password},
                                {"full_name", u.FullName},
                                {"role", u.Role},
                                {"is_active", effectiveActive}
                            }
                            If Not String.IsNullOrWhiteSpace(u.Phone) Then changes("phone") = u.Phone
                            If Not String.IsNullOrWhiteSpace(u.Email) Then changes("email") = u.Email
                            If Not String.IsNullOrWhiteSpace(u.PhotoBase64) Then changes("avatar_url") = u.PhotoBase64

                            Dim updateData = New With {
                                .token = token,
                                .op = "update",
                                .table = "users",
                                .filter = $"company_id=eq.{companyId}&username=eq.{u.Username}",
                                .payload = changes
                            }
                            Dim updateJson = JsonConvert.SerializeObject(updateData)
                            Dim updateContent As New StringContent(updateJson, Encoding.UTF8, "application/json")
                            Await client.PostAsync(AdminDbUrl, updateContent).ConfigureAwait(False)
                        Catch __logEx As Exception
                            Logger.LogError("UserSyncService.vb:803", __logEx)
                        End Try
                    Next
                End Using
            Catch ex As Exception
                Logger.LogDebug($"UserSyncService.SyncUserDetailsDirectAsync: {ex.Message}")
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
                    client.Timeout = TimeSpan.FromSeconds(8)
                    client.DefaultRequestHeaders.Add("apikey", supabaseKey)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " & supabaseKey)

                    Dim fetchBody As New StringContent(
                        JsonConvert.SerializeObject(New With {.p_company_id = companyId}),
                        Encoding.UTF8, "application/json")

                    Dim resp = Await client.PostAsync(supabaseUrl.TrimEnd("/"c) & "/rest/v1/rpc/get_pending_password_resets", fetchBody).ConfigureAwait(False)
                    If Not resp.IsSuccessStatusCode Then Return

                    Dim json = Await resp.Content.ReadAsStringAsync().ConfigureAwait(False)
                    Dim rows = JsonConvert.DeserializeObject(Of List(Of PendingResetItem))(json)
                    If rows Is Nothing OrElse rows.Count = 0 Then Return

                    For Each r In rows
                        If String.IsNullOrWhiteSpace(r.username) OrElse String.IsNullOrWhiteSpace(r.pending_password_hash) Then Continue For

                        Try
                            Using cn = DBModule.NewConn()
                                Using cmd As New SqlCommand("UPDATE Users_TBL SET User_password = @pwd WHERE User_username = @user", cn)
                                    ' أمان: قناة إعادة تعيين كلمة المرور تخزن تجزئة فقط
                                    cmd.Parameters.AddWithValue("@pwd", SanitizeIncomingPassword(r.pending_password_hash))
                                    cmd.Parameters.AddWithValue("@user", r.username)
                                    cmd.ExecuteNonQuery()
                                End Using
                            End Using

                            Dim clearBody As New StringContent(
                                JsonConvert.SerializeObject(New With {.p_company_id = companyId, .p_username = r.username}),
                                Encoding.UTF8, "application/json")
                            Await client.PostAsync(supabaseUrl.TrimEnd("/"c) & "/rest/v1/rpc/clear_password_reset", clearBody).ConfigureAwait(False)
                            Logger.Info($"UserSyncService: Applied pending password reset for user {r.username}")
                        Catch exRow As Exception
                            Logger.LogError("UserSyncService.ApplyPasswordReset", exRow)
                        End Try
                    Next
                End Using
            Catch ex As Exception
                Logger.LogDebug($"UserSyncService.PullPasswordResetsAsync: {ex.Message}")
            End Try
        End Function

        Private Class PendingResetItem
            Public Property username As String
            Public Property pending_password_hash As String
        End Class
    End Class
End Namespace
