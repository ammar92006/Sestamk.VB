Imports System
Imports System.Windows.Forms

Public Class FrmPendingInvoices

    Private ReadOnly _repo As POSRepository
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
    End Sub

    Private Sub SetupGrid()
        dgvPending.Columns.Clear()
        dgvPending.AutoGenerateColumns = False
        dgvPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPending.MultiSelect = False
        dgvPending.ReadOnly = True

        dgvPending.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNum", .HeaderText = "رقم المعلقة", .DataPropertyName = "PendingNumber", .Width = 120})
        dgvPending.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colDate", .HeaderText = "التاريخ", .DataPropertyName = "PendingDate", .Width = 130})
        dgvPending.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colCust", .HeaderText = "العميل", .DataPropertyName = "CustomerName", .Width = 120})
        dgvPending.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTable", .HeaderText = "الطاولة", .DataPropertyName = "TableName", .Width = 90})
        dgvPending.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTotal", .HeaderText = "الإجمالي", .DataPropertyName = "TotalAmount", .Width = 100})
    End Sub

    Private Sub LoadPendingInvoices()
        Dim list = _repo.GetPendingInvoices()
        dgvPending.DataSource = list
    End Sub

    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        If dgvPending.CurrentRow IsNot Nothing Then
            SelectedPendingInvoice = CType(dgvPending.CurrentRow.DataBoundItem, PendingInvoiceModel)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("برجاء اختيار فاتورة معلقة لاستكمالها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDeletePending_Click(sender As Object, e As EventArgs) Handles btnDeletePending.Click
        If dgvPending.CurrentRow IsNot Nothing Then
            Dim selectedItem = CType(dgvPending.CurrentRow.DataBoundItem, PendingInvoiceModel)
            If selectedItem IsNot Nothing Then
                Dim msg = $"هل أنت متأكد من رغبتك في إلغاء وحذف الفاتورة المعلقة رقم ({selectedItem.PendingNumber})؟"
                If MessageBox.Show(msg, "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If _repo.DeletePendingInvoice(selectedItem.PendingID) Then
                        ' إذا كانت مرتبطة بطاولة صالة، يتم تحرير الطاولة تلقائياً لتصبح متاحة (1)
                        If selectedItem.TableID.HasValue Then
                            _repo.UpdateTableStatus(selectedItem.TableID.Value, 1)
                        End If
                        MessageBox.Show("تم إلغاء وحذف الفاتورة المعلقة بنجاح وتحرير أي طاولة مرتبطة بها.", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadPendingInvoices()
                    Else
                        MessageBox.Show("حدث خطأ أثناء محاولة حذف الفاتورة المعلقة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            MessageBox.Show("برجاء اختيار فاتورة معلقة لحذفها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MessageBox.Show("برجاء اختيار فاتورة معلقة لاستكمالها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class