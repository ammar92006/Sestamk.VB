
Imports System.IO.Ports
Imports System.Linq

Module ScannerModule
    Public WithEvents barcodePort As SerialPort
    Private buffer As String = ""

    Public Sub StartScanner()
        Try
            buffer = ""

            ' احترام مفتاح التفعيل: لو الاسكنر معطّل لا نفتح المنفذ
            If Not SettingsManager.GetBoolSetting(SettingsKeys.ScannerEnabled, True) Then Exit Sub

            Dim currentport = SettingsManager.GetSetting(SettingsKeys.ScannerPort)
            If String.IsNullOrWhiteSpace(currentport) Then Exit Sub

            ' قراءة الإعدادات المتقدمة (مع قيم افتراضية آمنة)
            Dim baud As Integer = CInt(Val(SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerBaudRate, "9600")))
            If baud <= 0 Then baud = 9600
            Dim dataBits As Integer = CInt(Val(SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerDataBits, "8")))
            If dataBits < 5 OrElse dataBits > 8 Then dataBits = 8

            Dim par As Parity = Parity.None
            [Enum].TryParse(SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerParity, "None"), True, par)
            Dim sBits As StopBits = StopBits.One
            [Enum].TryParse(SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerStopBits, "One"), True, sBits)

            If barcodePort Is Nothing Then
                barcodePort = New SerialPort(currentport, baud, par, dataBits, sBits)
                AddHandler barcodePort.DataReceived, AddressOf barcodePort_DataReceived
                barcodePort.Open()
            ElseIf Not barcodePort.IsOpen Then
                barcodePort.Open()
            End If

            barcodePort.DiscardInBuffer()
        Catch ex As Exception
            ' بدون رسالة مزعجة — تُسجّل فقط ليكمل البرنامج عمله بهدوء
            Debug.WriteLine("StartScanner: " & ex.Message)
        End Try
    End Sub


    Private Sub barcodePort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            buffer = barcodePort.ReadExisting()


            If buffer.Contains(vbCr) Or buffer.Contains(vbLf) Then
                Dim code As String = buffer.Trim()
                buffer = ""


                Dim activeFrm As Form = Form.ActiveForm

                If activeFrm IsNot Nothing Then
                    Select Case activeFrm.Name
                        Case "Login"
                            activeFrm.Invoke(Sub()
                                                 CallByName(activeFrm, "FillFromScanner", CallType.Method, code)
                                             End Sub)
                        Case "Sales", "Sales_Returns", "Products", "Stock", "Purchases", "Purchases_Returns"
                            activeFrm.Invoke(Sub()
                                                 CallByName(activeFrm, "ProcessBarcodeData", CallType.Method, code)
                                             End Sub)
                        Case "ProductUnits", "add_new_product"
                            activeFrm.Invoke(Sub()
                                                 CallByName(activeFrm, "scannerPort_DataReceived", CallType.Method, code)
                                             End Sub)
                        Case "Reports"
                            activeFrm.Invoke(Sub()
                                                 CallByName(activeFrm, "scannerInvoice_DataReceived", CallType.Method, code)
                                             End Sub)
                    End Select
                End If
            End If
        Catch ex As Exception
        Finally
            buffer = ""
            barcodePort.DiscardInBuffer()
        End Try
    End Sub

    Public Sub StopScanner()
        Try
            If barcodePort IsNot Nothing AndAlso barcodePort.IsOpen Then
                barcodePort.DiscardInBuffer()
                barcodePort.Close()
            End If

            buffer = ""
        Catch __logEx As Exception
            Logger.LogError("ScannerModule.vb:94", __logEx)
        End Try
    End Sub

End Module
