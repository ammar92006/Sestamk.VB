Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCSettingsHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBackSettings_Click(sender As Object, e As EventArgs) Handles btnBackSettings.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
            OpenFormOnce(GetType(Settings), btnSettings)
        End Sub

        Private Sub btnfrmPrinters_Click(sender As Object, e As EventArgs) Handles btnfrmPrinters.Click
            OpenFormOnce(GetType(frmPrinters), btnfrmPrinters)
        End Sub

        Private Sub btnBackups_Click(sender As Object, e As EventArgs) Handles btnBackups.Click
            OpenFormOnce(GetType(Backup), btnBackups)
        End Sub

        Private Sub btnfrmRestaurantSections_Click(sender As Object, e As EventArgs) Handles btnfrmRestaurantSections.Click
            OpenFormOnce(GetType(frmRestaurantSections), btnfrmRestaurantSections)
        End Sub

        Private Sub btnfrmRestaurantTables_Click(sender As Object, e As EventArgs) Handles btnfrmRestaurantTables.Click
            OpenFormOnce(GetType(frmRestaurantTables), btnfrmRestaurantTables)
        End Sub

        Private Sub btnfrmColors_Click(sender As Object, e As EventArgs) Handles btnfrmColors.Click
            OpenFormOnce(GetType(frmColors), btnfrmColors)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnSettings, "Settings"},
                {btnfrmPrinters, "frmPrinters"},
                {btnBackups, "Backup"},
                {btnfrmRestaurantSections, "frmRestaurantSections"},
                {btnfrmRestaurantTables, "frmRestaurantTables"},
                {btnfrmColors, "frmColors"}
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
                flpSettings.BackColor = pal.Background

                pnlHeaderSettings.BackColor = pal.CardBackground
                lblTitleSettings.ForeColor = pal.TextPrimary
                lblDescSettings.ForeColor = pal.TextSecondary

                btnBackSettings.FillColor = pal.ButtonSecondaryBackground
                btnBackSettings.ForeColor = pal.ButtonSecondaryForeground
                btnBackSettings.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnSettings, btnfrmPrinters, btnBackups, btnfrmRestaurantSections, btnfrmRestaurantTables, btnfrmColors}
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
