Imports System.Drawing

Public NotInheritable Class LightThemePalette
    Inherits ThemePalette

    Public Overrides ReadOnly Property ThemeType As AppTheme
        Get
            Return AppTheme.Light
        End Get
    End Property

    Public Overrides ReadOnly Property Background As Color
        Get
            Return H("#F8F9FA")
        End Get
    End Property

    Public Overrides ReadOnly Property BackgroundSecondary As Color
        Get
            Return H("#F1F4F9")
        End Get
    End Property

    Public Overrides ReadOnly Property Surface As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property SurfaceSecondary As Color
        Get
            Return H("#F8FAFC")
        End Get
    End Property

    Public Overrides ReadOnly Property SurfaceHeader As Color
        Get
            Return H("#243342")
        End Get
    End Property

    Public Overrides ReadOnly Property TextPrimary As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property TextSecondary As Color
        Get
            Return H("#475569")
        End Get
    End Property

    Public Overrides ReadOnly Property TextMuted As Color
        Get
            Return H("#64748B")
        End Get
    End Property

    Public Overrides ReadOnly Property TextDisabled As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property TextOnPrimary As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property TextOnDark As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property Primary As Color
        Get
            Return H("#2B5B84")
        End Get
    End Property

    Public Overrides ReadOnly Property PrimaryHover As Color
        Get
            Return H("#244D70")
        End Get
    End Property

    Public Overrides ReadOnly Property PrimaryPressed As Color
        Get
            Return H("#1D3F5C")
        End Get
    End Property

    Public Overrides ReadOnly Property PrimaryLight As Color
        Get
            Return H("#EBF3FA")
        End Get
    End Property

    Public Overrides ReadOnly Property PrimaryDark As Color
        Get
            Return H("#1D3F5C")
        End Get
    End Property

    Public Overrides ReadOnly Property NavBackground As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property NavHover As Color
        Get
            Return H("#334155")
        End Get
    End Property

    Public Overrides ReadOnly Property NavSelected As Color
        Get
            Return H("#2563EB")
        End Get
    End Property

    Public Overrides ReadOnly Property NavText As Color
        Get
            Return H("#E2E8F0")
        End Get
    End Property

    Public Overrides ReadOnly Property NavSelectedText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property InputBackground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property InputForeground As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property InputBorder As Color
        Get
            Return H("#CBD5E1")
        End Get
    End Property

    Public Overrides ReadOnly Property InputHoverBorder As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property InputFocusBorder As Color
        Get
            Return H("#2B5B84")
        End Get
    End Property

    Public Overrides ReadOnly Property InputPlaceholder As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property InputDisabledBackground As Color
        Get
            Return H("#F1F5F9")
        End Get
    End Property

    Public Overrides ReadOnly Property InputDisabledForeground As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonBackground As Color
        Get
            Return H("#2B5B84")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonForeground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonHover As Color
        Get
            Return H("#244D70")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonPressed As Color
        Get
            Return H("#1D3F5C")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSecondaryBackground As Color
        Get
            Return H("#E2E8F0")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSecondaryForeground As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSecondaryHover As Color
        Get
            Return H("#CBD5E1")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonDisabledBackground As Color
        Get
            Return H("#E2E8F0")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonDisabledForeground As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property Border As Color
        Get
            Return H("#D1D5DB")
        End Get
    End Property

    Public Overrides ReadOnly Property BorderLight As Color
        Get
            Return H("#E2E8F0")
        End Get
    End Property

    Public Overrides ReadOnly Property BorderStrong As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property Divider As Color
        Get
            Return H("#E5E7EB")
        End Get
    End Property

    Public Overrides ReadOnly Property Success As Color
        Get
            Return H("#10B981")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessHover As Color
        Get
            Return H("#059669")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessLight As Color
        Get
            Return H("#D1FAE5")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property Danger As Color
        Get
            Return H("#EF4444")
        End Get
    End Property

    Public Overrides ReadOnly Property DangerHover As Color
        Get
            Return H("#DC2626")
        End Get
    End Property

    Public Overrides ReadOnly Property DangerLight As Color
        Get
            Return H("#FEE2E2")
        End Get
    End Property

    Public Overrides ReadOnly Property DangerText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property Warning As Color
        Get
            Return H("#D97706")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningHover As Color
        Get
            Return H("#B45309")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningLight As Color
        Get
            Return H("#FEF3C7")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property Info As Color
        Get
            Return H("#0284C7")
        End Get
    End Property

    Public Overrides ReadOnly Property InfoHover As Color
        Get
            Return H("#0369A1")
        End Get
    End Property

    Public Overrides ReadOnly Property InfoLight As Color
        Get
            Return H("#E0F2FE")
        End Get
    End Property

    Public Overrides ReadOnly Property InfoText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property CardBackground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property CardBorder As Color
        Get
            Return H("#E2E8F0")
        End Get
    End Property

    Public Overrides ReadOnly Property SelectionBackground As Color
        Get
            Return H("#DBEAFE")
        End Get
    End Property

    Public Overrides ReadOnly Property SelectionForeground As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property GridBackground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property GridAlternateBackground As Color
        Get
            Return H("#F8FAFC")
        End Get
    End Property

    Public Overrides ReadOnly Property GridHeaderBackground As Color
        Get
            Return H("#243342")
        End Get
    End Property

    Public Overrides ReadOnly Property GridHeaderForeground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property GridBorder As Color
        Get
            Return H("#E2E8F0")
        End Get
    End Property

    Public Overrides ReadOnly Property GridSelectionBackground As Color
        Get
            Return H("#DBEAFE")
        End Get
    End Property

    Public Overrides ReadOnly Property GridSelectionForeground As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property GridForeground As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBackground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuForeground As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuHover As Color
        Get
            Return H("#EBF3FA")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuSelected As Color
        Get
            Return H("#2B5B84")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder As Color
        Get
            Return H("#E5E7EB")
        End Get
    End Property

    Public Overrides ReadOnly Property TabBackground As Color
        Get
            Return H("#F8F9FA")
        End Get
    End Property

    Public Overrides ReadOnly Property TabInactive As Color
        Get
            Return H("#E2E8F0")
        End Get
    End Property

    Public Overrides ReadOnly Property TabActive As Color
        Get
            Return H("#2B5B84")
        End Get
    End Property

    Public Overrides ReadOnly Property TabHover As Color
        Get
            Return H("#EBF3FA")
        End Get
    End Property

    Public Overrides ReadOnly Property TabText As Color
        Get
            Return H("#475569")
        End Get
    End Property

    Public Overrides ReadOnly Property TabActiveText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property ScrollBarBackground As Color
        Get
            Return H("#F1F5F9")
        End Get
    End Property

    Public Overrides ReadOnly Property ScrollBarThumb As Color
        Get
            Return H("#CBD5E1")
        End Get
    End Property

    Public Overrides ReadOnly Property ToggleCheckedFill As Color
        Get
            Return H("#10B981")
        End Get
    End Property

    Public Overrides ReadOnly Property ToggleUncheckedFill As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property ToggleInnerColor As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    ' ── Elevation Layers (مستويات الارتفاع في الوضع الفاتح) ─────
    Public Overrides ReadOnly Property SurfaceLevel1 As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property SurfaceLevel2 As Color
        Get
            Return H("#F8FAFC")
        End Get
    End Property

    Public Overrides ReadOnly Property SurfaceLevel3 As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    ' ── Semantic: Subtle / Soft Badges (شارات ناعمة دقيقة للوضع الفاتح) ──
    Public Overrides ReadOnly Property SuccessSubtleBackground As Color
        Get
            Return H("#F0FDF4")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessSubtleForeground As Color
        Get
            Return H("#15803D")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessSubtleBorder As Color
        Get
            Return H("#BBF7D0")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningSubtleBackground As Color
        Get
            Return H("#FFFBEB")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningSubtleForeground As Color
        Get
            Return H("#B45309")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningSubtleBorder As Color
        Get
            Return H("#FDE68A")
        End Get
    End Property

    Public Overrides ReadOnly Property DangerSubtleBackground As Color
        Get
            Return Color.FromArgb(254, 242, 242)
        End Get
    End Property

    Public Overrides ReadOnly Property DangerSubtleForeground As Color
        Get
            Return Color.FromArgb(185, 28, 28)
        End Get
    End Property

    Public Overrides ReadOnly Property DangerSubtleBorder As Color
        Get
            Return Color.FromArgb(248, 113, 113)
        End Get
    End Property

    Public Overrides ReadOnly Property InfoSubtleBackground As Color
        Get
            Return Color.FromArgb(239, 246, 255)
        End Get
    End Property

    Public Overrides ReadOnly Property InfoSubtleForeground As Color
        Get
            Return Color.FromArgb(29, 78, 216)
        End Get
    End Property

    Public Overrides ReadOnly Property InfoSubtleBorder As Color
        Get
            Return Color.FromArgb(147, 197, 253)
        End Get
    End Property

    ' ── Accent: Indigo ───────────────────────────────────────────
    Public Overrides ReadOnly Property AccentIndigo As Color
        Get
            Return H("#6366F1")
        End Get
    End Property

    Public Overrides ReadOnly Property AccentIndigoHover As Color
        Get
            Return H("#4F46E5")
        End Get
    End Property

    Public Overrides ReadOnly Property AccentIndigoText As Color
        Get
            Return Color.White
        End Get
    End Property

    Public Overrides ReadOnly Property AccentIndigoSubtle As Color
        Get
            Return H("#EEF2FF")
        End Get
    End Property

    Public Overrides ReadOnly Property AccentIndigoSubtleForeground As Color
        Get
            Return H("#4338CA")
        End Get
    End Property

    Public Overrides ReadOnly Property AccentIndigoSubtleBorder As Color
        Get
            Return H("#C7D2FE")
        End Get
    End Property

End Class
