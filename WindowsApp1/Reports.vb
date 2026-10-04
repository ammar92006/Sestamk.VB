

Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Security.Cryptography.Xml
Imports Org.BouncyCastle.Asn1.X9

Public Class Reports
    Dim x, y As Integer
    Dim newpoint As New Point
    Private originalSalesTable As DataTable = Nothing
    Private originalPurchaseTable As DataTable = Nothing
    Private status_show_p As Boolean = False

    Private Sub ReportsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' التجاوب مع الشاشة: تكبير الفورم لملء الشاشة لو أكبر من المساحة المتاحة
        LayoutHelper.MaximizeIfTooLarge(Me)
        TabPurchases.Text = "أرشيف مشتريات المنتجات"
        Dim modernPage As New TabPage("مشتريات الخامات والموردين")
        Dim openModern As New Button With {.Text = "فتح تقارير المشتريات الحديثة", .Dock = DockStyle.Top, .Height = 55}
        AddHandler openModern.Click, Sub() PurchaseDocumentHelper.RunSafely(Sub()
                                                                              SupplierAccountingService.DemandPermission("frmPurchaseReports", "CanOpen")
                                                                              Using report As New frmPurchaseReports()
                                                                                  report.ShowDialog(Me)
                                                                              End Using
                                                                          End Sub)
        modernPage.Controls.Add(openModern)
        TabReports.TabPages.Add(modernPage)

        UpdateDateTime()
        Timer1.Interval = 1000
        Timer1.Enabled = True
        LoadCustomers()
        LoadSuppliers()
        LoadUsers()
        LoadPaymentMethods()
        SetupDataGridViewSales(dgvSales)
        SetupDataGridViewSales(dgvInvoiceDetails)
        SetupDataGridViewSales(dgvInvoiceDetailsPurchase)
        SetupDataGridViewSales(dgv_balance_download)
        SetupDataGridViewSales(dgvPurchase)
        ' [FIX] تفعيل DoubleBuffered على شبكات التقارير لتقليل الـ Flickering
        EnableDoubleBuffer(dgvSales)
        EnableDoubleBuffer(dgvInvoiceDetails)
        EnableDoubleBuffer(dgvInvoiceDetailsPurchase)
        EnableDoubleBuffer(dgv_balance_download)
        EnableDoubleBuffer(dgvPurchase)
        LoadAllInvoices()
        LoadAllInvoicesPurchase()
        loadlogininfo()
        LoadAllBalancedownload()
        Load_most_sale()
        LoadNumericColumns(dgvSales, cboColumns)
        TabReports.SelectedIndex = 5
        txtCopies.Text = 1
        chkSalesDate.Checked = True
        chkPurchaseDate.Checked = True
    End Sub
    Private Sub cboColumns_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
) Handles cboColumns.SelectedIndexChanged

        If cboColumns.SelectedIndex = -1 Then
            txt_sum_col.Text = ""
            Return
        End If

        Dim colName As String = cboColumns.SelectedValue.ToString()
        Dim sumValue As Decimal = GetColumnSum(dgvSales, colName)

        txt_sum_col.Text = sumValue.ToString("N2")



    End Sub

    Public Sub LoadNumericColumns(
    dgv As DataGridView,
    cbo As ComboBox)

        cbo.DataSource = Nothing

        Dim dt As New DataTable()
        dt.Columns.Add("Text")   ' اللي هيظهر
        dt.Columns.Add("Value")  ' الاسم الحقيقي للعمود

        For Each col As DataGridViewColumn In dgv.Columns
            If col.ValueType Is GetType(Integer) _
            OrElse col.ValueType Is GetType(Decimal) _
            OrElse col.ValueType Is GetType(Double) _
            OrElse col.ValueType Is GetType(Long) Then

                dt.Rows.Add(col.HeaderText, col.Name)
            End If
        Next

        cbo.DisplayMember = "Text"
        cbo.ValueMember = "Value"
        cbo.DataSource = dt

        cbo.SelectedIndex = -1

    End Sub
    Public Function GetColumnSum(
    dgv As DataGridView,
    columnName As String
) As Decimal

        Dim total As Decimal = 0

        If Not dgv.Columns.Contains(columnName) Then
            Return 0
        End If

        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow AndAlso
           row.Cells(columnName).Value IsNot Nothing AndAlso
           IsNumeric(row.Cells(columnName).Value) Then

                total += Convert.ToDecimal(row.Cells(columnName).Value)
            End If
        Next

        Return total
    End Function

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


    Private Sub SetupDataGridViewSales(ByVal dgv As DataGridView)
        Main.datagridviewsetup(dgv)
        dgv.BorderStyle = BorderStyle.None

        With dgv
            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With
    End Sub
    Private Sub LoadCustomers()
        Dim dt = ReportsModule.GetCustomersList()
        cboSalesCustomer.DataSource = dt
        cboSalesCustomer.DisplayMember = "CustomerName"
        cboSalesCustomer.ValueMember = "CustomerID"
        cboSalesCustomer.SelectedIndex = -1
    End Sub

    Private Sub LoadSuppliers()
        cboPurchaseSupplier.DataSource = Nothing
        cboPurchaseSupplier.Items.Clear()
        Dim dt = ReportsModule.GetSuppliersList()
        cboPurchaseSupplier.DataSource = dt
        cboPurchaseSupplier.DisplayMember = "SuppliersName"
        cboPurchaseSupplier.ValueMember = "SuppliersID"
        cboPurchaseSupplier.SelectedIndex = -1
    End Sub

    Private Sub LoadUsers()
        Dim dt = ReportsModule.GetUsersList()

        cboSalesUser.DataSource = dt.Copy()
        cboSalesUser.DisplayMember = "User_Name"
        cboSalesUser.ValueMember = "User_ID"
        cboSalesUser.SelectedIndex = -1

        cboPurchaseUser.DataSource = dt.Copy()
        cboPurchaseUser.DisplayMember = "User_Name"
        cboPurchaseUser.ValueMember = "User_ID"
        cboPurchaseUser.SelectedIndex = -1
    End Sub

    Private Sub LoadPaymentMethods()
        Dim dt = ReportsModule.GetPaymentMethodsList()
        cboSalesPay.DataSource = dt.Copy()
        cboSalesPay.DisplayMember = "Payment_Method"
        cboSalesPay.SelectedIndex = -1

        cboPurchasePay.DataSource = dt.Copy()
        cboPurchasePay.DisplayMember = "Payment_Method"
        cboPurchasePay.SelectedIndex = -1
    End Sub

    ' ========================
    '     زر بحث المبيعات
    ' ========================
    Public Sub btnSearchSales_Click(sender As Object, e As EventArgs) Handles btnSearchSales.Click

        Dim f As Date? = If(chkSalesDate.Checked, dtSalesFrom.Value.Date, Nothing)
        Dim t As Date? = If(chkSalesDate.Checked, dtSalesTo.Value.Date, Nothing)

        Dim cust As Integer? = Nothing
        If cboSalesCustomer.SelectedIndex >= 0 Then
            cust = CInt(cboSalesCustomer.SelectedValue)
        End If

        Dim usr As Integer? = Nothing
        If cboSalesUser.SelectedIndex >= 0 Then
            usr = CInt(cboSalesUser.SelectedValue)
        End If

        Dim pay As String = Nothing
        If cboSalesPay.SelectedIndex >= 0 Then
            pay = cboSalesPay.Text.Trim()
        End If

        Dim dt = ReportsModule.GetSalesReport(f, t, cust, pay, usr, chkSalesDetails.Checked)
        dgvSales.DataSource = dt
        LoadNumericColumns(dgvSales, cboColumns)

    End Sub


    ' ========================   
    '     زر بحث المشتريات
    ' ========================
    Private Sub btnSearchPurchase_Click(sender As Object, e As EventArgs) Handles btnSearchPurchase.Click
        'Dim f As Date? = If(chkPurchaseDate.Checked, dtPurchaseFrom.Value.Date, Nothing)
        'Dim t As Date? = If(chkPurchaseDate.Checked, dtPurchaseTo.Value.Date, Nothing)

        'Dim sup As Integer = If(cboPurchaseSupplier.SelectedIndex >= 0, CInt(cboPurchaseSupplier.SelectedValue), 0)
        'Dim usr As Integer = If(cboPurchaseUser.SelectedIndex >= 0, CInt(cboPurchaseUser.SelectedValue), 0)
        'Dim pay As String = If(cboPurchasePay.SelectedIndex >= 0, cboPurchasePay.Text, "")

        'Dim dt = ReportsModule.GetPurchaseReport2(f, t, sup, pay, usr, chkPurchaseDetails.Checked)
        'dgvPurchase.DataSource = dt


        'Dim f As Date? = If(chkSalesDate.Checked, dtSalesFrom.Value.Date, Nothing)
        'Dim t As Date? = If(chkSalesDate.Checked, dtSalesTo.Value.Date, Nothing)

        'Dim cust As Integer? = Nothing
        'If cboSalesCustomer.SelectedIndex >= 0 Then
        '    cust = CInt(cboSalesCustomer.SelectedValue)
        'End If

        'Dim usr As Integer? = Nothing
        'If cboSalesUser.SelectedIndex >= 0 Then
        '    usr = CInt(cboSalesUser.SelectedValue)
        'End If

        'Dim pay As String = Nothing
        'If cboSalesPay.SelectedIndex >= 0 Then
        '    pay = cboSalesPay.Text.Trim()
        'End If

        'Dim dt = ReportsModule.GetSalesReport(f, t, cust, pay, usr, chkSalesDetails.Checked)
        'dgvSales.DataSource = dt

        Dim f As Date? = If(chkPurchaseDate.Checked, dtPurchaseFrom.Value.Date, Nothing)
        Dim t As Date? = If(chkPurchaseDate.Checked, dtPurchaseTo.Value.Date, Nothing)

        Dim sup As Integer? = Nothing
        If cboPurchaseSupplier.SelectedIndex >= 0 Then
            sup = CInt(cboPurchaseSupplier.SelectedValue)
        End If

        Dim usr As Integer? = Nothing
        If cboPurchaseUser.SelectedIndex >= 0 Then
            usr = CInt(cboPurchaseUser.SelectedValue)
        End If

        Dim pay As String = Nothing
        If cboPurchasePay.SelectedIndex >= 0 Then
            pay = cboPurchasePay.Text.Trim()
        End If

        Dim dt = ReportsModule.GetPurchaseReport2(
    f,
    t,
    sup,
    pay,
    usr,
    chkPurchaseDetails.Checked
)

        dgvPurchase.DataSource = dt

    End Sub

    ' ========================
    '     زر بحث حركة المخزون
    ' ========================
    'Private Sub btnSearchStock_Click(sender As Object, e As EventArgs)
    '    Dim f As Date? = If(chkStockDate.Checked, dtStockFrom.Value.Date, Nothing)
    '    Dim t As Date? = If(chkStockDate.Checked, dtStockTo.Value.Date, Nothing)

    '    Dim dt = ReportsModule.GetStockMovement(f, t)
    '    dgvStock.DataSource = dt
    'End Sub

    ' ========================
    '     زر بحث الأرباح
    ' ========================
    Private Sub btnSearchProfit_Click(sender As Object, e As EventArgs)
        'Dim f As Date? = If(chkProfitDate.Checked, dtProfitFrom.Value.Date, Nothing)
        'Dim t As Date? = If(chkProfitDate.Checked, dtProfitTo.Value.Date, Nothing)

        'Dim dt = ReportsModule.GetProfit(f, t)
        'dgv_balance_download.DataSource = dt
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Close()
    End Sub

    Private Sub dgvSales_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvSales.DataBindingComplete
        Try
            With dgvSales

                Dim headers As New Dictionary(Of String, String) From {
                    {"Invoice_ID", "كود الفاتورة"},
                    {"Invoice_type", "نوع الفاتورة"},
                    {"Invoice_Date", "تاريخ الفاتورة"},
                    {"CustomerID", "id العميل"},
                    {"CustomerName", "اسم العميل"},
                    {"Net_Amount", "اجمالي الفاتورة"},
                    {"Discount_Value", "الخصم"},
                    {"Total_Amount", "الاجمالي بعد الخصم"},
                    {"Amount_Paid", "المدفوع"},
                    {"Remaining", "المتبقي"},
                    {"Payment_Method", "طريقه الدفع"},
                    {"User_ID", "ID المستخدم"},
                    {"User_Name", "اسم المستخدم"},
                    {"Product_ID", "ID المنتج"},
                    {"Product_Name", "اسم المنتج"},
                    {"Quantity_Sold", "الكمية الاساسية"},
                    {"Sale_Price_Per_Unit", "سعر البيع"},
                    {"Total_Line_Amount", "اجمالي Line"},
                    {"Total_Profit", "الربح الصافي"}
                }

                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next
            End With
            Dim sumValue As Decimal = GetColumnSum(dgvSales, "Total_Profit")
            txt_Total_Profit_dgv.Text = sumValue
        Catch ex As Exception

            Logger.LogError("Reports.vb:359", ex)
        End Try

    End Sub

    Private Sub dgvSales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSales.CellDoubleClick
        Try
            ' تأكد إن المستخدم ضغط على صف صحيح
            If e.RowIndex < 0 Then Exit Sub

            ' الحصول على رقم الفاتورة
            Dim invoiceID As Integer = Convert.ToInt32(dgvSales.Rows(e.RowIndex).Cells("Invoice_ID").Value)

            ' استدعاء دالة تحميل تفاصيل الفاتورة
            LoadSelectedInvoice(invoiceID)

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء فتح تفاصيل الفاتورة: " & ex.Message)
        End Try
    End Sub
    Public Sub scannerInvoice_DataReceived(code As String)
        If TabReports.SelectedIndex = 5 Or TabReports.SelectedIndex = 2 Then
            Try
                Me.Invoke(Sub()
                              Dim invoiceID As Integer
                              If Integer.TryParse(code, invoiceID) Then
                                  LoadSelectedInvoice(invoiceID)
                              Else
                                  SmartMessageBox.Show("رقم الفاتورة غير صالح: " & code, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                              End If
                          End Sub)
            Catch ex As Exception
                SmartMessageBox.Show("حدث خطأ أثناء استقبال البيانات من السكانر: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    'Private Sub LoadInvoiceDetails(invoiceID As Integer)
    '    Try
    '        ' استرجاع بيانات تفاصيل الفاتورة من الموديول
    '        Dim dt As DataTable = ReportsModule.GetSalesDetails(invoiceID)

    '        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
    '            SmartMessageBox.Show("لا توجد تفاصيل لهذه الفاتورة.")
    '            Exit Sub
    '        End If

    '        ' عرض التفاصيل
    '        dgvInvoiceDetails.DataSource = dt

    '        ' فتح التاب
    '        TabReports.SelectedTab = tabInvoiceDetails

    '        ' عمل فوكس
    '        dgvInvoiceDetails.Focus()

    '    Catch ex As Exception
    '        SmartMessageBox.Show("خطأ أثناء تحميل تفاصيل الفاتورة: " & ex.Message)
    '    End Try
    'End Sub
    'Private Sub LoadAllInvoices()
    '    Dim dt As DataTable = ReportsModule.GetAllInvoices()
    '    dgvSales.DataSource = dt
    'End Sub'
    Private Sub LoadAllInvoices()
        Dim dt As DataTable = ReportsModule.GetAllInvoices()
        originalSalesTable = dt
        dgvSales.DataSource = originalSalesTable
    End Sub
    Private Sub LoadAllInvoicesPurchase()
        Dim dt As DataTable = ReportsModule.GetAllInvoicesPurchase()
        originalPurchaseTable = dt
        dgvPurchase.DataSource = originalPurchaseTable
    End Sub

    Private Sub LoadAllBalancedownload()
        Dim dt As DataTable = ReportsModule.GetAllBalancedownload()
        dgv_balance_download.DataSource = dt
    End Sub
    Private Sub Load_most_sale()
        Dim dt As DataTable = ReportsModule.GetAll_most_sale()
        dgvStock.DataSource = dt
    End Sub
    Private Sub loadlogininfo()

        Try
            Using cn As SqlConnection = DBModule.NewConn()

            Dim query As String = "
                SELECT User_Name 
                FROM Users_TBL 
                WHERE User_ID = @ID
            "

            Using cmd As New SqlCommand(query, cn)

                cmd.Parameters.AddWithValue("@ID", Session.CurrentUserID)

                Dim User_Name As String = Convert.ToString(cmd.ExecuteScalar())
                lbl_user_name.Text = User_Name

            End Using

        End Using
        Catch ex As Exception

            SmartMessageBox.Show("حدث خطأ أثناء التحقق من المستحدم: " & ex.Message,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub


    Public Sub LoadSelectedInvoice(ByVal invoiceID As Integer)
        Try

            ' ========== هـــيــدر ==========
            Dim dtHeader As DataTable = GetInvoiceHeader(invoiceID)
            If dtHeader Is Nothing OrElse dtHeader.Rows.Count = 0 Then
                SmartMessageBox.Show("لا توجد تفاصيل لهذه الفاتورة.")
                Exit Sub
            End If
            If dtHeader.Rows.Count > 0 Then
                Dim R = dtHeader.Rows(0)

                txt_Invoice_type.Text = R("Invoice_type").ToString()
                txtInvID.Text = R("Invoice_ID").ToString()
                dtpInvDate.Value = CDate(R("Invoice_Date"))
                'txt_Customer_Code.Text = R("Customer_ID").ToString()
                txtCustomerName.Text = R("CustomerName").ToString()
                txtTotal.Text = R("Total_Amount").ToString()
                txtDiscount.Text = R("Discount_Value").ToString()
                txtNet.Text = R("Net_Amount").ToString()
                txtPaid.Text = R("Amount_Paid").ToString()
                txtRemaining.Text = R("Remaining").ToString()
                txt_Payment_Method.Text = R("Payment_Method").ToString()
                txtUser.Text = R("User_Name").ToString()
                txt_Total_Profit.Text = R("Total_Profit").ToString()
                Dim phone As String = String.Empty
                Dim CustomerCode As String = String.Empty
                Try
                    Using cn As SqlConnection = DBModule.NewConn()

                    Dim query As String = "SELECT PhoneNumber , CustomerCode FROM Customers WHERE CustomerID = @CustomerID"
                    Using cmd As New SqlCommand(query, cn)
                        cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = R("Customer_ID").ToString()

                        'Dim obj = cmd.ExecuteScalar()
                        'If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                        '    phone = obj.ToString().Trim()
                        '    txtCustomerPhone.Text = phone
                        'End If
                        Using rd = cmd.ExecuteReader()
                            If rd.Read() Then
                                phone = If(IsDBNull(rd("PhoneNumber")), "", rd("PhoneNumber").ToString().Trim())
                                txtCustomerPhone.Text = phone
                                CustomerCode = If(IsDBNull(rd("CustomerCode")), "", rd("CustomerCode").ToString().Trim())
                                txt_Customer_Code.Text = CustomerCode
                            End If
                        End Using
                    End Using
                    End Using ' cn

                Catch ex As Exception
                    SmartMessageBox.Show("حدث خطأ أثناء البحث عن رقم الهاتف: " & ex.Message)
                End Try
            End If

            ' ========== تفاصيل ==========
            Dim dtDetails As DataTable = GetInvoiceDetails(invoiceID)
            dgvInvoiceDetails.DataSource = dtDetails

            ' ========== فتح التــاب ==========
            TabReports.SelectedTab = tabInvoiceDetails
            dgvInvoiceDetails.Focus()

        Catch ex As Exception

            Logger.LogError("Reports.vb:541", ex)
        End Try

    End Sub
    Public Sub LoadSelectedInvoicePurchase(ByVal invoiceID As Integer)
        Try

            ' ========== هـــيــدر ==========
            Dim dtHeaderPurchase As DataTable = GetInvoiceHeaderpurchases(invoiceID)
            If dtHeaderPurchase Is Nothing OrElse dtHeaderPurchase.Rows.Count = 0 Then
                SmartMessageBox.Show("لا توجد تفاصيل لهذه الفاتورة.")
                Exit Sub
            End If
            If dtHeaderPurchase.Rows.Count > 0 Then
                Dim R = dtHeaderPurchase.Rows(0)
                txtSupplier_Num.Text = R("PhoneNumber").ToString()
                txtSupplierCode.Text = R("SuppliersCode").ToString()
                txt_Invoice_type2.Text = R("Purchase_type").ToString()
                txtInvID2.Text = R("Purchase_Id").ToString()
                dtpInvDate2.Value = CDate(R("Purchase_Date"))
                txtSupplierName.Text = R("SuppliersName").ToString()
                txtTotal2.Text = R("Total_Amount").ToString()
                txtDiscount2.Text = R("Discount_Value").ToString()
                txtNet2.Text = R("Net_Amount").ToString()
                txtPaid2.Text = R("Amount_Paid").ToString()
                txtRemaining2.Text = R("Remaining").ToString()
                txtUser2.Text = R("User_Name").ToString()
            End If
            ' ========== تفاصيل ==========
            Dim dtDetailsPurchase As DataTable = GetInvoiceDetailsPurchase(invoiceID)
            dgvInvoiceDetailsPurchase.DataSource = dtDetailsPurchase

            ' ========== فتح التــاب ==========
            TabReports.SelectedIndex = 1
            dgvPurchase.Focus()

        Catch ex As Exception

            Logger.LogError("Reports.vb:579", ex)
        End Try

    End Sub

    Private Sub lblDate_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown, lblTime.MouseDown, lblHeader.MouseDown, lblDate.MouseDown, lbl_user_name.MouseDown, Label14.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub dgvInvoiceDetails_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvInvoiceDetails.DataBindingComplete
        Try
            With dgvInvoiceDetails

                ' قاموس يحتوي على (اسم العمود → الاسم الظاهر)
                Dim headers As New Dictionary(Of String, String) From {
                    {"Invoice_ID", "كود الفاتورة"},
                    {"Product_Name", "اسم المنتج"},
                    {"Quantity_Sold", "الاجمالي بالوحدة الاساسية"},
                    {"ProductUnit_Name", "اسم الوحدة"},
                    {"Sale_Price_Per_Unit", "سعر البيع"},
                    {"Total_Line_Amount", "السعر الاجمالي للمنتج"},
                    {"Profit", "الربح الصافي"}
                }

                ' تعيين العناوين لو الأعمدة موجودة
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next
            End With
        Catch __logEx As Exception
            Logger.LogError("Reports.vb:613", __logEx)
        End Try
    End Sub

    Private Sub dgv_balance_download_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgv_balance_download.DataBindingComplete
        Try
            With dgv_balance_download
                Dim headers As New Dictionary(Of String, String) From {
                    {"LogID", "كود العملية"},
                    {"CustomerID", "ID العميل"},
                    {"CustomerCode", "كود العميل"},
                    {"CustomerName", "اسم العميل"},
                    {"OldBalance", "الرصيد قبل"},
                    {"PaidAmount", "المدفوع"},
                    {"NewBalance", "الرصيد بعد"},
                    {"Notes", "الملاحظات"},
                    {"UserName", "اسم المستخدم"},
                    {"ActionDate", "التاريخ"}
                }
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next
            End With
        Catch __logEx As Exception
            Logger.LogError("Reports.vb:639", __logEx)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UpdateDateTime()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim copies As Integer = 1
        Integer.TryParse(txtCopies.Text.Trim(), copies)
        Dim CurrentIDV As Integer
        Integer.TryParse(txtInvID.Text.Trim(), CurrentIDV)
        PrintInvoiceFromDBProfessional(CurrentIDV, copies)
    End Sub

    Private Async Sub btnSendInvoiceWhatsApp_Click(sender As Object, e As EventArgs) Handles btnSendInvoiceWhatsApp.Click
        Dim phone As String = txtCustomerPhone.Text.Trim()
        Dim invoiceID As Integer = txtInvID.Text.Trim
        If String.IsNullOrWhiteSpace(phone) Then
            SmartMessageBox.Show("رقم الهاتف غير صالح.")
            Return
        End If

        ' توليد نص الفاتورة
        Dim message As String = ReportsModule.GenerateInvoiceText(invoiceID)

        ' إرسال الرسالة
        Dim success As Boolean = Await WhatsAppAPI.SendText(phone, message)

        If success Then
            SmartMessageBox.Show("✅ تم إرسال الفاتورة على واتساب بنجاح")
        Else
            SmartMessageBox.Show("❌ فشل إرسال الفاتورة على واتساب")
        End If
    End Sub


    Private Sub dgvPurchase_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvPurchase.DataBindingComplete
        Try
            With dgvPurchase
                If dgvPurchase.Columns.Contains("purchases_Image") Then
                    With dgvPurchase.Columns("purchases_Image")
                        .HeaderText = "صورة الفاتورة"
                        .Visible = False
                    End With
                End If
                Dim headers As New Dictionary(Of String, String) From {
                    {"Purchase_Id", "كود الفاتورة"},
                    {"Purchase_type", "نوع الفاتورة"},
                    {"Purchase_Date", "تاريخ الفاتورة"},
                    {"SuppliersID", "id المورد"},
                    {"SuppliersName", "اسم المورد"},
                    {"Net_Amount", "المبلغ الصافي"},
                    {"Discount_Value", "قيمة الخصم"},
                    {"Total_Amount", "اجمالي الفاتوة"},
                    {"Amount_Paid", "المدفوع"},
                    {"Remaining", "المتبقي"},
                    {"Notes", "الملاحظات"},
                    {"User_ID", "ID المستخدم"},
                    {"Payment_Method", "طريقة الدفع"},
                    {"User_Name", "اسم المستخدم"}
                }

                ' تعيين العناوين لو الأعمدة موجودة
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next

            End With

        Catch ex As Exception
            ' تجاهل أي خطأ
            Logger.LogError("Reports.vb:714", ex)
        End Try
    End Sub

    Private Sub dgvPurchase_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchase.CellDoubleClick
        Try
            ' تأكد إن المستخدم ضغط على صف صحيح
            If e.RowIndex < 0 Then Exit Sub

            ' الحصول على رقم الفاتورة
            Dim invoiceID As Integer = Convert.ToInt32(dgvPurchase.Rows(e.RowIndex).Cells("Purchase_Id").Value)
            ' استدعاء دالة تحميل تفاصيل الفاتورة
            LoadSelectedInvoicePurchase(invoiceID)

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء فتح تفاصيل الفاتورة: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvInvoiceDetailsPurchase_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvInvoiceDetailsPurchase.DataBindingComplete
        Try
            With dgvInvoiceDetailsPurchase
                ' قاموس يحتوي على (اسم العمود → الاسم الظاهر)
                Dim headers As New Dictionary(Of String, String) From {
                    {"Purchase_Id", "كود الفاتورة"},
                    {"Product_Name", "اسم المنتج"},
                    {"Quantity_Sold", "الكمية"},
                    {"ProductUnit_Name", "اسم الوحدة"},
                    {"Purchase_Price_Per_Unit", "سعر الشراء"},
                    {"Total_Line_Amount", "الاجمالي"}
                }

                ' تعيين العناوين لو الأعمدة موجودة
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next

            End With

        Catch ex As Exception
            ' تجاهل أي خطأ
            Logger.LogError("Reports.vb:757", ex)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        WindowState = FormWindowState.Minimized

    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        UpdateDateTime()
        Timer1.Interval = 1000
        Timer1.Enabled = True
        LoadCustomers()
        LoadSuppliers()
        LoadUsers()
        LoadPaymentMethods()
        SetupDataGridViewSales(dgvSales)
        SetupDataGridViewSales(dgvInvoiceDetails)
        SetupDataGridViewSales(dgvInvoiceDetailsPurchase)
        SetupDataGridViewSales(dgv_balance_download)
        SetupDataGridViewSales(dgvPurchase)
        LoadAllInvoices()
        LoadAllInvoicesPurchase()
        loadlogininfo()
        LoadAllBalancedownload()
        LoadNumericColumns(dgvSales, cboColumns)
        TabReports.SelectedIndex = 5
        txtCopies.Text = 1
        chkSalesDate.Checked = True
        chkPurchaseDate.Checked = True
    End Sub

    Private Sub dgvStock_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvStock.DataBindingComplete
        Try
            With dgvStock
                SetupDataGridView(dgvStock)
                ' قاموس يحتوي على (اسم العمود → الاسم الظاهر)
                Dim headers As New Dictionary(Of String, String) From {
                    {"Product_ID", "ID المنتج"},
                    {"Product_Name", "اسم المنتج"},
                    {"ProductUnit_Name", "اسم الوحدة"},
                    {"Sale_Price_Per_Unit", "سعر البيع"},
                    {"Total_Line_Amount", "اجمالي المبيعات"},
                    {"TotalQuantitySold", "الكمية المباعة"}
                }

                ' تعيين العناوين لو الأعمدة موجودة
                For Each item In headers
                    If .Columns.Contains(item.Key) Then
                        .Columns(item.Key).HeaderText = item.Value
                    End If
                Next

            End With

        Catch ex As Exception
            ' تجاهل أي خطأ
            Logger.LogError("Reports.vb:823", ex)
        End Try
    End Sub

    Private Sub lblDate_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove, lblTime.MouseMove, lblHeader.MouseMove, lblDate.MouseMove, lbl_user_name.MouseMove, Label14.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub btn_inv_delete_Click(sender As Object, e As EventArgs) Handles btn_inv_delete.Click
        Try
            If dgvSales.CurrentRow Is Nothing Then
                SmartMessageBox.Show("من فضلك اختر فاتورة لحذفها أولاً")
                Return
            End If

            Dim inv_id As Integer = Convert.ToInt32(dgvSales.CurrentRow.Cells("Invoice_ID").Value)

            If SmartMessageBox.Show("هل أنت متأكد من حذف هذه الفاتورة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            ' العروض التوافقية (vw_SalesHeaderAll / vw_SalesDetailsAll) مبنية على UNION ولا تقبل الحذف
            ' المباشر، لذلك نحذف من الجداول الحقيقية. صفوف المبيعات الحديثة تظهر في العرض بمعرّف مُزاح
            ' (100000000 + InvoiceID) لفصل مجال المعرّفات عن القديمة، فنتعرف على الجدول الصحيح بفكّ الإزاحة.
            Const ModernIdOffset As Integer = 100000000

            Using cn As SqlConnection = DBModule.NewConn()

                If inv_id >= ModernIdOffset Then
                    ' فاتورة حديثة: نفكّ الإزاحة ثم نحذف التفاصيل فالنرأس
                    Dim realInvoiceID As Integer = inv_id - ModernIdOffset

                    Dim queryModernDetails As String = "DELETE FROM SalesInvoiceDetails WHERE InvoiceID = @Invoice_ID"
                    Using cmdModernDetails As New SqlCommand(queryModernDetails, cn)
                        cmdModernDetails.Parameters.AddWithValue("@Invoice_ID", realInvoiceID)
                        cmdModernDetails.ExecuteNonQuery()
                    End Using

                    Dim queryModernHeader As String = "DELETE FROM SalesInvoices WHERE InvoiceID = @Invoice_ID"
                    Using cmdModernHeader As New SqlCommand(queryModernHeader, cn)
                        cmdModernHeader.Parameters.AddWithValue("@Invoice_ID", realInvoiceID)
                        cmdModernHeader.ExecuteNonQuery()
                    End Using
                Else
                    ' فاتورة قديمة: معرّفها كما هو في الجداول القديمة
                    Dim queryDetails As String = "DELETE FROM SalesDetails WHERE Invoice_ID = @Invoice_ID"
                    Using cmdDetails As New SqlCommand(queryDetails, cn)
                        cmdDetails.Parameters.AddWithValue("@Invoice_ID", inv_id)
                        cmdDetails.ExecuteNonQuery()
                    End Using

                    Dim queryHeader As String = "DELETE FROM SalesHeader WHERE Invoice_ID = @Invoice_ID"
                    Using cmdHeader As New SqlCommand(queryHeader, cn)
                        cmdHeader.Parameters.AddWithValue("@Invoice_ID", inv_id)
                        cmdHeader.ExecuteNonQuery()
                    End Using
                End If

            End Using

            SmartMessageBox.Show("🗑️ تم حذف الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadAllInvoices()
        Catch ex As Exception
            SmartMessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_inv_purchases_del_Click(sender As Object, e As EventArgs) Handles btn_inv_purchases_del.Click
        Try
            If dgvPurchase.CurrentRow Is Nothing Then
                SmartMessageBox.Show("من فضلك اختر فاتورة لحذفها أولاً")
                Return
            End If

            Dim inv_id As Integer = Convert.ToInt32(dgvPurchase.CurrentRow.Cells("Purchase_Id").Value)

            If SmartMessageBox.Show("هل أنت متأكد من حذف هذه الفاتورة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            Using cn As SqlConnection = DBModule.NewConn()

            Dim queryDetails As String = "DELETE FROM PurchaseDetails WHERE PurchaseID = @Invoice_ID"
            Using cmdDetails As New SqlCommand(queryDetails, cn)
                cmdDetails.Parameters.AddWithValue("@Invoice_ID", inv_id)
                cmdDetails.ExecuteNonQuery()
            End Using

            Dim queryHeader As String = "DELETE FROM PurchaseHeaders WHERE PurchaseID = @Invoice_ID"
            Using cmdHeader As New SqlCommand(queryHeader, cn)
                cmdHeader.Parameters.AddWithValue("@Invoice_ID", inv_id)
                cmdHeader.ExecuteNonQuery()
            End Using


            End Using

            SmartMessageBox.Show("🗑️ تم حذف الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadAllInvoicesPurchase()
        Catch ex As Exception
            SmartMessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message)
        End Try
    End Sub

    Private Async Sub btn_sand_supplier_Click(sender As Object, e As EventArgs) Handles btn_sand_supplier.Click
        Dim phone As String = txtSupplier_Num.Text.Trim()
        Dim invoiceID As Integer = txtInvID2.Text.Trim
        If String.IsNullOrWhiteSpace(phone) Then
            SmartMessageBox.Show("رقم الهاتف غير صالح.")
            Return
        End If

        ' توليد نص الفاتورة
        Dim message As String = ReportsModule.GenerateInvoiceText2(invoiceID)

        ' إرسال الرسالة
        Dim success As Boolean = Await WhatsAppAPI.SendText(phone, message)

        If success Then
            SmartMessageBox.Show("✅ تم إرسال الفاتورة على واتساب بنجاح")
        Else
            SmartMessageBox.Show("❌ فشل إرسال الفاتورة على واتساب")
        End If
    End Sub

    Private Sub btn_purchases_print_Click(sender As Object, e As EventArgs) Handles btn_purchases_print.Click
        Dim copies As Integer = 1
        Integer.TryParse(txtCopies2.Text.Trim(), copies)
        Dim CurrentIDV As Integer
        Integer.TryParse(txtInvID.Text.Trim(), CurrentIDV)
        PrintInvoiceFromDBProfessional(CurrentIDV, copies)
    End Sub

    Private Sub btn_edit_sale_Click(sender As Object, e As EventArgs) Handles btn_edit_sale.Click

        'Dim frm As Sales = Nothing
        'Dim invoiceID As Integer = txtInvID.Text.Trim
        'For Each f As Form In Application.OpenForms
        '    If TypeOf f Is Sales Then
        '        frm = CType(f, Sales)
        '    End If
        'Next

        'If frm Is Nothing Then
        '    frm = New Sales()
        '    frm.inv_id_edit = invoiceID
        '    frm.Show()
        'Else
        '    frm.inv_id_edit = invoiceID
        'End If

        'frm.btn_Invoice_Edit.Visible = True
        'Await frm.LoadInvoiceAsync(invoiceID)

        Dim invoiceID As Integer = txtInvID.Text.Trim
        ' TODO: تم حذف فورم Sales القديمة — يجب ربط تعديل الفاتورة بـ frmPOS
        Logger.Warn("محاولة فتح فاتورة للتعديل (Sales form محذوفة): InvoiceID=" & invoiceID)
        Notify.Toast("هذه الميزة قيد التطوير", Notify.ToastType.Warning)


    End Sub

    Private Sub btn_show_pirfit_Click(sender As Object, e As EventArgs) Handles btn_show_pirfit.Click
        If status_show_p = False Then
            status_show_p = True
            btn_show_pirfit.Image = My.Resources.show
        Else
            status_show_p = False
            btn_show_pirfit.Image = My.Resources.hidden

        End If
        If status_show_p Then
            txt_Total_Profit_dgv.Visible = True
            Label39.Visible = True
        Else
            txt_Total_Profit_dgv.Visible = False
            Label39.Visible = False
        End If
    End Sub

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

            If .Columns.Contains("Product_ID") Then .Columns("Product_ID").Visible = False

            If .Columns.Contains("Sale_Price_Per_Unit") Then .Columns("Sale_Price_Per_Unit").DefaultCellStyle.Format = "N2"
            If .Columns.Contains("Product_ID") Then .Columns("Product_ID").DisplayIndex = 0
            If .Columns.Contains("Product_Name") Then .Columns("Product_Name").DisplayIndex = 1
            If .Columns.Contains("ProductUnit_Name") Then .Columns("ProductUnit_Name").DisplayIndex = 2
            If .Columns.Contains("Sale_Price_Per_Unit") Then .Columns("Sale_Price_Per_Unit").DisplayIndex = 3
            If .Columns.Contains("TotalQuantitySold") Then .Columns("TotalQuantitySold").DisplayIndex = 4
            If .Columns.Contains("Total_Line_Amount") Then .Columns("Total_Line_Amount").DisplayIndex = 5

            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            dgv.ColumnHeadersHeight = 60
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16.0!, FontStyle.Bold)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            dgv.DefaultCellStyle.Font = New Font("Segoe UI", 14.0!)

            dgv.RowHeadersVisible = False
            dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

        End With

    End Sub





End Class
