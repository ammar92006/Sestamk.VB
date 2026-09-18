Imports System

Public Class ProductSizeModel
    Public Property ProductSizeID As Integer
    Public Property ProductID As Integer
    Public Property SizeID As Integer
    Public Property CostPrice As Decimal
    Public Property SalePrice As Decimal
    Public Property Barcode As String
    Public Property ImageBase64 As String
    Public Property IsDefault As Boolean
    Public Property SortOrder As Integer
    Public Property IsActive As Boolean
    Public Property IsDeleted As Boolean
    Public Property CreatedAt As DateTime

    ' بيانات الحجم من جدول Sizes
    Public Property SizeInfo As SizeModel
End Class