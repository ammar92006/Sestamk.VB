Imports System

Public Class ProductModel
    Public Property Product_ID As Integer
    Public Property ProductCode As String
    Public Property Barcode As String
    Public Property ProductNameAr As String
    Public Property ProductNameEn As String

    Public ReadOnly Property ProductName As String
        Get
            Return If(Not String.IsNullOrEmpty(ProductNameAr), ProductNameAr, If(ProductNameEn, ""))
        End Get
    End Property
    Public Property Image As String                  ' مطابق لاسم العمود Image في الصورة
    Public Property Description As String
    Public Property DiscountPercent As Double?
    Public Property TaxPercent As Double?
    Public Property IsActive As Boolean?
    Public Property IsDeleted As Boolean?
    Public Property PreparationTime As TimeSpan?
    Public Property Notes As String
    Public Property Category_ID As Integer?
    Public Property IsDiscountPercent As Boolean?
    Public Property IsTaxPercent As Boolean?

    ' السعر الافتراضي بعد الخصم أو السعر الأساسي
    Public Property BasePrice As Decimal = 0 ' يمكن ضبطه حسب جدول أسعار الأحجام أو السعر الأساسي
    Public Property SizesCount As Integer = 0
    Public Property AddonsCount As Integer = 0
    Public Property DefaultPrice As Decimal = 0
    Public Property IsDirect As Boolean? = True

    Public ReadOnly Property IsDirectItem As Boolean
        Get
            If IsDirect.HasValue Then
                Return IsDirect.Value
            End If
            Return SizesCount <= 1 AndAlso AddonsCount = 0
        End Get
    End Property
End Class