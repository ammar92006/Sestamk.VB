Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports System.Diagnostics

Public Class Backup

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupDataGridView(dgv_backup)
            LoadBackupLog(dgv_backup)
            ApplyCustomTheme()
            Dim drag0 As New FormDragHelper(Me, pnlTopBar)
            Dim drag1 As New FormDragHelper(Me, lblTopTitle)
        Catch ex As Exception
            Logger.LogError("Backup_Load error: ", ex)
        End Try
    End Sub

    Protected Overrides Sub ApplyCustomTheme()
        MyBase.ApplyCustomTheme()
        Try
            Dim palette = ThemeManager.Instance.Palette
            If palette Is Nothing Then Return

            If ThemeManager.Instance.IsDark Then
                Me.BackColor = Color.FromArgb(13, 15, 20)
                pnlTopBar.BackColor = Color.FromArgb(20, 24, 33)
                pnlBottomBar.BackColor = Color.FromArgb(20, 24, 33)
                pnlContainer.BackColor = Color.FromArgb(13, 15, 20)

                cardStats.FillColor = Color.FromArgb(26, 31, 43)
                cardStats.BorderColor = Color.FromArgb(42, 47, 59)

                cardActions.FillColor = Color.FromArgb(26, 31, 43)
                cardActions.BorderColor = Color.FromArgb(42, 47, 59)

                cardTable.FillColor = Color.FromArgb(26, 31, 43)
                cardTable.BorderColor = Color.FromArgb(42, 47, 59)

                lblTopTitle.ForeColor = Color.FromArgb(243, 244, 246)
                lblTableTitle.ForeColor = Color.FromArgb(243, 244, 246)
                lblStatsTitle.ForeColor = Color.FromArgb(209, 213, 219)
                lblActionsTitle.ForeColor = Color.FromArgb(209, 213, 219)
                lblFooter.ForeColor = Color.FromArgb(156, 163, 175)

                lblLastBackupTitle.ForeColor = Color.FromArgb(156, 163, 175)
                lblBackupCountTitle.ForeColor = Color.FromArgb(156, 163, 175)
                lblDbSizeTitle.ForeColor = Color.FromArgb(156, 163, 175)

                dgv_backup.BackgroundColor = Color.FromArgb(20, 24, 33)
                dgv_backup.DefaultCellStyle.BackColor = Color.FromArgb(26, 31, 43)
                dgv_backup.DefaultCellStyle.ForeColor = Color.FromArgb(243, 244, 246)
                dgv_backup.RowsDefaultCellStyle.BackColor = Color.FromArgb(20, 24, 33)
                dgv_backup.RowsDefaultCellStyle.ForeColor = Color.FromArgb(243, 244, 246)
                dgv_backup.GridColor = Color.FromArgb(42, 47, 59)
            Else
                Me.BackColor = Color.FromArgb(243, 244, 246)
                pnlTopBar.BackColor = Color.FromArgb(255, 255, 255)
                pnlBottomBar.BackColor = Color.FromArgb(255, 255, 255)
                pnlContainer.BackColor = Color.FromArgb(243, 244, 246)

                cardStats.FillColor = Color.White
                cardStats.BorderColor = Color.FromArgb(229, 231, 235)

                cardActions.FillColor = Color.White
                cardActions.BorderColor = Color.FromArgb(229, 231, 235)

                cardTable.FillColor = Color.White
                cardTable.BorderColor = Color.FromArgb(229, 231, 235)

                lblTopTitle.ForeColor = Color.FromArgb(17, 24, 39)
                lblTableTitle.ForeColor = Color.FromArgb(17, 24, 39)
                lblStatsTitle.ForeColor = Color.FromArgb(55, 65, 81)
                lblActionsTitle.ForeColor = Color.FromArgb(55, 65, 81)
                lblFooter.ForeColor = Color.FromArgb(107, 114, 128)

                lblLastBackupTitle.ForeColor = Color.FromArgb(107, 114, 128)
                lblBackupCountTitle.ForeColor = Color.FromArgb(107, 114, 128)
                lblDbSizeTitle.ForeColor = Color.FromArgb(107, 114, 128)

                dgv_backup.BackgroundColor = Color.FromArgb(249, 250, 251)
                dgv_backup.DefaultCellStyle.BackColor = Color.White
                dgv_backup.DefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39)
                dgv_backup.RowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251)
                dgv_backup.RowsDefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39)
                dgv_backup.GridColor = Color.FromArgb(229, 231, 235)
            End If
        Catch ex As Exception
            Logger.LogError("Backup.ApplyCustomTheme error: ", ex)
        End Try
    End Sub

    Public Sub LoadBackupLog(dgv As DataGridView)
        Try
            Dim oldDt = TryCast(dgv.DataSource, DataTable)
            dgv.DataSource = Nothing
            Try
                oldDt?.Dispose()
            Catch __logEx As Exception
                Logger.LogError("Backup.vb:100", __logEx)
            End Try

            Dim dt As New DataTable
            Dim query As String =
                "SELECT
                    Backup_ID,
                    Backup_File,
                    Backup_Date,
                    Backup_By,
                    Backup_Slot
                 FROM Backup_Log
                 ORDER BY Backup_Date DESC"

            Using cn As SqlConnection = NewConn()
                Using da As New SqlDataAdapter(query, cn)
                    da.SelectCommand.CommandTimeout = 30
                    da.Fill(dt)
                End Using
            End Using

            EnableDoubleBuffer(dgv)
            dgv.DataSource = dt

            If dgv.Columns.Contains("Backup_ID") Then dgv.Columns("Backup_ID").HeaderText = "رقم العملية"
            If dgv.Columns.Contains("Backup_File") Then dgv.Columns("Backup_File").HeaderText = "مسار ملف النسخة"
            If dgv.Columns.Contains("Backup_Date") Then dgv.Columns("Backup_Date").HeaderText = "تاريخ ووقت النسخ"
            If dgv.Columns.Contains("Backup_By") Then dgv.Columns("Backup_By").HeaderText = "المستخدم المسؤول"
            If dgv.Columns.Contains("Backup_Slot") Then dgv.Columns("Backup_Slot").HeaderText = "الفترة المجدولة"

            If dgv.Columns.Contains("Backup_ID") Then dgv.Columns("Backup_ID").FillWeight = 40
            If dgv.Columns.Contains("Backup_File") Then dgv.Columns("Backup_File").FillWeight = 160
            If dgv.Columns.Contains("Backup_Date") Then dgv.Columns("Backup_Date").FillWeight = 70
            If dgv.Columns.Contains("Backup_By") Then dgv.Columns("Backup_By").FillWeight = 60
            If dgv.Columns.Contains("Backup_Slot") Then dgv.Columns("Backup_Slot").FillWeight = 40

            dgv.ClearSelection()
            UpdateInfoStats(dt)

        Catch ex As Exception
            Logger.LogError("LoadBackupLog error: ", ex)
            SmartMessageBox.Show("تعذر تحميل سجل النسخ الاحتياطي: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub UpdateInfoStats(dt As DataTable)
        Try
            lblBackupCount.Text = dt.Rows.Count.ToString() & " نسخة"

            If dt.Rows.Count > 0 Then
                Dim lastDate = Convert.ToDateTime(dt.Rows(0)("Backup_Date"))
                lblLastBackup.Text = lastDate.ToString("yyyy-MM-dd HH:mm")
            Else
                lblLastBackup.Text = "لا توجد نسخ سابقة"
            End If

            Dim dbSize As Double = 0
            Try
                Using cn As SqlConnection = NewConn()
                    Dim q As String = "SELECT (SUM(size) * 8.0) / 1024.0 FROM sys.database_files"
                    Using cmd As New SqlCommand(q, cn)
                        cmd.CommandTimeout = 15
                        Dim res = cmd.ExecuteScalar()
                        If res IsNot Nothing AndAlso res IsNot DBNull.Value Then
                            dbSize = Convert.ToDouble(res)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Logger.LogError("UpdateInfoStats dbSize query: ", ex)
            End Try

            lblDbSize.Text = dbSize.ToString("0.00") & " ميجابايت"
        Catch ex As Exception
            Logger.LogError("UpdateInfoStats error: ", ex)
        End Try
    End Sub

    Private Sub SetupDataGridView(ByVal dgv As DataGridView)
        Try
            Main.datagridviewsetup(dgv)
            dgv.BorderStyle = BorderStyle.None
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.MultiSelect = False
            dgv.ReadOnly = True
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False

            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        Catch ex As Exception
            Logger.LogError("SetupDataGridView error: ", ex)
        End Try
    End Sub

    Private Async Sub btn_Backup_Click(sender As Object, e As EventArgs) Handles btn_Backup.Click
        Try
            SetUiBusy(True, "جاري إنشاء النسخة الاحتياطية لقاعدة البيانات...")

            Dim targetFolder = GetTargetFolder()
            Dim user = If(Not String.IsNullOrWhiteSpace(Session.CurrentUserName), Session.CurrentUserName, "مدير النظام")

            Await Task.Run(Sub() TakeBackup(targetFolder, user))

            LoadBackupLog(dgv_backup)
            lblStatus.Text = "تم إنشاء النسخة الاحتياطية بنجاح"

            Try
                Notify.Toast("تم إنشاء النسخة الاحتياطية بنجاح", Notify.ToastType.Success)
            Catch
                SmartMessageBox.Show("تم إنشاء النسخة الاحتياطية بنجاح في:" & vbCrLf & targetFolder, "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Catch ex As Exception
            lblStatus.Text = "حدث خطأ أثناء أخذ النسخة"
            Logger.LogError("btn_Backup_Click error: ", ex)
            SmartMessageBox.Show("تعذر إنشاء النسخة الاحتياطية: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SetUiBusy(False, "جاهز للعمل...")
        End Try
    End Sub

    Private Async Sub btn_Restore_Click(sender As Object, e As EventArgs) Handles btn_Restore.Click
        If dgv_backup.CurrentRow Is Nothing Then
            SmartMessageBox.Show("يرجى تحديد نسخة احتياطية من الجدول أولاً لاستعادتها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim filePath As String = Convert.ToString(dgv_backup.CurrentRow.Cells("Backup_File").Value)
        Dim backupDate As String = Convert.ToString(dgv_backup.CurrentRow.Cells("Backup_Date").Value)

        If Not File.Exists(filePath) Then
            SmartMessageBox.Show("ملف النسخة الاحتياطية غير موجود في المسار المحدد:" & vbCrLf & filePath, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim confirmMsg = "تنبيه هام جداً!" & vbCrLf & vbCrLf &
                         "أنت على وشك استعادة النسخة الاحتياطية المسجلة بتاريخ: " & backupDate & vbCrLf &
                         "سيتم استبدال جميع البيانات الحالية بالبيانات الموجودة في هذه النسخة." & vbCrLf & vbCrLf &
                         "هل أنت متأكد تماماً من متابعة الاستعادة؟"

        If SmartMessageBox.Show(confirmMsg, "تأكيد استعادة البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                SetUiBusy(True, "جاري استعادة قاعدة البيانات من النسخة الاحتياطية...")

                Await Task.Run(Sub() RestoreBackup(filePath))

                lblStatus.Text = "تمت استعادة قاعدة البيانات بنجاح"
                Try
                    Notify.Toast("تمت استعادة النسخة الاحتياطية بنجاح", Notify.ToastType.Success)
                Catch
                    SmartMessageBox.Show("تمت عملية الاستعادة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Catch ex As Exception
                lblStatus.Text = "فشلت عملية استعادة النسخة"
                Logger.LogError("btn_Restore_Click error: ", ex)
                SmartMessageBox.Show("حدث خطأ أثناء استعادة النسخة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SetUiBusy(False, "جاهز للعمل...")
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgv_backup.CurrentRow Is Nothing Then
            SmartMessageBox.Show("يرجى اختيار النسخة المراد حذفها من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim backupId = dgv_backup.CurrentRow.Cells("Backup_ID").Value
        Dim filePath = Convert.ToString(dgv_backup.CurrentRow.Cells("Backup_File").Value)
        Dim backupDate = Convert.ToString(dgv_backup.CurrentRow.Cells("Backup_Date").Value)

        Dim confirmMsg = "هل أنت متأكد من حذف هذه النسخة الاحتياطية؟" & vbCrLf &
                         "التاريخ: " & backupDate & vbCrLf &
                         "سيتم حذف الملف وسجل العملية نهائياً."

        If SmartMessageBox.Show(confirmMsg, "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                If File.Exists(filePath) Then
                    Try
                        File.Delete(filePath)
                    Catch ex As Exception
                        Logger.LogError("File.Delete backup error: ", ex)
                    End Try
                End If

                Dim q = "DELETE FROM Backup_Log WHERE Backup_ID = @id"
                Using cn = NewConn()
                    Using cmd As New SqlCommand(q, cn)
                        cmd.Parameters.AddWithValue("@id", backupId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadBackupLog(dgv_backup)
                Try
                    Notify.Toast("تم حذف النسخة الاحتياطية بنجاح", Notify.ToastType.Success)
                Catch __logEx As Exception
                    Logger.LogError("Backup.vb:301", __logEx)
                End Try
            Catch ex As Exception
                Logger.LogError("btnDelete_Click error: ", ex)
                SmartMessageBox.Show("تعذر حذف النسخة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnOpenFolder.Click
        Try
            Dim folder = GetTargetFolder()
            If Directory.Exists(folder) Then
                Process.Start(New ProcessStartInfo("explorer.exe", folder) With {.UseShellExecute = True})
            Else
                SmartMessageBox.Show("مجلد النسخ الاحتياطية غير متوفر حالياً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Logger.LogError("btnOpenFolder_Click error: ", ex)
        End Try
    End Sub

    Private Sub SetUiBusy(isBusy As Boolean, statusText As String)
        btn_Backup.Enabled = Not isBusy
        btn_Restore.Enabled = Not isBusy
        btnDelete.Enabled = Not isBusy
        btnOpenFolder.Enabled = Not isBusy
        progressBackup.Visible = isBusy
        lblStatus.Text = statusText
    End Sub

    Private Function GetTargetFolder() As String
        Dim customPath = SettingsManager.GetSetting(SettingsKeys.SystemBackupPath)
        Dim targetFolder As String = ""
        If Not String.IsNullOrWhiteSpace(customPath) Then
            targetFolder = customPath.Trim()
        Else
            Try
                Dim appBak = Path.Combine(Application.StartupPath, "Backups")
                If Not Directory.Exists(appBak) Then Directory.CreateDirectory(appBak)
                targetFolder = appBak
            Catch
                Dim commonBak = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "Backups")
                If Not Directory.Exists(commonBak) Then Directory.CreateDirectory(commonBak)
                targetFolder = commonBak
            End Try
        End If

        Try
            If Not Directory.Exists(targetFolder) Then
                Directory.CreateDirectory(targetFolder)
            End If
        Catch
            Dim docBak = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sestamk", "Backups")
            If Not Directory.Exists(docBak) Then Directory.CreateDirectory(docBak)
            targetFolder = docBak
        End Try

        Return targetFolder
    End Function

    Private Sub btnWinMax_Click(sender As Object, e As EventArgs) Handles btnWinMax.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btnWinClose_Click(sender As Object, e As EventArgs) Handles btnWinClose.Click
        Close()
    End Sub

    Private Sub btnWinMin_Click(sender As Object, e As EventArgs) Handles btnWinMin.Click
        FormHelper.Minimiz(Me)
    End Sub
End Class