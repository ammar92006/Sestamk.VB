Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Namespace Services.Cloud

    ''' <summary>
    ''' نتيجة حل التعارض
    ''' </summary>
    Public Enum ConflictResolution
        LocalWins
        RemoteWins
        NeedsManualReview
    End Enum

    ''' <summary>
    ''' فئة مسؤولة عن حل وتسجيل التعارضات بين البيانات المحلية والسحابية
    ''' </summary>
    Public NotInheritable Class ConflictResolver
        Private Sub New()
        End Sub

        ''' <summary>
        ''' تحديد طريقة الحل بناءً على الإستراتيجية
        ''' </summary>
        Public Shared Function Resolve(tableName As String, localUpdatedAt As DateTime?, remoteUpdatedAt As DateTime?, strategy As ConflictStrategy) As ConflictResolution
            Select Case strategy
                Case ConflictStrategy.LocalWins
                    Return ConflictResolution.LocalWins

                Case ConflictStrategy.RemoteWins
                    Return ConflictResolution.RemoteWins

                Case ConflictStrategy.ManualReview
                    Return ConflictResolution.NeedsManualReview

                Case Else ' ConflictStrategy.LastWriteWins
                    If localUpdatedAt.HasValue AndAlso remoteUpdatedAt.HasValue Then
                        If localUpdatedAt.Value > remoteUpdatedAt.Value Then
                            Return ConflictResolution.LocalWins
                        Else
                            Return ConflictResolution.RemoteWins
                        End If
                    ElseIf localUpdatedAt.HasValue AndAlso Not remoteUpdatedAt.HasValue Then
                        Return ConflictResolution.LocalWins
                    Else
                        Return ConflictResolution.RemoteWins
                    End If
            End Select
        End Function

        ''' <summary>
        ''' تسجيل التعارض في جدول _SyncConflicts المحلي
        ''' </summary>
        Public Shared Async Function LogConflictAsync(tableName As String, syncId As Guid, localDataJson As String, remoteDataJson As String) As Task(Of Long)
            Try
                Dim query As String = "INSERT INTO _SyncConflicts (TableName, RowSyncId, LocalDataJson, RemoteDataJson, DetectedAt, IsResolved) " &
                                      "OUTPUT INSERTED.ConflictId " &
                                      "VALUES (@TableName, @RowSyncId, @LocalData, @RemoteData, SYSUTCDATETIME(), 0);"

                Using conn As SqlConnection = DBModule.NewConn()
                    If conn Is Nothing Then Return 0
                    If conn.State <> ConnectionState.Open Then Await conn.OpenAsync().ConfigureAwait(False)

                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@TableName", tableName)
                        cmd.Parameters.AddWithValue("@RowSyncId", syncId)
                        cmd.Parameters.AddWithValue("@LocalData", If(String.IsNullOrEmpty(localDataJson), DBNull.Value, CObj(localDataJson)))
                        cmd.Parameters.AddWithValue("@RemoteData", If(String.IsNullOrEmpty(remoteDataJson), DBNull.Value, CObj(remoteDataJson)))

                        Dim result = Await cmd.ExecuteScalarAsync().ConfigureAwait(False)
                        If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                            Return Convert.ToInt64(result)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"LogConflictAsync Error: {ex.Message}")
            End Try
            Return 0
        End Function

        ''' <summary>
        ''' استرجاع التعارضات المعلقة التي تتطلب مراجعة يدوية
        ''' </summary>
        Public Shared Async Function GetUnresolvedConflictsAsync() As Task(Of List(Of SyncConflict))
            Dim list As New List(Of SyncConflict)()
            Try
                Dim query As String = "SELECT ConflictId, TableName, RowSyncId, LocalDataJson, RemoteDataJson, DetectedAt, IsResolved, Resolution " &
                                      "FROM _SyncConflicts WHERE IsResolved = 0 ORDER BY DetectedAt DESC;"

                Using conn As SqlConnection = DBModule.NewConn()
                    If conn Is Nothing Then Return list
                    If conn.State <> ConnectionState.Open Then Await conn.OpenAsync().ConfigureAwait(False)

                    Using cmd As New SqlCommand(query, conn)
                        Using reader = Await cmd.ExecuteReaderAsync().ConfigureAwait(False)
                            While Await reader.ReadAsync().ConfigureAwait(False)
                                Dim conflict As New SyncConflict() With {
                                    .ConflictId = Convert.ToInt64(reader("ConflictId")),
                                    .TableName = Convert.ToString(reader("TableName")),
                                    .RowSyncId = DirectCast(reader("RowSyncId"), Guid),
                                    .LocalDataJson = If(reader.IsDBNull(reader.GetOrdinal("LocalDataJson")), Nothing, Convert.ToString(reader("LocalDataJson"))),
                                    .RemoteDataJson = If(reader.IsDBNull(reader.GetOrdinal("RemoteDataJson")), Nothing, Convert.ToString(reader("RemoteDataJson"))),
                                    .DetectedAt = Convert.ToDateTime(reader("DetectedAt")),
                                    .IsResolved = Convert.ToBoolean(reader("IsResolved")),
                                    .Resolution = If(reader.IsDBNull(reader.GetOrdinal("Resolution")), Nothing, Convert.ToString(reader("Resolution")))
                                }
                                list.Add(conflict)
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"GetUnresolvedConflictsAsync Error: {ex.Message}")
            End Try
            Return list
        End Function

        ''' <summary>
        ''' حل التعارض يدوياً
        ''' </summary>
        Public Shared Async Function ResolveConflictManuallyAsync(conflictId As Long, resolution As String, resolvedByUserId As Integer) As Task(Of Boolean)
            Try
                Dim query As String = "UPDATE _SyncConflicts SET IsResolved = 1, Resolution = @Resolution, " &
                                      "ResolvedAt = SYSUTCDATETIME(), ResolvedBy = @ResolvedBy " &
                                      "WHERE ConflictId = @ConflictId;"

                Using conn As SqlConnection = DBModule.NewConn()
                    If conn Is Nothing Then Return False
                    If conn.State <> ConnectionState.Open Then Await conn.OpenAsync().ConfigureAwait(False)

                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@Resolution", resolution)
                        cmd.Parameters.AddWithValue("@ResolvedBy", resolvedByUserId)
                        cmd.Parameters.AddWithValue("@ConflictId", conflictId)

                        Dim rowsAffected = Await cmd.ExecuteNonQueryAsync().ConfigureAwait(False)
                        Return rowsAffected > 0
                    End Using
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"ResolveConflictManuallyAsync Error: {ex.Message}")
                Return False
            End Try
        End Function

    End Class
End Namespace
