<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmMessage
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
        Me.pnlHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlCard = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.lblCustomerTitle = New System.Windows.Forms.Label()
        Me.lblBalanceBefore = New System.Windows.Forms.Label()
        Me.lblBalanceBeforeTitle = New System.Windows.Forms.Label()
        Me.lblAmountPaid = New System.Windows.Forms.Label()
        Me.lblAmountPaidTitle = New System.Windows.Forms.Label()
        Me.lblBalanceAfter = New System.Windows.Forms.Label()
        Me.lblBalanceAfterTitle = New System.Windows.Forms.Label()
        Me.lblTreasury = New System.Windows.Forms.Label()
        Me.lblTreasuryTitle = New System.Windows.Forms.Label()
        Me.lblNotesTitle = New System.Windows.Forms.Label()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblPasswordTitle = New System.Windows.Forms.Label()
        Me.txtPassword = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnlBottom = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnOK = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancel = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlCard.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(560, 50)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(50, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(495, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "تأكيد سند قبض / تنزيل رصيد عميل"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(10, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(35, 34)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "✕"
        '
        'pnlCard
        '
        Me.pnlCard.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.pnlCard.BorderRadius = 10
        Me.pnlCard.BorderThickness = 1
        Me.pnlCard.Controls.Add(Me.lblCustomerName)
        Me.pnlCard.Controls.Add(Me.lblCustomerTitle)
        Me.pnlCard.Controls.Add(Me.lblBalanceBefore)
        Me.pnlCard.Controls.Add(Me.lblBalanceBeforeTitle)
        Me.pnlCard.Controls.Add(Me.lblAmountPaid)
        Me.pnlCard.Controls.Add(Me.lblAmountPaidTitle)
        Me.pnlCard.Controls.Add(Me.lblBalanceAfter)
        Me.pnlCard.Controls.Add(Me.lblBalanceAfterTitle)
        Me.pnlCard.Controls.Add(Me.lblTreasury)
        Me.pnlCard.Controls.Add(Me.lblTreasuryTitle)
        Me.pnlCard.Controls.Add(Me.lblNotesTitle)
        Me.pnlCard.Controls.Add(Me.txtNotes)
        Me.pnlCard.Controls.Add(Me.lblPasswordTitle)
        Me.pnlCard.Controls.Add(Me.txtPassword)
        Me.pnlCard.FillColor = System.Drawing.Color.White
        Me.pnlCard.Location = New System.Drawing.Point(20, 65)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(520, 395)
        Me.pnlCard.TabIndex = 1
        '
        'lblCustomerTitle
        '
        Me.lblCustomerTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCustomerTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblCustomerTitle.Location = New System.Drawing.Point(370, 15)
        Me.lblCustomerTitle.Name = "lblCustomerTitle"
        Me.lblCustomerTitle.Size = New System.Drawing.Size(130, 25)
        Me.lblCustomerTitle.TabIndex = 0
        Me.lblCustomerTitle.Text = "العميل:"
        Me.lblCustomerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerName
        '
        Me.lblCustomerName.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.lblCustomerName.Location = New System.Drawing.Point(20, 15)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(345, 25)
        Me.lblCustomerName.TabIndex = 1
        Me.lblCustomerName.Text = "اسم العميل"
        Me.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBalanceBeforeTitle
        '
        Me.lblBalanceBeforeTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalanceBeforeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblBalanceBeforeTitle.Location = New System.Drawing.Point(370, 55)
        Me.lblBalanceBeforeTitle.Name = "lblBalanceBeforeTitle"
        Me.lblBalanceBeforeTitle.Size = New System.Drawing.Size(130, 25)
        Me.lblBalanceBeforeTitle.TabIndex = 2
        Me.lblBalanceBeforeTitle.Text = "الرصيد السابق:"
        Me.lblBalanceBeforeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBalanceBefore
        '
        Me.lblBalanceBefore.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalanceBefore.ForeColor = System.Drawing.Color.Black
        Me.lblBalanceBefore.Location = New System.Drawing.Point(20, 55)
        Me.lblBalanceBefore.Name = "lblBalanceBefore"
        Me.lblBalanceBefore.Size = New System.Drawing.Size(345, 25)
        Me.lblBalanceBefore.TabIndex = 3
        Me.lblBalanceBefore.Text = "0.00"
        Me.lblBalanceBefore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmountPaidTitle
        '
        Me.lblAmountPaidTitle.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblAmountPaidTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblAmountPaidTitle.Location = New System.Drawing.Point(370, 95)
        Me.lblAmountPaidTitle.Name = "lblAmountPaidTitle"
        Me.lblAmountPaidTitle.Size = New System.Drawing.Size(130, 30)
        Me.lblAmountPaidTitle.TabIndex = 4
        Me.lblAmountPaidTitle.Text = "المبلغ المحصل:"
        Me.lblAmountPaidTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAmountPaid
        '
        Me.lblAmountPaid.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblAmountPaid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblAmountPaid.Location = New System.Drawing.Point(20, 95)
        Me.lblAmountPaid.Name = "lblAmountPaid"
        Me.lblAmountPaid.Size = New System.Drawing.Size(345, 30)
        Me.lblAmountPaid.TabIndex = 5
        Me.lblAmountPaid.Text = "0.00 ج.م"
        Me.lblAmountPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBalanceAfterTitle
        '
        Me.lblBalanceAfterTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalanceAfterTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblBalanceAfterTitle.Location = New System.Drawing.Point(370, 140)
        Me.lblBalanceAfterTitle.Name = "lblBalanceAfterTitle"
        Me.lblBalanceAfterTitle.Size = New System.Drawing.Size(130, 25)
        Me.lblBalanceAfterTitle.TabIndex = 6
        Me.lblBalanceAfterTitle.Text = "الرصيد بعد السداد:"
        Me.lblBalanceAfterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBalanceAfter
        '
        Me.lblBalanceAfter.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalanceAfter.ForeColor = System.Drawing.Color.Black
        Me.lblBalanceAfter.Location = New System.Drawing.Point(20, 140)
        Me.lblBalanceAfter.Name = "lblBalanceAfter"
        Me.lblBalanceAfter.Size = New System.Drawing.Size(345, 25)
        Me.lblBalanceAfter.TabIndex = 7
        Me.lblBalanceAfter.Text = "0.00"
        Me.lblBalanceAfter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTreasuryTitle
        '
        Me.lblTreasuryTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTreasuryTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblTreasuryTitle.Location = New System.Drawing.Point(370, 180)
        Me.lblTreasuryTitle.Name = "lblTreasuryTitle"
        Me.lblTreasuryTitle.Size = New System.Drawing.Size(130, 25)
        Me.lblTreasuryTitle.TabIndex = 8
        Me.lblTreasuryTitle.Text = "الخزينة المودع بها:"
        Me.lblTreasuryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTreasury
        '
        Me.lblTreasury.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.lblTreasury.Location = New System.Drawing.Point(20, 180)
        Me.lblTreasury.Name = "lblTreasury"
        Me.lblTreasury.Size = New System.Drawing.Size(345, 25)
        Me.lblTreasury.TabIndex = 9
        Me.lblTreasury.Text = "الخزينة الرئيسية"
        Me.lblTreasury.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNotesTitle
        '
        Me.lblNotesTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNotesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblNotesTitle.Location = New System.Drawing.Point(370, 220)
        Me.lblNotesTitle.Name = "lblNotesTitle"
        Me.lblNotesTitle.Size = New System.Drawing.Size(130, 25)
        Me.lblNotesTitle.TabIndex = 10
        Me.lblNotesTitle.Text = "ملاحظات العملية:"
        Me.lblNotesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNotes
        '
        Me.txtNotes.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtNotes.BorderRadius = 6
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtNotes.Location = New System.Drawing.Point(20, 220)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNotes.PlaceholderText = "ملاحظات السند (اختياري)..."
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(345, 60)
        Me.txtNotes.TabIndex = 11
        Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPasswordTitle
        '
        Me.lblPasswordTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPasswordTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblPasswordTitle.Location = New System.Drawing.Point(370, 300)
        Me.lblPasswordTitle.Name = "lblPasswordTitle"
        Me.lblPasswordTitle.Size = New System.Drawing.Size(130, 25)
        Me.lblPasswordTitle.TabIndex = 12
        Me.lblPasswordTitle.Text = "تأكيد كلمة المرور:"
        Me.lblPasswordTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPassword
        '
        Me.txtPassword.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtPassword.BorderRadius = 6
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPassword.Location = New System.Drawing.Point(20, 295)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.PlaceholderText = "كلمة مرور المستخدم الحالي..."
        Me.txtPassword.SelectedText = ""
        Me.txtPassword.Size = New System.Drawing.Size(345, 36)
        Me.txtPassword.TabIndex = 13
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlBottom.Controls.Add(Me.btnOK)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 480)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(560, 65)
        Me.pnlBottom.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.BorderRadius = 8
        Me.btnOK.FillColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(290, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(240, 42)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "✔ تأكيد وحفظ السند"
        '
        'btnCancel
        '
        Me.btnCancel.BorderRadius = 8
        Me.btnCancel.FillColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(30, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(240, 42)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "✕ إلغاء"
        '
        'frmConfirmMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(560, 545)
        Me.Controls.Add(Me.pnlCard)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmConfirmMessage"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "تأكيد سند قبض عميل"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlCard.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlCard As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblCustomerTitle As System.Windows.Forms.Label
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblBalanceBeforeTitle As System.Windows.Forms.Label
    Friend WithEvents lblBalanceBefore As System.Windows.Forms.Label
    Friend WithEvents lblAmountPaidTitle As System.Windows.Forms.Label
    Friend WithEvents lblAmountPaid As System.Windows.Forms.Label
    Friend WithEvents lblBalanceAfterTitle As System.Windows.Forms.Label
    Friend WithEvents lblBalanceAfter As System.Windows.Forms.Label
    Friend WithEvents lblTreasuryTitle As System.Windows.Forms.Label
    Friend WithEvents lblTreasury As System.Windows.Forms.Label
    Friend WithEvents lblNotesTitle As System.Windows.Forms.Label
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblPasswordTitle As System.Windows.Forms.Label
    Friend WithEvents txtPassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pnlBottom As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnOK As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button

End Class
