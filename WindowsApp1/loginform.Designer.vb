<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundActivationTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pn_0 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblSideCopyright = New System.Windows.Forms.Label()
        Me.pn_main = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cmbUsername = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnclose = New Guna.UI2.WinForms.Guna2Button()
        Me.btnThemeToggle = New Guna.UI2.WinForms.Guna2Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnsup = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnlogin = New Guna.UI2.WinForms.Guna2Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpassword = New Guna.UI2.WinForms.Guna2TextBox()
        Me.CheckBox1 = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.lblusername = New System.Windows.Forms.Label()
        Me.lblpassword = New System.Windows.Forms.Label()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.pn_0.SuspendLayout()
        Me.pn_main.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundActivationTimer
        '
        '
        'pn_0
        '
        Me.pn_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.pn_0.Controls.Add(Me.lblSideCopyright)
        Me.pn_0.Controls.Add(Me.lblDesc)
        Me.pn_0.Controls.Add(Me.lblBrand)
        Me.pn_0.Controls.Add(Me.lblWelcome)
        Me.pn_0.Dock = System.Windows.Forms.DockStyle.Left
        Me.pn_0.Location = New System.Drawing.Point(0, 0)
        Me.pn_0.Name = "pn_0"
        Me.pn_0.Size = New System.Drawing.Size(560, 800)
        Me.pn_0.TabIndex = 0
        '
        'lblWelcome
        '
        Me.lblWelcome.BackColor = System.Drawing.Color.Transparent
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblWelcome.ForeColor = System.Drawing.Color.White
        Me.lblWelcome.Location = New System.Drawing.Point(80, 250)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(400, 55)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "مرحباً بك"
        Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBrand
        '
        Me.lblBrand.BackColor = System.Drawing.Color.Transparent
        Me.lblBrand.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Regular)
        Me.lblBrand.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.lblBrand.Location = New System.Drawing.Point(80, 310)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(400, 45)
        Me.lblBrand.TabIndex = 1
        Me.lblBrand.Text = "في نظام سستامك"
        Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDesc
        '
        Me.lblDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblDesc.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular)
        Me.lblDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblDesc.Location = New System.Drawing.Point(80, 390)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(400, 60)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "نظام متكامل لإدارة نقاط البيع والمطاعم" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "بأحدث التقنيات وأسهل الطرق"
        Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSideCopyright
        '
        Me.lblSideCopyright.BackColor = System.Drawing.Color.Transparent
        Me.lblSideCopyright.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular)
        Me.lblSideCopyright.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblSideCopyright.Location = New System.Drawing.Point(80, 740)
        Me.lblSideCopyright.Name = "lblSideCopyright"
        Me.lblSideCopyright.Size = New System.Drawing.Size(400, 25)
        Me.lblSideCopyright.TabIndex = 3
        Me.lblSideCopyright.Text = "Sestamk © 2026"
        Me.lblSideCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pn_main
        '
        Me.pn_main.Controls.Add(Me.Guna2PictureBox1)
        Me.pn_main.Controls.Add(Me.cmbUsername)
        Me.pn_main.Controls.Add(Me.btnclose)
        Me.pn_main.Controls.Add(Me.btnThemeToggle)
        Me.pn_main.Controls.Add(Me.Label4)
        Me.pn_main.Controls.Add(Me.btnsup)
        Me.pn_main.Controls.Add(Me.Label1)
        Me.pn_main.Controls.Add(Me.Guna2Panel1)
        Me.pn_main.Controls.Add(Me.btnlogin)
        Me.pn_main.Controls.Add(Me.Label2)
        Me.pn_main.Controls.Add(Me.txtpassword)
        Me.pn_main.Controls.Add(Me.CheckBox1)
        Me.pn_main.Controls.Add(Me.lblusername)
        Me.pn_main.Controls.Add(Me.lblpassword)
        Me.pn_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pn_main.Location = New System.Drawing.Point(560, 0)
        Me.pn_main.Name = "pn_main"
        Me.pn_main.Size = New System.Drawing.Size(720, 800)
        Me.pn_main.TabIndex = 1
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.FillColor = System.Drawing.Color.Empty
        Me.Guna2PictureBox1.Image = Global.WindowsApp1.My.Resources.Resources.loge
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(270, 50)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(180, 180)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Guna2PictureBox1.TabIndex = 26
        Me.Guna2PictureBox1.TabStop = False
        '
        'cmbUsername
        '
        Me.cmbUsername.BackColor = System.Drawing.Color.Transparent
        Me.cmbUsername.BorderColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.cmbUsername.BorderRadius = 10
        Me.cmbUsername.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsername.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.cmbUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.cmbUsername.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.cmbUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.cmbUsername.ItemHeight = 32
        Me.cmbUsername.Location = New System.Drawing.Point(135, 380)
        Me.cmbUsername.Name = "cmbUsername"
        Me.cmbUsername.Size = New System.Drawing.Size(450, 38)
        Me.cmbUsername.TabIndex = 32
        Me.cmbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnclose
        '
        Me.btnclose.BorderRadius = 14
        Me.btnclose.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnclose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnclose.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnclose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnclose.FillColor = System.Drawing.Color.Transparent
        Me.btnclose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnclose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.btnclose.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnclose.HoverState.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(16, 16)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(38, 38)
        Me.btnclose.TabIndex = 31
        Me.btnclose.Text = "✕"
        Me.btnclose.TextOffset = New System.Drawing.Point(0, 0)
        '
        'btnThemeToggle
        '
        Me.btnThemeToggle.BorderRadius = 14
        Me.btnThemeToggle.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnThemeToggle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnThemeToggle.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnThemeToggle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnThemeToggle.FillColor = System.Drawing.Color.Transparent
        Me.btnThemeToggle.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.btnThemeToggle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnThemeToggle.Location = New System.Drawing.Point(60, 16)
        Me.btnThemeToggle.Name = "btnThemeToggle"
        Me.btnThemeToggle.Size = New System.Drawing.Size(38, 38)
        Me.btnThemeToggle.TabIndex = 33
        Me.btnThemeToggle.Text = "🌙"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(135, 765)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(450, 25)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "جميع الحقوق محفوظة © سستامك 2026"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnsup
        '
        Me.btnsup.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnsup.BorderRadius = 10
        Me.btnsup.BorderThickness = 1
        Me.btnsup.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnsup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnsup.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnsup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnsup.FillColor = System.Drawing.Color.Empty
        Me.btnsup.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnsup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnsup.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnsup.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnsup.Image = Global.WindowsApp1.My.Resources.Resources.customer_support
        Me.btnsup.ImageOffset = New System.Drawing.Point(-5, 0)
        Me.btnsup.ImageSize = New System.Drawing.Size(22, 22)
        Me.btnsup.Location = New System.Drawing.Point(225, 715)
        Me.btnsup.Name = "btnsup"
        Me.btnsup.Size = New System.Drawing.Size(270, 40)
        Me.btnsup.TabIndex = 29
        Me.btnsup.Text = "اتصل بالدعم الفني"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(252, 680)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "تواجه مشكلة في تسجيل الدخول؟"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.FillColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Guna2Panel1.Location = New System.Drawing.Point(135, 660)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(450, 2)
        Me.Guna2Panel1.TabIndex = 0
        '
        'btnlogin
        '
        Me.btnlogin.BorderRadius = 10
        Me.btnlogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnlogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnlogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnlogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnlogin.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.btnlogin.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnlogin.ForeColor = System.Drawing.Color.White
        Me.btnlogin.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnlogin.Image = Global.WindowsApp1.My.Resources.Resources.enter__1_
        Me.btnlogin.ImageSize = New System.Drawing.Size(26, 26)
        Me.btnlogin.Location = New System.Drawing.Point(135, 590)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.PressedColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnlogin.Size = New System.Drawing.Size(450, 50)
        Me.btnlogin.TabIndex = 27
        Me.btnlogin.Text = "تسجيل الدخول"
        Me.btnlogin.TextOffset = New System.Drawing.Point(5, 0)
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(260, 290)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 30)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "إدارة مطعمك بذكاء"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtpassword
        '
        Me.txtpassword.BorderColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.txtpassword.BorderRadius = 10
        Me.txtpassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtpassword.DefaultText = ""
        Me.txtpassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtpassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtpassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtpassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtpassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.txtpassword.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.txtpassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.txtpassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.txtpassword.Location = New System.Drawing.Point(135, 490)
        Me.txtpassword.Margin = New System.Windows.Forms.Padding(6)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.txtpassword.PlaceholderText = "أدخل كلمة المرور"
        Me.txtpassword.SelectedText = ""
        Me.txtpassword.Size = New System.Drawing.Size(450, 38)
        Me.txtpassword.TabIndex = 23
        Me.txtpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtpassword.UseSystemPasswordChar = True
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.CheckedState.BorderRadius = 4
        Me.CheckBox1.CheckedState.BorderThickness = 0
        Me.CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(435, 534)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(150, 26)
        Me.CheckBox1.TabIndex = 21
        Me.CheckBox1.Text = "إظهار كلمة المرور"
        Me.CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.CheckBox1.UncheckedState.BorderRadius = 4
        Me.CheckBox1.UncheckedState.BorderThickness = 1
        Me.CheckBox1.UncheckedState.FillColor = System.Drawing.Color.Transparent
        '
        'lblusername
        '
        Me.lblusername.BackColor = System.Drawing.Color.Transparent
        Me.lblusername.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblusername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblusername.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblusername.Location = New System.Drawing.Point(420, 345)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(165, 30)
        Me.lblusername.TabIndex = 16
        Me.lblusername.Text = "اسم المستخدم"
        Me.lblusername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblpassword
        '
        Me.lblpassword.BackColor = System.Drawing.Color.Transparent
        Me.lblpassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblpassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblpassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblpassword.Location = New System.Drawing.Point(420, 455)
        Me.lblpassword.Name = "lblpassword"
        Me.lblpassword.Size = New System.Drawing.Size(165, 30)
        Me.lblpassword.TabIndex = 17
        Me.lblpassword.Text = "كلمة المرور"
        Me.lblpassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 25
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1280, 800)
        Me.Controls.Add(Me.pn_main)
        Me.Controls.Add(Me.pn_0)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pn_main.ResumeLayout(False)
        Me.pn_0.ResumeLayout(False)
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BackgroundActivationTimer As Timer
    Friend WithEvents pn_0 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblBrand As Label
    Friend WithEvents lblDesc As Label
    Friend WithEvents lblSideCopyright As Label
    Friend WithEvents pn_main As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtpassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents CheckBox1 As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents lblusername As Label
    Friend WithEvents lblpassword As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents btnlogin As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents btnsup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnclose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnThemeToggle As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents cmbUsername As Guna.UI2.WinForms.Guna2ComboBox
End Class
