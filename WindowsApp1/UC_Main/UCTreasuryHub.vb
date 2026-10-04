Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCTreasuryHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
            ApplyTheme()
        End Sub

        Private Sub btnBackTreasury_Click(sender As Object, e As EventArgs) Handles btnBackTreasury.Click
            RaiseEvent BackRequested(Me, EventArgs.Empty)
        End Sub

        Private Sub btnfrmTreasury_Click(sender As Object, e As EventArgs) Handles btnfrmTreasury.Click
            OpenFormOnce(GetType(frmTreasury), btnfrmTreasury)
        End Sub

        Private Sub btnFrmTreasuryTransfer_Click(sender As Object, e As EventArgs) Handles btnFrmTreasuryTransfer.Click
            OpenFormOnce(GetType(FrmTreasuryTransfer), btnFrmTreasuryTransfer)
        End Sub

        Private Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles btnDeposit.Click
            OpenTreasuryWithOperation(FrmTreasuryTransaction.TreasuryOperation.Deposit, btnDeposit)
        End Sub

        Private Sub btnWithdraw_Click(sender As Object, e As EventArgs) Handles btnWithdraw.Click
            OpenTreasuryWithOperation(FrmTreasuryTransaction.TreasuryOperation.Withdraw, btnWithdraw)
        End Sub

        Private Sub btnFrmTreasuryTransactionsReport_Click(sender As Object, e As EventArgs) Handles btnFrmTreasuryTransactionsReport.Click
            OpenFormOnce(GetType(FrmTreasuryTransactionsReport), btnFrmTreasuryTransactionsReport)
        End Sub

        Private Sub OpenTreasuryWithOperation(op As FrmTreasuryTransaction.TreasuryOperation, btn As Control)
            If Not Session.HasPermission("FrmTreasuryTransaction", "CanOpen") Then
                Dim dispName As String = Session.GetScreenDisplayName("FrmTreasuryTransaction")
                SmartMessageBox.Show("عفواً، ليس لديك صلاحية لفتح شاشة (" & dispName & ")!", "صلاحيات الوصول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim frm As New FrmTreasuryTransaction(op)
            AddHandler frm.Load, Sub(s, ev)
                                     Session.ApplyFormPermissions(frm, "FrmTreasuryTransaction")
                                     ThemeManager.Instance.ApplyTheme(frm)
                                 End Sub
            AddHandler frm.Shown, Sub(s, ev)
                                      Session.ApplyFormPermissions(frm, "FrmTreasuryTransaction")
                                      ThemeManager.Instance.ApplyTheme(frm)
                                  End Sub
            ThemeManager.Instance.ApplyTheme(frm)
            frm.Show()
        End Sub

        Public Sub ApplyPermissions()
            If Session.CurrentRoleID = 1 Then Return

            Dim mappings As New Dictionary(Of Control, String) From {
                {btnfrmTreasury, "frmTreasury"},
                {btnFrmTreasuryTransfer, "FrmTreasuryTransfer"},
                {btnDeposit, "FrmTreasuryTransaction"},
                {btnWithdraw, "FrmTreasuryTransaction"},
                {btnFrmTreasuryTransactionsReport, "FrmTreasuryTransactionsReport"}
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
                flpTreasury.BackColor = pal.Background

                ' بطاقة الهيدر العلوية
                pnlHeaderTreasury.FillColor = pal.CardBackground
                pnlHeaderTreasury.BackColor = Color.Transparent
                pnlHeaderTreasury.BorderColor = pal.Border
                pnlHeaderTreasury.BorderThickness = 1
                pnlHeaderTreasury.BorderRadius = 10

                lblTitleTreasury.ForeColor = pal.TextPrimary
                lblTitleTreasury.BackColor = Color.Transparent
                lblDescTreasury.ForeColor = pal.TextSecondary
                lblDescTreasury.BackColor = Color.Transparent

                ' زر العودة
                btnBackTreasury.FillColor = pal.ButtonSecondaryBackground
                btnBackTreasury.ForeColor = If(isDark, Color.FromArgb(96, 165, 250), pal.Primary)
                btnBackTreasury.BorderColor = pal.Border
                btnBackTreasury.BorderThickness = 1
                btnBackTreasury.HoverState.FillColor = pal.ButtonSecondaryHover
                btnBackTreasury.HoverState.ForeColor = If(isDark, Color.White, pal.Primary)

                ' أزرار وظائف القسم
                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmTreasury, btnFrmTreasuryTransfer, btnDeposit, btnWithdraw, btnFrmTreasuryTransactionsReport}
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
                Logger.LogError("UCTreasuryHub.vb:131", __logEx)
            End Try
        End Sub

    End Class

End Namespace
