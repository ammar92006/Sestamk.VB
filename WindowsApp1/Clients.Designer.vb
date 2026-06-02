<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Clients
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Clients))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.frm_title = New DevExpress.XtraEditors.LabelControl()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_empty = New System.Windows.Forms.Button()
        Me.btn_add_user = New System.Windows.Forms.Button()
        Me.btn_delet = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.TXTSearch = New System.Windows.Forms.TextBox()
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
        Me.dgvcliens = New System.Windows.Forms.DataGridView()
        Me.myTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvcliens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.frm_title)
        Me.Panel1.Controls.Add(Me.btnMinimize)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1600, 63)
        Me.Panel1.TabIndex = 0
        '
        'frm_title
        '
        Me.frm_title.Appearance.Font = New System.Drawing.Font("LBC", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frm_title.Appearance.Options.UseFont = True
        Me.frm_title.Location = New System.Drawing.Point(607, 3)
        Me.frm_title.Name = "frm_title"
        Me.frm_title.Size = New System.Drawing.Size(260, 62)
        Me.frm_title.TabIndex = 96
        Me.frm_title.Text = "بيانات العملاء"
        '
        'btnMinimize
        '
        Me.btnMinimize.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnMinimize.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btnMinimize.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMinimize.Location = New System.Drawing.Point(51, 12)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(33, 30)
        Me.btnMinimize.TabIndex = 89
        Me.btnMinimize.Text = "_"
        Me.btnMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(90, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(33, 30)
        Me.Button4.TabIndex = 88
        Me.Button4.Text = "_"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Button2.Image = Global.WindowsApp1.My.Resources.Resources.close
        Me.Button2.Location = New System.Drawing.Point(12, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 30)
        Me.Button2.TabIndex = 90
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 999)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1600, 51)
        Me.Panel2.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(21, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(243, 45)
        Me.Label11.TabIndex = 93
        Me.Label11.Text = "مجموع العملاء"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(281, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 45)
        Me.Label12.TabIndex = 94
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.TextBox2)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.TextBox3)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.TextBox4)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.ComboBox1)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.btn_empty)
        Me.Panel3.Controls.Add(Me.btn_add_user)
        Me.Panel3.Controls.Add(Me.btn_delet)
        Me.Panel3.Controls.Add(Me.btn_edit)
        Me.Panel3.Controls.Add(Me.btn_Search)
        Me.Panel3.Controls.Add(Me.TXTSearch)
        Me.Panel3.Controls.Add(Me.note_client)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.address_client)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.mmber_client)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Idnum_client)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.phone_client)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.money_client)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.name_client)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.code_client)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.dgvcliens)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 63)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel3.Size = New System.Drawing.Size(1600, 936)
        Me.Panel3.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.TextBox1.Location = New System.Drawing.Point(71, 281)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(296, 33)
        Me.TextBox1.TabIndex = 100
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(378, 279)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 35)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "الملاحظات"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.TextBox2.Location = New System.Drawing.Point(71, 229)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(296, 33)
        Me.TextBox2.TabIndex = 99
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(379, 227)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(187, 35)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "العنوان"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.TextBox3.Location = New System.Drawing.Point(71, 179)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(296, 33)
        Me.TextBox3.TabIndex = 98
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(378, 175)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(187, 35)
        Me.Label14.TabIndex = 102
        Me.Label14.Text = "عدد الافراد"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.TextBox4.Location = New System.Drawing.Point(71, 126)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(296, 33)
        Me.TextBox4.TabIndex = 97
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(378, 126)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(187, 35)
        Me.Label15.TabIndex = 101
        Me.Label15.Text = "رقم البطاقة"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.SlateGray
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = Global.WindowsApp1.My.Resources.Resources.loading_arrow
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(8, 7)
        Me.Button3.Name = "Button3"
        Me.Button3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button3.Size = New System.Drawing.Size(137, 51)
        Me.Button3.TabIndex = 95
        Me.Button3.Text = "تحديث"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 24.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(962, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(246, 47)
        Me.ComboBox1.TabIndex = 92
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.WindowsApp1.My.Resources.Resources.top_up
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(48, 346)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(287, 51)
        Me.Button1.TabIndex = 77
        Me.Button1.Text = "اضافة رصيد للعميل"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_empty
        '
        Me.btn_empty.BackColor = System.Drawing.Color.Goldenrod
        Me.btn_empty.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.btn_empty.ForeColor = System.Drawing.Color.White
        Me.btn_empty.Image = Global.WindowsApp1.My.Resources.Resources.bin__1_
        Me.btn_empty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_empty.Location = New System.Drawing.Point(1277, 346)
        Me.btn_empty.Name = "btn_empty"
        Me.btn_empty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_empty.Size = New System.Drawing.Size(126, 51)
        Me.btn_empty.TabIndex = 82
        Me.btn_empty.Text = "افراغ"
        Me.btn_empty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_empty.UseVisualStyleBackColor = False
        '
        'btn_add_user
        '
        Me.btn_add_user.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_add_user.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.btn_add_user.ForeColor = System.Drawing.Color.White
        Me.btn_add_user.Image = Global.WindowsApp1.My.Resources.Resources.add_user
        Me.btn_add_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_add_user.Location = New System.Drawing.Point(427, 346)
        Me.btn_add_user.Name = "btn_add_user"
        Me.btn_add_user.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_add_user.Size = New System.Drawing.Size(276, 51)
        Me.btn_add_user.TabIndex = 78
        Me.btn_add_user.Text = "اضافة عميل جديد"
        Me.btn_add_user.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_add_user.UseVisualStyleBackColor = False
        '
        'btn_delet
        '
        Me.btn_delet.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_delet.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.btn_delet.ForeColor = System.Drawing.Color.White
        Me.btn_delet.Image = Global.WindowsApp1.My.Resources.Resources.bin
        Me.btn_delet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_delet.Location = New System.Drawing.Point(1082, 346)
        Me.btn_delet.Name = "btn_delet"
        Me.btn_delet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_delet.Size = New System.Drawing.Size(126, 51)
        Me.btn_delet.TabIndex = 81
        Me.btn_delet.Text = "حذف"
        Me.btn_delet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_delet.UseVisualStyleBackColor = False
        '
        'btn_edit
        '
        Me.btn_edit.BackColor = System.Drawing.Color.Blue
        Me.btn_edit.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.btn_edit.ForeColor = System.Drawing.Color.White
        Me.btn_edit.Image = Global.WindowsApp1.My.Resources.Resources.draw
        Me.btn_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_edit.Location = New System.Drawing.Point(831, 346)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_edit.Size = New System.Drawing.Size(123, 51)
        Me.btn_edit.TabIndex = 80
        Me.btn_edit.Text = "تعديل"
        Me.btn_edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_edit.UseVisualStyleBackColor = False
        '
        'btn_Search
        '
        Me.btn_Search.BackColor = System.Drawing.Color.Black
        Me.btn_Search.Font = New System.Drawing.Font("Tahoma", 26.0!)
        Me.btn_Search.ForeColor = System.Drawing.Color.White
        Me.btn_Search.Image = Global.WindowsApp1.My.Resources.Resources.magnifying_glass
        Me.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Search.Location = New System.Drawing.Point(216, 44)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_Search.Size = New System.Drawing.Size(137, 51)
        Me.btn_Search.TabIndex = 87
        Me.btn_Search.Text = "بحث"
        Me.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Search.UseVisualStyleBackColor = False
        '
        'TXTSearch
        '
        Me.TXTSearch.Font = New System.Drawing.Font("Tahoma", 24.0!)
        Me.TXTSearch.Location = New System.Drawing.Point(359, 48)
        Me.TXTSearch.Name = "TXTSearch"
        Me.TXTSearch.Size = New System.Drawing.Size(597, 46)
        Me.TXTSearch.TabIndex = 85
        Me.TXTSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'note_client
        '
        Me.note_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.note_client.Location = New System.Drawing.Point(571, 281)
        Me.note_client.Name = "note_client"
        Me.note_client.Size = New System.Drawing.Size(296, 33)
        Me.note_client.TabIndex = 75
        Me.note_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(873, 277)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(202, 35)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "الملاحظات"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'address_client
        '
        Me.address_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.address_client.Location = New System.Drawing.Point(571, 225)
        Me.address_client.Name = "address_client"
        Me.address_client.Size = New System.Drawing.Size(296, 33)
        Me.address_client.TabIndex = 73
        Me.address_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(873, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(202, 35)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "العنوان"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mmber_client
        '
        Me.mmber_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.mmber_client.Location = New System.Drawing.Point(571, 175)
        Me.mmber_client.Name = "mmber_client"
        Me.mmber_client.Size = New System.Drawing.Size(296, 33)
        Me.mmber_client.TabIndex = 72
        Me.mmber_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(873, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(202, 35)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "عدد الافراد"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Idnum_client
        '
        Me.Idnum_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Idnum_client.Location = New System.Drawing.Point(571, 126)
        Me.Idnum_client.Name = "Idnum_client"
        Me.Idnum_client.Size = New System.Drawing.Size(296, 33)
        Me.Idnum_client.TabIndex = 70
        Me.Idnum_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(873, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(202, 35)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "رقم البطاقة"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'phone_client
        '
        Me.phone_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.phone_client.Location = New System.Drawing.Point(1081, 277)
        Me.phone_client.Name = "phone_client"
        Me.phone_client.Size = New System.Drawing.Size(296, 33)
        Me.phone_client.TabIndex = 69
        Me.phone_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(1383, 277)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(196, 35)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "رقم الهاتف"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'money_client
        '
        Me.money_client.Enabled = False
        Me.money_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.money_client.Location = New System.Drawing.Point(1081, 225)
        Me.money_client.Name = "money_client"
        Me.money_client.Size = New System.Drawing.Size(296, 33)
        Me.money_client.TabIndex = 68
        Me.money_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(1383, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(196, 35)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "رصيد العميل"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'name_client
        '
        Me.name_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.name_client.Location = New System.Drawing.Point(1081, 175)
        Me.name_client.Name = "name_client"
        Me.name_client.Size = New System.Drawing.Size(296, 33)
        Me.name_client.TabIndex = 66
        Me.name_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(1383, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 35)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "اسم العميل"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'code_client
        '
        Me.code_client.Enabled = False
        Me.code_client.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.code_client.Location = New System.Drawing.Point(1081, 126)
        Me.code_client.Name = "code_client"
        Me.code_client.Size = New System.Drawing.Size(296, 33)
        Me.code_client.TabIndex = 65
        Me.code_client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(1383, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(196, 35)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "كود العميل"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvcliens
        '
        Me.dgvcliens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvcliens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcliens.Location = New System.Drawing.Point(8, 410)
        Me.dgvcliens.Name = "dgvcliens"
        Me.dgvcliens.ReadOnly = True
        Me.dgvcliens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvcliens.Size = New System.Drawing.Size(1569, 502)
        Me.dgvcliens.TabIndex = 86
        '
        'myTimer
        '
        Me.myTimer.Interval = 1000
        '
        'Clients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1600, 1050)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Clients"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvcliens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents frm_title As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents btnMinimize As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btn_empty As Button
    Friend WithEvents btn_add_user As Button
    Friend WithEvents btn_delet As Button
    Friend WithEvents btn_edit As Button
    Friend WithEvents btn_Search As Button
    Friend WithEvents dgvcliens As DataGridView
    Friend WithEvents TXTSearch As TextBox
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
    Friend WithEvents myTimer As Timer
End Class
