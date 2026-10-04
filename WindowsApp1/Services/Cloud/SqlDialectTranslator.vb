Imports System.Text
Imports System.Linq

Namespace Services.Cloud

    ''' <summary>
    ''' مترجم لهجات SQL بين SQL Server و SQLite
    ''' Translates between SQL Server (T-SQL) and SQLite SQL dialects
    ''' </summary>
    Public Module SqlDialectTranslator

        ''' <summary>
        ''' تحويل أنواع البيانات من SQL Server إلى SQLite
        ''' Convert SQL Server types to SQLite
        ''' </summary>
        Public Function TranslateDataType(sqlServerType As String) As String
            If String.IsNullOrEmpty(sqlServerType) Then Return "TEXT"
            
            Dim typeUpper = sqlServerType.ToUpper().Split("("c)(0).Trim()
            
            Select Case typeUpper
                Case "INT", "BIGINT", "SMALLINT", "TINYINT", "BIT"
                    Return "INTEGER" ' الأرقام الصحيحة والمنطقية
                    
                Case "NVARCHAR", "VARCHAR", "NTEXT", "TEXT", "CHAR", "NCHAR", "UNIQUEIDENTIFIER"
                    Return "TEXT" ' النصوص
                    
                Case "DECIMAL", "NUMERIC", "MONEY", "SMALLMONEY"
                    Return "TEXT" ' تخزين القيم المالية كنص للحفاظ على الدقة (store financial values as text for precision)
                    
                Case "FLOAT", "REAL"
                    Return "REAL" ' الأرقام العشرية
                    
                Case "DATETIME", "DATETIME2", "DATE", "TIME", "SMALLDATETIME"
                    Return "TEXT" ' التواريخ والأوقات (ISO 8601)
                    
                Case "VARBINARY", "IMAGE", "BINARY"
                    Return "BLOB" ' البيانات الثنائية
                    
                Case Else
                    ' أي نوع آخر يتم تحويله إلى نص كاحتياط
                    Return "TEXT"
            End Select
        End Function

        ''' <summary>
        ''' تحويل القيم الافتراضية
        ''' Convert defaults
        ''' </summary>
        Public Function TranslateDefaultValue(sqlServerDefault As String) As String
            If String.IsNullOrEmpty(sqlServerDefault) Then Return String.Empty
            
            Dim def = sqlServerDefault.Trim().ToUpper()
            
            ' إزالة الأقواس المحيطة إذا وجدت
            While def.StartsWith("(") AndAlso def.EndsWith(")")
                def = def.Substring(1, def.Length - 2).Trim()
            End While
            
            ' معالجة دوال التاريخ
            If def = "GETDATE()" OrElse def = "SYSDATETIME()" OrElse def = "SYSUTCDATETIME()" Then
                Return "CURRENT_TIMESTAMP" ' datetime('now') in SQLite
            End If
            
            ' معالجة NEWID() 
            If def = "NEWID()" Then
                Return String.Empty ' Generate in code, not in SQL
            End If
            
            ' معالجة النصوص التي تبدأ بـ N (N'...')
            If def.StartsWith("N'") Then
                Return def.Substring(1) ' Remove the N prefix
            End If
            
            Return def ' إرجاع القيمة كما هي للأرقام أو النصوص العادية
        End Function

        ''' <summary>
        ''' إنشاء جملة CREATE TABLE لـ SQLite/Turso
        ''' Generate CREATE TABLE for SQLite/Turso from the existing TableDefinition class
        ''' </summary>
        Public Function BuildCreateTableSqlite(tableDef As Object, syncColumns As Boolean) As String
            ' نستخدم Object لتجنب مشاكل الترابط، ونستخدم Late Binding
            ' We use Object to avoid coupling, and use Late Binding in VB.NET
            Dim tableName As String = tableDef.TableName
            Dim columns As IEnumerable(Of Object) = tableDef.Columns
            
            Dim sb As New StringBuilder()
            sb.AppendLine($"CREATE TABLE IF NOT EXISTS [{tableName}] (")
            
            Dim colDefs As New List(Of String)()
            
            For Each col In columns
                Dim colName As String = ""
                Try
                    colName = Convert.ToString(col.Name)
                Catch __logEx As Exception
                    Logger.LogError("SqlDialectTranslator.vb:97", __logEx)
                End Try
                If String.IsNullOrEmpty(colName) Then
                    Try
                        colName = Convert.ToString(col.ColumnName)
                    Catch __logEx As Exception
                        Logger.LogError("SqlDialectTranslator.vb:103", __logEx)
                    End Try
                End If

                Dim colType As String = ""
                Try
                    colType = Convert.ToString(col.SqlType)
                Catch __logEx As Exception
                    Logger.LogError("SqlDialectTranslator.vb:111", __logEx)
                End Try
                If String.IsNullOrEmpty(colType) Then
                    Try
                        colType = Convert.ToString(col.DataType)
                    Catch __logEx As Exception
                        Logger.LogError("SqlDialectTranslator.vb:117", __logEx)
                    End Try
                End If

                Dim isNullable As Boolean = True
                Try
                    isNullable = CBool(col.IsNullable)
                Catch __logEx As Exception
                    Logger.LogError("SqlDialectTranslator.vb:125", __logEx)
                End Try

                Dim isPrimaryKey As Boolean = False
                Try
                    isPrimaryKey = CBool(col.IsPrimaryKey)
                Catch __logEx As Exception
                    Logger.LogError("SqlDialectTranslator.vb:132", __logEx)
                End Try
                
                Dim defaultVal As String = String.Empty
                Try
                    defaultVal = col.DefaultValue
                Catch ex As Exception
                    ' قد لا تكون الخاصية موجودة
                    Logger.LogError("SqlDialectTranslator.vb:139", ex)
                End Try
                
                Dim sqliteType = TranslateDataType(colType)
                Dim colDefStr = $"[{colName}] {sqliteType}"
                
                If isPrimaryKey Then
                    colDefStr &= " PRIMARY KEY"
                ElseIf Not isNullable Then
                    colDefStr &= " NOT NULL"
                End If
                
                If Not String.IsNullOrEmpty(defaultVal) Then
                    Dim sqliteDefault = TranslateDefaultValue(defaultVal)
                    If Not String.IsNullOrEmpty(sqliteDefault) Then
                        colDefStr &= $" DEFAULT {sqliteDefault}"
                    End If
                End If
                
                colDefs.Add(colDefStr)
            Next
            
            ' إضافة أعمدة المزامنة إذا طلب ذلك (Add sync columns)
            If syncColumns Then
                ' التحقق من عدم وجود الأعمدة مسبقاً
                Dim existingColNames = colDefs.Select(Function(c) c.Split(" "c)(0).Replace("[", "").Replace("]", "").ToUpper()).ToList()
                
                If Not existingColNames.Contains("SYNC_ID") Then
                    colDefs.Add("[sync_id] TEXT UNIQUE")
                End If
                If Not existingColNames.Contains("UPDATED_AT") Then
                    colDefs.Add("[updated_at] TEXT")
                End If
                If Not existingColNames.Contains("IS_DELETED") Then
                    colDefs.Add("[is_deleted] INTEGER DEFAULT 0")
                End If
                If Not existingColNames.Contains("DEVICE_ID") Then
                    colDefs.Add("[device_id] TEXT")
                End If
            End If
            
            sb.AppendLine("    " & String.Join("," & Environment.NewLine & "    ", colDefs))
            sb.AppendLine(");")
            
            Return sb.ToString()
        End Function

        ''' <summary>
        ''' إنشاء جملة إدخال أو تحديث لـ SQLite
        ''' Generate INSERT OR REPLACE statement for SQLite
        ''' </summary>
        Public Function BuildUpsertSqlite(tableName As String, columns As String(), syncIdColumn As String) As String
            Dim colNames = String.Join(", ", columns.Select(Function(c) $"[{c}]"))
            Dim paramNames = String.Join(", ", columns.Select(Function(c) $"@{c}"))
            
            ' في حالة SQLite نستخدم INSERT OR REPLACE
            ' ملاحظة: INSERT OR REPLACE يعتمد على وجود قيد فريد (UNIQUE/PRIMARY KEY) مثل sync_id
            Dim sb As New StringBuilder()
            sb.AppendLine($"INSERT OR REPLACE INTO [{tableName}] ({colNames})")
            sb.AppendLine($"VALUES ({paramNames});")
            
            Return sb.ToString()
        End Function

        ''' <summary>
        ''' إنشاء جملة MERGE لـ SQL Server (upsert by sync_id)
        ''' Generate MERGE statement for SQL Server
        ''' </summary>
        Public Function BuildMergeSqlServer(tableName As String, columns As String(), syncIdColumn As String) As String
            Dim sb As New StringBuilder()
            sb.AppendLine($"MERGE INTO [{tableName}] AS target")
            sb.AppendLine($"USING (SELECT {String.Join(", ", columns.Select(Function(c) $"@{c} AS [{c}]"))}) AS source")
            sb.AppendLine($"ON (target.[{syncIdColumn}] = source.[{syncIdColumn}])")
            
            ' جزء التحديث (MATCHED)
            Dim updateCols = columns.Where(Function(c) c <> syncIdColumn).ToList()
            If updateCols.Count > 0 Then
                sb.AppendLine("WHEN MATCHED THEN")
                sb.AppendLine("    UPDATE SET")
                Dim updateSet = String.Join("," & Environment.NewLine & "        ", updateCols.Select(Function(c) $"target.[{c}] = source.[{c}]"))
                sb.AppendLine($"        {updateSet}")
            End If
            
            ' جزء الإدخال (NOT MATCHED)
            sb.AppendLine("WHEN NOT MATCHED THEN")
            sb.AppendLine($"    INSERT ({String.Join(", ", columns.Select(Function(c) $"[{c}]"))})")
            sb.AppendLine($"    VALUES ({String.Join(", ", columns.Select(Function(c) $"source.[{c}]"))});")
            
            Return sb.ToString()
        End Function

    End Module

End Namespace
