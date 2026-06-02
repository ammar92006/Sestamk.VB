''' <summary>
''' مفاتيح الإعدادات الموحّدة (تُخزّن في جدول AppSettings عبر SettingsManager).
''' استخدام ثوابت بدل النصوص المباشرة يمنع الأخطاء الإملائية ويوحّد المصدر.
''' </summary>
Public Module SettingsKeys

    ' ── حالة التهيئة / أول تشغيل ──
    Public Const SetupCompleted As String = "SetupCompleted"

    ' ── حساب المدير (قابل للتهيئة لكل نشاط) ──
    Public Const AdminUsername As String = "AdminUsername"
    Public Const AdminPassword As String = "AdminPassword"

    ' ── بيانات النشاط / المحل ──
    Public Const ShopName As String = "ShopName"
    Public Const ShopPhone As String = "ShopPhone"
    Public Const ShopPhone2 As String = "ShopPhone2"
    Public Const ShopAddress As String = "ShopAddress"
    Public Const TaxNumber As String = "TaxNumber"
    Public Const FooterText As String = "FooterText"
    Public Const DeliveryText As String = "DeliveryText"
    Public Const LogoPath As String = "LogoPath"
    Public Const Currency As String = "Currency"
    Public Const BusinessType As String = "BusinessType"

    ' ── الطباعة ──
    Public Const ThermalPrinterName As String = "ThermalPrinterName"
    Public Const NormalPrinterName As String = "NormalPrinterName"
    Public Const PrintStyle As String = "PrintStyle"
    Public Const PrintLogo As String = "PrintLogo"
    Public Const PrintBarcode As String = "PrintBarcode"
    Public Const PrintPreview As String = "PrintPreview"

    ' ── طابعة الباركود ──
    Public Const BarcodePrinterName As String = "BarcodePrinterName"
    Public Const BarcodeLabelWidth As String = "BarcodeLabelWidth"
    Public Const BarcodeLabelHeight As String = "BarcodeLabelHeight"
    Public Const BarcodeCopies As String = "BarcodeCopies"
    Public Const BarcodeFontSize As String = "BarcodeFontSize"
    Public Const BarcodeFooterText As String = "BarcodeFooterText"
    Public Const BarcodeShowName As String = "BarcodeShowName"
    Public Const BarcodeShowPrice As String = "BarcodeShowPrice"
    Public Const BarcodeShowStoreName As String = "BarcodeShowStoreName"

    ' ── الاسكنر (Scanner Barcode) ──
    Public Const ScannerPort As String = "Current_port_scanner"  ' محفوظ بهذا الاسم للتوافق الرجعي
    Public Const ScannerEnabled As String = "ScannerEnabled"
    Public Const ScannerBaudRate As String = "ScannerBaudRate"
    Public Const ScannerDataBits As String = "ScannerDataBits"
    Public Const ScannerParity As String = "ScannerParity"
    Public Const ScannerStopBits As String = "ScannerStopBits"

End Module
