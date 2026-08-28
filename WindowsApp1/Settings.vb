Imports System.Data.SqlClient
Imports System.IO.Ports
Imports System.Drawing.Printing
Imports System.IO

''' <summary>
''' فورم الاعدادات العامة - يحتوي على تبويبات الإعدادات
''' </summary>
Public Class Settings
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim WithEvents serial As SerialPort

    Private _scannerTesting As Boolean = False
    Private defaultTreasuryid As Integer
    Private IsDineInServiceFeePercent As Boolean
    Private DineInServiceFee As Decimal

    '══════════════════════════════════════════════════════════════
    ' عند تحميل الفورم - نحمل كل الإعدادات
    '══════════════════════════════════════════════════════════════
    Private Async Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' التجاوب مع الشاشة: ملاءمة حجم الفورم للمساحة المتاحة + توسيطه
        'LayoutHelper.FitToWorkingArea(Me)

        ' تبويب الباركود (Scanner)
        'LoadPorts()
        Dim savedPort = SettingsManager.GetSetting(SettingsKeys.ScannerPort)
        If Not String.IsNullOrEmpty(savedPort) Then ComboBoxPorts.Text = savedPort
        'LoadScannerSettings()

        ' تبويب طابعة الباركود
        'LoadBarcodePrintersList()
        'LoadBarcodePrinterSettings()

        ' تبويب الاعدادات العامة
        LoadGeneralSettings()

        ' تبويب قاعدة البيانات
        PopulateDetectedServers()
        LoadDbSettingsToForm()
        Await LoadTreasuriesAsync()
    End Sub

    '══════════════════════════════════════════════════════════════
    ' إعدادات طابعة الباركود (TabPage4)
    '══════════════════════════════════════════════════════════════
    'Private Sub LoadBarcodePrintersList()
    '    cmbBarcodePrinter.Items.Clear()
    '    For Each printerName As String In PrinterSettings.InstalledPrinters
    '        cmbBarcodePrinter.Items.Add(printerName)
    '    Next
    'End Sub

    'Private Sub LoadBarcodePrinterSettings()
    '    Try
    '        Dim savedPrinter = If(SettingsManager.GetSetting("BarcodePrinterName"), "")
    '        If Not String.IsNullOrEmpty(savedPrinter) Then cmbBarcodePrinter.Text = savedPrinter

    '        Dim w = SettingsManager.GetSetting("BarcodeLabelWidth")
    '        If Not String.IsNullOrEmpty(w) Then
    '            Dim wi As Integer
    '            If Integer.TryParse(w, wi) AndAlso wi >= numBarcodeLabelWidth.Minimum AndAlso wi <= numBarcodeLabelWidth.Maximum Then
    '                numBarcodeLabelWidth.Value = wi
    '            End If
    '        End If

    '        Dim h = SettingsManager.GetSetting("BarcodeLabelHeight")
    '        If Not String.IsNullOrEmpty(h) Then
    '            Dim hi As Integer
    '            If Integer.TryParse(h, hi) AndAlso hi >= numBarcodeLabelHeight.Minimum AndAlso hi <= numBarcodeLabelHeight.Maximum Then
    '                numBarcodeLabelHeight.Value = hi
    '            End If
    '        End If

    '        Dim c = SettingsManager.GetSetting("BarcodeCopies")
    '        If Not String.IsNullOrEmpty(c) Then
    '            Dim ci As Integer
    '            If Integer.TryParse(c, ci) AndAlso ci >= numBarcodeCopies.Minimum AndAlso ci <= numBarcodeCopies.Maximum Then
    '                numBarcodeCopies.Value = ci
    '            End If
    '        End If

    '        Dim fs = SettingsManager.GetSetting("BarcodeFontSize")
    '        If Not String.IsNullOrEmpty(fs) Then
    '            Dim fsi As Integer
    '            If Integer.TryParse(fs, fsi) AndAlso fsi >= numBarcodeFontSize.Minimum AndAlso fsi <= numBarcodeFontSize.Maximum Then
    '                numBarcodeFontSize.Value = fsi
    '            End If
    '        End If

    '        txtBarcodeFooter.Text = If(SettingsManager.GetSetting("BarcodeFooterText"), "")
    '        chkBarcodeShowName.Checked = (If(SettingsManager.GetSetting("BarcodeShowName"), "true").ToLower() = "true")
    '        chkBarcodeShowPrice.Checked = (If(SettingsManager.GetSetting("BarcodeShowPrice"), "true").ToLower() = "true")
    '        chkBarcodeShowStoreName.Checked = (If(SettingsManager.GetSetting("BarcodeShowStoreName"), "false").ToLower() = "true")
    '    Catch ex As Exception
    '        MessageBox.Show("خطأ في تحميل إعدادات طابعة الباركود: " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnRefreshBarcodePrinters_Click(sender As Object, e As EventArgs)
    '    LoadBarcodePrintersList()
    '    MessageBox.Show("✅ تم تحديث قائمة الطابعات.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    'End Sub

    'Private Sub btnSaveBarcodePrinter_Click(sender As Object, e As EventArgs)
    '    Try
    '        SettingsManager.SaveSetting("BarcodePrinterName", cmbBarcodePrinter.Text)
    '        SettingsManager.SaveSetting("BarcodeLabelWidth", CInt(numBarcodeLabelWidth.Value).ToString())
    '        SettingsManager.SaveSetting("BarcodeLabelHeight", CInt(numBarcodeLabelHeight.Value).ToString())
    '        SettingsManager.SaveSetting("BarcodeCopies", CInt(numBarcodeCopies.Value).ToString())
    '        SettingsManager.SaveSetting("BarcodeFontSize", CInt(numBarcodeFontSize.Value).ToString())
    '        SettingsManager.SaveSetting("BarcodeFooterText", txtBarcodeFooter.Text.Trim())
    '        SettingsManager.SaveSetting("BarcodeShowName", chkBarcodeShowName.Checked.ToString().ToLower())
    '        SettingsManager.SaveSetting("BarcodeShowPrice", chkBarcodeShowPrice.Checked.ToString().ToLower())
    '        SettingsManager.SaveSetting("BarcodeShowStoreName", chkBarcodeShowStoreName.Checked.ToString().ToLower())
    '        Notify.Toast("تم حفظ إعدادات طابعة الباركود", Notify.ToastType.Success)
    '    Catch ex As Exception
    '        Notify.Error("خطأ في الحفظ: " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnTestBarcodePrinter_Click(sender As Object, e As EventArgs)
    '    Try
    '        If String.IsNullOrEmpty(cmbBarcodePrinter.Text) Then
    '            MessageBox.Show("يرجى اختيار طابعة الباركود أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return
    '        End If

    '        Dim labelWmm As Integer = CInt(numBarcodeLabelWidth.Value)
    '        Dim labelHmm As Integer = CInt(numBarcodeLabelHeight.Value)
    '        Dim labelWhi As Integer = CInt(labelWmm * 3.937)  ' مم → 1/100 بوصة
    '        Dim labelHhi As Integer = CInt(labelHmm * 3.937)
    '        Dim fontSize As Integer = CInt(numBarcodeFontSize.Value)
    '        Dim footer As String = txtBarcodeFooter.Text

    '        Using pd As New PrintDocument()
    '            pd.PrinterSettings.PrinterName = cmbBarcodePrinter.Text
    '            pd.DefaultPageSettings.PaperSize = New PaperSize("BarcodeLabel", labelWhi, labelHhi)
    '            pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
    '            pd.OriginAtMargins = False

    '            Dim handler As PrintPageEventHandler = Nothing
    '            handler = Sub(s2, ev)
    '                          Dim writer As New ZXing.BarcodeWriter() With {
    '                              .Format = ZXing.BarcodeFormat.CODE_128,
    '                              .Options = New ZXing.Common.EncodingOptions With {
    '                                  .Height = Math.Max(40, ev.PageBounds.Height - 35),
    '                                  .Width = Math.Max(80, ev.PageBounds.Width - 10),
    '                                  .Margin = 0, .PureBarcode = True}}
    '                          Using img As Bitmap = writer.Write("TEST12345")
    '                              Dim x As Integer = (ev.PageBounds.Width - img.Width) \ 2
    '                              ev.Graphics.DrawImage(img, x, 3)
    '                              Using fnt As New Font("Arial", fontSize, FontStyle.Bold)
    '                                  Dim txt As String = "TEST12345"
    '                                  Dim sz = ev.Graphics.MeasureString(txt, fnt)
    '                                  ev.Graphics.DrawString(txt, fnt, Brushes.Black,
    '                                                         (ev.PageBounds.Width - sz.Width) / 2, img.Height + 5)
    '                                  If Not String.IsNullOrEmpty(footer) Then
    '                                      Using fnt2 As New Font("Arial", Math.Max(6, fontSize - 2))
    '                                          Dim sz2 = ev.Graphics.MeasureString(footer, fnt2)
    '                                          ev.Graphics.DrawString(footer, fnt2, Brushes.Black,
    '                                                                 (ev.PageBounds.Width - sz2.Width) / 2,
    '                                                                 img.Height + 5 + sz.Height + 2)
    '                                      End Using
    '                                  End If
    '                              End Using
    '                          End Using
    '                          ev.HasMorePages = False
    '                      End Sub
    '            AddHandler pd.PrintPage, handler
    '            Try
    '                pd.Print()
    '                MessageBox.Show("✅ تم إرسال طباعة اختبار.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Finally
    '                RemoveHandler pd.PrintPage, handler
    '            End Try
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("❌ خطأ في الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    '══════════════════════════════════════════════════════════════
    ' ➊ تبويب الباركود (Scanner) — إعدادات متقدمة + تجربة حيّة
    '══════════════════════════════════════════════════════════════
    'Private Sub LoadPorts()
    '    ComboBoxPorts.Items.Clear()
    '    ComboBoxPorts.Items.AddRange(SerialPort.GetPortNames())
    'End Sub

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

    Private Async Function LoadTreasuriesAsync() As Task
        Try
            Dim dt As New DataTable()
            Using cn As SqlConnection = Await NewConnAsync()
                Const sql As String =
                "
                SELECT
                TreasuryID,
                TreasuryNameAr
                FROM Treasury
                WHERE IsActive = 1
                AND IsDeleted = 0
                ORDER BY IsDefault DESC, TreasuryNameAr
                "

                Using da As New SqlDataAdapter(sql, cn)
                    Await Task.Run(Sub() da.Fill(dt))
                End Using
            End Using

            cmbTreasury.DataSource = dt
            cmbTreasury.DisplayMember = "TreasuryNameAr"
            cmbTreasury.ValueMember = "TreasuryID"
            cmbTreasury.SelectedIndex = -1

            defaultTreasuryid = If(SettingsManager.GetSetting("defaultTreasuryid"), -1)
            cmbTreasury.SelectedIndex = defaultTreasuryid
        Catch ex As Exception
        End Try
    End Function

    Private Sub btnRefreshPorts_Click(sender As Object, e As EventArgs) Handles btnRefreshPorts.Click
        'LoadPorts()
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
            'Debug.WriteLine("scan test recv: " & ex.Message)
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
            'cmbCurrency.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.Currency, "ج.م")
            'cmbBusinessType.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.BusinessType, "سوبر ماركت")
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

            txtInvoiceItemsPerPage.Text = If(SettingsManager.GetSetting("InvoiceItemsPerPage"), "25")
            'txtdefaultcustomercode.Text = If(SettingsManager.GetSetting("defaultcustomercode"), "1")
            btnIsDineInServiceFeePercent.Checked = If(SettingsManager.GetSetting("IsDineInServiceFeePercent"), False)
            txtDineInServiceFee.Text = If(SettingsManager.GetSetting("DineInServiceFee"), "0")


            ' استدعاء الدالة أولاً لملء القوائم
            FillDefaultSettingsDropdowns()

            ' قراءة نوع الطلب الافتراضي المحفوظ (الافتراضي: 1 = تيك أوي)
            Dim defaultOrderType = If(SettingsManager.GetSetting("DefaultOrderType"), "1")
            cmbDefaultOrderType.SelectedValue = Convert.ToInt32(defaultOrderType)

            ' قراءة العميل الافتراضي المحفوظ
            Dim defaultCustomerID = If(SettingsManager.GetSetting("DefaultCustomerID"), "")
            If Not String.IsNullOrEmpty(defaultCustomerID) Then
                cmbDefaultCustomer.SelectedValue = Convert.ToInt32(defaultCustomerID)
            End If

            ' قراءة الطيار الافتراضي المحفوظ
            Dim defaultDriverID = If(SettingsManager.GetSetting("DefaultDriverID"), "")
            If Not String.IsNullOrEmpty(defaultDriverID) Then
                cmbDefaultDriver.SelectedValue = Convert.ToInt32(defaultDriverID)
            End If

            ' قراءة الفرع الحالي المحفوظ
            Dim defaultBranchID = If(SettingsManager.GetSetting("CurrentBranchID"), "")
            If Not String.IsNullOrEmpty(defaultBranchID) Then
                cmbBranches.SelectedValue = Convert.ToInt32(defaultBranchID)
            End If

            ' قراءة المخزن الحالي المحفوظ
            Dim defaultStoreID = If(SettingsManager.GetSetting("CurrentStoreID"), "")
            If Not String.IsNullOrEmpty(defaultStoreID) Then
                cmbStores.SelectedValue = Convert.ToInt32(defaultStoreID)
            End If
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

    Private Sub btnRefreshPrinters_Click(sender As Object, e As EventArgs) Handles btnRefreshPrinters.Click
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

    Private Sub btnSaveGeneral_Click(sender As Object, e As EventArgs) Handles btnSaveGeneral.Click
        Try
            ' حفظ معلومات المحل
            SettingsManager.SaveSetting("ShopName", txtShopName.Text.Trim())
            SettingsManager.SaveSetting("ShopPhone", txtShopPhone.Text.Trim())
            SettingsManager.SaveSetting("ShopPhone2", txtShopPhone2.Text.Trim())
            SettingsManager.SaveSetting("ShopAddress", txtShopAddress.Text.Trim())
            SettingsManager.SaveSetting("TaxNumber", txtShopTax.Text.Trim())
            SettingsManager.SaveSetting("FooterText", txtFooterText.Text.Trim())
            SettingsManager.SaveSetting("DeliveryText", txtDeliveryText.Text.Trim())
            'SettingsManager.SaveSetting(SettingsKeys.Currency, cmbCurrency.Text.Trim())
            'SettingsManager.SaveSetting(SettingsKeys.BusinessType, cmbBusinessType.Text.Trim())
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

    Private Sub btnTestThermal_Click(sender As Object, e As EventArgs) Handles btnTestThermal.Click
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
    Private Sub btnDetectServers_Click(sender As Object, e As EventArgs) Handles btnDetectServers.Click
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

    Private Sub chkWindowsAuth_CheckedChanged(sender As Object, e As EventArgs) Handles chkWindowsAuth.CheckedChanged
        UpdateAuthFields()
    End Sub

    Private Sub UpdateAuthFields()
        Dim useWin As Boolean = chkWindowsAuth.Checked
        txtDbUser.Enabled = Not useWin
        txtDbPassword.Enabled = Not useWin
        lblDbUser.Enabled = Not useWin
        lblDbPassword.Enabled = Not useWin
    End Sub

    Private Sub btnTestDbConnection_Click(sender As Object, e As EventArgs) Handles btnTestDbConnection.Click
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

    Private Sub btnSaveDbSettings_Click(sender As Object, e As EventArgs) Handles btnSaveDbSettings.Click
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
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        ElseIf WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            SettingsManager.SaveSetting("InvoiceItemsPerPage", txtInvoiceItemsPerPage.Text)
            'SettingsManager.SaveSetting("defaultcustomercode", txtdefaultcustomercode.Text)
            SettingsManager.SaveSetting("defaultTreasuryid", cmbTreasury.SelectedIndex)
            SettingsManager.SaveSetting("IsDineInServiceFeePercent", btnIsDineInServiceFeePercent.Checked)
            SettingsManager.SaveSetting("DineInServiceFee", txtDineInServiceFee.Text)

            ' حفظ نوع الطلب الافتراضي والعميل الافتراضي
            If cmbDefaultOrderType.SelectedValue IsNot Nothing Then
                SettingsManager.SaveSetting("DefaultOrderType", cmbDefaultOrderType.SelectedValue.ToString())
            End If

            If cmbDefaultCustomer.SelectedValue IsNot Nothing Then
                SettingsManager.SaveSetting("DefaultCustomerID", cmbDefaultCustomer.SelectedValue.ToString())
            End If
            If cmbDefaultDriver.SelectedValue IsNot Nothing Then
                SettingsManager.SaveSetting("DefaultDriverID", cmbDefaultDriver.SelectedValue.ToString())
            End If

            ' حفظ الفرع والمخزن الحاليين
            If cmbBranches.SelectedValue IsNot Nothing Then
                SettingsManager.SaveSetting("CurrentBranchID", cmbBranches.SelectedValue.ToString())
            End If

            If cmbStores.SelectedValue IsNot Nothing Then
                SettingsManager.SaveSetting("CurrentStoreID", cmbStores.SelectedValue.ToString())
            End If

            Notify.Toast("تم حفظ إعدادات المبيعات", Notify.ToastType.Success)
        Catch ex As Exception
            Notify.Error("خطأ في الحفظ: " & ex.Message)
        End Try
    End Sub

    ' زر الإغلاق
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub


    Private Sub FillDefaultSettingsDropdowns()


        Dim repo As New POSRepository(DBModule.ConnectionString)
        ' 1. تعبئة قائمة الفروع
        Dim dtBranches = repo.GetActiveBranches()
        cmbBranches.DataSource = dtBranches
        cmbBranches.DisplayMember = "BranchName"
        cmbBranches.ValueMember = "BranchID"
        cmbBranches.SelectedIndex = -1

        ' 2. تعبئة قائمة المخازن
        Dim dtStores = repo.GetActiveStores()
        cmbStores.DataSource = dtStores
        cmbStores.DisplayMember = "StoreName"
        cmbStores.ValueMember = "StoreID"
        cmbStores.SelectedIndex = -1

        ' 1. تعبئة قائمة نوع الطلب الافتراضي
        Dim dtOrderTypes As New DataTable()
        dtOrderTypes.Columns.Add("TypeID", GetType(Integer))
        dtOrderTypes.Columns.Add("TypeName", GetType(String))

        dtOrderTypes.Rows.Add(1, "تيك أوي")
        dtOrderTypes.Rows.Add(2, "صالة")
        dtOrderTypes.Rows.Add(3, "دليفري")

        cmbDefaultOrderType.DataSource = dtOrderTypes
        cmbDefaultOrderType.DisplayMember = "TypeName"
        cmbDefaultOrderType.ValueMember = "TypeID"

        ' 2. تعبئة قائمة العملاء
        Dim customers = repo.GetActiveCustomers()

        cmbDefaultCustomer.DataSource = customers
        cmbDefaultCustomer.DisplayMember = "CustomerName"
        cmbDefaultCustomer.ValueMember = "CustomerID"


        ' جلب قائمة الطيارين النشطين
        Dim drivers = repo.GetActiveDeliveryDrivers()
        cmbDefaultDriver.DataSource = drivers
        cmbDefaultDriver.DisplayMember = "DriverName"
        cmbDefaultDriver.ValueMember = "DriverID"
        cmbDefaultDriver.SelectedIndex = -1
    End Sub
End Class