Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Services.Cloud

    ''' <summary>
    ''' فئة مسؤولة عن دفع التغييرات المحلية من SQL Server إلى السحابة Turso
    ''' </summary>
    Public Class SyncPushHandler
        Private ReadOnly _client As TursoHttpClient
        Private ReadOnly _deviceId As String

        Public Sub New(client As TursoHttpClient, deviceId As String)
            _client = client
            _deviceId = If(String.IsNullOrEmpty(deviceId), "UNKNOWN_DEV", deviceId)
        End Sub

        ''' <summary>
        ''' دفع التغييرات المعلقة إلى السحابة (مع تكرار الدفعات حتى إفراغ السجل وتحديث أجهزة المنشأة)
        ''' </summary>
        Public Async Function PushPendingChangesAsync(Optional batchSize As Integer = 50, Optional progress As IProgress(Of SyncProgressEventArgs) = Nothing) As Task(Of SyncResult)
            Dim startTime = DateTime.Now
            Dim totalPushed As Integer = 0
            Dim maxBatches As Integer = 20
            Dim currentBatch As Integer = 0

            Try
                Using conn As SqlConnection = DBModule.NewConn()
                    If conn Is Nothing Then Return SyncResult.CreateFailed("تعذر الاتصال بقاعدة البيانات المحلية.")
                    If conn.State <> ConnectionState.Open Then Await conn.OpenAsync().ConfigureAwait(False)

                    While currentBatch < maxBatches
                        currentBatch += 1

                        ' جلب التغييرات غير المتزامنة من سجل المزامنة (باستثناء الصلاحيات)
                        Dim getLogQuery = "SELECT TOP (@BatchSize) LogId, TableName, RowSyncId, Operation, ChangedColumns, RowDataJson, CreatedAt " &
                                          "FROM _SyncLog WHERE IsSynced = 0 AND RetryCount < 5 AND TableName <> 'Permissions' ORDER BY LogId ASC"
                        Dim dtLogs As New DataTable()

                        Using cmd As New SqlCommand(getLogQuery, conn)
                            cmd.Parameters.AddWithValue("@BatchSize", batchSize)
                            Using reader = Await cmd.ExecuteReaderAsync().ConfigureAwait(False)
                                dtLogs.Load(reader)
                            End Using
                        End Using

                        If dtLogs.Rows.Count = 0 Then Exit While

                        ' تحضير قائمة العمليات للسحابة
                        Dim batchOperations As New List(Of Tuple(Of String, Object()))()
                        Dim successfulLogIds As New List(Of Long)()
                        Dim tablePushedCounts As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)

                        For Each row As DataRow In dtLogs.Rows
                            Dim logId As Long = Convert.ToInt64(row("LogId"))
                            Dim tableName As String = Convert.ToString(row("TableName"))
                            Dim syncId As Guid = DirectCast(row("RowSyncId"), Guid)
                            Dim operation As String = Convert.ToString(row("Operation")).ToUpper()
                            Dim createdAt As DateTime = Convert.ToDateTime(row("CreatedAt"))

                            If operation = "I" OrElse operation = "U" Then
                                Dim rowValues As New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)

                                ' قراءة بيانات السجل الحالية إذا كانت مخزنة كـ JSON
                                Dim rowDataJson As String = If(row.IsNull("RowDataJson"), Nothing, Convert.ToString(row("RowDataJson")))
                                If Not String.IsNullOrEmpty(rowDataJson) Then
                                    Try
                                        Dim parsed = JObject.Parse(rowDataJson)
                                        For Each prop In parsed.Properties()
                                            rowValues(prop.Name) = prop.Value?.ToObject(Of Object)()
                                        Next
                                    Catch
                                    End Try
                                End If

                                ' قراءة الصف مباشرة من الجدول المحلي إن لم تكن متوفرة
                                If rowValues.Count = 0 Then
                                    Try
                                        Using cmdFetch As New SqlCommand($"SELECT TOP 1 * FROM [{tableName}] WHERE sync_id = @sid", conn)
                                            cmdFetch.Parameters.AddWithValue("@sid", syncId)
                                            Using reader = Await cmdFetch.ExecuteReaderAsync().ConfigureAwait(False)
                                                If Await reader.ReadAsync().ConfigureAwait(False) Then
                                                    For i = 0 To reader.FieldCount - 1
                                                        Dim colName = reader.GetName(i)
                                                        Dim val = reader.GetValue(i)
                                                        rowValues(colName) = If(val Is DBNull.Value, Nothing, val)
                                                    Next
                                                End If
                                            End Using
                                        End Using
                                    Catch
                                    End Try
                                End If

                                If rowValues.Count > 0 Then
                                    rowValues("sync_id") = syncId.ToString()
                                    rowValues("updated_at") = createdAt.ToString("o")
                                    rowValues("device_id") = _deviceId
                                    rowValues("is_deleted") = 0

                                    Dim columns = rowValues.Keys.ToList()
                                    Dim placeholders = columns.Select(Function(c) "?").ToList()
                                    Dim values = columns.Select(Function(c) rowValues(c)).ToArray()

                                    Dim sql = $"INSERT OR REPLACE INTO [{tableName}] ({String.Join(", ", columns.Select(Function(c) $"[{c}]"))}) VALUES ({String.Join(", ", placeholders)});"
                                    batchOperations.Add(New Tuple(Of String, Object())(sql, values))
                                    successfulLogIds.Add(logId)
                                    tablePushedCounts(tableName) = If(tablePushedCounts.ContainsKey(tableName), tablePushedCounts(tableName) + 1, 1)
                                Else
                                    ' الصف حذف محلياً بالفعل، ندفع حذف منطقي للسحابة
                                    Dim sql = $"UPDATE [{tableName}] SET is_deleted = 1, updated_at = ?, device_id = ? WHERE sync_id = ?;"
                                    Dim values As Object() = {createdAt.ToString("o"), _deviceId, syncId.ToString()}
                                    batchOperations.Add(New Tuple(Of String, Object())(sql, values))
                                    successfulLogIds.Add(logId)
                                    tablePushedCounts(tableName) = If(tablePushedCounts.ContainsKey(tableName), tablePushedCounts(tableName) + 1, 1)
                                End If

                            ElseIf operation = "D" Then
                                Dim sql = $"UPDATE [{tableName}] SET is_deleted = 1, updated_at = ?, device_id = ? WHERE sync_id = ?;"
                                Dim values As Object() = {createdAt.ToString("o"), _deviceId, syncId.ToString()}
                                batchOperations.Add(New Tuple(Of String, Object())(sql, values))
                                successfulLogIds.Add(logId)
                                tablePushedCounts(tableName) = If(tablePushedCounts.ContainsKey(tableName), tablePushedCounts(tableName) + 1, 1)
                            End If
                        Next

                        ' تنفيذ الدفعة على السحابة
                        If batchOperations.Count > 0 Then
                            Dim isBatchSuccess As Boolean = False
                            Dim batchEx As Exception = Nothing

                            Try
                                isBatchSuccess = Await _client.ExecuteTransactionAsync(batchOperations).ConfigureAwait(False)
                            Catch ex As Exception
                                batchEx = ex
                            End Try

                            If batchEx IsNot Nothing OrElse Not isBatchSuccess Then
                                If successfulLogIds.Count > 0 Then
                                    Dim logIdsStr = String.Join(",", successfulLogIds)
                                    Dim errMsg = If(batchEx IsNot Nothing, batchEx.Message, "فشل تنفيذ معاملة المزامنة على خادم Turso.")
                                    Dim failSql = $"UPDATE _SyncLog SET RetryCount = RetryCount + 1, ErrorMessage = @Err WHERE LogId IN ({logIdsStr})"
                                    Using cmdFail As New SqlCommand(failSql, conn)
                                        cmdFail.Parameters.AddWithValue("@Err", errMsg)
                                        Await cmdFail.ExecuteNonQueryAsync().ConfigureAwait(False)
                                    End Using
                                End If

                                If batchEx IsNot Nothing Then Throw batchEx
                                Return SyncResult.CreateFailed("فشل تنفيذ معاملة المزامنة على خادم Turso.")
                            End If

                            ' تحديث حالة السجل محلياً عند النجاح
                            If successfulLogIds.Count > 0 Then
                                Dim logIdsStr = String.Join(",", successfulLogIds)
                                Dim updateLogSql = $"UPDATE _SyncLog SET IsSynced = 1, SyncedAt = SYSUTCDATETIME() WHERE LogId IN ({logIdsStr})"
                                Using cmdUpdate As New SqlCommand(updateLogSql, conn)
                                    Await cmdUpdate.ExecuteNonQueryAsync().ConfigureAwait(False)
                                End Using

                                ' تحديث حالة المزامنة لكل جدول متأثر بعدده الفعلي
                                For Each kvp In tablePushedCounts
                                    Dim tb = kvp.Key
                                    Dim cnt = kvp.Value
                                    Dim updateStateSql = "IF EXISTS (SELECT 1 FROM _SyncState WHERE TableName = @TableName) " &
                                                         "    UPDATE _SyncState SET LastPushAt = SYSUTCDATETIME(), TotalPushed = TotalPushed + @Count WHERE TableName = @TableName " &
                                                         "ELSE " &
                                                         "    INSERT INTO _SyncState (TableName, LastPushAt, TotalPushed) VALUES (@TableName, SYSUTCDATETIME(), @Count);"
                                    Using cmdState As New SqlCommand(updateStateSql, conn)
                                        cmdState.Parameters.AddWithValue("@Count", cnt)
                                        cmdState.Parameters.AddWithValue("@TableName", tb)
                                        Await cmdState.ExecuteNonQueryAsync().ConfigureAwait(False)
                                    End Using
                                Next
                            End If

                            totalPushed += batchOperations.Count

                            progress?.Report(New SyncProgressEventArgs With {
                                .Operation = "push",
                                .Message = $"تم إرسال {totalPushed} حركة إلى السحابة بنجاح...",
                                .CurrentRow = totalPushed,
                                .TotalRows = totalPushed
                            })
                        End If

                        ' إذا كان عدد السجلات أقل من الدفعة، نكون انتهينا
                        If dtLogs.Rows.Count < batchSize Then Exit While
                    End While

                    ' تسجيل وتحديث الجهاز الحالي في جدول أجهزة المنشأة على السحابة
                    Try
                        Dim devSql = "INSERT INTO [_SyncDevices] ([device_id], [device_name], [app_version], [os_info], [last_sync_utc], [total_pushed]) " &
                                     "VALUES (?, ?, ?, ?, ?, ?) " &
                                     "ON CONFLICT([device_id]) DO UPDATE SET " &
                                     "[device_name] = excluded.[device_name], " &
                                     "[app_version] = excluded.[app_version], " &
                                     "[os_info] = excluded.[os_info], " &
                                     "[last_sync_utc] = excluded.[last_sync_utc], " &
                                     "[total_pushed] = [_SyncDevices].[total_pushed] + excluded.[total_pushed];"
                        Dim devArgs As Object() = {
                            _deviceId,
                            Environment.MachineName,
                            Application.ProductVersion,
                            Environment.OSVersion.ToString(),
                            DateTime.UtcNow.ToString("o"),
                            totalPushed
                        }
                        Await _client.ExecuteNonQueryAsync(devSql, devArgs).ConfigureAwait(False)
                    Catch exDev As Exception
                        Logger.LogError("SyncPushHandler._SyncDevices", exDev)
                    End Try

                End Using

                Dim finalResult = SyncResult.CreateSuccess(totalPushed, 0, 0)
                finalResult.StartedAt = startTime
                finalResult.CompletedAt = DateTime.Now
                Return finalResult

            Catch ex As Exception
                Dim failedResult = SyncResult.CreateFailed($"خطأ في رفع التغييرات للسحابة: {ex.Message}")
                failedResult.StartedAt = startTime
                failedResult.CompletedAt = DateTime.Now
                Return failedResult
            End Try
        End Function

    End Class
End Namespace
