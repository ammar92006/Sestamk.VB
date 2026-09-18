Imports System.IO.Ports

Module PrinterManager

    ' ──────────────────────────────────────────────────────────────────
    ' [FIX جوهري] هذا الموديول كان مكسوراً:
    '   - StartPrinter/StopPrinter يشيران إلى barcodePort وهو متغير في
    '     ScannerModule (خلط بين منفذ الطابعة والسكانر).
    '   - استخدام CallByName للوصول لدوال الفورمات (بطيء، بدون فحص وقت
    '     التصميم، يُخفي أخطاء كثيرة في التشغيل).
    '   - فقدان Dispose للمنفذ ← قفل COM Port دائم لو تعطل البرنامج.
    '
    ' الموديول حالياً غير مُستدعى من أي مكان في المشروع (تم التحقق بـ Grep)،
    ' لكن نُبقيه ونُصلحه ليكون آمناً لو استُخدم لاحقاً.
    ' ──────────────────────────────────────────────────────────────────

    Public WithEvents PrinterPort As SerialPort
    Private buffer As String = ""
    Private ReadOnly _lock As New Object()

    Public Sub StartPrinter()
        SyncLock _lock
            Try
                Dim currentportPrinter = SettingsManager.GetSetting("Current_port_scanner")

                If String.IsNullOrWhiteSpace(currentportPrinter) Then Exit Sub

                If PrinterPort Is Nothing Then
                    PrinterPort = New SerialPort(currentportPrinter, 9600, Parity.None, 8, StopBits.One)
                    AddHandler PrinterPort.DataReceived, AddressOf PrinterPort_DataReceived
                End If

                If Not PrinterPort.IsOpen Then
                    PrinterPort.Open()
                End If
            Catch ex As Exception
                Debug.WriteLine("PrinterManager.StartPrinter error: " & ex.Message)
            End Try
        End SyncLock
    End Sub

    Private Sub PrinterPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            buffer &= PrinterPort.ReadExisting()

            ' عند نهاية المسح (الجهاز يضيف Enter)
            If buffer.Contains(vbCr) OrElse buffer.Contains(vbLf) Then
                Dim code As String = buffer.Trim()
                buffer = ""

                ' [FIX] استبدال CallByName بـ TypeOf/DirectCast - أسرع وآمن
                For Each frm As Form In Application.OpenForms.Cast(Of Form)().ToList()
                    Try
                        If TypeOf frm Is Login Then
                            frm.Invoke(Sub() DirectCast(frm, Login).FillFromScanner(code))
                            'ElseIf TypeOf frm Is Sales Then
                            'frm.Invoke(Sub() DirectCast(frm, Sales).ProcessBarcodeData(code))
                        ElseIf TypeOf frm Is ProductUnits Then
                            frm.Invoke(Sub() DirectCast(frm, ProductUnits).scannerPort_DataReceived(code))
                        End If
                    Catch
                        ' الفورم قد يكون في طور الإغلاق - تجاهل
                    End Try
                Next
            End If
        Catch
        End Try
    End Sub

    Public Sub StopPrinter()
        SyncLock _lock
            Try
                If PrinterPort IsNot Nothing Then
                    Try
                        RemoveHandler PrinterPort.DataReceived, AddressOf PrinterPort_DataReceived
                    Catch
                    End Try
                    If PrinterPort.IsOpen Then
                        Try
                            PrinterPort.DiscardInBuffer()
                        Catch
                        End Try
                        PrinterPort.Close()
                    End If
                    PrinterPort.Dispose()
                    PrinterPort = Nothing
                End If
                buffer = ""
            Catch
            End Try
        End SyncLock
    End Sub
End Module
