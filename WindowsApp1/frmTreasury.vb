Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Guna.UI2.WinForms
Imports WindowsApp1.FrmTreasuryTransaction

Public Class frmTreasury


#Region "Variables"
    Private _x, _y As Integer
    Private _newPoint As New Point

    Private _treasuryId As Integer = 0
    Private _isLoading As Boolean = False

#End Region


    Private Async Sub Treasury_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Await LoadTreasuryAsync()
        SetupDataGridView(dgvTreasury)

        cmbSearchBy.Items.Clear()

        cmbSearchBy.Items.Add("الكل")
        cmbSearchBy.Items.Add("كود الخزنة")
        cmbSearchBy.Items.Add("اسم الخزنة")
        cmbSearchBy.Items.Add("الاسم الإنجليزي")
        cmbSearchBy.Items.Add("الحالة")
        cmbSearchBy.Items.Add("الافتراضية")

        cmbSearchBy.SelectedIndex = 0

        ClearControls()

    End Sub
    Private Async Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        Await RefreshDataAsync()

    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearControls()

    End Sub
    'Private Async Sub btnAdd_Click(sender As Object,
    '                           e As EventArgs) Handles btnAdd.Click

    '    If Not Await ValidateTreasuryAsync() Then Exit Sub

    '    Try

    '        Using cn As SqlConnection = Await NewConnAsync()

    '            Using trans = cn.BeginTransaction()

    '                Try

    '                    'If chkIsDefault.Checked Then

    '                    '    Dim cmdDefault As New SqlCommand(
    '                    '            "UPDATE Treasury SET IsDefault=0",
    '                    '            cn,
    '                    '            trans)

    '                    '    Await cmdDefault.ExecuteNonQueryAsync()

    '                    'End If

    '                    Dim sql As String =
    '                    "INSERT INTO Treasury
    '                    (
    '                    TreasuryCode,
    '                    TreasuryNameAr,
    '                    Description,
    '                    OpeningBalance,
    '                    CurrentBalance,
    '                    IsActive,
    '                    CreatedDate
    '                    )
    '                    VALUES
    '                    (
    '                    @TreasuryCode,
    '                    @TreasuryNameAr,
    '                    @Description,
    '                    @OpeningBalance,
    '                    @CurrentBalance,
    '                    @IsActive,
    '                    GETDATE()
    '                    )"

    '                    Using cmd As New SqlCommand(sql, cn, trans)

    '                        cmd.Parameters.AddWithValue("@TreasuryCode", txtTreasuryCode.Text.Trim())

    '                        cmd.Parameters.AddWithValue("@TreasuryNameAr", txtTreasuryNameAr.Text.Trim())

    '                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())

    '                        cmd.Parameters.AddWithValue("@OpeningBalance", Convert.ToDecimal(txtOpeningBalance.Text))

    '                        cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(txtOpeningBalance.Text))

    '                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked)

    '                        Await cmd.ExecuteNonQueryAsync()

    '                    End Using


    '                    ' الحصول على ID الخزنة الجديدة
    '                    Dim TreasuryID As Integer

    '                    Using cmdID As New SqlCommand("SELECT CAST(SCOPE_IDENTITY() AS INT)", cn, trans)

    '                        TreasuryID = Convert.ToInt32(Await cmdID.ExecuteScalarAsync())

    '                    End Using

    '                    ' لو فيه رصيد افتتاحى
    '                    If Convert.ToDecimal(txtOpeningBalance.Text) > 0 Then

    '                        Dim sqlTransaction As String =
    '                            "INSERT INTO TreasuryTransactions
    '                            (
    '                            TreasuryID,
    '                            TransactionDate,
    '                            TransactionType,
    '                            ReferenceID,
    '                            ReferenceNo,
    '                            Amount,
    '                            IsDeposit,
    '                            Notes,
    '                            CreatedDate
    '                            )
    '                            VALUES
    '                            (
    '                            @TreasuryID,
    '                            GETDATE(),
    '                            @TransactionType,
    '                            NULL,
    '                            NULL,
    '                            @Amount,
    '                            1,
    '                            @Notes,
    '                            GETDATE()
    '                            )"

    '                        Using cmd As New SqlCommand(sqlTransaction, cn, trans)

    '                            cmd.Parameters.AddWithValue("@TreasuryID", TreasuryID)

    '                            cmd.Parameters.AddWithValue("@TransactionType", 1) ' Opening Balance

    '                            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtOpeningBalance.Text))

    '                            cmd.Parameters.AddWithValue("@Notes", "الرصيد الافتتاحى للخزنة")

    '                            Await cmd.ExecuteNonQueryAsync()

    '                        End Using

    '                    End If

    '                    Dim UpdateBalance As String =
    '                        "UPDATE Treasury
    '                        SET CurrentBalance=
    '                        (
    '                        SELECT
    '                        ISNULL(SUM(
    '                        CASE
    '                        WHEN IsDeposit=1 THEN Amount
    '                        ELSE -Amount
    '                        END),0)
    '                        FROM TreasuryTransactions
    '                        WHERE TreasuryID=@TreasuryID
    '                        )
    '                        WHERE TreasuryID=@TreasuryID"

    '                    Using cmd As New SqlCommand(UpdateBalance, cn, trans)

    '                        cmd.Parameters.AddWithValue("@TreasuryID", TreasuryID)

    '                        Await cmd.ExecuteNonQueryAsync()

    '                    End Using

    '                    trans.Commit()

    '                Catch

    '                    trans.Rollback()

    '                    Throw

    '                End Try

    '            End Using

    '        End Using

    '        MessageBox.Show("تم إضافة الخزنة بنجاح.",
    '                    "نجاح",
    '                    MessageBoxButtons.OK,
    '                    MessageBoxIcon.Information)

    '        ClearControls()

    '        Await RefreshDataAsync()

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message,
    '                    "خطأ",
    '                    MessageBoxButtons.OK,
    '                    MessageBoxIcon.Error)

    '    End Try

    'End Sub


    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If Not Await ValidateTreasuryAsync() Then Exit Sub

        Try
            Using cn As SqlConnection = Await NewConnAsync()
                Using trans = cn.BeginTransaction()
                    Try
                        'If chkIsDefault.Checked Then
                        '    Dim cmdDefault As New SqlCommand(
                        '        "UPDATE Treasury SET IsDefault=0",
                        '        cn,
                        '        trans)
                        '    Await cmdDefault.ExecuteNonQueryAsync()
                        'End If

                        ' تم إضافة SELECT CAST(SCOPE_IDENTITY() AS INT) في نهاية نص الاستعلام
                        Dim sql As String =
                    "INSERT INTO Treasury
                    (
                    TreasuryCode,
                    TreasuryNameAr,
                    Description,
                    OpeningBalance,
                    CurrentBalance,
                    IsActive,
                    CreatedDate
                    )
                    VALUES
                    (
                    @TreasuryCode,
                    @TreasuryNameAr,
                    @Description,
                    @OpeningBalance,
                    @CurrentBalance,
                    @IsActive,
                    GETDATE()
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);"

                        Dim TreasuryID As Integer = 0

                        Using cmd As New SqlCommand(sql, cn, trans)
                            cmd.Parameters.AddWithValue("@TreasuryCode", txtTreasuryCode.Text.Trim())
                            cmd.Parameters.AddWithValue("@TreasuryNameAr", txtTreasuryNameAr.Text.Trim())
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                            cmd.Parameters.AddWithValue("@OpeningBalance", Convert.ToDecimal(txtOpeningBalance.Text))
                            cmd.Parameters.AddWithValue("@CurrentBalance", Convert.ToDecimal(txtOpeningBalance.Text))
                            cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked)

                            ' استخدام ExecuteScalarAsync للحصول على المعرف تلقائياً وتجنب الـ DBNull
                            Dim resultID = Await cmd.ExecuteScalarAsync()

                            If resultID IsNot Nothing AndAlso resultID IsNot DBNull.Value Then
                                TreasuryID = Convert.ToInt32(resultID)
                            Else
                                Throw New Exception("فشل في الحصول على معرف الخزنة الجديدة. تأكد من أن الحقل Identity في قاعدة البيانات.")
                            End If
                        End Using


                        ' لو فيه رصيد افتتاحى
                        If Convert.ToDecimal(txtOpeningBalance.Text) > 0 Then

                            Dim sqlTransaction As String =
                            "INSERT INTO TreasuryTransactions
                            (
                            TreasuryID,
                            TransactionDate,
                            TransactionType,
                            ReferenceID,
                            ReferenceNo,
                            Amount,
                            IsDeposit,
                            Notes,
                            CreatedDate
                            )
                            VALUES
                            (
                            @TreasuryID,
                            GETDATE(),
                            @TransactionType,
                            NULL,
                            NULL,
                            @Amount,
                            1,
                            @Notes,
                            GETDATE()
                            )"

                            Using cmd As New SqlCommand(sqlTransaction, cn, trans)
                                cmd.Parameters.AddWithValue("@TreasuryID", TreasuryID)
                                cmd.Parameters.AddWithValue("@TransactionType", 1) ' Opening Balance
                                cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtOpeningBalance.Text))
                                cmd.Parameters.AddWithValue("@Notes", "الرصيد الافتتاحى للخزنة")

                                Await cmd.ExecuteNonQueryAsync()
                            End Using

                        End If

                        Dim UpdateBalance As String =
                        "UPDATE Treasury
                        SET CurrentBalance=
                        (
                        SELECT
                        ISNULL(SUM(
                        CASE
                        WHEN IsDeposit=1 THEN Amount
                        ELSE -Amount
                        END),0)
                        FROM TreasuryTransactions
                        WHERE TreasuryID=@TreasuryID
                        )
                        WHERE TreasuryID=@TreasuryID"

                        Using cmd As New SqlCommand(UpdateBalance, cn, trans)
                            cmd.Parameters.AddWithValue("@TreasuryID", TreasuryID)

                            Await cmd.ExecuteNonQueryAsync()
                        End Using

                        trans.Commit()

                    Catch
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            MessageBox.Show("تم إضافة الخزنة بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

            ClearControls()

            Await RefreshDataAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        End Try

    End Sub

    Private Async Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If _treasuryId = 0 Then

            MessageBox.Show("يرجى اختيار خزنة أولاً.")

            Exit Sub

        End If

        If Not Await ValidateTreasuryAsync() Then Exit Sub

        Try

            Using cn As SqlConnection = Await NewConnAsync()

                Using trans = cn.BeginTransaction()

                    Try

                        'If chkIsDefault.Checked Then

                        '    Dim cmdDefault As New SqlCommand(
                        '"UPDATE Treasury SET IsDefault=0",
                        'cn,
                        'trans)

                        '    Await cmdDefault.ExecuteNonQueryAsync()

                        'End If

                        Dim sql As String =
"
UPDATE Treasury
SET

TreasuryCode=@TreasuryCode,

TreasuryNameAr=@TreasuryNameAr,


Description=@Description,

IsActive=@IsActive,

ModifiedDate=GETDATE()

WHERE TreasuryID=@TreasuryID
"

                        Using cmd As New SqlCommand(sql, cn, trans)

                            cmd.Parameters.AddWithValue("@TreasuryCode", txtTreasuryCode.Text.Trim())

                            cmd.Parameters.AddWithValue("@TreasuryNameAr", txtTreasuryNameAr.Text.Trim())

                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())

                            cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked)

                            cmd.Parameters.AddWithValue("@TreasuryID", _treasuryId)

                            Await cmd.ExecuteNonQueryAsync()

                        End Using

                        trans.Commit()

                    Catch

                        trans.Rollback()

                        Throw

                    End Try

                End Using

            End Using

            MessageBox.Show("تم تعديل الخزنة بنجاح.")

            Await RefreshDataAsync()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If _treasuryId = 0 Then

            MessageBox.Show("يرجى اختيار خزنة أولاً.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

            Exit Sub

        End If

        'If chkIsDefault.Checked Then

        '    MessageBox.Show("لا يمكن حذف الخزنة الافتراضية.",
        '                "تنبيه",
        '                MessageBoxButtons.OK,
        '                MessageBoxIcon.Warning)

        '    Exit Sub

        'End If

        If Await TreasuryService.HasTransactionsAsync(_treasuryId) Then

            MessageBox.Show("لا يمكن حذف الخزنة لأنها تحتوي على حركات مالية.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

            Exit Sub

        End If

        If MessageBox.Show("هل تريد حذف الخزنة؟",
                       "تأكيد الحذف",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.No Then

            Exit Sub

        End If

        Try

            Using cn As SqlConnection = Await NewConnAsync()

                Dim sql As String =
"UPDATE Treasury
SET
IsDeleted = 1,
ModifiedDate = GETDATE()
WHERE TreasuryID = @TreasuryID"

                Using cmd As New SqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue("@TreasuryID", _treasuryId)

                    Await cmd.ExecuteNonQueryAsync()

                End Using

            End Using

            MessageBox.Show("تم حذف الخزنة بنجاح.",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

            ClearControls()

            Await RefreshDataAsync()

        Catch ex As Exception

            MessageBox.Show(ex.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub dgvTreasury_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTreasury.SelectionChanged

        If _isLoading Then Exit Sub

        If dgvTreasury.CurrentRow Is Nothing Then Exit Sub

        Try

            _treasuryId =
            Convert.ToInt32(dgvTreasury.CurrentRow.Cells("TreasuryID").Value)

            txtTreasuryCode.Text =
            dgvTreasury.CurrentRow.Cells("TreasuryCode").Value.ToString()

            txtTreasuryNameAr.Text =
            dgvTreasury.CurrentRow.Cells("TreasuryNameAr").Value.ToString()

            txtOpeningBalance.Text =
            dgvTreasury.CurrentRow.Cells("OpeningBalance").Value

            txtCurrentBalance.Text =
            dgvTreasury.CurrentRow.Cells("CurrentBalance").Value

            txtCreatedDate.Text =
            dgvTreasury.CurrentRow.Cells("CreatedDate").Value.ToString()

            txtModifiedDate.Text =
            dgvTreasury.CurrentRow.Cells("ModifiedDate").Value.ToString()

            txtDescription.Text =
            dgvTreasury.CurrentRow.Cells("Description").Value.ToString()

            'chkIsDefault.Checked =
            'Convert.ToBoolean(dgvTreasury.CurrentRow.Cells("IsDefault").Value)

            chkIsActive.Checked =
            Convert.ToBoolean(dgvTreasury.CurrentRow.Cells("IsActive").Value)

            txtOpeningBalance.ReadOnly = True

            txtCurrentBalance.ReadOnly = True

        Catch

        End Try

    End Sub
    Private Async Function LoadTreasuryAsync() As Task

        Try

            _isLoading = True

            Dim dt As New DataTable()

            Using cn As SqlConnection = Await NewConnAsync()

                Dim sql As String =
                                    "
                                    SELECT
                                    TreasuryID,
                                    TreasuryCode,
                                    TreasuryNameAr,
                                    OpeningBalance ,
                                    CurrentBalance ,
                                    Description,
                                    IsActive,
                                    CreatedDate,
                                    ModifiedDate
                                    FROM Treasury
                                    Where IsDeleted = 0
                                    ORDER BY TreasuryCode ASC"

                Using da As New SqlDataAdapter(sql, cn)

                    Await Task.Run(Sub()
                                       da.Fill(dt)
                                   End Sub)

                End Using

            End Using

            dgvTreasury.DataSource = dt

            FormatGrid()
            dgvTreasury.ClearSelection()
        Catch ex As Exception

            MessageBox.Show(ex.Message,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Finally

            _isLoading = False

        End Try

    End Function


    Private Async Function RefreshDataAsync() As Task

        Dim SelectedID As Integer = _treasuryId

        Await LoadTreasuryAsync()

        If SelectedID = 0 Then Exit Function

        For Each row As DataGridViewRow In dgvTreasury.Rows

            If Convert.ToInt32(row.Cells("TreasuryID").Value) = SelectedID Then

                row.Selected = True

                dgvTreasury.CurrentCell = row.Cells(1)

                Exit For

            End If

        Next

    End Function

    Private Sub FormatGrid()

        With dgvTreasury

            .AutoGenerateColumns = True

            .AllowUserToAddRows = False

            .AllowUserToDeleteRows = False

            .ReadOnly = True

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .MultiSelect = False

            .RowHeadersVisible = False

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .Columns("TreasuryID").Visible = False

            .Columns("TreasuryCode").HeaderText = "كود الخزنة"

            .Columns("TreasuryNameAr").HeaderText = "اسم الخزنة"

            .Columns("OpeningBalance").HeaderText = "الرصيد الافتتاحى"

            .Columns("CurrentBalance").HeaderText = "الرصيد الحالى"

            .Columns("IsActive").HeaderText = "نشطة"

            .Columns("Description").HeaderText = "الوصف"

            .Columns("CreatedDate").HeaderText = "تاريخ الاضافة"

            .Columns("ModifiedDate").HeaderText = "تاريخ التعديل"

            .Columns("OpeningBalance").DefaultCellStyle.Format = "N2"

            .Columns("CurrentBalance").DefaultCellStyle.Format = "N2"

            '.Columns("الرصيد الافتتاحى").DefaultCellStyle.Alignment =
            '    DataGridViewContentAlignment.MiddleCenter

            '.Columns("الرصيد الحالى").DefaultCellStyle.Alignment =
            '    DataGridViewContentAlignment.MiddleCenter

        End With

    End Sub
    Private Sub SetupDataGridView(ByVal dgv As DataGridView)
        Main.datagridviewsetup(dgv)
        dgv.BorderStyle = BorderStyle.None

        With dgv
            For Each col As DataGridViewColumn In .Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            _newPoint = Control.MousePosition
            _newPoint.X -= _x
            _newPoint.Y -= _y
            Me.Location = _newPoint
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        _x = Control.MousePosition.X - Me.Location.X
        _y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        WindowState = If(WindowState = FormWindowState.Normal,
                     FormWindowState.Maximized, FormWindowState.Normal)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub ClearControls()

        _treasuryId = 0

        txtSearch.Clear()

        txtTreasuryCode.Text = GetNextCode("Treasuries", "TreasuryCode").ToString()

        txtTreasuryNameAr.Clear()

        txtOpeningBalance.Text = "0.00"

        txtCurrentBalance.Text = "0.00"

        txtDescription.Clear()

        txtCreatedDate.Clear()

        txtModifiedDate.Clear()

        txtOpeningBalance.ReadOnly = True

        txtCurrentBalance.ReadOnly = True

        'chkIsDefault.Checked = False

        chkIsActive.Checked = True

        txtTreasuryCode.Focus()

        dgvTreasury.ClearSelection()

    End Sub

    Private Async Function SearchTreasuryAsync() As Task

        Try

            Dim dt As New DataTable()

            Using cn As SqlConnection = Await NewConnAsync()

                Dim sql As String =
                                "SELECT
                                TreasuryID,
                                TreasuryCode ,
                                TreasuryNameAr,
                                OpeningBalance,
                                CurrentBalance,
                                IsActive,
                                Description,
                                CreatedDate,
                                ModifiedDate
                                FROM Treasury
                                WHERE IsDeleted=0 "

                Dim SearchValue As String = txtSearch.Text.Trim()

                Select Case cmbSearchBy.Text

                    Case "كود الخزنة"

                        sql &= " AND TreasuryCode LIKE @Search "

                    Case "اسم الخزنة"

                        sql &= " AND TreasuryNameAr LIKE @Search "

                    Case "الحالة"

                        If SearchValue = "نشطة" Then

                            sql &= " AND IsActive=1 "

                        ElseIf SearchValue = "غير نشطة" Then

                            sql &= " AND IsActive=0 "

                        End If


                    Case Else

                        sql &= "
                        AND
                        (
                        TreasuryCode LIKE @Search
                        OR TreasuryNameAr LIKE @Search
                        )"

                End Select

                sql &= " ORDER BY TreasuryID ASC "

                Using cmd As New SqlCommand(sql, cn)

                    If sql.Contains("@Search") Then

                        cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 100).Value = "%" & SearchValue & "%"

                    End If

                    Using da As New SqlDataAdapter(cmd)

                        Await Task.Run(Sub() da.Fill(dt))

                    End Using

                End Using

            End Using

            dgvTreasury.DataSource = dt

            FormatGrid()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Function

    Private Async Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Await SearchTreasuryAsync()
    End Sub

    Private Async Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        txtSearch.Clear()

        txtSearch.Focus()

        Await SearchTreasuryAsync()
    End Sub

    Private Async Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles btnDeposit.Click
        Using frm As New FrmTreasuryTransaction(TreasuryOperation.Deposit)
            ' فحص ما إذا كان المستخدم قد أتم العملية بنجاح
            If frm.ShowDialog() = DialogResult.OK Then
                ' تحديث بيانات الخزنة فوراً
                Await LoadTreasuryAsync()
            End If
        End Using
    End Sub

    Private Async Sub btnWithdraw_Click(sender As Object, e As EventArgs) Handles btnWithdraw.Click
        Using frm As New FrmTreasuryTransaction(TreasuryOperation.Withdraw)
            ' فحص نجاح العملية
            If frm.ShowDialog() = DialogResult.OK Then
                Await LoadTreasuryAsync()
            End If
        End Using
    End Sub

    Private Async Sub btnOpenTransferForm_Click(sender As Object, e As EventArgs) Handles btnOpenTransferForm.Click
        Using frm As New FrmTreasuryTransfer()
            ' فحص نجاح عملية التحويل
            If frm.ShowDialog() = DialogResult.OK Then
                Await LoadTreasuryAsync()
            End If
        End Using
    End Sub

    Private Sub btnTreasuryTransactionsReport_Click(sender As Object, e As EventArgs) Handles btnTreasuryTransactionsReport.Click
        Try
            ' إنشاء كائن جديد من فورم الحركات
            Dim frm As New FrmTreasuryTransactionsReport()

            ' فتح الفورم بشكل عادي ليتنقل المستخدم بين الشاشات بحرية
            frm.Show()

        Catch ex As Exception
            MessageBox.Show("خطأ أثناء فتح شاشة الحركات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Function ValidateTreasuryAsync() As Task(Of Boolean)
        If String.IsNullOrWhiteSpace(txtTreasuryCode.Text) Then
            txtTreasuryCode.Text = GetNextCode("Treasuries", "TreasuryCode").ToString()
        End If

        If String.IsNullOrWhiteSpace(txtTreasuryCode.Text) Then
            MessageBox.Show("يرجى إدخال كود الخزنة.",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

            txtTreasuryCode.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtTreasuryNameAr.Text) Then
            MessageBox.Show("يرجى إدخال اسم الخزنة.",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

            txtTreasuryNameAr.Focus()
            Return False
        End If

        Dim OpeningBalance As Decimal

        If Not Decimal.TryParse(txtOpeningBalance.Text, OpeningBalance) Then

            MessageBox.Show("الرصيد الافتتاحى غير صحيح.",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

            txtOpeningBalance.Focus()

            Return False

        End If

        Using cn As SqlConnection = Await NewConnAsync()

            Dim sql As String =
    "SELECT COUNT(*)
FROM Treasury
WHERE TreasuryCode=@Code
AND TreasuryID<>@ID"

            Using cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@Code", txtTreasuryCode.Text.Trim())
                cmd.Parameters.AddWithValue("@ID", _treasuryId)

                If Convert.ToInt32(Await cmd.ExecuteScalarAsync()) > 0 Then

                    MessageBox.Show("كود الخزنة مستخدم من قبل.",
                                    "تنبيه",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)

                    txtTreasuryCode.Focus()

                    Return False

                End If

            End Using

            sql =
                            "SELECT COUNT(*)
                                FROM Treasury
                                WHERE TreasuryNameAr=@Name
                                AND TreasuryID<>@ID"

            Using cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@Name", txtTreasuryNameAr.Text.Trim())
                cmd.Parameters.AddWithValue("@ID", _treasuryId)

                If Convert.ToInt32(Await cmd.ExecuteScalarAsync()) > 0 Then

                    MessageBox.Show("اسم الخزنة موجود بالفعل.",
                                    "تنبيه",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)

                    txtTreasuryNameAr.Focus()

                    Return False

                End If

            End Using

        End Using

        Return True

    End Function

    'Public Shared Async Function UpdateTreasuryBalanceAsync(
    'TreasuryID As Integer,
    'cn As SqlConnection,
    'trans As SqlTransaction) As Task

    '    Dim sql As String =
    '        "UPDATE Treasury
    '    SET CurrentBalance=
    '    (
    '    SELECT
    '    ISNULL(SUM(
    '    CASE
    '    WHEN IsDeposit=1 THEN Amount
    '    ELSE -Amount
    '    END),0)
    '    FROM TreasuryTransactions
    '    WHERE TreasuryID=@TreasuryID
    '    )
    '    WHERE TreasuryID=@TreasuryID"

    '    Using cmd As New SqlCommand(sql, cn, trans)

    '        cmd.Parameters.AddWithValue("@TreasuryID", TreasuryID)

    '        Await cmd.ExecuteNonQueryAsync()

    '    End Using

    'End Function
End Class