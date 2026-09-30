Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCPurchasesHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBackPurchases_Click(sender As Object, e As EventArgs) Handles btnBackPurchases.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnfrmPurchases_Click(sender As Object, e As EventArgs) Handles btnfrmPurchases.Click
            OpenFormOnce(GetType(frmPurchases), btnfrmPurchases)
        End Sub

        Private Sub btnfrmPurchaseReports_Click(sender As Object, e As EventArgs) Handles btnfrmPurchaseReports.Click
            OpenFormOnce(GetType(frmPurchaseReports), btnfrmPurchaseReports)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnfrmPurchases, "frmPurchases"},
                {btnfrmPurchaseReports, "frmPurchaseReports"}
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
                flpPurchases.BackColor = pal.Background

                pnlHeaderPurchases.BackColor = pal.CardBackground
                lblTitlePurchases.ForeColor = pal.TextPrimary
                lblDescPurchases.ForeColor = pal.TextSecondary

                btnBackPurchases.FillColor = pal.ButtonSecondaryBackground
                btnBackPurchases.ForeColor = pal.ButtonSecondaryForeground
                btnBackPurchases.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmPurchases, btnfrmPurchaseReports}
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
