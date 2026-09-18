Imports System.Data.SqlClient
Imports System.Text

Public Class frmStoreStock

    ' =========================================================
    ' البيانات المؤقتة
    ' =========================================================
    Private _cachedStock As DataTable = Nothing
    Private _selectedStockID As Integer = -1
    Private _suppressEvents As Boolean = False
    Private Shared _hasUnitColumns As Boolean? = Nothing

    ' =========================================================
    ' حالات المخزون - StatusCode
    ' 0 = ممتاز  (فوق الحد الأقصى أو ليس له حد)
    ' 1 = جيد    (بين الأدنى والأقصى)
    ' 2 = منخفض  (أقل من الأدنى لكن > 0)
    ' 3 = نفد    (= صفر)
    ' 4 = عجز    (< صفر)
    ' =========================================================

    ' =========================================================
    ' التحقق من وجود أعمدة MinUnitID و MaxUnitID في قاعدة البيانات
    ' =========================================================
    Private Function CheckIfUnitColumnsExist() As Boolean

        If _hasUnitColumns.HasValue Then Return _hasUnitColumns.Value

        Try

            Dim query As String =
                "SELECT COUNT(1) FROM INFORMATION_SCHEMA.COLUMNS " &
                "WHERE TABLE_NAME = 'StoreStock' AND COLUMN_NAME IN ('MinUnitID', 'MaxUnitID')"

            Dim dt As DataTable = DBModule.ExecuteQuery(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim cnt As Integer = Convert.ToInt32(dt.Rows(0)(0))
                _hasUnitColumns = (cnt >= 2)
            Else
                _hasUnitColumns = False
            End If

        Catch ex As Exception
            _hasUnitColumns = False
        End Try

        Return _hasUnitColumns.Value

    End Function

    ' =========================================================
    ' تحميل وحدات الخامة في كومبو بوكس الحد الأدنى والأقصى
    ' =========================================================
    Private Sub LoadMaterialUnits(materialID As Integer)

        Try

            Dim query As String =
                "SELECT U.UnitID, U.UnitName, CAST(1 AS DECIMAL(18,6)) AS ConversionFactor " &
                "FROM RawMaterials RM " &
                "INNER JOIN Units U ON RM.UnitID = U.UnitID " &
                "WHERE RM.MaterialID = @MaterialID " &
                "UNION ALL " &
                "SELECT MU.UnitID, U.UnitName, MU.ConversionFactor " &
                "FROM MaterialUnits MU " &
                "INNER JOIN Units U ON MU.UnitID = U.UnitID " &
                "INNER JOIN RawMaterials RM ON MU.MaterialID = RM.MaterialID " &
                "WHERE MU.MaterialID = @MaterialID AND MU.UnitID <> RM.UnitID " &
                "ORDER BY ConversionFactor ASC"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@MaterialID", SqlDbType.Int).Value = materialID

                    Dim dtMin As New DataTable()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dtMin)
                    End Using

                    Dim dtMax As DataTable = dtMin.Copy()

                    Dim oldSuppress As Boolean = _suppressEvents
                    _suppressEvents = True

                    cmbMinUnit.DataSource = dtMin
                    cmbMinUnit.DisplayMember = "UnitName"
                    cmbMinUnit.ValueMember = "UnitID"

                    cmbMaxUnit.DataSource = dtMax
                    cmbMaxUnit.DisplayMember = "UnitName"
                    cmbMaxUnit.ValueMember = "UnitID"

                    If dtMin.Rows.Count > 0 Then
                        cmbMinUnit.SelectedIndex = 0
                        cmbMaxUnit.SelectedIndex = 0
                    Else
                        cmbMinUnit.SelectedIndex = -1
                        cmbMaxUnit.SelectedIndex = -1
                    End If

                    _suppressEvents = oldSuppress

                End Using
            End Using

        Catch ex As Exception
            'Debug.WriteLine("LoadMaterialUnits Error: " & ex.Message)
        End Try

    End Sub

    ' =========================================================
    ' دوال مساعدة للوحدات والتحويل
    ' =========================================================
    Private Function GetUnitConversionFactor(cmb As Guna.UI2.WinForms.Guna2ComboBox) As Decimal

        If cmb.SelectedIndex = -1 OrElse cmb.SelectedItem Is Nothing Then Return 1D

        Dim drv As DataRowView = TryCast(cmb.SelectedItem, DataRowView)
        If drv IsNot Nothing AndAlso Not IsDBNull(drv("ConversionFactor")) Then
            Dim factor As Decimal = Convert.ToDecimal(drv("ConversionFactor"))
            Return If(factor > 0D, factor, 1D)
        End If

        Return 1D

    End Function

    Private Function GetSelectedUnitID(cmb As Guna.UI2.WinForms.Guna2ComboBox) As Object

        If cmb.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmb.SelectedValue) Then
            Dim val As Integer
            If Integer.TryParse(cmb.SelectedValue.ToString(), val) AndAlso val > 0 Then
                Return val
            End If
        End If

        Return DBNull.Value

    End Function

    ' =========================================================
    ' تحميل المخازن والخامات في الكومبوهات
    ' =========================================================
    Private Sub FillDropdowns()

        Try

            ' المخازن
            Dim dtStores As DataTable = DBModule.ExecuteQuery(
                "SELECT StoreID, StoreName FROM Stores " &
                "WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) " &
                "ORDER BY StoreName ASC"
            )

            If dtStores IsNot Nothing Then
                _suppressEvents = True
                cmbStore.DataSource = dtStores
                cmbStore.DisplayMember = "StoreName"
                cmbStore.ValueMember = "StoreID"
                Dim defaultStoreID = If(SettingsManager.GetSetting("CurrentStoreID"), "")
                cmbStore.SelectedIndex = defaultStoreID
                cmbMaterial_SelectedIndexChanged(Nothing, Nothing)
                _suppressEvents = False
            End If

            ' الخامات
            Dim dtMaterials As DataTable = DBModule.ExecuteQuery(
                "SELECT R.MaterialID, R.MaterialName FROM RawMaterials R " &
                "WHERE R.IsActive = 1 AND (R.IsDeleted = 0 OR R.IsDeleted IS NULL) " &
                "ORDER BY R.MaterialName ASC"
            )

            If dtMaterials IsNot Nothing Then
                _suppressEvents = True
                cmbMaterial.DataSource = dtMaterials
                cmbMaterial.DisplayMember = "MaterialName"
                cmbMaterial.ValueMember = "MaterialID"
                cmbMaterial.SelectedIndex = -1
                _suppressEvents = False
            End If

        Catch ex As Exception
            Debug.WriteLine("FillDropdowns Error: " & ex.Message)
        End Try

    End Sub

    ' =========================================================
    ' تحميل مخزون الفرع في الكاش
    ' =========================================================
    Private Sub LoadStockGrid(Optional storeID As Integer = -1)

        Try

            Dim hasUnitCols As Boolean = CheckIfUnitColumnsExist()

            Dim query As String =
                "SELECT " &
                "SS.StockID, " &
                "SS.StoreID, " &
                "ST.StoreName, " &
                "SS.MaterialID, " &
                "RM.MaterialName, " &
                "SS.CurrentStock, " &
                "U.UnitName AS BaseUnitName, " &
                "SS.MinStock, " &
                "SS.MaxStock "

            If hasUnitCols Then
                query &=
                    ", SS.MinUnitID, " &
                    "UMin.UnitName AS MinUnitName, " &
                    "ISNULL(FMin.ConversionFactor, 1) AS MinFactor, " &
                    "SS.MaxUnitID, " &
                    "UMax.UnitName AS MaxUnitName, " &
                    "ISNULL(FMax.ConversionFactor, 1) AS MaxFactor "
            End If

            query &=
                "FROM StoreStock SS " &
                "INNER JOIN Stores ST ON SS.StoreID = ST.StoreID " &
                "INNER JOIN RawMaterials RM ON SS.MaterialID = RM.MaterialID " &
                "INNER JOIN Units U ON RM.UnitID = U.UnitID "

            If hasUnitCols Then
                query &=
                    "LEFT JOIN Units UMin ON SS.MinUnitID = UMin.UnitID " &
                    "LEFT JOIN Units UMax ON SS.MaxUnitID = UMax.UnitID " &
                    "LEFT JOIN ( " &
                    "    SELECT MaterialID, UnitID, CAST(1 AS DECIMAL(18,6)) AS ConversionFactor FROM RawMaterials " &
                    "    UNION ALL " &
                    "    SELECT MaterialID, UnitID, ConversionFactor FROM MaterialUnits " &
                    ") FMin ON FMin.MaterialID = SS.MaterialID AND FMin.UnitID = SS.MinUnitID " &
                    "LEFT JOIN ( " &
                    "    SELECT MaterialID, UnitID, CAST(1 AS DECIMAL(18,6)) AS ConversionFactor FROM RawMaterials " &
                    "    UNION ALL " &
                    "    SELECT MaterialID, UnitID, ConversionFactor FROM MaterialUnits " &
                    ") FMax ON FMax.MaterialID = SS.MaterialID AND FMax.UnitID = SS.MaxUnitID "
            End If

            If storeID > 0 Then
                query &= "WHERE SS.StoreID = @StoreID "
            End If

            query &= "ORDER BY RM.MaterialName ASC"

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(query, conn)

                    If storeID > 0 Then
                        cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = storeID
                    End If

                    Dim dt As New DataTable()

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    ' أعمدة إضافية للعرض
                    If Not dt.Columns.Contains("DisplayedStock") Then
                        dt.Columns.Add("DisplayedStock", GetType(String))
                    End If
                    If Not dt.Columns.Contains("DisplayedMinStock") Then
                        dt.Columns.Add("DisplayedMinStock", GetType(String))
                    End If
                    If Not dt.Columns.Contains("DisplayedMaxStock") Then
                        dt.Columns.Add("DisplayedMaxStock", GetType(String))
                    End If
                    If Not dt.Columns.Contains("StockStatus") Then
                        dt.Columns.Add("StockStatus", GetType(String))
                    End If
                    If Not dt.Columns.Contains("StatusCode") Then
                        dt.Columns.Add("StatusCode", GetType(Integer))
                    End If

                    ' حساب القيم المعروضة والحالة لكل صف
                    For Each row As DataRow In dt.Rows

                        Dim matID As Integer = Convert.ToInt32(row("MaterialID"))
                        Dim baseUnitName As String = If(IsDBNull(row("BaseUnitName")), "", row("BaseUnitName").ToString())

                        Dim currentStock As Decimal =
                            If(IsDBNull(row("CurrentStock")), 0D, Convert.ToDecimal(row("CurrentStock")))

                        Dim minStock As Decimal =
                            If(IsDBNull(row("MinStock")), 0D, Convert.ToDecimal(row("MinStock")))

                        Dim maxStock As Decimal =
                            If(IsDBNull(row("MaxStock")), 0D, Convert.ToDecimal(row("MaxStock")))

                        ' الرصيد الحالي بالوحدات
                        row("DisplayedStock") = FormatMaterialStock(matID, currentStock)

                        ' الحد الأدنى المعروض
                        Dim minUnitName As String = ""
                        Dim minFactor As Decimal = 1D
                        If hasUnitCols AndAlso dt.Columns.Contains("MinUnitID") AndAlso Not IsDBNull(row("MinUnitID")) Then
                            minUnitName = If(Not IsDBNull(row("MinUnitName")), row("MinUnitName").ToString(), "")
                            minFactor = If(dt.Columns.Contains("MinFactor") AndAlso Not IsDBNull(row("MinFactor")), Convert.ToDecimal(row("MinFactor")), 1D)
                        End If
                        If String.IsNullOrEmpty(minUnitName) Then minUnitName = baseUnitName
                        Dim dispMinVal As Decimal = If(minFactor > 0D, minStock / minFactor, minStock)
                        row("DisplayedMinStock") = dispMinVal.ToString("0.######") & " " & minUnitName

                        ' الحد الأقصى المعروض
                        Dim maxUnitName As String = ""
                        Dim maxFactor As Decimal = 1D
                        If hasUnitCols AndAlso dt.Columns.Contains("MaxUnitID") AndAlso Not IsDBNull(row("MaxUnitID")) Then
                            maxUnitName = If(Not IsDBNull(row("MaxUnitName")), row("MaxUnitName").ToString(), "")
                            maxFactor = If(dt.Columns.Contains("MaxFactor") AndAlso Not IsDBNull(row("MaxFactor")), Convert.ToDecimal(row("MaxFactor")), 1D)
                        End If
                        If String.IsNullOrEmpty(maxUnitName) Then maxUnitName = baseUnitName
                        Dim dispMaxVal As Decimal = If(maxFactor > 0D, maxStock / maxFactor, maxStock)
                        row("DisplayedMaxStock") = If(maxStock > 0D, dispMaxVal.ToString("0.######") & " " & maxUnitName, "-")

                        ' 5 حالات للمخزون
                        If currentStock < 0D Then
                            row("StockStatus") = "عجز"
                            row("StatusCode") = 4

                        ElseIf currentStock = 0D Then
                            row("StockStatus") = "نفد"
                            row("StatusCode") = 3

                        ElseIf currentStock <= minStock Then
                            row("StockStatus") = "منخفض"
                            row("StatusCode") = 2

                        ElseIf maxStock > 0D AndAlso currentStock >= maxStock Then
                            row("StockStatus") = "ممتاز"
                            row("StatusCode") = 0

                        Else
                            row("StockStatus") = "جيد"
                            row("StatusCode") = 1

                        End If

                    Next

                    _cachedStock = dt
                    dgvStock.DataSource = dt

                End Using

            End Using

            ConfigureGrid()
            ApplyStockColors()

        Catch ex As Exception

            MessageBox.Show(
                "خطأ في تحميل أرصدة المخزن:" & Environment.NewLine & ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' =========================================================
    ' البحث المتقدم في الكاش
    ' =========================================================
    Private Sub ApplySearch()

        If _cachedStock Is Nothing Then Exit Sub

        Dim searchText As String = txtSearch.Text.Trim()
        Dim searchField As String = If(cmbSearchField.SelectedItem?.ToString(), "")

        If String.IsNullOrEmpty(searchText) Then
            dgvStock.DataSource = _cachedStock
            ConfigureGrid()
            ApplyStockColors()
            Exit Sub
        End If

        Dim dv As New DataView(_cachedStock)

        Select Case searchField

            Case "اسم الخامة"
                dv.RowFilter = $"MaterialName LIKE '%{EscapeFilter(searchText)}%'"

            Case "المخزن"
                dv.RowFilter = $"StoreName LIKE '%{EscapeFilter(searchText)}%'"

            Case "الحالة"
                Select Case searchText.Trim()
                    Case "ممتاز"
                        dv.RowFilter = "StatusCode = 0"
                    Case "جيد"
                        dv.RowFilter = "StatusCode = 1"
                    Case "منخفض"
                        dv.RowFilter = "StatusCode = 2"
                    Case "نفد"
                        dv.RowFilter = "StatusCode = 3"
                    Case "عجز"
                        dv.RowFilter = "StatusCode = 4"
                    Case Else
                        dv.RowFilter = $"StockStatus LIKE '%{EscapeFilter(searchText)}%'"
                End Select

            Case Else
                dv.RowFilter = $"MaterialName LIKE '%{EscapeFilter(searchText)}%'"

        End Select

        Dim result As DataTable = dv.ToTable()
        dgvStock.DataSource = result
        ConfigureGrid()
        ApplyStockColors()

    End Sub

    Private Function EscapeFilter(text As String) As String
        Return text.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]")
    End Function

    ' =========================================================
    ' تجهيز DataGridView
    ' =========================================================
    Private Sub ConfigureGrid()

        Dim hiddenColumns As String() = {
            "StockID", "StoreID", "MaterialID",
            "CurrentStock", "BaseUnitName", "StatusCode",
            "MinStock", "MaxStock",
            "MinUnitID", "MaxUnitID", "MinUnitName", "MaxUnitName",
            "MinFactor", "MaxFactor"
        }

        For Each col As String In hiddenColumns
            If dgvStock.Columns.Contains(col) Then
                dgvStock.Columns(col).Visible = False
            End If
        Next

        Dim headers As New Dictionary(Of String, String) From {
            {"StoreName", "المخزن"},
            {"MaterialName", "الخامة"},
            {"DisplayedStock", "الكمية المتوفرة"},
            {"DisplayedMinStock", "الحد الأدنى"},
            {"DisplayedMaxStock", "الحد الأقصى"},
            {"StockStatus", "الحالة"}
        }

        For Each kvp In headers
            If dgvStock.Columns.Contains(kvp.Key) Then
                dgvStock.Columns(kvp.Key).HeaderText = kvp.Value
            End If
        Next

    End Sub

    ' =========================================================
    ' تلوين الصفوف حسب حالة المخزون (5 حالات)
    ' =========================================================
    Private Sub ApplyStockColors()

        'For Each row As DataGridViewRow In dgvStock.Rows

        '    If row.IsNewRow Then Continue For
        '    If Not dgvStock.Columns.Contains("StatusCode") Then Continue For

        '    Dim val = row.Cells("StatusCode").Value
        '    If val Is Nothing OrElse IsDBNull(val) Then Continue For

        '    Dim statusCode As Integer = Convert.ToInt32(val)

        '    Select Case statusCode

        '        Case 4
        '            ' عجز - بنفسجي
        '            row.DefaultCellStyle.BackColor = Color.FromArgb(230, 210, 240)
        '            row.DefaultCellStyle.ForeColor = Color.FromArgb(100, 0, 130)

        '        Case 3
        '            ' نفد - أحمر
        '            row.DefaultCellStyle.BackColor = Color.MistyRose
        '            row.DefaultCellStyle.ForeColor = Color.DarkRed

        '        Case 2
        '            ' منخفض - برتقالي
        '            row.DefaultCellStyle.BackColor = Color.LemonChiffon
        '            row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod

        '        Case 1
        '            ' جيد - ألوان عادية
        '            row.DefaultCellStyle.BackColor = dgvStock.DefaultCellStyle.BackColor
        '            row.DefaultCellStyle.ForeColor = dgvStock.DefaultCellStyle.ForeColor

        '        Case 0
        '            ' ممتاز - أخضر فاتح
        '            row.DefaultCellStyle.BackColor = Color.FromArgb(220, 245, 220)
        '            row.DefaultCellStyle.ForeColor = Color.DarkGreen

        '    End Select

        'Next

    End Sub

    ' =========================================================
    ' التحقق من صحة البيانات
    ' =========================================================
    Private Function IsValidInput() As Boolean

        If cmbStore.SelectedIndex = -1 OrElse cmbStore.SelectedValue Is Nothing Then
            MessageBox.Show("يرجى اختيار المخزن.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbMaterial.SelectedIndex = -1 OrElse cmbMaterial.SelectedValue Is Nothing Then
            MessageBox.Show("يرجى اختيار الخامة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim stock As Decimal
        If Not Decimal.TryParse(txtCurrentStock.Text, stock) Then
            MessageBox.Show("الرصيد الحالي يجب أن يكون رقماً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim minVal As Decimal
        If Not String.IsNullOrWhiteSpace(txtMinStock.Text) AndAlso Not Decimal.TryParse(txtMinStock.Text, minVal) Then
            MessageBox.Show("الحد الأدنى يجب أن يكون رقماً صحيحاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim maxVal As Decimal
        If Not String.IsNullOrWhiteSpace(txtMaxStock.Text) AndAlso Not Decimal.TryParse(txtMaxStock.Text, maxVal) Then
            MessageBox.Show("الحد الأقصى يجب أن يكون رقماً صحيحاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True

    End Function

    ' =========================================================
    ' تفريغ الحقول
    ' =========================================================
    Private Sub ClearFields()

        _suppressEvents = True
        _selectedStockID = -1
        cmbMaterial.SelectedIndex = -1
        cmbMinUnit.DataSource = Nothing
        cmbMaxUnit.DataSource = Nothing
        txtCurrentStock.Text = "0"
        txtMinStock.Text = "0"
        txtMaxStock.Text = "0"
        txtDisplayedStock.Text = ""
        lblStockStatus.Text = "---"
        lblStockStatus.BackColor = Color.Transparent
        lblStockStatus.ForeColor = ThemeManager.Instance.CurrentPalette.TextPrimary
        dgvStock.ClearSelection()
        _suppressEvents = False

    End Sub

    ' =========================================================
    ' زر الإضافة
    ' =========================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If Not IsValidInput() Then Exit Sub

        Dim storeID As Integer = Convert.ToInt32(cmbStore.SelectedValue)
        Dim materialID As Integer = Convert.ToInt32(cmbMaterial.SelectedValue)
        Dim currentStock As Decimal = 0

        Decimal.TryParse(txtCurrentStock.Text, currentStock)

        ' حساب الحد الأدنى بالوحدة الأساسية
        Dim minInput As Decimal = 0D
        Decimal.TryParse(txtMinStock.Text, minInput)
        Dim minFactor As Decimal = GetUnitConversionFactor(cmbMinUnit)
        Dim baseMinStock As Decimal = minInput * minFactor
        Dim minUnitID As Object = GetSelectedUnitID(cmbMinUnit)

        ' حساب الحد الأقصى بالوحدة الأساسية
        Dim maxInput As Decimal = 0D
        Decimal.TryParse(txtMaxStock.Text, maxInput)
        Dim maxFactor As Decimal = GetUnitConversionFactor(cmbMaxUnit)
        Dim baseMaxStock As Decimal = maxInput * maxFactor
        Dim maxUnitID As Object = GetSelectedUnitID(cmbMaxUnit)

        Dim hasUnitCols As Boolean = CheckIfUnitColumnsExist()

        Try

            Using conn As New SqlConnection(DBModule.ConnectionString)
                conn.Open()

                ' التحقق من عدم وجود سجل مسبق
                Using cmdCheck As New SqlCommand(
                    "SELECT COUNT(1) FROM StoreStock WHERE StoreID = @StoreID AND MaterialID = @MaterialID",
                    conn
                )
                    cmdCheck.Parameters.Add("@StoreID", SqlDbType.Int).Value = storeID
                    cmdCheck.Parameters.Add("@MaterialID", SqlDbType.Int).Value = materialID

                    If Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0 Then
                        MessageBox.Show(
                            "هذه الخامة موجودة بالفعل في هذا المخزن." & Environment.NewLine &
                            "استخدم زر التعديل لتحديث الرصيد والحدود.",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )
                        Return
                    End If

                End Using

                Dim insertSql As String
                If hasUnitCols Then
                    insertSql =
                        "INSERT INTO StoreStock (StoreID, MaterialID, CurrentStock, MinStock, MaxStock, MinUnitID, MaxUnitID) " &
                        "VALUES (@StoreID, @MaterialID, @CurrentStock, @MinStock, @MaxStock, @MinUnitID, @MaxUnitID)"
                Else
                    insertSql =
                        "INSERT INTO StoreStock (StoreID, MaterialID, CurrentStock, MinStock, MaxStock) " &
                        "VALUES (@StoreID, @MaterialID, @CurrentStock, @MinStock, @MaxStock)"
                End If

                Using cmdInsert As New SqlCommand(insertSql, conn)
                    cmdInsert.Parameters.Add("@StoreID", SqlDbType.Int).Value = storeID
                    cmdInsert.Parameters.Add("@MaterialID", SqlDbType.Int).Value = materialID
                    cmdInsert.Parameters.Add("@CurrentStock", SqlDbType.Decimal).Value = currentStock
                    cmdInsert.Parameters.Add("@MinStock", SqlDbType.Decimal).Value = baseMinStock
                    cmdInsert.Parameters.Add("@MaxStock", SqlDbType.Decimal).Value = baseMaxStock

                    If hasUnitCols Then
                        cmdInsert.Parameters.Add("@MinUnitID", SqlDbType.Int).Value = If(minUnitID Is DBNull.Value, DBNull.Value, Convert.ToInt32(minUnitID))
                        cmdInsert.Parameters.Add("@MaxUnitID", SqlDbType.Int).Value = If(maxUnitID Is DBNull.Value, DBNull.Value, Convert.ToInt32(maxUnitID))
                    End If

                    cmdInsert.ExecuteNonQuery()
                End Using

            End Using

            MessageBox.Show("تمت الإضافة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _cachedStock = Nothing
            LoadStockGrid(storeID)
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(
                "خطأ أثناء الإضافة:" & Environment.NewLine & ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    ' =========================================================
    ' زر التعديل
    ' =========================================================
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If _selectedStockID = -1 Then
            MessageBox.Show("يرجى تحديد صف من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not IsValidInput() Then Exit Sub

        Dim currentStock As Decimal = 0
        Decimal.TryParse(txtCurrentStock.Text, currentStock)

        ' حساب الحد الأدنى بالوحدة الأساسية
        Dim minInput As Decimal = 0D
        Decimal.TryParse(txtMinStock.Text, minInput)
        Dim minFactor As Decimal = GetUnitConversionFactor(cmbMinUnit)
        Dim baseMinStock As Decimal = minInput * minFactor
        Dim minUnitID As Object = GetSelectedUnitID(cmbMinUnit)

        ' حساب الحد الأقصى بالوحدة الأساسية
        Dim maxInput As Decimal = 0D
        Decimal.TryParse(txtMaxStock.Text, maxInput)
        Dim maxFactor As Decimal = GetUnitConversionFactor(cmbMaxUnit)
        Dim baseMaxStock As Decimal = maxInput * maxFactor
        Dim maxUnitID As Object = GetSelectedUnitID(cmbMaxUnit)

        Dim hasUnitCols As Boolean = CheckIfUnitColumnsExist()

        Try

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Dim updateSql As String
                If hasUnitCols Then
                    updateSql =
                        "UPDATE StoreStock SET " &
                        "CurrentStock = @CurrentStock, " &
                        "MinStock = @MinStock, " &
                        "MaxStock = @MaxStock, " &
                        "MinUnitID = @MinUnitID, " &
                        "MaxUnitID = @MaxUnitID " &
                        "WHERE StockID = @StockID"
                Else
                    updateSql =
                        "UPDATE StoreStock SET " &
                        "CurrentStock = @CurrentStock, " &
                        "MinStock = @MinStock, " &
                        "MaxStock = @MaxStock " &
                        "WHERE StockID = @StockID"
                End If

                Using cmd As New SqlCommand(updateSql, conn)
                    cmd.Parameters.Add("@CurrentStock", SqlDbType.Decimal).Value = currentStock
                    cmd.Parameters.Add("@MinStock", SqlDbType.Decimal).Value = baseMinStock
                    cmd.Parameters.Add("@MaxStock", SqlDbType.Decimal).Value = baseMaxStock
                    cmd.Parameters.Add("@StockID", SqlDbType.Int).Value = _selectedStockID

                    If hasUnitCols Then
                        cmd.Parameters.Add("@MinUnitID", SqlDbType.Int).Value = If(minUnitID Is DBNull.Value, DBNull.Value, Convert.ToInt32(minUnitID))
                        cmd.Parameters.Add("@MaxUnitID", SqlDbType.Int).Value = If(maxUnitID Is DBNull.Value, DBNull.Value, Convert.ToInt32(maxUnitID))
                    End If

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            MessageBox.Show("تم التعديل بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim storeID As Integer = If(cmbStore.SelectedIndex >= 0, Convert.ToInt32(cmbStore.SelectedValue), -1)
            _cachedStock = Nothing
            LoadStockGrid(storeID)
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(
                "خطأ أثناء التعديل:" & Environment.NewLine & ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    ' =========================================================
    ' زر الحذف (نهائي)
    ' =========================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If _selectedStockID = -1 Then
            MessageBox.Show("يرجى تحديد صف من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim materialName As String = ""
        If dgvStock.SelectedRows.Count > 0 Then
            Dim cell = dgvStock.SelectedRows(0).Cells("MaterialName")
            If cell.Value IsNot Nothing Then materialName = cell.Value.ToString()
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            $"هل أنت متأكد من حذف سجل الخامة ""{materialName}"" من المخزن؟" & Environment.NewLine &
            "هذا الإجراء لا يمكن التراجع عنه.",
            "تأكيد الحذف النهائي",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If confirm <> DialogResult.Yes Then Exit Sub

        Try

            Using conn As New SqlConnection(DBModule.ConnectionString)

                Using cmd As New SqlCommand(
                    "DELETE FROM StoreStock WHERE StockID = @StockID",
                    conn
                )
                    cmd.Parameters.Add("@StockID", SqlDbType.Int).Value = _selectedStockID
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            MessageBox.Show("تم الحذف بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim storeID As Integer = If(cmbStore.SelectedIndex >= 0, Convert.ToInt32(cmbStore.SelectedValue), -1)
            _cachedStock = Nothing
            LoadStockGrid(storeID)
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(
                "خطأ أثناء الحذف:" & Environment.NewLine & ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    ' =========================================================
    ' تحديد صف من الجريد — يملأ الحقول
    ' =========================================================
    Private Sub dgvStock_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvStock.SelectionChanged

        If _suppressEvents Then Exit Sub
        If dgvStock.SelectedRows.Count = 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvStock.SelectedRows(0)
        If row.IsNewRow Then Exit Sub

        Try

            _suppressEvents = True

            ' StockID
            If dgvStock.Columns.Contains("StockID") AndAlso
               row.Cells("StockID").Value IsNot Nothing AndAlso
               Not IsDBNull(row.Cells("StockID").Value) Then
                _selectedStockID = Convert.ToInt32(row.Cells("StockID").Value)
            End If

            ' المخزن
            If dgvStock.Columns.Contains("StoreID") AndAlso
               row.Cells("StoreID").Value IsNot Nothing AndAlso
               Not IsDBNull(row.Cells("StoreID").Value) Then
                cmbStore.SelectedValue = Convert.ToInt32(row.Cells("StoreID").Value)
            End If

            ' الخامة
            Dim matID As Integer = 0
            If dgvStock.Columns.Contains("MaterialID") AndAlso
               row.Cells("MaterialID").Value IsNot Nothing AndAlso
               Not IsDBNull(row.Cells("MaterialID").Value) Then
                matID = Convert.ToInt32(row.Cells("MaterialID").Value)
                cmbMaterial.SelectedValue = matID
            End If

            ' تحميل وحدات الخامة في الكومبوهات
            If matID > 0 Then
                LoadMaterialUnits(matID)
            End If

            ' الحد الأدنى والوحدة
            Dim minBase As Decimal = 0D
            If dgvStock.Columns.Contains("MinStock") AndAlso
               row.Cells("MinStock").Value IsNot Nothing AndAlso
               Not IsDBNull(row.Cells("MinStock").Value) Then
                minBase = Convert.ToDecimal(row.Cells("MinStock").Value)
            End If

            Dim minUnitID As Object = If(dgvStock.Columns.Contains("MinUnitID"), row.Cells("MinUnitID").Value, DBNull.Value)
            If minUnitID IsNot Nothing AndAlso Not IsDBNull(minUnitID) AndAlso Convert.ToInt32(minUnitID) > 0 Then
                cmbMinUnit.SelectedValue = Convert.ToInt32(minUnitID)
                Dim fMin As Decimal = GetUnitConversionFactor(cmbMinUnit)
                txtMinStock.Text = If(fMin > 0D, (minBase / fMin).ToString("0.######"), minBase.ToString("0.######"))
            Else
                If cmbMinUnit.Items.Count > 0 Then cmbMinUnit.SelectedIndex = 0
                txtMinStock.Text = minBase.ToString("0.######")
            End If

            ' الحد الأقصى والوحدة
            Dim maxBase As Decimal = 0D
            If dgvStock.Columns.Contains("MaxStock") AndAlso
               row.Cells("MaxStock").Value IsNot Nothing AndAlso
               Not IsDBNull(row.Cells("MaxStock").Value) Then
                maxBase = Convert.ToDecimal(row.Cells("MaxStock").Value)
            End If

            Dim maxUnitID As Object = If(dgvStock.Columns.Contains("MaxUnitID"), row.Cells("MaxUnitID").Value, DBNull.Value)
            If maxUnitID IsNot Nothing AndAlso Not IsDBNull(maxUnitID) AndAlso Convert.ToInt32(maxUnitID) > 0 Then
                cmbMaxUnit.SelectedValue = Convert.ToInt32(maxUnitID)
                Dim fMax As Decimal = GetUnitConversionFactor(cmbMaxUnit)
                txtMaxStock.Text = If(fMax > 0D, (maxBase / fMax).ToString("0.######"), maxBase.ToString("0.######"))
            Else
                If cmbMaxUnit.Items.Count > 0 Then cmbMaxUnit.SelectedIndex = 0
                txtMaxStock.Text = maxBase.ToString("0.######")
            End If

            ' الرصيد الحالي (الوحدة الأساسية)
            If dgvStock.Columns.Contains("CurrentStock") AndAlso
               row.Cells("CurrentStock").Value IsNot Nothing AndAlso
               Not IsDBNull(row.Cells("CurrentStock").Value) Then
                txtCurrentStock.Text = Convert.ToDecimal(row.Cells("CurrentStock").Value).ToString("0.######")
            Else
                txtCurrentStock.Text = "0"
            End If

            ' الرصيد المعروض
            If dgvStock.Columns.Contains("DisplayedStock") AndAlso
               row.Cells("DisplayedStock").Value IsNot Nothing AndAlso
               Not IsDBNull(row.Cells("DisplayedStock").Value) Then
                txtDisplayedStock.Text = row.Cells("DisplayedStock").Value.ToString()
            End If

            ' الحالة مع تلوين الـ label
            If dgvStock.Columns.Contains("StockStatus") AndAlso
               row.Cells("StockStatus").Value IsNot Nothing AndAlso
               Not IsDBNull(row.Cells("StockStatus").Value) Then

                lblStockStatus.Text = row.Cells("StockStatus").Value.ToString()

                Dim statusCode As Integer = 1
                If dgvStock.Columns.Contains("StatusCode") AndAlso
                   row.Cells("StatusCode").Value IsNot Nothing AndAlso
                   Not IsDBNull(row.Cells("StatusCode").Value) Then
                    statusCode = Convert.ToInt32(row.Cells("StatusCode").Value)
                End If

                Select Case statusCode
                    Case 4
                        lblStockStatus.BackColor = Color.FromArgb(230, 210, 240)
                        lblStockStatus.ForeColor = Color.FromArgb(100, 0, 130)
                    Case 3
                        lblStockStatus.BackColor = Color.MistyRose
                        lblStockStatus.ForeColor = Color.DarkRed
                    Case 2
                        lblStockStatus.BackColor = Color.LemonChiffon
                        lblStockStatus.ForeColor = Color.DarkGoldenrod
                    Case 1
                        lblStockStatus.BackColor = Color.FromArgb(230, 245, 255)
                        lblStockStatus.ForeColor = Color.SteelBlue
                    Case 0
                        lblStockStatus.BackColor = Color.FromArgb(220, 245, 220)
                        lblStockStatus.ForeColor = Color.DarkGreen
                End Select

            End If

        Catch ex As Exception
            Debug.WriteLine("dgvStock_SelectionChanged Error: " & ex.Message)
        Finally
            _suppressEvents = False
        End Try

    End Sub

    ' =========================================================
    ' عند تغيير اختيار الخامة، تحميل وحداتها تلقائياً
    ' =========================================================
    Private Sub cmbMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaterial.SelectedIndexChanged

        If _suppressEvents Then Exit Sub

        If cmbMaterial.SelectedIndex = -1 OrElse cmbMaterial.SelectedValue Is Nothing Then
            cmbMinUnit.DataSource = Nothing
            cmbMaxUnit.DataSource = Nothing
            Exit Sub
        End If

        Dim matID As Integer
        If Integer.TryParse(cmbMaterial.SelectedValue.ToString(), matID) AndAlso matID > 0 Then
            LoadMaterialUnits(matID)
        End If

    End Sub

    ' =========================================================
    ' عرض الرصيد بالوحدات (مثال: 2 شكارة + 3 كيلو + 200 جرام)
    ' =========================================================
    Private Function FormatMaterialStock(materialID As Integer, currentStock As Decimal) As String

        Try

            If currentStock < 0D Then
                Return "عجز: " & FormatMaterialStock(materialID, Math.Abs(currentStock))
            End If

            If currentStock = 0D Then Return "0"

            Dim units As DataTable = GetMaterialUnitsForDisplay(materialID)

            If units Is Nothing OrElse units.Rows.Count = 0 Then
                Return currentStock.ToString("0.######")
            End If

            Dim remaining As Decimal = currentStock
            Dim parts As New List(Of String)

            For Each unitRow As DataRow In units.Rows
                Dim factor As Decimal = Convert.ToDecimal(unitRow("ConversionFactor"))
                If factor <= 0D Then Continue For

                Dim unitName As String = unitRow("UnitName").ToString()
                Dim unitCount As Decimal = Math.Floor(remaining / factor)

                If unitCount > 0D Then
                    Dim countText As String
                    If unitCount = Math.Truncate(unitCount) Then
                        countText = Convert.ToInt64(unitCount).ToString()
                    Else
                        countText = unitCount.ToString("0.######")
                    End If
                    parts.Add(countText & " " & unitName)
                    remaining -= unitCount * factor
                    remaining = Decimal.Round(remaining, 6)
                End If

                If remaining <= 0.0000005D Then Exit For
            Next

            If remaining > 0.0000005D Then
                parts.Add(remaining.ToString("0.######") & " " & GetBaseUnitName(materialID))
            End If

            Return If(parts.Count = 0, currentStock.ToString("0.######"), String.Join(" + ", parts))

        Catch ex As Exception
            Debug.WriteLine("FormatMaterialStock Error: " & ex.Message)
            Return currentStock.ToString("0.######")
        End Try

    End Function

    ' =========================================================
    ' تحميل وحدات الخامة للعرض
    ' =========================================================
    Private Function GetMaterialUnitsForDisplay(materialID As Integer) As DataTable

        Dim dt As New DataTable()

        Try

            Dim query As String =
                "SELECT U.UnitName, CAST(1 AS DECIMAL(18,6)) AS ConversionFactor " &
                "FROM RawMaterials RM " &
                "INNER JOIN Units U ON RM.UnitID = U.UnitID " &
                "WHERE RM.MaterialID = @MaterialID " &
                "UNION ALL " &
                "SELECT U.UnitName, MU.ConversionFactor " &
                "FROM MaterialUnits MU " &
                "INNER JOIN Units U ON MU.UnitID = U.UnitID " &
                "WHERE MU.MaterialID = @MaterialID " &
                "ORDER BY ConversionFactor DESC"

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@MaterialID", SqlDbType.Int).Value = materialID
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Debug.WriteLine("GetMaterialUnitsForDisplay Error: " & ex.Message)
        End Try

        Return dt

    End Function

    ' =========================================================
    ' جلب الوحدة الأساسية
    ' =========================================================
    Private Function GetBaseUnitName(materialID As Integer) As String

        Try

            Using conn As New SqlConnection(DBModule.ConnectionString)
                Using cmd As New SqlCommand(
                    "SELECT U.UnitName FROM RawMaterials RM " &
                    "INNER JOIN Units U ON RM.UnitID = U.UnitID " &
                    "WHERE RM.MaterialID = @MaterialID",
                    conn
                )
                    cmd.Parameters.Add("@MaterialID", SqlDbType.Int).Value = materialID
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return result.ToString()
                    End If
                End Using
            End Using

        Catch ex As Exception
            Debug.WriteLine("GetBaseUnitName Error: " & ex.Message)
        End Try

        Return ""

    End Function

    ' =========================================================
    ' Load
    ' =========================================================
    Private Sub frmStoreStock_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        Try

            ' خيارات البحث
            cmbSearchField.Items.Clear()
            cmbSearchField.Items.AddRange(New Object() {
                "اسم الخامة",
                "المخزن",
                "الحالة"
            })
            cmbSearchField.SelectedIndex = 0

            FillDropdowns()
            LoadStockGrid()
            datagridviewsetup(dgvStock)

            Dim Drag As New FormDragHelper(Me, panelHeader)

        Catch ex As Exception
            MessageBox.Show(
                "خطأ أثناء فتح شاشة المخزون:" & Environment.NewLine & ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    ' =========================================================
    ' تغيير الفرع — يعيد تحميل الجريد
    ' =========================================================
    Private Sub cmbStore_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbStore.SelectedIndexChanged

        If _suppressEvents Then Exit Sub
        If cmbStore.SelectedIndex = -1 Then Exit Sub

        Try
            Dim storeID As Integer = Convert.ToInt32(cmbStore.SelectedValue)
            _cachedStock = Nothing
            LoadStockGrid(storeID)
        Catch ex As Exception
            Debug.WriteLine("Store selection change: " & ex.Message)
        End Try

    End Sub

    ' =========================================================
    ' البحث النصي
    ' =========================================================
    Private Sub txtSearch_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearch.TextChanged

        ApplySearch()

    End Sub

    ' =========================================================
    ' تغيير حقل البحث
    ' =========================================================
    Private Sub cmbSearchField_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbSearchField.SelectedIndexChanged

        ApplySearch()

    End Sub

    ' =========================================================
    ' Refresh
    ' =========================================================
    Private Sub btnRefresh_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRefresh.Click

        Try
            _hasUnitColumns = Nothing ' إعادة فحص الأعمدة في حال تم تطبيق سكربت SQL
            Dim storeID As Integer = If(cmbStore.SelectedIndex >= 0, Convert.ToInt32(cmbStore.SelectedValue), -1)
            _cachedStock = Nothing
            LoadStockGrid(storeID)
            ClearFields()
            txtSearch.Text = ""
        Catch ex As Exception
            MessageBox.Show(
                "خطأ أثناء التحديث:" & Environment.NewLine & ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    ' =========================================================
    ' تفريغ الحقول
    ' =========================================================
    Private Sub btnClearFields_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClearFields.Click

        ClearFields()

    End Sub

    ' =========================================================
    ' Close / Max / Min
    ' =========================================================
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

End Class