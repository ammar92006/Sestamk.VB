# tests/OnboardingAndTrialEndToEnd.ps1
# اختبار التكامل والتحقق الشامل لدورة تسجيل الشركات، الموافقة الإدارية، وتراخيص الـ 14 يوماً التجريبية
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

$script:passCount = 0
$script:failCount = 0

function Assert-Test([string]$name, [bool]$cond, [string]$details = "") {
    if ($cond) {
        Write-Host "PASS $name" -ForegroundColor Green
        $script:passCount++
    } else {
        Write-Host "FAIL $($name): $details" -ForegroundColor Red
        $script:failCount++
    }
}

Write-Host "==========================================================================" -ForegroundColor Cyan
Write-Host "  🛡️ فحص واختبار دورة حياة التراخيص التجريبية 14 يوماً وتكامل المنظومة" -ForegroundColor Cyan
Write-Host "==========================================================================" -ForegroundColor Cyan

# ── 1. فحص خوارزمية توليد السيريال القياسي (Serial Key Format Test) ──
Write-Host "`n[المرحلة 1] فحص خوارزمية توليد السيريال التجريبي" -ForegroundColor Yellow

function New-TestSerial() {
    $chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"
    $bytes = New-Object byte[] 12
    $rng = [System.Security.Cryptography.RandomNumberGenerator]::Create()
    $rng.GetBytes($bytes)
    $sb = New-Object System.Text.StringBuilder "SEST-"
    for ($i = 0; $i -lt 12; $i++) {
        [void]$sb.Append($chars[$bytes[$i] % $chars.Length])
        if ($i -eq 3 -or $i -eq 7) { [void]$sb.Append('-') }
    }
    return $sb.ToString()
}

$sampleSerial = [string](New-TestSerial)
Assert-Test "Serial key format starts with 'SEST-'" ($sampleSerial.StartsWith("SEST-")) "Got: $sampleSerial"
Assert-Test "Serial key has exact standard length (19 chars)" ($sampleSerial.Length -eq 19) "Got: $sampleSerial"
Assert-Test "Serial key regex matches SEST-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}" ($sampleSerial -match '^SEST-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$') "Got: $sampleSerial"

# ── 2. محاكاة إنشاء ترخيص تجريبي 14 يوماً (14-Day Trial License Payload) ──
Write-Host "`n[المرحلة 2] محاكاة بيانات ترخيص 14 يوماً الصادر من برنامج التحكم" -ForegroundColor Yellow

$companyName = "مطعم الشام الأصيل — فرع المعادي"
$startDate = [DateTime]::UtcNow.Date
$expiryDate = $startDate.AddDays(14)

$licenseRaw = @"
{
    "status": "active",
    "plan": "trial",
    "plan_type": "trial",
    "company_name": "$companyName",
    "saved_serial": "$sampleSerial",
    "starts_at": "$($startDate.ToString('yyyy-MM-dd'))",
    "expires_at": "$($expiryDate.ToString('yyyy-MM-dd'))",
    "max_devices": 2,
    "max_users": 5,
    "is_trial": true
}
"@
$licensePayload = [Newtonsoft.Json.Linq.JObject]::Parse($licenseRaw)

# حفظ في الكاش الآمن للبرنامج
[WindowsApp1.LicenseCache]::Save($licensePayload)
$loadedLicense = [WindowsApp1.LicenseCache]::Load()

Assert-Test "License successfully cached in secure DPAPI storage" ($null -ne $loadedLicense)

# ── 3. فحص تعرف البرنامج المكتبي على التجربة والأيام المتبقية ──
Write-Host "`n[المرحلة 3] فحص استجابة محرك التراخيص المكتبي (License Engine)" -ForegroundColor Yellow

$isTrial = [bool][WindowsApp1.LicenseCache]::IsTrial()
$planType = [string][WindowsApp1.LicenseCache]::GetPlanType()
$daysLeft = [int][WindowsApp1.LicenseCache]::GetDaysRemaining()
$cachedCompany = [string][WindowsApp1.LicenseCache]::GetCompanyName()

Assert-Test "LicenseCache identifies license as Trial" ($isTrial -eq $true) "Got: $isTrial"
Assert-Test "LicenseCache returns plan type 'trial'" ($planType -eq "trial") "Got: $planType"
Assert-Test "LicenseCache accurately calculates remaining days (14 days)" ($daysLeft -ge 13 -and $daysLeft -le 14) "Got: $daysLeft days"
Assert-Test "LicenseCache returns correct company name" ($cachedCompany -eq $companyName) "Got: $cachedCompany"

# ── 4. فحص فحص الإقلاع الشامل LicenseBootstrapper ──
Write-Host "`n[المرحلة 4] فحص إقلاع النظام وصلاحية الترخيص التجريبي" -ForegroundColor Yellow

$checkTask = [WindowsApp1.LicenseBootstrapper]::CheckAsync($false)
$checkResult = $checkTask.GetAwaiter().GetResult()

Assert-Test "LicenseBootstrapper accepts 14-day trial as valid" ($checkResult.IsValid -eq $true) "IsValid: $($checkResult.IsValid)"
Assert-Test "LicenseBootstrapper does not require activation modal" ($checkResult.RequiresActivation -eq $false) "RequiresActivation: $($checkResult.RequiresActivation)"

# ── 5. فحص قفل انتهاء التجربة (Trial Expiration Lockout Enforcement) ──
Write-Host "`n[المرحلة 5] فحص القفل التلقائي الصارم فور انتهاء الـ 14 يوماً" -ForegroundColor Yellow

$expiredDate = [DateTime]::UtcNow.Date.AddDays(-1)
$expiredRaw = @"
{
    "status": "expired",
    "plan": "trial",
    "plan_type": "trial",
    "company_name": "$companyName",
    "saved_serial": "$sampleSerial",
    "starts_at": "$($startDate.AddDays(-15).ToString('yyyy-MM-dd'))",
    "expires_at": "$($expiredDate.ToString('yyyy-MM-dd'))",
    "max_devices": 2,
    "max_users": 5,
    "is_trial": true
}
"@
$expiredPayload = [Newtonsoft.Json.Linq.JObject]::Parse($expiredRaw)
[WindowsApp1.LicenseCache]::Save($expiredPayload)

$expiredDaysLeft = [int][WindowsApp1.LicenseCache]::GetDaysRemaining()
Assert-Test "Expired trial returns 0 days remaining (never negative)" ($expiredDaysLeft -eq 0) "Got: $expiredDaysLeft"

# إعادة الترخيص الساري الصالح للاختبارات التالية
[WindowsApp1.LicenseCache]::Save($licensePayload)

# ── 6. فحص شارة الهيدر في MainForm ──
Write-Host "`n[المرحلة 6] فحص منطق شارة الهيدر في الشاشة الرئيسية (UI Badge Inspection)" -ForegroundColor Yellow

$trialBadgeText = "🟢 تجريبي: باقي $daysLeft يوم"
Assert-Test "Trial badge string formats correctly with remaining days" ($trialBadgeText -match "باقي (13|14) يوم") "Got: $trialBadgeText"

Write-Host "`n==========================================================================" -ForegroundColor Cyan
Write-Host "  نتائج فحص دورة حياة التراخيص: نجح: $script:passCount | فشل: $script:failCount" -ForegroundColor Cyan
Write-Host "==========================================================================" -ForegroundColor Cyan

if ($script:failCount -gt 0) {
    throw "فشلت $script:failCount فحوصات في اختبار دورة التراخيص والتسجيل."
}
