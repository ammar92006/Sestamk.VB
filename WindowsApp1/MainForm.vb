Imports System.Runtime.InteropServices
Imports WindowsApp1.FrmTreasuryTransaction

Public Class MainForm

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Application.Exit()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        FormHelper.ToggleMaximize(Me)
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        FormHelper.Minimiz(Me)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.RightToLeft = RightToLeft.Yes
        TabControl1.RightToLeftLayout = False
        TabControl1.Alignment = TabAlignment.Top
        TabControl1.DrawMode = TabDrawMode.Normal
        TabControl1.SizeMode = TabSizeMode.Normal

        ReverseTabPages()
        Dim Drag As FormDragHelper
        Drag = New FormDragHelper(Me, panelHeader)
        Drag = New FormDragHelper(Me, lbltitle)

        ' تطبيق ثيم MainForm المتوافق مع الهوية الأصلية
        ApplyMainFormTheme()
        AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
    End Sub

    Private Sub ReverseTabPages()
        Dim pages As New List(Of TabPage)
        For Each page As TabPage In TabControl1.TabPages
            pages.Add(page)
        Next
        TabControl1.TabPages.Clear()
        For i As Integer = pages.Count - 1 To 0 Step -1
            TabControl1.TabPages.Add(pages(i))
        Next
    End Sub

    Public Sub ApplyMainFormTheme()
        Try
            Dim pal = ThemeManager.Instance.CurrentPalette

            ' خلفية الفورم
            Me.BackColor = pal.Background

            ' الهيدر يظل داكناً بالهوية الأصلية
            panelHeader.FillColor = pal.SurfaceHeader
            lbltitle.ForeColor = pal.TextOnDark

            ' أزرار التحكم بالنافذة
            btn_min.Appearance.BackColor = pal.SurfaceHeader
            btn_min.Appearance.ForeColor = pal.TextOnDark
            btn_min.Appearance.Options.UseBackColor = True
            btn_min.Appearance.Options.UseForeColor = True

            btn_max.Appearance.BackColor = pal.SurfaceHeader
            btn_max.Appearance.ForeColor = pal.TextOnDark
            btn_max.Appearance.Options.UseBackColor = True
            btn_max.Appearance.Options.UseForeColor = True

            btn_close.Appearance.BackColor = pal.SurfaceHeader
            btn_close.Appearance.ForeColor = pal.TextOnDark
            btn_close.Appearance.Options.UseBackColor = True
            btn_close.Appearance.Options.UseForeColor = True

            ' شريط التبويبات
            TabControl1.BackColor = pal.Background
            For Each pg As TabPage In TabControl1.TabPages
                pg.BackColor = pal.Background
            Next

            ' أشرطة الأدوات ToolStrip
            ThemeHelper.ApplyToolStripRenderer(Me, pal)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
        If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return
        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf ApplyMainFormTheme))
        Else
            ApplyMainFormTheme()
        End If
    End Sub

    ' ─── أزرار شريط الأدوات (ToolStrip Buttons) ───
    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        OpenFormOnce(GetType(Categories), btnCategories)
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        OpenFormOnce(GetType(Products), btnProducts)
    End Sub

    Private Sub btnfrmProductSizes_Click(sender As Object, e As EventArgs) Handles btnfrmProductSizes.Click
        OpenFormOnce(GetType(frmProductSizes), btnfrmProductSizes)
    End Sub

    Private Sub btnfrmProductAddons_Click(sender As Object, e As EventArgs) Handles btnfrmProductAddons.Click
        OpenFormOnce(GetType(frmProductAddons), btnfrmProductAddons)
    End Sub

    Private Sub btnfrmPOS_Click(sender As Object, e As EventArgs) Handles btnfrmPOS.Click
        OpenFormOnce(GetType(frmPOS), btnfrmPOS)
    End Sub

    Private Sub btnfrmEmployees_Click(sender As Object, e As EventArgs) Handles btnfrmEmployees.Click
        OpenFormOnce(GetType(frmEmployees), btnfrmEmployees)
    End Sub

    Private Sub btnfrmJobTitles_Click(sender As Object, e As EventArgs) Handles btnfrmJobTitles.Click
        OpenFormOnce(GetType(frmJobTitles), btnfrmJobTitles)
    End Sub

    Private Sub btnfrmDepartments_Click(sender As Object, e As EventArgs) Handles btnfrmDepartments.Click
        OpenFormOnce(GetType(frmDepartments), btnfrmDepartments)
    End Sub

    Private Sub btnfrmSalarySystems_Click(sender As Object, e As EventArgs) Handles btnfrmSalarySystems.Click
        OpenFormOnce(GetType(frmSalarySystems), btnfrmSalarySystems)
    End Sub

    Private Sub btnfrmColors_Click(sender As Object, e As EventArgs) Handles btnfrmColors.Click
        OpenFormOnce(GetType(frmColors), btnfrmColors)
    End Sub

    Private Sub btnfrmDeliveryAreas_Click(sender As Object, e As EventArgs) Handles btnfrmDeliveryAreas.Click
        OpenFormOnce(GetType(frmDeliveryAreas), btnfrmDeliveryAreas)
    End Sub

    Private Sub btnfrmDeliveryDrivers_Click(sender As Object, e As EventArgs) Handles btnfrmDeliveryDrivers.Click
        OpenFormOnce(GetType(frmDeliveryDrivers), btnfrmDeliveryDrivers)
    End Sub

    Private Sub btnfrmTreasury_Click(sender As Object, e As EventArgs) Handles btnfrmTreasury.Click
        OpenFormOnce(GetType(frmTreasury), btnfrmTreasury)
    End Sub

    Private Sub btnFrmTreasuryTransfer_Click(sender As Object, e As EventArgs) Handles btnFrmTreasuryTransfer.Click
        OpenFormOnce(GetType(FrmTreasuryTransfer), btnFrmTreasuryTransfer)
    End Sub

    Private Sub btnFrmTreasuryTransactionsReport_Click(sender As Object, e As EventArgs) Handles btnFrmTreasuryTransactionsReport.Click
        OpenFormOnce(GetType(FrmTreasuryTransactionsReport), btnFrmTreasuryTransactionsReport)
    End Sub

    Private Sub btnfrmPrinters_Click(sender As Object, e As EventArgs) Handles btnfrmPrinters.Click
        OpenFormOnce(GetType(frmPrinters), btnfrmPrinters)
    End Sub

    Private Sub btnfrmRestaurantSections_Click(sender As Object, e As EventArgs) Handles btnfrmRestaurantSections.Click
        OpenFormOnce(GetType(frmRestaurantSections), btnfrmRestaurantSections)
    End Sub

    Private Sub btnfrmRestaurantTables_Click(sender As Object, e As EventArgs) Handles btnfrmRestaurantTables.Click
        OpenFormOnce(GetType(frmRestaurantTables), btnfrmRestaurantTables)
    End Sub

    Private Sub btnfrmShifts_Click(sender As Object, e As EventArgs) Handles btnfrmShifts.Click
        OpenFormOnce(GetType(frmShifts), btnfrmShifts)
    End Sub

    Private Sub btnfrmBranches_Click(sender As Object, e As EventArgs) Handles btnfrmBranches.Click
        OpenFormOnce(GetType(frmBranches), btnfrmBranches)
    End Sub

    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnFrmCustomers.Click
        OpenFormOnce(GetType(FrmCustomers), btnFrmCustomers)
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        OpenFormOnce(GetType(Settings), btnSettings)
    End Sub

    Private Sub btnBackups_Click(sender As Object, e As EventArgs) Handles btnBackups.Click
        OpenFormOnce(GetType(Backup), btnBackups)
    End Sub

    Private Sub btnFrmCustomerStatement_Click(sender As Object, e As EventArgs) Handles btnFrmCustomerStatement.Click
        OpenFormOnce(GetType(FrmCustomerStatement), btnFrmCustomerStatement)
    End Sub

    Private Sub btnFrmSalesReport_Click(sender As Object, e As EventArgs) Handles btnFrmSalesReport.Click
        OpenFormOnce(GetType(FrmSalesReport), btnFrmSalesReport)
    End Sub

    Private Sub btnFrmDriverReport_Click(sender As Object, e As EventArgs) Handles btnFrmDriverReport.Click
        OpenFormOnce(GetType(FrmDriverReport), btnFrmDriverReport)
    End Sub

    Private Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles btnDeposit.Click
        OpenTreasuryWithOperation(FrmTreasuryTransaction.TreasuryOperation.Deposit, btnDeposit)
    End Sub

    Private Sub btnWithdraw_Click(sender As Object, e As EventArgs) Handles btnWithdraw.Click
        OpenTreasuryWithOperation(FrmTreasuryTransaction.TreasuryOperation.Withdraw, btnWithdraw)
    End Sub

    Private Sub btnform_Expenses_Click(sender As Object, e As EventArgs) Handles btnform_Expenses.Click
        OpenFormOnce(GetType(form_Expenses), btnform_Expenses)
    End Sub

    Private Sub btnExpensesReportForm_Click(sender As Object, e As EventArgs) Handles btnExpensesReportForm.Click
        OpenFormOnce(GetType(ExpensesReportForm), btnExpensesReportForm)
    End Sub

    Private Sub btnfrmUnits_Click(sender As Object, e As EventArgs) Handles btnfrmUnits.Click
        OpenFormOnce(GetType(frmUnits), btnfrmUnits)
    End Sub

    Private Sub btnfrmStores_Click(sender As Object, e As EventArgs) Handles btnfrmStores.Click
        OpenFormOnce(GetType(FrmStores), btnfrmStores)
    End Sub

    Private Sub btnfrmStoreStock_Click(sender As Object, e As EventArgs) Handles btnfrmStoreStock.Click
        OpenFormOnce(GetType(frmStoreStock), btnfrmStoreStock)
    End Sub

    Private Sub btnfrmRawMaterials_Click(sender As Object, e As EventArgs) Handles btnfrmRawMaterials.Click
        OpenFormOnce(GetType(frmRawMaterials), btnfrmRawMaterials)
    End Sub

    Private Sub btnfrmRecipes_Click(sender As Object, e As EventArgs) Handles btnfrmRecipes.Click
        OpenFormOnce(GetType(frmRecipes), btnfrmRecipes)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        OpenFormOnce(GetType(FrmSuppliers), ToolStripButton3)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        OpenFormOnce(GetType(FrmSupplierTransactions), ToolStripButton4)
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        OpenFormOnce(GetType(Purchases), ToolStripButton13)
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        OpenFormOnce(GetType(Purchase_Return), ToolStripButton14)
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        OpenFormOnce(GetType(Sales_Returns), ToolStripButton11)
    End Sub

    Private Sub OpenTreasuryWithOperation(op As FrmTreasuryTransaction.TreasuryOperation, btn As ToolStripButton)
        Dim frm As New FrmTreasuryTransaction(op)
        AddHandler frm.FormClosed, Sub(s, ev)
                                       btn.Checked = False
                                   End Sub
        frm.Show()
        btn.Checked = True
    End Sub

End Class
