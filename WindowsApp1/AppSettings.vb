Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports DevExpress.XtraPrinting.Native.WebClientUIControl
Imports Newtonsoft.Json

Public Class AppSettings
    Public Property ScannerPort As String
    Public Property ScannerEnabled As Boolean
End Class

Public Module SettingsManager

    ' 🟢 قراءة الإعداد
    Public Function GetSetting(key As String) As String
        Try
            Using cn As New SqlConnection(ConnectionString)
                cn.Open()
                Dim cmd As New SqlCommand("SELECT SettingValue FROM AppSettings WHERE SettingKey = @key", cn)
                cmd.Parameters.AddWithValue("@key", key)
                Dim result = cmd.ExecuteScalar()
                Return If(result IsNot Nothing, result.ToString(), Nothing)
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ' 🟢 قراءة الإعداد مع قيمة افتراضية لو غير موجود أو فارغ
    Public Function GetSettingOrDefault(key As String, defaultValue As String) As String
        Dim v = GetSetting(key)
        Return If(String.IsNullOrEmpty(v), defaultValue, v)
    End Function

    ' 🟢 قراءة إعداد منطقي (Boolean)
    Public Function GetBoolSetting(key As String, defaultValue As Boolean) As Boolean
        Dim v = GetSetting(key)
        If String.IsNullOrEmpty(v) Then Return defaultValue
        Dim b As Boolean
        If Boolean.TryParse(v, b) Then Return b
        Return v.Trim().ToLower() = "true" OrElse v.Trim() = "1"
    End Function

    ' 🟢 قراءة إعداد رقمي (Integer)
    Public Function GetIntSetting(key As String, defaultValue As Integer) As Integer
        Dim v = GetSetting(key)
        Dim n As Integer
        If Not String.IsNullOrEmpty(v) AndAlso Integer.TryParse(v, n) Then Return n
        Return defaultValue
    End Function

    ' 🟡 حفظ أو تحديث الإعداد
    Public Sub SaveSetting(key As String, value As String)
        Using cn As New SqlConnection(ConnectionString)
            cn.Open()
            Dim cmd As New SqlCommand("
                IF EXISTS (SELECT 1 FROM AppSettings WHERE SettingKey = @key)
                    UPDATE AppSettings SET SettingValue = @value WHERE SettingKey = @key
                ELSE
                    INSERT INTO AppSettings (SettingKey, SettingValue) VALUES (@key, @value)", cn)
            cmd.Parameters.AddWithValue("@key", key)
            cmd.Parameters.AddWithValue("@value", If(value, ""))
            cmd.ExecuteNonQuery()
        End Using
    End Sub
    Public Sub CloseBarcodePort(portName As String)
        Try
            ' التأكد أن الاسم موجود
            If Not String.IsNullOrWhiteSpace(portName) Then
                ' إنشاء كائن SerialPort مؤقت بالاسم
                Using barcodePort As New SerialPort(portName)
                    ' إذا كان البورت مفتوح بالفعل، يغلقه
                    If barcodePort.IsOpen Then
                        barcodePort.Close()
                        MessageBox.Show("تم غلق منفذ الباركود " & portName, "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End If
        Catch ex As UnauthorizedAccessException
            MessageBox.Show("البورت مستخدم من برنامج آخر: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء غلق منفذ الباركود: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' دالة تتحقق إذا كان البورت شغال (مفتوح) وتعطي معلومات دقيقة
    Public Function IsPortBusy(portName As String) As Boolean
        Try
            ' التأكد أن الاسم موجود
            If String.IsNullOrWhiteSpace(portName) Then Return False

            ' استخدام WMI للتحقق من كل البورتات المتصلة بالويندوز
            Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_SerialPort")
            For Each port As ManagementObject In searcher.Get()
                If port("DeviceID").ToString().ToUpper() = portName.ToUpper() Then
                    ' إذا وجدنا البورت، نتحقق إذا مفتوح
                    Using testPort As New SerialPort(portName)
                        Try
                            testPort.Open()
                            testPort.Close()
                            Return False ' غير مستخدم حالياً
                        Catch ex As UnauthorizedAccessException
                            Return True ' البورت مستخدم من برنامج آخر
                        End Try
                    End Using
                End If
            Next
            ' إذا البورت غير موجود ضمن المنافذ المتاحة
            Return False
        Catch
            Return False
        End Try
    End Function

    ' دالة لإغلاق البورت إذا شغال
    Public Sub ClosePortIfOpen(portName As String)
        Try
            If IsPortBusy(portName) Then
                Using port As New SerialPort(portName)
                    If port.IsOpen Then
                        port.Close()
                    End If
                End Using
                MessageBox.Show($"تم غلق البورت {portName} بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show($"البورت {portName} غير مستخدم حالياً.", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء غلق البورت: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Module
