Imports System.Data.SqlClient
Imports System.IO.Ports
Imports System.Drawing.Printing
Imports System.IO

''' <summary>
''' فورم الاعدادات العامة - يحتوي على 3 تبويبات:
''' 1. الاعدادات العامة (معلومات المحل + الطابعة)
''' 2. قاعدة البيانات (إعدادات الاتصال)
''' 3. Scanner Barcode
''' </summary>
Public Class Settings
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim WithEvents serial As SerialPort
    Private ReadOnly _tips As New ToolTip() With {.AutoPopDelay = 6000, .InitialDelay = 300, .ReshowDelay = 100}

    ' ══ عناصر تبويب الاعدادات العامة ══
    Private txtShopName As TextBox
    Private txtShopPhone As TextBox
    Private txtShopPhone2 As TextBox
    Private txtShopAddress As TextBox
    Private txtShopTax As TextBox
    Private txtFooterText As TextBox
    Private txtDeliveryText As TextBox
    Private cmbCurrency As ComboBox
    Private cmbBusinessType As ComboBox
    Private txtLogoPath As TextBox
    Private picLogoPreview As PictureBox
    Private cmbThermalPrinter As ComboBox
    Private cmbNormalPrinter As ComboBox
    Private btnRefreshPrinters As Button
    Private btnBrowseLogo As Button
    Private btnSaveGeneral As Button
    Private btnTestThermal As Button
    Private rbStyleSimple As RadioButton
    Private rbStyleAdvanced As RadioButton
    Private chkPrintLogo As CheckBox
    Private chkPrintBarcode As CheckBox
    Private chkPrintPreview As CheckBox

    ' ══ عناصر تبويب طابعة الباركود (TabPage4) ══
    Private cmbBarcodePrinter As ComboBox
    Private numBarcodeLabelWidth As NumericUpDown
    Private numBarcodeLabelHeight As NumericUpDown
    Private numBarcodeCopies As NumericUpDown
    Private numBarcodeFontSize As NumericUpDown
    Private txtBarcodeFooter As TextBox
    Private chkBarcodeShowName As CheckBox
    Private chkBarcodeShowPrice As CheckBox
    Private chkBarcodeShowStoreName As CheckBox
    Private btnSaveBarcodePrinter As Button
    Private btnTestBarcodePrinter As Button
    Private btnRefreshBarcodePrinters As Button

    ' ══ عناصر تبويب قاعدة البيانات ══
    Private txtDbServer As ComboBox
    Private btnDetectServers As Button
    Private txtDbName As TextBox
    Private txtDbUser As TextBox
    Private txtDbPassword As TextBox
    Private chkWindowsAuth As CheckBox
    Private btnTestDbConnection As Button
    Private btnSaveDbSettings As Button
    Private lblDbStatus As Label
    Private lblDbUser As Label
    Private lblDbPassword As Label

    ' ══ عناصر الإعدادات المتقدمة للاسكنر (TabPage3) ══
    Private cmbBaudRate As ComboBox
    Private cmbDataBits As ComboBox
    Private cmbParity As ComboBox
    Private cmbStopBits As ComboBox
    Private txtScanTestResult As TextBox
    Private lblScanTestHint As Label
    Private _scannerTesting As Boolean = False

    '══════════════════════════════════════════════════════════════
    ' عند تحميل الفورم - نحمل كل الإعدادات
    '══════════════════════════════════════════════════════════════
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' التجاوب مع الشاشة: ملاءمة حجم الفورم للمساحة المتاحة + توسيطه
        LayoutHelper.FitToWorkingArea(Me)

        ' بناء عناصر التحكم الجديدة
        InitializeCustomControls()

        ' تبويب الباركود (Scanner)
        BuildScannerAdvancedControls()
        LoadPorts()
        Dim savedPort = SettingsManager.GetSetting(SettingsKeys.ScannerPort)
        If Not String.IsNullOrEmpty(savedPort) Then ComboBoxPorts.Text = savedPort
        LoadScannerSettings()

        ' تبويب الاعدادات العامة
        LoadGeneralSettings()

        ' تبويب قاعدة البيانات
        LoadDbSettingsToForm()
    End Sub

    ''' <summary>إنشاء عناصر التحكم الجديدة لتبويبَي الاعدادات العامة وقاعدة البيانات</summary>
    Private Sub InitializeCustomControls()
        ' ═══════════════════════════════════════════════
        ' ── TabPage1: الاعدادات العامة ──
        ' ═══════════════════════════════════════════════
        TabPage1.BackColor = Color.FromArgb(55, 53, 62)
        Dim yOff As Integer = 30

        Dim MakeLabel = Function(txt As String, yy As Integer) As Label
                            Dim lb As New Label() With {
                                .Text = txt, .ForeColor = Color.White,
                                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                                .AutoSize = True,
                                .Location = New Point(TabPage1.Width - 200, yy),
                                .RightToLeft = RightToLeft.Yes
                            }
                            TabPage1.Controls.Add(lb)
                            Return lb
                        End Function

        Dim MakeTextBox = Function(yy As Integer, wide As Integer) As TextBox
                              Dim tb As New TextBox() With {
                                  .Location = New Point(TabPage1.Width - 200 - wide - 15, yy - 3),
                                  .Width = wide, .Height = 30,
                                  .Font = New Font("Segoe UI", 11),
                                  .RightToLeft = RightToLeft.Yes
                              }
                              TabPage1.Controls.Add(tb)
                              Return tb
                          End Function

        MakeLabel("اسم المحل:", yOff) : txtShopName = MakeTextBox(yOff, 400) : yOff += 45
        MakeLabel("رقم الهاتف 1:", yOff) : txtShopPhone = MakeTextBox(yOff, 300) : yOff += 45
        MakeLabel("رقم الهاتف 2:", yOff) : txtShopPhone2 = MakeTextBox(yOff, 300) : yOff += 45
        MakeLabel("العنوان:", yOff) : txtShopAddress = MakeTextBox(yOff, 500) : yOff += 45
        MakeLabel("الرقم الضريبي:", yOff) : txtShopTax = MakeTextBox(yOff, 300) : yOff += 45
        MakeLabel("نص التذييل:", yOff) : txtFooterText = MakeTextBox(yOff, 500) : yOff += 45
        MakeLabel("نص التوصيل:", yOff) : txtDeliveryText = MakeTextBox(yOff, 500) : yOff += 45

        ' العملة
        MakeLabel("العملة:", yOff)
        cmbCurrency = New ComboBox() With {
            .Location = New Point(TabPage1.Width - 200 - 300 - 15, yOff - 3), .Width = 300,
            .Font = New Font("Segoe UI", 11), .DropDownStyle = ComboBoxStyle.DropDown,
            .RightToLeft = RightToLeft.Yes
        }
        cmbCurrency.Items.AddRange(New String() {"ج.م", "ر.س", "د.إ", "د.ك", "د.ع", "$", "€"})
        TabPage1.Controls.Add(cmbCurrency)
        yOff += 45

        ' نوع النشاط
        MakeLabel("نوع النشاط:", yOff)
        cmbBusinessType = New ComboBox() With {
            .Location = New Point(TabPage1.Width - 200 - 300 - 15, yOff - 3), .Width = 300,
            .Font = New Font("Segoe UI", 11), .DropDownStyle = ComboBoxStyle.DropDown,
            .RightToLeft = RightToLeft.Yes
        }
        cmbBusinessType.Items.AddRange(New String() {"سوبر ماركت", "بقالة", "صيدلية", "مخبز", "ملابس", "إلكترونيات", "أخرى"})
        TabPage1.Controls.Add(cmbBusinessType)
        yOff += 55

        ' اللوجو
        MakeLabel("مسار اللوجو:", yOff)
        txtLogoPath = New TextBox() With {
            .Location = New Point(200, yOff - 3), .Width = 500,
            .Font = New Font("Segoe UI", 10), .RightToLeft = RightToLeft.Yes
        }
        TabPage1.Controls.Add(txtLogoPath)
        btnBrowseLogo = New Button() With {
            .Text = "📂 اختر صورة اللوجو",
            .Location = New Point(40, yOff - 7),
            .Width = 150, .Height = 38,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = Color.FromArgb(76, 132, 255),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        btnBrowseLogo.FlatAppearance.BorderSize = 0
        btnBrowseLogo.FlatAppearance.MouseOverBackColor = Color.FromArgb(96, 152, 255)
        AddHandler btnBrowseLogo.Click, AddressOf btnBrowseLogo_Click
        TabPage1.Controls.Add(btnBrowseLogo)
        _tips.SetToolTip(btnBrowseLogo, "اضغط لاختيار صورة شعار/لوجو المحل من جهازك")

        ' معاينة مباشرة للّوجو (في العمود الأيسر الفارغ تحت الزر — لا تزحزح باقي الصفوف)
        Dim lblPreview As New Label() With {
            .Text = "معاينة اللوجو:", .ForeColor = Color.Gainsboro,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold), .AutoSize = True,
            .Location = New Point(40, yOff + 34), .RightToLeft = RightToLeft.Yes
        }
        TabPage1.Controls.Add(lblPreview)
        picLogoPreview = New PictureBox() With {
            .Location = New Point(40, yOff + 56), .Size = New Size(130, 100),
            .SizeMode = PictureBoxSizeMode.Zoom,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.White
        }
        TabPage1.Controls.Add(picLogoPreview)
        _tips.SetToolTip(picLogoPreview, "معاينة صورة اللوجو المختارة")
        yOff += 50

        ' الطابعة الحرارية
        MakeLabel("الطابعة الحرارية:", yOff)
        cmbThermalPrinter = New ComboBox() With {
            .Location = New Point(TabPage1.Width - 650, yOff - 3), .Width = 430,
            .Font = New Font("Segoe UI", 11), .DropDownStyle = ComboBoxStyle.DropDownList,
            .RightToLeft = RightToLeft.Yes
        }
        TabPage1.Controls.Add(cmbThermalPrinter)
        yOff += 45

        ' الطابعة العادية
        MakeLabel("الطابعة العادية:", yOff)
        cmbNormalPrinter = New ComboBox() With {
            .Location = New Point(TabPage1.Width - 650, yOff - 3), .Width = 430,
            .Font = New Font("Segoe UI", 11), .DropDownStyle = ComboBoxStyle.DropDownList,
            .RightToLeft = RightToLeft.Yes
        }
        TabPage1.Controls.Add(cmbNormalPrinter)
        yOff += 45

        ' نمط الطباعة
        MakeLabel("نمط الطباعة:", yOff)
        rbStyleSimple = New RadioButton() With {
            .Text = "استيل 1", .Location = New Point(TabPage1.Width - 430, yOff),
            .Font = New Font("Segoe UI", 11), .ForeColor = Color.White,
            .RightToLeft = RightToLeft.Yes, .Checked = True, .AutoSize = True
        }
        rbStyleAdvanced = New RadioButton() With {
            .Text = "استيل 2", .Location = New Point(TabPage1.Width - 650, yOff),
            .Font = New Font("Segoe UI", 11), .ForeColor = Color.White,
            .RightToLeft = RightToLeft.Yes, .AutoSize = True
        }
        TabPage1.Controls.Add(rbStyleSimple)
        TabPage1.Controls.Add(rbStyleAdvanced)
        yOff += 40

        ' طباعة اللوجو
        chkPrintLogo = New CheckBox() With {
            .Text = "طباعة اللوجو مع الفاتورة",
            .Location = New Point(TabPage1.Width - 450, yOff),
            .Font = New Font("Segoe UI", 11), .ForeColor = Color.White,
            .RightToLeft = RightToLeft.Yes, .AutoSize = True, .Checked = True
        }
        TabPage1.Controls.Add(chkPrintLogo)
        yOff += 40

        ' طباعة الباركود
        chkPrintBarcode = New CheckBox() With {
            .Text = "طباعة الباركود مع الفاتورة",
            .Location = New Point(TabPage1.Width - 450, yOff),
            .Font = New Font("Segoe UI", 11), .ForeColor = Color.White,
            .RightToLeft = RightToLeft.Yes, .AutoSize = True, .Checked = True
        }
        TabPage1.Controls.Add(chkPrintBarcode)
        yOff += 40

        ' معاينة قبل الطباعة
        chkPrintPreview = New CheckBox() With {
            .Text = "عرض معاينة قبل الطباعة",
            .Location = New Point(TabPage1.Width - 450, yOff),
            .Font = New Font("Segoe UI", 11), .ForeColor = Color.White,
            .RightToLeft = RightToLeft.Yes, .AutoSize = True, .Checked = False
        }
        TabPage1.Controls.Add(chkPrintPreview)
        yOff += 50

        ' أزرار
        btnRefreshPrinters = New Button() With {
            .Text = "🔄 تحديث الطابعات",
            .Location = New Point(TabPage1.Width - 300, yOff),
            .Width = 180, .Height = 40,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .BackColor = Color.FromArgb(40, 52, 70), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnRefreshPrinters.Click, AddressOf btnRefreshPrinters_Click
        TabPage1.Controls.Add(btnRefreshPrinters)

        btnTestThermal = New Button() With {
            .Text = "🖨️ اختبار الحرارية",
            .Location = New Point(TabPage1.Width - 500, yOff),
            .Width = 180, .Height = 40,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .BackColor = Color.FromArgb(30, 100, 60), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnTestThermal.Click, AddressOf btnTestThermal_Click
        TabPage1.Controls.Add(btnTestThermal)

        btnSaveGeneral = New Button() With {
            .Text = "💾 حفظ الاعدادات",
            .Location = New Point(TabPage1.Width - 720, yOff),
            .Width = 190, .Height = 40,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .BackColor = Color.FromArgb(76, 132, 255), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnSaveGeneral.Click, AddressOf btnSaveGeneral_Click
        TabPage1.Controls.Add(btnSaveGeneral)

        ' ═══════════════════════════════════════════════
        ' ── TabPage2: قاعدة البيانات ──
        ' ═══════════════════════════════════════════════
        TabPage2.BackColor = Color.FromArgb(45, 45, 55)
        Dim yD As Integer = 40

        Dim AddDbRow = Sub(lbl As String, ctrl As Control)
                           Dim lb2 As New Label() With {
                               .Text = lbl, .ForeColor = Color.White,
                               .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                               .AutoSize = True,
                               .Location = New Point(TabPage2.Width - 230, yD),
                               .RightToLeft = RightToLeft.Yes
                           }
                           ctrl.Location = New Point(TabPage2.Width - 750, yD - 3)
                           ctrl.Width = 490
                           ctrl.Font = New Font("Segoe UI", 11)
                           CType(ctrl, Control).RightToLeft = RightToLeft.Yes
                           TabPage2.Controls.Add(lb2)
                           TabPage2.Controls.Add(ctrl)
                           yD += 55
                       End Sub

        txtDbServer = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDown}
        AddDbRow("الخادم (Server):", txtDbServer)

        ' زر الاكتشاف التلقائي لخوادم SQL المثبتة (يسار حقل الخادم)
        btnDetectServers = New Button() With {
            .Text = "🔍 اكتشاف تلقائي",
            .Location = New Point(TabPage2.Width - 750 - 175, txtDbServer.Top - 1),
            .Width = 165, .Height = 30,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = Color.FromArgb(40, 52, 70), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnDetectServers.Click, AddressOf btnDetectServers_Click
        TabPage2.Controls.Add(btnDetectServers)

        ' تعبئة قائمة الخوادم المكتشفة عند فتح الفورم
        PopulateDetectedServers()

        txtDbName = New TextBox()
        AddDbRow("اسم قاعدة البيانات:", txtDbName)

        chkWindowsAuth = New CheckBox() With {
            .Text = "استخدام Windows Authentication",
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 11),
            .AutoSize = True,
            .RightToLeft = RightToLeft.Yes,
            .Location = New Point(TabPage2.Width - 550, yD)
        }
        AddHandler chkWindowsAuth.CheckedChanged, AddressOf chkWindowsAuth_CheckedChanged
        TabPage2.Controls.Add(chkWindowsAuth)
        yD += 50

        lblDbUser = New Label() With {
            .Text = "اسم المستخدم:", .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .AutoSize = True, .Location = New Point(TabPage2.Width - 230, yD),
            .RightToLeft = RightToLeft.Yes
        }
        txtDbUser = New TextBox() With {.Location = New Point(TabPage2.Width - 750, yD - 3), .Width = 490, .Font = New Font("Segoe UI", 11), .RightToLeft = RightToLeft.Yes}
        TabPage2.Controls.Add(lblDbUser)
        TabPage2.Controls.Add(txtDbUser)
        yD += 55

        lblDbPassword = New Label() With {
            .Text = "كلمة المرور:", .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .AutoSize = True, .Location = New Point(TabPage2.Width - 230, yD),
            .RightToLeft = RightToLeft.Yes
        }
        txtDbPassword = New TextBox() With {
            .Location = New Point(TabPage2.Width - 750, yD - 3), .Width = 490,
            .Font = New Font("Segoe UI", 11), .PasswordChar = "•"c,
            .RightToLeft = RightToLeft.Yes
        }
        TabPage2.Controls.Add(lblDbPassword)
        TabPage2.Controls.Add(txtDbPassword)
        yD += 65

        lblDbStatus = New Label() With {
            .Text = "", .ForeColor = Color.LightGreen,
            .Font = New Font("Segoe UI", 14, FontStyle.Bold),
            .AutoSize = True, .Location = New Point(TabPage2.Width - 550, yD)
        }
        TabPage2.Controls.Add(lblDbStatus)
        yD += 45

        btnTestDbConnection = New Button() With {
            .Text = "🔌 اختبار الاتصال",
            .Location = New Point(TabPage2.Width - 450, yD),
            .Width = 180, .Height = 42,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .BackColor = Color.FromArgb(40, 52, 70), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnTestDbConnection.Click, AddressOf btnTestDbConnection_Click
        TabPage2.Controls.Add(btnTestDbConnection)

        btnSaveDbSettings = New Button() With {
            .Text = "💾 حفظ إعدادات قاعدة البيانات",
            .Location = New Point(TabPage2.Width - 720, yD),
            .Width = 240, .Height = 42,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .BackColor = Color.FromArgb(76, 132, 255), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnSaveDbSettings.Click, AddressOf btnSaveDbSettings_Click
        TabPage2.Controls.Add(btnSaveDbSettings)

        ' ═══════════════════════════════════════════════
        ' ── TabPage4: إعدادات طابعة الباركود ──
        ' ═══════════════════════════════════════════════
        BuildBarcodePrinterTab()
    End Sub

    ''' <summary>إنشاء عناصر تبويب طابعة الباركود</summary>
    Private Sub BuildBarcodePrinterTab()
        Dim yB As Integer = 30

        Dim MakeBLabel = Function(txt As String, yy As Integer) As Label
                             Dim lb As New Label() With {
                                 .Text = txt, .ForeColor = Color.White,
                                 .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                                 .AutoSize = True,
                                 .Location = New Point(TabPage4.Width - 250, yy),
                                 .RightToLeft = RightToLeft.Yes
                             }
                             TabPage4.Controls.Add(lb)
                             Return lb
                         End Function

        ' اسم طابعة الباركود
        MakeBLabel("طابعة الباركود:", yB)
        cmbBarcodePrinter = New ComboBox() With {
            .Location = New Point(TabPage4.Width - 700, yB - 3), .Width = 430,
            .Font = New Font("Segoe UI", 11), .DropDownStyle = ComboBoxStyle.DropDownList,
            .RightToLeft = RightToLeft.Yes
        }
        TabPage4.Controls.Add(cmbBarcodePrinter)
        yB += 50

        ' عرض الملصق (مم)
        MakeBLabel("عرض الملصق (مم):", yB)
        numBarcodeLabelWidth = New NumericUpDown() With {
            .Location = New Point(TabPage4.Width - 450, yB - 3), .Width = 180,
            .Font = New Font("Segoe UI", 11), .Minimum = 10, .Maximum = 200,
            .Value = 50, .RightToLeft = RightToLeft.Yes
        }
        TabPage4.Controls.Add(numBarcodeLabelWidth)
        yB += 45

        ' ارتفاع الملصق (مم)
        MakeBLabel("ارتفاع الملصق (مم):", yB)
        numBarcodeLabelHeight = New NumericUpDown() With {
            .Location = New Point(TabPage4.Width - 450, yB - 3), .Width = 180,
            .Font = New Font("Segoe UI", 11), .Minimum = 10, .Maximum = 200,
            .Value = 25, .RightToLeft = RightToLeft.Yes
        }
        TabPage4.Controls.Add(numBarcodeLabelHeight)
        yB += 45

        ' عدد النسخ
        MakeBLabel("عدد النسخ الافتراضي:", yB)
        numBarcodeCopies = New NumericUpDown() With {
            .Location = New Point(TabPage4.Width - 450, yB - 3), .Width = 180,
            .Font = New Font("Segoe UI", 11), .Minimum = 1, .Maximum = 999,
            .Value = 1, .RightToLeft = RightToLeft.Yes
        }
        TabPage4.Controls.Add(numBarcodeCopies)
        yB += 45

        ' حجم الخط
        MakeBLabel("حجم خط الملصق:", yB)
        numBarcodeFontSize = New NumericUpDown() With {
            .Location = New Point(TabPage4.Width - 450, yB - 3), .Width = 180,
            .Font = New Font("Segoe UI", 11), .Minimum = 5, .Maximum = 24,
            .Value = 8, .RightToLeft = RightToLeft.Yes
        }
        TabPage4.Controls.Add(numBarcodeFontSize)
        yB += 45

        ' نص التذييل
        MakeBLabel("نص أسفل الملصق:", yB)
        txtBarcodeFooter = New TextBox() With {
            .Location = New Point(TabPage4.Width - 700, yB - 3), .Width = 430,
            .Font = New Font("Segoe UI", 11), .RightToLeft = RightToLeft.Yes
        }
        TabPage4.Controls.Add(txtBarcodeFooter)
        yB += 50

        ' خيارات إظهار اسم المنتج / السعر / اسم المحل
        chkBarcodeShowName = New CheckBox() With {
            .Text = "إظهار اسم المنتج",
            .Location = New Point(TabPage4.Width - 450, yB),
            .Font = New Font("Segoe UI", 11), .ForeColor = Color.White,
            .RightToLeft = RightToLeft.Yes, .AutoSize = True, .Checked = True
        }
        TabPage4.Controls.Add(chkBarcodeShowName)
        yB += 35

        chkBarcodeShowPrice = New CheckBox() With {
            .Text = "إظهار السعر",
            .Location = New Point(TabPage4.Width - 450, yB),
            .Font = New Font("Segoe UI", 11), .ForeColor = Color.White,
            .RightToLeft = RightToLeft.Yes, .AutoSize = True, .Checked = True
        }
        TabPage4.Controls.Add(chkBarcodeShowPrice)
        yB += 35

        chkBarcodeShowStoreName = New CheckBox() With {
            .Text = "إظهار اسم المحل",
            .Location = New Point(TabPage4.Width - 450, yB),
            .Font = New Font("Segoe UI", 11), .ForeColor = Color.White,
            .RightToLeft = RightToLeft.Yes, .AutoSize = True, .Checked = False
        }
        TabPage4.Controls.Add(chkBarcodeShowStoreName)
        yB += 55

        ' أزرار
        btnRefreshBarcodePrinters = New Button() With {
            .Text = "🔄 تحديث الطابعات",
            .Location = New Point(TabPage4.Width - 300, yB),
            .Width = 180, .Height = 40,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .BackColor = Color.FromArgb(40, 52, 70), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnRefreshBarcodePrinters.Click, AddressOf btnRefreshBarcodePrinters_Click
        TabPage4.Controls.Add(btnRefreshBarcodePrinters)

        btnTestBarcodePrinter = New Button() With {
            .Text = "🖨️ اختبار الطباعة",
            .Location = New Point(TabPage4.Width - 500, yB),
            .Width = 180, .Height = 40,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .BackColor = Color.FromArgb(30, 100, 60), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnTestBarcodePrinter.Click, AddressOf btnTestBarcodePrinter_Click
        TabPage4.Controls.Add(btnTestBarcodePrinter)

        btnSaveBarcodePrinter = New Button() With {
            .Text = "💾 حفظ الإعدادات",
            .Location = New Point(TabPage4.Width - 720, yB),
            .Width = 200, .Height = 40,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .BackColor = Color.FromArgb(76, 132, 255), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnSaveBarcodePrinter.Click, AddressOf btnSaveBarcodePrinter_Click
        TabPage4.Controls.Add(btnSaveBarcodePrinter)

        ' تعبئة قائمة الطابعات وقراءة القيم المحفوظة
        LoadBarcodePrintersList()
        LoadBarcodePrinterSettings()
    End Sub

    Private Sub LoadBarcodePrintersList()
        cmbBarcodePrinter.Items.Clear()
        For Each printerName As String In PrinterSettings.InstalledPrinters
            cmbBarcodePrinter.Items.Add(printerName)
        Next
    End Sub

    Private Sub LoadBarcodePrinterSettings()
        Try
            Dim savedPrinter = If(SettingsManager.GetSetting("BarcodePrinterName"), "")
            If Not String.IsNullOrEmpty(savedPrinter) Then cmbBarcodePrinter.Text = savedPrinter

            Dim w = SettingsManager.GetSetting("BarcodeLabelWidth")
            If Not String.IsNullOrEmpty(w) Then
                Dim wi As Integer
                If Integer.TryParse(w, wi) AndAlso wi >= numBarcodeLabelWidth.Minimum AndAlso wi <= numBarcodeLabelWidth.Maximum Then
                    numBarcodeLabelWidth.Value = wi
                End If
            End If

            Dim h = SettingsManager.GetSetting("BarcodeLabelHeight")
            If Not String.IsNullOrEmpty(h) Then
                Dim hi As Integer
                If Integer.TryParse(h, hi) AndAlso hi >= numBarcodeLabelHeight.Minimum AndAlso hi <= numBarcodeLabelHeight.Maximum Then
                    numBarcodeLabelHeight.Value = hi
                End If
            End If

            Dim c = SettingsManager.GetSetting("BarcodeCopies")
            If Not String.IsNullOrEmpty(c) Then
                Dim ci As Integer
                If Integer.TryParse(c, ci) AndAlso ci >= numBarcodeCopies.Minimum AndAlso ci <= numBarcodeCopies.Maximum Then
                    numBarcodeCopies.Value = ci
                End If
            End If

            Dim fs = SettingsManager.GetSetting("BarcodeFontSize")
            If Not String.IsNullOrEmpty(fs) Then
                Dim fsi As Integer
                If Integer.TryParse(fs, fsi) AndAlso fsi >= numBarcodeFontSize.Minimum AndAlso fsi <= numBarcodeFontSize.Maximum Then
                    numBarcodeFontSize.Value = fsi
                End If
            End If

            txtBarcodeFooter.Text = If(SettingsManager.GetSetting("BarcodeFooterText"), "")
            chkBarcodeShowName.Checked = (If(SettingsManager.GetSetting("BarcodeShowName"), "true").ToLower() = "true")
            chkBarcodeShowPrice.Checked = (If(SettingsManager.GetSetting("BarcodeShowPrice"), "true").ToLower() = "true")
            chkBarcodeShowStoreName.Checked = (If(SettingsManager.GetSetting("BarcodeShowStoreName"), "false").ToLower() = "true")
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل إعدادات طابعة الباركود: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshBarcodePrinters_Click(sender As Object, e As EventArgs)
        LoadBarcodePrintersList()
        MessageBox.Show("✅ تم تحديث قائمة الطابعات.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSaveBarcodePrinter_Click(sender As Object, e As EventArgs)
        Try
            SettingsManager.SaveSetting("BarcodePrinterName", cmbBarcodePrinter.Text)
            SettingsManager.SaveSetting("BarcodeLabelWidth", CInt(numBarcodeLabelWidth.Value).ToString())
            SettingsManager.SaveSetting("BarcodeLabelHeight", CInt(numBarcodeLabelHeight.Value).ToString())
            SettingsManager.SaveSetting("BarcodeCopies", CInt(numBarcodeCopies.Value).ToString())
            SettingsManager.SaveSetting("BarcodeFontSize", CInt(numBarcodeFontSize.Value).ToString())
            SettingsManager.SaveSetting("BarcodeFooterText", txtBarcodeFooter.Text.Trim())
            SettingsManager.SaveSetting("BarcodeShowName", chkBarcodeShowName.Checked.ToString().ToLower())
            SettingsManager.SaveSetting("BarcodeShowPrice", chkBarcodeShowPrice.Checked.ToString().ToLower())
            SettingsManager.SaveSetting("BarcodeShowStoreName", chkBarcodeShowStoreName.Checked.ToString().ToLower())
            Notify.Toast("تم حفظ إعدادات طابعة الباركود", Notify.ToastType.Success)
        Catch ex As Exception
            Notify.Error("خطأ في الحفظ: " & ex.Message)
        End Try
    End Sub

    Private Sub btnTestBarcodePrinter_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(cmbBarcodePrinter.Text) Then
                MessageBox.Show("يرجى اختيار طابعة الباركود أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim labelWmm As Integer = CInt(numBarcodeLabelWidth.Value)
            Dim labelHmm As Integer = CInt(numBarcodeLabelHeight.Value)
            Dim labelWhi As Integer = CInt(labelWmm * 3.937)  ' مم → 1/100 بوصة
            Dim labelHhi As Integer = CInt(labelHmm * 3.937)
            Dim fontSize As Integer = CInt(numBarcodeFontSize.Value)
            Dim footer As String = txtBarcodeFooter.Text

            Using pd As New PrintDocument()
                pd.PrinterSettings.PrinterName = cmbBarcodePrinter.Text
                pd.DefaultPageSettings.PaperSize = New PaperSize("BarcodeLabel", labelWhi, labelHhi)
                pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                pd.OriginAtMargins = False

                Dim handler As PrintPageEventHandler = Nothing
                handler = Sub(s2, ev)
                              Dim writer As New ZXing.BarcodeWriter() With {
                                  .Format = ZXing.BarcodeFormat.CODE_128,
                                  .Options = New ZXing.Common.EncodingOptions With {
                                      .Height = Math.Max(40, ev.PageBounds.Height - 35),
                                      .Width = Math.Max(80, ev.PageBounds.Width - 10),
                                      .Margin = 0, .PureBarcode = True}}
                              Using img As Bitmap = writer.Write("TEST12345")
                                  Dim x As Integer = (ev.PageBounds.Width - img.Width) \ 2
                                  ev.Graphics.DrawImage(img, x, 3)
                                  Using fnt As New Font("Arial", fontSize, FontStyle.Bold)
                                      Dim txt As String = "TEST12345"
                                      Dim sz = ev.Graphics.MeasureString(txt, fnt)
                                      ev.Graphics.DrawString(txt, fnt, Brushes.Black,
                                                             (ev.PageBounds.Width - sz.Width) / 2, img.Height + 5)
                                      If Not String.IsNullOrEmpty(footer) Then
                                          Using fnt2 As New Font("Arial", Math.Max(6, fontSize - 2))
                                              Dim sz2 = ev.Graphics.MeasureString(footer, fnt2)
                                              ev.Graphics.DrawString(footer, fnt2, Brushes.Black,
                                                                     (ev.PageBounds.Width - sz2.Width) / 2,
                                                                     img.Height + 5 + sz.Height + 2)
                                          End Using
                                      End If
                                  End Using
                              End Using
                              ev.HasMorePages = False
                          End Sub
                AddHandler pd.PrintPage, handler
                Try
                    pd.Print()
                    MessageBox.Show("✅ تم إرسال طباعة اختبار.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Finally
                    RemoveHandler pd.PrintPage, handler
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ خطأ في الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' ➊ تبويب الباركود (Scanner) — إعدادات متقدمة + تجربة حيّة
    '══════════════════════════════════════════════════════════════
    Private Sub LoadPorts()
        ComboBoxPorts.Items.Clear()
        ComboBoxPorts.Items.AddRange(SerialPort.GetPortNames())
    End Sub

    ''' <summary>بناء عناصر الإعدادات المتقدمة للاسكنر (Baud / DataBits / Parity / StopBits + صندوق التجربة)</summary>
    Private Sub BuildScannerAdvancedControls()
        Dim pnl As New Panel() With {
            .Location = New Point(60, 150),
            .Size = New Size(580, 450),
            .BackColor = Color.FromArgb(45, 45, 55),
            .RightToLeft = RightToLeft.Yes
        }
        TabPage3.Controls.Add(pnl)

        Dim title As New Label() With {
            .Text = "⚙️ إعدادات متقدمة", .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 15, FontStyle.Bold), .AutoSize = True,
            .Location = New Point(360, 8), .RightToLeft = RightToLeft.Yes
        }
        pnl.Controls.Add(title)

        Dim MakeRow = Function(labelText As String, items() As String, yy As Integer) As ComboBox
                          Dim lb As New Label() With {
                              .Text = labelText, .ForeColor = Color.White,
                              .Font = New Font("Segoe UI", 12, FontStyle.Bold), .AutoSize = True,
                              .Location = New Point(420, yy + 4), .RightToLeft = RightToLeft.Yes
                          }
                          Dim cb As New ComboBox() With {
                              .Location = New Point(110, yy), .Width = 290, .Height = 32,
                              .Font = New Font("Segoe UI", 12),
                              .DropDownStyle = ComboBoxStyle.DropDownList,
                              .RightToLeft = RightToLeft.Yes
                          }
                          cb.Items.AddRange(items)
                          pnl.Controls.Add(lb)
                          pnl.Controls.Add(cb)
                          Return cb
                      End Function

        cmbBaudRate = MakeRow("سرعة النقل (Baud):", New String() {"9600", "19200", "38400", "57600", "115200"}, 55)
        cmbDataBits = MakeRow("بِتّات البيانات:", New String() {"7", "8"}, 100)
        cmbParity = MakeRow("التماثل (Parity):", New String() {"None", "Even", "Odd", "Mark", "Space"}, 145)
        cmbStopBits = MakeRow("بِتّات التوقّف:", New String() {"One", "Two", "OnePointFive"}, 190)

        lblScanTestHint = New Label() With {
            .Text = "اضغط «اختبار الاتصال» ثم امسح أي باركود — ستظهر النتيجة هنا:",
            .ForeColor = Color.Gainsboro, .Font = New Font("Segoe UI", 10), .AutoSize = True,
            .Location = New Point(40, 235), .RightToLeft = RightToLeft.Yes
        }
        pnl.Controls.Add(lblScanTestHint)

        txtScanTestResult = New TextBox() With {
            .Location = New Point(20, 265), .Size = New Size(540, 170),
            .Multiline = True, .ReadOnly = True, .ScrollBars = ScrollBars.Vertical,
            .BackColor = Color.FromArgb(28, 28, 36), .ForeColor = Color.LightGreen,
            .Font = New Font("Consolas", 12, FontStyle.Bold), .RightToLeft = RightToLeft.No
        }
        pnl.Controls.Add(txtScanTestResult)
    End Sub

    ''' <summary>تحميل إعدادات الاسكنر المحفوظة إلى عناصر التحكم</summary>
    Private Sub LoadScannerSettings()
        Try
            cmbBaudRate.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerBaudRate, "9600")
            cmbDataBits.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerDataBits, "8")
            cmbParity.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerParity, "None")
            cmbStopBits.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerStopBits, "One")
            CheckBoxEnabled.Checked = SettingsManager.GetBoolSetting(SettingsKeys.ScannerEnabled, True)
        Catch ex As Exception
            Debug.WriteLine("LoadScannerSettings: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshPorts_Click(sender As Object, e As EventArgs) Handles btnRefreshPorts.Click
        LoadPorts()
        lblStatus.Text = "✅ تم تحديث المنافذ"
        lblStatus.ForeColor = Color.LightGreen
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSavebarcode.Click
        Dim portName As String = ComboBoxPorts.Text
        If String.IsNullOrEmpty(portName) Then
            MessageBox.Show("يرجى اختيار المنفذ أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SettingsManager.SaveSetting(SettingsKeys.ScannerPort, portName)
        SettingsManager.SaveSetting(SettingsKeys.ScannerBaudRate, cmbBaudRate.Text)
        SettingsManager.SaveSetting(SettingsKeys.ScannerDataBits, cmbDataBits.Text)
        SettingsManager.SaveSetting(SettingsKeys.ScannerParity, cmbParity.Text)
        SettingsManager.SaveSetting(SettingsKeys.ScannerStopBits, cmbStopBits.Text)
        SettingsManager.SaveSetting(SettingsKeys.ScannerEnabled, CheckBoxEnabled.Checked.ToString().ToLower())

        lblStatus.Text = "✅ تم حفظ إعدادات الاسكنر"
        lblStatus.ForeColor = Color.LightGreen
    End Sub

    ''' <summary>زر التجربة: تشغيل/إيقاف تجربة حيّة للاسكنر بالإعدادات الحالية</summary>
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        If _scannerTesting Then
            StopScanTest()
            Return
        End If

        If String.IsNullOrEmpty(ComboBoxPorts.Text) Then
            MessageBox.Show("يرجى اختيار المنفذ أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' تحرير المنفذ لو الاسكنر الرئيسي شغّال عليه
            ScannerModule.StopScanner()

            Dim baud As Integer = CInt(SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerBaudRate, cmbBaudRate.Text))
            Dim dataBits As Integer = CInt(cmbDataBits.Text)
            Dim par As Parity = CType([Enum].Parse(GetType(Parity), cmbParity.Text), Parity)
            Dim sBits As StopBits = CType([Enum].Parse(GetType(StopBits), cmbStopBits.Text), StopBits)

            serial = New SerialPort(ComboBoxPorts.Text, baud, par, dataBits, sBits) With {
                .Handshake = Handshake.None
            }
            serial.Open()

            _scannerTesting = True
            txtScanTestResult.Clear()
            txtScanTestResult.AppendText("🟢 التجربة جارية — امسح أي باركود..." & vbCrLf)
            btnTestConnection.Text = "⏹ إيقاف التجربة"
            lblStatus.Text = "🟢 جاري تجربة الاسكنر"
            lblStatus.ForeColor = Color.LightGreen
        Catch ex As Exception
            MessageBox.Show("تعذّر فتح المنفذ للتجربة: " & ex.Message, "تنبيه",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ''' <summary>إيقاف تجربة الاسكنر وتحرير المنفذ</summary>
    Private Sub StopScanTest()
        Try
            If serial IsNot Nothing AndAlso serial.IsOpen Then serial.Close()
            If serial IsNot Nothing Then serial.Dispose()
        Catch
        End Try
        serial = Nothing
        _scannerTesting = False
        btnTestConnection.Text = "اختبار الاتصال"
        lblStatus.Text = "⏹ تم إيقاف التجربة"
        lblStatus.ForeColor = Color.Gold
    End Sub

    Private Sub btnCloseConnection_Click(sender As Object, e As EventArgs) Handles btnCloseConnection.Click
        If _scannerTesting Then StopScanTest()
        ' إيقاف الاسكنر الرئيسي + إغلاق المنفذ المحفوظ بهدوء
        ScannerModule.StopScanner()
        Dim portName As String = SettingsManager.GetSetting(SettingsKeys.ScannerPort)
        If Not String.IsNullOrEmpty(portName) Then
            SettingsManager.CloseBarcodePort(portName)
        End If
        lblStatus.Text = "⏹ تم غلق منفذ الباركود"
        lblStatus.ForeColor = Color.Gold
    End Sub

    Private Sub serial_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serial.DataReceived
        Try
            Dim data As String = serial.ReadExisting().Trim()
            If String.IsNullOrEmpty(data) Then Return
            If Me.IsHandleCreated Then
                Me.BeginInvoke(Sub()
                                   txtScanTestResult.AppendText("✅ " & DateTime.Now.ToString("HH:mm:ss") & "  →  " & data & vbCrLf)
                               End Sub)
            End If
        Catch ex As Exception
            Debug.WriteLine("scan test recv: " & ex.Message)
        End Try
    End Sub

    ''' <summary>إيقاف أي تجربة جارية عند إغلاق الفورم لتحرير المنفذ</summary>
    Private Sub Settings_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _scannerTesting Then StopScanTest()
    End Sub

    '══════════════════════════════════════════════════════════════
    ' ➋ تبويب الاعدادات العامة
    '══════════════════════════════════════════════════════════════
    Private Sub LoadGeneralSettings()
        Try
            ' معلومات المحل
            txtShopName.Text = If(SettingsManager.GetSetting("ShopName"), "")
            txtShopPhone.Text = If(SettingsManager.GetSetting("ShopPhone"), "")
            txtShopPhone2.Text = If(SettingsManager.GetSetting("ShopPhone2"), "")
            txtShopAddress.Text = If(SettingsManager.GetSetting("ShopAddress"), "")
            txtShopTax.Text = If(SettingsManager.GetSetting("TaxNumber"), "")
            txtFooterText.Text = If(SettingsManager.GetSetting("FooterText"), "")
            txtDeliveryText.Text = If(SettingsManager.GetSetting("DeliveryText"), "يوجد توصيل للمنازل")
            cmbCurrency.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.Currency, "ج.م")
            cmbBusinessType.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.BusinessType, "سوبر ماركت")
            txtLogoPath.Text = If(SettingsManager.GetSetting("LogoPath"), "")
            LoadLogoPreview(txtLogoPath.Text)

            ' تحميل قائمة الطابعات
            LoadPrintersList()

            ' اختيار الطابعة الحرارية المحفوظة
            Dim savedThermal = If(SettingsManager.GetSetting("ThermalPrinterName"), "")
            Dim savedNormal = If(SettingsManager.GetSetting("NormalPrinterName"), "")

            If Not String.IsNullOrEmpty(savedThermal) Then
                cmbThermalPrinter.Text = savedThermal
            End If
            If Not String.IsNullOrEmpty(savedNormal) Then
                cmbNormalPrinter.Text = savedNormal
            End If

            ' إعدادات الطباعة
            Dim styleVal = If(SettingsManager.GetSetting("PrintStyle"), "1")
            If styleVal = "1" Then
                rbStyleSimple.Checked = True
            Else
                rbStyleAdvanced.Checked = True
            End If

            Dim printLogo = If(SettingsManager.GetSetting("PrintLogo"), "true")
            chkPrintLogo.Checked = (printLogo.ToLower() = "true")

            Dim printBarcode = If(SettingsManager.GetSetting("PrintBarcode"), "true")
            chkPrintBarcode.Checked = (printBarcode.ToLower() = "true")

            Dim printPreview = If(SettingsManager.GetSetting("PrintPreview"), "false")
            chkPrintPreview.Checked = (printPreview.ToLower() = "true")

        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل الاعدادات العامة: " & ex.Message)
        End Try
    End Sub

    ''' <summary>تحميل قائمة الطابعات المثبتة على الجهاز</summary>
    Private Sub LoadPrintersList()
        cmbThermalPrinter.Items.Clear()
        cmbNormalPrinter.Items.Clear()

        For Each printerName As String In PrinterSettings.InstalledPrinters
            cmbThermalPrinter.Items.Add(printerName)
            cmbNormalPrinter.Items.Add(printerName)
        Next
    End Sub

    Private Sub btnRefreshPrinters_Click(sender As Object, e As EventArgs)
        LoadPrintersList()
        MessageBox.Show("✅ تم تحديث قائمة الطابعات.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnBrowseLogo_Click(sender As Object, e As EventArgs)
        Using dlg As New OpenFileDialog()
            dlg.Title = "اختر صورة اللوجو"
            dlg.Filter = "صور|*.png;*.jpg;*.jpeg;*.bmp;*.gif|الكل|*.*"
            If dlg.ShowDialog() = DialogResult.OK Then
                txtLogoPath.Text = dlg.FileName
                LoadLogoPreview(dlg.FileName)
            End If
        End Using
    End Sub

    ''' <summary>تحميل صورة اللوجو في صندوق المعاينة بدون قفل الملف على القرص</summary>
    Private Sub LoadLogoPreview(path As String)
        Try
            If picLogoPreview Is Nothing Then Return
            ' تحرير الصورة القديمة أولاً
            If picLogoPreview.Image IsNot Nothing Then
                Dim old = picLogoPreview.Image
                picLogoPreview.Image = Nothing
                old.Dispose()
            End If
            If Not String.IsNullOrWhiteSpace(path) AndAlso IO.File.Exists(path) Then
                ' نسخ الصورة من stream حتى لا يبقى الملف مقفولاً
                Using fs As New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read)
                    Using tmp As Image = Image.FromStream(fs)
                        picLogoPreview.Image = New Bitmap(tmp)
                    End Using
                End Using
            End If
        Catch ex As Exception
            Debug.WriteLine("LoadLogoPreview: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSaveGeneral_Click(sender As Object, e As EventArgs)
        Try
            ' حفظ معلومات المحل
            SettingsManager.SaveSetting("ShopName", txtShopName.Text.Trim())
            SettingsManager.SaveSetting("ShopPhone", txtShopPhone.Text.Trim())
            SettingsManager.SaveSetting("ShopPhone2", txtShopPhone2.Text.Trim())
            SettingsManager.SaveSetting("ShopAddress", txtShopAddress.Text.Trim())
            SettingsManager.SaveSetting("TaxNumber", txtShopTax.Text.Trim())
            SettingsManager.SaveSetting("FooterText", txtFooterText.Text.Trim())
            SettingsManager.SaveSetting("DeliveryText", txtDeliveryText.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.Currency, cmbCurrency.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.BusinessType, cmbBusinessType.Text.Trim())
            SettingsManager.SaveSetting("LogoPath", txtLogoPath.Text.Trim())

            ' حفظ أسماء الطابعات
            SettingsManager.SaveSetting("ThermalPrinterName", cmbThermalPrinter.Text)
            SettingsManager.SaveSetting("NormalPrinterName", cmbNormalPrinter.Text)

            ' حفظ نمط الطباعة
            SettingsManager.SaveSetting("PrintStyle", If(rbStyleSimple.Checked, "1", "2"))
            SettingsManager.SaveSetting("PrintLogo", chkPrintLogo.Checked.ToString().ToLower())
            SettingsManager.SaveSetting("PrintBarcode", chkPrintBarcode.Checked.ToString().ToLower())
            SettingsManager.SaveSetting("PrintPreview", chkPrintPreview.Checked.ToString().ToLower())

            Notify.Toast("تم حفظ الاعدادات العامة", Notify.ToastType.Success)
        Catch ex As Exception
            Notify.Error("خطأ في الحفظ: " & ex.Message)
        End Try
    End Sub

    Private Sub btnTestThermal_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(cmbThermalPrinter.Text) Then
            MessageBox.Show("يرجى اختيار الطابعة الحرارية أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            ' طباعة صفحة اختبار
            Dim testText As String = "==============================" & vbLf &
                                     "   اختبار الطابعة الحرارية   " & vbLf &
                                     "==============================" & vbLf &
                                     "تم الاختبار بنجاح ✅" & vbLf & vbLf & vbLf
            RawPrinterHelper.PrintReceiptWithLogo(cmbThermalPrinter.Text, Nothing, testText, False)
            MessageBox.Show("✅ تم إرسال صفحة الاختبار للطابعة الحرارية.", "نجاح")
        Catch ex As Exception
            MessageBox.Show("❌ خطأ في اختبار الطابعة: " & ex.Message, "خطأ")
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' ➌ تبويب قاعدة البيانات
    '══════════════════════════════════════════════════════════════
    Private Sub LoadDbSettingsToForm()
        Try
            ' تحميل الإعدادات المحفوظة في الملف
            DBModule.LoadDbSettings()

            txtDbServer.Text = DBModule.server
            txtDbName.Text = DBModule.database
            txtDbUser.Text = DBModule.username
            txtDbPassword.Text = DBModule.password
            chkWindowsAuth.Checked = DBModule.useWindowsAuth

            ' تعطيل/تفعيل حقول المصادقة
            UpdateAuthFields()
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل إعدادات قاعدة البيانات: " & ex.Message)
        End Try
    End Sub

    ''' <summary>تعبئة قائمة الخوادم المكتشفة في الـ ComboBox مع الحفاظ على القيمة الحالية</summary>
    Private Sub PopulateDetectedServers()
        Try
            Dim current As String = txtDbServer.Text
            txtDbServer.Items.Clear()
            For Each srv As String In DBModule.DetectSqlServers()
                txtDbServer.Items.Add(srv)
            Next
            If Not String.IsNullOrEmpty(current) Then txtDbServer.Text = current
        Catch ex As Exception
            Debug.WriteLine("PopulateDetectedServers: " & ex.Message)
        End Try
    End Sub

    ''' <summary>زر الاكتشاف التلقائي: يحدّث القائمة ويحاول إيجاد خادم يتصل بقاعدة البيانات فعلياً</summary>
    Private Sub btnDetectServers_Click(sender As Object, e As EventArgs)
        Try
            PopulateDetectedServers()

            Dim dbName As String = txtDbName.Text.Trim()
            If String.IsNullOrEmpty(dbName) Then dbName = DBModule.database

            Dim winAuth As Boolean = chkWindowsAuth.Checked
            Dim usr As String = txtDbUser.Text.Trim()
            Dim pwd As String = txtDbPassword.Text

            ' تجربة كل خادم مكتشف لإيجاد أول واحد يتصل بقاعدة البيانات
            For Each srv As String In DBModule.DetectSqlServers()
                Dim cs As String = DBModule.BuildConnectionString(srv, dbName, usr, pwd, winAuth)
                If DBModule.TestConnection(cs) Then
                    txtDbServer.Text = srv
                    lblDbStatus.Text = "✅ تم العثور على خادم متصل: " & srv
                    lblDbStatus.ForeColor = Color.LightGreen
                    Return
                End If
            Next

            lblDbStatus.Text = "⚠️ تم تحديث القائمة لكن لم يتصل أي خادم بقاعدة البيانات."
            lblDbStatus.ForeColor = Color.Orange
        Catch ex As Exception
            lblDbStatus.Text = "❌ " & ex.Message
            lblDbStatus.ForeColor = Color.OrangeRed
        End Try
    End Sub

    Private Sub chkWindowsAuth_CheckedChanged(sender As Object, e As EventArgs)
        UpdateAuthFields()
    End Sub

    Private Sub UpdateAuthFields()
        Dim useWin As Boolean = chkWindowsAuth.Checked
        txtDbUser.Enabled = Not useWin
        txtDbPassword.Enabled = Not useWin
        lblDbUser.Enabled = Not useWin
        lblDbPassword.Enabled = Not useWin
    End Sub

    Private Sub btnTestDbConnection_Click(sender As Object, e As EventArgs)
        Try
            ' بناء connection string مؤقت للاختبار
            Dim tempCs As String
            If chkWindowsAuth.Checked Then
                tempCs = $"Server={txtDbServer.Text.Trim()};Database={txtDbName.Text.Trim()};Integrated Security=True;MultipleActiveResultSets=True;"
            Else
                tempCs = $"Server={txtDbServer.Text.Trim()};Database={txtDbName.Text.Trim()};User Id={txtDbUser.Text.Trim()};Password={txtDbPassword.Text};MultipleActiveResultSets=True;"
            End If

            If DBModule.TestConnection(tempCs) Then
                lblDbStatus.Text = "✅ الاتصال ناجح"
                lblDbStatus.ForeColor = Color.LightGreen
            Else
                lblDbStatus.Text = "❌ فشل الاتصال"
                lblDbStatus.ForeColor = Color.OrangeRed
            End If
        Catch ex As Exception
            lblDbStatus.Text = "❌ " & ex.Message
            lblDbStatus.ForeColor = Color.OrangeRed
        End Try
    End Sub

    Private Sub btnSaveDbSettings_Click(sender As Object, e As EventArgs)
        Try
            DBModule.server = txtDbServer.Text.Trim()
            DBModule.database = txtDbName.Text.Trim()
            DBModule.username = txtDbUser.Text.Trim()
            DBModule.password = txtDbPassword.Text
            DBModule.useWindowsAuth = chkWindowsAuth.Checked

            ' حفظ في الملف
            DBModule.SaveDbSettings()

            ' اختبار الاتصال الجديد
            If DBModule.TestConnection() Then
                MessageBox.Show("✅ تم حفظ إعدادات قاعدة البيانات بنجاح وتم التحقق من الاتصال.",
                                "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim result = MessageBox.Show("⚠️ تم الحفظ لكن تعذّر الاتصال بقاعدة البيانات بالإعدادات الجديدة." & vbCrLf &
                                             "هل تريد الإبقاء على الإعدادات؟",
                                             "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.No Then
                    ' استرجاع الإعدادات القديمة
                    DBModule.LoadDbSettings()
                    LoadDbSettingsToForm()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("❌ خطأ في الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' تحريك الفورم
    '══════════════════════════════════════════════════════════════
    Private Sub pnlHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlHeader.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub pnlHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlHeader.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = WindowState.Normal Then
            WindowState = FormWindowState.Maximized
        ElseIf WindowState.Maximized Then
            WindowState = FormWindowState.Normal
        End If
    End Sub

    ' زر الإغلاق
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class