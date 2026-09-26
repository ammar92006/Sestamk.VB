Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports WindowsApp1.Services

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات اتصال خادم وقاعدة بيانات SQL Server
    ''' مع دعم محرك SQL Server Express LocalDB ومحرك الفحص والترقيع التلقائي
    ''' </summary>
    Public Class UCDatabaseSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Private _isBusy As Boolean = False
        Private _selectedEngineMode As String = "localdb" ' "localdb" or "sqlserver"

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCDatabaseSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            PopulateDetectedServers()
            LoadDbSettingsToForm()

            ' تطبيق الثيم الحالي على الشاشة والعناصر المخصصة
            ApplyThemeColors()
            AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged

            ' تحديث حالة محرك LocalDB في الخلفية
            Dim chkLocalDbTask = RefreshLocalDbStatusAsync()

            ' تحميل إحصائيات الجداول إذا كان الاتصال متاحاً
            Dim loadTask = SafeLoadTableStatisticsAsync()
        End Sub

        Private Sub UCDatabaseSettings_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
            RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
        End Sub

        Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
            If Me.IsDisposed OrElse Me.Disposing Then Return
            ApplyThemeColors()
        End Sub

        ''' <summary>
        ''' تطبيق ألوان الثيم على عناصر DataGridView وسجل العمليات والبطاقات
        ''' </summary>
        Private Sub ApplyThemeColors()
            Try
                If Me.IsDisposed OrElse Me.Disposing Then Return

                Dim isDark = ThemeManager.Instance.IsDark
                Dim palette = ThemeManager.Instance.Palette

                If isDark Then
                    pnlMain.BackColor = Color.FromArgb(13, 15, 20)

                    cardEngine.FillColor = Color.FromArgb(26, 31, 43)
                    cardEngine.BorderColor = Color.FromArgb(42, 47, 59)

                    cardLocalDb.FillColor = Color.FromArgb(26, 31, 43)
                    cardLocalDb.BorderColor = Color.FromArgb(42, 47, 59)

                    cardServer.FillColor = Color.FromArgb(26, 31, 43)
                    cardServer.BorderColor = Color.FromArgb(42, 47, 59)

                    cardAuth.FillColor = Color.FromArgb(26, 31, 43)
                    cardAuth.BorderColor = Color.FromArgb(42, 47, 59)

                    cardStatus.FillColor = Color.FromArgb(26, 31, 43)
                    cardStatus.BorderColor = Color.FromArgb(42, 47, 59)

                    cardMaintenance.FillColor = Color.FromArgb(26, 31, 43)
                    cardMaintenance.BorderColor = Color.FromArgb(42, 47, 59)

                    cardReset.FillColor = Color.FromArgb(26, 31, 43)
                    cardReset.BorderColor = Color.FromArgb(42, 47, 59)

                    txtMaintenanceLog.FillColor = Color.FromArgb(15, 18, 24)
                    txtMaintenanceLog.ForeColor = Color.FromArgb(220, 225, 235)
                    txtMaintenanceLog.BorderColor = Color.FromArgb(55, 65, 81)

                    If dgvTables IsNot Nothing AndAlso Not dgvTables.IsDisposed Then
                        dgvTables.BackgroundColor = Color.FromArgb(20, 24, 33)
                        dgvTables.DefaultCellStyle.BackColor = Color.FromArgb(26, 31, 43)
                        dgvTables.DefaultCellStyle.ForeColor = Color.White
                        dgvTables.DefaultCellStyle.SelectionBackColor = Color.FromArgb(42, 50, 68)
                        dgvTables.DefaultCellStyle.SelectionForeColor = Color.White
                        dgvTables.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(20, 24, 33)
                        dgvTables.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 36, 50)
                        dgvTables.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                        dgvTables.GridColor = Color.FromArgb(42, 47, 59)
                        dgvTables.ThemeStyle.GridColor = Color.FromArgb(42, 47, 59)
                        dgvTables.ThemeStyle.BackColor = Color.FromArgb(20, 24, 33)
                    End If
                Else
                    pnlMain.BackColor = Color.FromArgb(248, 250, 252)

                    cardEngine.FillColor = Color.White
                    cardEngine.BorderColor = Color.FromArgb(226, 232, 240)

                    cardLocalDb.FillColor = Color.White
                    cardLocalDb.BorderColor = Color.FromArgb(226, 232, 240)

                    cardServer.FillColor = Color.White
                    cardServer.BorderColor = Color.FromArgb(226, 232, 240)

                    cardAuth.FillColor = Color.White
                    cardAuth.BorderColor = Color.FromArgb(226, 232, 240)

                    cardStatus.FillColor = Color.White
                    cardStatus.BorderColor = Color.FromArgb(226, 232, 240)

                    cardMaintenance.FillColor = Color.White
                    cardMaintenance.BorderColor = Color.FromArgb(226, 232, 240)

                    cardReset.FillColor = Color.White
                    cardReset.BorderColor = Color.FromArgb(226, 232, 240)

                    txtMaintenanceLog.FillColor = Color.FromArgb(241, 245, 249)
                    txtMaintenanceLog.ForeColor = Color.FromArgb(30, 41, 59)
                    txtMaintenanceLog.BorderColor = Color.FromArgb(203, 213, 225)

                    If dgvTables IsNot Nothing AndAlso Not dgvTables.IsDisposed Then
                        dgvTables.BackgroundColor = Color.White
                        dgvTables.DefaultCellStyle.BackColor = Color.White
                        dgvTables.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59)
                        dgvTables.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 232, 240)
                        dgvTables.DefaultCellStyle.SelectionForeColor = Color.Black
                        dgvTables.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
                        dgvTables.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249)
                        dgvTables.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42)
                        dgvTables.GridColor = Color.FromArgb(226, 232, 240)
                        dgvTables.ThemeStyle.GridColor = Color.FromArgb(226, 232, 240)
                        dgvTables.ThemeStyle.BackColor = Color.White
                    End If

                    lblTitle.ForeColor = Color.FromArgb(15, 23, 42)
                    lblSubtitle.ForeColor = Color.FromArgb(71, 85, 105)

                    lblCardEngineTitle.ForeColor = Color.FromArgb(15, 23, 42)
                    lblCardLocalDbTitle.ForeColor = Color.FromArgb(15, 23, 42)
                    lblCardServerTitle.ForeColor = Color.FromArgb(15, 23, 42)
                    lblDbServer.ForeColor = Color.FromArgb(51, 65, 85)
                    lblDbName.ForeColor = Color.FromArgb(51, 65, 85)

                    lblCardAuthTitle.ForeColor = Color.FromArgb(15, 23, 42)
                    chkWindowsAuth.ForeColor = Color.FromArgb(51, 65, 85)
                    lblDbUser.ForeColor = Color.FromArgb(51, 65, 85)
                    lblDbPassword.ForeColor = Color.FromArgb(51, 65, 85)

                    lblCardStatusTitle.ForeColor = Color.FromArgb(15, 23, 42)
                    lblDbStatus.ForeColor = Color.FromArgb(71, 85, 105)

                    lblCardMaintenanceTitle.ForeColor = Color.FromArgb(15, 23, 42)
                    lblCardMaintenanceSubtitle.ForeColor = Color.FromArgb(71, 85, 105)
                    lblMaintenanceProgress.ForeColor = Color.FromArgb(51, 65, 85)

                    lblCardResetTitle.ForeColor = Color.FromArgb(15, 23, 42)
                    lblCardResetSubtitle.ForeColor = Color.FromArgb(71, 85, 105)
                End If
            Catch ex As Exception
                Debug.WriteLine("ApplyThemeColors error: " & ex.Message)
            End Try
        End Sub

        Public Sub LoadDbSettingsToForm()
            Try
                DBModule.LoadDbSettings()

                txtDbServer.Text = DBModule.server
                txtDbName.Text = DBModule.database
                txtDbUser.Text = DBModule.username
                txtDbPassword.Text = DBModule.password
                chkWindowsAuth.Checked = DBModule.useWindowsAuth

                chkAttachDb.Checked = DBModule.useAttachDb
                txtAttachDbPath.Text = DBModule.attachDbPath

                If String.IsNullOrEmpty(txtAttachDbPath.Text) Then
                    txtAttachDbPath.Text = LocalDbManager.GetDefaultDatabaseMdfPath(DBModule.database)
                End If

                _selectedEngineMode = DBModule.dbEngineType
                If String.IsNullOrEmpty(_selectedEngineMode) Then
                    _selectedEngineMode = If(DBModule.server.ToLower().Contains("(localdb)"), "localdb", "sqlserver")
                End If

                UpdateEngineModeVisuals(_selectedEngineMode)
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

        ' ══════════════════════════════════════════════════════════════════════
        ' التبديل بين نمط LocalDB وخادم SQL Server الشبكي
        ' ══════════════════════════════════════════════════════════════════════

        Private Sub btnSelectLocalDb_Click(sender As Object, e As EventArgs) Handles btnSelectLocalDb.Click
            _selectedEngineMode = "localdb"
            UpdateEngineModeVisuals("localdb")

            ' ضبط الافتراضيات لـ LocalDB
            txtDbServer.Text = "(localdb)\MSSQLLocalDB"
            chkWindowsAuth.Checked = True
            UpdateAuthFields()

            Dim chkTask = RefreshLocalDbStatusAsync()
        End Sub

        Private Sub btnSelectServer_Click(sender As Object, e As EventArgs) Handles btnSelectServer.Click
            _selectedEngineMode = "sqlserver"
            UpdateEngineModeVisuals("sqlserver")

            If txtDbServer.Text.ToLower().Contains("(localdb)") Then
                txtDbServer.Text = ".\SQLEXPRESS"
            End If
            UpdateAuthFields()
        End Sub

        Private Sub UpdateEngineModeVisuals(mode As String)
            If mode = "localdb" Then
                btnSelectLocalDb.FillColor = Color.FromArgb(16, 185, 129)
                btnSelectLocalDb.ForeColor = Color.White
                btnSelectLocalDb.BorderThickness = 0

                btnSelectServer.FillColor = Color.FromArgb(42, 47, 59)
                btnSelectServer.ForeColor = Color.FromArgb(209, 213, 219)
                btnSelectServer.BorderThickness = 1

                cardLocalDb.Visible = True
                btnDetectServers.Visible = False
            Else
                btnSelectServer.FillColor = Color.FromArgb(58, 141, 252)
                btnSelectServer.ForeColor = Color.White
                btnSelectServer.BorderThickness = 0

                btnSelectLocalDb.FillColor = Color.FromArgb(42, 47, 59)
                btnSelectLocalDb.ForeColor = Color.FromArgb(209, 213, 219)
                btnSelectLocalDb.BorderThickness = 1

                cardLocalDb.Visible = False
                btnDetectServers.Visible = True
            End If
        End Sub

        ' ══════════════════════════════════════════════════════════════════════
        ' إدارة محرك LocalDB الداخلي
        ' ══════════════════════════════════════════════════════════════════════

        Private Async Function RefreshLocalDbStatusAsync() As Task
            Try
                If Me.IsDisposed OrElse Me.Disposing Then Return

                lblLocalDbStatusText.Text = "جاري فحص محرك LocalDB..."
                lblLocalDbStatusText.ForeColor = Color.Yellow

                Dim info = Await LocalDbManager.GetInstanceStatusAsync("MSSQLLocalDB")

                If Me.IsDisposed OrElse Me.Disposing Then Return

                If Not info.IsInstalled Then
                    Dim msi = LocalDbManager.FindLocalDbMsiInstaller()
                    btnInstallLocalDb.Visible = True
                    If Not String.IsNullOrEmpty(msi) Then
                        lblLocalDbStatusText.Text = "❌ محرك LocalDB غير مثبت على الجهاز (حزمة التثبيت متوفرة)"
                        btnInstallLocalDb.Text = "📦 تثبيت محرك LocalDB صامتاً (متوفر)"
                    Else
                        lblLocalDbStatusText.Text = "❌ محرك LocalDB غير مثبت على هذا الجهاز"
                        btnInstallLocalDb.Text = "⬇️ تثبيت / تنزيل محرك LocalDB"
                    End If
                    lblLocalDbStatusText.ForeColor = Color.OrangeRed
                    btnStartLocalDb.Enabled = False
                    btnStopLocalDb.Enabled = False
                Else
                    btnInstallLocalDb.Visible = False
                    btnStartLocalDb.Enabled = (info.State <> LocalDbState.Running)
                    btnStopLocalDb.Enabled = (info.State = LocalDbState.Running)

                    If info.State = LocalDbState.Running Then
                        lblLocalDbStatusText.Text = $"✅ محرك LocalDB مثبت والنسخة [MSSQLLocalDB] تعمل بنشاط (v{info.Version})"
                        lblLocalDbStatusText.ForeColor = Color.LightGreen
                    Else
                        lblLocalDbStatusText.Text = $"⏸️ محرك LocalDB مثبت لكن النسخة [MSSQLLocalDB] متوقفة حالياً"
                        lblLocalDbStatusText.ForeColor = Color.Orange
                    End If
                End If
            Catch ex As Exception
                lblLocalDbStatusText.Text = "خطأ في فحص LocalDB: " & ex.Message
                lblLocalDbStatusText.ForeColor = Color.OrangeRed
            End Try
        End Function

        Private Async Sub btnStartLocalDb_Click(sender As Object, e As EventArgs) Handles btnStartLocalDb.Click
            lblLocalDbStatusText.Text = "جاري بدء تشغيل محرك LocalDB..."
            Dim started = Await LocalDbManager.StartInstanceAsync("MSSQLLocalDB")
            Await RefreshLocalDbStatusAsync()
            If started Then
                Try
                    Notify.Toast("تم تشغيل محرك LocalDB بنجاح ▶️", Notify.ToastType.Success)
                Catch
                End Try
            Else
                MessageBox.Show("تعذر تشغيل محرك LocalDB تلقائياً. تحقق من تثبيت SQL LocalDB.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Async Sub btnStopLocalDb_Click(sender As Object, e As EventArgs) Handles btnStopLocalDb.Click
            lblLocalDbStatusText.Text = "جاري إيقاف محرك LocalDB..."
            Await LocalDbManager.StopInstanceAsync("MSSQLLocalDB")
            Await RefreshLocalDbStatusAsync()
            Try
                Notify.Toast("تم إيقاف محرك LocalDB ⏹️", Notify.ToastType.Info)
            Catch
            End Try
        End Sub

        Private Async Sub btnCheckLocalDb_Click(sender As Object, e As EventArgs) Handles btnCheckLocalDb.Click
            Await RefreshLocalDbStatusAsync()
        End Sub

        Private Async Sub btnInstallLocalDb_Click(sender As Object, e As EventArgs) Handles btnInstallLocalDb.Click
            Dim msi = LocalDbManager.FindLocalDbMsiInstaller()

            If String.IsNullOrEmpty(msi) Then
                Dim askDownload = MessageBox.Show(
                    "لم يتم العثور على ملف SqlLocalDB.msi تلقائياً على هذا الجهاز." & vbCrLf & vbCrLf &
                    "هل ترغب في تنزيل الحزمة الرسمية من موقع Microsoft وتثبيتها تلقائياً الآن؟" & vbCrLf &
                    "(اضغط 'لا' لتحديد مكان الملف يدوياً من جهازك)",
                    "تنزيل أو تحديد SqlLocalDB.msi",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If askDownload = DialogResult.Yes Then
                    btnInstallLocalDb.Enabled = False
                    lblLocalDbStatusText.Text = "⏳ جارٍ تنزيل SqlLocalDB.msi من موقع Microsoft..."
                    lblLocalDbStatusText.ForeColor = Color.Yellow

                    Dim downloadTarget = Path.Combine(Application.StartupPath, "redist", "SqlLocalDB.msi")
                    Dim prog As New Progress(Of Integer)(Sub(pct)
                                                             lblLocalDbStatusText.Text = $"⏳ جارٍ التنزيل: {pct}%..."
                                                         End Sub)
                    Dim downloaded = Await LocalDbManager.DownloadLocalDbMsiAsync(downloadTarget, prog)
                    If downloaded Then
                        msi = downloadTarget
                    Else
                        MessageBox.Show("تعذر تنزيل حزمة SqlLocalDB.msi تلقائياً. تأكد من اتصال الإنترنت أو انسخ الملف يدوياً.", "فشل التنزيل", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        btnInstallLocalDb.Enabled = True
                        Return
                    End If
                ElseIf askDownload = DialogResult.No Then
                    Using ofd As New OpenFileDialog()
                        ofd.Title = "اختر ملف SqlLocalDB.msi"
                        ofd.Filter = "حزم تثبيت Windows Installer (*.msi)|*.msi|جميع الملفات (*.*)|*.*"
                        ofd.FileName = "SqlLocalDB.msi"
                        If ofd.ShowDialog() = DialogResult.OK Then
                            msi = ofd.FileName
                        Else
                            Return
                        End If
                    End Using
                Else
                    Return
                End If
            End If

            Dim ask = MessageBox.Show("هل تريد بدء التثبيت الصامت لمحرك Microsoft SQL Server Express LocalDB الآن؟",
                                      "تثبيت LocalDB", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If ask <> DialogResult.Yes Then Return

            btnInstallLocalDb.Enabled = False
            lblLocalDbStatusText.Text = "جاري التثبيت في الخلفية، يرجى الانتظار..."
            lblLocalDbStatusText.ForeColor = Color.Yellow

            Dim installed = Await LocalDbManager.InstallLocalDbSilentlyAsync(msi)
            btnInstallLocalDb.Enabled = True

            If installed Then
                MessageBox.Show("تم تثبيت محرك SQL Server LocalDB بنجاح!", "نجاح التثبيت", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Await RefreshLocalDbStatusAsync()
            Else
                MessageBox.Show("فشل التثبيت أو تم إلغاؤه من قبل المستخدم. يرجى تشغيل ملف SqlLocalDB.msi يدوياً بصلاحيات مدير النظام.", "فشل التثبيت", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        ''' <summary>
        ''' تهيئة وتثبيت قاعدة البيانات الخاصة بـ LocalDB وبناء كافة الجداول من الكود والموارد تلقائياً
        ''' </summary>
        Private Async Sub btnInitLocalDatabase_Click(sender As Object, e As EventArgs) Handles btnInitLocalDatabase.Click
            Try
                btnInitLocalDatabase.Enabled = False
                btnInitLocalDatabase.Text = "⏳ جارٍ الفحص والتهيئة..."

                ' 1. التحقق من تثبيت محرك LocalDB على جهاز العميل
                If Not LocalDbManager.IsLocalDbInstalled() Then
                    Dim msi = LocalDbManager.FindLocalDbMsiInstaller()
                    If Not String.IsNullOrEmpty(msi) Then
                        Dim ask = MessageBox.Show("محرك SQL Server LocalDB غير مثبت على هذا الجهاز." & vbCrLf &
                                                  "هل تريد تثبيته صامتاً الآن من الحزمة المرفقة؟",
                                                  "تثبيت LocalDB", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If ask = DialogResult.Yes Then
                            lblLocalDbStatusText.Text = "⏳ جارٍ تثبيت محرك LocalDB في الخلفية..."
                            lblLocalDbStatusText.ForeColor = Color.Yellow
                            Dim installed = Await LocalDbManager.InstallLocalDbSilentlyAsync(msi)
                            If Not installed Then
                                MessageBox.Show("تعذر إكمال تثبيت LocalDB تلقائياً. يرجى تشغيل حزمة SqlLocalDB.msi كمسؤول.",
                                                "فشل التثبيت", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return
                            End If
                        Else
                            Return
                        End If
                    Else
                        MessageBox.Show("محرك Microsoft SQL Server LocalDB غير مثبت على هذا الجهاز،" & vbCrLf &
                                        "ولم يتم العثور على ملف SqlLocalDB.msi في مجلد البرنامج." & vbCrLf &
                                        "يرجى تثبيت SQL LocalDB ليعمل هذا النمط.",
                                        "المحرك غير متوفر", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End If

                ' 2. بدء تشغيل نسخة LocalDB الافتراضية
                lblLocalDbStatusText.Text = "⏳ جارٍ بدء تشغيل محرك LocalDB..."
                lblLocalDbStatusText.ForeColor = Color.Yellow
                Dim started = Await LocalDbManager.EnsureInstanceRunningAsync("MSSQLLocalDB")
                If Not started Then
                    MessageBox.Show("تعذر تشغيل نسخة LocalDB (MSSQLLocalDB). يرجى التأكد من صلاحيات النظام.",
                                    "خطأ في تشغيل المحرك", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' 3. إنشاء قاعدة البيانات والجداول من الموارد المضمنة والكود (Self-Healing)
                Dim targetDb = txtDbName.Text.Trim()
                If String.IsNullOrEmpty(targetDb) Then targetDb = "SestamkDB"

                lblLocalDbStatusText.Text = $"⏳ جارٍ إنشاء قاعدة البيانات [{targetDb}] وبناء وترقيع الجداول..."
                lblDbStatus.Text = $"جارٍ تهيئة الجداول وهيكل قاعدة البيانات [{targetDb}]..."

                Dim progressIndicator = New Progress(Of MaintenanceProgress)(
                    Sub(p)
                        lblLocalDbStatusText.Text = $"[{p.Percentage}%] {p.CurrentStep}: {p.Message}"
                    End Sub)

                Dim maint As New DatabaseMaintenanceService("(localdb)\MSSQLLocalDB", targetDb, "", "", True)
                Dim report = Await maint.CheckAndRepairDatabaseAsync(progressIndicator)

                If report.IsSuccess Then
                    ' 4. تحديث وضبط عناصر الواجهة
                    txtDbServer.Text = "(localdb)\MSSQLLocalDB"
                    txtDbName.Text = targetDb
                    chkWindowsAuth.Checked = True
                    _selectedEngineMode = "localdb"
                    UpdateEngineModeVisuals("localdb")

                    ' 5. حفظ الإعدادات الدائمة في DBModule و db_config.ini
                    DBModule.server = "(localdb)\MSSQLLocalDB"
                    DBModule.database = targetDb
                    DBModule.username = ""
                    DBModule.password = ""
                    DBModule.useWindowsAuth = True
                    DBModule.dbEngineType = "localdb"
                    DBModule.useAttachDb = chkAttachDb.Checked
                    DBModule.attachDbPath = txtAttachDbPath.Text.Trim()
                    DBModule.localDbInstanceName = "MSSQLLocalDB"
                    DBModule.SaveDbSettings()

                    lblLocalDbStatusText.Text = $"✅ قاعدة بيانات LocalDB [{targetDb}] جاهزة وتعمل بنشاط!"
                    lblLocalDbStatusText.ForeColor = Color.LightGreen

                    lblDbStatus.Text = $"✅ الاتصال ناجح بقاعدة البيانات [{targetDb}] وجاهزة للاستخدام"
                    lblDbStatus.ForeColor = Color.LightGreen

                    Await RefreshLocalDbStatusAsync()
                    Await SafeLoadTableStatisticsAsync()

                    Dim msg As String = $"🎉 تمت تهيئة وتثبيت قاعدة البيانات [{targetDb}] بنجاح تام!" & vbCrLf & vbCrLf &
                                        $"• عدد الجداول المهيأة والجاهزة: {DatabaseSchemaDefinitions.GetExpectedSchema().Count}" & vbCrLf &
                                        $"• الجداول المنشأة حديثاً: {report.TablesCreated.Count}" & vbCrLf &
                                        $"• الأعمدة التي تم ترقيعها: {report.ColumnsAdded.Count}" & vbCrLf &
                                        $"• زمن التنفيذ: {report.ExecutionTime.TotalSeconds:F2} ثانية" & vbCrLf & vbCrLf &
                                        "تم حفظ الإعدادات تلقائياً، والتطبيق جاهز للعمل بالكامل دون أي ملفات خارجية."

                    MessageBox.Show(msg, "نجاح تهيئة وتثبيت قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Try
                        Notify.Toast("تم تثبيت وتهيئة قاعدة البيانات بنجاح 🚀", Notify.ToastType.Success)
                    Catch
                    End Try
                Else
                    Dim errMsg = String.Join(vbCrLf, report.Errors)
                    MessageBox.Show("حدث خطأ أثناء فحص وتهيئة قاعدة البيانات:" & vbCrLf & errMsg,
                                    "خطأ في التهيئة", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    lblLocalDbStatusText.Text = "❌ فشلت تهيئة قاعدة البيانات"
                    lblLocalDbStatusText.ForeColor = Color.OrangeRed
                End If

            Catch ex As Exception
                MessageBox.Show("خطأ غير متوقع أثناء تهيئة LocalDB: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                btnInitLocalDatabase.Enabled = True
                btnInitLocalDatabase.Text = "⚡ تثبيت وتهيئة قاعدة بيانات LocalDB"
            End Try
        End Sub

        Private Sub chkAttachDb_CheckedChanged(sender As Object, e As EventArgs) Handles chkAttachDb.CheckedChanged
            txtAttachDbPath.Enabled = chkAttachDb.Checked
            btnBrowseMdf.Enabled = chkAttachDb.Checked
            If chkAttachDb.Checked AndAlso String.IsNullOrEmpty(txtAttachDbPath.Text) Then
                txtAttachDbPath.Text = LocalDbManager.GetDefaultDatabaseMdfPath(txtDbName.Text.Trim())
            End If
        End Sub

        Private Sub btnBrowseMdf_Click(sender As Object, e As EventArgs) Handles btnBrowseMdf.Click
            Using ofd As New OpenFileDialog()
                ofd.Filter = "SQL Server Database (*.mdf)|*.mdf|All Files (*.*)|*.*"
                ofd.Title = "اختر ملف قاعدة البيانات"
                If ofd.ShowDialog() = DialogResult.OK Then
                    txtAttachDbPath.Text = ofd.FileName
                End If
            End Using
        End Sub

        ' ══════════════════════════════════════════════════════════════════════
        ' استكشاف السيرفرات والمصادقة
        ' ══════════════════════════════════════════════════════════════════════

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
            Dim useWin As Boolean = chkWindowsAuth.Checked OrElse (_selectedEngineMode = "localdb")
            txtDbUser.Enabled = Not useWin
            txtDbPassword.Enabled = Not useWin
            lblDbUser.Enabled = Not useWin
            lblDbPassword.Enabled = Not useWin
        End Sub

        Private Async Sub btnTestDbConnection_Click(sender As Object, e As EventArgs) Handles btnTestDbConnection.Click
            Try
                Dim srv = txtDbServer.Text.Trim()
                Dim db = txtDbName.Text.Trim()
                Dim usr = txtDbUser.Text.Trim()
                Dim pwd = txtDbPassword.Text
                Dim winAuth = chkWindowsAuth.Checked OrElse (_selectedEngineMode = "localdb")
                Dim attach = If(chkAttachDb.Checked, txtAttachDbPath.Text.Trim(), "")

                ' إذا كان المحرك LocalDB، نتأكد من تشغيل الـ Instance أولاً
                If _selectedEngineMode = "localdb" OrElse srv.ToLower().Contains("(localdb)") Then
                    Await LocalDbManager.EnsureInstanceRunningAsync("MSSQLLocalDB")
                End If

                Dim tempCs = DBModule.BuildConnectionString(srv, db, usr, pwd, winAuth, attach)

                If DBModule.TestConnection(tempCs) Then
                    lblDbStatus.Text = "✅ الاتصال بقاعدة البيانات ناجح وصحيح 100%"
                    lblDbStatus.ForeColor = Color.LightGreen
                    Await SafeLoadTableStatisticsAsync()
                Else
                    lblDbStatus.Text = "❌ فشل الاتصال بقاعدة البيانات — يرجى مراجعة إعدادات السيرفر وبيانات الدخول"
                    lblDbStatus.ForeColor = Color.OrangeRed
                End If
            Catch ex As Exception
                lblDbStatus.Text = "❌ " & ex.Message
                lblDbStatus.ForeColor = Color.OrangeRed
            End Try
        End Sub

        Private Async Sub btnSaveDbSettings_Click(sender As Object, e As EventArgs) Handles btnSaveDbSettings.Click
            Try
                DBModule.server = txtDbServer.Text.Trim()
                DBModule.database = txtDbName.Text.Trim()
                DBModule.username = txtDbUser.Text.Trim()
                DBModule.password = txtDbPassword.Text
                DBModule.useWindowsAuth = chkWindowsAuth.Checked OrElse (_selectedEngineMode = "localdb")

                DBModule.dbEngineType = _selectedEngineMode
                DBModule.useAttachDb = chkAttachDb.Checked
                DBModule.attachDbPath = txtAttachDbPath.Text.Trim()
                DBModule.localDbInstanceName = "MSSQLLocalDB"

                ' تفعيل التشفير تلقائياً للسيرفرات السحابية والشبكية الخارجية
                Dim isRemote = Not String.IsNullOrEmpty(DBModule.server) AndAlso
                               Not DBModule.server.ToLower().Contains("(localdb)") AndAlso
                               Not DBModule.server.Equals("localhost", StringComparison.OrdinalIgnoreCase) AndAlso
                               Not DBModule.server.Equals(".", StringComparison.OrdinalIgnoreCase) AndAlso
                               Not DBModule.server.Equals(Environment.MachineName, StringComparison.OrdinalIgnoreCase)
                DBModule.encryptConnection = isRemote
                DBModule.trustServerCertificate = True

                ' التأكد من وجود مجلد قاعدة البيانات لو تم تفعيل AttachDb
                If DBModule.useAttachDb Then
                    LocalDbManager.EnsureDatabaseDirectoryExists(DBModule.database)
                End If

                DBModule.SaveDbSettings()

                ' تشغيل LocalDB لو كان هو المختار
                If _selectedEngineMode = "localdb" Then
                    Await LocalDbManager.EnsureInstanceRunningAsync("MSSQLLocalDB")
                End If

                If DBModule.TestConnection() Then
                    Try
                        Notify.Toast("تم حفظ إعدادات قاعدة البيانات وتم التحقق من الاتصال بنجاح ✅", Notify.ToastType.Success)
                    Catch
                        MessageBox.Show("✅ تم حفظ إعدادات قاعدة البيانات بنجاح والاتصال يعمل تماماً.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                    lblDbStatus.Text = "✅ تم الحفظ بنجاح والاتصال نشط"
                    lblDbStatus.ForeColor = Color.LightGreen
                    Dim loadTask = SafeLoadTableStatisticsAsync()
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

        ' ══════════════════════════════════════════════════════════════════════
        ' محرك الفحص والترقيع التلقائي (Self-Healing Engine UI Event Handlers)
        ' ══════════════════════════════════════════════════════════════════════

        Private Async Sub btnRunMaintenance_Click(sender As Object, e As EventArgs) Handles btnRunMaintenance.Click
            If _isBusy Then Return
            _isBusy = True
            SetBusyState(True)

            Try
                prgMaintenance.Value = 5
                lblMaintenanceProgress.Text = "بدء فحص وصيانة قاعدة البيانات..."
                txtMaintenanceLog.AppendText($"=== بدء عملية الفحص والترقيع: {DateTime.Now} ===" & vbCrLf)

                Dim srv = txtDbServer.Text.Trim()
                Dim db = txtDbName.Text.Trim()
                Dim usr = txtDbUser.Text.Trim()
                Dim pwd = txtDbPassword.Text
                Dim winAuth = chkWindowsAuth.Checked OrElse (_selectedEngineMode = "localdb")

                If _selectedEngineMode = "localdb" Then
                    Await LocalDbManager.EnsureInstanceRunningAsync("MSSQLLocalDB")
                End If

                Dim service As New DatabaseMaintenanceService(srv, db, usr, pwd, winAuth)

                Dim progressHandler As New Progress(Of MaintenanceProgress)(Sub(p)
                                                                                prgMaintenance.Value = Math.Max(0, Math.Min(100, p.Percentage))
                                                                                lblMaintenanceProgress.Text = $"{p.CurrentStep}: {p.Message}"
                                                                            End Sub)

                Dim report = Await service.CheckAndRepairDatabaseAsync(progressHandler)

                txtMaintenanceLog.AppendText(report.ToString() & vbCrLf)
                txtMaintenanceLog.SelectionStart = txtMaintenanceLog.TextLength
                txtMaintenanceLog.ScrollToCaret()

                If report.IsSuccess Then
                    prgMaintenance.Value = 100
                    lblMaintenanceProgress.Text = "✅ اكتمل الفحص والإصلاح بنجاح!"

                    Dim summaryMsg = $"اكتمل فحص وصيانة قاعدة البيانات بنجاح في {report.ExecutionTime.TotalSeconds:F2} ثانية." & vbCrLf &
                                     $"• الجداول المنشأة: {report.TablesCreated.Count}" & vbCrLf &
                                     $"• الأعمدة المضافة: {report.ColumnsAdded.Count}"

                    Try
                        Notify.Toast("تم فحص وصيانة هيكل قاعدة البيانات بنجاح ✅", Notify.ToastType.Success)
                    Catch
                    End Try

                    MessageBox.Show(summaryMsg, "تقرير الصيانة الذاتية", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    lblMaintenanceProgress.Text = "❌ حدثت أخطاء أثناء الصيانة."
                    MessageBox.Show("حدثت بعض الأخطاء أثناء فحص أو ترقيع قاعدة البيانات، يرجى مراجعة سجل العمليات أدناه.",
                                    "تنبيه الصيانة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                Await SafeLoadTableStatisticsAsync()

            Catch ex As Exception
                txtMaintenanceLog.AppendText($"❌ خطأ غير متوقع: {ex.Message}" & vbCrLf)
                MessageBox.Show("خطأ أثناء الفحص: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _isBusy = False
                SetBusyState(False)
            End Try
        End Sub

        Private Sub btnClearLog_Click(sender As Object, e As EventArgs) Handles btnClearLog.Click
            txtMaintenanceLog.Clear()
            lblMaintenanceProgress.Text = "تم تفريغ سجل العمليات."
            prgMaintenance.Value = 0
        End Sub

        Private Sub SetBusyState(busy As Boolean)
            btnRunMaintenance.Enabled = Not busy
            btnClearLog.Enabled = Not busy
            btnResetTransactional.Enabled = Not busy
            btnRefreshStats.Enabled = Not busy
            btnSaveDbSettings.Enabled = Not busy
            btnTestDbConnection.Enabled = Not busy
            btnDetectServers.Enabled = Not busy
            btnSelectLocalDb.Enabled = Not busy
            btnSelectServer.Enabled = Not busy
            btnStartLocalDb.Enabled = Not busy
            btnStopLocalDb.Enabled = Not busy
            btnCheckLocalDb.Enabled = Not busy
            btnInstallLocalDb.Enabled = Not busy
            dgvTables.Enabled = Not busy
        End Sub

        ' ══════════════════════════════════════════════════════════════════════
        ' إدارة وتصفير الجداول (Table Reset & Identity Reseed UI Handlers)
        ' ══════════════════════════════════════════════════════════════════════

        Private Async Sub btnRefreshStats_Click(sender As Object, e As EventArgs) Handles btnRefreshStats.Click
            Await SafeLoadTableStatisticsAsync()
        End Sub

        Private Async Function SafeLoadTableStatisticsAsync() As Task
            Try
                If Me.IsDisposed OrElse Me.Disposing OrElse dgvTables Is Nothing OrElse dgvTables.IsDisposed Then Return

                Dim srv = txtDbServer.Text.Trim()
                Dim db = txtDbName.Text.Trim()
                Dim usr = txtDbUser.Text.Trim()
                Dim pwd = txtDbPassword.Text
                Dim winAuth = chkWindowsAuth.Checked OrElse (_selectedEngineMode = "localdb")

                If String.IsNullOrEmpty(srv) OrElse String.IsNullOrEmpty(db) Then Return

                Dim service As New DatabaseMaintenanceService(srv, db, usr, pwd, winAuth)
                Dim stats = Await service.GetTableStatisticsAsync()

                If Me.IsDisposed OrElse Me.Disposing OrElse dgvTables Is Nothing OrElse dgvTables.IsDisposed Then Return

                dgvTables.Rows.Clear()
                For Each item In stats
                    Dim typeStr = If(item.IsTransactional, "حركي / دوري", "أساسي / مرجعي")
                    Dim countStr = If(item.ExistsInDb, item.RecordCount.ToString("N0"), "غير موجود")
                    Dim rowIdx = dgvTables.Rows.Add(item.TableName, item.DisplayNameAr, typeStr, countStr)

                    If Not item.ExistsInDb Then
                        dgvTables.Rows(rowIdx).DefaultCellStyle.ForeColor = Color.Gray
                    ElseIf item.IsTransactional Then
                        dgvTables.Rows(rowIdx).Cells("colType").Style.ForeColor = Color.FromArgb(239, 68, 68)
                    End If
                Next
            Catch ex As Exception
                Debug.WriteLine("SafeLoadTableStatisticsAsync error: " & ex.Message)
            End Try
        End Function

        Private Async Sub btnResetTransactional_Click(sender As Object, e As EventArgs) Handles btnResetTransactional.Click
            If _isBusy Then Return

            Dim confirm = MessageBox.Show("⚠️ تحذير شديد الأهمية:" & vbCrLf & vbCrLf &
                                          "سيتم تفريغ كافة حركات فواتير المبيعات، المشتريات، المصروفات، الورديات، وسجلات الخزينة بالكامل، وتصفير عدادات الترقيم التلقائي إلى 0." & vbCrLf & vbCrLf &
                                          "ملاحظة: البيانات الأساسية (الأصناف، العملاء، الموردين، المستخدمين، الإعدادات) لن تتأثر أبداً." & vbCrLf & vbCrLf &
                                          "هل أنت متأكد تماماً من رغبتك في المتابعة؟",
                                          "تأكيد تفريغ حركات النظام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm <> DialogResult.Yes Then Return

            _isBusy = True
            SetBusyState(True)

            Try
                prgMaintenance.Value = 10
                lblMaintenanceProgress.Text = "جارٍ تفريغ حركات المعاملات وتصفير العدادات..."
                txtMaintenanceLog.AppendText($"=== بدء تصفير جداول المعاملات: {DateTime.Now} ===" & vbCrLf)

                Dim winAuth = chkWindowsAuth.Checked OrElse (_selectedEngineMode = "localdb")
                Dim service As New DatabaseMaintenanceService(txtDbServer.Text.Trim(), txtDbName.Text.Trim(),
                                                              txtDbUser.Text.Trim(), txtDbPassword.Text, winAuth)

                Dim progressHandler As New Progress(Of MaintenanceProgress)(Sub(p)
                                                                               prgMaintenance.Value = Math.Max(0, Math.Min(100, p.Percentage))
                                                                               lblMaintenanceProgress.Text = $"{p.CurrentStep}: {p.Message}"
                                                                           End Sub)

                Dim report = Await service.ResetTransactionalDataAsync(progressHandler)

                txtMaintenanceLog.AppendText(report.ToString() & vbCrLf)
                txtMaintenanceLog.SelectionStart = txtMaintenanceLog.TextLength
                txtMaintenanceLog.ScrollToCaret()

                If report.IsSuccess Then
                    prgMaintenance.Value = 100
                    lblMaintenanceProgress.Text = "✅ تم تصفير كافة حركات المعاملات بنجاح!"
                    Try
                        Notify.Toast("تم تصفير حركات المبيعات والمشتريات وتصفير العدادات بنجاح 🧹", Notify.ToastType.Success)
                    Catch
                    End Try
                    MessageBox.Show("تم تفريغ جداول المعاملات وتصفير عدادات الهوية بنجاح.", "تمت التهيئة", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("حدثت بعض الأخطاء أثناء تفريغ الجداول، راجع سجل العمليات للتفاصيل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                Await SafeLoadTableStatisticsAsync()

            Catch ex As Exception
                MessageBox.Show("خطأ أثناء التهيئة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _isBusy = False
                SetBusyState(False)
            End Try
        End Sub

        Private Async Sub dgvTables_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTables.CellContentClick
            If e.RowIndex < 0 OrElse e.ColumnIndex <> dgvTables.Columns("colResetAction").Index Then Return
            If _isBusy Then Return

            Dim tableName = dgvTables.Rows(e.RowIndex).Cells("colTableName").Value?.ToString()
            Dim displayName = dgvTables.Rows(e.RowIndex).Cells("colDisplayName").Value?.ToString()

            If String.IsNullOrEmpty(tableName) Then Return

            Dim prompt = $"هل أنت متأكد تماماً من رغبتك في تفريغ جدول [{displayName} ({tableName})] وحذف كافة سجلاته وتصفير العداد التلقائي (Identity Reseed)؟" & vbCrLf & vbCrLf &
                         "⚠️ لا يمكن التراجع عن هذه العملية بعد تنفيذها!"

            Dim confirm = MessageBox.Show(prompt, $"تأكيد تهيئة جدول {displayName}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm <> DialogResult.Yes Then Return

            _isBusy = True
            SetBusyState(True)

            Try
                lblMaintenanceProgress.Text = $"جارٍ تهيئة جدول [{tableName}]..."
                Dim winAuth = chkWindowsAuth.Checked OrElse (_selectedEngineMode = "localdb")
                Dim service As New DatabaseMaintenanceService(txtDbServer.Text.Trim(), txtDbName.Text.Trim(),
                                                              txtDbUser.Text.Trim(), txtDbPassword.Text, winAuth)

                Dim success = Await service.ResetTableDataAsync(tableName)
                If success Then
                    txtMaintenanceLog.AppendText($"[{DateTime.Now:HH:mm:ss}] ✅ تم تفريغ جدول [{tableName}] وتصفير عداده بنجاح." & vbCrLf)
                    lblMaintenanceProgress.Text = $"✅ تم إفراغ جدول [{displayName}] وتصفير العداد بنجاح."

                    Try
                        Notify.Toast($"تم تفريغ جدول {displayName} بنجاح ✅", Notify.ToastType.Success)
                    Catch
                    End Try

                    dgvTables.Rows(e.RowIndex).Cells("colRecordCount").Value = "0"
                    Await SafeLoadTableStatisticsAsync()
                End If
            Catch ex As Exception
                txtMaintenanceLog.AppendText($"[{DateTime.Now:HH:mm:ss}] ❌ فشل تفريغ جدول [{tableName}]: {ex.Message}" & vbCrLf)
                MessageBox.Show($"تعذر تفريغ جدول {displayName}: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _isBusy = False
                SetBusyState(False)
            End Try
        End Sub

    End Class
End Namespace
