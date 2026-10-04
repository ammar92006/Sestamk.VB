; ==============================================================================
; سكريبت إعداد برنامج التثبيت الاحترافي لتطبيق سستمك (Sestamk POS Setup Script)
; يدعم التثبيت الصامت التلقائي لمحرك Microsoft SQL Server LocalDB و .NET Framework 4.8
; الأمان: لا تُمنح صلاحيات التعديل على ملفات البرنامج التنفيذية ({app} و tools) لمنع تصعيد الصلاحيات،
; وتُمنح فقط على مجلدات البيانات (logs / Backups / db / photos / Barcodes) لتخزين ملفات التشغيل.
; متوافق مع Inno Setup 6+
; ==============================================================================

#define MyAppName "Sestamk POS"
#define MyAppVersion "1.3.0"
#define MyAppPublisher "Sestamk Solutions"
#define MyAppURL "https://sestamk.com"
#define MyAppExeName "Sestamk.exe"

#ifndef SourceBin
  #define SourceBin "WindowsApp1\bin\Release"
#endif

[Setup]
AppId={{D829B278-8317-4F1E-BF43-7A398246E201}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\Sestamk
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=OutputSetup
OutputBaseFilename=Sestamk_Setup_v{#MyAppVersion}
SetupIconFile=WindowsApp1\loge.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin
DisableProgramGroupPage=yes
UninstallDisplayName={#MyAppName}

[Languages]
Name: "arabic"; MessagesFile: "compiler:Languages\Arabic.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Dirs]
; صلاحيات التعديل لمجلدات البيانات فقط — مجلد البرنامج الجذري ومجلد tools يبقيان محميين (يحتويان ملفات تنفيذية)
Name: "{app}"
Name: "{app}\logs"; Permissions: users-modify
Name: "{app}\Backups"; Permissions: users-modify
Name: "{app}\db"; Permissions: users-modify
Name: "{app}\redist"
Name: "{app}\photos_user"; Permissions: users-modify
Name: "{app}\photos_purchases"; Permissions: users-modify
Name: "{app}\Barcodes"; Permissions: users-modify
Name: "{app}\tools"
; أمان: مجلدات البيانات فقط قابلة للتعديل من المستخدمين.
; {commonappdata}\Sestamk الجذري ومجلد runner يُتركان محميين (صلاحية المسؤولين فقط)
; لأن runner يحمل الأداة التي تُنفَّذ بصلاحيات مسؤول عند التحديث.
Name: "{commonappdata}\Sestamk"
Name: "{commonappdata}\Sestamk\updates"; Permissions: users-modify
Name: "{commonappdata}\Sestamk\runner"
Name: "{commonappdata}\Sestamk\logs"; Permissions: users-modify
Name: "{commonappdata}\Sestamk\Backups"; Permissions: users-modify

[InstallDelete]
; أمان: إزالة المشغّل القديم الذي كان يوضع في مجلد قابل للكتابة من أي مستخدم محلي
; ويُشغَّل بصلاحيات مسؤول (ثغرة تصعيد صلاحيات) — استُبدل بمشغّل في مجلد محمي.
Type: filesandordirs; Name: "{commonappdata}\Sestamk\updates\runner"

[Files]
; 1. الملفات الأساسية للبرنامج (exe + جميع المكتبات المشغلة) — بدون صلاحيات تعديل (أمان: منع استبدال الملفات التنفيذية)
; أمان: تُستثنى إعدادات قاعدة البيانات المحلية (تحتوي مسار وكلمة مرور جهاز المطوّر) وملف manifest.json
; (وصف إصدار قديم لا يجب أن يُشحن داخل مجلد البرنامج) وملفات النسخ الاحتياطية.
Source: "{#SourceBin}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs; Excludes: "*.pdb,*.xml,*.vshost.*,*.manifest,*.application,Backups\*,logs\*,app.publish\*,db_config.ini,manifest.json,*.bak,*.old_*"

; 1.1 أداة التحديث المباشر التلقائي (update.exe و Sestamk.VB.Updater.exe) في مجلد البرنامج الرئيسي ومجلد tools
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{app}"; DestName: "update.exe"; Flags: ignoreversion
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{app}"; DestName: "Sestamk.VB.Updater.exe"; Flags: ignoreversion
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{app}\tools"; DestName: "update.exe"; Flags: ignoreversion
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{app}\tools"; DestName: "Sestamk.VB.Updater.exe"; Flags: ignoreversion

; 1.2 مشغّل التحديث المحمي (أمان): يُثبَّت في مجلد لا يملك المستخدمون صلاحية الكتابة عليه،
; ثم يُشغَّل من هناك بصلاحيات مسؤول. البديل القديم كان نسخ الأداة إلى مجلد قابل للكتابة
; من أي مستخدم ثم تنفيذها مرفوعة — وهو ما أُغلق.
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{commonappdata}\Sestamk\runner"; DestName: "update_runner.exe"; Flags: ignoreversion skipifsourcedoesntexist

; 2. حزمة محرك LocalDB للتثبيت المؤقت
Source: "WindowsApp1\redist\SqlLocalDB.msi"; DestDir: "{tmp}"; Flags: deleteafterinstall skipifsourcedoesntexist

; 3. حزمة محرك LocalDB داخل مجلد البرنامج كاحتياط دائم للنظام
Source: "WindowsApp1\redist\SqlLocalDB.msi"; DestDir: "{app}\redist"; Flags: ignoreversion skipifsourcedoesntexist

; 4. سكريبت هيكل قاعدة البيانات الأولية (هيكل + بيانات أساسية فقط)
; أمان/خصوصية: لا يُشحن أبداً أي ملف يحتوي بيانات إنتاج حقيقية (عملاء/فواتير/موظفين).
; سابقاً كان يُشحن SestamkDB_SQL2014_Full.sql الذي يحوي نسخة كاملة من قاعدة بيانات المطوّر.
Source: "WindowsApp1\Resources\DatabaseSchema.sql"; DestDir: "{app}\db"; Flags: ignoreversion

; 5. حزمة .NET Framework 4.8 إن توفرت في مجلد redist
Source: "Installer\redist\ndp48-x86-x64-allos-enu.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
; 1. تثبيت .NET Framework 4.8 إذا كان ناقصاً ومتوفراً
Filename: "{tmp}\ndp48-x86-x64-allos-enu.exe"; Parameters: "/q /norestart"; \
  StatusMsg: "جارٍ تثبيت .NET Framework 4.8..."; Check: ShouldInstallDotNet48; Flags: runhidden waituntilterminated

; 2. تثبيت صامت لمحرك LocalDB إذا لم يكن مثبتاً على جهاز العميل
Filename: "msiexec.exe"; Parameters: "/i ""{tmp}\SqlLocalDB.msi"" /qn /norestart IACCEPTSQLLOCALDBLICENSETERMS=YES"; \
  StatusMsg: "جارٍ تهيئة وتثبيت محرك قاعدة البيانات الخفيف Microsoft SQL LocalDB..."; Check: NeedsLocalDbInstall; Flags: runhidden waituntilterminated

; 3. تشغيل البرنامج بعد اكتمال التثبيت
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
// التحقق من تثبيت .NET Framework 4.8 فما فوق
function IsDotNet48Installed(): Boolean;
var
  rel: Cardinal;
begin
  Result := False;
  if RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', rel) then
    Result := (rel >= 528040);
end;

function ShouldInstallDotNet48(): Boolean;
begin
  Result := (not IsDotNet48Installed()) and FileExists(ExpandConstant('{tmp}\ndp48-x86-x64-allos-enu.exe'));
end;

// التحقق مما إذا كان محرك LocalDB مثبتاً بالفعل على جهاز العميل
function IsLocalDbInstalled(): Boolean;
begin
  Result := FileExists(ExpandConstant('{pf64}\Microsoft SQL Server\170\Tools\Binn\SqlLocalDB.exe')) or
            FileExists(ExpandConstant('{pf64}\Microsoft SQL Server\160\Tools\Binn\SqlLocalDB.exe')) or
            FileExists(ExpandConstant('{pf64}\Microsoft SQL Server\150\Tools\Binn\SqlLocalDB.exe')) or
            FileExists(ExpandConstant('{pf64}\Microsoft SQL Server\140\Tools\Binn\SqlLocalDB.exe')) or
            FileExists(ExpandConstant('{pf64}\Microsoft SQL Server\130\Tools\Binn\SqlLocalDB.exe')) or
            FileExists(ExpandConstant('{pf64}\Microsoft SQL Server\120\Tools\Binn\SqlLocalDB.exe')) or
            FileExists(ExpandConstant('{pf64}\Microsoft SQL Server\110\Tools\Binn\SqlLocalDB.exe')) or
            RegKeyExists(HKLM64, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions') or
            RegKeyExists(HKLM32, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions') or
            RegKeyExists(HKLM, 'SOFTWARE\WOW6432Node\Microsoft\Microsoft SQL Server Local DB\Installed Versions');
end;

function NeedsLocalDbInstall(): Boolean;
begin
  Result := (not IsLocalDbInstalled()) and FileExists(ExpandConstant('{tmp}\SqlLocalDB.msi'));
end;
