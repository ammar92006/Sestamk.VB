Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCUsersHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
        End Sub

        Private Sub btnBackUsers_Click(sender As Object, e As EventArgs) Handles btnBackUsers.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnfrmUsers_Click(sender As Object, e As EventArgs) Handles btnfrmUsers.Click
            OpenFormOnce(GetType(frmUsers), btnfrmUsers)
        End Sub

        Private Sub btnfrmRolesAndPermissions_Click(sender As Object, e As EventArgs) Handles btnfrmRolesAndPermissions.Click
            OpenFormOnce(GetType(frmRolesAndPermissions), btnfrmRolesAndPermissions)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnfrmUsers, "frmUsers"},
                {btnfrmRolesAndPermissions, "frmRolesAndPermissions"}
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
                flpUsers.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderUsers.FillColor = pal.CardBackground
                pnlHeaderUsers.BackColor = Color.Transparent
                pnlHeaderUsers.BorderColor = pal.Border
                pnlHeaderUsers.BorderThickness = 1
                pnlHeaderUsers.BorderRadius = 10

                lblTitleUsers.ForeColor = pal.TextPrimary
                lblTitleUsers.BackColor = Color.Transparent
                lblDescUsers.ForeColor = pal.TextSecondary
                lblDescUsers.BackColor = Color.Transparent

                ' زر العودة
                btnBackUsers.FillColor = pal.ButtonSecondaryBackground
                btnBackUsers.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackUsers.BorderColor = pal.Border
                btnBackUsers.BorderThickness = 1
                btnBackUsers.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackUsers.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmUsers, btnfrmRolesAndPermissions}
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
                Logger.LogError("UCUsersHub.vb:96", __logEx)
            End Try
        End Sub

    End Class

End Namespace
