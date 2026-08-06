Imports System.Data.SqlClient
Imports System.Net.NetworkInformation
Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.Threading

Public Class Login
    Private x As Integer, y As Integer
    Private newpoint As New Point
    Private lastRow As Integer
    Private Shared appMutex As Mutex

    Private Function GetMacAddress() As String
        Try
            Dim networkInterfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each netInterface As NetworkInterface In networkInterfaces
                If netInterface.OperationalStatus = OperationalStatus.Up Then
                    Dim bytes = netInterface.GetPhysicalAddress().GetAddressBytes()
                    Return BitConverter.ToString(bytes)
                End If
            Next
        Catch ex As Exception
            Return "لا يمكن الحصول على عنوان MAC"
        End Try

        Return "لم يتم العثور على بطاقة شبكة نشطة"
    End Function



    Private Function GetNextLoginCode() As Integer
        Dim query As String = "SELECT COUNT(ID) AS NumberOfItems FROM Login_Info_TBL WHERE ID IS NOT NULL"
        Try
            Connect()
            Using cmd As New SqlCommand(query, Conn)
                Dim resultObj As Object = cmd.ExecuteScalar()
                Dim cnt As Integer = 0
                If resultObj IsNot Nothing AndAlso Integer.TryParse(resultObj.ToString(), cnt) Then
                    Return cnt + 1
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء جلب رقم الإدخال: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
        Return 1
    End Function

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
            Connect()
            Using cmd As New SqlCommand(insertSql, Conn)
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
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تسجيل الدخول: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub GetUserId()
        Dim query As String =
            "SELECT User_ID FROM Users_TBL WHERE User_username = @username"
        Try
            Connect()
            Using command As New SqlCommand(query, Conn)
                command.Parameters.AddWithValue("@username", txtusername.Text.Trim)
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Integer.TryParse(result.ToString(), New Integer()) Then
                    useridlogin = Convert.ToInt32(result)
                Else
                    useridlogin = 0
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("حدث خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
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
        ' [FIX] استبدال Process.Kill بإغلاق نظيف يحرر الموارد
        Try
            StopScanner()
        Catch
        End Try
        Try
            Disconnect()
        Catch
        End Try
        Application.Exit()
    End Sub

    Private Sub txtusername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtpassword.Focus()
        End If
    End Sub

    Private Sub txtpassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnlogin.PerformClick()
        End If
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        'If CheckBox1.Checked Then
        '    password.PasswordChar = ControlChars.NullChar
        'Else
        '    password.PasswordChar = "*"c
        'End If


        txtpassword.UseSystemPasswordChar = Not CheckBox1.Checked
        'password.PasswordChar = CheckBox1.Checked ?  ? '\0' : '●'
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' --- منع تشغيل أكثر من نسخة ---
        'Dim createdNew As Boolean = False

        '' اسم فريد للبرنامج - غيره لأي اسم خاص بالبرنامج
        'appMutex = New Mutex(True, "AmmarAppMutex2025_UniqueName", createdNew)

        '' لو createdNew = False → يبقى في نسخة شغالة قبل كده
        'If Not createdNew Then
        '    MsgBox("يوجد نسخة أخرى من البرنامج تعمل بالفعل، سيتم إعادة تشغيل البرنامج.", vbExclamation)

        '    ' شغل نسخة جديدة
        '    Process.Start(Application.ExecutablePath)

        '    ' اقفل النسخة الحالية فورًا
        '    End
        '    Return
        'End If
        ' [FIX] إخفاء عناصر فحص الإنترنت (تم إلغاء الميزة بناءً على طلب المستخدم)
        'Dim StoreName As String = SettingsManager.GetSetting("ShopName")
        'If String.IsNullOrEmpty(StoreName) Then StoreName = ""

        'lbltitle.Text = StoreName


        Try
            'Label6.Visible = False
            'PictureBox2.Visible = False
        Catch
        End Try

        ' [FIX] جعل الـ Scanner لا يظهر MessageBox عند فشل فتح المنفذ
        Try
            StartScanner()
        Catch
        End Try

        AddHandler Application.ApplicationExit, AddressOf AppExit

        txtusername.Focus()

        ' [FIX] تشغيل النسخ الاحتياطي وحذف القديمة في الخلفية
        ' بدلاً من حجب UI Thread وقت فتح شاشة الدخول
        Task.Run(Sub()
                     Try
                         CheckAndTakeScheduledBackup("D:\Backups", "نسخة بدأ التشغيل")
                     Catch ex As Exception
                         Debug.WriteLine("Background backup error: " & ex.Message)
                     End Try

                     Try
                         DeleteOldBackups()
                     Catch ex As Exception
                         Debug.WriteLine("Background delete-old error: " & ex.Message)
                     End Try
                 End Sub)
        'If IsInternetAvailable() Then
        '    If Not CheckActivation.IsActivated() Then
        '        FormActivation.Show()

        '        If Not CheckActivation.IsActivated() Then
        '            MsgBox("البرنامج مغلق لحين التفعيل.", vbCritical)
        '            End
        '        End If
        '    End If
        'Else

        'End If
        'BackgroundActivationTimer.Interval = 1000 ' كل 60 ثانية
        'BackgroundActivationTimer.Start()
        ' البرنامج اشتغل بنجاح
        '' التعامل مع مفتاح التجربة في الريجستري
        'Try
        '    Dim trialKey As String = "HKEY_CURRENT_USER\keyammar"
        '    Dim trialValueName As String = "keyammar"
        '    Dim currentValue As Object = My.Computer.Registry.GetValue(trialKey, trialValueName, Nothing)

        '    If currentValue Is Nothing Then
        '        My.Computer.Registry.SetValue(trialKey, trialValueName, 30)
        '    Else
        '        Dim mm As Integer
        '        If Integer.TryParse(currentValue.ToString(), mm) Then
        '            mm -= 1
        '            My.Computer.Registry.SetValue(trialKey, trialValueName, mm)

        '            If mm < 1 Then
        '                MessageBox.Show("عذرًا، انتهت الفترة التجريبية للبرنامج. يُرجى شراء النسخة الكاملة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                ' اغلاق التطبيق بأمان
        '                For Each frm As Form In Application.OpenForms.Cast(Of Form)().ToList()
        '                    frm.Close()
        '                Next
        '                Return
        '            End If
        '        Else
        '            MessageBox.Show("حدث خطأ: القيمة المخزنة غير صالحة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("خطأ أثناء التحقق من التجربة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        ' [FIX] DeleteOldBackups() نُقلت إلى Task.Run أعلاه (لا حجب لـ UI Thread)

    End Sub
    Public Sub DeleteOldBackups(Optional days As Integer = 30)
        Try
            DBModule.Connect()

            Dim limitDate As DateTime = DateTime.Now.AddDays(-days)

            Dim query As String =
            "SELECT Backup_ID, Backup_File 
             FROM Backup_Log 
             WHERE Backup_Date < @LimitDate"

            Using cmd As New SqlCommand(query, DBModule.Conn)
                cmd.Parameters.AddWithValue("@LimitDate", limitDate)

                Using dr As SqlDataReader = cmd.ExecuteReader()
                    Dim filesToDelete As New List(Of String)
                    Dim idsToDelete As New List(Of Integer)

                    While dr.Read()
                        filesToDelete.Add(dr("Backup_File").ToString())
                        idsToDelete.Add(Convert.ToInt32(dr("Backup_ID")))
                    End While

                    dr.Close()

                    ' ===== حذف الملفات من الهارد =====
                    For Each filePath In filesToDelete
                        If System.IO.File.Exists(filePath) Then
                            System.IO.File.Delete(filePath)
                        End If
                    Next

                    ' ===== حذف السجلات من قاعدة البيانات =====
                    For Each id In idsToDelete
                        Using delCmd As New SqlCommand(
                        "DELETE FROM Backup_Log WHERE Backup_ID = @ID", DBModule.Conn)
                            delCmd.Parameters.AddWithValue("@ID", id)
                            delCmd.ExecuteNonQuery()
                        End Using
                    Next
                End Using
            End Using

        Catch ex As Exception
            MsgBox("خطأ أثناء تنظيف النسخ القديمة: " & ex.Message)
        End Try
    End Sub

    Private Sub AppExit(sender As Object, e As EventArgs)
        'StopServer()
    End Sub
    Private Sub BackgroundActivationTimer_Tick(sender As Object, e As EventArgs) Handles BackgroundActivationTimer.Tick
        Task.Run(Sub()
                     Dim ok = CheckActivation.CheckActivationBackground()

                     If Not ok Then
                         Me.Invoke(Sub()

                                       BackgroundActivationTimer.Stop()

                                       MsgBox("تم إلغاء تفعيل البرنامج من السيرفر.", vbCritical)

                                       Dim actForm As New FormActivation()
                                       actForm.Show()

                                       For Each frm As Form In Application.OpenForms.Cast(Of Form)().ToList()
                                           If frm IsNot actForm Then
                                               frm.Close()
                                           End If
                                       Next

                                   End Sub)


                     End If

                 End Sub)
    End Sub

    ' [FIX] حُذفت دوال CheckInternetStatus / IsInternetAvailable / Timer1_Tick
    ' فحص الإنترنت كل ثانية كان من أكبر أسباب التهنيج:
    '   - NetworkInterface.GetIsNetworkAvailable() يحجب UI Thread حتى 30 ثانية
    '     عند انقطاع الشبكة.
    '   - Timer كل 1000ms يكدّس استدعاءات إذا تأخر الأول.
    ' Timer1 لا يزال موجوداً في Designer لكنه بلا handler ولا يبدأ.

    Public Sub FillFromScanner(code As String)
        Try
            If String.IsNullOrWhiteSpace(code) Then Return

            If code.Contains(":") Then
                Dim parts = code.Split(":"c)
                txtusername.Clear()
                txtpassword.Clear()
                txtusername.Text = parts(0)
                If parts.Length > 1 Then txtpassword.Text = parts(1)
                btnlogin.PerformClick()
            Else
                If String.IsNullOrEmpty(txtusername.Text) Then
                    'username.Text = code
                Else
                    'password.Text = code
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub HideAllFormsExcept(targetForm As Form)
        For Each openForm As Form In Application.OpenForms.OfType(Of Form)().ToList()
            openForm.Close()
        Next
    End Sub



    Public Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        If String.IsNullOrWhiteSpace(txtusername.Text) Then
            MessageBox.Show("يرجى إدخال اسم المستخدم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(txtpassword.Text) Then
            MessageBox.Show("يرجى إدخال كلمة المرور", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim enteredUser As String = txtusername.Text.Trim()
        Dim enteredPass As String = txtpassword.Text.Trim()

        Dim deviceName As String = Environment.MachineName
        Dim macAddress As String = GetMacAddress()
        Dim currentDate As DateTime = DateTime.Today
        Dim currentTime As String = DateTime.Now.ToString("hh:mm:ss tt")

        If enteredUser = usernameadmin AndAlso enteredPass = passwordadmin Then
            Me.Hide()
            Dim mainForm As New MainForm()
            mainForm.Show()

            Dim code As Integer = GetNextLoginCode()
            LogLoginInfo(code, deviceName, macAddress, currentDate, currentTime, enteredUser, enteredPass, "")

            Notify.Toast("تم الدخول بنجاح", Notify.ToastType.Success)

            usernamelogin = enteredUser
            passwordlogin = enteredPass
            GetUserId()

            txtusername.Text = String.Empty
            txtpassword.Text = String.Empty
            Return
        End If


        Dim query As String = "
    SELECT User_ID, RoleID, User_username, User_Stats ,User_Name
    FROM Users_TBL 
    WHERE User_username = @username AND User_password = @password"
        Try
            Connect()
            Using cmd As New SqlClient.SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@username", enteredUser)
                cmd.Parameters.AddWithValue("@password", enteredPass)

                Using reader As SqlClient.SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then

                        Dim userStats As Boolean = False
                        If Not IsDBNull(reader("User_Stats")) Then
                            userStats = Convert.ToBoolean(reader("User_Stats"))
                        End If

                        If userStats = False Then
                            MessageBox.Show("⚠️ هذا المستخدم محظور أو غير مفعل.", "مستخدم محظور", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            txtusername.Clear()
                            txtpassword.Clear()
                            txtusername.Focus()
                            Return
                        End If

                        Dim userId As Integer = 0
                        Integer.TryParse(reader("User_ID").ToString(), userId)

                        Dim roleId As Integer = 0
                        If Not IsDBNull(reader("RoleID")) Then
                            Integer.TryParse(reader("RoleID").ToString(), roleId)
                        End If

                        Session.CurrentUserID = userId
                        Session.CurrentUserfullName = reader("User_Name").ToString()
                        Session.CurrentUserName = enteredUser
                        Session.CurrentUserPassword = enteredPass
                        Session.CurrentRoleID = roleId

                        Session.LoadPermissions(roleId)

                        Me.Hide()
                        Dim mainForm As New MainForm()
                        mainForm.Show()

                        Dim code As Integer = GetNextLoginCode()
                        LogLoginInfo(code, deviceName, macAddress, currentDate, currentTime, enteredUser, enteredPass, "")

                        Notify.Toast("تم تسجيل الدخول بنجاح", Notify.ToastType.Success)
                        usernamelogin = enteredUser
                        passwordlogin = enteredPass

                        txtusername.Clear()
                        txtpassword.Clear()
                        Return
                    Else
                        MessageBox.Show("❌ اسم المستخدم أو كلمة المرور غير صحيحة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtusername.Clear()
                        txtpassword.Clear()
                        txtusername.Focus()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تسجيل الدخول: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub
End Class
