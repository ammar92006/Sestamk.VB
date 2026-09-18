Imports System.Drawing

Public NotInheritable Class ColorHelper
    Private Sub New()
    End Sub

    Public Shared Function GetColor(colorModel As ColorModel) As Color
        If colorModel Is Nothing Then
            Return Color.FromArgb(45, 45, 48) ' لون افتراضي داكن
        End If

        ' 1. تجربة HexCode
        If Not String.IsNullOrWhiteSpace(colorModel.HexCode) Then
            Dim hex As String = colorModel.HexCode.Trim()
            If Not hex.StartsWith("#") Then hex = "#" & hex
            Try
                Return ColorTranslator.FromHtml(hex)
            Catch
            End Try
        End If

        ' 2. تجربة RGB
        If Not String.IsNullOrWhiteSpace(colorModel.RGB) Then
            Try
                Dim parts() As String = colorModel.RGB.Split(","c)
                If parts.Length = 3 Then
                    Dim r As Integer = Integer.Parse(parts(0).Trim())
                    Dim g As Integer = Integer.Parse(parts(1).Trim())
                    Dim b As Integer = Integer.Parse(parts(2).Trim())
                    Return Color.FromArgb(r, g, b)
                End If
            Catch
            End Try
        End If

        Return Color.FromArgb(45, 45, 48)
    End Function
End Class