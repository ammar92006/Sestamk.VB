<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About_the_program
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About_the_program))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.note_client = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.address_client = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mmber_client = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Idnum_client = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.phone_client = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.money_client = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.name_client = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.code_client = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btnMinimize = New System.Windows.Forms.Button()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 30.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(493, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "حول البرنامج"
        '
        'dgvUsers
        '
        Me.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Location = New System.Drawing.Point(12, 333)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.ReadOnly = True
        Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsers.Size = New System.Drawing.Size(1223, 429)
        Me.dgvUsers.TabIndex = 1
        '
        'note_client
        '
        Me.note_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.note_client.Location = New System.Drawing.Point(806, 277)
        Me.note_client.Name = "note_client"
        Me.note_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.note_client.Size = New System.Drawing.Size(296, 33)
        Me.note_client.TabIndex = 27
        Me.note_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(579, 273)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(211, 35)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "حالة الاتصال"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'address_client
        '
        Me.address_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.address_client.Location = New System.Drawing.Point(806, 221)
        Me.address_client.Name = "address_client"
        Me.address_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.address_client.Size = New System.Drawing.Size(296, 33)
        Me.address_client.TabIndex = 25
        Me.address_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(579, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label8.Size = New System.Drawing.Size(211, 35)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "كلمة المرور"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mmber_client
        '
        Me.mmber_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.mmber_client.Location = New System.Drawing.Point(806, 171)
        Me.mmber_client.Name = "mmber_client"
        Me.mmber_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.mmber_client.Size = New System.Drawing.Size(296, 33)
        Me.mmber_client.TabIndex = 24
        Me.mmber_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(579, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(211, 35)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "اسم المستخدم"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Idnum_client
        '
        Me.Idnum_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Idnum_client.Location = New System.Drawing.Point(806, 119)
        Me.Idnum_client.Name = "Idnum_client"
        Me.Idnum_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Idnum_client.Size = New System.Drawing.Size(296, 33)
        Me.Idnum_client.TabIndex = 22
        Me.Idnum_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(579, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(211, 35)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "الوقت"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'phone_client
        '
        Me.phone_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.phone_client.Location = New System.Drawing.Point(262, 277)
        Me.phone_client.Name = "phone_client"
        Me.phone_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.phone_client.Size = New System.Drawing.Size(296, 33)
        Me.phone_client.TabIndex = 21
        Me.phone_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(60, 276)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(196, 35)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "التاريخ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'money_client
        '
        Me.money_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.money_client.Location = New System.Drawing.Point(262, 223)
        Me.money_client.Name = "money_client"
        Me.money_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.money_client.Size = New System.Drawing.Size(296, 33)
        Me.money_client.TabIndex = 19
        Me.money_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(60, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(196, 35)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Mac Address"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'name_client
        '
        Me.name_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.name_client.Location = New System.Drawing.Point(262, 169)
        Me.name_client.Name = "name_client"
        Me.name_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.name_client.Size = New System.Drawing.Size(296, 33)
        Me.name_client.TabIndex = 2
        Me.name_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(60, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(196, 35)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "اسم الجهاز"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'code_client
        '
        Me.code_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.code_client.Location = New System.Drawing.Point(262, 117)
        Me.code_client.Name = "code_client"
        Me.code_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.code_client.Size = New System.Drawing.Size(296, 33)
        Me.code_client.TabIndex = 1
        Me.code_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(60, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(196, 35)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "كود الدخول"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(54, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1138, 255)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معلومات الدخول"
        '
        'btn_close
        '
        Me.btn_close.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btn_close.Image = CType(resources.GetObject("btn_close.Image"), System.Drawing.Image)
        Me.btn_close.Location = New System.Drawing.Point(1198, 9)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(33, 30)
        Me.btn_close.TabIndex = 34
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btnMinimize
        '
        Me.btnMinimize.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btnMinimize.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMinimize.Location = New System.Drawing.Point(1159, 9)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(33, 30)
        Me.btnMinimize.TabIndex = 33
        Me.btnMinimize.Text = "_"
        Me.btnMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMinimize.UseVisualStyleBackColor = True
        '
        'About_the_program
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1247, 774)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.note_client)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.address_client)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.mmber_client)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Idnum_client)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.phone_client)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.money_client)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.name_client)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.code_client)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvUsers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "About_the_program"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "حول البرنامج"
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents note_client As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents address_client As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents mmber_client As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Idnum_client As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents phone_client As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents money_client As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents name_client As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents code_client As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_close As Button
    Friend WithEvents btnMinimize As Button
End Class
