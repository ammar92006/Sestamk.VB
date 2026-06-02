'==========================================
'📁 SalesManager.vb
'==========================================
Imports System.Data
Imports System.Data.SqlClient
Imports Guna.UI2.WinForms

Public Class SalesManager

    '══════════════════════════════════════════════════════════════
    ' متغيرات الكلاس
    '══════════════════════════════════════════════════════════════
    ' [إصلاح حيوي]: حذف isFillingList ووضعها كمتغير Instance بدلاً من
    '  Shared لمنع تعارض النسخ المتعددة إذا وُجدت.
    Private _isFillingList As Boolean = False

    '══════════════════════════════════════════════════════════════
    ' دالة مساعدة لإنشاء الاتصال
    ' [إصلاح جوهري]: بدلاً من الاعتماد على Conn العالمي مع Connect/Disconnect
    '  التي تسبب مشاكل Threading و Connection Leaks,
    '  كل دالة تنشئ connectionها الخاص داخل Using ← أكثر أماناً.
    '══════════════════════════════════════════════════════════════
    Private Function CreateConnection() As SqlConnection
        Dim cn As New SqlConnection(ConnectionString)
        cn.Open()
        Return cn
    End Function

    '══════════════════════════════════════════════════════════════
    ' دالة لجلب بيانات منتج الميزان حسب الكود
    ' [إصلاح]: استبدال Using Conn (خاطئ) بـ Using CreateConnection()
    '══════════════════════════════════════════════════════════════
    Public Function GetScaleProductByCode(productCode As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            Using cn = CreateConnection()
                Using cmd As New SqlCommand(
                    "SELECT Code, Name, Price FROM TheScale WHERE Code = @Code", cn)
                    ' [الأمان]: SqlDbType.Int يمنع SQL Injection للكود الرقمي
                    cmd.Parameters.Add("@Code", SqlDbType.Int).Value = productCode
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

    '══════════════════════════════════════════════════════════════
    ' دوال جلب اقتراحات المنتج
    ' [إصلاح]: إزالة Using Conn الخاطئة التي كانت تتلف الاتصال العالمي
    '══════════════════════════════════════════════════════════════
    Public Function GetProductSuggestions(ByVal searchTerm As String) As DataTable
        Dim dt As New DataTable()
        Const query As String =
            "SELECT DISTINCT
                P.Product_ID,
                P.Product_Name,
                P.Product_Code
             FROM dbo.Products AS P
             LEFT JOIN dbo.ProductUnits AS PU ON P.Product_ID = PU.Product_ID
             WHERE P.Product_Name LIKE '%' + @SearchTerm + '%'
             ORDER BY P.Product_Name;"
        Try
            Using cn = CreateConnection()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@SearchTerm", SqlDbType.NVarChar, 200).Value = searchTerm
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء جلب اقتراحات المنتج: " & ex.Message)
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
             WHERE P.Product_Code LIKE '%' + @SearchTerm + '%'
             ORDER BY P.Product_Name;"
        Try
            Using cn = CreateConnection()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@SearchTerm", SqlDbType.NVarChar, 200).Value = searchTerm
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء جلب اقتراحات المنتج بالكود: " & ex.Message)
        End Try
        Return dt
    End Function

    '══════════════════════════════════════════════════════════════
    ' دوال جلب وحدات المنتج
    '══════════════════════════════════════════════════════════════
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
            Using cn = CreateConnection()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@PID", SqlDbType.Int).Value = productId
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

    ' نسخة لجلب سعر الشراء (للمرتجعات وصفحات المشتريات)
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
            Using cn = CreateConnection()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@PID", SqlDbType.Int).Value = productId
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء تحميل وحدات المنتج (سعر الشراء): " & ex.Message)
        End Try
        Return dt
    End Function

    '══════════════════════════════════════════════════════════════
    ' تحميل وحدات المنتج وتحديد السعر الافتراضي
    ' [إصلاح حيوي]: إزالة "Dim sales As New Sales" التي كانت تنشئ
    '  نسخة جديدة من الفورم وتحدّث متغيراتها بدلاً من متغيرات الفورم الفعلي!
    '  الآن نمرر CurrentSalePrice, CurrentConversionFactor ByRef مباشرة.
    '══════════════════════════════════════════════════════════════
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

    ' نسخة لسعر الشراء (للمرتجعات وصفحات المشتريات)
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
            MessageBox.Show("⚠️ خطأ في تحميل وحدات المنتج (سعر الشراء): " & ex.Message)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' تحديد السعر ومعامل التحويل
    '══════════════════════════════════════════════════════════════
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
            MessageBox.Show("⚠️ خطأ في تحديد السعر ومعامل التحويل: " & ex.Message)
        End Try
    End Sub

    ' نسخة لسعر الشراء
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
            MessageBox.Show("⚠️ خطأ في تحديد سعر الشراء ومعامل التحويل: " & ex.Message)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' حدث تغيير الوحدة
    ' [إصلاح]: الآن يقبل ByRef للمتغيرات من الفورم الفعلي
    '══════════════════════════════════════════════════════════════
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
            SetPriceAndFactor(drv.Row, txtSalePrice, CurrentConversionFactorVar,
                              CurrentSalePriceVar, CurrentUnitIDVar)

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

    ' نسخة لسعر الشراء
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
            SetPriceAndFactor2(drv.Row, txtSalePrice, CurrentConversionFactorVar,
                               CurrentSalePriceVar, CurrentUnitIDVar)

            If IsNumeric(txtQuantity.Text) AndAlso CurrentSalePriceVar > 0 Then
                Dim total = Convert.ToDecimal(txtQuantity.Text) * CurrentSalePriceVar
                txtTotalProduct.Text = total.ToString("N2")
            Else
                txtTotalProduct.Text = "0.00"
            End If

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء تغيير الوحدة (سعر الشراء): " & ex.Message)
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' حدث البحث بالكود
    '══════════════════════════════════════════════════════════════
    Public Sub txtProductCodeSearch_TextChanged(sender As Object, e As EventArgs,
                                                ByVal lstProductSuggestions As ListBox)
        Dim txtBox As Guna2TextBox = CType(sender, Guna2TextBox)
        Dim searchTerm As String = txtBox.Text.Trim()

        If searchTerm.Length < 1 Then
            lstProductSuggestions.Visible = False
            Return
        End If

        Try
            _isFillingList = True
            Dim resultsTable As DataTable = GetProductSuggestionsbycode(searchTerm)
            lstProductSuggestions.DataSource = resultsTable
            lstProductSuggestions.DisplayMember = "Product_Name"
            lstProductSuggestions.ValueMember = "Product_ID"
            lstProductSuggestions.Visible = (resultsTable.Rows.Count > 0)
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء البحث بالكود: " & ex.Message)
        Finally
            _isFillingList = False
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' حدث البحث بالاسم
    '══════════════════════════════════════════════════════════════
    Public Sub txtProductNameSearch_TextChanged(sender As Object, e As EventArgs,
                                                ByVal lstProductSuggestions As ListBox)
        Dim txtBox As Guna2TextBox = CType(sender, Guna2TextBox)
        Dim searchTerm As String = txtBox.Text.Trim()
        txtBox.AutoCompleteMode = AutoCompleteMode.None
        txtBox.AutoCompleteSource = AutoCompleteSource.None

        If searchTerm.Length < 1 Then
            lstProductSuggestions.Visible = False
            Return
        End If

        Try
            _isFillingList = True
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
            _isFillingList = False
        End Try
    End Sub

    ' نسخة ثانية للبحث بالاسم (محافظ على الوظيفة الأصلية)
    Public Sub txtProductNameSearch_TextChanged2(sender As Object, e As EventArgs,
                                                 ByVal lstProductSuggestions As ListBox)
        Dim txtBox As Guna2TextBox = CType(sender, Guna2TextBox)
        Dim searchTerm As String = txtBox.Text.Trim()
        txtBox.AutoCompleteMode = AutoCompleteMode.None
        txtBox.AutoCompleteSource = AutoCompleteSource.None

        If searchTerm.Length < 1 Then
            lstProductSuggestions.Visible = False
            Return
        End If

        Try
            _isFillingList = True
            Dim resultsTable As DataTable = GetProductSuggestions(searchTerm)
            lstProductSuggestions.DataSource = resultsTable
            lstProductSuggestions.DisplayMember = "Product_Name"
            lstProductSuggestions.ValueMember = "Product_ID"
            lstProductSuggestions.ClearSelected()
            lstProductSuggestions.Visible = (resultsTable.Rows.Count > 0)
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء البحث بالاسم (2): " & ex.Message)
        Finally
            _isFillingList = False
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' عند اختيار منتج من نتائج البحث بالكود
    ' [إصلاح حيوي]: إزالة "Dim sales As New Sales" وتمرير
    '  CurrentSalePrice, CurrentConversionFactor, CurrentUnitID ByRef
    '══════════════════════════════════════════════════════════════
    Public Sub lstCodeSuggestions_SelectedIndexChanged(sender As Object, e As EventArgs,
                                                       ByVal txtProductName As Guna2TextBox,
                                                       ByRef SelectedProductIdVar As Integer,
                                                       ByVal lstBox2 As ListBox,
                                                       ByVal txtProductCode As Guna2TextBox,
                                                       ByVal cmbUnit As ComboBox,
                                                       ByVal txtSalePrice As Guna2TextBox,
                                                       ByVal txtQuantity As Guna2TextBox,
                                                       ByRef CurrentSalePriceVar As Decimal,
                                                       ByRef CurrentConversionFactorVar As Decimal,
                                                       ByRef CurrentUnitIDVar As Integer)

        If _isFillingList Then Return
        Dim lstBox As ListBox = CType(sender, ListBox)
        If lstBox.SelectedIndex = -1 Then Return

        Try
            Dim drv As DataRowView = CType(lstBox.SelectedItem, DataRowView)
            SelectedProductIdVar = Convert.ToInt32(drv("Product_ID"))

            txtProductCode.Text = drv("Product_Code").ToString()
            txtProductName.Text = drv("Product_Name").ToString()
            lstBox.Visible = False
            If lstBox2 IsNot Nothing Then lstBox2.Visible = False

            ' [إصلاح]: تمرير متغيرات الفورم الفعلي ByRef ← تُحدَّث مباشرة
            LoadUnitsAndSetDefaultPrice(SelectedProductIdVar, cmbUnit, txtSalePrice,
                                        CurrentSalePriceVar, CurrentConversionFactorVar)

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ عند اختيار المنتج بالكود: " & ex.Message)
        Finally
            txtQuantity.Focus()
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' عند اختيار منتج من نتائج البحث بالاسم
    ' [إصلاح حيوي]: إزالة "Dim sales As New Sales" التي كانت
    '  تنشئ فورم Sales جديد وهمي وتحدّث متغيراته الخاصة لا متغيرات
    '  الفورم الفعلي المفتوح! هذا كان يمنع تحديث CurrentSalePrice
    '  و CurrentConversionFactor بشكل كامل.
    '══════════════════════════════════════════════════════════════
    Public Sub lstNameSuggestions_SelectedIndexChanged(sender As Object, e As EventArgs,
                                                       ByVal txtProductName As Guna2TextBox,
                                                       ByRef SelectedProductIdVar As Integer,
                                                       ByVal lstBox2 As ListBox,
                                                       ByVal txtProductCode As Guna2TextBox,
                                                       ByVal cmbUnit As ComboBox,
                                                       ByVal txtSalePrice As Guna2TextBox,
                                                       ByVal txtQuantity As Guna2TextBox,
                                                       ByRef CurrentSalePriceVar As Decimal,
                                                       ByRef CurrentConversionFactorVar As Decimal,
                                                       ByRef CurrentUnitIDVar As Integer)

        ' ⛔ منع التشغيل التلقائي أثناء ملء القائمة
        If _isFillingList Then Return

        Dim lstBox As ListBox = CType(sender, ListBox)
        If lstBox.SelectedIndex = -1 Then Return

        Try
            Dim drv As DataRowView = CType(lstBox.SelectedItem, DataRowView)
            SelectedProductIdVar = Convert.ToInt32(drv("Product_ID"))

            txtProductName.Text = drv("Product_Name").ToString()
            txtProductCode.Text = drv("Product_Code").ToString()
            lstBox.Visible = False
            If lstBox2 IsNot Nothing Then lstBox2.Visible = False

            ' [إصلاح]: تمرير متغيرات الفورم الفعلي ByRef ← تُحدَّث مباشرة
            LoadUnitsAndSetDefaultPrice(SelectedProductIdVar, cmbUnit, txtSalePrice,
                                        CurrentSalePriceVar, CurrentConversionFactorVar)

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ عند اختيار المنتج بالاسم: " & ex.Message)
        Finally
            txtQuantity.Focus()
        End Try
    End Sub

    ' نسخة لسعر الشراء
    Public Sub lstNameSuggestions_SelectedIndexChanged2(sender As Object, e As EventArgs,
                                                        ByVal txtProductName As Guna2TextBox,
                                                        ByRef SelectedProductIdVar As Integer,
                                                        ByVal lstBox2 As ListBox,
                                                        ByVal txtProductCode As Guna2TextBox,
                                                        ByVal cmbUnit As ComboBox,
                                                        ByVal txtSalePrice As Guna2TextBox,
                                                        ByVal txtQuantity As Guna2TextBox,
                                                        ByRef CurrentSalePriceVar As Decimal,
                                                        ByRef CurrentConversionFactorVar As Decimal,
                                                        ByRef CurrentUnitIDVar As Integer)

        If _isFillingList Then Return
        Dim lstBox As ListBox = CType(sender, ListBox)
        If lstBox.SelectedIndex = -1 Then Return

        Try
            Dim drv As DataRowView = CType(lstBox.SelectedItem, DataRowView)
            SelectedProductIdVar = Convert.ToInt32(drv("Product_ID"))

            txtProductName.Text = drv("Product_Name").ToString()
            txtProductCode.Text = drv("Product_Code").ToString()
            lstBox.Visible = False
            If lstBox2 IsNot Nothing Then lstBox2.Visible = False

            ' [إصلاح]: تمرير متغيرات الفورم الفعلي ByRef ← تُحدَّث مباشرة
            LoadUnitsAndSetDefaultPrice2(SelectedProductIdVar, cmbUnit, txtSalePrice,
                                         CurrentSalePriceVar, CurrentConversionFactorVar)

        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ عند اختيار المنتج بالاسم (سعر الشراء): " & ex.Message)
        Finally
            txtQuantity.Focus()
        End Try
    End Sub

    '══════════════════════════════════════════════════════════════
    ' التحقق من توفر المخزون
    ' [تحسين]: إزالة Connect()/Disconnect() واستبدالها بـ Using
    '══════════════════════════════════════════════════════════════
    Public Function CheckStockAvailability(ByVal productId As Integer,
                                           ByVal requiredQuantity As Integer,
                                           ByVal conversionFactor As Decimal) As Decimal
        Dim currentStock As Decimal = 0D
        Const query As String = "SELECT Quantity_OnHand FROM dbo.Stock WHERE Product_ID = @PID;"
        Try
            Using cn = CreateConnection()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@PID", SqlDbType.Int).Value = productId
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        currentStock = Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء فحص المخزون: " & ex.Message)
        End Try
        Return currentStock - (requiredQuantity * conversionFactor)
    End Function

    '══════════════════════════════════════════════════════════════
    ' جلب الوحدة من الباركود
    ' [إصلاح]: إزالة Using Conn الخاطئة
    '══════════════════════════════════════════════════════════════
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
            Using cn = CreateConnection()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = barcode
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

    ' نسخة لسعر الشراء
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
            Using cn = CreateConnection()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = barcode
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("⚠️ خطأ أثناء البحث بالباركود (سعر الشراء): " & ex.Message)
        End Try
        Return dt
    End Function

End Class