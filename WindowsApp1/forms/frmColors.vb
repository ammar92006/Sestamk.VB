Imports System.Data.SqlClient

Public Class frmColors
    Dim x, y As Integer
    Dim newpoint As New Point
    Private _currentColorHex As String = ""

    Private Sub LoadColorsGrid()
        ' نقرأ HexCode فقط من الداتابيز لتلوين المعاينة
        Dim query As String = "SELECT ColorID, ColorCode, ColorName, HexCode, IsActive " &
                              "FROM Colors WHERE IsDeleted = 0 OR IsDeleted IS NULL"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter(cmd)
                    Try
                        conn.Open()
                        da.Fill(dt)
                        dgvColors.DataSource = dt
                        clearfilds()

                        ' إخفاء المعرفات والأكواد الفنية عن عين المستخدم
                        If dgvColors.Columns.Contains("ColorID") Then dgvColors.Columns("ColorID").Visible = False
                        If dgvColors.Columns.Contains("HexCode") Then dgvColors.Columns("HexCode").Visible = False

                        ' تسمية الأعمدة المقروءة فقط
                        If dgvColors.Columns.Contains("ColorCode") Then
                            dgvColors.Columns("ColorCode").HeaderText = "كود اللون"
                            dgvColors.Columns("ColorCode").DisplayIndex = 0
                        End If
                        If dgvColors.Columns.Contains("ColorName") Then
                            dgvColors.Columns("ColorName").HeaderText = "اسم اللون"
                            dgvColors.Columns("ColorName").DisplayIndex = 1
                        End If
                        ' إضافة عمود الدائرة/المربع الملون داخل الجدول إن لم يكن موجوداً
                        If Not dgvColors.Columns.Contains("ColorPreview") Then
                            Dim colPreview As New DataGridViewTextBoxColumn()
                            colPreview.Name = "ColorPreview"
                            colPreview.HeaderText = "اللون"
                            colPreview.Width = 80
                            dgvColors.Columns.Insert(2, colPreview)
                        End If
                        If dgvColors.Columns.Contains("IsActive") Then
                            dgvColors.Columns("IsActive").HeaderText = "نشط"
                            dgvColors.Columns("IsActive").DisplayIndex = 3
                        End If


                    Catch ex As Exception
                        SmartMessageBox.Show("خطأ في جلب الألوان: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End Using
    End Sub

    ' تلوين الخلية المخصصة بلون الخامة/الصنف في الجدول مباشرة
    Private Sub dgvColors_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvColors.CellPainting
        ' تطبيق الرسم فقط على عمود المعاينة
        If e.RowIndex >= 0 AndAlso dgvColors.Columns(e.ColumnIndex).Name = "ColorPreview" Then
            e.PaintBackground(e.ClipBounds, True)

            Dim row As DataGridViewRow = dgvColors.Rows(e.RowIndex)
            If row.Cells("HexCode").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("HexCode").Value) Then
                Dim hex As String = row.Cells("HexCode").Value.ToString()
                If Not String.IsNullOrWhiteSpace(hex) Then
                    Try
                        Using br As New SolidBrush(ColorTranslator.FromHtml(hex))
                            ' رسم مربع لوني ناعم بحدود دائرية في منتصف الخلية
                            Dim rect As New Rectangle(e.CellBounds.X + (e.CellBounds.Width - 40) \ 2, e.CellBounds.Y + (e.CellBounds.Height - 20) \ 2, 60, 20)
                            e.Graphics.FillRectangle(br, rect)
                            e.Graphics.DrawRectangle(Pens.Gray, rect)
                        End Using
                    Catch __logEx As Exception
                        Logger.LogError("frmColors.vb:75", __logEx)
                    End Try
                End If
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub frmColors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        datagridviewsetup(dgvColors)
        LoadColorsGrid()
        txtColorCode.Text = GetNextCode("Colors", "ColorCode")
    End Sub

    ' فتح ColorDialog عند النقر على الزر أو النقر على مربع المعاينة
    Private Sub btnPickColor_Click(sender As Object, e As EventArgs) Handles btnPickColor.Click, pnlColorPreview.Click
        Using cd As New ColorDialog()
            cd.AllowFullOpen = True
            cd.AnyColor = True
            cd.FullOpen = True

            If cd.ShowDialog() = DialogResult.OK Then
                SetChosenColor(cd.Color)
            End If
        End Using
    End Sub

    Private Sub SetChosenColor(c As Color)
        pnlColorPreview.FillColor = c
        _currentColorHex = $"#{c.R:X2}{c.G:X2}{c.B:X2}"
    End Sub

    'Private Sub datagridviewsetup()
    '    With dgvColors
    '        .ReadOnly = True
    '        .AllowUserToAddRows = False
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToResizeColumns = False
    '        .AllowUserToResizeRows = False
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '        .RowHeadersVisible = False
    '        .MultiSelect = False
    '        .BackgroundColor = Color.FromArgb(30, 30, 35)

    '        ' توحيد لون الهيدر
    '        .EnableHeadersVisualStyles = False
    '        .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 43)
    '        .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    '        .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .ColumnHeadersHeight = 45

    '        ' توحيد ألوان الصفوف الغامقة وإلغاء اللون الأبيض
    '        .DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 50)
    '        .DefaultCellStyle.ForeColor = Color.White
    '        .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180)
    '        .DefaultCellStyle.SelectionForeColor = Color.White
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '        ' حل مشكلة الصف الأبيض المتبادل:
    '        .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 40)
    '        .AlternatingRowsDefaultCellStyle.ForeColor = Color.White
    '        .AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180)
    '        .AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White
    '    End With
    'End Sub
    ' جلب تفاصيل اللون المختار من الجدول وعرض لونه في مربع المعاينة
    Private Sub dgvColors_SelectionChanged(sender As Object, e As EventArgs) Handles dgvColors.SelectionChanged
        If dgvColors.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvColors.SelectedRows(0)

        If row.Cells("ColorID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ColorID").Value) Then
            txtColorCode.Text = If(IsDBNull(row.Cells("ColorCode").Value), "", row.Cells("ColorCode").Value.ToString())
            txtColorName.Text = If(IsDBNull(row.Cells("ColorName").Value), "", row.Cells("ColorName").Value.ToString())
            'txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))

            If Not IsDBNull(row.Cells("HexCode").Value) Then
                _currentColorHex = row.Cells("HexCode").Value.ToString()
                Try
                    pnlColorPreview.FillColor = ColorTranslator.FromHtml(_currentColorHex)
                Catch
                    pnlColorPreview.FillColor = Color.Black
                End Try
            Else
                _currentColorHex = ""
                pnlColorPreview.FillColor = Color.Black
            End If
        End If
    End Sub

    ' 1. إضافة لون جديد
    Private Sub btnAddColor_Click(sender As Object, e As EventArgs) Handles btnAddColor.Click
        If String.IsNullOrWhiteSpace(txtColorName.Text) Then
            SmartMessageBox.Show("يرجى إدخال اسم اللون!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtColorName.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(_currentColorHex) Then
            SmartMessageBox.Show("يرجى اختيار اللون بالضغط على زر (اختر اللون)!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "INSERT INTO Colors (ColorCode, ColorName, HexCode, IsActive, IsDeleted) " &
                              "VALUES (@ColorCode, @ColorName, @HexCode, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ColorCode", If(String.IsNullOrEmpty(txtColorCode.Text), GetNextCode("Colors", "ColorCode").ToString(), txtColorCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@ColorName", txtColorName.Text.Trim())
                cmd.Parameters.AddWithValue("@HexCode", _currentColorHex)
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                'cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    SmartMessageBox.Show("تم حفظ اللون بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadColorsGrid()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 2. تعديل لون موجود
    Private Sub btnEditColor_Click(sender As Object, e As EventArgs) Handles btnEditColor.Click
        If dgvColors.SelectedRows.Count = 0 Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvColors.SelectedRows(0).Cells("ColorID").Value)

        If String.IsNullOrWhiteSpace(txtColorName.Text) Then
            SmartMessageBox.Show("يرجى إدخال اسم اللون!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "UPDATE Colors SET ColorCode = @ColorCode, ColorName = @ColorName, " &
                              "HexCode = @HexCode, IsActive = @IsActive WHERE ColorID = @ColorID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ColorID", currentID)
                cmd.Parameters.AddWithValue("@ColorCode", If(String.IsNullOrEmpty(txtColorCode.Text), DBNull.Value, txtColorCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@ColorName", txtColorName.Text.Trim())
                cmd.Parameters.AddWithValue("@HexCode", _currentColorHex)
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                'cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    SmartMessageBox.Show("تم تعديل اللون بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadColorsGrid()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء التعديل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' 3. حذف اللون (Soft Delete)
    Private Sub btnDeleteColor_Click(sender As Object, e As EventArgs) Handles btnDeleteColor.Click
        If dgvColors.SelectedRows.Count = 0 Then Exit Sub

        If SmartMessageBox.Show("هل أنت متأكد من حذف هذا اللون؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvColors.SelectedRows(0).Cells("ColorID").Value)
            Dim query As String = "UPDATE Colors SET IsDeleted = 1 WHERE ColorID = @ColorID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ColorID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        SmartMessageBox.Show("تم حذف اللون بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadColorsGrid()
                    Catch ex As Exception
                        SmartMessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        txtColorCode.Text = GetNextCode("Colors", "ColorCode")
        txtColorName.Clear()
        _currentColorHex = ""
        pnlColorPreview.FillColor = Color.Black
        tgStatus.Checked = True
        dgvColors.ClearSelection()
    End Sub
End Class