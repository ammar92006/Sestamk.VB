Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.Utils.Html.Internal
Imports DocumentFormat.OpenXml.ExtendedProperties
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler.Commands

Public Class Purchases
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim manager As New temp_manager()
    Public sourcePath As String = ""
    Public SelectedProductId As Integer = 0
    Public CurrentConversionFactor As Decimal = 0D
    Public CurrentSalePrice As Decimal = 0D
    Private CurrentUnitID As Integer = 0
    Private _autoSave As Boolean = False


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
    Public Sub ProcessBarcodeData(code As String)
        Dim Barcode As String = ""
        Try
            Barcode = code.Trim

            If String.IsNullOrWhiteSpace(Barcode) Then Exit Sub

            ' ==========================
            ' تحقق هل الباركود منتج ميزان
            ' ==========================
            If Barcode.StartsWith("99") Then
                AddScaleProductToGrid(Barcode)
                'txtQuantity.Text = "" ' الكمية محسوبة تلقائياً من الوزن
                'btn_add_product.PerformClick()

            Else
                ' المنتجات العادية
                If SearchAndFillProductByBarcode(Barcode) Then
                    txtQuantity.Text = "1"
                    btn_add_product.PerformClick()
                End If
            End If

        Catch ex As Exception
            ' تجاهل الخطأ بدون توقف البرنامج
        End Try
    End Sub
    ' ==========================
    ' دالة خاصة بمنتجات الميزان
    ' ==========================
    Private Sub AddScaleProductToGrid(ByVal barcodeValue As String)
        Try
            ' ================================
            ' 1) التحقق من الباركود
            ' ================================
            barcodeValue = barcodeValue.Trim()
            Dim productCodeStr As String = barcodeValue.Substring(2, 5)
            If String.IsNullOrWhiteSpace(barcodeValue) Then
                MessageBox.Show("⚠️ الباركود فارغ.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If barcodeValue.Length < 12 Then
                MessageBox.Show("⚠️ باركود الميزان يجب أن يكون 12 رقم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' ================================
            ' 2) التحقق من أن الباركود يبدأ بـ 99
            ' ================================
            If Not barcodeValue.StartsWith("99") Then
                MessageBox.Show("⚠️ هذا ليس باركود ميزان (لا يبدأ بـ 99).", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' ================================
            ' 3) استخراج كود المنتج (بعد 99)
            ' ================================

            If Not IsNumeric(productCodeStr) Then
                MessageBox.Show("⚠️ كود المنتج داخل الباركود غير صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim productID As Integer = CInt(productCodeStr)

            ' ================================
            ' 4) استخراج الوزن (5 أرقام)
            ' ================================
            Dim weightStr As String = barcodeValue.Substring(7, 5)

            If Not IsNumeric(weightStr) Then
                MessageBox.Show("⚠️ الوزن داخل الباركود غير صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim weightGrams As Decimal = CDec(weightStr)  ' الوزن بالجرام

            ' ================================
            ' 5) جلب بيانات المنتج من قاعدة البيانات
            ' ================================
            Dim dtScale As DataTable = manager.GetScaleProductByCode(productID)

            If dtScale Is Nothing OrElse dtScale.Rows.Count = 0 Then
                MessageBox.Show($"⚠️ لا يوجد منتج لهذا الكود: {productCodeStr}",
                        "غير موجود",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim row As DataRow = dtScale.Rows(0)
            Dim productName As String = row("Name").ToString()
            Dim dbPrice As Decimal = CDec(row("Price")) ' سعر الكيلو من قاعدة البيانات

            ' ================================
            ' 6) حساب الإجمالي: وزن × سعر
            ' ================================
            ' السعر للكيلو — الوزن جرام → تحويل للكيلو
            Dim weightKg As Decimal = weightGrams / 1000D
            Dim totalPrice As Decimal = weightKg * dbPrice

            ' ================================
            ' 7) تجهيز الجريد
            ' ================================
            Dim dgv As DataGridView = Me.dgv_Purchases

            ' البحث عن المنتج داخل الجريد
            Dim rowFound As DataGridViewRow =
            dgv.Rows.Cast(Of DataGridViewRow)().
            FirstOrDefault(Function(r)
                               Return Not r.IsNewRow AndAlso
                                      CInt(r.Cells("ColProductID").Value) = productID
                           End Function)

            If rowFound IsNot Nothing Then
                Dim oldQty As Decimal = CDec(rowFound.Cells("ColQuantity").Value)
                Dim newQty As Decimal = oldQty + weightGrams

                rowFound.Cells("ColQuantity").Value = newQty
                rowFound.Cells("ColPrice").Value = dbPrice
                rowFound.Cells("ColTotal").Value = Math.Round(newQty / 1000D * dbPrice, 2)

            Else
                Dim newRow As DataGridViewRow = dgv.Rows(dgv.Rows.Add())

                newRow.Cells("ColProductID").Value = productID
                newRow.Cells("ColProduct_Code").Value = productID
                newRow.Cells("ColProductName").Value = productName
                newRow.Cells("ColUnitName").Value = "جرام"
                newRow.Cells("ColPrice").Value = dbPrice
                newRow.Cells("ColQuantity").Value = weightGrams
                newRow.Cells("ColTotal").Value = Math.Round(totalPrice, 2)
            End If

            ' ================================
            ' 8) تحديث إجمالي الفاتورة
            ' ================================
            UpdateInvoiceTotals()

        Catch ex As Exception
            MessageBox.Show("❌ خطأ أثناء إضافة منتج الميزان: " & ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        End Try
    End Sub



    Private Function SearchAndFillProductByBarcode(ByVal barcodeValue As String) As Boolean

        Try
            Dim dtUnit As DataTable = manager.GetUnitByBarcode2(barcodeValue)

            If dtUnit.Rows.Count = 1 Then

                Dim row As DataRow = dtUnit.Rows(0)

                SelectedProductId = row("Product_ID").ToString()
                txtProductNameSearch.Text = row("Product_Name").ToString()
                If lstNameSuggestions.Items.Count > 0 Then
                    lstNameSuggestions.SelectedIndex = 0
                End If
                'txtProductCodeSearch.Text = row("Product_Code").ToString()
                cmbUnit.Text = row("Unit_Name").ToString()
                txt_purchase_price.Text = row("Purchase_Price").ToString()
                Return True

            Else
                MessageBox.Show($"لا يوجد منتج مرتبط بالباركود: {barcodeValue}",
                                "منتج غير موجود",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)

                Return False
            End If

        Catch ex As Exception

            MessageBox.Show("خطأ في البحث عن الباركود: " & ex.Message,
                            "خطأ قاعدة بيانات",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

            Return False

        End Try

    End Function

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
        getnewInvoiceID()
        SetupDataGridView(dgv_Purchases)
        ' [FIX] تفعيل DoubleBuffered
        EnableDoubleBuffer(dgv_Purchases)
        LoadSuppliers()
        'newInvoiceID()
        pic_purchases.Image = My.Resources.نص_فقرتك
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


        ''الزراير
        Me.btn_add_new_product.Location = New System.Drawing.Point(20, 5)
        Me.btnDelete.Location = New System.Drawing.Point(430, 5)
        Me.btnEdit.Location = New System.Drawing.Point(800, 5)
        Me.btnSaveInvoice.Location = New System.Drawing.Point(1200, 5)

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
            Using Conn
                Connect()

                Dim query As String =
                "SELECT Product_Name, Product_State 
                 FROM Products 
                 WHERE Product_ID = @id"

                Dim cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@id", productId)

                Dim reader = cmd.ExecuteReader()

                If reader.Read() Then

                    Dim productName As String = reader("Product_Name").ToString()
                    Dim isActive As Boolean = Convert.ToBoolean(reader("Product_State"))

                    If isActive = True Then
                        Return True
                    End If

                    ' المنتج غير نشط → رسالة احترافية
                    MessageBox.Show(
                    $"⚠️ المنتج غير نشط ولا يمكن استخدامه حالياً." & vbCrLf &
                    $"📦 اسم المنتج: {productName}" & vbCrLf &
                    $"🔍 كود المنتج: {productId}",
                    "تنبيه - المنتج غير نشط",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                    Return False
                Else
                    MessageBox.Show(
                    "❌ لم يتم العثور على المنتج المطلوب.",
                    "منتج غير موجود",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )
                    Return False
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("حدث خطأ: " & ex.Message,
                        "خطأ في البحث",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
            Return False
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
        getnewInvoiceID()
        txtProductCodeSearch.Clear()
        txtProductNameSearch.Clear()
        cmbUnit.DataSource = Nothing
        cmbUnit.Items.Clear()
        txt_purchase_price.Clear()
        txtQuantity.Clear()
        txt_totelProduct.Clear()
        'cmbVendor.Items.Clear()
        cmbVendor.SelectedIndex = -1

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

        Dim qtyToAddDecimal As Decimal
        If Not Decimal.TryParse(txtQuantity.Text.Trim(), qtyToAddDecimal) OrElse qtyToAddDecimal <= 0D Then
            MessageBox.Show("❌ الكمية غير صالحة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim dgv As DataGridView = Me.dgv_Purchases

        Dim currentProductId As Integer = Me.SelectedProductId
        Dim currentProduct_Code As String = txtProductCodeSearch.Text.Trim()
        Dim currentProductName As String = txtProductNameSearch.Text.Trim()
        Dim currentUnitName As String = cmbUnit.Text.Trim()
        Dim price As Decimal = CurrentSalePrice
        If CurrentSalePrice <> Convert.ToDecimal(txt_purchase_price.Text) Then
            price = Convert.ToDecimal(txt_purchase_price.Text)
        End If
        Dim unitId = CurrentUnitID
        Dim factor As Decimal = CurrentConversionFactor
        Dim useIdMatch As Boolean = (currentProductId > 0)

        ' ===============================
        ' البحث عن صف موجود (مطابقة دقيقة: كود + اسم + وحدة)
        ' ===============================
        Dim rowFound As DataGridViewRow = Nothing

        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For

            Try
                Dim existingId As Integer = 0
                Dim existingCode As String = String.Empty
                Dim existingProductName As String = String.Empty
                Dim existingUnitName As String = String.Empty

                If dgv.Columns.Contains("ColProductID") Then
                    Dim cellVal = row.Cells("ColProductID").Value
                    If cellVal IsNot Nothing AndAlso Not IsDBNull(cellVal) Then
                        Integer.TryParse(cellVal.ToString(), existingId)
                    End If
                End If

                If dgv.Columns.Contains("ColProduct_Code") Then
                    Dim c = row.Cells("ColProduct_Code").Value
                    existingCode = If(c, "").ToString().Trim()
                End If

                If dgv.Columns.Contains("ColProductName") Then
                    Dim n = row.Cells("ColProductName").Value
                    existingProductName = If(n, "").ToString().Trim()
                End If

                If dgv.Columns.Contains("ColUnitName") Then
                    Dim u = row.Cells("ColUnitName").Value
                    existingUnitName = If(u, "").ToString().Trim()
                End If

                Dim codeMatches As Boolean = String.Equals(existingCode, currentProduct_Code, StringComparison.OrdinalIgnoreCase)
                Dim nameMatches As Boolean = String.Equals(existingProductName, currentProductName, StringComparison.OrdinalIgnoreCase)
                Dim unitMatches As Boolean = String.Equals(existingUnitName, currentUnitName, StringComparison.OrdinalIgnoreCase)

                If useIdMatch Then
                    If existingId = currentProductId AndAlso codeMatches AndAlso nameMatches AndAlso unitMatches Then
                        rowFound = row
                        Exit For
                    End If
                Else
                    If codeMatches AndAlso nameMatches AndAlso unitMatches Then
                        rowFound = row
                        Exit For
                    End If
                End If

            Catch ex As Exception
            End Try
        Next

        ' ===============================
        ' المنتج موجود في الجدول
        ' ===============================
        If rowFound IsNot Nothing Then

            Dim existingQty As Decimal = 0D
            Decimal.TryParse(rowFound.Cells("ColQuantity").Value, existingQty)

            ' الجمع على الكمية الموجودة
            Dim newQty As Decimal = existingQty + qtyToAddDecimal

            rowFound.Cells("ColQuantity").Value = newQty
            rowFound.Cells("ColPrice").Value = price
            rowFound.Cells("ColTotal").Value = Math.Round(newQty * price, 2)
            If dgv.Columns.Contains("ColUnitID") Then rowFound.Cells("ColUnitID").Value = unitId
            If dgv.Columns.Contains("ColFactor") Then rowFound.Cells("ColFactor").Value = factor

        Else

            ' ===============================
            ' إضافة صف جديد
            ' ===============================
            Dim newRow As DataGridViewRow = CType(dgv.RowTemplate.Clone(), DataGridViewRow)
            newRow.CreateCells(dgv)

            If dgv.Columns.Contains("ColProductID") Then newRow.Cells(dgv.Columns("ColProductID").Index).Value = currentProductId
            If dgv.Columns.Contains("ColProduct_Code") Then newRow.Cells(dgv.Columns("ColProduct_Code").Index).Value = currentProduct_Code
            If dgv.Columns.Contains("ColProductName") Then newRow.Cells(dgv.Columns("ColProductName").Index).Value = currentProductName
            If dgv.Columns.Contains("ColUnitName") Then newRow.Cells(dgv.Columns("ColUnitName").Index).Value = currentUnitName
            If dgv.Columns.Contains("ColPrice") Then newRow.Cells(dgv.Columns("ColPrice").Index).Value = price
            If dgv.Columns.Contains("ColQuantity") Then newRow.Cells(dgv.Columns("ColQuantity").Index).Value = qtyToAddDecimal
            If dgv.Columns.Contains("ColTotal") Then newRow.Cells(dgv.Columns("ColTotal").Index).Value = Math.Round(qtyToAddDecimal * price, 2)
            If dgv.Columns.Contains("ColUnitID") Then newRow.Cells(dgv.Columns("ColUnitID").Index).Value = unitId
            If dgv.Columns.Contains("ColFactor") Then newRow.Cells(dgv.Columns("ColFactor").Index).Value = factor

            dgv.Rows.Add(newRow)
        End If

        UpdateInvoiceTotals()

    End Sub


    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        ClearProductFields()
        cleartxts()
    End Sub
    Private Sub txtTotalRequired_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRequired.TextChanged
        CalculateInvoice()
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        CalculateInvoice()
    End Sub

    Private Sub txtPaid_TextChanged(sender As Object, e As EventArgs) Handles txtPaid.TextChanged
        CalculateInvoice()
    End Sub

    Private Sub CalculateInvoice()

        Dim totalRequired As Decimal
        Dim discount As Decimal
        Dim totalAfterDiscount As Decimal
        Dim paid As Decimal
        Dim remaining As Decimal

        ' ===============================
        ' 1️⃣ حساب الإجمالي بعد الخصم
        ' ===============================
        If Decimal.TryParse(txtTotalRequired.Text, totalRequired) Then

            If Decimal.TryParse(txtDiscount.Text, discount) Then

                ' لو الخصم أكبر من الإجمالي
                If discount > totalRequired Then
                    MessageBox.Show("⚠️ قيمة الخصم لا يمكن أن تتجاوز المبلغ المطلوب!",
                                "تنبيه",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)

                    txtDiscount.Text = "0"
                    discount = 0
                End If

                totalAfterDiscount = totalRequired - discount
                txtTotalAfterDiscount.Text = totalAfterDiscount.ToString("0.##")

            Else
                totalAfterDiscount = totalRequired
                txtTotalAfterDiscount.Text = totalRequired.ToString("0.##")
            End If

        Else
            txtTotalAfterDiscount.Text = ""
            txtRemaining.Text = ""
            Exit Sub
        End If

        ' ===============================
        ' 2️⃣ حساب المتبقي
        ' ===============================
        If Decimal.TryParse(txtPaid.Text, paid) Then

            remaining = paid - totalAfterDiscount

            ' عرض المتبقي بدون إشارة
            txtRemaining.Text = Math.Abs(remaining).ToString("0.##")

            ' تلوين حسب الحالة
            If remaining < 0 Then
                txtRemaining.ForeColor = Color.Red      ' عليه فلوس
            ElseIf remaining > 0 Then
                txtRemaining.ForeColor = Color.Green    ' باقي له
            Else
                txtRemaining.ForeColor = Color.Black    ' تمام
            End If

        Else
            ' لو المدفوع فاضي
            txtRemaining.Text = totalAfterDiscount.ToString("0.##")
            txtRemaining.ForeColor = Color.Red
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

    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click
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
                If pic_purchases.Image IsNot Nothing Then
                    pic_purchases.Image.Dispose()
                    pic_purchases.Image = Nothing
                End If

                Using img As System.Drawing.Image = System.Drawing.Image.FromFile(sourcePath)
                    pic_purchases.Image = New Bitmap(img)  ' ← نسخ الصورة (Clone)
                End Using


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
        If Not String.IsNullOrEmpty(sourcePath) Then
            File.Copy(sourcePath, destinationPath, True)
        End If
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


        Dim invoiceCode As Integer = 0

        ' [الأمان]: التحقق من صحة رقم الفاتورة
        If Not Integer.TryParse(txt_Invoice_ID.Text.Trim(), invoiceCode) OrElse invoiceCode <= 0 Then
            MessageBox.Show("رقم الفاتورة غير صالح.")
            Return
        End If


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
                INSERT INTO Purchase_Header (Purchase_Date, Supplier_ID, User_ID, User_Name, Total_Amount, Discount_Value, Net_Amount, Amount_Paid, Remaining, Payment_Method, Notes , purchases_Image , Invoice_Code)
                VALUES (GETDATE(), @Supplier_ID, @User_ID, @User_Name, @Total_Amount, @Discount_Value, @Net_Amount, @Amount_Paid, @Remaining, @Payment_Method, @Notes ,@destinationPath ,@Invoice_Code);
                SELECT SCOPE_IDENTITY();"


            Dim query_check As String = "SELECT COUNT(*) FROM Purchase_Header WHERE Invoice_Code=@ic"
            Using cmd_check As New SqlCommand(query_check, Conn, transaction)
                cmd_check.Parameters.Add("@ic", SqlDbType.Int).Value = invoiceCode

                If Convert.ToInt32(cmd_check.ExecuteScalar()) > 0 Then
                    Throw New Exception("كود الفاتورة موجود بالفعل.")
                    Exit Sub
                End If
            End Using


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
                cmd_header.Parameters.AddWithValue("@Invoice_Code", invoiceCode)

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

                Dim TotalLine As Decimal = 0D
                Decimal.TryParse(Convert.ToString(row.Cells("ColTotal").Value), TotalLine)

                Dim Factor As Decimal = 1D
                Decimal.TryParse(Convert.ToString(row.Cells("ColFactor").Value), Factor)

                Dim PName As String = row.Cells("ColProductName").Value
                Dim UnitName As String = row.Cells("ColUnitName").Value

                Dim QtyBaseToDeduct As Decimal = QtySold * Factor
                Dim query_details As String = "
                INSERT INTO Purchase_Detalis (Purchase_Id, Product_ID,Product_Name,ProductUnit_Name, ProductUnit_ID, Quantity_Sold, Purchase_Price_Per_Unit)
                VALUES (@InvID, @PID,@Product_Name,@ProductUnit_Name, @UnitID, @QtySold, @Price);"

                Using cmd_details As New SqlCommand(query_details, Conn, transaction)
                    cmd_details.Parameters.AddWithValue("@InvID", NewInvoiceID)
                    cmd_details.Parameters.AddWithValue("@PID", PID)
                    cmd_details.Parameters.AddWithValue("@Product_Name", PName)
                    cmd_details.Parameters.AddWithValue("@ProductUnit_Name", UnitName)
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
            'cleartxts()
            'ClearSalesForm()
            btnDelete.PerformClick()

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
        getnewInvoiceID()
        txtProductCodeSearch.Clear()
        txtProductNameSearch.Clear()
        cmbUnit.DataSource = Nothing
        cmbUnit.Items.Clear()
        'cmbVendor.DataSource = Nothing
        'cmbVendor.Items.Clear()
        cmbVendor.SelectedIndex = -1

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

    Private Sub cmbVendor_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub dgv_Purchases_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Purchases.CellClick
    '    ' التأكد من أن المستخدم نقر على عمود الحذف (ColDelete)
    '    If e.ColumnIndex = dgv_Purchases.Columns("ColDelete").Index AndAlso e.RowIndex >= 0 Then

    '        Dim ProductNameToDelete As String = dgv_Purchases.Rows(e.RowIndex).Cells("ColProductName").Value.ToString()

    '        If MessageBox.Show($"هل أنت متأكد من حذف الصنف ({ProductNameToDelete}) من الفاتورة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '            ' 1. حذف الصف
    '            dgv_Purchases.Rows.RemoveAt(e.RowIndex)

    '            ' 2. تحديث الإجماليات
    '            UpdateInvoiceTotals()

    '            MessageBox.Show("تم حذف الصنف.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    End If
    'End Sub
    Private Function GetStockQty(productId As Integer) As Decimal
        Dim stockQty As Decimal = 0D

        Try
            Connect() ' فتح الاتصال

            Dim cmd As New SqlCommand("
            SELECT Quantity_OnHand 
            FROM Stock 
            WHERE Product_ID = @PID
        ", Conn)

            cmd.Parameters.AddWithValue("@PID", productId)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                stockQty = Convert.ToDecimal(result)
            End If

        Catch ex As Exception
            MessageBox.Show("" & ex.Message)
        Finally
            Disconnect() ' غلق الاتصال
        End Try

        ' لو عندك عامل تحويل (factor) لازم نعدّل به
        ' مثلاً لو الوحدة "كرتونة" = 12 قطعة → المخزون يكون عدد القطع
        Return stockQty
    End Function

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Purchases.CellClick
        If e.RowIndex < 0 Then Exit Sub

        ' ===========================
        '  حذف صنف
        ' ===========================
        If e.ColumnIndex = dgv_Purchases.Columns("ColDelete").Index Then

            Dim ProductNameToDelete As String = dgv_Purchases.Rows(e.RowIndex).Cells("ColProductName").Value.ToString()

            If MessageBox.Show($"هل أنت متأكد من حذف الصنف ({ProductNameToDelete}) من الفاتورة؟",
                           "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                dgv_Purchases.Rows.RemoveAt(e.RowIndex)
                UpdateInvoiceTotals()
                MessageBox.Show("تم حذف الصنف.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Exit Sub
        End If

        ' ===========================
        '  تحقق أن الضغط على + أو –
        ' ===========================
        Dim dgv = dgv_Purchases
        If e.ColumnIndex < 0 Then Exit Sub

        Dim colName As String = dgv.Columns(e.ColumnIndex).Name
        If colName <> "ColQtyPlus" AndAlso colName <> "ColQtyMinus" Then Exit Sub

        Dim row = dgv.Rows(e.RowIndex)

        ' ===========================
        '  جلب البيانات الأساسية
        ' ===========================
        Dim qty As Decimal = 0
        Decimal.TryParse(row.Cells("ColQuantity").Value.ToString(), qty)

        Dim price As Decimal = 0
        Decimal.TryParse(row.Cells("ColPrice").Value.ToString(), price)

        ' --------- جلب ProductID ----------
        Dim productId As Integer = 0
        If dgv.Columns.Contains("ColProductID") Then
            If row.Cells("ColProductID").Value IsNot Nothing Then
                Integer.TryParse(row.Cells("ColProductID").Value.ToString(), productId)
            End If
        End If

        ' --------- جلب المخزون ----------
        Dim stockQty As Decimal = GetStockQty(productId)

        ' ===========================
        '  منطق الزيادة والنقصان + فحص المخزون
        ' ===========================
        If colName = "ColQtyPlus" Then

            Dim newQty = qty + 1

            If newQty > stockQty Then
                MessageBox.Show("❌ لا يمكن إضافة هذه الكمية. المخزون المتاح هو: " & stockQty,
                            "كمية غير متوفرة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            qty = newQty

        ElseIf colName = "ColQtyMinus" Then

            qty -= 1

            If qty <= 0 Then
                dgv.Rows.RemoveAt(e.RowIndex)
                UpdateInvoiceTotals()
                Exit Sub
            End If
        End If

        ' ===========================
        '  تحديث القيم في الصف
        ' ===========================
        row.Cells("ColQuantity").Value = qty
        row.Cells("ColTotal").Value = Math.Round(qty * price, 2)

        UpdateInvoiceTotals()

    End Sub

    Public Sub OpenSingleForm(Of T As {Form, New})()

        ' ابحث عن الفورم في الـ OpenForms
        Dim frm As Form = Windows.Forms.Application.OpenForms.
            Cast(Of Form)().
            FirstOrDefault(Function(f) TypeOf f Is T)
        If frm IsNot Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            frm.Focus()
        Else
            Dim newForm As New T()
            newForm.Show()
        End If
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        OpenSingleForm(Of Purchase_Return)()

    End Sub

    Private Sub panelHeader_Paint(sender As Object, e As PaintEventArgs) Handles panelHeader.Paint

    End Sub

    Private Sub btn_add_new_product_Click(sender As Object, e As EventArgs) Handles btn_add_new_product.Click
        OpenSingleForm(Of add_new_product)()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ClearProductFields()
        cleartxts()
        dgv_Purchases.Rows.Clear()
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_add_product.PerformClick()
        End If
    End Sub

    Private Sub grpCustomerInfo_Click(sender As Object, e As EventArgs) Handles grpCustomerInfo.Click

    End Sub

    Private Sub btn_auto_pay_Click(sender As Object, e As EventArgs) Handles btn_auto_pay.Click
        If String.IsNullOrWhiteSpace(txtTotalAfterDiscount.Text) Then
            MessageBox.Show("برجاء التأكد من المبلغ بعد الخصم")
            Return
        End If

        txtPaid.Text = txtTotalAfterDiscount.Text
        cmb_Pay.SelectedIndex = 0
        If _autoSave Then btnSaveInvoice.PerformClick()
    End Sub

    Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch1.CheckedChanged
        _autoSave = Guna2ToggleSwitch1.Checked
    End Sub

    'Private Sub SetupDataGridView(ByVal dgv As DataGridView)
    '    ' ------------------------------
    '    ' 1. الإعدادات الأساسية
    '    ' ------------------------------
    '    dgv.AllowUserToAddRows = False
    '    dgv.AllowUserToDeleteRows = False
    '    dgv.ReadOnly = True
    '    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '    dgv.MultiSelect = False
    '    dgv.BorderStyle = BorderStyle.None
    '    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
    '    dgv.EnableHeadersVisualStyles = False

    '    ' ------------------------------
    '    ' 2. ألوان الوضع الداكن (Dark Mode)
    '    ' ------------------------------
    '    Dim darkBackground As Color = Color.FromArgb(30, 30, 30)           ' خلفية رئيسية
    '    Dim darkRow As Color = Color.FromArgb(45, 45, 45)                  ' صف عادي
    '    Dim darkAltRow As Color = Color.FromArgb(55, 55, 55)               ' صف متناوب
    '    Dim darkHeader As Color = Color.FromArgb(64, 64, 64)               ' رؤوس الأعمدة
    '    Dim highlightColor As Color = Color.FromArgb(0, 122, 204)          ' لون الصف المحدد
    '    Dim textColor As Color = Color.Gainsboro                           ' النصوص العادية

    '    dgv.BackgroundColor = darkBackground
    '    dgv.RowsDefaultCellStyle.BackColor = darkRow
    '    dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAltRow
    '    dgv.DefaultCellStyle.ForeColor = textColor
    '    dgv.GridColor = Color.FromArgb(80, 80, 80)

    '    ' ------------------------------
    '    ' 3. تنسيق الأعمدة والعناوين
    '    ' ------------------------------
    '    With dgv
    '        .Columns.Clear()

    '        ' إضافة الأعمدة المرئية
    '        .Columns.Add("ColProductID", "كود المنتج")
    '        .Columns.Add("ColProductName", "اسم المنتج")
    '        .Columns.Add("ColUnitName", "الوحدة")
    '        .Columns.Add("ColPrice", "سعر الوحدة")
    '        .Columns.Add("ColQuantity", "الكمية")
    '        .Columns.Add("ColTotal", "الإجمالي")

    '        ' إضافة الأعمدة المخفية (مفاتيح ومنطق الحساب)
    '        .Columns.Add("ColUnitID", "UnitID")
    '        .Columns.Add("ColFactor", "Factor")

    '        .Columns("ColUnitID").Visible = False
    '        .Columns("ColFactor").Visible = False

    '        ' 2. إضافة عمود الحذف (Button Column)
    '        Dim btnCol As New DataGridViewButtonColumn()
    '        btnCol.HeaderText = "حذف"
    '        btnCol.Text = "❌" ' أو "حذف"
    '        btnCol.Name = "ColDelete"
    '        btnCol.UseColumnTextForButtonValue = True
    '        .Columns.Add(btnCol)

    '        ' 3. التنسيق الاحترافي (إذا لم يكن جاهزاً)
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .MultiSelect = False
    '        .AllowUserToAddRows = False
    '        ' عرض الأعمدة
    '        .Columns("ColProductName").Width = 230
    '        .Columns("ColQuantity").Width = 160

    '        '' الترتيب
    '        '.Columns("ProductCode").DisplayIndex = 0
    '        '.Columns("ProductName").DisplayIndex = 1
    '        '.Columns("DisplayStockQuantity").DisplayIndex = 2
    '        '.Columns("BaseUnitName").DisplayIndex = 3
    '        '.Columns("MinQuantity").DisplayIndex = 4

    '        ' تنسيق الأرقام
    '        .Columns("ColPrice").DefaultCellStyle.Format = "N2"
    '        .Columns("ColTotal").DefaultCellStyle.Format = "N2"

    '        ' محاذاة النصوص
    '        For Each col As DataGridViewColumn In dgv.Columns
    '            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        Next

    '        ' ------------------------------
    '        ' 4. مظهر الرأس والصفوف
    '        ' ------------------------------
    '        dgv.RowTemplate.Height = 32
    '        dgv.ColumnHeadersHeight = 45


    '        ' رؤوس الأعمدة
    '        dgv.ColumnHeadersDefaultCellStyle.BackColor = darkHeader
    '        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
    '        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.5!, FontStyle.Bold)
    '        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

    '        ' ------------------------------
    '        ' 5. الصف المحدد (Selection)
    '        ' ------------------------------
    '        dgv.DefaultCellStyle.SelectionBackColor = highlightColor
    '        dgv.DefaultCellStyle.SelectionForeColor = Color.White
    '        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 10.5!)

    '        ' ------------------------------
    '        ' 6. تحسين الشكل العام
    '        ' ------------------------------
    '        dgv.RowHeadersVisible = False
    '        dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
    '    End With
    'End Sub

    Private Sub SetupDataGridView(ByVal dgv As DataGridView)

        dgv.AllowUserToAddRows = False
        'dgv.AllowUser = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False

        ThemeHelper.ApplyDataGridViewTheme(dgv, ThemeManager.Instance.CurrentPalette)

        With dgv

            .Columns.Clear()
            .Columns.Add("ColProductID", "ID المنتج")
            .Columns.Add("ColProduct_Code", "كود المنتج")
            .Columns.Add("ColProductName", "اسم المنتج")
            .Columns.Add("ColUnitName", "الوحدة")
            .Columns.Add("ColPrice", "سعر الشراء")
            Dim ColQtyMinus As New DataGridViewButtonColumn()
            ColQtyMinus.HeaderText = ""
            ColQtyMinus.Text = "➖"
            ColQtyMinus.Name = "ColQtyMinus"
            ColQtyMinus.Width = 5
            ColQtyMinus.UseColumnTextForButtonValue = True
            .Columns.Add(ColQtyMinus)
            .Columns.Add("ColQuantity", "الكمية")
            Dim ColQtyPlus As New DataGridViewButtonColumn()
            ColQtyPlus.HeaderText = ""
            ColQtyPlus.Text = "➕"
            ColQtyPlus.Name = "ColQtyPlus"
            ColQtyPlus.Width = 5
            ColQtyPlus.UseColumnTextForButtonValue = True
            .Columns.Add(ColQtyPlus)
            .Columns.Add("ColTotal", "الإجمالي")

            .Columns.Add("ColUnitID", "UnitID")
            .Columns.Add("ColFactor", "Factor")

            .Columns("ColProductID").Visible = False
            .Columns("ColUnitID").Visible = False
            .Columns("ColFactor").Visible = False

            Dim btnCol As New DataGridViewButtonColumn()
            btnCol.HeaderText = "حذف"
            btnCol.Text = "❌"
            btnCol.Name = "ColDelete"
            btnCol.UseColumnTextForButtonValue = True
            .Columns.Add(btnCol)

            .Columns("ColProductName").Width = 230
            .Columns("ColQuantity").Width = 160

            .Columns("ColPrice").DefaultCellStyle.Format = "N2"
            .Columns("ColTotal").DefaultCellStyle.Format = "N2"

            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            dgv.RowTemplate.Height = 32
            dgv.ColumnHeadersHeight = 45

            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            dgv.DefaultCellStyle.Font = New Font("Segoe UI", 12.0!)

            dgv.RowHeadersVisible = False
            dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

        End With

    End Sub



    Private Function OpenConnection() As SqlConnection
        Dim cn As New SqlConnection(ConnectionString)
        cn.Open()
        Return cn
    End Function

    Private Sub getnewInvoiceID()
        Try
            Using cn = OpenConnection()
                Using cmd As New SqlCommand(
                    "SELECT ISNULL(MAX(Invoice_Code),0)+1 AS NextInv FROM Purchase_Header;", cn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        txt_Invoice_ID.Text = Convert.ToInt32(result).ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("خطأ في حساب رقم الفاتورة: " & ex.Message)
        End Try
    End Sub

End Class