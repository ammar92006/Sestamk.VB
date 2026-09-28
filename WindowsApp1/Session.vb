Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Module Session
    Public CurrentUserID As Integer = 0
    Public CurrentUserfullName As String = String.Empty
    Public CurrentUserName As String = String.Empty
    Public CurrentUserPassword As String = String.Empty
    Public CurrentRoleID As Integer = 0
    Public Permissions As DataTable = Nothing
    Public GuardedScreens As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

    ''' <summary>
    ''' تحميل الصلاحيات من قاعدة البيانات وحفظها في Session.Permissions
    ''' وتحميل قائمة الشاشات المقيدة من AppScreens
    ''' </summary>
    Public Sub LoadPermissions(roleId As Integer)
        Try
            ' Dispose للـ DataTable القديم لمنع تراكم الذاكرة
            Try
                Permissions?.Dispose()
            Catch
            End Try
            Permissions = Nothing

            Using cn As New SqlConnection(DBModule.ConnectionString)
                cn.Open()

                ' 1. تحميل قائمة الشاشات المسجلة في النظام وعناوينها
                Dim screenSql As String = "SELECT FormName, ScreenDisplayName FROM AppScreens"
                Using cmdScreen As New SqlCommand(screenSql, cn)
                    Using daScreen As New SqlDataAdapter(cmdScreen)
                        Dim dtScreens As New DataTable()
                        daScreen.Fill(dtScreens)
                        GuardedScreens.Clear()
                        For Each r As DataRow In dtScreens.Rows
                            Dim fn As String = r("FormName").ToString().Trim()
                            Dim dn As String = r("ScreenDisplayName").ToString().Trim()
                            If Not GuardedScreens.ContainsKey(fn) Then
                                GuardedScreens.Add(fn, dn)
                            End If
                        Next
                    End Using
                End Using

                ' 2. تحميل الصلاحيات للدور الحالي
                Dim sql As String = "SELECT * FROM Permissions WHERE RoleID = @RoleID"
                Using cmd As New SqlCommand(sql, cn)
                    'cmd.CommandTimeout = 15
                    cmd.Parameters.AddWithValue("@RoleID", roleId)
                    Using da As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        Permissions = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("Session.LoadPermissions", ex)
            If roleId <> 1 Then
                MessageBox.Show("خطأ في تحميل الصلاحيات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Permissions = New DataTable()
        End Try
    End Sub

    ''' <summary>
    ''' تنظيف بيانات الجلسة عند تسجيل الخروج أو إغلاق التطبيق.
    ''' </summary>
    Public Sub Clear()
        Try
            Permissions?.Dispose()
        Catch
        End Try
        Permissions = Nothing
        GuardedScreens.Clear()
        CurrentUserID = 0
        CurrentUserfullName = String.Empty
        CurrentUserName = String.Empty
        CurrentUserPassword = String.Empty
        CurrentRoleID = 0
    End Sub

    ''' <summary>
    ''' تحويل اسم الفورم إلى الشاشة الأم التابعة لها إن كان فورم فرعي أو إضافة سريعة
    ''' </summary>
    Public Function ResolveFormAlias(formName As String) As String
        If String.IsNullOrEmpty(formName) Then Return ""

        Select Case formName.ToLowerInvariant()
            Case "add_new_product"
                Return "Products"
            Case "add_new_customer", "customer"
                Return "FrmCustomers"
            Case "add_new_supplier", "suppliers"
                Return "FrmSuppliers"
            Case "purchases", "purchase_return"
                Return "frmPurchases"
            Case "add_new_categorie", "frmcategorytypes"
                Return "Categories"
            Case "add_new_user", "users"
                Return "frmUsers"
            Case "staff"
                Return "frmEmployees"
            Case "stock"
                Return "frmStoreStock"
            Case "productunits"
                Return "frmUnits"
            Case "frmaddons"
                Return "frmProductAddons"
            Case "frmsizes"
                Return "frmProductSizes"
            Case "frmworkshifts"
                Return "frmShifts"
            Case "frmmaterialunits"
                Return "frmRawMaterials"
            Case "frmpendinginvoices", "frmheldinvoices", "frmselectkitchencomment"
                Return "frmPOS"
            Case "kitchencomments"
                Return "frmKitchenComments"
            Case Else
                Return formName
        End Select
    End Function

    ''' <summary>
    ''' جلب الاسم العربي لشاشة معينة لعرضه في رسائل التنبيه
    ''' </summary>
    Public Function GetScreenDisplayName(formName As String) As String
        Dim resolved As String = ResolveFormAlias(formName)
        If GuardedScreens.ContainsKey(resolved) Then
            Return GuardedScreens(resolved)
        End If
        Return formName
    End Function

    ''' <summary>
    ''' فحص هل للمستخدم صلاحية معينة على شاشة محددة
    ''' </summary>
    Public Function HasPermission(formName As String, permissionColumn As String) As Boolean
        Try
            ' الأدمن (RoleID = 1) يمتلك صلاحيات كاملة دائماً بدون قيد
            If CurrentRoleID = 1 Then Return True

            Dim resolved As String = ResolveFormAlias(formName)

            ' إذا لم تكن الشاشة مدرجة في شاشات النظام، تعتبر شاشة مساعدة مفتوحة
            If GuardedScreens.Count > 0 AndAlso Not GuardedScreens.ContainsKey(resolved) Then
                Return True
            End If

            If Permissions Is Nothing OrElse Permissions.Rows.Count = 0 Then Return False

            Dim rows() As DataRow = Permissions.Select("FormName = '" & resolved.Replace("'", "''") & "' AND " & permissionColumn & " = 1")
            Return (rows.Length > 0)
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' فحص صلاحية فتح الشاشة، مع إظهار رسالة تحذيرية وإغلاق الفورم فوراً إذا لم يكن مصرحاً به
    ''' </summary>
    Public Function CheckCanOpen(frm As Form, Optional formName As String = Nothing) As Boolean
        If frm Is Nothing Then Return True
        If CurrentRoleID = 1 Then Return True

        If String.IsNullOrEmpty(formName) Then formName = frm.GetType().Name
        Dim resolved As String = ResolveFormAlias(formName)

        If GuardedScreens.Count > 0 AndAlso Not GuardedScreens.ContainsKey(resolved) Then
            Return True
        End If

        If Not HasPermission(resolved, "CanOpen") Then
            Dim dispName As String = GetScreenDisplayName(resolved)
            MessageBox.Show("عفواً، ليس لديك صلاحية لفتح شاشة (" & dispName & ")!", "صلاحيات الوصول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            frm.BeginInvoke(New MethodInvoker(AddressOf frm.Close))
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' تطبيق الصلاحيات (إضافة، تعديل، حذف) على عناصر التحكم والأزرار داخل الفورم
    ''' </summary>
    Public Sub ApplyFormPermissions(frm As Form, Optional formName As String = Nothing)
        If frm Is Nothing Then Return
        If CurrentRoleID = 1 Then Return

        If String.IsNullOrEmpty(formName) Then formName = frm.GetType().Name
        Dim resolved As String = ResolveFormAlias(formName)

        If GuardedScreens.Count > 0 AndAlso Not GuardedScreens.ContainsKey(resolved) Then
            Return
        End If

        Dim canAdd As Boolean = HasPermission(resolved, "CanAdd")
        Dim canEdit As Boolean = HasPermission(resolved, "CanEdit")
        Dim canDelete As Boolean = HasPermission(resolved, "CanDelete")

        ApplyControlPermissions(frm, canAdd, canEdit, canDelete, resolved)
    End Sub

    Private Sub ApplyControlPermissions(parent As Control, canAdd As Boolean, canEdit As Boolean, canDelete As Boolean, formName As String)
        If parent Is Nothing Then Return

        ' 1. معالجة عناصر شريط الأدوات ToolStrip
        If TypeOf parent Is ToolStrip Then
            Dim ts As ToolStrip = CType(parent, ToolStrip)
            For Each item As ToolStripItem In ts.Items
                ProcessToolStripItem(item, canAdd, canEdit, canDelete, formName)
            Next
        End If

        ' 2. فحص عناصر التحكم والتعامل مع الأزرار
        For Each ctrl As Control In parent.Controls
            If IsButtonControl(ctrl) Then
                ProcessButtonControl(ctrl, canAdd, canEdit, canDelete, formName)
            End If

            If ctrl.HasChildren Then
                ApplyControlPermissions(ctrl, canAdd, canEdit, canDelete, formName)
            End If
        Next
    End Sub

    Private Function IsButtonControl(ctrl As Control) As Boolean
        If ctrl Is Nothing Then Return False
        If TypeOf ctrl Is ButtonBase Then Return True
        Dim typeName As String = ctrl.GetType().Name.ToLowerInvariant()
        If typeName.Contains("button") Then Return True
        Return False
    End Function

    Private Sub ProcessButtonControl(ctrl As Control, canAdd As Boolean, canEdit As Boolean, canDelete As Boolean, formName As String)
        Dim name As String = ctrl.Name.ToLowerInvariant()

        ' استثناء أزرار إغلاق وتكبير وتصغير النوافذ والبحث
        If name.StartsWith("btn_close") OrElse name.StartsWith("btn_max") OrElse name.StartsWith("btn_min") OrElse
           name = "btnclose" OrElse name = "btncancel" OrElse name = "btnexit" OrElse name = "btnsearch" Then
            Return
        End If

        ' فحص زر الحذف
        If IsDeleteButton(name) Then
            If Not canDelete Then
                LockButton(ctrl, "DELETE", "عفواً، ليس لديك صلاحية الحذف في هذه الشاشة!")
            End If
            Return
        End If

        ' فحص زر التعديل
        If IsEditButton(name) Then
            If Not canEdit Then
                LockButton(ctrl, "EDIT", "عفواً، ليس لديك صلاحية التعديل في هذه الشاشة!")
            End If
            Return
        End If

        ' فحص زر الإضافة
        If IsAddButton(name) Then
            If Not canAdd Then
                LockButton(ctrl, "ADD", "عفواً، ليس لديك صلاحية الإضافة في هذه الشاشة!")
            End If
            Return
        End If

        ' فحص أزرار الحفظ العامة
        If name = "btnsave" OrElse name = "btnsaveinvoice" Then
            If Not canAdd AndAlso Not canEdit Then
                LockButton(ctrl, "SAVE", "عفواً، ليس لديك صلاحية الحفظ أو التعديل في هذه الشاشة!")
            End If
        End If
    End Sub

    Private Function IsDeleteButton(name As String) As Boolean
        If name.Contains("delete") OrElse name.Contains("delet") OrElse name.Contains("remove") Then
            Return True
        End If
        If name.StartsWith("del_") OrElse name.EndsWith("_del") OrElse name.Contains("_del_") Then
            Return True
        End If
        Return False
    End Function

    Private Function IsEditButton(name As String) As Boolean
        Return name.Contains("edit") OrElse name.Contains("update")
    End Function

    Private Function IsAddButton(name As String) As Boolean
        If name.Contains("add") OrElse name.Contains("new") OrElse name.Contains("create") OrElse name.Contains("insert") Then
            Return True
        End If
        If name = "btnsaveandpay" OrElse name = "btn_saveproduct" Then
            Return True
        End If
        Return False
    End Function

    Private Sub LockButton(ctrl As Control, reason As String, errorMessage As String)
        If ctrl.Tag IsNot Nothing AndAlso ctrl.Tag.ToString().StartsWith("LOCKED_BY_PERMISSION_") Then
            ctrl.Enabled = False
            Return
        End If

        ctrl.Enabled = False
        ctrl.Tag = "LOCKED_BY_PERMISSION_" & reason & "|" & errorMessage

        ' منع إعادة تفعيل الزر برمجياً من أحداث الفورم عند تغير التحديد
        RemoveHandler ctrl.EnabledChanged, AddressOf OnLockedControlEnabledChanged
        AddHandler ctrl.EnabledChanged, AddressOf OnLockedControlEnabledChanged

        ' إضافة حماية عند النقر
        RemoveHandler ctrl.Click, AddressOf OnLockedControlClick
        AddHandler ctrl.Click, AddressOf OnLockedControlClick
    End Sub

    Private Sub OnLockedControlEnabledChanged(s As Object, e As EventArgs)
        Dim c As Control = TryCast(s, Control)
        If c IsNot Nothing AndAlso c.Tag IsNot Nothing AndAlso c.Tag.ToString().StartsWith("LOCKED_BY_PERMISSION_") Then
            If c.Enabled Then
                c.Enabled = False
            End If
        End If
    End Sub

    Private Sub OnLockedControlClick(s As Object, e As EventArgs)
        Dim c As Control = TryCast(s, Control)
        If c IsNot Nothing AndAlso c.Tag IsNot Nothing AndAlso c.Tag.ToString().StartsWith("LOCKED_BY_PERMISSION_") Then
            Dim parts = c.Tag.ToString().Split("|"c)
            If parts.Length > 1 Then
                MessageBox.Show(parts(1), "صلاحيات الوصول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ProcessToolStripItem(item As ToolStripItem, canAdd As Boolean, canEdit As Boolean, canDelete As Boolean, formName As String)
        If item Is Nothing Then Return
        Dim name As String = item.Name.ToLowerInvariant()

        If name.StartsWith("btn_close") OrElse name.StartsWith("btn_max") OrElse name.StartsWith("btn_min") OrElse
           name = "btnclose" OrElse name = "btncancel" OrElse name = "btnexit" OrElse name = "btnsearch" Then
            Return
        End If

        If IsDeleteButton(name) Then
            If Not canDelete Then
                LockToolStripItem(item, "DELETE", "عفواً، ليس لديك صلاحية الحذف في هذه الشاشة!")
            End If
            Return
        End If

        If IsEditButton(name) Then
            If Not canEdit Then
                LockToolStripItem(item, "EDIT", "عفواً، ليس لديك صلاحية التعديل في هذه الشاشة!")
            End If
            Return
        End If

        If IsAddButton(name) Then
            If Not canAdd Then
                LockToolStripItem(item, "ADD", "عفواً، ليس لديك صلاحية الإضافة في هذه الشاشة!")
            End If
            Return
        End If

        If TypeOf item Is ToolStripDropDownItem Then
            Dim dropDown As ToolStripDropDownItem = CType(item, ToolStripDropDownItem)
            For Each subItem As ToolStripItem In dropDown.DropDownItems
                ProcessToolStripItem(subItem, canAdd, canEdit, canDelete, formName)
            Next
        End If
    End Sub

    Private Sub LockToolStripItem(item As ToolStripItem, reason As String, errorMessage As String)
        If item.Tag IsNot Nothing AndAlso item.Tag.ToString().StartsWith("LOCKED_BY_PERMISSION_") Then
            item.Enabled = False
            Return
        End If

        item.Enabled = False
        item.Tag = "LOCKED_BY_PERMISSION_" & reason & "|" & errorMessage

        RemoveHandler item.EnabledChanged, AddressOf OnLockedToolStripEnabledChanged
        AddHandler item.EnabledChanged, AddressOf OnLockedToolStripEnabledChanged

        RemoveHandler item.Click, AddressOf OnLockedToolStripClick
        AddHandler item.Click, AddressOf OnLockedToolStripClick
    End Sub

    Private Sub OnLockedToolStripEnabledChanged(s As Object, e As EventArgs)
        Dim itm As ToolStripItem = TryCast(s, ToolStripItem)
        If itm IsNot Nothing AndAlso itm.Tag IsNot Nothing AndAlso itm.Tag.ToString().StartsWith("LOCKED_BY_PERMISSION_") Then
            If itm.Enabled Then
                itm.Enabled = False
            End If
        End If
    End Sub

    Private Sub OnLockedToolStripClick(s As Object, e As EventArgs)
        Dim itm As ToolStripItem = TryCast(s, ToolStripItem)
        If itm IsNot Nothing AndAlso itm.Tag IsNot Nothing AndAlso itm.Tag.ToString().StartsWith("LOCKED_BY_PERMISSION_") Then
            Dim parts = itm.Tag.ToString().Split("|"c)
            If parts.Length > 1 Then
                MessageBox.Show(parts(1), "صلاحيات الوصول", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Module
