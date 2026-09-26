''' <summary>
''' Types of themes available in the application.
''' To add a new theme: add a value here and create a matching Palette â€” without touching any Form.
''' </summary>
Public Enum AppTheme
    Light
    Dark
End Enum

''' <summary>
''' وضع المظهر المحدد من قبل المستخدم: فاتح، داكن، أو تلقائي حسب مظهر نظام الويندوز.
''' </summary>
Public Enum ThemeMode
    Light
    Dark
    System
End Enum