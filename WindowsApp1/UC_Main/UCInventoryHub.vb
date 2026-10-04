Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCInventoryHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
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
                            Dim gBtn = CType(kvp.Key, Guna.UI2.WinForms.Guna2Button)
                            Dim isDark As Boolean = ThemeManager.Instance.IsDark
                            Dim pal = ThemeManager.Instance.CurrentPalette
                            gBtn.FillColor = If(isDark, Color.FromArgb(20, 24, 32), If(pal IsNot Nothing, pal.ButtonDisabledBackground, Color.FromArgb(241, 245, 249)))
                            gBtn.ForeColor = If(pal IsNot Nothing, pal.TextDisabled, Color.FromArgb(148, 163, 184))
                            gBtn.BorderColor = If(isDark, Color.FromArgb(35, 45, 63), If(pal IsNot Nothing, pal.Border, Color.FromArgb(226, 232, 240)))
                        End If
                    End If
                End If
            Next
        End Sub

        Public Sub ApplyTheme()
            Try
                Dim pal = ThemeManager.Instance.CurrentPalette
                If pal Is Nothing Then Return
                Dim isDark As Boolean = ThemeManager.Instance.IsDark

                Me.BackColor = pal.Background
                flpInventory.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderInventory.FillColor = pal.CardBackground
                pnlHeaderInventory.BackColor = Color.Transparent
                pnlHeaderInventory.BorderColor = pal.Border
                pnlHeaderInventory.BorderThickness = 1
                pnlHeaderInventory.BorderRadius = 10

                lblTitleInventory.ForeColor = pal.TextPrimary
                lblTitleInventory.BackColor = Color.Transparent
                lblDescInventory.ForeColor = pal.TextSecondary
                lblDescInventory.BackColor = Color.Transparent

                ' زر العودة
                btnBackInventory.FillColor = pal.ButtonSecondaryBackground
                btnBackInventory.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackInventory.BorderColor = pal.Border
                btnBackInventory.BorderThickness = 1
                btnBackInventory.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackInventory.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmStoreStock, btnfrmRawMaterials, btnfrmRecipes, btnfrmStores, btnfrmUnits}
                For Each btn In buttons
                    If btn IsNot Nothing Then
                        btn.FillColor = pal.CardBackground
                        btn.BorderColor = pal.Border
                        btn.BorderThickness = 1
                        btn.ForeColor = pal.TextPrimary
                        btn.HoverState.FillColor = pal.Primary
                        btn.HoverState.BorderColor = pal.PrimaryHover
                        btn.HoverState.ForeColor = pal.TextOnPrimary
                    End If
                Next
            Catch __logEx As Exception
                Logger.LogError("UCInventoryHub.vb:111", __logEx)
            End Try
        End Sub

    End Class

End Namespace
