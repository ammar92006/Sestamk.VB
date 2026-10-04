Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace UC_Settings
    ''' <summary>
    ''' شاشة إعدادات المبيعات وسلوك الكاشير وأنواع الطلبات
    ''' </summary>
    Public Class UCSalesSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Async Sub UCSalesSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Await InitializeDataAsync()
            LoadSettings()
        End Sub

        Private Async Function InitializeDataAsync() As Task
            Try
                ' 1. ملء أنواع الطلبات
                Dim dtOrderTypes As New DataTable()
                dtOrderTypes.Columns.Add("TypeID", GetType(Integer))
                dtOrderTypes.Columns.Add("TypeName", GetType(String))
                dtOrderTypes.Rows.Add(1, "تيك أوي - سفري")
                dtOrderTypes.Rows.Add(2, "صالة")
                dtOrderTypes.Rows.Add(3, "دليفري - توصيل")

                cmbDefaultOrderType.DataSource = dtOrderTypes
                cmbDefaultOrderType.DisplayMember = "TypeName"
                cmbDefaultOrderType.ValueMember = "TypeID"

                ' 2. ملء الفروع والمخازن والعملاء والطيارين من POSRepository
                Try
                    Dim repo As New POSRepository(DBModule.ConnectionString)

                    Dim dtBranches = repo.GetActiveBranches()
                    cmbBranches.DataSource = dtBranches
                    cmbBranches.DisplayMember = "BranchName"
                    cmbBranches.ValueMember = "BranchID"
                    cmbBranches.SelectedIndex = -1

                    Dim dtStores = repo.GetActiveStores()
                    cmbStores.DataSource = dtStores
                    cmbStores.DisplayMember = "StoreName"
                    cmbStores.ValueMember = "StoreID"
                    cmbStores.SelectedIndex = -1

                    Dim customers = repo.GetActiveCustomers()
                    cmbDefaultCustomer.DataSource = customers
                    cmbDefaultCustomer.DisplayMember = "CustomerName"
                    cmbDefaultCustomer.ValueMember = "CustomerID"
                    cmbDefaultCustomer.SelectedIndex = -1

                    Dim drivers = repo.GetActiveDeliveryDrivers()
                    cmbDefaultDriver.DataSource = drivers
                    cmbDefaultDriver.DisplayMember = "DriverName"
                    cmbDefaultDriver.ValueMember = "DriverID"
                    cmbDefaultDriver.SelectedIndex = -1
                Catch ex As Exception
                    Debug.WriteLine("POSRepository load error: " & ex.Message)
                End Try

                ' 3. ملء الخزائن
                Await LoadTreasuriesAsync()
            Catch ex As Exception
                Debug.WriteLine("InitializeDataAsync: " & ex.Message)
            End Try
        End Function

        Private Async Function LoadTreasuriesAsync() As Task
            Try
                Dim dt As New DataTable()
                Using cn As SqlConnection = Await NewConnAsync()
                    Const sql As String = "
                        SELECT TreasuryID, TreasuryNameAr 
                        FROM Treasury 
                        WHERE IsActive = 1 AND IsDeleted = 0 
                        ORDER BY IsDefault DESC, TreasuryNameAr"

                    Using da As New SqlDataAdapter(sql, cn)
                        Await Task.Run(Sub() da.Fill(dt))
                    End Using
                End Using

                cmbTreasury.DataSource = dt
                cmbTreasury.DisplayMember = "TreasuryNameAr"
                cmbTreasury.ValueMember = "TreasuryID"
                cmbTreasury.SelectedIndex = -1
            Catch ex As Exception
                Debug.WriteLine("LoadTreasuriesAsync: " & ex.Message)
            End Try
        End Function

        Public Sub LoadSettings()
            Try
                ' أنواع الطلبات
                tglDineIn.Checked = SettingsManager.GetBoolSetting(SettingsKeys.SalesEnableDineIn, True)
                tglTakeaway.Checked = SettingsManager.GetBoolSetting(SettingsKeys.SalesEnableTakeaway, True)
                tglDelivery.Checked = SettingsManager.GetBoolSetting(SettingsKeys.SalesEnableDelivery, True)

                Dim defaultOrderTypeVal = SettingsManager.GetSettingOrDefault(SettingsKeys.DefaultOrderType, "1")
                Dim orderTypeId As Integer
                If Integer.TryParse(defaultOrderTypeVal, orderTypeId) Then
                    cmbDefaultOrderType.SelectedValue = orderTypeId
                End If

                ' الضرائب والخصومات
                tglEnableTax.Checked = SettingsManager.GetBoolSetting(SettingsKeys.EnableTax, True)
                txtTaxPercent.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.TaxPercent, "14")

                tglEnableDiscount.Checked = SettingsManager.GetBoolSetting(SettingsKeys.EnableDiscount, True)
                txtDiscountPercent.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.DefaultDiscountPercent, "0")

                txtDineInServiceFee.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.DineInServiceFee, "0")
                btnIsDineInServiceFeePercent.Checked = SettingsManager.GetBoolSetting(SettingsKeys.IsDineInServiceFeePercent, False)

                ' أصناف الفاتورة
                txtInvoiceItemsPerPage.Text = SettingsManager.GetSettingOrDefault(SettingsKeys.InvoiceItemsPerPage, "25")

                ' العميل والطيار والخزينة
                Dim defaultCust = SettingsManager.GetSetting(SettingsKeys.DefaultCustomerID)
                If Not String.IsNullOrEmpty(defaultCust) Then
                    Dim cid As Integer
                    If Integer.TryParse(defaultCust, cid) Then cmbDefaultCustomer.SelectedValue = cid
                End If

                Dim defaultDrv = SettingsManager.GetSetting(SettingsKeys.DefaultDriverID)
                If Not String.IsNullOrEmpty(defaultDrv) Then
                    Dim did As Integer
                    If Integer.TryParse(defaultDrv, did) Then cmbDefaultDriver.SelectedValue = did
                End If

                Dim defaultBr = SettingsManager.GetSetting(SettingsKeys.CurrentBranchID)
                If Not String.IsNullOrEmpty(defaultBr) Then
                    Dim bid As Integer
                    If Integer.TryParse(defaultBr, bid) Then cmbBranches.SelectedValue = bid
                End If

                Dim defaultSt = SettingsManager.GetSetting(SettingsKeys.CurrentStoreID)
                If Not String.IsNullOrEmpty(defaultSt) Then
                    Dim sid As Integer
                    If Integer.TryParse(defaultSt, sid) Then cmbStores.SelectedValue = sid
                End If

                Dim defaultTr = SettingsManager.GetSetting(SettingsKeys.DefaultTreasuryID)
                If Not String.IsNullOrEmpty(defaultTr) Then
                    Dim tid As Integer
                    If Integer.TryParse(defaultTr, tid) Then cmbTreasury.SelectedValue = tid
                End If

                ' الخيارات الافتراضية
                tglDeductIngredients.Checked = SettingsManager.GetBoolSetting(SettingsKeys.SalesDeductIngredients, True)

                ' طرق الدفع
                chkPaymentCash.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PaymentCash, True)
                chkPaymentVisa.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PaymentVisa, True)
                chkPaymentMaster.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PaymentMaster, True)
                chkPaymentMada.Checked = SettingsManager.GetBoolSetting(SettingsKeys.PaymentMada, True)
            Catch ex As Exception
                SmartMessageBox.Show("خطأ في قراءة إعدادات البيع: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Try
                ' حفظ أنواع الطلبات
                SettingsManager.SaveSetting(SettingsKeys.SalesEnableDineIn, tglDineIn.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.SalesEnableTakeaway, tglTakeaway.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.SalesEnableDelivery, tglDelivery.Checked.ToString().ToLower())

                If cmbDefaultOrderType.SelectedValue IsNot Nothing Then
                    SettingsManager.SaveSetting(SettingsKeys.DefaultOrderType, cmbDefaultOrderType.SelectedValue.ToString())
                End If

                ' حفظ الضرائب والخصم
                SettingsManager.SaveSetting(SettingsKeys.EnableTax, tglEnableTax.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.TaxPercent, txtTaxPercent.Text.Trim())

                SettingsManager.SaveSetting(SettingsKeys.EnableDiscount, tglEnableDiscount.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.DefaultDiscountPercent, txtDiscountPercent.Text.Trim())

                SettingsManager.SaveSetting(SettingsKeys.DineInServiceFee, txtDineInServiceFee.Text.Trim())
                SettingsManager.SaveSetting(SettingsKeys.IsDineInServiceFeePercent, btnIsDineInServiceFeePercent.Checked.ToString().ToLower())

                ' حفظ أصناف الفاتورة
                SettingsManager.SaveSetting(SettingsKeys.InvoiceItemsPerPage, txtInvoiceItemsPerPage.Text.Trim())

                ' حفظ الخيارات الافتراضية
                If cmbDefaultCustomer.SelectedValue IsNot Nothing Then
                    SettingsManager.SaveSetting(SettingsKeys.DefaultCustomerID, cmbDefaultCustomer.SelectedValue.ToString())
                End If
                If cmbDefaultDriver.SelectedValue IsNot Nothing Then
                    SettingsManager.SaveSetting(SettingsKeys.DefaultDriverID, cmbDefaultDriver.SelectedValue.ToString())
                End If
                If cmbBranches.SelectedValue IsNot Nothing Then
                    SettingsManager.SaveSetting(SettingsKeys.CurrentBranchID, cmbBranches.SelectedValue.ToString())
                End If
                If cmbStores.SelectedValue IsNot Nothing Then
                    SettingsManager.SaveSetting(SettingsKeys.CurrentStoreID, cmbStores.SelectedValue.ToString())
                End If
                If cmbTreasury.SelectedValue IsNot Nothing Then
                    SettingsManager.SaveSetting(SettingsKeys.DefaultTreasuryID, cmbTreasury.SelectedValue.ToString())
                End If

                ' حفظ خيار خصم الخامات من المخزن
                SettingsManager.SaveSetting(SettingsKeys.SalesDeductIngredients, tglDeductIngredients.Checked.ToString().ToLower())

                ' حفظ طرق الدفع
                SettingsManager.SaveSetting(SettingsKeys.PaymentCash, chkPaymentCash.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.PaymentVisa, chkPaymentVisa.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.PaymentMaster, chkPaymentMaster.Checked.ToString().ToLower())
                SettingsManager.SaveSetting(SettingsKeys.PaymentMada, chkPaymentMada.Checked.ToString().ToLower())

                Try
                    Notify.Toast("تم حفظ إعدادات البيع بنجاح ✅", Notify.ToastType.Success)
                Catch
                    SmartMessageBox.Show("✅ تم حفظ إعدادات البيع بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Catch ex As Exception
                SmartMessageBox.Show("خطأ في حفظ إعدادات البيع: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If SmartMessageBox.Show("هل أنت متأكد من استعادة القيم الافتراضية لإعدادات البيع؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                tglDineIn.Checked = True
                tglTakeaway.Checked = True
                tglDelivery.Checked = True
                tglEnableTax.Checked = True
                txtTaxPercent.Text = "14"
                tglEnableDiscount.Checked = True
                txtDiscountPercent.Text = "0"
                txtDineInServiceFee.Text = "0"
                btnIsDineInServiceFeePercent.Checked = False
                txtInvoiceItemsPerPage.Text = "25"
                tglDeductIngredients.Checked = True
                chkPaymentCash.Checked = True
                chkPaymentVisa.Checked = True
                chkPaymentMaster.Checked = True
                chkPaymentMada.Checked = True
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
