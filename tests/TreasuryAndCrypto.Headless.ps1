param([string]$AppPath = (Join-Path $PSScriptRoot '..\WindowsApp1\bin\Debug\Sestamk.exe'))
# ============================================================
# Headless service tests: PasswordHasher + TreasuryService
# Runs without UI against a scratch LocalDB fixture database.
# ============================================================
$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Data
$AppPath = (Resolve-Path $AppPath).Path
$appDirectory = Split-Path $AppPath
$resolver = [ResolveEventHandler] {
    param($sender, $eventArgs)
    $simpleName = (New-Object Reflection.AssemblyName($eventArgs.Name)).Name
    $candidate = Join-Path $appDirectory ($simpleName + '.dll')
    if (Test-Path -LiteralPath $candidate) { return [Reflection.Assembly]::LoadFrom($candidate) }
    return $null
}
[AppDomain]::CurrentDomain.add_AssemblyResolve($resolver)
$asm = [Reflection.Assembly]::LoadFrom($AppPath)

$hasherT  = $asm.GetType('WindowsApp1.PasswordHasher')
$treasuryT = $asm.GetType('WindowsApp1.TreasuryService')
if (-not $hasherT)   { throw 'WindowsApp1.PasswordHasher not found' }
if (-not $treasuryT) { throw 'WindowsApp1.TreasuryService not found' }

function InvokeStatic($t, $m, $arguments) {
    $mi = $t.GetMethod($m, [Reflection.BindingFlags]'Public,Static')
    if (-not $mi) { throw "method $m not found" }
    try {
        if ($mi.ReturnType -eq [void]) { $mi.Invoke($null, $arguments) | Out-Null }
        else { return $mi.Invoke($null, $arguments) }
    } catch { throw $_.Exception.InnerException }
}
function AssertTrue($cond, [string]$label) {
    if (-not $cond) { throw "FAIL $label" }
    Write-Output "PASS $label"
}
function AssertEqual($actual, $expected, [string]$label) {
    if ($actual -ne $expected) { throw "FAIL $label expected=$expected actual=$actual" }
    Write-Output "PASS $label ($actual)"
}
function ExpectThrow([scriptblock]$action, [string]$label) {
    $failed = $false
    try { & $action | Out-Null } catch { $failed = $true }
    if (-not $failed) { throw "FAIL expected exception: $label" }
    Write-Output "PASS $label"
}

# ---------- 1) PasswordHasher ----------
Write-Output '--- PasswordHasher ---'
$h1 = InvokeStatic $hasherT 'Hash' @('S3cret!123')
AssertTrue ((InvokeStatic $hasherT 'IsHashed' @($h1)) -eq $true) 'hash format recognized'
AssertTrue ((InvokeStatic $hasherT 'Verify' @('S3cret!123', $h1)) -eq $true) 'verify correct password'
AssertTrue ((InvokeStatic $hasherT 'Verify' @('wrong', $h1)) -eq $false) 'verify wrong password'
$h2 = InvokeStatic $hasherT 'Hash' @('S3cret!123')
AssertTrue ($h1 -ne $h2) 'salt produces unique hashes'
AssertTrue ((InvokeStatic $hasherT 'IsHashed' @('2222')) -eq $false) 'plain text detected as legacy'
AssertTrue ((InvokeStatic $hasherT 'Verify' @('2222', '2222')) -eq $true) 'legacy plain text verifies'
AssertTrue ((InvokeStatic $hasherT 'Verify' @('2223', '2222')) -eq $false) 'legacy plain text rejects wrong'
# tampered hash must not verify
$tampered = $h1.Substring(0, $h1.Length - 4) + 'AAAA'
AssertTrue ((InvokeStatic $hasherT 'Verify' @('S3cret!123', $tampered)) -eq $false) 'tampered hash rejected'

# ---------- 2) TreasuryService on scratch DB ----------
Write-Output '--- TreasuryService ---'
$testDb = 'SestamkTreasuryTests_' + [Guid]::NewGuid().ToString('N')
$master = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=master;Integrated Security=True;Encrypt=False;TrustServerCertificate=True')
$master.Open()
$cmd = $master.CreateCommand()
$cmd.CommandText = "CREATE DATABASE [$testDb]; ALTER DATABASE [$testDb] SET READ_COMMITTED_SNAPSHOT ON;"
[void]$cmd.ExecuteNonQuery()

$cs = "Server=(localdb)\MSSQLLocalDB;Database=$testDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"
$cn = New-Object System.Data.SqlClient.SqlConnection($cs)
$cn.Open()
function Exec([string]$sql) { $c = $cn.CreateCommand(); $c.CommandText = $sql; [void]$c.ExecuteNonQuery(); $c.Dispose() }
function Scalar2([string]$sql) { $c = $cn.CreateCommand(); $c.CommandText = $sql; $r = $c.ExecuteScalar(); $c.Dispose(); return $r }

Exec @"
CREATE TABLE Treasury (
  TreasuryID INT IDENTITY PRIMARY KEY,
  TreasuryCode NVARCHAR(50) NOT NULL,
  TreasuryNameAr NVARCHAR(200) NOT NULL,
  OpeningBalance DECIMAL(18,2) NOT NULL DEFAULT 0,
  CurrentBalance DECIMAL(18,2) NOT NULL DEFAULT 0,
  IsDefault BIT NOT NULL DEFAULT 0,
  IsActive BIT NOT NULL DEFAULT 1,
  CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
  IsDeleted BIT NOT NULL DEFAULT 0,
  TreasuryName NVARCHAR(200) NULL,
  Balance DECIMAL(18,2) NOT NULL DEFAULT 0
);
CREATE TABLE TreasuryTransactions (
  TransactionID INT IDENTITY PRIMARY KEY,
  TreasuryID INT NOT NULL,
  TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
  TransactionType INT NOT NULL,
  ReferenceID INT NULL,
  ReferenceNo NVARCHAR(50) NULL,
  Amount DECIMAL(18,2) NOT NULL,
  IsDeposit BIT NOT NULL,
  Notes NVARCHAR(MAX) NULL,
  UserID INT NULL,
  CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
INSERT INTO Treasury (TreasuryCode, TreasuryNameAr, TreasuryName, OpeningBalance, CurrentBalance)
VALUES ('T1', N'الخزينة الرئيسية', N'الخزينة الرئيسية', 1000.00, 1000.00);
"@

$typesEnum = $asm.GetType('WindowsApp1.TreasuryTransactionTypes')
# enum values used by code: Sale etc; numeric values passed directly
$treasuryId = 1
$userId = 2

function AddTx([decimal]$amount, [bool]$isDeposit, [int]$txType) {
    # App contract: AddTransactionAsync + UpdateBalanceAsync run inside ONE caller-owned
    # SqlTransaction; on any throw the caller must roll back (orphan rows must not commit).
    $trans = $cn.BeginTransaction()
    try {
        $mi = $treasuryT.GetMethods([Reflection.BindingFlags]'Public,Static') | Where-Object { $_.Name -eq 'AddTransactionAsync' } | Select-Object -First 1
        $p = New-Object 'System.Collections.Generic.List[object]'
        [void]$p.Add([int]$treasuryId); [void]$p.Add([int]$txType); [void]$p.Add([decimal]$amount); [void]$p.Add([bool]$isDeposit)
        [void]$p.Add([int]0); [void]$p.Add([string]'TEST'); [void]$p.Add([string]'headless test'); [void]$p.Add([int]$userId)
        [void]$p.Add([System.Data.SqlClient.SqlConnection]$cn); [void]$p.Add($trans)
        $task = $mi.Invoke($null, $p.ToArray())
        $task.GetAwaiter().GetResult()

        $mi2 = $treasuryT.GetMethods([Reflection.BindingFlags]'Public,Static') | Where-Object { $_.Name -eq 'UpdateBalanceAsync' } | Select-Object -First 1
        $p2 = New-Object 'System.Collections.Generic.List[object]'
        [void]$p2.Add([int]$treasuryId); [void]$p2.Add([System.Data.SqlClient.SqlConnection]$cn); [void]$p2.Add($trans); [void]$p2.Add([bool]$isDeposit)
        $task2 = $mi2.Invoke($null, $p2.ToArray())
        $task2.GetAwaiter().GetResult()

        $trans.Commit()
    } catch {
        $trans.Rollback()
        throw
    }
}
function GetBalance { return [decimal](Scalar2 'SELECT CurrentBalance FROM Treasury WHERE TreasuryID = 1') }

# deposit 500 -> 1500
AddTx 500 $true 1
AssertEqual (GetBalance) 1500 'deposit updates balance from opening+txns'

# withdraw 2000 -> must throw (insufficient funds) and roll back the inserted row
ExpectThrow { AddTx 2000 $false 2 } 'withdraw beyond balance rejected'
AssertEqual (GetBalance) 1500 'balance unchanged after rejected withdraw'
AssertEqual (Scalar2 'SELECT COUNT(*) FROM TreasuryTransactions WHERE IsDeposit = 0 AND Amount = 2000') 0 'rejected withdraw leaves no orphan transaction row'

# withdraw 500 -> 1000
AddTx 500 $false 2
AssertEqual (GetBalance) 1000 'withdraw updates balance'

# deposit with sub-cent amount: was a KNOWN BUG (SqlClient truncates at Scale=2 without
# pre-rounding: 250.555 became 250.55). Fixed in v1.2.7 by Math.Round(amount, 2) in
# TreasuryService.AddTransactionAsync — now expects correct rounding to 250.56.
AddTx ([decimal]'250.555') $true 1
AssertEqual (GetBalance) 1250.56 'sub-cent amount rounds to nearest cent (1250.56)'

$cn.Dispose()
# تنظيف قاعدة الاختبار: يجب طرد أي اتصال قائم أولاً (SINGLE_USER + ROLLBACK IMMEDIATE)،
# وإلا فشل DROP DATABASE برسالة "currently in use" وأفشل الاختبار رغم نجاح كل التأكيدات.
$cmd = $master.CreateCommand()
$cmd.CommandText = "IF DB_ID('$testDb') IS NOT NULL BEGIN ALTER DATABASE [$testDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [$testDb]; END;"
$cmd.CommandTimeout = 60
[void]$cmd.ExecuteNonQuery()
$master.Dispose()
Write-Output 'ALL SERVICE TESTS PASSED'
