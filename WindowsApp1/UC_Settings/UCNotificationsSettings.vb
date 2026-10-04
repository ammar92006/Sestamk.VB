Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات أصوات وتنبيهات النظام ونفاذ المخزون
    ''' </summary>
    Public Class UCNotificationsSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCNotificationsSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadSettings()
        End Sub

        Public Sub LoadSettings()
            Try
                tglOrderSound.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationNewOrderSound, True)
                tglErrorSound.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationErrorSound, True)
                tglLowStock.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationLowStockAlert, True)
                tglPrintFailure.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationPrintFailAlert, True)
            Catch ex As Exception
                SmartMessageBox.Show("خطأ في قراءة إعدادات الإشعارات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                SettingsManager.SaveSetting(SettingsKeys.NotificationNewOrderSound, tglOrderSound.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.NotificationErrorSound, tglErrorSound.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.NotificationLowStockAlert, tglLowStock.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.NotificationPrintFailAlert, tglPrintFailure.Checked.ToString().ToLower())

                Try
                    Notify.Toast("تم حفظ إعدادات الإشعارات بنجاح ✅", Notify.ToastType.Success)
                Catch
                    SmartMessageBox.Show("✅ تم حفظ إعدادات الإشعارات بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Catch ex As Exception
                SmartMessageBox.Show("خطأ في حفظ إعدادات الإشعارات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If SmartMessageBox.Show("هل أنت متأكد من استعادة القيم الافتراضية لإعدادات الإشعارات؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                tglOrderSound.Checked = True
                tglErrorSound.Checked = True
                tglLowStock.Checked = True
                tglPrintFailure.Checked = True
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
