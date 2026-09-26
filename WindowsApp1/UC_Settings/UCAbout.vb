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

        Private Sub btnWebHome_Click(sender As Object, e As EventArgs) Handles btnWebHome.Click
            WebLinks.OpenHome()
        End Sub

        Private Sub btnWebAbout_Click(sender As Object, e As EventArgs) Handles btnWebAbout.Click
            WebLinks.OpenAbout()
        End Sub

        Private Sub btnWebSupport_Click(sender As Object, e As EventArgs) Handles btnWebSupport.Click
            WebLinks.OpenContact()
        End Sub

        Private Sub btnWebTerms_Click(sender As Object, e As EventArgs) Handles btnWebTerms.Click
            WebLinks.OpenTerms()
        End Sub

        Private Sub btnWebPrivacy_Click(sender As Object, e As EventArgs) Handles btnWebPrivacy.Click
            WebLinks.OpenPrivacy()
        End Sub

        Private Sub btnWebUpdates_Click(sender As Object, e As EventArgs) Handles btnWebUpdates.Click
            WebLinks.OpenUpdates()
        End Sub

        Private Sub btnWebAcademy_Click(sender As Object, e As EventArgs) Handles btnWebAcademy.Click
            WebLinks.OpenAcademy()
        End Sub

        Private Sub btnWebPortal_Click(sender As Object, e As EventArgs) Handles btnWebPortal.Click
            WebLinks.OpenUrl(WebLinks.RoutePortal)
        End Sub
    End Class
End Namespace
