Imports System.Data.SqlClient

Public Class SupplierRepository
    Private ReadOnly _connectionString As String

    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub

    ' 1. جلب قائمة الموردين مع البحث
    Public Function GetSuppliers(Optional search As String = "") As DataTable
        Using conn As New SqlConnection(_connectionString)
            Dim query As String = "SELECT SupplierID, SupplierCode, SupplierName, Phone1, CurrentBalance, IsActive " &
                                 "FROM Suppliers " &
                                 "WHERE SupplierName LIKE @search OR Phone1 LIKE @search OR SupplierCode LIKE @search " &
                                 "ORDER BY SupplierID DESC"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@search", $"%{search}%")
                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                Return dt
            End Using
        End Using
    End Function

    ' 2. إضافة/تعديل مورد وتسجيل الرصيد الافتتاحي كحركة مالية
    Public Function SaveSupplier(supplier As SupplierModel, userId As Integer, ByRef newSupplierId As Integer) As Boolean
        newSupplierId = supplier.SupplierID
        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()

            Try
                If supplier.SupplierID = 0 Then ' إضافة جديد
                    Dim insertQuery As String = "INSERT INTO Suppliers " &
                        "(SupplierCode, SupplierName, Phone1, Phone2, Email, Address, OpeningBalance, CurrentBalance, CreditLimit, Notes, IsActive) " &
                        "VALUES " &
                        "(@SupplierCode, @SupplierName, @Phone1, @Phone2, @Email, @Address, @OpeningBalance, @OpeningBalance, @CreditLimit, @Notes, @IsActive); " &
                        "SELECT SCOPE_IDENTITY();"

                    Using cmd As New SqlCommand(insertQuery, conn, transaction)
                        AddSupplierParameters(cmd, supplier)
                        newSupplierId = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using

                    ' تسجيل الرصيد الافتتاحي كحركة مالية
                    If supplier.OpeningBalance <> 0 Then
                        Dim txQuery As String = "INSERT INTO SupplierTransactions " &
                            "(SupplierID, TransactionType, ReferenceType, CreditAmount, DebitAmount, BalanceAfter, Notes, CreatedByUserID) " &
                            "VALUES " &
                            "(@SupplierID, N'رصيد افتتاحي', 'OpeningBalance', @Credit, @Debit, @BalanceAfter, N'رصيد افتتاحي عند الإنشاء', @UserID);"

                        Using txCmd As New SqlCommand(txQuery, conn, transaction)
                            Dim credit As Decimal = If(supplier.OpeningBalance > 0, supplier.OpeningBalance, 0)
                            Dim debit As Decimal = If(supplier.OpeningBalance < 0, Math.Abs(supplier.OpeningBalance), 0)

                            txCmd.Parameters.AddWithValue("@SupplierID", newSupplierId)
                            txCmd.Parameters.AddWithValue("@Credit", credit)
                            txCmd.Parameters.AddWithValue("@Debit", debit)
                            txCmd.Parameters.AddWithValue("@BalanceAfter", supplier.OpeningBalance)
                            txCmd.Parameters.AddWithValue("@UserID", userId)
                            txCmd.ExecuteNonQuery()
                        End Using
                    End If
                Else ' تعديل مورد قائم
                    Dim updateQuery As String = "UPDATE Suppliers SET " &
                        "SupplierCode = @SupplierCode, " &
                        "SupplierName = @SupplierName, " &
                        "Phone1 = @Phone1, " &
                        "Phone2 = @Phone2, " &
                        "Email = @Email, " &
                        "Address = @Address, " &
                        "CreditLimit = @CreditLimit, " &
                        "Notes = @Notes, " &
                        "IsActive = @IsActive, " &
                        "UpdatedAt = GETDATE() " &
                        "WHERE SupplierID = @SupplierID;"

                    Using cmd As New SqlCommand(updateQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID)
                        AddSupplierParameters(cmd, supplier)
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                transaction.Commit()
                Return True
            Catch ex As Exception
                transaction.Rollback()
                Throw
            End Try
        End Using
    End Function

    ' 3. جلب كشف حساب المورد
    Public Function GetSupplierStatement(supplierId As Integer, fromDate As DateTime, toDate As DateTime) As DataTable
        Using conn As New SqlConnection(_connectionString)
            Dim query As String = "SELECT TransactionID, TransactionDate, TransactionType, ReferenceType, ReferenceID, " &
                                 "CreditAmount, DebitAmount, BalanceAfter, PaymentMethod, Notes " &
                                 "FROM SupplierTransactions " &
                                 "WHERE SupplierID = @SupplierID AND TransactionDate BETWEEN @FromDate AND @ToDate " &
                                 "ORDER BY TransactionID ASC"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SupplierID", supplierId)
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date)
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddTicks(-1))

                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                Return dt
            End Using
        End Using
    End Function

    Private Sub AddSupplierParameters(cmd As SqlCommand, model As SupplierModel)
        cmd.Parameters.AddWithValue("@SupplierCode", If(String.IsNullOrEmpty(model.SupplierCode), CObj(DBNull.Value), model.SupplierCode))
        cmd.Parameters.AddWithValue("@SupplierName", model.SupplierName)
        cmd.Parameters.AddWithValue("@Phone1", model.Phone1)
        cmd.Parameters.AddWithValue("@Phone2", If(String.IsNullOrEmpty(model.Phone2), CObj(DBNull.Value), model.Phone2))
        cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrEmpty(model.Email), CObj(DBNull.Value), model.Email))
        cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrEmpty(model.Address), CObj(DBNull.Value), model.Address))
        cmd.Parameters.AddWithValue("@OpeningBalance", model.OpeningBalance)
        cmd.Parameters.AddWithValue("@CreditLimit", model.CreditLimit)
        cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(model.Notes), CObj(DBNull.Value), model.Notes))
        cmd.Parameters.AddWithValue("@IsActive", model.IsActive)
    End Sub
End Class

Public Class SupplierModel
    Public Property SupplierID As Integer
    Public Property SupplierCode As String
    Public Property SupplierName As String
    Public Property Phone1 As String
    Public Property Phone2 As String
    Public Property Email As String
    Public Property Address As String
    Public Property OpeningBalance As Decimal
    Public Property CurrentBalance As Decimal
    Public Property CreditLimit As Decimal
    Public Property Notes As String
    Public Property IsActive As Boolean = True
End Class