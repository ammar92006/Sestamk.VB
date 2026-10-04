Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms
Imports ZXing

Public Module ThermalTestReceiptHelper

    ' أوامر ESC/POS للدرج والقص
    Private ReadOnly ESC_DRAWER_KICK As Byte() = {&H1B, &H70, &H0, &H19, &HFA} ' نبضة فتح درج الكاشير
    Private ReadOnly ESC_PAPER_CUT As Byte() = {&H1D, &H56, &H41, &H5}       ' قص الورق الجزئي (Partial Cut)

    ''' <summary>
    ''' طباعة أو معاينة ورقة اختبار الطابعة الحرارية بتصميم احترافي متكامل
    ''' </summary>
    Public Sub PrintTestReceipt(printerName As String,
                                Optional paperSize As String = "80mm",
                                Optional printLogo As Boolean = True,
                                Optional printBarcode As Boolean = True,
                                Optional openDrawer As Boolean = False,
                                Optional usePreview As Boolean = False)

        If String.IsNullOrWhiteSpace(printerName) Then
            SmartMessageBox.Show("يرجى اختيار الطابعة الحرارية أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim is80mm As Boolean = Not String.Equals(paperSize, "58mm", StringComparison.OrdinalIgnoreCase)
            Dim targetWidth As Integer = If(is80mm, 285, 195)
            Dim paperWidthUnits As Integer = If(is80mm, 300, 210)

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = printerName
            pd.DefaultPageSettings.PaperSize = New PaperSize("ThermalTest", paperWidthUnits, 5000)
            pd.DefaultPageSettings.Margins = New Margins(2, 2, 2, 2)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         DrawTestReceiptContent(e.Graphics, targetWidth, is80mm, printerName, printLogo, printBarcode, openDrawer)
                                         e.HasMorePages = False
                                     End Sub

            If usePreview Then
                Using dlg As New PrintPreviewDialog()
                    dlg.Document = pd
                    dlg.Text = "معاينة ورقة اختبار الطابعة الحرارية - سيستمك"
                    dlg.WindowState = FormWindowState.Normal
                    dlg.Width = 480
                    dlg.Height = 740
                    dlg.StartPosition = FormStartPosition.CenterScreen
                    dlg.UseAntiAlias = True
                    dlg.PrintPreviewControl.Zoom = 1.0
                    dlg.ShowIcon = False
                    dlg.ShowDialog()
                End Using
            Else
                pd.Print()

                If openDrawer Then
                    RawPrinterHelper.SendBytesToPrinter(printerName, ESC_DRAWER_KICK)
                End If

                RawPrinterHelper.SendBytesToPrinter(printerName, ESC_PAPER_CUT)

                Try
                    Notify.Toast("تم إرسال ورقة اختبار الطابعة بنجاح ✅", Notify.ToastType.Success)
                Catch
                    SmartMessageBox.Show("✅ تم إرسال صفحة الاختبار للطابعة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If

        Catch ex As Exception
            SmartMessageBox.Show("❌ خطأ أثناء اختبار الطابعة: " & ex.Message, "خطأ في الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' رسم محتوى ورقة الاختبار على أي كائن Graphics مع إرجاع الارتفاع الكلي
    ''' </summary>
    Public Function DrawTestReceiptContent(g As Graphics, pageWidth As Integer, is80mm As Boolean,
                                           printerName As String, printLogo As Boolean,
                                           printBarcode As Boolean, openDrawer As Boolean) As Integer

        g.SmoothingMode = SmoothingMode.HighQuality
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim yPos As Integer = 6

        ' جلب بيانات المتجر من الإعدادات
        Dim shopName As String = SettingsManager.GetSetting("ShopName")
        If String.IsNullOrWhiteSpace(shopName) Then shopName = "نظام سيستمك لإدارة المبيعات"

        Dim shopPhone As String = SettingsManager.GetSetting("ShopPhone")
        Dim shopPhone2 As String = SettingsManager.GetSetting("ShopPhone2")
        Dim shopAddress As String = SettingsManager.GetSetting("ShopAddress")
        Dim logoPath As String = SettingsManager.GetSetting("LogoPath")

        Dim currentUserName As String = If(Not String.IsNullOrWhiteSpace(Session.CurrentUserfullName),
                                           Session.CurrentUserfullName,
                                           If(Not String.IsNullOrWhiteSpace(Session.CurrentUserName), Session.CurrentUserName, Environment.UserName))

        ' تنسيقات النصوص والخطوط
        Using sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center},
              sfRight As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.DirectionRightToLeft},
              sfLeft As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center},
              fontShopName As New Font("Segoe UI", If(is80mm, 13.0!, 11.0!), FontStyle.Bold),
              fontBannerTitle As New Font("Segoe UI", If(is80mm, 11.0!, 9.5!), FontStyle.Bold),
              fontBannerSub As New Font("Segoe UI", If(is80mm, 8.5!, 7.0!), FontStyle.Regular),
              fontSectionHeader As New Font("Segoe UI", If(is80mm, 10.0!, 8.5!), FontStyle.Bold),
              fontBold As New Font("Segoe UI", If(is80mm, 9.5!, 8.0!), FontStyle.Bold),
              fontRegular As New Font("Segoe UI", If(is80mm, 9.0!, 7.5!), FontStyle.Regular),
              fontSmall As New Font("Segoe UI", If(is80mm, 8.0!, 7.0!), FontStyle.Regular),
              fontTotal As New Font("Segoe UI", If(is80mm, 12.0!, 10.0!), FontStyle.Bold)

            ' ══════════════════════════════════════════════════════
            ' 1. الشعار (Logo)
            ' ══════════════════════════════════════════════════════
            If printLogo AndAlso Not String.IsNullOrEmpty(logoPath) AndAlso File.Exists(logoPath) Then
                Try
                    Using originalLogo = Image.FromFile(logoPath)
                        Dim maxLogoW As Integer = If(is80mm, 150, 100)
                        Dim logoW As Integer = Math.Min(maxLogoW, pageWidth - 20)
                        Dim logoH As Integer = CInt(originalLogo.Height * (CDbl(logoW) / originalLogo.Width))
                        If logoH > 70 Then logoH = 70
                        Dim logoX As Integer = (pageWidth - logoW) \ 2
                        g.DrawImage(originalLogo, New Rectangle(logoX, yPos, logoW, logoH))
                        yPos += logoH + 6
                    End Using
                Catch __logEx As Exception
                    Logger.LogError("ThermalTestReceiptHelper.vb:132", __logEx)
                End Try
            End If

            ' ══════════════════════════════════════════════════════
            ' 2. اسم المنشأة وبياناتها
            ' ══════════════════════════════════════════════════════
            g.DrawString(shopName, fontShopName, Brushes.Black, New RectangleF(0, yPos, pageWidth, 24), sfCenter)
            yPos += 24

            Dim phones As String = shopPhone & If(Not String.IsNullOrWhiteSpace(shopPhone2), " - " & shopPhone2, "")
            If Not String.IsNullOrWhiteSpace(phones) Then
                g.DrawString("هاتف: " & phones, fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 15), sfCenter)
                yPos += 15
            End If

            If Not String.IsNullOrWhiteSpace(shopAddress) Then
                g.DrawString(shopAddress, fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 15), sfCenter)
                yPos += 15
            End If

            yPos += 4

            ' ══════════════════════════════════════════════════════
            ' 3. شريط العنوان الرئيسي المزين (Banner)
            ' ══════════════════════════════════════════════════════
            DrawDoubleLine(g, yPos, pageWidth)
            yPos += 5
            g.DrawString("★ صفحة اختبار الطابعة الحرارية ★", fontBannerTitle, Brushes.Black, New RectangleF(0, yPos, pageWidth, 20), sfCenter)
            yPos += 20
            g.DrawString("THERMAL PRINTER HARDWARE TEST", fontBannerSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 14), sfCenter)
            yPos += 15
            DrawDoubleLine(g, yPos, pageWidth)
            yPos += 8

            ' ══════════════════════════════════════════════════════
            ' 4. بيانات الطابعة والنظام (Device & System Info)
            ' ══════════════════════════════════════════════════════
            g.DrawString("── [ بيانات الطابعة والنظام ] ──", fontSectionHeader, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
            yPos += 20

            Dim rowH As Integer = If(is80mm, 18, 16)
            DrawKeyValue(g, "اسم الطابعة:", TruncateText(printerName, If(is80mm, 26, 17)), fontRegular, fontBold, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += rowH
            DrawKeyValue(g, "مقاس الورق:", If(is80mm, "80 ملم - عادي", "58 ملم - صغير"), fontRegular, fontBold, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += rowH
            DrawKeyValue(g, "حالة الاتصال:", "متصلة وجاهزة ✔", fontRegular, fontBold, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += rowH
            DrawKeyValue(g, "التاريخ والوقت:", DateTime.Now.ToString("yyyy/MM/dd HH:mm"), fontRegular, fontRegular, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += rowH
            DrawKeyValue(g, "اسم الجهاز:", Environment.MachineName, fontRegular, fontRegular, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += rowH
            DrawKeyValue(g, "المستخدم الحالي:", currentUserName, fontRegular, fontRegular, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += rowH + 2

            DrawDashedLine(g, yPos, pageWidth)
            yPos += 7

            ' ══════════════════════════════════════════════════════
            ' 5. اختبار وضوح وجودة الخطوط العربية والإنجليزية
            ' ══════════════════════════════════════════════════════
            g.DrawString("── [ اختبار جودة الخطوط ] ──", fontSectionHeader, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
            yPos += 20

            g.DrawString("خط عريض: نظام سيستمك الذكي للمبيعات", fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 17), sfCenter)
            yPos += 17

            If is80mm Then
                g.DrawString("أ ب ت ث ج ح خ د ذ ر ز س ش ص ض ط ظ ع غ ف ق ك ل م ن هـ و ي", fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
                yPos += 16
            Else
                g.DrawString("أ ب ت ث ج ح خ د ذ ر ز س ش ص", fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 14), sfCenter)
                yPos += 14
                g.DrawString("ض ط ظ ع غ ف ق ك ل م ن هـ و ي", fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 14), sfCenter)
                yPos += 15
            End If

            g.DrawString("0 1 2 3 4 5 6 7 8 9 | LE / ج.م / $ / % / @ / #", fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
            yPos += 18

            DrawDashedLine(g, yPos, pageWidth)
            yPos += 7

            ' ══════════════════════════════════════════════════════
            ' 6. محاكاة جدول الفاتورة لاختبار المحاذاة (Sample Grid)
            ' ══════════════════════════════════════════════════════
            g.DrawString("── [ نموذج معاينة جدول الفاتورة ] ──", fontSectionHeader, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
            yPos += 20

            ' تقسيم الأعمدة بدقة
            Dim colTotalW As Integer = If(is80mm, 50, 34)
            Dim colPriceW As Integer = If(is80mm, 45, 28)
            Dim colQtyW As Integer = If(is80mm, 35, 28)
            Dim colNameX As Integer = colTotalW + colPriceW + colQtyW + 4
            Dim colNameW As Integer = pageWidth - colNameX

            ' رأس الجدول
            g.DrawString("الصنف", fontBold, Brushes.Black, New RectangleF(colNameX, yPos, colNameW, 16), sfRight)
            g.DrawString("الكمية", fontSmall, Brushes.Black, New RectangleF(colTotalW + colPriceW, yPos, colQtyW, 16), sfCenter)
            g.DrawString("السعر", fontSmall, Brushes.Black, New RectangleF(colTotalW, yPos, colPriceW, 16), sfCenter)
            g.DrawString("الإجمالي", fontSmall, Brushes.Black, New RectangleF(0, yPos, colTotalW, 16), sfLeft)
            yPos += 18

            DrawSolidLine(g, yPos, pageWidth)
            yPos += 5

            ' الأصناف التجريبية
            DrawItemRow(g, "شاي العروسة 250جم", "2", "35.00", "70.00", fontRegular, fontBold, sfRight, sfCenter, sfLeft, yPos, colNameX, colNameW, colQtyW, colPriceW, colTotalW)
            yPos += 17

            DrawItemRow(g, "سكر أبيض فاخر 1كجم", "1", "25.00", "25.00", fontRegular, fontBold, sfRight, sfCenter, sfLeft, yPos, colNameX, colNameW, colQtyW, colPriceW, colTotalW)
            yPos += 17

            DrawItemRow(g, "مياه معدنية 1.5 لتر", "3", "8.00", "24.00", fontRegular, fontBold, sfRight, sfCenter, sfLeft, yPos, colNameX, colNameW, colQtyW, colPriceW, colTotalW)
            yPos += 19

            DrawSolidLine(g, yPos, pageWidth)
            yPos += 6

            ' الإجماليات
            Dim vatLabel As String = If(is80mm, "الضريبة (14%):", "ض.ق.م (14%):")
            DrawKeyValue(g, "إجمالي الأصناف:", "119.00 ج.م", fontRegular, fontRegular, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += 18

            DrawKeyValue(g, vatLabel, "16.66 ج.م", fontRegular, fontRegular, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += 19

            ' برواز الصافي المطلوب - [FIX] توزيع نسبي بدلاً من قيم ثابتة
            Dim netBoxH As Integer = If(is80mm, 26, 22)
            Using pNet As New Pen(Color.Black, 1.5!)
                g.DrawRectangle(pNet, 1, yPos, pageWidth - 2, netBoxH)
            End Using
            Dim netTitle As String = If(is80mm, "الصافي الإجمالي:", "الصافي:")
            Dim splitNet As Integer = CInt(pageWidth * 0.35)
            g.DrawString(netTitle, fontTotal, Brushes.Black, New RectangleF(splitNet, yPos + 2, pageWidth - splitNet - 4, netBoxH - 4), sfRight)
            g.DrawString("135.66 ج.م", fontTotal, Brushes.Black, New RectangleF(4, yPos + 2, splitNet - 4, netBoxH - 4), sfLeft)
            yPos += netBoxH + 6

            DrawKeyValue(g, "طريقة الدفع:", "نقداً - Cash", fontSmall, fontSmall, sfRight, sfLeft, yPos, pageWidth, is80mm)
            yPos += 18

            DrawDashedLine(g, yPos, pageWidth)
            yPos += 7

            ' ══════════════════════════════════════════════════════
            ' 7. اختبار الباركود والـ QR Code
            ' ══════════════════════════════════════════════════════
            If printBarcode Then
                g.DrawString("── [ فحص الباركود والماسح ] ──", fontSectionHeader, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
                yPos += 20

                ' 1. باركود خطي (Code 128)
                Dim barWidth As Integer = Math.Min(If(is80mm, 200, 150), pageWidth - 20)
                Dim barHeight As Integer = If(is80mm, 35, 28)
                Using barBmp = GenerateBarcode128("20260918001", barWidth, barHeight)
                    If barBmp IsNot Nothing Then
                        Dim barX As Integer = (pageWidth - barWidth) \ 2
                        g.DrawImage(barBmp, New Rectangle(barX, yPos, barWidth, barHeight))
                        yPos += barHeight + 3
                        g.DrawString("* 20260918001 *", fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 14), sfCenter)
                        yPos += 16
                    End If
                End Using

                ' 2. رمز QR Code
                Dim qrSize As Integer = If(is80mm, 90, 75)
                Dim qrContent As String = "SESTAMK-TEST-PAGE|" & printerName & "|" & DateTime.Now.ToString("yyyyMMddHHmmss") & "|STATUS:SUCCESS"
                Using qrBmp = GenerateQRCodeBmp(qrContent, qrSize)
                    If qrBmp IsNot Nothing Then
                        Dim qrX As Integer = (pageWidth - qrSize) \ 2
                        g.DrawImage(qrBmp, New Rectangle(qrX, yPos, qrSize, qrSize))
                        yPos += qrSize + 4
                        g.DrawString("(امسح الرمز للتأكد من استجابة الماسح الضوئي)", fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 15), sfCenter)
                        yPos += 17
                    End If
                End Using

                DrawDashedLine(g, yPos, pageWidth)
                yPos += 7
            End If

            ' ══════════════════════════════════════════════════════
            ' 8. تنبيه درج النقدية
            ' ══════════════════════════════════════════════════════
            If openDrawer Then
                g.DrawString("[✔] تم إرسال نبضة فتح درج النقدية بنجاح", fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 16), sfCenter)
                yPos += 18
                DrawDashedLine(g, yPos, pageWidth)
                yPos += 7
            End If

            ' ══════════════════════════════════════════════════════
            ' 9. التذييل ورسالة النجاح (Footer)
            ' ══════════════════════════════════════════════════════
            DrawDoubleLine(g, yPos, pageWidth)
            yPos += 6
            g.DrawString("✔ تم اختبار كافة وظائف الطابعة بنجاح", fontBold, Brushes.Black, New RectangleF(0, yPos, pageWidth, 18), sfCenter)
            yPos += 18
            g.DrawString("ALL PRINTER TESTS COMPLETED", fontBannerSub, Brushes.Black, New RectangleF(0, yPos, pageWidth, 14), sfCenter)
            yPos += 15
            g.DrawString("نظام سيستمك لإدارة الأنشطة التجارية والمطاعم", fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 15), sfCenter)
            yPos += 14
            g.DrawString("www.sestamk.com", fontSmall, Brushes.Black, New RectangleF(0, yPos, pageWidth, 14), sfCenter)
            yPos += 22
        End Using

        Return yPos
    End Function

    ''' <summary>
    ''' توليد صورة Bitmap لورقة الاختبار للمعاينة أو الحفظ
    ''' </summary>
    Public Function RenderTestReceiptToBitmap(printerName As String,
                                             Optional paperSize As String = "80mm",
                                             Optional printLogo As Boolean = True,
                                             Optional printBarcode As Boolean = True,
                                             Optional openDrawer As Boolean = False) As Bitmap
        Dim is80mm As Boolean = Not String.Equals(paperSize, "58mm", StringComparison.OrdinalIgnoreCase)
        Dim targetWidth As Integer = If(is80mm, 285, 195)

        Dim tempBmp As New Bitmap(targetWidth, 2000)
        Dim finalH As Integer = 0
        Using g As Graphics = Graphics.FromImage(tempBmp)
            g.Clear(Color.White)
            finalH = DrawTestReceiptContent(g, targetWidth, is80mm, printerName, printLogo, printBarcode, openDrawer)
        End Using
        tempBmp.Dispose()

        Dim resultBmp As New Bitmap(targetWidth, finalH + 10)
        Using g As Graphics = Graphics.FromImage(resultBmp)
            g.Clear(Color.White)
            DrawTestReceiptContent(g, targetWidth, is80mm, printerName, printLogo, printBarcode, openDrawer)
        End Using

        Return resultBmp
    End Function

    ' ═════════════════════════════════════════════════════════════════
    ' دوال مساعدة في الرسم
    ' ═════════════════════════════════════════════════════════════════
    Private Sub DrawKeyValue(g As Graphics, label As String, value As String,
                             fontLabel As Font, fontValue As Font,
                             sfRight As StringFormat, sfLeft As StringFormat,
                             y As Integer, w As Integer, is80mm As Boolean)
        ' [FIX] تحسين التوزيع النسبي وزيادة ارتفاع السطر
        Dim splitX As Integer = If(is80mm, CInt(w * 0.48), CInt(w * 0.50))
        Dim rowH As Integer = 19
        g.DrawString(label, fontLabel, Brushes.Black, New RectangleF(splitX, y, w - splitX, rowH), sfRight)
        g.DrawString(value, fontValue, Brushes.Black, New RectangleF(0, y, splitX, rowH), sfLeft)
    End Sub

    Private Sub DrawItemRow(g As Graphics, itemName As String, qty As String, price As String, total As String,
                            fontName As Font, fontNumbers As Font,
                            sfRight As StringFormat, sfCenter As StringFormat, sfLeft As StringFormat,
                            y As Integer, colNameX As Integer, colNameW As Integer, colQtyW As Integer, colPriceW As Integer, colTotalW As Integer)
        g.DrawString(itemName, fontName, Brushes.Black, New RectangleF(colNameX, y, colNameW, 16), sfRight)
        g.DrawString(qty, fontNumbers, Brushes.Black, New RectangleF(colTotalW + colPriceW, y, colQtyW, 16), sfCenter)
        g.DrawString(price, fontNumbers, Brushes.Black, New RectangleF(colTotalW, y, colPriceW, 16), sfCenter)
        g.DrawString(total, fontNumbers, Brushes.Black, New RectangleF(0, y, colTotalW, 16), sfLeft)
    End Sub

    Private Sub DrawDoubleLine(g As Graphics, y As Integer, w As Integer)
        Using p As New Pen(Color.Black, 1)
            g.DrawLine(p, 2, y, w - 2, y)
            g.DrawLine(p, 2, y + 2, w - 2, y + 2)
        End Using
    End Sub

    Private Sub DrawSolidLine(g As Graphics, y As Integer, w As Integer, Optional thickness As Single = 1.0!)
        Using p As New Pen(Color.Black, thickness)
            g.DrawLine(p, 2, y, w - 2, y)
        End Using
    End Sub

    Private Sub DrawDashedLine(g As Graphics, y As Integer, w As Integer)
        Using p As New Pen(Color.Black, 1) With {.DashStyle = DashStyle.Dash}
            g.DrawLine(p, 2, y, w - 2, y)
        End Using
    End Sub

    Private Function TruncateText(txt As String, maxChars As Integer) As String
        If String.IsNullOrEmpty(txt) Then Return ""
        If txt.Length <= maxChars Then Return txt
        Return txt.Substring(0, maxChars - 2) & ".."
    End Function

    Private Function GenerateQRCodeBmp(content As String, size As Integer) As Bitmap
        Try
            Dim writer As New ZXing.BarcodeWriter With {
                .Format = ZXing.BarcodeFormat.QR_CODE,
                .Options = New ZXing.QrCode.QrCodeEncodingOptions With {
                    .Height = size,
                    .Width = size,
                    .Margin = 1,
                    .CharacterSet = "UTF-8"
                }
            }
            Return writer.Write(content)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GenerateBarcode128(content As String, width As Integer, height As Integer) As Bitmap
        Try
            Dim writer As New ZXing.BarcodeWriter With {
                .Format = ZXing.BarcodeFormat.CODE_128,
                .Options = New ZXing.Common.EncodingOptions With {
                    .Height = height,
                    .Width = width,
                    .Margin = 1
                }
            }
            Return writer.Write(content)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module
