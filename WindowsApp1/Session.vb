Imports System.Data

Public Module Session
    Public CurrentUserID As Integer = 0
    Public CurrentUserfullName As String = String.Empty
    Public CurrentUserName As String = String.Empty
    Public CurrentUserPassword As String = String.Empty
    Public CurrentRoleID As Integer = 0
    Public Permissions As DataTable = Nothing



    ' تحميل الصلاحيات من قاعدة البيانات وحفظها في Session.Permissions
    ' [FIX] استبدال Connect/Disconnect بـ Using محلي + Dispose للجدول القديم
    Public Sub LoadPermissions(roleId As Integer)
        Try
            ' Dispose للـ DataTable القديم لمنع تراكم الذاكرة عند إعادة تسجيل الدخول
            Try
                Permissions?.Dispose()
            Catch
            End Try
            Permissions = Nothing

            Dim sql As String = "SELECT * FROM Permissions WHERE RoleID = @RoleID"
            Using cn As SqlClient.SqlConnection = NewConn()
                Using cmd As New SqlClient.SqlCommand(sql, cn)
                    cmd.CommandTimeout = 15
                    cmd.Parameters.AddWithValue("@RoleID", roleId)
                    Using da As New SqlClient.SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        Permissions = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("خطأ في تحميل الصلاحيات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Permissions = New DataTable()
        End Try
    End Sub

    ''' <summary>
    ''' تنظيف بيانات الجلسة - يُستدعى عند Logout أو إغلاق التطبيق.
    ''' [FIX] لمنع تراكم DataTable في الذاكرة عبر الجلسات.
    ''' </summary>
    Public Sub Clear()
        Try
            Permissions?.Dispose()
        Catch
        End Try
        Permissions = Nothing
        CurrentUserID = 0
        CurrentUserfullName = String.Empty
        CurrentUserName = String.Empty
        CurrentUserPassword = String.Empty
        CurrentRoleID = 0
    End Sub

    ' دالة مساعدة تفحص هل للدور صلاحية معينة على فورم معين
    Public Function HasPermission(formName As String, permissionColumn As String) As Boolean
        Try
            If Permissions Is Nothing OrElse Permissions.Rows.Count = 0 Then Return False
            Dim rows() As DataRow = Permissions.Select("FormName = '" & formName.Replace("'", "''") & "' AND " & permissionColumn & " = 1")
            Return (rows.Length > 0)
        Catch
            Return False
        End Try
    End Function
End Module
