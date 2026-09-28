Imports System.Drawing

Public NotInheritable Class DarkThemePalette
    Inherits ThemePalette

    Public Overrides ReadOnly Property ThemeType As AppTheme
        Get
            Return AppTheme.Dark
        End Get
    End Property

    Public Overrides ReadOnly Property Background As Color
        Get
            Return H("#141821")
        End Get
    End Property

    Public Overrides ReadOnly Property BackgroundSecondary As Color
        Get
            Return H("#1A1F2B")
        End Get
    End Property

    Public Overrides ReadOnly Property Surface As Color
        Get
            Return H("#202634")
        End Get
    End Property

    Public Overrides ReadOnly Property SurfaceSecondary As Color
        Get
            Return H("#283042")
        End Get
    End Property

    Public Overrides ReadOnly Property SurfaceHeader As Color
        Get
            Return H("#1A232E")
        End Get
    End Property

    Public Overrides ReadOnly Property TextPrimary As Color
        Get
            Return H("#F1F5F9")
        End Get
    End Property

    Public Overrides ReadOnly Property TextSecondary As Color
        Get
            Return H("#CBD5E1")
        End Get
    End Property

    Public Overrides ReadOnly Property TextMuted As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property TextDisabled As Color
        Get
            Return H("#64748B")
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
            Return H("#3B82F6")
        End Get
    End Property

    Public Overrides ReadOnly Property PrimaryHover As Color
        Get
            Return H("#2563EB")
        End Get
    End Property

    Public Overrides ReadOnly Property PrimaryPressed As Color
        Get
            Return H("#2563EB")
        End Get
    End Property

    Public Overrides ReadOnly Property PrimaryLight As Color
        Get
            Return H("#1E3A5F")
        End Get
    End Property

    Public Overrides ReadOnly Property PrimaryDark As Color
        Get
            Return H("#1D4ED8")
        End Get
    End Property

    Public Overrides ReadOnly Property NavBackground As Color
        Get
            Return H("#111827")
        End Get
    End Property

    Public Overrides ReadOnly Property NavHover As Color
        Get
            Return H("#1F2937")
        End Get
    End Property

    Public Overrides ReadOnly Property NavSelected As Color
        Get
            Return H("#2563EB")
        End Get
    End Property

    Public Overrides ReadOnly Property NavText As Color
        Get
            Return H("#9CA3AF")
        End Get
    End Property

    Public Overrides ReadOnly Property NavSelectedText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property InputBackground As Color
        Get
            Return H("#1A1F2B")
        End Get
    End Property

    Public Overrides ReadOnly Property InputForeground As Color
        Get
            Return H("#F8FAFC")
        End Get
    End Property

    Public Overrides ReadOnly Property InputBorder As Color
        Get
            Return H("#334155")
        End Get
    End Property

    Public Overrides ReadOnly Property InputHoverBorder As Color
        Get
            Return H("#64748B")
        End Get
    End Property

    Public Overrides ReadOnly Property InputFocusBorder As Color
        Get
            Return H("#3B82F6")
        End Get
    End Property

    Public Overrides ReadOnly Property InputPlaceholder As Color
        Get
            Return H("#64748B")
        End Get
    End Property

    Public Overrides ReadOnly Property InputDisabledBackground As Color
        Get
            Return H("#1E232F")
        End Get
    End Property

    Public Overrides ReadOnly Property InputDisabledForeground As Color
        Get
            Return H("#475569")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonBackground As Color
        Get
            Return H("#2563EB")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonForeground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonHover As Color
        Get
            Return H("#3B82F6")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonPressed As Color
        Get
            Return H("#1D4ED8")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSecondaryBackground As Color
        Get
            Return H("#283042")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSecondaryForeground As Color
        Get
            Return H("#F1F5F9")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSecondaryHover As Color
        Get
            Return H("#334155")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonDisabledBackground As Color
        Get
            Return H("#232B3A")
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonDisabledForeground As Color
        Get
            Return H("#64748B")
        End Get
    End Property

    Public Overrides ReadOnly Property Border As Color
        Get
            Return H("#334155")
        End Get
    End Property

    Public Overrides ReadOnly Property BorderLight As Color
        Get
            Return H("#1E293B")
        End Get
    End Property

    Public Overrides ReadOnly Property BorderStrong As Color
        Get
            Return H("#475569")
        End Get
    End Property

    Public Overrides ReadOnly Property Divider As Color
        Get
            Return H("#262F3E")
        End Get
    End Property

    Public Overrides ReadOnly Property Success As Color
        Get
            Return H("#059669")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessHover As Color
        Get
            Return H("#10B981")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessLight As Color
        Get
            Return H("#064E3B")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property Danger As Color
        Get
            Return H("#DC2626")
        End Get
    End Property

    Public Overrides ReadOnly Property DangerHover As Color
        Get
            Return H("#EF4444")
        End Get
    End Property

    Public Overrides ReadOnly Property DangerLight As Color
        Get
            Return H("#7F1D1D")
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
            Return H("#F59E0B")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningLight As Color
        Get
            Return H("#78350F")
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
            Return H("#38BDF8")
        End Get
    End Property

    Public Overrides ReadOnly Property InfoLight As Color
        Get
            Return H("#0C4A6E")
        End Get
    End Property

    Public Overrides ReadOnly Property InfoText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property CardBackground As Color
        Get
            Return H("#202634")
        End Get
    End Property

    Public Overrides ReadOnly Property CardBorder As Color
        Get
            Return H("#283042")
        End Get
    End Property

    Public Overrides ReadOnly Property SelectionBackground As Color
        Get
            Return H("#1E3A8A")
        End Get
    End Property

    Public Overrides ReadOnly Property SelectionForeground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property GridBackground As Color
        Get
            Return H("#141821")
        End Get
    End Property

    Public Overrides ReadOnly Property GridAlternateBackground As Color
        Get
            Return H("#1A1F2B")
        End Get
    End Property

    Public Overrides ReadOnly Property GridHeaderBackground As Color
        Get
            Return H("#1A232E")
        End Get
    End Property

    Public Overrides ReadOnly Property GridHeaderForeground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property GridBorder As Color
        Get
            Return H("#283042")
        End Get
    End Property

    Public Overrides ReadOnly Property GridSelectionBackground As Color
        Get
            Return H("#1E3A8A")
        End Get
    End Property

    Public Overrides ReadOnly Property GridSelectionForeground As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property GridForeground As Color
        Get
            Return H("#F1F5F9")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBackground As Color
        Get
            Return H("#263044")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuForeground As Color
        Get
            Return H("#F1F5F9")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuHover As Color
        Get
            Return H("#334155")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuSelected As Color
        Get
            Return H("#2563EB")
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder As Color
        Get
            Return H("#3E4C66")
        End Get
    End Property

    Public Overrides ReadOnly Property TabBackground As Color
        Get
            Return H("#141821")
        End Get
    End Property

    Public Overrides ReadOnly Property TabInactive As Color
        Get
            Return H("#1A1F2B")
        End Get
    End Property

    Public Overrides ReadOnly Property TabActive As Color
        Get
            Return H("#2563EB")
        End Get
    End Property

    Public Overrides ReadOnly Property TabHover As Color
        Get
            Return H("#283042")
        End Get
    End Property

    Public Overrides ReadOnly Property TabText As Color
        Get
            Return H("#94A3B8")
        End Get
    End Property

    Public Overrides ReadOnly Property TabActiveText As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    Public Overrides ReadOnly Property ScrollBarBackground As Color
        Get
            Return H("#1A1F2B")
        End Get
    End Property

    Public Overrides ReadOnly Property ScrollBarThumb As Color
        Get
            Return H("#334155")
        End Get
    End Property

    Public Overrides ReadOnly Property ToggleCheckedFill As Color
        Get
            Return H("#10B981")
        End Get
    End Property

    Public Overrides ReadOnly Property ToggleUncheckedFill As Color
        Get
            Return H("#475569")
        End Get
    End Property

    Public Overrides ReadOnly Property ToggleInnerColor As Color
        Get
            Return H("#FFFFFF")
        End Get
    End Property

    ' ── Elevation Layers (مستويات الارتفاع في الوضع الداكن) ──────
    Public Overrides ReadOnly Property SurfaceLevel1 As Color
        Get
            Return H("#202634")
        End Get
    End Property

    Public Overrides ReadOnly Property SurfaceLevel2 As Color
        Get
            Return H("#283042")
        End Get
    End Property

    Public Overrides ReadOnly Property SurfaceLevel3 As Color
        Get
            Return H("#263044")
        End Get
    End Property

    ' ── Semantic: Subtle / Soft Badges (شارات ناعمة دقيقة للوضع الداكن) ──
    Public Overrides ReadOnly Property SuccessSubtleBackground As Color
        Get
            Return Color.FromArgb(16, 42, 34)
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessSubtleForeground As Color
        Get
            Return H("#34D399")
        End Get
    End Property

    Public Overrides ReadOnly Property SuccessSubtleBorder As Color
        Get
            Return H("#059669")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningSubtleBackground As Color
        Get
            Return Color.FromArgb(48, 28, 10)
        End Get
    End Property

    Public Overrides ReadOnly Property WarningSubtleForeground As Color
        Get
            Return H("#FBBF24")
        End Get
    End Property

    Public Overrides ReadOnly Property WarningSubtleBorder As Color
        Get
            Return H("#D97706")
        End Get
    End Property

    Public Overrides ReadOnly Property DangerSubtleBackground As Color
        Get
            Return Color.FromArgb(45, 25, 30)
        End Get
    End Property

    Public Overrides ReadOnly Property DangerSubtleForeground As Color
        Get
            Return Color.FromArgb(254, 202, 202)
        End Get
    End Property

    Public Overrides ReadOnly Property DangerSubtleBorder As Color
        Get
            Return H("#EF4444")
        End Get
    End Property

    Public Overrides ReadOnly Property InfoSubtleBackground As Color
        Get
            Return Color.FromArgb(24, 38, 62)
        End Get
    End Property

    Public Overrides ReadOnly Property InfoSubtleForeground As Color
        Get
            Return Color.FromArgb(191, 219, 254)
        End Get
    End Property

    Public Overrides ReadOnly Property InfoSubtleBorder As Color
        Get
            Return H("#3B82F6")
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
            Return Color.FromArgb(30, 27, 75)
        End Get
    End Property

    Public Overrides ReadOnly Property AccentIndigoSubtleForeground As Color
        Get
            Return H("#A5B4FC")
        End Get
    End Property

    Public Overrides ReadOnly Property AccentIndigoSubtleBorder As Color
        Get
            Return H("#6366F1")
        End Get
    End Property

End Class
