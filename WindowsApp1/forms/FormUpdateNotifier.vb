Imports System.Drawing
Imports System.Linq
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

Public Class FormUpdateNotifier
    Inherits System.Windows.Forms.Form

    Private ReadOnly _manifest As VbUpdateManifest

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(manifest As VbUpdateManifest)
        Me.New()
        _manifest = manifest

        If manifest IsNot Nothing Then
            Dim verStr = If(String.IsNullOrWhiteSpace(manifest.Version), "1.0.0", manifest.Version.Trim())
            lblVersionBadge.Text = "v" & verStr.TrimStart("v"c)
            lblTitle.Text = "تحديث جديد متوفر: " & verStr

            ' عرض حجم الحزمة الفعلي في كافة عناصر التحكم
            UpdateSizeLabels(manifest.PackageSize, manifest.Mandatory)

            ' إذا كان الحجم غير محدد في المانيفست، نقوم بجلبه ديناميكياً بدقة عبر طلب HEAD
            If manifest.PackageSize <= 0 AndAlso Not String.IsNullOrWhiteSpace(manifest.PackageUrl) Then
                FetchRealPackageSizeAsync()
            End If

            ' تنسيق قائمة الملاحظات والتحسينات في بطاقات أنيقة
            PopulateNotesList(manifest)

            btnLater.Visible = Not manifest.Mandatory
            btnClose.Visible = Not manifest.Mandatory
        End If
    End Sub

    Private Sub UpdateSizeLabels(bytes As Long, isMandatory As Boolean)
        Dim sizeStr = FormatFileSize(bytes)
        Dim sizeStrAr = FormatFileSizeArabic(bytes)

        lblSizeBadge.Text = sizeStr
        lblSizeInCard.Text = "الحجم: " & sizeStrAr

        If isMandatory Then
            lblDeltaNotice.Text = "⚠️ هذا التحديث إلزامي (" & sizeStr & ") لمتابعة العمل والتوافق مع السيرفر"
            lblDeltaNotice.ForeColor = Color.FromArgb(248, 113, 113)
            pnlDeltaNotice.FillColor = Color.FromArgb(69, 26, 26)
            pnlDeltaNotice.BorderColor = Color.FromArgb(239, 68, 68)
        Else
            lblDeltaNotice.Text = "⚡ تحديث ذكي وسريع (" & sizeStr & "): يتم تنزيل وتحديث الملفات الجديدة فقط دون الحاجة لإعادة التثبيت"
            lblDeltaNotice.ForeColor = Color.FromArgb(148, 163, 184)
            pnlDeltaNotice.FillColor = Color.FromArgb(30, 41, 59)
            pnlDeltaNotice.BorderColor = Color.FromArgb(51, 65, 85)
        End If
    End Sub

    Private Async Sub FetchRealPackageSizeAsync()
        If _manifest Is Nothing OrElse String.IsNullOrWhiteSpace(_manifest.PackageUrl) Then Return
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(6)
                Using req As New HttpRequestMessage(HttpMethod.Head, _manifest.PackageUrl)
                    Dim resp = Await client.SendAsync(req)
                    If resp.IsSuccessStatusCode AndAlso resp.Content.Headers.ContentLength.HasValue Then
                        Dim realBytes = resp.Content.Headers.ContentLength.Value
                        If realBytes > 0 Then
                            _manifest.PackageSize = realBytes
                            If Me.InvokeRequired Then
                                Me.Invoke(Sub() UpdateSizeLabels(realBytes, _manifest.Mandatory))
                            Else
                                UpdateSizeLabels(realBytes, _manifest.Mandatory)
                            End If
                        End If
                    End If
                End Using
            End Using
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' تقسيم وتنسيق الملاحظات إلى بطاقات منفصلة جذابة وعصرية بأيقونات مناسبة
    ''' </summary>
    Private Sub PopulateNotesList(manifest As VbUpdateManifest)
        Dim items As New List(Of String)()

        ' 1. قراءة قائمة whats_new إذا كانت متوفرة
        If manifest.WhatsNew IsNot Nothing AndAlso manifest.WhatsNew.Count > 0 Then
            For Each item In manifest.WhatsNew
                Dim clean = CleanNoteText(item)
                If Not String.IsNullOrWhiteSpace(clean) AndAlso Not items.Contains(clean) Then
                    items.Add(clean)
                End If
            Next
        End If

        ' 2. تفكيك نص notes بسطور منفصلة
        If items.Count = 0 AndAlso Not String.IsNullOrWhiteSpace(manifest.Notes) Then
            Dim rawLines = manifest.Notes.Replace(vbCrLf, vbLf).Replace(vbCr, vbLf).Split(New Char() {ChrW(10)}, StringSplitOptions.RemoveEmptyEntries)
            For Each line In rawLines
                Dim clean = CleanNoteText(line)
                If Not String.IsNullOrWhiteSpace(clean) AndAlso Not items.Contains(clean) Then
                    items.Add(clean)
                End If
            Next
        End If

        ' 3. في حال عدم وجود نصوص نضع تحسينات افتراضية واضحة
        If items.Count = 0 Then
            items.Add("تحسينات شاملة على أداء واستقرار النظام وسرعة الاستجابة.")
            items.Add("تحديث ومعالجة جداول وبنية قاعدة البيانات تلقائياً.")
            items.Add("حماية واستمرار بيانات التفعيل دون الحاجة لإعادة إدخال كود الترخيص.")
            items.Add("نظام إشعارات عصري ومطور بتصميم البطاقات الداكنة.")
        End If

        ' 4. ضبط txtNotes كنسخة نصية منسقة بأسطر متباعدة
        txtNotes.Text = String.Join(vbCrLf & vbCrLf, items.Select(Function(it) "• " & it))

        ' 5. بناء بطاقات الملاحظات الأنيقة داخل FlowLayoutPanel
        pnlNotesList.SuspendLayout()
        pnlNotesList.Controls.Clear()

        Dim cardWidth = Math.Max(460, pnlNotesList.ClientSize.Width - 25)

        For Each item In items
            Dim card = CreateNoteCard(item, cardWidth)
            pnlNotesList.Controls.Add(card)
        Next

        pnlNotesList.ResumeLayout(True)
    End Sub

    Private Function CleanNoteText(raw As String) As String
        If String.IsNullOrWhiteSpace(raw) Then Return String.Empty
        Dim t = raw.Trim()
        While t.StartsWith("•") OrElse t.StartsWith("-") OrElse t.StartsWith("*")
            t = t.Substring(1).Trim()
        End While
        Return t
    End Function

    Private Function GetNoteIcon(text As String) As String
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
        ElseIf text.IndexOf("تخزين", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("قاعدة", StringComparison.OrdinalIgnoreCase) >= 0 OrElse text.IndexOf("بيانات", StringComparison.OrdinalIgnoreCase) >= 0 Then
            Return "💾"
        Else
            Return "✦"
        End If
    End Function

    Private Function CreateNoteCard(text As String, cardWidth As Integer) As Control
        Dim pnl As New Guna2Panel With {
            .Width = cardWidth,
            .BorderRadius = 8,
            .BorderThickness = 1,
            .BorderColor = Color.FromArgb(51, 65, 85),
            .FillColor = Color.FromArgb(30, 41, 59),
            .Margin = New Padding(0, 0, 0, 7),
            .Padding = New Padding(10, 8, 10, 8),
            .RightToLeft = RightToLeft.Yes
        }

        Dim icon = GetNoteIcon(text)
        Dim lblIcon As New Label With {
            .Text = icon,
            .Font = New Font("Segoe UI Emoji", 10.0!, FontStyle.Regular),
            .ForeColor = Color.FromArgb(56, 189, 248),
            .AutoSize = False,
            .Size = New Size(26, 24),
            .Location = New Point(pnl.Width - 34, 8),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .TextAlign = ContentAlignment.MiddleCenter
        }

        Dim lblText As New Label With {
            .Text = text,
            .Font = New Font("Segoe UI", 9.25!, FontStyle.Regular),
            .ForeColor = Color.FromArgb(241, 245, 249),
            .Location = New Point(10, 8),
            .Width = pnl.Width - 48,
            .AutoSize = True,
            .MaximumSize = New Size(pnl.Width - 48, 0),
            .RightToLeft = RightToLeft.Yes,
            .TextAlign = ContentAlignment.TopRight
        }

        pnl.Controls.Add(lblIcon)
        pnl.Controls.Add(lblText)

        ' تحديد ارتفاع البطاقة تلقائياً لملاءمة النص
        pnl.Height = Math.Max(42, lblText.Height + 18)

        Return pnl
    End Function

    Private Shared Function FormatFileSize(bytes As Long) As String
        If bytes <= 0 Then Return "-- MB"
        If bytes >= 1024L * 1024L * 1024L Then
            Dim gb = bytes / (1024.0 * 1024.0 * 1024.0)
            Return gb.ToString("0.0") & " GB"
        ElseIf bytes >= 1024L * 1024L Then
            Dim mb = bytes / (1024.0 * 1024.0)
            Return mb.ToString("0.0") & " MB"
        ElseIf bytes >= 1024L Then
            Dim kb = bytes / 1024.0
            Return kb.ToString("0") & " KB"
        Else
            Return bytes & " B"
        End If
    End Function

    Private Shared Function FormatFileSizeArabic(bytes As Long) As String
        If bytes <= 0 Then Return "غير محدد"
        If bytes >= 1024L * 1024L * 1024L Then
            Dim gb = bytes / (1024.0 * 1024.0 * 1024.0)
            Return gb.ToString("0.0") & " جيجابايت"
        ElseIf bytes >= 1024L * 1024L Then
            Dim mb = bytes / (1024.0 * 1024.0)
            Return mb.ToString("0.0") & " ميجابايت"
        ElseIf bytes >= 1024L Then
            Dim kb = bytes / 1024.0
            Return kb.ToString("0") & " كيلوبايت"
        Else
            Return bytes & " بايت"
        End If
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click, btnLater.Click
        Close()
    End Sub

    Private Async Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If _manifest Is Nothing Then
            Close()
            Return
        End If

        btnUpdate.Enabled = False
        btnLater.Enabled = False
        btnClose.Enabled = False
        pnlProgress.Visible = True
        prgUpdate.Value = 0

        Dim progress = New Progress(Of Integer)(
            Sub(value)
                Dim safeVal = Math.Max(0, Math.Min(100, value))
                prgUpdate.Value = safeVal
                lblProgressStatus.Text = "جارٍ تنزيل ملفات التحديث... " & safeVal & "%"
            End Sub)

        lblProgressStatus.Text = "جارٍ الاتصال بسيرفر التحديثات وتنزيل الحزمة..."
        Dim errorMessage = Await UpdateCoordinator.DownloadAndLaunchAsync(_manifest, progress)
        If String.IsNullOrWhiteSpace(errorMessage) Then
            lblProgressStatus.Text = "تم التنزيل بنجاح! جارٍ تطبيق التحديث وإعادة التشغيل..."
            Await Task.Delay(1000)
            Application.Exit()
        Else
            MessageBox.Show(errorMessage, "فشل التحديث", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnUpdate.Enabled = True
            btnLater.Enabled = Not _manifest.Mandatory
            btnClose.Enabled = Not _manifest.Mandatory
            pnlProgress.Visible = False
        End If
    End Sub
End Class