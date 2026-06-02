Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class free_sale
    Dim sqlcon As New SqlConnection("Server=" & My.Settings.Server_name & "; database=" & My.Settings.Database_name & ";User Id=" & My.Settings.username_server & ";Password=" & My.Settings.password_server)
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim adapter As SqlDataAdapter
    Dim adapter2 As SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim lastrow As Integer
    Dim cmdb As New SqlCommandBuilder
    Private Sub free_sale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        allrowint()
        fatcode.Text = lastrow
        fatdata.Text = DateTime.Today.ToString("yyyy/MM/dd")
        username.Text = usernamelogin

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub free_sale_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub free_sale_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub amount_TextChanged(sender As Object, e As EventArgs) Handles amount.TextChanged
        All.Text = Val(amount.Text) * Val(My.Settings.Free_bread_price)
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        'تسجيل العملية
        'تاريخ اليوم
        Dim currentDate As DateTime = DateTime.Today.ToString("dd/MM/yyyy")

        ' تعريف متغير لتخزين الوقت الحالي بنظام 12 ساعة
        Dim currentTime As String = DateTime.Now.ToString("hh:mm:ss tt")

        'تحويل بيانات العملية الي قواعد البيانات
        Dim strInsert As String = "INSERT INTO T_Sales " _
& "VALUES(" & lastrow & ",'" & usernamelogin & "','" & "عميل حر" & "','" & currentDate & "','" & currentTime & "','" & "عميل حر" & "','" & "عميل حر" & "','" & All.Text & "','" & amount.Text & "')"
        sqlcon.Open()
        Dim cmd As New SqlCommand(strInsert, sqlcon)
        cmd.ExecuteNonQuery()
        MsgBox("الحمد لله والشكر لله", MsgBoxStyle.Information, "اتمام العملية")
        allrowint()

        fatcode.Text = lastrow
        sqlcon.Close()
    End Sub

    Private Sub note_client_TextChanged(sender As Object, e As EventArgs) Handles note_client.TextChanged

    End Sub

    Sub allrowint()

        'معرفه عدد الصفوف
        Dim sqlconi As String = "Server=" & My.Settings.Server_name & "; database=" & My.Settings.Database_name & ";User Id=" & My.Settings.username_server & ";Password=" & My.Settings.password_server
        'معرفة اخر صف يحتوي علي بيانات
        Dim query2 As String = "SELECT COUNT(ID) AS NumberOfItems FROM T_Sales WHERE ID IS NOT NULL"
        Using connection As New SqlConnection(sqlconi)
            Try
                connection.Open()

                ' تنفيذ الاستعلام
                Dim command As New SqlCommand(query2, connection)
                Dim result As Object = command.ExecuteScalar()
                lastrow = Val(result.ToString) + 1
            Catch ex As Exception
                MsgBox("حدث خطأ: " & ex.Message)
                Exit Sub
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

End Class