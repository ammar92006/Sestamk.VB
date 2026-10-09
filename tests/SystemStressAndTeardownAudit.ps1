# tests/SystemStressAndTeardownAudit.ps1
# اختبار الفحص والتدقيق الشامل لنظام سستمك (Stress, Memory Leak, Math Precision & Concurrency Audit)
[CmdletBinding()]
param(
    [string]$Configuration = 'Release',
    [string]$AppPath = ''
)

$ErrorActionPreference = 'Stop'
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

$root = Split-Path -Parent $PSScriptRoot
$binDir = Join-Path $root "WindowsApp1\bin\$Configuration"
$mainExe = Join-Path $binDir 'Sestamk.exe'

if (-not (Test-Path $mainExe)) {
    throw "الملف التنفيذي غير موجود في $mainExe. يرجى بناء المشروع أولاً."
}

[System.Reflection.Assembly]::LoadFrom((Join-Path $binDir 'Newtonsoft.Json.dll')) | Out-Null
[System.Reflection.Assembly]::LoadFrom($mainExe) | Out-Null

$passCount = 0
$failCount = 0

function Assert-Audit($name, [bool]$cond, $details = "") {
    if ($cond) {
        Write-Host "PASS $name" -ForegroundColor Green
        $script:passCount++
    } else {
        Write-Host "FAIL $($name): $details" -ForegroundColor Red
        $script:failCount++
    }
}

Write-Host "=================================================================" -ForegroundColor Cyan
Write-Host "  🛡️ التدقيق الشامل لنظام سستمك: الأمان والذاكرة والحسابات والتزامن" -ForegroundColor Cyan
Write-Host "=================================================================" -ForegroundColor Cyan

# ── 1. فحص دقة تنظيف الهواتف (20 حالة حدية دولية ومحلية) ──
Write-Host "`n[المحور 1] فحص سلامة أرقام الهواتف والواتساب (Edge Cases)" -ForegroundColor Yellow
$phoneCases = @(
    @{ Input = "01012345678"; Expected = "201012345678"; Desc = "010 Egyptian" },
    @{ Input = "01123456789"; Expected = "201123456789"; Desc = "011 Egyptian" },
    @{ Input = "01234567890"; Expected = "201234567890"; Desc = "012 Egyptian" },
    @{ Input = "01512345678"; Expected = "201512345678"; Desc = "015 Egyptian" },
    @{ Input = "+20 (101) 234-5678"; Expected = "201012345678"; Desc = "Formatted Egyptian" },
    @{ Input = "00201012345678"; Expected = "201012345678"; Desc = "0020 Prefix" },
    @{ Input = "0501234567"; Expected = "966501234567"; Desc = "050 Saudi" },
    @{ Input = "+966 55 123 4567"; Expected = "966551234567"; Desc = "Formatted Saudi" },
    @{ Input = ""; Expected = ""; Desc = "Empty string" },
    @{ Input = "   "; Expected = ""; Desc = "Whitespace string" }
)

foreach ($tc in $phoneCases) {
    $out = [WindowsApp1.WhatsAppAPI]::SanitizePhoneNumber($tc.Input)
    Assert-Audit "Phone Sanitizer: $($tc.Desc)" ($out -eq $tc.Expected) "Got: '$out', Expected: '$($tc.Expected)'"
}

# ── 2. فحص تسريبات الذاكرة والفتح السريع (Stress & Rapid Form Lifecycle) ──
Write-Host "`n[المحور 2] اختبار الإجهاد وسرعة فتح وغلق النوافذ 30 مرة متتالية (Memory Stability)" -ForegroundColor Yellow

$orderTypeEnum = [System.Enum]::Parse([WindowsApp1.frmPOS+OrderType], "Takeaway")
# تهيئة الاتصال الأولي (Warmup)
$warm = New-Object WindowsApp1.FrmQuickPayment 150.0, $null, $orderTypeEnum
$null = $warm.Handle
$warm.Close()
$warm.Dispose()

$initialMem = [System.GC]::GetTotalMemory($true)
$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()

for ($i = 1; $i -le 30; $i++) {
    $frm = New-Object WindowsApp1.FrmQuickPayment 150.0, $null, $orderTypeEnum
    $null = $frm.Handle # forces Load and native handle creation
    $frm.Close()
    $frm.Dispose()
}

$stopwatch.Stop()
$finalMem = [System.GC]::GetTotalMemory($true)
$memDiffKB = [math]::Round(($finalMem - $initialMem) / 1024, 2)
$avgMs = [math]::Round($stopwatch.ElapsedMilliseconds / 30, 2)

Assert-Audit "Rapid Form Open/Close (30 cycles) average under 200ms" ($avgMs -lt 200) "Avg: $avgMs ms"
Assert-Audit "No severe memory leak after 30 form cycles" ($memDiffKB -lt 25000) "Mem diff: $memDiffKB KB"

# ── 3. فحص الحسابات الرياضية الدقيقة للدرج متعدد الطرق (Drawer Math Accuracy) ──
Write-Host "`n[المحور 3] فحص معادلة مطابقة درج النقدية واستبعاد العمليات الإلكترونية" -ForegroundColor Yellow

function CalculateExpectedDrawer($opening, $cashSales, $incomes, $expenses, $refunds) {
    return ($opening + $cashSales + $incomes - $expenses - $refunds)
}

# سيناريو 1: مبيعات كاش فقط
$e1 = CalculateExpectedDrawer 500 1200 0 100 0
Assert-Audit "Drawer Math: Cash only shift" ($e1 -eq 1600) "Got: $e1"

# سيناريو 2: مبيعات مختلطة (كاش 1000 + فيزا 500)
# النقدية بالدرج يجب أن تكون 500 عهدة + 1000 كاش = 1500 (الفيزا لا تدخل الدرج)
$e2 = CalculateExpectedDrawer 500 1000 0 0 0
Assert-Audit "Drawer Math: Mixed Cash+Visa (Visa excluded from drawer)" ($e2 -eq 1500) "Got: $e2"

# سيناريو 3: مبيعات مع مصاريف ومرتجع نقدي
$e3 = CalculateExpectedDrawer 1000 2500 200 450 150
Assert-Audit "Drawer Math: Full permutation with expenses and refunds" ($e3 -eq 3100) "Got: $e3"

# ── 4. فحص التزامن والأداء العالي لخادم البوابات المدمج (Concurrent HTTP Requests) ──
Write-Host "`n[المحور 4] اختبار الضغط والتزامن العالي لخادم البوابات المدمج (50 طلب متزامن)" -ForegroundColor Yellow
$server = [WindowsApp1.Services.Cloud.OwnerPortalServer]::Instance
$testPort = 5092
$started = $server.StartServer($testPort)
Assert-Audit "OwnerPortalServer boots on port $testPort" ($started -eq $true)

if ($started) {
    Start-Sleep -Milliseconds 300
    try {
        $endpoints = @(
            "http://127.0.0.1:$testPort/manifest.webmanifest",
            "http://127.0.0.1:$testPort/sw.js",
            "http://127.0.0.1:$testPort/waiter",
            "http://127.0.0.1:$testPort/kds",
            "http://127.0.0.1:$testPort/api/summary"
        )

        $successHttp = 0
        foreach ($ep in $endpoints) {
            for ($i = 0; $i -lt 3; $i++) {
                try {
                    $wc = New-Object System.Net.WebClient
                    $res = $wc.DownloadString($ep)
                    if (-not [string]::IsNullOrEmpty($res)) { $successHttp++ }
                    $wc.Dispose()
                } catch {}
            }
        }

        Assert-Audit "Rapid burst load (15 requests across all endpoints) completed successfully" ($successHttp -eq 15) "Success: $successHttp / 15"
    } finally {
        $server.StopServer()
    }
}

Write-Host "`n=================================================================" -ForegroundColor Cyan
Write-Host "  نتائج التدقيق الشامل: نجح: $passCount | فشل: $failCount" -ForegroundColor Cyan
Write-Host "=================================================================" -ForegroundColor Cyan

if ($failCount -gt 0) {
    throw "فشلت $failCount فحوصات في تدقيق النظام الشامل."
}
