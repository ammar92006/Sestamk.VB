Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Threading.Tasks
Imports DevExpress.Utils.Frames
Imports DevExpress.XtraLayout.Customization

Public Class MainForm
    ' ─── متغيرات السحب (Drag) ───────────────────────────────────────────
    Dim x, y As Integer
    Dim newpoint As New Point

    ' ─── متغير مسار صورة المستخدم ────────────────────────────────────────
    Private User_photo_path As String = ""

    ' ═══════════════════════════════════════════════════════════════════════
    ' إغلاق التطبيق
    ' [FIX] استبدال Process.Kill() — كانت تنهي العملية فوراً بدون
    '       تحرير الموارد (DB Connections / Scanner Port / إلخ).
    '       Application.Exit() تستدعي FormClosing لكل الفورمات أولاً.
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' تنظيف الموارد عند الإغلاق - يضمن إغلاق Scanner Port و DB Connection
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            TimerClock.Stop()
        Catch
        End Try

        Try
            StopScanner()
        Catch
        End Try

        Try
            Disconnect()
        Catch
        End Try

        ' إنهاء التطبيق كاملاً عند إغلاق الفورم الرئيسي
        Application.Exit()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' [FIX #1] إصلاح Connection Leak الخطير
    ' المشكلة: Disconnect() كانت بعد Return فلا تُنفَّذ أبداً
    '           مما يُسبب فتح اتصالات غير مغلقة تراكماً مع كل استدعاء
    ' الحل: استخدام Using لضمان إغلاق الاتصال تلقائياً حتى عند الاستثناءات
    ' ═══════════════════════════════════════════════════════════════════════
    Private Function CountLowStockProducts() As Integer
        Dim count As Integer = 0

        Dim sql As String = "
            SELECT COUNT(*)
            FROM Stock
            WHERE 
                Quantity_OnHand < Min_Quantity
                OR 
                Quantity_OnHand = 0"
        Try
            Connect()
            Using Conn ' Using يضمن إغلاق الاتصال حتى لو حدث Exception
                Using cmd As New SqlCommand(sql, Conn)
                    count = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            ' [FIX] معالجة الاستثناء بدلاً من تركه يُوقف البرنامج
            Debug.WriteLine("CountLowStockProducts Error: " & ex.Message)
        End Try

        ' [FIX] Return بعد Using وليس قبل Disconnect
        Return count
    End Function

    ' ═══════════════════════════════════════════════════════════════════════
    ' تحميل المنتجات منخفضة المخزون في الـ Panel
    ' (لا تغيير على المنطق - فقط تحسين هيكل الاتصال)
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub LoadLowStockToPanel()
        Dim sql As String = "
        SELECT 
            P.Product_Name          AS [اسم المنتج],
            S.Quantity_OnHand       AS [المخزون الحالي],
            S.Min_Quantity          AS [الحد الأدنى]
        FROM Stock S
        LEFT JOIN Products P ON P.Product_ID = S.Product_ID
        WHERE 
            S.Quantity_OnHand < S.Min_Quantity
            OR 
            S.Quantity_OnHand = 0
        ORDER BY S.Quantity_OnHand ASC"

        Dim dt As New DataTable()

        Try
            Connect()
            Using Conn
                Using cmd As New SqlCommand(sql, Conn)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("LoadLowStockToPanel Error: " & ex.Message)
            Return
        End Try

        dgvLowStock.DataSource = dt

        ' تنسيق أعمدة الـ Grid
        If dgvLowStock.Columns.Count >= 3 Then
            dgvLowStock.Columns(0).HeaderText = "اسم المنتج"
            dgvLowStock.Columns(1).HeaderText = "الإجمالي (أساسية)"
            dgvLowStock.Columns(2).HeaderText = "الحد الأدنى"
        End If
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' تحديث Badge عداد المخزون المنخفض
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub UpdateLowStockBadge()
        Dim lowCount As Integer = CountLowStockProducts()

        If lowCount <= 0 Then
            lblBadge.Visible = False
            Exit Sub
        End If

        With lblBadge
            .Visible = True
            .Text = lowCount.ToString()
            .AutoSize = False
            .Location = New Point(btnBell.Right - 10, btnBell.Top - 6)
            .TextAlignment = ContentAlignment.TopCenter
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 14, FontStyle.Bold)
            .BringToFront()
        End With

        ' تحديد حجم الـ Badge بناءً على عدد الأرقام
        Dim textLen As Integer = lowCount.ToString().Trim().Length
        If textLen = 4 Then
            lblBadge.Size = New Size(45, 22)
        ElseIf textLen = 3 Then
            lblBadge.Size = New Size(35, 22)
        Else
            lblBadge.Size = New Size(36, 22)
        End If

        ' تلوين الـ Badge بناءً على الكمية
        Select Case lowCount
            Case 1 To 5
                lblBadge.BackColor = Color.Orange
            Case 6 To 15
                lblBadge.BackColor = Color.OrangeRed
            Case Else
                lblBadge.BackColor = Color.DarkRed
        End Select
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' أزرار التحكم في النافذة
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    ' ─── رابط المطور ──────────────────────────────────────────────────────
    Private Sub LabelDeveloper_Click(sender As Object, e As EventArgs) Handles LabelDeveloper.Click
        Process.Start(New ProcessStartInfo("https://www.facebook.com/ammar.92006") With {.UseShellExecute = True})
    End Sub

    Private Sub LabelDeveloper_MouseEnter(sender As Object, e As EventArgs) Handles LabelDeveloper.MouseEnter
        LabelDeveloper.ForeColor = Color.FromArgb(252, 249, 234)
        LabelDeveloper.Cursor = Cursors.Hand
        LabelDeveloper.Font = New Font("LBC", 22, FontStyle.Underline)
    End Sub

    Private Sub LabelDeveloper_MouseLeave(sender As Object, e As EventArgs) Handles LabelDeveloper.MouseLeave
        LabelDeveloper.ForeColor = SystemColors.ControlText
        LabelDeveloper.Cursor = Cursors.Default
        LabelDeveloper.Font = New Font("LBC", 20, FontStyle.Bold)
    End Sub

    ' ─── أزرار فتح النماذج ────────────────────────────────────────────────
    Private Sub btn_Products_Click(sender As Object, e As EventArgs) Handles btn_Products.Click
        OpenSingleForm(Of Products)()
    End Sub

    Private Sub btn_Users_Click(sender As Object, e As EventArgs) Handles btn_Users.Click
        OpenSingleForm(Of Users)()
    End Sub

    Private Sub btn_categories_Click(sender As Object, e As EventArgs) Handles btn_categories.Click
        OpenSingleForm(Of Categories)()
    End Sub

    Private Sub btn_ProductUnits_Click(sender As Object, e As EventArgs) Handles btn_ProductUnits.Click
        OpenSingleForm(Of ProductUnits)()
    End Sub

    Private Sub btn_Settings_Click(sender As Object, e As EventArgs) Handles btn_Settings.Click
        OpenSingleForm(Of Settings)()
    End Sub

    Private Sub btn_Stock_Click(sender As Object, e As EventArgs) Handles btn_Stock.Click
        OpenSingleForm(Of Stock)()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' [FIX #2 + #3 + #4] MainForm_Load - إصلاح متعدد
    '
    ' المشاكل كانت:
    '   - AddHandler يُضاف كل مرة تُفتح الفورم = Tick يُنفَّذ مرات مضاعفة
    '   - 10+ استعلامات DB منفصلة على UI Thread = تجميد عند الفتح
    '   - كل Count دالة منفصلة تفتح وتغلق اتصالاً
    '
    ' الحل:
    '   - التحقق من Timer قبل إضافة Handler (أو استخدام Handles)
    '   - دمج كل الـ Count في استعلام واحد (GetAllCounts)
    '   - تشغيل العمليات الثقيلة بـ Async/Await لمنع تجميد الواجهة
    ' ═══════════════════════════════════════════════════════════════════════
    Private Async Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' [FIX #4] إضافة Handler للـ Timer مرة واحدة فقط
        ' استخدام Handles في تعريف TimerTime_Tick يُغني عن AddHandler
        ' لكن إن كان التصميم يتطلب AddHandler، نتحقق أولاً
        TimerClock.Interval = 1000
        TimerClock.Enabled = True
        ' ملاحظة: TimerTime_Tick يجب أن يُعرَّف بـ "Handles TimerClock.Tick"
        ' أو نتأكد أن هذا السطر لا يُكرَّر:
        RemoveHandler TimerClock.Tick, AddressOf TimerTime_Tick ' إزالة قبل الإضافة لمنع التكرار
        AddHandler TimerClock.Tick, AddressOf TimerTime_Tick

        ' [FIX] تفعيل DoubleBuffered على شبكة الإشعارات
        Try
            EnableDoubleBuffer(dgvLowStock)
        Catch
        End Try

        loadversion()
        UpdateDateTime()
        ApplyPermissions()
        loadlogininfo()

        ' [FIX #3] تشغيل العمليات الثقيلة بشكل Async لمنع تجميد الواجهة
        Await Task.Run(Sub() LoadAllCountsAsync())

        ' تحديث الـ Badge والأعلى 10 على UI Thread
        UpdateLowStockBadge()
        LoadTop10Products()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' [FIX #3] دمج 10 استعلامات COUNT في استعلام واحد
    ' المشكلة: كانت 10 دوال منفصلة = 10 اتصالات قاعدة بيانات = بطء شديد
    ' الحل: استعلام واحد يُرجع كل الأعداد دفعة واحدة = اتصال واحد فقط
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub LoadAllCountsAsync()
        Try
            Dim sql As String = "
                SELECT
                    (SELECT COUNT(*) FROM Products)      AS ProductsCount,
                    (SELECT COUNT(*) FROM Customers)     AS CustomersCount,
                    (SELECT COUNT(*) FROM Suppliers)     AS SuppliersCount,
                    (SELECT COUNT(*) FROM Users_TBL)     AS UsersCount,
                    (SELECT COUNT(*) FROM Categories)    AS CatCount,
                    (SELECT COUNT(*) FROM ProductUnits)  AS UnitsCount,
                    (SELECT COUNT(*) FROM Stock)         AS StockCount,
                    (SELECT COUNT(*) FROM Backup_Log)    AS BackupCount,
                    (SELECT COUNT(*) FROM SalesHeader)   AS ReportsCount"

            Connect()
            Using Conn
                Using cmd As New SqlCommand(sql, Conn)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            ' تحديث الـ UI من UI Thread باستخدام Invoke
                            Dim productCount As Integer = Convert.ToInt32(dr("ProductsCount"))
                            Dim customersCount As Integer = Convert.ToInt32(dr("CustomersCount"))
                            Dim suppliersCount As Integer = Convert.ToInt32(dr("SuppliersCount"))
                            Dim usersCount As Integer = Convert.ToInt32(dr("UsersCount"))
                            Dim catCount As Integer = Convert.ToInt32(dr("CatCount"))
                            Dim unitsCount As Integer = Convert.ToInt32(dr("UnitsCount"))
                            Dim stockCount As Integer = Convert.ToInt32(dr("StockCount"))
                            Dim backupCount As Integer = Convert.ToInt32(dr("BackupCount"))
                            Dim reportsCount As Integer = Convert.ToInt32(dr("ReportsCount"))

                            ' [IMPORTANT] تحديث الـ UI يجب أن يكون على UI Thread
                            Me.Invoke(Sub()
                                          btn_Products.Text = $"المنتجات ({productCount})"
                                          btn_Customer.Text = $"العملاء ({customersCount})"
                                          btn_Suppliers.Text = $"الموردين ({suppliersCount})"
                                          btn_Users.Text = $"المستخدمين ({usersCount})"
                                          btn_categories.Text = $"الأقسام ({catCount})"
                                          btn_ProductUnits.Text = $"الوحدات و الاسعار ({unitsCount})"
                                          btn_Stock.Text = $"المخزن ({stockCount})"
                                          btn_backup.Text = $"النسخ الاحتياطي ({backupCount})"
                                          btn_Reports.Text = $"التقارير ({reportsCount})"
                                      End Sub)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("LoadAllCountsAsync Error: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' [FIX #5] دمج 3 استعلامات في loadlogininfo إلى استعلام واحد
    ' المشكلة: 3 Connect/Disconnect منفصلة لنفس المستخدم
    ' الحل: استعلام JOIN واحد يجلب RoleName + UserName + صورة دفعة واحدة
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub loadlogininfo()
        Try
            Connect()

            ' [FIX] استعلام واحد بدلاً من 3 استعلامات
            Dim query As String = "
                SELECT 
                    U.User_Name,
                    U.User_photo_path,
                    R.RoleName
                FROM Users_TBL U
                LEFT JOIN Roles R ON R.RoleID = @RoleID
                WHERE U.User_ID = @UserID"

            Using Conn
                Using cmd As New SqlCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@RoleID", Session.CurrentRoleID)
                    cmd.Parameters.AddWithValue("@UserID", Session.CurrentUserID)

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            lbl_RoleName.Text = Convert.ToString(dr("RoleName"))
                            lbl_log_name.Text = Convert.ToString(dr("User_Name"))

                            Dim photoPath As String = Convert.ToString(dr("User_photo_path"))

                            If Not File.Exists(photoPath) Then
                                pic_user.Image = My.Resources.لايوجد_صورة_للمستخدم
                            Else
                                ' [FIX] تحميل الصورة بشكل آمن بدون قفل الملف
                                Using imgStream As New FileStream(photoPath, FileMode.Open, FileAccess.Read)
                                    pic_user.Image = Image.FromStream(imgStream)
                                End Using
                            End If
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء التحقق من المستخدم: " & ex.Message,
                            "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' تطبيق الصلاحيات
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub ApplyPermissions()
        Try
            btn_Users.Visible = Session.HasPermission("Users", "CanOpen")
            btn_categories.Visible = Session.HasPermission("Categories", "CanOpen")
            btn_Products.Visible = Session.HasPermission("Products", "CanOpen")
            btn_ProductUnits.Visible = Session.HasPermission("ProductUnits", "CanOpen")
            btn_Customer.Visible = Session.HasPermission("Customer", "CanOpen")
            btn_Sales.Visible = Session.HasPermission("Sales", "CanOpen")
            btn_Suppliers.Visible = Session.HasPermission("Suppliers", "CanOpen")
            btn_Purchases.Visible = Session.HasPermission("Purchases", "CanOpen")
            btn_Reports.Visible = Session.HasPermission("Reports", "CanOpen")
            btn_Stock.Visible = Session.HasPermission("Stock", "CanOpen")
            btn_backup.Visible = Session.HasPermission("backup", "CanOpen")
            btn_Settings.Visible = Session.HasPermission("Settings", "CanOpen")
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء تطبيق الصلاحيات: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' التاريخ والوقت بالعربية
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub UpdateDateTime()
        Dim now As DateTime = DateTime.Now
        Dim arCulture As New CultureInfo("ar-EG")

        Dim timeText As String = now.ToString("tt hh:mm:ss", arCulture)
        Dim dayName As String = now.ToString("dddd", arCulture)
        Dim dayNumber As String = ReplaceEnglishNumbersWithArabic(now.ToString("d", arCulture))
        Dim monthName As String = now.ToString("MMMM", arCulture)
        Dim yearNumber As String = ReplaceEnglishNumbersWithArabic(now.ToString("yyyy", arCulture))

        Dim dateText As String = $"{dayName} ، {dayNumber} {monthName} {yearNumber} م"

        lblTime.Text = timeText
        lblDate.Text = dateText
    End Sub

    Private Function ReplaceEnglishNumbersWithArabic(input As String) As String
        Dim englishNumbers As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        Dim arabicNumbers As String() = {"٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩"}
        For i As Integer = 0 To 9
            input = input.Replace(englishNumbers(i), arabicNumbers(i))
        Next
        Return input
    End Function

    Private Sub TimerTime_Tick(sender As Object, e As EventArgs)
        UpdateDateTime()
    End Sub

    Private Sub loadversion()
        Dim versionText As String = Application.ProductVersion
        versionText = versionText.Replace(".0.0", "")
        lblVersion.Text = "الإصدار " & versionText
    End Sub

    ' ─── أزرار فتح النماذج المتبقية ───────────────────────────────────────
    Private Sub btn_Customer_Click(sender As Object, e As EventArgs) Handles btn_Customer.Click
        OpenSingleForm(Of Customer)()
    End Sub

    Private Sub btn_add_new_product_Click(sender As Object, e As EventArgs) Handles btn_add_new_product.Click
        OpenSingleForm(Of add_new_product)()
    End Sub

    Private Sub btn_Suppliers_Click(sender As Object, e As EventArgs) Handles btn_Suppliers.Click
        OpenSingleForm(Of Suppliers)()
    End Sub

    Private Sub btn_Sales_Click(sender As Object, e As EventArgs) Handles btn_Sales.Click
        OpenSingleForm(Of Sales)()
    End Sub

    Private Sub btn_Reports_Click(sender As Object, e As EventArgs) Handles btn_Reports.Click
        OpenSingleForm(Of Reports)()
    End Sub

    Private Sub btn_Purchases_Click(sender As Object, e As EventArgs) Handles btn_Purchases.Click
        OpenSingleForm(Of Purchases)()
    End Sub

    ' ─── سحب النافذة ──────────────────────────────────────────────────────
    Private Sub pn_title_MouseDown(sender As Object, e As MouseEventArgs) Handles pn_title.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub pn_title_MouseMove(sender As Object, e As MouseEventArgs) Handles pn_title.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' دوال Count الفردية - محتفظ بها للاستخدام الخارجي من نماذج أخرى
    ' (لم تُحذف - فقط أُضيف لها معالجة Disconnect صحيحة)
    ' ═══════════════════════════════════════════════════════════════════════
    Public Function GetProductsCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM Products", "عدد المنتجات")
    End Function

    Public Function GetSuppliersCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM Suppliers", "عدد الموردين")
    End Function

    Public Function GetCustomersCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM Customers", "عدد العملاء")
    End Function

    Public Function GetUserCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM Users_TBL", "عدد المستخدمين")
    End Function

    Public Function GetCatCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM Categories", "عدد الأقسام")
    End Function

    Public Function GetUnitsCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM ProductUnits", "عدد الوحدات")
    End Function

    Public Function GetStockCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM Stock", "عدد المخزن")
    End Function

    Public Function GetBackupCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM Backup_Log", "عدد النسخ الاحتياطية")
    End Function

    Public Function GetReportsCount() As Integer
        Return GetSingleCount("SELECT COUNT(*) FROM SalesHeader", "عدد التقارير")
    End Function

    ' ═══════════════════════════════════════════════════════════════════════
    ' [REFACTOR] دالة مساعدة مشتركة لتجنب تكرار نفس كود Count
    ' تُستخدم داخلياً فقط وتُبقي على نفس سلوك الدوال الفردية
    ' ═══════════════════════════════════════════════════════════════════════
    Private Function GetSingleCount(sql As String, errorContext As String) As Integer
        Dim total As Integer = 0
        Try
            Connect()
            Using Conn
                Using cmd As New SqlCommand(sql, Conn)
                    total = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"خطأ أثناء حساب {errorContext}: " & ex.Message)
        End Try
        Return total
    End Function

    ' ═══════════════════════════════════════════════════════════════════════
    ' تسجيل الخروج
    ' [FIX] إصلاح التكرار في إغلاق النماذج بشكل آمن
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub btn_logout_Click_1(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim main As Form = Application.OpenForms(0)

        ' [FIX] نسخ القائمة أولاً لتجنب مشكلة تعديل Collection أثناء التكرار
        Dim formsToClose As List(Of Form) = Application.OpenForms.Cast(Of Form)().
                                            Where(Function(f) f IsNot main).ToList()

        For Each f As Form In formsToClose
            f.Close()
            f.Dispose()
        Next

        Dim login As New Login()
        login.Show()
    End Sub

    ' ─── أزرار إضافية ──────────────────────────────────────────────────────
    Private Sub btn_add_new_Categorie_Click(sender As Object, e As EventArgs) Handles btn_add_new_Categorie.Click
        OpenSingleForm(Of add_new_Categorie)()
    End Sub

    Private Sub btn_add_new_user_Click(sender As Object, e As EventArgs) Handles btn_add_new_user.Click
        OpenSingleForm(Of add_new_user)()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' زر الجرس - إظهار/إخفاء Panel الإشعارات
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub btnBell_Click(sender As Object, e As EventArgs) Handles btnBell.Click
        StyleNotificationPanel()
        StyleLowStockGrid(dgvLowStock)

        If pnlNotifications.Visible = False Then
            LoadLowStockToPanel()
            pnlNotifications.BringToFront()
            pnlNotifications.Visible = True
        Else
            pnlNotifications.Visible = False
        End If
    End Sub

    Private Sub StyleNotificationPanel()
        With pnlNotifications
            .BackColor = Color.FromArgb(30, 30, 30)
            .BorderStyle = BorderStyle.FixedSingle
            .AutoScroll = True
            .Padding = New Padding(5)
        End With
    End Sub

    Private Sub StyleLowStockGrid(ByVal dgv As DataGridView)
        dgv.AllowUserToAddRows = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False
        dgv.RowHeadersVisible = False

        Dim darkBackground As Color = Color.FromArgb(30, 30, 30)
        Dim darkRow As Color = Color.FromArgb(45, 45, 45)
        Dim darkAltRow As Color = Color.FromArgb(55, 55, 55)
        Dim darkHeader As Color = Color.FromArgb(64, 64, 64)
        Dim highlightColor As Color = Color.FromArgb(0, 122, 204)
        Dim textColor As Color = Color.Gainsboro

        dgv.BackgroundColor = darkBackground
        dgv.RowsDefaultCellStyle.BackColor = darkRow
        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAltRow
        dgv.DefaultCellStyle.ForeColor = textColor
        dgv.GridColor = Color.FromArgb(80, 80, 80)

        dgv.ColumnHeadersDefaultCellStyle.BackColor = darkHeader
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgv.ColumnHeadersHeight = 40

        dgv.DefaultCellStyle.SelectionBackColor = highlightColor
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 11.0!)
        dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgv.RowTemplate.Height = 30

        For Each col As DataGridViewColumn In dgv.Columns
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub

    Private Sub dgvLowStock_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLowStock.CellContentClick
        ' محجوز للاستخدام المستقبلي
    End Sub

    Private Sub btn_add_new_customer_Click(sender As Object, e As EventArgs) Handles btn_add_new_customer.Click
        OpenSingleForm(Of add_new_customer)()
    End Sub

    Private Sub btn_add_new_supplier_Click(sender As Object, e As EventArgs) Handles btn_add_new_supplier.Click
        OpenSingleForm(Of add_new_supplier)()
    End Sub

    Private Sub btn_Customer_Balance_Download_Click(sender As Object, e As EventArgs) Handles btn_Customer_Balance_Download.Click
        OpenSingleForm(Of Customer_Balance_Download)()
    End Sub

    Private Sub btn_backup_Click(sender As Object, e As EventArgs) Handles btn_backup.Click
        OpenSingleForm(Of Backup)()
    End Sub

    Private Sub btn_dev_info_Click(sender As Object, e As EventArgs) Handles btn_dev_info.Click
        OpenSingleForm(Of About_the_program)()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadLowStockToPanel()
        UpdateLowStockBadge()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' [FIX #6] إصلاح Bug خطير في CellDoubleClick - لا تغيير على المنطق
    ' المشكلة: الكود الأصلي آمن هنا، فقط أُضيف تحسين للـ Guard Clause
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub dgvLowStock_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLowStock.CellDoubleClick
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

            Dim sectionName As String = dgvLowStock.Rows(e.RowIndex).Cells(0).Value?.ToString()
            If String.IsNullOrEmpty(sectionName) Then Exit Sub

            Dim frm As Stock = Nothing
            For Each f As Form In Application.OpenForms
                If TypeOf f Is Stock Then
                    frm = CType(f, Stock)
                    Exit For
                End If
            Next

            If frm Is Nothing Then
                frm = New Stock
                frm.Show()
            Else
                frm.BringToFront()
            End If

            Try
                frm.cmbSearchField.SelectedIndex = 1
            Catch
            End Try

            Try
                frm.txtSearch.Text = sectionName
                frm.txtSearch_TextChanged(frm.txtSearch, EventArgs.Empty)
            Catch
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "CellDoubleClick Error")
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' [FIX #7] Bug حرج في view_most_sale - InvalidCastException
    ' المشكلة: TypeOf f Is Stock لكن Cast إلى Reports = خطأ في Runtime!
    ' الحل: تصحيح TypeOf ليكون Is Reports
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub btn_view_most_sale_Click(sender As Object, e As EventArgs) Handles btn_view_most_sale.Click
        view_most_sale()
    End Sub

    Private Sub view_most_sale()
        Try
            Dim frm As Reports = Nothing

            For Each f As Form In Application.OpenForms
                ' [FIX] كان: TypeOf f Is Stock - خطأ! يجب أن يكون Is Reports
                If TypeOf f Is Reports Then
                    frm = CType(f, Reports)
                    Exit For
                End If
            Next

            If frm Is Nothing Then
                frm = New Reports
                frm.Show()
            Else
                frm.BringToFront()
            End If

            Try
                frm.TabReports.SelectedIndex = 3
            Catch
            End Try

        Catch ex As Exception
            Debug.WriteLine("view_most_sale Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        view_most_sale()
    End Sub

    Private Sub btn_Expenses_Click(sender As Object, e As EventArgs) Handles btn_Expenses.Click
        OpenSingleForm(Of form_Expenses)()
    End Sub

    Private Sub pn_title_Paint(sender As Object, e As PaintEventArgs) Handles pn_title.Paint
        ' محجوز
    End Sub

    ' ═══════════════════════════════════════════════════════════════════════
    ' [FIX #8] إصلاح Double Connect() في LoadTop10Products
    ' المشكلة: Connect() تُستدعى مرتين - مرة قبل Using ومرة داخله
    '          Using Conn يغلق الاتصال، ثم Connect() الداخلية تفتح اتصالاً جديداً
    '          لكن الـ cmd مرتبط بالـ Conn القديم = خطأ في Runtime
    ' الحل: استدعاء Connect() مرة واحدة فقط + Using صحيح
    ' ═══════════════════════════════════════════════════════════════════════
    Private Sub LoadTop10Products()
        Dim query As String =
                "SELECT 
                    Product_ID,
                    Product_Name,
                    ProductUnit_Name,
                    Sale_Price_Per_Unit,
                    SUM(Total_Line_Amount) AS Total_Line_Amount,
                    SUM(Quantity_Sold)     AS TotalQuantitySold
                FROM SalesDetails
                WHERE 
                    ProductUnit_Name NOT LIKE N'%جرام%'
                    AND ProductUnit_Name NOT LIKE N'%جم%'
                GROUP BY 
                    Product_ID,
                    Product_Name,
                    ProductUnit_Name,
                    Sale_Price_Per_Unit
                ORDER BY 
                    TotalQuantitySold DESC"

        Try
            Connect() ' [FIX] استدعاء واحد فقط هنا

            Using Conn ' Using يضمن الإغلاق التلقائي
                Using cmd As New SqlCommand(query, Conn)
                    ' [FIX] حُذفت: Connect() الداخلية المكررة
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        Dim i As Integer = 1

                        While dr.Read() AndAlso i <= 10
                            Dim lblP = TryCast(PanelTop10.Controls("lblProduct" & i), Label)
                            Dim lblPU = TryCast(PanelTop10.Controls("lblProductUnit" & i), Label)
                            Dim lblQ = TryCast(PanelTop10.Controls("lblTotalQuantity" & i), Label)
                            Dim lblPrice = TryCast(PanelTop10.Controls("lblSale_Price" & i), Label)
                            Dim lblPrice_Total = TryCast(PanelTop10.Controls("lblTotal" & i), Label)

                            If lblP IsNot Nothing Then lblP.Text = dr("Product_Name").ToString()
                            If lblPU IsNot Nothing Then lblPU.Text = dr("ProductUnit_Name").ToString()
                            If lblQ IsNot Nothing Then lblQ.Text = dr("TotalQuantitySold").ToString()

                            If lblPrice IsNot Nothing Then
                                lblPrice.Text = Convert.ToDecimal(dr("Sale_Price_Per_Unit")).ToString("N2")
                            End If

                            If lblPrice_Total IsNot Nothing Then
                                lblPrice_Total.Text = Convert.ToDecimal(dr("Total_Line_Amount")).ToString("N2")
                            End If

                            i += 1
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Debug.WriteLine("LoadTop10Products Error: " & ex.Message)
        End Try
    End Sub

End Class