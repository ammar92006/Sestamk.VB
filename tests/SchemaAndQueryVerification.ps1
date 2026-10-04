<#
.SYNOPSIS
    التحقق من صحة تغييرات الهيكل والاستعلامات الجديدة على قاعدة اختبار حقيقية (LocalDB).

.DESCRIPTION
    ينشئ قاعدة بيانات مؤقتة، يطبّق عليها سكربت الهيكل المُشحَّن
    (WindowsApp1\Resources\DatabaseSchema.sql)، ثم يتحقق من:
      1) أن سكربت الهيكل يُطبَّق بلا أخطاء على قاعدة جديدة.
      2) أن الأعمدة الجديدة موجودة (SalesInvoiceDetails.SizeID / AddonIDs،
         SalesInvoices.OriginalInvoiceID).
      3) أن استعلام الوصفة الجديد يعمل فعلاً (كان يشير لأعمدة غير موجودة).
      4) أن استعلام كميات المرتجعات السابقة يعمل ويرجّع النتيجة الصحيحة.
      5) أن المسار القديم (ItemID/ModifierID) كان سيفشل — لإثبات وجود العطب أصلاً.
    ثم يحذف قاعدة الاختبار.

.EXAMPLE
    powershell -NoProfile -ExecutionPolicy Bypass -File tests\SchemaAndQueryVerification.ps1
#>
param(
    [string]$SchemaPath = (Join-Path $PSScriptRoot '..\WindowsApp1\Resources\DatabaseSchema.sql'),
    [string]$Server = '(localdb)\MSSQLLocalDB'
)

$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Data

$SchemaPath = (Resolve-Path $SchemaPath).Path
$testDb = 'SestamkSchemaVerify_' + [Guid]::NewGuid().ToString('N').Substring(0, 10)

$pass = 0; $fail = 0
function Check([bool]$ok, [string]$name, [string]$detail = '') {
    if ($ok) { $script:pass++; Write-Output "PASS $name" }
    else { $script:fail++; Write-Output "FAIL $name  $detail" }
}

function New-Conn([string]$db) {
    New-Object System.Data.SqlClient.SqlConnection("Server=$Server;Database=$db;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;Connect Timeout=30")
}
function Invoke-Sql($cn, [string]$sql, [int]$timeout = 120) {
    $cmd = $cn.CreateCommand(); $cmd.CommandText = $sql; $cmd.CommandTimeout = $timeout
    try { [void]$cmd.ExecuteNonQuery() } finally { $cmd.Dispose() }
}
function Scalar($cn, [string]$sql) {
    $cmd = $cn.CreateCommand(); $cmd.CommandText = $sql; $cmd.CommandTimeout = 60
    try { return $cmd.ExecuteScalar() } finally { $cmd.Dispose() }
}
function Table($cn, [string]$sql) {
    $cmd = $cn.CreateCommand(); $cmd.CommandText = $sql; $cmd.CommandTimeout = 60
    $da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    $dt = New-Object System.Data.DataTable
    try { [void]$da.Fill($dt); return $dt } finally { $cmd.Dispose(); $da.Dispose() }
}

$master = New-Conn 'master'
$master.Open()
$cn = $null

try {
    Write-Output "--- creating scratch database $testDb ---"
    Invoke-Sql $master "CREATE DATABASE [$testDb];"

    $cn = New-Conn $testDb
    $cn.Open()

    # ── 1) تطبيق سكربت الهيكل المُشحَّن ───────────────────────────────────────
    Write-Output "--- applying shipped schema script ---"
    $script = [System.IO.File]::ReadAllText($SchemaPath)
    $batches = [regex]::Split($script, '(?im)^\s*GO\s*$') | Where-Object { $_.Trim() -ne '' }
    $applyErrors = New-Object System.Collections.Generic.List[string]
    foreach ($b in $batches) {
        try { Invoke-Sql $cn $b }
        catch { $applyErrors.Add($_.Exception.Message) }
    }
    Check ($applyErrors.Count -eq 0) 'schema script applies with no errors' ("errors: " + ($applyErrors -join ' | '))
    if ($applyErrors.Count -gt 0) { $applyErrors | Select-Object -First 5 | ForEach-Object { Write-Output "      $_" } }

    # ── 2) الأعمدة الجديدة موجودة ─────────────────────────────────────────────
    $col = { param($t, $c) Scalar $cn "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='$t' AND COLUMN_NAME='$c'" }
    Check ((& $col 'SalesInvoiceDetails' 'SizeID') -eq 1)      'SalesInvoiceDetails.SizeID exists'
    Check ((& $col 'SalesInvoiceDetails' 'AddonIDs') -eq 1)    'SalesInvoiceDetails.AddonIDs exists'
    Check ((& $col 'SalesInvoices' 'OriginalInvoiceID') -eq 1) 'SalesInvoices.OriginalInvoiceID exists'
    Check ((Scalar $cn "SELECT COUNT(*) FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME='vw_SalesHeaderAll'") -eq 1)  'View vw_SalesHeaderAll exists'
    Check ((Scalar $cn "SELECT COUNT(*) FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME='vw_SalesDetailsAll'") -eq 1) 'View vw_SalesDetailsAll exists'

    # ── 3) أعمدة جدول Recipes الفعلية (أساس عطب الريسيبي) ─────────────────────
    Check ((Scalar $cn "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Recipes'") -eq 1) 'Recipes table exists'
    Check ((& $col 'Recipes' 'ProductID') -eq 1)  'Recipes has ProductID'
    Check ((& $col 'Recipes' 'SizeID') -eq 1)     'Recipes has SizeID'
    Check ((& $col 'Recipes' 'AddonID') -eq 1)    'Recipes has AddonID'
    Check ((& $col 'Recipes' 'ItemID') -eq 0 -and (& $col 'Recipes' 'ModifierID') -eq 0) `
          'Recipes has NO ItemID/ModifierID (old query was guaranteed to fail)'

    # ── 4) بيانات اختبار: صنف + حجم + إضافة + وصفات ───────────────────────────
    Invoke-Sql $cn @"
SET IDENTITY_INSERT [dbo].[Products] ON;
INSERT INTO [dbo].[Products] (Product_ID, ProductName, ProductNameAr, SalePrice, IsActive, IsDeleted) VALUES (900, N'Test Item', N'صنف اختبار', 100, 1, 0);
SET IDENTITY_INSERT [dbo].[Products] OFF;
INSERT INTO [dbo].[Recipes] (ProductID, SizeID, AddonID, MaterialID, Quantity) VALUES (900, NULL, NULL, 501, 0.2500);
INSERT INTO [dbo].[Recipes] (ProductID, SizeID, AddonID, MaterialID, Quantity) VALUES (900, 7,    NULL, 502, 0.1000);
INSERT INTO [dbo].[Recipes] (ProductID, SizeID, AddonID, MaterialID, Quantity) VALUES (900, NULL, 11,   503, 2.0000);
"@

    # ── 5) استعلام الوصفة الجديد يعمل ويرجّع الوصفة الصحيحة ───────────────────
    $recipeSql = @"
SELECT MaterialID, Quantity FROM Recipes
WHERE ProductID = @ProductID
  AND ((@SizeID IS NULL AND SizeID IS NULL) OR SizeID = @SizeID)
  AND ((@AddonID IS NULL AND AddonID IS NULL) OR AddonID = @AddonID)
"@
    function RecipeCount($sizeId, $addonId) {
        $cmd = $cn.CreateCommand(); $cmd.CommandText = $recipeSql
        [void]$cmd.Parameters.AddWithValue('@ProductID', 900)
        [void]$cmd.Parameters.AddWithValue('@SizeID', $(if ($null -eq $sizeId) { [DBNull]::Value } else { $sizeId }))
        [void]$cmd.Parameters.AddWithValue('@AddonID', $(if ($null -eq $addonId) { [DBNull]::Value } else { $addonId }))
        try { $r = $cmd.ExecuteScalar(); if ($null -eq $r) { return 0 } else { return 1 } } finally { $cmd.Dispose() }
    }
    Check ((RecipeCount $null $null) -eq 1) 'base recipe matched (no size, no addon)'
    Check ((RecipeCount 7 $null)    -eq 1) 'size recipe matched'
    Check ((RecipeCount $null 11)   -eq 1) 'addon recipe matched'
    Check ((RecipeCount 7 11)       -eq 0) 'no false match for size+addon combination'

    # ── 6) إثبات أن الاستعلام القديم كان يفشل ────────────────────────────────
    $oldFailed = $false
    try {
        [void](Scalar $cn "SELECT COUNT(*) FROM Recipes WHERE ItemID = 900")
    } catch { $oldFailed = $true }
    Check $oldFailed 'old query (ItemID) indeed fails on this schema'

    # ── 7) استعلام كميات المرتجعات السابقة ───────────────────────────────────
    Invoke-Sql $cn @"
SET IDENTITY_INSERT [dbo].[SalesInvoices] ON;
INSERT INTO [dbo].[SalesInvoices] (InvoiceID, InvoiceNumber, InvoiceDate, OrderType, ShiftID, UserID, NetTotal, IsCredit, IsActive, IsDeleted, OriginalInvoiceID)
VALUES (9001, N'1', GETDATE(), 1, 1, 1, 200, 0, 1, 0, NULL);
INSERT INTO [dbo].[SalesInvoices] (InvoiceID, InvoiceNumber, InvoiceDate, OrderType, ShiftID, UserID, NetTotal, IsCredit, IsActive, IsDeleted, OriginalInvoiceID)
VALUES (9002, N'RET-1', GETDATE(), 1, 1, 1, -50, 0, 1, 0, 9001);
SET IDENTITY_INSERT [dbo].[SalesInvoices] OFF;
INSERT INTO [dbo].[SalesInvoiceDetails] (InvoiceID, ProductID, ProductName, SizeName, AddonsText, UnitPrice, Quantity, TotalPrice, SizeID, AddonIDs)
VALUES (9001, 900, N'صنف اختبار', N'وسط', N'جبنة', 100, 3, 300, 7, N'11');
INSERT INTO [dbo].[SalesInvoiceDetails] (InvoiceID, ProductID, ProductName, SizeName, AddonsText, UnitPrice, Quantity, TotalPrice, SizeID, AddonIDs)
VALUES (9002, 900, N'صنف اختبار', N'وسط', N'جبنة', 100, -1, -100, 7, N'11');
"@

    $returnedSql = @"
SELECT d.ProductID, ISNULL(d.SizeName,'') AS SizeName, ISNULL(d.AddonsText,'') AS AddonsText,
       SUM(ABS(ISNULL(d.Quantity,0))) AS ReturnedQty
FROM SalesInvoiceDetails d
INNER JOIN SalesInvoices i ON i.InvoiceID = d.InvoiceID
WHERE ISNULL(i.IsDeleted,0) = 0
  AND (i.OriginalInvoiceID = @OrigID
       OR (i.OriginalInvoiceID IS NULL AND i.Notes LIKE @NotesPattern))
GROUP BY d.ProductID, ISNULL(d.SizeName,''), ISNULL(d.AddonsText,'')
"@
    $cmd = $cn.CreateCommand(); $cmd.CommandText = $returnedSql
    [void]$cmd.Parameters.AddWithValue('@OrigID', 9001)
    [void]$cmd.Parameters.AddWithValue('@NotesPattern', '%مرتجع مبيعات للفاتورة #1 |%')
    $dt = New-Object System.Data.DataTable
    $da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    [void]$da.Fill($dt); $cmd.Dispose(); $da.Dispose()
    Check ($dt.Rows.Count -eq 1) 'previous-returns query returns one grouped line'
    if ($dt.Rows.Count -eq 1) {
        Check ([decimal]$dt.Rows[0]['ReturnedQty'] -eq 1) 'previous-returns query returns the right quantity (1)'
    }

    # ── 8) تحديث رصيد العميل النسبي (منع Lost Update) ────────────────────────
    Invoke-Sql $cn "SET IDENTITY_INSERT [dbo].[Customers] ON; INSERT INTO [dbo].[Customers] (CustomerID, CustomerCode, CustomerName, CurrentBalance, IsActive, IsDeleted) VALUES (9001, N'C1', N'عميل اختبار', 100, 1, 0); SET IDENTITY_INSERT [dbo].[Customers] OFF;"
    Invoke-Sql $cn "UPDATE Customers SET CurrentBalance = ISNULL(CurrentBalance,0) - @d WHERE CustomerID = 9001;".Replace('@d', '25')
    Check ([decimal](Scalar $cn "SELECT CurrentBalance FROM Customers WHERE CustomerID = 9001") -eq 75) 'relative customer balance update works (100 - 25 = 75)'
    Invoke-Sql $cn "UPDATE Customers SET CurrentBalance = ISNULL(CurrentBalance,0) + @d WHERE CustomerID = 9001;".Replace('@d', '25')
    Check ([decimal](Scalar $cn "SELECT CurrentBalance FROM Customers WHERE CustomerID = 9001") -eq 100) 'relative credit update works (75 + 25 = 100)'
}
finally {
    if ($cn) { $cn.Dispose() }
    try {
        Invoke-Sql $master "IF DB_ID('$testDb') IS NOT NULL BEGIN ALTER DATABASE [$testDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [$testDb]; END;"
        Write-Output "--- scratch database removed ---"
    } catch { Write-Output "WARN cleanup failed: $($_.Exception.Message)" }
    $master.Dispose()
}

Write-Output ""
Write-Output "RESULT: $pass passed, $fail failed"
if ($fail -gt 0) { exit 1 }
Write-Output 'ALL SCHEMA & QUERY VERIFICATIONS PASSED'
