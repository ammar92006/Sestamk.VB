Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCExpensesHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBackExpenses_Click(sender As Object, e As EventArgs) Handles btnBackExpenses.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnform_Expenses_Click(sender As Object, e As EventArgs) Handles btnform_Expenses.Click
            OpenFormOnce(GetType(form_Expenses), btnform_Expenses)
        End Sub

        Private Sub btnExpensesReportForm_Click(sender As Object, e As EventArgs) Handles btnExpensesReportForm.Click
            OpenFormOnce(GetType(ExpensesReportForm), btnExpensesReportForm)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnform_Expenses, "form_Expenses"},
                {btnExpensesReportForm, "ExpensesReportForm"}
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
                flpExpenses.BackColor = pal.Background

                pnlHeaderExpenses.BackColor = pal.CardBackground
                lblTitleExpenses.ForeColor = pal.TextPrimary
                lblDescExpenses.ForeColor = pal.TextSecondary

                btnBackExpenses.FillColor = pal.ButtonSecondaryBackground
                btnBackExpenses.ForeColor = pal.ButtonSecondaryForeground
                btnBackExpenses.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnform_Expenses, btnExpensesReportForm}
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
