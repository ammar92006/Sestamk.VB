Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmDriverReport

    Private ReadOnly _repo As POSRepository

    Public Sub New()
        InitializeComponent()
        _repo = New POSRepository(DBModule.ConnectionString)
    End Sub

    Private Sub FrmDriverReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now

        LoadDriversDropdown()

        cmbStatus.Items.Clear()
        cmbStatus.Items.AddRange(New Object() {"الكل", "معلق طرف الطيار", "تمت التصفية"})
        cmbStatus.SelectedIndex = 0

        datagridviewsetup(dgvDriverReport)
        SetupGrid()
        FilterData()

        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
    End Sub

    Private Sub LoadDriversDropdown()
        Dim drivers = _repo.GetActiveDeliveryDrivers()

        ' إضافة خيار "كل الطيارين"
        Dim dtDrivers As New DataTable()
        dtDrivers.Columns.Add("DriverID", GetType(Integer))
        dtDrivers.Columns.Add("DriverName", GetType(String))

        dtDrivers.Rows.Add(0, "--- كل الطيارين ---")
        For Each d In drivers
            dtDrivers.Rows.Add(d.DriverID, d.DriverName)
        Next

        cmbDrivers.DataSource = dtDrivers
        cmbDrivers.DisplayMember = "DriverName"
        cmbDrivers.ValueMember = "DriverID"
        cmbDrivers.SelectedIndex = 0
    End Sub

    ' تم نقل تعريف وتنسيق الأعمدة إلى الديزاينر FrmDriverReport.Designer.vb
    Private Sub SetupGrid()
        dgvDriverReport.AutoGenerateColumns = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FilterData()
    End Sub

    Private Sub FilterData()
        Dim driverID As Integer = If(cmbDrivers.SelectedValue IsNot Nothing, Convert.ToInt32(cmbDrivers.SelectedValue), 0)

        Dim isSettledParam As Integer = -1
        If cmbStatus.SelectedIndex = 1 Then isSettledParam = 0 ' معلق
        If cmbStatus.SelectedIndex = 2 Then isSettledParam = 1 ' تمت التصفية

        Dim dt As DataTable = _repo.GetDriverTransactionsReport(driverID, dtpFrom.Value, dtpTo.Value, isSettledParam)
        dgvDriverReport.DataSource = dt

        ' تجميع ملخص حسابات الطيار
        Dim totalOrdersCount As Integer = dt.Rows.Count
        Dim totalCashOrders As Decimal = 0
        Dim totalDeliveryFees As Decimal = 0

        For Each row As DataRow In dt.Rows
            totalCashOrders += Convert.ToDecimal(row("OrderTotal"))
            totalDeliveryFees += Convert.ToDecimal(row("DeliveryFee"))
        Next

        ' الصافي المطلوب توريده من الطيار للمطعم = إجمالي مبالغ الفواتير - عمولات التوصيل
        Dim netDueToRestaurant As Decimal = totalCashOrders - totalDeliveryFees

        lblTotalOrdersCount.Text = totalOrdersCount.ToString()
        lblTotalOrdersCash.Text = totalCashOrders.ToString("N2") & " ج"
        lblTotalDeliveryFees.Text = totalDeliveryFees.ToString("N2") & " ج"
        lblNetDueToRestaurant.Text = netDueToRestaurant.ToString("N2") & " ج"
    End Sub

    ' =========================================================
    ' زر تصفية حسابات وأوردرات الطيار وتوريدها للدرج
    ' =========================================================
    Private Sub btnSettle_Click(sender As Object, e As EventArgs) Handles btnSettle.Click
        Dim driverID As Integer = If(cmbDrivers.SelectedValue IsNot Nothing, Convert.ToInt32(cmbDrivers.SelectedValue), 0)

        If driverID = 0 Then
            MessageBox.Show("برجاء اختيار طيار محدد من القائمة لإجراء التصفية!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim driverName As String = cmbDrivers.Text
        Dim confirm = MessageBox.Show($"هل أنت متأكد من تسوية وتصفية جميع الأوردرات المعلقة للطيار: {driverName}؟", "تأكيد التصفية", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            If _repo.SettleDriverOrders(driverID) Then
                MessageBox.Show("تمت تصفية وتوريد حسابات الطيار بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FilterData()
            Else
                MessageBox.Show("لا توجد أوردرات معلقة لتصفيتها لهذا الطيار.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

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