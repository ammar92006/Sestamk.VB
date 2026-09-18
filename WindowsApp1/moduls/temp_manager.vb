'==========================================
'📁 SalesManager.vb
'==========================================
Imports System.Data
Imports System.Data.SqlClient
Imports Guna.UI2.WinForms

Public Class temp_manager

    '==========================================
    '🔸 المتغيرات العامة
    '==========================================
    Private SelectedProductId As Integer = 0
    Private isFillingList As Boolean = False

    '==========================================
    '🔹 دالة مساعدة لإنشاء الاتصال
    '==========================================
    'Private Function CreateConnection() As SqlConnection
    '    Return New SqlConnection(ConnectionString)
    'End Function
    ' ==========================================
    ' [FIX] استبدال نمط Using Conn/Connect()/Disconnect() المربك
    '       بـ Using محلي صارم — لا تسرّب اتصالات + Timeout قصير
    '       لمنع التجمد عند الاستعلامات البطيئة.
    ' ==========================================

    ' ==========================================
    ' دالة لجلب بيانات منتج الميزان حسب الكود
    ' ==========================================
    Public Function GetScaleProductByCode(productCode As String) As DataTable
        Dim dt As New DataTable()
        Const query As String = "SELECT Code, Name , Price FROM TheScale WHERE Code = @Code"

        Try
            Using cn As SqlConnection = NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandTimeout = 15
                    cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = productCode

                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("خطأ أثناء جلب بيانات منتج الميزان: " & ex.Message,
                            "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function

    '==========================================
    '🔹 دالة جلب اقتراحات المنتج (بالاسم)
    '==========================================
    Public Function GetProductSuggestions(ByVal searchTerm As String) As DataTable
        Dim dt As New DataTable()
        Const query As String =
            "SELECT DISTINCT
                P.Product_ID,
                P.Product_Name,
                P.Product_Code
            FROM dbo.Products AS P
            LEFT JOIN dbo.ProductUnits AS PU ON P.Product_ID = PU.Product_ID
            WHERE
                (P.Product_Name LIKE '%' + @SearchTerm + '%')
            ORDER BY P.Product_Name;"

        Try
            Using cn As SqlConnection = NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandTimeout = 15
                    cmd.Parameters.AddWithValue("@SearchTerm", searchTerm)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("GetProductSuggestions error: " & ex.Message)
        End Try

        Return dt
    End Function

    Public Function GetProductSuggestionsbycode(ByVal searchTerm As String) As DataTable
        Dim dt As New DataTable()
        Const query As String =
            "SELECT DISTINCT
                P.Product_ID,
                P.Product_Name,
                P.Product_Code
            FROM dbo.Products AS P
            LEFT JOIN dbo.ProductUnits AS PU ON P.Product_ID = PU.Product_ID
            WHERE
                (P.Product_Code LIKE '%' + @SearchTerm + '%')
            ORDER BY P.Product_Name;"

        Try
            Using cn As SqlConnection = NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandTimeout = 15
                    cmd.Parameters.AddWithValue("@SearchTerm", searchTerm)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("GetProductSuggestionsbycode error: " & ex.Message)
        End Try

        Return dt
    End Function

    '==========================================
    '🔹 دالة جلب وحدات المنتج
    '==========================================
    Public Function GetProductUnits(ByVal productId As Integer) As DataTable
        Dim dt As New DataTable()
        Const query As String =
            "SELECT
                PU.ProductUnit_ID,
                PU.Product_ID,
                PU.Unit_Name,
                PU.Sale_Price,
                PU.Unit_Quantity,
                PU.Barcode
             FROM dbo.ProductUnits AS PU
             LEFT JOIN dbo.Products AS P ON P.Product_ID = PU.Product_ID
             WHERE PU.Product_ID = @PID
             ORDER BY Unit_Quantity ASC;"

        Try
            Using cn As SqlConnection = NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandTimeout = 15
                    cmd.Parameters.AddWithValue("@PID", productId)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء تحميل وحدات المنتج: " & ex.Message)
        End Try

        Return dt
    End Function

    Public Function GetProductUnits2(ByVal productId As Integer) As DataTable
        Dim dt As New DataTable()
        Const query As String =
            "SELECT
                PU.ProductUnit_ID,
                PU.Product_ID,
                PU.Unit_Name,
                PU.Purchase_Price,
                PU.Unit_Quantity,
                PU.Barcode
             FROM dbo.ProductUnits AS PU
             LEFT JOIN dbo.Products AS P ON P.Product_ID = PU.Product_ID
             WHERE PU.Product_ID = @PID
             ORDER BY Unit_Quantity ASC;"

        Try
            Using cn As SqlConnection = NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandTimeout = 15
                    cmd.Parameters.AddWithValue("@PID", productId)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء تحميل وحدات المنتج: " & ex.Message)
        End Try

        Return dt
    End Function

    '==========================================
    '🔹 تحميل وحدات المنتج وتحديد السعر الافتراضي
    '==========================================
    Public Sub LoadUnitsAndSetDefaultPrice(ByVal productId As Integer,
                                           ByVal cmbUnit As ComboBox,
                                           ByVal txtSalePrice As Guna2TextBox,
                                           ByRef CurrentSalePriceVar As Decimal,
                                           ByRef CurrentConversionFactorVar As Decimal)

        Try
            Dim dtUnits As DataTable = GetProductUnits(productId)

            cmbUnit.DataSource = dtUnits
            cmbUnit.DisplayMember = "Unit_Name"
            cmbUnit.ValueMember = "ProductUnit_ID"

            If dtUnits.Rows.Count > 0 Then
                Dim row As DataRow = dtUnits.Rows(0)
                cmbUnit.SelectedIndex = 0

                CurrentConversionFactorVar = Convert.ToDecimal(row("Unit_Quantity"))
                CurrentSalePriceVar = Convert.ToDecimal(row("Sale_Price"))
                txtSalePrice.Text = CurrentSalePriceVar.ToString("N2")
            Else
                CurrentConversionFactorVar = 0
                CurrentSalePriceVar = 0
                txtSalePrice.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ في تحميل وحدات المنتج: " & ex.Message)
        End Try
    End Sub
    Public Sub LoadUnitsAndSetDefaultPrice2(ByVal productId As Integer,
                                           ByVal cmbUnit As ComboBox,
                                           ByVal txtSalePrice As Guna2TextBox,
                                           ByRef CurrentSalePriceVar As Decimal,
                                           ByRef CurrentConversionFactorVar As Decimal)

        Try
            Dim dtUnits As DataTable = GetProductUnits2(productId)

            cmbUnit.DataSource = dtUnits
            cmbUnit.DisplayMember = "Unit_Name"
            cmbUnit.ValueMember = "ProductUnit_ID"

            If dtUnits.Rows.Count > 0 Then
                Dim row As DataRow = dtUnits.Rows(0)
                cmbUnit.SelectedIndex = 0

                CurrentConversionFactorVar = Convert.ToDecimal(row("Unit_Quantity"))
                CurrentSalePriceVar = Convert.ToDecimal(row("Purchase_Price"))
                txtSalePrice.Text = CurrentSalePriceVar.ToString("N2")
            Else
                CurrentConversionFactorVar = 0
                CurrentSalePriceVar = 0
                txtSalePrice.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ في تحميل وحدات المنتج: " & ex.Message)
        End Try
    End Sub

    '==========================================
    '🔹 تحديد السعر ومعامل التحويل
    '==========================================
    Public Sub SetPriceAndFactor(ByVal selectedRow As DataRow,
                                 ByVal txtSalePrice As Guna2TextBox,
                                 ByRef CurrentConversionFactorVar As Decimal,
                                 ByRef CurrentSalePriceVar As Decimal,
                                 ByRef CurrentUnitIDVar As Integer)

        Try
            CurrentConversionFactorVar = Convert.ToDecimal(selectedRow("Unit_Quantity"))
            CurrentSalePriceVar = Convert.ToDecimal(selectedRow("Sale_Price"))
            CurrentUnitIDVar = Convert.ToInt32(selectedRow("ProductUnit_ID"))

            txtSalePrice.Text = CurrentSalePriceVar.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("⚠️ 
السعر ومعامل التحويل: " & ex.Message)
        End Try
    End Sub
    Public Sub SetPriceAndFactor2(ByVal selectedRow As DataRow,
                                 ByVal txtSalePrice As Guna2TextBox,
                                 ByRef CurrentConversionFactorVar As Decimal,
                                 ByRef CurrentSalePriceVar As Decimal,
                                 ByRef CurrentUnitIDVar As Integer)

        Try
            CurrentConversionFactorVar = Convert.ToDecimal(selectedRow("Unit_Quantity"))
            CurrentSalePriceVar = Convert.ToDecimal(selectedRow("Purchase_Price"))
            CurrentUnitIDVar = Convert.ToInt32(selectedRow("ProductUnit_ID"))

            txtSalePrice.Text = CurrentSalePriceVar.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("⚠️ 
السعر ومعامل التحويل: " & ex.Message)
        End Try
    End Sub

    '==========================================
    '🔹 حدث تغيير الوحدة
    '==========================================
    Public Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs,
                                            ByVal txtQuantity As Guna2TextBox,
                                            ByVal txtTotalProduct As Guna2TextBox,
                                            ByVal txtSalePrice As Guna2TextBox,
                                            ByRef CurrentConversionFactorVar As Decimal,
                                            ByRef CurrentSalePriceVar As Decimal,
                                            ByRef CurrentUnitIDVar As Integer)

        Dim cmbUnit As ComboBox = CType(sender, ComboBox)

        If cmbUnit.SelectedItem Is Nothing Then
            txtSalePrice.Clear()
            txtTotalProduct.Clear()
            CurrentSalePriceVar = 0D
            CurrentConversionFactorVar = 0D
            CurrentUnitIDVar = 0
            Exit Sub
        End If

        Try
            Dim drv As DataRowView = CType(cmbUnit.SelectedItem, DataRowView)
            SetPriceAndFactor(drv.Row, txtSalePrice, CurrentConversionFactorVar, CurrentSalePriceVar, CurrentUnitIDVar)

            If IsNumeric(txtQuantity.Text) AndAlso CurrentSalePriceVar > 0 Then
                Dim total = Convert.ToDecimal(txtQuantity.Text) * CurrentSalePriceVar
                txtTotalProduct.Text = total.ToString("N2")
            Else
                txtTotalProduct.Text = "0.00"
            End If

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء تغيير الوحدة: " & ex.Message)
        End Try
    End Sub
    Public Sub cmbUnit_SelectedIndexChanged2(sender As Object, e As EventArgs,
                                            ByVal txtQuantity As Guna2TextBox,
                                            ByVal txtTotalProduct As Guna2TextBox,
                                            ByVal txtSalePrice As Guna2TextBox,
                                            ByRef CurrentConversionFactorVar As Decimal,
                                            ByRef CurrentSalePriceVar As Decimal,
                                            ByRef CurrentUnitIDVar As Integer)

        Dim cmbUnit As ComboBox = CType(sender, ComboBox)

        If cmbUnit.SelectedItem Is Nothing Then
            txtSalePrice.Clear()
            txtTotalProduct.Clear()
            CurrentSalePriceVar = 0D
            CurrentConversionFactorVar = 0D
            CurrentUnitIDVar = 0
            Exit Sub
        End If

        Try
            Dim drv As DataRowView = CType(cmbUnit.SelectedItem, DataRowView)
            SetPriceAndFactor2(drv.Row, txtSalePrice, CurrentConversionFactorVar, CurrentSalePriceVar, CurrentUnitIDVar)

            If IsNumeric(txtQuantity.Text) AndAlso CurrentSalePriceVar > 0 Then
                Dim total = Convert.ToDecimal(txtQuantity.Text) * CurrentSalePriceVar
                txtTotalProduct.Text = total.ToString("N2")
            Else
                txtTotalProduct.Text = "0.00"
            End If

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء تغيير الوحدة: " & ex.Message)
        End Try
    End Sub

    '==========================================
    '🔹 حدث البحث بالكود
    '==========================================
    Public Sub txtProductCodeSearch_TextChanged(sender As Object, e As EventArgs, ByVal lstProductSuggestions As ListBox)
        Dim txtBox As Guna2TextBox = CType(sender, Guna2TextBox)
        Dim searchTerm As String = txtBox.Text.Trim()

        If searchTerm.Length < 1 Then
            lstProductSuggestions.Visible = False
            Exit Sub
        End If

        Try
            isFillingList = True
            Dim resultsTable As DataTable = GetProductSuggestionsbycode(searchTerm)
            lstProductSuggestions.DataSource = resultsTable
            lstProductSuggestions.DisplayMember = "Product_Name"
            lstProductSuggestions.ValueMember = "Product_ID"
            lstProductSuggestions.Visible = (resultsTable.Rows.Count > 0)
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء البحث بالكود: " & ex.Message)
        Finally
            isFillingList = False
        End Try
    End Sub

    '==========================================
    '🔹 حدث البحث بالاسم
    '==========================================
    Public Sub txtProductNameSearch_TextChanged(sender As Object, e As EventArgs, ByVal lstProductSuggestions As ListBox)
        Dim txtBox As Guna2TextBox = CType(sender, Guna2TextBox)
        Dim searchTerm As String = txtBox.Text.Trim()
        txtBox.AutoCompleteMode = AutoCompleteMode.None
        txtBox.AutoCompleteSource = AutoCompleteSource.None

        If searchTerm.Length < 1 Then
            lstProductSuggestions.Visible = False
            Exit Sub
        End If

        Try
            isFillingList = True
            Dim resultsTable As DataTable = GetProductSuggestions(searchTerm)
            lstProductSuggestions.DataSource = resultsTable
            lstProductSuggestions.DisplayMember = "Product_Name"
            lstProductSuggestions.ValueMember = "Product_ID"
            ' ⛔ منع الاختيار التلقائي
            lstProductSuggestions.ClearSelected()
            lstProductSuggestions.Visible = (resultsTable.Rows.Count > 0)
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء البحث بالاسم: " & ex.Message)
        Finally
            isFillingList = False
        End Try
    End Sub
    Public Sub txtProductNameSearch_TextChanged2(sender As Object, e As EventArgs, ByVal lstProductSuggestions As ListBox)
        Dim txtBox As Guna2TextBox = CType(sender, Guna2TextBox)
        Dim searchTerm As String = txtBox.Text.Trim()
        txtBox.AutoCompleteMode = AutoCompleteMode.None
        txtBox.AutoCompleteSource = AutoCompleteSource.None

        If searchTerm.Length < 1 Then
            lstProductSuggestions.Visible = False
            Exit Sub
        End If

        Try
            isFillingList = True
            Dim resultsTable As DataTable = GetProductSuggestions(searchTerm)
            lstProductSuggestions.DataSource = resultsTable
            lstProductSuggestions.DisplayMember = "Product_Name"
            lstProductSuggestions.ValueMember = "Product_ID"
            ' ⛔ منع الاختيار التلقائي
            lstProductSuggestions.ClearSelected()
            lstProductSuggestions.Visible = (resultsTable.Rows.Count > 0)
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء البحث بالاسم: " & ex.Message)
        Finally
            isFillingList = False
        End Try
    End Sub

    '==========================================
    '🔹 عند اختيار منتج من نتائج البحث بالكود
    '==========================================
    Public Sub lstCodeSuggestions_SelectedIndexChanged(sender As Object, e As EventArgs,
                                                       ByVal txtProduct_ID As Guna2TextBox,
                                                       ByVal txtProductCode As Guna2TextBox,
                                                       ByVal txtProductName As Guna2TextBox,
                                                       ByVal cmbUnit As ComboBox,
                                                       ByVal txtSalePrice As Guna2TextBox,
                                                       ByVal txtQuantity As Guna2TextBox)

        Dim lstBox As ListBox = CType(sender, ListBox)
        If lstBox.SelectedIndex = -1 Then Exit Sub

        Try
            Dim drv As DataRowView = CType(lstBox.SelectedItem, DataRowView)
            SelectedProductId = Convert.ToInt32(drv("Product_ID"))

            txtProduct_ID.Text = drv("Product_ID").ToString()
            txtProductCode.Text = drv("Product_Code").ToString()
            txtProductName.Text = drv("Product_Name").ToString()
            lstBox.Visible = False
            Dim tempSalePrice As Decimal = 0
            Dim tempConversionFactor As Decimal = 0
            LoadUnitsAndSetDefaultPrice(SelectedProductId, cmbUnit, txtSalePrice,
                                        tempSalePrice, tempConversionFactor)

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ عند اختيار المنتج بالكود: " & ex.Message)
        End Try
    End Sub

    '==========================================
    '🔹 عند اختيار منتج من نتائج البحث بالاسم
    '==========================================
    Public Sub lstNameSuggestions_SelectedIndexChanged(sender As Object, e As EventArgs,
                                                       ByVal txtProductName As Guna2TextBox,
                                                       ByRef SelectedProductId As Integer,
                                                       ByVal lstBox2 As ListBox,
                                                       ByVal txtProductCode As Guna2TextBox,
                                                       ByVal cmbUnit As ComboBox,
                                                       ByVal txtSalePrice As Guna2TextBox,
                                                       ByVal txtQuantity As Guna2TextBox)


        If isFillingList Then
            Exit Sub  ' ⛔ امنع التشغيل التلقائي
        End If
        Dim lstBox As ListBox = CType(sender, ListBox)
        If lstBox.SelectedIndex = -1 Then Exit Sub

        Try
            Dim drv As DataRowView = CType(lstBox.SelectedItem, DataRowView)
            SelectedProductId = Convert.ToInt32(drv("Product_ID"))

            txtProductName.Text = drv("Product_Name").ToString()
            txtProductCode.Text = drv("Product_Code").ToString()
            lstBox.Visible = False
            lstBox2.Visible = False

            Dim tempSalePrice2 As Decimal = 0
            Dim tempConversionFactor2 As Decimal = 0
            LoadUnitsAndSetDefaultPrice(SelectedProductId, cmbUnit, txtSalePrice,
                                        tempSalePrice2, tempConversionFactor2)

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ عند اختيار المنتج بالاسم: " & ex.Message)
        Finally
            txtQuantity.Focus()
        End Try
    End Sub
    Public Sub lstNameSuggestions_SelectedIndexChanged2(sender As Object, e As EventArgs,
                                                       ByVal txtProductName As Guna2TextBox,
                                                       ByRef SelectedProductId As Integer,
                                                       ByVal lstBox2 As ListBox,
                                                       ByVal txtProductCode As Guna2TextBox,
                                                       ByVal cmbUnit As ComboBox,
                                                       ByVal txtSalePrice As Guna2TextBox,
                                                       ByVal txtQuantity As Guna2TextBox)


        If isFillingList Then
            Exit Sub  ' ⛔ امنع التشغيل التلقائي
        End If
        Dim lstBox As ListBox = CType(sender, ListBox)
        If lstBox.SelectedIndex = -1 Then Exit Sub

        Try
            Dim drv As DataRowView = CType(lstBox.SelectedItem, DataRowView)
            SelectedProductId = Convert.ToInt32(drv("Product_ID"))

            txtProductName.Text = drv("Product_Name").ToString()
            txtProductCode.Text = drv("Product_Code").ToString()
            lstBox.Visible = False
            lstBox2.Visible = False
            Dim tempSalePrice3 As Decimal = 0
            Dim tempConversionFactor3 As Decimal = 0
            LoadUnitsAndSetDefaultPrice2(SelectedProductId, cmbUnit, txtSalePrice,
                                         tempSalePrice3, tempConversionFactor3)

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ عند اختيار المنتج بالاسم: " & ex.Message)
        Finally
            txtQuantity.Focus()
        End Try
    End Sub

    'Public Sub lstNameSuggestions_SelectedIndexChanged(sender As Object, e As EventArgs,
    '                                               txtProductName As Guna2TextBox,
    '                                               txtProductCode As Guna2TextBox,
    '                                               cmbUnit As ComboBox,
    '                                               txtSalePrice As Guna2TextBox,
    '                                               txtQuantity As Guna2TextBox)

    '    Dim lstBox As ListBox = CType(sender, ListBox)
    '    If lstBox.SelectedIndex = -1 Then Exit Sub

    '    Try
    '        Dim drv As DataRowView = CType(lstBox.SelectedItem, DataRowView)

    '        SelectedProductId = Convert.ToInt32(drv("Product_ID"))
    '        txtProductName.Text = drv("Product_Name").ToString()
    '        txtProductCode.Text = drv("Product_Code").ToString()

    '        lstBox.Visible = False

    '        Dim sales As New Sales
    '        LoadUnitsAndSetDefaultPrice(SelectedProductId, cmbUnit, txtSalePrice,
    '                                sales.CurrentSalePrice, sales.CurrentConversionFactor)

    '    Catch ex As Exception
    '        MessageBox.Show("⚠️ خطأ عند اختيار المنتج بالاسم: " & ex.Message)
    '    End Try
    'End Sub




    '==========================================
    '🔹 التحقق من توفر المخزون
    '==========================================
    Public Function CheckStockAvailability(ByVal productId As Integer,
                                       ByVal requiredQuantity As Integer,
                                       ByVal conversionFactor As Decimal) As Decimal

        Dim currentStock As Decimal = 0D
        Const query As String = "SELECT Quantity_OnHand FROM dbo.Stock WHERE Product_ID = @PID;"

        Try
            Using cn As SqlConnection = NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandTimeout = 15
                    cmd.Parameters.AddWithValue("@PID", productId)

                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        currentStock = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء فحص المخزون: " & ex.Message)
        End Try

        Return currentStock - (requiredQuantity * conversionFactor)
    End Function


    '==========================================
    '🔹 جلب الوحدة من الباركود
    '==========================================
    Public Function GetUnitByBarcode(ByVal barcode As String) As DataTable
        Dim dt As New DataTable()
        Const query As String =
            "SELECT TOP 1
                PU.ProductUnit_ID,
                PU.Product_ID,
                PU.Unit_Quantity,
                PU.Sale_Price,
                PU.Unit_Name,
                P.Product_Name,
                P.Product_Code
             FROM ProductUnits AS PU
             INNER JOIN dbo.Products AS P ON PU.Product_ID = P.Product_ID
             WHERE PU.Barcode = @Barcode;"

        Try
            Using cn As SqlConnection = NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandTimeout = 10
                    cmd.Parameters.AddWithValue("@Barcode", barcode)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء البحث بالباركود: " & ex.Message)
        End Try

        Return dt
    End Function

    Public Function GetUnitByBarcode2(ByVal barcode As String) As DataTable
        Dim dt As New DataTable()
        Const query As String =
            "SELECT TOP 1
                PU.ProductUnit_ID,
                PU.Product_ID,
                PU.Unit_Quantity,
                PU.Purchase_Price,
                PU.Unit_Name,
                P.Product_Name,
                P.Product_Code
             FROM ProductUnits AS PU
             INNER JOIN dbo.Products AS P ON PU.Product_ID = P.Product_ID
             WHERE PU.Barcode = @Barcode;"

        Try
            Using cn As SqlConnection = NewConn()
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandTimeout = 10
                    cmd.Parameters.AddWithValue("@Barcode", barcode)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء البحث بالباركود: " & ex.Message)
        End Try

        Return dt
    End Function

End Class
