Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCExpensesHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
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
                flpExpenses.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderExpenses.FillColor = pal.CardBackground
                pnlHeaderExpenses.BackColor = Color.Transparent
                pnlHeaderExpenses.BorderColor = pal.Border
                pnlHeaderExpenses.BorderThickness = 1
                pnlHeaderExpenses.BorderRadius = 10

                lblTitleExpenses.ForeColor = pal.TextPrimary
                lblTitleExpenses.BackColor = Color.Transparent
                lblDescExpenses.ForeColor = pal.TextSecondary
                lblDescExpenses.BackColor = Color.Transparent

                ' زر العودة
                btnBackExpenses.FillColor = pal.ButtonSecondaryBackground
                btnBackExpenses.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackExpenses.BorderColor = pal.Border
                btnBackExpenses.BorderThickness = 1
                btnBackExpenses.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackExpenses.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnform_Expenses, btnExpensesReportForm}
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
