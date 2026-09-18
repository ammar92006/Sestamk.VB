Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms

Public Class RestaurantPrintManager

    ' أوامر ESC/POS القياسية
    Private Shared ReadOnly ESC_DRAWER_KICK As Byte() = {&H1B, &H70, &H0, &H19, &HFA} ' فتح درج الكاشير
    Private Shared ReadOnly ESC_PAPER_CUT As Byte() = {&H1D, &H56, &H41, &H0}       ' قص الورق الكامل

    ''' <summary>
    ''' جلب اسم الطابعة الحرارية المحفوظة في الإعدادات أو الطابعة الافتراضية
    ''' </summary>
    Public Shared Function GetDefaultThermalPrinter() As String
        Dim printerName As String = SettingsManager.GetSetting("ThermalPrinterName")
        If String.IsNullOrWhiteSpace(printerName) Then
            Dim ps As New PrinterSettings()
            printerName = ps.PrinterName
        End If
        Return printerName
    End Function

    ''' <summary>
    ''' فتح درج النقدية عبر إرسال نبضة للطابعة الحرارية
    ''' </summary>
    Public Shared Sub OpenCashDrawer(Optional customPrinterName As String = "")
        Try
            Dim prn = If(String.IsNullOrWhiteSpace(customPrinterName), GetDefaultThermalPrinter(), customPrinterName)
            If Not String.IsNullOrWhiteSpace(prn) Then
                RawPrinterHelper.SendBytesToPrinter(prn, ESC_DRAWER_KICK)
            End If
        Catch ex As Exception
            Debug.WriteLine("OpenCashDrawer error: " & ex.Message)
        End Try
    End Sub

    ' ═════════════════════════════════════════════════════════════════
    ' 1. طباعة فاتورة العميل (Guest Receipt)
    ' ═════════════════════════════════════════════════════════════════
    Public Shared Sub PrintCustomerReceipt(inv As InvoiceModel,
                                           Optional customerName As String = "",
                                           Optional tableName As String = "",
                                           Optional driverName As String = "",
                                           Optional isReprint As Boolean = False,
                                           Optional customPrinterName As String = "")
        Try
            Dim prn = If(String.IsNullOrWhiteSpace(customPrinterName), GetDefaultThermalPrinter(), customPrinterName)
            If String.IsNullOrWhiteSpace(prn) Then
                MessageBox.Show("لم يتم تحديد طابعة فواتير في الإعدادات!", "تنبيه الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' معلومات المحل
            Dim shopName = SettingsManager.GetSettingOrDefault("ShopName", "مطعم")
            Dim shopPhone = SettingsManager.GetSettingOrDefault("ShopPhone", "")
            Dim shopPhone2 = SettingsManager.GetSettingOrDefault("ShopPhone2", "")
            Dim shopAddress = SettingsManager.GetSettingOrDefault("ShopAddress", "")
            Dim shopTax = SettingsManager.GetSettingOrDefault("TaxNumber", "")
            Dim footerText = SettingsManager.GetSettingOrDefault("FooterText", "شكراً لزيارتكم ونتشرف بخدمتكم دائماً")
            Dim logoPath = SettingsManager.GetSettingOrDefault("LogoPath", "")
            Dim printLogo = SettingsManager.GetBoolSetting("PrintLogo", True)

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = prn
            pd.DefaultPageSettings.Margins = New Margins(4, 4, 4, 4)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If pageWidth > 300 Then pageWidth = 290 ' ضبط عرض الإيصال القياسي 80 مم

                                         Dim yPos As Integer = 5

                                         ' 1. اللوجو إن وجد
                                         If printLogo AndAlso Not String.IsNullOrEmpty(logoPath) AndAlso File.Exists(logoPath) Then
                                             Try
                                                 Using logoImg = Image.FromFile(logoPath)
                                                     Dim logoW As Integer = Math.Min(160, pageWidth - 40)
                                                     Dim logoH As Integer = CInt(logoImg.Height * (CDbl(logoW) / logoImg.Width))
                                                     If logoH > 70 Then logoH = 70
                                                     Dim logoX As Integer = (pageWidth - logoW) \ 2
                                                     g.DrawImage(logoImg, New Rectangle(logoX, yPos, logoW, logoH))
                                                     yPos += logoH + 6
                                                 End Using
                                             Catch
                                             End Try
                                         End If

                                         ' 2. اسم المطعم والهيدر
                                         Using fontTitle As New Font("Segoe UI", 13.0!, FontStyle.Bold),
                                               fontSub As New Font("Segoe UI", 8.5!, FontStyle.Regular),
                                               fontBold As New Font("Segoe UI", 9.0!, FontStyle.Bold),
                                               fontRegular As New Font("Segoe UI", 8.5!, FontStyle.Regular),
                                               sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center},
                                               sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
                                               sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near}

                                             ' اسم المحل
                                             g.DrawString(shopName, fontTitle, Brushes.Black, New RectangleF(0, yPos, pageWidth, 26), sfCenter)
                                             yPos += 26

                                             ' العنوان والهاتف
                                             If Not String.IsNullOrWhiteSpace(shopAddress) Then
                                                 g.DrawString(shopAddress, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
                                                 yPos += 18
                                             End If
                                             Dim phones = shopPhone & If(Not String.IsNullOrWhiteSpace(shopPhone2), " - " & shopPhone2, "")
                                             If Not String.IsNullOrWhiteSpace(phones) Then
                                                 g.DrawString("هاتف: " & phones, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
                                                 yPos += 18
                                             End If
                                             If Not String.IsNullOrWhiteSpace(shopTax) Then
                                                 g.DrawString("الرقم الضريبي: " & shopTax, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
                                                 yPos += 18
                                             End If

                                             ' شريط نوع الفاتورة
                                             yPos += 4
                                             Dim badgeText As String = If(isReprint, "فاتورة مبيعات (نسخة معاد طباعتها)", "فاتورة ضريبية مبسطة")
                                             g.DrawString(badgeText, fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 20), sfCenter)
                                             yPos += 20

                                             DrawDashedLine(g, yPos, pageWidth)
                                             yPos += 6

                                             ' بيانات الفاتورة
                                             g.DrawString("رقم الفاتورة: " & inv.InvoiceNumber, fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                                             yPos += 18
                                             g.DrawString("التاريخ والوقت: " & inv.InvoiceDate.ToString("yyyy/MM/dd - hh:mm tt"), fontRegular, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                                             yPos += 18

                                             ' بيان نوع الطلب
                                             Dim orderTypeDesc As String = ""
                                             Select Case inv.OrderType
                                                 Case 1 : orderTypeDesc = "تيك أوي (Takeaway)"
                                                 Case 2 : orderTypeDesc = "صالة (Dine-In) - طاولة: " & If(Not String.IsNullOrWhiteSpace(tableName), tableName, inv.TableID.ToString())
                                                 Case 3 : orderTypeDesc = "دليفري (Delivery)" & If(Not String.IsNullOrWhiteSpace(driverName), " - طيار: " & driverName, "")
                                                 Case Else : orderTypeDesc = "طلب مطعم"
                                             End Select

                                             g.DrawString("نوع الطلب: " & orderTypeDesc, fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 20), sfRight)
                                             yPos += 20

                                             ' بيانات العميل لو دليفري أو آجل
                                             If Not String.IsNullOrWhiteSpace(customerName) Then
                                                 g.DrawString("العميل: " & customerName, fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                                                 yPos += 18
                                             End If

                                             DrawDashedLine(g, yPos, pageWidth)
                                             yPos += 6

                                             ' 3. جدول الأصناف (هيدر)
                                             g.DrawString("الصنف / الخيارات", fontBold, Brushes.Black, New RectangleF(130, yPos, pageWidth - 130, 18), sfRight)
                                             g.DrawString("الكمية", fontBold, Brushes.Black, New RectangleF(75, yPos, 50, 18), sfCenter)
                                             g.DrawString("الإجمالي", fontBold, Brushes.Black, New RectangleF(0, yPos, 70, 18), sfLeft)
                                             yPos += 20
                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 5

                                             ' 4. تفاصيل الأصناف
                                             For Each det In inv.Details
                                                 Dim itemDisplay As String = det.ProductName
                                                 If Not String.IsNullOrWhiteSpace(det.SizeName) AndAlso det.SizeName <> "عادي" Then
                                                     itemDisplay &= " (" & det.SizeName & ")"
                                                 End If

                                                 g.DrawString(itemDisplay, fontBold, Brushes.Black, New RectangleF(125, yPos, pageWidth - 125, 18), sfRight)
                                                 g.DrawString(det.Quantity.ToString(), fontBold, Brushes.Black, New RectangleF(75, yPos, 50, 18), sfCenter)
                                                 g.DrawString(det.TotalPrice.ToString("N2"), fontBold, Brushes.Black, New RectangleF(0, yPos, 70, 18), sfLeft)
                                                 yPos += 18

                                                 ' سطر الإضافات إن وجدت
                                                 If Not String.IsNullOrWhiteSpace(det.AddonsText) AndAlso det.AddonsText <> "-" Then
                                                     g.DrawString(" + " & det.AddonsText, fontSub, Brushes.DimGray, New RectangleF(80, yPos, pageWidth - 80, 16), sfRight)
                                                     yPos += 16
                                                 End If

                                                 ' الملاحظات إن وجدت
                                                 If Not String.IsNullOrWhiteSpace(det.Notes) Then
                                                     g.DrawString(" * " & det.Notes, fontSub, Brushes.DarkRed, New RectangleF(80, yPos, pageWidth - 80, 16), sfRight)
                                                     yPos += 16
                                                 End If

                                                 yPos += 2
                                             Next

                                             DrawDashedLine(g, yPos, pageWidth)
                                             yPos += 6

                                             ' 5. قسم الإجماليات
                                             DrawAmountRow(g, "إجمالي الأصناف:", inv.TotalBeforeDiscount.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18

                                             If inv.DeliveryFee > 0 Then
                                                 DrawAmountRow(g, "خدمة التوصيل:", inv.DeliveryFee.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                                 yPos += 18
                                             End If

                                             If inv.DiscountAmount > 0 Then
                                                 DrawAmountRow(g, "الخصم:", "-" & inv.DiscountAmount.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                                 yPos += 18
                                             End If

                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 4

                                             ' الإجمالي الصافي بخط عريض
                                             Using fontGrand As New Font("Segoe UI", 12.0!, FontStyle.Bold)
                                                 g.DrawString("الصافي المطلوب:", fontGrand, Brushes.Black, New RectangleF(100, yPos, pageWidth - 100, 24), sfRight)
                                                 g.DrawString(inv.NetTotal.ToString("N2") & " ج", fontGrand, Brushes.Black, New RectangleF(0, yPos, 100, 24), sfLeft)
                                                 yPos += 26
                                             End Using

                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 4

                                             ' النقدية والمتبقي
                                             If inv.PaidAmount > 0 Then
                                                 DrawAmountRow(g, "المدفوع نقداً:", inv.PaidAmount.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                                 yPos += 18
                                             End If
                                             If inv.RemainingAmount > 0 Then
                                                 DrawAmountRow(g, If(inv.IsCredit, "المتبقي آجل:", "الباقي للعميل:"), inv.RemainingAmount.ToString("N2") & " ج", fontBold, sfRight, sfLeft, yPos, pageWidth)
                                                 yPos += 18
                                             End If

                                             ' 6. رمز الـ QR Code الضريبي
                                             Dim tlvData = QRCodeHelper.BuildZatcaTlvBase64(shopName, shopTax, inv.InvoiceDate, inv.NetTotal, 0)
                                             Using qrBmp = QRCodeHelper.GenerateQRCode(tlvData, 105, 105)
                                                 If qrBmp IsNot Nothing Then
                                                     yPos += 8
                                                     Dim qrX As Integer = (pageWidth - 105) \ 2
                                                     g.DrawImage(qrBmp, New Rectangle(qrX, yPos, 105, 105))
                                                     yPos += 110
                                                 End If
                                             End Using

                                             ' 7. تذييل الفاتورة
                                             If Not String.IsNullOrWhiteSpace(footerText) Then
                                                 g.DrawString(footerText, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 28), sfCenter)
                                                 yPos += 30
                                             End If

                                             g.DrawString("سستامك لإدارة المطاعم - Sestamk POS", fontSub, Brushes.Gray, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
                                             yPos += 20
                                         End Using

                                         e.HasMorePages = False
                                     End Sub

            pd.Print()

            ' فتح درج النقدية وقص الورق بعد الطباعة
            OpenCashDrawer(prn)

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء طباعة فاتورة العميل: " & ex.Message, "خطأ طباعة", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ═════════════════════════════════════════════════════════════════
    ' 2. طباعة إيصال المطبخ / البار (Kitchen Order Ticket - KOT)
    ' ═════════════════════════════════════════════════════════════════
    Public Shared Sub PrintKitchenTicket(orderNumber As String,
                                         orderTypeDesc As String,
                                         tableName As String,
                                         staffName As String,
                                         items As List(Of InvoiceDetailModel),
                                         Optional ticketTitle As String = "طلب تشغيل مطبخ",
                                         Optional customPrinterName As String = "")
        Try
            If items Is Nothing OrElse items.Count = 0 Then Return

            Dim prn = If(String.IsNullOrWhiteSpace(customPrinterName), GetDefaultThermalPrinter(), customPrinterName)
            If String.IsNullOrWhiteSpace(prn) Then Return

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = prn
            pd.DefaultPageSettings.Margins = New Margins(4, 4, 4, 4)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If pageWidth > 300 Then pageWidth = 290

                                         Dim yPos As Integer = 10

                                         Using fontHeader As New Font("Segoe UI", 14.0!, FontStyle.Bold),
                                               fontOrderType As New Font("Segoe UI", 13.0!, FontStyle.Bold),
                                               fontItemName As New Font("Segoe UI", 11.5!, FontStyle.Bold),
                                               fontQty As New Font("Segoe UI", 13.0!, FontStyle.Bold),
                                               fontSub As New Font("Segoe UI", 9.5!, FontStyle.Bold),
                                               fontMeta As New Font("Segoe UI", 9.0!, FontStyle.Regular),
                                               sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center},
                                               sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
                                               sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near}

                                             ' عنوان البون
                                             g.DrawString("══ " & ticketTitle & " ══", fontHeader, Brushes.Black, New RectangleF(0, yPos, pageWidth, 26), sfCenter)
                                             yPos += 28

                                             ' نوع الطلب والطاولة بشكل ضخم وواضح لطهاة المطبخ
                                             Dim tableOrType As String = orderTypeDesc
                                             If Not String.IsNullOrWhiteSpace(tableName) Then
                                                 tableOrType &= " [ " & tableName & " ]"
                                             End If
                                             g.DrawString(tableOrType, fontOrderType, Brushes.Black, New RectangleF(0, yPos, pageWidth, 26), sfCenter)
                                             yPos += 26

                                             DrawSolidLine(g, yPos, pageWidth, 2)
                                             yPos += 6

                                             ' الوقت ورقم الطلب والموظف
                                             g.DrawString("طلب رقم: " & orderNumber, fontMeta, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                                             yPos += 18
                                             g.DrawString("الوقت: " & DateTime.Now.ToString("yyyy/MM/dd - hh:mm tt"), fontMeta, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                                             yPos += 18
                                             If Not String.IsNullOrWhiteSpace(staffName) Then
                                                 g.DrawString("الكاشير/الويتر: " & staffName, fontMeta, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                                                 yPos += 18
                                             End If

                                             DrawDashedLine(g, yPos, pageWidth)
                                             yPos += 8

                                             ' الأصناف بدون أسعار
                                             For Each det In items
                                                 ' الصنف
                                                 Dim itemName As String = det.ProductName
                                                 If Not String.IsNullOrWhiteSpace(det.SizeName) AndAlso det.SizeName <> "عادي" Then
                                                     itemName &= " (" & det.SizeName & ")"
                                                 End If

                                                 ' الكمية في اليسار بحجم كبير
                                                 g.DrawString(det.Quantity.ToString() & "x", fontQty, Brushes.Black, New RectangleF(0, yPos, 45, 24), sfLeft)
                                                 ' اسم الصنف في اليمين
                                                 g.DrawString(itemName, fontItemName, Brushes.Black, New RectangleF(45, yPos, pageWidth - 45, 24), sfRight)
                                                 yPos += 24

                                                 ' الإضافات
                                                 If Not String.IsNullOrWhiteSpace(det.AddonsText) AndAlso det.AddonsText <> "-" Then
                                                     g.DrawString("  [+] " & det.AddonsText, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                                                     yPos += 18
                                                 End If

                                                 ' الملاحظات التجهيزية (مثل بدون شطة، تسوية زيادة)
                                                 If Not String.IsNullOrWhiteSpace(det.Notes) Then
                                                     g.DrawString("  [!] " & det.Notes, fontSub, Brushes.DarkRed, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                                                     yPos += 18
                                                 End If

                                                 yPos += 4
                                                 DrawDashedLine(g, yPos, pageWidth)
                                                 yPos += 6
                                             Next

                                             yPos += 10
                                             g.DrawString("══ نهاية طلب التشغيل ══", fontMeta, Brushes.Gray, New RectangleF(0, yPos, pageWidth, 20), sfCenter)
                                             yPos += 25
                                         End Using

                                         e.HasMorePages = False
                                     End Sub

            pd.Print()

        Catch ex As Exception
            Debug.WriteLine("PrintKitchenTicket error: " & ex.Message)
        End Try
    End Sub

    ' ═════════════════════════════════════════════════════════════════
    ' 3. طباعة تقرير تقفيل الوردية الحراري (Z-Report)
    ' ═════════════════════════════════════════════════════════════════
    Public Shared Sub PrintShiftZReport(shiftNumber As String,
                                        workShiftName As String,
                                        openDate As DateTime,
                                        closeDate As DateTime,
                                        cashierName As String,
                                        openingCash As Decimal,
                                        totalSales As Decimal,
                                        totalDineIn As Decimal,
                                        totalTakeaway As Decimal,
                                        totalDelivery As Decimal,
                                        deliveryFees As Decimal,
                                        totalExpenses As Decimal,
                                        totalRefunds As Decimal,
                                        expectedCash As Decimal,
                                        actualCash As Decimal,
                                        cashDiff As Decimal,
                                        notes As String,
                                        Optional customPrinterName As String = "")
        Try
            Dim prn = If(String.IsNullOrWhiteSpace(customPrinterName), GetDefaultThermalPrinter(), customPrinterName)
            If String.IsNullOrWhiteSpace(prn) Then Return

            Dim shopName = SettingsManager.GetSettingOrDefault("ShopName", "مطعم")

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = prn
            pd.DefaultPageSettings.Margins = New Margins(4, 4, 4, 4)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If pageWidth > 300 Then pageWidth = 290

                                         Dim yPos As Integer = 10

                                         Using fontTitle As New Font("Segoe UI", 12.5!, FontStyle.Bold),
                                               fontHeader As New Font("Segoe UI", 10.0!, FontStyle.Bold),
                                               fontBold As New Font("Segoe UI", 9.0!, FontStyle.Bold),
                                               fontRegular As New Font("Segoe UI", 8.5!, FontStyle.Regular),
                                               sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center},
                                               sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
                                               sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near}

                                             ' عنوان التقرير
                                             g.DrawString(shopName, fontTitle, Brushes.Black, New RectangleF(0, yPos, pageWidth, 24), sfCenter)
                                             yPos += 24
                                             g.DrawString("═══ تقرير إغلاق الوردية (Z-REPORT) ═══", fontHeader, Brushes.Black, New RectangleF(0, yPos, pageWidth, 20), sfCenter)
                                             yPos += 24

                                             DrawSolidLine(g, yPos, pageWidth, 2)
                                             yPos += 6

                                             ' معلومات الوردية
                                             DrawAmountRow(g, "رقم الوردية:", shiftNumber, fontBold, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "نوع الوردية:", workShiftName, fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "الموظف المسؤول:", cashierName, fontBold, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "تاريخ الفتح:", openDate.ToString("yyyy/MM/dd - hh:mm tt"), fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "تاريخ الإغلاق:", closeDate.ToString("yyyy/MM/dd - hh:mm tt"), fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 20

                                             DrawDashedLine(g, yPos, pageWidth)
                                             yPos += 6

                                             ' تفصيل المبيعات
                                             g.DrawString("── تفاصيل المبيعات ──", fontHeader, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
                                             yPos += 20

                                             DrawAmountRow(g, "مبيعات الصالة (Dine-In):", totalDineIn.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "مبيعات التيك أوي (Takeaway):", totalTakeaway.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "مبيعات الدليفري (Delivery):", totalDelivery.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             If deliveryFees > 0 Then
                                                 DrawAmountRow(g, "إجمالي رسوم التوصيل:", deliveryFees.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                                 yPos += 18
                                             End If

                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 4
                                             DrawAmountRow(g, "إجمالي المبيعات:", totalSales.ToString("N2") & " ج", fontBold, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 20

                                             DrawDashedLine(g, yPos, pageWidth)
                                             yPos += 6

                                             ' حركة النقدية بالدرج
                                             g.DrawString("── حركة النقدية بالدرج ──", fontHeader, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
                                             yPos += 20

                                             DrawAmountRow(g, "عهدة بداية الوردية:", openingCash.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "(+) إجمالي المبيعات النقدية:", totalSales.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             If totalExpenses > 0 Then
                                                 DrawAmountRow(g, "(-) إجمالي المصروفات:", "-" & totalExpenses.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                                 yPos += 18
                                             End If
                                             If totalRefunds > 0 Then
                                                 DrawAmountRow(g, "(-) إجمالي المرتجعات:", "-" & totalRefunds.ToString("N2") & " ج", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                                 yPos += 18
                                             End If

                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 4
                                             DrawAmountRow(g, "النقدية المتوقعة بالدرج:", expectedCash.ToString("N2") & " ج", fontBold, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "المبلغ المجرود فعلياً:", actualCash.ToString("N2") & " ج", fontBold, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 20

                                             ' فارق النقدية (عجز أو زيادة)
                                             Dim diffLabel As String = "الفارق:"
                                             Dim diffValue As String = cashDiff.ToString("N2") & " ج"
                                             If cashDiff = 0 Then
                                                 diffValue = "متطابق تماماً (0.00)"
                                             ElseIf cashDiff < 0 Then
                                                 diffLabel = "العجز في الدرج:"
                                             Else
                                                 diffLabel = "الزيادة في الدرج:"
                                             End If

                                             DrawAmountRow(g, diffLabel, diffValue, fontTitle, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 26

                                             If Not String.IsNullOrWhiteSpace(notes) Then
                                                 g.DrawString("ملاحظات: " & notes, fontRegular, Brushes.Black, New RectangleF(0, yPos, pageWidth, 28), sfRight)
                                                 yPos += 30
                                             End If

                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 15

                                             ' توقيعات
                                             g.DrawString("توقيع الكاشير: ____________", fontRegular, Brushes.Black, New RectangleF(130, yPos, pageWidth - 130, 20), sfRight)
                                             g.DrawString("توقيع المدير: ____________", fontRegular, Brushes.Black, New RectangleF(0, yPos, 120, 20), sfLeft)
                                             yPos += 35
                                         End Using

                                         e.HasMorePages = False
                                     End Sub

            pd.Print()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء طباعة تقرير الوردية Z-Report: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ═════════════════════════════════════════════════════════════════
    ' دوال مساعدة في الرسم والتنسيق
    ' ═════════════════════════════════════════════════════════════════
    Private Shared Sub DrawAmountRow(g As Graphics, label As String, val As String, fnt As Font, sfRight As StringFormat, sfLeft As StringFormat, y As Integer, w As Integer)
        g.DrawString(label, fnt, Brushes.Black, New RectangleF(90, y, w - 90, 18), sfRight)
        g.DrawString(val, fnt, Brushes.Black, New RectangleF(0, y, 90, 18), sfLeft)
    End Sub

    Private Shared Sub DrawDashedLine(g As Graphics, y As Integer, w As Integer)
        Using pen As New Pen(Color.Black, 1) With {.DashStyle = Drawing2D.DashStyle.Dash}
            g.DrawLine(pen, 2, y, w - 4, y)
        End Using
    End Sub

    Private Shared Sub DrawSolidLine(g As Graphics, y As Integer, w As Integer, Optional thickness As Single = 1)
        Using pen As New Pen(Color.Black, thickness)
            g.DrawLine(pen, 2, y, w - 4, y)
        End Using
    End Sub

    ' ═════════════════════════════════════════════════════════════════
    ' 4. طباعة إيصال سداد حصة فردية (Split Bill Sub-Receipt)
    ' ═════════════════════════════════════════════════════════════════
    Public Shared Sub PrintSplitReceipt(invoiceNumber As String,
                                        guestNumber As Integer,
                                        totalGuests As Integer,
                                        guestName As String,
                                        shareAmount As Decimal,
                                        paidAmount As Decimal,
                                        paymentMethod As String,
                                        tableName As String,
                                        totalInvoiceAmount As Decimal,
                                        Optional customPrinterName As String = "")
        Try
            Dim prn = If(String.IsNullOrWhiteSpace(customPrinterName), GetDefaultThermalPrinter(), customPrinterName)
            If String.IsNullOrWhiteSpace(prn) Then
                MessageBox.Show("لم يتم تحديد طابعة فواتير في الإعدادات!", "تنبيه الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim shopName = SettingsManager.GetSettingOrDefault("ShopName", "مطعم")
            Dim shopPhone = SettingsManager.GetSettingOrDefault("ShopPhone", "")
            Dim footerText = SettingsManager.GetSettingOrDefault("FooterText", "شكراً لزيارتكم ونتشرف بخدمتكم دائماً")

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = prn
            pd.DefaultPageSettings.Margins = New Margins(4, 4, 4, 4)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If pageWidth > 300 Then pageWidth = 290

                                         Dim yPos As Integer = 10

                                         Using fontTitle As New Font("Segoe UI", 12.0!, FontStyle.Bold),
                                               fontSub As New Font("Segoe UI", 8.5!, FontStyle.Regular),
                                               fontBold As New Font("Segoe UI", 9.5!, FontStyle.Bold),
                                               fontRegular As New Font("Segoe UI", 8.5!, FontStyle.Regular),
                                               sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center},
                                               sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
                                               sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near}

                                             ' هيدر المحل
                                             g.DrawString(shopName, fontTitle, Brushes.Black, New RectangleF(0, yPos, pageWidth, 24), sfCenter)
                                             yPos += 24
                                             If Not String.IsNullOrEmpty(shopPhone) Then
                                                 g.DrawString("هاتف: " & shopPhone, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
                                                 yPos += 18
                                             End If

                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 8

                                             ' عنوان الإيصال
                                             g.DrawString("إيصال سداد حصة فردية (تقسيم فاتورة)", fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 20), sfCenter)
                                             yPos += 22

                                             ' بيانات الفاتورة والطاولة
                                             DrawAmountRow(g, "رقم الفاتورة:", If(String.IsNullOrEmpty(invoiceNumber), "-", invoiceNumber), fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "الطاولة:", If(String.IsNullOrEmpty(tableName), "-", tableName), fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "التاريخ والوقت:", DateTime.Now.ToString("yyyy/MM/dd HH:mm"), fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 20

                                             DrawDashedLine(g, yPos, pageWidth)
                                             yPos += 10

                                             ' بيانات الحصة والعميل
                                             DrawAmountRow(g, "اسم الضيف / الحصة:", guestName, fontBold, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "ترتيب الحصة:", $"فرد {guestNumber} من إجمالي {totalGuests}", fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 18
                                             DrawAmountRow(g, "طريقة الدفع:", paymentMethod, fontRegular, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 22

                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 8

                                             ' المبالغ
                                             DrawAmountRow(g, "المبلغ المستحق للحصة:", shareAmount.ToString("N2") & " ج", fontBold, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 20
                                             DrawAmountRow(g, "المبلغ المدفوع الفعلي:", paidAmount.ToString("N2") & " ج", fontBold, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 22

                                             DrawDashedLine(g, yPos, pageWidth)
                                             yPos += 8
                                             DrawAmountRow(g, "إجمالي الفاتورة الأصلية:", totalInvoiceAmount.ToString("N2") & " ج", fontSub, sfRight, sfLeft, yPos, pageWidth)
                                             yPos += 20

                                             DrawSolidLine(g, yPos, pageWidth)
                                             yPos += 10

                                             ' الفوتر
                                             g.DrawString(footerText, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 30), sfCenter)
                                             yPos += 30
                                         End Using

                                         e.HasMorePages = False
                                     End Sub

            pd.Print()
            OpenCashDrawer(prn)
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء طباعة إيصال الحصة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
