Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmSelectDriver

    Private ReadOnly _repo As POSRepository




    ' النتيجة التي تعود لشاشة المبيعات
    Public Property SelectedDriver As DeliveryDriverModel

    Public Sub New(repo As POSRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub FrmSelectDriver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)
        LoadDrivers()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub LoadDrivers()
        flpDrivers.Controls.Clear()
        Dim drivers = _repo.GetActiveDeliveryDrivers()

        For Each drv In drivers
            ' نص الزر: اسم الطيار + التليفون + رسم التوصيل + المنطقة
            Dim areaText As String = If(drv.AreaInfo IsNot Nothing, " (" & drv.AreaInfo.AreaName & ")", "")
            Dim btnText As String = drv.DriverName & areaText & vbCrLf &
                                    "📱 " & drv.Phone & vbCrLf &
                                    "🛵 خدمة توصيل: " & drv.DeliveryFeeValue.ToString("N2") & " EGP"

            Dim btn As New Guna.UI2.WinForms.Guna2Button With {
                .Text = btnText,
                .Tag = drv,
                .Width = 180,
                .Height = 90,
                .BorderRadius = 10,
                .FillColor = Color.FromArgb(41, 128, 185),
                .ForeColor = Color.White,
                .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            }

            AddHandler btn.Click, AddressOf DriverButton_Click
            flpDrivers.Controls.Add(btn)
        Next
    End Sub

    Private Sub DriverButton_Click(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Guna.UI2.WinForms.Guna2Button)
        SelectedDriver = CType(btn.Tag, DeliveryDriverModel)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class