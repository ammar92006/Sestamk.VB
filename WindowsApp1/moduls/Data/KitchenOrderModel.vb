Imports System
Imports System.Collections.Generic

Namespace Global.WindowsApp1
    Public Enum KitchenOrderStatus As Byte
        [New] = 0           ' طلب جديد لم يبدأ تحضيره
        Preparing = 1       ' جاري التحضير
        Ready = 2           ' جاهز للتقديم
        Bumped = 3          ' تم التسليم / مفرغ من الشاشة
        Cancelled = 4       ' ملغي
    End Enum

    Public Class KitchenOrderModel
        Public Property KitchenOrderID As Integer
        Public Property OrderNumber As String
        Public Property OrderType As Byte            ' 1: Takeaway, 2: DineIn, 3: Delivery
        Public Property TableID As Integer?
        Public Property TableName As String
        Public Property CustomerName As String
        Public Property ServerName As String
        Public Property CreatedAt As DateTime = DateTime.Now
        Public Property Status As KitchenOrderStatus = KitchenOrderStatus.New
        Public Property PreparationStartedAt As DateTime?
        Public Property ReadyAt As DateTime?
        Public Property CompletedAt As DateTime?
        Public Property Notes As String
        Public Property Items As New List(Of KitchenOrderItemModel)

        ' خصائص مساعدة للعرض
        Public ReadOnly Property OrderTypeDisplay As String
            Get
                Select Case OrderType
                    Case 1 : Return "تيك أوي"
                    Case 2 : Return If(Not String.IsNullOrEmpty(TableName), "صالة | طاولة: " & TableName, "صالة")
                    Case 3 : Return "دليفري"
                    Case Else : Return "طلب محلي"
                End Select
            End Get
        End Property

        Public ReadOnly Property ElapsedSeconds As Integer
            Get
                Return Math.Max(0, CInt((DateTime.Now - CreatedAt).TotalSeconds))
            End Get
        End Property

        Public ReadOnly Property ElapsedFormatted As String
            Get
                Dim ts As TimeSpan = DateTime.Now - CreatedAt
                If ts.TotalHours >= 1 Then
                    Return String.Format("{0:00}:{1:00}:{2:00}", CInt(Math.Floor(ts.TotalHours)), ts.Minutes, ts.Seconds)
                Else
                    Return String.Format("{0:00}:{1:00}", Math.Max(0, ts.Minutes), Math.Max(0, ts.Seconds))
                End If
            End Get
        End Property
    End Class

    Public Class KitchenOrderItemModel
        Public Property DetailID As Integer
        Public Property KitchenOrderID As Integer
        Public Property ProductID As Integer
        Public Property ProductName As String
        Public Property SizeName As String
        Public Property AddonsText As String
        Public Property Quantity As Integer
        Public Property Notes As String
        Public Property IsCompleted As Boolean = False
        Public Property StationName As String
    End Class
End Namespace
