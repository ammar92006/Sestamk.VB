Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Clients
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim adapter1 As SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cmdb As New SqlCommandBuilder
    Dim oldid As Integer

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Clients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT Cust_Code as 'كود العميل', Cust_Name as 'اسم العميل',Cust_N_Name as 'لقب العميل',Cust_S_Date as 'تاريخ بدأ التعامل',Cust_Major as 'طبيعه التعامل',Cust_Address as 'عنوان العميل',Cust_Mobile as ' 1 رقم الهاتف',Cust_Mobile1 as 'رقم الهاتف 2',Cust_State as 'حالة العميل',Cust_Note as الملاحظات From Customer_TBL"
        Connect()
        adapter1 = New SqlDataAdapter(query, Conn)
        adapter1.Fill(ds, "Clients")
        dgvcliens.DataSource = ds.Tables("Clients")
        ds.Tables("Clients").Constraints.Add("Pirmary", ds.Tables("Clients").Columns("كود العميل"), True)
        Dim arrey() As String = {"كود العميل", "اسم العميل", "الرصيد", "رقم الهاتف", "رقم البطاقة", "عدد الافراد", "العنوان", "الملاحظات", "الكل"}
        ComboBox1.Items.AddRange(arrey)
        ComboBox1.SelectedIndex = 1 ' تعيين الخيار الافتراضي
        myTimer.Start()
        TXTSearch.Focus()

        Main()



    End Sub

    Private Sub myTimer_Tick(sender As Object, e As EventArgs)
        ' الكود الذي تريد تنفيذه كل ثانيتين
        'Dim query As String = "SELECT Client_Code as 'كود العميل', Client_Name as 'اسم العميل',Client_Balance as 'رصيد العميل',Client_Phone as 'رقم الهاتف',Client_Card_number as 'رقم البطاقة',Client_Members as 'عدد الافراد',Client_Address as 'العنوان',Client_Note as الملاحظات From T_Clients"
        'adapter = New SqlDataAdapter(query, sqlcon)
        'adapter.Fill(ds, "Clients")
        'dgvcliens.DataSource = ds.Tables("Clients")

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        code_client.Clear()
        name_client.Clear()
        money_client.Clear()
        phone_client.Clear()
        mmber_client.Clear()
        Idnum_client.Clear()
        address_client.Clear()
        note_client.Clear()
        TXTSearch.Clear()
    End Sub

    Private Sub btn_add_user_Click(sender As Object, e As EventArgs)
        Dim addclient As New Add_client()
        addclient.Show()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs)
        If code_client.Text = "" Then
            MsgBox("يرجي تحديد العميل اولا ثم التعديل", MsgBoxStyle.Critical, "التعديل")
            Exit Sub
        End If
        Dim row As DataRow = ds.Tables("Clients").Rows.Find(Val(code_client.Text))
        'row(0) = code_client.Text
        row(1) = name_client.Text
        'row(2) = money_client.Text
        row(3) = phone_client.Text
        row(4) = Idnum_client.Text
        row(5) = mmber_client.Text
        row(6) = address_client.Text
        row(7) = note_client.Text
        cmdb = New SqlCommandBuilder(adapter1)
        adapter1.Update(ds.Tables("Clients"))
        MsgBox("تم عملية التعديل بنجاح", MsgBoxStyle.Information, "تعديل")
        btn_empty.PerformClick()
    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs)
        Dim connectionString As String = "server=AmmarAhmed-PC; database=db_Al-Ikhlas Bakery ; integrated security = true"
        Dim query As String = "SELECT Client_Code, Client_Name, Client_Balance, Client_Phone, Client_Card_number, Client_Members, Client_Address, Client_Note FROM T_Clients WHERE "

        ' تحديد معيار البحث
        Dim selectedCriterion As String = ComboBox1.SelectedItem.ToString()
        Dim columnName As String = ""
        '"كود العميل", "اسم العميل", "الرصيد", "رقم الهاتف", "رقم البطاقة", "عدد الافراد", "العنوان", "الملاحظات", "الكل"


        If selectedCriterion = "الكل" Then
            ' البحث في جميع الأعمدة
            query &= "Client_Name LIKE @SearchValue OR Client_Code LIKE @SearchValue OR "
            query &= "Client_Balance LIKE @SearchValue OR Client_Phone LIKE @SearchValue OR "
            query &= "Client_Card_number LIKE @SearchValue OR Client_Members LIKE @SearchValue OR "
            query &= "Client_Address LIKE @SearchValue OR Client_Note LIKE @SearchValue"

        Else
            ' تعيين اسم العمود بناءً على معيار البحث
            Select Case selectedCriterion
                Case "اسم العميل"
                    columnName = "Client_Name"
                Case "كود العميل"
                    columnName = "Client_Code"
                Case "الرصيد"
                    columnName = "Client_Balance"
                Case "رقم الهاتف"
                    columnName = "Client_Phone"
                Case "رقم البطاقة"
                    columnName = "Client_Card_number"
                Case "عدد الافراد"
                    columnName = "Client_Members"
                Case "العنوان"
                    columnName = "Client_Address"
                Case "الملاحظات"
                    columnName = "Client_Note"

                Case Else
                    MsgBox("الرجاء اختيار معيار بحث صحيح.", MsgBoxStyle.Exclamation, "خطأ")
                    Exit Sub
            End Select
            ' إضافة معيار البحث إلى الاستعلام
            query &= $"{columnName} LIKE @SearchValue"

        End If




        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                ' تمرير قيمة البحث إلى الاستعلام
                cmd.Parameters.AddWithValue("@SearchValue", "%" & TXTSearch.Text & "%")
                Dim adapter2 As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter2.Fill(table)


                ' عرض النتائج في DataGridView
                dgvcliens.DataSource = table

                ' عرض رسالة إذا لم تكن هناك نتائج
                If table.Rows.Count = 0 Then
                    MsgBox("لا توجد نتائج تطابق البحث.", MsgBoxStyle.Information, "نتائج البحث")
                End If
            End Using
        End Using
    End Sub

    Private Sub btn_delet_Click(sender As Object, e As EventArgs)
        If code_client.Text = "" Then
            MsgBox("يرجي التحديد اولا ثم الحذف", MsgBoxStyle.Critical, "الحذف")
            Exit Sub
        End If
        Dim row As DataRow = ds.Tables("Clients").Rows.Find(code_client.Text.Trim)
        If row Is Nothing Then
            MsgBox("هذا العميل غير موجود", MsgBoxStyle.Critical, "الحذف")
        Else



            Dim result As DialogResult
            result = MsgBox("هل أنت متأكد من أنك تريد حذف هذا العميل؟ هذه العملية لا يمكن التراجع عنها.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "تأكيد الحذف")

            If result = MsgBoxResult.Yes Then
                ' تنفيذ عملية الحذف

                row.Delete()
                cmdb = New SqlCommandBuilder(adapter1)
                adapter1.Update(ds.Tables("Clients"))
                Dim clientName As String = name_client.Text
                MsgBox($"تم حذف بيانات العميل '{clientName}' بنجاح.", MsgBoxStyle.Information, "عملية الحذف")
                btn_empty.PerformClick()

            Else
                ' إلغاء الحذف
                MsgBox("تم إلغاء عملية الحذف.", MsgBoxStyle.Information, "إلغاء الحذف")
                Exit Sub
            End If



        End If
    End Sub

    Private Sub dgvcliens_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click_1(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        ' التحقق من أن الصف الحالي صالح
        If e.RowIndex >= 0 Then
            ' تحديد الصف المحدد
            Dim selectedRow As DataGridViewRow = dgvcliens.Rows(e.RowIndex)

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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TXTSearch_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedCriterion As String = ComboBox1.SelectedItem.ToString()
        Select Case selectedCriterion
            Case "اسم العميل"
                TXTSearch.Focus()
                settextboxdata()
        End Select

    End Sub


    Sub settextboxdata()
        Dim adapter5 As SqlDataAdapter

        adapter5 = New SqlDataAdapter("Select Cust_Name from Customer_TBL", Conn)
        adapter5.Fill(dt)
        Dim datasource As New AutoCompleteStringCollection
        For i As Integer = 0 To dt.Rows.Count - 1
            datasource.Add(dt.Rows(i)("Cust_Name"))
        Next
        TXTSearch.AutoCompleteCustomSource = datasource
        TXTSearch.AutoCompleteMode = AutoCompleteMode.Suggest
        TXTSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
    Private Sub TXTSearch_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyValue = Keys.Enter Then
            btn_Search.PerformClick()
        End If
    End Sub


    ' دالة لحساب عدد القيم في عمود معين
    Public Function GetColumnCount(connectionString As String, tableName As String, columnName As String) As Integer
        Dim count As Integer = 0
        Dim query As String = $"SELECT COUNT({columnName}) FROM {tableName}"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    count = Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("خطأ أثناء التنفيذ: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using

        Return count
    End Function

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        Dim query As String = "SELECT Client_Code as 'كود العميل', Client_Name as 'اسم العميل',Client_Balance as 'رصيد العميل',Client_Phone as 'رقم الهاتف',Client_Card_number as 'رقم البطاقة',Client_Members as 'عدد الافراد',Client_Address as 'العنوان',Client_Note as الملاحظات From T_Clients"
        adapter1 = New SqlDataAdapter(query, Conn)
        adapter1.Fill(ds, "Clients")
        dgvcliens.DataSource = ds.Tables("Clients")
        cmdb = New SqlCommandBuilder(adapter1)
        adapter1.Update(ds.Tables("Clients"))
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub code_client_TextChanged(sender As Object, e As EventArgs) Handles code_client.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub address_client_TextChanged(sender As Object, e As EventArgs) Handles address_client.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub btnMinimize_Click_2(sender As Object, e As EventArgs) Handles btnMinimize.Click

    End Sub

    Private Sub TXTSearch_TextChanged_1(sender As Object, e As EventArgs) Handles TXTSearch.TextChanged

    End Sub

    Private Sub btn_empty_Click(sender As Object, e As EventArgs) Handles btn_empty.Click

    End Sub

    Private Sub dgvcliens_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcliens.CellContentClick

    End Sub

    Private Sub btn_Search_Click_1(sender As Object, e As EventArgs) Handles btn_Search.Click

    End Sub

    ' مثال على الاستخدام
    Sub Main()
        ' نص الاتصال بقاعدة البيانات

        ' اسم الجدول والعمود
        Dim tableName As String = "Customer_TBL"
        Dim columnName As String = "Cust_ID"

        ' استدعاء الدالة
        Dim columnCount As Integer = GetColumnCount(connectionString, tableName, columnName)

        ' عرض النتيجة
        Console.WriteLine($"عدد القيم في العمود {columnName} في الجدول {tableName}: {columnCount}")
        Label12.Text = columnCount
    End Sub


End Class
