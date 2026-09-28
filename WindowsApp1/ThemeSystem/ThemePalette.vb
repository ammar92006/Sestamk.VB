Imports System.Drawing

''' <summary>
''' Abstract base class for all Theme Palettes.
''' Inherit from this class and define the colors to create a new Theme.
''' </summary>
Public MustInherit Class ThemePalette

    Public MustOverride ReadOnly Property ThemeType As AppTheme

    ' â”€â”€ Surfaces â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property Background As Color
    Public MustOverride ReadOnly Property BackgroundSecondary As Color
    Public MustOverride ReadOnly Property Surface As Color
    Public MustOverride ReadOnly Property SurfaceSecondary As Color
    Public MustOverride ReadOnly Property SurfaceHeader As Color

    ' â”€â”€ Text â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property TextPrimary As Color
    Public MustOverride ReadOnly Property TextSecondary As Color
    Public MustOverride ReadOnly Property TextMuted As Color
    Public MustOverride ReadOnly Property TextDisabled As Color
    Public MustOverride ReadOnly Property TextOnPrimary As Color
    Public MustOverride ReadOnly Property TextOnDark As Color

    ' â”€â”€ Brand â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property Primary As Color
    Public MustOverride ReadOnly Property PrimaryHover As Color
    Public MustOverride ReadOnly Property PrimaryPressed As Color
    Public MustOverride ReadOnly Property PrimaryLight As Color
    Public MustOverride ReadOnly Property PrimaryDark As Color

    ' â”€â”€ Navigation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property NavBackground As Color
    Public MustOverride ReadOnly Property NavHover As Color
    Public MustOverride ReadOnly Property NavSelected As Color
    Public MustOverride ReadOnly Property NavText As Color
    Public MustOverride ReadOnly Property NavSelectedText As Color

    ' â”€â”€ Inputs â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property InputBackground As Color
    Public MustOverride ReadOnly Property InputForeground As Color
    Public MustOverride ReadOnly Property InputBorder As Color
    Public MustOverride ReadOnly Property InputHoverBorder As Color
    Public MustOverride ReadOnly Property InputFocusBorder As Color
    Public MustOverride ReadOnly Property InputPlaceholder As Color
    Public MustOverride ReadOnly Property InputDisabledBackground As Color
    Public MustOverride ReadOnly Property InputDisabledForeground As Color

    ' â”€â”€ Buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property ButtonBackground As Color
    Public MustOverride ReadOnly Property ButtonForeground As Color
    Public MustOverride ReadOnly Property ButtonHover As Color
    Public MustOverride ReadOnly Property ButtonPressed As Color
    Public MustOverride ReadOnly Property ButtonSecondaryBackground As Color
    Public MustOverride ReadOnly Property ButtonSecondaryForeground As Color
    Public MustOverride ReadOnly Property ButtonSecondaryHover As Color
    Public MustOverride ReadOnly Property ButtonDisabledBackground As Color
    Public MustOverride ReadOnly Property ButtonDisabledForeground As Color

    ' â”€â”€ Borders â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property Border As Color
    Public MustOverride ReadOnly Property BorderLight As Color
    Public MustOverride ReadOnly Property BorderStrong As Color
    Public MustOverride ReadOnly Property Divider As Color

    ' â”€â”€ Semantic: Success â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property Success As Color
    Public MustOverride ReadOnly Property SuccessHover As Color
    Public MustOverride ReadOnly Property SuccessLight As Color
    Public MustOverride ReadOnly Property SuccessText As Color

    ' â”€â”€ Semantic: Warning â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property Warning As Color
    Public MustOverride ReadOnly Property WarningHover As Color
    Public MustOverride ReadOnly Property WarningLight As Color
    Public MustOverride ReadOnly Property WarningText As Color

    ' â”€â”€ Semantic: Danger â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property Danger As Color
    Public MustOverride ReadOnly Property DangerHover As Color
    Public MustOverride ReadOnly Property DangerLight As Color
    Public MustOverride ReadOnly Property DangerText As Color

    ' â”€â”€ Semantic: Info â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property Info As Color
    Public MustOverride ReadOnly Property InfoHover As Color
    Public MustOverride ReadOnly Property InfoLight As Color
    Public MustOverride ReadOnly Property InfoText As Color

    ' â”€â”€ Cards â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property CardBackground As Color
    Public MustOverride ReadOnly Property CardBorder As Color

    ' â”€â”€ Selection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property SelectionBackground As Color
    Public MustOverride ReadOnly Property SelectionForeground As Color

    ' â”€â”€ DataGridView â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property GridBackground As Color
    Public MustOverride ReadOnly Property GridAlternateBackground As Color
    Public MustOverride ReadOnly Property GridHeaderBackground As Color
    Public MustOverride ReadOnly Property GridHeaderForeground As Color
    Public MustOverride ReadOnly Property GridBorder As Color
    Public MustOverride ReadOnly Property GridSelectionBackground As Color
    Public MustOverride ReadOnly Property GridSelectionForeground As Color
    Public MustOverride ReadOnly Property GridForeground As Color

    ' â”€â”€ Menus / ToolStrip â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property MenuBackground As Color
    Public MustOverride ReadOnly Property MenuForeground As Color
    Public MustOverride ReadOnly Property MenuHover As Color
    Public MustOverride ReadOnly Property MenuSelected As Color
    Public MustOverride ReadOnly Property MenuBorder As Color

    ' â”€â”€ Tabs â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property TabBackground As Color
    Public MustOverride ReadOnly Property TabInactive As Color
    Public MustOverride ReadOnly Property TabActive As Color
    Public MustOverride ReadOnly Property TabHover As Color
    Public MustOverride ReadOnly Property TabText As Color
    Public MustOverride ReadOnly Property TabActiveText As Color

    ' â”€â”€ ScrollBars â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property ScrollBarBackground As Color
    Public MustOverride ReadOnly Property ScrollBarThumb As Color

    ' ── Toggle / CheckBox ─────────────────────────────────────────
    Public MustOverride ReadOnly Property ToggleCheckedFill As Color
    Public MustOverride ReadOnly Property ToggleUncheckedFill As Color
    Public MustOverride ReadOnly Property ToggleInnerColor As Color

    ' ── Elevation Layers (مستويات الارتفاع والعمق) ─────────────────
    Public Overridable ReadOnly Property SurfaceLevel1 As Color
        Get
            Return Surface
        End Get
    End Property

    Public Overridable ReadOnly Property SurfaceLevel2 As Color
        Get
            Return SurfaceSecondary
        End Get
    End Property

    Public Overridable ReadOnly Property SurfaceLevel3 As Color
        Get
            Return MenuBackground
        End Get
    End Property

    ' ── Semantic: Subtle / Soft Badges (شارات ناعمة عالية التباين) ──
    Public Overridable ReadOnly Property SuccessSubtleBackground As Color
        Get
            Return SuccessLight
        End Get
    End Property

    Public Overridable ReadOnly Property SuccessSubtleForeground As Color
        Get
            Return Success
        End Get
    End Property

    Public Overridable ReadOnly Property SuccessSubtleBorder As Color
        Get
            Return Success
        End Get
    End Property

    Public Overridable ReadOnly Property WarningSubtleBackground As Color
        Get
            Return WarningLight
        End Get
    End Property

    Public Overridable ReadOnly Property WarningSubtleForeground As Color
        Get
            Return Warning
        End Get
    End Property

    Public Overridable ReadOnly Property WarningSubtleBorder As Color
        Get
            Return Warning
        End Get
    End Property

    Public Overridable ReadOnly Property DangerSubtleBackground As Color
        Get
            Return DangerLight
        End Get
    End Property

    Public Overridable ReadOnly Property DangerSubtleForeground As Color
        Get
            Return Danger
        End Get
    End Property

    Public Overridable ReadOnly Property DangerSubtleBorder As Color
        Get
            Return Danger
        End Get
    End Property

    Public Overridable ReadOnly Property InfoSubtleBackground As Color
        Get
            Return InfoLight
        End Get
    End Property

    Public Overridable ReadOnly Property InfoSubtleForeground As Color
        Get
            Return Info
        End Get
    End Property

    Public Overridable ReadOnly Property InfoSubtleBorder As Color
        Get
            Return Info
        End Get
    End Property

    ' ── Accent: Indigo (للجداول والوظائف الخاصة) ───────────────────
    Public Overridable ReadOnly Property AccentIndigo As Color
        Get
            Return H("#6366F1")
        End Get
    End Property

    Public Overridable ReadOnly Property AccentIndigoHover As Color
        Get
            Return H("#4F46E5")
        End Get
    End Property

    Public Overridable ReadOnly Property AccentIndigoText As Color
        Get
            Return Color.White
        End Get
    End Property

    Public Overridable ReadOnly Property AccentIndigoSubtle As Color
        Get
            Return H("#EEF2FF")
        End Get
    End Property

    Public Overridable ReadOnly Property AccentIndigoSubtleForeground As Color
        Get
            Return H("#4338CA")
        End Get
    End Property

    Public Overridable ReadOnly Property AccentIndigoSubtleBorder As Color
        Get
            Return H("#C7D2FE")
        End Get
    End Property

    ' ── Helper & Contrast Utilities ──────────────────────────────
    ''' <summary>Converts a hex color string (e.g. #FFFFFF) to a Color.</summary>
    Protected Shared Function H(hexColor As String) As Color
        Return ColorTranslator.FromHtml(hexColor)
    End Function

    ''' <summary>
    ''' Calculates relative luminance according to WCAG 2.1 formula (0.0 = darkest black, 1.0 = lightest white).
    ''' </summary>
    Public Shared Function GetRelativeLuminance(c As Color) As Double
        Dim r As Double = If(c.R / 255.0 <= 0.03928, (c.R / 255.0) / 12.92, Math.Pow(((c.R / 255.0) + 0.055) / 1.055, 2.4))
        Dim g As Double = If(c.G / 255.0 <= 0.03928, (c.G / 255.0) / 12.92, Math.Pow(((c.G / 255.0) + 0.055) / 1.055, 2.4))
        Dim b As Double = If(c.B / 255.0 <= 0.03928, (c.B / 255.0) / 12.92, Math.Pow(((c.B / 255.0) + 0.055) / 1.055, 2.4))
        Return 0.2126 * r + 0.7152 * g + 0.0722 * b
    End Function

    ''' <summary>
    ''' Calculates contrast ratio between two colors according to WCAG 2.1 (1:1 to 21:1).
    ''' </summary>
    Public Shared Function GetContrastRatio(c1 As Color, c2 As Color) As Double
        Dim l1 As Double = GetRelativeLuminance(c1)
        Dim l2 As Double = GetRelativeLuminance(c2)
        If l1 < l2 Then
            Dim tmp As Double = l1
            l1 = l2
            l2 = tmp
        End If
        Return (l1 + 0.05) / (l2 + 0.05)
    End Function

End Class