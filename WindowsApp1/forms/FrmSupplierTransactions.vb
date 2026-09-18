Imports System.Data.SqlClient

Public Class FrmSupplierTransactions
    Private ReadOnly _connString As String = "Server=.;Database=RestaurantDB;Trusted_Connection=True;"
    Private _supplierId As Integer
    Private _supplierName As String
    Private ReadOnly _currentUserId As Integer = 1

    ' Constructor لاستقبال رقم المورد واسمه من الشاشة الرئيسية
    Public Sub New(supplierId As Integer, supplierName As String)
        InitializeComponent()
        _supplierId = supplierId
        _supplierName = supplierName
    End Sub

    'Private Sub FrmSupplierTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    lblHeaderSupplierName.Text = "كشف حساب المورد: " & _supplierName
    '    dtpFromDate.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) ' أول الشهر الحالي
    '    dtpToDate.Value = DateTime.Now

    '    LoadTreasuries()
    '    LoadPaymentMethods()
    '    LoadTransactionTypes()
    '    LoadSupplierBalance()
    '    LoadTransactionsGrid()
    'End Sub

    'Private Sub LoadTreasuries()
    '    Using conn As New SqlConnection(_connString)
    '        Dim query As String = "SELECT TreasuryID, TreasuryName FROM Treasuries WHERE IsActive = 1"
    '        Dim adapter As New SqlDataAdapter(query, conn)
    '        Dim dt As New DataTable()
    '        adapter.Fill(dt)
    '        cmbTreasury.DataSource = dt
    '        cmbTreasury.DisplayMember = "TreasuryName"
    '        cmbTreasury.ValueMember = "TreasuryID"
    '    End Using
    'End Sub

    'Private Sub LoadPaymentMethods()
    '    cmbPaymentMethod.Items.Clear()
    '    cmbPaymentMethod.Items.AddRange(New String() {"نقدي", "تحويل بنكي", "شيك"})
    '    cmbPaymentMethod.SelectedIndex = 0
    'End Sub

    'Private Sub LoadTransactionTypes()
    '    cmbTransactionType.Items.Clear()
    '    cmbTransactionType.Items.AddRange(New String() {"الكل", "فاتورة شراء", "سداد للمورد", "مردودات مشتريات", "رصيد افتتاحي"})
    '    cmbTransactionType.SelectedIndex = 0
    'End Sub

    'Private Sub LoadSupplierBalance()
    '    Using conn As New SqlConnection(_connString)
    '        Dim query As String = "SELECT CurrentBalance FROM Suppliers WHERE SupplierID = @id"
    '        Using cmd As New SqlCommand(query, conn)
    '            cmd.Parameters.AddWithValue("@id", _supplierId)
    '            conn.Open()
    '            Dim bal As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
    '            lblHeaderCurrentBalance.Text = "الرصيد الحالي: " & bal.ToString("N2")
    '            lblHeaderCurrentBalance.ForeColor = If(bal > 0, Color.DarkRed, Color.DarkGreen)
    '        End Using
    '    End Using
    'End Sub

    'Public Sub LoadTransactionsGrid()
    '    Using conn As New SqlConnection(_connString)
    '        Dim query As String = "SELECT TransactionID, TransactionDate, TransactionType, ReferenceType, ReferenceID, " &
    '                             "CreditAmount, DebitAmount, BalanceAfter, PaymentMethod, Notes " &
    '                             "FROM SupplierTransactions " &
    '                             "WHERE SupplierID = @SupplierID AND TransactionDate BETWEEN @FromDate AND @ToDate "

    '        If cmbTransactionType.SelectedIndex > 0 Then
    '            query &= " AND TransactionType = @TxType "
    '        End If

    '        query &= " ORDER BY TransactionID ASC"

    '        Using cmd As New SqlCommand(query, conn)
    '            cmd.Parameters.AddWithValue("@SupplierID", _supplierId)
    '            cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
    '            cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date.AddDays(1).AddTicks(-1))

    '            If cmbTransactionType.SelectedIndex > 0 Then
    '                cmd.Parameters.AddWithValue("@TxType", cmbTransactionType.SelectedItem.ToString())
    '            End If

    '            Dim adapter As New SqlDataAdapter(cmd)
    '            Dim dt As New DataTable()
    '            adapter.Fill(dt)
    '            dgvTransactions.DataSource = dt
    '            FormatTransactionsGrid()
    '        End Using
    '    End Using
    'End Sub

    'Private Sub FormatTransactionsGrid()
    '    If dgvTransactions.Columns("TransactionID") IsNot Nothing Then dgvTransactions.Columns("TransactionID").HeaderText = "رقم الحركة"
    '    If dgvTransactions.Columns("TransactionDate") IsNot Nothing Then dgvTransactions.Columns("TransactionDate").HeaderText = "التاريخ"
    '    If dgvTransactions.Columns("TransactionType") IsNot Nothing Then dgvTransactions.Columns("TransactionType").HeaderText = "نوع الحركة"
    '    If dgvTransactions.Columns("ReferenceType") IsNot Nothing Then dgvTransactions.Columns("ReferenceType").HeaderText = "المرجع"
    '    If dgvTransactions.Columns("ReferenceID") IsNot Nothing Then dgvTransactions.Columns("ReferenceID").HeaderText = "رقم المستند"
    '    If dgvTransactions.Columns("CreditAmount") IsNot Nothing Then
    '        dgvTransactions.Columns("CreditAmount").HeaderText = "دائن (+علينا)"
    '        dgvTransactions.Columns("CreditAmount").DefaultCellStyle.Format = "N2"
    '    End If
    '    If dgvTransactions.Columns("DebitAmount") IsNot Nothing Then
    '        dgvTransactions.Columns("DebitAmount").HeaderText = "مدين (-سداد)"
    '        dgvTransactions.Columns("DebitAmount").DefaultCellStyle.Format = "N2"
    '    End If
    '    If dgvTransactions.Columns("BalanceAfter") IsNot Nothing Then
    '        dgvTransactions.Columns("BalanceAfter").HeaderText = "الرصيد التراكمي"
    '        dgvTransactions.Columns("BalanceAfter").DefaultCellStyle.Format = "N2"
    '    End If
    '    If dgvTransactions.Columns("PaymentMethod") IsNot Nothing Then dgvTransactions.Columns("PaymentMethod").HeaderText = "طريقة الدفع"
    '    If dgvTransactions.Columns("Notes") IsNot Nothing Then dgvTransactions.Columns("Notes").HeaderText = "البيان"
    'End Sub

    'Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
    '    LoadTransactionsGrid()
    'End Sub

    '' تنفيذ عملية سداد لمورد وتحديث رصيد الخزينة ورصيد المورد
    'Private Sub btnSavePayment_Click(sender As Object, e As EventArgs) Handles btnSavePayment.Click
    '    If numPaymentAmount.Value <= 0 Then
    '        MessageBox.Show("يرجى إدخال مبلغ سداد صحيح أكبر من الصفر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    If cmbTreasury.SelectedValue Is Nothing Then
    '        MessageBox.Show("يرجى تحديد الخزينة التي سيتم الصرف منها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    Using conn As New SqlConnection(_connString)
    '        conn.Open()
    '        Dim trans As SqlTransaction = conn.BeginTransaction()

    '        Try
    '            ' 1. جلب الرصيد الحالي للمورد للعمليات الحسابية
    '            Dim currentBal As Decimal = 0
    '            Dim getBalQuery As String = "SELECT CurrentBalance FROM Suppliers WITH (UPDLOCK) WHERE SupplierID = @SupplierID"
    '            Using cmdGetBal As New SqlCommand(getBalQuery, conn, trans)
    '                cmdGetBal.Parameters.AddWithValue("@SupplierID", _supplierId)
    '                currentBal = Convert.ToDecimal(cmdGetBal.ExecuteScalar())
    '            End Using

    '            Dim newBal As Decimal = currentBal - numPaymentAmount.Value

    '            ' 2. إضافة حركة جديدة في جدول SupplierTransactions
    '            Dim insertTxQuery As String = "INSERT INTO SupplierTransactions " &
    '                "(SupplierID, TransactionDate, TransactionType, ReferenceType, CreditAmount, DebitAmount, BalanceAfter, PaymentMethod, TreasuryID, Notes, CreatedByUserID) " &
    '                "VALUES (@SupplierID, GETDATE(), N'سداد للمورد', 'PaymentVoucher', 0.00, @Amount, @BalanceAfter, @Method, @TreasuryID, @Notes, @UserID);"

    '            Using cmdTx As New SqlCommand(insertTxQuery, conn, trans)
    '                cmdTx.Parameters.AddWithValue("@SupplierID", _supplierId)
    '                cmdTx.Parameters.AddWithValue("@Amount", numPaymentAmount.Value)
    '                cmdTx.Parameters.AddWithValue("@BalanceAfter", newBal)
    '                cmdTx.Parameters.AddWithValue("@Method", cmbPaymentMethod.SelectedItem.ToString())
    '                cmdTx.Parameters.AddWithValue("@TreasuryID", cmbTreasury.SelectedValue)
    '                cmdTx.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtPaymentNotes.Text), "سداد دفعة للمورد", txtPaymentNotes.Text.Trim()))
    '                cmdTx.Parameters.AddWithValue("@UserID", _currentUserId)
    '                cmdTx.ExecuteNonQuery()
    '            End Using

    '            ' 3. تحديث الرصيد الحالي للمورد
    '            Dim updateBalQuery As String = "UPDATE Suppliers SET CurrentBalance = @NewBalance WHERE SupplierID = @SupplierID"
    '            Using cmdUp As New SqlCommand(updateBalQuery, conn, trans)
    '                cmdUp.Parameters.AddWithValue("@NewBalance", newBal)
    '                cmdUp.Parameters.AddWithValue("@SupplierID", _supplierId)
    '                cmdUp.ExecuteNonQuery()
    '            End Using

    '            trans.Commit()
    '            MessageBox.Show("تم تسجيل عملية السداد بنجاح وتحديث الحسابات.", "تمت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            ' إعادة تعيين حقول السداد وتحديث البيانات
    '            numPaymentAmount.Value = 0
    '            txtPaymentNotes.Text = String.Empty
    '            LoadSupplierBalance()
    '            LoadTransactionsGrid()

    '        Catch ex As Exception
    '            trans.Rollback()
    '            MessageBox.Show($"حدث خطأ أثناء حفظ حركة السداد: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Using
    'End Sub
End Class