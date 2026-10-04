Imports System.Data.SqlClient

Public Class frmProductAddons

    Private _cachedProductAddons As DataTable = Nothing

    ' 1. ملء القوائم المنسدلة
    Private Sub FillDropdowns()
        Try
            Dim dtProducts As DataTable = DBModule.ExecuteQuery("SELECT Product_ID, ProductNameAr FROM Products WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND (IsActive = 1 OR IsActive IS NULL) ORDER BY ProductNameAr")
            If dtProducts IsNot Nothing Then
                cmbProduct.DataSource = dtProducts
                cmbProduct.DisplayMember = "ProductNameAr"
                cmbProduct.ValueMember = "Product_ID"
                cmbProduct.SelectedIndex = -1
            End If

            Dim dtAddons As DataTable = DBModule.ExecuteQuery("SELECT AddonID, AddonNameAr FROM Addons WHERE (IsDeleted = 0 OR IsDeleted IS NULL) AND (IsActive = 1 OR IsActive IS NULL) ORDER BY AddonNameAr")
            If dtAddons IsNot Nothing Then
                cmbAddon.DataSource = dtAddons
                cmbAddon.DisplayMember = "AddonNameAr"
                cmbAddon.ValueMember = "AddonID"
                cmbAddon.SelectedIndex = -1
            End If
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في تحميل القوائم: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. تحميل وجلب إضافات الأصناف للجريد (تحميل كل الإضافات افتراضياً)
    Private Sub LoadProductAddonsGrid(Optional productID As Integer? = Nothing)
        Dim query As String = "SELECT PA.ProductAddonID, PA.ProductID, P.ProductNameAr, PA.AddonID, A.AddonNameAr, " &
                              "PA.CostPrice, PA.SalePrice, PA.IsActive " &
                              "FROM ProductAddons PA " &
                              "INNER JOIN Products P ON PA.ProductID = P.Product_ID " &
                              "INNER JOIN Addons A ON PA.AddonID = A.AddonID " &
                              "WHERE (PA.IsDeleted = 0 OR PA.IsDeleted IS NULL) "

        If productID.HasValue AndAlso productID.Value > 0 Then
            query &= $" AND PA.ProductID = {productID.Value} "
        End If

        query &= " ORDER BY P.ProductNameAr ASC, A.AddonNameAr ASC"

        Dim dt As DataTable = DBModule.ExecuteQuery(query)
        _cachedProductAddons = dt
        dgvProductAddons.DataSource = dt

        If dgvProductAddons.Columns.Contains("ProductAddonID") Then dgvProductAddons.Columns("ProductAddonID").Visible = False
        If dgvProductAddons.Columns.Contains("ProductID") Then dgvProductAddons.Columns("ProductID").Visible = False
        If dgvProductAddons.Columns.Contains("AddonID") Then dgvProductAddons.Columns("AddonID").Visible = False

        If dgvProductAddons.Columns.Contains("ProductNameAr") Then dgvProductAddons.Columns("ProductNameAr").HeaderText = "اسم الصنف"
        If dgvProductAddons.Columns.Contains("AddonNameAr") Then dgvProductAddons.Columns("AddonNameAr").HeaderText = "الإضافة"
        If dgvProductAddons.Columns.Contains("CostPrice") Then dgvProductAddons.Columns("CostPrice").HeaderText = "التكلفة"
        If dgvProductAddons.Columns.Contains("SalePrice") Then dgvProductAddons.Columns("SalePrice").HeaderText = "سعر البيع"
        If dgvProductAddons.Columns.Contains("IsActive") Then dgvProductAddons.Columns("IsActive").HeaderText = "نشط"
    End Sub

    Private Sub frmProductAddons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDropdowns()
        LoadProductAddonsGrid() ' العرض العام لكل الإضافات افتراضياً
        datagridviewsetup(dgvProductAddons)
        Dim Drag As FormDragHelper = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub cmbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProduct.SelectedIndexChanged

    End Sub

    Private Sub dgvProductAddons_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductAddons.SelectionChanged
        If dgvProductAddons.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvProductAddons.SelectedRows(0)

        If row.Cells("ProductAddonID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ProductAddonID").Value) Then
            If Not IsDBNull(row.Cells("ProductID").Value) Then cmbProduct.SelectedValue = row.Cells("ProductID").Value
            If Not IsDBNull(row.Cells("AddonID").Value) Then cmbAddon.SelectedValue = row.Cells("AddonID").Value

            txtCostPrice.Text = If(IsDBNull(row.Cells("CostPrice").Value), "0.00", row.Cells("CostPrice").Value.ToString())
            txtSalePrice.Text = If(IsDBNull(row.Cells("SalePrice").Value), "0.00", row.Cells("SalePrice").Value.ToString())
            tgStatus.Checked = If(IsDBNull(row.Cells("IsActive").Value), False, Convert.ToBoolean(row.Cells("IsActive").Value))
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

    End Sub

    Private Sub btnAddAddonForm_Click(sender As Object, e As EventArgs) Handles btnAddAddonForm.Click

        Dim frm As New frmAddons()
        frm.ShowDialog()
        LoadProductAddonsGrid()
        ClearFields()
        FillDropdowns()
    End Sub
    Private Sub ClearFields()
        txtCostPrice.Clear()
        txtSalePrice.Clear()
        tgStatus.Checked = False
        cmbProduct.SelectedValue = -1
        cmbAddon.SelectedValue = -1
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)

    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)

    End Sub

    Private Sub btnAddProductForm_Click(sender As Object, e As EventArgs) Handles btnAddProductForm.Click
        Dim frm As New Products()
        frm.ShowDialog()
        FillDropdowns() ' إعادة شحن الكومبو بوكس بعد إضافة حجم جديد
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub
End Class