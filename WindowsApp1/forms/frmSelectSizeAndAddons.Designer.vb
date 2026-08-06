<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectSizeAndAddons
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

        '── Controls ─────────────────────────────────────────────────
        Me.pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.lblSizesTitle = New System.Windows.Forms.Label()
        Me.pnlSizesFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblAddonsTitle = New System.Windows.Forms.Label()
        Me.pnlAddonsFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblItemNotes = New System.Windows.Forms.Label()
        Me.txtItemNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnlFooterDlg = New System.Windows.Forms.Panel()
        Me.lblItemTotal = New System.Windows.Forms.Label()
        Me.btnConfirmItem = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancelDlg = New Guna.UI2.WinForms.Guna2Button()

        Me.pnlHeader.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlFooterDlg.SuspendLayout()
        Me.SuspendLayout()

        ' ═══════════════════════════════════════════════════════════
        '  pnlHeader  —  60px dark header
        ' ═══════════════════════════════════════════════════════════
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.FillColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(640, 60)
        Me.pnlHeader.ShadowDecoration.Enabled = False
        Me.pnlHeader.Controls.Add(Me.lblProductName)

        '  lblProductName  —  14pt Bold
        Me.lblProductName.BackColor = System.Drawing.Color.Transparent
        Me.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProductName.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblProductName.ForeColor = System.Drawing.Color.White
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblProductName.Size = New System.Drawing.Size(640, 60)
        Me.lblProductName.TabIndex = 0
        Me.lblProductName.Text = "اسم المنتج"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ═══════════════════════════════════════════════════════════
        '  pnlFooterDlg  —  80px bottom panel
        ' ═══════════════════════════════════════════════════════════
        Me.pnlFooterDlg.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.pnlFooterDlg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooterDlg.Name = "pnlFooterDlg"
        Me.pnlFooterDlg.Size = New System.Drawing.Size(640, 78)
        Me.pnlFooterDlg.Controls.Add(Me.lblItemTotal)
        Me.pnlFooterDlg.Controls.Add(Me.btnConfirmItem)
        Me.pnlFooterDlg.Controls.Add(Me.btnCancelDlg)

        '  lblItemTotal
        Me.lblItemTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItemTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblItemTotal.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblItemTotal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.lblItemTotal.Location = New System.Drawing.Point(410, 18)
        Me.lblItemTotal.Name = "lblItemTotal"
        Me.lblItemTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblItemTotal.Size = New System.Drawing.Size(220, 42)
        Me.lblItemTotal.TabIndex = 10
        Me.lblItemTotal.Text = "الإجمالي:  0.00"
        Me.lblItemTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        '  btnConfirmItem  —  Green 45px
        Me.btnConfirmItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmItem.BorderRadius = 10
        Me.btnConfirmItem.FillColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnConfirmItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnConfirmItem.ForeColor = System.Drawing.Color.White
        Me.btnConfirmItem.HoverState.FillColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.btnConfirmItem.PressedColor = System.Drawing.Color.FromArgb(25, 135, 65)
        Me.btnConfirmItem.Location = New System.Drawing.Point(10, 15)
        Me.btnConfirmItem.Name = "btnConfirmItem"
        Me.btnConfirmItem.Size = New System.Drawing.Size(170, 48)
        Me.btnConfirmItem.TabIndex = 11
        Me.btnConfirmItem.Text = "✔  تأكيد الإضافة"
        Me.btnConfirmItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '  btnCancelDlg  —  Red cancel
        Me.btnCancelDlg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelDlg.BorderRadius = 10
        Me.btnCancelDlg.FillColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.btnCancelDlg.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancelDlg.ForeColor = System.Drawing.Color.White
        Me.btnCancelDlg.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 100, 84)
        Me.btnCancelDlg.PressedColor = System.Drawing.Color.FromArgb(180, 45, 35)
        Me.btnCancelDlg.Location = New System.Drawing.Point(190, 15)
        Me.btnCancelDlg.Name = "btnCancelDlg"
        Me.btnCancelDlg.Size = New System.Drawing.Size(130, 48)
        Me.btnCancelDlg.TabIndex = 12
        Me.btnCancelDlg.Text = "✖  إلغاء"
        Me.btnCancelDlg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ═══════════════════════════════════════════════════════════
        '  pnlBody  —  Fills remaining space
        ' ═══════════════════════════════════════════════════════════
        Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlBody.Controls.Add(Me.txtItemNotes)
        Me.pnlBody.Controls.Add(Me.lblItemNotes)
        Me.pnlBody.Controls.Add(Me.pnlAddonsFlow)
        Me.pnlBody.Controls.Add(Me.lblAddonsTitle)
        Me.pnlBody.Controls.Add(Me.pnlSizesFlow)
        Me.pnlBody.Controls.Add(Me.lblSizesTitle)

        '  lblSizesTitle
        Me.lblSizesTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSizesTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblSizesTitle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblSizesTitle.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.lblSizesTitle.Location = New System.Drawing.Point(480, 12)
        Me.lblSizesTitle.Name = "lblSizesTitle"
        Me.lblSizesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSizesTitle.Size = New System.Drawing.Size(140, 26)
        Me.lblSizesTitle.TabIndex = 1
        Me.lblSizesTitle.Text = "▶  اختر الحجم:"
        Me.lblSizesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        '  pnlSizesFlow  —  Size buttons (Small/Med/Large)
        Me.pnlSizesFlow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSizesFlow.AutoScroll = True
        Me.pnlSizesFlow.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.pnlSizesFlow.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlSizesFlow.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.pnlSizesFlow.Location = New System.Drawing.Point(12, 44)
        Me.pnlSizesFlow.Name = "pnlSizesFlow"
        Me.pnlSizesFlow.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlSizesFlow.Size = New System.Drawing.Size(614, 85)
        Me.pnlSizesFlow.TabIndex = 2
        Me.pnlSizesFlow.WrapContents = False

        '  lblAddonsTitle
        Me.lblAddonsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAddonsTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblAddonsTitle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblAddonsTitle.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18)
        Me.lblAddonsTitle.Location = New System.Drawing.Point(465, 138)
        Me.lblAddonsTitle.Name = "lblAddonsTitle"
        Me.lblAddonsTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAddonsTitle.Size = New System.Drawing.Size(155, 26)
        Me.lblAddonsTitle.TabIndex = 3
        Me.lblAddonsTitle.Text = "▶  الإضافات:"
        Me.lblAddonsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        '  pnlAddonsFlow  —  Addon checkbox cards
        Me.pnlAddonsFlow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAddonsFlow.AutoScroll = True
        Me.pnlAddonsFlow.BackColor = System.Drawing.Color.FromArgb(37, 37, 53)
        Me.pnlAddonsFlow.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.pnlAddonsFlow.Location = New System.Drawing.Point(12, 170)
        Me.pnlAddonsFlow.Name = "pnlAddonsFlow"
        Me.pnlAddonsFlow.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlAddonsFlow.Size = New System.Drawing.Size(614, 120)
        Me.pnlAddonsFlow.TabIndex = 4
        Me.pnlAddonsFlow.WrapContents = True

        '  lblItemNotes
        Me.lblItemNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItemNotes.BackColor = System.Drawing.Color.Transparent
        Me.lblItemNotes.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblItemNotes.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199)
        Me.lblItemNotes.Location = New System.Drawing.Point(477, 300)
        Me.lblItemNotes.Name = "lblItemNotes"
        Me.lblItemNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblItemNotes.Size = New System.Drawing.Size(145, 24)
        Me.lblItemNotes.TabIndex = 5
        Me.lblItemNotes.Text = "ملاحظات المطبخ:"
        Me.lblItemNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        '  txtItemNotes  —  Multi-line kitchen notes
        Me.txtItemNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemNotes.BorderRadius = 8
        Me.txtItemNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItemNotes.DefaultText = ""
        Me.txtItemNotes.FillColor = System.Drawing.Color.FromArgb(52, 73, 94)
        Me.txtItemNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.txtItemNotes.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtItemNotes.ForeColor = System.Drawing.Color.White
        Me.txtItemNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.txtItemNotes.Location = New System.Drawing.Point(12, 330)
        Me.txtItemNotes.Multiline = True
        Me.txtItemNotes.Name = "txtItemNotes"
        Me.txtItemNotes.PlaceholderText = "مثال: بدون بصل، إضافي حار..."
        Me.txtItemNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtItemNotes.SelectedText = ""
        Me.txtItemNotes.Size = New System.Drawing.Size(614, 60)
        Me.txtItemNotes.TabIndex = 6

        ' ═══════════════════════════════════════════════════════════
        '  frmSelectSizeAndAddons  —  Form properties
        ' ═══════════════════════════════════════════════════════════
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(30, 30, 46)
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectSizeAndAddons"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "الحجم والإضافات"

        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlFooterDlg)
        Me.Controls.Add(Me.pnlHeader)

        Me.pnlHeader.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlFooterDlg.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    '── Field declarations ───────────────────────────────────────────
    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents lblSizesTitle As System.Windows.Forms.Label
    Friend WithEvents pnlSizesFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblAddonsTitle As System.Windows.Forms.Label
    Friend WithEvents pnlAddonsFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblItemNotes As System.Windows.Forms.Label
    Friend WithEvents txtItemNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pnlFooterDlg As System.Windows.Forms.Panel
    Friend WithEvents lblItemTotal As System.Windows.Forms.Label
    Friend WithEvents btnConfirmItem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancelDlg As Guna.UI2.WinForms.Guna2Button

End Class
