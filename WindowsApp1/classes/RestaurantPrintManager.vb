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
                    Catch __logEx As Exception
                        Logger.LogError("RestaurantPrintManager.vb:66", __logEx)
                    End Try
                End If
                If String.IsNullOrWhiteSpace(prn) Then
                    SmartMessageBox.Show("لم يتم تحديد طابعة فواتير في الإعدادات!", "تنبيه الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Catch __logEx As Exception
                Logger.LogError("RestaurantPrintManager.vb:119", __logEx)
            End Try

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If is58mm Then
                                             If pageWidth > 220 Then pageWidth = 200
                                         Else
                                             If pageWidth > 310 Then pageWidth = 298
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
            SmartMessageBox.Show("حدث خطأ أثناء طباعة فاتورة العميل: " & ex.Message, "خطأ طباعة", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Catch __logEx As Exception
                Logger.LogError("RestaurantPrintManager.vb:208", __logEx)
            End Try
        End If

        Using fontTitle As New Font("Segoe UI", If(isSmallPaper, 11.5!, 13.0!), FontStyle.Bold),
              fontSub As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.0!), FontStyle.Regular),
              fontBold As New Font("Segoe UI", baseFontSize + 1.0!, FontStyle.Bold),
              fontRegular As New Font("Segoe UI", baseFontSize + 0.5!, FontStyle.Regular),
              fontHeader As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.5!), FontStyle.Bold),
              fontRow As New Font("Segoe UI", baseFontSize + 0.5!, FontStyle.Regular),
              fontRowBold As New Font("Segoe UI", baseFontSize + 0.5!, FontStyle.Bold),
              fontGrand As New Font("Segoe UI", If(isSmallPaper, 10.5!, 11.5!), FontStyle.Bold),
              fontAddon As New Font("Segoe UI", If(isSmallPaper, 7.5!, 8.0!), FontStyle.Regular),
              fontNote As New Font("Segoe UI", If(isSmallPaper, 7.5!, 8.5!), FontStyle.Bold),
              sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap},
              sfRight As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center},
              sfItemWrap As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
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
            Dim colW1 As Integer = CInt(metaW * 0.53) ' عمود نوع الطلب / رقم الفاتورة
            Dim colW2 As Integer = metaW - colW1     ' عمود التاريخ / العميل (130px كافية لاسم العميل والتاريخ)
            Dim metaRowH As Integer = 26

            ' الصف الأول: رقم الفاتورة + التاريخ
            Dim metaY1 As Integer = yPos
            g.FillRectangle(metaBgBrush, metaX, metaY1, metaW, metaRowH)
            g.DrawRectangle(gridPen, metaX, metaY1, metaW, metaRowH)
            g.DrawLine(gridPen, metaX + colW2, metaY1, metaX + colW2, metaY1 + metaRowH)
            g.DrawString("فاتورة: #" & inv.InvoiceNumber, fontBold, Brushes.Black, New RectangleF(metaX + colW2 + 4, metaY1, colW1 - 8, metaRowH), sfRight)
            g.DrawString(inv.InvoiceDate.ToString("yyyy/MM/dd HH:mm"), fontSub, Brushes.Black, New RectangleF(metaX + 2, metaY1, colW2 - 4, metaRowH), sfCenter)
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
                        Using fontClient As New Font("Segoe UI", If(g.MeasureString(clientOrUser, fontSub).Width > (colW2 - 8), 7.5!, 8.5!), FontStyle.Regular),
                  sfClient As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.NoWrap, .Trimming = StringTrimming.EllipsisCharacter}
                g.DrawString(clientOrUser, fontClient, Brushes.Black, New RectangleF(metaX + 2, metaY2, colW2 - 4, metaRowH), sfClient)
            End Using
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

                ' قياس ارتفاع النص المطلوب لاسم الصنف والإضافات والملاحظات ديناميكياً
                Dim measuredSize = g.MeasureString(itemName, fontRowBold, colNameW - 8, sfItemWrap)
                Dim baseTextH As Integer = Math.Max(20, CInt(Math.Ceiling(measuredSize.Height)) + 2)
                Dim rowH As Integer = baseTextH

                Dim addonH As Integer = 0
                If hasAddons Then
                    Dim addonSize = g.MeasureString("+" & det.AddonsText, fontAddon, colNameW - 8, sfItemWrap)
                    addonH = Math.Max(16, CInt(Math.Ceiling(addonSize.Height)) + 2)
                    rowH += addonH
                End If

                Dim noteH As Integer = 0
                If hasNotes Then
                    Dim noteSize = g.MeasureString("*" & det.Notes, fontNote, colNameW - 8, sfItemWrap)
                    noteH = Math.Max(16, CInt(Math.Ceiling(noteSize.Height)) + 2)
                    rowH += noteH
                End If

                rowH += 4 ' هوامش علوية وسفلية مريحة

                ' رسم تفاصيل الصنف
                Dim textY As Integer = yPos + 2
                g.DrawString(itemName, fontRowBold, Brushes.Black, New RectangleF(xName + 2, textY, colNameW - 6, baseTextH), sfItemWrap)
                textY += baseTextH

                If hasAddons Then
                    g.DrawString("+" & det.AddonsText, fontAddon, Brushes.DarkSlateGray, New RectangleF(xName + 2, textY, colNameW - 6, addonH), sfItemWrap)
                    textY += addonH
                End If

                If hasNotes Then
                    g.DrawString("*" & det.Notes, fontNote, Brushes.DarkRed, New RectangleF(xName + 2, textY, colNameW - 6, noteH), sfItemWrap)
                    textY += noteH
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

            ' 5. جدول ملخص الإجماليات الشبكي (Excel Totals Box) - [FIX] توزيع نسبي
            Dim totalRowH As Integer = 24
            Dim totalValW As Integer = CInt(tableW * If(isSmallPaper, 0.30, 0.32))
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
                    ' الضريبة الفعلية للفاتورة (كانت تُمرَّر صفراً دائماً فيُشفَّر وعاء ضريبي خاطئ)
                    Dim tlvData = QRCodeHelper.BuildZatcaTlvBase64(shopName, shopTax, inv.InvoiceDate, inv.NetTotal, inv.TaxAmount)
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
                g.DrawString("[توصيل] " & deliveryNotice, fontSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
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
            Catch __logEx As Exception
                Logger.LogError("RestaurantPrintManager.vb:532", __logEx)
            End Try
        End If

        Using fontTitle As New Font("Segoe UI", 13.0!, FontStyle.Bold),
              fontSub As New Font("Segoe UI", 9.5!, FontStyle.Regular),
              fontBold As New Font("Segoe UI", baseFontSize + 1.0!, FontStyle.Bold),
              fontRegular As New Font("Segoe UI", baseFontSize + 0.5!, FontStyle.Regular),
              sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center},
              sfRight As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center}

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

            ' 3. جدول الأصناف (هيدر) - [FIX] توزيع نسبي للأعمدة بدلاً من قيم مطلقة
            Dim colTotalW_c As Integer = CInt(pageWidth * 0.24)
            Dim colQtyW_c As Integer = CInt(pageWidth * 0.18)
            Dim colNameW_c As Integer = pageWidth - colTotalW_c - colQtyW_c
            Dim colQtyX_c As Integer = colTotalW_c
            Dim colNameX_c As Integer = colTotalW_c + colQtyW_c

            g.DrawString("الصنف", fontBold, Brushes.Black, New RectangleF(colNameX_c, yPos, colNameW_c, 20), sfRight)
            g.DrawString("الكمية", fontBold, Brushes.Black, New RectangleF(colQtyX_c, yPos, colQtyW_c, 20), sfCenter)
            g.DrawString("الإجمالي", fontBold, Brushes.Black, New RectangleF(0, yPos, colTotalW_c, 20), sfLeft)
            yPos += 22
            DrawSolidLine(g, yPos, pageWidth)
            yPos += 5

            ' 4. تفاصيل الأصناف
            For Each det In inv.Details
                Dim itemDisplay As String = det.ProductName
                If Not String.IsNullOrWhiteSpace(det.SizeName) AndAlso det.SizeName <> "عادي" Then
                    itemDisplay &= " (" & det.SizeName & ")"
                End If

                ' [FIX] قياس ارتفاع النص لمنع القص
                Dim measuredH = g.MeasureString(itemDisplay, fontBold, colNameW_c - 4)
                Dim itemRowH As Integer = Math.Max(20, CInt(measuredH.Height) + 4)

                g.DrawString(itemDisplay, fontBold, Brushes.Black, New RectangleF(colNameX_c, yPos, colNameW_c - 4, itemRowH), sfRight)
                g.DrawString(det.Quantity.ToString(), fontBold, Brushes.Black, New RectangleF(colQtyX_c, yPos, colQtyW_c, itemRowH), sfCenter)
                g.DrawString(det.TotalPrice.ToString("N2"), fontBold, Brushes.Black, New RectangleF(0, yPos, colTotalW_c, itemRowH), sfLeft)
                yPos += itemRowH

                ' سطر الإضافات إن وجدت بديناميكية لمنع القص
                If Not String.IsNullOrWhiteSpace(det.AddonsText) AndAlso det.AddonsText <> "-" Then
                    Dim addonStr = " + " & det.AddonsText
                    Dim aSize = g.MeasureString(addonStr, fontSub, colNameW_c + colQtyW_c - 4, sfRight)
                    Dim aH As Integer = Math.Max(18, CInt(Math.Ceiling(aSize.Height)) + 2)
                    g.DrawString(addonStr, fontSub, Brushes.DimGray, New RectangleF(colQtyX_c, yPos, colNameW_c + colQtyW_c - 4, aH), sfRight)
                    yPos += aH
                End If

                ' الملاحظات إن وجدت بديناميكية لمنع القص
                If Not String.IsNullOrWhiteSpace(det.Notes) Then
                    Dim noteStr = " * " & det.Notes
                    Dim nSize = g.MeasureString(noteStr, fontSub, colNameW_c + colQtyW_c - 4, sfRight)
                    Dim nH As Integer = Math.Max(18, CInt(Math.Ceiling(nSize.Height)) + 2)
                    g.DrawString(noteStr, fontSub, Brushes.DarkRed, New RectangleF(colQtyX_c, yPos, colNameW_c + colQtyW_c - 4, nH), sfRight)
                    yPos += nH
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
                ' [FIX] توزيع نسبي بدلاً من قيمة ثابتة 100px
                Dim netValW As Integer = CInt(pageWidth * 0.38)
                Dim netLblW As Integer = pageWidth - netValW
                g.DrawString("الصافي المطلوب:", fontGrand, Brushes.Black, New RectangleF(netValW, yPos, netLblW, 26), sfRight)
                g.DrawString(inv.NetTotal.ToString("N2") & " ج", fontGrand, Brushes.Black, New RectangleF(0, yPos, netValW, 26), sfLeft)
                yPos += 28
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
                    ' الضريبة الفعلية للفاتورة (كانت تُمرَّر صفراً دائماً فيُشفَّر وعاء ضريبي خاطئ)
                    Dim tlvData = QRCodeHelper.BuildZatcaTlvBase64(shopName, shopTax, inv.InvoiceDate, inv.NetTotal, inv.TaxAmount)
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
                                         Optional ticketTitle As String = "طلب تجهيز المطبخ",
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
                    Catch __logEx As Exception
                        Logger.LogError("RestaurantPrintManager.vb:756", __logEx)
                    End Try
                End If
                If String.IsNullOrWhiteSpace(prn) Then Return
            End If

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = prn
            pd.DefaultPageSettings.Margins = New Margins(2, 2, 2, 2)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                                         g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

                                         Dim paperSizeVal = SettingsManager.GetSettingOrDefault(SettingsKeys.PrinterPaperSize, "80mm").ToLower()
                                         Dim isSmallPaper As Boolean = (paperSizeVal = "58mm" OrElse e.PageBounds.Width < 240)

                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If pageWidth > 310 Then pageWidth = 298
                                         If isSmallPaper Then pageWidth = Math.Min(pageWidth, 205)

                                         Dim kitchenDesign = SettingsManager.GetSettingOrDefault(SettingsKeys.KitchenTicketDesign, "1")
                                         If kitchenDesign = "2" Then
                                             RenderKitchenTicketDesign2(g, pageWidth, isSmallPaper, orderNumber, orderTypeDesc, tableName, staffName, items, ticketTitle)
                                         Else
                                             RenderKitchenTicketDesign1(g, pageWidth, isSmallPaper, orderNumber, orderTypeDesc, tableName, staffName, items, ticketTitle)
                                         End If

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

    ''' <summary>
    ''' تصميم 1 لبون المطبخ: كلاسيكي مدمج وواضح مع التفاف نصوص كامل للأصناف والملاحظات
    ''' </summary>
    Private Shared Sub RenderKitchenTicketDesign1(g As Graphics,
                                                 pageWidth As Integer,
                                                 isSmallPaper As Boolean,
                                                 orderNumber As String,
                                                 orderTypeDesc As String,
                                                 tableName As String,
                                                 staffName As String,
                                                 items As List(Of InvoiceDetailModel),
                                                 ticketTitle As String)
        Dim yPos As Integer = 8
        Dim isFollowUp As Boolean = ticketTitle.Contains("متابعة")

        Using fontTitle As New Font("Segoe UI", If(isSmallPaper, 12.0!, 13.5!), FontStyle.Bold),
              fontOrderType As New Font("Segoe UI", If(isSmallPaper, 11.5!, 13.0!), FontStyle.Bold),
              fontMeta As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.0!), FontStyle.Regular),
              fontMetaBold As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.0!), FontStyle.Bold),
              fontColHeader As New Font("Segoe UI", If(isSmallPaper, 9.0!, 10.0!), FontStyle.Bold),
              fontItemName As New Font("Segoe UI", If(isSmallPaper, 10.5!, 11.5!), FontStyle.Bold),
              fontQty As New Font("Segoe UI", If(isSmallPaper, 11.5!, 13.0!), FontStyle.Bold),
              fontAddon As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.0!), FontStyle.Regular),
              fontNotes As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.5!), FontStyle.Bold),
              fontFooter As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.0!), FontStyle.Regular),
              sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center},
              sfRight As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              sfItemWrap As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center},
              headerBrush As New SolidBrush(Color.FromArgb(240, 240, 240)),
              noteBrush As New SolidBrush(Color.FromArgb(254, 242, 242)),
              penDark As New Pen(Color.Black, 2.0!),
              penNote As New Pen(Color.FromArgb(239, 68, 68), 1.0!)

            ' 1. عنوان البون
            Dim titleRect As New RectangleF(4, yPos, pageWidth - 8, 26)
            If isFollowUp Then
                g.FillRectangle(headerBrush, 4, yPos, pageWidth - 8, 26)
                g.DrawRectangle(penDark, 4, yPos, pageWidth - 8, 26)
                g.DrawString("◄◄ " & ticketTitle & " ►►", fontTitle, Brushes.Black, titleRect, sfCenter)
            Else
                g.DrawString("══ " & ticketTitle & " ══", fontTitle, Brushes.Black, titleRect, sfCenter)
            End If
            yPos += 28

            If isFollowUp Then
                Dim alertRect As New RectangleF(4, yPos, pageWidth - 8, 20)
                g.DrawString("[تنبيه]: أصناف جديدة مضافة للطلب", fontMetaBold, Brushes.DarkRed, alertRect, sfCenter)
                yPos += 22
            End If

            ' 2. نوع الطلب والطاولة
            Dim tableOrType As String = orderTypeDesc
            If Not String.IsNullOrWhiteSpace(tableName) AndAlso Not orderTypeDesc.Contains(tableName) Then
                tableOrType &= " [ " & tableName & " ]"
            End If
            g.DrawString(tableOrType, fontOrderType, Brushes.Black, New RectangleF(4, yPos, pageWidth - 8, 24), sfCenter)
            yPos += 26

            DrawSolidLine(g, yPos, pageWidth, 2)
            yPos += 6

            ' 3. البيانات الوصفية (رقم الطلب، التاريخ، الكاشير)
            g.DrawString("طلب رقم: " & orderNumber, fontMetaBold, Brushes.Black, New RectangleF(4, yPos, pageWidth - 8, 18), sfRight)
            yPos += 18
            g.DrawString("الوقت: " & DateTime.Now.ToString("yyyy/MM/dd - hh:mm tt"), fontMeta, Brushes.Black, New RectangleF(4, yPos, pageWidth - 8, 18), sfRight)
            yPos += 18
            If Not String.IsNullOrWhiteSpace(staffName) Then
                g.DrawString("الكاشير/الويتر: " & staffName, fontMeta, Brushes.Black, New RectangleF(4, yPos, pageWidth - 8, 18), sfRight)
                yPos += 18
            End If

            DrawSolidLine(g, yPos, pageWidth, 1)
            yPos += 5

            ' 4. ترويسة الأعمدة
            Dim colQtyW As Integer = If(isSmallPaper, 38, 48)
            Dim colNameW As Integer = (pageWidth - 8) - colQtyW

            g.DrawString("الكمية", fontColHeader, Brushes.Black, New RectangleF(4, yPos, colQtyW, 20), sfLeft)
            g.DrawString("الصنف والملاحظات", fontColHeader, Brushes.Black, New RectangleF(4 + colQtyW, yPos, colNameW, 20), sfRight)
            yPos += 22
            DrawDashedLine(g, yPos, pageWidth)
            yPos += 6

            ' 5. قائمة الأصناف
            Dim totalQty As Integer = 0
            For Each det In items
                totalQty += det.Quantity

                ' اسم الصنف مع الحجم
                Dim itemName As String = det.ProductName
                If Not String.IsNullOrWhiteSpace(det.SizeName) AndAlso det.SizeName <> "عادي" Then
                    itemName &= " (" & det.SizeName & ")"
                End If

                ' قياس ارتفاع اسم الصنف لمنع أي قص
                Dim nameSize = g.MeasureString(itemName, fontItemName, colNameW, sfItemWrap)
                Dim nameH As Integer = Math.Max(22, CInt(Math.Ceiling(nameSize.Height)) + 2)

                ' رسم الكمية في اليسار بخط عريض
                g.DrawString(det.Quantity.ToString() & "x", fontQty, Brushes.Black, New RectangleF(4, yPos, colQtyW, nameH), sfLeft)

                ' رسم اسم الصنف في اليمين مع التفاف كامل
                g.DrawString(itemName, fontItemName, Brushes.Black, New RectangleF(4 + colQtyW, yPos, colNameW, nameH), sfItemWrap)
                yPos += nameH

                ' الإضافات
                If Not String.IsNullOrWhiteSpace(det.AddonsText) AndAlso det.AddonsText <> "-" Then
                    Dim addonText As String = "  [+] إضافات: " & det.AddonsText
                    Dim addonSize = g.MeasureString(addonText, fontAddon, pageWidth - 12, sfItemWrap)
                    Dim addonH As Integer = Math.Max(16, CInt(Math.Ceiling(addonSize.Height)) + 2)
                    g.DrawString(addonText, fontAddon, Brushes.DarkSlateGray, New RectangleF(4, yPos, pageWidth - 8, addonH), sfItemWrap)
                    yPos += addonH
                End If

                ' ملاحظات التحضير (مثل بدون شطة، تسوية زيادة)
                If Not String.IsNullOrWhiteSpace(det.Notes) Then
                    Dim noteText As String = "  [*] ملاحظة: " & det.Notes
                    Dim noteSize = g.MeasureString(noteText, fontNotes, pageWidth - 16, sfItemWrap)
                    Dim noteH As Integer = Math.Max(18, CInt(Math.Ceiling(noteSize.Height)) + 4)

                    ' بوكس مظلل للملاحظات
                    g.FillRectangle(noteBrush, 4, yPos, pageWidth - 8, noteH)
                    g.DrawRectangle(penNote, 4, yPos, pageWidth - 8, noteH)
                    g.DrawString(noteText, fontNotes, Brushes.DarkRed, New RectangleF(6, yPos + 2, pageWidth - 12, noteH - 4), sfItemWrap)
                    yPos += noteH + 3
                End If

                yPos += 3
                DrawDashedLine(g, yPos, pageWidth)
                yPos += 5
            Next

            ' 6. التذييل
            yPos += 4
            g.DrawString("إجمالي الكميات: " & totalQty.ToString() & " قطعة", fontMetaBold, Brushes.Black, New RectangleF(4, yPos, pageWidth - 8, 18), sfCenter)
            yPos += 20
            Dim endText As String = If(isFollowUp, "══ نهاية ورقة المتابعة ══", "══ نهاية طلب التجهيز ══")
            g.DrawString(endText, fontFooter, Brushes.Gray, New RectangleF(4, yPos, pageWidth - 8, 18), sfCenter)
            yPos += 22
        End Using
    End Sub

    ''' <summary>
    ''' تصميم 2 لبون المطبخ: بطاقات حديثة مقسمة لكل صنف مع شارات بارزة ومربعات مميزة للملاحظات
    ''' </summary>
    Private Shared Sub RenderKitchenTicketDesign2(g As Graphics,
                                                 pageWidth As Integer,
                                                 isSmallPaper As Boolean,
                                                 orderNumber As String,
                                                 orderTypeDesc As String,
                                                 tableName As String,
                                                 staffName As String,
                                                 items As List(Of InvoiceDetailModel),
                                                 ticketTitle As String)
        Dim yPos As Integer = 8
        Dim isFollowUp As Boolean = ticketTitle.Contains("متابعة")

        Using fontTitle As New Font("Segoe UI", If(isSmallPaper, 12.0!, 13.5!), FontStyle.Bold),
              fontOrderType As New Font("Segoe UI", If(isSmallPaper, 12.5!, 14.0!), FontStyle.Bold),
              fontMeta As New Font("Segoe UI", If(isSmallPaper, 8.0!, 8.5!), FontStyle.Regular),
              fontMetaBold As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.0!), FontStyle.Bold),
              fontItemName As New Font("Segoe UI", If(isSmallPaper, 11.0!, 12.0!), FontStyle.Bold),
              fontQty As New Font("Segoe UI", If(isSmallPaper, 12.0!, 13.5!), FontStyle.Bold),
              fontAddon As New Font("Segoe UI", If(isSmallPaper, 8.0!, 8.5!), FontStyle.Regular),
              fontNotes As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.0!), FontStyle.Bold),
              fontFooter As New Font("Segoe UI", If(isSmallPaper, 8.5!, 9.0!), FontStyle.Bold),
              sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center},
              sfRight As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              sfItemWrap As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center},
              headerBgBrush As New SolidBrush(Color.FromArgb(235, 238, 242)),
              badgeBgBrush As New SolidBrush(Color.FromArgb(220, 226, 236)),
              cardBgBrush As New SolidBrush(Color.FromArgb(250, 251, 252)),
              qtyBadgeBrush As New SolidBrush(Color.FromArgb(233, 236, 239)),
              noteBgBrush As New SolidBrush(Color.FromArgb(254, 242, 242)),
              penBorder As New Pen(Color.FromArgb(55, 65, 81), 1.5!),
              penCard As New Pen(Color.FromArgb(107, 114, 128), 1.2!),
              penBadge As New Pen(Color.FromArgb(75, 85, 99), 1.0!),
              penNote As New Pen(Color.FromArgb(220, 38, 38), 1.0!)

            ' 1. بطاقة الرأس المؤطرة (Header Card)
            Dim headerH As Integer = If(isFollowUp, 62, 38)
            Dim headerRect As New Rectangle(4, yPos, pageWidth - 8, headerH)
            g.FillRectangle(headerBgBrush, headerRect)
            g.DrawRectangle(penBorder, headerRect)

            ' العنوان
            Dim titleRect As New RectangleF(6, yPos + 4, pageWidth - 12, 26)
            Dim titlePrefix As String = If(isFollowUp, "[!] ", "◆ ")
            g.DrawString(titlePrefix & ticketTitle, fontTitle, Brushes.Black, titleRect, sfCenter)

            If isFollowUp Then
                Dim alertRect As New RectangleF(6, yPos + 32, pageWidth - 12, 24)
                g.FillRectangle(noteBgBrush, 8, yPos + 32, pageWidth - 16, 22)
                g.DrawRectangle(penNote, 8, yPos + 32, pageWidth - 16, 22)
                g.DrawString("[!] طلب متابعة: أصناف مضافة حديثاً", fontMetaBold, Brushes.DarkRed, alertRect, sfCenter)
            End If
            yPos += headerH + 6

            ' 2. نوع الطلب والطاولة داخل شارة بارزة وضخمة
            Dim tableOrType As String = orderTypeDesc
            If Not String.IsNullOrWhiteSpace(tableName) AndAlso Not orderTypeDesc.Contains(tableName) Then
                tableOrType &= " [ " & tableName & " ]"
            End If
            Dim badgeH As Integer = 34
            Dim typeBadgeRect As New Rectangle(4, yPos, pageWidth - 8, badgeH)
            g.FillRectangle(badgeBgBrush, typeBadgeRect)
            g.DrawRectangle(penBorder, typeBadgeRect)
            g.DrawString(tableOrType, fontOrderType, Brushes.Black, New RectangleF(6, yPos, pageWidth - 12, badgeH), sfCenter)
            yPos += badgeH + 6

            ' 3. صندوق البيانات الوصفية (جدول من سطرين)
            Dim metaBoxH As Integer = 38
            Dim metaRect As New Rectangle(4, yPos, pageWidth - 8, metaBoxH)
            g.DrawRectangle(penCard, metaRect)
            Dim halfW As Integer = (pageWidth - 8) \ 2
            g.DrawLine(penCard, 4 + halfW, yPos, 4 + halfW, yPos + metaBoxH)
            g.DrawLine(penCard, 4, yPos + 19, 4 + (pageWidth - 8), yPos + 19)

            ' السطر الأول: رقم الطلب (يمين) | التاريخ (يسار)
            g.DrawString("طلب #: " & orderNumber, fontMetaBold, Brushes.Black, New RectangleF(4 + halfW + 4, yPos + 1, halfW - 8, 18), sfRight)
            g.DrawString(DateTime.Now.ToString("yyyy/MM/dd"), fontMeta, Brushes.Black, New RectangleF(6, yPos + 1, halfW - 8, 18), sfCenter)

            ' السطر الثاني: الويتر/الكاشير (يمين) | الوقت (يسار)
            Dim waiterStr As String = If(Not String.IsNullOrWhiteSpace(staffName), "الويتر: " & staffName, "كاشير")
            g.DrawString(waiterStr, fontMeta, Brushes.Black, New RectangleF(4 + halfW + 4, yPos + 19, halfW - 8, 18), sfRight)
            g.DrawString(DateTime.Now.ToString("hh:mm tt"), fontMetaBold, Brushes.Black, New RectangleF(6, yPos + 19, halfW - 8, 18), sfCenter)
            yPos += metaBoxH + 8

            ' 4. بطاقات الأصناف المستقلة (Item Cards)
            Dim totalQty As Integer = 0
            Dim cardW As Integer = pageWidth - 8
            Dim qtyBadgeW As Integer = If(isSmallPaper, 40, 50)
            Dim innerNameW As Integer = cardW - qtyBadgeW - 14

            For Each det In items
                totalQty += det.Quantity

                ' اسم الصنف مع الحجم
                Dim itemName As String = det.ProductName
                If Not String.IsNullOrWhiteSpace(det.SizeName) AndAlso det.SizeName <> "عادي" Then
                    itemName &= " (" & det.SizeName & ")"
                End If

                ' قياس ارتفاع اسم الصنف
                Dim nameSize = g.MeasureString(itemName, fontItemName, innerNameW, sfItemWrap)
                Dim nameH As Integer = Math.Max(24, CInt(Math.Ceiling(nameSize.Height)) + 2)

                ' حساب ارتفاع البطاقة بالكامل
                Dim hasAddons As Boolean = (Not String.IsNullOrWhiteSpace(det.AddonsText) AndAlso det.AddonsText <> "-")
                Dim hasNotes As Boolean = Not String.IsNullOrWhiteSpace(det.Notes)

                Dim addonH As Integer = 0
                Dim addonText As String = ""
                If hasAddons Then
                    addonText = "[+] " & det.AddonsText
                    Dim addonSize = g.MeasureString(addonText, fontAddon, cardW - 16, sfItemWrap)
                    addonH = Math.Max(16, CInt(Math.Ceiling(addonSize.Height)) + 2)
                End If

                Dim noteH As Integer = 0
                Dim noteText As String = ""
                If hasNotes Then
                    noteText = "[*] ملاحظة: " & det.Notes
                    Dim noteSize = g.MeasureString(noteText, fontNotes, cardW - 24, sfItemWrap)
                    noteH = Math.Max(20, CInt(Math.Ceiling(noteSize.Height)) + 6)
                End If

                Dim cardH As Integer = 8 + nameH
                If hasAddons Then cardH += addonH + 4
                If hasNotes Then cardH += noteH + 6
                cardH += 6 ' هامش سفلي للبطاقة

                ' رسم خلفية وحدود البطاقة
                Dim cardRect As New Rectangle(4, yPos, cardW, cardH)
                g.FillRectangle(cardBgBrush, cardRect)
                g.DrawRectangle(penCard, cardRect)

                ' رسم شارة الكمية في يسار البطاقة
                Dim badgeBoxH As Integer = Math.Min(34, cardH - 12)
                Dim badgeRect As New Rectangle(8, yPos + 6, qtyBadgeW, badgeBoxH)
                g.FillRectangle(qtyBadgeBrush, badgeRect)
                g.DrawRectangle(penBadge, badgeRect)
                g.DrawString(det.Quantity.ToString() & "x", fontQty, Brushes.Black, New RectangleF(badgeRect.X, badgeRect.Y, badgeRect.Width, badgeRect.Height), sfCenter)

                ' رسم اسم الصنف في يمين البطاقة
                Dim nameX As Integer = 4 + qtyBadgeW + 8
                g.DrawString(itemName, fontItemName, Brushes.Black, New RectangleF(nameX, yPos + 6, innerNameW, nameH), sfItemWrap)

                Dim currentInnerY As Integer = yPos + 6 + nameH + 2

                ' رسم الإضافات داخل البطاقة
                If hasAddons Then
                    g.DrawString(addonText, fontAddon, Brushes.DarkSlateGray, New RectangleF(8, currentInnerY, cardW - 16, addonH), sfItemWrap)
                    currentInnerY += addonH + 4
                End If

                ' رسم الملاحظات داخل بوكس مميز بالبطاقة
                If hasNotes Then
                    Dim nBoxRect As New Rectangle(8, currentInnerY, cardW - 16, noteH)
                    g.FillRectangle(noteBgBrush, nBoxRect)
                    g.DrawRectangle(penNote, nBoxRect)
                    g.DrawString(noteText, fontNotes, Brushes.DarkRed, New RectangleF(12, currentInnerY + 2, cardW - 24, noteH - 4), sfItemWrap)
                    currentInnerY += noteH + 4
                End If

                yPos += cardH + 6 ' مسافة فاصلة بين كل كارت والتالي
            Next

            ' 5. بطاقة التلخيص والتذييل
            Dim footerH As Integer = 46
            Dim footerRect As New Rectangle(4, yPos, pageWidth - 8, footerH)
            g.FillRectangle(headerBgBrush, footerRect)
            g.DrawRectangle(penBorder, footerRect)

            g.DrawString("إجمالي الكميات: " & totalQty.ToString() & " قطعة | الأصناف: " & items.Count.ToString(), fontFooter, Brushes.Black, New RectangleF(6, yPos + 4, pageWidth - 12, 18), sfCenter)
            Dim footerEndText As String = If(isFollowUp, "« للتجهيز والمتابعة الفورية »", "« للتجهيز والتحضير الفوري »")
            g.DrawString(footerEndText, fontMetaBold, Brushes.DarkSlateGray, New RectangleF(6, yPos + 24, pageWidth - 12, 18), sfCenter)
            yPos += footerH + 16
        End Using
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
            pd.DefaultPageSettings.Margins = New Margins(2, 2, 2, 2)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If pageWidth > 310 Then pageWidth = 298

                                         Dim yPos As Integer = 10

                                         Using fontTitle As New Font("Segoe UI", 13.0!, FontStyle.Bold),
                                               fontHeader As New Font("Segoe UI", 10.5!, FontStyle.Bold),
                                               fontBold As New Font("Segoe UI", 9.5!, FontStyle.Bold),
                                               fontRegular As New Font("Segoe UI", 9.0!, FontStyle.Regular),
                                               sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center},
                                               sfRight As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
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
                                             g.DrawString("توقيع الكاشير: ____________", fontRegular, Brushes.Black, New RectangleF(pageWidth \ 2, yPos, pageWidth \ 2, 20), sfRight)
                                             g.DrawString("توقيع المدير: ____________", fontRegular, Brushes.Black, New RectangleF(0, yPos, pageWidth \ 2, 20), sfLeft)
                                             yPos += 35
                                         End Using

                                         e.HasMorePages = False
                                     End Sub

            pd.Print()

        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء طباعة تقرير الوردية Z-Report: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ═════════════════════════════════════════════════════════════════
    ' دوال مساعدة في الرسم والتنسيق
    ' ═════════════════════════════════════════════════════════════════
    Private Shared Sub DrawAmountRow(g As Graphics, label As String, val As String, fnt As Font, sfRight As StringFormat, sfLeft As StringFormat, y As Integer, w As Integer)
        ' [FIX] توزيع نسبي للأعمدة بدلاً من قيم ثابتة - لضمان محاذاة صحيحة على كل مقاسات الورق
        Dim valColW As Integer = CInt(w * 0.35)
        Dim lblColW As Integer = w - valColW
        Dim rowH As Integer = Math.Max(18, CInt(fnt.GetHeight(g)) + 4)
        g.DrawString(label, fnt, Brushes.Black, New RectangleF(valColW, y, lblColW, rowH), sfRight)
        g.DrawString(val, fnt, Brushes.Black, New RectangleF(0, y, valColW, rowH), sfLeft)
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
                SmartMessageBox.Show("لم يتم تحديد طابعة فواتير في الإعدادات!", "تنبيه الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim shopName = SettingsManager.GetSettingOrDefault("ShopName", "مطعم")
            Dim shopPhone = SettingsManager.GetSettingOrDefault("ShopPhone", "")
            Dim footerText = SettingsManager.GetSettingOrDefault("FooterText", "شكراً لزيارتكم ونتشرف بخدمتكم دائماً")

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = prn
            pd.DefaultPageSettings.Margins = New Margins(2, 2, 2, 2)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim g As Graphics = e.Graphics
                                         Dim pageWidth As Integer = e.PageBounds.Width
                                         If pageWidth > 310 Then pageWidth = 298

                                         Dim yPos As Integer = 10

                                         Using fontTitle As New Font("Segoe UI", 12.0!, FontStyle.Bold),
                                               fontSub As New Font("Segoe UI", 8.5!, FontStyle.Regular),
                                               fontBold As New Font("Segoe UI", 9.5!, FontStyle.Bold),
                                               fontRegular As New Font("Segoe UI", 9.0!, FontStyle.Regular),
                                               sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center},
                                               sfRight As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
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
            SmartMessageBox.Show("خطأ أثناء طباعة إيصال الحصة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
