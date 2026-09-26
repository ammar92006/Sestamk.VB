Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports Microsoft.Win32

Namespace Services

    ''' <summary>
    ''' حالات محرك SQL Server Express LocalDB
    ''' </summary>
    Public Enum LocalDbState
        NotInstalled = 0
        Stopped = 1
        Running = 2
        ErrorState = 3
    End Enum

    ''' <summary>
    ''' معلومات تفصيلية عن حالة محرك ونسخة LocalDB
    ''' </summary>
    Public Class LocalDbStatusInfo
        Public Property IsInstalled As Boolean = False
        Public Property Version As String = ""
        Public Property CliPath As String = ""
        Public Property State As LocalDbState = LocalDbState.NotInstalled
        Public Property InstanceName As String = "MSSQLLocalDB"
        Public Property InstancePipeName As String = ""
        Public Property RawOutput As String = ""

        Public ReadOnly Property StateDescription As String
            Get
                Select Case State
                    Case LocalDbState.Running
                        Return "يعمل بنشاط (Running) ✅"
                    Case LocalDbState.Stopped
                        Return "متوقف (Stopped) ⏸️"
                    Case LocalDbState.NotInstalled
                        Return "غير مثبت على هذا الجهاز ❌"
                    Case Else
                        Return "حالة غير معروفة / خطأ ⚠️"
                End Select
            End Get
        End Property
    End Class

    ''' <summary>
    ''' مدير دورة حياة محرك وخوادم Microsoft SQL Server Express LocalDB
    ''' مسؤول عن: كشف التثبيت، بدء وتشغيل الـ Instances، التثبيت الصامت، وإدارة ملفات MDF
    ''' </summary>
    Public Module LocalDbManager

        Public Const DefaultInstanceName As String = "MSSQLLocalDB"
        Public Const CustomAppInstanceName As String = "SestamkLocalDB"

        ' ══════════════════════════════════════════════════════════════════════
        ' 1. فحص وجود محرك LocalDB ومسار الأداة
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>
        ''' العثور على المسار الحقيقي لأداة SqlLocalDB.exe في مجلدات النظام المختلفة
        ''' </summary>
        Public Function GetLocalDbCliPath() As String
            Try
                ' 1) فحص المسارات القياسية لإصدارات SQL Server (من 2012 حتى 2025+)
                Dim knownVersions = New String() {"170", "160", "150", "140", "130", "120", "110"}
                Dim progFiles64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                Dim progFiles32 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)

                For Each ver In knownVersions
                    ' 64-bit path
                    Dim p64 = Path.Combine(progFiles64, "Microsoft SQL Server", ver, "Tools", "Binn", "SqlLocalDB.exe")
                    If File.Exists(p64) Then Return p64

                    ' 32-bit path
                    If Not String.IsNullOrEmpty(progFiles32) Then
                        Dim p32 = Path.Combine(progFiles32, "Microsoft SQL Server", ver, "Tools", "Binn", "SqlLocalDB.exe")
                        If File.Exists(p32) Then Return p32
                    End If
                Next

                ' 2) فحص سجل النظام (Registry)
                For Each rootPath In {"SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions",
                                      "SOFTWARE\WOW6432Node\Microsoft\Microsoft SQL Server Local DB\Installed Versions"}
                    Using key = Registry.LocalMachine.OpenSubKey(rootPath)
                        If key IsNot Nothing Then
                            For Each subKeyName In key.GetSubKeyNames()
                                Using subKey = key.OpenSubKey(subKeyName)
                                    If subKey IsNot Nothing Then
                                        Dim instDir = TryCast(subKey.GetValue("InstanceAPIPath"), String)
                                        If Not String.IsNullOrEmpty(instDir) Then
                                            ' InstanceAPIPath غالباً يشير لمجلد dll، الأداة التنفيذية تكون بجواره أو في Binn
                                            Dim candidateExe = Path.Combine(Path.GetDirectoryName(instDir), "SqlLocalDB.exe")
                                            If File.Exists(candidateExe) Then Return candidateExe
                                        End If
                                    End If
                                End Using
                            Next
                        End If
                    End Using
                Next

                ' 3) فحص مسارات PATH العامة
                Dim envPath = Environment.GetEnvironmentVariable("PATH")
                If Not String.IsNullOrEmpty(envPath) Then
                    For Each pathDir As String In envPath.Split(";"c)
                        Dim trimmed = pathDir.Trim().Trim(""""c)
                        If Not String.IsNullOrEmpty(trimmed) AndAlso Directory.Exists(trimmed) Then
                            Dim p = Path.Combine(trimmed, "SqlLocalDB.exe")
                            If File.Exists(p) Then Return p
                        End If
                    Next
                End If

            Catch ex As Exception
                Debug.WriteLine("GetLocalDbCliPath error: " & ex.Message)
            End Try

            Return ""
        End Function

        ''' <summary>
        ''' التحقق مما إذا كان محرك SQL Server LocalDB مثبتاً على نظام التشغيل
        ''' </summary>
        Public Function IsLocalDbInstalled() As Boolean
            If Not String.IsNullOrEmpty(GetLocalDbCliPath()) Then Return True

            ' التحقق الإضافي من وجود مفاتيح الريجستري الخاصة بـ LocalDB
            Try
                Using key1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions")
                    If key1 IsNot Nothing AndAlso key1.SubKeyCount > 0 Then Return True
                End Using
                Using key2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\Microsoft\Microsoft SQL Server Local DB\Installed Versions")
                    If key2 IsNot Nothing AndAlso key2.SubKeyCount > 0 Then Return True
                End Using
            Catch
            End Try

            Return False
        End Function

        ' ══════════════════════════════════════════════════════════════════════
        ' 2. تنفيذ أوامر LocalDB في عمليات خلفية صامتة (Silent Execution)
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>
        ''' تنفيذ أمر SqlLocalDB برمجياً دون إظهار أي نافذة أو شاشة CMD سوداء للمستخدم
        ''' </summary>
        Public Async Function ExecuteCliCommandAsync(arguments As String) As Task(Of Tuple(Of Integer, String))
            Dim cliPath = GetLocalDbCliPath()
            Dim exeToRun = If(Not String.IsNullOrEmpty(cliPath), cliPath, "sqllocaldb")

            Dim sbOutput As New StringBuilder()

            Dim psi As New ProcessStartInfo(exeToRun, arguments) With {
                .CreateNoWindow = True,
                .UseShellExecute = False,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .StandardOutputEncoding = Encoding.UTF8,
                .StandardErrorEncoding = Encoding.UTF8
            }

            Return Await Task.Run(Function()
                                      Try
                                          Using p As New Process()
                                              p.StartInfo = psi
                                              p.Start()

                                              Dim outStr = p.StandardOutput.ReadToEnd()
                                              Dim errStr = p.StandardError.ReadToEnd()
                                              p.WaitForExit(15000)

                                              If Not String.IsNullOrWhiteSpace(outStr) Then sbOutput.AppendLine(outStr)
                                              If Not String.IsNullOrWhiteSpace(errStr) Then sbOutput.AppendLine(errStr)

                                              Return Tuple.Create(p.ExitCode, sbOutput.ToString().Trim())
                                          End Using
                                      Catch ex As Exception
                                          Return Tuple.Create(-1, "خطأ في تشغيل sqllocaldb: " & ex.Message)
                                      End Try
                                  End Function).ConfigureAwait(False)
        End Function

        ' ══════════════════════════════════════════════════════════════════════
        ' 3. استعلام وبدء وتشغيل الـ Instances
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>
        ''' الاستعلام عن حالة نسخة LocalDB واستخراج اسمها وحالتها ورقم الـ Pipe
        ''' </summary>
        Public Async Function GetInstanceStatusAsync(Optional instanceName As String = DefaultInstanceName) As Task(Of LocalDbStatusInfo)
            Dim info As New LocalDbStatusInfo With {
                .InstanceName = instanceName,
                .IsInstalled = IsLocalDbInstalled(),
                .CliPath = GetLocalDbCliPath()
            }

            If Not info.IsInstalled Then
                info.State = LocalDbState.NotInstalled
                Return info
            End If

            Dim result = Await ExecuteCliCommandAsync($"info ""{instanceName}""").ConfigureAwait(False)
            info.RawOutput = result.Item2

            If result.Item1 <> 0 OrElse result.Item2.Contains("does not exist") OrElse result.Item2.Contains("غير موجود") Then
                info.State = LocalDbState.Stopped
                Return info
            End If

            ' استخراج الحالة من المخرجات: State: Running أو State: Stopped
            Dim matchState = Regex.Match(result.Item2, "State:\s*([A-Za-z]+)", RegexOptions.IgnoreCase)
            If matchState.Success Then
                Dim st = matchState.Groups(1).Value.Trim().ToLower()
                If st = "running" Then
                    info.State = LocalDbState.Running
                Else
                    info.State = LocalDbState.Stopped
                End If
            Else
                info.State = LocalDbState.Stopped
            End If

            ' استخراج الإصدار
            Dim matchVer = Regex.Match(result.Item2, "Version:\s*([0-9\.]+)", RegexOptions.IgnoreCase)
            If matchVer.Success Then
                info.Version = matchVer.Groups(1).Value.Trim()
            End If

            ' استخراج مسار الـ Named Pipe
            Dim matchPipe = Regex.Match(result.Item2, "Instance pipe name:\s*(np:[^\r\n]+)", RegexOptions.IgnoreCase)
            If matchPipe.Success Then
                info.InstancePipeName = matchPipe.Groups(1).Value.Trim()
            End If

            Return info
        End Function

        ''' <summary>
        ''' التأكد من إنشاء وتشغيل الـ Instance تلقائياً في الخلفية
        ''' </summary>
        Public Async Function EnsureInstanceRunningAsync(Optional instanceName As String = DefaultInstanceName) As Task(Of Boolean)
            If Not IsLocalDbInstalled() Then Return False

            Try
                ' 1) فحص الحالة الحالية
                Dim currentInfo = Await GetInstanceStatusAsync(instanceName).ConfigureAwait(False)
                If currentInfo.State = LocalDbState.Running Then Return True

                ' 2) إذا كانت النسخة غير موجودة، نقوم بإنشائها
                If currentInfo.RawOutput.Contains("does not exist") OrElse currentInfo.RawOutput.Contains("غير موجود") Then
                    Await ExecuteCliCommandAsync($"create ""{instanceName}""").ConfigureAwait(False)
                End If

                ' 3) تشغيل النسخة
                Dim startResult = Await ExecuteCliCommandAsync($"start ""{instanceName}""").ConfigureAwait(False)

                ' 4) تحقق نهائي من كونها أصبحت في حالة Running
                Dim checkInfo = Await GetInstanceStatusAsync(instanceName).ConfigureAwait(False)
                Return (checkInfo.State = LocalDbState.Running)

            Catch ex As Exception
                Debug.WriteLine("EnsureInstanceRunningAsync error: " & ex.Message)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' إيقاف نسخة LocalDB يدوياً
        ''' </summary>
        Public Async Function StopInstanceAsync(Optional instanceName As String = DefaultInstanceName) As Task(Of Boolean)
            If Not IsLocalDbInstalled() Then Return False
            Dim res = Await ExecuteCliCommandAsync($"stop ""{instanceName}"" -i").ConfigureAwait(False)
            Dim info = Await GetInstanceStatusAsync(instanceName).ConfigureAwait(False)
            Return (info.State = LocalDbState.Stopped)
        End Function

        ''' <summary>
        ''' بدء تشغيل نسخة LocalDB
        ''' </summary>
        Public Async Function StartInstanceAsync(Optional instanceName As String = DefaultInstanceName) As Task(Of Boolean)
            Return Await EnsureInstanceRunningAsync(instanceName).ConfigureAwait(False)
        End Function

        ' ══════════════════════════════════════════════════════════════════════
        ' 4. إدارة التثبيت الصامت لـ SqlLocalDB.msi (Fallback / Silent Install)
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>رابط التحميل المباشر الرسمي لحزمة SqlLocalDB من مايكروسوفت</summary>
        Public Const OfficialLocalDbDownloadUrl As String = "https://download.microsoft.com/download/8/4/c/84c6c430-e0f5-476d-bf43-eaaa222a72e0/SqlLocalDB.MSI"

        ''' <summary>
        ''' البحث عن ملف حزمة التثبيت SqlLocalDB.msi المرفقة مع البرنامج في كافة المسارات المتوقعة
        ''' </summary>
        Public Function FindLocalDbMsiInstaller() As String
            Dim searchPaths As New List(Of String) From {
                Path.Combine(Application.StartupPath, "redist", "SqlLocalDB.msi"),
                Path.Combine(Application.StartupPath, "SqlLocalDB.msi"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "redist", "SqlLocalDB.msi"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SqlLocalDB.msi"),
                Path.Combine(Application.StartupPath, "setup", "SqlLocalDB.msi"),
                Path.Combine(Application.StartupPath, "db", "SqlLocalDB.msi"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "redist", "SqlLocalDB.msi"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "Installer", "redist", "SqlLocalDB.msi"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "V1.0", "SqlLocalDB.msi"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "publish", "SqlLocalDB.msi")
            }

            ' فحص مسار ClickOnce الأصلي الذي تم التثبيت منه إن وُجد
            Try
                Dim actArgs = AppDomain.CurrentDomain.SetupInformation.ActivationArguments
                If actArgs IsNot Nothing AndAlso actArgs.ActivationData IsNot Nothing AndAlso actArgs.ActivationData.Length > 0 Then
                    Dim actUri As String = actArgs.ActivationData(0)
                    If Uri.IsWellFormedUriString(actUri, UriKind.Absolute) Then
                        Dim u As New Uri(actUri)
                        If u.IsFile Then
                            Dim actDir = Path.GetDirectoryName(u.LocalPath)
                            searchPaths.Add(Path.Combine(actDir, "SqlLocalDB.msi"))
                            searchPaths.Add(Path.Combine(actDir, "redist", "SqlLocalDB.msi"))
                        End If
                    End If
                End If
            Catch
            End Try

            ' فحص مجلد التنزيلات وسطح المكتب للمستخدم الحالي
            Try
                Dim userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                If Not String.IsNullOrEmpty(userProfile) Then
                    searchPaths.Add(Path.Combine(userProfile, "Downloads", "SqlLocalDB.msi"))
                    searchPaths.Add(Path.Combine(userProfile, "Downloads", "V1.0", "SqlLocalDB.msi"))
                    searchPaths.Add(Path.Combine(userProfile, "Desktop", "SqlLocalDB.msi"))
                    searchPaths.Add(Path.Combine(userProfile, "Desktop", "V1.0", "SqlLocalDB.msi"))
                End If
            Catch
            End Try

            ' فحص جذور وحدات التخزين والفلاشات المتصلة (Removable & Fixed Drives)
            Try
                For Each drive In DriveInfo.GetDrives()
                    If drive.IsReady Then
                        searchPaths.Add(Path.Combine(drive.RootDirectory.FullName, "SqlLocalDB.msi"))
                        searchPaths.Add(Path.Combine(drive.RootDirectory.FullName, "V1.0", "SqlLocalDB.msi"))
                        searchPaths.Add(Path.Combine(drive.RootDirectory.FullName, "redist", "SqlLocalDB.msi"))
                    End If
                Next
            Catch
            End Try

            For Each p In searchPaths
                Try
                    Dim fullPath = Path.GetFullPath(p)
                    If File.Exists(fullPath) Then Return fullPath
                Catch
                End Try
            Next

            Return ""
        End Function

        ''' <summary>
        ''' تنزيل حزمة SqlLocalDB.msi مباشرة من خوادم مايكروسوفت الرسمية
        ''' </summary>
        Public Async Function DownloadLocalDbMsiAsync(destinationPath As String, Optional progress As IProgress(Of Integer) = Nothing) As Task(Of Boolean)
            Try
                Using client As New System.Net.Http.HttpClient()
                    client.Timeout = TimeSpan.FromMinutes(10)
                    Using resp = Await client.GetAsync(OfficialLocalDbDownloadUrl, System.Net.Http.HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(False)
                        If Not resp.IsSuccessStatusCode Then Return False
                        Dim totalBytes As Long = If(resp.Content.Headers.ContentLength.HasValue, resp.Content.Headers.ContentLength.Value, -1L)

                        Dim dir = Path.GetDirectoryName(destinationPath)
                        If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)

                        Using stream = Await resp.Content.ReadAsStreamAsync().ConfigureAwait(False)
                            Using fileStream As New FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, True)
                                Dim buffer(8191) As Byte
                                Dim totalRead As Long = 0
                                Dim bytesRead As Integer = 0
                                Do
                                    bytesRead = Await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(False)
                                    If bytesRead <= 0 Then Exit Do
                                    Await fileStream.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(False)
                                    totalRead += bytesRead
                                    If totalBytes > 0 AndAlso progress IsNot Nothing Then
                                        Dim pct = CInt((totalRead * 100) / totalBytes)
                                        progress.Report(pct)
                                    End If
                                Loop
                            End Using
                        End Using
                        Return File.Exists(destinationPath) AndAlso New FileInfo(destinationPath).Length > 10000000
                    End Using
                End Using
            Catch ex As Exception
                Debug.WriteLine("DownloadLocalDbMsiAsync error: " & ex.Message)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' تثبيت محرك LocalDB صامتاً في الخلفية بدون أي تدخل من المستخدم
        ''' باستخدام: msiexec /i SqlLocalDB.msi /qn /norestart IACCEPTSQLLOCALDBLICENSETERMS=YES
        ''' </summary>
        Public Async Function InstallLocalDbSilentlyAsync(Optional msiPath As String = "") As Task(Of Boolean)
            Dim fileToInstall = If(Not String.IsNullOrEmpty(msiPath), msiPath, FindLocalDbMsiInstaller())
            If String.IsNullOrEmpty(fileToInstall) OrElse Not File.Exists(fileToInstall) Then
                Return False
            End If

            Return Await Task.Run(Function()
                                      Try
                                          Dim psi As New ProcessStartInfo("msiexec.exe") With {
                                              .Arguments = $"/i ""{fileToInstall}"" /qn /norestart IACCEPTSQLLOCALDBLICENSETERMS=YES",
                                              .CreateNoWindow = True,
                                              .UseShellExecute = False,
                                              .WindowStyle = ProcessWindowStyle.Hidden
                                          }

                                          Using p = Process.Start(psi)
                                              p.WaitForExit(180000) ' انتظار حتى 3 دقائق
                                              Return (p.ExitCode = 0 OrElse p.ExitCode = 3010)
                                          End Using
                                      Catch ex As Exception
                                          Debug.WriteLine("InstallLocalDbSilently error: " & ex.Message)
                                          Return False
                                      End Try
                                  End Function).ConfigureAwait(False)
        End Function

        ' ══════════════════════════════════════════════════════════════════════
        ' 5. بنية ملفات قاعدة البيانات ومسارات التخزين الآمنة
        ' ══════════════════════════════════════════════════════════════════════

        ''' <summary>
        ''' المسار الافتراضي الآمن لحفظ ملف قاعدة البيانات .mdf في LocalApplicationData
        ''' يضمن هذا المسار امتلاك المستخدم العادي لكافة صلاحيات القراءة والكتابة دون قيود UAC
        ''' </summary>
        Public Function GetDefaultDatabaseMdfPath(Optional dbName As String = "SestamkDB") As String
            Dim localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            Dim appDbFolder = Path.Combine(localAppData, "Sestamk", "Database")
            Return Path.Combine(appDbFolder, $"{dbName}.mdf")
        End Function

        ''' <summary>
        ''' التأكد من وجود مجلد حفظ قاعدة البيانات وتفويض الصلاحيات إن لزم
        ''' </summary>
        Public Function EnsureDatabaseDirectoryExists(Optional dbName As String = "SestamkDB") As String
            Dim mdfPath = GetDefaultDatabaseMdfPath(dbName)
            Dim folder = Path.GetDirectoryName(mdfPath)
            If Not Directory.Exists(folder) Then
                Directory.CreateDirectory(folder)
            End If
            Return folder
        End Function

        ''' <summary>
        ''' بناء ConnectionString خاصة بـ LocalDB تدعم AttachDbFilename أو الاتصال المباشر
        ''' </summary>
        Public Function BuildLocalDbConnectionString(Optional instanceName As String = DefaultInstanceName,
                                                    Optional dbName As String = "SestamkDB",
                                                    Optional attachMdfPath As String = "") As String
            Dim serverPart = $"(localdb)\{instanceName}"
            Dim attachPart = If(Not String.IsNullOrEmpty(attachMdfPath), $"AttachDbFilename={attachMdfPath};", "")

            Return $"Server={serverPart};{attachPart}Database={dbName};Integrated Security=True;" &
                   "MultipleActiveResultSets=True;Connect Timeout=30;Pooling=True;Max Pool Size=100;"
        End Function

    End Module

End Namespace
