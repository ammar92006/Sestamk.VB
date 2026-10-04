Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmSelectTable

    Private ReadOnly _repo As POSRepository
    Private _selectedSectionID As Integer? = Nothing

    ' البيانات المرتجعة للـ FrmSales / frmPOS
    Public Property SelectedTableID As Integer
    Public Property SelectedTableName As String
    Public Property IsOccupiedSelected As Boolean = False
    Public Property ActiveReservation As TableReservationModel = Nothing
    Public Property HasActiveReservation As Boolean = False

    Public Sub New(repo As POSRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub FrmSelectTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)
        LoadSections()
        LoadTables(Nothing) ' عرض كافة الطاولات أولاً
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    ' ==========================================
    ' 1. رسم أزرار الأقسام (Sections)
    ' ==========================================
    Private Sub LoadSections()
        flpSections.Controls.Clear()

        ' زر عرض الكل
        Dim btnAll As New Guna.UI2.WinForms.Guna2Button With {
            .Text = "الكل",
            .Tag = 0,
            .Width = 110,
            .Height = 40,
            .BorderRadius = 8,
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        }
        ApplySectionButtonStyle(btnAll, _selectedSectionID Is Nothing OrElse _selectedSectionID = 0)
        AddHandler btnAll.Click, AddressOf SectionButton_Click
        flpSections.Controls.Add(btnAll)

        Dim sections = _repo.GetRestaurantSections()
        If sections IsNot Nothing Then
            For Each sec In sections
                Dim isSelected As Boolean = (_selectedSectionID.HasValue AndAlso _selectedSectionID.Value = sec.SectionID)
                Dim btn As New Guna.UI2.WinForms.Guna2Button With {
                    .Text = sec.SectionName,
                    .Tag = sec.SectionID,
                    .Width = 125,
                    .Height = 40,
                    .BorderRadius = 8,
                    .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
                }
                ApplySectionButtonStyle(btn, isSelected)
                AddHandler btn.Click, AddressOf SectionButton_Click
                flpSections.Controls.Add(btn)
            Next
        End If
    End Sub

    Private Sub ApplySectionButtonStyle(btn As Guna.UI2.WinForms.Guna2Button, isSelected As Boolean)
        Dim pal = ThemeManager.Instance.CurrentPalette
        If isSelected Then
            btn.FillColor = pal.Primary
            btn.ForeColor = Color.White
            btn.BorderThickness = 0
        Else
            btn.FillColor = pal.Surface
            btn.ForeColor = pal.TextSecondary
            btn.BorderColor = pal.Border
            btn.BorderThickness = 1
        End If
    End Sub

    Private Sub SectionButton_Click(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Dim sectionID As Integer = Convert.ToInt32(btn.Tag)

        If sectionID = 0 Then
            _selectedSectionID = Nothing
            LoadTables(Nothing)
        Else
            _selectedSectionID = sectionID
            LoadTables(sectionID)
        End If

        ' تحديث تمييز الزر المحدد
        For Each ctrl As Control In flpSections.Controls
            If TypeOf ctrl Is Guna.UI2.WinForms.Guna2Button Then
                Dim sBtn = CType(ctrl, Guna.UI2.WinForms.Guna2Button)
                Dim sID As Integer = Convert.ToInt32(sBtn.Tag)
                Dim active As Boolean = (sID = 0 AndAlso (_selectedSectionID Is Nothing OrElse _selectedSectionID = 0)) OrElse (_selectedSectionID.HasValue AndAlso _selectedSectionID.Value = sID)
                ApplySectionButtonStyle(sBtn, active)
            End If
        Next
    End Sub

    ' ==========================================
    ' 2. رسم أزرار الطاولات (Tables)
    ' ==========================================
    Private Sub LoadTables(sectionID As Integer?)
        flpTables.Controls.Clear()
        Dim tables = _repo.GetRestaurantTables(sectionID)

        Dim freeCount As Integer = 0
        Dim occupiedCount As Integer = 0
        Dim reservedCount As Integer = 0
        Dim totalCount As Integer = 0

        If tables IsNot Nothing Then
            totalCount = tables.Count
            For Each tbl In tables
                Select Case tbl.TableStatus
                    Case 1 : freeCount += 1
                    Case 2 : occupiedCount += 1
                    Case 3 : reservedCount += 1
                End Select
            Next
        End If

        lblLegend.Text = $"إجمالي الطاولات: {totalCount}   |   🟢 متاحة: {freeCount}   |   🔴 مشغولة: {occupiedCount}   |   🟡 محجوزة: {reservedCount}"

        If tables Is Nothing OrElse tables.Count = 0 Then
            Dim lblEmpty As New Label With {
                .Text = "لا توجد طاولات في هذا القسم",
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .AutoSize = True,
                .Margin = New Padding(20)
            }
            flpTables.Controls.Add(lblEmpty)
            Return
        End If

        For Each tbl In tables
            ' تحديد اسم الطاولة المعروض
            Dim displayName As String = If(Not String.IsNullOrWhiteSpace(tbl.TableName), tbl.TableName, tbl.TableNumber)

            ' تحديد لون ونص الحالة بناءً على حالة الطاولة
            Dim statusText As String = ""
            Dim btnColor As Color
            Select Case tbl.TableStatus
                Case 1 ' متاحة (Free)
                    statusText = "متاحة"
                    btnColor = Color.FromArgb(16, 185, 129) ' Emerald Green (#10B981)
                Case 2 ' مشغولة (Occupied)
                    statusText = "مشغولة"
                    btnColor = Color.FromArgb(239, 68, 68) ' Rose Red (#EF4444)
                Case 3 ' محجوزة (Reserved)
                    statusText = "محجوزة"
                    btnColor = Color.FromArgb(245, 158, 11) ' Amber Yellow (#F59E0B)
                Case Else
                    statusText = "غير متاحة"
                    btnColor = Color.FromArgb(100, 116, 139) ' Slate Gray (#64748B)
            End Select

            Dim btnText As String = displayName & vbCrLf & "🪑 " & tbl.ChairsCount & " مقاعد" & vbCrLf & "● " & statusText

            Dim btn As New Guna.UI2.WinForms.Guna2Button With {
                .Text = btnText,
                .Tag = tbl,
                .Width = 150,
                .Height = 100,
                .BorderRadius = 12,
                .FillColor = btnColor,
                .ForeColor = Color.White,
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .Margin = New Padding(8),
                .Animated = True
            }

            AddHandler btn.Click, AddressOf TableButton_Click
            flpTables.Controls.Add(btn)
        Next
    End Sub

    Private Sub TableButton_Click(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Dim tbl = CType(btn.Tag, RestaurantTableModel)
        Dim displayName As String = If(Not String.IsNullOrWhiteSpace(tbl.TableName), tbl.TableName, tbl.TableNumber)

        ' التأكد من حالة الطاولة عند الاختيار
        If tbl.TableStatus = 2 Then
            Dim res As DialogResult = SmartMessageBox.Show(
                $"الطاولة ({displayName}) مشغولة حالياً وبها طلب مفتوح!" & vbCrLf &
                "هل تريد فتح الطلب الحالي لإضافة أصناف أخرى أو إتمام الحساب؟",
                "طاولة مشغولة", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.No Then Return
            IsOccupiedSelected = True
        ElseIf tbl.TableStatus = 3 Then
            ' طاولة محجوزة
            Dim resv = _repo.GetActiveReservationForTable(tbl.TableID)
            If resv IsNot Nothing Then
                Dim depStr = If(resv.DepositAmount > 0, $"{resv.DepositAmount:N2} ج.م", "بدون عربون")
                Dim msg = $"الطاولة ({displayName}) محجوزة للعميل:" & vbCrLf &
                          $"👤 العميل: {resv.CustomerName}" & vbCrLf &
                          $"📞 الهاتف: {resv.CustomerPhone}" & vbCrLf &
                          $"👥 عدد الأفراد: {resv.GuestCount}" & vbCrLf &
                          $"🕒 الموعد: {resv.ReservationDateTime:yyyy/MM/dd HH:mm}" & vbCrLf &
                          $"💰 العربون المدفوع: {depStr}" & vbCrLf & vbCrLf &
                          "هل تريد تسكين العميل الآن وبدء طلبه (مع خصم العربون تلقائياً من الفاتورة)؟"

                Dim dlgRes = SmartMessageBox.Show(msg, "تسكين حجز الطاولة", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dlgRes = DialogResult.No Then Return

                ' تحديث حالة الحجز إلى Seated وحالة الطاولة إلى مشغولة
                _repo.CheckInReservation(resv.ReservationID, tbl.TableID)
                ActiveReservation = resv
                HasActiveReservation = True
            End If
            IsOccupiedSelected = False
        Else
            IsOccupiedSelected = False
        End If

        SelectedTableID = tbl.TableID
        SelectedTableName = displayName

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
