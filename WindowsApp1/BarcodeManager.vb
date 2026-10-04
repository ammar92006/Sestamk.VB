Imports System.IO.Ports

Public Module BarcodeManager
    Private WithEvents serial As SerialPort
    Public Event BarcodeReceived(ByVal data As String)

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return serial IsNot Nothing AndAlso serial.IsOpen
        End Get
    End Property

    ' 🔹 فتح المنفذ مرة واحدة فقط
    Public Function OpenPort(portName As String) As Boolean
        Try
            If IsConnected Then
                Return True
            End If

            serial = New SerialPort(portName, 9600, Parity.None, 8, StopBits.One)
            serial.Open()
            Return True

        Catch ex As Exception
            SmartMessageBox.Show("⚠️ خطأ في فتح المنفذ: " & ex.Message, "Barcode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' 🔹 غلق المنفذ
    Public Sub ClosePort()
        Try
            If serial IsNot Nothing AndAlso serial.IsOpen Then
                serial.Close()
            End If
        Catch __logEx As Exception
            Logger.LogError("BarcodeManager.vb:36", __logEx)
        End Try
    End Sub

    ' 🔹 استقبال البيانات من السكنر
    Private Sub serial_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serial.DataReceived
        Try
            Dim data As String = serial.ReadExisting().Trim()
            If data <> "" Then
                RaiseEvent BarcodeReceived(data)
            End If
        Catch __logEx As Exception
            Logger.LogError("BarcodeManager.vb:48", __logEx)
        End Try
    End Sub
End Module
