Imports System.Data.SqlClient

Public Class sale_client
    Dim sqlcon As New SqlConnection("Server=" & My.Settings.Server_name & "; database=" & My.Settings.Database_name & ";User Id=" & My.Settings.username_server & ";Password=" & My.Settings.password_server)
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim adapter As SqlDataAdapter
    Dim adapter2 As SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim lastrow As Integer
    Dim cmdb As New SqlCommandBuilder
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            TextBox2.Clear()

            TextBox3.Clear()
            Button6.PerformClick()
        Else
            Try
                Dim strQuery As String = "SELECT * FROM T_Clients WHERE Client_Code=" & TextBox1.Text
                Dim cmd As New SqlCommand(strQuery, sqlcon)
                sqlcon.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    TextBox2.Text = dr(1)


                    TextBox3.Text = dr(2)
                    mmber_client.Text = dr(5)
                    Idnum_client.Text = dr(4)
                    phone_client.Text = dr(3)
                    address_client.Text = dr(6)
                    note_client.Text = dr(7)
                Else
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    TextBox7.Clear()

                    Exit Sub

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                sqlcon.Close()
            End Try
        End If
        SearchNameAndDate()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            TextBox2.Clear()
            TextBox3.Clear()
        Else
            Try
                Dim strQuery As String = "SELECT * FROM T_Clients WHERE Client_Name='" & TextBox2.Text.Trim & "'"
                Dim cmd As New SqlCommand(strQuery, sqlcon)
                sqlcon.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    TextBox1.Text = dr(0)
                    TextBox3.Text = dr(2)
                    mmber_client.Text = dr(5)
                    Idnum_client.Text = dr(4)
                    phone_client.Text = dr(3)
                    address_client.Text = dr(6)
                    note_client.Text = dr(7)
                Else
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    TextBox7.Clear()

                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                sqlcon.Close()

            End Try
        End If
        SearchNameAndDate()
    End Sub

    Private Sub SearchNameAndDate()
        ' سلسلة الاتصال بقاعدة البيانات
        Dim connectionString As String = "Server=" & My.Settings.Server_name & "; database=" & My.Settings.Database_name & ";User Id=" & My.Settings.username_server & ";Password=" & My.Settings.password_server ' عدل الإعدادات حسب البيئة الخاصة بك

        ' الاسم الذي تريد البحث عنه
        Dim searchName As String = TextBox2.Text ' يمكنك تغييره ليكون ديناميكيًا (مثلاً TextBox.Text)

        ' نص الاستعلام SQL
        Dim query As String = "SELECT TOP 1 Data , Client_Name ,Time ,Balance FROM T_Operations WHERE Client_Name = @Name ORDER BY Data DESC , Time DESC "

        ' إنشاء الاتصال
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open() ' فتح الاتصال

                ' إنشاء أمر SQL
                Using command As New SqlCommand(query, connection)
                    ' إضافة الباراميتر لتجنب مشاكل SQL Injection
                    command.Parameters.AddWithValue("@Name", searchName)

                    ' تنفيذ الاستعلام
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            ' قراءة البيانات
                            While reader.Read()
                                Dim name As String = reader("Client_Name").ToString()
                                Dim lastDate As DateTime = reader("Data")
                                Dim lastDateTime As DateTime = reader("Time")
                                Dim lastaddmoney As String = reader("Balance")
                                ' عرض النتائج
                                TextBox4.Text = name
                                TextBox5.Text = lastDate
                                TextBox6.Text = lastDateTime
                                TextBox7.Text = lastaddmoney

                            End While
                        Else

                            TextBox4.Clear()
                            TextBox5.Clear()
                            TextBox6.Clear()
                            TextBox7.Clear()

                            Exit Sub
                        End If
                    End Using
                End Using
            Catch ex As Exception
                ' التعامل مع الأخطاء
                MessageBox.Show("حدث خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Private Sub sale_client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT Client_Code as 'كود العميل', Client_Name as 'اسم العميل',Client_Balance as 'رصيد العميل',Client_Phone as 'رقم الهاتف',Client_Card_number as 'رقم البطاقة',Client_Members as 'عدد الافراد',Client_Address as 'العنوان',Client_Note as الملاحظات From T_Clients"
        adapter = New SqlDataAdapter(query, sqlcon)
        adapter.Fill(ds, "Clients")
        DataGridView1.DataSource = ds.Tables("Clients")
        ds.Tables("Clients").Constraints.Add("Pirmary", ds.Tables("Clients").Columns("كود العميل"), True)

        adapter2 = New SqlDataAdapter("Select Client_Name from T_Clients", sqlcon)
        adapter2.Fill(dt)
        Dim datasource As New AutoCompleteStringCollection
        For i As Integer = 0 To dt.Rows.Count - 1
            datasource.Add(dt.Rows(i)("Client_Name"))
        Next
        TextBox2.AutoCompleteCustomSource = datasource
        TextBox2.AutoCompleteMode = AutoCompleteMode.Suggest
        TextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource




        allrowint()


        fatcode.Text = lastrow
        fatdata.Text = DateTime.Today.ToString("dd/MM/yyyy")
        username.Text = usernamelogin
    End Sub

    Private Sub sale_client_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub


    Private Sub sale_client_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub All_TextChanged(sender As Object, e As EventArgs) Handles All.TextChanged

    End Sub

    Private Sub amount_TextChanged(sender As Object, e As EventArgs) Handles amount.TextChanged
        All.Text = Val(amount.Text) * Val(My.Settings.Price_of_bread_customer_variable)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If TextBox1.Text = "" Then
            MsgBox("يرجي ادخال كود العميل", MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            MsgBox("يرجي ادخال اسم العميل", MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End If
        Dim query As String = "SELECT * From T_Clients where Client_Code=@username and Client_Name=@password"
        sqlcon.Close()
        sqlcon.Open()
        Dim cmd2 As New SqlCommand(query, sqlcon)
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@username", SqlDbType.NVarChar, 50)
        param(0).Value = TextBox1.Text.Trim

        param(1) = New SqlParameter("@password", SqlDbType.NVarChar, 50)
        param(1).Value = TextBox2.Text.Trim

        cmd2.Parameters.AddRange(param)


        Dim reader As SqlDataReader = cmd2.ExecuteReader
        reader.Read()
        Try
            If reader.HasRows Then

            Else
                MsgBox("يوجد حطأ في بيانات العميل", MsgBoxStyle.Critical, "عفوا")
                Exit Sub

            End If
            If Val(All.Text) > Val(TextBox3.Text) Then
                Dim currentBalance As Double = Val(All.Text)
                Dim requiredAmount As Double = Val(TextBox3.Text)

                MsgBox("عذرًا، الرصيد الحالي للعميل (" & requiredAmount.ToString() & ") غير كافٍ." & vbNewLine &
           "الرصيد المطلوب: (" & currentBalance.ToString() & ")." & vbNewLine &
           "يرجى إضافة المبلغ المطلوب واستكمال العملية.",
           MsgBoxStyle.Critical,
           "تنبيه")

                Exit Sub

            End If
        Catch ex As Exception
        Finally
            reader.Close()
            sqlcon.Close()
        End Try

        ' تنفيذ الإجراء المطلوب
        Dim row As DataRow = ds.Tables("Clients").Rows.Find(Val(TextBox1.Text))

        row(2) = Val(TextBox3.Text) - Val(All.Text)

        cmdb = New SqlCommandBuilder(adapter)
        adapter.Update(ds.Tables("Clients"))






        'تسجيل العملية
        'تاريخ اليوم
        Dim currentDate As DateTime = DateTime.Today.ToString("dd/MM/yyyy")

        ' تعريف متغير لتخزين الوقت الحالي بنظام 12 ساعة
        Dim currentTime As String = DateTime.Now.ToString("hh:mm:ss tt")

        'تحويل بيانات العملية الي قواعد البيانات
        Dim strInsert As String = "INSERT INTO T_Sales " _
        & "VALUES(" & lastrow & ",'" & usernamelogin & "','" & "عميل متغير" & "','" & currentDate & "','" & currentTime & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & All.Text & "','" & amount.Text & "')"
        sqlcon.Open()
        Dim cmd As New SqlCommand(strInsert, sqlcon)

        cmd.ExecuteNonQuery()
        MsgBox("الحمد لله والشكر لله")
        allrowint()

        fatcode.Text = lastrow
        sqlcon.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' التحقق من أن الصف الحالي صالح
        If e.RowIndex >= 0 Then
            ' تحديد الصف المحدد
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' نقل البيانات إلى مربعات النص
            TextBox1.Text = If(selectedRow.Cells(0).Value IsNot Nothing, selectedRow.Cells(0).Value.ToString(), "")  ' العمود الأول
            TextBox2.Text = If(selectedRow.Cells(1).Value IsNot Nothing, selectedRow.Cells(1).Value.ToString(), "") ' العمود الثاني
            TextBox3.Text = If(selectedRow.Cells(2).Value IsNot Nothing, selectedRow.Cells(2).Value.ToString(), "") ' العمود الثالث
            phone_client.Text = If(selectedRow.Cells(3).Value IsNot Nothing, selectedRow.Cells(3).Value.ToString(), "")
            Idnum_client.Text = If(selectedRow.Cells(4).Value IsNot Nothing, selectedRow.Cells(4).Value.ToString(), "")
            mmber_client.Text = If(selectedRow.Cells(5).Value IsNot Nothing, selectedRow.Cells(5).Value.ToString(), "")
            address_client.Text = If(selectedRow.Cells(6).Value IsNot Nothing, selectedRow.Cells(6).Value.ToString(), "")
            note_client.Text = If(selectedRow.Cells(7).Value IsNot Nothing, selectedRow.Cells(7).Value.ToString(), "")
            Button3.PerformClick()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        mmber_client.Clear()
        Idnum_client.Clear()
        phone_client.Clear()
        address_client.Clear()
        note_client.Clear()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

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
            Finally
                connection.Close()
            End Try
        End Using
    End Sub


End Class