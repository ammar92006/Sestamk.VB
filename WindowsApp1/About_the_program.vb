Imports System.Data.SqlClient

Public Class About_the_program
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim adapter As SqlDataAdapter
    Dim ds As New DataSet
    Dim cmdb As New SqlCommandBuilder
    Dim oldid As Integer
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub About_the_program_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT ID as 'كود العملية',Login_DeviceName as 'اسم الجهاز',Login_MacAddress as 'عنوان الماك',Login_CurrentDate as 'التاريخ' , Login_CurrentTime as 'الوقت', Login_Username as 'اسم المستخدم',Login_Password as 'كلمة المرور',Login_Note as 'حالة الاتصال' From Login_Info_TBL ORDER BY ID ASC"
        Connect()
        adapter = New SqlDataAdapter(query, Conn)
        adapter.Fill(ds, "Login_Info_TBL")
        dgvUsers.DataSource = ds.Tables("Login_Info_TBL")
        Disconnect()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        ' التحقق من أن الصف الحالي صالح
        If e.RowIndex >= 0 Then
            ' تحديد الصف المحدد
            Dim selectedRow As DataGridViewRow = dgvUsers.Rows(e.RowIndex)

            ' نقل البيانات إلى مربعات النص
            code_client.Text = If(selectedRow.Cells(0).Value IsNot Nothing, selectedRow.Cells(0).Value.ToString(), "")  ' العمود الأول
            name_client.Text = If(selectedRow.Cells(1).Value IsNot Nothing, selectedRow.Cells(1).Value.ToString(), "") ' العمود الثاني
            money_client.Text = If(selectedRow.Cells(2).Value IsNot Nothing, selectedRow.Cells(2).Value.ToString(), "") ' العمود الثالث
            phone_client.Text = If(selectedRow.Cells(3).Value IsNot Nothing, selectedRow.Cells(3).Value.ToString(), "")
            Idnum_client.Text = If(selectedRow.Cells(4).Value IsNot Nothing, selectedRow.Cells(4).Value.ToString(), "")
            mmber_client.Text = If(selectedRow.Cells(5).Value IsNot Nothing, selectedRow.Cells(5).Value.ToString(), "")
            address_client.Text = If(selectedRow.Cells(6).Value IsNot Nothing, selectedRow.Cells(6).Value.ToString(), "")
            note_client.Text = If(selectedRow.Cells(7).Value IsNot Nothing, selectedRow.Cells(7).Value.ToString(), "")




        End If
    End Sub

    Private Sub About_the_program_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub About_the_program_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub
End Class