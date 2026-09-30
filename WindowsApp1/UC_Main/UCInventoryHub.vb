Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCInventoryHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBackInventory_Click(sender As Object, e As EventArgs) Handles btnBackInventory.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnfrmStoreStock_Click(sender As Object, e As EventArgs) Handles btnfrmStoreStock.Click
            OpenFormOnce(GetType(frmStoreStock), btnfrmStoreStock)
        End Sub

        Private Sub btnfrmRawMaterials_Click(sender As Object, e As EventArgs) Handles btnfrmRawMaterials.Click
            OpenFormOnce(GetType(frmRawMaterials), btnfrmRawMaterials)
        End Sub

        Private Sub btnfrmRecipes_Click(sender As Object, e As EventArgs) Handles btnfrmRecipes.Click
            OpenFormOnce(GetType(frmRecipes), btnfrmRecipes)
        End Sub

        Private Sub btnfrmStores_Click(sender As Object, e As EventArgs) Handles btnfrmStores.Click
            OpenFormOnce(GetType(FrmStores), btnfrmStores)
        End Sub

        Private Sub btnfrmUnits_Click(sender As Object, e As EventArgs) Handles btnfrmUnits.Click
            OpenFormOnce(GetType(frmUnits), btnfrmUnits)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnfrmStoreStock, "frmStoreStock"},
                {btnfrmRawMaterials, "frmRawMaterials"},
                {btnfrmRecipes, "frmRecipes"},
                {btnfrmStores, "FrmStores"},
                {btnfrmUnits, "frmUnits"}
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
                flpInventory.BackColor = pal.Background

                pnlHeaderInventory.BackColor = pal.CardBackground
                lblTitleInventory.ForeColor = pal.TextPrimary
                lblDescInventory.ForeColor = pal.TextSecondary

                btnBackInventory.FillColor = pal.ButtonSecondaryBackground
                btnBackInventory.ForeColor = pal.ButtonSecondaryForeground
                btnBackInventory.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmStoreStock, btnfrmRawMaterials, btnfrmRecipes, btnfrmStores, btnfrmUnits}
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
