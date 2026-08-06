Imports System.Data.SqlClient

Public Class frmCategoryTypes
    Dim x, y As Integer
    Dim newpoint As New Point

    ' 1. دالة تحميل وجلب البيانات للجدول (تستبعد المحذوف منطقياً)
    Private Sub LoadTypesGrid()
        ClearFields()
        Dim query As String = "SELECT CategoryTypeID, TypeCode, TypeName, IsActive FROM CategoryTypes WHERE IsDeleted = 0 OR IsDeleted IS NULL"
        Dim dt As DataTable = DBModule.ExecuteQuery(query)

        If dt IsNot Nothing Then
            dgvCategoryTypes.DataSource = dt

            ' تنسيق الأعمدة باللغة العربية
            If dgvCategoryTypes.Columns.Contains("CategoryTypeID") Then dgvCategoryTypes.Columns("CategoryTypeID").Visible = False
            dgvCategoryTypes.Columns("TypeCode").HeaderText = "كود النوع"
            dgvCategoryTypes.Columns("TypeName").HeaderText = "اسم نوع الفئة"
            dgvCategoryTypes.Columns("IsActive").HeaderText = "نشط"
        End If
    End Sub

    ' حدث تحميل الفورم
    Private Sub frmCategoryTypes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTypesGrid()
        datagridviewsetup()
    End Sub

    ' 2. خط الدفاع الأول: دالة التحقق من المدخلات (Validation)
    Private Function IsValidData() As Boolean
        ' التحقق من أن اسم النوع ليس فارغاً (لأنه حقل لا يقبل NULL في قاعدة البيانات)
        If String.IsNullOrWhiteSpace(txtTypeName.Text) Then
            MessageBox.Show("عذراً، يجب إدخال اسم نوع الفئة أولاً!", "تنبيه الـ Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTypeName.Focus()
            Return False
        End If
        Return True
    End Function

    ' 3. دالة تنظيف الحقول وتفريغها
    Private Sub ClearFields()
        txtTypeCode.Clear()
        txtTypeName.Clear()
        tgStatus.Checked = True ' الوضع الافتراضي نشط
        dgvCategoryTypes.ClearSelection() ' إلغاء تحديد الصفوف في الجدول
    End Sub
    Private Sub datagridviewsetup()
        With dgvCategoryTypes

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

            ' ✅ عرض الأعمدة بالتساوي
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .MultiSelect = False
        End With
    End Sub
    ' حدث زر تنظيف الحقول الخاص بك
    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearFields()
    End Sub

    ' 4. حدث التحديد من الجريد فيو لعرض البيانات في التكست بوكس بأمان
    Private Sub dgvCategoryTypes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCategoryTypes.SelectionChanged
        If dgvCategoryTypes.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvCategoryTypes.SelectedRows(0)

        If row.Cells("CategoryTypeID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("CategoryTypeID").Value) Then
            txtTypeCode.Text = If(IsDBNull(row.Cells("TypeCode").Value), "", row.Cells("TypeCode").Value.ToString())
            txtTypeName.Text = If(IsDBNull(row.Cells("TypeName").Value), "", row.Cells("TypeName").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' 5. زر إضافة نوع فئة جديد
    Private Sub btnAddType_Click(sender As Object, e As EventArgs) Handles btnAddType.Click
        ' التحقق من البيانات قبل الإرسال للقاعدة
        If Not IsValidData() Then Exit Sub

        Dim query As String = "INSERT INTO CategoryTypes (TypeCode, TypeName, IsActive, IsDeleted) VALUES (@TypeCode, @TypeName, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@TypeCode", If(String.IsNullOrEmpty(txtTypeCode.Text), DBNull.Value, txtTypeCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@TypeName", txtTypeName.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ نوع الفئة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadTypesGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 6. زر تعديل بيانات نوع الفئة الحالي
    Private Sub btnEditType_Click(sender As Object, e As EventArgs) Handles btnEditType.Click
        If dgvCategoryTypes.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار النوع المراد تعديله من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' التحقق من صحة البيانات
        If Not IsValidData() Then Exit Sub

        Dim currentID As Integer = Convert.ToInt32(dgvCategoryTypes.SelectedRows(0).Cells("CategoryTypeID").Value)
        Dim query As String = "UPDATE CategoryTypes SET TypeCode = @TypeCode, TypeName = @TypeName, IsActive = @IsActive WHERE CategoryTypeID = @CategoryTypeID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@CategoryTypeID", currentID)
                cmd.Parameters.AddWithValue("@TypeCode", If(String.IsNullOrEmpty(txtTypeCode.Text), DBNull.Value, txtTypeCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@TypeName", txtTypeName.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadTypesGrid()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 7. زر الحذف المنطقي لنوع الفئة (Soft Delete)
    Private Sub btnDeleteType_Click(sender As Object, e As EventArgs) Handles btnDeleteType.Click
        If dgvCategoryTypes.SelectedRows.Count = 0 Then
            MessageBox.Show("يرجى اختيار النوع المراد حذفه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من رغبتك في حذف نوع الفئة هذا؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvCategoryTypes.SelectedRows(0).Cells("CategoryTypeID").Value)
            Dim query As String = "UPDATE CategoryTypes SET IsDeleted = 1 WHERE CategoryTypeID = @CategoryTypeID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CategoryTypeID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف نوع الفئة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadTypesGrid()
                        ClearFields()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
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

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class