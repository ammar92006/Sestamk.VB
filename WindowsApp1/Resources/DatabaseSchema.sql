-- ===================================================================
-- Sestamk - Core Database Schema Initialization DDL
-- Comprehensive Schema for 74 Tables matching SestamkDB and LocalDB
-- ===================================================================

-- -------------------------------------------------------------
-- 1. Table: [dbo].[Addons]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Addons]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Addons] (
        [AddonID] INT IDENTITY(1,1) NOT NULL,
        [AddonCode] NVARCHAR(20) NULL,
        [AddonNameAr] NVARCHAR(100) NOT NULL,
        [AddonNameEn] NVARCHAR(100) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_Addons] PRIMARY KEY ([AddonID])
    );
END
GO

-- -------------------------------------------------------------
-- 1b. Table: [dbo].[KitchenComments]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[KitchenComments]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[KitchenComments] (
        [CommentID] INT IDENTITY(1,1) NOT NULL,
        [CommentCode] NVARCHAR(50) NULL,
        [CommentText] NVARCHAR(250) NOT NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_KitchenComments] PRIMARY KEY ([CommentID])
    );
END
GO

-- -------------------------------------------------------------
-- 2. Table: [dbo].[AppScreens]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[AppScreens]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[AppScreens] (
        [ScreenID] INT IDENTITY(1,1) NOT NULL,
        [FormName] NVARCHAR(100) NOT NULL,
        [ScreenDisplayName] NVARCHAR(150) NOT NULL,
        [Category] NVARCHAR(100) NOT NULL,
        CONSTRAINT [PK_AppScreens] PRIMARY KEY ([ScreenID])
    );
END
GO

-- -------------------------------------------------------------
-- 3. Table: [dbo].[AppSettings]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[AppSettings]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[AppSettings] (
        [ID] INT IDENTITY(1,1) NOT NULL,
        [SettingKey] NVARCHAR(MAX) NULL,
        [SettingValue] NVARCHAR(MAX) NULL,
        CONSTRAINT [PK_AppSettings] PRIMARY KEY ([ID])
    );
END
GO

-- -------------------------------------------------------------
-- 4. Table: [dbo].[BRANCH_TBL]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[BRANCH_TBL]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[BRANCH_TBL] (
        [BRAN_ID] NUMERIC(18, 0) NOT NULL,
        [BRAN_CODE] NUMERIC(18, 0) NULL,
        [BRAN_NAME] VARCHAR(50) NULL,
        [BRAN_ADDRESS] VARCHAR(50) NULL,
        [BRAN_PHONE] VARCHAR(50) NULL,
        [BRAN_MOBILE] VARCHAR(50) NULL,
        [BRAN_OPENDATE] DATE NULL,
        [BRAN_STATE] INT NULL,
        [Com_ID] NUMERIC(18, 0) NULL,
        CONSTRAINT [PK_BRANCH_TBL] PRIMARY KEY ([BRAN_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 5. Table: [dbo].[Backup_Log]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Backup_Log]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Backup_Log] (
        [Backup_ID] INT IDENTITY(1,1) NOT NULL,
        [Backup_File] NVARCHAR(MAX) NULL,
        [Backup_Date] DATETIME NULL DEFAULT getdate(),
        [Backup_By] NVARCHAR(MAX) NULL,
        [Backup_Slot] INT NULL,
        [Backup_Size] NVARCHAR(50) NULL,
        CONSTRAINT [PK_Backup_Log] PRIMARY KEY ([Backup_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 6. Table: [dbo].[Branches]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Branches]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Branches] (
        [BranchID] INT IDENTITY(1,1) NOT NULL,
        [BranchCode] NVARCHAR(20) NULL,
        [BranchName] NVARCHAR(150) NOT NULL,
        [Phone] NVARCHAR(30) NULL,
        [Mobile] NVARCHAR(30) NULL,
        [Address] NVARCHAR(500) NULL,
        [Notes] NVARCHAR(500) NULL,
        [IsMainBranch] BIT NOT NULL DEFAULT 0,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [ManagerEmployeeID] INT NULL,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [CreatedBy] INT NULL,
        [IsDefault] BIT NOT NULL DEFAULT 0,
        CONSTRAINT [PK_Branches] PRIMARY KEY ([BranchID])
    );
END
GO

-- -------------------------------------------------------------
-- 7. Table: [dbo].[Categories]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Categories]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Categories] (
        [Category_ID] INT IDENTITY(1,1) NOT NULL,
        [CategoryCode] NVARCHAR(MAX) NULL,
        [Category_NameAr] NVARCHAR(MAX) NOT NULL,
        [CategoryNameEn] NVARCHAR(MAX) NULL,
        [Imagebase64] NVARCHAR(MAX) NULL,
        [Description] NVARCHAR(MAX) NULL,
        [IsActive] BIT NULL,
        [IsDeleted] BIT NULL,
        [ColorID] INT NULL,
        [CategoryTypeID] INT NULL,
        [PrinterID] INT NULL,
        [CategoryID] INT NULL,
        [CategoryName] NVARCHAR(150) NULL,
        [Category_Name] NVARCHAR(150) NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Category_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 8. Table: [dbo].[CategoryTypes]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[CategoryTypes]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[CategoryTypes] (
        [CategoryTypeID] INT IDENTITY(1,1) NOT NULL,
        [TypeCode] NVARCHAR(20) NULL,
        [TypeName] NVARCHAR(MAX) NOT NULL,
        [IsActive] BIT NULL,
        [IsDeleted] BIT NULL DEFAULT 0,
        CONSTRAINT [PK_CategoryTypes] PRIMARY KEY ([CategoryTypeID])
    );
END
GO

-- -------------------------------------------------------------
-- 9. Table: [dbo].[Colors]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Colors]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Colors] (
        [ColorID] INT IDENTITY(1,1) NOT NULL,
        [ColorCode] NVARCHAR(30) NULL,
        [ColorName] NVARCHAR(100) NULL,
        [HexCode] NVARCHAR(20) NULL,
        [IsActive] BIT NULL DEFAULT 1,
        [IsDeleted] BIT NULL DEFAULT 0,
        [Notes] NVARCHAR(250) NULL,
        CONSTRAINT [PK_Colors] PRIMARY KEY ([ColorID])
    );
END
GO

-- -------------------------------------------------------------
-- 10. Table: [dbo].[Company_info_TBL]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Company_info_TBL]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Company_info_TBL] (
        [Com_ID] NUMERIC(18, 0) NOT NULL,
        [Com_Code] NUMERIC(18, 0) NULL,
        [Com_NAME] NVARCHAR(MAX) NULL,
        [Com_ADDRESS1] NVARCHAR(MAX) NULL,
        [Com_ADDRESS2] NVARCHAR(MAX) NULL,
        [Com_ADDRESS3] NVARCHAR(MAX) NULL,
        [Com_Mobile1] NVARCHAR(MAX) NULL,
        [Com_Mobile2] NVARCHAR(MAX) NULL,
        [Com_Mobile3] NVARCHAR(MAX) NULL,
        [Com_FAX] NVARCHAR(MAX) NULL,
        [Com_Title] NVARCHAR(MAX) NULL,
        [Com_Note] NVARCHAR(MAX) NULL,
        CONSTRAINT [PK_Company_info_TBL] PRIMARY KEY ([Com_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 11. Table: [dbo].[Customer]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Customer]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Customer] (
        [CustomerID] INT IDENTITY(1,1) NOT NULL,
        [CustomerCode] NVARCHAR(50) NULL,
        [CustomerName] NVARCHAR(150) NOT NULL,
        [Phone] NVARCHAR(50) NULL,
        [PhoneNumber] NVARCHAR(50) NULL,
        [Address] NVARCHAR(250) NULL,
        [CreditLimit] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Balance] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [CurrentBalance] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Notes] NVARCHAR(MAX) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_Customer] PRIMARY KEY ([CustomerID])
    );
END
GO

-- -------------------------------------------------------------
-- 12. Table: [dbo].[CustomerBalanceLog]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[CustomerBalanceLog]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[CustomerBalanceLog] (
        [LogID] INT IDENTITY(1,1) NOT NULL,
        [CustomerID] INT NULL,
        [CustomerCode] NVARCHAR(MAX) NULL,
        [CustomerName] NVARCHAR(MAX) NULL,
        [OldBalance] DECIMAL(18, 2) NULL,
        [PaidAmount] DECIMAL(18, 2) NULL,
        [NewBalance] DECIMAL(18, 2) NULL,
        [Notes] NVARCHAR(MAX) NULL,
        [UserName] NVARCHAR(MAX) NULL,
        [ActionDate] DATETIME NULL
    );
END
GO

-- -------------------------------------------------------------
-- 13. Table: [dbo].[CustomerTransactions]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[CustomerTransactions]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[CustomerTransactions] (
        [TransactionID] INT IDENTITY(1,1) NOT NULL,
        [TransactionDate] DATETIME NOT NULL DEFAULT getdate(),
        [CustomerID] INT NOT NULL,
        [InvoiceID] INT NULL,
        [TransactionType] NVARCHAR(50) NOT NULL,
        [Debit] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Credit] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [BalanceAfter] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Notes] NVARCHAR(500) NULL,
        [ShiftID] INT NULL,
        [UserID] INT NOT NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [BranchID] INT NULL,
        CONSTRAINT [PK_CustomerTransactions] PRIMARY KEY ([TransactionID])
    );
END
GO

-- -------------------------------------------------------------
-- 14. Table: [dbo].[Customer_Account_TBL]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Customer_Account_TBL]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Customer_Account_TBL] (
        [Cust_A_ID] NUMERIC(18, 0) NOT NULL,
        [Cust_A_Code] NUMERIC(18, 0) NULL,
        [Cust_A_Name] VARCHAR(200) NULL,
        [Cust_A_N_Name] VARCHAR(MAX) NULL,
        [Cust_A_Date] DATE NULL,
        [Cust_A_Dept] DECIMAL(18, 2) NULL,
        [Trd_ID] NUMERIC(18, 0) NULL,
        [Cust_A_State] BIT NULL,
        [Cust_A_Note] VARCHAR(MAX) NULL,
        [Cust_ID] NUMERIC(18, 0) NULL,
        CONSTRAINT [PK_Customer_Account_TBL] PRIMARY KEY ([Cust_A_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 15. Table: [dbo].[Customer_TBL]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Customer_TBL]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Customer_TBL] (
        [Cust_ID] NUMERIC(18, 0) NOT NULL,
        [Cust_Code] NUMERIC(18, 0) NULL,
        [Cust_Name] VARCHAR(200) NULL,
        [Cust_N_Name] VARCHAR(MAX) NULL,
        [Cust_S_Date] DATE NULL,
        [Cust_Major] VARCHAR(MAX) NULL,
        [Cust_Address] VARCHAR(MAX) NULL,
        [Cust_Mobile] VARCHAR(MAX) NULL,
        [Cust_Mobile1] VARCHAR(MAX) NULL,
        [Cust_State] BIT NULL,
        [Cust_Note] VARCHAR(MAX) NULL,
        CONSTRAINT [PK_Customer_TBL] PRIMARY KEY ([Cust_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 16. Table: [dbo].[Customers]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Customers]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Customers] (
        [CustomerID] INT IDENTITY(1,1) NOT NULL,
        [CustomerCode] NVARCHAR(50) NULL,
        [CustomerName] NVARCHAR(100) NULL,
        [Phone1] NVARCHAR(20) NULL,
        [Phone2] NVARCHAR(20) NULL,
        [Email] NVARCHAR(100) NULL,
        [AreaID] INT NULL,
        [Address] NVARCHAR(255) NULL,
        [CurrentBalance] DECIMAL(18, 2) NULL DEFAULT 0,
        [AllowCredit] BIT NULL DEFAULT 1,
        [CreditLimit] DECIMAL(18, 2) NULL DEFAULT 0,
        [IsDiscountPercent] BIT NULL,
        [DiscountPercent] FLOAT NULL DEFAULT 0,
        [IsDeleted] BIT NULL DEFAULT 0,
        [IsActive] BIT NULL DEFAULT 1,
        [StopReason] NVARCHAR(255) NULL,
        [Rating] TINYINT NULL DEFAULT 5,
        [Notes] NVARCHAR(MAX) NULL,
        [CreatedDate] DATETIME NULL DEFAULT getdate(),
        [CreatedByUserID] INT NULL,
        [LastTransactionDate] DATETIME NULL,
        [Phone] NVARCHAR(50) NULL,
        [Balance] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [PhoneNumber] NVARCHAR(50) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID])
    );
END
GO

-- -------------------------------------------------------------
-- 17. Table: [dbo].[DeliveryAreas]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[DeliveryAreas]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DeliveryAreas] (
        [AreaID] INT IDENTITY(1,1) NOT NULL,
        [AreaCode] NVARCHAR(20) NULL,
        [AreaName] NVARCHAR(100) NOT NULL,
        [Notes] NVARCHAR(250) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [DeliveryFee] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CONSTRAINT [PK_DeliveryAreas] PRIMARY KEY ([AreaID])
    );
END
GO

-- -------------------------------------------------------------
-- 18. Table: [dbo].[DeliveryDrivers]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[DeliveryDrivers]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DeliveryDrivers] (
        [DriverID] INT IDENTITY(1,1) NOT NULL,
        [DriverCode] NVARCHAR(20) NOT NULL,
        [DriverName] NVARCHAR(150) NOT NULL,
        [Phone] NVARCHAR(20) NOT NULL,
        [Phone2] NVARCHAR(20) NULL,
        [NationalID] NVARCHAR(20) NULL,
        [EmployeeID] INT NULL,
        [LicenseNumber] NVARCHAR(50) NULL,
        [VehicleType] NVARCHAR(50) NULL,
        [VehiclePlateNumber] NVARCHAR(50) NULL,
        [IsPercentage] BIT NOT NULL DEFAULT 0,
        [DeliveryFeeValue] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [DriverStatus] TINYINT NOT NULL DEFAULT 1,
        [Notes] NVARCHAR(500) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [CreatedBy] INT NULL,
        [AreaID] INT NULL,
        [VehicleNumber] NVARCHAR(50) NULL,
        CONSTRAINT [PK_DeliveryDrivers] PRIMARY KEY ([DriverID])
    );
END
GO

-- -------------------------------------------------------------
-- 19. Table: [dbo].[Departments]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Departments]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Departments] (
        [DepartmentID] INT IDENTITY(1,1) NOT NULL,
        [DepartmentCode] NVARCHAR(20) NULL,
        [DepartmentName] NVARCHAR(100) NOT NULL,
        [Notes] NVARCHAR(500) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [CreatedBy] INT NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentID])
    );
END
GO

-- -------------------------------------------------------------
-- 20. Table: [dbo].[DriverTransactions]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[DriverTransactions]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DriverTransactions] (
        [TransactionID] INT IDENTITY(1,1) NOT NULL,
        [TransactionDate] DATETIME NOT NULL DEFAULT getdate(),
        [DriverID] INT NOT NULL,
        [InvoiceID] INT NOT NULL,
        [OrderTotal] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [DeliveryFee] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [CollectedAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [IsSettled] BIT NOT NULL DEFAULT 0,
        [SettledAt] DATETIME NULL,
        [ShiftID] INT NOT NULL,
        [UserID] INT NOT NULL,
        [Notes] NVARCHAR(250) NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_DriverTransactions] PRIMARY KEY ([TransactionID])
    );
END
GO

-- -------------------------------------------------------------
-- 21. Table: [dbo].[Employees]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Employees]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Employees] (
        [EmployeeID] INT IDENTITY(1,1) NOT NULL,
        [EmployeeCode] NVARCHAR(20) NOT NULL,
        [ArabicName] NVARCHAR(200) NOT NULL,
        [EnglishName] NVARCHAR(200) NULL,
        [NationalID] NVARCHAR(20) NULL,
        [Phone] NVARCHAR(20) NULL,
        [Phone2] NVARCHAR(20) NULL,
        [Email] NVARCHAR(150) NULL,
        [Address] NVARCHAR(500) NULL,
        [BirthDate] DATE NULL,
        [HireDate] DATE NOT NULL DEFAULT getdate(),
        [ContractEndDate] DATE NULL,
        [BranchID] INT NULL,
        [DepartmentID] INT NULL,
        [JobTitleID] INT NULL,
        [SalarySystemID] INT NULL,
        [BasicSalary] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [TransportationAllowance] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [HousingAllowance] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [OtherAllowances] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [InsuranceStatus] BIT NOT NULL DEFAULT 0,
        [InsuranceAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [OvertimeAllowed] BIT NOT NULL DEFAULT 0,
        [OvertimeRate] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [PersonalPhoto] NVARCHAR(MAX) NULL,
        [NationalIDPhotofront] NVARCHAR(MAX) NULL,
        [NationalIDPhotoback] NVARCHAR(MAX) NULL,
        [Cv] NVARCHAR(MAX) NULL,
        [FingerprintCode] NVARCHAR(50) NULL,
        [EmployeeStatus] TINYINT NOT NULL DEFAULT 1,
        [Gender] TINYINT NULL,
        [Notes] NVARCHAR(MAX) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [CreatedBy] INT NULL,
        [ModifiedAt] DATETIME2 NULL,
        [ModifiedBy] INT NULL,
        [DeletedAt] DATETIME2 NULL,
        [DeletedBy] INT NULL,
        [CheckInTime] TIME NULL,
        [CheckOutTime] TIME NULL,
        [DailyWorkingHours] DECIMAL(5, 2) NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeID])
    );
END
GO

-- -------------------------------------------------------------
-- 22. Table: [dbo].[Expenses]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Expenses]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Expenses] (
        [Expense_ID] INT IDENTITY(1,1) NOT NULL,
        [Expense_Date] DATE NOT NULL DEFAULT CONVERT([date],getdate()),
        [Category] NVARCHAR(50) NULL,
        [Amount] DECIMAL(18, 2) NOT NULL,
        [Payment_Method] NVARCHAR(50) NULL,
        [Payee] NVARCHAR(100) NULL,
        [Payment_Status] NVARCHAR(20) NULL DEFAULT 'Paid',
        [Notes] NVARCHAR(MAX) NULL,
        [Created_By] NVARCHAR(50) NULL,
        [Created_At] DATETIME NULL DEFAULT getdate(),
        [UpdatedAt] DATETIME NULL DEFAULT getdate(),
        [TreasuryID] INT NULL,
        [ExpenseID] INT NULL,
        [ExpenseDate] DATETIME NOT NULL DEFAULT getdate(),
        [ExpenseType] NVARCHAR(100) NULL,
        [UserID] INT NULL,
        [ShiftID] INT NULL,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_Expenses] PRIMARY KEY ([Expense_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 23. Table: [dbo].[JobTitles]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[JobTitles]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[JobTitles] (
        [JobTitleID] INT IDENTITY(1,1) NOT NULL,
        [JobTitleCode] NVARCHAR(20) NULL,
        [JobTitleName] NVARCHAR(100) NOT NULL,
        [DepartmentID] INT NULL,
        [Notes] NVARCHAR(500) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [CreatedBy] INT NULL,
        CONSTRAINT [PK_JobTitles] PRIMARY KEY ([JobTitleID])
    );
END
GO

-- -------------------------------------------------------------
-- 24. Table: [dbo].[KitchenOrderDetails]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[KitchenOrderDetails]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[KitchenOrderDetails] (
        [DetailID] INT IDENTITY(1,1) NOT NULL,
        [KitchenOrderID] INT NOT NULL,
        [ProductID] INT NOT NULL,
        [ProductName] NVARCHAR(200) NOT NULL,
        [SizeName] NVARCHAR(100) NULL,
        [AddonsText] NVARCHAR(500) NULL,
        [Quantity] INT NOT NULL DEFAULT 1,
        [Notes] NVARCHAR(500) NULL,
        [IsCompleted] BIT NOT NULL DEFAULT 0,
        [StationName] NVARCHAR(100) NULL,
        CONSTRAINT [PK_KitchenOrderDetails] PRIMARY KEY ([DetailID])
    );
END
GO

-- -------------------------------------------------------------
-- 25. Table: [dbo].[KitchenOrders]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[KitchenOrders]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[KitchenOrders] (
        [KitchenOrderID] INT IDENTITY(1,1) NOT NULL,
        [OrderNumber] NVARCHAR(50) NOT NULL,
        [OrderType] TINYINT NOT NULL DEFAULT 1,
        [TableID] INT NULL,
        [TableName] NVARCHAR(100) NULL,
        [CustomerName] NVARCHAR(150) NULL,
        [ServerName] NVARCHAR(100) NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [Status] TINYINT NOT NULL DEFAULT 0,
        [PreparationStartedAt] DATETIME NULL,
        [ReadyAt] DATETIME NULL,
        [CompletedAt] DATETIME NULL,
        [Notes] NVARCHAR(500) NULL,
        CONSTRAINT [PK_KitchenOrders] PRIMARY KEY ([KitchenOrderID])
    );
END
GO

-- -------------------------------------------------------------
-- 26. Table: [dbo].[KitchenWaste]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[KitchenWaste]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[KitchenWaste] (
        [WasteID] INT IDENTITY(1,1) NOT NULL,
        [WasteNumber] NVARCHAR(50) NOT NULL,
        [WasteDate] DATETIME NOT NULL DEFAULT getdate(),
        [WasteType] TINYINT NOT NULL DEFAULT 1,
        [StoreID] INT NOT NULL DEFAULT 1,
        [TotalLossAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [ShiftID] INT NULL,
        [UserID] INT NOT NULL DEFAULT 1,
        [ResponsibleStaffName] NVARCHAR(150) NULL,
        [Reason] NVARCHAR(500) NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_KitchenWaste] PRIMARY KEY ([WasteID])
    );
END
GO

-- -------------------------------------------------------------
-- 27. Table: [dbo].[KitchenWasteDetails]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[KitchenWasteDetails]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[KitchenWasteDetails] (
        [DetailID] INT IDENTITY(1,1) NOT NULL,
        [WasteID] INT NOT NULL,
        [MaterialID] INT NULL,
        [ProductID] INT NULL,
        [ItemName] NVARCHAR(200) NOT NULL,
        [Quantity] DECIMAL(18, 4) NOT NULL DEFAULT 1,
        [UnitName] NVARCHAR(50) NULL,
        [UnitCost] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [TotalCost] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Notes] NVARCHAR(500) NULL,
        CONSTRAINT [PK_KitchenWasteDetails] PRIMARY KEY ([DetailID])
    );
END
GO

-- -------------------------------------------------------------
-- 28. Table: [dbo].[Login_Info_TBL]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Login_Info_TBL]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Login_Info_TBL] (
        [ID] INT IDENTITY(1,1) NOT NULL,
        [Login_Code] INT NULL,
        [Login_DeviceName] NVARCHAR(MAX) NULL,
        [Login_MacAddress] NVARCHAR(MAX) NULL,
        [Login_CurrentDate] DATE NULL,
        [Login_CurrentTime] NVARCHAR(MAX) NULL,
        [Login_Username] NVARCHAR(MAX) NULL,
        [Login_Password] NVARCHAR(MAX) NULL,
        [Login_Note] NVARCHAR(MAX) NULL,
        CONSTRAINT [PK_Login_Info_TBL] PRIMARY KEY ([ID])
    );
END
GO

-- -------------------------------------------------------------
-- 29. Table: [dbo].[Main_Cash_TBL]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Main_Cash_TBL]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Main_Cash_TBL] (
        [Cash_ID] NUMERIC(18, 0) NOT NULL,
        [Cash_Code] NUMERIC(18, 0) NULL,
        [Cash_S_Date] DATE NULL,
        [Cash_S_Balance] NUMERIC(18, 2) NULL,
        [Cash_Z_Balance] NUMERIC(18, 2) NULL,
        [Cash_Balance] NUMERIC(18, 2) NULL,
        [Cash_Stats] INT NULL,
        [Cash_Note] NVARCHAR(MAX) NULL,
        [BRAN_ID] NUMERIC(18, 0) NULL,
        CONSTRAINT [PK_Main_Cash_TBL] PRIMARY KEY ([Cash_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 30. Table: [dbo].[MaterialUnits]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[MaterialUnits]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[MaterialUnits] (
        [MaterialUnitID] INT IDENTITY(1,1) NOT NULL,
        [MaterialID] INT NOT NULL,
        [UnitID] INT NOT NULL,
        [ConversionFactor] DECIMAL(18, 2) NOT NULL,
        [Barcode] NVARCHAR(50) NULL,
        [PurchasePrice] DECIMAL(18, 4) NULL DEFAULT 0.0000,
        [Notes] NVARCHAR(200) NULL,
        [CostPrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CONSTRAINT [PK_MaterialUnits] PRIMARY KEY ([MaterialUnitID])
    );
END
GO

-- -------------------------------------------------------------
-- 31. Table: [dbo].[Partners]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Partners]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Partners] (
        [Partner_ID] INT IDENTITY(1,1) NOT NULL,
        [Partner_Name] NVARCHAR(MAX) NULL,
        [Partner_Type] NVARCHAR(MAX) NULL,
        [Phone] NVARCHAR(MAX) NULL,
        [Address] NVARCHAR(MAX) NULL,
        [Email] NVARCHAR(MAX) NULL,
        [CompanyName] NVARCHAR(MAX) NULL,
        [Balance] NUMERIC(18, 2) NULL DEFAULT 0,
        [Notes] NVARCHAR(MAX) NULL,
        [CreatedAt] DATETIME NULL DEFAULT getdate(),
        [ImagePath] NVARCHAR(MAX) NULL,
        CONSTRAINT [PK_Partners] PRIMARY KEY ([Partner_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 32. Table: [dbo].[PendingInvoices]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[PendingInvoices]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[PendingInvoices] (
        [PendingID] INT IDENTITY(1,1) NOT NULL,
        [PendingNumber] NVARCHAR(50) NOT NULL,
        [PendingDate] DATETIME NOT NULL DEFAULT getdate(),
        [ShiftID] INT NOT NULL,
        [UserID] INT NOT NULL,
        [OrderType] TINYINT NOT NULL DEFAULT 1,
        [CustomerID] INT NULL,
        [CustomerName] NVARCHAR(150) NULL,
        [TableID] INT NULL,
        [TableName] NVARCHAR(100) NULL,
        [DriverID] INT NULL,
        [DriverName] NVARCHAR(150) NULL,
        [DeliveryFee] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [InvoiceJSON] NVARCHAR(MAX) NOT NULL,
        [TotalAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Notes] NVARCHAR(500) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_PendingInvoices] PRIMARY KEY ([PendingID])
    );
END
GO

-- -------------------------------------------------------------
-- 33. Table: [dbo].[Permissions]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Permissions]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Permissions] (
        [PermissionID] INT IDENTITY(1,1) NOT NULL,
        [RoleID] INT NOT NULL,
        [FormName] NVARCHAR(100) NOT NULL,
        [CanOpen] BIT NOT NULL DEFAULT 0,
        [CanAdd] BIT NOT NULL DEFAULT 0,
        [CanEdit] BIT NOT NULL DEFAULT 0,
        [CanDelete] BIT NOT NULL DEFAULT 0,
        CONSTRAINT [PK_Permissions] PRIMARY KEY ([PermissionID])
    );
END
GO

-- -------------------------------------------------------------
-- 34. Table: [dbo].[Printers]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Printers]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Printers] (
        [PrinterID] INT IDENTITY(1,1) NOT NULL,
        [PrinterName] NVARCHAR(200) NOT NULL,
        [TargetPrinter] NVARCHAR(500) NULL,
        [Note] NVARCHAR(MAX) NULL,
        [IsActive] BIT NULL DEFAULT 1,
        [IsDeleted] BIT NULL DEFAULT 0,
        [PrinterType] NVARCHAR(50) NULL,
        CONSTRAINT [PK_Printers] PRIMARY KEY ([PrinterID])
    );
END
GO

-- -------------------------------------------------------------
-- 35. Table: [dbo].[ProductAddons]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[ProductAddons]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[ProductAddons] (
        [ProductAddonID] INT IDENTITY(1,1) NOT NULL,
        [ProductID] INT NOT NULL,
        [AddonID] INT NOT NULL,
        [CostPrice] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [SalePrice] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [SortOrder] INT NULL,
        [IsDefault] BIT NULL,
        [AddonName] NVARCHAR(150) NULL,
        [Price] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CONSTRAINT [PK_ProductAddons] PRIMARY KEY ([ProductAddonID])
    );
END
GO

-- -------------------------------------------------------------
-- 36. Table: [dbo].[ProductSizes]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[ProductSizes]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[ProductSizes] (
        [ProductSizeID] INT IDENTITY(1,1) NOT NULL,
        [ProductID] INT NULL,
        [SizeID] INT NULL,
        [CostPrice] DECIMAL(18, 2) NULL DEFAULT 0.00,
        [SalePrice] DECIMAL(18, 2) NULL DEFAULT 0.00,
        [Barcode] NVARCHAR(100) NULL,
        [ImageBase64] NVARCHAR(MAX) NULL,
        [IsDefault] BIT NULL DEFAULT 0,
        [SortOrder] INT NULL DEFAULT 1,
        [IsActive] BIT NULL DEFAULT 1,
        [IsDeleted] BIT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NULL DEFAULT getdate(),
        CONSTRAINT [PK_ProductSizes] PRIMARY KEY ([ProductSizeID])
    );
END
GO

-- -------------------------------------------------------------
-- 37. Table: [dbo].[ProductUnits]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[ProductUnits]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[ProductUnits] (
        [ProductUnit_ID] INT IDENTITY(1,1) NOT NULL,
        [Product_ID] INT NULL,
        [Unit_Name] NVARCHAR(MAX) NULL,
        [Unit_Quantity] DECIMAL(18, 4) NULL,
        [Unit_Order] INT NULL,
        [Barcode] NVARCHAR(MAX) NULL,
        [Purchase_Price] DECIMAL(18, 2) NULL,
        [Sale_Price] DECIMAL(18, 2) NULL,
        [Notes] NVARCHAR(MAX) NULL,
        [BarcodeImage] NVARCHAR(MAX) NULL,
        [UnitID] INT NULL,
        [ProductID] INT NULL,
        [UnitName] NVARCHAR(100) NULL,
        [ConversionFactor] DECIMAL(18, 4) NOT NULL DEFAULT 1,
        [SalePrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [IsDefault] BIT NOT NULL DEFAULT 0,
        CONSTRAINT [PK_ProductUnits] PRIMARY KEY ([ProductUnit_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 38. Table: [dbo].[Products]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Products]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Products] (
        [Product_ID] INT IDENTITY(1,1) NOT NULL,
        [ProductCode] NVARCHAR(50) NULL,
        [ProductNameAr] NVARCHAR(250) NOT NULL,
        [ProductNameEn] NVARCHAR(250) NULL,
        [Image] NVARCHAR(MAX) NULL,
        [Description] NVARCHAR(250) NULL,
        [DiscountPercent] FLOAT NULL,
        [TaxPercent] FLOAT NULL,
        [IsActive] BIT NULL,
        [IsDeleted] BIT NULL DEFAULT 0,
        [PreparationTime] TIME NULL,
        [Notes] NVARCHAR(MAX) NULL,
        [Category_ID] INT NULL,
        [IsDiscountPercent] BIT NULL DEFAULT 1,
        [IsTaxPercent] BIT NULL DEFAULT 1,
        [ProductID] INT NULL,
        [CategoryID] INT NULL,
        [Barcode] NVARCHAR(100) NULL,
        [ProductName] NVARCHAR(200) NULL,
        [SalePrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [CostPrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Quantity] DECIMAL(18, 3) NOT NULL DEFAULT 0,
        [MinQuantity] DECIMAL(18, 3) NOT NULL DEFAULT 0,
        [Unit] NVARCHAR(50) NULL,
        [ImageBase64] NVARCHAR(MAX) NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [BasePrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Partner_ID] INT NULL,
        [IsDirect] BIT NULL DEFAULT 1,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Product_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 39. Table: [dbo].[PurchaseDetails]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[PurchaseDetails]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[PurchaseDetails] (
        [DetailID] INT IDENTITY(1,1) NOT NULL,
        [PurchaseID] INT NOT NULL,
        [MaterialID] INT NOT NULL,
        [UnitID] INT NOT NULL,
        [Quantity] DECIMAL(18, 4) NOT NULL,
        [ConversionFactor] DECIMAL(18, 4) NOT NULL DEFAULT 1.0000,
        [ActualBaseQuantity] DECIMAL(37, 8) NULL,
        [UnitPrice] DECIMAL(18, 4) NOT NULL,
        [BaseUnitCost] DECIMAL(18, 6) NOT NULL DEFAULT 0.000000,
        [TotalPrice] DECIMAL(37, 8) NULL,
        [ProductID] INT NULL,
        [Total] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CONSTRAINT [PK_PurchaseDetails] PRIMARY KEY ([DetailID])
    );
END
GO

-- -------------------------------------------------------------
-- 40. Table: [dbo].[PurchaseHeaders]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[PurchaseHeaders]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[PurchaseHeaders] (
        [PurchaseID] INT IDENTITY(1,1) NOT NULL,
        [InvoiceNumber] NVARCHAR(50) NOT NULL,
        [SupplierID] INT NOT NULL,
        [StoreID] INT NOT NULL,
        [PurchaseDate] DATETIME NOT NULL DEFAULT getdate(),
        [TotalAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [Discount] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [NetTotal] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [PaidAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [RemainingAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [PaymentType] NVARCHAR(20) NOT NULL DEFAULT 'CASH',
        [TreasuryID] INT NULL,
        [Notes] NVARCHAR(250) NULL,
        [UserID] INT NOT NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        CONSTRAINT [PK_PurchaseHeaders] PRIMARY KEY ([PurchaseID])
    );
END
GO

-- -------------------------------------------------------------
-- 41. Table: [dbo].[Purchase_Detalis]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Purchase_Detalis]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Purchase_Detalis] (
        [Detail_Purchase_ID] INT IDENTITY(1,1) NOT NULL,
        [Purchase_Id] INT NOT NULL,
        [Product_ID] INT NOT NULL,
        [ProductUnit_ID] INT NOT NULL,
        [Quantity_Sold] DECIMAL(18, 2) NOT NULL,
        [Purchase_Price_Per_Unit] DECIMAL(18, 2) NOT NULL,
        [Total_Line_Amount] DECIMAL(18, 2) NULL,
        [Product_Name] NVARCHAR(MAX) NULL,
        [ProductUnit_Name] NVARCHAR(MAX) NULL,
        CONSTRAINT [PK_Purchase_Detalis] PRIMARY KEY ([Detail_Purchase_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 42. Table: [dbo].[Purchase_Header]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Purchase_Header]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Purchase_Header] (
        [Purchase_Id] INT IDENTITY(1,1) NOT NULL,
        [Purchase_type] NVARCHAR(MAX) NULL,
        [Purchase_Date] DATETIME NULL,
        [Supplier_ID] INT NULL,
        [User_ID] INT NULL,
        [User_Name] NVARCHAR(MAX) NULL,
        [Net_Amount] DECIMAL(18, 2) NULL,
        [Discount_Value] DECIMAL(18, 2) NULL,
        [Total_Amount] DECIMAL(18, 2) NULL,
        [Amount_Paid] DECIMAL(18, 2) NULL,
        [Remaining] DECIMAL(18, 2) NULL,
        [Notes] NVARCHAR(MAX) NULL,
        [purchases_Image] NVARCHAR(MAX) NULL,
        [Payment_Method] NVARCHAR(50) NULL,
        CONSTRAINT [PK_Purchase_Header] PRIMARY KEY ([Purchase_Id])
    );
END
GO

-- -------------------------------------------------------------
-- 43. Table: [dbo].[Purchases]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Purchases]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Purchases] (
        [PurchaseID] INT IDENTITY(1,1) NOT NULL,
        [InvoiceNo] NVARCHAR(50) NULL,
        [PurchaseDate] DATETIME NOT NULL DEFAULT getdate(),
        [SupplierID] INT NULL,
        [UserID] INT NOT NULL,
        [Total] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Paid] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Remaining] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Notes] NVARCHAR(MAX) NULL,
        [TotalAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [NetTotal] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        CONSTRAINT [PK_Purchases] PRIMARY KEY ([PurchaseID])
    );
END
GO

-- -------------------------------------------------------------
-- 44. Table: [dbo].[RawMaterials]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[RawMaterials]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[RawMaterials] (
        [MaterialID] INT IDENTITY(1,1) NOT NULL,
        [MaterialBarcode] NVARCHAR(100) NULL,
        [MaterialName] NVARCHAR(150) NULL,
        [UnitID] INT NULL,
        [CostPrice] DECIMAL(18, 4) NULL DEFAULT 0.0000,
        [CreatedAt] DATETIME NULL DEFAULT getdate(),
        [IsActive] BIT NULL DEFAULT 1,
        [IsDeleted] BIT NULL,
        CONSTRAINT [PK_RawMaterials] PRIMARY KEY ([MaterialID])
    );
END
GO

-- -------------------------------------------------------------
-- 45. Table: [dbo].[Recipes]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Recipes]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Recipes] (
        [RecipeID] INT IDENTITY(1,1) NOT NULL,
        [ProductID] INT NOT NULL,
        [SizeID] INT NULL,
        [AddonID] INT NULL,
        [MaterialID] INT NULL,
        [Quantity] DECIMAL(18, 4) NULL,
        [Notes] NVARCHAR(150) NULL,
        [UnitID] INT NULL,
        CONSTRAINT [PK_Recipes] PRIMARY KEY ([RecipeID])
    );
END
GO

-- -------------------------------------------------------------
-- 46. Table: [dbo].[RestaurantSections]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[RestaurantSections]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[RestaurantSections] (
        [SectionID] INT IDENTITY(1,1) NOT NULL,
        [SectionCode] NVARCHAR(20) NULL,
        [SectionName] NVARCHAR(100) NOT NULL,
        [TablesCount] INT NOT NULL DEFAULT 0,
        [Notes] NVARCHAR(250) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_RestaurantSections] PRIMARY KEY ([SectionID])
    );
END
GO

-- -------------------------------------------------------------
-- 47. Table: [dbo].[RestaurantTables]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[RestaurantTables]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[RestaurantTables] (
        [TableID] INT IDENTITY(1,1) NOT NULL,
        [TableNumber] NVARCHAR(20) NOT NULL,
        [TableName] NVARCHAR(100) NULL,
        [SectionID] INT NOT NULL,
        [ChairsCount] INT NOT NULL DEFAULT 4,
        [TableStatus] TINYINT NOT NULL DEFAULT 1,
        [Notes] NVARCHAR(250) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [Capacity] INT NOT NULL DEFAULT 4,
        [Status] NVARCHAR(50) NOT NULL DEFAULT 'Available',
        CONSTRAINT [PK_RestaurantTables] PRIMARY KEY ([TableID])
    );
END
GO

-- -------------------------------------------------------------
-- 48. Table: [dbo].[Roles]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Roles]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Roles] (
        [RoleID] INT IDENTITY(1,1) NOT NULL,
        [RoleName] NVARCHAR(100) NOT NULL,
        [Description] NVARCHAR(250) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleID])
    );
END
GO

-- -------------------------------------------------------------
-- 49. Table: [dbo].[SalaryPayments]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[SalaryPayments]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SalaryPayments] (
        [PaymentID] INT IDENTITY(1,1) NOT NULL,
        [PaymentNumber] NVARCHAR(30) NOT NULL,
        [EmployeeID] INT NOT NULL,
        [TreasuryID] INT NOT NULL,
        [ShiftID] INT NULL,
        [PaymentDate] DATETIME NOT NULL DEFAULT getdate(),
        [SalaryMonth] INT NOT NULL,
        [SalaryYear] INT NOT NULL,
        [BasicSalary] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [Allowances] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [Deductions] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [Advances] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [NetSalary] DECIMAL(18, 2) NOT NULL,
        [Notes] NVARCHAR(250) NULL,
        [PaidByUserID] INT NOT NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_SalaryPayments] PRIMARY KEY ([PaymentID])
    );
END
GO

-- -------------------------------------------------------------
-- 50. Table: [dbo].[SalarySystems]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[SalarySystems]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SalarySystems] (
        [SalarySystemID] INT IDENTITY(1,1) NOT NULL,
        [SalarySystemCode] NVARCHAR(20) NULL,
        [SalarySystemName] NVARCHAR(100) NOT NULL,
        [PaymentDays] INT NULL,
        [Notes] NVARCHAR(500) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        [CreatedBy] INT NULL,
        CONSTRAINT [PK_SalarySystems] PRIMARY KEY ([SalarySystemID])
    );
END
GO

-- -------------------------------------------------------------
-- 51. Table: [dbo].[Sales]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Sales]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Sales] (
        [SaleID] INT IDENTITY(1,1) NOT NULL,
        [InvoiceNo] NVARCHAR(50) NULL,
        [SaleDate] DATETIME NOT NULL DEFAULT getdate(),
        [CustomerID] INT NULL,
        [UserID] INT NOT NULL,
        [ShiftID] INT NULL,
        [SubTotal] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Discount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Tax] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Total] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Paid] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Remaining] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [PaymentType] NVARCHAR(50) NOT NULL DEFAULT 'Cash',
        [Status] NVARCHAR(50) NOT NULL DEFAULT 'Completed',
        [Notes] NVARCHAR(MAX) NULL,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        CONSTRAINT [PK_Sales] PRIMARY KEY ([SaleID])
    );
END
GO

-- -------------------------------------------------------------
-- 52. Table: [dbo].[SalesDetails]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[SalesDetails]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SalesDetails] (
        [Detail_ID] INT IDENTITY(1,1) NOT NULL,
        [Invoice_ID] INT NULL,
        [Product_ID] INT NULL,
        [Product_Name] NVARCHAR(MAX) NULL,
        [ProductUnit_ID] INT NULL,
        [ProductUnit_Name] NVARCHAR(MAX) NULL,
        [Quantity_Sold] DECIMAL(18, 2) NULL,
        [Sale_Price_Per_Unit] DECIMAL(18, 2) NULL,
        [Total_Line_Amount] DECIMAL(18, 2) NULL,
        [Profit] DECIMAL(18, 2) NULL,
        [Purchase_Price_At_Sale] DECIMAL(18, 2) NULL,
        [DetailID] INT NULL,
        [SaleID] INT NULL,
        [ProductID] INT NULL,
        [Quantity] DECIMAL(18, 3) NOT NULL DEFAULT 1,
        [UnitPrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [CostPrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Discount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Total] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CONSTRAINT [PK_SalesDetails] PRIMARY KEY ([Detail_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 53. Table: [dbo].[SalesHeader]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[SalesHeader]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SalesHeader] (
        [Invoice_ID] INT IDENTITY(1,1) NOT NULL,
        [Invoice_Date] DATETIME NULL DEFAULT getdate(),
        [Customer_ID] INT NULL,
        [User_ID] INT NULL,
        [User_Name] NVARCHAR(MAX) NULL,
        [Net_Amount] DECIMAL(18, 2) NULL,
        [Discount_Value] DECIMAL(18, 2) NULL DEFAULT 0.00,
        [Total_Amount] DECIMAL(18, 2) NULL,
        [Payment_Method] NVARCHAR(MAX) NULL,
        [Amount_Paid] DECIMAL(18, 2) NULL,
        [Remaining] DECIMAL(18, 2) NULL,
        [Total_Profit] DECIMAL(18, 2) NULL,
        [Notes] NVARCHAR(MAX) NULL,
        [Invoice_type] NVARCHAR(50) NULL,
        [Invoice_Code] INT NULL,
        [TreasuryID] INT NULL,
        [PreviousBalance] DECIMAL(18, 2) NULL,
        CONSTRAINT [PK_SalesHeader] PRIMARY KEY ([Invoice_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 54. Table: [dbo].[SalesInvoiceDetails]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[SalesInvoiceDetails]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SalesInvoiceDetails] (
        [DetailID] INT IDENTITY(1,1) NOT NULL,
        [InvoiceID] INT NOT NULL,
        [ProductID] INT NOT NULL,
        [ProductName] NVARCHAR(250) NOT NULL,
        [SizeName] NVARCHAR(100) NULL,
        [AddonsText] NVARCHAR(500) NULL,
        [UnitPrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Quantity] INT NOT NULL DEFAULT 1,
        [TotalPrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Notes] NVARCHAR(250) NULL,
        [CostPrice] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Discount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CONSTRAINT [PK_SalesInvoiceDetails] PRIMARY KEY ([DetailID])
    );
END
GO

-- -------------------------------------------------------------
-- 55. Table: [dbo].[SalesInvoices]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[SalesInvoices]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SalesInvoices] (
        [InvoiceID] INT IDENTITY(1,1) NOT NULL,
        [InvoiceNumber] NVARCHAR(50) NOT NULL,
        [InvoiceDate] DATETIME NOT NULL DEFAULT getdate(),
        [OrderType] TINYINT NOT NULL DEFAULT 1,
        [ShiftID] INT NOT NULL,
        [UserID] INT NOT NULL,
        [CustomerID] INT NULL,
        [TableID] INT NULL,
        [DriverID] INT NULL,
        [DeliveryFee] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [TotalBeforeDiscount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [DiscountAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [NetTotal] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [PaidAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [RemainingAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [IsCredit] BIT NOT NULL DEFAULT 0,
        [TreasuryID] INT NULL,
        [Notes] NVARCHAR(500) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [BranchID] INT NULL,
        [StoreID] INT NULL,
        [SubTotal] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Discount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Tax] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [PaymentType] NVARCHAR(50) NOT NULL DEFAULT N'نقدي',
        CONSTRAINT [PK_SalesInvoices] PRIMARY KEY ([InvoiceID])
    );
END
GO

-- -------------------------------------------------------------
-- 56. Table: [dbo].[Settings]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Settings]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Settings] (
        [SettingKey] NVARCHAR(100) NOT NULL,
        [SettingValue] NVARCHAR(500) NULL,
        CONSTRAINT [PK_Settings] PRIMARY KEY ([SettingKey])
    );
END
GO

-- -------------------------------------------------------------
-- 57. Table: [dbo].[Shifts]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Shifts]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Shifts] (
        [ShiftID] INT IDENTITY(1,1) NOT NULL,
        [ShiftNumber] NVARCHAR(30) NOT NULL,
        [BranchID] INT NULL,
        [UserID] INT NOT NULL,
        [OpenDateTime] DATETIME2 NOT NULL DEFAULT getdate(),
        [CloseDateTime] DATETIME2 NULL,
        [OpeningCash] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [ClosingCash] DECIMAL(18, 2) NULL,
        [ExpectedCash] DECIMAL(18, 2) NULL,
        [CashDifference] DECIMAL(18, 2) NULL,
        [TotalSales] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [TotalVisaSales] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [TotalRefunds] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [TotalPurchases] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [TotalPurchaseRefunds] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [TotalExpenses] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [TotalIncomes] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [TotalOrders] INT NOT NULL DEFAULT 0,
        [Status] TINYINT NOT NULL DEFAULT 1,
        [Notes] NVARCHAR(500) NULL,
        [ClosedByUserID] INT NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [WorkShiftID] INT NULL,
        [StartTime] DATETIME NOT NULL DEFAULT getdate(),
        [EndTime] DATETIME NULL,
        [StartCash] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [EndCash] DECIMAL(18, 2) NULL,
        [ActualCash] DECIMAL(18, 2) NULL,
        [Difference] DECIMAL(18, 2) NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [TreasuryID] INT NULL,
        CONSTRAINT [PK_Shifts] PRIMARY KEY ([ShiftID])
    );
END
GO

-- -------------------------------------------------------------
-- 58. Table: [dbo].[Sizes]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Sizes]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Sizes] (
        [SizeID] INT IDENTITY(1,1) NOT NULL,
        [SizeCode] NVARCHAR(20) NULL,
        [SizeNameAr] NVARCHAR(100) NOT NULL,
        [SizeNameEn] NVARCHAR(100) NULL,
        [Notes] NVARCHAR(250) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_Sizes] PRIMARY KEY ([SizeID])
    );
END
GO

-- -------------------------------------------------------------
-- 59. Table: [dbo].[Stock]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Stock]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Stock] (
        [Stock_ID] INT IDENTITY(1,1) NOT NULL,
        [Product_ID] INT NOT NULL,
        [Quantity_OnHand] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Min_Quantity] DECIMAL(18, 2) NULL,
        [Max_Quantity] DECIMAL(18, 2) NULL,
        [Last_Update] DATETIME NULL DEFAULT getdate(),
        [Unit_Name] NVARCHAR(50) NULL,
        [Barcode] NVARCHAR(100) NULL,
        [Purchase_Price] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Sale_Price] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [Notes] NVARCHAR(MAX) NULL,
        CONSTRAINT [PK_Stock] PRIMARY KEY ([Stock_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 60. Table: [dbo].[StockMovements]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[StockMovements]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[StockMovements] (
        [MovementID] INT IDENTITY(1,1) NOT NULL,
        [StoreID] INT NOT NULL,
        [MaterialID] INT NOT NULL,
        [MovementType] NVARCHAR(50) NOT NULL,
        [Quantity] DECIMAL(18, 3) NOT NULL,
        [ReferenceID] INT NULL,
        [CreatedDate] DATETIME NULL DEFAULT getdate(),
        CONSTRAINT [PK_StockMovements] PRIMARY KEY ([MovementID])
    );
END
GO

-- -------------------------------------------------------------
-- 61. Table: [dbo].[StockTransactions]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[StockTransactions]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[StockTransactions] (
        [Transaction_ID] INT IDENTITY(1,1) NOT NULL,
        [Product_ID] INT NOT NULL,
        [ProductUnit_ID] INT NOT NULL,
        [Quantity] NUMERIC(18, 0) NOT NULL,
        [Base_Quantity] NVARCHAR(MAX) NULL DEFAULT getdate(),
        [Transaction_Type] NVARCHAR(MAX) NULL,
        [Transaction_Date] DATE NULL,
        [Reference_No] INT NULL,
        [Notes] NVARCHAR(MAX) NULL,
        CONSTRAINT [PK_StockTransactions] PRIMARY KEY ([Transaction_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 62. Table: [dbo].[StoreStock]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[StoreStock]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[StoreStock] (
        [StockID] INT IDENTITY(1,1) NOT NULL,
        [StoreID] INT NOT NULL,
        [MaterialID] INT NOT NULL,
        [CurrentStock] DECIMAL(18, 3) NULL DEFAULT 0.000,
        [MinStock] DECIMAL(18, 6) NULL DEFAULT 0,
        [MaxStock] DECIMAL(18, 6) NULL,
        [MinUnitID] INT NULL,
        [MaxUnitID] INT NULL,
        CONSTRAINT [PK_StoreStock] PRIMARY KEY ([StockID])
    );
END
GO

-- -------------------------------------------------------------
-- 63. Table: [dbo].[Stores]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Stores]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Stores] (
        [StoreID] INT IDENTITY(1,1) NOT NULL,
        [StoreName] NVARCHAR(250) NOT NULL,
        [IsDefault] BIT NULL DEFAULT 0,
        [IsActive] BIT NULL DEFAULT 1,
        [IsDeleted] BIT NULL DEFAULT 0,
        [StoreCode] NVARCHAR(50) NULL,
        CONSTRAINT [PK_Stores] PRIMARY KEY ([StoreID])
    );
END
GO

-- -------------------------------------------------------------
-- 64. Table: [dbo].[SupplierTransactions]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[SupplierTransactions]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SupplierTransactions] (
        [TransactionID] INT IDENTITY(1,1) NOT NULL,
        [SupplierID] INT NOT NULL,
        [TransactionType] NVARCHAR(50) NOT NULL,
        [ReferenceNo] NVARCHAR(50) NULL,
        [Debit] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [Credit] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [BalanceBefore] DECIMAL(18, 2) NULL,
        [BalanceAfter] DECIMAL(18, 2) NOT NULL,
        [TransactionDate] DATETIME NOT NULL DEFAULT getdate(),
        [TreasuryID] INT NULL,
        [Notes] NVARCHAR(250) NULL,
        [UserID] INT NOT NULL,
        [SuppliersID] INT NULL,
        [Amount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CONSTRAINT [PK_SupplierTransactions] PRIMARY KEY ([TransactionID])
    );
END
GO

-- -------------------------------------------------------------
-- 65. Table: [dbo].[Suppliers]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Suppliers]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Suppliers] (
        [SupplierID] INT IDENTITY(1,1) NOT NULL,
        [SupplierCode] NVARCHAR(30) NOT NULL,
        [SupplierName] NVARCHAR(150) NOT NULL,
        [Phone] NVARCHAR(30) NULL,
        [Address] NVARCHAR(250) NULL,
        [CurrentBalance] DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
        [Notes] NVARCHAR(250) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [Balance] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [SuppliersID] INT NULL,
        [SuppliersCode] NVARCHAR(50) NULL,
        [SuppliersName] NVARCHAR(150) NULL,
        [Companyname] NVARCHAR(150) NULL,
        CONSTRAINT [PK_Suppliers] PRIMARY KEY ([SupplierID])
    );
END
GO

-- -------------------------------------------------------------
-- 66. Table: [dbo].[TableReservations]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[TableReservations]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TableReservations] (
        [ReservationID] INT IDENTITY(1,1) NOT NULL,
        [ReservationNumber] NVARCHAR(50) NOT NULL,
        [TableID] INT NOT NULL,
        [TableName] NVARCHAR(100) NULL,
        [CustomerName] NVARCHAR(150) NOT NULL,
        [CustomerPhone] NVARCHAR(50) NOT NULL,
        [GuestCount] INT NOT NULL DEFAULT 2,
        [ReservationDateTime] DATETIME NOT NULL,
        [DepositAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [TreasuryID] INT NULL,
        [Status] TINYINT NOT NULL DEFAULT 1,
        [Notes] NVARCHAR(500) NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [CreatedByUserID] INT NOT NULL DEFAULT 1,
        CONSTRAINT [PK_TableReservations] PRIMARY KEY ([ReservationID])
    );
END
GO

-- -------------------------------------------------------------
-- 67. Table: [dbo].[TheScale]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[TheScale]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TheScale] (
        [ID] INT IDENTITY(1,1) NOT NULL,
        [Code] NVARCHAR(MAX) NULL,
        [Name] NVARCHAR(MAX) NULL,
        [Price] DECIMAL(18, 2) NULL,
        [Purchase_Price] DECIMAL(18, 2) NULL,
        CONSTRAINT [PK_TheScale] PRIMARY KEY ([ID])
    );
END
GO

-- -------------------------------------------------------------
-- 68. Table: [dbo].[Tratde_Type_TBL]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Tratde_Type_TBL]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Tratde_Type_TBL] (
        [Trd_ID] NUMERIC(18, 0) NOT NULL,
        [Trd_Code] NUMERIC(18, 0) NULL,
        [Trd_Type] VARBINARY(50) NULL,
        [Trd_State] BIT NULL,
        [Trd_Note] VARCHAR(MAX) NULL,
        CONSTRAINT [PK_Tratde_Type_TBL] PRIMARY KEY ([Trd_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 69. Table: [dbo].[Treasury]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Treasury]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Treasury] (
        [TreasuryID] INT IDENTITY(1,1) NOT NULL,
        [TreasuryCode] NVARCHAR(20) NOT NULL,
        [TreasuryNameAr] NVARCHAR(100) NOT NULL,
        [Description] NVARCHAR(500) NULL,
        [OpeningBalance] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [CurrentBalance] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        [IsDefault] BIT NOT NULL DEFAULT 0,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [CreatedDate] DATETIME NOT NULL DEFAULT getdate(),
        [ModifiedDate] DATETIME NULL,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [TreasuryName] NVARCHAR(100) NULL,
        [Balance] DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CONSTRAINT [PK_Treasury] PRIMARY KEY ([TreasuryID])
    );
END
GO

-- -------------------------------------------------------------
-- 70. Table: [dbo].[TreasuryTransactions]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[TreasuryTransactions]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TreasuryTransactions] (
        [TransactionID] INT IDENTITY(1,1) NOT NULL,
        [TreasuryID] INT NOT NULL,
        [TransactionDate] DATETIME NOT NULL DEFAULT getdate(),
        [TransactionType] INT NOT NULL,
        [ReferenceID] INT NULL,
        [ReferenceNo] NVARCHAR(50) NULL,
        [Amount] DECIMAL(18, 2) NOT NULL,
        [IsDeposit] BIT NOT NULL,
        [Notes] NVARCHAR(500) NULL,
        [UserID] INT NULL,
        [CreatedDate] DATETIME NOT NULL DEFAULT getdate(),
        [ShiftID] INT NULL,
        [RelatedID] INT NULL,
        CONSTRAINT [PK_TreasuryTransactions] PRIMARY KEY ([TransactionID])
    );
END
GO

-- -------------------------------------------------------------
-- 71. Table: [dbo].[Units]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Units]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Units] (
        [UnitID] INT IDENTITY(1,1) NOT NULL,
        [UnitCode] NVARCHAR(50) NULL,
        [UnitName] NVARCHAR(50) NOT NULL,
        [IsActive] BIT NULL DEFAULT 1,
        [IsDeleted] BIT NULL DEFAULT 0,
        CONSTRAINT [PK_Units] PRIMARY KEY ([UnitID])
    );
END
GO

-- -------------------------------------------------------------
-- 72. Table: [dbo].[Users]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Users]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Users] (
        [UserID] INT IDENTITY(1,1) NOT NULL,
        [Username] NVARCHAR(100) NOT NULL,
        [Password] NVARCHAR(250) NOT NULL,
        [FullName] NVARCHAR(150) NULL,
        [RoleID] INT NULL,
        [UserRole] NVARCHAR(50) NULL,
        [Phone] NVARCHAR(50) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
    );
END
GO

-- -------------------------------------------------------------
-- 73. Table: [dbo].[Users_TBL]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[Users_TBL]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Users_TBL] (
        [User_ID] INT IDENTITY(1,1) NOT NULL,
        [User_Code] NVARCHAR(250) NULL,
        [User_Name] NVARCHAR(250) NULL,
        [User_username] NVARCHAR(250) NULL,
        [User_password] NVARCHAR(250) NULL,
        [User_Stats] BIT NULL,
        [User_Role] NVARCHAR(200) NULL,
        [User_Note] NVARCHAR(MAX) NULL,
        [RoleID] INT NULL,
        [UserBarcode] NVARCHAR(250) NULL,
        [UserPhotobase64] NVARCHAR(MAX) NULL,
        [IsActive] BIT NULL DEFAULT 1,
        [IsDeleted] BIT NULL DEFAULT 0,
        [EmployeeID] INT NULL,
        [User_photo_path] NVARCHAR(MAX) NULL,
        [User_Barcode_path] NVARCHAR(MAX) NULL,
        [CreatedAt] DATETIME NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_Users_TBL] PRIMARY KEY ([User_ID])
    );
END
GO

-- -------------------------------------------------------------
-- 74. Table: [dbo].[WorkShifts]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[WorkShifts]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[WorkShifts] (
        [WorkShiftID] INT IDENTITY(1,1) NOT NULL,
        [WorkShiftCode] NVARCHAR(20) NULL,
        [WorkShiftName] NVARCHAR(100) NOT NULL,
        [StartTime] TIME NOT NULL,
        [EndTime] TIME NOT NULL,
        [Notes] NVARCHAR(250) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [IsDeleted] BIT NOT NULL DEFAULT 0,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT getdate(),
        CONSTRAINT [PK_WorkShifts] PRIMARY KEY ([WorkShiftID])
    );
END
GO

-- -------------------------------------------------------------
-- 75. Table: [dbo].[_SyncLog]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[_SyncLog]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[_SyncLog] (
        [LogId] BIGINT IDENTITY(1,1) NOT NULL,
        [TableName] NVARCHAR(128) NOT NULL,
        [RowSyncId] UNIQUEIDENTIFIER NOT NULL,
        [Operation] CHAR(1) NOT NULL,
        [ChangedColumns] NVARCHAR(MAX) NULL,
        [RowDataJson] NVARCHAR(MAX) NULL,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        [IsSynced] BIT NOT NULL DEFAULT 0,
        [SyncedAt] DATETIME2 NULL,
        [ErrorMessage] NVARCHAR(MAX) NULL,
        [RetryCount] INT NOT NULL DEFAULT 0,
        CONSTRAINT [PK__SyncLog] PRIMARY KEY ([LogId])
    );
END
GO

-- -------------------------------------------------------------
-- 76. Table: [dbo].[_SyncState]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[_SyncState]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[_SyncState] (
        [TableName] NVARCHAR(128) NOT NULL,
        [LastPushAt] DATETIME2 NULL,
        [LastPullAt] DATETIME2 NULL,
        [LastPullVersion] BIGINT NOT NULL DEFAULT 0,
        [TotalPushed] BIGINT NOT NULL DEFAULT 0,
        [TotalPulled] BIGINT NOT NULL DEFAULT 0,
        [LastError] NVARCHAR(MAX) NULL,
        [LastErrorAt] DATETIME2 NULL,
        CONSTRAINT [PK__SyncState] PRIMARY KEY ([TableName])
    );
END
GO

-- -------------------------------------------------------------
-- 77. Table: [dbo].[_SyncConflicts]
-- -------------------------------------------------------------
IF OBJECT_ID('[dbo].[_SyncConflicts]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[_SyncConflicts] (
        [ConflictId] BIGINT IDENTITY(1,1) NOT NULL,
        [TableName] NVARCHAR(128) NOT NULL,
        [RowSyncId] UNIQUEIDENTIFIER NOT NULL,
        [LocalDataJson] NVARCHAR(MAX) NULL,
        [RemoteDataJson] NVARCHAR(MAX) NULL,
        [DetectedAt] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        [IsResolved] BIT NOT NULL DEFAULT 0,
        [Resolution] NVARCHAR(20) NULL,
        [ResolvedAt] DATETIME2 NULL,
        [ResolvedBy] INT NULL,
        CONSTRAINT [PK__SyncConflicts] PRIMARY KEY ([ConflictId])
    );
END
GO

-- =============================================================
-- ESSENTIAL SEED DATA
-- =============================================================
-- 1. Default Role
IF OBJECT_ID('[dbo].[Roles]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Roles])
BEGIN
    SET IDENTITY_INSERT [dbo].[Roles] ON;
    INSERT INTO [dbo].[Roles] (RoleID, RoleName, Description, IsActive)
    VALUES (1, N'المدير العام', N'صلاحيات كاملة على كافة أقسام وإعدادات النظام', 1),
           (2, N'كاشير', N'صلاحيات نقطة البيع والفواتير', 1);
    SET IDENTITY_INSERT [dbo].[Roles] OFF;
END
GO

-- 2. Default Admin in Users_TBL
IF OBJECT_ID('[dbo].[Users_TBL]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Users_TBL])
BEGIN
    INSERT INTO [dbo].[Users_TBL] (User_Code, User_Name, User_username, User_password, RoleID, IsActive, IsDeleted, CreatedAt)
    VALUES (N'ADM-001', N'المدير العام', N'admin', N'123', 1, 1, 0, GETDATE());
END
GO

-- 3. Default Legacy User in Users (Compatibility)
IF OBJECT_ID('[dbo].[Users]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Users])
BEGIN
    INSERT INTO [dbo].[Users] (Username, Password, FullName, RoleID, UserRole, IsActive, IsDeleted, CreatedAt)
    VALUES (N'admin', N'123', N'المدير العام', 1, N'Admin', 1, 0, GETDATE());
END
GO

-- 4. Default Units
IF OBJECT_ID('[dbo].[Units]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Units])
BEGIN
    SET IDENTITY_INSERT [dbo].[Units] ON;
    INSERT INTO [dbo].[Units] (UnitID, UnitName, IsActive, UnitCode, IsDeleted)
    VALUES (1, N'قطعة', 1, N'PCS', 0),
           (2, N'علبة', 1, N'BOX', 0),
           (3, N'كرتونة', 1, N'CTN', 0),
           (4, N'كيلو', 1, N'KG', 0);
    SET IDENTITY_INSERT [dbo].[Units] OFF;
END
GO

-- 5. Default Category Types
IF OBJECT_ID('[dbo].[CategoryTypes]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[CategoryTypes])
BEGIN
    SET IDENTITY_INSERT [dbo].[CategoryTypes] ON;
    INSERT INTO [dbo].[CategoryTypes] (CategoryTypeID, TypeName, DisplayOrder, IsActive, TypeCode, IsDeleted)
    VALUES (1, N'مأكولات ومشروبات', 1, 1, N'FB', 0),
           (2, N'خدمات', 2, 1, N'SRV', 0),
           (3, N'بضائع عامة', 3, 1, N'GEN', 0),
           (4, N'مطبخ وتجهيز', 4, 1, N'KIT', 0);
    SET IDENTITY_INSERT [dbo].[CategoryTypes] OFF;
END
GO

-- 6. Default Colors
IF OBJECT_ID('[dbo].[Colors]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Colors])
BEGIN
    SET IDENTITY_INSERT [dbo].[Colors] ON;
    INSERT INTO [dbo].[Colors] (ColorID, ColorName, ColorHex, IsActive, HexCode, IsDeleted)
    VALUES (1, N'أزرق رئيسي', N'#3B82F6', 1, N'#3B82F6', 0),
           (2, N'أخضر زمردي', N'#10B981', 1, N'#10B981', 0),
           (3, N'برتقالي كهرماني', N'#F59E0B', 1, N'#F59E0B', 0),
           (4, N'أحمر مرجاني', N'#EF4444', 1, N'#EF4444', 0),
           (5, N'بنفسجي هادئ', N'#8B5CF6', 1, N'#8B5CF6', 0);
    SET IDENTITY_INSERT [dbo].[Colors] OFF;
END
GO

-- 7. Default Treasury
IF OBJECT_ID('[dbo].[Treasury]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Treasury])
BEGIN
    SET IDENTITY_INSERT [dbo].[Treasury] ON;
    INSERT INTO [dbo].[Treasury] (TreasuryID, TreasuryName, Balance, IsActive, TreasuryCode, TreasuryNameAr, OpeningBalance, CurrentBalance, IsDeleted)
    VALUES (1, N'الخزينة الرئيسية', 0, 1, N'TRS-01', N'الخزينة الرئيسية', 0, 0, 0);
    SET IDENTITY_INSERT [dbo].[Treasury] OFF;
END
GO

-- 8. Default Main Cash (Legacy)
IF OBJECT_ID('[dbo].[Main_Cash_TBL]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Main_Cash_TBL])
BEGIN
    SET IDENTITY_INSERT [dbo].[Main_Cash_TBL] ON;
    INSERT INTO [dbo].[Main_Cash_TBL] (Cash_ID, Cash_Code, Cash_S_Date, Cash_S_Balance, Cash_Z_Balance, Cash_Balance, Cash_Stats)
    VALUES (1, N'CSH-01', GETDATE(), 0, 0, 0, N'Active');
    SET IDENTITY_INSERT [dbo].[Main_Cash_TBL] OFF;
END
GO

-- 9. Default Store / Warehouse
IF OBJECT_ID('[dbo].[Stores]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Stores])
BEGIN
    SET IDENTITY_INSERT [dbo].[Stores] ON;
    INSERT INTO [dbo].[Stores] (StoreID, StoreName, Location, IsActive, IsDefault)
    VALUES (1, N'المخزن الرئيسي', N'المقر الرئيسي', 1, 1);
    SET IDENTITY_INSERT [dbo].[Stores] OFF;
END
GO

-- 10. Default Branch
IF OBJECT_ID('[dbo].[Branches]', 'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Branches])
BEGIN
    SET IDENTITY_INSERT [dbo].[Branches] ON;
    INSERT INTO [dbo].[Branches] (BranchID, BranchCode, BranchName, Phone, Mobile, Address)
    VALUES (1, N'BR-01', N'الفرع الرئيسي', N'0245598368', N'01200000000', N'المقر الرئيسي');
    SET IDENTITY_INSERT [dbo].[Branches] OFF;
END
GO

-- 11. Default AppScreens
IF OBJECT_ID('[dbo].[AppScreens]', 'U') IS NOT NULL
BEGIN
    DECLARE @Screens TABLE (FormName NVARCHAR(100), Category NVARCHAR(100), ScreenDisplayName NVARCHAR(200));
    INSERT INTO @Screens (FormName, Category, ScreenDisplayName) VALUES
    ('frmPOS', N'المبيعات ونقاط البيع', N'شاشة الكاشير ونقاط البيع (POS)'),
    ('Sales_Returns', N'المبيعات ونقاط البيع', N'مرتجع المبيعات'),
    ('FrmSalesReport', N'المبيعات ونقاط البيع', N'تقرير المبيعات'),
    ('frmHeldInvoices', N'المبيعات ونقاط البيع', N'الفواتير المعلقة والمؤقتة'),
    ('Products', N'الأصناف والمخزون', N'الأصناف والمنتجات'),
    ('Categories', N'الأصناف والمخزون', N'الأقسام والتصنيفات'),
    ('frmProductSizes', N'الأصناف والمخزون', N'أحجام ومقاسات المنتجات'),
    ('frmProductAddons', N'الأصناف والمخزون', N'إضافات ومكونات المنتجات'),
    ('frmUnits', N'الأصناف والمخزون', N'وحدات القياس'),
    ('FrmStores', N'الأصناف والمخزون', N'المخازن والمستودعات'),
    ('frmStoreStock', N'الأصناف والمخزون', N'رصيد وجرد المخازن'),
    ('frmRawMaterials', N'الأصناف والمخزون', N'المواد الخام'),
    ('frmRecipes', N'الأصناف والمخزون', N'مكونات وتكاليف الوجبات'),
    ('FrmKitchenWaste', N'الأصناف والمخزون', N'إدارة الهالك والتالف'),
    ('FrmKitchenDisplay', N'الأصناف والمخزون', N'شاشة المطبخ (KDS)'),
    ('Purchases', N'المشتريات والموردين', N'فواتير المشتريات'),
    ('Purchase_Return', N'المشتريات والموردين', N'مرتجع المشتريات'),
    ('FrmSuppliers', N'المشتريات والموردين', N'إدارة الموردين'),
    ('FrmSupplierTransactions', N'المشتريات والموردين', N'حركات ومدفوعات الموردين'),
    ('frmPurchaseReports', N'المشتريات والموردين', N'تقارير المشتريات'),
    ('FrmCustomers', N'العملاء والتوصيل', N'إدارة العملاء'),
    ('FrmCustomerStatement', N'العملاء والتوصيل', N'كشف حساب عميل'),
    ('frmDeliveryDrivers', N'العملاء والتوصيل', N'مناديب وسائقي التوصيل'),
    ('frmDeliveryAreas', N'العملاء والتوصيل', N'مناطق ورسوم التوصيل'),
    ('FrmDriverReport', N'العملاء والتوصيل', N'تقرير التوصيل والمناديب'),
    ('frmRestaurantTables', N'الصالة والطاولات', N'طاولات الصالة'),
    ('frmRestaurantSections', N'الصالة والطاولات', N'أقسام الصالة'),
    ('FrmTableReservations', N'الصالة والطاولات', N'حجز الطاولات'),
    ('frmTreasury', N'الخزينة والمصروفات', N'إدارة الخزائن ونقاط النقدية'),
    ('FrmTreasuryTransaction', N'الخزينة والمصروفات', N'حركات الإيداع والصرف'),
    ('FrmTreasuryTransfer', N'الخزينة والمصروفات', N'تحويل بين الخزائن'),
    ('FrmTreasuryTransactionsReport', N'الخزينة والمصروفات', N'تقرير حركات الخزينة'),
    ('form_Expenses', N'الخزينة والمصروفات', N'تسجيل المصروفات'),
    ('ExpensesReportForm', N'الخزينة والمصروفات', N'تقرير المصروفات'),
    ('frmShifts', N'الخزينة والمصروفات', N'الورديات والشفتات'),
    ('frmWorkShifts', N'الخزينة والمصروفات', N'أنواع وتوقيتات الورديات'),
    ('frmUsers', N'الموظفين والمستخدمين والصلاحيات', N'المستخدمين وحسابات الدخول'),
    ('frmRolesAndPermissions', N'الموظفين والمستخدمين والصلاحيات', N'الأدوار والصلاحيات'),
    ('frmEmployees', N'الموظفين والمستخدمين والصلاحيات', N'إدارة الموظفين'),
    ('frmJobTitles', N'الموظفين والمستخدمين والصلاحيات', N'المسميات الوظيفية'),
    ('frmDepartments', N'الموظفين والمستخدمين والصلاحيات', N'الأقسام الإدارية'),
    ('frmSalarySystems', N'الموظفين والمستخدمين والصلاحيات', N'أنظمة الرواتب'),
    ('frmSalaryPayment', N'الموظفين والمستخدمين والصلاحيات', N'صرف الرواتب'),
    ('Settings', N'الإعدادات والنظام', N'إعدادات النظام العامة'),
    ('Backup', N'الإعدادات والنظام', N'النسخ الاحتياطي واستعادة البيانات'),
    ('frmColors', N'الإعدادات والنظام', N'ألوان التصنيفات'),
    ('frmPrinters', N'الإعدادات والنظام', N'إعدادات الطابعات'),
    ('frmBranches', N'الإعدادات والنظام', N'الفروع'),
    ('Reports', N'الإعدادات والنظام', N'التقارير الشاملة');

    INSERT INTO AppScreens (FormName, Category, ScreenDisplayName)
    SELECT S.FormName, S.Category, S.ScreenDisplayName
    FROM @Screens S
    WHERE NOT EXISTS (SELECT 1 FROM AppScreens A WHERE A.FormName = S.FormName);
END
GO

-- 12. Default Admin Permissions
IF OBJECT_ID('[dbo].[Permissions]', 'U') IS NOT NULL AND OBJECT_ID('[dbo].[AppScreens]', 'U') IS NOT NULL
BEGIN
    INSERT INTO Permissions (RoleID, FormName, CanOpen, CanAdd, CanEdit, CanDelete)
    SELECT 1, S.FormName, 1, 1, 1, 1
    FROM AppScreens S
    WHERE NOT EXISTS (SELECT 1 FROM Permissions P WHERE P.RoleID = 1 AND P.FormName = S.FormName);
END
GO

-- 13. Default AppSettings
IF OBJECT_ID('[dbo].[AppSettings]', 'U') IS NOT NULL
BEGIN
    DECLARE @Defs TABLE (K NVARCHAR(100), V NVARCHAR(MAX));
    INSERT INTO @Defs (K, V) VALUES
    ('AppTheme', 'Dark'),
    ('autoSaveinvoice', 'True'),
    ('AutoUpdate_Enabled', 'true'),
    ('BusinessType', N'كافيه ومطعم'),
    ('Currency', N'ج.م'),
    ('CurrencyName', N'جنيه مصري - ج.م'),
    ('CurrentBranchID', '1'),
    ('CurrentStoreID', '1'),
    ('defaultTreasuryid', '1'),
    ('EnableDiscount', 'true'),
    ('EnableTax', 'true'),
    ('TaxPercentage', '14'),
    ('ServiceFeePercentage', '12'),
    ('IsFirstRunCompleted', '1');

    INSERT INTO AppSettings (SettingKey, SettingValue)
    SELECT D.K, D.V FROM @Defs D
    WHERE NOT EXISTS (SELECT 1 FROM AppSettings A WHERE A.SettingKey = D.K);
END
GO
