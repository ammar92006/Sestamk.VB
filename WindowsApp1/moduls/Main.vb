Imports System.Data.SqlClient

Module Main
    Public Sub datagridviewsetup(dgv As DataGridView)
        With dgv
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
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .MultiSelect = False
        End With
    End Sub

    Public Sub OpenFormOnce(ByVal formType As Type, ByVal btn As ToolStripButton)
        ' نبحث عن أي فورم من نفس النوع مفتوحة بالفعل
        For Each f As Form In Application.OpenForms
            If f.GetType() Is formType Then
                ' لو موجودة: نعرضها ونخليها في المقدمة
                f.Show()
                f.BringToFront()
                f.Activate()
                btn.Checked = True
                Return
            End If
        Next

        ' لو مش موجودة: نفتح واحدة جديدة
        Dim frm As Form = CType(Activator.CreateInstance(formType), Form)

        ' لما الفورم تتقفل نرجع الزرار لحالته الطبيعية
        AddHandler frm.FormClosed, Sub(sender, e)
                                       btn.Checked = False
                                   End Sub

        frm.Show()
        btn.Checked = True
    End Sub

    Public Sub InitializeShiftSession()
        Dim repo As New POSRepository(DBModule.ConnectionString)

        ' 1. البحث عن الوردية المفتوحة حالياً في الداتا بيز
        Dim activeShift As ShiftModel = repo.GetActiveShift()

        If activeShift IsNot Nothing Then
            ' توجد وردية مفتوحة بالفعل -> إسنادها للـ Cache فوراً
            ShiftSession.CurrentShift = activeShift
        Else
            ' لا توجد وردية مفتوحة -> تفريغ الـ Session
            ShiftSession.ClearSession()
        End If
    End Sub

    Public Function GetNextCode(tableName As String, codeColumn As String) As Integer
        Dim nextCode As Integer = 1

        Try
            Using con As New SqlConnection(ConnectionString)
                con.Open()

                Dim sql As String = $"
                SELECT ISNULL(MAX(TRY_CONVERT(INT, [{codeColumn}])), 0) + 1
                FROM [{tableName}]"

                Using cmd As New SqlCommand(sql, con)
                    nextCode = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

        Catch ex As Exception
            'MessageBox.Show("حدث خطأ أثناء جلب الكود التالي:" & vbCrLf & ex.Message)
        End Try

        Return nextCode
    End Function

End Module
