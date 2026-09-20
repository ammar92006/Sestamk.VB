<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUpdateNotifier
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
        Me._title = New System.Windows.Forms.Label()
        Me._notes = New System.Windows.Forms.TextBox()
        Me._progress = New System.Windows.Forms.ProgressBar()
        Me._update = New System.Windows.Forms.Button()
        Me._later = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        '_title
        '
        Me._title.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me._title.Location = New System.Drawing.Point(24, 20)
        Me._title.Name = "_title"
        Me._title.Size = New System.Drawing.Size(470, 35)
        Me._title.TabIndex = 0
        Me._title.Text = "يتوفر تحديث جديد"
        Me._title.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_notes
        '
        Me._notes.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me._notes.Location = New System.Drawing.Point(24, 70)
        Me._notes.Multiline = True
        Me._notes.Name = "_notes"
        Me._notes.ReadOnly = True
        Me._notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me._notes.Size = New System.Drawing.Size(470, 165)
        Me._notes.TabIndex = 1
        '
        '_progress
        '
        Me._progress.Location = New System.Drawing.Point(24, 250)
        Me._progress.Name = "_progress"
        Me._progress.Size = New System.Drawing.Size(470, 18)
        Me._progress.TabIndex = 2
        Me._progress.Visible = False
        '
        '_update
        '
        Me._update.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me._update.Location = New System.Drawing.Point(274, 282)
        Me._update.Name = "_update"
        Me._update.Size = New System.Drawing.Size(110, 32)
        Me._update.TabIndex = 3
        Me._update.Text = "تحديث الآن"
        Me._update.UseVisualStyleBackColor = True
        '
        '_later
        '
        Me._later.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me._later.Location = New System.Drawing.Point(144, 282)
        Me._later.Name = "_later"
        Me._later.Size = New System.Drawing.Size(110, 32)
        Me._later.TabIndex = 4
        Me._later.Text = "لاحقاً"
        Me._later.UseVisualStyleBackColor = True
        '
        'FormUpdateNotifier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 330)
        Me.Controls.Add(Me._later)
        Me.Controls.Add(Me._update)
        Me.Controls.Add(Me._progress)
        Me.Controls.Add(Me._notes)
        Me.Controls.Add(Me._title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUpdateNotifier"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "تحديث سيستمك"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents _title As System.Windows.Forms.Label
    Friend WithEvents _notes As System.Windows.Forms.TextBox
    Friend WithEvents _progress As System.Windows.Forms.ProgressBar
    Friend WithEvents _update As System.Windows.Forms.Button
    Friend WithEvents _later As System.Windows.Forms.Button
End Class
