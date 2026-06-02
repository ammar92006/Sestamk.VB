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

    ' ══ عناصر تبويب الاعدادات العامة ══
    Private txtShopName As TextBox
    Private txtShopPhone As TextBox
    Private txtShopPhone2 As TextBox
    Private txtShopAddress As TextBox
    Private txtShopTax As TextBox
    Private txtFooterText As TextBox
    Private txtDeliveryText As TextBox
    Private txtLogoPath As TextBox
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
    Private txtDbServer As TextBox
    Private txtDbName As TextBox
    Private txtDbUser As TextBox
    Private txtDbPassword As TextBox
    Private chkWindowsAuth As CheckBox
    Private btnTestDbConnection As Button
    Private btnSaveDbSettings As Button
    Private lblDbStatus As Label
    Private lblDbUser As Label
    Private lblDbPassword As Label

    '══════════════════════════════════════════════════════════════
    ' عند تحميل الفورم - نحمل كل الإعدادات
    '══════════════════════════════════════════════════════════════
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' بناء عناصر التحكم الجديدة
        InitializeCustomControls()

        ' تبويب الباركود
        LoadPorts()
        Dim savedPort = SettingsManager.GetSetting("Current_port_scanner")
        If Not String.IsNullOrEmpty(savedPort) Then ComboBoxPorts.Text = savedPort

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
        MakeLabel("نص التوصيل:", yOff) : txtDeliveryText = MakeTextBox(yOff, 500) : yOff += 55

        ' اللوجو
        MakeLabel("مسار اللوجو:", yOff)
        txtLogoPath = New TextBox() With {
            .Location = New Point(200, yOff - 3), .Width = 500,
            .Font = New Font("Segoe UI", 10), .RightToLeft = RightToLeft.Yes
        }
        TabPage1.Controls.Add(txtLogoPath)
        btnBrowseLogo = New Button() With {
            .Text = "📂 استعراض", .Location = New Point(100, yOff - 3),
            .Width = 95, .Height = 28, .Font = New Font("Segoe UI", 9)
        }
        AddHandler btnBrowseLogo.Click, AddressOf btnBrowseLogo_Click
        TabPage1.Controls.Add(btnBrowseLogo)
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

        txtDbServer = New TextBox()
        AddDbRow("الخادم (Server):", txtDbServer)

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
            MessageBox.Show("✅ تم حفظ إعدادات طابعة الباركود.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("❌ خطأ في الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    ' ➊ تبويب الباركود
    '══════════════════════════════════════════════════════════════
    Private Sub LoadPorts()
        ComboBoxPorts.Items.Clear()
        ComboBoxPorts.Items.AddRange(SerialPort.GetPortNames())
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
        SettingsManager.SaveSetting("Current_port_scanner", portName)
        MessageBox.Show("✅ تم حفظ إعداد الباركود بنجاح.")
    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        ' اختبار الاتصال بالسيريال
    End Sub

    Private Sub btnCloseConnection_Click(sender As Object, e As EventArgs) Handles btnCloseConnection.Click
        Dim portName As String = SettingsManager.GetSetting("Current_port_scanner")
        If Not String.IsNullOrEmpty(portName) Then
            SettingsManager.CloseBarcodePort(portName)
        End If
    End Sub

    Private Sub serial_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serial.DataReceived
        Dim data As String = serial.ReadExisting()
        Me.Invoke(Sub() MessageBox.Show("تم قراءة: " & data))
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
            txtLogoPath.Text = If(SettingsManager.GetSetting("LogoPath"), "")

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
            End If
        End Using
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
            SettingsManager.SaveSetting("LogoPath", txtLogoPath.Text.Trim())

            ' حفظ أسماء الطابعات
            SettingsManager.SaveSetting("ThermalPrinterName", cmbThermalPrinter.Text)
            SettingsManager.SaveSetting("NormalPrinterName", cmbNormalPrinter.Text)

            ' حفظ نمط الطباعة
            SettingsManager.SaveSetting("PrintStyle", If(rbStyleSimple.Checked, "1", "2"))
            SettingsManager.SaveSetting("PrintLogo", chkPrintLogo.Checked.ToString().ToLower())
            SettingsManager.SaveSetting("PrintBarcode", chkPrintBarcode.Checked.ToString().ToLower())
            SettingsManager.SaveSetting("PrintPreview", chkPrintPreview.Checked.ToString().ToLower())

            MessageBox.Show("✅ تم حفظ الاعدادات العامة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("❌ خطأ في الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    ' زر الإغلاق
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class