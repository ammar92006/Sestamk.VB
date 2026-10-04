Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' فورم Toast متطور مع جميع الميزات الاحترافية
''' </summary>
Public Class frmToastAdvanced

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Model As ToastModelAdvanced

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TargetLocation As Point

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IsClosing As Boolean

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IsPaused As Boolean

    Private _animationStep As Integer = 0
    Private _totalAnimationSteps As Integer = 25
    Private _isExpanded As Boolean = False
    Private _originalHeight As Integer
    Private _progressValue As Double = 0

    Public Sub New(model As ToastModelAdvanced)
        InitializeComponent()

        Me.Model = model
        Me.Opacity = 0
        Me.DoubleBuffered = True
        _originalHeight = Me.Height

        ' تطبيق الحجم المخصص
        If model.Width > 0 Then Me.Width = model.Width
        If model.Height > 0 Then Me.Height = model.Height

        ApplyToastStyle(model)
        SetupButtons()
        SetupProgressBar()

        ' إتاحة إيقاف العد التنازلي عند الـ hover
        HookMouseEvents(Me)
    End Sub

    ''' <summary>
    ''' تطبيق التصميم والألوان
    ''' </summary>
    Private Sub ApplyToastStyle(model As ToastModelAdvanced)
        ' العنوان والرسالة
        lblTitle.Text = If(String.IsNullOrWhiteSpace(model.Title), GetDefaultTitle(model.Type), model.Title)
        lblMessage.Text = model.Message

        ' الأيقونة
        If model.ShowIcon Then
            If model.CustomIcon IsNot Nothing Then
                picIcon.Image = model.CustomIcon
                picIcon.Visible = True
                lblIcon.Visible = False
            Else
                lblIcon.Text = GetIcon(model)
                lblIcon.Visible = True
                picIcon.Visible = False
            End If
        Else
            lblIcon.Visible = False
            picIcon.Visible = False
        End If

        ' الألوان
        Dim accentColor = If(model.CustomAccentColor, GetAccentColor(model.Type))
        pnlAccent.BackColor = accentColor
        lblIcon.ForeColor = accentColor

        If model.CustomBackColor.HasValue Then
            guna2Panel1.FillColor = model.CustomBackColor.Value
        End If

        If model.CustomForeColor.HasValue Then
            lblTitle.ForeColor = model.CustomForeColor.Value
            lblMessage.ForeColor = model.CustomForeColor.Value
        End If

        ' إعداد Expandable
        If model.IsExpandable AndAlso Not String.IsNullOrWhiteSpace(model.ExpandedMessage) Then
            btnExpand.Visible = True
        Else
            btnExpand.Visible = False
        End If

        ' Click Action
        If model.ClickAction IsNot Nothing Then
            guna2Panel1.Cursor = Cursors.Hand
            lblTitle.Cursor = Cursors.Hand
            lblMessage.Cursor = Cursors.Hand
            lblIcon.Cursor = Cursors.Hand
        End If
    End Sub

    ''' <summary>
    ''' إعداد الأزرار التفاعلية
    ''' </summary>
    Private Sub SetupButtons()
        If Model.Buttons Is Nothing OrElse Model.Buttons.Count = 0 Then
            pnlButtons.Visible = False
            Return
        End If

        pnlButtons.Visible = True
        pnlButtons.Controls.Clear()

        Dim x As Integer = pnlButtons.Width - 10
        For Each btnModel In Model.Buttons
            Dim btn As New Guna.UI2.WinForms.Guna2Button With {
                .Text = btnModel.Text,
                .FillColor = btnModel.BackColor,
                .ForeColor = btnModel.ForeColor,
                .BorderRadius = 8,
                .Height = 32,
                .Width = 80,
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .Cursor = Cursors.Hand,
                .Tag = btnModel
            }

            x -= btn.Width + 5
            btn.Location = New Point(x, 5)
            pnlButtons.Controls.Add(btn)

            AddHandler btn.Click, Sub(s, e)
                                      Try
                                          btnModel.Action?.Invoke()
                                          If btnModel.CloseToastOnClick Then
                                              StartClose()
                                          End If
                                      Catch ex As Exception
                                          Logger.LogError("ToastButton.Click", ex)
                                      End Try
                                  End Sub
        Next

        ' تعديل الارتفاع لاحتواء الأزرار
        Me.Height += pnlButtons.Height
    End Sub

    ''' <summary>
    ''' إعداد Progress Bar
    ''' </summary>
    Private Sub SetupProgressBar()
        If Model.ShowProgressBar Then
            progressBar.Visible = True
            progressBar.FillColor = Model.ProgressBarColor
        Else
            progressBar.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' تحديث الأنيميشن في كل tick
    ''' </summary>
    Public Sub UpdateAnimation()
        If IsClosing Then
            HandleClosingAnimation()
        Else
            HandleOpeningAnimation()
            UpdateProgressBar()
        End If
    End Sub

    ''' <summary>
    ''' أنيميشن الظهور
    ''' </summary>
    Private Sub HandleOpeningAnimation()
        If _animationStep >= _totalAnimationSteps Then Return

        _animationStep += 1

        Select Case Model.Animation
            Case ToastAnimation.Fade
                Me.Opacity = ToastAnimationHelper.CalculateOpacity(_animationStep, _totalAnimationSteps, True)

            Case ToastAnimation.Slide
                Dim newY = ToastAnimationHelper.CalculatePosition(
                    Me.Location.Y, TargetLocation.Y,
                    _animationStep, _totalAnimationSteps,
                    ToastAnimation.Slide
                )
                Me.Location = New Point(Me.Location.X, newY)
                Me.Opacity = Math.Min(Me.Opacity + 0.08, 1.0)

            Case ToastAnimation.Scale
                Dim scale = ToastAnimationHelper.CalculateScale(_animationStep, _totalAnimationSteps, True)
                ' Scale simulation (محدود في WinForms)
                Me.Opacity = ToastAnimationHelper.CalculateOpacity(_animationStep, _totalAnimationSteps, True)

            Case ToastAnimation.Bounce, ToastAnimation.SlideWithBounce
                Dim newY = ToastAnimationHelper.CalculatePosition(
                    Me.Location.Y, TargetLocation.Y,
                    _animationStep, _totalAnimationSteps,
                    Model.Animation
                )
                Me.Location = New Point(Me.Location.X, newY)
                Me.Opacity = Math.Min(Me.Opacity + 0.08, 1.0)
        End Select

        ' التحقق من انتهاء الوقت للإغلاق التلقائي
        If _animationStep >= _totalAnimationSteps AndAlso Model.AutoClose AndAlso Not Model.IsSticky AndAlso Not IsPaused Then
            Dim elapsed = (DateTime.Now - Model.CreatedAt).TotalMilliseconds
            If elapsed >= Model.Duration Then
                StartClose()
            End If
        End If
    End Sub

    ''' <summary>
    ''' أنيميشن الإغلاق
    ''' </summary>
    Private Sub HandleClosingAnimation()
        Me.Opacity -= 0.08

        ' انزلاق للخارج أثناء الإغلاق
        If Model.Animation = ToastAnimation.Slide OrElse Model.Animation = ToastAnimation.SlideWithBounce Then
            Select Case Model.Position
                Case ToastPosition.BottomRight, ToastPosition.TopRight
                    Me.Left += 15

                Case ToastPosition.BottomLeft, ToastPosition.TopLeft
                    Me.Left -= 15

                Case ToastPosition.BottomCenter, ToastPosition.TopCenter
                    Me.Top += If(Model.Position = ToastPosition.BottomCenter, 15, -15)
            End Select
        End If
    End Sub

    ''' <summary>
    ''' تحديث Progress Bar
    ''' </summary>
    Private Sub UpdateProgressBar()
        If Not Model.ShowProgressBar OrElse Not progressBar.Visible Then Return

        Dim elapsed = (DateTime.Now - Model.CreatedAt).TotalMilliseconds
        _progressValue = Math.Min(100, (elapsed / Model.Duration) * 100)
        progressBar.Value = CInt(_progressValue)
    End Sub

    ''' <summary>
    ''' بدء الإغلاق
    ''' </summary>
    Public Sub StartClose()
        IsClosing = True
        Model.CloseAction?.Invoke()
    End Sub

    ''' <summary>
    ''' تحديث عدد المجموعة
    ''' </summary>
    Public Sub UpdateGroupCount(count As Integer)
        If count > 1 Then
            lblTitle.Text = $"{Model.Title} ({count})"
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        StartClose()
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click
        ToggleExpand()
    End Sub

    ''' <summary>
    ''' توسيع/طي الإشعار
    ''' </summary>
    Private Sub ToggleExpand()
        _isExpanded = Not _isExpanded

        If _isExpanded Then
            lblMessage.Text = Model.ExpandedMessage
            Me.Height = Model.ExpandedHeight
            btnExpand.Text = "▲"
        Else
            lblMessage.Text = Model.Message
            Me.Height = _originalHeight
            btnExpand.Text = "▼"
        End If

        ' تحديث الموضع النهائي
        TargetLocation = New Point(TargetLocation.X, TargetLocation.Y)
    End Sub

    Private Sub Card_Click(sender As Object, e As EventArgs) Handles guna2Panel1.Click, lblMessage.Click, lblTitle.Click, lblIcon.Click
        Try
            If Model IsNot Nothing AndAlso Model.ClickAction IsNot Nothing Then
                Model.ClickAction.Invoke()
                StartClose()
            End If
        Catch ex As Exception
            Logger.LogError("frmToastAdvanced.Card_Click", ex)
        End Try
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
        Dim cursorScreen = Cursor.Position
        If Not Me.Bounds.Contains(cursorScreen) Then
            IsPaused = False
        End If
    End Sub

    Private Function GetDefaultTitle(type As ToastType) As String
        Select Case type
            Case ToastType.Success : Return "تمت العملية بنجاح"
            Case ToastType.Warning : Return "تنبيه"
            Case ToastType.Error : Return "خطأ"
            Case ToastType.Question : Return "سؤال"
            Case Else : Return "إشعار"
        End Select
    End Function

    Private Function GetIcon(model As ToastModelAdvanced) As String
        If Not String.IsNullOrWhiteSpace(model.Icon) Then
            Return model.Icon
        End If

        Select Case model.Type
            Case ToastType.Success : Return "✓"
            Case ToastType.Error : Return "✕"
            Case ToastType.Warning : Return "⚠"
            Case ToastType.Question : Return "؟"
            Case Else : Return "ℹ"
        End Select
    End Function

    Private Function GetAccentColor(type As ToastType) As Color
        Select Case type
            Case ToastType.Success
                Return Color.FromArgb(34, 197, 94)
            Case ToastType.Error
                Return Color.FromArgb(239, 68, 68)
            Case ToastType.Warning
                Return Color.FromArgb(245, 158, 11)
            Case ToastType.Question
                Return Color.FromArgb(168, 85, 247)
            Case Else
                Return Color.FromArgb(59, 130, 246)
        End Select
    End Function

    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H80
            cp.ExStyle = cp.ExStyle Or &H8000000
            Return cp
        End Get
    End Property

End Class
