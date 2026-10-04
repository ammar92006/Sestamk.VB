Imports System
Imports System.Collections.Generic

Public Class InvoiceModel
    Public Property InvoiceID As Integer
    Public Property InvoiceNumber As String
    Public Property InvoiceDate As DateTime = DateTime.Now
    Public Property OrderType As Byte                 ' 1=Takeaway, 2=DineIn, 3=Delivery
    Public Property ShiftID As Integer
    Public Property UserID As Integer
    Public Property CustomerID As Integer?
    Public Property TableID As Integer?
    Public Property DriverID As Integer?
    Public Property DeliveryFee As Decimal = 0
    ''' <summary>رسوم خدمة الصالة — تُخزن في عمود DineInServiceFee (v1.3.0: توثيق الرسوم)</summary>
    Public Property DineInServiceFee As Decimal = 0
    ''' <summary>مبلغ الضريبة المحسوب للأصناف — يُخزن في عمود Tax (v1.3.0)</summary>
    Public Property TaxAmount As Decimal = 0
    Public Property TotalBeforeDiscount As Decimal = 0
    Public Property DiscountAmount As Decimal = 0
    Public Property NetTotal As Decimal = 0
    Public Property PaidAmount As Decimal = 0
    Public Property RemainingAmount As Decimal = 0
    Public Property IsCredit As Boolean = False
    Public Property TreasuryID As Integer?
    Public Property Notes As String

    Public Property BranchID As Integer?
    Public Property StoreID As Integer?

    ' تفاصيل الأصناف داخل الفاتورة
    Public Property Details As New List(Of InvoiceDetailModel)
End Class

Public Class InvoiceDetailModel
    Public Property DetailID As Integer
    Public Property InvoiceID As Integer
    Public Property ProductID As Integer
    Public Property ProductName As String
    Public Property SizeName As String
    Public Property AddonsText As String
    Public Property UnitPrice As Decimal
    Public Property Quantity As Integer
    Public Property TotalPrice As Decimal
    Public Property Notes As String

    ''' <summary>
    ''' معرّف الحجم المختار — يُستخدم لخصم/إرجاع وصفة الحجم من المخزن.
    ''' اختياري: يُملأ من شاشة البيع، ويبقى Nothing للسطور القديمة/المستوردة.
    ''' </summary>
    Public Property SizeID As Integer?

    ''' <summary>
    ''' معرّفات الإضافات المختارة — تُستخدم لخصم/إرجاع وصفة كل إضافة من المخزن.
    ''' </summary>
    Public Property AddonIDs As New List(Of Integer)

    ''' <summary>نسبة ضريبة السطر (%) — تُحفظ مع الفواتير المعلقة (JSON) ويتم تجاهلها عند التخزين في SalesInvoiceDetails</summary>
    Public Property TaxPercent As Decimal
End Class

' موديل الفاتورة المعلقة
Public Class PendingInvoiceModel
    Public Property PendingID As Integer
    Public Property PendingNumber As String
    Public Property PendingDate As DateTime
    Public Property ShiftID As Integer
    Public Property UserID As Integer
    Public Property OrderType As Byte
    Public Property CustomerID As Integer?
    Public Property CustomerName As String
    Public Property TableID As Integer?
    Public Property TableName As String
    Public Property DriverID As Integer?
    Public Property DriverName As String
    Public Property DeliveryFee As Decimal
    Public Property InvoiceJSON As String
    Public Property TotalAmount As Decimal
    Public Property Notes As String

    Public ReadOnly Property OrderTypeDisplay As String
        Get
            Select Case OrderType
                Case 1
                    Return "🥡 تيك أوي"
                Case 2
                    Return "🍽️ صالة"
                Case 3
                    Return "🛵 دليفري"
                Case Else
                    Return "طلب"
            End Select
        End Get
    End Property

    Public ReadOnly Property OrderReferenceDisplay As String
        Get
            Select Case OrderType
                Case 1
                    Return "استلام كاونتر"
                Case 2
                    Return If(Not String.IsNullOrWhiteSpace(TableName), "طاولة: " & TableName, "-")
                Case 3
                    Return If(Not String.IsNullOrWhiteSpace(DriverName), "الطيار: " & DriverName, "دليفري")
                Case Else
                    Return "-"
            End Select
        End Get
    End Property
End Class