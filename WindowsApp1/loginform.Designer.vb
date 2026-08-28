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
        Me.pn_main = New Guna.UI2.WinForms.Guna2Panel()
        Me.cmbUsername = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpassword = New Guna.UI2.WinForms.Guna2TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.lblusername = New System.Windows.Forms.Label()
        Me.lblpassword = New System.Windows.Forms.Label()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.btnclose = New Guna.UI2.WinForms.Guna2Button()
        Me.btnsup = New Guna.UI2.WinForms.Guna2Button()
        Me.btnlogin = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.pn_main.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundActivationTimer
        '
        '
        'pn_0
        '
        Me.pn_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pn_0.Dock = System.Windows.Forms.DockStyle.Left
        Me.pn_0.Location = New System.Drawing.Point(0, 0)
        Me.pn_0.Name = "pn_0"
        Me.pn_0.Size = New System.Drawing.Size(560, 800)
        Me.pn_0.TabIndex = 0
        '
        'pn_main
        '
        Me.pn_main.Controls.Add(Me.Guna2PictureBox1)
        Me.pn_main.Controls.Add(Me.cmbUsername)
        Me.pn_main.Controls.Add(Me.btnclose)
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
        'cmbUsername
        '
        Me.cmbUsername.BackColor = System.Drawing.Color.Transparent
        Me.cmbUsername.BorderRadius = 8
        Me.cmbUsername.BorderThickness = 2
        Me.cmbUsername.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsername.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbUsername.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.cmbUsername.ForeColor = System.Drawing.Color.Black
        Me.cmbUsername.ItemHeight = 36
        Me.cmbUsername.Location = New System.Drawing.Point(61, 384)
        Me.cmbUsername.Name = "cmbUsername"
        Me.cmbUsername.Size = New System.Drawing.Size(604, 42)
        Me.cmbUsername.TabIndex = 32
        Me.cmbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(514, 760)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 31)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "© Sestamk 2026 "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(219, 682)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(295, 31)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "تواجه مشكلة في تسجيل الدخول؟"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.FillColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Guna2Panel1.Location = New System.Drawing.Point(61, 664)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(604, 5)
        Me.Guna2Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(287, 290)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 35)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "إدارة مطعمك بذكاء"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtpassword
        '
        Me.txtpassword.BorderRadius = 8
        Me.txtpassword.BorderThickness = 3
        Me.txtpassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtpassword.DefaultText = ""
        Me.txtpassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtpassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtpassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtpassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtpassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtpassword.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtpassword.ForeColor = System.Drawing.Color.Black
        Me.txtpassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtpassword.Location = New System.Drawing.Point(61, 490)
        Me.txtpassword.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PlaceholderText = ""
        Me.txtpassword.SelectedText = ""
        Me.txtpassword.Size = New System.Drawing.Size(604, 42)
        Me.txtpassword.TabIndex = 23
        Me.txtpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtpassword.UseSystemPasswordChar = True
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.CheckBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(502, 536)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(163, 32)
        Me.CheckBox1.TabIndex = 21
        Me.CheckBox1.Text = "اظهار كلمة المرور"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'lblusername
        '
        Me.lblusername.BackColor = System.Drawing.Color.Transparent
        Me.lblusername.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblusername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblusername.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblusername.Location = New System.Drawing.Point(473, 339)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(192, 42)
        Me.lblusername.TabIndex = 16
        Me.lblusername.Text = "اسم المستخدم"
        Me.lblusername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblpassword
        '
        Me.lblpassword.BackColor = System.Drawing.Color.Transparent
        Me.lblpassword.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblpassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblpassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblpassword.Location = New System.Drawing.Point(473, 444)
        Me.lblpassword.Name = "lblpassword"
        Me.lblpassword.Size = New System.Drawing.Size(192, 42)
        Me.lblpassword.TabIndex = 17
        Me.lblpassword.Text = "كلمة المرور"
        Me.lblpassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 10
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'btnclose
        '
        Me.btnclose.BorderRadius = 8
        Me.btnclose.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnclose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnclose.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnclose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnclose.FillColor = System.Drawing.Color.Empty
        Me.btnclose.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Image = Global.WindowsApp1.My.Resources.Resources.close3
        Me.btnclose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnclose.Location = New System.Drawing.Point(12, 12)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(81, 72)
        Me.btnclose.TabIndex = 31
        Me.btnclose.TextOffset = New System.Drawing.Point(10, 0)
        '
        'btnsup
        '
        Me.btnsup.BorderColor = System.Drawing.Color.BurlyWood
        Me.btnsup.BorderRadius = 8
        Me.btnsup.BorderThickness = 2
        Me.btnsup.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnsup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnsup.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnsup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnsup.FillColor = System.Drawing.Color.Empty
        Me.btnsup.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnsup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.btnsup.Image = Global.WindowsApp1.My.Resources.Resources.customer_support
        Me.btnsup.ImageOffset = New System.Drawing.Point(-5, 0)
        Me.btnsup.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnsup.Location = New System.Drawing.Point(219, 728)
        Me.btnsup.Name = "btnsup"
        Me.btnsup.Size = New System.Drawing.Size(285, 45)
        Me.btnsup.TabIndex = 29
        Me.btnsup.Text = "اتصل بالدعم الفني"
        '
        'btnlogin
        '
        Me.btnlogin.BorderRadius = 8
        Me.btnlogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnlogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnlogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnlogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnlogin.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.btnlogin.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.btnlogin.ForeColor = System.Drawing.Color.White
        Me.btnlogin.Image = Global.WindowsApp1.My.Resources.Resources.enter__1_
        Me.btnlogin.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnlogin.Location = New System.Drawing.Point(61, 591)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(604, 55)
        Me.btnlogin.TabIndex = 27
        Me.btnlogin.Text = "تسجيل الدخول"
        Me.btnlogin.TextOffset = New System.Drawing.Point(10, 0)
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.FillColor = System.Drawing.Color.Empty
        Me.Guna2PictureBox1.Image = Global.WindowsApp1.My.Resources.Resources.loge
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(250, 12)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(264, 264)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Guna2PictureBox1.TabIndex = 26
        Me.Guna2PictureBox1.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
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
        Me.pn_main.PerformLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BackgroundActivationTimer As Timer
    Friend WithEvents pn_0 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pn_main As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtpassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents CheckBox1 As CheckBox
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
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents cmbUsername As Guna.UI2.WinForms.Guna2ComboBox
End Class
