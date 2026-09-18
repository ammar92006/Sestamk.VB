<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuickPayment
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQuickPayment))
        Me.panelHeader = New Guna.UI2.WinForms.Guna2Panel()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel7 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnExactAmount = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnConfirm = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel6 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnDot = New Guna.UI2.WinForms.Guna2Button()
        Me.btn0 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnClearInput = New Guna.UI2.WinForms.Guna2Button()
        Me.btn1 = New Guna.UI2.WinForms.Guna2Button()
        Me.btn2 = New Guna.UI2.WinForms.Guna2Button()
        Me.btn3 = New Guna.UI2.WinForms.Guna2Button()
        Me.btn4 = New Guna.UI2.WinForms.Guna2Button()
        Me.btn5 = New Guna.UI2.WinForms.Guna2Button()
        Me.btn6 = New Guna.UI2.WinForms.Guna2Button()
        Me.btn7 = New Guna.UI2.WinForms.Guna2Button()
        Me.btn8 = New Guna.UI2.WinForms.Guna2Button()
        Me.btn9 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.cmbTreasury = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDefaultDiscount = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Guna2Panel8 = New Guna.UI2.WinForms.Guna2Panel()
        Me.rdoCredit = New Guna.UI2.WinForms.Guna2Button()
        Me.rdoCash = New Guna.UI2.WinForms.Guna2Button()
        Me.lblPreviousBalance = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRemaining = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNetTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnPlus200 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPlus100 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPlus50 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPlus10 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPaidInput = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2Panel5.SuspendLayout()
        Me.Guna2Panel7.SuspendLayout()
        Me.Guna2Panel6.SuspendLayout()
        Me.Guna2Panel4.SuspendLayout()
        Me.Guna2Panel8.SuspendLayout()
        Me.Guna2Panel3.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btn_close)
        Me.panelHeader.Controls.Add(Me.Guna2HtmlLabel1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelHeader.Size = New System.Drawing.Size(1280, 70)
        Me.panelHeader.TabIndex = 3
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
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(675, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(67, 42)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "الدفع"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.Guna2Panel5)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Panel4)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Panel3)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Panel2)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 70)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1280, 730)
        Me.Guna2Panel1.TabIndex = 4
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.Controls.Add(Me.Guna2Panel7)
        Me.Guna2Panel5.Controls.Add(Me.Guna2Panel6)
        Me.Guna2Panel5.Location = New System.Drawing.Point(12, 272)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.Size = New System.Drawing.Size(795, 455)
        Me.Guna2Panel5.TabIndex = 3
        '
        'Guna2Panel7
        '
        Me.Guna2Panel7.Controls.Add(Me.btnExactAmount)
        Me.Guna2Panel7.Controls.Add(Me.btnCancel)
        Me.Guna2Panel7.Controls.Add(Me.btnConfirm)
        Me.Guna2Panel7.Location = New System.Drawing.Point(3, 6)
        Me.Guna2Panel7.Name = "Guna2Panel7"
        Me.Guna2Panel7.Size = New System.Drawing.Size(304, 419)
        Me.Guna2Panel7.TabIndex = 5597
        '
        'btnExactAmount
        '
        Me.btnExactAmount.BorderRadius = 8
        Me.btnExactAmount.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnExactAmount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnExactAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnExactAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnExactAmount.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.btnExactAmount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnExactAmount.ForeColor = System.Drawing.Color.White
        Me.btnExactAmount.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnExactAmount.Location = New System.Drawing.Point(10, 3)
        Me.btnExactAmount.Name = "btnExactAmount"
        Me.btnExactAmount.Size = New System.Drawing.Size(291, 153)
        Me.btnExactAmount.TabIndex = 10
        Me.btnExactAmount.Text = "المبلغ بالضبط"
        '
        'btnCancel
        '
        Me.btnCancel.BorderRadius = 8
        Me.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancel.FillColor = System.Drawing.Color.Crimson
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(10, 162)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(291, 85)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "الغاء"
        '
        'btnConfirm
        '
        Me.btnConfirm.BorderRadius = 8
        Me.btnConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnConfirm.FillColor = System.Drawing.Color.LightGreen
        Me.btnConfirm.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.btnConfirm.ForeColor = System.Drawing.Color.White
        Me.btnConfirm.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnConfirm.Location = New System.Drawing.Point(10, 253)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(291, 162)
        Me.btnConfirm.TabIndex = 8
        Me.btnConfirm.Text = "تأكيد الدفع"
        '
        'Guna2Panel6
        '
        Me.Guna2Panel6.Controls.Add(Me.btnDot)
        Me.Guna2Panel6.Controls.Add(Me.btn0)
        Me.Guna2Panel6.Controls.Add(Me.btnClearInput)
        Me.Guna2Panel6.Controls.Add(Me.btn1)
        Me.Guna2Panel6.Controls.Add(Me.btn2)
        Me.Guna2Panel6.Controls.Add(Me.btn3)
        Me.Guna2Panel6.Controls.Add(Me.btn4)
        Me.Guna2Panel6.Controls.Add(Me.btn5)
        Me.Guna2Panel6.Controls.Add(Me.btn6)
        Me.Guna2Panel6.Controls.Add(Me.btn7)
        Me.Guna2Panel6.Controls.Add(Me.btn8)
        Me.Guna2Panel6.Controls.Add(Me.btn9)
        Me.Guna2Panel6.Location = New System.Drawing.Point(310, 3)
        Me.Guna2Panel6.Name = "Guna2Panel6"
        Me.Guna2Panel6.Size = New System.Drawing.Size(481, 422)
        Me.Guna2Panel6.TabIndex = 5596
        '
        'btnDot
        '
        Me.btnDot.BorderRadius = 8
        Me.btnDot.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDot.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDot.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDot.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDot.FillColor = System.Drawing.Color.LightSlateGray
        Me.btnDot.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnDot.ForeColor = System.Drawing.Color.White
        Me.btnDot.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDot.Location = New System.Drawing.Point(4, 318)
        Me.btnDot.Name = "btnDot"
        Me.btnDot.Size = New System.Drawing.Size(150, 100)
        Me.btnDot.TabIndex = 5606
        Me.btnDot.Text = "."
        '
        'btn0
        '
        Me.btn0.BorderRadius = 8
        Me.btn0.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn0.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn0.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn0.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn0.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn0.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn0.ForeColor = System.Drawing.Color.White
        Me.btn0.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn0.Location = New System.Drawing.Point(166, 318)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(150, 100)
        Me.btn0.TabIndex = 5605
        Me.btn0.Text = "0"
        '
        'btnClearInput
        '
        Me.btnClearInput.BorderRadius = 8
        Me.btnClearInput.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearInput.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearInput.FillColor = System.Drawing.Color.SlateGray
        Me.btnClearInput.Font = New System.Drawing.Font("Segoe UI", 30.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearInput.ForeColor = System.Drawing.Color.White
        Me.btnClearInput.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClearInput.Location = New System.Drawing.Point(328, 318)
        Me.btnClearInput.Name = "btnClearInput"
        Me.btnClearInput.Size = New System.Drawing.Size(150, 100)
        Me.btnClearInput.TabIndex = 5604
        Me.btnClearInput.Text = "C"
        '
        'btn1
        '
        Me.btn1.BorderRadius = 8
        Me.btn1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn1.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn1.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn1.ForeColor = System.Drawing.Color.White
        Me.btn1.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn1.Location = New System.Drawing.Point(3, 212)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(150, 100)
        Me.btn1.TabIndex = 5603
        Me.btn1.Text = "1"
        '
        'btn2
        '
        Me.btn2.BorderRadius = 8
        Me.btn2.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn2.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn2.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn2.ForeColor = System.Drawing.Color.White
        Me.btn2.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn2.Location = New System.Drawing.Point(165, 212)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(150, 100)
        Me.btn2.TabIndex = 5602
        Me.btn2.Text = "2"
        '
        'btn3
        '
        Me.btn3.BorderRadius = 8
        Me.btn3.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn3.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn3.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn3.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn3.ForeColor = System.Drawing.Color.White
        Me.btn3.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn3.Location = New System.Drawing.Point(327, 212)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(150, 100)
        Me.btn3.TabIndex = 5601
        Me.btn3.Text = "3"
        '
        'btn4
        '
        Me.btn4.BorderRadius = 8
        Me.btn4.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn4.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn4.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn4.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn4.ForeColor = System.Drawing.Color.White
        Me.btn4.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn4.Location = New System.Drawing.Point(4, 109)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(150, 100)
        Me.btn4.TabIndex = 5600
        Me.btn4.Text = "4"
        '
        'btn5
        '
        Me.btn5.BorderRadius = 8
        Me.btn5.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn5.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn5.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn5.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn5.ForeColor = System.Drawing.Color.White
        Me.btn5.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn5.Location = New System.Drawing.Point(166, 109)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(150, 100)
        Me.btn5.TabIndex = 5599
        Me.btn5.Text = "5"
        '
        'btn6
        '
        Me.btn6.BorderRadius = 8
        Me.btn6.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn6.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn6.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn6.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn6.ForeColor = System.Drawing.Color.White
        Me.btn6.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn6.Location = New System.Drawing.Point(328, 109)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(150, 100)
        Me.btn6.TabIndex = 5598
        Me.btn6.Text = "6"
        '
        'btn7
        '
        Me.btn7.BorderRadius = 8
        Me.btn7.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn7.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn7.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn7.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn7.ForeColor = System.Drawing.Color.White
        Me.btn7.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn7.Location = New System.Drawing.Point(3, 3)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(150, 100)
        Me.btn7.TabIndex = 5597
        Me.btn7.Text = "7"
        '
        'btn8
        '
        Me.btn8.BorderRadius = 8
        Me.btn8.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn8.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn8.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn8.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn8.ForeColor = System.Drawing.Color.White
        Me.btn8.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn8.Location = New System.Drawing.Point(165, 3)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(150, 100)
        Me.btn8.TabIndex = 5596
        Me.btn8.Text = "8"
        '
        'btn9
        '
        Me.btn9.BorderRadius = 8
        Me.btn9.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn9.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn9.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn9.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn9.FillColor = System.Drawing.Color.LightSlateGray
        Me.btn9.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btn9.ForeColor = System.Drawing.Color.White
        Me.btn9.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn9.Location = New System.Drawing.Point(327, 3)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(150, 100)
        Me.btn9.TabIndex = 5595
        Me.btn9.Text = "9"
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.Controls.Add(Me.cmbTreasury)
        Me.Guna2Panel4.Controls.Add(Me.Label10)
        Me.Guna2Panel4.Controls.Add(Me.lblDefaultDiscount)
        Me.Guna2Panel4.Controls.Add(Me.Label9)
        Me.Guna2Panel4.Controls.Add(Me.Guna2Panel8)
        Me.Guna2Panel4.Controls.Add(Me.lblPreviousBalance)
        Me.Guna2Panel4.Controls.Add(Me.Label7)
        Me.Guna2Panel4.Controls.Add(Me.lblRemaining)
        Me.Guna2Panel4.Controls.Add(Me.Label6)
        Me.Guna2Panel4.Controls.Add(Me.lblPaid)
        Me.Guna2Panel4.Controls.Add(Me.Label5)
        Me.Guna2Panel4.Controls.Add(Me.lblNetTotal)
        Me.Guna2Panel4.Controls.Add(Me.Label3)
        Me.Guna2Panel4.Controls.Add(Me.txtDiscount)
        Me.Guna2Panel4.Controls.Add(Me.Label2)
        Me.Guna2Panel4.Controls.Add(Me.lblGrandTotal)
        Me.Guna2Panel4.Controls.Add(Me.Label1)
        Me.Guna2Panel4.Location = New System.Drawing.Point(809, 27)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.Size = New System.Drawing.Size(459, 700)
        Me.Guna2Panel4.TabIndex = 2
        '
        'cmbTreasury
        '
        Me.cmbTreasury.BackColor = System.Drawing.Color.Transparent
        Me.cmbTreasury.BorderRadius = 6
        Me.cmbTreasury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTreasury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTreasury.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbTreasury.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.cmbTreasury.ForeColor = System.Drawing.Color.Black
        Me.cmbTreasury.ItemHeight = 42
        Me.cmbTreasury.Location = New System.Drawing.Point(22, 586)
        Me.cmbTreasury.Name = "cmbTreasury"
        Me.cmbTreasury.Size = New System.Drawing.Size(210, 48)
        Me.cmbTreasury.TabIndex = 5655
        Me.cmbTreasury.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(238, 582)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(210, 50)
        Me.Label10.TabIndex = 5654
        Me.Label10.Text = "الخزنة"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDefaultDiscount
        '
        Me.lblDefaultDiscount.BackColor = System.Drawing.Color.Transparent
        Me.lblDefaultDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDefaultDiscount.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDefaultDiscount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblDefaultDiscount.Location = New System.Drawing.Point(22, 282)
        Me.lblDefaultDiscount.Name = "lblDefaultDiscount"
        Me.lblDefaultDiscount.Size = New System.Drawing.Size(210, 50)
        Me.lblDefaultDiscount.TabIndex = 5653
        Me.lblDefaultDiscount.Text = "0"
        Me.lblDefaultDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(238, 282)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(210, 50)
        Me.Label9.TabIndex = 5652
        Me.Label9.Text = "الخصم الافتراضي"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel8
        '
        Me.Guna2Panel8.Controls.Add(Me.rdoCredit)
        Me.Guna2Panel8.Controls.Add(Me.rdoCash)
        Me.Guna2Panel8.Location = New System.Drawing.Point(22, 636)
        Me.Guna2Panel8.Name = "Guna2Panel8"
        Me.Guna2Panel8.Size = New System.Drawing.Size(426, 61)
        Me.Guna2Panel8.TabIndex = 5651
        '
        'rdoCredit
        '
        Me.rdoCredit.BorderRadius = 8
        Me.rdoCredit.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.rdoCredit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.rdoCredit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.rdoCredit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.rdoCredit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.rdoCredit.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.rdoCredit.ForeColor = System.Drawing.Color.White
        Me.rdoCredit.ImageSize = New System.Drawing.Size(64, 64)
        Me.rdoCredit.Location = New System.Drawing.Point(3, 7)
        Me.rdoCredit.Name = "rdoCredit"
        Me.rdoCredit.Size = New System.Drawing.Size(207, 48)
        Me.rdoCredit.TabIndex = 7
        Me.rdoCredit.Text = "آجل"
        '
        'rdoCash
        '
        Me.rdoCash.BorderRadius = 8
        Me.rdoCash.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.rdoCash.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.rdoCash.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.rdoCash.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.rdoCash.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.rdoCash.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.rdoCash.ForeColor = System.Drawing.Color.White
        Me.rdoCash.ImageSize = New System.Drawing.Size(64, 64)
        Me.rdoCash.Location = New System.Drawing.Point(216, 7)
        Me.rdoCash.Name = "rdoCash"
        Me.rdoCash.Size = New System.Drawing.Size(204, 48)
        Me.rdoCash.TabIndex = 6
        Me.rdoCash.Text = "نقدي"
        '
        'lblPreviousBalance
        '
        Me.lblPreviousBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblPreviousBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreviousBalance.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblPreviousBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblPreviousBalance.Location = New System.Drawing.Point(22, 522)
        Me.lblPreviousBalance.Name = "lblPreviousBalance"
        Me.lblPreviousBalance.Size = New System.Drawing.Size(210, 50)
        Me.lblPreviousBalance.TabIndex = 5650
        Me.lblPreviousBalance.Text = "0.00"
        Me.lblPreviousBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(238, 522)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(210, 50)
        Me.Label7.TabIndex = 5649
        Me.Label7.Text = "الرصيد السابق للعميل"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRemaining
        '
        Me.lblRemaining.BackColor = System.Drawing.Color.Transparent
        Me.lblRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemaining.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblRemaining.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblRemaining.Location = New System.Drawing.Point(22, 462)
        Me.lblRemaining.Name = "lblRemaining"
        Me.lblRemaining.Size = New System.Drawing.Size(210, 50)
        Me.lblRemaining.TabIndex = 5648
        Me.lblRemaining.Text = "0.00"
        Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(238, 462)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(210, 50)
        Me.Label6.TabIndex = 5647
        Me.Label6.Text = "المتبقي على العميل"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPaid
        '
        Me.lblPaid.BackColor = System.Drawing.Color.Transparent
        Me.lblPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaid.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblPaid.Location = New System.Drawing.Point(22, 402)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(210, 50)
        Me.lblPaid.TabIndex = 5646
        Me.lblPaid.Text = "0.00"
        Me.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(238, 402)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 50)
        Me.Label5.TabIndex = 5645
        Me.Label5.Text = "المدفوع"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNetTotal
        '
        Me.lblNetTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblNetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNetTotal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblNetTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblNetTotal.Location = New System.Drawing.Point(22, 342)
        Me.lblNetTotal.Name = "lblNetTotal"
        Me.lblNetTotal.Size = New System.Drawing.Size(210, 50)
        Me.lblNetTotal.TabIndex = 5644
        Me.lblNetTotal.Text = "0.00"
        Me.lblNetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(238, 342)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(210, 50)
        Me.Label3.TabIndex = 5643
        Me.Label3.Text = "الإجمالي بعد الخصم"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDiscount
        '
        Me.txtDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiscount.BorderRadius = 6
        Me.txtDiscount.BorderThickness = 3
        Me.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscount.DefaultText = ""
        Me.txtDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDiscount.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtDiscount.Location = New System.Drawing.Point(22, 222)
        Me.txtDiscount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.PlaceholderText = ""
        Me.txtDiscount.SelectedText = ""
        Me.txtDiscount.Size = New System.Drawing.Size(210, 50)
        Me.txtDiscount.TabIndex = 5642
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(238, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 50)
        Me.Label2.TabIndex = 5641
        Me.Label2.Text = "الخصم"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblGrandTotal.Font = New System.Drawing.Font("Segoe UI", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblGrandTotal.Location = New System.Drawing.Point(13, 118)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(430, 65)
        Me.lblGrandTotal.TabIndex = 5640
        Me.lblGrandTotal.Text = "0.00"
        Me.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 30.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(96, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 65)
        Me.Label1.TabIndex = 5639
        Me.Label1.Text = "المجموع الكلي"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.Controls.Add(Me.btnPlus200)
        Me.Guna2Panel3.Controls.Add(Me.btnPlus100)
        Me.Guna2Panel3.Controls.Add(Me.btnPlus50)
        Me.Guna2Panel3.Controls.Add(Me.btnPlus10)
        Me.Guna2Panel3.Location = New System.Drawing.Point(12, 166)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.Size = New System.Drawing.Size(795, 100)
        Me.Guna2Panel3.TabIndex = 1
        '
        'btnPlus200
        '
        Me.btnPlus200.BorderRadius = 10
        Me.btnPlus200.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPlus200.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPlus200.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPlus200.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPlus200.FillColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnPlus200.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnPlus200.ForeColor = System.Drawing.Color.White
        Me.btnPlus200.Location = New System.Drawing.Point(16, 17)
        Me.btnPlus200.Name = "btnPlus200"
        Me.btnPlus200.Size = New System.Drawing.Size(178, 62)
        Me.btnPlus200.TabIndex = 5595
        Me.btnPlus200.Text = "200+"
        '
        'btnPlus100
        '
        Me.btnPlus100.BorderRadius = 10
        Me.btnPlus100.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPlus100.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPlus100.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPlus100.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPlus100.FillColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnPlus100.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnPlus100.ForeColor = System.Drawing.Color.White
        Me.btnPlus100.Location = New System.Drawing.Point(209, 17)
        Me.btnPlus100.Name = "btnPlus100"
        Me.btnPlus100.Size = New System.Drawing.Size(178, 62)
        Me.btnPlus100.TabIndex = 5594
        Me.btnPlus100.Text = "100+"
        '
        'btnPlus50
        '
        Me.btnPlus50.BorderRadius = 10
        Me.btnPlus50.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPlus50.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPlus50.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPlus50.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPlus50.FillColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnPlus50.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnPlus50.ForeColor = System.Drawing.Color.White
        Me.btnPlus50.Location = New System.Drawing.Point(402, 17)
        Me.btnPlus50.Name = "btnPlus50"
        Me.btnPlus50.Size = New System.Drawing.Size(178, 62)
        Me.btnPlus50.TabIndex = 5593
        Me.btnPlus50.Text = "50+"
        '
        'btnPlus10
        '
        Me.btnPlus10.BorderRadius = 10
        Me.btnPlus10.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPlus10.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPlus10.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPlus10.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPlus10.FillColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnPlus10.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnPlus10.ForeColor = System.Drawing.Color.White
        Me.btnPlus10.Location = New System.Drawing.Point(595, 17)
        Me.btnPlus10.Name = "btnPlus10"
        Me.btnPlus10.Size = New System.Drawing.Size(178, 62)
        Me.btnPlus10.TabIndex = 5592
        Me.btnPlus10.Text = "10+"
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.Label8)
        Me.Guna2Panel2.Controls.Add(Me.txtPaidInput)
        Me.Guna2Panel2.Location = New System.Drawing.Point(12, 26)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(795, 121)
        Me.Guna2Panel2.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(643, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 21)
        Me.Label8.TabIndex = 5638
        Me.Label8.Text = "أدخل المبلغ المستلم"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPaidInput
        '
        Me.txtPaidInput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaidInput.BorderRadius = 6
        Me.txtPaidInput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaidInput.DefaultText = ""
        Me.txtPaidInput.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPaidInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPaidInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaidInput.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaidInput.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPaidInput.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtPaidInput.ForeColor = System.Drawing.Color.Black
        Me.txtPaidInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.txtPaidInput.Location = New System.Drawing.Point(25, 18)
        Me.txtPaidInput.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPaidInput.Name = "txtPaidInput"
        Me.txtPaidInput.PlaceholderText = ""
        Me.txtPaidInput.SelectedText = ""
        Me.txtPaidInput.Size = New System.Drawing.Size(749, 97)
        Me.txtPaidInput.TabIndex = 5637
        Me.txtPaidInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 8
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'FrmQuickPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 800)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmQuickPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel5.ResumeLayout(False)
        Me.Guna2Panel7.ResumeLayout(False)
        Me.Guna2Panel6.ResumeLayout(False)
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel8.ResumeLayout(False)
        Me.Guna2Panel3.ResumeLayout(False)
        Me.Guna2Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtPaidInput As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnPlus200 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPlus100 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPlus50 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPlus10 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn9 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel6 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnDot As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn0 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClearInput As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn4 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn5 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn6 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn7 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn8 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel7 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnExactAmount As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnConfirm As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblRemaining As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblPaid As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblNetTotal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDiscount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Panel8 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblPreviousBalance As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents rdoCredit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents rdoCash As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblDefaultDiscount As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbTreasury As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
