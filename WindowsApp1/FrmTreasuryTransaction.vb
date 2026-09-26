Imports System.Data.SqlClient

Public Class FrmTreasuryTransaction

    Private defaultTreasuryid As Integer = -1

    Public Enum TreasuryOperation

        Deposit = 1

        Withdraw = 2

    End Enum
    Private _operation As TreasuryOperation


    Private _x, _y As Integer
    Private _newPoint As New Point

    Public Sub New(operation As TreasuryOperation)

        InitializeComponent()

        _operation = operation



    End Sub
    Private Async Sub FrmTreasuryTransaction_Load() Handles MyBase.Load

        Await LoadTreasuriesAsync()

        dtpTransactionDate.Value = Date.Now

        txtAmount.Text = "0.00"

        If _operation = TreasuryOperation.Deposit Then

            Me.Text = "إيداع نقدية"

            btnSave.Text = "إيداع"

            lbltitle.Text = "ايداع في الخزنة"

        Else

            Me.Text = "سحب نقدية"

            btnSave.Text = "سحب"

            lbltitle.Text = "سحب من الخزنة"


        End If

    End Sub


    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not ValidateData() Then Return

        btnSave.Enabled = False

        Try
            Using cn As SqlConnection = Await NewConnAsync()
                ' فتح الـ Transaction
                Using trans As SqlTransaction = cn.BeginTransaction()
                    Try
                        ' تمرير البيانات مع تحويلات آمنة
                        Await TreasuryService.AddTransactionAsync(
                        treasuryID:=CInt(cmbTreasury.SelectedValue),
                        transactionType:=If(_operation = TreasuryOperation.Deposit,
                                            TreasuryTransactionTypes.ManualDeposit,
                                            TreasuryTransactionTypes.ManualWithdraw),
                        amount:=Convert.ToDecimal(txtAmount.Text),
                        isDeposit:=(_operation = TreasuryOperation.Deposit),
                        referenceID:=0,
                        referenceNo:=txtReferenceNo.Text.Trim(),
                        notes:=txtNotes.Text.Trim(),
                        userID:=Session.CurrentUserID,
                        cn:=cn,
                        trans:=trans)

                        ' إذا وصلنا هنا بدون أخطاء يتم الحفظ نهائياً
                        trans.Commit()
                    Catch
                        ' الـ Using سيتكفل بالـ Rollback تلقائياً عند حدوث Exception والخروج من البلوك
                        Throw
                    End Try
                End Using
            End Using

            MessageBox.Show("تم حفظ الحركة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
            ClearControls()

        Catch ex As Exception
            ShowError(ex.Message)
        Finally
            btnSave.Enabled = True
        End Try

    End Sub

    Private Async Function LoadTreasuriesAsync() As Task

        Try

            Dim dt As New DataTable()

            Using cn As SqlConnection = Await NewConnAsync()

                Const sql As String =
"
SELECT
TreasuryID,
TreasuryNameAr
FROM Treasury
WHERE IsActive = 1
AND IsDeleted = 0
ORDER BY IsDefault DESC, TreasuryNameAr
"

                Using da As New SqlDataAdapter(sql, cn)

                    Await Task.Run(Sub() da.Fill(dt))

                End Using

            End Using
            cmbTreasury.DataSource = dt
            cmbTreasury.DisplayMember = "TreasuryNameAr"
            cmbTreasury.ValueMember = "TreasuryID"
            defaultTreasuryid = SettingsManager.GetIntSetting(SettingsKeys.DefaultTreasuryID, -1)
            If defaultTreasuryid > 0 Then
                cmbTreasury.SelectedValue = defaultTreasuryid
            ElseIf cmbTreasury.Items.Count > 0 Then
                cmbTreasury.SelectedIndex = 0
            End If

        Catch ex As Exception

            ShowError(ex.Message)

        End Try

    End Function
    Private Sub ClearControls()

        cmbTreasury.SelectedIndex = -1

        txtAmount.Text = "0.00"

        txtReferenceNo.Clear()

        txtNotes.Clear()

        dtpTransactionDate.Value = Date.Now

        cmbTreasury.Focus()

    End Sub
    Private Function ValidateData() As Boolean

        If cmbTreasury.SelectedIndex = -1 Then

            ShowWarning("اختر الخزنة.")

            cmbTreasury.Focus()

            Return False

        End If

        Dim amount As Decimal

        If Not Decimal.TryParse(txtAmount.Text, amount) Then

            ShowWarning("المبلغ غير صحيح.")

            txtAmount.Focus()

            Return False

        End If

        If amount <= 0 Then

            ShowWarning("يجب أن يكون المبلغ أكبر من صفر.")

            txtAmount.Focus()

            Return False

        End If

        Return True

    End Function

    Private Sub ShowWarning(msg As String)
        MessageBox.Show(msg, "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Private Sub ShowError(msg As String)
        MessageBox.Show(msg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown, lbltitle.MouseDown
        _x = Control.MousePosition.X - Me.Location.X
        _y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove, lbltitle.MouseMove
        If e.Button = MouseButtons.Left Then
            _newPoint = Control.MousePosition
            _newPoint.X -= _x
            _newPoint.Y -= _y
            Me.Location = _newPoint
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearControls()
    End Sub
End Class