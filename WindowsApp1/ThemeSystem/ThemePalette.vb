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

    ' â”€â”€ Toggle / CheckBox â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    Public MustOverride ReadOnly Property ToggleCheckedFill As Color
    Public MustOverride ReadOnly Property ToggleUncheckedFill As Color
    Public MustOverride ReadOnly Property ToggleInnerColor As Color

    ' â”€â”€ Helper â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    ''' <summary>Converts a hex color string (e.g. #FFFFFF) to a Color.</summary>
    Protected Shared Function H(hexColor As String) As Color
        Return ColorTranslator.FromHtml(hexColor)
    End Function

End Class