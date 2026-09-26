Imports System.Data.SqlClient

Module Main
    Public Sub datagridviewsetup(dgv As DataGridView)
        With dgv
            '---------------------------
            ' الصلاحيات والتحكم
            '---------------------------
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            ' منع تغيير حجم الأعمدة والصفوف
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            '---------------------------
            ' الإعدادات العامة للشكل
            '---------------------------
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            '---------------------------
            ' إعداد العنوان (Header)
            '---------------------------
            .EnableHeadersVisualStyles = False
            .ColumnHeadersVisible = True
            .ColumnHeadersHeight = 70
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '---------------------------
            ' إعداد الصفوف (Rows)
            '---------------------------
            .DefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5)

            '---------------------------
            ' تطبيق ألوان السمة الحالية (Light / Dark)
            '---------------------------
            ThemeHelper.ApplyDataGridViewTheme(dgv, ThemeManager.Instance.CurrentPalette)
        End With
    End Sub

    Public Sub datagridviewsetup_Editable(dgv As DataGridView)
        With dgv
            '---------------------------
            ' الصلاحيات والتحكم (قابلة للتعديل)
            '---------------------------
            .ReadOnly = False ' السماح بالتعديل
            .AllowUserToAddRows = True  ' يمكنك جعلها False إذا أردت منعه من إضافة صفوف جديدة
            .AllowUserToDeleteRows = True ' يمكنك جعلها False إذا أردت منعه من حذف الصفوف
            ' منع تغيير حجم الأعمدة والصفوف
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            ' تحديد الخلية فقط بدلاً من الصف بالكامل لتسهيل التعديل
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .MultiSelect = False

            '---------------------------
            ' الإعدادات العامة للشكل
            '---------------------------
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            '---------------------------
            ' إعداد العنوان (Header)
            '---------------------------
            .EnableHeadersVisualStyles = False
            .ColumnHeadersVisible = True
            .ColumnHeadersHeight = 70
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '---------------------------
            ' إعداد الصفوف (Rows)
            '---------------------------
            .DefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5)

            '---------------------------
            ' تطبيق ألوان السمة الحالية (Light / Dark)
            '---------------------------
            ThemeHelper.ApplyDataGridViewTheme(dgv, ThemeManager.Instance.CurrentPalette)
        End With
    End Sub
    Public Sub OpenFormOnce(ByVal formType As Type, ByVal btn As ToolStripButton)
        ' 1. التحقق من صلاحية الفتح
        If Not Session.HasPermission(formType.Name, "CanOpen") Then
            Dim dispName As String = Session.GetScreenDisplayName(formType.Name)
            MessageBox.Show("عفواً، ليس لديك صلاحية لفتح شاشة (" & dispName & ")!", "صلاحيات الوصول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If btn IsNot Nothing Then btn.Checked = False
            Exit Sub
        End If

        ' نبحث عن أي فورم من نفس النوع مفتوحة بالفعل
        For Each f As Form In Application.OpenForms
            If f.GetType() Is formType Then
                ' لو موجودة: نعرضها ونخليها في المقدمة
                f.Show()
                f.BringToFront()
                f.Activate()
                Session.ApplyFormPermissions(f, formType.Name)
                If btn IsNot Nothing Then btn.Checked = True
                Return
            End If
        Next

        ' لو مش موجودة: نفتح واحدة جديدة
        Dim frm As Form = CType(Activator.CreateInstance(formType), Form)

        ' تطبيق الصلاحيات والسمة على الفورم عند التحميل وعند الظهور
        AddHandler frm.Load, Sub(sender, e)
                                 Session.ApplyFormPermissions(frm, formType.Name)
                                 ThemeManager.Instance.ApplyTheme(frm)
                             End Sub
        AddHandler frm.Shown, Sub(sender, e)
                                  Session.ApplyFormPermissions(frm, formType.Name)
                                  ThemeManager.Instance.ApplyTheme(frm)
                              End Sub

        ' لما الفورم تتقفل نرجع الزرار لحالته الطبيعية
        AddHandler frm.FormClosed, Sub(sender, e)
                                       If btn IsNot Nothing Then btn.Checked = False
                                   End Sub

        ThemeManager.Instance.ApplyTheme(frm)
        frm.Show()
        If btn IsNot Nothing Then btn.Checked = True
    End Sub

    Public Sub InitializeShiftSession()
        Try
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
        Catch ex As Exception
            Logger.LogError("InitializeShiftSession", ex)
            ShiftSession.ClearSession()
        End Try
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
