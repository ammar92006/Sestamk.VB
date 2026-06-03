# ينتج نسخة احتياطية من قاعدة البيانات ويضعها في Installer\db\Cashier_Market.bak
# الاستخدام: .\prepare_db_backup.ps1 -Server ".\SQLEXPRESS" -Database "Cashier_Market"
param(
    [string]$Server   = ".\SQLEXPRESS",
    [string]$Database = "Cashier_Market"
)

$ErrorActionPreference = "Stop"
$dbDir  = Join-Path $PSScriptRoot "db"
$bakOut = Join-Path $dbDir "$Database.bak"

if (-not (Test-Path $dbDir)) { New-Item -ItemType Directory -Path $dbDir | Out-Null }

$sql = @"
BACKUP DATABASE [$Database]
TO DISK = N'$bakOut'
WITH FORMAT, INIT, COMPRESSION, NAME = N'$Database-Full';
"@

Write-Host "إنشاء نسخة احتياطية من [$Database] على [$Server] ..." -ForegroundColor Cyan

$sqlcmd = Get-Command sqlcmd -ErrorAction SilentlyContinue
if ($sqlcmd) {
    & sqlcmd -S $Server -E -b -Q $sql
} else {
    # بديل عبر .NET لو sqlcmd غير متوفّر
    Add-Type -AssemblyName "System.Data"
    $cn = New-Object System.Data.SqlClient.SqlConnection("Server=$Server;Database=master;Integrated Security=True;")
    $cn.Open()
    $cmd = $cn.CreateCommand()
    $cmd.CommandTimeout = 300
    $cmd.CommandText = $sql
    [void]$cmd.ExecuteNonQuery()
    $cn.Close()
}

if (Test-Path $bakOut) {
    $size = "{0:N1} MB" -f ((Get-Item $bakOut).Length / 1MB)
    Write-Host "تم: $bakOut ($size)" -ForegroundColor Green
} else {
    Write-Error "فشل إنشاء النسخة الاحتياطية."
}
