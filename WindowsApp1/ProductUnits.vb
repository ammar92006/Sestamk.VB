Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.IO.Ports
Imports DevExpress.XtraTreeList
Imports ZXing
Imports ZXing.Common


Public Class ProductUnits
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim adapter As SqlDataAdapter
    Dim ds As New DataSet
    Dim cmdb As New SqlCommandBuilder


    Private _currentUnitID As Integer = 0

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = WindowState.Normal Then
            WindowState = FormWindowState.Maximized
        ElseIf WindowState.Maximized Then
            WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ProductUnits.CellClick
        'Try
        '    ' تجاهل الضغط على الهيدر
        '    If e.RowIndex < 0 Then Exit Sub

        '    Dim row As DataGridViewRow = dgv_ProductUnits.Rows(e.RowIndex)

        '    ' تعبئة البيانات في الحقول — حسب ترتيب الأعمدة في DataGridView
        '    ProductUnit_ID.Text = GetCellValue(row, "كود الوحدة")
        '    ProductUnit_ID.Text = GetCellValue(row, "ID المنتج")
        '    txt_Product_Name.Text = GetCellValue(row, "اسم المنتج")
        '    Unit_Name.Text = GetCellValue(row, "اسم الوحدة")
        '    Unit_Quantity.Text = GetCellValue(row, "عدد الوحدات الصغيرة داخلها")
        '    txt_Barcode.Text = GetCellValue(row, "الباركود")
        '    Purchase_Price.Text = GetCellValue(row, "سعر الشراء")
        '    Sale_Price.Text = GetCellValue(row, "سعر البيع")
        '    Notes.Text = GetCellValue(row, "الملاحظات")

        '    ' تحديد الصف المحدد فقط
        '    dgv_ProductUnits.ClearSelection()
        '    row.Selected = True
        '    lstSuggestions.Visible = False

        'Catch ex As Exception
        '    MessageBox.Show("❌ خطأ أثناء تحميل بيانات الصف: " & ex.Message)
        'End Try
        Try
            If e.RowIndex < 0 Then Exit Sub

            Dim row As DataGridViewRow = dgv_ProductUnits.Rows(e.RowIndex)

            ' ✅ حفظ كود الوحدة الحقيقي في المتغير المخصص
            Dim unitIDStr As String = GetCellValue(row, "كود الوحدة")
            Integer.TryParse(unitIDStr, _currentUnitID)

            ' ✅ عرض ID المنتج في الحقل (للإضافة/التعديل)
            ProductUnit_ID.Text = GetCellValue(row, "ID المنتج")

            txt_Product_Name.Text = GetCellValue(row, "اسم المنتج")
            txt_ProductCode.Text = GetCellValue(row, "كود المنتج")
            Unit_Name.Text = GetCellValue(row, "اسم الوحدة")
            Unit_Quantity.Text = GetCellValue(row, "عدد الوحدات الصغيرة داخلها")
            txt_Barcode.Text = GetCellValue(row, "الباركود")
            Purchase_Price.Text = GetCellValue(row, "سعر الشراء")
            Sale_Price.Text = GetCellValue(row, "سعر البيع")
            Notes.Text = GetCellValue(row, "الملاحظات")
            dgv_ProductUnits.ClearSelection()
            row.Selected = True
            lstSuggestions.Visible = False

        Catch ex As Exception
            MessageBox.Show("❌ خطأ أثناء تحميل بيانات الصف: " & ex.Message)
        End Try

    End Sub
    Private Function GetCellValue(row As DataGridViewRow, columnName As String) As String
        Try
            If row.Cells(columnName).Value Is Nothing OrElse IsDBNull(row.Cells(columnName).Value) Then
                Return ""
            End If
            Return row.Cells(columnName).Value.ToString()
        Catch
            Return ""
        End Try
    End Function

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        _currentUnitID = 0
        ProductUnit_ID.Clear()
        txt_Product_Name.Clear()
        Unit_Name.Clear()
        Unit_Quantity.Clear()
        txt_Barcode.Clear()
        Purchase_Price.Clear()
        Sale_Price.Clear()
        Notes.Clear()
        dgv_ProductUnits.ClearSelection()
        txtSearch.Clear()
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            Connect()
            Dim query As String = "INSERT INTO ProductUnits (Product_ID, Unit_Name, Unit_Quantity, Barcode, Purchase_Price, Sale_Price, Notes)
                               VALUES (@Product_ID, @Unit_Name, @Unit_Quantity, @Barcode, @Purchase_Price, @Sale_Price, @Notes)"
            Dim cmd As New SqlCommand(query, Conn)
            cmd.Parameters.AddWithValue("@Product_ID", ProductUnit_ID.Text)
            cmd.Parameters.AddWithValue("@Unit_Name", Unit_Name.Text)
            cmd.Parameters.AddWithValue("@Unit_Quantity", Unit_Quantity.Text)
            cmd.Parameters.AddWithValue("@Barcode", txt_Barcode.Text)
            cmd.Parameters.AddWithValue("@Purchase_Price", Purchase_Price.Text)
            cmd.Parameters.AddWithValue("@Sale_Price", Sale_Price.Text)
            cmd.Parameters.AddWithValue("@Notes", Notes.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("✅ تم إضافة الوحدة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Disconnect()
            btn_clear.PerformClick()
            LoadProductUnits() ' لإعادة تحميل البيانات
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء الإضافة: " & ex.Message)
        End Try
    End Sub
    Private Sub datagridviewsetup()
        With dgv_ProductUnits
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
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
            .ColumnHeadersHeight = 65
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
            .AllowUserToResizeRows = True
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False

            ' ✅ ضبط النص في المنتصف داخل الخلايا
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' ✅ إظهار عناوين الأعمدة (لو كانت مخفية)
            .ColumnHeadersVisible = True


            .Columns(0).Visible = False
            .Columns(1).Visible = False
            '.Columns("CustomerID").Visible = False

            '' ✅ عناوين الأعمدة
            '.Columns("CustomerCode").HeaderText = "كود العميل"
            '.Columns("CustomerName").HeaderText = "اسم العميل"
            '.Columns("PhoneNumber").HeaderText = "رقم الهاتف"
            '.Columns("Address").HeaderText = "العنوان"
            '.Columns("CreditLimit").HeaderText = "حد الائتمان"
            '.Columns("CurrentBalance").HeaderText = "الرصيد الحالي"
            '.Columns("IsActive").HeaderText = "الحالة"
            '.Columns("Notes").HeaderText = "الملاحظات"
            '.Columns("CreatedAt").HeaderText = "تاريخ الاضافة"
            '.Columns("UpdatedAt").HeaderText = "تاريخ اخر تحديث"

            '' الترتيب
            '.Columns("Product_ID").DisplayIndex = 0
            '.Columns("Product_Code").DisplayIndex = 1
            '.Columns("Product_Name").DisplayIndex = 2
            '.Columns("Unit_Name").DisplayIndex = 3
            '.Columns("Category_Name").DisplayIndex = 4
            '.Columns("Partner_Name").DisplayIndex = 5
            '.Columns("CompanyName").DisplayIndex = 6
            '.Columns("Product_Note").DisplayIndex = 7
            '.Columns("Product_State").DisplayIndex = 8
            .Columns(3).Width = 300
            '.Columns("IsActive").Width = 60


            ' ✅ عرض الأعمدة بالتساوي
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '' ✅ تحسين مظهر الصفوف
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
            '.DefaultCellStyle.Font = New Font("Segoe UI", 14)
            '.DefaultCellStyle.ForeColor = Color.Black
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255)
            '.DefaultCellStyle.SelectionForeColor = Color.White

            '' ✅ تحسين عناوين الأعمدة
            '.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            '.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 102, 153)
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.EnableHeadersVisualStyles = False   ' ← لازم False علشان التنسيق يبان فعلاً

            '' ✅ حدود الصفوف والخلايا
            '.GridColor = Color.LightGray
            '.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            '.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            '.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            ' ✅ شكل جميل للصفوف
            '.RowTemplate.Height = 100
            .MultiSelect = False
        End With
    End Sub

    Private Sub ProductUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductUnits()
        lstSuggestions.Visible = False
        lstSuggestions.BorderStyle = BorderStyle.FixedSingle
        lstSuggestions.BackColor = Color.FromArgb(45, 45, 48)
        lstSuggestions.ForeColor = Color.White
        lstSuggestions.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lstSuggestions.ItemHeight = 25
        cmbSearchField.Items.Add("كود الوحدة")
        cmbSearchField.Items.Add("كود المنتج")
        cmbSearchField.Items.Add("اسم الوحدة")
        cmbSearchField.Items.Add("عدد الوحدات الصغيرة داخلها")
        cmbSearchField.Items.Add("اسم المنتج")
        cmbSearchField.Items.Add("سعر الشراء")
        cmbSearchField.Items.Add("سعر البيع")
        cmbSearchField.Items.Add("الملاحظات")
        cmbSearchField.Items.Add("الباركود")
        'Style_Controls()

        txt_PrintCount.Text = 1
        'With dgv_ProductUnits
        '    '---------------------------
        '    ' إعداد العنوان (Header)
        '    '---------------------------
        '    .EnableHeadersVisualStyles = False
        '    .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43)
        '    .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        '    .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        '    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .ColumnHeadersHeight = 65
        '    .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

        '    '---------------------------
        '    ' إعداد الصفوف (Rows)
        '    '---------------------------
        '    .DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 55)
        '    .DefaultCellStyle.ForeColor = Color.White
        '    .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180) ' لون أزرق أنيق عند التحديد
        '    .DefaultCellStyle.SelectionForeColor = Color.White
        '    .DefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5)
        '    .RowTemplate.Height = 40

        '    '---------------------------
        '    ' الصفوف المتبادلة
        '    '---------------------------
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65)

        '    '---------------------------
        '    ' شكل الشبكة
        '    '---------------------------
        '    .GridColor = Color.FromArgb(80, 80, 80)
        '    .BorderStyle = BorderStyle.None
        '    .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

        '    '---------------------------
        '    ' الإعدادات العامة
        '    '---------------------------
        '    .BackgroundColor = Color.FromArgb(30, 30, 35)
        '    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        '    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        '    .RowHeadersVisible = False ' ✅ تم حل مشكلة الخطأ هنا
        '    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    .ReadOnly = True
        '    .AllowUserToAddRows = False
        '    .AllowUserToResizeRows = False
        '    .AllowUserToDeleteRows = False
        '    .AllowUserToResizeColumns = False
        'End With


        datagridviewsetup()
        btn_clear.PerformClick()
        cmbSearchField.SelectedIndex = 4
    End Sub
    Private Sub StyleDataGridView(dgv As DataGridView)
        With dgv
            '===============================
            '          العنوان (Header)
            '===============================
            .EnableHeadersVisualStyles = False
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 35)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 15, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 55

            '===============================
            '  الصفوف (Rows)
            '===============================
            .DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 45)
            .DefaultCellStyle.ForeColor = Color.WhiteSmoke
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 150, 220)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Segoe UI", 13, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Padding = New Padding(6)

            .RowTemplate.Height = 45

            ' صفوف متبادلة
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 55)

            '===============================
            '           الشبكة
            '===============================
            .GridColor = Color.FromArgb(65, 65, 70)
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

            '===============================
            '        الإعدادات العامة
            '===============================
            .BackgroundColor = Color.FromArgb(25, 25, 28)
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
        End With
    End Sub

    Private Sub PrintSelectedRowValues(dgv As DataGridView)

        If dgv.CurrentRow Is Nothing Then
            MessageBox.Show("❌ من فضلك اختر صف أولاً.")
            Exit Sub
        End If

        Dim msg As New System.Text.StringBuilder

        For Each col As DataGridViewColumn In dgv.Columns
            Dim colName As String = col.HeaderText
            Dim colValue As String = ""

            Try
                colValue = Convert.ToString(dgv.CurrentRow.Cells(col.Index).Value)
            Catch
                colValue = ""
            End Try

            msg.AppendLine(colName & ": " & colValue)
        Next

        MessageBox.Show(msg.ToString(), "بيانات الصف", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        'Try
        '    ' استدعاء دالة التحقق
        '    Dim result = ValidateAndConvertInputs()
        '    If Not result.IsValid Then
        '        MessageBox.Show(result.Message, "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Return
        '    End If

        '    Connect()

        '    Dim query As String = "
        '        UPDATE ProductUnits SET 
        '            Product_ID=@Product_ID,
        '            Unit_Name=@Unit_Name,
        '            Unit_Quantity=@Unit_Quantity,
        '            Barcode=@Barcode,
        '            Purchase_Price=@Purchase_Price,
        '            Sale_Price=@Sale_Price,
        '            Notes=@Notes
        '        WHERE ProductUnit_ID=@ProductUnit_ID"

        '    Using cmd As New SqlCommand(query, Conn)
        '        cmd.Parameters.AddWithValue("@ProductUnit_ID", result.UnitID)
        '        cmd.Parameters.AddWithValue("@Product_ID", result.ProductID)
        '        cmd.Parameters.AddWithValue("@Unit_Name", Unit_Name.Text)
        '        cmd.Parameters.AddWithValue("@Unit_Quantity", result.UnitQty)
        '        cmd.Parameters.AddWithValue("@Barcode", txt_Barcode.Text)
        '        cmd.Parameters.AddWithValue("@Purchase_Price", result.PurchasePrice)
        '        cmd.Parameters.AddWithValue("@Sale_Price", result.SalePrice)
        '        cmd.Parameters.AddWithValue("@Notes", Notes.Text)
        '        cmd.ExecuteNonQuery()
        '    End Using

        '    MessageBox.Show("✏️ تم تعديل البيانات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Disconnect()
        '    btn_clear.PerformClick()
        '    LoadProductUnits()

        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء التعديل: " & ex.Message)
        'End Try
        Try
            ' ✅ التحقق من وجود وحدة محددة
            If _currentUnitID = 0 Then
                MessageBox.Show("من فضلك اختر وحدة من الجدول أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim result = ValidateAndConvertInputs()
            If Not result.IsValid Then
                MessageBox.Show(result.Message, "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Connect()

            Dim query As String = "
            UPDATE ProductUnits SET 
                Product_ID      = @Product_ID,
                Unit_Name       = @Unit_Name,
                Unit_Quantity   = @Unit_Quantity,
                Barcode         = @Barcode,
                Purchase_Price  = @Purchase_Price,
                Sale_Price      = @Sale_Price,
                Notes           = @Notes
            WHERE ProductUnit_ID = @ProductUnit_ID"

            Using cmd As New SqlCommand(query, Conn)
                ' ✅ استخدام المتغير الصحيح في WHERE
                cmd.Parameters.AddWithValue("@ProductUnit_ID", _currentUnitID)
                cmd.Parameters.AddWithValue("@Product_ID", result.ProductID)
                cmd.Parameters.AddWithValue("@Unit_Name", Unit_Name.Text)
                cmd.Parameters.AddWithValue("@Unit_Quantity", result.UnitQty)
                cmd.Parameters.AddWithValue("@Barcode", txt_Barcode.Text)
                cmd.Parameters.AddWithValue("@Purchase_Price", result.PurchasePrice)
                cmd.Parameters.AddWithValue("@Sale_Price", result.SalePrice)
                cmd.Parameters.AddWithValue("@Notes", Notes.Text)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                ' ✅ التحقق الفعلي من أن التعديل تم
                If rowsAffected > 0 Then
                    MessageBox.Show("✏️ تم تعديل البيانات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("⚠️ لم يتم العثور على الوحدة في قاعدة البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using

            Disconnect()
            _currentUnitID = 0
            btn_clear.PerformClick()
            LoadProductUnits()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء التعديل: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        'Try
        '    If ProductUnit_ID.Text = "" Then
        '        MessageBox.Show("من فضلك اختر وحدة لحذفها أولاً")
        '        Return
        '    End If

        '    If MessageBox.Show("هل أنت متأكد من حذف هذه الوحدة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '        Connect()
        '        Dim query As String = "DELETE FROM ProductUnits WHERE ProductUnit_ID=@ProductUnit_ID"
        '        Dim cmd As New SqlCommand(query, Conn)
        '        cmd.Parameters.AddWithValue("@ProductUnit_ID", Convert.ToInt32(ProductUnit_ID.Text.Trim))
        '        cmd.ExecuteNonQuery()
        '        Disconnect()
        '        MessageBox.Show("🗑️ تم حذف الوحدة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        btn_clear.PerformClick()
        '        LoadProductUnits()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        'End Try
        Try
            If _currentUnitID = 0 Then
                MessageBox.Show("من فضلك اختر وحدة لحذفها أولاً")
                Return
            End If

            If MessageBox.Show("هل أنت متأكد من حذف هذه الوحدة؟", "تأكيد الحذف",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Connect()
                Dim query As String = "DELETE FROM ProductUnits WHERE ProductUnit_ID = @ProductUnit_ID"
                Dim cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@ProductUnit_ID", _currentUnitID)
                cmd.ExecuteNonQuery()
                Disconnect()
                MessageBox.Show("🗑️ تم حذف الوحدة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _currentUnitID = 0
                btn_clear.PerformClick()
                LoadProductUnits()
            End If
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        End Try
    End Sub

    'Private Sub LoadData()
    '    ds.Tables.Clear()
    '    '        Dim query As String = "SELECT ProductUnit_ID as 'كود الوحدة',
    '    'PU.Product_ID as 'كود المنتج',
    '    'P.Product_Name as 'اسم المنتج',
    '    'PU.Unit_Name as 'اسم الوحدة',
    '    'PU.Unit_Quantity as 'عدد الوحدات الصغيرة داخلها',
    '    'PU.Barcode as 'الباركود',
    '    'PU.Purchase_Price as 'سعر الشراء',
    '    'PU.Sale_Price as 'سعر البيع',
    '    'PU.Notes as 'الملاحظات' 
    '    'From ProductUnits AS PU
    '    'LEFT JOIN
    '    '   dbo.Products AS P ON P.Product_ID = PU.Product_ID "
    '    '        Connect()
    '    '        adapter = New SqlDataAdapter(query, Conn)
    '    '        adapter.Fill(ds, "ProductUnits")
    '    '        DataGridView1.DataSource = ds.Tables("ProductUnits")
    '    '        Disconnect()


    '    Dim query As String = "
    '    SELECT 
    '        ProductUnit_ID as 'كود الوحدة',
    '        PU.Product_ID as 'كود المنتج',
    '        P.Product_Name as 'اسم المنتج',
    '        PU.Unit_Name as 'اسم الوحدة',
    '        PU.Unit_Quantity as 'عدد الوحدات الصغيرة داخلها',
    '        PU.Barcode as 'الباركود',
    '        PU.Purchase_Price as 'سعر الشراء',
    '        PU.Sale_Price as 'سعر البيع',
    '        PU.Notes as 'الملاحظات'
    '    FROM ProductUnits AS PU
    '    LEFT JOIN dbo.Products AS P ON P.Product_ID = PU.Product_ID"

    '    Connect()
    '    adapter = New SqlDataAdapter(query, Conn)

    '    If ds.Tables.Contains("ProductUnits") Then
    '        ds.Tables("ProductUnits").Clear()
    '    End If

    '    adapter.Fill(ds, "ProductUnits")
    '    dgv_ProductUnits.DataSource = ds.Tables("ProductUnits")

    '    ' مفتاح أساسي
    '    If Not ds.Tables("ProductUnits").Constraints.Contains("PrimaryKey") Then
    '        ds.Tables("ProductUnits").Constraints.Add("PrimaryKey", ds.Tables("ProductUnits").Columns("كود الوحدة"), True)
    '    End If


    'End Sub

    Private Sub LoadProductUnits(Optional filter As String = "", Optional field As String = "")
        Using Conn
            ProductUnit_ID.Clear()
            ProductUnit_ID.Clear()
            txt_Product_Name.Clear()
            Unit_Name.Clear()
            Unit_Quantity.Clear()
            txt_Barcode.Clear()
            Purchase_Price.Clear()
            Sale_Price.Clear()
            Notes.Clear()
            dgv_ProductUnits.ClearSelection()
            Dim query As String = "SELECT 
            ProductUnit_ID as 'كود الوحدة',
            P.Product_ID as 'ID المنتج',
            P.Product_Code as 'كود المنتج',
            P.Product_Name as 'اسم المنتج',
            PU.Unit_Name as 'اسم الوحدة',
            PU.Unit_Quantity as 'عدد الوحدات الصغيرة داخلها',
            PU.Barcode as 'الباركود',
            PU.Purchase_Price as 'سعر الشراء',
            PU.Sale_Price as 'سعر البيع',
            PU.Notes as 'الملاحظات'
            FROM ProductUnits AS PU
            LEFT JOIN dbo.Products AS P ON P.Product_ID = PU.Product_ID"
            Connect()
            If filter <> "" Then
                Dim columnName As String = ""
                Select Case field
                    Case "كود الوحدة"
                        columnName = "ProductUnit_ID"
                    Case "كود المنتج"
                        columnName = "Product_Code"
                    Case "اسم الوحدة"
                        columnName = "Unit_Name"
                    Case "عدد الوحدات الصغيرة داخلها"
                        columnName = "Unit_Quantity"
                    Case "اسم المنتج"
                        columnName = "Product_Name"
                    Case "سعر الشراء"
                        columnName = "Purchase_Price"
                    Case "سعر البيع"
                        columnName = "Sale_Price"
                    Case "الملاحظات"
                        columnName = "Notes"
                    Case "الباركود"
                        columnName = "Barcode"
                End Select

                If columnName <> "" Then
                    query &= $" WHERE {columnName} LIKE @filter"
                End If
            End If

            Dim cmd As New SqlCommand(query, Conn)
            If filter <> "" Then cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgv_ProductUnits.DataSource = dt
            Disconnect()
        End Using
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        Try
            If String.IsNullOrWhiteSpace(txt_Product_Name.Text) Then
                MsgBox("من فضلك أدخل اسم المنتج.", vbExclamation)
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(Unit_Name.Text) Then
                MsgBox("من فضلك أدخل اسم الوحدة.", vbExclamation)
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(Sale_Price.Text) Then
                MsgBox("من فضلك أدخل سعر البيع.", vbExclamation)
                Exit Sub
            End If

            If Not IsNumeric(Sale_Price.Text) Then
                MsgBox("سعر البيع يجب أن يكون رقم.", vbExclamation)
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txt_Barcode.Text) Then
                MsgBox("من فضلك أدخل الباركود.", vbExclamation)
                Exit Sub
            End If

            If txt_Barcode.Text.Length < 4 Then
                MsgBox("الباركود قصير جدًا وغير صالح.", vbExclamation)
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txt_PrintCount.Text) Then
                MsgBox("من فضلك أدخل عدد النسخ.", vbExclamation)
                Exit Sub
            End If

            If Not IsNumeric(txt_PrintCount.Text) OrElse CInt(txt_PrintCount.Text) <= 0 Then
                MsgBox("عدد النسخ يجب أن يكون رقم أكبر من صفر.", vbExclamation)
                Exit Sub
            End If

            ' ==============================
            ' 2) قيمة العدد
            ' ==============================
            Dim copies As Integer = CInt(txt_PrintCount.Text)

            ' ==============================
            ' 3) استخراج القيم
            ' ==============================
            Dim productName As String = txt_Product_Name.Text.Trim()
            Dim unitName As String = Unit_Name.Text.Trim()
            Dim Price_sales As String = Sale_Price.Text.Trim()
            Dim barcodeText As String = txt_Barcode.Text.Trim()

            ' ==============================
            ' 4) حلقة الطباعة
            ' ==============================
            For i As Integer = 1 To copies

                Dim pd As New PrintDocument()
                pd.PrinterSettings = New PrinterSettings With {
            .PrinterName = "Xprinter XP-233B"
        }

                pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                pd.OriginAtMargins = False
                'AddHandler pd.PrintPage,
                'Sub(s, ev)
                '    ' ===== استخدام عرض الصفحة الحالي =====
                '    Dim labelWidthPx As Integer = ev.PageBounds.Width

                '    ' ===== إعداد الباركود =====
                '    Dim writer As New ZXing.BarcodeWriter()
                '    writer.Format = ZXing.BarcodeFormat.CODE_128
                '    writer.Options = New ZXing.Common.EncodingOptions With {
                '        .Height = 45,
                '        .Width = labelWidthPx - 4,
                '        .Margin = 0,
                '        .PureBarcode = True
                '    }

                '    Dim barcodeImg As Bitmap = writer.Write(barcodeText)

                '    ' ===== مركز الباركود أفقياً =====
                '    Dim centerX As Integer = (labelWidthPx - barcodeImg.Width) - 15
                '    Dim startY As Integer = 4
                '    ev.Graphics.DrawImage(barcodeImg, centerX, startY)
                '    Dim fullText As String = $"{productName} {unitName} {Price_sales}"
                '    Dim font As New Font("Arial", 7, FontStyle.Bold)
                '    Dim textSize As SizeF = ev.Graphics.MeasureString(fullText, font)
                '    Dim textX As Single = (labelWidthPx - textSize.Width) - 15
                '    Dim textY As Single = startY + barcodeImg.Height + 7
                '    Dim textY2 As Single = startY + barcodeImg.Height + 7 + 5
                '    ev.Graphics.DrawString(fullText, font, Brushes.Black, textX, textY)
                '    ev.Graphics.DrawString("نص الصلاحية هنا ", font, Brushes.Black, textX, textY2)
                '    Dim storeText As String = "ماركت الحمد والرضا - 01095032689"
                '    Dim storeFont As New Font("Arial", 7, FontStyle.Bold)
                '    Dim storeSize As SizeF = ev.Graphics.MeasureString(storeText, storeFont)
                '    Dim storeX As Single = (labelWidthPx - storeSize.Width) - 15
                '    Dim storeY As Single = textY + 27
                '    ev.Graphics.DrawString(storeText, storeFont, Brushes.Black, storeX, storeY)
                '    ev.HasMorePages = False
                'End Sub
                'pd.Print()

                AddHandler pd.PrintPage,
Sub(s, ev)
    Dim labelWidthPx As Integer = ev.PageBounds.Width

    ' ===== إعداد الباركود =====
    Dim writer As New ZXing.BarcodeWriter()
    writer.Format = ZXing.BarcodeFormat.CODE_128
    writer.Options = New ZXing.Common.EncodingOptions With {
        .Height = 45,
        .Width = labelWidthPx - 4,
        .Margin = 0,
        .PureBarcode = True
    }

    Dim barcodeImg As Bitmap = writer.Write(barcodeText)

    ' ===== مركز الباركود أفقياً =====
    Dim centerX As Integer = (labelWidthPx - barcodeImg.Width) - 15
    Dim startY As Integer = 4
    ev.Graphics.DrawImage(barcodeImg, centerX, startY)

    ' ===== النص الأساسي =====
    Dim fullText As String = $"{productName} - {unitName} | {Price_sales}"
    Dim font As New Font("Arial", 7, FontStyle.Bold)

    Dim textSize As SizeF = ev.Graphics.MeasureString(fullText, font)
    Dim textX As Single = (labelWidthPx - textSize.Width) - 15
    Dim textY As Single = startY + barcodeImg.Height + 7

    ev.Graphics.DrawString(fullText, font, Brushes.Black, textX, textY)

    ' ===== تاريخ الصلاحية =====
    'Dim expDate As DateTimeOffset = CType(Guna2DateTimePicker1.EditValue, DateTimeOffset)
    'Dim expText As String = $"تاريخ الصلاحية: {expDate:yyyy/MM/dd HH:mm:ss}"

    'Dim textY2 As Single = textY + 15
    'ev.Graphics.DrawString(expText, font, Brushes.Black, textX, textY2)

    ' ===== تاريخ الصلاحية (لو موجود) =====
    ' ✅ الإصلاح: Date هو Value Type ولا يقبل IsNot Nothing
    ' لذلك نقارن بـ Date.MinValue بدلاً من Nothing
    If Guna2DateTimePicker1.Value <> Date.MinValue Then

        Dim expDate As DateTimeOffset =
        CType(Guna2DateTimePicker1.Value, DateTimeOffset)


        Dim textY2 As Single = textY + 15
        Dim textX2 As Single = (labelWidthPx - textSize.Width) - 15

        Dim today As DateTimeOffset = DateTimeOffset.Now
        Dim remainingDays As Integer =
        CInt(Math.Floor((expDate - today).TotalDays))

        Dim remainText As String

        If remainingDays >= 0 Then
            remainText = $"{remainingDays} يوم"
        Else
            remainText = $"منتهي منذ {Math.Abs(remainingDays)} يوم"
        End If
        Dim expText As String =
        $"تاريخ الصلاحية: {expDate:yyyy/MM/dd} {remainText}"

        ev.Graphics.DrawString(expText, font, Brushes.Black, textX2, textY2)

    End If



    ' ===== اسم المحل =====
    Dim storeText As String = "ماركت الحمد والرضا - 01095032689"
    Dim storeFont As New Font("Arial", 7, FontStyle.Bold)

    Dim storeSize As SizeF = ev.Graphics.MeasureString(storeText, storeFont)
    Dim storeX As Single = (labelWidthPx - storeSize.Width) - 15
    Dim storeY As Single = textY + 27

    ev.Graphics.DrawString(storeText, storeFont, Brushes.Black, storeX, storeY)

    ev.HasMorePages = False
End Sub

                pd.Print()

            Next
        Catch ex As Exception
            MsgBox("خطأ في الطباعة: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        btn_clear.PerformClick()
        LoadProductUnits()
    End Sub

    Private Sub btnSearchByID_Click(sender As Object, e As EventArgs) Handles btnSearchByID.Click
        ' تأكد إن المستخدم كتب رقم ID
        If String.IsNullOrWhiteSpace(ProductUnit_ID.Text) Then
            MessageBox.Show("من فضلك أدخل كود المنتج أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try

            Connect()
            ' استعلام البحث
            Dim cmd As New SqlCommand("SELECT Product_Name FROM Products WHERE Product_ID = @id", Conn)
            cmd.Parameters.AddWithValue("@id", ProductUnit_ID.Text)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                txt_Product_Name.Text = reader("Product_Name").ToString()
            Else
                MessageBox.Show("لم يتم العثور على المنتج بهذا الكود", "نتيجة البحث", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_Product_Name.Clear()
            End If

            reader.Close()
            Disconnect()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء البحث: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearchByName_Click(sender As Object, e As EventArgs) Handles btnSearchByName.Click
        ' تأكد إن المستخدم كتب اسم المنتج
        If String.IsNullOrWhiteSpace(txt_Product_Name.Text) Then
            MessageBox.Show("من فضلك أدخل اسم المنتج أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try

            Connect()
            ' استعلام البحث
            Dim cmd As New SqlCommand("SELECT Product_ID FROM Products WHERE Product_Name = @name", Conn)
            cmd.Parameters.AddWithValue("@name", txt_Product_Name.Text)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ProductUnit_ID.Text = reader("Product_ID").ToString()
            Else
                MessageBox.Show("لم يتم العثور على المنتج بهذا الاسم", "نتيجة البحث", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ProductUnit_ID.Clear()
            End If

            reader.Close()
            Disconnect()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء البحث: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txt_Product_Name_TextChanged(sender As Object, e As EventArgs) Handles txt_Product_Name.TextChanged
        lstSuggestions.Items.Clear()

        Dim searchText As String = txt_Product_Name.Text.Trim()
        If searchText = "" Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Try
            Using Conn
                Connect()
                Dim cmd As New SqlCommand("SELECT Product_Name FROM Products WHERE Product_Name LIKE @name + '%'", Conn)
                cmd.Parameters.AddWithValue("@name", searchText)

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    lstSuggestions.Items.Add(reader("Product_Name").ToString())
                End While
                reader.Close()
                Disconnect()
            End Using

            lstSuggestions.Visible = lstSuggestions.Items.Count > 0
            lstSuggestions.BringToFront()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء تحميل الاقتراحات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lstSuggestions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSuggestions.SelectedIndexChanged
        If lstSuggestions.SelectedItem Is Nothing Then Exit Sub

        txt_Product_Name.Text = lstSuggestions.SelectedItem.ToString()
        lstSuggestions.Visible = False

        ' بعد اختيار الاسم نجيب الكود من قاعدة البيانات
        Try
            Using Conn
                Connect()
                Dim cmd As New SqlCommand("SELECT Product_ID FROM Products WHERE Product_Name = @name", Conn)
                cmd.Parameters.AddWithValue("@name", txt_Product_Name.Text)

                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    ProductUnit_ID.Text = result.ToString()
                Else
                    ProductUnit_ID.Clear()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء جلب كود المنتج: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        Try
            ' ✅ تحقق من أن المستخدم اختار عمود وأدخل قيمة
            If cmbSearchField.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(txtSearch.Text) Then
                MessageBox.Show("من فضلك اختر عمود واكتب قيمة للبحث", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' ✅ تجهيز المتغيرات
            Dim columnName As String = cmbSearchField.SelectedValue.ToString().Trim()
            Dim searchValue As String = txtSearch.Text.Trim().Replace("'", "''")

            ' ✅ بناء الاستعلام بطريقة آمنة
            Dim query As String = $"
        SELECT 
            PU.ProductUnit_ID AS 'كود الوحدة',
            PU.Product_ID AS 'كود المنتج',
            P.Product_Name AS 'اسم المنتج',
            PU.Unit_Name AS 'اسم الوحدة',
            PU.Unit_Quantity AS 'عدد الوحدات الصغيرة داخلها',
            PU.Barcode AS 'الباركود',
            PU.Purchase_Price AS 'سعر الشراء',
            PU.Sale_Price AS 'سعر البيع',
            PU.Notes AS 'الملاحظات'
        FROM ProductUnits AS PU
        LEFT JOIN dbo.Products AS P ON P.Product_ID = PU.Product_ID
        WHERE PU.{columnName} LIKE @value
        ORDER BY P.Product_Name ASC;
    "

            ' ✅ الاتصال بقاعدة البيانات
            Connect()

            Using cmd As New SqlCommand(query, Conn)
                ' ✅ تمرير القيمة بشكل آمن
                cmd.Parameters.AddWithValue("@value", "%" & searchValue & "%")

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                ' ✅ عرض النتائج
                If dt.Rows.Count > 0 Then
                    dgv_ProductUnits.DataSource = dt
                Else
                    dgv_ProductUnits.DataSource = Nothing
                    MessageBox.Show("لا توجد نتائج مطابقة للبحث.", "نتيجة البحث", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        Catch ex As SqlException
            MessageBox.Show("خطأ في الاتصال أو الاستعلام بقاعدة البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("حدث خطأ غير متوقع أثناء البحث: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' ✅ إغلاق الاتصال بأمان
            Disconnect()
        End Try

    End Sub



    Private Sub Style_Controls()

        ' إعداد الخط الموحد
        Dim txtFont As New Font("Segoe UI", 16, FontStyle.Bold)

        '-------------------------------
        ' تنسيق TextBox العناصر
        '-------------------------------
        With ProductUnit_ID
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With txtSearch
            .TextAlign = HorizontalAlignment.Center
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With ProductUnit_ID
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With txt_Product_Name
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With Unit_Name
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With Unit_Quantity
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With txt_Barcode
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With Purchase_Price
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With Sale_Price
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

        With Notes
            .TextAlign = HorizontalAlignment.Center
            .Font = txtFont
            .ForeColor = Color.Black
            .BackColor = Color.White
        End With

    End Sub

    Private Sub btn_scan_bar_Click(sender As Object, e As EventArgs) Handles btn_scan_bar.Click
        Try
            ' التأكد إن المنفذ مفتوح
            'If Not barcodePort.IsOpen Then
            '    barcodePort.Open()
            'End If

            MessageBox.Show("في انتظار قراءة الباركود من جهاز السكانر المتصل", "انتظار", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء محاولة فتح المنفذ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' ✅ دالة لاستخراج الباركود بطريقة آمنة ومنظمة
    ' تعريف المنفذ الخاص بالسكانر
    'Private WithEvents scannerPort As New SerialPort("COM9", 9600, Parity.None, 8, StopBits.One)

    ' ✅ دالة قراءة الباركود (بشكل عام)
    Public Function GetScannedBarcode(ByVal scannedText As String) As String
        Try
            ' التحقق من وجود رقم المنتج أولاً
            If String.IsNullOrWhiteSpace(ProductUnit_ID.Text) Then
                MessageBox.Show("من فضلك اختر المنتج أولاً قبل مسح الباركود.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ProductUnit_ID.Focus()
                Return Nothing
            End If

            ' التحقق من أن الباركود فعلاً مقروء
            If String.IsNullOrWhiteSpace(scannedText) Then
                MessageBox.Show("لم يتم قراءة أي باركود. حاول المسح مرة أخرى.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End If

            ' إزالة أي رموز غير مقروءة من السكانر (أحياناً تضيف رموز تحكم)
            scannedText = System.Text.RegularExpressions.Regex.Replace(scannedText, "[^\w\-]", "")

            ' ✅ نجاح العملية
            Return scannedText

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء قراءة الباركود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Private Sub btn_generate_barcode_Click(sender As Object, e As EventArgs) Handles btn_generate_barcode.Click
        Try
            ' التحقق من وجود رقم الوحدة
            If String.IsNullOrWhiteSpace(ProductUnit_ID.Text) Then
                MessageBox.Show("من فضلك أدخل رقم الوحدة أولاً قبل توليد الباركود.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ProductUnit_ID.Focus()
                Exit Sub
            End If

            ' جلب رقم الوحدة
            Dim unitId As String = ProductUnit_ID.Text.Trim()

            ' التحقق أن رقم الوحدة رقم فعلاً
            If Not IsNumeric(unitId) Then
                MessageBox.Show("رقم الوحدة يجب أن يكون رقمياً فقط.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' ✅ توليد رقم باركود فريد مبني على رقم الوحدة والتاريخ والوقت
            ' الصيغة: [رقم الوحدة][آخر رقمين من السنة][الشهر][اليوم][دقيقتين][ثانيتين]
            Dim generatedBarcode As String = unitId & DateTime.Now.ToString("yyMMdd")

            ' وضع الباركود في التكست بوكس الخاص به
            txt_Barcode.Text = generatedBarcode

            ' رسالة نجاح
            MessageBox.Show("تم توليد رقم الباركود بنجاح: " & generatedBarcode, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء توليد الباركود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' ✅ استقبال البيانات من السكانر (عند المسح)
    Public Sub scannerPort_DataReceived(code As String)
        If txtSearch.Focused AndAlso cmbSearchField.Text = "الباركود" Then
            txtSearch.Text = code
            Exit Sub
        End If
        Try
            ' استدعاء المعالجة داخل الـ UI Thread
            Me.Invoke(Sub()
                          txt_Barcode.Focus()
                          txt_Barcode.Text = code
                          MessageBox.Show("تم قراءة الباركود: " & code, "تم بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                      End Sub)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء استقبال البيانات من السكانر: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseDown, Label1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseMove, Label1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()
        lstSuggestions.Items.Clear()

        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            LoadProductUnits() ' عرض الكل لو البحث فاضي
            Exit Sub
        End If

        Dim field As String = cmbSearchField.SelectedItem.ToString()
        'Dim suggestions = GetSuggestions(field, keyword)

        'If suggestions.Count > 0 Then
        '    lstSuggestions.Items.AddRange(suggestions.ToArray())
        '    lstSuggestions.Visible = True
        'Else
        'lstSuggestions.Visible = False
        'End If

        LoadProductUnits(keyword, field)
    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs)
        'Guna2DateTimePicker1.Clear()
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized

    End Sub

    Private Function ValidateAndConvertInputs() As (IsValid As Boolean,
                                                    UnitID As Integer,
                                                    ProductID As Integer,
                                                    UnitQty As Decimal,
                                                    PurchasePrice As Decimal,
                                                    SalePrice As Decimal,
                                                    Message As String)
        ' التحقق من الفراغات
        If String.IsNullOrWhiteSpace(ProductUnit_ID.Text) Then
            Return (False, 0, 0, 0, 0, 0, "من فضلك اختر وحدة أولاً.")
        End If

        If String.IsNullOrWhiteSpace(ProductUnit_ID.Text) Then
            Return (False, 0, 0, 0, 0, 0, "كود المنتج فارغ.")
        End If

        If String.IsNullOrWhiteSpace(Unit_Quantity.Text) Then
            Return (False, 0, 0, 0, 0, 0, "عدد الوحدات فارغ.")
        End If

        If String.IsNullOrWhiteSpace(Purchase_Price.Text) Then
            Return (False, 0, 0, 0, 0, 0, "سعر الشراء فارغ.")
        End If

        If String.IsNullOrWhiteSpace(Sale_Price.Text) Then
            Return (False, 0, 0, 0, 0, 0, "سعر البيع فارغ.")
        End If

        ' محاولة التحويل
        Dim unitID As Integer, productID As Integer
        Dim unitQty As Decimal, purchasePrice As Decimal, salePrice As Decimal

        If Not Integer.TryParse(ProductUnit_ID.Text.Trim, unitID) Then
            Return (False, 0, 0, 0, 0, 0, "كود الوحدة غير صالح.")
        End If

        If Not Integer.TryParse(ProductUnit_ID.Text.Trim, productID) Then
            Return (False, 0, 0, 0, 0, 0, "كود المنتج غير صالح.")
        End If

        If Not Decimal.TryParse(Unit_Quantity.Text.Trim, NumberStyles.Any, CultureInfo.InvariantCulture, unitQty) Then
            Return (False, 0, 0, 0, 0, 0, "كمية الوحدة غير صالحة.")
        End If

        If Not Decimal.TryParse(Purchase_Price.Text.Trim, NumberStyles.Any, CultureInfo.InvariantCulture, purchasePrice) Then
            Return (False, 0, 0, 0, 0, 0, "سعر الشراء غير صالح.")
        End If

        If Not Decimal.TryParse(Sale_Price.Text.Trim, NumberStyles.Any, CultureInfo.InvariantCulture, salePrice) Then
            Return (False, 0, 0, 0, 0, 0, "سعر البيع غير صالح.")
        End If

        ' ✅ لو كله تمام
        Return (True, unitID, productID, unitQty, purchasePrice, salePrice, "")
    End Function

End Class