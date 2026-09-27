Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات التحديثات التلقائية وسجل الإصدارات المطور والاحترافي
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
                Dim updatesArray As New JArray()

                ' 1. جلب التحديثات المخصصة لـ Sestamk.VB حصراً من GitHub Releases لمنع أي تداخل مع C#
                Try
                    Using ghClient As New HttpClient()
                        ghClient.Timeout = TimeSpan.FromSeconds(12)
                        ghClient.DefaultRequestHeaders.Add("User-Agent", "Sestamk-VB-App")
                        Dim ghResp = Await ghClient.GetAsync(LicenseSettings.GitHubReleasesApiUrl)
                        If ghResp.IsSuccessStatusCode Then
                            Dim ghJson = Await ghResp.Content.ReadAsStringAsync()
                            Dim ghList = JArray.Parse(ghJson)
                            For Each rel In ghList
                                Dim tag = Convert.ToString(rel("tag_name")).TrimStart("v"c)
                                Dim title = Convert.ToString(rel("name"))
                                Dim body = Convert.ToString(rel("body"))
                                Dim pubDate = Convert.ToString(rel("published_at"))
                                Dim manUrl = "https://github.com/ammar92006/Sestamk.VB/releases/download/v" & tag & "/manifest.json"
                                Dim htmlUrl = Convert.ToString(rel("html_url"))

                                Dim pkgSize As Long = 0
                                Dim instSize As Long = 0
                                Dim assets = rel("assets")
                                If assets IsNot Nothing AndAlso assets.Type = JTokenType.Array Then
                                    For Each a In assets
                                        Dim aName = Convert.ToString(a("name")).ToLowerInvariant()
                                        If aName = "package.zip" Then
                                            Long.TryParse(Convert.ToString(a("size")), pkgSize)
                                        ElseIf aName.EndsWith(".exe") AndAlso aName.Contains("setup") Then
                                            Long.TryParse(Convert.ToString(a("size")), instSize)
                                        End If
                                    Next
                                End If

                                Dim cardItem As New JObject From {
                                    {"version", tag},
                                    {"title", If(String.IsNullOrWhiteSpace(title), "الإصدار " & tag, title)},
                                    {"description", body},
                                    {"release_date", pubDate},
                                    {"manifest_url", manUrl},
                                    {"html_url", htmlUrl},
                                    {"package_size", pkgSize},
                                    {"installer_size", instSize}
                                }
                                updatesArray.Add(cardItem)
                            Next
                        End If
                    End Using
                Catch exGh As Exception
                    Debug.WriteLine("GitHub releases check error: " & exGh.Message)
                End Try

                ' 2. في حال لم نتمكن من الوصول لـ GitHub Releases، نحاول فحص المانيفست الافتراضي
                If updatesArray.Count = 0 Then
                    Try
                        Using client As New HttpClient()
                            client.Timeout = TimeSpan.FromSeconds(10)
                            client.DefaultRequestHeaders.Add("User-Agent", "Sestamk-VB-App")
                            Dim defResp = Await client.GetAsync(LicenseSettings.DefaultManifestUrl)
                            If defResp.IsSuccessStatusCode Then
                                Dim manJson = Await defResp.Content.ReadAsStringAsync()
                                Dim parsedMan = UpdateCoordinator.ParseManifest(JObject.Parse(manJson))
                                If parsedMan IsNot Nothing Then
                                    Dim cardItem As New JObject From {
                                        {"version", parsedMan.Version},
                                        {"title", If(String.IsNullOrWhiteSpace(parsedMan.Title), "الإصدار " & parsedMan.Version, parsedMan.Title)},
                                        {"description", parsedMan.Notes},
                                        {"release_date", DateTime.UtcNow.ToString("yyyy-MM-dd")},
                                        {"manifest_url", LicenseSettings.DefaultManifestUrl},
                                        {"html_url", "https://github.com/ammar92006/Sestamk.VB/releases/latest"},
                                        {"package_size", parsedMan.PackageSize},
                                        {"installer_size", parsedMan.InstallerSize}
                                    }
                                    updatesArray.Add(cardItem)
                                End If
                            End If
                        End Using
                    Catch exDef As Exception
                        Debug.WriteLine("Default manifest check error: " & exDef.Message)
                    End Try
                End If

                flpUpdateHistory.SuspendLayout()
                flpUpdateHistory.AutoScrollPosition = New Point(0, 0)
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

                    ' رسم بطاقات التحديثات بتصميم بطاقات الميزات العصرية
                    Dim cardWidth = Math.Max(350, flpUpdateHistory.ClientSize.Width - 28)
                    Dim yOffset As Integer = 10
                    Dim isFirst = True

                    For Each upd In updatesArray
                        Dim card = CreateUpdateCard(upd, cardWidth, isFirst)
                        card.Location = New Point(10, yOffset)
                        flpUpdateHistory.Controls.Add(card)
                        yOffset += card.Height + 16
                        isFirst = False
                    Next
                Else
                    lblLatestVersion.Text = Application.ProductVersion
                    lblLatestUpdateDate.Text = "لا توجد سجلات"
                    btnCheckForUpdates.Text = "✅ النظام محدّث"
                    btnCheckForUpdates.FillColor = Color.FromArgb(16, 185, 129)
                    btnCheckForUpdates.Enabled = False
                End If
            Catch ex As Exception
                Debug.WriteLine("LoadUpdateHistoryCardsAsync error: " & ex.Message)
                lblLatestVersion.Text = "-"
                lblLatestUpdateDate.Text = "-"
            Finally
                flpUpdateHistory.ResumeLayout(True)
            End Try
        End Function

        Private Sub flpUpdateHistory_Resize(sender As Object, e As EventArgs) Handles flpUpdateHistory.Resize
            Try
                Dim targetWidth = Math.Max(350, flpUpdateHistory.ClientSize.Width - 28)
                For Each ctrl As Control In flpUpdateHistory.Controls
                    If TypeOf ctrl Is Guna.UI2.WinForms.Guna2Panel Then
                        ctrl.Width = targetWidth
                    End If
                Next
            Catch
            End Try
        End Sub

        Private Function CreateUpdateCard(update As JToken, cardWidth As Integer, isLatest As Boolean) As Guna.UI2.WinForms.Guna2Panel
            Dim ver = Convert.ToString(update("version"))
            Dim rawTitle = Convert.ToString(update("title"))
            Dim releaseDate = Convert.ToString(update("release_date"))
            Dim body = Convert.ToString(update("description"))
            Dim isCurrent = IsCurrentVersion(ver)

            ' البطاقة الرئيسية
            Dim card As New Guna.UI2.WinForms.Guna2Panel()
            card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            card.BorderRadius = 12
            card.Width = cardWidth
            card.RightToLeft = RightToLeft.Yes

            If isLatest Then
                card.BorderColor = Color.FromArgb(59, 130, 246) ' إطار أزرق لامع للإصدار الأحدث
                card.BorderThickness = 2
                card.FillColor = Color.FromArgb(24, 30, 44)
            Else
                card.BorderColor = Color.FromArgb(47, 55, 70)
                card.BorderThickness = 1
                card.FillColor = Color.FromArgb(20, 25, 36)
            End If

            ' 1. لوحة الترويسة Header
            Dim pnlHeader As New Panel With {
                .Location = New Point(16, 14),
                .Size = New Size(cardWidth - 32, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                .BackColor = Color.Transparent,
                .RightToLeft = RightToLeft.Yes
            }

            ' شارة رقم الإصدار (Version Badge) في أقصى اليمين
            Dim badgeText = "v" & ver
            If isLatest Then
                badgeText = "v" & ver & " (الأحدث)"
            End If

            Dim fontBadge As New Font("Segoe UI", 9.5!, FontStyle.Bold)
            Dim badgeSize = TextRenderer.MeasureText(badgeText, fontBadge)
            Dim badgeWidth = Math.Max(75, badgeSize.Width + (If(isLatest, 34, 20)))

            Dim pnlBadge As New Guna.UI2.WinForms.Guna2Panel With {
                .Size = New Size(badgeWidth, 28),
                .BorderRadius = 6,
                .Location = New Point(pnlHeader.Width - badgeWidth, 3),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .FillColor = If(isLatest, Color.FromArgb(37, 99, 235), Color.FromArgb(51, 65, 85))
            }

            If isLatest Then
                Dim lblBadgeIcon As New Label With {
                    .Text = "★",
                    .Font = New Font("Segoe UI", 10.0!, FontStyle.Bold),
                    .ForeColor = Color.FromArgb(254, 240, 138),
                    .Size = New Size(22, 28),
                    .Location = New Point(badgeWidth - 26, 0),
                    .TextAlign = ContentAlignment.MiddleCenter
                }
                pnlBadge.Controls.Add(lblBadgeIcon)

                Dim lblBadgeText As New Label With {
                    .Text = badgeText,
                    .Font = fontBadge,
                    .ForeColor = Color.White,
                    .Location = New Point(4, 0),
                    .Size = New Size(badgeWidth - 28, 28),
                    .TextAlign = ContentAlignment.MiddleCenter
                }
                pnlBadge.Controls.Add(lblBadgeText)
            Else
                Dim lblBadgeText As New Label With {
                    .Text = badgeText,
                    .Font = fontBadge,
                    .ForeColor = Color.FromArgb(226, 232, 240),
                    .Dock = DockStyle.Fill,
                    .TextAlign = ContentAlignment.MiddleCenter
                }
                pnlBadge.Controls.Add(lblBadgeText)
            End If
            pnlHeader.Controls.Add(pnlBadge)

            ' شارة النسخة الحالية (إن انطبقت)
            Dim currentBadgeWidth = 0
            If isCurrent Then
                currentBadgeWidth = 110
                Dim pnlCurrent As New Guna.UI2.WinForms.Guna2Panel With {
                    .Size = New Size(currentBadgeWidth, 28),
                    .BorderRadius = 6,
                    .Location = New Point(pnlBadge.Left - currentBadgeWidth - 8, 3),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                    .FillColor = Color.FromArgb(20, 83, 45),
                    .BorderColor = Color.FromArgb(34, 197, 94),
                    .BorderThickness = 1
                }
                Dim lblCurrentText As New Label With {
                    .Text = "✔ نسختك الحالية",
                    .Font = New Font("Segoe UI", 9.0!, FontStyle.Bold),
                    .ForeColor = Color.FromArgb(187, 247, 208),
                    .Dock = DockStyle.Fill,
                    .TextAlign = ContentAlignment.MiddleCenter
                }
                pnlCurrent.Controls.Add(lblCurrentText)
                pnlHeader.Controls.Add(pnlCurrent)
            End If

            ' عنوان الإصدار النظيف بجانب الشارة
            Dim cleanTitle = CleanReleaseTitle(rawTitle, ver)
            Dim rightBound = If(isCurrent, pnlBadge.Left - currentBadgeWidth - 16, pnlBadge.Left - 10)
            Dim leftBound = 220
            Dim titleWidth = Math.Max(150, rightBound - leftBound)

            Dim lblCardTitle As New Label With {
                .Text = cleanTitle,
                .Font = New Font("Segoe UI", 12.0!, FontStyle.Bold),
                .ForeColor = Color.FromArgb(248, 250, 252),
                .Location = New Point(leftBound, 3),
                .Size = New Size(titleWidth, 28),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                .TextAlign = ContentAlignment.MiddleRight,
                .RightToLeft = RightToLeft.Yes
            }
            pnlHeader.Controls.Add(lblCardTitle)

            ' تاريخ الإصدار على أقصى اليسار مع أيقونة تقويم منفصلة
            Dim formattedDate = FormatReleaseDateArabic(releaseDate)
            Dim pnlDate As New Panel With {
                .Location = New Point(0, 4),
                .Size = New Size(220, 26),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left,
                .BackColor = Color.Transparent
            }
            Dim lblDateIcon As New Label With {
                .Text = "📅",
                .Font = New Font("Segoe UI Emoji", 9.5!, FontStyle.Regular),
                .ForeColor = Color.FromArgb(96, 165, 250),
                .Location = New Point(0, 0),
                .Size = New Size(24, 26),
                .TextAlign = ContentAlignment.MiddleCenter
            }
            Dim lblDateText As New Label With {
                .Text = formattedDate,
                .Font = New Font("Segoe UI", 9.25!, FontStyle.Regular),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(26, 0),
                .Size = New Size(190, 26),
                .TextAlign = ContentAlignment.MiddleLeft
            }
            pnlDate.Controls.Add(lblDateIcon)
            pnlDate.Controls.Add(lblDateText)
            pnlHeader.Controls.Add(pnlDate)
            card.Controls.Add(pnlHeader)

            ' خط فاصل ناعم تحت الترويسة
            Dim pnlSep As New Guna.UI2.WinForms.Guna2Panel With {
                .Location = New Point(16, pnlHeader.Bottom + 8),
                .Size = New Size(cardWidth - 32, 1),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                .FillColor = Color.FromArgb(42, 51, 66)
            }
            card.Controls.Add(pnlSep)

            ' 2. عناصر قائمة الميزات وسجل التغييرات (Changelog Features Cards)
            Dim currentY = pnlSep.Bottom + 12
            Dim items = ParseReleaseNotes(body)
            Dim itemWidth = cardWidth - 32

            For Each item In items
                Dim featureCard = CreateFeatureItem(item, itemWidth)
                featureCard.Location = New Point(16, currentY)
                card.Controls.Add(featureCard)
                currentY += featureCard.Height + 8
            Next

            ' 3. شريط المعلومات والتحميل (Footer)
            Dim pnlFooter = CreateCardFooter(update, itemWidth, isLatest)
            pnlFooter.Location = New Point(16, currentY + 4)
            card.Controls.Add(pnlFooter)

            card.Height = pnlFooter.Bottom + 14
            Return card
        End Function

        Private Function CleanReleaseTitle(title As String, version As String) As String
            If String.IsNullOrWhiteSpace(title) Then Return "تحديث سستمك الشامل"
            Dim t = title.Trim()
            ' إزالة أي ذكر لـ VB.NET أو VB نهائياً من العناوين
            t = t.Replace("(VB.NET)", "").Replace("(vb.net)", "").Replace("VB.NET", "").Replace("vb.net", "")
            t = t.Replace("(VB)", "").Replace("(vb)", "").Replace("VB .NET", "").Replace("vb .net", "")
            ' إزالة التكرار مثل "الإصدار 1.2.2 - " أو "v1.2.2"
            t = t.Replace("الإصدار " & version, "")
            t = t.Replace("v" & version, "")
            t = t.Replace("V" & version, "")
            t = t.Replace(version, "")
            t = t.Trim(" "c, "-"c, "•"c, ":"c, "("c, ")"c).Trim()
            If String.IsNullOrWhiteSpace(t) Then t = "تحديث سستمك الشامل"
            Return t
        End Function

        Private Class ReleaseNoteItem
            Public Property Icon As String
            Public Property Title As String
            Public Property Description As String
        End Class

        Private Function ParseReleaseNotes(rawBody As String) As List(Of ReleaseNoteItem)
            Dim list As New List(Of ReleaseNoteItem)()
            If String.IsNullOrWhiteSpace(rawBody) Then
                list.Add(New ReleaseNoteItem With {
                    .Icon = "✨",
                    .Title = "تحسينات عامة على النظام",
                    .Description = "تحسينات دورية على الأداء والاستقرار وسرعة معالجة البيانات."
                })
                Return list
            End If

            Dim lines = rawBody.Split({vbCrLf, vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
            For Each rawLine In lines
                Dim line = rawLine.Trim()
                If String.IsNullOrWhiteSpace(line) Then Continue For

                ' استبعاد الترويسات مثل ### ما الجديد
                If line.StartsWith("#") OrElse line.StartsWith("ما الجديد", StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If

                ' إزالة علامات القوائم
                While line.StartsWith("•") OrElse line.StartsWith("-") OrElse line.StartsWith("*")
                    line = line.Substring(1).Trim()
                End While

                If String.IsNullOrWhiteSpace(line) Then Continue For

                ' استخراج الأيقونة التعبيرية إن وجدت في البداية
                Dim icon As String = Nothing
                Dim lineAfterIcon = line

                Dim commonIcons = {"🧹", "📁", "💳", "📊", "🔐", "🚀", "🛡️", "🛡", "🔔", "🔑", "💻", "💾", "✨", "⚡", "🔧", "🐞", "⚙️", "⚙", "🎯", "📱", "🖨️", "🖨", "🏷️", "🏷", "💰", "📦", "🌐", "✅", "✦"}
                For Each ci In commonIcons
                    If line.StartsWith(ci) Then
                        icon = ci
                        lineAfterIcon = line.Substring(ci.Length).Trim()
                        Exit For
                    End If
                Next

                Dim itemTitle As String = ""
                Dim itemDesc As String = ""

                ' فحص نمط **العنوان**: الشرح
                If lineAfterIcon.Contains("**") Then
                    Dim firstStar = lineAfterIcon.IndexOf("**")
                    Dim secondStar = lineAfterIcon.IndexOf("**", firstStar + 2)
                    If secondStar > firstStar Then
                        itemTitle = lineAfterIcon.Substring(firstStar + 2, secondStar - firstStar - 2).Trim()
                        Dim remainder = lineAfterIcon.Substring(secondStar + 2).Trim()
                        itemDesc = remainder.TrimStart(":"c, "-"c, "•"c, " "c).Trim()
                    End If
                End If

                ' إذا لم يتم العثور على النجوم، نبحث عن :
                If String.IsNullOrWhiteSpace(itemTitle) Then
                    If lineAfterIcon.Contains(":") Then
                        Dim parts = lineAfterIcon.Split({":"c}, 2)
                        itemTitle = parts(0).Trim()
                        itemDesc = parts(1).Trim()
                    Else
                        itemTitle = lineAfterIcon.Trim()
                        itemDesc = ""
                    End If
                End If

                itemTitle = itemTitle.Replace("**", "").Replace("__", "").Replace("(VB.NET)", "").Replace("VB.NET", "").Replace("(VB)", "").Trim()
                itemDesc = itemDesc.Replace("**", "").Replace("__", "").Replace("(VB.NET)", "").Replace("VB.NET", "").Replace("(VB)", "").Trim()

                If String.IsNullOrWhiteSpace(icon) Then
                    icon = GetSmartIcon(itemTitle & " " & itemDesc)
                End If

                If Not String.IsNullOrWhiteSpace(itemTitle) Then
                    list.Add(New ReleaseNoteItem With {
                        .Icon = icon,
                        .Title = itemTitle,
                        .Description = itemDesc
                    })
                End If
            Next

            If list.Count = 0 Then
                list.Add(New ReleaseNoteItem With {
                    .Icon = "✨",
                    .Title = "تفاصيل التحديث",
                    .Description = CleanMarkdown(rawBody)
                })
            End If

            Return list
        End Function

        Private Function GetSmartIcon(text As String) As String
            If String.IsNullOrWhiteSpace(text) Then Return "✦"
            If text.IndexOf("تفعيل", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("ترخيص", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("رخصة", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "🔑"
            ElseIf text.IndexOf("إشعار", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("تنبيه", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "🔔"
            ElseIf text.IndexOf("update", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("محدث", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("تحديث", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "🚀"
            ElseIf text.IndexOf("إقفال", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("حماية", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("Shadow", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("قفل", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "🛡️"
            ElseIf text.IndexOf("جهاز", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("HWID", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("بصمة", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "💻"
            ElseIf text.IndexOf("مورد", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("كشف حساب", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("حسابات", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("سند", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "💳"
            ElseIf text.IndexOf("تقرير", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("تقارير", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "📊"
            ElseIf text.IndexOf("جدول", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("تنظيف", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("معماري", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("قاعدة", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "🧹"
            ElseIf text.IndexOf("أرشفة", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("شاشة", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("شاشات", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "📁"
            ElseIf text.IndexOf("صلاحيات", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("تنقل", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("أمان", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "🔐"
            ElseIf text.IndexOf("تثبيت", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("حزمة", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("setup", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "💿"
            ElseIf text.IndexOf("طباعة", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("طابعة", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("فاتورة", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return "🖨️"
            Else
                Return "✦"
            End If
        End Function

        Private Function CleanMarkdown(raw As String) As String
            If String.IsNullOrWhiteSpace(raw) Then Return ""
            Dim t = raw.Replace("###", "").Replace("##", "").Replace("#", "")
            t = t.Replace("**", "").Replace("__", "").Replace("`", "")
            Return t.Trim()
        End Function

        Private Function CreateFeatureItem(item As ReleaseNoteItem, itemWidth As Integer) As Guna.UI2.WinForms.Guna2Panel
            Dim pnl As New Guna.UI2.WinForms.Guna2Panel With {
                .Width = itemWidth,
                .BorderRadius = 8,
                .BorderThickness = 1,
                .BorderColor = Color.FromArgb(42, 51, 66),
                .FillColor = Color.FromArgb(16, 21, 31),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                .RightToLeft = RightToLeft.Yes
            }

            ' حاوية الأيقونة في أقصى اليسار
            Dim pnlIcon As New Guna.UI2.WinForms.Guna2Panel With {
                .Size = New Size(36, 36),
                .BorderRadius = 8,
                .FillColor = Color.FromArgb(26, 34, 49),
                .BorderColor = Color.FromArgb(51, 65, 85),
                .BorderThickness = 1,
                .Location = New Point(10, 10),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left
            }

            Dim lblIcon As New Label With {
                .Text = item.Icon,
                .Font = New Font("Segoe UI Emoji", 13.0!, FontStyle.Regular),
                .ForeColor = Color.FromArgb(56, 189, 248),
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter
            }
            pnlIcon.Controls.Add(lblIcon)
            pnl.Controls.Add(pnlIcon)

            Dim textWidth = itemWidth - 68

            If Not String.IsNullOrWhiteSpace(item.Description) Then
                Dim lblTitle As New Label With {
                    .Text = item.Title,
                    .Font = New Font("Segoe UI", 10.25!, FontStyle.Bold),
                    .ForeColor = Color.FromArgb(248, 250, 252),
                    .Location = New Point(56, 10),
                    .Width = textWidth,
                    .AutoSize = True,
                    .MaximumSize = New Size(textWidth, 0),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                    .RightToLeft = RightToLeft.Yes,
                    .TextAlign = ContentAlignment.TopRight
                }
                pnl.Controls.Add(lblTitle)

                Dim lblDesc As New Label With {
                    .Text = item.Description,
                    .Font = New Font("Segoe UI", 9.25!, FontStyle.Regular),
                    .ForeColor = Color.FromArgb(203, 213, 225),
                    .Location = New Point(56, lblTitle.Bottom + 4),
                    .Width = textWidth,
                    .AutoSize = True,
                    .MaximumSize = New Size(textWidth, 0),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                    .RightToLeft = RightToLeft.Yes,
                    .TextAlign = ContentAlignment.TopRight
                }
                pnl.Controls.Add(lblDesc)

                pnl.Height = Math.Max(56, lblDesc.Bottom + 12)
            Else
                Dim lblTitle As New Label With {
                    .Text = item.Title,
                    .Font = New Font("Segoe UI", 9.75!, FontStyle.Regular),
                    .ForeColor = Color.FromArgb(241, 245, 249),
                    .Location = New Point(56, 16),
                    .Width = textWidth,
                    .AutoSize = True,
                    .MaximumSize = New Size(textWidth, 0),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                    .RightToLeft = RightToLeft.Yes,
                    .TextAlign = ContentAlignment.TopRight
                }
                pnl.Controls.Add(lblTitle)

                pnl.Height = Math.Max(56, lblTitle.Bottom + 14)
            End If

            ' تأثير تفاعلي ناعم عند مرور مؤشر الفأرة (Hover Effect)
            Dim onEnter = Sub(s As Object, e As EventArgs)
                              pnl.BorderColor = Color.FromArgb(59, 130, 246)
                              pnl.FillColor = Color.FromArgb(23, 31, 46)
                          End Sub
            Dim onLeave = Sub(s As Object, e As EventArgs)
                              Dim pt = pnl.PointToClient(Cursor.Position)
                              If Not pnl.ClientRectangle.Contains(pt) Then
                                  pnl.BorderColor = Color.FromArgb(42, 51, 66)
                                  pnl.FillColor = Color.FromArgb(16, 21, 31)
                              End If
                          End Sub

            AddHandler pnl.MouseEnter, onEnter
            AddHandler pnl.MouseLeave, onLeave
            AddHandler pnlIcon.MouseEnter, onEnter
            AddHandler pnlIcon.MouseLeave, onLeave
            AddHandler lblIcon.MouseEnter, onEnter
            AddHandler lblIcon.MouseLeave, onLeave

            Return pnl
        End Function

        Private Function CreateCardFooter(update As JToken, footerWidth As Integer, isLatest As Boolean) As Guna.UI2.WinForms.Guna2Panel
            Dim pnl As New Guna.UI2.WinForms.Guna2Panel With {
                .Width = footerWidth,
                .Height = 36,
                .BackColor = Color.Transparent,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                .RightToLeft = RightToLeft.Yes
            }

            Dim pkgSize As Long = 0
            Dim instSize As Long = 0
            If update("package_size") IsNot Nothing Then Long.TryParse(Convert.ToString(update("package_size")), pkgSize)
            If update("installer_size") IsNot Nothing Then Long.TryParse(Convert.ToString(update("installer_size")), instSize)

            Dim htmlUrl = Convert.ToString(update("html_url"))

            ' شارة أحجام الملفات بكامل عرض البطاقة
            Dim sizeInfo = ""
            If pkgSize > 0 Then
                sizeInfo &= "📦 حزمة التحديث: " & FormatBytesArabic(pkgSize)
            End If
            If instSize > 0 Then
                If Not String.IsNullOrWhiteSpace(sizeInfo) Then sizeInfo &= "   •   "
                sizeInfo &= "💿 ملف التثبيت: " & FormatBytesArabic(instSize)
            End If

            If Not String.IsNullOrWhiteSpace(sizeInfo) Then
                Dim lblSizes As New Label With {
                    .Text = sizeInfo,
                    .Font = New Font("Segoe UI", 9.0!, FontStyle.Regular),
                    .ForeColor = Color.FromArgb(148, 163, 184),
                    .Location = New Point(10, 6),
                    .Width = footerWidth - 20,
                    .Height = 24,
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                    .TextAlign = ContentAlignment.MiddleRight,
                    .RightToLeft = RightToLeft.Yes
                }
                pnl.Controls.Add(lblSizes)
            End If

            Return pnl
        End Function

        Private Function FormatReleaseDateArabic(rawDate As String) As String
            If String.IsNullOrWhiteSpace(rawDate) Then Return "غير محدد"
            Dim dt As DateTime
            If DateTime.TryParse(rawDate, dt) Then
                Return dt.ToString("yyyy/MM/dd  hh:mm tt", System.Globalization.CultureInfo.InvariantCulture) _
                         .Replace("AM", "صباحاً").Replace("PM", "مساءً")
            End If
            Return rawDate
        End Function

        Private Function FormatBytesArabic(bytes As Long) As String
            If bytes <= 0 Then Return ""
            If bytes >= 1024L * 1024L * 1024L Then
                Return (bytes / (1024.0 * 1024.0 * 1024.0)).ToString("0.0") & " جيجابايت"
            ElseIf bytes >= 1024L * 1024L Then
                Return (bytes / (1024.0 * 1024.0)).ToString("0.0") & " ميجابايت"
            ElseIf bytes >= 1024L Then
                Return (bytes / 1024.0).ToString("0") & " كيلوبايت"
            Else
                Return bytes & " بايت"
            End If
        End Function

        Private Function IsCurrentVersion(verStr As String) As Boolean
            Try
                Dim v1 As Version = Nothing
                Dim v2 As Version = Nothing
                Dim cleanVer = verStr.TrimStart("v"c, "V"c)
                Dim cleanCurrent = Application.ProductVersion.TrimStart("v"c, "V"c)
                If Version.TryParse(cleanVer, v1) AndAlso Version.TryParse(cleanCurrent, v2) Then
                    Return v1 = v2 OrElse (v1.Major = v2.Major AndAlso v1.Minor = v2.Minor AndAlso v1.Build = v2.Build)
                End If
                Return String.Equals(cleanVer, cleanCurrent, StringComparison.OrdinalIgnoreCase)
            Catch
                Return False
            End Try
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

                If String.IsNullOrWhiteSpace(_latestManifestUrl) Then
                    _latestManifestUrl = LicenseSettings.DefaultManifestUrl
                End If

                If Not String.IsNullOrWhiteSpace(_latestManifestUrl) Then
                    Using client As New HttpClient()
                        client.Timeout = TimeSpan.FromSeconds(15)
                        client.DefaultRequestHeaders.Add("User-Agent", "Sestamk-VB-App")
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
