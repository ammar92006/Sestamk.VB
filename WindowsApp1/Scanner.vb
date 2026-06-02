Imports System.IO.Ports
Imports System.Management

Public Class ScannerManager
    Implements IDisposable

    ' ===============================
    ' 🔹 الخصائص الأساسية
    ' ===============================
    Public Property PortName As String = ""
    Public Property BaudRate As Integer = 9600
    Public ReadOnly Property IsOpen As Boolean
        Get
            Return _port IsNot Nothing AndAlso _port.IsOpen
        End Get
    End Property

    Private _port As SerialPort
    Private _disposed As Boolean = False

    ' 🔹 حدث عند استقبال باركود جديد
    Public Event BarcodeReceived(ByVal barcode As String)

    ' ===============================
    ' 🔹 جلب المنافذ المتاحة مع الاسم الودي
    ' ===============================
    Public Function GetAvailablePorts() As List(Of String)
        Dim result As New List(Of String)
        Dim ports = SerialPort.GetPortNames()

        Try
            ' نحاول نجيب الاسم الودي من الـ WMI
            Using searcher As New ManagementObjectSearcher("SELECT Name FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'")
                For Each mo As ManagementObject In searcher.Get()
                    Dim nameStr As String = mo("Name").ToString()
                    Dim startIdx = nameStr.IndexOf("(COM")
                    If startIdx >= 0 Then
                        Dim endIdx = nameStr.IndexOf(")", startIdx)
                        If endIdx > startIdx Then
                            Dim comName = nameStr.Substring(startIdx + 1, endIdx - startIdx - 1) ' COM3 مثلاً
                            If ports.Contains(comName) Then
                                result.Add(nameStr)
                                ports = ports.Where(Function(p) p <> comName).ToArray() ' نشيل اللي أضفناه
                            End If
                        End If
                    End If
                Next
            End Using
        Catch
            ' في حال فشل WMI نرجع الأسماء فقط
        End Try

        ' لو في منافذ ما اتضافتش نضيفها بالاسم العادي
        For Each p In ports
            If Not result.Any(Function(x) x.Contains(p)) Then
                result.Add(p)
            End If
        Next

        Return result
    End Function

    ' ===============================
    ' 🔹 فتح المنفذ
    ' ===============================
    Public Function OpenPort(Optional selectedFriendlyName As String = Nothing) As Boolean
        Try
            If IsOpen Then ClosePort()

            ' لو المستخدم اختار الاسم الودي "USB Serial Device (COM3)" نطلع منه COM3
            If Not String.IsNullOrEmpty(selectedFriendlyName) AndAlso selectedFriendlyName.Contains("(COM") Then
                Dim startIdx = selectedFriendlyName.IndexOf("(COM")
                Dim endIdx = selectedFriendlyName.IndexOf(")", startIdx)
                If startIdx >= 0 AndAlso endIdx > startIdx Then
                    PortName = selectedFriendlyName.Substring(startIdx + 1, endIdx - startIdx - 1)
                End If
            End If

            If String.IsNullOrEmpty(PortName) Then Throw New Exception("لم يتم تحديد المنفذ بعد.")

            _port = New SerialPort(PortName, BaudRate, Parity.None, 8, StopBits.One)
            _port.Handshake = Handshake.None
            _port.NewLine = vbCrLf
            AddHandler _port.DataReceived, AddressOf OnDataReceived
            _port.Open()

            Return True
        Catch ex As Exception
            Throw New Exception("فشل في فتح المنفذ: " & ex.Message)
        End Try
    End Function

    ' ===============================
    ' 🔹 إغلاق المنفذ
    ' ===============================
    Public Sub ClosePort()
        Try
            If _port IsNot Nothing AndAlso _port.IsOpen Then
                RemoveHandler _port.DataReceived, AddressOf OnDataReceived
                _port.DiscardInBuffer()
                _port.DiscardOutBuffer()
                _port.Close()
            End If
        Catch
        End Try
    End Sub

    ' ===============================
    ' 🔹 استقبال البيانات (الباركود)
    ' ===============================
    Private Sub OnDataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            If _port Is Nothing Then Return
            Dim data As String = ""
            Try
                data = _port.ReadLine().Trim()
            Catch
                data = _port.ReadExisting().Trim()
            End Try

            If Not String.IsNullOrEmpty(data) Then
                RaiseEvent BarcodeReceived(data)
            End If
        Catch
        End Try
    End Sub

    ' ===============================
    ' 🔹 Dispose
    ' ===============================
    Public Sub Dispose() Implements IDisposable.Dispose
        If _disposed Then Return
        _disposed = True
        Try
            ClosePort()
            If _port IsNot Nothing Then
                _port.Dispose()
                _port = Nothing
            End If
        Catch
        End Try
    End Sub
End Class
