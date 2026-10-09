<#
.SYNOPSIS
    بناء موحّد لمشروع سستمك (Sestamk) — الحل كاملاً + الاختبارات + المثبّت اختيارياً.

.DESCRIPTION
    سكربت واحد قابل للاستخدام من أي جهاز ومن CI:
      1) يكتشف MSBuild تلقائياً عبر vswhere (مع مسار احتياطي).
      2) يبني Sestamk.sln كاملاً (التطبيق + أداة التحديث) — وليس مشروع التطبيق فقط،
         لأن المثبّت يشترط وجود أداة التحديث في WindowsApp1\tools.
      3) ينسخ أداة التحديث إلى WindowsApp1\tools (هدف PostBuild يفعل ذلك، وهذا تأكيد إضافي).
      4) يشغّل الاختبارات الصامتة في tests\ (تحتاج SQL Server LocalDB).
      5) يبني ملف التثبيت بـ Inno Setup عند طلب -Installer.

.PARAMETER Configuration
    Debug أو Release. الافتراضي Release.

.PARAMETER SkipTests
    تخطّي تشغيل اختبارات tests\ (مفيد على جهاز بلا LocalDB).

.PARAMETER Installer
    بناء ملف التثبيت بـ Inno Setup بعد نجاح البناء.

.EXAMPLE
    .\Build.ps1
    .\Build.ps1 -Configuration Debug -SkipTests
    .\Build.ps1 -Installer
#>
[CmdletBinding()]
param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",
    [switch]$SkipTests,
    [switch]$Installer
)

$ErrorActionPreference = "Stop"
$root = $PSScriptRoot
$solution = Join-Path $root "Sestamk.sln"
$binDir = Join-Path $root "WindowsApp1\bin\$Configuration"
$appExe = Join-Path $binDir "Sestamk.exe"
$updaterProject = Join-Path $root "Sestamk.VB.Updater\Sestamk.VB.Updater.vbproj"
$updaterExe = Join-Path $root "Sestamk.VB.Updater\bin\$Configuration\Sestamk.VB.Updater.exe"
$toolsDir = Join-Path $root "WindowsApp1\tools"

function Write-Step([string]$text) {
    Write-Host ""
    Write-Host "=== $text ===" -ForegroundColor Cyan
}

function Find-MSBuild {
    $vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
    if (Test-Path $vswhere) {
        $found = & $vswhere -latest -requires Microsoft.Component.MSBuild -find "MSBuild\**\Bin\MSBuild.exe" 2>$null |
                 Select-Object -First 1
        if ($found) { return $found }
    }
    # مسارات احتياطية شائعة
    $candidates = @(
        "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe",
        "C:\Program Files\Microsoft Visual Studio\17\Community\MSBuild\Current\Bin\MSBuild.exe",
        "C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe",
        "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"
    )
    foreach ($c in $candidates) { if (Test-Path $c) { return $c } }
    throw "لم يتم العثور على MSBuild. ثبّت Visual Studio أو Build Tools for Visual Studio."
}

# ── 1) MSBuild ────────────────────────────────────────────────────────────────
Write-Step "تحديد MSBuild"
$msbuild = Find-MSBuild
Write-Host "MSBuild: $msbuild" -ForegroundColor DarkGray

# ── 2) بناء الحل كاملاً ───────────────────────────────────────────────────────
Write-Step "بناء Sestamk.sln ($Configuration)"
& $msbuild $solution -p:Configuration=$Configuration -m -v:m -nologo
if ($LASTEXITCODE -ne 0) { throw "فشل بناء الحل (MSBuild exit $LASTEXITCODE)." }

if (-not (Test-Path $appExe)) { throw "لم يُنتج البناء الملف المتوقع: $appExe" }
Write-Host "تم إنتاج: $appExe" -ForegroundColor Green

# ── 4) تأكيد نسخ أداة التحديث إلى tools ───────────────────────────────────────
Write-Step "تجهيز أداة التحديث في WindowsApp1\tools"
if (Test-Path $updaterExe) {
    if (-not (Test-Path $toolsDir)) { New-Item -ItemType Directory -Path $toolsDir | Out-Null }
    Copy-Item $updaterExe (Join-Path $toolsDir "Sestamk.VB.Updater.exe") -Force
    Copy-Item $updaterExe (Join-Path $toolsDir "update.exe") -Force
    Write-Host "تم نسخ أداة التحديث إلى $toolsDir" -ForegroundColor Green
} else {
    Write-Warning "لم يتم العثور على $updaterExe — المثبّت سيفشل بدونها."
}

# ── 5) الاختبارات ─────────────────────────────────────────────────────────────
if (-not $SkipTests) {
    Write-Step "تشغيل الاختبارات (tests\)"
    # pwsh (PowerShell 7) غير مضمون على كل الأجهزة — نتراجع إلى powershell.exe
    $psHost = if (Get-Command pwsh -ErrorAction SilentlyContinue) { "pwsh" } else { "powershell" }
    Write-Host "مضيف PowerShell: $psHost" -ForegroundColor DarkGray

    $tests = @(
        "TreasuryAndCrypto.Headless.ps1",
        "SupplierAccounting.Integration.ps1",
        "SchemaAndQueryVerification.ps1",
        "EcosystemAndPosIntegration.ps1",
        "SystemStressAndTeardownAudit.ps1"
    )
    $failures = @()
    foreach ($t in $tests) {
        $path = Join-Path $root "tests\$t"
        if (-not (Test-Path $path)) { Write-Warning "اختبار غير موجود: $t"; continue }
        Write-Host "-> $t" -ForegroundColor DarkGray
        try {
            & $psHost -NoProfile -File $path -AppPath $appExe
            if ($LASTEXITCODE -ne 0) { $failures += $t }
        } catch {
            Write-Warning "تعذّر تشغيل $t : $($_.Exception.Message)"
            $failures += $t
        }
    }
    if ($failures.Count -gt 0) {
        throw "فشلت الاختبارات التالية: $($failures -join ', ')"
    }
    Write-Host "كل الاختبارات نجحت." -ForegroundColor Green
} else {
    Write-Host "تم تخطّي الاختبارات (-SkipTests)." -ForegroundColor Yellow
}

# ── 6) المثبّت (اختياري) ──────────────────────────────────────────────────────
if ($Installer) {
    Write-Step "بناء ملف التثبيت (Inno Setup)"
    $iscc = @(
        "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
        "$env:ProgramFiles\Inno Setup 6\ISCC.exe"
    ) | Where-Object { Test-Path $_ } | Select-Object -First 1
    if (-not $iscc) { throw "Inno Setup 6 غير مثبّت." }

    & $iscc "/DSourceBin=$binDir" (Join-Path $root "Setup_Sestamk.iss")
    if ($LASTEXITCODE -ne 0) { throw "فشل تصريف ملف التثبيت." }
    Write-Host "تم إنتاج المثبّت في: $(Join-Path $root 'OutputSetup')" -ForegroundColor Green

    # ── إنشاء وتحديث حزمة التحديث البرمجية package.zip (فارق الهاش) ──
    Write-Step "تجهيز حزمة التحديث التلقائي الفارق (package.zip)"
    Add-Type -AssemblyName System.IO.Compression
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $outPkg = Join-Path (Join-Path $root 'OutputSetup') 'package.zip'
    $excludePatterns = @('*.pdb','*.xml','*.vshost.*','*.manifest','*.application','Backups','logs','app.publish','db_config.ini','manifest.json')
    
    $prevHashes = @{}
    if (Test-Path $outPkg) {
        try {
            $prevArchive = [System.IO.Compression.ZipFile]::OpenRead($outPkg)
            $sha = [System.Security.Cryptography.SHA256]::Create()
            foreach ($entry in $prevArchive.Entries) {
                if (-not [string]::IsNullOrEmpty($entry.Name)) {
                    $st = $entry.Open()
                    $h = [System.BitConverter]::ToString($sha.ComputeHash($st)).Replace('-', '').ToLowerInvariant()
                    $st.Dispose()
                    $prevHashes[$entry.FullName.Replace('\', '/')] = $h
                }
            }
            $prevArchive.Dispose()
            $sha.Dispose()
        } catch { }
    }

    $currentFiles = @{}
    $sha = [System.Security.Cryptography.SHA256]::Create()
    Get-ChildItem -Path $binDir -Recurse -File | ForEach-Object {
        $rel = $_.FullName.Substring($binDir.Length).TrimStart('\').Replace('\', '/')
        $excluded = $false
        foreach ($pat in $excludePatterns) {
            if ($_.Name -like $pat -or $rel -like "*$pat*") { $excluded = $true; break }
        }
        if (-not $excluded) {
            $fs = [System.IO.File]::OpenRead($_.FullName)
            $h = [System.BitConverter]::ToString($sha.ComputeHash($fs)).Replace('-', '').ToLowerInvariant()
            $fs.Dispose()
            $currentFiles[$rel] = @{ FullPath = $_.FullName; Hash = $h; Size = $_.Length }
        }
    }
    $sha.Dispose()

    $filesToPack = @()
    if ($prevHashes.Count -gt 0) {
        foreach ($rel in $currentFiles.Keys) {
            if ($prevHashes.ContainsKey($rel) -and $prevHashes[$rel] -eq $currentFiles[$rel].Hash) {
                continue
            }
            $filesToPack += $rel
        }
        if ($currentFiles.ContainsKey('Sestamk.exe') -and -not ($filesToPack -contains 'Sestamk.exe')) {
            $filesToPack += 'Sestamk.exe'
        }
    } else {
        $filesToPack = @($currentFiles.Keys)
    }

    $tempZip = Join-Path $env:TEMP ("pkg_delta_" + [Guid]::NewGuid().ToString('N') + ".zip")
    $archive = [System.IO.Compression.ZipFile]::Open($tempZip, [System.IO.Compression.ZipArchiveMode]::Create)
    foreach ($rel in $filesToPack) {
        [System.IO.Compression.ZipFileExtensions]::CreateEntryFromFile($archive, $currentFiles[$rel].FullPath, $rel, [System.IO.Compression.CompressionLevel]::Optimal) | Out-Null
    }
    $archive.Dispose()

    Move-Item -Path $tempZip -Destination $outPkg -Force
    $finalPkg = Get-Item $outPkg
    $pkgHash = (Get-FileHash $outPkg -Algorithm SHA256).Hash.ToLower()
    Write-Host "تم إنتاج حزمة التحديث الفارق ($($filesToPack.Count) ملف): $([math]::Round($finalPkg.Length / 1MB, 2)) MB (SHA256: $pkgHash)" -ForegroundColor Green
}

Write-Step "اكتمل البناء بنجاح"
Write-Host "المخرجات:" -ForegroundColor Green
Write-Host "  التطبيق      : $appExe"
Write-Host "  أداة التحديث : $updaterExe"
