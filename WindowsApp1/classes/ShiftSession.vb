Public Class ShiftSession

    Public Shared Property CurrentShift As ShiftModel

    ' التأكد أن الوردية موجودة ونشطة وليست معلقة أو مغلقة
    Public Shared ReadOnly Property HasActiveShift As Boolean
        Get
            Return CurrentShift IsNot Nothing AndAlso CurrentShift.Status = 1
        End Get
    End Property

    ' تفريغ الوردية من الذاكرة عند التعليق أو الإغلاق
    Public Shared Sub ClearSession()
        CurrentShift = Nothing
    End Sub

End Class