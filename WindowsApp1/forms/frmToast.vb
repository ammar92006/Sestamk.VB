Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmToast

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Model As ToastModel

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TargetY As Integer

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IsClosing As Boolean

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IsPaused As Boolean

    Public Sub New(model As ToastModel)
        InitializeComponent()

        Me.Model = model
        Me.Opacity = 0
        Me.DoubleBuffered = True

        ApplyToastStyle(model)

        ' إتاحة إيقاف العد التنازلي مؤقتاً عند مرور الماوس فوق الإشعار
        HookMouseEvents(Me)
    End Sub

    ''' <summary>
    ''' تطبيق التصميم والألوان والأيقونة بدقة مثل Sestamk_App
    ''' </summary>
    Private Sub ApplyToastStyle(model As ToastModel)
        lblTitle.Text = If(String.IsNullOrWhiteSpace(model.Title), GetDefaultTitle(model.Type), model.Title)
        lblMessage.Text = model.Message
        lblIcon.Text = GetIcon(model.Type)

        Dim accentColor As Color = GetAccentColor(model.Type)
        pnlAccent.BackColor = accentColor
        lblIcon.ForeColor = accentColor

        If model.ClickAction IsNot Nothing Then
            guna2Panel1.Cursor = Cursors.Hand
            lblTitle.Cursor = Cursors.Hand
            lblMessage.Cursor = Cursors.Hand
            lblIcon.Cursor = Cursors.Hand
        End If
    End Sub

    Private Function GetDefaultTitle(type As Notify.ToastType) As String
        Select Case type
            Case Notify.ToastType.Success : Return "تمت العملية بنجاح"
            Case Notify.ToastType.Warning : Return "تنبيه"
            Case Notify.ToastType.[Error] : Return "خطأ"
            Case Else : Return "إشعار"
        End Select
    End Function

    Private Function GetIcon(type As Notify.ToastType) As String
        Select Case type
            Case Notify.ToastType.Success : Return "✓"
            Case Notify.ToastType.[Error] : Return "✕"
            Case Notify.ToastType.Warning : Return "⚠"
            Case Else : Return "ℹ"
        End Select
    End Function

    Private Function GetAccentColor(type As Notify.ToastType) As Color
        Select Case type
            Case Notify.ToastType.Success
                Return Color.FromArgb(34, 197, 94)    ' أخضر زمردي
            Case Notify.ToastType.[Error]
                Return Color.FromArgb(239, 68, 68)    ' أحمر وردي
            Case Notify.ToastType.Warning
                Return Color.FromArgb(245, 158, 11)   ' برتقالي تحذيري
            Case Else
                Return Color.FromArgb(59, 130, 246)   ' أزرق معلوماتي
        End Select
    End Function

    Public Sub StartClose()
        IsClosing = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        StartClose()
    End Sub

    Private Sub Card_Click(sender As Object, e As EventArgs) Handles guna2Panel1.Click, lblMessage.Click, lblTitle.Click, lblIcon.Click
        Try
            If Model IsNot Nothing AndAlso Model.ClickAction IsNot Nothing Then
                Model.ClickAction.Invoke()
            End If
        Catch ex As Exception
            Debug.WriteLine("Toast ClickAction error: " & ex.Message)
        End Try
        StartClose()
    End Sub

    Private Sub HookMouseEvents(parent As Control)
        AddHandler parent.MouseEnter, AddressOf OnHoverEnter
        AddHandler parent.MouseLeave, AddressOf OnHoverLeave
        For Each child As Control In parent.Controls
            HookMouseEvents(child)
        Next
    End Sub

    Private Sub OnHoverEnter(sender As Object, e As EventArgs)
        IsPaused = True
    End Sub

    Private Sub OnHoverLeave(sender As Object, e As EventArgs)
        ' إذا خرج الماوس خارج حدود النموذج بالكامل نستأنف المؤقت
        Dim cursorScreen = Cursor.Position
        If Not Me.Bounds.Contains(cursorScreen) Then
            IsPaused = False
        End If
    End Sub

    ''' <summary>
    ''' منع سرقة الفوكس من الكاشير أو مربعات النصوص الحالية
    ''' </summary>
    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H80          ' WS_EX_TOOLWINDOW (لا يظهر في Alt-Tab)
            cp.ExStyle = cp.ExStyle Or &H8000000      ' WS_EX_NOACTIVATE (لا يسحب الفوكس أبداً)
            Return cp
        End Get
    End Property

End Class
