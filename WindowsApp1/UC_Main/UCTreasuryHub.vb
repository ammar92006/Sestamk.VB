Imports System.Windows.Forms
Imports System.Drawing

Namespace UC_Main

    Public Class UCTreasuryHub
        Inherits UserControl

        Public Event BackRequested As EventHandler

        Public Sub New()
            InitializeComponent()
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
                MessageBox.Show("عفواً، ليس لديك صلاحية لفتح شاشة (" & dispName & ")!", "صلاحيات الوصول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                flpTreasury.BackColor = pal.Background

                pnlHeaderTreasury.BackColor = pal.CardBackground
                lblTitleTreasury.ForeColor = pal.TextPrimary
                lblDescTreasury.ForeColor = pal.TextSecondary

                btnBackTreasury.FillColor = pal.ButtonSecondaryBackground
                btnBackTreasury.ForeColor = pal.ButtonSecondaryForeground
                btnBackTreasury.BorderColor = pal.Border

                Dim buttons() As Guna.UI2.WinForms.Guna2Button = {btnfrmTreasury, btnFrmTreasuryTransfer, btnDeposit, btnWithdraw, btnFrmTreasuryTransactionsReport}
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
