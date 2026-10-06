Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports System.Text.Json
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports WindowsApp1.Services

''' <summary>
''' وحدة إدارة وتكامل خدمة الواتساب المتقدمة (Sestamk WhatsApp Integration Hub).
''' تدعم الإرسال المزدوج:
'''   1. الإرسال المباشر المجاني عبر رابط wa.me وتطبيق WhatsApp Desktop الرسمي بدون أي تكلفة أو سيرفرات.
'''   2. الإرسال الآلي التلقائي في الخلفية عبر سيرفر API في حال تفعيله في الإعدادات، مع تراجع تلقائي ذكي.
''' </summary>
Public Class WhatsAppAPI

    Private Shared ReadOnly client As New HttpClient() With {
        .Timeout = TimeSpan.FromSeconds(8)
    }

    ''' <summary>
    ''' تنظيف وتنسيق رقم الهاتف بالصيغة الدولية القياسية (E.164 / WhatsApp Format).
    ''' </summary>
    Public Shared Function SanitizePhoneNumber(rawPhone As String) As String
        If String.IsNullOrWhiteSpace(rawPhone) Then Return String.Empty

        ' الاحتفاظ بالأرقام فقط
        Dim sb As New StringBuilder()
        For Each ch In rawPhone
            If Char.IsDigit(ch) Then
                sb.Append(ch)
            End If
        Next
        Dim digits = sb.ToString()

        If String.IsNullOrEmpty(digits) Then Return String.Empty

        ' 1. إزالة الأصفار البادئة إن كانت بصيغة 0020
        If digits.StartsWith("00") Then
            digits = digits.Substring(2)
        End If

        ' 2. أرقام مصر (تبدأ بـ 010 أو 011 أو 012 أو 015)
        If digits.Length = 11 AndAlso digits.StartsWith("01") Then
            Return "20" & digits.Substring(1)
        ElseIf digits.Length = 10 AndAlso (digits.StartsWith("10") OrElse digits.StartsWith("11") OrElse digits.StartsWith("12") OrElse digits.StartsWith("15")) Then
            Return "20" & digits
        End If

        ' 3. أرقام السعودية (تبدأ بـ 05)
        If digits.Length = 10 AndAlso digits.StartsWith("05") Then
            Return "966" & digits.Substring(1)
        ElseIf digits.Length = 9 AndAlso digits.StartsWith("5") Then
            Return "966" & digits
        End If

        Return digits
    End Function

    ''' <summary>
    ''' فتح تطبيق واتساب لسطح المكتب أو المتصفح مباشرة بالرقم والرسالة المجهزة مسبقاً (مباشر ومجاني 100%)
    ''' </summary>
    Public Shared Sub OpenDirectWhatsApp(phone As String, message As String)
        Try
            Dim cleanPhone = SanitizePhoneNumber(phone)
            Dim encodedMsg = Uri.EscapeDataString(message)
            Dim url = If(Not String.IsNullOrEmpty(cleanPhone),
                         $"https://wa.me/{cleanPhone}?text={encodedMsg}",
                         $"https://wa.me/?text={encodedMsg}")

            Dim psi As New ProcessStartInfo(url) With {
                .UseShellExecute = True
            }
            Process.Start(psi)
        Catch ex As Exception
            Logger.LogError("WhatsAppAPI.OpenDirectWhatsApp", ex)
            SmartMessageBox.Show("تعذر فتح تطبيق الواتساب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ''' <summary>
    ''' إرسال رسالة نصية للعميل مع الاستراتيجية المزدوجة (تلقائي بالخلفية إن وُجد، أو مباشر بواتساب)
    ''' </summary>
    Public Shared Async Function SendText(phone As String, message As String, Optional preferDirect As Boolean = False) As Task(Of Boolean)
        Dim cleanPhone = SanitizePhoneNumber(phone)

        If preferDirect OrElse Not WhatsAppService.IsEnabled Then
            OpenDirectWhatsApp(cleanPhone, message)
            Return True
        End If

        ' محاولة الإرسال عبر سيرفر الواتساب أولاً
        Try
            Dim result = Await WhatsAppService.SendTextAsync(cleanPhone, message)
            If result.Success Then
                Try
                    Notify.Toast("تم إرسال رسالة الواتساب بنجاح ✅", Notify.ToastType.Success)
                Catch
                End Try
                Return True
            Else
                ' التراجع التلقائي لفتح المحادثة مباشرة
                OpenDirectWhatsApp(cleanPhone, message)
                Return True
            End If
        Catch ex As Exception
            Logger.LogError("WhatsAppAPI.SendText", ex)
            OpenDirectWhatsApp(cleanPhone, message)
            Return True
        End Try
    End Function

    ' =========================================================
    ' قوالب الرسائل الجاهزة والمزخرفة بالإيموجي (Templates)
    ' =========================================================

    ''' <summary>
    ''' بناء رسالة الفاتورة الإلكترونية المنسقة للواتساب
    ''' </summary>
    Public Shared Function FormatInvoiceMessage(inv As InvoiceModel, Optional customerName As String = "عميلنا العزيز", Optional customShopName As String = "", Optional customShopPhone As String = "") As String
        Dim shopName = If(Not String.IsNullOrWhiteSpace(customShopName), customShopName, SettingsManager.GetSettingDual(SettingsKeys.ShopName, SettingsKeys.StoreName, "سستمك"))
        Dim shopPhone = If(Not String.IsNullOrWhiteSpace(customShopPhone), customShopPhone, SettingsManager.GetSettingDual(SettingsKeys.ShopPhone, SettingsKeys.StorePhone, ""))
        Dim footerText = SettingsManager.GetSettingDual(SettingsKeys.FooterText, SettingsKeys.ReceiptFooter, "شكراً لزيارتكم ونتشرف بخدمتكم دائماً! ❤️")

        Dim orderTypeDesc As String = "مبيعات"
        Select Case inv.OrderType
            Case 1 : orderTypeDesc = "تيك أوي (Takeaway) 🛍️"
            Case 2 : orderTypeDesc = "صالة (Dine-In) 🍽️"
            Case 3 : orderTypeDesc = "توصيل دليفري (Delivery) 🛵"
        End Select

        Dim sb As New StringBuilder()
        sb.AppendLine("🧾 *فاتورة مبيعات إلكترونية*")
        sb.AppendLine($"🏬 *{shopName}*")
        sb.AppendLine("━━━━━━━━━━━━━━━━━━")
        sb.AppendLine($"📄 رقم الفاتورة: *#{inv.InvoiceNumber}*")
        sb.AppendLine($"🕒 التاريخ: {inv.InvoiceDate:yyyy/MM/dd - hh:mm tt}")
        If Not String.IsNullOrWhiteSpace(customerName) AndAlso customerName <> "عميل نقدي" Then
            sb.AppendLine($"👤 العميل: *{customerName}*")
        End If
        sb.AppendLine($"📍 نوع الطلب: {orderTypeDesc}")
        sb.AppendLine("━━━━━━━━━━━━━━━━━━")
        sb.AppendLine("*الأصناف المطلوبة:*")

        If inv.Details IsNot Nothing AndAlso inv.Details.Count > 0 Then
            For Each item In inv.Details
                Dim sizeStr = If(Not String.IsNullOrWhiteSpace(item.SizeName) AndAlso item.SizeName <> "عادي", $" ({item.SizeName})", "")
                sb.AppendLine($"• {item.Quantity}× {item.ProductName}{sizeStr} ⟵ *{item.TotalPrice:N2} ج.م*")
                If Not String.IsNullOrWhiteSpace(item.AddonsText) AndAlso item.AddonsText <> "-" Then
                    sb.AppendLine($"  ↳ إضافة: {item.AddonsText}")
                End If
            Next
        Else
            sb.AppendLine("• إجمالي أصناف الفاتورة")
        End If

        sb.AppendLine("━━━━━━━━━━━━━━━━━━")
        If inv.DiscountAmount > 0 Then
            sb.AppendLine($"💰 المجموع: {inv.TotalBeforeDiscount:N2} ج.م")
            sb.AppendLine($"🏷️ الخصم: -{inv.DiscountAmount:N2} ج.م")
        End If
        If inv.TaxAmount > 0 Then
            sb.AppendLine($"🏛️ الضريبة: +{inv.TaxAmount:N2} ج.م")
        End If
        If inv.DeliveryFee > 0 Then
            sb.AppendLine($"🛵 التوصيل: +{inv.DeliveryFee:N2} ج.م")
        End If
        If inv.DineInServiceFee > 0 Then
            sb.AppendLine($"🍽️ خدمة الصالة: +{inv.DineInServiceFee:N2} ج.م")
        End If

        sb.AppendLine($"💵 *صافي المطلوب: {inv.NetTotal:N2} ج.م*")
        sb.AppendLine($"💳 طريقة الدفع: {If(Not String.IsNullOrWhiteSpace(inv.PaymentType), inv.PaymentType, "نقدي")}")
        If inv.RemainingAmount > 0 Then
            sb.AppendLine($"⏳ المتبقي كآجل: *{inv.RemainingAmount:N2} ج.م*")
        End If
        sb.AppendLine("━━━━━━━━━━━━━━━━━━")
        sb.AppendLine(footerText)
        If Not String.IsNullOrWhiteSpace(shopPhone) Then
            sb.AppendLine($"📞 للتواصل والطلبات: {shopPhone}")
        End If

        Return sb.ToString()
    End Function

    ''' <summary>
    ''' بناء رسالة ملخص تقفيل الوردية للمالك عبر واتساب
    ''' </summary>
    Public Shared Function FormatShiftZReportMessage(shiftNumber As String, cashierName As String, openDate As DateTime, closeDate As DateTime,
                                                     openingCash As Decimal, totalSales As Decimal, cashSales As Decimal, visaSales As Decimal,
                                                     walletSales As Decimal, totalExpenses As Decimal, expectedCash As Decimal, actualCash As Decimal, diff As Decimal) As String
        Dim shopName = SettingsManager.GetSettingDual(SettingsKeys.ShopName, SettingsKeys.StoreName, "سستمك")
        Dim diffText = If(diff = 0, "مطابق تماماً (0.00 ج.م) ✓", If(diff > 0, $"+{diff:N2} ج.م (زيادة)", $"{diff:N2} ج.م (عجز ⚠️)"))

        Dim sb As New StringBuilder()
        sb.AppendLine("📊 *تقرير إغلاق الوردية اليومي (Z-REPORT)*")
        sb.AppendLine($"🏬 *{shopName}*")
        sb.AppendLine("━━━━━━━━━━━━━━━━━━")
        sb.AppendLine($"🔢 وردية رقم: *#{shiftNumber}*")
        sb.AppendLine($"👤 الكاشير المسؤول: *{cashierName}*")
        sb.AppendLine($"🕒 فتحت: {openDate:yyyy/MM/dd hh:mm tt}")
        sb.AppendLine($"🕒 أغلقت: {closeDate:yyyy/MM/dd hh:mm tt}")
        sb.AppendLine("━━━━━━━━━━━━━━━━━━")
        sb.AppendLine($"💰 *إجمالي المبيعات:* *{totalSales:N2} ج.م*")
        sb.AppendLine($"💵 مبيعات نقدي (كاش): {cashSales:N2} ج.م")
        If visaSales > 0 Then sb.AppendLine($"💳 مبيعات فيزا / شبكة: {visaSales:N2} ج.م")
        If walletSales > 0 Then sb.AppendLine($"📱 مبيعات محفظة / إنستا: {walletSales:N2} ج.م")
        sb.AppendLine("━━━━━━━━━━━━━━━━━━")
        sb.AppendLine($"💼 عهدة البداية: {openingCash:N2} ج.م")
        If totalExpenses > 0 Then sb.AppendLine($"📉 المصروفات: -{totalExpenses:N2} ج.م")
        sb.AppendLine($"💵 النقدية المتوقعة بالدرج: *{expectedCash:N2} ج.م*")
        sb.AppendLine($"🔍 المبلغ المجرود فعلياً: *{actualCash:N2} ج.م*")
        sb.AppendLine($"⚖️ الفارق: *{diffText}*")
        sb.AppendLine("━━━━━━━━━━━━━━━━━━")
        sb.AppendLine("تم الإرسال آلياً عبر نظام سستمك لنقاط البيع ✅")

        Return sb.ToString()
    End Function

    ''' <summary>
    ''' إرسال ملف/صورة عبر وسيط الواتساب
    ''' </summary>
    Public Shared Async Function SendMedia(phone As String, filePath As String, Optional caption As String = "") As Task(Of Boolean)
        If Not File.Exists(filePath) Then Return False
        Dim cleanPhone = SanitizePhoneNumber(phone)

        If Not WhatsAppService.IsEnabled Then
            OpenDirectWhatsApp(cleanPhone, caption)
            Return True
        End If

        Try
            Dim res = Await WhatsAppService.SendMediaAsync(cleanPhone, filePath, caption)
            Return res.Success
        Catch ex As Exception
            Logger.LogError("WhatsAppAPI.SendMedia", ex)
            OpenDirectWhatsApp(cleanPhone, caption)
            Return True
        End Try
    End Function

End Class
