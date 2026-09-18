Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Public Class FrmProductOptions

    Private ReadOnly _product As ProductModel
    Private ReadOnly _repo As POSRepository

    ' الكائن المرجعي الذي سيرجع لشاشة المبيعات (عنصر واحد للتوافقية وقائمة كاملة للعناصر)
    Public Property ResultOrderItem As OrderItemModel
    Public Property ResultOrderItems As New List(Of OrderItemModel)

    ' الأحجام والإضافات المحددة حالياً
    Private ReadOnly _selectedSizes As New List(Of ProductSizeModel)
    Private ReadOnly _selectedAddons As New List(Of ProductAddonModel)

    Public Sub New(product As ProductModel, repo As POSRepository)
        InitializeComponent()
        _product = product
        _repo = repo
    End Sub

    Private Sub FrmProductOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)
        Dim pal = ThemeManager.Instance.CurrentPalette
        Label3.BackColor = pal.Surface
        Label3.ForeColor = pal.TextPrimary
        Label1.BackColor = pal.Surface
        Label1.ForeColor = pal.TextPrimary

        Guna2HtmlLabel1.Text = If(String.IsNullOrWhiteSpace(_product.ProductNameAr), _product.ProductNameEn, _product.ProductNameAr)

        LoadSizes()
        LoadAddons()
        CalculateTotal()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' =========================================================
    ' 1. تحميل الأحجام (اختيار متعدد باستخدام كروت و CheckBox احترافي)
    ' =========================================================
    Private Sub LoadSizes()
        flpSizes.Controls.Clear()
        _selectedSizes.Clear()
        Dim sizes = _repo.GetProductSizes(_product.Product_ID)
        Dim pal = ThemeManager.Instance.CurrentPalette

        For Each ps In sizes
            Dim pnlCard As New Guna.UI2.WinForms.Guna2Panel With {
                .Width = 200,
                .Height = 52,
                .Margin = New Padding(8),
                .BorderRadius = 10,
                .BorderThickness = 1,
                .BorderColor = pal.Border,
                .FillColor = pal.Surface,
                .Cursor = Cursors.Hand
            }

            Dim chk As New Guna.UI2.WinForms.Guna2CheckBox With {
                .Text = ps.SizeInfo.SizeNameAr & " (" & ps.SalePrice.ToString("N2") & " ج.م)",
                .Tag = ps,
                .AutoSize = False,
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = pal.TextPrimary,
                .RightToLeft = RightToLeft.Yes,
                .Cursor = Cursors.Hand
            }

            chk.CheckedState.FillColor = Color.FromArgb(46, 204, 113)
            chk.CheckedState.BorderColor = Color.FromArgb(46, 204, 113)
            chk.UncheckedState.FillColor = pal.InputBackground
            chk.UncheckedState.BorderColor = pal.Border

            pnlCard.Controls.Add(chk)

            AddHandler pnlCard.Click, Sub(s, e) chk.Checked = Not chk.Checked
            AddHandler chk.CheckedChanged, AddressOf SizeCheckBox_CheckedChanged

            flpSizes.Controls.Add(pnlCard)

            ' اختيار الحجم الافتراضي إذا كان محدداً في قاعدة البيانات
            If ps.IsDefault Then
                chk.Checked = True
            End If
        Next

        ' إذا لم يوجد حجم افتراضي، يتم اختيار أول حجم تلقائياً
        If _selectedSizes.Count = 0 AndAlso flpSizes.Controls.Count > 0 Then
            Dim firstCard = CType(flpSizes.Controls(0), Guna.UI2.WinForms.Guna2Panel)
            If firstCard.Controls.Count > 0 AndAlso TypeOf firstCard.Controls(0) Is Guna.UI2.WinForms.Guna2CheckBox Then
                Dim firstChk = CType(firstCard.Controls(0), Guna.UI2.WinForms.Guna2CheckBox)
                firstChk.Checked = True
            End If
        End If
    End Sub

    Private Sub SizeCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim chk = CType(sender, Guna.UI2.WinForms.Guna2CheckBox)
        Dim ps = CType(chk.Tag, ProductSizeModel)
        Dim pnl = CType(chk.Parent, Guna.UI2.WinForms.Guna2Panel)
        Dim pal = ThemeManager.Instance.CurrentPalette

        If chk.Checked Then
            If Not _selectedSizes.Contains(ps) Then _selectedSizes.Add(ps)
            pnl.FillColor = If(ThemeManager.Instance.CurrentTheme = AppTheme.Dark, Color.FromArgb(24, 60, 42), Color.FromArgb(235, 248, 240))
            pnl.BorderColor = Color.FromArgb(46, 204, 113)
        Else
            If _selectedSizes.Contains(ps) Then _selectedSizes.Remove(ps)
            pnl.FillColor = pal.Surface
            pnl.BorderColor = pal.Border
        End If

        CalculateTotal()
    End Sub

    ' =========================================================
    ' 2. تحميل الإضافات (اختيار متعدد باستخدام كروت و CheckBox احترافي)
    ' =========================================================
    Private Sub LoadAddons()
        flpAddons.Controls.Clear()
        _selectedAddons.Clear()
        Dim addons = _repo.GetProductAddons(_product.Product_ID)
        Dim pal = ThemeManager.Instance.CurrentPalette

        For Each pa In addons
            Dim pnlCard As New Guna.UI2.WinForms.Guna2Panel With {
                .Width = 200,
                .Height = 52,
                .Margin = New Padding(8),
                .BorderRadius = 10,
                .BorderThickness = 1,
                .BorderColor = pal.Border,
                .FillColor = pal.Surface,
                .Cursor = Cursors.Hand
            }

            Dim chk As New Guna.UI2.WinForms.Guna2CheckBox With {
                .Text = pa.AddonInfo.AddonNameAr & " (+ " & pa.SalePrice.ToString("N2") & " ج.م)",
                .Tag = pa,
                .AutoSize = False,
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular),
                .ForeColor = pal.TextPrimary,
                .RightToLeft = RightToLeft.Yes,
                .Cursor = Cursors.Hand
            }

            chk.CheckedState.FillColor = Color.FromArgb(52, 152, 219)
            chk.CheckedState.BorderColor = Color.FromArgb(52, 152, 219)
            chk.UncheckedState.FillColor = pal.InputBackground
            chk.UncheckedState.BorderColor = pal.Border

            pnlCard.Controls.Add(chk)

            AddHandler pnlCard.Click, Sub(s, e) chk.Checked = Not chk.Checked
            AddHandler chk.CheckedChanged, AddressOf AddonCheckBox_CheckedChanged

            flpAddons.Controls.Add(pnlCard)

            ' تحديد الإضافة إذا كانت مفعلة افتراضياً
            If pa.IsDefault.HasValue AndAlso pa.IsDefault.Value Then
                chk.Checked = True
            End If
        Next
    End Sub

    Private Sub AddonCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim chk = CType(sender, Guna.UI2.WinForms.Guna2CheckBox)
        Dim pa = CType(chk.Tag, ProductAddonModel)
        Dim pnl = CType(chk.Parent, Guna.UI2.WinForms.Guna2Panel)
        Dim pal = ThemeManager.Instance.CurrentPalette

        If chk.Checked Then
            If Not _selectedAddons.Contains(pa) Then _selectedAddons.Add(pa)
            pnl.FillColor = If(ThemeManager.Instance.CurrentTheme = AppTheme.Dark, Color.FromArgb(20, 50, 75), Color.FromArgb(235, 245, 255))
            pnl.BorderColor = Color.FromArgb(52, 152, 219)
        Else
            If _selectedAddons.Contains(pa) Then _selectedAddons.Remove(pa)
            pnl.FillColor = pal.Surface
            pnl.BorderColor = pal.Border
        End If

        CalculateTotal()
    End Sub

    ' =========================================================
    ' 3. حساب السعر وتوضيح تفصيل الحساب (حجم + إضافات)
    ' =========================================================
    Private Sub CalculateTotal()
        Dim addonsPrice As Decimal = 0
        For Each addon In _selectedAddons
            addonsPrice += addon.SalePrice
        Next

        Dim total As Decimal = 0
        Dim itemCount As Integer = 0

        If _selectedSizes.Count > 0 Then
            itemCount = _selectedSizes.Count
            For Each sz In _selectedSizes
                total += sz.SalePrice + addonsPrice
            Next
        Else
            itemCount = 1
            total = addonsPrice
        End If

        lblTotalPrice.Text = total.ToString("N2")
        lblQuantity.Text = itemCount.ToString()
    End Sub

    ' =========================================================
    ' 4. زر الإضافة للفاتورة
    ' =========================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ResultOrderItems.Clear()

        If _selectedSizes.Count > 0 Then
            For Each sz In _selectedSizes
                Dim item As New OrderItemModel With {
                    .Product_ID = _product.Product_ID,
                    .ProductName = If(String.IsNullOrWhiteSpace(_product.ProductNameAr), _product.ProductNameEn, _product.ProductNameAr),
                    .SelectedSize = sz,
                    .SelectedAddons = New List(Of ProductAddonModel)(_selectedAddons),
                    .Quantity = 1,
                    .Notes = ""
                }
                ResultOrderItems.Add(item)
            Next
        Else
            Dim item As New OrderItemModel With {
                .Product_ID = _product.Product_ID,
                .ProductName = If(String.IsNullOrWhiteSpace(_product.ProductNameAr), _product.ProductNameEn, _product.ProductNameAr),
                .SelectedSize = Nothing,
                .SelectedAddons = New List(Of ProductAddonModel)(_selectedAddons),
                .Quantity = 1,
                .Notes = ""
            }
            ResultOrderItems.Add(item)
        End If

        ResultOrderItem = ResultOrderItems.FirstOrDefault()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class