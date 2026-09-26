<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectKitchenComment
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
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblProductSub = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.pnlFooter = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnManage = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnApply = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlContent = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblPresetsHeader = New System.Windows.Forms.Label()
        Me.pnlCardsContainer = New Guna.UI2.WinForms.Guna2Panel()
        Me.flpComments = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblQuickAddHeader = New System.Windows.Forms.Label()
        Me.pnlQuickAdd = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnQuickAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.txtNewComment = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblFinalNoteHeader = New System.Windows.Forms.Label()
        Me.txtFinalNote = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlCardsContainer.SuspendLayout()
        Me.pnlQuickAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblProductSub)
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Controls.Add(Me.btnClose)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(680, 68)
        Me.panelHeader.TabIndex = 0
        '
        'lblProductSub
        '
        Me.lblProductSub.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProductSub.BackColor = System.Drawing.Color.Transparent
        Me.lblProductSub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblProductSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblProductSub.Location = New System.Drawing.Point(60, 36)
        Me.lblProductSub.Name = "lblProductSub"
        Me.lblProductSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblProductSub.Size = New System.Drawing.Size(600, 22)
        Me.lblProductSub.TabIndex = 2
        Me.lblProductSub.Text = "الصنف: بيتزا مشكل جبن"
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(60, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitle.Size = New System.Drawing.Size(600, 28)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "تعليقات وملاحظات المطبخ 📝"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.FillColor = System.Drawing.Color.Transparent
        Me.btnClose.IconColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(12, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 34)
        Me.btnClose.TabIndex = 0
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.pnlFooter.BorderThickness = 1
        Me.pnlFooter.Controls.Add(Me.btnManage)
        Me.pnlFooter.Controls.Add(Me.btnClear)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Controls.Add(Me.btnApply)
        Me.pnlFooter.CustomBorderThickness = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 570)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlFooter.Size = New System.Drawing.Size(680, 65)
        Me.pnlFooter.TabIndex = 2
        '
        'btnManage
        '
        Me.btnManage.BorderRadius = 8
        Me.btnManage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManage.FillColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnManage.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnManage.ForeColor = System.Drawing.Color.White
        Me.btnManage.Location = New System.Drawing.Point(16, 12)
        Me.btnManage.Name = "btnManage"
        Me.btnManage.Size = New System.Drawing.Size(125, 42)
        Me.btnManage.TabIndex = 3
        Me.btnManage.Text = "إدارة التعليقات ⚙️"
        '
        'btnClear
        '
        Me.btnClear.BorderRadius = 8
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(150, 12)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(110, 42)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "مسح الملاحظة ❌"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BorderRadius = 8
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FillColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnCancel.Location = New System.Drawing.Point(380, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(110, 42)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "إلغاء"
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.BorderRadius = 8
        Me.btnApply.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApply.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btnApply.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnApply.ForeColor = System.Drawing.Color.White
        Me.btnApply.Location = New System.Drawing.Point(500, 12)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(165, 42)
        Me.btnApply.TabIndex = 0
        Me.btnApply.Text = "تطبيق الملاحظة ✔️"
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.Transparent
        Me.pnlContent.Controls.Add(Me.lblFinalNoteHeader)
        Me.pnlContent.Controls.Add(Me.txtFinalNote)
        Me.pnlContent.Controls.Add(Me.lblQuickAddHeader)
        Me.pnlContent.Controls.Add(Me.pnlQuickAdd)
        Me.pnlContent.Controls.Add(Me.lblPresetsHeader)
        Me.pnlContent.Controls.Add(Me.pnlCardsContainer)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 68)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.pnlContent.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlContent.Size = New System.Drawing.Size(680, 502)
        Me.pnlContent.TabIndex = 1
        '
        'lblPresetsHeader
        '
        Me.lblPresetsHeader.AutoSize = True
        Me.lblPresetsHeader.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblPresetsHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblPresetsHeader.Location = New System.Drawing.Point(490, 8)
        Me.lblPresetsHeader.Name = "lblPresetsHeader"
        Me.lblPresetsHeader.Size = New System.Drawing.Size(175, 20)
        Me.lblPresetsHeader.TabIndex = 0
        Me.lblPresetsHeader.Text = "التعليقات والملاحظات الجاهزة:"
        '
        'pnlCardsContainer
        '
        Me.pnlCardsContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCardsContainer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.pnlCardsContainer.BorderRadius = 10
        Me.pnlCardsContainer.BorderThickness = 1
        Me.pnlCardsContainer.Controls.Add(Me.flpComments)
        Me.pnlCardsContainer.FillColor = System.Drawing.Color.White
        Me.pnlCardsContainer.Location = New System.Drawing.Point(16, 32)
        Me.pnlCardsContainer.Name = "pnlCardsContainer"
        Me.pnlCardsContainer.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlCardsContainer.Size = New System.Drawing.Size(648, 260)
        Me.pnlCardsContainer.TabIndex = 1
        '
        'flpComments
        '
        Me.flpComments.AutoScroll = True
        Me.flpComments.BackColor = System.Drawing.Color.Transparent
        Me.flpComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpComments.Location = New System.Drawing.Point(8, 8)
        Me.flpComments.Name = "flpComments"
        Me.flpComments.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.flpComments.Size = New System.Drawing.Size(632, 244)
        Me.flpComments.TabIndex = 0
        '
        'lblQuickAddHeader
        '
        Me.lblQuickAddHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuickAddHeader.AutoSize = True
        Me.lblQuickAddHeader.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblQuickAddHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblQuickAddHeader.Location = New System.Drawing.Point(490, 302)
        Me.lblQuickAddHeader.Name = "lblQuickAddHeader"
        Me.lblQuickAddHeader.Size = New System.Drawing.Size(175, 19)
        Me.lblQuickAddHeader.TabIndex = 2
        Me.lblQuickAddHeader.Text = "إضافة تعليق جديد سريعاً وحفظه:"
        '
        'pnlQuickAdd
        '
        Me.pnlQuickAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlQuickAdd.Controls.Add(Me.btnQuickAdd)
        Me.pnlQuickAdd.Controls.Add(Me.txtNewComment)
        Me.pnlQuickAdd.Location = New System.Drawing.Point(16, 325)
        Me.pnlQuickAdd.Name = "pnlQuickAdd"
        Me.pnlQuickAdd.Size = New System.Drawing.Size(648, 44)
        Me.pnlQuickAdd.TabIndex = 3
        '
        'btnQuickAdd
        '
        Me.btnQuickAdd.BorderRadius = 8
        Me.btnQuickAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuickAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnQuickAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btnQuickAdd.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnQuickAdd.ForeColor = System.Drawing.Color.White
        Me.btnQuickAdd.Location = New System.Drawing.Point(0, 0)
        Me.btnQuickAdd.Name = "btnQuickAdd"
        Me.btnQuickAdd.Size = New System.Drawing.Size(155, 44)
        Me.btnQuickAdd.TabIndex = 1
        Me.btnQuickAdd.Text = "إضافة للقائمة ➕"
        '
        'txtNewComment
        '
        Me.txtNewComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewComment.BorderRadius = 8
        Me.txtNewComment.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNewComment.DefaultText = ""
        Me.txtNewComment.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.txtNewComment.ForeColor = System.Drawing.Color.Black
        Me.txtNewComment.Location = New System.Drawing.Point(165, 2)
        Me.txtNewComment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNewComment.Name = "txtNewComment"
        Me.txtNewComment.PlaceholderText = "اكتب تعليقاً جديداً ليتم إدراجه وحفظه تلقائياً..."
        Me.txtNewComment.SelectedText = ""
        Me.txtNewComment.Size = New System.Drawing.Size(483, 40)
        Me.txtNewComment.TabIndex = 0
        '
        'lblFinalNoteHeader
        '
        Me.lblFinalNoteHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFinalNoteHeader.AutoSize = True
        Me.lblFinalNoteHeader.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblFinalNoteHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblFinalNoteHeader.Location = New System.Drawing.Point(475, 377)
        Me.lblFinalNoteHeader.Name = "lblFinalNoteHeader"
        Me.lblFinalNoteHeader.Size = New System.Drawing.Size(190, 19)
        Me.lblFinalNoteHeader.TabIndex = 4
        Me.lblFinalNoteHeader.Text = "نص الملاحظة النهائي المرسل للمطبخ:"
        '
        'txtFinalNote
        '
        Me.txtFinalNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFinalNote.BorderRadius = 8
        Me.txtFinalNote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFinalNote.DefaultText = ""
        Me.txtFinalNote.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtFinalNote.ForeColor = System.Drawing.Color.Black
        Me.txtFinalNote.Location = New System.Drawing.Point(16, 401)
        Me.txtFinalNote.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFinalNote.Multiline = True
        Me.txtFinalNote.Name = "txtFinalNote"
        Me.txtFinalNote.PlaceholderText = "يمكنك التعديل أو كتابة أي ملاحظة يدوية إضافية هنا..."
        Me.txtFinalNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFinalNote.SelectedText = ""
        Me.txtFinalNote.Size = New System.Drawing.Size(648, 85)
        Me.txtFinalNote.TabIndex = 5
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 14
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'frmSelectKitchenComment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(680, 635)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSelectKitchenComment"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "اختيار تعليق المطبخ"
        Me.panelHeader.ResumeLayout(False)
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.pnlCardsContainer.ResumeLayout(False)
        Me.pnlQuickAdd.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblProductSub As System.Windows.Forms.Label
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents pnlFooter As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnApply As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnManage As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlContent As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblPresetsHeader As System.Windows.Forms.Label
    Friend WithEvents pnlCardsContainer As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents flpComments As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblQuickAddHeader As System.Windows.Forms.Label
    Friend WithEvents pnlQuickAdd As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtNewComment As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnQuickAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblFinalNoteHeader As System.Windows.Forms.Label
    Friend WithEvents txtFinalNote As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
