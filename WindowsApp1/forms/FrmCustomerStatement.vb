Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmCustomerStatement

    Private ReadOnly _repo As POSRepository

    Public Sub New()
        InitializeComponent()
        _repo = New POSRepository(DBModule.ConnectionString)
    End Sub

    Private Sub FrmCustomerStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomersCombo()
        dtpFrom.Value = DateTime.Now.AddMonths(-1)
        dtpTo.Value = DateTime.Now
        SetupGrid()


        datagridviewsetup(dgvStatement)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub LoadCustomersCombo()
        Dim custs = _repo.GetActiveCustomers()
        cmbCustomers.DataSource = custs
        cmbCustomers.DisplayMember = "CustomerName"
        cmbCustomers.ValueMember = "CustomerID"
        cmbCustomers.SelectedIndex = -1
    End Sub

    ' تم نقل تعريف وتنسيق الأعمدة إلى الديزاينر FrmCustomerStatement.Designer.vb
    Private Sub SetupGrid()
        dgvStatement.AutoGenerateColumns = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cmbCustomers.SelectedValue Is Nothing Then
            MessageBox.Show("برجاء اختيار العميل أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim custID As Integer = Convert.ToInt32(cmbCustomers.SelectedValue)
        Dim dt As DataTable = _repo.GetCustomerStatement(custID, dtpFrom.Value, dtpTo.Value)
        dgvStatement.DataSource = dt

        ' تجميع وتحديث المؤشرات
        Dim totalDebit As Decimal = 0
        Dim totalCredit As Decimal = 0

        For Each row As DataRow In dt.Rows
            totalDebit += Convert.ToDecimal(row("Debit"))
            totalCredit += Convert.ToDecimal(row("Credit"))
        Next

        lblTotalDebit.Text = totalDebit.ToString("N2") & " ج"
        lblTotalCredit.Text = totalCredit.ToString("N2") & " ج"

        Dim finalBal As Decimal = 0
        If dt.Rows.Count > 0 Then
            finalBal = Convert.ToDecimal(dt.Rows(dt.Rows.Count - 1)("BalanceAfter"))
        End If
        lblFinalBalance.Text = finalBal.ToString("N2") & " ج"
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub
End Class