<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_new_user
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(add_new_user))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pn_title_page = New System.Windows.Forms.Label()
        Me.btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpCustomerInfo = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_delet_barcode = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_barcode_print = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbRoleName = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btn_barcode_new = New DevExpress.XtraEditors.SimpleButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pic_Barcode = New System.Windows.Forms.PictureBox()
        Me.btnSelectImage = New DevExpress.XtraEditors.SimpleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pic_user = New System.Windows.Forms.PictureBox()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtUser_Note = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUser_password = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_clean = New DevExpress.XtraEditors.SimpleButton()
        Me.lblStatus = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.chkUser_Stats = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Guna2HtmlLabel8 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtUser_username = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtUser_Name = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtUser_Code = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Panel1.SuspendLayout()
        Me.grpCustomerInfo.SuspendLayout()
        CType(Me.pic_Barcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel1.Controls.Add(Me.pn_title_page)
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1600, 72)
        Me.Panel1.TabIndex = 0
        '
        'pn_title_page
        '
        Me.pn_title_page.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pn_title_page.AutoSize = True
        Me.pn_title_page.Font = New System.Drawing.Font("LBC", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pn_title_page.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.pn_title_page.Location = New System.Drawing.Point(667, 9)
        Me.pn_title_page.Name = "pn_title_page"
        Me.pn_title_page.Size = New System.Drawing.Size(371, 51)
        Me.pn_title_page.TabIndex = 4
        Me.pn_title_page.Text = "اضافة مستخدم جديد"
        Me.pn_title_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btn_close.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 690)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1600, 60)
        Me.Panel2.TabIndex = 1
        '
        'grpCustomerInfo
        '
        Me.grpCustomerInfo.Controls.Add(Me.btnNew)
        Me.grpCustomerInfo.Controls.Add(Me.btn_delet_barcode)
        Me.grpCustomerInfo.Controls.Add(Me.btn_barcode_print)
        Me.grpCustomerInfo.Controls.Add(Me.cmbRoleName)
        Me.grpCustomerInfo.Controls.Add(Me.btn_barcode_new)
        Me.grpCustomerInfo.Controls.Add(Me.Label7)
        Me.grpCustomerInfo.Controls.Add(Me.pic_Barcode)
        Me.grpCustomerInfo.Controls.Add(Me.btnSelectImage)
        Me.grpCustomerInfo.Controls.Add(Me.Label6)
        Me.grpCustomerInfo.Controls.Add(Me.pic_user)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel9)
        Me.grpCustomerInfo.Controls.Add(Me.txtUser_Note)
        Me.grpCustomerInfo.Controls.Add(Me.Label5)
        Me.grpCustomerInfo.Controls.Add(Me.Label4)
        Me.grpCustomerInfo.Controls.Add(Me.txtUser_password)
        Me.grpCustomerInfo.Controls.Add(Me.Label3)
        Me.grpCustomerInfo.Controls.Add(Me.Label2)
        Me.grpCustomerInfo.Controls.Add(Me.Label1)
        Me.grpCustomerInfo.Controls.Add(Me.btn_clean)
        Me.grpCustomerInfo.Controls.Add(Me.lblStatus)
        Me.grpCustomerInfo.Controls.Add(Me.chkUser_Stats)
        Me.grpCustomerInfo.Controls.Add(Me.Guna2HtmlLabel8)
        Me.grpCustomerInfo.Controls.Add(Me.txtUser_username)
        Me.grpCustomerInfo.Controls.Add(Me.txtUser_Name)
        Me.grpCustomerInfo.Controls.Add(Me.txtUser_Code)
        Me.grpCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCustomerInfo.FillColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.grpCustomerInfo.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.grpCustomerInfo.Location = New System.Drawing.Point(0, 72)
        Me.grpCustomerInfo.Name = "grpCustomerInfo"
        Me.grpCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grpCustomerInfo.Size = New System.Drawing.Size(1600, 618)
        Me.grpCustomerInfo.TabIndex = 72
        Me.grpCustomerInfo.Text = "بيانات المستخدم"
        Me.grpCustomerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Appearance.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Appearance.Options.UseFont = True
        Me.btnNew.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.add_user__1_
        Me.btnNew.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.btnNew.Location = New System.Drawing.Point(541, 532)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnNew.Size = New System.Drawing.Size(403, 75)
        Me.btnNew.TabIndex = 5574
        Me.btnNew.Text = "اضافة مستخدم جديد (F2)"
        '
        'btn_delet_barcode
        '
        Me.btn_delet_barcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_delet_barcode.Appearance.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delet_barcode.Appearance.Options.UseFont = True
        Me.btn_delet_barcode.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.delete
        Me.btn_delet_barcode.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_delet_barcode.Location = New System.Drawing.Point(319, 274)
        Me.btn_delet_barcode.Name = "btn_delet_barcode"
        Me.btn_delet_barcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_delet_barcode.Size = New System.Drawing.Size(71, 75)
        Me.btn_delet_barcode.TabIndex = 5573
        '
        'btn_barcode_print
        '
        Me.btn_barcode_print.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_barcode_print.Appearance.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_barcode_print.Appearance.Options.UseFont = True
        Me.btn_barcode_print.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.printing
        Me.btn_barcode_print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_barcode_print.Location = New System.Drawing.Point(319, 356)
        Me.btn_barcode_print.Name = "btn_barcode_print"
        Me.btn_barcode_print.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_barcode_print.Size = New System.Drawing.Size(316, 75)
        Me.btn_barcode_print.TabIndex = 5572
        Me.btn_barcode_print.Text = "طباعة الباركود"
        '
        'cmbRoleName
        '
        Me.cmbRoleName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRoleName.BackColor = System.Drawing.Color.Transparent
        Me.cmbRoleName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoleName.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbRoleName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbRoleName.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.cmbRoleName.ForeColor = System.Drawing.Color.Black
        Me.cmbRoleName.ItemHeight = 30
        Me.cmbRoleName.Location = New System.Drawing.Point(707, 207)
        Me.cmbRoleName.Name = "cmbRoleName"
        Me.cmbRoleName.Size = New System.Drawing.Size(282, 36)
        Me.cmbRoleName.TabIndex = 5571
        '
        'btn_barcode_new
        '
        Me.btn_barcode_new.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_barcode_new.Appearance.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_barcode_new.Appearance.Options.UseFont = True
        Me.btn_barcode_new.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.shopping
        Me.btn_barcode_new.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_barcode_new.Location = New System.Drawing.Point(396, 274)
        Me.btn_barcode_new.Name = "btn_barcode_new"
        Me.btn_barcode_new.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_barcode_new.Size = New System.Drawing.Size(239, 75)
        Me.btn_barcode_new.TabIndex = 5570
        Me.btn_barcode_new.Text = "انشاء باركود"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(386, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 37)
        Me.Label7.TabIndex = 5569
        Me.Label7.Text = "صورة الباركود"
        '
        'pic_Barcode
        '
        Me.pic_Barcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_Barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_Barcode.Location = New System.Drawing.Point(325, 135)
        Me.pic_Barcode.Name = "pic_Barcode"
        Me.pic_Barcode.Size = New System.Drawing.Size(300, 120)
        Me.pic_Barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Barcode.TabIndex = 5568
        Me.pic_Barcode.TabStop = False
        '
        'btnSelectImage
        '
        Me.btnSelectImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectImage.Appearance.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectImage.Appearance.Options.UseFont = True
        Me.btnSelectImage.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.new_hire
        Me.btnSelectImage.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnSelectImage.Location = New System.Drawing.Point(33, 356)
        Me.btnSelectImage.Name = "btnSelectImage"
        Me.btnSelectImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSelectImage.Size = New System.Drawing.Size(280, 75)
        Me.btnSelectImage.TabIndex = 5567
        Me.btnSelectImage.Text = "تحديد الصورة"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(77, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(213, 37)
        Me.Label6.TabIndex = 5566
        Me.Label6.Text = "صورة المستخدم"
        '
        'pic_user
        '
        Me.pic_user.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_user.Location = New System.Drawing.Point(33, 135)
        Me.pic_user.Name = "pic_user"
        Me.pic_user.Size = New System.Drawing.Size(280, 200)
        Me.pic_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_user.TabIndex = 5565
        Me.pic_user.TabStop = False
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel9.AutoSize = False
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(915, 273)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(206, 36)
        Me.Guna2HtmlLabel9.TabIndex = 5564
        Me.Guna2HtmlLabel9.Text = "الملاحظات"
        Me.Guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtUser_Note
        '
        Me.txtUser_Note.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_Note.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser_Note.DefaultText = ""
        Me.txtUser_Note.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser_Note.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser_Note.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Note.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Note.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Note.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser_Note.ForeColor = System.Drawing.Color.Black
        Me.txtUser_Note.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Note.Location = New System.Drawing.Point(707, 318)
        Me.txtUser_Note.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser_Note.Multiline = True
        Me.txtUser_Note.Name = "txtUser_Note"
        Me.txtUser_Note.PlaceholderText = ""
        Me.txtUser_Note.SelectedText = ""
        Me.txtUser_Note.Size = New System.Drawing.Size(414, 113)
        Me.txtUser_Note.TabIndex = 5563
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(1010, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 37)
        Me.Label5.TabIndex = 5561
        Me.Label5.Text = "الموظف"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(1421, 343)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 37)
        Me.Label4.TabIndex = 5560
        Me.Label4.Text = "كلمة المرور *"
        '
        'txtUser_password
        '
        Me.txtUser_password.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_password.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser_password.DefaultText = ""
        Me.txtUser_password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_password.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser_password.ForeColor = System.Drawing.Color.Black
        Me.txtUser_password.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_password.Location = New System.Drawing.Point(1160, 386)
        Me.txtUser_password.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser_password.Name = "txtUser_password"
        Me.txtUser_password.PlaceholderText = ""
        Me.txtUser_password.SelectedText = ""
        Me.txtUser_password.Size = New System.Drawing.Size(414, 45)
        Me.txtUser_password.TabIndex = 5559
        Me.txtUser_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(1373, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 37)
        Me.Label3.TabIndex = 5558
        Me.Label3.Text = "اسم المستخدم *"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(1423, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 37)
        Me.Label2.TabIndex = 5557
        Me.Label2.Text = "الاسم كامل *"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(1375, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 37)
        Me.Label1.TabIndex = 5556
        Me.Label1.Text = "كود المستخدم *"
        '
        'btn_clean
        '
        Me.btn_clean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_clean.Appearance.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clean.Appearance.Options.UseFont = True
        Me.btn_clean.AutoSize = True
        Me.btn_clean.ImageOptions.Image = Global.WindowsApp1.My.Resources.Resources.eraser
        Me.btn_clean.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btn_clean.Location = New System.Drawing.Point(1325, 2)
        Me.btn_clean.Name = "btn_clean"
        Me.btn_clean.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_clean.Size = New System.Drawing.Size(38, 36)
        Me.btn_clean.TabIndex = 44
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = False
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("LBC", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(800, 113)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(222, 45)
        Me.lblStatus.TabIndex = 34
        Me.lblStatus.Text = "نشط / غير نشط"
        Me.lblStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkUser_Stats
        '
        Me.chkUser_Stats.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkUser_Stats.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUser_Stats.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkUser_Stats.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUser_Stats.CheckedState.InnerColor = System.Drawing.Color.White
        Me.chkUser_Stats.Location = New System.Drawing.Point(1028, 113)
        Me.chkUser_Stats.Name = "chkUser_Stats"
        Me.chkUser_Stats.Size = New System.Drawing.Size(93, 44)
        Me.chkUser_Stats.TabIndex = 9
        Me.chkUser_Stats.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUser_Stats.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkUser_Stats.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.chkUser_Stats.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Guna2HtmlLabel8
        '
        Me.Guna2HtmlLabel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel8.AutoSize = False
        Me.Guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel8.Font = New System.Drawing.Font("LBC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel8.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel8.Location = New System.Drawing.Point(961, 51)
        Me.Guna2HtmlLabel8.Name = "Guna2HtmlLabel8"
        Me.Guna2HtmlLabel8.Size = New System.Drawing.Size(172, 47)
        Me.Guna2HtmlLabel8.TabIndex = 30
        Me.Guna2HtmlLabel8.Text = "الحالة"
        Me.Guna2HtmlLabel8.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'txtUser_username
        '
        Me.txtUser_username.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_username.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser_username.DefaultText = ""
        Me.txtUser_username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_username.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser_username.ForeColor = System.Drawing.Color.Black
        Me.txtUser_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_username.Location = New System.Drawing.Point(1160, 290)
        Me.txtUser_username.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser_username.Name = "txtUser_username"
        Me.txtUser_username.PlaceholderText = ""
        Me.txtUser_username.SelectedText = ""
        Me.txtUser_username.Size = New System.Drawing.Size(414, 45)
        Me.txtUser_username.TabIndex = 5
        Me.txtUser_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUser_Name
        '
        Me.txtUser_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_Name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser_Name.DefaultText = ""
        Me.txtUser_Name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser_Name.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser_Name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Name.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser_Name.ForeColor = System.Drawing.Color.Black
        Me.txtUser_Name.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Name.Location = New System.Drawing.Point(1160, 194)
        Me.txtUser_Name.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser_Name.Name = "txtUser_Name"
        Me.txtUser_Name.PlaceholderText = ""
        Me.txtUser_Name.SelectedText = ""
        Me.txtUser_Name.Size = New System.Drawing.Size(414, 45)
        Me.txtUser_Name.TabIndex = 4
        Me.txtUser_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUser_Code
        '
        Me.txtUser_Code.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_Code.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser_Code.DefaultText = ""
        Me.txtUser_Code.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser_Code.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser_Code.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Code.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser_Code.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Code.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtUser_Code.ForeColor = System.Drawing.Color.Black
        Me.txtUser_Code.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser_Code.Location = New System.Drawing.Point(1160, 96)
        Me.txtUser_Code.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtUser_Code.Name = "txtUser_Code"
        Me.txtUser_Code.PlaceholderText = ""
        Me.txtUser_Code.SelectedText = ""
        Me.txtUser_Code.Size = New System.Drawing.Size(414, 45)
        Me.txtUser_Code.TabIndex = 3
        Me.txtUser_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'add_new_user
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1600, 750)
        Me.Controls.Add(Me.grpCustomerInfo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "add_new_user"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة مستخدم جديد"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpCustomerInfo.ResumeLayout(False)
        Me.grpCustomerInfo.PerformLayout()
        CType(Me.pic_Barcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pn_title_page As Label
    Friend WithEvents grpCustomerInfo As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents btn_delet_barcode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_barcode_print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbRoleName As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btn_barcode_new As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label7 As Label
    Friend WithEvents pic_Barcode As PictureBox
    Friend WithEvents btnSelectImage As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents pic_user As PictureBox
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtUser_Note As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUser_password As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_clean As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblStatus As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents chkUser_Stats As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Guna2HtmlLabel8 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtUser_username As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtUser_Name As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtUser_Code As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
End Class
