Imports System.Data
Imports System.Drawing
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

Namespace UC_Main
    ''' <summary>
    ''' شاشة لوحة التحكم والداشبورد الرئيسية (UCDashboard)
    ''' عنصر تحكم منفصل بالكامل يتيح التعديل والتصميم السلس عبر Visual Studio Designer.
    ''' </summary>
    Public Class UCDashboard
        Inherits UserControl

        ' أحداث التنقل وفتح الشاشات
        Public Event OpenSalesRequested()
        Public Event OpenProductsRequested()
        Public Event OpenCustomersRequested()
        Public Event OpenBackupsRequested()
        Public Event OpenSalesReportRequested()
        Public Event OpenPurchaseReportsRequested()
        Public Event OpenTreasuryReportRequested()
        Public Event OpenSuppliersRequested()
        Public Event OpenStoreStockRequested()
        Public Event OpenShiftsRequested()

        Private _isRefreshing As Integer = 0

        Public Sub New()
            InitializeComponent()
            ApplyDashboardTheme()
        End Sub

        Private Sub UCDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ApplyDashboardTheme()
            ApplyPermissions()
            UpdateDateTimeAndShift()
            RefreshDashboardAsync(isManual:=False)
        End Sub

        ''' <summary>
        ''' تطبيق صلاحيات المستخدم على أزرار الداشبورد
        ''' </summary>
        Public Sub ApplyPermissions()
            Try
                If Session.CurrentRoleID = 1 Then Return
                If btnQuickPOS IsNot Nothing Then btnQuickPOS.Enabled = Session.HasPermission("frmPOS", "CanOpen")
                If btnQuickProducts IsNot Nothing Then btnQuickProducts.Enabled = Session.HasPermission("Products", "CanOpen")
                If btnQuickCustomers IsNot Nothing Then btnQuickCustomers.Enabled = Session.HasPermission("FrmCustomers", "CanOpen")
                If btnQuickBackup IsNot Nothing Then btnQuickBackup.Enabled = Session.HasPermission("Backup", "CanOpen")
            Catch ex As Exception
                Logger.LogError("UCDashboard.ApplyPermissions", ex)
            End Try
        End Sub

        ''' <summary>
        ''' تطبيق ثيم الداشبورد ليتناسق مع إعدادات النظام
        ''' </summary>
        Public Sub ApplyDashboardTheme()
            Try
                Dim pal = ThemeManager.Instance.CurrentPalette
                If pal Is Nothing Then Return

                Me.BackColor = pal.Background
                pnlDashboardBody.BackColor = pal.Background
                pnlWelcome.BackColor = pal.Background

                ' بطاقات الإحصائيات
                Dim cards() As Guna2Panel = {cardSales, cardPurchases, cardProfit, cardProducts, cardCustomers, cardSuppliers}
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

                ' بطاقة الفواتير
                cardRecentInvoices.FillColor = pal.CardBackground
                cardRecentInvoices.BorderRadius = 12
                cardRecentInvoices.BorderThickness = 1
                cardRecentInvoices.BorderColor = pal.Border
                lblRecentInvoicesTitle.ForeColor = pal.TextPrimary
                btnViewAllInvoices.FillColor = pal.Primary
                btnViewAllInvoices.ForeColor = pal.TextOnPrimary
                btnViewAllInvoices.BorderRadius = 6

                ' جدول الفواتير
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

                ' بطاقة التنبيهات
                cardAlerts.FillColor = pal.CardBackground
                cardAlerts.BorderRadius = 12
                cardAlerts.BorderThickness = 1
                cardAlerts.BorderColor = pal.Border
                lblAlertsTitle.ForeColor = pal.TextPrimary

                Dim alertCards() As Guna2Panel = {cardAlertStock, cardAlertShift, cardAlertBackup}
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

                ' أزرار الوصول السريع
                btnQuickPOS.FillColor = pal.Primary
                btnQuickPOS.ForeColor = pal.TextOnPrimary
                btnQuickPOS.BorderRadius = 8
                btnQuickPOS.BorderThickness = 1
                btnQuickPOS.BorderColor = pal.PrimaryHover

                Dim quickBtns() As Guna2Button = {btnQuickProducts, btnQuickCustomers, btnQuickBackup}
                For Each qb In quickBtns
                    If qb IsNot Nothing Then
                        qb.FillColor = pal.ButtonSecondaryBackground
                        qb.ForeColor = pal.ButtonSecondaryForeground
                        qb.BorderRadius = 8
                        qb.BorderThickness = 1
                        qb.BorderColor = pal.Border
                    End If
                Next

                ' عناصر الهيدر الترحيبي
                lblWelcomeGreeting.ForeColor = pal.TextPrimary
                lblWelcomeSub.ForeColor = pal.TextSecondary
                lblShiftDuration.ForeColor = pal.Primary
                btnRefreshDashboard.FillColor = pal.Primary
                btnRefreshDashboard.ForeColor = pal.TextOnPrimary
                btnRefreshDashboard.BorderRadius = 8
                btnRefreshDashboard.BorderThickness = 1
                btnRefreshDashboard.BorderColor = pal.PrimaryHover
            Catch ex As Exception
                Logger.LogError("UCDashboard.ApplyDashboardTheme", ex)
            End Try
        End Sub

        ''' <summary>
        ''' تحديث التحية الذكية ومدة الوردية
        ''' </summary>
        Public Sub UpdateDateTimeAndShift()
            Try
                Dim nowTime As DateTime = DateTime.Now
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

                If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                    Dim shiftDuration As TimeSpan = nowTime - ShiftSession.CurrentShift.OpenDateTime
                    Dim durationStr As String = String.Format("{0:D2}:{1:D2}:{2:D2}", CInt(Math.Floor(shiftDuration.TotalHours)), shiftDuration.Minutes, shiftDuration.Seconds)
                    lblShiftDuration.Text = "مدة الوردية: " & durationStr
                Else
                    lblShiftDuration.Text = "الوردية: مغلقة"
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub btnRefreshDashboard_Click(sender As Object, e As EventArgs) Handles btnRefreshDashboard.Click
            RefreshDashboardAsync(isManual:=True)
        End Sub

        ''' <summary>
        ''' جلب وتحديث مؤشرات الداشبورد في الخلفية بشكل غير تزامني
        ''' </summary>
        Public Async Sub RefreshDashboardAsync(Optional isManual As Boolean = False)
            If Interlocked.CompareExchange(_isRefreshing, 1, 0) <> 0 Then Return

            Try
                If isManual AndAlso btnRefreshDashboard IsNot Nothing Then
                    btnRefreshDashboard.Enabled = False
                    btnRefreshDashboard.Text = "⏳ جاري التحديث..."
                End If

                Await Task.Run(Sub() LoadDashboardData())
            Catch ex As Exception
                Logger.LogError("UCDashboard.RefreshDashboardAsync", ex)
            Finally
                If isManual AndAlso btnRefreshDashboard IsNot Nothing Then
                    btnRefreshDashboard.Enabled = True
                    btnRefreshDashboard.Text = "تحديث البيانات"
                End If
                Interlocked.Exchange(_isRefreshing, 0)
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
                    Me.BeginInvoke(Sub() UpdateDashboardUI(salesAmount, salesCount, purchasesAmount, purchasesCount, expensesAmount, productsCount, customersCount, suppliersCount, dtRecentInvoices, lowStockCount))
                Else
                    UpdateDashboardUI(salesAmount, salesCount, purchasesAmount, purchasesCount, expensesAmount, productsCount, customersCount, suppliersCount, dtRecentInvoices, lowStockCount)
                End If

            Catch ex As Exception
                Logger.LogError("UCDashboard.LoadDashboardData", ex)
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
                Logger.LogError("UCDashboard.UpdateDashboardUI", ex)
            End Try
        End Sub

        ' ==========================================
        ' أحداث أزرار وبطاقات الداشبورد
        ' ==========================================
        Private Sub btnQuickPOS_Click(sender As Object, e As EventArgs) Handles btnQuickPOS.Click
            RaiseEvent OpenSalesRequested()
        End Sub

        Private Sub btnQuickProducts_Click(sender As Object, e As EventArgs) Handles btnQuickProducts.Click
            RaiseEvent OpenProductsRequested()
        End Sub

        Private Sub btnQuickCustomers_Click(sender As Object, e As EventArgs) Handles btnQuickCustomers.Click
            RaiseEvent OpenCustomersRequested()
        End Sub

        Private Sub btnQuickBackup_Click(sender As Object, e As EventArgs) Handles btnQuickBackup.Click
            RaiseEvent OpenBackupsRequested()
        End Sub

        Private Sub btnViewAllInvoices_Click(sender As Object, e As EventArgs) Handles btnViewAllInvoices.Click
            RaiseEvent OpenSalesReportRequested()
        End Sub

        Private Sub cardSales_Click(sender As Object, e As EventArgs) Handles cardSales.Click, lblCardSalesTitle.Click, lblCardSalesVal.Click, lblCardSalesSub.Click, picCardSales.Click
            RaiseEvent OpenSalesReportRequested()
        End Sub

        Private Sub cardPurchases_Click(sender As Object, e As EventArgs) Handles cardPurchases.Click, lblCardPurchasesTitle.Click, lblCardPurchasesVal.Click, lblCardPurchasesSub.Click, picCardPurchases.Click
            RaiseEvent OpenPurchaseReportsRequested()
        End Sub

        Private Sub cardProfit_Click(sender As Object, e As EventArgs) Handles cardProfit.Click, lblCardProfitTitle.Click, lblCardProfitVal.Click, lblCardProfitSub.Click, picCardProfit.Click
            RaiseEvent OpenTreasuryReportRequested()
        End Sub

        Private Sub cardProducts_Click(sender As Object, e As EventArgs) Handles cardProducts.Click, lblCardProductsTitle.Click, lblCardProductsVal.Click, lblCardProductsSub.Click, picCardProducts.Click
            RaiseEvent OpenProductsRequested()
        End Sub

        Private Sub cardCustomers_Click(sender As Object, e As EventArgs) Handles cardCustomers.Click, lblCardCustomersTitle.Click, lblCardCustomersVal.Click, lblCardCustomersSub.Click, picCardCustomers.Click
            RaiseEvent OpenCustomersRequested()
        End Sub

        Private Sub cardSuppliers_Click(sender As Object, e As EventArgs) Handles cardSuppliers.Click, lblCardSuppliersTitle.Click, lblCardSuppliersVal.Click, lblCardSuppliersSub.Click, picCardSuppliers.Click
            RaiseEvent OpenSuppliersRequested()
        End Sub

        Private Sub cardAlertStock_Click(sender As Object, e As EventArgs) Handles cardAlertStock.Click, lblAlertStockTitle.Click, lblAlertStockDesc.Click
            RaiseEvent OpenStoreStockRequested()
        End Sub

        Private Sub cardAlertShift_Click(sender As Object, e As EventArgs) Handles cardAlertShift.Click, lblAlertShiftTitle.Click, lblAlertShiftDesc.Click
            RaiseEvent OpenShiftsRequested()
        End Sub

        Private Sub cardAlertBackup_Click(sender As Object, e As EventArgs) Handles cardAlertBackup.Click, lblAlertBackupTitle.Click, lblAlertBackupDesc.Click
            RaiseEvent OpenBackupsRequested()
        End Sub

    End Class
End Namespace
