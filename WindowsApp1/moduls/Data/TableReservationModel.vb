Imports System

Namespace Global.WindowsApp1
    Public Enum ReservationStatus As Byte
        Confirmed = 1   ' مؤكد وقيد الانتظار
        Seated = 2      ' حضر العميل وتم تسكينه على الطاولة
        Cancelled = 3   ' تم الإلغاء
        NoShow = 4      ' لم يحضر العميل
    End Enum

    Public Class TableReservationModel
        Public Property ReservationID As Integer
        Public Property ReservationNumber As String
        Public Property TableID As Integer
        Public Property TableName As String
        Public Property CustomerName As String
        Public Property CustomerPhone As String
        Public Property GuestCount As Integer = 2
        Public Property ReservationDateTime As DateTime = DateTime.Now
        Public Property DepositAmount As Decimal = 0
        Public Property TreasuryID As Integer?
        Public Property Status As ReservationStatus = ReservationStatus.Confirmed
        Public Property Notes As String
        Public Property CreatedAt As DateTime = DateTime.Now
        Public Property CreatedByUserID As Integer = 1

        Public ReadOnly Property StatusName As String
            Get
                Select Case Status
                    Case ReservationStatus.Confirmed : Return "مؤكد 🟡"
                    Case ReservationStatus.Seated : Return "تم التسكين 🔴"
                    Case ReservationStatus.Cancelled : Return "ملغي ⚪"
                    Case ReservationStatus.NoShow : Return "لم يحضر ❌"
                    Case Else : Return "غير محدد"
                End Select
            End Get
        End Property

        Public ReadOnly Property IsUpcoming As Boolean
            Get
                Return Status = ReservationStatus.Confirmed AndAlso ReservationDateTime >= DateTime.Now.Date
            End Get
        End Property
    End Class
End Namespace
