Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات قارئ الباركود التسلسلي واختبار الاتصال
    ''' </summary>
    Public Class UCScannerSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Private WithEvents serial As SerialPort
        Private _scannerTesting As Boolean = False

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCScannerSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadPorts()
            LoadSettings()
        End Sub

        Private Sub LoadPorts()
            Try
                ComboBoxPorts.Items.Clear()
                ComboBoxPorts.Items.AddRange(SerialPort.GetPortNames())
            Catch ex As Exception
                Debug.WriteLine("LoadPorts error: " & ex.Message)
            End Try
        End Sub

        Private Sub btnRefreshPorts_Click(sender As Object, e As EventArgs) Handles btnRefreshPorts.Click
            LoadPorts()
            lblStatus.Text = "حالة الاسكنر: تم تحديث المنافذ ✅"
            lblStatus.ForeColor = Color.LightGreen
        End Sub

        Public Sub LoadSettings()
            Try
                Dim savedPort = SettingsManager.GetSettingDual(SettingsKeys.ScannerPort, "Scanner_COMPort", "")
                If Not String.IsNullOrEmpty(savedPort) Then ComboBoxPorts.Text = savedPort

                cmbBaudRate.Text = SettingsManager.GetSettingDual(SettingsKeys.ScannerBaudRate, "Scanner_BaudRate", "9600")
                cmbDataBits.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerDataBits, "8")
                cmbParity.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerParity, "None")
                cmbStopBits.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerStopBits, "One")
                CheckBoxEnabled.Checked = SettingsManager.GetBoolSettingDual(SettingsKeys.ScannerEnabled, "Scanner_Enabled", True)
            Catch ex As Exception
                Debug.WriteLine("LoadScannerSettings error: " & ex.Message)
            End Try
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Dim portName As String = ComboBoxPorts.Text.Trim()
            If String.IsNullOrEmpty(portName) Then
                MessageBox.Show("يرجى اختيار المنفذ أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                SettingsManager.SaveSettingDual(SettingsKeys.ScannerPort, "Scanner_COMPort", portName)
                SettingsManager.SaveSettingDual(SettingsKeys.ScannerBaudRate, "Scanner_BaudRate", cmbBaudRate.Text)
                SettingsManager.SaveSetting(SettingsKeys.ScannerDataBits, cmbDataBits.Text)
                SettingsManager.SaveSetting(SettingsKeys.ScannerParity, cmbParity.Text)
                SettingsManager.SaveSetting(SettingsKeys.ScannerStopBits, cmbStopBits.Text)
                SettingsManager.SaveSettingDual(SettingsKeys.ScannerEnabled, "Scanner_Enabled", CheckBoxEnabled.Checked.ToString().ToLower())

                lblStatus.Text = "حالة الاسكنر: تم الحفظ بنجاح ✅"
                lblStatus.ForeColor = Color.LightGreen

                Try
                    Notify.Toast("تم حفظ إعدادات الاسكنر بنجاح ✅", Notify.ToastType.Success)
                Catch
                    MessageBox.Show("✅ تم حفظ إعدادات الاسكنر بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Catch ex As Exception
                MessageBox.Show("خطأ في حفظ إعدادات الاسكنر: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
            If _scannerTesting Then
                StopScanTest()
                Return
            End If

            If String.IsNullOrEmpty(ComboBoxPorts.Text) Then
                MessageBox.Show("يرجى اختيار المنفذ أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                ' تحرير المنفذ لو الاسكنر الرئيسي شغّال عليه
                ScannerModule.StopScanner()

                Dim baud As Integer = CInt(SettingsManager.GetSettingOrDefault(SettingsKeys.ScannerBaudRate, cmbBaudRate.Text))
                Dim dataBits As Integer = CInt(cmbDataBits.Text)
                Dim par As Parity = CType([Enum].Parse(GetType(Parity), cmbParity.Text), Parity)
                Dim sBits As StopBits = CType([Enum].Parse(GetType(StopBits), cmbStopBits.Text), StopBits)

                serial = New SerialPort(ComboBoxPorts.Text, baud, par, dataBits, sBits) With {
                    .Handshake = Handshake.None
                }
                serial.Open()

                _scannerTesting = True
                txtScanTestResult.Clear()
                txtScanTestResult.AppendText("🟢 التجربة جارية — امسح أي باركود الآن..." & vbCrLf)
                btnTestConnection.Text = "⏹ إيقاف التجربة"
                lblStatus.Text = "حالة الاسكنر: 🟢 جاري التجربة"
                lblStatus.ForeColor = Color.LightGreen
            Catch ex As Exception
                MessageBox.Show("تعذّر فتح المنفذ للتجربة: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub StopScanTest()
            Try
                If serial IsNot Nothing AndAlso serial.IsOpen Then serial.Close()
                If serial IsNot Nothing Then serial.Dispose()
            Catch
            End Try
            serial = Nothing
            _scannerTesting = False
            btnTestConnection.Text = "🔌 اختبار الاتصال"
            lblStatus.Text = "حالة الاسكنر: ⏹ تم إيقاف التجربة"
            lblStatus.ForeColor = Color.Gold
        End Sub

        Private Sub btnCloseConnection_Click(sender As Object, e As EventArgs) Handles btnCloseConnection.Click
            If _scannerTesting Then StopScanTest()
            ScannerModule.StopScanner()
            Dim portName As String = SettingsManager.GetSetting(SettingsKeys.ScannerPort)
            If Not String.IsNullOrEmpty(portName) Then
                SettingsManager.CloseBarcodePort(portName)
            End If
            lblStatus.Text = "حالة الاسكنر: ⏹ تم غلق منفذ الباركود"
            lblStatus.ForeColor = Color.Gold
        End Sub

        Private Sub serial_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serial.DataReceived
            Try
                Dim data As String = serial.ReadExisting().Trim()
                If String.IsNullOrEmpty(data) Then Return
                If Me.IsHandleCreated Then
                    Me.BeginInvoke(Sub()
                                       txtScanTestResult.AppendText("✅ " & DateTime.Now.ToString("HH:mm:ss") & "  →  " & data & vbCrLf)
                                   End Sub)
                End If
            Catch ex As Exception
                Debug.WriteLine("serial_DataReceived error: " & ex.Message)
            End Try
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If MessageBox.Show("هل أنت متأكد من استعادة القيم الافتراضية لإعدادات الاسكنر؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                cmbBaudRate.Text = "9600"
                cmbDataBits.Text = "8"
                cmbParity.Text = "None"
                cmbStopBits.Text = "One"
                CheckBoxEnabled.Checked = True
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            If _scannerTesting Then StopScanTest()
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
