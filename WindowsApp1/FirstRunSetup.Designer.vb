<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FirstRunSetup
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
        Me.header = New System.Windows.Forms.Label()
        Me.lblShopName = New System.Windows.Forms.Label()
        Me.txtShopName = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.txtTax = New System.Windows.Forms.TextBox()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.lblBusinessType = New System.Windows.Forms.Label()
        Me.cmbBusinessType = New System.Windows.Forms.ComboBox()
        Me.lblLogo = New System.Windows.Forms.Label()
        Me.txtLogoPath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblAdminSection = New System.Windows.Forms.Label()
        Me.lblAdminUser = New System.Windows.Forms.Label()
        Me.txtAdminUser = New System.Windows.Forms.TextBox()
        Me.lblAdminPass = New System.Windows.Forms.Label()
        Me.txtAdminPass = New System.Windows.Forms.TextBox()
        Me.lblAdminPass2 = New System.Windows.Forms.Label()
        Me.txtAdminPass2 = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.header.Dock = System.Windows.Forms.DockStyle.Top
        Me.header.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.header.ForeColor = System.Drawing.Color.White
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(640, 60)
        Me.header.TabIndex = 0
        Me.header.Text = "👋 مرحباً — لنُهيّئ البرنامج لنشاطك"
        Me.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblShopName
        '
        Me.lblShopName.AutoSize = True
        Me.lblShopName.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblShopName.ForeColor = System.Drawing.Color.White
        Me.lblShopName.Location = New System.Drawing.Point(440, 84)
        Me.lblShopName.Name = "lblShopName"
        Me.lblShopName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblShopName.Size = New System.Drawing.Size(161, 20)
        Me.lblShopName.TabIndex = 1
        Me.lblShopName.Text = "اسم المحل / النشاط *:"
        '
        'txtShopName
        '
        Me.txtShopName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtShopName.Location = New System.Drawing.Point(40, 80)
        Me.txtShopName.Name = "txtShopName"
        Me.txtShopName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtShopName.Size = New System.Drawing.Size(380, 27)
        Me.txtShopName.TabIndex = 2
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblPhone.ForeColor = System.Drawing.Color.White
        Me.lblPhone.Location = New System.Drawing.Point(440, 126)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPhone.Size = New System.Drawing.Size(86, 20)
        Me.lblPhone.TabIndex = 3
        Me.lblPhone.Text = "رقم الهاتف:"
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPhone.Location = New System.Drawing.Point(40, 122)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPhone.Size = New System.Drawing.Size(380, 27)
        Me.txtPhone.TabIndex = 4
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblAddress.ForeColor = System.Drawing.Color.White
        Me.lblAddress.Location = New System.Drawing.Point(440, 168)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAddress.Size = New System.Drawing.Size(59, 20)
        Me.lblAddress.TabIndex = 5
        Me.lblAddress.Text = "العنوان:"
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtAddress.Location = New System.Drawing.Point(40, 164)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAddress.Size = New System.Drawing.Size(380, 27)
        Me.txtAddress.TabIndex = 6
        '
        'lblTax
        '
        Me.lblTax.AutoSize = True
        Me.lblTax.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTax.ForeColor = System.Drawing.Color.White
        Me.lblTax.Location = New System.Drawing.Point(440, 210)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTax.Size = New System.Drawing.Size(109, 20)
        Me.lblTax.TabIndex = 7
        Me.lblTax.Text = "الرقم الضريبي:"
        '
        'txtTax
        '
        Me.txtTax.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtTax.Location = New System.Drawing.Point(40, 206)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTax.Size = New System.Drawing.Size(380, 27)
        Me.txtTax.TabIndex = 8
        '
        'lblCurrency
        '
        Me.lblCurrency.AutoSize = True
        Me.lblCurrency.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrency.ForeColor = System.Drawing.Color.White
        Me.lblCurrency.Location = New System.Drawing.Point(440, 252)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCurrency.Size = New System.Drawing.Size(56, 20)
        Me.lblCurrency.TabIndex = 9
        Me.lblCurrency.Text = "العملة:"
        '
        'cmbCurrency
        '
        Me.cmbCurrency.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbCurrency.Items.AddRange(New Object() {"ج.م", "ر.س", "د.إ", "د.ك", "د.ع", "$", "€"})
        Me.cmbCurrency.Location = New System.Drawing.Point(40, 248)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCurrency.Size = New System.Drawing.Size(380, 28)
        Me.cmbCurrency.TabIndex = 10
        Me.cmbCurrency.Text = "ج.م"
        '
        'lblBusinessType
        '
        Me.lblBusinessType.AutoSize = True
        Me.lblBusinessType.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBusinessType.ForeColor = System.Drawing.Color.White
        Me.lblBusinessType.Location = New System.Drawing.Point(440, 294)
        Me.lblBusinessType.Name = "lblBusinessType"
        Me.lblBusinessType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblBusinessType.Size = New System.Drawing.Size(89, 20)
        Me.lblBusinessType.TabIndex = 11
        Me.lblBusinessType.Text = "نوع النشاط:"
        '
        'cmbBusinessType
        '
        Me.cmbBusinessType.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbBusinessType.Items.AddRange(New Object() {"سوبر ماركت", "بقالة", "صيدلية", "مخبز", "ملابس", "إلكترونيات", "أخرى"})
        Me.cmbBusinessType.Location = New System.Drawing.Point(40, 290)
        Me.cmbBusinessType.Name = "cmbBusinessType"
        Me.cmbBusinessType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbBusinessType.Size = New System.Drawing.Size(380, 28)
        Me.cmbBusinessType.TabIndex = 12
        Me.cmbBusinessType.Text = "سوبر ماركت"
        '
        'lblLogo
        '
        Me.lblLogo.AutoSize = True
        Me.lblLogo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblLogo.ForeColor = System.Drawing.Color.White
        Me.lblLogo.Location = New System.Drawing.Point(440, 336)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLogo.Size = New System.Drawing.Size(155, 20)
        Me.lblLogo.TabIndex = 13
        Me.lblLogo.Text = "شعار/لوجو (اختياري):"
        '
        'txtLogoPath
        '
        Me.txtLogoPath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtLogoPath.Location = New System.Drawing.Point(120, 332)
        Me.txtLogoPath.Name = "txtLogoPath"
        Me.txtLogoPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLogoPath.Size = New System.Drawing.Size(300, 25)
        Me.txtLogoPath.TabIndex = 14
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.ForeColor = System.Drawing.Color.White
        Me.btnBrowse.Location = New System.Drawing.Point(40, 331)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(70, 28)
        Me.btnBrowse.TabIndex = 15
        Me.btnBrowse.Text = "📂"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'lblAdminSection
        '
        Me.lblAdminSection.AutoSize = True
        Me.lblAdminSection.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblAdminSection.ForeColor = System.Drawing.Color.Gold
        Me.lblAdminSection.Location = New System.Drawing.Point(440, 382)
        Me.lblAdminSection.Name = "lblAdminSection"
        Me.lblAdminSection.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAdminSection.Size = New System.Drawing.Size(130, 25)
        Me.lblAdminSection.TabIndex = 16
        Me.lblAdminSection.Text = "🔐 حساب المدير"
        '
        'lblAdminUser
        '
        Me.lblAdminUser.AutoSize = True
        Me.lblAdminUser.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblAdminUser.ForeColor = System.Drawing.Color.White
        Me.lblAdminUser.Location = New System.Drawing.Point(440, 426)
        Me.lblAdminUser.Name = "lblAdminUser"
        Me.lblAdminUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAdminUser.Size = New System.Drawing.Size(161, 20)
        Me.lblAdminUser.TabIndex = 17
        Me.lblAdminUser.Text = "اسم مستخدم المدير *:"
        '
        'txtAdminUser
        '
        Me.txtAdminUser.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtAdminUser.Location = New System.Drawing.Point(40, 422)
        Me.txtAdminUser.Name = "txtAdminUser"
        Me.txtAdminUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdminUser.Size = New System.Drawing.Size(380, 27)
        Me.txtAdminUser.TabIndex = 18
        '
        'lblAdminPass
        '
        Me.lblAdminPass.AutoSize = True
        Me.lblAdminPass.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblAdminPass.ForeColor = System.Drawing.Color.White
        Me.lblAdminPass.Location = New System.Drawing.Point(440, 468)
        Me.lblAdminPass.Name = "lblAdminPass"
        Me.lblAdminPass.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAdminPass.Size = New System.Drawing.Size(100, 20)
        Me.lblAdminPass.TabIndex = 19
        Me.lblAdminPass.Text = "كلمة المرور *:"
        '
        'txtAdminPass
        '
        Me.txtAdminPass.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtAdminPass.Location = New System.Drawing.Point(40, 464)
        Me.txtAdminPass.Name = "txtAdminPass"
        Me.txtAdminPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtAdminPass.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdminPass.Size = New System.Drawing.Size(380, 27)
        Me.txtAdminPass.TabIndex = 20
        '
        'lblAdminPass2
        '
        Me.lblAdminPass2.AutoSize = True
        Me.lblAdminPass2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblAdminPass2.ForeColor = System.Drawing.Color.White
        Me.lblAdminPass2.Location = New System.Drawing.Point(440, 510)
        Me.lblAdminPass2.Name = "lblAdminPass2"
        Me.lblAdminPass2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAdminPass2.Size = New System.Drawing.Size(135, 20)
        Me.lblAdminPass2.TabIndex = 21
        Me.lblAdminPass2.Text = "تأكيد كلمة المرور *:"
        '
        'txtAdminPass2
        '
        Me.txtAdminPass2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtAdminPass2.Location = New System.Drawing.Point(40, 506)
        Me.txtAdminPass2.Name = "txtAdminPass2"
        Me.txtAdminPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtAdminPass2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdminPass2.Size = New System.Drawing.Size(380, 27)
        Me.txtAdminPass2.TabIndex = 22
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(40, 565)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(560, 48)
        Me.btnSave.TabIndex = 23
        Me.btnSave.Text = "💾 حفظ وبدء الاستخدام"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'FirstRunSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(640, 720)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtAdminPass2)
        Me.Controls.Add(Me.lblAdminPass2)
        Me.Controls.Add(Me.txtAdminPass)
        Me.Controls.Add(Me.lblAdminPass)
        Me.Controls.Add(Me.txtAdminUser)
        Me.Controls.Add(Me.lblAdminUser)
        Me.Controls.Add(Me.lblAdminSection)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtLogoPath)
        Me.Controls.Add(Me.lblLogo)
        Me.Controls.Add(Me.cmbBusinessType)
        Me.Controls.Add(Me.lblBusinessType)
        Me.Controls.Add(Me.cmbCurrency)
        Me.Controls.Add(Me.lblCurrency)
        Me.Controls.Add(Me.txtTax)
        Me.Controls.Add(Me.lblTax)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.txtShopName)
        Me.Controls.Add(Me.lblShopName)
        Me.Controls.Add(Me.header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FirstRunSetup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تهيئة البرنامج لأول مرة"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents header As System.Windows.Forms.Label
    Friend WithEvents lblShopName As System.Windows.Forms.Label
    Friend WithEvents txtShopName As System.Windows.Forms.TextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents txtTax As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents cmbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents lblBusinessType As System.Windows.Forms.Label
    Friend WithEvents cmbBusinessType As System.Windows.Forms.ComboBox
    Friend WithEvents lblLogo As System.Windows.Forms.Label
    Friend WithEvents txtLogoPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblAdminSection As System.Windows.Forms.Label
    Friend WithEvents lblAdminUser As System.Windows.Forms.Label
    Friend WithEvents txtAdminUser As System.Windows.Forms.TextBox
    Friend WithEvents lblAdminPass As System.Windows.Forms.Label
    Friend WithEvents txtAdminPass As System.Windows.Forms.TextBox
    Friend WithEvents lblAdminPass2 As System.Windows.Forms.Label
    Friend WithEvents txtAdminPass2 As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
