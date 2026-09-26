Imports System.Drawing
Imports System.IO
Imports System.Text
Imports ZXing
Imports ZXing.QrCode

Public Module QRCodeHelper

    ''' <summary>
    ''' بناء ترميز TLV (Tag-Length-Value) المعتمد في الفوترة الإلكترونية
    ''' </summary>
    Public Function BuildZatcaTlvBase64(sellerName As String, vatNumber As String, invoiceDateTime As DateTime, totalAmount As Decimal, vatAmount As Decimal) As String
        Try
            Using ms As New MemoryStream()
                WriteTlvTag(ms, 1, sellerName)
                WriteTlvTag(ms, 2, vatNumber)
                WriteTlvTag(ms, 3, invoiceDateTime.ToString("yyyy-MM-ddTHH:mm:ss"))
                WriteTlvTag(ms, 4, totalAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture))
                WriteTlvTag(ms, 5, vatAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture))

                Return Convert.ToBase64String(ms.ToArray())
            End Using
        Catch ex As Exception
            Return sellerName & " | " & invoiceDateTime.ToString("yyyy-MM-dd HH:mm") & " | " & totalAmount.ToString("N2")
        End Try
    End Function

    Private Sub WriteTlvTag(ms As MemoryStream, tagNumber As Byte, value As String)
        If String.IsNullOrEmpty(value) Then value = ""
        Dim valBytes = Encoding.UTF8.GetBytes(value)
        ms.WriteByte(tagNumber)
        ms.WriteByte(CByte(valBytes.Length))
        ms.Write(valBytes, 0, valBytes.Length)
    End Sub

    ''' <summary>
    ''' توليد صورة Bitmap لرمز الاستجابة السريعة QR Code
    ''' </summary>
    Public Function GenerateQRCode(content As String, Optional width As Integer = 150, Optional height As Integer = 150) As Bitmap
        Try
            If String.IsNullOrWhiteSpace(content) Then Return Nothing

            Dim writer As New BarcodeWriter With {
                .Format = BarcodeFormat.QR_CODE,
                .Options = New QrCodeEncodingOptions With {
                    .Height = height,
                    .Width = width,
                    .Margin = 1,
                    .CharacterSet = "UTF-8"
                }
            }

            Return writer.Write(content)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' توليد صورة Bitmap لباركود خطي أحادي الأبعاد 1D (Code 128)
    ''' </summary>
    Public Function GenerateBarcode1D(content As String, Optional width As Integer = 200, Optional height As Integer = 50) As Bitmap
        Try
            If String.IsNullOrWhiteSpace(content) Then Return Nothing

            Dim writer As New BarcodeWriter With {
                .Format = BarcodeFormat.CODE_128,
                .Options = New ZXing.Common.EncodingOptions With {
                    .Height = height,
                    .Width = width,
                    .Margin = 2,
                    .PureBarcode = False
                }
            }

            Return writer.Write(content)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module
