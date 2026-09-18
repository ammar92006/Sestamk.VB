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
                $"Sestamk_{DateTime.Now:yyyyMMdd_HHmmss}_S{slot}.bak"

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
                $"Sestamk_{DateTime.Now:yyyyMMdd_HHmmss}.bak"

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
            ' ── التحقق من صحة الملف قبل الاستعادة ──
            If String.IsNullOrWhiteSpace(backupFile) Then
                MsgBox("❌ لم يتم تحديد ملف النسخة الاحتياطية.", MsgBoxStyle.Critical)
                Return
            End If

            If Not IO.File.Exists(backupFile) Then
                MsgBox("❌ ملف النسخة الاحتياطية غير موجود:" & vbCrLf & backupFile, MsgBoxStyle.Critical)
                Return
            End If

            ' التحقق من امتداد الملف
            Dim ext As String = IO.Path.GetExtension(backupFile).ToLower()
            If ext <> ".bak" Then
                MsgBox("❌ نوع الملف غير صالح. يجب أن يكون بامتداد .bak", MsgBoxStyle.Critical)
                Return
            End If

            ' التحقق من حجم الملف (يجب ألا يكون فارغاً)
            Dim fileInfo As New IO.FileInfo(backupFile)
            If fileInfo.Length = 0 Then
                MsgBox("❌ ملف النسخة الاحتياطية فارغ.", MsgBoxStyle.Critical)
                Return
            End If

            ' تأكيد من المستخدم قبل الاستعادة
            Dim result = MessageBox.Show(
                "⚠️ استعادة النسخة الاحتياطية ستحل محل قاعدة البيانات الحالية بالكامل." & vbCrLf &
                "الملف: " & IO.Path.GetFileName(backupFile) & vbCrLf &
                "الحجم: " & Math.Round(fileInfo.Length / 1024.0 / 1024.0, 2) & " MB" & vbCrLf & vbCrLf &
                "هل أنت متأكد من المتابعة؟",
                "تأكيد استعادة النسخة الاحتياطية",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result <> DialogResult.Yes Then Return

            DBModule.Disconnect()

            Dim masterConnStr As String =
                $"Server={DBModule.server};Database=master;Integrated Security=True;"

            Using conn As New SqlConnection(masterConnStr)
                conn.Open()

                ' التحقق من صحة النسخة الاحتياطية قبل الاستعادة
                Try
                    Using verifyCmd As New SqlCommand("RESTORE VERIFYONLY FROM DISK = @path", conn)
                        verifyCmd.Parameters.AddWithValue("@path", backupFile)
                        verifyCmd.CommandTimeout = 300
                        verifyCmd.ExecuteNonQuery()
                    End Using
                Catch verifyEx As Exception
                    MsgBox("❌ ملف النسخة الاحتياطية تالف أو غير صالح:" & vbCrLf & verifyEx.Message,
                           MsgBoxStyle.Critical)
                    Logger.LogError("RestoreBackup.Verify", verifyEx)
                    Return
                End Try

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

            Logger.LogInfo("تم استعادة النسخة الاحتياطية بنجاح: " & backupFile)
            MsgBox("✅ تم استعادة النسخة الاحتياطية بنجاح", MsgBoxStyle.Information)

        Catch ex As Exception
            Logger.LogError("RestoreBackup", ex)
            MsgBox("❌ خطأ أثناء الاستعادة:" & vbCrLf & ex.Message,
                   MsgBoxStyle.Critical)
        End Try
    End Sub

End Module
