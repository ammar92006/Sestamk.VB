Imports System
Imports System.Threading.Tasks

Namespace Services.Cloud

    ''' <summary>
    ''' فئة مسؤولة عن بناء وتحديث هيكل الجداول في Turso السحابي
    ''' </summary>
    Public Class TursoSchemaBuilder

        ''' <summary>
        ''' التأكد من تطابق هيكل السحابة مع المحلي
        ''' </summary>
        Public Async Function EnsureRemoteSchemaAsync(client As TursoHttpClient, Optional progress As IProgress(Of String) = Nothing) As Task(Of Boolean)
            Try
                ' الحصول على الجداول القابلة للمزامنة
                Dim syncableTables = SyncableTableRegistry.GetSyncableTables()
                ' الحصول على تعريف الجداول وتحويلها إلى قاموس للبحث السريع
                Dim schemaDefs = Services.DatabaseSchemaDefinitions.GetExpectedSchema()
                Dim schemaDict = schemaDefs.ToDictionary(Function(t) t.TableName, StringComparer.OrdinalIgnoreCase)
                
                Dim success As Boolean = True
                
                For Each syncTable In syncableTables
                    Dim tableName = syncTable.TableName
                    ' التحقق من وجود الجدول في التعريفات
                    If schemaDict.ContainsKey(tableName) Then
                        Dim tableDef = schemaDict(tableName)
                        
                        ' إرسال تحديث بالتقدم
                        progress?.Report($"جاري بناء الهيكل للجدول {tableName} في Turso...")
                        
                        ' إنشاء أمر إنشاء الجدول
                        Dim createTableSql = SqlDialectTranslator.BuildCreateTableSqlite(tableDef, syncColumns:=True)
                        
                        ' إنشاء الفهارس
                        Dim createSyncIdIndexSql = $"CREATE INDEX IF NOT EXISTS IX_{tableName}_sync_id ON [{tableName}] (sync_id);"
                        Dim createUpdatedAtIndexSql = $"CREATE INDEX IF NOT EXISTS IX_{tableName}_updated_at ON [{tableName}] (updated_at);"
                        
                        ' تنفيذ الأوامر على Turso
                        Try
                            Await client.ExecuteNonQueryAsync(createTableSql).ConfigureAwait(False)
                            Await client.ExecuteNonQueryAsync(createSyncIdIndexSql).ConfigureAwait(False)
                            Await client.ExecuteNonQueryAsync(createUpdatedAtIndexSql).ConfigureAwait(False)
                        Catch ex As Exception
                            progress?.Report($"حدث خطأ أثناء إنشاء جدول {tableName}: {ex.Message}")
                            success = False
                        End Try
                    End If
                Next
                
                ' إنشاء جدول أجهزة المنشأة لتتبع المزامنة اللحظية لكل جهاز
                Try
                    Dim createDevicesSql = "CREATE TABLE IF NOT EXISTS [_SyncDevices] (" &
                                           "[device_id] TEXT PRIMARY KEY, " &
                                           "[device_name] TEXT NOT NULL, " &
                                           "[app_version] TEXT, " &
                                           "[os_info] TEXT, " &
                                           "[last_sync_utc] TEXT NOT NULL, " &
                                           "[total_pushed] INTEGER DEFAULT 0, " &
                                           "[total_pulled] INTEGER DEFAULT 0, " &
                                           "[is_active] INTEGER DEFAULT 1);"
                    Await client.ExecuteNonQueryAsync(createDevicesSql).ConfigureAwait(False)
                    Await client.ExecuteNonQueryAsync("CREATE INDEX IF NOT EXISTS IX_SyncDevices_last_sync ON [_SyncDevices] (last_sync_utc);").ConfigureAwait(False)
                Catch exDev As Exception
                    Logger.LogError("TursoSchemaBuilder._SyncDevices", exDev)
                End Try

                If success Then
                    progress?.Report("تم التأكد من الهيكل السحابي بنجاح.")
                End If
                
                Return success
            Catch ex As Exception
                progress?.Report($"حدث خطأ عام أثناء بناء الهيكل: {ex.Message}")
                Return False
            End Try
        End Function

        ''' <summary>
        ''' الحصول على عدد الجداول في السحابة
        ''' </summary>
        Public Async Function GetRemoteTableCountAsync(client As TursoHttpClient) As Task(Of Integer)
            Try
                Dim query As String = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';"
                
                ' استخدام دالة التنفيذ للحصول على قيمة مفردة
                Dim result = Await client.ExecuteScalarAsync(query).ConfigureAwait(False)
                
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    Return Convert.ToInt32(result)
                End If
                
                Return 0
            Catch ex As Exception
                Throw New Exception("حدث خطأ أثناء جلب عدد الجداول السحابية: " & ex.Message, ex)
            End Try
        End Function

    End Class

End Namespace
