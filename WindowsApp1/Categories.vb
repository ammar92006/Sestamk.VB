Imports System.Data.SqlClient
Imports ClosedXML.Excel
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
        With dvg_Categories
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
            .AllowUserToResizeRows = True
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False

            ' ✅ ضبط النص في المنتصف داخل الخلايا
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' ✅ إظهار عناوين الأعمدة (لو كانت مخفية)
            .ColumnHeadersVisible = True


            '.Columns("BaseUnit_ID").Visible = False
            '.Columns("CustomerID").Visible = False

            '' ✅ عناوين الأعمدة
            .Columns("Category_ID").HeaderText = "كود القسم"
            .Columns("Category_Name").HeaderText = "اسم القسم"
            .Columns("Description").HeaderText = "وصف القسم"
            .Columns("Products_Count").HeaderText = "عدد المنتجات"
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
            '.Columns("Category_ID").Width = 200
            '.Columns("Category_Name").Width = 400
            '.Columns("Description").Width = 400
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

    Private Sub LoadCategories(Optional filter As String = "", Optional field As String = "")
        Using Conn
            Dim query As String = "SELECT Category_ID ,Category_Name ,Description  From Categories"
            Connect()
            txt_CategoryID.Clear()
            txt_CategoryName.Clear()
            txt_Description.Clear()
            txt_ProductsCount.Clear()

            If filter <> "" Then
                Dim columnName As String = ""
                Select Case field
                    Case "كود القسم"
                        columnName = "Category_ID"
                    Case "اسم القسم"
                        columnName = "Category_Name"
                    Case "وصف القسم"
                        columnName = "Description"
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

            '---------------------------
            ' إضافة عمود جديد لعدد المنتجات
            '---------------------------
            If Not dt.Columns.Contains("Products_Count") Then
                dt.Columns.Add("Products_Count", GetType(Integer))
            End If

            ' تعبئة العمود بعدد المنتجات
            For Each row As DataRow In dt.Rows
                Dim catID As Integer = Convert.ToInt32(row("Category_ID"))
                row("Products_Count") = GetProductsCount(catID)
            Next

            dvg_Categories.DataSource = dt

            Disconnect()
        End Using
    End Sub
    Private Function GetProductsCount(categoryId As Integer) As Integer
        Dim count As Integer = 0

        Try
            Connect()
            Dim query As String = "SELECT COUNT(*) FROM Products WHERE Category_ID = @id"

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@id", categoryId)
                count = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

        Catch ex As Exception
            MessageBox.Show("خطأ: " & ex.Message)
        Finally
            Disconnect()
        End Try

        Return count
    End Function


    Private Sub Categories_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadCategories()
        cmbSearchField.Items.Add("كود القسم")
        cmbSearchField.Items.Add("اسم القسم")
        cmbSearchField.Items.Add("وصف القسم")
        cmbSearchField.SelectedIndex = 1
        datagridviewsetup()
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
        'Try
        '    ' ==== 1) التحقق من صحة البيانات قبل الإضافة ====
        '    If String.IsNullOrWhiteSpace(TextBox2.Text) Then
        '        MessageBox.Show("❌ من فضلك أدخل اسم الصنف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        TextBox2.Focus()
        '        Exit Sub
        '    End If

        '    If String.IsNullOrWhiteSpace(TextBox3.Text) Then
        '        MessageBox.Show("❌ من فضلك أدخل وصف الصنف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        TextBox3.Focus()
        '        Exit Sub
        '    End If

        '    ' ==== 2) التحقق من عدم تكرار اسم الصنف ====
        '    Dim checkQuery As String = "SELECT COUNT(*) FROM Categories WHERE Category_Name = @Category_Name"
        '    Using checkCmd As New SqlCommand(checkQuery, Conn)
        '        Connect()
        '        checkCmd.Parameters.AddWithValue("@Category_Name", TextBox2.Text.Trim())

        '        Dim exists As Integer = CInt(checkCmd.ExecuteScalar())

        '        If exists > 0 Then
        '            MessageBox.Show("⚠ الصنف موجود بالفعل، لا يمكن إضافته مرة أخرى.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Disconnect()
        '            Exit Sub
        '        End If
        '    End Using

        '    ' ==== 3) تنفيذ عملية الإضافة ====
        '    Dim insertQuery As String = "INSERT INTO Categories (Category_Name, Description)
        '                         VALUES (@Category_Name, @Description)"

        '    Using insertCmd As New SqlCommand(insertQuery, Conn)
        '        insertCmd.Parameters.AddWithValue("@Category_Name", TextBox2.Text.Trim())
        '        insertCmd.Parameters.AddWithValue("@Description", TextBox3.Text.Trim())

        '        insertCmd.ExecuteNonQuery()
        '    End Using

        '    Disconnect()

        '    MessageBox.Show("✅ تم إضافة الصنف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    DataGridView1.ClearSelection()

        'Catch ex As Exception
        '    MessageBox.Show("⚠ حدث خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Finally
        '    LoadData()

        'End Try

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        'Try
        '    If TextBox1.Text = "" Then
        '        MessageBox.Show("من فضلك اختر وحدة لتعديلها أولاً")
        '        Return
        '    End If

        '    Connect()
        '    Dim query As String = "UPDATE Categories SET 
        '                        Category_Name=@Category_Name,
        '                        Description=@Description
        '                      WHERE Category_ID=@Category_ID  "

        '    Dim cmd As New SqlCommand(query, Conn)
        '    cmd.Parameters.AddWithValue("@Category_Name", TextBox2.Text)
        '    cmd.Parameters.AddWithValue("@Description", TextBox3.Text)
        '    cmd.Parameters.AddWithValue("@Category_ID", TextBox1.Text)


        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("✏️ تم تعديل البيانات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Disconnect()

        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء التعديل: " & ex.Message)
        'Finally
        '    LoadData()
        'End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        'Try
        '    ' ✅ تأكد إن المستخدم ضغط على صف صحيح
        '    If e.RowIndex >= 0 Then
        '        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        '        ' ✅ نقل البيانات إلى TextBoxات
        '        TextBox1.Text = row.Cells(0).Value.ToString()
        '        TextBox2.Text = row.Cells(1).Value.ToString()
        '        TextBox3.Text = row.Cells(2).Value.ToString()

        '    End If

        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء تحميل بيانات الصف: " & ex.Message)

        'End Try


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
        'Try
        '    If TextBox1.Text = "" Then
        '        MessageBox.Show("من فضلك اختر المنتج لحذفه أولاً")
        '        Return
        '    End If

        '    If MessageBox.Show("هل أنت متأكد من الحذف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '        Connect()
        '        Dim query As String = "DELETE FROM Categories WHERE Category_ID=@Category_ID"
        '        Dim cmd As New SqlCommand(query, Conn)
        '        cmd.Parameters.AddWithValue("@Category_ID", TextBox1.Text)
        '        cmd.ExecuteNonQuery()
        '        Disconnect()
        '        MessageBox.Show("🗑️ تم الحذف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        LoadData()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        'End Try
        'DataGridView1.ClearSelection()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        '================================================================================
        ' كود البحث/الفلترة
        '================================================================================

        'Try
        '    ' 1. التأكد من الاتصال بقاعدة البيانات
        '    Connect()

        '    ' 2. تعريف جملة SQL للبحث/الفلترة
        '    ' نستخدم (LIKE) و (CONCAT('%', @SearchTerm, '%')) للبحث الجزئي
        '    ' استبدل 'Categories' و 'Category_Name' بأسماء جدولك وعمود البحث الفعليين
        '    Dim searchQuery As String = "SELECT * FROM Categories WHERE Category_Name LIKE @SearchTerm OR Description LIKE @SearchTerm"

        '    ' 3. إنشاء الأمر (Command)
        '    Dim cmd As New SqlCommand(searchQuery, Conn)

        '    ' 4. إضافة بارامتر قيمة البحث
        '    ' نضيف علامات % قبل وبعد النص للسماح بالبحث الجزئي
        '    cmd.Parameters.AddWithValue("@SearchTerm", "%" & txtSearch.Text & "%")

        '    ' 5. تنفيذ الأمر وتعبئة البيانات في DataGridView
        '    Dim da1 As New SqlDataAdapter(cmd)
        '    Dim dt1 As New DataTable()
        '    da1.Fill(dt1)

        '    ' عرض النتائج في DataGridView
        '    DataGridView1.DataSource = dt1

        '    ' 6. رسالة تأكيد (اختياري)
        '    MessageBox.Show($"تم العثور على {dt1.Rows.Count} سجل مطابق.", "نتائج البحث", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Catch ex As Exception
        '    ' معالجة أي خطأ قد يحدث أثناء الاتصال أو الاستعلام
        '    MessageBox.Show("حدث خطأ أثناء البحث: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Finally
        '    ' 7. قطع الاتصال بقاعدة البيانات
        '    Disconnect()
        'End Try
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'LoadData()
        'TextBox1.Clear()
        'TextBox2.Clear()
        'TextBox3.Clear()
        'txtSearch.Clear()
        'DataGridView1.ClearSelection()
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

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearFields()
    End Sub

    Private Sub dvg_Categories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvg_Categories.CellClick
        Try
            ' تجاهل الضغط على الهيدر
            If e.RowIndex < 0 Then Return

            Dim row As DataGridViewRow = dvg_Categories.Rows(e.RowIndex)

            '============================
            ' تحميل بيانات التصنيف داخل التكست بوكس
            '============================
            txt_CategoryID.Text = row.Cells("Category_ID").Value.ToString()
            txt_CategoryName.Text = row.Cells("Category_Name").Value.ToString()
            txt_Description.Text = row.Cells("Description").Value.ToString()

            '============================
            ' حساب عدد المنتجات المرتبطة بالتصنيف
            '============================
            Dim categoryID As Integer = Convert.ToInt32(row.Cells("Category_ID").Value)
            Dim productCount As Integer = GetProductsCount(categoryID)

            ' ضع العدد في TextBox أو Label
            txt_ProductsCount.Text = productCount.ToString()

        Catch ex As Exception
            MessageBox.Show("خطأ: " & ex.Message)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            ' التحقق من الحقول الأساسية
            If String.IsNullOrWhiteSpace(txt_CategoryName.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال اسم القسم.", "تنبيه")
                Return
            End If

            Connect()

            Dim query As String = "
            INSERT INTO Categories (Category_Name, Description)
            VALUES (@Name, @Description)
        "

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@Name", txt_CategoryName.Text.Trim())
                cmd.Parameters.AddWithValue("@Description", txt_Description.Text.Trim())
                cmd.ExecuteNonQuery()
            End Using

            Disconnect()

            MessageBox.Show("✅ تم إضافة القسم بنجاح.", "نجاح")

            LoadCategories() ' إعادة تحميل الداتا
            ClearFields()    ' تفريغ الخانات

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الإضافة: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrWhiteSpace(txt_CategoryID.Text) Then
                MessageBox.Show("⚠️ لا يوجد قسم محدد للتعديل.", "تنبيه")
                Return
            End If

            If String.IsNullOrWhiteSpace(txt_CategoryName.Text) Then
                MessageBox.Show("⚠️ يرجى إدخال اسم القسم.", "تنبيه")
                Return
            End If

            Connect()

            Dim query As String = "
            UPDATE Categories
            SET Category_Name = @Name, Description = @Description
            WHERE Category_ID = @ID
        "

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@ID", txt_CategoryID.Text)
                cmd.Parameters.AddWithValue("@Name", txt_CategoryName.Text.Trim())
                cmd.Parameters.AddWithValue("@Description", txt_Description.Text.Trim())
                cmd.ExecuteNonQuery()
            End Using

            Disconnect()

            MessageBox.Show("✅ تم تعديل القسم بنجاح.", "تم")

            LoadCategories()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء التعديل: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If String.IsNullOrWhiteSpace(txt_CategoryID.Text) Then
                MessageBox.Show("⚠️ لا يوجد قسم محدد للحذف.", "تنبيه")
                Return
            End If

            Dim result = MessageBox.Show("هل أنت متأكد من حذف هذا القسم؟", "تأكيد الحذف",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.No Then Exit Sub

            Connect()

            Dim query As String = "DELETE FROM Categories WHERE Category_ID = @ID"

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@ID", txt_CategoryID.Text)
                cmd.ExecuteNonQuery()
            End Using

            Disconnect()

            MessageBox.Show("🗑️ تم حذف القسم بنجاح.", "نجاح")

            LoadCategories()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الحذف: " & ex.Message)
        End Try
    End Sub
    Private Sub ClearFields()
        txt_CategoryID.Clear()
        txt_CategoryName.Clear()
        txt_Description.Clear()
        txt_ProductsCount.Clear()
        txtSearch.Clear()
        dvg_Categories.ClearSelection()
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
            Case "كود القسم"
                columnName = "Category_ID"
            Case "اسم القسم"
                columnName = "Category_Name"
            Case "وصف القسم"
                columnName = "Description"
        End Select
        Using Conn
            Connect()
            Dim query As String = $"SELECT {columnName} FROM Categories WHERE {columnName} LIKE @keyword"
            Dim cmd As New SqlCommand(query, Conn)
            cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")

            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                suggestions.Add(reader(columnName).ToString())
            End While
        End Using
        Disconnect()
        Return suggestions
    End Function

    Private Sub dvg_Categories_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvg_Categories.CellDoubleClick
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

            Dim sectionName As String = dvg_Categories.Rows(e.RowIndex).Cells("Category_Name").Value.ToString()

            Dim frm As Products = Nothing
            For Each f As Form In Application.OpenForms
                If TypeOf f Is Products Then
                    frm = CType(f, Products)
                    Exit For
                End If
            Next

            If frm Is Nothing Then
                frm = New Products
                frm.Show()
            Else
                frm.BringToFront()
            End If

            Try
                frm.cmbSearchField.SelectedIndex = 3
            Catch
            End Try

            Try
                frm.txtSearch.Text = sectionName
                frm.txtSearch_TextChanged(frm.txtSearch, EventArgs.Empty)
            Catch
            End Try

        Catch ex As Exception
            ' تجاهل أي خطأ بصمت
        End Try
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

                Selectrow(visibleRow.Index)

            End If
        End If
    End Sub
    Private Sub Selectrow(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dvg_Categories.Rows.Count Then Exit Sub

        Dim row As DataGridViewRow = dvg_Categories.Rows(rowIndex)
        Try

            'txtCustomerCode.Text = row.Cells("CustomerCode").Value?.ToString()
            '============================
            ' تحميل بيانات التصنيف داخل التكست بوكس
            '============================
            txt_CategoryID.Text = row.Cells("Category_ID").Value.ToString()
            txt_CategoryName.Text = row.Cells("Category_Name").Value.ToString()
            txt_Description.Text = row.Cells("Description").Value.ToString()

            '============================
            ' حساب عدد المنتجات المرتبطة بالتصنيف
            '============================
            Dim categoryID As Integer = Convert.ToInt32(row.Cells("Category_ID").Value)
            Dim productCount As Integer = GetProductsCount(categoryID)

            ' ضع العدد في TextBox أو Label
            txt_ProductsCount.Text = productCount.ToString()

        Catch ex As Exception
            MessageBox.Show("خطأ: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    'Private Sub LoadData()
    '    'Dim query As String = "SELECT Category_ID as 'كود الصنف',Category_Name as 'اسم الصنف',Description as 'الملاحظات' From Categories"
    '    'Connect()
    '    'da = New SqlDataAdapter(query, Conn)
    '    'dt = New DataTable()
    '    'da.Fill(dt)
    '    'DataGridView1.DataSource = dt
    '    'DataGridView1.ClearSelection()
    '    'Disconnect()
    'End Sub
End Class