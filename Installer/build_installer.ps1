# يبني البرنامج (Release) ثم يجمّع ملف التثبيت بـ Inno Setup.
# الاستخدام: .\build_installer.ps1 [-Configuration Release]
param(
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"
$root    = Split-Path $PSScriptRoot -Parent
$proj    = Join-Path $root "WindowsApp1\ش.vbproj"
$binDir  = Join-Path $root "WindowsApp1\bin\$Configuration"
$iss     = Join-Path $PSScriptRoot "CashierMarket.iss"

# 1) إيجاد MSBuild
$msbuild = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" `
    -latest -requires Microsoft.Component.MSBuild `
    -find "MSBuild\**\Bin\MSBuild.exe" | Select-Object -First 1
if (-not $msbuild) { throw "MSBuild غير موجود. ثبّت Visual Studio أو Build Tools." }

# 2) بناء البرنامج
Write-Host "بناء البرنامج ($Configuration) ..." -ForegroundColor Cyan
& $msbuild $proj /t:Build /p:Configuration=$Configuration /v:minimal /nologo
if ($LASTEXITCODE -ne 0) { throw "فشل بناء البرنامج." }

# 3) إيجاد مجمّع Inno Setup
$iscc = @("${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe", "$env:ProgramFiles\Inno Setup 6\ISCC.exe") |
        Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $iscc) { throw "Inno Setup 6 غير مثبّت. نزّله من https://jrsoftware.org/isdl.php" }

# 4) تجميع ملف التثبيت
Write-Host "تجميع ملف التثبيت ..." -ForegroundColor Cyan
& $iscc "/DSourceBin=$binDir" $iss
if ($LASTEXITCODE -ne 0) { throw "فشل تجميع ملف التثبيت." }

Write-Host "تم! ملف التثبيت في: $(Join-Path $PSScriptRoot 'Output\Sestamk-Setup.exe')" -ForegroundColor Green
