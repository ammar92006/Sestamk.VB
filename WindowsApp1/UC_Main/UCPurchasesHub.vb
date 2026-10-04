Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCPurchasesHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
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
                flpPurchases.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderPurchases.FillColor = pal.CardBackground
                pnlHeaderPurchases.BackColor = Color.Transparent
                pnlHeaderPurchases.BorderColor = pal.Border
                pnlHeaderPurchases.BorderThickness = 1
                pnlHeaderPurchases.BorderRadius = 10

                lblTitlePurchases.ForeColor = pal.TextPrimary
                lblTitlePurchases.BackColor = Color.Transparent
                lblDescPurchases.ForeColor = pal.TextSecondary
                lblDescPurchases.BackColor = Color.Transparent

                ' زر العودة
                btnBackPurchases.FillColor = pal.ButtonSecondaryBackground
                btnBackPurchases.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackPurchases.BorderColor = pal.Border
                btnBackPurchases.BorderThickness = 1
                btnBackPurchases.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackPurchases.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmPurchases, btnfrmPurchaseReports}
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
                Logger.LogError("UCPurchasesHub.vb:96", __logEx)
            End Try
        End Sub

    End Class

End Namespace
