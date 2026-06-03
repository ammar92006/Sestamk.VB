Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' نظام إشعارات موحّد (Toast) هادئ بدل MessageBox المتناثرة للرسائل الروتينية.
''' يظهر إشعاراً صغيراً أسفل يمين الشاشة يختفي تلقائياً.
''' للرسائل المهمة/التأكيد ما زال يُستخدم MessageBox عبر Confirm/Error.
''' </summary>
Public Module Notify

    Public Enum ToastType
        Info
        Success
        [Warning]
        [Error]
    End Enum

    ''' <summary>إشعار سريع يختفي تلقائياً (للنجاح/المعلومات الروتينية)</summary>
    Public Sub Toast(message As String, Optional type As ToastType = ToastType.Success, Optional ms As Integer = 2500)
        Try
            Dim t As New ToastForm(message, type, ms)
            t.Show()
        Catch
            ' fallback صامت
        End Try
    End Sub

    ''' <summary>رسالة تأكيد (نعم/لا) موحّدة — ترجع True لو وافق المستخدم</summary>
    Public Function Confirm(message As String, Optional title As String = "تأكيد") As Boolean
        Return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

    ''' <summary>رسالة خطأ موحّدة (للأخطاء التي يجب أن يراها المستخدم)</summary>
    Public Sub [Error](message As String, Optional title As String = "خطأ")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>نافذة الإشعار الصغيرة (تُدار داخلياً)</summary>
    Private Class ToastForm
        Inherits Form

        Private ReadOnly _timer As New Timer()
        Private _life As Integer

        Public Sub New(message As String, type As ToastType, ms As Integer)
            _life = ms
            Me.FormBorderStyle = FormBorderStyle.None
            Me.ShowInTaskbar = False
            Me.StartPosition = FormStartPosition.Manual
            Me.TopMost = True
            Me.Size = New Size(330, 70)
            Me.RightToLeft = RightToLeft.Yes
            Me.Opacity = 0

            Dim back As Color
            Dim icon As String
            Select Case type
                Case ToastType.Success : back = Color.FromArgb(39, 174, 96) : icon = "✅"
                Case ToastType.Warning : back = Color.FromArgb(211, 154, 0) : icon = "⚠️"
                Case ToastType.[Error] : back = Color.FromArgb(192, 57, 43) : icon = "❌"
                Case Else : back = Color.FromArgb(41, 128, 185) : icon = "ℹ️"
            End Select
            Me.BackColor = back

            Dim lbl As New Label() With {
                .Text = icon & "  " & message,
                .ForeColor = Color.White,
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .RightToLeft = RightToLeft.Yes
            }
            Me.Controls.Add(lbl)

            ' الموضع: أسفل يمين المساحة المتاحة
            Dim wa = Screen.PrimaryScreen.WorkingArea
            Me.Location = New Point(wa.Right - Me.Width - 20, wa.Bottom - Me.Height - 20)

            _timer.Interval = 40
            AddHandler _timer.Tick, AddressOf OnTick
            _timer.Start()
        End Sub

        Private _fadingOut As Boolean = False
        Private Sub OnTick(sender As Object, e As EventArgs)
            If Not _fadingOut Then
                If Me.Opacity < 0.95 Then
                    Me.Opacity += 0.12
                Else
                    _life -= _timer.Interval
                    If _life <= 0 Then _fadingOut = True
                End If
            Else
                If Me.Opacity > 0.05 Then
                    Me.Opacity -= 0.12
                Else
                    _timer.Stop()
                    Me.Close()
                End If
            End If
        End Sub

        Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
            Get
                Return True
            End Get
        End Property
    End Class

End Module
