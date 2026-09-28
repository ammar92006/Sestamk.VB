Imports System.Data.SqlClient

' All supplier postings use the same sign: credit increases the amount owed.
Public NotInheritable Class SupplierAccountingService
    Public Shared Sub DemandPermission(screen As String, action As String)
        If Session.CurrentUserID <= 0 OrElse Not Session.HasPermission(screen, action) Then
            Throw New UnauthorizedAccessException("ليس لديك صلاحية تنفيذ هذه العملية.")
        End If
    End Sub

    Public Shared Function Query(sql As String, ParamArray parameters() As SqlParameter) As DataTable
        Using cn As New SqlConnection(DBModule.ConnectionString), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddRange(parameters)
            Dim result As New DataTable()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(result)
            End Using
            Return result
        End Using
    End Function

    Public Shared Function GetStatement(supplierID As Integer, fromDate As Date, toDate As Date) As DataTable
        If fromDate.Date > toDate.Date Then Throw New ArgumentException("تاريخ البداية يجب ألا يتجاوز تاريخ النهاية.")
        ' A legacy balance may have no corresponding ledger entries. Preserve and
        ' disclose that difference instead of silently rewriting historical data.
        Const sql As String = "
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;
DECLARE @Legacy decimal(18,2), @Before decimal(18,2);
SELECT @Legacy = S.CurrentBalance - ISNULL(SUM(T.Credit-T.Debit),0)
FROM Suppliers S LEFT JOIN SupplierTransactions T ON T.SupplierID=S.SupplierID
WHERE S.SupplierID=@ID GROUP BY S.CurrentBalance;
SELECT @Before = ISNULL(@Legacy,0)+ISNULL(SUM(Credit-Debit),0)
FROM SupplierTransactions WHERE SupplierID=@ID AND TransactionDate<@From;
SELECT TransactionDate AS [التاريخ], TransactionType AS [الحركة], ReferenceNo AS [المرجع],
       Debit AS [مدين], Credit AS [دائن],
       @Before+SUM(Credit-Debit) OVER(ORDER BY TransactionDate,TransactionID ROWS UNBOUNDED PRECEDING) AS [الرصيد],
       PaymentMethod AS [طريقة الدفع], Notes AS [البيان]
FROM SupplierTransactions WHERE SupplierID=@ID AND TransactionDate>=@From AND TransactionDate<@To
ORDER BY TransactionDate,TransactionID;
SELECT @Before AS PreviousBalance, ISNULL(@Legacy,0) AS LegacyDifference;
COMMIT;"
        Using cn As New SqlConnection(DBModule.ConnectionString), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@ID", supplierID)
            cmd.Parameters.AddWithValue("@From", fromDate.Date)
            cmd.Parameters.AddWithValue("@To", toDate.Date.AddDays(1))
            Dim ds As New DataSet()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(ds)
            End Using
            Dim dt = ds.Tables(0)
            Dim first = dt.NewRow()
            first("التاريخ") = fromDate.Date
            first("الحركة") = "رصيد سابق"
            first("مدين") = 0D
            first("دائن") = 0D
            first("الرصيد") = ds.Tables(1).Rows(0)("PreviousBalance")
            first("البيان") = If(CDec(ds.Tables(1).Rows(0)("LegacyDifference")) = 0D, "رصيد ما قبل الفترة", "يتضمن فرق رصيد تاريخي غير ممثل بحركات: " & CDec(ds.Tables(1).Rows(0)("LegacyDifference")).ToString("N2"))
            dt.Rows.InsertAt(first, 0)
            Return dt
        End Using
    End Function

    Public Shared Function GetBalances(Optional supplierID As Integer = 0, Optional search As String = "") As DataTable
        Return Query("SELECT S.SupplierCode AS [الكود], S.SupplierName AS [المورد], S.Phone AS [الهاتف],
S.OpeningBalance AS [الرصيد الافتتاحي], ISNULL(T.Purchases,0) AS [المشتريات],
ISNULL(T.Paid,0) AS [المسدد], S.CurrentBalance AS [الرصيد الحالي],
S.CurrentBalance-ISNULL(T.Movement,0) AS [فرق تاريخي غير مسجل]
FROM Suppliers S OUTER APPLY (SELECT SUM(CASE WHEN TransactionType='PURCHASE' THEN Credit ELSE 0 END) Purchases,
SUM(CASE WHEN TransactionType IN ('PURCHASE','SUPPLIER_PAYMENT') THEN Debit ELSE 0 END) Paid,
SUM(Credit-Debit) Movement FROM SupplierTransactions WHERE SupplierID=S.SupplierID) T
WHERE (S.IsDeleted=0 OR S.IsDeleted IS NULL OR S.CurrentBalance<>0) AND (@ID=0 OR S.SupplierID=@ID)
AND (S.SupplierName LIKE @Search OR S.SupplierCode LIKE @Search OR S.Phone LIKE @Search)
ORDER BY S.SupplierName", New SqlParameter("@ID", supplierID), New SqlParameter("@Search", "%" & search & "%"))
    End Function

    Public Shared Async Function PayAsync(supplierID As Integer, treasuryID As Integer, amount As Decimal, method As String, notes As String) As Task
        DemandPermission("FrmSupplierTransactions", "CanAdd")
        If amount <= 0D OrElse Decimal.Round(amount, 2) <> amount Then Throw New ArgumentException("أدخل مبلغاً موجباً بمنزلتين عشريتين كحد أقصى.")
        If (notes IsNot Nothing AndAlso notes.Length > 250) OrElse (method IsNot Nothing AndAlso method.Length > 30) Then Throw New ArgumentException("البيان أو طريقة الدفع يتجاوز الطول المسموح.")
        If String.IsNullOrWhiteSpace(method) Then Throw New ArgumentException("حدد طريقة الدفع.")
        Using cn As New SqlConnection(DBModule.ConnectionString)
            Await cn.OpenAsync()
            Using tx = cn.BeginTransaction(IsolationLevel.Serializable)
                Try
                    Dim before As Decimal
                    Using cmd As New SqlCommand("SELECT CurrentBalance FROM Suppliers WITH(UPDLOCK,HOLDLOCK) WHERE SupplierID=@ID AND IsActive=1 AND ISNULL(IsDeleted,0)=0", cn, tx)
                        cmd.Parameters.AddWithValue("@ID", supplierID)
                        Dim value = Await cmd.ExecuteScalarAsync()
                        If value Is Nothing Then Throw New ArgumentException("المورد غير موجود أو غير نشط.")
                        before = CDec(value)
                    End Using
                    Using cmd As New SqlCommand("SELECT TreasuryID FROM Treasury WITH(UPDLOCK,HOLDLOCK) WHERE TreasuryID=@ID AND IsActive=1 AND ISNULL(IsDeleted,0)=0", cn, tx)
                        cmd.Parameters.AddWithValue("@ID", treasuryID)
                        If Await cmd.ExecuteScalarAsync() Is Nothing Then Throw New ArgumentException("الخزينة غير متاحة.")
                    End Using
                    Dim reference = "SP-" & Guid.NewGuid().ToString("N")
                    Dim movementID As Integer
                    Using cmd As New SqlCommand("INSERT INTO SupplierTransactions(SupplierID,TransactionType,ReferenceNo,Debit,Credit,BalanceBefore,BalanceAfter,TreasuryID,PaymentMethod,Notes,UserID) VALUES(@ID,'SUPPLIER_PAYMENT',@Ref,@Amount,0,@Before,@After,@Treasury,@Method,@Notes,@User); SELECT CAST(SCOPE_IDENTITY() AS int);", cn, tx)
                        cmd.Parameters.AddWithValue("@ID", supplierID)
                        cmd.Parameters.AddWithValue("@Ref", reference)
                        cmd.Parameters.AddWithValue("@Amount", amount)
                        cmd.Parameters.AddWithValue("@Before", before)
                        cmd.Parameters.AddWithValue("@After", before - amount)
                        cmd.Parameters.AddWithValue("@Treasury", treasuryID)
                        cmd.Parameters.AddWithValue("@Method", method)
                        cmd.Parameters.AddWithValue("@Notes", notes)
                        cmd.Parameters.AddWithValue("@User", Session.CurrentUserID)
                        movementID = CInt(Await cmd.ExecuteScalarAsync())
                    End Using
                    Using cmd As New SqlCommand("UPDATE Suppliers SET CurrentBalance=CurrentBalance-@Amount WHERE SupplierID=@ID", cn, tx)
                        cmd.Parameters.AddWithValue("@ID", supplierID)
                        cmd.Parameters.AddWithValue("@Amount", amount)
                        Await cmd.ExecuteNonQueryAsync()
                    End Using
                    Await TreasuryService.AddTransactionAsync(treasuryID, TreasuryTransactionTypes.SupplierPayment, amount, False, movementID, reference, notes, Session.CurrentUserID, cn, tx)
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function
    Public Shared Sub EnsurePurchaseHeadersBranchColumn()
        Try
            Dim sql As String = "IF OBJECT_ID('[dbo].[PurchaseHeaders]', 'U') IS NOT NULL AND COL_LENGTH('[dbo].[PurchaseHeaders]', 'BranchID') IS NULL " &
                                "BEGIN ALTER TABLE [dbo].[PurchaseHeaders] ADD [BranchID] INT NULL; END"
            DBModule.ExecuteNonQuery(sql)
        Catch ex As Exception
            Debug.WriteLine("EnsurePurchaseHeadersBranchColumn error: " & ex.Message)
        End Try
    End Sub

    Public Shared Async Function SavePurchaseAsync(invNumber As String, supID As Integer, storeID As Integer, purchaseDate As Date, discount As Decimal, paid As Decimal, paymentCode As String, treasuryID As Integer?, notes As String, items As DataTable, updateCost As Boolean, Optional branchID As Integer? = Nothing) As Task(Of Integer)
        DemandPermission("frmPurchases", "CanAdd")
        EnsurePurchaseHeadersBranchColumn()
        If items Is Nothing OrElse items.Rows.Count = 0 Then Throw New ArgumentException("الفاتورة فارغة.")
        If String.IsNullOrWhiteSpace(invNumber) OrElse invNumber.Length > 50 Then Throw New ArgumentException("رقم الفاتورة غير صالح.")
        If notes IsNot Nothing AndAlso notes.Length > 250 Then Throw New ArgumentException("البيان يتجاوز 250 حرفاً.")
        Dim total As Decimal = 0D
        For Each row As DataRow In items.Rows
            Dim qty = CDec(row("Quantity")), price = CDec(row("UnitPrice")), factor = CDec(row("ConversionFactor"))
            If qty <= 0 OrElse price <= 0 OrElse factor <= 0 Then Throw New ArgumentException("راجع الكميات والأسعار ومعاملات التحويل.")
            If Decimal.Round(qty, 4) <> qty OrElse Decimal.Round(price, 4) <> price OrElse Decimal.Round(factor, 4) <> factor Then Throw New ArgumentException("دقة الكمية والسعر والتحويل لا تتجاوز أربع منازل عشرية.")
            If Decimal.Round(qty * factor, 3) <> qty * factor Then Throw New ArgumentException("الكمية بالوحدة الأساسية تتجاوز دقة المخزون (ثلاث منازل عشرية).")
            total += qty * price
        Next
        If discount < 0 OrElse discount > total OrElse Decimal.Round(discount, 2) <> discount Then Throw New ArgumentException("قيمة الخصم غير صالحة.")
        Dim netTotal = Decimal.Round(total - discount, 2, MidpointRounding.AwayFromZero)
        Select Case paymentCode
            Case "CASH" : paid = netTotal
            Case "CREDIT" : paid = 0D
            Case "PARTIAL"
                If paid <= 0 OrElse paid >= netTotal Then Throw New ArgumentException("السداد الجزئي يجب أن يكون أكبر من صفر وأقل من الصافي.")
            Case Else : Throw New ArgumentException("نوع السداد غير صالح.")
        End Select
        If paid < 0 OrElse paid > netTotal OrElse Decimal.Round(paid, 2) <> paid Then Throw New ArgumentException("قيمة السداد غير صالحة.")
        If paid > 0 AndAlso Not treasuryID.HasValue Then Throw New ArgumentException("حدد خزينة السداد.")
        If paid = 0 Then treasuryID = Nothing
        Dim remaining = netTotal - paid
        Using conn As New SqlConnection(DBModule.ConnectionString)
            Await conn.OpenAsync()
            Using trans As SqlTransaction = conn.BeginTransaction(IsolationLevel.Serializable)

                Try
                    Using storeCheck As New SqlCommand("SELECT StoreID FROM Stores WHERE StoreID=@ID AND ISNULL(IsActive,1)=1", conn, trans)
                        storeCheck.Parameters.AddWithValue("@ID", storeID)
                        If Await storeCheck.ExecuteScalarAsync() Is Nothing Then Throw New ArgumentException("المخزن غير موجود.")
                    End Using
                    If branchID.HasValue Then
                        Using branchCheck As New SqlCommand("SELECT BranchID FROM Branches WHERE BranchID=@ID AND IsActive=1 AND ISNULL(IsDeleted,0)=0", conn, trans)
                            branchCheck.Parameters.AddWithValue("@ID", branchID.Value)
                            If Await branchCheck.ExecuteScalarAsync() Is Nothing Then Throw New ArgumentException("الفرع المحدد غير متاح.")
                        End Using
                    End If
                    Dim supBefore As Decimal
                    Using lockSupplier As New SqlCommand("SELECT CurrentBalance FROM Suppliers WITH(UPDLOCK,HOLDLOCK) WHERE SupplierID=@ID AND IsActive=1 AND ISNULL(IsDeleted,0)=0", conn, trans)
                        lockSupplier.Parameters.AddWithValue("@ID", supID)
                        Dim value = Await lockSupplier.ExecuteScalarAsync()
                        If value Is Nothing Then Throw New ArgumentException("المورد غير متاح.")
                        supBefore = CDec(value)
                    End Using
                    Using duplicate As New SqlCommand("SELECT COUNT(*) FROM PurchaseHeaders WITH(UPDLOCK,HOLDLOCK) WHERE InvoiceNumber=@No", conn, trans)
                        duplicate.Parameters.AddWithValue("@No", invNumber)
                        If CInt(Await duplicate.ExecuteScalarAsync()) > 0 Then Throw New ArgumentException("رقم الفاتورة مستخدم بالفعل؛ أدخل رقماً جديداً.")
                    End Using
                    If paid > 0D Then
                        Using lockTreasury As New SqlCommand("SELECT TreasuryID FROM Treasury WITH(UPDLOCK,HOLDLOCK) WHERE TreasuryID=@ID AND IsActive=1 AND ISNULL(IsDeleted,0)=0", conn, trans)
                            lockTreasury.Parameters.AddWithValue("@ID", If(treasuryID.HasValue, treasuryID.Value, 0))
                            If Await lockTreasury.ExecuteScalarAsync() Is Nothing Then Throw New ArgumentException("الخزينة غير متاحة.")
                        End Using
                    End If
                    ' 1. حفظ رأس الفاتورة مع طريقة الدفع والفرع
                    Dim sqlHeader As String = "INSERT INTO PurchaseHeaders (InvoiceNumber, SupplierID, StoreID, BranchID, PurchaseDate, TotalAmount, Discount, NetTotal, PaidAmount, RemainingAmount, PaymentType, TreasuryID, Notes, UserID) " &
                                              "VALUES (@InvNo, @SupID, @StoreID, @BranchID, @Date, @Total, @Disc, @Net, @Paid, @Rem, @PayType, @TreasuryID, @Notes, @User); " &
                                              "SELECT SCOPE_IDENTITY();"

                    Dim purchaseID As Integer = 0
                    Using cmdH As New SqlCommand(sqlHeader, conn, trans)
                        cmdH.Parameters.AddWithValue("@User", Session.CurrentUserID)
                        cmdH.Parameters.AddWithValue("@InvNo", invNumber)
                        cmdH.Parameters.AddWithValue("@SupID", supID)
                        cmdH.Parameters.AddWithValue("@StoreID", storeID)
                        cmdH.Parameters.AddWithValue("@BranchID", If(branchID.HasValue, CObj(branchID.Value), DBNull.Value))
                        cmdH.Parameters.AddWithValue("@Date", purchaseDate)
                        cmdH.Parameters.AddWithValue("@Total", total)
                        cmdH.Parameters.AddWithValue("@Disc", discount)
                        cmdH.Parameters.AddWithValue("@Net", netTotal)
                        cmdH.Parameters.AddWithValue("@Paid", paid)
                        cmdH.Parameters.AddWithValue("@Rem", remaining)
                        cmdH.Parameters.AddWithValue("@PayType", paymentCode)
                        cmdH.Parameters.AddWithValue("@TreasuryID", If(treasuryID.HasValue, treasuryID.Value, DBNull.Value))
                        cmdH.Parameters.AddWithValue("@Notes", If(String.IsNullOrWhiteSpace(notes), CObj(DBNull.Value), notes.Trim()))

                        purchaseID = Convert.ToInt32(Await cmdH.ExecuteScalarAsync())
                    End Using

                    ' 2. حفظ التفاصيل وزيادة رصيد الخامات في المخزن المحدد بالوحدة الأساسية
                    For Each r As DataRow In items.Rows
                        Dim matID As Integer = Convert.ToInt32(r("MaterialID"))
                        Dim unitID As Integer = Convert.ToInt32(r("UnitID"))
                        Dim qty As Decimal = Convert.ToDecimal(r("Quantity"))
                        Dim factor As Decimal = Convert.ToDecimal(r("ConversionFactor"))
                        Dim baseQty As Decimal = qty * factor
                        Dim price As Decimal = Convert.ToDecimal(r("UnitPrice"))

                        Using materialCheck As New SqlCommand("SELECT UnitID FROM RawMaterials WHERE MaterialID=@ID AND IsActive=1 AND ISNULL(IsDeleted,0)=0", conn, trans)
                            materialCheck.Parameters.AddWithValue("@ID", matID)
                            Dim baseUnit = Await materialCheck.ExecuteScalarAsync()
                            If baseUnit Is Nothing OrElse IsDBNull(baseUnit) Then Throw New ArgumentException("الخامة غير متاحة أو ليس لها وحدة أساسية.")
                            If CInt(baseUnit) = unitID Then
                                If factor <> 1D Then Throw New ArgumentException("معامل الوحدة الأساسية يجب أن يساوي واحداً.")
                            Else
                                Using unitCheck As New SqlCommand("SELECT ConversionFactor FROM MaterialUnits WHERE MaterialID=@ID AND UnitID=@Unit", conn, trans)
                                    unitCheck.Parameters.AddWithValue("@ID", matID)
                                    unitCheck.Parameters.AddWithValue("@Unit", unitID)
                                    Dim currentFactor = Await unitCheck.ExecuteScalarAsync()
                                    If currentFactor Is Nothing OrElse CDec(currentFactor) <> factor Then Throw New ArgumentException("تغير تعريف الوحدة؛ أعد إضافة الخامة للفاتورة.")
                                End Using
                            End If
                        End Using
                        ' أ) إدراج السطر
                        Dim sqlDetail As String = "INSERT INTO PurchaseDetails (PurchaseID, MaterialID, UnitID, Quantity, ConversionFactor, UnitPrice, BaseUnitCost) " &
                                                  "VALUES (@PurchID, @MatID, @UnitID, @Qty, @Factor, @Price, @BaseCost)"
                        Using cmdD As New SqlCommand(sqlDetail, conn, trans)
                            cmdD.Parameters.AddWithValue("@PurchID", purchaseID)
                            cmdD.Parameters.AddWithValue("@MatID", matID)
                            cmdD.Parameters.AddWithValue("@UnitID", unitID)
                            cmdD.Parameters.AddWithValue("@Qty", qty)
                            cmdD.Parameters.AddWithValue("@Factor", factor)
                            cmdD.Parameters.AddWithValue("@Price", price)
                            cmdD.Parameters.AddWithValue("@BaseCost", Decimal.Round(price / factor * (netTotal / total), 6))
                            Await cmdD.ExecuteNonQueryAsync()
                        End Using

                        If updateCost Then
                            Using cost As New SqlCommand("UPDATE RawMaterials SET CostPrice=@Cost WHERE MaterialID=@ID; UPDATE MaterialUnits SET PurchasePrice=@Cost*ConversionFactor WHERE MaterialID=@ID;", conn, trans)
                                cost.Parameters.AddWithValue("@ID", matID)
                                cost.Parameters.AddWithValue("@Cost", Decimal.Round(price / factor * (netTotal / total), 6))
                                Await cost.ExecuteNonQueryAsync()
                            End Using
                        End If
                        ' ب) زيادة رصيد الخامة في المخزن بالوحدة الأساسية (BaseQuantity)
                        Dim sqlStock As String = "IF NOT EXISTS (SELECT 1 FROM StoreStock WITH(UPDLOCK,HOLDLOCK) WHERE StoreID = @StoreID AND MaterialID = @MatID) " &
                                                 "    INSERT INTO StoreStock (StoreID, MaterialID, CurrentStock) VALUES (@StoreID, @MatID, @BaseQty); " &
                                                 "ELSE " &
                                                 "    UPDATE StoreStock SET CurrentStock = ISNULL(CurrentStock,0) + @BaseQty WHERE StoreID = @StoreID AND MaterialID = @MatID;"
                        Using cmdStock As New SqlCommand(sqlStock, conn, trans)
                            cmdStock.Parameters.AddWithValue("@StoreID", storeID)
                            cmdStock.Parameters.AddWithValue("@MatID", matID)
                            cmdStock.Parameters.AddWithValue("@BaseQty", baseQty)
                            Await cmdStock.ExecuteNonQueryAsync()
                        End Using

                        ' ج) تسجيل حركة توريد في StockMovements
                        Dim sqlMove As String = "INSERT INTO StockMovements (StoreID, MaterialID, MovementType, Quantity, ReferenceID, CreatedDate) " &
                                                "VALUES (@StoreID, @MatID, 'PURCHASE', @BaseQty, @Ref, GETDATE())"
                        Using cmdMove As New SqlCommand(sqlMove, conn, trans)
                            cmdMove.Parameters.AddWithValue("@StoreID", storeID)
                            cmdMove.Parameters.AddWithValue("@MatID", matID)
                            cmdMove.Parameters.AddWithValue("@BaseQty", baseQty)
                            cmdMove.Parameters.AddWithValue("@Ref", purchaseID)
                            Await cmdMove.ExecuteNonQueryAsync()
                        End Using
                    Next

                    ' 3. تحديث حساب المورد بالمتبقي وتسجيل الحركة
                    ' CurrentBalance يزداد بالمبلغ المتبقي (الآجل) فقط
                    Dim sqlSupBal As String = "UPDATE Suppliers SET CurrentBalance = CurrentBalance + @Rem WHERE SupplierID = @SupID; " &
                                              "SELECT CurrentBalance FROM Suppliers WHERE SupplierID = @SupID;"
                    Dim supNewBal As Decimal = 0
                    Using cmdSup As New SqlCommand(sqlSupBal, conn, trans)
                        cmdSup.Parameters.AddWithValue("@Rem", remaining)
                        cmdSup.Parameters.AddWithValue("@SupID", supID)
                        supNewBal = Convert.ToDecimal(Await cmdSup.ExecuteScalarAsync())
                    End Using

                    ' تسجيل حركة المورد:
                    ' الدائن (Credit) = صافي الفاتورة (مبلغ مستحق للمورد مقابل البضاعة)
                    ' المدين (Debit) = المبلغ المسدد نقداً (ما دفعناه للمورد)
                    Dim sqlSupTrans As String = "INSERT INTO SupplierTransactions (SupplierID, TransactionType, ReferenceNo, Debit, Credit, BalanceBefore, BalanceAfter, Notes, UserID, TreasuryID, PaymentMethod) " &
                                                "VALUES (@SupID, 'PURCHASE', @Ref, @Debit, @Credit, @BalBefore, @BalAfter, @Notes, @User, @Treasury, @Method)"
                    Using cmdST As New SqlCommand(sqlSupTrans, conn, trans)
                        cmdST.Parameters.AddWithValue("@User", Session.CurrentUserID)
                        cmdST.Parameters.AddWithValue("@BalBefore", supBefore)
                        cmdST.Parameters.AddWithValue("@Treasury", If(treasuryID.HasValue, CObj(treasuryID.Value), DBNull.Value))
                        cmdST.Parameters.AddWithValue("@Method", paymentCode)
                        cmdST.Parameters.AddWithValue("@SupID", supID)
                        cmdST.Parameters.AddWithValue("@Ref", invNumber)
                        cmdST.Parameters.AddWithValue("@Debit", paid)
                        cmdST.Parameters.AddWithValue("@Credit", netTotal)
                        cmdST.Parameters.AddWithValue("@BalAfter", supNewBal)
                        cmdST.Parameters.AddWithValue("@Notes", $"فاتورة مشتريات رقم {invNumber}")
                        Await cmdST.ExecuteNonQueryAsync()
                    End Using

                    ' 4. خصم المسدد نقداً من الخزينة إن وجد
                    If paid > 0 AndAlso treasuryID.HasValue Then
                        Await TreasuryService.AddTransactionAsync(
                            treasuryID:=treasuryID.Value,
                            transactionType:=TreasuryTransactionTypes.SupplierPayment,
                            amount:=paid,
                            isDeposit:=False,
                            referenceID:=purchaseID,
                            referenceNo:=invNumber,
                            notes:=$"سداد نقدي لفاتورة مشتريات رقم {invNumber}",
                            userID:=Session.CurrentUserID,
                            cn:=conn,
                            trans:=trans
                        )
                    End If

                    trans.Commit()
                    Return purchaseID

                Catch ex As Exception
                    trans.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function
End Class
