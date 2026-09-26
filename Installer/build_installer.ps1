# Builds the program (Release) and packages the installer with Inno Setup.
# Usage: .\build_installer.ps1 [-Configuration Release]
param(
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"
$root    = Split-Path $PSScriptRoot -Parent
$proj    = Join-Path $root "WindowsApp1\Sestamk.VB.vbproj"
$binDir  = Join-Path $root "WindowsApp1\bin\$Configuration"
$iss     = Join-Path $root "Setup_Sestamk.iss"

# 1) Locate MSBuild
$msbuild = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" `
    -latest -requires Microsoft.Component.MSBuild `
    -find "MSBuild\**\Bin\MSBuild.exe" | Select-Object -First 1
if (-not $msbuild) {
    $fallbackMsbuild = "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"
    if (Test-Path $fallbackMsbuild) {
        $msbuild = $fallbackMsbuild
    } else {
        throw "MSBuild not found. Please install Visual Studio or Build Tools."
    }
}

# 2) Build project
Write-Host "Building project ($Configuration) ..." -ForegroundColor Cyan
& $msbuild $proj /t:Build /p:Configuration=$Configuration /v:minimal /nologo
if ($LASTEXITCODE -ne 0) { throw "Project build failed." }

# 3) Locate Inno Setup Compiler
$iscc = @("${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe", "$env:ProgramFiles\Inno Setup 6\ISCC.exe") |
        Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $iscc) { throw "Inno Setup 6 is not installed. Download from https://jrsoftware.org/isdl.php" }

# 4) Compile installer
Write-Host "Compiling setup installer with Inno Setup ($iss) ..." -ForegroundColor Cyan
& $iscc "/DSourceBin=$binDir" $iss
if ($LASTEXITCODE -ne 0) { throw "Installer compilation failed." }

$finalSetup = Join-Path $root "OutputSetup\Sestamk_Setup_v2026.exe"
Write-Host "Done! Installer created successfully at: $finalSetup" -ForegroundColor Green