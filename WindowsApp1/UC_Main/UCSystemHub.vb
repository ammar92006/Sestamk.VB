Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCSystemHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBackSystem_Click(sender As Object, e As EventArgs) Handles btnBackSystem.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
            OpenFormOnce(GetType(Categories), btnCategories)
        End Sub

        Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
            OpenFormOnce(GetType(Products), btnProducts)
        End Sub

        Private Sub btnfrmProductSizes_Click(sender As Object, e As EventArgs) Handles btnfrmProductSizes.Click
            OpenFormOnce(GetType(frmProductSizes), btnfrmProductSizes)
        End Sub

        Private Sub btnfrmProductAddons_Click(sender As Object, e As EventArgs) Handles btnfrmProductAddons.Click
            OpenFormOnce(GetType(frmProductAddons), btnfrmProductAddons)
        End Sub

        Private Sub btnfrmKitchenComments_Click(sender As Object, e As EventArgs) Handles btnfrmKitchenComments.Click
            OpenFormOnce(GetType(frmKitchenComments), btnfrmKitchenComments)
        End Sub

        Private Sub btnfrmDeliveryAreas_Click(sender As Object, e As EventArgs) Handles btnfrmDeliveryAreas.Click
            OpenFormOnce(GetType(frmDeliveryAreas), btnfrmDeliveryAreas)
        End Sub

        Private Sub btnfrmDeliveryDrivers_Click(sender As Object, e As EventArgs) Handles btnfrmDeliveryDrivers.Click
            OpenFormOnce(GetType(frmDeliveryDrivers), btnfrmDeliveryDrivers)
        End Sub

        Private Sub btnfrmShifts_Click(sender As Object, e As EventArgs) Handles btnfrmShifts.Click
            OpenFormOnce(GetType(frmShifts), btnfrmShifts)
        End Sub

        Private Sub btnShiftReports_Click(sender As Object, e As EventArgs) Handles btnShiftReports.Click
            OpenFormOnce(GetType(FrmShiftReports), btnShiftReports)
        End Sub

        Private Sub btnfrmBranches_Click(sender As Object, e As EventArgs) Handles btnfrmBranches.Click
            OpenFormOnce(GetType(frmBranches), btnfrmBranches)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnCategories, "Categories"},
                {btnProducts, "Products"},
                {btnfrmProductSizes, "frmProductSizes"},
                {btnfrmProductAddons, "frmProductAddons"},
                {btnfrmKitchenComments, "frmKitchenComments"},
                {btnfrmDeliveryAreas, "frmDeliveryAreas"},
                {btnfrmDeliveryDrivers, "frmDeliveryDrivers"},
                {btnfrmShifts, "frmShifts"},
                {btnShiftReports, "FrmShiftReports"},
                {btnfrmBranches, "frmBranches"}
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
                flpSystem.BackColor = pal.Background

                pnlHeaderSystem.BackColor = pal.CardBackground
                lblTitleSystem.ForeColor = pal.TextPrimary
                lblDescSystem.ForeColor = pal.TextSecondary

                btnBackSystem.FillColor = pal.ButtonSecondaryBackground
                btnBackSystem.ForeColor = pal.ButtonSecondaryForeground
                btnBackSystem.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnCategories, btnProducts, btnfrmProductSizes, btnfrmProductAddons, btnfrmKitchenComments, btnfrmDeliveryAreas, btnfrmDeliveryDrivers, btnfrmShifts, btnShiftReports, btnfrmBranches}
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
