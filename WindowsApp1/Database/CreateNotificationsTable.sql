-- جدول الإشعارات في النظام
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notifications]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Notifications](
        [NotificationID] [int] IDENTITY(1,1) NOT NULL,
        [NotificationType] [nvarchar](50) NOT NULL, -- نوع الإشعار: Order, Error, LowStock, PrintFailure, System, Info
        [Title] [nvarchar](200) NOT NULL, -- عنوان الإشعار
        [Message] [nvarchar](max) NOT NULL, -- نص الإشعار
        [Icon] [nvarchar](50) NULL, -- أيقونة الإشعار
        [Priority] [int] NOT NULL DEFAULT(1), -- الأولوية: 1=عادي، 2=متوسط، 3=عالي، 4=حرج
        [IsRead] [bit] NOT NULL DEFAULT(0), -- هل تم القراءة
        [IsActionable] [bit] NOT NULL DEFAULT(0), -- هل يحتاج إجراء
        [ActionType] [nvarchar](50) NULL, -- نوع الإجراء المطلوب
        [ActionData] [nvarchar](max) NULL, -- بيانات الإجراء (JSON)
        [RelatedEntityType] [nvarchar](50) NULL, -- نوع الكيان المرتبط (Order, Product, etc)
        [RelatedEntityID] [int] NULL, -- معرف الكيان المرتبط
        [UserID] [int] NULL, -- المستخدم المستهدف (NULL = للجميع)
        [CreatedAt] [datetime] NOT NULL DEFAULT(GETDATE()),
        [ReadAt] [datetime] NULL, -- تاريخ القراءة
        [ExpiresAt] [datetime] NULL, -- تاريخ انتهاء الصلاحية
        [IsDeleted] [bit] NOT NULL DEFAULT(0),
        [DeletedAt] [datetime] NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([NotificationID] ASC)
    )

    -- إنشاء Indexes لتحسين الأداء
    CREATE INDEX [IX_Notifications_UserID_IsRead] ON [dbo].[Notifications] ([UserID], [IsRead])
    CREATE INDEX [IX_Notifications_CreatedAt] ON [dbo].[Notifications] ([CreatedAt] DESC)
    CREATE INDEX [IX_Notifications_Type_Priority] ON [dbo].[Notifications] ([NotificationType], [Priority])
    CREATE INDEX [IX_Notifications_IsDeleted] ON [dbo].[Notifications] ([IsDeleted]) WHERE [IsDeleted] = 0
END
GO

-- جدول إعدادات الإشعارات لكل مستخدم
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
        CONSTRAINT [PK_UserNotificationSettings] PRIMARY KEY CLUSTERED ([SettingID] ASC),
        CONSTRAINT [UK_UserNotificationSettings] UNIQUE ([UserID], [NotificationType])
    )
END
GO
