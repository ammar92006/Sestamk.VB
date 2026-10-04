Imports System.IO
Imports System.Media

''' <summary>
''' مدير الأصوات المخصصة للإشعارات
''' </summary>
Public NotInheritable Class ToastSoundManager
    Private Sub New()
    End Sub

    Private Shared ReadOnly _soundCache As New Dictionary(Of String, SoundPlayer)
    Private Shared ReadOnly _lock As New Object()

    ''' <summary>
    ''' تشغيل صوت الإشعار حسب النوع والإعدادات
    ''' </summary>
    Public Shared Sub PlayToastSound(model As ToastModelAdvanced)
        If model Is Nothing OrElse Not model.PlaySound Then Return

        Try
            ' التحقق من الإعدادات العامة
            If Not SettingsManager.GetBoolSetting(SettingsKeys.NotificationSoundEnabled, True) Then
                Return
            End If

            ' تشغيل الصوت المناسب
            Select Case model.Sound
                Case ToastSound.None
                    ' لا صوت

                Case ToastSound.SystemBeep
                    Beep()

                Case ToastSound.SystemAsterisk
                    SystemSounds.Asterisk.Play()

                Case ToastSound.SystemExclamation
                    SystemSounds.Exclamation.Play()

                Case ToastSound.SystemHand
                    SystemSounds.Hand.Play()

                Case ToastSound.SystemQuestion
                    SystemSounds.Question.Play()

                Case ToastSound.Custom
                    PlayCustomSound(model.CustomSoundPath)

                Case Else
                    ' صوت افتراضي حسب نوع الإشعار
                    PlayDefaultSoundForType(model.Type)
            End Select

        Catch ex As Exception
            Logger.LogError("ToastSoundManager.PlayToastSound", ex)
        End Try
    End Sub

    ''' <summary>
    ''' تشغيل صوت مخصص من ملف
    ''' </summary>
    Private Shared Sub PlayCustomSound(soundPath As String)
        If String.IsNullOrWhiteSpace(soundPath) Then Return

        Try
            ' التحقق من وجود الملف
            If Not File.Exists(soundPath) Then
                Logger.Warn($"Sound file not found: {soundPath}", "ToastSoundManager")
                Return
            End If

            SyncLock _lock
                ' استخدام cache للأصوات المتكررة
                Dim player As SoundPlayer

                If _soundCache.ContainsKey(soundPath) Then
                    player = _soundCache(soundPath)
                Else
                    player = New SoundPlayer(soundPath)
                    player.Load()
                    _soundCache(soundPath) = player
                End If

                player.Play()
            End SyncLock

        Catch ex As Exception
            Logger.LogError("ToastSoundManager.PlayCustomSound", ex)
        End Try
    End Sub

    ''' <summary>
    ''' تشغيل الصوت الافتراضي حسب نوع الإشعار
    ''' </summary>
    Private Shared Sub PlayDefaultSoundForType(type As ToastType)
        Select Case type
            Case ToastType.Success, ToastType.Info
                If SettingsManager.GetBoolSetting(SettingsKeys.NotificationNewOrderSound, True) Then
                    SystemSounds.Asterisk.Play()
                End If

            Case ToastType.Warning
                If SettingsManager.GetBoolSetting(SettingsKeys.NotificationErrorSound, True) Then
                    SystemSounds.Exclamation.Play()
                End If

            Case ToastType.Error
                If SettingsManager.GetBoolSetting(SettingsKeys.NotificationErrorSound, True) Then
                    SystemSounds.Hand.Play()
                End If

            Case ToastType.Question
                SystemSounds.Question.Play()
        End Select
    End Sub

    ''' <summary>
    ''' تنظيف ذاكرة التخزين المؤقت للأصوات
    ''' </summary>
    Public Shared Sub ClearSoundCache()
        SyncLock _lock
            For Each player In _soundCache.Values
                Try
                    player?.Dispose()
                Catch __logEx As Exception
                    Logger.LogError("ToastSoundManager.vb:125", __logEx)
                End Try
            Next
            _soundCache.Clear()
        End SyncLock
    End Sub

    ''' <summary>
    ''' تحميل صوت مخصص مسبقاً للاستخدام السريع
    ''' </summary>
    Public Shared Sub PreloadCustomSound(soundPath As String)
        If String.IsNullOrWhiteSpace(soundPath) OrElse Not File.Exists(soundPath) Then
            Return
        End If

        Try
            SyncLock _lock
                If Not _soundCache.ContainsKey(soundPath) Then
                    Dim player As New SoundPlayer(soundPath)
                    player.Load()
                    _soundCache(soundPath) = player
                End If
            End SyncLock
        Catch ex As Exception
            Logger.LogError("ToastSoundManager.PreloadCustomSound", ex)
        End Try
    End Sub
End Class
