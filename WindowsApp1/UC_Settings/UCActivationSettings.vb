Imports System.Drawing
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports WindowsApp1.Services.Sync

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات التفعيل والترخيص السحابي ومزامنة المستخدمين وبصمة الجهاز
    ''' </summary>
    Public Class UCActivationSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCActivationSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                lblHWID.Text = HardwareFingerprint.GetCurrent()
                LoadLicenseData()
            Catch ex As Exception
                Debug.WriteLine("UCActivationSettings_Load error: " & ex.Message)
            End Try
        End Sub

        Public Sub LoadLicenseData()
            Try
                lblHWID.Text = HardwareFingerprint.GetCurrent()
                Dim license = LicenseCache.Load()

                If license IsNot Nothing Then
                    Dim status = Convert.ToString(license("status")).ToLowerInvariant()
                    Dim expiresAtStr = Convert.ToString(license("expires_at"))
                    Dim expiresAt As DateTime
                    Dim hasExpiry = DateTime.TryParse(expiresAtStr, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, expiresAt) OrElse DateTime.TryParse(expiresAtStr, expiresAt)

                    Dim graceDays = 0
                    Dim graceToken = license("grace_days")
                    If graceToken IsNot Nothing Then Integer.TryParse(Convert.ToString(graceToken), graceDays)

                    Dim effectiveExpiry = If(hasExpiry, expiresAt.Date.AddDays(graceDays), DateTime.MaxValue)

                    ' حساب وتحديد حالة الاشتراك وفترة السماح بدقة متناهية
                    If hasExpiry AndAlso DateTime.Today > effectiveExpiry Then
                        lblStatus.Text = "❌ منتهي الصلاحية"
                        lblStatus.ForeColor = Color.FromArgb(248, 113, 113)
                        pnlStatusBadge.FillColor = Color.FromArgb(45, 20, 20)
                        pnlStatusBadge.BorderColor = Color.FromArgb(239, 68, 68)
                    ElseIf hasExpiry AndAlso DateTime.Today > expiresAt.Date Then
                        Dim remainingGrace = Math.Max(0, (effectiveExpiry - DateTime.Today).Days)
                        lblStatus.Text = $"⚠️ فترة سماح ({remainingGrace} يوم)"
                        lblStatus.ForeColor = Color.FromArgb(251, 191, 36)
                        pnlStatusBadge.FillColor = Color.FromArgb(48, 36, 12)
                        pnlStatusBadge.BorderColor = Color.FromArgb(245, 158, 11)
                    ElseIf status = "grace_period" Then
                        Dim remainingGrace = If(hasExpiry, Math.Max(0, (effectiveExpiry - DateTime.Today).Days), graceDays)
                        lblStatus.Text = $"⚠️ فترة سماح ({remainingGrace} يوم)"
                        lblStatus.ForeColor = Color.FromArgb(251, 191, 36)
                        pnlStatusBadge.FillColor = Color.FromArgb(48, 36, 12)
                        pnlStatusBadge.BorderColor = Color.FromArgb(245, 158, 11)
                    ElseIf status = "active" Then
                        lblStatus.Text = "● الترخيص نشط ومصرّح به"
                        lblStatus.ForeColor = Color.FromArgb(52, 211, 153)
                        pnlStatusBadge.FillColor = Color.FromArgb(15, 47, 36)
                        pnlStatusBadge.BorderColor = Color.FromArgb(16, 185, 129)
                    Else
                        lblStatus.Text = "غير مفعل (" & status & ")"
                        lblStatus.ForeColor = Color.FromArgb(248, 113, 113)
                        pnlStatusBadge.FillColor = Color.FromArgb(45, 20, 20)
                        pnlStatusBadge.BorderColor = Color.FromArgb(239, 68, 68)
                    End If

                    ' فترة السماح
                    lblGracePeriod.Text = If(graceDays > 0, $"{graceDays} أيام سماح بعد الانتهاء", "بدون فترة سماح")

                    ' تاريخ البداية
                    Dim createdAtStr = Convert.ToString(license("created_at"))
                    Dim createdAt As DateTime
                    If DateTime.TryParse(createdAtStr, createdAt) Then
                        lblStartDate.Text = createdAt.ToString("yyyy-MM-dd")
                    Else
                        lblStartDate.Text = If(String.IsNullOrWhiteSpace(createdAtStr), "-", createdAtStr)
                    End If

                    ' تاريخ الانتهاء
                    If hasExpiry Then
                        lblExpiryDate.Text = expiresAt.ToString("yyyy-MM-dd")
                    Else
                        lblExpiryDate.Text = If(String.IsNullOrWhiteSpace(expiresAtStr), "-", expiresAtStr)
                    End If

                    ' السيريال
                    Dim serial = Convert.ToString(license("saved_serial"))
                    lblSerial.Text = If(String.IsNullOrWhiteSpace(serial), "غير متوفر", serial)

                    ' اسم الشركة
                    Dim company = Convert.ToString(license("company_name"))
                    lblCompanyName.Text = If(String.IsNullOrWhiteSpace(company), "شركة عامة", company)

                    ' كود / معرف الشركة
                    Dim companyId = Convert.ToString(license("company_id"))
                    lblCompanyId.Text = If(String.IsNullOrWhiteSpace(companyId), "-", companyId)

                    ' نوع الخطة
                    Dim plan = Convert.ToString(license("plan"))
                    lblPlanName.Text = If(String.IsNullOrWhiteSpace(plan), "PRO", plan.ToUpperInvariant())

                    ' قناة التحديث
                    Dim channel = Convert.ToString(license("channel")).ToUpperInvariant()
                    Dim channelDisplay = "قناة عامة مستقرة (PUBLIC)"
                    If channel = "BETA" Then
                        channelDisplay = "قناة تجريبية (BETA)"
                        lblChannel.Text = channelDisplay
                        lblChannel.ForeColor = Color.FromArgb(245, 158, 11)
                    Else
                        lblChannel.Text = channelDisplay
                        lblChannel.ForeColor = Color.FromArgb(52, 211, 153)
                    End If

                    ' تحديث شريط الملخص العلوي (Hero Banner)
                    lblHeroCompany.Text = $"الشركة المرخصة: {lblCompanyName.Text}"
                    lblHeroPlan.Text = $"الخطة السحابية: {lblPlanName.Text}  |  {channelDisplay}"
                    lblHeroExpiry.Text = If(hasExpiry, $"تاريخ الانتهاء: {expiresAt:yyyy-MM-dd}", "تاريخ الانتهاء: دائم / غير محدد")
                    lblHeroGrace.Text = $"فترة السماح: {lblGracePeriod.Text}"

                    ' الأجهزة والمستخدمين
                    Dim maxDevices = Convert.ToString(license("max_devices"))
                    lblMaxDevices.Text = If(String.IsNullOrWhiteSpace(maxDevices), "-", $"{maxDevices} أجهزة")

                    Dim maxUsers = Convert.ToString(license("max_users"))
                    lblMaxUsers.Text = If(String.IsNullOrWhiteSpace(maxUsers), "-", $"{maxUsers} مستخدمين")

                    ' التكلفة والعملة
                    If String.Equals(plan, "trial", StringComparison.OrdinalIgnoreCase) Then
                        lblPrice.Text = "نسخة تجريبية مجانية"
                        lblPrice.ForeColor = Color.FromArgb(251, 191, 36)
                    Else
                        Dim priceVal As Decimal = 0
                        Dim priceStr = Convert.ToString(license("price"))
                        Decimal.TryParse(priceStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, priceVal)

                        Dim rawCurrency = Convert.ToString(license("currency"))?.Trim()
                        Dim displayCurrency = "ج.م"
                        If Not String.IsNullOrWhiteSpace(rawCurrency) Then
                            If rawCurrency.Equals("EGP", StringComparison.OrdinalIgnoreCase) OrElse rawCurrency.Contains("جني") OrElse rawCurrency.Contains("ج.م") Then
                                displayCurrency = "ج.م"
                            ElseIf rawCurrency.Equals("USD", StringComparison.OrdinalIgnoreCase) OrElse rawCurrency = "$" Then
                                displayCurrency = "$"
                            ElseIf rawCurrency.Equals("SAR", StringComparison.OrdinalIgnoreCase) OrElse rawCurrency.Contains("ريال") Then
                                displayCurrency = "ر.س"
                            Else
                                displayCurrency = rawCurrency
                            End If
                        End If

                        If priceVal > 0 Then
                            lblPrice.Text = $"{priceVal:N2} {displayCurrency}"
                        Else
                            lblPrice.Text = $"0.00 {displayCurrency}"
                        End If
                        lblPrice.ForeColor = Color.White
                    End If

                    ' حالة الجهاز والإصدار
                    Dim appVer = Application.ProductVersion
                    lblDeviceStatus.Text = $"الجهاز: {Environment.MachineName}  |  الحالة: نشط ومصرّح بالعمل ✅  |  الإصدار: v{appVer}"
                    lblDeviceStatus.ForeColor = Color.FromArgb(52, 211, 153)

                    ' آخر اتصال ومزامنة
                    Dim syncStr = Convert.ToString(If(license("last_successful_sync_utc"), license("last_successful_sync")))
                    Dim syncDt As DateTime
                    If DateTime.TryParse(syncStr, syncDt) Then
                        lblLastSync.Text = syncDt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") & " (متصل ومحدث لحظياً)"
                    Else
                        lblLastSync.Text = "نشط ومتصل بالخادم السحابي"
                    End If

                Else
                    lblStatus.Text = "⚠️ غير مفعل"
                    lblStatus.ForeColor = Color.FromArgb(248, 113, 113)
                    pnlStatusBadge.FillColor = Color.FromArgb(45, 20, 20)
                    pnlStatusBadge.BorderColor = Color.FromArgb(239, 68, 68)

                    lblHeroCompany.Text = "الشركة المرخصة: -"
                    lblHeroPlan.Text = "الخطة: غير محدد"
                    lblHeroExpiry.Text = "تاريخ الانتهاء: -"
                    lblHeroGrace.Text = "فترة السماح: -"

                    lblStartDate.Text = "-"
                    lblExpiryDate.Text = "-"
                    lblGracePeriod.Text = "-"
                    lblSerial.Text = "لا يوجد سيريال مفعل"
                    lblCompanyName.Text = "-"
                    lblCompanyId.Text = "-"
                    lblPlanName.Text = "-"
                    lblChannel.Text = "-"
                    lblMaxDevices.Text = "-"
                    lblMaxUsers.Text = "-"
                    lblPrice.Text = "-"
                    lblDeviceStatus.Text = $"الجهاز: {Environment.MachineName} | الإصدار: v{Application.ProductVersion}"
                    lblLastSync.Text = "-"
                End If
            Catch ex As Exception
                Debug.WriteLine("LoadLicenseData error: " & ex.Message)
            End Try
        End Sub

        Private Sub btnCopyHWID_Click(sender As Object, e As EventArgs) Handles btnCopyHWID.Click
            Try
                If Not String.IsNullOrWhiteSpace(lblHWID.Text) AndAlso lblHWID.Text <> "-" Then
                    Clipboard.SetText(lblHWID.Text)
                    Try
                        Notify.Toast("تم نسخ بصمة الجهاز إلى الحافظة بنجاح ✅", Notify.ToastType.Success)
                    Catch
                        SmartMessageBox.Show("تم نسخ بصمة الجهاز (HWID) بنجاح.", "تم النسخ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Catch ex As Exception
                SmartMessageBox.Show("تعذر النسخ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub btnCopySerial_Click(sender As Object, e As EventArgs) Handles btnCopySerial.Click
            Try
                If Not String.IsNullOrWhiteSpace(lblSerial.Text) AndAlso lblSerial.Text <> "-" AndAlso lblSerial.Text <> "غير متوفر" Then
                    Clipboard.SetText(lblSerial.Text)
                    Try
                        Notify.Toast("تم نسخ مفتاح الترخيص إلى الحافظة بنجاح ✅", Notify.ToastType.Success)
                    Catch
                        SmartMessageBox.Show("تم نسخ مفتاح الترخيص بنجاح.", "تم النسخ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Catch ex As Exception
                SmartMessageBox.Show("تعذر النسخ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub btnCopyCompanyId_Click(sender As Object, e As EventArgs) Handles btnCopyCompanyId.Click
            Try
                If Not String.IsNullOrWhiteSpace(lblCompanyId.Text) AndAlso lblCompanyId.Text <> "-" Then
                    Clipboard.SetText(lblCompanyId.Text)
                    Try
                        Notify.Toast("تم نسخ معرّف الشركة إلى الحافظة بنجاح ✅", Notify.ToastType.Success)
                    Catch
                        SmartMessageBox.Show("تم نسخ معرّف الشركة بنجاح.", "تم النسخ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Catch ex As Exception
                SmartMessageBox.Show("تعذر النسخ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub btnChangeSerial_Click(sender As Object, e As EventArgs) Handles btnChangeSerial.Click
            Try
                Using frm As New FormActivation()
                    If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                        LoadLicenseData()
                        ' مزامنة فورية بعد تفعيل سيريال جديد
                        Task.Run(Async Function()
                                     Try
                                         Await UserSyncService.SyncAsync()
                                     Catch __logEx As Exception
                                         Logger.LogError("UCActivationSettings.vb:264", __logEx)
                                     End Try
                                 End Function)
                        Try
                            Notify.Toast("تم تحديث بيانات التفعيل والربط السحابي بنجاح ✅", Notify.ToastType.Success)
                        Catch __logEx As Exception
                            Logger.LogError("UCActivationSettings.vb:270", __logEx)
                        End Try
                    End If
                End Using
            Catch ex As Exception
                SmartMessageBox.Show("خطأ أثناء فتح نافذة التفعيل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Async Sub btnCheckUpdate_Click(sender As Object, e As EventArgs) Handles btnCheckUpdate.Click
            btnCheckUpdate.Enabled = False
            btnCheckUpdate.Text = "جاري الفحص..."
            Try
                Dim license = LicenseCache.Load()
                Dim found = Await UpdateCoordinator.CheckAndPromptAsync(license, Me.FindForm())
                If Not found Then
                    Try
                        Notify.Toast("أنت تستخدم أحدث إصدار متوفر بالفعل! 🎉", Notify.ToastType.Info)
                    Catch
                        SmartMessageBox.Show("أنت تستخدم أحدث إصدار متوفر بالفعل من البرنامج.", "لا يوجد تحديثات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Catch ex As Exception
                SmartMessageBox.Show("خطأ أثناء فحص التحديثات: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                btnCheckUpdate.Enabled = True
                btnCheckUpdate.Text = "🚀 البحث عن تحديثات للبرنامج"
            End Try
        End Sub

        Private Async Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            btnRefresh.Enabled = False
            btnRefresh.Text = "جاري الفحص والمزامنة..."
            Try
                ' 1. التحقق من الترخيص أونلاين
                Dim result = Await LicenseBootstrapper.CheckAsync(forceOnlineCheck:=True)

                ' 2. مزامنة المستخدمين وسحب إعادة تعيين كلمات المرور
                Dim syncedUsers = Await UserSyncService.SyncAsync()
                Await UserSyncService.PullPasswordResetsAsync()

                LoadLicenseData()

                If result.IsValid Then
                    Dim syncMsg = If(syncedUsers, "وتمت مزامنة بيانات المستخدمين وكلمات المرور بنجاح ✅", "والترخيص متصل بالسيرفر بنجاح ✅")
                    Try
                        Notify.Toast($"الترخيص ساري ومفعل", Notify.ToastType.Success)
                    Catch
                        SmartMessageBox.Show($"الترخيص ساري ومفعل بنجاح، {syncMsg}", "تم التحديث", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                Else
                    SmartMessageBox.Show(result.Message, "حالة الترخيص", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                SmartMessageBox.Show("تعذر الاتصال بخادم التراخيص: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                btnRefresh.Enabled = True
                btnRefresh.Text = "🔄 فحص وتحديث الترخيص"
            End Try
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
