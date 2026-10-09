Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports Newtonsoft.Json

Public Class AppSettings
    Public Property ScannerPort As String
    Public Property ScannerEnabled As Boolean
End Class

Public Module SettingsManager

    Private ReadOnly _cache As New System.Collections.Concurrent.ConcurrentDictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    Private _cacheLoaded As Boolean = False
    Private ReadOnly _cacheLock As New Object()
    Private _tableChecked As Boolean = False

    ''' <summary>تحميل جميع الإعدادات دفعة واحدة في الذاكرة لتسريع التطبيق</summary>
    Public Sub LoadAllSettings()
        Try
            SyncLock _cacheLock
                Using cn As New SqlConnection(ConnectionString)
                    cn.Open()
                    If Not _tableChecked Then
                        EnsureSettingsTable(cn)
                        _tableChecked = True
                    End If
                    Using cmd As New SqlCommand("SELECT SettingKey, SettingValue FROM AppSettings", cn)
                        Using dr As SqlDataReader = cmd.ExecuteReader()
                            While dr.Read()
                                Dim k = dr("SettingKey").ToString()
                                Dim v = If(dr.IsDBNull(dr.GetOrdinal("SettingValue")), "", dr("SettingValue").ToString())
                                _cache(k) = v
                            End While
                        End Using
                    End Using
                End Using
                _cacheLoaded = True
            End SyncLock
        Catch ex As Exception
            Logger.LogError("AppSettings.vb:42", ex)
        End Try
    End Sub

    Private Sub EnsureSettingsTable(cn As SqlConnection)
        Try
            Using cmd As New SqlCommand("
                IF OBJECT_ID('AppSettings', 'U') IS NULL
                BEGIN
                    CREATE TABLE AppSettings (
                        SettingKey NVARCHAR(100) NOT NULL PRIMARY KEY,
                        SettingValue NVARCHAR(MAX) NULL
                    );
                END", cn)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Logger.LogError("AppSettings.vb:59", ex)
        End Try
    End Sub

    ' 🟢 قراءة الإعداد (مسترجع فوراً من الذاكرة Cache)
    Public Function GetSetting(key As String) As String
        If String.IsNullOrEmpty(key) Then Return Nothing

        If _cache.ContainsKey(key) Then
            Return _cache(key)
        End If

        If Not _cacheLoaded Then
            LoadAllSettings()
            If _cache.ContainsKey(key) Then
                Return _cache(key)
            End If
        End If

        Try
            Using cn As New SqlConnection(ConnectionString)
                cn.Open()
                If Not _tableChecked Then
                    EnsureSettingsTable(cn)
                    _tableChecked = True
                End If
                Using cmd As New SqlCommand("SELECT SettingValue FROM AppSettings WHERE SettingKey = @key", cn)
                    cmd.Parameters.AddWithValue("@key", key)
                    Dim result = cmd.ExecuteScalar()
                    Dim val = If(result IsNot Nothing AndAlso Not Convert.IsDBNull(result), result.ToString(), Nothing)
                    If val IsNot Nothing Then
                        _cache(key) = val
                    End If
                    Return val
                End Using
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

    Public Function GetStringSetting(key As String, Optional defaultValue As String = "") As String
        Return GetSettingOrDefault(key, defaultValue)
    End Function

    ' 🟢 قراءة إعداد بمفتاحين بديلين (Key1 ثم Key2)
    Public Function GetSettingDual(key1 As String, key2 As String, Optional defaultValue As String = "") As String
        Dim v = GetSetting(key1)
        If Not String.IsNullOrEmpty(v) Then Return v
        v = GetSetting(key2)
        If Not String.IsNullOrEmpty(v) Then Return v
        Return defaultValue
    End Function

    ' 🟢 قراءة إعداد منطقي (Boolean)
    Public Function GetBoolSetting(key As String, defaultValue As Boolean) As Boolean
        Dim v = GetSetting(key)
        If String.IsNullOrEmpty(v) Then Return defaultValue
        Dim b As Boolean
        If Boolean.TryParse(v, b) Then Return b
        Return v.Trim().ToLower() = "true" OrElse v.Trim() = "1"
    End Function

    ' 🟢 قراءة إعداد منطقي بمفتاحين بديلين
    Public Function GetBoolSettingDual(key1 As String, key2 As String, defaultValue As Boolean) As Boolean
        Dim v = GetSettingDual(key1, key2, "")
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

    ' 🟡 حفظ أو تحديث الإعداد في الذاكرة وفي قاعدة البيانات
    Public Sub SaveSetting(key As String, value As String)
        If String.IsNullOrEmpty(key) Then Return
        Dim safeVal = If(value, "")
        _cache(key) = safeVal

        Task.Run(Sub()
                     Try
                         Using cn As New SqlConnection(ConnectionString)
                             cn.Open()
                             If Not _tableChecked Then
                                 EnsureSettingsTable(cn)
                                 _tableChecked = True
                             End If
                             Using cmd As New SqlCommand("
                                 IF EXISTS (SELECT 1 FROM AppSettings WHERE SettingKey = @key)
                                     UPDATE AppSettings SET SettingValue = @value WHERE SettingKey = @key
                                 ELSE
                                     INSERT INTO AppSettings (SettingKey, SettingValue) VALUES (@key, @value)", cn)
                                 cmd.Parameters.AddWithValue("@key", key)
                                 cmd.Parameters.AddWithValue("@value", safeVal)
                                 cmd.ExecuteNonQuery()
                             End Using
                         End Using
                     Catch ex As Exception
                         Logger.LogError("AppSettings.vb:170", ex)
                     End Try
                 End Sub)
    End Sub

    ' 🟡 حفظ الإعداد بمفتاحين متطابقين لمزامنة التوافق
    Public Sub SaveSettingDual(key1 As String, key2 As String, value As String)
        SaveSetting(key1, value)
        If Not String.Equals(key1, key2, StringComparison.OrdinalIgnoreCase) Then
            SaveSetting(key2, value)
        End If
    End Sub
    ''' <summary>إغلاق منفذ الباركود بهدوء (بدون رسائل). يُفضّل استخدام ScannerModule.StopScanner.</summary>
    Public Sub CloseBarcodePort(portName As String)
        Try
            If Not String.IsNullOrWhiteSpace(portName) Then
                Using barcodePort As New SerialPort(portName)
                    If barcodePort.IsOpen Then barcodePort.Close()
                End Using
            End If
        Catch ex As Exception
            'Debug.WriteLine("CloseBarcodePort: " & ex.Message)
            Logger.LogError("AppSettings.vb:191", ex)
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
                SmartMessageBox.Show($"تم غلق البورت {portName} بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                SmartMessageBox.Show($"البورت {portName} غير مستخدم حالياً.", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            SmartMessageBox.Show("خطأ أثناء غلق البورت: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Module
