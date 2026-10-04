Imports System.Drawing
Imports System.Math

''' <summary>
''' مساعد الأنيميشن المتقدم مع Easing Functions
''' </summary>
Public NotInheritable Class ToastAnimationHelper
    Private Sub New()
    End Sub

    ''' <summary>
    ''' دالة Easing للحصول على حركة سلسة وطبيعية
    ''' </summary>
    Public Shared Function EaseOutBack(t As Double, b As Double, c As Double, d As Double) As Double
        Const s As Double = 1.70158
        t = t / d - 1
        Return c * (t * t * ((s + 1) * t + s) + 1) + b
    End Function

    ''' <summary>
    ''' Ease Out Cubic - حركة انزلاق سلسة مع تباطؤ في النهاية
    ''' </summary>
    Public Shared Function EaseOutCubic(t As Double) As Double
        t -= 1
        Return t * t * t + 1
    End Function

    ''' <summary>
    ''' Ease In Out Cubic - حركة متوازنة في البداية والنهاية
    ''' </summary>
    Public Shared Function EaseInOutCubic(t As Double) As Double
        If t < 0.5 Then
            Return 4 * t * t * t
        Else
            Dim f As Double = (2 * t) - 2
            Return 0.5 * f * f * f + 1
        End If
    End Function

    ''' <summary>
    ''' Ease Out Elastic - حركة ارتدادية مرنة
    ''' </summary>
    Public Shared Function EaseOutElastic(t As Double) As Double
        If t = 0 Then Return 0
        If t = 1 Then Return 1

        Dim p As Double = 0.3
        Return Pow(2, -10 * t) * Sin((t - p / 4) * (2 * PI) / p) + 1
    End Function

    ''' <summary>
    ''' Ease Out Bounce - حركة ارتداد واقعية
    ''' </summary>
    Public Shared Function EaseOutBounce(t As Double) As Double
        If t < (1 / 2.75) Then
            Return 7.5625 * t * t
        ElseIf t < (2 / 2.75) Then
            t -= (1.5 / 2.75)
            Return 7.5625 * t * t + 0.75
        ElseIf t < (2.5 / 2.75) Then
            t -= (2.25 / 2.75)
            Return 7.5625 * t * t + 0.9375
        Else
            t -= (2.625 / 2.75)
            Return 7.5625 * t * t + 0.984375
        End If
    End Function

    ''' <summary>
    ''' حساب الموضع بناءً على نوع الأنيميشن
    ''' </summary>
    Public Shared Function CalculatePosition(
        startValue As Integer,
        endValue As Integer,
        currentStep As Integer,
        totalSteps As Integer,
        animationType As ToastAnimation
    ) As Integer
        If totalSteps = 0 Then Return endValue

        Dim progress As Double = CDbl(currentStep) / CDbl(totalSteps)
        Dim easedProgress As Double

        Select Case animationType
            Case ToastAnimation.Fade
                easedProgress = progress ' خطي للتلاشي

            Case ToastAnimation.Slide
                easedProgress = EaseOutCubic(progress)

            Case ToastAnimation.Scale
                easedProgress = EaseInOutCubic(progress)

            Case ToastAnimation.Bounce
                easedProgress = EaseOutBounce(progress)

            Case ToastAnimation.SlideWithBounce
                easedProgress = EaseOutElastic(progress)

            Case Else
                easedProgress = progress
        End Select

        Return CInt(startValue + (endValue - startValue) * easedProgress)
    End Function

    ''' <summary>
    ''' حساب الشفافية بناءً على التقدم
    ''' </summary>
    Public Shared Function CalculateOpacity(
        currentStep As Integer,
        totalSteps As Integer,
        isFadingIn As Boolean
    ) As Double
        If totalSteps = 0 Then Return If(isFadingIn, 1.0, 0.0)

        Dim progress As Double = CDbl(currentStep) / CDbl(totalSteps)

        If isFadingIn Then
            Return Math.Min(progress, 1.0)
        Else
            Return Math.Max(1.0 - progress, 0.0)
        End If
    End Function

    ''' <summary>
    ''' حساب Scale للتكبير/التصغير
    ''' </summary>
    Public Shared Function CalculateScale(
        currentStep As Integer,
        totalSteps As Integer,
        isScalingUp As Boolean
    ) As Double
        If totalSteps = 0 Then Return 1.0

        Dim progress As Double = CDbl(currentStep) / CDbl(totalSteps)

        If isScalingUp Then
            Return 0.8 + (0.2 * EaseOutBack(progress, 0, 1, 1))
        Else
            Return 1.0 - (0.2 * progress)
        End If
    End Function
End Class
