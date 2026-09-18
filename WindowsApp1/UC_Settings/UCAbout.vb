Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' شاشة حول البرنامج وبيانات المطور والإصدار
    ''' </summary>
    Public Class UCAbout
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
