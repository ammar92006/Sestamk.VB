Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCSuppliersHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBackSuppliers_Click(sender As Object, e As EventArgs) Handles btnBackSuppliers.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
            OpenFormOnce(GetType(FrmSuppliers), ToolStripButton3)
        End Sub

        Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
            OpenFormOnce(GetType(FrmSupplierTransactions), ToolStripButton4)
        End Sub

        Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
            OpenFormOnce(GetType(frmPurchaseReports), ToolStripButton5)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {ToolStripButton3, "FrmSuppliers"},
                {ToolStripButton4, "FrmSupplierTransactions"},
                {ToolStripButton5, "frmPurchaseReports"}
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
                flpSuppliers.BackColor = pal.Background

                pnlHeaderSuppliers.BackColor = pal.CardBackground
                lblTitleSuppliers.ForeColor = pal.TextPrimary
                lblDescSuppliers.ForeColor = pal.TextSecondary

                btnBackSuppliers.FillColor = pal.ButtonSecondaryBackground
                btnBackSuppliers.ForeColor = pal.ButtonSecondaryForeground
                btnBackSuppliers.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {ToolStripButton3, ToolStripButton4, ToolStripButton5}
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
