Imports System.Data.SqlClient

''' <summary>
''' مدير الإشعارات المركزي - يتعامل مع إنشاء وإدارة وعرض الإشعارات
''' </summary>
Public Class NotificationManager
    Private Shared _instance As NotificationManager
    Private Shared ReadOnly _lock As New Object()

    ''' <summary>
    ''' نمط Singleton للوصول للمدير من أي مكان
    ''' </summary>
    Public Shared ReadOnly Property Instance As NotificationManager
        Get
            If _instance Is Nothing Then
                SyncLock _lock
                    If _instance Is Nothing Then
                        _instance = New NotificationManager()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property

    ''' <summary>
    ''' حدث يُطلق عند وصول إشعار جديد
    ''' </summary>
    Public Event NotificationReceived As EventHandler(Of NotificationEventArgs)

    ''' <summary>
    ''' حدث يُطلق عند قراءة إشعار
    ''' </summary>
    Public Event NotificationRead As EventHandler(Of NotificationEventArgs)

    Private Sub New()
        ' مُنشئ خاص للـ Singleton
        EnsureTablesExist()
    End Sub

    Public Sub EnsureTablesExist()
        Try
            Dim sql As String = "
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notifications]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Notifications](
        [NotificationID] [int] IDENTITY(1,1) NOT NULL,
        [NotificationType] [nvarchar](50) NOT NULL,
        [Title] [nvarchar](200) NOT NULL,
        [Message] [nvarchar](max) NOT NULL,
        [Icon] [nvarchar](50) NULL,
        [Priority] [int] NOT NULL DEFAULT(1),
        [IsRead] [bit] NOT NULL DEFAULT(0),
        [IsActionable] [bit] NOT NULL DEFAULT(0),
        [ActionType] [nvarchar](50) NULL,
        [ActionData] [nvarchar](max) NULL,
        [RelatedEntityType] [nvarchar](50) NULL,
        [RelatedEntityID] [int] NULL,
        [UserID] [int] NULL,
        [CreatedAt] [datetime] NOT NULL DEFAULT(GETDATE()),
        [ReadAt] [datetime] NULL,
        [ExpiresAt] [datetime] NULL,
        [IsDeleted] [bit] NOT NULL DEFAULT(0),
        [DeletedAt] [datetime] NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([NotificationID] ASC)
    );
    CREATE INDEX [IX_Notifications_UserID_IsRead] ON [dbo].[Notifications] ([UserID], [IsRead]);
    CREATE INDEX [IX_Notifications_CreatedAt] ON [dbo].[Notifications] ([CreatedAt] DESC);
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserNotificationSettings]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[UserNotificationSettings](
        [SettingID] [int] IDENTITY(1,1) NOT NULL,
        [UserID] [int] NOT NULL,
        [NotificationType] [nvarchar](50) NOT NULL,
        [IsEnabled] [bit] NOT NULL DEFAULT(1),
        [PlaySound] [bit] NOT NULL DEFAULT(1),
        [ShowPopup] [bit] NOT NULL DEFAULT(1),
        [UpdatedAt] [datetime] NOT NULL DEFAULT(GETDATE()),
        CONSTRAINT [PK_UserNotificationSettings] PRIMARY KEY CLUSTERED ([SettingID] ASC)
    );
END"
            DBModule.ExecuteNonQuery(sql)
        Catch ex As Exception
            Logger.LogError("NotificationManager.EnsureTablesExist", ex)
        End Try
    End Sub

#Region "أنواع الإشعارات"
    Public Enum NotificationType
        [Order] = 1         ' طلب جديد
        [Error] = 2         ' خطأ في النظام
        LowStock = 3        ' نفاذ المخزون
        PrintFailure = 4    ' فشل الطباعة
        System = 5          ' إشعار نظام
        Info = 6            ' معلومة عامة
        Warning = 7         ' تحذير
        Success = 8         ' نجاح عملية
        Payment = 9         ' إشعار دفع
        Shift = 10          ' إشعار وردية
        Employee = 11       ' إشعار موظف
        Expense = 12        ' إشعار مصروف
    End Enum

    Public Enum NotificationPriority
        Normal = 1      ' عادي
        Medium = 2      ' متوسط
        High = 3        ' عالي
        Critical = 4    ' حرج
    End Enum
#End Region

#Region "إنشاء الإشعارات"
    ''' <summary>
    ''' إنشاء إشعار جديد
    ''' </summary>
    Public Function CreateNotification(
        type As NotificationType,
        title As String,
        message As String,
        Optional priority As NotificationPriority = NotificationPriority.Normal,
        Optional userId As Integer? = Nothing,
        Optional icon As String = Nothing,
        Optional isActionable As Boolean = False,
        Optional actionType As String = Nothing,
        Optional actionData As String = Nothing,
        Optional relatedEntityType As String = Nothing,
        Optional relatedEntityId As Integer? = Nothing,
        Optional expiresInMinutes As Integer? = Nothing,
        Optional showToast As Boolean = True
    ) As Integer

        Try
            ' التحقق من إعدادات المستخدم - هل الإشعار مُفعّل؟
            If Not IsNotificationEnabledForUser(type, userId) Then
                Return 0
            End If

            Dim expiresAt As DateTime? = Nothing
            If expiresInMinutes.HasValue Then
                expiresAt = DateTime.Now.AddMinutes(expiresInMinutes.Value)
            End If

            Dim query As String = "
                INSERT INTO Notifications (
                    NotificationType, Title, Message, Icon, Priority,
                    IsActionable, ActionType, ActionData,
                    RelatedEntityType, RelatedEntityID,
                    UserID, ExpiresAt
                ) VALUES (
                    @Type, @Title, @Message, @Icon, @Priority,
                    @IsActionable, @ActionType, @ActionData,
                    @RelatedEntityType, @RelatedEntityID,
                    @UserID, @ExpiresAt
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);"

            Dim params As New Dictionary(Of String, Object) From {
                {"@Type", type.ToString()},
                {"@Title", title},
                {"@Message", message},
                {"@Icon", If(icon, GetDefaultIcon(type))},
                {"@Priority", CInt(priority)},
                {"@IsActionable", isActionable},
                {"@ActionType", If(actionType, DBNull.Value)},
                {"@ActionData", If(actionData, DBNull.Value)},
                {"@RelatedEntityType", If(relatedEntityType, DBNull.Value)},
                {"@RelatedEntityID", If(relatedEntityId, DBNull.Value)},
                {"@UserID", If(userId, DBNull.Value)},
                {"@ExpiresAt", If(expiresAt, DBNull.Value)}
            }

            Dim notificationId As Integer = Convert.ToInt32(DBModule.ExecuteScalar(query, params))

            ' إطلاق حدث الإشعار الجديد
            If notificationId > 0 Then
                Dim notification As New NotificationEventArgs With {
                    .NotificationId = notificationId,
                    .Type = type,
                    .Title = title,
                    .Message = message,
                    .Priority = priority
                }
                RaiseEvent NotificationReceived(Me, notification)

                ' عرض Toast Notification إذا كان مفعلاً
                If showToast Then
                    ShowToastForNotification(type, title, message, priority, isActionable, actionType, actionData, relatedEntityId)
                End If
            End If

            Return notificationId

        Catch ex As Exception
            Logger.LogError("NotificationManager.CreateNotification", ex)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' عرض Toast Notification للإشعار
    ''' </summary>
    Private Sub ShowToastForNotification(
        type As NotificationType,
        title As String,
        message As String,
        priority As NotificationPriority,
        isActionable As Boolean,
        actionType As String,
        actionData As String,
        relatedEntityId As Integer?
    )
        Try
            ' تحويل نوع الإشعار إلى ToastType
            Dim toastType As ToastType
            Select Case type
                Case NotificationType.Success
                    toastType = ToastType.Success
                Case NotificationType.Error
                    toastType = ToastType.Error
                Case NotificationType.Warning
                    toastType = ToastType.Warning
                Case Else
                    toastType = ToastType.Info
            End Select

            ' إنشاء نموذج Toast متطور
            Dim toastModel As New ToastModelAdvanced With {
                .Type = toastType,
                .Title = title,
                .Message = message,
                .Priority = CType(priority, ToastPriority),
                .RelatedNotificationId = relatedEntityId
            }

            ' إضافة إجراء تفاعلي إذا كان الإشعار قابل للتفاعل
            If isActionable AndAlso Not String.IsNullOrWhiteSpace(actionType) Then
                toastModel.ClickAction = Sub()
                                             HandleNotificationAction(actionType, actionData)
                                         End Sub
            End If

            ' تجميع الإشعارات المتشابهة إذا كان مفعلاً
            If SettingsManager.GetBoolSetting(SettingsKeys.NotificationStackSimilar, False) Then
                toastModel.CanStack = True
                toastModel.GroupKey = type.ToString()
            End If

            ' عرض الإشعار
            ToastManagerAdvanced.Show(toastModel)

        Catch ex As Exception
            Logger.LogError("NotificationManager.ShowToastForNotification", ex)
        End Try
    End Sub

    ''' <summary>
    ''' معالجة إجراء الإشعار عند النقر
    ''' </summary>
    Private Sub HandleNotificationAction(actionType As String, actionData As String)
        Try
            Select Case actionType
                Case "OpenOrder"
                    ' فتح نافذة الطلب
                    ' TODO: تنفيذ فتح الطلب

                Case "OpenProduct"
                    ' فتح نافذة المنتج
                    ' TODO: تنفيذ فتح المنتج

                Case "OpenPrinterSettings"
                    ' فتح إعدادات الطابعة
                    ' TODO: تنفيذ فتح الإعدادات

                Case "OpenShifts"
                    ' فتح نافذة الورديات
                    ' TODO: تنفيذ فتح الورديات

                Case "OpenExpenses"
                    ' فتح نافذة المصروفات
                    ' TODO: تنفيذ فتح المصروفات

                Case "OpenPurchases"
                    ' فتح نافذة المشتريات
                    ' TODO: تنفيذ فتح المشتريات
            End Select

        Catch ex As Exception
            Logger.LogError("NotificationManager.HandleNotificationAction", ex)
        End Try
    End Sub

    ''' <summary>
    ''' إشعار طلب جديد
    ''' </summary>
    Public Function NotifyNewOrder(orderNumber As String, amount As Decimal, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.Order,
            "طلب جديد 🛒",
            $"تم استلام طلب رقم #{orderNumber} بقيمة {amount:N2} ج.م",
            NotificationPriority.Medium,
            userId,
            "cart",
            True,
            "OpenOrder",
            orderNumber
        )
    End Function

    ''' <summary>
    ''' إشعار نفاذ مخزون
    ''' </summary>
    Public Function NotifyLowStock(productName As String, currentStock As Integer, minStock As Integer, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.LowStock,
            "تحذير: نفاذ المخزون ⚠️",
            $"المنتج '{productName}' أوشك على النفاذ - الكمية الحالية: {currentStock} (الحد الأدنى: {minStock})",
            NotificationPriority.High,
            userId,
            "stock",
            True,
            "OpenProduct",
            productName
        )
    End Function

    ''' <summary>
    ''' إشعار فشل طباعة
    ''' </summary>
    Public Function NotifyPrintFailure(printerName As String, errorMessage As String, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.PrintFailure,
            "فشل الطباعة 🖨️",
            $"فشلت الطباعة على الطابعة '{printerName}': {errorMessage}",
            NotificationPriority.High,
            userId,
            "printer",
            True,
            "OpenPrinterSettings"
        )
    End Function

    ''' <summary>
    ''' إشعار خطأ في النظام
    ''' </summary>
    Public Function NotifyError(title As String, message As String, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.Error,
            title,
            message,
            NotificationPriority.High,
            userId,
            "error"
        )
    End Function

    ''' <summary>
    ''' إشعار نجاح
    ''' </summary>
    Public Function NotifySuccess(title As String, message As String, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.Success,
            title,
            message,
            NotificationPriority.Normal,
            userId,
            "check"
        )
    End Function

    ''' <summary>
    ''' إشعار معلومة
    ''' </summary>
    Public Function NotifyInfo(title As String, message As String, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.Info,
            title,
            message,
            NotificationPriority.Normal,
            userId,
            "info"
        )
    End Function

    ''' <summary>
    ''' إشعار وردية (فتح أو إغلاق)
    ''' </summary>
    Public Function NotifyShift(title As String, message As String, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.Shift,
            title,
            message,
            NotificationPriority.Normal,
            userId,
            "clock",
            True,
            "OpenShifts"
        )
    End Function

    ''' <summary>
    ''' إشعار تسجيل مصروف
    ''' </summary>
    Public Function NotifyExpense(title As String, message As String, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.Expense,
            title,
            message,
            NotificationPriority.Normal,
            userId,
            "money",
            True,
            "OpenExpenses"
        )
    End Function

    ''' <summary>
    ''' إشعار فاتورة مشتريات وتوريد
    ''' </summary>
    Public Function NotifyPurchase(invoiceNo As String, totalAmount As Decimal, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.Payment,
            "فاتورة مشتريات جديدة 📥",
            $"تم تسجيل فاتورة شراء رقم #{invoiceNo} بقيمة {totalAmount:N2} ج.م وتوريد الأصناف للمخزن",
            NotificationPriority.Normal,
            userId,
            "stock",
            True,
            "OpenPurchases",
            invoiceNo
        )
    End Function

    ''' <summary>
    ''' إشعار هالك مطبخ
    ''' </summary>
    Public Function NotifyKitchenWaste(wasteNumber As String, Optional userId As Integer? = Nothing) As Integer
        Return CreateNotification(
            NotificationType.Warning,
            "تسجيل هالك مطبخ 🗑️",
            $"تم تسجيل مستند هالك مطبخ برقم #{wasteNumber} وتسوية الخامات بالمخزن",
            NotificationPriority.Medium,
            userId,
            "warning",
            False
        )
    End Function

    ''' <summary>
    ''' فحص دوري للمخزون المنخفض وإنشاء إشعارات تلقائية للأصناف التي بلغت حد الطلب
    ''' </summary>
    Public Async Function CheckAndNotifyLowStockAsync() As Task
        Await Task.Run(Sub()
            Try
                If Not SettingsManager.GetBoolSetting(SettingsKeys.NotificationLowStockAlert, True) Then Return

                ' البحث عن الأصناف التي وصلت للحد الأدنى ولم يُرسل لها إشعار خلال آخر 6 ساعات
                Dim sql As String = "
                    SELECT TOP 10 p.Product_ID, p.ProductNameAr, ISNULL(s.CurrentStock, 0) AS CurrentStock, ISNULL(s.MinStock, 5) AS MinStock
                    FROM StoreStock s
                    INNER JOIN Products p ON s.MaterialID = p.Product_ID
                    WHERE s.CurrentStock <= ISNULL(s.MinStock, 5)
                      AND (p.IsDeleted = 0 OR p.IsDeleted IS NULL)
                      AND NOT EXISTS (
                          SELECT 1 FROM Notifications n 
                          WHERE n.NotificationType = 'LowStock' 
                            AND n.RelatedEntityType = 'Product' 
                            AND n.RelatedEntityID = p.Product_ID 
                            AND n.CreatedAt >= DATEADD(HOUR, -6, GETDATE())
                      )"

                Dim dt As DataTable = DBModule.ExecuteQuery(sql)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        Dim prodId As Integer = Convert.ToInt32(row("Product_ID"))
                        Dim prodName As String = If(Not IsDBNull(row("ProductNameAr")), row("ProductNameAr").ToString(), "صنف")
                        Dim currStock As Decimal = Convert.ToDecimal(row("CurrentStock"))
                        Dim minStock As Decimal = Convert.ToDecimal(row("MinStock"))

                        CreateNotification(
                            NotificationType.LowStock,
                            "تحذير: نفاذ المخزون ⚠️",
                            $"المنتج '{prodName}' أوشك على النفاذ - الكمية الحالية: {currStock:N0} (الحد الأدنى: {minStock:N0})",
                            NotificationPriority.High,
                            Nothing,
                            "stock",
                            True,
                            "OpenProduct",
                            prodName,
                            "Product",
                            prodId
                        )
                    Next
                End If
            Catch ex As Exception
                Logger.LogError("NotificationManager.CheckAndNotifyLowStockAsync", ex)
            End Try
        End Sub)
    End Function
#End Region

#Region "قراءة وإدارة الإشعارات"
    ''' <summary>
    ''' جلب الإشعارات غير المقروءة للمستخدم الحالي
    ''' </summary>
    Public Function GetUnreadNotifications(Optional userId As Integer? = Nothing) As DataTable
        Try
            Dim targetUserId As Integer? = If(userId, Session.CurrentUserID)

            Dim query As String = "
                SELECT TOP 50
                    NotificationID, NotificationType, Title, Message, Icon,
                    Priority, IsActionable, ActionType, ActionData,
                    RelatedEntityType, RelatedEntityID, CreatedAt
                FROM Notifications
                WHERE IsRead = 0
                    AND IsDeleted = 0
                    AND (UserID IS NULL OR UserID = @UserID)
                    AND (ExpiresAt IS NULL OR ExpiresAt > GETDATE())
                ORDER BY Priority DESC, CreatedAt DESC"

            Dim params As New Dictionary(Of String, Object) From {
                {"@UserID", If(targetUserId, DBNull.Value)}
            }

            Return DBModule.ExecuteQuery(query, params)
        Catch ex As Exception
            Logger.LogError("NotificationManager.GetUnreadNotifications", ex)
            Return New DataTable()
        End Try
    End Function

    ''' <summary>
    ''' عدد الإشعارات غير المقروءة
    ''' </summary>
    Public Function GetUnreadCount(Optional userId As Integer? = Nothing) As Integer
        Try
            Dim targetUserId As Integer? = If(userId, Session.CurrentUserID)

            Dim query As String = "
                SELECT COUNT(*)
                FROM Notifications
                WHERE IsRead = 0
                    AND IsDeleted = 0
                    AND (UserID IS NULL OR UserID = @UserID)
                    AND (ExpiresAt IS NULL OR ExpiresAt > GETDATE())"

            Dim params As New Dictionary(Of String, Object) From {
                {"@UserID", If(targetUserId, DBNull.Value)}
            }

            Return Convert.ToInt32(DBModule.ExecuteScalar(query, params))
        Catch ex As Exception
            Logger.LogError("NotificationManager.GetUnreadCount", ex)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' وضع علامة مقروء على إشعار
    ''' </summary>
    Public Function MarkAsRead(notificationId As Integer) As Boolean
        Try
            Dim query As String = "
                UPDATE Notifications
                SET IsRead = 1, ReadAt = GETDATE()
                WHERE NotificationID = @NotificationID"

            Dim params As New Dictionary(Of String, Object) From {
                {"@NotificationID", notificationId}
            }

            DBModule.ExecuteNonQuery(query, params)

            ' إطلاق حدث القراءة
            RaiseEvent NotificationRead(Me, New NotificationEventArgs With {.NotificationId = notificationId})

            Return True
        Catch ex As Exception
            Logger.LogError("NotificationManager.MarkAsRead", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' وضع علامة مقروء على جميع الإشعارات
    ''' </summary>
    Public Function MarkAllAsRead(Optional userId As Integer? = Nothing) As Boolean
        Try
            Dim targetUserId As Integer? = If(userId, Session.CurrentUserID)

            Dim query As String = "
                UPDATE Notifications
                SET IsRead = 1, ReadAt = GETDATE()
                WHERE IsRead = 0
                    AND IsDeleted = 0
                    AND (UserID IS NULL OR UserID = @UserID)"

            Dim params As New Dictionary(Of String, Object) From {
                {"@UserID", If(targetUserId, DBNull.Value)}
            }

            DBModule.ExecuteNonQuery(query, params)
            Return True
        Catch ex As Exception
            Logger.LogError("NotificationManager.MarkAllAsRead", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' حذف إشعار (حذف ناعم)
    ''' </summary>
    Public Function DeleteNotification(notificationId As Integer) As Boolean
        Try
            Dim query As String = "
                UPDATE Notifications
                SET IsDeleted = 1, DeletedAt = GETDATE()
                WHERE NotificationID = @NotificationID"

            Dim params As New Dictionary(Of String, Object) From {
                {"@NotificationID", notificationId}
            }

            DBModule.ExecuteNonQuery(query, params)
            Return True
        Catch ex As Exception
            Logger.LogError("NotificationManager.DeleteNotification", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' حذف جميع الإشعارات المقروءة
    ''' </summary>
    Public Function DeleteAllRead(Optional userId As Integer? = Nothing) As Boolean
        Try
            Dim targetUserId As Integer? = If(userId, Session.CurrentUserID)

            Dim query As String = "
                UPDATE Notifications
                SET IsDeleted = 1, DeletedAt = GETDATE()
                WHERE IsRead = 1
                    AND IsDeleted = 0
                    AND (UserID IS NULL OR UserID = @UserID)"

            Dim params As New Dictionary(Of String, Object) From {
                {"@UserID", If(targetUserId, DBNull.Value)}
            }

            DBModule.ExecuteNonQuery(query, params)
            Return True
        Catch ex As Exception
            Logger.LogError("NotificationManager.DeleteAllRead", ex)
            Return False
        End Try
    End Function
#End Region

#Region "الإعدادات والأصوات"
    ''' <summary>
    ''' التحقق من تفعيل الإشعار للمستخدم
    ''' </summary>
    Private Function IsNotificationEnabledForUser(type As NotificationType, userId As Integer?) As Boolean
        Try
            Dim targetUserId As Integer = If(userId, Session.CurrentUserID)

            ' التحقق من الإعدادات العامة أولاً
            Dim settingKey As String = GetNotificationSettingKey(type)
            If Not String.IsNullOrEmpty(settingKey) Then
                If Not SettingsManager.GetBoolSetting(settingKey, True) Then
                    Return False
                End If
            End If

            ' TODO: التحقق من إعدادات المستخدم الخاصة من جدول UserNotificationSettings
            Return True
        Catch ex As Exception
            Return True ' افتراضياً نفعّل الإشعار في حالة الخطأ
        End Try
    End Function

    ''' <summary>
    ''' تشغيل صوت الإشعار
    ''' </summary>
    Private Sub PlayNotificationSound(type As NotificationType, userId As Integer?)
        Try
            Dim settingKey As String = Nothing

            Select Case type
                Case NotificationType.Order
                    settingKey = SettingsKeys.NotificationNewOrderSound
                Case NotificationType.Error
                    settingKey = SettingsKeys.NotificationErrorSound
                Case NotificationType.LowStock
                    settingKey = SettingsKeys.NotificationLowStockAlert
                Case NotificationType.PrintFailure
                    settingKey = SettingsKeys.NotificationPrintFailAlert
            End Select

            If Not String.IsNullOrEmpty(settingKey) AndAlso SettingsManager.GetBoolSetting(settingKey, True) Then
                ' تشغيل الصوت
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
        Catch ex As Exception
            ' تجاهل أخطاء تشغيل الصوت
            Logger.LogError("NotificationManager.vb:706", ex)
        End Try
    End Sub

    ''' <summary>
    ''' الحصول على مفتاح الإعداد لنوع الإشعار
    ''' </summary>
    Private Function GetNotificationSettingKey(type As NotificationType) As String
        Select Case type
            Case NotificationType.Order
                Return SettingsKeys.NotificationNewOrderSound
            Case NotificationType.Error
                Return SettingsKeys.NotificationErrorSound
            Case NotificationType.LowStock
                Return SettingsKeys.NotificationLowStockAlert
            Case NotificationType.PrintFailure
                Return SettingsKeys.NotificationPrintFailAlert
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' الحصول على الأيقونة الافتراضية لنوع الإشعار
    ''' </summary>
    Private Function GetDefaultIcon(type As NotificationType) As String
        Select Case type
            Case NotificationType.Order : Return "cart"
            Case NotificationType.Error : Return "error"
            Case NotificationType.LowStock : Return "stock"
            Case NotificationType.PrintFailure : Return "printer"
            Case NotificationType.System : Return "settings"
            Case NotificationType.Info : Return "info"
            Case NotificationType.Warning : Return "warning"
            Case NotificationType.Success : Return "check"
            Case NotificationType.Payment : Return "money"
            Case NotificationType.Shift : Return "clock"
            Case NotificationType.Employee : Return "user"
            Case NotificationType.Expense : Return "expense"
            Case Else : Return "bell"
        End Select
    End Function
#End Region
End Class

''' <summary>
''' معلومات حدث الإشعار
''' </summary>
Public Class NotificationEventArgs
    Inherits EventArgs

    Public Property NotificationId As Integer
    Public Property Type As NotificationManager.NotificationType
    Public Property Title As String
    Public Property Message As String
    Public Property Priority As NotificationManager.NotificationPriority
End Class
