Imports System.Drawing
Imports System.IO

Public Class UCCategoryCard
    Private _Category As CategoryModel
    Public Event CategoryClicked(category As CategoryModel)

    Public Property Category As CategoryModel
        Get
            Return _Category
        End Get
        Set(value As CategoryModel)
            _Category = value
            If value IsNot Nothing Then LoadCategory()
        End Set
    End Property

    Private Sub UCCategoryCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.Hand
        AddHandler picCategory.Click, AddressOf Card_Click
        AddHandler lblCategoryName.Click, AddressOf Card_Click
        AddHandler pnlColor.Click, AddressOf Card_Click
        AddHandler MyBase.Click, AddressOf Card_Click
    End Sub

    Private Sub LoadCategory()
        lblCategoryName.Text = If(String.IsNullOrWhiteSpace(_Category.Category_NameAr), _Category.CategoryNameEn, _Category.Category_NameAr)
        pnlColor.BackColor = ColorHelper.GetColor(_Category.CategoryColor)

        If Not String.IsNullOrWhiteSpace(_Category.Imagebase64) Then
            picCategory.Image = Base64ToImage(_Category.Imagebase64)
        Else
            picCategory.Image = Nothing
        End If
    End Sub

    Private Function Base64ToImage(base64 As String) As Image
        Try
            Dim bytes() As Byte = Convert.FromBase64String(base64)
            Using ms As New MemoryStream(bytes)
                Using tempImage As Image = Image.FromStream(ms)
                    Return New Bitmap(tempImage)
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Private Sub Card_Click(sender As Object, e As EventArgs)
        If _Category IsNot Nothing Then RaiseEvent CategoryClicked(_Category)
    End Sub
End Class