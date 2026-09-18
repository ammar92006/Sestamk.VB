Imports System
Imports System.Collections.Generic

Namespace Global.WindowsApp1
    Public Enum KitchenWasteType As Byte
        RawMaterialSpoilage = 1  ' خامة تالفة / فاسدة
        PreparationLoss = 2      ' سوء إعداد / طهي بالخطأ
        ExpiredMaterial = 3      ' انتهاء تاريخ الصلاحية
        DamagedMeal = 4          ' وجبة كاملة تالفة أو مرتجعة لسوء الجودة
    End Enum

    Public Class KitchenWasteModel
        Public Property WasteID As Integer
        Public Property WasteNumber As String
        Public Property WasteDate As DateTime = DateTime.Now
        Public Property WasteType As KitchenWasteType = KitchenWasteType.RawMaterialSpoilage
        Public Property StoreID As Integer = 1
        Public Property StoreName As String
        Public Property TotalLossAmount As Decimal = 0
        Public Property ShiftID As Integer?
        Public Property UserID As Integer = 1
        Public Property ResponsibleStaffName As String
        Public Property Reason As String
        Public Property CreatedAt As DateTime = DateTime.Now
        Public Property Details As New List(Of KitchenWasteDetailModel)

        Public ReadOnly Property WasteTypeName As String
            Get
                Select Case WasteType
                    Case KitchenWasteType.RawMaterialSpoilage : Return "خامة تالفة / تالف إعداد"
                    Case KitchenWasteType.PreparationLoss : Return "سوء إعداد / خطأ طهي"
                    Case KitchenWasteType.ExpiredMaterial : Return "انتهاء صلاحية"
                    Case KitchenWasteType.DamagedMeal : Return "وجبة تالفة"
                    Case Else : Return "أخرى"
                End Select
            End Get
        End Property
    End Class

    Public Class KitchenWasteDetailModel
        Public Property DetailID As Integer
        Public Property WasteID As Integer
        Public Property MaterialID As Integer?
        Public Property ProductID As Integer?
        Public Property ItemName As String
        Public Property Quantity As Decimal = 1
        Public Property UnitName As String
        Public Property UnitCost As Decimal = 0
        Public Property TotalCost As Decimal = 0
        Public Property Notes As String
    End Class
End Namespace
