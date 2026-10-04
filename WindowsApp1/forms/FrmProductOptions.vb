Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Public Class FrmProductOptions

    Private ReadOnly _product As ProductModel
    Private ReadOnly _repo As POSRepository

    ' الكائن المرجعي الذي سيرجع لشاشة المبيعات
    Public Property ResultOrderItem As OrderItemModel
    Public Property ResultOrderItems As New List(Of OrderItemModel)

    ' الحجم والإضافات المحددة حالياً
    Private _selectedSize As ProductSizeModel
    Private ReadOnly _selectedAddons As New List(Of ProductAddonModel)
    Private _quantity As Integer = 1

    ' كروت التحكم المرئية
    Private ReadOnly _sizeCards As New List(Of Guna.UI2.WinForms.Guna2Panel)
    Private ReadOnly _addonCards As New List(Of Guna.UI2.WinForms.Guna2Panel)

    Private ReadOnly Property CurrencySymbol As String
        Get
            Return SettingsManager.GetSettingOrDefault(SettingsKeys.Currency, "ج.م")
        End Get
    End Property

    Public Sub New(product As ProductModel, repo As POSRepository)
        InitializeComponent()
        _product = product
        _repo = repo
    End Sub

    Private Sub FrmProductOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged

        lblProductTitle.Text = If(String.IsNullOrWhiteSpace(_product.ProductNameAr), _product.ProductNameEn, _product.ProductNameAr)

        ApplyCurrentTheme()
        LoadSizes()
        LoadAddons()
        CalculateTotal()

        Dim Drag As New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub FrmProductOptions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
    End Sub

    Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
        ApplyCurrentTheme()
    End Sub

    ' =========================================================
    ' تطبيق الثيم الشامل (دعم كامل للوضعين الفاتح والداكن)
    ' =========================================================
    Private Sub ApplyCurrentTheme()
        Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
        Dim pal = ThemeManager.Instance.CurrentPalette

        Me.BackColor = pal.Background

        ' رأس النافذة
        panelHeader.FillColor = If(isDark, pal.SurfaceHeader, Color.FromArgb(30, 41, 59))
        panelHeader.BackColor = Color.Transparent
        lblProductTitle.ForeColor = Color.White

        ' عناوين الأقسام
        Label3.BackColor = If(isDark, Color.FromArgb(26, 32, 44), Color.FromArgb(241, 245, 249))
        Label3.ForeColor = pal.TextPrimary
        Label1.BackColor = If(isDark, Color.FromArgb(26, 32, 44), Color.FromArgb(241, 245, 249))
        Label1.ForeColor = pal.TextPrimary

        ' لوحات المحتوى وحاويات التمرير
        Guna2Panel1.FillColor = pal.Background
        Guna2Panel1.BackColor = Color.Transparent
        flpSizes.BackColor = pal.Background

        Guna2Panel2.FillColor = pal.Background
        Guna2Panel2.BackColor = Color.Transparent
        flpAddons.BackColor = pal.Background

        ' الشريط السفلي
        Guna2Panel3.FillColor = pal.Surface
        Guna2Panel3.BackColor = Color.Transparent
        Guna2Panel3.BorderColor = pal.Border

        Label2.ForeColor = pal.TextSecondary
        Label5.ForeColor = pal.TextSecondary
        lblQuantity.ForeColor = pal.TextPrimary
        lblQuantity.BackColor = pal.InputBackground

        btnMinus.FillColor = pal.InputBackground
        btnMinus.ForeColor = pal.TextPrimary
        btnMinus.BorderColor = pal.Border

        btnPlus.FillColor = pal.InputBackground
        btnPlus.ForeColor = pal.TextPrimary
        btnPlus.BorderColor = pal.Border

        lblTotalPrice.ForeColor = If(isDark, Color.FromArgb(52, 211, 153), Color.FromArgb(16, 185, 129))

        ' تحديث كروت الأحجام والإضافات القائمة
        UpdateSizeCardStyles()
        UpdateAddonCardStyles()
    End Sub

    ' =========================================================
    ' 1. تحميل الأحجام (اختيار أحادي حصري بتصميم كروت عصري وأنيق)
    ' =========================================================
    Private Sub LoadSizes()
        flpSizes.Controls.Clear()
        _sizeCards.Clear()

        Dim sizes = _repo.GetProductSizes(_product.Product_ID)

        If sizes Is Nothing OrElse sizes.Count = 0 Then
            Label3.Visible = False
            Guna2Panel1.Visible = False
            _selectedSize = Nothing
            Return
        End If

        Label3.Visible = True
        Guna2Panel1.Visible = True

        ' ضبط ارتفاع لوحة الأحجام ديناميكياً لتفادي الفراغات الميتة
        If sizes.Count <= 3 Then
            Guna2Panel1.Height = 76
        ElseIf sizes.Count <= 6 Then
            Guna2Panel1.Height = 146
        Else
            Guna2Panel1.Height = 150
        End If

        ' اختيار الحجم الافتراضي إذا وجد أو أول حجم
        _selectedSize = sizes.FirstOrDefault(Function(s) s.IsDefault)
        If _selectedSize Is Nothing AndAlso sizes.Count > 0 Then
            _selectedSize = sizes(0)
        End If

        For Each ps In sizes
            Dim card = CreateSizeCard(ps)
            _sizeCards.Add(card)
            flpSizes.Controls.Add(card)
        Next

        UpdateSizeCardStyles()
    End Sub

    Private Function CreateSizeCard(ps As ProductSizeModel) As Guna.UI2.WinForms.Guna2Panel
        Dim pal = ThemeManager.Instance.CurrentPalette

        Dim pnlCard As New Guna.UI2.WinForms.Guna2Panel With {
            .Width = 206,
            .Height = 62,
            .Margin = New Padding(5),
            .BorderRadius = 10,
            .BorderThickness = 1,
            .BorderColor = pal.Border,
            .FillColor = pal.Surface,
            .Cursor = Cursors.Hand,
            .Tag = ps,
            .RightToLeft = RightToLeft.No
        }

        ' أيقونة الاختيار الدائرية (Radio Style للاختيار الأحادي)
        Dim chk As New Guna.UI2.WinForms.Guna2CustomRadioButton With {
            .Dock = DockStyle.Right,
            .Width = 34,
            .Cursor = Cursors.Hand,
            .Tag = ps
        }
        chk.CheckedState.FillColor = Color.FromArgb(16, 185, 129)
        chk.CheckedState.BorderColor = Color.FromArgb(16, 185, 129)
        chk.CheckedState.InnerColor = Color.White
        chk.UncheckedState.FillColor = Color.Transparent
        chk.UncheckedState.BorderColor = pal.Border
        chk.UncheckedState.InnerColor = Color.Transparent

        ' حاوية النصوص
        Dim pnlText As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.Transparent,
            .Padding = New Padding(6, 4, 4, 4),
            .Cursor = Cursors.Hand,
            .RightToLeft = RightToLeft.No
        }

        Dim lblName As New Label With {
            .Text = If(ps.SizeInfo IsNot Nothing AndAlso Not String.IsNullOrEmpty(ps.SizeInfo.SizeNameAr), ps.SizeInfo.SizeNameAr, "عادي"),
            .Dock = DockStyle.Top,
            .Height = 26,
            .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleRight,
            .AutoEllipsis = True,
            .BackColor = Color.Transparent,
            .ForeColor = pal.TextPrimary,
            .Cursor = Cursors.Hand,
            .RightToLeft = RightToLeft.No
        }

        Dim lblPrice As New Label With {
            .Text = ps.SalePrice.ToString("N2") & " " & CurrencySymbol,
            .Dock = DockStyle.Bottom,
            .Height = 22,
            .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleRight,
            .ForeColor = Color.FromArgb(16, 185, 129),
            .BackColor = Color.Transparent,
            .Cursor = Cursors.Hand,
            .RightToLeft = RightToLeft.No
        }

        pnlText.Controls.Add(lblPrice)
        pnlText.Controls.Add(lblName)

        pnlCard.Controls.Add(pnlText)
        pnlCard.Controls.Add(chk)

        ' الضغط على أي جزء من الكرت يحدد هذا الحجم
        Dim clickHandler As EventHandler = Sub(s, e)
            _selectedSize = ps
            UpdateSizeCardStyles()
            CalculateTotal()
        End Sub

        AddHandler pnlCard.Click, clickHandler
        AddHandler chk.Click, clickHandler
        AddHandler pnlText.Click, clickHandler
        AddHandler lblName.Click, clickHandler
        AddHandler lblPrice.Click, clickHandler

        Return pnlCard
    End Function

    Private Sub UpdateSizeCardStyles()
        Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
        Dim pal = ThemeManager.Instance.CurrentPalette

        For Each card In _sizeCards
            Dim ps = CType(card.Tag, ProductSizeModel)
            Dim isSelected = (_selectedSize IsNot Nothing AndAlso _selectedSize.ProductSizeID = ps.ProductSizeID)

            Dim chk = card.Controls.OfType(Of Guna.UI2.WinForms.Guna2CustomRadioButton)().FirstOrDefault()
            If chk IsNot Nothing Then chk.Checked = isSelected

            Dim pnlText = card.Controls.OfType(Of Panel)().FirstOrDefault()
            Dim lblName As Label = Nothing
            If pnlText IsNot Nothing Then
                lblName = pnlText.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Dock = DockStyle.Top)
            End If

            If isSelected Then
                card.BorderThickness = 2
                card.BorderColor = Color.FromArgb(16, 185, 129)
                card.FillColor = If(isDark, Color.FromArgb(12, 54, 40), Color.FromArgb(236, 253, 245))
                If lblName IsNot Nothing Then lblName.ForeColor = If(isDark, Color.FromArgb(167, 243, 208), Color.FromArgb(6, 95, 70))
            Else
                card.BorderThickness = 1
                card.BorderColor = pal.Border
                card.FillColor = pal.Surface
                If lblName IsNot Nothing Then lblName.ForeColor = pal.TextPrimary
            End If
        Next
    End Sub

    ' =========================================================
    ' 2. تحميل الإضافات (اختيار متعدد بكروت أنيقة ومفصولة السعر)
    ' =========================================================
    Private Sub LoadAddons()
        flpAddons.Controls.Clear()
        _addonCards.Clear()
        _selectedAddons.Clear()

        Dim addons = _repo.GetProductAddons(_product.Product_ID)

        If addons Is Nothing OrElse addons.Count = 0 Then
            Label1.Visible = False
            Guna2Panel2.Visible = False
            Return
        End If

        Label1.Visible = True
        Guna2Panel2.Visible = True

        For Each pa In addons
            ' الإضافات المفعلة افتراضياً
            If pa.IsDefault.HasValue AndAlso pa.IsDefault.Value Then
                _selectedAddons.Add(pa)
            End If

            Dim card = CreateAddonCard(pa)
            _addonCards.Add(card)
            flpAddons.Controls.Add(card)
        Next

        UpdateAddonCardStyles()
    End Sub

    Private Function CreateAddonCard(pa As ProductAddonModel) As Guna.UI2.WinForms.Guna2Panel
        Dim pal = ThemeManager.Instance.CurrentPalette

        Dim pnlCard As New Guna.UI2.WinForms.Guna2Panel With {
            .Width = 206,
            .Height = 62,
            .Margin = New Padding(5),
            .BorderRadius = 10,
            .BorderThickness = 1,
            .BorderColor = pal.Border,
            .FillColor = pal.Surface,
            .Cursor = Cursors.Hand,
            .Tag = pa,
            .RightToLeft = RightToLeft.No
        }

        Dim chk As New Guna.UI2.WinForms.Guna2CustomCheckBox With {
            .Dock = DockStyle.Right,
            .Width = 34,
            .Cursor = Cursors.Hand,
            .Tag = pa
        }
        chk.CheckedState.FillColor = Color.FromArgb(59, 130, 246)
        chk.CheckedState.BorderColor = Color.FromArgb(59, 130, 246)
        chk.UncheckedState.FillColor = Color.Transparent
        chk.UncheckedState.BorderColor = pal.Border

        Dim pnlText As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.Transparent,
            .Padding = New Padding(6, 4, 4, 4),
            .Cursor = Cursors.Hand,
            .RightToLeft = RightToLeft.No
        }

        Dim lblName As New Label With {
            .Text = If(pa.AddonInfo IsNot Nothing AndAlso Not String.IsNullOrEmpty(pa.AddonInfo.AddonNameAr), pa.AddonInfo.AddonNameAr, "إضافة"),
            .Dock = DockStyle.Top,
            .Height = 26,
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleRight,
            .AutoEllipsis = True,
            .BackColor = Color.Transparent,
            .ForeColor = pal.TextPrimary,
            .Cursor = Cursors.Hand,
            .RightToLeft = RightToLeft.No
        }

        Dim lblPrice As New Label With {
            .Text = "+ " & pa.SalePrice.ToString("N2") & " " & CurrencySymbol,
            .Dock = DockStyle.Bottom,
            .Height = 22,
            .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleRight,
            .ForeColor = Color.FromArgb(59, 130, 246),
            .BackColor = Color.Transparent,
            .Cursor = Cursors.Hand,
            .RightToLeft = RightToLeft.No
        }

        pnlText.Controls.Add(lblPrice)
        pnlText.Controls.Add(lblName)

        pnlCard.Controls.Add(pnlText)
        pnlCard.Controls.Add(chk)

        Dim toggleHandler As EventHandler = Sub(s, e)
            If _selectedAddons.Any(Function(x) x.ProductAddonID = pa.ProductAddonID) Then
                _selectedAddons.RemoveAll(Function(x) x.ProductAddonID = pa.ProductAddonID)
            Else
                _selectedAddons.Add(pa)
            End If
            UpdateAddonCardStyles()
            CalculateTotal()
        End Sub

        AddHandler pnlCard.Click, toggleHandler
        AddHandler chk.Click, toggleHandler
        AddHandler pnlText.Click, toggleHandler
        AddHandler lblName.Click, toggleHandler
        AddHandler lblPrice.Click, toggleHandler

        Return pnlCard
    End Function

    Private Sub UpdateAddonCardStyles()
        Dim isDark As Boolean = (ThemeManager.Instance.CurrentTheme = AppTheme.Dark)
        Dim pal = ThemeManager.Instance.CurrentPalette

        For Each card In _addonCards
            Dim pa = CType(card.Tag, ProductAddonModel)
            Dim isSelected = _selectedAddons.Any(Function(x) x.ProductAddonID = pa.ProductAddonID)

            Dim chk = card.Controls.OfType(Of Guna.UI2.WinForms.Guna2CustomCheckBox)().FirstOrDefault()
            If chk IsNot Nothing Then chk.Checked = isSelected

            Dim pnlText = card.Controls.OfType(Of Panel)().FirstOrDefault()
            Dim lblName As Label = Nothing
            If pnlText IsNot Nothing Then
                lblName = pnlText.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Dock = DockStyle.Top)
            End If

            If isSelected Then
                card.BorderThickness = 2
                card.BorderColor = Color.FromArgb(59, 130, 246)
                card.FillColor = If(isDark, Color.FromArgb(20, 50, 85), Color.FromArgb(239, 246, 255))
                If lblName IsNot Nothing Then lblName.ForeColor = If(isDark, Color.FromArgb(191, 219, 254), Color.FromArgb(30, 64, 175))
            Else
                card.BorderThickness = 1
                card.BorderColor = pal.Border
                card.FillColor = pal.Surface
                If lblName IsNot Nothing Then lblName.ForeColor = pal.TextPrimary
            End If
        Next
    End Sub

    ' =========================================================
    ' 3. زيادة ونقصان الكمية
    ' =========================================================
    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        If _quantity > 1 Then
            _quantity -= 1
            CalculateTotal()
        End If
    End Sub

    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        If _quantity < 99 Then
            _quantity += 1
            CalculateTotal()
        End If
    End Sub

    ' =========================================================
    ' 4. حساب السعر الإجمالي الصافي بناءً على الخيارات والكمية
    ' =========================================================
    Private Sub CalculateTotal()
        Dim basePrice As Decimal = If(_selectedSize IsNot Nothing, _selectedSize.SalePrice, _product.DefaultPrice)
        Dim addonsTotal As Decimal = 0

        For Each ad In _selectedAddons
            addonsTotal += ad.SalePrice
        Next

        Dim singleItemPrice As Decimal = basePrice + addonsTotal
        Dim grandTotal As Decimal = singleItemPrice * _quantity

        lblTotalPrice.Text = grandTotal.ToString("N2") & " " & CurrencySymbol
        lblQuantity.Text = _quantity.ToString()
    End Sub

    ' =========================================================
    ' 5. زر الإضافة للفاتورة
    ' =========================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ResultOrderItems.Clear()

        Dim item As New OrderItemModel With {
            .Product_ID = _product.Product_ID,
            .ProductName = If(String.IsNullOrWhiteSpace(_product.ProductNameAr), _product.ProductNameEn, _product.ProductNameAr),
            .SelectedSize = _selectedSize,
            .SelectedAddons = New List(Of ProductAddonModel)(_selectedAddons),
            .Quantity = _quantity,
            .Notes = "",
            .TaxPercent = Convert.ToDecimal(If(_product.TaxPercent.HasValue, _product.TaxPercent.Value, 0))
        }

        ResultOrderItems.Add(item)
        ResultOrderItem = item

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class