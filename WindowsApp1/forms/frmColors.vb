Imports System.Data.SqlClient

Public Class frmColors
    Dim x, y As Integer
    Dim newpoint As New Point
    ' دالة تحميل البيانات وعرضها داخل الجدول
    Private Sub LoadColorsGrid()
        ' استبعاد الألوان المحذوفة منطقياً
        Dim query As String = "SELECT ColorID, ColorCode, ColorName, HexCode, RGB, IsActive, Notes FROM Colors WHERE IsDeleted = 0 OR IsDeleted IS NULL"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter(cmd)
                    Try
                        conn.Open()
                        da.Fill(dt)
                        dgvColors.DataSource = dt
                        clearfilds()
                        ' تنسيق الأعمدة
                        If dgvColors.Columns.Contains("ColorID") Then dgvColors.Columns("ColorID").Visible = False
                        dgvColors.Columns("ColorCode").HeaderText = "كود اللون"
                        dgvColors.Columns("ColorName").HeaderText = "اسم اللون"
                        dgvColors.Columns("HexCode").HeaderText = "كود الـ Hex"
                        dgvColors.Columns("RGB").HeaderText = "RGB"
                        dgvColors.Columns("IsActive").HeaderText = "نشط"
                        dgvColors.Columns("Notes").HeaderText = "ملاحظات"
                    Catch ex As Exception
                        MessageBox.Show("خطأ في جلب الألوان: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End Using
    End Sub

    ' حدث تحميل الفورم
    Private Sub frmColors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datagridviewsetup()
        LoadColorsGrid()
    End Sub

    Private Sub datagridviewsetup()
        With dgvColors
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


    ' حدث التحديد من الجريد فيو لعرض البيانات في التكست بوكس
    Private Sub dgvColors_SelectionChanged(sender As Object, e As EventArgs) Handles dgvColors.SelectionChanged
        If dgvColors.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvColors.SelectedRows(0)

        If row.Cells("ColorID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ColorID").Value) Then
            txtColorCode.Text = If(IsDBNull(row.Cells("ColorCode").Value), "", row.Cells("ColorCode").Value.ToString())
            txtColorName.Text = If(IsDBNull(row.Cells("ColorName").Value), "", row.Cells("ColorName").Value.ToString())
            txtHexCode.Text = If(IsDBNull(row.Cells("HexCode").Value), "", row.Cells("HexCode").Value.ToString())
            txtRGB.Text = If(IsDBNull(row.Cells("RGB").Value), "", row.Cells("RGB").Value.ToString())
            txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    ' 1. دالة إضافة لون جديد
    Private Sub btnAddColor_Click(sender As Object, e As EventArgs) Handles btnAddColor.Click
        If String.IsNullOrWhiteSpace(txtColorName.Text) Then
            MessageBox.Show("يرجى إدخال اسم اللون أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "INSERT INTO Colors (ColorCode, ColorName, HexCode, RGB, IsActive, IsDeleted, Notes) " &
                              "VALUES (@ColorCode, @ColorName, @HexCode, @RGB, @IsActive, 0, @Notes)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ColorCode", If(String.IsNullOrEmpty(txtColorCode.Text), DBNull.Value, txtColorCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@ColorName", txtColorName.Text.Trim())
                cmd.Parameters.AddWithValue("@HexCode", If(String.IsNullOrEmpty(txtHexCode.Text), DBNull.Value, txtHexCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@RGB", If(String.IsNullOrEmpty(txtRGB.Text), DBNull.Value, txtRGB.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم حفظ اللون بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadColorsGrid()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 2. دالة تعديل اللون الحالي
    Private Sub btnEditColor_Click(sender As Object, e As EventArgs) Handles btnEditColor.Click
        If dgvColors.SelectedRows.Count = 0 Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvColors.SelectedRows(0).Cells("ColorID").Value)

        Dim query As String = "UPDATE Colors SET ColorCode = @ColorCode, ColorName = @ColorName, HexCode = @HexCode, " &
                              "RGB = @RGB, IsActive = @IsActive, Notes = @Notes WHERE ColorID = @ColorID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ColorID", currentID)
                cmd.Parameters.AddWithValue("@ColorCode", If(String.IsNullOrEmpty(txtColorCode.Text), DBNull.Value, txtColorCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@ColorName", txtColorName.Text.Trim())
                cmd.Parameters.AddWithValue("@HexCode", If(String.IsNullOrEmpty(txtHexCode.Text), DBNull.Value, txtHexCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@RGB", If(String.IsNullOrEmpty(txtRGB.Text), DBNull.Value, txtRGB.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("تم تعديل البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadColorsGrid()
                Catch ex As Exception
                    MessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 3. دالة الحذف المنطقي (Soft Delete)
    Private Sub btnDeleteColor_Click(sender As Object, e As EventArgs) Handles btnDeleteColor.Click
        If dgvColors.SelectedRows.Count = 0 Then Exit Sub

        Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا اللون؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvColors.SelectedRows(0).Cells("ColorID").Value)
            Dim query As String = "UPDATE Colors SET IsDeleted = 1 WHERE ColorID = @ColorID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ColorID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف اللون بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadColorsGrid()

                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown, Panel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove, Panel1.MouseMove
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearfilds()
    End Sub

    Private Sub clearfilds()
        txtColorCode.Clear()
        txtColorName.Clear()
        txtHexCode.Clear()
        txtRGB.Clear()
        txtNotes.Clear()
        tgStatus.Checked = False

    End Sub
End Class