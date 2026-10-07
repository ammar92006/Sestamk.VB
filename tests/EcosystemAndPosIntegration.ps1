# tests/EcosystemAndPosIntegration.ps1
# اختبارات التكامل للأنظمة الجديدة: خادم البوابات، البحث بالباركود، دورة المطبخ، ومطابقة الدرج متعدد الطرق
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

# تحميل مكتبات البرنامج
[System.Reflection.Assembly]::LoadFrom((Join-Path $binDir 'Newtonsoft.Json.dll')) | Out-Null
[System.Reflection.Assembly]::LoadFrom($mainExe) | Out-Null

$passCount = 0
$failCount = 0

function Assert-Condition($name, [bool]$cond, $details = "") {
    if ($cond) {
        Write-Host "PASS $name" -ForegroundColor Green
        $script:passCount++
    } else {
        Write-Host "FAIL $($name): $details" -ForegroundColor Red
        $script:failCount++
    }
}

Write-Host "=== 1. فحص تنظيف وتنسيق أرقام الواتساب (WhatsApp Phone Sanitizer) ===" -ForegroundColor Cyan
$p1 = [WindowsApp1.WhatsAppAPI]::SanitizePhoneNumber("01012345678")
Assert-Condition "Egyptian 010 number formatted to 2010..." ($p1 -eq "201012345678") "Got: $p1"

$p2 = [WindowsApp1.WhatsAppAPI]::SanitizePhoneNumber("+20 11-22-33-44-55")
Assert-Condition "Egyptian formatted with plus/spaces" ($p2 -eq "201122334455") "Got: $p2"

$p3 = [WindowsApp1.WhatsAppAPI]::SanitizePhoneNumber("0512345678")
Assert-Condition "Saudi 05 number formatted to 9665..." ($p3 -eq "966512345678") "Got: $p3"

$p4 = [WindowsApp1.WhatsAppAPI]::SanitizePhoneNumber("00201599887766")
Assert-Condition "International double-zero prefix stripped" ($p4 -eq "201599887766") "Got: $p4"

Write-Host "`n=== 2. فحص قوالب رسائل الواتساب (WhatsApp Templates) ===" -ForegroundColor Cyan
$dummyInv = New-Object WindowsApp1.InvoiceModel
$dummyInv.InvoiceNumber = "2026-TEST"
$dummyInv.NetTotal = 290.00
$dummyInv.PaymentType = "فيزا"
$dummyInv.OrderType = 2
$invMsg = [WindowsApp1.WhatsAppAPI]::FormatInvoiceMessage($dummyInv, "عميل تجريبي", "مطعم سستمك", "01000000000")
Assert-Condition "Invoice message contains invoice number" ($invMsg.Contains("2026-TEST"))
Assert-Condition "Invoice message contains payment type" ($invMsg.Contains("فيزا"))
Assert-Condition "Invoice message contains net total" ($invMsg.Contains("290"))

$shiftMsg = [WindowsApp1.WhatsAppAPI]::FormatShiftZReportMessage("S-101", "أحمد الكاشير", [DateTime]::Now, [DateTime]::Now, 500, 1500, 1000, 500, 0, 100, 1400, 1400, 0)
Assert-Condition "Shift Z-Report message contains shift number" ($shiftMsg.Contains("S-101"))
Assert-Condition "Shift Z-Report contains drawer cash" ($shiftMsg.Contains("1,000") -or $shiftMsg.Contains("1000"))
Assert-Condition "Shift Z-Report contains visa sales" ($shiftMsg.Contains("500"))

Write-Host "`n=== 3. فحص قاعدة البيانات المحلية واستعلامات الباركود والبحث ===" -ForegroundColor Cyan
# إنشاء اتصال محلي
$cs = "Server=.\SQLEXPRESS;Database=SestamkDB;Integrated Security=True;TrustServerCertificate=True"
$canConnect = $false
try {
    $cn = New-Object System.Data.SqlClient.SqlConnection($cs)
    $cn.Open()
    $canConnect = $true
    $cn.Close()
} catch {}

if ($canConnect) {
    $repo = New-Object WindowsApp1.POSRepository($cs)

    # 1. فحص البحث
    $searchRes = $repo.SearchProducts("برجر")
    Assert-Condition "SearchProducts returns products for Arabic keyword" ($searchRes.Count -gt 0) "Count: $($searchRes.Count)"

    # 2. فحص صنف غير موجود
    $emptyProd = $repo.GetProductByBarcode("999999999999999999999")
    Assert-Condition "Non-existent barcode returns null" ($emptyProd -eq $null)

    # 3. فحص دورة طلب المطبخ وتجنب إلغاء الطلبات السارية
    $ko1 = New-Object WindowsApp1.KitchenOrderModel
    $ko1.OrderType = 2
    $ko1.TableID = 9999
    $ko1.TableName = "طاولة اختبار"
    $ko1.ServerName = "فاحص آلي"
    $ko1.Status = [WindowsApp1.KitchenOrderStatus]::New
    $ko1.Items.Add((New-Object WindowsApp1.KitchenOrderItemModel -Property @{
        ProductID = 1; ProductName = "صنف رئيسي في الفرن"; Quantity = 1; StationName = "المطبخ"
    }))

    $ko1Id = $repo.CreateKitchenOrderAsync($ko1).GetAwaiter().GetResult()
    Assert-Condition "Created primary kitchen order" ($ko1Id -gt 0) "ID: $ko1Id"

    # طلب استكمالي لنفس الطاولة
    $ko2 = New-Object WindowsApp1.KitchenOrderModel
    $ko2.OrderType = 2
    $ko2.TableID = 9999
    $ko2.TableName = "طاولة اختبار"
    $ko2.ServerName = "فاحص آلي"
    $ko2.Status = [WindowsApp1.KitchenOrderStatus]::New
    $ko2.Items.Add((New-Object WindowsApp1.KitchenOrderItemModel -Property @{
        ProductID = 2; ProductName = "مشروب إضافي"; Quantity = 1; StationName = "البار"
    }))

    $ko2Id = $repo.CreateKitchenOrderAsync($ko2).GetAwaiter().GetResult()
    Assert-Condition "Created follow-up kitchen order" ($ko2Id -gt 0) "ID: $ko2Id"

    # التحقق من أن الطلب الأول لم يُلغَ (Status <> 4)
    $activeOrders = $repo.GetActiveKitchenOrders()
    $firstOrderActive = ($activeOrders | Where-Object { $_.KitchenOrderID -eq $ko1Id })
    Assert-Condition "Follow-up order did NOT cancel in-progress kitchen order" ($firstOrderActive -ne $null)

    # تنظيف الطلبات التجريبية
    $cn2 = New-Object System.Data.SqlClient.SqlConnection($cs)
    $cn2.Open()
    $cmdDel = $cn2.CreateCommand()
    $cmdDel.CommandText = "DELETE FROM KitchenOrders WHERE KitchenOrderID IN ($ko1Id, $ko2Id);"
    $cmdDel.ExecuteNonQuery() | Out-Null
    $cn2.Close()
} else {
    Write-Host "تخطي فحوصات قاعدة البيانات الحية (SQLEXPRESS غير متصل)." -ForegroundColor Yellow
}

Write-Host "`n=== 4. فحص خادم البوابات الذكية المدمج (OwnerPortalServer Endpoints) ===" -ForegroundColor Cyan
$server = [WindowsApp1.Services.Cloud.OwnerPortalServer]::Instance
$testPort = 5088
$started = $server.StartServer($testPort)
Assert-Condition "OwnerPortalServer starts on test port $testPort" ($started -eq $true)

if ($started) {
    Start-Sleep -Milliseconds 300
    try {
        # 1. اختبار الـ PWA Manifest
        $resM = Invoke-WebRequest -Uri "http://127.0.0.1:$testPort/manifest.webmanifest" -UseBasicParsing
        Assert-Condition "GET /manifest.webmanifest returns 200" ($resM.StatusCode -eq 200)

        # 2. اختبار الـ Service Worker
        $resSW = Invoke-WebRequest -Uri "http://127.0.0.1:$testPort/sw.js" -UseBasicParsing
        Assert-Condition "GET /sw.js returns 200" ($resSW.StatusCode -eq 200)

        # 3. اختبار بوابة الويتر
        $resW = Invoke-WebRequest -Uri "http://127.0.0.1:$testPort/waiter" -UseBasicParsing
        Assert-Condition "GET /waiter returns 200" ($resW.StatusCode -eq 200)

        # 4. اختبار شاشة المطبخ
        $resK = Invoke-WebRequest -Uri "http://127.0.0.1:$testPort/kds" -UseBasicParsing
        Assert-Condition "GET /kds returns 200" ($resK.StatusCode -eq 200)

        # 5. اختبار API الملخص (التأكد من عدم وجود خطأ SQL OpeningDate)
        $summaryJson = (Invoke-WebRequest -Uri "http://127.0.0.1:$testPort/api/summary" -UseBasicParsing).Content | ConvertFrom-Json
        Assert-Condition "GET /api/summary returns valid JSON with success=true" ($summaryJson.success -eq $true)

        # 6. اختبار API المنيو
        $menuJson = (Invoke-WebRequest -Uri "http://127.0.0.1:$testPort/api/menu" -UseBasicParsing).Content | ConvertFrom-Json
        Assert-Condition "GET /api/menu returns success=true" ($menuJson.success -eq $true)
        if ($menuJson.categories.Count -gt 0) {
            $firstCat = $menuJson.categories[0]
            Assert-Condition "Category name is not empty" (-not [string]::IsNullOrWhiteSpace($firstCat.name)) "Name: $($firstCat.name)"
        }
    } finally {
        $server.StopServer()
    }
}

Write-Host "`n=== ملخص النتائج ===" -ForegroundColor Cyan
Write-Host "نجح: $passCount | فشل: $failCount"
if ($failCount -gt 0) {
    throw "فشلت $failCount اختبارات في مجموعة EcosystemAndPosIntegration."
}
