Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' معالج أول تشغيل: يظهر مرة واحدة بعد التثبيت لكل نشاط.
''' يجمع بيانات المحل/النشاط وينشئ حساب المدير، ثم يعلّم SetupCompleted = true.
''' مبني بالكود بالكامل (بدون Designer) ليسهل صيانته ويتجنّب تعقيد المصمم.
''' </summary>
Partial Class FirstRunSetup

    Public Sub New()
        InitializeComponent()
        AddHandler btnBrowse.Click, AddressOf btnBrowse_Click
        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler Me.Load, Sub() LayoutHelper.FitToWorkingArea(Me)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs)
        Using dlg As New OpenFileDialog() With {.Filter = "صور|*.png;*.jpg;*.jpeg;*.bmp|الكل|*.*"}
            If dlg.ShowDialog() = DialogResult.OK Then txtLogoPath.Text = dlg.FileName
        End Using
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
