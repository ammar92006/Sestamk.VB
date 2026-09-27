Imports System
Imports System.Drawing
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports WindowsApp1.Services

Namespace UC_Settings

    Public Class UCWhatsAppSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Private WithEvents _statusTimer As New System.Windows.Forms.Timer()
        Private _isRefreshing As Boolean = False

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Async Sub UCWhatsAppSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadSettings()

            _statusTimer.Interval = 4000
            _statusTimer.Start()

            Await RefreshStatusAsync()
        End Sub

        Public Sub LoadSettings()
            Try
                Dim mode = SettingsManager.GetSetting(SettingsKeys.WhatsAppMode)
                If String.Equals(mode, "Local", StringComparison.OrdinalIgnoreCase) Then
                    rdoModeLocal.Checked = True
                    rdoModeCloud.Checked = False
                Else
                    rdoModeCloud.Checked = True
                    rdoModeLocal.Checked = False
                End If

                txtServerUrl.Text = SettingsManager.GetSetting(SettingsKeys.WhatsAppServerUrl)
                If String.IsNullOrWhiteSpace(txtServerUrl.Text) Then
                    txtServerUrl.Text = "http://127.0.0.1:3000"
                End If

                txtApiSecret.Text = SettingsManager.GetSetting(SettingsKeys.WhatsAppApiSecret)
                If String.IsNullOrWhiteSpace(txtApiSecret.Text) Then
                    txtApiSecret.Text = "40ddff3e42dce8ecae15405ba523f572e526c673e0b40051a8d67aee1bdab190"
                End If

                tglAutoSend.Checked = SettingsManager.GetBoolSetting(SettingsKeys.WhatsAppAutoSendInvoice, False)

                Dim fmt = SettingsManager.GetSetting(SettingsKeys.WhatsAppInvoiceFormat)
                If String.Equals(fmt, "Image", StringComparison.OrdinalIgnoreCase) Then
                    rdoFormatImage.Checked = True
                ElseIf String.Equals(fmt, "PDF", StringComparison.OrdinalIgnoreCase) Then
                    rdoFormatPdf.Checked = True
                Else
                    rdoFormatText.Checked = True
                End If

                Dim welcome = SettingsManager.GetSetting(SettingsKeys.WhatsAppWelcomeTemplate)
                txtWelcomeTemplate.Text = If(String.IsNullOrWhiteSpace(welcome), "أهلاً بك في {ShopName}، يسعدنا دائماً خدمتكم وتقديم أفضل تجربة لكم!", welcome)

                Dim invTpl = SettingsManager.GetSetting(SettingsKeys.WhatsAppInvoiceTemplate)
                txtInvoiceTemplate.Text = If(String.IsNullOrWhiteSpace(invTpl), "مرحباً {CustomerName}، شكراً لتعاملكم مع {ShopName}. فاتورتكم رقم {InvoiceNo} بإجمالي {Total} ج.م. نتمنى لكم يوماً سعيداً!", invTpl)

            Catch ex As Exception
                MessageBox.Show("خطأ في قراءة إعدادات الواتساب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Async Sub _statusTimer_Tick(sender As Object, e As EventArgs) Handles _statusTimer.Tick
            If Not _isRefreshing AndAlso Me.Visible Then
                Await RefreshStatusAsync()
            End If
        End Sub

        Private Async Function RefreshStatusAsync() As Task
            If _isRefreshing Then Return
            _isRefreshing = True
            Try
                Dim res = Await WhatsAppService.HealthCheckAsync()
                If Not res.ok Then
                    SetStatusBadge("الخدمة غير متصلة 🔴", Color.FromArgb(239, 68, 68), "---")
                    picQRCode.Image = Nothing
                    Return
                End If

                Select Case res.status.ToUpperInvariant()
                    Case "CONNECTED"
                        SetStatusBadge("متصل بنجاح ✅", Color.FromArgb(34, 197, 94), If(String.IsNullOrEmpty(res.mePhone), "متصل", res.mePhone))
                        picQRCode.Image = Nothing
                        lblQrHint.Text = "الحساب متصل وجاهز لإرسال الرسائل والفواتير."

                    Case "QR_READY"
                        SetStatusBadge("في انتظار مسح الرمز ⏳", Color.FromArgb(234, 179, 8), "---")
                        lblQrHint.Text = "افتح واتساب > الأجهزة المرتبطة > امسح رمز الـ QR"
                        Await LoadQrCodeAsync()

                    Case "INITIALIZING"
                        SetStatusBadge("جارٍ تهيئة الجلسة... 🔄", Color.FromArgb(234, 179, 8), "---")

                    Case "DISCONNECTED"
                        SetStatusBadge("غير مقترن ❌", Color.FromArgb(239, 68, 68), "---")
                        picQRCode.Image = Nothing

                    Case Else
                        SetStatusBadge(res.status, Color.FromArgb(156, 163, 175), "---")
                End Select
            Catch ex As Exception
                SetStatusBadge("خطأ اتصال 🔴", Color.FromArgb(239, 68, 68), "---")
            Finally
                _isRefreshing = False
            End Try
        End Function

        Private Sub SetStatusBadge(text As String, color As Color, phone As String)
            If InvokeRequired Then
                Invoke(Sub() SetStatusBadge(text, color, phone))
                Return
            End If
            lblStatusBadge.Text = text
            lblStatusBadge.ForeColor = color
            lblConnectedPhone.Text = phone
        End Sub

        Private Async Function LoadQrCodeAsync() As Task
            Try
                Dim qrBase64 = Await WhatsAppService.GetQrBase64Async()
                If String.IsNullOrEmpty(qrBase64) Then Return

                Dim cleanBase64 = If(qrBase64.Contains(","), qrBase64.Split(","c)(1), qrBase64)
                Dim bytes = Convert.FromBase64String(cleanBase64)
                Using ms As New MemoryStream(bytes)
                    Dim img = Image.FromStream(ms)
                    If picQRCode.Image IsNot Nothing Then picQRCode.Image.Dispose()
                    picQRCode.Image = New Bitmap(img)
                End Using
            Catch ex As Exception
            End Try
        End Function

        Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
            btnConnect.Enabled = False
            Try
                SetStatusBadge("جارٍ فحص الاتصال...", Color.FromArgb(234, 179, 8), "---")
                Await RefreshStatusAsync()
            Finally
                btnConnect.Enabled = True
            End Try
        End Sub

        Private Async Sub btnResetSession_Click(sender As Object, e As EventArgs) Handles btnResetSession.Click
            If MessageBox.Show("هل أنت متأكد من فك ارتباط الحساب وإعادة تهيئة الجلسة؟ سيتطلب ذلك مسح رمز QR مجدداً.", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                btnResetSession.Enabled = False
                Try
                    Dim ok = Await WhatsAppService.ResetSessionAsync()
                    If ok Then
                        Try
                            Notify.Toast("تمت إعادة ضبط جلسة الواتساب بنجاح 🔓", Notify.ToastType.Info)
                        Catch
                            MessageBox.Show("تمت إعادة ضبط الجلسة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End Try
                        Await RefreshStatusAsync()
                    Else
                        MessageBox.Show("تعذّر إعادة ضبط الجلسة، تأكد من أن السيرفر يعمل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Finally
                    btnResetSession.Enabled = True
                End Try
            End If
        End Sub

        Private Sub btnPresetCloud_Click(sender As Object, e As EventArgs) Handles btnPresetCloud.Click
            rdoModeCloud.Checked = True
            rdoModeLocal.Checked = False
            txtServerUrl.Text = "https://wa.sestamk.com"
        End Sub

        Private Sub btnPresetLocal_Click(sender As Object, e As EventArgs) Handles btnPresetLocal.Click
            rdoModeLocal.Checked = True
            rdoModeCloud.Checked = False
            txtServerUrl.Text = "http://127.0.0.1:3000"
        End Sub

        Private Async Sub btnSendTest_Click(sender As Object, e As EventArgs) Handles btnSendTest.Click
            Dim phone = txtTestPhone.Text.Trim().Replace("+", "").Replace(" ", "")
            If String.IsNullOrEmpty(phone) Then
                MessageBox.Show("يرجى إدخال رقم هاتف المستلم (مع كود الدولة مثل 201012345678).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTestPhone.Focus()
                Return
            End If

            Dim msg = txtTestMsg.Text.Trim()
            If String.IsNullOrEmpty(msg) Then
                msg = "رسالة تجريبية لتأكيد عمل خدمة الواتساب بنجاح من نظام سيستمك لنقاط البيع ✅"
            End If

            btnSendTest.Enabled = False
            btnSendTest.Text = "جارٍ الإرسال..."
            Try
                Dim res = Await WhatsAppService.SendTextAsync(phone, msg)
                If res.success Then
                    Try
                        Notify.Toast("تم إرسال الرسالة التجريبية بنجاح 🚀", Notify.ToastType.Success)
                    Catch
                        MessageBox.Show("✅ تم إرسال الرسالة التجريبية بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                Else
                    MessageBox.Show("❌ فشل إرسال الرسالة:" & vbCrLf & res.error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Finally
                btnSendTest.Enabled = True
                btnSendTest.Text = "إرسال تجربة الآن 🚀"
            End Try
        End Sub

        Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                Dim mode = If(rdoModeLocal.Checked, "Local", "Cloud")
                SettingsManager.SaveSetting(SettingsKeys.WhatsAppMode, mode)
                SettingsManager.SaveSetting(SettingsKeys.WhatsAppServerUrl, txtServerUrl.Text.Trim())
                SettingsManager.SaveSetting(SettingsKeys.WhatsAppApiSecret, txtApiSecret.Text.Trim())
                SettingsManager.SaveSetting(SettingsKeys.WhatsAppAutoSendInvoice, tglAutoSend.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.WhatsAppEnabled, tglAutoSend.Checked.ToString().ToLower())

                Dim fmt = "Text"
                If rdoFormatImage.Checked Then fmt = "Image"
                If rdoFormatPdf.Checked Then fmt = "PDF"
                SettingsManager.SaveSetting(SettingsKeys.WhatsAppInvoiceFormat, fmt)

                SettingsManager.SaveSetting(SettingsKeys.WhatsAppWelcomeTemplate, txtWelcomeTemplate.Text.Trim())
                SettingsManager.SaveSetting(SettingsKeys.WhatsAppInvoiceTemplate, txtInvoiceTemplate.Text.Trim())

                Try
                    Notify.Toast("تم حفظ إعدادات الواتساب بنجاح ✅", Notify.ToastType.Success)
                Catch
                    MessageBox.Show("✅ تم حفظ إعدادات الواتساب بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

                Await RefreshStatusAsync()

            Catch ex As Exception
                MessageBox.Show("خطأ في حفظ إعدادات الواتساب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If MessageBox.Show("هل أنت متأكد من استعادة القيم الافتراضية لإعدادات الواتساب؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                rdoModeCloud.Checked = True
                rdoModeLocal.Checked = False
                txtServerUrl.Text = "http://127.0.0.1:3000"
                txtApiSecret.Text = "40ddff3e42dce8ecae15405ba523f572e526c673e0b40051a8d67aee1bdab190"
                tglAutoSend.Checked = False
                rdoFormatText.Checked = True
                txtWelcomeTemplate.Text = "أهلاً بك في {ShopName}، يسعدنا دائماً خدمتكم وتقديم أفضل تجربة لكم!"
                txtInvoiceTemplate.Text = "مرحباً {CustomerName}، شكراً لتعاملكم مع {ShopName}. فاتورتكم رقم {InvoiceNo} بإجمالي {Total} ج.م. نتمنى لكم يوماً سعيداً!"
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            _statusTimer.Stop()
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub

    End Class

End Namespace
