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

        Private Async Sub UCCloudSyncSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                ' إخفاء بطاقة تفاصيل المنصة التقنية عن المستخدم العادي
                cardPlatform.Visible = False
                txtTursoUrl.ReadOnly = True
                txtAuthToken.ReadOnly = True

                ' جلب معلومات المنشأة من كاش الترخيص
                Dim lic = LicenseCache.Load()
                If lic IsNot Nothing Then
                    Dim comp = Convert.ToString(If(lic("company_name"), lic("shop_name")))
                    Dim ser = Convert.ToString(lic("saved_serial"))
                    lblCompanyInfo.Text = $"المنشأة: {comp} | كود الترخيص: {ser}"
                Else
                    lblCompanyInfo.Text = "المنشأة: غير محددة (يرجى تفعيل البرنامج أولاً)"
                End If

                ' تنظيف أي سجلات قديمة أو معلقة لجدول الصلاحيات تلقائياً لحل مشكلة التغييرات المعلقة الزائفة
                Using conn = DBModule.NewConn()
                    If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                        Try
                            Using cmdClean As New SqlCommand("DELETE FROM _SyncLog WHERE TableName = 'Permissions'; IF OBJECT_ID('dbo.[TR_Permissions_SyncTrack]', 'TR') IS NOT NULL DROP TRIGGER [dbo].[TR_Permissions_SyncTrack];", conn)
                                cmdClean.ExecuteNonQuery()
                            End Using
                        Catch
                        End Try
                    End If
                End Using

                ' التأكد من تهيئة الربط تلقائياً من الترخيص
                If Not Services.Cloud.CloudSyncConfig.IsConfigured() Then
                    Await Services.Cloud.CloudSyncConfig.EnsureConfigFromLicenseAsync().ConfigureAwait(True)
                End If

                LoadSettings()
                ApplyThemeColors()
                LoadSyncLog()
                RefreshSyncStatus()
                LoadCompanyDevices()

                AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
                AddHandler Services.Cloud.CloudSyncService.Instance.SyncProgress, AddressOf OnSyncProgress
                AddHandler Services.Cloud.CloudSyncService.Instance.SyncCompleted, AddressOf OnSyncCompleted
            Catch ex As Exception
                ' تجاهل الأخطاء عند التحميل الأول
                Logger.LogError("UCCloudSyncSettings.vb:24", ex)
            End Try
        End Sub

        Private Sub UCCloudSyncSettings_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
            Try
                RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
                RemoveHandler Services.Cloud.CloudSyncService.Instance.SyncProgress, AddressOf OnSyncProgress
                RemoveHandler Services.Cloud.CloudSyncService.Instance.SyncCompleted, AddressOf OnSyncCompleted
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
                ' تحديث بيانات المنشأة المعروضة للمستخدم
                Dim lic = LicenseCache.Load()
                Dim compName = If(lic IsNot Nothing, Convert.ToString(If(lic("company_name"), lic("shop_name"))), "")
                Dim serial = If(lic IsNot Nothing, Convert.ToString(lic("saved_serial")), "")

                If Not String.IsNullOrWhiteSpace(compName) Then
                    lblCompanyInfo.Text = $"المنشأة: {compName} | كود الترخيص: {serial}"
                Else
                    lblCompanyInfo.Text = "المنشأة: جاري التحقق من الترخيص..."
                End If

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
                Logger.LogError("UCCloudSyncSettings.LoadSettings", __logEx)
            End Try
        End Sub

        Private Sub SaveSettings()
            Try
                Dim config = Services.Cloud.CloudSyncConfig.Load()
                If config Is Nothing Then config = New Services.Cloud.CloudSyncSettings()

                ' تحديث تفضيلات المستخدم
                config.IsSyncEnabled = toggleSyncEnabled.Checked

                Dim interval As Integer
                If Integer.TryParse(txtSyncInterval.Text.Trim(), interval) AndAlso interval >= 5 Then
                    config.SyncIntervalSeconds = interval
                Else
                    config.SyncIntervalSeconds = 30
                End If

                If Not String.IsNullOrWhiteSpace(txtTursoUrl.Text) Then config.TursoUrl = txtTursoUrl.Text.Trim()
                If Not String.IsNullOrWhiteSpace(txtAuthToken.Text) Then config.AuthToken = txtAuthToken.Text.Trim()

                config.DeviceId = Services.Cloud.CloudSyncConfig.GetOrCreateDeviceId()

                Services.Cloud.CloudSyncConfig.Save(config)

                If config.IsSyncEnabled Then
                    Services.Cloud.CloudSyncService.Instance.StartBackgroundSync(config.SyncIntervalSeconds)
                Else
                    Services.Cloud.CloudSyncService.Instance.StopBackgroundSync()
                End If

                Notify.Toast("تم حفظ إعدادات المزامنة بنجاح ✅", Notify.ToastType.Success)
            Catch ex As Exception
                SmartMessageBox.Show("خطأ أثناء حفظ الإعدادات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Async Sub btnSyncFromLicense_Click(sender As Object, e As EventArgs) Handles btnSyncFromLicense.Click
            btnSyncFromLicense.Enabled = False
            lblConnectionResult.Text = "⏳ جاري جلب إعدادات المزامنة والتحقق من قاعدة المنشأة السحابية..."
            lblConnectionResult.ForeColor = Drawing.Color.FromArgb(100, 181, 246)

            Try
                Dim ok = Await Services.Cloud.CloudSyncConfig.EnsureConfigFromLicenseAsync().ConfigureAwait(True)
                If ok Then
                    LoadSettings()
                    RefreshSyncStatus()
                    lblConnectionResult.Text = "✅ تم ربط وتجهيز قاعدة البيانات السحابية لمنشأتك بنجاح!"
                    lblConnectionResult.ForeColor = Drawing.Color.FromArgb(76, 175, 80)
                    Notify.Toast("تم تحديث الربط السحابي تلقائياً من الترخيص ✅", Notify.ToastType.Success)
                Else
                    lblConnectionResult.Text = "⚠️ يرجى التأكد من تفعيل البرنامج أولاً لجلب الربط."
                    lblConnectionResult.ForeColor = Drawing.Color.FromArgb(255, 183, 77)
                End If
            Catch ex As Exception
                lblConnectionResult.Text = "❌ " & ex.Message
                lblConnectionResult.ForeColor = Drawing.Color.FromArgb(244, 67, 54)
            Finally
                btnSyncFromLicense.Enabled = True
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
                        Using cmd As New SqlCommand("SELECT COUNT(*) FROM _SyncLog WHERE IsSynced = 0 AND TableName <> 'Permissions'", conn)
                            Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                            lblPendingChanges.Text = count.ToString()
                        End Using
                    Catch
                        lblPendingChanges.Text = "0"
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
            lblConnectionResult.Text = "⏳ جاري فحص الاتصال بالقاعدة السحابية..."
            lblConnectionResult.ForeColor = Drawing.Color.FromArgb(100, 181, 246)
            btnTestConnection.Enabled = False

            Try
                Dim config = Services.Cloud.CloudSyncConfig.Load()
                If config Is Nothing OrElse String.IsNullOrWhiteSpace(config.TursoUrl) OrElse String.IsNullOrWhiteSpace(config.AuthToken) Then
                    lblConnectionResult.Text = "⚠️ لم يتم تهيئة الربط السحابي بعد. يرجى تفعيل البرنامج أولاً."
                    lblConnectionResult.ForeColor = Drawing.Color.FromArgb(255, 183, 77)
                    Return
                End If

                Using client As New Services.Cloud.TursoHttpClient(config.TursoUrl, config.AuthToken)
                    Dim isOk = Await client.TestConnectionAsync().ConfigureAwait(True)
                    If isOk Then
                        lblConnectionResult.Text = "✅ الاتصال بالقاعدة السحابية للمنشأة ناجح ومستقر!"
                        lblConnectionResult.ForeColor = Drawing.Color.FromArgb(76, 175, 80)
                    Else
                        lblConnectionResult.Text = "❌ فشل الاتصال بقاعدة المنشأة السحابية."
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

                    Dim sql = "SELECT TOP 50 LogId AS [Log ID], TableName AS N'الجدول', " &
                              "CASE Operation WHEN 'I' THEN N'➕ إضافة' WHEN 'U' THEN N'✏️ تعديل' WHEN 'D' THEN N'❌ حذف' ELSE Operation END AS N'العملية', " &
                              "CreatedAt AS N'الوقت', CASE WHEN IsSynced = 1 THEN N'✅ تم' ELSE N'⏳ معلق' END AS N'الحالة', " &
                              "ISNULL(ErrorMessage, N'—') AS N'الخطأ / الملاحظات' FROM _SyncLog WHERE TableName <> 'Permissions' ORDER BY CreatedAt DESC"
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

        ' ═══════════════════════════════════════════════════════════
        ' أجهزة المنشأة وشريط التقدم اللحظي (Devices & Live Progress)
        ' ═══════════════════════════════════════════════════════════

        Private Sub OnSyncProgress(sender As Object, e As SyncProgressEventArgs)
            If Me.InvokeRequired Then
                Me.BeginInvoke(New Action(Of Object, SyncProgressEventArgs)(AddressOf OnSyncProgress), sender, e)
                Return
            End If

            prgSyncProgress.Visible = True
            lblSyncProgressText.Visible = True

            If e.Operation = "push" Then
                Dim pct = Math.Min(50, Math.Max(10, CInt((e.CurrentRow / Math.Max(1, e.TotalRows)) * 50)))
                prgSyncProgress.Value = pct
                lblSyncProgressText.Text = $"⬆️ {e.Message}"
            ElseIf e.Operation = "pull" Then
                Dim basePct = 50
                Dim tablePct = CInt((e.CurrentTable / Math.Max(1, e.TotalTables)) * 50)
                prgSyncProgress.Value = Math.Min(100, basePct + tablePct)
                lblSyncProgressText.Text = $"⬇️ {e.Message}"
            Else
                lblSyncProgressText.Text = e.Message
            End If
        End Sub

        Private Sub OnSyncCompleted(sender As Object, e As SyncResult)
            If Me.InvokeRequired Then
                Me.BeginInvoke(New Action(Of Object, SyncResult)(AddressOf OnSyncCompleted), sender, e)
                Return
            End If

            prgSyncProgress.Value = 100
            lblSyncProgressText.Text = "✅ اكتملت المزامنة بنجاح"
            Task.Delay(3000).ContinueWith(Sub()
                                              If Not Me.IsDisposed Then
                                                  Me.BeginInvoke(Sub()
                                                                     prgSyncProgress.Visible = False
                                                                     lblSyncProgressText.Visible = False
                                                                 End Sub)
                                              End If
                                          End Sub)
            RefreshSyncStatus()
            LoadSyncLog()
            LoadCompanyDevices()
        End Sub

        Private Async Sub LoadCompanyDevices()
            Try
                Dim devices = Await Services.Cloud.CloudSyncConfig.GetCompanyDevicesAsync().ConfigureAwait(True)
                Dim dt As New DataTable()
                dt.Columns.Add("اسم الجهاز", GetType(String))
                dt.Columns.Add("نوع الجهاز", GetType(String))
                dt.Columns.Add("الإصدار", GetType(String))
                dt.Columns.Add("آخر ظهور / مزامنة", GetType(String))
                dt.Columns.Add("حركات مرسلة", GetType(String))
                dt.Columns.Add("حركات مستلمة", GetType(String))
                dt.Columns.Add("نظام التشغيل", GetType(String))

                For Each dev In devices
                    Dim nameDisplay = If(dev.IsCurrentDevice, $"{dev.DeviceName} (هذا الجهاز ⭐)", dev.DeviceName)
                    dt.Rows.Add(nameDisplay, dev.DeviceTypeDisplay, dev.AppVersion, dev.LastSeenDisplay, dev.TotalPushed.ToString("N0"), dev.TotalPulled.ToString("N0"), dev.OsInfo)
                Next

                dgvDevices.DataSource = dt
                lblDevicesCount.Text = $"{devices.Count} أجهزة مسجلة بالمنشأة"
            Catch ex As Exception
                Logger.LogError("UCCloudSyncSettings.LoadCompanyDevices", ex)
            End Try
        End Sub

        Private Sub btnRefreshDevices_Click(sender As Object, e As EventArgs) Handles btnRefreshDevices.Click
            LoadCompanyDevices()
        End Sub

    End Class
End Namespace
