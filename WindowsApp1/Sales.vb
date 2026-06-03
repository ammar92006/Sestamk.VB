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
'  ملاحظة: الاتصال بقاعدة البيانات يعتمد على دالة GetConnectionString()
'  يجب أن تُعرّف هذه الدالة في Module أو Base Class ترجع
'  connectionString صحيح مثل:
'  "Data Source=...;Initial Catalog=...;Integrated Security=True"
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
    Private _autoSave As Boolean = False
    Private _currentIDV As Integer

    ' [قفل الفاتورة بعد الحفظ]: يمنع إضافة منتجات/حفظ مرة تانية على نفس الفاتورة
    ' لحد ما يتم الضغط على مسح/حذف لبدء فاتورة جديدة
    Private _invoiceSaved As Boolean = False
    Public ScalID As Integer = 0

    'Public inv_id_edit As Integer
    Public Property inv_id_edit As Integer

    ' ── منع إعادة الدخول لـ RecalculateTotals ──
    ' [تحسين]: فلاق يمنع Cascading Calls التي كانت تسبب تجميد الـ UI
    Private _isRecalculating As Boolean = False

    ' ── Debounce للبحث (300ms بعد آخر حرف) ──
    ' [تحسين]: CancellationTokenSource أسلم مع Async/Await
    Private _searchCts As CancellationTokenSource

    ' ── Cache لسعر الشراء ──
    Private _purchasePriceCache As New Dictionary(Of String, Decimal)

    ' ── Cache مؤقت للمخزون (يُمسح عند إضافة أو تعديل منتج) ──
    ' [تحسين]: يقلل استعلامات قاعدة البيانات للمنتج نفسه خلال جلسة الفاتورة
    Private _stockCache As New Dictionary(Of Integer, Decimal)

    '══════════════════════════════════════════════════════════════
    ' دوال الاتصال بقاعدة البيانات
    ' [تحسين جوهري]: كل دالة تفتح وتغلق connectionها الخاص
    '  بدلاً من Conn عالمي ← يمنع Connection Leaks تماماً
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
    ' [تحسين]: العمليات الثقيلة تعمل بالتوازي في الخلفية
    '══════════════════════════════════════════════════════════════
    Private Async Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' التجاوب مع الشاشة: تكبير الفورم لملء الشاشة لو أكبر من المساحة المتاحة
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

        ' [تحسين]: تشغيل العمليات الثقيلة بالتوازي بدلاً من التسلسل
        Await Task.WhenAll(
            Task.Run(Sub() Me.Invoke(Sub() loadlogininfo())),
            Task.Run(Sub() Me.Invoke(Sub() getnewInvoiceID()))
        )

        SetupDataGridView(DataGridView1)
        ' [FIX] تفعيل DoubleBuffered لتقليل الـ Flickering عند تعبئة الأصناف
        EnableDoubleBuffer(DataGridView1)
        cleartxts()
        txt_Customer_Code.Text = "1"
        Await SearchCustomerByCodeAsync("1")
        txt_Customer_Name.Focus()

        ' [إصلاح حيوي]: RegisterProductSearchHandlers تمرر متغيرات الفورم الفعلي
        RegisterProductSearchHandlers()

        txtDiscount.Text = "0"
        txt_totelProduct.Text = "0"
        DataGridView1.Columns("ColQtyPlus").Width = 30
        DataGridView1.Columns("ColQtyMinus").Width = 30
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
        ' ──────────────────────────────────────────────────────────
        ' [إصلاح حيوي جداً]: كانت SalesManager تنشئ Dim sales As New Sales
        '  وتحدّث متغيرات على نسخة جديدة مجهولة بدلاً من الفورم الحالي!
        '  الآن نمرر ByRef مباشرة من هذا الفورم عبر Lambdas.
        ' ──────────────────────────────────────────────────────────

        ' حدث اختيار المنتج من قائمة الاسم
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
                    CurrentSalePrice,          ' ← ByRef على الفورم الفعلي
                    CurrentConversionFactor,   ' ← ByRef على الفورم الفعلي
                    _currentUnitID)            ' ← ByRef على الفورم الفعلي
            End Sub

        ' حدث البحث بالاسم
        AddHandler txtProductNameSearch.TextChanged,
            Sub(s, ev)
                _manager.txtProductNameSearch_TextChanged(s, ev, lstNameSuggestions)
            End Sub

        ' حدث البحث بالكود
        AddHandler txtProductCodeSearch.TextChanged,
            Sub(s, ev)
                _manager.txtProductCodeSearch_TextChanged(s, ev, lstNameSuggestions)
            End Sub

        ' حدث تغيير الوحدة
        AddHandler cmbUnit.SelectedIndexChanged,
            Sub(s, ev)
                _manager.cmbUnit_SelectedIndexChanged(
                    s, ev,
                    txtQuantity,
                    txt_totelProduct,
                    txtSalePrice,
                    CurrentConversionFactor,   ' ← ByRef على الفورم الفعلي
                    CurrentSalePrice,          ' ← ByRef على الفورم الفعلي
                    _currentUnitID)            ' ← ByRef على الفورم الفعلي
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

        ' مسح الـ Caches عند تفريغ الفاتورة لضمان بيانات محدّثة
        _purchasePriceCache.Clear()
        _stockCache.Clear()
        txt_Customer_Code.Text = 1
        btn_search_Customer_ID.PerformClick()

        ' فتح القفل بعد المسح لبدء فاتورة جديدة
        UnlockInvoice()
    End Sub

    Private Sub btn_clean_Click(sender As Object, e As EventArgs) Handles btn_clean.Click
        cleartxts()
    End Sub

    ' قفل الفاتورة بعد الحفظ: تعطيل أزرار الإضافة والحفظ
    Private Sub LockInvoiceAfterSave()
        _invoiceSaved = True
        btn_add_product.Enabled = False
        Button2.Enabled = False
        btnSaveInvoice.Enabled = False
    End Sub

    ' فتح القفل لبدء فاتورة جديدة
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
                .Width = 5, .UseColumnTextForButtonValue = True}
            .Columns.Add(colMinus)

            .Columns.Add("ColQuantity", "الكمية / الوزن")

            Dim colPlus As New DataGridViewButtonColumn() With {
                .HeaderText = "", .Text = "➕", .Name = "ColQtyPlus",
                .Width = 5, .UseColumnTextForButtonValue = True}
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
                Using cmd As New SqlCommand(
                    "SELECT ISNULL(MAX(Invoice_Code),0)+1 AS NextInv FROM SalesHeader;", cn)
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
    ' بحث العميل بالكود (Async) ← واجهة لا تتجمد أثناء الاستعلام
    '══════════════════════════════════════════════════════════════
    Private Async Sub btn_search_Customer_ID_Click(sender As Object, e As EventArgs) _
        Handles btn_search_Customer_ID.Click
        Await SearchCustomerByCodeAsync(txt_Customer_Code.Text.Trim())
    End Sub

    Private Async Function SearchCustomerByCodeAsync(code As String) As Task
        If String.IsNullOrWhiteSpace(code) Then
            ShowWarning("من فضلك ادخل كود العميل")
            Return
        End If
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand(
                    "SELECT CustomerName, CurrentBalance FROM Customers WHERE CustomerCode=@code", cn)
                    ' [الأمان]: Parameterized Query يمنع SQL Injection
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
    ' [تحسين]: 300ms بعد آخر حرف ← يقلل عدد الاستعلامات بشكل كبير
    '══════════════════════════════════════════════════════════════
    Private Async Sub txt_Customer_Name_TextChanged(sender As Object, e As EventArgs) _
        Handles txt_Customer_Name.TextChanged
        Dim keyword As String = txt_Customer_Name.Text.Trim()
        If keyword.Length < 1 Then
            lstSuggestions.Visible = False
            lstSuggestions.Items.Clear()
            Return
        End If

        ' إلغاء أي بحث سابق لم يكتمل بعد
        _searchCts?.Cancel()
        _searchCts = New CancellationTokenSource()
        Dim token = _searchCts.Token

        Try
            Await Task.Delay(300, token)    ' 300ms debounce
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
            ' طبيعي عند إلغاء البحث القديم لا داعي لتسجيل خطأ
        End Try
    End Sub

    Private Async Function GetCustomerSuggestionsAsync(keyword As String,
                                                        token As CancellationToken) As Task(Of List(Of String))
        Dim result As New List(Of String)()
        Try
            Using cn = Await OpenConnectionAsync()
                ' [الأمان]: TOP 15 يمنع استرجاع آلاف السجلات + Parameterized
                Using cmd As New SqlCommand(
                    "SELECT TOP 15 CustomerName FROM Customers WHERE CustomerName LIKE @kw", cn)
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 200).Value = "%" & keyword & "%"
                    Using rd = Await cmd.ExecuteReaderAsync(token)
                        While Await rd.ReadAsync(token)
                            result.Add(rd("CustomerName").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception When Not (TypeOf ex Is TaskCanceledException)
            ' تجاهل أخطاء البحث الثانوية فقط للـ Debounce
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
                Using cmd As New SqlCommand(
                    "SELECT CustomerID,CustomerCode,CustomerName,CurrentBalance " &
                    "FROM dbo.Customers WHERE CustomerName=@name", cn)
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
    ' [تحسين]: الواجهة لا تتجمد أثناء جلب بيانات الميزان
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

            ' [تحسين]: جلب الربح في الخلفية بدون تجميد UI
            Dim profit As Decimal = Await Task.Run(Function() GetScaleProductProfitFromDB(productID, weightKg))

            '' التحقق من تكرار الباركود
            'For Each gridRow As DataGridViewRow In DataGridView1.Rows
            '    If Not gridRow.IsNewRow Then
            '        If gridRow.Cells("ColProductName").Value?.ToString() = productName AndAlso
            '           gridRow.Cells("LastNumScaleBarcode").Value?.ToString() = lastNum Then
            '            ShowWarning("باركود الميزان متكرر")
            '            Return
            '        End If
            '    End If
            'Next

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

    ' حساب الربح من الميزان — تُنفّذ في Task.Run (خارج UI Thread)
    Private Function GetScaleProductProfitFromDB(productID As Integer, weightKg As Decimal) As Decimal
        Try
            Using cn = OpenConnection()
                Using cmd As New SqlCommand(
                    "SELECT Price, Purchase_Price FROM TheScale WHERE Code=@Code", cn)
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
            ' إرجاع صفر عند أي خطأ بدلاً من كراش
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
    ' [تحسين]: Cache يمنع استعلام DB متكرر للمنتج نفسه في نفس الجلسة
    '══════════════════════════════════════════════════════════════
    Private Async Function GetStockQtyAsync(productId As Integer) As Task(Of Decimal)
        If _stockCache.ContainsKey(productId) Then Return _stockCache(productId)

        Dim stockQty As Decimal = 0D
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand(
                    "SELECT Quantity_OnHand FROM Stock WHERE Product_ID=@PID", cn)
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

    ' نسخة متزامنة للاستخدام داخل Task.Run فقط
    Private Function GetStockQtySync(productId As Integer) As Decimal
        If _stockCache.ContainsKey(productId) Then Return _stockCache(productId)
        Dim stockQty As Decimal = 0D
        Try
            Using cn = OpenConnection()
                Using cmd As New SqlCommand(
                    "SELECT Quantity_OnHand FROM Stock WHERE Product_ID=@PID", cn)
                    cmd.Parameters.Add("@PID", SqlDbType.Int).Value = productId
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        stockQty = Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch
            ' إرجاع صفر عند أي خطأ
        End Try
        _stockCache(productId) = stockQty
        Return stockQty
    End Function

    '══════════════════════════════════════════════════════════════
    ' Cache سعر الشراء
    '══════════════════════════════════════════════════════════════
    Private Function GetPurchasePriceFromCache(productId As Integer, unitId As Integer) As Decimal
        Dim key As String = $"{productId}_{unitId}"
        If _purchasePriceCache.ContainsKey(key) Then Return _purchasePriceCache(key)

        Dim result As Decimal = 0D
        Try
            Using cn = OpenConnection()
                Using cmd As New SqlCommand(
                    "SELECT Purchase_Price FROM ProductUnits WHERE Product_ID=@P AND ProductUnit_ID=@U", cn)
                    cmd.Parameters.Add("@P", SqlDbType.Int).Value = productId
                    cmd.Parameters.Add("@U", SqlDbType.Int).Value = unitId
                    Dim val = cmd.ExecuteScalar()
                    If val IsNot Nothing AndAlso Not IsDBNull(val) Then result = CDec(val)
                End Using
            End Using
        Catch
            ' إرجاع صفر عند أي خطأ
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
                Using cmd As New SqlCommand(
                    "SELECT Product_Name, Product_State FROM Products WHERE Product_ID=@id", cn)
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
    ' [تحسين]: الزر لا يتجمد أثناء فحص المخزون لأن العملية Async
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

        ' فحص حالة المنتج في الخلفية
        If Not Await CheckProductStatusAsync(SelectedProductId) Then Return

        ' إضافة أو تحديث الصف
        Await UpdateExistingRowOrAddAsync()

        ClearProductFields()
        UpdateInvoiceTotals()
        ' مسح cache المخزون لأن الكمية تغيرت
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

        ' [تحسين]: جلب المخزون Async في الخلفية
        Dim stockQty As Decimal = Await GetStockQtyAsync(currentProductId)
        Dim reservedQty As Decimal = GetReservedQty(currentProductId)
        Dim purchasePrice As Decimal = GetPurchasePriceFromCache(currentProductId, unitId)
        Dim profitPerUnit As Decimal = price - purchasePrice

        ' البحث عن صف موجود بنفس المنتج والوحدة
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
            ' تحديث صف موجود
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
            ' إضافة صف جديد
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
    ' [تحسين]: SuspendLayout + ResumeLayout يمنع الوميض
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

        ' ── حذف الصف ──
        If e.ColumnIndex = dgv.Columns("ColDelete").Index Then
            Dim pName As String = Convert.ToString(dgv.Rows(e.RowIndex).Cells("ColProductName").Value)
            If MessageBox.Show($"هل أنت متأكد من حذف الصنف ({pName}) من الفاتورة؟",
                               "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim pid As Integer = 0
                Integer.TryParse(dgv.Rows(e.RowIndex).Cells("ColProductID").Value?.ToString(), pid)
                dgv.Rows.RemoveAt(e.RowIndex)
                If pid > 0 Then _stockCache.Remove(pid)   ' تحديث cache
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
            ' [تحسين]: Async لجلب المخزون بدون تجميد UI
            stockQty = Await GetStockQtyAsync(productId)
        End If

        Dim purchasePrice As Decimal = If(isUnknown, 0D,
            GetPurchasePriceFromCache(productId, unitId))
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
        If Not isUnknown Then _stockCache.Remove(productId)  ' إعادة تحميل cache
        UpdateInvoiceTotals()
    End Sub

    '══════════════════════════════════════════════════════════════
    ' الحسابات المالية الموحدة
    ' [تحسين الأهم]: فلاق _isRecalculating يمنع Cascading Calls
    '  التي كانت تسبب تجميد الواجهة عند كل ضغطة مفتاح
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
                Using cmd As New SqlCommand(
                    "SELECT CustomerID FROM Customers WHERE CustomerCode=@code", cn)
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
                Using cmd As New SqlCommand(
                    "SELECT CAST(IsActive AS INT) FROM Customers WHERE CustomerID=@id", cn)
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
    ' [تحسين الأكبر]: كل العملية داخل Transaction Async
    '  واجهة لا تتجمد أبداً أثناء الحفظ
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

        ' [الأمان]: التحقق من صحة رقم الفاتورة
        If Not Integer.TryParse(txt_Invoice_ID.Text.Trim(), invoiceCode) OrElse invoiceCode <= 0 Then
            ShowError("رقم الفاتورة غير صالح.")
            Return
        End If

        btnSaveInvoice.Enabled = False   ' منع الضغط المزدوج
        Try
            Dim newInvoiceID As Integer = 0
            Dim totalProfit As Decimal = 0D

            ' جمع بيانات الجريد قبل الـ Await (لأن الجريد على UI Thread)
            Dim gridData = CollectGridData()

            Await Task.Run(Async Function()
                               Using cn = Await OpenConnectionAsync()
                                   Using transaction As SqlTransaction = cn.BeginTransaction(IsolationLevel.ReadCommitted)
                                       Try
                                           newInvoiceID = InsertSalesHeader(invoiceCode, customerID,
                                               totalBefore, totalAfter, discount, paid, remaining,
                                               notes, userID, userName, paymentType, cn, transaction)

                                           InsertSalesDetailsAndUpdateStock(newInvoiceID, gridData, cn, transaction)

                                           totalProfit = gridData.Sum(Function(r) r.Profit)
                                           UpdateInvoiceProfitSync(newInvoiceID, totalProfit, cn, transaction)

                                           If Not CheckCreditLimitSync(customerCode, remaining, cn, transaction) Then
                                               transaction.Rollback()
                                               Return
                                           End If

                                           UpdateCustomerBalanceSync(customerCode, remaining, cn, transaction)
                                           transaction.Commit()
                                       Catch ex As Exception
                                           Try : transaction.Rollback() : Catch : End Try
                                           Throw
                                       End Try
                                   End Using
                               End Using
                           End Function)

            ' العودة لـ UI Thread بعد الحفظ
            _currentIDV = newInvoiceID

            ' قفل الفاتورة: منع إضافة منتجات أو الحفظ مرة تانية
            ' المستخدم يقدر يطبع أو يضغط مسح/حذف لبدء فاتورة جديدة
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

            ' مسح الفاتورة بعد الحفظ
            'DataGridView1.Rows.Clear()
            'cleartxts()

        Catch ex As Exception
            ShowError("❌ فشل الحفظ. تم التراجع عن التغييرات. الخطأ: " & ex.Message)
        Finally
            ' لو الفاتورة اتحفظت بنجاح نسيب الزر مقفول لحد ما يضغط مسح/حذف
            If Not _invoiceSaved Then btnSaveInvoice.Enabled = True
        End Try
    End Sub

    ' ── جمع بيانات الجريد في بنية منفصلة (يُستخدم قبل أي Await) ──
    Private Function CollectGridData() As List(Of InvoiceLineData)
        Dim result As New List(Of InvoiceLineData)()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For
            result.Add(New InvoiceLineData With {
                .ProductID = ParseInt(row.Cells("ColProductID").Value),
                .ProductName = Convert.ToString(row.Cells("ColProductName").Value),
                .UnitID = ParseInt(row.Cells("ColUnitID").Value),
                .UnitName = Convert.ToString(row.Cells("ColUnitName").Value),
                .SalePrice = ParseDecimal(Convert.ToString(row.Cells("ColPrice").Value)),
                .Quantity = ParseDecimal(Convert.ToString(row.Cells("ColQuantity").Value)),
                .Total = ParseDecimal(Convert.ToString(row.Cells("ColTotal").Value)),
                .Factor = ParseDecimal(Convert.ToString(row.Cells("ColFactor").Value)),
                .Profit = ParseDecimal(Convert.ToString(row.Cells("ColProfit").Value))
            })
        Next
        Return result
    End Function

    ' ── بنية بيانات سطر الفاتورة ──
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
        Public ReadOnly Property IsScaleProduct As Boolean
            Get
                Return UnitName = "جرام" OrElse UnitName = "جم"
            End Get
        End Property
    End Class

    '══════════════════════════════════════════════════════════════
    ' إدراج رأس الفاتورة (متزامن داخل Task.Run)
    '══════════════════════════════════════════════════════════════
    Private Function InsertSalesHeader(invoiceCode As Integer, customerID As Integer,
                                       totalBefore As Decimal, totalAfter As Decimal,
                                       discountVal As Decimal, paid As Decimal, remaining As Decimal,
                                       notes As String, userID As Integer, userName As String,
                                       paymentType As String,
                                       cn As SqlConnection, tx As SqlTransaction) As Integer

        ' [الأمان]: التحقق من عدم تكرار رقم الفاتورة
        Using checkCmd As New SqlCommand(
            "SELECT COUNT(*) FROM SalesHeader WHERE Invoice_Code=@ic", cn, tx)
            checkCmd.Parameters.Add("@ic", SqlDbType.Int).Value = invoiceCode
            If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                Throw New Exception("كود الفاتورة موجود بالفعل.")
            End If
        End Using

        Dim sql As String =
            "INSERT INTO SalesHeader(Invoice_Code,Invoice_type,Invoice_Date,Customer_ID," &
            "User_ID,User_Name,Total_Amount,Discount_Value,Net_Amount,Amount_Paid,Remaining,Payment_Method,Notes)" &
            " VALUES(@ic,@it,GETDATE(),@cid,@uid,@un,@ta,@dv,@na,@ap,@rem,@pm,@nt);" &
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

            Dim obj = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Return CInt(obj)
            End If
            Throw New Exception("فشل إنشاء رقم الفاتورة (SCOPE_IDENTITY).")
        End Using
    End Function

    '══════════════════════════════════════════════════════════════
    ' إدراج تفاصيل الفاتورة وتحديث المخزون (Batch)
    ' [الأمان]: Parameters ديناميكية بدلاً من String.Join في SQL
    '  يمنع SQL Injection تماماً في IN clause
    '══════════════════════════════════════════════════════════════
    Private Sub InsertSalesDetailsAndUpdateStock(invoiceID As Integer,
                                                  lines As List(Of InvoiceLineData),
                                                  cn As SqlConnection, tx As SqlTransaction)
        If lines.Count = 0 Then Return

        ' جمع IDs بأمان
        Dim regularIds = lines.Where(Function(l) Not l.IsScaleProduct AndAlso l.ProductID > 0) _
                              .Select(Function(l) l.ProductID).Distinct().ToList()
        Dim scaleIds = lines.Where(Function(l) l.IsScaleProduct AndAlso l.ProductID > 0) _
                            .Select(Function(l) l.ProductID).Distinct().ToList()

        ' [الأمان]: بناء Parameters ديناميكي بدلاً من String.Join في SQL مباشرة
        Dim profitRegular As New Dictionary(Of String, Decimal)
        If regularIds.Count > 0 Then
            Dim paramNames As New List(Of String)
            Using cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.Transaction = tx
                For i = 0 To regularIds.Count - 1
                    Dim pName = "@p" & i
                    paramNames.Add(pName)
                    cmd.Parameters.Add(pName, SqlDbType.Int).Value = regularIds(i)
                Next
                cmd.CommandText =
                    "SELECT Product_ID,ProductUnit_ID,ISNULL(Purchase_Price,0),ISNULL(Sale_Price,0) " &
                    $"FROM ProductUnits WHERE Product_ID IN ({String.Join(",", paramNames)})"
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim k = $"{rd(0)}_{rd(1)}"
                        profitRegular(k) = CDec(rd(3)) - CDec(rd(2))
                    End While
                End Using
            End Using
        End If

        Dim profitScale As New Dictionary(Of Integer, Decimal)
        If scaleIds.Count > 0 Then
            Dim paramNames As New List(Of String)
            Using cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.Transaction = tx
                For i = 0 To scaleIds.Count - 1
                    Dim pName = "@s" & i
                    paramNames.Add(pName)
                    cmd.Parameters.Add(pName, SqlDbType.Int).Value = scaleIds(i)
                Next
                cmd.CommandText =
                    "SELECT Code,ISNULL(Price,0),ISNULL(Purchase_Price,0) " &
                    $"FROM TheScale WHERE Code IN ({String.Join(",", paramNames)})"
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        profitScale(Convert.ToInt32(rd(0))) = CDec(rd(1)) - CDec(rd(2))
                    End While
                End Using
            End Using
        End If

        ' إدراج التفاصيل
        For Each line In lines
            Dim profit As Decimal = 0D
            If line.IsScaleProduct Then
                Dim weightKg As Decimal = line.Quantity / 1000D
                If profitScale.ContainsKey(line.ProductID) Then
                    profit = profitScale(line.ProductID) * weightKg
                End If
            Else
                Dim key = $"{line.ProductID}_{line.UnitID}"
                If profitRegular.ContainsKey(key) Then
                    profit = profitRegular(key) * line.Quantity
                End If
            End If

            Using cmd As New SqlCommand(
                "INSERT INTO SalesDetails(Invoice_ID,Product_ID,Product_Name,ProductUnit_ID," &
                "ProductUnit_Name,Quantity_Sold,Sale_Price_Per_Unit,Total_Line_Amount,Profit)" &
                " VALUES(@inv,@pid,@pn,@uid,@un,@qty,@price,@total,@profit);",
                cn, tx)
                cmd.Parameters.Add("@inv", SqlDbType.Int).Value = invoiceID
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = line.ProductID
                cmd.Parameters.Add("@pn", SqlDbType.NVarChar, 300).Value = line.ProductName
                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = line.UnitID
                cmd.Parameters.Add("@un", SqlDbType.NVarChar, 100).Value = line.UnitName
                cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = line.Quantity
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = line.SalePrice
                cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = line.Total
                cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = line.Profit
                cmd.ExecuteNonQuery()
            End Using

            ' تحديث المخزون (ليس لمنتجات الميزان)
            If line.IsScaleProduct OrElse line.ProductID <= 0 Then Continue For
            Dim qtyToDeduct As Decimal = line.Quantity * If(line.Factor > 0, line.Factor, 1D)
            Using cmd As New SqlCommand(
                "UPDATE Stock SET Quantity_OnHand=Quantity_OnHand-@qty WHERE Product_ID=@pid;",
                cn, tx)
                cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = qtyToDeduct
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = line.ProductID
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub UpdateInvoiceProfitSync(invoiceID As Integer, profit As Decimal,
                                         cn As SqlConnection, tx As SqlTransaction)
        Using cmd As New SqlCommand(
            "UPDATE SalesHeader SET Total_Profit=@p WHERE Invoice_ID=@id", cn, tx)
            cmd.Parameters.Add("@p", SqlDbType.Decimal).Value = profit
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function CheckCreditLimitSync(customerCode As String, remaining As Decimal,
                                          cn As SqlConnection, tx As SqlTransaction) As Boolean
        Dim balanceBefore As Decimal = 0D, creditLimit As Decimal = 0D
        Using cmd As New SqlCommand(
            "SELECT ISNULL(CurrentBalance,0),ISNULL(CreditLimit,0) " &
            "FROM Customers WHERE CustomerCode=@code", cn, tx)
            cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    balanceBefore = Convert.ToDecimal(rd(0))
                    creditLimit = Convert.ToDecimal(rd(1))
                End If
            End Using
        End Using

        Dim balanceAfter As Decimal = balanceBefore + remaining
        If balanceAfter > creditLimit Then
            Me.Invoke(Sub() ShowWarning(
                "⚠️ الرصيد بعد العملية سيتجاوز حد الائتمان." & vbCrLf &
                $"حد الائتمان: {creditLimit}" & vbCrLf &
                $"الرصيد الحالي: {balanceBefore}" & vbCrLf &
                $"متبقي الفاتورة: {remaining}" & vbCrLf &
                $"الرصيد بعد الفاتورة: {balanceAfter}"))
            Return False
        End If
        Return True
    End Function

    Private Sub UpdateCustomerBalanceSync(customerCode As String, remaining As Decimal,
                                          cn As SqlConnection, tx As SqlTransaction)
        If remaining = 0D Then Return
        Using cmd As New SqlCommand(
            "UPDATE Customers SET CurrentBalance=ISNULL(CurrentBalance,0)+@rem WHERE CustomerCode=@code;",
            cn, tx)
            cmd.Parameters.Add("@rem", SqlDbType.Decimal).Value = remaining
            cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Async Function GetCustomerPhoneAsync(customerCode As String) As Task(Of String)
        Try
            Using cn = Await OpenConnectionAsync()
                Using cmd As New SqlCommand(
                    "SELECT PhoneNumber FROM Customers WHERE CustomerCode=@code", cn)
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar, 50).Value = customerCode
                    Using rd = Await cmd.ExecuteReaderAsync()
                        If Await rd.ReadAsync() Then
                            Return If(IsDBNull(rd("PhoneNumber")), "", rd("PhoneNumber").ToString().Trim())
                        End If
                    End Using
                End Using
            End Using
        Catch
            ' إرجاع فارغ عند أي خطأ
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

            '══════════════════════════════════════
            ' تحميل الهيدر
            '══════════════════════════════════════
            Using cmd As New SqlCommand(
        "SELECT 
            h.Invoice_ID,
            h.Invoice_Code,
            h.Total_Amount,
            h.Discount_Value,
            h.Net_Amount,
            h.Amount_Paid,
            h.Remaining,
            h.Payment_Method,
            h.Notes,
            c.CustomerID,
            c.CustomerCode,
            c.CustomerName,
            ISNULL(c.CurrentBalance,0) AS CurrentBalance
        FROM SalesHeader h
        INNER JOIN Customers c ON h.Customer_ID = c.CustomerID
        WHERE h.Invoice_ID=@id", cn)

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID

                Using rd = Await cmd.ExecuteReaderAsync()

                    If Await rd.ReadAsync() Then

                        _currentIDV = Convert.ToInt32(rd("Invoice_ID"))

                        txt_Invoice_ID.Text = rd("Invoice_Code").ToString()

                        txt_Customer_Code.Text = rd("CustomerCode").ToString()
                        txt_Customer_Name.Text = rd("CustomerName").ToString()

                        txt_Customer_Balance.Text = rd("CurrentBalance").ToString()

                        cmb_Pay.Text = rd("Payment_Method").ToString()

                        txtTotalRequired.Text = rd("Net_Amount").ToString()
                        txtTotalAfterDiscount.Text = rd("Total_Amount").ToString()

                        txtDiscount.Text = rd("Discount_Value").ToString()
                        txtPaid.Text = rd("Amount_Paid").ToString()
                        txtRemaining.Text = rd("Remaining").ToString()

                        txt_notes.Text = rd("Notes").ToString()

                    Else
                        ShowWarning("الفاتورة غير موجودة.")
                        Return
                    End If

                End Using
            End Using


            '══════════════════════════════════════
            ' تحميل تفاصيل الفاتورة
            '══════════════════════════════════════
            Using cmd As New SqlCommand(
        "SELECT 
            P.Product_Code,
            d.Product_ID,
            d.Product_Name,
            d.ProductUnit_ID,
            d.ProductUnit_Name,
            d.Quantity_Sold,
            d.Sale_Price_Per_Unit,
            d.Total_Line_Amount,
            ISNULL(u.Unit_Quantity,1) AS Factor,
            CASE WHEN s.Code IS NULL THEN 0 ELSE 1 END AS IsScaleProduct
        FROM SalesDetails d
        LEFT JOIN ProductUnits u 
            ON d.Product_ID = u.Product_ID 
            AND d.ProductUnit_ID = u.ProductUnit_ID
        LEFT JOIN Products P
            ON d.Product_ID = P.Product_ID
        LEFT JOIN TheScale s 
            ON d.Product_ID = s.Code
        WHERE d.Invoice_ID=@id
        ORDER BY d.Detail_ID", cn)

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

                        ' الأعمدة الظاهرة
                        r.Cells("colProductID").Value = productID
                        r.Cells("ColProduct_Code").Value = productCode
                        r.Cells("colProductName").Value = productName
                        r.Cells("colUnitID").Value = unitID
                        r.Cells("colUnitName").Value = unitName
                        r.Cells("colQuantity").Value = qty
                        r.Cells("ColPrice").Value = price
                        r.Cells("colTotal").Value = total

                        ' الأعمدة المخفية (مهمة للمعالجة)
                        If DataGridView1.Columns.Contains("colFactor") Then
                            r.Cells("colFactor").Value = factor
                        End If

                        If DataGridView1.Columns.Contains("colIsScaleProduct") Then
                            r.Cells("colIsScaleProduct").Value = isScale
                        End If

                    End While

                End Using
            End Using

        End Using


        '══════════════════════════════════════
        ' إعادة حساب الإجماليات
        '══════════════════════════════════════
        Try

            Dim total As Decimal = 0D

            For Each r As DataGridViewRow In DataGridView1.Rows
                If r.IsNewRow Then Continue For

                If r.Cells("colTotal").Value IsNot Nothing Then
                    total += Convert.ToDecimal(r.Cells("colTotal").Value)
                End If
            Next

            txtTotalRequired.Text = total.ToString("0.00")

            Dim discount As Decimal = ParseDecimal(txtDiscount.Text)

            txtTotalAfterDiscount.Text = (total - discount).ToString("0.00")

            txtRemaining.Text =
            (ParseDecimal(txtTotalAfterDiscount.Text) -
             ParseDecimal(txtPaid.Text)).ToString("0.00")

        Catch
        End Try

    End Function


    Public Async Function UpdateInvoiceAsync(invoiceID As Integer) As Task

        If invoiceID <= 0 Then
            ShowWarning("رقم الفاتورة غير صالح.")
            Return
        End If

        Dim customerCode As String = txt_Customer_Code.Text.Trim()

        Dim newTotalBefore As Decimal = ParseDecimal(txtTotalRequired.Text)
        Dim newTotalAfter As Decimal = ParseDecimal(txtTotalAfterDiscount.Text)
        Dim newDiscount As Decimal = ParseDecimal(txtDiscount.Text)
        Dim newPaid As Decimal = ParseDecimal(txtPaid.Text)
        Dim newRemaining As Decimal = ParseDecimal(txtRemaining.Text)

        Dim notes As String = txt_notes.Text.Trim()
        Dim paymentType As String = cmb_Pay.Text.Trim()

        Dim gridData = CollectGridData()

        Using cn = Await OpenConnectionAsync()
            Using tr = cn.BeginTransaction()

                Try

                    '══════════════════════════════
                    ' جلب المتبقي القديم
                    '══════════════════════════════
                    Dim oldRemaining As Decimal = 0

                    Using cmd As New SqlCommand(
                "SELECT Remaining FROM SalesHeader WHERE Invoice_ID=@id",
                cn, tr)

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
                        oldRemaining = Convert.ToDecimal(cmd.ExecuteScalar())
                    End Using


                    '══════════════════════════════
                    ' إعادة المخزون القديم (استعلام واحد)
                    '══════════════════════════════
                    Using cmd As New SqlCommand(
                "UPDATE S
                 SET S.Quantity_OnHand = S.Quantity_OnHand + (D.Quantity_Sold * ISNULL(U.Unit_Quantity,1))
                 FROM Stock S
                 INNER JOIN SalesDetails D ON S.Product_ID = D.Product_ID
                 LEFT JOIN ProductUnits U 
                 ON D.Product_ID = U.Product_ID 
                 AND D.ProductUnit_ID = U.ProductUnit_ID
                 WHERE D.Invoice_ID=@id", cn, tr)

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
                        cmd.ExecuteNonQuery()
                    End Using


                    '══════════════════════════════
                    ' حذف التفاصيل القديمة
                    '══════════════════════════════
                    Using cmd As New SqlCommand(
                "DELETE FROM SalesDetails WHERE Invoice_ID=@id",
                cn, tr)

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = invoiceID
                        cmd.ExecuteNonQuery()
                    End Using


                    '══════════════════════════════
                    ' إدخال التفاصيل الجديدة
                    '══════════════════════════════
                    InsertSalesDetailsAndUpdateStock(invoiceID, gridData, cn, tr)


                    '══════════════════════════════
                    ' حساب الربح الجديد
                    '══════════════════════════════
                    Dim totalProfit As Decimal = gridData.Sum(Function(r) r.Profit)

                    UpdateInvoiceProfitSync(invoiceID, totalProfit, cn, tr)


                    '══════════════════════════════
                    ' تحديث الهيدر
                    '══════════════════════════════
                    Using cmd As New SqlCommand(
                "UPDATE SalesHeader
                 SET Total_Amount=@total,
                     Discount_Value=@discount,
                     Net_Amount=@net,
                     Amount_Paid=@paid,
                     Remaining=@rem,
                     Payment_Method=@pm,
                     Notes=@notes
                 WHERE Invoice_ID=@id", cn, tr)

                        cmd.Parameters.AddWithValue("@total", newTotalAfter)
                        cmd.Parameters.AddWithValue("@discount", newDiscount)
                        cmd.Parameters.AddWithValue("@net", newTotalBefore)
                        cmd.Parameters.AddWithValue("@paid", newPaid)
                        cmd.Parameters.AddWithValue("@rem", newRemaining)
                        cmd.Parameters.AddWithValue("@pm", paymentType)
                        cmd.Parameters.AddWithValue("@notes", notes)
                        cmd.Parameters.AddWithValue("@id", invoiceID)

                        cmd.ExecuteNonQuery()
                    End Using


                    '══════════════════════════════
                    ' تعديل رصيد العميل بالفرق
                    '══════════════════════════════
                    Dim diff As Decimal = newRemaining - oldRemaining

                    If diff <> 0 Then

                        Using cmd As New SqlCommand(
                    "UPDATE Customers
                     SET CurrentBalance = ISNULL(CurrentBalance,0) + @diff
                     WHERE CustomerCode=@code", cn, tr)

                            cmd.Parameters.AddWithValue("@diff", diff)
                            cmd.Parameters.AddWithValue("@code", customerCode)

                            cmd.ExecuteNonQuery()
                        End Using

                    End If


                    tr.Commit()

                    MessageBox.Show("تم تعديل الفاتورة بنجاح",
                                "نجاح",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                Catch ex As Exception

                    Try
                        tr.Rollback()
                    Catch
                    End Try

                    Throw

                End Try

            End Using
        End Using

    End Function

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
        ShowInfo(If(success, "✅ تم إرسال الفاتورة على واتساب بنجاح",
                              "❌ فشل إرسال الفاتورة على واتساب"))
    End Function

    Private Function IsInternetAvailable() As Boolean
        Try
            Return NetworkInterface.GetIsNetworkAvailable()
        Catch
            Return False
        End Try
    End Function

    '══════════════════════════════════════════════════════════════
    ' الطباعة (في Background Thread)
    ' [تحسين]: PrintInvoice تعمل في Task.Run ← UI لا يتجمد
    ' [إصلاح Memory Leak]: كل GDI objects داخل Using
    '══════════════════════════════════════════════════════════════
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Await PrintInvoiceSafeAsync(_currentIDV)
    End Sub

    Private Async Function PrintInvoiceSafeAsync(invoiceID As Integer) As Task
        Try
            ' جمع بيانات الطباعة من UI Thread أولاً
            Dim printData = CollectPrintData()

            ' لو المعاينة مفعّلة، نشغّل على UI Thread مباشرة (PrintPreviewDialog يلزمه UI Thread)
            ' ولا نبعت أي حاجة للطابعة إلا لو المستخدم ضغط على زر الطباعة من نافذة المعاينة نفسها.
            If ShouldShowPrintPreview() Then
                PrintInvoice80mmProfessionalCore(invoiceID, printData)
            Else
                Await Task.Run(Sub() PrintInvoice80mmProfessionalCore(invoiceID, printData))
            End If
        Catch ex As Exception
            ShowError("خطأ أثناء الطباعة: " & ex.Message)
        End Try
    End Function

    ' بنية لجمع بيانات الطباعة من UI Thread
    Private Class PrintData
        Public InvoiceItems As List(Of InvoiceLineData)
        Public CustomerCode As String
        Public CustomerName As String
        Public CustomerBalance As String
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
            .TotalRequired = txtTotalRequired.Text,
            .Discount = txtDiscount.Text,
            .TotalAfterDiscount = txtTotalAfterDiscount.Text,
            .Paid = txtPaid.Text,
            .Remaining = txtRemaining.Text,
            .UserName = lbl_user_name.Text,
            .PaymentMethod = cmb_Pay.Text
        }
    End Function

    ' [إصلاح Memory Leak]: جميع الـ GDI objects داخل Using
    'Private Sub PrintInvoice80mmProfessionalCore(invoiceID As Integer, data As PrintData)
    '    Const StoreName As String = "سوبر ماركت الحمد والرضا"
    '    Const Phone1 As String = "01095032689"
    '    Const Phone2 As String = "0242295339"
    '    Const Address As String = "السلمانية - شارع الجمعية الزراعية"
    '    Const FooterMsg As String = "❤ شكراً لتعاملكم معنا"
    '    Const subtitle As String = "❤ شكراً لتعاملكم معنايوجد توصيل للمنازل"

    '    Using logoImg As System.Drawing.Image = System.Drawing.Image.FromFile("D:\final_logo_2.png")
    '        Using fTitle As New Font("Traditional Arabic", 16, FontStyle.Bold)
    '            Using fBold As New Font("Traditional Arabic", 10, FontStyle.Bold)
    '                Using f11 As New Font("Traditional Arabic", 10)
    '                    Using pd As New PrintDocument()
    '                        pd.PrinterSettings.PrinterName = "XP-80C"
    '                        pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
    '                        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

    '                        Dim handler As PrintPageEventHandler = Nothing
    '                        handler = Sub(sender, e)
    '                                      Dim g = e.Graphics
    '                                      Dim Y As Integer = e.MarginBounds.Top
    '                                      Dim pageW As Integer = e.MarginBounds.Width
    '                                      Dim leftX As Integer = e.MarginBounds.Left

    '                                      ' [إصلاح Memory Leak]: StringFormat و Pen داخل Using
    '                                      Using fmtC As New StringFormat() With {
    '                                          .Alignment = StringAlignment.Center,
    '                                          .LineAlignment = StringAlignment.Center,
    '                                          .FormatFlags = StringFormatFlags.DirectionRightToLeft}
    '                                          Using fmtR As New StringFormat() With {
    '                                              .Alignment = StringAlignment.Far,
    '                                              .LineAlignment = StringAlignment.Center,
    '                                              .FormatFlags = StringFormatFlags.DirectionRightToLeft}
    '                                              Using fmtWrap As New StringFormat() With {
    '                                                  .Alignment = StringAlignment.Near,
    '                                                  .LineAlignment = StringAlignment.Center,
    '                                                  .FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.NoClip}
    '                                                  Using linePen As New Pen(Color.Black, 1)

    '                                                      Dim centerLine = Sub(t As String, f As Font)
    '                                                                           g.DrawString(t, f, Brushes.Black,
    '                                                                               New RectangleF(leftX, Y, pageW, f.Height + 5), fmtC)
    '                                                                           Y += f.Height + 5
    '                                                                       End Sub

    '                                                      Dim rightLine = Sub(t As String, f As Font)
    '                                                                          g.DrawString(t, f, Brushes.Black,
    '                                                                              New RectangleF(leftX, Y, pageW, f.Height + 6), fmtR)
    '                                                                          Y += f.Height + 6
    '                                                                      End Sub

    '                                                      Dim separator = Sub()
    '                                                                          g.DrawLine(linePen, leftX, Y, leftX + pageW, Y)
    '                                                                          Y += 8
    '                                                                      End Sub

    '                                                      ' رأس الفاتورة
    '                                                      Dim titleSize = g.MeasureString(StoreName, fTitle)
    '                                                      g.DrawString(StoreName, fTitle, Brushes.Black,
    '                                                          New RectangleF(leftX, Y, pageW, titleSize.Height), fmtC)

    '                                                      g.DrawString(subtitle, fTitle, Brushes.Black,
    '                                                                   New RectangleF(leftX, Y, pageW, titleSize.Height), fmtC)
    '                                                      Dim infoY As Integer = Y + CInt(titleSize.Height) + 5 + 30
    '                                                      Dim infoX As Integer = leftX

    '                                                      Dim rightAt = Sub(t As String, f As Font, ByRef myY As Integer)
    '                                                                        g.DrawString(t, f, Brushes.Black,
    '                                                                            New RectangleF(infoX, myY, pageW, f.Height + 6), fmtR)
    '                                                                        myY += f.Height + 6
    '                                                                    End Sub

    '                                                      rightAt("هاتف: " & Phone1, f11, infoY)
    '                                                      rightAt("أرضي: " & Phone2, f11, infoY)
    '                                                      rightAt(Address, f11, infoY)
    '                                                      Y = Math.Max(Y + CInt(titleSize.Height) + 5 + 80, infoY)

    '                                                      separator()
    '                                                      rightLine("نوع الفاتورة : فاتورة مبيعات", f11)
    '                                                      rightLine("رقم الفاتورة : " & invoiceID, f11)
    '                                                      rightLine("التاريخ : " & DateTime.Now.ToString("yyyy/MM/dd  hh:mm:ss tt"), f11)
    '                                                      rightLine("الكاشير : " & data.UserName, f11)
    '                                                      rightLine("كود العميل : " & data.CustomerCode, f11)
    '                                                      rightLine("اسم العميل : " & data.CustomerName, f11)
    '                                                      separator()

    '                                                      ' الجدول
    '                                                      Dim colTW = CInt(pageW * 0.2)
    '                                                      Dim colPW = CInt(pageW * 0.16)
    '                                                      Dim colQW = CInt(pageW * 0.16)
    '                                                      Dim colNW = pageW - (colTW + colPW + colQW)
    '                                                      Dim xT As Integer = leftX
    '                                                      Dim xP As Integer = xT + colTW
    '                                                      Dim xQ As Integer = xP + colPW
    '                                                      Dim xN As Integer = xQ + colQW
    '                                                      Dim tableY As Integer = Y
    '                                                      Dim headerH As Integer = 26

    '                                                      g.DrawString("المنتج", fBold, Brushes.Black, New RectangleF(xN, Y, colNW, headerH), fmtC)
    '                                                      g.DrawString("الكمية", fBold, Brushes.Black, New RectangleF(xQ, Y, colQW, headerH), fmtC)
    '                                                      g.DrawString("السعر", fBold, Brushes.Black, New RectangleF(xP, Y, colPW, headerH), fmtC)
    '                                                      g.DrawString("الإجمالي", fBold, Brushes.Black, New RectangleF(xT, Y, colTW, headerH), fmtC)
    '                                                      Y += headerH

    '                                                      For Each line In data.InvoiceItems
    '                                                          Dim h As Integer = Math.Max(26,
    '                                                              CInt(g.MeasureString(line.ProductName, f11, colNW, fmtWrap).Height) + 6)
    '                                                          g.DrawString("  " & line.ProductName & " ", f11, Brushes.Black,
    '                                                              New RectangleF(xN, Y + 3, colNW, h - 6), fmtC)
    '                                                          g.DrawString(line.Quantity.ToString(), f11, Brushes.Black,
    '                                                              New RectangleF(xQ, Y, colQW, h), fmtC)
    '                                                          g.DrawString(FormatNumber(line.SalePrice, 2), f11, Brushes.Black,
    '                                                              New RectangleF(xP - 3, Y, colPW, h), fmtC)
    '                                                          g.DrawString(FormatNumber(line.Total, 2), f11, Brushes.Black,
    '                                                              New RectangleF(xT - 3, Y, colTW, h), fmtC)
    '                                                          Y += h
    '                                                          g.DrawLine(linePen, leftX, Y, leftX + pageW, Y)
    '                                                      Next

    '                                                      Dim tableEndY As Integer = Y
    '                                                      g.DrawLine(linePen, leftX, tableY, leftX + pageW, tableY)
    '                                                      g.DrawLine(linePen, leftX, tableY + headerH, leftX + pageW, tableY + headerH)
    '                                                      g.DrawLine(linePen, leftX, tableEndY, leftX + pageW, tableEndY)
    '                                                      g.DrawLine(linePen, xT, tableY, xT, tableEndY)
    '                                                      g.DrawLine(linePen, xP, tableY, xP, tableEndY)
    '                                                      g.DrawLine(linePen, xQ, tableY, xQ, tableEndY)
    '                                                      g.DrawLine(linePen, xN, tableY, xN, tableEndY)
    '                                                      g.DrawLine(linePen, xN + colNW, tableY, xN + colNW, tableEndY)

    '                                                      separator()
    '                                                      If Val(data.Discount) > 0 Then
    '                                                          rightLine("إجمالي قبل الخصم : " & data.TotalRequired, fBold)
    '                                                          rightLine("الخصم : " & data.Discount, fBold)
    '                                                          rightLine("الصافي : " & data.TotalAfterDiscount, fBold)
    '                                                      Else
    '                                                          rightLine("إجمالي الفاتورة : " & data.TotalRequired, fBold)
    '                                                      End If
    '                                                      rightLine("المدفوع : " & data.Paid, fBold)

    '                                                      If data.CustomerCode <> "1" Then
    '                                                          Dim prevBal As Decimal = 0D
    '                                                          Dim invRem As Decimal = 0D
    '                                                          Decimal.TryParse(data.CustomerBalance, prevBal)
    '                                                          Decimal.TryParse(data.Remaining, invRem)
    '                                                          rightLine("رصيد سابق : " & prevBal.ToString("0.00"), fBold)
    '                                                          rightLine("متبقي الفاتورة : " & invRem.ToString("0.00"), fBold)
    '                                                          rightLine("إجمالي الحساب : " & (prevBal + invRem).ToString("0.00"), fBold)
    '                                                      End If

    '                                                      separator()
    '                                                      ' [إصلاح Memory Leak]: QR Bitmap داخل Using
    '                                                      Using qr As Bitmap = GenerateQRCode(invoiceID.ToString())
    '                                                          g.DrawImage(qr, leftX + (pageW - qr.Width) \ 2, Y)
    '                                                          Y += qr.Height + 5
    '                                                      End Using

    '                                                      centerLine(FooterMsg, fBold)
    '                                                      e.HasMorePages = False
    '                                                      separator()

    '                                                  End Using : End Using : End Using : End Using
    '                                  End Sub

    '                        AddHandler pd.PrintPage, handler
    '                        Try
    '                            pd.Print()
    '                        Finally
    '                            ' [إصلاح Memory Leak]: إلغاء تسجيل الـ handler دائماً
    '                            RemoveHandler pd.PrintPage, handler
    '                        End Try
    '                    End Using
    '                End Using : End Using : End Using : End Using
    'End Sub

    'Private Function GenerateQRCode(text As String) As Bitmap
    '    Dim writer As New ZXing.BarcodeWriter() With {
    '        .Format = ZXing.BarcodeFormat.CODE_128,
    '        .Options = New ZXing.Common.EncodingOptions With {
    '            .Height = 70, .Width = 140, .Margin = 0}}
    '    Return writer.Write(text)
    'End Function

    '''الكود الجديد 
    ''' <summary>
    ''' الكود الجديد 
    ''' 
    ''' </summary>

    Private Sub PrintInvoice80mmProfessionalCore(invoiceID As Integer, data As PrintData)
        Dim styleVal As String = SettingsManager.GetSetting("PrintStyle")
        If String.IsNullOrEmpty(styleVal) Then styleVal = "1"
        If styleVal = "2" Then
            PrintInvoice80mm_Style2(invoiceID, data)
        Else
            PrintInvoice80mm_Style1(invoiceID, data)
        End If
    End Sub

    Private Sub PrintInvoice80mm_Style1(invoiceID As Integer, data As PrintData)
        Dim StoreName As String = SettingsManager.GetSetting("ShopName")
        Dim ShopPhone As String = SettingsManager.GetSetting("ShopPhone")
        Dim ShopAddress As String = SettingsManager.GetSetting("ShopAddress")
        Dim TaxNumber As String = SettingsManager.GetSetting("TaxNumber")
        Dim FooterMsg As String = SettingsManager.GetSetting("FooterText")

        If String.IsNullOrEmpty(StoreName) Then StoreName = "سوبر ماركت الحمد والرضا"
        If String.IsNullOrEmpty(FooterMsg) Then FooterMsg = "❤ شكراً لتعاملكم معنا"

        Dim thermalPrinter As String = SettingsManager.GetSetting("ThermalPrinterName")
        Dim logoPath As String = SettingsManager.GetSetting("LogoPath")

        ' احترام إعداد "طباعة اللوجو مع الفاتورة"
        Dim printLogoSetting As String = SettingsManager.GetSetting("PrintLogo")
        Dim shouldPrintLogo As Boolean = String.IsNullOrEmpty(printLogoSetting) OrElse printLogoSetting.Trim().ToLower() = "true"

        Dim logoImg As System.Drawing.Image = Nothing
        Try
            If shouldPrintLogo AndAlso Not String.IsNullOrEmpty(logoPath) AndAlso IO.File.Exists(logoPath) Then
                logoImg = System.Drawing.Image.FromFile(logoPath)
            End If
        Catch
        End Try

        Try
            Using fTitle As New Font("Arial", 16, FontStyle.Bold)
                Using fBold As New Font("Arial", 12, FontStyle.Bold)
                    Using f11 As New Font("Arial", 11, FontStyle.Bold)
                        Using pd As New PrintDocument()
                            If Not String.IsNullOrEmpty(thermalPrinter) Then
                                pd.PrinterSettings.PrinterName = thermalPrinter
                            End If
                            pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
                            pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

                            Dim handler As PrintPageEventHandler = Nothing
                            handler = Sub(sender, e)
                                          Dim g = e.Graphics
                                          Dim Y As Integer = e.MarginBounds.Top
                                          Dim pageW As Integer = e.MarginBounds.Width
                                          Dim leftX As Integer = e.MarginBounds.Left

                                          Using fmtC As New StringFormat() With {
                                              .Alignment = StringAlignment.Center,
                                              .LineAlignment = StringAlignment.Center,
                                              .FormatFlags = StringFormatFlags.DirectionRightToLeft}
                                              Using fmtR As New StringFormat() With {
                                                  .Alignment = StringAlignment.Far,
                                                  .LineAlignment = StringAlignment.Center,
                                                  .FormatFlags = StringFormatFlags.DirectionRightToLeft}
                                                  Using fmtWrap As New StringFormat() With {
                                                      .Alignment = StringAlignment.Near,
                                                      .LineAlignment = StringAlignment.Center,
                                                      .FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.NoClip}
                                                      Using linePen As New Pen(Color.Black, 1)

                                                          Dim centerLine = Sub(t As String, f As Font)
                                                                               g.DrawString(t, f, Brushes.Black,
                                                                                            New RectangleF(leftX, Y, pageW, f.Height + 5), fmtC)
                                                                               Y += f.Height + 5
                                                                           End Sub

                                                          Dim rightLine = Sub(t As String, f As Font)
                                                                              g.DrawString(t, f, Brushes.Black,
                                                                                           New RectangleF(leftX, Y, pageW, f.Height + 6), fmtR)
                                                                              Y += f.Height + 6
                                                                          End Sub

                                                          Dim separator = Sub()
                                                                              g.DrawLine(linePen, leftX, Y, leftX + pageW, Y)
                                                                              Y += 8
                                                                          End Sub

                                                          If logoImg IsNot Nothing Then
                                                              Dim logoWidth As Integer = 180
                                                              Dim logoHeight As Integer = CInt(logoWidth * logoImg.Height / logoImg.Width)
                                                              Dim logoXPos As Integer = leftX + (pageW - logoWidth) \ 2
                                                              g.DrawImage(logoImg, logoXPos, Y, logoWidth, logoHeight)
                                                              Y += logoHeight + 10
                                                          End If

                                                          Dim titleSize = g.MeasureString(StoreName, fTitle)
                                                          g.DrawString(StoreName, fTitle, Brushes.Black,
                                                                       New RectangleF(leftX, Y, pageW, titleSize.Height), fmtC)
                                                          Y += CInt(titleSize.Height) + 5

                                                          If Not String.IsNullOrEmpty(ShopPhone) Then centerLine("هاتف: " & ShopPhone, f11)
                                                          If Not String.IsNullOrEmpty(ShopAddress) Then centerLine("العنوان: " & ShopAddress, f11)
                                                          If Not String.IsNullOrEmpty(TaxNumber) Then centerLine("الرقم الضريبي: " & TaxNumber, f11)
                                                          Y += 5

                                                          separator()
                                                          rightLine("نوع الفاتورة : فاتورة مبيعات", f11)
                                                          rightLine("رقم الفاتورة : " & invoiceID, f11)
                                                          rightLine("التاريخ : " & DateTime.Now.ToString("yyyy/MM/dd  hh:mm:ss tt"), f11)
                                                          rightLine("الكاشير : " & data.UserName, f11)
                                                          rightLine("كود العميل : " & data.CustomerCode, f11)
                                                          rightLine("اسم العميل : " & data.CustomerName, f11)
                                                          separator()

                                                          ' هامش أمان من حافة الورق اليمنى (طابعات POS-80C وغيرها)
                                                          Const safeRightInset As Integer = 28
                                                          Dim tableW As Integer = pageW - safeRightInset
                                                          Dim colTW = CInt(tableW * 0.2)
                                                          Dim colPW = CInt(tableW * 0.16)
                                                          Dim colQW = CInt(tableW * 0.13)
                                                          Dim colNW = tableW - (colTW + colPW + colQW)
                                                          Dim xT As Integer = leftX
                                                          Dim xP As Integer = xT + colTW
                                                          Dim xQ As Integer = xP + colPW
                                                          Dim xN As Integer = xQ + colQW
                                                          Dim tableY As Integer = Y
                                                          Dim headerH As Integer = 28

                                                          g.DrawString("المنتج", fBold, Brushes.Black, New RectangleF(xN, Y, colNW, headerH), fmtC)
                                                          g.DrawString("الكمية", fBold, Brushes.Black, New RectangleF(xQ, Y, colQW, headerH), fmtC)
                                                          g.DrawString("السعر", fBold, Brushes.Black, New RectangleF(xP, Y, colPW, headerH), fmtC)
                                                          g.DrawString("الإجمالي", fBold, Brushes.Black, New RectangleF(xT, Y, colTW, headerH), fmtC)
                                                          Y += headerH

                                                          ' padding داخلي لخلية المنتج عشان حروف أول الاسم تطبع كاملة
                                                          Const namePadRight As Integer = 8
                                                          Const namePadLeft As Integer = 4
                                                          Dim nameTextWidth As Integer = colNW - namePadRight - namePadLeft
                                                          If nameTextWidth < 20 Then nameTextWidth = colNW
                                                          For Each line In data.InvoiceItems
                                                              Dim cleanName As String = If(line.ProductName, "").Replace(vbCr, " ").Replace(vbLf, " ").Trim()
                                                              Dim measured As SizeF = g.MeasureString(cleanName, f11, nameTextWidth, fmtWrap)
                                                              Dim h As Integer = Math.Max(28, CInt(measured.Height) + 10)
                                                              g.DrawString(cleanName, f11, Brushes.Black,
                                                                  New RectangleF(xN + namePadLeft, Y + 4, nameTextWidth, h - 8), fmtWrap)
                                                              g.DrawString(line.Quantity.ToString("0.##"), f11, Brushes.Black,
                                                                  New RectangleF(xQ, Y, colQW, h), fmtC)
                                                              g.DrawString(FormatNumber(line.SalePrice, 2), f11, Brushes.Black,
                                                                  New RectangleF(xP, Y, colPW, h), fmtC)
                                                              g.DrawString(FormatNumber(line.Total, 2), f11, Brushes.Black,
                                                                  New RectangleF(xT, Y, colTW, h), fmtC)
                                                              Y += h
                                                              g.DrawLine(linePen, leftX, Y, leftX + tableW, Y)
                                                          Next

                                                          Dim tableEndY As Integer = Y
                                                          g.DrawLine(linePen, leftX, tableY, leftX + tableW, tableY)
                                                          g.DrawLine(linePen, leftX, tableY + headerH, leftX + tableW, tableY + headerH)
                                                          g.DrawLine(linePen, xT, tableY, xT, tableEndY)
                                                          g.DrawLine(linePen, xP, tableY, xP, tableEndY)
                                                          g.DrawLine(linePen, xQ, tableY, xQ, tableEndY)
                                                          g.DrawLine(linePen, xN, tableY, xN, tableEndY)
                                                          g.DrawLine(linePen, xN + colNW, tableY, xN + colNW, tableEndY)

                                                          separator()
                                                          If Val(data.Discount) > 0 Then
                                                              rightLine("إجمالي قبل الخصم : " & data.TotalRequired, fBold)
                                                              rightLine("الخصم : " & data.Discount, fBold)
                                                              rightLine("الصافي : " & data.TotalAfterDiscount, fBold)
                                                          Else
                                                              rightLine("إجمالي الفاتورة : " & data.TotalRequired, fBold)
                                                          End If
                                                          rightLine("المدفوع : " & data.Paid, fBold)

                                                          If data.CustomerCode <> "1" Then
                                                              Dim prevBal As Decimal = 0D
                                                              Dim invRem As Decimal = 0D
                                                              Decimal.TryParse(data.CustomerBalance, prevBal)
                                                              Decimal.TryParse(data.Remaining, invRem)
                                                              rightLine("رصيد سابق : " & prevBal.ToString("0.00"), fBold)
                                                              rightLine("متبقي الفاتورة : " & invRem.ToString("0.00"), fBold)
                                                              rightLine("إجمالي الحساب : " & (prevBal + invRem).ToString("0.00"), fBold)
                                                          End If

                                                          separator()
                                                          'Using qr As Bitmap = GenerateQRCode(invoiceID.ToString())
                                                          '    g.DrawImage(qr, leftX + (pageW - qr.Width) \ 2, Y)
                                                          '    Y += qr.Height + 5
                                                          'End Using

                                                          centerLine(FooterMsg, fBold)
                                                          e.HasMorePages = False
                                                          separator()

                                                      End Using : End Using : End Using : End Using
                                      End Sub

                            AddHandler pd.PrintPage, handler
                            Try
                                If ShouldShowPrintPreview() Then
                                    ShowPrintPreviewDialog(pd, "معاينة الفاتورة - استيل 1")
                                Else
                                    pd.Print()
                                End If
                            Finally
                                RemoveHandler pd.PrintPage, handler
                            End Try
                        End Using
                    End Using
                End Using
            End Using
        Finally
            If logoImg IsNot Nothing Then logoImg.Dispose()
        End Try
    End Sub

    ' هل المستخدم مفعل معاينة قبل الطباعة؟
    Private Function ShouldShowPrintPreview() As Boolean
        Try
            Dim v = SettingsManager.GetSetting("PrintPreview")
            Return Not String.IsNullOrEmpty(v) AndAlso v.Trim().ToLower() = "true"
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' فتح نافذة معاينة الفاتورة فقط - بدون أي طباعة فعلية.
    ''' المستخدم يقدر يطبع من زر الطباعة داخل نافذة المعاينة لو حب.
    ''' </summary>
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
                        ' عرض النافذة - لن تُرسل أي طباعة للطابعة إلا لو ضغط المستخدم زر الطابعة داخل النافذة
                        dlg.ShowDialog()
                    Finally
                        dlg.Dispose()
                    End Try
                Catch ex As Exception
                    MessageBox.Show("خطأ في عرض المعاينة: " & ex.Message,
                                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub

        Try
            If Me.IsHandleCreated AndAlso Me.InvokeRequired Then
                Me.Invoke(showPreview)
            Else
                showPreview.Invoke()
            End If
        Catch ex As Exception
            ' Fallback - شغّل بدون Invoke
            showPreview.Invoke()
        End Try
    End Sub

    ' استيل 2: تصميم الهيدر شبيه فاتورة المصطفى (لوجو + اسم على اليمين، بيانات الفاتورة على اليسار)
    Private Sub PrintInvoice80mm_Style2(invoiceID As Integer, data As PrintData)
        Dim StoreName As String = SettingsManager.GetSetting("ShopName")
        Dim ShopPhone As String = SettingsManager.GetSetting("ShopPhone")
        Dim ShopPhone2 As String = SettingsManager.GetSetting("ShopPhone2")
        Dim ShopAddress As String = SettingsManager.GetSetting("ShopAddress")
        Dim TaxNumber As String = SettingsManager.GetSetting("TaxNumber")
        Dim FooterMsg As String = SettingsManager.GetSetting("FooterText")
        Dim DeliveryText As String = SettingsManager.GetSetting("DeliveryText")
        If String.IsNullOrEmpty(DeliveryText) Then DeliveryText = "يوجد توصيل للمنازل"

        If String.IsNullOrEmpty(StoreName) Then StoreName = "سوبر ماركت الحمد والرضا"
        If String.IsNullOrEmpty(FooterMsg) Then FooterMsg = "❤ شكراً لتعاملكم معنا"

        Dim thermalPrinter As String = SettingsManager.GetSetting("ThermalPrinterName")
        Dim logoPath As String = SettingsManager.GetSetting("LogoPath")

        ' احترام إعداد "طباعة اللوجو مع الفاتورة"
        Dim printLogoSetting As String = SettingsManager.GetSetting("PrintLogo")
        Dim shouldPrintLogo As Boolean = String.IsNullOrEmpty(printLogoSetting) OrElse printLogoSetting.Trim().ToLower() = "true"

        Dim logoImg As System.Drawing.Image = Nothing
        Try
            If shouldPrintLogo AndAlso Not String.IsNullOrEmpty(logoPath) AndAlso IO.File.Exists(logoPath) Then
                logoImg = System.Drawing.Image.FromFile(logoPath)
            End If
        Catch
        End Try

        Try
            ' خط أصغر بسيط مقارنة باستيل 1
            Using fBrand As New Font("Arial", 13, FontStyle.Bold)
                Using fBold As New Font("Arial", 11, FontStyle.Bold)
                    Using fTotalLarge As New Font("Arial", 13, FontStyle.Bold)
                        Using f10 As New Font("Arial", 10, FontStyle.Bold)
                            Using f9 As New Font("Arial", 10, FontStyle.Bold)
                                Using pd As New PrintDocument()
                                    If Not String.IsNullOrEmpty(thermalPrinter) Then
                                        pd.PrinterSettings.PrinterName = thermalPrinter
                                    End If
                                    pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 5000)
                                    pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

                                    Dim handler As PrintPageEventHandler = Nothing
                                    handler = Sub(sender, e)
                                                  Dim g = e.Graphics
                                                  Dim Y As Integer = e.MarginBounds.Top
                                                  Dim pageW As Integer = e.MarginBounds.Width
                                                  Dim leftX As Integer = e.MarginBounds.Left

                                                  Using fmtC As New StringFormat() With {
                                                  .Alignment = StringAlignment.Center,
                                                  .LineAlignment = StringAlignment.Center,
                                                  .FormatFlags = StringFormatFlags.DirectionRightToLeft}
                                                      Using fmtR As New StringFormat() With {
                                                      .Alignment = StringAlignment.Far,
                                                      .LineAlignment = StringAlignment.Center,
                                                      .FormatFlags = StringFormatFlags.DirectionRightToLeft}
                                                          Using fmtWrap As New StringFormat() With {
                                                          .Alignment = StringAlignment.Near,
                                                          .LineAlignment = StringAlignment.Center,
                                                          .FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.NoClip}
                                                              Using linePen As New Pen(Color.Black, 1)

                                                                  Dim centerLine = Sub(t As String, f As Font)
                                                                                       g.DrawString(t, f, Brushes.Black,
                                                                                                New RectangleF(leftX, Y, pageW, f.Height + 5), fmtC)
                                                                                       Y += f.Height + 5
                                                                                   End Sub

                                                                  Dim rightLine = Sub(t As String, f As Font)
                                                                                      g.DrawString(t, f, Brushes.Black,
                                                                                               New RectangleF(leftX, Y, pageW, f.Height + 4), fmtR)
                                                                                      Y += f.Height + 4
                                                                                  End Sub

                                                                  Dim separator = Sub()
                                                                                      g.DrawLine(linePen, leftX, Y, leftX + pageW, Y)
                                                                                      Y += 6
                                                                                  End Sub

                                                                  ' هامش أمان من حافة الورق اليمنى (نطبقه على الجدول وعلى صف اليمين كله)
                                                                  Const safeRightInset As Integer = 28
                                                                  Dim usableW As Integer = pageW - safeRightInset

                                                                  ' rightLine المعدّل: محاذاة اليمين داخل عرض آمن (مش لحافة الورق)
                                                                  Dim rightLineSafe = Sub(t As String, f As Font)
                                                                                          g.DrawString(t, f, Brushes.Black,
                                                                                                   New RectangleF(leftX, Y, usableW, f.Height + 4), fmtR)
                                                                                          Y += f.Height + 4
                                                                                      End Sub

                                                                  ' ─── الهيدر على غرار فاتورة المصطفى ───
                                                                  ' عمود اليمين (بصرياً): اللوجو + اسم المحل
                                                                  ' عمود الشمال (بصرياً): اسم العميل، رقم الفاتورة، التاريخ، المستخدم
                                                                  Dim logoColW As Integer = CInt(usableW * 0.32)         ' عمود اللوجو (يمين الورق)
                                                                  Dim infoColW As Integer = usableW - logoColW           ' عمود البيانات (شمال الورق)
                                                                  Dim infoColX As Integer = leftX                        ' x لعمود البيانات
                                                                  Dim logoColX As Integer = leftX + infoColW             ' x لعمود اللوجو
                                                                  Dim logoY As Integer = Y    ' Y لرسم اللوجو
                                                                  Dim infoY As Integer = Y    ' Y لرسم البيانات

                                                                  ' (يمين): لوجو + اسم المحل تحته
                                                                  If logoImg IsNot Nothing Then
                                                                      Dim logoWidth As Integer = Math.Min(95, logoColW - 6)
                                                                      Dim logoHeight As Integer = CInt(logoWidth * logoImg.Height / logoImg.Width)
                                                                      Dim logoXPos As Integer = logoColX + (logoColW - logoWidth) \ 2
                                                                      g.DrawImage(logoImg, logoXPos, logoY, logoWidth, logoHeight)
                                                                      logoY += logoHeight + 4
                                                                  End If

                                                                  ' اسم المحل فوق مع فرق بسيط من اللوجو
                                                                  logoY += 5

                                                                  Dim brandFont As Font = fBrand
                                                                  Dim brandMeasure As SizeF = g.MeasureString(StoreName, brandFont)
                                                                  If brandMeasure.Width > logoColW - 4 Then
                                                                      brandFont = New Font("Arial", 9, FontStyle.Bold)
                                                                  End If
                                                                  Dim brandH As Integer = brandFont.Height + 4
                                                                  g.DrawString(StoreName, brandFont, Brushes.Black,
                                                                           New RectangleF(logoColX, logoY, logoColW, brandH), fmtC)
                                                                  logoY += brandH

                                                                  ' (شمال): بيانات العميل/الفاتورة (label : value) بمحاذاة يمنى
                                                                  ' [إصلاح التداخل] نقيس الارتفاع الفعلي للنص مع الالتفاف ونضيف هوامش رأسية
                                                                  ' حتى لا يتداخل أي سطر (مثل سطر التاريخ) مع السطر التالي، ويُطبَّق هذا
                                                                  ' تلقائياً على كل الحقول (اسم العميل، الفاتورة، التاريخ، المستخدم، الدفع)
                                                                  ' كما يتمدّد الصف رأسياً إذا كان النص طويلاً (التفاف لأكثر من سطر).
                                                                  Dim fieldPadX As Integer = 6
                                                                  Dim fieldPadY As Integer = 5
                                                                  Dim fieldGap As Integer = 3
                                                                  Dim drawRightField = Sub(label As String, value As String)
                                                                                           Dim txt As String = label & " : " & If(value, "").Trim()
                                                                                           Dim availW As Integer = infoColW - fieldPadX * 2
                                                                                           If availW < 20 Then availW = infoColW
                                                                                           ' قياس الارتفاع الفعلي مع الالتفاف داخل عرض العمود
                                                                                           Dim measured As SizeF = g.MeasureString(txt, f10, availW, fmtR)
                                                                                           Dim textH As Integer = Math.Max(f10.Height, CInt(Math.Ceiling(measured.Height)))
                                                                                           Dim rowH As Integer = textH + fieldPadY * 2
                                                                                           g.DrawString(txt, f10, Brushes.Black,
                                                                                                    New RectangleF(infoColX + fieldPadX, infoY + fieldPadY, availW, textH), fmtR)
                                                                                           infoY += rowH
                                                                                           ' خط فاصل أسفل الحقل مع فجوة صغيرة قبل الحقل التالي
                                                                                           g.DrawLine(linePen, infoColX, infoY, infoColX + infoColW, infoY)
                                                                                           infoY += fieldGap
                                                                                       End Sub

                                                                  drawRightField("اسم العميل", data.CustomerName)
                                                                  drawRightField("فاتورة رقم", invoiceID.ToString())
                                                                  drawRightField("التاريخ", DateTime.Now.ToString("yyyy/MM/dd hh:mm tt"))
                                                                  drawRightField("المستخدم", data.UserName)
                                                                  drawRightField("طريقة الدفع", data.PaymentMethod)

                                                                  ' خط رأسي يفصل بين عمودَي الهيدر
                                                                  g.DrawLine(linePen, logoColX, Y, logoColX, Math.Max(logoY, infoY))

                                                                  ' خط أفقي تحت الهيدر
                                                                  Y = Math.Max(infoY, logoY) + 4
                                                                  g.DrawLine(linePen, leftX, Y, leftX + usableW, Y)
                                                                  Y += 6

                                                                  ' العنوان والهواتف (سطر كامل)
                                                                  Dim phones As String = ShopPhone
                                                                  If Not String.IsNullOrEmpty(ShopPhone2) Then
                                                                      phones = If(String.IsNullOrEmpty(phones), ShopPhone2, ShopPhone & " - " & ShopPhone2)
                                                                  End If
                                                                  If Not String.IsNullOrEmpty(ShopAddress) Then centerLine(ShopAddress, f9)
                                                                  If Not String.IsNullOrEmpty(phones) Then centerLine(phones, f9)
                                                                  If Not String.IsNullOrEmpty(TaxNumber) Then centerLine("الرقم الضريبي: " & TaxNumber, f9)

                                                                  separator()

                                                                  ' ─── جدول المنتجات بدون عمود رقم ───
                                                                  ' الأعمدة من اليسار البصري لليمين البصري:
                                                                  ' [جمالى] [السعر] [الكمية] [الصنف]
                                                                  Dim tableW As Integer = usableW
                                                                  Dim colTW = CInt(tableW * 0.22)       ' إجمالي
                                                                  Dim colPW = CInt(tableW * 0.18)      ' السعر
                                                                  Dim colQW = CInt(tableW * 0.16)      ' الكمية
                                                                  Dim colNW = tableW - (colTW + colPW + colQW)  ' الصنف
                                                                  Dim xT As Integer = leftX
                                                                  Dim xP As Integer = xT + colTW
                                                                  Dim xQ As Integer = xP + colPW
                                                                  Dim xN As Integer = xQ + colQW
                                                                  Dim tableY As Integer = Y
                                                                  Dim headerH As Integer = 26

                                                                  g.DrawString("الصنف", fBold, Brushes.Black, New RectangleF(xN, Y, colNW, headerH), fmtC)
                                                                  g.DrawString("الكمية", fBold, Brushes.Black, New RectangleF(xQ, Y, colQW, headerH), fmtC)
                                                                  g.DrawString("السعر", fBold, Brushes.Black, New RectangleF(xP, Y, colPW, headerH), fmtC)
                                                                  g.DrawString("إجمالي", fBold, Brushes.Black, New RectangleF(xT, Y, colTW, headerH), fmtC)
                                                                  Y += headerH

                                                                  Const namePadRight As Integer = 8
                                                                  Const namePadLeft As Integer = 4
                                                                  Dim nameTextWidth As Integer = colNW - namePadRight - namePadLeft
                                                                  If nameTextWidth < 20 Then nameTextWidth = colNW
                                                                  For Each line In data.InvoiceItems
                                                                      Dim cleanName As String = If(line.ProductName, "").Replace(vbCr, " ").Replace(vbLf, " ").Trim()
                                                                      Dim measured As SizeF = g.MeasureString(cleanName, f10, nameTextWidth, fmtWrap)
                                                                      Dim h As Integer = Math.Max(24, CInt(measured.Height) + 8)
                                                                      g.DrawString(cleanName, f10, Brushes.Black,
                                                                      New RectangleF(xN + namePadLeft, Y + 3, nameTextWidth, h - 6), fmtWrap)
                                                                      g.DrawString(line.Quantity.ToString("0.##"), f10, Brushes.Black,
                                                                      New RectangleF(xQ, Y, colQW, h), fmtC)
                                                                      g.DrawString(FormatNumber(line.SalePrice, 2), f10, Brushes.Black,
                                                                      New RectangleF(xP, Y, colPW, h), fmtC)
                                                                      g.DrawString(FormatNumber(line.Total, 2), f10, Brushes.Black,
                                                                      New RectangleF(xT, Y, colTW, h), fmtC)
                                                                      Y += h
                                                                      g.DrawLine(linePen, leftX, Y, leftX + tableW, Y)
                                                                  Next

                                                                  Dim tableEndY As Integer = Y
                                                                  g.DrawLine(linePen, leftX, tableY, leftX + tableW, tableY)
                                                                  g.DrawLine(linePen, leftX, tableY + headerH, leftX + tableW, tableY + headerH)
                                                                  g.DrawLine(linePen, xT, tableY, xT, tableEndY)
                                                                  g.DrawLine(linePen, xP, tableY, xP, tableEndY)
                                                                  g.DrawLine(linePen, xQ, tableY, xQ, tableEndY)
                                                                  g.DrawLine(linePen, xN, tableY, xN, tableEndY)
                                                                  g.DrawLine(linePen, xN + colNW, tableY, xN + colNW, tableEndY)

                                                                  separator()
                                                                  If Val(data.Discount) > 0 Then
                                                                      centerLine("إجمالي قبل الخصم : " & data.TotalRequired, fTotalLarge)
                                                                      centerLine("الخصم           : " & data.Discount, fTotalLarge)
                                                                      centerLine("الصافي          : " & data.TotalAfterDiscount, fTotalLarge)
                                                                  Else
                                                                      centerLine("إجمالي الفاتورة : " & data.TotalRequired, fTotalLarge)
                                                                  End If
                                                                  centerLine("المدفوع         : " & data.Paid, fTotalLarge)
                                                                  centerLine("المتبقي         : " & data.Remaining, fTotalLarge)

                                                                  If data.CustomerCode <> "1" Then
                                                                      Dim prevBal As Decimal = 0D
                                                                      Dim invRem As Decimal = 0D
                                                                      Decimal.TryParse(data.CustomerBalance, prevBal)
                                                                      Decimal.TryParse(data.Remaining, invRem)
                                                                      rightLineSafe("رصيد سابق : " & prevBal.ToString("0.00"), fBold)
                                                                      rightLineSafe("متبقي الفاتورة : " & invRem.ToString("0.00"), fBold)
                                                                      rightLineSafe("إجمالي الحساب : " & (prevBal + invRem).ToString("0.00"), fBold)
                                                                  End If

                                                                  separator()
                                                                  centerLine("* " & FooterMsg & " *", fBold)
                                                                  If Not String.IsNullOrEmpty(DeliveryText) Then
                                                                      centerLine("** " & DeliveryText & " **", fBold)
                                                                  End If
                                                                  e.HasMorePages = False
                                                                  separator()

                                                              End Using : End Using : End Using : End Using
                                              End Sub

                                    AddHandler pd.PrintPage, handler
                                    Try
                                        If ShouldShowPrintPreview() Then
                                            ShowPrintPreviewDialog(pd, "معاينة الفاتورة - استيل 2")
                                        Else
                                            pd.Print()
                                        End If
                                    Finally
                                        RemoveHandler pd.PrintPage, handler
                                    End Try
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Finally
            If logoImg IsNot Nothing Then logoImg.Dispose()
        End Try
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
                Using cmd As New SqlCommand(
                    "SELECT User_Name FROM Users_TBL WHERE User_ID=@id", cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Session.CurrentUserID
                    lbl_user_name.Text = Convert.ToString(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            ShowError("خطأ أثناء التحقق من المستخدم: " & ex.Message)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' بقية الأحداث والميزات (محافظ على جميع الوظائف الأصلية)
    '══════════════════════════════════════════════════════════════
    Private Sub btn_Sales_Returns_Click(sender As Object, e As EventArgs) _
        Handles btn_Sales_Returns.Click
        OpenSingleForm(Of Sales_Returns)()
    End Sub

    Private Sub btnToggleDiscount_Click(sender As Object, e As EventArgs) _
        Handles btnToggleDiscount.Click
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

    Private Sub btnToggleScanner_Click(sender As Object, e As EventArgs) _
        Handles btnToggleScanner.Click
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
        ' فتح القفل بعد مسح المنتجات لبدء فاتورة جديدة
        UnlockInvoice()
    End Sub

    Private Sub txt_Customer_Balance_TextChanged(sender As Object, e As EventArgs) _
        Handles txt_Customer_Balance.TextChanged
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
        If _autoSave Then btnSaveInvoice.PerformClick()
    End Sub

    Private Sub check_Stats_CheckedChanged(sender As Object, e As EventArgs) _
        Handles check_Stats.CheckedChanged
        _isSendToWhatsApp = check_Stats.Checked
    End Sub

    Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs) _
        Handles Guna2ToggleSwitch1.CheckedChanged
        _autoSave = Guna2ToggleSwitch1.Checked
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
        If Guna2TextBox1.TextLength = 0 OrElse Guna2TextBox2.TextLength = 0 OrElse
           txt_free_profit.TextLength = 0 Then
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

        ' [تحسين]: دالة مساعدة محلية لضبط قيم الخلايا بأمان
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

    Private Sub grpCustomerInfo_Click(sender As Object, e As EventArgs) Handles grpCustomerInfo.Click
    End Sub

    '══════════════════════════════════════════════════════════════
    ' دوال مساعدة مشتركة
    '══════════════════════════════════════════════════════════════
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

    Private Sub ShowInfo(msg As String)
        MessageBox.Show(msg, "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class