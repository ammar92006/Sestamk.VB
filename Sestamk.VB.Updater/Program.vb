Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.IO.Compression
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Module Program

    <STAThread()>
    Sub Main(args As String())
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Dim pendingPath As String = Nothing
        Dim isShadowRunner As Boolean = False

        ' تحليل معاملات سطر الأوامر
        For i As Integer = 0 To args.Length - 1
            If args(i).Equals("--pending", StringComparison.OrdinalIgnoreCase) AndAlso i + 1 < args.Length Then
                pendingPath = args(i + 1).Trim(""""c)
            ElseIf args(i).Equals("--shadow-runner", StringComparison.OrdinalIgnoreCase) Then
                isShadowRunner = True
            End If
        Next

        If String.IsNullOrWhiteSpace(pendingPath) OrElse Not File.Exists(pendingPath) Then
            MessageBox.Show("لم يتم تمرير ملف معلومات التحديث الصحيح.", "أداة التحديث - سستمك", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' قراءة محتوى ملف التحديث
        Dim jsonContent As String = ""
        Try
            jsonContent = File.ReadAllText(pendingPath)
        Catch ex As Exception
            MessageBox.Show("تعذر قراءة ملف معلومات التحديث: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim packagePath = ExtractJsonField(jsonContent, "package_path")
        Dim targetPath = ExtractJsonField(jsonContent, "target_path")
        Dim mainExe = ExtractJsonField(jsonContent, "main_exe")
        Dim newVersion = ExtractJsonField(jsonContent, "version")

        ' ══════════════════════════════════════════════════════════════════════════════
        ' أمان (إغلاق ثغرة تصعيد الصلاحيات): هذه الأداة تُشغَّل بصلاحيات مسؤول وتكتب داخل
        ' مجلد التثبيت، بينما ملف pending-update.json يقع في مجلد يمكن لأي مستخدم محلي
        ' كتابته. لذلك:
        '   • مجلد الهدف يُشتق من موضع الأداة نفسها (مجلد تثبيت محمي)، أو يُمرَّر صراحةً
        '     ويُقبل فقط إذا كان مجلد تثبيت حقيقي يحتوي Sestamk.exe — فيتعذّر توجيه
        '     الكتابة إلى أي مجلد آخر على النظام.
        '   • البرنامج الأساسي المستهدف يُشتق من مجلد الهدف نفسه، فلا يمكن استخدام
        '     الأداة لإنهاء عملية أخرى (كان target_path/main_exe من الملف يسمحان بذلك).
        '   • لا تُنسخ الأداة ولا تُنفَّذ من أي مجلد قابل للكتابة من المستخدمين؛
        '     استُبدلت النسخة الظلية في ProgramData بمشغّل محمي يُثبّته المثبّت.
        ' ══════════════════════════════════════════════════════════════════════════════
        Dim explicitTarget As String = ReadArg(args, "--target")
        If Not String.IsNullOrWhiteSpace(explicitTarget) Then
            Dim candidate As String = String.Empty
            Try
                candidate = Path.GetFullPath(explicitTarget).TrimEnd(Path.DirectorySeparatorChar)
            Catch
                candidate = String.Empty
            End Try
            If String.IsNullOrWhiteSpace(candidate) OrElse Not File.Exists(Path.Combine(candidate, "Sestamk.exe")) Then
                MessageBox.Show("مجلد التثبيت المستهدف غير صالح أو غير موثوق — تم إلغاء التحديث.",
                                "تحديث مرفوض", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            targetPath = candidate
        Else
            targetPath = ResolveInstallTarget(AppDomain.CurrentDomain.BaseDirectory)
        End If

        ' البرنامج الأساسي يُشتق دائماً من مجلد الهدف الموثوق — لا يُقرأ من الملف
        mainExe = Path.Combine(targetPath, "Sestamk.exe")

        ' ─── تشغيل واجهة التحديث العصرية ───
        ' ملاحظة أمنية: أُزيلت آلية "النسخة الظلية" القديمة التي كانت تنسخ الأداة إلى
        ' %ProgramData%\Sestamk\updates\runner (مجلد قابل للكتابة من أي مستخدم) ثم تُشغّلها
        ' بصلاحيات مسؤول — وهو ما كان يتيح لأي مستخدم محلي استبدال الملف التنفيذي قبل
        ' تنفيذه مرفوعاً. استبدال الملفات المقفولة يتولاه "Rename Trick" داخل الواجهة.
        Dim updaterForm As New FrmModernUpdater(pendingPath, packagePath, targetPath, mainExe, newVersion)
        Application.Run(updaterForm)
    End Sub

    Public Function ExtractJsonField(json As String, fieldName As String) As String
        Dim pattern As String = """" & fieldName & """\s*:\s*""([^""]+)"""
        Dim match = Regex.Match(json, pattern, RegexOptions.IgnoreCase)
        If match.Success Then
            Return match.Groups(1).Value.Replace("\\", "\")
        End If
        Return String.Empty
    End Function

    ''' <summary>قراءة قيمة معامل سطر أوامر بالشكل --name "value".</summary>
    Public Function ReadArg(args As String(), name As String) As String
        If args Is Nothing Then Return String.Empty
        For i As Integer = 0 To args.Length - 2
            If args(i).Equals(name, StringComparison.OrdinalIgnoreCase) Then
                Return args(i + 1).Trim(""""c)
            End If
        Next
        Return String.Empty
    End Function

    ''' <summary>
    ''' تحديد مجلد التثبيت انطلاقاً من موضع الأداة نفسها — وليس من ملف JSON قابل للكتابة
    ''' من أي مستخدم محلي. يفحص المجلد ثم المجلد الأعلى بحثاً عن Sestamk.exe
    ''' (لأن الأداة تُوضع أحياناً في مجلد فرعي مثل tools).
    ''' </summary>
    Public Function ResolveInstallTarget(startDir As String) As String
        Dim dir As String = Path.GetFullPath(startDir).TrimEnd(Path.DirectorySeparatorChar)
        Try
            If File.Exists(Path.Combine(dir, "Sestamk.exe")) Then Return dir
            Dim parent = Directory.GetParent(dir)
            If parent IsNot Nothing AndAlso File.Exists(Path.Combine(parent.FullName, "Sestamk.exe")) Then
                Return parent.FullName.TrimEnd(Path.DirectorySeparatorChar)
            End If
        Catch
        End Try
        Return dir
    End Function

    ''' <summary>
    ''' مصدر الحقيقة الموثوق لوصف الإصدار (HTTPS ثابت) — لا يُقرأ من أي ملف محلي.
    ''' </summary>
    Public Const TrustedManifestUrl As String = "https://github.com/ammar92006/Sestamk.VB/releases/latest/download/manifest.json"

    ''' <summary>
    ''' التحقق الإلزامي من بصمة حزمة التحديث مقابل مانيفست الإصدار الرسمي على HTTPS.
    ''' السبب: العملية تعمل بصلاحيات مسؤول وتكتب داخل مجلد التثبيت، وملف
    ''' pending-update.json قابل للكتابة من أي مستخدم محلي — فلا يجوز الاعتماد على أي
    ''' بصمة قادمة منه. تُرجع نصاً فارغاً عند النجاح، أو سبب الرفض.
    ''' </summary>
    Public Function VerifyPackageFromTrustedSource(packagePath As String) As String
        Try
            If String.IsNullOrWhiteSpace(packagePath) OrElse Not File.Exists(packagePath) Then
                Return "حزمة التحديث غير موجودة."
            End If

            Dim manifestJson As String
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(30)
                manifestJson = client.GetStringAsync(TrustedManifestUrl).GetAwaiter().GetResult()
            End Using

            Dim expected As String = ExtractJsonField(manifestJson, "sha256")
            If String.IsNullOrWhiteSpace(expected) OrElse expected.Trim().Length <> 64 Then
                Return "تعذّر قراءة البصمة الرسمية (SHA-256) من مانيفست الإصدار المنشور — تم رفض التحديث."
            End If

            Dim actual As String
            Using sha As SHA256 = SHA256.Create()
                Using fs As New FileStream(packagePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                    actual = BitConverter.ToString(sha.ComputeHash(fs)).Replace("-", String.Empty)
                End Using
            End Using

            If Not String.Equals(actual, expected.Trim(), StringComparison.OrdinalIgnoreCase) Then
                Return "بصمة حزمة التحديث لا تطابق البصمة الرسمية المنشورة — تم رفض التحديث لأسباب أمنية."
            End If

            Return String.Empty
        Catch ex As Exception
            Return "تعذّر التحقق من سلامة حزمة التحديث من المصدر الرسمي (" & ex.Message & ") — تم رفض التحديث."
        End Try
    End Function

End Module

''' <summary>
''' شاشة التحديث العصرية الاحترافية المتناسقة مع ثيم سستمك الداكن وحركات التقدم الانسيابية
''' </summary>
Public Class FrmModernUpdater
    Inherits Form

    Private ReadOnly _pendingPath As String
    Private ReadOnly _packagePath As String
    Private ReadOnly _targetPath As String
    Private ReadOnly _mainExe As String
    Private ReadOnly _newVersion As String

    Private lblTitle As Label
    Private lblBadge As Label
    Private lblStatus As Label
    Private lblDetail As Label
    Private lblPercentage As Label
    Private lblSecurityNote As Label
    Private pgbBar As ModernProgressBar
    Private iconPanel As Panel

    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(nLeftRect As Integer, nTopRect As Integer, nRightRect As Integer, nBottomRect As Integer, nWidthEllipse As Integer, nHeightEllipse As Integer) As IntPtr
    End Function

    Public Sub New(pendingPath As String, packagePath As String, targetPath As String, mainExe As String, newVersion As String)
        _pendingPath = pendingPath
        _packagePath = packagePath
        _targetPath = targetPath
        _mainExe = mainExe
        _newVersion = If(String.IsNullOrWhiteSpace(newVersion), "1.2.6", newVersion)

        InitializeUI()
    End Sub

    Private Sub InitializeUI()
        Me.Text = "مُحَدِّث سستمك - Sestamk Updater"
        Me.Size = New Size(540, 270)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(15, 23, 42) ' Slate 950
        Me.ForeColor = Color.White
        Me.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        Me.DoubleBuffered = True
        Me.ShowInTaskbar = True
        Me.RightToLeft = RightToLeft.Yes
        Me.RightToLeftLayout = True

        ' حواف ناعمة دائرية
        Try
            Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20))
        Catch
        End Try

        ' أيقونة تحديث عصرية
        iconPanel = New Panel() With {
            .Size = New Size(44, 44),
            .Location = New Point(Width - 68, 24),
            .BackColor = Color.Transparent
        }
        AddHandler iconPanel.Paint, Sub(s, e)
                                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                                        Using brush As New LinearGradientBrush(iconPanel.ClientRectangle, Color.FromArgb(6, 182, 212), Color.FromArgb(16, 185, 129), LinearGradientMode.ForwardDiagonal)
                                            e.Graphics.FillEllipse(brush, 2, 2, 40, 40)
                                        End Using
                                        Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                                            Using f As New Font("Segoe UI", 16.0F, FontStyle.Bold)
                                                e.Graphics.DrawString("⟳", f, Brushes.White, New RectangleF(0, 0, 44, 44), sf)
                                            End Using
                                        End Using
                                    End Sub
        Me.Controls.Add(iconPanel)

        ' العنوان الرئيسي
        lblTitle = New Label() With {
            .Text = "تحديث برنامج سستمك",
            .Font = New Font("Segoe UI", 13.5F, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(130, 22),
            .AutoSize = True
        }
        Me.Controls.Add(lblTitle)

        ' شارة الإصدار الجديد
        lblBadge = New Label() With {
            .Text = "v" & _newVersion.TrimStart("v"c),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(224, 242, 254),
            .BackColor = Color.FromArgb(14, 116, 144),
            .Padding = New Padding(6, 2, 6, 2),
            .Location = New Point(lblTitle.Left - 75, 27),
            .AutoSize = True
        }
        Me.Controls.Add(lblBadge)

        ' نص الحالة العامة
        lblStatus = New Label() With {
            .Text = "جاري تهيئة وتأمين بيئة التحديث...",
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(226, 232, 240),
            .Location = New Point(24, 82),
            .Size = New Size(Width - 48, 24)
        }
        Me.Controls.Add(lblStatus)

        ' شريط التقدم العصري
        pgbBar = New ModernProgressBar() With {
            .Location = New Point(24, 116),
            .Size = New Size(Width - 48, 16),
            .Maximum = 100,
            .Value = 0
        }
        Me.Controls.Add(pgbBar)

        ' النسبة المئوية
        lblPercentage = New Label() With {
            .Text = "0%",
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(16, 185, 129),
            .Location = New Point(24, 140),
            .Size = New Size(70, 22),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        Me.Controls.Add(lblPercentage)

        ' تفاصيل الملف الجاري نقله
        lblDetail = New Label() With {
            .Text = "انتظار إغلاق العمليات السابقة...",
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(148, 163, 184),
            .Location = New Point(95, 142),
            .Size = New Size(Width - 120, 20),
            .AutoEllipsis = True
        }
        Me.Controls.Add(lblDetail)

        ' ملاحظة أمان التفعيل والبيانات
        lblSecurityNote = New Label() With {
            .Text = "✓ يتم الحفاظ التام على بيانات التفعيل، الإعدادات، وقواعد البيانات تلقائياً دون أي فقدان.",
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(100, 116, 139),
            .Location = New Point(24, 230),
            .Size = New Size(Width - 48, 20)
        }
        Me.Controls.Add(lblSecurityNote)

        AddHandler Me.Shown, AddressOf StartUpdateAsync
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' شريط علوي ملون أنيق
        Using brush As New LinearGradientBrush(New Rectangle(0, 0, Width, 4), Color.FromArgb(6, 182, 212), Color.FromArgb(16, 185, 129), LinearGradientMode.Horizontal)
            e.Graphics.FillRectangle(brush, 0, 0, Width, 4)
        End Using

        ' إطار هادئ حول النافذة
        Using pen As New Pen(Color.FromArgb(51, 65, 85), 1.5F)
            e.Graphics.DrawRectangle(pen, 1, 1, Width - 2, Height - 2)
        End Using
    End Sub

    Private Async Sub StartUpdateAsync(sender As Object, e As EventArgs)
        Dim tempOldFiles As New List(Of String)()
        Try
            ' 0) أمان: التحقق الإلزامي من بصمة الحزمة مقابل المانيفست الرسمي على HTTPS
            '    قبل إغلاق البرنامج أو كتابة أي ملف — إغلاق صامت لأي حزمة غير موثوقة.
            lblStatus.Text = "جاري التحقق من سلامة حزمة التحديث..."
            lblDetail.Text = "مطابقة البصمة الرقمية (SHA-256) مع المصدر الرسمي..."
            pgbBar.Value = 3
            lblPercentage.Text = "3%"

            Dim rejection As String = Await Task.Run(Function() VerifyPackageFromTrustedSource(_packagePath))
            If Not String.IsNullOrEmpty(rejection) Then
                pgbBar.Value = 0
                lblPercentage.Text = "0%"
                lblStatus.Text = "⛔ تم رفض التحديث لأسباب أمنية"
                lblDetail.Text = rejection
                MessageBox.Show(rejection & vbCrLf & vbCrLf & "لم يتم تعديل أي ملف في البرنامج.",
                                "تحديث مرفوض", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
                Return
            End If

            ' 1) إغلاق البرنامج الأساسي وفك القفل عن الملفات
            lblStatus.Text = "جاري إغلاق نظام سستمك وفك قفل الملفات..."
            lblDetail.Text = "انتظار تحرير العمليات في الذاكرة..."
            Await Task.Delay(1000)

            Await Task.Run(Sub() EnsureProcessExited(_mainExe, 10))

            If Not File.Exists(_packagePath) Then
                MessageBox.Show("حزمة التحديث غير موجودة: " & _packagePath, "خطأ في التحديث", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RestartMainApp()
                Application.Exit()
                Return
            End If

            ' 2) استخراج ملفات الحزمة مع التقدم الانسيابي وخدعة إعادة التسمية للملفات المحجوزة
            lblStatus.Text = "جاري فك ضغط واستبدال ملفات النظام الحديثة..."
            pgbBar.Value = 5
            lblPercentage.Text = "5%"

            Await Task.Run(Sub()
                               Using archive As ZipArchive = ZipFile.OpenRead(_packagePath)
                                   Dim totalEntries = archive.Entries.Count
                                   Dim currentIndex = 0

                                   For Each entry As ZipArchiveEntry In archive.Entries
                                       currentIndex += 1
                                       Dim destPath = Path.GetFullPath(Path.Combine(_targetPath, entry.FullName))

                                       ' حماية ضد Zip Slip — يجب أن يقع المسار داخل مجلد الهدف نفسه
                                       ' (المقارنة بالبادئة وحدها تسمح بمجلد مجاور مثل C:\AppEvil يطابق C:\App)
                                       Dim targetRoot = Path.GetFullPath(_targetPath).TrimEnd("\"c)
                                       If Not destPath.StartsWith(targetRoot & "\", StringComparison.OrdinalIgnoreCase) Then
                                           Continue For
                                       End If

                                       Dim entryName = entry.Name
                                       Dim pct = 5 + CInt((currentIndex / Math.Max(1, totalEntries)) * 85)

                                       Me.BeginInvoke(Sub()
                                                          pgbBar.Value = pct
                                                          lblPercentage.Text = pct & "%"
                                                          lblDetail.Text = "جاري تحديث: " & If(String.IsNullOrEmpty(entryName), entry.FullName, entryName) & " (" & currentIndex & " من " & totalEntries & ")"
                                                      End Sub)

                                       If String.IsNullOrEmpty(entryName) Then
                                           ' مجلد
                                           Directory.CreateDirectory(destPath)
                                       ElseIf String.Equals(entryName, "update.exe", StringComparison.OrdinalIgnoreCase) OrElse String.Equals(entryName, "Sestamk.VB.Updater.exe", StringComparison.OrdinalIgnoreCase) Then
                                           Try
                                               entry.ExtractToFile(destPath, overwrite:=True)
                                           Catch
                                           End Try
                                       Else
                                           ' ملف
                                           Directory.CreateDirectory(Path.GetDirectoryName(destPath))

                                           ' تطبيق خدعة Rename Trick للملفات المقفولة
                                           Dim retries As Integer = 5
                                           Dim extracted As Boolean = False

                                           While retries > 0 AndAlso Not extracted
                                               Try
                                                   entry.ExtractToFile(destPath, overwrite:=True)
                                                   extracted = True
                                               Catch exIo As IOException
                                                   ' إذا كان الملف محجوزاً بواسطة ويندوز، نقوم بتغيير اسمه أولاً
                                                   Dim oldRenamePath = destPath & ".old_" & Guid.NewGuid().ToString("N").Substring(0, 6)
                                                   Try
                                                       If File.Exists(destPath) Then
                                                           File.Move(destPath, oldRenamePath)
                                                           tempOldFiles.Add(oldRenamePath)
                                                       End If
                                                       entry.ExtractToFile(destPath, overwrite:=True)
                                                       extracted = True
                                                   Catch
                                                       retries -= 1
                                                       Thread.Sleep(500)
                                                   End Try
                                               Catch
                                                   retries -= 1
                                                   Thread.Sleep(500)
                                               End Try
                                           End While
                                       End If
                                       Thread.Sleep(15) ' تأثير بصري سلس للحركة
                                   Next
                               End Using
                           End Sub)

            ' 3) تنظيف الملفات المؤقتة
            lblStatus.Text = "تم تحديث كافة الملفات بنجاح! جاري إنهاء التثبيت..."
            lblDetail.Text = "تنظيف الملفات المؤقتة وإعادة التشغيل..."
            pgbBar.Value = 95
            lblPercentage.Text = "95%"
            Await Task.Delay(600)

            Try
                If File.Exists(_pendingPath) Then File.Delete(_pendingPath)
                If File.Exists(_packagePath) Then File.Delete(_packagePath)
                For Each oldF As String In tempOldFiles
                    Try
                        If File.Exists(oldF) Then File.Delete(oldF)
                    Catch
                    End Try
                Next
            Catch
            End Try

            pgbBar.Value = 100
            lblPercentage.Text = "100%"
            lblStatus.Text = "✅ تم اكتمال التحديث بنجاح! جاري تشغيل سستمك..."
            lblDetail.Text = "انتهى التحديث، جاري فتح النظام الآن."
            Await Task.Delay(900)

            ' 4) تحديث ملفات أداة التحديث في مجلد البرنامج بالأداة الحديثة إن كنا نعمل من مجلد خارجي
            Try
                Dim currentRunnerExe = Process.GetCurrentProcess().MainModule.FileName
                If Not currentRunnerExe.StartsWith(_targetPath.TrimEnd(Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase) Then
                    Dim toolsDir = Path.Combine(_targetPath, "tools")
                    Directory.CreateDirectory(toolsDir)
                    File.Copy(currentRunnerExe, Path.Combine(toolsDir, "update.exe"), True)
                    File.Copy(currentRunnerExe, Path.Combine(toolsDir, "Sestamk.VB.Updater.exe"), True)
                    File.Copy(currentRunnerExe, Path.Combine(_targetPath, "update.exe"), True)
                    File.Copy(currentRunnerExe, Path.Combine(_targetPath, "Sestamk.VB.Updater.exe"), True)
                End If
            Catch
            End Try

            ' 5) إعادة تشغيل سستمك مع تمرير مؤشر ما بعد التحديث
            RestartMainApp()
            Application.Exit()

        Catch ex As Exception
            ' أمان واستقرار: استعادة الملفات الأصلية فوراً في حال حدوث أي خطأ غير متوقع أثناء الفك
            Try
                For Each oldF In tempOldFiles
                    If File.Exists(oldF) Then
                        Dim markerIdx = oldF.IndexOf(".old_")
                        If markerIdx > 0 Then
                            Dim originalDest = oldF.Substring(0, markerIdx)
                            If File.Exists(originalDest) Then File.Delete(originalDest)
                            File.Move(oldF, originalDest)
                        End If
                    End If
                Next
            Catch
            End Try

            MessageBox.Show("حدث خطأ غير متوقع أثناء تثبيت التحديث:" & vbCrLf & ex.Message & vbCrLf & vbCrLf & "✓ تمت استعادة الملفات السابقة بنجاح لحماية استقرار النظام.", "خطأ في التحديث", MessageBoxButtons.OK, MessageBoxIcon.Error)
            RestartMainApp()
            Application.Exit()
        End Try
    End Sub

    Private Sub EnsureProcessExited(mainExe As String, timeoutSec As Integer)
        ' إنهاء أي عمليات قديمة للمحدث بخلاف العملية الحالية
        Try
            Dim currentPid = Process.GetCurrentProcess().Id
            For Each uName As String In New String() {"update", "Sestamk.VB.Updater"}
                For Each up As Process In Process.GetProcessesByName(uName)
                    Try
                        If up.Id <> currentPid AndAlso Not up.HasExited Then
                            up.Kill()
                            up.WaitForExit(1500)
                        End If
                    Catch
                    End Try
                Next
            Next
        Catch
        End Try

        If String.IsNullOrWhiteSpace(mainExe) Then Return
        Dim pName = Path.GetFileNameWithoutExtension(mainExe)
        Dim sw = Stopwatch.StartNew()

        ' 1) محاولة إغلاق آمن: إرسال WM_CLOSE للنوافذ الرئيسية ليتوقف النظام بأمان (حفظ الفاتورة الجارية)
        Try
            For Each p As Process In Process.GetProcessesByName(pName)
                Try
                    If Not p.HasExited AndAlso p.MainWindowHandle <> IntPtr.Zero Then
                        p.CloseMainWindow()
                    End If
                Catch
                End Try
            Next
        Catch
        End Try

        ' 2) الانتظار حتى تخرج العملية بنفسها
        While sw.Elapsed.TotalSeconds < timeoutSec
            Dim list = Process.GetProcessesByName(pName)
            If list.Length = 0 Then Return
            Thread.Sleep(500)
        End While

        ' 3) إنهاء قسري كحل أخير فقط إذا لم تغلق بعد المهلة كاملة
        Try
            For Each p As Process In Process.GetProcessesByName(pName)
                Try
                    If Not p.HasExited Then
                        p.Kill()
                        p.WaitForExit(3000)
                    End If
                Catch
                End Try
            Next
        Catch
        End Try
        Thread.Sleep(800)
    End Sub

    Private Sub RestartMainApp()
        If Not String.IsNullOrWhiteSpace(_mainExe) AndAlso File.Exists(_mainExe) Then
            Try
                Dim psi As New ProcessStartInfo(_mainExe) With {
                    .UseShellExecute = True,
                    .WorkingDirectory = Path.GetDirectoryName(_mainExe),
                    .Arguments = "--post-update"
                }
                Process.Start(psi)
            Catch ex As Exception
                MessageBox.Show("تعذر تشغيل البرنامج الأساسي: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

End Class

''' <summary>
''' شريط تقدم عصري ذو تعبئة متدرجة وحواف دائرية أنيقة
''' </summary>
Public Class ModernProgressBar
    Inherits Control

    Private _value As Integer = 0
    Private _maximum As Integer = 100

    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        Me.Height = 16
        Me.BackColor = Color.FromArgb(30, 41, 59) ' Slate 800
    End Sub

    Public Property Value As Integer
        Get
            Return _value
        End Get
        Set(val As Integer)
            _value = Math.Max(0, Math.Min(_maximum, val))
            Invalidate()
        End Set
    End Property

    Public Property Maximum As Integer
        Get
            Return _maximum
        End Get
        Set(val As Integer)
            _maximum = Math.Max(1, val)
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = Me.ClientRectangle
        rect.Width -= 1
        rect.Height -= 1

        ' خلفية المسار
        Using bgPath = GetRoundedPath(rect, rect.Height \ 2)
            Using bgBrush As New SolidBrush(Color.FromArgb(30, 41, 59))
                g.FillPath(bgBrush, bgPath)
            End Using
            Using borderPen As New Pen(Color.FromArgb(51, 65, 85), 1.0F)
                g.DrawPath(borderPen, bgPath)
            End Using
        End Using

        ' تعبئة التقدم بتدرج لوني ساحر (Cyan -> Emerald)
        If _value > 0 Then
            Dim fillWidth = CInt((_value / _maximum) * rect.Width)
            If fillWidth > 4 Then
                Dim fillRect As New Rectangle(rect.X, rect.Y, fillWidth, rect.Height)
                Using fillPath = GetRoundedPath(fillRect, rect.Height \ 2)
                    Using brush As New LinearGradientBrush(fillRect, Color.FromArgb(6, 182, 212), Color.FromArgb(16, 185, 129), LinearGradientMode.Horizontal)
                        g.FillPath(brush, fillPath)
                    End Using
                End Using
            End If
        End If
    End Sub

    Private Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim r = Math.Min(radius, rect.Height \ 2)
        Dim d = r * 2
        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function
End Class
