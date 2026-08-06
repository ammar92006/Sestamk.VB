<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayInvoice
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()

        '── Panels ────────────────────────────────────────────────────
        Me.pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblPaymentTitle = New System.Windows.Forms.Label()
        Me.pnlAmounts = New System.Windows.Forms.Panel()
        Me.lblNetRequiredTitle = New System.Windows.Forms.Label()
        Me.lblNetRequired = New System.Windows.Forms.Label()
        Me.lblPaidTitle = New System.Windows.Forms.Label()
        Me.txtPaidAmount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblRemainingTitle = New System.Windows.Forms.Label()
        Me.lblRemainingAmount = New System.Windows.Forms.Label()
        Me.pnlNumpadArea = New System.Windows.Forms.Panel()
        Me.tblNumpad = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNum7 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum8 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum9 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum4 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum5 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum6 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum1 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum2 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum3 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNumDot = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNum0 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNumBack = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNumClear = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlShortcuts = New System.Windows.Forms.Panel()
        Me.btnShortcut50 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnShortcut100 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnShortcut200 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnShortcut500 = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlPayFooter = New System.Windows.Forms.Panel()
        Me.btnPrintAndClose = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCloseWithoutPrint = New Guna.UI2.WinForms.Guna2Button()

        Me.pnlHeader.SuspendLayout()
        Me.pnlAmounts.SuspendLayout()
        Me.pnlNumpadArea.SuspendLayout()
        Me.tblNumpad.SuspendLayout()
        Me.pnlShortcuts.SuspendLayout()
        Me.pnlPayFooter.SuspendLayout()
        Me.SuspendLayout()

        ' ═══════════════════════════════════════════════════════════
        '  pnlHeader  —  60px
        ' ═══════════════════════════════════════════════════════════
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.FillColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(560, 60)
        Me.pnlHeader.ShadowDecoration.Enabled = False
        Me.pnlHeader.Controls.Add(Me.lblPaymentTitle)

        '  lblPaymentTitle
        Me.lblPaymentTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblPaymentTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPaymentTitle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblPaymentTitle.ForeColor = System.Drawing.Color.White
        Me.lblPaymentTitle.Name = "lblPaymentTitle"
        Me.lblPaymentTitle.Size = New System.Drawing.Size(560, 60)
        Me.lblPaymentTitle.TabIndex = 0
        Me.lblPaymentTitle.Text = "💳  إتمام الدفع"
        Me.lblPaymentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ═══════════════════════════════════════════════════════════
        '  pnlPayFooter  —  72px
        ' ═══════════════════════════════════════════════════════════
        Me.pnlPayFooter.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.pnlPayFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPayFooter.Name = "pnlPayFooter"
        Me.pnlPayFooter.Size = New System.Drawing.Size(560, 72)
        Me.pnlPayFooter.Controls.Add(Me.btnPrintAndClose)
        Me.pnlPayFooter.Controls.Add(Me.btnCloseWithoutPrint)

        '  btnPrintAndClose  —  Green 50px
        Me.btnPrintAndClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintAndClose.BorderRadius = 10
        Me.btnPrintAndClose.FillColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnPrintAndClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrintAndClose.ForeColor = System.Drawing.Color.White
        Me.btnPrintAndClose.HoverState.FillColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.btnPrintAndClose.PressedColor = System.Drawing.Color.FromArgb(25, 135, 65)
        Me.btnPrintAndClose.Location = New System.Drawing.Point(10, 10)
        Me.btnPrintAndClose.Name = "btnPrintAndClose"
        Me.btnPrintAndClose.Size = New System.Drawing.Size(255, 52)
        Me.btnPrintAndClose.TabIndex = 80
        Me.btnPrintAndClose.Text = "🖨  طباعة وإغلاق"
        Me.btnPrintAndClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '  btnCloseWithoutPrint
        Me.btnCloseWithoutPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCloseWithoutPrint.BorderRadius = 10
        Me.btnCloseWithoutPrint.FillColor = System.Drawing.Color.FromArgb(52, 73, 94)
        Me.btnCloseWithoutPrint.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCloseWithoutPrint.ForeColor = System.Drawing.Color.White
        Me.btnCloseWithoutPrint.HoverState.FillColor = System.Drawing.Color.FromArgb(72, 100, 130)
        Me.btnCloseWithoutPrint.PressedColor = System.Drawing.Color.FromArgb(35, 50, 65)
        Me.btnCloseWithoutPrint.Location = New System.Drawing.Point(275, 10)
        Me.btnCloseWithoutPrint.Name = "btnCloseWithoutPrint"
        Me.btnCloseWithoutPrint.Size = New System.Drawing.Size(250, 52)
        Me.btnCloseWithoutPrint.TabIndex = 81
        Me.btnCloseWithoutPrint.Text = "✖  إغلاق بدون طباعة"
        Me.btnCloseWithoutPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ═══════════════════════════════════════════════════════════
        '  pnlAmounts  —  Display values  160px
        ' ═══════════════════════════════════════════════════════════
        Me.pnlAmounts.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.pnlAmounts.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAmounts.Name = "pnlAmounts"
        Me.pnlAmounts.Padding = New System.Windows.Forms.Padding(15, 8, 15, 8)
        Me.pnlAmounts.Size = New System.Drawing.Size(560, 155)
        Me.pnlAmounts.Controls.Add(Me.lblNetRequiredTitle)
        Me.pnlAmounts.Controls.Add(Me.lblNetRequired)
        Me.pnlAmounts.Controls.Add(Me.lblPaidTitle)
        Me.pnlAmounts.Controls.Add(Me.txtPaidAmount)
        Me.pnlAmounts.Controls.Add(Me.lblRemainingTitle)
        Me.pnlAmounts.Controls.Add(Me.lblRemainingAmount)

        '  Row 1: Net Required
        Me.lblNetRequiredTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblNetRequiredTitle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblNetRequiredTitle.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199)
        Me.lblNetRequiredTitle.Location = New System.Drawing.Point(300, 8)
        Me.lblNetRequiredTitle.Name = "lblNetRequiredTitle"
        Me.lblNetRequiredTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNetRequiredTitle.Size = New System.Drawing.Size(245, 30)
        Me.lblNetRequiredTitle.TabIndex = 1
        Me.lblNetRequiredTitle.Text = "المبلغ المطلوب:"
        Me.lblNetRequiredTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        Me.lblNetRequired.BackColor = System.Drawing.Color.Transparent
        Me.lblNetRequired.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblNetRequired.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.lblNetRequired.Location = New System.Drawing.Point(15, 8)
        Me.lblNetRequired.Name = "lblNetRequired"
        Me.lblNetRequired.Size = New System.Drawing.Size(280, 34)
        Me.lblNetRequired.TabIndex = 2
        Me.lblNetRequired.Text = "0.00"
        Me.lblNetRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        '  Row 2: Paid Amount Input
        Me.lblPaidTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblPaidTitle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblPaidTitle.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199)
        Me.lblPaidTitle.Location = New System.Drawing.Point(400, 50)
        Me.lblPaidTitle.Name = "lblPaidTitle"
        Me.lblPaidTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPaidTitle.Size = New System.Drawing.Size(145, 30)
        Me.lblPaidTitle.TabIndex = 3
        Me.lblPaidTitle.Text = "المبلغ المدفوع:"
        Me.lblPaidTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        Me.txtPaidAmount.BorderRadius = 8
        Me.txtPaidAmount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaidAmount.DefaultText = ""
        Me.txtPaidAmount.FillColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.txtPaidAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.txtPaidAmount.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPaidAmount.ForeColor = System.Drawing.Color.White
        Me.txtPaidAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.txtPaidAmount.Location = New System.Drawing.Point(15, 48)
        Me.txtPaidAmount.Name = "txtPaidAmount"
        Me.txtPaidAmount.PlaceholderText = "0.00"
        Me.txtPaidAmount.ReadOnly = True
        Me.txtPaidAmount.SelectedText = ""
        Me.txtPaidAmount.Size = New System.Drawing.Size(380, 48)
        Me.txtPaidAmount.TabIndex = 4
        Me.txtPaidAmount.Text = "0"
        Me.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center

        '  Row 3: Remaining / Change
        Me.lblRemainingTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblRemainingTitle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblRemainingTitle.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199)
        Me.lblRemainingTitle.Location = New System.Drawing.Point(330, 107)
        Me.lblRemainingTitle.Name = "lblRemainingTitle"
        Me.lblRemainingTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRemainingTitle.Size = New System.Drawing.Size(215, 30)
        Me.lblRemainingTitle.TabIndex = 5
        Me.lblRemainingTitle.Text = "المبلغ المرتجع:"
        Me.lblRemainingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        Me.lblRemainingAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblRemainingAmount.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblRemainingAmount.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.lblRemainingAmount.Location = New System.Drawing.Point(15, 107)
        Me.lblRemainingAmount.Name = "lblRemainingAmount"
        Me.lblRemainingAmount.Size = New System.Drawing.Size(310, 34)
        Me.lblRemainingAmount.TabIndex = 6
        Me.lblRemainingAmount.Text = "0.00"
        Me.lblRemainingAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' ═══════════════════════════════════════════════════════════
        '  pnlShortcuts  —  Quick cash buttons  50px
        ' ═══════════════════════════════════════════════════════════
        Me.pnlShortcuts.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.pnlShortcuts.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlShortcuts.Name = "pnlShortcuts"
        Me.pnlShortcuts.Size = New System.Drawing.Size(560, 52)
        Me.pnlShortcuts.Controls.Add(Me.btnShortcut50)
        Me.pnlShortcuts.Controls.Add(Me.btnShortcut100)
        Me.pnlShortcuts.Controls.Add(Me.btnShortcut200)
        Me.pnlShortcuts.Controls.Add(Me.btnShortcut500)

        Dim btnShortcutStyle As Action(Of Guna.UI2.WinForms.Guna2Button, String, Integer) =
            Sub(b, t, x)
                b.BorderRadius = 8
                b.FillColor = System.Drawing.Color.FromArgb(52, 73, 94)
                b.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
                b.ForeColor = System.Drawing.Color.White
                b.HoverState.FillColor = System.Drawing.Color.FromArgb(41, 128, 185)
                b.Location = New System.Drawing.Point(x, 7)
                b.Size = New System.Drawing.Size(118, 38)
                b.Text = t
                b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            End Sub

        Me.btnShortcut50.Name = "btnShortcut50"
        Me.btnShortcut50.TabIndex = 40
        btnShortcutStyle(Me.btnShortcut50, "+50", 10)

        Me.btnShortcut100.Name = "btnShortcut100"
        Me.btnShortcut100.TabIndex = 41
        btnShortcutStyle(Me.btnShortcut100, "+100", 138)

        Me.btnShortcut200.Name = "btnShortcut200"
        Me.btnShortcut200.TabIndex = 42
        btnShortcutStyle(Me.btnShortcut200, "+200", 266)

        Me.btnShortcut500.Name = "btnShortcut500"
        Me.btnShortcut500.TabIndex = 43
        btnShortcutStyle(Me.btnShortcut500, "+500", 394)

        ' ═══════════════════════════════════════════════════════════
        '  pnlNumpadArea  —  Fills remainder
        ' ═══════════════════════════════════════════════════════════
        Me.pnlNumpadArea.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.pnlNumpadArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNumpadArea.Name = "pnlNumpadArea"
        Me.pnlNumpadArea.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlNumpadArea.Controls.Add(Me.tblNumpad)

        '  tblNumpad  —  4-col TableLayoutPanel for numpad
        Me.tblNumpad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblNumpad.BackColor = System.Drawing.Color.Transparent
        Me.tblNumpad.ColumnCount = 3
        Me.tblNumpad.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tblNumpad.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tblNumpad.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34!))
        Me.tblNumpad.RowCount = 4
        Me.tblNumpad.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblNumpad.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblNumpad.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblNumpad.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblNumpad.Location = New System.Drawing.Point(10, 10)
        Me.tblNumpad.Name = "tblNumpad"
        Me.tblNumpad.Size = New System.Drawing.Size(538, 220)
        Me.tblNumpad.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None

        ' Helper to style numpad buttons
        Dim StyleNumBtn As Action(Of Guna.UI2.WinForms.Guna2Button, String, Integer, Integer, Boolean) =
            Sub(b, t, tabI, fillArgb, isSpecial)
                b.BorderRadius = 8
                b.FillColor = If(isSpecial, System.Drawing.Color.FromArgb(44, 62, 80), System.Drawing.Color.FromArgb(52, 73, 94))
                b.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
                b.ForeColor = System.Drawing.Color.White
                b.HoverState.FillColor = System.Drawing.Color.FromArgb(41, 128, 185)
                b.Dock = System.Windows.Forms.DockStyle.Fill
                b.Margin = New System.Windows.Forms.Padding(3)
                b.Name = b.Name
                b.TabIndex = tabI
                b.Text = t
                b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            End Sub

        Me.btnNum7.Name = "btnNum7" : StyleNumBtn(Me.btnNum7, "7", 20, 0, False)
        Me.btnNum8.Name = "btnNum8" : StyleNumBtn(Me.btnNum8, "8", 21, 0, False)
        Me.btnNum9.Name = "btnNum9" : StyleNumBtn(Me.btnNum9, "9", 22, 0, False)
        Me.btnNum4.Name = "btnNum4" : StyleNumBtn(Me.btnNum4, "4", 23, 0, False)
        Me.btnNum5.Name = "btnNum5" : StyleNumBtn(Me.btnNum5, "5", 24, 0, False)
        Me.btnNum6.Name = "btnNum6" : StyleNumBtn(Me.btnNum6, "6", 25, 0, False)
        Me.btnNum1.Name = "btnNum1" : StyleNumBtn(Me.btnNum1, "1", 26, 0, False)
        Me.btnNum2.Name = "btnNum2" : StyleNumBtn(Me.btnNum2, "2", 27, 0, False)
        Me.btnNum3.Name = "btnNum3" : StyleNumBtn(Me.btnNum3, "3", 28, 0, False)
        Me.btnNumDot.Name = "btnNumDot" : StyleNumBtn(Me.btnNumDot, ".", 29, 0, True)
        Me.btnNum0.Name = "btnNum0" : StyleNumBtn(Me.btnNum0, "0", 30, 0, False)
        Me.btnNumBack.Name = "btnNumBack" : StyleNumBtn(Me.btnNumBack, "⌫", 31, 0, True)
        Me.btnNumClear.Name = "btnNumClear"
        Me.btnNumClear.BorderRadius = 8
        Me.btnNumClear.FillColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.btnNumClear.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnNumClear.ForeColor = System.Drawing.Color.White
        Me.btnNumClear.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 100, 84)
        Me.btnNumClear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNumClear.Margin = New System.Windows.Forms.Padding(3)
        Me.btnNumClear.TabIndex = 32
        Me.btnNumClear.Text = "مسح"
        Me.btnNumClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '  Add numpad cells  (row 0)
        Me.tblNumpad.Controls.Add(Me.btnNum7, 0, 0)
        Me.tblNumpad.Controls.Add(Me.btnNum8, 1, 0)
        Me.tblNumpad.Controls.Add(Me.btnNum9, 2, 0)
        '  row 1
        Me.tblNumpad.Controls.Add(Me.btnNum4, 0, 1)
        Me.tblNumpad.Controls.Add(Me.btnNum5, 1, 1)
        Me.tblNumpad.Controls.Add(Me.btnNum6, 2, 1)
        '  row 2
        Me.tblNumpad.Controls.Add(Me.btnNum1, 0, 2)
        Me.tblNumpad.Controls.Add(Me.btnNum2, 1, 2)
        Me.tblNumpad.Controls.Add(Me.btnNum3, 2, 2)
        '  row 3
        Me.tblNumpad.Controls.Add(Me.btnNumDot, 0, 3)
        Me.tblNumpad.Controls.Add(Me.btnNum0, 1, 3)
        Me.tblNumpad.Controls.Add(Me.btnNumBack, 2, 3)

        ' ═══════════════════════════════════════════════════════════
        '  frmPayInvoice  —  Form properties
        ' ═══════════════════════════════════════════════════════════
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.ClientSize = New System.Drawing.Size(560, 560)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPayInvoice"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "إتمام الدفع"

        Me.Controls.Add(Me.pnlNumpadArea)
        Me.Controls.Add(Me.pnlShortcuts)
        Me.Controls.Add(Me.pnlAmounts)
        Me.Controls.Add(Me.pnlPayFooter)
        Me.Controls.Add(Me.pnlHeader)

        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAmounts.ResumeLayout(False)
        Me.pnlNumpadArea.ResumeLayout(False)
        Me.tblNumpad.ResumeLayout(False)
        Me.pnlShortcuts.ResumeLayout(False)
        Me.pnlPayFooter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    '── Field declarations ───────────────────────────────────────────
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblPaymentTitle As System.Windows.Forms.Label
    Friend WithEvents pnlAmounts As System.Windows.Forms.Panel
    Friend WithEvents lblNetRequiredTitle As System.Windows.Forms.Label
    Friend WithEvents lblNetRequired As System.Windows.Forms.Label
    Friend WithEvents lblPaidTitle As System.Windows.Forms.Label
    Friend WithEvents txtPaidAmount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblRemainingTitle As System.Windows.Forms.Label
    Friend WithEvents lblRemainingAmount As System.Windows.Forms.Label
    Friend WithEvents pnlNumpadArea As System.Windows.Forms.Panel
    Friend WithEvents tblNumpad As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnNum0 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum4 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum5 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum6 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum7 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum8 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNum9 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNumDot As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNumBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNumClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlShortcuts As System.Windows.Forms.Panel
    Friend WithEvents btnShortcut50 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnShortcut100 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnShortcut200 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnShortcut500 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlPayFooter As System.Windows.Forms.Panel
    Friend WithEvents btnPrintAndClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCloseWithoutPrint As Guna.UI2.WinForms.Guna2Button

End Class
