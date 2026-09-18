Imports System

Public Class ShiftModel
    Public Property ShiftID As Integer
    Public Property ShiftNumber As String
    Public Property BranchID As Integer?
    Public Property UserID As Integer
    Public Property OpenDateTime As DateTime
    Public Property CloseDateTime As DateTime?
    Public Property OpeningCash As Decimal
    Public Property ClosingCash As Decimal?
    Public Property ExpectedCash As Decimal?
    Public Property CashDifference As Decimal?

    ' مبالغ الوردية
    Public Property TotalSales As Decimal = 0
    Public Property TotalVisaSales As Decimal = 0
    Public Property TotalRefunds As Decimal = 0
    Public Property TotalPurchases As Decimal = 0
    Public Property TotalPurchaseRefunds As Decimal = 0
    Public Property TotalExpenses As Decimal = 0
    Public Property TotalIncomes As Decimal = 0
    Public Property TotalOrders As Integer = 0

    ' الحالة
    Public Property Status As Byte = 1 ' 1 = مفتوحة, 2 = مغلقة, 3 = معلقة
    Public Property Notes As String
    Public Property ClosedByUserID As Integer?
    Public Property IsActive As Boolean = True
    Public Property IsDeleted As Boolean = False
    Public Property WorkShiftID As Integer?

    Public Property WorkShiftName As String
    Public Property TreasuryID As Integer? = Nothing

End Class