Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports WindowsApp1.FrmTreasuryTransaction

Public Class MainForm

    Private _isLoggingOut As Boolean = False

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
        SetActiveNav(navDashboard, viewDashboard)

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

            ' التحية الذكية حسب الوقت
            Dim hour As Integer = nowTime.Hour
            Dim greeting As String = "أهلاً بك"
            If hour >= 5 AndAlso hour < 12 Then
                greeting = "صباح الخير"
            ElseIf hour >= 12 AndAlso hour < 17 Then
                greeting = "طاب يومك"
            Else
                greeting = "مساء الخير"
            End If
            Dim uName As String = If(Not String.IsNullOrEmpty(Session.CurrentUserfullName), Session.CurrentUserfullName, Session.CurrentUserName)
            If String.IsNullOrEmpty(uName) Then uName = "المدير العام"
            lblWelcomeGreeting.Text = greeting & "، " & uName

            ' مدة الوردية النشطة
            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                Dim shiftDuration As TimeSpan = nowTime - ShiftSession.CurrentShift.OpenDateTime
                Dim durationStr As String = String.Format("{0:D2}:{1:D2}:{2:D2}", CInt(Math.Floor(shiftDuration.TotalHours)), shiftDuration.Minutes, shiftDuration.Seconds)
                lblShiftDuration.Text = "مدة الوردية: " & durationStr
                lblStatusShift.Text = "الوردية #" & ShiftSession.CurrentShift.ShiftNumber & " (" & durationStr & ")"
            Else
                lblShiftDuration.Text = "الوردية: مغلقة"
                lblStatusShift.Text = "الوردية: لا توجد وردية نشطة"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        UpdateDateTimeAndShift()
    End Sub

    Private _isRefreshingDashboard As Integer = 0

    Private Sub tmrDashboardRefresh_Tick(sender As Object, e As EventArgs) Handles tmrDashboardRefresh.Tick
        ' التحديث التلقائي الدوري في الخلفية (صامت تماماً وبدون أي وميض للزر، وفقط إذا كانت شاشة الداشبورد معروضة حالياً)
        If viewDashboard IsNot Nothing AndAlso viewDashboard.Visible Then
            RefreshDashboardAsync(isManual:=False)
        End If
    End Sub

    Private Sub btnRefreshDashboard_Click(sender As Object, e As EventArgs) Handles btnRefreshDashboard.Click
        ' التحديث اليدوي المباشر عند نقر المستخدم على الزر
        RefreshDashboardAsync(isManual:=True)
    End Sub

    ''' <summary>
    ''' جلب وتحديث مؤشرات الداشبورد في الخلفية بشكل غير تزامني لمنع تجميد الواجهة وبدون إزعاج المستخدم
    ''' </summary>
    Public Async Sub RefreshDashboardAsync(Optional isManual As Boolean = False)
        ' منع أي استدعاءات متزامنة في نفس الوقت (Thread-safe concurrency guard)
        If System.Threading.Interlocked.CompareExchange(_isRefreshingDashboard, 1, 0) <> 0 Then Return

        Try
            ' إظهار حالة التحميل للزر فقط عند التحديث اليدوي المباشر
            If isManual AndAlso btnRefreshDashboard IsNot Nothing Then
                btnRefreshDashboard.Enabled = False
                btnRefreshDashboard.Text = "⏳ جاري التحديث..."
            End If

            Await Task.Run(Sub()
                               LoadDashboardData()
                           End Sub)
        Catch ex As Exception
            Logger.LogError("RefreshDashboardAsync", ex)
        Finally
            If isManual AndAlso btnRefreshDashboard IsNot Nothing Then
                btnRefreshDashboard.Enabled = True
                btnRefreshDashboard.Text = "تحديث البيانات"
            End If
            System.Threading.Interlocked.Exchange(_isRefreshingDashboard, 0)
        End Try
    End Sub

    Private Sub LoadDashboardData()
        Try
            ' 1. مبيعات اليوم
            Dim salesAmount As Decimal = 0
            Dim salesCount As Integer = 0
            Try
                Dim dtSales = DBModule.ExecuteQuery("SELECT ISNULL(SUM(NetTotal), 0) AS TotalSales, COUNT(*) AS InvoicesCount FROM SalesInvoices WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND CAST(InvoiceDate AS DATE) = CAST(GETDATE() AS DATE)")
                If dtSales IsNot Nothing AndAlso dtSales.Rows.Count > 0 Then
                    salesAmount = Convert.ToDecimal(dtSales.Rows(0)("TotalSales"))
                    salesCount = Convert.ToInt32(dtSales.Rows(0)("InvoicesCount"))
                End If
            Catch
            End Try

            ' 2. مشتريات اليوم
            Dim purchasesAmount As Decimal = 0
            Dim purchasesCount As Integer = 0
            Try
                Dim dtPurchases = DBModule.ExecuteQuery("SELECT ISNULL(SUM(NetTotal), 0) AS TotalPurchases, COUNT(*) AS PurchasesCount FROM PurchaseHeaders WHERE CAST(PurchaseDate AS DATE) = CAST(GETDATE() AS DATE)")
                If dtPurchases IsNot Nothing AndAlso dtPurchases.Rows.Count > 0 Then
                    purchasesAmount = Convert.ToDecimal(dtPurchases.Rows(0)("TotalPurchases"))
                    purchasesCount = Convert.ToInt32(dtPurchases.Rows(0)("PurchasesCount"))
                End If
            Catch
            End Try

            ' 3. مصروفات اليوم
            Dim expensesAmount As Decimal = 0
            Try
                Dim dtExp = DBModule.ExecuteQuery("SELECT ISNULL(SUM(Amount), 0) AS TotalExpenses FROM Expenses WHERE CAST(Expense_Date AS DATE) = CAST(GETDATE() AS DATE)")
                If dtExp IsNot Nothing AndAlso dtExp.Rows.Count > 0 Then
                    expensesAmount = Convert.ToDecimal(dtExp.Rows(0)("TotalExpenses"))
                End If
            Catch
            End Try

            ' 4. إجمالي الأصناف
            Dim productsCount As Integer = 0
            Try
                Dim dtProd = DBModule.ExecuteQuery("SELECT COUNT(*) FROM Products WHERE (IsDeleted = 0 OR IsDeleted IS NULL)")
                If dtProd IsNot Nothing AndAlso dtProd.Rows.Count > 0 Then
                    productsCount = Convert.ToInt32(dtProd.Rows(0)(0))
                End If
            Catch
            End Try

            ' 5. إجمالي العملاء
            Dim customersCount As Integer = 0
            Try
                Dim dtCust = DBModule.ExecuteQuery("SELECT COUNT(*) FROM Customers WHERE (IsDeleted = 0 OR IsDeleted IS NULL)")
                If dtCust IsNot Nothing AndAlso dtCust.Rows.Count > 0 Then
                    customersCount = Convert.ToInt32(dtCust.Rows(0)(0))
                End If
            Catch
            End Try

            ' 6. إجمالي الموردين
            Dim suppliersCount As Integer = 0
            Try
                Dim dtSup = DBModule.ExecuteQuery("SELECT COUNT(*) FROM Suppliers WHERE (IsDeleted = 0 OR IsDeleted IS NULL)")
                If dtSup IsNot Nothing AndAlso dtSup.Rows.Count > 0 Then
                    suppliersCount = Convert.ToInt32(dtSup.Rows(0)(0))
                End If
            Catch
            End Try

            ' 7. آخر 10 فواتير مبيعات
            Dim dtRecentInvoices As DataTable = Nothing
            Try
                dtRecentInvoices = DBModule.ExecuteQuery("SELECT TOP 10 ISNULL(i.InvoiceNumber, CAST(i.InvoiceID AS VARCHAR)) AS InvoiceNumber, CONVERT(VARCHAR(5), i.InvoiceDate, 108) AS InvoiceTime, ISNULL(c.CustomerName, N'عميل نقدي') AS CustomerName, CASE i.OrderType WHEN 1 THEN N'تيك أواي' WHEN 2 THEN N'صالة' WHEN 3 THEN N'توصيل' ELSE N'مبيعات' END AS OrderTypeName, i.NetTotal, CASE WHEN i.IsCredit = 1 THEN N'آجل' ELSE N'نقدي' END AS PaymentTypeName FROM SalesInvoices i LEFT JOIN Customers c ON i.CustomerID = c.CustomerID WHERE (i.IsDeleted = 0 OR i.IsDeleted IS NULL) ORDER BY i.InvoiceID DESC")
            Catch
            End Try

            ' 8. نواقص المخزون
            Dim lowStockCount As Integer = 0
            Try
                Dim dtLow = DBModule.ExecuteQuery("SELECT COUNT(*) FROM Products p INNER JOIN StoreStock s ON p.Product_ID = s.MaterialID WHERE s.CurrentStock <= 5")
                If dtLow IsNot Nothing AndAlso dtLow.Rows.Count > 0 Then
                    lowStockCount = Convert.ToInt32(dtLow.Rows(0)(0))
                End If
            Catch
                Try
                    Dim dtLow2 = DBModule.ExecuteQuery("SELECT COUNT(*) FROM Stock WHERE Quantity_OnHand <= ISNULL(Min_Quantity, 5)")
                    If dtLow2 IsNot Nothing AndAlso dtLow2.Rows.Count > 0 Then
                        lowStockCount = Convert.ToInt32(dtLow2.Rows(0)(0))
                    End If
                Catch
                End Try
            End Try

            ' تحديث عناصر الواجهة على خيط واجهة المستخدم الرئيسي
            If Me.InvokeRequired Then
                Me.BeginInvoke(Sub()
                                   UpdateDashboardUI(salesAmount, salesCount, purchasesAmount, purchasesCount, expensesAmount, productsCount, customersCount, suppliersCount, dtRecentInvoices, lowStockCount)
                               End Sub)
            Else
                UpdateDashboardUI(salesAmount, salesCount, purchasesAmount, purchasesCount, expensesAmount, productsCount, customersCount, suppliersCount, dtRecentInvoices, lowStockCount)
            End If

        Catch ex As Exception
            Logger.LogError("LoadDashboardData", ex)
        End Try
    End Sub

    Private Sub UpdateDashboardUI(salesAmt As Decimal, salesCnt As Integer, purAmt As Decimal, purCnt As Integer, expAmt As Decimal, prodCnt As Integer, custCnt As Integer, supCnt As Integer, dtInvoices As DataTable, lowStockCnt As Integer)
        Try
            Dim currency As String = "جنية"
            Try
                Dim curr = SettingsManager.GetSetting("Currency")
                If Not String.IsNullOrEmpty(curr) Then currency = " " & curr
            Catch
            End Try

            ' تعبئة البطاقات
            lblCardSalesVal.Text = salesAmt.ToString("N2") & currency
            lblCardSalesSub.Text = salesCnt & " فاتورة اليوم"

            lblCardPurchasesVal.Text = purAmt.ToString("N2") & currency
            lblCardPurchasesSub.Text = purCnt & " فاتورة اليوم"

            Dim netProfit As Decimal = salesAmt - expAmt
            lblCardProfitVal.Text = netProfit.ToString("N2") & currency
            lblCardProfitSub.Text = "(المبيعات - المصروفات)"

            lblCardProductsVal.Text = prodCnt.ToString("N0")
            lblCardProductsSub.Text = "صنف مسجل بالنظام"

            lblCardCustomersVal.Text = custCnt.ToString("N0")
            lblCardCustomersSub.Text = "عميل مسجل"

            lblCardSuppliersVal.Text = supCnt.ToString("N0")
            lblCardSuppliersSub.Text = "مورد مسجل"

            ' تعبئة جدول آخر الفواتير
            dgvRecentInvoices.Rows.Clear()
            If dtInvoices IsNot Nothing Then
                For Each r As DataRow In dtInvoices.Rows
                    Dim invNum As String = r("InvoiceNumber").ToString()
                    Dim invTime As String = r("InvoiceTime").ToString()
                    Dim custName As String = r("CustomerName").ToString()
                    Dim ordType As String = r("OrderTypeName").ToString()
                    Dim netTot As String = Convert.ToDecimal(r("NetTotal")).ToString("N2")
                    Dim payType As String = r("PaymentTypeName").ToString()
                    dgvRecentInvoices.Rows.Add(invNum, invTime, custName, ordType, netTot, payType)
                Next
            End If

            ' التنبيهات الذكية
            If lowStockCnt > 0 Then
                lblAlertStockTitle.Text = "نواقص المخزون (" & lowStockCnt & " صنف)"
                lblAlertStockDesc.Text = "يوجد " & lowStockCnt & " أصناف وصلت أو تجاوزت حد الطلب الأدنى"
            Else
                lblAlertStockTitle.Text = "المخزون سليم"
                lblAlertStockDesc.Text = "لا توجد أصناف تحت حد الطلب الأدنى حالياً"
            End If

            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                lblAlertShiftTitle.Text = "وردية نشطة رقم #" & ShiftSession.CurrentShift.ShiftNumber
                lblAlertShiftDesc.Text = "بدأت في: " & ShiftSession.CurrentShift.OpenDateTime.ToString("hh:mm tt")
            Else
                lblAlertShiftTitle.Text = "لا توجد وردية نشطة"
                lblAlertShiftDesc.Text = "يجب فتح وردية جديدة قبل بدء عمليات البيع"
            End If

            lblAlertBackupTitle.Text = "حالة النسخ الاحتياطي"
            lblAlertBackupDesc.Text = "النظام مؤمن بنسخ احتياطي يومي مجدول"

        Catch ex As Exception
            Logger.LogError("UpdateDashboardUI", ex)
        End Try
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

        Dim allViews() As Control = {viewDashboard, viewSales, viewSystem, viewInventory, viewPurchases, viewCustomers, viewSuppliers, viewTreasury, viewExpenses, viewEmployees, viewUsers, viewSettings}
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
        SetActiveNav(navDashboard, viewDashboard)
        RefreshDashboardAsync(isManual:=False)
    End Sub

    Private Sub navSales_Click(sender As Object, e As EventArgs) Handles navSales.Click
        SetActiveNav(navSales, viewSales)
    End Sub

    Private Sub navSystem_Click(sender As Object, e As EventArgs) Handles navSystem.Click
        SetActiveNav(navSystem, viewSystem)
    End Sub

    Private Sub navInventory_Click(sender As Object, e As EventArgs) Handles navInventory.Click
        SetActiveNav(navInventory, viewInventory)
    End Sub

    Private Sub navPurchases_Click(sender As Object, e As EventArgs) Handles navPurchases.Click
        SetActiveNav(navPurchases, viewPurchases)
    End Sub

    Private Sub navCustomers_Click(sender As Object, e As EventArgs) Handles navCustomers.Click
        SetActiveNav(navCustomers, viewCustomers)
    End Sub

    Private Sub navSuppliers_Click(sender As Object, e As EventArgs) Handles navSuppliers.Click
        SetActiveNav(navSuppliers, viewSuppliers)
    End Sub

    Private Sub navTreasury_Click(sender As Object, e As EventArgs) Handles navTreasury.Click
        SetActiveNav(navTreasury, viewTreasury)
    End Sub

    Private Sub navExpenses_Click(sender As Object, e As EventArgs) Handles navExpenses.Click
        SetActiveNav(navExpenses, viewExpenses)
    End Sub

    Private Sub navEmployees_Click(sender As Object, e As EventArgs) Handles navEmployees.Click
        SetActiveNav(navEmployees, viewEmployees)
    End Sub

    Private Sub navUsers_Click(sender As Object, e As EventArgs) Handles navUsers.Click
        SetActiveNav(navUsers, viewUsers)
    End Sub

    Private Sub navSettings_Click(sender As Object, e As EventArgs) Handles navSettings.Click
        SetActiveNav(navSettings, viewSettings)
    End Sub

    Private Sub btnBackToDashboard_Click(sender As Object, e As EventArgs) Handles btnBackSales.Click, btnBackSystem.Click, btnBackInventory.Click, btnBackPurchases.Click, btnBackCustomers.Click, btnBackSuppliers.Click, btnBackTreasury.Click, btnBackExpenses.Click, btnBackEmployees.Click, btnBackUsers.Click, btnBackSettings.Click
        SetActiveNav(navDashboard, viewDashboard)
    End Sub

    Private Sub txtGlobalSearch_TextChanged(sender As Object, e As EventArgs) Handles txtGlobalSearch.TextChanged
        Dim term As String = txtGlobalSearch.Text.Trim().ToLower()
        If String.IsNullOrWhiteSpace(term) Then Return

        If term.Contains("بيع") OrElse term.Contains("pos") OrElse term.Contains("كاشير") OrElse term.Contains("مطبخ") OrElse term.Contains("kds") OrElse term.Contains("هالك") OrElse term.Contains("طاول") OrElse term.Contains("مرتجع") Then
            SetActiveNav(navSales, viewSales)
        ElseIf term.Contains("صنف") OrElse term.Contains("فئة") OrElse term.Contains("منيو") OrElse term.Contains("وردية") OrElse term.Contains("فرع") OrElse term.Contains("طيار") OrElse term.Contains("توصيل") Then
            SetActiveNav(navSystem, viewSystem)
        ElseIf term.Contains("مخزن") OrElse term.Contains("خام") OrElse term.Contains("ريسيبي") OrElse term.Contains("مخزون") OrElse term.Contains("وحد") Then
            SetActiveNav(navInventory, viewInventory)
        ElseIf term.Contains("شراء") OrElse term.Contains("مشتريات") OrElse term.Contains("توريد") Then
            SetActiveNav(navPurchases, viewPurchases)
        ElseIf term.Contains("عميل") OrElse term.Contains("عملاء") OrElse term.Contains("دين") Then
            SetActiveNav(navCustomers, viewCustomers)
        ElseIf term.Contains("مورد") OrElse term.Contains("موردين") Then
            SetActiveNav(navSuppliers, viewSuppliers)
        ElseIf term.Contains("خزن") OrElse term.Contains("خزينة") OrElse term.Contains("سحب") OrElse term.Contains("إيداع") OrElse term.Contains("ايداع") Then
            SetActiveNav(navTreasury, viewTreasury)
        ElseIf term.Contains("مصروف") OrElse term.Contains("مصاريف") OrElse term.Contains("نثريات") Then
            SetActiveNav(navExpenses, viewExpenses)
        ElseIf term.Contains("موظف") OrElse term.Contains("راتب") OrElse term.Contains("رواتب") OrElse term.Contains("سلف") OrElse term.Contains("مرتب") Then
            SetActiveNav(navEmployees, viewEmployees)
        ElseIf term.Contains("مستخدم") OrElse term.Contains("صلاحي") OrElse term.Contains("دور") OrElse term.Contains("كلمة سر") Then
            SetActiveNav(navUsers, viewUsers)
        ElseIf term.Contains("طابع") OrElse term.Contains("نسخ") OrElse term.Contains("إعداد") OrElse term.Contains("اعداد") OrElse term.Contains("ألوان") Then
            SetActiveNav(navSettings, viewSettings)
        End If
    End Sub

    Private Sub txtGlobalSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGlobalSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            Dim term As String = txtGlobalSearch.Text.Trim().ToLower()
            If term.Contains("بيع") OrElse term.Contains("pos") OrElse term.Contains("كاشير") Then
                btnfrmPOS.PerformClick()
            ElseIf term.Contains("مطبخ") OrElse term.Contains("kds") Then
                btnKds.PerformClick()
            ElseIf term.Contains("صنف") OrElse term.Contains("منتج") Then
                btnProducts.PerformClick()
            ElseIf term.Contains("خزينة") OrElse term.Contains("خزن") Then
                btnfrmTreasury.PerformClick()
            ElseIf term.Contains("ايداع") OrElse term.Contains("إيداع") Then
                btnDeposit.PerformClick()
            ElseIf term.Contains("سحب") Then
                btnWithdraw.PerformClick()
            ElseIf term.Contains("عميل") Then
                btnFrmCustomers.PerformClick()
            ElseIf term.Contains("مورد") Then
                ToolStripButton3.PerformClick()
            ElseIf term.Contains("شراء") OrElse term.Contains("مشتريات") Then
                btnfrmPurchases.PerformClick()
            ElseIf term.Contains("مصروف") Then
                btnform_Expenses.PerformClick()
            ElseIf term.Contains("موظف") Then
                btnfrmEmployees.PerformClick()
            ElseIf term.Contains("طابع") Then
                btnfrmPrinters.PerformClick()
            ElseIf term.Contains("نسخ") Then
                btnBackups.PerformClick()
            ElseIf term.Contains("اعداد") OrElse term.Contains("إعداد") Then
                btnSettings.PerformClick()
            End If
        End If
    End Sub

    Public Sub ApplyMainFormTheme()
        Try
            Dim pal = ThemeManager.Instance.CurrentPalette

            ' خلفية الفورم والحاويات الرئيسية
            Me.BackColor = pal.Background
            pnlMainContainer.BackColor = pal.Background
            pnlWelcome.BackColor = pal.Background

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

            ' عناصر الترحيب والساعة
            lblWelcomeGreeting.ForeColor = pal.TextPrimary
            lblWelcomeSub.ForeColor = pal.TextSecondary
            lblShiftDuration.ForeColor = pal.Primary
            btnRefreshDashboard.FillColor = pal.Primary
            btnRefreshDashboard.ForeColor = pal.TextOnPrimary
            btnRefreshDashboard.BorderRadius = 8
            btnRefreshDashboard.BorderThickness = 1
            btnRefreshDashboard.BorderColor = pal.PrimaryHover

            ' تطبيق ثيم بطاقات الإحصائيات الستة مع إطار عصري ومحدد
            Dim cards() As Guna.UI2.WinForms.Guna2Panel = {cardSales, cardPurchases, cardProfit, cardProducts, cardCustomers, cardSuppliers}
            For Each c In cards
                If c IsNot Nothing Then
                    c.FillColor = pal.CardBackground
                    c.BorderRadius = 12
                    c.BorderThickness = 1
                    c.BorderColor = pal.Border
                End If
            Next

            lblCardSalesTitle.ForeColor = pal.TextSecondary
            lblCardPurchasesTitle.ForeColor = pal.TextSecondary
            lblCardProfitTitle.ForeColor = pal.TextSecondary
            lblCardProductsTitle.ForeColor = pal.TextSecondary
            lblCardCustomersTitle.ForeColor = pal.TextSecondary
            lblCardSuppliersTitle.ForeColor = pal.TextSecondary

            lblCardSalesSub.ForeColor = pal.TextMuted
            lblCardPurchasesSub.ForeColor = pal.TextMuted
            lblCardProfitSub.ForeColor = pal.TextMuted
            lblCardProductsSub.ForeColor = pal.TextMuted
            lblCardCustomersSub.ForeColor = pal.TextMuted
            lblCardSuppliersSub.ForeColor = pal.TextMuted

            lblCardSalesVal.ForeColor = pal.Success
            lblCardPurchasesVal.ForeColor = pal.Warning
            lblCardProfitVal.ForeColor = pal.Primary
            lblCardProductsVal.ForeColor = pal.TextPrimary
            lblCardCustomersVal.ForeColor = pal.TextPrimary
            lblCardSuppliersVal.ForeColor = pal.TextPrimary

            ' بطاقة آخر الفواتير بإطار عصري
            cardRecentInvoices.FillColor = pal.CardBackground
            cardRecentInvoices.BorderRadius = 12
            cardRecentInvoices.BorderThickness = 1
            cardRecentInvoices.BorderColor = pal.Border
            lblRecentInvoicesTitle.ForeColor = pal.TextPrimary
            btnViewAllInvoices.FillColor = pal.Primary
            btnViewAllInvoices.ForeColor = pal.TextOnPrimary
            btnViewAllInvoices.BorderRadius = 6
            btnViewAllInvoices.BorderThickness = 1
            btnViewAllInvoices.BorderColor = pal.PrimaryHover

            ' جدول فواتير المبيعات
            dgvRecentInvoices.BackgroundColor = pal.CardBackground
            dgvRecentInvoices.DefaultCellStyle.BackColor = pal.CardBackground
            dgvRecentInvoices.DefaultCellStyle.ForeColor = pal.TextPrimary
            dgvRecentInvoices.DefaultCellStyle.SelectionBackColor = pal.SelectionBackground
            dgvRecentInvoices.DefaultCellStyle.SelectionForeColor = pal.SelectionForeground
            dgvRecentInvoices.AlternatingRowsDefaultCellStyle.BackColor = pal.GridAlternateBackground
            dgvRecentInvoices.AlternatingRowsDefaultCellStyle.ForeColor = pal.TextPrimary
            dgvRecentInvoices.ColumnHeadersDefaultCellStyle.BackColor = pal.GridHeaderBackground
            dgvRecentInvoices.ColumnHeadersDefaultCellStyle.ForeColor = pal.GridHeaderForeground
            dgvRecentInvoices.GridColor = pal.Border

            ' بطاقة التنبيهات وإشعارات النظام بإطار عصري
            cardAlerts.FillColor = pal.CardBackground
            cardAlerts.BorderRadius = 12
            cardAlerts.BorderThickness = 1
            cardAlerts.BorderColor = pal.Border
            lblAlertsTitle.ForeColor = pal.TextPrimary

            Dim alertCards() As Guna.UI2.WinForms.Guna2Panel = {cardAlertStock, cardAlertShift, cardAlertBackup}
            For Each ac In alertCards
                If ac IsNot Nothing Then
                    ac.FillColor = pal.BackgroundSecondary
                    ac.BorderRadius = 8
                    ac.BorderThickness = 1
                    ac.BorderColor = pal.Border
                End If
            Next

            lblAlertStockTitle.ForeColor = pal.TextPrimary
            lblAlertShiftTitle.ForeColor = pal.TextPrimary
            lblAlertBackupTitle.ForeColor = pal.TextPrimary

            lblAlertStockDesc.ForeColor = pal.TextSecondary
            lblAlertShiftDesc.ForeColor = pal.TextSecondary
            lblAlertBackupDesc.ForeColor = pal.TextSecondary

            lblQuickTitle.ForeColor = pal.TextPrimary

            ' أزرار الوصول السريع بإطارات أنيقة
            btnQuickPOS.FillColor = pal.Primary
            btnQuickPOS.ForeColor = pal.TextOnPrimary
            btnQuickPOS.BorderRadius = 8
            btnQuickPOS.BorderThickness = 1
            btnQuickPOS.BorderColor = pal.PrimaryHover

            Dim quickBtns() As Guna.UI2.WinForms.Guna2Button = {btnQuickProducts, btnQuickCustomers, btnQuickBackup}
            For Each qb In quickBtns
                If qb IsNot Nothing Then
                    qb.FillColor = pal.ButtonSecondaryBackground
                    qb.ForeColor = pal.ButtonSecondaryForeground
                    qb.BorderRadius = 8
                    qb.BorderThickness = 1
                    qb.BorderColor = pal.Border
                End If
            Next

            ' أزرار الأقسام (Action Tiles)
            Dim allTiles() As Guna.UI2.WinForms.Guna2Button = {
                btnfrmPOS, btnSalesReturns, btnFrmSalesReport, btnFrmDriverReport, btnKds, btnWaste, btnRes,
                btnCategories, btnProducts, btnfrmProductSizes, btnfrmProductAddons, btnfrmKitchenComments, btnfrmDeliveryAreas, btnfrmDeliveryDrivers, btnfrmShifts, btnShiftReports, btnfrmBranches,
                btnfrmStoreStock, btnfrmRawMaterials, btnfrmRecipes, btnfrmStores, btnfrmUnits,
                btnfrmPurchases, btnfrmPurchaseReports,
                btnFrmCustomers, btnFrmCustomerStatement, btnCustomerBalanceDownload, ToolStripButton11,
                ToolStripButton3, ToolStripButton4, ToolStripButton5,
                btnfrmTreasury, btnFrmTreasuryTransfer, btnDeposit, btnWithdraw, btnFrmTreasuryTransactionsReport,
                btnform_Expenses, btnExpensesReportForm,
                btnfrmEmployees, btnfrmJobTitles, btnfrmDepartments, btnfrmSalarySystems, btnfrmSalaryPayment,
                btnfrmUsers, btnfrmRolesAndPermissions,
                btnSettings, btnfrmPrinters, btnBackups, btnfrmRestaurantSections, btnfrmRestaurantTables, btnfrmColors
            }

            For Each tile In allTiles
                If tile IsNot Nothing Then
                    tile.FillColor = pal.CardBackground
                    tile.BorderColor = pal.Border
                    tile.ForeColor = pal.TextPrimary
                    tile.HoverState.FillColor = pal.Primary
                    tile.HoverState.BorderColor = pal.PrimaryHover
                    tile.HoverState.ForeColor = pal.TextOnPrimary
                End If
            Next

            ' أزرار العودة في هيدر الأقسام
            Dim backBtns() As Guna.UI2.WinForms.Guna2Button = {btnBackSales, btnBackSystem, btnBackInventory, btnBackPurchases, btnBackCustomers, btnBackSuppliers, btnBackTreasury, btnBackExpenses, btnBackEmployees, btnBackUsers, btnBackSettings}
            For Each bb In backBtns
                If bb IsNot Nothing Then
                    bb.FillColor = pal.ButtonSecondaryBackground
                    bb.ForeColor = pal.ButtonSecondaryForeground
                    bb.BorderColor = pal.Border
                End If
            Next

            ' عناوين ونصوص ووصف الأقسام
            Dim secTitles() As Label = {lblTitleSales, lblTitleSystem, lblTitleInventory, lblTitlePurchases, lblTitleCustomers, lblTitleSuppliers, lblTitleTreasury, lblTitleExpenses, lblTitleEmployees, lblTitleUsers, lblTitleSettings}
            For Each lt In secTitles
                If lt IsNot Nothing Then lt.ForeColor = pal.TextPrimary
            Next

            Dim secDescs() As Label = {lblDescSales, lblDescSystem, lblDescInventory, lblDescPurchases, lblDescCustomers, lblDescSuppliers, lblDescTreasury, lblDescExpenses, lblDescEmployees, lblDescUsers, lblDescSettings}
            For Each ld In secDescs
                If ld IsNot Nothing Then ld.ForeColor = pal.TextSecondary
            Next

            ' خلفيات شاشات الأقسام وحاوياتها
            Dim allSecViews() As Control = {viewSales, viewSystem, viewInventory, viewPurchases, viewCustomers, viewSuppliers, viewTreasury, viewExpenses, viewEmployees, viewUsers, viewSettings}
            For Each sv In allSecViews
                If sv IsNot Nothing Then sv.BackColor = pal.Background
            Next

            Dim secFlps() As FlowLayoutPanel = {flpSales, flpSystem, flpInventory, flpPurchases, flpCustomers, flpSuppliers, flpTreasury, flpExpenses, flpEmployees, flpUsers, flpSettings}
            For Each fp In secFlps
                If fp IsNot Nothing Then fp.BackColor = pal.Background
            Next

            Dim secHeaders() As Panel = {pnlHeaderSales, pnlHeaderSystem, pnlHeaderInventory, pnlHeaderPurchases, pnlHeaderCustomers, pnlHeaderSuppliers, pnlHeaderTreasury, pnlHeaderExpenses, pnlHeaderEmployees, pnlHeaderUsers, pnlHeaderSettings}
            For Each hp In secHeaders
                If hp IsNot Nothing Then hp.BackColor = pal.Background
            Next

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

    ' ─── أزرار شريط الأدوات (ToolStrip Buttons) ───
    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        OpenFormOnce(GetType(Categories), btnCategories)
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        OpenFormOnce(GetType(Products), btnProducts)
    End Sub

    Private Sub btnfrmProductSizes_Click(sender As Object, e As EventArgs) Handles btnfrmProductSizes.Click
        OpenFormOnce(GetType(frmProductSizes), btnfrmProductSizes)
    End Sub

    Private Sub btnfrmProductAddons_Click(sender As Object, e As EventArgs) Handles btnfrmProductAddons.Click
        OpenFormOnce(GetType(frmProductAddons), btnfrmProductAddons)
    End Sub

    Private Sub btnfrmKitchenComments_Click(sender As Object, e As EventArgs) Handles btnfrmKitchenComments.Click
        OpenFormOnce(GetType(frmKitchenComments), btnfrmKitchenComments)
    End Sub

    Private Sub btnfrmPOS_Click(sender As Object, e As EventArgs) Handles btnfrmPOS.Click
        OpenFormOnce(GetType(frmPOS), btnfrmPOS)
    End Sub

    Private Sub btnSalesReturns_Click(sender As Object, e As EventArgs) Handles btnSalesReturns.Click
        OpenFormOnce(GetType(Sales_Returns), btnSalesReturns)
    End Sub

    Private Sub btnfrmEmployees_Click(sender As Object, e As EventArgs) Handles btnfrmEmployees.Click
        OpenFormOnce(GetType(frmEmployees), btnfrmEmployees)
    End Sub

    Private Sub btnfrmJobTitles_Click(sender As Object, e As EventArgs) Handles btnfrmJobTitles.Click
        OpenFormOnce(GetType(frmJobTitles), btnfrmJobTitles)
    End Sub

    Private Sub btnfrmDepartments_Click(sender As Object, e As EventArgs) Handles btnfrmDepartments.Click
        OpenFormOnce(GetType(frmDepartments), btnfrmDepartments)
    End Sub

    Private Sub btnfrmSalarySystems_Click(sender As Object, e As EventArgs) Handles btnfrmSalarySystems.Click
        OpenFormOnce(GetType(frmSalarySystems), btnfrmSalarySystems)
    End Sub

    Private Sub btnfrmColors_Click(sender As Object, e As EventArgs) Handles btnfrmColors.Click
        OpenFormOnce(GetType(frmColors), btnfrmColors)
    End Sub

    Private Sub btnfrmDeliveryAreas_Click(sender As Object, e As EventArgs) Handles btnfrmDeliveryAreas.Click
        OpenFormOnce(GetType(frmDeliveryAreas), btnfrmDeliveryAreas)
    End Sub

    Private Sub btnfrmDeliveryDrivers_Click(sender As Object, e As EventArgs) Handles btnfrmDeliveryDrivers.Click
        OpenFormOnce(GetType(frmDeliveryDrivers), btnfrmDeliveryDrivers)
    End Sub

    Private Sub btnfrmTreasury_Click(sender As Object, e As EventArgs) Handles btnfrmTreasury.Click
        OpenFormOnce(GetType(frmTreasury), btnfrmTreasury)
    End Sub

    Private Sub btnFrmTreasuryTransfer_Click(sender As Object, e As EventArgs) Handles btnFrmTreasuryTransfer.Click
        OpenFormOnce(GetType(FrmTreasuryTransfer), btnFrmTreasuryTransfer)
    End Sub

    Private Sub btnFrmTreasuryTransactionsReport_Click(sender As Object, e As EventArgs) Handles btnFrmTreasuryTransactionsReport.Click
        OpenFormOnce(GetType(FrmTreasuryTransactionsReport), btnFrmTreasuryTransactionsReport)
    End Sub

    Private Sub btnfrmPrinters_Click(sender As Object, e As EventArgs) Handles btnfrmPrinters.Click
        OpenFormOnce(GetType(frmPrinters), btnfrmPrinters)
    End Sub

    Private Sub btnfrmRestaurantSections_Click(sender As Object, e As EventArgs) Handles btnfrmRestaurantSections.Click
        OpenFormOnce(GetType(frmRestaurantSections), btnfrmRestaurantSections)
    End Sub

    Private Sub btnfrmRestaurantTables_Click(sender As Object, e As EventArgs) Handles btnfrmRestaurantTables.Click
        OpenFormOnce(GetType(frmRestaurantTables), btnfrmRestaurantTables)
    End Sub

    Private Sub btnfrmShifts_Click(sender As Object, e As EventArgs) Handles btnfrmShifts.Click
        OpenFormOnce(GetType(frmShifts), btnfrmShifts)
    End Sub

    Private Sub btnShiftReports_Click(sender As Object, e As EventArgs) Handles btnShiftReports.Click
        OpenFormOnce(GetType(FrmShiftReports), btnShiftReports)
    End Sub

    Private Sub btnfrmBranches_Click(sender As Object, e As EventArgs) Handles btnfrmBranches.Click
        OpenFormOnce(GetType(frmBranches), btnfrmBranches)
    End Sub

    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnFrmCustomers.Click
        OpenFormOnce(GetType(FrmCustomers), btnFrmCustomers)
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        OpenFormOnce(GetType(Settings), btnSettings)
    End Sub

    Private Sub btnBackups_Click(sender As Object, e As EventArgs) Handles btnBackups.Click
        OpenFormOnce(GetType(Backup), btnBackups)
    End Sub

    Private Sub btnFrmCustomerStatement_Click(sender As Object, e As EventArgs) Handles btnFrmCustomerStatement.Click
        OpenFormOnce(GetType(FrmCustomerStatement), btnFrmCustomerStatement)
    End Sub

    Private Sub btnCustomerBalanceDownload_Click(sender As Object, e As EventArgs) Handles btnCustomerBalanceDownload.Click
        OpenFormOnce(GetType(Customer_Balance_Download), btnCustomerBalanceDownload)
    End Sub

    Private Sub btnFrmSalesReport_Click(sender As Object, e As EventArgs) Handles btnFrmSalesReport.Click
        OpenFormOnce(GetType(FrmSalesReport), btnFrmSalesReport)
    End Sub

    Private Sub btnFrmDriverReport_Click(sender As Object, e As EventArgs) Handles btnFrmDriverReport.Click
        OpenFormOnce(GetType(FrmDriverReport), btnFrmDriverReport)
    End Sub

    Private Sub btnKds_Click(sender As Object, e As EventArgs) Handles btnKds.Click
        OpenFormOnce(GetType(FrmKitchenDisplay), btnKds)
    End Sub

    Private Sub btnWaste_Click(sender As Object, e As EventArgs) Handles btnWaste.Click
        OpenFormOnce(GetType(FrmKitchenWaste), btnWaste)
    End Sub

    Private Sub btnRes_Click(sender As Object, e As EventArgs) Handles btnRes.Click
        OpenFormOnce(GetType(FrmTableReservations), btnRes)
    End Sub

    Private Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles btnDeposit.Click
        OpenTreasuryWithOperation(FrmTreasuryTransaction.TreasuryOperation.Deposit, btnDeposit)
    End Sub

    Private Sub btnWithdraw_Click(sender As Object, e As EventArgs) Handles btnWithdraw.Click
        OpenTreasuryWithOperation(FrmTreasuryTransaction.TreasuryOperation.Withdraw, btnWithdraw)
    End Sub

    Private Sub btnform_Expenses_Click(sender As Object, e As EventArgs) Handles btnform_Expenses.Click
        OpenFormOnce(GetType(form_Expenses), btnform_Expenses)
    End Sub

    Private Sub btnExpensesReportForm_Click(sender As Object, e As EventArgs) Handles btnExpensesReportForm.Click
        OpenFormOnce(GetType(ExpensesReportForm), btnExpensesReportForm)
    End Sub

    Private Sub btnfrmUnits_Click(sender As Object, e As EventArgs) Handles btnfrmUnits.Click
        OpenFormOnce(GetType(frmUnits), btnfrmUnits)
    End Sub

    Private Sub btnfrmStores_Click(sender As Object, e As EventArgs) Handles btnfrmStores.Click
        OpenFormOnce(GetType(FrmStores), btnfrmStores)
    End Sub

    Private Sub btnfrmStoreStock_Click(sender As Object, e As EventArgs) Handles btnfrmStoreStock.Click
        OpenFormOnce(GetType(frmStoreStock), btnfrmStoreStock)
    End Sub

    Private Sub btnfrmRawMaterials_Click(sender As Object, e As EventArgs) Handles btnfrmRawMaterials.Click
        OpenFormOnce(GetType(frmRawMaterials), btnfrmRawMaterials)
    End Sub

    Private Sub btnfrmRecipes_Click(sender As Object, e As EventArgs) Handles btnfrmRecipes.Click
        OpenFormOnce(GetType(frmRecipes), btnfrmRecipes)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        OpenFormOnce(GetType(FrmSuppliers), ToolStripButton3)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        OpenFormOnce(GetType(FrmSupplierTransactions), ToolStripButton4)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If Not Session.HasPermission("frmPurchaseReports", "CanOpen") Then
            MessageBox.Show("ليس لديك صلاحية فتح تقارير الموردين.")
            Return
        End If
        Using report As New frmPurchaseReports With {.ShowSupplierBalances = True}
            ThemeManager.Instance.ApplyTheme(report)
            report.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles btnfrmPurchases.Click
        OpenFormOnce(GetType(frmPurchases), btnfrmPurchases)
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        OpenFormOnce(GetType(Reports), ToolStripButton11)
    End Sub

    Private Sub OpenTreasuryWithOperation(op As FrmTreasuryTransaction.TreasuryOperation, btn As Control)
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

    Private Sub btnfrmSalaryPayment_Click(sender As Object, e As EventArgs) Handles btnfrmSalaryPayment.Click
        OpenFormOnce(GetType(frmSalaryPayment), btnfrmSalaryPayment)
    End Sub

    Private Sub btnfrmUsers_Click(sender As Object, e As EventArgs) Handles btnfrmUsers.Click
        OpenFormOnce(GetType(frmUsers), btnfrmUsers)
    End Sub

    Private Sub btnfrmRolesAndPermissions_Click(sender As Object, e As EventArgs) Handles btnfrmRolesAndPermissions.Click
        OpenFormOnce(GetType(frmRolesAndPermissions), btnfrmRolesAndPermissions)
    End Sub

    Private Sub btnfrmPurchaseReports_Click(sender As Object, e As EventArgs) Handles btnfrmPurchaseReports.Click
        OpenFormOnce(GetType(frmPurchaseReports), btnfrmPurchaseReports)
    End Sub

    ' ─── تفاعلات أزرار الداشبورد والبطاقات ───
    Private Sub btnViewAllInvoices_Click(sender As Object, e As EventArgs) Handles btnViewAllInvoices.Click
        btnFrmSalesReport.PerformClick()
    End Sub

    Private Sub cardSales_Click(sender As Object, e As EventArgs) Handles cardSales.Click, lblCardSalesTitle.Click, lblCardSalesVal.Click, lblCardSalesSub.Click, picCardSales.Click
        btnFrmSalesReport.PerformClick()
    End Sub

    Private Sub cardPurchases_Click(sender As Object, e As EventArgs) Handles cardPurchases.Click, lblCardPurchasesTitle.Click, lblCardPurchasesVal.Click, lblCardPurchasesSub.Click, picCardPurchases.Click
        btnfrmPurchaseReports.PerformClick()
    End Sub

    Private Sub cardProfit_Click(sender As Object, e As EventArgs) Handles cardProfit.Click, lblCardProfitTitle.Click, lblCardProfitVal.Click, lblCardProfitSub.Click, picCardProfit.Click
        btnFrmTreasuryTransactionsReport.PerformClick()
    End Sub

    Private Sub cardProducts_Click(sender As Object, e As EventArgs) Handles cardProducts.Click, lblCardProductsTitle.Click, lblCardProductsVal.Click, lblCardProductsSub.Click, picCardProducts.Click
        btnProducts.PerformClick()
    End Sub

    Private Sub cardCustomers_Click(sender As Object, e As EventArgs) Handles cardCustomers.Click, lblCardCustomersTitle.Click, lblCardCustomersVal.Click, lblCardCustomersSub.Click, picCardCustomers.Click
        btnFrmCustomers.PerformClick()
    End Sub

    Private Sub cardSuppliers_Click(sender As Object, e As EventArgs) Handles cardSuppliers.Click, lblCardSuppliersTitle.Click, lblCardSuppliersVal.Click, lblCardSuppliersSub.Click, picCardSuppliers.Click
        ToolStripButton3.PerformClick()
    End Sub

    Private Sub cardAlertStock_Click(sender As Object, e As EventArgs) Handles cardAlertStock.Click, lblAlertStockTitle.Click, lblAlertStockDesc.Click
        btnfrmStoreStock.PerformClick()
    End Sub

    Private Sub cardAlertShift_Click(sender As Object, e As EventArgs) Handles cardAlertShift.Click, lblAlertShiftTitle.Click, lblAlertShiftDesc.Click
        btnfrmShifts.PerformClick()
    End Sub

    Private Sub cardAlertBackup_Click(sender As Object, e As EventArgs) Handles cardAlertBackup.Click, lblAlertBackupTitle.Click, lblAlertBackupDesc.Click
        btnBackups.PerformClick()
    End Sub

    Private Sub btnQuickPOS_Click(sender As Object, e As EventArgs) Handles btnQuickPOS.Click
        btnfrmPOS.PerformClick()
    End Sub

    Private Sub btnQuickProducts_Click(sender As Object, e As EventArgs) Handles btnQuickProducts.Click
        btnProducts.PerformClick()
    End Sub

    Private Sub btnQuickCustomers_Click(sender As Object, e As EventArgs) Handles btnQuickCustomers.Click
        btnFrmCustomers.PerformClick()
    End Sub

    Private Sub btnQuickBackup_Click(sender As Object, e As EventArgs) Handles btnQuickBackup.Click
        btnBackups.PerformClick()
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
                btnfrmPOS.PerformClick()
            Case Keys.F2
                e.Handled = True
                btnProducts.PerformClick()
            Case Keys.F3
                e.Handled = True
                btnFrmCustomers.PerformClick()
            Case Keys.F4
                e.Handled = True
                btnBackups.PerformClick()
            Case Keys.F5
                e.Handled = True
                RefreshDashboardAsync(isManual:=True)
        End Select
    End Sub

    ''' <summary>
    ''' تطبيق الصلاحيات على أزرار القائمة الرئيسية في MainForm
    ''' </summary>
    Public Sub ApplyPermissionsToMainForm()
        If Session.CurrentRoleID = 1 Then Return ' مدير النظام لديه وصول كامل

        Dim mappings As New Dictionary(Of Control, String) From {
            {btnCategories, "Categories"},
            {btnProducts, "Products"},
            {btnfrmProductSizes, "frmProductSizes"},
            {btnfrmProductAddons, "frmProductAddons"},
            {btnfrmKitchenComments, "frmKitchenComments"},
            {btnfrmPOS, "frmPOS"},
            {btnSalesReturns, "Sales_Returns"},
            {btnfrmEmployees, "frmEmployees"},
            {btnfrmJobTitles, "frmJobTitles"},
            {btnfrmDepartments, "frmDepartments"},
            {btnfrmSalarySystems, "frmSalarySystems"},
            {btnfrmColors, "frmColors"},
            {btnfrmDeliveryAreas, "frmDeliveryAreas"},
            {btnfrmDeliveryDrivers, "frmDeliveryDrivers"},
            {btnfrmTreasury, "frmTreasury"},
            {btnFrmTreasuryTransfer, "FrmTreasuryTransfer"},
            {btnFrmTreasuryTransactionsReport, "FrmTreasuryTransactionsReport"},
            {btnfrmPrinters, "frmPrinters"},
            {btnfrmRestaurantSections, "frmRestaurantSections"},
            {btnfrmRestaurantTables, "frmRestaurantTables"},
            {btnfrmShifts, "frmShifts"},
            {btnShiftReports, "FrmShiftReports"},
            {btnfrmBranches, "frmBranches"},
            {btnFrmCustomers, "FrmCustomers"},
            {btnSettings, "Settings"},
            {btnBackups, "Backup"},
            {btnFrmCustomerStatement, "FrmCustomerStatement"},
            {btnCustomerBalanceDownload, "Customer_Balance_Download"},
            {btnFrmSalesReport, "FrmSalesReport"},
            {btnFrmDriverReport, "FrmDriverReport"},
            {btnDeposit, "FrmTreasuryTransaction"},
            {btnWithdraw, "FrmTreasuryTransaction"},
            {btnform_Expenses, "form_Expenses"},
            {btnExpensesReportForm, "ExpensesReportForm"},
            {btnfrmUnits, "frmUnits"},
            {btnfrmStores, "FrmStores"},
            {btnfrmStoreStock, "frmStoreStock"},
            {btnfrmRawMaterials, "frmRawMaterials"},
            {btnfrmRecipes, "frmRecipes"},
            {ToolStripButton3, "FrmSuppliers"},
            {ToolStripButton4, "FrmSupplierTransactions"},
            {ToolStripButton5, "frmPurchaseReports"},
            {btnfrmPurchases, "frmPurchases"},
            {btnfrmPurchaseReports, "frmPurchaseReports"},
            {ToolStripButton11, "Reports"},
            {btnfrmSalaryPayment, "frmSalaryPayment"},
            {btnfrmUsers, "frmUsers"},
            {btnfrmRolesAndPermissions, "frmRolesAndPermissions"},
            {btnKds, "FrmKitchenDisplay"},
            {btnWaste, "FrmKitchenWaste"},
            {btnRes, "FrmTableReservations"}
        }

        For Each kvp In mappings
            If kvp.Key IsNot Nothing Then
                Dim allowed As Boolean = Session.HasPermission(kvp.Value, "CanOpen")
                kvp.Key.Enabled = allowed
                If Not allowed Then
                    If TypeOf kvp.Key Is Guna.UI2.WinForms.Guna2Button Then
                        CType(kvp.Key, Guna.UI2.WinForms.Guna2Button).FillColor = Color.FromArgb(20, 24, 32)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            WindowsApp1.Services.Updates.BackgroundUpdateService.StopMonitoring()
        Catch
        End Try
    End Sub

End Class
