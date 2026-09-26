Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms

Module Program

    Sub Main(args As String())
        Dim pendingPath As String = Nothing

        ' تحليل معاملات سطر الأوامر: --pending "<path>"
        For i As Integer = 0 To args.Length - 1
            If args(i).Equals("--pending", StringComparison.OrdinalIgnoreCase) AndAlso i + 1 < args.Length Then
                pendingPath = args(i + 1).Trim(""""c)
                Exit For
            End If
        Next

        If String.IsNullOrWhiteSpace(pendingPath) OrElse Not File.Exists(pendingPath) Then
            MessageBox.Show("لم يتم تمرير ملف معلومات التحديث الصحيح.", "أداة التحديث - سستمك", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim mainExe As String = Nothing
        Dim targetPath As String = Nothing
        Dim packagePath As String = Nothing

        Try
            Dim jsonContent As String = File.ReadAllText(pendingPath)
            packagePath = ExtractJsonField(jsonContent, "package_path")
            targetPath = ExtractJsonField(jsonContent, "target_path")
            mainExe = ExtractJsonField(jsonContent, "main_exe")

            If String.IsNullOrWhiteSpace(packagePath) OrElse Not File.Exists(packagePath) Then
                MessageBox.Show("حزمة التحديث غير موجودة: " & packagePath, "خطأ في التحديث", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RestartMainApp(mainExe)
                Return
            End If

            If String.IsNullOrWhiteSpace(targetPath) OrElse Not Directory.Exists(targetPath) Then
                targetPath = AppDomain.CurrentDomain.BaseDirectory
            End If

            ' 1) إمهال وانتظار إغلاق التطبيق الرئيسي بالكامل
            WaitAndEnsureProcessExited(mainExe, 15)

            ' 2) استخراج ملفات الحزمة واستبدالها في مجلد البرنامج
            Using archive As ZipArchive = ZipFile.OpenRead(packagePath)
                For Each entry As ZipArchiveEntry In archive.Entries
                    Dim destinationPath = Path.GetFullPath(Path.Combine(targetPath, entry.FullName))

                    ' حماية مسار الملفات ضد Zip Slip
                    If Not destinationPath.StartsWith(targetPath, StringComparison.OrdinalIgnoreCase) Then
                        Continue For
                    End If

                    If String.IsNullOrEmpty(entry.Name) Then
                        ' مجلد
                        Directory.CreateDirectory(destinationPath)
                    Else
                        ' ملف
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath))
                        Dim retries As Integer = 3
                        While retries > 0
                            Try
                                entry.ExtractToFile(destinationPath, overwrite:=True)
                                Exit While
                            Catch ex As IOException
                                retries -= 1
                                If retries = 0 Then Throw
                                Thread.Sleep(800)
                            End Try
                        End While
                    End If
                Next
            End Using

            ' 3) تنظيف الملفات المؤقتة بعد نجاح الاستبدال
            Try
                If File.Exists(pendingPath) Then File.Delete(pendingPath)
                If File.Exists(packagePath) Then File.Delete(packagePath)
            Catch
            End Try

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تثبيت التحديث: " & vbCrLf & ex.Message, "فشل التحديث", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' 4) إعادة تشغيل البرنامج الرئيسي دائماً
            RestartMainApp(mainExe)
        End Try
    End Sub

    Private Sub WaitAndEnsureProcessExited(mainExe As String, timeoutSeconds As Integer)
        If String.IsNullOrWhiteSpace(mainExe) Then
            Thread.Sleep(2000)
            Return
        End If

        Dim processName As String = Path.GetFileNameWithoutExtension(mainExe)
        Dim sw As Stopwatch = Stopwatch.StartNew()

        While sw.Elapsed.TotalSeconds < timeoutSeconds
            Dim runningProcesses = Process.GetProcessesByName(processName)
            If runningProcesses.Length = 0 Then
                Thread.Sleep(500)
                Return
            End If
            Thread.Sleep(500)
        End While

        ' إذا استمر التطبيق بالعمل بعد انقضاء المهلة نقوم بإنهائه قسراً لفك قفل الملفات
        Try
            For Each p In Process.GetProcessesByName(processName)
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
        Thread.Sleep(1000)
    End Sub

    Private Sub RestartMainApp(mainExe As String)
        If Not String.IsNullOrWhiteSpace(mainExe) AndAlso File.Exists(mainExe) Then
            Try
                Dim psi As New ProcessStartInfo(mainExe) With {
                    .UseShellExecute = True,
                    .WorkingDirectory = Path.GetDirectoryName(mainExe)
                }
                Process.Start(psi)
            Catch ex As Exception
                MessageBox.Show("تعذر تشغيل البرنامج الرئيسي: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Function ExtractJsonField(json As String, fieldName As String) As String
        Dim pattern As String = """" & fieldName & """\s*:\s*""([^""]+)"""
        Dim match = Regex.Match(json, pattern, RegexOptions.IgnoreCase)
        If match.Success Then
            Return match.Groups(1).Value.Replace("\\", "\")
        End If
        Return String.Empty
    End Function

End Module
