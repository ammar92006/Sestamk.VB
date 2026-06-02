Imports System.Data.SqlClient
Imports DevExpress.Utils.About
Imports DocumentFormat.OpenXml.ExtendedProperties
Imports Org.BouncyCastle.Crypto.Operators
''' <summary>
''' 
''' </summary>
Public Class Stock
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim Stock_ID As Integer
    Dim ProductId As Integer
    Private Product_Image As String = ""
    Dim manager As New SalesManager()

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Stock_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Guna2Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseDown, panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Guna2Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseMove, panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Stock_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Public Sub ProcessBarcodeData(code As String)
        Dim Barcode As String = ""
        Try
            Barcode = code.Trim

            If String.IsNullOrWhiteSpace(Barcode) Then Exit Sub
            If SearchAndFillProductByBarcode(Barcode) Then
                'txtQuantity.Text = "1"
                'btn_add_product.PerformClick()
            End If


        Catch ex As Exception
            ' تجاهل الخطأ بدون توقف البرنامج
        End Try
    End Sub
    Private Function SearchAndFillProductByBarcode(ByVal barcodeValue As String) As Boolean

        Try
            Dim dtUnit As DataTable = manager.GetUnitByBarcode(barcodeValue)
            If dtUnit.Rows.Count = 1 Then
                Dim row As DataRow = dtUnit.Rows(0)
                cmbSearchField.SelectedIndex = 1
                txtSearch.Text = row("Product_Name").ToString()
                txtSearch.Focus()
                txtSearch.SelectAll()
                Return True
            Else
                MessageBox.Show($"لا يوجد منتج مرتبط بالباركود: {barcodeValue}",
                                "منتج غير موجود",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)

                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ في البحث عن الباركود: " & ex.Message,
                            "خطأ قاعدة بيانات",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub Stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' [FIX] تفعيل DoubleBuffered لتقليل الـ Flickering
        EnableDoubleBuffer(dgvProducts)
        'dgvProducts.DataSource = Nothing
        LoadStockData()

        setuptxt()

        cmbSearchField.Items.AddRange({
                                 "كود المنتج",
                                 "اسم المنتج",
                                 "المخزون المتوفر",
                                 "الوحدة الأساسية",
                                 "حد الطلب الادني",
                                 "الإجمالي (أساسية)",
                                 "القسم",
                                 "اسم المورد"
                                 })

        cmbSearchField.SelectedIndex = 1

        Dim lowCount = CountLowStockProducts()
        lblLowStockCount.Text = lowCount.ToString()
        dgvProducts.ClearSelection()
        Connect()
        AutoInsertMissingStock(Conn)
    End Sub

    Private Sub AutoInsertMissingStock(conn As SqlConnection)
        Dim sql As String = "
        SELECT P.Product_ID
        FROM Products P
        LEFT JOIN Stock S ON P.Product_ID = S.Product_ID
        WHERE S.Product_ID IS NULL;"

        Dim missingList As New List(Of Integer)
        Connect()

        Using cmd As New SqlCommand(sql, conn)
            Connect()

            Using r = cmd.ExecuteReader()
                Connect()

                While r.Read()
                    Connect()

                    missingList.Add(Convert.ToInt32(r(0)))
                End While
            End Using
        End Using

        If missingList.Count = 0 Then Exit Sub

        For Each ProductId In missingList
            Dim insertSQL As String = "
            INSERT INTO Stock (Product_ID, Quantity_OnHand, Min_Quantity, Last_Update)
            VALUES (@PID, 0, 0, GETDATE());"

            Using cmd As New SqlCommand(insertSQL, conn)
                cmd.Parameters.AddWithValue("@PID", ProductId)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub
    'Private Sub LoadStockData()
    '    Try
    '        Connect()
    '        AutoInsertMissingStock(Conn)

    '        Dim manager As New StockManager()
    '        Dim dataList As List(Of StockDisplayItem) = manager.GetDecomposedStockData()

    '        If dataList Is Nothing OrElse dataList.Count = 0 Then
    '            MessageBox.Show("لا توجد بيانات لعرضها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If

    '        dgvProducts.DataSource = dataList

    '        SetupDataGridView(dgvProducts)
    '        'SetupDataGridViewSystem(dgvProducts)
    '        AddStockStatusColumn()
    '        HighlightLowStockRows()


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "خطأ في تحميل البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub LoadStockData(Optional filter As String = "", Optional field As String = "")
        Try
            Connect()
            ProductCode.Clear()
            txtProductName.Clear()
            DisplayStockQuantity.Clear()
            txtBaseUnitName.Clear()
            txtMinQty.Clear()
            txtQty.Clear()
            txtPartner_Name.Clear()
            txtCategoryName.Clear()
            ProductId = 0
            Stock_ID = 0
            dgvProducts.ClearSelection()
            Product_Image = ""
            Pic_Product.Image = My.Resources.لا_يوجد_صورة_للمنتج

            Dim manager As New StockManager()
            'Dim dataList As List(Of StockDisplayItem) = manager.GetFilteredStockData(filter, field)
            Dim dataList As List(Of StockDisplayItem) = manager.GetDecomposedStockData_FAST(filter, field)

            dgvProducts.DataSource = dataList

            AddStockStatusColumn()
            HighlightLowStockRows()
            datagridviewsetup()

            'SetupDataGridView(dgvProducts)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "خطأ في تحميل البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub


    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        LoadStockData()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        ' التأكد إن المستخدم ضغط على صف صالح
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvProducts.Rows(e.RowIndex)
            ProductCode.Text = If(selectedRow.Cells("ProductCode").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ProductCode").Value), selectedRow.Cells("ProductCode").Value.ToString(), "")
            txtProductName.Text = If(selectedRow.Cells("ProductName").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ProductName").Value), selectedRow.Cells("ProductName").Value.ToString(), "")
            DisplayStockQuantity.Text = If(selectedRow.Cells("DisplayStockQuantity").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("DisplayStockQuantity").Value), selectedRow.Cells("DisplayStockQuantity").Value.ToString(), "")
            txtBaseUnitName.Text = If(selectedRow.Cells("BaseUnitName").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("BaseUnitName").Value), selectedRow.Cells("BaseUnitName").Value.ToString(), "")
            txtMinQty.Text = If(selectedRow.Cells("MinQuantity").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("MinQuantity").Value), selectedRow.Cells("MinQuantity").Value.ToString(), "")
            txtQty.Text = If(selectedRow.Cells("BaseQuantityTotal").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("BaseQuantityTotal").Value), selectedRow.Cells("BaseQuantityTotal").Value, "")
            txtPartner_Name.Text = If(selectedRow.Cells("Partner_Name").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("Partner_Name").Value), selectedRow.Cells("Partner_Name").Value.ToString(), "")
            txtCategoryName.Text = If(selectedRow.Cells("CategoryName").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("CategoryName").Value), selectedRow.Cells("CategoryName").Value.ToString(), "")
            txtStockID.Text = If(selectedRow.Cells("Stock_ID").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("Stock_ID").Value), selectedRow.Cells("Stock_ID").Value.ToString(), "")
            Stock_ID = If(selectedRow.Cells("Stock_ID").Value IsNot Nothing, selectedRow.Cells("Stock_ID").Value, 0)
            ProductId = If(selectedRow.Cells("ProductId").Value IsNot Nothing, selectedRow.Cells("ProductId").Value, 0)

            ' التعامل مع الصورة
            Dim Product_Image As String = If(selectedRow.Cells("ProductImagePath").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ProductImagePath").Value), selectedRow.Cells("ProductImagePath").Value.ToString(), "")

            If String.IsNullOrEmpty(Product_Image) OrElse Not IO.File.Exists(Product_Image) Then
                ' عرض صورة افتراضية
                Pic_Product.Image = My.Resources.لا_يوجد_صورة_للمنتج
            Else
                ' إزالة الصورة السابقة لتجنب Lock
                If Pic_Product.Image IsNot Nothing Then
                    Pic_Product.Image.Dispose()
                    Pic_Product.Image = Nothing
                End If

                ' تحميل نسخة من الصورة بدون Lock
                Using img As System.Drawing.Image = System.Drawing.Image.FromFile(Product_Image)
                    Pic_Product.Image = New Bitmap(img)
                End Using
            End If
        End If

    End Sub
    'Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
    '    If e.RowIndex >= 0 Then
    '        DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60)
    '    End If
    'End Sub

    'Private Sub DataGridView1_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
    '    If e.RowIndex >= 0 Then
    '        DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45)
    '    End If
    'End Sub

    Private Sub SetupDataGridView(ByVal dgv As DataGridView)
        ' ------------------------------
        ' 1. الإعدادات الأساسية
        ' ------------------------------
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False
        dgv.AllowUserToResizeRows = False      ' منع تعديل ارتفاع الصفوف
        dgv.AllowUserToResizeColumns = False
        ' ------------------------------
        ' 2. ألوان الوضع الداكن (Dark Mode)
        ' ------------------------------
        Dim darkBackground As Color = Color.FromArgb(30, 30, 30)           ' خلفية رئيسية
        Dim darkRow As Color = Color.FromArgb(45, 45, 45)                  ' صف عادي
        Dim darkAltRow As Color = Color.FromArgb(55, 55, 55)               ' صف متناوب
        Dim darkHeader As Color = Color.FromArgb(64, 64, 64)               ' رؤوس الأعمدة
        Dim highlightColor As Color = Color.FromArgb(0, 122, 204)          ' لون الصف المحدد
        Dim textColor As Color = Color.Gainsboro                           ' النصوص العادية

        dgv.BackgroundColor = darkBackground
        dgv.RowsDefaultCellStyle.BackColor = darkRow
        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAltRow
        dgv.DefaultCellStyle.ForeColor = textColor
        dgv.GridColor = Color.FromArgb(80, 80, 80)

        ' ------------------------------
        ' 3. تنسيق الأعمدة والعناوين
        ' ------------------------------

    End Sub
    Private Sub datagridviewsetup()
        With dgvProducts
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
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
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
            .DefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
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




            '.Columns("Product_ID").Visible = False
            '.Columns("BaseUnit_ID").Visible = False
            '.Columns("Product_Image").Visible = False

            ''' ✅ عناوين الأعمدة
            '.Columns("Product_Code").HeaderText = "كود المنتج"
            '.Columns("Product_Name").HeaderText = "اسم المنتج"
            '.Columns("Category_Name").HeaderText = "القسم"
            '.Columns("SuppliersName").HeaderText = "اسم المورد"
            '.Columns("CompanyName").HeaderText = "اسم الشركة"
            '.Columns("Product_Note").HeaderText = "الملاحظات"
            '.Columns("Product_State").HeaderText = "حالة المنتج"
            '.Columns("Unit_Name").HeaderText = "الوحدة الاساسية"

            ''' الترتيب
            '.Columns("Product_Code").DisplayIndex = 0
            '.Columns("Product_Name").DisplayIndex = 1
            '.Columns("Category_Name").DisplayIndex = 2
            '.Columns("Unit_Name").DisplayIndex = 3

            '.Columns("CompanyName").DisplayIndex = 4
            '.Columns("SuppliersName").DisplayIndex = 5
            '.Columns("Product_Note").DisplayIndex = 7
            ''.Columns("User_Barcode_path").DisplayIndex = 6
            ''.Columns("User_Stats").DisplayIndex = 7
            ''.Columns("Product_State").DisplayIndex = 8
            '.Columns("Product_Name").Width = 300
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
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Try
            ' التحقق من وجود بيانات
            If String.IsNullOrWhiteSpace(txtStockID.Text) Then
                MessageBox.Show("❌ يرجى اختيار منتج لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim stockId As Integer = CInt(txtStockID.Text)
            Dim qty As Decimal
            Dim minQty As Decimal

            If Not Decimal.TryParse(txtQty.Text, qty) Then
                MessageBox.Show("❌ الكمية غير صالحة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If Not Decimal.TryParse(txtMinQty.Text, minQty) Then
                MessageBox.Show("❌ الحد الأدنى غير صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim m As New StockManager()

            If m.UpdateStock(stockId, qty, minQty) Then
                MessageBox.Show("✔ تم تعديل بيانات المخزون بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStockData()
            Else
                MessageBox.Show("❌ فشل في تعديل المخزون.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_delet_Click(sender As Object, e As EventArgs) Handles btn_delet.Click
        Try
            If String.IsNullOrWhiteSpace(txtStockID.Text) Then
                MessageBox.Show("❌ اختر منتجًا لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim stockId As Integer = CInt(txtStockID.Text)

            If MessageBox.Show("هل تريد حذف سجل المخزون لهذا المنتج؟", "تأكيد",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Dim m As New StockManager()

            If m.DeleteStock(stockId) Then
                MessageBox.Show("✔ تم حذف المخزون.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStockData()
            Else
                MessageBox.Show("❌ فشل في حذف المخزون.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        txtSearch.Clear()
        ProductCode.Clear()
        txtProductName.Clear()
        DisplayStockQuantity.Clear()
        txtBaseUnitName.Clear()
        txtMinQty.Clear()
        txtQty.Clear()
        txtPartner_Name.Clear()
        txtCategoryName.Clear()
        ProductId = 0
        Stock_ID = 0
        dgvProducts.ClearSelection()
        Product_Image = ""
        Pic_Product.Image = Nothing
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

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

    Private Sub AddStockStatusColumn()
        ' لو العمود موجود من قبل متعملوش تاني
        If Not dgvProducts.Columns.Contains("StockStatus") Then
            Dim col As New DataGridViewTextBoxColumn()
            col.Name = "StockStatus"
            col.HeaderText = "حالة المخزون"
            col.Width = 180
            col.ReadOnly = True
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvProducts.Columns.Add(col)
        End If

        For Each row As DataGridViewRow In dgvProducts.Rows

            Dim qty As Decimal = If(IsDBNull(row.Cells("BaseQuantityTotal").Value), 0, Convert.ToDecimal(row.Cells("BaseQuantityTotal").Value))
            Dim minQty As Decimal = If(IsDBNull(row.Cells("MinQuantity").Value), 0, Convert.ToDecimal(row.Cells("MinQuantity").Value))

            Dim status As String = ""

            If qty = 0 Then
                status = "❌ غير متوفر"
            ElseIf qty < minQty Then
                status = "❗ ناقص"
            ElseIf qty = minQty Then
                status = "⚠ قريب من النفاد"
            Else
                status = "✔ جيد"
            End If

            row.Cells("StockStatus").Value = status

        Next
    End Sub


    'Private Sub HighlightLowStockRows()

    '    For Each row As DataGridViewRow In dgvProducts.Rows

    '        Dim qty As Decimal = If(IsDBNull(row.Cells("BaseQuantityTotal").Value), 0, Convert.ToDecimal(row.Cells("BaseQuantityTotal").Value))
    '        Dim minQty As Decimal = If(IsDBNull(row.Cells("MinQuantity").Value), 0, Convert.ToDecimal(row.Cells("MinQuantity").Value))

    '        If qty = 0 Then
    '            ' غير متوفر
    '            row.DefaultCellStyle.BackColor = Color.FromArgb(150, 0, 0)   ' أحمر غامق
    '            row.DefaultCellStyle.ForeColor = Color.White

    '        ElseIf qty < minQty Then
    '            ' ناقص
    '            row.DefaultCellStyle.BackColor = Color.FromArgb(200, 50, 50) ' أحمر
    '            row.DefaultCellStyle.ForeColor = Color.White

    '        ElseIf qty = minQty Then
    '            ' قريب من النفاد
    '            row.DefaultCellStyle.BackColor = Color.FromArgb(220, 180, 0) ' أصفر
    '            row.DefaultCellStyle.ForeColor = Color.Black

    '        Else
    '            ' جيد
    '            row.DefaultCellStyle.BackColor = Color.FromArgb(45, 80, 45)  ' أخضر 
    '            row.DefaultCellStyle.ForeColor = Color.White
    '        End If

    '    Next

    'End Sub
    Private Sub HighlightLowStockRows()

        For Each row As DataGridViewRow In dgvProducts.Rows

            Dim qty As Decimal = If(IsDBNull(row.Cells("BaseQuantityTotal").Value), 0, Convert.ToDecimal(row.Cells("BaseQuantityTotal").Value))
            Dim minQty As Decimal = If(IsDBNull(row.Cells("MinQuantity").Value), 0, Convert.ToDecimal(row.Cells("MinQuantity").Value))

            ' غير متوفر – أحمر غامق
            If qty = 0 Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(60, 20, 20)
                row.DefaultCellStyle.ForeColor = Color.White

                ' ناقص – برتقالي/أحمر غامق
            ElseIf qty < minQty Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(80, 40, 10)
                row.DefaultCellStyle.ForeColor = Color.White

                ' قريب من النفاد – أصفر غامق
            ElseIf qty = minQty Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(80, 80, 10)
                row.DefaultCellStyle.ForeColor = Color.White

                ' جيد – أخضر غامق ناعم
            Else
                row.DefaultCellStyle.BackColor = Color.FromArgb(20, 60, 20)
                row.DefaultCellStyle.ForeColor = Color.White
            End If

        Next

    End Sub

    Public Function CountLowStockProducts() As Integer
        Dim count As Integer = 0

        For Each row As DataGridViewRow In dgvProducts.Rows
            Dim qty As Decimal = If(IsDBNull(row.Cells("BaseQuantityTotal").Value), 0, Convert.ToDecimal(row.Cells("BaseQuantityTotal").Value))
            Dim minQty As Decimal = If(IsDBNull(row.Cells("MinQuantity").Value), 0, Convert.ToDecimal(row.Cells("MinQuantity").Value))

            If qty = 0 Or qty < minQty Then
                count += 1
            End If
        Next

        Return count
    End Function

    Public Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()
        lstSuggestions.Items.Clear()

        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            LoadStockData()
            Exit Sub
        End If

        Dim field As String = cmbSearchField.SelectedItem.ToString()
        Dim suggestions = GetStockSuggestions(field, keyword)

        If suggestions.Count > 0 Then
            lstSuggestions.Items.AddRange(suggestions.ToArray())
            lstSuggestions.Visible = True
        Else
            lstSuggestions.Visible = False
        End If

        LoadStockData(keyword, field)
        dgvProducts.ClearSelection()
    End Sub
    Private Function GetStockSuggestions(field As String, keyword As String) As List(Of String)
        Dim list As New List(Of String)

        Dim columnName As String = ""
        Select Case field
            Case "كود المنتج" : columnName = "P.Product_Code"
            Case "اسم المنتج" : columnName = "P.Product_Name"
            Case "التصنيف" : columnName = "C.Category_Name"
            Case "المورد" : columnName = "V.SuppliersName"
        End Select

        If columnName = "" Then Return list

        ' ---------------------------
        '   نفس نفس نفس جملة المخزون
        '   لكن نرجع العمود فقط
        ' ---------------------------
        Dim query As String =
        $"SELECT DISTINCT {columnName} 
          FROM dbo.Stock AS S
          LEFT JOIN dbo.Products AS P ON S.Product_ID = P.Product_ID
          LEFT JOIN dbo.ProductUnits AS BU ON P.BaseUnit_ID = BU.ProductUnit_ID 
          LEFT JOIN dbo.Categories AS C ON P.Category_ID = C.Category_ID
          LEFT JOIN dbo.Suppliers AS V ON P.Partner_ID = V.SuppliersID
          WHERE {columnName} LIKE @k
          ORDER BY {columnName};"
        Try
            Connect()

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@k", "%" & keyword & "%")

                Using r = cmd.ExecuteReader()
                    While r.Read()
                        If Not IsDBNull(r(0)) Then
                            list.Add(r(0).ToString())
                        End If
                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("خطأ في جلب الاقتراحات: " & ex.Message)
        End Try

        Return list
    End Function

    Private Sub dgvProducts_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvProducts.DataBindingComplete

        With dgvProducts

            ' الأعمدة غير المرئية
            .Columns("ProductId").Visible = False
            .Columns("ProductImage").Visible = False
            .Columns("Partner_ID").Visible = False
            .Columns("Stock_ID").Visible = False
            .Columns("ProductImagePath").Visible = False

            ' أسماء الأعمدة بالعربية
            .Columns("ProductCode").HeaderText = "كود المنتج"
            .Columns("ProductName").HeaderText = "اسم المنتج"
            .Columns("Partner_Name").HeaderText = "اسم المورد"
            .Columns("CategoryName").HeaderText = "القسم"
            .Columns("BaseUnitName").HeaderText = "الوحدة الأساسية"
            .Columns("DisplayStockQuantity").HeaderText = "المخزون المتوفر"
            .Columns("BaseQuantityTotal").HeaderText = "الإجمالي (أساسية)"
            .Columns("MinQuantity").HeaderText = "حد الطلب الأدنى"
            .Columns("LastUpdate").HeaderText = "آخر تحديث"

            ' عرض الأعمدة
            .Columns("ProductName").Width = 230
            .Columns("DisplayStockQuantity").Width = 160

            ' الترتيب
            .Columns("ProductCode").DisplayIndex = 0
            .Columns("ProductName").DisplayIndex = 1
            .Columns("DisplayStockQuantity").DisplayIndex = 2
            .Columns("BaseUnitName").DisplayIndex = 3
            .Columns("MinQuantity").DisplayIndex = 4

            ' تنسيق الأرقام
            .Columns("BaseQuantityTotal").DefaultCellStyle.Format = "N2"

            ' محاذاة النصوص
            For Each col As DataGridViewColumn In dgvProducts.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            ' ------------------------------
            ' 4. مظهر الرأس والصفوف
            ' ------------------------------
            'dgv.RowTemplate.Height = 32
            dgvProducts.ColumnHeadersHeight = 75


        End With
    End Sub

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        'If lstSuggestions.SelectedItem IsNot Nothing Then
        '    txtSearch.Text = lstSuggestions.SelectedItem.ToString()
        '    lstSuggestions.Visible = False
        'End If
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txtSearch.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
            'LoadCustomers(txtSearch.Text)
            Dim keyword As String = txtSearch.Text.Trim()
            Dim field As String = cmbSearchField.SelectedItem.ToString()
            LoadStockData(keyword, field)

            If dgvProducts.Rows.GetRowCount(DataGridViewElementStates.Visible) = 1 Then

                Dim visibleRow As DataGridViewRow =
                    dgvProducts.Rows.Cast(Of DataGridViewRow)().
                    First(Function(r) r.Visible)

                Dim visibleCell As DataGridViewCell =
                    visibleRow.Cells.Cast(Of DataGridViewCell)().
                    First(Function(c) c.Visible)

                dgvProducts.ClearSelection()
                visibleRow.Selected = True
                dgvProducts.CurrentCell = visibleCell

                Selectrow(visibleRow.Index)

            End If
        End If
    End Sub


    Private Sub Selectrow(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvProducts.Rows.Count Then Exit Sub

        Dim selectedRow As DataGridViewRow = dgvProducts.Rows(rowIndex)
        Try

            ProductCode.Text = If(selectedRow.Cells("ProductCode").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ProductCode").Value), selectedRow.Cells("ProductCode").Value.ToString(), "")
            txtProductName.Text = If(selectedRow.Cells("ProductName").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ProductName").Value), selectedRow.Cells("ProductName").Value.ToString(), "")
            DisplayStockQuantity.Text = If(selectedRow.Cells("DisplayStockQuantity").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("DisplayStockQuantity").Value), selectedRow.Cells("DisplayStockQuantity").Value.ToString(), "")
            txtBaseUnitName.Text = If(selectedRow.Cells("BaseUnitName").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("BaseUnitName").Value), selectedRow.Cells("BaseUnitName").Value.ToString(), "")
            txtMinQty.Text = If(selectedRow.Cells("MinQuantity").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("MinQuantity").Value), selectedRow.Cells("MinQuantity").Value.ToString(), "")
            txtQty.Text = If(selectedRow.Cells("BaseQuantityTotal").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("BaseQuantityTotal").Value), selectedRow.Cells("BaseQuantityTotal").Value, "")
            txtPartner_Name.Text = If(selectedRow.Cells("Partner_Name").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("Partner_Name").Value), selectedRow.Cells("Partner_Name").Value.ToString(), "")
            txtCategoryName.Text = If(selectedRow.Cells("CategoryName").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("CategoryName").Value), selectedRow.Cells("CategoryName").Value.ToString(), "")
            txtStockID.Text = If(selectedRow.Cells("Stock_ID").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("Stock_ID").Value), selectedRow.Cells("Stock_ID").Value.ToString(), "")
            Stock_ID = If(selectedRow.Cells("Stock_ID").Value IsNot Nothing, selectedRow.Cells("Stock_ID").Value, 0)
            ProductId = If(selectedRow.Cells("ProductId").Value IsNot Nothing, selectedRow.Cells("ProductId").Value, 0)

            ' التعامل مع الصورة
            Dim Product_Image As String = If(selectedRow.Cells("ProductImagePath").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ProductImagePath").Value), selectedRow.Cells("ProductImagePath").Value.ToString(), "")

            If String.IsNullOrEmpty(Product_Image) OrElse Not IO.File.Exists(Product_Image) Then
                Pic_Product.Image = My.Resources.لا_يوجد_صورة_للمنتج
            Else
                If Pic_Product.Image IsNot Nothing Then
                    Pic_Product.Image.Dispose()
                    Pic_Product.Image = Nothing
                End If

                Using img As System.Drawing.Image = System.Drawing.Image.FromFile(Product_Image)
                    Pic_Product.Image = New Bitmap(img)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ: " & ex.Message)
        End Try
    End Sub

    Private Sub Stock_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'dgvProducts.DataSource = Nothing
    End Sub

    Private Sub setuptxt()
        ProductCode.TextAlign = HorizontalAlignment.Center
        txtProductName.TextAlign = HorizontalAlignment.Center
        DisplayStockQuantity.TextAlign = HorizontalAlignment.Center
        txtBaseUnitName.TextAlign = HorizontalAlignment.Center
        txtMinQty.TextAlign = HorizontalAlignment.Center
        txtQty.TextAlign = HorizontalAlignment.Center
        txtPartner_Name.TextAlign = HorizontalAlignment.Center
        txtCategoryName.TextAlign = HorizontalAlignment.Center
    End Sub
End Class