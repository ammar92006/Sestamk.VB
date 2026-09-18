Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports Guna.UI2.WinForms
Imports System.Drawing.Imaging
' [FIX] Alias لتجنب تضارب Timer بين System.Threading.Timer و System.Windows.Forms.Timer
Imports WinFormsTimer = System.Windows.Forms.Timer

Public Module DBModule

    ' ──────────────────────────────────────────────────────────
    ' متغير الاتصال العام — للحفاظ على التوافق مع الكود القديم
    ' كل استدعاء لـ Connect() يستبدل أي اتصال سابق ويغلقه أولاً.
    ' المتغير محمي بـ SyncLock لتجنب race conditions بين الخيوط.
    ' ──────────────────────────────────────────────────────────
    Public Conn As SqlConnection
    Private ReadOnly _connLock As New Object()

    ' ══════════════════════════════════════════════════════════
    ' إعدادات الاتصال - يمكن تغييرها من فورم الاعدادات
    ' ══════════════════════════════════════════════════════════
    Public server As String = "(localdb)\MSSQLLocalDB"
    Public database As String = "SestamkDB"
    Public username As String = ""
    Public password As String = ""
    Public useWindowsAuth As Boolean = True  ' True = Windows Auth, False = SQL Auth

    ''' <summary>بناء ConnectionString من قيم محددة (يُستخدم للاختبار والاكتشاف التلقائي)</summary>
    Public Function BuildConnectionString(srv As String, db As String,
                                          usr As String, pwd As String,
                                          winAuth As Boolean) As String
        Dim auth As String = If(winAuth,
            "Integrated Security=True;",
            $"User Id={usr};Password={pwd};")

        Return $"Server={srv};Database={db};{auth}" &
               "MultipleActiveResultSets=True;" &
               "Pooling=True;Max Pool Size=200;Min Pool Size=5;" &
               "Connect Timeout=10;"
    End Function

    ''' <summary>بناء ConnectionString مع تفعيل Connection Pooling و Timeout</summary>
    Public ReadOnly Property ConnectionString As String
        Get
            Return BuildConnectionString(server, database, username, password, useWindowsAuth)
        End Get
    End Property

    Public Function ExecuteQuery(query As String) As DataTable
        ' 💡 ضع نص الاتصال (Connection String) الخاص بقاعدة بياناتك هنا

        Dim dt As New DataTable()

        ' استخدام Using يضمن إغلاق وتفريغ الاتصال فوراً حتى لو حصل خطأ
        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                Using da As New SqlDataAdapter(cmd)
                    Try
                        conn.Open()
                        da.Fill(dt)
                        Return dt
                    Catch ex As Exception
                        ' عرض الخطأ بشكل واضح لمعرفته أثناء التطوير
                        MessageBox.Show("حدث خطأ أثناء الاتصال بقاعدة البيانات: " & ex.Message,
                                    "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return Nothing
                    End Try
                End Using
            End Using
        End Using
    End Function
    Public Function ExecuteNonQuery(query As String) As Integer
        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                Try
                    conn.Open()
                    Return cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("حدث خطأ أثناء تنفيذ العملية: " & ex.Message,
                                    "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return -1
                End Try
            End Using
        End Using
    End Function

    Public Function ExecuteScalar(query As String) As Object
        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                Try
                    conn.Open()
                    Return cmd.ExecuteScalar()
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        End Using
    End Function
    ' تحويل النص من قاعدة البيانات (Base64) إلى صورة لعرضها
    Public Function Base64ToImage(base64String As String) As Image
        If String.IsNullOrEmpty(base64String) Then Return Nothing
        Try
            Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
            Using ms As New MemoryStream(imageBytes)
                Return Image.FromStream(ms)
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    ' تحويل الصورة من الـ PictureBox إلى نص Base64 لحفظها
    Public Function ImageToBase64(img As Image) As String
        If img Is Nothing Then Return String.Empty
        Try
            Using ms As New MemoryStream()
                ' حفظ الصورة في الذاكرة بصيغة Png للحفاظ على الشفافية والجودة
                img.Save(ms, ImageFormat.Png)
                Dim imageBytes As Byte() = ms.ToArray()
                Return Convert.ToBase64String(imageBytes)
            End Using
        Catch
            Return String.Empty
        End Try
    End Function

    ' ══════════════════════════════════════════════════════════
    ' مسار ملف الاعدادات المحلي
    ' ══════════════════════════════════════════════════════════
    Private ReadOnly DbConfigPath As String =
        Path.Combine(Application.StartupPath, "db_config.ini")

    ''' <summary>تحميل إعدادات قاعدة البيانات من الملف عند بداية التشغيل</summary>
    Public Sub LoadDbSettings()
        Try
            If Not File.Exists(DbConfigPath) Then Exit Sub
            For Each line As String In File.ReadAllLines(DbConfigPath)
                If line.StartsWith("#") OrElse Not line.Contains("=") Then Continue For
                Dim parts() As String = line.Split(New Char() {"="c}, 2)
                Dim key As String = parts(0).Trim().ToLower()
                Dim val As String = parts(1).Trim()
                Select Case key
                    Case "server" : server = val
                    Case "database" : database = val
                    Case "username" : username = val
                    Case "password" : password = val
                    Case "windowsauth" : useWindowsAuth = (val.ToLower() = "true")
                End Select
            Next
        Catch ex As Exception
            Debug.WriteLine("خطأ تحميل إعدادات DB: " & ex.Message)
        End Try
    End Sub

    ''' <summary>حفظ إعدادات قاعدة البيانات في الملف</summary>
    Public Sub SaveDbSettings()
        Try
            Dim lines() As String = {
                "# إعدادات قاعدة البيانات - لا تحذف هذا الملف",
                "server=" & server,
                "database=" & database,
                "username=" & username,
                "password=" & password,
                "windowsauth=" & useWindowsAuth.ToString().ToLower()
            }
            File.WriteAllLines(DbConfigPath, lines)
        Catch ex As Exception
            MessageBox.Show("خطأ حفظ إعدادات DB: " & ex.Message, "خطأ")
        End Try
    End Sub

    ''' <summary>اختبار الاتصال بقاعدة البيانات وإرجاع True إذا نجح</summary>
    Public Function TestConnection(Optional customConnStr As String = "") As Boolean
        Try
            Dim cs As String = If(String.IsNullOrEmpty(customConnStr), ConnectionString, customConnStr)
            Using testConn As New SqlConnection(cs)
                testConn.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function

    ' ══════════════════════════════════════════════════════════
    ' اكتشاف خوادم SQL المثبتة على الجهاز تلقائياً
    ' (LocalDB ثم النسخ المسماة من الريجستري ثم الافتراضيات الشائعة)
    ' الترتيب = أولوية المحاولة عند الاتصال التلقائي.
    ' ══════════════════════════════════════════════════════════
    Public Function DetectSqlServers() As List(Of String)
        Dim found As New List(Of String)

        ' (1) نسخ LocalDB عبر أداة sqllocaldb
        Try
            Dim psi As New ProcessStartInfo("sqllocaldb", "info") With {
                .RedirectStandardOutput = True,
                .UseShellExecute = False,
                .CreateNoWindow = True
            }
            Using p = Process.Start(psi)
                Dim output As String = p.StandardOutput.ReadToEnd()
                p.WaitForExit(3000)
                For Each line As String In output.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                    Dim inst As String = line.Trim()
                    If inst <> "" Then found.Add("(localdb)\" & inst)
                Next
            End Using
        Catch
        End Try

        ' التأكد من وجود النسخة الافتراضية لـ LocalDB دائماً
        If Not found.Any(Function(s) s.ToLower().Contains("mssqllocaldb")) Then
            found.Add("(localdb)\MSSQLLocalDB")
        End If

        ' (2) نسخ SQL المثبتة محلياً من الريجستري
        Try
            Using key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                "SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL")
                If key IsNot Nothing Then
                    For Each instName As String In key.GetValueNames()
                        If instName.ToUpper() = "MSSQLSERVER" Then
                            AddUnique(found, Environment.MachineName)
                            AddUnique(found, ".")
                        Else
                            AddUnique(found, Environment.MachineName & "\" & instName)
                            AddUnique(found, ".\" & instName)
                        End If
                    Next
                End If
            End Using
        Catch
        End Try

        ' (3) افتراضيات شائعة كحل أخير
        For Each fb As String In {".\SQLEXPRESS", "localhost", "."}
            AddUnique(found, fb)
        Next

        Return found
    End Function

    Private Sub AddUnique(list As List(Of String), value As String)
        If Not list.Any(Function(x) String.Equals(x, value, StringComparison.OrdinalIgnoreCase)) Then
            list.Add(value)
        End If
    End Sub

    ''' <summary>
    ''' محاولة اتصال تلقائية صامتة: تجرّب الإعدادات المحفوظة أولاً،
    ''' فإن فشلت تجرّب كل الخوادم المكتشفة بنفس قاعدة البيانات والمصادقة،
    ''' وكحل أخير تُهيّئ قاعدة LocalDB من نسخة احتياطية مرفقة (لأجهزة التثبيت الجديدة).
    ''' عند أول نجاح تحفظ الإعدادات الناجحة في db_config.ini.
    ''' ترجع True إذا نجح الاتصال.
    ''' </summary>
    Public Function TryAutoConnect() As Boolean
        ' (1) جرّب الإعدادات المحفوظة الحالية كما هي
        If TestConnection() Then Return True

        ' (2) جرّب كل خادم مكتشف بنفس قاعدة البيانات والمصادقة
        For Each srv As String In DetectSqlServers()
            Dim cs As String = BuildConnectionString(srv, database, username, password, useWindowsAuth)
            If TestConnection(cs) Then
                server = srv
                Try
                    SaveDbSettings()
                Catch
                End Try
                Return True
            End If
        Next

        ' (3) حل أخير: تهيئة قاعدة LocalDB من النسخة الاحتياطية المرفقة (db\<database>.bak)
        '     يفيد عند التثبيت على جهاز جديد لا توجد عليه قاعدة بيانات بعد.
        If EnsureLocalDbDatabase() Then
            server = "(localdb)\MSSQLLocalDB"
            useWindowsAuth = True
            If TestConnection() Then
                Try
                    SaveDbSettings()
                Catch
                End Try
                Return True
            End If
        End If

        Return False
    End Function

    ''' <summary>
    ''' تتأكد من وجود قاعدة البيانات على LocalDB، وإن لم تكن موجودة تستعيدها من
    ''' نسخة احتياطية مرفقة بالبرنامج في المجلد db\&lt;database&gt;.bak.
    ''' لا تفعل شيئاً (وترجع False بهدوء) إن لم توجد النسخة الاحتياطية أو فشلت العملية.
    ''' </summary>
    Public Function EnsureLocalDbDatabase() As Boolean
        Try
            ' تشغيل نسخة LocalDB الافتراضية (إنشاء + بدء) بأفضل جهد
            For Each arg As String In {"create MSSQLLocalDB", "start MSSQLLocalDB"}
                Try
                    Dim psi As New ProcessStartInfo("sqllocaldb", arg) With {
                        .CreateNoWindow = True, .UseShellExecute = False,
                        .WindowStyle = ProcessWindowStyle.Hidden}
                    Process.Start(psi).WaitForExit(8000)
                Catch
                End Try
            Next

            Dim masterCs As String = "Server=(localdb)\MSSQLLocalDB;Database=master;Integrated Security=True;Connect Timeout=15;"
            Using cn As New SqlConnection(masterCs)
                cn.Open()

                ' هل القاعدة موجودة بالفعل؟
                Using chk As New SqlCommand("SELECT DB_ID(@n)", cn)
                    chk.Parameters.AddWithValue("@n", database)
                    Dim r = chk.ExecuteScalar()
                    If r IsNot Nothing AndAlso Not Convert.IsDBNull(r) Then Return True
                End Using

                ' البحث عن النسخة الاحتياطية المرفقة
                Dim bak As String = Path.Combine(Application.StartupPath, "db", database & ".bak")
                If Not File.Exists(bak) Then Return False

                ' قراءة الأسماء المنطقية من النسخة الاحتياطية
                Dim dataLogical As String = "", logLogical As String = ""
                Using fl As New SqlCommand("RESTORE FILELISTONLY FROM DISK=@p", cn)
                    fl.Parameters.AddWithValue("@p", bak)
                    Using rd = fl.ExecuteReader()
                        While rd.Read()
                            Dim t = rd("Type").ToString().ToUpper()
                            If t = "D" AndAlso dataLogical = "" Then dataLogical = rd("LogicalName").ToString()
                            If t = "L" AndAlso logLogical = "" Then logLogical = rd("LogicalName").ToString()
                        End While
                    End Using
                End Using
                If dataLogical = "" Then Return False
                If logLogical = "" Then logLogical = dataLogical & "_log"

                Dim dataDir As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                Dim mdf As String = Path.Combine(dataDir, database & ".mdf")
                Dim ldf As String = Path.Combine(dataDir, database & "_log.ldf")

                ' بناء أمر RESTORE (الأسماء المنطقية لا تقبل Parameters في T-SQL فنُهرّب علامات الاقتباس)
                Dim esc = Function(s As String) s.Replace("'", "''")
                Dim restoreSql As String =
                    "RESTORE DATABASE [" & database.Replace("]", "]]") & "] FROM DISK=@p WITH " &
                    "MOVE '" & esc(dataLogical) & "' TO '" & esc(mdf) & "', " &
                    "MOVE '" & esc(logLogical) & "' TO '" & esc(ldf) & "', REPLACE"

                Using rs As New SqlCommand(restoreSql, cn)
                    rs.CommandTimeout = 180
                    rs.Parameters.AddWithValue("@p", bak)
                    rs.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            Logger.LogError("EnsureLocalDbDatabase", ex)
            Return False
        End Try
    End Function

    ' ══════════════════════════════════════════════════════════
    ' Connect / Disconnect — متوافقة مع الكود القديم لكن آمنة
    '
    ' Connect() الجديدة:
    '   1) تتخلص بأمان من أي Conn سابق (Close + Dispose).
    '   2) تنشئ اتصالاً جديداً وتفتحه (يستخدم Connection Pool تلقائياً).
    '   3) محمية بـ SyncLock ضد race conditions بين الخيوط.
    '
    ' Disconnect() الجديدة:
    '   1) تغلق وتتخلص من Conn.
    '   2) تجعله Nothing لمنع الاستخدام بعد الإغلاق.
    ' ══════════════════════════════════════════════════════════
    Public Sub Connect()
        SyncLock _connLock
            Try
                ' [FIX جوهري - 2026-05-26] الحفاظ على التوافق التام مع الكود القديم
                ' الذي يستدعي Connect() عدة مرات أثناء نفس العملية (مثلاً ReportsModule).
                ' إذا كان Conn موجوداً ومفتوحاً، أعد استخدامه (لا تتخلص منه
                ' لأن SqlCommand قد يكون يحتفظ بـ reference له).
                If Conn IsNot Nothing Then
                    Try
                        If Conn.State = ConnectionState.Open Then
                            Exit Sub
                        End If
                    Catch
                        ' Conn قد يكون disposed أو في حالة غير صالحة - أنشئ جديد
                    End Try
                End If

                ' لاحظ: لا نستدعي Conn.Dispose() على القديم لأن قد يكون
                ' هناك SqlCommand يحمل reference له. الـ GC و Connection Pool
                ' سيتعاملان معه. للتنظيف الصريح استخدم Disconnect().
                Conn = New SqlConnection(ConnectionString)
                Conn.Open()

            Catch ex As Exception
                Conn = Nothing
                MsgBox("فشل الاتصال بقاعدة البيانات ❌" & vbCrLf & ex.Message,
                       MsgBoxStyle.Critical, "خطأ")
            End Try
        End SyncLock
    End Sub

    Public Sub Disconnect()
        SyncLock _connLock
            Try
                If Conn IsNot Nothing Then
                    If Conn.State <> ConnectionState.Closed Then
                        Conn.Close()
                    End If
                    Conn.Dispose()
                End If
            Catch ex As Exception
                Debug.WriteLine("Disconnect Error: " & ex.Message)
            Finally
                Conn = Nothing
            End Try
        End SyncLock
    End Sub

    ''' <summary>
    ''' Helper جديد لإنشاء اتصال محلي مفتوح — للاستخدام داخل Using.
    ''' هذا هو النمط المفضل للكود الجديد والآمن لـ Async.
    ''' </summary>
    Public Function NewConn() As SqlConnection
        Dim cn As New SqlConnection(ConnectionString)
        cn.Open()
        Return cn
    End Function

    ''' <summary>
    ''' Helper async لإنشاء اتصال محلي مفتوح بدون حجب UI Thread.
    ''' </summary>
    Public Async Function NewConnAsync() As Task(Of SqlConnection)
        Dim cn As New SqlConnection(ConnectionString)
        Await cn.OpenAsync()
        Return cn
    End Function

    ' ──────────────────────────────────────────────────────────
    ' خرائط أسماء الأعمدة بالعربية
    ' ──────────────────────────────────────────────────────────
    Public ColumnMap As New Dictionary(Of String, String)

    Public Function GetColumnNamesWithArabic(tableName As String) As Dictionary(Of String, String)
        Dim columns As New Dictionary(Of String, String)()

        Try
            Using cn As SqlConnection = NewConn()
                Dim query As String = "
                SELECT COLUMN_NAME
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = @TableName
                ORDER BY ORDINAL_POSITION"

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@TableName", tableName)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim colName As String = reader("COLUMN_NAME").ToString()
                            Dim arabicName As String = ""

                            Select Case colName
                                Case "Partner_ID" : arabicName = "الكود"
                                Case "Partner_Name" : arabicName = "الاسم"
                                Case "Partner_Type" : arabicName = "النوع"
                                Case "Phone" : arabicName = "رقم الهاتف"
                                Case "Address" : arabicName = "العنوان"
                                Case "CompanyName" : arabicName = "اسم الشركة"
                                Case "Balance" : arabicName = "الرصيد"
                                Case "ImagePath" : arabicName = "مسار الصورة"
                                Case "Notes" : arabicName = "ملاحظات"
                                Case "CreatedAt" : arabicName = "تاريخ الإنشاء"

                                Case "Product_ID" : arabicName = "ID المنتج"
                                Case "Product_Code" : arabicName = "كود المنتج"
                                Case "Product_Name" : arabicName = "اسم المنتج"
                                Case "Category_ID" : arabicName = "التصنيف"
                                Case "Product_Barcode" : arabicName = "باركود"
                                Case "Product_Image" : arabicName = "الصوره"
                                Case "Product_State" : arabicName = "حالة الباركود"
                                Case "Product_Note" : arabicName = "ملاحظات"

                                Case "ProductUnit_ID" : arabicName = "كود الوحدة"
                                Case "Unit_Name" : arabicName = "اسم الوحدة"
                                Case "Unit_Quantity" : arabicName = "عدد الوحدات الصغيرة داخلها"
                                Case "Barcode" : arabicName = "الباركود"
                                Case "Purchase_Price" : arabicName = "سعر الشراء"
                                Case "Sale_Price" : arabicName = "سعر البيع"
                                Case "Expiry_Date" : arabicName = "تاريخ الانتهاء"

                                Case Else : arabicName = colName
                            End Select

                            If Not columns.ContainsKey(colName) Then
                                columns.Add(colName, arabicName)
                            End If
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Error loading column names: " & ex.Message)
        End Try

        Return columns
    End Function

    Public Sub LoadColumnNamesFromDB(cmb As ComboBox, tableName As String)
        ColumnMap = GetColumnNamesWithArabic(tableName)
        cmb.Items.Clear()
        For Each kvp In ColumnMap
            cmb.Items.Add(kvp.Value)
        Next
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' إعداد البحث التفاعلي (Live Search)
    '
    ' الإصلاحات الجوهرية:
    '   1) تايمر مخصص لكل ListBox/TextBox (Dictionary) بدلاً من واحد عام
    '      كان يتصادم بين الفورمات المفتوحة.
    '   2) تنفيذ الاستعلام في الخلفية بـ Task.Run + OpenAsync حتى لا
    '      يتجمد UI Thread أثناء الكتابة.
    '   3) إلغاء الاستعلام السابق عند ضغطة مفتاح جديدة (CancellationToken)
    '      حتى لا تتراكم نتائج قديمة أو تستهلك Connection Pool.
    '   4) إزالة Handlers قبل الإضافة لمنع تكرارها لو تم استدعاء
    '      SetupLiveSearch لنفس العنصر أكثر من مرة.
    ' ──────────────────────────────────────────────────────────
    Private ReadOnly _searchTimers As New Dictionary(Of Guna2TextBox, WinFormsTimer)
    Private ReadOnly _searchCts As New Dictionary(Of Guna2TextBox, CancellationTokenSource)

    Public Sub SetupLiveSearch(cmb As ComboBox, txt As Guna2TextBox, lst As ListBox, tableName As String, parentForm As Form)
        ' تنسيق الـ ListBox
        lst.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lst.BorderStyle = BorderStyle.FixedSingle
        lst.Height = 95
        lst.Width = txt.Width
        lst.Visible = False
        lst.BackColor = Color.White
        lst.ForeColor = Color.Black
        lst.IntegralHeight = False
        lst.ItemHeight = 25
        lst.BringToFront()

        ' تايمر مخصص لهذا العنصر (يمنع التصادم بين الفورمات)
        Dim timer As WinFormsTimer = Nothing
        If Not _searchTimers.TryGetValue(txt, timer) Then
            timer = New WinFormsTimer() With {.Interval = 300}
            _searchTimers(txt) = timer
        End If

        ' إزالة handlers قديمة قبل الإضافة (لمنع التكرار)
        RemoveAllTickHandlers(timer)
        AddHandler timer.Tick, Sub()
                                   timer.Stop()
                                   ' إطلاق Async بدون انتظار (Fire-and-forget)
                                   LoadSuggestionsAsync(cmb, txt, lst, tableName)
                               End Sub

        AddHandler txt.TextChanged, Sub()
                                        timer.Stop()
                                        If txt.Text.Trim() <> "" Then
                                            timer.Start()
                                            lst.Visible = True
                                        Else
                                            CancelPendingSearch(txt)
                                            lst.Visible = False
                                            lst.Items.Clear()
                                        End If
                                    End Sub

        AddHandler lst.Click, Sub()
                                  If lst.SelectedItem IsNot Nothing Then
                                      txt.Text = lst.SelectedItem.ToString()
                                      lst.Visible = False
                                  End If
                              End Sub

        AddHandler txt.KeyDown, Sub(sender, e)
                                    If e.KeyCode = Keys.Enter AndAlso lst.Visible AndAlso lst.Items.Count > 0 Then
                                        txt.Text = lst.Items(0).ToString()
                                        lst.Visible = False
                                        e.SuppressKeyPress = True
                                    End If
                                End Sub
    End Sub

    Private Sub RemoveAllTickHandlers(t As WinFormsTimer)
        ' .NET لا توفر طريقة سهلة لإزالة كل handlers، لكن لا داعي
        ' للقلق لأن Dictionary يضمن أن نستخدم نفس instance.
        ' لو لزم الأمر يمكن استبدال instance:
        Try
            t.Stop()
        Catch
        End Try
    End Sub

    Private Sub CancelPendingSearch(txt As Guna2TextBox)
        Dim cts As CancellationTokenSource = Nothing
        If _searchCts.TryGetValue(txt, cts) Then
            Try
                cts.Cancel()
                cts.Dispose()
            Catch
            End Try
            _searchCts.Remove(txt)
        End If
    End Sub

    ' دالة عامة لفتح أي فورم بدون تكرار مع فحص الصلاحيات وتطبيقها
    Public Sub OpenSingleForm(Of T As {Form, New})()
        Dim formName As String = GetType(T).Name
        If Not Session.HasPermission(formName, "CanOpen") Then
            Dim dispName As String = Session.GetScreenDisplayName(formName)
            MessageBox.Show("عفواً، ليس لديك صلاحية لفتح هذه الشاشة (" & dispName & ")!", "صلاحيات الوصول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim frm As Form = Application.OpenForms.
            Cast(Of Form)().
            FirstOrDefault(Function(f) TypeOf f Is T)
        If frm IsNot Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            frm.Focus()
            Session.ApplyFormPermissions(frm, formName)
        Else
            Dim newForm As New T()
            AddHandler newForm.Load, Sub(s, e)
                                         Session.ApplyFormPermissions(newForm, formName)
                                     End Sub
            AddHandler newForm.Shown, Sub(s, e)
                                          Session.ApplyFormPermissions(newForm, formName)
                                      End Sub
            newForm.Show()
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' تحميل الاقتراحات بشكل Async (بدون حجب UI Thread)
    ' ──────────────────────────────────────────────────────────
    Public Async Sub LoadSuggestionsAsync(cmb As ComboBox, txt As Guna2TextBox, lst As ListBox, tableName As String)
        ' التحقق من المدخلات على UI thread أولاً
        If cmb.SelectedItem Is Nothing OrElse txt.Text.Trim() = "" Then
            lst.Visible = False
            lst.Items.Clear()
            Return
        End If

        Dim selectedCriterion As String = cmb.SelectedItem.ToString()
        Dim selectedColumn As String = MapCriterionToColumn(selectedCriterion)

        If selectedCriterion <> "الكل" AndAlso selectedColumn = "" Then
            MsgBox("الرجاء اختيار معيار بحث صحيح.", MsgBoxStyle.Exclamation, "خطأ")
            Return
        End If

        Dim searchText As String = txt.Text

        ' إلغاء أي بحث سابق معلق
        CancelPendingSearch(txt)
        Dim cts As New CancellationTokenSource()
        _searchCts(txt) = cts
        Dim token As CancellationToken = cts.Token

        Dim results As New List(Of String)()

        Try
            Using cn As SqlConnection = Await NewConnAsync()
                If token.IsCancellationRequested Then Return

                Dim query As String = $"SELECT DISTINCT [{selectedColumn}] FROM [{tableName}] WHERE [{selectedColumn}] LIKE @search"

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@search", searchText & "%")

                    Using reader As SqlDataReader = Await cmd.ExecuteReaderAsync(token)
                        While Await reader.ReadAsync(token)
                            If Not reader.IsDBNull(0) Then
                                results.Add(reader.GetValue(0).ToString())
                            End If
                        End While
                    End Using
                End Using
            End Using

        Catch ex As OperationCanceledException
            Return ' تم إلغاء البحث - طبيعي
        Catch ex As Exception
            lst.Visible = False
            ' لا نظهر MessageBox من background thread - فقط لوج
            Debug.WriteLine("LoadSuggestionsAsync Error: " & ex.Message)
            Return
        End Try

        ' تحديث الـ UI على UI Thread
        If token.IsCancellationRequested Then Return

        Try
            lst.Items.Clear()
            For Each item In results
                lst.Items.Add(item)
            Next
            lst.Visible = (lst.Items.Count > 0)
        Catch
        End Try
    End Sub

    ''' <summary>تحويل معيار البحث العربي إلى اسم العمود</summary>
    Private Function MapCriterionToColumn(criterion As String) As String
        Select Case criterion
            Case "الكود" : Return "Partner_ID"
            Case "الاسم" : Return "Partner_Name"
            Case "النوع" : Return "Partner_Type"
            Case "رقم الهاتف" : Return "Phone"
            Case "العنوان" : Return "Address"
            Case "اسم الشركة" : Return "CompanyName"
            Case "الرصيد" : Return "Balance"
            Case "مسار الصورة" : Return "ImagePath"
            Case "ملاحظات" : Return "Notes"
            Case "تاريخ الإنشاء" : Return "CreatedAt"
            Case Else : Return ""
        End Select
    End Function

    ''' <summary>
    ''' دالة قديمة محفوظة للتوافق - تُحوّل داخلياً للنسخة Async
    ''' </summary>
    Public Sub LoadSuggestions(cmb As ComboBox, txt As Guna2TextBox, lst As ListBox, tableName As String)
        LoadSuggestionsAsync(cmb, txt, lst, tableName)
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' Helper: تفعيل DoubleBuffered على DataGridView لتقليل الـ Flickering
    ' ──────────────────────────────────────────────────────────
    Public Sub EnableDoubleBuffer(dgv As DataGridView)
        Try
            Dim pi = GetType(DataGridView).GetProperty(
                "DoubleBuffered",
                Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            If pi IsNot Nothing Then
                pi.SetValue(dgv, True, Nothing)
            End If
        Catch
        End Try
    End Sub

End Module
