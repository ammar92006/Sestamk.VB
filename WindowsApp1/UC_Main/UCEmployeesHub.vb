Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCEmployeesHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
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
                flpEmployees.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderEmployees.FillColor = pal.CardBackground
                pnlHeaderEmployees.BackColor = Color.Transparent
                pnlHeaderEmployees.BorderColor = pal.Border
                pnlHeaderEmployees.BorderThickness = 1
                pnlHeaderEmployees.BorderRadius = 10

                lblTitleEmployees.ForeColor = pal.TextPrimary
                lblTitleEmployees.BackColor = Color.Transparent
                lblDescEmployees.ForeColor = pal.TextSecondary
                lblDescEmployees.BackColor = Color.Transparent

                ' زر العودة
                btnBackEmployees.FillColor = pal.ButtonSecondaryBackground
                btnBackEmployees.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackEmployees.BorderColor = pal.Border
                btnBackEmployees.BorderThickness = 1
                btnBackEmployees.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackEmployees.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmEmployees, btnfrmJobTitles, btnfrmDepartments, btnfrmSalarySystems, btnfrmSalaryPayment}
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
                Logger.LogError("UCEmployeesHub.vb:111", __logEx)
            End Try
        End Sub

    End Class

End Namespace
