Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DevExpress.Utils.About
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraEditors
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraRichEdit.Import.Html
Imports Guna.UI2.WinForms
Imports Microsoft.Office.Interop
Imports OfficeOpenXml
Imports ZXing

Public Class Products

    '#Region "═══ المتغيرات الأساسية ═══"
    '    Dim x, y As Integer
    '    Dim newpoint As New Point
    '    Dim adapter As SqlDataAdapter
    '    Dim ds As New DataSet
    '    Dim cmdb As New SqlCommandBuilder
    '    Private Product_Image As String = ""
    '    Dim cmd As SqlCommand
    '    Dim da As SqlDataAdapter
    '    Dim dt As DataTable
    '    Dim manager As New SalesManager()
    '#End Region

    '#Region "═══ [تحسين #1] متغيرات الأداء - Caching & Debounce ═══"
    '    ' ✅ Debounce Timer: يمنع الاستعلام عند كل ضغطة مفتاح
    '    '    بدلاً من 10 استعلامات/ثانية → استعلام واحد فقط بعد 350ms من التوقف
    Private _searchTimer As New Timer() With {.Interval = 350}

    '    ' ✅ Cache: تخزين المنتجات في الذاكرة للبحث الفوري بدون DB
    '    '    O(n) بدلاً من رحلة شبكية في كل بحث
    Private _cachedProducts As DataTable = Nothing

    '    ' ✅ Flag: تهيئة أعمدة الـ DataGridView مرة واحدة فقط عند التحميل
    '    '    بدلاً من تنفيذ 15 عملية في كل DataBindingComplete
    '    Private _columnsConfigured As Boolean = False

    '    ' ✅ الـ SQL الأساسي في متغير مشترك لتجنب تكرار كتابته
    '    Private Const BASE_QUERY As String =
    '        "SELECT
    '            P.Product_ID,
    '            P.BaseUnit_ID,
    '            PU.Unit_Name,
    '            P.Product_Code,
    '            P.Product_Name,
    '            C.Category_Name,
    '            V.CompanyName,
    '            V.SuppliersName,
    '            P.Product_Image,
    '            P.Product_Note,
    '            P.Product_State
    '         FROM dbo.Products AS P
    '         LEFT JOIN dbo.Categories AS C ON P.Category_ID = C.Category_ID
    '         LEFT JOIN dbo.Suppliers AS V ON P.Partner_ID = V.SuppliersID
    '         LEFT JOIN dbo.ProductUnits AS PU ON PU.ProductUnit_ID = P.BaseUnit_ID"
    '#End Region

    '#Region "═══ تحميل الفورم ═══"
    '    Private Sub Products_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '        ' [تحسين] ربط الـ Timer قبل أي شيء
    '        AddHandler _searchTimer.Tick, AddressOf SearchTimer_Tick

    '        LoadCategories()
    '        LoadSuppliers()
    '        LoadProducts() ' يملأ _cachedProducts أيضاً
    '        datagridviewsetup()
    '        ' [FIX] تفعيل DoubleBuffered لتقليل الـ Flickering عند البحث/التمرير
    '        EnableDoubleBuffer(dgvProducts)
    '        Try
    '            If Session.HasPermission("Products", "CanAdd") = False Then btnAdd.Visible = False
    '            If Session.HasPermission("Products", "CanEdit") = False Then btnUpdate.Visible = False
    '            If Session.HasPermission("Products", "CanDelete") = False Then btnDelete.Visible = False
    '        Catch ex As Exception
    '            MessageBox.Show("خطأ في تحميل صلاحيات المنتجات: " & ex.Message)
    '        End Try

    '        lblStatus.Text = "غير نشط"
    '        lblStatus.ForeColor = Color.Red

    '        cmbSearchField.Items.AddRange({
    '            "ID المنتج",
    '            "كود المنتج",
    '            "اسم المنتج",
    '            "القسم",
    '            "اسم الشركه المورده",
    '            "اسم المورد",
    '            "الوحدة الاساسية",
    '            "الملاحظات"
    '        })
    '        cmbSearchField.SelectedIndex = 2
    '    End Sub

    '    Private Sub Products_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    '        ' [تحسين] تنظيف الموارد عند إغلاق الفورم
    '        _searchTimer.Stop()
    '        _searchTimer.Dispose()
    '        If _cachedProducts IsNot Nothing Then
    '            _cachedProducts.Dispose()
    '            _cachedProducts = Nothing
    '        End If
    '    End Sub
    '#End Region

    '#Region "═══ إعداد الـ DataGridView ═══"
    '    Private Sub datagridviewsetup()
    '        With dgvProducts
    '            .ReadOnly = True
    '            .AllowUserToAddRows = False
    '            .AllowUserToDeleteRows = False
    '            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            .EnableHeadersVisualStyles = False

    '            ' إعداد Header
    '            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43)
    '            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    '            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
    '            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            .ColumnHeadersHeight = 70
    '            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
    '            .ColumnHeadersVisible = True

    '            ' إعداد الصفوف
    '            .DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 55)
    '            .DefaultCellStyle.ForeColor = Color.White
    '            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180)
    '            .DefaultCellStyle.SelectionForeColor = Color.White
    '            .DefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
    '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5)

    '            ' الصفوف المتبادلة
    '            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65)

    '            ' شكل الشبكة
    '            .GridColor = Color.FromArgb(80, 80, 80)
    '            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

    '            ' إعدادات عامة
    '            .BackgroundColor = Color.FromArgb(30, 30, 35)
    '            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
    '            .RowHeadersVisible = False
    '            .AllowUserToResizeRows = True
    '            .AllowUserToResizeColumns = False
    '            .MultiSelect = False
    '        End With
    '    End Sub

    '    ' [تحسين #2] تهيئة الأعمدة مرة واحدة فقط بدلاً من كل DataBindingComplete
    '    Private Sub ConfigureColumnsOnce()
    '        'If _columnsConfigured Then Return
    '        Try
    '            With dgvProducts
    '                If .Columns.Contains("Product_ID") Then .Columns("Product_ID").Visible = False
    '                If .Columns.Contains("BaseUnit_ID") Then .Columns("BaseUnit_ID").Visible = False
    '                If .Columns.Contains("Product_Image") Then .Columns("Product_Image").Visible = False

    '                If .Columns.Contains("Product_Code") Then .Columns("Product_Code").HeaderText = "كود المنتج"
    '                If .Columns.Contains("Product_Name") Then .Columns("Product_Name").HeaderText = "اسم المنتج"
    '                If .Columns.Contains("Category_Name") Then .Columns("Category_Name").HeaderText = "القسم"
    '                If .Columns.Contains("SuppliersName") Then .Columns("SuppliersName").HeaderText = "اسم المورد"
    '                If .Columns.Contains("CompanyName") Then .Columns("CompanyName").HeaderText = "اسم الشركة"
    '                If .Columns.Contains("Product_Note") Then .Columns("Product_Note").HeaderText = "الملاحظات"
    '                If .Columns.Contains("Product_State") Then .Columns("Product_State").HeaderText = "حالة المنتج"
    '                If .Columns.Contains("Unit_Name") Then .Columns("Unit_Name").HeaderText = "الوحدة الاساسية"

    '                If .Columns.Contains("Product_Code") Then .Columns("Product_Code").DisplayIndex = 0
    '                If .Columns.Contains("Product_Name") Then .Columns("Product_Name").DisplayIndex = 1
    '                If .Columns.Contains("Category_Name") Then .Columns("Category_Name").DisplayIndex = 2
    '                If .Columns.Contains("Unit_Name") Then .Columns("Unit_Name").DisplayIndex = 3
    '                If .Columns.Contains("CompanyName") Then .Columns("CompanyName").DisplayIndex = 4
    '                If .Columns.Contains("SuppliersName") Then .Columns("SuppliersName").DisplayIndex = 5
    '                If .Columns.Contains("Product_Note") Then .Columns("Product_Note").DisplayIndex = 6

    '                If .Columns.Contains("Product_Name") Then .Columns("Product_Name").Width = 300
    '                If .Columns.Contains("IsActive") Then .Columns("IsActive").Width = 60
    '            End With
    '            '_columnsConfigured = True ' ← لن يُنفَّذ مرة ثانية أبداً
    '        Catch
    '        End Try
    '    End Sub

    '    ' [تحسين #3] DataBindingComplete فقط يستدعي ConfigureColumnsOnce
    '    Private Sub dgvProducts_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
    '        ConfigureColumnsOnce()
    '    End Sub
    '#End Region

    '#Region "═══ تحميل البيانات الأساسية ═══"
    '    Private Sub LoadCategories()
    '        Try
    '            Connect()
    '            Dim cmd_LoadCategories As New SqlCommand(
    '                "SELECT Category_ID, Category_Name FROM Categories ORDER BY Category_ID", Conn)
    '            Dim da_LoadCategories As New SqlDataAdapter(cmd_LoadCategories)
    '            Dim dt_LoadCategories As New DataTable()
    '            da_LoadCategories.Fill(dt_LoadCategories)
    '            cmbCategory.DataSource = dt_LoadCategories
    '            cmbCategory.DisplayMember = "Category_Name"
    '            cmbCategory.ValueMember = "Category_ID"
    '            cmbCategory.SelectedIndex = -1
    '        Catch ex As Exception
    '            MessageBox.Show("خطأ في تحميل الأقسام: " & ex.Message)
    '        Finally
    '            Disconnect()
    '        End Try
    '    End Sub

    '    Private Sub LoadSuppliers()
    '        Try
    '            Connect()
    '            Dim cmd_LoadSuppliers As New SqlCommand(
    '                "SELECT SuppliersID, SuppliersName, Companyname FROM dbo.Suppliers ORDER BY SuppliersID;", Conn)
    '            Dim da_LoadSuppliers As New SqlDataAdapter(cmd_LoadSuppliers)
    '            Dim dt_LoadSuppliers As New DataTable()
    '            da_LoadSuppliers.Fill(dt_LoadSuppliers)
    '            cmbVendor.DataSource = dt_LoadSuppliers
    '            cmbVendor.DisplayMember = "SuppliersName"
    '            cmbVendor.ValueMember = "SuppliersID"
    '            cmbVendor.SelectedIndex = -1
    '        Catch ex As Exception
    '            MessageBox.Show("خطأ في تحميل الموردين: " & ex.Message)
    '        Finally
    '            Disconnect()
    '        End Try
    '    End Sub

    '    Private Sub LoadBaseUnit()
    '        If String.IsNullOrWhiteSpace(txtProductId.Text) Then Return
    '        Try
    '            Connect()
    '            Dim cmd_LoadBaseUnit As New SqlCommand(
    '                "SELECT P.Product_ID, PU.ProductUnit_ID, PU.Unit_Name
    '                 FROM dbo.Products AS P
    '                 LEFT JOIN dbo.ProductUnits AS PU ON P.Product_ID = PU.Product_ID
    '                 WHERE P.Product_ID = @PID
    '                 ORDER BY Unit_Quantity;", Conn)
    '            cmd_LoadBaseUnit.Parameters.AddWithValue("@PID", Convert.ToInt32(txtProductId.Text.Trim()))
    '            Dim da_LoadBaseUnit As New SqlDataAdapter(cmd_LoadBaseUnit)
    '            Dim dt_LoadBaseUnit As New DataTable()
    '            da_LoadBaseUnit.Fill(dt_LoadBaseUnit)
    '            cmbBaseUnit.DataSource = dt_LoadBaseUnit
    '            cmbBaseUnit.DisplayMember = "Unit_Name"
    '            cmbBaseUnit.ValueMember = "ProductUnit_ID"
    '        Catch ex As Exception
    '            MessageBox.Show("خطأ في تحميل الوحدات: " & ex.Message)
    '        Finally
    '            Disconnect()
    '        End Try
    '    End Sub
    '#End Region

    '#Region "═══ [تحسين #4] LoadProducts مع Cache ═══"
    '    ' الآن LoadProducts تُخزِّن النتيجة في _cachedProducts
    '    ' والبحث يتم في الذاكرة بدون رحلة DB إضافية
    '    Private Sub LoadProducts(Optional filter As String = "", Optional field As String = "")
    '        ClearUIOnly() ' [تحسين] مسح الـ UI بدون مسح txtSearch

    '        Try
    '            ' ─────────────────────────────────────────
    '            ' إذا لم يوجد Cache أو طُلب تحميل كامل جديد
    '            ' ─────────────────────────────────────────
    '            If _cachedProducts Is Nothing OrElse (filter = "" AndAlso field = "") Then
    '                Connect()
    '                Dim fullCmd As New SqlCommand(BASE_QUERY & " ORDER BY P.Product_Name", Conn)
    '                Dim fullDa As New SqlDataAdapter(fullCmd)
    '                Dim freshDt As New DataTable()
    '                fullDa.Fill(freshDt)
    '                ' تحديث Cache
    '                If _cachedProducts IsNot Nothing Then _cachedProducts.Dispose()
    '                _cachedProducts = freshDt
    '            End If

    '            ' ─────────────────────────────────────────
    '            ' [تحسين] البحث في الذاكرة بدون DB إضافي
    '            ' ─────────────────────────────────────────
    '            If filter <> "" AndAlso field <> "" Then
    '                Dim columnName As String = GetColumnName(field)
    '                If columnName <> "" Then
    '                    ' استخدام DataView للفلترة في الذاكرة - O(n) بدون شبكة
    '                    Dim dv As New DataView(_cachedProducts)
    '                    ' استخراج اسم العمود بدون prefix (P., C., V., PU.)
    '                    Dim shortCol As String = columnName.Split("."c)(1)
    '                    dv.RowFilter = $"{shortCol} LIKE '%{filter.Replace("'", "''")}%'"
    '                    Dim filteredDt As DataTable = dv.ToTable()
    '                    BindToGrid(filteredDt)
    '                Else
    '                    BindToGrid(_cachedProducts)
    '                End If
    '            Else
    '                BindToGrid(_cachedProducts)
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show("خطأ في تحميل المنتجات: " & ex.Message)
    '        Finally
    '            Disconnect()
    '            ConfigureColumnsOnce()
    '        End Try
    '    End Sub

    '    ' [تحسين #5] SuspendLayout/ResumeLayout لمنع إعادة الرسم المتكرر
    '    Private Sub BindToGrid(source As DataTable)
    '        dgvProducts.SuspendLayout()
    '        dgvProducts.DataSource = Nothing
    '        dgvProducts.DataSource = source
    '        dgvProducts.ResumeLayout()
    '    End Sub

    '    ' [تحسين] إبطال Cache بعد عمليات التعديل فقط
    '    Private Sub InvalidateCache()
    '        If _cachedProducts IsNot Nothing Then
    '            _cachedProducts.Dispose()
    '            _cachedProducts = Nothing
    '        End If
    '        _columnsConfigured = False
    '    End Sub
    '#End Region

    '#Region "═══ [تحسين #6] البحث مع Debounce Timer ═══"
    '    ' ✅ النتيجة: بدلاً من 10 استعلامات/ثانية ← استعلام واحد فقط
    '    Public Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
    '        ' أوقف الـ Timer عند كل ضغطة مفتاح
    '        _searchTimer.Stop()
    '        lstSuggestions.Visible = False

    '        Dim keyword As String = txtSearch.Text.Trim()

    '        If keyword.Length < 1 Then
    '            ' إذا مسح المستخدم النص - أظهر الكل فوراً بدون DB (من Cache)
    '            If _cachedProducts IsNot Nothing Then
    '                BindToGrid(_cachedProducts)
    '            Else
    '                LoadProducts()
    '            End If
    '            Return
    '        End If

    '        ' ابدأ العد التنازلي - سيُنفَّذ بعد 350ms من توقف الكتابة فقط
    '        _searchTimer.Start()
    '    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs)
        _searchTimer.Stop() ' نفِّذ مرة واحدة فقط

        Dim keyword As String = txtSearch.Text.Trim()
        If keyword.Length < 1 Then
            If _cachedProducts IsNot Nothing Then
                dgvProducts.DataSource = _cachedProducts
            Else
                LoadProductsGrid()
            End If
            lstSuggestions.Visible = False
            Return
        End If

        Dim field As String = If(cmbSearchField.SelectedItem?.ToString(), "")
        If field = "" Then Return

        ' [تحسين] البحث في الذاكرة - لا رحلة DB على الإطلاق
        LoadProductsGrid(keyword, field)
        UpdateSuggestionsFromCache(keyword, field)
        dgvProducts.ClearSelection()
    End Sub

    ' [تحسين #7] الاقتراحات من Cache في الذاكرة - لا DB إضافي
    Private Sub UpdateSuggestionsFromCache(keyword As String, field As String)
        lstSuggestions.Items.Clear()
        If _cachedProducts Is Nothing Then Return

        Dim columnName As String = GetColumnName(field)
        If String.IsNullOrEmpty(columnName) Then Return

        Dim shortCol As String = If(columnName.Contains("."c), columnName.Split("."c)(1), columnName)
        If Not _cachedProducts.Columns.Contains(shortCol) Then Return

        ' فلترة من الـ DataTable المخزنة في الذاكرة
        Dim suggestions = _cachedProducts.AsEnumerable().
            Where(Function(r) Not IsDBNull(r(shortCol)) AndAlso
                              r(shortCol).ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).
            Select(Function(r) r(shortCol).ToString()).
            Distinct().
            OrderBy(Function(s) s).
            Take(10). ' حد أقصى 10 اقتراحات لمنع إبطاء الـ UI
            ToList()

        If suggestions.Count > 0 Then
            lstSuggestions.Items.AddRange(suggestions.ToArray())
            lstSuggestions.Visible = True
        Else
            lstSuggestions.Visible = False
        End If
    End Sub

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txtSearch.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
        End If
    End Sub

    Private Sub cmbSearchField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchField.SelectedIndexChanged
        Dim keyword As String = txtSearch.Text.Trim()
        lstSuggestions.Items.Clear()

        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            If _cachedProducts IsNot Nothing Then
                dgvProducts.DataSource = _cachedProducts
            Else
                LoadProductsGrid()
            End If
            Return
        End If

        Dim field As String = cmbSearchField.SelectedItem?.ToString()
        If String.IsNullOrEmpty(field) Then Return

        LoadProductsGrid(keyword, field)
        UpdateSuggestionsFromCache(keyword, field)
    End Sub
    '#End Region

    '#Region "═══ دالة مساعدة: تحويل الحقل العربي لاسم العمود ═══"
    Private Function GetColumnName(field As String) As String
        Select Case field
            Case "الاسم عربي" : Return "ProductNameAr"
            Case "كود الصنف" : Return "ProductCode"
            Case "الاسم إنجليزي" : Return "ProductNameEn"
            Case "الفئة" : Return "Category_NameAr"
            Case "الوصف" : Return "Description"
            Case Else : Return ""
        End Select
    End Function
    '#End Region

    '#Region "═══ عمليات CRUD ═══"
    '    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
    '        If Not ValidateProductData() Then Return
    '        Try
    '            Connect()
    '            Dim query_Add As String =
    '                "INSERT INTO Products (Product_Code, Product_Name, Category_ID, Partner_ID, Product_Image, Product_State, Product_Note)
    '                 VALUES (@Product_Code, @Product_Name, @Category_ID, @Partner_ID, @Product_Image, @Product_State, @Product_Note)"

    '            Using cmd_Add As New SqlCommand(query_Add, Conn)
    '                cmd_Add.Parameters.AddWithValue("@Product_Code", txtProductCode.Text.Trim())
    '                cmd_Add.Parameters.AddWithValue("@Product_Name", txtProductName.Text.Trim())

    '                Dim categoryId As Integer
    '                If Not Integer.TryParse(cmbCategory.SelectedValue?.ToString(), categoryId) Then
    '                    MessageBox.Show("كود التصنيف غير صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Return
    '                End If
    '                cmd_Add.Parameters.AddWithValue("@Category_ID", categoryId)

    '                Dim partnerId As Integer
    '                If cmbVendor.SelectedValue Is Nothing OrElse
    '                   Not Integer.TryParse(cmbVendor.SelectedValue.ToString(), partnerId) Then
    '                    MessageBox.Show("كود المورد غير صالح أو غير محدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Return
    '                End If
    '                cmd_Add.Parameters.AddWithValue("@Partner_ID", partnerId)
    '                cmd_Add.Parameters.AddWithValue("@Product_Image", If(Product_Image, ""))
    '                cmd_Add.Parameters.AddWithValue("@Product_State", check_Stats.Checked.ToString())
    '                cmd_Add.Parameters.AddWithValue("@Product_Note", txtProductNote.Text.Trim())
    '                cmd_Add.ExecuteNonQuery()
    '            End Using

    '            MessageBox.Show("✅ تم الإضافة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            InvalidateCache() ' [تحسين] أبطل Cache لتحميل جديد
    '            LoadProducts()
    '            ClearAllFields()
    '        Catch ex As Exception
    '            MessageBox.Show("❌ خطأ أثناء الإضافة: " & ex.Message)
    '        Finally
    '            Disconnect()
    '            dgvProducts.ClearSelection()
    '        End Try
    '    End Sub

    '    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
    '        If Not ValidateProductData() Then Return
    '        If String.IsNullOrWhiteSpace(txtProductId.Text) Then
    '            MessageBox.Show("❌ يرجى تحديد المنتج المراد تعديله أولاً.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return
    '        End If

    '        Try
    '            Connect()
    '            Dim query_Update As String =
    '                "UPDATE Products SET
    '                    Product_Code  = @Product_Code,
    '                    BaseUnit_ID   = @BaseUnit_ID,
    '                    Product_Name  = @Product_Name,
    '                    Category_ID   = @Category_ID,
    '                    Partner_ID    = @Partner_ID,
    '                    Product_Image = @Product_Image,
    '                    Product_State = @Product_State,
    '                    Product_Note  = @Product_Note
    '                 WHERE Product_ID = @Product_ID"

    '            Using cmd_Update As New SqlCommand(query_Update, Conn)
    '                cmd_Update.Parameters.Add("@Product_ID", SqlDbType.Int).Value = Convert.ToInt32(txtProductId.Text)
    '                cmd_Update.Parameters.AddWithValue("@Product_Code", txtProductCode.Text.Trim())
    '                cmd_Update.Parameters.AddWithValue("@Product_Name", txtProductName.Text.Trim())
    '                cmd_Update.Parameters.AddWithValue("@Category_ID", cmbCategory.SelectedValue)
    '                cmd_Update.Parameters.AddWithValue("@Partner_ID", cmbVendor.SelectedValue)
    '                cmd_Update.Parameters.AddWithValue("@Product_Image", If(Product_Image, ""))
    '                cmd_Update.Parameters.AddWithValue("@Product_State", check_Stats.Checked.ToString())
    '                cmd_Update.Parameters.AddWithValue("@Product_Note", txtProductNote.Text.Trim())

    '                Dim baseUnitId As Integer = 1
    '                Integer.TryParse(cmbBaseUnit.SelectedValue?.ToString(), baseUnitId)
    '                cmd_Update.Parameters.AddWithValue("@BaseUnit_ID", baseUnitId)

    '                Dim rowsAffected As Integer = cmd_Update.ExecuteNonQuery()
    '                If rowsAffected > 0 Then
    '                    MessageBox.Show("✅ تم التعديل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    InvalidateCache()
    '                    LoadProducts()
    '                    ClearAllFields()
    '                Else
    '                    MessageBox.Show("❌ لم يتم العثور على المنتج المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End If
    '            End Using
    '        Catch ex As Exception
    '            MessageBox.Show("❌ خطأ أثناء التعديل: " & ex.Message)
    '        Finally
    '            Disconnect()
    '            dgvProducts.ClearSelection()
    '        End Try
    '    End Sub

    '    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
    '        If String.IsNullOrWhiteSpace(txtProductId.Text) Then
    '            MessageBox.Show("❌ يرجى تحديد المنتج المراد حذفه.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return
    '        End If
    '        If MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا المنتج؟", "تأكيد الحذف",
    '                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

    '        Try
    '            Connect()
    '            Using cmd_Delete As New SqlCommand("DELETE FROM Products WHERE Product_ID = @Product_ID", Conn)
    '                cmd_Delete.Parameters.Add("@Product_ID", SqlDbType.Int).Value = Convert.ToInt32(txtProductId.Text)
    '                Dim rowsAffected As Integer = cmd_Delete.ExecuteNonQuery()
    '                If rowsAffected > 0 Then
    '                    MessageBox.Show("🗑️ تم حذف المنتج بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    InvalidateCache()
    '                    LoadProducts()
    '                    ClearAllFields()
    '                Else
    '                    MessageBox.Show("❌ لم يتم العثور على المنتج المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End If
    '            End Using
    '        Catch ex As Exception
    '            MessageBox.Show("❌ خطأ أثناء الحذف: " & ex.Message)
    '        Finally
    '            Disconnect()
    '            dgvProducts.ClearSelection()
    '        End Try
    '    End Sub
    '#End Region

    '#Region "═══ التحقق من البيانات ═══"
    '    Private Function ValidateProductData() As Boolean
    '        If String.IsNullOrWhiteSpace(txtProductCode.Text) Then
    '            MessageBox.Show("الرجاء إدخال كود المنتج.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            txtProductCode.Focus()
    '            Return False
    '        End If
    '        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
    '            MessageBox.Show("الرجاء إدخال اسم المنتج.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            txtProductName.Focus()
    '            Return False
    '        End If
    '        If cmbCategory.SelectedIndex = -1 Then
    '            MessageBox.Show("الرجاء اختيار تصنيف المنتج.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            cmbCategory.Focus()
    '            Return False
    '        End If
    '        If cmbVendor.SelectedIndex = -1 Then
    '            MessageBox.Show("الرجاء اختيار مورد المنتج.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            cmbVendor.Focus()
    '            Return False
    '        End If
    '        Return True
    '    End Function
    '#End Region

    '#Region "═══ تحديد صف وعرض البيانات ═══"
    '    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs)
    '        If e.RowIndex >= 0 Then
    '            Selectrow(e.RowIndex)
    '        End If
    '    End Sub

    '    Private Sub Selectrow(rowIndex As Integer)
    '        If rowIndex < 0 OrElse rowIndex >= dgvProducts.Rows.Count Then Return

    '        Dim row As DataGridViewRow = dgvProducts.Rows(rowIndex)
    '        Try
    '            txtProductId.Text = row.Cells("Product_ID").Value?.ToString()
    '            txtProductCode.Text = row.Cells("Product_Code").Value?.ToString()
    '            txtProductName.Text = row.Cells("Product_Name").Value?.ToString()
    '            cmbCategory.Text = row.Cells("Category_Name").Value?.ToString()
    '            txtCompanyName.Text = row.Cells("CompanyName").Value?.ToString()
    '            cmbVendor.Text = row.Cells("SuppliersName").Value?.ToString()
    '            txtProductNote.Text = row.Cells("Product_Note").Value?.ToString()
    '            cmbBaseUnit.Text = row.Cells("Unit_Name").Value?.ToString()
    '            Product_Image = row.Cells("Product_Image").Value?.ToString()

    '            Dim stateVal As String = row.Cells("Product_State").Value?.ToString()
    '            If stateVal = "True" Then
    '                check_Stats.Checked = True
    '            ElseIf stateVal = "False" Then
    '                check_Stats.Checked = False
    '            Else
    '                check_Stats.BackColor = Color.FromArgb(255, 128, 128)
    '            End If

    '            ' [تحسين] تحميل الصورة بأمان مع Dispose صحيح
    '            LoadProductImage(Product_Image)

    '        Catch ex As Exception
    '            MessageBox.Show("حدث خطأ أثناء تحميل بيانات الصف: " & ex.Message)
    '        End Try
    '    End Sub

    '    ' [تحسين #8] دالة مستقلة لتحميل الصورة مع إدارة الذاكرة
    '    Private Sub LoadProductImage(imagePath As String)
    '        If String.IsNullOrWhiteSpace(imagePath) OrElse Not File.Exists(imagePath) Then
    '            Pic_Product.Image = My.Resources.لا_يوجد_صورة_للمنتج
    '            Return
    '        End If
    '        Try
    '            If Pic_Product.Image IsNot Nothing Then
    '                Pic_Product.Image.Dispose()
    '                Pic_Product.Image = Nothing
    '            End If
    '            Using img As System.Drawing.Image = System.Drawing.Image.FromFile(imagePath)
    '                Pic_Product.Image = New Bitmap(img)
    '            End Using
    '        Catch
    '            Pic_Product.Image = My.Resources.لا_يوجد_صورة_للمنتج
    '        End Try
    '    End Sub
    '#End Region

    '#Region "═══ مسح الحقول ═══"
    '    ' [تحسين #9] مسح الـ UI فقط بدون مسح txtSearch (لا يؤثر على البحث)
    '    Private Sub ClearUIOnly()
    '        txtProductId.Clear()
    '        txtProductCode.Clear()
    '        txtProductName.Clear()
    '        txtProductNote.Clear()
    '        txtCompanyName.Clear()
    '        cmbCategory.SelectedIndex = -1
    '        cmbVendor.SelectedIndex = -1
    '        Product_Image = ""
    '        dgvProducts.ClearSelection()
    '        cmbBaseUnit.DataSource = Nothing
    '        cmbBaseUnit.Items.Clear()
    '        check_Stats.Checked = False
    '        Pic_Product.Image = My.Resources.لا_يوجد_صورة_للمنتج
    '    End Sub

    '    ' [تحسين] ClearAllFields يُستدعى مرة واحدة فقط (لا مرتين)
    '    Private Sub ClearAllFields()
    '        ClearUIOnly()
    '        txtSearch.Clear()
    '        lstSuggestions.Visible = False
    '    End Sub

    '    Private Sub btn_clear_Click(sender As Object, e As EventArgs)
    '        ClearAllFields() ' مرة واحدة كافية
    '    End Sub
    '#End Region

    '#Region "═══ إعادة التحميل والمزامنة ═══"
    '    Private Sub btn_load_Click(sender As Object, e As EventArgs)
    '        InvalidateCache()
    '        LoadCategories()
    '        LoadSuppliers()
    '        LoadProducts()
    '        ClearAllFields()
    '    End Sub

    '    Private Sub txtProductId_TextChanged(sender As Object, e As EventArgs)
    '        If Not String.IsNullOrWhiteSpace(txtProductId.Text) Then
    '            LoadBaseUnit()
    '        End If
    '    End Sub
    '#End Region

    '#Region "═══ الصورة ═══"
    '    Private Sub btnBrowseImage_Click(sender As Object, e As EventArgs)
    '        Try
    '            If dgvProducts.SelectedRows.Count = 0 Then
    '                MessageBox.Show("يرجى تحديد منتج أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Return
    '            End If

    '            Dim ofd As New OpenFileDialog With {
    '                .Filter = "صور (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif",
    '                .Title = "اختر الصورة"
    '            }

    '            If ofd.ShowDialog() = DialogResult.OK Then
    '                Dim sourcePath As String = ofd.FileName
    '                Dim photosFolder As String = Path.Combine(Application.StartupPath, "photos_products")
    '                If Not Directory.Exists(photosFolder) Then Directory.CreateDirectory(photosFolder)

    '                Dim id As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)
    '                Dim newFileName As String = "product_" & id & Path.GetExtension(sourcePath)
    '                Dim destinationPath As String = Path.Combine(photosFolder, newFileName)

    '                File.Copy(sourcePath, destinationPath, True)

    '                Try
    '                    Connect()
    '                    Using cmdImg As New SqlCommand(
    '                        "UPDATE Products SET Product_Image = @Product_Image WHERE Product_ID = @Product_ID", Conn)
    '                        cmdImg.Parameters.AddWithValue("@Product_Image", destinationPath)
    '                        cmdImg.Parameters.AddWithValue("@Product_ID", id)
    '                        cmdImg.ExecuteNonQuery()
    '                    End Using
    '                Finally
    '                    Disconnect()
    '                End Try

    '                LoadProductImage(destinationPath)
    '                MessageBox.Show("✅ تم حفظ الصورة بنجاح:" & vbCrLf & destinationPath,
    '                                "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                InvalidateCache()
    '                LoadProducts()
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show("حدث خطأ أثناء حفظ الصورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Sub
    '#End Region

    '#Region "═══ المورد والشركة ═══"
    '    Private Sub cmbVendor_SelectedIndexChanged(sender As Object, e As EventArgs)
    '        If cmbVendor.SelectedValue Is Nothing OrElse cmbVendor.SelectedIndex = -1 Then
    '            txtCompanyName.Text = String.Empty
    '            Return
    '        End If

    '        Dim dtVendors As DataTable = TryCast(cmbVendor.DataSource, DataTable)
    '        If dtVendors Is Nothing Then Return

    '        Dim partnerId As Integer = 0
    '        If IsNumeric(cmbVendor.SelectedValue) Then
    '            partnerId = Convert.ToInt32(cmbVendor.SelectedValue)
    '        End If

    '        Dim selectedRows() As DataRow = dtVendors.Select($"SuppliersID = {partnerId}")
    '        txtCompanyName.Text = If(selectedRows.Length > 0, selectedRows(0)("Companyname").ToString(), String.Empty)
    '    End Sub
    '#End Region

    '#Region "═══ تحريك الفورم ═══"
    '    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
    '        x = Control.MousePosition.X - Me.Location.X
    '        y = Control.MousePosition.Y - Me.Location.Y
    '    End Sub

    '    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
    '        If e.Button = MouseButtons.Left Then
    '            newpoint = Control.MousePosition
    '            newpoint.X -= x
    '            newpoint.Y -= y
    '            Me.Location = newpoint
    '        End If
    '    End Sub
    '#End Region

    '#Region "═══ الحالة (نشط/غير نشط) ═══"
    '    Private Sub check_Stats_CheckedChanged(sender As Object, e As EventArgs)
    '        If check_Stats.Checked Then
    '            lblStatus.Text = "نشط"
    '            lblStatus.ForeColor = Color.Green
    '        Else
    '            lblStatus.Text = "غير نشط"
    '            lblStatus.ForeColor = Color.Red
    '        End If
    '    End Sub
    '#End Region

    '#Region "═══ الأزرار العامة ═══"
    '    Private Sub btn_Close_Click(sender As Object, e As EventArgs)
    '        Close()
    '    End Sub

    '    Private Sub btn_close_Click_1(sender As Object, e As EventArgs) Handles btn_close.Click
    '        Close()
    '    End Sub

    '    Private Sub btn_max_Click_1(sender As Object, e As EventArgs) Handles btn_max.Click
    '        WindowState = If(WindowState = FormWindowState.Maximized,
    '                         FormWindowState.Normal,
    '                         FormWindowState.Maximized)
    '    End Sub

    '    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
    '        WindowState = FormWindowState.Minimized
    '    End Sub

    '    Private Sub btn_Staff_Click(sender As Object, e As EventArgs)
    '        OpenSingleForm(Of The_Scale)()
    '    End Sub

    '    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    '        ' لا يوجد رسم مخصص
    '    End Sub
    '#End Region

    '#Region "═══ الباركود ═══"
    '    Public Sub ProcessBarcodeData(code As String)
    '        Try
    '            Dim barcode As String = code?.Trim()
    '            If String.IsNullOrWhiteSpace(barcode) Then Return
    '            SearchAndFillProductByBarcode(barcode)
    '        Catch
    '            ' تجاهل الخطأ بدون توقف البرنامج
    '        End Try
    '    End Sub

    '    Private Function SearchAndFillProductByBarcode(barcodeValue As String) As Boolean
    '        Try
    '            Dim dtUnit As DataTable = manager.GetUnitByBarcode(barcodeValue)
    '            If dtUnit IsNot Nothing AndAlso dtUnit.Rows.Count = 1 Then
    '                cmbSearchField.SelectedIndex = 2
    '                txtSearch.Text = dtUnit.Rows(0)("Product_Name").ToString()
    '                txtSearch.Focus()
    '                txtSearch.SelectAll()
    '                Return True
    '            Else
    '                MessageBox.Show($"لا يوجد منتج مرتبط بالباركود: {barcodeValue}",
    '                                "منتج غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Return False
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show("خطأ في البحث عن الباركود: " & ex.Message,
    '                            "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Return False
    '        End Try
    '    End Function
    '#End Region
    Dim x, y As Integer
    Dim newpoint As New Point
    ' 1. دالة جلب وعرض الأصناف مع ربطها بالفئات لعرض اسم القسم
    'Private Sub LoadProductsGrid()
    '    Dim query As String = "SELECT P.Product_ID, P.ProductCode, P.ProductNameAr, P.ProductNameEn, P.Image, " &
    '                          "P.Description, P.DiscountPercent,P.IsDiscountPercent, P.TaxPercent,P.IsTaxPercent, P.IsActive, P.PreparationTime, " &
    '                          "P.Notes, P.Category_ID, Cat.Category_NameAr " &
    '                          "FROM Products P " &
    '                          "LEFT JOIN Categories Cat ON P.Category_ID = Cat.Category_ID " &
    '                          "WHERE P.IsDeleted = 0 OR P.IsDeleted IS NULL"

    '    Dim dt As DataTable = DBModule.ExecuteQuery(query)
    '    If dt IsNot Nothing Then
    '        dgvProducts.DataSource = dt

    '        ' إخفاء المعرفات والصورة من العرض المباشر
    '        If dgvProducts.Columns.Contains("Product_ID") Then dgvProducts.Columns("Product_ID").Visible = False
    '        If dgvProducts.Columns.Contains("Category_ID") Then dgvProducts.Columns("Category_ID").Visible = False
    '        If dgvProducts.Columns.Contains("Image") Then dgvProducts.Columns("Image").Visible = False
    '        If dgvProducts.Columns.Contains("IsDiscountPercent") Then dgvProducts.Columns("IsDiscountPercent").Visible = False
    '        If dgvProducts.Columns.Contains("IsTaxPercent") Then dgvProducts.Columns("IsTaxPercent").Visible = False

    '        ' تسمية الأعمدة بالعربية
    '        dgvProducts.Columns("ProductCode").HeaderText = "كود الصنف"
    '        dgvProducts.Columns("ProductNameAr").HeaderText = "الاسم عربي"
    '        dgvProducts.Columns("ProductNameEn").HeaderText = "الاسم إنجليزي"
    '        dgvProducts.Columns("Category_NameAr").HeaderText = "القسم/الفئة"
    '        dgvProducts.Columns("DiscountPercent").HeaderText = "خصم %"
    '        dgvProducts.Columns("TaxPercent").HeaderText = "الضريبة %"
    '        dgvProducts.Columns("IsActive").HeaderText = "نشط"
    '        dgvProducts.Columns("PreparationTime").HeaderText = "وقت التحضير"
    '        dgvProducts.Columns("Description").HeaderText = "الوصف"
    '        dgvProducts.Columns("IsActive").Width = 60
    '    End If
    'End Sub
    Private Sub LoadProductsGrid(Optional filter As String = "", Optional field As String = "")
        Try
            ' 1. التحقق وجلب البيانات في الكاش إذا كان فارغاً
            If _cachedProducts Is Nothing OrElse (String.IsNullOrEmpty(filter) AndAlso String.IsNullOrEmpty(field)) Then
                Dim query As String = "SELECT P.Product_ID, P.ProductCode, P.ProductNameAr, P.ProductNameEn, P.Image, " &
                                  "P.Description, P.DiscountPercent, P.IsDiscountPercent, P.TaxPercent, P.IsTaxPercent, P.IsActive, P.PreparationTime, " &
                                  "P.Notes, P.Category_ID, Cat.Category_NameAr " &
                                  "FROM Products P " &
                                  "LEFT JOIN Categories Cat ON P.Category_ID = Cat.Category_ID " &
                                  "WHERE P.IsDeleted = 0 OR P.IsDeleted IS NULL"

                Dim freshDt As DataTable = DBModule.ExecuteQuery(query)

                If _cachedProducts IsNot Nothing Then _cachedProducts.Dispose()
                _cachedProducts = freshDt
            End If

            ' 🛑 خط دفاع أول: إذا كان الكاش لا يزال فارغاً بسبب فشل الاتصال، نخرج فوراً لمنع الـ Crash
            If _cachedProducts Is Nothing Then Exit Sub

            ' 2. معالجة التصفية والبحث في الذاكرة
            Dim dtToBind As DataTable = _cachedProducts

            If Not String.IsNullOrEmpty(filter) AndAlso Not String.IsNullOrEmpty(field) Then
                Dim columnName As String = ""
                Select Case field.Trim()
                    Case "كود الصنف" : columnName = "ProductCode"
                    Case "الاسم عربي" : columnName = "ProductNameAr"
                    Case "الاسم إنجليزي" : columnName = "ProductNameEn"
                    Case "الفئة" : columnName = "Category_NameAr"
                    Case "الوصف" : columnName = "Description"
                End Select

                If columnName <> "" AndAlso _cachedProducts.Columns.Contains(columnName) Then
                    Dim dv As New DataView(_cachedProducts)
                    Dim safeFilter As String = filter.Replace("'", "''")
                    dv.RowFilter = $"{columnName} LIKE '%{safeFilter}%'"
                    dtToBind = dv.ToTable()
                End If
            End If

            ' 3. ربط البيانات بالـ DataGridView
            dgvProducts.DataSource = dtToBind

            ' 🛑 حماية التنسيقات (تأمين الأعمدة ضد الـ NullReferenceException)
            ' نتحقق أولاً من وجود العمود قبل تعديل خصائصه

            Dim hiddenColumns As String() = {"Product_ID", "Category_ID", "Image", "IsDiscountPercent", "IsTaxPercent"}
            For Each col In hiddenColumns
                If dgvProducts.Columns.Contains(col) Then dgvProducts.Columns(col).Visible = False
            Next

            ' تغيير العناوين فقط للأعمدة الموجودة بالفعل في الجريد
            If dgvProducts.Columns.Contains("ProductCode") Then dgvProducts.Columns("ProductCode").HeaderText = "كود الصنف"
            If dgvProducts.Columns.Contains("ProductNameAr") Then dgvProducts.Columns("ProductNameAr").HeaderText = "الاسم عربي"
            If dgvProducts.Columns.Contains("ProductNameEn") Then dgvProducts.Columns("ProductNameEn").HeaderText = "الاسم إنجليزي"
            If dgvProducts.Columns.Contains("Category_NameAr") Then dgvProducts.Columns("Category_NameAr").HeaderText = "القسم/الفئة"
            If dgvProducts.Columns.Contains("DiscountPercent") Then dgvProducts.Columns("DiscountPercent").HeaderText = "الخصم"
            If dgvProducts.Columns.Contains("TaxPercent") Then dgvProducts.Columns("TaxPercent").HeaderText = "الضريبة"
            If dgvProducts.Columns.Contains("PreparationTime") Then dgvProducts.Columns("PreparationTime").HeaderText = "وقت التحضير"
            If dgvProducts.Columns.Contains("Description") Then dgvProducts.Columns("Description").HeaderText = "الوصف"

            If dgvProducts.Columns.Contains("IsActive") Then
                dgvProducts.Columns("IsActive").HeaderText = "نشط"
                dgvProducts.Columns("IsActive").Width = 60
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل وتصفية المنتجات: " & ex.Message, "خطأ خطير", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler _searchTimer.Tick, AddressOf SearchTimer_Tick
        FillCategoriesComboBox() ' ملء قائمة الأقسام أولاً
        LoadProductsGrid() ' عرض الأصناف
        datagridviewsetup()
        dtpPrepTime.Format = DateTimePickerFormat.Custom
        dtpPrepTime.CustomFormat = "HH:mm:ss" ' صيغة 24 ساعة (أو "hh:mm:ss tt" لصيغة AM/PM)
        dtpPrepTime.ShowUpDown = True ' إظهار أسهم للتحكم بالوقت بدلاً من النتيجة (Calendar)
        cmbSearchField.Items.Clear()
        cmbSearchField.Items.AddRange(New Object() {
            "كود الصنف",
            "الاسم عربي",
            "الاسم إنجليزي",
            "الفئة",
            "الوصف"
        })

        ' تحديد العنصر الأول كخيار افتراضي (الاسم عربي) لكي لا يظل فارغاً
        If cmbSearchField.Items.Count > 0 Then
            cmbSearchField.SelectedIndex = 0
        End If
    End Sub
    Private Sub FillCategoriesComboBox()
        Dim query As String = "SELECT Category_ID, Category_NameAr FROM Categories WHERE IsActive = 1 AND IsDeleted = 0 OR IsDeleted IS NULL"
        Dim dt As DataTable = DBModule.ExecuteQuery(query)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            cmbCategory.DataSource = dt
            cmbCategory.DisplayMember = "Category_NameAr"
            cmbCategory.ValueMember = "Category_ID"
            cmbCategory.SelectedIndex = -1
        End If
    End Sub
    ' 2. دالة التحقق من البيانات (Validation)
    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtProductNameAr.Text) Then
            MessageBox.Show("يجب إدخال اسم الصنف بالعربي!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductNameAr.Focus()
            Return False
        End If
        If cmbCategory.SelectedIndex = -1 OrElse cmbCategory.SelectedValue Is Nothing Then
            MessageBox.Show("يرجى اختيار القسم التابع له الصنف!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Return False
        End If
        Return True
    End Function

    ' 3. دالة تنظيف الحقول
    Private Sub ClearFields()
        txtProductCode.Clear()
        txtProductNameAr.Clear()
        txtProductNameEn.Clear()
        txtDescription.Clear()
        txtDiscount.Text = "0"
        txtTax.Text = "0"
        txtNotes.Clear()
        dtpPrepTime.Text = "00:00:00"
        cmbCategory.SelectedIndex = -1
        picProduct.Image = Nothing
        tgStatus.Checked = True
        dgvProducts.ClearSelection()
        btnDiscountType.Checked = False
        btnTaxType.Checked = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub
    Private Sub datagridviewsetup()
        With dgvProducts
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .DefaultCellStyle.SelectionBackColor = Color.RoyalBlue

            '---------------------------
            ' إعداد العنوان (Header)
            '---------------------------
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 70
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            '---------------------------
            ' إعداد الصفوف (Rows)
            '---------------------------
            .DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 55)
            .DefaultCellStyle.ForeColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180) ' لون أزرق أنيق عند التحديد
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5)
            '.RowTemplate.Height = 60

            '---------------------------
            ' الصفوف المتبادلة
            '---------------------------
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65)

            '---------------------------
            ' شكل الشبكة
            '---------------------------
            .GridColor = Color.FromArgb(80, 80, 80)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

            '---------------------------
            ' الإعدادات العامة
            '---------------------------
            .BackgroundColor = Color.FromArgb(30, 30, 35)
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False

            ' ✅ ضبط النص في المنتصف داخل الخلايا
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .ColumnHeadersVisible = True

            '.Columns("Category_ID").Visible = False
            '.Columns("ColorID").Visible = False
            '.Columns("PrinterID").Visible = False
            '.Columns("CategoryTypeID").Visible = False
            '.Columns("Imagebase64").Visible = False
            '.Columns("IsDeleted").Visible = False

            '.Columns("CategoryCode").HeaderText = "كود الفئة"
            '.Columns("Category_NameAr").HeaderText = "اسم الفئة عربي"
            '.Columns("CategoryNameEn").HeaderText = "اسم الفئة إنجليزي"
            '.Columns("Description").HeaderText = "وصف القسم"
            '.Columns("IsActive").HeaderText = "الحالة"
            '.Columns("ColorName").HeaderText = "اللون"
            '.Columns("PrinterName").HeaderText = "الطابعه"
            '.Columns("TypeName").HeaderText = "نوع الفئة"


            '' الترتيب
            '.Columns("Product_ID").DisplayIndex = 0
            '.Columns("Product_Code").DisplayIndex = 1
            '.Columns("Category_NameAr").Width = 300
            '.Columns("Unit_Name").DisplayIndex = 3
            '.Columns("Category_Name").DisplayIndex = 4
            '.Columns("Partner_Name").DisplayIndex = 5
            '.Columns("CompanyName").DisplayIndex = 6
            '.Columns("Product_Note").DisplayIndex = 7
            '.Columns("Product_State").DisplayIndex = 8
            '.Columns("Category_ID").Width = 200
            '.Columns("Category_Name").Width = 400
            '.Columns("Description").Width = 400
            '.Columns("IsActive").Width = 60

            ' ✅ عرض الأعمدة بالتساوي
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .MultiSelect = False
        End With
    End Sub
    ' 4. حدث التحديد التلقائي بأمان لعرض بيانات الصنف والصورة
    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If dgvProducts.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvProducts.SelectedRows(0)

        If row.Cells("Product_ID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Product_ID").Value) Then
            txtProductCode.Text = If(IsDBNull(row.Cells("ProductCode").Value), "", row.Cells("ProductCode").Value.ToString())
            txtProductNameAr.Text = If(IsDBNull(row.Cells("ProductNameAr").Value), "", row.Cells("ProductNameAr").Value.ToString())
            txtProductNameEn.Text = If(IsDBNull(row.Cells("ProductNameEn").Value), "", row.Cells("ProductNameEn").Value.ToString())
            txtDescription.Text = If(IsDBNull(row.Cells("Description").Value), "", row.Cells("Description").Value.ToString())
            txtDiscount.Text = If(IsDBNull(row.Cells("DiscountPercent").Value), "0", row.Cells("DiscountPercent").Value.ToString())
            txtTax.Text = If(IsDBNull(row.Cells("TaxPercent").Value), "0", row.Cells("TaxPercent").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            'txtPrepTime.Text = If(IsDBNull(row.Cells("PreparationTime").Value), "00:00:00", row.Cells("PreparationTime").Value.ToString())
            ' داخل دالة dgvProducts_SelectionChanged
            If Not IsDBNull(row.Cells("IsDiscountPercent").Value) Then
                btnDiscountType.Checked = Convert.ToBoolean(row.Cells("IsDiscountPercent").Value)
                ' هنا يمكنك تغيير لون الزر أو حالته البصرية ليطابق الـ Checked (مثلاً لون أخضر أو أزرق لو مفعل، ورمادي لو معطل)
            End If

            If Not IsDBNull(row.Cells("IsTaxPercent").Value) Then
                btnTaxType.Checked = Convert.ToBoolean(row.Cells("IsTaxPercent").Value)
            End If

            ' التعديل الخاص بعرض الوقت داخل دالة dgvProducts_SelectionChanged
            If Not IsDBNull(row.Cells("PreparationTime").Value) Then
                ' تحويل الـ TimeSpan القادم من قاعدة البيانات إلى DateTime ليقبله الكنترول
                Dim prepTime As TimeSpan = DirectCast(row.Cells("PreparationTime").Value, TimeSpan)
                dtpPrepTime.Value = DateTime.Today.Add(prepTime)
            Else
                dtpPrepTime.Value = DateTime.Today ' وقت افتراضي (00:00:00) في حال كان فارغاً
            End If

            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))

            ' تحديد القسم في الكومبو بوكس بناءً على الـ ID
            If Not IsDBNull(row.Cells("Category_ID").Value) Then
                cmbCategory.SelectedValue = row.Cells("Category_ID").Value
            Else
                cmbCategory.SelectedIndex = -1
            End If

            ' عرض الصورة المحولة من الـ Base64 بأمان
            If Not IsDBNull(row.Cells("Image").Value) AndAlso Not String.IsNullOrEmpty(row.Cells("Image").Value.ToString()) Then
                picProduct.Image = DBModule.Base64ToImage(row.Cells("Image").Value.ToString())
                picProduct.SizeMode = PictureBoxSizeMode.Zoom
            Else
                picProduct.Image = Nothing
            End If
        End If
    End Sub

    ' 5. زر إضافة صنف جديد
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO Products (ProductCode, ProductNameAr, ProductNameEn, Image, Description, DiscountPercent,IsDiscountPercent, TaxPercent,IsTaxPercent, IsActive, IsDeleted, PreparationTime, Notes, Category_ID) " &
                              "VALUES (@ProductCode, @ProductNameAr, @ProductNameEn, @Image, @Description, @DiscountPercent,@IsDiscountPercent, @TaxPercent,@IsTaxPercent, @IsActive, 0, @PreparationTime, @Notes, @Category_ID)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductCode", If(String.IsNullOrEmpty(txtProductCode.Text), DBNull.Value, txtProductCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@ProductNameAr", txtProductNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@ProductNameEn", If(String.IsNullOrEmpty(txtProductNameEn.Text), DBNull.Value, txtProductNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                'cmd.Parameters.AddWithValue("@DiscountPercent", If(String.IsNullOrEmpty(txtDiscount.Text), 0, Convert.ToDouble(txtDiscount.Text.Trim())))
                'cmd.Parameters.AddWithValue("@TaxPercent", If(String.IsNullOrEmpty(txtTax.Text), 0, txtTax.Text.Trim())) ' لو عدلته لـ float حوله لـ Convert.ToDouble
                ' 1. تمرير قيمة ونوع الخصم
                cmd.Parameters.AddWithValue("@DiscountPercent", If(String.IsNullOrEmpty(txtDiscount.Text), 0, Convert.ToDouble(txtDiscount.Text.Trim())))
                cmd.Parameters.AddWithValue("@IsDiscountPercent", btnDiscountType.Checked) ' حفظ حالة زر الخصم

                ' 2. تمرير قيمة ونوع الضريبة
                cmd.Parameters.AddWithValue("@TaxPercent", If(String.IsNullOrEmpty(txtTax.Text), 0, Convert.ToDouble(txtTax.Text.Trim())))
                cmd.Parameters.AddWithValue("@IsTaxPercent", btnTaxType.Checked) ' حفظ حالة زر الضريبة
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@Category_ID", cmbCategory.SelectedValue)

                '' وقت التحضير (Time)
                'Dim prepTime As TimeSpan
                'If TimeSpan.TryParse(txtPrepTime.Text, prepTime) Then
                '    cmd.Parameters.AddWithValue("@PreparationTime", prepTime)
                'Else
                '    cmd.Parameters.AddWithValue("@PreparationTime", DBNull.Value)
                'End If
                ' التعديل الخاص بالبارامتر داخل دالتي الحفظ والتعديل (Insert & Update)
                Dim selectedTime As TimeSpan = dtpPrepTime.Value.TimeOfDay
                cmd.Parameters.AddWithValue("@PreparationTime", selectedTime)

                ' حفظ الصورة كـ Base64
                Dim imgBase64 As String = DBModule.ImageToBase64(picProduct.Image)
                cmd.Parameters.AddWithValue("@Image", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ الصنف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadProductsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            ' 1. إعادة ملء الفئات المربوطة (في حال أضاف المستخدم فئات جديدة من الشاشة الأخرى)
            FillCategoriesComboBox()

            ' 2. إعادة تحميل داتا الأصناف بالكامل
            LoadProductsGrid()

            ' 3. تفريغ الحقول لتجنب التداخل
            ClearFields()

            MessageBox.Show("تم تحديث البيانات وجلب أحدث السجلات بنجاح!", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("حدثت مشكلة أثناء التحديث: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' 1. التحقق من تحديد صف من الجدول أولاً
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار الصنف المراد تعديله من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. خط الدفاع الأول: التحقق من صحة البيانات
        If Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)

        Dim query As String = "UPDATE Products SET ProductCode = @ProductCode, ProductNameAr = @ProductNameAr, " &
                              "ProductNameEn = @ProductNameEn, Image = @Image, Description = @Description, " &
                              "DiscountPercent = @DiscountPercent,IsDiscountPercent = @IsDiscountPercent, TaxPercent = @TaxPercent,IsTaxPercent = @IsTaxPercent, IsActive = @IsActive, " &
                              "PreparationTime = @PreparationTime, Notes = @Notes, Category_ID = @Category_ID " &
                              "WHERE Product_ID = @Product_ID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Product_ID", currentID)
                cmd.Parameters.AddWithValue("@ProductCode", If(String.IsNullOrEmpty(txtProductCode.Text), DBNull.Value, txtProductCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@ProductNameAr", txtProductNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@ProductNameEn", If(String.IsNullOrEmpty(txtProductNameEn.Text), DBNull.Value, txtProductNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                cmd.Parameters.AddWithValue("@DiscountPercent", If(String.IsNullOrEmpty(txtDiscount.Text), 0, Convert.ToDouble(txtDiscount.Text.Trim())))
                cmd.Parameters.AddWithValue("@IsDiscountPercent", btnDiscountType.Checked) ' حفظ حالة زر الخصم
                cmd.Parameters.AddWithValue("@TaxPercent", If(String.IsNullOrEmpty(txtTax.Text), 0, txtTax.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsTaxPercent", btnTaxType.Checked) ' حفظ حالة زر الضريبة
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@Category_ID", cmbCategory.SelectedValue)

                ' وقت التحضير من الـ Guna2DateTimePicker
                cmd.Parameters.AddWithValue("@PreparationTime", dtpPrepTime.Value.TimeOfDay)

                ' تحويل وصيانة الصورة كـ Base64
                Dim imgBase64 As String = DBModule.ImageToBase64(picProduct.Image)
                cmd.Parameters.AddWithValue("@Image", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل بيانات الصنف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadProductsGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار الصنف المراد حذفه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' رسالة تأكيد لحماية صيانة البيانات من الأخطاء العفوية
        Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا الصنف؟ (حذف ناعم)", "تأكيد الحذف",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If result = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Product_ID").Value)
            Dim query As String = "UPDATE Products SET IsDeleted = 1 WHERE Product_ID = @Product_ID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Product_ID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الصنف بنجاح بنمط الحذف الناعم!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadProductsGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' إيقاف التايمر مؤقتاً عند كل ضغطة زر
        _searchTimer.Stop()

        Dim keyword As String = txtSearch.Text.Trim()

        ' إذا قام المستخدم بمسح نص البحث، أظهر كل البيانات فوراً من الكاش دون انتظار التايمر
        If keyword.Length = 0 Then
            If _cachedProducts IsNot Nothing Then
                dgvProducts.DataSource = _cachedProducts
            Else
                LoadProductsGrid()
            End If
            Return
        End If

        ' ابدأ العد التنازلي للتنفيذ بعد توقف الكتابة
        _searchTimer.Start()
    End Sub


    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub
End Class


