Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' واجهة إعدادات المزامنة السحابية (Cloud Sync Settings Panel)
    ''' </summary>
    Public Class UCCloudSyncSettings
        Inherits UserControl
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Private Sub UCCloudSyncSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                LoadSettings()
                ApplyThemeColors()
                LoadSyncLog()
                RefreshSyncStatus()

                AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
            Catch ex As Exception
                ' تجاهل الأخطاء عند التحميل الأول
                Logger.LogError("UCCloudSyncSettings.vb:24", ex)
            End Try
        End Sub

        Private Sub UCCloudSyncSettings_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
            Try
                RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
            Catch __logEx As Exception
                Logger.LogError("UCCloudSyncSettings.vb:33", __logEx)
            End Try
        End Sub

        Private Sub ApplyThemeColors()
            Try
                Dim palette = ThemeManager.Instance.CurrentPalette
                If palette Is Nothing Then Return
                ' يمكن إضافة تخصيص ألوان إضافي هنا
            Catch __logEx As Exception
                Logger.LogError("UCCloudSyncSettings.vb:43", __logEx)
            End Try
        End Sub

        Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
            If Me.IsDisposed OrElse Me.Disposing Then Return
            ApplyThemeColors()
        End Sub

        ' ═══════════════════════════════════════════════════════════
        ' تحميل وحفظ الإعدادات (Load/Save Settings)
        ' ═══════════════════════════════════════════════════════════

        Private Sub LoadSettings()
            Try
                Dim config = Services.Cloud.CloudSyncConfig.Load()
                If config Is Nothing Then Return

                txtTursoUrl.Text = If(config.TursoUrl, "")
                txtAuthToken.Text = If(config.AuthToken, "")

                toggleSyncEnabled.Checked = config.IsSyncEnabled
                txtSyncInterval.Text = config.SyncIntervalSeconds.ToString()

                txtPlatformToken.Text = If(config.PlatformToken, "")
                txtOrgSlug.Text = If(config.OrganizationSlug, "")
                txtDbName.Text = If(config.DatabaseName, "")
            Catch __logEx As Exception
                ' تجاهل إذا لم يوجد ملف إعدادات بعد
                Logger.LogError("UCCloudSyncSettings.vb:71", __logEx)
            End Try
        End Sub

        Private Sub SaveSettings()
            Try
                Dim config As New Services.Cloud.CloudSyncSettings()
                config.TursoUrl = txtTursoUrl.Text.Trim()
                config.AuthToken = txtAuthToken.Text.Trim()
                config.IsSyncEnabled = toggleSyncEnabled.Checked

                Dim interval As Integer
                If Integer.TryParse(txtSyncInterval.Text.Trim(), interval) AndAlso interval >= 5 Then
                    config.SyncIntervalSeconds = interval
                Else
                    config.SyncIntervalSeconds = 30
                End If

                config.PlatformToken = txtPlatformToken.Text.Trim()
                config.OrganizationSlug = txtOrgSlug.Text.Trim()
                config.DatabaseName = txtDbName.Text.Trim()
                config.DeviceId = Services.Cloud.CloudSyncConfig.GetOrCreateDeviceId()

                Services.Cloud.CloudSyncConfig.Save(config)

                If config.IsSyncEnabled Then
                    Services.Cloud.CloudSyncService.Instance.StartBackgroundSync()
                Else
                    Services.Cloud.CloudSyncService.Instance.StopBackgroundSync()
                End If

                Notify.Toast("تم حفظ إعدادات المزامنة السحابية بنجاح ✅", Notify.ToastType.Success)
            Catch ex As Exception
                SmartMessageBox.Show("خطأ أثناء حفظ الإعدادات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ' ═══════════════════════════════════════════════════════════
        ' حالة المزامنة (Sync Status)
        ' ═══════════════════════════════════════════════════════════

        Private Sub RefreshSyncStatus()
            Try
                ' فحص حالة التهيئة
                Dim config = Services.Cloud.CloudSyncConfig.Load()
                Dim isConfigured = config IsNot Nothing AndAlso
                                   Not String.IsNullOrWhiteSpace(config.TursoUrl) AndAlso
                                   Not String.IsNullOrWhiteSpace(config.AuthToken)

                If Not isConfigured Then
                    lblSyncStatus.Text = "غير مهيأ"
                    lblSyncStatus.ForeColor = Drawing.Color.FromArgb(255, 183, 77)
                    lblLastSyncTime.Text = "---"
                    lblPendingChanges.Text = "0"
                    Return
                End If

                If Not config.IsSyncEnabled Then
                    lblSyncStatus.Text = "متوقف"
                    lblSyncStatus.ForeColor = Drawing.Color.FromArgb(180, 180, 190)
                Else
                    lblSyncStatus.Text = "مفعّل وجاهز"
                    lblSyncStatus.ForeColor = Drawing.Color.FromArgb(76, 175, 80)
                End If

                ' استعلام عدد التغييرات المعلقة من _SyncLog
                Using conn = DBModule.NewConn()
                    If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then Return

                    Try
                        Using cmd As New SqlCommand("SELECT COUNT(*) FROM _SyncLog WHERE IsSynced = 0", conn)
                            Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                            lblPendingChanges.Text = count.ToString()
                        End Using
                    Catch
                        lblPendingChanges.Text = "---"
                    End Try

                    Try
                        Using cmd As New SqlCommand("SELECT MAX(SyncedAt) FROM _SyncLog WHERE IsSynced = 1", conn)
                            Dim lastSync = cmd.ExecuteScalar()
                            If lastSync IsNot DBNull.Value AndAlso lastSync IsNot Nothing Then
                                lblLastSyncTime.Text = Convert.ToDateTime(lastSync).ToString("yyyy/MM/dd hh:mm tt")
                            Else
                                lblLastSyncTime.Text = "لم تتم بعد"
                            End If
                        End Using
                    Catch
                        lblLastSyncTime.Text = "---"
                    End Try
                End Using
            Catch
                lblSyncStatus.Text = "خطأ"
                lblSyncStatus.ForeColor = Drawing.Color.FromArgb(244, 67, 54)
            End Try
        End Sub

        ' ═══════════════════════════════════════════════════════════
        ' اختبار الاتصال (Test Connection)
        ' ═══════════════════════════════════════════════════════════

        Private Async Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
            lblConnectionResult.Text = "⏳ جاري اختبار الاتصال..."
            lblConnectionResult.ForeColor = Drawing.Color.FromArgb(100, 181, 246)
            btnTestConnection.Enabled = False

            Try
                Dim url = txtTursoUrl.Text.Trim()
                Dim token = txtAuthToken.Text.Trim()

                If String.IsNullOrWhiteSpace(url) OrElse String.IsNullOrWhiteSpace(token) Then
                    lblConnectionResult.Text = "⚠️ أدخل الرابط ورمز المصادقة أولاً"
                    lblConnectionResult.ForeColor = Drawing.Color.FromArgb(255, 183, 77)
                    Return
                End If

                Using client As New Services.Cloud.TursoHttpClient(url, token)
                    Dim isOk = Await client.TestConnectionAsync().ConfigureAwait(True)
                    If isOk Then
                        lblConnectionResult.Text = "✅ الاتصال ناجح!"
                        lblConnectionResult.ForeColor = Drawing.Color.FromArgb(76, 175, 80)
                    Else
                        lblConnectionResult.Text = "❌ فشل الاتصال"
                        lblConnectionResult.ForeColor = Drawing.Color.FromArgb(244, 67, 54)
                    End If
                End Using
            Catch ex As Exception
                lblConnectionResult.Text = "❌ " & ex.Message
                lblConnectionResult.ForeColor = Drawing.Color.FromArgb(244, 67, 54)
            Finally
                btnTestConnection.Enabled = True
            End Try
        End Sub

        ' ═══════════════════════════════════════════════════════════
        ' سجل المزامنة (Sync Log)
        ' ═══════════════════════════════════════════════════════════

        Private Sub LoadSyncLog()
            Try
                Using conn = DBModule.NewConn()
                    If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then Return

                    Dim sql = "SELECT TOP 50 LogId, TableName AS N'الجدول', Operation AS N'العملية', " &
                              "CreatedAt AS N'الوقت', CASE WHEN IsSynced = 1 THEN N'تم' ELSE N'معلق' END AS N'الحالة', " &
                              "ErrorMessage AS N'الخطأ' FROM _SyncLog ORDER BY CreatedAt DESC"
                    Using cmd As New SqlCommand(sql, conn)
                        Using da As New SqlDataAdapter(cmd)
                            Dim dt As New DataTable()
                            da.Fill(dt)
                            dgvSyncLog.DataSource = dt
                        End Using
                    End Using
                End Using
            Catch __logEx As Exception
                ' تجاهل إذا الجدول غير موجود بعد
                Logger.LogError("UCCloudSyncSettings.vb:227", __logEx)
            End Try
        End Sub

        ' ═══════════════════════════════════════════════════════════
        ' أحداث الأزرار (Button Events)
        ' ═══════════════════════════════════════════════════════════

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            SaveSettings()
            RefreshSyncStatus()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If SmartMessageBox.Show("هل أنت متأكد من إعادة ضبط إعدادات المزامنة السحابية؟",
                               "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                txtTursoUrl.Clear()
                txtAuthToken.Clear()
                txtPlatformToken.Clear()
                txtOrgSlug.Clear()
                txtDbName.Clear()
                toggleSyncEnabled.Checked = False
                txtSyncInterval.Text = "30"
            End If
        End Sub

        Private Async Sub btnSyncNow_Click(sender As Object, e As EventArgs) Handles btnSyncNow.Click
            btnSyncNow.Enabled = False
            lblSyncStatus.Text = "مزامنة جارية..."
            lblSyncStatus.ForeColor = Drawing.Color.FromArgb(255, 183, 77)

            Try
                Dim result = Await Services.Cloud.CloudSyncService.Instance.TriggerSyncAsync().ConfigureAwait(True)

                RefreshSyncStatus()
                LoadSyncLog()

                If result.Status = SyncStatus.Success Then
                    Notify.Toast($"تمت المزامنة بنجاح ✅ (مرسل: {result.TotalPushed}، مستلم: {result.TotalPulled})", Notify.ToastType.Success)
                ElseIf result.Status = SyncStatus.PartialSuccess Then
                    Notify.Toast($"اكتملت المزامنة مع تنبيهات ⚠️ (مرسل: {result.TotalPushed}، مستلم: {result.TotalPulled})", Notify.ToastType.Warning)
                ElseIf result.Status = SyncStatus.Offline Then
                    SmartMessageBox.Show("لا يوجد اتصال بالإنترنت حالياً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Dim err = If(result.Errors.Count > 0, String.Join(Environment.NewLine, result.Errors), "فشلت المزامنة.")
                    SmartMessageBox.Show(err, "خطأ في المزامنة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                SmartMessageBox.Show("خطأ أثناء المزامنة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                btnSyncNow.Enabled = True
            End Try
        End Sub

        Private Sub btnRefreshStatus_Click(sender As Object, e As EventArgs) Handles btnRefreshStatus.Click
            RefreshSyncStatus()
            LoadSyncLog()
        End Sub

        Private Sub btnClearLog_Click(sender As Object, e As EventArgs) Handles btnClearLog.Click
            If SmartMessageBox.Show("هل أنت متأكد من مسح سجل المزامنة بالكامل؟",
                               "تأكيد المسح", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Using conn = DBModule.NewConn()
                        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then Return
                        Using cmd As New SqlCommand("DELETE FROM _SyncLog", conn)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    LoadSyncLog()
                    Notify.Toast("تم مسح سجل المزامنة ✅", Notify.ToastType.Success)
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء مسح السجل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub btnToggleTokenVisibility_Click(sender As Object, e As EventArgs) Handles btnToggleTokenVisibility.Click
            txtAuthToken.UseSystemPasswordChar = Not txtAuthToken.UseSystemPasswordChar
            btnToggleTokenVisibility.Text = If(txtAuthToken.UseSystemPasswordChar, "👁", "🔒")
        End Sub

    End Class
End Namespace
