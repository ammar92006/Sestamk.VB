Imports System.Drawing
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات التفعيل والترخيص وبصمة الجهاز المحدثة
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
                Dim license = LicenseCache.Load()
                If license IsNot Nothing Then
                    Dim status = Convert.ToString(license("status")).ToLowerInvariant()
                    Dim expiresAtStr = Convert.ToString(license("expires_at"))
                    Dim expiresAt As DateTime
                    Dim isExpired = (DateTime.TryParse(expiresAtStr, expiresAt) AndAlso expiresAt.Date < DateTime.Today)

                    If status = "active" AndAlso Not isExpired Then
                        lblStatus.Text = "✅ مفعل (نشط)"
                        lblStatus.ForeColor = Color.FromArgb(52, 211, 153)
                    ElseIf status = "grace_period" Then
                        lblStatus.Text = "⚠️ فترة سماح"
                        lblStatus.ForeColor = Color.FromArgb(245, 158, 11)
                    ElseIf isExpired Then
                        lblStatus.Text = "❌ منتهي الصلاحية"
                        lblStatus.ForeColor = Color.FromArgb(239, 68, 68)
                    Else
                        lblStatus.Text = "غير مفعل (" & status & ")"
                        lblStatus.ForeColor = Color.FromArgb(239, 68, 68)
                    End If

                    ' تاريخ البداية
                    Dim createdAtStr = Convert.ToString(license("created_at"))
                    Dim createdAt As DateTime
                    If DateTime.TryParse(createdAtStr, createdAt) Then
                        lblStartDate.Text = createdAt.ToString("yyyy-MM-dd")
                    Else
                        lblStartDate.Text = If(String.IsNullOrWhiteSpace(createdAtStr), "-", createdAtStr)
                    End If

                    ' تاريخ الانتهاء
                    If DateTime.TryParse(expiresAtStr, expiresAt) Then
                        lblExpiryDate.Text = expiresAt.ToString("yyyy-MM-dd")
                    Else
                        lblExpiryDate.Text = If(String.IsNullOrWhiteSpace(expiresAtStr), "-", expiresAtStr)
                    End If

                    ' السيريال
                    Dim serial = Convert.ToString(license("saved_serial"))
                    lblSerial.Text = If(String.IsNullOrWhiteSpace(serial), "غير متوفر", serial)

                    ' اسم المنشأة
                    Dim company = Convert.ToString(license("company_name"))
                    lblCompanyName.Text = If(String.IsNullOrWhiteSpace(company), "شركة عامة", company)

                    ' الخطة
                    Dim plan = Convert.ToString(license("plan"))
                    lblPlanName.Text = If(String.IsNullOrWhiteSpace(plan), "PRO", plan.ToUpperInvariant())

                    ' الأجهزة والمستخدمين
                    Dim maxDevices = Convert.ToString(license("max_devices"))
                    lblMaxDevices.Text = If(String.IsNullOrWhiteSpace(maxDevices), "-", maxDevices)

                    Dim maxUsers = Convert.ToString(license("max_users"))
                    lblMaxUsers.Text = If(String.IsNullOrWhiteSpace(maxUsers), "-", maxUsers)

                    ' السعر
                    If String.Equals(plan, "trial", StringComparison.OrdinalIgnoreCase) Then
                        lblPrice.Text = "نسخة تجريبية مجانية"
                    Else
                        Dim price = Convert.ToString(license("price"))
                        Dim currency = Convert.ToString(license("currency"))
                        If String.IsNullOrWhiteSpace(currency) Then currency = "USD"
                        If String.IsNullOrWhiteSpace(price) Then price = "0.00"
                        lblPrice.Text = price & " " & currency
                    End If
                Else
                    lblStatus.Text = "⚠️ غير مفعل"
                    lblStatus.ForeColor = Color.FromArgb(239, 68, 68)
                    lblStartDate.Text = "-"
                    lblExpiryDate.Text = "-"
                    lblSerial.Text = "لا يوجد سيريال مفعل"
                    lblCompanyName.Text = "-"
                    lblPlanName.Text = "-"
                    lblMaxDevices.Text = "-"
                    lblMaxUsers.Text = "-"
                    lblPrice.Text = "-"
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
                        MessageBox.Show("تم نسخ بصمة الجهاز (HWID) بنجاح إلى الحافظة.", "تم النسخ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show("تعذر النسخ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub btnChangeSerial_Click(sender As Object, e As EventArgs) Handles btnChangeSerial.Click
            Try
                Using frm As New FormActivation()
                    If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                        LoadLicenseData()
                        Try
                            Notify.Toast("تم تحديث بيانات التفعيل بنجاح ✅", Notify.ToastType.Success)
                        Catch
                        End Try
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("خطأ أثناء فتح نافذة التفعيل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Async Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            btnRefresh.Enabled = False
            btnRefresh.Text = "جاري الفحص..."
            Try
                Dim result = Await LicenseBootstrapper.CheckAsync()
                LoadLicenseData()
                If result.IsValid Then
                    Try
                        Notify.Toast("تم التحقق من الترخيص: الترخيص ساري ✅", Notify.ToastType.Success)
                    Catch
                        MessageBox.Show("الترخيص ساري ومفعل بنجاح.", "تم التحقق", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                Else
                    MessageBox.Show(result.Message, "حالة الترخيص", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show("تعذر الاتصال بخادم التراخيص: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                btnRefresh.Enabled = True
                btnRefresh.Text = "🔄 تحديث بيانات الترخيص"
            End Try
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
