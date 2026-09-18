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
                cmbNormalPrinter.Items.Clear()

                For Each printerName As String In PrinterSettings.InstalledPrinters
                    cmbThermalPrinter.Items.Add(printerName)
                    cmbNormalPrinter.Items.Add(printerName)
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
                Dim savedNormal = SettingsManager.GetSettingOrDefault(SettingsKeys.NormalPrinterName, "")

                If Not String.IsNullOrEmpty(savedThermal) Then cmbThermalPrinter.Text = savedThermal
                If Not String.IsNullOrEmpty(savedNormal) Then cmbNormalPrinter.Text = savedNormal

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

                ' نمط الطباعة
                Dim styleVal = SettingsManager.GetSettingOrDefault(SettingsKeys.PrintStyle, "1")
                If styleVal = "2" Then
                    rbStyleAdvanced.Checked = True
                Else
                    rbStyleSimple.Checked = True
                End If

                ' خيارات الطباعة
                chkPrintLogo.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PrintLogo, True)
                chkPrintBarcode.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PrintBarcode, True)
                chkPrintPreview.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PrintPreview, False)
                tglAutoPrint.Checked = SettingsManager.GetBoolSettingDual(SettingsKeys.PrinterAutoPrint, SettingsKeys.PrintReceiptOnPayment, True)
                tglOpenDrawer.Checked = SettingsManager.GetBoolSettingDual(SettingsKeys.PrinterOpenCashDrawer, SettingsKeys.OpenDrawerOnPayment, True)
                txtCopies.Text = SettingsManager.GetIntSetting(SettingsKeys.PrinterCopiesCount, 1).ToString()
            Catch ex As Exception
                MessageBox.Show("خطأ في قراءة إعدادات الطابعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                ' حفظ اسم الطابعة بالتوافق مع نسختي البرنامج
                SettingsManager.SaveSettingDual(SettingsKeys.ThermalPrinterName, SettingsKeys.DefaultPrinterName, cmbThermalPrinter.Text.Trim())
                SettingsManager.SaveSetting(SettingsKeys.NormalPrinterName, cmbNormalPrinter.Text.Trim())

                ' حفظ مقاس الورق
                Dim paperSize As String = "80mm"
                If rbSize58.Checked Then
                    paperSize = "58mm"
                ElseIf rbSizeA4.Checked Then
                    paperSize = "A4"
                End If
                SettingsManager.SaveSetting(SettingsKeys.PrinterPaperSize, paperSize)

                ' حفظ نمط الطباعة
                SettingsManager.SaveSetting(SettingsKeys.PrintStyle, If(rbStyleAdvanced.Checked, "2", "1"))

                ' حفظ خيارات الطباعة
                SettingsManager.SaveSetting(SettingsKeys.PrintLogo, chkPrintLogo.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.PrintBarcode, chkPrintBarcode.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.PrintPreview, chkPrintPreview.Checked.ToString().ToLower())
                SettingsManager.SaveSettingDual(SettingsKeys.PrinterAutoPrint, SettingsKeys.PrintReceiptOnPayment, tglAutoPrint.Checked.ToString().ToLower())
                SettingsManager.SaveSettingDual(SettingsKeys.PrinterOpenCashDrawer, SettingsKeys.OpenDrawerOnPayment, tglOpenDrawer.Checked.ToString().ToLower())

                Dim copies As Integer
                If Integer.TryParse(txtCopies.Text.Trim(), copies) AndAlso copies > 0 Then
                    SettingsManager.SaveSetting(SettingsKeys.PrinterCopiesCount, copies.ToString())
                End If

                Try
                    Notify.Toast("تم حفظ إعدادات الطابعة بنجاح ✅", Notify.ToastType.Success)
                Catch
                    MessageBox.Show("✅ تم حفظ إعدادات الطابعة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            Dim paperSize As String = If(rbSize58.Checked, "58mm", "80mm")
            ThermalTestReceiptHelper.PrintTestReceipt(
                printerName:=cmbThermalPrinter.Text.Trim(),
                paperSize:=paperSize,
                printLogo:=chkPrintLogo.Checked,
                printBarcode:=chkPrintBarcode.Checked,
                openDrawer:=tglOpenDrawer.Checked,
                usePreview:=chkPrintPreview.Checked
            )
        End Sub


        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If MessageBox.Show("هل أنت متأكد من استعادة القيم الافتراضية لإعدادات الطابعة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                rbSize80.Checked = True
                rbStyleSimple.Checked = True
                chkPrintLogo.Checked = True
                chkPrintBarcode.Checked = True
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
