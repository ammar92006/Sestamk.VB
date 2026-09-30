Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCSalesHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
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
                flpSales.BackColor = pal.Background

                pnlHeaderSales.BackColor = pal.CardBackground
                lblTitleSales.ForeColor = pal.TextPrimary
                lblDescSales.ForeColor = pal.TextSecondary

                btnBackSales.FillColor = pal.ButtonSecondaryBackground
                btnBackSales.ForeColor = pal.ButtonSecondaryForeground
                btnBackSales.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmPOS, btnSalesReturns, btnFrmSalesReport, btnFrmDriverReport, btnKds, btnWaste, btnRes}
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
