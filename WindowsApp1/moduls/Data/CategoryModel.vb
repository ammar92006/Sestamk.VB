Public Class CategoryModel
    Public Property Category_ID As Integer
    Public Property CategoryCode As String
    Public Property Category_NameAr As String
    Public Property CategoryNameEn As String
    Public Property Imagebase64 As String
    Public Property Description As String
    Public Property IsActive As Boolean
    Public Property IsDeleted As Boolean
    Public Property ColorID As Integer?
    Public Property CategoryTypeID As Integer?
    Public Property PrinterID As Integer?

    ' موديل اللون المرتبط بالقسم
    Public Property CategoryColor As ColorModel
End Class