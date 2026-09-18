Imports System.ComponentModel
Imports System.Windows.Forms

Public Class BaseForm
    Inherits System.Windows.Forms.Form

    Private _themeSubscribed As Boolean = False

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        If IsInDesignMode() Then Return

        SubscribeTheme()
        ApplyTheme()
    End Sub

    Public Overridable Sub ApplyTheme()
        If IsInDesignMode() Then Return

        Try
            ThemeManager.Instance.ApplyTheme(Me)
            ApplyCustomTheme()
        Catch ex As Exception
        End Try
    End Sub

    Protected Overridable Sub ApplyCustomTheme()
    End Sub

    Private Sub SubscribeTheme()
        If _themeSubscribed Then Return
        AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
        _themeSubscribed = True
    End Sub

    Private Sub UnsubscribeTheme()
        If Not _themeSubscribed Then Return
        RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
        _themeSubscribed = False
    End Sub

    Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
        If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return

        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf ApplyTheme))
        Else
            ApplyTheme()
        End If
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            UnsubscribeTheme()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Protected Function IsInDesignMode() As Boolean
        If Me.DesignMode Then Return True
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return True
        Return False
    End Function

End Class
