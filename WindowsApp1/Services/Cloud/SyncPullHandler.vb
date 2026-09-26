Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Threading.Tasks

Namespace Services.Cloud

    ''' <summary>
    ''' فئة مسؤولة عن سحب التغييرات السحابية من Turso إلى SQL Server المحلي
    ''' </summary>
    Public Class SyncPullHandler
        Private ReadOnly _client As TursoHttpClient
        Private ReadOnly _deviceId As String

        Public Sub New(client As TursoHttpClient, deviceId As String)
            _client = client
            _deviceId = If(String.IsNullOrEmpty(deviceId), "UNKNOWN_DEV", deviceId)
        End Sub

        ''' <summary>
        ''' سحب التغييرات من السحابة إلى قاعدة البيانات المحلية
        ''' </summary>
        Public Async Function PullChangesAsync(Optional progress As IProgress(Of SyncProgressEventArgs) = Nothing) As Task(Of SyncResult)
            Dim startTime = DateTime.Now
            Dim totalPulled As Integer = 0
            Dim totalConflicts As Integer = 0

            Try
                Dim tables = SyncableTableRegistry.GetTablesInSyncOrder()

                Using conn As SqlConnection = DBModule.NewConn()
                    If conn Is Nothing Then Return SyncResult.CreateFailed("تعذر الاتصال بقاعدة البيانات المحلية.")
                    If conn.State <> ConnectionState.Open Then Await conn.OpenAsync().ConfigureAwait(False)

                    ' تعيين CONTEXT_INFO لتنبيه تريجرات SQL Server بأن هذه عملية مزامنة لمنع التكرار اللانهائي
                    Try
                        Using cmdContext As New SqlCommand("SET CONTEXT_INFO 0x53594E43000000000000000000000000;", conn)
                            Await cmdContext.ExecuteNonQueryAsync().ConfigureAwait(False)
                        End Using
                    Catch
                    End Try

                    For tableIdx = 0 To tables.Count - 1
                        Dim table = tables(tableIdx)

                        ' الحصول على تاريخ آخر سحب للجدول
                        Dim lastPullAt As DateTime? = Nothing
                        Dim getStateSql = "SELECT LastPullAt FROM _SyncState WHERE TableName = @TableName"
                        Using cmdState As New SqlCommand(getStateSql, conn)
                            cmdState.Parameters.AddWithValue("@TableName", table.TableName)
                            Dim res = Await cmdState.ExecuteScalarAsync().ConfigureAwait(False)
                            If res IsNot Nothing AndAlso Not DBNull.Value.Equals(res) Then
                                lastPullAt = Convert.ToDateTime(res)
                            End If
                        End Using

                        ' تجهيز استعلام السحابة
                        Dim remoteQuery As String
                        Dim remoteParams As New List(Of Object)()

                        If lastPullAt Is Nothing Then
                            remoteQuery = $"SELECT * FROM [{table.TableName}] WHERE is_deleted = 0 ORDER BY updated_at ASC LIMIT 500"
                        Else
                            remoteQuery = $"SELECT * FROM [{table.TableName}] WHERE updated_at > ? AND (device_id IS NULL OR device_id <> ?) ORDER BY updated_at ASC LIMIT 500"
                            remoteParams.Add(lastPullAt.Value.ToString("o"))
                            remoteParams.Add(_deviceId)
                        End If

                        ' جلب البيانات من السحابة
                        Dim dtRemote As DataTable = Nothing
                        Try
                            dtRemote = Await _client.ExecuteQueryAsync(remoteQuery, remoteParams.ToArray()).ConfigureAwait(False)
                        Catch ex As Exception
                            System.Diagnostics.Debug.WriteLine($"Error querying remote table {table.TableName}: {ex.Message}")
                            Continue For
                        End Try

                        Dim pulledForTable As Integer = 0

                        If dtRemote IsNot Nothing AndAlso dtRemote.Rows.Count > 0 Then
                            ' جلب أسماء الأعمدة في الجدول المحلي وقائمة أعمدة الـ IDENTITY
                            Dim localColumns As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                            Dim identityColumn As String = Nothing

                            Using cmdSchema As New SqlCommand($"SELECT COLUMN_NAME, COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME), COLUMN_NAME, 'IsIdentity') AS IsIdentity FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName", conn)
                                cmdSchema.Parameters.AddWithValue("@TableName", table.TableName)
                                Using reader = Await cmdSchema.ExecuteReaderAsync().ConfigureAwait(False)
                                    While Await reader.ReadAsync().ConfigureAwait(False)
                                        Dim colName = Convert.ToString(reader("COLUMN_NAME"))
                                        localColumns.Add(colName)
                                        If Convert.ToInt32(reader("IsIdentity")) = 1 Then
                                            identityColumn = colName
                                        End If
                                    End While
                                End Using
                            End Using

                            For Each row As DataRow In dtRemote.Rows
                                If Not dtRemote.Columns.Contains("sync_id") OrElse row.IsNull("sync_id") Then Continue For

                                Dim syncIdStr = Convert.ToString(row("sync_id"))
                                Dim syncId As Guid
                                If Not Guid.TryParse(syncIdStr, syncId) Then Continue For

                                Dim remoteUpdatedAt As DateTime = DateTime.UtcNow
                                If dtRemote.Columns.Contains("updated_at") AndAlso Not row.IsNull("updated_at") Then
                                    DateTime.TryParse(Convert.ToString(row("updated_at")), remoteUpdatedAt)
                                End If

                                ' التحقق من وجود السجل محلياً
                                Dim localUpdatedAt As DateTime? = Nothing
                                Dim checkLocalSql = $"SELECT TOP 1 updated_at FROM [{table.TableName}] WHERE sync_id = @SyncId"
                                Using cmdCheck As New SqlCommand(checkLocalSql, conn)
                                    cmdCheck.Parameters.AddWithValue("@SyncId", syncId)
                                    Dim localRes = Await cmdCheck.ExecuteScalarAsync().ConfigureAwait(False)
                                    If localRes IsNot Nothing AndAlso Not DBNull.Value.Equals(localRes) Then
                                        localUpdatedAt = Convert.ToDateTime(localRes)
                                    End If
                                End Using

                                If localUpdatedAt.HasValue Then
                                    ' السجل موجود، نحل التعارض
                                    Dim resolution = ConflictResolver.Resolve(table.TableName, localUpdatedAt.Value, remoteUpdatedAt, CType(table.ConflictStrategy, ConflictStrategy))

                                    If resolution = ConflictResolution.RemoteWins Then
                                        ' تحديث السجل المحلي بالبيانات السحابية
                                        Dim updateCols As New List(Of String)()
                                        Dim updateCmd As New SqlCommand()
                                        updateCmd.Connection = conn

                                        For Each col As DataColumn In dtRemote.Columns
                                            If localColumns.Contains(col.ColumnName) AndAlso
                                               Not String.Equals(col.ColumnName, "sync_id", StringComparison.OrdinalIgnoreCase) AndAlso
                                               Not String.Equals(col.ColumnName, identityColumn, StringComparison.OrdinalIgnoreCase) Then

                                                updateCols.Add($"[{col.ColumnName}] = @{col.ColumnName}")
                                                Dim val = If(row.IsNull(col), DBNull.Value, row(col))
                                                updateCmd.Parameters.AddWithValue($"@{col.ColumnName}", val)
                                            End If
                                        Next

                                        If updateCols.Count > 0 Then
                                            updateCmd.CommandText = $"UPDATE [{table.TableName}] SET {String.Join(", ", updateCols)} WHERE sync_id = @sync_id"
                                            updateCmd.Parameters.AddWithValue("@sync_id", syncId)
                                            Await updateCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                                            pulledForTable += 1
                                        End If

                                    ElseIf resolution = ConflictResolution.NeedsManualReview Then
                                        totalConflicts += 1
                                        Await ConflictResolver.LogConflictAsync(table.TableName, syncId, Nothing, Nothing).ConfigureAwait(False)
                                    End If

                                Else
                                    ' السجل غير موجود محلياً، إدراج جديد
                                    Dim insertCols As New List(Of String)()
                                    Dim paramNames As New List(Of String)()
                                    Dim insertCmd As New SqlCommand()
                                    insertCmd.Connection = conn

                                    For Each col As DataColumn In dtRemote.Columns
                                        ' تخطي عمود الـ IDENTITY المحلي حتى يقوم SQL Server بتوليد معرف محلي
                                        If localColumns.Contains(col.ColumnName) AndAlso
                                           Not String.Equals(col.ColumnName, identityColumn, StringComparison.OrdinalIgnoreCase) Then

                                            insertCols.Add($"[{col.ColumnName}]")
                                            paramNames.Add($"@{col.ColumnName}")
                                            Dim val = If(row.IsNull(col), DBNull.Value, row(col))
                                            insertCmd.Parameters.AddWithValue($"@{col.ColumnName}", val)
                                        End If
                                    Next

                                    If insertCols.Count > 0 Then
                                        insertCmd.CommandText = $"INSERT INTO [{table.TableName}] ({String.Join(", ", insertCols)}) VALUES ({String.Join(", ", paramNames)});"
                                        Await insertCmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                                        pulledForTable += 1
                                    End If
                                End If
                            Next

                            ' تحديث حالة السحب للجدول
                            Dim updateStateSql = "IF EXISTS (SELECT 1 FROM _SyncState WHERE TableName = @TableName) " &
                                                 "    UPDATE _SyncState SET LastPullAt = SYSUTCDATETIME(), TotalPulled = TotalPulled + @Count WHERE TableName = @TableName " &
                                                 "ELSE " &
                                                 "    INSERT INTO _SyncState (TableName, LastPullAt, TotalPulled) VALUES (@TableName, SYSUTCDATETIME(), @Count);"
                            Using cmdUpState As New SqlCommand(updateStateSql, conn)
                                cmdUpState.Parameters.AddWithValue("@Count", pulledForTable)
                                cmdUpState.Parameters.AddWithValue("@TableName", table.TableName)
                                Await cmdUpState.ExecuteNonQueryAsync().ConfigureAwait(False)
                            End Using

                            totalPulled += pulledForTable
                        End If

                        progress?.Report(New SyncProgressEventArgs With {
                            .Operation = "pull",
                            .TableName = table.TableName,
                            .CurrentTable = tableIdx + 1,
                            .TotalTables = tables.Count,
                            .CurrentRow = pulledForTable,
                            .Message = $"جاري سحب التغييرات: {table.DisplayNameAr} ({pulledForTable} سجل)"
                        })
                    Next

                    ' إعادة تعيين CONTEXT_INFO
                    Try
                        Using cmdResetContext As New SqlCommand("SET CONTEXT_INFO 0x0;", conn)
                            Await cmdResetContext.ExecuteNonQueryAsync().ConfigureAwait(False)
                        End Using
                    Catch
                    End Try

                End Using

                Dim finalResult = SyncResult.CreateSuccess(0, totalPulled, totalConflicts)
                finalResult.StartedAt = startTime
                finalResult.CompletedAt = DateTime.Now
                Return finalResult

            Catch ex As Exception
                Dim failedResult = SyncResult.CreateFailed($"خطأ في سحب التغييرات من السحابة: {ex.Message}")
                failedResult.StartedAt = startTime
                failedResult.CompletedAt = DateTime.Now
                Return failedResult
            End Try
        End Function

    End Class
End Namespace
