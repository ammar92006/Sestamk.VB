Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' معالج أول تشغيل: يظهر مرة واحدة بعد التثبيت لكل نشاط.
''' يجمع بيانات المحل/النشاط وينشئ حساب المدير، ثم يعلّم SetupCompleted = true.
''' مبني بالكود بالكامل (بدون Designer) ليسهل صيانته ويتجنّب تعقيد المصمم.
''' </summary>
Public Class FirstRunSetup
    Inherits Form

    Private txtShopName As TextBox
    Private txtPhone As TextBox
    Private txtAddress As TextBox
    Private txtTax As TextBox
    Private cmbCurrency As ComboBox
    Private cmbBusinessType As ComboBox
    Private txtLogoPath As TextBox
    Private txtAdminUser As TextBox
    Private txtAdminPass As TextBox
    Private txtAdminPass2 As TextBox

    Public Sub New()
        InitForm()
        AddHandler Me.Load, Sub() LayoutHelper.FitToWorkingArea(Me)
    End Sub

    Private Sub InitForm()
        Me.Text = "تهيئة البرنامج لأول مرة"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.RightToLeft = RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ClientSize = New Size(640, 720)
        Me.BackColor = Color.FromArgb(45, 45, 55)

        Dim header As New Label() With {
            .Text = "👋 مرحباً — لنُهيّئ البرنامج لنشاطك",
            .ForeColor = Color.White, .Font = New Font("Segoe UI", 16, FontStyle.Bold),
            .AutoSize = False, .TextAlign = ContentAlignment.MiddleCenter,
            .Dock = DockStyle.Top, .Height = 60, .BackColor = Color.FromArgb(33, 42, 57)
        }
        Me.Controls.Add(header)

        Dim y As Integer = 80

        Dim MakeLabel = Sub(txt As String, yy As Integer)
                            Me.Controls.Add(New Label() With {
                                .Text = txt, .ForeColor = Color.White,
                                .Font = New Font("Segoe UI", 11, FontStyle.Bold), .AutoSize = True,
                                .Location = New Point(Me.ClientSize.Width - 200, yy + 4),
                                .RightToLeft = RightToLeft.Yes})
                        End Sub

        Dim MakeText = Function(yy As Integer) As TextBox
                           Dim tb As New TextBox() With {
                               .Location = New Point(40, yy), .Width = 380, .Height = 30,
                               .Font = New Font("Segoe UI", 11), .RightToLeft = RightToLeft.Yes}
                           Me.Controls.Add(tb)
                           Return tb
                       End Function

        MakeLabel("اسم المحل / النشاط *:", y) : txtShopName = MakeText(y) : y += 42
        MakeLabel("رقم الهاتف:", y) : txtPhone = MakeText(y) : y += 42
        MakeLabel("العنوان:", y) : txtAddress = MakeText(y) : y += 42
        MakeLabel("الرقم الضريبي:", y) : txtTax = MakeText(y) : y += 42

        MakeLabel("العملة:", y)
        cmbCurrency = New ComboBox() With {
            .Location = New Point(40, y), .Width = 380, .Font = New Font("Segoe UI", 11),
            .DropDownStyle = ComboBoxStyle.DropDown, .RightToLeft = RightToLeft.Yes}
        cmbCurrency.Items.AddRange(New String() {"ج.م", "ر.س", "د.إ", "د.ك", "د.ع", "$", "€"})
        cmbCurrency.Text = "ج.م"
        Me.Controls.Add(cmbCurrency) : y += 42

        MakeLabel("نوع النشاط:", y)
        cmbBusinessType = New ComboBox() With {
            .Location = New Point(40, y), .Width = 380, .Font = New Font("Segoe UI", 11),
            .DropDownStyle = ComboBoxStyle.DropDown, .RightToLeft = RightToLeft.Yes}
        cmbBusinessType.Items.AddRange(New String() {"سوبر ماركت", "بقالة", "صيدلية", "مخبز", "ملابس", "إلكترونيات", "أخرى"})
        cmbBusinessType.Text = "سوبر ماركت"
        Me.Controls.Add(cmbBusinessType) : y += 42

        MakeLabel("شعار/لوجو (اختياري):", y)
        txtLogoPath = New TextBox() With {
            .Location = New Point(120, y), .Width = 300, .Font = New Font("Segoe UI", 10),
            .RightToLeft = RightToLeft.Yes}
        Me.Controls.Add(txtLogoPath)
        Dim btnBrowse As New Button() With {
            .Text = "📂", .Location = New Point(40, y - 1), .Width = 70, .Height = 30,
            .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(40, 52, 70), .ForeColor = Color.White}
        AddHandler btnBrowse.Click, Sub()
                                        Using dlg As New OpenFileDialog() With {
                                            .Filter = "صور|*.png;*.jpg;*.jpeg;*.bmp|الكل|*.*"}
                                            If dlg.ShowDialog() = DialogResult.OK Then txtLogoPath.Text = dlg.FileName
                                        End Using
                                    End Sub
        Me.Controls.Add(btnBrowse) : y += 50

        ' فاصل حساب المدير
        Me.Controls.Add(New Label() With {
            .Text = "🔐 حساب المدير", .ForeColor = Color.Gold,
            .Font = New Font("Segoe UI", 13, FontStyle.Bold), .AutoSize = True,
            .Location = New Point(Me.ClientSize.Width - 200, y), .RightToLeft = RightToLeft.Yes})
        y += 40

        MakeLabel("اسم مستخدم المدير *:", y) : txtAdminUser = MakeText(y) : y += 42
        MakeLabel("كلمة المرور *:", y)
        txtAdminPass = MakeText(y) : txtAdminPass.PasswordChar = "•"c : y += 42
        MakeLabel("تأكيد كلمة المرور *:", y)
        txtAdminPass2 = MakeText(y) : txtAdminPass2.PasswordChar = "•"c : y += 55

        Dim btnSave As New Button() With {
            .Text = "💾 حفظ وبدء الاستخدام",
            .Location = New Point(40, y), .Width = 560, .Height = 48,
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .BackColor = Color.FromArgb(76, 132, 255), .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat}
        AddHandler btnSave.Click, AddressOf btnSave_Click
        Me.Controls.Add(btnSave)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        ' تحقق من الحقول المطلوبة
        If String.IsNullOrWhiteSpace(txtShopName.Text) Then
            MessageBox.Show("يرجى إدخال اسم المحل / النشاط.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(txtAdminUser.Text) OrElse String.IsNullOrWhiteSpace(txtAdminPass.Text) Then
            MessageBox.Show("يرجى إدخال اسم مستخدم المدير وكلمة المرور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtAdminPass.Text <> txtAdminPass2.Text Then
            MessageBox.Show("كلمتا المرور غير متطابقتين.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            SettingsManager.SaveSetting(SettingsKeys.ShopName, txtShopName.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.ShopPhone, txtPhone.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.ShopAddress, txtAddress.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.TaxNumber, txtTax.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.Currency, cmbCurrency.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.BusinessType, cmbBusinessType.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.LogoPath, txtLogoPath.Text.Trim())

            SettingsManager.SaveSetting(SettingsKeys.AdminUsername, txtAdminUser.Text.Trim())
            SettingsManager.SaveSetting(SettingsKeys.AdminPassword, txtAdminPass.Text)

            SettingsManager.SaveSetting(SettingsKeys.SetupCompleted, "true")

            ' تطبيق بيانات المدير فوراً على الجلسة الحالية
            Settingsall.usernameadmin = txtAdminUser.Text.Trim()
            Settingsall.passwordadmin = txtAdminPass.Text

            MessageBox.Show("✅ تم حفظ بيانات نشاطك. يمكنك الآن تسجيل الدخول.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("تعذّر حفظ البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
