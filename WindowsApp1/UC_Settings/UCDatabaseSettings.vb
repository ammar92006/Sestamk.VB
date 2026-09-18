Imports System.Drawing
Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات اتصال خادم وقاعدة بيانات SQL Server
    ''' </summary>
    Public Class UCDatabaseSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCDatabaseSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            PopulateDetectedServers()
            LoadDbSettingsToForm()
        End Sub

        Public Sub LoadDbSettingsToForm()
            Try
                DBModule.LoadDbSettings()

                txtDbServer.Text = DBModule.server
                txtDbName.Text = DBModule.database
                txtDbUser.Text = DBModule.username
                txtDbPassword.Text = DBModule.password
                chkWindowsAuth.Checked = DBModule.useWindowsAuth

                UpdateAuthFields()
            Catch ex As Exception
                MessageBox.Show("خطأ في تحميل إعدادات قاعدة البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PopulateDetectedServers()
            Try
                Dim current As String = txtDbServer.Text
                txtDbServer.Items.Clear()
                For Each srv As String In DBModule.DetectSqlServers()
                    txtDbServer.Items.Add(srv)
                Next
                If Not String.IsNullOrEmpty(current) Then txtDbServer.Text = current
            Catch ex As Exception
                Debug.WriteLine("PopulateDetectedServers: " & ex.Message)
            End Try
        End Sub

        Private Sub btnDetectServers_Click(sender As Object, e As EventArgs) Handles btnDetectServers.Click
            Try
                PopulateDetectedServers()

                Dim dbName As String = txtDbName.Text.Trim()
                If String.IsNullOrEmpty(dbName) Then dbName = DBModule.database

                Dim winAuth As Boolean = chkWindowsAuth.Checked
                Dim usr As String = txtDbUser.Text.Trim()
                Dim pwd As String = txtDbPassword.Text

                For Each srv As String In DBModule.DetectSqlServers()
                    Dim cs As String = DBModule.BuildConnectionString(srv, dbName, usr, pwd, winAuth)
                    If DBModule.TestConnection(cs) Then
                        txtDbServer.Text = srv
                        lblDbStatus.Text = "✅ تم العثور على خادم متصل بنجاح: " & srv
                        lblDbStatus.ForeColor = Color.LightGreen
                        Return
                    End If
                Next

                lblDbStatus.Text = "⚠️ تم تحديث قائمة الخوادم لكن لم يتصل أي خادم بقاعدة البيانات."
                lblDbStatus.ForeColor = Color.Orange
            Catch ex As Exception
                lblDbStatus.Text = "❌ خطأ أثناء الاكتشاف: " & ex.Message
                lblDbStatus.ForeColor = Color.OrangeRed
            End Try
        End Sub

        Private Sub chkWindowsAuth_CheckedChanged(sender As Object, e As EventArgs) Handles chkWindowsAuth.CheckedChanged
            UpdateAuthFields()
        End Sub

        Private Sub UpdateAuthFields()
            Dim useWin As Boolean = chkWindowsAuth.Checked
            txtDbUser.Enabled = Not useWin
            txtDbPassword.Enabled = Not useWin
            lblDbUser.Enabled = Not useWin
            lblDbPassword.Enabled = Not useWin
        End Sub

        Private Sub btnTestDbConnection_Click(sender As Object, e As EventArgs) Handles btnTestDbConnection.Click
            Try
                Dim tempCs As String
                If chkWindowsAuth.Checked Then
                    tempCs = $"Server={txtDbServer.Text.Trim()};Database={txtDbName.Text.Trim()};Integrated Security=True;MultipleActiveResultSets=True;"
                Else
                    tempCs = $"Server={txtDbServer.Text.Trim()};Database={txtDbName.Text.Trim()};User Id={txtDbUser.Text.Trim()};Password={txtDbPassword.Text};MultipleActiveResultSets=True;"
                End If

                If DBModule.TestConnection(tempCs) Then
                    lblDbStatus.Text = "✅ الاتصال بقاعدة البيانات ناجح وصحيح 100%"
                    lblDbStatus.ForeColor = Color.LightGreen
                Else
                    lblDbStatus.Text = "❌ فشل الاتصال بقاعدة البيانات — يرجى مراجعة اسم السيرفر وبيانات الدخول"
                    lblDbStatus.ForeColor = Color.OrangeRed
                End If
            Catch ex As Exception
                lblDbStatus.Text = "❌ " & ex.Message
                lblDbStatus.ForeColor = Color.OrangeRed
            End Try
        End Sub

        Private Sub btnSaveDbSettings_Click(sender As Object, e As EventArgs) Handles btnSaveDbSettings.Click
            Try
                DBModule.server = txtDbServer.Text.Trim()
                DBModule.database = txtDbName.Text.Trim()
                DBModule.username = txtDbUser.Text.Trim()
                DBModule.password = txtDbPassword.Text
                DBModule.useWindowsAuth = chkWindowsAuth.Checked

                DBModule.SaveDbSettings()

                If DBModule.TestConnection() Then
                    Try
                        Notify.Toast("تم حفظ إعدادات قاعدة البيانات وتم التحقق من الاتصال بنجاح ✅", Notify.ToastType.Success)
                    Catch
                        MessageBox.Show("✅ تم حفظ إعدادات قاعدة البيانات بنجاح والاتصال يعمل تماماً.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                    lblDbStatus.Text = "✅ تم الحفظ بنجاح والاتصال نشط"
                    lblDbStatus.ForeColor = Color.LightGreen
                Else
                    Dim result = MessageBox.Show("⚠️ تم الحفظ لكن تعذّر الاتصال بقاعدة البيانات بالإعدادات الجديدة." & vbCrLf &
                                                 "هل تريد الإبقاء على الإعدادات؟",
                                                 "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If result = DialogResult.No Then
                        DBModule.LoadDbSettings()
                        LoadDbSettingsToForm()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("❌ خطأ في الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            LoadDbSettingsToForm()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
