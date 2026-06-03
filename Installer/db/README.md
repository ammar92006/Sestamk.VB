# مجلد قاعدة البيانات (db)

ضع هنا النسخة الاحتياطية لقاعدة البيانات باسم **`Cashier_Market.bak`**.

عند أول تشغيل للبرنامج على جهاز جديد، يكتشف البرنامج أن قاعدة البيانات غير
موجودة، فيستعيد هذه النسخة تلقائياً إلى LocalDB
(`DBModule.EnsureLocalDbDatabase`) ويكتب ملف الاتصال `db_config.ini` بنفسه —
بدون أي تدخّل من المستخدم.

## كيفية إنتاج النسخة الاحتياطية من جهازك

من PowerShell (مع تعديل اسم الخادم لو لزم):

```powershell
.\prepare_db_backup.ps1 -Server ".\SQLEXPRESS" -Database "Cashier_Market"
```

أو يدوياً عبر SQL Server Management Studio:

```sql
BACKUP DATABASE [Cashier_Market]
TO DISK = N'<مسار المشروع>\Installer\db\Cashier_Market.bak'
WITH FORMAT, INIT, COMPRESSION;
```

> ملف `.bak` غير مضمّن في المستودع لكبر حجمه (راجع .gitignore). أنتجه قبل بناء الإنستولر.
