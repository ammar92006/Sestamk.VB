Imports System

Public Class ProductAddonModel
    Public Property ProductAddonID As Integer
    Public Property ProductID As Integer
    Public Property AddonID As Integer
    Public Property CostPrice As Decimal
    Public Property SalePrice As Decimal
    Public Property IsActive As Boolean
    Public Property IsDeleted As Boolean
    Public Property CreatedAt As DateTime
    Public Property SortOrder As Integer?
    Public Property IsDefault As Boolean?

    ' بيانات الإضافة من جدول Addons
    Public Property AddonInfo As AddonModel
End Class