Imports System.Diagnostics
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class FormActivation

    Private _hwid As String = ""
    Private _pollTimer As Windows.Forms.Timer

    Private Sub FormActivation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' 1. قراءة بصمة الجهاز الفريدة (HWID)
            _hwid = HardwareFingerprint.GetCurrent()
            lblHWID.Text = _hwid

            ' 2. توليد رمز الاستجابة السريعة (QR Code) ليسهل مسحه بالكاميرا
            picQRCode.Image = QRCodeHelper.GenerateQRCode(_hwid, 200, 200)

            ' 3. فحص الكاش المحلي في حال وجود سيريال محفوظ مسبقاً
            Dim cache = LicenseCache.Load()
            If cache IsNot Nothing Then
                Dim savedSerial = Convert.ToString(cache("saved_serial"))
                If Not String.IsNullOrWhiteSpace(savedSerial) Then
                    txtLicense.Text = savedSerial.Trim().ToUpperInvariant()
                End If

                Dim status = Convert.ToString(cache("status")).ToLowerInvariant()
                Dim expiresAtStr = Convert.ToString(cache("expires_at"))
                Dim expiresAt As DateTime
                Dim isExpired = (DateTime.TryParse(expiresAtStr, expiresAt) AndAlso expiresAt.Date < DateTime.Today)

                If (status = "active" OrElse status = "grace_period") AndAlso Not isExpired Then
                    UpdateStatusBadge("مفعل (نشط)", isSuccess:=True)
                    lblStatusMessage.Text = "الترخيص مفعل حالياً حتى تاريخ: " & expiresAt.ToString("yyyy-MM-dd")
                    lblStatusMessage.ForeColor = Color.FromArgb(52, 211, 153)
                ElseIf isExpired Then
                    UpdateStatusBadge("منتهي الصلاحية", isSuccess:=False, isWarning:=True)
                    lblStatusMessage.Text = "⚠️ انتهت صلاحية هذا الترخيص في: " & expiresAt.ToString("yyyy-MM-dd") & " - يرجى التجديد"
                    lblStatusMessage.ForeColor = Color.FromArgb(248, 113, 113)
                Else
                    UpdateStatusBadge("يلزم التفعيل", isSuccess:=False)
                End If
            Else
                UpdateStatusBadge("يلزم التفعيل", isSuccess:=False)
            End If

            ' 4. بدء فحص دوري تلقائي صامت في الخلفية في حال قام الأدمن بتفعيل الجهاز
            StartBackgroundHwidPolling()

        Catch ex As Exception
            MessageBox.Show("حدث خطأ في تحميل بيانات بصمة الجهاز: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' تفعيل البرنامج باستخدام مفتاح الترخيص المدخل
    ''' </summary>
    Private Async Sub btn_Staff_Click(sender As Object, e As EventArgs) Handles btn_Staff.Click
        Dim serial = txtLicense.Text.Trim()
        If String.IsNullOrWhiteSpace(serial) Then
            lblStatusMessage.Text = "⚠️ يرجى إدخال أو لصق كود التفعيل أولاً."
            lblStatusMessage.ForeColor = Color.FromArgb(248, 113, 113)
            txtLicense.Focus()
            Return
        End If

        btn_Staff.Enabled = False
        btnCheckOnline.Enabled = False
        btnPaste.Enabled = False
        progressActivation.Visible = True
        lblStatusMessage.Text = "جارٍ الاتصال بالسيرفر والتحقق من كود التفعيل..."
        lblStatusMessage.ForeColor = Color.FromArgb(147, 197, 253)

        Try
            Dim result = Await LicenseBootstrapper.ActivateAsync(serial)
            If result.IsValid Then
                StopBackgroundHwidPolling()
                UpdateStatusBadge("تم التفعيل", isSuccess:=True)
                lblStatusMessage.Text = "✅ تم تفعيل البرنامج بنجاح! جاري الدخول للنظام..."
                lblStatusMessage.ForeColor = Color.FromArgb(52, 211, 153)

                Try
                    Notify.Toast(result.Message, Notify.ToastType.Success)
                Catch
                End Try

                Await Task.Delay(800)
                DialogResult = DialogResult.OK
                Close()
            Else
                Dim msg = If(String.IsNullOrWhiteSpace(result.Message), "مفتاح التفعيل غير صالح.", result.Message)
                lblStatusMessage.Text = "❌ " & msg
                lblStatusMessage.ForeColor = Color.FromArgb(248, 113, 113)
                MessageBox.Show(msg, "فشل التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblStatusMessage.Text = "❌ خطأ في الاتصال: " & ex.Message
            lblStatusMessage.ForeColor = Color.FromArgb(248, 113, 113)
            MessageBox.Show("تعذر إتمام عملية التفعيل: " & ex.Message, "خطأ تفعيل", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btn_Staff.Enabled = True
            btnCheckOnline.Enabled = True
            btnPaste.Enabled = True
            progressActivation.Visible = False
        End Try
    End Sub

    ''' <summary>
    ''' فحص مباشر لحالة الترخيص عبر السيرفر دون كتابة يدوي (HWID / Serial)
    ''' </summary>
    Private Async Sub btnCheckOnline_Click(sender As Object, e As EventArgs) Handles btnCheckOnline.Click
        btnCheckOnline.Enabled = False
        btn_Staff.Enabled = False
        progressActivation.Visible = True
        lblStatusMessage.Text = "جارٍ فحص حالة التفعيل المباشر من خادم التراخيص..."
        lblStatusMessage.ForeColor = Color.FromArgb(147, 197, 253)

        Try
            ' 1. التحقق المباشر عبر بصمة الجهاز المسجلة مسبقاً في لوحة التحكم (HWID Zero-Touch)
            Dim hwidResult = Await LicenseBootstrapper.CheckByHwidAsync()
            If hwidResult.IsValid Then
                StopBackgroundHwidPolling()
                Dim newSerial = Convert.ToString(hwidResult.Payload("saved_serial"))
                If Not String.IsNullOrWhiteSpace(newSerial) Then
                    txtLicense.Text = newSerial.Trim().ToUpperInvariant()
                End If
                UpdateStatusBadge("مفعل أونلاين", isSuccess:=True)
                lblStatusMessage.Text = "✅ تم استرداد وتفعيل الترخيص من السيرفر بنجاح!"
                lblStatusMessage.ForeColor = Color.FromArgb(52, 211, 153)

                Try
                    Notify.Toast("تم تفعيل الجهاز أونلاين بنجاح ✅", Notify.ToastType.Success)
                Catch
                End Try

                Await Task.Delay(800)
                DialogResult = DialogResult.OK
                Close()
                Return
            End If

            ' 2. في حال لم يعثر عليه بالبصمة، التحقق بواسطة السيريال المدخل أو المحفوظ
            Dim serialToCheck = txtLicense.Text.Trim()
            Dim cache = LicenseCache.Load()
            If String.IsNullOrWhiteSpace(serialToCheck) AndAlso cache IsNot Nothing Then
                serialToCheck = Convert.ToString(cache("saved_serial"))
            End If

            If Not String.IsNullOrWhiteSpace(serialToCheck) Then
                Dim actResult = Await LicenseBootstrapper.ActivateAsync(serialToCheck)
                If actResult.IsValid Then
                    StopBackgroundHwidPolling()
                    UpdateStatusBadge("مفعل أونلاين", isSuccess:=True)
                    lblStatusMessage.Text = "✅ الترخيص ساري ومسجل بالسيرفر بنجاح!"
                    lblStatusMessage.ForeColor = Color.FromArgb(52, 211, 153)

                    Try
                        Notify.Toast("تم التحقق من الترخيص وتفعيله بنجاح ✅", Notify.ToastType.Success)
                    Catch
                    End Try

                    Await Task.Delay(800)
                    DialogResult = DialogResult.OK
                    Close()
                    Return
                End If
            End If

            ' 3. في حال عدم وجود ترخيص نشط
            lblStatusMessage.Text = "⚠️ لم يتم العثور على ترخيص نشط مسجل لهذا الجهاز على السيرفر."
            lblStatusMessage.ForeColor = Color.FromArgb(251, 191, 36)
            MessageBox.Show("لا يوجد ترخيص نشط مسجل لهذا الجهاز على السيرفر حتى الآن." & vbCrLf & vbCrLf &
                            "إذا قمت بإرسال معرف الجهاز للإدارة، يرجى الانتظار لحين التفعيل ثم الضغط على هذا الزر مرة أخرى.",
                            "فحص السيرفر الأونلاين", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            lblStatusMessage.Text = "❌ تعذر الاتصال بالسيرفر: " & ex.Message
            lblStatusMessage.ForeColor = Color.FromArgb(248, 113, 113)
        Finally
            btnCheckOnline.Enabled = True
            btn_Staff.Enabled = True
            progressActivation.Visible = False
        End Try
    End Sub

    ''' <summary>
    ''' فحص دوري تلقائي صامت في الخلفية كل 10 ثوانٍ لتفعيل الجهاز فور قيام الأدمن بربطه
    ''' </summary>
    Private Sub StartBackgroundHwidPolling()
        Try
            If _pollTimer IsNot Nothing Then Return
            _pollTimer = New Windows.Forms.Timer() With {.Interval = 10000}
            AddHandler _pollTimer.Tick, Async Sub(s, ev)
                                            Try
                                                If Me.IsDisposed OrElse Not Me.IsHandleCreated Then
                                                    StopBackgroundHwidPolling()
                                                    Return
                                                End If
                                                Dim autoHwid = Await LicenseBootstrapper.CheckByHwidAsync()
                                                If autoHwid.IsValid AndAlso Not Me.IsDisposed Then
                                                    StopBackgroundHwidPolling()
                                                    Dim newSerial = Convert.ToString(autoHwid.Payload("saved_serial"))
                                                    If Not String.IsNullOrWhiteSpace(newSerial) Then
                                                        txtLicense.Text = newSerial.Trim().ToUpperInvariant()
                                                    End If
                                                    UpdateStatusBadge("مفعل أونلاين", isSuccess:=True)
                                                    lblStatusMessage.Text = "✅ تم استرداد وتفعيل الترخيص تلقائياً من السيرفر!"
                                                    lblStatusMessage.ForeColor = Color.FromArgb(52, 211, 153)
                                                    Try
                                                        Notify.Toast("تم تفعيل الجهاز أونلاين بنجاح ✅", Notify.ToastType.Success)
                                                    Catch
                                                    End Try
                                                    Await Task.Delay(800)
                                                    DialogResult = DialogResult.OK
                                                    Close()
                                                End If
                                            Catch
                                            End Try
                                        End Sub
            _pollTimer.Start()
        Catch
        End Try
    End Sub

    Private Sub StopBackgroundHwidPolling()
        Try
            If _pollTimer IsNot Nothing Then
                _pollTimer.Stop()
                _pollTimer.Dispose()
                _pollTimer = Nothing
            End If
        Catch
        End Try
    End Sub

    Private Sub FormActivation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopBackgroundHwidPolling()
    End Sub

    Private Sub UpdateStatusBadge(badgeText As String, isSuccess As Boolean, Optional isWarning As Boolean = False)
        lblStatusBadge.Text = badgeText
        If isSuccess Then
            lblStatusBadge.FillColor = Color.FromArgb(6, 78, 59)
            lblStatusBadge.ForeColor = Color.FromArgb(52, 211, 153)
        ElseIf isWarning Then
            lblStatusBadge.FillColor = Color.FromArgb(69, 58, 26)
            lblStatusBadge.ForeColor = Color.FromArgb(251, 191, 36)
        Else
            lblStatusBadge.FillColor = Color.FromArgb(69, 26, 26)
            lblStatusBadge.ForeColor = Color.FromArgb(248, 113, 113)
        End If
        lblStatusBadge.HoverState.FillColor = lblStatusBadge.FillColor
        lblStatusBadge.HoverState.ForeColor = lblStatusBadge.ForeColor
    End Sub

    ''' <summary>
    ''' نسخ بصمة الجهاز للحافظة مع إشعار وتغيير نص الزر مؤقتاً
    ''' </summary>
    Private Async Sub btnCopyHwid_Click(sender As Object, e As EventArgs) Handles btnCopyHwid.Click
        Try
            If Not String.IsNullOrEmpty(_hwid) Then
                Clipboard.SetText(_hwid)
                Dim origText = btnCopyHwid.Text
                btnCopyHwid.Text = "✓ تم النسخ بنجاح!"
                btnCopyHwid.FillColor = Color.FromArgb(16, 185, 129)

                Try
                    Notify.Toast("تم نسخ معرف الجهاز للحافظة بنجاح ✅", Notify.ToastType.Success)
                Catch
                End Try

                Await Task.Delay(2000)
                btnCopyHwid.Text = origText
                btnCopyHwid.FillColor = Color.FromArgb(51, 65, 85)
            End If
        Catch ex As Exception
            MessageBox.Show("تعذر نسخ المعرف: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ''' <summary>
    ''' لصق كود التفعيل من الحافظة مباشرة
    ''' </summary>
    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        Try
            If Clipboard.ContainsText() Then
                Dim clipText = Clipboard.GetText().Trim().ToUpperInvariant()
                If Not String.IsNullOrWhiteSpace(clipText) Then
                    txtLicense.Text = clipText
                    lblStatusMessage.Text = "تم لصق كود التفعيل. اضغط على زر 'تأكيد وتفعيل' للمتابعة."
                    lblStatusMessage.ForeColor = Color.FromArgb(56, 189, 248)
                End If
            Else
                lblStatusMessage.Text = "⚠️ الحافظة لا تحتوي على نص للصقه."
                lblStatusMessage.ForeColor = Color.FromArgb(251, 191, 36)
            End If
        Catch ex As Exception
            MessageBox.Show("تعذر اللصق: " & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ''' <summary>
    ''' فتح واتساب مباشرة مع رسالة مجهزة مسبقاً ببصمة الجهاز
    ''' </summary>
    Private Sub btnSupport_Click(sender As Object, e As EventArgs) Handles btnSupport.Click
        Try
            Dim message = "مرحباً، أود تفعيل ترخيص برنامج سستمك لإدارة المطاعم (Sestamk POS)" & vbCrLf &
                          "معرّف بصمة الجهاز (HWID):" & vbCrLf &
                          _hwid
            Dim url = "https://wa.me/201281637066?text=" & Uri.EscapeDataString(message)
            Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("تعذر فتح رابط الدعم الفني: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

End Class