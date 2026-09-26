' Compatibility facade for the existing login timer.
' The old CPU-only fingerprint, AES key, sys.dat cache and service-role key are retired.
Module CheckActivation
    Public Function GetHWID() As String
        Return HardwareFingerprint.GetCurrent()
    End Function

    Public Function IsActivated() As Boolean
        Return Task.Run(Function() LicenseBootstrapper.CheckAsync()).GetAwaiter().GetResult().IsValid
    End Function

    Public Function CheckActivationBackground() As Boolean
        Return Task.Run(Function() LicenseBootstrapper.CheckAsync(forceOnlineCheck:=True)).GetAwaiter().GetResult().IsValid
    End Function
End Module