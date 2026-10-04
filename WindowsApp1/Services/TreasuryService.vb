Imports System.Data.SqlClient

Public Class TreasuryService

    Public Shared Async Function UpdateBalanceAsync(
    treasuryId As Integer,
    cn As SqlConnection,
    trans As SqlTransaction,
    Optional isDeposit As Boolean = True) As Task

        ' 1. استعلام لحساب الرصيد الجديد المتوقع بعد الحركة الحالية مع مراعاة الرصيد الافتتاحي للخزنة
        Const sqlCalculate As String = "
        SELECT ISNULL(T.OpeningBalance, 0) + ISNULL(
            (SELECT SUM(CASE WHEN TT.IsDeposit = 1 THEN TT.Amount ELSE -TT.Amount END) 
             FROM TreasuryTransactions TT 
             WHERE TT.TreasuryID = T.TreasuryID), 
            0
        ) 
        FROM Treasury T 
        WHERE T.TreasuryID = @TreasuryID"

        Dim newBalance As Decimal = 0

        ' حساب الرصيد الجديد
        Using cmdCalc As New SqlCommand(sqlCalculate, cn, trans)
            cmdCalc.Parameters.Add("@TreasuryID", SqlDbType.Int).Value = treasuryId

            ' استخدام ExecuteScalarAsync لأننا نحتاج قيمة واحدة فقط (الرصيد)
            Dim result = Await cmdCalc.ExecuteScalarAsync()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                newBalance = Convert.ToDecimal(result)
            End If
        End Using

        ' 2. الشرط الحاسم: فحص عدم كفاية الرصيد يكون فقط في حركات الصرف/السحب (isDeposit = False)
        ' أما في حركات الإيداع والبيع، فالأموال تدخل الخزينة ولا يجوز منع الإيداع أبداً
        If Not isDeposit AndAlso newBalance < 0 Then
            ' رمي الخطأ هنا سيجعل الـ Catch في فورم الحفظ تعمل تلقائياً، ويتم عمل Rollback للحركة كأنها لم تكن
            Throw New InvalidOperationException("عذراً، لا يمكن إتمام العملية نظراً لعدم وجود رصيد كافٍ في الخزنة.")
        End If

        ' 3. إذا كان الرصيد سليماً أو الحركة إيداع، نقوم بتحديث جدول الخزنة
        Const sqlUpdate As String = "
        UPDATE Treasury 
        SET CurrentBalance = @NewBalance 
        WHERE TreasuryID = @TreasuryID"

        Using cmdUpdate As New SqlCommand(sqlUpdate, cn, trans)
            cmdUpdate.Parameters.Add("@TreasuryID", SqlDbType.Int).Value = treasuryId

            cmdUpdate.Parameters.Add("@NewBalance", SqlDbType.Decimal).Value = newBalance
            cmdUpdate.Parameters("@NewBalance").Precision = 18
            cmdUpdate.Parameters("@NewBalance").Scale = 2

            Await cmdUpdate.ExecuteNonQueryAsync()
        End Using

    End Function

    Public Shared Async Function HasTransactionsAsync(TreasuryID As Integer) As Task(Of Boolean)

        Using cn As SqlConnection = Await NewConnAsync()

            Dim sql As String =
"
SELECT COUNT(*)
FROM TreasuryTransactions
WHERE TreasuryID=@TreasuryID
"

            Using cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@TreasuryID", TreasuryID)

                Return Convert.ToInt32(Await cmd.ExecuteScalarAsync()) > 0

            End Using

        End Using

    End Function



    Public Shared Async Function AddTransactionAsync(
    treasuryID As Integer,
    transactionType As TreasuryTransactionTypes,
    amount As Decimal,
    isDeposit As Boolean,
    referenceID As Integer,
    referenceNo As String,
    notes As String,
    userID As Integer,
    cn As SqlConnection,
    trans As SqlTransaction) As Task

        ' Serialize writers before inserting and recalculating this treasury.
        ' The lock is held by the caller's transaction through commit/rollback.
        Using lockCommand As New SqlCommand("SELECT TreasuryID FROM Treasury WITH (UPDLOCK,HOLDLOCK) WHERE TreasuryID=@ID", cn, trans)
            lockCommand.Parameters.AddWithValue("@ID", treasuryID)
            If Await lockCommand.ExecuteScalarAsync() Is Nothing Then Throw New ArgumentException("الخزينة غير موجودة.")
        End Using

        Const sql As String = "INSERT INTO TreasuryTransactions 
                           (TreasuryID, TransactionDate, TransactionType, ReferenceID, ReferenceNo, Amount, IsDeposit, Notes, UserID, CreatedDate) 
                           VALUES 
                           (@TreasuryID, GETDATE(), @TransactionType, @ReferenceID, @ReferenceNo, @Amount, @IsDeposit, @Notes, @UserID, GETDATE())"

        Using cmd As New SqlCommand(sql, cn, trans)

            cmd.Parameters.Add("@TreasuryID", SqlDbType.Int).Value = treasuryID
            cmd.Parameters.Add("@TransactionType", SqlDbType.Int).Value = CInt(transactionType)
            cmd.Parameters.Add("@ReferenceID", SqlDbType.Int).Value = referenceID

            ' معالجة النصوص الفارغة لتخزينها كـ NULL في القاعدة إن كانت فارغة
            cmd.Parameters.Add("@ReferenceNo", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrEmpty(referenceNo), DBNull.Value, referenceNo)

            ' SqlClient يقصّ القيمة (لا يقرّبها) عند تحديد Scale=2 — لذلك نقرّب هنا أولاً
            ' حتى لا يفقد المبلغ كسوراً مثل 250.555 وتصبح 250.55 بدل 250.56
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Math.Round(amount, 2)
            cmd.Parameters("@Amount").Precision = 18
            cmd.Parameters("@Amount").Scale = 2

            cmd.Parameters.Add("@IsDeposit", SqlDbType.Bit).Value = isDeposit
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = If(String.IsNullOrEmpty(notes), DBNull.Value, notes)
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID

            Await cmd.ExecuteNonQueryAsync()
        End Using

        ' تنبيه هام جداً: يجب أن تدعم الدالة بالأسفل استقبال الـ trans وتمريره للـ SqlCommand الداخلي بها
        Await UpdateBalanceAsync(treasuryID, cn, trans, isDeposit)

    End Function

    Public Shared Async Function TransferBetweenTreasuriesAsync(
    fromTreasuryID As Integer,
    toTreasuryID As Integer,
    amount As Decimal,
    notes As String,
    userID As Integer) As Task

        Using cn As SqlConnection = Await NewConnAsync()
            Using trans As SqlTransaction = cn.BeginTransaction()
                Try
                    ' --- 1. تسجيل حركة السحب من الخزنة المصدر ---
                    Await AddTransactionAsync(
                        treasuryID:=fromTreasuryID,
                        transactionType:=TreasuryTransactionTypes.Transfer, ' القيمة 8 من الـ Enum الخاص بك
                        amount:=amount,
                        isDeposit:=False, ' سحب
                        referenceID:=toTreasuryID, ' نضع رقم الخزنة الأخرى كمرجع للحركة
                        referenceNo:="تحويل صادر",
                        notes:=notes,
                        userID:=userID,
                        cn:=cn,
                        trans:=trans
                    )

                    ' --- 2. تسجيل حركة الإيداع في الخزنة الهدف ---
                    Await AddTransactionAsync(
                        treasuryID:=toTreasuryID,
                        transactionType:=TreasuryTransactionTypes.Transfer, ' نفس القيمة 8
                        amount:=amount,
                        isDeposit:=True, ' إيداع
                        referenceID:=fromTreasuryID, ' نضع رقم الخزنة المصدر كمرجع
                        referenceNo:="تحويل وارد",
                        notes:=notes,
                        userID:=userID,
                        cn:=cn,
                        trans:=trans
                    )

                    ' إذا نجحت العمليتان ولم يحدث استثناء بسبب الرصيد السالب، يتم الحفظ النهائي
                    trans.Commit()

                Catch
                    ' في حال حدوث أي خطأ (مثل خطأ الرصيد السالب)، يتم إلغاء السحب والإيداع كلياً تلقائياً
                    Throw
                End Try
            End Using
        End Using
    End Function


    'Public Shared Async Function GetTransactionsReportAsync(
    'treasuryID As Integer?,
    'transactionType As Integer?,
    'fromDate As DateTime,
    'toDate As DateTime,
    'searchText As String) As Task(Of DataTable)

    '    Dim dt As New DataTable()

    '    ' استعلام يجلب البيانات مع عمل Join لاسم الخزنة واسم المستخدم
    '    Const sql As String = "
    '    SELECT 
    '        T.TransactionID,
    '        Tr.TreasuryNameAr As [الخزنة],
    '        T.TransactionDate As [التاريخ],
    '        CASE 
    '            WHEN T.TransactionType = 1 THEN N'رصيد إفتتاحي'
    '            WHEN T.TransactionType = 2 THEN N'مبيعات'
    '            WHEN T.TransactionType = 3 THEN N'مشتريات'
    '            WHEN T.TransactionType = 4 THEN N'سند قبض عميل'
    '            WHEN T.TransactionType = 5 THEN N'سند صرف مورد'
    '            WHEN T.TransactionType = 6 THEN N'مصروفات'
    '            WHEN T.TransactionType = 7 THEN N'إيرادات'
    '            WHEN T.TransactionType = 8 THEN N'تحويل بين الخزن'
    '            WHEN T.TransactionType = 9 THEN N'مرتجع مبيعات'
    '            WHEN T.TransactionType = 10 THEN N'مرتجع مشتريات'
    '            WHEN T.TransactionType = 11 THEN N'إيداع يدوي'
    '            WHEN T.TransactionType = 12 THEN N'سحب يدوي'
    '            ELSE N'أخرى'
    '        END As [نوع الحركة],
    '        T.ReferenceNo As [رقم المرجع],
    '        CASE WHEN T.IsDeposit = 1 THEN T.Amount ELSE 0 END As [إيداع (+)],
    '        CASE WHEN T.IsDeposit = 0 THEN T.Amount ELSE 0 END As [سحب (-)],
    '        T.Notes As [الملاحظات],
    '        U.User_Name As [المستخدم]
    '    FROM TreasuryTransactions T
    '    INNER JOIN Treasury Tr ON T.TreasuryID = Tr.TreasuryID
    '    LEFT JOIN Users_TBL U ON T.UserID = U.User_ID
    '    WHERE 
    '        (CAST(T.TransactionDate As Date) BETWEEN @FromDate AND @ToDate)
    '        AND (@TreasuryID IS NULL OR T.TreasuryID = @TreasuryID)
    '        AND (@TransactionType IS NULL OR T.TransactionType = @TransactionType)
    '        AND (@SearchText = '' OR T.ReferenceNo LIKE @SearchText OR T.Notes LIKE @SearchText)
    '    ORDER BY T.TransactionID DESC"

    '    Using cn As SqlConnection = Await NewConnAsync()
    '        Using cmd As New SqlCommand(sql, cn)
    '            ' تمرير البارامترات مع التعامل مع القيم الفارغة (DBNull)
    '            cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date
    '            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate.Date
    '            cmd.Parameters.Add("@TreasuryID", SqlDbType.Int).Value = If(treasuryID.HasValue, treasuryID.Value, DBNull.Value)
    '            cmd.Parameters.Add("@TransactionType", SqlDbType.Int).Value = If(transactionType.HasValue, transactionType.Value, DBNull.Value)
    '            cmd.Parameters.Add("@SearchText", SqlDbType.NVarChar, 100).Value = If(String.IsNullOrEmpty(searchText), "", "%" & searchText & "%")

    '            Using da As New SqlDataAdapter(cmd)
    '                Await Task.Run(Sub() da.Fill(dt))
    '            End Using
    '        End Using
    '    End Using

    '    Return dt
    'End Function


    Public Shared Async Function GetTransactionsReportAsync(
    treasuryID As Integer?,
    transactionType As Integer?,
    userID As Integer?, ' ⬅️ أضفنا هذا البارامتر الجديد
    fromDate As DateTime,
    toDate As DateTime,
    searchText As String) As Task(Of DataTable)

        Dim dt As New DataTable()

        Const sql As String = "
        SELECT 
            T.TransactionID,
            Tr.TreasuryNameAr As [الخزنة],
            T.TransactionDate As [التاريخ],
            CASE 
                WHEN T.TransactionType = 1 THEN N'رصيد إفتتاحي'
                WHEN T.TransactionType = 2 THEN N'مبيعات'
                WHEN T.TransactionType = 3 THEN N'مشتريات'
                WHEN T.TransactionType = 4 THEN N'سند قبض عميل'
                WHEN T.TransactionType = 5 THEN N'سند صرف مورد'
                WHEN T.TransactionType = 6 THEN N'مصروفات'
                WHEN T.TransactionType = 7 THEN N'إيرادات'
                WHEN T.TransactionType = 8 THEN N'تحويل بين الخزن'
                WHEN T.TransactionType = 9 THEN N'مرتجع مبيعات'
                WHEN T.TransactionType = 10 THEN N'مرتجع مشتريات'
                WHEN T.TransactionType = 11 THEN N'إيداع يدوي'
                WHEN T.TransactionType = 12 THEN N'سحب يدوي'
                ELSE N'أخرى'
            END As [نوع الحركة],
            T.ReferenceNo As [رقم المرجع],
            CASE WHEN T.IsDeposit = 1 THEN T.Amount ELSE 0 END As [إيداع (+)],
            CASE WHEN T.IsDeposit = 0 THEN T.Amount ELSE 0 END As [سحب (-)],
            T.Notes As [الملاحظات],
            U.User_Name As [المستخدم]
        FROM TreasuryTransactions T
        INNER JOIN Treasury Tr ON T.TreasuryID = Tr.TreasuryID
        LEFT JOIN Users_TBL U ON T.UserID = U.User_ID
        WHERE 
            (CAST(T.TransactionDate As Date) BETWEEN @FromDate AND @ToDate)
            AND (@TreasuryID IS NULL OR T.TreasuryID = @TreasuryID)
            AND (@TransactionType IS NULL OR T.TransactionType = @TransactionType)
            AND (@UserID IS NULL OR T.UserID = @UserID) 
            AND (@SearchText = '' OR T.ReferenceNo LIKE @SearchText OR T.Notes LIKE @SearchText)
        ORDER BY T.TransactionID DESC"

        Using cn As SqlConnection = Await NewConnAsync()
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate.Date
                cmd.Parameters.Add("@TreasuryID", SqlDbType.Int).Value = If(treasuryID.HasValue, treasuryID.Value, DBNull.Value)
                cmd.Parameters.Add("@TransactionType", SqlDbType.Int).Value = If(transactionType.HasValue, transactionType.Value, DBNull.Value)
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = If(userID.HasValue, userID.Value, DBNull.Value) ' ⬅️ تمرير قيمة المستخدم
                cmd.Parameters.Add("@SearchText", SqlDbType.NVarChar, 100).Value = If(String.IsNullOrEmpty(searchText), "", "%" & searchText & "%")

                Using da As New SqlDataAdapter(cmd)
                    Await Task.Run(Sub() da.Fill(dt))
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Shared Async Function GetAllTreasuriesAsync() As Task(Of DataTable)
        Dim dt As New DataTable()

        ' نفس الاستعلام والحقول المستخدمة في شاشاتك
        Const sql As String = "
        SELECT 
            TreasuryID, 
            TreasuryNameAr 
        FROM Treasury 
        WHERE IsActive = 1 AND IsDeleted = 0
        ORDER BY TreasuryNameAr ASC"

        Try
            Using cn As SqlConnection = Await NewConnAsync()
                Using cmd As New SqlCommand(sql, cn)
                    Using da As New SqlDataAdapter(cmd)
                        ' تشغيل الـ Fill في سياق خيط منفصل (Task) للحفاظ على سلاسة واجهة البرنامج
                        Await Task.Run(Sub() da.Fill(dt))
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' يفضل إعادة رمي الخطأ ليتم التعامل معه وعرضه في واجهة الفورم المستدعي
            Throw New Exception("فشل جلب بيانات الخزن من السيرفر: " & ex.Message, ex)
        End Try

        Return dt
    End Function
End Class
