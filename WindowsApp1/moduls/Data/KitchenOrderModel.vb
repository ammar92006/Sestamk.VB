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

        ' حساب وقت التحضير المتوقع للأوردر بالكامل (أقصى وقت بين أصنافه أو 10 دقائق افتراضياً)
        Public ReadOnly Property EstimatedPrepMinutes As Integer
            Get
                Dim maxMins As Integer = 0
                If Items IsNot Nothing AndAlso Items.Count > 0 Then
                    For Each itm In Items
                        If itm.PreparationTime.HasValue Then
                            Dim m As Integer = CInt(Math.Ceiling(itm.PreparationTime.Value.TotalMinutes))
                            If m > maxMins Then maxMins = m
                        End If
                    Next
                End If
                Return If(maxMins > 0, maxMins, 10)
            End Get
        End Property

        Public ReadOnly Property HasCustomPrepTime As Boolean
            Get
                Return Items IsNot Nothing AndAlso Items.Any(Function(x) x.PreparationTime.HasValue AndAlso x.PreparationTime.Value.TotalMinutes > 0)
            End Get
        End Property

        Public ReadOnly Property EstimatedPrepFormatted As String
            Get
                Return $"{EstimatedPrepMinutes} د"
            End Get
        End Property

        Public ReadOnly Property IsOverdue As Boolean
            Get
                Return ElapsedSeconds > (EstimatedPrepMinutes * 60)
            End Get
        End Property

        Public ReadOnly Property OverdueMinutes As Integer
            Get
                Dim diffSec = ElapsedSeconds - (EstimatedPrepMinutes * 60)
                Return If(diffSec > 0, CInt(Math.Ceiling(diffSec / 60.0)), 0)
            End Get
        End Property

        Public ReadOnly Property PrepProgressRatio As Double
            Get
                Dim totalEstSec = EstimatedPrepMinutes * 60.0
                If totalEstSec <= 0 Then Return 1.0
                Return Math.Min(2.0, ElapsedSeconds / totalEstSec)
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
        Public Property PreparationTime As TimeSpan?

        Public ReadOnly Property PrepMinutes As Integer
            Get
                If PreparationTime.HasValue AndAlso PreparationTime.Value.TotalMinutes > 0 Then
                    Return CInt(Math.Ceiling(PreparationTime.Value.TotalMinutes))
                End If
                Return 0
            End Get
        End Property
    End Class
End Namespace
