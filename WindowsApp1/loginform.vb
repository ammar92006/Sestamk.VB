Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Net.NetworkInformation
Imports System.Windows.Forms
Imports System.Threading.Tasks

Public Class Login
    Private x As Integer, y As Integer
    Private newpoint As Point

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

    Private Sub FillUsersComboBox()
        Dim query As String = "SELECT User_ID, User_username FROM Users_TBL WHERE (IsActive = 1 OR IsActive IS NULL) AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY User_username"
        Try
            Using cn As SqlConnection = DBModule.NewConn()
                Using da As New SqlDataAdapter(query, cn)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        cmbUsername.DataSource = dt
                        cmbUsername.DisplayMember = "User_username"
                        cmbUsername.ValueMember = "User_ID"
                        cmbUsername.SelectedIndex = -1
                    End If
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("FillUsersComboBox", ex)
            MessageBox.Show("حدث خطأ أثناء تحميل قائمة المستخدمين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FillUsersComboBox()
        Catch ex As Exception
            Logger.LogError("Login_Load.FillUsers", ex)
        End Try

        ' ── تطبيق السمة الحالية وضبط زر التبديل ──
        ThemeManager.Instance.ApplyTheme(Me)
        UpdateThemeToggleButton()

        AddHandler ThemeManager.Instance.ThemeChanged, Sub(s, theme, palette)
                                                           UpdateThemeToggleButton()
                                                           pn_0.Invalidate()
                                                       End Sub

        ' تفعيل سحب النافذة عبر اللوحة اليسرى واللوحة الرئيسية
        Dim drag0 As New FormDragHelper(Me, pn_0)

        ' ── تحسين اللوحة الجانبية: إضافة نصوص ترحيبية ──
        SetupSidePanelLabels()

        ' ── تأثير Fade-in عند فتح النافذة ──
        Me.Opacity = 0
        Dim fadeTimer As New Timer() With {.Interval = 15}
        AddHandler fadeTimer.Tick, Sub(s, ev)
                                       If Me.Opacity < 1 Then
                                           Me.Opacity += 0.05
                                       Else
                                           Me.Opacity = 1
                                           fadeTimer.Stop()
                                           fadeTimer.Dispose()
                                       End If
                                   End Sub
        fadeTimer.Start()

        ' ── تذكر آخر مستخدم سجل دخوله ──
        Try
            Dim lastUser As String = SettingsManager.GetSetting("LastLoggedInUser")
            If Not String.IsNullOrEmpty(lastUser) Then
                cmbUsername.Text = lastUser
                txtpassword.Focus()
            Else
                cmbUsername.Focus()
            End If
        Catch
            cmbUsername.Focus()
        End Try

        ' ── النسخ الاحتياطي التلقائي في مجلد البرنامج (Backups) بدون حجب واجهة المستخدم ──
        Task.Run(Sub()
                     Try
                         Dim appBackupFolder As String = Path.Combine(Application.StartupPath, "Backups")
                         If Not Directory.Exists(appBackupFolder) Then
                             Directory.CreateDirectory(appBackupFolder)
                         End If

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
    End Sub

    Private Sub btnThemeToggle_Click(sender As Object, e As EventArgs) Handles btnThemeToggle.Click
        ThemeManager.Instance.ToggleTheme()
    End Sub

    Private Sub UpdateThemeToggleButton()
        If ThemeManager.Instance.CurrentTheme = AppTheme.Dark Then
            btnThemeToggle.Text = "☀️"
            btnThemeToggle.ForeColor = Color.FromArgb(250, 204, 21)
            btnThemeToggle.HoverState.FillColor = Color.FromArgb(40, 50, 70)
        Else
            btnThemeToggle.Text = "🌙"
            btnThemeToggle.ForeColor = Color.FromArgb(71, 85, 105)
            btnThemeToggle.HoverState.FillColor = Color.FromArgb(226, 232, 240)
        End If
    End Sub

    ''' <summary>
    ''' رسم التدرج اللوني على اللوحة الجانبية
    ''' </summary>
    Private Sub pn_0_Paint(sender As Object, e As PaintEventArgs) Handles pn_0.Paint
        Dim panel = DirectCast(sender, Control)
        Dim topColor As Color
        Dim bottomColor As Color

        If ThemeManager.Instance.CurrentTheme = AppTheme.Dark Then
            topColor = Color.FromArgb(15, 23, 42)
            bottomColor = Color.FromArgb(30, 41, 59)
        Else
            topColor = Color.FromArgb(12, 40, 100)
            bottomColor = Color.FromArgb(35, 100, 190)
        End If

        Using brush As New LinearGradientBrush(
            panel.ClientRectangle,
            topColor,
            bottomColor,
            LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, panel.ClientRectangle)
        End Using
    End Sub

    ''' <summary>
    ''' إعداد نصوص ترحيبية على اللوحة الجانبية
    ''' </summary>
    Private Sub SetupSidePanelLabels()
        ' العنوان الرئيسي
        Dim lblWelcome As New Label() With {
            .Text = "مرحباً بك",
            .Font = New Font("Segoe UI", 28, FontStyle.Bold),
            .ForeColor = Color.White,
            .BackColor = Color.Transparent,
            .AutoSize = False,
            .Size = New Size(400, 55),
            .Location = New Point(80, 250),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        pn_0.Controls.Add(lblWelcome)

        ' العنوان الفرعي
        Dim lblBrand As New Label() With {
            .Text = "في نظام سستامك",
            .Font = New Font("Segoe UI", 22, FontStyle.Regular),
            .ForeColor = Color.FromArgb(200, 210, 230),
            .BackColor = Color.Transparent,
            .AutoSize = False,
            .Size = New Size(400, 45),
            .Location = New Point(80, 310),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        pn_0.Controls.Add(lblBrand)

        ' الوصف
        Dim lblDesc As New Label() With {
            .Text = "نظام متكامل لإدارة نقاط البيع والمطاعم" & vbCrLf &
                    "بأحدث التقنيات وأسهل الطرق",
            .Font = New Font("Segoe UI", 12, FontStyle.Regular),
            .ForeColor = Color.FromArgb(160, 180, 210),
            .BackColor = Color.Transparent,
            .AutoSize = False,
            .Size = New Size(400, 60),
            .Location = New Point(80, 390),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        pn_0.Controls.Add(lblDesc)

        ' خط فاصل مزخرف
        Dim lblLine As New Label() With {
            .Text = "━━━━━━━━━━━━━━━━━━━━━",
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .ForeColor = Color.FromArgb(80, 120, 180),
            .BackColor = Color.Transparent,
            .AutoSize = False,
            .Size = New Size(400, 20),
            .Location = New Point(80, 470),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        pn_0.Controls.Add(lblLine)

        ' حقوق النشر في اللوحة الجانبية
        Dim lblSideCopyright As New Label() With {
            .Text = "Sestamk © 2026",
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .ForeColor = Color.FromArgb(100, 140, 190),
            .BackColor = Color.Transparent,
            .AutoSize = False,
            .Size = New Size(400, 25),
            .Location = New Point(80, 740),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        pn_0.Controls.Add(lblSideCopyright)
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

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        txtpassword.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub

    Private Sub btnsup_Click(sender As Object, e As EventArgs) Handles btnsup.Click
        Dim phone As String = SettingsManager.GetSetting(SettingsKeys.ShopPhone)
        Dim msg As String =
            "نظام سستامك لإدارة نقاط البيع والمطاعم" & vbCrLf &
            "لطلب الدعم الفني والمساعدة:" & vbCrLf &
            If(Not String.IsNullOrWhiteSpace(phone), "الهاتف: " & phone & vbCrLf, "") &
            "الإصدار: 2026"
        MessageBox.Show(msg, "الدعم الفني", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                ' حفظ آخر مستخدم
                Try
                    SettingsManager.SaveSetting("LastLoggedInUser", enteredUser)
                Catch
                End Try

                ' تسجيل حركة الدخول
                Dim code As Integer = GetNextLoginCode()
                LogLoginInfo(code, deviceName, macAddress, currentDate, currentTime, enteredUser, enteredPass, "دخول مدير النظام")

                Notify.Toast("تم تسجيل دخول المدير بنجاح ✅", Notify.ToastType.Success)

                Me.Hide()
                Dim mainForm As New MainForm()
                mainForm.Show()

                txtpassword.Clear()
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

                            ' حفظ آخر مستخدم
                            Try
                                SettingsManager.SaveSetting("LastLoggedInUser", enteredUser)
                            Catch
                            End Try

                            ' تسجيل حركة الدخول
                            Dim code As Integer = GetNextLoginCode()
                            LogLoginInfo(code, deviceName, macAddress, currentDate, currentTime, enteredUser, enteredPass, "دخول ناجح")

                            Notify.Toast("تم تسجيل الدخول بنجاح ✅", Notify.ToastType.Success)

                            Me.Hide()
                            Dim mainForm As New MainForm()
                            mainForm.Show()

                            txtpassword.Clear()
                            Return
                        Else
                            MessageBox.Show("❌ اسم المستخدم أو كلمة المرور غير صحيحة.", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtpassword.Clear()
                            txtpassword.Focus()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Logger.LogError("btnlogin_Click", ex)
            MessageBox.Show("حدث خطأ أثناء الاتصال بالخادم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnlogin.Enabled = True
            btnlogin.Text = originalButtonText
            Me.Cursor = Cursors.Default
        End Try
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

End Class
