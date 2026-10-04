# دليل إصدار تحديث سستمك — Sestamk Release Process

> **هذا هو المرجع الدائم لخطوات رفع تحديث جديد** (أُعيد بناؤه وتوثيقه في 2026-10-04 أثناء إصدار v1.2.7
> من واقع إصدارات v1.2.3 → v1.2.6 السابقة). اتبعه بالترتيب مع كل إصدار.

---

## نظرة عامة على معمارية التحديث

```
العميل (Sestamk.exe) ──كل 5 دقائق──> جدول updates على Supabase (أحدث صف is_active للقناة)
        │
        └─ إذا version أحدث → ينبه المستخدم → ينزّل package.zip من GitHub Release
           → يتحقق من sha256 (إلزامي في v1.2.6+) → يفك فوق مجلد التطبيق عبر update.exe
```

- **GitHub Releases** (repo `ammar92006/Sestamk.VB`) يستضيف الملفات الثنائية: `package.zip` + `Sestamk_Setup_v2026.exe` + `manifest.json`.
- **Supabase جدول `updates`** هو مصدر الحقيقة للإصدار الأحدث: صف واحد لكل إصدار يحمل `manifest_url` و`full_install_url` والأحجام والملاحظات.
- **manifest.json** (جذر الريبو + نسخة موقعية في `E:\Sestamk\updates\manifest.json`) يصف الحزمة بالهاش والحجم.

## الخطوات بالترتيب

### 1) قبل أي شيء: نسخة احتياطية كاملة
```powershell
robocopy "E:\Sestamk\Sestamk.VB" "E:\Sestamk\Backup_Sestamk_VB_$(Get-Date -Format yyyyMMdd_HHmmss)" /E /R:1 /W:1
```

### 2) رفع أرقام الإصدار في 5 مواضع (كلها لازم تبقى متطابقة)
| الموضع | الملف |
|---|---|
| إصدار الملف للتطبيق | `WindowsApp1\My Project\AssemblyInfo.vb` → `AssemblyFileVersion` **و** `AssemblyInformationalVersion` |
| إصدار الأداة | `Sestamk.VB.Updater\My Project\AssemblyInfo.vb` → الثلاثة (`AssemblyVersion` أيضاً) |
| واجهة الـ installer | `Setup_Sestamk.iss` → `#define MyAppVersion` |
| وصف الحزمة | `manifest.json` → `version` وروابط الـ release الجديدة |
| قاعدة البيانات | صف جديد في جدول `updates` على Supabase (خطوة 6) |

### 3) بناء + اختبار
```powershell
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" Sestamk.sln -p:Configuration=Release -m -v:m -nologo
```
- تأكد أن `bin\Release\Sestamk.exe` يعرض `ProductVersion = الإصدار الجديد`.
- انسخ الأداة: `Sestamk.VB.Updater\bin\Release\Sestamk.VB.Updater.exe` → `WindowsApp1\tools\` (بالاسمين `Sestamk.VB.Updater.exe` و `update.exe`).
- شغّل الاختبارات الصامتة: `tests\TreasuryAndCrypto.Headless.ps1` + `SupplierAccounting.Integration.ps1`
  وفحوص `tests\DataIntegrityAudit.sql` على نسخة معزولة (انظر تعليقاتها).

### 4) بناء الأصول
**أ) installer (Inno Setup 6):**
```powershell
& "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" Setup_Sestamk.iss
# الناتج: OutputSetup\Sestamk_Setup_v<ver>.exe
```
**ب) package.zip** من محتويات `WindowsApp1\bin\Release` مع استثناءات:
`*.pdb, *.xml, *.vshost.*, *.manifest, *.application, Backups\*, logs\*, app.publish\*, db_config.ini`
(إعداد قاعدة البيانات المحلي لا يُشحن للعملاء أبداً).

**ج) الحسابات:**
```powershell
(Get-FileHash OutputSetup\package.zip -Algorithm SHA256).Hash.ToLower()
(Get-Item OutputSetup\package.zip).Length
```
ضع `sha256` و `size` في `manifest.json` (الـ Updater يرفض الحزمة بدون تطابق الهاش).

### 5) Git: Commit + Tag + Push
```bash
git add -A
git commit -m "Release v1.2.7: <ملخص التحديث>"
git tag -a v1.2.7 -m "Release v1.2.7"
git push origin master --follow-tags
```

### 6) GitHub Release بالأصول الثلاثة
الأصول الإلزامية (نفس الأسماء حرفياً):
- `package.zip`
- `Sestamk_Setup_v2026.exe` (اسم ثابت — الـ manifest والموقع يشيران إليه بهذا الاسم)
- `manifest.json` (نسخة الريبو المحدّثة — الـ `manifest_url` في Supabase يشير إليه)

عبر الويب: Releases → Draft new release → tag `v1.2.7` → ارفع الملفات → Publish.
أو عبر `gh` بعد `gh auth login`.

### 7) Supabase: نشر صف التحديث (هنا يبدأ وصول التحديث للعملاء)
جدول `updates` — أدرج صف الإصدار الجديد بنفس بنية صف v1.2.6:
```sql
INSERT INTO updates
(version, previous_version, channel, title, title_ar, description, whats_new,
 is_mandatory, min_version_to_update, manifest_url, full_install_url,
 delta_size_bytes, full_size_bytes, is_active, release_date)
VALUES ('1.2.7', '1.2.6', 'public', 'تحديث سيستمك ... v1.2.7', <نفس العنوان>,
        <وصف>, '<json array>', false, '0.0.0',
        'https://github.com/ammar92006/Sestamk.VB/releases/download/v1.2.7/manifest.json',
        'https://github.com/ammar92006/Sestamk.VB/releases/download/v1.2.7/Sestamk_Setup_v2026.exe',
        84879288, 123091905, true, CURRENT_DATE);
```
التنفيذ: SQL Editor في لوحة Supabase، أو Management API بـ sbp_ token (البروتوكول:
طلب التوكن → تنفيذ → حذف التوكن محلياً → المستخدم يعمل Revoke).
**تحقق بعدها:** `GET /rest/v1/updates?version=eq.1.2.7` بمفتاح anon يجب أن يعيد الصف.

### 8) الموقع الإلكتوري (اختياري للتحديث — مطلوب للتسويق)
- انسخ `manifest.json` إلى `E:\Sestamk\updates\manifest.json` (نسخة الموقع).
- أضف ملاحظات الإصدار لصفحة changelog (`Sestamk_POS_ERP_System`).
- الرفع يحدث تلقائياً بـ GitHub Actions (`deploy.yml` → FTP إلى InfinityFree) عند push لمونوريبو `E:\Sestamk`.

### 9) التحقق النهائي (من جهاز عميل أو قبل الإنتاج)
1. شغّل نسخة v1.2.6 → انتظر تنبيه التحديث (أو `BackgroundUpdateService.CheckNowAsync`).
2. تأكد من ظهور v1.2.7 وتطابق الهاش أثناء التنزيل.
3. بعد التحديث: تسجيل دخول + فاتورة + خزينة تعمل، وشريط الحالة يعرض الإصدار الجديد.

## سجل أخطاء لا تكررها
- **نسيت `AssemblyInformationalVersion`** → العميل يقرأ ProductVersion القديم ولا يظهر له التحديث أبداً.
- **شحن `db_config.ini`** داخل package.zip → إعدادات قاعدة بيانات المكتب تتسرب للعملاء.
- **اسم ملف الـ installer مختلف عن الـ manifest** → تنزيل مكسور للعملاء (الاسم الثابت: `Sestamk_Setup_v2026.exe`).
- **نسيان نسخة الـ Updater في `WindowsApp1\tools\`** → الـ installer يبني بأداة قديمة.
- **رفع صف Supabase قبل رفع الـ Release** → العملاء يتلقوا رابط 404 — الترتيب: Release أولاً ثم الصف.
