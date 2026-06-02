Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DevExpress.Utils.About
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraEditors
Imports DevExpress.XtraExport.Helpers
Imports Guna.UI2.WinForms
Imports ZXing
Imports Microsoft.Office.Interop
Imports OfficeOpenXml

Public Class Partners
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim selectedID As Integer = -1
    Dim x, y As Integer
    Dim newpoint As New Point

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        If WindowState Then
            WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub

    Private Sub Partners_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPartners()
        Dim cols = GetColumnNamesWithArabic("Partners")

        cmbColumns.Items.Clear()

        For Each pair In cols
            cmbColumns.Items.Add(pair.Value)
        Next

    End Sub

    Private Sub Partners_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Partners_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellClick
        Try
            ' ✅ تأكد إن المستخدم ضغط على صف صحيح
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DataGridView.Rows(e.RowIndex)

                ' ✅ نقل البيانات إلى TextBoxات
                txtID.Text = row.Cells("Partner_ID").Value.ToString()
                txtName.Text = row.Cells("Partner_Name").Value.ToString()
                cmbType.Text = row.Cells("Partner_Type").Value.ToString()
                txtPhone.Text = row.Cells("Phone").Value.ToString()
                txtCompany.Text = row.Cells("CompanyName").Value.ToString()
                txtBalance.Text = row.Cells("Balance").Value.ToString()
                txtImagePath.Text = row.Cells("ImagePath").Value.ToString()
                txtNotes.Text = row.Cells("Notes").Value.ToString()
                txtCreatedAt.Text = row.Cells("CreatedAt").Value.ToString()




                ' ✅ تحميل الصورة في PictureBox لو المسار موجود
                Dim imagePath As String = txtImagePath.Text
                If IO.File.Exists(imagePath) Then
                    PictureBox1.Image = System.Drawing.Image.FromFile(imagePath)
                Else
                    PictureBox1.Image = My.Resources.DefaultImageclient
                End If

                If Not File.Exists(txtID.Text) Then
                    ' إذا لم يكن هناك مسار صالح، عرض صورة افتراضية
                    Barcode.Image = My.Resources.DefaultBarcodeImage ' تأكد من إضافة صورة افتراضية في الموارد
                Else
                    Barcode.Image = System.Drawing.Image.FromFile(txtID.Text)

                End If


            End If

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تحميل بيانات الصف: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim cmd_Add As SqlCommand
            Disconnect()
            Connect()
            Dim query_Add As String = "
                                        INSERT INTO Partners 
                                        ( Partner_Name, Partner_Type, Phone, CompanyName, Balance, ImagePath, Notes, CreatedAt)
                                        VALUES ( @Partner_Name, @Type, @Phone, @Company, @Balance, @Image, @Notes, GETDATE())"


            cmd_Add = New SqlCommand(query_Add, Conn)
            'cmd_Add.Parameters.AddWithValue("@Partner_ID", GetNextID())
            cmd_Add.Parameters.AddWithValue("@Partner_Name", txtName.Text)
            cmd_Add.Parameters.AddWithValue("@Type", cmbType.SelectedValue)
            cmd_Add.Parameters.AddWithValue("@Phone", txtPhone.Text)
            cmd_Add.Parameters.AddWithValue("@Company", txtCompany.Text)
            cmd_Add.Parameters.AddWithValue("@Balance", Decimal.Parse(txtBalance.Text))
            cmd_Add.Parameters.AddWithValue("@Image", txtImagePath.Text)
            cmd_Add.Parameters.AddWithValue("@Notes", txtNotes.Text)

            cmd_Add.ExecuteNonQuery()
            Disconnect()



            MessageBox.Show("✅ تم الاضافة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadPartners()

        Catch ex As Exception
            MessageBox.Show("❌ Error: " & ex.Message)
            Disconnect()
        Finally
            DataGridView.ClearSelection()
        End Try

    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        txtID.Clear()
        txtName.Clear()
        txtPhone.Clear()
        txtCompany.Clear()
        txtBalance.Clear()
        txtCreatedAt.Clear()
        txtNotes.Clear()
        txtImagePath.Clear()
        txtSearch.Clear()
        Barcode.Image = My.Resources.DefaultBarcodeImage
        PictureBox1.Image = My.Resources.DefaultImageclient
        DataGridView.ClearSelection()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txtID.Text = "" Then
                MessageBox.Show("من فضلك اختر العميل / المورد لحذفه أولاً")
                Return
            End If

            If MessageBox.Show("هل أنت متأكد من الحذف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Connect()
                Dim query As String = "DELETE FROM Partners WHERE Partner_ID=@Partner_ID"
                Dim cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@Partner_ID", txtID.Text)
                cmd.ExecuteNonQuery()
                Disconnect()
                MessageBox.Show("🗑️ تم الحذف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPartners()
            End If
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        End Try
        DataGridView.ClearSelection()
    End Sub




    Private Sub LoadPartners()
        Try
            btn_clear.PerformClick()
            ' تحميل أسماء الأعمدة ديناميكيًا من قاعدة البيانات
            LoadColumnNamesFromDB(cmbColumns, "Partners")

            ' تجهيز البحث التفاعلي
            SetupLiveSearch(cmbColumns, txtSearch, ListHelp, "Partners", Me)
            ' إخفاء القائمة في البداية
            ListHelp.Visible = False

            txtID.TextAlign = HorizontalAlignment.Center
            txtName.TextAlign = HorizontalAlignment.Center
            txtPhone.TextAlign = HorizontalAlignment.Center
            txtCompany.TextAlign = HorizontalAlignment.Center
            txtBalance.TextAlign = HorizontalAlignment.Center
            txtNotes.TextAlign = HorizontalAlignment.Center
            txtSearch.TextAlign = HorizontalAlignment.Center
            txtCreatedAt.TextAlign = HorizontalAlignment.Center
            txtID.TextAlign = HorizontalAlignment.Center
            cmbType.TextAlign = HorizontalAlignment.Center
            cmbColumns.TextAlign = HorizontalAlignment.Center
            Connect()
            da = New SqlDataAdapter("SELECT Partner_ID, Partner_Name, Partner_Type, Phone, CompanyName, Balance, ImagePath ,Notes ,CreatedAt FROM Partners", Conn)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView.DataSource = dt

            ' تحسين تصميم الداتا جريد
            With DataGridView


                ' ✅ منع المستخدم من إضافة أو حذف صفوف يدويًا
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False

                ' ✅ ضبط النص في المنتصف داخل الخلايا
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                ' ✅ إظهار عناوين الأعمدة (لو كانت مخفية)
                .ColumnHeadersVisible = True

                ' ✅ عناوين الأعمدة
                .Columns("Partner_ID").HeaderText = "ID"
                .Columns("Partner_Name").HeaderText = "Name"
                .Columns("Partner_Type").HeaderText = "Type"
                .Columns("Phone").HeaderText = "Phone"
                .Columns("CompanyName").HeaderText = "Company"
                .Columns("Balance").HeaderText = "Balance"
                .Columns("ImagePath").HeaderText = "Image"
                .Columns("Notes").HeaderText = "Image"
                .Columns("CreatedAt").HeaderText = "Image"

                ' ✅ عرض الأعمدة بالتساوي
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                ' ✅ تحسين مظهر الصفوف
                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
                .DefaultCellStyle.Font = New Font("Segoe UI", 12)
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255)
                .DefaultCellStyle.SelectionForeColor = Color.White

                ' ✅ تحسين عناوين الأعمدة
                .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 102, 153)
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .EnableHeadersVisualStyles = False   ' ← لازم False علشان التنسيق يبان فعلاً

                ' ✅ حدود الصفوف والخلايا
                .GridColor = Color.LightGray
                .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
                .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

                ' ✅ شكل جميل للصفوف
                .RowTemplate.Height = 30
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
            End With
            Connect()
            Dim cmd2 As New SqlCommand("SELECT DISTINCT Partner_Type FROM Partners", Conn)
            Dim da2 As New SqlDataAdapter(cmd2)
            Dim dt2 As New DataTable()
            da2.Fill(dt2)

            ' تأكد من مسح أي عناصر قديمة
            cmbType.DataSource = Nothing
            cmbType.Items.Clear()

            cmbType.DataSource = dt2
            cmbType.DisplayMember = "Partner_Type"
            cmbType.ValueMember = "Partner_Type"
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            Disconnect()
        End Try


    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' ✅ تأكد إن فيه ID صالح
        If String.IsNullOrWhiteSpace(txtID.Text) Then
            MessageBox.Show("⚠️ من فضلك اختر سجل للتعديل عليه أولًا.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Connect()
            ' ✅ استعلام التعديل
            Dim query_update As String = "
            UPDATE Partners 
            SET Partner_Name = @Name,
                Partner_Type = @Type,
                Phone = @Phone,
                CompanyName = @Company,
                Balance = @Balance,
                ImagePath = @Image,
                Notes = @Notes
            WHERE Partner_ID = @ID
        "

            ' ✅ إعداد الأوامر
            Dim cmd_update As New SqlCommand(query_update, Conn)
            cmd_update.Parameters.AddWithValue("@ID", Integer.Parse(txtID.Text))
            cmd_update.Parameters.AddWithValue("@Name", txtName.Text)
            cmd_update.Parameters.AddWithValue("@Type", cmbType.Text)
            cmd_update.Parameters.AddWithValue("@Phone", txtPhone.Text)
            cmd_update.Parameters.AddWithValue("@Company", txtCompany.Text)
            cmd_update.Parameters.AddWithValue("@Balance", If(String.IsNullOrWhiteSpace(txtBalance.Text), 0, Decimal.Parse(txtBalance.Text)))
            cmd_update.Parameters.AddWithValue("@Image", txtImagePath.Text)
            cmd_update.Parameters.AddWithValue("@Notes", txtNotes.Text)

            ' ✅ تنفيذ التعديل



            If MessageBox.Show("هل أنت متأكد من التعديل؟", "تأكيد التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                cmd_update.ExecuteNonQuery()
                MessageBox.Show("✅ تم تعديل البيانات بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPartners()
                btn_clear.PerformClick()

            Else
                MessageBox.Show("⚠️ لم يتم العثور على السجل المطلوب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Disconnect()
        Catch ex As Exception
            MessageBox.Show("❌ حدث خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Disconnect()
        End Try
    End Sub

    Private Sub btn_ExportToExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportToExcel.Click
        ExportToExcel_EPPlus()
    End Sub

    Private Function GetNextID() As Integer
        Dim nextID As Integer = 1 ' القيمة الافتراضية لو الجدول فاضي

        Try
            Connect()
            Dim query3 As String = "SELECT ISNULL(MAX(Partner_ID), 0) + 1 FROM Partners"
            Dim cmd3 As New SqlCommand(query3, Conn)

            nextID = Convert.ToInt32(cmd3.ExecuteScalar())
            Disconnect()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء جلب آخر ID: " & ex.Message)
            Disconnect()
        Finally
            Disconnect()
        End Try

        Return nextID
    End Function

    Private Sub ExportToExcel_EPPlus()
        ' استخدم SaveFileDialog للسماح للمستخدم باختيار مكان حفظ الملف
        Using sfd As New SaveFileDialog()
            sfd.Filter = "ملف إكسل (*.xlsx)|*.xlsx"
            sfd.Title = "تصدير بيانات الشركاء إلى ملف إكسل"
            sfd.FileName = "Partners_Export.xlsx" ' اسم افتراضي

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    ' يجب إضافة هذا السطر قبل أي استخدام لـ ExcelPackage
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                    ' 1. جلب البيانات من قاعدة البيانات (كما كان سابقًا)
                    Dim dt As New DataTable()
                    Connect()
                    Dim adapter As New SqlDataAdapter("SELECT Partner_Name, Partner_Type, Phone, CompanyName, Balance, Notes, CreatedAt FROM Partners", Conn)
                    adapter.Fill(dt)
                    Disconnect()

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("لا توجد بيانات لتصديرها.", "تصدير", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    ' 2. تهيئة سياق EPPlus (مطلوب لإصدارات EPPlus الأحدث)
                    ' تحتاج إلى وضع هذا السطر لضمان أن EPPlus يعمل بترخيص غير تجاري
                    ' إذا كنت تستخدم ترخيصًا تجاريًا، ستحتاج إلى إعداد الترخيص بدلاً من ذلك.
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial

                    ' 3. إنشاء ملف Excel جديد
                    Using package As New ExcelPackage()
                        ' إضافة ورقة عمل (Worksheet)
                        Dim worksheet = package.Workbook.Worksheets.Add("Partners Data")

                        ' تحميل DataTable مباشرة إلى ورقة العمل (يتم تحميل الرؤوس والبيانات تلقائيًا)
                        worksheet.Cells("A1").LoadFromDataTable(dt, True)

                        ' تنسيق إضافي (اختياري)
                        worksheet.Cells(worksheet.Dimension.Address).AutoFitColumns() ' احتواء تلقائي للأعمدة

                        ' تنسيق رؤوس الأعمدة (اختياري)
                        Using range = worksheet.Cells(1, 1, 1, dt.Columns.Count)
                            range.Style.Font.Bold = True
                            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                        End Using

                        ' 4. حفظ الملف
                        Dim fileInfo As New FileInfo(sfd.FileName)
                        package.SaveAs(fileInfo)
                    End Using

                    MessageBox.Show("✅ تم تصدير البيانات بنجاح باستخدام EPPlus.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show("❌ فشل التصدير باستخدام EPPlus: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        ImportFromExcel_EPPlus()
    End Sub

    Private Sub ImportFromExcel_EPPlus()
        ' استخدم OpenFileDialog للسماح للمستخدم باختيار ملف Excel
        Using ofd As New OpenFileDialog()
            ofd.Filter = "ملف إكسل (*.xlsx)|*.xlsx" ' EPPlus يدعم XLSX بشكل أساسي
            ofd.Title = "استيراد بيانات الشركاء من ملف إكسل"

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    ' تهيئة سياق EPPlus (مطلوب)
                    ' يجب إضافة هذا السطر قبل أي استخدام لـ ExcelPackage
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                    ' 1. فتح ملف Excel
                    Dim fileInfo As New FileInfo(ofd.FileName)
                    Using package As New ExcelPackage(fileInfo)
                        ' افتراض أن البيانات في ورقة العمل الأولى
                        Dim worksheet = package.Workbook.Worksheets(0)

                        ' تحديد نطاق البيانات المستخدمة
                        Dim startRow As Integer = 2 ' نبدأ من الصف الثاني لتخطي رؤوس الأعمدة
                        Dim rowCount As Integer = worksheet.Dimension.End.Row

                        Connect()
                        ' استعلام الإدراج (يجب أن يتطابق ترتيب الأعمدة مع ملف الإكسل)
                        Dim query_Import As String = "INSERT INTO Partners (Partner_Name, Partner_Type, Phone, CompanyName, Balance, Notes, CreatedAt) VALUES (@Partner_Name, @Type, @Phone, @Company, @Balance, @Notes, GETDATE())"
                        Dim cmd_Import As New SqlCommand(query_Import, Conn)

                        ' 2. قراءة البيانات من الصف الثاني حتى النهاية
                        For i As Integer = startRow To rowCount
                            ' قراءة القيم مباشرة من الخلية (Cells(الصف, العمود))

                            Dim partnerName As String = worksheet.Cells(i, 1).GetValue(Of String)()
                            Dim type As String = worksheet.Cells(i, 2).GetValue(Of String)()
                            Dim phone As String = worksheet.Cells(i, 3).GetValue(Of String)()
                            Dim company As String = worksheet.Cells(i, 4).GetValue(Of String)()

                            ' نستخدم GetValue(Of Decimal) لضمان تحويل صحيح للأرقام
                            Dim balance As Decimal = worksheet.Cells(i, 5).GetValue(Of Decimal)()
                            Dim notes As String = worksheet.Cells(i, 6).GetValue(Of String)()
                            ' عمود 7 (ImagePath) لم يتم استخدامه هنا، لذا نضعه كـ DBNull أو نتركه.
                            ' إذا كان عمود ImagePath غير مهم، يمكنك إزالتة من استعلام INSERT وترك الأعمدة الأساسية فقط، أو وضع قيمة فارغة

                            ' إعداد وتعيين البارامترات
                            cmd_Import.Parameters.Clear()
                            cmd_Import.Parameters.AddWithValue("@Partner_Name", partnerName)
                            cmd_Import.Parameters.AddWithValue("@Type", type)
                            cmd_Import.Parameters.AddWithValue("@Phone", phone)
                            cmd_Import.Parameters.AddWithValue("@Company", company)
                            cmd_Import.Parameters.AddWithValue("@Balance", balance)
                            cmd_Import.Parameters.AddWithValue("@Notes", notes)

                            ' تنفيذ الاستعلام
                            cmd_Import.ExecuteNonQuery()
                        Next

                        Disconnect()
                    End Using ' يضمن إغلاق ملف Excel

                    MessageBox.Show("✅ تم استيراد البيانات بنجاح وحفظها في قاعدة البيانات.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadPartners() ' تحديث عرض البيانات بعد الإضافة

                Catch ex As Exception
                    MessageBox.Show("❌ فشل الاستيراد. تأكد من تطابق تنسيق أعمدة ملف الإكسل (6 أعمدة بالترتيب). الخطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Disconnect() ' التأكد من إغلاق الاتصال في حالة حدوث خطأ
                End Try
            End If
        End Using
    End Sub
End Class