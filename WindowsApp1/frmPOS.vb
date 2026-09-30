Public Class frmPOS
    Private _repo As New POSRepository(DBModule.ConnectionString)

    Public Enum OrderType
        Takeaway = 1
        DineIn = 2
        Delivery = 3
    End Enum

    Public Property CurrentOrderType As OrderType = OrderType.Takeaway
    Public Property SelectedTableID As Integer? = Nothing
    Public Property SelectedTableName As String = ""
    Public Property SelectedDriverID As Integer? = Nothing
    Public Property SelectedDriverName As String = ""
    Public Property DeliveryFee As Decimal = 0
    Public Property IsDineInServiceFeePercent As Boolean = False
    Public Property DineInServiceFee As Decimal = 0
    Public Property TaxAmount As Decimal = 0
    Public Property CurrentCustomer As CustomerModel
    Public Property CurrentReservationDeposit As Decimal = 0
    Public Property CurrentReservationID As Integer? = Nothing
    Private _currentPendingInvoiceID As Integer? = Nothing
    Private _currentPendingInvoiceNumber As String = ""
    Private _recalledOriginalItems As New List(Of InvoiceDetailModel)()

    ' متغيرات الطباعة وإعادة الطباعة وعمليات الطاولات
    Private _lastSavedInvoice As InvoiceModel = Nothing
    Private _lastSavedCustomerName As String = ""
    Private _lastSavedTableName As String = ""
    Private _lastSavedDriverName As String = ""
    Private _tablesContextMenu As ContextMenuStrip

    ' متغيرات التحكم في شبكة الفئات والأصناف
    Private _categoryColumns As Integer = 4
    Private _categoryRows As Integer = 2
    Private _selectedCategoryID As Integer = 0
    Private _selectedCategoryColor As Color = Color.FromArgb(94, 148, 255)
    Private _categoryButtons As New List(Of Guna.UI2.WinForms.Guna2Button)

    Private ReadOnly Property CurrencySymbol As String
        Get
            Return SettingsManager.GetSettingOrDefault(SettingsKeys.Currency, "ج.م")
        End Get
    End Property

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DBModule.EnsureKitchenCommentsTable()
        Catch exComments As Exception
            Logger.LogError("frmPOS_Load.EnsureKitchenCommentsTable", exComments)
        End Try

        If _repo Is Nothing Then
            _repo = New POSRepository(DBModule.ConnectionString)
        End If
        EnableTouchScrolling(flpProducts)
        EnableTouchScrolling(flpCategories)
        AddHandler flpProducts.Resize, Sub() UpdateProductButtonsLayout()
        SetupCategoryControlsToolbar()
        LoadCategories()
        datagridviewsetup(dgvInvoice)
        SetupInvoiceGrid()
        CalculatePOSGrandTotal()
        Dim Drag0 As FormDragHelper = New FormDragHelper(Me, panelHeader)
        Dim Drag1 As FormDragHelper = New FormDragHelper(Me, Guna2HtmlLabel1)
        Dim Drag2 As FormDragHelper = New FormDragHelper(Me, Label8)
        Dim Drag3 As FormDragHelper = New FormDragHelper(Me, lblUser_fullName)
        Dim Drag4 As FormDragHelper = New FormDragHelper(Me, lblCurrentShift)
        Dim Drag5 As FormDragHelper = New FormDragHelper(Me, Label4)
        Dim Drag6 As FormDragHelper = New FormDragHelper(Me, Label10)
        Dim Drag7 As FormDragHelper = New FormDragHelper(Me, lblDateTime)
        If Session.CurrentUserfullName IsNot Nothing AndAlso String.IsNullOrEmpty(Session.CurrentUserfullName) = False Then
            lblUser_fullName.Text = Session.CurrentUserfullName
        End If

        Timer1.Start()
        btnTakeaway.Checked = True
        CurrentOrderType = OrderType.Takeaway

        ApplyDefaultPOSSettings()
        ' تحديث رقم الفاتورة القادمة
        UpdateNextInvoiceNumber()

        Me.KeyPreview = True
        SetupTablesContextMenu()
        ApplyPOSTheme()
        AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnPOSThemeChanged
    End Sub

    Private Sub frmPOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnPOSThemeChanged
    End Sub

    Private Sub OnPOSThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
        ApplyPOSTheme(palette)
    End Sub

    ''' <summary>
    ''' تطبيق سمة احترافية فائقة التباين والوضوح لشاشة الكاشير والمبيعات (POS)
    ''' </summary>
    Public Sub ApplyPOSTheme(Optional palette As ThemePalette = Nothing)
        Try
            If palette Is Nothing Then
                palette = ThemeManager.Instance.CurrentPalette
            End If
            If palette Is Nothing Then Return

            Dim isDark As Boolean = (palette.ThemeType = AppTheme.Dark)

            Me.SuspendLayout()
            Try
                ' 1. خلفية النافذة الرئيسية والحاويات
                Me.BackColor = palette.Background
                Guna2Panel2.FillColor = palette.Background
                Guna2Panel3.FillColor = palette.Surface
                Guna2Panel3.BorderColor = palette.Border

                ' 2. الشريط العلوي (Header)
                panelHeader.FillColor = palette.SurfaceHeader
                panelHeader.BackColor = Color.Transparent
                lblDateTime.ForeColor = Color.White
                lblUser_fullName.ForeColor = Color.White
                lblCurrentShift.ForeColor = Color.White
                Guna2HtmlLabel1.ForeColor = Color.White
                Label4.ForeColor = Color.FromArgb(203, 213, 225)
                Label8.ForeColor = Color.FromArgb(203, 213, 225)
                Label10.ForeColor = Color.FromArgb(203, 213, 225)

                ' 3. شريط رقم الفاتورة والأصناف أعلى جدول المبيعات
                Guna2Panel9.FillColor = palette.SurfaceSecondary
                Guna2Panel9.BorderColor = palette.Border
                Label1.ForeColor = palette.TextPrimary
                Label2.ForeColor = palette.TextSecondary
                lblInvoiceNumber.BackColor = palette.InfoSubtleBackground
                lblInvoiceNumber.ForeColor = palette.InfoSubtleForeground
                lblInvoiceNumber.BorderStyle = BorderStyle.None

                ' 4. شريط نوع الطلب وأزرار التبديل
                Guna2Panel12.FillColor = palette.SurfaceSecondary
                lblOrderTypeStatus.ForeColor = palette.TextPrimary

                Dim summaryBorder As Color = palette.Border
                Dim orderBtnInactiveFill As Color = palette.SurfaceSecondary
                Dim orderBtnInactiveFore As Color = palette.TextSecondary
                Dim orderBtnActiveFill As Color = palette.Primary
                For Each btn As Guna.UI2.WinForms.Guna2Button In {btnTakeaway, btnDineIn, btnDelivery}
                    btn.CheckedState.FillColor = orderBtnActiveFill
                    btn.CheckedState.ForeColor = Color.White
                    btn.FillColor = orderBtnInactiveFill
                    btn.ForeColor = orderBtnInactiveFore
                    btn.BorderColor = summaryBorder
                    btn.BorderThickness = 1
                Next

                ' 5. جدول الفاتورة
                ThemeHelper.ApplyDataGridViewTheme(dgvInvoice, palette)

                ' 6. شبكة ملخص الإجماليات (المجموع، التوصيل، خدمة الصالة، الضريبة)
                Dim titleBg As Color = palette.SurfaceSecondary
                Dim titleFg As Color = palette.TextSecondary
                Dim valueBg As Color = palette.InputBackground
                Dim valueFg As Color = palette.TextPrimary

                ' المجموع
                Guna2Panel16.FillColor = valueBg
                Label12.BackColor = titleBg
                Label12.ForeColor = titleFg
                lblSubTotal.BackColor = valueBg
                lblSubTotal.ForeColor = valueFg

                ' التوصيل
                Guna2Panel17.FillColor = valueBg
                Label13.BackColor = titleBg
                Label13.ForeColor = titleFg
                lblDeliveryFee.BackColor = valueBg
                lblDeliveryFee.ForeColor = valueFg

                ' خدمة الصالة
                Guna2Panel18.FillColor = valueBg
                Label15.BackColor = titleBg
                Label15.ForeColor = titleFg
                lblDineInFee.BackColor = valueBg
                lblDineInFee.ForeColor = valueFg

                ' الضريبة
                Guna2Panel19.FillColor = valueBg
                Label17.BackColor = titleBg
                Label17.ForeColor = titleFg
                lblTax.BackColor = valueBg
                lblTax.ForeColor = valueFg

                ' الإجمالي النهائي
                Guna2Panel24.FillColor = palette.SuccessSubtleBackground
                Guna2Panel26.FillColor = palette.SuccessSubtleBackground
                Label25.BackColor = Color.Transparent
                Label25.ForeColor = palette.SuccessSubtleForeground
                lblGrandTotal.BackColor = Color.Transparent
                lblGrandTotal.ForeColor = If(isDark, palette.SuccessSubtleForeground, palette.Success)

                ' 7. صف العميل
                Guna2Panel21.FillColor = palette.Surface
                Label6.BackColor = titleBg
                Label6.ForeColor = palette.TextPrimary
                txtCustomer.FillColor = palette.InputBackground
                txtCustomer.ForeColor = palette.InputForeground
                txtCustomer.BorderColor = summaryBorder
                btnSelectCustomer.FillColor = palette.ButtonSecondaryBackground
                btnSelectCustomer.ForeColor = palette.ButtonSecondaryForeground

                ' 8. أزرار الإجراءات السفلية
                btnPay.FillColor = palette.Success
                btnPay.ForeColor = palette.SuccessText
                btnHoldInvoice.ForeColor = Color.White
                UpdateHoldButtonText()
                btntables.FillColor = palette.AccentIndigo
                btntables.ForeColor = palette.AccentIndigoText
                btnPendingInvoices.FillColor = palette.Primary
                btnPendingInvoices.ForeColor = palette.TextOnPrimary
                btnDeleteRow.FillColor = palette.Danger
                btnDeleteRow.ForeColor = palette.DangerText
                btnclear.FillColor = palette.ButtonSecondaryBackground
                btnclear.ForeColor = palette.ButtonSecondaryForeground

                ' 9. شريط أدوات شبكة الفئات (الأعمدة والصفوف)
                pnlCategoryGridToolbar.FillColor = palette.SurfaceSecondary
                pnlCategoryGridToolbar.BorderColor = summaryBorder
                lblRowTitle.ForeColor = titleFg
                lblColTitle.ForeColor = titleFg
                lblRowValue.ForeColor = palette.TextPrimary
                lblColValue.ForeColor = palette.TextPrimary

                Dim btnGridFill As Color = palette.ButtonSecondaryBackground
                Dim btnGridFore As Color = palette.ButtonSecondaryForeground
                btnIncRow.FillColor = btnGridFill : btnIncRow.ForeColor = btnGridFore : btnIncRow.BorderThickness = 1 : btnIncRow.BorderColor = summaryBorder
                btnDecRow.FillColor = btnGridFill : btnDecRow.ForeColor = btnGridFore : btnDecRow.BorderThickness = 1 : btnDecRow.BorderColor = summaryBorder
                btnIncCol.FillColor = btnGridFill : btnIncCol.ForeColor = btnGridFore : btnIncCol.BorderThickness = 1 : btnIncCol.BorderColor = summaryBorder
                btnDecCol.FillColor = btnGridFill : btnDecCol.ForeColor = btnGridFore : btnDecCol.BorderThickness = 1 : btnDecCol.BorderColor = summaryBorder

                ' 10. حاويات الأصناف والفئات
                flpProducts.BackColor = palette.BackgroundSecondary
                flpCategories.BackColor = palette.BackgroundSecondary
                Dim bgSpacerColor As Color = palette.BackgroundSecondary
                Guna2Panel5.BackColor = bgSpacerColor
                Guna2Panel6.BackColor = bgSpacerColor
                Guna2Panel7.BackColor = bgSpacerColor
                Guna2Panel8.BackColor = bgSpacerColor

                ' 11. إعادة رسم الأصناف المفتوحة حالياً لتتوافق مع السمة (فقط إذا كانت الأقسام محملة بالفعل)
                If _categoryButtons IsNot Nothing AndAlso _categoryButtons.Count > 0 Then
                    LoadProducts(_selectedCategoryID)
                End If

            Finally
                Me.ResumeLayout(True)
            End Try
        Catch ex As Exception
            Logger.LogError("ApplyPOSTheme", ex)
        End Try
    End Sub

    Private Sub frmPOS_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not CheckAndEnsureActiveShift() Then
            ' لو مفيش وردية والكاشير رفض يفتح وردية أو قفل الشاشة بدون فتح وردية
            ' نستخدم BeginInvoke حتى تكتمل جميع الأحداث المتعلقة بظهور الفورم (مثل Guna2 ShadowForm) قبل الإغلاق
            Me.BeginInvoke(Sub() Me.Close())
        Else
            If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                lblCurrentShift.Text = ShiftSession.CurrentShift.WorkShiftName
            End If
        End If
    End Sub
    Private Sub ApplyDefaultPOSSettings()
        Try
            ' =========================================================
            ' 1. تعيين نوع الطلب وضبط ظهور الأزرار وفق الإعدادات
            ' =========================================================
            Dim enableTakeaway As Boolean = SettingsManager.GetBoolSetting(SettingsKeys.SalesEnableTakeaway, True)
            Dim enableDineIn As Boolean = SettingsManager.GetBoolSetting(SettingsKeys.SalesEnableDineIn, True)
            Dim enableDelivery As Boolean = SettingsManager.GetBoolSetting(SettingsKeys.SalesEnableDelivery, True)

            btnTakeaway.Visible = enableTakeaway
            btnDineIn.Visible = enableDineIn
            btnDelivery.Visible = enableDelivery

            Dim defaultOrderTypeVal As String = SettingsManager.GetSettingOrDefault(SettingsKeys.DefaultOrderType, "1")
            Dim orderTypeInt As Integer = 1
            Integer.TryParse(defaultOrderTypeVal, orderTypeInt)

            ' إذا كان النوع الافتراضي معطلاً، اختيار أول نوع متاح
            If orderTypeInt = 2 AndAlso Not enableDineIn Then
                orderTypeInt = If(enableTakeaway, 1, If(enableDelivery, 3, 1))
            ElseIf orderTypeInt = 3 AndAlso Not enableDelivery Then
                orderTypeInt = If(enableTakeaway, 1, If(enableDineIn, 2, 1))
            ElseIf orderTypeInt = 1 AndAlso Not enableTakeaway Then
                orderTypeInt = If(enableDineIn, 2, If(enableDelivery, 3, 1))
            End If

            Select Case orderTypeInt
                Case 2 ' صالة
                    btnDineIn.Checked = True
                    CurrentOrderType = OrderType.DineIn
                    lblOrderTypeStatus.Text = "نوع الطلب: صالة"
                Case 3 ' دليفري
                    btnDelivery.Checked = True
                    CurrentOrderType = OrderType.Delivery
                    lblOrderTypeStatus.Text = "نوع الطلب: دليفري"
                    ApplyDefaultDriver() ' تعيين الطيار الافتراضي ورسوم التوصيل تلقائياً
                Case Else ' تيك أوي (1)
                    btnTakeaway.Checked = True
                    CurrentOrderType = OrderType.Takeaway
                    lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"
            End Select
            UpdateHoldButtonText()

            ' =========================================================
            ' 2. تعيين العميل الافتراضي
            ' =========================================================
            Dim defaultCustIDStr As String = SettingsManager.GetSettingOrDefault("DefaultCustomerID", "")
            Dim custID As Integer = 0

            If Integer.TryParse(defaultCustIDStr, custID) AndAlso custID > 0 Then
                Dim activeCustomers = _repo.GetActiveCustomers()
                Dim defaultCust = activeCustomers.FirstOrDefault(Function(c) c.CustomerID = custID)

                If defaultCust IsNot Nothing Then
                    CurrentCustomer = defaultCust
                    txtCustomer.Text = defaultCust.CustomerName
                End If
            End If

        Catch ex As Exception
            Logger.LogError("ApplyDefaultPOSSettings", ex)
            ' في حال حدوث أي خطأ نرجع للقيم الأساسية
            btnTakeaway.Checked = True
            CurrentOrderType = OrderType.Takeaway
        End Try
    End Sub
    Private Sub ApplyDefaultDriver()
        Try
            Dim defaultDriverIDStr As String = SettingsManager.GetSettingOrDefault("DefaultDriverID", "")
            Dim drvID As Integer = 0

            If Integer.TryParse(defaultDriverIDStr, drvID) AndAlso drvID > 0 Then
                Dim activeDrivers = _repo.GetActiveDeliveryDrivers()
                Dim defaultDrv = activeDrivers.FirstOrDefault(Function(d) d.DriverID = drvID)

                If defaultDrv IsNot Nothing Then
                    SelectedDriverID = defaultDrv.DriverID
                    SelectedDriverName = defaultDrv.DriverName
                    DeliveryFee = defaultDrv.DeliveryFeeValue

                    lblOrderTypeStatus.Text = "نوع الطلب: دليفري | الطيار: " & SelectedDriverName & " | خدمة التوصيل: " & DeliveryFee.ToString("N2")
                    lblDeliveryFee.Text = DeliveryFee.ToString("N2")
                    CalculatePOSGrandTotal()
                End If
            End If
        Catch ex As Exception
            Logger.LogError("ApplyDefaultDriver", ex)
        End Try
    End Sub
    '=========================================================
    ' دالة التحقق من الوردية وتوجيه المستخدم لشاشة الورديات
    ' =========================================================
    Private Function CheckAndEnsureActiveShift() As Boolean

        ' أ) التأكد أولاً من تحميل حالة الوردية من الداتا بيز للذاكرة
        InitializeShiftSession()

        ' ب) لو فيه وردية نشطة ومفتوحة (Status = 1) نرجع True فوراً
        If ShiftSession.HasActiveShift Then
            Return True
        End If

        ' ج) لو مفيش وردية مفتوحة نطلع الـ MessageBox
        Dim msgResult As DialogResult = MessageBox.Show(
        "لا توجد وردية مفتوحة حالياً!" & vbCrLf & "هل تريد فتح وردية جديدة الآن للتمكن من البيع؟",
        "تنبيه الوردية الحالية",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.RightAlign
    )

        ' د) لو داس Yes نفتح فورم الورديات
        If msgResult = DialogResult.Yes Then

            Using frm As New frmShifts()
                frm.ShowDialog()
            End Using

            ' بعد ما يقفل فورم الورديات، بنفحص تاني هل فتح وردية بالفعل ولا لأ
            InitializeShiftSession()

            If ShiftSession.HasActiveShift Then
                MessageBox.Show("تم التعرف على الوردية الجديدة بنجاح! يمكنك البدء بالبيع الآن.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                MessageBox.Show("لم يتم فتح وردية نشطة، سيتم إغلاق شاشة البيع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

        Else
            ' لو داس No بنرجع False عشان نقفل شاشة البيع
            Return False
        End If


    End Function
    ' =========================================================
    ' إعدادات شبكة الفاتورة
    ' تم نقل تعريف وتنسيق الأعمدة إلى الديزاينر frmPOS.Designer.vb
    ' =========================================================
    Private Sub SetupInvoiceGrid()
        dgvInvoice.AutoGenerateColumns = False
        dgvInvoice.ColumnHeadersHeight = 38
        dgvInvoice.RowTemplate.Height = 36
        If dgvInvoice.Columns.Contains("colNotes") Then
            dgvInvoice.Columns("colNotes").HeaderText = "ملاحظات المطبخ 📝"
            dgvInvoice.Columns("colNotes").Width = 135
            dgvInvoice.Columns("colNotes").ToolTipText = "انقر مرتين لاختيار أو كتابة تعليق للمطبخ 📝"
        End If
        SetupInvoiceContextMenu()
    End Sub

    Private Sub SetupInvoiceContextMenu()
        Try
            Dim cms As New ContextMenuStrip()
            cms.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            cms.RightToLeft = RightToLeft.Yes

            Dim itemNote = cms.Items.Add("تعليقات وملاحظات المطبخ 📝 (نقر مزدوج)")
            AddHandler itemNote.Click, Sub()
                                           If dgvInvoice.CurrentRow IsNot Nothing Then
                                               OpenKitchenCommentDialog(dgvInvoice.CurrentRow.Index)
                                           End If
                                       End Sub

            cms.Items.Add(New ToolStripSeparator())

            Dim itemPlus = cms.Items.Add("زيادة الكمية (+1)")
            AddHandler itemPlus.Click, Sub()
                                           If dgvInvoice.CurrentRow IsNot Nothing Then
                                               UpdateRowQuantity(dgvInvoice.CurrentRow.Index, +1)
                                           End If
                                       End Sub

            Dim itemMinus = cms.Items.Add("إنقاص الكمية (-1)")
            AddHandler itemMinus.Click, Sub()
                                            If dgvInvoice.CurrentRow IsNot Nothing Then
                                                UpdateRowQuantity(dgvInvoice.CurrentRow.Index, -1)
                                            End If
                                        End Sub

            Dim itemDelete = cms.Items.Add("حذف الصنف من الفاتورة 🗑️")
            AddHandler itemDelete.Click, Sub()
                                             btnDeleteRow_Click(Nothing, Nothing)
                                         End Sub

            dgvInvoice.ContextMenuStrip = cms
        Catch ex As Exception
            Logger.LogError("SetupInvoiceContextMenu", ex)
        End Try
    End Sub
    ' =========================================================
    ' أداة شريط التحكم بشبكة الفئات (الأعمدة والصفوف) وحفظ الإعدادات
    ' =========================================================
    Private Sub SetupCategoryControlsToolbar()
        Try
            ' استرجاع الإعدادات المحفوظة للأعمدة والصفوف
            Dim savedCols As String = SettingsManager.GetSettingOrDefault("POS_CategoryColumns", "4")
            Dim savedRows As String = SettingsManager.GetSettingOrDefault("POS_CategoryRows", "2")
            Integer.TryParse(savedCols, _categoryColumns)
            Integer.TryParse(savedRows, _categoryRows)
            If _categoryColumns < 2 Then _categoryColumns = 4
            If _categoryRows < 1 Then _categoryRows = 2

            ' ضبط القيم في عناصر التصميم
            lblColValue.Text = _categoryColumns.ToString()
            lblRowValue.Text = _categoryRows.ToString()

            ' ربط حدث تغيير حجم الحاوية لإعادة ضبط أبعاد الأزرار تلقائياً
            AddHandler flpCategories.Resize, Sub()
                                                 UpdateCategoryButtonsLayout()
                                             End Sub

        Catch ex As Exception
            Logger.LogError("SetupCategoryControlsToolbar", ex)
        End Try
    End Sub

    Private Sub btnDecCol_Click(sender As Object, e As EventArgs) Handles btnDecCol.Click
        If _categoryColumns > 2 Then
            _categoryColumns -= 1
            lblColValue.Text = _categoryColumns.ToString()
            SettingsManager.SaveSetting("POS_CategoryColumns", _categoryColumns.ToString())
            UpdateCategoryButtonsLayout()
        End If
    End Sub

    Private Sub btnIncCol_Click(sender As Object, e As EventArgs) Handles btnIncCol.Click
        If _categoryColumns < 8 Then
            _categoryColumns += 1
            lblColValue.Text = _categoryColumns.ToString()
            SettingsManager.SaveSetting("POS_CategoryColumns", _categoryColumns.ToString())
            UpdateCategoryButtonsLayout()
        End If
    End Sub

    Private Sub btnDecRow_Click(sender As Object, e As EventArgs) Handles btnDecRow.Click
        If _categoryRows > 1 Then
            _categoryRows -= 1
            lblRowValue.Text = _categoryRows.ToString()
            SettingsManager.SaveSetting("POS_CategoryRows", _categoryRows.ToString())
            UpdateCategoryButtonsLayout()
        End If
    End Sub

    Private Sub btnIncRow_Click(sender As Object, e As EventArgs) Handles btnIncRow.Click
        If _categoryRows < 5 Then
            _categoryRows += 1
            lblRowValue.Text = _categoryRows.ToString()
            SettingsManager.SaveSetting("POS_CategoryRows", _categoryRows.ToString())
            UpdateCategoryButtonsLayout()
        End If
    End Sub

    ' =========================================================
    ' ضبط أبعاد شبكة أزرار الفئات ديناميكياً حسب الأعمدة والصفوف
    ' =========================================================
    Private Sub UpdateCategoryButtonsLayout()
        Try
            If flpCategories Is Nothing Then Return

            ' 1. تعديل ارتفاع Guna2Panel1 حسب عدد الصفوف
            Dim targetPanelHeight As Integer = 56 + (_categoryRows * 65) + 25
            If targetPanelHeight < 140 Then targetPanelHeight = 140
            If targetPanelHeight > 420 Then targetPanelHeight = 420
            If Guna2Panel1 IsNot Nothing AndAlso Guna2Panel1.Height <> targetPanelHeight Then
                Guna2Panel1.Height = targetPanelHeight
            End If

            ' 2. حساب العرض والارتفاع المناسبين لكل زر فئة
            Dim clientW As Integer = flpCategories.ClientSize.Width
            If clientW <= 0 Then clientW = flpCategories.Width
            Dim availW As Integer = clientW - flpCategories.Padding.Left - flpCategories.Padding.Right
            Dim btnMarginH As Integer = 6 ' هامش إجمالي لكل زر (3 يمين + 3 يسار)
            Dim colCount As Integer = Math.Max(1, _categoryColumns)
            Dim calculatedW As Integer = CInt(Math.Floor((availW - (colCount * btnMarginH)) / colCount))
            If calculatedW < 60 Then calculatedW = 60

            Dim clientH As Integer = flpCategories.ClientSize.Height
            If clientH <= 0 Then clientH = flpCategories.Height
            Dim availH As Integer = clientH - flpCategories.Padding.Top - flpCategories.Padding.Bottom
            Dim rowCount As Integer = Math.Max(1, _categoryRows)
            Dim btnMarginV As Integer = 6
            Dim calculatedH As Integer = CInt(Math.Floor((availH - (rowCount * btnMarginV)) / rowCount))
            If calculatedH < 45 Then calculatedH = 45

            flpCategories.SuspendLayout()
            For Each c As Control In flpCategories.Controls
                If TypeOf c Is Guna.UI2.WinForms.Guna2Button Then
                    c.Size = New Size(calculatedW, calculatedH)
                    c.Margin = New Padding(3)
                End If
            Next
            flpCategories.ResumeLayout(True)
        Catch ex As Exception
            ' تجنب أي خطأ أثناء التهيئة الأولية
        End Try
    End Sub

    ' =========================================================
    ' السحب باللمس (Touch & Drag Scrolling) لشاشات الكاشير
    ' =========================================================
    Private _isDraggingTouch As Boolean = False
    Private _touchDragStart As Point
    Private _touchScrollStart As Point

    Private Sub EnableTouchScrolling(flp As FlowLayoutPanel)
        If flp Is Nothing Then Return
        AddHandler flp.MouseDown, Sub(s, e)
                                      If e.Button = MouseButtons.Left Then
                                          _isDraggingTouch = True
                                          _touchDragStart = e.Location
                                          _touchScrollStart = flp.AutoScrollPosition
                                      End If
                                  End Sub

        AddHandler flp.MouseMove, Sub(s, e)
                                      If _isDraggingTouch AndAlso e.Button = MouseButtons.Left Then
                                          Dim deltaX = _touchDragStart.X - e.Location.X
                                          Dim deltaY = _touchDragStart.Y - e.Location.Y
                                          flp.AutoScrollPosition = New Point(-_touchScrollStart.X + deltaX, -_touchScrollStart.Y + deltaY)
                                      End If
                                  End Sub

        AddHandler flp.MouseUp, Sub(s, e)
                                    _isDraggingTouch = False
                                End Sub
    End Sub

    ' ==========================================
    ' 1. رسم الأقسام كأزرار ملونة داخل flpCategories
    ' ==========================================
    Private Sub LoadCategories()
        Try
            If _repo Is Nothing Then
                _repo = New POSRepository(DBModule.ConnectionString)
            End If
            Dim categories = _repo.GetCategories()

            flpCategories.SuspendLayout()
            Try
                flpCategories.Controls.Clear()
                _categoryButtons.Clear()

                ' تحديث أبعاد الحاوية
                UpdateCategoryButtonsLayout()

                ' 1. إضافة زر "عرض الكل" كأول زر في شبكة الفئات
                Dim allCat As New CategoryModel With {
                    .Category_ID = 0,
                    .Category_NameAr = "عرض الكل",
                    .CategoryNameEn = "All"
                }

                Dim btnAll As New Guna.UI2.WinForms.Guna2Button With {
                    .BorderRadius = 8,
                    .Cursor = Cursors.Hand,
                    .Font = New Font("Segoe UI", 11.0!, FontStyle.Bold),
                    .ForeColor = Color.White,
                    .Tag = allCat,
                    .Text = "عرض الكل",
                    .Margin = New Padding(3),
                    .Animated = True,
                    .FillColor = Color.FromArgb(41, 128, 185)
                }
                btnAll.HoverState.FillColor = ControlPaint.Light(Color.FromArgb(41, 128, 185), 0.2F)
                btnAll.HoverState.BorderColor = Color.White

                AddHandler btnAll.Click, AddressOf CategoryButton_Click

                _categoryButtons.Add(btnAll)
                flpCategories.Controls.Add(btnAll)

                ' 2. إضافة باقي أزرار الفئات الملونة
                For Each cat As CategoryModel In categories
                    Dim btn As New Guna.UI2.WinForms.Guna2Button With {
                        .BorderRadius = 8,
                        .Cursor = Cursors.Hand,
                        .Font = New Font("Segoe UI", 11.0!, FontStyle.Bold),
                        .ForeColor = Color.White,
                        .Tag = cat,
                        .Text = cat.Category_NameAr,
                        .Margin = New Padding(3),
                        .Animated = True
                    }

                    ' استخراج لون الفئة المخصص أو استخدام لون افتراضي مناسب
                    Dim catColor As Color = ColorHelper.GetColor(cat.CategoryColor)
                    Dim isDarkTheme As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
                    If catColor.IsEmpty OrElse catColor = Color.Transparent OrElse (catColor.R = 0 AndAlso catColor.G = 0 AndAlso catColor.B = 0) OrElse (Not isDarkTheme AndAlso catColor.GetBrightness() < 0.25) Then
                        Dim modernPalette = New Color() {
                            Color.FromArgb(37, 99, 235),  ' أزرق ملكي
                            Color.FromArgb(220, 38, 38),  ' أحمر ياقوتي
                            Color.FromArgb(217, 119, 6),  ' برتقالي دافئ
                            Color.FromArgb(13, 148, 136), ' تركواز
                            Color.FromArgb(124, 58, 237), ' بنفسجي
                            Color.FromArgb(225, 29, 72),  ' قرمزي
                            Color.FromArgb(16, 185, 129), ' زمردي
                            Color.FromArgb(79, 70, 229)   ' نيلي
                        }
                        catColor = modernPalette(Math.Abs(cat.Category_ID) Mod modernPalette.Length)
                    End If

                    btn.FillColor = catColor
                    btn.HoverState.FillColor = ControlPaint.Light(catColor, 0.2F)
                    btn.HoverState.BorderColor = Color.White

                    AddHandler btn.Click, AddressOf CategoryButton_Click

                    _categoryButtons.Add(btn)
                    flpCategories.Controls.Add(btn)
                Next

                ' تحديد زر "عرض الكل" تلقائياً عند فتح الشاشة
                SelectCategoryButton(btnAll, allCat)

                ' إعادة تطبيق الأبعاد الدقيقة بعد ملء العناصر
                UpdateCategoryButtonsLayout()
            Finally
                flpCategories.ResumeLayout(True)
            End Try
        Catch ex As Exception
            Logger.LogError("LoadCategories", ex)
            MessageBox.Show("حدث خطأ أثناء تحميل الأقسام: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' تحديد القسم المختار وإبرازه بصرياً
    Private Sub SelectCategoryButton(btn As Guna.UI2.WinForms.Guna2Button, cat As CategoryModel)
        _selectedCategoryID = cat.Category_ID
        Dim catColor As Color = ColorHelper.GetColor(cat.CategoryColor)
        If catColor.IsEmpty OrElse catColor = Color.Transparent OrElse (catColor.R = 0 AndAlso catColor.G = 0 AndAlso catColor.B = 0) Then
            catColor = If(cat.Category_ID = 0, Color.FromArgb(41, 128, 185), Color.FromArgb(94, 148, 255))
        End If
        _selectedCategoryColor = catColor

        For Each b In _categoryButtons
            If b Is btn Then
                b.BorderThickness = 3
                b.BorderColor = Color.White
            Else
                b.BorderThickness = 0
                b.BorderColor = Color.Transparent
            End If
        Next

        ' جلب أصناف هذا القسم ورسمها
        LoadProducts(cat.Category_ID)
    End Sub

    ' عند الضغط على زر القسم
    Private Sub CategoryButton_Click(sender As Object, e As EventArgs)
        Dim btn = TryCast(sender, Guna.UI2.WinForms.Guna2Button)
        If btn IsNot Nothing Then
            Dim cat = TryCast(btn.Tag, CategoryModel)
            If cat IsNot Nothing Then
                SelectCategoryButton(btn, cat)
            End If
        End If
    End Sub

    ' ==========================================
    ' 2. رسم الأصناف داخل flpProducts بنظام الأزرار الحديثة والبادج الاحترافي
    ' ==========================================
    Private Sub LoadProducts(categoryID As Integer)
        Try
            If _repo Is Nothing Then
                _repo = New POSRepository(DBModule.ConnectionString)
            End If
            Dim products = _repo.GetProductsByCategoryID(categoryID)
            Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)

            flpProducts.SuspendLayout()
            Try
                flpProducts.Controls.Clear()

                ' في حال كان القسم خالياً من الأصناف، إظهار بطاقة توضيحية راقية
                If products Is Nothing OrElse products.Count = 0 Then
                    Dim pnlEmpty As New Guna.UI2.WinForms.Guna2Panel With {
                        .Width = Math.Max(320, flpProducts.ClientSize.Width - 50),
                        .Height = 220,
                        .BorderRadius = 14,
                        .FillColor = If(isDark, Color.FromArgb(30, 41, 59), Color.White),
                        .BorderColor = If(isDark, Color.FromArgb(51, 65, 85), Color.FromArgb(226, 232, 240)),
                        .BorderThickness = 1,
                        .Margin = New Padding(20, 35, 20, 20)
                    }
                    Dim lblEmpty As New Label With {
                        .Dock = DockStyle.Fill,
                        .Text = "🍽️ لا توجد أصناف في هذا القسم حالياً" & vbCrLf & vbCrLf & "يرجى اختيار قسم آخر أو الضغط على زر ""عرض الكل""",
                        .Font = New Font("Segoe UI", 13.0!, FontStyle.Bold),
                        .ForeColor = If(isDark, Color.FromArgb(148, 163, 184), Color.FromArgb(100, 116, 139)),
                        .TextAlign = ContentAlignment.MiddleCenter
                    }
                    pnlEmpty.Controls.Add(lblEmpty)
                    flpProducts.Controls.Add(pnlEmpty)
                    Return
                End If

                Dim numCols As Integer = 5
                Dim marginH As Integer = 6 ' 3 يمين + 3 يسار
                Dim scrollW As Integer = If(flpProducts.VerticalScroll.Visible, 0, SystemInformation.VerticalScrollBarWidth)
                Dim availW As Integer = flpProducts.ClientSize.Width - flpProducts.Padding.Horizontal - scrollW - 2
                If availW < 300 Then availW = 820
                Dim cardW As Integer = Math.Max(95, (availW - (numCols * marginH)) \ numCols)

                For Each prod As ProductModel In products
                    Dim btn As New Guna.UI2.WinForms.Guna2Button With {
                        .Width = cardW,
                        .Height = 110,
                        .BorderRadius = 12,
                        .Margin = New Padding(3, 4, 3, 4),
                        .Cursor = Cursors.Hand,
                        .Tag = prod,
                        .Animated = True,
                        .FillColor = If(isDark, Color.FromArgb(30, 41, 59), Color.White),
                        .ForeColor = If(isDark, Color.White, Color.FromArgb(15, 23, 42)),
                        .CustomBorderThickness = New Padding(0, 4, 0, 0),
                        .CustomBorderColor = _selectedCategoryColor,
                        .BorderThickness = 1,
                        .BorderColor = If(isDark, Color.FromArgb(51, 65, 85), Color.FromArgb(226, 232, 240)),
                        .Text = ""
                    }

                    btn.HoverState.FillColor = If(isDark, Color.FromArgb(40, 49, 68), Color.FromArgb(248, 250, 252))
                    btn.HoverState.CustomBorderColor = Color.White
                    btn.HoverState.BorderColor = _selectedCategoryColor

                    AddHandler btn.Paint, AddressOf ProductButton_Paint
                    AddHandler btn.Click, AddressOf ProductButton_Click

                    flpProducts.Controls.Add(btn)
                Next

                UpdateProductButtonsLayout()
            Finally
                flpProducts.ResumeLayout(True)
            End Try
        Catch ex As Exception
            Logger.LogError("LoadProducts", ex)
            MessageBox.Show("حدث خطأ أثناء تحميل الأصناف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' ضبط أبعاد وهوامش بطاقات الأصناف ديناميكياً لتوزيع 5 أعمدة بالضبط وبشكل جمالي متناسق بدون أي فراغات مهدرة
    ''' </summary>
    Private Sub UpdateProductButtonsLayout()
        Try
            If flpProducts Is Nothing OrElse flpProducts.Controls.Count = 0 Then Return

            ' لو وُجد بانل فارغ "لا توجد أصناف"، نجعله يملأ العرض
            For Each c As Control In flpProducts.Controls
                If TypeOf c Is Guna.UI2.WinForms.Guna2Panel Then
                    c.Width = Math.Max(320, flpProducts.ClientSize.Width - 20)
                End If
            Next

            Dim numCols As Integer = 5
            Dim marginH As Integer = 6 ' 3 يمين + 3 يسار
            Dim scrollW As Integer = If(flpProducts.VerticalScroll.Visible, 0, SystemInformation.VerticalScrollBarWidth)
            Dim availW As Integer = flpProducts.ClientSize.Width - flpProducts.Padding.Horizontal - scrollW - 2
            If availW <= 100 Then Return

            Dim cardW As Integer = Math.Max(95, (availW - (numCols * marginH)) \ numCols)

            flpProducts.SuspendLayout()
            For Each c As Control In flpProducts.Controls
                If TypeOf c Is Guna.UI2.WinForms.Guna2Button Then
                    If c.Width <> cardW Then c.Width = cardW
                    c.Margin = New Padding(3, 4, 3, 4)
                End If
            Next
            flpProducts.ResumeLayout(True)
        Catch ex As Exception
        End Try
    End Sub

    ' رسم محتويات زر الصنف بجماليات عالية: الاسم بالأعلى وبادج السعر بالأسفل
    Private Sub ProductButton_Paint(sender As Object, e As PaintEventArgs)
        Dim btn = TryCast(sender, Guna.UI2.WinForms.Guna2Button)
        If btn Is Nothing Then Return
        Dim prod = TryCast(btn.Tag, ProductModel)
        If prod Is Nothing Then Return

        Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' 1. رسم اسم الصنف بأعلى البطاقة بمساحة كافية وخط واضح
        Dim titleRect As New Rectangle(6, 10, btn.Width - 12, btn.Height - 48)
        Using sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            sf.Trimming = StringTrimming.EllipsisWord
            sf.FormatFlags = StringFormatFlags.NoClip

            Dim titleFontSize As Single = If(btn.Width < 125, 9.5!, 11.0!)
            Using titleFont As New Font("Segoe UI", titleFontSize, FontStyle.Bold)
                Dim titleBrush As Brush = If(isDark, Brushes.White, New SolidBrush(Color.FromArgb(15, 23, 42)))
                Try
                    g.DrawString(prod.ProductNameAr, titleFont, titleBrush, titleRect, sf)
                Finally
                    If Not isDark Then titleBrush.Dispose()
                End Try
            End Using
        End Using

        ' 2. تحديد تفاصيل بادج السعر (Pill Badge)
        Dim priceText As String
        Dim pillBgColor As Color
        Dim isDirect As Boolean = prod.IsDirectItem

        If isDirect Then
            priceText = prod.DefaultPrice.ToString("N2") & " " & CurrencySymbol
            pillBgColor = Color.FromArgb(16, 185, 129) ' أخضر زمردي جذاب للأصناف السريعة
        Else
            If prod.DefaultPrice > 0 Then
                priceText = "يبدأ من " & prod.DefaultPrice.ToString("N2") & " " & CurrencySymbol
            Else
                priceText = "+ خيارات"
            End If
            pillBgColor = Color.FromArgb(37, 99, 235) ' أزرق ملكي للأصناف ذات الخيارات المتعددة
        End If

        ' 3. حساب أبعاد ورسم كبسولة السعر بالأسفل
        Dim badgeFontSize As Single = If(btn.Width < 125, 8.5!, 9.5!)
        Using badgeFont As New Font("Segoe UI", badgeFontSize, FontStyle.Bold)
            Dim textSize = g.MeasureString(priceText, badgeFont)
            Dim pillW As Integer = Math.Min(btn.Width - 12, CInt(Math.Ceiling(textSize.Width)) + 14)
            Dim pillH As Integer = 25
            Dim pillX As Integer = (btn.Width - pillW) \ 2
            Dim pillY As Integer = btn.Height - pillH - 8
            Dim pillRect As New Rectangle(pillX, pillY, pillW, pillH)

            Using pillPath = GetRoundedRectanglePath(pillRect, 6)
                Using pillBrush As New SolidBrush(pillBgColor)
                    g.FillPath(pillBrush, pillPath)
                End Using

                Using sfBadge As New StringFormat()
                    sfBadge.Alignment = StringAlignment.Center
                    sfBadge.LineAlignment = StringAlignment.Center
                    g.DrawString(priceText, badgeFont, Brushes.White, pillRect, sfBadge)
                End Using
            End Using
        End Using
    End Sub

    ' مساعدة لرسم الأشكال المستديرة (Rounded Rectangle)
    Private Function GetRoundedRectanglePath(rect As Rectangle, radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        Dim d As Integer = radius * 2
        If d > rect.Width Then d = rect.Width
        If d > rect.Height Then d = rect.Height

        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' ==========================================
    ' حدث الضغط على زر الصنف (إضافة مباشرة أو خيارات)
    ' ==========================================
    Private Sub ProductButton_Click(sender As Object, e As EventArgs)
        Dim btn = TryCast(sender, Guna.UI2.WinForms.Guna2Button)
        If btn Is Nothing Then Return
        Dim product = TryCast(btn.Tag, ProductModel)
        If product Is Nothing Then Return

        Try
            If product.IsDirectItem Then
                ' صنف مباشر (حجم واحد وبدون إضافات) - إضافة مباشرة وسريعة بنقرة واحدة
                Dim sizes = _repo.GetProductSizes(product.Product_ID)
                Dim orderItem As New OrderItemModel With {
                    .Product_ID = product.Product_ID,
                    .ProductName = product.ProductNameAr,
                    .Quantity = 1
                }

                If sizes IsNot Nothing AndAlso sizes.Count > 0 Then
                    Dim defaultSize = sizes.FirstOrDefault(Function(s) s.IsDefault)
                    If defaultSize Is Nothing Then defaultSize = sizes(0)
                    orderItem.SelectedSize = defaultSize
                Else
                    orderItem.SelectedSize = New ProductSizeModel With {
                        .ProductID = product.Product_ID,
                        .SalePrice = product.DefaultPrice,
                        .SizeInfo = New SizeModel With {.SizeNameAr = "عادي"}
                    }
                End If

                AddItemToInvoice(orderItem)
            Else
                ' صنف يحتوي على خيارات متعددة (أحجام مختلفة أو إضافات) - فتح شاشة الخيارات كـ Dialog
                Using frmOptions As New FrmProductOptions(product, _repo)
                    If frmOptions.ShowDialog() = DialogResult.OK Then
                        For Each selectedItem In frmOptions.ResultOrderItems
                            AddItemToInvoice(selectedItem)
                        Next
                    End If
                End Using
            End If
        Catch ex As Exception
            Logger.LogError("ProductButton_Click", ex)
            MessageBox.Show("حدث خطأ أثناء إضافة الصنف: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================================
    ' [نظام الـ UserControl القديم - معلق للاحتفاظ به بناء على طلب المستخدم]
    ' =========================================================================
    ' Private Sub LoadCategories_OldUserControl()
    '     Try
    '         Dim categories = _repo.GetCategories()
    '         flpCategories.SuspendLayout()
    '         Try
    '             flpCategories.Controls.Clear()
    '             For Each cat As CategoryModel In categories
    '                 Dim card As New UCCategoryCard With {
    '                     .Width = 130,
    '                     .Height = 140,
    '                     .Category = cat
    '                 }
    '                 AddHandler card.CategoryClicked, AddressOf CategoryCard_Click_OldUserControl
    '                 flpCategories.Controls.Add(card)
    '             Next
    '         Finally
    '             flpCategories.ResumeLayout()
    '         End Try
    '     Catch ex As Exception
    '         Logger.LogError("LoadCategories", ex)
    '     End Try
    ' End Sub
    ' Private Sub CategoryCard_Click_OldUserControl(category As CategoryModel)
    '     LoadProducts_OldUserControl(category.Category_ID)
    ' End Sub
    ' Private Sub LoadProducts_OldUserControl(categoryID As Integer)
    '     Dim products = _repo.GetProductsByCategoryID(categoryID)
    '     flpProducts.SuspendLayout()
    '     Try
    '         flpProducts.Controls.Clear()
    '         For Each prod As ProductModel In products
    '             Dim card As New UCProductCard With {
    '                 .Width = 140,
    '                 .Height = 150,
    '                 .Product = prod
    '             }
    '             AddHandler card.ProductClicked, AddressOf ProductCard_Click_OldUserControl
    '             flpProducts.Controls.Add(card)
    '         Next
    '     Finally
    '         flpProducts.ResumeLayout()
    '     End Try
    ' End Sub
    ' Private Sub ProductCard_Click_OldUserControl(product As ProductModel)
    '     Using frmOptions As New FrmProductOptions(product, _repo)
    '         If frmOptions.ShowDialog() = DialogResult.OK Then
    '             For Each selectedItem In frmOptions.ResultOrderItems
    '                 AddItemToInvoice(selectedItem)
    '             Next
    '         End If
    '     End Using
    ' End Sub
    ' =========================================================
    ' دالة جلب وعرض رقم الفاتورة الحالي المتسلسل
    ' =========================================================
    Private Sub UpdateNextInvoiceNumber()
        If _repo IsNot Nothing Then
            Dim nextNum As String = _repo.GetNextInvoiceNumber()
            lblInvoiceNumber.Text = nextNum ' Label رقم الفاتورة بأعلى الشاشة
        End If
    End Sub

    ' =========================================================
    ' الدالة المركزية للحسابات الشاملة لكل العوامل والعملات
    ' =========================================================
    Private Sub CalculatePOSGrandTotal()
        Dim itemsTotal As Decimal = 0

        ' 1. مجموع الأصناف في الجدول
        For Each row As DataGridViewRow In dgvInvoice.Rows
            If row.Cells("colTotalPrice").Value IsNot Nothing Then
                Dim rowVal As Decimal = 0
                Decimal.TryParse(row.Cells("colTotalPrice").Value.ToString(), rowVal)
                itemsTotal += rowVal
            End If
        Next

        ' 2. عرض الصافي الأولي
        lblSubTotal.Text = itemsTotal.ToString("N2")
        Dim feeStr As String = SettingsManager.GetSettingOrDefault("DineInServiceFee", "0")
        Decimal.TryParse(feeStr, DineInServiceFee)
        Dim IsPercent As Boolean = SettingsManager.GetBoolSetting("IsDineInServiceFeePercent", False)
        IsDineInServiceFeePercent = IsPercent
        ' 3. تحديد رسوم الدليفري ورسوم الصالة والضريبة
        Dim currentDelivery As Decimal = If(CurrentOrderType = OrderType.Delivery, DeliveryFee, 0)
        Dim currentDineInFee As Decimal
        If IsPercent Then
            currentDineInFee = If(CurrentOrderType = OrderType.DineIn, itemsTotal * DineInServiceFee / 100, 0)
            lblDineInFee.Text = itemsTotal * DineInServiceFee / 100 & $"({DineInServiceFee}%)"
        Else
            currentDineInFee = If(CurrentOrderType = OrderType.DineIn, DineInServiceFee, 0)
            lblDineInFee.Text = currentDineInFee.ToString("N2")
        End If

        lblDeliveryFee.Text = currentDelivery.ToString("N2")
        'lblDineInFee.Text = currentDineInFee.ToString("N2")
        lblTax.Text = TaxAmount.ToString("N2")

        ' 4. حساب الإجمالي النهائي (مع مراعاة السوالب والعمليات الحسابية المتقاطعة وخصم عربون الحجز)
        Dim finalGrandTotal As Decimal = itemsTotal + currentDelivery + currentDineInFee + TaxAmount - CurrentReservationDeposit

        ' منع أي قيم سالبة غير منطقية
        If finalGrandTotal < 0 Then finalGrandTotal = 0

        If CurrentReservationDeposit > 0 Then
            lblGrandTotal.Text = $"{finalGrandTotal:N2} {CurrencySymbol} (عربون: -{CurrentReservationDeposit:N2})"
        Else
            lblGrandTotal.Text = finalGrandTotal.ToString("N2") & " " & CurrencySymbol
        End If
    End Sub

    Private Sub AddItemToInvoice(item As OrderItemModel)
        Dim sizeName As String = "عادي"
        If item.SelectedSize IsNot Nothing Then
            If item.SelectedSize.SizeInfo IsNot Nothing AndAlso Not String.IsNullOrEmpty(item.SelectedSize.SizeInfo.SizeNameAr) Then
                sizeName = item.SelectedSize.SizeInfo.SizeNameAr
            End If
        End If

        Dim addonsList As New List(Of String)
        For Each addon In item.SelectedAddons
            If addon.AddonInfo IsNot Nothing AndAlso Not String.IsNullOrEmpty(addon.AddonInfo.AddonNameAr) Then
                addonsList.Add(addon.AddonInfo.AddonNameAr)
            End If
        Next
        Dim addonsText As String = If(addonsList.Count > 0, String.Join(", ", addonsList), "-")

        Dim baseSizePrice As Decimal = If(item.SelectedSize IsNot Nothing, item.SelectedSize.SalePrice, 0)
        Dim addonsTotalPrice As Decimal = 0
        For Each addon In item.SelectedAddons
            addonsTotalPrice += addon.SalePrice
        Next
        Dim singleUnitPrice As Decimal = baseSizePrice + addonsTotalPrice

        dgvInvoice.Rows.Add(
            dgvInvoice.Rows.Count + 1,
            item.ProductName,
            sizeName,
            addonsText,
            singleUnitPrice,
            item.Quantity,
            item.TotalPrice,
            item.Notes,
            item.Product_ID
        )

        ' تحديث الحسابات الشاملة فور إضافة صنف
        CalculatePOSGrandTotal()
    End Sub

    ' =========================================================
    ' زر تعليق الفاتورة المحدث مع دعم الـ JSON وقفل الطاولة
    ' =========================================================
    Private Sub btnHoldInvoice_Click(sender As Object, e As EventArgs) Handles btnHoldInvoice.Click
        If dgvInvoice.Rows.Count = 0 Then
            MessageBox.Show("لا يمكن تعليق أو إرسال فاتورة فارغة للمطبخ!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' للطلبات الدليفري يجب تحديد العميل والطيار
        If CurrentOrderType = OrderType.Delivery Then
            If CurrentCustomer Is Nothing AndAlso String.IsNullOrWhiteSpace(txtCustomer.Text) Then
                MessageBox.Show("برجاء تحديد العميل أولاً لطلبات الدليفري قبل تعليق الفاتورة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnSelectCustomer.Focus()
                Return
            End If
            If Not SelectedDriverID.HasValue Then
                MessageBox.Show("برجاء تحديد طيار التوصيل أولاً لطلبات الدليفري!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        ' لطلبات الصالة يجب تحديد الطاولة
        If CurrentOrderType = OrderType.DineIn AndAlso Not SelectedTableID.HasValue Then
            MessageBox.Show("برجاء اختيار الطاولة أولاً لطلب الصالة قبل إرساله للمطبخ!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnDineIn.PerformClick()
            Return
        End If

        ' تجهيز قائمة أسطر الفاتورة لتحويلها لـ JSON احترافي
        Dim itemsList As New List(Of InvoiceDetailModel)
        For Each row As DataGridViewRow In dgvInvoice.Rows
            If Not row.IsNewRow Then
                itemsList.Add(New InvoiceDetailModel With {
                    .ProductID = Convert.ToInt32(row.Cells("colProductID").Value),
                    .ProductName = row.Cells("colProductName").Value.ToString(),
                    .SizeName = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), ""),
                    .AddonsText = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), ""),
                    .UnitPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value),
                    .Quantity = Convert.ToInt32(row.Cells("colQuantity").Value),
                    .TotalPrice = Convert.ToDecimal(row.Cells("colTotalPrice").Value),
                    .Notes = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")
                })
            End If
        Next

        Dim jsonItems As String = Newtonsoft.Json.JsonConvert.SerializeObject(itemsList)
        Dim custName As String = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerName, If(Not String.IsNullOrWhiteSpace(txtCustomer.Text) AndAlso txtCustomer.Text.Trim() <> "عميل نقدي", txtCustomer.Text.Trim(), "عميل نقدي"))
        Dim custID As Integer? = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerID, CType(Nothing, Integer?))

        Dim pendingInv As New PendingInvoiceModel With {
            .ShiftID = If(ShiftSession.CurrentShift IsNot Nothing, ShiftSession.CurrentShift.ShiftID, 1),
            .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
            .OrderType = CByte(CurrentOrderType),
            .CustomerID = custID,
            .CustomerName = custName,
            .TableID = SelectedTableID,
            .TableName = SelectedTableName,
            .DriverID = SelectedDriverID,
            .DriverName = SelectedDriverName,
            .DeliveryFee = DeliveryFee,
            .InvoiceJSON = jsonItems,
            .TotalAmount = GetInvoiceTotalFromGrid()
        }

        If _repo.SavePendingInvoice(pendingInv) Then

            Dim isRecalledInvoice As Boolean = _currentPendingInvoiceID.HasValue
            Dim oldPendingNumber As String = If(isRecalledInvoice, _currentPendingInvoiceNumber, "")

            ' إذا كانت هناك فاتورة معلقة سابقة مسترجعة، نحذفها بعد تعليق الفاتورة الجديدة
            If _currentPendingInvoiceID.HasValue Then
                _repo.DeletePendingInvoice(_currentPendingInvoiceID.Value)
                _currentPendingInvoiceID = Nothing
                _currentPendingInvoiceNumber = ""
            End If

            ' إذا كان نوع الطلب صالة -> تغيير حالة الطاولة إلى مشغولة (2) في الداتا بيز
            If CurrentOrderType = OrderType.DineIn AndAlso SelectedTableID.HasValue Then
                _repo.UpdateTableStatus(SelectedTableID.Value, 2) ' 2 = مشغولة/حجز معلق
            End If

            ' صياغة وصف نوع الطلب بوضوح للطباعة والمطبخ
            Dim kotTypeDesc As String
            If CurrentOrderType = OrderType.DineIn Then
                kotTypeDesc = "صالة - طاولة: " & SelectedTableName
                If custName <> "عميل نقدي" Then kotTypeDesc &= " | العميل: " & custName
            ElseIf CurrentOrderType = OrderType.Delivery Then
                kotTypeDesc = "دليفري | الطيار: " & SelectedDriverName
                If custName <> "عميل نقدي" Then kotTypeDesc &= " | العميل: " & custName
            Else
                kotTypeDesc = "تيك أوي"
                If custName <> "عميل نقدي" Then kotTypeDesc &= " | العميل: " & custName
            End If

            Dim staffName As String = If(Session.CurrentUserfullName IsNot Nothing, Session.CurrentUserfullName, "كاشير")

            If isRecalledInvoice Then
                ' فحص الأصناف الجديدة المضافة عند تعديل الفاتورة المسترجعة
                Dim newAddedItems = GetNewlyAddedItems(itemsList)
                If newAddedItems.Count > 0 Then
                    Dim autoFollowUp = SettingsManager.GetBoolSetting(SettingsKeys.AutoPrintFollowUpTicket, True)
                    If autoFollowUp Then
                        Dim ticketNumStr = If(Not String.IsNullOrWhiteSpace(oldPendingNumber), oldPendingNumber, pendingInv.PendingID.ToString())
                        Try
                            RestaurantPrintManager.PrintKitchenTicket(
                                orderNumber:="متابعة #" & pendingInv.PendingID,
                                orderTypeDesc:=kotTypeDesc,
                                tableName:=SelectedTableName,
                                staffName:=staffName,
                                items:=newAddedItems,
                                ticketTitle:="ورقة متابعة فاتورة #" & ticketNumStr
                            )
                        Catch exKot As Exception
                            Logger.LogError("btnHoldInvoice_Click - PrintKitchenFollowUpTicket", exKot)
                        End Try
                    End If

                    ' إرسال الأصناف المضافة فقط لشاشة المطبخ KDS
                    Try
                        Dim kOrder As New KitchenOrderModel With {
                            .OrderNumber = "متابعة #" & pendingInv.PendingID,
                            .OrderType = CByte(CurrentOrderType),
                            .TableID = SelectedTableID,
                            .TableName = SelectedTableName,
                            .CustomerName = custName,
                            .ServerName = staffName,
                            .Status = KitchenOrderStatus.New
                        }
                        For Each itm In newAddedItems
                            kOrder.Items.Add(New KitchenOrderItemModel With {
                                .ProductID = itm.ProductID,
                                .ProductName = itm.ProductName,
                                .SizeName = itm.SizeName,
                                .AddonsText = itm.AddonsText,
                                .Quantity = itm.Quantity,
                                .Notes = itm.Notes
                            })
                        Next
                        Dim unusedTask = Task.Run(Async Function() Await _repo.CreateKitchenOrderAsync(kOrder))
                    Catch exKds As Exception
                        Logger.LogError("btnHoldInvoice_Click - KDS FollowUp", exKds)
                    End Try
                End If
            Else
                ' طلب جديد بالكامل لأول مرة
                Dim autoKitchen = SettingsManager.GetBoolSetting(SettingsKeys.AutoPrintKitchenTicket, True)
                If autoKitchen Then
                    Try
                        RestaurantPrintManager.PrintKitchenTicket(
                            orderNumber:="طلب #" & pendingInv.PendingID,
                            orderTypeDesc:=kotTypeDesc,
                            tableName:=SelectedTableName,
                            staffName:=staffName,
                            items:=itemsList,
                            ticketTitle:="طلب تجهيز المطبخ"
                        )
                    Catch exKot As Exception
                        Logger.LogError("btnHoldInvoice_Click - PrintKitchenTicket", exKot)
                    End Try
                End If

                ' إرسال الطلب الجديد لشاشة المطبخ KDS
                Try
                    Dim kOrder As New KitchenOrderModel With {
                        .OrderNumber = "طلب #" & pendingInv.PendingID,
                        .OrderType = CByte(CurrentOrderType),
                        .TableID = SelectedTableID,
                        .TableName = SelectedTableName,
                        .CustomerName = custName,
                        .ServerName = staffName,
                        .Status = KitchenOrderStatus.New
                    }
                    For Each itm In itemsList
                        kOrder.Items.Add(New KitchenOrderItemModel With {
                            .ProductID = itm.ProductID,
                            .ProductName = itm.ProductName,
                            .SizeName = itm.SizeName,
                            .AddonsText = itm.AddonsText,
                            .Quantity = itm.Quantity,
                            .Notes = itm.Notes
                        })
                    Next
                    Dim unusedTask = Task.Run(Async Function() Await _repo.CreateKitchenOrderAsync(kOrder))
                Catch exKds As Exception
                    Logger.LogError("btnHoldInvoice_Click - KDS", exKds)
                End Try
            End If

            If CurrentOrderType = OrderType.DineIn Then
                MessageBox.Show($"تم إرسال الطلب للمطبخ (KOT & KDS) وتسكينه على ({SelectedTableName}) بنجاح!" & vbCrLf & "سيظل الحساب معلقاً حتى انتهاء العميل من تناول وجبته وسداد الفاتورة.", "إرسال للمطبخ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf CurrentOrderType = OrderType.Delivery Then
                MessageBox.Show($"تم إرسال الطلب للمطبخ (KOT & KDS) وإسناده للطيار ({SelectedDriverName}) بنجاح!" & vbCrLf & "يمكنك استرجاع الفاتورة وسدادها من المعلقة [F7] عند عودة الطيار بالتحصيل.", "إرسال دليفري", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("تم إرسال الطلب للمطبخ (KOT & KDS) بنجاح!" & vbCrLf & "يمكنك استرجاع الفاتورة وسدادها من المعلقة [F7] فور استلام العميل للطلب.", "إرسال تيك أوي", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ResetPOSForm()
            UpdateNextInvoiceNumber() ' تغيير وتحديث رقم الفاتورة القادمة
        End If
    End Sub

    ' =========================================================
    ' دالة مساعدة لحساب مجموع أسطر الفاتورة من DataGridView
    ' =========================================================
    Private Function GetInvoiceTotalFromGrid() As Decimal
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvInvoice.Rows
            If row.Cells("colTotalPrice").Value IsNot Nothing Then
                total += Convert.ToDecimal(row.Cells("colTotalPrice").Value)
            End If
        Next
        Return total
    End Function

    ' =========================================================
    ' تحديث نص ولون زر التعليق/الإرسال للمطبخ بناءً على نوع الطلب
    ' =========================================================
    Public Sub UpdateHoldButtonText()
        Select Case CurrentOrderType
            Case OrderType.DineIn
                btnHoldInvoice.Text = " إرسال للمطبخ [F5]"
                btnHoldInvoice.FillColor = Color.FromArgb(79, 70, 229) ' Royal Indigo
            Case OrderType.Delivery
                btnHoldInvoice.Text = " إرسال للطيار والمطبخ [F5]"
                btnHoldInvoice.FillColor = Color.FromArgb(249, 115, 22) ' Vibrant Orange
            Case OrderType.Takeaway
                btnHoldInvoice.Text = " إرسال للمطبخ (دفع لاحق) [F5]"
                btnHoldInvoice.FillColor = Color.FromArgb(13, 148, 136) ' Teal
        End Select
    End Sub

    ' =========================================================
    ' استرجاع الفواتير المعلقة وإعادة فتح الطاولة والعميل
    ' =========================================================
    Private Sub btnPendingInvoices_Click(sender As Object, e As EventArgs) Handles btnPendingInvoices.Click
        Using frmPending As New FrmPendingInvoices(_repo)
            If frmPending.ShowDialog() = DialogResult.OK Then

                Dim pendingItem = frmPending.SelectedPendingInvoice
                If pendingItem IsNot Nothing Then

                    ResetPOSForm()

                    ' 1. استرجاع العميل وتعبئة حقل الاسم إذا وُجد
                    If pendingItem.CustomerID.HasValue AndAlso pendingItem.CustomerID.Value > 0 Then
                        CurrentCustomer = New CustomerModel With {
                            .CustomerID = pendingItem.CustomerID.Value,
                            .CustomerName = pendingItem.CustomerName
                        }
                        txtCustomer.Text = CurrentCustomer.CustomerName
                    ElseIf Not String.IsNullOrWhiteSpace(pendingItem.CustomerName) AndAlso pendingItem.CustomerName <> "عميل نقدي" Then
                        txtCustomer.Text = pendingItem.CustomerName
                    End If

                    ' 2. استرجاع نوع الطلب والطاولات
                    CurrentOrderType = CType(pendingItem.OrderType, OrderType)
                    Select Case CurrentOrderType
                        Case OrderType.Takeaway
                            btnTakeaway.Checked = True
                            lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"
                        Case OrderType.DineIn
                            btnDineIn.Checked = True
                            SelectedTableID = pendingItem.TableID
                            SelectedTableName = pendingItem.TableName
                            lblOrderTypeStatus.Text = "نوع الطلب: صالة | الطاولة: " & SelectedTableName
                        Case OrderType.Delivery
                            btnDelivery.Checked = True
                            SelectedDriverID = pendingItem.DriverID
                            SelectedDriverName = pendingItem.DriverName
                            DeliveryFee = pendingItem.DeliveryFee
                            lblDeliveryFee.Text = DeliveryFee.ToString("N2")
                            lblOrderTypeStatus.Text = "نوع الطلب: دليفري | الطيار: " & SelectedDriverName
                    End Select

                    ' 3. إعادة تحميل الأسطر عبر فك الـ JSON (مع دعم الصيغة القديمة للتوافقية)
                    If Not String.IsNullOrWhiteSpace(pendingItem.InvoiceJSON) Then
                        If pendingItem.InvoiceJSON.Trim().StartsWith("[") Then
                            Try
                                Dim items = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of InvoiceDetailModel))(pendingItem.InvoiceJSON)
                                If items IsNot Nothing Then
                                    For Each itm In items
                                        dgvInvoice.Rows.Add(
                                            dgvInvoice.Rows.Count + 1,
                                            itm.ProductName,
                                            itm.SizeName,
                                            itm.AddonsText,
                                            itm.UnitPrice,
                                            itm.Quantity,
                                            itm.TotalPrice,
                                            itm.Notes,
                                            itm.ProductID
                                        )
                                    Next
                                End If
                            Catch ex As Exception
                                Logger.LogError("btnPendingInvoices_Click - Deserializing InvoiceJSON", ex)
                                MessageBox.Show("حدث خطأ أثناء قراءة أصناف الفاتورة المعلقة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        Else
                            ' توافقية مع الفواتير المعلقة القديمة بنظام الـ Delimiter
                            Dim rowsData() As String = pendingItem.InvoiceJSON.Split("~"c)
                            For Each rData In rowsData
                                Dim parts() As String = rData.Split("|"c)
                                If parts.Length >= 8 Then
                                    dgvInvoice.Rows.Add(
                                        dgvInvoice.Rows.Count + 1,
                                        parts(1),
                                        parts(2),
                                        parts(3),
                                        Convert.ToDecimal(parts(4)),
                                        Convert.ToInt32(parts(5)),
                                        Convert.ToDecimal(parts(6)),
                                        parts(7),
                                        Convert.ToInt32(parts(0))
                                    )
                                End If
                            Next
                        End If
                    End If

                    CalculatePOSGrandTotal()

                    ' الاحتفاظ برقم الفاتورة المعلقة لحذفها بأمان عند إتمام الدفع أو إعادة التعليق
                    _currentPendingInvoiceID = pendingItem.PendingID
                    _currentPendingInvoiceNumber = If(Not String.IsNullOrWhiteSpace(pendingItem.PendingNumber), pendingItem.PendingNumber, pendingItem.PendingID.ToString())
                    SnapshotRecalledItems()

                End If

            End If
        End Using
    End Sub

    Private Sub btnDelivery_Click(sender As Object, e As EventArgs) Handles btnDelivery.Click
        CurrentOrderType = OrderType.Delivery
        SelectedTableID = Nothing
        SelectedTableName = ""
        UpdateHoldButtonText()
        ' فتح فورم اختيار الطيار
        Using frmDriver As New FrmSelectDriver(_repo)
            If frmDriver.ShowDialog() = DialogResult.OK Then

                ' استلام الطيار المختار
                Dim driver As DeliveryDriverModel = frmDriver.SelectedDriver

                If driver IsNot Nothing Then
                    ' حفظ البيانات
                    SelectedDriverID = driver.DriverID
                    SelectedDriverName = driver.DriverName
                    DeliveryFee = driver.DeliveryFeeValue

                    ' تحديث شاشة العرض
                    lblOrderTypeStatus.Text = "نوع الطلب: دليفري | الطيار: " & driver.DriverName & " | خدمة التوصيل: " & driver.DeliveryFeeValue.ToString("N2")
                    lblDeliveryFee.Text = driver.DeliveryFeeValue.ToString("N2")
                    CalculatePOSGrandTotal()
                End If

            Else
                ' لو أغلقت الشاشة بدون اختيار طيار يرجع تيك أوي
                btnTakeaway.Checked = True
                btnTakeaway_Click(Nothing, Nothing)
            End If
        End Using
    End Sub

    Private Sub btnTakeaway_Click(sender As Object, e As EventArgs) Handles btnTakeaway.Click
        CurrentOrderType = OrderType.Takeaway

        ' تفريغ بيانات الصالة والدليفري
        SelectedTableID = Nothing
        SelectedTableName = ""
        SelectedDriverID = Nothing
        SelectedDriverName = ""
        DeliveryFee = 0
        lblDeliveryFee.Text = "0.00"
        lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"
        UpdateHoldButtonText()
        CalculatePOSGrandTotal()
    End Sub

    ' =========================================================
    ' زر الدفع ومراجعة الشروط قبل الفتح
    ' =========================================================
    Private Async Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

        If dgvInvoice.Rows.Count = 0 Then
            MessageBox.Show("لا يمكن إتمام عملية الدفع بفاتورة فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' التحقق من طلبات الصالة
        If CurrentOrderType = OrderType.DineIn AndAlso Not SelectedTableID.HasValue Then
            MessageBox.Show("برجاء تحديد رقم الطاولة أولاً لطلبات الصالة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' التحقق من طلبات الدليفري
        If CurrentOrderType = OrderType.Delivery Then
            If CurrentCustomer Is Nothing Then
                MessageBox.Show("برجاء تحديد بيانات العميل أولاً لطلبات الدليفري!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnSelectCustomer.Focus()
                Return
            End If

            If Not SelectedDriverID.HasValue Then
                MessageBox.Show("برجاء تحديد طيار التوصيل أولاً لطلبات الدليفري!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        CalculatePOSGrandTotal()
        Dim itemsTotal As Decimal = GetInvoiceTotalFromGrid()
        Dim currentDineInFee As Decimal = If(CurrentOrderType = OrderType.DineIn, If(IsDineInServiceFeePercent, itemsTotal * DineInServiceFee / 100, DineInServiceFee), 0)
        Dim finalInvoiceTotal As Decimal = itemsTotal + currentDineInFee + TaxAmount
        If CurrentOrderType = OrderType.Delivery Then finalInvoiceTotal += DeliveryFee
        If CurrentReservationDeposit > 0 Then
            finalInvoiceTotal = Math.Max(0, finalInvoiceTotal - CurrentReservationDeposit)
        End If

        Using frmPay As New FrmQuickPayment(finalInvoiceTotal, CurrentCustomer, CurrentOrderType)
            If frmPay.ShowDialog() = DialogResult.OK Then

                Dim custID As Integer? = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerID, CType(Nothing, Integer?))

                ' جلب الفرع والمخزن الحاليين من الإعدادات بأمان
                Dim currentBranchID As Integer = 1
                Integer.TryParse(SettingsManager.GetSettingOrDefault("CurrentBranchID", "1"), currentBranchID)

                Dim currentStoreID As Integer = 1
                Integer.TryParse(SettingsManager.GetSettingOrDefault("CurrentStoreID", "1"), currentStoreID)

                Dim shiftIdVal As Integer = 1
                If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                    shiftIdVal = ShiftSession.CurrentShift.ShiftID
                End If

                Dim invoiceNotes As String = ""
                If CurrentReservationDeposit > 0 Then
                    invoiceNotes = $"[تم خصم عربون حجز مسبق بقيمة {CurrentReservationDeposit:N2} {CurrencySymbol}]"
                End If

                Dim invoice As New InvoiceModel With {
                    .OrderType = CByte(CurrentOrderType),
                    .ShiftID = shiftIdVal,
                    .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
                    .CustomerID = custID,
                    .TableID = SelectedTableID,
                    .DriverID = SelectedDriverID,
                    .BranchID = currentBranchID,
                    .StoreID = currentStoreID,
                    .DeliveryFee = DeliveryFee,
                    .TotalBeforeDiscount = frmPay.FinalGrandTotal,
                    .DiscountAmount = frmPay.TotalDiscount,
                    .NetTotal = frmPay.NetTotal,
                    .PaidAmount = frmPay.PaidAmount,
                    .RemainingAmount = frmPay.RemainingAmount,
                    .IsCredit = frmPay.IsCreditOrder,
                    .TreasuryID = If(frmPay.SelectedTreasuryID > 0, frmPay.SelectedTreasuryID, CType(Nothing, Integer?)),
                    .Notes = invoiceNotes
                }

                For Each row As DataGridViewRow In dgvInvoice.Rows
                    If Not row.IsNewRow Then
                        invoice.Details.Add(New InvoiceDetailModel With {
                            .ProductID = Convert.ToInt32(row.Cells("colProductID").Value),
                            .ProductName = row.Cells("colProductName").Value.ToString(),
                            .SizeName = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), ""),
                            .AddonsText = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), ""),
                            .UnitPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value),
                            .Quantity = Convert.ToInt32(row.Cells("colQuantity").Value),
                            .TotalPrice = Convert.ToDecimal(row.Cells("colTotalPrice").Value),
                            .Notes = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")
                        })
                    End If
                Next

                btnPay.Enabled = False
                Try
                    Dim savedInvNum As String = Await _repo.SaveInvoiceAsync(invoice)
                    ' تحديث الذاكرة الحالية للوردية فوراً
                    If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                        ShiftSession.CurrentShift.TotalSales += invoice.PaidAmount
                        ShiftSession.CurrentShift.TotalOrders += 1
                    End If
                    ' إذا كانت الفاتورة صالة، يتم تحرير الطاولة وإرجاع حالتها متاحة (1)
                    If CurrentOrderType = OrderType.DineIn AndAlso SelectedTableID.HasValue Then
                        _repo.UpdateTableStatus(SelectedTableID.Value, 1) ' 1 = متاحة
                    End If

                    ' إذا كان هناك حجز مرتبط بالطاولة، يتم تأكيد إتمامه وتصفية المتغيرات
                    If CurrentReservationID.HasValue AndAlso SelectedTableID.HasValue Then
                        _repo.CheckInReservation(CurrentReservationID.Value, SelectedTableID.Value)
                        CurrentReservationID = Nothing
                        CurrentReservationDeposit = 0
                    End If

                    ' فحص ما إذا كان الطلب قد أُرسل بالفعل للمطبخ عبر التعليق المسبق
                    Dim wasAlreadyHeld As Boolean = _currentPendingInvoiceID.HasValue
                    Dim oldPendingNumber As String = If(wasAlreadyHeld, _currentPendingInvoiceNumber, "")

                    ' إغلاق الفاتورة المعلقة بعد الحفظ الناجح
                    If _currentPendingInvoiceID.HasValue Then
                        _repo.DeletePendingInvoice(_currentPendingInvoiceID.Value)
                        _currentPendingInvoiceID = Nothing
                        _currentPendingInvoiceNumber = ""
                    End If

                    invoice.InvoiceNumber = savedInvNum
                    Dim custNameStr As String = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerName, If(Not String.IsNullOrWhiteSpace(txtCustomer.Text) AndAlso txtCustomer.Text.Trim() <> "عميل نقدي", txtCustomer.Text.Trim(), "عميل نقدي"))

                    ' 1. الطباعة التلقائية لإيصال العميل (إذا كانت مفعلة في الإعدادات)
                    Dim autoPrintReceipt As Boolean = SettingsManager.GetBoolSettingDual(SettingsKeys.PrinterAutoPrint, SettingsKeys.PrintReceiptOnPayment, True)
                    If autoPrintReceipt Then
                        Try
                            RestaurantPrintManager.PrintCustomerReceipt(invoice, custNameStr, SelectedTableName, SelectedDriverName)
                        Catch printEx As Exception
                            Logger.LogError("btnPay_Click - PrintCustomerReceipt", printEx)
                        End Try
                    End If

                    ' 2. طباعة بون المطبخ أو ورقة المتابعة للأصناف المضافة
                    Dim staffName As String = If(Session.CurrentUserfullName IsNot Nothing, Session.CurrentUserfullName, "كاشير")
                    Dim orderDesc As String
                    If CurrentOrderType = OrderType.DineIn Then
                        orderDesc = "صالة - طاولة: " & SelectedTableName
                        If custNameStr <> "عميل نقدي" Then orderDesc &= " | العميل: " & custNameStr
                    ElseIf CurrentOrderType = OrderType.Delivery Then
                        orderDesc = "دليفري | الطيار: " & SelectedDriverName
                        If custNameStr <> "عميل نقدي" Then orderDesc &= " | العميل: " & custNameStr
                    Else
                        orderDesc = "تيك أوي"
                        If custNameStr <> "عميل نقدي" Then orderDesc &= " | العميل: " & custNameStr
                    End If

                    If wasAlreadyHeld Then
                        ' إذا كانت الفاتورة معلقة مسبقاً، نتحقق من وجود أصناف أُضيفت حديثاً
                        Dim newAddedItems = GetNewlyAddedItems(invoice.Details)
                        If newAddedItems.Count > 0 Then
                            Dim autoFollowUp = SettingsManager.GetBoolSetting(SettingsKeys.AutoPrintFollowUpTicket, True)
                            If autoFollowUp Then
                                Try
                                    RestaurantPrintManager.PrintKitchenTicket(
                                        orderNumber:=savedInvNum,
                                        orderTypeDesc:=orderDesc,
                                        tableName:=SelectedTableName,
                                        staffName:=staffName,
                                        items:=newAddedItems,
                                        ticketTitle:="ورقة متابعة فاتورة #" & savedInvNum
                                    )
                                Catch exKot As Exception
                                    Logger.LogError("btnPay_Click - PrintKitchenFollowUpTicket", exKot)
                                End Try
                            End If

                            ' إرسال الأصناف المضافة لشاشة المطبخ KDS
                            Try
                                Dim kOrder As New KitchenOrderModel With {
                                    .OrderNumber = savedInvNum,
                                    .OrderType = CByte(CurrentOrderType),
                                    .TableID = SelectedTableID,
                                    .TableName = SelectedTableName,
                                    .CustomerName = custNameStr,
                                    .ServerName = staffName,
                                    .Status = KitchenOrderStatus.New
                                }
                                For Each itm In newAddedItems
                                    kOrder.Items.Add(New KitchenOrderItemModel With {
                                        .ProductID = itm.ProductID,
                                        .ProductName = itm.ProductName,
                                        .SizeName = itm.SizeName,
                                        .AddonsText = itm.AddonsText,
                                        .Quantity = itm.Quantity,
                                        .Notes = itm.Notes
                                    })
                                Next
                                Await _repo.CreateKitchenOrderAsync(kOrder)
                            Catch exKds As Exception
                                Logger.LogError("btnPay_Click - KDS FollowUp", exKds)
                            End Try
                        End If
                    Else
                        ' طلب دفع فوري بالكامل
                        Dim autoKitchen = SettingsManager.GetBoolSetting(SettingsKeys.AutoPrintKitchenTicket, True)
                        If autoKitchen Then
                            Try
                                RestaurantPrintManager.PrintKitchenTicket(
                                    orderNumber:=savedInvNum,
                                    orderTypeDesc:=orderDesc,
                                    tableName:=SelectedTableName,
                                    staffName:=staffName,
                                    items:=invoice.Details,
                                    ticketTitle:="طلب تجهيز المطبخ"
                                )
                            Catch exKot As Exception
                                Logger.LogError("btnPay_Click - PrintKitchenTicket", exKot)
                            End Try
                        End If

                        ' إرسال الطلب لشاشة المطبخ الرقمية (KDS)
                        Try
                            Dim kOrder As New KitchenOrderModel With {
                                .OrderNumber = savedInvNum,
                                .OrderType = CByte(CurrentOrderType),
                                .TableID = SelectedTableID,
                                .TableName = SelectedTableName,
                                .CustomerName = custNameStr,
                                .ServerName = staffName,
                                .Status = KitchenOrderStatus.New
                            }
                            For Each itm In invoice.Details
                                kOrder.Items.Add(New KitchenOrderItemModel With {
                                    .ProductID = itm.ProductID,
                                    .ProductName = itm.ProductName,
                                    .SizeName = itm.SizeName,
                                    .AddonsText = itm.AddonsText,
                                    .Quantity = itm.Quantity,
                                    .Notes = itm.Notes
                                })
                            Next
                            Await _repo.CreateKitchenOrderAsync(kOrder)
                        Catch exKds As Exception
                            Logger.LogError("btnPay_Click - KDS", exKds)
                        End Try
                    End If

                    ' 3. حفظ بيانات الفاتورة لإمكانية إعادة طباعتها فوراً
                    _lastSavedInvoice = invoice
                    _lastSavedCustomerName = custNameStr
                    _lastSavedTableName = SelectedTableName
                    _lastSavedDriverName = SelectedDriverName

                    MessageBox.Show("تم حفظ وطباعة الفاتورة بنجاح برقم: " & savedInvNum, "حفظ الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ResetPOSForm()
                    UpdateNextInvoiceNumber() ' تحديث رقم الفاتورة القادمة تلقائياً

                Catch ex As Exception
                    Logger.LogError("btnPay_Click - SaveInvoiceAsync", ex)
                    MessageBox.Show("حدث خطأ أثناء حفظ الفاتورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    btnPay.Enabled = True
                End Try

            End If
        End Using

    End Sub

    ' =========================================================
    ' تفريغ الشاشة وإتاحة الفاتورة التالية
    ' =========================================================
    Private Sub ResetPOSForm()
        dgvInvoice.Rows.Clear()

        CurrentCustomer = Nothing
        txtCustomer.Text = ""
        SelectedTableID = Nothing
        SelectedTableName = ""
        SelectedDriverID = Nothing
        SelectedDriverName = ""
        DeliveryFee = 0
        DineInServiceFee = 0
        TaxAmount = 0
        CurrentReservationDeposit = 0
        CurrentReservationID = Nothing
        _currentPendingInvoiceID = Nothing
        _currentPendingInvoiceNumber = ""
        _recalledOriginalItems.Clear()

        ApplyDefaultPOSSettings()

        btnTakeaway.Checked = True
        CurrentOrderType = OrderType.Takeaway
        lblOrderTypeStatus.Text = "نوع الطلب: تيك أوي"
        UpdateHoldButtonText()

        CalculatePOSGrandTotal()
    End Sub

    ''' <summary>
    ''' التقاط لقطة فورية للأصناف الموجودة داخل الفاتورة عند استرجاعها
    ''' للمقارنة لاحقاً وطباعة الأصناف الإضافية الجديدة فقط في ورقة المتابعة
    ''' </summary>
    Private Sub SnapshotRecalledItems()
        _recalledOriginalItems.Clear()
        For Each row As DataGridViewRow In dgvInvoice.Rows
            If Not row.IsNewRow Then
                Dim itm As New InvoiceDetailModel With {
                    .ProductID = Convert.ToInt32(row.Cells("colProductID").Value),
                    .ProductName = If(row.Cells("colProductName").Value IsNot Nothing, row.Cells("colProductName").Value.ToString(), ""),
                    .SizeName = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), ""),
                    .AddonsText = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), ""),
                    .UnitPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value),
                    .Quantity = Convert.ToInt32(row.Cells("colQuantity").Value),
                    .TotalPrice = Convert.ToDecimal(row.Cells("colTotalPrice").Value),
                    .Notes = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")
                }
                _recalledOriginalItems.Add(itm)
            End If
        Next
    End Sub

    ''' <summary>
    ''' استخراج الأصناف أو الكميات التي تمت إضافتها حديثاً بعد استرجاع الفاتورة المعلقة
    ''' </summary>
    Private Function GetNewlyAddedItems(currentItems As List(Of InvoiceDetailModel)) As List(Of InvoiceDetailModel)
        Dim result As New List(Of InvoiceDetailModel)()
        If currentItems Is Nothing OrElse currentItems.Count = 0 Then Return result

        ' إذا لم تكن هناك أصناف سابقة محفوظة، كل الأصناف الحالية جديدة
        If _recalledOriginalItems Is Nothing OrElse _recalledOriginalItems.Count = 0 Then
            Return New List(Of InvoiceDetailModel)(currentItems)
        End If

        ' نسخة عمل من الأصناف الأصلية لخصم الكميات المطابقة تدريجياً
        Dim originalCopies = _recalledOriginalItems.Select(Function(x) New InvoiceDetailModel With {
            .ProductID = x.ProductID,
            .ProductName = x.ProductName,
            .SizeName = If(x.SizeName, ""),
            .AddonsText = If(x.AddonsText, ""),
            .Notes = If(x.Notes, ""),
            .Quantity = x.Quantity
        }).ToList()

        For Each cur In currentItems
            Dim curSize = If(cur.SizeName, "").Trim()
            Dim curAddons = If(cur.AddonsText, "").Trim()
            Dim curNotes = If(cur.Notes, "").Trim()

            ' البحث عن صنف مطابق في الأصناف الأصلية (نفس الصنف، الحجم، الإضافات، والملاحظات)
            Dim match = originalCopies.FirstOrDefault(Function(orig) orig.ProductID = cur.ProductID AndAlso
                                                                     If(orig.SizeName, "").Trim().Equals(curSize, StringComparison.OrdinalIgnoreCase) AndAlso
                                                                     If(orig.AddonsText, "").Trim().Equals(curAddons, StringComparison.OrdinalIgnoreCase) AndAlso
                                                                     If(orig.Notes, "").Trim().Equals(curNotes, StringComparison.OrdinalIgnoreCase))

            If match Is Nothing Then
                ' صنف جديد لم يكن موجوداً
                result.Add(New InvoiceDetailModel With {
                    .ProductID = cur.ProductID,
                    .ProductName = cur.ProductName,
                    .SizeName = cur.SizeName,
                    .AddonsText = cur.AddonsText,
                    .UnitPrice = cur.UnitPrice,
                    .Quantity = cur.Quantity,
                    .TotalPrice = cur.UnitPrice * cur.Quantity,
                    .Notes = cur.Notes
                })
            Else
                ' صنف موجود مسبقاً، نتحقق هل زادت كميته
                If cur.Quantity > match.Quantity Then
                    Dim addedQty = cur.Quantity - match.Quantity
                    result.Add(New InvoiceDetailModel With {
                        .ProductID = cur.ProductID,
                        .ProductName = cur.ProductName,
                        .SizeName = cur.SizeName,
                        .AddonsText = cur.AddonsText,
                        .UnitPrice = cur.UnitPrice,
                        .Quantity = addedQty,
                        .TotalPrice = cur.UnitPrice * addedQty,
                        .Notes = cur.Notes
                    })
                    match.Quantity = 0
                Else
                    match.Quantity -= cur.Quantity
                End If
            End If
        Next

        Return result
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        ResetPOSForm()
    End Sub

    ' =========================================================
    ' زر حذف صنف محدد من الفاتورة
    ' =========================================================
    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click
        If dgvInvoice.CurrentRow IsNot Nothing AndAlso Not dgvInvoice.CurrentRow.IsNewRow Then
            Dim prodName As String = If(dgvInvoice.CurrentRow.Cells("colProductName").Value IsNot Nothing, dgvInvoice.CurrentRow.Cells("colProductName").Value.ToString(), "هذا الصنف")
            dgvInvoice.Rows.Remove(dgvInvoice.CurrentRow)

            ' إعادة ترقيم المسلسل
            For i As Integer = 0 To dgvInvoice.Rows.Count - 1
                dgvInvoice.Rows(i).Cells("colIndex").Value = i + 1
            Next

            CalculatePOSGrandTotal()
        Else
            MessageBox.Show("برجاء اختيار الصنف المراد حذفه من جدول الفاتورة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' =========================================================
    ' التحكم السريع في الكميات (+ / - / حذف بالزر)
    ' =========================================================
    Private Sub UpdateRowQuantity(rowIndex As Integer, delta As Integer)
        If rowIndex >= 0 AndAlso rowIndex < dgvInvoice.Rows.Count Then
            Dim row = dgvInvoice.Rows(rowIndex)
            Dim currentQty As Integer = Convert.ToInt32(row.Cells("colQuantity").Value)
            Dim newQty As Integer = currentQty + delta

            If newQty <= 0 Then
                dgvInvoice.Rows.RemoveAt(rowIndex)
            Else
                Dim unitPrice As Decimal = Convert.ToDecimal(row.Cells("colUnitPrice").Value)
                row.Cells("colQuantity").Value = newQty
                row.Cells("colTotalPrice").Value = unitPrice * newQty
            End If

            For i As Integer = 0 To dgvInvoice.Rows.Count - 1
                dgvInvoice.Rows(i).Cells("colIndex").Value = i + 1
            Next

            CalculatePOSGrandTotal()
        End If
    End Sub

    Private Sub dgvInvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvInvoice.KeyDown
        If dgvInvoice.CurrentRow IsNot Nothing AndAlso Not dgvInvoice.CurrentRow.IsNewRow Then
            If e.KeyCode = Keys.Delete Then
                btnDeleteRow_Click(Nothing, Nothing)
                e.Handled = True
            ElseIf e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus Then
                UpdateRowQuantity(dgvInvoice.CurrentRow.Index, +1)
                e.Handled = True
            ElseIf e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
                UpdateRowQuantity(dgvInvoice.CurrentRow.Index, -1)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvInvoice_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' الضغط المزدوج على عمود الكمية يزود الكمية بمقدار 1
            If e.ColumnIndex = dgvInvoice.Columns("colQuantity").Index OrElse e.ColumnIndex = dgvInvoice.Columns("colUnitPrice").Index Then
                UpdateRowQuantity(e.RowIndex, +1)
            Else
                ' الضغط المزدوج على عمود الملاحظات أو اسم الصنف أو أي خلية أخرى في السطر يفتح نافذة اختيار وإضافة تعليق المطبخ
                OpenKitchenCommentDialog(e.RowIndex)
            End If
        End If
    End Sub

    Public Sub OpenKitchenCommentDialog(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvInvoice.Rows.Count Then Return
        Dim row = dgvInvoice.Rows(rowIndex)
        Dim prodName = If(row.Cells("colProductName").Value IsNot Nothing, row.Cells("colProductName").Value.ToString(), "")
        Dim currentNote = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")

        Using dlg As New frmSelectKitchenComment(prodName, currentNote)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                row.Cells("colNotes").Value = dlg.SelectedComment
                dgvInvoice.InvalidateRow(rowIndex)
            End If
        End Using
    End Sub

    Private Sub btnAddCategoryForm_Click(sender As Object, e As EventArgs)
        Dim frm As New Categories()
        frm.ShowDialog()
        LoadCategories()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd - hh:mm:ss tt")
    End Sub

    Private Sub btnSelectCustomer_Click(sender As Object, e As EventArgs) Handles btnSelectCustomer.Click
        Using frmSelect As New FrmSelectCustomer(_repo)
            If frmSelect.ShowDialog() = DialogResult.OK Then
                CurrentCustomer = frmSelect.SelectedCustomer
                txtCustomer.Text = CurrentCustomer.CustomerName
            End If
        End Using
    End Sub

    Private Sub SetupTablesContextMenu()
        _tablesContextMenu = New ContextMenuStrip()
        _tablesContextMenu.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        _tablesContextMenu.RightToLeft = RightToLeft.Yes

        Dim itemSelectTable = _tablesContextMenu.Items.Add("اختيار / فتح طاولة صالة (F10)")
        itemSelectTable.Image = My.Resources.dinning_hall
        AddHandler itemSelectTable.Click, Sub() btnDineIn.PerformClick()

        Dim itemTransfer = _tablesContextMenu.Items.Add("نقل طلب الطاولة الحالية إلى طاولة أخرى")
        AddHandler itemTransfer.Click, Sub() TransferCurrentTable()

        Dim itemKOT = _tablesContextMenu.Items.Add("طباعة طلب المطبخ / البار الحالي (KOT)")
        AddHandler itemKOT.Click, Sub() PrintCurrentKOT()

        Dim itemReprint = _tablesContextMenu.Items.Add("إعادة طباعة آخر فاتورة مبيعات (F9)")
        AddHandler itemReprint.Click, Sub() ReprintLastInvoice()

        Dim itemKDS = _tablesContextMenu.Items.Add("شاشة المطبخ الرقمية (KDS - F11)")
        AddHandler itemKDS.Click, Sub() OpenKitchenDisplay()

        Dim itemSplit = _tablesContextMenu.Items.Add("تقسيم الفاتورة وسداد الحصص (Split Bill - F8)")
        AddHandler itemSplit.Click, Sub() OpenSplitBill()

        Dim itemReservations = _tablesContextMenu.Items.Add("إدارة حجوزات طاولات الصالة والعربون")
        AddHandler itemReservations.Click, Sub() OpenTableReservations()

        _tablesContextMenu.Items.Add(New ToolStripSeparator())

        Dim itemManage = _tablesContextMenu.Items.Add("إدارة أقسام وطاولات الصالة")
        AddHandler itemManage.Click, Sub()
                                         Dim frmRT As New frmRestaurantTables()
                                         frmRT.ShowDialog()
                                     End Sub

        btntables.ContextMenuStrip = _tablesContextMenu
    End Sub

    Private Sub btntables_Click(sender As Object, e As EventArgs) Handles btntables.Click
        If _tablesContextMenu IsNot Nothing Then
            _tablesContextMenu.Show(btntables, New Point(0, -_tablesContextMenu.Height))
        Else
            Dim frmRT As New frmRestaurantTables
            frmRT.ShowDialog()
        End If
    End Sub

    Private Sub btnDineIn_Click(sender As Object, e As EventArgs) Handles btnDineIn.Click
        CurrentOrderType = OrderType.DineIn
        SelectedDriverID = Nothing
        SelectedDriverName = ""
        DeliveryFee = 0
        lblDeliveryFee.Text = "0.00"
        UpdateHoldButtonText()

        Using frmTables As New FrmSelectTable(_repo)
            If frmTables.ShowDialog() = DialogResult.OK Then
                SelectedTableID = frmTables.SelectedTableID
                SelectedTableName = frmTables.SelectedTableName
                lblOrderTypeStatus.Text = "نوع الطلب: صالة | الطاولة: " & SelectedTableName
                UpdateHoldButtonText()

                ' إذا تم اختيار طاولة مشغولة، استرجاع طلبها تلقائياً
                If frmTables.IsOccupiedSelected AndAlso SelectedTableID.HasValue Then
                    LoadPendingInvoiceForTable(SelectedTableID.Value)
                End If

                ' إذا كان للطاولة حجز نشط وتم تسكينه
                If frmTables.HasActiveReservation AndAlso frmTables.ActiveReservation IsNot Nothing Then
                    CurrentReservationDeposit = frmTables.ActiveReservation.DepositAmount
                    CurrentReservationID = frmTables.ActiveReservation.ReservationID
                    txtCustomer.Text = frmTables.ActiveReservation.CustomerName
                    lblOrderTypeStatus.Text = $"نوع الطلب: صالة | {SelectedTableName} (حجز: {frmTables.ActiveReservation.CustomerName} - عربون: {CurrentReservationDeposit:N2} {CurrencySymbol})"
                    MessageBox.Show($"تم تسكين العميل ({frmTables.ActiveReservation.CustomerName}) بنجاح!" & vbCrLf &
                                    $"سيتم خصم مبلغ العربون ({CurrentReservationDeposit:N2} {CurrencySymbol}) تلقائياً من إجمالي الفاتورة.",
                                    "تسكين حجز الطاولة", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                CalculatePOSGrandTotal()
            Else
                btnTakeaway.Checked = True
                btnTakeaway_Click(Nothing, Nothing)
            End If
        End Using
    End Sub

    ' =========================================================
    ' استرجاع فاتورة وطلب طاولة مشغولة في الصالة
    ' =========================================================
    Public Sub LoadPendingInvoiceForTable(tableID As Integer)
        Try
            Dim pendingItem = _repo.GetPendingInvoiceByTableID(tableID)
            If pendingItem IsNot Nothing Then
                dgvInvoice.Rows.Clear()
                _currentPendingInvoiceID = pendingItem.PendingID
                _currentPendingInvoiceNumber = If(Not String.IsNullOrWhiteSpace(pendingItem.PendingNumber), pendingItem.PendingNumber, pendingItem.PendingID.ToString())
                CurrentOrderType = OrderType.DineIn
                btnDineIn.Checked = True
                UpdateHoldButtonText()

                If pendingItem.CustomerID.HasValue AndAlso pendingItem.CustomerID.Value > 0 Then
                    CurrentCustomer = New CustomerModel With {
                        .CustomerID = pendingItem.CustomerID.Value,
                        .CustomerName = pendingItem.CustomerName
                    }
                    txtCustomer.Text = CurrentCustomer.CustomerName
                ElseIf Not String.IsNullOrWhiteSpace(pendingItem.CustomerName) AndAlso pendingItem.CustomerName <> "عميل نقدي" Then
                    txtCustomer.Text = pendingItem.CustomerName
                End If

                If Not String.IsNullOrWhiteSpace(pendingItem.InvoiceJSON) Then
                    If pendingItem.InvoiceJSON.Trim().StartsWith("[") Then
                        Dim items = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of InvoiceDetailModel))(pendingItem.InvoiceJSON)
                        If items IsNot Nothing Then
                            For Each itm In items
                                dgvInvoice.Rows.Add(
                                    dgvInvoice.Rows.Count + 1,
                                    itm.ProductName,
                                    itm.SizeName,
                                    itm.AddonsText,
                                    itm.UnitPrice,
                                    itm.Quantity,
                                    itm.TotalPrice,
                                    itm.Notes,
                                    itm.ProductID
                                )
                            Next
                        End If
                    Else
                        Dim rowsData() As String = pendingItem.InvoiceJSON.Split("~"c)
                        For Each rData In rowsData
                            Dim parts() As String = rData.Split("|"c)
                            If parts.Length >= 8 Then
                                dgvInvoice.Rows.Add(
                                    dgvInvoice.Rows.Count + 1,
                                    parts(1), parts(2), parts(3),
                                    Convert.ToDecimal(parts(4)),
                                    Convert.ToInt32(parts(5)),
                                    Convert.ToDecimal(parts(6)),
                                    parts(7),
                                    Convert.ToInt32(parts(0))
                                )
                            End If
                        Next
                    End If
                End If

                CalculatePOSGrandTotal()
                SnapshotRecalledItems()
                MessageBox.Show($"تم استرجاع طلب الطاولة [{SelectedTableName}] بنجاح، يمكنك تعديل الأصناف أو إتمام المحاسبة.", "طلب طاولة مفتوح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Logger.LogError("LoadPendingInvoiceForTable", ex)
            MessageBox.Show("حدث خطأ أثناء استرجاع طلب الطاولة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' نقل الطلب الحالي إلى طاولة أخرى
    ' =========================================================
    Public Sub TransferCurrentTable()
        If Not SelectedTableID.HasValue Then
            MessageBox.Show("برجاء تحديد طاولة صالة أولاً لنقلها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' لو كان هناك أصناف في الجدول غير معلقة بعد، نعلقها تلقائياً
        If dgvInvoice.Rows.Count > 0 AndAlso Not _currentPendingInvoiceID.HasValue Then
            btnHoldInvoice.PerformClick()
            Return
        End If

        Using frmTarget As New FrmSelectTable(_repo)
            frmTarget.Text = "اختر الطاولة الفارغة المراد نقل الطلب إليها"
            If frmTarget.ShowDialog() = DialogResult.OK Then
                If frmTarget.IsOccupiedSelected Then
                    MessageBox.Show("لا يمكن النقل إلى طاولة مشغولة بالفعل!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim targetTableID As Integer = frmTarget.SelectedTableID
                Dim targetTableName As String = frmTarget.SelectedTableName

                If _repo.TransferTable(SelectedTableID.Value, targetTableID, targetTableName) Then
                    Dim oldName As String = SelectedTableName
                    SelectedTableID = targetTableID
                    SelectedTableName = targetTableName
                    lblOrderTypeStatus.Text = "نوع الطلب: صالة | الطاولة: " & SelectedTableName
                    MessageBox.Show($"تم نقل الطلب بنجاح من [{oldName}] إلى [{targetTableName}]", "نجاح النقل", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("حدث خطأ أثناء تحديث بيانات الطاولة في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Using
    End Sub

    ' =========================================================
    ' طباعة بون المطبخ (KOT) للأصناف الحالية
    ' =========================================================
    Public Sub PrintCurrentKOT()
        If dgvInvoice.Rows.Count = 0 Then
            MessageBox.Show("لا توجد أصناف في الفاتورة لإرسالها للمطبخ!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim itemsList As New List(Of InvoiceDetailModel)
        For Each row As DataGridViewRow In dgvInvoice.Rows
            If Not row.IsNewRow Then
                itemsList.Add(New InvoiceDetailModel With {
                    .ProductID = Convert.ToInt32(row.Cells("colProductID").Value),
                    .ProductName = row.Cells("colProductName").Value.ToString(),
                    .SizeName = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), ""),
                    .AddonsText = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), ""),
                    .UnitPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value),
                    .Quantity = Convert.ToInt32(row.Cells("colQuantity").Value),
                    .TotalPrice = Convert.ToDecimal(row.Cells("colTotalPrice").Value),
                    .Notes = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")
                })
            End If
        Next

        Try
            Dim kotTypeDesc As String = If(CurrentOrderType = OrderType.DineIn, "صالة - طاولة: " & SelectedTableName, If(CurrentOrderType = OrderType.Delivery, "دليفري | الطيار: " & SelectedDriverName, "تيك أوي"))
            Dim staffName As String = If(Session.CurrentUserfullName IsNot Nothing, Session.CurrentUserfullName, "كاشير")
            Dim title As String = "طلب تجهيز المطبخ"

            If _currentPendingInvoiceID.HasValue Then
                Dim newItems = GetNewlyAddedItems(itemsList)
                If newItems.Count > 0 Then
                    Dim pNum = If(Not String.IsNullOrWhiteSpace(_currentPendingInvoiceNumber), _currentPendingInvoiceNumber, _currentPendingInvoiceID.Value.ToString())
                    title = "ورقة متابعة فاتورة #" & pNum
                    itemsList = newItems
                End If
            End If

            RestaurantPrintManager.PrintKitchenTicket("طلب يدوي", kotTypeDesc, SelectedTableName, staffName, itemsList, ticketTitle:=title)
            MessageBox.Show("تمت طباعة بون المطبخ (KOT) بنجاح!", "طباعة المطبخ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Logger.LogError("PrintCurrentKOT", ex)
            MessageBox.Show("حدث خطأ أثناء طباعة بون المطبخ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' إعادة طباعة آخر فاتورة مبيعات
    ' =========================================================
    Public Sub ReprintLastInvoice()
        If _lastSavedInvoice IsNot Nothing Then
            Try
                RestaurantPrintManager.PrintCustomerReceipt(_lastSavedInvoice, _lastSavedCustomerName, _lastSavedTableName, _lastSavedDriverName)
                MessageBox.Show("تمت إعادة طباعة الفاتورة بنجاح.", "إعادة الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("حدث خطأ أثناء إعادة الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Dim lastInvNum As String = _repo.GetLastSavedInvoiceNumber()
            If Not String.IsNullOrEmpty(lastInvNum) Then
                Dim inv = _repo.GetInvoiceByNumber(lastInvNum)
                If inv IsNot Nothing Then
                    RestaurantPrintManager.PrintCustomerReceipt(inv, "عميل نقدي", "", "")
                    MessageBox.Show("تمت إعادة طباعة الفاتورة رقم " & lastInvNum & " بنجاح.", "إعادة الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            End If
            MessageBox.Show("لا توجد فواتير مسجلة في الجلسة لإعادة طباعتها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' =========================================================
    ' اختصارات لوحة المفاتيح السريعة لنقاط البيع
    ' =========================================================
    Private Sub frmPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                e.Handled = True
                btnHoldInvoice.PerformClick()
            Case Keys.F7
                e.Handled = True
                btnPendingInvoices.PerformClick()
            Case Keys.F8
                e.Handled = True
                OpenSplitBill()
            Case Keys.F9
                e.Handled = True
                ReprintLastInvoice()
            Case Keys.F10
                e.Handled = True
                btnDineIn.PerformClick()
            Case Keys.F11
                e.Handled = True
                OpenKitchenDisplay()
            Case Keys.F12
                e.Handled = True
                btnPay.PerformClick()
        End Select
    End Sub

    Public Sub OpenKitchenDisplay()
        Dim frmKds As New FrmKitchenDisplay()
        frmKds.Show()
    End Sub

    Public Sub OpenTableReservations()
        Dim frmRes As New FrmTableReservations()
        frmRes.ShowDialog()
    End Sub

    Public Async Sub OpenSplitBill()
        If dgvInvoice.Rows.Count = 0 Then
            MessageBox.Show("لا يمكن تقسيم فاتورة فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        CalculatePOSGrandTotal()
        Dim itemsTotal As Decimal = GetInvoiceTotalFromGrid()
        Dim currentDineInFee As Decimal = If(CurrentOrderType = OrderType.DineIn, If(IsDineInServiceFeePercent, itemsTotal * DineInServiceFee / 100, DineInServiceFee), 0)
        Dim netToSplit As Decimal = itemsTotal + currentDineInFee + TaxAmount
        If CurrentOrderType = OrderType.Delivery Then netToSplit += DeliveryFee

        If CurrentReservationDeposit > 0 Then
            netToSplit = Math.Max(0, netToSplit - CurrentReservationDeposit)
        End If

        Dim tableDisplay = If(Not String.IsNullOrEmpty(SelectedTableName), SelectedTableName, "طلب عام")
        Dim invNumDisplay = If(Not String.IsNullOrEmpty(lblInvoiceNumber.Text), lblInvoiceNumber.Text, "فاتورة جديدة")

        Using frmSplit As New FrmSplitBill(netToSplit, tableDisplay, invNumDisplay)
            If frmSplit.ShowDialog() = DialogResult.OK AndAlso frmSplit.IsFullySettled Then
                Dim custID As Integer? = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerID, CType(Nothing, Integer?))
                Dim currentBranchID As Integer = 1
                Integer.TryParse(SettingsManager.GetSettingOrDefault("CurrentBranchID", "1"), currentBranchID)
                Dim currentStoreID As Integer = 1
                Integer.TryParse(SettingsManager.GetSettingOrDefault("CurrentStoreID", "1"), currentStoreID)

                Dim shiftIdVal As Integer = 1
                If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                    shiftIdVal = ShiftSession.CurrentShift.ShiftID
                End If

                Dim noteText = $"[فاتورة مقسمة مسددة بالكامل - {frmSplit.GuestCount} أفراد]"
                If CurrentReservationDeposit > 0 Then
                    noteText &= $" | [تم خصم عربون حجز مسبق بقيمة {CurrentReservationDeposit:N2} {CurrencySymbol}]"
                End If

                Dim splitTreasuryID As Integer? = Nothing
                If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing AndAlso ShiftSession.CurrentShift.TreasuryID.HasValue AndAlso ShiftSession.CurrentShift.TreasuryID.Value > 0 Then
                    splitTreasuryID = ShiftSession.CurrentShift.TreasuryID.Value
                Else
                    Dim defT = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)
                    If defT > 0 Then splitTreasuryID = defT
                End If

                Dim invoice As New InvoiceModel With {
                    .OrderType = CByte(CurrentOrderType),
                    .ShiftID = shiftIdVal,
                    .UserID = If(Session.CurrentUserID > 0, Session.CurrentUserID, 1),
                    .CustomerID = custID,
                    .TableID = SelectedTableID,
                    .DriverID = SelectedDriverID,
                    .BranchID = currentBranchID,
                    .StoreID = currentStoreID,
                    .DeliveryFee = DeliveryFee,
                    .TotalBeforeDiscount = netToSplit + CurrentReservationDeposit,
                    .DiscountAmount = 0,
                    .NetTotal = netToSplit,
                    .PaidAmount = netToSplit,
                    .RemainingAmount = 0,
                    .IsCredit = False,
                    .TreasuryID = splitTreasuryID,
                    .Notes = noteText
                }

                For Each row As DataGridViewRow In dgvInvoice.Rows
                    If Not row.IsNewRow Then
                        invoice.Details.Add(New InvoiceDetailModel With {
                            .ProductID = Convert.ToInt32(row.Cells("colProductID").Value),
                            .ProductName = row.Cells("colProductName").Value.ToString(),
                            .SizeName = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), ""),
                            .AddonsText = If(row.Cells("colAddons").Value IsNot Nothing, row.Cells("colAddons").Value.ToString(), ""),
                            .UnitPrice = Convert.ToDecimal(row.Cells("colUnitPrice").Value),
                            .Quantity = Convert.ToInt32(row.Cells("colQuantity").Value),
                            .TotalPrice = Convert.ToDecimal(row.Cells("colTotalPrice").Value),
                            .Notes = If(row.Cells("colNotes").Value IsNot Nothing, row.Cells("colNotes").Value.ToString(), "")
                        })
                    End If
                Next

                btnPay.Enabled = False
                Try
                    Dim savedInvNum As String = Await _repo.SaveInvoiceAsync(invoice)

                    If ShiftSession.HasActiveShift AndAlso ShiftSession.CurrentShift IsNot Nothing Then
                        ShiftSession.CurrentShift.TotalSales += invoice.PaidAmount
                        ShiftSession.CurrentShift.TotalOrders += 1
                    End If

                    If CurrentOrderType = OrderType.DineIn AndAlso SelectedTableID.HasValue Then
                        _repo.UpdateTableStatus(SelectedTableID.Value, 1)
                    End If

                    If CurrentReservationID.HasValue AndAlso SelectedTableID.HasValue Then
                        _repo.CheckInReservation(CurrentReservationID.Value, SelectedTableID.Value)
                        CurrentReservationID = Nothing
                        CurrentReservationDeposit = 0
                    End If

                    Dim custNameStr As String = If(CurrentCustomer IsNot Nothing, CurrentCustomer.CustomerName, "عميل نقدي")
                    Try
                        RestaurantPrintManager.PrintCustomerReceipt(invoice, custNameStr, SelectedTableName, SelectedDriverName)
                    Catch printEx As Exception
                        Logger.LogError("OpenSplitBill - PrintCustomerReceipt", printEx)
                    End Try

                    _lastSavedInvoice = invoice
                    _lastSavedCustomerName = custNameStr
                    _lastSavedTableName = SelectedTableName
                    _lastSavedDriverName = SelectedDriverName

                    MessageBox.Show($"تم سداد الفاتورة المقسمة بنجاح وحفظها برقم: {savedInvNum}", "نجاح السداد", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ResetPOSForm()
                Catch ex As Exception
                    Logger.LogError("OpenSplitBill - SaveInvoiceAsync", ex)
                    MessageBox.Show("حدث خطأ أثناء حفظ الفاتورة المقسمة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    btnPay.Enabled = True
                End Try
            End If
        End Using
    End Sub

End Class
