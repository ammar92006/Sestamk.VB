Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

''' <summary>
''' مساعد الطابعة الحرارية - يدعم ESC/POS وطباعة الصور (اللوجو)
''' </summary>
Public Class RawPrinterHelper

    '══════════════════════════════════════════════════════
    ' Win32 API للطباعة الخام (RAW)
    '══════════════════════════════════════════════════════
    <DllImport("winspool.drv", EntryPoint:="OpenPrinterA", SetLastError:=True,
               CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function OpenPrinter(szPrinter As String, ByRef hPrinter As IntPtr, pd As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", EntryPoint:="ClosePrinter", SetLastError:=True,
               CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ClosePrinter(hPrinter As IntPtr) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Public Structure DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.drv", EntryPoint:="StartDocPrinterA", SetLastError:=True,
               CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartDocPrinter(hPrinter As IntPtr, level As Integer, ByRef di As DOCINFOA) As Boolean
    End Function

    <DllImport("winspool.drv", EntryPoint:="EndDocPrinter", SetLastError:=True,
               CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndDocPrinter(hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", EntryPoint:="StartPagePrinter", SetLastError:=True,
               CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartPagePrinter(hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", EntryPoint:="EndPagePrinter", SetLastError:=True,
               CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndPagePrinter(hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.drv", EntryPoint:="WritePrinter", SetLastError:=True,
               CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function WritePrinter(hPrinter As IntPtr, data As Byte(), size As Integer,
                                        ByRef written As Integer) As Boolean
    End Function

    '══════════════════════════════════════════════════════
    ' إرسال بيانات خام (RAW bytes) للطابعة
    '══════════════════════════════════════════════════════
    Public Shared Function SendBytesToPrinter(printerName As String, bytes() As Byte) As Boolean
        Dim hPrinter As IntPtr = IntPtr.Zero
        If Not OpenPrinter(printerName, hPrinter, IntPtr.Zero) Then Return False

        Dim di As New DOCINFOA With {
            .pDocName = "Thermal Receipt",
            .pDataType = "RAW"
        }

        If Not StartDocPrinter(hPrinter, 1, di) Then
            ClosePrinter(hPrinter)
            Return False
        End If

        StartPagePrinter(hPrinter)

        Dim written As Integer = 0
        WritePrinter(hPrinter, bytes, bytes.Length, written)

        EndPagePrinter(hPrinter)
        EndDocPrinter(hPrinter)
        ClosePrinter(hPrinter)
        Return True
    End Function

    '══════════════════════════════════════════════════════
    ' إرسال نص ASCII للطابعة
    '══════════════════════════════════════════════════════
    Public Shared Function SendStringToPrinter(printerName As String, text As String) As Boolean
        Dim bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(text)
        Return SendBytesToPrinter(printerName, bytes)
    End Function

    '══════════════════════════════════════════════════════
    ' طباعة اللوجو (صورة) على الطابعة الحرارية
    ' باستخدام GDI+ PrintDocument (أوسع توافقاً مع الطابعات الحرارية)
    '══════════════════════════════════════════════════════
    Public Shared Sub PrintLogoOnThermal(printerName As String, logoPath As String,
                                         Optional logoWidth As Integer = 200,
                                         Optional logoHeight As Integer = 80)
        Try
            If Not File.Exists(logoPath) Then Exit Sub

            Dim logo As Image = Image.FromFile(logoPath)
            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = printerName

            ' إضافة معالج الطباعة
            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         ' حساب موضع اللوجو في المنتصف
                                         Dim x As Integer = CInt((e.PageBounds.Width - logoWidth) / 2)
                                         If x < 0 Then x = 0
                                         Dim logoRect As New Rectangle(x, 5, logoWidth, logoHeight)
                                         e.Graphics.DrawImage(logo, logoRect)
                                         e.HasMorePages = False
                                     End Sub

            pd.Print()
            logo.Dispose()

        Catch ex As Exception
            ' تجاهل أخطاء اللوجو دون إيقاف الطباعة
            Debug.WriteLine("خطأ طباعة اللوجو: " & ex.Message)
        End Try
    End Sub

    '══════════════════════════════════════════════════════
    ' تحويل صورة اللوجو إلى ESC/POS bitmap data
    ' (للطابعات التي تدعم ESC/POS فقط)
    '══════════════════════════════════════════════════════
    Public Shared Function ConvertImageToEscPos(imgPath As String, Optional maxWidth As Integer = 384) As Byte()
        Try
            If Not File.Exists(imgPath) Then Return New Byte() {}

            Using originalImg As Image = Image.FromFile(imgPath)
                ' حساب الحجم المناسب للطابعة الحرارية
                Dim ratio As Double = CDbl(originalImg.Height) / CDbl(originalImg.Width)
                Dim newWidth As Integer = Math.Min(originalImg.Width, maxWidth)
                ' المحاذاة لأقرب 8 بكسل (مطلوب لـ ESC/POS)
                newWidth = CInt(Math.Floor(newWidth / 8.0)) * 8
                Dim newHeight As Integer = CInt(newWidth * ratio)

                Using bmp As New Bitmap(newWidth, newHeight)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.Clear(Color.White)
                        g.DrawImage(originalImg, 0, 0, newWidth, newHeight)
                    End Using

                    Return BitmapToEscPosBytes(bmp)
                End Using
            End Using

        Catch ex As Exception
            Debug.WriteLine("خطأ تحويل اللوجو: " & ex.Message)
            Return New Byte() {}
        End Try
    End Function

    '══════════════════════════════════════════════════════
    ' تحويل Bitmap إلى أوامر ESC/POS GS v 0
    '══════════════════════════════════════════════════════
    Private Shared Function BitmapToEscPosBytes(bmp As Bitmap) As Byte()
        Using ms As New MemoryStream()
            Dim widthBytes As Integer = CInt(Math.Ceiling(bmp.Width / 8.0))

            ' ESC/POS: GS v 0 (Raster bit-image)
            ms.WriteByte(&H1D)  ' GS
            ms.WriteByte(&H76)  ' v
            ms.WriteByte(&H30)  ' 0
            ms.WriteByte(&H0)   ' m = normal size

            ' xL, xH: عرض البيانات بالبايت
            ms.WriteByte(CByte(widthBytes And &HFF))
            ms.WriteByte(CByte((widthBytes >> 8) And &HFF))

            ' yL, yH: ارتفاع الصورة بالبكسل
            ms.WriteByte(CByte(bmp.Height And &HFF))
            ms.WriteByte(CByte((bmp.Height >> 8) And &HFF))

            ' بيانات الصورة
            For y As Integer = 0 To bmp.Height - 1
                For xByte As Integer = 0 To widthBytes - 1
                    Dim b As Byte = 0
                    For bit As Integer = 0 To 7
                        Dim x As Integer = xByte * 8 + bit
                        If x < bmp.Width Then
                            Dim pixel As Color = bmp.GetPixel(x, y)
                            ' تحويل للأبيض والأسود: إذا كان الـ pixel داكن = bit = 1
                            Dim brightness As Integer = CInt(pixel.R) * 299 + CInt(pixel.G) * 587 + CInt(pixel.B) * 114
                            If brightness < 128000 Then  ' < 128 * 1000
                                b = b Or CByte(1 << (7 - bit))
                            End If
                        End If
                    Next
                    ms.WriteByte(b)
                Next
            Next

            Return ms.ToArray()
        End Using
    End Function

    '══════════════════════════════════════════════════════
    ' طباعة لوجو عبر ESC/POS مباشرة (للطابعات المتوافقة)
    '══════════════════════════════════════════════════════
    Public Shared Function PrintLogoEscPos(printerName As String, logoPath As String) As Boolean
        Try
            Dim logoBytes() As Byte = ConvertImageToEscPos(logoPath)
            If logoBytes.Length = 0 Then Return False

            ' أمر التوسيط قبل اللوجو
            Dim centerCmd() As Byte = {&H1B, &H61, &H1}  ' ESC a 1 (center)
            Dim allBytes(centerCmd.Length + logoBytes.Length - 1) As Byte
            Array.Copy(centerCmd, allBytes, centerCmd.Length)
            Array.Copy(logoBytes, 0, allBytes, centerCmd.Length, logoBytes.Length)

            Return SendBytesToPrinter(printerName, allBytes)
        Catch ex As Exception
            Debug.WriteLine("خطأ ESC/POS Logo: " & ex.Message)
            Return False
        End Try
    End Function

    '══════════════════════════════════════════════════════
    ' الدالة الرئيسية: طباعة اللوجو مع النص على الطابعة الحرارية
    ' تحاول ESC/POS أولاً، وإذا فشلت تستخدم GDI+
    '══════════════════════════════════════════════════════
    Public Shared Sub PrintReceiptWithLogo(printerName As String,
                                            logoPath As String,
                                            receiptText As String,
                                            Optional useEscPos As Boolean = True)
        Try
            If useEscPos Then
                ' ——— طريقة ESC/POS ———
                Dim allData As New System.IO.MemoryStream()

                ' 1) تهيئة الطابعة
                Dim initCmd() As Byte = {&H1B, &H40}  ' ESC @
                allData.Write(initCmd, 0, initCmd.Length)

                ' 2) اللوجو إذا وجد
                If Not String.IsNullOrEmpty(logoPath) AndAlso File.Exists(logoPath) Then
                    Dim centerCmd() As Byte = {&H1B, &H61, &H1}
                    allData.Write(centerCmd, 0, centerCmd.Length)

                    Dim logoBytes() As Byte = ConvertImageToEscPos(logoPath)
                    If logoBytes.Length > 0 Then
                        allData.Write(logoBytes, 0, logoBytes.Length)
                        ' سطر فارغ بعد اللوجو
                        allData.WriteByte(10)
                    End If
                End If

                ' 3) النص
                If Not String.IsNullOrEmpty(receiptText) Then
                    Dim textBytes() As Byte = System.Text.Encoding.GetEncoding(1256).GetBytes(receiptText)
                    allData.Write(textBytes, 0, textBytes.Length)
                End If

                ' 4) قص الورق
                Dim cutCmd() As Byte = {&H1D, &H56, &H41, &H5}  ' GS V A (partial cut)
                allData.Write(cutCmd, 0, cutCmd.Length)

                SendBytesToPrinter(printerName, allData.ToArray())
            Else
                ' ——— طريقة GDI+ (PrintDocument) ———
                PrintUsingGDI(printerName, logoPath, receiptText)
            End If

        Catch ex As Exception
            MessageBox.Show("خطأ في الطباعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '══════════════════════════════════════════════════════
    ' طباعة عبر GDI+ (PrintDocument) - بديل لـ ESC/POS
    '══════════════════════════════════════════════════════
    Private Shared Sub PrintUsingGDI(printerName As String, logoPath As String, receiptText As String)
        Dim logo As Image = Nothing
        Try
            If Not String.IsNullOrEmpty(logoPath) AndAlso File.Exists(logoPath) Then
                logo = Image.FromFile(logoPath)
            End If

            Dim pd As New PrintDocument()
            pd.PrinterSettings.PrinterName = printerName
            pd.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5)

            AddHandler pd.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                         Dim yPos As Integer = 5
                                         Dim pageWidth As Integer = e.PageBounds.Width

                                         ' رسم اللوجو
                                         If logo IsNot Nothing Then
                                             Dim logoW As Integer = Math.Min(200, pageWidth - 10)
                                             Dim logoH As Integer = CInt(logo.Height * (CDbl(logoW) / logo.Width))
                                             Dim logoX As Integer = CInt((pageWidth - logoW) / 2)
                                             e.Graphics.DrawImage(logo, New Rectangle(logoX, yPos, logoW, logoH))
                                             yPos += logoH + 5
                                         End If

                                         ' رسم النص
                                         If Not String.IsNullOrEmpty(receiptText) Then
                                             Dim fnt As New Font("Arial", 10, FontStyle.Bold)
                                             Dim sf As New StringFormat()
                                             sf.Alignment = StringAlignment.Center
                                             sf.FormatFlags = StringFormatFlags.DirectionRightToLeft
                                             Dim rect As New RectangleF(0, yPos, pageWidth, fnt.Height + 5)
                                             Dim lines() As String = receiptText.Split(vbLf)
                                             For Each line In lines
                                                 e.Graphics.DrawString(line.TrimEnd(vbCr), fnt, Brushes.Black, rect, sf)
                                                 yPos += CInt(fnt.GetHeight(e.Graphics)) + 2
                                                 rect.Y = yPos
                                             Next
                                             fnt.Dispose()
                                             sf.Dispose()
                                         End If

                                         e.HasMorePages = False
                                     End Sub

            pd.Print()

        Catch ex As Exception
            Debug.WriteLine("GDI Print Error: " & ex.Message)
        Finally
            If logo IsNot Nothing Then logo.Dispose()
        End Try
    End Sub

End Class
