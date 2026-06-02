
Imports System.IO.Ports
Imports System.Linq

Module ScannerModule
    Public WithEvents barcodePort As SerialPort
    Private buffer As String = ""

    Public Sub StartScanner()
        Try
            buffer = ""

            Dim currentport = SettingsManager.GetSetting("Current_port_scanner")

            If barcodePort Is Nothing Then
                barcodePort = New SerialPort(currentport, 9600, Parity.None, 8, StopBits.One)
                AddHandler barcodePort.DataReceived, AddressOf barcodePort_DataReceived
                barcodePort.Open()
            ElseIf Not barcodePort.IsOpen Then
                barcodePort.Open()
            End If

            barcodePort.DiscardInBuffer()
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء تشغيل الاسكنر: " & ex.Message)
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
    'Private Sub barcodePort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
    '    Try
    '        buffer &= barcodePort.ReadExisting()

    '        ' لما يوصل نهاية المسح (عادة القارئ بيضيف Enter)
    '        If buffer.Contains(vbCr) Or buffer.Contains(vbLf) Then
    '            Dim code As String = buffer.Trim()
    '            buffer = ""

    '            ' نجيب الفورم النشط فقط
    '            Dim activeFrm As Form = Form.ActiveForm

    '            If activeFrm IsNot Nothing Then
    '                Select Case activeFrm.Name
    '                    Case "Login"
    '                        activeFrm.Invoke(Sub()
    '                                             CallByName(activeFrm, "FillFromScanner", CallType.Method, code)
    '                                         End Sub)
    '                    Case "Sales"
    '                        activeFrm.Invoke(Sub()
    '                                             CallByName(activeFrm, "ProcessBarcodeData", CallType.Method, code)
    '                                         End Sub)
    '                    Case "ProductUnits", "add_new_product"
    '                        activeFrm.Invoke(Sub()
    '                                             CallByName(activeFrm, "scannerPort_DataReceived", CallType.Method, code)
    '                                         End Sub)
    '                End Select
    '            End If
    '        End If
    '    Catch ex As Exception
    '        ' يمكن تسجيل الخطأ أو تجاهله
    '    End Try
    'End Sub

    'Private Sub barcodePort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
    '    Try
    '        buffer &= barcodePort.ReadExisting()

    '        ' لما يوصل نهاية المسح (القارئ بيضيف Enter)
    '        If buffer.Contains(vbCr) Or buffer.Contains(vbLf) Then

    '            Dim code As String = buffer.Trim()
    '            buffer = ""

    '            ' 🔥 نجيب الفورم المفتوحة حسب الاسم (نفس فكرتك بس بدون ActiveForm)
    '            Dim frmName As String = ""
    '            Dim activeFrm As Form = Nothing

    '            For Each frm As Form In Application.OpenForms
    '                If frm.Name = "Login" Or frm.Name = "Sales" Or frm.Name = "ProductUnits" Or frm.Name = "add_new_product" Then
    '                    activeFrm = frm
    '                    frmName = frm.Name
    '                    Exit For
    '                End If
    '            Next

    '            If activeFrm IsNot Nothing Then
    '                activeFrm.Invoke(Sub()
    '                                     CallByName(activeFrm, GetMethodName(frmName), CallType.Method, code)
    '                                 End Sub)
    '            End If

    '        End If

    '    Catch ex As Exception
    '    End Try
    'End Sub

    Public Sub StopScanner()
        Try
            If barcodePort IsNot Nothing AndAlso barcodePort.IsOpen Then
                barcodePort.DiscardInBuffer()
                barcodePort.Close()
            End If

            buffer = ""
        Catch
        End Try
    End Sub

End Module
