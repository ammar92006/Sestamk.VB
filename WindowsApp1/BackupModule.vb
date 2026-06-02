Imports System.Data.SqlClient
Imports System.IO

Public Module BackupModule
    Public BackupTime1 As TimeSpan = New TimeSpan(10, 0, 0) ' 10:00 AM
    Public BackupTime2 As TimeSpan = New TimeSpan(18, 0, 0) ' 06:00 PM

    ' [FIX جوهري] استبدال DBModule.Conn العام بـ Using محلي:
    '   - منع تسرّب الاتصالات لو فشل Disconnect.
    '   - حذف Finally Connect() الغريب (كان يعيد فتح اتصال بلا داعٍ).
    '   - تحسين الـ BACKUP بـ CommandTimeout كبير لقواعد البيانات الكبيرة.

    Public Function BackupTakenToday(slot As Integer) As Boolean
        Try
            Using cn As SqlConnection = NewConn()
                Dim q As String =
                    "SELECT COUNT(*) FROM Backup_Log
                     WHERE Backup_Slot = @slot
                       AND CAST(Backup_Date AS DATE) = CAST(GETDATE() AS DATE)"

                Using cmd As New SqlCommand(q, cn)
                    cmd.Parameters.AddWithValue("@slot", slot)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Sub TakeBackupScheduled(folder As String, userName As String, slot As Integer)
        Try
            If Not Directory.Exists(folder) Then
                Directory.CreateDirectory(folder)
            End If

            Dim fileName As String =
                $"Cashier_Market_{DateTime.Now:yyyyMMdd_HHmmss}_S{slot}.bak"

            Dim fullPath As String = Path.Combine(folder, fileName)

            Using cn As SqlConnection = NewConn()
                Dim backupQuery As String =
                    $"BACKUP DATABASE [{DBModule.database}]
                      TO DISK = @path
                      WITH INIT"

                Using cmd As New SqlCommand(backupQuery, cn)
                    cmd.Parameters.AddWithValue("@path", fullPath)
                    cmd.CommandTimeout = 600 ' 10 دقائق لقواعد البيانات الكبيرة
                    cmd.ExecuteNonQuery()
                End Using

                Dim logQuery As String =
                    "INSERT INTO Backup_Log (Backup_File, Backup_By, Backup_Slot)
                     VALUES (@file, @user, @slot)"

                Using cmd As New SqlCommand(logQuery, cn)
                    cmd.Parameters.AddWithValue("@file", fullPath)
                    cmd.Parameters.AddWithValue("@user", userName)
                    cmd.Parameters.AddWithValue("@slot", slot)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            ' لا نطلع رسالة عشان قد يكون في شاشة الدخول
            Debug.WriteLine("TakeBackupScheduled error: " & ex.Message)
        End Try
    End Sub

    Public Sub CheckAndTakeScheduledBackup(backupFolder As String, userName As String)
        Dim nowTime As TimeSpan = DateTime.Now.TimeOfDay

        ' ===== الميعاد الأول =====
        If nowTime >= BackupTime1 AndAlso Not BackupTakenToday(1) Then
            TakeBackupScheduled(backupFolder, userName, 1)
            Exit Sub
        End If

        ' ===== الميعاد الثاني =====
        If nowTime >= BackupTime2 AndAlso Not BackupTakenToday(2) Then
            TakeBackupScheduled(backupFolder, userName, 2)
            Exit Sub
        End If
    End Sub

    Public Sub TakeBackup(backupFolder As String, userName As String)
        Try
            If Not Directory.Exists(backupFolder) Then
                Directory.CreateDirectory(backupFolder)
            End If

            Dim fileName As String =
                $"Cashier_Market_{DateTime.Now:yyyyMMdd_HHmmss}.bak"

            Dim fullPath As String = Path.Combine(backupFolder, fileName)

            Using cn As SqlConnection = NewConn()
                Dim backupQuery As String =
                    $"BACKUP DATABASE [{DBModule.database}]
                      TO DISK = @path
                      WITH INIT"

                Using cmd As New SqlCommand(backupQuery, cn)
                    cmd.Parameters.AddWithValue("@path", fullPath)
                    cmd.CommandTimeout = 600
                    cmd.ExecuteNonQuery()
                End Using

                Dim logQuery As String =
                    "INSERT INTO Backup_Log (Backup_File, Backup_By)
                     VALUES (@file, @user)"

                Using cmd As New SqlCommand(logQuery, cn)
                    cmd.Parameters.AddWithValue("@file", fullPath)
                    cmd.Parameters.AddWithValue("@user", userName)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MsgBox("✅ تم إنشاء النسخة الاحتياطية بنجاح", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("❌ خطأ أثناء النسخ الاحتياطي:" & vbCrLf & ex.Message,
                   MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub RestoreBackup(backupFile As String)
        Try
            DBModule.Disconnect()

            Dim masterConnStr As String =
                $"Server={DBModule.server};Database=master;Integrated Security=True;"

            Using conn As New SqlConnection(masterConnStr)
                conn.Open()

                Dim restoreQuery As String =
                    $"ALTER DATABASE [{DBModule.database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                      RESTORE DATABASE [{DBModule.database}]
                      FROM DISK = @path
                      WITH REPLACE;
                      ALTER DATABASE [{DBModule.database}] SET MULTI_USER;"

                Using cmd As New SqlCommand(restoreQuery, conn)
                    cmd.Parameters.AddWithValue("@path", backupFile)
                    cmd.CommandTimeout = 600
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MsgBox("✅ تم استعادة النسخة الاحتياطية بنجاح", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("❌ خطأ أثناء الاستعادة:" & vbCrLf & ex.Message,
                   MsgBoxStyle.Critical)
        End Try
    End Sub

End Module
