Imports System

Public Class CustomerModel
    Public Property CustomerID As Integer
    Public Property CustomerCode As String
    Public Property CustomerName As String
    Public Property Phone1 As String
    Public Property Phone2 As String
    Public Property Email As String
    Public Property AreaID As Integer?
    Public Property Address As String
    Public Property CurrentBalance As Decimal? = 0
    Public Property AllowCredit As Boolean? = False
    Public Property CreditLimit As Decimal? = 0
    Public Property IsDiscountPercent As Boolean? = True
    Public Property DiscountPercent As Double? = 0
    Public Property IsDeleted As Boolean? = False
    Public Property IsActive As Boolean? = True
    Public Property StopReason As String
    Public Property Rating As Byte? = 5
    Public Property Notes As String
    Public Property CreatedDate As DateTime?
    Public Property CreatedByUserID As Integer?
    Public Property LastTransactionDate As DateTime?

    ' بيانات المنطقة المربوطة من جدول DeliveryAreas
    Public Property AreaInfo As DeliveryAreaModel
End Class