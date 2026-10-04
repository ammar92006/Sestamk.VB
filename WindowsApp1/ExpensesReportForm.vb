Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading.Tasks

Public Class ExpensesReportForm

    Dim x, y As Integer
    Dim newpoint As New Point

    Private Sub SetupDataGridViewSales(ByVal dgv As DataGridView)
        Main.datagridviewsetup(dgv)
        dgv.BorderStyle = BorderStyle.None

        With dgv
            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
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
                SmartMessageBox.Show("خطأ أثناء جلب التقارير: " & ex.Message, "خطأ فني", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        Dim curSymbol = SettingsManager.GetSettingOrDefault(SettingsKeys.Currency, "ج.م")
        lblTotalAmount.Text = total.ToString("N2") & " " & curSymbol
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
            SmartMessageBox.Show("من فضلك اختر المصروف الذي تريد حذفه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. إظهار رسالة تأكيد للحذف
        ' ملحوظة: استخدمت SmartMessageBox.Show هنا لأنها الطريقة القياسية في تطبيقات Desktop VB.NET
        Dim confirmResult = SmartMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا المصروف نهائياً؟",
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
            SmartMessageBox.Show("حدث خطأ أثناء محاولة تحديد كود المصروف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                        SmartMessageBox.Show("تم حذف البيانات بنجاح.", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' 5. تحديث الجدول لإظهار البيانات الجديدة بعد الحذف
                        Await FilterDataAsync()
                    Else
                        SmartMessageBox.Show("لم يتم العثور على السجل في قاعدة البيانات، ربما تم حذفه مسبقاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                Catch ex As SqlException
                    SmartMessageBox.Show("خطأ في قاعدة البيانات أثناء الحذف: " & ex.Message, "خطأ فني", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    SmartMessageBox.Show("حدث خطأ غير متوقع: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub





End Class