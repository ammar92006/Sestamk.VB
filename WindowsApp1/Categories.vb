Imports System.Data.SqlClient
Imports ClosedXML.Excel
Imports DevExpress.Office.Utils
Imports DevExpress.PivotGrid.Design
Imports DevExpress.Utils.About

Public Class Categories
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim adapter As SqlDataAdapter
    Dim ds As New DataSet
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim cmdb As New SqlCommandBuilder


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub datagridviewsetup()
        Main.datagridviewsetup(dvg_Categories)
        With dvg_Categories

            .Columns("Category_ID").Visible = False
            .Columns("ColorID").Visible = False
            .Columns("PrinterID").Visible = False
            .Columns("CategoryTypeID").Visible = False
            .Columns("Imagebase64").Visible = False
            .Columns("IsDeleted").Visible = False

            .Columns("CategoryCode").HeaderText = "كود الفئة"
            .Columns("Category_NameAr").HeaderText = "اسم الفئة عربي"
            .Columns("CategoryNameEn").HeaderText = "اسم الفئة إنجليزي"
            .Columns("Description").HeaderText = "وصف القسم"
            .Columns("IsActive").HeaderText = "الحالة"
            .Columns("ColorName").HeaderText = "اللون"
            .Columns("PrinterName").HeaderText = "الطابعه"
            .Columns("TypeName").HeaderText = "نوع الفئة"


            '' الترتيب
            '.Columns("Product_ID").DisplayIndex = 0
            '.Columns("Product_Code").DisplayIndex = 1
            .Columns("Category_NameAr").Width = 300
            '.Columns("Unit_Name").DisplayIndex = 3
            '.Columns("Category_Name").DisplayIndex = 4
            '.Columns("Partner_Name").DisplayIndex = 5
            '.Columns("CompanyName").DisplayIndex = 6
            '.Columns("Product_Note").DisplayIndex = 7
            '.Columns("Product_State").DisplayIndex = 8
            '.Columns("Category_ID").Width = 200
            '.Columns("Category_Name").Width = 400
            '.Columns("Description").Width = 400
            .Columns("IsActive").Width = 60

            ' ✅ عرض الأعمدة بالتساوي
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .MultiSelect = False
        End With
    End Sub
    Private Sub LoadCategories(Optional filter As String = "", Optional field As String = "")
        ' 1. بناء الاستعلام الأساسي
        Dim query As String = "SELECT Cat.Category_ID, " &
                          "       Cat.CategoryCode, " &
                          "       Cat.Category_NameAr, " &
                          "       Cat.CategoryNameEn, " &
                          "       Cat.Imagebase64, " &
                          "       Cat.Description, " &
                          "       Cat.IsActive, " &
                          "       Cat.IsDeleted, " &
                          "       Cat.ColorID, " &
                          "       C.ColorName, " &
                          "       Cat.CategoryTypeID, " &
                          "       CT.TypeName, " &
                          "       Cat.PrinterID, " &
                          "       P.PrinterName " &
                          "  FROM Categories AS Cat " &
                          "  LEFT JOIN Colors C ON Cat.ColorID = C.ColorID " &
                          "  LEFT JOIN CategoryTypes CT ON Cat.CategoryTypeID = CT.CategoryTypeID " &
                          "  LEFT JOIN Printers P ON Cat.PrinterID = P.PrinterID "

        ' 2. تحديد اسم العمود بناءً على الفلتر
        Dim columnName As String = ""
        If Not String.IsNullOrEmpty(filter) Then
            Select Case field
                Case "كود الفئة"
                    columnName = "Cat.CategoryCode"
                Case "اسم الفئة عربي"
                    columnName = "Cat.Category_NameAr"
                Case "اسم الفئة إنجليزي"
                    columnName = "Cat.CategoryNameEn"
                Case "لون الفئة"
                    columnName = "C.ColorName" ' تم التعديل للبحث بالاسم وليس الـ ID لتسهيل البحث التفاعلي للمستخدم
                Case "الطابعه"
                    columnName = "P.PrinterName" ' تم التعديل للبحث بالاسم وليس الـ ID
                Case "نوع الفئة"
                    columnName = "CT.TypeName" ' تم التعديل للبحث بالاسم وليس الـ ID
            End Select

            ' إضافة شرط الـ WHERE مع ترك مسافة آمنة (لاحظ المسافة قبل WHERE)
            If columnName <> "" Then
                query &= $" WHERE {columnName} LIKE @filter AND (Cat.IsDeleted = 0 OR Cat.IsDeleted IS NULL)"
            Else
                query &= " WHERE (Cat.IsDeleted = 0 OR Cat.IsDeleted IS NULL)"
            End If
        Else
            query &= " WHERE (Cat.IsDeleted = 0 OR Cat.IsDeleted IS NULL)"
        End If

        ' 3. فتح اتصال محلي آمن ومستقل تماماً باستعمال الـ ConnectionString الخاص بـ DBModule
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)

                ' تمرير البارامتر بأمان في حالة وجود فلتر
                If Not String.IsNullOrEmpty(filter) AndAlso columnName <> "" Then
                    cmd.Parameters.AddWithValue("@filter", "%" & filter.Trim() & "%")
                End If

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()

                Try
                    conn.Open()
                    da.Fill(dt)

                    ' ربط البيانات بالـ DataGridView
                    dvg_Categories.DataSource = dt

                    ' الحفاظ على التكست بوكس: نظف الحقول فقط لو المستخدم مش بيعمل بحث حالياً
                    If String.IsNullOrEmpty(filter) Then
                        ClearFields()
                    End If

                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء تحميل بيانات الفئات: " & ex.Message, "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using ' يتم قفل وتدمير الاتصال المحلي هنا تلقائياً وبأمان دون التأثير على البرنامج
    End Sub
    Private Sub dvg_Categories_SelectionChanged(sender As Object, e As EventArgs) Handles dvg_Categories.SelectionChanged
        ' 1. التحقق من وجود صف محدد واحد على الأقل
        If dvg_Categories.SelectedRows.Count = 0 Then Exit Sub

        Dim currentRow As DataGridViewRow = dvg_Categories.SelectedRows(0)

        ' 2. التحقق من أن الصف يحتوي على بيانات صحيحة وليس صفاً فارغاً (New Row)
        'If currentRow.Cells("CategoryCode").Value Is Nothing OrElse IsDBNull(currentRow.Cells("CategoryCode").Value) Then
        '    'ClearFields() ' إذا كان الصف فارغاً نقوم بتفريغ الحقول
        '    Exit Sub
        'End If

        Try
            ' --- تعبئة صناديق النصوص بأمان ---
            txtCategoryCode.Text = If(IsDBNull(currentRow.Cells("CategoryCode").Value), String.Empty, currentRow.Cells("CategoryCode").Value.ToString())
            txtCategoryNameAr.Text = If(IsDBNull(currentRow.Cells("Category_NameAr").Value), String.Empty, currentRow.Cells("Category_NameAr").Value.ToString())
            txtCategoryNameEn.Text = If(IsDBNull(currentRow.Cells("CategoryNameEn").Value), String.Empty, currentRow.Cells("CategoryNameEn").Value.ToString())
            txtDescription.Text = If(IsDBNull(currentRow.Cells("Description").Value), String.Empty, currentRow.Cells("Description").Value.ToString())

            ' --- تعبئة الكومبو بوكس بناءً على الـ ValueMember (الأكثر أماناً) ---

            ' 1. لون الفئة
            If Not IsDBNull(currentRow.Cells("ColorID").Value) Then
                cmbColor.SelectedValue = currentRow.Cells("ColorID").Value
            Else
                cmbColor.SelectedIndex = -1
            End If

            ' 2. الطابعة
            If Not IsDBNull(currentRow.Cells("PrinterID").Value) Then
                cmbPrinter.SelectedValue = currentRow.Cells("PrinterID").Value
            Else
                cmbPrinter.SelectedIndex = -1
            End If

            ' 3. نوع الفئة
            If Not IsDBNull(currentRow.Cells("CategoryTypeID").Value) Then
                cmbType.SelectedValue = currentRow.Cells("CategoryTypeID").Value
            Else
                cmbType.SelectedIndex = -1
            End If

            ' --- تعبئة زر الحالة (ToggleSwitch) ---
            If Not IsDBNull(currentRow.Cells("IsActive").Value) Then
                tgStatus.Checked = Convert.ToBoolean(currentRow.Cells("IsActive").Value)
            Else
                tgStatus.Checked = False
            End If

            ' سطر الصورة داخل دالة dvg_Categories_SelectionChanged المفترض تعديله:
            If Not IsDBNull(currentRow.Cells("Imagebase64").Value) AndAlso Not String.IsNullOrEmpty(currentRow.Cells("Imagebase64").Value.ToString()) Then
                picCategory.Image = Base64ToImage(currentRow.Cells("Imagebase64").Value.ToString())
                picCategory.SizeMode = PictureBoxSizeMode.Zoom
            Else
                picCategory.Image = Nothing
            End If
        Catch ex As Exception
            ' معالجة أي خطأ غير متوقع دون توقف التطبيق
            SmartMessageBox.Show("حدث خطأ أثناء عرض بيانات الصف: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Function GetProductsCount(categoryId As Integer) As Integer
        Dim count As Integer = 0

        Try
            Using cn As SqlConnection = DBModule.NewConn()
            Dim query As String = "SELECT COUNT(*) FROM Products WHERE Category_ID = @id"

            Using cmd As New SqlCommand(query, cn)
                cmd.Parameters.AddWithValue("@id", categoryId)
                count = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

        End Using
        Catch ex As Exception
            SmartMessageBox.Show("خطأ: " & ex.Message)
        End Try

        Return count
    End Function


    Private Sub Categories_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadCategories()
        FillCategoryTypesComboBox()
        FillPrintersComboBox()
        FillColorsComboBox()
        cmbSearchField.Items.Add("كود الفئة")
        cmbSearchField.Items.Add("اسم الفئة عربي")
        cmbSearchField.Items.Add("اسم الفئة إنجليزي")
        cmbSearchField.Items.Add("لون الفئة")
        cmbSearchField.Items.Add("الطابعه")
        cmbSearchField.Items.Add("نوع الفئة")

        txtCategoryCode.Text = GetNextCode("Categories", "CategoryCode")
        cmbSearchField.SelectedIndex = 1
        datagridviewsetup()

        EnableDoubleBuffer(dvg_Categories)
        ' بعد تحميل البيانات أعدل الهيدر
        If dvg_Categories.Columns.Contains("Products_Count") Then
            dvg_Categories.Columns("Products_Count").HeaderText = "عدد المنتجات"
        End If

    End Sub

    Private Sub Categories_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
    End Sub


    Private Sub Categories_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub


    Private Sub dvg_Categories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvg_Categories.CellClick
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If Not IsValidData() Then Exit Sub

            If InsertCategory() Then
                SmartMessageBox.Show("تمت إضافة الفئة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' هنا تستدعي دالة تحديث الداتا جريد فيو لتظهر البيانات الجديدة
                ClearFields()
                LoadCategories()
            End If

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء الإضافة: " & ex.Message)
        End Try

    End Sub
    Private Sub ClearFields()
        ' --- تفريغ صناديق النصوص (TextBoxes) باستخدام .Clear() ---
        'txtCategoryCode.Clear()       ' كود الفئة
        txtCategoryCode.Text = GetNextCode("Categories", "CategoryCode")
        txtCategoryNameAr.Clear()     ' اسم الفئة عربي
        txtCategoryNameEn.Clear()     ' اسم الفئة انجليزي
        txtDescription.Clear()        ' وصف الفئة
        txtItemsCount.Clear()         ' عدد الاصناف
        txtSearch.Clear()             ' حقل البحث (ابحث عن فئه)

        ' --- إعادة تعيين القوائم المنسدلة (ComboBoxes) ---
        cmbColor.SelectedIndex = -1      ' لون الفئة
        cmbPrinter.SelectedIndex = -1    ' الطابعه
        cmbType.SelectedIndex = -1       ' نوع الفئة
        'cmbSearchField.SelectedIndex = 1  ' الـ ComboBox العلوي الموجود فوق الوصف

        ' --- إعادة تعيين زر الحالة (ToggleSwitch) ---
        tgStatus.Checked = False         ' حاله القسم

        ' --- تفريغ قائمة المقترحات (ListBox) ---
        lstSuggestions.Items.Clear()     ' قائمة المقترحات
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()
        lstSuggestions.Items.Clear()

        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            LoadCategories()
            Exit Sub
        End If

        Dim field As String = cmbSearchField.SelectedItem.ToString()
        Dim suggestions = GetSuggestions(field, keyword)

        If suggestions.Count > 0 Then
            lstSuggestions.Items.AddRange(suggestions.ToArray())
            lstSuggestions.Visible = True
        Else
            lstSuggestions.Visible = False
        End If

        LoadCategories(keyword, field)
    End Sub
    Private Function GetSuggestions(field As String, keyword As String) As List(Of String)
        Dim suggestions As New List(Of String)()

        Dim columnName As String = ""
        Select Case field
            Case "كود الفئة"
                columnName = "CategoryCode"
            Case "اسم الفئة عربي"
                columnName = "Category_NameAr"
            Case "اسم الفئة إنجليزي"
                columnName = "CategoryNameEn"
            Case "لون الفئة"
                columnName = "Category_NameAr"
            Case "الطابعه"
                columnName = "Category_NameAr"
            Case "نوع الفئة"
                columnName = "Category_NameAr"
        End Select
        Using Conn
            Using cn As SqlConnection = DBModule.NewConn()
            Dim query As String = $"SELECT {columnName} FROM Categories WHERE {columnName} LIKE @keyword AND IsDeleted = 0"
            Dim cmd As New SqlCommand(query, cn)
            cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")

            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                suggestions.Add(reader(columnName).ToString())
            End While
        End Using
        End Using
        Return suggestions
    End Function

    Private Sub dvg_Categories_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvg_Categories.CellDoubleClick
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
            LoadCategories(keyword, field)

            If dvg_Categories.Rows.GetRowCount(DataGridViewElementStates.Visible) = 1 Then

                Dim visibleRow As DataGridViewRow =
                    dvg_Categories.Rows.Cast(Of DataGridViewRow)().
                    First(Function(r) r.Visible)

                Dim visibleCell As DataGridViewCell =
                    visibleRow.Cells.Cast(Of DataGridViewCell)().
                    First(Function(c) c.Visible)

                dvg_Categories.ClearSelection()
                visibleRow.Selected = True
                dvg_Categories.CurrentCell = visibleCell

                'Selectrow(visibleRow.Index)

            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub FillColorsComboBox()
        Dim query As String = "SELECT ColorID, ColorName FROM Colors Where IsActive = 1 AND IsDeleted = 0 OR IsDeleted IS NULL"

        Try
            ' -------------------------------------------------------------------------
            ' 💡 ضع سطر تحميل البيانات وجلب الـ DataTable الخاص بك هنا بنفس طريقتك
            ' مثال: Dim dt As DataTable = YourDatabaseClass.LoadData(query)
            ' -------------------------------------------------------------------------
            Dim dt As DataTable = ExecuteQuery(query) ' استبدل ExecuteQuery بالدالة المعتمدة عندك

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cmbColor.DataSource = dt
                cmbColor.DisplayMember = "ColorName"
                cmbColor.ValueMember = "ColorID"
                cmbColor.SelectedIndex = -1
            End If
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل ألوان الفئات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillPrintersComboBox()
        Dim query As String = "SELECT PrinterID, PrinterName FROM Printers Where IsActive = 1 AND IsDeleted = 0 OR IsDeleted IS NULL"

        Try
            ' -------------------------------------------------------------------------
            ' 💡 ضع سطر تحميل البيانات وجلب الـ DataTable الخاص بك هنا بنفس طريقتك
            ' -------------------------------------------------------------------------
            Dim dt As DataTable = ExecuteQuery(query) ' استبدل ExecuteQuery بالدالة المعتمدة عندك

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cmbPrinter.DataSource = dt
                cmbPrinter.DisplayMember = "PrinterName"
                cmbPrinter.ValueMember = "PrinterID"
                cmbPrinter.SelectedIndex = -1
            End If
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل الطابعات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadCategories()
        FillCategoryTypesComboBox()
        FillPrintersComboBox()
        FillColorsComboBox()
        dvg_Categories.ClearSelection()
    End Sub

    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp"
            ofd.Title = "اختر صورة الفئة"

            If ofd.ShowDialog() = DialogResult.OK Then
                ' شحن الصورة داخل الـ PictureBox
                picCategory.Image = Image.FromFile(ofd.FileName)
                picCategory.SizeMode = PictureBoxSizeMode.Zoom
            End If
        End Using
    End Sub
    Private Sub btnDeleteImage_Click(sender As Object, e As EventArgs) Handles btnDeleteImage.Click
        picCategory.Image = Nothing
    End Sub
    Private Sub FillCategoryTypesComboBox()
        Dim query As String = "SELECT CategoryTypeID, TypeName FROM CategoryTypes Where IsActive = 1 AND IsDeleted = 0 OR IsDeleted IS NULL"

        Try
            ' -------------------------------------------------------------------------
            ' 💡 ضع سطر تحميل البيانات وجلب الـ DataTable الخاص بك هنا بنفس طريقتك
            ' -------------------------------------------------------------------------
            Dim dt As DataTable = ExecuteQuery(query) ' استبدل ExecuteQuery بالدالة المعتمدة عندك

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cmbType.DataSource = dt
                cmbType.DisplayMember = "TypeName"
                cmbType.ValueMember = "CategoryTypeID"
                cmbType.SelectedIndex = -1
            End If
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل أنواع الفئات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function InsertCategory() As Boolean
        ' تأكد من تطابق أسماء الأعمدة في الجدول الخاص بك
        Dim query As String = "INSERT INTO Categories (CategoryCode, Category_NameAr, CategoryNameEn, Description, IsActive, ColorID, CategoryTypeID, PrinterID, Imagebase64, IsDeleted) " &
                          "VALUES (@CategoryCode, @Category_NameAr, @CategoryNameEn, @Description, @IsActive, @ColorID, @CategoryTypeID, @PrinterID, @Imagebase64, 0)"

        ' استخدام الخاصية الجاهزة ConnectionString من الـ DBModule الخاص بك
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                ' إضافة المعاملات (Parameters) بأمان
                cmd.Parameters.AddWithValue("@CategoryCode", If(String.IsNullOrEmpty(txtCategoryCode.Text), DBNull.Value, txtCategoryCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Category_NameAr", If(String.IsNullOrEmpty(txtCategoryNameAr.Text), DBNull.Value, txtCategoryNameAr.Text.Trim()))
                cmd.Parameters.AddWithValue("@CategoryNameEn", If(String.IsNullOrEmpty(txtCategoryNameEn.Text), DBNull.Value, txtCategoryNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                ' معاملات الـ ComboBoxes بناءً على الـ ValueMember
                cmd.Parameters.AddWithValue("@ColorID", If(cmbColor.SelectedValue Is Nothing, DBNull.Value, cmbColor.SelectedValue))
                cmd.Parameters.AddWithValue("@CategoryTypeID", If(cmbType.SelectedValue Is Nothing, DBNull.Value, cmbType.SelectedValue))
                cmd.Parameters.AddWithValue("@PrinterID", If(cmbPrinter.SelectedValue Is Nothing, DBNull.Value, cmbPrinter.SelectedValue))

                ' تحويل الصورة وحفظها كـ Base64 عبر دالة الموديول الذكية
                Dim imgBase64 As String = DBModule.ImageToBase64(picCategory.Image)
                cmd.Parameters.AddWithValue("@Imagebase64", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                Try
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء إضافة الفئة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If Not IsValidData() Then Exit Sub
            If UpdateCategory() Then
                SmartMessageBox.Show("تم تعديل بيانات الفئة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' هنا تستدعي دالة تحديث الداتا جريد فيو لتظهر التعديلات
                ClearFields()
                LoadCategories()
            End If
        Catch ex As Exception

            Logger.LogError("Categories.vb:579", ex)
        End Try
    End Sub

    Private Function UpdateCategory() As Boolean
        ' التحقق من تحديد صف من الجدول أولاً
        If dvg_Categories.SelectedRows.Count = 0 Then
            SmartMessageBox.Show("يرجى اختيار الفئة المراد تعديلها من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' الحصول على الـ ID المخفي من الصف الحالي
        Dim currentID As Integer = Convert.ToInt32(dvg_Categories.SelectedRows(0).Cells("Category_ID").Value)

        Dim query As String = "UPDATE Categories SET CategoryCode = @CategoryCode, Category_NameAr = @Category_NameAr, " &
                          "CategoryNameEn = @CategoryNameEn, Description = @Description, IsActive = @IsActive, " &
                          "ColorID = @ColorID, CategoryTypeID = @CategoryTypeID, PrinterID = @PrinterID, Imagebase64 = @Imagebase64 " &
                          "WHERE Category_ID = @Category_ID"

        ' الاعتماد على الـ ConnectionString المعزول لمنع خطأ الـ Connection state is open
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Category_ID", currentID)
                cmd.Parameters.AddWithValue("@CategoryCode", If(String.IsNullOrEmpty(txtCategoryCode.Text), DBNull.Value, txtCategoryCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Category_NameAr", If(String.IsNullOrEmpty(txtCategoryNameAr.Text), DBNull.Value, txtCategoryNameAr.Text.Trim()))
                cmd.Parameters.AddWithValue("@CategoryNameEn", If(String.IsNullOrEmpty(txtCategoryNameEn.Text), DBNull.Value, txtCategoryNameEn.Text.Trim()))
                cmd.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                cmd.Parameters.AddWithValue("@ColorID", If(cmbColor.SelectedValue Is Nothing, DBNull.Value, cmbColor.SelectedValue))
                cmd.Parameters.AddWithValue("@CategoryTypeID", If(cmbType.SelectedValue Is Nothing, DBNull.Value, cmbType.SelectedValue))
                cmd.Parameters.AddWithValue("@PrinterID", If(cmbPrinter.SelectedValue Is Nothing, DBNull.Value, cmbPrinter.SelectedValue))

                Dim imgBase64 As String = DBModule.ImageToBase64(picCategory.Image)
                cmd.Parameters.AddWithValue("@Imagebase64", If(String.IsNullOrEmpty(imgBase64), DBNull.Value, imgBase64))

                Try
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء تعديل الفئة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dvg_Categories.SelectedRows.Count = 0 Then
            SmartMessageBox.Show("يرجى اختيار الفئة المراد حذفها من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' رسالة تأكيد لحماية البيانات من الضغط غير المقصود
        Dim result As DialogResult = SmartMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذه الفئة نهائياً؟", "تأكيد الحذف",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If result = DialogResult.Yes Then
            ' تنفيذ دالة الحذف الآمنة
            If DeleteCategory() Then
                SmartMessageBox.Show("تم حذف الفئة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' تفريغ الحقول ومسح البيانات من أدوات الإدخال
                ClearFields()
                LoadCategories()
                ' 💡 هنا قم باستدعاء الدالة المسؤولة عن تحديث الـ DataGridView في الفورم عندك لتختفي الفئة المحذوفة فوراً
            End If
        End If
    End Sub

    Private Function DeleteCategory() As Boolean
        ' 1. التأكد أولاً من تحديد صف من الجدول لحذفه
        If dvg_Categories.SelectedRows.Count = 0 Then
            SmartMessageBox.Show("يرجى اختيار الفئة المراد حذفها من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' 2. أخذ الـ ID الخاص بالفئة المحددة (تأكد من اسم العمود الحقيقي للـ ID في الـ DataGridView)
        Dim currentID As Integer = Convert.ToInt32(dvg_Categories.SelectedRows(0).Cells("Category_ID").Value)

        ' 3. استعلام الحذف المنطقي الآمن (Soft Delete)
        Dim query As String = "UPDATE Categories SET IsDeleted = 1 WHERE Category_ID = @Category_ID"

        ' 4. استخدام الـ ConnectionString المعزول والديناميكي من الـ DBModule الخاص بك لتفادي خطأ السيرفر
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                ' تمرير الـ Parameter بأمان
                cmd.Parameters.AddWithValue("@Category_ID", currentID)

                Try
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء حذف الفئة: " & ex.Message, "خطأ في السيرفر", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Sub btnAddColorForm_Click(sender As Object, e As EventArgs) Handles btnAddColorForm.Click
        Dim frm As New frmColors() ' اسم فورم الألوان الفرعي
        frm.ShowDialog() ' يفتح كـ Dialog معلق
        FillColorsComboBox() ' بمجرد إغلاق الفورم الفرعي، تتحدث القائمة فوراً
    End Sub

    Private Sub btnAddPrinterForm_Click(sender As Object, e As EventArgs) Handles btnAddPrinterForm.Click
        Dim frm As New frmPrinters() ' اسم فورم الطابعات الفرعي
        frm.ShowDialog()
        FillPrintersComboBox() ' تتحدث القائمة فوراً
    End Sub

    Private Sub btnAddTypeForm_Click(sender As Object, e As EventArgs) Handles btnAddTypeForm.Click
        Dim frm As New frmCategoryTypes() ' اسم فورم أنواع الفئات الفرعي
        frm.ShowDialog()
        FillCategoryTypesComboBox() ' تتحدث القائمة فوراً
    End Sub

    Private Function IsValidData() As Boolean
        ' 1. التحقق من كود الفئة
        If String.IsNullOrWhiteSpace(txtCategoryCode.Text) Then
            SmartMessageBox.Show("عذراً، يجب إدخال كود الفئة أولاً!", "تنبيهvalidation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryCode.Focus()
            Return False
        End If

        ' 2. التحقق من اسم الفئة باللغة العربية
        If String.IsNullOrWhiteSpace(txtCategoryNameAr.Text) Then
            SmartMessageBox.Show("عذراً، يجب إدخال اسم الفئة باللغة العربية!", "تنبيهvalidation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryNameAr.Focus()
            Return False
        End If

        ' 3. التحقق من اختيار نوع الفئة من الكومبو بوكس
        If cmbType.SelectedValue Is Nothing OrElse cmbType.SelectedIndex = -1 Then
            SmartMessageBox.Show("عذراً، يجب اختيار نوع الفئة!", "تنبيهvalidation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbType.Focus()
            Return False
        End If

        ' 💡 يمكنك إضافة أي شروط إضافية هنا (مثل التأكد من اختيار لون أو طابعة إذا كانت إجبارية)

        ' إذا اجتازت البيانات كل الشروط ترجع الدالة True
        Return True
    End Function
End Class