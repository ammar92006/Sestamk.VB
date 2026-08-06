<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTreasuryTransfer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTreasuryTransfer))
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
        Me.btnTransfer = New Guna.UI2.WinForms.Guna2Button()
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.lbltitle = New System.Windows.Forms.Label()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbFromTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbToTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAmount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtNotes = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel1.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.btnClose)
        Me.Guna2Panel1.Controls.Add(Me.btnTransfer)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 485)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Guna2Panel1.Size = New System.Drawing.Size(793, 70)
        Me.Guna2Panel1.TabIndex = 5642
        '
        'btnClose
        '
        Me.btnClose.BorderRadius = 8
        Me.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClose.FillColor = System.Drawing.Color.Gainsboro
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(159, 13)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(180, 45)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "إلغاء"
        '
        'btnTransfer
        '
        Me.btnTransfer.BorderRadius = 8
        Me.btnTransfer.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTransfer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTransfer.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTransfer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnTransfer.FillColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnTransfer.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnTransfer.ForeColor = System.Drawing.Color.Black
        Me.btnTransfer.Location = New System.Drawing.Point(465, 13)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(180, 45)
        Me.btnTransfer.TabIndex = 0
        Me.btnTransfer.Text = "حفظ"
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lbltitle)
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(793, 70)
        Me.panelHeader.TabIndex = 5641
        '
        'lbltitle
        '
        Me.lbltitle.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitle.ForeColor = System.Drawing.Color.White
        Me.lbltitle.Location = New System.Drawing.Point(246, 11)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Size = New System.Drawing.Size(313, 42)
        Me.lbltitle.TabIndex = 6
        Me.lbltitle.Text = "تحويل بين الخزن"
        Me.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_close
        '
        Me.btn_close.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Appearance.Options.UseFont = True
        Me.btn_close.AutoSize = True
        Me.btn_close.ImageOptions.SvgImage = CType(resources.GetObject("btn_close.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_close.Location = New System.Drawing.Point(15, 17)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btn_close.Size = New System.Drawing.Size(38, 36)
        Me.btn_close.TabIndex = 3
        '
        'cmbFromTreasury
        '
        Me.cmbFromTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFromTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbFromTreasury.BorderRadius = 8
        Me.cmbFromTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFromTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFromTreasury.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbFromTreasury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbFromTreasury.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbFromTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbFromTreasury.ItemHeight = 40
        Me.cmbFromTreasury.Location = New System.Drawing.Point(39, 84)
        Me.cmbFromTreasury.Name = "cmbFromTreasury"
        Me.cmbFromTreasury.Size = New System.Drawing.Size(455, 46)
        Me.cmbFromTreasury.TabIndex = 5644
        Me.cmbFromTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(500, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(244, 46)
        Me.Label4.TabIndex = 5643
        Me.Label4.Text = "الخزنة المحوّل منها"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbToTreasury
        '
        Me.cmbToTreasury.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbToTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbToTreasury.BorderRadius = 8
        Me.cmbToTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbToTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbToTreasury.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbToTreasury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbToTreasury.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbToTreasury.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbToTreasury.ItemHeight = 40
        Me.cmbToTreasury.Location = New System.Drawing.Point(39, 150)
        Me.cmbToTreasury.Name = "cmbToTreasury"
        Me.cmbToTreasury.Size = New System.Drawing.Size(455, 46)
        Me.cmbToTreasury.TabIndex = 5646
        Me.cmbToTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(500, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 46)
        Me.Label1.TabIndex = 5645
        Me.Label1.Text = "الخزنة المحوّل إليها"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(500, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(244, 46)
        Me.Label2.TabIndex = 5648
        Me.Label2.Text = "المبلغ المراد تحويله"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.BorderRadius = 8
        Me.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAmount.DefaultText = ""
        Me.txtAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAmount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAmount.Location = New System.Drawing.Point(39, 216)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.PlaceholderText = ""
        Me.txtAmount.SelectedText = ""
        Me.txtAmount.Size = New System.Drawing.Size(455, 46)
        Me.txtAmount.TabIndex = 5647
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel9.AutoSize = False
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(538, 299)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(206, 29)
        Me.Guna2HtmlLabel9.TabIndex = 5650
        Me.Guna2HtmlLabel9.Text = "الملاحظات"
        Me.Guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.BorderRadius = 8
        Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotes.DefaultText = ""
        Me.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.Location = New System.Drawing.Point(39, 337)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.PlaceholderText = ""
        Me.txtNotes.SelectedText = ""
        Me.txtNotes.Size = New System.Drawing.Size(705, 108)
        Me.txtNotes.TabIndex = 5649
        '
        'FrmTreasuryTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 555)
        Me.Controls.Add(Me.Guna2HtmlLabel9)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.cmbToTreasury)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbFromTreasury)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTreasuryTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Guna2Panel1.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTransfer As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lbltitle As Label
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Public WithEvents cmbFromTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label4 As Label
    Public WithEvents cmbToTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAmount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtNotes As Guna.UI2.WinForms.Guna2TextBox
End Class
