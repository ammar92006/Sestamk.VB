Imports System.Data.SqlClient
Imports System.Drawing.Printing ' 🖨️ مكتبة التعامل مع طابعات الويندوز

Public Class frmPrinters
    Dim x, y As Integer
    Dim newpoint As New Point

    ' دالة جلب الطابعات المعرفة في نسخة الويندوز وملء الكومبو بوكس بها
    Private Sub GetSystemPrinters()
        Try
            cmbWindowsPrinters.Items.Clear()

            ' اللف على كل الطابعات المثبتة في الجهاز
            For Each printer As String In PrinterSettings.InstalledPrinters
                cmbWindowsPrinters.Items.Add(printer)
            Next

            If cmbWindowsPrinters.Items.Count > 0 Then
                cmbWindowsPrinters.SelectedIndex = -1 ' بدون تحديد افتراضي
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء قراءة طابعات الجهاز: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' دالة تحميل وجلب بيانات الطابعات للجدول
    ' جلب الوظائف المعرفة من قاعدة البيانات
    Private Sub LoadPrintersGrid()
        Dim query As String = "SELECT PrinterID, PrinterName, TargetPrinter, Note, IsActive FROM Printers WHERE IsDeleted = 0"
        Dim dt As DataTable = DBModule.ExecuteQuery(query)
        clearing()

        If dt IsNot Nothing Then
            dgvPrinters.DataSource = dt
            If dgvPrinters.Columns.Contains("PrinterID") Then dgvPrinters.Columns("PrinterID").Visible = False
            dgvPrinters.Columns("PrinterName").HeaderText = "منفذ الطباعة في البرنامج"
            dgvPrinters.Columns("TargetPrinter").HeaderText = "الطابعة المتصلة في الويندوز"
            dgvPrinters.Columns("Note").HeaderText = "ملاحظات"
            dgvPrinters.Columns("IsActive").HeaderText = "نشط"
        End If
    End Sub

    ' حدث تحميل الفورم
    Private Sub frmPrinters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        GetSystemPrinters() ' 1. جلب طابعات الويندوز أولاً
        LoadPrintersGrid()  ' 2. عرض البيانات المخزنة في الجريد
        datagridviewsetup()
    End Sub

    ' عند اختيار طابعة معينة من الكومبو بوكس، نقوم بجلب البورت (Port) الخاص بها تلقائياً
    Private Sub cmbInstalledPrinters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWindowsPrinters.SelectedIndexChanged
        'If cmbWindowsPrinters.SelectedIndex = -1 Then Exit Sub

        'Try
        '    Dim ps As New PrinterSettings()
        '    ps.PrinterName = cmbWindowsPrinters.SelectedItem.ToString()

        '    ' جلب اسم المنفذ (مثل LPT1، USB001، إلخ) وعرضه تلقائياً في حقل المنفذ
        '    ' ملاحظة: قد تحتاج لـ ManagementObjectSearcher إذا أردت تفاصيل بورت دقيقة جداً، 
        '    ' ولكن وضع اسم الطابعة الصحيح هو الأهم لعملية الطباعة
        '    txtPrinterName.Text = "USB / Network Port" ' قيمة توضيحية أو اتركه يملأ تلقائياً بناءً على تعريف الشبكة
        'Catch
        '    txtPrinterName.Text = "Unknown Port"
        'End Try
    End Sub

    ' حدث التحديد من الجريد فيو
    Private Sub dgvPrinters_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPrinters.SelectionChanged
        If dgvPrinters.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvPrinters.SelectedRows(0)

        If row.Cells("PrinterID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("PrinterID").Value) Then
            txtPrinterName.Text = row.Cells("PrinterName").Value.ToString()
            cmbWindowsPrinters.Text = row.Cells("TargetPrinter").Value.ToString()
            txtNote.Text = row.Cells("Note").Value.ToString()
            tgStatus.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)
        End If
    End Sub

    ' زر إضافة طابعة جديدة
    Private Sub btnAddPrinter_Click(sender As Object, e As EventArgs) Handles btnAddPrinter.Click
        If String.IsNullOrWhiteSpace(txtPrinterName.Text) OrElse cmbWindowsPrinters.SelectedIndex = -1 Then
            MessageBox.Show("يرجى كتابة اسم المنفذ واختيار الطابعة الحقيقية!")
            Exit Sub
        End If

        Dim query As String = "INSERT INTO Printers (PrinterName, TargetPrinter, Note, IsActive, IsDeleted) VALUES (@PrinterName, @TargetPrinter, @Note, @IsActive, 0)"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PrinterName", txtPrinterName.Text.Trim())
                cmd.Parameters.AddWithValue("@TargetPrinter", cmbWindowsPrinters.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@Note", txtNote.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadPrintersGrid()
                    MessageBox.Show("تم الحفظ بنجاح")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    ' زر تعديل بيانات الطابعة الحالية
    Private Sub btnEditPrinter_Click(sender As Object, e As EventArgs) Handles btnEditPrinter.Click
        If dgvPrinters.SelectedRows.Count = 0 Then Exit Sub
        Dim currentID As Integer = Convert.ToInt32(dgvPrinters.SelectedRows(0).Cells("PrinterID").Value)

        Dim query As String = "UPDATE Printers SET PrinterName = @PrinterName, TargetPrinter = @TargetPrinter, Note = @Note, IsActive = @IsActive WHERE PrinterID = @PrinterID"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PrinterID", currentID)
                cmd.Parameters.AddWithValue("@PrinterName", txtPrinterName.Text.Trim())
                cmd.Parameters.AddWithValue("@TargetPrinter", cmbWindowsPrinters.Text)
                cmd.Parameters.AddWithValue("@Note", txtNote.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadPrintersGrid()
                    MessageBox.Show("تم التعديل بنجاح")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    ' زر الحذف المنطقي للطابعة (Soft Delete)
    Private Sub btnDeletePrinter_Click(sender As Object, e As EventArgs) Handles btnDeletePrinter.Click
        ' (نفس كود الحذف السابق دون تغيير يعتمد على الـ ID)
        If dgvPrinters.SelectedRows.Count = 0 Then Exit Sub
        Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من رغبتك في حذف هذه الطابعة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim currentID As Integer = Convert.ToInt32(dgvPrinters.SelectedRows(0).Cells("PrinterID").Value)
            Dim query As String = "UPDATE Printers SET IsDeleted = 1 WHERE PrinterID = @PrinterID"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@PrinterID", currentID)
                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("تم حذف الطابعة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadPrintersGrid()
                    Catch ex As Exception
                        MessageBox.Show("خطأ أثناء الحذف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If
    End Sub
    Private Sub datagridviewsetup()
        Main.datagridviewsetup(dgvPrinters)
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearing()
    End Sub

    Private Sub clearing()
        txtPrinterName.Clear()
        cmbWindowsPrinters.SelectedIndex = -1
        txtNote.Clear()
        tgStatus.Checked = False
    End Sub

    Private Sub btnTestCurrentPrinter_Click(sender As Object, e As EventArgs) Handles btnTestCurrentPrinter.Click
        Dim targetPrinter As String = cmbWindowsPrinters.Text
        If String.IsNullOrWhiteSpace(targetPrinter) AndAlso dgvPrinters.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvPrinters.SelectedRows(0)
            If row.Cells("TargetPrinter").Value IsNot Nothing Then
                targetPrinter = row.Cells("TargetPrinter").Value.ToString()
            End If
        End If

        If String.IsNullOrWhiteSpace(targetPrinter) Then
            MessageBox.Show("يرجى اختيار طابعة لتجربتها أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ThermalTestReceiptHelper.PrintTestReceipt(
            printerName:=targetPrinter,
            paperSize:="80mm",
            printLogo:=True,
            printBarcode:=True,
            openDrawer:=False,
            usePreview:=False
        )
    End Sub
End Class