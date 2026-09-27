Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Public Class frmSelectKitchenComment

    Private ReadOnly _productName As String
    Private ReadOnly _initialNote As String

    Public Property SelectedComment As String = ""

    ' قائمة التعليقات المحددة حالياً من الكروت
    Private ReadOnly _selectedComments As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
    Private ReadOnly _commentCards As New List(Of Guna.UI2.WinForms.Guna2Panel)

    Public Sub New(Optional productName As String = "", Optional initialNote As String = "")
        InitializeComponent()
        _productName = productName
        _initialNote = If(initialNote, "").Trim()
    End Sub

    Private Sub frmSelectKitchenComment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBModule.EnsureKitchenCommentsTable()

        If Not String.IsNullOrWhiteSpace(_productName) Then
            lblProductSub.Text = "الصنف: " & _productName
        Else
            lblProductSub.Text = "تحديد ملاحظات التشغيل والتحضير للمطبخ"
        End If

        txtFinalNote.Text = _initialNote
        ParseInitialNote(_initialNote)

        ApplyCurrentTheme()
        AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged

        LoadCommentCards()

        Dim drag As New FormDragHelper(Me, panelHeader)
        Dim drag1 As New FormDragHelper(Me, lblTitle)
        Dim drag2 As New FormDragHelper(Me, lblProductSub)
    End Sub

    Private Sub frmSelectKitchenComment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
    End Sub

    Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
        ApplyCurrentTheme()
    End Sub

    Private Sub ParseInitialNote(note As String)
        _selectedComments.Clear()
        If String.IsNullOrWhiteSpace(note) Then Return

        ' تقسيم الملاحظات السابقة لو كانت مفصولة بفواصل
        Dim parts = note.Split(New String() {",", "،", " - ", " + "}, StringSplitOptions.RemoveEmptyEntries)
        For Each p In parts
            Dim trimmed = p.Trim()
            If Not String.IsNullOrEmpty(trimmed) Then
                _selectedComments.Add(trimmed)
            End If
        Next
    End Sub

    ' =========================================================
    ' تطبيق الثيم الشامل (دعم كامل للوضعين الفاتح والداكن)
    ' =========================================================
    Private Sub ApplyCurrentTheme()
        Dim isDark As Boolean = ThemeManager.Instance.IsDark
        Dim pal = ThemeManager.Instance.Palette

        Me.BackColor = pal.Background

        panelHeader.FillColor = If(isDark, pal.SurfaceHeader, Color.FromArgb(30, 41, 59))
        lblTitle.ForeColor = Color.White
        lblProductSub.ForeColor = If(isDark, Color.FromArgb(148, 163, 184), Color.FromArgb(203, 213, 225))

        pnlContent.BackColor = pal.Background
        pnlFooter.FillColor = pal.Surface
        pnlFooter.BorderColor = pal.Border

        lblPresetsHeader.ForeColor = pal.TextPrimary
        lblQuickAddHeader.ForeColor = pal.TextPrimary
        lblFinalNoteHeader.ForeColor = pal.TextPrimary

        pnlCardsContainer.FillColor = If(isDark, pal.Surface, Color.White)
        pnlCardsContainer.BorderColor = pal.Border
        flpComments.BackColor = Color.Transparent

        txtNewComment.FillColor = pal.InputBackground
        txtNewComment.ForeColor = pal.TextPrimary
        txtNewComment.BorderColor = pal.Border

        txtFinalNote.FillColor = pal.InputBackground
        txtFinalNote.ForeColor = pal.TextPrimary
        txtFinalNote.BorderColor = pal.Border

        btnCancel.FillColor = If(isDark, Color.FromArgb(42, 47, 59), Color.FromArgb(226, 232, 240))
        btnCancel.ForeColor = pal.TextPrimary

        UpdateAllCardVisualStyles()
    End Sub

    ' =========================================================
    ' تحميل كروت التعليقات من قاعدة البيانات
    ' =========================================================
    Public Sub LoadCommentCards()
        flpComments.Controls.Clear()
        _commentCards.Clear()

        Dim dt As DataTable = Nothing
        Try
            Dim query As String = "SELECT CommentID, CommentCode, CommentText FROM KitchenComments WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND IsActive = 1 ORDER BY CommentID ASC"
            dt = DBModule.ExecuteQuery(query)
        Catch ex As Exception
            Logger.LogError("LoadCommentCards", ex)
        End Try

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Dim lblEmpty As New Label With {
                .Text = "لا توجد تعليقات جاهزة مسجلة، يمكنك إضافة تعليق سريعاً من الحقل بالأسفل.",
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Font = New Font("Segoe UI", 11.0F),
                .ForeColor = Color.Gray
            }
            flpComments.Controls.Add(lblEmpty)
            Return
        End If

        For Each row As DataRow In dt.Rows
            Dim commentText As String = row("CommentText").ToString()
            Dim card = CreateCommentCard(commentText)
            _commentCards.Add(card)
            flpComments.Controls.Add(card)
        Next

        UpdateAllCardVisualStyles()
    End Sub

    ' =========================================================
    ' إنشاء كارت تعليق تفاعلي بتصميم عصري (زي فورم الأحجام والإضافات)
    ' =========================================================
    Private Function CreateCommentCard(commentText As String) As Guna.UI2.WinForms.Guna2Panel
        Dim pal = ThemeManager.Instance.Palette

        Dim pnlCard As New Guna.UI2.WinForms.Guna2Panel With {
            .Width = 195,
            .Height = 48,
            .Margin = New Padding(5),
            .BorderRadius = 8,
            .BorderThickness = 1,
            .BorderColor = pal.Border,
            .FillColor = pal.Surface,
            .Cursor = Cursors.Hand,
            .Tag = commentText,
            .RightToLeft = RightToLeft.Yes
        }

        Dim lblText As New Label With {
            .Text = commentText,
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleCenter,
            .AutoEllipsis = True,
            .BackColor = Color.Transparent,
            .ForeColor = pal.TextPrimary,
            .Cursor = Cursors.Hand
        }

        pnlCard.Controls.Add(lblText)

        Dim clickHandler As EventHandler = Sub(s, e)
            ToggleCommentSelection(commentText)
        End Sub

        AddHandler pnlCard.Click, clickHandler
        AddHandler lblText.Click, clickHandler

        Return pnlCard
    End Function

    ' =========================================================
    ' تبديل حالة تحديد التعليق وتحديث مربع النص النهائي
    ' =========================================================
    Private Sub ToggleCommentSelection(commentText As String)
        If _selectedComments.Contains(commentText) Then
            _selectedComments.Remove(commentText)
        Else
            _selectedComments.Add(commentText)
        End If

        UpdateAllCardVisualStyles()
        RebuildFinalNoteFromSelections()
    End Sub

    Private Sub UpdateAllCardVisualStyles()
        Dim isDark As Boolean = ThemeManager.Instance.IsDark
        Dim pal = ThemeManager.Instance.Palette

        For Each card In _commentCards
            Dim commentText = card.Tag?.ToString()
            Dim isSelected = (commentText IsNot Nothing AndAlso _selectedComments.Contains(commentText))

            Dim lblText = card.Controls.OfType(Of Label)().FirstOrDefault()

            If isSelected Then
                card.BorderThickness = 2
                card.BorderColor = Color.FromArgb(16, 185, 129)
                card.FillColor = If(isDark, Color.FromArgb(12, 54, 40), Color.FromArgb(236, 253, 245))
                If lblText IsNot Nothing Then
                    lblText.ForeColor = If(isDark, Color.FromArgb(167, 243, 208), Color.FromArgb(6, 95, 70))
                End If
            Else
                card.BorderThickness = 1
                card.BorderColor = pal.Border
                card.FillColor = pal.Surface
                If lblText IsNot Nothing Then
                    lblText.ForeColor = pal.TextPrimary
                End If
            End If
        Next
    End Sub

    Private Sub RebuildFinalNoteFromSelections()
        If _selectedComments.Count > 0 Then
            txtFinalNote.Text = String.Join("، ", _selectedComments)
        Else
            txtFinalNote.Clear()
        End If
    End Sub

    ' =========================================================
    ' إضافة تعليق جديد سريعاً وحفظه بالداتا بيز فوراً
    ' =========================================================
    Private Sub btnQuickAdd_Click(sender As Object, e As EventArgs) Handles btnQuickAdd.Click
        Dim newComment = txtNewComment.Text.Trim()
        If String.IsNullOrWhiteSpace(newComment) Then
            MessageBox.Show("يرجى كتابة نص التعليق أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewComment.Focus()
            Return
        End If

        ' التحقق إذا كان مضافاً مسبقاً
        Dim alreadyExists = False
        For Each card In _commentCards
            If String.Equals(card.Tag?.ToString(), newComment, StringComparison.OrdinalIgnoreCase) Then
                alreadyExists = True
                Exit For
            End If
        Next

        If Not alreadyExists Then
            ' حفظ التعليق في قاعدة البيانات
            Try
                Dim maxIdObj = DBModule.ExecuteScalar("SELECT ISNULL(MAX(CommentID), 0) + 1 FROM KitchenComments")
                Dim nextCode = GetNextCode("KitchenComments", "CommentCode").ToString()

                Dim query = "INSERT INTO KitchenComments (CommentCode, CommentText, IsActive, IsDeleted, CreatedAt) VALUES (@Code, @Text, 1, 0, GETDATE())"
                Using conn As New SqlConnection(DBModule.ConnectionString)
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@Code", nextCode)
                        cmd.Parameters.AddWithValue("@Text", newComment)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                ' إضافة الكارت للواجهة فوراً
                Dim card = CreateCommentCard(newComment)
                _commentCards.Add(card)
                flpComments.Controls.Add(card)
            Catch ex As Exception
                Logger.LogError("btnQuickAdd_Click", ex)
            End Try
        End If

        ' تفعيله واختياره فوراً
        _selectedComments.Add(newComment)
        UpdateAllCardVisualStyles()
        RebuildFinalNoteFromSelections()

        txtNewComment.Clear()
        txtNewComment.Focus()
    End Sub

    Private Sub txtNewComment_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNewComment.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnQuickAdd.PerformClick()
        End If
    End Sub

    ' =========================================================
    ' أزرار التحكم السفلية
    ' =========================================================
    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        SelectedComment = txtFinalNote.Text.Trim()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        _selectedComments.Clear()
        txtFinalNote.Clear()
        UpdateAllCardVisualStyles()
    End Sub

    Private Sub btnManage_Click(sender As Object, e As EventArgs) Handles btnManage.Click
        Using frm As New frmKitchenComments()
            frm.ShowDialog(Me)
        End Using

        ' تحديث الكروت بعد إغلاق شاشة الإدارة
        LoadCommentCards()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
