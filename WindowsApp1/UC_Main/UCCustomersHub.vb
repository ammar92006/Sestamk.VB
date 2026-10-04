Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCCustomersHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
        End Sub

        Private Sub btnBackCustomers_Click(sender As Object, e As EventArgs) Handles btnBackCustomers.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnFrmCustomers_Click(sender As Object, e As EventArgs) Handles btnFrmCustomers.Click
            OpenFormOnce(GetType(FrmCustomers), btnFrmCustomers)
        End Sub

        Private Sub btnFrmCustomerStatement_Click(sender As Object, e As EventArgs) Handles btnFrmCustomerStatement.Click
            OpenFormOnce(GetType(FrmCustomerStatement), btnFrmCustomerStatement)
        End Sub

        Private Sub btnCustomerBalanceDownload_Click(sender As Object, e As EventArgs) Handles btnCustomerBalanceDownload.Click
            OpenFormOnce(GetType(Customer_Balance_Download), btnCustomerBalanceDownload)
        End Sub

        Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
            OpenFormOnce(GetType(Reports), ToolStripButton11)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnFrmCustomers, "FrmCustomers"},
                {btnFrmCustomerStatement, "FrmCustomerStatement"},
                {btnCustomerBalanceDownload, "Customer_Balance_Download"},
                {ToolStripButton11, "Reports"}
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
                flpCustomers.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderCustomers.FillColor = pal.CardBackground
                pnlHeaderCustomers.BackColor = Color.Transparent
                pnlHeaderCustomers.BorderColor = pal.Border
                pnlHeaderCustomers.BorderThickness = 1
                pnlHeaderCustomers.BorderRadius = 10

                lblTitleCustomers.ForeColor = pal.TextPrimary
                lblTitleCustomers.BackColor = Color.Transparent
                lblDescCustomers.ForeColor = pal.TextSecondary
                lblDescCustomers.BackColor = Color.Transparent

                ' زر العودة
                btnBackCustomers.FillColor = pal.ButtonSecondaryBackground
                btnBackCustomers.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackCustomers.BorderColor = pal.Border
                btnBackCustomers.BorderThickness = 1
                btnBackCustomers.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackCustomers.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnFrmCustomers, btnFrmCustomerStatement, btnCustomerBalanceDownload, ToolStripButton11}
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
                Logger.LogError("UCCustomersHub.vb:106", __logEx)
            End Try
        End Sub

    End Class

End Namespace
