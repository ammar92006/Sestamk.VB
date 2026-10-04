# Builds the whole solution (Release) and packages the installer with Inno Setup.
# Usage: .\build_installer.ps1 [-Configuration Release] [-SkipTests]
#
# ملاحظة: هذا السكربت صار واجهة رقيقة حول Build.ps1 في جذر المستودع لتفادي ازدواج
# منطق البناء. سابقاً كان يبني WindowsApp1 فقط، بينما Setup_Sestamk.iss يشترط وجود
# أداة التحديث (Sestamk.VB.Updater.exe) في WindowsApp1\tools — وكان البناء يفشل
# من نسخة نظيفة لأن تلك الأداة تُنتَج من مشروع آخر.
param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",
    [switch]$SkipTests
)

$ErrorActionPreference = "Stop"
$root = Split-Path $PSScriptRoot -Parent
$buildScript = Join-Path $root "Build.ps1"

if (-not (Test-Path $buildScript)) {
    throw "لم يتم العثور على سكربت البناء الموحّد: $buildScript"
}

$buildArgs = @("-Configuration", $Configuration, "-Installer")
if ($SkipTests) { $buildArgs += "-SkipTests" }

& $buildScript @buildArgs
if ($LASTEXITCODE -ne 0) { throw "فشل بناء الحزمة أو المثبّت." }

Write-Host ""
Write-Host "تم إنتاج المثبّت: $(Join-Path $root 'OutputSetup\Sestamk_Setup_v2026.exe')" -ForegroundColor Green
