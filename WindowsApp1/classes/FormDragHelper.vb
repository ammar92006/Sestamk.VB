Imports System.Windows.Forms
Imports System.Drawing

Public Class FormDragHelper
    Private ReadOnly _form As Form
    Private ReadOnly _control As Control

    Private _x As Integer
    Private _y As Integer
    Private _isDragging As Boolean

    Public Sub New(frm As Form, dragControl As Control)
        _form = frm
        _control = dragControl

        AddHandler _control.MouseDown, AddressOf Control_MouseDown
        AddHandler _control.MouseMove, AddressOf Control_MouseMove
        AddHandler _control.MouseUp, AddressOf Control_MouseUp
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            _isDragging = True
            _x = Cursor.Position.X - _form.Left
            _y = Cursor.Position.Y - _form.Top
        End If
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        If _isDragging Then
            _form.Location = New Point(
                Cursor.Position.X - _x,
                Cursor.Position.Y - _y)
        End If
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        _isDragging = False
    End Sub


End Class
