Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmSelectCustomer

    Private ReadOnly _repo As POSRepository
    Private _allCustomers As List(Of CustomerModel) = Nothing

    ' العميل المختار المرتجع لشاشة البيع
    Public Property SelectedCustomer As CustomerModel

    Public Sub New(repo As POSRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub FrmSelectCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)
        datagridviewsetup(dgvCustomers)
        SetupGrid()
        LoadCustomers()

        Dim drag As New FormDragHelper(Me, panelHeader)
        Dim drag2 As New FormDragHelper(Me, Guna2HtmlLabel1)
    End Sub

    ' تم نقل تعريف وتنسيق الأعمدة إلى الديزاينر FrmSelectCustomer.Designer.vb
    Private Sub SetupGrid()
        dgvCustomers.AutoGenerateColumns = False
    End Sub

    Private Sub LoadCustomers()
        If _repo Is Nothing Then Return
        _allCustomers = _repo.GetActiveCustomers("")
        ApplySearchFilter()
    End Sub

    ' البحث اللحظي الشامل لكل الحقول بداخل txtSearch بدون ComboBox أو ListBox
    Private Sub ApplySearchFilter()
        If _allCustomers Is Nothing Then Exit Sub

        Dim keyword As String = txtSearch.Text.Trim()
        If String.IsNullOrWhiteSpace(keyword) Then
            dgvCustomers.DataSource = _allCustomers
            Exit Sub
        End If

        Dim kwLower As String = keyword.ToLower()
        Dim filteredList As New List(Of CustomerModel)()

        For Each c In _allCustomers
            Dim isMatch As Boolean = (c.CustomerName IsNot Nothing AndAlso c.CustomerName.ToLower().Contains(kwLower)) OrElse
                                      (c.CustomerCode IsNot Nothing AndAlso c.CustomerCode.ToLower().Contains(kwLower)) OrElse
                                      (c.Phone1 IsNot Nothing AndAlso c.Phone1.ToLower().Contains(kwLower)) OrElse
                                      (c.Phone2 IsNot Nothing AndAlso c.Phone2.ToLower().Contains(kwLower)) OrElse
                                      (c.Address IsNot Nothing AndAlso c.Address.ToLower().Contains(kwLower)) OrElse
                                      (c.Email IsNot Nothing AndAlso c.Email.ToLower().Contains(kwLower)) OrElse
                                      (c.Notes IsNot Nothing AndAlso c.Notes.ToLower().Contains(kwLower)) OrElse
                                      (c.AreaInfo IsNot Nothing AndAlso c.AreaInfo.AreaName IsNot Nothing AndAlso c.AreaInfo.AreaName.ToLower().Contains(kwLower))

            If isMatch Then filteredList.Add(c)
        Next

        dgvCustomers.DataSource = filteredList
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearchFilter()
    End Sub

    ' دعم التنقل والضغط على Enter أو السهم للأسفل في مربع البحث
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectAndClose()
            e.Handled = True
        ElseIf e.KeyCode = Keys.Down Then
            If dgvCustomers.Rows.Count > 0 Then
                dgvCustomers.Focus()
            End If
        End If
    End Sub

    ' اختيار العميل عند الضغط المزدوج أو Enter بالجدول
    Private Sub dgvCustomers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellDoubleClick
        SelectAndClose()
    End Sub

    Private Sub dgvCustomers_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCustomers.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectAndClose()
            e.Handled = True
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        SelectAndClose()
    End Sub

    Private Sub SelectAndClose()
        If dgvCustomers.CurrentRow IsNot Nothing Then
            SelectedCustomer = CType(dgvCustomers.CurrentRow.DataBoundItem, CustomerModel)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            SmartMessageBox.Show("برجاء اختيار عميل أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' زر إضافة عميل جديد إذا لم يكن متواجد
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Using frmAdd As New FrmCustomers(_repo)
            If frmAdd.ShowDialog() = DialogResult.OK Then
                LoadCustomers()
            End If
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class