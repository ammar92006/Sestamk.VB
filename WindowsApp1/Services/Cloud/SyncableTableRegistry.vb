Imports System.Collections.Generic
Imports System.Linq

Namespace Services.Cloud

    ''' <summary>
    ''' سجل الجداول القابلة للمزامنة (Registry of syncable tables)
    ''' </summary>
    Public Module SyncableTableRegistry

        Public Class SyncableTable
            Public Property TableName As String
            Public Property DisplayNameAr As String
            Public Property PrimaryKeyColumn As String   ' e.g. "AddonID"
            Public Property SyncIdColumn As String = "sync_id" ' always "sync_id"
            Public Property Direction As Integer         ' from SyncModels.vb (SyncDirection)
            Public Property ConflictStrategy As Integer  ' from SyncModels.vb (ConflictStrategy)
            Public Property Priority As Integer          ' lower = sync first (master data before transactions)
            Public Property DependsOn As String() = Array.Empty(Of String)() ' tables that must sync before this one
            Public Property ExcludeColumns As String() = Array.Empty(Of String)() ' columns to skip during sync (e.g., local-only)
        End Class

        Private _tables As List(Of SyncableTable)

        ''' <summary>
        ''' الحصول على جميع الجداول القابلة للمزامنة (Get all syncable tables)
        ''' </summary>
        Public Function GetSyncableTables() As List(Of SyncableTable)
            If _tables IsNot Nothing Then Return _tables

            _tables = New List(Of SyncableTable)

            ' Priority 1 - Master/Reference Data (sync first)
            _tables.Add(New SyncableTable With {.TableName = "Units", .DisplayNameAr = "الوحدات", .PrimaryKeyColumn = "UnitID", .Priority = 1})
            _tables.Add(New SyncableTable With {.TableName = "Colors", .DisplayNameAr = "الألوان", .PrimaryKeyColumn = "ColorID", .Priority = 1})
            _tables.Add(New SyncableTable With {.TableName = "CategoryTypes", .DisplayNameAr = "أنواع التصنيفات", .PrimaryKeyColumn = "CategoryTypeID", .Priority = 1})
            _tables.Add(New SyncableTable With {.TableName = "Categories", .DisplayNameAr = "التصنيفات", .PrimaryKeyColumn = "Category_ID", .Priority = 1, .DependsOn = {"CategoryTypes"}})
            _tables.Add(New SyncableTable With {.TableName = "JobTitles", .DisplayNameAr = "المسميات الوظيفية", .PrimaryKeyColumn = "JobTitleID", .Priority = 1})
            _tables.Add(New SyncableTable With {.TableName = "SalarySystems", .DisplayNameAr = "أنظمة الرواتب", .PrimaryKeyColumn = "SalarySystemID", .Priority = 1})
            _tables.Add(New SyncableTable With {.TableName = "Roles", .DisplayNameAr = "الأدوار", .PrimaryKeyColumn = "RoleID", .Priority = 1})
            _tables.Add(New SyncableTable With {.TableName = "DeliveryAreas", .DisplayNameAr = "مناطق التوصيل", .PrimaryKeyColumn = "AreaID", .Priority = 1})

            ' Priority 2 - Core Business Data
            _tables.Add(New SyncableTable With {.TableName = "Branches", .DisplayNameAr = "الفروع", .PrimaryKeyColumn = "BranchID", .Priority = 2})
            _tables.Add(New SyncableTable With {.TableName = "Departments", .DisplayNameAr = "الأقسام", .PrimaryKeyColumn = "DepartmentID", .Priority = 2, .DependsOn = {"Branches"}})
            _tables.Add(New SyncableTable With {.TableName = "Stores", .DisplayNameAr = "المستودعات", .PrimaryKeyColumn = "StoreID", .Priority = 2, .DependsOn = {"Branches"}})
            _tables.Add(New SyncableTable With {.TableName = "Users", .DisplayNameAr = "المستخدمين", .PrimaryKeyColumn = "UserID", .Priority = 2, .DependsOn = {"Roles"}})
            _tables.Add(New SyncableTable With {.TableName = "Permissions", .DisplayNameAr = "الصلاحيات", .PrimaryKeyColumn = "PermissionID", .Priority = 2, .DependsOn = {"Roles"}})
            _tables.Add(New SyncableTable With {.TableName = "Employees", .DisplayNameAr = "الموظفين", .PrimaryKeyColumn = "EmployeeID", .Priority = 2, .DependsOn = {"Branches", "JobTitles", "SalarySystems"}})
            _tables.Add(New SyncableTable With {.TableName = "Customers", .DisplayNameAr = "العملاء", .PrimaryKeyColumn = "CustomerID", .Priority = 2})
            _tables.Add(New SyncableTable With {.TableName = "Suppliers", .DisplayNameAr = "الموردين", .PrimaryKeyColumn = "SupplierID", .Priority = 2})
            _tables.Add(New SyncableTable With {.TableName = "Products", .DisplayNameAr = "المنتجات", .PrimaryKeyColumn = "Product_ID", .Priority = 2, .DependsOn = {"Categories", "Units"}})
            _tables.Add(New SyncableTable With {.TableName = "Addons", .DisplayNameAr = "الإضافات", .PrimaryKeyColumn = "AddonID", .Priority = 2})
            _tables.Add(New SyncableTable With {.TableName = "ProductAddons", .DisplayNameAr = "إضافات المنتجات", .PrimaryKeyColumn = "ProductAddonID", .Priority = 2, .DependsOn = {"Products", "Addons"}})
            _tables.Add(New SyncableTable With {.TableName = "ProductUnits", .DisplayNameAr = "وحدات المنتجات", .PrimaryKeyColumn = "ProductUnitID", .Priority = 2, .DependsOn = {"Products", "Units"}})
            _tables.Add(New SyncableTable With {.TableName = "Sizes", .DisplayNameAr = "الأحجام", .PrimaryKeyColumn = "SizeID", .Priority = 2})
            _tables.Add(New SyncableTable With {.TableName = "ProductSizes", .DisplayNameAr = "أحجام المنتجات", .PrimaryKeyColumn = "ProductSizeID", .Priority = 2, .DependsOn = {"Products", "Sizes"}})
            _tables.Add(New SyncableTable With {.TableName = "RawMaterials", .DisplayNameAr = "المواد الخام", .PrimaryKeyColumn = "MaterialID", .Priority = 2, .DependsOn = {"Units"}})
            _tables.Add(New SyncableTable With {.TableName = "MaterialUnits", .DisplayNameAr = "وحدات المواد", .PrimaryKeyColumn = "MaterialUnitID", .Priority = 2, .DependsOn = {"RawMaterials", "Units"}})
            _tables.Add(New SyncableTable With {.TableName = "Recipes", .DisplayNameAr = "الوصفات", .PrimaryKeyColumn = "RecipeID", .Priority = 2, .DependsOn = {"Products", "RawMaterials"}})
            _tables.Add(New SyncableTable With {.TableName = "RestaurantSections", .DisplayNameAr = "أقسام المطعم", .PrimaryKeyColumn = "SectionID", .Priority = 2, .DependsOn = {"Branches"}})
            _tables.Add(New SyncableTable With {.TableName = "RestaurantTables", .DisplayNameAr = "طاولات المطعم", .PrimaryKeyColumn = "TableID", .Priority = 2, .DependsOn = {"RestaurantSections"}})
            _tables.Add(New SyncableTable With {.TableName = "DeliveryDrivers", .DisplayNameAr = "السائقين", .PrimaryKeyColumn = "DriverID", .Priority = 2, .DependsOn = {"DeliveryAreas"}})
            _tables.Add(New SyncableTable With {.TableName = "Treasury", .DisplayNameAr = "الخزينة", .PrimaryKeyColumn = "TreasuryID", .Priority = 2, .DependsOn = {"Branches"}})
            _tables.Add(New SyncableTable With {.TableName = "Partners", .DisplayNameAr = "الشركاء", .PrimaryKeyColumn = "PartnerID", .Priority = 2})
            _tables.Add(New SyncableTable With {.TableName = "KitchenComments", .DisplayNameAr = "ملاحظات المطبخ", .PrimaryKeyColumn = "CommentID", .Priority = 2})

            ' Priority 3 - Transactional Data
            _tables.Add(New SyncableTable With {.TableName = "Shifts", .DisplayNameAr = "الورديات", .PrimaryKeyColumn = "ShiftID", .Priority = 3, .DependsOn = {"Users"}})
            _tables.Add(New SyncableTable With {.TableName = "WorkShifts", .DisplayNameAr = "فترات العمل", .PrimaryKeyColumn = "WorkShiftID", .Priority = 3, .DependsOn = {"Users"}})
            _tables.Add(New SyncableTable With {.TableName = "SalesHeader", .DisplayNameAr = "رأس المبيعات", .PrimaryKeyColumn = "SaleHeaderID", .Priority = 3, .DependsOn = {"Users", "Customers", "Branches"}})
            _tables.Add(New SyncableTable With {.TableName = "SalesDetails", .DisplayNameAr = "تفاصيل المبيعات", .PrimaryKeyColumn = "SaleDetailID", .Priority = 3, .DependsOn = {"SalesHeader", "Products"}})
            _tables.Add(New SyncableTable With {.TableName = "SalesInvoices", .DisplayNameAr = "فواتير المبيعات", .PrimaryKeyColumn = "InvoiceID", .Priority = 3, .DependsOn = {"Users", "Customers"}})
            _tables.Add(New SyncableTable With {.TableName = "SalesInvoiceDetails", .DisplayNameAr = "تفاصيل فواتير المبيعات", .PrimaryKeyColumn = "InvoiceDetailID", .Priority = 3, .DependsOn = {"SalesInvoices", "Products"}})
            _tables.Add(New SyncableTable With {.TableName = "Sales", .DisplayNameAr = "المبيعات", .PrimaryKeyColumn = "SaleID", .Priority = 3, .DependsOn = {"Users", "Customers"}})
            _tables.Add(New SyncableTable With {.TableName = "PurchaseHeaders", .DisplayNameAr = "رأس المشتريات", .PrimaryKeyColumn = "PurchaseID", .Priority = 3, .DependsOn = {"Suppliers", "Users"}})
            _tables.Add(New SyncableTable With {.TableName = "PurchaseDetails", .DisplayNameAr = "تفاصيل المشتريات", .PrimaryKeyColumn = "DetailID", .Priority = 3, .DependsOn = {"PurchaseHeaders", "RawMaterials", "Units"}})
            _tables.Add(New SyncableTable With {.TableName = "Purchases", .DisplayNameAr = "المشتريات", .PrimaryKeyColumn = "PurchaseID", .Priority = 3, .DependsOn = {"Suppliers"}})
            _tables.Add(New SyncableTable With {.TableName = "PendingInvoices", .DisplayNameAr = "الفواتير المعلقة", .PrimaryKeyColumn = "PendingInvoiceID", .Priority = 3, .DependsOn = {"Users", "Customers"}})
            _tables.Add(New SyncableTable With {.TableName = "CustomerTransactions", .DisplayNameAr = "حركات العملاء", .PrimaryKeyColumn = "TransactionID", .Priority = 3, .DependsOn = {"Customers"}, .ConflictStrategy = 1}) ' 1 = ManualReview (Assuming enum value)
            _tables.Add(New SyncableTable With {.TableName = "CustomerBalanceLog", .DisplayNameAr = "سجل أرصدة العملاء", .PrimaryKeyColumn = "LogID", .Priority = 3, .DependsOn = {"Customers"}})
            _tables.Add(New SyncableTable With {.TableName = "SupplierTransactions", .DisplayNameAr = "حركات الموردين", .PrimaryKeyColumn = "TransactionID", .Priority = 3, .DependsOn = {"Suppliers"}, .ConflictStrategy = 1})
            _tables.Add(New SyncableTable With {.TableName = "TreasuryTransactions", .DisplayNameAr = "حركات الخزينة", .PrimaryKeyColumn = "TransactionID", .Priority = 3, .DependsOn = {"Treasury"}, .ConflictStrategy = 1})
            _tables.Add(New SyncableTable With {.TableName = "Expenses", .DisplayNameAr = "المصروفات", .PrimaryKeyColumn = "ExpenseID", .Priority = 3, .DependsOn = {"Treasury"}, .ConflictStrategy = 1})
            _tables.Add(New SyncableTable With {.TableName = "SalaryPayments", .DisplayNameAr = "مدفوعات الرواتب", .PrimaryKeyColumn = "PaymentID", .Priority = 3, .DependsOn = {"Employees"}, .ConflictStrategy = 1})
            _tables.Add(New SyncableTable With {.TableName = "Stock", .DisplayNameAr = "المخزون", .PrimaryKeyColumn = "StockID", .Priority = 3, .DependsOn = {"Products", "Stores"}})
            _tables.Add(New SyncableTable With {.TableName = "StoreStock", .DisplayNameAr = "مخزون المستودعات", .PrimaryKeyColumn = "StoreStockID", .Priority = 3, .DependsOn = {"Stores", "Products"}})
            _tables.Add(New SyncableTable With {.TableName = "StockMovements", .DisplayNameAr = "حركات المخزون", .PrimaryKeyColumn = "MovementID", .Priority = 3, .DependsOn = {"Products", "Stores"}})
            _tables.Add(New SyncableTable With {.TableName = "StockTransactions", .DisplayNameAr = "معاملات المخزون", .PrimaryKeyColumn = "StockTransactionID", .Priority = 3, .DependsOn = {"Products"}})
            _tables.Add(New SyncableTable With {.TableName = "DriverTransactions", .DisplayNameAr = "حركات السائقين", .PrimaryKeyColumn = "DriverTransactionID", .Priority = 3, .DependsOn = {"DeliveryDrivers"}})
            _tables.Add(New SyncableTable With {.TableName = "KitchenOrders", .DisplayNameAr = "طلبات المطبخ", .PrimaryKeyColumn = "KitchenOrderID", .Priority = 3, .DependsOn = {"Products"}})
            _tables.Add(New SyncableTable With {.TableName = "KitchenOrderDetails", .DisplayNameAr = "تفاصيل طلبات المطبخ", .PrimaryKeyColumn = "KitchenOrderDetailID", .Priority = 3, .DependsOn = {"KitchenOrders", "Products"}})
            _tables.Add(New SyncableTable With {.TableName = "KitchenWaste", .DisplayNameAr = "هالك المطبخ", .PrimaryKeyColumn = "WasteID", .Priority = 3, .DependsOn = {"Products"}})
            _tables.Add(New SyncableTable With {.TableName = "KitchenWasteDetails", .DisplayNameAr = "تفاصيل هالك المطبخ", .PrimaryKeyColumn = "WasteDetailID", .Priority = 3, .DependsOn = {"KitchenWaste", "RawMaterials"}})
            _tables.Add(New SyncableTable With {.TableName = "TableReservations", .DisplayNameAr = "حجوزات الطاولات", .PrimaryKeyColumn = "ReservationID", .Priority = 3, .DependsOn = {"RestaurantTables", "Customers"}})

            ' تعيين القيم الافتراضية
            For Each tbl In _tables
                If tbl.Direction = 0 Then tbl.Direction = 1 ' TwoWay
                ' If ConflictStrategy is 0, it means ServerWins
            Next

            Return _tables
        End Function

        ''' <summary>
        ''' الحصول على جدول بالاسم (Get table by name)
        ''' </summary>
        Public Function GetTable(tableName As String) As SyncableTable
            Return GetSyncableTables().FirstOrDefault(Function(t) t.TableName.Equals(tableName, StringComparison.OrdinalIgnoreCase))
        End Function

        ''' <summary>
        ''' التحقق مما إذا كان الجدول قابلاً للمزامنة (Check if table is syncable)
        ''' </summary>
        Public Function IsSyncable(tableName As String) As Boolean
            Return GetTable(tableName) IsNot Nothing
        End Function

        ''' <summary>
        ''' الحصول على الجداول بترتيب المزامنة (Get tables in sync order - Topological Sort)
        ''' </summary>
        Public Function GetTablesInSyncOrder() As List(Of SyncableTable)
            Dim allTables = GetSyncableTables()
            Dim result As New List(Of SyncableTable)
            Dim visited As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

            ' الفرز حسب الأولوية أولاً (Sort by priority first)
            For Each priority In {1, 2, 3}
                Dim priorityTables = allTables.Where(Function(t) t.Priority = priority).ToList()
                
                For Each tbl In priorityTables
                    Visit(tbl, allTables, visited, result)
                Next
            Next

            Return result
        End Function

        Private Sub Visit(tbl As SyncableTable, allTables As List(Of SyncableTable), visited As HashSet(Of String), result As List(Of SyncableTable))
            If visited.Contains(tbl.TableName) Then Return
            
            visited.Add(tbl.TableName)

            ' زيارة الاعتماديات (Visit Dependencies)
            If tbl.DependsOn IsNot Nothing Then
                For Each depName In tbl.DependsOn
                    Dim depTable = allTables.FirstOrDefault(Function(t) t.TableName.Equals(depName, StringComparison.OrdinalIgnoreCase))
                    If depTable IsNot Nothing Then
                        Visit(depTable, allTables, visited, result)
                    End If
                Next
            End If

            result.Add(tbl)
        End Sub

    End Module

End Namespace
