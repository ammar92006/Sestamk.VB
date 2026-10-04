Imports System.Windows.Forms

''' <summary>
''' بانل إعدادات الإشعارات المتطورة
''' </summary>
Public Class UCNotificationsSettingsAdvanced

    Private _isLoading As Boolean = False

    Public Sub New()
        InitializeComponent()
        LoadSettings()
    End Sub

    ''' <summary>
    ''' تحميل الإعدادات الحالية
    ''' </summary>
    Private Sub LoadSettings()
        _isLoading = True
        Try
            ' تفعيل/إيقاف الأصوات
            chkSoundEnabled.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationSoundEnabled, True)
            chkNewOrderSound.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationNewOrderSound, True)
            chkErrorSound.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationErrorSound, True)
            chkLowStockAlert.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationLowStockAlert, True)
            chkPrintFailAlert.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationPrintFailAlert, True)

            ' إعدادات Toast المتطورة
            chkShowProgressBar.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationShowProgressBar, False)
            chkStackSimilar.Checked = SettingsManager.GetBoolSetting(SettingsKeys.NotificationStackSimilar, False)

            ' موضع العرض
            Dim position As Integer = SettingsManager.GetIntSetting(SettingsKeys.NotificationPosition, 0)
            cmbPosition.SelectedIndex = Math.Min(position, cmbPosition.Items.Count - 1)

            ' نوع الأنيميشن
            Dim animation As Integer = SettingsManager.GetIntSetting(SettingsKeys.NotificationAnimation, 4)
            cmbAnimation.SelectedIndex = Math.Min(animation, cmbAnimation.Items.Count - 1)

            ' المدة
            numDuration.Value = SettingsManager.GetIntSetting(SettingsKeys.NotificationDuration, 3800)

            ' الحد الأقصى للإشعارات المرئية
            numMaxVisible.Value = SettingsManager.GetIntSetting(SettingsKeys.NotificationMaxVisible, 5)

            ' مسار الصوت المخصص
            txtCustomSoundPath.Text = SettingsManager.GetStringSetting(SettingsKeys.NotificationCustomSoundPath, "")

        Catch ex As Exception
            Logger.LogError("UCNotificationsSettingsAdvanced.LoadSettings", ex)
        Finally
            _isLoading = False
        End Try
    End Sub

    ''' <summary>
    ''' حفظ الإعدادات
    ''' </summary>
    Public Function SaveSettings() As Boolean
        Try
            ' الأصوات
            SettingsManager.SaveSetting(SettingsKeys.NotificationSoundEnabled, chkSoundEnabled.Checked)
            SettingsManager.SaveSetting(SettingsKeys.NotificationNewOrderSound, chkNewOrderSound.Checked)
            SettingsManager.SaveSetting(SettingsKeys.NotificationErrorSound, chkErrorSound.Checked)
            SettingsManager.SaveSetting(SettingsKeys.NotificationLowStockAlert, chkLowStockAlert.Checked)
            SettingsManager.SaveSetting(SettingsKeys.NotificationPrintFailAlert, chkPrintFailAlert.Checked)

            ' إعدادات Toast
            SettingsManager.SaveSetting(SettingsKeys.NotificationShowProgressBar, chkShowProgressBar.Checked)
            SettingsManager.SaveSetting(SettingsKeys.NotificationStackSimilar, chkStackSimilar.Checked)
            SettingsManager.SaveSetting(SettingsKeys.NotificationPosition, cmbPosition.SelectedIndex)
            SettingsManager.SaveSetting(SettingsKeys.NotificationAnimation, cmbAnimation.SelectedIndex)
            SettingsManager.SaveSetting(SettingsKeys.NotificationDuration, CInt(numDuration.Value))
            SettingsManager.SaveSetting(SettingsKeys.NotificationMaxVisible, CInt(numMaxVisible.Value))
            SettingsManager.SaveSetting(SettingsKeys.NotificationCustomSoundPath, txtCustomSoundPath.Text.Trim())

            ' إعادة تحميل إعدادات ToastManager
            ToastManagerAdvanced.ReloadSettings()

            ToastManagerAdvanced.ShowSuccess("تم الحفظ", "تم حفظ إعدادات الإشعارات بنجاح")
            Return True

        Catch ex As Exception
            Logger.LogError("UCNotificationsSettingsAdvanced.SaveSettings", ex)
            ToastManagerAdvanced.ShowError("خطأ", "فشل حفظ الإعدادات: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub chkSoundEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoundEnabled.CheckedChanged
        If Not _isLoading Then
            ' تفعيل/تعطيل خيارات الأصوات الفرعية
            pnlSoundOptions.Enabled = chkSoundEnabled.Checked
        End If
    End Sub

    Private Sub btnTestToast_Click(sender As Object, e As EventArgs) Handles btnTestToast.Click
        ' اختبار الإشعار بالإعدادات الحالية
        Dim testModel As New ToastModelAdvanced With {
            .Type = CType(cmbTestType.SelectedIndex, ToastType),
            .Title = "إشعار تجريبي",
            .Message = "هذا إشعار تجريبي لاختبار الإعدادات الحالية",
            .Position = CType(cmbPosition.SelectedIndex, ToastPosition),
            .Animation = CType(cmbAnimation.SelectedIndex, ToastAnimation),
            .Duration = CInt(numDuration.Value),
            .ShowProgressBar = chkShowProgressBar.Checked
        }
        ToastManagerAdvanced.Show(testModel)
    End Sub

    Private Sub btnBrowseSound_Click(sender As Object, e As EventArgs) Handles btnBrowseSound.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "ملفات الصوت|*.wav;*.mp3|جميع الملفات|*.*"
            ofd.Title = "اختر ملف صوت"

            If ofd.ShowDialog() = DialogResult.OK Then
                txtCustomSoundPath.Text = ofd.FileName
                ' تحميل مسبق للصوت
                ToastSoundManager.PreloadCustomSound(ofd.FileName)
            End If
        End Using
    End Sub

    Private Sub btnTestCustomSound_Click(sender As Object, e As EventArgs) Handles btnTestCustomSound.Click
        If Not String.IsNullOrWhiteSpace(txtCustomSoundPath.Text) Then
            Dim testModel As New ToastModelAdvanced With {
                .Sound = ToastSound.Custom,
                .CustomSoundPath = txtCustomSoundPath.Text.Trim(),
                .PlaySound = True
            }
            ToastSoundManager.PlayToastSound(testModel)
        Else
            ToastManagerAdvanced.ShowWarning("تنبيه", "الرجاء اختيار ملف صوت أولاً")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveSettings()
    End Sub

    Private Sub btnTestWithButtons_Click(sender As Object, e As EventArgs) Handles btnTestWithButtons.Click
        ' اختبار إشعار مع أزرار تفاعلية
        Dim testModel As New ToastModelAdvanced With {
            .Type = ToastType.Question,
            .Title = "تأكيد العملية",
            .Message = "هل تريد تنفيذ هذا الإجراء؟",
            .Position = CType(cmbPosition.SelectedIndex, ToastPosition),
            .Duration = 10000,
            .AutoClose = False
        }

        testModel.Buttons.Add(New ToastButton With {
            .Text = "نعم",
            .BackColor = Color.FromArgb(34, 197, 94),
            .Action = Sub()
                          ToastManagerAdvanced.ShowSuccess("تم التأكيد", "تم قبول العملية بنجاح")
                      End Sub
        })

        testModel.Buttons.Add(New ToastButton With {
            .Text = "لا",
            .BackColor = Color.FromArgb(239, 68, 68),
            .Action = Sub()
                          ToastManagerAdvanced.ShowInfo("تم الإلغاء", "تم إلغاء العملية")
                      End Sub
        })

        ToastManagerAdvanced.Show(testModel)
    End Sub

    Private Sub btnTestExpandable_Click(sender As Object, e As EventArgs) Handles btnTestExpandable.Click
        ' اختبار إشعار قابل للتوسيع
        Dim testModel As New ToastModelAdvanced With {
            .Type = ToastType.Info,
            .Title = "تفاصيل الطلب",
            .Message = "اضغط للمزيد من التفاصيل...",
            .IsExpandable = True,
            .ExpandedMessage = "تفاصيل الطلب الكاملة:" & vbCrLf &
                               "- الصنف: بيتزا مارغريتا" & vbCrLf &
                               "- الكمية: 2" & vbCrLf &
                               "- السعر: 150 ج.م" & vbCrLf &
                               "- وقت التحضير: 15 دقيقة",
            .ExpandedHeight = 180,
            .Position = CType(cmbPosition.SelectedIndex, ToastPosition),
            .Duration = 10000
        }
        ToastManagerAdvanced.Show(testModel)
    End Sub

    Private Sub btnResetDefaults_Click(sender As Object, e As EventArgs) Handles btnResetDefaults.Click
        If SmartMessageBox.Show("هل تريد استعادة الإعدادات الافتراضية؟", "تأكيد",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' استعادة القيم الافتراضية
            cmbPosition.SelectedIndex = 0
            cmbAnimation.SelectedIndex = 4
            numDuration.Value = 3800
            numMaxVisible.Value = 5
            chkShowProgressBar.Checked = False
            chkStackSimilar.Checked = False
            chkSoundEnabled.Checked = True
            txtCustomSoundPath.Text = ""
        End If
    End Sub
End Class
