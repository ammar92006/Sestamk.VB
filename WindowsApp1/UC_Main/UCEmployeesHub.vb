Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCEmployeesHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBackEmployees_Click(sender As Object, e As EventArgs) Handles btnBackEmployees.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnfrmEmployees_Click(sender As Object, e As EventArgs) Handles btnfrmEmployees.Click
            OpenFormOnce(GetType(frmEmployees), btnfrmEmployees)
        End Sub

        Private Sub btnfrmJobTitles_Click(sender As Object, e As EventArgs) Handles btnfrmJobTitles.Click
            OpenFormOnce(GetType(frmJobTitles), btnfrmJobTitles)
        End Sub

        Private Sub btnfrmDepartments_Click(sender As Object, e As EventArgs) Handles btnfrmDepartments.Click
            OpenFormOnce(GetType(frmDepartments), btnfrmDepartments)
        End Sub

        Private Sub btnfrmSalarySystems_Click(sender As Object, e As EventArgs) Handles btnfrmSalarySystems.Click
            OpenFormOnce(GetType(frmSalarySystems), btnfrmSalarySystems)
        End Sub

        Private Sub btnfrmSalaryPayment_Click(sender As Object, e As EventArgs) Handles btnfrmSalaryPayment.Click
            OpenFormOnce(GetType(frmSalaryPayment), btnfrmSalaryPayment)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnfrmEmployees, "frmEmployees"},
                {btnfrmJobTitles, "frmJobTitles"},
                {btnfrmDepartments, "frmDepartments"},
                {btnfrmSalarySystems, "frmSalarySystems"},
                {btnfrmSalaryPayment, "frmSalaryPayment"}
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
                flpEmployees.BackColor = pal.Background

                pnlHeaderEmployees.BackColor = pal.CardBackground
                lblTitleEmployees.ForeColor = pal.TextPrimary
                lblDescEmployees.ForeColor = pal.TextSecondary

                btnBackEmployees.FillColor = pal.ButtonSecondaryBackground
                btnBackEmployees.ForeColor = pal.ButtonSecondaryForeground
                btnBackEmployees.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmEmployees, btnfrmJobTitles, btnfrmDepartments, btnfrmSalarySystems, btnfrmSalaryPayment}
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
