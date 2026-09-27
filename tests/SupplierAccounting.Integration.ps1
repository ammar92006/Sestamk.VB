param([string]$AppPath = (Join-Path $PSScriptRoot '..\WindowsApp1\bin\Debug\Sestamk.exe'), [string]$RenderDirectory = '')
$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Data
Add-Type -AssemblyName System.Windows.Forms
$AppPath = (Resolve-Path $AppPath).Path
$appDirectory = Split-Path $AppPath
# Windows PowerShell does not load Sestamk.exe.config binding redirects.
# Resolve dependencies from the same application output used by the test.
$resolver = [ResolveEventHandler] {
    param($sender, $eventArgs)
    $simpleName = (New-Object Reflection.AssemblyName($eventArgs.Name)).Name
    $candidate = Join-Path $appDirectory ($simpleName + '.dll')
    if (Test-Path -LiteralPath $candidate) { return [Reflection.Assembly]::LoadFrom($candidate) }
    return $null
}
[AppDomain]::CurrentDomain.add_AssemblyResolve($resolver)
[void][Reflection.Assembly]::LoadFrom($AppPath)
$testDb = 'SestamkSupplierTests_' + [Guid]::NewGuid().ToString('N')
$master = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=master;Integrated Security=True;Encrypt=False;TrustServerCertificate=True')
$cn = $null
$created = $false
function Execute([string]$sql) {
    $cmd = $cn.CreateCommand(); $cmd.CommandText = $sql
    try { [void]$cmd.ExecuteNonQuery() } finally { $cmd.Dispose() }
}
function Scalar([string]$sql) {
    $cmd = $cn.CreateCommand(); $cmd.CommandText = $sql
    try { return $cmd.ExecuteScalar() } finally { $cmd.Dispose() }
}
function AssertEqual($actual, $expected, [string]$label) {
    if ($actual -ne $expected) { throw "$label expected=$expected actual=$actual" }
    Write-Output "PASS $label"
}
function ExpectFailure([scriptblock]$action, [string]$label) {
    $failed = $false
    try { & $action | Out-Null } catch { $failed = $true }
    if (-not $failed) { throw "Expected failure: $label" }
    Write-Output "PASS $label"
}
# Populate only a newly created fixture database; never read application settings.
function Seed([string]$table, [hashtable]$values) {
    $definition = $schema | Where-Object TableName -eq $table
    $cmd = $cn.CreateCommand()
    $names = @(); $parameters = @()
    foreach ($column in $definition.Columns) {
        if ($column.IsIdentity) { continue }
        if ($values.ContainsKey($column.Name)) { $value = $values[$column.Name] }
        elseif (-not $column.IsNullable -and [string]::IsNullOrEmpty($column.DefaultValue)) {
            if ($column.SqlType -match 'CHAR') { $value = 'fixture' }
            elseif ($column.SqlType -match 'DATE') { $value = [DateTime]::Now }
            else { $value = 0 }
        } else { continue }
        $names += '[' + $column.Name + ']'
        $parameter = '@p' + $parameters.Count
        $parameters += $parameter
        [void]$cmd.Parameters.AddWithValue($parameter, $value)
    }
    $cmd.CommandText = "INSERT INTO [$table] (" + ($names -join ',') + ') VALUES (' + ($parameters -join ',') + '); SELECT CAST(SCOPE_IDENTITY() AS int);'
    try { return [int]$cmd.ExecuteScalar() } finally { $cmd.Dispose() }
}
try {
    $master.Open()
    $command = $master.CreateCommand(); $command.CommandText = "CREATE DATABASE [$testDb]"; [void]$command.ExecuteNonQuery(); $command.Dispose(); $created = $true
    $cn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=$testDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")
    $cn.Open()
    [WindowsApp1.DBModule]::server = '(localdb)\MSSQLLocalDB'
    [WindowsApp1.DBModule]::database = $testDb
    [WindowsApp1.DBModule]::useWindowsAuth = $true
    [WindowsApp1.DBModule]::useAttachDb = $false
    [WindowsApp1.Session]::CurrentUserID = 42
    [WindowsApp1.Session]::CurrentRoleID = 1
    $schema = [WindowsApp1.Services.DatabaseSchemaDefinitions]::GetExpectedSchema()
    $tables = @('Suppliers','SupplierTransactions','Treasury','TreasuryTransactions','PurchaseHeaders','PurchaseDetails','RawMaterials','MaterialUnits','Units','Stores','StoreStock','StockMovements','Branches','AppSettings')
    foreach ($definition in $schema) { if ($tables -contains $definition.TableName) { Execute $definition.ToCreateTableSql() } }
    $treasury = Seed 'Treasury' @{TreasuryNameAr='test';OpeningBalance=1000;CurrentBalance=1000}
    $unit = Seed 'Units' @{UnitName='piece'}
    $boxUnit = Seed 'Units' @{UnitName='box'}
    $store = Seed 'Stores' @{StoreName='test'}
    $material = Seed 'RawMaterials' @{MaterialName='test';UnitID=$unit;CostPrice=5}
    [void](Seed 'MaterialUnits' @{MaterialID=$material;UnitID=$boxUnit;ConversionFactor=10;PurchasePrice=50})
    $supplier = New-Object WindowsApp1.SupplierModel
    $supplier.SupplierCode='S1';$supplier.SupplierName='Supplier';$supplier.Phone1='';$supplier.OpeningBalance=100
    $repo = New-Object WindowsApp1.SupplierRepository([WindowsApp1.DBModule]::ConnectionString)
    [int]$supplierID=0
    [void]$repo.SaveSupplier($supplier,42,[ref]$supplierID)
    AssertEqual (Scalar "SELECT CurrentBalance FROM Suppliers WHERE SupplierID=$supplierID") 100 'opening balance'
    AssertEqual (Scalar "SELECT Credit-Debit FROM SupplierTransactions WHERE SupplierID=$supplierID") 100 'opening ledger'
    $items = New-Object System.Data.DataTable
    foreach($column in @('MaterialID','UnitID','Quantity','ConversionFactor','UnitPrice')) { [void]$items.Columns.Add($column,[decimal]) }
    [void]$items.Rows.Add($material,$boxUnit,2,10,100)
    $id = [WindowsApp1.SupplierAccountingService]::SavePurchaseAsync('TEST-001',$supplierID,$store,[DateTime]::Today,20,50,'PARTIAL',$treasury,'test',$items,$true).GetAwaiter().GetResult()
    AssertEqual (Scalar "SELECT CurrentBalance FROM Suppliers WHERE SupplierID=$supplierID") 230 'partial purchase supplier balance'
    AssertEqual (Scalar "SELECT CurrentBalance FROM Treasury WHERE TreasuryID=$treasury") 950 'partial purchase treasury'
    AssertEqual (Scalar "SELECT CurrentStock FROM StoreStock WHERE MaterialID=$material") 20 'stock conversion'
    AssertEqual (Scalar "SELECT CostPrice FROM RawMaterials WHERE MaterialID=$material") 9 'discounted base cost'
    AssertEqual (Scalar "SELECT PurchasePrice FROM MaterialUnits WHERE MaterialID=$material") 90 'converted unit cost'
    AssertEqual (Scalar "SELECT BalanceBefore FROM SupplierTransactions WHERE TransactionType='PURCHASE'") 100 'record previous balance'
    AssertEqual (Scalar "SELECT ReferenceID FROM StockMovements") $id 'numeric stock reference'
    AssertEqual (Scalar "SELECT UserID FROM PurchaseHeaders") 42 'session user'
    ExpectFailure { [WindowsApp1.SupplierAccountingService]::SavePurchaseAsync('TEST-001',$supplierID,$store,[DateTime]::Today,0,0,'CREDIT',$null,'test',$items,$false).GetAwaiter().GetResult() } 'duplicate invoice rollback'
    AssertEqual (Scalar 'SELECT COUNT(*) FROM PurchaseHeaders') 1 'no duplicate header'
    [WindowsApp1.SupplierAccountingService]::PayAsync($supplierID,$treasury,30,'cash','payment').GetAwaiter().GetResult()
    AssertEqual (Scalar "SELECT CurrentBalance FROM Suppliers WHERE SupplierID=$supplierID") 200 'supplier payment'
    AssertEqual (Scalar "SELECT CurrentBalance FROM Treasury WHERE TreasuryID=$treasury") 920 'payment treasury'
    ExpectFailure { [WindowsApp1.SupplierAccountingService]::PayAsync($supplierID,$treasury,2000,'cash','fail').GetAwaiter().GetResult() } 'insufficient treasury rollback'
    AssertEqual (Scalar "SELECT CurrentBalance FROM Suppliers WHERE SupplierID=$supplierID") 200 'supplier unchanged on failure'
    AssertEqual (Scalar 'SELECT COUNT(*) FROM SupplierTransactions') 3 'failed payment no ledger entry'
    AssertEqual (Scalar 'SELECT COUNT(*) FROM TreasuryTransactions') 2 'failed payment no treasury entry'
    $items.Rows[0]['UnitPrice']=1000
    ExpectFailure { [WindowsApp1.SupplierAccountingService]::SavePurchaseAsync('TEST-FAIL',$supplierID,$store,[DateTime]::Today,0,2000,'CASH',$treasury,'test',$items,$true).GetAwaiter().GetResult() } 'cash invoice insufficient funds'
    AssertEqual (Scalar 'SELECT COUNT(*) FROM PurchaseHeaders') 1 'failed purchase header rolled back'
    AssertEqual (Scalar 'SELECT CurrentStock FROM StoreStock') 20 'failed purchase stock rolled back'
    AssertEqual (Scalar 'SELECT CostPrice FROM RawMaterials') 9 'failed purchase cost rolled back'
    $items.Rows[0]['UnitPrice']=100
    Execute 'ALTER TABLE PurchaseDetails DROP COLUMN ActualBaseQuantity,TotalPrice; ALTER TABLE PurchaseDetails ADD ActualBaseQuantity AS Quantity*ConversionFactor, TotalPrice AS Quantity*UnitPrice;'
    [void][WindowsApp1.SupplierAccountingService]::SavePurchaseAsync('TEST-CREDIT',$supplierID,$store,[DateTime]::Today,0,0,'CREDIT',$null,'test',$items,$false).GetAwaiter().GetResult()
    AssertEqual (Scalar 'SELECT COUNT(*) FROM TreasuryTransactions') 2 'credit purchase no treasury entry'
    AssertEqual (Scalar 'SELECT CostPrice FROM RawMaterials') 9 'cost update opt out'
    Execute "UPDATE SupplierTransactions SET TransactionDate=DATEADD(day,-2,GETDATE()) WHERE TransactionType='OPENING_BALANCE'"
    $statement=[WindowsApp1.SupplierAccountingService]::GetStatement($supplierID,[DateTime]::Today,[DateTime]::Today)
    AssertEqual $statement.Rows[0][5] 100 'statement previous period balance'
    AssertEqual $statement.Rows[$statement.Rows.Count-1][5] 400 'statement final balance'
    Execute "UPDATE Suppliers SET CurrentBalance=CurrentBalance+7 WHERE SupplierID=$supplierID"
    $statement=[WindowsApp1.SupplierAccountingService]::GetStatement($supplierID,[DateTime]::Today,[DateTime]::Today)
    AssertEqual $statement.Rows[0][5] 107 'legacy difference preserved'
    $balances=[WindowsApp1.SupplierAccountingService]::GetBalances($supplierID,'')
    AssertEqual $balances.Rows[0][7] 7 'legacy difference disclosed'
    $task1=[WindowsApp1.SupplierAccountingService]::PayAsync($supplierID,$treasury,10,'cash','concurrent 1')
    $task2=[WindowsApp1.SupplierAccountingService]::PayAsync($supplierID,$treasury,10,'cash','concurrent 2')
    $task1.GetAwaiter().GetResult();$task2.GetAwaiter().GetResult()
    AssertEqual (Scalar "SELECT CurrentBalance FROM Suppliers WHERE SupplierID=$supplierID") 387 'concurrent payments supplier'
    AssertEqual (Scalar "SELECT CurrentBalance FROM Treasury WHERE TreasuryID=$treasury") 900 'concurrent payments treasury'
    [WindowsApp1.Session]::CurrentRoleID=2
    ExpectFailure { [WindowsApp1.SupplierAccountingService]::PayAsync($supplierID,$treasury,1,'cash','denied').GetAwaiter().GetResult() } 'permission denied'
    [WindowsApp1.Session]::CurrentRoleID=1
    ExpectFailure { [WindowsApp1.SupplierAccountingService]::SavePurchaseAsync('INVALID-PARTIAL',$supplierID,$store,[DateTime]::Today,0,250,'PARTIAL',$treasury,'test',$items,$false).GetAwaiter().GetResult() } 'reject overpayment'
    ExpectFailure { [WindowsApp1.SupplierAccountingService]::SavePurchaseAsync('INVALID-DISCOUNT',$supplierID,$store,[DateTime]::Today,250,0,'CREDIT',$null,'test',$items,$false).GetAwaiter().GetResult() } 'reject excessive discount'
    ExpectFailure { [WindowsApp1.SupplierAccountingService]::GetStatement($supplierID,[DateTime]::Today,[DateTime]::Today.AddDays(-1)) } 'reject reversed date range'
    $supplierExport = [WindowsApp1.Services.DataExportImportService]::GetEntityByKey('Suppliers')
    $exportData = [WindowsApp1.Services.DataExportImportService]::GetEntityDataTable($supplierExport, $null, $null)
    AssertEqual $exportData.Rows.Count 1 'supplier export query'
    $purchaseExport = [WindowsApp1.Services.DataExportImportService]::GetEntityByKey('Purchases')
    $exportData = [WindowsApp1.Services.DataExportImportService]::GetEntityDataTable($purchaseExport, [DateTime]::Today, [DateTime]::Today)
    AssertEqual $exportData.Rows.Count 2 'modern purchase export query'
    $exportGrid = New-Object System.Windows.Forms.DataGridView
    $exportGrid.AllowUserToAddRows = $false
    $exportGrid.BindingContext = New-Object System.Windows.Forms.BindingContext
    $exportGrid.DataSource = $balances
    $exportPath = Join-Path ([IO.Path]::GetTempPath()) ($testDb + '.xlsx')
    try {
        [WindowsApp1.PurchaseDocumentHelper]::WriteGridExcel($exportGrid,'Supplier balances',$exportPath,'Integration fixture')
        $book = New-Object ClosedXML.Excel.XLWorkbook($exportPath)
        try {
            $sheet = $book.Worksheets.Worksheet(2)
            AssertEqual ($sheet.Cell(2,7).GetDouble()) 407 'Excel numeric balance'
            AssertEqual ($sheet.Cell(3,7).GetDouble()) 407 'Excel balance sum formula'
        } finally { $book.Dispose() }
    } finally {
        $exportGrid.Dispose()
        if (Test-Path -LiteralPath $exportPath) { Remove-Item -LiteralPath $exportPath }
    }
    if ($RenderDirectory) {
        [void][IO.Directory]::CreateDirectory($RenderDirectory)
        foreach ($typeName in @('WindowsApp1.FrmSupplierTransactions','WindowsApp1.frmSuppliers','WindowsApp1.frmPurchases','WindowsApp1.frmPurchaseReports','WindowsApp1.FrmPurchaseDocument')) {
            $preview = New-Object $typeName
            try {
                $preview.BindingContext = New-Object System.Windows.Forms.BindingContext
                $preview.StartPosition = [System.Windows.Forms.FormStartPosition]::Manual
                $preview.Location = New-Object System.Drawing.Point(-30000,-30000)
                $preview.ShowInTaskbar = $false
                if ($typeName -eq 'WindowsApp1.frmPurchaseReports') { $preview.ShowSupplierBalances = $true }
                $preview.Show()
                [System.Windows.Forms.Application]::DoEvents()
                $preview.PerformLayout()
                $bitmap = New-Object System.Drawing.Bitmap($preview.Width,$preview.Height)
                try {
                    $preview.DrawToBitmap($bitmap, (New-Object System.Drawing.Rectangle(0,0,$preview.Width,$preview.Height)))
                    $bitmap.Save((Join-Path $RenderDirectory ($preview.GetType().Name + '.png')))
                } finally { $bitmap.Dispose() }
                Write-Output "PASS form load and render $typeName"
            } finally { $preview.Dispose() }
        }
    }
    $form=New-Object WindowsApp1.FrmSupplierTransactions
    $form.Dispose()
    Write-Output 'PASS parameterless statement constructor'
    Write-Output 'ALL SUPPLIER ACCOUNTING TESTS PASSED'
} finally {
    if ($cn) { $cn.Dispose() }
    [System.Data.SqlClient.SqlConnection]::ClearAllPools()
    if ($created -and $testDb -match '^SestamkSupplierTests_[a-f0-9]{32}$') {
        $command=$master.CreateCommand();$command.CommandText="ALTER DATABASE [$testDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [$testDb];"
        [void]$command.ExecuteNonQuery();$command.Dispose()
        Write-Output 'Fixture database removed.'
    }
    $master.Dispose()
    [AppDomain]::CurrentDomain.remove_AssemblyResolve($resolver)
}
