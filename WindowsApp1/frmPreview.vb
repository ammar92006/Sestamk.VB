Imports System.Data.SqlClient

Public Class FormPreviewCustomers
    Private importedData As DataTable

    ' 🔹 Constructor بياخد البيانات وقت إنشاء الفورم
    Public Sub New(importedData As DataTable)
        InitializeComponent()
        Me.importedData = importedData
    End Sub

    Public Sub LoadData(ByVal dt As DataTable)
        dgvPreview.DataSource = dt
    End Sub

    Private Sub btnSaveToDatabase_Click(sender As Object, e As EventArgs) Handles btnSaveToDatabase.Click
        'Try
        '    Using Conn

        '        For Each row As DataGridViewRow In dgvPreview.Rows
        '            If Not row.IsNewRow Then
        '                ' 🧩 نجيب القيم بالترتيب بدل الأسماء لتجنب مشكلة اختلاف أسماء الأعمدة
        '                Dim customerCode As String = row.Cells(0).Value.ToString().Trim()     ' كود العميل
        '                Dim customerName As String = row.Cells(1).Value.ToString().Trim()     ' اسم العميل
        '                Dim phoneNumber As String = row.Cells(2).Value.ToString().Trim()      ' رقم الهاتف
        '                Dim balance As Decimal = Convert.ToDecimal(If(IsDBNull(row.Cells(3).Value), 0, row.Cells(3).Value))
        '                Dim creditLimit As Decimal = Convert.ToDecimal(If(IsDBNull(row.Cells(4).Value), 0, row.Cells(4).Value))
        '                Dim isActive As Boolean = True

        '                ' ✅ تحقق من وجود العميل
        '                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM Customers WHERE CustomerCode = @code", Conn)
        '                checkCmd.Parameters.AddWithValue("@code", customerCode)
        '                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

        '                If exists = 0 Then
        '                    ' ✅ العميل جديد → نضيفه
        '                    Dim insertCmd As New SqlCommand("
        '                INSERT INTO Customers (CustomerCode, CustomerName, PhoneNumber, Balance, CreditLimit, IsActive, CreatedAt)
        '                VALUES (@code, @name, @phone, @balance, @limit, @active, GETDATE())", Conn)

        '                    insertCmd.Parameters.AddWithValue("@code", customerCode)
        '                    insertCmd.Parameters.AddWithValue("@name", customerName)
        '                    insertCmd.Parameters.AddWithValue("@phone", phoneNumber)
        '                    insertCmd.Parameters.AddWithValue("@balance", balance)
        '                    insertCmd.Parameters.AddWithValue("@limit", creditLimit)
        '                    insertCmd.Parameters.AddWithValue("@active", isActive)
        '                    insertCmd.ExecuteNonQuery()

        '                Else
        '                    ' ⚙️ العميل موجود → نحدث بياناته
        '                    Dim updateCmd As New SqlCommand("
        '                UPDATE Customers
        '                SET CustomerName = @name,
        '                    PhoneNumber = @phone,
        '                    Balance = @balance,
        '                    CreditLimit = @limit,
        '                    IsActive = @active
        '                WHERE CustomerCode = @code", Conn)

        '                    updateCmd.Parameters.AddWithValue("@code", customerCode)
        '                    updateCmd.Parameters.AddWithValue("@name", customerName)
        '                    updateCmd.Parameters.AddWithValue("@phone", phoneNumber)
        '                    updateCmd.Parameters.AddWithValue("@balance", balance)
        '                    updateCmd.Parameters.AddWithValue("@limit", creditLimit)
        '                    updateCmd.Parameters.AddWithValue("@active", isActive)
        '                    updateCmd.ExecuteNonQuery()
        '                End If
        '            End If
        '        Next

        '        MessageBox.Show("✅ تم حفظ جميع البيانات بنجاح (مع التحديث للبيانات المكررة).", "تم بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    End Using

        'Catch ex As Exception
        '    MessageBox.Show("حدث خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    Disconnect()
        'End Try

        Dim connString As String = "Data Source=.;Initial Catalog=اسم_قاعدتك;Integrated Security=True"
        Using conn As New SqlConnection(connString)
            conn.Open()

            For Each row As DataGridViewRow In dgvPreview.Rows
                If Not row.IsNewRow Then
                    Try
                        Dim customerCode As String = Convert.ToString(row.Cells("CustomerCode").Value)
                        Dim customerName As String = Convert.ToString(row.Cells("CustomerName").Value)
                        Dim balance As Decimal = 0
                        Dim creditLimit As Decimal = 0

                        If IsNumeric(row.Cells("Balance").Value) Then
                            balance = Convert.ToDecimal(row.Cells("Balance").Value)
                        End If
                        If IsNumeric(row.Cells("CreditLimit").Value) Then
                            creditLimit = Convert.ToDecimal(row.Cells("CreditLimit").Value)
                        End If

                        ' التحقق من التكرار في قاعدة البيانات
                        Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM Customers WHERE CustomerCode = @code", conn)
                        checkCmd.Parameters.AddWithValue("@code", customerCode)
                        Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If exists = 0 Then
                            Dim insertCmd As New SqlCommand("INSERT INTO Customers (CustomerCode, CustomerName, Balance, CreditLimit) VALUES (@c1, @c2, @c3, @c4)", conn)
                            insertCmd.Parameters.AddWithValue("@c1", customerCode)
                            insertCmd.Parameters.AddWithValue("@c2", customerName)
                            insertCmd.Parameters.AddWithValue("@c3", balance)
                            insertCmd.Parameters.AddWithValue("@c4", creditLimit)
                            insertCmd.ExecuteNonQuery()
                        End If

                    Catch ex As Exception
                        ' تجاهل الصف اللي فيه خطأ وكمّل
                        Console.WriteLine("خطأ في الصف: " & ex.Message)
                    End Try
                End If
            Next

            MessageBox.Show("تم حفظ البيانات بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub






End Class
