Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.Utils.Html.Internal
Imports DocumentFormat.OpenXml.ExtendedProperties
Imports System.Windows.Forms
Public Class Purchase_Return
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim manager As New temp_manager()
    Public sourcePath As String = ""
    Public SelectedProductId As Integer = 0
    Public CurrentConversionFactor As Decimal = 0D
    Public CurrentSalePrice As Decimal = 0D
    Private CurrentUnitID As Integer = 0


    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()

    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Purchases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadlogininfo()
        SetupDataGridView(dgv_Purchases)
        LoadSuppliers()
        newInvoiceID()
        'pic_purchases.Image = My.Resources.نص_فقرتك
        Me.KeyPreview = True
        With cmb_Pay
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Popup
            .Font = New Font("Segoe UI", 14, FontStyle.Bold)
            .ForeColor = Color.Black
            .BackColor = Color.White
            .Items.Clear()
            .Items.Add("نقدي")
            .Items.Add("كاش")
            .Items.Add("آجل")
            .SelectedIndex = 0
        End With

        AddHandler lstNameSuggestions.SelectedIndexChanged,
            Sub(s, ev)
                manager.lstNameSuggestions_SelectedIndexChanged2(
                    s, ev,
                    txtProductNameSearch, SelectedProductId, lstCodeSuggestions, txtProductCodeSearch, cmbUnit, txt_purchase_price, txtQuantity
                )
            End Sub


        ' البحث بالاسم
        AddHandler txtProductNameSearch.TextChanged,
            Sub(s, ev)
                manager.txtProductNameSearch_TextChanged2(s, ev, lstNameSuggestions)
            End Sub
        lstCodeSuggestions.Visible = False
        lstNameSuggestions.Visible = False


        ' عند تغيير الوحدة
        AddHandler cmbUnit.SelectedIndexChanged,
            Sub(s, ev)
                manager.cmbUnit_SelectedIndexChanged2(
                    s,
                    ev,
                    txtQuantity,
                    txt_totelProduct,
                    txt_purchase_price,
                    CurrentConversionFactor,  ' <--- يتم تمريره كمرجع
                    CurrentSalePrice,         ' <--- يتم تمريره كمرجع
                    CurrentUnitID             ' <--- يتم تمريره كمرجع
                )
            End Sub
        txtDiscount.Text = 0
        txt_totelProduct.Text = 0
    End Sub
    Private Sub LoadSuppliers()
        Try
            Dim cmd_LoadSuppliers As SqlCommand
            Dim da_LoadSuppliers As SqlDataAdapter
            Dim dt_LoadSuppliers As DataTable
            Connect()
            cmd_LoadSuppliers = New SqlCommand("SELECT SuppliersID ,SuppliersName, Companyname FROM dbo.Suppliers ORDER BY SuppliersID;", Conn)
            da_LoadSuppliers = New SqlDataAdapter(cmd_LoadSuppliers)
            dt_LoadSuppliers = New DataTable
            da_LoadSuppliers.Fill(dt_LoadSuppliers)
            cmbVendor.DataSource = dt_LoadSuppliers
            cmbVendor.DisplayMember = "SuppliersName"
            cmbVendor.ValueMember = "SuppliersID"
            cmbVendor.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub
    Private Sub sale_p_product()
        ' نحاول نحسب الناتج فقط لما تكون القيم صحيحة رقمياً
        Dim quantity As Decimal
        Dim price As Decimal

        ' التحقق من أن القيم رقمية باستخدام TryParse
        If Decimal.TryParse(txtQuantity.Text, quantity) AndAlso Decimal.TryParse(txt_purchase_price.Text, price) Then
            txt_totelProduct.Text = (price * quantity).ToString("0.##")
        Else
            ' لو القيم غير صالحة، نخلي الناتج فاضي أو صفر
            txt_totelProduct.Text = ""
        End If
    End Sub

    Private Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnit.SelectedIndexChanged
        sale_p_product()
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        sale_p_product()
    End Sub

    Public Function CheckProductStatus(productId As Integer) As Boolean
        Try
            Connect()
            Using cmd As New SqlCommand("SELECT Product_Name, Product_State FROM Products WHERE Product_ID = @id", Conn)
                cmd.Parameters.AddWithValue("@id", productId)
                Dim reader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim productName As String = reader("Product_Name").ToString()
                    Dim isActive As Boolean = Convert.ToBoolean(reader("Product_State"))
                    If isActive Then Return True
                    MessageBox.Show($"⚠️ المنتج غير نشط ولا يمكن استخدامه حالياً." & vbCrLf &
                        $"📦 اسم المنتج: {productName}" & vbCrLf &
                        $"🔍 كود المنتج: {productId}",
                        "تنبيه - المنتج غير نشط", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                Else
                    MessageBox.Show("❌ لم يتم العثور على المنتج المطلوب.", "منتج غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("حدث خطأ: " & ex.Message, "خطأ في البحث", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Disconnect()
        End Try
    End Function
    Private Sub btn_add_product_Click(sender As Object, e As EventArgs) Handles btn_add_product.Click
        ' 1. التحقق من المدخلات الأساسية
        If Me.SelectedProductId <= 0 Then
            MessageBox.Show("الرجاء اختيار منتج أولاً.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(txtQuantity.Text) OrElse Convert.ToDecimal(txtQuantity.Text) <= 0 Then
            MessageBox.Show("الرجاء إدخال كمية صحيحة.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Exit Sub
        End If
        If CheckProductStatus(SelectedProductId) = False Then
            Exit Sub ' المنتج غير نشط → أخرج
        End If

        ' ----------------------------------------------------
        ' *إزالة*: تم إزالة كل منطق التحقق من المخزون والإضافة المباشرة من هنا.
        '         التحقق يتم الآن داخل UpdateExistingRowOrAdd.
        ' ----------------------------------------------------

        ' 2. استدعاء الدالة الجديدة: تحديث الصف الحالي أو إضافة صف جديد
        UpdateExistingRowOrAdd()

        ' 3. مسح حقول الإدخال للصنف التالي
        ClearProductFields()

        ' 4. تحديث الإجمالي الكلي في أسفل الفورم (يجب أن يتم استدعاؤها في النهاية)
        ' يجب عليك التأكد من أن دالة UpdateInvoiceTotals() موجودة وتعمل بشكل صحيح
        UpdateInvoiceTotals()

        txtProductNameSearch.Focus()
    End Sub
    Private Sub UpdateInvoiceTotals()
        Dim GrandTotal As Decimal = 0D

        ' جمع إجمالي جميع بنود الفاتورة
        For Each row As DataGridViewRow In dgv_Purchases.Rows
            If Not row.IsNewRow AndAlso row.Cells("ColTotal").Value IsNot Nothing Then
                GrandTotal += Convert.ToDecimal(row.Cells("ColTotal").Value)
            End If
        Next

        ' 1. الإجمالي
        txtTotalRequired.Text = GrandTotal.ToString("N2") ' افترض أن هذا هو حقل الإجمالي الكلي

        '' 2. المطلوب (بعد الخصم)
        'Dim Discount As Decimal = If(IsNumeric(txtDiscount.Text), Convert.ToDecimal(txtDiscount.Text), 0D)
        'Dim RequiredAmount As Decimal = GrandTotal - Discount
        'txtRequiredAmount.Text = RequiredAmount.ToString("N2") ' حقل المطلوب

        '' 3. المتبقي
        'Dim PaidAmount As Decimal = If(IsNumeric(txtPaid.Text), Convert.ToDecimal(txtPaid.Text), 0D)
        'Dim RemainingAmount As Decimal = RequiredAmount - PaidAmount
        'txtRemainingAmount.Text = RemainingAmount.ToString("N2") ' حقل المتبقي
    End Sub
    Private Sub ClearProductFields()
        newInvoiceID()
        txtProductCodeSearch.Clear()
        txtProductNameSearch.Clear()
        cmbUnit.DataSource = Nothing
        cmbUnit.Items.Clear()
        txt_purchase_price.Clear()
        txtQuantity.Clear()
        txt_totelProduct.Clear()


        txtProductCodeSearch.TextAlign = HorizontalAlignment.Center
        txtProductNameSearch.TextAlign = HorizontalAlignment.Center
        cmbUnit.TextAlign = HorizontalAlignment.Center
        cmbUnit.TextAlign = HorizontalAlignment.Center
        txt_purchase_price.TextAlign = HorizontalAlignment.Center
        txtQuantity.TextAlign = HorizontalAlignment.Center
        txt_totelProduct.TextAlign = HorizontalAlignment.Center
    End Sub
    Private Sub newInvoiceID()

        Dim newInvoiceID As Integer

        Try
            Connect()

            Dim query As String = "
                SELECT ISNULL(Purchase_Id, 0) 
                FROM Purchase_Header 
                WHERE Purchase_Id IS NOT NULL
            "

            Using cmd As New SqlCommand(query, Conn)
                Dim lastID As Object = cmd.ExecuteScalar()

                If lastID IsNot Nothing AndAlso Not IsDBNull(lastID) Then
                    newInvoiceID = Convert.ToInt32(lastID) + 1
                End If
            End Using

            Disconnect()

            txt_Invoice_ID.Text = newInvoiceID.ToString()

        Catch ex As Exception

            MessageBox.Show("حدث خطأ أثناء حساب رقم الفاتورة الجديد: " & ex.Message,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Finally
            Disconnect()
        End Try

    End Sub
    Private Sub UpdateExistingRowOrAdd()

        Dim qtyToAdd As Integer
        If Not Integer.TryParse(txtQuantity.Text.Trim(), qtyToAdd) Then
            MessageBox.Show("❌ الكمية غير صالحة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim dgv As DataGridView = Me.dgv_Purchases
        Dim currentProduct_Code As String = txtProductCodeSearch.Text.Trim()
        Dim currentProductName As String = txtProductNameSearch.Text.Trim()
        Dim currentUnitName As String = cmbUnit.Text.Trim()

        Dim totalLineAmount As Decimal = qtyToAdd * CurrentSalePrice
        Dim rowFound As Boolean = False

        ' -----------------------------------------------------
        ' 1) البحث عن الصف للتجميع (بدون التحقق من المخزون)
        ' -----------------------------------------------------
        Dim oldQty As Integer = 0

        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For

            Dim existingProductName As String = CStr(row.Cells("ColProductName").Value).Trim()
            Dim existingUnitName As String = CStr(row.Cells("ColUnitName").Value).Trim()

            If existingProductName.Equals(currentProductName, StringComparison.OrdinalIgnoreCase) AndAlso
           existingUnitName.Equals(currentUnitName, StringComparison.OrdinalIgnoreCase) Then

                rowFound = True
                oldQty = Convert.ToDecimal(row.Cells("ColQuantity").Value)
                Exit For
            End If
        Next

        ' الكمية الإجمالية
        Dim totalQtyRequired As Integer = oldQty + qtyToAdd

        ' -----------------------------------------------------
        ' 2) لو الصف موجود → تحديثه
        ' -----------------------------------------------------
        If rowFound Then
            For Each row As DataGridViewRow In dgv.Rows
                If row.IsNewRow Then Continue For

                Dim existingProductName As String = CStr(row.Cells("ColProductName").Value).Trim()
                Dim existingUnitName As String = CStr(row.Cells("ColUnitName").Value).Trim()

                If existingProductName.Equals(currentProductName, StringComparison.OrdinalIgnoreCase) AndAlso
               existingUnitName.Equals(currentUnitName, StringComparison.OrdinalIgnoreCase) Then

                    row.Cells("ColQuantity").Value = totalQtyRequired.ToString("N2")
                    row.Cells("ColTotal").Value = (totalQtyRequired * CurrentSalePrice).ToString("N2")
                    Exit Sub
                End If
            Next
        End If

        ' -----------------------------------------------------
        ' 3) ضبط ترتيب الأعمدة (مرئي + مخفي + زر الحذف)
        ' -----------------------------------------------------
        Try
            dgv.Columns("ColProductID").DisplayIndex = 0
            dgv.Columns("ColProductName").DisplayIndex = 1
            dgv.Columns("ColUnitName").DisplayIndex = 2
            dgv.Columns("ColPrice").DisplayIndex = 3
            dgv.Columns("ColQuantity").DisplayIndex = 4
            dgv.Columns("ColTotal").DisplayIndex = 5

            dgv.Columns("ColUnitID").DisplayIndex = 6
            dgv.Columns("ColFactor").DisplayIndex = 7

            dgv.Columns("ColDelete").DisplayIndex = 8
        Catch
            ' لو حصل خطأ في عمود مش موجود نتجاهل
        End Try

        ' -----------------------------------------------------
        ' 4) إضافة الصف الجديد بترتيب مضبوط 100%
        ' -----------------------------------------------------
        dgv.Rows.Add(
        SelectedProductId,              ' ColProductID
        currentProductName,             ' ColProductName
        currentUnitName,                ' ColUnitName
        CurrentSalePrice.ToString("N2"),' ColPrice
        qtyToAdd.ToString("N2"),        ' ColQuantity
        totalLineAmount.ToString("N2"), ' ColTotal
        CurrentUnitID,                  ' ColUnitID (مخفي)
        CurrentConversionFactor)       ' ColFactor (مخفي)
        ' ColDelete يضاف تلقائياً كزر


    End Sub



    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearProductFields()
    End Sub

    Private Sub txtTotalRequired_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRequired.TextChanged
        Dim totalRequired As Decimal
        Dim discount As Decimal

        ' التحقق من أن القيم رقمية
        If Decimal.TryParse(txtTotalRequired.Text, totalRequired) AndAlso Decimal.TryParse(txtDiscount.Text, discount) Then

            ' لو الخصم أكبر من المبلغ المطلوب
            If discount > totalRequired Then
                ' رسالة تنبيه احترافية
                MessageBox.Show("⚠️ قيمة الخصم لا يمكن أن تتجاوز المبلغ المطلوب!",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                ' نرجع الخصم إلى صفر لتصحيح الخطأ
                txtDiscount.Text = "0"
                txtDiscount.SelectAll()
                txtTotalAfterDiscount.Text = totalRequired.ToString("0.##")
                Exit Sub
            End If

            ' حساب الإجمالي بعد الخصم
            txtTotalAfterDiscount.Text = (totalRequired - discount).ToString("0.##")
            txtRemaining.Text = (totalRequired - discount).ToString("0.##")

        ElseIf Decimal.TryParse(txtTotalRequired.Text, totalRequired) Then
            ' لو الخصم مش صالح أو فاضي
            txtTotalAfterDiscount.Text = totalRequired.ToString("0.##")
        Else
            ' لو المبلغ المطلوب نفسه غير صالح
            txtTotalAfterDiscount.Text = ""
        End If

        Dim totalAfterDiscount As Decimal
        Dim paid As Decimal

        ' التحقق من أن الإجمالي والمدفوع أرقام صحيحة
        If Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount) AndAlso Decimal.TryParse(txtPaid.Text, paid) Then

            ' ✅ نخلي الإجمالي بالسالب ونجمع عليه المدفوع
            Dim remaining As Decimal = (-totalAfterDiscount) + paid

            ' عرض المتبقي في التكست بوكس
            txtRemaining.Text = remaining.ToString("0.##")

            ' تلوين المتبقي حسب الحالة
            If remaining < 0 Then
                txtRemaining.ForeColor = Color.Red
            ElseIf remaining > 0 Then
                txtRemaining.ForeColor = Color.Green
            Else
                txtRemaining.ForeColor = Color.Black
            End If

        ElseIf Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount) Then
            txtRemaining.Text = (-totalAfterDiscount).ToString("0.##")
        Else
            txtRemaining.Text = ""
        End If
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        Dim totalRequired As Decimal
        Dim discount As Decimal
        If txtDiscount.TextLength = 0 Then
            txtDiscount.Text = 0
        End If
        ' التحقق من أن القيم رقمية
        If Decimal.TryParse(txtTotalRequired.Text, totalRequired) AndAlso Decimal.TryParse(txtDiscount.Text, discount) Then

            ' لو الخصم أكبر من المبلغ المطلوب
            If discount > totalRequired Then
                ' رسالة تنبيه احترافية
                MessageBox.Show("⚠️ قيمة الخصم لا يمكن أن تتجاوز المبلغ المطلوب!",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                ' نرجع الخصم إلى صفر لتصحيح الخطأ
                txtDiscount.Text = "0"
                txtDiscount.Focus()
                txtTotalAfterDiscount.Text = totalRequired.ToString("0.##")
                Exit Sub
            End If

            ' حساب الإجمالي بعد الخصم
            txtTotalAfterDiscount.Text = (totalRequired - discount).ToString("0.##")
            txtRemaining.Text = (totalRequired - discount).ToString("0.##")

        ElseIf Decimal.TryParse(txtTotalRequired.Text, totalRequired) Then
            ' لو الخصم مش صالح أو فاضي
            txtTotalAfterDiscount.Text = totalRequired.ToString("0.##")
        Else
            ' لو المبلغ المطلوب نفسه غير صالح
            txtTotalAfterDiscount.Text = ""
        End If

        Dim totalAfterDiscount As Decimal
        Dim paid As Decimal

        ' التحقق من أن الإجمالي والمدفوع أرقام صحيحة
        If Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount) AndAlso Decimal.TryParse(txtPaid.Text, paid) Then

            ' ✅ نخلي الإجمالي بالسالب ونجمع عليه المدفوع
            Dim remaining As Decimal = (-totalAfterDiscount) + paid

            ' عرض المتبقي في التكست بوكس
            txtRemaining.Text = remaining.ToString("0.##")

            ' تلوين المتبقي حسب الحالة
            If remaining < 0 Then
                txtRemaining.ForeColor = Color.Red
            ElseIf remaining > 0 Then
                txtRemaining.ForeColor = Color.Green
            Else
                txtRemaining.ForeColor = Color.Black
            End If

        ElseIf Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount) Then
            txtRemaining.Text = (-totalAfterDiscount).ToString("0.##")
        Else
            txtRemaining.Text = ""
        End If
    End Sub

    Private Sub txtPaid_TextChanged(sender As Object, e As EventArgs) Handles txtPaid.TextChanged
        Dim totalAfterDiscount As Decimal
        Dim paid As Decimal
        If txtPaid.TextLength = 0 Then
            txtPaid.Text = 0
        End If
        ' التحقق من أن الإجمالي والمدفوع أرقام صحيحة
        If Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount) AndAlso Decimal.TryParse(txtPaid.Text, paid) Then

            ' ✅ نخلي الإجمالي بالسالب ونجمع عليه المدفوع
            Dim remaining As Decimal = (-totalAfterDiscount) + paid

            ' عرض المتبقي في التكست بوكس
            txtRemaining.Text = remaining.ToString("0.##")

            ' تلوين المتبقي حسب الحالة
            If remaining < 0 Then
                txtRemaining.ForeColor = Color.Red
            ElseIf remaining > 0 Then
                txtRemaining.ForeColor = Color.Green
            Else
                txtRemaining.ForeColor = Color.Black
            End If

        ElseIf Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount) Then
            txtRemaining.Text = (-totalAfterDiscount).ToString("0.##")
        Else
            txtRemaining.Text = ""
        End If
    End Sub


    Private Sub cmb_Pay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Pay.SelectedIndexChanged
        Select Case cmb_Pay.Text
            Case "كاش"
                txtRemaining.Visible = True
                txtPaid.Visible = True
                lblRemaining.Visible = True
                lblPaid.Visible = True
            Case "نقدي"
                txtRemaining.Visible = True
                txtPaid.Visible = True
                lblRemaining.Visible = True
                lblPaid.Visible = True

            Case "آجل"
                txtPaid.Text = 0
                txtPaid.Visible = False
                lblPaid.Visible = False

            Case Else
                txtPaid.Visible = False
                lblPaid.Visible = False
        End Select
        Dim totalRequired As Decimal
        Dim discount As Decimal

        ' التحقق من أن القيم رقمية
        If Decimal.TryParse(txtTotalRequired.Text, totalRequired) AndAlso Decimal.TryParse(txtDiscount.Text, discount) Then

            ' لو الخصم أكبر من المبلغ المطلوب
            If discount > totalRequired Then
                ' رسالة تنبيه احترافية
                MessageBox.Show("⚠️ قيمة الخصم لا يمكن أن تتجاوز المبلغ المطلوب!",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                ' نرجع الخصم إلى صفر لتصحيح الخطأ
                txtDiscount.Text = "0"
                txtDiscount.SelectAll()
                txtTotalAfterDiscount.Text = totalRequired.ToString("0.##")
                Exit Sub
            End If

            ' حساب الإجمالي بعد الخصم
            txtTotalAfterDiscount.Text = (totalRequired - discount).ToString("0.##")
            txtRemaining.Text = (totalRequired - discount).ToString("0.##")

        ElseIf Decimal.TryParse(txtTotalRequired.Text, totalRequired) Then
            ' لو الخصم مش صالح أو فاضي
            txtTotalAfterDiscount.Text = totalRequired.ToString("0.##")
        Else
            ' لو المبلغ المطلوب نفسه غير صالح
            txtTotalAfterDiscount.Text = ""
        End If

        Dim totalAfterDiscount As Decimal
        Dim paid As Decimal

        ' التحقق من أن الإجمالي والمدفوع أرقام صحيحة
        If Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount) AndAlso Decimal.TryParse(txtPaid.Text, paid) Then

            ' ✅ نخلي الإجمالي بالسالب ونجمع عليه المدفوع
            Dim remaining As Decimal = (-totalAfterDiscount) + paid

            ' عرض المتبقي في التكست بوكس
            txtRemaining.Text = remaining.ToString("0.##")

            ' تلوين المتبقي حسب الحالة
            If remaining < 0 Then
                txtRemaining.ForeColor = Color.Red
            ElseIf remaining > 0 Then
                txtRemaining.ForeColor = Color.Green
            Else
                txtRemaining.ForeColor = Color.Black
            End If

        ElseIf Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount) Then
            txtRemaining.Text = (-totalAfterDiscount).ToString("0.##")
        Else
            txtRemaining.Text = ""
        End If

    End Sub

    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs)
        Try

            ' إنشاء مربع حوار لاختيار الصورة
            Dim ofd As New OpenFileDialog With {
                .Filter = "صور (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif",
                .Title = "اختر الصورة"
            }

            If ofd.ShowDialog() = DialogResult.OK Then
                ' المسار الأصلي للصورة
                'Dim sourcePath As String = ofd.FileName
                sourcePath = ofd.FileName
                ' مجلد الحفظ
                'Dim photosFolder As String = Path.Combine(System.Windows.Forms.Application.StartupPath, "photos_purchases")

                '' إنشاء المجلد لو مش موجود
                'If Not Directory.Exists(photosFolder) Then
                '    Directory.CreateDirectory(photosFolder)
                'End If

                '' اسم الصورة الجديدة (مثلاً حسب التاريخ والوقت لتجنب التكرار)
                'Dim id As Integer = Convert.ToInt32(txt_Invoice_ID.Text)
                'Dim newFileName As String = "purchases_" & id & Path.GetExtension(sourcePath)
                'Dim destinationPath As String = Path.Combine(photosFolder, newFileName)

                '' نسخ الصورة
                'File.Copy(sourcePath, destinationPath, True)
                'Using Conn

                '    Connect()
                '    Using cmd As New SqlCommand("UPDATE Products SET purchases_Image = @purchases_Image WHERE Product_ID = @Product_ID", Conn)
                '        cmd.Parameters.AddWithValue("@purchases_Image", destinationPath)
                '        cmd.Parameters.AddWithValue("@Product_ID", id)
                '        cmd.ExecuteNonQuery()
                '    End Using
                '    Disconnect()
                'End Using
                ' عرض الصورة في PictureBox (لو عندك)

                'pic_purchases.Image = System.Drawing.Image.FromFile(sourcePath)
                ' تحميل الصورة بدون أن يحدث Lock للملف
                'If pic_purchases.Image IsNot Nothing Then
                '    pic_purchases.Image.Dispose()
                '    pic_purchases.Image = Nothing
                'End If

                'Using img As System.Drawing.Image = System.Drawing.Image.FromFile(sourcePath)
                '    pic_purchases.Image = New Bitmap(img)  ' ← نسخ الصورة (Clone)
                'End Using


                '' حفظ المسار الجديد في متغير
                'Dim imagePath As String = destinationPath

                ' لو عايز تخزنها في TextBox مثلاً
                'txtImagePath.Text = imagePath

                MessageBox.Show("✅ تم تحديد الصورة بنجاح:" & vbCrLf, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء حفظ الصورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'LoadProducts()
            'ClearAllFields()
            'ClearAllFields()
        End Try
    End Sub
    Private Sub loadlogininfo()

        Try
            Connect()

            Dim query As String = "
                SELECT User_Name 
                FROM Users_TBL 
                WHERE User_ID = @ID
            "

            Using cmd As New SqlCommand(query, Conn)

                cmd.Parameters.AddWithValue("@ID", Session.CurrentUserID)

                Dim User_Name As String = Convert.ToString(cmd.ExecuteScalar())
                lbl_user_name.Text = User_Name

            End Using

        Catch ex As Exception

            MessageBox.Show("حدث خطأ أثناء التحقق من المستحدم: " & ex.Message,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Finally
            Disconnect()
        End Try

    End Sub
    Private Sub btnSaveInvoice_Click(sender As Object, e As EventArgs) Handles btnSaveInvoice.Click
        ' في FormSales.vb

        ' ----------------------------------------------------
        ' 1. التحقق المبدئي والحصول على المتغيرات
        ' ----------------------------------------------------
        ' التحقق من وجود ID العميل
        If String.IsNullOrWhiteSpace(cmbVendor.Text) Then
            MessageBox.Show("الرجاء إدخال التأكد من بيانات المورد اولا.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbVendor.Focus()
            Exit Sub
        End If

        If dgv_Purchases.Rows.Count = 0 Then
            MessageBox.Show("يجب إضافة أصناف للفاتورة أولاً.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' جلب كود العميل
        Dim SupplierID As Integer = Convert.ToInt32(cmbVendor.SelectedValue)
        'Dim CustomerID As Integer = 0

        'Try
        '    Connect()
        '    Dim query As String = "SELECT CustomerID FROM Customers WHERE CustomerCode = @ID"
        '    Using cmd As New SqlCommand(query, Conn)
        '        cmd.Parameters.AddWithValue("@ID", SupplierID)
        '        Dim obj = cmd.ExecuteScalar()
        '        If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
        '            Integer.TryParse(obj.ToString(), SupplierID)
        '        Else
        '            MessageBox.Show("لم يتم العثور على عميل بهذا الكود.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Exit Sub
        '        End If
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء التحقق من العميل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'Finally
        '    Disconnect()
        'End Try

        'مجلد الحفظ
        Dim photosFolder As String = Path.Combine(System.Windows.Forms.Application.StartupPath, "photos_purchases")

        ' إنشاء المجلد لو مش موجود
        If Not Directory.Exists(photosFolder) Then
            Directory.CreateDirectory(photosFolder)
        End If

        ' اسم الصورة الجديدة (مثلاً حسب التاريخ والوقت لتجنب التكرار)
        Dim id As Integer = Convert.ToInt32(txt_Invoice_ID.Text)
        Dim newFileName As String = "purchases_" & id & Path.GetExtension(sourcePath)
        Dim destinationPath As String = Path.Combine(photosFolder, newFileName)

        ' نسخ الصورة
        File.Copy(sourcePath, destinationPath, True)
        'Using Conn

        '    Connect()
        '    Using cmd As New SqlCommand("UPDATE Products SET purchases_Image = @purchases_Image WHERE Product_ID = @Product_ID", Conn)
        '        cmd.Parameters.AddWithValue("@purchases_Image", destinationPath)
        '        cmd.Parameters.AddWithValue("@Product_ID", id)
        '        cmd.ExecuteNonQuery()
        '    End Using
        '    Disconnect()
        'End Using


        ' جلب القيم من الواجهة
        Dim totalBeforeDiscount As Decimal = 0D
        Decimal.TryParse(txtTotalRequired.Text, totalBeforeDiscount)

        Dim totalAfterDiscount As Decimal = 0D
        Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount)

        Dim discountValue As Decimal = 0D
        Decimal.TryParse(txtDiscount.Text, discountValue)

        Dim paidAmount As Decimal = 0D
        Decimal.TryParse(txtPaid.Text, paidAmount)

        Dim Remaining As Decimal = 0D
        Decimal.TryParse(txtRemaining.Text, Remaining)

        Dim notest As String = Convert.ToString(txt_notes.Text)
        Dim userloginid As Integer = Session.CurrentUserID
        Dim usernamelogin As String = Convert.ToString(lbl_user_name.Text.Trim())
        Dim paymentType As String = cmb_Pay.Text.Trim()

        ' ----------------------------------------------------
        ' 2. التحقق من المخزون قبل المعاملة
        ' ----------------------------------------------------
        ' (اختياري – لو عندك دالة تحقق من المخزون قبل التنفيذ، يتم استدعاؤها هنا)

        Connect()
        Dim transaction As SqlTransaction = Conn.BeginTransaction()
        Dim NewInvoiceID As Integer = 0

        Try
            ' -------------------------------------------
            ' 3. إدخال الفاتورة في SalesHeader
            ' -------------------------------------------
            Dim query_header As String = "
                INSERT INTO Purchase_Header (Purchase_Date, Supplier_ID, User_ID, User_Name, Total_Amount, Discount_Value, Net_Amount, Amount_Paid, Remaining, Payment_Method, Notes , purchases_Image)
                VALUES (GETDATE(), @Supplier_ID, @User_ID, @User_Name, @Total_Amount, @Discount_Value, @Net_Amount, @Amount_Paid, @Remaining, @Payment_Method, @Notes ,@destinationPath);
                SELECT SCOPE_IDENTITY();"

            Using cmd_header As New SqlCommand(query_header, Conn, transaction)
                cmd_header.Parameters.AddWithValue("@Supplier_ID", SupplierID)
                cmd_header.Parameters.AddWithValue("@User_ID", userloginid)
                cmd_header.Parameters.AddWithValue("@User_Name", usernamelogin)
                cmd_header.Parameters.AddWithValue("@Total_Amount", totalAfterDiscount)
                cmd_header.Parameters.AddWithValue("@Discount_Value", discountValue)
                cmd_header.Parameters.AddWithValue("@Net_Amount", totalBeforeDiscount)
                cmd_header.Parameters.AddWithValue("@Amount_Paid", paidAmount)
                cmd_header.Parameters.AddWithValue("@Remaining", Remaining)
                cmd_header.Parameters.AddWithValue("@Payment_Method", paymentType)
                cmd_header.Parameters.AddWithValue("@Notes", notest)
                cmd_header.Parameters.AddWithValue("@destinationPath", destinationPath)

                Dim obj = cmd_header.ExecuteScalar()
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    Integer.TryParse(obj.ToString(), NewInvoiceID)
                Else
                    Throw New Exception("فشل إنشاء رقم الفاتورة (SCOPE_IDENTITY).")
                End If
            End Using

            ' -------------------------------------------
            ' 4. إدخال تفاصيل الفاتورة وتحديث المخزون
            ' -------------------------------------------
            For Each row As DataGridViewRow In dgv_Purchases.Rows
                If row.IsNewRow Then Continue For

                Dim PID As Integer = 0
                Integer.TryParse(Convert.ToString(row.Cells("ColProductID").Value), PID)

                Dim UnitID As Integer = 0
                Integer.TryParse(Convert.ToString(row.Cells("ColUnitID").Value), UnitID)

                Dim SalePrice As Decimal = 0D
                Decimal.TryParse(Convert.ToString(row.Cells("ColPrice").Value), SalePrice)

                Dim QtySold As Decimal = 0D
                Decimal.TryParse(Convert.ToString(row.Cells("ColQuantity").Value), QtySold)

                'Dim TotalLine As Decimal = 0D
                'Decimal.TryParse(Convert.ToString(row.Cells("ColTotal").Value), TotalLine)

                Dim Factor As Decimal = 1D
                Decimal.TryParse(Convert.ToString(row.Cells("ColFactor").Value), Factor)

                Dim QtyBaseToDeduct As Decimal = QtySold * Factor
                ' تفاصيل الصنف
                Dim query_details As String = "
                INSERT INTO Purchase_Detalis (Purchase_Id, Product_ID, ProductUnit_ID, Quantity_Sold, Purchase_Price_Per_Unit)
                VALUES (@InvID, @PID, @UnitID, @QtySold, @Price);"

                Using cmd_details As New SqlCommand(query_details, Conn, transaction)
                    cmd_details.Parameters.AddWithValue("@InvID", NewInvoiceID)
                    cmd_details.Parameters.AddWithValue("@PID", PID)
                    cmd_details.Parameters.AddWithValue("@UnitID", UnitID)
                    cmd_details.Parameters.AddWithValue("@QtySold", QtySold)
                    cmd_details.Parameters.AddWithValue("@Price", SalePrice)
                    cmd_details.ExecuteNonQuery()
                End Using

                ' تحديث المخزون
                Dim query_stock_update As String = "
    UPDATE Stock SET Quantity_OnHand = Quantity_OnHand + @DeductQty WHERE Product_ID = @PID;"
                Using cmd_stock_update As New SqlCommand(query_stock_update, Conn, transaction)
                    cmd_stock_update.Parameters.AddWithValue("@DeductQty", QtyBaseToDeduct)
                    cmd_stock_update.Parameters.AddWithValue("@PID", PID)
                    cmd_stock_update.ExecuteNonQuery()
                End Using
            Next

            ' -------------------------------------------
            ' 5. التحقق من الرصيد
            ' -------------------------------------------
            Dim BalanceBefore As Decimal = 0D
            ' قراءة الرصيد وحد الائتمان قبل التحديث
            Dim qCustomerInfo As String = "SELECT ISNULL(CurrentBalance,0) FROM Suppliers WHERE SuppliersID = @ID"
            Using cmdCust As New SqlCommand(qCustomerInfo, Conn, transaction)
                cmdCust.Parameters.AddWithValue("@ID", SupplierID)
                Using rdr = cmdCust.ExecuteReader()
                    If rdr.Read() Then
                        BalanceBefore = Convert.ToDecimal(rdr(0))
                    End If
                End Using
            End Using

            '' حساب الرصيد بعد الفاتورة
            'Dim BalanceAfter As Decimal = BalanceBefore + Remaining
            '' التحقق من تجاوز الحد
            'If BalanceAfter > CreditLimit Then
            '    transaction.Rollback()
            '    MessageBox.Show("⚠️ لا يمكن حفظ الفاتورة لأن الرصيد بعد العملية سيتجاوز حد الائتمان المسموح به للعميل." &
            '                vbCrLf & $"حد الائتمان: {CreditLimit}" &
            '                vbCrLf & $"الرصيد الحالي: {BalanceBefore}" &
            '                vbCrLf & $"متبقي الفاتورة: {Remaining}" &
            '                vbCrLf & $"الرصيد بعد الفاتورة: {BalanceAfter}",
            '                "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If

            ' -------------------------------------------
            ' 6. تحديث رصيد المورد بعد التأكد من الحد الائتماني
            ' -------------------------------------------
            If Remaining <> 0 Then
                Dim query_update_customer As String = "
        UPDATE Suppliers 
        SET CurrentBalance = ISNULL(CurrentBalance, 0) + @RemainingAmount
        WHERE SuppliersID = @SuppliersID;"
                Using cmd_update_customer As New SqlCommand(query_update_customer, Conn, transaction)
                    cmd_update_customer.Parameters.AddWithValue("@RemainingAmount", Remaining)
                    cmd_update_customer.Parameters.AddWithValue("@SuppliersID", SupplierID)
                    cmd_update_customer.ExecuteNonQuery()
                End Using
            End If

            ' -------------------------------------------
            ' 7. تأكيد المعاملة
            ' -------------------------------------------
            transaction.Commit()

            MessageBox.Show($"✅ تم حفظ الفاتورة رقم {NewInvoiceID} بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cleartxts()
            'ClearSalesForm()

        Catch ex As Exception
            ' -------------------------------------------
            ' 8. التراجع عند الخطأ
            ' -------------------------------------------
            Try
                transaction.Rollback()
            Catch
            End Try

            MessageBox.Show("❌ فشل الحفظ. تم التراجع عن التغييرات. الخطأ: " & ex.Message,
                        "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Disconnect()
        End Try

    End Sub
    Private Sub cleartxts()

        newInvoiceID()

        txtProductCodeSearch.Clear()
        txtProductNameSearch.Clear()
        cmbUnit.DataSource = Nothing
        cmbUnit.Items.Clear()
        cmbVendor.DataSource = Nothing
        cmbVendor.Items.Clear()

        txt_notes.Clear()
        txt_purchase_price.Clear()
        txtQuantity.Clear()
        txt_totelProduct.Clear()

        txtTotalRequired.Clear()
        txtDiscount.Clear()
        txtTotalAfterDiscount.Clear()
        txtPaid.Clear()
        txtRemaining.Clear()

        'txt_Customer_Code.Clear()
        'txt_Customer_Name.Clear()
        'txt_Customer_Balance.Clear()


        'txt_Customer_Code.TabIndex = 1
        'txt_Customer_Name.TabIndex = 2
        'lstSuggestions.TabIndex = 3

        cmbUnit.TextAlign = HorizontalAlignment.Center
        txt_purchase_price.TextAlign = HorizontalAlignment.Center
        txtQuantity.TextAlign = HorizontalAlignment.Center
        txt_totelProduct.TextAlign = HorizontalAlignment.Center

    End Sub

    Private Sub cmbVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVendor.SelectedIndexChanged

    End Sub

    Private Sub dgv_Purchases_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Purchases.CellClick
        ' التأكد من أن المستخدم نقر على عمود الحذف (ColDelete)
        If e.ColumnIndex = dgv_Purchases.Columns("ColDelete").Index AndAlso e.RowIndex >= 0 Then

            Dim ProductNameToDelete As String = dgv_Purchases.Rows(e.RowIndex).Cells("ColProductName").Value.ToString()

            If MessageBox.Show($"هل أنت متأكد من حذف الصنف ({ProductNameToDelete}) من الفاتورة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                ' 1. حذف الصف
                dgv_Purchases.Rows.RemoveAt(e.RowIndex)

                ' 2. تحديث الإجماليات
                UpdateInvoiceTotals()

                MessageBox.Show("تم حذف الصنف.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub



    Private Sub SetupDataGridView(ByVal dgv As DataGridView)
        ' ------------------------------
        ' 1. الإعدادات الأساسية
        ' ------------------------------
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False

        ' ------------------------------
        ' 2. ألوان الوضع الداكن (Dark Mode)
        ' ------------------------------
        Dim darkBackground As Color = Color.FromArgb(30, 30, 30)           ' خلفية رئيسية
        Dim darkRow As Color = Color.FromArgb(45, 45, 45)                  ' صف عادي
        Dim darkAltRow As Color = Color.FromArgb(55, 55, 55)               ' صف متناوب
        Dim darkHeader As Color = Color.FromArgb(64, 64, 64)               ' رؤوس الأعمدة
        Dim highlightColor As Color = Color.FromArgb(0, 122, 204)          ' لون الصف المحدد
        Dim textColor As Color = Color.Gainsboro                           ' النصوص العادية

        dgv.BackgroundColor = darkBackground
        dgv.RowsDefaultCellStyle.BackColor = darkRow
        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAltRow
        dgv.DefaultCellStyle.ForeColor = textColor
        dgv.GridColor = Color.FromArgb(80, 80, 80)

        ' ------------------------------
        ' 3. تنسيق الأعمدة والعناوين
        ' ------------------------------
        With dgv
            .Columns.Clear()

            ' إضافة الأعمدة المرئية
            .Columns.Add("ColProductID", "كود المنتج")
            .Columns.Add("ColProductName", "اسم المنتج")
            .Columns.Add("ColUnitName", "الوحدة")
            .Columns.Add("ColPrice", "سعر الوحدة")
            .Columns.Add("ColQuantity", "الكمية")
            .Columns.Add("ColTotal", "الإجمالي")

            ' إضافة الأعمدة المخفية (مفاتيح ومنطق الحساب)
            .Columns.Add("ColUnitID", "UnitID")
            .Columns.Add("ColFactor", "Factor")

            .Columns("ColUnitID").Visible = False
            .Columns("ColFactor").Visible = False

            ' 2. إضافة عمود الحذف (Button Column)
            Dim btnCol As New DataGridViewButtonColumn()
            btnCol.HeaderText = "حذف"
            btnCol.Text = "❌" ' أو "حذف"
            btnCol.Name = "ColDelete"
            btnCol.UseColumnTextForButtonValue = True
            .Columns.Add(btnCol)

            ' 3. التنسيق الاحترافي (إذا لم يكن جاهزاً)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            ' عرض الأعمدة
            .Columns("ColProductName").Width = 230
            .Columns("ColQuantity").Width = 160

            '' الترتيب
            '.Columns("ProductCode").DisplayIndex = 0
            '.Columns("ProductName").DisplayIndex = 1
            '.Columns("DisplayStockQuantity").DisplayIndex = 2
            '.Columns("BaseUnitName").DisplayIndex = 3
            '.Columns("MinQuantity").DisplayIndex = 4

            ' تنسيق الأرقام
            .Columns("ColPrice").DefaultCellStyle.Format = "N2"
            .Columns("ColTotal").DefaultCellStyle.Format = "N2"

            ' محاذاة النصوص
            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            ' ------------------------------
            ' 4. مظهر الرأس والصفوف
            ' ------------------------------
            dgv.RowTemplate.Height = 32
            dgv.ColumnHeadersHeight = 45


            ' رؤوس الأعمدة
            dgv.ColumnHeadersDefaultCellStyle.BackColor = darkHeader
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.5!, FontStyle.Bold)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            ' ------------------------------
            ' 5. الصف المحدد (Selection)
            ' ------------------------------
            dgv.DefaultCellStyle.SelectionBackColor = highlightColor
            dgv.DefaultCellStyle.SelectionForeColor = Color.White
            dgv.DefaultCellStyle.Font = New Font("Segoe UI", 10.5!)

            ' ------------------------------
            ' 6. تحسين الشكل العام
            ' ------------------------------
            dgv.RowHeadersVisible = False
            dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        End With
    End Sub
End Class