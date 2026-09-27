Imports System.Drawing.Printing
Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات الطابعات ومقاس الورق ودرج النقدية
    ''' </summary>
    Public Class UCPrinterSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCPrinterSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadPrintersList()
            LoadSettings()
        End Sub

        Private Sub LoadPrintersList()
            Try
                cmbThermalPrinter.Items.Clear()
                cmbKitchenPrinter.Items.Clear()
                cmbNormalPrinter.Items.Clear()
                cmbBarcodePrinter.Items.Clear()

                For Each printerName As String In PrinterSettings.InstalledPrinters
                    cmbThermalPrinter.Items.Add(printerName)
                    cmbKitchenPrinter.Items.Add(printerName)
                    cmbNormalPrinter.Items.Add(printerName)
                    cmbBarcodePrinter.Items.Add(printerName)
                Next
            Catch ex As Exception
                Debug.WriteLine("LoadPrintersList error: " & ex.Message)
            End Try
        End Sub

        Private Sub btnRefreshPrinters_Click(sender As Object, e As EventArgs) Handles btnRefreshPrinters.Click
            LoadPrintersList()
            Try
                Notify.Toast("تم تحديث قائمة الطابعات بنجاح ✅", Notify.ToastType.Success)
            Catch
                MessageBox.Show("✅ تم تحديث قائمة الطابعات بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        Public Sub LoadSettings()
            Try
                ' الطابعات المحفوظة (دعم المفاتيح المتوافقة مع نسختي VB و C#)
                Dim savedThermal = SettingsManager.GetSettingDual(SettingsKeys.ThermalPrinterName, SettingsKeys.DefaultPrinterName, "")
                Dim savedKitchen = SettingsManager.GetSettingOrDefault(SettingsKeys.KitchenPrinterName, "")
                Dim savedNormal = SettingsManager.GetSettingOrDefault(SettingsKeys.NormalPrinterName, "")
                Dim savedBarcode = SettingsManager.GetSettingOrDefault(SettingsKeys.BarcodePrinterName, "")

                ' في حال لم تكن هناك طابعة محددة مسبقاً، نختار طابعة النظام الافتراضية
                If String.IsNullOrEmpty(savedThermal) Then
                    Try
                        Dim ps As New PrinterSettings()
                        savedThermal = ps.PrinterName
                    Catch
                    End Try
                End If

                SelectComboValue(cmbThermalPrinter, savedThermal)
                SelectComboValue(cmbKitchenPrinter, savedKitchen)
                SelectComboValue(cmbNormalPrinter, savedNormal)
                SelectComboValue(cmbBarcodePrinter, savedBarcode)

                ' مقاس الورق
                Dim paperSize = SettingsManager.GetSettingOrDefault(SettingsKeys.PrinterPaperSize, "80mm")
                Select Case paperSize.ToLower()
                    Case "58mm"
                        rbSize58.Checked = True
                    Case "a4"
                        rbSizeA4.Checked = True
                    Case Else
                        rbSize80.Checked = True
                End Select

                ' خيارات الطباعة
                chkPrintLogo.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PrintLogo, True)
                chkPrintBarcode.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PrintBarcode, True)
                Dim barcodeType = SettingsManager.GetSettingOrDefault(SettingsKeys.InvoiceBarcodeType, "2D")
                cmbBarcodeType.SelectedIndex = If(barcodeType.Equals("1D", StringComparison.OrdinalIgnoreCase), 1, 0)
                cmbBarcodeType.Visible = chkPrintBarcode.Checked
                chkPrintPreview.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PrintPreview, False)
                tglAutoPrint.Checked = SettingsManager.GetBoolSettingDual(SettingsKeys.PrinterAutoPrint, SettingsKeys.PrintReceiptOnPayment, True)
                tglAutoPrintKitchen.Checked = SettingsManager.GetBoolSetting(SettingsKeys.AutoPrintKitchenTicket, True)
                tglAutoPrintFollowUp.Checked = SettingsManager.GetBoolSetting(SettingsKeys.AutoPrintFollowUpTicket, True)
                Dim kDesign = SettingsManager.GetSettingOrDefault(SettingsKeys.KitchenTicketDesign, "1")
                cmbKitchenDesign.SelectedIndex = If(kDesign = "2", 1, 0)
                tglOpenDrawer.Checked = SettingsManager.GetBoolSettingDual(SettingsKeys.PrinterOpenCashDrawer, SettingsKeys.OpenDrawerOnPayment, True)
                txtCopies.Text = SettingsManager.GetIntSetting(SettingsKeys.PrinterCopiesCount, 1).ToString()
            Catch ex As Exception
                MessageBox.Show("خطأ في قراءة إعدادات الطابعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkPrintBarcode_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrintBarcode.CheckedChanged
            cmbBarcodeType.Visible = chkPrintBarcode.Checked
        End Sub

        Private Sub SelectComboValue(cmb As Guna.UI2.WinForms.Guna2ComboBox, value As String)
            If String.IsNullOrWhiteSpace(value) Then Return
            Dim idx = cmb.FindStringExact(value)
            If idx >= 0 Then
                cmb.SelectedIndex = idx
            Else
                cmb.Text = value
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                ' حفظ اسم الطابعة بالتوافق مع نسختي البرنامج
                SettingsManager.SaveSettingDual(SettingsKeys.ThermalPrinterName, SettingsKeys.DefaultPrinterName, cmbThermalPrinter.Text.Trim())
                SettingsManager.SaveSetting(SettingsKeys.KitchenPrinterName, cmbKitchenPrinter.Text.Trim())
                SettingsManager.SaveSetting(SettingsKeys.NormalPrinterName, cmbNormalPrinter.Text.Trim())
                SettingsManager.SaveSetting(SettingsKeys.BarcodePrinterName, cmbBarcodePrinter.Text.Trim())

                ' حفظ مقاس الورق
                Dim paperSize As String = "80mm"
                If rbSize58.Checked Then
                    paperSize = "58mm"
                ElseIf rbSizeA4.Checked Then
                    paperSize = "A4"
                End If
                SettingsManager.SaveSetting(SettingsKeys.PrinterPaperSize, paperSize)

                ' حفظ خيارات الطباعة
                SettingsManager.SaveSetting(SettingsKeys.PrintLogo, chkPrintLogo.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.PrintBarcode, chkPrintBarcode.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.InvoiceBarcodeType, If(cmbBarcodeType.SelectedIndex = 1, "1D", "2D"))
                SettingsManager.SaveSetting(SettingsKeys.PrintPreview, chkPrintPreview.Checked.ToString().ToLower())
                SettingsManager.SaveSettingDual(SettingsKeys.PrinterAutoPrint, SettingsKeys.PrintReceiptOnPayment, tglAutoPrint.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.AutoPrintKitchenTicket, tglAutoPrintKitchen.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.AutoPrintFollowUpTicket, tglAutoPrintFollowUp.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.KitchenTicketDesign, If(cmbKitchenDesign.SelectedIndex = 1, "2", "1"))
                SettingsManager.SaveSettingDual(SettingsKeys.PrinterOpenCashDrawer, SettingsKeys.OpenDrawerOnPayment, tglOpenDrawer.Checked.ToString().ToLower())

                Dim copies As Integer
                If Integer.TryParse(txtCopies.Text.Trim(), copies) AndAlso copies > 0 Then
                    SettingsManager.SaveSetting(SettingsKeys.PrinterCopiesCount, copies.ToString())
                End If

                Try
                    Notify.Toast("تم حفظ إعدادات الطابعة والطباعة بنجاح ✅", Notify.ToastType.Success)
                Catch
                    MessageBox.Show("✅ تم حفظ إعدادات الطابعة والطباعة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Catch ex As Exception
                MessageBox.Show("خطأ في حفظ إعدادات الطابعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnTestThermal_Click(sender As Object, e As EventArgs) Handles btnTestThermal.Click
            If String.IsNullOrWhiteSpace(cmbThermalPrinter.Text) Then
                MessageBox.Show("يرجى اختيار الطابعة الحرارية أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim paperSize As String = If(rbSize58.Checked, "58mm", If(rbSizeA4.Checked, "A4", "80mm"))
            ThermalTestReceiptHelper.PrintTestReceipt(
                printerName:=cmbThermalPrinter.Text.Trim(),
                paperSize:=paperSize,
                printLogo:=chkPrintLogo.Checked,
                printBarcode:=chkPrintBarcode.Checked,
                openDrawer:=tglOpenDrawer.Checked,
                usePreview:=chkPrintPreview.Checked
            )
        End Sub

        Private Sub btnTestKitchen_Click(sender As Object, e As EventArgs) Handles btnTestKitchen.Click
            Dim kitchenPrn As String = cmbKitchenPrinter.Text.Trim()
            If String.IsNullOrWhiteSpace(kitchenPrn) AndAlso Not chkPrintPreview.Checked Then
                MessageBox.Show("يرجى اختيار طابعة المطبخ أولاً أو تفعيل المعاينة قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                ' حفظ التصميم المختار مؤقتاً لتطبيقه في التجربة
                SettingsManager.SaveSetting(SettingsKeys.KitchenTicketDesign, If(cmbKitchenDesign.SelectedIndex = 1, "2", "1"))

                Dim testItems As New List(Of InvoiceDetailModel) From {
                    New InvoiceDetailModel With {.ProductName = "برجر كلاسيك دوبل بالجبنة وصوص المشروم الخاص", .SizeName = "كبير عائلي", .Quantity = 2, .AddonsText = "جبنة شيدر إضافية + صوص باربيكيو", .Notes = "بدون بصل - تسوية زيادة على الجريل"},
                    New InvoiceDetailModel With {.ProductName = "بيتزا رانش دجاج مقرمشة مع الخضار الطازج", .SizeName = "وسط", .Quantity = 1, .Notes = "تسوية كرسبي مقرمشة مع تقطيع 8 قطع"},
                    New InvoiceDetailModel With {.ProductName = "بطاطس محمرة فارم فريتس متبلة", .Quantity = 3, .AddonsText = "بهارات حارة"}
                }

                RestaurantPrintManager.PrintKitchenTicket(
                    orderNumber:="تجربة-01",
                    orderTypeDesc:="صالة - طاولة 5",
                    tableName:="طاولة 5",
                    staffName:="كاشير تجريبي",
                    items:=testItems,
                    ticketTitle:="طلب تجهيز المطبخ (تجريبي)",
                    customPrinterName:=kitchenPrn,
                    forcePreview:=chkPrintPreview.Checked
                )

                If Not chkPrintPreview.Checked Then
                    Try
                        Notify.Toast("تم إرسال بون الاختبار لطابعة المطبخ بنجاح 🍳", Notify.ToastType.Success)
                    Catch
                        MessageBox.Show("✅ تم إرسال بون الاختبار لطابعة المطبخ بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show("خطأ أثناء طباعة تجربة المطبخ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If MessageBox.Show("هل أنت متأكد من استعادة القيم الافتراضية لإعدادات الطابعة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    Dim ps As New PrinterSettings()
                    SelectComboValue(cmbThermalPrinter, ps.PrinterName)
                Catch
                End Try
                cmbKitchenPrinter.SelectedIndex = -1
                cmbKitchenPrinter.Text = ""
                cmbNormalPrinter.SelectedIndex = -1
                cmbNormalPrinter.Text = ""
                cmbBarcodePrinter.SelectedIndex = -1
                cmbBarcodePrinter.Text = ""
                rbSize80.Checked = True
                chkPrintLogo.Checked = True
                chkPrintBarcode.Checked = True
                cmbBarcodeType.SelectedIndex = 0
                cmbBarcodeType.Visible = True
                chkPrintPreview.Checked = False
                tglAutoPrint.Checked = True
                tglOpenDrawer.Checked = True
                txtCopies.Text = "1"
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
