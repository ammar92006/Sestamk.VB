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
    Public Const KitchenPrinterName As String = "KitchenPrinterName"
    Public Const NormalPrinterName As String = "NormalPrinterName"
    Public Const PrintStyle As String = "PrintStyle"
    Public Const PrintLogo As String = "PrintLogo"
    Public Const PrintBarcode As String = "PrintBarcode"
    Public Const InvoiceBarcodeType As String = "InvoiceBarcodeType"
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

    ' ── الثيم والمظهر (Appearance / Theme) ──
    Public Const AppTheme As String = "AppTheme"

    ' ── إعدادات النظام (System Settings) ──
    Public Const SystemLanguage As String = "System_Language"
    Public Const SystemAutoBackup As String = "System_AutoBackup"
    Public Const SystemBackupPath As String = "System_BackupPath"
    Public Const SystemRunAtStartup As String = "System_RunAtStartup"
    Public Const SystemAutoLogoutEnabled As String = "System_AutoLogoutEnabled"
    Public Const SystemAutoLogoutTimer As String = "System_AutoLogoutTimer"
    Public Const LoginMaxAttempts As String = "Login_MaxAttempts"
    Public Const CurrencyName As String = "CurrencyName"

    ' ── إعدادات المبيعات (Sales Settings) ──
    Public Const SalesEnableDineIn As String = "Sales_EnableDineIn"
    Public Const SalesEnableTakeaway As String = "Sales_EnableTakeaway"
    Public Const SalesEnableDelivery As String = "Sales_EnableDelivery"
    Public Const SalesDeductIngredients As String = "Sales_DeductIngredients"
    Public Const EnableTax As String = "EnableTax"
    Public Const TaxPercent As String = "TaxPercent"
    Public Const EnableDiscount As String = "EnableDiscount"
    Public Const DefaultDiscountPercent As String = "DefaultDiscountPercent"
    Public Const PaymentCash As String = "Payment_Cash"
    Public Const PaymentVisa As String = "Payment_Visa"
    Public Const PaymentMaster As String = "Payment_Master"
    Public Const PaymentMada As String = "Payment_Mada"
    Public Const DefaultOrderType As String = "DefaultOrderType"
    Public Const DefaultCustomerID As String = "DefaultCustomerID"
    Public Const DefaultDriverID As String = "DefaultDriverID"
    Public Const CurrentBranchID As String = "CurrentBranchID"
    Public Const CurrentStoreID As String = "CurrentStoreID"
    Public Const DefaultTreasuryID As String = "defaultTreasuryid"
    Public Const IsDineInServiceFeePercent As String = "IsDineInServiceFeePercent"
    Public Const DineInServiceFee As String = "DineInServiceFee"
    Public Const InvoiceItemsPerPage As String = "InvoiceItemsPerPage"

    ' ── إعدادات الطابعة الإضافية (Printer Settings) ──
    Public Const PrinterPaperSize As String = "Printer_PaperSize"
    Public Const PrinterAutoPrint As String = "Printer_AutoPrint"
    Public Const PrinterCopiesCount As String = "Printer_InvoiceCopies"
    Public Const PrinterOpenCashDrawer As String = "Printer_OpenCashDrawer"

    ' ── تخصيص الفاتورة (Receipt Settings) ──
    Public Const ReceiptFontSize As String = "Receipt_FontSize"
    Public Const ReceiptStyle As String = "Receipt_Style"
    Public Const ShowTax As String = "ShowTax"
    Public Const ShowDiscount As String = "ShowDiscount"
    Public Const ShowCashier As String = "ShowCashier"
    Public Const ShowLogo As String = "ShowLogo"

    ' ── مفاتيح التوافق المزدوج مع C# ──
    Public Const DefaultPrinterName As String = "DefaultPrinterName"
    Public Const PrintReceiptOnPayment As String = "PrintReceiptOnPayment"
    Public Const OpenDrawerOnPayment As String = "OpenDrawerOnPayment"
    Public Const StoreName As String = "StoreName"
    Public Const StorePhone As String = "StorePhone"
    Public Const StorePhone2 As String = "StorePhone2"
    Public Const StoreAddress As String = "StoreAddress"
    Public Const ReceiptFooter As String = "Receipt_Footer"
    Public Const ReceiptLogoPath As String = "Receipt_LogoPath"
    Public Const ServicePriceTable As String = "ServicePriceTable"
    Public Const ServicePriceDelivery As String = "ServicePriceDelivery"
    Public Const DefaultPilotId As String = "DefaultPilotId"
    Public Const DefaultPilotName As String = "DefaultPilotName"

    ' ── الإشعارات والتنبيهات (Notification Settings) ──
    Public Const NotificationNewOrderSound As String = "Notification_NewOrderSound"
    Public Const NotificationErrorSound As String = "Notification_ErrorSound"
    Public Const NotificationLowStockAlert As String = "Notification_LowStockAlert"
    Public Const NotificationPrintFailAlert As String = "Notification_PrintFailAlert"

End Module
