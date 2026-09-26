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
    ''' جلب اسم طابعة المطبخ المحفوظة في الإعدادات أو طابعة الفواتير الحرارية كبديل
    ''' </summary>
    Public Shared Function GetKitchenPrinter() As String
        Dim printerName As String = SettingsManager.GetSetting(SettingsKeys.KitchenPrinterName)
        If String.IsNullOrWhiteSpace(printerName) Then
            Return GetDefaultThermalPrinter()
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
                                           Optional customPrinterName As String = "",
                                           Optional forcePreview As Boolean = False)
        Try
            Dim prn = If(String.IsNullOrWhiteSpace(customPrinterName), GetDefaultThermalPrinter(), customPrinterName)
            If String.IsNullOrWhiteSpace(prn) Then
                If forcePreview Then
                    Try
                        Dim ps As New PrinterSettings()
                        prn = ps.PrinterName
                    Catch
                    End Try
                End If
                If String.IsNullOrWhiteSpace(prn) Then
                    MessageBox.Show("لم يتم تحديد طابعة فواتير في الإعدادات!", "تنبيه الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            ' معلومات المحل
            Dim shopName = SettingsManager.GetSettingDual(SettingsKeys.ShopName, SettingsKeys.StoreName, "مطعم")
            Dim shopPhone = SettingsManager.GetSettingDual(SettingsKeys.ShopPhone, SettingsKeys.StorePhone, "لا يوجد رقم هاتف")
            Dim shopPhone2 = SettingsManager.GetSettingDual(SettingsKeys.ShopPhone2, SettingsKeys.StorePhone2, "لا يوجد رقم هاتف")
            Dim shopAddress = SettingsManager.GetSettingDual(SettingsKeys.ShopAddress, SettingsKeys.StoreAddress, "لا يوجد عنوان")
            Dim shopTax = SettingsManager.GetSettingOrDefault(SettingsKeys.TaxNumber, "")
            Dim footerText = SettingsManager.GetSettingDual(SettingsKeys.FooterText, SettingsKeys.ReceiptFooter, "شكراً لزيارتكم ونتشرف بخدمتكم دائماً")
            Dim logoPath = SettingsManager.GetSettingDual(SettingsKeys.LogoPath, SettingsKeys.ReceiptLogoPath, "")
            Dim printLogo = SettingsManager.GetBoolSettingDual(SettingsKeys.ShowLogo, SettingsKeys.PrintLogo, True)
            Dim printBarcode = SettingsManager.GetBoolSetting(SettingsKeys.PrintBarcode, True)
            Dim barcodeType = SettingsManager.GetSettingOrDefault(SettingsKeys.InvoiceBarcodeType, "2D")

            ' إعدادات التخطيط والخيارات
            Dim receiptStyle = SettingsManager.GetSettingOrDefault(SettingsKeys.ReceiptStyle, "Classic")
            Dim showTax = SettingsManager.GetBoolSetting(SettingsKeys.ShowTax, True)
            Dim showDiscount = SettingsManager.GetBoolSetting(SettingsKeys.ShowDiscount, True)
            Dim showCashier = SettingsManager.GetBoolSetting(SettingsKeys.ShowCashier, True)
            Dim usePreview = SettingsManager.GetBoolSetting(SettingsKeys.PrintPreview, False)
            Dim autoPrint = SettingsManager.GetBoolSettingDual(SettingsKeys.PrinterAutoPrint, SettingsKeys.PrintReceiptOnPayment, True)
            Dim openDrawerSetting = SettingsManager.GetBoolSettingDual(SettingsKeys.PrinterOpenCashDrawer, SettingsKeys.OpenDrawerOnPayment, True)

            ' فحص الطباعة التلقائية (إذا كانت معطلة والطباعة غير يدوية أو غير تجريبية نتخطى)
            If Not isReprint AndAlso Not forcePreview AndAlso Not autoPrint Then
                Return
            End If

            Dim paperSizeVal = SettingsManager.GetSettingOrDefault(SettingsKeys.PrinterPaperSize, "80mm")
            Dim is58mm = paperSizeVal.Equals("58mm", StringComparison.OrdinalIgnoreCase)

            Dim fontSizeVal = SettingsManager.GetSettingOrDefault(SettingsKeys.ReceiptFontSize, "8.5")
            Dim baseFontSize As Single = 8.5!
            Single.TryParse(fontSizeVal, baseFontSize)
            If baseFontSize < 6.5! OrElse baseFontSize > 13.0! Then baseFontSize = 8.5!

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = prn
            pd.DefaultPageSettings.Margins = New Margins(2, 2, 2, 2)

            ' عدد النسخ
            Dim copiesVal As Integer = SettingsManager.GetIntSetting(SettingsKeys.PrinterCopiesCount, 1)
            If copiesVal < 1 Then copiesVal = 1
            Try
                pd.PrinterSettings.Copies = CShort(copiesVal)
            Catch
            End Try

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If is58mm Then
                                             If pageWidth > 205 Then pageWidth = 195
                                         Else
                                             If pageWidth > 300 Then pageWidth = 285
                                         End If

                                         If receiptStyle.Equals("Grid", StringComparison.OrdinalIgnoreCase) Then
                                             RenderCustomerReceiptGrid(g, pageWidth, inv, customerName, tableName, driverName, isReprint, shopName, shopPhone, shopPhone2, shopAddress, shopTax, footerText, logoPath, printLogo, showTax, showDiscount, showCashier, baseFontSize, printBarcode, barcodeType)
                                         Else
                                             RenderCustomerReceiptClassic(g, pageWidth, inv, customerName, tableName, driverName, isReprint, shopName, shopPhone, shopPhone2, shopAddress, shopTax, footerText, logoPath, printLogo, showTax, showDiscount, showCashier, baseFontSize, printBarcode, barcodeType)
                                         End If

                                         e.HasMorePages = False
                                     End Sub

            If usePreview OrElse forcePreview Then
                Using dlg As New PrintPreviewDialog()
                    dlg.Document = pd
                    dlg.Text = "معاينة فاتورة المبيعات"
                    dlg.WindowState = FormWindowState.Normal
                    dlg.Width = 480
                    dlg.Height = 750
                    dlg.StartPosition = FormStartPosition.CenterScreen
                    dlg.UseAntiAlias = True
                    dlg.PrintPreviewControl.Zoom = 1.0
                    dlg.ShowDialog()
                End Using
            Else
                pd.Print()
                If openDrawerSetting Then
                    OpenCashDrawer(prn)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء طباعة فاتورة العميل: " & ex.Message, "خطأ طباعة", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' رسم فاتورة العميل بالنمط الجدولي المنظم (Excel Grid Table) بتصميم احترافي وتوزيع دقيق للأعمدة
    ''' </summary>
    Private Shared Sub RenderCustomerReceiptGrid(g As Graphics,
                                                pageWidth As Integer,
                                                inv As InvoiceModel,
                                                customerName As String,
                                                tableName As String,
                                                driverName As String,
                                                isReprint As Boolean,
                                                shopName As String,
                                                shopPhone As String,
                                                shopPhone2 As String,
                                                shopAddress As String,
                                                shopTax As String,
                                                footerText As String,
                                                logoPath As String,
                                                printLogo As Boolean,
                                                showTax As Boolean,
                                                showDiscount As Boolean,
                                                showCashier As Boolean,
                                                baseFontSize As Single,
                                                Optional printBarcode As Boolean = True,
                                                Optional barcodeType As String = "2D")

        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim isSmallPaper As Boolean = (pageWidth < 230)
        Dim yPos As Integer = 5

        ' 1. اللوجو إن وجد
        If printLogo AndAlso Not String.IsNullOrEmpty(logoPath) AndAlso File.Exists(logoPath) Then
            Try
                Using logoImg = Image.FromFile(logoPath)
                    Dim maxW As Integer = If(isSmallPaper, 120, 150)
                    Dim logoW As Integer = Math.Min(maxW, pageWidth - 40)
                    Dim logoH As Integer = CInt(logoImg.Height * (CDbl(logoW) / logoImg.Width))
                    If logoH > 65 Then logoH = 65
                    Dim logoX As Integer = (pageWidth - logoW) \ 2
                    g.DrawImage(logoImg, New Rectangle(logoX, yPos, logoW, logoH))
                    yPos += logoH + 6
                End Using
            Catch
            End Try
        End If

        Using fontTitle As New Font("Segoe UI", If(isSmallPaper, 11.5!, 13.0!), FontStyle.Bold),
              fontSub As New Font("Segoe UI", If(isSmallPaper, 7.5!, 8.0!), FontStyle.Regular),
              fontBold As New Font("Segoe UI", baseFontSize + 0.5!, FontStyle.Bold),
              fontRegular As New Font("Segoe UI", baseFontSize, FontStyle.Regular),
              fontHeader As New Font("Segoe UI", If(isSmallPaper, 8.0!, 9.0!), FontStyle.Bold),
              fontRow As New Font("Segoe UI", baseFontSize, FontStyle.Regular),
              fontRowBold As New Font("Segoe UI", baseFontSize, FontStyle.Bold),
              fontGrand As New Font("Segoe UI", If(isSmallPaper, 10.5!, 11.5!), FontStyle.Bold),
              fontAddon As New Font("Segoe UI", 7.5!, FontStyle.Regular),
              fontNote As New Font("Segoe UI", 7.5!, FontStyle.Bold),
              sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap},
              sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center},
              sfItemWrap As New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Near, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              borderPen As New Pen(Color.Black, 2.0!),
              gridPen As New Pen(Color.Black, 1.8!),
              boldPen As New Pen(Color.Black, 2.2!),
              headerBrush As New SolidBrush(Color.FromArgb(236, 239, 244)),
              highlightBrush As New SolidBrush(Color.FromArgb(230, 235, 244)),
              metaBgBrush As New SolidBrush(Color.FromArgb(248, 249, 251))

            ' 2. اسم المطعم وبيانات الاتصال
            g.DrawString(shopName, fontTitle, Brushes.Black, New RectangleF(0, yPos, pageWidth, 24), sfCenter)
            yPos += 24

            If Not String.IsNullOrWhiteSpace(shopAddress) Then
                g.DrawString(shopAddress, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
                yPos += 16
            End If

            Dim phones = shopPhone & If(Not String.IsNullOrWhiteSpace(shopPhone2), " - " & shopPhone2, "")
            If Not String.IsNullOrWhiteSpace(phones) Then
                g.DrawString("هاتف: " & phones, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
                yPos += 16
            End If

            If showTax AndAlso Not String.IsNullOrWhiteSpace(shopTax) Then
                g.DrawString("الرقم الضريبي: " & shopTax, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
                yPos += 16
            End If

            yPos += 4

            ' شريط عنوان الفاتورة داخل إطار مظلل أنيق
            Dim badgeText As String = If(isReprint, "فاتورة مبيعات (نسخة معاد طباعتها)", "فاتورة مبيعات")
            Dim badgeRect As New Rectangle(6, yPos, pageWidth - 12, 24)
            g.FillRectangle(headerBrush, badgeRect)
            g.DrawRectangle(borderPen, badgeRect)
            g.DrawString(badgeText, fontBold, Brushes.Black, badgeRect, sfCenter)
            yPos += 28

            ' 3. صندوق بيانات الفاتورة الشبكي (Meta Box)
            Dim metaX As Integer = 4
            Dim metaW As Integer = pageWidth - 8
            Dim colW1 As Integer = CInt(metaW * 0.58) ' عمود نوع الطلب / رقم الفاتورة (58% لمنع قص النصوص)
            Dim colW2 As Integer = metaW - colW1     ' عمود التاريخ / العميل (42%)
            Dim metaRowH As Integer = 22

            ' الصف الأول: رقم الفاتورة + التاريخ
            Dim metaY1 As Integer = yPos
            g.FillRectangle(metaBgBrush, metaX, metaY1, metaW, metaRowH)
            g.DrawRectangle(gridPen, metaX, metaY1, metaW, metaRowH)
            g.DrawLine(gridPen, metaX + colW2, metaY1, metaX + colW2, metaY1 + metaRowH)
            g.DrawString("رقم الفاتورة: " & inv.InvoiceNumber, fontBold, Brushes.Black, New RectangleF(metaX + colW2 + 4, metaY1, colW1 - 8, metaRowH), sfRight)
            g.DrawString(inv.InvoiceDate.ToString("yyyy/MM/dd hh:mm tt"), fontSub, Brushes.Black, New RectangleF(metaX + 2, metaY1, colW2 - 4, metaRowH), sfCenter)
            yPos += metaRowH

            ' بيان نوع الطلب بدون عبارات زائدة تسبب القص
            Dim orderTypeDesc As String = ""
            Select Case inv.OrderType
                Case 1 : orderTypeDesc = "طلب خارجي (تيك أوي)"
                Case 2 : orderTypeDesc = "صالة - " & If(Not String.IsNullOrWhiteSpace(tableName), tableName, "طاولة " & inv.TableID.ToString())
                Case 3 : orderTypeDesc = "توصيل (دليفري)" & If(Not String.IsNullOrWhiteSpace(driverName), " - " & driverName, "")
                Case Else : orderTypeDesc = "طلب مطعم"
            End Select

            ' الصف الثاني: نوع الطلب + العميل / الكاشير
            Dim metaY2 As Integer = yPos
            g.FillRectangle(metaBgBrush, metaX, metaY2, metaW, metaRowH)
            g.DrawRectangle(gridPen, metaX, metaY2, metaW, metaRowH)
            g.DrawLine(gridPen, metaX + colW2, metaY2, metaX + colW2, metaY2 + metaRowH)
            g.DrawString(orderTypeDesc, fontBold, Brushes.Black, New RectangleF(metaX + colW2 + 4, metaY2, colW1 - 8, metaRowH), sfRight)

            Dim clientOrUser As String = ""
            If Not String.IsNullOrWhiteSpace(customerName) Then
                clientOrUser = "العميل: " & customerName
            ElseIf showCashier Then
                clientOrUser = "كاشير: " & Environment.UserName
            Else
                clientOrUser = "عميل نقدي"
            End If
            g.DrawString(clientOrUser, fontRegular, Brushes.Black, New RectangleF(metaX + 2, metaY2, colW2 - 4, metaRowH), sfRight)
            yPos += metaRowH + 6

            ' 4. جدول المنتجات الشبكي (Excel Grid Table)
            Dim tableX As Integer = 4
            Dim tableW As Integer = pageWidth - 8

            ' توزيع دقيق لعرض الأعمدة يمنع التفاف "الكمية" نهائياً
            Dim colTotalW As Integer = If(isSmallPaper, 44, 62)
            Dim colPriceW As Integer = If(isSmallPaper, 38, 48)
            Dim colQtyW As Integer = If(isSmallPaper, 32, 46) ' 46px في 80 مم كافية تماماً لكلمة "الكمية"
            Dim colNameW As Integer = tableW - (colTotalW + colPriceW + colQtyW)

            Dim xTotal As Integer = tableX
            Dim xPrice As Integer = xTotal + colTotalW
            Dim xQty As Integer = xPrice + colPriceW
            Dim xName As Integer = xQty + colQtyW

            Dim tableStartY As Integer = yPos
            Dim headerH As Integer = 24

            ' رأس الجدول المظلل
            g.FillRectangle(headerBrush, tableX, yPos, tableW, headerH)
            g.DrawRectangle(borderPen, tableX, yPos, tableW, headerH)

            g.DrawString("الإجمالي", fontHeader, Brushes.Black, New RectangleF(xTotal, yPos, colTotalW, headerH), sfCenter)
            g.DrawString("السعر", fontHeader, Brushes.Black, New RectangleF(xPrice, yPos, colPriceW, headerH), sfCenter)
            g.DrawString("الكمية", fontHeader, Brushes.Black, New RectangleF(xQty, yPos, colQtyW, headerH), sfCenter)
            g.DrawString("الصنف", fontHeader, Brushes.Black, New RectangleF(xName, yPos, colNameW - 6, headerH), sfRight)

            yPos += headerH

            ' صفوف الأصناف
            For Each det In inv.Details
                Dim itemName As String = det.ProductName
                If Not String.IsNullOrWhiteSpace(det.SizeName) AndAlso det.SizeName <> "عادي" Then
                    itemName &= " (" & det.SizeName & ")"
                End If

                Dim hasAddons As Boolean = Not String.IsNullOrWhiteSpace(det.AddonsText) AndAlso det.AddonsText <> "-"
                Dim hasNotes As Boolean = Not String.IsNullOrWhiteSpace(det.Notes)

                ' قياس ارتفاع النص المطلوب لاسم الصنف
                Dim measuredSize = g.MeasureString(itemName, fontRowBold, colNameW - 8)
                Dim baseTextH As Integer = Math.Max(20, CInt(measuredSize.Height) + 2)
                Dim rowH As Integer = baseTextH
                If hasAddons Then rowH += 15
                If hasNotes Then rowH += 15
                rowH += 4 ' هوامش علوية وسفلية مريحة

                ' رسم تفاصيل الصنف
                Dim textY As Integer = yPos + 2
                g.DrawString(itemName, fontRowBold, Brushes.Black, New RectangleF(xName + 2, textY, colNameW - 6, baseTextH), sfItemWrap)
                textY += baseTextH

                If hasAddons Then
                    g.DrawString("+" & det.AddonsText, fontAddon, Brushes.DarkSlateGray, New RectangleF(xName + 2, textY, colNameW - 6, 14), sfItemWrap)
                    textY += 14
                End If

                If hasNotes Then
                    g.DrawString("*" & det.Notes, fontNote, Brushes.DarkRed, New RectangleF(xName + 2, textY, colNameW - 6, 14), sfItemWrap)
                    textY += 14
                End If

                ' رسم الكمية والسعر والإجمالي
                g.DrawString(det.Quantity.ToString(), fontRowBold, Brushes.Black, New RectangleF(xQty, yPos, colQtyW, rowH), sfCenter)
                g.DrawString(det.UnitPrice.ToString("0.00"), fontRow, Brushes.Black, New RectangleF(xPrice, yPos, colPriceW, rowH), sfCenter)
                g.DrawString(det.TotalPrice.ToString("0.00"), fontRowBold, Brushes.Black, New RectangleF(xTotal + 2, yPos, colTotalW - 4, rowH), sfCenter)

                yPos += rowH
                g.DrawLine(gridPen, tableX, yPos, tableX + tableW, yPos)
            Next

            Dim tableEndY As Integer = yPos

            ' رسم الخطوط الرأسية المستمرة والإطار الخارجي لكامل الجدول
            g.DrawRectangle(borderPen, tableX, tableStartY, tableW, tableEndY - tableStartY)
            g.DrawLine(gridPen, xPrice, tableStartY, xPrice, tableEndY)
            g.DrawLine(gridPen, xQty, tableStartY, xQty, tableEndY)
            g.DrawLine(gridPen, xName, tableStartY, xName, tableEndY)

            yPos += 6

            ' 5. جدول ملخص الإجماليات الشبكي (Excel Totals Box)
            Dim totalRowH As Integer = 22
            Dim totalValW As Integer = If(isSmallPaper, 68, 88)
            Dim totalLabelW As Integer = tableW - totalValW

            Dim drawGridSummaryRow = Sub(label As String, val As String, isHighlight As Boolean)
                                         Dim rH As Integer = If(isHighlight, 26, totalRowH)
                                         Dim rRect As New Rectangle(tableX, yPos, tableW, rH)
                                         If isHighlight Then
                                             g.FillRectangle(highlightBrush, rRect)
                                             g.DrawRectangle(boldPen, rRect)
                                             g.DrawLine(boldPen, tableX + totalValW, yPos, tableX + totalValW, yPos + rH)
                                             g.DrawString(label, fontGrand, Brushes.Black, New RectangleF(tableX + totalValW + 4, yPos, totalLabelW - 8, rH), sfRight)
                                             g.DrawString(val, fontGrand, Brushes.Black, New RectangleF(tableX + 4, yPos, totalValW - 8, rH), sfLeft)
                                         Else
                                             g.DrawRectangle(gridPen, rRect)
                                             g.DrawLine(gridPen, tableX + totalValW, yPos, tableX + totalValW, yPos + rH)
                                             g.DrawString(label, fontBold, Brushes.Black, New RectangleF(tableX + totalValW + 4, yPos, totalLabelW - 8, rH), sfRight)
                                             g.DrawString(val, fontRowBold, Brushes.Black, New RectangleF(tableX + 4, yPos, totalValW - 8, rH), sfLeft)
                                         End If
                                         yPos += rH
                                     End Sub

            drawGridSummaryRow("إجمالي الأصناف:", inv.TotalBeforeDiscount.ToString("N2") & " ج", False)

            If inv.DeliveryFee > 0 Then
                drawGridSummaryRow("خدمة التوصيل:", inv.DeliveryFee.ToString("N2") & " ج", False)
            End If

            If showDiscount AndAlso inv.DiscountAmount > 0 Then
                drawGridSummaryRow("الخصم:", "-" & inv.DiscountAmount.ToString("N2") & " ج", False)
            End If

            ' صف الصافي المطلوب (مميز بتظليل وإطار أغمق وخط عريض)
            drawGridSummaryRow("الصافي المطلوب:", inv.NetTotal.ToString("N2") & " ج", True)

            If inv.PaidAmount > 0 Then
                drawGridSummaryRow("المدفوع نقداً:", inv.PaidAmount.ToString("N2") & " ج", False)
            End If

            If inv.RemainingAmount > 0 Then
                Dim remLabel = If(inv.IsCredit, "المتبقي آجل:", "الباقي للعميل:")
                drawGridSummaryRow(remLabel, inv.RemainingAmount.ToString("N2") & " ج", False)
            End If

            yPos += 8

            ' 6. رمز الباركود (1D خطي أو 2D QR Code حسب الإعدادات)
            If printBarcode Then
                If barcodeType.Equals("1D", StringComparison.OrdinalIgnoreCase) Then
                    Dim barW As Integer = Math.Min(If(isSmallPaper, 180, 220), pageWidth - 20)
                    Dim barH As Integer = If(isSmallPaper, 40, 48)
                    Dim barContent As String = If(Not String.IsNullOrWhiteSpace(inv.InvoiceNumber), inv.InvoiceNumber, inv.InvoiceID.ToString())
                    Using barBmp = QRCodeHelper.GenerateBarcode1D(barContent, barW, barH)
                        If barBmp IsNot Nothing Then
                            Dim barX As Integer = (pageWidth - barW) \ 2
                            g.DrawImage(barBmp, New Rectangle(barX, yPos, barW, barH))
                            yPos += barH + 6
                        End If
                    End Using
                Else
                    Dim qrSize As Integer = If(isSmallPaper, 85, 105)
                    Dim tlvData = QRCodeHelper.BuildZatcaTlvBase64(shopName, shopTax, inv.InvoiceDate, inv.NetTotal, 0)
                    Using qrBmp = QRCodeHelper.GenerateQRCode(tlvData, qrSize, qrSize)
                        If qrBmp IsNot Nothing Then
                            Dim qrX As Integer = (pageWidth - qrSize) \ 2
                            g.DrawImage(qrBmp, New Rectangle(qrX, yPos, qrSize, qrSize))
                            yPos += qrSize + 6
                        End If
                    End Using
                End If
            End If

            ' 7. تذييل الفاتورة ونصوص التوصيل
            Dim deliveryNotice = SettingsManager.GetSettingOrDefault(SettingsKeys.DeliveryText, "")
            If inv.OrderType = 3 AndAlso Not String.IsNullOrWhiteSpace(deliveryNotice) Then
                g.DrawString("🛵 " & deliveryNotice, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
                yPos += 18
            End If

            If Not String.IsNullOrWhiteSpace(footerText) Then
                g.DrawString(footerText, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 24), sfCenter)
                yPos += 26
            End If

            g.DrawString("سستمك لإدارة المطاعم - Sestamk POS", fontSub, Brushes.Gray, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
            yPos += 20
        End Using
    End Sub

    ''' <summary>
    ''' رسم فاتورة العميل بالنمط الكلاسيكي البسيط (خطوط منقطة وأعمدة متباعدة)
    ''' </summary>
    Private Shared Sub RenderCustomerReceiptClassic(g As Graphics,
                                                   pageWidth As Integer,
                                                   inv As InvoiceModel,
                                                   customerName As String,
                                                   tableName As String,
                                                   driverName As String,
                                                   isReprint As Boolean,
                                                   shopName As String,
                                                   shopPhone As String,
                                                   shopPhone2 As String,
                                                   shopAddress As String,
                                                   shopTax As String,
                                                   footerText As String,
                                                   logoPath As String,
                                                   printLogo As Boolean,
                                                   showTax As Boolean,
                                                   showDiscount As Boolean,
                                                   showCashier As Boolean,
                                                   baseFontSize As Single,
                                                   Optional printBarcode As Boolean = True,
                                                   Optional barcodeType As String = "2D")

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

        Using fontTitle As New Font("Segoe UI", 13.0!, FontStyle.Bold),
              fontSub As New Font("Segoe UI", 8.5!, FontStyle.Regular),
              fontBold As New Font("Segoe UI", baseFontSize + 0.5!, FontStyle.Bold),
              fontRegular As New Font("Segoe UI", baseFontSize, FontStyle.Regular),
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
            If showTax AndAlso Not String.IsNullOrWhiteSpace(shopTax) Then
                g.DrawString("الرقم الضريبي: " & shopTax, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
                yPos += 18
            End If

            ' شريط نوع الفاتورة
            yPos += 4
            Dim badgeText As String = If(isReprint, "فاتورة مبيعات (نسخة معاد طباعتها)", "فاتورة مبيعات")
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

            ' بيانات العميل والكاشير
            If Not String.IsNullOrWhiteSpace(customerName) Then
                g.DrawString("العميل: " & customerName, fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                yPos += 18
            End If
            If showCashier Then
                g.DrawString("الكاشير: " & Environment.UserName, fontRegular, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfRight)
                yPos += 18
            End If

            DrawDashedLine(g, yPos, pageWidth)
            yPos += 6

            ' 3. جدول الأصناف (هيدر)
            g.DrawString("الصنف", fontBold, Brushes.Black, New RectangleF(130, yPos, pageWidth - 130, 18), sfRight)
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

            If showDiscount AndAlso inv.DiscountAmount > 0 Then
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

            ' 6. رمز الباركود (1D خطي أو 2D QR Code حسب الإعدادات)
            If printBarcode Then
                If barcodeType.Equals("1D", StringComparison.OrdinalIgnoreCase) Then
                    Dim barW As Integer = Math.Min(220, pageWidth - 20)
                    Dim barH As Integer = 45
                    Dim barContent As String = If(Not String.IsNullOrWhiteSpace(inv.InvoiceNumber), inv.InvoiceNumber, inv.InvoiceID.ToString())
                    Using barBmp = QRCodeHelper.GenerateBarcode1D(barContent, barW, barH)
                        If barBmp IsNot Nothing Then
                            yPos += 8
                            Dim barX As Integer = (pageWidth - barW) \ 2
                            g.DrawImage(barBmp, New Rectangle(barX, yPos, barW, barH))
                            yPos += barH + 6
                        End If
                    End Using
                Else
                    Dim tlvData = QRCodeHelper.BuildZatcaTlvBase64(shopName, shopTax, inv.InvoiceDate, inv.NetTotal, 0)
                    Using qrBmp = QRCodeHelper.GenerateQRCode(tlvData, 105, 105)
                        If qrBmp IsNot Nothing Then
                            yPos += 8
                            Dim qrX As Integer = (pageWidth - 105) \ 2
                            g.DrawImage(qrBmp, New Rectangle(qrX, yPos, 105, 105))
                            yPos += 110
                        End If
                    End Using
                End If
            End If

            ' 7. تذييل الفاتورة
            If Not String.IsNullOrWhiteSpace(footerText) Then
                g.DrawString(footerText, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 28), sfCenter)
                yPos += 30
            End If

            g.DrawString("سستمك لإدارة المطاعم - Sestamk POS", fontSub, Brushes.Gray, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
            yPos += 20
        End Using
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
                                         Optional customPrinterName As String = "",
                                         Optional forcePreview As Boolean = False)
        Try
            If items Is Nothing OrElse items.Count = 0 Then Return

            Dim prn = If(String.IsNullOrWhiteSpace(customPrinterName), GetKitchenPrinter(), customPrinterName)
            If String.IsNullOrWhiteSpace(prn) Then
                If forcePreview Then
                    Try
                        Dim ps As New PrinterSettings()
                        prn = ps.PrinterName
                    Catch
                    End Try
                End If
                If String.IsNullOrWhiteSpace(prn) Then Return
            End If

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
                                             If Not String.IsNullOrWhiteSpace(tableName) AndAlso Not orderTypeDesc.Contains(tableName) Then
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

            Dim usePreview = SettingsManager.GetBoolSetting(SettingsKeys.PrintPreview, False)
            If usePreview OrElse forcePreview Then
                Using dlg As New PrintPreviewDialog()
                    dlg.Document = pd
                    dlg.Text = "معاينة بون المطبخ (KOT)"
                    dlg.WindowState = FormWindowState.Normal
                    dlg.Width = 460
                    dlg.Height = 700
                    dlg.StartPosition = FormStartPosition.CenterScreen
                    dlg.UseAntiAlias = True
                    dlg.PrintPreviewControl.Zoom = 1.0
                    dlg.ShowDialog()
                End Using
            Else
                pd.Print()
            End If

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

            Dim usePreview = SettingsManager.GetBoolSetting(SettingsKeys.PrintPreview, False)
            If usePreview Then
                Using dlg As New PrintPreviewDialog()
                    dlg.Document = pd
                    dlg.Text = "معاينة إيصال تقسيم الفاتورة"
                    dlg.WindowState = FormWindowState.Normal
                    dlg.Width = 480
                    dlg.Height = 700
                    dlg.StartPosition = FormStartPosition.CenterScreen
                    dlg.UseAntiAlias = True
                    dlg.PrintPreviewControl.Zoom = 1.0
                    dlg.ShowDialog()
                End Using
            Else
                pd.Print()
                OpenCashDrawer(prn)
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء طباعة إيصال الحصة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
