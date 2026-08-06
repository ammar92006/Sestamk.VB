Public Class TreasuryTransactionModel

    Public Property TreasuryID As Integer

    Public Property TransactionType As TreasuryTransactionTypes

    Public Property Amount As Decimal

    Public Property IsDeposit As Boolean

    Public Property ReferenceID As Integer?

    Public Property ReferenceNo As String

    Public Property Notes As String

    Public Property UserID As Integer?

End Class

Public Enum TreasuryTransactionTypes

    OpeningBalance = 1

    Sale = 2

    Purchase = 3

    CustomerReceipt = 4

    SupplierPayment = 5

    Expense = 6

    Income = 7

    Transfer = 8

    SaleReturn = 9

    PurchaseReturn = 10

    ManualDeposit = 11

    ManualWithdraw = 12

End Enum