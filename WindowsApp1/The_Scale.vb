Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports ExcelDataReader
Imports System.Text

Public Class The_Scale
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim id As Integer
    Private Sub form_TheScale_load() Handles MyBase.Load
        LoadTheScale()
        datagridviewsetup()
        cmbSearchField.Items.Add("الكود")
        cmbSearchField.Items.Add("الاسم")
        cmbSearchField.Items.Add("سعر الشراء")
        cmbSearchField.Items.Add("سعر البيع")
        cmbSearchField.SelectedIndex = 1
    End Sub
    Private Sub cleantxts()
        txt_Name.Clear()
        txt_Purchase_Price.Clear()
        Price.Clear()
        Code.Clear()
        dgv_TheScale.ClearSelection()
    End Sub
    Private Sub datagridviewsetup()
        With dgv_TheScale
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


            .Columns("ID").Visible = False
            '.Columns("User_ID").Visible = False
            '.Columns("User_photo_path").Visible = False

            '' ✅ عناوين الأعمدة
            '.Columns("User_Code").HeaderText = "كود المستخدم"
            '.Columns("User_Name").HeaderText = "الاسم كامل"
            '.Columns("User_username").HeaderText = "اسم المستخدم"
            '.Columns("User_password").HeaderText = "كلمة المرور"
            '.Columns("User_Stats").HeaderText = "الحالة"
            '.Columns("User_Note").HeaderText = "الملاحظات"
            '.Columns("RoleName").HeaderText = "الموظف"
            '.Columns("User_Barcode_path").HeaderText = "الباركود"

            '' الترتيب
            .Columns("الكود").DisplayIndex = 0
            .Columns("الاسم").DisplayIndex = 1
            .Columns("سعر الشراء").DisplayIndex = 2
            .Columns("سعر البيع").DisplayIndex = 3
            '.Columns("RoleName").DisplayIndex = 4
            '.Columns("User_Note").DisplayIndex = 5
            '.Columns("User_Barcode_path").DisplayIndex = 6
            '.Columns("User_Stats").DisplayIndex = 7
            '.Columns("Product_State").DisplayIndex = 8
            '.Columns("CustomerName").Width = 300
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
    Private Sub LoadTheScale(Optional filter As String = "", Optional field As String = "")
        Using Conn
            Dim query As String = "SELECT   
                                        ID AS 'ID',
                                        Code AS 'الكود',
                                        Name AS 'الاسم',
                                        Price AS 'سعر البيع',
                                        Purchase_Price AS 'سعر الشراء'
                                        FROM TheScale"
            Connect()

            If filter <> "" Then
                Dim columnName As String = ""
                Select Case field
                    Case "الكود"
                        columnName = "Code"
                    Case "الاسم"
                        columnName = "Name"
                    Case "سعر البيع"
                        columnName = "Price"
                    Case "سعر الشراء"
                        columnName = "Purchase_Price"
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
            dgv_TheScale.DataSource = dt
            Disconnect()
        End Using
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub
    Public Sub ImportExcelToTheScale(ByVal excelPath As String)

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        Dim dt As New DataTable()

        Using stream = File.Open(excelPath, FileMode.Open, FileAccess.Read)
            Using reader = ExcelReaderFactory.CreateReader(stream)

                Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                    .UseHeaderRow = True
                }
            })

                ' أول شيت تلقائيًا
                dt = result.Tables(0)
            End Using
        End Using

        Dim finalDT As New DataTable()
        finalDT.Columns.Add("Code", GetType(String))
        finalDT.Columns.Add("Name", GetType(String))
        finalDT.Columns.Add("Price", GetType(Decimal))

        For Each row As DataRow In dt.Rows

            Dim code As String = row("رقم").ToString().Trim()
            Dim name As String = row("اسم").ToString().Trim()
            Dim price As String = row("السعر").ToString().Trim()

            If code <> "" And name <> "" Then
                finalDT.Rows.Add(code, name, If(price = "", 0, price))
            End If
        Next


        Try
            Connect()

            Using bulk As New SqlBulkCopy(Conn)
                bulk.DestinationTableName = "TheScale"

                bulk.ColumnMappings.Add("Code", "Code")
                bulk.ColumnMappings.Add("Name", "Name")
                bulk.ColumnMappings.Add("Price", "Price")

                bulk.WriteToServer(finalDT)
            End Using

            MessageBox.Show("✔ تم استيراد البيانات بنجاح")

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الاستيراد: " & ex.Message)

        Finally
            Disconnect()
        End Try

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

    Private Sub dgv_TheScale_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_TheScale.CellClick
        Try
            ' تجاهل الضغط على الهيدر
            If e.RowIndex < 0 Then Exit Sub

            Dim row As DataGridViewRow = dgv_TheScale.Rows(e.RowIndex)

            id = GetCellValue(row, "ID")
            Code.Text = GetCellValue(row, "الكود")
            txt_Name.Text = GetCellValue(row, "الاسم")
            Price.Text = GetCellValue(row, "سعر البيع")
            txt_Purchase_Price.Text = GetCellValue(row, "سعر الشراء")
            'dgv_TheScale.ClearSelection()
            row.Selected = True

        Catch ex As Exception
            MessageBox.Show("❌ خطأ أثناء تحميل بيانات الصف: " & ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()


        If cmbSearchField.SelectedItem Is Nothing Then
            Return
        End If

        Dim field As String = cmbSearchField.SelectedItem.ToString()


        If keyword.Length < 1 Then
            LoadTheScale()
            Exit Sub
        End If

        LoadTheScale(keyword, field)
    End Sub

    Private Sub btn_ImportExcel_Click(sender As Object, e As EventArgs) Handles btn_ImportExcel.Click
        Try
            Dim ofd As New OpenFileDialog With {
            .Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls",
            .Title = "اختر ملف Excel"
        }

            If ofd.ShowDialog() = DialogResult.OK Then
                Dim excelPath As String = ofd.FileName
                ImportExcelToTheScale(excelPath)
            Else
                MessageBox.Show("⚠ لم يتم اختيار ملف.")
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ: " & ex.Message)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If Code.Text = "" Or txt_Name.Text = "" Then
            MessageBox.Show("⚠ الرجاء إدخال الكود والاسم")
            Return
        End If

        Try
            Connect()
            Dim query As String = "INSERT INTO TheScale (Code, Name, Price , Purchase_Price) VALUES (@Code, @Name, @Price,@Purchase_Price)"
            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@Code", Code.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txt_Name.Text.Trim())
                cmd.Parameters.AddWithValue("@Price", If(Price.Text = "", 0, Convert.ToDecimal(Price.Text)))
                cmd.Parameters.AddWithValue("@Purchase_Price", If(txt_Purchase_Price.Text = "", 0, Convert.ToDecimal(txt_Purchase_Price.Text)))
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("✔ تم إضافة المنتج بنجاح")
            cleantxts()
            LoadTheScale() ' دالة لتحديث DataGridView
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الإضافة: " & ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgv_TheScale.SelectedRows.Count = 0 Then
            MessageBox.Show("⚠ الرجاء تحديد صف للتعديل")
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgv_TheScale.SelectedRows(0)
        Dim id As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)

        Try
            Connect()
            Dim query As String = "UPDATE TheScale SET Code=@Code, Name=@Name, Price=@Price , Purchase_Price=@Purchase_Price WHERE ID=@ID"
            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@Code", Code.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txt_Name.Text.Trim())
                cmd.Parameters.AddWithValue("@Price", If(Price.Text = "", 0, Convert.ToDecimal(Price.Text)))
                cmd.Parameters.AddWithValue("@Purchase_Price", If(txt_Purchase_Price.Text = "", 0, Convert.ToDecimal(txt_Purchase_Price.Text)))
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("✔ تم تعديل المنتج بنجاح")
            cleantxts()
            LoadTheScale()
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء التعديل: " & ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgv_TheScale.SelectedRows.Count = 0 Then
            MessageBox.Show("⚠ الرجاء تحديد صف للحذف")
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgv_TheScale.SelectedRows(0)
        Dim id As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)

        If MessageBox.Show("هل أنت متأكد من حذف هذا المنتج؟", "تأكيد الحذف", MessageBoxButtons.YesNo) = DialogResult.No Then
            Return
        End If

        Try
            Connect()
            Dim query As String = "DELETE FROM TheScale WHERE ID=@ID"
            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("✔ تم حذف المنتج بنجاح")
            cleantxts()
            LoadTheScale()
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء الحذف: " & ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        cleantxts()
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


End Class