Imports System

Public Class DeliveryDriverModel
    Public Property DriverID As Integer
    Public Property DriverCode As String
    Public Property DriverName As String
    Public Property Phone As String
    Public Property Phone2 As String
    Public Property NationalID As String
    Public Property EmployeeID As Integer?
    Public Property LicenseNumber As String
    Public Property VehicleType As String
    Public Property VehiclePlateNumber As String
    Public Property IsPercentage As Boolean
    Public Property DeliveryFeeValue As Decimal
    Public Property DriverStatus As Byte
    Public Property Notes As String
    Public Property IsActive As Boolean
    Public Property IsDeleted As Boolean
    Public Property CreatedAt As DateTime
    Public Property CreatedBy As Integer?
    Public Property AreaID As Integer?

    ' بيانات المنطقة المربوطة بالطيار (إن وجدت)
    Public Property AreaInfo As DeliveryAreaModel
End Class