Imports System.Data.SqlClient
Imports System.IO
Public Class Backup
    Dim x, y As Integer
    Dim newpoint As New Point
    Public Sub LoadBackupLog(dgv As DataGridView)
        Try
            ' [FIX] Dispose للجدول القديم لمنع تراكم الذاكرة عند إعادة التحميل
            Dim oldDt = TryCast(dgv.DataSource, DataTable)
            dgv.DataSource = Nothing
            Try
                oldDt?.Dispose()
            Catch
            End Try

            Dim dt As New DataTable
            Dim query As String =
        "SELECT
            Backup_ID,
            Backup_File,
            Backup_Date,
            Backup_By,
            Backup_Slot
         FROM Backup_Log
         ORDER BY Backup_Date DESC"

            ' [FIX] Using محلي بدل DBModule.Conn العام
            Using cn As SqlConnection = NewConn()
                Using da As New SqlDataAdapter(query, cn)
                    da.SelectCommand.CommandTimeout = 30
                    da.Fill(dt)
                End Using
            End Using

            ' [FIX] DoubleBuffered لتقليل الـ Flickering عند الـ Fill
            EnableDoubleBuffer(dgv)
            dgv.DataSource = dt

            ' ===== العناوين =====
            dgv.Columns("Backup_ID").HeaderText = "رقم النسخة"
            dgv.Columns("Backup_File").HeaderText = "مسار ملف النسخة"
            dgv.Columns("Backup_Date").HeaderText = "تاريخ النسخ"
            dgv.Columns("Backup_By").HeaderText = "المستخدم"
            dgv.Columns("Backup_Slot").HeaderText = "موعد النسخة"

            '' ===== تحويل رقم الموعد لنص مفهوم =====
            'For Each row As DataGridViewRow In dgv.Rows
            '    If row.Cells("Backup_Slot").Value IsNot DBNull.Value Then
            '        Select Case Convert.ToInt32(row.Cells("Backup_Slot").Value)
            '            Case 1
            '                row.Cells("Backup_Slot").Value = "النسخة الأولى"
            '            Case 2
            '                row.Cells("Backup_Slot").Value = "النسخة الثانية"
            '            Case Else
            '                row.Cells("Backup_Slot").Value = "غير معروف"
            '        End Select
            '    End If
            'Next

            ' ===== تنسيق بسيط =====
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgv.ReadOnly = True
            dgv.AllowUserToAddRows = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.ClearSelection()
            'DBModule.Disconnect()

        Catch ex As Exception
            MsgBox("❌ خطأ تحميل السجل:" & ex.Message)
        End Try
    End Sub

    Private Sub SetupDataGridViewSales(ByVal dgv As DataGridView)
        dgv.AllowUserToAddRows = False
        'dgv.AllowUser = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.EnableHeadersVisualStyles = False

        Dim darkBackground As Color = Color.FromArgb(30, 30, 30)
        Dim darkRow As Color = Color.FromArgb(45, 45, 45)
        Dim darkAltRow As Color = Color.FromArgb(55, 55, 55)
        Dim darkHeader As Color = Color.FromArgb(64, 64, 64)
        Dim highlightColor As Color = Color.FromArgb(0, 122, 204)
        Dim textColor As Color = Color.Gainsboro

        dgv.BackgroundColor = darkBackground
        dgv.RowsDefaultCellStyle.BackColor = darkRow
        dgv.AlternatingRowsDefaultCellStyle.BackColor = darkAltRow
        dgv.DefaultCellStyle.ForeColor = textColor
        dgv.GridColor = Color.FromArgb(80, 80, 80)

        With dgv
            For Each col As DataGridViewColumn In dgv.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            'dgv.RowTemplate.Height = 40
            'dgv.ColumnHeadersHeight = 80

            dgv.ColumnHeadersDefaultCellStyle.BackColor = darkHeader
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            dgv.DefaultCellStyle.SelectionBackColor = highlightColor
            dgv.DefaultCellStyle.SelectionForeColor = Color.White
            dgv.DefaultCellStyle.Font = New Font("Segoe UI", 12.0!)

            dgv.RowHeadersVisible = False
            dgv.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

        End With

    End Sub
    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridViewSales(dgv_backup)
        LoadBackupLog(dgv_backup)
    End Sub

    Private Sub btn_Backup_Click(sender As Object, e As EventArgs) Handles btn_Backup.Click
        TakeBackup("D:\Backups", Session.CurrentUserName)
        LoadBackupLog(dgv_backup)

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, Label1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Label1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()
    End Sub

    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        ElseIf WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        WindowState = FormWindowState.Minimized
    End Sub


    Private Sub btn_Restore_Click(sender As Object, e As EventArgs) Handles btn_Restore.Click
        If dgv_backup.CurrentRow Is Nothing Then Exit Sub

        Dim filePath As String =
            dgv_backup.CurrentRow.Cells("Backup_File").Value.ToString()

        If MsgBox("هل أنت متأكد من استعادة النسخة؟",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            RestoreBackup(filePath)
        End If
    End Sub
End Class