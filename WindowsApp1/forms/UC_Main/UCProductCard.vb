Imports System.Drawing
Imports System.IO

Public Class UCProductCard
    Private _Product As ProductModel
    Public Event ProductClicked(product As ProductModel)

    Public Property Product As ProductModel
        Get
            Return _Product
        End Get
        Set(value As ProductModel)
            _Product = value
            If value IsNot Nothing Then LoadProduct()
        End Set
    End Property

    Private Sub UCProductCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.Hand
        AddHandler picProduct.Click, AddressOf Card_Click
        AddHandler lblProductName.Click, AddressOf Card_Click
        AddHandler MyBase.Click, AddressOf Card_Click
    End Sub

    Private Sub LoadProduct()
        lblProductName.Text = If(String.IsNullOrWhiteSpace(_Product.ProductNameAr), _Product.ProductNameEn, _Product.ProductNameAr)
        lblDescription.Text = _Product.Description

        ' إتاحة عرض صورة المنتج من حقل Image
        If Not String.IsNullOrWhiteSpace(_Product.Image) Then
            picProduct.Image = Base64ToImage(_Product.Image)
        Else
            picProduct.Image = Nothing
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
        If _Product IsNot Nothing Then RaiseEvent ProductClicked(_Product)
    End Sub
End Class
