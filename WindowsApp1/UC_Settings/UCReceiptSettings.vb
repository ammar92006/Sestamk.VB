Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' شاشة تخصيص الفاتورة وبيانات المؤسسة والشعار
    ''' </summary>
    Public Class UCReceiptSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCReceiptSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadSettings()
        End Sub

        Public Sub LoadSettings()
            Try
                ' بيانات المحل بالتوافق مع المفاتيح المزدوجة لنسختي VB و C#
                txtShopName.Text = SettingsManager.GetSettingDual(SettingsKeys.ShopName, SettingsKeys.StoreName, "")
                txtShopPhone.Text = SettingsManager.GetSettingDual(SettingsKeys.ShopPhone, SettingsKeys.StorePhone, "")
                txtShopPhone2.Text = SettingsManager.GetSettingDual(SettingsKeys.ShopPhone2, SettingsKeys.StorePhone2, "")
                txtShopAddress.Text = SettingsManager.GetSettingDual(SettingsKeys.ShopAddress, SettingsKeys.StoreAddress, "")
                txtShopTax.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.TaxNumber, "")

                ' الشعار
                txtLogoPath.Text = SettingsManager.GetSettingDual(SettingsKeys.LogoPath, SettingsKeys.ReceiptLogoPath, "")
                tglShowLogo.Checked = SettingsManager.GetBoolSettingDual(SettingsKeys.ShowLogo, SettingsKeys.PrintLogo, True)
                LoadLogoPreview(txtLogoPath.Text)

                ' تصميم وهيئة الفاتورة
                Dim fontSizeVal = SettingsManager.GetSettingOrDefault(SettingsKeys.ReceiptFontSize, "8.5")
                Select Case fontSizeVal
                    Case "7"
                        cmbFontSize.SelectedIndex = 0
                    Case "10"
                        cmbFontSize.SelectedIndex = 2
                    Case "12"
                        cmbFontSize.SelectedIndex = 3
                    Case Else
                        cmbFontSize.SelectedIndex = 1
                End Select

                Dim styleVal = SettingsManager.GetSettingOrDefault(SettingsKeys.ReceiptStyle, "")
                If String.IsNullOrWhiteSpace(styleVal) Then
                    Dim oldPrintStyle = SettingsManager.GetSettingOrDefault(SettingsKeys.PrintStyle, "1")
                    styleVal = If(oldPrintStyle = "2", "Grid", "Classic")
                End If
                If styleVal.Equals("Grid", StringComparison.OrdinalIgnoreCase) OrElse styleVal = "2" Then
                    cmbReceiptStyle.SelectedIndex = 1
                Else
                    cmbReceiptStyle.SelectedIndex = 0
                End If

                tglShowTax.Checked = SettingsManager.GetBoolSetting(SettingsKeys.ShowTax, True)
                tglShowDiscount.Checked = SettingsManager.GetBoolSetting(SettingsKeys.ShowDiscount, True)
                tglShowCashier.Checked = SettingsManager.GetBoolSetting(SettingsKeys.ShowCashier, True)

                ' نصوص التذييل
                txtFooterText.Text = SettingsManager.GetSettingDual(SettingsKeys.FooterText, SettingsKeys.ReceiptFooter, "شكراً لزيارتكم - نتمنى لكم يوماً سعيداً")
                txtDeliveryText.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.DeliveryText, "يوجد توصيل للمنازل")
            Catch ex As Exception
                SmartMessageBox.Show("خطأ في قراءة إعدادات الفاتورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnBrowseLogo_Click(sender As Object, e As EventArgs) Handles btnBrowseLogo.Click
            Using dlg As New OpenFileDialog()
                dlg.Title = "اختر صورة شعار المؤسسة"
                dlg.Filter = "ملفات الصور|*.png;*.jpg;*.jpeg;*.bmp;*.gif|كل الملفات|*.*"
                If dlg.ShowDialog() = DialogResult.OK Then
                    txtLogoPath.Text = dlg.FileName
                    LoadLogoPreview(dlg.FileName)
                End If
            End Using
        End Sub

        Private Sub LoadLogoPreview(path As String)
            Try
                If picLogoPreview.Image IsNot Nothing Then
                    Dim old = picLogoPreview.Image
                    picLogoPreview.Image = Nothing
                    old.Dispose()
                End If

                If Not String.IsNullOrWhiteSpace(path) AndAlso File.Exists(path) Then
                    Using fs As New FileStream(path, FileMode.Open, FileAccess.Read)
                        Using tmp As Image = Image.FromStream(fs)
                            picLogoPreview.Image = New Bitmap(tmp)
                        End Using
                    End Using
                End If
            Catch ex As Exception
                Debug.WriteLine("LoadLogoPreview error: " & ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' حفظ الإعدادات في قاعدة البيانات
        ''' </summary>
        Private Sub SaveSettingsInternal(Optional showToast As Boolean = True)
            ' حفظ بيانات المحل بالتوافق بين VB و C#
            SettingsManager.SaveSettingDual(SettingsKeys.ShopName, SettingsKeys.StoreName, txtShopName.Text.Trim())
            SettingsManager.SaveSettingDual(SettingsKeys.ShopPhone, SettingsKeys.StorePhone, txtShopPhone.Text.Trim())
            SettingsManager.SaveSettingDual(SettingsKeys.ShopPhone2, SettingsKeys.StorePhone2, txtShopPhone2.Text.Trim())
            SettingsManager.SaveSettingDual(SettingsKeys.ShopAddress, SettingsKeys.StoreAddress, txtShopAddress.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.TaxNumber, txtShopTax.Text.Trim())

            ' حفظ الشعار
            SettingsManager.SaveSettingDual(SettingsKeys.LogoPath, SettingsKeys.ReceiptLogoPath, txtLogoPath.Text.Trim())
            SettingsManager.SaveSettingDual(SettingsKeys.ShowLogo, SettingsKeys.PrintLogo, tglShowLogo.Checked.ToString().ToLower())

            ' حجم الخط
            Dim fontSizes = New String() {"7", "8.5", "10", "12"}
            Dim selectedFontSize = fontSizes(Math.Max(0, Math.Min(cmbFontSize.SelectedIndex, fontSizes.Length - 1)))
            SettingsManager.SaveSetting(SettingsKeys.ReceiptFontSize, selectedFontSize)

            ' نمط الفاتورة والتوافق مع PrintStyle (1=Classic, 2=Grid)
            Dim isGrid = (cmbReceiptStyle.SelectedIndex = 1)
            SettingsManager.SaveSetting(SettingsKeys.ReceiptStyle, If(isGrid, "Grid", "Classic"))
            SettingsManager.SaveSetting(SettingsKeys.PrintStyle, If(isGrid, "2", "1"))

            SettingsManager.SaveSetting(SettingsKeys.ShowTax, tglShowTax.Checked.ToString().ToLower())
            SettingsManager.SaveSetting(SettingsKeys.ShowDiscount, tglShowDiscount.Checked.ToString().ToLower())
            SettingsManager.SaveSetting(SettingsKeys.ShowCashier, tglShowCashier.Checked.ToString().ToLower())

            ' نصوص التذييل
            SettingsManager.SaveSettingDual(SettingsKeys.FooterText, SettingsKeys.ReceiptFooter, txtFooterText.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.DeliveryText, txtDeliveryText.Text.Trim())

            If showToast Then
                Try
                    Notify.Toast("تم حفظ إعدادات الفاتورة بنجاح ✅", Notify.ToastType.Success)
                Catch
                    SmartMessageBox.Show("✅ تم حفظ إعدادات الفاتورة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                SaveSettingsInternal(showToast:=True)
            Catch ex As Exception
                SmartMessageBox.Show("خطأ في حفظ إعدادات الفاتورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If SmartMessageBox.Show("هل أنت متأكد من استعادة القيم الافتراضية لإعدادات الفاتورة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                cmbFontSize.SelectedIndex = 1
                cmbReceiptStyle.SelectedIndex = 0
                tglShowLogo.Checked = True
                tglShowTax.Checked = True
                tglShowDiscount.Checked = True
                tglShowCashier.Checked = True
                txtFooterText.Text = "شكراً لزيارتكم - نتمنى لكم يوماً سعيداً"
                txtDeliveryText.Text = "يوجد توصيل للمنازل"
            End If
        End Sub

        Private Sub btnTestReceipt_Click(sender As Object, e As EventArgs) Handles btnTestReceipt.Click
            Try
                ' تطبيق الإعدادات الحالية لتعكس المعاينة فوراً ما اختاره المستخدم
                SaveSettingsInternal(showToast:=False)

                ' إنشاء فاتورة تجريبية لاختبار التصميم
                Dim testInv As New InvoiceModel() With {
                    .InvoiceID = 9999,
                    .InvoiceNumber = "DEMO-1001",
                    .InvoiceDate = DateTime.Now,
                    .OrderType = 2,
                    .TotalBeforeDiscount = 385D,
                    .DiscountAmount = If(tglShowDiscount.Checked, 25D, 0D),
                    .DeliveryFee = 0D,
                    .NetTotal = If(tglShowDiscount.Checked, 360D, 385D),
                    .PaidAmount = 400D,
                    .RemainingAmount = If(tglShowDiscount.Checked, 40D, 15D)
                }

                testInv.Details.Add(New InvoiceDetailModel With {
                    .ProductName = "بيتزا سوبر سوبريم",
                    .SizeName = "كبير",
                    .UnitPrice = 145D,
                    .Quantity = 1,
                    .TotalPrice = 145D,
                    .AddonsText = "موتزاريلا إضافية"
                })

                testInv.Details.Add(New InvoiceDetailModel With {
                    .ProductName = "برجر كلاسيك دوبل",
                    .SizeName = "عادي",
                    .UnitPrice = 90D,
                    .Quantity = 2,
                    .TotalPrice = 180D,
                    .Notes = "بدون صوص حار"
                })

                testInv.Details.Add(New InvoiceDetailModel With {
                    .ProductName = "بطاطس فارم فريتس",
                    .SizeName = "عادي",
                    .UnitPrice = 30D,
                    .Quantity = 2,
                    .TotalPrice = 60D
                })

                ' فتح شاشة المعاينة الحية للفاتورة مباشرة
                RestaurantPrintManager.PrintCustomerReceipt(
                    inv:=testInv,
                    customerName:="عميل تجريبي",
                    tableName:="طاولة 4",
                    driverName:="",
                    isReprint:=False,
                    customPrinterName:="",
                    forcePreview:=True
                )
            Catch ex As Exception
                SmartMessageBox.Show("خطأ أثناء تجربة طباعة الفاتورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
