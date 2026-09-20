Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Text
Imports System.Web.UI.WebControls
Imports DevExpress.Utils.Behaviors.Common
Imports DevExpress.XtraEditors
Imports DocumentFormat.OpenXml.ExtendedProperties
Imports Guna.UI2.WinForms
Imports System.Drawing
Imports System.Runtime.InteropServices
Public Class Sales_Returns

    Dim x, y As Integer
    Dim newpoint As New Point
    Dim manager As New temp_manager()
    Dim formattedDate As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    Public SelectedProductId As Integer = 0
    Public CurrentConversionFactor As Decimal = 0D
    Public CurrentSalePrice As Decimal = 0D
    Private CurrentUnitID As Integer = 0
    Private WithEvents Timer1 As New Timer()

    '----------------------------------------------------
    ' أزرار وإعدادات الفورم
    '----------------------------------------------------

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    ' تحريك الفورم
    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    '----------------------------------------------------
    ' عند تحميل الفورم
    '----------------------------------------------------

    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


        Timer1.Interval = 1000
        Timer1.Start()
        UpdateDateTime()
        Timer2.Interval = 1000
        Timer2.Enabled = True
        loadlogininfo()
        SetupDataGridView(Me.DataGridView1)
        ' [FIX] تفعيل DoubleBuffered
        EnableDoubleBuffer(Me.DataGridView1)
        newInvoiceID()
        cleartxts()
        txt_Customer_Name.Focus()

        AddHandler lstNameSuggestions.SelectedIndexChanged,
            Sub(s, ev)
                manager.lstNameSuggestions_SelectedIndexChanged(
                    s, ev,
                    txtProductNameSearch, SelectedProductId, lstCodeSuggestions, txtProductCodeSearch, cmbUnit, txtSalePrice, txtQuantity
                )
            End Sub


        ' البحث بالاسم
        AddHandler txtProductNameSearch.TextChanged,
            Sub(s, ev)
                manager.txtProductNameSearch_TextChanged(s, ev, lstNameSuggestions)
            End Sub
        lstCodeSuggestions.Visible = False
        lstNameSuggestions.Visible = False


        ' عند تغيير الوحدة
        AddHandler cmbUnit.SelectedIndexChanged,
            Sub(s, ev)
                manager.cmbUnit_SelectedIndexChanged(
                    s,
                    ev,
                    txtQuantity,
                    txt_totelProduct,
                    txtSalePrice,
                    CurrentConversionFactor,  ' <--- يتم تمريره كمرجع
                    CurrentSalePrice,         ' <--- يتم تمريره كمرجع
                    CurrentUnitID             ' <--- يتم تمريره كمرجع
                )
            End Sub



        txtDiscount.Text = 0
        txt_totelProduct.Text = 0
    End Sub

    '----------------------------------------------------
    ' تفريغ الحقول
    '----------------------------------------------------

    Private Sub cleartxts()

        newInvoiceID()

        txtProductCodeSearch.Clear()
        txtProductNameSearch.Clear()
        cmbUnit.DataSource = Nothing
        cmbUnit.Items.Clear()

        txt_notes.Clear()
        txtSalePrice.Clear()
        txtQuantity.Clear()
        txt_totelProduct.Clear()

        txtTotalRequired.Clear()
        txtDiscount.Clear()
        txtTotalAfterDiscount.Clear()
        txtPaid.Clear()
        txtRemaining.Clear()

        txt_Customer_Code.Clear()
        txt_Customer_Name.Clear()
        txt_Customer_Balance.Clear()

        cmb_Pay.SelectedIndex = 0

        txt_Customer_Code.TabIndex = 1
        txt_Customer_Name.TabIndex = 2
        lstSuggestions.TabIndex = 3

        cmbUnit.TextAlign = HorizontalAlignment.Center
        txtSalePrice.TextAlign = HorizontalAlignment.Center
        txtQuantity.TextAlign = HorizontalAlignment.Center
        txt_totelProduct.TextAlign = HorizontalAlignment.Center

    End Sub

    '----------------------------------------------------
    ' تهيئة الداتا جريد
    '----------------------------------------------------

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
            .Columns.Add("ColPrice", "سعر البيع")
            .Columns.Add("ColQuantity", "الكمية")
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

            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.5!, FontStyle.Bold)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            dgv.DefaultCellStyle.Font = New Font("Segoe UI", 10.5!)

            dgv.RowHeadersVisible = False
            dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

        End With

    End Sub
    '----------------------------------------------------
    ' استقبال الباركود وتعبئة بيانات المنتج
    '----------------------------------------------------

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
            Dim dgv As DataGridView = Me.DataGridView1

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
            Dim dtUnit As DataTable = manager.GetUnitByBarcode(barcodeValue)

            If dtUnit.Rows.Count = 1 Then

                Dim row As DataRow = dtUnit.Rows(0)

                SelectedProductId = row("Product_ID").ToString()
                txtProductNameSearch.Text = row("Product_Name").ToString()
                If lstNameSuggestions.Items.Count > 0 Then
                    lstNameSuggestions.SelectedIndex = 0
                End If
                'txtProductCodeSearch.Text = row("Product_Code").ToString()
                cmbUnit.Text = row("Unit_Name").ToString()
                txtSalePrice.Text = row("Sale_Price").ToString()
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



    '----------------------------------------------------
    ' رقم الفاتورة الجديد
    '----------------------------------------------------

    Private Sub newInvoiceID()

        Dim newInvoiceID As Integer

        Try
            Connect()

            Dim query As String = "
                SELECT ISNULL(Invoice_ID, 0) 
                FROM SalesHeader 
                WHERE Invoice_ID IS NOT NULL
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

    '----------------------------------------------------
    ' التاريخ والوقت
    '----------------------------------------------------

    Private Sub UpdateDateTime()

        Dim now As DateTime = DateTime.Now
        Dim arCulture As New CultureInfo("ar-EG")

        Dim timeText As String = now.ToString("tt hh:mm:ss", arCulture)
        Dim dayName As String = now.ToString("dddd", arCulture)
        Dim dayNumber As String = now.ToString("d", arCulture)
        Dim monthName As String = now.ToString("MMMM", arCulture)
        Dim yearNumber As String = now.ToString("yyyy", arCulture)

        Dim dateText As String = $"{dayName} ، {dayNumber} {monthName} {yearNumber} م"

        lblTime.Text = timeText
        lblDate.Text = dateText

    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        cleartxts()
    End Sub

    '----------------------------------------------------
    ' بحث العميل بالكود
    '----------------------------------------------------

    Private Sub btn_search_Customer_ID_Click(sender As Object, e As EventArgs) _
        Handles btn_search_Customer_ID.Click

        If txt_Customer_Code.TextLength = 0 Then
            MessageBox.Show("من فضلك ادخل كود العميل",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Connect()

            Dim query As String = "
                SELECT CustomerName, CurrentBalance
                FROM Customers
                WHERE CustomerCode = @CustomerCode
            "

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@CustomerCode", txt_Customer_Code.Text)

                Using reader As SqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        txt_Customer_Name.Text = reader("CustomerName").ToString()
                        txt_Customer_Balance.Text = reader("CurrentBalance").ToString()

                    Else
                        MessageBox.Show("العميل غير موجود",
                                        "تنبيه",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)

                        txt_Customer_Name.Clear()
                        txt_Customer_Balance.Clear()
                    End If

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show("خطأ أثناء جلب بيانات العميل: " & ex.Message,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Finally
            Disconnect()
        End Try

    End Sub

    Private Sub txt_Customer_Code_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txt_Customer_Code.KeyDown

        If e.KeyCode = Keys.Enter Then
            btn_search_Customer_ID.PerformClick()
        End If

    End Sub

    '----------------------------------------------------
    ' البحث بالاسم + الاقتراحات
    '----------------------------------------------------

    Private Sub txt_Customer_Name_TextChanged(sender As Object, e As EventArgs) _
        Handles txt_Customer_Name.TextChanged

        Dim keyword As String = txt_Customer_Name.Text.Trim()

        lstSuggestions.Items.Clear()

        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            Exit Sub
        End If

        Dim suggestions = GetSuggestions(keyword)

        If suggestions.Count > 0 Then
            lstSuggestions.Items.AddRange(suggestions.ToArray())
            lstSuggestions.Visible = True
        Else
            lstSuggestions.Visible = False
        End If

    End Sub

    Private Function GetSuggestions(keyword As String) As List(Of String)

        Dim suggestions As New List(Of String)()

        Try
            Connect()

            Dim query As String = "
                SELECT CustomerName 
                FROM Customers 
                WHERE CustomerName LIKE @keyword
            "

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        suggestions.Add(reader("CustomerName").ToString())
                    End While
                End Using

            End Using

        Catch ex As Exception

        Finally
            Disconnect()
        End Try

        Return suggestions

    End Function

    '----------------------------------------------------
    ' بحث العميل بالاسم من زر البحث
    '----------------------------------------------------

    Private Sub btn_search_Customer_name_Click(sender As Object, e As EventArgs) _
        Handles btn_search_Customer_name.Click

        If txt_Customer_Name.TextLength = 0 Then
            MessageBox.Show("من فضلك ادخل اسم العميل",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Connect()

            Dim query As String = "
                SELECT CustomerID, CustomerCode, CustomerName, CurrentBalance, 
                       CreditLimit, IsActive
                FROM dbo.Customers 
                WHERE CustomerName = @CustomerName
            "

            Using cmd As New SqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@CustomerName", txt_Customer_Name.Text)

                Using reader As SqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then

                        txt_Customer_Code.Text = reader("CustomerCode").ToString()
                        txt_Customer_Balance.Text = reader("CurrentBalance").ToString()

                    Else

                        MessageBox.Show("العميل غير موجود",
                                        "تنبيه",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)

                        txt_Customer_Code.Clear()
                        txt_Customer_Balance.Clear()

                    End If

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show("خطأ أثناء جلب بيانات العميل: " & ex.Message,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Finally
            Disconnect()

        End Try

    End Sub

    '----------------------------------------------------
    ' اختصارات لوحة المفاتيح
    '----------------------------------------------------

    Private Sub Sales_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles MyBase.KeyDown

        If e.Control AndAlso e.KeyCode = Keys.F Then
            e.SuppressKeyPress = True
            e.Handled = True
            txt_Customer_Name.Focus()
        End If

        If (e.Alt AndAlso e.KeyCode = Keys.F4) OrElse (e.KeyCode = Keys.Escape) Then
            e.Handled = True
            Me.Close()
        End If

        If (e.Control AndAlso e.KeyCode = Keys.N) OrElse e.KeyCode = Keys.F2 Then
            btnSaveInvoice.PerformClick()
        End If

        Select Case e.KeyCode

            Case Keys.F1

                MessageBox.Show(
                    "الاختصارات المتاحة:" & vbCrLf &
                    "F2 / Ctrl+N : حفظ الفاتورة" & vbCrLf &
                    "F8 : استدعاء فاتورة مبيعات بالرقم" & vbCrLf &
                    "F6 : مسح الحقول" & vbCrLf &
                    "Ctrl+F : بحث عن العميل" & vbCrLf &
                    "Esc : خروج",
                    "دليل الاختصارات",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            Case Keys.F8
                Dim invNum = InputBox("أدخل رقم فاتورة المبيعات الأصلية (مثال: 1 أو رقم الفاتورة) لاسترجاع أصنافها:", "استدعاء فاتورة مبيعات")
                If Not String.IsNullOrWhiteSpace(invNum) Then
                    LoadOriginalInvoiceForReturn(invNum)
                End If

            Case Keys.F6
                cleartxts()

        End Select

    End Sub

    ' =========================================================
    ' استدعاء فاتورة مبيعات مطعم أصلية واسترجاع أصنافها للمرتجع
    ' =========================================================
    Public Sub LoadOriginalInvoiceForReturn(invNum As String)
        If String.IsNullOrWhiteSpace(invNum) Then Return
        Try
            Dim repo As New POSRepository(DBModule.ConnectionString)
            Dim inv = repo.GetInvoiceByNumber(invNum.Trim())
            If inv IsNot Nothing Then
                DataGridView1.Rows.Clear()

                ' جلب وتعبئة بيانات العميل
                If inv.CustomerID.HasValue AndAlso inv.CustomerID.Value > 0 Then
                    Dim cust = repo.GetCustomerByID(inv.CustomerID.Value)
                    If cust IsNot Nothing Then
                        txt_Customer_Code.Text = cust.CustomerCode
                        txt_Customer_Name.Text = cust.CustomerName
                        txt_Customer_Balance.Text = cust.CurrentBalance.ToString("N2")
                    End If
                Else
                    txt_Customer_Code.Text = "CASH"
                    txt_Customer_Name.Text = "عميل نقدي"
                    txt_Customer_Balance.Text = "0.00"
                End If

                txtDiscount.Text = inv.DiscountAmount.ToString("N2")
                txt_notes.Text = "مرتجع مبيعات للفاتورة الأصلية رقم " & inv.InvoiceNumber

                For Each det In inv.Details
                    Dim rowIdx As Integer = DataGridView1.Rows.Add()
                    Dim r = DataGridView1.Rows(rowIdx)
                    r.Cells("ColProductID").Value = det.ProductID
                    r.Cells("ColProduct_Code").Value = det.ProductID.ToString()
                    r.Cells("ColProductName").Value = det.ProductName & If(Not String.IsNullOrEmpty(det.SizeName), " (" & det.SizeName & ")", "")
                    r.Cells("ColUnitName").Value = If(Not String.IsNullOrEmpty(det.SizeName), det.SizeName, "قطعة")
                    r.Cells("ColPrice").Value = det.UnitPrice
                    r.Cells("ColQuantity").Value = det.Quantity
                    r.Cells("ColTotal").Value = det.TotalPrice
                    r.Cells("ColUnitID").Value = 1
                    r.Cells("ColFactor").Value = 1
                Next

                UpdateInvoiceTotals()
                MessageBox.Show($"تم استرجاع أصناف الفاتورة [{inv.InvoiceNumber}] بنجاح، يرجى حذف أي أصناف لا يرغب العميل في إرجاعها أو تعديل الكميات.", "نجاح الاسترجاع", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("لم يتم العثور على فاتورة مبيعات مسجلة بهذا الرقم!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء جلب الفاتورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '----------------------------------------------------
    ' الاقتراحات للمنتجات
    '----------------------------------------------------

    Private Function GetSuggestions_Prouduct(keyword As String) As List(Of String)

        Dim suggestions As New List(Of String)()

        Using Conn
            Connect()

            Dim query As String = "
                SELECT Product_Name 
                FROM Products 
                WHERE Product_Name LIKE @keyword
            "

            Dim cmd As New SqlCommand(query, Conn)
            cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")

            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                suggestions.Add(reader("Product_Name").ToString())
            End While

        End Using

        Disconnect()

        Return suggestions

    End Function

    'Private Sub txtProductNameSearch_TextChanged(sender As Object, e As EventArgs) _
    '    Handles txtProductNameSearch.TextChanged

    '    'Dim keyword As String = txtProductNameSearch.Text.Trim()

    '    'lstNameSuggestions.Items.Clear()

    '    'If keyword.Length < 1 Then
    '    '    lstNameSuggestions.Visible = False
    '    '    Exit Sub
    '    'End If

    '    'Dim suggestions = GetSuggestions_Prouduct(keyword)

    '    'If suggestions.Count > 0 Then
    '    '    lstNameSuggestions.Items.AddRange(suggestions.ToArray())
    '    '    lstNameSuggestions.Visible = True
    '    'Else
    '    '    lstNameSuggestions.Visible = False
    '    'End If

    'End Sub

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txt_Customer_Name.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
            btn_search_Customer_name.PerformClick()
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        sale_p_product()
    End Sub

    Private Sub lbl_user_name_MouseDown(sender As Object, e As MouseEventArgs) Handles lblTime.MouseDown, lblDate.MouseDown, lbl_user_name.MouseDown, Label14.MouseDown

    End Sub

    Private Sub sale_p_product()
        ' نحاول نحسب الناتج فقط لما تكون القيم صحيحة رقمياً
        Dim quantity As Decimal
        Dim price As Decimal

        ' التحقق من أن القيم رقمية باستخدام TryParse
        If Decimal.TryParse(txtQuantity.Text, quantity) AndAlso Decimal.TryParse(txtSalePrice.Text, price) Then
            txt_totelProduct.Text = (price * quantity).ToString("0.##")
        Else
            ' لو القيم غير صالحة، نخلي الناتج فاضي أو صفر
            txt_totelProduct.Text = ""
        End If
    End Sub
    Private Sub lbl_user_name_MouseMove(sender As Object, e As MouseEventArgs) Handles lblTime.MouseMove, lblDate.MouseMove, lbl_user_name.MouseMove, Label14.MouseMove

    End Sub

    Private Sub cmbUnit_TextChanged(sender As Object, e As EventArgs) Handles cmbUnit.TextChanged
        sale_p_product()
    End Sub

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
    Private Sub ClearProductFields()
        newInvoiceID()
        txtProductCodeSearch.Clear()
        txtProductNameSearch.Clear()
        cmbUnit.DataSource = Nothing
        cmbUnit.Items.Clear()
        txtSalePrice.Clear()
        txtQuantity.Clear()
        txt_totelProduct.Clear()


        txtProductCodeSearch.TextAlign = HorizontalAlignment.Center
        txtProductNameSearch.TextAlign = HorizontalAlignment.Center
        cmbUnit.TextAlign = HorizontalAlignment.Center
        cmbUnit.TextAlign = HorizontalAlignment.Center
        txtSalePrice.TextAlign = HorizontalAlignment.Center
        txtQuantity.TextAlign = HorizontalAlignment.Center
        txt_totelProduct.TextAlign = HorizontalAlignment.Center
    End Sub

    ' في FormSales.vb
    Private Sub UpdateExistingRowOrAdd()

        Dim qtyToAdd As Integer
        If Not Integer.TryParse(txtQuantity.Text.Trim(), qtyToAdd) Then
            MessageBox.Show("❌ الكمية غير صالحة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim dgv As DataGridView = Me.DataGridView1
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

        ' الكمية الإجمالية (بدون أي تحقق من مخزون)
        Dim totalQtyRequired As Integer = oldQty + qtyToAdd

        ' -----------------------------------------------------
        ' 2) لو الصف موجود → حدّثه
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
        ' 3) لو الصف غير موجود → أضفه كصف جديد
        ' -----------------------------------------------------
        dgv.Rows.Add(
        SelectedProductId,
        currentProduct_Code,
        currentProductName,
        currentUnitName,
        CurrentSalePrice.ToString("N2"),
        qtyToAdd.ToString("N2"),
        totalLineAmount.ToString("N2"),
        CurrentUnitID,
        CurrentConversionFactor
    )

    End Sub


    'Public Sub ProcessBarcodeData(code As String)
    '    Dim Barcode As String = ""
    '    Try
    '        ' قراءة كل البيانات الموجودة في المخزن المؤقت لمنفذ COM
    '        Barcode = code

    '        If Barcode.Length > 0 Then
    '            ' 1. تمرير الباركود للبحث (البارت الأول من الدالة)
    '            If SearchAndFillProductByBarcode(Barcode) Then

    '                ' 2. تعيين الكمية لـ 1
    '                txtQuantity.Text = "1"

    '                ' 3. النقر على زر الإضافة برمجياً
    '                btn_add_product.PerformClick()
    '            End If

    '            ' مسح الباركود من حقل البحث بعد الاستخدام
    '            Me.txtProductNameSearch.Clear()

    '        End If

    '    Catch ex As Exception
    '        ' تجاهل أخطاء المهلة البسيطة (ReadTimeout)
    '    End Try
    'End Sub

    Private Sub UpdateInvoiceTotals()
        Dim GrandTotal As Decimal = 0D

        ' جمع إجمالي جميع بنود الفاتورة
        For Each row As DataGridViewRow In DataGridView1.Rows
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' التأكد من أن المستخدم نقر على عمود الحذف (ColDelete)
        If e.ColumnIndex = DataGridView1.Columns("ColDelete").Index AndAlso e.RowIndex >= 0 Then

            Dim ProductNameToDelete As String = DataGridView1.Rows(e.RowIndex).Cells("ColProductName").Value.ToString()

            If MessageBox.Show($"هل أنت متأكد من حذف الصنف ({ProductNameToDelete}) من الفاتورة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                ' 1. حذف الصف
                DataGridView1.Rows.RemoveAt(e.RowIndex)

                ' 2. تحديث الإجماليات
                UpdateInvoiceTotals()

                MessageBox.Show("تم حذف الصنف.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtProductNameSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductNameSearch.KeyDown
        If e.KeyCode = Keys.Down Then
            lstNameSuggestions.Focus()
        End If
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_add_product.PerformClick()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        UpdateDateTime()
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
        'Select Case cmb_Pay.Text
        '    Case "كاش"
        '        txtRemaining.Visible = True
        '        txtPaid.Visible = True
        '        lblRemaining.Visible = True
        '        lblPaid.Visible = True
        '    Case "نقدي"
        '        txtRemaining.Visible = True
        '        txtPaid.Visible = True
        '        lblRemaining.Visible = True
        '        lblPaid.Visible = True

        '    Case "آجل"
        '        txtPaid.Text = 0
        '        txtPaid.Visible = False
        '        lblPaid.Visible = False

        '    Case Else
        '        txtPaid.Visible = False
        '        lblPaid.Visible = False
        'End Select
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




    'Private Sub btnSaveInvoice_Click(sender As Object, e As EventArgs) Handles btnSaveInvoice.Click
    '    ' في FormSales.vb

    '    ' ----------------------------------------------------
    '    ' 1. التحقق المبدئي والحصول على المتغيرات
    '    ' ----------------------------------------------------

    '    ' التحقق من وجود ID العميل
    '    If String.IsNullOrWhiteSpace(txt_Customer_Code.Text) Or String.IsNullOrWhiteSpace(txt_Customer_Name.Text) Or String.IsNullOrWhiteSpace(txt_Customer_Balance.Text) Then
    '        MessageBox.Show("الرجاء إدخال التأكد من بيانات العميل اولا.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txt_Customer_Name.Focus()
    '        Exit Sub
    '    End If

    '    If Me.DataGridView1.Rows.Count = 0 Then
    '        MessageBox.Show("يجب إضافة أصناف للفاتورة أولاً.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    ' جلب كود العميل
    '    Dim CustomerCode As String = txt_Customer_Code.Text.Trim()
    '    Dim CustomerID As Integer = 0

    '    Try
    '        Connect()
    '        Dim query As String = "SELECT CustomerID FROM Customers WHERE CustomerCode = @ID"
    '        Using cmd As New SqlCommand(query, Conn)
    '            cmd.Parameters.AddWithValue("@ID", CustomerCode)
    '            Dim obj = cmd.ExecuteScalar()
    '            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
    '                Integer.TryParse(obj.ToString(), CustomerID)
    '            Else
    '                MessageBox.Show("لم يتم العثور على عميل بهذا الكود.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Exit Sub
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("حدث خطأ أثناء التحقق من العميل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    Finally
    '        Disconnect()
    '    End Try

    '    ' جلب القيم من الواجهة
    '    Dim totalBeforeDiscount As Decimal = 0D
    '    Decimal.TryParse(txtTotalRequired.Text, totalBeforeDiscount)

    '    Dim totalAfterDiscount As Decimal = 0D
    '    Decimal.TryParse(txtTotalAfterDiscount.Text, totalAfterDiscount)

    '    Dim discountValue As Decimal = 0D
    '    Decimal.TryParse(txtDiscount.Text, discountValue)

    '    Dim paidAmount As Decimal = 0D
    '    Decimal.TryParse(txtPaid.Text, paidAmount)

    '    Dim Remaining As Decimal = 0D
    '    Decimal.TryParse(txtRemaining.Text, Remaining)

    '    Dim notest As String = Convert.ToString(txt_notes.Text)
    '    Dim userloginid As Integer = Session.CurrentUserID
    '    Dim usernamelogin As String = Convert.ToString(lbl_user_name.Text.Trim())
    '    Dim paymentType As String = cmb_Pay.Text.Trim()

    '    ' ----------------------------------------------------
    '    ' 2. التحقق من المخزون قبل المعاملة
    '    ' ----------------------------------------------------
    '    ' (اختياري – لو عندك دالة تحقق من المخزون قبل التنفيذ، يتم استدعاؤها هنا)

    '    Connect()
    '    Dim transaction As SqlTransaction = Conn.BeginTransaction()
    '    Dim NewInvoiceID As Integer = 0

    '    Try
    '        ' -------------------------------------------
    '        ' 3. إدخال الفاتورة في SalesHeader
    '        ' -------------------------------------------
    '        Dim query_header As String = "
    '            INSERT INTO SalesHeader (Invoice_Date,Invoice_type, Customer_ID, User_ID, User_Name, Total_Amount, Discount_Value, Net_Amount, Amount_Paid, Remaining, Payment_Method, Notes)
    '            VALUES (GETDATE(),@Invoice_type, @Customer_ID, @User_ID, @User_Name, @Total_Amount, @Discount_Value, @Net_Amount, @Amount_Paid, @Remaining, @Payment_Method, @Notes);
    '            SELECT SCOPE_IDENTITY();"

    '        Using cmd_header As New SqlCommand(query_header, Conn, transaction)
    '            cmd_header.Parameters.AddWithValue("@Invoice_type", "فاتورة مرتجع بيع")
    '            cmd_header.Parameters.AddWithValue("@Customer_ID", CustomerID)
    '            cmd_header.Parameters.AddWithValue("@User_ID", userloginid)
    '            cmd_header.Parameters.AddWithValue("@User_Name", usernamelogin)
    '            cmd_header.Parameters.AddWithValue("@Total_Amount", totalAfterDiscount)
    '            cmd_header.Parameters.AddWithValue("@Discount_Value", discountValue)
    '            cmd_header.Parameters.AddWithValue("@Net_Amount", totalBeforeDiscount)
    '            cmd_header.Parameters.AddWithValue("@Amount_Paid", paidAmount)
    '            cmd_header.Parameters.AddWithValue("@Remaining", Remaining)
    '            cmd_header.Parameters.AddWithValue("@Payment_Method", "")
    '            cmd_header.Parameters.AddWithValue("@Notes", notest)

    '            Dim obj = cmd_header.ExecuteScalar()
    '            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
    '                Integer.TryParse(obj.ToString(), NewInvoiceID)
    '            Else
    '                Throw New Exception("فشل إنشاء رقم الفاتورة (SCOPE_IDENTITY).")
    '            End If
    '        End Using

    '        ' -------------------------------------------
    '        ' 4. إدخال تفاصيل الفاتورة وتحديث المخزون
    '        ' -------------------------------------------
    '        For Each row As DataGridViewRow In Me.DataGridView1.Rows
    '            If row.IsNewRow Then Continue For

    '            Dim PID As Integer = 0
    '            Integer.TryParse(Convert.ToString(row.Cells("ColProductID").Value), PID)

    '            Dim UnitID As Integer = 0
    '            Integer.TryParse(Convert.ToString(row.Cells("ColUnitID").Value), UnitID)

    '            Dim SalePrice As Decimal = 0D
    '            Decimal.TryParse(Convert.ToString(row.Cells("ColPrice").Value), SalePrice)

    '            Dim QtySold As Decimal = 0D
    '            Decimal.TryParse(Convert.ToString(row.Cells("ColQuantity").Value), QtySold)

    '            Dim TotalLine As Decimal = 0D
    '            Decimal.TryParse(Convert.ToString(row.Cells("ColTotal").Value), TotalLine)

    '            Dim Factor As Decimal = 1D
    '            Decimal.TryParse(Convert.ToString(row.Cells("ColFactor").Value), Factor)

    '            Dim QtyBaseToDeduct As Decimal = QtySold * Factor

    '            ' تفاصيل الصنف
    '            Dim query_details As String = "
    'INSERT INTO SalesDetails (Invoice_ID, Product_ID, ProductUnit_ID, Quantity_Sold, Sale_Price_Per_Unit, Total_Line_Amount)
    'VALUES (@InvID, @PID, @UnitID, @QtySold, @Price, @TotalLine);"

    '            Using cmd_details As New SqlCommand(query_details, Conn, transaction)
    '                cmd_details.Parameters.AddWithValue("@InvID", NewInvoiceID)
    '                cmd_details.Parameters.AddWithValue("@PID", PID)
    '                cmd_details.Parameters.AddWithValue("@UnitID", UnitID)
    '                cmd_details.Parameters.AddWithValue("@QtySold", QtySold)
    '                cmd_details.Parameters.AddWithValue("@Price", SalePrice)
    '                cmd_details.Parameters.AddWithValue("@TotalLine", TotalLine)
    '                cmd_details.ExecuteNonQuery()
    '            End Using

    '            ' تحديث المخزون
    '            Dim query_stock_update As String = "
    'UPDATE Stock SET Quantity_OnHand = Quantity_OnHand + @DeductQty WHERE Product_ID = @PID;"
    '            Using cmd_stock_update As New SqlCommand(query_stock_update, Conn, transaction)
    '                cmd_stock_update.Parameters.AddWithValue("@DeductQty", QtyBaseToDeduct)
    '                cmd_stock_update.Parameters.AddWithValue("@PID", PID)
    '                cmd_stock_update.ExecuteNonQuery()
    '            End Using
    '        Next

    '        ' -------------------------------------------
    '        ' 5. التحقق من حد الائتمان قبل تحديث الرصيد
    '        ' -------------------------------------------
    '        Dim BalanceBefore As Decimal = 0D
    '        Dim CreditLimit As Decimal = 0D

    '        ' قراءة الرصيد وحد الائتمان قبل التحديث
    '        Dim qCustomerInfo As String = "SELECT ISNULL(CurrentBalance,0), ISNULL(CreditLimit,0) FROM Customers WHERE CustomerCode = @ID"
    '        Using cmdCust As New SqlCommand(qCustomerInfo, Conn, transaction)
    '            cmdCust.Parameters.AddWithValue("@ID", CustomerCode)
    '            Using rdr = cmdCust.ExecuteReader()
    '                If rdr.Read() Then
    '                    BalanceBefore = Convert.ToDecimal(rdr(0))
    '                    CreditLimit = Convert.ToDecimal(rdr(1))
    '                End If
    '            End Using
    '        End Using

    '        ' حساب الرصيد بعد الفاتورة
    '        Dim BalanceAfter As Decimal = BalanceBefore + Remaining
    '        ' التحقق من تجاوز الحد
    '        'If BalanceAfter > CreditLimit Then
    '        '    transaction.Rollback()
    '        '    MessageBox.Show("⚠️ لا يمكن حفظ الفاتورة لأن الرصيد بعد العملية سيتجاوز حد الائتمان المسموح به للعميل." &
    '        '                vbCrLf & $"حد الائتمان: {CreditLimit}" &
    '        '                vbCrLf & $"الرصيد الحالي: {BalanceBefore}" &
    '        '                vbCrLf & $"متبقي الفاتورة: {Remaining}" &
    '        '                vbCrLf & $"الرصيد بعد الفاتورة: {BalanceAfter}",
    '        '                "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        '    Exit Sub
    '        'End If

    '        ' -------------------------------------------
    '        ' 6. تحديث رصيد العميل بعد التأكد من الحد الائتماني
    '        ' -------------------------------------------
    '        If Remaining <> 0 Then
    '            Dim query_update_customer As String = "
    '    UPDATE Customers 
    '    SET CurrentBalance = ISNULL(CurrentBalance, 0) + @RemainingAmount
    '    WHERE CustomerCode = @CustomerCode;"
    '            Using cmd_update_customer As New SqlCommand(query_update_customer, Conn, transaction)
    '                cmd_update_customer.Parameters.AddWithValue("@RemainingAmount", totalBeforeDiscount)
    '                cmd_update_customer.Parameters.AddWithValue("@CustomerCode", CustomerCode)
    '                cmd_update_customer.ExecuteNonQuery()
    '            End Using
    '        End If

    '        ' -------------------------------------------
    '        ' 7. تأكيد المعاملة
    '        ' -------------------------------------------
    '        transaction.Commit()

    '        MessageBox.Show($"✅ تم حفظ الفاتورة رقم {NewInvoiceID} بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        cleartxts()

    '    Catch ex As Exception
    '        ' -------------------------------------------
    '        ' 8. التراجع عند الخطأ
    '        ' -------------------------------------------
    '        Try
    '            transaction.Rollback()
    '        Catch
    '        End Try

    '        MessageBox.Show("❌ فشل الحفظ. تم التراجع عن التغييرات. الخطأ: " & ex.Message,
    '                    "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Finally
    '        Disconnect()
    '    End Try

    'End Sub
    ' ========================================
    ' حفظ فاتورة مرتجع البيع
    ' ========================================
    Private Sub btnSaveReturnInvoice_Click(sender As Object, e As EventArgs) Handles btnSaveInvoice.Click
        ' --------------------------
        ' 1. التحقق من العميل وأصناف الفاتورة
        ' --------------------------
        If String.IsNullOrWhiteSpace(txt_Customer_Code.Text) OrElse
           String.IsNullOrWhiteSpace(txt_Customer_Name.Text) Then
            MessageBox.Show("الرجاء التأكد من بيانات العميل أولاً.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_Customer_Name.Focus()
            Exit Sub
        End If

        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("يجب إضافة أصناف للفاتورة أولاً.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim CustomerCode As String = txt_Customer_Code.Text.Trim()
        Dim CustomerID As Integer = GetCustomerID(CustomerCode)
        If CustomerID = 0 Then CustomerID = 1 ' افتراضي عميل نقدي

        ' --------------------------
        ' 2. جلب قيم الفاتورة بدقة
        ' --------------------------
        Dim totalBeforeDiscount As Decimal = ParseDecimal(txtTotalRequired.Text)
        Dim discountValue As Decimal = ParseDecimal(txtDiscount.Text)
        Dim totalAfterDiscount As Decimal = ParseDecimal(txtTotalAfterDiscount.Text)
        If totalAfterDiscount = 0 AndAlso totalBeforeDiscount > 0 Then
            totalAfterDiscount = totalBeforeDiscount - discountValue
        End If

        Dim paymentType As String = If(cmb_Pay.SelectedItem IsNot Nothing, cmb_Pay.SelectedItem.ToString(), "نقدي")
        Dim paidAmount As Decimal = ParseDecimal(txtPaid.Text)
        If paidAmount = 0 AndAlso paymentType <> "آجل" AndAlso totalAfterDiscount > 0 Then
            paidAmount = totalAfterDiscount
        End If
        Dim Remaining As Decimal = ParseDecimal(txtRemaining.Text)

        Dim notes As String = txt_notes.Text.Trim()
        Dim userID As Integer = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1)
        Dim userName As String = If(Not String.IsNullOrEmpty(Session.CurrentUserfullName), Session.CurrentUserfullName, lbl_user_name.Text.Trim())

        ' --------------------------
        ' 3. بدء المعاملة وحفظ البيانات متكاملة
        ' --------------------------
        Connect()
        Using transaction As SqlTransaction = Conn.BeginTransaction()
            Try
                ' إدخال الفاتورة في SalesHeader
                Dim NewInvoiceID As Integer = InsertReturnInvoiceHeader(CustomerID, totalBeforeDiscount, totalAfterDiscount, discountValue,
                                                                    paidAmount, Remaining, notes, userID, userName, paymentType, transaction)

                ' إدخال تفاصيل الفاتورة وتحديث المخزون والخامات
                InsertReturnInvoiceDetailsAndUpdateStock(NewInvoiceID, transaction)

                ' تحديث رصيد العميل إذا كان هناك آجل أو خصم من حسابه
                If Remaining > 0 OrElse paymentType = "آجل" Then
                    Dim creditRefund = If(Remaining > 0, Remaining, totalAfterDiscount)
                    UpdateCustomerBalance(CustomerCode, -creditRefund, transaction)
                End If

                ' تحديث إجمالي مرتجعات الوردية النشطة بالداتا بيز والذاكرة
                Dim queryShiftRefund As String = "UPDATE Shifts SET TotalRefunds = ISNULL(TotalRefunds, 0) + @Refund WHERE Status = 1;"
                Using cmdShift As New SqlCommand(queryShiftRefund, Conn, transaction)
                    cmdShift.Parameters.AddWithValue("@Refund", totalAfterDiscount)
                    cmdShift.ExecuteNonQuery()
                End Using

                If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                    ShiftSession.CurrentShift.TotalRefunds += totalAfterDiscount
                End If

                ' تسجيل حركة صرف نقدية من الخزينة لقاء المرتجع المدفوع كاش
                If paidAmount > 0 Then
                    Dim currentTreasuryID As Integer = 1
                    If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing AndAlso ShiftSession.CurrentShift.TreasuryID.HasValue AndAlso ShiftSession.CurrentShift.TreasuryID.Value > 0 Then
                        currentTreasuryID = ShiftSession.CurrentShift.TreasuryID.Value
                    End If

                    Dim queryTreasury As String = "
                        INSERT INTO TreasuryTransactions (TreasuryID, TransactionType, Amount, TransactionDate, Description, ShiftID, UserID, IsActive, IsDeleted)
                        VALUES (@TreasuryID, N'صرف', @Amount, GETDATE(), @Desc, @ShiftID, @UserID, 1, 0);
                    "
                    Using cmdTreasury As New SqlCommand(queryTreasury, Conn, transaction)
                        cmdTreasury.Parameters.AddWithValue("@TreasuryID", currentTreasuryID)
                        cmdTreasury.Parameters.AddWithValue("@Amount", paidAmount)
                        cmdTreasury.Parameters.AddWithValue("@Desc", "مرتجع مبيعات فاتورة #" & NewInvoiceID)
                        cmdTreasury.Parameters.AddWithValue("@ShiftID", If(ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, CType(DBNull.Value, Object)))
                        cmdTreasury.Parameters.AddWithValue("@UserID", userID)
                        cmdTreasury.ExecuteNonQuery()
                    End Using
                End If

                ' تأكيد المعاملة
                transaction.Commit()

                MessageBox.Show($"✅ تم حفظ فاتورة المرتجع رقم {NewInvoiceID} بنجاح وقيد الصرف في الوردية والخزينة.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cleartxts()

            Catch ex As Exception
                Try
                    transaction.Rollback()
                Catch
                End Try
                MessageBox.Show("❌ فشل الحفظ. تم التراجع عن التغييرات. الخطأ: " & ex.Message, "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' ========================================
    ' إدخال Header المرتجع
    ' ========================================
    Private Function InsertReturnInvoiceHeader(CustomerID As Integer, totalBeforeDiscount As Decimal, totalAfterDiscount As Decimal,
                                           discountValue As Decimal, paidAmount As Decimal, Remaining As Decimal,
                                           notes As String, userID As Integer, userName As String, paymentType As String,
                                           transaction As SqlTransaction) As Integer
        Dim NewInvoiceID As Integer = 0
        Dim query As String = "
        INSERT INTO SalesHeader (Invoice_type, Invoice_Date, Customer_ID, User_ID, User_Name, Total_Amount, Discount_Value, Net_Amount, Amount_Paid, Remaining, Payment_Method, Notes)
        VALUES (@Invoice_type, GETDATE(), @Customer_ID, @User_ID, @User_Name, @Total_Amount, @Discount_Value, @Net_Amount, @Amount_Paid, @Remaining, @Payment_Method, @Notes);
        SELECT SCOPE_IDENTITY();"

        Using cmd As New SqlCommand(query, Conn, transaction)
            cmd.Parameters.Add("@Invoice_type", SqlDbType.NVarChar).Value = "فاتورة مرتجع بيع"
            cmd.Parameters.Add("@Customer_ID", SqlDbType.Int).Value = CustomerID
            cmd.Parameters.Add("@User_ID", SqlDbType.Int).Value = userID
            cmd.Parameters.Add("@User_Name", SqlDbType.NVarChar).Value = userName
            cmd.Parameters.Add("@Total_Amount", SqlDbType.Decimal).Value = totalAfterDiscount
            cmd.Parameters.Add("@Discount_Value", SqlDbType.Decimal).Value = discountValue
            cmd.Parameters.Add("@Net_Amount", SqlDbType.Decimal).Value = totalBeforeDiscount
            cmd.Parameters.Add("@Amount_Paid", SqlDbType.Decimal).Value = paidAmount
            cmd.Parameters.Add("@Remaining", SqlDbType.Decimal).Value = Remaining
            cmd.Parameters.Add("@Payment_Method", SqlDbType.NVarChar).Value = paymentType
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes

            Dim obj = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Integer.TryParse(obj.ToString(), NewInvoiceID)
            Else
                Throw New Exception("فشل إنشاء رقم الفاتورة (SCOPE_IDENTITY).")
            End If
        End Using

        Return NewInvoiceID
    End Function

    ' ========================================
    ' إدخال التفاصيل وتحديث المخزون والخامات
    ' ========================================
    Private Sub InsertReturnInvoiceDetailsAndUpdateStock(NewInvoiceID As Integer, transaction As SqlTransaction)
        Dim currentStoreID As Integer = 1
        Integer.TryParse(SettingsManager.GetSettingOrDefault("CurrentStoreID", "1"), currentStoreID)

        For Each row In GetValidRows()
            Dim PID As Integer = Convert.ToInt32(row.Cells("ColProductID").Value)
            Dim UnitID As Integer = Convert.ToInt32(row.Cells("ColUnitID").Value)
            Dim SalePrice As Decimal = ParseDecimal(Convert.ToString(row.Cells("ColPrice").Value))
            Dim QtySold As Decimal = ParseDecimal(Convert.ToString(row.Cells("ColQuantity").Value))
            Dim TotalLine As Decimal = ParseDecimal(Convert.ToString(row.Cells("ColTotal").Value))
            Dim Factor As Decimal = ParseDecimal(Convert.ToString(row.Cells("ColFactor").Value))
            Dim QtyBaseToAdd As Decimal = QtySold * Factor

            ' إدخال تفاصيل الفاتورة
            Dim queryDetails As String = "
INSERT INTO SalesDetails (Invoice_ID, Product_ID, ProductUnit_ID, Quantity_Sold, Sale_Price_Per_Unit, Total_Line_Amount)
VALUES (@InvID, @PID, @UnitID, @QtySold, @Price, @TotalLine);"

            Using cmd As New SqlCommand(queryDetails, Conn, transaction)
                cmd.Parameters.Add("@InvID", SqlDbType.Int).Value = NewInvoiceID
                cmd.Parameters.Add("@PID", SqlDbType.Int).Value = PID
                cmd.Parameters.Add("@UnitID", SqlDbType.Int).Value = UnitID
                cmd.Parameters.Add("@QtySold", SqlDbType.Decimal).Value = QtySold
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = SalePrice
                cmd.Parameters.Add("@TotalLine", SqlDbType.Decimal).Value = TotalLine
                cmd.ExecuteNonQuery()
            End Using

            ' ==============================================
            ' 1. تحديث المخزون العام للمنتج
            ' ==============================================
            Dim queryStock As String = "
UPDATE Stock SET Quantity_OnHand = Quantity_OnHand + @QtyToAdd WHERE Product_ID = @PID;"

            Using cmdStock As New SqlCommand(queryStock, Conn, transaction)
                cmdStock.Parameters.Add("@QtyToAdd", SqlDbType.Decimal).Value = QtyBaseToAdd
                cmdStock.Parameters.Add("@PID", SqlDbType.Int).Value = PID
                cmdStock.ExecuteNonQuery()
            End Using

            ' ==============================================
            ' 2. استرجاع خامات الريسيبي للمطبخ/المخزن إن وجدت
            ' ==============================================
            Try
                InventoryDeductionManager.RestoreItemRecipe(Conn, transaction, currentStoreID, PID, Nothing, Nothing, QtySold, "RET-" & NewInvoiceID)
            Catch exRecipe As Exception
                Debug.WriteLine("RestoreItemRecipe error: " & exRecipe.Message)
            End Try

        Next
    End Sub

    ' ========================================
    ' تحديث رصيد العميل
    ' ========================================
    Private Sub UpdateCustomerBalance(CustomerCode As String, AmountToAdd As Decimal, transaction As SqlTransaction)
        Dim query As String = "
UPDATE Customers
SET CurrentBalance = ISNULL(CurrentBalance,0) + @Amount
WHERE CustomerCode = @CustomerCode;"

        Using cmd As New SqlCommand(query, Conn, transaction)
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = AmountToAdd
            cmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar).Value = CustomerCode
            cmd.ExecuteNonQuery()
        End Using
    End Sub
    Public Function ParseDecimal(value As Object) As Decimal
        If value Is Nothing Then Return 0
        Dim s As String = value.ToString().Trim()
        If String.IsNullOrWhiteSpace(s) Then Return 0
        Dim result As Decimal = 0
        Decimal.TryParse(s, result)
        Return result
    End Function
    Public Function GetValidRows() As List(Of DataGridViewRow)
        Dim rows As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For

            If row.Cells("ColProductID").Value IsNot Nothing AndAlso
           row.Cells("ColQuantity").Value IsNot Nothing Then
                rows.Add(row)
            End If
        Next
        Return rows
    End Function
    Public Function GetCustomerID(customerCode As String) As Integer

        Dim query As String = "SELECT CustomerID FROM Customers WHERE CustomerCode = @Code"
        Connect()

        Using cmd As New SqlCommand(query, Conn)
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = customerCode
            Dim obj = cmd.ExecuteScalar()

            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Return Convert.ToInt32(obj)
            End If
        End Using
        Return 0
    End Function

    '===========================
    '🧾 دالة طباعة فاتورة تجريبية
    '===========================
    Private Sub PrintTestInvoice()

        Dim doc As New Printing.PrintDocument
        AddHandler doc.PrintPage, AddressOf Me.PrintPageHandler

        Dim dlg As New PrintPreviewDialog
        dlg.Document = doc
        dlg.WindowState = FormWindowState.Maximized
        dlg.ShowDialog()

    End Sub

    '==========================================
    '🖨 الريندر الخاص بمحتوى الفاتورة على الورقة
    '==========================================
    Private Sub PrintPageHandler(sender As Object, e As Printing.PrintPageEventArgs)

        Dim g = e.Graphics
        Dim fontTitle As New Font("Arial", 16, FontStyle.Bold)
        Dim fontNormal As New Font("Arial", 12)
        Dim y As Integer = 40

        '-------------------------
        '🧾 رأس الفاتورة
        '-------------------------
        g.DrawString("فاتورة تجريبية", fontTitle, Brushes.Black, 250, y)
        y += 40

        g.DrawString("المستخدم: عمار أحمد", fontNormal, Brushes.Black, 40, y)
        y += 30

        g.DrawString("تاريخ: " & Date.Now.ToString("yyyy/MM/dd  hh:mm tt"), fontNormal, Brushes.Black, 40, y)
        y += 40

        g.DrawLine(Pens.Black, 40, y, 780, y)
        y += 20

        '-------------------------
        '📦 عناصر الفاتورة
        '-------------------------
        g.DrawString("الصنف", fontNormal, Brushes.Black, 40, y)
        g.DrawString("الكمية", fontNormal, Brushes.Black, 300, y)
        g.DrawString("السعر", fontNormal, Brushes.Black, 450, y)
        g.DrawString("الإجمالي", fontNormal, Brushes.Black, 600, y)
        y += 30

        g.DrawLine(Pens.Black, 40, y, 780, y)
        y += 20

        ' صنف تجريبي
        g.DrawString("منتج تجريبي رقم 1", fontNormal, Brushes.Black, 40, y)
        g.DrawString("2", fontNormal, Brushes.Black, 300, y)
        g.DrawString("150", fontNormal, Brushes.Black, 450, y)
        g.DrawString("300", fontNormal, Brushes.Black, 600, y)
        y += 30

        ' صنف تجريبي 2
        g.DrawString("منتج تجريبي رقم 2", fontNormal, Brushes.Black, 40, y)
        g.DrawString("1", fontNormal, Brushes.Black, 300, y)
        g.DrawString("200", fontNormal, Brushes.Black, 450, y)
        g.DrawString("200", fontNormal, Brushes.Black, 600, y)
        y += 40

        g.DrawLine(Pens.Black, 40, y, 780, y)
        y += 30

        '-------------------------
        '💰 الإجمالي النهائي
        '-------------------------
        g.DrawString("الإجمالي الكلي: 500 جنيه", fontTitle, Brushes.Black, 40, y)

    End Sub


    Public Sub PrintInvoice80mmProfessional(ByVal InvoiceID As Integer)

        ' ===== بيانات من الإعدادات =====
        Dim StoreName As String = If(SettingsManager.GetSetting("ShopName"), "سوبر ماركت الحمد والرضا")
        Dim Phone1 As String = If(SettingsManager.GetSetting("ShopPhone"), "")
        Dim Phone2 As String = If(SettingsManager.GetSetting("ShopPhone2"), "")
        Dim Address As String = If(SettingsManager.GetSetting("ShopAddress"), "")
        Dim FooterMsg As String = If(SettingsManager.GetSetting("FooterText"), "شكراً لتعاملكم معنا ❤")
        Dim DevSig As String = "تم التصميم بواسطة عمار احمد"

        ' ===== الخطوط =====
        Dim fBig As New Font("Tahoma", 16, FontStyle.Bold)
        Dim fBold As New Font("Tahoma", 12, FontStyle.Bold)
        Dim f11 As New Font("Tahoma", 11)
        Dim f11b As New Font("Tahoma", 11, FontStyle.Bold)

        ' ===== إعداد الطباعة =====
        Dim pd As New PrintDocument()
        pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
        pd.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5)

        AddHandler pd.PrintPage,
Sub(sender, e)

    Dim g = e.Graphics
    Dim Y As Integer = 5
    Dim pageW As Integer = e.PageBounds.Width

    ' =======================
    ' دوال جاهزة RTL + Center
    ' =======================

    Dim fmtR As New StringFormat With {
        .Alignment = StringAlignment.Far,
        .FormatFlags = StringFormatFlags.DirectionRightToLeft
    }

    Dim fmtC As New StringFormat With {
        .Alignment = StringAlignment.Center,
        .FormatFlags = StringFormatFlags.DirectionRightToLeft
    }

    Dim Center = Sub(txt As String, f As Font)
                     g.DrawString(txt, f, Brushes.Black,
                                  New RectangleF(0, Y, pageW, f.Height + 6),
                                  fmtC)
                     Y += f.GetHeight() + 6
                 End Sub

    Dim RightAligned = Sub(txt As String, f As Font)
                           g.DrawString(txt, f, Brushes.Black,
                                        New RectangleF(0, Y, pageW - 10, f.Height + 6),
                                        fmtR)
                           Y += f.GetHeight() + 6
                       End Sub

    ' =======================
    ' الرأس
    ' =======================
    Center(StoreName, fBig)
    If Not String.IsNullOrEmpty(Phone1) Then Center("هاتف: " & Phone1, f11)
    If Not String.IsNullOrEmpty(Phone2) Then Center("هاتف: " & Phone2, f11)
    If Not String.IsNullOrEmpty(Address) Then Center(Address, f11)
    ' ✅ تحسين: نجوم بدل الإيموجي (لا يطبع على الحرارية)
    ' كود قديم: Center("🛵 يوجد توصيل للمنازل", f11)
    Center("** يوجد توصيل للمنازل **", f11)

    ' ✅ تحسين: خط سميك يفصل الرأس عن بيانات الفاتورة
    ' كود قديم: Center(New String("━"c, 40), f11)
    Center(New String("="c, 40), f11b)

    ' =======================
    ' بيانات الفاتورة
    ' =======================
    RightAligned("رقم الفاتورة : " & InvoiceID, f11)
    ' ✅ تحسين: تنسيق الوقت 12 ساعة مع ص/م
    RightAligned("التاريخ : " & DateTime.Now.ToString("yyyy/MM/dd  hh:mm:ss tt"), f11)
    ' كود قديم (24 ساعة): RightAligned("التاريخ : " & DateTime.Now.ToString("yyyy/MM/dd HH:mm"), f11)
    RightAligned("الكاشير : " & lbl_user_name.Text, f11)
    RightAligned("اسم العميل : " & txt_Customer_Name.Text, f11)
    RightAligned("كود العميل : " & txt_Customer_Code.Text, f11)
    ' ✅ تحسين: طريقة الدفع
    If Not String.IsNullOrEmpty(cmb_Pay.Text) Then
        RightAligned("طريقة الدفع : " & cmb_Pay.Text, f11)
    End If
    ' كود قديم: لم يكن يظهر طريقة الدفع

    ' ✅ تحسين: خط سميك قبل جدول الأصناف
    ' كود قديم: Center(New String("─"c, 40), f11)
    Center(New String("="c, 40), f11b)

    ' =======================
    ' جدول المنتجات — محسّن RTL
    ' =======================

    Dim colTotalW = 60
    Dim colPriceW = 60
    Dim colQtyW = 40
    Dim colProductW = pageW - (colTotalW + colPriceW + colQtyW + 20)

    ' ===== عناوين الأعمدة =====
    g.DrawString("الإجمالي", f11b, Brushes.Black, New RectangleF(0, Y, colTotalW, 20), fmtR)
    g.DrawString("السعر", f11b, Brushes.Black, New RectangleF(colTotalW, Y, colPriceW, 20), fmtR)
    g.DrawString("الكمية", f11b, Brushes.Black, New RectangleF(colTotalW + colPriceW, Y, colQtyW, 20), fmtR)
    g.DrawString("المنتج", f11b, Brushes.Black, New RectangleF(colTotalW + colPriceW + colQtyW, Y, colProductW, 20), fmtR)
    Y += 25

    Center(New String("-"c, 40), f11)

    ' ===== الصفوف =====
    For Each row As DataGridViewRow In DataGridView1.Rows
        If row.IsNewRow Then Continue For

        Dim name As String = CStr(row.Cells("ColProductName").Value)
        Dim qtyRaw As Decimal = 0D
        Decimal.TryParse(Convert.ToString(row.Cells("ColQuantity").Value), qtyRaw)
        Dim qty As String = qtyRaw.ToString("0.##")
        Dim price As String = FormatNumber(row.Cells("ColPrice").Value, 2)
        Dim total As String = FormatNumber(row.Cells("ColTotal").Value, 2)

        ' اسم المنتج قابل لطي الأسطر تلقائياً
        Dim nameHeight = g.MeasureString(name, f11, colProductW).Height

        g.DrawString(total, f11, Brushes.Black, New RectangleF(0, Y, colTotalW, nameHeight), fmtR)
        g.DrawString(price, f11, Brushes.Black, New RectangleF(colTotalW, Y, colPriceW, nameHeight), fmtR)
        g.DrawString(qty, f11, Brushes.Black, New RectangleF(colTotalW + colPriceW, Y, colQtyW, nameHeight), fmtR)
        g.DrawString(name, f11, Brushes.Black, New RectangleF(colTotalW + colPriceW + colQtyW, Y, colProductW, nameHeight), fmtR)

        Y += nameHeight + 8
        Center(New String("."c, 40), f11)
    Next

    ' ✅ تحسين: عدد الأصناف
    Dim itemCount As Integer = 0
    For Each r As DataGridViewRow In DataGridView1.Rows
        If Not r.IsNewRow Then itemCount += 1
    Next
    Center(New String("-"c, 40), f11)
    RightAligned("عدد الأصناف : " & itemCount, f11)
    ' كود قديم: لم يكن يظهر عدد الأصناف

    ' ✅ تحسين: خط سميك قبل المجاميع
    ' كود قديم: Center(New String("─"c, 40), f11)
    Center(New String("="c, 40), f11b)

    ' =======================
    ' المجاميع
    ' =======================
    ' ✅ تحسين: الخصم يظهر فقط إذا كان أكبر من صفر + فونت أكبر للإجمالي
    Dim discountVal As Decimal = 0
    Decimal.TryParse(txtDiscount.Text, discountVal)
    If discountVal > 0 Then
        ' كود قديم: RightAligned("إجمالي قبل الخصم : " & txtTotalRequired.Text, fBold)
        RightAligned("إجمالي قبل الخصم : " & txtTotalRequired.Text, fBig)
        RightAligned("الخصم           : " & txtDiscount.Text, fBold)
        ' كود قديم: RightAligned("الصافي : " & txtTotalAfterDiscount.Text, fBold)
        RightAligned("الصافي          : " & txtTotalAfterDiscount.Text, fBig)
    Else
        ' كود قديم: RightAligned("إجمالي الفاتورة : " & txtTotalRequired.Text, fBold)
        RightAligned("إجمالي الفاتورة : " & txtTotalRequired.Text, fBig)
    End If
    ' كود قديم (يظهر الخصم دائماً حتى لو صفر):
    ' RightAligned("إجمالي قبل الخصم : " & txtTotalRequired.Text, fBold)
    ' RightAligned("الخصم : " & txtDiscount.Text, fBold)
    ' RightAligned("الصافي : " & txtTotalAfterDiscount.Text, fBold)

    RightAligned("المدفوع         : " & txtPaid.Text, fBold)
    RightAligned("المتبقي         : " & txtRemaining.Text, fBold)

    ' ✅ تحسين: رصيد العميل السابق (يظهر فقط لعملاء الآجل)
    Dim custCode As String = txt_Customer_Code.Text.Trim()
    If custCode <> "1" AndAlso Not String.IsNullOrEmpty(custCode) Then
        Try
            Using cn2 As New SqlClient.SqlConnection(ConnectionString)
                cn2.Open()
                Dim cmd2 As New SqlClient.SqlCommand(
                    "SELECT CurrentBalance FROM Customers WHERE CustomerCode = @code", cn2)
                cmd2.Parameters.AddWithValue("@code", custCode)
                Dim balObj = cmd2.ExecuteScalar()
                If balObj IsNot Nothing Then
                    Dim currentBal As Decimal = CDec(balObj)
                    Dim invoiceRemaining As Decimal = 0
                    Decimal.TryParse(txtRemaining.Text, invoiceRemaining)
                    Dim previousBal As Decimal = currentBal - invoiceRemaining
                    Center(New String("─"c, 40), f11)
                    RightAligned("رصيد سابق : " & previousBal.ToString("0.00"), fBold)
                    RightAligned("متبقي الفاتورة : " & invoiceRemaining.ToString("0.00"), fBold)
                    RightAligned("إجمالي الحساب : " & currentBal.ToString("0.00"), fBold)
                End If
            End Using
        Catch
            ' تجاهل أي خطأ في جلب الرصيد
        End Try
    End If
    ' كود قديم: لم يكن هذا القسم موجوداً

    ' ✅ تحسين: خط سميك بعد المجاميع
    ' كود قديم: Center(New String("━"c, 40), f11)
    Center(New String("="c, 40), f11b)

    ' =======================
    ' باركود (مشروط بالإعداد)
    ' =======================
    Dim printBarcodeSetting As Boolean = (If(SettingsManager.GetSetting("PrintBarcode"), "true").ToLower() = "true")
    If printBarcodeSetting Then
        Dim qr As Bitmap = GenerateQRCode(InvoiceID.ToString())
        Dim qrX = (pageW - qr.Width) \ 2
        g.DrawImage(qr, qrX, Y)
        Y += qr.Height + 20
    End If
    ' كود قديم (الباركود يطبع دائماً):
    ' Dim qr As Bitmap = GenerateQRCode(InvoiceID.ToString())
    ' Dim qrX = (pageW - qr.Width) \ 2
    ' g.DrawImage(qr, qrX, Y)
    ' Y += qr.Height + 20

    ' =======================
    ' فوتر
    ' =======================
    ' ✅ تحسين: فوتر بنجوم وخط سميك
    ' كود قديم: Center(FooterMsg, f11b)
    Center(New String("="c, 40), f11b)
    Center("* " & FooterMsg & " *", f11b)
    Center("** يوجد توصيل للمنازل **", f11)
    Center(DevSig, f11)
    Center(New String("="c, 40), f11b)

End Sub

        Dim dlg As New PrintPreviewDialog With {
        .Document = pd,
        .WindowState = FormWindowState.Maximized
    }
        dlg.ShowDialog()

    End Sub

    '============================
    ' دالة توليد QR Code
    '============================
    Private Function GenerateQRCode(text As String) As Bitmap
        Dim writer As New ZXing.BarcodeWriter()
        writer.Format = ZXing.BarcodeFormat.QR_CODE
        writer.Options = New ZXing.Common.EncodingOptions With {
        .Height = 120,
        .Width = 120,
        .Margin = 0
    }
        Return writer.Write(text)
    End Function

    '============================
    ' دالة لمحاذاة النص للوسط
    '============================
    Private Function CenterText(text As String) As String
        Dim totalWidth As Integer = 40
        If text.Length >= totalWidth Then Return text
        Dim pad As Integer = (totalWidth - text.Length) \ 2
        Return New String(" "c, pad) & text
    End Function


    '===========================================================
    ' 🖨 دالة طباعة فاتورة حرارية احترافية مقاس 80mm
    '===========================================================
    'Private Sub PrintThermalInvoice80()

    '    Dim doc As New Printing.PrintDocument
    '    doc.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 302, 800) ' 80mm عرض

    '    AddHandler doc.PrintPage, AddressOf Me.RenderInvoice80

    '    Dim preview As New PrintPreviewDialog
    '    preview.Document = doc
    '    preview.WindowState = FormWindowState.Maximized
    '    preview.ShowDialog()

    'End Sub


    ''===========================================================
    '' 🎨 رسم الفاتورة على الورقة (Render)
    ''===========================================================
    'Private Sub RenderInvoice80(sender As Object, e As Printing.PrintPageEventArgs)

    '    Dim g = e.Graphics
    '    Dim y As Integer = 10

    '    Dim fontTitle As New Font("Tahoma", 12, FontStyle.Bold)
    '    Dim fontNormal As New Font("Tahoma", 9, FontStyle.Regular)
    '    Dim fontBold As New Font("Tahoma", 9, FontStyle.Bold)

    '    '-----------------------------------------
    '    ' 🏪 اسم المحل
    '    '-----------------------------------------
    '    g.DrawString("فاتورة تجريبية - المستخدم: عمار أحمد", fontTitle, Brushes.Black, 10, y)
    '    y += 30

    '    g.DrawLine(Pens.Black, 0, y, 300, y)
    '    y += 10

    '    '-----------------------------------------
    '    ' 📅 بيانات الفاتورة
    '    '-----------------------------------------
    '    g.DrawString("التاريخ: " & Date.Now.ToString("yyyy/MM/dd hh:mm tt"), fontNormal, Brushes.Black, 10, y)
    '    y += 20

    '    g.DrawString("رقم الفاتورة: 0001", fontNormal, Brushes.Black, 10, y)
    '    y += 25

    '    g.DrawLine(Pens.Black, 0, y, 300, y)
    '    y += 10

    '    '-----------------------------------------
    '    ' 📦 جدول الأصناف
    '    '-----------------------------------------
    '    g.DrawString("الصنف", fontBold, Brushes.Black, 10, y)
    '    g.DrawString("الكمية", fontBold, Brushes.Black, 130, y)
    '    g.DrawString("السعر", fontBold, Brushes.Black, 190, y)
    '    g.DrawString("الإجمالي", fontBold, Brushes.Black, 240, y)
    '    y += 20

    '    g.DrawLine(Pens.Black, 0, y, 300, y)
    '    y += 10

    '    '===============================
    '    ' 🛒 الأصناف التجريبية
    '    '===============================

    '    ' صنف 1
    '    g.DrawString("منتج رقم 1", fontNormal, Brushes.Black, 10, y)
    '    g.DrawString("2", fontNormal, Brushes.Black, 140, y)
    '    g.DrawString("150", fontNormal, Brushes.Black, 190, y)
    '    g.DrawString("300", fontNormal, Brushes.Black, 240, y)
    '    y += 20

    '    ' صنف 2
    '    g.DrawString("منتج رقم 2", fontNormal, Brushes.Black, 10, y)
    '    g.DrawString("1", fontNormal, Brushes.Black, 140, y)
    '    g.DrawString("200", fontNormal, Brushes.Black, 190, y)
    '    g.DrawString("200", fontNormal, Brushes.Black, 240, y)
    '    y += 20

    '    g.DrawLine(Pens.Black, 0, y, 300, y)
    '    y += 15

    '    '-----------------------------------------
    '    ' 💰 الإجمالي النهائي
    '    '-----------------------------------------
    '    g.DrawString("الإجمالي الكلي:", fontBold, Brushes.Black, 10, y)
    '    g.DrawString("500 جنيه", fontBold, Brushes.Black, 200, y)
    '    y += 30

    '    g.DrawLine(Pens.Black, 0, y, 300, y)
    '    y += 20

    '    '-----------------------------------------
    '    ' 🔳 QR Code (اختياري)
    '    '-----------------------------------------
    '    Dim qr As Bitmap = GenerateSimpleQR("Invoice Test - Ammar Ahmed")
    '    g.DrawImage(qr, 80, y)
    '    y += qr.Height + 20

    '    g.DrawString("شكراً لتعاملكم معنا ❤️", fontTitle, Brushes.Black, 40, y)

    'End Sub


    ''===========================================================
    '' 🔳 توليد QR Code بسيط بدون مكتبات خارجية
    ''===========================================================
    'Private Function GenerateSimpleQR(text As String) As Bitmap
    '    Dim encoder As New ZXing.BarcodeWriter
    '    encoder.Format = ZXing.BarcodeFormat.QR_CODE
    '    encoder.Options = New ZXing.Common.EncodingOptions With {
    '    .Height = 120,
    '    .Width = 120,
    '    .Margin = 0
    '}
    '    Return encoder.Write(text)
    'End Function

    '----------------------------------------------------
    ' تحميل بيانات المستخدم الحالي
    '----------------------------------------------------

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
End Class