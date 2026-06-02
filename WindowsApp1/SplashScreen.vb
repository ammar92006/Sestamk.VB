Imports System.ComponentModel

Public Class SplashScreen

    ' متغيرات التحكم بالوقت
    ' يمكن تعديل TotalDisplayTime لزيادة أو تقليل وقت انتظار الشاشة
    Private Const TotalDisplayTime As Integer = 4000 ' إجمالي وقت العرض بالمللي ثانية (4 ثوانٍ)
    Private Const FadeTime As Integer = 400         ' وقت التلاشي للداخل وللخارج بالمللي ثانية (0.4 ثانية)

    ' سرعة الحركة (مهم للحركة الناعمة)
    Private Const AnimationInterval As Integer = 20 ' التحديث كل 20 مللي ثانية لحركة ناعمة

    Private elapsedTime As Integer = 0 ' الوقت المنقضي

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' لضمان البدء من الصفر
        Me.Opacity = 0.0

        ' إعداد العدادات
        Timer1.Interval = AnimationInterval
        Timer2.Interval = AnimationInterval

        ' إعداد شريط التحميل: يمكن استخدام ProgressBar1 أو إخفاؤه والاعتماد على الحركة فقط
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = TotalDisplayTime
        ProgressBar1.Value = 0

        ' تخصيص مظهر التطبيق
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.None ' إزالة الإطار

        ' بدء المؤقت الرئيسي
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        elapsedTime += Timer1.Interval ' تحديث الوقت المنقضي

        If Me.Opacity < 1.0 Then
            Dim OpacityIncrease As Double = 1.0 / (FadeTime / AnimationInterval)
            Me.Opacity += OpacityIncrease
            If Me.Opacity > 1.0 Then Me.Opacity = 1.0
        End If

        If elapsedTime <= TotalDisplayTime Then
            ProgressBar1.Value = elapsedTime
        End If

        If elapsedTime >= TotalDisplayTime Then
            Timer1.Stop()
            Timer2.Start()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ' مرحلة التلاشي للخارج (Fade Out)
        If Me.Opacity > 0.0 Then
            Dim OpacityDecrease As Double = 1.0 / (FadeTime / AnimationInterval)
            Me.Opacity -= OpacityDecrease
            If Me.Opacity < 0.0 Then Me.Opacity = 0.0
        Else
            ' عند الانتهاء، إغلاق الشاشة وفتح شاشة الدخول
            Timer2.Stop()
            Dim mainForm As New Login()
            mainForm.Show()
            Me.Hide()
            ' التأكد من تحرير الموارد
            Me.Dispose()
        End If
    End Sub
End Class