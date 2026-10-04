Imports System.Drawing

''' <summary>
''' نموذج Toast متطور مع جميع الخيارات والميزات
''' </summary>
Public Class ToastModelAdvanced
    Public Property Id As Guid = Guid.NewGuid()

    ' المحتوى
    Public Property Title As String
    Public Property Message As String
    Public Property Type As ToastType = ToastType.Success
    Public Property Priority As ToastPriority = ToastPriority.Normal

    ' الأيقونة والصورة
    Public Property Icon As String = Nothing
    Public Property CustomIcon As Image = Nothing
    Public Property ShowIcon As Boolean = True

    ' التوقيت والسلوك
    Public Property Duration As Integer = 3800
    Public Property AutoClose As Boolean = True
    Public Property IsSticky As Boolean = False ' إشعار ثابت لا يختفي تلقائياً
    Public Property CreatedAt As DateTime = DateTime.Now

    ' المظهر
    Public Property Position As ToastPosition = ToastPosition.BottomRight
    Public Property Animation As ToastAnimation = ToastAnimation.SlideWithBounce
    Public Property CustomBackColor As Color? = Nothing
    Public Property CustomForeColor As Color? = Nothing
    Public Property CustomAccentColor As Color? = Nothing
    Public Property Width As Integer = 340
    Public Property Height As Integer = 90

    ' الصوت
    Public Property Sound As ToastSound = ToastSound.SystemAsterisk
    Public Property CustomSoundPath As String = Nothing
    Public Property PlaySound As Boolean = True

    ' التفاعلية
    Public Property ClickAction As Action = Nothing
    Public Property CloseAction As Action = Nothing
    Public Property Buttons As List(Of ToastButton) = New List(Of ToastButton)
    Public Property IsExpandable As Boolean = False
    Public Property ExpandedMessage As String = Nothing
    Public Property ExpandedHeight As Integer = 150

    ' Progress Bar
    Public Property ShowProgressBar As Boolean = False
    Public Property ProgressBarColor As Color = Color.FromArgb(59, 130, 246)

    ' البيانات المرتبطة
    Public Property Tag As Object = Nothing
    Public Property RelatedNotificationId As Integer? = Nothing

    ' التجميع
    Public Property GroupKey As String = Nothing ' لتجميع الإشعارات المتشابهة
    Public Property CanStack As Boolean = False
End Class

''' <summary>
''' نموذج زر التفاعل داخل Toast
''' </summary>
Public Class ToastButton
    Public Property Text As String
    Public Property Action As Action
    Public Property BackColor As Color = Color.FromArgb(59, 130, 246)
    Public Property ForeColor As Color = Color.White
    Public Property CloseToastOnClick As Boolean = True
End Class

''' <summary>
''' نموذج مجموعة إشعارات مكدسة
''' </summary>
Public Class ToastGroup
    Public Property GroupKey As String
    Public Property Toasts As List(Of ToastModelAdvanced) = New List(Of ToastModelAdvanced)
    Public Property DisplayedToast As ToastModelAdvanced
    Public ReadOnly Property Count As Integer
        Get
            Return Toasts.Count
        End Get
    End Property
End Class
