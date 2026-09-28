Imports System.Data.SqlClient

Public Class add_new_product
    Dim x, y As Integer
    Dim newpoint As New Point
    Public sourcePath As String = ""

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
    Public Sub scannerPort_DataReceived(code As String)

        Try
            ' استدعاء المعالجة داخل الـ UI Thread
            Me.Invoke(Sub()
                          txtUnitBarcode.Focus()
                          txtUnitBarcode.Text = code
                          MessageBox.Show("تم قراءة الباركود: " & code, "تم بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                      End Sub)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء استقبال البيانات من السكانر: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
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

    Private Sub add_new_product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datagridviewsetup()
        LoadCategories()
        LoadSuppliers()
        chkState.Checked = True
        GetMaxProductCode()
        Me.KeyPreview = True
        If InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName.ToUpper() = "EN" Then
            lblLang.Text = "انجليزي"
        ElseIf InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName.ToUpper() = "AR" Then
            lblLang.Text = "عربي"
        End If
    End Sub
    Private Sub GetMaxProductCode()
        If InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName.ToUpper() = "EN" Then
            lblLang.Text = "انجليزي"
        ElseIf InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName.ToUpper() = "AR" Then
            lblLang.Text = "عربي"
        End If
        Try
            Dim maxCode As Integer = 0

            Using cn As SqlConnection = DBModule.NewConn()
                Using cmd As New SqlClient.SqlCommand("SELECT ISNULL(MAX(CAST(Product_Code AS INT)), 0) 
                                                        FROM Products
                                                        WHERE ISNUMERIC(Product_Code) = 1
                                                        ", cn)
                    maxCode = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

            txtProductCode.Text = (maxCode + 1).ToString()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء جلب كود المنتج: " & ex.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try

    End Sub

    ' تم نقل تعريف وتنسيق الأعمدة إلى الديزاينر add_new_product.Designer.vb
    Private Sub datagridviewsetup()
        Main.datagridviewsetup(dgvUnits)
        dgvUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub LoadCategories()
        Try
            Dim cmd_LoadCategories As SqlCommand
            Dim da_LoadCategories As SqlDataAdapter
            Dim dt_LoadCategories As DataTable
            Using cn As SqlConnection = DBModule.NewConn()
            cmd_LoadCategories = New SqlCommand("SELECT Category_ID, Category_Name FROM Categories ORDER BY Category_ID", cn)
            da_LoadCategories = New SqlDataAdapter(cmd_LoadCategories)
            dt_LoadCategories = New DataTable
            da_LoadCategories.Fill(dt_LoadCategories)
            cmbCategory.DataSource = dt_LoadCategories
            cmbCategory.DisplayMember = "Category_Name"
            cmbCategory.ValueMember = "Category_ID"
            cmbCategory.SelectedIndex = -1
        End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVendor.SelectedIndexChanged
        'نتأكد من أن هناك قيمة تم اختيارها (وليس -1 وهو الوضع الافتراضي أو الفارغ)
        If cmbVendor.SelectedValue IsNot Nothing AndAlso cmbVendor.SelectedIndex <> -1 Then

            ' التحقق من أن مصدر البيانات هو DataTable
            Dim dtVendors As DataTable = TryCast(cmbVendor.DataSource, DataTable)

            If dtVendors IsNot Nothing Then

                ' جلب قيمة الـ Partner_ID
                Dim partnerId As Integer = 0
                If cmbVendor.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbVendor.SelectedValue) Then
                    partnerId = Convert.ToInt32(cmbVendor.SelectedValue)
                End If


                ' استخدام Select() للبحث عن الصف المطابق للـ Partner_ID
                ' تأكد من أن "Partner_ID" هو اسم عمود المفتاح الأساسي في DataTable
                Dim selectedRows() As DataRow = dtVendors.Select($"SuppliersID = {partnerId}")

                If selectedRows.Length > 0 Then
                    ' إذا تم العثور على الصف، قم بتعبئة مربع النص باسم الشركة (CompanyName)
                    ' تأكد من أن "Partner_Name" هو اسم العمود الذي يحتوي على اسم الشركة
                    txtCompanyName.Text = selectedRows(0)("Companyname").ToString()
                Else
                    txtCompanyName.Text = String.Empty
                End If

            End If

        Else
            ' مسح مربع النص إذا لم يتم اختيار أي مورد
            txtCompanyName.Text = String.Empty
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try

            ' إنشاء مربع حوار لاختيار الصورة
            Dim ofd As New OpenFileDialog With {
                .Filter = "صور (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif",
                .Title = "اختر الصورة"}
            If ofd.ShowDialog() = DialogResult.OK Then
                sourcePath = ofd.FileName
                If Pic_Product.Image IsNot Nothing Then
                    Pic_Product.Image.Dispose()
                    Pic_Product.Image = Nothing
                End If
                Using img As System.Drawing.Image = System.Drawing.Image.FromFile(sourcePath)
                    Pic_Product.Image = New Bitmap(img)  ' ← نسخ الصورة (Clone)
                End Using

                MessageBox.Show("✅ تم تحديد الصورة بنجاح:" & vbCrLf, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حفظ الصورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_AddUnit_Click(sender As Object, e As EventArgs) Handles btn_AddUnit.Click
        If txtUnitName.Text.Trim = "" Then
            MessageBox.Show("أدخل اسم الوحدة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtUnitQuantity.Text.Trim = "" Then
            MessageBox.Show("أدخل عدد الوحدات التي داخلها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtPurchasePrice.Text.Trim = "" Then
            MessageBox.Show("أدخل سعر الشراء", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtSalePrice.Text.Trim = "" Then
            MessageBox.Show("أدخل سعر البيع", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim bar As String = txtUnitBarcode.Text.Trim()

        '' 1 — فحص داخل GRID
        'If BarcodeExistsInGrid(bar) Then
        '    MessageBox.Show("⚠ هذا الباركود مضاف بالفعل داخل الوحدات.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return
        'End If

        '' 2 — فحص داخل قاعدة البيانات
        'If BarcodeExistsInDatabase(bar) Then
        '    MessageBox.Show("❌ هذا الباركود موجود بالفعل في قاعدة البيانات ولا يمكن تكراره.", "مكرر", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If

        ' بعد التأكد… إضافة الوحدة
        dgvUnits.Rows.Add(
        txtUnitName.Text,
        txtUnitQuantity.Text,
        bar,
        txtPurchasePrice.Text,
        txtSalePrice.Text,
        txtUnitNotes.Text
    )

        ' تنظيف الحقول
        txtUnitName.Clear()
        txtUnitQuantity.Clear()
        txtUnitBarcode.Clear()
        txtPurchasePrice.Clear()
        txtSalePrice.Clear()
        txtUnitNotes.Clear()
    End Sub

    Private Sub check_Stats_CheckedChanged(sender As Object, e As EventArgs) Handles chkState.CheckedChanged
        If chkState.Checked Then
            lblStatus.Text = "نشط"
            lblStatus.ForeColor = Color.Green
        Else
            lblStatus.Text = "نشط غير"
            lblStatus.ForeColor = Color.Red
        End If
    End Sub
    Private Sub ShowWarning(msg As String, ctrl As Control)
        MessageBox.Show("❌ " & msg, "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ctrl.Focus()
    End Sub

    Private Sub btn_SaveProduct_Click(sender As Object, e As EventArgs) Handles btn_SaveProduct.Click

        '==============================
        ' 🔍 1 — التحقق من البيانات
        '==============================
        If String.IsNullOrWhiteSpace(txtProductCode.Text) Then
            ShowWarning("من فضلك أدخل كود المنتج.", txtProductCode)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            ShowWarning("من فضلك أدخل اسم المنتج.", txtProductName)
            Exit Sub
        End If

        If cmbCategory.SelectedValue Is Nothing Then
            ShowWarning("من فضلك اختر القسم.", cmbCategory)
            Exit Sub
        End If

        If cmbVendor.SelectedValue Is Nothing Then
            ShowWarning("من فضلك اختر المورد.", cmbVendor)
            Exit Sub
        End If

        Try
            Using cn As SqlConnection = DBModule.NewConn()

            '====================================================
            ' 2 — إضافة المنتج أولاً إلى جدول Products
            '====================================================
            Dim queryProd As String =
            "INSERT INTO Products 
            (Product_Code, Product_Name, Category_ID, Partner_ID, Product_Image, Product_State, Product_Note)
             VALUES (@Code, @Name, @Cat, @Vendor, @Image, @State, @Note);
             SELECT SCOPE_IDENTITY();"

            Using cmdProd As New SqlCommand(queryProd, cn)

                cmdProd.Parameters.AddWithValue("@Code", txtProductCode.Text.Trim())
                cmdProd.Parameters.AddWithValue("@Name", txtProductName.Text.Trim())
                cmdProd.Parameters.AddWithValue("@Cat", cmbCategory.SelectedValue)
                cmdProd.Parameters.AddWithValue("@Vendor", cmbVendor.SelectedValue)
                cmdProd.Parameters.AddWithValue("@Image", If(sourcePath, DBNull.Value))
                cmdProd.Parameters.AddWithValue("@State", chkState.Checked)
                cmdProd.Parameters.AddWithValue("@Note", txtProductNote.Text.Trim())

                Dim NewProductID As Integer = Convert.ToInt32(cmdProd.ExecuteScalar())

                'اختياري: عرض ID المنتج
                'MessageBox.Show("كود المنتج الجديد: " & NewProductID)
                '===========================================================
                ' 3 — إضافة وحدات المنتج من الـ DataGridView
                '===========================================================
                Dim queryUnit As String =
                "INSERT INTO ProductUnits
                (Product_ID, Unit_Name, Unit_Quantity, Barcode, Purchase_Price, Sale_Price, Notes)
                VALUES (@PID, @UName, @UQty, @Bar, @Pur, @Sale, @Notes)"

                For Each row As DataGridViewRow In dgvUnits.Rows
                    If row.IsNewRow Then Continue For

                    Using cmdUnit As New SqlCommand(queryUnit, cn)

                        cmdUnit.Parameters.AddWithValue("@PID", NewProductID)
                        cmdUnit.Parameters.AddWithValue("@UName", row.Cells("ColUnitName").Value)
                        cmdUnit.Parameters.AddWithValue("@UQty", row.Cells("ColUnitQuantity").Value)
                        cmdUnit.Parameters.AddWithValue("@Bar", row.Cells("ColBarcode").Value)
                        cmdUnit.Parameters.AddWithValue("@Pur", row.Cells("ColPurchasePrice").Value)
                        cmdUnit.Parameters.AddWithValue("@Sale", row.Cells("ColSalePrice").Value)
                        cmdUnit.Parameters.AddWithValue("@Notes", row.Cells("ColNotes").Value)

                        cmdUnit.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show("✔ تم إضافة المنتج ووحداته بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            ClearAll()
            GetMaxProductCode()

        End Using
        Catch ex As Exception
            MessageBox.Show("❌ حدث خطأ أثناء حفظ المنتج:" & vbCrLf & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function BarcodeExistsInDatabase(barcode As String) As Boolean
        Try
            Using cn As SqlConnection = DBModule.NewConn()
            Dim query As String = "SELECT COUNT(*) FROM ProductUnits WHERE Barcode = @Bar"
            Dim cmd As New SqlCommand(query, cn)
            cmd.Parameters.AddWithValue("@Bar", barcode)

            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0

        End Using
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء فحص الباركود: " & ex.Message)
            Return True
        End Try
    End Function
    Private Function BarcodeExistsInGrid(barcode As String) As Boolean
        For Each row As DataGridViewRow In dgvUnits.Rows
            If row.IsNewRow Then Continue For
            If row.Cells("ColBarcode").Value.ToString() = barcode Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub ClearAll()
        txtProductCode.Clear()
        txtProductName.Clear()
        txtProductNote.Clear()

        cmbCategory.SelectedIndex = -1
        cmbVendor.SelectedIndex = -1

        dgvUnits.Rows.Clear()

        txtProductCode.Focus()
    End Sub
    Private Sub GenerateUniqueBarcode()

        Dim newBarcode As String = ""
        Dim exists As Boolean = True
        Dim rnd As New Random()

        Using cn As SqlConnection = DBModule.NewConn()
        While exists

            ' توليد رقم عشوائي من 12 رقم (مناسب للباركود)
            newBarcode = rnd.Next(100000000, 999999999).ToString() &
            rnd.Next(100, 999).ToString()

            ' فحص هل موجود في قاعدة البيانات؟
            Using cmd As New SqlClient.SqlCommand("
            SELECT COUNT(*) FROM ProductUnits WHERE Barcode = @Barcode", cn)

                cmd.Parameters.AddWithValue("@Barcode", newBarcode)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            End Using
        End While
        End Using

        ' وضع الباركود في التيكست بوكس
        txtUnitBarcode.Text = newBarcode

    End Sub
    Private Sub dgvUnits_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUnits.CellClick

        ' تجنب الضغط على Header
        If e.RowIndex < 0 Then Exit Sub

        ' تحقق لو العمود هو عمود الحذف
        If dgvUnits.Columns(e.ColumnIndex).Name = "ColDelete" Then

            ' الحصول على اسم الوحدة من العمود الصحيح (حسب الـ setup عندك)
            Dim UnitNameToDelete As String = dgvUnits.Rows(e.RowIndex).Cells("ColUnitName").Value.ToString()

            ' رسالة تأكيد الحذف
            If MessageBox.Show($"هل أنت متأكد من حذف الوحدة ({UnitNameToDelete}) من وحدات هذا المنتج؟",
                               "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                ' حذف الصف من الـ DataGridView
                dgvUnits.Rows.RemoveAt(e.RowIndex)

                ' رسالة نجاح الحذف
                MessageBox.Show("تم حذف الوحدة.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub btn_generate_barcode_Click(sender As Object, e As EventArgs) Handles btn_generate_barcode.Click
        GenerateUniqueBarcode()
    End Sub

    Private Sub btnNewCode_Click(sender As Object, e As EventArgs) Handles btnNewCode.Click
        GetMaxProductCode()
    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearAll()
    End Sub

    Private Sub txtUnitBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnitBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_SaveProduct.PerformClick()
        End If
    End Sub

    Private Sub add_new_product_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        'If e.Control AndAlso e.KeyCode = Keys.F1 Then
        '    e.SuppressKeyPress = True ' يمنع مرور الاختصار للنظام
        '    e.Handled = True           ' يمنع أي أكواد أخرى من التعامل مع نفس الحدث
        '    txtSearch.Focus()
        'End If



        If (e.Alt AndAlso e.KeyCode = Keys.F4) OrElse (e.KeyCode = Keys.Escape) Then
            e.Handled = True
            Me.Close()
        End If


        If e.KeyCode = Keys.F2 Then
            btn_SaveProduct.PerformClick()
        End If


        'Select Case e.KeyCode
        '    Case Keys.F1
        '        MessageBox.Show("الاختصارات المتاحة:" & vbCrLf &
        '            "F2 / Ctrl+N : إضافة جديد" & vbCrLf &
        '            "F3 : تعديل" & vbCrLf &
        '            "F4 : حذف" & vbCrLf &
        '            "F5 : تحديث الجدول" & vbCrLf &
        '            "F6 : مسح الحقول" & vbCrLf &
        '            "Ctrl+F : بحث" & vbCrLf &
        '            "Esc : خروج", "دليل الاختصارات", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    'Case Keys.F2
        '    '    btnNew.PerformClick()   ' زر الإضافة

        '    Case Keys.F3
        '        btnEdit.PerformClick()  ' زر التعديل

        '    Case Keys.F4
        '        btnDelete.PerformClick() ' زر الحذف

        '    Case Keys.F6
        '        ClearFields()' زر مسح الحقول

        '    Case Keys.F5
        '        LoadCustomers()         ' إعادة تحميل الجدول مثلاً
        '            ' إعادة تحميل الجدول مثلاً

        '    Case Keys.Escape
        '        Me.Close()              ' خروج من الفورم
        'End Select
    End Sub

    Private Sub add_new_product_InputLanguageChanged(sender As Object, e As InputLanguageChangedEventArgs) Handles MyBase.InputLanguageChanged
        If e.InputLanguage.Culture.TwoLetterISOLanguageName.ToUpper() = "EN" Then
            lblLang.Text = "انجليزي"
        ElseIf e.InputLanguage.Culture.TwoLetterISOLanguageName.ToUpper() = "AR" Then
            lblLang.Text = "عربي"
        End If
    End Sub

    Private Sub LoadSuppliers()
        Try
            Dim cmd_LoadSuppliers As SqlCommand
            Dim da_LoadSuppliers As SqlDataAdapter
            Dim dt_LoadSuppliers As DataTable
            Using cn As SqlConnection = DBModule.NewConn()
            cmd_LoadSuppliers = New SqlCommand("SELECT SuppliersID ,SuppliersName, Companyname FROM dbo.Suppliers ORDER BY SuppliersID;", cn)
            da_LoadSuppliers = New SqlDataAdapter(cmd_LoadSuppliers)
            dt_LoadSuppliers = New DataTable
            da_LoadSuppliers.Fill(dt_LoadSuppliers)
            cmbVendor.DataSource = dt_LoadSuppliers
            cmbVendor.DisplayMember = "SuppliersName"
            cmbVendor.ValueMember = "SuppliersID"
            cmbVendor.SelectedIndex = -1
        End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class