Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Net.NetworkInformation
Imports System.Windows.Forms
Imports System.Threading.Tasks
Imports System.Security.Cryptography
Imports System.Text

Public Class Login
    Private x As Integer, y As Integer
    Private newpoint As Point
    Private _failedLoginAttempts As Integer = 0
    Private _lockoutUntil As DateTime = DateTime.MinValue
    Private _isBindingUsers As Boolean = False


    ' ──────────────────────────────────────────────────────────
    ' الدوال المساعدة (Helpers)
    ' ──────────────────────────────────────────────────────────

    Private Function GetMacAddress() As String
        Try
            Dim networkInterfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each netInterface As NetworkInterface In networkInterfaces
                If netInterface.OperationalStatus = OperationalStatus.Up AndAlso
                   netInterface.NetworkInterfaceType <> NetworkInterfaceType.Loopback Then
                    Dim bytes = netInterface.GetPhysicalAddress().GetAddressBytes()
                    If bytes IsNot Nothing AndAlso bytes.Length > 0 Then
                        Return BitConverter.ToString(bytes)
                    End If
                End If
            Next
        Catch ex As Exception
            Logger.LogError("GetMacAddress", ex)
            Return "لا يمكن الحصول على عنوان MAC"
        End Try

        Return "لم يتم العثور على بطاقة شبكة نشطة"
    End Function

    Private Function GetNextLoginCode() As Integer
        Dim query As String = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Login_Info_TBL"
        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlCommand(query, cn)
                    Dim resultObj As Object = cmd.ExecuteScalar()
                    If resultObj IsNot Nothing AndAlso Not Convert.IsDBNull(resultObj) Then
                        Return Convert.ToInt32(resultObj)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("GetNextLoginCode", ex)
        End Try
        Return 1
    End Function

    Private Function EncryptPassword(plainText As String) As String
        If String.IsNullOrEmpty(plainText) Then Return ""
        Try
            Dim plainBytes = Encoding.UTF8.GetBytes(plainText)
            Dim encryptedBytes = ProtectedData.Protect(plainBytes, Nothing, DataProtectionScope.CurrentUser)
            Return Convert.ToBase64String(encryptedBytes)
        Catch ex As Exception
            Logger.LogError("EncryptPassword", ex)
            Return ""
        End Try
    End Function

    Private Function DecryptPassword(cipherText As String) As String
        If String.IsNullOrEmpty(cipherText) Then Return ""
        Try
            Dim cipherBytes = Convert.FromBase64String(cipherText)
            Dim decryptedBytes = ProtectedData.Unprotect(cipherBytes, Nothing, DataProtectionScope.CurrentUser)
            Return Encoding.UTF8.GetString(decryptedBytes)
        Catch ex As Exception
            Logger.LogError("DecryptPassword", ex)
            Return ""
        End Try
    End Function

    Private Sub SaveLoginPreferences(username As String, password As String)
        Try
            SettingsManager.SaveSetting("LastLoggedInUser", username)
            If chkRememberMe IsNot Nothing AndAlso chkRememberMe.Checked Then
                SettingsManager.SaveSetting("RememberMe_Enabled", "true")
                SettingsManager.SaveSetting("RememberMe_User", username)
                SettingsManager.SaveSetting("RememberMe_Pass", EncryptPassword(password))
            Else
                SettingsManager.SaveSetting("RememberMe_Enabled", "false")
                SettingsManager.SaveSetting("RememberMe_Pass", "")
            End If
        Catch ex As Exception
            Logger.LogError("SaveLoginPreferences", ex)
        End Try
    End Sub

    Public Sub FillUsersComboBox(Optional showPromptOnError As Boolean = True)
        Dim query As String = "SELECT User_ID, User_username FROM Users_TBL WHERE (IsActive = 1 OR IsActive IS NULL) AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY User_username"
        _isBindingUsers = True
        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Using da As New SqlDataAdapter(query, cn)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        ' تحديد المستخدم المطلوب اختياره (آخر مستخدم سجل دخوله أولاً، ثم المحفوظ في تذكرني)
                        Dim targetUser As String = SettingsManager.GetSetting("LastLoggedInUser")
                        Dim isRemembered As Boolean = SettingsManager.GetBoolSetting("RememberMe_Enabled", False)
                        If String.IsNullOrWhiteSpace(targetUser) AndAlso isRemembered Then
                            targetUser = SettingsManager.GetSetting("RememberMe_User")
                        End If
                        If String.IsNullOrWhiteSpace(targetUser) Then
                            Try
                                Using cmdLast As New SqlCommand("SELECT TOP 1 Login_Username FROM Login_Info_TBL WHERE (Login_Note LIKE N'%ناجح%' OR Login_Note IS NULL) AND Login_Username IS NOT NULL AND Login_Username <> '' ORDER BY ID DESC", cn)
                                    Dim lastObj = cmdLast.ExecuteScalar()
                                    If lastObj IsNot Nothing AndAlso Not Convert.IsDBNull(lastObj) Then
                                        targetUser = lastObj.ToString().Trim()
                                    End If
                                End Using
                            Catch
                            End Try
                        End If

                        Dim targetId As Object = Nothing
                        If Not String.IsNullOrWhiteSpace(targetUser) Then
                            For Each row As DataRow In dt.Rows
                                If String.Equals(row("User_username").ToString().Trim(), targetUser.Trim(), StringComparison.OrdinalIgnoreCase) Then
                                    targetId = row("User_ID")
                                    Exit For
                                End If
                            Next
                        End If

                        cmbUsername.DataSource = dt
                        cmbUsername.DisplayMember = "User_username"
                        cmbUsername.ValueMember = "User_ID"

                        If targetId IsNot Nothing Then
                            cmbUsername.SelectedValue = targetId
                        Else
                            cmbUsername.SelectedIndex = 0
                        End If

                        ' استرجاع كلمة المرور المحفوظة إذا كانت خاصية تذكرني مفعلة
                        If isRemembered AndAlso targetId IsNot Nothing Then
                            If chkRememberMe IsNot Nothing Then chkRememberMe.Checked = True
                            Dim savedEncPass As String = SettingsManager.GetSetting("RememberMe_Pass")
                            If Not String.IsNullOrEmpty(savedEncPass) Then
                                Dim savedPass As String = DecryptPassword(savedEncPass)
                                If Not String.IsNullOrEmpty(savedPass) Then
                                    txtpassword.Text = savedPass
                                End If
                            End If
                        ElseIf chkRememberMe IsNot Nothing Then
                            chkRememberMe.Checked = False
                        End If
                    Else
                        cmbUsername.DataSource = Nothing
                        If chkRememberMe IsNot Nothing Then chkRememberMe.Checked = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("FillUsersComboBox", ex)
            If showPromptOnError Then
                PromptDatabaseError(ex, "تعذر الاتصال بقاعدة البيانات أو تحميل قائمة المستخدمين.")
            End If
        Finally
            _isBindingUsers = False
        End Try
    End Sub

    ''' <summary>
    ''' تنبيه المستخدم عند حدوث خطأ في قاعدة البيانات وسؤاله لفتح الإعدادات مباشرة
    ''' </summary>
    Public Sub PromptDatabaseError(ex As Exception, customMessage As String)
        Dim msg As String = customMessage & vbCrLf & vbCrLf &
                            "تفاصيل الخطأ:" & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf &
                            "هل ترغب في فتح إعدادات قاعدة البيانات الآن لضبط الاتصال؟"

        Dim choice = MessageBox.Show(msg, "خطأ في قاعدة البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If choice = DialogResult.Yes Then
            OpenDatabaseSettings()
        End If
    End Sub

    ''' <summary>
    ''' فتح نافذة إعدادات قاعدة البيانات مقفولة على قسم قاعدة البيانات فقط مع التحديث التلقائي
    ''' </summary>
    Public Sub OpenDatabaseSettings()
        Try
            Settings.OpenDatabaseSettings(Me, databaseOnly:=True)

            ' بعد إغلاق شاشة الإعدادات، نقوم بإعادة قراءة إعدادات الاتصال ومحاولة التحديث
            DBModule.LoadDbSettings()
            If DBModule.TestConnection() Then
                FillUsersComboBox(showPromptOnError:=False)
                If cmbUsername.Items.Count > 0 Then
                    Notify.Toast("تم الاتصال بقاعدة البيانات وتحديث قائمة المستخدمين بنجاح ✅", Notify.ToastType.Success)
                Else
                    Notify.Toast("تم الاتصال بنجاح، ولكن لم يتم العثور على مستخدمين مسجلين في الجدول.", Notify.ToastType.Info)
                End If
            End If
        Catch ex As Exception
            Logger.LogError("OpenDatabaseSettings", ex)
            MessageBox.Show("حدث خطأ أثناء فتح شاشة الإعدادات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogLoginInfo(loginCode As Integer,
                             deviceName As String,
                             macAddress As String,
                             currentDate As DateTime,
                             currentTime As String,
                             usernameValue As String,
                             passwordValue As String,
                             note As String)

        Dim insertSql As String =
            "INSERT INTO Login_Info_TBL " &
            "(Login_Code, Login_DeviceName, Login_MacAddress, Login_CurrentDate, Login_CurrentTime, Login_Username, Login_Password, Login_Note) " &
            "VALUES (@Login_Code, @Login_DeviceName, @Login_MacAddress, @Login_CurrentDate, @Login_CurrentTime, @Login_Username, @Login_Password, @Login_Note)"

        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlCommand(insertSql, cn)
                    cmd.Parameters.AddWithValue("@Login_Code", loginCode)
                    cmd.Parameters.AddWithValue("@Login_DeviceName", deviceName)
                    cmd.Parameters.AddWithValue("@Login_MacAddress", macAddress)
                    cmd.Parameters.AddWithValue("@Login_CurrentDate", currentDate)
                    cmd.Parameters.AddWithValue("@Login_CurrentTime", currentTime)
                    cmd.Parameters.AddWithValue("@Login_Username", usernameValue)
                    cmd.Parameters.AddWithValue("@Login_Password", passwordValue)
                    cmd.Parameters.AddWithValue("@Login_Note", note)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("LogLoginInfo", ex)
        End Try
    End Sub

    Private Function GetUserId(username As String) As Integer
        Dim query As String = "SELECT ISNULL(User_ID, 0) FROM Users_TBL WHERE User_username = @username"
        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        Return Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("GetUserId", ex)
        End Try
        Return 0
    End Function

    Public Sub DeleteOldBackups(backupFolder As String, Optional days As Integer = 30)
        Try
            Dim limitDate As DateTime = DateTime.Now.AddDays(-days)
            Dim query As String = "SELECT Backup_ID, Backup_File FROM Backup_Log WHERE Backup_Date < @LimitDate"

            Dim filesToDelete As New List(Of String)
            Dim idsToDelete As New List(Of Integer)

            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@LimitDate", limitDate)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            filesToDelete.Add(dr("Backup_File").ToString())
                            idsToDelete.Add(Convert.ToInt32(dr("Backup_ID")))
                        End While
                    End Using
                End Using

                ' حذف الملفات الفعلية من القرص
                For Each filePath In filesToDelete
                    Try
                        If File.Exists(filePath) Then File.Delete(filePath)
                    Catch
                    End Try
                Next

                ' حذف السجلات من جدول Backup_Log
                For Each id In idsToDelete
                    Using delCmd As New SqlCommand("DELETE FROM Backup_Log WHERE Backup_ID = @ID", cn)
                        delCmd.Parameters.AddWithValue("@ID", id)
                        delCmd.ExecuteNonQuery()
                    End Using
                Next
            End Using

        Catch ex As Exception
            Logger.LogError("DeleteOldBackups", ex)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' أحداث النافذة وعناصر التحكم (Form Events)
    ' ──────────────────────────────────────────────────────────

    Private Async Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ── تحميل قائمة المستخدمين وتحديد المستخدم الأخير وكلمة المرور فوراً قبل أي انتظار ──
        Try
            FillUsersComboBox(showPromptOnError:=False)
        Catch ex As Exception
            Logger.LogError("Login_Load.FillUsers", ex)
        End Try

        AddHandler LicenseBootstrapper.LicenseInvalidated, Sub(msg)
            Try
                If Me.IsDisposed Then Return
                Me.BeginInvoke(Sub()
                    Try
                        BackgroundActivationTimer.Stop()
                        Dim alertText = If(String.IsNullOrWhiteSpace(msg), "تم إلغاء تفعيل البرنامج من السيرفر.", msg)
                        MessageBox.Show(alertText, "تنبيه التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Dim actForm As New FormActivation()
                        actForm.Show()
                        For Each frm As Form In Application.OpenForms.Cast(Of Form)().ToList()
                            If frm IsNot actForm Then frm.Close()
                        Next
                    Catch
                    End Try
                End Sub)
            Catch
            End Try
        End Sub

        Dim license = Await LicenseBootstrapper.CheckAsync()
        If Not license.IsValid Then
            Using activation As New FormActivation()
                If activation.ShowDialog(Me) <> DialogResult.OK Then
                    Application.Exit()
                    Return
                End If
            End Using
        ElseIf license.IsOffline AndAlso Not String.IsNullOrWhiteSpace(license.Message) Then
            MessageBox.Show(license.Message, "وضع عدم الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' فحص التحديثات التلقائي في الخلفية عند بدء التشغيل
        If license.IsValid AndAlso license.Payload IsNot Nothing Then
            Dim autoUpd = SettingsManager.GetBoolSetting("AutoUpdate_Enabled", True)
            If autoUpd Then
                Dim updateTask = Task.Run(Async Function()
                                              Try
                                                  Await Task.Delay(2500)
                                                  Await UpdateCoordinator.CheckAndPromptAsync(license.Payload, Me)
                                              Catch ex As Exception
                                                  Debug.WriteLine("AutoUpdate check skipped: " & ex.Message)
                                              End Try
                                          End Function)
            End If
        End If

        ' التأكد من تعبئة القائمة في حال لم تكن محملة
        If cmbUsername.Items.Count = 0 Then
            Try
                FillUsersComboBox(showPromptOnError:=False)
            Catch ex As Exception
                Logger.LogError("Login_Load.FillUsersFallback", ex)
            End Try
        End If

        If pnlLockout IsNot Nothing Then pnlLockout.Visible = False

        ' ── تطبيق السمة الحالية وضبط كافة العناصر بدقة ──
        ThemeManager.Instance.ApplyTheme(Me)
        ApplyLoginCustomTheme(ThemeManager.Instance.CurrentPalette)

        AddHandler ThemeManager.Instance.ThemeChanged, Sub(s, theme, palette)
                                                           ApplyLoginCustomTheme(palette)
                                                       End Sub

        ' تفعيل سحب النافذة عبر اللوحة اليسرى واللوحة الرئيسية
        Dim drag0 As New FormDragHelper(Me, pn_0)

        ' ── تأثير Fade-in عند فتح النافذة ──
        Me.Opacity = 0.2
        Dim fadeTimer As New Timer() With {.Interval = 15}
        AddHandler fadeTimer.Tick, Sub(s, ev)
                                       If Me.Opacity < 1 Then
                                           Me.Opacity += 0.05
                                       Else
                                           Me.Opacity = 1
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                           FocusPasswordOrUser()
                                       End If
                                   End Sub
        fadeTimer.Start()

        ' ── تذكر آخر مستخدم سجل دخوله وتحديد التركيز ──
        SelectLastUserAndFocusPassword()

        ' ── النسخ الاحتياطي التلقائي وفق إعدادات النظام بدون حجب واجهة المستخدم ──
        Dim bgBackup = Task.Run(Sub()
                     Try
                         ' فحص تفعيل النسخ الاحتياطي التلقائي من الإعدادات
                         If Not SettingsManager.GetBoolSetting(SettingsKeys.SystemAutoBackup, True) Then
                             Exit Sub
                         End If

                         ' استخدام مسار النسخ المخصص أو الافتراضي مع معالجة صلاحيات UAC
                         Dim customPath = SettingsManager.GetSetting(SettingsKeys.SystemBackupPath)
                         Dim appBackupFolder As String = ""
                         If Not String.IsNullOrWhiteSpace(customPath) Then
                             appBackupFolder = customPath.Trim()
                         Else
                             Try
                                 Dim appBak = Path.Combine(Application.StartupPath, "Backups")
                                 If Not Directory.Exists(appBak) Then Directory.CreateDirectory(appBak)
                                 appBackupFolder = appBak
                             Catch
                                 Dim commonBak = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Sestamk", "Backups")
                                 If Not Directory.Exists(commonBak) Then Directory.CreateDirectory(commonBak)
                                 appBackupFolder = commonBak
                             End Try
                         End If

                         Try
                             If Not Directory.Exists(appBackupFolder) Then
                                 Directory.CreateDirectory(appBackupFolder)
                             End If
                         Catch
                             Dim docBak = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sestamk", "Backups")
                             If Not Directory.Exists(docBak) Then Directory.CreateDirectory(docBak)
                             appBackupFolder = docBak
                         End Try

                         CheckAndTakeScheduledBackup(appBackupFolder, "نسخة بدء التشغيل")
                         DeleteOldBackups(appBackupFolder)
                     Catch ex As Exception
                         Logger.LogError("BackgroundBackup", ex)
                     End Try
                 End Sub)

        ' ضبط مؤقت التفعيل لفترة منطقية (كل 5 دقائق بدل ثانية واحدة لتوفير المعالج)
        Try
            BackgroundActivationTimer.Interval = 300000
            BackgroundActivationTimer.Start()
        Catch
        End Try

        ' إعداد التلميحات لأزرار شريط الأدوات العلوي
        Try
            Dim tip As New ToolTip()
            tip.SetToolTip(btnDbSettings, "إعدادات قاعدة البيانات والسيرفر (F12 أو Ctrl+S)")
            tip.SetToolTip(btnThemeToggle, "تبديل المظهر (فاتح / داكن)")
            tip.SetToolTip(btnMinimize, "تصغير النافذة")
            tip.SetToolTip(btnclose, "إغلاق البرنامج")
            tip.SetToolTip(btnTogglePassword, "إظهار / إخفاء كلمة المرور")
        Catch
        End Try

        ' ضبط رقم الإصدار ديناميكياً
        Try
            Dim appVer As String = "v" & Application.ProductVersion
            lblVersionBadge.Text = "● النظام جاهز | " & appVer
            lblSideCopyright.Text = "سستمك © 2026 • الإصدار " & appVer
            Label4.Text = "جميع الحقوق محفوظة © سستمك 2026"
            btnTogglePassword.BringToFront()
        Catch
        End Try
    End Sub

    Private Sub Login_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SelectLastUserAndFocusPassword()
    End Sub

    Private Sub Login_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            If cmbUsername.SelectedIndex >= 0 AndAlso Not txtpassword.Focused Then
                Me.ActiveControl = txtpassword
                txtpassword.Focus()
            End If
        Catch
        End Try
    End Sub

    Private Sub cmbUsername_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsername.SelectedIndexChanged
        If _isBindingUsers Then Return
        Try
            Dim selectedUser As String = cmbUsername.Text.Trim()
            Dim remUser As String = SettingsManager.GetSetting("RememberMe_User")
            Dim isRem As Boolean = SettingsManager.GetBoolSetting("RememberMe_Enabled", False)

            If isRem AndAlso Not String.IsNullOrEmpty(remUser) AndAlso String.Equals(selectedUser, remUser.Trim(), StringComparison.OrdinalIgnoreCase) Then
                If chkRememberMe IsNot Nothing Then chkRememberMe.Checked = True
                Dim encPass As String = SettingsManager.GetSetting("RememberMe_Pass")
                txtpassword.Text = DecryptPassword(encPass)
            Else
                If chkRememberMe IsNot Nothing Then chkRememberMe.Checked = False
                txtpassword.Clear()
            End If
        Catch ex As Exception
            Logger.LogError("cmbUsername_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub SelectLastUserAndFocusPassword()
        Try
            If cmbUsername.Items.Count > 0 Then
                ' استرجاع اسم آخر مستخدم:
                ' 1. آخر مستخدم سجل دخوله في الإعدادات (LastLoggedInUser)
                ' 2. خيار تذكرني إذا كان مفعلاً
                ' 3. آخر عملية تسجيل دخول مسجلة في جدول Login_Info_TBL
                Dim targetUser As String = SettingsManager.GetSetting("LastLoggedInUser")
                Dim isRemembered As Boolean = SettingsManager.GetBoolSetting("RememberMe_Enabled", False)

                If String.IsNullOrWhiteSpace(targetUser) AndAlso isRemembered Then
                    targetUser = SettingsManager.GetSetting("RememberMe_User")
                End If

                If String.IsNullOrWhiteSpace(targetUser) Then
                    Try
                        Using cn As SqlConnection = DBModule.NewConn()
                            Using cmdLast As New SqlCommand("SELECT TOP 1 Login_Username FROM Login_Info_TBL WHERE (Login_Note LIKE N'%ناجح%' OR Login_Note IS NULL) AND Login_Username IS NOT NULL AND Login_Username <> '' ORDER BY ID DESC", cn)
                                Dim lastObj = cmdLast.ExecuteScalar()
                                If lastObj IsNot Nothing AndAlso Not Convert.IsDBNull(lastObj) Then
                                    targetUser = lastObj.ToString().Trim()
                                End If
                            End Using
                        End Using
                    Catch
                    End Try
                End If

                If Not String.IsNullOrWhiteSpace(targetUser) Then
                    Dim foundIndex As Integer = -1
                    For i As Integer = 0 To cmbUsername.Items.Count - 1
                        Dim drv = TryCast(cmbUsername.Items(i), DataRowView)
                        If drv IsNot Nothing AndAlso String.Equals(drv("User_username").ToString().Trim(), targetUser.Trim(), StringComparison.OrdinalIgnoreCase) Then
                            foundIndex = i
                            Exit For
                        ElseIf String.Equals(cmbUsername.GetItemText(cmbUsername.Items(i)).Trim(), targetUser.Trim(), StringComparison.OrdinalIgnoreCase) Then
                            foundIndex = i
                            Exit For
                        End If
                    Next

                    If foundIndex >= 0 Then
                        cmbUsername.SelectedIndex = foundIndex
                    End If
                End If

                ' تعبئة كلمة المرور إذا كانت ميزة تذكرني مفعلة لهذا المستخدم
                If isRemembered Then
                    Dim savedEncPass As String = SettingsManager.GetSetting("RememberMe_Pass")
                    If Not String.IsNullOrEmpty(savedEncPass) Then
                        Dim savedPass As String = DecryptPassword(savedEncPass)
                        If Not String.IsNullOrEmpty(savedPass) Then
                            txtpassword.Text = savedPass
                        End If
                    End If
                End If
            End If

            FocusPasswordOrUser()
        Catch ex As Exception
            Logger.LogError("SelectLastUserAndFocusPassword", ex)
        End Try
    End Sub

    Private Sub FocusPasswordOrUser()
        Me.BeginInvoke(Sub()
                           Try
                               If cmbUsername.SelectedIndex >= 0 Then
                                   Me.ActiveControl = txtpassword
                                   txtpassword.Focus()
                                   txtpassword.SelectAll()
                               Else
                                   Me.ActiveControl = cmbUsername
                                   cmbUsername.Focus()
                               End If
                           Catch
                           End Try
                       End Sub)
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnTogglePassword_Click(sender As Object, e As EventArgs) Handles btnTogglePassword.Click
        txtpassword.UseSystemPasswordChar = Not txtpassword.UseSystemPasswordChar
        If txtpassword.UseSystemPasswordChar Then
            btnTogglePassword.Image = WindowsApp1.My.Resources.Resources.view
        Else
            btnTogglePassword.Image = WindowsApp1.My.Resources.Resources.hide__1_
        End If
    End Sub

    Private Sub btnThemeToggle_Click(sender As Object, e As EventArgs) Handles btnThemeToggle.Click
        ThemeManager.Instance.ToggleTheme()
    End Sub

    Private Sub btnDbSettings_Click(sender As Object, e As EventArgs) Handles btnDbSettings.Click
        OpenDatabaseSettings()
    End Sub

    Private Sub Login_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' اختصارات فتح إعدادات قاعدة البيانات: F12 أو Ctrl+S أو Ctrl+Shift+D
        If e.KeyCode = Keys.F12 OrElse
           (e.Control AndAlso e.KeyCode = Keys.S) OrElse
           (e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.D) Then
            e.SuppressKeyPress = True
            e.Handled = True
            OpenDatabaseSettings()
        End If
    End Sub

    ''' <summary>
    ''' تطبيق التنسيقات والألوان الخاصة بفورم تسجيل الدخول لضمان أعلى درجات التناسق والوضوح
    ''' </summary>
    Private Sub ApplyLoginCustomTheme(palette As ThemePalette)
        If palette Is Nothing Then Return

        ' 1. تحديث نصوص وألوان اللوحة الترحيبية
        UpdateSidePanelTheme(palette)

        ' 2. ضبط زر تبديل الثيم وزر إعدادات قاعدة البيانات
        UpdateThemeToggleButton()
        UpdateDbSettingsButton()

        ' 3. ضمان شفافية اللوحة الترحيبية لرسم التدرج المخصص بسلاسة
        pn_0.FillColor = Color.Transparent
        pn_0.Invalidate()

        ' 4. ضبط الخط الفاصل ليكون مرئياً وواضحاً في السمتين
        Guna2Panel1.FillColor = palette.Divider

        ' 5. زر الإغلاق والتصغير وعين كلمة المرور
        btnclose.FillColor = Color.Transparent
        btnclose.ForeColor = palette.TextMuted
        btnclose.HoverState.FillColor = palette.Danger
        btnclose.HoverState.ForeColor = Color.White

        If btnMinimize IsNot Nothing Then
            btnMinimize.FillColor = Color.Transparent
            btnMinimize.ForeColor = palette.TextMuted
            btnMinimize.HoverState.FillColor = palette.SurfaceSecondary
            btnMinimize.HoverState.ForeColor = palette.TextPrimary
        End If

        If btnTogglePassword IsNot Nothing Then
            btnTogglePassword.FillColor = Color.Transparent
            btnTogglePassword.ForeColor = palette.TextMuted
            btnTogglePassword.HoverState.FillColor = palette.SurfaceSecondary
        End If

        ' 6. زر الدعم الفني: زر ثانوي أنيق مع هوية بصرية واضحة
        btnsup.ForeColor = palette.InfoSubtleForeground
        btnsup.BorderColor = palette.Border
        btnsup.HoverState.BorderColor = palette.Info
        btnsup.HoverState.FillColor = palette.InfoSubtleBackground

        ' 7. التسلسل الهرمي للنصوص التوضيحية
        Label2.ForeColor = palette.TextSecondary
        Label1.ForeColor = palette.TextSecondary
        Label4.ForeColor = palette.TextMuted
        lblusername.ForeColor = palette.TextPrimary
        lblpassword.ForeColor = palette.TextPrimary

        ' 8. مربع اختيار تذكرني
        If chkRememberMe IsNot Nothing Then
            If ThemeManager.Instance.IsDark Then
                chkRememberMe.ForeColor = palette.TextSecondary
                chkRememberMe.CheckedState.FillColor = palette.Primary
                chkRememberMe.CheckedState.BorderColor = palette.Primary
                chkRememberMe.UncheckedState.FillColor = palette.InputBackground
                chkRememberMe.UncheckedState.BorderColor = palette.InputBorder
            Else
                chkRememberMe.ForeColor = Color.FromArgb(100, 116, 139)
                chkRememberMe.CheckedState.FillColor = palette.Primary
                chkRememberMe.CheckedState.BorderColor = palette.Primary
                chkRememberMe.UncheckedState.FillColor = Color.White
                chkRememberMe.UncheckedState.BorderColor = Color.FromArgb(200, 205, 215)
            End If
        End If

        ' 9. لوحة الحظر المؤقت والعداد التنازلي
        If pnlLockout IsNot Nothing AndAlso lblLockoutTimer IsNot Nothing Then
            If ThemeManager.Instance.IsDark Then
                pnlLockout.FillColor = Color.FromArgb(45, 20, 25)
                pnlLockout.BorderColor = Color.FromArgb(239, 68, 68)
                lblLockoutTimer.ForeColor = Color.FromArgb(254, 202, 202)
            Else
                pnlLockout.FillColor = Color.FromArgb(254, 242, 242)
                pnlLockout.BorderColor = Color.FromArgb(248, 113, 113)
                lblLockoutTimer.ForeColor = Color.FromArgb(185, 28, 28)
            End If
        End If
    End Sub

    Private Sub UpdateSidePanelTheme(palette As ThemePalette)
        If lblWelcome Is Nothing Then Return

        If ThemeManager.Instance.IsDark Then
            lblWelcome.ForeColor = Color.White
            lblBrand.ForeColor = Color.FromArgb(203, 213, 225)
            lblDesc.ForeColor = Color.FromArgb(148, 163, 184)
            lblSideCopyright.ForeColor = Color.FromArgb(100, 116, 139)

            If lblVersionBadge IsNot Nothing Then
                lblVersionBadge.FillColor = Color.FromArgb(40, 59, 130, 246)
                lblVersionBadge.BorderColor = Color.FromArgb(59, 130, 246)
                lblVersionBadge.ForeColor = Color.FromArgb(147, 197, 253)
            End If

            Dim cardFill = Color.FromArgb(20, 255, 255, 255)
            Dim cardBorder = Color.FromArgb(35, 255, 255, 255)
            Dim descColor = Color.FromArgb(148, 163, 184)

            If pnlFeature1 IsNot Nothing Then
                pnlFeature1.FillColor = cardFill
                pnlFeature1.BorderColor = cardBorder
                lblFeatureTitle1.ForeColor = Color.White
                lblFeatureDesc1.ForeColor = descColor

                pnlFeature2.FillColor = cardFill
                pnlFeature2.BorderColor = cardBorder
                lblFeatureTitle2.ForeColor = Color.White
                lblFeatureDesc2.ForeColor = descColor

                pnlFeature3.FillColor = cardFill
                pnlFeature3.BorderColor = cardBorder
                lblFeatureTitle3.ForeColor = Color.White
                lblFeatureDesc3.ForeColor = descColor
            End If
        Else
            lblWelcome.ForeColor = Color.White
            lblBrand.ForeColor = Color.FromArgb(224, 236, 248)
            lblDesc.ForeColor = Color.FromArgb(190, 215, 240)
            lblSideCopyright.ForeColor = Color.FromArgb(160, 195, 230)

            If lblVersionBadge IsNot Nothing Then
                lblVersionBadge.FillColor = Color.FromArgb(40, 255, 255, 255)
                lblVersionBadge.BorderColor = Color.FromArgb(120, 255, 255, 255)
                lblVersionBadge.ForeColor = Color.White
            End If

            Dim cardFill = Color.FromArgb(30, 255, 255, 255)
            Dim cardBorder = Color.FromArgb(60, 255, 255, 255)
            Dim descColor = Color.FromArgb(200, 225, 250)

            If pnlFeature1 IsNot Nothing Then
                pnlFeature1.FillColor = cardFill
                pnlFeature1.BorderColor = cardBorder
                lblFeatureTitle1.ForeColor = Color.White
                lblFeatureDesc1.ForeColor = descColor

                pnlFeature2.FillColor = cardFill
                pnlFeature2.BorderColor = cardBorder
                lblFeatureTitle2.ForeColor = Color.White
                lblFeatureDesc2.ForeColor = descColor

                pnlFeature3.FillColor = cardFill
                pnlFeature3.BorderColor = cardBorder
                lblFeatureTitle3.ForeColor = Color.White
                lblFeatureDesc3.ForeColor = descColor
            End If
        End If
    End Sub

    Private Sub UpdateThemeToggleButton()
        If ThemeManager.Instance.IsDark Then
            btnThemeToggle.Text = "☀️"
            btnThemeToggle.ForeColor = Color.FromArgb(250, 204, 21)
            btnThemeToggle.FillColor = Color.FromArgb(30, 41, 59)
            btnThemeToggle.BorderColor = Color.FromArgb(51, 65, 85)
            btnThemeToggle.BorderThickness = 1
            btnThemeToggle.HoverState.FillColor = Color.FromArgb(51, 65, 85)
        Else
            btnThemeToggle.Text = "🌙"
            btnThemeToggle.ForeColor = Color.FromArgb(71, 85, 105)
            btnThemeToggle.FillColor = Color.FromArgb(241, 245, 249)
            btnThemeToggle.BorderColor = Color.FromArgb(226, 232, 240)
            btnThemeToggle.BorderThickness = 1
            btnThemeToggle.HoverState.FillColor = Color.FromArgb(226, 232, 240)
        End If
    End Sub

    Private Sub UpdateDbSettingsButton()
        If btnDbSettings Is Nothing Then Return
        If ThemeManager.Instance.IsDark Then
            'btnDbSettings.Text = "⚙️"
            btnDbSettings.ForeColor = Color.FromArgb(148, 163, 184)
            btnDbSettings.FillColor = Color.FromArgb(30, 41, 59)
            btnDbSettings.BorderColor = Color.FromArgb(51, 65, 85)
            btnDbSettings.BorderThickness = 1
            btnDbSettings.HoverState.FillColor = Color.FromArgb(51, 65, 85)
            btnDbSettings.HoverState.ForeColor = Color.White
        Else
            'btnDbSettings.Text = "⚙️"
            btnDbSettings.ForeColor = Color.FromArgb(71, 85, 105)
            btnDbSettings.FillColor = Color.FromArgb(241, 245, 249)
            btnDbSettings.BorderColor = Color.FromArgb(226, 232, 240)
            btnDbSettings.BorderThickness = 1
            btnDbSettings.HoverState.FillColor = Color.FromArgb(226, 232, 240)
            btnDbSettings.HoverState.ForeColor = Color.FromArgb(30, 41, 59)
        End If
    End Sub

    ''' <summary>
    ''' رسم التدرج اللوني والخط الفاصل الأنيق على اللوحة الجانبية
    ''' </summary>
    Private Sub pn_0_Paint(sender As Object, e As PaintEventArgs) Handles pn_0.Paint
        Dim panel = DirectCast(sender, Control)
        Dim topColor As Color
        Dim bottomColor As Color

        If ThemeManager.Instance.IsDark Then
            topColor = Color.FromArgb(15, 23, 42)
            bottomColor = Color.FromArgb(30, 41, 59)
        Else
            topColor = Color.FromArgb(12, 40, 100)
            bottomColor = Color.FromArgb(35, 100, 190)
        End If

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Using brush As New LinearGradientBrush(
            panel.ClientRectangle,
            topColor,
            bottomColor,
            LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, panel.ClientRectangle)
        End Using
    End Sub


    Private Sub Login_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, pn_main.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Login_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, pn_main.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Try
            Application.Exit()
        Catch
            End
        End Try
    End Sub

    Private Sub cmbUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtpassword.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtpassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnlogin.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    'Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs)
    '    txtpassword.UseSystemPasswordChar = Not CheckBox1.Checked
    'End Sub

    Private Sub btnsup_Click(sender As Object, e As EventArgs) Handles btnsup.Click
        WebLinks.OpenContact()
    End Sub

    Private Sub BackgroundActivationTimer_Tick(sender As Object, e As EventArgs) Handles BackgroundActivationTimer.Tick
        Task.Run(Sub()
                     Try
                         Dim ok = CheckActivation.CheckActivationBackground()
                         If Not ok Then
                             Me.Invoke(Sub()
                                           BackgroundActivationTimer.Stop()
                                           MessageBox.Show("تم إلغاء تفعيل البرنامج من السيرفر.", "تنبيه التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                           Dim actForm As New FormActivation()
                                           actForm.Show()
                                           For Each frm As Form In Application.OpenForms.Cast(Of Form)().ToList()
                                               If frm IsNot actForm Then frm.Close()
                                           Next
                                       End Sub)
                         End If
                     Catch ex As Exception
                         Logger.LogError("ActivationBackgroundCheck", ex)
                     End Try
                 End Sub)
    End Sub

    ' ──────────────────────────────────────────────────────────
    ' عملية تسجيل الدخول (Async Login)
    ' ──────────────────────────────────────────────────────────

    Public Async Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        ' ── فحص القفل المؤقت لتجاوز المحاولات الخاطئة ──
        If DateTime.Now < _lockoutUntil Then
            StartLockoutCountdown()
            Return
        End If

        ' ── 1. التحقق من صحة المدخلات ──
        Dim enteredUser As String = cmbUsername.Text.Trim()
        Dim enteredPass As String = txtpassword.Text.Trim()

        If cmbUsername.SelectedIndex = -1 AndAlso String.IsNullOrWhiteSpace(enteredUser) Then
            MessageBox.Show("يرجى اختيار اسم المستخدم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(enteredPass) Then
            MessageBox.Show("يرجى إدخال كلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtpassword.Focus()
            Return
        End If

        ' ── 2. حالة التحميل (Busy State لمنع النقر المزدوج وتجميد الشاشة) ──
        btnlogin.Enabled = False
        Dim originalButtonText As String = btnlogin.Text
        btnlogin.Text = "جاري التحقق..."
        Me.Cursor = Cursors.WaitCursor

        Dim deviceName As String = Environment.MachineName
        Dim macAddress As String = GetMacAddress()
        Dim currentDate As DateTime = DateTime.Today
        Dim currentTime As String = DateTime.Now.ToString("hh:mm:ss tt")

        Try
            ' ── 3. فحص حساب المدير (Admin Credentials) ──
            If Not String.IsNullOrEmpty(usernameadmin) AndAlso enteredUser = usernameadmin AndAlso enteredPass = passwordadmin Then
                ' تهيئة جلسة المدير بالكامل
                Dim adminId As Integer = GetUserId(enteredUser)
                Session.CurrentUserID = If(adminId > 0, adminId, 1)
                Session.CurrentUserfullName = "المدير العام"
                Session.CurrentUserName = enteredUser
                Session.CurrentUserPassword = enteredPass
                Session.CurrentRoleID = 1
                Session.LoadPermissions(1)
                InitializeShiftSession()

                usernamelogin = enteredUser
                passwordlogin = enteredPass
                useridlogin = Session.CurrentUserID

                ' حفظ إعدادات تسجيل الدخول وتذكرني
                SaveLoginPreferences(enteredUser, enteredPass)

                ' تسجيل حركة الدخول
                Dim code As Integer = GetNextLoginCode()
                LogLoginInfo(code, deviceName, macAddress, currentDate, currentTime, enteredUser, enteredPass, "دخول مدير النظام")

                _failedLoginAttempts = 0
                _lockoutUntil = DateTime.MinValue
                If tmrLockoutCountdown IsNot Nothing Then tmrLockoutCountdown.Stop()
                If pnlLockout IsNot Nothing Then pnlLockout.Visible = False
                Notify.Toast("تم تسجيل دخول المدير بنجاح ✅", Notify.ToastType.Success)

                Me.Hide()
                Dim mainForm As New MainForm()
                mainForm.Show()

                If Not (chkRememberMe IsNot Nothing AndAlso chkRememberMe.Checked) Then
                    txtpassword.Clear()
                End If
                Return
            End If

            ' ── 4. فحص المستخدم من قاعدة البيانات (Async Query) ──
            Dim query As String = "
                SELECT User_ID, RoleID, User_username, IsActive, User_Name, IsDeleted
                FROM Users_TBL 
                WHERE User_username = @username AND User_password = @password"

            Using cn As SqlConnection = Await DBModule.NewConnAsync()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.AddWithValue("@username", enteredUser)
                    cmd.Parameters.AddWithValue("@password", enteredPass)

                    Using reader As SqlDataReader = Await cmd.ExecuteReaderAsync()
                        If Await reader.ReadAsync() Then
                            ' فحص حالة التفعيل
                            Dim userStats As Boolean = True
                            If Not IsDBNull(reader("IsActive")) Then
                                userStats = Convert.ToBoolean(reader("IsActive"))
                            End If

                            If Not userStats Then
                                MessageBox.Show("⚠️ هذا المستخدم غير مفعل، يرجى مراجعة إدارة النظام.", "مستخدم غير نشط", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                txtpassword.Clear()
                                txtpassword.Focus()
                                Return
                            End If

                            ' قراءة البيانات
                            Dim userId As Integer = Convert.ToInt32(reader("User_ID"))
                            Dim roleId As Integer = 0
                            If Not IsDBNull(reader("RoleID")) Then
                                Integer.TryParse(reader("RoleID").ToString(), roleId)
                            End If

                            Dim fullName As String = If(Not IsDBNull(reader("User_Name")), reader("User_Name").ToString(), enteredUser)

                            ' تهيئة الجلسة بالكامل
                            Session.CurrentUserID = userId
                            Session.CurrentUserfullName = fullName
                            Session.CurrentUserName = enteredUser
                            Session.CurrentUserPassword = enteredPass
                            Session.CurrentRoleID = roleId
                            Session.LoadPermissions(roleId)
                            InitializeShiftSession()

                            usernamelogin = enteredUser
                            passwordlogin = enteredPass
                            useridlogin = userId

                            ' حفظ إعدادات تسجيل الدخول وتذكرني
                            SaveLoginPreferences(enteredUser, enteredPass)

                            ' تسجيل حركة الدخول
                            Dim code As Integer = GetNextLoginCode()
                            LogLoginInfo(code, deviceName, macAddress, currentDate, currentTime, enteredUser, enteredPass, "دخول ناجح")

                            _failedLoginAttempts = 0
                            _lockoutUntil = DateTime.MinValue
                            If tmrLockoutCountdown IsNot Nothing Then tmrLockoutCountdown.Stop()
                            If pnlLockout IsNot Nothing Then pnlLockout.Visible = False
                            Notify.Toast("تم تسجيل الدخول بنجاح ✅", Notify.ToastType.Success)

                            Me.Hide()
                            Dim mainForm As New MainForm()
                            mainForm.Show()

                            If Not (chkRememberMe IsNot Nothing AndAlso chkRememberMe.Checked) Then
                                txtpassword.Clear()
                            End If
                            Return
                        Else
                            _failedLoginAttempts += 1
                            Dim maxAttempts As Integer = SettingsManager.GetIntSetting(SettingsKeys.LoginMaxAttempts, 5)
                            If maxAttempts <= 0 Then maxAttempts = 5

                            If _failedLoginAttempts >= maxAttempts Then
                                _lockoutUntil = DateTime.Now.AddSeconds(60)
                                _failedLoginAttempts = 0
                                StartLockoutCountdown()
                            Else
                                Dim leftAttempts = maxAttempts - _failedLoginAttempts
                                MessageBox.Show($"❌ اسم المستخدم أو كلمة المرور غير صحيحة.{vbCrLf}(المحاولات المتبقية قبل إيقاف الدخول: {leftAttempts})", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                            txtpassword.Clear()
                            txtpassword.Focus()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Logger.LogError("btnlogin_Click", ex)
            Dim isDbError As Boolean = (TypeOf ex Is SqlException) OrElse
                                       ex.Message.IndexOf("SQL", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                       ex.Message.IndexOf("table", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                       ex.Message.IndexOf("database", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                       ex.Message.IndexOf("login failed", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                       ex.Message.IndexOf("network-related", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                       ex.Message.IndexOf("connection", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                       ex.Message.IndexOf("Users_TBL", StringComparison.OrdinalIgnoreCase) >= 0

            If isDbError Then
                PromptDatabaseError(ex, "تعذر إتمام عملية تسجيل الدخول بسبب مشكلة في الاتصال بقاعدة البيانات أو الخادم.")
            Else
                MessageBox.Show("حدث خطأ أثناء الاتصال بالخادم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If DateTime.Now < _lockoutUntil Then
                btnlogin.Enabled = False
                btnlogin.Text = "محظور مؤقتاً"
            Else
                btnlogin.Enabled = True
                btnlogin.Text = originalButtonText
            End If
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' بدء العداد التنازلي للحظر المؤقت عند تجاوز الحد الأقصى للمحاولات الخاطئة
    ''' </summary>
    Private Sub StartLockoutCountdown()
        Dim remaining = _lockoutUntil - DateTime.Now
        Dim totalSecs As Integer = Math.Max(1, CInt(remaining.TotalSeconds))
        Dim mins As Integer = totalSecs \ 60
        Dim secs As Integer = totalSecs Mod 60

        lblLockoutTimer.Text = $"⏳ تم إيقاف الدخول مؤقتاً | يرجى الانتظار: {mins:D2}:{secs:D2}"
        pnlLockout.Visible = True
        btnlogin.Enabled = False
        btnlogin.Text = "محظور مؤقتاً"
        txtpassword.Enabled = False
        cmbUsername.Enabled = False
        tmrLockoutCountdown.Interval = 1000
        tmrLockoutCountdown.Start()
    End Sub

    Private Sub tmrLockoutCountdown_Tick(sender As Object, e As EventArgs) Handles tmrLockoutCountdown.Tick
        Dim remaining = _lockoutUntil - DateTime.Now
        Dim totalSecs As Integer = CInt(remaining.TotalSeconds)

        If totalSecs <= 0 Then
            tmrLockoutCountdown.Stop()
            _lockoutUntil = DateTime.MinValue
            _failedLoginAttempts = 0
            pnlLockout.Visible = False
            btnlogin.Enabled = True
            btnlogin.Text = "تسجيل الدخول"
            txtpassword.Enabled = True
            cmbUsername.Enabled = True
            txtpassword.Clear()
            txtpassword.Focus()

            Try
                Notify.Toast("انتهت فترة الحظر المؤقت، يمكنك محاولة تسجيل الدخول الآن 🔓", Notify.ToastType.Success)
            Catch
            End Try
        Else
            Dim mins As Integer = totalSecs \ 60
            Dim secs As Integer = totalSecs Mod 60
            lblLockoutTimer.Text = $"⏳ تم إيقاف الدخول مؤقتاً | يرجى الانتظار: {mins:D2}:{secs:D2}"
        End If
    End Sub

    ''' <summary>
    ''' استقبال بيانات الاسكانر لتسجيل الدخول السريع عبر كارت الكاشير
    ''' </summary>
    Public Sub FillFromScanner(code As String)
        Try
            If String.IsNullOrWhiteSpace(code) Then Return
            code = code.Trim()

            If code.Contains(":") Then
                Dim parts = code.Split(":"c)
                cmbUsername.Text = parts(0).Trim()
                If parts.Length > 1 Then txtpassword.Text = parts(1).Trim()
                btnlogin.PerformClick()
            Else
                cmbUsername.Text = code
                txtpassword.Focus()
            End If
        Catch ex As Exception
            Logger.LogError("FillFromScanner", ex)
        End Try
    End Sub

    ''' <summary>
    ''' إعادة تهيئة شاشة تسجيل الدخول عند تسجيل الخروج من الشاشة الرئيسية
    ''' </summary>
    Public Sub ResetForLogout()
        Try
            Dim isRem As Boolean = SettingsManager.GetBoolSetting("RememberMe_Enabled", False)
            If isRem Then
                If chkRememberMe IsNot Nothing Then chkRememberMe.Checked = True
                Dim savedEncPass As String = SettingsManager.GetSetting("RememberMe_Pass")
                If Not String.IsNullOrEmpty(savedEncPass) Then
                    txtpassword.Text = DecryptPassword(savedEncPass)
                Else
                    txtpassword.Clear()
                End If
            Else
                txtpassword.Clear()
                If chkRememberMe IsNot Nothing Then chkRememberMe.Checked = False
            End If

            If DateTime.Now < _lockoutUntil Then
                StartLockoutCountdown()
            Else
                If tmrLockoutCountdown IsNot Nothing Then tmrLockoutCountdown.Stop()
                If pnlLockout IsNot Nothing Then pnlLockout.Visible = False
                btnlogin.Enabled = True
                btnlogin.Text = "تسجيل الدخول"
                txtpassword.Enabled = True
                cmbUsername.Enabled = True
            End If
            Me.Cursor = Cursors.Default
            Me.Opacity = 1
            Me.Visible = True
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            Me.BringToFront()
            Me.Activate()

            ' التركيز الذكي على خانة الباسورد إذا كان المستخدم محدداً، أو على اسم المستخدم
            If cmbUsername.Items.Count > 0 Then
                SelectLastUserAndFocusPassword()
            Else
                FillUsersComboBox(showPromptOnError:=False)
                SelectLastUserAndFocusPassword()
            End If
        Catch ex As Exception
            Logger.LogError("ResetForLogout", ex)
        End Try
    End Sub

End Class
