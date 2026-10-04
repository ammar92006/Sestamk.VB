Imports System.ComponentModel

' ========================================================
' Enumerations للتحكم في نظام Toast Notification المتطور
' ========================================================

''' <summary>
''' أنواع الإشعارات المدعومة
''' </summary>
Public Enum ToastType
    Success = 0
    Info = 1
    Warning = 2
    [Error] = 3
    Question = 4
    Custom = 5
End Enum

''' <summary>
''' أولوية الإشعار
''' </summary>
Public Enum ToastPriority
    Low = 0
    Normal = 1
    High = 2
    Critical = 3
End Enum

''' <summary>
''' مواضع عرض الإشعارات على الشاشة
''' </summary>
Public Enum ToastPosition
    <Description("أسفل اليمين")>
    BottomRight = 0

    <Description("أسفل اليسار")>
    BottomLeft = 1

    <Description("أسفل الوسط")>
    BottomCenter = 2

    <Description("أعلى اليمين")>
    TopRight = 3

    <Description("أعلى اليسار")>
    TopLeft = 4

    <Description("أعلى الوسط")>
    TopCenter = 5

    <Description("الوسط")>
    Center = 6
End Enum

''' <summary>
''' نوع الأنيميشن عند الظهور/الاختفاء
''' </summary>
Public Enum ToastAnimation
    <Description("انزلاق")>
    Slide = 0

    <Description("تلاشي")>
    Fade = 1

    <Description("تكبير")>
    Scale = 2

    <Description("ارتداد")>
    Bounce = 3

    <Description("انزلاق مع ارتداد")>
    SlideWithBounce = 4
End Enum

''' <summary>
''' نوع الأصوات المدعومة
''' </summary>
Public Enum ToastSound
    None = 0
    SystemBeep = 1
    SystemAsterisk = 2
    SystemExclamation = 3
    SystemHand = 4
    SystemQuestion = 5
    Custom = 6
End Enum

''' <summary>
''' اتجاه الانزلاق
''' </summary>
Public Enum SlideDirection
    FromRight = 0
    FromLeft = 1
    FromTop = 2
    FromBottom = 3
End Enum
