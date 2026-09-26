Imports System.Drawing
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات التحديثات التلقائية وسجل الإصدارات
    ''' </summary>
    Public Class UCUpdatesSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Private _latestManifestUrl As String = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Async Sub UCUpdatesSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                lblCurrentVersion.Text = Application.ProductVersion
                tglAutoUpdate.Checked = SettingsManager.GetBoolSetting("AutoUpdate_Enabled", True)

                Dim license = LicenseCache.Load()
                Dim userChannel As String = "public"
                If license IsNot Nothing Then
                    userChannel = Convert.ToString(license("channel"))
                    If String.IsNullOrWhiteSpace(userChannel) Then userChannel = "public"
                End If

                lblChannel.Text = userChannel.ToUpperInvariant()
                Await LoadUpdateHistoryCardsAsync(userChannel)
            Catch ex As Exception
                Debug.WriteLine("UCUpdatesSettings_Load error: " & ex.Message)
            End Try
        End Sub

        Private Sub tglAutoUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles tglAutoUpdate.CheckedChanged
            Try
                SettingsManager.SaveSetting("AutoUpdate_Enabled", tglAutoUpdate.Checked.ToString().ToLower())
                Try
                    Notify.Toast("تم حفظ إعدادات التحديث التلقائي بنجاح ✅", Notify.ToastType.Success)
                Catch
                End Try
            Catch ex As Exception
                MessageBox.Show("فشل حفظ إعداد التحديث: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Async Function LoadUpdateHistoryCardsAsync(channel As String) As Task
            Try
                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(15)
                    client.DefaultRequestHeaders.Add("apikey", LicenseSettings.PublishableKey)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " & LicenseSettings.PublishableKey)

                    Dim url = LicenseSettings.SupabaseUrl.TrimEnd("/"c) & "/rest/v1/updates?channel=eq." & Uri.EscapeDataString(channel) & "&is_active=eq.true&select=*&order=release_date.desc"
                    Dim response = Await client.GetAsync(url)

                    If Not response.IsSuccessStatusCode Then
                        lblLatestVersion.Text = "-"
                        lblLatestUpdateDate.Text = "-"
                        Return
                    End If

                    Dim json = Await response.Content.ReadAsStringAsync()
                    Dim updatesArray = JArray.Parse(json)

                    If updatesArray.Count = 0 AndAlso Not String.Equals(channel, "beta", StringComparison.OrdinalIgnoreCase) Then
                        ' جلب التحديثات النشطة المتاحة لضمان عدم بقاء الشاشة فارغة
                        Dim fallbackUrl = LicenseSettings.SupabaseUrl.TrimEnd("/"c) & "/rest/v1/updates?is_active=eq.true&select=*&order=release_date.desc"
                        Dim fallbackResp = Await client.GetAsync(fallbackUrl)
                        If fallbackResp.IsSuccessStatusCode Then
                            Dim fallbackJson = Await fallbackResp.Content.ReadAsStringAsync()
                            updatesArray = JArray.Parse(fallbackJson)
                        End If
                    End If

                    flpUpdateHistory.SuspendLayout()
                    flpUpdateHistory.Controls.Clear()

                    If updatesArray.Count > 0 Then
                        ' أحدث تحديث
                        Dim latest = updatesArray(0)
                        Dim latestVerStr = Convert.ToString(latest("version"))
                        _latestManifestUrl = Convert.ToString(latest("manifest_url"))

                        lblLatestVersion.Text = If(String.IsNullOrWhiteSpace(latestVerStr), "-", latestVerStr)

                        Dim dateStr = Convert.ToString(latest("release_date"))
                        If String.IsNullOrWhiteSpace(dateStr) Then dateStr = Convert.ToString(latest("created_at"))

                        Dim parsedDate As DateTime
                        If DateTime.TryParse(dateStr, parsedDate) Then
                            lblLatestUpdateDate.Text = parsedDate.ToString("yyyy-MM-dd")
                        Else
                            lblLatestUpdateDate.Text = If(String.IsNullOrWhiteSpace(dateStr), "-", dateStr)
                        End If

                        ' التحقق من وجود إصدار أحدث
                        Dim currentVer As Version = Nothing
                        Dim latestVer As Version = Nothing
                        Dim hasNewer = False

                        If Version.TryParse(Application.ProductVersion, currentVer) AndAlso Version.TryParse(latestVerStr, latestVer) Then
                            hasNewer = (latestVer > currentVer)
                        Else
                            hasNewer = Not String.Equals(Application.ProductVersion, latestVerStr, StringComparison.OrdinalIgnoreCase)
                        End If

                        If hasNewer Then
                            btnCheckForUpdates.Text = "⬇️ تحديث الآن"
                            btnCheckForUpdates.FillColor = Color.FromArgb(37, 99, 235)
                            btnCheckForUpdates.Enabled = True
                        Else
                            btnCheckForUpdates.Text = "✅ النظام محدّث"
                            btnCheckForUpdates.FillColor = Color.FromArgb(16, 185, 129)
                            btnCheckForUpdates.Enabled = False
                        End If

                        ' رسم بطاقات التحديثات
                        Dim yOffset As Integer = 10
                        For Each upd In updatesArray
                            Dim card = CreateUpdateCard(upd, yOffset)
                            flpUpdateHistory.Controls.Add(card)
                            yOffset += card.Height + 15
                        Next
                    Else
                        lblLatestVersion.Text = Application.ProductVersion
                        lblLatestUpdateDate.Text = "لا توجد سجلات"
                        btnCheckForUpdates.Text = "✅ النظام محدّث"
                        btnCheckForUpdates.FillColor = Color.FromArgb(16, 185, 129)
                        btnCheckForUpdates.Enabled = False
                    End If
                End Using
            Catch ex As Exception
                Debug.WriteLine("LoadUpdateHistoryCardsAsync error: " & ex.Message)
                lblLatestVersion.Text = "-"
                lblLatestUpdateDate.Text = "-"
            Finally
                flpUpdateHistory.ResumeLayout(True)
            End Try
        End Function

        Private Function CreateUpdateCard(update As JToken, topPos As Integer) As Guna.UI2.WinForms.Guna2Panel
            Dim card As New Guna.UI2.WinForms.Guna2Panel()
            card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            card.BorderColor = Color.FromArgb(55, 65, 81)
            card.BorderRadius = 10
            card.BorderThickness = 1
            card.FillColor = Color.FromArgb(31, 41, 55)
            card.Location = New Point(10, topPos)
            card.Width = Math.Max(300, flpUpdateHistory.ClientSize.Width - 30)

            Dim ver = Convert.ToString(update("version"))
            Dim title = Convert.ToString(update("title"))
            Dim releaseDate = Convert.ToString(update("release_date"))

            ' عنوان البطاقة
            Dim lblCardTitle As New Label()
            lblCardTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            lblCardTitle.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
            lblCardTitle.ForeColor = Color.FromArgb(243, 244, 246)
            lblCardTitle.Text = "الإصدار " & ver & " - " & title
            lblCardTitle.TextAlign = ContentAlignment.MiddleRight
            lblCardTitle.Location = New Point(200, 12)
            lblCardTitle.Size = New Size(card.Width - 220, 26)
            card.Controls.Add(lblCardTitle)

            ' تاريخ الإصدار
            Dim lblDate As New Label()
            lblDate.Anchor = AnchorStyles.Top Or AnchorStyles.Left
            lblDate.Font = New Font("Segoe UI", 9.5!)
            lblDate.ForeColor = Color.FromArgb(156, 163, 175)
            lblDate.Text = releaseDate
            lblDate.TextAlign = ContentAlignment.MiddleLeft
            lblDate.Location = New Point(15, 14)
            lblDate.Size = New Size(180, 22)
            card.Controls.Add(lblDate)

            ' ما الجديد (Whats New)
            Dim sb As New StringBuilder()
            Dim whatsNew = update("whats_new")
            If whatsNew IsNot Nothing AndAlso whatsNew.Type = JTokenType.Array Then
                For Each item In whatsNew
                    sb.AppendLine("• " & Convert.ToString(item))
                Next
            Else
                Dim desc = Convert.ToString(update("description"))
                sb.AppendLine("• " & If(String.IsNullOrWhiteSpace(desc), "تحسينات عامة على أداء النظام.", desc))
            End If

            Dim lblFeatures As New Label()
            lblFeatures.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            lblFeatures.Font = New Font("Segoe UI", 10.0!)
            lblFeatures.ForeColor = Color.FromArgb(209, 213, 219)
            lblFeatures.Text = sb.ToString().TrimEnd()
            lblFeatures.TextAlign = ContentAlignment.TopRight
            lblFeatures.RightToLeft = RightToLeft.Yes
            lblFeatures.Location = New Point(15, 45)
            lblFeatures.Size = New Size(card.Width - 30, 20)
            lblFeatures.AutoSize = True
            card.Controls.Add(lblFeatures)

            card.Height = lblFeatures.Bottom + 15
            Return card
        End Function

        Private Async Sub btnCheckForUpdates_Click(sender As Object, e As EventArgs) Handles btnCheckForUpdates.Click
            btnCheckForUpdates.Enabled = False
            Dim originalText = btnCheckForUpdates.Text
            btnCheckForUpdates.Text = "جاري الفحص..."
            Try
                Dim license = LicenseCache.Load()
                Dim channel = If(license IsNot Nothing, Convert.ToString(license("channel")), "public")
                If String.IsNullOrWhiteSpace(channel) Then channel = "public"

                Await LoadUpdateHistoryCardsAsync(channel)

                If Not String.IsNullOrWhiteSpace(_latestManifestUrl) Then
                    Using client As New HttpClient()
                        client.Timeout = TimeSpan.FromSeconds(15)
                        Dim manifestJson = Await client.GetStringAsync(_latestManifestUrl)
                        Dim parsed = JObject.Parse(manifestJson)
                        Dim manifest = UpdateCoordinator.ParseManifest(parsed)

                        If manifest IsNot Nothing Then
                            Dim curVer As Version = Nothing
                            Dim manVer As Version = Nothing
                            Dim isNewer = False

                            If Version.TryParse(Application.ProductVersion, curVer) AndAlso Version.TryParse(manifest.Version, manVer) Then
                                isNewer = (manVer > curVer)
                            Else
                                isNewer = Not String.Equals(Application.ProductVersion, manifest.Version, StringComparison.OrdinalIgnoreCase)
                            End If

                            If isNewer Then
                                Using notifier As New FormUpdateNotifier(manifest)
                                    notifier.ShowDialog(Me.FindForm())
                                End Using
                            Else
                                Try
                                    Notify.Toast("أنت تستخدم أحدث إصدار حالياً ✅", Notify.ToastType.Success)
                                Catch
                                    MessageBox.Show("أنت تستخدم أحدث إصدار متاح حالياً.", "التحديثات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Try
                            End If
                        Else
                            Try
                                Notify.Toast("أنت تستخدم أحدث إصدار حالياً ✅", Notify.ToastType.Success)
                            Catch
                                MessageBox.Show("أنت تستخدم أحدث إصدار متاح حالياً.", "التحديثات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End Try
                        End If
                    End Using
                Else
                    Try
                        Notify.Toast("أنت تستخدم أحدث إصدار حالياً ✅", Notify.ToastType.Success)
                    Catch
                        MessageBox.Show("أنت تستخدم أحدث إصدار حالياً.", "التحديثات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show("حدث خطأ أثناء فحص التحديثات: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                btnCheckForUpdates.Enabled = True
                btnCheckForUpdates.Text = originalText
            End Try
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
