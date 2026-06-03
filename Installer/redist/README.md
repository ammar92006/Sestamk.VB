# مجلد المتطلبات (redist)

ضع هنا ملفات المتطلبات قبل بناء ملف التثبيت. الإنستولر يتحقق تلقائياً
من وجود كل متطلب على جهاز العميل، ويثبّته **فقط لو كان ناقصاً**.

## الملفات المطلوبة (بنفس الأسماء بالضبط)

| الملف | الوصف | رابط التنزيل |
|---|---|---|
| `ndp48-x86-x64-allos-enu.exe` | .NET Framework 4.8 (مثبّت غير متصل) | https://dotnet.microsoft.com/download/dotnet-framework/net48 |
| `SqlLocalDB.msi` | SQL Server Express LocalDB | https://www.microsoft.com/download/details.aspx?id=101064 (اختر SqlLocalDB.msi) |

> ملاحظات:
> - لو لم تضع ملفاً، يتخطّاه الإنستولر بهدوء (ويُظهر تنبيهاً فقط لو كان المتطلب ناقصاً على الجهاز).
> - `SqlLocalDB.msi` متوفّر ضمن حزمة "SQL Server Express" — نزّل النسخة المناسبة لمعمارية النظام (x64).
> - هذه الملفات كبيرة الحجم ولذلك **غير مضمّنة في المستودع** (راجع .gitignore).
