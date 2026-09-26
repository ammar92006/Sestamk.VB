Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Threading.Tasks
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
        ''' دفع التغييرات المعلقة إلى السحابة
        ''' </summary>
        Public Async Function PushPendingChangesAsync(Optional batchSize As Integer = 50, Optional progress As IProgress(Of SyncProgressEventArgs) = Nothing) As Task(Of SyncResult)
            Dim startTime = DateTime.Now
            Dim pushedCount As Integer = 0

            Try
                Using conn As SqlConnection = DBModule.NewConn()
                    If conn Is Nothing Then Return SyncResult.CreateFailed("تعذر الاتصال بقاعدة البيانات المحلية.")
                    If conn.State <> ConnectionState.Open Then Await conn.OpenAsync().ConfigureAwait(False)

                    ' جلب التغييرات غير المتزامنة من سجل المزامنة
                    Dim getLogQuery = "SELECT TOP (@BatchSize) LogId, TableName, RowSyncId, Operation, ChangedColumns, RowDataJson, CreatedAt " &
                                      "FROM _SyncLog WHERE IsSynced = 0 AND RetryCount < 5 ORDER BY LogId ASC"
                    Dim dtLogs As New DataTable()

                    Using cmd As New SqlCommand(getLogQuery, conn)
                        cmd.Parameters.AddWithValue("@BatchSize", batchSize)
                        Using reader = Await cmd.ExecuteReaderAsync().ConfigureAwait(False)
                            dtLogs.Load(reader)
                        End Using
                    End Using

                    If dtLogs.Rows.Count = 0 Then
                        Dim emptyRes = SyncResult.CreateSuccess(0, 0, 0)
                        emptyRes.StartedAt = startTime
                        emptyRes.CompletedAt = DateTime.Now
                        Return emptyRes
                    End If

                    ' تحضير قائمة العمليات للسحابة
                    Dim batchOperations As New List(Of Tuple(Of String, Object()))()
                    Dim successfulLogIds As New List(Of Long)()
                    Dim affectedTables As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

                    For Each row As DataRow In dtLogs.Rows
                        Dim logId As Long = Convert.ToInt64(row("LogId"))
                        Dim tableName As String = Convert.ToString(row("TableName"))
                        Dim syncId As Guid = DirectCast(row("RowSyncId"), Guid)
                        Dim operation As String = Convert.ToString(row("Operation")).ToUpper()
                        Dim createdAt As DateTime = Convert.ToDateTime(row("CreatedAt"))

                        affectedTables.Add(tableName)

                        If operation = "I" OrElse operation = "U" Then
                            ' قراءة بيانات السجل الحالية إذا لم تكن مخزنة كـ JSON
                            Dim rowDataJson As String = If(row.IsNull("RowDataJson"), Nothing, Convert.ToString(row("RowDataJson")))
                            Dim rowValues As New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)

                            If Not String.IsNullOrEmpty(rowDataJson) Then
                                Try
                                    Dim parsed = JObject.Parse(rowDataJson)
                                    For Each prop In parsed.Properties()
                                        rowValues(prop.Name) = prop.Value?.ToObject(Of Object)()
                                    Next
                                Catch
                                End Try
                            End If

                            ' إذا لم نتمكن من القراءة من JSON، نقرأ الصف مباشرة من الجدول المحلي
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
                                ' تجهيز أعمدة المزامنة
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
                            Else
                                ' الصف حذف محلياً أو غير موجود، نسجل نجاح السجل لتجاوزه
                                successfulLogIds.Add(logId)
                            End If

                        ElseIf operation = "D" Then
                            ' حذف منطقي في السحابة
                            Dim sql = $"UPDATE [{tableName}] SET is_deleted = 1, updated_at = ?, device_id = ? WHERE sync_id = ?;"
                            Dim values As Object() = {createdAt.ToString("o"), _deviceId, syncId.ToString()}
                            batchOperations.Add(New Tuple(Of String, Object())(sql, values))
                            successfulLogIds.Add(logId)
                        End If
                    Next

                    ' تنفيذ الدفعة على السحابة
                    If batchOperations.Count > 0 Then
                        Dim isBatchSuccess As Boolean = False
                        Dim batchEx As Exception = Nothing

                        Try
                            isBatchSuccess = Await _client.ExecuteTransactionAsync(batchOperations).ConfigureAwait(False)
                            If isBatchSuccess Then
                                pushedCount = batchOperations.Count
                            End If
                        Catch ex As Exception
                            batchEx = ex
                        End Try

                        If batchEx IsNot Nothing OrElse Not isBatchSuccess Then
                            ' تحديث سجل الأخطاء محلياً خارج الـ Catch
                            If successfulLogIds.Count > 0 Then
                                Dim logIdsStr = String.Join(",", successfulLogIds)
                                Dim errMsg = If(batchEx IsNot Nothing, batchEx.Message, "فشل تنفيذ معاملة المزامنة على خادم Turso.")
                                Dim failSql = $"UPDATE _SyncLog SET RetryCount = RetryCount + 1, ErrorMessage = @Err WHERE LogId IN ({logIdsStr})"
                                Using cmdFail As New SqlCommand(failSql, conn)
                                    cmdFail.Parameters.AddWithValue("@Err", errMsg)
                                    Await cmdFail.ExecuteNonQueryAsync().ConfigureAwait(False)
                                End Using
                            End If

                            If batchEx IsNot Nothing Then
                                Throw batchEx
                            Else
                                Return SyncResult.CreateFailed("فشل تنفيذ معاملة المزامنة على خادم Turso.")
                            End If
                        End If
                    End If

                    ' تحديث حالة السجل محلياً عند النجاح
                    If successfulLogIds.Count > 0 Then
                        Dim logIdsStr = String.Join(",", successfulLogIds)
                        Dim updateLogSql = $"UPDATE _SyncLog SET IsSynced = 1, SyncedAt = SYSUTCDATETIME() WHERE LogId IN ({logIdsStr})"
                        Using cmdUpdate As New SqlCommand(updateLogSql, conn)
                            Await cmdUpdate.ExecuteNonQueryAsync().ConfigureAwait(False)
                        End Using

                        ' تحديث حالة المزامنة لكل جدول متأثر
                        For Each tb In affectedTables
                            Dim updateStateSql = "IF EXISTS (SELECT 1 FROM _SyncState WHERE TableName = @TableName) " &
                                                 "    UPDATE _SyncState SET LastPushAt = SYSUTCDATETIME(), TotalPushed = TotalPushed + @Count WHERE TableName = @TableName " &
                                                 "ELSE " &
                                                 "    INSERT INTO _SyncState (TableName, LastPushAt, TotalPushed) VALUES (@TableName, SYSUTCDATETIME(), @Count);"
                            Using cmdState As New SqlCommand(updateStateSql, conn)
                                cmdState.Parameters.AddWithValue("@Count", pushedCount)
                                cmdState.Parameters.AddWithValue("@TableName", tb)
                                Await cmdState.ExecuteNonQueryAsync().ConfigureAwait(False)
                            End Using
                        Next
                    End If

                    progress?.Report(New SyncProgressEventArgs With {
                        .Operation = "push",
                        .Message = $"تم إرسال {pushedCount} حركة إلى السحابة بنجاح.",
                        .CurrentRow = pushedCount,
                        .TotalRows = pushedCount
                    })

                End Using

                Dim finalResult = SyncResult.CreateSuccess(pushedCount, 0, 0)
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
