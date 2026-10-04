Imports System.Data.SqlClient

Public Class frmMaterialUnits
    Private _materialID As Integer
    Private _materialName As String
    Private _baseUnitName As String

    Public Sub New(materialID As Integer, materialName As String, baseUnitName As String)
        InitializeComponent()
        _materialID = materialID
        _materialName = materialName
        _baseUnitName = baseUnitName
    End Sub

    Private Sub frmMaterialUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.CheckCanOpen(Me) Then Return
        Session.ApplyFormPermissions(Me)

        lblMaterialName.Text = $"{_materialName} (الوحدة الأساسية: {_baseUnitName})"
        lblBaseUnitHint.Text = _baseUnitName
        FillUnitsDropdown()
        LoadUnitsGrid()

        datagridviewsetup(dgvMaterialUnits)
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub FillUnitsDropdown()
        Try
            ' استبعاد الوحدة الأساسية للخامة حتى لا تظهر في القائمة
            Dim query As String = "SELECT UnitID, UnitName FROM Units " &
                              "WHERE UnitID <> (SELECT UnitID FROM RawMaterials WHERE MaterialID = @MatID) " &
                              "ORDER BY UnitName ASC"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@MatID", _materialID)
                    Dim dt As New DataTable()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    cmbUnit.DataSource = dt
                    cmbUnit.DisplayMember = "UnitName"
                    cmbUnit.ValueMember = "UnitID"
                    cmbUnit.SelectedIndex = -1
                End Using
            End Using
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في جلب الوحدات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUnitsGrid()
        Try
            Dim query As String = "SELECT MU.MaterialUnitID, MU.UnitID, U.UnitName, MU.ConversionFactor, " &
                                  "MU.Barcode, MU.PurchasePrice " &
                                  "FROM MaterialUnits MU " &
                                  "INNER JOIN Units U ON MU.UnitID = U.UnitID " &
                                  "WHERE MU.MaterialID = @MatID ORDER BY MU.ConversionFactor ASC"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@MatID", _materialID)
                    Dim dt As New DataTable()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    dgvMaterialUnits.DataSource = dt

                    If dgvMaterialUnits.Columns.Contains("MaterialUnitID") Then dgvMaterialUnits.Columns("MaterialUnitID").Visible = False
                    If dgvMaterialUnits.Columns.Contains("UnitID") Then dgvMaterialUnits.Columns("UnitID").Visible = False

                    If dgvMaterialUnits.Columns.Contains("UnitName") Then dgvMaterialUnits.Columns("UnitName").HeaderText = "الوحدة"
                    If dgvMaterialUnits.Columns.Contains("ConversionFactor") Then dgvMaterialUnits.Columns("ConversionFactor").HeaderText = $"المعادل بـ ({_baseUnitName})"
                    If dgvMaterialUnits.Columns.Contains("Barcode") Then dgvMaterialUnits.Columns("Barcode").HeaderText = "الباركود"
                    If dgvMaterialUnits.Columns.Contains("PurchasePrice") Then dgvMaterialUnits.Columns("PurchasePrice").HeaderText = "سعر الشراء"
                End Using
            End Using
        Catch ex As Exception
            SmartMessageBox.Show("خطأ في جلب وحدات التحويل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddUnit_Click(sender As Object, e As EventArgs) Handles btnAddUnit.Click
        If cmbUnit.SelectedIndex = -1 Then
            SmartMessageBox.Show("يرجى اختيار الوحدة المراد إضافتها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim factor As Decimal = 0
        If Not Decimal.TryParse(txtConversionFactor.Text.Trim(), factor) OrElse factor <= 0 Then
            SmartMessageBox.Show("يرجى إدخال معامل تحويل صحيح أكبر من صفر!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConversionFactor.Focus()
            Exit Sub
        End If

        Dim price As Decimal = 0
        Decimal.TryParse(txtPurchasePrice.Text.Trim(), price)

        Dim query As String = "IF EXISTS (SELECT 1 FROM MaterialUnits WHERE MaterialID = @MatID AND UnitID = @UnitID) " &
                              "    UPDATE MaterialUnits SET ConversionFactor = @Factor, Barcode = @Barcode, PurchasePrice = @Price WHERE MaterialID = @MatID AND UnitID = @UnitID; " &
                              "ELSE " &
                              "    INSERT INTO MaterialUnits (MaterialID, UnitID, ConversionFactor, Barcode, PurchasePrice) VALUES (@MatID, @UnitID, @Factor, @Barcode, @Price);"

        Using conn As New SqlConnection(DBModule.ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@MatID", _materialID)
                cmd.Parameters.AddWithValue("@UnitID", cmbUnit.SelectedValue)
                cmd.Parameters.AddWithValue("@Factor", factor)
                cmd.Parameters.AddWithValue("@Barcode", If(String.IsNullOrWhiteSpace(txtBarcode.Text), DBNull.Value, txtBarcode.Text.Trim()))
                cmd.Parameters.AddWithValue("@Price", price)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadUnitsGrid()
                    ClearInputs()
                Catch ex As Exception
                    SmartMessageBox.Show("خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDeleteUnit_Click(sender As Object, e As EventArgs) Handles btnDeleteUnit.Click
        If dgvMaterialUnits.SelectedRows.Count = 0 Then Exit Sub
        Dim unitID As Integer = Convert.ToInt32(dgvMaterialUnits.SelectedRows(0).Cells("MaterialUnitID").Value)

        If SmartMessageBox.Show("هل أنت متأكد من حذف هذه الوحدة للتحويل؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand("DELETE FROM MaterialUnits WHERE MaterialUnitID = @ID", conn)
                    cmd.Parameters.AddWithValue("@ID", unitID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadUnitsGrid()
                    ClearInputs()
                End Using
            End Using
        End If
    End Sub

    Private Sub ClearInputs()
        cmbUnit.SelectedIndex = -1
        txtConversionFactor.Clear()
        txtBarcode.Clear()
        txtPurchasePrice.Text = "0.00"
        dgvMaterialUnits.ClearSelection()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvMaterialUnits_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMaterialUnits.SelectionChanged
        If dgvMaterialUnits.SelectedRows.Count = 0 Then Exit Sub
        Dim row As DataGridViewRow = dgvMaterialUnits.SelectedRows(0)

        If row.Cells("UnitID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("UnitID").Value) Then
            cmbUnit.SelectedValue = row.Cells("UnitID").Value
            txtConversionFactor.Text = Convert.ToDecimal(row.Cells("ConversionFactor").Value).ToString("G29")
            txtBarcode.Text = If(IsDBNull(row.Cells("Barcode").Value), "", row.Cells("Barcode").Value.ToString())
            txtPurchasePrice.Text = If(IsDBNull(row.Cells("PurchasePrice").Value), "0.00", Convert.ToDecimal(row.Cells("PurchasePrice").Value).ToString("N2"))
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnAddUnit_Click(sender, e)
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        ClearInputs()
    End Sub
End Class