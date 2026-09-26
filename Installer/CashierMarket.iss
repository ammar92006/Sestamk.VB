; ============================================================================
;  Cashier Market — Inno Setup installer
;  ينتج Setup.exe واحد يثبّت البرنامج + يتحقق من المتطلبات (.NET 4.8 و LocalDB)
;  ويثبّتها لو ناقصة. قاعدة البيانات تُهيّأ تلقائياً من البرنامج عند أول تشغيل
;  (DBModule.EnsureLocalDbDatabase) من النسخة الاحتياطية المرفقة في db\.
;
;  للبناء: شغّل build_installer.ps1 أو افتح هذا الملف في Inno Setup واضغط Compile.
; ============================================================================

#define AppName "Sestamk"
#define AppVersion "1.0.0"
#define AppPublisher "Ammar Ahmed"
#define AppExe "Sestamk.exe"

; مجلد ناتج بناء البرنامج. للإصدار النهائي غيّره إلى bin\Release.
#ifndef SourceBin
  #define SourceBin "..\WindowsApp1\bin\Debug"
#endif

[Setup]
AppId={{B7E9C3A1-4D2F-4E6B-9C8A-CASHIERMARKET01}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
OutputDir=Output
OutputBaseFilename=Sestamk-Setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
; مطلوب صلاحيات مدير لتثبيت المتطلبات (.NET / LocalDB)
PrivilegesRequired=admin
ArchitecturesInstallIn64BitMode=x64compatible
DisableProgramGroupPage=yes
UninstallDisplayName={#AppName}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "إنشاء اختصار على سطح المكتب"; GroupDescription: "اختصارات إضافية:"

[Files]
; ── ملفات البرنامج (الناتج كامل: exe + كل المكتبات) ──
Source: "{#SourceBin}\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs ignoreversion

; ── النسخة الاحتياطية لقاعدة البيانات (تُستعاد تلقائياً عند أول تشغيل) ──
Source: "db\Cashier_Market.bak"; DestDir: "{app}\db"; Flags: skipifsourcedoesntexist ignoreversion

; ── المتطلبات (تُوضع في مجلد redist قبل البناء؛ تُحذف بعد التثبيت) ──
Source: "redist\ndp48-x86-x64-allos-enu.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall skipifsourcedoesntexist
Source: "redist\SqlLocalDB.msi"; DestDir: "{tmp}"; Flags: deleteafterinstall skipifsourcedoesntexist

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExe}"
Name: "{group}\إزالة {#AppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExe}"; Tasks: desktopicon

[Run]
; تثبيت .NET Framework 4.8 إذا كان ناقصاً ومتوفّراً في redist
Filename: "{tmp}\ndp48-x86-x64-allos-enu.exe"; Parameters: "/q /norestart"; \
  StatusMsg: "جارٍ تثبيت .NET Framework 4.8 ..."; Check: ShouldInstallDotNet48

; تثبيت SQL Server LocalDB إذا كان ناقصاً ومتوفّراً في redist
Filename: "msiexec.exe"; Parameters: "/i ""{tmp}\SqlLocalDB.msi"" /qn IACCEPTSQLLOCALDBLICENSETERMS=YES"; \
  StatusMsg: "جارٍ تثبيت SQL Server LocalDB ..."; Check: ShouldInstallLocalDb

; تشغيل البرنامج بعد انتهاء التثبيت
Filename: "{app}\{#AppExe}"; Description: "تشغيل {#AppName}"; Flags: nowait postinstall skipifsilent

[Code]
{ ---- التحقق من تثبيت .NET Framework 4.8 (Release >= 528040) ---- }
function IsDotNet48Installed(): Boolean;
var
  rel: Cardinal;
begin
  Result := False;
  if RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', rel) then
    Result := (rel >= 528040);
end;

{ ---- التحقق من وجود SQL Server LocalDB ---- }
function IsLocalDbInstalled(): Boolean;
begin
  Result := RegKeyExists(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions')
    or RegKeyExists(HKLM, 'SOFTWARE\WOW6432Node\Microsoft\Microsoft SQL Server Local DB\Installed Versions');
end;

{ ---- شروط تشغيل أوامر التثبيت (المتطلب ناقص + ملفه موجود) ---- }
function ShouldInstallDotNet48(): Boolean;
begin
  Result := (not IsDotNet48Installed()) and FileExists(ExpandConstant('{tmp}\ndp48-x86-x64-allos-enu.exe'));
end;

function ShouldInstallLocalDb(): Boolean;
begin
  Result := (not IsLocalDbInstalled()) and FileExists(ExpandConstant('{tmp}\SqlLocalDB.msi'));
end;

{ ---- تحذير ودّي لو متطلب ناقص ولم يُرفق مثبّته ---- }
procedure CurStepChanged(CurStep: TSetupStep);
var
  msg: String;
begin
  if CurStep = ssInstall then
  begin
    msg := '';
    if (not IsDotNet48Installed()) and (not FileExists(ExpandConstant('{src}\redist\ndp48-x86-x64-allos-enu.exe'))) then
      msg := msg + '• .NET Framework 4.8 غير مثبّت ولم يُرفق مثبّته.' + #13#10;
    if (not IsLocalDbInstalled()) and (not FileExists(ExpandConstant('{src}\redist\SqlLocalDB.msi'))) then
      msg := msg + '• SQL Server LocalDB غير مثبّت ولم يُرفق مثبّته.' + #13#10;
    if msg <> '' then
      MsgBox('تنبيه: بعض المتطلبات ناقصة وسيُكمل التثبيت بدونها:' + #13#10#13#10 +
             msg + #13#10 + 'يُفضّل وضع ملفات المتطلبات في مجلد redist قبل البناء.',
             mbInformation, MB_OK);
  end;
end;
