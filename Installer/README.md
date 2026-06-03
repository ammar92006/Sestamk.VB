# مشروع التثبيت — Cashier Market Installer

ينتج ملف **`CashierMarket-Setup.exe`** واحد يثبّت البرنامج على أي جهاز ويتولّى
المتطلبات تلقائياً.

## ماذا يفعل الإنستولر
1. ينسخ ملفات البرنامج إلى `Program Files\Cashier Market`.
2. يتحقق من **.NET Framework 4.8** ويثبّته لو ناقص (من `redist`).
3. يتحقق من **SQL Server LocalDB** ويثبّته لو ناقص (من `redist`).
4. ينشئ اختصارات (قائمة ابدأ + سطح المكتب اختياري).
5. عند **أول تشغيل**، يستعيد البرنامج قاعدة البيانات تلقائياً من
   `db\Cashier_Market.bak` إلى LocalDB ويكتب `db_config.ini` بنفسه.

## خطوات البناء
1. ضع المتطلبات في مجلد `redist` (راجع `redist\README.md`).
2. أنتج نسخة قاعدة البيانات في `db\Cashier_Market.bak`:
   ```powershell
   .\prepare_db_backup.ps1 -Server ".\SQLEXPRESS" -Database "Cashier_Market"
   ```
3. ابنِ ملف التثبيت:
   ```powershell
   .\build_installer.ps1 -Configuration Release
   ```
4. الناتج: `Output\CashierMarket-Setup.exe`

## المتطلبات على جهاز التطوير
- Visual Studio / MSBuild (لبناء البرنامج).
- [Inno Setup 6](https://jrsoftware.org/isdl.php) (لتجميع ملف التثبيت).

> ملاحظة: ملفات `redist\*` و `db\*.bak` و `Output\` غير مضمّنة في المستودع
> لكبر حجمها (راجع `.gitignore`).
