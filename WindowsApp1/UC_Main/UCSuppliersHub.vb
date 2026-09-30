Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCSuppliersHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
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
                flpSuppliers.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderSuppliers.FillColor = pal.CardBackground
                pnlHeaderSuppliers.BackColor = Color.Transparent
                pnlHeaderSuppliers.BorderColor = pal.Border
                pnlHeaderSuppliers.BorderThickness = 1
                pnlHeaderSuppliers.BorderRadius = 10

                lblTitleSuppliers.ForeColor = pal.TextPrimary
                lblTitleSuppliers.BackColor = Color.Transparent
                lblDescSuppliers.ForeColor = pal.TextSecondary
                lblDescSuppliers.BackColor = Color.Transparent

                ' زر العودة
                btnBackSuppliers.FillColor = pal.ButtonSecondaryBackground
                btnBackSuppliers.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackSuppliers.BorderColor = pal.Border
                btnBackSuppliers.BorderThickness = 1
                btnBackSuppliers.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackSuppliers.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {ToolStripButton3, ToolStripButton4, ToolStripButton5}
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
            Catch
            End Try
        End Sub

    End Class

End Namespace
