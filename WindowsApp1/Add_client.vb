Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Add_client
    Dim sqlcon As New SqlConnection("Server=" & My.Settings.Server_name & "; database=" & My.Settings.Database_name & ";User Id=" & My.Settings.username_server & ";Password=" & My.Settings.password_server)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main()
        Dim myform2 As New Clients
        myform2.Refresh()

        'Dim strQuery As String = "SELECT TOP 1 Client_Code FROM T_Clients WHERE Client_Code = @code ORDER BY Client_Code DESC"
        'Dim cmd2 As New SqlCommand(strQuery, sqlcon)
        'Dim searchName As String = Client_Code.Text.Trim ' يمكنك تغييره ليكون ديناميكيًا (مثلاً TextBox.Text)
        'sqlcon.Open()
        'Dim dr As SqlDataReader = cmd2.ExecuteReader
        '' إضافة الباراميتر لتجنب مشاكل SQL Injection
        'cmd2.Parameters.AddWithValue("@code", searchName)
        'dr.Read()
        'If dr.HasRows Then
        '    MsgBox("هذا العميل مكرر", MsgBoxStyle.Critical, "خطأ")
        '    Exit Sub
        'End If
        'sqlcon.Close()
        'dr.Close()

        'Try
        '    If Client_Code.Text = "" Then
        '        MsgBox("برجاء ادخال كود العميل", MsgBoxStyle.Critical, "خطأ")
        '        Exit Sub
        '    End If
        '    If Client_Name.Text = "" Then
        '        MsgBox("برجاء ادخال اسم العميل", MsgBoxStyle.Critical, "خطأ")
        '    End If
        '    Dim strInsert As String = "INSERT INTO T_Clients " _
        '    & "VALUES(" & Client_Code.Text & ",'" & Client_Name.Text & "'," & Client_Balance.Text & ",'" & Client_Phone.Text & "'," & Client_Card_number.Text & "," & Client_Members.Text & ",'" & Client_Address.Text & "','" & Client_Note.Text & "')"
        '    Dim cmd As New SqlCommand(strInsert, sqlcon)
        '    sqlcon.Open()
        '    cmd.ExecuteNonQuery()

        '    MsgBox("تم الاضافة بنجاح")

        'Catch ex As Exception

        '    MsgBox("خطأ لم يتم الخفظ برجاء ادخال البيانات بشكل صحيح", MsgBoxStyle.Critical, "خطأ في العملية")
        '    MsgBox(ex.Message)
        '    Exit Sub
        'Finally

        '    sqlcon.Close()
        'End Try



    End Sub

    Private Sub Add_client_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Dim x, y As Integer
    Dim newpoint As New Point
    Private Sub Login_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub


    Private Sub Login_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Label4_MouseMove(sender As Object, e As MouseEventArgs) Handles Label4.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Client_Code.Clear()
        Client_Name.Clear()
        Client_Balance.Clear()
        Client_Card_number.Clear()
        Client_Members.Clear()
        Client_Address.Clear()
        Client_Phone.Clear()
        Client_Note.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim myform As New Clients
        myform.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Label4_MouseDown(sender As Object, e As MouseEventArgs) Handles Label4.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub



    Sub Main()
        ' متغيرات الاتصال بقاعدة البيانات
        Dim connectionString As String = "Server=" & My.Settings.Server_name & "; database=" & My.Settings.Database_name & ";User Id=" & My.Settings.username_server & ";Password=" & My.Settings.password_server
        Dim query As String = "SELECT COUNT(*) FROM T_Clients WHERE Client_Code = @value"
        Dim searchValue As Integer = Client_Code.Text ' الرقم الذي تبحث عنه

        ' إنشاء الاتصال وتنفيذه
        Using connection As New SqlConnection(connectionString)
                Try
                    ' فتح الاتصال
                    connection.Open()

                    ' إنشاء أمر البحث
                    Using command As New SqlCommand(query, connection)
                        ' إضافة القيمة كمعامل
                        command.Parameters.AddWithValue("@value", searchValue)

                        ' تنفيذ الاستعلام
                        Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())

                        ' التحقق من النتيجة
                        If result > 0 Then
                        ' إذا تم العثور على القيمة

                        MsgBox("هذا العميل موجود بالفعل", MsgBoxStyle.Critical, "خطأ")
                        Exit Sub
                        ' نفذ الإجراء المطلوب هنا
                    Else
                        ' إذا لم يتم العثور على القيمة


                        Try
                            If Client_Code.Text = "" Then
                                MsgBox("برجاء ادخال كود العميل", MsgBoxStyle.Critical, "خطأ")
                                Exit Sub
                            End If
                            If Client_Name.Text = "" Then
                                MsgBox("برجاء ادخال اسم العميل", MsgBoxStyle.Critical, "خطأ")
                                Exit Sub
                            End If
                            If Client_Balance.Text = "" Then
                                MsgBox("برجاء ادخال رصيد العميل", MsgBoxStyle.Critical, "خطأ")
                                Exit Sub
                            End If
                            Dim strInsert As String = "INSERT INTO T_Clients " _
                            & "VALUES(" & Client_Code.Text & ",'" & Client_Name.Text & "'," & Client_Balance.Text & ",'" & Client_Phone.Text & "'," & Client_Card_number.Text & "," & Client_Members.Text & ",'" & Client_Address.Text & "','" & Client_Note.Text & "')"
                            Dim cmd As New SqlCommand(strInsert, sqlcon)
                            sqlcon.Open()
                            cmd.ExecuteNonQuery()

                            MsgBox("تم الاضافة بنجاح")

                        Catch ex As Exception

                            MsgBox("خطأ لم يتم الخفظ برجاء ادخال البيانات بشكل صحيح", MsgBoxStyle.Critical, "خطأ في العملية")

                            Exit Sub
                        Finally

                            sqlcon.Close()
                        End Try


                        ' نفذ الإجراء البديل هنا
                    End If
                    End Using
                Catch ex As Exception
                ' معالجة الأخطاء
                Console.WriteLine("حدث خطأ: " & ex.Message)
                Exit Sub
            Finally
                    ' إغلاق الاتصال
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End Using

            ' لإبقاء نافذة الكونسول مفتوحة
            Console.ReadLine()
        End Sub



End Class