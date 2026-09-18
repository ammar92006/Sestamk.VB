Imports System.Collections.Generic

Public Class OrderItemModel
    Public Property Product_ID As Integer
    Public Property ProductName As String
    Public Property SelectedSize As ProductSizeModel
    Public Property SelectedAddons As New List(Of ProductAddonModel)
    Public Property Quantity As Integer = 1
    Public Property Notes As String = ""

    ' حساب السعر الإجمالي الصافي بناءً على الأحجام والإضافات المحددة
    Public ReadOnly Property TotalPrice As Decimal
        Get
            Dim basePrice As Decimal = If(SelectedSize IsNot Nothing, SelectedSize.SalePrice, 0)
            Dim addonsTotal As Decimal = 0

            For Each addon In SelectedAddons
                addonsTotal += addon.SalePrice
            Next

            Return (basePrice + addonsTotal) * Quantity
        End Get
    End Property
End Class