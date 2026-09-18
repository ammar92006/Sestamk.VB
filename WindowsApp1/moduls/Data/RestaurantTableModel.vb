Imports System

Public Class RestaurantTableModel
    Public Property TableID As Integer
    Public Property TableNumber As String
    Public Property TableName As String
    Public Property SectionID As Integer
    Public Property ChairsCount As Integer
    Public Property TableStatus As Byte ' 1 = Free, 2 = Occupied, 3 = Reserved
    Public Property Notes As String
    Public Property IsActive As Boolean
    Public Property IsDeleted As Boolean
    Public Property CreatedAt As DateTime

    ' بيانات القسم المربوطة بالطاولة
    Public Property SectionInfo As RestaurantSectionModel
End Class