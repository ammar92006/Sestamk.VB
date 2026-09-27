Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Namespace Services

    ''' <summary>
    ''' كائن تقرير الصيانة والفحص والترقيع التلقائي (Audit Log)
    ''' </summary>
    Public Class MaintenanceReport
        Public Property IsSuccess As Boolean = True
        Public Property DatabaseCreated As Boolean = False
        Public Property TablesCreated As New List(Of String)()
        Public Property ColumnsAdded As New List(Of String)()
        Public Property Errors As New List(Of String)()
        Public Property AuditLog As New StringBuilder()
        Public Property ExecutionTime As TimeSpan = TimeSpan.Zero

        Public Sub Log(message As String)
            Dim timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            AuditLog.AppendLine($"[{timestamp}] {message}")
        End Sub

        Public Sub LogError(message As String, Optional ex As Exception = Nothing)
            IsSuccess = False
            Dim fullMsg = If(ex IsNot Nothing, $"{message} - {ex.Message}", message)
            Errors.Add(fullMsg)
            Log($"❌ خطأ: {fullMsg}")
        End Sub

        Public Overrides Function ToString() As String
            Return AuditLog.ToString()
        End Function
    End Class

    ''' <summary>
    ''' كائن إشعار التقدم في عمليات الصيانة
    ''' </summary>
    Public Class MaintenanceProgress
        Public Property Percentage As Integer
        Public Property CurrentStep As String
        Public Property Message As String

        Public Sub New(percentage As Integer, currentStep As String, message As String)
            Me.Percentage = percentage
            Me.CurrentStep = currentStep
            Me.Message = message
        End Sub
    End Class

    ''' <summary>
    ''' معلومات وإحصائيات جدول في قاعدة البيانات
    ''' </summary>
    Public Class TableInfo
        Public Property TableName As String
        Public Property DisplayNameAr As String
        Public Property DisplayNameEn As String
        Public Property RecordCount As Long
        Public Property IsTransactional As Boolean
        Public Property ExistsInDb As Boolean
    End Class

    ''' <summary>
    ''' محرك الفحص والترقيع التلقائي والصيانة الشاملة لقاعدة البيانات
    ''' (Database Self-Healing and Integrity Engine)
    ''' </summary>
    Public Class DatabaseMaintenanceService

        Private ReadOnly _connectionString As String
        Private ReadOnly _serverName As String
        Private ReadOnly _databaseName As String
        Private ReadOnly _username As String
        Private ReadOnly _password As String
        Private ReadOnly _useWindowsAuth As Boolean

        Public Sub New(connectionString As String)
            _connectionString = connectionString
            Dim builder As New SqlConnectionStringBuilder(connectionString)
            _serverName = builder.DataSource
            _databaseName = builder.InitialCatalog
            _username = builder.UserID
            _password = builder.Password
            _useWindowsAuth = builder.IntegratedSecurity
        End Sub

        Public Sub New(server As String, dbName As String, user As String, pass As String, winAuth As Boolean)
            _serverName = server
            _databaseName = dbName
            _username = user
            _password = pass
            _useWindowsAuth = winAuth
            _connectionString = DBModule.BuildConnectionString(server, dbName, user, pass, winAuth)
        End Sub

        ''' <summary>
        ''' إنشاء نص اتصال خاص بقاعدة بيانات master على نفس الخادم
        ''' </summary>
        Private Function BuildMasterConnectionString() As String
            Return DBModule.BuildConnectionString(_serverName, "master", _username, _password, _useWindowsAuth)
        End Function

        ' ══════════════════════════════════════════════════════════════════════
        ' 1. فحص وجود قاعدة البيانات وإنشاؤها تلقائياً (Database Bootstrap)
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>
        ''' فحص وجود قاعدة البيانات عبر master، وإنشاؤها مع تنفيذ سكريبت التهيئة إن كانت مفقودة
        ''' </summary>
        Public Async Function EnsureDatabaseExistsAsync(Optional progress As IProgress(Of MaintenanceProgress) = Nothing) As Task(Of MaintenanceReport)
            Dim report As New MaintenanceReport()
            Dim sw = Stopwatch.StartNew()

            Try
                report.Log($"بدء فحص وجود قاعدة البيانات [{_databaseName}] على الخادم [{_serverName}]...")
                progress?.Report(New MaintenanceProgress(10, "فحص وجود قاعدة البيانات", "جارٍ الاتصال بـ master..."))

                Dim masterCs = BuildMasterConnectionString()
                Dim dbExists As Boolean = False

                Using conn As New SqlConnection(masterCs)
                    Await conn.OpenAsync().ConfigureAwait(False)
                    report.Log("تم الاتصال بخادم SQL Server (master) بنجاح.")

                    Using cmd As New SqlCommand("SELECT DB_ID(@DbName);", conn)
                        cmd.Parameters.AddWithValue("@DbName", _databaseName)
                        Dim result = Await cmd.ExecuteScalarAsync().ConfigureAwait(False)
                        dbExists = (result IsNot Nothing AndAlso Not Convert.IsDBNull(result))
                    End Using

                    If Not dbExists Then
                        report.Log($"قاعدة البيانات [{_databaseName}] غير موجودة. جارٍ إنشاؤها تلقائياً...")
                        progress?.Report(New MaintenanceProgress(30, "إنشاء قاعدة البيانات", $"إنشاء قاعدة البيانات [{_databaseName}]..."))

                        ' إنشاء قاعدة البيانات
                        Dim safeDbName = _databaseName.Replace("]", "]]")
                        Dim createDbSql = $"CREATE DATABASE [{safeDbName}] COLLATE Arabic_CI_AS;"
                        Using createCmd As New SqlCommand(createDbSql, conn)
                            createCmd.CommandTimeout = 120
                            Await createCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                        End Using

                        report.DatabaseCreated = True
                        report.Log($"✅ تم إنشاء قاعدة البيانات [{_databaseName}] بنجاح.")
                    Else
                        report.Log($"✅ تم التحقق: قاعدة البيانات [{_databaseName}] موجودة مسبقاً.")
                    End If
                End Using

                ' إذا كانت القاعدة قد أُنشئت للتو، نقوم بتنفيذ سكريبت التهيئة الأساسي الكامل
                If report.DatabaseCreated Then
                    progress?.Report(New MaintenanceProgress(60, "تنفيذ سكريبت الهيكل الأولي", "جارٍ تنفيذ سكريبت الجداول الأساسية..."))
                    Await ExecuteEmbeddedBootstrapScriptAsync(report).ConfigureAwait(False)
                End If

            Catch ex As Exception
                report.LogError($"فشل أثناء فحص أو إنشاء قاعدة البيانات: {ex.Message}", ex)
            Finally
                sw.Stop()
                report.ExecutionTime = sw.Elapsed
            End Try

            Return report
        End Function

        ''' <summary>
        ''' تنفيذ سكريبت DDL المضمن في الموارد (Embedded Resource)
        ''' </summary>
        Public Async Function ExecuteEmbeddedBootstrapScriptAsync(report As MaintenanceReport) As Task
            Try
                report.Log("جارٍ قراءة سكريبت الهيكل الأولي من الموارد المضمنة...")
                Dim script = ReadEmbeddedScript("DatabaseSchema.sql")

                If String.IsNullOrWhiteSpace(script) Then
                    report.Log("⚠️ لم يتم العثور على سكريبت الموارد المضمنة DatabaseSchema.sql، سيتم استخدام منشئ الهيكل الكودي.")
                    Return
                End If

                Await ExecuteScriptBatchesAsync(script, report).ConfigureAwait(False)
                report.Log("✅ تم تنفيذ سكريبت الهيكل الأولي بنجاح.")
            Catch ex As Exception
                report.LogError($"خطأ أثناء تنفيذ سكريبت التهيئة الأولي: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' قراءة ملف سكريبت نصي من الـ Embedded Resources
        ''' </summary>
        Public Shared Function ReadEmbeddedScript(resourceFileName As String) As String
            Try
                Dim asm = Assembly.GetExecutingAssembly()
                Dim matchingNames = asm.GetManifestResourceNames()

                Dim foundName As String = Nothing
                For Each name In matchingNames
                    If name.EndsWith(resourceFileName, StringComparison.OrdinalIgnoreCase) Then
                        foundName = name
                        Exit For
                    End If
                Next

                If foundName Is Nothing Then
                    ' تجربة قراءة من المجلد الفعلي كـ Fallback
                    Dim localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", resourceFileName)
                    If File.Exists(localPath) Then
                        Return File.ReadAllText(localPath, Encoding.UTF8)
                    End If
                    Return Nothing
                End If

                Using stream = asm.GetManifestResourceStream(foundName)
                    If stream Is Nothing Then Return Nothing
                    Using reader As New StreamReader(stream, Encoding.UTF8)
                        Return reader.ReadToEnd()
                    End Using
                End Using
            Catch ex As Exception
                Debug.WriteLine("ReadEmbeddedScript error: " & ex.Message)
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' تقسيم وتنفيذ أوامر SQL التي تحتوي على فواصل GO
        ''' </summary>
        Public Async Function ExecuteScriptBatchesAsync(script As String, report As MaintenanceReport) As Task
            Using conn As New SqlConnection(_connectionString)
                Await conn.OpenAsync().ConfigureAwait(False)

                ' تقسيم السكريبت على كلمات GO المستقلة
                Dim batches = Regex.Split(script, "^\s*GO\s*$", RegexOptions.Multiline Or RegexOptions.IgnoreCase)

                For Each rawBatch In batches
                    Dim batch = rawBatch.Trim()
                    If Not String.IsNullOrEmpty(batch) Then
                        Using cmd As New SqlCommand(batch, conn)
                            cmd.CommandTimeout = 120
                            Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                        End Using
                    End If
                Next
            End Using
        End Function

        ' ══════════════════════════════════════════════════════════════════════
        ' 2. فحص وترقيع الجداول والأعمدة تلقائياً (Self-Healing Migration)
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>
        ''' تشغيل الفحص والترقيع الشامل لقاعدة البيانات (الجداول + الأعمدة)
        ''' </summary>
        Public Async Function CheckAndRepairDatabaseAsync(Optional progress As IProgress(Of MaintenanceProgress) = Nothing) As Task(Of MaintenanceReport)
            Dim report As New MaintenanceReport()
            Dim sw = Stopwatch.StartNew()

            Try
                report.Log("🚀 بدء عملية الفحص والصيانة الشاملة (Database Self-Healing)...")
                progress?.Report(New MaintenanceProgress(5, "بدء الفحص", "التحقق من وجود قاعدة البيانات..."))

                ' الخطوة 1: التأكد من وجود قاعدة البيانات أولاً
                Dim dbCheckReport = Await EnsureDatabaseExistsAsync(progress).ConfigureAwait(False)
                report.DatabaseCreated = dbCheckReport.DatabaseCreated
                For Each errMsg In dbCheckReport.Errors
                    report.LogError(errMsg)
                Next

                If Not dbCheckReport.IsSuccess AndAlso Not dbCheckReport.DatabaseCreated Then
                    report.LogError("توقف الفحص لتعذر الوصول إلى قاعدة البيانات أو إنشائها.")
                    Return report
                End If

                ' الخطوة 2: فحص وترقيع الجداول الناقصة
                progress?.Report(New MaintenanceProgress(30, "فحص الجداول", "الاستعلام عن جداول النظام ومقارنة الهيكل..."))
                Await CheckAndRepairTablesAsync(report, progress).ConfigureAwait(False)

                ' الخطوة 3: فحص وترقيع الأعمدة الناقصة
                progress?.Report(New MaintenanceProgress(65, "فحص الأعمدة", "فحص أعمدة الجداول وتوليد ترقيعات ALTER TABLE..."))
                Await CheckAndRepairColumnsAsync(report, progress).ConfigureAwait(False)

                ' الخطوة 4: مزامنة البيانات المشتركة وزرع الحساب الافتراضي وتأكيد الجاهزية
                progress?.Report(New MaintenanceProgress(85, "مزامنة البيانات الأساسية", "مزامنة الحقول التوافقية وزرع الحساب الافتراضي..."))
                Await SyncAndSeedEssentialDataAsync(report, progress).ConfigureAwait(False)

                progress?.Report(New MaintenanceProgress(100, "اكتمل الفحص", "تم اكتمال فحص وترقيع قاعدة البيانات بنجاح."))
                report.Log($"🎉 انتهت عملية الصيانة بنجاح. الجداول المنشأة: {report.TablesCreated.Count}، الأعمدة المضافة: {report.ColumnsAdded.Count}.")

            Catch ex As Exception
                report.LogError($"خطأ عام أثناء فحص وصيانة قاعدة البيانات: {ex.Message}", ex)
            Finally
                sw.Stop()
                report.ExecutionTime = sw.Elapsed
                report.Log($"زمن التنفيذ الإجمالي: {report.ExecutionTime.TotalSeconds:F2} ثانية.")
            End Try

            Return report
        End Function

        ''' <summary>
        ''' فحص جداول النظام وإنشاء أي جدول مفقود
        ''' </summary>
        Private Async Function CheckAndRepairTablesAsync(report As MaintenanceReport, progress As IProgress(Of MaintenanceProgress)) As Task
            Dim expectedTables = DatabaseSchemaDefinitions.GetExpectedSchema()
            Dim existingTables As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

            Using conn As New SqlConnection(_connectionString)
                Await conn.OpenAsync().ConfigureAwait(False)

                ' جلب أسماء الجداول الموجودة حالياً من INFORMATION_SCHEMA.TABLES
                Dim query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';"
                Using cmd As New SqlCommand(query, conn)
                    Using reader = Await cmd.ExecuteReaderAsync().ConfigureAwait(False)
                        While Await reader.ReadAsync().ConfigureAwait(False)
                            existingTables.Add(reader.GetString(0))
                        End While
                    End Using
                End Using

                report.Log($"تم العثور على {existingTables.Count} جدول في قاعدة البيانات الحالية.")

                ' مقارنة الجداول المطلوبة وإنشاء المفقود منها
                For Each def In expectedTables
                    Dim exists = existingTables.Contains(def.TableName)

                    If Not exists Then
                        report.Log($"⚠️ الجدول [{def.TableName}] مفقود! جارٍ إنشاؤه كودياً...")
                        Dim createSql = def.ToCreateTableSql()

                        Using createCmd As New SqlCommand(createSql, conn)
                            Await createCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                        End Using

                        existingTables.Add(def.TableName)
                        report.TablesCreated.Add(def.TableName)
                        report.Log($"✅ تم إنشاء الجدول [{def.TableName}] بنجاح.")
                    End If
                Next
            End Using
        End Function

        ''' <summary>
        ''' فحص أعمدة كل جدول وتحديث/إضافة الأعمدة المفقودة دون المساس بالبيانات
        ''' </summary>
        Private Async Function CheckAndRepairColumnsAsync(report As MaintenanceReport, progress As IProgress(Of MaintenanceProgress)) As Task
            Dim expectedTables = DatabaseSchemaDefinitions.GetExpectedSchema()

            Using conn As New SqlConnection(_connectionString)
                Await conn.OpenAsync().ConfigureAwait(False)

                ' جلب خريطة الأعمدة الحالية لكل جدول
                Dim tableColumnsMap As New Dictionary(Of String, HashSet(Of String))(StringComparer.OrdinalIgnoreCase)
                Dim colsQuery = "SELECT TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS;"

                Using cmd As New SqlCommand(colsQuery, conn)
                    Using reader = Await cmd.ExecuteReaderAsync().ConfigureAwait(False)
                        While Await reader.ReadAsync().ConfigureAwait(False)
                            Dim tbl = reader.GetString(0)
                            Dim col = reader.GetString(1)

                            If Not tableColumnsMap.ContainsKey(tbl) Then
                                tableColumnsMap(tbl) = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                            End If
                            tableColumnsMap(tbl).Add(col)
                        End While
                    End Using
                End Using

                ' مقارنة الأعمدة وإصلاح الناقص
                For Each tblDef In expectedTables
                    Dim actualTableName = tblDef.TableName
                    If Not tableColumnsMap.ContainsKey(actualTableName) Then
                        Continue For
                    End If

                    Dim existingCols = tableColumnsMap(actualTableName)

                    For Each colDef In tblDef.Columns
                        If Not existingCols.Contains(colDef.Name) Then
                            report.Log($"⚠️ العمود [{colDef.Name}] مفقود في الجدول [{actualTableName}]! جارٍ توليد وتنفيذ ALTER TABLE ADD...")

                            Dim alterSql = colDef.ToAlterTableAddSql(actualTableName)
                            Using alterCmd As New SqlCommand(alterSql, conn)
                                Await alterCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                            End Using

                            existingCols.Add(colDef.Name)
                            Dim changeRecord = $"{actualTableName}.{colDef.Name} ({colDef.SqlType})"
                            report.ColumnsAdded.Add(changeRecord)
                            report.Log($"✅ تم إضافة العمود [{changeRecord}] بنجاح دون المساس بالبيانات القديمة.")
                        End If
                    Next
                Next
            End Using
        End Function

        ''' <summary>
        ''' مزامنة الحقول التوافقية وزرع البيانات الأولية وحساب المدير الافتراضي
        ''' </summary>
        Private Async Function SyncAndSeedEssentialDataAsync(report As MaintenanceReport, progress As IProgress(Of MaintenanceProgress)) As Task
            report.Log("جارٍ التحقق من الحساب الافتراضي ومزامنة الحقول التوافقية...")

            Using conn As New SqlConnection(_connectionString)
                Await conn.OpenAsync().ConfigureAwait(False)

                ' 1. زرع الدور الأساسي في جدول Roles إن كان فارغاً
                Try
                    Dim seedRoleSql As String = "
                    IF OBJECT_ID('Roles', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Roles)
                    BEGIN
                        INSERT INTO Roles (RoleName, Description, IsActive) 
                        VALUES (N'المدير العام', N'صلاحيات كاملة على كافة أقسام وإعدادات النظام', 1);
                    END"
                    Using cmd As New SqlCommand(seedRoleSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء تهيئة الأدوار: {ex.Message}")
                End Try

                ' 2. زرع المستخدم الافتراضي في Users_TBL إن كان فارغاً
                Try
                    Dim seedUserTblSql As String = "
                    IF OBJECT_ID('Users_TBL', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Users_TBL)
                    BEGIN
                        INSERT INTO Users_TBL (User_Code, User_Name, User_username, User_password, RoleID, IsActive, IsDeleted)
                        VALUES ('1', N'المدير العام', 'admin', '123', 1, 1, 0);
                    END"
                    Using cmd As New SqlCommand(seedUserTblSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء تهيئة جدول Users_TBL: {ex.Message}")
                End Try

                ' 3. زرع المستخدم في جدول Users التوافقي ومزامنته مع Users_TBL
                Try
                    Dim syncUsersSql As String = "
                    IF OBJECT_ID('Users', 'U') IS NOT NULL AND OBJECT_ID('Users_TBL', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM Users) AND EXISTS (SELECT 1 FROM Users_TBL)
                        BEGIN
                            INSERT INTO Users (Username, Password, FullName, RoleID, UserRole, IsActive, CreatedAt)
                            SELECT User_username, User_password, User_Name, RoleID, N'المدير العام', IsActive, GETDATE()
                            FROM Users_TBL;
                        END
                        ELSE IF NOT EXISTS (SELECT 1 FROM Users_TBL) AND EXISTS (SELECT 1 FROM Users)
                        BEGIN
                            INSERT INTO Users_TBL (User_Code, User_Name, User_username, User_password, RoleID, IsActive, IsDeleted)
                            SELECT CAST(UserID AS NVARCHAR(50)), FullName, Username, Password, RoleID, IsActive, 0
                            FROM Users;
                        END
                    END"
                    Using cmd As New SqlCommand(syncUsersSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء مزامنة المستخدمين: {ex.Message}")
                End Try

                ' 4. مزامنة جدول Customers و Customer
                Try
                    Dim syncCustSql As String = "
                    IF OBJECT_ID('Customers', 'U') IS NOT NULL AND OBJECT_ID('Customer', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM Customers) AND EXISTS (SELECT 1 FROM Customer)
                        BEGIN
                            INSERT INTO Customers (CustomerCode, CustomerName, Phone, PhoneNumber, Address, Balance, CurrentBalance, IsActive, IsDeleted)
                            SELECT CustomerCode, CustomerName, Phone, Phone, Address, Balance, Balance, IsActive, 0
                            FROM Customer;
                        END
                        ELSE IF NOT EXISTS (SELECT 1 FROM Customer) AND EXISTS (SELECT 1 FROM Customers)
                        BEGIN
                            INSERT INTO Customer (CustomerCode, CustomerName, Phone, PhoneNumber, Address, Balance, CurrentBalance, IsActive, IsDeleted)
                            SELECT CustomerCode, CustomerName, Phone, COALESCE(PhoneNumber, Phone), Address, Balance, COALESCE(CurrentBalance, Balance), IsActive, 0
                            FROM Customers;
                        END
                    END"
                    Using cmd As New SqlCommand(syncCustSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء مزامنة العملاء: {ex.Message}")
                End Try

                ' 5. مزامنة الأعمدة المترادفة في المنتجات Products
                Try
                    Dim syncProductsSql As String = "
                    IF OBJECT_ID('Products', 'U') IS NOT NULL
                    BEGIN
                        UPDATE Products SET Product_ID = ProductID WHERE Product_ID IS NULL;
                        UPDATE Products SET ProductNameAr = ProductName WHERE ProductNameAr IS NULL AND ProductName IS NOT NULL;
                        UPDATE Products SET ProductName = ProductNameAr WHERE ProductName IS NULL AND ProductNameAr IS NOT NULL;
                        UPDATE Products SET Category_ID = CategoryID WHERE Category_ID IS NULL AND CategoryID IS NOT NULL;
                        UPDATE Products SET CategoryID = Category_ID WHERE CategoryID IS NULL AND Category_ID IS NOT NULL;
                        UPDATE Products SET BasePrice = SalePrice WHERE BasePrice = 0 AND SalePrice > 0;
                    END"
                    Using cmd As New SqlCommand(syncProductsSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء مزامنة المنتجات: {ex.Message}")
                End Try

                ' 6. مزامنة الأعمدة المترادفة في الأقسام Categories
                Try
                    Dim syncCategoriesSql As String = "
                    IF OBJECT_ID('Categories', 'U') IS NOT NULL
                    BEGIN
                        UPDATE Categories SET Category_ID = CategoryID WHERE Category_ID IS NULL;
                        UPDATE Categories SET Category_NameAr = CategoryName WHERE Category_NameAr IS NULL AND CategoryName IS NOT NULL;
                        UPDATE Categories SET Category_Name = CategoryName WHERE Category_Name IS NULL AND CategoryName IS NOT NULL;
                        UPDATE Categories SET CategoryName = Category_NameAr WHERE CategoryName IS NULL AND Category_NameAr IS NOT NULL;
                    END"
                    Using cmd As New SqlCommand(syncCategoriesSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء مزامنة الأقسام: {ex.Message}")
                End Try

                ' 7. مزامنة الأعمدة المترادفة في المصروفات Expenses
                Try
                    Dim syncExpensesSql As String = "
                    IF OBJECT_ID('Expenses', 'U') IS NOT NULL
                    BEGIN
                        UPDATE Expenses SET Expense_ID = ExpenseID WHERE Expense_ID IS NULL;
                        UPDATE Expenses SET Expense_Date = ExpenseDate WHERE Expense_Date IS NULL;
                        UPDATE Expenses SET ExpenseDate = Expense_Date WHERE ExpenseDate IS NULL;
                        UPDATE Expenses SET Category = ExpenseType WHERE Category IS NULL AND ExpenseType IS NOT NULL;
                        UPDATE Expenses SET ExpenseType = Category WHERE ExpenseType IS NULL AND Category IS NOT NULL;
                    END"
                    Using cmd As New SqlCommand(syncExpensesSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء مزامنة المصروفات: {ex.Message}")
                End Try

                ' 8. مزامنة الأعمدة المترادفة في الموردين Suppliers
                Try
                    Dim syncSuppliersSql As String = "
                    IF OBJECT_ID('Suppliers', 'U') IS NOT NULL
                    BEGIN
                        UPDATE Suppliers SET SuppliersID = SupplierID WHERE SuppliersID IS NULL;
                        UPDATE Suppliers SET SuppliersName = SupplierName WHERE SuppliersName IS NULL AND SupplierName IS NOT NULL;
                        UPDATE Suppliers SET SupplierName = SuppliersName WHERE SupplierName IS NULL AND SuppliersName IS NOT NULL;
                        UPDATE Suppliers SET CurrentBalance = Balance WHERE CurrentBalance IS NULL;
                    END"
                    Using cmd As New SqlCommand(syncSuppliersSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء مزامنة الموردين: {ex.Message}")
                End Try

                ' 9. تهيئة خزينة افتراضية إن لم توجد
                Try
                    Dim seedTreasurySql As String = "
                    IF OBJECT_ID('Treasury', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Treasury)
                    BEGIN
                        INSERT INTO Treasury (TreasuryName, Balance, IsDefault, IsActive)
                        VALUES (N'الخزينة الرئيسية', 0, 1, 1);
                    END"
                    Using cmd As New SqlCommand(seedTreasurySql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء تهيئة الخزينة: {ex.Message}")
                End Try

                ' 10. تهيئة مخزن افتراضي إن لم يوجد
                Try
                    Dim seedStoreSql As String = "
                    IF OBJECT_ID('Stores', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Stores)
                    BEGIN
                        INSERT INTO Stores (StoreName, StoreCode, IsActive, IsDeleted)
                        VALUES (N'المخزن الرئيسي', 'WH-1', 1, 0);
                    END"
                    Using cmd As New SqlCommand(seedStoreSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء تهيئة المخزن: {ex.Message}")
                End Try

                ' 11. تهيئة ورديات العمل الافتراضية ومزامنة جدول الورديات WorkShifts & Shifts
                Try
                    Dim syncShiftsSql As String = "
                    -- تهيئة الورديات المرجعية الأساسية إن لم توجد
                    IF OBJECT_ID('WorkShifts', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM WorkShifts WHERE IsDeleted = 0 OR IsDeleted IS NULL)
                    BEGIN
                        INSERT INTO WorkShifts (WorkShiftCode, WorkShiftName, StartTime, EndTime, Notes, IsActive, IsDeleted, CreatedAt)
                        VALUES 
                        ('WS-01', N'وردية صباحية', '08:00:00', '16:00:00', N'وردية العمل الصباحية الأولى', 1, 0, GETDATE()),
                        ('WS-02', N'وردية مسائية', '16:00:00', '00:00:00', N'وردية العمل المسائية الثانية', 1, 0, GETDATE());
                    END

                    -- تصحيح ومزامنة جدول Shifts
                    IF OBJECT_ID('Shifts', 'U') IS NOT NULL
                    BEGIN
                        -- تصحيح نوع بيانات عمود Status إذا كان nvarchar قديماً
                        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Shifts' AND COLUMN_NAME = 'Status' AND DATA_TYPE LIKE '%char%')
                        BEGIN
                            UPDATE Shifts SET Status = '1' WHERE Status IS NULL OR Status = N'مفتوحة' OR Status = 'Open';
                            UPDATE Shifts SET Status = '2' WHERE Status = N'مغلقة' OR Status = 'Closed';
                            UPDATE Shifts SET Status = '3' WHERE Status = N'معلقة';

                            DECLARE @DefConst NVARCHAR(200);
                            SELECT @DefConst = d.name
                            FROM sys.default_constraints d
                            JOIN sys.columns c ON d.parent_column_id = c.column_id AND d.parent_object_id = c.object_id
                            WHERE d.parent_object_id = OBJECT_ID('Shifts') AND c.name = 'Status';

                            IF @DefConst IS NOT NULL
                                EXEC('ALTER TABLE Shifts DROP CONSTRAINT [' + @DefConst + '];');

                            ALTER TABLE Shifts ALTER COLUMN Status INT NOT NULL;
                            ALTER TABLE Shifts ADD CONSTRAINT DF_Shifts_Status DEFAULT 1 FOR Status;
                        END

                        -- مزامنة الحقول التوافقية
                        UPDATE Shifts SET OpenDateTime = StartTime WHERE OpenDateTime IS NULL AND StartTime IS NOT NULL;
                        UPDATE Shifts SET CloseDateTime = EndTime WHERE CloseDateTime IS NULL AND EndTime IS NOT NULL;
                        UPDATE Shifts SET OpeningCash = StartCash WHERE OpeningCash = 0 AND StartCash > 0;
                        UPDATE Shifts SET ClosingCash = EndCash WHERE ClosingCash IS NULL AND EndCash IS NOT NULL;
                        UPDATE Shifts SET ShiftNumber = 'SH-' + CAST(ShiftID AS NVARCHAR(20)) WHERE ShiftNumber IS NULL;
                    END"
                    Using cmd As New SqlCommand(syncShiftsSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء تهيئة ومزامنة الورديات: {ex.Message}")
                End Try

                ' 11b. تهيئة تعليقات وملاحظات المطبخ الافتراضية
                Try
                    Dim seedCommentsSql As String = "
                    IF OBJECT_ID('KitchenComments', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM KitchenComments WHERE IsDeleted = 0 OR IsDeleted IS NULL)
                    BEGIN
                        INSERT INTO KitchenComments (CommentCode, CommentText, IsActive, IsDeleted, CreatedAt) VALUES
                        ('COM-001', N'بدون سكر', 1, 0, GETDATE()),
                        ('COM-002', N'بدون شطة', 1, 0, GETDATE()),
                        ('COM-003', N'شطة زيادة 🔥', 1, 0, GETDATE()),
                        ('COM-004', N'مستوي جيداً (Well Done)', 1, 0, GETDATE()),
                        ('COM-005', N'نصف استواء (Medium)', 1, 0, GETDATE()),
                        ('COM-006', N'بدون بصل', 1, 0, GETDATE()),
                        ('COM-007', N'سفري / خارجي', 1, 0, GETDATE()),
                        ('COM-008', N'سخن جداً ♨️', 1, 0, GETDATE()),
                        ('COM-009', N'صوص جانبي', 1, 0, GETDATE()),
                        ('COM-010', N'بدون ملح', 1, 0, GETDATE()),
                        ('COM-011', N'ملح خفيف', 1, 0, GETDATE()),
                        ('COM-012', N'بدون ثوم', 1, 0, GETDATE()),
                        ('COM-013', N'زيادة كاتشب', 1, 0, GETDATE()),
                        ('COM-014', N'زيادة مايونيز', 1, 0, GETDATE()),
                        ('COM-015', N'بدون طماطم', 1, 0, GETDATE()),
                        ('COM-016', N'خبز محمص زيادة', 1, 0, GETDATE());
                    END"
                    Using cmd As New SqlCommand(seedCommentsSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء تهيئة تعليقات المطبخ: {ex.Message}")
                End Try

                ' 12. تهيئة شاشات النظام ووظائفه في جدول AppScreens
                Try
                    Dim seedScreensSql As String = "
                    IF OBJECT_ID('AppScreens', 'U') IS NOT NULL
                    BEGIN
                        DECLARE @Screens TABLE (FormName NVARCHAR(100), Category NVARCHAR(100), ScreenDisplayName NVARCHAR(200));
                        INSERT INTO @Screens (FormName, Category, ScreenDisplayName) VALUES
                        ('frmPOS', N'المبيعات ونقاط البيع', N'شاشة الكاشير ونقاط البيع (POS)'),
                        ('frmKitchenComments', N'المبيعات ونقاط البيع', N'تعليقات وملاحظات المطبخ'),
                        ('Sales_Returns', N'المبيعات ونقاط البيع', N'مرتجع المبيعات'),
                        ('FrmSalesReport', N'المبيعات ونقاط البيع', N'تقرير المبيعات'),
                        ('FrmHeldInvoices', N'المبيعات ونقاط البيع', N'الفواتير المعلقة والمؤقتة'),
                        ('Products', N'الأصناف والمخزون', N'الأصناف والمنتجات'),
                        ('Categories', N'الأصناف والمخزون', N'الأقسام والتصنيفات'),
                        ('frmProductSizes', N'الأصناف والمخزون', N'أحجام ومقاسات المنتجات'),
                        ('frmProductAddons', N'الأصناف والمخزون', N'إضافات ومكونات المنتجات'),
                        ('frmKitchenComments', N'الأصناف والمخزون', N'تعليقات وملاحظات المطبخ'),
                        ('frmUnits', N'الأصناف والمخزون', N'وحدات القياس'),
                        ('FrmStores', N'الأصناف والمخزون', N'المخازن والمستودعات'),
                        ('frmStoreStock', N'الأصناف والمخزون', N'رصيد وجرد المخازن'),
                        ('frmRawMaterials', N'الأصناف والمخزون', N'المواد الخام'),
                        ('frmRecipes', N'الأصناف والمخزون', N'مكونات وتكاليف الوجبات'),
                        ('FrmKitchenWaste', N'الأصناف والمخزون', N'إدارة الهالك والتالف'),
                        ('FrmKitchenDisplay', N'الأصناف والمخزون', N'شاشة المطبخ (KDS)'),
                        ('frmPurchases', N'المشتريات والموردين', N'فواتير المشتريات'),
                        ('FrmSuppliers', N'المشتريات والموردين', N'إدارة الموردين'),
                        ('FrmSupplierTransactions', N'المشتريات والموردين', N'حركات ومدفوعات الموردين'),
                        ('frmPurchaseReports', N'المشتريات والموردين', N'تقارير المشتريات'),
                        ('FrmCustomers', N'العملاء والتوصيل', N'إدارة العملاء'),
                        ('FrmCustomerStatement', N'العملاء والتوصيل', N'كشف حساب عميل'),
                        ('frmDeliveryDrivers', N'العملاء والتوصيل', N'مناديب وسائقي التوصيل'),
                        ('frmDeliveryAreas', N'العملاء والتوصيل', N'مناطق ورسوم التوصيل'),
                        ('FrmDriverReport', N'العملاء والتوصيل', N'تقرير التوصيل والمناديب'),
                        ('frmRestaurantTables', N'الصالة والطاولات', N'طاولات الصالة'),
                        ('frmRestaurantSections', N'الصالة والطاولات', N'أقسام الصالة'),
                        ('FrmTableReservations', N'الصالة والطاولات', N'حجز الطاولات'),
                        ('frmTreasury', N'الخزينة والمصروفات', N'إدارة الخزائن ونقاط النقدية'),
                        ('FrmTreasuryTransaction', N'الخزينة والمصروفات', N'حركات الإيداع والصرف'),
                        ('FrmTreasuryTransfer', N'الخزينة والمصروفات', N'تحويل بين الخزائن'),
                        ('FrmTreasuryTransactionsReport', N'الخزينة والمصروفات', N'تقرير حركات الخزينة'),
                        ('form_Expenses', N'الخزينة والمصروفات', N'تسجيل المصروفات'),
                        ('ExpensesReportForm', N'الخزينة والمصروفات', N'تقرير المصروفات'),
                        ('frmShifts', N'الخزينة والمصروفات', N'الورديات والشفتات'),
                        ('frmWorkShifts', N'الخزينة والمصروفات', N'أنواع وتوقيتات الورديات'),
                        ('frmUsers', N'الموظفين والمستخدمين والصلاحيات', N'المستخدمين وحسابات الدخول'),
                        ('frmRolesAndPermissions', N'الموظفين والمستخدمين والصلاحيات', N'الأدوار والصلاحيات'),
                        ('frmEmployees', N'الموظفين والمستخدمين والصلاحيات', N'إدارة الموظفين'),
                        ('frmJobTitles', N'الموظفين والمستخدمين والصلاحيات', N'المسميات الوظيفية'),
                        ('frmDepartments', N'الموظفين والمستخدمين والصلاحيات', N'الأقسام الإدارية'),
                        ('frmSalarySystems', N'الموظفين والمستخدمين والصلاحيات', N'أنظمة الرواتب'),
                        ('frmSalaryPayment', N'الموظفين والمستخدمين والصلاحيات', N'صرف الرواتب'),
                        ('Settings', N'الإعدادات والنظام', N'إعدادات النظام العامة'),
                        ('Backup', N'الإعدادات والنظام', N'النسخ الاحتياطي واستعادة البيانات'),
                        ('frmColors', N'الإعدادات والنظام', N'ألوان التصنيفات'),
                        ('frmPrinters', N'الإعدادات والنظام', N'إعدادات الطابعات'),
                        ('frmBranches', N'الإعدادات والنظام', N'الفروع'),
                        ('Reports', N'الإعدادات والنظام', N'التقارير الشاملة');

                        INSERT INTO AppScreens (FormName, Category, ScreenDisplayName)
                        SELECT S.FormName, S.Category, S.ScreenDisplayName
                        FROM @Screens S
                        WHERE NOT EXISTS (SELECT 1 FROM AppScreens A WHERE A.FormName = S.FormName);
                    END"
                    Using cmd As New SqlCommand(seedScreensSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء تهيئة شاشات النظام: {ex.Message}")
                End Try

                ' 12. زرع الصلاحيات الكاملة لمدير النظام (RoleID = 1) على جميع الشاشات
                Try
                    Dim seedAdminPermsSql As String = "
                    IF OBJECT_ID('Permissions', 'U') IS NOT NULL AND OBJECT_ID('AppScreens', 'U') IS NOT NULL
                    BEGIN
                        INSERT INTO Permissions (RoleID, FormName, CanOpen, CanAdd, CanEdit, CanDelete)
                        SELECT 1, S.FormName, 1, 1, 1, 1
                        FROM AppScreens S
                        WHERE NOT EXISTS (SELECT 1 FROM Permissions P WHERE P.RoleID = 1 AND P.FormName = S.FormName);

                        UPDATE Permissions SET CanOpen = 1, CanAdd = 1, CanEdit = 1, CanDelete = 1 WHERE RoleID = 1;
                    END"
                    Using cmd As New SqlCommand(seedAdminPermsSql, conn)
                        Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                    End Using
                Catch ex As Exception
                    report.Log($"تنبيه أثناء تهيئة صلاحيات مدير النظام: {ex.Message}")
                End Try

                report.Log("✅ تمت مزامنة الحقول التوافقية وتأكيد الحساب الافتراضي والصلاحيات بنجاح.")
            End Using
        End Function

        ' ══════════════════════════════════════════════════════════════════════
        ' 3. تهيئة الجداول وتفريغها وتصفير العداد (Reset & Reseed)
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>
        ''' تفريغ جدول معين بأمان تام، مع حل قيود المفاتيح الأجنبية المرتبطة به تلقائياً وتصفير العداد التلقائي
        ''' </summary>
        Public Async Function ResetTableDataAsync(tableName As String) As Task(Of Boolean)
            Using conn As New SqlConnection(_connectionString)
                Await conn.OpenAsync().ConfigureAwait(False)

                Using trans = conn.BeginTransaction()
                    Try
                        ' 1) التحقق من وجود الجدول
                        Dim chkCmd As New SqlCommand("SELECT OBJECT_ID(@tbl, 'U');", conn, trans)
                        chkCmd.Parameters.AddWithValue("@tbl", tableName)
                        Dim tblObjId = Await chkCmd.ExecuteScalarAsync().ConfigureAwait(False)
                        If tblObjId Is Nothing OrElse Convert.IsDBNull(tblObjId) Then
                            Throw New InvalidOperationException($"الجدول [{tableName}] غير موجود في قاعدة البيانات.")
                        End If

                        ' 2) استعلام كافة المفاتيح الأجنبية التي تشير لهذا الجدول أو تشير لنفس الجدول
                        Dim getFksSql = "
                        SELECT 
                            fk.name AS ConstraintName,
                            OBJECT_SCHEMA_NAME(fk.parent_object_id) AS ReferencingSchema,
                            OBJECT_NAME(fk.parent_object_id) AS ReferencingTable,
                            COL_NAME(fkc.parent_object_id, fkc.parent_column_id) AS ReferencingColumn,
                            OBJECT_SCHEMA_NAME(fk.referenced_object_id) AS ReferencedSchema,
                            OBJECT_NAME(fk.referenced_object_id) AS ReferencedTable,
                            COL_NAME(fkc.referenced_object_id, fkc.referenced_column_id) AS ReferencedColumn,
                            c.is_nullable AS IsNullable
                        FROM sys.foreign_keys fk
                        JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
                        JOIN sys.columns c ON c.object_id = fkc.parent_object_id AND c.column_id = fkc.parent_column_id
                        WHERE fk.referenced_object_id = OBJECT_ID(@tbl)
                           OR (fk.parent_object_id = OBJECT_ID(@tbl) AND fk.referenced_object_id = OBJECT_ID(@tbl));"

                        Dim droppedFks As New List(Of (ConstraintName As String, RefSchema As String, RefTable As String, RefCol As String, TargetSchema As String, TargetTable As String, TargetCol As String, IsNullable As Boolean))()

                        Using getFksCmd As New SqlCommand(getFksSql, conn, trans)
                            getFksCmd.Parameters.AddWithValue("@tbl", tableName)
                            Using rdr = Await getFksCmd.ExecuteReaderAsync().ConfigureAwait(False)
                                While Await rdr.ReadAsync().ConfigureAwait(False)
                                    droppedFks.Add((
                                        rdr("ConstraintName").ToString(),
                                        rdr("ReferencingSchema").ToString(),
                                        rdr("ReferencingTable").ToString(),
                                        rdr("ReferencingColumn").ToString(),
                                        rdr("ReferencedSchema").ToString(),
                                        rdr("ReferencedTable").ToString(),
                                        rdr("ReferencedColumn").ToString(),
                                        Convert.ToBoolean(rdr("IsNullable"))
                                    ))
                                End While
                            End Using
                        End Using

                        ' 3) إسقاط قيود المفاتيح الأجنبية المرتبطة مؤقتاً للسماح بالحذف دون أي تعارض
                        For Each fk In droppedFks
                            Dim dropSql = $"ALTER TABLE [{fk.RefSchema}].[{fk.RefTable}] DROP CONSTRAINT [{fk.ConstraintName}];"
                            Using dropCmd As New SqlCommand(dropSql, conn, trans)
                                Await dropCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                            End Using
                        Next

                        ' 4) معالجة السجلات في الجداول المرتبطة:
                        ' إذا كان الحقل في الجدول المرتبط يقبل NULL نقوم بضبطه على NULL لمنع تعليق العلاقات.
                        ' إذا كان لا يقبل NULL (جداول تفاصيل وأبناء)، نقوم بحذف السجلات التابعة لتفادي وجود بيانات يتيمة مكسورة.
                        For Each fk In droppedFks
                            If Not fk.RefTable.Equals(tableName, StringComparison.OrdinalIgnoreCase) Then
                                If fk.IsNullable Then
                                    Dim nullifySql = $"UPDATE [{fk.RefSchema}].[{fk.RefTable}] SET [{fk.RefCol}] = NULL WHERE [{fk.RefCol}] IS NOT NULL;"
                                    Using nullifyCmd As New SqlCommand(nullifySql, conn, trans)
                                        Await nullifyCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                                    End Using
                                Else
                                    Dim cleanChildSql = $"DELETE FROM [{fk.RefSchema}].[{fk.RefTable}];"
                                    Using cleanChildCmd As New SqlCommand(cleanChildSql, conn, trans)
                                        Await cleanChildCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                                    End Using
                                End If
                            End If
                        Next

                        ' 5) تعطيل القيود الداخلية للجدول نفسه
                        Dim disableFkCmd As New SqlCommand($"ALTER TABLE [{tableName}] NOCHECK CONSTRAINT ALL;", conn, trans)
                        Await disableFkCmd.ExecuteNonQueryAsync().ConfigureAwait(False)

                        ' 6) تفريغ أي علاقات ذاتية (Self-referencing) إن وُجدت
                        For Each fk In droppedFks
                            If fk.RefTable.Equals(tableName, StringComparison.OrdinalIgnoreCase) AndAlso fk.IsNullable Then
                                Dim selfNullSql = $"UPDATE [{tableName}] SET [{fk.RefCol}] = NULL WHERE [{fk.RefCol}] IS NOT NULL;"
                                Using selfNullCmd As New SqlCommand(selfNullSql, conn, trans)
                                    Await selfNullCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                                End Using
                            End If
                        Next

                        ' 7) حذف بيانات الجدول الأساسي المطلوب تهيئته
                        Dim deleteCmd As New SqlCommand($"DELETE FROM [{tableName}];", conn, trans)
                        deleteCmd.CommandTimeout = 180
                        Await deleteCmd.ExecuteNonQueryAsync().ConfigureAwait(False)

                        ' 8) تصفير عداد الترقيم التلقائي (Identity Reseed)
                        Dim hasIdentityCmd As New SqlCommand("SELECT OBJECTPROPERTY(OBJECT_ID(@tbl), 'TableHasIdentity');", conn, trans)
                        hasIdentityCmd.Parameters.AddWithValue("@tbl", tableName)
                        Dim hasIdentity = Convert.ToInt32(Await hasIdentityCmd.ExecuteScalarAsync().ConfigureAwait(False))

                        If hasIdentity = 1 Then
                            Dim reseedCmd As New SqlCommand($"DBCC CHECKIDENT ('{tableName}', RESEED, 0);", conn, trans)
                            Await reseedCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                        End If

                        ' 9) إعادة إنشاء كافة المفاتيح الأجنبية التي تم إسقاطها باستخدام WITH NOCHECK لضمان النجاح التام 100%
                        For Each fk In droppedFks
                            Dim recreateSql = $"ALTER TABLE [{fk.RefSchema}].[{fk.RefTable}] WITH NOCHECK ADD CONSTRAINT [{fk.ConstraintName}] FOREIGN KEY ([{fk.RefCol}]) REFERENCES [{fk.TargetSchema}].[{fk.TargetTable}] ([{fk.TargetCol}]);"
                            Using recreateCmd As New SqlCommand(recreateSql, conn, trans)
                                Await recreateCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                            End Using
                        Next

                        ' 10) إعادة تفعيل القيود على الجدول الأساسي
                        Dim enableFkCmd As New SqlCommand($"ALTER TABLE [{tableName}] CHECK CONSTRAINT ALL;", conn, trans)
                        Await enableFkCmd.ExecuteNonQueryAsync().ConfigureAwait(False)

                        trans.Commit()
                        Return True
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        ''' <summary>
        ''' تفريغ كافة جداول المعاملات الحركية فقط (Sales, Purchases, Shifts, Expenses, TreasuryTransactions)
        ''' مع الحفاظ التام على البيانات الأساسية (العملاء، الموردين، الأصناف، المستخدمين، الإعدادات)
        ''' </summary>
        Public Async Function ResetTransactionalDataAsync(Optional progress As IProgress(Of MaintenanceProgress) = Nothing) As Task(Of MaintenanceReport)
            Dim report As New MaintenanceReport()
            Dim sw = Stopwatch.StartNew()

            ' ترتيب الحذف المنطقي: الجداول الفرعية والتفاصيل أولاً ثم الجداول الرئيسية
            Dim transactionalTables = New String() {
                "KitchenOrderDetails",
                "KitchenWasteDetails",
                "KitchenWaste",
                "KitchenOrders",
                "TableReservations",
                "DriverTransactions",
                "CustomerTransactions",
                "CustomerBalanceLog",
                "SalaryPayments",
                "StockTransactions",
                "StockMovements",
                "SalesInvoiceDetails",
                "PurchaseDetails",
                "SalesDetails",
                "TreasuryTransactions",
                "SupplierTransactions",
                "PendingInvoices",
                "Expenses",
                "SalesInvoices",
                "Sales",
                "SalesHeader",
                "PurchaseHeaders",
                "Shifts"
            }

            Try
                report.Log("⚠️ بدء عملية تفريغ وتهيئة جداول المعاملات والحركات الدورية...")
                progress?.Report(New MaintenanceProgress(10, "بدء التهيئة", "جارٍ إفراغ جداول المعاملات وتصفير العدادات..."))

                Dim total = transactionalTables.Length
                Dim current = 0

                For Each tbl In transactionalTables
                    current += 1
                    Dim percent = CInt((current / total) * 90)
                    progress?.Report(New MaintenanceProgress(percent, $"تفريغ {tbl}", $"جارٍ تفريغ جدول [{tbl}] وتصفير عداده..."))

                    Try
                        Dim done = Await ResetTableDataAsync(tbl).ConfigureAwait(False)
                        If done Then
                            report.Log($"✅ تم إفراغ جدول [{tbl}] وتصفير عداد الترقيم التلقائي بنجاح.")
                        End If
                    Catch ex As Exception
                        ' لو الجدول غير موجود أو حدث استثناء، نسجله ونكمل بقية الجداول
                        report.LogError($"تعذر تفريغ الجدول [{tbl}]: {ex.Message}")
                    End Try
                Next

                progress?.Report(New MaintenanceProgress(100, "اكتملت التهيئة", "تم تفريغ كافة جداول المعاملات وتصفير العدادات بنجاح."))
                report.Log("🎉 اكتملت عملية تصفير حركات المبيعات والمشتريات والخزينة والشفتات بنجاح.")

            Catch ex As Exception
                report.LogError($"خطأ عام في عملية التهيئة الشاملة: {ex.Message}", ex)
            Finally
                sw.Stop()
                report.ExecutionTime = sw.Elapsed
            End Try

            Return report
        End Function

        ' ══════════════════════════════════════════════════════════════════════
        ' 4. إحصائيات الجداول (Table Statistics)
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>
        ''' جلب معلومات وإحصائيات كافة جداول النظام وعدد سجلات كل جدول
        ''' </summary>
        Public Async Function GetTableStatisticsAsync() As Task(Of List(Of TableInfo))
            Dim result As New List(Of TableInfo)()
            Dim expected = DatabaseSchemaDefinitions.GetExpectedSchema()

            Using conn As New SqlConnection(_connectionString)
                Await conn.OpenAsync().ConfigureAwait(False)

                ' جلب عدد السجلات السريع من sys.dm_db_partition_stats أو COUNT_BIG
                For Each def In expected
                    Dim actualName = def.TableName

                    ' التحقق من وجود الجدول
                    Dim chkCmd As New SqlCommand("SELECT OBJECT_ID(@n, 'U');", conn)
                    chkCmd.Parameters.AddWithValue("@n", actualName)
                    Dim objId = Await chkCmd.ExecuteScalarAsync().ConfigureAwait(False)

                    Dim info As New TableInfo With {
                        .TableName = actualName,
                        .DisplayNameAr = def.DisplayNameAr,
                        .DisplayNameEn = def.DisplayNameEn,
                        .IsTransactional = def.IsTransactional,
                        .ExistsInDb = (objId IsNot Nothing AndAlso Not Convert.IsDBNull(objId)),
                        .RecordCount = 0
                    }

                    If info.ExistsInDb Then
                        Try
                            Dim countCmd As New SqlCommand($"SELECT COUNT_BIG(*) FROM [{actualName}];", conn)
                            countCmd.CommandTimeout = 30
                            Dim countResult = Await countCmd.ExecuteScalarAsync().ConfigureAwait(False)
                            If countResult IsNot Nothing AndAlso Not Convert.IsDBNull(countResult) Then
                                info.RecordCount = Convert.ToInt64(countResult)
                            End If
                        Catch
                            info.RecordCount = 0
                        End Try
                    End If

                    result.Add(info)
                Next
            End Using

            Return result
        End Function

    End Class

End Namespace
