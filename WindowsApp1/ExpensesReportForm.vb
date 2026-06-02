Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading.Tasks

Public Class ExpensesReportForm

    Dim x, y As Integer
    Dim newpoint As New Point

    Private Sub SetupDataGridViewSales(ByVal dgv As DataGridView)
        dgv.AllowUserToAddRows = False
        'dgv.AllowUser = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False

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

        With dgv

            '.Columns.Clear()
            '.Columns("Invoice_ID").HeaderText = "كود الفاتورة"
            '.Columns("Invoice_Date").HeaderText = "تاريخ الفاتورة"
            '.Columns("CustomerName").HeaderText = "اسم العميل"
            '.Columns("Total_Amount").HeaderText = "اجمالي الفاتورة"
            '.Columns("Discount_Value").HeaderText = "الخصم"
            '.Columns("Net_Amount").HeaderText = "الصافي"
            '.Columns("Amount_Paid").HeaderText = "المدفوع"
            '.Columns("Remaining").HeaderText = "المتبقي"
            '.Columns("Payment_Method").HeaderText = "طريقه الدفع"
            '.Columns("User_Name").HeaderText = "اسم المستخدم"
            '.Columns("Product_ID").HeaderText = "ID المنتج"
            '.Columns("Product_Name").HeaderText = "اسم المنتج"
            '.Columns("Quantity_Sold").HeaderText = "الكمية الاساسية"
            '.Columns("Sale_Price_Per_Unit").HeaderText = "سعر البيع"
            '.Columns("Total_Line_Amount").HeaderText = "اجمالي Line"


            '    .Columns("ColProductID").Visible = False
            '    .Columns("ColUnitID").Visible = False
            '    .Columns("ColFactor").Visible = False

            '    Dim btnCol As New DataGridViewButtonColumn()
            '    btnCol.HeaderText = "حذف"
            '    btnCol.Text = "❌"
            '    btnCol.Name = "ColDelete"
            '    btnCol.UseColumnTextForButtonValue = True
            '    .Columns.Add(btnCol)

            '.Columns("ColProductName").Width = 230
            '    .Columns("ColQuantity").Width = 160

            '    .Columns("ColPrice").DefaultCellStyle.Format = "N2"
            '    .Columns("ColTotal").DefaultCellStyle.Format = "N2"

            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            dgv.RowTemplate.Height = 40
            dgv.ColumnHeadersHeight = 60

            dgv.ColumnHeadersDefaultCellStyle.BackColor = darkHeader
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            dgv.DefaultCellStyle.SelectionBackColor = highlightColor
            dgv.DefaultCellStyle.SelectionForeColor = Color.White
            dgv.DefaultCellStyle.Font = New Font("Segoe UI", 12.0!)

            dgv.RowHeadersVisible = False
            dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

        End With

    End Sub
    ' سلسلة الاتصال بقاعدة البيانات
    Private ReadOnly connString As String = ConnectionString

    ' عند تحميل الشاشة
    Private Async Sub ExpensesReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' إعداد التواريخ الافتراضية (من بداية الشهر الحالي إلى اليوم)
        dtpFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpTo.Value = DateTime.Now

        ' تحميل التصنيفات في قائمة الفلترة
        LoadCategoriesFilter()
        SetupDataGridViewSales(dgvReport)
        ' عرض كل البيانات عند الفتح
        Await FilterDataAsync()
    End Sub

    ' تعبئة كومبو بوكس الفلترة بالتصنيفات الموجودة فعلياً في القاعدة
    Private Sub LoadCategoriesFilter()
        cmbCategoryFilter.Items.Clear()
        cmbCategoryFilter.Items.Add("الكل")

        ' يمكنك إضافة التصنيفات يدوياً أو جلبها من قاعدة البيانات Distinct
        cmbCategoryFilter.Items.AddRange(New String() {"طعام وشراب", "مواصلات", "سكن وإيجار", "فواتير (كهرباء/ماء)", "صحة وعلاج", "ترفيه", "تسوق", "أخرى"})
        cmbCategoryFilter.SelectedIndex = 0
    End Sub

    ' الدالة الرئيسية لجلب البيانات المفلترة
    Private Async Function FilterDataAsync() As Task
        Dim query As String = "SELECT Expense_ID as [كود], Expense_Date as [التاريخ], Category as [التصنيف], " &
                             "Amount as [المبلغ], Payee as [الجهة], Payment_Method as [طريقة الدفع], " &
                             "Payment_Status as [الحالة], Notes as [ملاحظات] " &
                             "FROM Expenses WHERE Expense_Date BETWEEN @From AND @To "

        ' إضافة شرط التصنيف إذا لم يكن "الكل"
        If cmbCategoryFilter.Text <> "الكل" Then
            query &= " AND Category = @Category "
        End If

        query &= " ORDER BY Expense_Date DESC"

        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@From", dtpFrom.Value.Date)
            cmd.Parameters.AddWithValue("@To", dtpTo.Value.Date)

            If cmbCategoryFilter.Text <> "الكل" Then
                cmd.Parameters.AddWithValue("@Category", cmbCategoryFilter.Text)
            End If

            Try
                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()

                Await Task.Run(Sub() adapter.Fill(dt))

                dgvReport.DataSource = dt

                ' تحسين شكل الجدول (اختياري)
                'FormatGrid()

                ' تحديث الإجمالي
                CalculateSummary(dt)

            Catch ex As Exception
                MessageBox.Show("خطأ أثناء جلب التقارير: " & ex.Message, "خطأ فني", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function

    ' زر البحث/تطبيق الفلتر
    Private Async Sub btnApplyFilter_Click(sender As Object, e As EventArgs) Handles btnApplyFilter.Click
        Await FilterDataAsync()
    End Sub

    ' حساب المجموع الكلي وعدد العمليات
    Private Sub CalculateSummary(dt As DataTable)
        Dim total As Decimal = 0
        Dim count As Integer = dt.Rows.Count

        For Each row As DataRow In dt.Rows
            total += Convert.ToDecimal(row("المبلغ"))
        Next

        lblTotalAmount.Text = total.ToString("N2") & " ج.م"
        lblOperationCount.Text = count.ToString()
    End Sub

    ' تنسيق أعمدة الجدول لتظهر بشكل لائق
    Private Sub FormatGrid()
        If dgvReport.Columns.Count > 0 Then
            dgvReport.Columns("المبلغ").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("المبلغ").DefaultCellStyle.ForeColor = Color.DarkGreen
            dgvReport.Columns("المبلغ").DefaultCellStyle.Font = New Font(dgvReport.Font, FontStyle.Bold)

            ' جعل التاريخ يظهر بشكل مختصر
            dgvReport.Columns("التاريخ").DefaultCellStyle.Format = "yyyy-MM-dd"
        End If
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

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Label1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, Label1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    ' حدث النقر على زر الحذف
    Private Async Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        ' 1. التأكد من أن المستخدم اختار صفاً من الجدول
        If dgvReport.SelectedRows.Count = 0 Then
            MessageBox.Show("من فضلك اختر المصروف الذي تريد حذفه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. إظهار رسالة تأكيد للحذف
        ' ملحوظة: استخدمت MessageBox.Show هنا لأنها الطريقة القياسية في تطبيقات Desktop VB.NET
        Dim confirmResult = MessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا المصروف نهائياً؟",
                                            "تأكيد الحذف",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2)

        If confirmResult = DialogResult.No Then Return

        ' 3. جلب رقم المعرف (ID) من الصف المحدد
        ' نستخدم اسم العمود "كود" كما هو معرف في دالة FilterDataAsync
        Dim selectedExpenseId As Integer = 0
        Try
            selectedExpenseId = Convert.ToInt32(dgvReport.SelectedRows(0).Cells("كود").Value)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء محاولة تحديد كود المصروف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' 4. تنفيذ عملية الحذف من قاعدة البيانات
        Dim deleteQuery As String = "DELETE FROM Expenses WHERE Expense_ID = @ID"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(deleteQuery, conn)
                cmd.Parameters.AddWithValue("@ID", selectedExpenseId)

                Try
                    ' فتح الاتصال بشكل غير متزامن
                    Await conn.OpenAsync()

                    ' تنفيذ الحذف
                    Dim rowsAffected As Integer = Await cmd.ExecuteNonQueryAsync()

                    If rowsAffected > 0 Then
                        MessageBox.Show("تم حذف البيانات بنجاح.", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' 5. تحديث الجدول لإظهار البيانات الجديدة بعد الحذف
                        Await FilterDataAsync()
                    Else
                        MessageBox.Show("لم يتم العثور على السجل في قاعدة البيانات، ربما تم حذفه مسبقاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                Catch ex As SqlException
                    MessageBox.Show("خطأ في قاعدة البيانات أثناء الحذف: " & ex.Message, "خطأ فني", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("حدث خطأ غير متوقع: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub





End Class