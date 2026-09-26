Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Threading.Tasks

Namespace Services.Cloud

    ''' <summary>
    ''' المحرك المركزي للمزامنة السحابية (Central Cloud Sync Orchestrator)
    ''' يدير عمليات المزامنة المجدولة والتلقائية واليدوية مع السحابة Turso
    ''' </summary>
    Public Class CloudSyncService
        Private Shared ReadOnly _lockObj As New Object()
        Private Shared _instance As CloudSyncService

        Public Shared ReadOnly Property Instance As CloudSyncService
            Get
                If _instance Is Nothing Then
                    SyncLock _lockObj
                        If _instance Is Nothing Then
                            _instance = New CloudSyncService()
                        End If
                    End SyncLock
                End If
                Return _instance
            End Get
        End Property

        Private _syncTimer As Timer
        Private _isSyncing As Integer = 0 ' 0 = idle, 1 = running
        Private _isInitialized As Boolean = False
        Private _schemaEnsured As Boolean = False

        ' Events
        Public Event SyncStarted As EventHandler
        Public Event SyncCompleted As EventHandler(Of SyncResult)
        Public Event SyncProgress As EventHandler(Of SyncProgressEventArgs)
        Public Event SyncError As EventHandler(Of Exception)

        Public Property CurrentStatus As SyncStatus = SyncStatus.Idle
        Public Property LastResult As SyncResult

        Private Sub New()
        End Sub

        ''' <summary>
        ''' تهيئة خدمة المزامنة وتجهيز قواعد البيانات المحلية والتريجرات
        ''' </summary>
        Public Async Function InitializeAsync() As Task(Of Boolean)
            If _isInitialized Then Return True

            Try
                ' 1. التأكد من وجود أعمدة المزامنة في الجداول المحلية
                Await EnsureSyncColumnsAsync().ConfigureAwait(False)

                ' 2. التأكد من وجود تريجرات التتبع
                Await EnsureTriggersAsync().ConfigureAwait(False)

                ' 3. بدء المؤقت التلقائي إذا كانت المزامنة مفعلة
                Dim config = CloudSyncConfig.Load()
                If config IsNot Nothing AndAlso config.IsSyncEnabled Then
                    StartBackgroundSync()
                End If

                _isInitialized = True
                Return True
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"CloudSyncService Initialize Error: {ex.Message}")
                Return False
            End Try
        End Function

        ''' <summary>
        ''' التأكد من وجود أعمدة المزامنة (sync_id, updated_at, is_deleted, device_id)
        ''' في كافة الجداول القابلة للمزامنة محلياً
        ''' </summary>
        Public Async Function EnsureSyncColumnsAsync() As Task
            Try
                Using conn As SqlConnection = DBModule.NewConn()
                    If conn Is Nothing Then Return
                    If conn.State <> ConnectionState.Open Then Await conn.OpenAsync().ConfigureAwait(False)

                    Dim tables = SyncableTableRegistry.GetSyncableTables()

                    For Each table In tables
                        Dim tableName = table.TableName

                        Dim checkSql = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName AND COLUMN_NAME IN ('sync_id', 'updated_at', 'is_deleted', 'device_id')"
                        Dim existingCols As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

                        Using cmdCheck As New SqlCommand(checkSql, conn)
                            cmdCheck.Parameters.AddWithValue("@TableName", tableName)
                            Using reader = Await cmdCheck.ExecuteReaderAsync().ConfigureAwait(False)
                                While Await reader.ReadAsync().ConfigureAwait(False)
                                    existingCols.Add(Convert.ToString(reader("COLUMN_NAME")))
                                End While
                            End Using
                        End Using

                        Dim alterSqls As New List(Of String)()

                        If Not existingCols.Contains("sync_id") Then
                            alterSqls.Add($"ALTER TABLE [{tableName}] ADD [sync_id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID();")
                        End If
                        If Not existingCols.Contains("updated_at") Then
                            alterSqls.Add($"ALTER TABLE [{tableName}] ADD [updated_at] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME();")
                        End If
                        If Not existingCols.Contains("is_deleted") Then
                            alterSqls.Add($"ALTER TABLE [{tableName}] ADD [is_deleted] BIT NOT NULL DEFAULT 0;")
                        End If
                        If Not existingCols.Contains("device_id") Then
                            alterSqls.Add($"ALTER TABLE [{tableName}] ADD [device_id] NVARCHAR(64) NULL;")
                        End If

                        For Each alterSql In alterSqls
                            Try
                                Using cmdAlter As New SqlCommand(alterSql, conn)
                                    Await cmdAlter.ExecuteNonQueryAsync().ConfigureAwait(False)
                                End Using
                            Catch ex As Exception
                                System.Diagnostics.Debug.WriteLine($"Error adding column to {tableName}: {ex.Message}")
                            End Try
                        Next
                    Next
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"EnsureSyncColumnsAsync Error: {ex.Message}")
            End Try
        End Function

        ''' <summary>
        ''' إنشاء أو تحديث تريجرات التتبع التلقائي للتغييرات على الجداول المزامنة
        ''' </summary>
        Public Async Function EnsureTriggersAsync() As Task
            Try
                Using conn As SqlConnection = DBModule.NewConn()
                    If conn Is Nothing Then Return
                    If conn.State <> ConnectionState.Open Then Await conn.OpenAsync().ConfigureAwait(False)

                    Dim tables = SyncableTableRegistry.GetSyncableTables()

                    For Each table In tables
                        Dim tableName = table.TableName
                        Dim triggerName = $"TR_{tableName}_SyncTrack"

                        Dim triggerSql = $"IF OBJECT_ID('dbo.[{triggerName}]', 'TR') IS NOT NULL DROP TRIGGER [dbo].[{triggerName}];"
                        Using cmdDrop As New SqlCommand(triggerSql, conn)
                            Await cmdDrop.ExecuteNonQueryAsync().ConfigureAwait(False)
                        End Using

                        Dim createTriggerSql =
                            $"CREATE TRIGGER [dbo].[{triggerName}] " &
                            $"ON [dbo].[{tableName}] " &
                            $"AFTER INSERT, UPDATE, DELETE " &
                            $"AS " &
                            $"BEGIN " &
                            $"    SET NOCOUNT ON; " &
                            $"    IF CONTEXT_INFO() = 0x53594E43000000000000000000000000 RETURN; " &
                            $"    IF EXISTS (SELECT 1 FROM inserted) " &
                            $"    BEGIN " &
                            $"        DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM deleted) THEN 'U' ELSE 'I' END; " &
                            $"        INSERT INTO [dbo].[_SyncLog] ([TableName], [RowSyncId], [Operation], [CreatedAt], [IsSynced], [RetryCount]) " &
                            $"        SELECT '{tableName}', i.[sync_id], @op, SYSUTCDATETIME(), 0, 0 " &
                            $"        FROM inserted i " &
                            $"        WHERE i.[sync_id] IS NOT NULL; " &
                            $"    END " &
                            $"    ELSE IF EXISTS (SELECT 1 FROM deleted) " &
                            $"    BEGIN " &
                            $"        INSERT INTO [dbo].[_SyncLog] ([TableName], [RowSyncId], [Operation], [CreatedAt], [IsSynced], [RetryCount]) " &
                            $"        SELECT '{tableName}', d.[sync_id], 'D', SYSUTCDATETIME(), 0, 0 " &
                            $"        FROM deleted d " &
                            $"        WHERE d.[sync_id] IS NOT NULL; " &
                            $"    END " &
                            $"END;"

                        Try
                            Using cmdCreate As New SqlCommand(createTriggerSql, conn)
                                Await cmdCreate.ExecuteNonQueryAsync().ConfigureAwait(False)
                            End Using
                        Catch ex As Exception
                            System.Diagnostics.Debug.WriteLine($"Error creating trigger for {tableName}: {ex.Message}")
                        End Try
                    Next
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"EnsureTriggersAsync Error: {ex.Message}")
            End Try
        End Function

        ''' <summary>
        ''' تشغيل دورة مزامنة كاملة (Push ثم Pull)
        ''' </summary>
        Public Async Function TriggerSyncAsync() As Task(Of SyncResult)
            ' منع تشغيل مزامنتين في نفس الوقت
            If Interlocked.CompareExchange(_isSyncing, 1, 0) <> 0 Then
                Return SyncResult.CreateFailed("المزامنة قيد التشغيل بالفعل.")
            End If

            Dim startTime = DateTime.Now
            CurrentStatus = SyncStatus.Syncing
            RaiseEvent SyncStarted(Me, EventArgs.Empty)

            Try
                ' 1. التحقق من الاتصال بالإنترنت
                Dim isOnline = Await NetworkMonitor.IsOnlineAsync().ConfigureAwait(False)
                If Not isOnline Then
                    CurrentStatus = SyncStatus.Offline
                    Dim offResult = SyncResult.CreateFailed("لا يوجد اتصال بالإنترنت.")
                    RaiseEvent SyncCompleted(Me, offResult)
                    Return offResult
                End If

                ' 2. التحقق من الإعدادات
                Dim config = CloudSyncConfig.Load()
                If config Is Nothing OrElse Not CloudSyncConfig.IsConfigured() Then
                    CurrentStatus = SyncStatus.Failed
                    Dim noCfgResult = SyncResult.CreateFailed("إعدادات المزامنة السحابية غير مكتملة.")
                    RaiseEvent SyncCompleted(Me, noCfgResult)
                    Return noCfgResult
                End If

                Using client As New TursoHttpClient(config.TursoUrl, config.AuthToken)
                    ' 3. التأكد من هيكل الجداول في السحابة مرة واحدة على الأقل
                    If Not _schemaEnsured Then
                        Dim schemaBuilder As New TursoSchemaBuilder()
                        Await schemaBuilder.EnsureRemoteSchemaAsync(client).ConfigureAwait(False)
                        _schemaEnsured = True
                    End If

                    ' 4. رفع التغييرات المحلية إلى السحابة (Push)
                    Dim pushHandler As New SyncPushHandler(client, config.DeviceId)
                    Dim pushProgress = New Progress(Of SyncProgressEventArgs)(Sub(e) RaiseEvent SyncProgress(Me, e))
                    Dim pushResult = Await pushHandler.PushPendingChangesAsync(progress:=pushProgress).ConfigureAwait(False)

                    ' 5. جلب التغييرات من السحابة إلى المحلي (Pull)
                    Dim pullHandler As New SyncPullHandler(client, config.DeviceId)
                    Dim pullProgress = New Progress(Of SyncProgressEventArgs)(Sub(e) RaiseEvent SyncProgress(Me, e))
                    Dim pullResult = Await pullHandler.PullChangesAsync(progress:=pullProgress).ConfigureAwait(False)

                    ' 6. تجميع النتيجة النهائية
                    Dim totalPushed = pushResult.TotalPushed
                    Dim totalPulled = pullResult.TotalPulled
                    Dim totalConflicts = pullResult.TotalConflicts

                    Dim combinedResult = SyncResult.CreateSuccess(totalPushed, totalPulled, totalConflicts)
                    combinedResult.StartedAt = startTime
                    combinedResult.CompletedAt = DateTime.Now

                    If pushResult.Status = SyncStatus.Failed OrElse pullResult.Status = SyncStatus.Failed Then
                        combinedResult.Status = SyncStatus.PartialSuccess
                        combinedResult.Errors.AddRange(pushResult.Errors)
                        combinedResult.Errors.AddRange(pullResult.Errors)
                    End If

                    CurrentStatus = combinedResult.Status
                    LastResult = combinedResult

                    ' تحديث وقت آخر مزامنة في الإعدادات
                    config.LastSyncUtc = DateTime.UtcNow.ToString("o")
                    CloudSyncConfig.Save(config)

                    RaiseEvent SyncCompleted(Me, combinedResult)
                    Return combinedResult
                End Using

            Catch ex As Exception
                CurrentStatus = SyncStatus.Failed
                Dim errResult = SyncResult.CreateFailed($"حدث خطأ أثناء المزامنة: {ex.Message}")
                errResult.StartedAt = startTime
                errResult.CompletedAt = DateTime.Now
                LastResult = errResult

                RaiseEvent SyncError(Me, ex)
                RaiseEvent SyncCompleted(Me, errResult)
                Return errResult

            Finally
                Interlocked.Exchange(_isSyncing, 0)
            End Try
        End Function

        ''' <summary>
        ''' بدء المزامنة الخلفية المجدولة
        ''' </summary>
        Public Sub StartBackgroundSync()
            StopBackgroundSync()

            Dim config = CloudSyncConfig.Load()
            Dim intervalSeconds = If(config IsNot Nothing AndAlso config.SyncIntervalSeconds >= 5, config.SyncIntervalSeconds, 30)

            _syncTimer = New Timer(Async Sub(state)
                                       Try
                                           Await TriggerSyncAsync().ConfigureAwait(False)
                                       Catch
                                       End Try
                                   End Sub, Nothing, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(intervalSeconds))
        End Sub

        ''' <summary>
        ''' إيقاف المزامنة الخلفية
        ''' </summary>
        Public Sub StopBackgroundSync()
            If _syncTimer IsNot Nothing Then
                _syncTimer.Dispose()
                _syncTimer = Nothing
            End If
        End Sub

    End Class
End Namespace
