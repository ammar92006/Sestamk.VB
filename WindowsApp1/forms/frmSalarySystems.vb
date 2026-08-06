Imports System.Data.SqlClient

Public Class frmSalarySystems
    Private _cachedSalaries As DataTable = Nothing

    Private Sub LoadGrid()
        Try
            If _cachedSalaries Is Nothing Then
                Dim query As String = "SELECT SalarySystemID, SalarySystemCode, SalarySystemName, PaymentDays, Notes, IsActive FROM SalarySystems WHERE IsDeleted = 0"
                _cachedSalaries = DBModule.ExecuteQuery(query)
            End If

            If _cachedSalaries Is Nothing Then Exit Sub
            dgvSalarySystems.DataSource = _cachedSalaries

            If dgvSalarySystems.Columns.Contains("SalarySystemID") Then dgvSalarySystems.Columns("SalarySystemID").Visible = False
            dgvSalarySystems.Columns("SalarySystemCode").HeaderText = "كود النظام"
            dgvSalarySystems.Columns("SalarySystemName").HeaderText = "اسم نظام الرواتب"
            dgvSalarySystems.Columns("PaymentDays").HeaderText = "أيام الدورة المالية"
            dgvSalarySystems.Columns("Notes").HeaderText = "ملاحظات"
            dgvSalarySystems.Columns("IsActive").HeaderText = "نشط"
        Catch ex As Exception : MessageBox.Show(ex.Message) : End Try
    End Sub

    Private Function IsValidData() As Boolean
        If String.IsNullOrWhiteSpace(txtSalarySystemName.Text) Then
            MessageBox.Show("يرجى إدخال اسم نظام الرواتب!") : Return False
        End If
        Return True
    End Function

    Private Sub ClearFields()
        txtSalarySystemCode.Clear()
        txtSalarySystemName.Clear()
        txtPaymentDays.Text = "30" ' افتراضي شهري
        txtNotes.Clear()
        tgStatus.Checked = True
        dgvSalarySystems.ClearSelection()
    End Sub

    Private Sub frmSalarySystems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
        datagridviewsetup(dgvSalarySystems)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsValidData() Then Exit Sub
        Dim query As String = "INSERT INTO SalarySystems (SalarySystemCode, SalarySystemName, PaymentDays, Notes, IsActive, IsDeleted) VALUES (@Code, @Name, @Days, @Notes, @IsActive, 0)"
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", If(String.IsNullOrEmpty(txtSalarySystemCode.Text), DBNull.Value, txtSalarySystemCode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Name", txtSalarySystemName.Text.Trim())
                cmd.Parameters.AddWithValue("@Days", If(String.IsNullOrEmpty(txtPaymentDays.Text), 30, Convert.ToInt32(txtPaymentDays.Text)))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))
                cmd.Parameters.AddWithValue("@IsActive", tgStatus.Checked)
                Try
                    conn.Open() : cmd.ExecuteNonQuery()
                    _cachedSalaries = Nothing : LoadGrid() : ClearFields()
                    MessageBox.Show("تم حفظ نظام الرواتب")
                Catch ex As Exception : MessageBox.Show(ex.Message) : End Try
            End Using
        End Using
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)

    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        ToggleMaximize(Me)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    ' التعديل والحذف متبعين لنفس أسلوب الأزرار السابقة بدقة وأمان للذاكرة.
End Class