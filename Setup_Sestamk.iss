; ==============================================================================
; سكريبت إعداد برنامج التثبيت الاحترافي لتطبيق سستمك (Sestamk POS Setup Script)
; يدعم التثبيت الصامت التلقائي لمحرك Microsoft SQL Server LocalDB و .NET Framework 4.8
; مع ضبط صلاحيات NTFS (users-modify) لمنع مشاكل UAC وحفظ الإعدادات في Program Files
; متوافق مع Inno Setup 6+
; ==============================================================================

#define MyAppName "Sestamk POS"
#define MyAppVersion "1.2.0"
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
OutputBaseFilename=Sestamk_Setup_v2026
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
; منح صلاحيات التعديل الكاملة للمستخدمين العاديين لمنع أخطاء Access Denied عند حفظ الإعدادات وقواعد البيانات المحلية
Name: "{app}"; Permissions: users-modify
Name: "{app}\logs"; Permissions: users-modify
Name: "{app}\Backups"; Permissions: users-modify
Name: "{app}\db"; Permissions: users-modify
Name: "{app}\redist"; Permissions: users-modify
Name: "{app}\photos_user"; Permissions: users-modify
Name: "{app}\photos_purchases"; Permissions: users-modify
Name: "{app}\Barcodes"; Permissions: users-modify
Name: "{app}\tools"; Permissions: users-modify
Name: "{commonappdata}\Sestamk"; Permissions: users-modify
Name: "{commonappdata}\Sestamk\logs"; Permissions: users-modify
Name: "{commonappdata}\Sestamk\Backups"; Permissions: users-modify

[Files]
; 1. الملفات الأساسية للبرنامج (exe + جميع المكتبات المشغلة) مع منح صلاحية التعديل
Source: "{#SourceBin}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs; Permissions: users-modify; Excludes: "*.pdb,*.xml,*.vshost.*,*.manifest,*.application,Backups\*,logs\*,app.publish\*"

; 1.1 أداة التحديث المباشر التلقائي (update.exe و Sestamk.VB.Updater.exe) في مجلد البرنامج الرئيسي ومجلد tools
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{app}"; DestName: "update.exe"; Flags: ignoreversion; Permissions: users-modify
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{app}"; DestName: "Sestamk.VB.Updater.exe"; Flags: ignoreversion; Permissions: users-modify
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{app}\tools"; DestName: "update.exe"; Flags: ignoreversion; Permissions: users-modify
Source: "WindowsApp1\tools\Sestamk.VB.Updater.exe"; DestDir: "{app}\tools"; DestName: "Sestamk.VB.Updater.exe"; Flags: ignoreversion; Permissions: users-modify

; 2. حزمة محرك LocalDB للتثبيت المؤقت
Source: "WindowsApp1\redist\SqlLocalDB.msi"; DestDir: "{tmp}"; Flags: deleteafterinstall skipifsourcedoesntexist

; 3. حزمة محرك LocalDB داخل مجلد البرنامج كاحتياط دائم للنظام
Source: "WindowsApp1\redist\SqlLocalDB.msi"; DestDir: "{app}\redist"; Flags: ignoreversion skipifsourcedoesntexist; Permissions: users-modify

; 4. سكريبتات هيكل وقاعدة البيانات الأولية
Source: "WindowsApp1\Resources\DatabaseSchema.sql"; DestDir: "{app}\db"; Flags: ignoreversion; Permissions: users-modify
Source: "SestamkDB_SQL2014_Full.sql"; DestDir: "{app}\db"; Flags: ignoreversion skipifsourcedoesntexist; Permissions: users-modify

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
