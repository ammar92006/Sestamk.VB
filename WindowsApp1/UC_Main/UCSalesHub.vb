Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCSalesHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
        End Sub

        Private Sub btnBackSales_Click(sender As Object, e As EventArgs) Handles btnBackSales.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnfrmPOS_Click(sender As Object, e As EventArgs) Handles btnfrmPOS.Click
            OpenFormOnce(GetType(frmPOS), btnfrmPOS)
        End Sub

        Private Sub btnSalesReturns_Click(sender As Object, e As EventArgs) Handles btnSalesReturns.Click
            OpenFormOnce(GetType(Sales_Returns), btnSalesReturns)
        End Sub

        Private Sub btnFrmSalesReport_Click(sender As Object, e As EventArgs) Handles btnFrmSalesReport.Click
            OpenFormOnce(GetType(FrmSalesReport), btnFrmSalesReport)
        End Sub

        Private Sub btnFrmDriverReport_Click(sender As Object, e As EventArgs) Handles btnFrmDriverReport.Click
            OpenFormOnce(GetType(FrmDriverReport), btnFrmDriverReport)
        End Sub

        Private Sub btnKds_Click(sender As Object, e As EventArgs) Handles btnKds.Click
            OpenFormOnce(GetType(FrmKitchenDisplay), btnKds)
        End Sub

        Private Sub btnWaste_Click(sender As Object, e As EventArgs) Handles btnWaste.Click
            OpenFormOnce(GetType(FrmKitchenWaste), btnWaste)
        End Sub

        Private Sub btnRes_Click(sender As Object, e As EventArgs) Handles btnRes.Click
            OpenFormOnce(GetType(FrmTableReservations), btnRes)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnfrmPOS, "frmPOS"},
                {btnSalesReturns, "Sales_Returns"},
                {btnFrmSalesReport, "FrmSalesReport"},
                {btnFrmDriverReport, "FrmDriverReport"},
                {btnKds, "FrmKitchenDisplay"},
                {btnWaste, "FrmKitchenWaste"},
                {btnRes, "FrmTableReservations"}
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
                flpSales.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderSales.FillColor = pal.CardBackground
                pnlHeaderSales.BackColor = Color.Transparent
                pnlHeaderSales.BorderColor = pal.Border
                pnlHeaderSales.BorderThickness = 1
                pnlHeaderSales.BorderRadius = 10

                lblTitleSales.ForeColor = pal.TextPrimary
                lblTitleSales.BackColor = Color.Transparent
                lblDescSales.ForeColor = pal.TextSecondary
                lblDescSales.BackColor = Color.Transparent

                ' زر العودة
                btnBackSales.FillColor = pal.ButtonSecondaryBackground
                btnBackSales.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackSales.BorderColor = pal.Border
                btnBackSales.BorderThickness = 1
                btnBackSales.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackSales.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmPOS, btnSalesReturns, btnFrmSalesReport, btnFrmDriverReport, btnKds, btnWaste, btnRes}
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
