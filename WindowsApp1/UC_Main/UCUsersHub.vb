Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCUsersHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBackUsers_Click(sender As Object, e As EventArgs) Handles btnBackUsers.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnfrmUsers_Click(sender As Object, e As EventArgs) Handles btnfrmUsers.Click
            OpenFormOnce(GetType(frmUsers), btnfrmUsers)
        End Sub

        Private Sub btnfrmRolesAndPermissions_Click(sender As Object, e As EventArgs) Handles btnfrmRolesAndPermissions.Click
            OpenFormOnce(GetType(frmRolesAndPermissions), btnfrmRolesAndPermissions)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnfrmUsers, "frmUsers"},
                {btnfrmRolesAndPermissions, "frmRolesAndPermissions"}
            }

            For Each kvp In mappings
                If kvp.Key IsNot Nothing Then
                    Dim allowed As Boolean = Session.HasPermission(kvp.Value, "CanOpen")
                    kvp.Key.Enabled = allowed
                    If Not allowed Then
                        If TypeOf kvp.Key Is Guna.UI2.WinForms.Guna2Button Then
                            CType(kvp.Key, Guna.UI2.WinForms.Guna2Button).FillColor = Color.FromArgb(20, 24, 32)
                        End If
                    End If
                End If
            Next
        End Sub

        Public Sub ApplyTheme()
            Try
                Dim pal = ThemeManager.Instance.CurrentPalette
                If pal Is Nothing Then Return

                Me.BackColor = pal.Background
                flpUsers.BackColor = pal.Background

                pnlHeaderUsers.BackColor = pal.CardBackground
                lblTitleUsers.ForeColor = pal.TextPrimary
                lblDescUsers.ForeColor = pal.TextSecondary

                btnBackUsers.FillColor = pal.ButtonSecondaryBackground
                btnBackUsers.ForeColor = pal.ButtonSecondaryForeground
                btnBackUsers.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmUsers, btnfrmRolesAndPermissions}
                For Each btn In buttons
                    If btn IsNot Nothing Then
                        btn.FillColor = pal.CardBackground
                        btn.BorderColor = pal.Border
                        btn.ForeColor = pal.TextPrimary
                        btn.HoverState.FillColor = pal.Primary
                        btn.HoverState.BorderColor = pal.PrimaryHover
                        btn.HoverState.ForeColor = pal.TextOnPrimary
                    End If
                Next
            Catch
            End Try
        End Sub

    End Class

End Namespace
