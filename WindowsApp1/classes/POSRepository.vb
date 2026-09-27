
Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Class POSRepository
    Private ReadOnly _ConnectionString As String

    Public Sub New(connectionString As String)
        _ConnectionString = connectionString
    End Sub

    ' 1. جلب أحجام المنتج مع تفاصيل الحجم
    Public Function GetProductSizes(productID As Integer) As List(Of ProductSizeModel)
        Dim list As New List(Of ProductSizeModel)

        Dim sql As String = "
            SELECT 
                ps.ProductSizeID, ps.ProductID, ps.SizeID, ps.CostPrice, ps.SalePrice, 
                ps.Barcode, ps.ImageBase64, ps.IsDefault, ps.SortOrder, ps.IsActive, ps.IsDeleted, ps.CreatedAt,
                s.SizeCode, s.SizeNameAr, s.SizeNameEn
            FROM ProductSizes ps
            INNER JOIN Sizes s ON ps.SizeID = s.SizeID
            WHERE ps.ProductID = @ProductID 
              AND ps.IsActive = 1 AND ps.IsDeleted = 0
              AND s.IsActive = 1 AND s.IsDeleted = 0
            ORDER BY ps.SortOrder, ps.ProductSizeID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim ps As New ProductSizeModel With {
                            .ProductSizeID = Convert.ToInt32(rdr("ProductSizeID")),
                            .ProductID = Convert.ToInt32(rdr("ProductID")),
                            .SizeID = Convert.ToInt32(rdr("SizeID")),
                            .CostPrice = Convert.ToDecimal(rdr("CostPrice")),
                            .SalePrice = Convert.ToDecimal(rdr("SalePrice")),
                            .Barcode = If(IsDBNull(rdr("Barcode")), Nothing, rdr("Barcode").ToString()),
                            .ImageBase64 = If(IsDBNull(rdr("ImageBase64")), Nothing, rdr("ImageBase64").ToString()),
                            .IsDefault = Convert.ToBoolean(rdr("IsDefault")),
                            .SortOrder = Convert.ToInt32(rdr("SortOrder")),
                            .IsActive = Convert.ToBoolean(rdr("IsActive")),
                            .IsDeleted = Convert.ToBoolean(rdr("IsDeleted")),
                            .CreatedAt = Convert.ToDateTime(rdr("CreatedAt")),
                            .SizeInfo = New SizeModel With {
                                .SizeID = Convert.ToInt32(rdr("SizeID")),
                                .SizeCode = If(IsDBNull(rdr("SizeCode")), Nothing, rdr("SizeCode").ToString()),
                                .SizeNameAr = rdr("SizeNameAr").ToString(),
                                .SizeNameEn = If(IsDBNull(rdr("SizeNameEn")), Nothing, rdr("SizeNameEn").ToString())
                            }
                        }
                        list.Add(ps)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ' 2. جلب إضافات المنتج مع تفاصيل الإضافة
    Public Function GetProductAddons(productID As Integer) As List(Of ProductAddonModel)
        Dim list As New List(Of ProductAddonModel)

        Dim sql As String = "
            SELECT 
                pa.ProductAddonID, pa.ProductID, pa.AddonID, pa.CostPrice, pa.SalePrice, 
                pa.IsActive, pa.IsDeleted, pa.CreatedAt, pa.SortOrder, pa.IsDefault,
                a.AddonCode, a.AddonNameAr, a.AddonNameEn
            FROM ProductAddons pa
            INNER JOIN Addons a ON pa.AddonID = a.AddonID
            WHERE pa.ProductID = @ProductID 
              AND pa.IsActive = 1 AND pa.IsDeleted = 0
              AND a.IsActive = 1 AND a.IsDeleted = 0
            ORDER BY pa.SortOrder, pa.ProductAddonID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim pa As New ProductAddonModel With {
                            .ProductAddonID = Convert.ToInt32(rdr("ProductAddonID")),
                            .ProductID = Convert.ToInt32(rdr("ProductID")),
                            .AddonID = Convert.ToInt32(rdr("AddonID")),
                            .CostPrice = Convert.ToDecimal(rdr("CostPrice")),
                            .SalePrice = Convert.ToDecimal(rdr("SalePrice")),
                            .IsActive = Convert.ToBoolean(rdr("IsActive")),
                            .IsDeleted = Convert.ToBoolean(rdr("IsDeleted")),
                            .CreatedAt = Convert.ToDateTime(rdr("CreatedAt")),
                            .AddonInfo = New AddonModel With {
                                .AddonID = Convert.ToInt32(rdr("AddonID")),
                                .AddonCode = If(IsDBNull(rdr("AddonCode")), Nothing, rdr("AddonCode").ToString()),
                                .AddonNameAr = rdr("AddonNameAr").ToString(),
                                .AddonNameEn = If(IsDBNull(rdr("AddonNameEn")), Nothing, rdr("AddonNameEn").ToString())
                            }
                        }

                        If Not IsDBNull(rdr("SortOrder")) Then pa.SortOrder = Convert.ToInt32(rdr("SortOrder"))
                        If Not IsDBNull(rdr("IsDefault")) Then pa.IsDefault = Convert.ToBoolean(rdr("IsDefault"))

                        list.Add(pa)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    '1. جلب الأقسام مع الألوان
    Public Function GetCategories() As List(Of CategoryModel)
        Dim list As New List(Of CategoryModel)

        Dim sql As String = "
                SELECT 
                    c.Category_ID, c.CategoryCode, c.Category_NameAr, c.CategoryNameEn,
                    c.Imagebase64, c.Description, c.IsActive, c.IsDeleted,
                    c.ColorID, c.CategoryTypeID, c.PrinterID,
                    cl.ColorID AS ColorTableID, cl.ColorCode, cl.ColorName, cl.HexCode
                FROM Categories c
                LEFT JOIN Colors cl ON c.ColorID = cl.ColorID
                WHERE c.IsActive = 1 AND c.IsDeleted = 0
                ORDER BY c.Category_ID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim cat As New CategoryModel With {
                            .Category_ID = Convert.ToInt32(rdr("Category_ID")),
                            .CategoryCode = If(IsDBNull(rdr("CategoryCode")), Nothing, rdr("CategoryCode").ToString()),
                            .Category_NameAr = If(IsDBNull(rdr("Category_NameAr")), Nothing, rdr("Category_NameAr").ToString()),
                            .CategoryNameEn = If(IsDBNull(rdr("CategoryNameEn")), Nothing, rdr("CategoryNameEn").ToString()),
                            .Imagebase64 = If(IsDBNull(rdr("Imagebase64")), Nothing, rdr("Imagebase64").ToString()),
                            .Description = If(IsDBNull(rdr("Description")), Nothing, rdr("Description").ToString()),
                            .IsActive = Convert.ToBoolean(rdr("IsActive")),
                            .IsDeleted = Convert.ToBoolean(rdr("IsDeleted"))
                        }

                        If Not IsDBNull(rdr("ColorTableID")) Then
                            cat.CategoryColor = New ColorModel With {
                                .ColorID = Convert.ToInt32(rdr("ColorTableID")),
                                .ColorCode = If(IsDBNull(rdr("ColorCode")), Nothing, rdr("ColorCode").ToString()),
                                .ColorName = If(IsDBNull(rdr("ColorName")), Nothing, rdr("ColorName").ToString()),
                                .HexCode = If(IsDBNull(rdr("HexCode")), Nothing, rdr("HexCode").ToString())
                            }
                        End If

                        list.Add(cat)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ' 2. جلب أصناف قسم معين
    Public Function GetProductsByCategoryID(categoryID As Integer) As List(Of ProductModel)
        Dim list As New List(Of ProductModel)

        Dim sql As String = "
                SELECT 
                    p.Product_ID, p.ProductCode, p.ProductNameAr, p.ProductNameEn, p.[Image],
                    p.Description, p.DiscountPercent, p.TaxPercent, p.IsActive, p.IsDeleted,
                    p.PreparationTime, p.Notes, p.Category_ID, p.IsDiscountPercent, p.IsTaxPercent,
                    (SELECT COUNT(*) FROM ProductSizes ps WHERE ps.ProductID = p.Product_ID AND ps.IsActive = 1 AND ps.IsDeleted = 0) AS SizesCount,
                    (SELECT COUNT(*) FROM ProductAddons pa WHERE pa.ProductID = p.Product_ID AND pa.IsActive = 1 AND pa.IsDeleted = 0) AS AddonsCount,
                    ISNULL((SELECT TOP 1 ps.SalePrice FROM ProductSizes ps WHERE ps.ProductID = p.Product_ID AND ps.IsActive = 1 AND ps.IsDeleted = 0 ORDER BY ps.IsDefault DESC, ps.SortOrder, ps.ProductSizeID), ISNULL(p.SalePrice, ISNULL(p.BasePrice, 0))) AS DefaultPrice,
                    ISNULL(p.IsDirect, 1) AS IsDirect
                FROM Products p
                WHERE (@CategoryID <= 0 OR p.Category_ID = @CategoryID) AND p.IsActive = 1 AND p.IsDeleted = 0
                ORDER BY p.ProductNameAr;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@CategoryID", categoryID)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim prod As New ProductModel With {
                            .Product_ID = Convert.ToInt32(rdr("Product_ID")),
                            .ProductCode = If(IsDBNull(rdr("ProductCode")), Nothing, rdr("ProductCode").ToString()),
                            .ProductNameAr = If(IsDBNull(rdr("ProductNameAr")), Nothing, rdr("ProductNameAr").ToString()),
                            .ProductNameEn = If(IsDBNull(rdr("ProductNameEn")), Nothing, rdr("ProductNameEn").ToString()),
                            .Image = If(IsDBNull(rdr("Image")), Nothing, rdr("Image").ToString()),
                            .Description = If(IsDBNull(rdr("Description")), Nothing, rdr("Description").ToString()),
                            .Notes = If(IsDBNull(rdr("Notes")), Nothing, rdr("Notes").ToString())
                        }

                        If Not IsDBNull(rdr("DiscountPercent")) Then prod.DiscountPercent = Convert.ToDouble(rdr("DiscountPercent"))
                        If Not IsDBNull(rdr("TaxPercent")) Then prod.TaxPercent = Convert.ToDouble(rdr("TaxPercent"))
                        If Not IsDBNull(rdr("IsActive")) Then prod.IsActive = Convert.ToBoolean(rdr("IsActive"))
                        If Not IsDBNull(rdr("IsDeleted")) Then prod.IsDeleted = Convert.ToBoolean(rdr("IsDeleted"))
                        If Not IsDBNull(rdr("Category_ID")) Then prod.Category_ID = Convert.ToInt32(rdr("Category_ID"))
                        If Not IsDBNull(rdr("IsDiscountPercent")) Then prod.IsDiscountPercent = Convert.ToBoolean(rdr("IsDiscountPercent"))
                        If Not IsDBNull(rdr("IsTaxPercent")) Then prod.IsTaxPercent = Convert.ToBoolean(rdr("IsTaxPercent"))
                        If Not IsDBNull(rdr("SizesCount")) Then prod.SizesCount = Convert.ToInt32(rdr("SizesCount"))
                        If Not IsDBNull(rdr("AddonsCount")) Then prod.AddonsCount = Convert.ToInt32(rdr("AddonsCount"))
                        If Not IsDBNull(rdr("DefaultPrice")) Then
                            prod.DefaultPrice = Convert.ToDecimal(rdr("DefaultPrice"))
                            prod.BasePrice = prod.DefaultPrice
                        End If
                        If Not IsDBNull(rdr("IsDirect")) Then prod.IsDirect = Convert.ToBoolean(rdr("IsDirect"))

                        list.Add(prod)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ' 1. جلب الطيارين النشطين مع بيانات منطقتهم
    Public Function GetActiveDeliveryDrivers() As List(Of DeliveryDriverModel)
        Dim list As New List(Of DeliveryDriverModel)

        Dim sql As String = "
        SELECT 
            d.DriverID, d.DriverCode, d.DriverName, d.Phone, d.Phone2, 
            d.NationalID, d.EmployeeID, d.LicenseNumber, d.VehicleType, 
            d.VehiclePlateNumber, d.IsPercentage, d.DeliveryFeeValue, 
            d.DriverStatus, d.Notes, d.IsActive, d.IsDeleted, d.CreatedAt, 
            d.CreatedBy, d.AreaID,
            a.AreaCode, a.AreaName
        FROM DeliveryDrivers d
        LEFT JOIN DeliveryAreas a ON d.AreaID = a.AreaID
        WHERE d.IsActive = 1 AND d.IsDeleted = 0
        ;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim driver As New DeliveryDriverModel With {
                        .DriverID = Convert.ToInt32(rdr("DriverID")),
                        .DriverCode = rdr("DriverCode").ToString(),
                        .DriverName = rdr("DriverName").ToString(),
                        .Phone = rdr("Phone").ToString(),
                        .Phone2 = If(IsDBNull(rdr("Phone2")), "", rdr("Phone2").ToString()),
                        .NationalID = If(IsDBNull(rdr("NationalID")), "", rdr("NationalID").ToString()),
                        .VehicleType = If(IsDBNull(rdr("VehicleType")), "", rdr("VehicleType").ToString()),
                        .VehiclePlateNumber = If(IsDBNull(rdr("VehiclePlateNumber")), "", rdr("VehiclePlateNumber").ToString()),
                        .IsPercentage = Convert.ToBoolean(rdr("IsPercentage")),
                        .DeliveryFeeValue = Convert.ToDecimal(rdr("DeliveryFeeValue")),
                        .DriverStatus = Convert.ToByte(rdr("DriverStatus")),
                        .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString()),
                        .IsActive = Convert.ToBoolean(rdr("IsActive")),
                        .IsDeleted = Convert.ToBoolean(rdr("IsDeleted")),
                        .CreatedAt = Convert.ToDateTime(rdr("CreatedAt"))
                    }

                        If Not IsDBNull(rdr("AreaID")) Then
                            driver.AreaID = Convert.ToInt32(rdr("AreaID"))
                            driver.AreaInfo = New DeliveryAreaModel With {
                            .AreaID = Convert.ToInt32(rdr("AreaID")),
                            .AreaCode = If(IsDBNull(rdr("AreaCode")), "", rdr("AreaCode").ToString()),
                            .AreaName = rdr("AreaName").ToString()
                        }
                        End If

                        list.Add(driver)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ' 2. جلب جميع مناطق التوصيل
    Public Function GetDeliveryAreas() As List(Of DeliveryAreaModel)
        Dim list As New List(Of DeliveryAreaModel)

        Dim sql As String = "
        SELECT AreaID, AreaCode, AreaName, Notes, IsActive, IsDeleted, CreatedAt
        FROM DeliveryAreas
        WHERE IsActive = 1 AND IsDeleted = 0
        ORDER BY AreaName;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        list.Add(New DeliveryAreaModel With {
                        .AreaID = Convert.ToInt32(rdr("AreaID")),
                        .AreaCode = If(IsDBNull(rdr("AreaCode")), "", rdr("AreaCode").ToString()),
                        .AreaName = rdr("AreaName").ToString(),
                        .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString()),
                        .IsActive = Convert.ToBoolean(rdr("IsActive")),
                        .IsDeleted = Convert.ToBoolean(rdr("IsDeleted")),
                        .CreatedAt = Convert.ToDateTime(rdr("CreatedAt"))
                    })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function


    ' 1. جلب أقسام المطعم
    Public Function GetRestaurantSections() As List(Of RestaurantSectionModel)
        Dim list As New List(Of RestaurantSectionModel)
        Dim sql As String = "SELECT SectionID, SectionCode, SectionName, TablesCount, Notes, IsActive, IsDeleted, CreatedAt " &
                             "FROM RestaurantSections WHERE IsActive = 1 AND IsDeleted = 0 ORDER BY SectionID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        list.Add(New RestaurantSectionModel With {
                            .SectionID = Convert.ToInt32(rdr("SectionID")),
                            .SectionCode = If(IsDBNull(rdr("SectionCode")), "", rdr("SectionCode").ToString()),
                            .SectionName = rdr("SectionName").ToString(),
                            .TablesCount = Convert.ToInt32(rdr("TablesCount")),
                            .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString()),
                            .IsActive = Convert.ToBoolean(rdr("IsActive")),
                            .IsDeleted = Convert.ToBoolean(rdr("IsDeleted")),
                            .CreatedAt = Convert.ToDateTime(rdr("CreatedAt"))
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ' 2. جلب طاولات قسم معين (أو الكل)
    Public Function GetRestaurantTables(Optional sectionID As Integer? = Nothing) As List(Of RestaurantTableModel)
        Dim list As New List(Of RestaurantTableModel)
        Dim sql As String = "SELECT t.TableID, t.TableNumber, t.TableName, t.SectionID, t.ChairsCount, t.TableStatus, " &
                             "t.Notes, t.IsActive, t.IsDeleted, t.CreatedAt, s.SectionName " &
                             "FROM RestaurantTables t " &
                             "INNER JOIN RestaurantSections s ON t.SectionID = s.SectionID " &
                             "WHERE t.IsActive = 1 AND t.IsDeleted = 0 AND s.IsActive = 1 AND s.IsDeleted = 0 "

        If sectionID.HasValue AndAlso sectionID.Value > 0 Then
            sql &= " AND t.SectionID = @SectionID "
        End If

        sql &= " ORDER BY t.TableNumber;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                If sectionID.HasValue AndAlso sectionID.Value > 0 Then
                    cmd.Parameters.AddWithValue("@SectionID", sectionID.Value)
                End If

                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        list.Add(New RestaurantTableModel With {
                            .TableID = Convert.ToInt32(rdr("TableID")),
                            .TableNumber = rdr("TableNumber").ToString(),
                            .TableName = If(IsDBNull(rdr("TableName")), "", rdr("TableName").ToString()),
                            .SectionID = Convert.ToInt32(rdr("SectionID")),
                            .ChairsCount = Convert.ToInt32(rdr("ChairsCount")),
                            .TableStatus = Convert.ToByte(rdr("TableStatus")),
                            .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString()),
                            .IsActive = Convert.ToBoolean(rdr("IsActive")),
                            .IsDeleted = Convert.ToBoolean(rdr("IsDeleted")),
                            .CreatedAt = Convert.ToDateTime(rdr("CreatedAt")),
                            .SectionInfo = New RestaurantSectionModel With {
                                .SectionID = Convert.ToInt32(rdr("SectionID")),
                                .SectionName = rdr("SectionName").ToString()
                            }
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function


    ' 1. جلب العملاء النشطين فقط (لشاشة الاختيار في POS)
    Public Function GetActiveCustomers(Optional searchQuery As String = "") As List(Of CustomerModel)
        Dim list As New List(Of CustomerModel)

        Dim sql As String = "
        SELECT 
            c.CustomerID, c.CustomerCode, c.CustomerName, c.Phone1, c.Phone2, 
            c.Email, c.AreaID, c.Address, c.CurrentBalance, c.AllowCredit, 
            c.CreditLimit, c.IsDiscountPercent, c.DiscountPercent, c.IsDeleted, c.IsActive, 
            c.StopReason, c.Rating, c.Notes, c.CreatedDate, c.CreatedByUserID, c.LastTransactionDate,
            a.AreaCode, a.AreaName
        FROM Customers c
        LEFT JOIN DeliveryAreas a ON c.AreaID = a.AreaID
        WHERE c.IsActive = 1 AND c.IsDeleted = 0 "

        If Not String.IsNullOrWhiteSpace(searchQuery) Then
            sql &= " AND (c.CustomerName LIKE @Search OR c.CustomerCode LIKE @Search OR c.Phone1 LIKE @Search OR c.Phone2 LIKE @Search OR c.Address LIKE @Search OR c.Email LIKE @Search OR c.Notes LIKE @Search OR a.AreaName LIKE @Search) "
        End If

        sql &= " ORDER BY c.CustomerName;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                If Not String.IsNullOrWhiteSpace(searchQuery) Then
                    cmd.Parameters.AddWithValue("@Search", "%" & searchQuery.Trim() & "%")
                End If

                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim cust As New CustomerModel With {
                            .CustomerID = Convert.ToInt32(rdr("CustomerID")),
                            .CustomerCode = If(IsDBNull(rdr("CustomerCode")), "", rdr("CustomerCode").ToString()),
                            .CustomerName = rdr("CustomerName").ToString(),
                            .Phone1 = rdr("Phone1").ToString(),
                            .Phone2 = If(IsDBNull(rdr("Phone2")), "", rdr("Phone2").ToString()),
                            .Email = If(IsDBNull(rdr("Email")), "", rdr("Email").ToString()),
                            .Address = If(IsDBNull(rdr("Address")), "", rdr("Address").ToString()),
                            .CurrentBalance = If(IsDBNull(rdr("CurrentBalance")), 0, Convert.ToDecimal(rdr("CurrentBalance"))),
                            .AllowCredit = If(IsDBNull(rdr("AllowCredit")), False, Convert.ToBoolean(rdr("AllowCredit"))),
                            .CreditLimit = If(IsDBNull(rdr("CreditLimit")), 0, Convert.ToDecimal(rdr("CreditLimit"))),
                            .IsDiscountPercent = If(IsDBNull(rdr("IsDiscountPercent")), True, Convert.ToBoolean(rdr("IsDiscountPercent"))),
                            .DiscountPercent = If(IsDBNull(rdr("DiscountPercent")), 0, Convert.ToDouble(rdr("DiscountPercent"))),
                            .IsActive = Convert.ToBoolean(rdr("IsActive")),
                            .IsDeleted = Convert.ToBoolean(rdr("IsDeleted"))
                        }

                        If Not IsDBNull(rdr("AreaID")) Then
                            cust.AreaID = Convert.ToInt32(rdr("AreaID"))
                            cust.AreaInfo = New DeliveryAreaModel With {
                                .AreaID = Convert.ToInt32(rdr("AreaID")),
                                .AreaName = rdr("AreaName").ToString()
                            }
                        End If

                        list.Add(cust)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ' 1. جلب العملاء النشطين فقط (لشاشة الاختيار في POS)
    Public Function GetAllCustomers(Optional searchQuery As String = "") As List(Of CustomerModel)
        Dim list As New List(Of CustomerModel)

        Dim sql As String = "
        SELECT 
            c.CustomerID, c.CustomerCode, c.CustomerName, c.Phone1, c.Phone2, 
            c.Email, c.AreaID, c.Address, c.CurrentBalance, c.AllowCredit, 
            c.CreditLimit,c.IsDiscountPercent, c.DiscountPercent, c.IsDeleted, c.IsActive, 
            c.StopReason, c.Rating, c.Notes, c.CreatedDate, c.CreatedByUserID, c.LastTransactionDate,
            a.AreaCode, a.AreaName
        FROM Customers c
        LEFT JOIN DeliveryAreas a ON c.AreaID = a.AreaID
        WHERE c.IsDeleted = 0 OR c.IsDeleted is Null "

        If Not String.IsNullOrWhiteSpace(searchQuery) Then
            sql &= " AND (c.CustomerName LIKE @Search OR c.Phone1 LIKE @Search OR c.Phone2 LIKE @Search) "
        End If

        sql &= " ORDER BY c.CustomerName;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                If Not String.IsNullOrWhiteSpace(searchQuery) Then
                    cmd.Parameters.AddWithValue("@Search", "%" & searchQuery.Trim() & "%")
                End If

                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim cust As New CustomerModel With {
                            .CustomerID = Convert.ToInt32(rdr("CustomerID")),
                            .CustomerCode = If(IsDBNull(rdr("CustomerCode")), "", rdr("CustomerCode").ToString()),
                            .CustomerName = rdr("CustomerName").ToString(),
                            .Phone1 = rdr("Phone1").ToString(),
                            .Phone2 = If(IsDBNull(rdr("Phone2")), "", rdr("Phone2").ToString()),
                            .Email = If(IsDBNull(rdr("Email")), "", rdr("Email").ToString()),
                            .Address = If(IsDBNull(rdr("Address")), "", rdr("Address").ToString()),
                            .CurrentBalance = If(IsDBNull(rdr("CurrentBalance")), 0, Convert.ToDecimal(rdr("CurrentBalance"))),
                            .AllowCredit = If(IsDBNull(rdr("AllowCredit")), False, Convert.ToBoolean(rdr("AllowCredit"))),
                            .CreditLimit = If(IsDBNull(rdr("CreditLimit")), 0, Convert.ToDecimal(rdr("CreditLimit"))),
                            .IsDiscountPercent = If(IsDBNull(rdr("IsDiscountPercent")), True, Convert.ToBoolean(rdr("IsDiscountPercent"))),
                            .DiscountPercent = If(IsDBNull(rdr("DiscountPercent")), 0, Convert.ToDouble(rdr("DiscountPercent"))),
                            .IsActive = Convert.ToBoolean(rdr("IsActive")),
                            .IsDeleted = Convert.ToBoolean(rdr("IsDeleted"))
                        }

                        If Not IsDBNull(rdr("AreaID")) Then
                            cust.AreaID = Convert.ToInt32(rdr("AreaID"))
                            cust.AreaInfo = New DeliveryAreaModel With {
                                .AreaID = Convert.ToInt32(rdr("AreaID")),
                                .AreaName = rdr("AreaName").ToString()
                            }
                        End If

                        list.Add(cust)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ' 2. إضافة عميل جديد
    Public Function AddCustomer(customer As CustomerModel) As Boolean
        Dim sql As String = "
        INSERT INTO Customers (CustomerCode, CustomerName, Phone1, Phone2, Email, AreaID, Address, AllowCredit, CreditLimit, IsDiscountPercent, DiscountPercent, Notes, IsActive, IsDeleted, CreatedDate)
        VALUES (@CustomerCode, @CustomerName, @Phone1, @Phone2, @Email, @AreaID, @Address, @AllowCredit, @CreditLimit, @IsDiscountPercent, @DiscountPercent, @Notes, 1, 0, GETDATE());"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@CustomerCode", If(String.IsNullOrEmpty(customer.CustomerCode), DBNull.Value, customer.CustomerCode))
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName)
                cmd.Parameters.AddWithValue("@Phone1", customer.Phone1)
                cmd.Parameters.AddWithValue("@Phone2", If(String.IsNullOrEmpty(customer.Phone2), DBNull.Value, customer.Phone2))
                cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrEmpty(customer.Email), DBNull.Value, customer.Email))
                cmd.Parameters.AddWithValue("@AreaID", If(customer.AreaID.HasValue, customer.AreaID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrEmpty(customer.Address), DBNull.Value, customer.Address))
                cmd.Parameters.AddWithValue("@AllowCredit", If(customer.AllowCredit.HasValue, customer.AllowCredit.Value, False))
                cmd.Parameters.AddWithValue("@CreditLimit", If(customer.CreditLimit.HasValue, customer.CreditLimit.Value, 0))
                cmd.Parameters.AddWithValue("@IsDiscountPercent", If(customer.IsDiscountPercent.HasValue, customer.IsDiscountPercent.Value, True))
                cmd.Parameters.AddWithValue("@DiscountPercent", If(customer.DiscountPercent.HasValue, customer.DiscountPercent.Value, 0))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(customer.Notes), DBNull.Value, customer.Notes))

                con.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' 1. تعديل بيانات عميل قائم
    Public Function UpdateCustomer(customer As CustomerModel) As Boolean
        Dim sql As String = "
        UPDATE Customers SET 
            CustomerCode = @CustomerCode,
            CustomerName = @CustomerName,
            Phone1 = @Phone1,
            Phone2 = @Phone2,
            Email = @Email,
            AreaID = @AreaID,
            Address = @Address,
            IsDiscountPercent = @IsDiscountPercent,
            DiscountPercent = @DiscountPercent,
            Notes = @Notes,
            IsActive = @IsActive
        WHERE CustomerID = @CustomerID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID)
                cmd.Parameters.AddWithValue("@CustomerCode", If(String.IsNullOrEmpty(customer.CustomerCode), DBNull.Value, customer.CustomerCode))
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName)
                cmd.Parameters.AddWithValue("@Phone1", customer.Phone1)
                cmd.Parameters.AddWithValue("@Phone2", If(String.IsNullOrEmpty(customer.Phone2), DBNull.Value, customer.Phone2))
                cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrEmpty(customer.Email), DBNull.Value, customer.Email))
                cmd.Parameters.AddWithValue("@AreaID", If(customer.AreaID.HasValue, customer.AreaID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@Address", If(String.IsNullOrEmpty(customer.Address), DBNull.Value, customer.Address))
                cmd.Parameters.AddWithValue("@IsDiscountPercent", If(customer.IsDiscountPercent.HasValue, customer.IsDiscountPercent.Value, True))
                cmd.Parameters.AddWithValue("@DiscountPercent", If(customer.DiscountPercent.HasValue, customer.DiscountPercent.Value, 0))
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(customer.Notes), DBNull.Value, customer.Notes))
                cmd.Parameters.AddWithValue("@IsActive", If(customer.IsActive.HasValue, customer.IsActive.Value, True))

                con.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' جلب بيانات عميل بالـ ID
    Public Function GetCustomerByID(customerID As Integer) As CustomerModel
        Dim sql As String = "SELECT * FROM Customers WHERE CustomerID = @CustomerID;"
        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                con.Open()
                Using rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        Return New CustomerModel With {
                            .CustomerID = Convert.ToInt32(rdr("CustomerID")),
                            .CustomerCode = If(IsDBNull(rdr("CustomerCode")), "", rdr("CustomerCode").ToString()),
                            .CustomerName = rdr("CustomerName").ToString(),
                            .CurrentBalance = If(IsDBNull(rdr("CurrentBalance")), 0D, Convert.ToDecimal(rdr("CurrentBalance")))
                        }
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    ' 2. الحذف الناعم (Soft Delete)
    Public Function SoftDeleteCustomer(customerID As Integer) As Boolean
        Dim sql As String = "UPDATE Customers SET IsDeleted = 1, IsActive = 0 WHERE CustomerID = @CustomerID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                con.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' 3. التحقق من تكرار رقم الموبايل
    Public Function IsPhoneExists(phone As String, Optional excludeCustomerID As Integer = 0) As Boolean
        Dim sql As String = "SELECT COUNT(1) FROM Customers WHERE Phone1 = @Phone AND IsDeleted = 0 AND CustomerID <> @ExcludeID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@Phone", phone.Trim())
                cmd.Parameters.AddWithValue("@ExcludeID", excludeCustomerID)
                con.Open()
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    ' 1. جلب الوردية المفتوحة حالياً (Status = 1) لربطها بالـ Session
    Public Function GetActiveShift() As ShiftModel
        Dim shift As ShiftModel = Nothing

        ' نفس الاستعلام المستخدم في LoadShiftsGridAndActiveStatus عندك
        Dim sql As String = "
        SELECT TOP 1 * ,WorkShiftName
FROM Shifts S
LEFT JOIN WorkShifts WF ON S.WorkShiftID = WF.WorkShiftID
WHERE Status = 1 AND S.IsActive = 1 AND (S.IsDeleted = 0 OR S.IsDeleted IS NULL)
ORDER BY ShiftID DESC;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    If rdr.Read() Then
                        shift = New ShiftModel With {
                        .ShiftID = Convert.ToInt32(rdr("ShiftID")),
                        .ShiftNumber = rdr("ShiftNumber").ToString(),
                        .UserID = Convert.ToInt32(rdr("UserID")),
                        .OpenDateTime = Convert.ToDateTime(rdr("OpenDateTime")),
                        .OpeningCash = Convert.ToDecimal(rdr("OpeningCash")),
                        .TotalSales = Convert.ToDecimal(rdr("TotalSales")),
                        .TotalExpenses = Convert.ToDecimal(rdr("TotalExpenses")),
                        .TotalIncomes = Convert.ToDecimal(rdr("TotalIncomes")),
                        .TotalRefunds = Convert.ToDecimal(rdr("TotalRefunds")),
                        .Status = Convert.ToByte(rdr("Status")),
                        .WorkShiftName = Convert.ToString(rdr("WorkShiftName"))
                    }

                        If Not IsDBNull(rdr("BranchID")) Then shift.BranchID = Convert.ToInt32(rdr("BranchID"))
                        If Not IsDBNull(rdr("WorkShiftID")) Then shift.WorkShiftID = Convert.ToInt32(rdr("WorkShiftID"))
                        If Not IsDBNull(rdr("Notes")) Then shift.Notes = rdr("Notes").ToString()
                    End If
                End Using
            End Using
        End Using

        Return shift
    End Function


    ' ==========================================
    ' 1. حفظ الفاتورة المكتملة بالتفاصيل والـ Transaction والربط بالخزينة
    ' ==========================================
    Public Async Function SaveInvoiceAsync(inv As InvoiceModel) As Task(Of String)
        Dim sqlInvoice As String = "
        INSERT INTO SalesInvoices 
        (InvoiceNumber, InvoiceDate, OrderType, ShiftID, UserID, CustomerID, TableID, DriverID,
        BranchID, StoreID, DeliveryFee, TotalBeforeDiscount, DiscountAmount, NetTotal, PaidAmount, RemainingAmount, IsCredit, TreasuryID, Notes, IsActive, IsDeleted, CreatedAt)
        VALUES 
        (@Num, GETDATE(), @OrderType, @ShiftID, @UserID, @CustomerID, @TableID, @DriverID,
        @BranchID, @StoreID, @DeliveryFee, @TotalBeforeDiscount, @DiscountAmount, @NetTotal, @PaidAmount, @RemainingAmount, @IsCredit, @TreasuryID, @Notes, 1, 0, GETDATE());
        SELECT SCOPE_IDENTITY();"

        Dim sqlDetail As String = "
        INSERT INTO SalesInvoiceDetails 
        (InvoiceID, ProductID, ProductName, SizeName, AddonsText, UnitPrice, Quantity, TotalPrice, Notes)
        VALUES 
        (@InvoiceID, @ProductID, @ProductName, @SizeName, @AddonsText, @UnitPrice, @Quantity, @TotalPrice, @Notes);"

        Using con As New SqlConnection(_ConnectionString)
            Await con.OpenAsync()
            Dim trans As SqlTransaction = con.BeginTransaction()

            Try
                ' توليد رقم فاتورة متسلسل تصاعدي يبدأ من 1 (1, 2, 3...)
                Dim nextInvNum As Integer = 1
                Dim sqlSeq As String = "SELECT ISNULL(MAX(TRY_CAST(InvoiceNumber AS INT)), 0) + 1 FROM SalesInvoices WITH (UPDLOCK, HOLDLOCK);"
                Using cmdSeq As New SqlCommand(sqlSeq, con, trans)
                    Dim objSeq = Await cmdSeq.ExecuteScalarAsync()
                    If objSeq IsNot Nothing AndAlso Not IsDBNull(objSeq) Then
                        nextInvNum = Convert.ToInt32(objSeq)
                    End If
                End Using
                Dim generatedNumber As String = nextInvNum.ToString()
                inv.InvoiceNumber = generatedNumber

                Dim newInvoiceID As Integer = 0

                ' أ) حفظ رأس الفاتورة
                Using cmdInv As New SqlCommand(sqlInvoice, con, trans)
                    cmdInv.Parameters.AddWithValue("@Num", generatedNumber)
                    cmdInv.Parameters.AddWithValue("@OrderType", inv.OrderType)
                    cmdInv.Parameters.AddWithValue("@ShiftID", inv.ShiftID)
                    cmdInv.Parameters.AddWithValue("@UserID", inv.UserID)
                    cmdInv.Parameters.AddWithValue("@CustomerID", If(inv.CustomerID.HasValue, inv.CustomerID.Value, DBNull.Value))
                    cmdInv.Parameters.AddWithValue("@TableID", If(inv.TableID.HasValue, inv.TableID.Value, DBNull.Value))
                    cmdInv.Parameters.AddWithValue("@DriverID", If(inv.DriverID.HasValue, inv.DriverID.Value, DBNull.Value))
                    cmdInv.Parameters.AddWithValue("@BranchID", If(inv.BranchID.HasValue, inv.BranchID.Value, DBNull.Value))
                    cmdInv.Parameters.AddWithValue("@StoreID", If(inv.StoreID.HasValue, inv.StoreID.Value, DBNull.Value))
                    cmdInv.Parameters.AddWithValue("@DeliveryFee", inv.DeliveryFee)
                    cmdInv.Parameters.AddWithValue("@TotalBeforeDiscount", inv.TotalBeforeDiscount)
                    cmdInv.Parameters.AddWithValue("@DiscountAmount", inv.DiscountAmount)
                    cmdInv.Parameters.AddWithValue("@NetTotal", inv.NetTotal)
                    cmdInv.Parameters.AddWithValue("@PaidAmount", inv.PaidAmount)
                    cmdInv.Parameters.AddWithValue("@RemainingAmount", inv.RemainingAmount)
                    cmdInv.Parameters.AddWithValue("@IsCredit", inv.IsCredit)
                    cmdInv.Parameters.AddWithValue("@TreasuryID", If(inv.TreasuryID.HasValue, inv.TreasuryID.Value, DBNull.Value))
                    cmdInv.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(inv.Notes), DBNull.Value, inv.Notes))

                    Dim objId = Await cmdInv.ExecuteScalarAsync()
                    newInvoiceID = Convert.ToInt32(objId)
                End Using

                ' ب) حفظ تفاصيل الفاتورة وخصم المخزون
                For Each dt In inv.Details
                    Using cmdDet As New SqlCommand(sqlDetail, con, trans)
                        cmdDet.Parameters.AddWithValue("@InvoiceID", newInvoiceID)
                        cmdDet.Parameters.AddWithValue("@ProductID", dt.ProductID)
                        cmdDet.Parameters.AddWithValue("@ProductName", dt.ProductName)
                        cmdDet.Parameters.AddWithValue("@SizeName", If(String.IsNullOrEmpty(dt.SizeName), DBNull.Value, dt.SizeName))
                        cmdDet.Parameters.AddWithValue("@AddonsText", If(String.IsNullOrEmpty(dt.AddonsText), DBNull.Value, dt.AddonsText))
                        cmdDet.Parameters.AddWithValue("@UnitPrice", dt.UnitPrice)
                        cmdDet.Parameters.AddWithValue("@Quantity", dt.Quantity)
                        cmdDet.Parameters.AddWithValue("@TotalPrice", dt.TotalPrice)
                        cmdDet.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(dt.Notes), DBNull.Value, dt.Notes))

                        Await cmdDet.ExecuteNonQueryAsync()
                    End Using

                    ' خصم المخزون حسب الريسيبي إن كان هناك مخزن محدد وميزة خصم الخامات مفعلة
                    If inv.StoreID.HasValue AndAlso inv.StoreID.Value > 0 Then
                        Try
                            Dim shouldDeduct As Boolean = SettingsManager.GetBoolSetting(SettingsKeys.SalesDeductIngredients, True)
                            If shouldDeduct Then
                                InventoryDeductionManager.DeductItemRecipe(con, trans, inv.StoreID.Value, dt.ProductID, Nothing, Nothing, dt.Quantity, generatedNumber)
                            End If
                        Catch exStock As Exception
                            Debug.WriteLine("Inventory deduction error: " & exStock.Message)
                        End Try
                    End If
                Next

                ' =========================================================================
                ' ج) تسجيل حركة العميل وتحديث رصيده (مرة واحدة بصورة متسقة)
                ' =========================================================================
                If inv.CustomerID.HasValue Then
                    ' 1. جلب الرصيد السابق للعميل
                    Dim prevBalance As Decimal = 0
                    Dim sqlGetBal As String = "SELECT ISNULL(CurrentBalance, 0) FROM Customers WHERE CustomerID = @CID;"
                    Using cmdBal As New SqlCommand(sqlGetBal, con, trans)
                        cmdBal.Parameters.AddWithValue("@CID", inv.CustomerID.Value)
                        Dim balObj = Await cmdBal.ExecuteScalarAsync()
                        If balObj IsNot Nothing AndAlso Not IsDBNull(balObj) Then
                            prevBalance = Convert.ToDecimal(balObj)
                        End If
                    End Using

                    ' 2. حساب الرصيد الجديد: الرصيد السابق - المبلغ المتبقي (المديونية بالسالب)
                    Dim newBalance As Decimal = prevBalance - inv.RemainingAmount

                    ' 3. تسجيل الحركة في جدول CustomerTransactions
                    Dim sqlCustTrans As String = "
        INSERT INTO CustomerTransactions 
        (TransactionDate, CustomerID, InvoiceID, BranchID, TransactionType, Debit, Credit, BalanceAfter, Notes, ShiftID, UserID, CreatedAt)
        VALUES 
        (GETDATE(), @CustomerID, @InvoiceID, @BranchID, @Type, @Debit, @Credit, @BalanceAfter, @Notes, @ShiftID, @UserID, GETDATE());"

                    Using cmdTrans As New SqlCommand(sqlCustTrans, con, trans)
                        cmdTrans.Parameters.AddWithValue("@CustomerID", inv.CustomerID.Value)
                        cmdTrans.Parameters.AddWithValue("@InvoiceID", newInvoiceID)
                        cmdTrans.Parameters.AddWithValue("@BranchID", If(inv.BranchID.HasValue, inv.BranchID.Value, DBNull.Value))
                        cmdTrans.Parameters.AddWithValue("@Type", If(inv.IsCredit, "فاتورة بيع آجل", "فاتورة بيع نقدي"))
                        cmdTrans.Parameters.AddWithValue("@Debit", inv.NetTotal)       '-- القيمة المطلوبة
                        cmdTrans.Parameters.AddWithValue("@Credit", inv.PaidAmount)    ' -- القيمة المدفوعة
                        cmdTrans.Parameters.AddWithValue("@BalanceAfter", newBalance)
                        cmdTrans.Parameters.AddWithValue("@Notes", "فاتورة مبيعات رقم " & generatedNumber)
                        cmdTrans.Parameters.AddWithValue("@ShiftID", inv.ShiftID)
                        cmdTrans.Parameters.AddWithValue("@UserID", inv.UserID)
                        Await cmdTrans.ExecuteNonQueryAsync()
                    End Using

                    ' 4. تحديث الرصيد النهائي في جدول العملاء
                    Dim sqlUpdateBal As String = "UPDATE Customers SET CurrentBalance = @NewBal, LastTransactionDate = GETDATE() WHERE CustomerID = @CID;"
                    Using cmdUp As New SqlCommand(sqlUpdateBal, con, trans)
                        cmdUp.Parameters.AddWithValue("@NewBal", newBalance)
                        cmdUp.Parameters.AddWithValue("@CID", inv.CustomerID.Value)
                        Await cmdUp.ExecuteNonQueryAsync()
                    End Using
                End If

                ' =========================================================================
                ' د) تسجيل حركة الطيار تلقائياً لو كان نوع الطلب دليفري
                ' =========================================================================
                If inv.OrderType = 3 AndAlso inv.DriverID.HasValue Then
                    Dim sqlDriverTrans As String = "
        INSERT INTO DriverTransactions 
        (TransactionDate, DriverID, InvoiceID, OrderTotal, DeliveryFee, CollectedAmount, IsSettled, ShiftID, UserID, Notes, CreatedAt)
        VALUES 
        (GETDATE(), @DriverID, @InvoiceID, @OrderTotal, @DeliveryFee, 0, 0, @ShiftID, @UserID, @Notes, GETDATE());"

                    Using cmdDriver As New SqlCommand(sqlDriverTrans, con, trans)
                        cmdDriver.Parameters.AddWithValue("@DriverID", inv.DriverID.Value)
                        cmdDriver.Parameters.AddWithValue("@InvoiceID", newInvoiceID)
                        cmdDriver.Parameters.AddWithValue("@OrderTotal", inv.NetTotal)     '  -- المبلغ الكلي للفاتورة المطلوب تحصيله
                        cmdDriver.Parameters.AddWithValue("@DeliveryFee", inv.DeliveryFee)  ' -- رسوم التوصيل المخصصة للطيار
                        cmdDriver.Parameters.AddWithValue("@ShiftID", inv.ShiftID)
                        cmdDriver.Parameters.AddWithValue("@UserID", inv.UserID)
                        cmdDriver.Parameters.AddWithValue("@Notes", "فاتورة دليفري رقم " & generatedNumber)
                        Await cmdDriver.ExecuteNonQueryAsync()
                    End Using
                End If

                ' =========================================================================
                ' هـ) تحديث إجماليات الوردية الحالية في جدول Shifts
                ' =========================================================================
                Dim sqlUpdateShift As String = "
                UPDATE Shifts SET 
                    TotalSales = ISNULL(TotalSales, 0) + @PaidCash,
                    TotalOrders = ISNULL(TotalOrders, 0) + 1
                WHERE ShiftID = @ShiftID;"

                Using cmdShift As New SqlCommand(sqlUpdateShift, con, trans)
                    cmdShift.Parameters.AddWithValue("@PaidCash", inv.PaidAmount) ' المبلغ النقدي الفعلي المحصل
                    cmdShift.Parameters.AddWithValue("@ShiftID", inv.ShiftID)
                    Await cmdShift.ExecuteNonQueryAsync()
                End Using

                ' و) تسجيل حركة الخزنة تلقائياً إذا كان هناك مبلغ مدفوع وخزينة محددة
                If inv.TreasuryID.HasValue AndAlso inv.TreasuryID.Value > 0 AndAlso inv.PaidAmount > 0 Then
                    Await TreasuryService.AddTransactionAsync(
                        treasuryID:=inv.TreasuryID.Value,
                        transactionType:=TreasuryTransactionTypes.Sale,
                        amount:=inv.PaidAmount,
                        isDeposit:=True,
                        referenceID:=newInvoiceID,
                        referenceNo:=generatedNumber,
                        notes:="مبيعات فاتورة رقم " & generatedNumber,
                        userID:=inv.UserID,
                        cn:=con,
                        trans:=trans
                    )
                End If

                trans.Commit()
                Return generatedNumber

            Catch ex As Exception
                Try : trans.Rollback() : Catch : End Try
                Throw
            End Try
        End Using
    End Function

    Public Function SaveInvoice(inv As InvoiceModel) As String
        Return Task.Run(Function() SaveInvoiceAsync(inv)).GetAwaiter().GetResult()
    End Function

    ' ==========================================
    ' 2. حفظ الفاتورة في الفواتير المعلقة
    ' ==========================================
    Public Function SavePendingInvoice(pending As PendingInvoiceModel) As Boolean
        Dim pendingNum As String = "PND-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")

        Dim sql As String = "
        INSERT INTO PendingInvoices 
        (PendingNumber, PendingDate, ShiftID, UserID, OrderType, CustomerID, CustomerName, TableID, TableName, DriverID, DriverName, DeliveryFee, InvoiceJSON, TotalAmount, Notes, IsActive)
        VALUES 
        (@Num, GETDATE(), @ShiftID, @UserID, @OrderType, @CustomerID, @CustomerName, @TableID, @TableName, @DriverID, @DriverName, @DeliveryFee, @JSON, @TotalAmount, @Notes, 1);
        SELECT SCOPE_IDENTITY();"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@Num", pendingNum)
                cmd.Parameters.AddWithValue("@ShiftID", pending.ShiftID)
                cmd.Parameters.AddWithValue("@UserID", pending.UserID)
                cmd.Parameters.AddWithValue("@OrderType", pending.OrderType)
                cmd.Parameters.AddWithValue("@CustomerID", If(pending.CustomerID.HasValue, pending.CustomerID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@CustomerName", If(String.IsNullOrEmpty(pending.CustomerName), DBNull.Value, pending.CustomerName))
                cmd.Parameters.AddWithValue("@TableID", If(pending.TableID.HasValue, pending.TableID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@TableName", If(String.IsNullOrEmpty(pending.TableName), DBNull.Value, pending.TableName))
                cmd.Parameters.AddWithValue("@DriverID", If(pending.DriverID.HasValue, pending.DriverID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@DriverName", If(String.IsNullOrEmpty(pending.DriverName), DBNull.Value, pending.DriverName))
                cmd.Parameters.AddWithValue("@DeliveryFee", pending.DeliveryFee)
                cmd.Parameters.AddWithValue("@JSON", pending.InvoiceJSON)
                cmd.Parameters.AddWithValue("@TotalAmount", pending.TotalAmount)
                cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(pending.Notes), DBNull.Value, pending.Notes))

                con.Open()
                Dim scalarResult = cmd.ExecuteScalar()
                If scalarResult IsNot Nothing AndAlso Not IsDBNull(scalarResult) Then
                    Dim newId = Convert.ToInt32(scalarResult)
                    pending.PendingID = newId
                    pending.PendingNumber = pendingNum
                    Return newId > 0
                End If
                Return False
            End Using
        End Using
    End Function

    ' ==========================================
    ' 3. جلب الفواتير المعلقة النشطة
    ' ==========================================
    Public Function GetPendingInvoices() As List(Of PendingInvoiceModel)
        Dim list As New List(Of PendingInvoiceModel)
        Dim sql As String = "SELECT * FROM PendingInvoices WHERE IsActive = 1 ORDER BY PendingID DESC;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        list.Add(New PendingInvoiceModel With {
                            .PendingID = Convert.ToInt32(rdr("PendingID")),
                            .PendingNumber = rdr("PendingNumber").ToString(),
                            .PendingDate = Convert.ToDateTime(rdr("PendingDate")),
                            .ShiftID = Convert.ToInt32(rdr("ShiftID")),
                            .UserID = Convert.ToInt32(rdr("UserID")),
                            .OrderType = Convert.ToByte(rdr("OrderType")),
                            .CustomerID = If(IsDBNull(rdr("CustomerID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("CustomerID"))),
                            .CustomerName = If(IsDBNull(rdr("CustomerName")), "", rdr("CustomerName").ToString()),
                            .TableID = If(IsDBNull(rdr("TableID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("TableID"))),
                            .TableName = If(IsDBNull(rdr("TableName")), "", rdr("TableName").ToString()),
                            .DriverID = If(IsDBNull(rdr("DriverID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("DriverID"))),
                            .DriverName = If(IsDBNull(rdr("DriverName")), "", rdr("DriverName").ToString()),
                            .DeliveryFee = Convert.ToDecimal(rdr("DeliveryFee")),
                            .InvoiceJSON = rdr("InvoiceJSON").ToString(),
                            .TotalAmount = Convert.ToDecimal(rdr("TotalAmount")),
                            .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString())
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ' ==========================================
    ' 4. حذف أو إغلاق الفاتورة المعلقة بعد استكمالها
    ' ==========================================
    Public Function DeletePendingInvoice(pendingID As Integer) As Boolean
        Dim sql As String = "UPDATE PendingInvoices SET IsActive = 0 WHERE PendingID = @ID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@ID", pendingID)
                con.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function


    ' 1. دالة جلب رقم الفاتورة التالي
    Public Function GetNextInvoiceNumber() As String
        Dim nextID As Integer = 1
        Dim sql As String = "SELECT ISNULL(MAX(TRY_CAST(InvoiceNumber AS INT)), 0) + 1 FROM SalesInvoices;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    nextID = Convert.ToInt32(obj)
                End If
            End Using
        End Using

        Return nextID.ToString()
    End Function

    ' 2. دالة تحديث حالة الطاولة (1 = متاحة, 2 = مشغولة)
    Public Sub UpdateTableStatus(tableID As Integer, status As Byte)
        Dim sql As String = "UPDATE RestaurantTables SET TableStatus = @Status WHERE TableID = @TableID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@Status", status)
                cmd.Parameters.AddWithValue("@TableID", tableID)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    ' 1. كشف حساب عميل مالي متقدم
    'Public Function GetCustomerStatement(customerID As Integer, fromDate As DateTime, toDate As DateTime) As DataTable
    '    Dim dt As New DataTable()
    '    Dim sql As String = "
    '    SELECT 
    '        TransactionID,
    '        TransactionDate,
    '        TransactionType,
    '        Debit,
    '        Credit,
    '        BalanceAfter,
    '        Notes
    '    FROM CustomerTransactions
    '    WHERE CustomerID = @CID 
    '      AND TransactionDate BETWEEN @FromDate AND @ToDate
    '    ORDER BY TransactionID ASC;"

    '    Using con As New SqlConnection(_ConnectionString)
    '        Using cmd As New SqlCommand(sql, con)
    '            cmd.Parameters.AddWithValue("@CID", customerID)
    '            cmd.Parameters.AddWithValue("@FromDate", fromDate.Date)
    '            cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1))
    '            Using da As New SqlDataAdapter(cmd)
    '                da.Fill(dt)
    '            End Using
    '        End Using
    '    End Using
    '    Return dt
    'End Function
    Public Function GetCustomerStatement(customerID As Integer, fromDate As DateTime, toDate As DateTime, Optional branchID As Integer = 0) As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "
        SELECT 
            ct.TransactionID,
            ct.TransactionDate,
            ISNULL(b.BranchName, N'-') AS BranchName,
            ct.TransactionType,
            ct.Debit,
            ct.Credit,
            ct.BalanceAfter,
            ct.Notes
        FROM CustomerTransactions ct
        LEFT JOIN Branches b ON ct.BranchID = b.BranchID
        WHERE ct.CustomerID = @CID 
          AND ct.TransactionDate BETWEEN @FromDate AND @ToDate "

        If branchID > 0 Then sql &= " AND ct.BranchID = @BranchID "

        sql &= " ORDER BY ct.TransactionID ASC;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@CID", customerID)
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date)
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1))
                If branchID > 0 Then cmd.Parameters.AddWithValue("@BranchID", branchID)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    ' 2. تقرير المبيعات المتقدم الشامل
    'Public Function GetSalesReport(fromDate As DateTime, toDate As DateTime, Optional orderType As Byte = 0, Optional shiftID As Integer = 0) As DataTable
    '    Dim dt As New DataTable()
    '    Dim sql As String = "
    '    SELECT 
    '        i.InvoiceID,
    '        i.InvoiceNumber,
    '        i.InvoiceDate,
    '        CASE i.OrderType WHEN 1 THEN N'تيك أوي' WHEN 2 THEN N'صالة' WHEN 3 THEN N'دليفري' ELSE N'أخرى' END AS OrderTypeName,
    '        ISNULL(c.CustomerName, N'عميل نقدي') AS CustomerName,
    '        ISNULL(t.TableName, N'-') AS TableName,
    '        ISNULL(d.DriverName, N'-') AS DriverName,
    '        i.DeliveryFee,
    '        i.TotalBeforeDiscount,
    '        i.DiscountAmount,
    '        i.NetTotal,
    '        i.PaidAmount,
    '        i.RemainingAmount,
    '        CASE WHEN i.IsCredit = 1 THEN N'آجل' ELSE N'نقدي' END AS PaymentType,
    '        s.ShiftNumber
    '    FROM SalesInvoices i
    '    LEFT JOIN Customers c ON i.CustomerID = c.CustomerID
    '    LEFT JOIN RestaurantTables t ON i.TableID = t.TableID
    '    LEFT JOIN DeliveryDrivers d ON i.DriverID = d.DriverID
    '    LEFT JOIN Shifts s ON i.ShiftID = s.ShiftID
    '    WHERE i.IsDeleted = 0 
    '      AND i.InvoiceDate BETWEEN @FromDate AND @ToDate "

    '    If orderType > 0 Then sql &= " AND i.OrderType = @OrderType "
    '    If shiftID > 0 Then sql &= " AND i.ShiftID = @ShiftID "

    '    sql &= " ORDER BY i.InvoiceID DESC;"

    '    Using con As New SqlConnection(_ConnectionString)
    '        Using cmd As New SqlCommand(sql, con)
    '            cmd.Parameters.AddWithValue("@FromDate", fromDate.Date)
    '            cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1))
    '            If orderType > 0 Then cmd.Parameters.AddWithValue("@OrderType", orderType)
    '            If shiftID > 0 Then cmd.Parameters.AddWithValue("@ShiftID", shiftID)
    '            Using da As New SqlDataAdapter(cmd)
    '                da.Fill(dt)
    '            End Using
    '        End Using
    '    End Using
    '    Return dt
    'End Function
    Public Function GetSalesReport(fromDate As DateTime, toDate As DateTime, Optional orderType As Byte = 0, Optional branchID As Integer = 0) As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "
        SELECT 
            i.InvoiceID,
            i.InvoiceNumber,
            i.InvoiceDate,
            ISNULL(b.BranchName, N'-') AS BranchName,
            ISNULL(st.StoreName, N'-') AS StoreName,
            CASE i.OrderType WHEN 1 THEN N'تيك أوي' WHEN 2 THEN N'صالة' WHEN 3 THEN N'دليفري' ELSE N'أخرى' END AS OrderTypeName,
            ISNULL(c.CustomerName, N'عميل نقدي') AS CustomerName,
            ISNULL(t.TableName, N'-') AS TableName,
            ISNULL(d.DriverName, N'-') AS DriverName,
            i.DeliveryFee,
            ISNULL(i.TotalBeforeDiscount, 0) AS TotalBeforeDiscount,
            ISNULL(i.DiscountAmount, 0) AS DiscountAmount,
            i.NetTotal,
            i.PaidAmount,
            i.RemainingAmount,
            CASE WHEN i.IsCredit = 1 THEN N'آجل' ELSE N'نقدي' END AS PaymentType,
            s.ShiftNumber
        FROM SalesInvoices i
        LEFT JOIN Branches b ON i.BranchID = b.BranchID
        LEFT JOIN Stores st ON i.StoreID = st.StoreID
        LEFT JOIN Customers c ON i.CustomerID = c.CustomerID
        LEFT JOIN RestaurantTables t ON i.TableID = t.TableID
        LEFT JOIN DeliveryDrivers d ON i.DriverID = d.DriverID
        LEFT JOIN Shifts s ON i.ShiftID = s.ShiftID
        WHERE i.IsDeleted = 0 
          AND i.InvoiceDate BETWEEN @FromDate AND @ToDate "

        If orderType > 0 Then sql &= " AND i.OrderType = @OrderType "
        If branchID > 0 Then sql &= " AND i.BranchID = @BranchID "

        sql &= " ORDER BY i.InvoiceID DESC;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date)
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1))
                If orderType > 0 Then cmd.Parameters.AddWithValue("@OrderType", orderType)
                If branchID > 0 Then cmd.Parameters.AddWithValue("@BranchID", branchID)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' 1. جلب تقرير حركات الطيارين مع الفلترة
    Public Function GetDriverTransactionsReport(driverID As Integer, fromDate As DateTime, toDate As DateTime, Optional isSettled As Integer = -1) As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "
        SELECT 
            dt.TransactionID,
            dt.TransactionDate,
            d.DriverName,
            d.Phone,
            i.InvoiceNumber,
            ISNULL(c.CustomerName, N'عميل دليفري') AS CustomerName,
            dt.OrderTotal,
            dt.DeliveryFee,
            CASE WHEN dt.IsSettled = 1 THEN N'تمت التصفية' ELSE N'معلق طرف الطيار' END AS SettleStatus,
            dt.SettledAt,
            s.ShiftNumber
        FROM DriverTransactions dt
        INNER JOIN DeliveryDrivers d ON dt.DriverID = d.DriverID
        INNER JOIN SalesInvoices i ON dt.InvoiceID = i.InvoiceID
        LEFT JOIN Customers c ON i.CustomerID = c.CustomerID
        LEFT JOIN Shifts s ON dt.ShiftID = s.ShiftID
        WHERE dt.TransactionDate BETWEEN @FromDate AND @ToDate "

        If driverID > 0 Then sql &= " AND dt.DriverID = @DriverID "
        If isSettled = 0 OrElse isSettled = 1 Then sql &= " AND dt.IsSettled = @IsSettled "

        sql &= " ORDER BY dt.TransactionID DESC;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date)
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1))
                If driverID > 0 Then cmd.Parameters.AddWithValue("@DriverID", driverID)
                If isSettled = 0 OrElse isSettled = 1 Then cmd.Parameters.AddWithValue("@IsSettled", isSettled)

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    ' 2. تصفية حساب الطيار (تسوية الأوردرات وتوريد المبالغ للدرج)
    Public Function SettleDriverOrders(driverID As Integer) As Boolean
        Dim sql As String = "
        UPDATE DriverTransactions 
        SET IsSettled = 1, SettledAt = GETDATE(), CollectedAmount = OrderTotal 
        WHERE DriverID = @DriverID AND IsSettled = 0;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@DriverID", driverID)
                con.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function


    ' جلب قائمة الفروع النشطة
    Public Function GetActiveBranches() As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "SELECT BranchID, BranchName FROM Branches WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY BranchName;"
        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' جلب قائمة المخازن النشطة
    Public Function GetActiveStores() As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "SELECT StoreID, StoreName FROM Stores WHERE IsActive = 1 AND (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY StoreName;"
        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' =========================================================
    ' جلب فاتورة مبيعات بالكامل برقم الفاتورة (لإعادة الطباعة أو المرتجع)
    ' =========================================================
    Public Function GetInvoiceByNumber(invoiceNumber As String) As InvoiceModel
        If String.IsNullOrWhiteSpace(invoiceNumber) Then Return Nothing

        Dim inv As InvoiceModel = Nothing
        Dim sqlHead As String = "
        SELECT 
            i.InvoiceID, i.InvoiceNumber, i.InvoiceDate, i.OrderType, i.ShiftID, i.UserID,
            i.CustomerID, i.TableID, i.DriverID, i.BranchID, i.StoreID, i.DeliveryFee,
            i.TotalBeforeDiscount, i.DiscountAmount, i.NetTotal, i.PaidAmount, i.RemainingAmount,
            i.IsCredit, i.TreasuryID, i.Notes
        FROM SalesInvoices i
        WHERE i.InvoiceNumber = @Num AND i.IsDeleted = 0;"

        Dim sqlDet As String = "
        SELECT 
            d.InvoiceDetailID, d.InvoiceID, d.ProductID, d.ProductName, d.SizeName,
            d.AddonsText, d.UnitPrice, d.Quantity, d.TotalPrice, d.Notes
        FROM SalesInvoiceDetails d
        WHERE d.InvoiceID = @InvID;"

        Using con As New SqlConnection(_ConnectionString)
            con.Open()
            Using cmdHead As New SqlCommand(sqlHead, con)
                cmdHead.Parameters.AddWithValue("@Num", invoiceNumber.Trim())
                Using rdr = cmdHead.ExecuteReader()
                    If rdr.Read() Then
                        inv = New InvoiceModel With {
                            .InvoiceID = Convert.ToInt32(rdr("InvoiceID")),
                            .InvoiceNumber = rdr("InvoiceNumber").ToString(),
                            .InvoiceDate = Convert.ToDateTime(rdr("InvoiceDate")),
                            .OrderType = Convert.ToByte(rdr("OrderType")),
                            .ShiftID = Convert.ToInt32(rdr("ShiftID")),
                            .UserID = Convert.ToInt32(rdr("UserID")),
                            .CustomerID = If(IsDBNull(rdr("CustomerID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("CustomerID"))),
                            .TableID = If(IsDBNull(rdr("TableID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("TableID"))),
                            .DriverID = If(IsDBNull(rdr("DriverID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("DriverID"))),
                            .DeliveryFee = Convert.ToDecimal(rdr("DeliveryFee")),
                            .TotalBeforeDiscount = Convert.ToDecimal(rdr("TotalBeforeDiscount")),
                            .DiscountAmount = Convert.ToDecimal(rdr("DiscountAmount")),
                            .NetTotal = Convert.ToDecimal(rdr("NetTotal")),
                            .PaidAmount = Convert.ToDecimal(rdr("PaidAmount")),
                            .RemainingAmount = Convert.ToDecimal(rdr("RemainingAmount")),
                            .IsCredit = Convert.ToBoolean(rdr("IsCredit")),
                            .TreasuryID = If(IsDBNull(rdr("TreasuryID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("TreasuryID"))),
                            .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString())
                        }
                    End If
                End Using
            End Using

            If inv IsNot Nothing Then
                Using cmdDet As New SqlCommand(sqlDet, con)
                    cmdDet.Parameters.AddWithValue("@InvID", inv.InvoiceID)
                    Using rdrDet = cmdDet.ExecuteReader()
                        While rdrDet.Read()
                            inv.Details.Add(New InvoiceDetailModel With {
                                .DetailID = Convert.ToInt32(rdrDet("InvoiceDetailID")),
                                .InvoiceID = Convert.ToInt32(rdrDet("InvoiceID")),
                                .ProductID = Convert.ToInt32(rdrDet("ProductID")),
                                .ProductName = rdrDet("ProductName").ToString(),
                                .SizeName = If(IsDBNull(rdrDet("SizeName")), "", rdrDet("SizeName").ToString()),
                                .AddonsText = If(IsDBNull(rdrDet("AddonsText")), "", rdrDet("AddonsText").ToString()),
                                .UnitPrice = Convert.ToDecimal(rdrDet("UnitPrice")),
                                .Quantity = Convert.ToInt32(rdrDet("Quantity")),
                                .TotalPrice = Convert.ToDecimal(rdrDet("TotalPrice")),
                                .Notes = If(IsDBNull(rdrDet("Notes")), "", rdrDet("Notes").ToString())
                            })
                        End While
                    End Using
                End Using
            End If
        End Using

        Return inv
    End Function

    ' =========================================================
    ' جلب الفاتورة المعلقة النشطة لطاولة محددة
    ' =========================================================
    Public Function GetPendingInvoiceByTableID(tableID As Integer) As PendingInvoiceModel
        Dim pending As PendingInvoiceModel = Nothing
        Dim sql As String = "SELECT TOP 1 * FROM PendingInvoices WHERE TableID = @TID AND IsActive = 1 ORDER BY PendingID DESC;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@TID", tableID)
                con.Open()
                Using rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        pending = New PendingInvoiceModel With {
                            .PendingID = Convert.ToInt32(rdr("PendingID")),
                            .PendingNumber = rdr("PendingNumber").ToString(),
                            .PendingDate = Convert.ToDateTime(rdr("PendingDate")),
                            .ShiftID = Convert.ToInt32(rdr("ShiftID")),
                            .UserID = Convert.ToInt32(rdr("UserID")),
                            .OrderType = Convert.ToByte(rdr("OrderType")),
                            .CustomerID = If(IsDBNull(rdr("CustomerID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("CustomerID"))),
                            .CustomerName = If(IsDBNull(rdr("CustomerName")), "", rdr("CustomerName").ToString()),
                            .TableID = Convert.ToInt32(rdr("TableID")),
                            .TableName = If(IsDBNull(rdr("TableName")), "", rdr("TableName").ToString()),
                            .DriverID = If(IsDBNull(rdr("DriverID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("DriverID"))),
                            .DriverName = If(IsDBNull(rdr("DriverName")), "", rdr("DriverName").ToString()),
                            .DeliveryFee = Convert.ToDecimal(rdr("DeliveryFee")),
                            .InvoiceJSON = rdr("InvoiceJSON").ToString(),
                            .TotalAmount = Convert.ToDecimal(rdr("TotalAmount")),
                            .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString())
                        }
                    End If
                End Using
            End Using
        End Using

        Return pending
    End Function

    ' =========================================================
    ' نقل طاولة مشغولة إلى طاولة أخرى شاغرة
    ' =========================================================
    Public Function TransferTable(fromTableID As Integer, toTableID As Integer, toTableName As String) As Boolean
        Dim sqlTransfer As String = "
        UPDATE PendingInvoices 
        SET TableID = @ToTID, TableName = @ToTName 
        WHERE TableID = @FromTID AND IsActive = 1;

        UPDATE RestaurantTables SET TableStatus = 1 WHERE TableID = @FromTID;
        UPDATE RestaurantTables SET TableStatus = 2 WHERE TableID = @ToTID;"

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand(sqlTransfer, con)
                cmd.Parameters.AddWithValue("@FromTID", fromTableID)
                cmd.Parameters.AddWithValue("@ToTID", toTableID)
                cmd.Parameters.AddWithValue("@ToTName", toTableName)
                con.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' =========================================================
    ' جلب تعيينات طابعات الأقسام (المطبخ / البار)
    ' =========================================================
    Public Function GetCategoryPrinters() As Dictionary(Of Integer, String)
        Dim dict As New Dictionary(Of Integer, String)
        Dim sql As String = "
        SELECT c.Category_ID, p.TargetPrinter 
        FROM Categories c 
        INNER JOIN Printers p ON c.PrinterID = p.PrinterID 
        WHERE c.IsActive = 1 AND p.IsActive = 1;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    con.Open()
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim catID = Convert.ToInt32(rdr("Category_ID"))
                            Dim prnName = rdr("TargetPrinter").ToString()
                            dict(catID) = prnName
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("GetCategoryPrinters error: " & ex.Message)
        End Try

        Return dict
    End Function

    ' =========================================================
    ' جلب رقم آخر فاتورة مبيعات تم حفظها في النظام
    ' =========================================================
    Public Function GetLastSavedInvoiceNumber() As String
        Dim sql As String = "SELECT TOP 1 InvoiceNumber FROM SalesInvoices WHERE (IsDeleted = 0 OR IsDeleted IS NULL) ORDER BY TRY_CAST(InvoiceNumber AS INT) DESC, InvoiceID DESC;"
        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    con.Open()
                    Dim obj = cmd.ExecuteScalar()
                    If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                        Return obj.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("GetLastSavedInvoiceNumber error: " & ex.Message)
        End Try
        Return ""
    End Function

    ' =========================================================
    ' 4. إدارة شاشة المطبخ الذكية (KDS - Kitchen Display System)
    ' =========================================================

    Private Shared _kdsTablesChecked As Boolean = False
    Private Shared ReadOnly _kdsInitLock As New Object()

    Public Sub EnsureKDSTablesCreated()
        If _kdsTablesChecked Then Return
        SyncLock _kdsInitLock
            If _kdsTablesChecked Then Return
            Try
                Dim ddl As String = "
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KitchenOrders')
                BEGIN
                    CREATE TABLE KitchenOrders (
                        KitchenOrderID INT IDENTITY(1,1) PRIMARY KEY,
                        OrderNumber NVARCHAR(50) NOT NULL,
                        OrderType TINYINT NOT NULL DEFAULT 1,
                        TableID INT NULL,
                        TableName NVARCHAR(100) NULL,
                        CustomerName NVARCHAR(150) NULL,
                        ServerName NVARCHAR(100) NULL,
                        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
                        Status TINYINT NOT NULL DEFAULT 0,
                        PreparationStartedAt DATETIME NULL,
                        ReadyAt DATETIME NULL,
                        CompletedAt DATETIME NULL,
                        Notes NVARCHAR(500) NULL
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KitchenOrderDetails')
                BEGIN
                    CREATE TABLE KitchenOrderDetails (
                        DetailID INT IDENTITY(1,1) PRIMARY KEY,
                        KitchenOrderID INT NOT NULL CONSTRAINT FK_KOD_KO REFERENCES KitchenOrders(KitchenOrderID) ON DELETE CASCADE,
                        ProductID INT NOT NULL,
                        ProductName NVARCHAR(200) NOT NULL,
                        SizeName NVARCHAR(100) NULL,
                        AddonsText NVARCHAR(500) NULL,
                        Quantity INT NOT NULL DEFAULT 1,
                        Notes NVARCHAR(500) NULL,
                        IsCompleted BIT NOT NULL DEFAULT 0,
                        StationName NVARCHAR(100) NULL
                    );
                END;"

                Using con As New SqlConnection(_ConnectionString)
                    Using cmd As New SqlCommand(ddl, con)
                        con.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                _kdsTablesChecked = True
            Catch ex As Exception
                Debug.WriteLine("EnsureKDSTablesCreated error: " & ex.Message)
            End Try
        End SyncLock
    End Sub

    Public Async Function CreateKitchenOrderAsync(order As KitchenOrderModel) As Task(Of Integer)
        EnsureKDSTablesCreated()
        Try
            Using con As New SqlConnection(_ConnectionString)
                Await con.OpenAsync()

                ' إلغاء أي طلب نشط مسبق لنفس الطاولة تجنباً للتكرار عند تعديل الطلب
                If order.TableID.HasValue AndAlso order.TableID.Value > 0 Then
                    Dim cancelOldSql As String = "UPDATE KitchenOrders SET Status = 4 WHERE TableID = @TID AND Status IN (0, 1);"
                    Using cmdOld As New SqlCommand(cancelOldSql, con)
                        cmdOld.Parameters.AddWithValue("@TID", order.TableID.Value)
                        Await cmdOld.ExecuteNonQueryAsync()
                    End Using
                End If

                Dim sqlOrder As String = "
                INSERT INTO KitchenOrders 
                (OrderNumber, OrderType, TableID, TableName, CustomerName, ServerName, CreatedAt, Status, Notes)
                VALUES 
                (@OrderNumber, @OrderType, @TableID, @TableName, @CustomerName, @ServerName, GETDATE(), @Status, @Notes);
                SELECT SCOPE_IDENTITY();"

                Dim newOrderID As Integer = 0
                Using cmd As New SqlCommand(sqlOrder, con)
                    cmd.Parameters.AddWithValue("@OrderNumber", If(String.IsNullOrEmpty(order.OrderNumber), GetNextCode("KitchenOrders", "OrderNumber").ToString(), order.OrderNumber))
                    cmd.Parameters.AddWithValue("@OrderType", order.OrderType)
                    cmd.Parameters.AddWithValue("@TableID", If(order.TableID.HasValue, order.TableID.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@TableName", If(String.IsNullOrEmpty(order.TableName), DBNull.Value, order.TableName))
                    cmd.Parameters.AddWithValue("@CustomerName", If(String.IsNullOrEmpty(order.CustomerName), DBNull.Value, order.CustomerName))
                    cmd.Parameters.AddWithValue("@ServerName", If(String.IsNullOrEmpty(order.ServerName), DBNull.Value, order.ServerName))
                    cmd.Parameters.AddWithValue("@Status", CByte(order.Status))
                    cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(order.Notes), DBNull.Value, order.Notes))

                    Dim obj = Await cmd.ExecuteScalarAsync()
                    newOrderID = Convert.ToInt32(obj)
                End Using

                If newOrderID > 0 AndAlso order.Items IsNot Nothing AndAlso order.Items.Count > 0 Then
                    Dim sqlItem As String = "
                    INSERT INTO KitchenOrderDetails 
                    (KitchenOrderID, ProductID, ProductName, SizeName, AddonsText, Quantity, Notes, IsCompleted, StationName)
                    VALUES 
                    (@KitchenOrderID, @ProductID, @ProductName, @SizeName, @AddonsText, @Quantity, @Notes, 0, @StationName);"

                    For Each itm In order.Items
                        Using cmdItem As New SqlCommand(sqlItem, con)
                            cmdItem.Parameters.AddWithValue("@KitchenOrderID", newOrderID)
                            cmdItem.Parameters.AddWithValue("@ProductID", itm.ProductID)
                            cmdItem.Parameters.AddWithValue("@ProductName", itm.ProductName)
                            cmdItem.Parameters.AddWithValue("@SizeName", If(String.IsNullOrEmpty(itm.SizeName), DBNull.Value, itm.SizeName))
                            cmdItem.Parameters.AddWithValue("@AddonsText", If(String.IsNullOrEmpty(itm.AddonsText), DBNull.Value, itm.AddonsText))
                            cmdItem.Parameters.AddWithValue("@Quantity", itm.Quantity)
                            cmdItem.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(itm.Notes), DBNull.Value, itm.Notes))
                            cmdItem.Parameters.AddWithValue("@StationName", If(String.IsNullOrEmpty(itm.StationName), DBNull.Value, itm.StationName))

                            Await cmdItem.ExecuteNonQueryAsync()
                        End Using
                    Next
                End If

                Return newOrderID
            End Using
        Catch ex As Exception
            Logger.LogError("CreateKitchenOrderAsync", ex)
            Return 0
        End Try
    End Function

    Public Function GetActiveKitchenOrders(Optional filterOrderType As Byte = 0, Optional stationFilter As String = "") As List(Of KitchenOrderModel)
        EnsureKDSTablesCreated()
        Dim orders As New List(Of KitchenOrderModel)

        Dim sql As String = "
        SELECT 
            o.KitchenOrderID, o.OrderNumber, o.OrderType, o.TableID, o.TableName, 
            o.CustomerName, o.ServerName, o.CreatedAt, o.Status, 
            o.PreparationStartedAt, o.ReadyAt, o.CompletedAt, o.Notes
        FROM KitchenOrders o
        WHERE o.Status IN (0, 1, 2) "

        If filterOrderType > 0 Then
            sql &= " AND o.OrderType = " & filterOrderType
        End If

        sql &= " ORDER BY o.CreatedAt ASC;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    con.Open()
                    Using rdr As SqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim ko As New KitchenOrderModel With {
                                .KitchenOrderID = Convert.ToInt32(rdr("KitchenOrderID")),
                                .OrderNumber = rdr("OrderNumber").ToString(),
                                .OrderType = Convert.ToByte(rdr("OrderType")),
                                .TableID = If(IsDBNull(rdr("TableID")), Nothing, Convert.ToInt32(rdr("TableID"))),
                                .TableName = If(IsDBNull(rdr("TableName")), "", rdr("TableName").ToString()),
                                .CustomerName = If(IsDBNull(rdr("CustomerName")), "", rdr("CustomerName").ToString()),
                                .ServerName = If(IsDBNull(rdr("ServerName")), "", rdr("ServerName").ToString()),
                                .CreatedAt = Convert.ToDateTime(rdr("CreatedAt")),
                                .Status = CType(Convert.ToByte(rdr("Status")), KitchenOrderStatus),
                                .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString())
                            }
                            If Not IsDBNull(rdr("PreparationStartedAt")) Then ko.PreparationStartedAt = Convert.ToDateTime(rdr("PreparationStartedAt"))
                            If Not IsDBNull(rdr("ReadyAt")) Then ko.ReadyAt = Convert.ToDateTime(rdr("ReadyAt"))
                            If Not IsDBNull(rdr("CompletedAt")) Then ko.CompletedAt = Convert.ToDateTime(rdr("CompletedAt"))

                            orders.Add(ko)
                        End While
                    End Using
                End Using

                If orders.Count > 0 Then
                    Dim idList As String = String.Join(",", orders.Select(Function(x) x.KitchenOrderID))
                    Dim sqlDetails As String = $"
                    SELECT d.DetailID, d.KitchenOrderID, d.ProductID, d.ProductName, d.SizeName, d.AddonsText, d.Quantity, d.Notes, d.IsCompleted, d.StationName,
                           p.PreparationTime
                    FROM KitchenOrderDetails d
                    LEFT JOIN Products p ON p.Product_ID = d.ProductID
                    WHERE d.KitchenOrderID IN ({idList})
                    ORDER BY d.DetailID ASC;"

                    Using cmdDet As New SqlCommand(sqlDetails, con)
                        Using rdrDet As SqlDataReader = cmdDet.ExecuteReader()
                            While rdrDet.Read()
                                Dim kId As Integer = Convert.ToInt32(rdrDet("KitchenOrderID"))
                                Dim parent = orders.FirstOrDefault(Function(x) x.KitchenOrderID = kId)
                                If parent IsNot Nothing Then
                                    Dim item As New KitchenOrderItemModel With {
                                        .DetailID = Convert.ToInt32(rdrDet("DetailID")),
                                        .KitchenOrderID = kId,
                                        .ProductID = Convert.ToInt32(rdrDet("ProductID")),
                                        .ProductName = rdrDet("ProductName").ToString(),
                                        .SizeName = If(IsDBNull(rdrDet("SizeName")), "", rdrDet("SizeName").ToString()),
                                        .AddonsText = If(IsDBNull(rdrDet("AddonsText")), "", rdrDet("AddonsText").ToString()),
                                        .Quantity = Convert.ToInt32(rdrDet("Quantity")),
                                        .Notes = If(IsDBNull(rdrDet("Notes")), "", rdrDet("Notes").ToString()),
                                        .IsCompleted = Convert.ToBoolean(rdrDet("IsCompleted")),
                                        .StationName = If(IsDBNull(rdrDet("StationName")), "", rdrDet("StationName").ToString())
                                    }

                                    If Not IsDBNull(rdrDet("PreparationTime")) Then
                                        Dim val = rdrDet("PreparationTime")
                                        If TypeOf val Is TimeSpan Then
                                            item.PreparationTime = DirectCast(val, TimeSpan)
                                        ElseIf TypeOf val Is DateTime Then
                                            item.PreparationTime = DirectCast(val, DateTime).TimeOfDay
                                        Else
                                            Dim tsParsed As TimeSpan
                                            If TimeSpan.TryParse(val.ToString(), tsParsed) Then
                                                item.PreparationTime = tsParsed
                                            End If
                                        End If
                                    End If

                                    If String.IsNullOrEmpty(stationFilter) OrElse stationFilter = "الكل" OrElse item.StationName = stationFilter Then
                                        parent.Items.Add(item)
                                    End If
                                End If
                            End While
                        End Using
                    End Using

                    If Not String.IsNullOrEmpty(stationFilter) AndAlso stationFilter <> "الكل" Then
                        orders.RemoveAll(Function(o) o.Items.Count = 0)
                    End If
                End If
            End Using
        Catch ex As Exception
            Logger.LogError("GetActiveKitchenOrders", ex)
        End Try

        Return orders
    End Function

    Public Function UpdateKitchenOrderStatus(kitchenOrderID As Integer, newStatus As KitchenOrderStatus) As Boolean
        EnsureKDSTablesCreated()
        Dim sql As String = "UPDATE KitchenOrders SET Status = @Status "
        If newStatus = KitchenOrderStatus.Preparing Then
            sql &= ", PreparationStartedAt = ISNULL(PreparationStartedAt, GETDATE()) "
        ElseIf newStatus = KitchenOrderStatus.Ready Then
            sql &= ", ReadyAt = GETDATE() "
        ElseIf newStatus = KitchenOrderStatus.Bumped Then
            sql &= ", CompletedAt = GETDATE() "
        End If
        sql &= " WHERE KitchenOrderID = @ID;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@Status", CByte(newStatus))
                    cmd.Parameters.AddWithValue("@ID", kitchenOrderID)
                    con.Open()
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("UpdateKitchenOrderStatus", ex)
            Return False
        End Try
    End Function

    Public Function ToggleKitchenItemStatus(detailID As Integer, isCompleted As Boolean) As Boolean
        EnsureKDSTablesCreated()
        Dim sql As String = "UPDATE KitchenOrderDetails SET IsCompleted = @IsComp WHERE DetailID = @ID;"
        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@IsComp", isCompleted)
                    cmd.Parameters.AddWithValue("@ID", detailID)
                    con.Open()
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("ToggleKitchenItemStatus", ex)
            Return False
        End Try
    End Function

    Public Function GetRecentBumpedOrders(Optional limit As Integer = 30) As List(Of KitchenOrderModel)
        EnsureKDSTablesCreated()
        Dim orders As New List(Of KitchenOrderModel)
        Dim sql As String = $"
        SELECT TOP {limit}
            o.KitchenOrderID, o.OrderNumber, o.OrderType, o.TableID, o.TableName, 
            o.CustomerName, o.ServerName, o.CreatedAt, o.Status, 
            o.PreparationStartedAt, o.ReadyAt, o.CompletedAt, o.Notes
        FROM KitchenOrders o
        WHERE o.Status = 3
        ORDER BY o.CompletedAt DESC;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    con.Open()
                    Using rdr As SqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim ko As New KitchenOrderModel With {
                                .KitchenOrderID = Convert.ToInt32(rdr("KitchenOrderID")),
                                .OrderNumber = rdr("OrderNumber").ToString(),
                                .OrderType = Convert.ToByte(rdr("OrderType")),
                                .TableID = If(IsDBNull(rdr("TableID")), Nothing, Convert.ToInt32(rdr("TableID"))),
                                .TableName = If(IsDBNull(rdr("TableName")), "", rdr("TableName").ToString()),
                                .CustomerName = If(IsDBNull(rdr("CustomerName")), "", rdr("CustomerName").ToString()),
                                .ServerName = If(IsDBNull(rdr("ServerName")), "", rdr("ServerName").ToString()),
                                .CreatedAt = Convert.ToDateTime(rdr("CreatedAt")),
                                .Status = CType(Convert.ToByte(rdr("Status")), KitchenOrderStatus),
                                .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString())
                            }
                            If Not IsDBNull(rdr("CompletedAt")) Then ko.CompletedAt = Convert.ToDateTime(rdr("CompletedAt"))
                            orders.Add(ko)
                        End While
                    End Using
                End Using

                If orders.Count > 0 Then
                    Dim idList As String = String.Join(",", orders.Select(Function(x) x.KitchenOrderID))
                    Dim sqlDetails As String = $"
                    SELECT d.DetailID, d.KitchenOrderID, d.ProductID, d.ProductName, d.SizeName, d.AddonsText, d.Quantity, d.Notes, d.IsCompleted, d.StationName,
                           p.PreparationTime
                    FROM KitchenOrderDetails d
                    LEFT JOIN Products p ON p.Product_ID = d.ProductID
                    WHERE d.KitchenOrderID IN ({idList})
                    ORDER BY d.DetailID ASC;"

                    Using cmdDet As New SqlCommand(sqlDetails, con)
                        Using rdrDet As SqlDataReader = cmdDet.ExecuteReader()
                            While rdrDet.Read()
                                Dim kId As Integer = Convert.ToInt32(rdrDet("KitchenOrderID"))
                                Dim parent = orders.FirstOrDefault(Function(x) x.KitchenOrderID = kId)
                                If parent IsNot Nothing Then
                                    Dim item As New KitchenOrderItemModel With {
                                        .DetailID = Convert.ToInt32(rdrDet("DetailID")),
                                        .KitchenOrderID = kId,
                                        .ProductID = Convert.ToInt32(rdrDet("ProductID")),
                                        .ProductName = rdrDet("ProductName").ToString(),
                                        .SizeName = If(IsDBNull(rdrDet("SizeName")), "", rdrDet("SizeName").ToString()),
                                        .AddonsText = If(IsDBNull(rdrDet("AddonsText")), "", rdrDet("AddonsText").ToString()),
                                        .Quantity = Convert.ToInt32(rdrDet("Quantity")),
                                        .Notes = If(IsDBNull(rdrDet("Notes")), "", rdrDet("Notes").ToString()),
                                        .IsCompleted = Convert.ToBoolean(rdrDet("IsCompleted")),
                                        .StationName = If(IsDBNull(rdrDet("StationName")), "", rdrDet("StationName").ToString())
                                    }

                                    If Not IsDBNull(rdrDet("PreparationTime")) Then
                                        Dim val = rdrDet("PreparationTime")
                                        If TypeOf val Is TimeSpan Then
                                            item.PreparationTime = DirectCast(val, TimeSpan)
                                        ElseIf TypeOf val Is DateTime Then
                                            item.PreparationTime = DirectCast(val, DateTime).TimeOfDay
                                        Else
                                            Dim tsParsed As TimeSpan
                                            If TimeSpan.TryParse(val.ToString(), tsParsed) Then
                                                item.PreparationTime = tsParsed
                                            End If
                                        End If
                                    End If

                                    parent.Items.Add(item)
                                End If
                            End While
                        End Using
                    End Using
                End If
            End Using
        Catch ex As Exception
            Logger.LogError("GetRecentBumpedOrders", ex)
        End Try
        Return orders
    End Function

    Public Function RecallKitchenOrder(kitchenOrderID As Integer) As Boolean
        EnsureKDSTablesCreated()
        Dim sql As String = "UPDATE KitchenOrders SET Status = 1, CompletedAt = NULL WHERE KitchenOrderID = @ID;"
        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@ID", kitchenOrderID)
                    con.Open()
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("RecallKitchenOrder", ex)
            Return False
        End Try
    End Function

    ' =========================================================
    ' 5. إدارة الهالك والتالف وتكلفة الوجبات (Kitchen Waste & Costing)
    ' =========================================================

    Private Shared _wasteTablesChecked As Boolean = False
    Private Shared ReadOnly _wasteInitLock As New Object()

    Public Sub EnsureWasteTablesCreated()
        If _wasteTablesChecked Then Return
        SyncLock _wasteInitLock
            If _wasteTablesChecked Then Return
            Try
                Dim ddl As String = "
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KitchenWaste')
                BEGIN
                    CREATE TABLE KitchenWaste (
                        WasteID INT IDENTITY(1,1) PRIMARY KEY,
                        WasteNumber NVARCHAR(50) NOT NULL,
                        WasteDate DATETIME NOT NULL DEFAULT GETDATE(),
                        WasteType TINYINT NOT NULL DEFAULT 1,
                        StoreID INT NOT NULL DEFAULT 1,
                        TotalLossAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
                        ShiftID INT NULL,
                        UserID INT NOT NULL DEFAULT 1,
                        ResponsibleStaffName NVARCHAR(150) NULL,
                        Reason NVARCHAR(500) NULL,
                        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KitchenWasteDetails')
                BEGIN
                    CREATE TABLE KitchenWasteDetails (
                        DetailID INT IDENTITY(1,1) PRIMARY KEY,
                        WasteID INT NOT NULL CONSTRAINT FK_KWD_KW REFERENCES KitchenWaste(WasteID) ON DELETE CASCADE,
                        MaterialID INT NULL,
                        ProductID INT NULL,
                        ItemName NVARCHAR(200) NOT NULL,
                        Quantity DECIMAL(18,4) NOT NULL DEFAULT 1,
                        UnitName NVARCHAR(50) NULL,
                        UnitCost DECIMAL(18,2) NOT NULL DEFAULT 0,
                        TotalCost DECIMAL(18,2) NOT NULL DEFAULT 0,
                        Notes NVARCHAR(500) NULL
                    );
                END;"

                Using con As New SqlConnection(_ConnectionString)
                    Using cmd As New SqlCommand(ddl, con)
                        con.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                _wasteTablesChecked = True
            Catch ex As Exception
                Debug.WriteLine("EnsureWasteTablesCreated error: " & ex.Message)
            End Try
        End SyncLock
    End Sub

    Public Async Function SaveKitchenWasteAsync(waste As KitchenWasteModel) As Task(Of Boolean)
        EnsureWasteTablesCreated()
        Dim genNumber As String = "WST-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")

        Dim sqlMaster As String = "
        INSERT INTO KitchenWaste 
        (WasteNumber, WasteDate, WasteType, StoreID, TotalLossAmount, ShiftID, UserID, ResponsibleStaffName, Reason, CreatedAt)
        VALUES 
        (@WasteNumber, @WasteDate, @WasteType, @StoreID, @TotalLossAmount, @ShiftID, @UserID, @ResponsibleStaffName, @Reason, GETDATE());
        SELECT SCOPE_IDENTITY();"

        Dim sqlDetail As String = "
        INSERT INTO KitchenWasteDetails 
        (WasteID, MaterialID, ProductID, ItemName, Quantity, UnitName, UnitCost, TotalCost, Notes)
        VALUES 
        (@WasteID, @MaterialID, @ProductID, @ItemName, @Quantity, @UnitName, @UnitCost, @TotalCost, @Notes);"

        Using con As New SqlConnection(_ConnectionString)
            Await con.OpenAsync()
            Dim trans As SqlTransaction = con.BeginTransaction()

            Try
                Dim newWasteID As Integer = 0
                Using cmdM As New SqlCommand(sqlMaster, con, trans)
                    cmdM.Parameters.AddWithValue("@WasteNumber", genNumber)
                    cmdM.Parameters.AddWithValue("@WasteDate", waste.WasteDate)
                    cmdM.Parameters.AddWithValue("@WasteType", CByte(waste.WasteType))
                    cmdM.Parameters.AddWithValue("@StoreID", waste.StoreID)
                    cmdM.Parameters.AddWithValue("@TotalLossAmount", waste.TotalLossAmount)
                    cmdM.Parameters.AddWithValue("@ShiftID", If(waste.ShiftID.HasValue, waste.ShiftID.Value, DBNull.Value))
                    cmdM.Parameters.AddWithValue("@UserID", waste.UserID)
                    cmdM.Parameters.AddWithValue("@ResponsibleStaffName", If(String.IsNullOrEmpty(waste.ResponsibleStaffName), DBNull.Value, waste.ResponsibleStaffName))
                    cmdM.Parameters.AddWithValue("@Reason", If(String.IsNullOrEmpty(waste.Reason), DBNull.Value, waste.Reason))

                    Dim objId = Await cmdM.ExecuteScalarAsync()
                    newWasteID = Convert.ToInt32(objId)
                End Using

                For Each det In waste.Details
                    Using cmdD As New SqlCommand(sqlDetail, con, trans)
                        cmdD.Parameters.AddWithValue("@WasteID", newWasteID)
                        cmdD.Parameters.AddWithValue("@MaterialID", If(det.MaterialID.HasValue, det.MaterialID.Value, DBNull.Value))
                        cmdD.Parameters.AddWithValue("@ProductID", If(det.ProductID.HasValue, det.ProductID.Value, DBNull.Value))
                        cmdD.Parameters.AddWithValue("@ItemName", det.ItemName)
                        cmdD.Parameters.AddWithValue("@Quantity", det.Quantity)
                        cmdD.Parameters.AddWithValue("@UnitName", If(String.IsNullOrEmpty(det.UnitName), DBNull.Value, det.UnitName))
                        cmdD.Parameters.AddWithValue("@UnitCost", det.UnitCost)
                        cmdD.Parameters.AddWithValue("@TotalCost", det.TotalCost)
                        cmdD.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(det.Notes), DBNull.Value, det.Notes))

                        Await cmdD.ExecuteNonQueryAsync()
                    End Using

                    ' خصم الخامات من المخزن إن كانت خامة مسجلة
                    If det.MaterialID.HasValue AndAlso det.MaterialID.Value > 0 Then
                        Dim sqlStockDeduct As String = "
                        IF NOT EXISTS (SELECT 1 FROM StoreStock WHERE StoreID = @StoreID AND MaterialID = @MaterialID)
                            INSERT INTO StoreStock (StoreID, MaterialID, CurrentStock) VALUES (@StoreID, @MaterialID, -@Qty);
                        ELSE
                            UPDATE StoreStock SET CurrentStock = CurrentStock - @Qty WHERE StoreID = @StoreID AND MaterialID = @MaterialID;

                        INSERT INTO StockMovements (StoreID, MaterialID, MovementType, Quantity, ReferenceID, CreatedDate)
                        VALUES (@StoreID, @MaterialID, 'WASTE', -@Qty, @Ref, GETDATE());"

                        Using cmdStock As New SqlCommand(sqlStockDeduct, con, trans)
                            cmdStock.Parameters.AddWithValue("@StoreID", waste.StoreID)
                            cmdStock.Parameters.AddWithValue("@MaterialID", det.MaterialID.Value)
                            cmdStock.Parameters.AddWithValue("@Qty", det.Quantity)
                            cmdStock.Parameters.AddWithValue("@Ref", genNumber)
                            Await cmdStock.ExecuteNonQueryAsync()
                        End Using
                    ElseIf det.ProductID.HasValue AndAlso det.ProductID.Value > 0 Then
                        ' إذا تم إتلاف وجبة كاملة، خصم مكونات ريسيبي الوجبة تلقائياً من المخزن
                        Try
                            InventoryDeductionManager.DeductItemRecipe(con, trans, waste.StoreID, det.ProductID.Value, Nothing, Nothing, det.Quantity, genNumber & "-WASTE")
                        Catch exRec As Exception
                            Debug.WriteLine("Deduct recipe on meal waste error: " & exRec.Message)
                        End Try
                    End If
                Next

                trans.Commit()
                waste.WasteNumber = genNumber
                waste.WasteID = newWasteID
                Return True

            Catch ex As Exception
                trans.Rollback()
                Logger.LogError("SaveKitchenWasteAsync", ex)
                Return False
            End Try
        End Using
    End Function

    Public Function GetKitchenWasteReport(fromDate As DateTime, toDate As DateTime, Optional storeID As Integer = 0, Optional wasteType As Byte = 0) As DataTable
        EnsureWasteTablesCreated()
        Dim dt As New DataTable()
        Dim sql As String = "
        SELECT 
            w.WasteID,
            w.WasteNumber,
            w.WasteDate,
            CASE w.WasteType 
                WHEN 1 THEN N'خامة تالفة / تالف إعداد'
                WHEN 2 THEN N'سوء إعداد / خطأ طهي'
                WHEN 3 THEN N'انتهاء صلاحية'
                WHEN 4 THEN N'وجبة تالفة'
                ELSE N'أخرى' 
            END AS WasteTypeName,
            ISNULL(s.StoreName, N'-') AS StoreName,
            w.TotalLossAmount,
            ISNULL(w.ResponsibleStaffName, N'-') AS ResponsibleStaffName,
            ISNULL(w.Reason, N'-') AS Reason,
            (SELECT COUNT(1) FROM KitchenWasteDetails d WHERE d.WasteID = w.WasteID) AS ItemsCount
        FROM KitchenWaste w
        LEFT JOIN Stores s ON w.StoreID = s.StoreID
        WHERE w.WasteDate BETWEEN @FromDate AND @ToDate "

        If storeID > 0 Then sql &= " AND w.StoreID = @StoreID "
        If wasteType > 0 Then sql &= " AND w.WasteType = @WasteType "

        sql &= " ORDER BY w.WasteID DESC;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date)
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1))
                    If storeID > 0 Then cmd.Parameters.AddWithValue("@StoreID", storeID)
                    If wasteType > 0 Then cmd.Parameters.AddWithValue("@WasteType", wasteType)

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("GetKitchenWasteReport", ex)
        End Try

        Return dt
    End Function

    Public Function GetRawMaterialsWithStock(storeID As Integer) As DataTable
        Dim dt As New DataTable()
        Dim sql As String = "
        SELECT 
            r.MaterialID, 
            r.MaterialName, 
            ISNULL(u.UnitName, N'-') AS UnitName, 
            ISNULL(r.CostPrice, 0) AS CostPrice, 
            ISNULL(s.CurrentStock, 0) AS CurrentStock
        FROM RawMaterials r
        INNER JOIN Units u ON r.UnitID = u.UnitID
        LEFT JOIN StoreStock s ON r.MaterialID = s.MaterialID AND s.StoreID = @StoreID
        WHERE (r.IsDeleted = 0 OR r.IsDeleted IS NULL) AND r.IsActive = 1
        ORDER BY r.MaterialName ASC;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@StoreID", storeID)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("GetRawMaterialsWithStock", ex)
        End Try

        Return dt
    End Function

    Public Function UpdateProductSizeCostPrice(productID As Integer, sizeID As Integer?, newCostPrice As Decimal) As Boolean
        Dim sql As String = ""
        If sizeID.HasValue AndAlso sizeID.Value > 0 Then
            sql = "UPDATE ProductSizes SET CostPrice = @Cost WHERE ProductID = @PID AND SizeID = @SID;"
        Else
            sql = "UPDATE ProductSizes SET CostPrice = @Cost WHERE ProductID = @PID; " &
                  "UPDATE Products SET CostPrice = @Cost WHERE Product_ID = @PID;"
        End If

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@Cost", newCostPrice)
                    cmd.Parameters.AddWithValue("@PID", productID)
                    If sizeID.HasValue AndAlso sizeID.Value > 0 Then
                        cmd.Parameters.AddWithValue("@SID", sizeID.Value)
                    End If
                    con.Open()
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("UpdateProductSizeCostPrice", ex)
            Return False
        End Try
    End Function

    ' =========================================================
    ' 6. إدارة حجوزات الصالة والعربون (Table Reservations & Deposit)
    ' =========================================================

    Private Shared _resTablesChecked As Boolean = False
    Private Shared ReadOnly _resInitLock As New Object()

    Public Sub EnsureReservationTablesCreated()
        If _resTablesChecked Then Return
        SyncLock _resInitLock
            If _resTablesChecked Then Return
            Try
                Dim ddl As String = "
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TableReservations')
                BEGIN
                    CREATE TABLE TableReservations (
                        ReservationID INT IDENTITY(1,1) PRIMARY KEY,
                        ReservationNumber NVARCHAR(50) NOT NULL,
                        TableID INT NOT NULL CONSTRAINT FK_TR_RT REFERENCES RestaurantTables(TableID),
                        TableName NVARCHAR(100) NULL,
                        CustomerName NVARCHAR(150) NOT NULL,
                        CustomerPhone NVARCHAR(50) NOT NULL,
                        GuestCount INT NOT NULL DEFAULT 2,
                        ReservationDateTime DATETIME NOT NULL,
                        DepositAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
                        TreasuryID INT NULL,
                        Status TINYINT NOT NULL DEFAULT 1,
                        Notes NVARCHAR(500) NULL,
                        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
                        CreatedByUserID INT NOT NULL DEFAULT 1
                    );
                END;"

                Using con As New SqlConnection(_ConnectionString)
                    Using cmd As New SqlCommand(ddl, con)
                        con.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                _resTablesChecked = True
            Catch ex As Exception
                Debug.WriteLine("EnsureReservationTablesCreated error: " & ex.Message)
            End Try
        End SyncLock
    End Sub

    Public Async Function SaveTableReservationAsync(res As TableReservationModel) As Task(Of Boolean)
        EnsureReservationTablesCreated()
        Dim genNumber As String = "RES-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")

        Dim sqlRes As String = "
        INSERT INTO TableReservations 
        (ReservationNumber, TableID, TableName, CustomerName, CustomerPhone, GuestCount, ReservationDateTime, DepositAmount, TreasuryID, Status, Notes, CreatedAt, CreatedByUserID)
        VALUES 
        (@Num, @TID, @TName, @CName, @CPhone, @Guests, @RDate, @Deposit, @TreasuryID, @Status, @Notes, GETDATE(), @UserID);
        SELECT SCOPE_IDENTITY();"

        Using con As New SqlConnection(_ConnectionString)
            Await con.OpenAsync()
            Dim trans As SqlTransaction = con.BeginTransaction()

            Try
                Dim newResID As Integer = 0
                Using cmd As New SqlCommand(sqlRes, con, trans)
                    cmd.Parameters.AddWithValue("@Num", genNumber)
                    cmd.Parameters.AddWithValue("@TID", res.TableID)
                    cmd.Parameters.AddWithValue("@TName", If(String.IsNullOrEmpty(res.TableName), DBNull.Value, res.TableName))
                    cmd.Parameters.AddWithValue("@CName", res.CustomerName)
                    cmd.Parameters.AddWithValue("@CPhone", res.CustomerPhone)
                    cmd.Parameters.AddWithValue("@Guests", res.GuestCount)
                    cmd.Parameters.AddWithValue("@RDate", res.ReservationDateTime)
                    cmd.Parameters.AddWithValue("@Deposit", res.DepositAmount)
                    cmd.Parameters.AddWithValue("@TreasuryID", If(res.TreasuryID.HasValue, res.TreasuryID.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@Status", CByte(res.Status))
                    cmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(res.Notes), DBNull.Value, res.Notes))
                    cmd.Parameters.AddWithValue("@UserID", res.CreatedByUserID)

                    Dim objId = Await cmd.ExecuteScalarAsync()
                    newResID = Convert.ToInt32(objId)
                End Using

                ' تحديث حالة الطاولة إلى 3 (محجوزة - أصفر)
                Dim sqlUpdateTable As String = "UPDATE RestaurantTables SET TableStatus = 3 WHERE TableID = @TID;"
                Using cmdTbl As New SqlCommand(sqlUpdateTable, con, trans)
                    cmdTbl.Parameters.AddWithValue("@TID", res.TableID)
                    Await cmdTbl.ExecuteNonQueryAsync()
                End Using

                ' إيداع مبلغ العربون بالخزينة تلقائياً إن وجد
                If res.DepositAmount > 0 AndAlso res.TreasuryID.HasValue AndAlso res.TreasuryID.Value > 0 Then
                    Await TreasuryService.AddTransactionAsync(
                        treasuryID:=res.TreasuryID.Value,
                        transactionType:=TreasuryTransactionTypes.CustomerReceipt,
                        amount:=res.DepositAmount,
                        isDeposit:=True,
                        referenceID:=newResID,
                        referenceNo:=genNumber,
                        notes:=$"عربون حجز طاولة {res.TableName} للعميل {res.CustomerName}",
                        userID:=res.CreatedByUserID,
                        cn:=con,
                        trans:=trans
                    )
                End If

                trans.Commit()
                res.ReservationNumber = genNumber
                res.ReservationID = newResID
                Return True

            Catch ex As Exception
                trans.Rollback()
                Logger.LogError("SaveTableReservationAsync", ex)
                Return False
            End Try
        End Using
    End Function

    Public Function GetTableReservations(fromDate As DateTime, toDate As DateTime, Optional status As Byte = 0) As List(Of TableReservationModel)
        EnsureReservationTablesCreated()
        Dim list As New List(Of TableReservationModel)

        Dim sql As String = "
        SELECT 
            r.ReservationID, r.ReservationNumber, r.TableID, ISNULL(r.TableName, t.TableName) AS TableName,
            r.CustomerName, r.CustomerPhone, r.GuestCount, r.ReservationDateTime,
            r.DepositAmount, r.TreasuryID, r.Status, r.Notes, r.CreatedAt, r.CreatedByUserID
        FROM TableReservations r
        INNER JOIN RestaurantTables t ON r.TableID = t.TableID
        WHERE r.ReservationDateTime BETWEEN @FromDate AND @ToDate "

        If status > 0 Then sql &= " AND r.Status = " & status

        sql &= " ORDER BY r.ReservationDateTime ASC;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date)
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1))
                    con.Open()
                    Using rdr As SqlDataReader = cmd.ExecuteReader()
                        While rdr.Read()
                            list.Add(New TableReservationModel With {
                                .ReservationID = Convert.ToInt32(rdr("ReservationID")),
                                .ReservationNumber = rdr("ReservationNumber").ToString(),
                                .TableID = Convert.ToInt32(rdr("TableID")),
                                .TableName = rdr("TableName").ToString(),
                                .CustomerName = rdr("CustomerName").ToString(),
                                .CustomerPhone = rdr("CustomerPhone").ToString(),
                                .GuestCount = Convert.ToInt32(rdr("GuestCount")),
                                .ReservationDateTime = Convert.ToDateTime(rdr("ReservationDateTime")),
                                .DepositAmount = Convert.ToDecimal(rdr("DepositAmount")),
                                .TreasuryID = If(IsDBNull(rdr("TreasuryID")), Nothing, Convert.ToInt32(rdr("TreasuryID"))),
                                .Status = CType(Convert.ToByte(rdr("Status")), ReservationStatus),
                                .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString()),
                                .CreatedAt = Convert.ToDateTime(rdr("CreatedAt")),
                                .CreatedByUserID = Convert.ToInt32(rdr("CreatedByUserID"))
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("GetTableReservations", ex)
        End Try

        Return list
    End Function

    Public Function GetActiveReservationForTable(tableID As Integer) As TableReservationModel
        EnsureReservationTablesCreated()
        Dim sql As String = "
        SELECT TOP 1 
            r.ReservationID, r.ReservationNumber, r.TableID, ISNULL(r.TableName, t.TableName) AS TableName,
            r.CustomerName, r.CustomerPhone, r.GuestCount, r.ReservationDateTime,
            r.DepositAmount, r.TreasuryID, r.Status, r.Notes, r.CreatedAt, r.CreatedByUserID
        FROM TableReservations r
        INNER JOIN RestaurantTables t ON r.TableID = t.TableID
        WHERE r.TableID = @TID AND r.Status = 1
        ORDER BY r.ReservationDateTime ASC;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@TID", tableID)
                    con.Open()
                    Using rdr As SqlDataReader = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Return New TableReservationModel With {
                                .ReservationID = Convert.ToInt32(rdr("ReservationID")),
                                .ReservationNumber = rdr("ReservationNumber").ToString(),
                                .TableID = Convert.ToInt32(rdr("TableID")),
                                .TableName = rdr("TableName").ToString(),
                                .CustomerName = rdr("CustomerName").ToString(),
                                .CustomerPhone = rdr("CustomerPhone").ToString(),
                                .GuestCount = Convert.ToInt32(rdr("GuestCount")),
                                .ReservationDateTime = Convert.ToDateTime(rdr("ReservationDateTime")),
                                .DepositAmount = Convert.ToDecimal(rdr("DepositAmount")),
                                .TreasuryID = If(IsDBNull(rdr("TreasuryID")), Nothing, Convert.ToInt32(rdr("TreasuryID"))),
                                .Status = CType(Convert.ToByte(rdr("Status")), ReservationStatus),
                                .Notes = If(IsDBNull(rdr("Notes")), "", rdr("Notes").ToString()),
                                .CreatedAt = Convert.ToDateTime(rdr("CreatedAt")),
                                .CreatedByUserID = Convert.ToInt32(rdr("CreatedByUserID"))
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("GetActiveReservationForTable", ex)
        End Try

        Return Nothing
    End Function

    Public Function CheckInReservation(reservationID As Integer, tableID As Integer) As Boolean
        EnsureReservationTablesCreated()
        Dim sql As String = "
        UPDATE TableReservations SET Status = 2 WHERE ReservationID = @RID;
        UPDATE RestaurantTables SET TableStatus = 2 WHERE TableID = @TID;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@RID", reservationID)
                    cmd.Parameters.AddWithValue("@TID", tableID)
                    con.Open()
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("CheckInReservation", ex)
            Return False
        End Try
    End Function

    Public Function CancelReservation(reservationID As Integer, tableID As Integer) As Boolean
        EnsureReservationTablesCreated()
        Dim sql As String = "
        UPDATE TableReservations SET Status = 3 WHERE ReservationID = @RID;
        IF NOT EXISTS (SELECT 1 FROM TableReservations WHERE TableID = @TID AND Status = 1)
            UPDATE RestaurantTables SET TableStatus = 1 WHERE TableID = @TID;"

        Try
            Using con As New SqlConnection(_ConnectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@RID", reservationID)
                    cmd.Parameters.AddWithValue("@TID", tableID)
                    con.Open()
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Logger.LogError("CancelReservation", ex)
            Return False
        End Try
    End Function

End Class


'Imports System
'Imports System.Collections.Generic
'Imports System.Data.SqlClient

'Public Class POSRepository
'    Private ReadOnly _ConnectionString As String

'    Public Sub New(connectionString As String)
'        _ConnectionString = connectionString
'    End Sub

'   
'End Class

