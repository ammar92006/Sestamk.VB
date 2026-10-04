Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCSettingsHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
        End Sub

        Private Sub btnBackSettings_Click(sender As Object, e As EventArgs) Handles btnBackSettings.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
            OpenFormOnce(GetType(Settings), btnSettings)
        End Sub

        Private Sub btnfrmPrinters_Click(sender As Object, e As EventArgs) Handles btnfrmPrinters.Click
            OpenFormOnce(GetType(frmPrinters), btnfrmPrinters)
        End Sub

        Private Sub btnBackups_Click(sender As Object, e As EventArgs) Handles btnBackups.Click
            OpenFormOnce(GetType(Backup), btnBackups)
        End Sub

        Private Sub btnfrmRestaurantSections_Click(sender As Object, e As EventArgs) Handles btnfrmRestaurantSections.Click
            OpenFormOnce(GetType(frmRestaurantSections), btnfrmRestaurantSections)
        End Sub

        Private Sub btnfrmRestaurantTables_Click(sender As Object, e As EventArgs) Handles btnfrmRestaurantTables.Click
            OpenFormOnce(GetType(frmRestaurantTables), btnfrmRestaurantTables)
        End Sub

        Private Sub btnfrmColors_Click(sender As Object, e As EventArgs) Handles btnfrmColors.Click
            OpenFormOnce(GetType(frmColors), btnfrmColors)
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnSettings, "Settings"},
                {btnfrmPrinters, "frmPrinters"},
                {btnBackups, "Backup"},
                {btnfrmRestaurantSections, "frmRestaurantSections"},
                {btnfrmRestaurantTables, "frmRestaurantTables"},
                {btnfrmColors, "frmColors"}
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
                flpSettings.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderSettings.FillColor = pal.CardBackground
                pnlHeaderSettings.BackColor = Color.Transparent
                pnlHeaderSettings.BorderColor = pal.Border
                pnlHeaderSettings.BorderThickness = 1
                pnlHeaderSettings.BorderRadius = 10

                lblTitleSettings.ForeColor = pal.TextPrimary
                lblTitleSettings.BackColor = Color.Transparent
                lblDescSettings.ForeColor = pal.TextSecondary
                lblDescSettings.BackColor = Color.Transparent

                ' زر العودة
                btnBackSettings.FillColor = pal.ButtonSecondaryBackground
                btnBackSettings.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackSettings.BorderColor = pal.Border
                btnBackSettings.BorderThickness = 1
                btnBackSettings.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackSettings.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnSettings, btnfrmPrinters, btnBackups, btnfrmRestaurantSections, btnfrmRestaurantTables, btnfrmColors}
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
                Logger.LogError("UCSettingsHub.vb:116", __logEx)
            End Try
        End Sub

    End Class

End Namespace
