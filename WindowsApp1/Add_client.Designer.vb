<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Add_client
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Add_client))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Client_Code = New System.Windows.Forms.TextBox()
        Me.Client_Name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Client_Balance = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Client_Card_number = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Client_Members = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Client_Address = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Client_Phone = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Client_Note = New System.Windows.Forms.TextBox()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(793, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "كود العميل"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Client_Code
        '
        Me.Client_Code.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Client_Code.Location = New System.Drawing.Point(545, 131)
        Me.Client_Code.Name = "Client_Code"
        Me.Client_Code.Size = New System.Drawing.Size(242, 30)
        Me.Client_Code.TabIndex = 1
        Me.Client_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Client_Name
        '
        Me.Client_Name.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Client_Name.Location = New System.Drawing.Point(545, 180)
        Me.Client_Name.Name = "Client_Name"
        Me.Client_Name.Size = New System.Drawing.Size(242, 30)
        Me.Client_Name.TabIndex = 2
        Me.Client_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(793, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "اسم العميل"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Client_Balance
        '
        Me.Client_Balance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Client_Balance.Location = New System.Drawing.Point(545, 225)
        Me.Client_Balance.Name = "Client_Balance"
        Me.Client_Balance.Size = New System.Drawing.Size(242, 30)
        Me.Client_Balance.TabIndex = 3
        Me.Client_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(793, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "رصيد العميل"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1084, 49)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "اضافة عميل جديد"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Client_Card_number
        '
        Me.Client_Card_number.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Client_Card_number.Location = New System.Drawing.Point(146, 131)
        Me.Client_Card_number.Name = "Client_Card_number"
        Me.Client_Card_number.Size = New System.Drawing.Size(242, 30)
        Me.Client_Card_number.TabIndex = 5
        Me.Client_Card_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(394, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 25)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "العنوان"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Client_Members
        '
        Me.Client_Members.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Client_Members.Location = New System.Drawing.Point(146, 177)
        Me.Client_Members.Name = "Client_Members"
        Me.Client_Members.Size = New System.Drawing.Size(242, 30)
        Me.Client_Members.TabIndex = 6
        Me.Client_Members.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(394, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 25)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "افراد البطاقة"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Client_Address
        '
        Me.Client_Address.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Client_Address.Location = New System.Drawing.Point(146, 223)
        Me.Client_Address.Name = "Client_Address"
        Me.Client_Address.Size = New System.Drawing.Size(242, 30)
        Me.Client_Address.TabIndex = 7
        Me.Client_Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(394, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 25)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "رقم البطاقة"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(793, 270)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 25)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "رقم الهاتف"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Client_Phone
        '
        Me.Client_Phone.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Client_Phone.Location = New System.Drawing.Point(545, 268)
        Me.Client_Phone.Name = "Client_Phone"
        Me.Client_Phone.Size = New System.Drawing.Size(242, 30)
        Me.Client_Phone.TabIndex = 4
        Me.Client_Phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(394, 270)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(145, 25)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "الملاحظات"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Client_Note
        '
        Me.Client_Note.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Client_Note.Location = New System.Drawing.Point(146, 268)
        Me.Client_Note.Name = "Client_Note"
        Me.Client_Note.Size = New System.Drawing.Size(242, 30)
        Me.Client_Note.TabIndex = 8
        Me.Client_Note.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMinimize
        '
        Me.btnMinimize.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btnMinimize.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMinimize.Location = New System.Drawing.Point(52, 12)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(33, 30)
        Me.btnMinimize.TabIndex = 18
        Me.btnMinimize.Text = "_"
        Me.btnMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMinimize.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Button5.Image = Global.WindowsApp1.My.Resources.Resources.recycling_bin_empty_18866__1_
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(365, 386)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(188, 66)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "افراغ"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Button4.Image = Global.WindowsApp1.My.Resources.Resources.close__1_
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(146, 386)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(195, 66)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "الغاء"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.Image = Global.WindowsApp1.My.Resources.Resources.customer_review
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(579, 386)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(195, 66)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "العملاء"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Button2.Image = Global.WindowsApp1.My.Resources.Resources.close
        Me.Button2.Location = New System.Drawing.Point(12, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 30)
        Me.Button2.TabIndex = 19
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Image = Global.WindowsApp1.My.Resources.Resources.diskette
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(815, 386)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(195, 66)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "حفظ"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Add_client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1084, 603)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Client_Note)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Client_Phone)
        Me.Controls.Add(Me.Client_Card_number)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Client_Members)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Client_Address)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Client_Balance)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Client_Name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Client_Code)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Add_client"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة عميل جديد"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Client_Code As TextBox
    Friend WithEvents Client_Name As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Client_Balance As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Client_Card_number As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Client_Members As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Client_Address As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Client_Phone As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Client_Note As TextBox
    Friend WithEvents btnMinimize As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
