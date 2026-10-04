Imports System
Imports System.Windows.Forms

Public Class FrmPendingInvoices

    Private ReadOnly _repo As POSRepository
    Private _allPendingList As New List(Of PendingInvoiceModel)
    Public Property SelectedPendingInvoice As PendingInvoiceModel

    Public Sub New(repo As POSRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub FrmPendingInvoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.Instance.ApplyTheme(Me)
        datagridviewsetup(dgvPending)
        SetupGrid()
        LoadPendingInvoices()

        Dim Drag0 As FormDragHelper = New FormDragHelper(Me, panelHeader)
        Me.KeyPreview = True
    End Sub

    Private Sub SetupGrid()
        dgvPending.AutoGenerateColumns = False
    End Sub

    Private Sub LoadPendingInvoices()
        _allPendingList = _repo.GetPendingInvoices()
        FilterInvoices()
    End Sub

    Private Sub FilterInvoices()
        Dim query = If(txtSearch IsNot Nothing, txtSearch.Text.Trim().ToLower(), "")
        If String.IsNullOrWhiteSpace(query) Then
            dgvPending.DataSource = _allPendingList.ToList()
        Else
            Dim filtered = _allPendingList.Where(Function(p)
                Return (p.PendingNumber IsNot Nothing AndAlso p.PendingNumber.ToLower().Contains(query)) OrElse
                       (p.CustomerName IsNot Nothing AndAlso p.CustomerName.ToLower().Contains(query)) OrElse
                       (p.DriverName IsNot Nothing AndAlso p.DriverName.ToLower().Contains(query)) OrElse
                       (p.TableName IsNot Nothing AndAlso p.TableName.ToLower().Contains(query)) OrElse
                       (p.OrderTypeDisplay IsNot Nothing AndAlso p.OrderTypeDisplay.ToLower().Contains(query)) OrElse
                       (p.OrderReferenceDisplay IsNot Nothing AndAlso p.OrderReferenceDisplay.ToLower().Contains(query))
            End Function).ToList()
            dgvPending.DataSource = filtered
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterInvoices()
    End Sub

    Private Sub FrmPendingInvoices_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter AndAlso Not txtSearch.Focused Then
            e.Handled = True
            btnResume.PerformClick()
        End If
    End Sub

    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        If dgvPending.CurrentRow IsNot Nothing Then
            SelectedPendingInvoice = CType(dgvPending.CurrentRow.DataBoundItem, PendingInvoiceModel)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            SmartMessageBox.Show("برجاء اختيار فاتورة معلقة لاستكمالها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDeletePending_Click(sender As Object, e As EventArgs) Handles btnDeletePending.Click
        If dgvPending.CurrentRow IsNot Nothing Then
            Dim selectedItem = CType(dgvPending.CurrentRow.DataBoundItem, PendingInvoiceModel)
            If selectedItem IsNot Nothing Then
                Dim msg = $"هل أنت متأكد من رغبتك في إلغاء وحذف الفاتورة المعلقة رقم ({selectedItem.PendingNumber})؟"
                If SmartMessageBox.Show(msg, "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If _repo.DeletePendingInvoice(selectedItem.PendingID) Then
                        ' إذا كانت مرتبطة بطاولة صالة، يتم تحرير الطاولة تلقائياً لتصبح متاحة (1)
                        If selectedItem.TableID.HasValue Then
                            _repo.UpdateTableStatus(selectedItem.TableID.Value, 1)
                        End If
                        SmartMessageBox.Show("تم إلغاء وحذف الفاتورة المعلقة بنجاح وتحرير أي طاولة مرتبطة بها.", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadPendingInvoices()
                    Else
                        SmartMessageBox.Show("حدث خطأ أثناء محاولة حذف الفاتورة المعلقة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            SmartMessageBox.Show("برجاء اختيار فاتورة معلقة لحذفها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvPending_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvPending.MouseDoubleClick
        If dgvPending.CurrentRow IsNot Nothing Then
            SelectedPendingInvoice = CType(dgvPending.CurrentRow.DataBoundItem, PendingInvoiceModel)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            SmartMessageBox.Show("برجاء اختيار فاتورة معلقة لاستكمالها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class