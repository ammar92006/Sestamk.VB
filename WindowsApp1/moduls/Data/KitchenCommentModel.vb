Imports System

Public Class KitchenCommentModel
    Public Property CommentID As Integer
    Public Property CommentCode As String
    Public Property CommentText As String
    Public Property IsActive As Boolean = True
    Public Property IsDeleted As Boolean = False
    Public Property CreatedAt As DateTime = DateTime.Now

    Public Overrides Function ToString() As String
        Return CommentText
    End Function
End Class
