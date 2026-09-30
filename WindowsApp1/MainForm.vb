Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports WindowsApp1.FrmTreasuryTransaction

Public Class MainForm

    Private _isLoggingOut As Boolean = False
    Private _ucDashboard As UC_Main.UCDashboard = Nothing
    Private _ucSales As UC_Main.UCSalesHub = Nothing
    Private _ucSystem As UC_Main.UCSystemHub = Nothing
    Private _ucInventory As UC_Main.UCInventoryHub = Nothing
    Private _ucPurchases As UC_Main.UCPurchasesHub = Nothing
    Private _ucCustomers As UC_Main.UCCustomersHub = Nothing
    Private _ucSuppliers As UC_Main.UCSuppliersHub = Nothing
    Private _ucTreasury As UC_Main.UCTreasuryHub = Nothing
    Private _ucExpenses As UC_Main.UCExpensesHub = Nothing
    Private _ucEmployees As UC_Main.UCEmployeesHub = Nothing
    Private _ucUsers As UC_Main.UCUsersHub = Nothing
    Private _ucSettings As UC_Main.UCSettingsHub = Nothing

    Private Sub OpenFormDirectly(formType As Type)
        OpenFormOnce(formType, CType(Nothing, Control))
    End Sub

    Public Function GetDashboardControl() As UC_Main.UCDashboard
        If _ucDashboard Is Nothing Then
            _ucDashboard = New UC_Main.UCDashboard()
            _ucDashboard.Dock = DockStyle.Fill
            AddHandler _ucDashboard.OpenSalesRequested, Sub() OpenFormDirectly(GetType(frmPOS))
            AddHandler _ucDashboard.OpenProductsRequested, Sub() OpenFormDirectly(GetType(Products))
            AddHandler _ucDashboard.OpenCustomersRequested, Sub() OpenFormDirectly(GetType(FrmCustomers))
            AddHandler _ucDashboard.OpenBackupsRequested, Sub() OpenFormDirectly(GetType(Backup))
            AddHandler _ucDashboard.OpenSalesReportRequested, Sub() OpenFormDirectly(GetType(FrmSalesReport))
            AddHandler _ucDashboard.OpenPurchaseReportsRequested, Sub() OpenFormDirectly(GetType(frmPurchaseReports))
            AddHandler _ucDashboard.OpenTreasuryReportRequested, Sub() OpenFormDirectly(GetType(FrmTreasuryTransactionsReport))
            AddHandler _ucDashboard.OpenSuppliersRequested, Sub() OpenFormDirectly(GetType(FrmSuppliers))
            AddHandler _ucDashboard.OpenStoreStockRequested, Sub() OpenFormDirectly(GetType(frmStoreStock))
            AddHandler _ucDashboard.OpenShiftsRequested, Sub() OpenFormDirectly(GetType(frmShifts))
            pnlMainContainer.Controls.Add(_ucDashboard)
            _ucDashboard.ApplyDashboardTheme()
            _ucDashboard.ApplyPermissions()
        End If
        Return _ucDashboard
    End Function

    Public Function GetSalesControl() As UC_Main.UCSalesHub
        If _ucSales Is Nothing Then
            _ucSales = New UC_Main.UCSalesHub()
            _ucSales.Dock = DockStyle.Fill
            AddHandler _ucSales.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucSales)
            _ucSales.ApplyTheme()
            _ucSales.ApplyPermissions()
        End If
        Return _ucSales
    End Function

    Public Function GetSystemControl() As UC_Main.UCSystemHub
        If _ucSystem Is Nothing Then
            _ucSystem = New UC_Main.UCSystemHub()
            _ucSystem.Dock = DockStyle.Fill
            AddHandler _ucSystem.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucSystem)
            _ucSystem.ApplyTheme()
            _ucSystem.ApplyPermissions()
        End If
        Return _ucSystem
    End Function

    Public Function GetInventoryControl() As UC_Main.UCInventoryHub
        If _ucInventory Is Nothing Then
            _ucInventory = New UC_Main.UCInventoryHub()
            _ucInventory.Dock = DockStyle.Fill
            AddHandler _ucInventory.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucInventory)
            _ucInventory.ApplyTheme()
            _ucInventory.ApplyPermissions()
        End If
        Return _ucInventory
    End Function

    Public Function GetPurchasesControl() As UC_Main.UCPurchasesHub
        If _ucPurchases Is Nothing Then
            _ucPurchases = New UC_Main.UCPurchasesHub()
            _ucPurchases.Dock = DockStyle.Fill
            AddHandler _ucPurchases.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucPurchases)
            _ucPurchases.ApplyTheme()
            _ucPurchases.ApplyPermissions()
        End If
        Return _ucPurchases
    End Function

    Public Function GetCustomersControl() As UC_Main.UCCustomersHub
        If _ucCustomers Is Nothing Then
            _ucCustomers = New UC_Main.UCCustomersHub()
            _ucCustomers.Dock = DockStyle.Fill
            AddHandler _ucCustomers.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucCustomers)
            _ucCustomers.ApplyTheme()
            _ucCustomers.ApplyPermissions()
        End If
        Return _ucCustomers
    End Function

    Public Function GetSuppliersControl() As UC_Main.UCSuppliersHub
        If _ucSuppliers Is Nothing Then
            _ucSuppliers = New UC_Main.UCSuppliersHub()
            _ucSuppliers.Dock = DockStyle.Fill
            AddHandler _ucSuppliers.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucSuppliers)
            _ucSuppliers.ApplyTheme()
            _ucSuppliers.ApplyPermissions()
        End If
        Return _ucSuppliers
    End Function

    Public Function GetTreasuryControl() As UC_Main.UCTreasuryHub
        If _ucTreasury Is Nothing Then
            _ucTreasury = New UC_Main.UCTreasuryHub()
            _ucTreasury.Dock = DockStyle.Fill
            AddHandler _ucTreasury.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucTreasury)
            _ucTreasury.ApplyTheme()
            _ucTreasury.ApplyPermissions()
        End If
        Return _ucTreasury
    End Function

    Public Function GetExpensesControl() As UC_Main.UCExpensesHub
        If _ucExpenses Is Nothing Then
            _ucExpenses = New UC_Main.UCExpensesHub()
            _ucExpenses.Dock = DockStyle.Fill
            AddHandler _ucExpenses.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucExpenses)
            _ucExpenses.ApplyTheme()
            _ucExpenses.ApplyPermissions()
        End If
        Return _ucExpenses
    End Function

    Public Function GetEmployeesControl() As UC_Main.UCEmployeesHub
        If _ucEmployees Is Nothing Then
            _ucEmployees = New UC_Main.UCEmployeesHub()
            _ucEmployees.Dock = DockStyle.Fill
            AddHandler _ucEmployees.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucEmployees)
            _ucEmployees.ApplyTheme()
            _ucEmployees.ApplyPermissions()
        End If
        Return _ucEmployees
    End Function

    Public Function GetUsersControl() As UC_Main.UCUsersHub
        If _ucUsers Is Nothing Then
            _ucUsers = New UC_Main.UCUsersHub()
            _ucUsers.Dock = DockStyle.Fill
            AddHandler _ucUsers.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucUsers)
            _ucUsers.ApplyTheme()
            _ucUsers.ApplyPermissions()
        End If
        Return _ucUsers
    End Function

    Public Function GetSettingsControl() As UC_Main.UCSettingsHub
        If _ucSettings Is Nothing Then
            _ucSettings = New UC_Main.UCSettingsHub()
            _ucSettings.Dock = DockStyle.Fill
            AddHandler _ucSettings.BackRequested, Sub(s, e) SetActiveNav(navDashboard, GetDashboardControl())
            pnlMainContainer.Controls.Add(_ucSettings)
            _ucSettings.ApplyTheme()
            _ucSettings.ApplyPermissions()
        End If
        Return _ucSettings
    End Function

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Application.Exit()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
        Drag = New FormDragHelper(Me, lbltitle)

        ' تهيئة شريط الحالة وبيانات الجلسة
        InitializeStatusBar()

        ' تعيين الشاشة النشطة الافتراضية
        SetActiveNav(navDashboard, GetDashboardControl())

        ' تطبيق ثيم MainForm المتوافق مع الهوية الأصلية
        ApplyMainFormTheme()
        AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged

        ' تطبيق قيود الصلاحيات على أزرار الشاشة الرئيسية
        ApplyPermissionsToMainForm()

        ' بدء تشغيل مؤقتات الساعة وتحديث الداشبورد
        tmrClock.Interval = 1000
        tmrClock.Start()

        ' مؤقت التحديث التلقائي للداشبورد (كل 3 دقائق = 180,000 مللي ثانية بدون وميض الزر)
        tmrDashboardRefresh.Interval = 180000
        tmrDashboardRefresh.Start()

        ' بدء خدمة القفل التلقائي للجلسة عند الخمول في الخلفية (أداء فائق وخفيف تماماً)
        WindowsApp1.Services.SessionLockService.Instance.StartMonitoring(Me)

        ' استمرار مزامنة المستخدمين التلقائية في الخلفية
        WindowsApp1.Services.Sync.UserSyncService.StartBackgroundSync(25)

        ' بدء فحص التحديثات التلقائية في الخلفية بدون أي تأثير على الأداء نهائياً (كل 3 دقائق مع تأخير إقلاع 30 ثانية)
        WindowsApp1.Services.Updates.BackgroundUpdateService.StartMonitoring(3)

        ' إعداد التلميح لأزرار الهيدر
        Try
            Dim tip As New ToolTip()
            tip.SetToolTip(btnLogout, "تسجيل الخروج من النظام وإغلاق كافة الشاشات المفتوحة (Ctrl+Q)")
            tip.SetToolTip(btnSupport, "فتح صفحة الدعم الفني على موقع سستمك الرسمي (https://sestamk.site.je/contact)")
            tip.SetToolTip(txtGlobalSearch, "البحث السريع في كافة شاشات ووظائف النظام (Ctrl+K)")
        Catch
        End Try

        ' تحميل بيانات الداشبورد فور فتح الشاشة بهدوء
        RefreshDashboardAsync(isManual:=False)
    End Sub

    Private Sub InitializeStatusBar()
        Try
            Dim displayName As String = If(Not String.IsNullOrEmpty(Session.CurrentUserfullName), Session.CurrentUserfullName, Session.CurrentUserName)
            Dim userTitle As String = If(String.IsNullOrEmpty(displayName), "المدير العام", displayName)
            Dim roleTitle As String = If(Session.CurrentRoleID = 1, "مدير النظام", "مستخدم نظام")
            lblStatusUser.Text = "المستخدم: " & userTitle
            lblStatusRole.Text = "الصلاحية: " & roleTitle
            If lblStatusUserRole IsNot Nothing Then
                lblStatusUserRole.Text = userTitle & " (" & roleTitle & ")"
            End If

            Dim branchName As String = "الفرع الرئيسي"
            Try
                Dim dtBranch As DataTable = DBModule.ExecuteQuery("SELECT TOP 1 BranchName FROM Branches WHERE IsActive = 1")
                If dtBranch IsNot Nothing AndAlso dtBranch.Rows.Count > 0 Then
                    branchName = dtBranch.Rows(0)("BranchName").ToString()
                End If
            Catch
            End Try
            lblStatusBranch.Text = "الفرع: " & branchName
            If lblHeaderBranch IsNot Nothing Then
                lblHeaderBranch.Text = "الفرع: " & branchName
            End If

            UpdateDateTimeAndShift()
        Catch ex As Exception
            Logger.LogError("InitializeStatusBar", ex)
        End Try
    End Sub

    Private Sub UpdateDateTimeAndShift()
        Try
            Dim nowTime As DateTime = DateTime.Now
            lblStatusDateTime.Text = nowTime.ToString("dddd, dd MMMM yyyy - hh:mm:ss tt")

            ' مدة الوردية النشطة لشريط الحالة السفلي
            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                Dim shiftDuration As TimeSpan = nowTime - ShiftSession.CurrentShift.OpenDateTime
                Dim durationStr As String = String.Format("{0:D2}:{1:D2}:{2:D2}", CInt(Math.Floor(shiftDuration.TotalHours)), shiftDuration.Minutes, shiftDuration.Seconds)
                lblStatusShift.Text = "الوردية #" & ShiftSession.CurrentShift.ShiftNumber & " (" & durationStr & ")"
            Else
                lblStatusShift.Text = "الوردية: لا توجد وردية نشطة"
            End If

            If _ucDashboard IsNot Nothing Then
                _ucDashboard.UpdateDateTimeAndShift()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        UpdateDateTimeAndShift()
    End Sub

    Private Sub tmrDashboardRefresh_Tick(sender As Object, e As EventArgs) Handles tmrDashboardRefresh.Tick
        ' التحديث التلقائي الدوري في الخلفية (صامت تماماً وفقط إذا كانت شاشة الداشبورد معروضة حالياً)
        If _ucDashboard IsNot Nothing AndAlso _ucDashboard.Visible Then
            _ucDashboard.RefreshDashboardAsync(isManual:=False)
        End If
    End Sub

    ''' <summary>
    ''' جلب وتحديث مؤشرات الداشبورد في الخلفية بشكل غير تزامني
    ''' </summary>
    Public Sub RefreshDashboardAsync(Optional isManual As Boolean = False)
        If _ucDashboard IsNot Nothing Then
            _ucDashboard.RefreshDashboardAsync(isManual)
        Else
            GetDashboardControl().RefreshDashboardAsync(isManual)
        End If
    End Sub



    ''' <summary>
    ''' التبديل السلس بين شاشات وأقسام النظام بالسايدبار وتحديث المظهر
    ''' </summary>
    Private Sub SetActiveNav(activeBtn As Guna.UI2.WinForms.Guna2Button, targetView As Control)
        Dim pal = ThemeManager.Instance.CurrentPalette
        Dim selColor As Color = If(pal IsNot Nothing, pal.NavSelected, Color.FromArgb(37, 99, 235))
        Dim selTextColor As Color = If(pal IsNot Nothing, pal.NavSelectedText, Color.White)
        Dim normalTextColor As Color = If(pal IsNot Nothing, pal.NavText, Color.FromArgb(209, 213, 219))

        Dim navButtons() As Guna.UI2.WinForms.Guna2Button = {navDashboard, navSales, navSystem, navInventory, navPurchases, navCustomers, navSuppliers, navTreasury, navExpenses, navEmployees, navUsers, navSettings}
        For Each btn In navButtons
            If btn IsNot Nothing Then
                btn.Checked = False
                btn.FillColor = Color.Transparent
                btn.ForeColor = normalTextColor
            End If
        Next

        If activeBtn IsNot Nothing Then
            activeBtn.Checked = True
            activeBtn.FillColor = selColor
            activeBtn.ForeColor = selTextColor
        End If

        Dim allViews() As Control = {_ucDashboard, _ucSales, _ucSystem, _ucInventory, _ucPurchases, _ucCustomers, _ucSuppliers, _ucTreasury, _ucExpenses, _ucEmployees, _ucUsers, _ucSettings}
        For Each v In allViews
            If v IsNot Nothing AndAlso v IsNot targetView Then
                v.Visible = False
            End If
        Next

        If targetView IsNot Nothing Then
            targetView.Visible = True
            targetView.BringToFront()
        End If
    End Sub

    Private Sub navDashboard_Click(sender As Object, e As EventArgs) Handles navDashboard.Click
        SetActiveNav(navDashboard, GetDashboardControl())
        GetDashboardControl().RefreshDashboardAsync(isManual:=False)
    End Sub

    Private Sub navSales_Click(sender As Object, e As EventArgs) Handles navSales.Click
        SetActiveNav(navSales, GetSalesControl())
    End Sub

    Private Sub navSystem_Click(sender As Object, e As EventArgs) Handles navSystem.Click
        SetActiveNav(navSystem, GetSystemControl())
    End Sub

    Private Sub navInventory_Click(sender As Object, e As EventArgs) Handles navInventory.Click
        SetActiveNav(navInventory, GetInventoryControl())
    End Sub

    Private Sub navPurchases_Click(sender As Object, e As EventArgs) Handles navPurchases.Click
        SetActiveNav(navPurchases, GetPurchasesControl())
    End Sub

    Private Sub navCustomers_Click(sender As Object, e As EventArgs) Handles navCustomers.Click
        SetActiveNav(navCustomers, GetCustomersControl())
    End Sub

    Private Sub navSuppliers_Click(sender As Object, e As EventArgs) Handles navSuppliers.Click
        SetActiveNav(navSuppliers, GetSuppliersControl())
    End Sub

    Private Sub navTreasury_Click(sender As Object, e As EventArgs) Handles navTreasury.Click
        SetActiveNav(navTreasury, GetTreasuryControl())
    End Sub

    Private Sub navExpenses_Click(sender As Object, e As EventArgs) Handles navExpenses.Click
        SetActiveNav(navExpenses, GetExpensesControl())
    End Sub

    Private Sub navEmployees_Click(sender As Object, e As EventArgs) Handles navEmployees.Click
        SetActiveNav(navEmployees, GetEmployeesControl())
    End Sub

    Private Sub navUsers_Click(sender As Object, e As EventArgs) Handles navUsers.Click
        SetActiveNav(navUsers, GetUsersControl())
    End Sub

    Private Sub navSettings_Click(sender As Object, e As EventArgs) Handles navSettings.Click
        SetActiveNav(navSettings, GetSettingsControl())
    End Sub

    Private Sub txtGlobalSearch_TextChanged(sender As Object, e As EventArgs) Handles txtGlobalSearch.TextChanged
        Dim term As String = txtGlobalSearch.Text.Trim().ToLower()
        If String.IsNullOrWhiteSpace(term) Then Return

        If term.Contains("بيع") OrElse term.Contains("pos") OrElse term.Contains("كاشير") OrElse term.Contains("مطبخ") OrElse term.Contains("kds") OrElse term.Contains("هالك") OrElse term.Contains("طاول") OrElse term.Contains("مرتجع") Then
            SetActiveNav(navSales, GetSalesControl())
        ElseIf term.Contains("صنف") OrElse term.Contains("فئة") OrElse term.Contains("منيو") OrElse term.Contains("وردية") OrElse term.Contains("فرع") OrElse term.Contains("طيار") OrElse term.Contains("توصيل") Then
            SetActiveNav(navSystem, GetSystemControl())
        ElseIf term.Contains("مخزن") OrElse term.Contains("خام") OrElse term.Contains("ريسيبي") OrElse term.Contains("مخزون") OrElse term.Contains("وحد") Then
            SetActiveNav(navInventory, GetInventoryControl())
        ElseIf term.Contains("شراء") OrElse term.Contains("مشتريات") OrElse term.Contains("توريد") Then
            SetActiveNav(navPurchases, GetPurchasesControl())
        ElseIf term.Contains("عميل") OrElse term.Contains("عملاء") OrElse term.Contains("دين") Then
            SetActiveNav(navCustomers, GetCustomersControl())
        ElseIf term.Contains("مورد") OrElse term.Contains("موردين") Then
            SetActiveNav(navSuppliers, GetSuppliersControl())
        ElseIf term.Contains("خزن") OrElse term.Contains("خزينة") OrElse term.Contains("سحب") OrElse term.Contains("إيداع") OrElse term.Contains("ايداع") Then
            SetActiveNav(navTreasury, GetTreasuryControl())
        ElseIf term.Contains("مصروف") OrElse term.Contains("مصاريف") OrElse term.Contains("نثريات") Then
            SetActiveNav(navExpenses, GetExpensesControl())
        ElseIf term.Contains("موظف") OrElse term.Contains("راتب") OrElse term.Contains("رواتب") OrElse term.Contains("سلف") OrElse term.Contains("مرتب") Then
            SetActiveNav(navEmployees, GetEmployeesControl())
        ElseIf term.Contains("مستخدم") OrElse term.Contains("صلاحي") OrElse term.Contains("دور") OrElse term.Contains("كلمة سر") Then
            SetActiveNav(navUsers, GetUsersControl())
        ElseIf term.Contains("طابع") OrElse term.Contains("نسخ") OrElse term.Contains("إعداد") OrElse term.Contains("اعداد") OrElse term.Contains("ألوان") Then
            SetActiveNav(navSettings, GetSettingsControl())
        End If
    End Sub

    Private Sub txtGlobalSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGlobalSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            Dim term As String = txtGlobalSearch.Text.Trim().ToLower()
            If term.Contains("بيع") OrElse term.Contains("pos") OrElse term.Contains("كاشير") Then
                OpenFormDirectly(GetType(frmPOS))
            ElseIf term.Contains("مطبخ") OrElse term.Contains("kds") Then
                OpenFormDirectly(GetType(FrmKitchenDisplay))
            ElseIf term.Contains("صنف") OrElse term.Contains("منتج") Then
                OpenFormDirectly(GetType(Products))
            ElseIf term.Contains("خزينة") OrElse term.Contains("خزن") Then
                OpenFormDirectly(GetType(frmTreasury))
            ElseIf term.Contains("ايداع") OrElse term.Contains("إيداع") Then
                OpenTreasuryTransaction(FrmTreasuryTransaction.TreasuryOperation.Deposit)
            ElseIf term.Contains("سحب") Then
                OpenTreasuryTransaction(FrmTreasuryTransaction.TreasuryOperation.Withdraw)
            ElseIf term.Contains("عميل") Then
                OpenFormDirectly(GetType(FrmCustomers))
            ElseIf term.Contains("مورد") Then
                OpenFormDirectly(GetType(FrmSuppliers))
            ElseIf term.Contains("شراء") OrElse term.Contains("مشتريات") Then
                OpenFormDirectly(GetType(frmPurchases))
            ElseIf term.Contains("مصروف") Then
                OpenFormDirectly(GetType(form_Expenses))
            ElseIf term.Contains("موظف") Then
                OpenFormDirectly(GetType(frmEmployees))
            ElseIf term.Contains("طابع") Then
                OpenFormDirectly(GetType(frmPrinters))
            ElseIf term.Contains("نسخ") Then
                OpenFormDirectly(GetType(Backup))
            ElseIf term.Contains("اعداد") OrElse term.Contains("إعداد") Then
                OpenFormDirectly(GetType(Settings))
            End If
        End If
    End Sub

    Private Sub OpenTreasuryTransaction(op As FrmTreasuryTransaction.TreasuryOperation)
        If Not Session.HasPermission("FrmTreasuryTransaction", "CanOpen") Then
            Dim dispName As String = Session.GetScreenDisplayName("FrmTreasuryTransaction")
            MessageBox.Show("عفواً، ليس لديك صلاحية لفتح شاشة (" & dispName & ")!", "صلاحيات الوصول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim frm As New FrmTreasuryTransaction(op)
        AddHandler frm.Load, Sub(s, ev)
                                 Session.ApplyFormPermissions(frm, "FrmTreasuryTransaction")
                                 ThemeManager.Instance.ApplyTheme(frm)
                             End Sub
        AddHandler frm.Shown, Sub(s, ev)
                                  Session.ApplyFormPermissions(frm, "FrmTreasuryTransaction")
                                  ThemeManager.Instance.ApplyTheme(frm)
                              End Sub
        ThemeManager.Instance.ApplyTheme(frm)
        frm.Show()
    End Sub

    Public Sub ApplyMainFormTheme()
        Try
            Dim pal = ThemeManager.Instance.CurrentPalette

            ' خلفية الفورم والحاويات الرئيسية
            Me.BackColor = pal.Background
            pnlMainContainer.BackColor = pal.Background

            ' الهيدر يظل داكناً بالهوية الأصلية
            panelHeader.FillColor = pal.SurfaceHeader
            pnlSidebar.FillColor = pal.SurfaceHeader
            lbltitle.BackColor = Color.Transparent
            lbltitle.ForeColor = pal.TextOnDark
            If lblHeaderBranch IsNot Nothing Then
                lblHeaderBranch.BackColor = Color.Transparent
                lblHeaderBranch.ForeColor = Color.FromArgb(203, 213, 225)
            End If
            If lblStatusUserRole IsNot Nothing Then
                lblStatusUserRole.BackColor = Color.Transparent
                lblStatusUserRole.ForeColor = Color.FromArgb(147, 197, 253)
            End If
            If picLogo IsNot Nothing Then picLogo.BackColor = Color.Transparent

            ' أزرار التحكم بالنافذة
            btn_min.FillColor = Color.Transparent
            btn_min.ForeColor = pal.TextOnDark
            btn_max.FillColor = Color.Transparent
            btn_max.ForeColor = pal.TextOnDark
            btn_close.FillColor = Color.Transparent
            btn_close.ForeColor = pal.TextOnDark

            btnLogout.FillColor = pal.ButtonSecondaryBackground
            btnLogout.ForeColor = pal.ButtonSecondaryForeground
            btnLogout.BorderColor = pal.Border
            btnSupport.FillColor = pal.ButtonSecondaryBackground
            btnSupport.ForeColor = pal.ButtonSecondaryForeground
            btnSupport.BorderColor = pal.Border

            ' شريط البحث في الهيدر متناسق مع الهيدر الداكن
            txtGlobalSearch.FillColor = Color.FromArgb(23, 30, 44)
            txtGlobalSearch.ForeColor = Color.White
            txtGlobalSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184)
            txtGlobalSearch.BorderColor = Color.FromArgb(38, 51, 72)

            ' تطبيق ثيم شاشة الداشبورد المستقلة
            If _ucDashboard IsNot Nothing Then
                _ucDashboard.ApplyDashboardTheme()
            End If

            If _ucSales IsNot Nothing Then _ucSales.ApplyTheme()
            If _ucSystem IsNot Nothing Then _ucSystem.ApplyTheme()
            If _ucInventory IsNot Nothing Then _ucInventory.ApplyTheme()
            If _ucPurchases IsNot Nothing Then _ucPurchases.ApplyTheme()
            If _ucCustomers IsNot Nothing Then _ucCustomers.ApplyTheme()
            If _ucSuppliers IsNot Nothing Then _ucSuppliers.ApplyTheme()
            If _ucTreasury IsNot Nothing Then _ucTreasury.ApplyTheme()
            If _ucExpenses IsNot Nothing Then _ucExpenses.ApplyTheme()
            If _ucEmployees IsNot Nothing Then _ucEmployees.ApplyTheme()
            If _ucUsers IsNot Nothing Then _ucUsers.ApplyTheme()
            If _ucSettings IsNot Nothing Then _ucSettings.ApplyTheme()

            ' زر تسجيل الخروج الاحترافي في الهيدر
            If btnLogout IsNot Nothing Then
                btnLogout.BorderRadius = 8
                btnLogout.BorderThickness = 1
                btnLogout.FillColor = pal.DangerSubtleBackground
                btnLogout.ForeColor = pal.DangerSubtleForeground
                btnLogout.BorderColor = pal.DangerSubtleBorder
                btnLogout.HoverState.FillColor = pal.Danger
                btnLogout.HoverState.ForeColor = Color.White
                btnLogout.HoverState.BorderColor = pal.Danger
            End If

            ' زر الدعم الفني في الهيدر
            If btnSupport IsNot Nothing Then
                btnSupport.BorderRadius = 8
                btnSupport.BorderThickness = 1
                btnSupport.FillColor = pal.InfoSubtleBackground
                btnSupport.ForeColor = pal.InfoSubtleForeground
                btnSupport.BorderColor = pal.InfoSubtleBorder
                btnSupport.HoverState.FillColor = pal.Info
                btnSupport.HoverState.ForeColor = Color.White
                btnSupport.HoverState.BorderColor = pal.Info
            End If

            ' شريط الحالة السفلي
            statusStripMain.BackColor = pal.SurfaceHeader
            statusStripMain.ForeColor = pal.TextOnDark
            For Each item As ToolStripItem In statusStripMain.Items
                item.ForeColor = pal.TextOnDark
            Next

        Catch ex As Exception
            Logger.LogError("ApplyMainFormTheme", ex)
        End Try
    End Sub

    Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
        If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return
        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf ApplyMainFormTheme))
        Else
            ApplyMainFormTheme()
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        PerformLogout()
    End Sub

    Private Sub btnSupport_Click(sender As Object, e As EventArgs) Handles btnSupport.Click
        WebLinks.OpenContact()
    End Sub

    ''' <summary>
    ''' تسجيل خروج فوري واحترافي: إغلاق كافة الشاشات المفتوحة والعودة لشاشة تسجيل الدخول مباشرة
    ''' </summary>
    Public Sub PerformLogout(Optional isAuto As Boolean = False)
        Try
            _isLoggingOut = True

            ' 1. إيقاف خدمة مراقبة الخمول ومؤقتات الداشبورد والساعة
            WindowsApp1.Services.SessionLockService.Instance.StopMonitoring()
            tmrClock.Stop()
            tmrDashboardRefresh.Stop()

            ' 2. تنظيف بيانات الجلسة بالكامل
            Session.Clear()
            usernamelogin = String.Empty
            passwordlogin = String.Empty
            useridlogin = 0

            ' 3. البحث عن فورم تسجيل الدخول الأصلي في الذاكرة
            Dim loginInstance As Login = Nothing
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is Login Then
                    loginInstance = CType(frm, Login)
                    Exit For
                End If
            Next

            ' 4. تجميع كافة النوافذ المفتوحة عدا شاشة تسجيل الدخول والشاشة الرئيسية لإغلاقها
            Dim otherForms As New List(Of Form)()
            For Each frm As Form In Application.OpenForms
                If frm IsNot loginInstance AndAlso frm IsNot Me Then
                    otherForms.Add(frm)
                End If
            Next

            ' إغلاق النوافذ الفرعية بترتيب عكسي لتفكيك النوافذ الحوارية والمودال بأمان تام
            For i As Integer = otherForms.Count - 1 To 0 Step -1
                Try
                    otherForms(i).Close()
                Catch ex As Exception
                    Logger.LogError("PerformLogout.CloseForm", ex)
                End Try
            Next

            ' 5. إعادة إظهار وتنشيط شاشة تسجيل الدخول
            If loginInstance IsNot Nothing AndAlso Not loginInstance.IsDisposed Then
                loginInstance.ResetForLogout(isAutoLock:=isAuto)
            Else
                Dim newLogin As New Login()
                newLogin.Show()
                newLogin.ResetForLogout(isAutoLock:=isAuto)
            End If

            If isAuto Then
                Try
                    Notify.Toast("تم قفل الجلسة تلقائياً بسبب الخمول لعدم الاستخدام 🔒", Notify.ToastType.Warning)
                Catch
                End Try
            Else
                Notify.Toast("تم تسجيل الخروج بنجاح ✅", Notify.ToastType.Info)
            End If

            ' 6. إغلاق الشاشة الرئيسية الحالية
            Me.Close()

        Catch ex As Exception
            Logger.LogError("PerformLogout", ex)
            MessageBox.Show("حدث خطأ أثناء محاولة تسجيل الخروج: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            _isLoggingOut = False
        End Try
    End Sub

    ' اختصارات لوحة المفاتيح
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' اختصار تسجيل الخروج السريع Ctrl + Q
        If e.Control AndAlso e.KeyCode = Keys.Q Then
            e.Handled = True
            PerformLogout()
            Return
        End If

        ' اختصار البحث السريع Ctrl + K
        If e.Control AndAlso e.KeyCode = Keys.K Then
            e.Handled = True
            txtGlobalSearch.Focus()
            txtGlobalSearch.SelectAll()
            Return
        End If

        Select Case e.KeyCode
            Case Keys.F1
                e.Handled = True
                OpenFormDirectly(GetType(frmPOS))
            Case Keys.F2
                e.Handled = True
                OpenFormDirectly(GetType(Products))
            Case Keys.F3
                e.Handled = True
                OpenFormDirectly(GetType(FrmCustomers))
            Case Keys.F4
                e.Handled = True
                OpenFormDirectly(GetType(Backup))
            Case Keys.F5
                e.Handled = True
                RefreshDashboardAsync(isManual:=True)
        End Select
    End Sub

    ''' <summary>
    ''' تطبيق الصلاحيات على أزرار القائمة الرئيسية في MainForm
    ''' </summary>
    Public Sub ApplyPermissionsToMainForm()
        If Session.CurrentRoleID = 1 Then Return

        If _ucDashboard IsNot Nothing Then _ucDashboard.ApplyPermissions()
        If _ucSales IsNot Nothing Then _ucSales.ApplyPermissions()
        If _ucSystem IsNot Nothing Then _ucSystem.ApplyPermissions()
        If _ucInventory IsNot Nothing Then _ucInventory.ApplyPermissions()
        If _ucPurchases IsNot Nothing Then _ucPurchases.ApplyPermissions()
        If _ucCustomers IsNot Nothing Then _ucCustomers.ApplyPermissions()
        If _ucSuppliers IsNot Nothing Then _ucSuppliers.ApplyPermissions()
        If _ucTreasury IsNot Nothing Then _ucTreasury.ApplyPermissions()
        If _ucExpenses IsNot Nothing Then _ucExpenses.ApplyPermissions()
        If _ucEmployees IsNot Nothing Then _ucEmployees.ApplyPermissions()
        If _ucUsers IsNot Nothing Then _ucUsers.ApplyPermissions()
        If _ucSettings IsNot Nothing Then _ucSettings.ApplyPermissions()
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            WindowsApp1.Services.Updates.BackgroundUpdateService.StopMonitoring()
        Catch
        End Try
    End Sub

End Class
