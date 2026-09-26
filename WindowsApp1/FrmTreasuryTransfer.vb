Imports System.Data.SqlClient

Public Class FrmTreasuryTransfer
    Private _x, _y As Integer
    Private _newPoint As New Point

    Private defaultTreasuryid As Integer = -1


    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown, lbltitle.MouseDown
        _x = Control.MousePosition.X - Me.Location.X
        _y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove, lbltitle.MouseMove
        If e.Button = MouseButtons.Left Then
            _newPoint = Control.MousePosition
            _newPoint.X -= _x
            _newPoint.Y -= _y
            Me.Location = _newPoint
        End If
    End Sub
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Async Sub FrmTreasuryTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadTreasuriesAsync()
    End Sub

    Private Async Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click

        ' 1. التحقق من اختيار الخزن
        If cmbFromTreasury.SelectedValue Is Nothing OrElse cmbToTreasury.SelectedValue Is Nothing Then
            MessageBox.Show("يرجى اختيار الخزنة المصدر والخزنة الهدف أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fromId As Integer = CInt(cmbFromTreasury.SelectedValue)
        Dim toId As Integer = CInt(cmbToTreasury.SelectedValue)

        ' 2. منع التحويل لنفس الخزنة
        If fromId = toId Then
            MessageBox.Show("عذراً، لا يمكن التحويل من وإلى نفس الخزنة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 3. التحقق من صحة المبلغ
        Dim amount As Decimal = 0
        If Not Decimal.TryParse(txtAmount.Text, amount) OrElse amount <= 0 Then
            MessageBox.Show("يرجى إدخال مبلغ تحويل صحيح أكبر من الصفر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' تعطيل الزر مؤقتاً لمنع النقرات المتكررة
        btnTransfer.Enabled = False

        Try
            ' 4. استدعاء دالة التحويل الاحترافية
            Await TreasuryService.TransferBetweenTreasuriesAsync(
            fromTreasuryID:=fromId,
            toTreasuryID:=toId,
            amount:=amount,
            notes:=txtNotes.Text.Trim(),
            userID:=Session.CurrentUserID ' معرف المستخدم الحالي للنظام
        )

            ' نجاح العملية
            MessageBox.Show("تمت عملية التحويل بنجاح وتحديث أرصدة الخزائن بنجاح.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information)


            ' ضع هذا السطر بعد MessageBox.Show("تم الحفظ بنجاح") مباشرة في الفورم الفرعي
            Me.DialogResult = DialogResult.OK
            Me.Close()

            ' تنظيف الشاشة بعد النجاح
            txtAmount.Clear()
            txtNotes.Clear()
            cmbFromTreasury.SelectedIndex = -1
            cmbToTreasury.SelectedIndex = -1

        Catch ex As Exception
            ' هنا ستظهر رسالة "عذراً، لا يمكن إتمام العملية نظراً لعدم وجود رصيد كافٍ" 
            ' القادمة من دالة UpdateBalanceAsync التي قمنا بتعديلها سابقاً
            MessageBox.Show(ex.Message, "خطأ أثناء العملية", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' إعادة تفعيل الزر في كل الأحوال
            btnTransfer.Enabled = True
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Async Function LoadTreasuriesAsync() As Task
        Try
            Dim dtFrom As New DataTable()

            Using cn As SqlConnection = Await NewConnAsync()
                Const sql As String = "
                SELECT TreasuryID, TreasuryNameAr 
                FROM Treasury 
                WHERE IsActive = 1 AND IsDeleted = 0"

                Using da As New SqlDataAdapter(sql, cn)
                    Await Task.Run(Sub() da.Fill(dtFrom))
                End Using
            End Using

            ' 🛑 السر هنا: نأخذ نسخة مستقلة تماماً للكومبو بوكس الثاني لمنع الارتباط
            Dim dtTo As DataTable = dtFrom.Copy()

            ' جلب الخزنة الافتراضية من الإعدادات
            Dim defaultTreasuryId As Integer = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)

            ' 1. إعداد كومبو بوكس "من خزنة"
            cmbFromTreasury.DataSource = dtFrom
            cmbFromTreasury.DisplayMember = "TreasuryNameAr"
            cmbFromTreasury.ValueMember = "TreasuryID"

            ' 💡 التعديل: نستخدم SelectedValue لتحديد الخزنة بناءً على الـ ID وليس الـ Index
            If defaultTreasuryId <> -1 Then
                cmbFromTreasury.SelectedValue = defaultTreasuryId
            Else
                cmbFromTreasury.SelectedIndex = -1
            End If

            ' 2. إعداد كومبو بوكس "إلى خزنة"
            cmbToTreasury.DataSource = dtTo
            cmbToTreasury.DisplayMember = "TreasuryNameAr"
            cmbToTreasury.ValueMember = "TreasuryID"

            ' في الغالب الخزنة المحول إليها نتركها فارغة ليختارها المستخدم يدوياً
            cmbToTreasury.SelectedIndex = -1

        Catch ex As Exception
            ' يفضل دائماً إظهار الخطأ حتى لا تختفي المشاكل أثناء التطوير
            MessageBox.Show("خطأ أثناء تحميل الخزن: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class