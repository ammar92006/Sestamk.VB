Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports DevExpress.XtraEditors
Imports Guna.UI2.WinForms

' ==============================================================
'  ملاحظة: الاتصال بقاعدة البيانات يعتمد على دالة ConnectionString أو GetConnectionString()
'  يجب التأكد من تعريف ConnectionString بشكل صحيح في مشروعك.
' ==============================================================

Public Class Sales

    '──────────────────────────────────────────────────────────────
    ' متغيرات الفورم
    '──────────────────────────────────────────────────────────────
    Private _x, _y As Integer
    Private _newPoint As New Point
    Private _manager As New SalesManager()
    Public SelectedProductId As Integer = 0
    Public CurrentConversionFactor As Decimal = 0D
    Public CurrentSalePrice As Decimal = 0D
    Private _currentUnitID As Integer = 0
    Private WithEvents _timer1 As New System.Windows.Forms.Timer()
    Private _discountEnabled As Boolean = True
    Private _moneyEnabled As Boolean = False
    Private _isSendToWhatsApp As Boolean = False
    Private _autoSave As Boolean = If(SettingsManager.GetSetting("autoSaveinvoice") = "true", True, False)
    Private _currentIDV As Integer

    ' [قفل الفاتورة بعد الحفظ]: يمنع إضافة منتجات/حفظ مرة تانية على نفس الفاتورة
    Private _invoiceSaved As Boolean = False
    Public ScalID As Integer = 0

    Public Property inv_id_edit As Integer

    ' ── منع إعادة الدخول لـ RecalculateTotals ──
    Private _isRecalculating As Boolean = False

    ' ── Debounce للبحث (300ms بعد آخر حرف) ──
    Private _searchCts As CancellationTokenSource

    ' ── Cache لسعر الشراء ──
    Private _purchasePriceCache As New Dictionary(Of String, Decimal)

    ' ── Cache مؤقت للمخزون (يُمسح عند إضافة أو تعديل منتج) ──
    Private _stockCache As New Dictionary(Of Integer, Decimal)
    Private _prevBalanceForPrint As Decimal = 0D

    ' الخزنة
    Private SelectedTreasuryid As Integer
    Private defaultTreasuryid As Integer = -1

    '══════════════════════════════════════════════════════════════
    ' دوال الاتصال بقاعدة البيانات
    '══════════════════════════════════════════════════════════════
    Private Function OpenConnection() As SqlConnection
        Dim cn As New SqlConnection(ConnectionString)
        cn.Open()
        Return cn
    End Function

    Private Async Function OpenConnectionAsync() As Task(Of SqlConnection)
        Dim cn As New SqlConnection(ConnectionString)
        Await cn.OpenAsync()
        Return cn
    End Function

    ' لتجنب الأخطاء إذا كانت دالة NewConnAsync معرفة خارجياً
    Private Async Function NewConnAsync() As Task(Of SqlConnection)
        Dim cn As New SqlConnection(ConnectionString)
        Await cn.OpenAsync()
        Return cn
    End Function

    ' تفعيل DoubleBuffered للـ DataGridView لمنع الوميض والبطء
    Private Sub EnableDoubleBuffer(ByVal dgv As DataGridView)
        Try
            Dim dgvType As Type = dgv.GetType()
            Dim pi As System.Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            pi.SetValue(dgv, True, Nothing)
        Catch ex As Exception
            ' تجاهل في حال عدم توفر الصلاحية للوصول للميزة
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' أزرار التحكم في الفورم (إغلاق / تكبير / تصغير / تحريك)
    '══════════════════════════════════════════════════════════════
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        WindowState = If(WindowState = FormWindowState.Normal,
                         FormWindowState.Maximized, FormWindowState.Normal)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        _x = Control.MousePosition.X - Me.Location.X
        _y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            _newPoint = Control.MousePosition
            _newPoint.X -= _x
            _newPoint.Y -= _y
            Me.Location = _newPoint
        End If
    End Sub

    Private Sub Labels_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles lblTime.MouseDown, lblDate.MouseDown, lbl_user_name.MouseDown,
                Label14.MouseDown, Guna2HtmlLabel1.MouseDown
        _x = Control.MousePosition.X - Me.Location.X
        _y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Labels_MouseMove(sender As Object, e As MouseEventArgs) _
        Handles lblTime.MouseMove, lblDate.MouseMove, lbl_user_name.MouseMove,
                Label14.MouseMove, Guna2HtmlLabel1.MouseMove
        If e.Button = MouseButtons.Left Then
            _newPoint = Control.MousePosition
            _newPoint.X -= _x
            _newPoint.Y -= _y
            Me.Location = _newPoint
        End If
    End Sub

    '══════════════════════════════════════════════════════════════
    ' تحميل الفورم (Async)
    '══════════════════════════════════════════════════════════════
    Private Async Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LayoutHelper.MaximizeIfTooLarge(Me)

        Me.KeyPreview = True
        btn_Invoice_Edit.Visible = False

        SetupComboPayment()
        btnToggleDiscount.PerformClick()
        UpdateLanguageLabel()

        _timer1.Interval = 1000
        _timer1.Start()
        UpdateDateTime()
        Timer2.Interval = 1000
        Timer2.Enabled = True

        ' تشغيل العمليات بالتوازي لسرعة فتح الشاشة
        If inv_id_edit > 0 Then
            Await Task.Run(Sub() Me.Invoke(Sub() loadlogininfo()))
        Else
            Await Task.WhenAll(
                Task.Run(Sub() Me.Invoke(Sub() loadlogininfo())),
                Task.Run(Sub() Me.Invoke(Sub() getnewInvoiceID()))
            )
        End If

        SetupDataGridView(DataGridView1)
        EnableDoubleBuffer(DataGridView1)

        If inv_id_edit = 0 Then
            cleartxts()
            Try
                Dim defaultCustCode As String = If(SettingsManager.GetSetting("defaultcustomercode"), "1")
                txt_Customer_Code.Text = defaultCustCode
                btn_search_CustomerCode.PerformClick()
                If lstNameSuggestions.Items.Count > 1 Then
                    lstNameSuggestions.SelectedIndex = 1
                End If
            Catch
            End Try
        End If

        RegisterProductSearchHandlers()

        txtDiscount.Text = "0"
        txt_totelProduct.Text = "0"
        DataGridView1.Columns("ColQtyPlus").Width = 30
        DataGridView1.Columns("ColQtyMinus").Width = 30
        Await LoadTreasuriesAsync()

        ' توزيع الأزرار بشكل متناسق في الشاشة
        Me.btnSaveInvoice.Location = New Point(1250, 5)
        Me.btn_Sales_Returns.Location = New Point(900, 5)
        Me.btnDelete.Location = New Point(600, 5)
        Me.Button1.Location = New Point(280, 5)
        Me.btnToggleScanner.Location = New Point(2, 5)
    End Sub

    Private Sub SetupComboPayment()
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
    End Sub

    Private Sub RegisterProductSearchHandlers()
        ' ربط الأحداث مع SalesManager وتمرير المتغيرات بواسطة Ref
        AddHandler lstNameSuggestions.SelectedIndexChanged,
            Sub(s, ev)
                _manager.lstNameSuggestions_SelectedIndexChanged(
                    s, ev,
                    txtProductNameSearch,
                    SelectedProductId,
                    lstCodeSuggestions,
                    txtProductCodeSearch,
                    cmbUnit,
                    txtSalePrice,
                    txtQuantity,
                    CurrentSalePrice,
                    CurrentConversionFactor,
                    _currentUnitID)
            End Sub

        AddHandler txtProductNameSearch.TextChanged,
            Sub(s, ev)
                _manager.txtProductNameSearch_TextChanged(s, ev, lstNameSuggestions)
            End Sub

        AddHandler txtProductCodeSearch.TextChanged,
            Sub(s, ev)
                _manager.txtProductCodeSearch_TextChanged(s, ev, lstNameSuggestions)
            End Sub

        AddHandler cmbUnit.SelectedIndexChanged,
            Sub(s, ev)
                _manager.cmbUnit_SelectedIndexChanged(
                    s, ev,
                    txtQuantity,
                    txt_totelProduct,
                    txtSalePrice,
                    CurrentConversionFactor,
                    CurrentSalePrice,
                    _currentUnitID)
            End Sub

        lstCodeSuggestions.Visible = False
        lstNameSuggestions.Visible = False
    End Sub

    '══════════════════════════════════════════════════════════════
    ' تفريغ حقول الفاتورة
    '══════════════════════════════════════════════════════════════
    Private Sub cleartxts()
        getnewInvoiceID()
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
        cmbUnit.TextAlign = HorizontalAlignment.Center
        txtSalePrice.TextAlign = HorizontalAlignment.Center
        txtQuantity.TextAlign = HorizontalAlignment.Center
        txt_totelProduct.TextAlign = HorizontalAlignment.Center

        _purchasePriceCache.Clear()
        _stockCache.Clear()
        txt_Customer_Code.Text = "1"
        btn_search_CustomerCode.PerformClick()

        UnlockInvoice()
    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        cleartxts()
    End Sub

    Private Sub LockInvoiceAfterSave()
        _invoiceSaved = True
        btn_add_product.Enabled = False
        Button2.Enabled = False
        _prevBalanceForPrint = ParseDecimal(txt_Customer_Balance.Text.Trim())
        btnSaveInvoice.Enabled = False
    End Sub

    Private Sub UnlockInvoice()
        _invoiceSaved = False
        btn_add_product.Enabled = True
        Button2.Enabled = True
        btnSaveInvoice.Enabled = True
    End Sub

    '══════════════════════════════════════════════════════════════
    ' إعداد DataGridView مع نمط داكن احترافي
    '══════════════════════════════════════════════════════════════
    Private Sub SetupDataGridView(ByVal dgv As DataGridView)
        dgv.AllowUserToAddRows = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False

        Dim darkBg As Color = Color.FromArgb(30, 30, 30)
        Dim darkRow As Color = Color.FromArgb(45, 45, 45)
        Dim darkAlt As Color = Color.FromArgb(55, 55, 55)
        Dim darkHdr As Color = Color.FromArgb(64, 64, 64)
        Dim highlight As Color = Color.FromArgb(0, 122, 204)
        Dim textClr As Color = Color.Gainsboro

        dgv.BackgroundColor = darkBg
        dgv.RowsDefaultCellStyle.BackColor = darkRow
        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAlt
        dgv.DefaultCellStyle.ForeColor = textClr
        dgv.GridColor = Color.FromArgb(80, 80, 80)

        With dgv
            .Columns.Clear()
            .Columns.Add("ColProductID", "ID المنتج")
            .Columns.Add("ColProduct_Code", "كود المنتج")
            .Columns.Add("ColProductName", "اسم المنتج")
            .Columns.Add("ColUnitName", "الوحدة")
            .Columns.Add("ColPrice", "سعر البيع")

            Dim colMinus As New DataGridViewButtonColumn() With {
                .HeaderText = "", .Text = "➖", .Name = "ColQtyMinus",
                .Width = 15, .UseColumnTextForButtonValue = True}
            .Columns.Add(colMinus)

            .Columns.Add("ColQuantity", "الكمية / الوزن")

            Dim colPlus As New DataGridViewButtonColumn() With {
                .HeaderText = "", .Text = "➕", .Name = "ColQtyPlus",
                .Width = 15, .UseColumnTextForButtonValue = True}
            .Columns.Add(colPlus)

            .Columns.Add("ColTotal", "الإجمالي")
            .Columns.Add("ColUnitID", "UnitID")
            .Columns.Add("ColFactor", "Factor")
            .Columns.Add("ColProfit", "Profit")
            .Columns.Add("LastNumScaleBarcode", "lastnum")

            .Columns("ColProductID").Visible = False
            .Columns("ColUnitID").Visible = False
            .Columns("ColFactor").Visible = False
            .Columns("ColProfit").Visible = False
            .Columns("LastNumScaleBarcode").Visible = False

            Dim colDel As New DataGridViewButtonColumn() With {
                .HeaderText = "حذف", .Text = "❌", .Name = "ColDelete",
                .UseColumnTextForButtonValue = True}
            .Columns.Add(colDel)

            .Columns("ColProductName").Width = 230
            .Columns("ColQuantity").Width = 160
            .Columns("ColPrice").DefaultCellStyle.Format = "N2"
            .Columns("ColTotal").DefaultCellStyle.Format = "N2"

            For Each col As DataGridViewColumn In .Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            .RowTemplate.Height = 32
            .ColumnHeadersHeight = 45
            .ColumnHeadersDefaultCellStyle.BackColor = darkHdr
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 15.0!, FontStyle.Bold)
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .DefaultCellStyle.SelectionBackColor = highlight
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Segoe UI", 14.0!)
            .RowHeadersVisible = False
            .DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        End With
    End Sub

    '══════════════════════════════════════════════════════════════
    ' رقم الفاتورة الجديد
    '══════════════════════════════════════════════════════════════
    Private Sub getnewInvoiceID()
        Try
            Using cn = OpenConnection()
                Using cmd As New SqlCommand("SELECT ISNULL(MAX(Invoice_Code),0)+1 AS NextInv FROM SalesHeader;", cn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        txt_Invoice_ID.Text = Convert.ToInt32(result).ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ShowError("خطأ في حساب رقم الفاتورة: " & ex.Message)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' التاريخ والوقت
    '══════════════════════════════════════════════════════════════
    Private Sub UpdateDateTime()
        Dim now As DateTime = DateTime.Now
        Dim arCulture As New CultureInfo("ar-EG")
        lblTime.Text = now.ToString("tt hh:mm:ss", arCulture)
        lblDate.Text = $"{now.ToString("dddd", arCulture)} ، {now.ToString("d", arCulture)} " &
                       $"{now.ToString("MMMM", arCulture)} {now.ToString("yyyy", arCulture)} م"
        UpdateLanguageLabel()
    End Sub

    Private Sub UpdateLanguageLabel()
        Dim lang = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName.ToUpper()
        lblLang.Text = If(lang = "AR", "عربي", "انجليزي")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        UpdateDateTime()
    End Sub

    Private Sub Sales_InputLanguageChanged(sender As Object, e As InputLanguageChangedEventArgs) _
        Handles MyBase.InputLanguageChanged
        UpdateLanguageLabel()
    End Sub

    '══════════════════════════════════════════════════════════════
    ' بحث العميل بالكود (Async)
    '══════════════════════════════════════════════════════════════
    Private Async Sub btn_search_Customer_ID_Click(sender As Object, e As EventArgs) _
        Handles btn_search_CustomerCode.Click
        Await SearchCustomerByCodeAsync(txt_Customer_Code.Text.Trim())
    End Sub

    Private Async Function SearchCustomerByCodeAsync(code As String) As Task
        If String.IsNullOrWhiteSpace(code) Then
            ShowWarning("من فضلك ادخل كود العميل")
            Return
        End If
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand("SELECT CustomerName, CurrentBalance FROM Customers WHERE CustomerCode=@code", cn)
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = code
                    Using rd = Await cmd.ExecuteReaderAsync()
                        If Await rd.ReadAsync() Then
                            txt_Customer_Name.Text = rd("CustomerName").ToString()
                            txt_Customer_Balance.Text = rd("CurrentBalance").ToString()
                        Else
                            ShowInfo("العميل غير موجود")
                            txt_Customer_Name.Clear()
                            txt_Customer_Balance.Clear()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ShowError("خطأ أثناء جلب بيانات العميل: " & ex.Message)
        End Try
    End Function

    Private Async Sub txt_Customer_Code_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txt_Customer_Code.KeyDown
        If e.KeyCode = Keys.Enter Then
            Await SearchCustomerByCodeAsync(txt_Customer_Code.Text.Trim())
        End If
    End Sub

    '══════════════════════════════════════════════════════════════
    ' البحث بالاسم مع Debounce حقيقي (CancellationToken)
    '══════════════════════════════════════════════════════════════
    Private Async Sub txt_Customer_Name_TextChanged(sender As Object, e As EventArgs) _
        Handles txt_Customer_Name.TextChanged
        Dim keyword As String = txt_Customer_Name.Text.Trim()
        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            lstSuggestions.Items.Clear()
            Return
        End If

        _searchCts?.Cancel()
        _searchCts = New CancellationTokenSource()
        Dim token = _searchCts.Token

        Try
            Await Task.Delay(300, token)
            If token.IsCancellationRequested Then Return

            Dim suggestions = Await GetCustomerSuggestionsAsync(keyword, token)
            If token.IsCancellationRequested Then Return

            lstSuggestions.Items.Clear()
            If suggestions.Count > 0 Then
                lstSuggestions.Items.AddRange(suggestions.ToArray())
                lstSuggestions.Visible = True
            Else
                lstSuggestions.Visible = False
            End If
        Catch ex As TaskCanceledException
        End Try
    End Sub

    Private Async Function GetCustomerSuggestionsAsync(keyword As String,
                                                        token As CancellationToken) As Task(Of List(Of String))
        Dim result As New List(Of String)()
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand("SELECT TOP 15 CustomerName FROM Customers WHERE CustomerName LIKE @kw", cn)
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 200).Value = "%" & keyword & "%"
                    Using rd = Await cmd.ExecuteReaderAsync(token)
                        While Await rd.ReadAsync(token)
                            result.Add(rd("CustomerName").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception When Not (TypeOf ex Is TaskCanceledException)
        End Try
        Return result
    End Function

    '══════════════════════════════════════════════════════════════
    ' بحث العميل بالاسم (Async)
    '══════════════════════════════════════════════════════════════
    Private Async Sub btn_search_Customer_name_Click(sender As Object, e As EventArgs) _
        Handles btn_search_Customer_name.Click
        If txt_Customer_Name.TextLength = 0 Then
            ShowWarning("من فضلك ادخل اسم العميل")
            Return
        End If
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand("SELECT CustomerID,CustomerCode,CustomerName,CurrentBalance FROM dbo.Customers WHERE CustomerName=@name", cn)
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = txt_Customer_Name.Text
                    Using rd = Await cmd.ExecuteReaderAsync()
                        If Await rd.ReadAsync() Then
                            Dim custID As Integer = Convert.ToInt32(rd("CustomerID"))
                            txt_Customer_Code.Text = rd("CustomerCode").ToString()
                            txt_Customer_Balance.Text = rd("CurrentBalance").ToString()
                            rd.Close()
                            If Not Await IsCustomerActiveAsync(custID) Then
                                ShowWarning("⚠ هذا العميل غير مُفعل ولا يمكن تنفيذ عملية البيع.")
                            End If
                        Else
                            ShowInfo("العميل غير موجود")
                            txt_Customer_Code.Clear()
                            txt_Customer_Balance.Clear()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ShowError("خطأ أثناء جلب بيانات العميل: " & ex.Message)
        End Try
    End Sub

    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
        If lstSuggestions.SelectedItem IsNot Nothing Then
            txt_Customer_Name.Text = lstSuggestions.SelectedItem.ToString()
            lstSuggestions.Visible = False
            btn_search_Customer_name.PerformClick()
        End If
    End Sub

    '══════════════════════════════════════════════════════════════
    ' اختصارات لوحة المفاتيح
    '══════════════════════════════════════════════════════════════
    Private Sub Sales_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.F Then
            e.SuppressKeyPress = True
            e.Handled = True
            txtProductNameSearch.Focus()
        End If
        If (e.Alt AndAlso e.KeyCode = Keys.F4) OrElse e.KeyCode = Keys.Escape Then
            e.Handled = True
            Me.Close()
        End If

        Select Case e.KeyCode
            Case Keys.F1
                MessageBox.Show(
                    "الاختصارات المتاحة:" & vbCrLf &
                    "F2 : حفظ الفاتورة" & vbCrLf &
                    "F3 : مرتجعات البيع" & vbCrLf &
                    "F4 : حذف الفاتورة" & vbCrLf &
                    "F5 : طباعة الفاتورة" & vbCrLf &
                    "F6 : مسح الحقول" & vbCrLf &
                    "Ctrl+F : بحث" & vbCrLf &
                    "Esc : خروج",
                    "دليل الاختصارات", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case Keys.F2 : btnSaveInvoice.PerformClick()
            Case Keys.F3 : btn_Sales_Returns.PerformClick()
            Case Keys.F4 : btnDelete.PerformClick()
            Case Keys.F6 : cleartxts()
            Case Keys.F5 : Button1.PerformClick()
            Case Keys.Escape : Me.Close()
        End Select
    End Sub

    '══════════════════════════════════════════════════════════════
    ' استقبال الباركود
    '══════════════════════════════════════════════════════════════
    Public Async Sub ProcessBarcodeData(code As String)
        Try
            Dim barcode As String = code.Trim()
            If String.IsNullOrWhiteSpace(barcode) Then Return

            If barcode.StartsWith("99") Then
                Await AddScaleProductToGridAsync(barcode)
            Else
                If Await SearchAndFillProductByBarcodeAsync(barcode) Then
                    txtQuantity.Text = "1"
                    btn_add_product.PerformClick()
                End If
            End If
        Catch ex As Exception
            ShowError("خطأ في معالجة الباركود: " & ex.Message)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' منتجات الميزان (Async)
    '══════════════════════════════════════════════════════════════
    Private Async Function AddScaleProductToGridAsync(ByVal barcodeValue As String) As Task
        Try
            barcodeValue = barcodeValue.Trim()
            If String.IsNullOrWhiteSpace(barcodeValue) Then
                ShowWarning("⚠️ الباركود فارغ.")
                Return
            End If
            If barcodeValue.Length < 13 Then
                ShowWarning("⚠️ باركود الميزان يجب أن يكون 13 رقم على الأقل.")
                Return
            End If
            If Not barcodeValue.StartsWith("99") Then
                ShowWarning("⚠️ هذا ليس باركود ميزان (لا يبدأ بـ 99).")
                Return
            End If

            Dim productCodeStr As String = barcodeValue.Substring(2, 5)
            If Not IsNumeric(productCodeStr) Then
                ShowWarning("⚠️ كود المنتج داخل الباركود غير صالح.")
                Return
            End If

            Dim productID As Integer = CInt(productCodeStr)
            ScalID = productID

            Dim weightStr As String = barcodeValue.Substring(7, 5)
            Dim lastNum As String = barcodeValue.Substring(12, 1)
            If Not IsNumeric(weightStr) Then
                ShowWarning("⚠️ الوزن داخل الباركود غير صالح.")
                Return
            End If

            Dim weightGrams As Decimal = CDec(weightStr)
            Dim dtScale As DataTable = _manager.GetScaleProductByCode(productID)
            If dtScale Is Nothing OrElse dtScale.Rows.Count = 0 Then
                ShowInfo($"⚠️ لا يوجد منتج لهذا الكود: {productCodeStr}")
                Return
            End If

            Dim row As DataRow = dtScale.Rows(0)
            Dim productName As String = row("Name").ToString()
            Dim dbPrice As Decimal = CDec(row("Price"))
            Dim weightKg As Decimal = weightGrams / 1000D
            Dim totalPrice As Decimal = weightKg * dbPrice

            Dim profit As Decimal = Await Task.Run(Function() GetScaleProductProfitFromDB(productID, weightKg))

            Dim newRow As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add())
            newRow.Cells("LastNumScaleBarcode").Value = lastNum
            newRow.Cells("ColProductID").Value = productID
            newRow.Cells("ColProduct_Code").Value = productID
            newRow.Cells("ColProductName").Value = productName
            newRow.Cells("ColUnitName").Value = "جرام"
            newRow.Cells("ColPrice").Value = dbPrice
            newRow.Cells("ColQuantity").Value = weightGrams
            newRow.Cells("ColProfit").Value = profit
            newRow.Cells("ColTotal").Value = Math.Round(totalPrice, 2)

            UpdateInvoiceTotals()
        Catch ex As Exception
            ShowError("❌ خطأ أثناء إضافة منتج الميزان: " & ex.Message)
        End Try
    End Function

    Private Function GetScaleProductProfitFromDB(productID As Integer, weightKg As Decimal) As Decimal
        Try
            Using cn = OpenConnection()
                Using cmd As New SqlCommand("SELECT Price, Purchase_Price FROM TheScale WHERE Code=@Code", cn)
                    cmd.Parameters.Add("@Code", SqlDbType.Int).Value = productID
                    Using rd = cmd.ExecuteReader()
                        If rd.Read() Then
                            Dim pp As Decimal = If(IsDBNull(rd("Purchase_Price")), 0, CDec(rd("Purchase_Price")))
                            Dim sp As Decimal = If(IsDBNull(rd("Price")), 0, CDec(rd("Price")))
                            Return (sp - pp) * weightKg
                        End If
                    End Using
                End Using
            End Using
        Catch
        End Try
        Return 0D
    End Function

    Private Async Function SearchAndFillProductByBarcodeAsync(ByVal barcodeValue As String) As Task(Of Boolean)
        Try
            Dim dtUnit As DataTable = _manager.GetUnitByBarcode(barcodeValue)
            If dtUnit.Rows.Count = 1 Then
                Dim row As DataRow = dtUnit.Rows(0)
                SelectedProductId = CInt(row("Product_ID").ToString())
                txtProductNameSearch.Text = row("Product_Name").ToString()
                If lstNameSuggestions.Items.Count > 0 Then lstNameSuggestions.SelectedIndex = 0
                cmbUnit.Text = row("Unit_Name").ToString()
                txtSalePrice.Text = row("Sale_Price").ToString()
                Return True
            Else
                ShowWarning($"لا يوجد منتج مرتبط بالباركود: {barcodeValue}")
                Return False
            End If
        Catch ex As Exception
            ShowError("خطأ في البحث عن الباركود: " & ex.Message)
            Return False
        End Try
    End Function

    '══════════════════════════════════════════════════════════════
    ' الحسابات: سعر × كمية
    '══════════════════════════════════════════════════════════════
    Private Sub sale_p_product()
        Dim qty, price As Decimal
        If Decimal.TryParse(txtQuantity.Text, qty) AndAlso
           Decimal.TryParse(txtSalePrice.Text, price) Then
            txt_totelProduct.Text = (price * qty).ToString("0.##")
        Else
            txt_totelProduct.Text = ""
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        sale_p_product()
    End Sub
    Private Sub txtSalePrice_TextChanged(sender As Object, e As EventArgs) Handles txtSalePrice.TextChanged
        sale_p_product()
    End Sub
    Private Sub cmbUnit_TextChanged(sender As Object, e As EventArgs) Handles cmbUnit.TextChanged
        sale_p_product()
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then btn_add_product.PerformClick()
    End Sub

    Private Sub txtProductNameSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductNameSearch.KeyDown
        If e.KeyCode = Keys.Down Then lstNameSuggestions.Focus()
    End Sub

    '══════════════════════════════════════════════════════════════
    ' المخزون المتاح (Async مع Cache)
    '══════════════════════════════════════════════════════════════
    Private Async Function GetStockQtyAsync(productId As Integer) As Task(Of Decimal)
        If _stockCache.ContainsKey(productId) Then Return _stockCache(productId)

        Dim stockQty As Decimal = 0D
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand("SELECT Quantity_OnHand FROM Stock WHERE Product_ID=@PID", cn)
                    cmd.Parameters.Add("@PID", SqlDbType.Int).Value = productId
                    Dim result = Await cmd.ExecuteScalarAsync()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        stockQty = Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            ShowError("خطأ في جلب المخزون: " & ex.Message)
        End Try

        _stockCache(productId) = stockQty
        Return stockQty
    End Function

    ' Cache سعر الشراء
    Private Function GetPurchasePriceFromCache(productId As Integer, unitId As Integer) As Decimal
        Dim key As String = $"{productId}_{unitId}"
        If _purchasePriceCache.ContainsKey(key) Then Return _purchasePriceCache(key)

        Dim result As Decimal = 0D
        Try
            Using cn = OpenConnection()
                Using cmd As New SqlCommand("SELECT Purchase_Price FROM ProductUnits WHERE Product_ID=@P AND ProductUnit_ID=@U", cn)
                    cmd.Parameters.Add("@P", SqlDbType.Int).Value = productId
                    cmd.Parameters.Add("@U", SqlDbType.Int).Value = unitId
                    Dim val = cmd.ExecuteScalar()
                    If val IsNot Nothing AndAlso Not IsDBNull(val) Then result = CDec(val)
                End Using
            End Using
        Catch
        End Try

        _purchasePriceCache(key) = result
        Return result
    End Function

    '══════════════════════════════════════════════════════════════
    ' التحقق من حالة المنتج (Async)
    '══════════════════════════════════════════════════════════════
    Public Async Function CheckProductStatusAsync(productId As Integer) As Task(Of Boolean)
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand("SELECT Product_Name, Product_State FROM Products WHERE Product_ID=@id", cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = productId
                    Using rd = Await cmd.ExecuteReaderAsync()
                        If Await rd.ReadAsync() Then
                            Dim pName As String = rd("Product_Name").ToString()
                            Dim isActive As Boolean = Convert.ToBoolean(rd("Product_State"))
                            If isActive Then Return True
                            ShowWarning($"⚠️ المنتج غير نشط ولا يمكن استخدامه حالياً.{vbCrLf}" &
                                        $"📦 اسم المنتج: {pName}{vbCrLf}🔍 كود المنتج: {productId}")
                            Return False
                        Else
                            ShowError("❌ لم يتم العثور على المنتج المطلوب.")
                            Return False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ShowError("حدث خطأ: " & ex.Message)
            Return False
        End Try
    End Function

    '══════════════════════════════════════════════════════════════
    ' إضافة المنتج للفاتورة (Async)
    '══════════════════════════════════════════════════════════════
    Private Async Sub btn_add_product_Click(sender As Object, e As EventArgs) Handles btn_add_product.Click
        If _invoiceSaved Then
            ShowWarning("تم حفظ الفاتورة بالفعل. اضغط (مسح / حذف) لبدء فاتورة جديدة قبل إضافة منتجات.")
            Return
        End If
        If Me.SelectedProductId <= 0 Then
            ShowWarning("الرجاء اختيار منتج أولاً.")
            Return
        End If
        Dim qty As Decimal
        If Not Decimal.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
            ShowWarning("الرجاء إدخال كمية صحيحة.")
            txtQuantity.Focus()
            Return
        End If

        If Not Await CheckProductStatusAsync(SelectedProductId) Then Return

        Await UpdateExistingRowOrAddAsync()

        ClearProductFields()
        UpdateInvoiceTotals()
        _stockCache.Remove(SelectedProductId)
        SelectedProductId = 0
        txtProductNameSearch.Focus()
    End Sub

    Private Sub ClearProductFields()
        getnewInvoiceID()
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
        txtSalePrice.TextAlign = HorizontalAlignment.Center
        txtQuantity.TextAlign = HorizontalAlignment.Center
        txt_totelProduct.TextAlign = HorizontalAlignment.Center
    End Sub

    Private Function GetReservedQty(productId As Integer) As Decimal
        Dim total As Decimal = 0D
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For
            Try
                Dim pid As Integer = 0
                If Not Integer.TryParse(row.Cells("ColProductID").Value?.ToString(), pid) Then Continue For
                If pid <> productId Then Continue For

                Dim rowQty As Decimal = 0D
                Dim rowFactor As Decimal = 1D
                Decimal.TryParse(row.Cells("ColQuantity").Value?.ToString(), rowQty)
                If DataGridView1.Columns.Contains("ColFactor") Then
                    Dim fo As Decimal = 1D
                    If Decimal.TryParse(row.Cells("ColFactor").Value?.ToString(), fo) AndAlso fo > 0D Then
                        rowFactor = fo
                    End If
                End If
                total += rowQty * rowFactor
            Catch
            End Try
        Next
        Return total
    End Function

    Private Async Function UpdateExistingRowOrAddAsync() As Task
        If Not DataGridView1.Columns.Contains("ColFactor") Then SetupDataGridView(DataGridView1)

        Dim qtyToAdd As Decimal
        If Not Decimal.TryParse(txtQuantity.Text.Trim(), qtyToAdd) OrElse qtyToAdd <= 0D Then
            ShowError("❌ الكمية غير صالحة.")
            Return
        End If

        Dim dgv As DataGridView = DataGridView1
        Dim currentProductId As Integer = SelectedProductId
        Dim currentProductCode As String = txtProductCodeSearch.Text.Trim()
        Dim currentProductName As String = txtProductNameSearch.Text.Trim()
        Dim currentUnitName As String = cmbUnit.Text.Trim()
        Dim price As Decimal = CurrentSalePrice

        If Session.HasPermission("Sales", "CanEdit") Then
            Dim txtPrice As Decimal = 0D
            If Decimal.TryParse(txtSalePrice.Text, txtPrice) AndAlso price <> txtPrice Then
                price = txtPrice
            End If
        End If

        Dim unitId As Integer = _currentUnitID
        Dim factor As Decimal = CurrentConversionFactor

        Dim stockQty As Decimal = Await GetStockQtyAsync(currentProductId)
        Dim reservedQty As Decimal = GetReservedQty(currentProductId)
        Dim purchasePrice As Decimal = GetPurchasePriceFromCache(currentProductId, unitId)
        Dim profitPerUnit As Decimal = price - purchasePrice

        Dim rowFound As DataGridViewRow = Nothing
        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For
            Dim pid As Integer = 0
            Integer.TryParse(row.Cells("ColProductID").Value?.ToString(), pid)
            If pid = currentProductId AndAlso
               row.Cells("ColProductName").Value?.ToString().Trim() = currentProductName AndAlso
               row.Cells("ColUnitName").Value?.ToString().Trim() = currentUnitName Then
                rowFound = row
                Exit For
            End If
        Next

        If rowFound IsNot Nothing Then
            Dim existingQty As Decimal = 0D
            Decimal.TryParse(rowFound.Cells("ColQuantity").Value?.ToString(), existingQty)
            Dim oldContrib As Decimal = existingQty * factor
            Dim newQty As Decimal = existingQty + qtyToAdd
            Dim needed As Decimal = (reservedQty - oldContrib) + (newQty * factor)

            If needed > stockQty Then
                ShowWarning("❌ الكمية غير متاحة.")
                Return
            End If

            rowFound.Cells("ColQuantity").Value = newQty
            rowFound.Cells("ColPrice").Value = price
            rowFound.Cells("ColTotal").Value = Math.Round(newQty * price, 2)
            rowFound.Cells("ColProfit").Value = Math.Round(profitPerUnit * newQty, 2)
            rowFound.Cells("ColUnitID").Value = unitId
            rowFound.Cells("ColFactor").Value = factor
        Else
            Dim needed As Decimal = reservedQty + (qtyToAdd * factor)
            If needed > stockQty Then
                ShowWarning("❌ الكمية غير متاحة.")
                Return
            End If

            Dim newRow As DataGridViewRow = dgv.Rows(dgv.Rows.Add())
            newRow.Cells("LastNumScaleBarcode").Value = ""
            newRow.Cells("ColProductID").Value = currentProductId
            newRow.Cells("ColProduct_Code").Value = currentProductCode
            newRow.Cells("ColProductName").Value = currentProductName
            newRow.Cells("ColUnitName").Value = currentUnitName
            newRow.Cells("ColPrice").Value = price
            newRow.Cells("ColQuantity").Value = qtyToAdd
            newRow.Cells("ColProfit").Value = Math.Round(profitPerUnit * qtyToAdd, 2)
            newRow.Cells("ColTotal").Value = Math.Round(qtyToAdd * price, 2)
            newRow.Cells("ColUnitID").Value = unitId
            newRow.Cells("ColFactor").Value = factor
        End If
    End Function

    '══════════════════════════════════════════════════════════════
    ' تحديث إجمالي الفاتورة
    '══════════════════════════════════════════════════════════════
    Private Sub UpdateInvoiceTotals()
        Dim grandTotal As Decimal = 0D
        DataGridView1.SuspendLayout()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow AndAlso row.Cells("ColTotal").Value IsNot Nothing Then
                grandTotal += Convert.ToDecimal(row.Cells("ColTotal").Value)
            End If
        Next
        DataGridView1.ResumeLayout()

        txtTotalRequired.Text = grandTotal.ToString("N2")
        RecalculateTotals()
    End Sub

    '══════════════════════════════════════════════════════════════
    ' أزرار ➕ ➖ في الجريد (Async)
    '══════════════════════════════════════════════════════════════
    Private Async Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim dgv = DataGridView1

        ' حذف الصف
        If e.ColumnIndex = dgv.Columns("ColDelete").Index Then
            Dim pName As String = Convert.ToString(dgv.Rows(e.RowIndex).Cells("ColProductName").Value)
            If MessageBox.Show($"هل أنت متأكد من حذف الصنف ({pName}) من الفاتورة؟",
                               "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim pid As Integer = 0
                Integer.TryParse(dgv.Rows(e.RowIndex).Cells("ColProductID").Value?.ToString(), pid)
                dgv.Rows.RemoveAt(e.RowIndex)
                If pid > 0 Then _stockCache.Remove(pid)
                UpdateInvoiceTotals()
                ShowInfo("تم حذف الصنف.")
            End If
            Return
        End If

        Dim colName As String = dgv.Columns(e.ColumnIndex).Name
        If colName <> "ColQtyPlus" AndAlso colName <> "ColQtyMinus" Then Return

        Dim row = dgv.Rows(e.RowIndex)
        Dim isUnknown As Boolean = Convert.ToString(row.Cells("ColUnitName").Value) = "غير معرف"

        Dim qty As Decimal = 0D
        Decimal.TryParse(Convert.ToString(row.Cells("ColQuantity").Value), qty)
        Dim price As Decimal = 0D
        Decimal.TryParse(Convert.ToString(row.Cells("ColPrice").Value), price)
        Dim productId As Integer = 0
        Integer.TryParse(Convert.ToString(row.Cells("ColProductID").Value), productId)
        Dim unitId As Integer = 0
        Integer.TryParse(Convert.ToString(row.Cells("ColUnitID").Value), unitId)

        Dim stockQty As Decimal = Decimal.MaxValue
        If Not isUnknown Then
            stockQty = Await GetStockQtyAsync(productId)
        End If

        Dim purchasePrice As Decimal = If(isUnknown, 0D, GetPurchasePriceFromCache(productId, unitId))
        Dim profitPerUnit As Decimal = price - purchasePrice

        If colName = "ColQtyPlus" Then
            Dim newQty As Decimal = qty + 1
            If Not isUnknown AndAlso newQty > stockQty Then
                ShowWarning("❌ لا يمكن إضافة هذه الكمية. المخزون المتاح: " & stockQty)
                Return
            End If
            qty = newQty
        ElseIf colName = "ColQtyMinus" Then
            qty -= 1
            If qty <= 0 Then
                dgv.Rows.RemoveAt(e.RowIndex)
                If Not isUnknown AndAlso productId > 0 Then _stockCache.Remove(productId)
                UpdateInvoiceTotals()
                Return
            End If
        End If

        row.Cells("ColQuantity").Value = qty
        row.Cells("ColTotal").Value = Math.Round(qty * price, 2)
        row.Cells("ColProfit").Value = Math.Round(qty * profitPerUnit, 2)
        If Not isUnknown Then _stockCache.Remove(productId)
        UpdateInvoiceTotals()
    End Sub

    '══════════════════════════════════════════════════════════════
    ' الحسابات المالية الموحدة
    '══════════════════════════════════════════════════════════════
    Private Sub txtTotalRequired_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRequired.TextChanged
        If Not _isRecalculating Then RecalculateTotals()
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        If _isRecalculating Then Return
        If txtDiscount.TextLength = 0 Then
            _isRecalculating = True
            txtDiscount.Text = "0"
            _isRecalculating = False
        End If
        RecalculateTotals()
    End Sub

    Private Sub txtPaid_TextChanged(sender As Object, e As EventArgs) Handles txtPaid.TextChanged
        If _isRecalculating Then Return
        If txtPaid.TextLength = 0 Then
            _isRecalculating = True
            txtPaid.Text = "0"
            _isRecalculating = False
        End If
        RecalculateTotals()
    End Sub

    Private Sub cmb_Pay_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cmb_Pay.SelectedIndexChanged
        Select Case cmb_Pay.Text
            Case "كاش", "نقدي"
                txtRemaining.Visible = True
                txtPaid.Visible = True
                lblRemaining.Visible = True
                lblPaid.Visible = True
                btn_auto_pay.Visible = True
            Case "آجل"
                _isRecalculating = True
                txtPaid.Text = "0"
                _isRecalculating = False
                txtPaid.Visible = False
                lblPaid.Visible = False
                btn_auto_pay.Visible = False
        End Select
        RecalculateTotals()
    End Sub

    Private Sub RecalculateTotals()
        If _isRecalculating Then Return
        _isRecalculating = True
        Try
            Dim totalRequired As Decimal
            If Not Decimal.TryParse(txtTotalRequired.Text, totalRequired) Then
                txtTotalAfterDiscount.Text = ""
                txtRemaining.Text = ""
                Return
            End If

            Dim discount As Decimal = 0D
            If _discountEnabled Then Decimal.TryParse(txtDiscount.Text, discount)

            If discount > totalRequired Then
                ShowWarning("⚠️ قيمة الخصم لا يمكن أن تتجاوز المبلغ المطلوب!")
                txtDiscount.Text = "0"
                discount = 0D
            End If

            Dim afterDiscount As Decimal = totalRequired - discount
            txtTotalAfterDiscount.Text = afterDiscount.ToString("0.##")

            Dim paid As Decimal = 0D
            Decimal.TryParse(txtPaid.Text, paid)
            Dim remaining As Decimal = paid - afterDiscount
            txtRemaining.Text = remaining.ToString("0.##")
            txtRemaining.ForeColor = If(remaining < 0, Color.Red,
                                        If(remaining > 0, Color.Green, Color.Black))
        Finally
            _isRecalculating = False
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' دوال مساعدة للعميل
    '══════════════════════════════════════════════════════════════
    Private Async Function GetCustomerIDAsync(customerCode As String) As Task(Of Integer)
        Dim customerID As Integer = 0
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand("SELECT CustomerID FROM Customers WHERE CustomerCode=@code", cn)
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
                    Dim obj = Await cmd.ExecuteScalarAsync()
                    If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                        Integer.TryParse(obj.ToString(), customerID)
                    Else
                        ShowWarning("لم يتم العثور على عميل بهذا الكود.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            ShowError("خطأ أثناء التحقق من العميل: " & ex.Message)
        End Try
        Return customerID
    End Function

    Public Async Function IsCustomerActiveAsync(customerId As Integer) As Task(Of Boolean)
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand("SELECT CAST(IsActive AS INT) FROM Customers WHERE CustomerID=@id", cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = customerId
                    Dim val = Await cmd.ExecuteScalarAsync()
                    Return val IsNot Nothing AndAlso Convert.ToInt32(val) = 1
                End Using
            End Using
        Catch ex As Exception
            ShowError("خطأ في التحقق من حالة العميل: " & ex.Message)
            Return False
        End Try
    End Function

    '══════════════════════════════════════════════════════════════
    ' حفظ الفاتورة (Async + Transaction)
    '══════════════════════════════════════════════════════════════
    Private Async Sub btn_SaveInvoice_Click(sender As Object, e As EventArgs) Handles btnSaveInvoice.Click
        If String.IsNullOrWhiteSpace(txt_Customer_Code.Text) OrElse
           String.IsNullOrWhiteSpace(txt_Customer_Name.Text) OrElse
           String.IsNullOrWhiteSpace(txt_Customer_Balance.Text) Then
            ShowWarning("الرجاء التأكد من بيانات العميل أولاً.")
            txt_Customer_Name.Focus()
            Return
        End If
        If DataGridView1.Rows.Cast(Of DataGridViewRow)().All(Function(r) r.IsNewRow) Then
            ShowWarning("يجب إضافة المنتجات للفاتورة أولاً.")
            Return
        End If

        Dim customerCode As String = txt_Customer_Code.Text.Trim()
        Dim customerID As Integer = Await GetCustomerIDAsync(customerCode)
        If customerID = 0 Then Return
        If Not Await IsCustomerActiveAsync(customerID) Then
            ShowWarning("⚠ هذا العميل غير مُفعل ولا يمكن تنفيذ عملية البيع.")
            Return
        End If
        Dim customerPreviousBalance As Decimal = ParseDecimal(txt_Customer_Balance.Text)

        Dim totalBefore As Decimal = ParseDecimal(txtTotalRequired.Text)
        Dim totalAfter As Decimal = ParseDecimal(txtTotalAfterDiscount.Text)
        Dim discount As Decimal = ParseDecimal(txtDiscount.Text)
        Dim paid As Decimal = ParseDecimal(txtPaid.Text)
        Dim remaining As Decimal = ParseDecimal(txtRemaining.Text)
        Dim notes As String = txt_notes.Text.Trim()
        Dim userID As Integer = Session.CurrentUserID
        Dim userName As String = lbl_user_name.Text.Trim()
        Dim paymentType As String = cmb_Pay.Text.Trim()
        Dim invoiceCode As Integer = 0

        If Not Integer.TryParse(txt_Invoice_ID.Text.Trim(), invoiceCode) OrElse invoiceCode <= 0 Then
            ShowError("رقم الفاتورة غير صالح.")
            Return
        End If

        btnSaveInvoice.Enabled = False
        Try
            Dim newInvoiceID As Integer = 0
            Dim totalProfit As Decimal = 0D

            Dim gridData = CollectGridData()

            Await Task.Run(Async Function()
                               Using cn = Await OpenConnectionAsync()
                                   Using transaction As SqlTransaction = cn.BeginTransaction(IsolationLevel.ReadCommitted)
                                       Try
                                           newInvoiceID = InsertSalesHeader(invoiceCode, customerID,
                                               totalBefore, totalAfter, discount, paid, remaining,
                                               notes, userID, userName, paymentType, SelectedTreasuryid, customerPreviousBalance, cn, transaction)

                                           InsertSalesDetailsAndUpdateStock(newInvoiceID, gridData, cn, transaction)

                                           totalProfit = gridData.Sum(Function(r) r.Profit)
                                           UpdateInvoiceProfitSync(newInvoiceID, totalProfit, cn, transaction)

                                           If Not CheckCreditLimitSync(customerCode, remaining, cn, transaction) Then
                                               Throw New Exception("تم رفض العملية: تجاوز حد الائتمان المسموح به للعميل.")
                                           End If

                                           UpdateCustomerBalanceSync(customerCode, remaining, cn, transaction)
                                           If paid > 0D Then
                                               Await TreasuryService.AddTransactionAsync(
                                                       treasuryID:=SelectedTreasuryid,
                                                       transactionType:=TreasuryTransactionTypes.Sale,
                                                       amount:=paid,
                                                       isDeposit:=True,
                                                       referenceID:=newInvoiceID,
                                                       referenceNo:=invoiceCode.ToString(),
                                                       notes:="فاتورة بيع رقم " & invoiceCode,
                                                       userID:=userID,
                                                       cn:=cn,
                                                       trans:=transaction)
                                           End If
                                           transaction.Commit()
                                       Catch ex As Exception
                                           Try : transaction.Rollback() : Catch : End Try
                                           Throw
                                       End Try
                                   End Using
                               End Using
                           End Function)

            _currentIDV = newInvoiceID
            LockInvoiceAfterSave()

            MessageBox.Show($"✅ تم حفظ الفاتورة رقم {newInvoiceID} بنجاح.",
                            "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txt_Customer_Code.Text = customerCode
            Await SearchCustomerByCodeAsync(customerCode)

            If _isSendToWhatsApp Then
                Dim phone As String = Await GetCustomerPhoneAsync(customerCode)
                If IsInternetAvailable() Then
                    Await SendInvoiceWhatsAppAsync(newInvoiceID, phone)
                Else
                    ShowWarning("لا يتوفر اتصال بالانترنت!")
                End If
            End If

        Catch ex As Exception
            ShowError("❌ فشل الحفظ. تم التراجع عن التغييرات. الخطأ: " & ex.Message)
        Finally
            If Not _invoiceSaved Then btnSaveInvoice.Enabled = True
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' جمع بيانات الـ Grid في قائمة موحدة
    '══════════════════════════════════════════════════════════════
    Private Function CollectGridData() As List(Of InvoiceLineData)
        Dim result As New List(Of InvoiceLineData)()
        Dim hasScaleCol As Boolean = DataGridView1.Columns.Contains("colIsScaleProduct")

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For

            Dim line As New InvoiceLineData With {
                .ProductID = ParseInt(row.Cells("ColProductID").Value),
                .ProductName = Convert.ToString(row.Cells("ColProductName").Value),
                .UnitID = ParseInt(row.Cells("ColUnitID").Value),
                .UnitName = Convert.ToString(row.Cells("ColUnitName").Value),
                .SalePrice = ParseDecimal(Convert.ToString(row.Cells("ColPrice").Value)),
                .Quantity = ParseDecimal(Convert.ToString(row.Cells("ColQuantity").Value)),
                .Total = ParseDecimal(Convert.ToString(row.Cells("ColTotal").Value)),
                .Factor = ParseDecimal(Convert.ToString(row.Cells("ColFactor").Value)),
                .Profit = ParseDecimal(Convert.ToString(row.Cells("ColProfit").Value)),
                .PurchasePriceAtSale = 0D,
                .IsNewLine = True
            }

            If hasScaleCol AndAlso row.Cells("colIsScaleProduct").Value IsNot Nothing Then
                line.SetScaleProductFlag(Convert.ToBoolean(row.Cells("colIsScaleProduct").Value))
            End If

            result.Add(line)
        Next
        Return result
    End Function

    '══════════════════════════════════════════════════════════════
    ' كلاس بيانات سطر الفاتورة
    '══════════════════════════════════════════════════════════════
    Private Class InvoiceLineData
        Public Property ProductID As Integer
        Public Property ProductName As String
        Public Property UnitID As Integer
        Public Property UnitName As String
        Public Property SalePrice As Decimal
        Public Property Quantity As Decimal
        Public Property Total As Decimal
        Public Property Factor As Decimal
        Public Property Profit As Decimal
        Public Property PurchasePriceAtSale As Decimal
        Public Property IsNewLine As Boolean

        Private _isScaleFlag As Boolean? = Nothing

        Public Sub SetScaleProductFlag(value As Boolean)
            _isScaleFlag = value
        End Sub

        Public ReadOnly Property IsScaleProduct As Boolean
            Get
                If _isScaleFlag.HasValue Then Return _isScaleFlag.Value
                Return UnitName = "جرام" OrElse UnitName = "جم"
            End Get
        End Property
    End Class

    '══════════════════════════════════════════════════════════════
    ' إدراج رأس الفاتورة
    '══════════════════════════════════════════════════════════════
    Private Function InsertSalesHeader(invoiceCode As Integer, customerID As Integer,
                                       totalBefore As Decimal, totalAfter As Decimal,
                                       discountVal As Decimal, paid As Decimal, remaining As Decimal,
                                       notes As String, userID As Integer, userName As String,
                                       paymentType As String, Treasuryid As Integer,
                                       customerPreviousBalance As Decimal,
                                       cn As SqlConnection, tx As SqlTransaction) As Integer

        Using checkCmd As New SqlCommand("SELECT COUNT(*) FROM SalesHeader WHERE Invoice_Code=@ic", cn, tx)
            checkCmd.Parameters.Add("@ic", SqlDbType.Int).Value = invoiceCode
            If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                Throw New Exception("كود الفاتورة موجود بالفعل.")
            End If
        End Using

        Dim sql As String =
            "INSERT INTO SalesHeader(Invoice_Code,Invoice_type,Invoice_Date,Customer_ID," &
            "User_ID,User_Name,Total_Amount,Discount_Value,Net_Amount,Amount_Paid,Remaining,Payment_Method,Notes,Treasuryid,PreviousBalance)" &
            " VALUES(@ic,@it,GETDATE(),@cid,@uid,@un,@ta,@dv,@na,@ap,@rem,@pm,@nt,@Tid,@CPB);" &
            " SELECT SCOPE_IDENTITY();"

        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@ic", SqlDbType.Int).Value = invoiceCode
            cmd.Parameters.Add("@it", SqlDbType.NVarChar, 50).Value = "فاتورة مبيعات"
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = customerID
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userID
            cmd.Parameters.Add("@un", SqlDbType.NVarChar, 200).Value = userName
            cmd.Parameters.Add("@ta", SqlDbType.Decimal).Value = totalAfter
            cmd.Parameters.Add("@dv", SqlDbType.Decimal).Value = discountVal
            cmd.Parameters.Add("@na", SqlDbType.Decimal).Value = totalBefore
            cmd.Parameters.Add("@ap", SqlDbType.Decimal).Value = paid
            cmd.Parameters.Add("@rem", SqlDbType.Decimal).Value = remaining
            cmd.Parameters.Add("@pm", SqlDbType.NVarChar, 50).Value = paymentType
            cmd.Parameters.Add("@nt", SqlDbType.NVarChar, 500).Value = notes
            cmd.Parameters.Add("@Tid", SqlDbType.Int).Value = Treasuryid
            cmd.Parameters.Add("@CPB", SqlDbType.Decimal).Value = customerPreviousBalance
            Dim obj = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Return CInt(obj)
            End If
            Throw New Exception("فشل إنشاء رقم الفاتورة (SCOPE_IDENTITY).")
        End Using
    End Function

    '══════════════════════════════════════════════════════════════
    ' إدراج تفاصيل الفاتورة الجديدة وتحديث المخزون
    '══════════════════════════════════════════════════════════════
    Private Sub InsertSalesDetailsAndUpdateStock(invoiceID As Integer,
                                                 lines As List(Of InvoiceLineData),
                                                 cn As SqlConnection, tx As SqlTransaction)
        If lines Is Nothing OrElse lines.Count = 0 Then Return

        Dim regularItems As New List(Of (ProductID As Integer, UnitID As Integer))
        Dim scaleItems As New List(Of Integer)

        For Each line In lines
            If line.ProductID <= 0 Then Continue For
            If line.IsScaleProduct Then
                If Not scaleItems.Contains(line.ProductID) Then
                    scaleItems.Add(line.ProductID)
                End If
            Else
                Dim exists = regularItems.Any(Function(x) x.ProductID = line.ProductID AndAlso x.UnitID = line.UnitID)
                If Not exists Then regularItems.Add((line.ProductID, line.UnitID))
            End If
        Next

        Dim purchasePriceRegular As New Dictionary(Of String, Decimal)
        If regularItems.Count > 0 Then
            Dim conditions As New List(Of String)
            Using cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.Transaction = tx
                For i As Integer = 0 To regularItems.Count - 1
                    Dim pParam = "@p" & i.ToString()
                    Dim uParam = "@u" & i.ToString()
                    conditions.Add("(Product_ID=" & pParam & " AND ProductUnit_ID=" & uParam & ")")
                    cmd.Parameters.Add(pParam, SqlDbType.Int).Value = regularItems(i).ProductID
                    cmd.Parameters.Add(uParam, SqlDbType.Int).Value = regularItems(i).UnitID
                Next
                cmd.CommandText =
                    "SELECT Product_ID, ProductUnit_ID, ISNULL(Purchase_Price,0) AS Purchase_Price " &
                    "FROM ProductUnits WHERE " & String.Join(" OR ", conditions)
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim pid = Convert.ToInt32(rd("Product_ID"))
                        Dim uid = Convert.ToInt32(rd("ProductUnit_ID"))
                        purchasePriceRegular(MakeProductUnitKey(pid, uid)) = Convert.ToDecimal(rd("Purchase_Price"))
                    End While
                End Using
            End Using
        End If

        Dim purchasePriceScale As New Dictionary(Of Integer, Decimal)
        If scaleItems.Count > 0 Then
            Dim paramNames As New List(Of String)
            Using cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.Transaction = tx
                For i As Integer = 0 To scaleItems.Count - 1
                    Dim pParam = "@s" & i.ToString()
                    paramNames.Add(pParam)
                    cmd.Parameters.Add(pParam, SqlDbType.Int).Value = scaleItems(i)
                Next
                cmd.CommandText =
                    "SELECT Code, ISNULL(Purchase_Price,0) AS Purchase_Price " &
                    "FROM TheScale WHERE Code IN (" & String.Join(",", paramNames) & ")"
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        purchasePriceScale(Convert.ToInt32(rd("Code"))) = Convert.ToDecimal(rd("Purchase_Price"))
                    End While
                End Using
            End Using
        End If

        For Each line In lines
            Dim purchasePriceAtSale As Decimal = 0D
            Dim lineProfit As Decimal = 0D

            If line.IsScaleProduct Then
                Dim weightKg As Decimal = line.Quantity / 1000D
                purchasePriceAtSale = If(purchasePriceScale.ContainsKey(line.ProductID), purchasePriceScale(line.ProductID), 0D)
                lineProfit = (line.SalePrice - purchasePriceAtSale) * weightKg
            Else
                Dim key = MakeProductUnitKey(line.ProductID, line.UnitID)
                purchasePriceAtSale = If(purchasePriceRegular.ContainsKey(key), purchasePriceRegular(key), 0D)
                lineProfit = (line.SalePrice - purchasePriceAtSale) * line.Quantity
            End If

            line.PurchasePriceAtSale = purchasePriceAtSale
            line.Profit = lineProfit

            Using cmd As New SqlCommand(
                "INSERT INTO SalesDetails(Invoice_ID, Product_ID, Product_Name, ProductUnit_ID, ProductUnit_Name," &
                "Quantity_Sold, Sale_Price_Per_Unit, Total_Line_Amount, Purchase_Price_At_Sale, Profit)" &
                " VALUES(@inv, @pid, @pn, @uid, @un, @qty, @price, @total, @ppa, @profit);", cn, tx)
                cmd.Parameters.Add("@inv", SqlDbType.Int).Value = invoiceID
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = line.ProductID
                cmd.Parameters.Add("@pn", SqlDbType.NVarChar, 300).Value = line.ProductName
                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = line.UnitID
                cmd.Parameters.Add("@un", SqlDbType.NVarChar, 100).Value = line.UnitName
                cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = line.Quantity
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = line.SalePrice
                cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = line.Total
                cmd.Parameters.Add("@ppa", SqlDbType.Decimal).Value = purchasePriceAtSale
                cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = lineProfit
                cmd.ExecuteNonQuery()
            End Using

            If line.IsScaleProduct OrElse line.ProductID <= 0 Then Continue For
            Dim qtyToDeduct As Decimal = line.Quantity * If(line.Factor > 0D, line.Factor, 1D)
            Using cmd As New SqlCommand("UPDATE Stock SET Quantity_OnHand = Quantity_OnHand - @qty WHERE Product_ID = @pid;", cn, tx)
                cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = qtyToDeduct
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = line.ProductID
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub UpdateInvoiceProfitSync(invoiceID As Integer, profit As Decimal,
                                         cn As SqlConnection, tx As SqlTransaction)
        Using cmd As New SqlCommand("UPDATE SalesHeader SET Total_Profit=@p WHERE Invoice_ID=@id", cn, tx)
            cmd.Parameters.Add("@p", SqlDbType.Decimal).Value = profit
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function CheckCreditLimitSync(customerCode As String, remaining As Decimal,
                                          cn As SqlConnection, tx As SqlTransaction) As Boolean
        Dim balanceBefore As Decimal = 0D, creditLimit As Decimal = 0D
        Using cmd As New SqlCommand("SELECT ISNULL(CurrentBalance,0), ISNULL(CreditLimit,0) FROM Customers WHERE CustomerCode=@code", cn, tx)
            cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    balanceBefore = Convert.ToDecimal(rd(0))
                    creditLimit = Convert.ToDecimal(rd(1))
                End If
            End Using
        End Using

        Dim balanceAfter As Decimal = balanceBefore + remaining
        If creditLimit > 0D AndAlso -balanceAfter > creditLimit Then
            Me.Invoke(Sub() ShowWarning(
                "⚠️ الرصيد بعد العملية سيتجاوز حد الائتمان." & vbCrLf &
                $"حد الائتمان: {creditLimit}" & vbCrLf &
                $"الرصيد الحالي (المديونية): {-balanceBefore}" & vbCrLf &
                $"متبقي الفاتورة: {-remaining}" & vbCrLf &
                $"الرصيد بعد الفاتورة (المديونية): {-balanceAfter}"))
            Return False
        End If
        Return True
    End Function

    Private Sub UpdateCustomerBalanceSync(customerCode As String, remaining As Decimal,
                                          cn As SqlConnection, tx As SqlTransaction)
        If remaining = 0D Then Return
        Using cmd As New SqlCommand("UPDATE Customers SET CurrentBalance=ISNULL(CurrentBalance,0)+@rem WHERE CustomerCode=@code;", cn, tx)
            cmd.Parameters.Add("@rem", SqlDbType.Decimal).Value = remaining
            cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Async Function GetCustomerPhoneAsync(customerCode As String) As Task(Of String)
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand("SELECT PhoneNumber FROM Customers WHERE CustomerCode=@code", cn)
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
                    Using rd = Await cmd.ExecuteReaderAsync()
                        If Await rd.ReadAsync() Then
                            Return If(IsDBNull(rd("PhoneNumber")), "", rd("PhoneNumber").ToString().Trim())
                        End If
                    End Using
                End Using
            End Using
        Catch
        End Try
        Return String.Empty
    End Function

    '══════════════════════════════════════════════════════════════
    ' تحميل فاتورة للتعديل
    '══════════════════════════════════════════════════════════════
    Public Async Function LoadInvoiceAsync(invoiceID As Integer) As Task
        If invoiceID <= 0 Then
            ShowWarning("رقم الفاتورة غير صالح.")
            Return
        End If

        DataGridView1.Rows.Clear()

        Using cn = Await OpenConnectionAsync()
            Using cmd As New SqlCommand(
                "SELECT h.Invoice_ID, h.Invoice_Code, h.Total_Amount, h.Discount_Value, h.Net_Amount, h.Amount_Paid, h.Remaining, h.Payment_Method, h.Notes, h.PreviousBalance, " &
                "c.CustomerID, c.CustomerCode, c.CustomerName, ISNULL(c.CurrentBalance,0) AS CurrentBalance FROM SalesHeader h " &
                "INNER JOIN Customers c ON h.Customer_ID = c.CustomerID WHERE h.Invoice_ID=@id", cn)

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

                Using rd = Await cmd.ExecuteReaderAsync()
                    If Await rd.ReadAsync() Then
                        _currentIDV = Convert.ToInt32(rd("Invoice_ID"))
                        txt_Invoice_ID.Text = rd("Invoice_Code").ToString()
                        txt_Customer_Code.Text = rd("CustomerCode").ToString()
                        txt_Customer_Name.Text = rd("CustomerName").ToString()

                        Dim prevBal As Decimal = If(IsDBNull(rd("PreviousBalance")), 0D, Convert.ToDecimal(rd("PreviousBalance")))
                        txt_Customer_Balance.Text = prevBal.ToString("0.00")
                        cmb_Pay.Text = rd("Payment_Method").ToString()
                        txtTotalRequired.Text = rd("Net_Amount").ToString()
                        txtTotalAfterDiscount.Text = rd("Total_Amount").ToString()
                        txtDiscount.Text = rd("Discount_Value").ToString()
                        txtPaid.Text = rd("Amount_Paid").ToString()
                        txtRemaining.Text = rd("Remaining").ToString()

                        _prevBalanceForPrint = prevBal
                        txt_notes.Text = rd("Notes").ToString()
                    Else
                        ShowWarning("الفاتورة غير موجودة.")
                        Return
                    End If
                End Using
            End Using

            Using cmd As New SqlCommand(
                "SELECT P.Product_Code, d.Product_ID, d.Product_Name, d.ProductUnit_ID, d.ProductUnit_Name, d.Quantity_Sold, d.Sale_Price_Per_Unit, d.Total_Line_Amount, " &
                "ISNULL(u.Unit_Quantity,1) AS Factor, CASE WHEN s.Code IS NULL THEN 0 ELSE 1 END AS IsScaleProduct FROM SalesDetails d " &
                "LEFT JOIN ProductUnits u ON d.Product_ID = u.Product_ID AND d.ProductUnit_ID = u.ProductUnit_ID " &
                "LEFT JOIN Products P ON d.Product_ID = P.Product_ID " &
                "LEFT JOIN TheScale s ON d.Product_ID = s.Code WHERE d.Invoice_ID=@id ORDER BY d.Detail_ID", cn)

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

                Using rd = Await cmd.ExecuteReaderAsync()
                    While Await rd.ReadAsync()
                        Dim productID As Integer = If(IsDBNull(rd("Product_ID")), 0, Convert.ToInt32(rd("Product_ID")))
                        Dim productCode As String = rd("Product_Code").ToString()
                        Dim productName As String = rd("Product_Name").ToString()
                        Dim unitID As Integer = If(IsDBNull(rd("ProductUnit_ID")), 0, Convert.ToInt32(rd("ProductUnit_ID")))
                        Dim unitName As String = rd("ProductUnit_Name").ToString()
                        Dim qty As Decimal = If(IsDBNull(rd("Quantity_Sold")), 0D, Convert.ToDecimal(rd("Quantity_Sold")))
                        Dim price As Decimal = If(IsDBNull(rd("Sale_Price_Per_Unit")), 0D, Convert.ToDecimal(rd("Sale_Price_Per_Unit")))
                        Dim total As Decimal = If(IsDBNull(rd("Total_Line_Amount")), 0D, Convert.ToDecimal(rd("Total_Line_Amount")))
                        Dim factor As Decimal = If(IsDBNull(rd("Factor")), 1D, Convert.ToDecimal(rd("Factor")))
                        Dim isScale As Boolean = Convert.ToBoolean(rd("IsScaleProduct"))

                        Dim rowIndex As Integer = DataGridView1.Rows.Add()
                        Dim r = DataGridView1.Rows(rowIndex)

                        r.Cells("ColProductID").Value = productID
                        r.Cells("ColProduct_Code").Value = productCode
                        r.Cells("ColProductName").Value = productName
                        r.Cells("ColUnitID").Value = unitID
                        r.Cells("ColUnitName").Value = unitName
                        r.Cells("ColQuantity").Value = qty
                        r.Cells("ColPrice").Value = price
                        r.Cells("ColTotal").Value = total

                        If DataGridView1.Columns.Contains("ColFactor") Then
                            r.Cells("ColFactor").Value = factor
                        End If
                        If DataGridView1.Columns.Contains("colIsScaleProduct") Then
                            r.Cells("colIsScaleProduct").Value = isScale
                        End If
                    End While
                End Using
            End Using
        End Using

        Try
            Dim total As Decimal = 0D
            For Each r As DataGridViewRow In DataGridView1.Rows
                If r.IsNewRow Then Continue For
                If r.Cells("ColTotal").Value IsNot Nothing Then
                    total += Convert.ToDecimal(r.Cells("ColTotal").Value)
                End If
            Next

            txtTotalRequired.Text = total.ToString("0.00")
            Dim discount As Decimal = ParseDecimal(txtDiscount.Text)
            txtTotalAfterDiscount.Text = (total - discount).ToString("0.00")

            Dim calcRemaining As Decimal = ParseDecimal(txtTotalAfterDiscount.Text) - ParseDecimal(txtPaid.Text)
            If calcRemaining > 0 Then
                txtRemaining.Text = (-calcRemaining).ToString("0.00")
            Else
                txtRemaining.Text = "0.00"
            End If
        Catch
        End Try
    End Function

    '══════════════════════════════════════════════════════════════
    ' فئة مساعدة لبيانات سطر الفاتورة القديم
    '══════════════════════════════════════════════════════════════
    Private Class OldDetailInfo
        Public Property ProductID As Integer
        Public Property UnitID As Integer
        Public Property Quantity As Decimal
        Public Property SalePrice As Decimal
        Public Property PurchasePriceAtSale As Decimal
        Public Property Profit As Decimal
        Public Property Factor As Decimal
    End Class

    Private Function MakeProductUnitKey(productID As Integer, unitID As Integer) As String
        Return productID.ToString() & "_" & unitID.ToString()
    End Function

    Private Function ValidateInvoiceBeforeSave(customerCode As String, gridData As List(Of InvoiceLineData)) As String
        If String.IsNullOrWhiteSpace(customerCode) Then
            Return "يجب اختيار عميل أولاً."
        End If
        If gridData Is Nothing OrElse gridData.Count = 0 Then
            Return "يجب إضافة صنف واحد على الأقل للفاتورة."
        End If

        Dim seenKeys As New HashSet(Of String)
        For Each line In gridData
            If line.Quantity <= 0D Then
                Return "الكمية يجب أن تكون أكبر من صفر للصنف: " & line.ProductName
            End If
            If line.SalePrice <= 0D Then
                Return "سعر البيع يجب أن يكون أكبر من صفر للصنف: " & line.ProductName
            End If
            If line.ProductID > 0 Then
                Dim key As String = MakeProductUnitKey(line.ProductID, line.UnitID)
                If seenKeys.Contains(key) Then
                    Return "يوجد تكرار للصنف: " & line.ProductName & " بنفس الوحدة. يرجى دمج الكميات."
                End If
                seenKeys.Add(key)
            End If
        Next
        Return String.Empty
    End Function

    Private Function FindOldEntryByProductID(oldDict As Dictionary(Of String, OldDetailInfo), productID As Integer) As OldDetailInfo
        For Each kvp In oldDict
            If kvp.Value.ProductID = productID Then
                Return kvp.Value
            End If
        Next
        Return Nothing
    End Function

    '══════════════════════════════════════════════════════════════
    ' تعديل الفاتورة وحفظ التغييرات التاريخية
    '══════════════════════════════════════════════════════════════
    Public Async Function UpdateInvoiceAsync(invoiceID As Integer) As Task
        If invoiceID <= 0 Then
            ShowWarning("رقم الفاتورة غير صالح.")
            Return
        End If

        Dim customerCodeFromForm As String = txt_Customer_Code.Text.Trim()
        Dim notes As String = txt_notes.Text.Trim()
        Dim paymentType As String = cmb_Pay.Text.Trim()

        If cmbTreasury.SelectedValue Is Nothing Then
            ShowWarning("يرجى اختيار الخزنة.")
            Return
        End If
        Dim newTreasuryID As Integer = Convert.ToInt32(cmbTreasury.SelectedValue)

        Dim gridData = CollectGridData()
        Dim recalcNet As Decimal = gridData.Sum(Function(x) x.Total)
        Dim newDiscount As Decimal = ParseDecimal(txtDiscount.Text)
        Dim recalcTotal As Decimal = recalcNet - newDiscount
        Dim newPaid As Decimal = ParseDecimal(txtPaid.Text)

        Dim calculatedRemaining As Decimal = recalcTotal - newPaid
        Dim newRemaining As Decimal = If(calculatedRemaining > 0, -calculatedRemaining, 0D)

        Dim validationError As String = ValidateInvoiceBeforeSave(customerCodeFromForm, gridData)
        If Not String.IsNullOrEmpty(validationError) Then
            ShowWarning(validationError)
            Return
        End If

        Using cn = Await OpenConnectionAsync()
            Using tr = cn.BeginTransaction()
                Try
                    Dim oldCustomerID As Integer
                    Dim oldRemaining As Decimal
                    Dim oldTreasuryID As Integer
                    Dim oldPaid As Decimal

                    LoadOldHeaderForUpdateSync(invoiceID, cn, tr, oldCustomerID, oldRemaining, oldTreasuryID, oldPaid)

                    Dim newCustomerID As Integer = ResolveCustomerIDFromCodeSync(customerCodeFromForm, cn, tr)
                    Dim customerChanged As Boolean = (newCustomerID <> oldCustomerID)

                    Dim finalPreviousBalance As Decimal = 0D
                    If Not customerChanged Then
                        Using cmdGetPrev = New SqlCommand("SELECT ISNULL(PreviousBalance, 0) FROM SalesHeader WHERE Invoice_ID = @id", cn, tr)
                            cmdGetPrev.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
                            finalPreviousBalance = Convert.ToDecimal(cmdGetPrev.ExecuteScalar())
                        End Using
                    Else
                        finalPreviousBalance = GetCustomerBalanceSync(newCustomerID, cn, tr)
                    End If

                    Dim oldDetailsDict As Dictionary(Of String, OldDetailInfo) = LoadOldSalesDetailsDictionarySync(invoiceID, cn, tr)

                    Dim neededKeys As New Dictionary(Of String, (ProductID As Integer, UnitID As Integer, IsScale As Boolean))
                    For Each row In gridData
                        Dim key = MakeProductUnitKey(row.ProductID, row.UnitID)
                        If Not oldDetailsDict.ContainsKey(key) Then
                            Dim oldEntry = FindOldEntryByProductID(oldDetailsDict, row.ProductID)
                            Dim canUseHistoricalCost As Boolean = oldEntry IsNot Nothing AndAlso
                                                                  oldEntry.PurchasePriceAtSale > 0D AndAlso
                                                                  oldEntry.Factor > 0D AndAlso
                                                                  row.Factor > 0D
                            If Not canUseHistoricalCost Then
                                If Not neededKeys.ContainsKey(key) Then
                                    neededKeys(key) = (row.ProductID, row.UnitID, row.IsScaleProduct)
                                End If
                            End If
                        ElseIf oldDetailsDict(key).PurchasePriceAtSale <= 0D Then
                            If Not neededKeys.ContainsKey(key) Then
                                neededKeys(key) = (row.ProductID, row.UnitID, row.IsScaleProduct)
                            End If
                        End If
                    Next

                    Dim purchasePricesDict As Dictionary(Of String, Decimal) = LoadPurchasePricesBatchSync(neededKeys.Values.ToList(), cn, tr)

                    Dim creditOk As Boolean
                    If Not customerChanged Then
                        Dim currentBalance As Decimal = GetCustomerBalanceSync(newCustomerID, cn, tr)
                        Dim projectedBalance As Decimal = (currentBalance - oldRemaining) + newRemaining
                        creditOk = CheckCreditLimitSync(newCustomerID, projectedBalance, cn, tr)
                    Else
                        Dim newCustomerBalance As Decimal = GetCustomerBalanceSync(newCustomerID, cn, tr)
                        creditOk = CheckCreditLimitSync(newCustomerID, newCustomerBalance + newRemaining, cn, tr)
                    End If

                    If Not creditOk Then
                        Throw New Exception("تجاوز حد الائتمان المسموح به لهذا العميل.")
                    End If

                    Using cmd As New SqlCommand(
                        "UPDATE S SET S.Quantity_OnHand = S.Quantity_OnHand + (D.Quantity_Sold * ISNULL(U.Unit_Quantity,1)) " &
                        "FROM Stock S INNER JOIN SalesDetails D ON S.Product_ID = D.Product_ID " &
                        "LEFT JOIN ProductUnits U ON D.Product_ID = U.Product_ID AND D.ProductUnit_ID = U.ProductUnit_ID " &
                        "WHERE D.Invoice_ID=@id", cn, tr)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
                        cmd.ExecuteNonQuery()
                    End Using

                    ValidateStockAvailabilitySync(gridData, cn, tr)

                    Using cmd As New SqlCommand("DELETE FROM SalesDetails WHERE Invoice_ID=@id", cn, tr)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
                        cmd.ExecuteNonQuery()
                    End Using

                    InsertSalesDetailsAndUpdateStock(invoiceID, gridData, oldDetailsDict, purchasePricesDict, cn, tr)

                    Dim totalProfit As Decimal = gridData.Sum(Function(x) x.Profit)

                    Using cmd As New SqlCommand(
                        "UPDATE SalesHeader SET Net_Amount=@net, Discount_Value=@discount, Total_Amount=@total, Amount_Paid=@paid, " &
                        "Remaining=@rem, Payment_Method=@pm, Notes=@notes, Total_Profit=@profit, Customer_ID=@custId, TreasuryID=@treasuryId, PreviousBalance=@prevBal " &
                        "WHERE Invoice_ID=@id", cn, tr)

                        cmd.Parameters.Add("@net", SqlDbType.Decimal).Value = recalcNet
                        cmd.Parameters.Add("@discount", SqlDbType.Decimal).Value = newDiscount
                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = recalcTotal
                        cmd.Parameters.Add("@paid", SqlDbType.Decimal).Value = newPaid
                        cmd.Parameters.Add("@rem", SqlDbType.Decimal).Value = newRemaining
                        cmd.Parameters.Add("@pm", SqlDbType.NVarChar, 50).Value = paymentType
                        cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 500).Value = notes
                        cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = totalProfit
                        cmd.Parameters.Add("@custId", SqlDbType.Int).Value = newCustomerID
                        cmd.Parameters.Add("@treasuryId", SqlDbType.Int).Value = newTreasuryID
                        cmd.Parameters.Add("@prevBal", SqlDbType.Decimal).Value = finalPreviousBalance
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim treasuryDiff As Decimal = newPaid - oldPaid
                    If treasuryDiff <> 0D Then
                        Dim finalTreasuryID As Integer = If(oldTreasuryID > 0, oldTreasuryID, newTreasuryID)
                        Dim finalDiff As Decimal = If(oldTreasuryID > 0, treasuryDiff, newPaid)

                        If finalDiff <> 0D Then
                            Dim isDepositAction As Boolean = (finalDiff > 0)
                            Dim absoluteAmount As Decimal = Math.Abs(finalDiff)

                            Await TreasuryService.AddTransactionAsync(
                                treasuryID:=finalTreasuryID,
                                transactionType:=TreasuryTransactionTypes.Sale,
                                amount:=absoluteAmount,
                                isDeposit:=isDepositAction,
                                referenceID:=invoiceID,
                                referenceNo:=invoiceID.ToString(),
                                notes:="تعديل فاتورة مبيعات - " & If(isDepositAction, "إيداع فرق التعديل", "سحب فرق التعديل"),
                                userID:=Session.CurrentUserID,
                                cn:=cn,
                                trans:=tr
                            )
                        End If
                    End If

                    If Not customerChanged Then
                        Dim diff As Decimal = newRemaining - oldRemaining
                        If diff <> 0D Then
                            AdjustCustomerBalanceByIDSync(newCustomerID, diff, cn, tr)
                        End If
                    Else
                        If oldRemaining <> 0D Then
                            AdjustCustomerBalanceByIDSync(oldCustomerID, -oldRemaining, cn, tr)
                        End If
                        If newRemaining <> 0D Then
                            AdjustCustomerBalanceByIDSync(newCustomerID, newRemaining, cn, tr)
                        End If
                    End If

                    tr.Commit()

                    txtTotalRequired.Text = recalcNet.ToString("0.00")
                    txtTotalAfterDiscount.Text = recalcTotal.ToString("0.00")
                    txtRemaining.Text = newRemaining.ToString("0.00")
                    txt_Customer_Balance.Text = finalPreviousBalance.ToString("0.00")

                    MessageBox.Show("تم تعديل الفاتورة وتحديث حسابات الأرصدة والخزن بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    Try : tr.Rollback() : Catch : End Try
                    ShowError("خطأ أثناء تعديل الفاتورة: " & ex.Message)
                End Try
            End Using
        End Using
    End Function

    '══════════════════════════════════════════════════════════════
    ' دوال مساعدة لعملية التعديل
    '══════════════════════════════════════════════════════════════
    Private Sub LoadOldHeaderForUpdateSync(invoiceID As Integer, cn As SqlConnection, tr As SqlTransaction,
                                           ByRef oldCustomerID As Integer, ByRef oldRemaining As Decimal,
                                           ByRef oldTreasuryID As Integer, ByRef oldPaid As Decimal)

        Using cmd As New SqlCommand("SELECT Customer_ID, Remaining, TreasuryID, Amount_Paid FROM SalesHeader WHERE Invoice_ID=@id", cn, tr)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    oldCustomerID = Convert.ToInt32(rd("Customer_ID"))
                    oldRemaining = Convert.ToDecimal(rd("Remaining"))
                    oldTreasuryID = If(rd("TreasuryID") Is DBNull.Value, 0, Convert.ToInt32(rd("TreasuryID")))
                    oldPaid = If(rd("Amount_Paid") Is DBNull.Value, 0D, Convert.ToDecimal(rd("Amount_Paid")))
                Else
                    Throw New Exception("تعذر العثور على الفاتورة رقم " & invoiceID.ToString())
                End If
            End Using
        End Using

        Dim currentCustBalance As Decimal = GetCustomerBalanceSync(oldCustomerID, cn, tr)
        _prevBalanceForPrint = currentCustBalance - oldRemaining
    End Sub

    Private Function ResolveCustomerIDFromCodeSync(customerCode As String, cn As SqlConnection, tr As SqlTransaction) As Integer
        Using cmd As New SqlCommand("SELECT CustomerID FROM Customers WHERE CustomerCode=@code", cn, tr)
            cmd.Parameters.AddWithValue("@code", customerCode)
            Dim result = cmd.ExecuteScalar()
            If result Is Nothing OrElse IsDBNull(result) Then
                Throw New Exception("رمز العميل غير موجود: " & customerCode)
            End If
            Return Convert.ToInt32(result)
        End Using
    End Function

    Private Function GetCustomerBalanceSync(customerID As Integer, cn As SqlConnection, tr As SqlTransaction) As Decimal
        Using cmd As New SqlCommand("SELECT ISNULL(CurrentBalance,0) FROM Customers WHERE CustomerID=@id", cn, tr)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = customerID
            Return Convert.ToDecimal(cmd.ExecuteScalar())
        End Using
    End Function

    Private Sub AdjustCustomerBalanceByIDSync(customerID As Integer, amount As Decimal, cn As SqlConnection, tr As SqlTransaction)
        Using cmd As New SqlCommand("UPDATE Customers SET CurrentBalance = ISNULL(CurrentBalance,0) + @amount WHERE CustomerID=@id", cn, tr)
            cmd.Parameters.AddWithValue("@amount", amount)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = customerID
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function CheckCreditLimitSync(customerID As Integer, projectedBalance As Decimal, cn As SqlConnection, tr As SqlTransaction) As Boolean
        Dim creditLimit As Decimal = 0D
        Dim customerName As String = ""

        Using cmd As New SqlCommand("SELECT ISNULL(CreditLimit,0), ISNULL(CustomerName,'') FROM Customers WHERE CustomerID=@id", cn, tr)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = customerID
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    creditLimit = Convert.ToDecimal(rd(0))
                    customerName = rd(1).ToString()
                End If
            End Using
        End Using

        If creditLimit > 0D AndAlso -projectedBalance > creditLimit Then
            Me.Invoke(Sub()
                          ShowWarning(
                              "⚠️ لا يمكن إتمام العملية." & vbCrLf & vbCrLf &
                              "ستتجاوز مديونية العميل حد الائتمان المسموح به." & vbCrLf & vbCrLf &
                              "العميل: " & customerName & vbCrLf &
                              "حد الائتمان: " & creditLimit.ToString("N2") & vbCrLf &
                              "المديونية المتوقعة بعد العملية: " & (-projectedBalance).ToString("N2"))
                      End Sub)
            Return False
        End If
        Return True
    End Function

    Private Function LoadOldSalesDetailsDictionarySync(invoiceID As Integer, cn As SqlConnection, tr As SqlTransaction) As Dictionary(Of String, OldDetailInfo)
        Dim result As New Dictionary(Of String, OldDetailInfo)
        Using cmd As New SqlCommand(
            "SELECT d.Product_ID, d.ProductUnit_ID, d.Quantity_Sold, d.Sale_Price_Per_Unit, ISNULL(d.Purchase_Price_At_Sale,0) AS Purchase_Price_At_Sale, " &
            "ISNULL(d.Profit,0) AS Profit, ISNULL(u.Unit_Quantity,1) AS Factor FROM SalesDetails d " &
            "LEFT JOIN ProductUnits u ON d.Product_ID = u.Product_ID AND d.ProductUnit_ID = u.ProductUnit_ID WHERE d.Invoice_ID=@id", cn, tr)

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    Dim info As New OldDetailInfo With {
                        .ProductID = Convert.ToInt32(rd("Product_ID")),
                        .UnitID = Convert.ToInt32(rd("ProductUnit_ID")),
                        .Quantity = Convert.ToDecimal(rd("Quantity_Sold")),
                        .SalePrice = Convert.ToDecimal(rd("Sale_Price_Per_Unit")),
                        .PurchasePriceAtSale = Convert.ToDecimal(rd("Purchase_Price_At_Sale")),
                        .Profit = Convert.ToDecimal(rd("Profit")),
                        .Factor = Convert.ToDecimal(rd("Factor"))
                    }
                    Dim key = MakeProductUnitKey(info.ProductID, info.UnitID)
                    result(key) = info
                End While
            End Using
        End Using
        Return result
    End Function

    Private Function LoadPurchasePricesBatchSync(items As List(Of (ProductID As Integer, UnitID As Integer, IsScale As Boolean)),
                                                 cn As SqlConnection, tr As SqlTransaction) As Dictionary(Of String, Decimal)
        Dim result As New Dictionary(Of String, Decimal)
        If items Is Nothing OrElse items.Count = 0 Then Return result

        Dim regularItems = items.Where(Function(i) Not i.IsScale).ToList()
        Dim scaleItems = items.Where(Function(i) i.IsScale).ToList()

        If regularItems.Count > 0 Then
            Dim conditions As New List(Of String)
            Using cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.Transaction = tr
                For i As Integer = 0 To regularItems.Count - 1
                    Dim pParam = "@p" & i.ToString()
                    Dim uParam = "@u" & i.ToString()
                    conditions.Add("(Product_ID=" & pParam & " AND ProductUnit_ID=" & uParam & ")")
                    cmd.Parameters.Add(pParam, SqlDbType.Int).Value = regularItems(i).ProductID
                    cmd.Parameters.Add(uParam, SqlDbType.Int).Value = regularItems(i).UnitID
                Next

                cmd.CommandText = "SELECT Product_ID, ProductUnit_ID, ISNULL(Purchase_Price,0) AS Purchase_Price FROM ProductUnits WHERE " & String.Join(" OR ", conditions)
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim pid = Convert.ToInt32(rd("Product_ID"))
                        Dim uid = Convert.ToInt32(rd("ProductUnit_ID"))
                        Dim price = Convert.ToDecimal(rd("Purchase_Price"))
                        result(MakeProductUnitKey(pid, uid)) = price
                    End While
                End Using
            End Using
        End If

        If scaleItems.Count > 0 Then
            Using cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.Transaction = tr
                Dim paramNames As New List(Of String)
                For i As Integer = 0 To scaleItems.Count - 1
                    Dim cParam = "@c" & i.ToString()
                    paramNames.Add(cParam)
                    cmd.Parameters.Add(cParam, SqlDbType.Int).Value = scaleItems(i).ProductID
                Next

                cmd.CommandText = "SELECT Code, ISNULL(Purchase_Price,0) AS Purchase_Price FROM TheScale WHERE Code IN (" & String.Join(",", paramNames) & ")"
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim code = Convert.ToInt32(rd("Code"))
                        Dim price = Convert.ToDecimal(rd("Purchase_Price"))
                        Dim matching = scaleItems.Where(Function(x) x.ProductID = code).ToList()
                        For Each m In matching
                            result(MakeProductUnitKey(m.ProductID, m.UnitID)) = price
                        Next
                    End While
                End Using
            End Using
        End If

        Return result
    End Function

    Private Sub ValidateStockAvailabilitySync(gridData As List(Of InvoiceLineData), cn As SqlConnection, tr As SqlTransaction)
        Dim productIDs = gridData.Select(Function(r) r.ProductID).Distinct().ToList()
        If productIDs.Count = 0 Then Return

        Dim stockDict As New Dictionary(Of Integer, Decimal)
        Using cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.Transaction = tr
            Dim paramNames As New List(Of String)
            For i As Integer = 0 To productIDs.Count - 1
                Dim pParam = "@p" & i.ToString()
                paramNames.Add(pParam)
                cmd.Parameters.Add(pParam, SqlDbType.Int).Value = productIDs(i)
            Next

            cmd.CommandText = "SELECT Product_ID, Quantity_OnHand FROM Stock WHERE Product_ID IN (" & String.Join(",", paramNames) & ")"
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    stockDict(Convert.ToInt32(rd("Product_ID"))) = Convert.ToDecimal(rd("Quantity_OnHand"))
                End While
            End Using
        End Using

        Dim requiredByProduct As New Dictionary(Of Integer, Decimal)
        For Each row In gridData
            If row.IsScaleProduct OrElse row.ProductID <= 0 Then Continue For
            Dim effectiveFactor As Decimal = If(row.Factor > 0D, row.Factor, 1D)
            Dim requiredQty As Decimal = row.Quantity * effectiveFactor

            If requiredByProduct.ContainsKey(row.ProductID) Then
                requiredByProduct(row.ProductID) += requiredQty
            Else
                requiredByProduct(row.ProductID) = requiredQty
            End If
        Next

        For Each kvp In requiredByProduct
            Dim available As Decimal = If(stockDict.ContainsKey(kvp.Key), stockDict(kvp.Key), 0D)
            If available - kvp.Value < 0D Then
                Throw New Exception("الكمية غير متوفرة بالمخزون للمنتج رقم " & kvp.Key.ToString() & " (المتاح: " & available.ToString("0.##") & ", المطلوب: " & kvp.Value.ToString("0.##") & ")")
            End If
        Next
    End Sub

    Private Sub InsertSalesDetailsAndUpdateStock(invoiceID As Integer, gridData As List(Of InvoiceLineData),
                                                 oldDetailsDict As Dictionary(Of String, OldDetailInfo),
                                                 purchasePricesDict As Dictionary(Of String, Decimal),
                                                 cn As SqlConnection, tr As SqlTransaction)

        For Each row In gridData
            Dim key = MakeProductUnitKey(row.ProductID, row.UnitID)
            Dim purchasePriceAtSale As Decimal = 0D
            Dim lineProfit As Decimal = 0D

            If oldDetailsDict.ContainsKey(key) AndAlso oldDetailsDict(key).PurchasePriceAtSale > 0D Then
                purchasePriceAtSale = oldDetailsDict(key).PurchasePriceAtSale
            ElseIf Not oldDetailsDict.ContainsKey(key) Then
                Dim oldEntry = FindOldEntryByProductID(oldDetailsDict, row.ProductID)
                If oldEntry IsNot Nothing AndAlso oldEntry.PurchasePriceAtSale > 0D AndAlso oldEntry.Factor > 0D AndAlso row.Factor > 0D Then
                    Dim costPerBaseUnit As Decimal = oldEntry.PurchasePriceAtSale / oldEntry.Factor
                    purchasePriceAtSale = Math.Round(costPerBaseUnit * row.Factor, 4)
                Else
                    purchasePriceAtSale = If(purchasePricesDict.ContainsKey(key), purchasePricesDict(key), 0D)
                End If
            Else
                purchasePriceAtSale = If(purchasePricesDict.ContainsKey(key), purchasePricesDict(key), 0D)
            End If

            If row.IsScaleProduct Then
                Dim weightKg As Decimal = row.Quantity / 1000D
                lineProfit = (row.SalePrice - purchasePriceAtSale) * weightKg
            Else
                lineProfit = (row.SalePrice - purchasePriceAtSale) * row.Quantity
            End If

            row.PurchasePriceAtSale = purchasePriceAtSale
            row.Profit = lineProfit

            Using cmd As New SqlCommand(
                "INSERT INTO SalesDetails(Invoice_ID, Product_ID, Product_Name, ProductUnit_ID, ProductUnit_Name, Quantity_Sold, Sale_Price_Per_Unit, Total_Line_Amount, Purchase_Price_At_Sale, Profit)" &
                " VALUES(@invoiceId, @productId, @productName, @unitId, @unitName, @qty, @salePrice, @total, @purchasePriceAtSale, @profit)", cn, tr)

                cmd.Parameters.Add("@invoiceId", SqlDbType.Int).Value = invoiceID
                cmd.Parameters.Add("@productId", SqlDbType.Int).Value = row.ProductID
                cmd.Parameters.Add("@productName", SqlDbType.NVarChar, 300).Value = row.ProductName
                cmd.Parameters.Add("@unitId", SqlDbType.Int).Value = row.UnitID
                cmd.Parameters.Add("@unitName", SqlDbType.NVarChar, 100).Value = row.UnitName
                cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = row.Quantity
                cmd.Parameters.Add("@salePrice", SqlDbType.Decimal).Value = row.SalePrice
                cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = row.Total
                cmd.Parameters.Add("@purchasePriceAtSale", SqlDbType.Decimal).Value = purchasePriceAtSale
                cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = lineProfit
                cmd.ExecuteNonQuery()
            End Using

            If row.IsScaleProduct OrElse row.ProductID <= 0 Then Continue For
            Dim effectiveFactor As Decimal = If(row.Factor > 0D, row.Factor, 1D)
            Using cmd As New SqlCommand("UPDATE Stock SET Quantity_OnHand = Quantity_OnHand - @requiredQty WHERE Product_ID = @productId", cn, tr)
                cmd.Parameters.Add("@requiredQty", SqlDbType.Decimal).Value = row.Quantity * effectiveFactor
                cmd.Parameters.Add("@productId", SqlDbType.Int).Value = row.ProductID
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    '══════════════════════════════════════════════════════════════
    ' واتساب
    '══════════════════════════════════════════════════════════════
    Private Async Function SendInvoiceWhatsAppAsync(invID As Integer, phone As String) As Task
        If String.IsNullOrWhiteSpace(phone) Then
            ShowWarning("رقم الهاتف غير صالح.")
            Return
        End If
        Dim message As String = ReportsModule.GenerateInvoiceText(invID)
        Dim success As Boolean = Await WhatsAppAPI.SendText(phone, message)
        ShowInfo(If(success, "✅ تم إرسال الفاتورة على واتساب بنجاح", "❌ فشل إرسال الفاتورة على واتساب"))
    End Function

    Private Function IsInternetAvailable() As Boolean
        Try
            Return NetworkInterface.GetIsNetworkAvailable()
            'End Catch
        Catch
            Return False
        End Try
    End Function

    '══════════════════════════════════════════════════════════════
    ' الطباعة (في Background Thread)
    '══════════════════════════════════════════════════════════════
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Await PrintInvoiceSafeAsync(_currentIDV)
    End Sub

    Private Async Function PrintInvoiceSafeAsync(invoiceID As Integer) As Task
        Try
            Dim printData = CollectPrintData()
            If ShouldShowPrintPreview() Then
                PrintInvoice80mmProfessionalCore(invoiceID, printData)
            Else
                Await Task.Run(Sub() PrintInvoice80mmProfessionalCore(invoiceID, printData))
            End If
        Catch ex As Exception
            ShowError("خطأ أثناء الطباعة: " & ex.Message)
        End Try
    End Function

    Private Class PrintData
        Public InvoiceItems As List(Of InvoiceLineData)
        Public CustomerCode As String
        Public CustomerName As String
        Public CustomerBalance As String
        Public PreviousBalance As Decimal
        Public TotalRequired As String
        Public Discount As String
        Public TotalAfterDiscount As String
        Public Paid As String
        Public Remaining As String
        Public UserName As String
        Public PaymentMethod As String
    End Class

    Private Function CollectPrintData() As PrintData
        Return New PrintData With {
            .InvoiceItems = CollectGridData(),
            .CustomerCode = txt_Customer_Code.Text,
            .CustomerName = txt_Customer_Name.Text,
            .CustomerBalance = txt_Customer_Balance.Text,
            .PreviousBalance = _prevBalanceForPrint,
            .TotalRequired = txtTotalRequired.Text,
            .Discount = txtDiscount.Text,
            .TotalAfterDiscount = txtTotalAfterDiscount.Text,
            .Paid = txtPaid.Text,
            .Remaining = txtRemaining.Text,
            .UserName = lbl_user_name.Text,
            .PaymentMethod = cmb_Pay.Text
        }
    End Function

    Private Sub PrintInvoice80mmProfessionalCore(invoiceID As Integer, data As PrintData)
        Dim styleVal As String = SettingsManager.GetSetting("PrintStyle")
        If String.IsNullOrEmpty(styleVal) Then styleVal = "2"
        If styleVal = "2" Then
            PrintInvoice80mm_Style2(invoiceID, data)
        Else
            PrintInvoice80mm_Style1(invoiceID, data)
        End If
    End Sub

    Private Sub PrintInvoice80mm_Style1(invoiceID As Integer, data As PrintData)
        Dim header As New InvoiceHeader With {
            .InvoiceID = invoiceID,
            .InvoiceDate = DateTime.Now,
            .CustomerCode = data.CustomerCode,
            .CustomerName = data.CustomerName,
            .UserName = data.UserName,
            .TotalAmount = ParseDecimal(data.TotalAfterDiscount),
            .Discount = ParseDecimal(data.Discount),
            .NetAmount = ParseDecimal(data.TotalRequired),
            .Paid = ParseDecimal(data.Paid),
            .Remaining = ParseDecimal(data.Remaining),
            .PreviousBalance = data.PreviousBalance,
            .PaymentMethod = data.PaymentMethod
        }

        Dim items As New List(Of InvoiceItem)()
        For Each line In data.InvoiceItems
            items.Add(New InvoiceItem With {
                .ProductName = line.ProductName,
                .Quantity = line.Quantity,
                .Price = line.SalePrice,
                .Total = line.Total
            })
        Next

        Dim printBarcode As Boolean = (If(SettingsManager.GetSetting("PrintBarcode"), "true").Trim().ToLower() = "true")
        RenderInvoiceReceiptStyle1(header, items, 1, ShouldShowPrintPreview(), "معاينة الفاتورة - استيل 1", printBarcode)
    End Sub

    Private Function ShouldShowPrintPreview() As Boolean
        Try
            Dim v = SettingsManager.GetSetting("PrintPreview")
            Return Not String.IsNullOrEmpty(v) AndAlso v.Trim().ToLower() = "true"
        Catch
            Return False
        End Try
    End Function

    Private Sub ShowPrintPreviewDialog(pd As PrintDocument, title As String)
        Dim showPreview As Action =
            Sub()
                Try
                    Dim dlg As New PrintPreviewDialog()
                    Try
                        dlg.Document = pd
                        dlg.Text = title
                        dlg.WindowState = FormWindowState.Maximized
                        dlg.UseAntiAlias = True
                        dlg.PrintPreviewControl.Zoom = 1.25
                        dlg.ShowIcon = False
                        dlg.StartPosition = FormStartPosition.CenterScreen
                        dlg.ShowDialog()
                    Finally
                        dlg.Dispose()
                    End Try
                Catch ex As Exception
                    MessageBox.Show("خطأ في عرض المعاينة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub

        Try
            If Me.IsHandleCreated AndAlso Me.InvokeRequired Then
                Me.Invoke(showPreview)
            Else
                showPreview.Invoke()
            End If
        Catch ex As Exception
            showPreview.Invoke()
        End Try
    End Sub

    Private Sub PrintInvoice80mm_Style2(invoiceID As Integer, data As PrintData)
        Dim header As New InvoiceHeader With {
            .InvoiceID = invoiceID,
            .InvoiceDate = DateTime.Now,
            .CustomerCode = data.CustomerCode,
            .CustomerName = data.CustomerName,
            .UserName = data.UserName,
            .TotalAmount = ParseDecimal(data.TotalAfterDiscount),
            .Discount = ParseDecimal(data.Discount),
            .NetAmount = ParseDecimal(data.TotalRequired),
            .Paid = ParseDecimal(data.Paid),
            .Remaining = ParseDecimal(data.Remaining),
            .PreviousBalance = data.PreviousBalance,
            .PaymentMethod = data.PaymentMethod
        }

        Dim items As New List(Of InvoiceItem)()
        For Each line In data.InvoiceItems
            items.Add(New InvoiceItem With {
                .ProductName = line.ProductName,
                .Quantity = line.Quantity,
                .Price = line.SalePrice,
                .Total = line.Total
            })
        Next

        Dim printBarcode As Boolean = (If(SettingsManager.GetSetting("PrintBarcode"), "true").Trim().ToLower() = "true")
        RenderInvoiceReceiptStyle2(header, items, 1, ShouldShowPrintPreview(), "معاينة الفاتورة - استيل 2", printBarcode)
    End Sub

    Private Function GenerateQRCode(text As String) As Bitmap
        Dim writer As New ZXing.BarcodeWriter() With {
            .Format = ZXing.BarcodeFormat.CODE_128,
            .Options = New ZXing.Common.EncodingOptions With {
                .Height = 70, .Width = 140, .Margin = 0}}
        Return writer.Write(text)
    End Function

    '══════════════════════════════════════════════════════════════
    ' تحميل بيانات المستخدم
    '══════════════════════════════════════════════════════════════
    Private Sub loadlogininfo()
        Try
            Using cn = OpenConnection()
                Using cmd As New SqlCommand("SELECT User_Name FROM Users_TBL WHERE User_ID=@id", cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Session.CurrentUserID
                    lbl_user_name.Text = Convert.ToString(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            ShowError("خطأ أثناء التحقق من المستخدم: " & ex.Message)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' الأحداث الأخرى وأدوات التحكم المساعدة
    '══════════════════════════════════════════════════════════════
    Private Sub btn_Sales_Returns_Click(sender As Object, e As EventArgs) Handles btn_Sales_Returns.Click
        OpenSingleForm(Of Sales_Returns)()
    End Sub

    Private Sub btnToggleDiscount_Click(sender As Object, e As EventArgs) Handles btnToggleDiscount.Click
        _discountEnabled = Not _discountEnabled
        If Not _discountEnabled Then
            lblDiscount.Visible = False
            txtDiscount.Visible = False
            lblTotalBefore.Visible = False
            lblTotalAfter.Text = "إجمالي الفاتورة"
            txtDiscount.Text = "0"
            btnToggleDiscount.Text = "✅"
            btnToggleDiscount.BackColor = Color.SeaGreen
        Else
            lblDiscount.Visible = True
            txtDiscount.Visible = True
            lblTotalBefore.Visible = True
            lblTotalAfter.Text = "إجمالي بعد الخصم"
            btnToggleDiscount.Text = "❌"
            btnToggleDiscount.BackColor = Color.Firebrick
        End If
        RecalculateTotals()
    End Sub

    Private Sub btnToggleScanner_Click(sender As Object, e As EventArgs) Handles btnToggleScanner.Click
        Try
            If barcodePort IsNot Nothing AndAlso barcodePort.IsOpen Then
                StopScanner()
                btnToggleScanner.Text = "تشغيل الاسكنر"
            Else
                StartScanner()
                btnToggleScanner.Text = If(barcodePort?.IsOpen, "إيقاف الاسكنر", "تشغيل الاسكنر")
            End If
        Catch ex As Exception
            ShowError("خطأ في الاسكنر: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        cleartxts()
        DataGridView1.Rows.Clear()
        _stockCache.Clear()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        DataGridView1.Rows.Clear()
        _stockCache.Clear()
        UpdateInvoiceTotals()
        UnlockInvoice()
    End Sub

    Private Sub txt_Customer_Balance_TextChanged(sender As Object, e As EventArgs) Handles txt_Customer_Balance.TextChanged
        SplitBalance(txt_Customer_Balance, txtDebit, txtCredit)
    End Sub

    Private Sub SplitBalance(txtBalance As Guna2TextBox, txtDebit As Guna2TextBox, txtCredit As Guna2TextBox)
        Dim balance As Decimal
        If Decimal.TryParse(txtBalance.Text.Trim(), balance) Then
            If balance < 0 Then
                txtDebit.Text = Math.Abs(balance).ToString()
                txtCredit.Text = "0"
            ElseIf balance > 0 Then
                txtDebit.Text = "0"
                txtCredit.Text = balance.ToString()
            Else
                txtDebit.Text = "0"
                txtCredit.Text = "0"
            End If
        Else
            txtDebit.Text = "0"
            txtCredit.Text = "0"
        End If
    End Sub

    Private Sub btn_auto_pay_Click(sender As Object, e As EventArgs) Handles btn_auto_pay.Click
        If String.IsNullOrWhiteSpace(txtTotalAfterDiscount.Text) Then
            ShowWarning("برجاء التأكد من المبلغ بعد الخصم")
            Return
        End If

        txtPaid.Text = txtTotalAfterDiscount.Text
        cmb_Pay.SelectedIndex = 0
        _autoSave = If(SettingsManager.GetSetting("autoSaveinvoice") = "true", True, False)
        If _autoSave Then btnSaveInvoice.PerformClick()
    End Sub

    Private Sub check_Stats_CheckedChanged(sender As Object, e As EventArgs) Handles check_Stats.CheckedChanged
        _isSendToWhatsApp = check_Stats.Checked
    End Sub

    Private Sub btn_money_Click(sender As Object, e As EventArgs) Handles btn_money.Click
        _moneyEnabled = Not _moneyEnabled
        Dim vis = _moneyEnabled
        lbl_Customer_Balance.Visible = vis
        txt_Customer_Balance.Visible = vis
        lbl_Credit.Visible = vis
        txtCredit.Visible = vis
        lbl_Debit.Visible = vis
        txtDebit.Visible = vis
        btn_money.Text = If(vis, "❌", "✅")
        Pic_Logo.Visible = Not vis
        btnToggleDiscount.BackColor = If(vis, Color.Firebrick, Color.SeaGreen)
    End Sub

    ' إضافة منتج حر (غير مرتبط بالمخزون)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If _invoiceSaved Then
            ShowWarning("تم حفظ الفاتورة بالفعل. اضغط (مسح / حذف) لبدء فاتورة جديدة قبل إضافة منتجات.")
            Return
        End If
        If Guna2TextBox1.TextLength = 0 OrElse Guna2TextBox2.TextLength = 0 OrElse txt_free_profit.TextLength = 0 Then
            ShowWarning("برجاء ملء جميع الحقول")
            Return
        End If
        If Not IsNumeric(txt_free_profit.Text) OrElse Not IsNumeric(Guna2TextBox2.Text) Then
            ShowWarning("برجاء إدخال أرقام صحيحة")
            Return
        End If

        Dim dgv As DataGridView = DataGridView1
        Dim newRow As DataGridViewRow = CType(dgv.RowTemplate.Clone(), DataGridViewRow)
        newRow.CreateCells(dgv)

        Dim setCell = Sub(colName As String, val As Object)
                          If dgv.Columns.Contains(colName) Then
                              newRow.Cells(dgv.Columns(colName).Index).Value = val
                          End If
                      End Sub

        setCell("ColProductID", 0)
        setCell("ColProduct_Code", 0)
        setCell("ColProductName", Guna2TextBox1.Text)
        setCell("ColUnitName", "غير معرف")
        setCell("ColPrice", Guna2TextBox2.Text)
        setCell("ColQuantity", 1)
        setCell("ColTotal", Guna2TextBox2.Text)
        setCell("ColUnitID", 0)
        setCell("ColFactor", 0)
        setCell("ColProfit", Convert.ToDecimal(txt_free_profit.Text))

        dgv.Rows.Add(newRow)
        ClearProductFields()
        Guna2TextBox1.Clear()
        Guna2TextBox2.Clear()
        txt_free_profit.Clear()
        UpdateInvoiceTotals()
    End Sub

    Private Sub Guna2TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Guna2TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then Guna2TextBox2.Focus()
    End Sub
    Private Sub Guna2TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles Guna2TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then txt_free_profit.Focus()
    End Sub
    Private Sub txt_free_profit_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_free_profit.KeyDown
        If e.KeyCode = Keys.Enter Then Button2.PerformClick()
    End Sub

    Private Function ParseDecimal(txt As String) As Decimal
        Dim result As Decimal
        Decimal.TryParse(txt, result)
        Return result
    End Function

    Private Function ParseInt(val As Object) As Integer
        Dim result As Integer
        If val IsNot Nothing Then Integer.TryParse(val.ToString(), result)
        Return result
    End Function

    Private Sub ShowWarning(msg As String)
        MessageBox.Show(msg, "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub ShowError(msg As String)
        MessageBox.Show(msg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Async Sub btn_Invoice_Edit_Click(sender As Object, e As EventArgs) Handles btn_Invoice_Edit.Click
        Await UpdateInvoiceAsync(inv_id_edit)
        btn_Invoice_Edit.Visible = False
    End Sub

    Private Async Function LoadTreasuriesAsync() As Task
        Try
            Dim dt As New DataTable()
            Using cn As SqlConnection = Await NewConnAsync()
                Const sql As String = "SELECT TreasuryID, TreasuryNameAr FROM Treasury WHERE IsActive = 1 AND IsDeleted = 0"
                Using da As New SqlDataAdapter(sql, cn)
                    Await Task.Run(Sub() da.Fill(dt))
                End Using
            End Using
            cmbTreasury.DataSource = dt
            cmbTreasury.DisplayMember = "TreasuryNameAr"
            cmbTreasury.ValueMember = "TreasuryID"
            Dim defaultIdSetting = SettingsManager.GetSetting("defaultTreasuryid")
            defaultTreasuryid = If(IsNumeric(defaultIdSetting), Convert.ToInt32(defaultIdSetting), -1)
            If defaultTreasuryid >= 0 AndAlso defaultTreasuryid < cmbTreasury.Items.Count Then
                cmbTreasury.SelectedIndex = defaultTreasuryid
            End If
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Function

    Private Sub cmbTreasury_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTreasury.SelectedIndexChanged
        If cmbTreasury.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbTreasury.SelectedValue) Then
            SelectedTreasuryid = Convert.ToInt32(cmbTreasury.SelectedValue)
        End If
    End Sub

    Private Sub ShowInfo(msg As String)
        MessageBox.Show(msg, "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
























'Imports System.Data.SqlClient
'Imports System.Drawing
'Imports System.Drawing.Printing
'Imports System.Globalization
'Imports System.Net.NetworkInformation
'Imports System.Text
'Imports System.Threading
'Imports System.Threading.Tasks
'Imports DevExpress.XtraEditors
'Imports Guna.UI2.WinForms

'' ==============================================================
''  ملاحظة: الاتصال بقاعدة البيانات يعتمد على دالة GetConnectionString()
''  يجب أن تُعرّف هذه الدالة في Module أو Base Class ترجع
''  connectionString صحيح مثل:
''  "Data Source=...;Initial Catalog=...;Integrated Security=True"
'' ==============================================================

'Public Class Sales

'    '──────────────────────────────────────────────────────────────
'    ' متغيرات الفورم
'    '──────────────────────────────────────────────────────────────
'    Private _x, _y As Integer
'    Private _newPoint As New Point
'    Private _manager As New SalesManager()
'    Public SelectedProductId As Integer = 0
'    Public CurrentConversionFactor As Decimal = 0D
'    Public CurrentSalePrice As Decimal = 0D
'    Private _currentUnitID As Integer = 0
'    Private WithEvents _timer1 As New System.Windows.Forms.Timer()
'    Private _discountEnabled As Boolean = True
'    Private _moneyEnabled As Boolean = False
'    Private _isSendToWhatsApp As Boolean = False
'    Private _autoSave As Boolean = If(SettingsManager.GetSetting("autoSaveinvoice"), "false")
'    Private _currentIDV As Integer

'    ' [قفل الفاتورة بعد الحفظ]: يمنع إضافة منتجات/حفظ مرة تانية على نفس الفاتورة
'    ' لحد ما يتم الضغط على مسح/حذف لبدء فاتورة جديدة
'    Private _invoiceSaved As Boolean = False
'    Public ScalID As Integer = 0

'    'Public inv_id_edit As Integer
'    Public Property inv_id_edit As Integer

'    ' ── منع إعادة الدخول لـ RecalculateTotals ──
'    ' [تحسين]: فلاق يمنع Cascading Calls التي كانت تسبب تجميد الـ UI
'    Private _isRecalculating As Boolean = False

'    ' ── Debounce للبحث (300ms بعد آخر حرف) ──
'    ' [تحسين]: CancellationTokenSource أسلم مع Async/Await
'    Private _searchCts As CancellationTokenSource

'    ' ── Cache لسعر الشراء ──
'    Private _purchasePriceCache As New Dictionary(Of String, Decimal)

'    ' ── Cache مؤقت للمخزون (يُمسح عند إضافة أو تعديل منتج) ──
'    ' [تحسين]: يقلل استعلامات قاعدة البيانات للمنتج نفسه خلال جلسة الفاتورة
'    Private _stockCache As New Dictionary(Of Integer, Decimal)
'    Private _prevBalanceForPrint As Decimal = 0D


'    ''الخزنه
'    Private SelectedTreasuryid As Integer

'    Private defaultTreasuryid As Integer = If(SettingsManager.GetSetting("defaultTreasuryid"), -1)
'    '══════════════════════════════════════════════════════════════
'    ' دوال الاتصال بقاعدة البيانات
'    ' [تحسين جوهري]: كل دالة تفتح وتغلق connectionها الخاص
'    '  بدلاً من Conn عالمي ← يمنع Connection Leaks تماماً
'    '══════════════════════════════════════════════════════════════
'    ' [تنظيف]: تم حذف oldLines المكررة — يُستخدم بدلاً منها OldDetailInfo داخل UpdateInvoiceAsync
'    Private Function OpenConnection() As SqlConnection
'        Dim cn As New SqlConnection(ConnectionString)
'        cn.Open()
'        Return cn
'    End Function

'    Private Async Function OpenConnectionAsync() As Task(Of SqlConnection)
'        Dim cn As New SqlConnection(ConnectionString)
'        Await cn.OpenAsync()
'        Return cn
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' أزرار التحكم في الفورم (إغلاق / تكبير / تصغير / تحريك)
'    '══════════════════════════════════════════════════════════════
'    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
'        Close()
'    End Sub

'    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
'        WindowState = If(WindowState = FormWindowState.Normal,
'                         FormWindowState.Maximized, FormWindowState.Normal)
'    End Sub

'    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
'        WindowState = FormWindowState.Minimized
'    End Sub

'    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
'        _x = Control.MousePosition.X - Me.Location.X
'        _y = Control.MousePosition.Y - Me.Location.Y
'    End Sub

'    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
'        If e.Button = MouseButtons.Left Then
'            _newPoint = Control.MousePosition
'            _newPoint.X -= _x
'            _newPoint.Y -= _y
'            Me.Location = _newPoint
'        End If
'    End Sub

'    Private Sub Labels_MouseDown(sender As Object, e As MouseEventArgs) _
'        Handles lblTime.MouseDown, lblDate.MouseDown, lbl_user_name.MouseDown,
'                Label14.MouseDown, Guna2HtmlLabel1.MouseDown
'        _x = Control.MousePosition.X - Me.Location.X
'        _y = Control.MousePosition.Y - Me.Location.Y
'    End Sub

'    Private Sub Labels_MouseMove(sender As Object, e As MouseEventArgs) _
'        Handles lblTime.MouseMove, lblDate.MouseMove, lbl_user_name.MouseMove,
'                Label14.MouseMove, Guna2HtmlLabel1.MouseMove
'        If e.Button = MouseButtons.Left Then
'            _newPoint = Control.MousePosition
'            _newPoint.X -= _x
'            _newPoint.Y -= _y
'            Me.Location = _newPoint
'        End If
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' تحميل الفورم (Async)
'    ' [تحسين]: العمليات الثقيلة تعمل بالتوازي في الخلفية
'    '══════════════════════════════════════════════════════════════
'    Private Async Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        ' التجاوب مع الشاشة: تكبير الفورم لملء الشاشة لو أكبر من المساحة المتاحة
'        LayoutHelper.MaximizeIfTooLarge(Me)

'        Me.KeyPreview = True

'        btn_Invoice_Edit.Visible = False

'        SetupComboPayment()
'        btnToggleDiscount.PerformClick()
'        UpdateLanguageLabel()

'        _timer1.Interval = 1000
'        _timer1.Start()
'        UpdateDateTime()
'        Timer2.Interval = 1000
'        Timer2.Enabled = True

'        ' [تحسين]: تشغيل العمليات الثقيلة بالتوازي بدلاً من التسلسل (تخطي رقم الفاتورة الجديد عند التعديل)
'        If inv_id_edit > 0 Then
'            Await Task.Run(Sub() Me.Invoke(Sub() loadlogininfo()))
'        Else
'            Await Task.WhenAll(
'                Task.Run(Sub() Me.Invoke(Sub() loadlogininfo())),
'                Task.Run(Sub() Me.Invoke(Sub() getnewInvoiceID()))
'            )
'        End If

'        SetupDataGridView(DataGridView1)
'        ' [FIX] تفعيل DoubleBuffered لتقليل الـ Flickering عند تعبئة الأصناف
'        EnableDoubleBuffer(DataGridView1)

'        If inv_id_edit = 0 Then
'            cleartxts()
'            Try
'                txt_Customer_Code.Text = If(SettingsManager.GetSetting("defaultcustomercode"), "1")
'                'Await SearchCustomerByCodeAsync(If(SettingsManager.GetSetting("defaultcustomercode"), "1"))
'                btn_search_CustomerCode.PerformClick()

'                lstNameSuggestions.SelectedIndex = 1
'            Catch ex As Exception

'            End Try
'        End If
'        'txt_Customer_Name.Focus()

'        ' [إصلاح حيوي]: RegisterProductSearchHandlers تمرر متغيرات الفورم الفعلي
'        RegisterProductSearchHandlers()

'        txtDiscount.Text = "0"
'        txt_totelProduct.Text = "0"
'        DataGridView1.Columns("ColQtyPlus").Width = 30
'        DataGridView1.Columns("ColQtyMinus").Width = 30
'        Await LoadTreasuriesAsync()

'        ''الزراير
'        Me.btnSaveInvoice.Location = New Point(1250, 5)
'        Me.btn_Sales_Returns.Location = New Point(900, 5)
'        Me.btnDelete.Location = New Point(600, 5)
'        Me.Button1.Location = New Point(280, 5)
'        Me.btnToggleScanner.Location = New Point(2, 5)


'    End Sub

'    Private Sub SetupComboPayment()
'        With cmb_Pay
'            .DropDownStyle = ComboBoxStyle.DropDownList
'            .FlatStyle = FlatStyle.Popup
'            .Font = New Font("Segoe UI", 14, FontStyle.Bold)
'            .ForeColor = Color.Black
'            .BackColor = Color.White
'            .Items.Clear()
'            .Items.Add("نقدي")
'            .Items.Add("كاش")
'            .Items.Add("آجل")
'            .SelectedIndex = 0
'        End With
'    End Sub

'    Private Sub RegisterProductSearchHandlers()
'        ' ──────────────────────────────────────────────────────────
'        ' [إصلاح حيوي جداً]: كانت SalesManager تنشئ Dim sales As New Sales
'        '  وتحدّث متغيرات على نسخة جديدة مجهولة بدلاً من الفورم الحالي!
'        '  الآن نمرر ByRef مباشرة من هذا الفورم عبر Lambdas.
'        ' ──────────────────────────────────────────────────────────

'        ' حدث اختيار المنتج من قائمة الاسم
'        AddHandler lstNameSuggestions.SelectedIndexChanged,
'            Sub(s, ev)
'                _manager.lstNameSuggestions_SelectedIndexChanged(
'                    s, ev,
'                    txtProductNameSearch,
'                    SelectedProductId,
'                    lstCodeSuggestions,
'                    txtProductCodeSearch,
'                    cmbUnit,
'                    txtSalePrice,
'                    txtQuantity,
'                    CurrentSalePrice,          ' ← ByRef على الفورم الفعلي
'                    CurrentConversionFactor,   ' ← ByRef على الفورم الفعلي
'                    _currentUnitID)            ' ← ByRef على الفورم الفعلي
'            End Sub

'        ' حدث البحث بالاسم
'        AddHandler txtProductNameSearch.TextChanged,
'            Sub(s, ev)
'                _manager.txtProductNameSearch_TextChanged(s, ev, lstNameSuggestions)
'            End Sub

'        ' حدث البحث بالكود
'        AddHandler txtProductCodeSearch.TextChanged,
'            Sub(s, ev)
'                _manager.txtProductCodeSearch_TextChanged(s, ev, lstNameSuggestions)
'            End Sub

'        ' حدث تغيير الوحدة
'        AddHandler cmbUnit.SelectedIndexChanged,
'            Sub(s, ev)
'                _manager.cmbUnit_SelectedIndexChanged(
'                    s, ev,
'                    txtQuantity,
'                    txt_totelProduct,
'                    txtSalePrice,
'                    CurrentConversionFactor,   ' ← ByRef على الفورم الفعلي
'                    CurrentSalePrice,          ' ← ByRef على الفورم الفعلي
'                    _currentUnitID)            ' ← ByRef على الفورم الفعلي
'            End Sub

'        lstCodeSuggestions.Visible = False
'        lstNameSuggestions.Visible = False
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' تفريغ حقول الفاتورة
'    '══════════════════════════════════════════════════════════════
'    Private Sub cleartxts()
'        getnewInvoiceID()
'        txtProductCodeSearch.Clear()
'        txtProductNameSearch.Clear()
'        cmbUnit.DataSource = Nothing
'        cmbUnit.Items.Clear()
'        txt_notes.Clear()
'        txtSalePrice.Clear()
'        txtQuantity.Clear()
'        txt_totelProduct.Clear()
'        txtTotalRequired.Clear()
'        txtDiscount.Clear()
'        txtTotalAfterDiscount.Clear()
'        txtPaid.Clear()
'        txtRemaining.Clear()
'        txt_Customer_Code.Clear()
'        txt_Customer_Name.Clear()
'        txt_Customer_Balance.Clear()
'        cmb_Pay.SelectedIndex = 0
'        cmbUnit.TextAlign = HorizontalAlignment.Center
'        txtSalePrice.TextAlign = HorizontalAlignment.Center
'        txtQuantity.TextAlign = HorizontalAlignment.Center
'        txt_totelProduct.TextAlign = HorizontalAlignment.Center

'        ' مسح الـ Caches عند تفريغ الفاتورة لضمان بيانات محدّثة
'        _purchasePriceCache.Clear()
'        _stockCache.Clear()
'        txt_Customer_Code.Text = 1
'        btn_search_CustomerCode.PerformClick()

'        ' فتح القفل بعد المسح لبدء فاتورة جديدة
'        UnlockInvoice()
'    End Sub

'    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
'        cleartxts()
'    End Sub

'    ' قفل الفاتورة بعد الحفظ: تعطيل أزرار الإضافة والحفظ
'    Private Sub LockInvoiceAfterSave()
'        _invoiceSaved = True
'        btn_add_product.Enabled = False
'        Button2.Enabled = False

'        _prevBalanceForPrint = ParseDecimal(txt_Customer_Balance.Text.Trim())

'        btnSaveInvoice.Enabled = False
'    End Sub

'    ' فتح القفل لبدء فاتورة جديدة
'    Private Sub UnlockInvoice()
'        _invoiceSaved = False
'        btn_add_product.Enabled = True
'        Button2.Enabled = True
'        btnSaveInvoice.Enabled = True
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' إعداد DataGridView مع نمط داكن احترافي
'    '══════════════════════════════════════════════════════════════
'    Private Sub SetupDataGridView(ByVal dgv As DataGridView)
'        dgv.AllowUserToAddRows = False
'        dgv.ReadOnly = True
'        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
'        dgv.MultiSelect = False
'        dgv.BorderStyle = BorderStyle.None
'        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
'        dgv.EnableHeadersVisualStyles = False

'        Dim darkBg As Color = Color.FromArgb(30, 30, 30)
'        Dim darkRow As Color = Color.FromArgb(45, 45, 45)
'        Dim darkAlt As Color = Color.FromArgb(55, 55, 55)
'        Dim darkHdr As Color = Color.FromArgb(64, 64, 64)
'        Dim highlight As Color = Color.FromArgb(0, 122, 204)
'        Dim textClr As Color = Color.Gainsboro


'        dgv.BackgroundColor = darkBg
'        dgv.RowsDefaultCellStyle.BackColor = darkRow
'        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAlt
'        dgv.DefaultCellStyle.ForeColor = textClr
'        dgv.GridColor = Color.FromArgb(80, 80, 80)

'        With dgv
'            .Columns.Clear()
'            .Columns.Add("ColProductID", "ID المنتج")
'            .Columns.Add("ColProduct_Code", "كود المنتج")
'            .Columns.Add("ColProductName", "اسم المنتج")
'            .Columns.Add("ColUnitName", "الوحدة")
'            .Columns.Add("ColPrice", "سعر البيع")

'            Dim colMinus As New DataGridViewButtonColumn() With {
'                .HeaderText = "", .Text = "➖", .Name = "ColQtyMinus",
'                .Width = 5, .UseColumnTextForButtonValue = True}
'            .Columns.Add(colMinus)

'            .Columns.Add("ColQuantity", "الكمية / الوزن")

'            Dim colPlus As New DataGridViewButtonColumn() With {
'                .HeaderText = "", .Text = "➕", .Name = "ColQtyPlus",
'                .Width = 5, .UseColumnTextForButtonValue = True}
'            .Columns.Add(colPlus)

'            .Columns.Add("ColTotal", "الإجمالي")
'            .Columns.Add("ColUnitID", "UnitID")
'            .Columns.Add("ColFactor", "Factor")
'            .Columns.Add("ColProfit", "Profit")
'            .Columns.Add("LastNumScaleBarcode", "lastnum")

'            .Columns("ColProductID").Visible = False
'            .Columns("ColUnitID").Visible = False
'            .Columns("ColFactor").Visible = False
'            .Columns("ColProfit").Visible = False
'            .Columns("LastNumScaleBarcode").Visible = False

'            Dim colDel As New DataGridViewButtonColumn() With {
'                .HeaderText = "حذف", .Text = "❌", .Name = "ColDelete",
'                .UseColumnTextForButtonValue = True}
'            .Columns.Add(colDel)

'            .Columns("ColProductName").Width = 230
'            .Columns("ColQuantity").Width = 160
'            .Columns("ColPrice").DefaultCellStyle.Format = "N2"
'            .Columns("ColTotal").DefaultCellStyle.Format = "N2"

'            For Each col As DataGridViewColumn In .Columns
'                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
'                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
'            Next

'            .RowTemplate.Height = 32
'            .ColumnHeadersHeight = 45
'            .ColumnHeadersDefaultCellStyle.BackColor = darkHdr
'            .ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
'            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 15.0!, FontStyle.Bold)
'            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
'            .DefaultCellStyle.SelectionBackColor = highlight
'            .DefaultCellStyle.SelectionForeColor = Color.White
'            .DefaultCellStyle.Font = New Font("Segoe UI", 14.0!)
'            .RowHeadersVisible = False
'            .DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
'        End With
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' رقم الفاتورة الجديد
'    '══════════════════════════════════════════════════════════════
'    Private Sub getnewInvoiceID()
'        Try
'            Using cn = OpenConnection()
'                Using cmd As New SqlCommand(
'                    "SELECT ISNULL(MAX(Invoice_Code),0)+1 AS NextInv FROM SalesHeader;", cn)
'                    Dim result = cmd.ExecuteScalar()
'                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
'                        txt_Invoice_ID.Text = Convert.ToInt32(result).ToString()
'                    End If
'                End Using
'            End Using
'        Catch ex As Exception
'            ShowError("خطأ في حساب رقم الفاتورة: " & ex.Message)
'        End Try
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' التاريخ والوقت
'    '══════════════════════════════════════════════════════════════
'    Private Sub UpdateDateTime()
'        Dim now As DateTime = DateTime.Now
'        Dim arCulture As New CultureInfo("ar-EG")
'        lblTime.Text = now.ToString("tt hh:mm:ss", arCulture)
'        lblDate.Text = $"{now.ToString("dddd", arCulture)} ، {now.ToString("d", arCulture)} " &
'                       $"{now.ToString("MMMM", arCulture)} {now.ToString("yyyy", arCulture)} م"
'        UpdateLanguageLabel()
'    End Sub

'    Private Sub UpdateLanguageLabel()
'        Dim lang = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName.ToUpper()
'        lblLang.Text = If(lang = "AR", "عربي", "انجليزي")
'    End Sub

'    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
'        UpdateDateTime()
'    End Sub

'    Private Sub Sales_InputLanguageChanged(sender As Object, e As InputLanguageChangedEventArgs) _
'        Handles MyBase.InputLanguageChanged
'        UpdateLanguageLabel()
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' بحث العميل بالكود (Async) ← واجهة لا تتجمد أثناء الاستعلام
'    '══════════════════════════════════════════════════════════════
'    Private Async Sub btn_search_Customer_ID_Click(sender As Object, e As EventArgs) _
'        Handles btn_search_CustomerCode.Click
'        Await SearchCustomerByCodeAsync(txt_Customer_Code.Text.Trim())
'    End Sub

'    Private Async Function SearchCustomerByCodeAsync(code As String) As Task
'        If String.IsNullOrWhiteSpace(code) Then
'            ShowWarning("من فضلك ادخل كود العميل")
'            Return
'        End If
'        Try
'            Using cn = Await OpenConnectionAsync()
'                Using cmd As New SqlCommand(
'                    "SELECT CustomerName, CurrentBalance FROM Customers WHERE CustomerCode=@code", cn)
'                    ' [الأمان]: Parameterized Query يمنع SQL Injection
'                    cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = code
'                    Using rd = Await cmd.ExecuteReaderAsync()
'                        If Await rd.ReadAsync() Then
'                            txt_Customer_Name.Text = rd("CustomerName").ToString()
'                            txt_Customer_Balance.Text = rd("CurrentBalance").ToString()
'                        Else
'                            ShowInfo("العميل غير موجود")
'                            txt_Customer_Name.Clear()
'                            txt_Customer_Balance.Clear()
'                        End If
'                    End Using
'                End Using
'            End Using
'        Catch ex As Exception
'            ShowError("خطأ أثناء جلب بيانات العميل: " & ex.Message)
'        End Try
'    End Function

'    Private Async Sub txt_Customer_Code_KeyDown(sender As Object, e As KeyEventArgs) _
'        Handles txt_Customer_Code.KeyDown
'        If e.KeyCode = Keys.Enter Then
'            Await SearchCustomerByCodeAsync(txt_Customer_Code.Text.Trim())
'        End If
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' البحث بالاسم مع Debounce حقيقي (CancellationToken)
'    ' [تحسين]: 300ms بعد آخر حرف ← يقلل عدد الاستعلامات بشكل كبير
'    '══════════════════════════════════════════════════════════════
'    Private Async Sub txt_Customer_Name_TextChanged(sender As Object, e As EventArgs) _
'        Handles txt_Customer_Name.TextChanged
'        Dim keyword As String = txt_Customer_Name.Text.Trim()
'        If keyword.Length < 1 Then
'            lstSuggestions.Visible = False
'            lstSuggestions.Items.Clear()
'            Return
'        End If

'        ' إلغاء أي بحث سابق لم يكتمل بعد
'        _searchCts?.Cancel()
'        _searchCts = New CancellationTokenSource()
'        Dim token = _searchCts.Token

'        Try
'            Await Task.Delay(300, token)    ' 300ms debounce
'            If token.IsCancellationRequested Then Return

'            Dim suggestions = Await GetCustomerSuggestionsAsync(keyword, token)
'            If token.IsCancellationRequested Then Return

'            lstSuggestions.Items.Clear()
'            If suggestions.Count > 0 Then
'                lstSuggestions.Items.AddRange(suggestions.ToArray())
'                lstSuggestions.Visible = True
'            Else
'                lstSuggestions.Visible = False
'            End If
'        Catch ex As TaskCanceledException
'            ' طبيعي عند إلغاء البحث القديم لا داعي لتسجيل خطأ
'        End Try
'    End Sub

'    Private Async Function GetCustomerSuggestionsAsync(keyword As String,
'                                                        token As CancellationToken) As Task(Of List(Of String))
'        Dim result As New List(Of String)()
'        Try
'            Using cn = Await OpenConnectionAsync()
'                ' [الأمان]: TOP 15 يمنع استرجاع آلاف السجلات + Parameterized
'                Using cmd As New SqlCommand(
'                    "SELECT TOP 15 CustomerName FROM Customers WHERE CustomerName LIKE @kw", cn)
'                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 200).Value = "%" & keyword & "%"
'                    Using rd = Await cmd.ExecuteReaderAsync(token)
'                        While Await rd.ReadAsync(token)
'                            result.Add(rd("CustomerName").ToString())
'                        End While
'                    End Using
'                End Using
'            End Using
'        Catch ex As Exception When Not (TypeOf ex Is TaskCanceledException)
'            ' تجاهل أخطاء البحث الثانوية فقط للـ Debounce
'        End Try
'        Return result
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' بحث العميل بالاسم (Async)
'    '══════════════════════════════════════════════════════════════
'    Private Async Sub btn_search_Customer_name_Click(sender As Object, e As EventArgs) _
'        Handles btn_search_Customer_name.Click
'        If txt_Customer_Name.TextLength = 0 Then
'            ShowWarning("من فضلك ادخل اسم العميل")
'            Return
'        End If
'        Try
'            Using cn = Await OpenConnectionAsync()
'                Using cmd As New SqlCommand(
'                    "SELECT CustomerID,CustomerCode,CustomerName,CurrentBalance " &
'                    "FROM dbo.Customers WHERE CustomerName=@name", cn)
'                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = txt_Customer_Name.Text
'                    Using rd = Await cmd.ExecuteReaderAsync()
'                        If Await rd.ReadAsync() Then
'                            Dim custID As Integer = Convert.ToInt32(rd("CustomerID"))
'                            txt_Customer_Code.Text = rd("CustomerCode").ToString()
'                            txt_Customer_Balance.Text = rd("CurrentBalance").ToString()
'                            rd.Close()
'                            If Not Await IsCustomerActiveAsync(custID) Then
'                                ShowWarning("⚠ هذا العميل غير مُفعل ولا يمكن تنفيذ عملية البيع.")
'                            End If
'                        Else
'                            ShowInfo("العميل غير موجود")
'                            txt_Customer_Code.Clear()
'                            txt_Customer_Balance.Clear()
'                        End If
'                    End Using
'                End Using
'            End Using
'        Catch ex As Exception
'            ShowError("خطأ أثناء جلب بيانات العميل: " & ex.Message)
'        End Try
'    End Sub

'    Private Sub lstSuggestions_Click(sender As Object, e As EventArgs) Handles lstSuggestions.Click
'        If lstSuggestions.SelectedItem IsNot Nothing Then
'            txt_Customer_Name.Text = lstSuggestions.SelectedItem.ToString()
'            lstSuggestions.Visible = False
'            btn_search_Customer_name.PerformClick()
'        End If
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' اختصارات لوحة المفاتيح
'    '══════════════════════════════════════════════════════════════
'    Private Sub Sales_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
'        If e.Control AndAlso e.KeyCode = Keys.F Then
'            e.SuppressKeyPress = True
'            e.Handled = True
'            txtProductNameSearch.Focus()
'        End If
'        If (e.Alt AndAlso e.KeyCode = Keys.F4) OrElse e.KeyCode = Keys.Escape Then
'            e.Handled = True
'            Me.Close()
'        End If

'        Select Case e.KeyCode
'            Case Keys.F1
'                MessageBox.Show(
'                    "الاختصارات المتاحة:" & vbCrLf &
'                    "F2 : حفظ الفاتورة" & vbCrLf &
'                    "F3 : مرتجعات البيع" & vbCrLf &
'                    "F4 : حذف الفاتورة" & vbCrLf &
'                    "F5 : طباعة الفاتورة" & vbCrLf &
'                    "F6 : مسح الحقول" & vbCrLf &
'                    "Ctrl+F : بحث" & vbCrLf &
'                    "Esc : خروج",
'                    "دليل الاختصارات", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Case Keys.F2 : btnSaveInvoice.PerformClick()
'            Case Keys.F3 : btn_Sales_Returns.PerformClick()
'            Case Keys.F4 : btnDelete.PerformClick()
'            Case Keys.F6 : cleartxts()
'            Case Keys.F5 : Button1.PerformClick()
'            Case Keys.Escape : Me.Close()
'        End Select
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' استقبال الباركود
'    '══════════════════════════════════════════════════════════════
'    Public Async Sub ProcessBarcodeData(code As String)
'        Try
'            Dim barcode As String = code.Trim()
'            If String.IsNullOrWhiteSpace(barcode) Then Return

'            If barcode.StartsWith("99") Then
'                Await AddScaleProductToGridAsync(barcode)
'            Else
'                If Await SearchAndFillProductByBarcodeAsync(barcode) Then
'                    txtQuantity.Text = "1"
'                    btn_add_product.PerformClick()
'                End If
'            End If
'        Catch ex As Exception
'            ShowError("خطأ في معالجة الباركود: " & ex.Message)
'        End Try
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' منتجات الميزان (Async)
'    ' [تحسين]: الواجهة لا تتجمد أثناء جلب بيانات الميزان
'    '══════════════════════════════════════════════════════════════
'    Private Async Function AddScaleProductToGridAsync(ByVal barcodeValue As String) As Task
'        Try
'            barcodeValue = barcodeValue.Trim()
'            If String.IsNullOrWhiteSpace(barcodeValue) Then
'                ShowWarning("⚠️ الباركود فارغ.")
'                Return
'            End If
'            If barcodeValue.Length < 13 Then
'                ShowWarning("⚠️ باركود الميزان يجب أن يكون 13 رقم على الأقل.")
'                Return
'            End If
'            If Not barcodeValue.StartsWith("99") Then
'                ShowWarning("⚠️ هذا ليس باركود ميزان (لا يبدأ بـ 99).")
'                Return
'            End If

'            Dim productCodeStr As String = barcodeValue.Substring(2, 5)
'            If Not IsNumeric(productCodeStr) Then
'                ShowWarning("⚠️ كود المنتج داخل الباركود غير صالح.")
'                Return
'            End If

'            Dim productID As Integer = CInt(productCodeStr)
'            ScalID = productID

'            Dim weightStr As String = barcodeValue.Substring(7, 5)
'            Dim lastNum As String = barcodeValue.Substring(12, 1)
'            If Not IsNumeric(weightStr) Then
'                ShowWarning("⚠️ الوزن داخل الباركود غير صالح.")
'                Return
'            End If

'            Dim weightGrams As Decimal = CDec(weightStr)
'            Dim dtScale As DataTable = _manager.GetScaleProductByCode(productID)
'            If dtScale Is Nothing OrElse dtScale.Rows.Count = 0 Then
'                ShowInfo($"⚠️ لا يوجد منتج لهذا الكود: {productCodeStr}")
'                Return
'            End If

'            Dim row As DataRow = dtScale.Rows(0)
'            Dim productName As String = row("Name").ToString()
'            Dim dbPrice As Decimal = CDec(row("Price"))
'            Dim weightKg As Decimal = weightGrams / 1000D
'            Dim totalPrice As Decimal = weightKg * dbPrice

'            ' [تحسين]: جلب الربح في الخلفية بدون تجميد UI
'            Dim profit As Decimal = Await Task.Run(Function() GetScaleProductProfitFromDB(productID, weightKg))

'            '' التحقق من تكرار الباركود
'            'For Each gridRow As DataGridViewRow In DataGridView1.Rows
'            '    If Not gridRow.IsNewRow Then
'            '        If gridRow.Cells("ColProductName").Value?.ToString() = productName AndAlso
'            '           gridRow.Cells("LastNumScaleBarcode").Value?.ToString() = lastNum Then
'            '            ShowWarning("باركود الميزان متكرر")
'            '            Return
'            '        End If
'            '    End If
'            'Next

'            Dim newRow As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Add())
'            newRow.Cells("LastNumScaleBarcode").Value = lastNum
'            newRow.Cells("ColProductID").Value = productID
'            newRow.Cells("ColProduct_Code").Value = productID
'            newRow.Cells("ColProductName").Value = productName
'            newRow.Cells("ColUnitName").Value = "جرام"
'            newRow.Cells("ColPrice").Value = dbPrice
'            newRow.Cells("ColQuantity").Value = weightGrams
'            newRow.Cells("ColProfit").Value = profit
'            newRow.Cells("ColTotal").Value = Math.Round(totalPrice, 2)

'            UpdateInvoiceTotals()

'        Catch ex As Exception
'            ShowError("❌ خطأ أثناء إضافة منتج الميزان: " & ex.Message)
'        End Try
'    End Function

'    ' حساب الربح من الميزان — تُنفّذ في Task.Run (خارج UI Thread)
'    Private Function GetScaleProductProfitFromDB(productID As Integer, weightKg As Decimal) As Decimal
'        Try
'            Using cn = OpenConnection()
'                Using cmd As New SqlCommand(
'                    "SELECT Price, Purchase_Price FROM TheScale WHERE Code=@Code", cn)
'                    cmd.Parameters.Add("@Code", SqlDbType.Int).Value = productID
'                    Using rd = cmd.ExecuteReader()
'                        If rd.Read() Then
'                            Dim pp As Decimal = If(IsDBNull(rd("Purchase_Price")), 0, CDec(rd("Purchase_Price")))
'                            Dim sp As Decimal = If(IsDBNull(rd("Price")), 0, CDec(rd("Price")))
'                            Return (sp - pp) * weightKg
'                        End If
'                    End Using
'                End Using
'            End Using
'        Catch
'            ' إرجاع صفر عند أي خطأ بدلاً من كراش
'        End Try
'        Return 0D
'    End Function

'    Private Async Function SearchAndFillProductByBarcodeAsync(ByVal barcodeValue As String) As Task(Of Boolean)
'        Try
'            Dim dtUnit As DataTable = _manager.GetUnitByBarcode(barcodeValue)
'            If dtUnit.Rows.Count = 1 Then
'                Dim row As DataRow = dtUnit.Rows(0)
'                SelectedProductId = CInt(row("Product_ID").ToString())
'                txtProductNameSearch.Text = row("Product_Name").ToString()
'                If lstNameSuggestions.Items.Count > 0 Then lstNameSuggestions.SelectedIndex = 0
'                cmbUnit.Text = row("Unit_Name").ToString()
'                txtSalePrice.Text = row("Sale_Price").ToString()
'                Return True
'            Else
'                ShowWarning($"لا يوجد منتج مرتبط بالباركود: {barcodeValue}")
'                Return False
'            End If
'        Catch ex As Exception
'            ShowError("خطأ في البحث عن الباركود: " & ex.Message)
'            Return False
'        End Try
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' الحسابات: سعر × كمية
'    '══════════════════════════════════════════════════════════════
'    Private Sub sale_p_product()
'        Dim qty, price As Decimal
'        If Decimal.TryParse(txtQuantity.Text, qty) AndAlso
'           Decimal.TryParse(txtSalePrice.Text, price) Then
'            txt_totelProduct.Text = (price * qty).ToString("0.##")
'        Else
'            txt_totelProduct.Text = ""
'        End If
'    End Sub

'    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
'        sale_p_product()
'    End Sub
'    Private Sub txtSalePrice_TextChanged(sender As Object, e As EventArgs) Handles txtSalePrice.TextChanged
'        sale_p_product()
'    End Sub
'    Private Sub cmbUnit_TextChanged(sender As Object, e As EventArgs) Handles cmbUnit.TextChanged
'        sale_p_product()
'    End Sub

'    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
'        If e.KeyCode = Keys.Enter Then btn_add_product.PerformClick()
'    End Sub

'    Private Sub txtProductNameSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductNameSearch.KeyDown
'        If e.KeyCode = Keys.Down Then lstNameSuggestions.Focus()
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' المخزون المتاح (Async مع Cache)
'    ' [تحسين]: Cache يمنع استعلام DB متكرر للمنتج نفسه في نفس الجلسة
'    '══════════════════════════════════════════════════════════════
'    Private Async Function GetStockQtyAsync(productId As Integer) As Task(Of Decimal)
'        If _stockCache.ContainsKey(productId) Then Return _stockCache(productId)

'        Dim stockQty As Decimal = 0D
'        Try
'            Using cn = Await OpenConnectionAsync()
'                Using cmd As New SqlCommand(
'                    "SELECT Quantity_OnHand FROM Stock WHERE Product_ID=@PID", cn)
'                    cmd.Parameters.Add("@PID", SqlDbType.Int).Value = productId
'                    Dim result = Await cmd.ExecuteScalarAsync()
'                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
'                        stockQty = Convert.ToDecimal(result)
'                    End If
'                End Using
'            End Using
'        Catch ex As Exception
'            ShowError("خطأ في جلب المخزون: " & ex.Message)
'        End Try

'        _stockCache(productId) = stockQty
'        Return stockQty
'    End Function

'    ' نسخة متزامنة للاستخدام داخل Task.Run فقط
'    Private Function GetStockQtySync(productId As Integer) As Decimal
'        If _stockCache.ContainsKey(productId) Then Return _stockCache(productId)
'        Dim stockQty As Decimal = 0D
'        Try
'            Using cn = OpenConnection()
'                Using cmd As New SqlCommand(
'                    "SELECT Quantity_OnHand FROM Stock WHERE Product_ID=@PID", cn)
'                    cmd.Parameters.Add("@PID", SqlDbType.Int).Value = productId
'                    Dim result = cmd.ExecuteScalar()
'                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
'                        stockQty = Convert.ToDecimal(result)
'                    End If
'                End Using
'            End Using
'        Catch
'            ' إرجاع صفر عند أي خطأ
'        End Try
'        _stockCache(productId) = stockQty
'        Return stockQty
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' Cache سعر الشراء
'    '══════════════════════════════════════════════════════════════
'    Private Function GetPurchasePriceFromCache(productId As Integer, unitId As Integer) As Decimal
'        Dim key As String = $"{productId}_{unitId}"
'        If _purchasePriceCache.ContainsKey(key) Then Return _purchasePriceCache(key)

'        Dim result As Decimal = 0D
'        Try
'            Using cn = OpenConnection()
'                Using cmd As New SqlCommand(
'                    "SELECT Purchase_Price FROM ProductUnits WHERE Product_ID=@P AND ProductUnit_ID=@U", cn)
'                    cmd.Parameters.Add("@P", SqlDbType.Int).Value = productId
'                    cmd.Parameters.Add("@U", SqlDbType.Int).Value = unitId
'                    Dim val = cmd.ExecuteScalar()
'                    If val IsNot Nothing AndAlso Not IsDBNull(val) Then result = CDec(val)
'                End Using
'            End Using
'        Catch
'            ' إرجاع صفر عند أي خطأ
'        End Try

'        _purchasePriceCache(key) = result
'        Return result
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' التحقق من حالة المنتج (Async)
'    '══════════════════════════════════════════════════════════════
'    Public Async Function CheckProductStatusAsync(productId As Integer) As Task(Of Boolean)
'        Try
'            Using cn = Await OpenConnectionAsync()
'                Using cmd As New SqlCommand(
'                    "SELECT Product_Name, Product_State FROM Products WHERE Product_ID=@id", cn)
'                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = productId
'                    Using rd = Await cmd.ExecuteReaderAsync()
'                        If Await rd.ReadAsync() Then
'                            Dim pName As String = rd("Product_Name").ToString()
'                            Dim isActive As Boolean = Convert.ToBoolean(rd("Product_State"))
'                            If isActive Then Return True
'                            ShowWarning($"⚠️ المنتج غير نشط ولا يمكن استخدامه حالياً.{vbCrLf}" &
'                                        $"📦 اسم المنتج: {pName}{vbCrLf}🔍 كود المنتج: {productId}")
'                            Return False
'                        Else
'                            ShowError("❌ لم يتم العثور على المنتج المطلوب.")
'                            Return False
'                        End If
'                    End Using
'                End Using
'            End Using
'        Catch ex As Exception
'            ShowError("حدث خطأ: " & ex.Message)
'            Return False
'        End Try
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' إضافة المنتج للفاتورة (Async)
'    ' [تحسين]: الزر لا يتجمد أثناء فحص المخزون لأن العملية Async
'    '══════════════════════════════════════════════════════════════
'    Private Async Sub btn_add_product_Click(sender As Object, e As EventArgs) Handles btn_add_product.Click
'        If _invoiceSaved Then
'            ShowWarning("تم حفظ الفاتورة بالفعل. اضغط (مسح / حذف) لبدء فاتورة جديدة قبل إضافة منتجات.")
'            Return
'        End If
'        If Me.SelectedProductId <= 0 Then
'            ShowWarning("الرجاء اختيار منتج أولاً.")
'            Return
'        End If
'        Dim qty As Decimal
'        If Not Decimal.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
'            ShowWarning("الرجاء إدخال كمية صحيحة.")
'            txtQuantity.Focus()
'            Return
'        End If

'        ' فحص حالة المنتج في الخلفية
'        If Not Await CheckProductStatusAsync(SelectedProductId) Then Return

'        ' إضافة أو تحديث الصف
'        Await UpdateExistingRowOrAddAsync()

'        ClearProductFields()
'        UpdateInvoiceTotals()
'        ' مسح cache المخزون لأن الكمية تغيرت
'        _stockCache.Remove(SelectedProductId)
'        SelectedProductId = 0
'        txtProductNameSearch.Focus()
'    End Sub

'    Private Sub ClearProductFields()
'        getnewInvoiceID()
'        txtProductCodeSearch.Clear()
'        txtProductNameSearch.Clear()
'        cmbUnit.DataSource = Nothing
'        cmbUnit.Items.Clear()
'        txtSalePrice.Clear()
'        txtQuantity.Clear()
'        txt_totelProduct.Clear()
'        txtProductCodeSearch.TextAlign = HorizontalAlignment.Center
'        txtProductNameSearch.TextAlign = HorizontalAlignment.Center
'        cmbUnit.TextAlign = HorizontalAlignment.Center
'        txtSalePrice.TextAlign = HorizontalAlignment.Center
'        txtQuantity.TextAlign = HorizontalAlignment.Center
'        txt_totelProduct.TextAlign = HorizontalAlignment.Center
'    End Sub

'    Private Function GetReservedQty(productId As Integer) As Decimal
'        Dim total As Decimal = 0D
'        For Each row As DataGridViewRow In DataGridView1.Rows
'            If row.IsNewRow Then Continue For
'            Try
'                Dim pid As Integer = 0
'                If Not Integer.TryParse(row.Cells("ColProductID").Value?.ToString(), pid) Then Continue For
'                If pid <> productId Then Continue For

'                Dim rowQty As Decimal = 0D
'                Dim rowFactor As Decimal = 1D
'                Decimal.TryParse(row.Cells("ColQuantity").Value?.ToString(), rowQty)
'                If DataGridView1.Columns.Contains("ColFactor") Then
'                    Dim fo As Decimal = 1D
'                    If Decimal.TryParse(row.Cells("ColFactor").Value?.ToString(), fo) AndAlso fo > 0D Then
'                        rowFactor = fo
'                    End If
'                End If
'                total += rowQty * rowFactor
'            Catch
'            End Try
'        Next
'        Return total
'    End Function

'    Private Async Function UpdateExistingRowOrAddAsync() As Task
'        If Not DataGridView1.Columns.Contains("ColFactor") Then SetupDataGridView(DataGridView1)

'        Dim qtyToAdd As Decimal
'        If Not Decimal.TryParse(txtQuantity.Text.Trim(), qtyToAdd) OrElse qtyToAdd <= 0D Then
'            ShowError("❌ الكمية غير صالحة.")
'            Return
'        End If

'        Dim dgv As DataGridView = DataGridView1
'        Dim currentProductId As Integer = SelectedProductId
'        Dim currentProductCode As String = txtProductCodeSearch.Text.Trim()
'        Dim currentProductName As String = txtProductNameSearch.Text.Trim()
'        Dim currentUnitName As String = cmbUnit.Text.Trim()
'        Dim price As Decimal = CurrentSalePrice

'        If Session.HasPermission("Sales", "CanEdit") Then
'            Dim txtPrice As Decimal = 0D
'            If Decimal.TryParse(txtSalePrice.Text, txtPrice) AndAlso price <> txtPrice Then
'                price = txtPrice
'            End If
'        End If

'        Dim unitId As Integer = _currentUnitID
'        Dim factor As Decimal = CurrentConversionFactor

'        ' [تحسين]: جلب المخزون Async في الخلفية
'        Dim stockQty As Decimal = Await GetStockQtyAsync(currentProductId)
'        Dim reservedQty As Decimal = GetReservedQty(currentProductId)
'        Dim purchasePrice As Decimal = GetPurchasePriceFromCache(currentProductId, unitId)
'        Dim profitPerUnit As Decimal = price - purchasePrice

'        ' البحث عن صف موجود بنفس المنتج والوحدة
'        Dim rowFound As DataGridViewRow = Nothing
'        For Each row As DataGridViewRow In dgv.Rows
'            If row.IsNewRow Then Continue For
'            Dim pid As Integer = 0
'            Integer.TryParse(row.Cells("ColProductID").Value?.ToString(), pid)
'            If pid = currentProductId AndAlso
'               row.Cells("ColProductName").Value?.ToString().Trim() = currentProductName AndAlso
'               row.Cells("ColUnitName").Value?.ToString().Trim() = currentUnitName Then
'                rowFound = row
'                Exit For
'            End If
'        Next

'        If rowFound IsNot Nothing Then
'            ' تحديث صف موجود
'            Dim existingQty As Decimal = 0D
'            Decimal.TryParse(rowFound.Cells("ColQuantity").Value?.ToString(), existingQty)
'            Dim oldContrib As Decimal = existingQty * factor
'            Dim newQty As Decimal = existingQty + qtyToAdd
'            Dim needed As Decimal = (reservedQty - oldContrib) + (newQty * factor)

'            If needed > stockQty Then
'                ShowWarning("❌ الكمية غير متاحة.")
'                Return
'            End If

'            rowFound.Cells("ColQuantity").Value = newQty
'            rowFound.Cells("ColPrice").Value = price
'            rowFound.Cells("ColTotal").Value = Math.Round(newQty * price, 2)
'            rowFound.Cells("ColProfit").Value = Math.Round(profitPerUnit * newQty, 2)
'            rowFound.Cells("ColUnitID").Value = unitId
'            rowFound.Cells("ColFactor").Value = factor
'        Else
'            ' إضافة صف جديد
'            Dim needed As Decimal = reservedQty + (qtyToAdd * factor)
'            If needed > stockQty Then
'                ShowWarning("❌ الكمية غير متاحة.")
'                Return
'            End If

'            Dim newRow As DataGridViewRow = dgv.Rows(dgv.Rows.Add())
'            newRow.Cells("LastNumScaleBarcode").Value = ""
'            newRow.Cells("ColProductID").Value = currentProductId
'            newRow.Cells("ColProduct_Code").Value = currentProductCode
'            newRow.Cells("ColProductName").Value = currentProductName
'            newRow.Cells("ColUnitName").Value = currentUnitName
'            newRow.Cells("ColPrice").Value = price
'            newRow.Cells("ColQuantity").Value = qtyToAdd
'            newRow.Cells("ColProfit").Value = Math.Round(profitPerUnit * qtyToAdd, 2)
'            newRow.Cells("ColTotal").Value = Math.Round(qtyToAdd * price, 2)
'            newRow.Cells("ColUnitID").Value = unitId
'            newRow.Cells("ColFactor").Value = factor
'        End If
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' تحديث إجمالي الفاتورة
'    ' [تحسين]: SuspendLayout + ResumeLayout يمنع الوميض
'    '══════════════════════════════════════════════════════════════
'    Private Sub UpdateInvoiceTotals()
'        Dim grandTotal As Decimal = 0D
'        DataGridView1.SuspendLayout()
'        For Each row As DataGridViewRow In DataGridView1.Rows
'            If Not row.IsNewRow AndAlso row.Cells("ColTotal").Value IsNot Nothing Then
'                grandTotal += Convert.ToDecimal(row.Cells("ColTotal").Value)
'            End If
'        Next
'        DataGridView1.ResumeLayout()

'        txtTotalRequired.Text = grandTotal.ToString("N2")
'        RecalculateTotals()
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' أزرار ➕ ➖ في الجريد (Async)
'    '══════════════════════════════════════════════════════════════
'    Private Async Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
'        Handles DataGridView1.CellClick
'        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

'        Dim dgv = DataGridView1

'        ' ── حذف الصف ──
'        If e.ColumnIndex = dgv.Columns("ColDelete").Index Then
'            Dim pName As String = Convert.ToString(dgv.Rows(e.RowIndex).Cells("ColProductName").Value)
'            If MessageBox.Show($"هل أنت متأكد من حذف الصنف ({pName}) من الفاتورة؟",
'                               "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
'                Dim pid As Integer = 0
'                Integer.TryParse(dgv.Rows(e.RowIndex).Cells("ColProductID").Value?.ToString(), pid)
'                dgv.Rows.RemoveAt(e.RowIndex)
'                If pid > 0 Then _stockCache.Remove(pid)   ' تحديث cache
'                UpdateInvoiceTotals()
'                ShowInfo("تم حذف الصنف.")
'            End If
'            Return
'        End If

'        Dim colName As String = dgv.Columns(e.ColumnIndex).Name
'        If colName <> "ColQtyPlus" AndAlso colName <> "ColQtyMinus" Then Return

'        Dim row = dgv.Rows(e.RowIndex)
'        Dim isUnknown As Boolean = Convert.ToString(row.Cells("ColUnitName").Value) = "غير معرف"

'        Dim qty As Decimal = 0D
'        Decimal.TryParse(Convert.ToString(row.Cells("ColQuantity").Value), qty)
'        Dim price As Decimal = 0D
'        Decimal.TryParse(Convert.ToString(row.Cells("ColPrice").Value), price)
'        Dim productId As Integer = 0
'        Integer.TryParse(Convert.ToString(row.Cells("ColProductID").Value), productId)
'        Dim unitId As Integer = 0
'        Integer.TryParse(Convert.ToString(row.Cells("ColUnitID").Value), unitId)

'        Dim stockQty As Decimal = Decimal.MaxValue
'        If Not isUnknown Then
'            ' [تحسين]: Async لجلب المخزون بدون تجميد UI
'            stockQty = Await GetStockQtyAsync(productId)
'        End If

'        Dim purchasePrice As Decimal = If(isUnknown, 0D,
'            GetPurchasePriceFromCache(productId, unitId))
'        Dim profitPerUnit As Decimal = price - purchasePrice

'        If colName = "ColQtyPlus" Then
'            Dim newQty As Decimal = qty + 1
'            If Not isUnknown AndAlso newQty > stockQty Then
'                ShowWarning("❌ لا يمكن إضافة هذه الكمية. المخزون المتاح: " & stockQty)
'                Return
'            End If
'            qty = newQty
'        ElseIf colName = "ColQtyMinus" Then
'            qty -= 1
'            If qty <= 0 Then
'                dgv.Rows.RemoveAt(e.RowIndex)
'                If Not isUnknown AndAlso productId > 0 Then _stockCache.Remove(productId)
'                UpdateInvoiceTotals()
'                Return
'            End If
'        End If

'        row.Cells("ColQuantity").Value = qty
'        row.Cells("ColTotal").Value = Math.Round(qty * price, 2)
'        row.Cells("ColProfit").Value = Math.Round(qty * profitPerUnit, 2)
'        If Not isUnknown Then _stockCache.Remove(productId)  ' إعادة تحميل cache
'        UpdateInvoiceTotals()
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' الحسابات المالية الموحدة
'    ' [تحسين الأهم]: فلاق _isRecalculating يمنع Cascading Calls
'    '  التي كانت تسبب تجميد الواجهة عند كل ضغطة مفتاح
'    '══════════════════════════════════════════════════════════════
'    Private Sub txtTotalRequired_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRequired.TextChanged
'        If Not _isRecalculating Then RecalculateTotals()
'    End Sub

'    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
'        If _isRecalculating Then Return
'        If txtDiscount.TextLength = 0 Then
'            _isRecalculating = True
'            txtDiscount.Text = "0"
'            _isRecalculating = False
'        End If
'        RecalculateTotals()
'    End Sub

'    Private Sub txtPaid_TextChanged(sender As Object, e As EventArgs) Handles txtPaid.TextChanged
'        If _isRecalculating Then Return
'        If txtPaid.TextLength = 0 Then
'            _isRecalculating = True
'            txtPaid.Text = "0"
'            _isRecalculating = False
'        End If
'        RecalculateTotals()
'    End Sub

'    Private Sub cmb_Pay_SelectedIndexChanged(sender As Object, e As EventArgs) _
'        Handles cmb_Pay.SelectedIndexChanged
'        Select Case cmb_Pay.Text
'            Case "كاش", "نقدي"
'                txtRemaining.Visible = True
'                txtPaid.Visible = True
'                lblRemaining.Visible = True
'                lblPaid.Visible = True
'                btn_auto_pay.Visible = True
'            Case "آجل"
'                _isRecalculating = True
'                txtPaid.Text = "0"
'                _isRecalculating = False
'                txtPaid.Visible = False
'                lblPaid.Visible = False
'                btn_auto_pay.Visible = False
'        End Select
'        RecalculateTotals()
'    End Sub

'    Private Sub RecalculateTotals()
'        If _isRecalculating Then Return
'        _isRecalculating = True
'        Try
'            Dim totalRequired As Decimal
'            If Not Decimal.TryParse(txtTotalRequired.Text, totalRequired) Then
'                txtTotalAfterDiscount.Text = ""
'                txtRemaining.Text = ""
'                Return
'            End If

'            Dim discount As Decimal = 0D
'            If _discountEnabled Then Decimal.TryParse(txtDiscount.Text, discount)

'            If discount > totalRequired Then
'                ShowWarning("⚠️ قيمة الخصم لا يمكن أن تتجاوز المبلغ المطلوب!")
'                txtDiscount.Text = "0"
'                discount = 0D
'            End If

'            Dim afterDiscount As Decimal = totalRequired - discount
'            txtTotalAfterDiscount.Text = afterDiscount.ToString("0.##")

'            Dim paid As Decimal = 0D
'            Decimal.TryParse(txtPaid.Text, paid)
'            Dim remaining As Decimal = paid - afterDiscount
'            txtRemaining.Text = remaining
'            txtRemaining.ForeColor = If(remaining < 0, Color.Red,
'                                        If(remaining > 0, Color.Green, Color.Black))
'        Finally
'            _isRecalculating = False
'        End Try
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' دوال مساعدة للعميل
'    '══════════════════════════════════════════════════════════════
'    Private Async Function GetCustomerIDAsync(customerCode As String) As Task(Of Integer)
'        Dim customerID As Integer = 0
'        Try
'            Using cn = Await OpenConnectionAsync()
'                Using cmd As New SqlCommand(
'                    "SELECT CustomerID FROM Customers WHERE CustomerCode=@code", cn)
'                    cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
'                    Dim obj = Await cmd.ExecuteScalarAsync()
'                    If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
'                        Integer.TryParse(obj.ToString(), customerID)
'                    Else
'                        ShowWarning("لم يتم العثور على عميل بهذا الكود.")
'                    End If
'                End Using
'            End Using
'        Catch ex As Exception
'            ShowError("خطأ أثناء التحقق من العميل: " & ex.Message)
'        End Try
'        Return customerID
'    End Function

'    Public Async Function IsCustomerActiveAsync(customerId As Integer) As Task(Of Boolean)
'        Try
'            Using cn = Await OpenConnectionAsync()
'                Using cmd As New SqlCommand(
'                    "SELECT CAST(IsActive AS INT) FROM Customers WHERE CustomerID=@id", cn)
'                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = customerId
'                    Dim val = Await cmd.ExecuteScalarAsync()
'                    Return val IsNot Nothing AndAlso Convert.ToInt32(val) = 1
'                End Using
'            End Using
'        Catch ex As Exception
'            ShowError("خطأ في التحقق من حالة العميل: " & ex.Message)
'            Return False
'        End Try
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' حفظ الفاتورة (Async + Transaction)
'    ' [تحسين الأكبر]: كل العملية داخل Transaction Async
'    '  واجهة لا تتجمد أبداً أثناء الحفظ
'    '══════════════════════════════════════════════════════════════
'    Private Async Sub btn_SaveInvoice_Click(sender As Object, e As EventArgs) Handles btnSaveInvoice.Click
'        If String.IsNullOrWhiteSpace(txt_Customer_Code.Text) OrElse
'           String.IsNullOrWhiteSpace(txt_Customer_Name.Text) OrElse
'           String.IsNullOrWhiteSpace(txt_Customer_Balance.Text) Then
'            ShowWarning("الرجاء التأكد من بيانات العميل أولاً.")
'            txt_Customer_Name.Focus()
'            Return
'        End If
'        If DataGridView1.Rows.Cast(Of DataGridViewRow)().All(Function(r) r.IsNewRow) Then
'            ShowWarning("يجب إضافة المنتجات للفاتورة أولاً.")
'            Return
'        End If

'        Dim customerCode As String = txt_Customer_Code.Text.Trim()
'        Dim customerID As Integer = Await GetCustomerIDAsync(customerCode)
'        If customerID = 0 Then Return
'        If Not Await IsCustomerActiveAsync(customerID) Then
'            ShowWarning("⚠ هذا العميل غير مُفعل ولا يمكن تنفيذ عملية البيع.")
'            Return
'        End If
'        Dim customerPreviousBalance As Decimal = ParseDecimal(txt_Customer_Balance.Text)

'        Dim totalBefore As Decimal = ParseDecimal(txtTotalRequired.Text)
'        Dim totalAfter As Decimal = ParseDecimal(txtTotalAfterDiscount.Text)
'        Dim discount As Decimal = ParseDecimal(txtDiscount.Text)
'        Dim paid As Decimal = ParseDecimal(txtPaid.Text)
'        Dim remaining As Decimal = ParseDecimal(txtRemaining.Text)
'        Dim notes As String = txt_notes.Text.Trim()
'        Dim userID As Integer = Session.CurrentUserID
'        Dim userName As String = lbl_user_name.Text.Trim()
'        Dim paymentType As String = cmb_Pay.Text.Trim()
'        Dim invoiceCode As Integer = 0

'        ' [الأمان]: التحقق من صحة رقم الفاتورة
'        If Not Integer.TryParse(txt_Invoice_ID.Text.Trim(), invoiceCode) OrElse invoiceCode <= 0 Then
'            ShowError("رقم الفاتورة غير صالح.")
'            Return
'        End If

'        btnSaveInvoice.Enabled = False   ' منع الضغط المزدوج
'        Try
'            Dim newInvoiceID As Integer = 0
'            Dim totalProfit As Decimal = 0D

'            ' جمع بيانات الجريد قبل الـ Await (لأن الجريد على UI Thread)
'            Dim gridData = CollectGridData()

'            Await Task.Run(Async Function()
'                               Using cn = Await OpenConnectionAsync()
'                                   Using transaction As SqlTransaction = cn.BeginTransaction(IsolationLevel.ReadCommitted)
'                                       Try
'                                           newInvoiceID = InsertSalesHeader(invoiceCode, customerID,
'                                               totalBefore, totalAfter, discount, paid, remaining,
'                                               notes, userID, userName, paymentType, SelectedTreasuryid, customerPreviousBalance, cn, transaction)

'                                           InsertSalesDetailsAndUpdateStock(newInvoiceID, gridData, cn, transaction)

'                                           totalProfit = gridData.Sum(Function(r) r.Profit)
'                                           UpdateInvoiceProfitSync(newInvoiceID, totalProfit, cn, transaction)

'                                           If Not CheckCreditLimitSync(customerCode, remaining, cn, transaction) Then
'                                               Throw New Exception("تم رفض العملية: تجاوز حد الائتمان المسموح به للعميل.")
'                                           End If

'                                           UpdateCustomerBalanceSync(customerCode, remaining, cn, transaction)
'                                           If paid > 0D Then

'                                               Await TreasuryService.AddTransactionAsync(
'                                                        treasuryID:=SelectedTreasuryid,
'                                                        transactionType:=TreasuryTransactionTypes.Sale,
'                                                        amount:=paid,
'                                                        isDeposit:=True,
'                                                        referenceID:=newInvoiceID,
'                                                        referenceNo:=invoiceCode.ToString(),
'                                                        notes:="فاتورة بيع رقم " & invoiceCode,
'                                                        userID:=userID,
'                                                        cn:=cn,
'                                                        trans:=transaction)

'                                           End If
'                                           transaction.Commit()
'                                       Catch ex As Exception
'                                           Try : transaction.Rollback() : Catch : End Try
'                                           Throw
'                                       End Try
'                                   End Using
'                               End Using
'                           End Function)

'            ' العودة لـ UI Thread بعد الحفظ
'            _currentIDV = newInvoiceID



'            ' قفل الفاتورة: منع إضافة منتجات أو الحفظ مرة تانية
'            ' المستخدم يقدر يطبع أو يضغط مسح/حذف لبدء فاتورة جديدة
'            LockInvoiceAfterSave()

'            MessageBox.Show($"✅ تم حفظ الفاتورة رقم {newInvoiceID} بنجاح.",
'                            "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)

'            txt_Customer_Code.Text = customerCode
'            Await SearchCustomerByCodeAsync(customerCode)

'            If _isSendToWhatsApp Then
'                Dim phone As String = Await GetCustomerPhoneAsync(customerCode)
'                If IsInternetAvailable() Then

'                    Await SendInvoiceWhatsAppAsync(newInvoiceID, phone)
'                Else
'                    ShowWarning("لا يتوفر اتصال بالانترنت!")
'                End If
'            End If

'            ' مسح الفاتورة بعد الحفظ
'            'DataGridView1.Rows.Clear()
'            'cleartxts()

'        Catch ex As Exception
'            ShowError("❌ فشل الحفظ. تم التراجع عن التغييرات. الخطأ: " & ex.Message)
'        Finally
'            ' لو الفاتورة اتحفظت بنجاح نسيب الزر مقفول لحد ما يضغط مسح/حذف
'            If Not _invoiceSaved Then btnSaveInvoice.Enabled = True
'        End Try
'    End Sub

'    ' ── جمع بيانات الجريد في بنية منفصلة (يُستخدم قبل أي Await) ──
'    ' ══════════════════════════════════════════════════════════════
'    ' جمع بيانات الـ Grid فى قائمة موحّدة
'    ' [تحسين]: يقرأ colIsScaleProduct من العمود المخفى عند وجوده (فاتورة محمّلة للتعديل)
'    '          ويرجع للكشف بالاسم كـ Fallback إذا لم يكن العمود موجوداً
'    ' ══════════════════════════════════════════════════════════════
'    Private Function CollectGridData() As List(Of InvoiceLineData)
'        Dim result As New List(Of InvoiceLineData)()
'        Dim hasScaleCol As Boolean = DataGridView1.Columns.Contains("colIsScaleProduct")

'        For Each row As DataGridViewRow In DataGridView1.Rows
'            If row.IsNewRow Then Continue For

'            Dim line As New InvoiceLineData With {
'                .ProductID = ParseInt(row.Cells("ColProductID").Value),
'                .ProductName = Convert.ToString(row.Cells("ColProductName").Value),
'                .UnitID = ParseInt(row.Cells("ColUnitID").Value),
'                .UnitName = Convert.ToString(row.Cells("ColUnitName").Value),
'                .SalePrice = ParseDecimal(Convert.ToString(row.Cells("ColPrice").Value)),
'                .Quantity = ParseDecimal(Convert.ToString(row.Cells("ColQuantity").Value)),
'                .Total = ParseDecimal(Convert.ToString(row.Cells("ColTotal").Value)),
'                .Factor = ParseDecimal(Convert.ToString(row.Cells("ColFactor").Value)),
'                .Profit = ParseDecimal(Convert.ToString(row.Cells("ColProfit").Value)),
'                .PurchasePriceAtSale = 0D,
'                .IsNewLine = True
'            }

'            ' قراءة علامة منتج الميزان من العمود المخفى (موجود عند تحميل فاتورة للتعديل)
'            If hasScaleCol AndAlso row.Cells("colIsScaleProduct").Value IsNot Nothing Then
'                line.SetScaleProductFlag(Convert.ToBoolean(row.Cells("colIsScaleProduct").Value))
'            End If

'            result.Add(line)
'        Next
'        Return result
'    End Function


'    ' ══════════════════════════════════════════════════════════════
'    ' بيانات سطر الفاتورة (مشتركة بين مسار الإنشاء والتعديل)
'    ' ══════════════════════════════════════════════════════════════
'    Private Class InvoiceLineData

'        Public Property ProductID As Integer
'        Public Property ProductName As String

'        Public Property UnitID As Integer
'        Public Property UnitName As String

'        Public Property SalePrice As Decimal
'        Public Property Quantity As Decimal
'        Public Property Total As Decimal

'        ' معامل التحويل للوحدة (عدد الوحدات الأساسية فى هذه الوحدة)
'        Public Property Factor As Decimal

'        ' الربح النهائى للسطر (يُحسب ويُحدَّث بواسطة InsertSalesDetailsAndUpdateStock)
'        Public Property Profit As Decimal

'        ' تكلفة الشراء وقت البيع — يُحسب ويُحدَّث بواسطة InsertSalesDetailsAndUpdateStock
'        Public Property PurchasePriceAtSale As Decimal

'        ' هل السطر جديد أم كان موجوداً فى الفاتورة؟
'        Public Property IsNewLine As Boolean

'        ' ── علامة صريحة لمنتجات الميزان (تُملأ من Grid أو تُترك Nothing للكشف التلقائى) ──
'        Private _isScaleFlag As Boolean? = Nothing

'        Public Sub SetScaleProductFlag(value As Boolean)
'            _isScaleFlag = value
'        End Sub

'        Public ReadOnly Property IsScaleProduct As Boolean
'            Get
'                ' إذا كانت العلامة مُعيّنة صراحةً (من Grid) نستخدمها
'                If _isScaleFlag.HasValue Then Return _isScaleFlag.Value
'                ' Fallback: كشف بناءً على اسم الوحدة
'                Return UnitName = "جرام" OrElse UnitName = "جم"
'            End Get
'        End Property

'    End Class
'    '══════════════════════════════════════════════════════════════
'    ' إدراج رأس الفاتورة (متزامن داخل Task.Run)
'    '══════════════════════════════════════════════════════════════
'    Private Function InsertSalesHeader(invoiceCode As Integer, customerID As Integer,
'                                       totalBefore As Decimal, totalAfter As Decimal,
'                                       discountVal As Decimal, paid As Decimal, remaining As Decimal,
'                                       notes As String, userID As Integer, userName As String,
'                                       paymentType As String,
'                                       Treasuryid As Integer,
'                                       customerPreviousBalance As Decimal,
'                                       cn As SqlConnection, tx As SqlTransaction) As Integer

'        ' [الأمان]: التحقق من عدم تكرار رقم الفاتورة
'        Using checkCmd As New SqlCommand(
'            "SELECT COUNT(*) FROM SalesHeader WHERE Invoice_Code=@ic", cn, tx)
'            checkCmd.Parameters.Add("@ic", SqlDbType.Int).Value = invoiceCode
'            If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
'                Throw New Exception("كود الفاتورة موجود بالفعل.")
'            End If
'        End Using

'        Dim sql As String =
'            "INSERT INTO SalesHeader(Invoice_Code,Invoice_type,Invoice_Date,Customer_ID," &
'            "User_ID,User_Name,Total_Amount,Discount_Value,Net_Amount,Amount_Paid,Remaining,Payment_Method,Notes,Treasuryid,PreviousBalance)" &
'            " VALUES(@ic,@it,GETDATE(),@cid,@uid,@un,@ta,@dv,@na,@ap,@rem,@pm,@nt,@Tid,@CPB);" &
'            " SELECT SCOPE_IDENTITY();"

'        Using cmd As New SqlCommand(sql, cn, tx)
'            cmd.Parameters.Add("@ic", SqlDbType.Int).Value = invoiceCode
'            cmd.Parameters.Add("@it", SqlDbType.NVarChar, 50).Value = "فاتورة مبيعات"
'            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = customerID
'            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userID
'            cmd.Parameters.Add("@un", SqlDbType.NVarChar, 200).Value = userName
'            cmd.Parameters.Add("@ta", SqlDbType.Decimal).Value = totalAfter
'            cmd.Parameters.Add("@dv", SqlDbType.Decimal).Value = discountVal
'            cmd.Parameters.Add("@na", SqlDbType.Decimal).Value = totalBefore
'            cmd.Parameters.Add("@ap", SqlDbType.Decimal).Value = paid
'            cmd.Parameters.Add("@rem", SqlDbType.Decimal).Value = remaining
'            cmd.Parameters.Add("@pm", SqlDbType.NVarChar, 50).Value = paymentType
'            cmd.Parameters.Add("@nt", SqlDbType.NVarChar, 500).Value = notes
'            cmd.Parameters.Add("@Tid", SqlDbType.Int).Value = Treasuryid
'            cmd.Parameters.Add("@CPB", SqlDbType.Decimal).Value = customerPreviousBalance
'            Dim obj = cmd.ExecuteScalar()
'            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
'                Return CInt(obj)
'            End If
'            Throw New Exception("فشل إنشاء رقم الفاتورة (SCOPE_IDENTITY).")
'        End Using
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' إدراج تفاصيل الفاتورة الجديدة وتحديث المخزون
'    ' [مسار الإنشاء] — يُستدعى عند حفظ فاتورة جديدة لأول مرة
'    '
'    ' [تحسين ERP]: الدالة تحسب Purchase_Price_At_Sale و Profit بنفسها
'    '  بدلاً من الاعتماد على قيم Grid أو حسابات سابقة.
'    '  يضمن ذلك دقة الأرباح التاريخية ولا يتغير الربح إذا تغير سعر الشراء لاحقاً.
'    ' [الأمان]: جميع الاستعلامات تستخدم SqlParameter
'    '══════════════════════════════════════════════════════════════
'    Private Sub InsertSalesDetailsAndUpdateStock(invoiceID As Integer,
'                                                  lines As List(Of InvoiceLineData),
'                                                  cn As SqlConnection, tx As SqlTransaction)
'        If lines Is Nothing OrElse lines.Count = 0 Then Return

'        ' ── جمع قوائم المنتجات المطلوبة لتحميل أسعار الشراء (دفعة واحدة) ──
'        Dim regularItems As New List(Of (ProductID As Integer, UnitID As Integer))
'        Dim scaleItems As New List(Of Integer)   ' أكواد منتجات الميزان

'        For Each line In lines
'            If line.ProductID <= 0 Then Continue For
'            If line.IsScaleProduct Then
'                If Not scaleItems.Contains(line.ProductID) Then
'                    scaleItems.Add(line.ProductID)
'                End If
'            Else
'                Dim exists = regularItems.Any(
'                    Function(x) x.ProductID = line.ProductID AndAlso x.UnitID = line.UnitID)
'                If Not exists Then regularItems.Add((line.ProductID, line.UnitID))
'            End If
'        Next

'        ' ── تحميل أسعار الشراء للمنتجات العادية (ProductUnits) دفعة واحدة ──
'        Dim purchasePriceRegular As New Dictionary(Of String, Decimal)
'        If regularItems.Count > 0 Then
'            Dim conditions As New List(Of String)
'            Using cmd As New SqlCommand()
'                cmd.Connection = cn
'                cmd.Transaction = tx
'                For i As Integer = 0 To regularItems.Count - 1
'                    Dim pParam = "@p" & i.ToString()
'                    Dim uParam = "@u" & i.ToString()
'                    conditions.Add("(Product_ID=" & pParam & " AND ProductUnit_ID=" & uParam & ")")
'                    cmd.Parameters.Add(pParam, SqlDbType.Int).Value = regularItems(i).ProductID
'                    cmd.Parameters.Add(uParam, SqlDbType.Int).Value = regularItems(i).UnitID
'                Next
'                cmd.CommandText =
'                    "SELECT Product_ID, ProductUnit_ID, ISNULL(Purchase_Price,0) AS Purchase_Price " &
'                    "FROM ProductUnits WHERE " & String.Join(" OR ", conditions)
'                Using rd = cmd.ExecuteReader()
'                    While rd.Read()
'                        Dim pid = Convert.ToInt32(rd("Product_ID"))
'                        Dim uid = Convert.ToInt32(rd("ProductUnit_ID"))
'                        purchasePriceRegular(MakeProductUnitKey(pid, uid)) =
'                            Convert.ToDecimal(rd("Purchase_Price"))
'                    End While
'                End Using
'            End Using
'        End If

'        ' ── تحميل أسعار الشراء لمنتجات الميزان (TheScale) دفعة واحدة ──
'        Dim purchasePriceScale As New Dictionary(Of Integer, Decimal)
'        If scaleItems.Count > 0 Then
'            Dim paramNames As New List(Of String)
'            Using cmd As New SqlCommand()
'                cmd.Connection = cn
'                cmd.Transaction = tx
'                For i As Integer = 0 To scaleItems.Count - 1
'                    Dim pParam = "@s" & i.ToString()
'                    paramNames.Add(pParam)
'                    cmd.Parameters.Add(pParam, SqlDbType.Int).Value = scaleItems(i)
'                Next
'                cmd.CommandText =
'                    "SELECT Code, ISNULL(Purchase_Price,0) AS Purchase_Price " &
'                    "FROM TheScale WHERE Code IN (" & String.Join(",", paramNames) & ")"
'                Using rd = cmd.ExecuteReader()
'                    While rd.Read()
'                        purchasePriceScale(Convert.ToInt32(rd("Code"))) =
'                            Convert.ToDecimal(rd("Purchase_Price"))
'                    End While
'                End Using
'            End Using
'        End If

'        ' ── إدراج كل سطر فى SalesDetails مع Purchase_Price_At_Sale و Profit ──
'        For Each line In lines

'            Dim purchasePriceAtSale As Decimal = 0D
'            Dim lineProfit As Decimal = 0D

'            If line.IsScaleProduct Then
'                ' منتج الميزان: الكمية بالجرام، نحوّلها لكيلو للحساب
'                Dim weightKg As Decimal = line.Quantity / 1000D
'                purchasePriceAtSale = If(purchasePriceScale.ContainsKey(line.ProductID),
'                                         purchasePriceScale(line.ProductID), 0D)
'                lineProfit = (line.SalePrice - purchasePriceAtSale) * weightKg
'            Else
'                ' منتج عادى: الربح = (سعر البيع - سعر الشراء) × الكمية
'                Dim key = MakeProductUnitKey(line.ProductID, line.UnitID)
'                purchasePriceAtSale = If(purchasePriceRegular.ContainsKey(key),
'                                         purchasePriceRegular(key), 0D)
'                lineProfit = (line.SalePrice - purchasePriceAtSale) * line.Quantity
'            End If

'            ' تحديث خصائص السطر ليتم جمعها لاحقاً فى إجمالى الربح
'            line.PurchasePriceAtSale = purchasePriceAtSale
'            line.Profit = lineProfit

'            ' إدراج السطر فى SalesDetails مع Purchase_Price_At_Sale
'            Using cmd As New SqlCommand(
'                "INSERT INTO SalesDetails" &
'                "    (Invoice_ID, Product_ID, Product_Name, ProductUnit_ID, ProductUnit_Name," &
'                "     Quantity_Sold, Sale_Price_Per_Unit, Total_Line_Amount," &
'                "     Purchase_Price_At_Sale, Profit)" &
'                " VALUES" &
'                "    (@inv, @pid, @pn, @uid, @un," &
'                "     @qty, @price, @total," &
'                "     @ppa, @profit);",
'                cn, tx)
'                cmd.Parameters.Add("@inv", SqlDbType.Int).Value = invoiceID
'                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = line.ProductID
'                cmd.Parameters.Add("@pn", SqlDbType.NVarChar, 300).Value = line.ProductName
'                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = line.UnitID
'                cmd.Parameters.Add("@un", SqlDbType.NVarChar, 100).Value = line.UnitName
'                cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = line.Quantity
'                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = line.SalePrice
'                cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = line.Total
'                cmd.Parameters.Add("@ppa", SqlDbType.Decimal).Value = purchasePriceAtSale
'                cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = lineProfit
'                cmd.ExecuteNonQuery()
'            End Using

'            ' تحديث المخزون (منتجات الميزان لا تُخصم من Stock)
'            If line.IsScaleProduct OrElse line.ProductID <= 0 Then Continue For
'            Dim qtyToDeduct As Decimal = line.Quantity * If(line.Factor > 0D, line.Factor, 1D)
'            Using cmd As New SqlCommand(
'                "UPDATE Stock SET Quantity_OnHand = Quantity_OnHand - @qty WHERE Product_ID = @pid;",
'                cn, tx)
'                cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = qtyToDeduct
'                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = line.ProductID
'                cmd.ExecuteNonQuery()
'            End Using
'        Next
'    End Sub

'    Private Sub UpdateInvoiceProfitSync(invoiceID As Integer, profit As Decimal,
'                                         cn As SqlConnection, tx As SqlTransaction)
'        Using cmd As New SqlCommand(
'            "UPDATE SalesHeader SET Total_Profit=@p WHERE Invoice_ID=@id", cn, tx)
'            cmd.Parameters.Add("@p", SqlDbType.Decimal).Value = profit
'            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
'            cmd.ExecuteNonQuery()
'        End Using
'    End Sub

'    Private Function CheckCreditLimitSync(customerCode As String, remaining As Decimal,
'                                          cn As SqlConnection, tx As SqlTransaction) As Boolean
'        Dim balanceBefore As Decimal = 0D, creditLimit As Decimal = 0D
'        Using cmd As New SqlCommand(
'            "SELECT ISNULL(CurrentBalance,0),ISNULL(CreditLimit,0) " &
'            "FROM Customers WHERE CustomerCode=@code", cn, tx)
'            cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
'            Using rd = cmd.ExecuteReader()
'                If rd.Read() Then
'                    balanceBefore = Convert.ToDecimal(rd(0))
'                    creditLimit = Convert.ToDecimal(rd(1))
'                End If
'            End Using
'        End Using

'        Dim balanceAfter As Decimal = balanceBefore + remaining
'        If creditLimit > 0D AndAlso -balanceAfter > creditLimit Then
'            Me.Invoke(Sub() ShowWarning(
'                "⚠️ الرصيد بعد العملية سيتجاوز حد الائتمان." & vbCrLf &
'                $"حد الائتمان: {creditLimit}" & vbCrLf &
'                $"الرصيد الحالي (المديونية): {-balanceBefore}" & vbCrLf &
'                $"متبقي الفاتورة: {-remaining}" & vbCrLf &
'                $"الرصيد بعد الفاتورة (المديونية): {-balanceAfter}"))
'            Return False
'        End If
'        Return True
'    End Function

'    Private Sub UpdateCustomerBalanceSync(customerCode As String, remaining As Decimal,
'                                          cn As SqlConnection, tx As SqlTransaction)
'        If remaining = 0D Then Return
'        Using cmd As New SqlCommand(
'            "UPDATE Customers SET CurrentBalance=ISNULL(CurrentBalance,0)+@rem WHERE CustomerCode=@code;",
'            cn, tx)
'            cmd.Parameters.Add("@rem", SqlDbType.Decimal).Value = remaining
'            cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
'            cmd.ExecuteNonQuery()
'        End Using
'    End Sub

'    Private Async Function GetCustomerPhoneAsync(customerCode As String) As Task(Of String)
'        Try
'            Using cn = Await OpenConnectionAsync()
'                Using cmd As New SqlCommand(
'                    "SELECT PhoneNumber FROM Customers WHERE CustomerCode=@code", cn)
'                    cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
'                    Using rd = Await cmd.ExecuteReaderAsync()
'                        If Await rd.ReadAsync() Then
'                            Return If(IsDBNull(rd("PhoneNumber")), "", rd("PhoneNumber").ToString().Trim())
'                        End If
'                    End Using
'                End Using
'            End Using
'        Catch
'            ' إرجاع فارغ عند أي خطأ
'        End Try
'        Return String.Empty
'    End Function


'    '══════════════════════════════════════════════════════════════
'    ' تحميل فاتورة للتعديل
'    '══════════════════════════════════════════════════════════════
'    'Public Async Function LoadInvoiceAsync(invoiceID As Integer) As Task

'    '    If invoiceID <= 0 Then
'    '        ShowWarning("رقم الفاتورة غير صالح.")
'    '        Return
'    '    End If

'    '    DataGridView1.Rows.Clear()

'    '    Using cn = Await OpenConnectionAsync()

'    '        '══════════════════════════════════════
'    '        ' تحميل الهيدر
'    '        '══════════════════════════════════════
'    '        Using cmd As New SqlCommand(
'    '    "SELECT 
'    '        h.Invoice_ID,
'    '        h.Invoice_Code,
'    '        h.Total_Amount,
'    '        h.Discount_Value,
'    '        h.Net_Amount,
'    '        h.Amount_Paid,
'    '        h.Remaining,
'    '        h.Payment_Method,
'    '        h.Notes,
'    '        c.CustomerID,
'    '        c.CustomerCode,
'    '        c.CustomerName,
'    '        ISNULL(c.CurrentBalance,0) AS CurrentBalance
'    '    FROM SalesHeader h
'    '    INNER JOIN Customers c ON h.Customer_ID = c.CustomerID
'    '    WHERE h.Invoice_ID=@id", cn)

'    '            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

'    '            Using rd = Await cmd.ExecuteReaderAsync()

'    '                If Await rd.ReadAsync() Then

'    '                    _currentIDV = Convert.ToInt32(rd("Invoice_ID"))

'    '                    txt_Invoice_ID.Text = rd("Invoice_Code").ToString()

'    '                    txt_Customer_Code.Text = rd("CustomerCode").ToString()
'    '                    txt_Customer_Name.Text = rd("CustomerName").ToString()

'    '                    txt_Customer_Balance.Text = rd("CurrentBalance").ToString()

'    '                    cmb_Pay.Text = rd("Payment_Method").ToString()

'    '                    txtTotalRequired.Text = rd("Net_Amount").ToString()
'    '                    txtTotalAfterDiscount.Text = rd("Total_Amount").ToString()

'    '                    txtDiscount.Text = rd("Discount_Value").ToString()
'    '                    txtPaid.Text = rd("Amount_Paid").ToString()
'    '                    txtRemaining.Text = rd("Remaining")

'    '                    ' [رصيد سابق]: لفاتورة محمّلة للتعديل/إعادة الطباعة، الرصيد السابق ≈ الرصيد الحالي - متبقي الفاتورة.
'    '                    '_prevBalanceForPrint = ParseDecimal(rd("CurrentBalance").ToString()) - ParseDecimal(rd("Remaining").ToString())
'    '                    _prevBalanceForPrint = rd("PreviousBalance").ToString()

'    '                    txt_notes.Text = rd("Notes").ToString()

'    '                Else
'    '                    ShowWarning("الفاتورة غير موجودة.")
'    '                    Return
'    '                End If

'    '            End Using
'    '        End Using


'    '        '══════════════════════════════════════
'    '        ' تحميل تفاصيل الفاتورة
'    '        '══════════════════════════════════════
'    '        Using cmd As New SqlCommand(
'    '    "SELECT 
'    '        P.Product_Code,
'    '        d.Product_ID,
'    '        d.Product_Name,
'    '        d.ProductUnit_ID,
'    '        d.ProductUnit_Name,
'    '        d.Quantity_Sold,
'    '        d.Sale_Price_Per_Unit,
'    '        d.Total_Line_Amount,
'    '        ISNULL(u.Unit_Quantity,1) AS Factor,
'    '        CASE WHEN s.Code IS NULL THEN 0 ELSE 1 END AS IsScaleProduct
'    '    FROM SalesDetails d
'    '    LEFT JOIN ProductUnits u 
'    '        ON d.Product_ID = u.Product_ID 
'    '        AND d.ProductUnit_ID = u.ProductUnit_ID
'    '    LEFT JOIN Products P
'    '        ON d.Product_ID = P.Product_ID
'    '    LEFT JOIN TheScale s 
'    '        ON d.Product_ID = s.Code
'    '    WHERE d.Invoice_ID=@id
'    '    ORDER BY d.Detail_ID", cn)

'    '            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

'    '            Using rd = Await cmd.ExecuteReaderAsync()

'    '                While Await rd.ReadAsync()

'    '                    Dim productID As Integer = If(IsDBNull(rd("Product_ID")), 0, Convert.ToInt32(rd("Product_ID")))
'    '                    Dim productCode As String = rd("Product_Code").ToString()
'    '                    Dim productName As String = rd("Product_Name").ToString()

'    '                    Dim unitID As Integer = If(IsDBNull(rd("ProductUnit_ID")), 0, Convert.ToInt32(rd("ProductUnit_ID")))
'    '                    Dim unitName As String = rd("ProductUnit_Name").ToString()

'    '                    Dim qty As Decimal = If(IsDBNull(rd("Quantity_Sold")), 0D, Convert.ToDecimal(rd("Quantity_Sold")))
'    '                    Dim price As Decimal = If(IsDBNull(rd("Sale_Price_Per_Unit")), 0D, Convert.ToDecimal(rd("Sale_Price_Per_Unit")))
'    '                    Dim total As Decimal = If(IsDBNull(rd("Total_Line_Amount")), 0D, Convert.ToDecimal(rd("Total_Line_Amount")))

'    '                    Dim factor As Decimal = If(IsDBNull(rd("Factor")), 1D, Convert.ToDecimal(rd("Factor")))
'    '                    Dim isScale As Boolean = Convert.ToBoolean(rd("IsScaleProduct"))

'    '                    Dim rowIndex As Integer = DataGridView1.Rows.Add()
'    '                    Dim r = DataGridView1.Rows(rowIndex)

'    '                    ' الأعمدة الظاهرة
'    '                    r.Cells("colProductID").Value = productID
'    '                    r.Cells("ColProduct_Code").Value = productCode
'    '                    r.Cells("colProductName").Value = productName
'    '                    r.Cells("colUnitID").Value = unitID
'    '                    r.Cells("colUnitName").Value = unitName
'    '                    r.Cells("colQuantity").Value = qty
'    '                    r.Cells("ColPrice").Value = price
'    '                    r.Cells("colTotal").Value = total

'    '                    ' الأعمدة المخفية (مهمة للمعالجة)
'    '                    If DataGridView1.Columns.Contains("colFactor") Then
'    '                        r.Cells("colFactor").Value = factor
'    '                    End If

'    '                    If DataGridView1.Columns.Contains("colIsScaleProduct") Then
'    '                        r.Cells("colIsScaleProduct").Value = isScale
'    '                    End If

'    '                End While

'    '            End Using
'    '        End Using

'    '    End Using


'    '    '══════════════════════════════════════
'    '    ' إعادة حساب الإجماليات
'    '    '══════════════════════════════════════
'    '    Try

'    '        Dim total As Decimal = 0D

'    '        For Each r As DataGridViewRow In DataGridView1.Rows
'    '            If r.IsNewRow Then Continue For

'    '            If r.Cells("colTotal").Value IsNot Nothing Then
'    '                total += Convert.ToDecimal(r.Cells("colTotal").Value)
'    '            End If
'    '        Next

'    '        txtTotalRequired.Text = total.ToString("0.00")

'    '        Dim discount As Decimal = ParseDecimal(txtDiscount.Text)

'    '        txtTotalAfterDiscount.Text = (total - discount).ToString("0.00")

'    '        txtRemaining.Text =
'    '        (ParseDecimal(txtTotalAfterDiscount.Text) -
'    '         ParseDecimal(txtPaid.Text)).ToString("0.00")

'    '    Catch
'    '    End Try

'    'End Function



'    '══════════════════════════════════════════════════════════════
'    ' تحميل فاتورة للتعديل
'    '══════════════════════════════════════════════════════════════
'    Public Async Function LoadInvoiceAsync(invoiceID As Integer) As Task

'        If invoiceID <= 0 Then
'            ShowWarning("رقم الفاتورة غير صالح.")
'            Return
'        End If

'        DataGridView1.Rows.Clear()

'        Using cn = Await OpenConnectionAsync()

'            '══════════════════════════════════════
'            ' تحميل الهيدر (تم إضافة PreviousBalance للاستعلام)
'            '══════════════════════════════════════
'            Using cmd As New SqlCommand(
'        "SELECT 
'            h.Invoice_ID,
'            h.Invoice_Code,
'            h.Total_Amount,
'            h.Discount_Value,
'            h.Net_Amount,
'            h.Amount_Paid,
'            h.Remaining,
'            h.Payment_Method,
'            h.Notes,
'            h.PreviousBalance, -- جلب العمود الجديد المخزن تاريخياً مع الفاتورة
'            c.CustomerID,
'            c.CustomerCode,
'            c.CustomerName,
'            ISNULL(c.CurrentBalance,0) AS CurrentBalance
'        FROM SalesHeader h
'        INNER JOIN Customers c ON h.Customer_ID = c.CustomerID
'        WHERE h.Invoice_ID=@id", cn)

'                cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

'                Using rd = Await cmd.ExecuteReaderAsync()

'                    If Await rd.ReadAsync() Then

'                        _currentIDV = Convert.ToInt32(rd("Invoice_ID"))

'                        txt_Invoice_ID.Text = rd("Invoice_Code").ToString()

'                        txt_Customer_Code.Text = rd("CustomerCode").ToString()
'                        txt_Customer_Name.Text = rd("CustomerName").ToString()

'                        ' رصيد العميل المعروض في واجهة التعديل:
'                        ' يُفضل محاسبياً عرض الرصيد "اللحظي" للعميل قبل هذه الفاتورة للتعديل بدقة
'                        Dim prevBal As Decimal = If(IsDBNull(rd("PreviousBalance")), 0D, Convert.ToDecimal(rd("PreviousBalance")))
'                        txt_Customer_Balance.Text = prevBal.ToString("0.00")

'                        cmb_Pay.Text = rd("Payment_Method").ToString()

'                        txtTotalRequired.Text = rd("Net_Amount").ToString()
'                        txtTotalAfterDiscount.Text = rd("Total_Amount").ToString()

'                        txtDiscount.Text = rd("Discount_Value").ToString()
'                        txtPaid.Text = rd("Amount_Paid").ToString()
'                        txtRemaining.Text = rd("Remaining").ToString()

'                        ' حفظ الرصيد التاريخي لغرض إعادة الطباعة بدقة
'                        _prevBalanceForPrint = prevBal

'                        txt_notes.Text = rd("Notes").ToString()

'                    Else
'                        ShowWarning("الفاتورة غير موجودة.")
'                        Return
'                    End If

'                End Using
'            End Using

'            '══════════════════════════════════════
'            ' تحميل تفاصيل الفاتورة
'            '══════════════════════════════════════
'            Using cmd As New SqlCommand(
'        "SELECT 
'            P.Product_Code,
'            d.Product_ID,
'            d.Product_Name,
'            d.ProductUnit_ID,
'            d.ProductUnit_Name,
'            d.Quantity_Sold,
'            d.Sale_Price_Per_Unit,
'            d.Total_Line_Amount,
'            ISNULL(u.Unit_Quantity,1) AS Factor,
'            CASE WHEN s.Code IS NULL THEN 0 ELSE 1 END AS IsScaleProduct
'        FROM SalesDetails d
'        LEFT JOIN ProductUnits u 
'            ON d.Product_ID = u.Product_ID 
'            AND d.ProductUnit_ID = u.ProductUnit_ID
'        LEFT JOIN Products P
'            ON d.Product_ID = P.Product_ID
'        LEFT JOIN TheScale s 
'            ON d.Product_ID = s.Code
'        WHERE d.Invoice_ID=@id
'        ORDER BY d.Detail_ID", cn)

'                cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

'                Using rd = Await cmd.ExecuteReaderAsync()

'                    While Await rd.ReadAsync()

'                        Dim productID As Integer = If(IsDBNull(rd("Product_ID")), 0, Convert.ToInt32(rd("Product_ID")))
'                        Dim productCode As String = rd("Product_Code").ToString()
'                        Dim productName As String = rd("Product_Name").ToString()

'                        Dim unitID As Integer = If(IsDBNull(rd("ProductUnit_ID")), 0, Convert.ToDecimal(rd("ProductUnit_ID")))
'                        Dim unitName As String = rd("ProductUnit_Name").ToString()

'                        Dim qty As Decimal = If(IsDBNull(rd("Quantity_Sold")), 0D, Convert.ToDecimal(rd("Quantity_Sold")))
'                        Dim price As Decimal = If(IsDBNull(rd("Sale_Price_Per_Unit")), 0D, Convert.ToDecimal(rd("Sale_Price_Per_Unit")))
'                        Dim total As Decimal = If(IsDBNull(rd("Total_Line_Amount")), 0D, Convert.ToDecimal(rd("Total_Line_Amount")))

'                        Dim factor As Decimal = If(IsDBNull(rd("Factor")), 1D, Convert.ToDecimal(rd("Factor")))
'                        Dim isScale As Boolean = Convert.ToBoolean(rd("IsScaleProduct"))

'                        Dim rowIndex As Integer = DataGridView1.Rows.Add()
'                        Dim r = DataGridView1.Rows(rowIndex)

'                        ' الأعمدة الظاهرة
'                        r.Cells("colProductID").Value = productID
'                        r.Cells("ColProduct_Code").Value = productCode
'                        r.Cells("colProductName").Value = productName
'                        r.Cells("colUnitID").Value = unitID
'                        r.Cells("colUnitName").Value = unitName
'                        r.Cells("colQuantity").Value = qty
'                        r.Cells("ColPrice").Value = price
'                        r.Cells("colTotal").Value = total

'                        ' الأعمدة المخفية (مهمة للمعالجة)
'                        If DataGridView1.Columns.Contains("colFactor") Then
'                            r.Cells("colFactor").Value = factor
'                        End If

'                        If DataGridView1.Columns.Contains("colIsScaleProduct") Then
'                            r.Cells("colIsScaleProduct").Value = isScale
'                        End If

'                    End While

'                End Using
'            End Using

'        End Using

'        '══════════════════════════════════════
'        ' إعادة حساب الإجماليات
'        '══════════════════════════════════════
'        Try
'            Dim total As Decimal = 0D

'            For Each r As DataGridViewRow In DataGridView1.Rows
'                If r.IsNewRow Then Continue For

'                If r.Cells("colTotal").Value IsNot Nothing Then
'                    total += Convert.ToDecimal(r.Cells("colTotal").Value)
'                End If
'            Next

'            txtTotalRequired.Text = total.ToString("0.00")
'            Dim discount As Decimal = ParseDecimal(txtDiscount.Text)
'            txtTotalAfterDiscount.Text = (total - discount).ToString("0.00")
'            'txtRemaining.Text = (ParseDecimal(txtTotalAfterDiscount.Text) - ParseDecimal(txtPaid.Text)).ToString("0.00")
'            ' إذا كان الصافي النهائي أكبر من المدفوع، نجعل المتبقي بالسالب ليعبر عن المديونية تماشياً مع حسابات الأرصدة
'            Dim calcRemaining As Decimal = ParseDecimal(txtTotalAfterDiscount.Text) - ParseDecimal(txtPaid.Text)
'            If calcRemaining > 0 Then
'                txtRemaining.Text = (-calcRemaining).ToString("0.00")
'            Else
'                txtRemaining.Text = "0.00"
'            End If
'        Catch
'        End Try

'    End Function


'    ' ════════════════════════════════════════════════════════════════════════════
'    ' إعادة تصميم UpdateInvoiceAsync + InsertSalesDetailsAndUpdateStock
'    ' مستوى ERP - مع الحفاظ الكامل على أسماء الجداول/الدوال/الكنترولز الحالية
'    '
'    ' ملاحظة هامة قبل الدمج:
'    '  1) هذا الكود يفترض أن CollectGridData() تُرجع List(Of InvoiceLineData) وأن
'    '     InvoiceLineData تحتوى الخصائص: ProductID, UnitID, ProductName, UnitName,
'    '     Quantity, SalePrice, Total, Profit, Factor, IsScaleProduct (موجودة بالفعل
'    '     أعلاه، وهى نفس الكلاس المُستخدم فى مسار إنشاء فاتورة جديدة).
'    '  2) دالة CheckCreditLimitSync القديمة (بتوقيع CustomerCode/remaining) تبقى
'    '     كما هى لمسار الإنشاء الجديد؛ وأضفنا Overload جديد بتوقيع
'    '     (CustomerID As Integer, projectedBalance As Decimal) خاص بمسار التعديل،
'    '     لأن التعديل يحتاج التعامل بـ CustomerID مباشرة وليس بالكود.
'    '  3) الكود يفترض عمود Purchase_Price_At_Sale موجود فعلاً فى SalesDetails
'    '     وعمود Total_Profit موجود فى SalesHeader وعمود CreditLimit فى Customers.
'    ' ════════════════════════════════════════════════════════════════════════════


'    ' ────────────────────────────────────────────────────────────────────────────
'    ' فئة مساعدة: تمثل سطر قديم من SalesDetails (قبل التعديل) - تُستخدم للمقارنة
'    ' ────────────────────────────────────────────────────────────────────────────
'    ' ────────────────────────────────────────────────────────────────────────────
'    ' بيانات سطر الفاتورة القديمة (قبل التعديل)
'    ' يُستخدم للمقارنة وحساب التكلفة التاريخية عند تغيير الوحدة
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Class OldDetailInfo
'        Public Property ProductID As Integer
'        Public Property UnitID As Integer
'        Public Property Quantity As Decimal
'        Public Property SalePrice As Decimal
'        Public Property PurchasePriceAtSale As Decimal
'        Public Property Profit As Decimal
'        ' معامل التحويل للوحدة القديمة — ضرورى لحساب التكلفة التاريخية عند تغيير الوحدة
'        'costPerBaseUnit = PurchasePriceAtSale / Factor_Old
'        'newPurchasePriceAtSale = costPerBaseUnit × Factor_New
'        Public Property Factor As Decimal
'        'Public Property PreviousBalance As Decimal
'    End Class


'    ' ────────────────────────────────────────────────────────────────────────────
'    ' مفتاح موحّد لكل Dictionary يعتمد على (المنتج + الوحدة)
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Function MakeProductUnitKey(productID As Integer, unitID As Integer) As String
'        Return productID.ToString() & "_" & unitID.ToString()
'    End Function


'    ' ════════════════════════════════════════════════════════════════════════════
'    ' Validation كامل قبل بداية الـ Transaction
'    ' يتحقق من صحة جميع البيانات المدخلة بدون الحاجة لفتح اتصال بقاعدة البيانات
'    ' ════════════════════════════════════════════════════════════════════════════
'    Private Function ValidateInvoiceBeforeSave(
'        customerCode As String,
'        gridData As List(Of InvoiceLineData)) As String

'        ' التحقق من اختيار عميل
'        If String.IsNullOrWhiteSpace(customerCode) Then
'            Return "يجب اختيار عميل أولاً."
'        End If

'        ' التحقق من وجود أصناف
'        If gridData Is Nothing OrElse gridData.Count = 0 Then
'            Return "يجب إضافة صنف واحد على الأقل للفاتورة."
'        End If

'        ' التحقق من صحة كل سطر + عدم التكرار
'        Dim seenKeys As New HashSet(Of String)
'        For Each line In gridData

'            ' الكمية يجب أن تكون موجبة
'            If line.Quantity <= 0D Then
'                Return "الكمية يجب أن تكون أكبر من صفر للصنف: " & line.ProductName
'            End If

'            ' السعر يجب أن يكون موجباً
'            If line.SalePrice <= 0D Then
'                Return "سعر البيع يجب أن يكون أكبر من صفر للصنف: " & line.ProductName
'            End If

'            ' لا يسمح بتكرار نفس الصنف بنفس الوحدة
'            If line.ProductID > 0 Then
'                Dim key As String = MakeProductUnitKey(line.ProductID, line.UnitID)
'                If seenKeys.Contains(key) Then
'                    Return "يوجد تكرار للصنف: " & line.ProductName & " بنفس الوحدة. يرجى دمج الكميات."
'                End If
'                seenKeys.Add(key)
'            End If

'        Next

'        Return String.Empty  ' لا يوجد خطأ
'    End Function


'    ' ════════════════════════════════════════════════════════════════════════════
'    ' البحث عن سطر قديم بـ ProductID فقط (بصرف النظر عن الوحدة)
'    ' يُستخدم لاكتشاف حالة تغيير الوحدة وحساب التكلفة التاريخية بالتناسب
'    ' ════════════════════════════════════════════════════════════════════════════
'    Private Function FindOldEntryByProductID(
'        oldDict As Dictionary(Of String, OldDetailInfo),
'        productID As Integer) As OldDetailInfo

'        For Each kvp In oldDict
'            If kvp.Value.ProductID = productID Then
'                Return kvp.Value
'            End If
'        Next
'        Return Nothing
'    End Function

'    ' ════════════════════════════════════════════════════════════════════════════
'    ' الدالة الرئيسية: UpdateInvoiceAsync (نسخة ERP المصلحة والمطابقة لحساباتك)
'    ' ════════════════════════════════════════════════════════════════════════════
'    'Public Async Function UpdateInvoiceAsync(invoiceID As Integer) As Task

'    '    If invoiceID <= 0 Then
'    '        ShowWarning("رقم الفاتورة غير صالح.")
'    '        Return
'    '    End If

'    '    ' ══════════════════════════════════════════════════════
'    '    ' [الخطوة 1] جمع بيانات الفورم 
'    '    ' ══════════════════════════════════════════════════════
'    '    Dim customerCodeFromForm As String = txt_Customer_Code.Text.Trim()
'    '    Dim notes As String = txt_notes.Text.Trim()
'    '    Dim paymentType As String = cmb_Pay.Text.Trim()

'    '    ' تحقق من اختيار الخزنة بالفورم
'    '    If cmbTreasury.SelectedValue Is Nothing Then
'    '        ShowWarning("يرجى اختيار الخزنة.")
'    '        Return
'    '    End If
'    '    Dim newTreasuryID As Integer = Convert.ToInt32(cmbTreasury.SelectedValue)

'    '    ' ══════════════════════════════════════════════════════
'    '    ' [الخطوة 2] جمع بيانات الـ Grid وإعادة حساب الإجماليات (مطابقة لجدولك)
'    '    ' ══════════════════════════════════════════════════════
'    '    Dim gridData = CollectGridData()

'    '    Dim recalcNet As Decimal = gridData.Sum(Function(x) x.Total) ' Net_Amount (الإجمالي قبل الخصم)
'    '    Dim newDiscount As Decimal = ParseDecimal(txtDiscount.Text)   ' Discount_Value
'    '    Dim recalcTotal As Decimal = recalcNet - newDiscount         ' Total_Amount (الصافي النهائي)
'    '    Dim newPaid As Decimal = ParseDecimal(txtPaid.Text)           ' Amount_Paid

'    '    ' 💡 مطابقة للصورة تماماً: المتبقي = الصافي النهائي - المدفوع
'    '    Dim newRemaining As Decimal = recalcTotal - newPaid           ' Remaining

'    '    ' ══════════════════════════════════════════════════════
'    '    ' [الخطوة 3] Validation كامل قبل بداية الـ Transaction
'    '    ' ══════════════════════════════════════════════════════
'    '    Dim validationError As String = ValidateInvoiceBeforeSave(customerCodeFromForm, gridData)
'    '    If Not String.IsNullOrEmpty(validationError) Then
'    '        ShowWarning(validationError)
'    '        Return
'    '    End If

'    '    Using cn = Await OpenConnectionAsync()
'    '        Using tr = cn.BeginTransaction()

'    '            Try
'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 4] جلب بيانات الهيدر القديمة داخل Transaction
'    '                ' ══════════════════════════════════════════════════
'    '                Dim oldCustomerID As Integer
'    '                Dim oldRemaining As Decimal
'    '                Dim oldTreasuryID As Integer
'    '                Dim oldPaid As Decimal

'    '                LoadOldHeaderForUpdateSync(invoiceID, cn, tr, oldCustomerID, oldRemaining, oldTreasuryID, oldPaid)

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 5] تحديد CustomerID الجديد من CustomerCode الفورم
'    '                ' ══════════════════════════════════════════════════
'    '                Dim newCustomerID As Integer = ResolveCustomerIDFromCodeSync(customerCodeFromForm, cn, tr)
'    '                Dim customerChanged As Boolean = (newCustomerID <> oldCustomerID)

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 6] جلب تفاصيل الفاتورة القديمة فى Dictionary
'    '                ' ══════════════════════════════════════════════════
'    '                Dim oldDetailsDict As Dictionary(Of String, OldDetailInfo) = LoadOldSalesDetailsDictionarySync(invoiceID, cn, tr)

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 7] تحديد الأسطر التى تحتاج جلب PurchasePrice حالى
'    '                ' ══════════════════════════════════════════════════
'    '                Dim neededKeys As New Dictionary(Of String, (ProductID As Integer, UnitID As Integer, IsScale As Boolean))

'    '                For Each row In gridData
'    '                    Dim key = MakeProductUnitKey(row.ProductID, row.UnitID)

'    '                    If Not oldDetailsDict.ContainsKey(key) Then
'    '                        Dim oldEntry = FindOldEntryByProductID(oldDetailsDict, row.ProductID)
'    '                        Dim canUseHistoricalCost As Boolean = oldEntry IsNot Nothing AndAlso
'    '                                                        oldEntry.PurchasePriceAtSale > 0D AndAlso
'    '                                                        oldEntry.Factor > 0D AndAlso
'    '                                                        row.Factor > 0D

'    '                        If Not canUseHistoricalCost Then
'    '                            If Not neededKeys.ContainsKey(key) Then
'    '                                neededKeys(key) = (row.ProductID, row.UnitID, row.IsScaleProduct)
'    '                            End If
'    '                        End If
'    '                    ElseIf oldDetailsDict(key).PurchasePriceAtSale <= 0D Then
'    '                        If Not neededKeys.ContainsKey(key) Then
'    '                            neededKeys(key) = (row.ProductID, row.UnitID, row.IsScaleProduct)
'    '                        End If
'    '                    End If
'    '                Next

'    '                Dim purchasePricesDict As Dictionary(Of String, Decimal) = LoadPurchasePricesBatchSync(neededKeys.Values.ToList(), cn, tr)

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 8] فحص حد الائتمان بعد إزالة أثر الفاتورة القديمة
'    '                ' ══════════════════════════════════════════════════
'    '                Dim creditOk As Boolean
'    '                If Not customerChanged Then
'    '                    Dim currentBalance As Decimal = GetCustomerBalanceSync(newCustomerID, cn, tr)
'    '                    Dim projectedBalance As Decimal = (currentBalance - oldRemaining) + newRemaining
'    '                    creditOk = CheckCreditLimitSync(newCustomerID, projectedBalance, cn, tr)
'    '                Else
'    '                    Dim newCustomerBalance As Decimal = GetCustomerBalanceSync(newCustomerID, cn, tr)
'    '                    creditOk = CheckCreditLimitSync(newCustomerID, newCustomerBalance + newRemaining, cn, tr)
'    '                End If

'    '                If Not creditOk Then
'    '                    Throw New Exception("تجاوز حد الائتمان المسموح به لهذا العميل.")
'    '                End If

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 9] إعادة المخزون القديم (استعلام مجمّع واحد)
'    '                ' ══════════════════════════════════════════════════
'    '                Using cmd As New SqlCommand(
'    '            "UPDATE S " &
'    '            "SET S.Quantity_OnHand = S.Quantity_OnHand + (D.Quantity_Sold * ISNULL(U.Unit_Quantity,1)) " &
'    '            "FROM Stock S " &
'    '            "INNER JOIN SalesDetails D ON S.Product_ID = D.Product_ID " &
'    '            "LEFT JOIN ProductUnits U " &
'    '            "   ON D.Product_ID = U.Product_ID " &
'    '            "   AND D.ProductUnit_ID = U.ProductUnit_ID " &
'    '            "WHERE D.Invoice_ID=@id", cn, tr)
'    '                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
'    '                    cmd.ExecuteNonQuery()
'    '                End Using

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 10] التحقق من كفاية المخزون للكميات الجديدة
'    '                ' ══════════════════════════════════════════════════
'    '                ValidateStockAvailabilitySync(gridData, cn, tr)

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 11] حذف تفاصيل الفاتورة القديمة
'    '                ' ══════════════════════════════════════════════════
'    '                Using cmd As New SqlCommand("DELETE FROM SalesDetails WHERE Invoice_ID=@id", cn, tr)
'    '                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
'    '                    cmd.ExecuteNonQuery()
'    '                End Using

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 12] إدخال التفاصيل الجديدة وتحديث المخزن
'    '                ' ══════════════════════════════════════════════════
'    '                InsertSalesDetailsAndUpdateStock(invoiceID, gridData, oldDetailsDict, purchasePricesDict, cn, tr)

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 13] حساب إجمالى الربح 
'    '                ' ══════════════════════════════════════════════════
'    '                Dim totalProfit As Decimal = gridData.Sum(Function(x) x.Profit)

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 14] تحديث هيدر الفاتورة بالأسماء الصحيحة لحقول جدولك الظاهر بالصورة
'    '                ' ══════════════════════════════════════════════════
'    '                Using cmd As New SqlCommand(
'    '            "UPDATE SalesHeader " &
'    '            "SET Net_Amount      = @net,     " & ' الإجمالي قبل الخصم
'    '            "    Discount_Value  = @discount," & ' قيمة الخصم
'    '            "    Total_Amount    = @total,   " & ' الصافي بعد الخصم
'    '            "    Amount_Paid     = @paid,    " & ' المدفوع
'    '            "    Remaining       = @rem,     " & ' المتبقي
'    '            "    Payment_Method  = @pm,      " &
'    '            "    Notes           = @notes,   " &
'    '            "    Total_Profit    = @profit,  " &
'    '            "    Customer_ID     = @custId,  " &
'    '            "    TreasuryID      = @treasuryId " &
'    '            "WHERE Invoice_ID    = @id", cn, tr)

'    '                    cmd.Parameters.Add("@net", SqlDbType.Decimal).Value = recalcNet
'    '                    cmd.Parameters.Add("@discount", SqlDbType.Decimal).Value = newDiscount
'    '                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = recalcTotal
'    '                    cmd.Parameters.Add("@paid", SqlDbType.Decimal).Value = newPaid
'    '                    cmd.Parameters.Add("@rem", SqlDbType.Decimal).Value = newRemaining
'    '                    cmd.Parameters.Add("@pm", SqlDbType.NVarChar, 50).Value = paymentType
'    '                    cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 500).Value = notes
'    '                    cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = totalProfit
'    '                    cmd.Parameters.Add("@custId", SqlDbType.Int).Value = newCustomerID
'    '                    cmd.Parameters.Add("@treasuryId", SqlDbType.Int).Value = newTreasuryID
'    '                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
'    '                    cmd.ExecuteNonQuery()
'    '                End Using

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 14 مكرر]: منطق "الفرق المالي المباشر" المصلح للخزائن (متوافق مع الفواتير القديمة)
'    '                ' ══════════════════════════════════════════════════
'    '                ' حساب فرق المال الجديد مطروحاً منه المال القديم
'    '                Dim treasuryDiff As Decimal = newPaid - oldPaid

'    '                If treasuryDiff <> 0D Then
'    '                    ' إذا كانت فاتورة قديمة (مفيش خزنة oldTreasuryID = 0)؛ نعتبر المدفوع القديم كأنه 0، ويتم إيداع المبلغ الجديد بالكامل في الخزنة الحالية.
'    '                    Dim finalTreasuryID As Integer = If(oldTreasuryID > 0, oldTreasuryID, newTreasuryID)
'    '                    Dim finalDiff As Decimal = If(oldTreasuryID > 0, treasuryDiff, newPaid)

'    '                    If finalDiff <> 0D Then
'    '                        Dim isDepositAction As Boolean = (finalDiff > 0)
'    '                        Dim absoluteAmount As Decimal = Math.Abs(finalDiff)

'    '                        Await TreasuryService.AddTransactionAsync(
'    '                        treasuryID:=finalTreasuryID,
'    '                        transactionType:=TreasuryTransactionTypes.Sale,
'    '                        amount:=absoluteAmount,
'    '                        isDeposit:=isDepositAction, ' True لإيداع فرق الزيادة، False لسحب فرق النقصان
'    '                        referenceID:=invoiceID,
'    '                        referenceNo:=invoiceID.ToString(),
'    '                        notes:="تعديل فاتورة مبيعات - " & If(isDepositAction, "إيداع فرق التعديل", "سحب فرق التعديل"),
'    '                        userID:=Session.CurrentUserID,
'    '                        cn:=cn,
'    '                        trans:=tr
'    '                    )
'    '                    End If
'    '                End If

'    '                ' ══════════════════════════════════════════════════
'    '                ' [الخطوة 15] تعديل رصيد العميل / العملاء
'    '                ' ══════════════════════════════════════════════════
'    '                If Not customerChanged Then
'    '                    Dim diff As Decimal = newRemaining - oldRemaining
'    '                    If diff <> 0D Then
'    '                        AdjustCustomerBalanceByIDSync(newCustomerID, diff, cn, tr)
'    '                    End If
'    '                Else
'    '                    If oldRemaining <> 0D Then
'    '                        AdjustCustomerBalanceByIDSync(oldCustomerID, -oldRemaining, cn, tr)
'    '                    End If
'    '                    If newRemaining <> 0D Then
'    '                        AdjustCustomerBalanceByIDSync(newCustomerID, newRemaining, cn, tr)
'    '                    End If
'    '                End If

'    '                tr.Commit()

'    '                ' تحديث شاشة العرض للمستخدم بالقيم الجديدة الصحيحة
'    '                txtTotalRequired.Text = recalcNet.ToString("0.00")
'    '                txtTotalAfterDiscount.Text = recalcTotal.ToString("0.00")
'    '                txtRemaining.Text = newRemaining.ToString("0.00")

'    '                MessageBox.Show("تم تعديل الفاتورة وتحديث حسابات الخزن بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

'    '            Catch ex As Exception
'    '                Try
'    '                    tr.Rollback()
'    '                Catch
'    '                End Try
'    '                ShowError("خطأ أثناء تعديل الفاتورة: " & ex.Message)
'    '            End Try
'    '        End Using
'    '    End Using
'    'End Function


'    ' ════════════════════════════════════════════════════════════════════════════
'    ' الدالة الرئيسية: UpdateInvoiceAsync (النسخة المصلحة لحسابات الرصيد السابق)
'    ' ════════════════════════════════════════════════════════════════════════════
'    Public Async Function UpdateInvoiceAsync(invoiceID As Integer) As Task

'        If invoiceID <= 0 Then
'            ShowWarning("رقم الفاتورة غير صالح.")
'            Return
'        End If

'        ' ══════════════════════════════════════════════════════
'        ' [الخطوة 1] جمع بيانات الفورم 
'        ' ══════════════════════════════════════════════════════
'        Dim customerCodeFromForm As String = txt_Customer_Code.Text.Trim()
'        Dim notes As String = txt_notes.Text.Trim()
'        Dim paymentType As String = cmb_Pay.Text.Trim()

'        ' تحقق من اختيار الخزنة بالفورم
'        If cmbTreasury.SelectedValue Is Nothing Then
'            ShowWarning("يرجى اختيار الخزنة.")
'            Return
'        End If
'        Dim newTreasuryID As Integer = Convert.ToInt32(cmbTreasury.SelectedValue)

'        ' ══════════════════════════════════════════════════════
'        ' [الخطوة 2] جمع بيانات الـ Grid وإعادة حساب الإجماليات 
'        ' ══════════════════════════════════════════════════════
'        Dim gridData = CollectGridData()

'        Dim recalcNet As Decimal = gridData.Sum(Function(x) x.Total) ' Net_Amount (الإجمالي قبل الخصم)
'        Dim newDiscount As Decimal = ParseDecimal(txtDiscount.Text)   ' Discount_Value
'        Dim recalcTotal As Decimal = recalcNet - newDiscount         ' Total_Amount (الصافي النهائي)
'        Dim newPaid As Decimal = ParseDecimal(txtPaid.Text)           ' Amount_Paid
'        'Dim newRemaining As Decimal = recalcTotal - newPaid           ' Remaining


'        ' المتبقي الفعلي كقيمة مديونية سالبة
'        Dim calculatedRemaining As Decimal = recalcTotal - newPaid
'        Dim newRemaining As Decimal = If(calculatedRemaining > 0, -calculatedRemaining, 0D)
'        ' ══════════════════════════════════════════════════════
'        ' [الخطوة 3] Validation كامل قبل بداية الـ Transaction
'        ' ══════════════════════════════════════════════════════
'        Dim validationError As String = ValidateInvoiceBeforeSave(customerCodeFromForm, gridData)
'        If Not String.IsNullOrEmpty(validationError) Then
'            ShowWarning(validationError)
'            Return
'        End If

'        Using cn = Await OpenConnectionAsync()
'            Using tr = cn.BeginTransaction()

'                Try
'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 4] جلب بيانات الهيدر القديمة داخل Transaction
'                    ' ══════════════════════════════════════════════════
'                    Dim oldCustomerID As Integer
'                    Dim oldRemaining As Decimal
'                    Dim oldTreasuryID As Integer
'                    Dim oldPaid As Decimal

'                    LoadOldHeaderForUpdateSync(invoiceID, cn, tr, oldCustomerID, oldRemaining, oldTreasuryID, oldPaid)

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 5] تحديد CustomerID الجديد من CustomerCode الفورم
'                    ' ══════════════════════════════════════════════════
'                    Dim newCustomerID As Integer = ResolveCustomerIDFromCodeSync(customerCodeFromForm, cn, tr)
'                    Dim customerChanged As Boolean = (newCustomerID <> oldCustomerID)

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 6] تحديد الرصيد السابق التاريخي المناسب للفاتورة المُعدلة
'                    ' ══════════════════════════════════════════════════
'                    Dim finalPreviousBalance As Decimal = 0D
'                    If Not customerChanged Then
'                        ' إذا لم يتغير العميل، يبقى رصيده السابق التاريخي للفاتورة كما هو دون تعديل
'                        Using cmdGetPrev = New SqlCommand("SELECT ISNULL(PreviousBalance, 0) FROM SalesHeader WHERE Invoice_ID = @id", cn, tr)
'                            cmdGetPrev.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
'                            finalPreviousBalance = Convert.ToDecimal(cmdGetPrev.ExecuteScalar())
'                        End Using
'                    Else
'                        ' إذا قام الكاشير بتغيير العميل بالكامل في الفاتورة أثناء التعديل:
'                        ' يصبح رصيده السابق التاريخي لهذه الفاتورة هو "الرصيد الحالي لهذا العميل الجديد"
'                        finalPreviousBalance = GetCustomerBalanceSync(newCustomerID, cn, tr)
'                    End If

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 7] جلب تفاصيل الفاتورة القديمة فى Dictionary
'                    ' ══════════════════════════════════════════════════
'                    Dim oldDetailsDict As Dictionary(Of String, OldDetailInfo) = LoadOldSalesDetailsDictionarySync(invoiceID, cn, tr)

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 8] تحديد الأسطر التى تحتاج جلب PurchasePrice حالى
'                    ' ══════════════════════════════════════════════════
'                    Dim neededKeys As New Dictionary(Of String, (ProductID As Integer, UnitID As Integer, IsScale As Boolean))

'                    For Each row In gridData
'                        Dim key = MakeProductUnitKey(row.ProductID, row.UnitID)

'                        If Not oldDetailsDict.ContainsKey(key) Then
'                            Dim oldEntry = FindOldEntryByProductID(oldDetailsDict, row.ProductID)
'                            Dim canUseHistoricalCost As Boolean = oldEntry IsNot Nothing AndAlso
'                                                                  oldEntry.PurchasePriceAtSale > 0D AndAlso
'                                                                  oldEntry.Factor > 0D AndAlso
'                                                                  row.Factor > 0D

'                            If Not canUseHistoricalCost Then
'                                If Not neededKeys.ContainsKey(key) Then
'                                    neededKeys(key) = (row.ProductID, row.UnitID, row.IsScaleProduct)
'                                End If
'                            End If
'                        ElseIf oldDetailsDict(key).PurchasePriceAtSale <= 0D Then
'                            If Not neededKeys.ContainsKey(key) Then
'                                neededKeys(key) = (row.ProductID, row.UnitID, row.IsScaleProduct)
'                            End If
'                        End If
'                    Next

'                    Dim purchasePricesDict As Dictionary(Of String, Decimal) = LoadPurchasePricesBatchSync(neededKeys.Values.ToList(), cn, tr)

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 9] فحص حد الائتمان بعد إزالة أثر الفاتورة القديمة
'                    ' ══════════════════════════════════════════════════
'                    Dim creditOk As Boolean
'                    If Not customerChanged Then
'                        Dim currentBalance As Decimal = GetCustomerBalanceSync(newCustomerID, cn, tr)
'                        ' موازنة الرصيد الحالي للعميل باستثناء المديونية السابقة للفاتورة وإضافة الجديدة
'                        Dim projectedBalance As Decimal = (currentBalance - oldRemaining) + newRemaining
'                        creditOk = CheckCreditLimitSync(newCustomerID, projectedBalance, cn, tr)
'                    Else
'                        ' إذا كان عميلاً جديداً، نجمع رصيده الحالي زائد المتبقي الجديد للفاتورة
'                        Dim newCustomerBalance As Decimal = GetCustomerBalanceSync(newCustomerID, cn, tr)
'                        creditOk = CheckCreditLimitSync(newCustomerID, newCustomerBalance + newRemaining, cn, tr)
'                    End If

'                    If Not creditOk Then
'                        Throw New Exception("تجاوز حد الائتمان المسموح به لهذا العميل.")
'                    End If

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 10] إعادة المخزون القديم (استعلام مجمّع واحد)
'                    ' ══════════════════════════════════════════════════
'                    Using cmd As New SqlCommand(
'                "UPDATE S " &
'                "SET S.Quantity_OnHand = S.Quantity_OnHand + (D.Quantity_Sold * ISNULL(U.Unit_Quantity,1)) " &
'                "FROM Stock S " &
'                "INNER JOIN SalesDetails D ON S.Product_ID = D.Product_ID " &
'                "LEFT JOIN ProductUnits U " &
'                "   ON D.Product_ID = U.Product_ID " &
'                "   AND D.ProductUnit_ID = U.ProductUnit_ID " &
'                "WHERE D.Invoice_ID=@id", cn, tr)
'                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
'                        cmd.ExecuteNonQuery()
'                    End Using

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 11] التحقق من كفاية المخزون للكميات الجديدة
'                    ' ══════════════════════════════════════════════════
'                    ValidateStockAvailabilitySync(gridData, cn, tr)

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 12] حذف تفاصيل الفاتورة القديمة
'                    ' ══════════════════════════════════════════════════
'                    Using cmd As New SqlCommand("DELETE FROM SalesDetails WHERE Invoice_ID=@id", cn, tr)
'                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
'                        cmd.ExecuteNonQuery()
'                    End Using

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 13] إدخال التفاصيل الجديدة وتحديث المخزن
'                    ' ══════════════════════════════════════════════════
'                    InsertSalesDetailsAndUpdateStock(invoiceID, gridData, oldDetailsDict, purchasePricesDict, cn, tr)

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 14] حساب إجمالى الربح 
'                    ' ══════════════════════════════════════════════════
'                    Dim totalProfit As Decimal = gridData.Sum(Function(x) x.Profit)

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 15] تحديث هيدر الفاتورة (بما في ذلك PreviousBalance الجديد)
'                    ' ══════════════════════════════════════════════════
'                    Using cmd As New SqlCommand(
'                "UPDATE SalesHeader " &
'                "SET Net_Amount      = @net,     " &
'                "    Discount_Value  = @discount," &
'                "    Total_Amount    = @total,   " &
'                "    Amount_Paid     = @paid,    " &
'                "    Remaining       = @rem,     " &
'                "    Payment_Method  = @pm,      " &
'                "    Notes           = @notes,   " &
'                "    Total_Profit    = @profit,  " &
'                "    Customer_ID     = @custId,  " &
'                "    TreasuryID      = @treasuryId, " &
'                "    PreviousBalance = @prevBal  " & ' تم إضافة تحديث الرصيد السابق هنا لحماية التقارير
'                "WHERE Invoice_ID    = @id", cn, tr)

'                        cmd.Parameters.Add("@net", SqlDbType.Decimal).Value = recalcNet
'                        cmd.Parameters.Add("@discount", SqlDbType.Decimal).Value = newDiscount
'                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = recalcTotal
'                        cmd.Parameters.Add("@paid", SqlDbType.Decimal).Value = newPaid
'                        cmd.Parameters.Add("@rem", SqlDbType.Decimal).Value = newRemaining
'                        cmd.Parameters.Add("@pm", SqlDbType.NVarChar, 50).Value = paymentType
'                        cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 500).Value = notes
'                        cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = totalProfit
'                        cmd.Parameters.Add("@custId", SqlDbType.Int).Value = newCustomerID
'                        cmd.Parameters.Add("@treasuryId", SqlDbType.Int).Value = newTreasuryID
'                        cmd.Parameters.Add("@prevBal", SqlDbType.Decimal).Value = finalPreviousBalance ' الرصيد المناسب
'                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
'                        cmd.ExecuteNonQuery()
'                    End Using

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 16]: منطق "الفرق المالي المباشر" المصلح للخزائن
'                    ' ══════════════════════════════════════════════════
'                    Dim treasuryDiff As Decimal = newPaid - oldPaid

'                    If treasuryDiff <> 0D Then
'                        Dim finalTreasuryID As Integer = If(oldTreasuryID > 0, oldTreasuryID, newTreasuryID)
'                        Dim finalDiff As Decimal = If(oldTreasuryID > 0, treasuryDiff, newPaid)

'                        If finalDiff <> 0D Then
'                            Dim isDepositAction As Boolean = (finalDiff > 0)
'                            Dim absoluteAmount As Decimal = Math.Abs(finalDiff)

'                            Await TreasuryService.AddTransactionAsync(
'                                treasuryID:=finalTreasuryID,
'                                transactionType:=TreasuryTransactionTypes.Sale,
'                                amount:=absoluteAmount,
'                                isDeposit:=isDepositAction,
'                                referenceID:=invoiceID,
'                                referenceNo:=invoiceID.ToString(),
'                                notes:="تعديل فاتورة مبيعات - " & If(isDepositAction, "إيداع فرق التعديل", "سحب فرق التعديل"),
'                                userID:=Session.CurrentUserID,
'                                cn:=cn,
'                                trans:=tr
'                            )
'                        End If
'                    End If

'                    ' ══════════════════════════════════════════════════
'                    ' [الخطوة 17] تعديل رصيد العميل / العملاء الفعلي
'                    ' ══════════════════════════════════════════════════
'                    If Not customerChanged Then
'                        Dim diff As Decimal = newRemaining - oldRemaining
'                        If diff <> 0D Then
'                            AdjustCustomerBalanceByIDSync(newCustomerID, diff, cn, tr)
'                        End If
'                    Else
'                        ' إذا تم تغيير العميل: نرجع للعميل القديم مديونيته التي ألغيت، ونخصم من العميل الجديد المديونية الجديدة
'                        If oldRemaining <> 0D Then
'                            AdjustCustomerBalanceByIDSync(oldCustomerID, -oldRemaining, cn, tr)
'                        End If
'                        If newRemaining <> 0D Then
'                            AdjustCustomerBalanceByIDSync(newCustomerID, newRemaining, cn, tr)
'                        End If
'                    End If

'                    tr.Commit()

'                    ' تحديث واجهة العرض للمستخدم
'                    txtTotalRequired.Text = recalcNet.ToString("0.00")
'                    txtTotalAfterDiscount.Text = recalcTotal.ToString("0.00")
'                    txtRemaining.Text = newRemaining.ToString("0.00")
'                    txt_Customer_Balance.Text = finalPreviousBalance.ToString("0.00") ' الرصيد السابق المعروض بالواجهة

'                    MessageBox.Show("تم تعديل الفاتورة وتحديث حسابات الأرصدة والخزن بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

'                Catch ex As Exception
'                    Try
'                        tr.Rollback()
'                    Catch
'                    End Try
'                    ShowError("خطأ أثناء تعديل الفاتورة: " & ex.Message)
'                End Try
'            End Using
'        End Using
'    End Function
'    ' ════════════════════════════════════════════════════════════════════════════
'    ' دوال مساعدة
'    ' ════════════════════════════════════════════════════════════════════════════
'    ' ────────────────────────────────────────────────────────────────────────────
'    ' جلب Customer_ID و Remaining من SalesHeader القديمة قبل أى تعديل
'    ' ────────────────────────────────────────────────────────────────────────────
'    'Private Sub LoadOldHeaderForUpdateSync(
'    'invoiceID As Integer,
'    'cn As SqlConnection,
'    'tr As SqlTransaction,
'    'ByRef oldCustomerID As Integer,
'    'ByRef oldRemaining As Decimal,
'    'ByRef oldTreasuryID As Integer,
'    'ByRef oldPaid As Decimal)

'    '    Using cmd As New SqlCommand(
'    '"SELECT Customer_ID, Remaining, TreasuryID, Amount_Paid 
'    ' FROM SalesHeader
'    ' WHERE Invoice_ID=@id", cn, tr)

'    '        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

'    '        Using rd = cmd.ExecuteReader()
'    '            If rd.Read() Then
'    '                ' قراءة المعرف والمتبقي (حقول أساسية)
'    '                oldCustomerID = Convert.ToInt32(rd("Customer_ID"))
'    '                oldRemaining = Convert.ToDecimal(rd("Remaining"))

'    '                ' 🛑 حماية الفواتير القديمة: فحص حقل الخزنة إذا كان فارغاً نضع 0
'    '                If rd("TreasuryID") IsNot DBNull.Value AndAlso Not IsDBNull(rd("TreasuryID")) Then
'    '                    oldTreasuryID = Convert.ToInt32(rd("TreasuryID"))
'    '                Else
'    '                    oldTreasuryID = 0
'    '                End If

'    '                ' 🛑 فحص حقل المدفوع القديم إذا كان فارغاً نضع 0
'    '                If rd("Amount_Paid") IsNot DBNull.Value AndAlso Not IsDBNull(rd("Amount_Paid")) Then
'    '                    oldPaid = Convert.ToDecimal(rd("Amount_Paid"))
'    '                Else
'    '                    oldPaid = 0D
'    '                End If
'    '            Else
'    '                Throw New Exception("تعذر العثور على الفاتورة رقم " & invoiceID.ToString())
'    '            End If
'    '        End Using
'    '    End Using
'    'End Sub


'    Private Sub LoadOldHeaderForUpdateSync(
'    invoiceID As Integer,
'    cn As SqlConnection,
'    tr As SqlTransaction,
'    ByRef oldCustomerID As Integer,
'    ByRef oldRemaining As Decimal,
'    ByRef oldTreasuryID As Integer,
'    ByRef oldPaid As Decimal)

'        Using cmd As New SqlCommand(
'        "SELECT Customer_ID, Remaining, TreasuryID, Amount_Paid FROM SalesHeader WHERE Invoice_ID=@id", cn, tr)

'            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

'            Using rd = cmd.ExecuteReader()
'                If rd.Read() Then
'                    oldCustomerID = Convert.ToInt32(rd("Customer_ID"))
'                    oldRemaining = Convert.ToDecimal(rd("Remaining"))

'                    If rd("TreasuryID") IsNot DBNull.Value Then
'                        oldTreasuryID = Convert.ToInt32(rd("TreasuryID"))
'                    Else
'                        oldTreasuryID = 0
'                    End If

'                    If rd("Amount_Paid") IsNot DBNull.Value Then
'                        oldPaid = Convert.ToDecimal(rd("Amount_Paid"))
'                    Else
'                        oldPaid = 0D
'                    End If
'                Else
'                    Throw New Exception("تعذر العثور على الفاتورة رقم " & invoiceID.ToString())
'                End If
'            End Using
'        End Using

'        ' ── [إصلاح الرصيد السابق في التعديل] ──
'        ' جلب الرصيد الحالي للعميل من قاعدة البيانات وطرح المتبقي القديم منه ليعطي الرصيد الدقيق قبل الفاتورة
'        Dim currentCustBalance As Decimal = GetCustomerBalanceSync(oldCustomerID, cn, tr)
'        _prevBalanceForPrint = currentCustBalance - oldRemaining
'    End Sub

'    ' ────────────────────────────────────────────────────────────────────────────
'    ' تحويل CustomerCode (المستخدم فى الفورم) إلى CustomerID (المستخدم داخليًا)
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Function ResolveCustomerIDFromCodeSync(
'    customerCode As String,
'    cn As SqlConnection,
'    tr As SqlTransaction) As Integer

'        Using cmd As New SqlCommand(
'        "SELECT CustomerID FROM Customers WHERE CustomerCode=@code", cn, tr)

'            cmd.Parameters.AddWithValue("@code", customerCode)

'            Dim result = cmd.ExecuteScalar()

'            If result Is Nothing OrElse IsDBNull(result) Then
'                Throw New Exception("رمز العميل غير موجود: " & customerCode)
'            End If

'            Return Convert.ToInt32(result)
'        End Using
'    End Function


'    ' ────────────────────────────────────────────────────────────────────────────
'    ' جلب رصيد العميل الحالى (CurrentBalance) بواسطة CustomerID
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Function GetCustomerBalanceSync(
'    customerID As Integer,
'    cn As SqlConnection,
'    tr As SqlTransaction) As Decimal

'        Using cmd As New SqlCommand(
'        "SELECT ISNULL(CurrentBalance,0) FROM Customers WHERE CustomerID=@id", cn, tr)

'            cmd.Parameters.Add("@id", SqlDbType.Int).Value = customerID
'            Return Convert.ToDecimal(cmd.ExecuteScalar())
'        End Using
'    End Function


'    ' ────────────────────────────────────────────────────────────────────────────
'    ' تعديل رصيد عميل واحد بمقدار معيّن (موجب أو سالب) باستخدام CustomerID
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Sub AdjustCustomerBalanceByIDSync(
'    customerID As Integer,
'    amount As Decimal,
'    cn As SqlConnection,
'    tr As SqlTransaction)

'        Using cmd As New SqlCommand(
'        "UPDATE Customers
'         SET CurrentBalance = ISNULL(CurrentBalance,0) + @amount
'         WHERE CustomerID=@id", cn, tr)

'            cmd.Parameters.AddWithValue("@amount", amount)
'            cmd.Parameters.Add("@id", SqlDbType.Int).Value = customerID

'            cmd.ExecuteNonQuery()
'        End Using
'    End Sub


'    ' ────────────────────────────────────────────────────────────────────────────
'    ' فحص حد الائتمان لمسار التعديل (Overload جديد باستخدام CustomerID مباشرة).
'    ' ملاحظة: بافتراض عمود CreditLimit فى Customers. الـ Overload الأصلى بالأعلى
'    ' (باستخدام CustomerCode) يبقى كما هو ويُستخدم فقط فى مسار إنشاء فاتورة جديدة.
'    ' ────────────────────────────────────────────────────────────────────────────
'    ' ────────────────────────────────────────────────────────────────────────────
'    ' فحص حد الائتمان بواسطة CustomerID (Overload خاص بمسار التعديل)
'    ' projectedBalance = الرصيد المتوقع بعد حساب أثر الفاتورة الجديدة
'    ' ملاحظة: الـ Overload الأصلى بالـ CustomerCode يبقى لمسار إنشاء الفاتورة الجديدة
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Function CheckCreditLimitSync(
'    customerID As Integer,
'    projectedBalance As Decimal,
'    cn As SqlConnection,
'    tr As SqlTransaction) As Boolean

'        Dim creditLimit As Decimal = 0D
'        Dim customerName As String = ""

'        Using cmd As New SqlCommand(
'        "SELECT ISNULL(CreditLimit,0), ISNULL(CustomerName,'') " &
'        "FROM Customers WHERE CustomerID=@id", cn, tr)
'            cmd.Parameters.Add("@id", SqlDbType.Int).Value = customerID
'            Using rd = cmd.ExecuteReader()
'                If rd.Read() Then
'                    creditLimit = Convert.ToDecimal(rd(0))
'                    customerName = rd(1).ToString()
'                End If
'            End Using
'        End Using

'        If creditLimit > 0D AndAlso -projectedBalance > creditLimit Then
'            Me.Invoke(Sub()
'                          ShowWarning(
'                      "⚠️ لا يمكن إتمام العملية." & vbCrLf & vbCrLf &
'                      "ستتجاوز مديونية العميل حد الائتمان المسموح به." & vbCrLf & vbCrLf &
'                      "العميل: " & customerName & vbCrLf &
'                      "حد الائتمان: " & creditLimit.ToString("N2") & vbCrLf &
'                      "المديونية المتوقعة بعد العملية: " & (-projectedBalance).ToString("N2"))
'                      End Sub)
'            Return False
'        End If

'        Return True
'    End Function


'    ' ────────────────────────────────────────────────────────────────────────────
'    ' جلب كل تفاصيل الفاتورة القديمة فى Dictionary
'    ' المفتاح = ProductID + "_" + UnitID
'    ' ────────────────────────────────────────────────────────────────────────────
'    ' ────────────────────────────────────────────────────────────────────────────
'    ' جلب كل تفاصيل الفاتورة القديمة فى Dictionary للمقارنة
'    ' [تحسين]: يجلب Factor من ProductUnits لاستخدامه فى حساب التكلفة التاريخية
'    '          عند تغيير وحدة منتج موجود بالفعل فى الفاتورة
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Function LoadOldSalesDetailsDictionarySync(
'    invoiceID As Integer,
'    cn As SqlConnection,
'    tr As SqlTransaction) As Dictionary(Of String, OldDetailInfo)

'        Dim result As New Dictionary(Of String, OldDetailInfo)

'        Using cmd As New SqlCommand(
'        "SELECT d.Product_ID,
'                d.ProductUnit_ID,
'                d.Quantity_Sold,
'                d.Sale_Price_Per_Unit,
'                ISNULL(d.Purchase_Price_At_Sale,0) AS Purchase_Price_At_Sale,
'                ISNULL(d.Profit,0)                 AS Profit,
'                ISNULL(u.Unit_Quantity,1)           AS Factor
'         FROM SalesDetails d
'         LEFT JOIN ProductUnits u
'             ON d.Product_ID     = u.Product_ID
'             AND d.ProductUnit_ID = u.ProductUnit_ID
'         WHERE d.Invoice_ID=@id", cn, tr)

'            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

'            Using rd = cmd.ExecuteReader()
'                While rd.Read()
'                    Dim info As New OldDetailInfo With {
'                        .ProductID = Convert.ToInt32(rd("Product_ID")),
'                        .UnitID = Convert.ToInt32(rd("ProductUnit_ID")),
'                        .Quantity = Convert.ToDecimal(rd("Quantity_Sold")),
'                        .SalePrice = Convert.ToDecimal(rd("Sale_Price_Per_Unit")),
'                        .PurchasePriceAtSale = Convert.ToDecimal(rd("Purchase_Price_At_Sale")),
'                        .Profit = Convert.ToDecimal(rd("Profit")),
'                        .Factor = Convert.ToDecimal(rd("Factor"))
'                    }
'                    Dim key = MakeProductUnitKey(info.ProductID, info.UnitID)
'                    result(key) = info
'                End While
'            End Using
'        End Using

'        Return result
'    End Function


'    ' ────────────────────────────────────────────────────────────────────────────
'    ' تحميل أسعار الشراء الحالية دفعة واحدة (بدون SELECT داخل Loop)
'    ' يفرّق بين المنتجات العادية (ProductUnits) ومنتجات الميزان (TheScale)
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Function LoadPurchasePricesBatchSync(
'    items As List(Of (ProductID As Integer, UnitID As Integer, IsScale As Boolean)),
'    cn As SqlConnection,
'    tr As SqlTransaction) As Dictionary(Of String, Decimal)

'        Dim result As New Dictionary(Of String, Decimal)

'        If items Is Nothing OrElse items.Count = 0 Then
'            Return result
'        End If

'        Dim regularItems = items.Where(Function(i) Not i.IsScale).ToList()
'        Dim scaleItems = items.Where(Function(i) i.IsScale).ToList()

'        ' ── المنتجات العادية: ProductUnits (منتج + وحدة) ──
'        If regularItems.Count > 0 Then

'            Dim conditions As New List(Of String)
'            Using cmd As New SqlCommand()
'                cmd.Connection = cn
'                cmd.Transaction = tr

'                For i As Integer = 0 To regularItems.Count - 1
'                    Dim pParam = "@p" & i.ToString()
'                    Dim uParam = "@u" & i.ToString()

'                    conditions.Add("(Product_ID=" & pParam & " AND ProductUnit_ID=" & uParam & ")")

'                    cmd.Parameters.Add(pParam, SqlDbType.Int).Value = regularItems(i).ProductID
'                    cmd.Parameters.Add(uParam, SqlDbType.Int).Value = regularItems(i).UnitID
'                Next

'                cmd.CommandText =
'                "SELECT Product_ID, ProductUnit_ID, ISNULL(Purchase_Price,0) AS Purchase_Price
'                 FROM ProductUnits
'                 WHERE " & String.Join(" OR ", conditions)

'                Using rd = cmd.ExecuteReader()
'                    While rd.Read()
'                        Dim pid = Convert.ToInt32(rd("Product_ID"))
'                        Dim uid = Convert.ToInt32(rd("ProductUnit_ID"))
'                        Dim price = Convert.ToDecimal(rd("Purchase_Price"))
'                        result(MakeProductUnitKey(pid, uid)) = price
'                    End While
'                End Using
'            End Using
'        End If

'        ' ── منتجات الميزان: TheScale (بالكود فقط) ──
'        If scaleItems.Count > 0 Then

'            Using cmd As New SqlCommand()
'                cmd.Connection = cn
'                cmd.Transaction = tr

'                Dim paramNames As New List(Of String)
'                For i As Integer = 0 To scaleItems.Count - 1
'                    Dim cParam = "@c" & i.ToString()
'                    paramNames.Add(cParam)
'                    cmd.Parameters.Add(cParam, SqlDbType.Int).Value = scaleItems(i).ProductID
'                Next

'                cmd.CommandText =
'                "SELECT Code, ISNULL(Purchase_Price,0) AS Purchase_Price
'                 FROM TheScale
'                 WHERE Code IN (" & String.Join(",", paramNames) & ")"

'                Using rd = cmd.ExecuteReader()
'                    While rd.Read()
'                        Dim code = Convert.ToInt32(rd("Code"))
'                        Dim price = Convert.ToDecimal(rd("Purchase_Price"))

'                        ' منتجات الميزان عادة وحدتها ثابتة، لذلك نبحث عن UnitID المطابق فى القائمة
'                        Dim matching = scaleItems.Where(Function(x) x.ProductID = code).ToList()
'                        For Each m In matching
'                            result(MakeProductUnitKey(m.ProductID, m.UnitID)) = price
'                        Next
'                    End While
'                End Using
'            End Using
'        End If

'        Return result
'    End Function


'    ' ────────────────────────────────────────────────────────────────────────────
'    ' التحقق من كفاية المخزون قبل خصم الكميات الجديدة (بعد إرجاع القديمة)
'    ' يمنع حفظ فاتورة تؤدى لرصيد سالب فى المخزون
'    ' ────────────────────────────────────────────────────────────────────────────
'    Private Sub ValidateStockAvailabilitySync(
'    gridData As List(Of InvoiceLineData),
'    cn As SqlConnection,
'    tr As SqlTransaction)

'        Dim productIDs = gridData.Select(Function(r) r.ProductID).Distinct().ToList()
'        If productIDs.Count = 0 Then Return

'        Dim stockDict As New Dictionary(Of Integer, Decimal)

'        Using cmd As New SqlCommand()
'            cmd.Connection = cn
'            cmd.Transaction = tr

'            Dim paramNames As New List(Of String)
'            For i As Integer = 0 To productIDs.Count - 1
'                Dim pParam = "@p" & i.ToString()
'                paramNames.Add(pParam)
'                cmd.Parameters.Add(pParam, SqlDbType.Int).Value = productIDs(i)
'            Next

'            cmd.CommandText =
'            "SELECT Product_ID, Quantity_OnHand
'             FROM Stock
'             WHERE Product_ID IN (" & String.Join(",", paramNames) & ")"

'            Using rd = cmd.ExecuteReader()
'                While rd.Read()
'                    stockDict(Convert.ToInt32(rd("Product_ID"))) = Convert.ToDecimal(rd("Quantity_OnHand"))
'                End While
'            End Using
'        End Using

'        ' تجميع الكمية المطلوبة (بالوحدة الأساسية) لكل منتج فى الفاتورة الجديدة.
'        ' منتجات الميزان (Factor يُقرأ صفر افتراضيًا فى CollectGridData) لا تُخصم من
'        ' جدول Stock أصلاً (نفس منطق InsertSalesDetailsAndUpdateStock)، لذلك نستبعدها هنا.
'        Dim requiredByProduct As New Dictionary(Of Integer, Decimal)

'        For Each row In gridData
'            If row.IsScaleProduct OrElse row.ProductID <= 0 Then Continue For

'            Dim effectiveFactor As Decimal = If(row.Factor > 0D, row.Factor, 1D)
'            Dim requiredQty As Decimal = row.Quantity * effectiveFactor

'            If requiredByProduct.ContainsKey(row.ProductID) Then
'                requiredByProduct(row.ProductID) += requiredQty
'            Else
'                requiredByProduct(row.ProductID) = requiredQty
'            End If
'        Next

'        For Each kvp In requiredByProduct
'            Dim available As Decimal = If(stockDict.ContainsKey(kvp.Key), stockDict(kvp.Key), 0D)

'            If available - kvp.Value < 0D Then
'                Throw New Exception(
'                "الكمية غير متوفرة بالمخزون للمنتج رقم " & kvp.Key.ToString() &
'                " (المتاح: " & available.ToString("0.##") &
'                ", المطلوب: " & kvp.Value.ToString("0.##") & ")")
'            End If
'        Next
'    End Sub


'    ' ════════════════════════════════════════════════════════════════════════════
'    ' InsertSalesDetailsAndUpdateStock — Overload خاص بمسار التعديل (6 معاملات)
'    '
'    ' منطق Purchase_Price_At_Sale (الحفاظ على التكلفة التاريخية):
'    '   1) نفس المنتج + نفس الوحدة + PurchasePriceAtSale > 0
'    '      ← نحافظ على التكلفة التاريخية تماماً (لا نلمس سعر الشراء)
'    '   2) نفس المنتج + وحدة مختلفة + بيانات تاريخية كافية
'    '      ← نحسب التكلفة بالتناسب: (PurchasePriceAtSale_قديم / Factor_قديم) × Factor_جديد
'    '      مثال: كرتون Factor=12 بسعر 120 → علبة Factor=1 → 120/12×1 = 10 ج
'    '   3) منتج جديد بالكامل أو لا توجد بيانات تاريخية
'    '      ← نأخذ سعر الشراء الحالى من purchasePricesDict
'    '   4) فواتير قديمة (PurchasePriceAtSale = 0)
'    '      ← نأخذ سعر الشراء الحالى لملء الفراغ
'    '
'    ' الربح: (SalePrice_جديد - PurchasePriceAtSale_المحدد) × Quantity_جديدة
'    ' منتجات الميزان: الكمية بالكيلو = Quantity / 1000
'    ' ════════════════════════════════════════════════════════════════════════════
'    Private Sub InsertSalesDetailsAndUpdateStock(
'    invoiceID As Integer,
'    gridData As List(Of InvoiceLineData),
'    oldDetailsDict As Dictionary(Of String, OldDetailInfo),
'    purchasePricesDict As Dictionary(Of String, Decimal),
'    cn As SqlConnection,
'    tr As SqlTransaction)

'        For Each row In gridData

'            Dim key = MakeProductUnitKey(row.ProductID, row.UnitID)
'            Dim purchasePriceAtSale As Decimal = 0D
'            Dim lineProfit As Decimal = 0D

'            ' ══════════════════════════════════════════════════
'            ' تحديد تكلفة الشراء وقت البيع (Purchase_Price_At_Sale)
'            ' ══════════════════════════════════════════════════

'            If oldDetailsDict.ContainsKey(key) AndAlso
'               oldDetailsDict(key).PurchasePriceAtSale > 0D Then

'                ' ✅ الحالة 1: نفس المنتج + نفس الوحدة + تكلفة تاريخية موجبة
'                '    نحافظ على التكلفة التاريخية — لا نتأثر بتغيرات سعر الشراء
'                purchasePriceAtSale = oldDetailsDict(key).PurchasePriceAtSale

'            ElseIf Not oldDetailsDict.ContainsKey(key) Then

'                ' المنتج غير موجود بهذا المفتاح (ProductID+UnitID)
'                Dim oldEntry = FindOldEntryByProductID(oldDetailsDict, row.ProductID)

'                If oldEntry IsNot Nothing AndAlso
'                   oldEntry.PurchasePriceAtSale > 0D AndAlso
'                   oldEntry.Factor > 0D AndAlso
'                   row.Factor > 0D Then

'                    ' ✅ الحالة 2: نفس المنتج + وحدة مختلفة + بيانات تاريخية كافية
'                    '    نحسب التكلفة بالتناسب عبر Factor (يحافظ على الربح التاريخى)
'                    '    costPerBaseUnit = PurchasePriceAtSale_قديم / Factor_قديم
'                    '    newPPA = costPerBaseUnit × Factor_جديد
'                    Dim costPerBaseUnit As Decimal = oldEntry.PurchasePriceAtSale / oldEntry.Factor
'                    purchasePriceAtSale = Math.Round(costPerBaseUnit * row.Factor, 4)

'                Else
'                    ' ✅ الحالة 3: منتج جديد بالكامل أو لا توجد بيانات تاريخية كافية
'                    '    نأخذ سعر الشراء الحالى المحمّل مسبقاً
'                    purchasePriceAtSale = If(purchasePricesDict.ContainsKey(key),
'                                             purchasePricesDict(key), 0D)
'                End If

'            Else
'                ' ✅ الحالة 4: فاتورة قديمة كانت PurchasePriceAtSale = 0
'                '    نملأ القيمة بسعر الشراء الحالى (أول تعديل يصحح البيانات القديمة)
'                purchasePriceAtSale = If(purchasePricesDict.ContainsKey(key),
'                                         purchasePricesDict(key), 0D)
'            End If

'            ' ══════════════════════════════════════════════════
'            ' حساب الربح باستخدام التكلفة المحددة أعلاه
'            ' ══════════════════════════════════════════════════
'            If row.IsScaleProduct Then
'                ' منتج الميزان: الكمية بالجرام → نحوّلها لكيلو
'                Dim weightKg As Decimal = row.Quantity / 1000D
'                lineProfit = (row.SalePrice - purchasePriceAtSale) * weightKg
'            Else
'                ' منتج عادى: الربح = (سعر البيع - تكلفة الشراء) × الكمية
'                lineProfit = (row.SalePrice - purchasePriceAtSale) * row.Quantity
'            End If

'            ' تحديث خصائص السطر ليتم جمعها فى إجمالى الربح بعد الانتهاء
'            row.PurchasePriceAtSale = purchasePriceAtSale
'            row.Profit = lineProfit

'            ' ══════════════════════════════════════════════════
'            ' إدراج السطر فى SalesDetails مع جميع الحقول
'            ' [الأمان]: جميع القيم عبر SqlParameter
'            ' ══════════════════════════════════════════════════
'            Using cmd As New SqlCommand(
'            "INSERT INTO SalesDetails" &
'            "    (Invoice_ID, Product_ID, Product_Name, ProductUnit_ID, ProductUnit_Name," &
'            "     Quantity_Sold, Sale_Price_Per_Unit, Total_Line_Amount," &
'            "     Purchase_Price_At_Sale, Profit)" &
'            " VALUES" &
'            "    (@invoiceId, @productId, @productName, @unitId, @unitName," &
'            "     @qty, @salePrice, @total," &
'            "     @purchasePriceAtSale, @profit)", cn, tr)

'                cmd.Parameters.Add("@invoiceId", SqlDbType.Int).Value = invoiceID
'                cmd.Parameters.Add("@productId", SqlDbType.Int).Value = row.ProductID
'                cmd.Parameters.Add("@productName", SqlDbType.NVarChar, 300).Value = row.ProductName
'                cmd.Parameters.Add("@unitId", SqlDbType.Int).Value = row.UnitID
'                cmd.Parameters.Add("@unitName", SqlDbType.NVarChar, 100).Value = row.UnitName
'                cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = row.Quantity
'                cmd.Parameters.Add("@salePrice", SqlDbType.Decimal).Value = row.SalePrice
'                cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = row.Total
'                cmd.Parameters.Add("@purchasePriceAtSale", SqlDbType.Decimal).Value = purchasePriceAtSale
'                cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = lineProfit
'                cmd.ExecuteNonQuery()
'            End Using

'            ' ══════════════════════════════════════════════════
'            ' خصم الكمية الجديدة من المخزون (ما عدا منتجات الميزان)
'            ' ══════════════════════════════════════════════════
'            If row.IsScaleProduct OrElse row.ProductID <= 0 Then Continue For

'            Dim effectiveFactor As Decimal = If(row.Factor > 0D, row.Factor, 1D)

'            Using cmd As New SqlCommand(
'            "UPDATE Stock " &
'            "SET Quantity_OnHand = Quantity_OnHand - @requiredQty " &
'            "WHERE Product_ID = @productId", cn, tr)
'                cmd.Parameters.Add("@requiredQty", SqlDbType.Decimal).Value = row.Quantity * effectiveFactor
'                cmd.Parameters.Add("@productId", SqlDbType.Int).Value = row.ProductID
'                cmd.ExecuteNonQuery()
'            End Using

'        Next

'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' واتساب
'    '══════════════════════════════════════════════════════════════
'    Private Async Function SendInvoiceWhatsAppAsync(invID As Integer, phone As String) As Task
'        If String.IsNullOrWhiteSpace(phone) Then
'            ShowWarning("رقم الهاتف غير صالح.")
'            Return
'        End If
'        Dim message As String = ReportsModule.GenerateInvoiceText(invID)
'        Dim success As Boolean = Await WhatsAppAPI.SendText(phone, message)
'        ShowInfo(If(success, "✅ تم إرسال الفاتورة على واتساب بنجاح",
'                              "❌ فشل إرسال الفاتورة على واتساب"))
'    End Function

'    Private Function IsInternetAvailable() As Boolean
'        Try
'            Return NetworkInterface.GetIsNetworkAvailable()
'        Catch
'            Return False
'        End Try
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' الطباعة (في Background Thread)
'    ' [تحسين]: PrintInvoice تعمل في Task.Run ← UI لا يتجمد
'    ' [إصلاح Memory Leak]: كل GDI objects داخل Using
'    '══════════════════════════════════════════════════════════════
'    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'        Await PrintInvoiceSafeAsync(_currentIDV)
'    End Sub

'    Private Async Function PrintInvoiceSafeAsync(invoiceID As Integer) As Task
'        Try
'            ' جمع بيانات الطباعة من UI Thread أولاً
'            Dim printData = CollectPrintData()

'            ' لو المعاينة مفعّلة، نشغّل على UI Thread مباشرة (PrintPreviewDialog يلزمه UI Thread)
'            ' ولا نبعت أي حاجة للطابعة إلا لو المستخدم ضغط على زر الطباعة من نافذة المعاينة نفسها.
'            If ShouldShowPrintPreview() Then
'                PrintInvoice80mmProfessionalCore(invoiceID, printData)
'            Else
'                Await Task.Run(Sub() PrintInvoice80mmProfessionalCore(invoiceID, printData))
'            End If
'        Catch ex As Exception
'            ShowError("خطأ أثناء الطباعة: " & ex.Message)
'        End Try
'    End Function

'    ' بنية لجمع بيانات الطباعة من UI Thread
'    Private Class PrintData
'        Public InvoiceItems As List(Of InvoiceLineData)
'        Public CustomerCode As String
'        Public CustomerName As String
'        Public CustomerBalance As String
'        ' [رصيد سابق]: الرصيد قبل الفاتورة (مُلتقط وقت الحفظ) — نطبع منه بدل الخانة المتغيرة.
'        Public PreviousBalance As Decimal
'        Public TotalRequired As String
'        Public Discount As String
'        Public TotalAfterDiscount As String
'        Public Paid As String
'        Public Remaining As String
'        Public UserName As String
'        Public PaymentMethod As String
'    End Class

'    Private Function CollectPrintData() As PrintData
'        Return New PrintData With {
'            .InvoiceItems = CollectGridData(),
'            .CustomerCode = txt_Customer_Code.Text,
'            .CustomerName = txt_Customer_Name.Text,
'            .CustomerBalance = txt_Customer_Balance.Text,
'            .PreviousBalance = _prevBalanceForPrint,
'            .TotalRequired = txtTotalRequired.Text,
'            .Discount = txtDiscount.Text,
'            .TotalAfterDiscount = txtTotalAfterDiscount.Text,
'            .Paid = txtPaid.Text,
'            .Remaining = txtRemaining.Text,
'            .UserName = lbl_user_name.Text,
'            .PaymentMethod = cmb_Pay.Text
'        }
'    End Function

'    Private Sub PrintInvoice80mmProfessionalCore(invoiceID As Integer, data As PrintData)
'        Dim styleVal As String = SettingsManager.GetSetting("PrintStyle")
'        If String.IsNullOrEmpty(styleVal) Then styleVal = "2"
'        If styleVal = "2" Then
'            PrintInvoice80mm_Style2(invoiceID, data)
'        Else
'            PrintInvoice80mm_Style1(invoiceID, data)
'        End If
'    End Sub

'    Private Sub PrintInvoice80mm_Style1(invoiceID As Integer, data As PrintData)
'        ' [توحيد الطباعة]: المبيعات تبني نفس نموذج التقارير (InvoiceHeader + InvoiceItem)
'        ' ثم تستدعي دالة الرسم الموحّدة RenderInvoiceReceiptStyle1 الموجودة في ReportsModule.
'        Dim header As New InvoiceHeader With {
'            .InvoiceID = invoiceID,
'            .InvoiceDate = DateTime.Now,
'            .CustomerCode = data.CustomerCode,
'            .CustomerName = data.CustomerName,
'            .UserName = data.UserName,
'            .TotalAmount = ParseDecimal(data.TotalAfterDiscount),
'            .Discount = ParseDecimal(data.Discount),
'            .NetAmount = ParseDecimal(data.TotalRequired),
'            .Paid = ParseDecimal(data.Paid),
'            .Remaining = ParseDecimal(data.Remaining),
'            .PreviousBalance = data.PreviousBalance,
'            .PaymentMethod = data.PaymentMethod
'        }

'        Dim items As New List(Of InvoiceItem)()
'        For Each line In data.InvoiceItems
'            items.Add(New InvoiceItem With {
'                .ProductName = line.ProductName,
'                .Quantity = line.Quantity,
'                .Price = line.SalePrice,
'                .Total = line.Total
'            })
'        Next

'        Dim printBarcode As Boolean = (If(SettingsManager.GetSetting("PrintBarcode"), "true").Trim().ToLower() = "true")
'        RenderInvoiceReceiptStyle1(header, items, 1, ShouldShowPrintPreview(), "معاينة الفاتورة - استيل 1", printBarcode)
'    End Sub

'    ' هل المستخدم مفعل معاينة قبل الطباعة؟
'    Private Function ShouldShowPrintPreview() As Boolean
'        Try
'            Dim v = SettingsManager.GetSetting("PrintPreview")
'            Return Not String.IsNullOrEmpty(v) AndAlso v.Trim().ToLower() = "true"
'        Catch
'            Return False
'        End Try
'    End Function

'    ''' <summary>
'    ''' فتح نافذة معاينة الفاتورة فقط - بدون أي طباعة فعلية.
'    ''' المستخدم يقدر يطبع من زر الطباعة داخل نافذة المعاينة لو حب.
'    ''' </summary>
'    Private Sub ShowPrintPreviewDialog(pd As PrintDocument, title As String)
'        Dim showPreview As Action =
'            Sub()
'                Try
'                    Dim dlg As New PrintPreviewDialog()
'                    Try
'                        dlg.Document = pd
'                        dlg.Text = title
'                        dlg.WindowState = FormWindowState.Maximized
'                        dlg.UseAntiAlias = True
'                        dlg.PrintPreviewControl.Zoom = 1.25
'                        dlg.ShowIcon = False
'                        dlg.StartPosition = FormStartPosition.CenterScreen
'                        ' عرض النافذة - لن تُرسل أي طباعة للطابعة إلا لو ضغط المستخدم زر الطابعة داخل النافذة
'                        dlg.ShowDialog()
'                    Finally
'                        dlg.Dispose()
'                    End Try
'                Catch ex As Exception
'                    MessageBox.Show("خطأ في عرض المعاينة: " & ex.Message,
'                                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                End Try
'            End Sub

'        Try
'            If Me.IsHandleCreated AndAlso Me.InvokeRequired Then
'                Me.Invoke(showPreview)
'            Else
'                showPreview.Invoke()
'            End If
'        Catch ex As Exception
'            ' Fallback - شغّل بدون Invoke
'            showPreview.Invoke()
'        End Try
'    End Sub

'    ' استيل 2: تصميم الهيدر شبيه فاتورة المصطفى (لوجو + اسم على اليمين، بيانات الفاتورة على اليسار)
'    Private Sub PrintInvoice80mm_Style2(invoiceID As Integer, data As PrintData)
'        ' [توحيد الطباعة]: المبيعات تبني نفس نموذج التقارير (InvoiceHeader + InvoiceItem)
'        ' ثم تستدعي دالة الرسم الموحّدة RenderInvoiceReceiptStyle2 الموجودة في ReportsModule.
'        ' أي تعديل في شكل الفاتورة يتم هناك مرة واحدة فينطبق على المبيعات والتقارير معاً.
'        Dim header As New InvoiceHeader With {
'            .InvoiceID = invoiceID,
'            .InvoiceDate = DateTime.Now,
'            .CustomerCode = data.CustomerCode,
'            .CustomerName = data.CustomerName,
'            .UserName = data.UserName,
'            .TotalAmount = ParseDecimal(data.TotalAfterDiscount),
'            .Discount = ParseDecimal(data.Discount),
'            .NetAmount = ParseDecimal(data.TotalRequired),
'            .Paid = ParseDecimal(data.Paid),
'            .Remaining = ParseDecimal(data.Remaining),
'            .PreviousBalance = data.PreviousBalance,
'            .PaymentMethod = data.PaymentMethod
'        }

'        Dim items As New List(Of InvoiceItem)()
'        For Each line In data.InvoiceItems
'            items.Add(New InvoiceItem With {
'                .ProductName = line.ProductName,
'                .Quantity = line.Quantity,
'                .Price = line.SalePrice,
'                .Total = line.Total
'            })
'        Next

'        Dim printBarcode As Boolean = (If(SettingsManager.GetSetting("PrintBarcode"), "true").Trim().ToLower() = "true")
'        RenderInvoiceReceiptStyle2(header, items, 1, ShouldShowPrintPreview(), "معاينة الفاتورة - استيل 2", printBarcode)
'    End Sub
'    Private Function GenerateQRCode(text As String) As Bitmap
'        Dim writer As New ZXing.BarcodeWriter() With {
'            .Format = ZXing.BarcodeFormat.CODE_128,
'            .Options = New ZXing.Common.EncodingOptions With {
'                .Height = 70, .Width = 140, .Margin = 0}}
'        Return writer.Write(text)
'    End Function

'    '══════════════════════════════════════════════════════════════
'    ' تحميل بيانات المستخدم
'    '══════════════════════════════════════════════════════════════
'    Private Sub loadlogininfo()
'        Try
'            Using cn = OpenConnection()
'                Using cmd As New SqlCommand(
'                    "SELECT User_Name FROM Users_TBL WHERE User_ID=@id", cn)
'                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Session.CurrentUserID
'                    lbl_user_name.Text = Convert.ToString(cmd.ExecuteScalar())
'                End Using
'            End Using
'        Catch ex As Exception
'            ShowError("خطأ أثناء التحقق من المستخدم: " & ex.Message)
'        End Try
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' بقية الأحداث والميزات (محافظ على جميع الوظائف الأصلية)
'    '══════════════════════════════════════════════════════════════
'    Private Sub btn_Sales_Returns_Click(sender As Object, e As EventArgs) _
'        Handles btn_Sales_Returns.Click
'        OpenSingleForm(Of Sales_Returns)()
'    End Sub

'    Private Sub btnToggleDiscount_Click(sender As Object, e As EventArgs) _
'        Handles btnToggleDiscount.Click
'        _discountEnabled = Not _discountEnabled
'        If Not _discountEnabled Then
'            lblDiscount.Visible = False
'            txtDiscount.Visible = False
'            lblTotalBefore.Visible = False
'            lblTotalAfter.Text = "إجمالي الفاتورة"
'            txtDiscount.Text = "0"
'            btnToggleDiscount.Text = "✅"
'            btnToggleDiscount.BackColor = Color.SeaGreen
'        Else
'            lblDiscount.Visible = True
'            txtDiscount.Visible = True
'            lblTotalBefore.Visible = True
'            lblTotalAfter.Text = "إجمالي بعد الخصم"
'            btnToggleDiscount.Text = "❌"
'            btnToggleDiscount.BackColor = Color.Firebrick
'        End If
'        RecalculateTotals()
'    End Sub

'    Private Sub btnToggleScanner_Click(sender As Object, e As EventArgs) _
'        Handles btnToggleScanner.Click
'        Try
'            If barcodePort IsNot Nothing AndAlso barcodePort.IsOpen Then
'                StopScanner()
'                btnToggleScanner.Text = "تشغيل الاسكنر"
'            Else
'                StartScanner()
'                btnToggleScanner.Text = If(barcodePort?.IsOpen, "إيقاف الاسكنر", "تشغيل الاسكنر")
'            End If
'        Catch ex As Exception
'            ShowError("خطأ في الاسكنر: " & ex.Message)
'        End Try
'    End Sub

'    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
'        cleartxts()
'        DataGridView1.Rows.Clear()
'        _stockCache.Clear()
'    End Sub

'    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
'        DataGridView1.Rows.Clear()
'        _stockCache.Clear()
'        UpdateInvoiceTotals()
'        ' فتح القفل بعد مسح المنتجات لبدء فاتورة جديدة
'        UnlockInvoice()
'    End Sub

'    Private Sub txt_Customer_Balance_TextChanged(sender As Object, e As EventArgs) _
'        Handles txt_Customer_Balance.TextChanged
'        SplitBalance(txt_Customer_Balance, txtDebit, txtCredit)
'    End Sub

'    Private Sub SplitBalance(txtBalance As Guna2TextBox, txtDebit As Guna2TextBox, txtCredit As Guna2TextBox)
'        Dim balance As Decimal
'        If Decimal.TryParse(txtBalance.Text.Trim(), balance) Then
'            If balance < 0 Then
'                txtDebit.Text = Math.Abs(balance).ToString()
'                txtCredit.Text = "0"
'            ElseIf balance > 0 Then
'                txtDebit.Text = "0"
'                txtCredit.Text = balance.ToString()
'            Else
'                txtDebit.Text = "0"
'                txtCredit.Text = "0"
'            End If
'        Else
'            txtDebit.Text = "0"
'            txtCredit.Text = "0"
'        End If
'    End Sub

'    Private Sub btn_auto_pay_Click(sender As Object, e As EventArgs) Handles btn_auto_pay.Click
'        If String.IsNullOrWhiteSpace(txtTotalAfterDiscount.Text) Then
'            ShowWarning("برجاء التأكد من المبلغ بعد الخصم")
'            Return
'        End If

'        txtPaid.Text = txtTotalAfterDiscount.Text
'        cmb_Pay.SelectedIndex = 0
'        _autoSave = If(SettingsManager.GetSetting("autoSaveinvoice"), "false")
'        If _autoSave Then btnSaveInvoice.PerformClick()
'    End Sub

'    Private Sub check_Stats_CheckedChanged(sender As Object, e As EventArgs) _
'        Handles check_Stats.CheckedChanged
'        _isSendToWhatsApp = check_Stats.Checked
'    End Sub

'    'Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs)

'    '    _autoSave = Guna2ToggleSwitch1.Checked
'    'End Sub

'    Private Sub btn_money_Click(sender As Object, e As EventArgs) Handles btn_money.Click
'        _moneyEnabled = Not _moneyEnabled
'        Dim vis = _moneyEnabled
'        lbl_Customer_Balance.Visible = vis
'        txt_Customer_Balance.Visible = vis
'        lbl_Credit.Visible = vis
'        txtCredit.Visible = vis
'        lbl_Debit.Visible = vis
'        txtDebit.Visible = vis
'        btn_money.Text = If(vis, "❌", "✅")
'        Pic_Logo.Visible = Not vis
'        btnToggleDiscount.BackColor = If(vis, Color.Firebrick, Color.SeaGreen)
'    End Sub

'    ' إضافة منتج حر (غير مرتبط بالمخزون)
'    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
'        If _invoiceSaved Then
'            ShowWarning("تم حفظ الفاتورة بالفعل. اضغط (مسح / حذف) لبدء فاتورة جديدة قبل إضافة منتجات.")
'            Return
'        End If
'        If Guna2TextBox1.TextLength = 0 OrElse Guna2TextBox2.TextLength = 0 OrElse
'           txt_free_profit.TextLength = 0 Then
'            ShowWarning("برجاء ملء جميع الحقول")
'            Return
'        End If
'        If Not IsNumeric(txt_free_profit.Text) OrElse Not IsNumeric(Guna2TextBox2.Text) Then
'            ShowWarning("برجاء إدخال أرقام صحيحة")
'            Return
'        End If

'        Dim dgv As DataGridView = DataGridView1
'        Dim newRow As DataGridViewRow = CType(dgv.RowTemplate.Clone(), DataGridViewRow)
'        newRow.CreateCells(dgv)

'        ' [تحسين]: دالة مساعدة محلية لضبط قيم الخلايا بأمان
'        Dim setCell = Sub(colName As String, val As Object)
'                          If dgv.Columns.Contains(colName) Then
'                              newRow.Cells(dgv.Columns(colName).Index).Value = val
'                          End If
'                      End Sub

'        setCell("ColProductID", 0)
'        setCell("ColProduct_Code", 0)
'        setCell("ColProductName", Guna2TextBox1.Text)
'        setCell("ColUnitName", "غير معرف")
'        setCell("ColPrice", Guna2TextBox2.Text)
'        setCell("ColQuantity", 1)
'        setCell("ColTotal", Guna2TextBox2.Text)
'        setCell("ColUnitID", 0)
'        setCell("ColFactor", 0)
'        setCell("ColProfit", Convert.ToDecimal(txt_free_profit.Text))

'        dgv.Rows.Add(newRow)
'        ClearProductFields()
'        Guna2TextBox1.Clear()
'        Guna2TextBox2.Clear()
'        txt_free_profit.Clear()
'        UpdateInvoiceTotals()
'    End Sub

'    Private Sub Guna2TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Guna2TextBox1.KeyDown
'        If e.KeyCode = Keys.Enter Then Guna2TextBox2.Focus()
'    End Sub
'    Private Sub Guna2TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles Guna2TextBox2.KeyDown
'        If e.KeyCode = Keys.Enter Then txt_free_profit.Focus()
'    End Sub
'    Private Sub txt_free_profit_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_free_profit.KeyDown
'        If e.KeyCode = Keys.Enter Then Button2.PerformClick()
'    End Sub

'    '══════════════════════════════════════════════════════════════
'    ' دوال مساعدة مشتركة
'    '══════════════════════════════════════════════════════════════
'    Private Function ParseDecimal(txt As String) As Decimal
'        Dim result As Decimal
'        Decimal.TryParse(txt, result)
'        Return result
'    End Function

'    Private Function ParseInt(val As Object) As Integer
'        Dim result As Integer
'        If val IsNot Nothing Then Integer.TryParse(val.ToString(), result)
'        Return result
'    End Function

'    Private Sub ShowWarning(msg As String)
'        MessageBox.Show(msg, "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    End Sub

'    Private Sub ShowError(msg As String)

'        MessageBox.Show(msg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
'    End Sub

'    Private Async Sub btn_Invoice_Edit_Click(sender As Object, e As EventArgs) Handles btn_Invoice_Edit.Click
'        Await UpdateInvoiceAsync(inv_id_edit)
'        btn_Invoice_Edit.Visible = False
'    End Sub
'    Private Async Function LoadTreasuriesAsync() As Task

'        Try

'            Dim dt As New DataTable()

'            Using cn As SqlConnection = Await NewConnAsync()

'                Const sql As String =
'                    "
'                    SELECT
'                    TreasuryID,
'                    TreasuryNameAr
'                    FROM Treasury
'                    WHERE IsActive = 1
'                    AND IsDeleted = 0
'                    "

'                Using da As New SqlDataAdapter(sql, cn)

'                    Await Task.Run(Sub() da.Fill(dt))

'                End Using

'            End Using
'            cmbTreasury.DataSource = dt
'            cmbTreasury.DisplayMember = "TreasuryNameAr"
'            cmbTreasury.ValueMember = "TreasuryID"
'            defaultTreasuryid = If(SettingsManager.GetSetting("defaultTreasuryid"), -1)
'            cmbTreasury.SelectedIndex = defaultTreasuryid

'        Catch ex As Exception

'            ShowError(ex.Message)

'        End Try

'    End Function

'    Private Sub cmbTreasury_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTreasury.SelectedIndexChanged
'        SelectedTreasuryid = cmbTreasury.SelectedIndex
'    End Sub

'    Private Sub ShowInfo(msg As String)
'        MessageBox.Show(msg, "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information)
'    End Sub
'    ' [تنظيف]: تم حذف OldInvoiceLine المكررة — يُستخدم بدلاً منها OldDetailInfo
'    '           الموجودة أعلاه والتى تدعم حقل Factor لحساب التكلفة التاريخية

'End Class