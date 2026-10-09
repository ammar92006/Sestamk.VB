Imports System.Drawing
Imports System.Windows.Forms
Imports Guna.UI2.WinForms

''' <summary>
''' Recursive Control traversal and theming engine.
''' Applies ThemePalette tokens to all supported control types.
''' Never modifies: Layout, Size, Location, Dock, Anchor, RTL, Fonts,
'''                 business logic, data bindings, or event handlers.
''' Includes protective guards for dynamically generated and custom-painted controls.
''' </summary>
Public NotInheritable Class ThemeHelper

    ' ──────────────────────────────────────────────────────────
    '  Entry Points
    ' ──────────────────────────────────────────────────────────

    ''' <summary>Apply theme to a Form and all its child controls.</summary>
    Public Shared Sub ApplyToForm(frm As Form, palette As ThemePalette)
        If frm Is Nothing OrElse frm.IsDisposed Then Return
        If TypeOf frm Is FrmKitchenDisplay Then
            DirectCast(frm, FrmKitchenDisplay).ApplyTheme()
            Return
        End If
        If TypeOf frm Is SplashScreen OrElse TypeOf frm Is FormActivation OrElse TypeOf frm Is FormUpdateNotifier OrElse TypeOf frm Is frmToast Then
            Return
        End If

        frm.SuspendLayout()
        Try
            ' تفعيل الرسم المزدوج في الذاكرة لتسريع العرض ومنع الوميض والتهنيج
            FormHelper.EnableDoubleBuffering(frm)

            frm.BackColor = palette.Background
            frm.ForeColor = palette.TextPrimary

            For Each ctrl As Control In frm.Controls
                ApplyToControl(ctrl, palette)
            Next

            ' Apply ToolStrip renderer to the form's ToolStrips
            ApplyToolStripRenderer(frm, palette)

            ' Specialized high-contrast theming for POS Cashier Screen
            If TypeOf frm Is frmPOS Then
                DirectCast(frm, frmPOS).ApplyPOSTheme(palette)
            End If
        Finally
            frm.ResumeLayout(True)
        End Try
    End Sub

    ''' <summary>
    ''' Apply theme to a single Control and recurse into its children.
    ''' Called for every control in the tree.
    ''' </summary>
    Public Shared Sub ApplyToControl(ctrl As Control, palette As ThemePalette)
        If ctrl Is Nothing OrElse ctrl.IsDisposed Then Return

        Try
            ' ── Protective Guards for Business & Dynamic Controls ──
            ' Guard 1: Do not overwrite child buttons of dynamic category/product containers in frmPOS or table cards in FrmSelectTable
            If ctrl.Parent IsNot Nothing Then
                Dim pName As String = ctrl.Parent.Name.ToLower()
                If pName = "flpcategories" OrElse pName = "flpproducts" OrElse pName = "flptables" Then
                    Return
                End If
            End If

            If TypeOf ctrl.Tag Is RestaurantTableModel Then
                Return
            End If

            Dim cNameLower As String = ctrl.Name.ToLower()

            ' Guard 2: UCCategoryCard color badge panel preserves its category color from SQL
            If cNameLower = "pnlcolor" Then
                Return
            End If

            ' Guard 3: For POS dynamic containers, style the panel itself but DO NOT touch internal buttons
            If cNameLower = "flpcategories" OrElse cNameLower = "flpproducts" Then
                ctrl.BackColor = palette.Background
                Return
            End If

            ' Guard 4: Theme switcher buttons and switches manage their own custom active/inactive visual state
            If cNameLower = "btnthemetoggle" OrElse cNameLower = "btnthemelight" OrElse cNameLower = "btnthemedark" OrElse cNameLower = "tgltheme" Then
                Return
            End If

            ' Guard 5: Branding and side hero panels (e.g. pn_0 in Login) have custom gradients and styled labels
            If cNameLower = "pn_0" Then
                Return
            End If
            If ctrl.Parent IsNot Nothing AndAlso ctrl.Parent.Name.ToLower() = "pn_0" Then
                Return
            End If

            ' ── Dispatch by type (most specific first) ──────────────

            ' Guna2 Controls
            If TypeOf ctrl Is Guna2Button Then
                ApplyGuna2Button(DirectCast(ctrl, Guna2Button), palette)
            ElseIf TypeOf ctrl Is Guna2TextBox Then
                ApplyGuna2TextBox(DirectCast(ctrl, Guna2TextBox), palette)
            ElseIf TypeOf ctrl Is Guna2ComboBox Then
                ApplyGuna2ComboBox(DirectCast(ctrl, Guna2ComboBox), palette)
            ElseIf TypeOf ctrl Is Guna2DateTimePicker Then
                ApplyGuna2DateTimePicker(DirectCast(ctrl, Guna2DateTimePicker), palette)
            ElseIf TypeOf ctrl Is Guna2NumericUpDown Then
                ApplyGuna2NumericUpDown(DirectCast(ctrl, Guna2NumericUpDown), palette)
            ElseIf TypeOf ctrl Is Guna2RadioButton Then
                ApplyGuna2RadioButton(DirectCast(ctrl, Guna2RadioButton), palette)
            ElseIf TypeOf ctrl Is Guna2Panel Then
                ApplyGuna2Panel(DirectCast(ctrl, Guna2Panel), palette)
            ElseIf TypeOf ctrl Is Guna2GroupBox Then
                ApplyGuna2GroupBox(DirectCast(ctrl, Guna2GroupBox), palette)
            ElseIf TypeOf ctrl Is Guna2ToggleSwitch Then
                ApplyGuna2ToggleSwitch(DirectCast(ctrl, Guna2ToggleSwitch), palette)
            ElseIf TypeOf ctrl Is Guna2CheckBox Then
                ApplyGuna2CheckBox(DirectCast(ctrl, Guna2CheckBox), palette)
            ElseIf TypeOf ctrl Is Guna2TabControl Then
                ApplyGuna2TabControl(DirectCast(ctrl, Guna2TabControl), palette)
            ElseIf TypeOf ctrl Is Guna2HtmlLabel Then
                ApplyGuna2HtmlLabel(DirectCast(ctrl, Guna2HtmlLabel), palette)
            ElseIf TypeOf ctrl Is Guna2PictureBox Then
                DirectCast(ctrl, Guna2PictureBox).BackColor = Color.Transparent
            ElseIf TypeOf ctrl Is Guna2ControlBox Then
                ApplyGuna2ControlBox(DirectCast(ctrl, Guna2ControlBox), palette)

            ' Standard WinForms — DataGridView first
            ElseIf TypeOf ctrl Is DataGridView Then
                ApplyDataGridViewTheme(DirectCast(ctrl, DataGridView), palette)

            ' Standard WinForms — ToolStrip family
            ElseIf TypeOf ctrl Is MenuStrip Then
                ApplyMenuStrip(DirectCast(ctrl, MenuStrip), palette)
            ElseIf TypeOf ctrl Is ContextMenuStrip Then
                ApplyContextMenuStrip(DirectCast(ctrl, ContextMenuStrip), palette)
            ElseIf TypeOf ctrl Is StatusStrip Then
                ApplyStatusStrip(DirectCast(ctrl, StatusStrip), palette)
            ElseIf TypeOf ctrl Is ToolStrip Then
                ApplyToolStrip(DirectCast(ctrl, ToolStrip), palette)

            ' Standard WinForms — Containers
            ElseIf TypeOf ctrl Is TabControl Then
                ApplyTabControl(DirectCast(ctrl, TabControl), palette)
            ElseIf TypeOf ctrl Is GroupBox Then
                ctrl.BackColor = palette.Surface
                ctrl.ForeColor = palette.TextPrimary
            ElseIf TypeOf ctrl Is SplitContainer Then
                ctrl.BackColor = palette.Background
            ElseIf TypeOf ctrl Is FlowLayoutPanel Then
                ctrl.BackColor = palette.Background

            ' Standard WinForms — Inputs
            ElseIf TypeOf ctrl Is RichTextBox Then
                ctrl.BackColor = palette.InputBackground
                ctrl.ForeColor = palette.InputForeground
            ElseIf TypeOf ctrl Is TextBox Then
                ctrl.BackColor = palette.InputBackground
                ctrl.ForeColor = palette.InputForeground
            ElseIf TypeOf ctrl Is MaskedTextBox Then
                ctrl.BackColor = palette.InputBackground
                ctrl.ForeColor = palette.InputForeground
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.BackColor = palette.InputBackground
                ctrl.ForeColor = palette.InputForeground
            ElseIf TypeOf ctrl Is ListBox Then
                ctrl.BackColor = palette.InputBackground
                ctrl.ForeColor = palette.InputForeground
            ElseIf TypeOf ctrl Is CheckedListBox Then
                ctrl.BackColor = palette.InputBackground
                ctrl.ForeColor = palette.TextPrimary
            ElseIf TypeOf ctrl Is NumericUpDown Then
                ctrl.BackColor = palette.InputBackground
                ctrl.ForeColor = palette.InputForeground
            ElseIf TypeOf ctrl Is DateTimePicker Then
                ctrl.BackColor = palette.InputBackground
                ctrl.ForeColor = palette.InputForeground

            ' Standard WinForms — Buttons / Toggles
            ElseIf TypeOf ctrl Is Button Then
                ApplyStandardButton(DirectCast(ctrl, Button), palette)
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.BackColor = Color.Transparent
                ctrl.ForeColor = palette.TextPrimary
            ElseIf TypeOf ctrl Is RadioButton Then
                ctrl.BackColor = Color.Transparent
                ctrl.ForeColor = palette.TextPrimary

            ' Standard WinForms — Labels
            ElseIf TypeOf ctrl Is LinkLabel Then
                DirectCast(ctrl, LinkLabel).LinkColor = palette.Info
                ctrl.BackColor = Color.Transparent
            ElseIf TypeOf ctrl Is Label Then
                ApplyLabel(DirectCast(ctrl, Label), palette)

            ' Standard WinForms — Display
            ElseIf TypeOf ctrl Is ProgressBar Then
                ctrl.BackColor = palette.Surface
            ElseIf TypeOf ctrl Is PictureBox Then
                ctrl.BackColor = Color.Transparent
            ElseIf TypeOf ctrl Is TreeView Then
                ctrl.BackColor = palette.Surface
                ctrl.ForeColor = palette.TextPrimary

            ' Panel (generic — after all specific panel types)
            ElseIf TypeOf ctrl Is Panel Then
                ApplyPanel(DirectCast(ctrl, Panel), palette)

            ' UserControl — apply recursively
            ElseIf TypeOf ctrl Is UserControl Then
                ctrl.BackColor = palette.Background
                ctrl.ForeColor = palette.TextPrimary
            End If

        Catch ex As Exception
            ' Never block theme application due to a single control error
            Logger.LogError("ThemeHelper.vb:218", ex)
        End Try

        ' ── Recurse into children ────────────────────────────────
        ' Skip containers whose children were already handled or should be guarded
        If TypeOf ctrl Is DataGridView Then Return
        If TypeOf ctrl Is MenuStrip Then Return
        If TypeOf ctrl Is ContextMenuStrip Then Return
        If TypeOf ctrl Is ToolStrip Then Return
        If TypeOf ctrl Is StatusStrip Then Return

        For Each child As Control In ctrl.Controls
            ApplyToControl(child, palette)
        Next
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Panel helpers
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyPanel(pnl As Panel, palette As ThemePalette)
        Dim nameLower As String = pnl.Name.ToLower()

        ' Header panels keep their distinctive header styling
        If nameLower.Contains("header") OrElse nameLower = "pnlheader" OrElse nameLower = "panelheader" Then
            pnl.BackColor = palette.SurfaceHeader
            pnl.ForeColor = palette.TextOnDark
            Return
        End If

        ' Navigation panels
        If nameLower.Contains("nav") OrElse nameLower.Contains("sidebar") OrElse nameLower.Contains("menu") Then
            pnl.BackColor = palette.NavBackground
            pnl.ForeColor = palette.NavText
            Return
        End If

        pnl.BackColor = palette.Surface
        pnl.ForeColor = palette.TextPrimary
    End Sub

    Private Shared Sub ApplyGuna2Panel(pnl As Guna2Panel, palette As ThemePalette)
        Dim nameLower As String = pnl.Name.ToLower()

        If nameLower = "panelheader" OrElse nameLower = "pnlheader" Then
            pnl.FillColor = palette.SurfaceHeader
            pnl.BackColor = Color.Transparent
            If palette.ThemeType = AppTheme.Light Then
                pnl.BorderColor = palette.Border
                pnl.BorderThickness = 1
            End If
            Return
        End If

        If nameLower.StartsWith("pnlheader") Then
            pnl.FillColor = palette.CardBackground
            pnl.BorderColor = palette.Border
            pnl.BorderThickness = 1
            pnl.BackColor = Color.Transparent
            Return
        End If

        If nameLower.Contains("nav") OrElse nameLower.Contains("sidebar") Then
            pnl.FillColor = palette.NavBackground
            pnl.BackColor = Color.Transparent
            If palette.ThemeType = AppTheme.Light Then
                pnl.BorderColor = palette.Border
                pnl.BorderThickness = 1
            End If
            Return
        End If

        ' Divider lines (thin panels used as horizontal or vertical separators)
        If pnl.Height <= 3 OrElse pnl.Width <= 3 OrElse nameLower.Contains("line") OrElse nameLower.Contains("divider") OrElse nameLower.Contains("sep") Then
            pnl.FillColor = palette.Divider
            pnl.BackColor = Color.Transparent
            Return
        End If

        pnl.FillColor = palette.Surface
        pnl.BackColor = Color.Transparent
        If pnl.BorderThickness > 0 Then
            pnl.BorderColor = palette.CardBorder
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2ControlBox helper
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2ControlBox(box As Guna2ControlBox, palette As ThemePalette)
        Try
            box.FillColor = Color.Transparent
            box.IconColor = palette.TextSecondary
            If box.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox Then
                box.HoverState.FillColor = palette.Danger
                box.HoverState.IconColor = Color.White
            Else
                box.HoverState.FillColor = palette.SurfaceSecondary
                box.HoverState.IconColor = palette.TextPrimary
            End If
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:319", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Label helper
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyLabel(lbl As Label, palette As ThemePalette)
        Dim parent As Control = lbl.Parent
        If parent IsNot Nothing Then
            Dim parentName As String = parent.Name.ToLower()
            If parentName = "panelheader" Then
                lbl.ForeColor = If(palette.ThemeType = AppTheme.Dark, palette.TextOnDark, palette.TextPrimary)
                lbl.BackColor = Color.Transparent
                Return
            End If
            If parentName.StartsWith("pnlheader") Then
                Dim isDesc As Boolean = lbl.Name.ToLower().Contains("desc")
                lbl.ForeColor = If(isDesc, palette.TextSecondary, palette.TextPrimary)
                lbl.BackColor = Color.Transparent
                Return
            End If

            ' Determine effective background color of parent (supports Guna2Panel FillColor)
            Dim parentBg As Color = parent.BackColor
            If TypeOf parent Is Guna2Panel Then
                Dim gp = DirectCast(parent, Guna2Panel)
                If gp.FillColor <> Color.Empty AndAlso gp.FillColor <> Color.Transparent Then
                    parentBg = gp.FillColor
                End If
            End If

            ' High contrast check based on effective parent background using WCAG luminance
            If ThemePalette.GetRelativeLuminance(parentBg) < 0.35 Then
                lbl.ForeColor = palette.TextOnDark
            Else
                lbl.ForeColor = palette.TextPrimary
            End If
            lbl.BackColor = Color.Transparent
            Return
        End If
        lbl.ForeColor = palette.TextPrimary
        lbl.BackColor = Color.Transparent
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2Button
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2Button(btn As Guna2Button, palette As ThemePalette)
        Try
            Dim nameLower As String = btn.Name.ToLower()
            Dim textLower As String = btn.Text.ToLower()
            Dim fillColor As Color = btn.FillColor
            Dim targetFill As Color
            Dim targetFore As Color = palette.ButtonForeground
            Dim targetHover As Color
            Dim targetPressed As Color = palette.ButtonPressed

            ' Window corner close buttons or buttons configured with transparent fill
            If (nameLower = "btnclose" OrElse nameLower.Contains("close")) AndAlso (fillColor = Color.Empty OrElse fillColor = Color.Transparent OrElse btn.BorderRadius >= 15) Then
                btn.FillColor = Color.Transparent
                btn.ForeColor = palette.TextSecondary
                Try
                    btn.HoverState.FillColor = palette.Danger
                    btn.HoverState.ForeColor = Color.White
                Catch __logEx As Exception
                    Logger.LogError("ThemeHelper.vb:385", __logEx)
                End Try
                Return
            End If

            ' ── Sidebar & Navigation Buttons Guard ─────────────────────
            Dim isNavButton As Boolean = False
            Dim curParent As Control = btn.Parent
            While curParent IsNot Nothing
                Dim pName As String = curParent.Name.ToLower()
                If pName.Contains("sidebar") OrElse pName.Contains("nav") Then
                    isNavButton = True
                    Exit While
                End If
                curParent = curParent.Parent
            End While

            If isNavButton Then
                btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
                btn.CheckedState.FillColor = palette.NavSelected
                btn.CheckedState.ForeColor = palette.NavSelectedText
                btn.HoverState.FillColor = palette.NavHover
                btn.HoverState.ForeColor = Color.White
                If btn.Checked Then
                    btn.FillColor = palette.NavSelected
                    btn.ForeColor = palette.NavSelectedText
                Else
                    btn.FillColor = Color.Transparent
                    btn.ForeColor = palette.NavText
                End If
                Return
            End If

            ' ── Generic Toggle Buttons (e.g. Percentage unit toggle) ───
            If btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton Then
                btn.CheckedState.FillColor = palette.Primary
                btn.CheckedState.ForeColor = palette.TextOnPrimary
                If Not btn.Checked Then
                    btn.FillColor = palette.SurfaceSecondary
                    btn.ForeColor = palette.TextSecondary
                    btn.BorderColor = palette.Border
                    btn.BorderThickness = 1
                    btn.HoverState.FillColor = palette.ButtonSecondaryHover
                    btn.HoverState.ForeColor = palette.TextPrimary
                    Return
                End If
            End If

            ' Semantic Detection by Name/Text and existing FillColor
            If nameLower.Contains("close") OrElse nameLower.Contains("delete") OrElse nameLower.Contains("del") OrElse textLower.Contains("حذف") OrElse IsSemanticDanger(fillColor) Then
                targetFill = palette.Danger
                targetHover = palette.DangerHover
                targetFore = palette.DangerText
            ElseIf nameLower.Contains("save") OrElse nameLower.Contains("add") OrElse nameLower.Contains("submit") OrElse textLower.Contains("اضافة") OrElse textLower.Contains("إضافة") OrElse textLower.Contains("حفظ") OrElse IsSemanticSuccess(fillColor) Then
                targetFill = palette.Success
                targetHover = palette.SuccessHover
                targetFore = palette.SuccessText
            ElseIf nameLower.Contains("edit") OrElse nameLower.Contains("update") OrElse textLower.Contains("تعديل") OrElse IsSemanticWarning(fillColor) Then
                targetFill = palette.Warning
                targetHover = palette.WarningHover
                targetFore = palette.WarningText
            ElseIf nameLower.Contains("print") OrElse textLower.Contains("طباعة") OrElse IsSemanticInfo(fillColor) Then
                targetFill = palette.Info
                targetHover = palette.InfoHover
                targetFore = palette.InfoText
            ElseIf nameLower.Contains("clean") OrElse nameLower.Contains("clear") OrElse textLower.Contains("مسح") OrElse IsNeutralDark(fillColor) Then
                targetFill = palette.Surface
                targetFore = palette.TextPrimary
                targetHover = palette.SurfaceSecondary
            ElseIf fillColor = Color.Empty OrElse fillColor = Color.Transparent Then
                ' Transparent buttons — keep transparent
                btn.ForeColor = palette.TextPrimary
                btn.BackColor = Color.Transparent
                btn.DisabledState.FillColor = Color.Transparent
                btn.DisabledState.ForeColor = palette.TextDisabled
                Return
            Else
                ' Default: Primary Action Button
                targetFill = palette.ButtonBackground
                targetHover = palette.ButtonHover
            End If

            btn.FillColor = targetFill
            btn.ForeColor = targetFore

            Try
                btn.HoverState.FillColor = targetHover
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:473", __logEx)
            End Try

            Try
                btn.PressedColor = targetPressed
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:479", __logEx)
            End Try

            btn.DisabledState.FillColor = palette.ButtonDisabledBackground
            btn.DisabledState.ForeColor = palette.ButtonDisabledForeground
            btn.DisabledState.BorderColor = palette.Border

        Catch ex As Exception
            Logger.LogError("ThemeHelper.vb:487", ex)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Standard Button
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyStandardButton(btn As Button, palette As ThemePalette)
        Dim nameLower As String = btn.Name.ToLower()
        Dim textLower As String = btn.Text.ToLower()
        Dim fillColor As Color = btn.BackColor

        If nameLower.Contains("delete") OrElse nameLower.Contains("del") OrElse textLower.Contains("حذف") OrElse IsSemanticDanger(fillColor) Then
            btn.BackColor = palette.Danger
            btn.ForeColor = palette.DangerText
        ElseIf nameLower.Contains("save") OrElse nameLower.Contains("add") OrElse textLower.Contains("حفظ") OrElse textLower.Contains("اضافة") OrElse IsSemanticSuccess(fillColor) Then
            btn.BackColor = palette.Success
            btn.ForeColor = palette.SuccessText
        ElseIf nameLower.Contains("edit") OrElse textLower.Contains("تعديل") OrElse IsSemanticWarning(fillColor) Then
            btn.BackColor = palette.Warning
            btn.ForeColor = palette.WarningText
        ElseIf IsNeutralDark(fillColor) Then
            btn.BackColor = palette.Surface
            btn.ForeColor = palette.TextPrimary
        Else
            btn.BackColor = palette.ButtonBackground
            btn.ForeColor = palette.ButtonForeground
        End If

        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderColor = palette.Border
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2TextBox
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2TextBox(txt As Guna2TextBox, palette As ThemePalette)
        Try
            txt.FillColor = palette.InputBackground
            txt.ForeColor = palette.InputForeground
            txt.BorderColor = palette.InputBorder
            txt.PlaceholderForeColor = palette.TextSecondary

            Try
                txt.FocusedState.BorderColor = palette.InputFocusBorder
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:533", __logEx)
            End Try
            Try
                txt.HoverState.BorderColor = palette.InputHoverBorder
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:538", __logEx)
            End Try

            txt.DisabledState.FillColor = palette.InputDisabledBackground
            txt.DisabledState.ForeColor = palette.InputDisabledForeground
            txt.DisabledState.BorderColor = palette.Border
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:545", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2ComboBox
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2ComboBox(cmb As Guna2ComboBox, palette As ThemePalette)
        Try
            cmb.FillColor = palette.InputBackground
            cmb.ForeColor = palette.InputForeground
            cmb.BorderColor = palette.InputBorder

            Try
                cmb.FocusedState.BorderColor = palette.InputFocusBorder
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:561", __logEx)
            End Try
            Try
                cmb.HoverState.BorderColor = palette.InputHoverBorder
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:566", __logEx)
            End Try

            Try
                If cmb.ItemsAppearance IsNot Nothing Then
                    cmb.ItemsAppearance.BackColor = palette.InputBackground
                    cmb.ItemsAppearance.ForeColor = palette.InputForeground
                    cmb.ItemsAppearance.SelectedBackColor = palette.SelectionBackground
                    cmb.ItemsAppearance.SelectedForeColor = palette.SelectionForeground
                End If
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:577", __logEx)
            End Try

            cmb.DisabledState.FillColor = palette.InputDisabledBackground
            cmb.DisabledState.ForeColor = palette.InputDisabledForeground
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:583", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2DateTimePicker
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2DateTimePicker(dtp As Guna2DateTimePicker, palette As ThemePalette)
        Try
            dtp.FillColor = palette.InputBackground
            dtp.ForeColor = palette.InputForeground
            dtp.BorderColor = palette.InputBorder

            Try
                dtp.CheckedState.FillColor = palette.InputBackground
                dtp.CheckedState.BorderColor = palette.InputBorder
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:600", __logEx)
            End Try

            Try
                dtp.HoverState.BorderColor = palette.InputHoverBorder
            Catch __logEx As Exception
                Logger.LogError("ThemeHelper.vb:606", __logEx)
            End Try
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:609", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2NumericUpDown
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2NumericUpDown(num As Guna2NumericUpDown, palette As ThemePalette)
        Try
            num.FillColor = palette.InputBackground
            num.ForeColor = palette.InputForeground
            num.BorderColor = palette.InputBorder
            num.UpDownButtonFillColor = palette.SurfaceSecondary
            num.UpDownButtonForeColor = palette.TextPrimary
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:624", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2RadioButton
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2RadioButton(rb As Guna2RadioButton, palette As ThemePalette)
        Try
            rb.ForeColor = palette.TextPrimary
            rb.CheckedState.BorderColor = palette.Primary
            rb.CheckedState.FillColor = palette.Primary
            rb.UncheckedState.BorderColor = palette.Border
            rb.UncheckedState.FillColor = palette.Surface
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:639", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2GroupBox
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2GroupBox(grp As Guna2GroupBox, palette As ThemePalette)
        Try
            grp.FillColor = palette.Surface
            grp.ForeColor = palette.TextPrimary
            grp.CustomBorderColor = palette.SurfaceSecondary
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:652", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2HtmlLabel
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2HtmlLabel(lbl As Guna2HtmlLabel, palette As ThemePalette)
        Try
            Dim parent As Control = lbl.Parent
            If parent IsNot Nothing AndAlso
               (parent.Name.ToLower().Contains("header") OrElse
                ThemePalette.GetRelativeLuminance(parent.BackColor) < 0.35) Then
                lbl.ForeColor = palette.TextOnDark
            Else
                lbl.ForeColor = palette.TextPrimary
            End If
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:670", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2ToggleSwitch
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2ToggleSwitch(tg As Guna2ToggleSwitch, palette As ThemePalette)
        Try
            tg.CheckedState.FillColor = palette.ToggleCheckedFill
            tg.CheckedState.BorderColor = palette.ToggleCheckedFill
            tg.CheckedState.InnerColor = palette.ToggleInnerColor

            tg.UncheckedState.FillColor = palette.ToggleUncheckedFill
            tg.UncheckedState.BorderColor = palette.ToggleUncheckedFill
            tg.UncheckedState.InnerColor = palette.ToggleInnerColor
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:687", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2CheckBox
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2CheckBox(chk As Guna2CheckBox, palette As ThemePalette)
        Try
            chk.CheckedState.FillColor = palette.ToggleCheckedFill
            chk.CheckedState.BorderColor = palette.ToggleCheckedFill
            chk.UncheckedState.FillColor = palette.ToggleUncheckedFill
            chk.UncheckedState.BorderColor = palette.ToggleUncheckedFill
            chk.ForeColor = palette.TextPrimary
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:702", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Guna2TabControl
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyGuna2TabControl(tab As Guna2TabControl, palette As ThemePalette)
        Try
            tab.BackColor = palette.TabBackground
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:713", __logEx)
        End Try

        For Each pg As TabPage In tab.TabPages
            pg.BackColor = palette.TabBackground
            pg.ForeColor = palette.TabText
            For Each child As Control In pg.Controls
                ApplyToControl(child, palette)
            Next
        Next
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Standard TabControl
    ' ──────────────────────────────────────────────────────────
    Private Shared Sub ApplyTabControl(tab As TabControl, palette As ThemePalette)
        tab.BackColor = palette.TabBackground

        For Each pg As TabPage In tab.TabPages
            pg.BackColor = palette.TabBackground
            pg.ForeColor = palette.TabText
            For Each child As Control In pg.Controls
                ApplyToControl(child, palette)
            Next
        Next
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  DataGridView
    ' ──────────────────────────────────────────────────────────
    Public Shared Sub ApplyDataGridViewTheme(dgv As DataGridView, palette As ThemePalette)
        Try
            dgv.BackgroundColor = palette.GridBackground
            dgv.GridColor = palette.GridBorder
            dgv.ForeColor = palette.GridForeground

            ' Default row style
            dgv.DefaultCellStyle.BackColor = palette.GridBackground
            dgv.DefaultCellStyle.ForeColor = palette.GridForeground
            dgv.DefaultCellStyle.SelectionBackColor = palette.GridSelectionBackground
            dgv.DefaultCellStyle.SelectionForeColor = palette.GridSelectionForeground

            ' Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = palette.GridAlternateBackground
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = palette.GridForeground
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = palette.GridSelectionBackground
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = palette.GridSelectionForeground

            ' Column headers
            dgv.EnableHeadersVisualStyles = False
            dgv.ColumnHeadersDefaultCellStyle.BackColor = palette.GridHeaderBackground
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = palette.GridHeaderForeground
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = palette.GridHeaderBackground
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = palette.GridHeaderForeground

            ' Row headers
            dgv.RowHeadersDefaultCellStyle.BackColor = palette.GridBackground
            dgv.RowHeadersDefaultCellStyle.ForeColor = palette.GridForeground
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = palette.GridSelectionBackground
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = palette.GridSelectionForeground

            ' Also try Guna2DataGridView ThemeStyle if applicable
            TryApplyGuna2DGVTheme(dgv, palette)

        Catch ex As Exception
            Logger.LogError("ThemeHelper.vb:778", ex)
        End Try
    End Sub

    Private Shared Sub TryApplyGuna2DGVTheme(dgv As DataGridView, palette As ThemePalette)
        Try
            Dim themeStyleProp = dgv.GetType().GetProperty("ThemeStyle")
            If themeStyleProp Is Nothing Then Return

            Dim themeStyle = themeStyleProp.GetValue(dgv)
            If themeStyle Is Nothing Then Return

            Dim ts = themeStyle.GetType()

            SetReflProp(themeStyle, ts, "BackColor", palette.GridBackground)

            Dim headerStyle = GetReflProp(themeStyle, ts, "HeaderStyle")
            If headerStyle IsNot Nothing Then
                Dim hs = headerStyle.GetType()
                SetReflProp(headerStyle, hs, "BackColor", palette.GridHeaderBackground)
                SetReflProp(headerStyle, hs, "ForeColor", palette.GridHeaderForeground)
            End If

            Dim rowsStyle = GetReflProp(themeStyle, ts, "RowsStyle")
            If rowsStyle IsNot Nothing Then
                Dim rs = rowsStyle.GetType()
                SetReflProp(rowsStyle, rs, "BackColor", palette.GridBackground)
                SetReflProp(rowsStyle, rs, "ForeColor", palette.GridForeground)
                SetReflProp(rowsStyle, rs, "SelectionBackColor", palette.GridSelectionBackground)
                SetReflProp(rowsStyle, rs, "SelectionForeColor", palette.GridSelectionForeground)
            End If

            Dim altStyle = GetReflProp(themeStyle, ts, "AlternatingRowsStyle")
            If altStyle IsNot Nothing Then
                Dim ar = altStyle.GetType()
                SetReflProp(altStyle, ar, "BackColor", palette.GridAlternateBackground)
                SetReflProp(altStyle, ar, "ForeColor", palette.GridForeground)
            End If
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:817", __logEx)
        End Try
    End Sub

    Private Shared Function GetReflProp(obj As Object, t As Type, propName As String) As Object
        Try
            Dim p = t.GetProperty(propName)
            If p IsNot Nothing Then Return p.GetValue(obj)
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:826", __logEx)
        End Try
        Return Nothing
    End Function

    Private Shared Sub SetReflProp(obj As Object, t As Type, propName As String, value As Object)
        Try
            Dim p = t.GetProperty(propName)
            If p IsNot Nothing Then p.SetValue(obj, value)
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:836", __logEx)
        End Try
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  ToolStrip / MenuStrip / StatusStrip / ContextMenuStrip
    ' ──────────────────────────────────────────────────────────
    Public Shared Sub ApplyToolStripRenderer(frm As Form, palette As ThemePalette)
        Try
            Dim renderer As New ThemeToolStripRenderer(palette)
            ApplyRendererToForm(frm, renderer)
        Catch __logEx As Exception
            Logger.LogError("ThemeHelper.vb:909", __logEx)
        End Try
    End Sub

    Private Shared Sub ApplyRendererToForm(parent As Control, renderer As ToolStripRenderer)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is ToolStrip Then
                DirectCast(ctrl, ToolStrip).Renderer = renderer
            ElseIf TypeOf ctrl Is MenuStrip Then
                DirectCast(ctrl, MenuStrip).Renderer = renderer
            ElseIf TypeOf ctrl Is StatusStrip Then
                DirectCast(ctrl, StatusStrip).Renderer = renderer
            End If
            If ctrl.Controls.Count > 0 Then
                ApplyRendererToForm(ctrl, renderer)
            End If
        Next
    End Sub

    Private Shared Sub ApplyMenuStrip(ms As MenuStrip, palette As ThemePalette)
        ms.BackColor = palette.MenuBackground
        ms.ForeColor = palette.MenuForeground
        ms.Renderer = New ThemeToolStripRenderer(palette)
        ApplyToolStripItems(ms.Items, palette)
    End Sub

    Private Shared Sub ApplyContextMenuStrip(cms As ContextMenuStrip, palette As ThemePalette)
        cms.BackColor = palette.MenuBackground
        cms.ForeColor = palette.MenuForeground
        cms.Renderer = New ThemeToolStripRenderer(palette)
        ApplyToolStripItems(cms.Items, palette)
    End Sub

    Private Shared Sub ApplyStatusStrip(ss As StatusStrip, palette As ThemePalette)
        ss.BackColor = palette.MenuBackground
        ss.ForeColor = palette.MenuForeground
        ss.Renderer = New ThemeToolStripRenderer(palette)
    End Sub

    Private Shared Sub ApplyToolStrip(ts As ToolStrip, palette As ThemePalette)
        ts.BackColor = palette.MenuBackground
        ts.ForeColor = palette.MenuForeground
        ts.Renderer = New ThemeToolStripRenderer(palette)
        ApplyToolStripItems(ts.Items, palette)
    End Sub

    Private Shared Sub ApplyToolStripItems(items As ToolStripItemCollection, palette As ThemePalette)
        For Each item As ToolStripItem In items
            item.BackColor = palette.MenuBackground
            item.ForeColor = palette.MenuForeground

            If TypeOf item Is ToolStripMenuItem Then
                Dim mi = DirectCast(item, ToolStripMenuItem)
                If mi.HasDropDownItems Then
                    ApplyToolStripItems(mi.DropDownItems, palette)
                End If
            End If
        Next
    End Sub

    ' ──────────────────────────────────────────────────────────
    '  Semantic Color Detection Helpers
    ' ──────────────────────────────────────────────────────────
    Private Shared Function IsSemanticDanger(c As Color) As Boolean
        If c = Color.Empty OrElse c = Color.Transparent Then Return False
        Return c.R > 150 AndAlso c.R > c.G * 1.5 AndAlso c.R > c.B * 1.5
    End Function

    Private Shared Function IsSemanticSuccess(c As Color) As Boolean
        If c = Color.Empty OrElse c = Color.Transparent Then Return False
        Return c.G > 100 AndAlso c.G > c.R * 1.3 AndAlso c.G > c.B * 1.0 AndAlso c.R < 200
    End Function

    Private Shared Function IsSemanticWarning(c As Color) As Boolean
        If c = Color.Empty OrElse c = Color.Transparent Then Return False
        Return c.R > 180 AndAlso c.G > 80 AndAlso c.G < 180 AndAlso c.B < 60
    End Function

    Private Shared Function IsSemanticInfo(c As Color) As Boolean
        If c = Color.Empty OrElse c = Color.Transparent Then Return False
        Return c.B > 150 AndAlso c.B > c.R * 1.3
    End Function

    Private Shared Function IsNeutralDark(c As Color) As Boolean
        If c = Color.Empty OrElse c = Color.Transparent Then Return False
        Dim maxDiff As Integer = Math.Max(Math.Abs(CInt(c.R) - CInt(c.G)),
                                 Math.Max(Math.Abs(CInt(c.G) - CInt(c.B)),
                                          Math.Abs(CInt(c.R) - CInt(c.B))))
        Return c.GetBrightness() < 0.45 AndAlso maxDiff < 40
    End Function

End Class

' =============================================================
'  ThemeToolStripRenderer — Custom ToolStrip Professional Renderer
' =============================================================
Public Class ThemeToolStripRenderer
    Inherits ToolStripProfessionalRenderer

    Private ReadOnly _palette As ThemePalette

    Public Sub New(palette As ThemePalette)
        MyBase.New(New ThemeColorTable(palette))
        _palette = palette
        Me.RoundedEdges = False
    End Sub

    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
        If e.ToolStrip IsNot Nothing Then
            Using br As New SolidBrush(_palette.MenuBackground)
                e.Graphics.FillRectangle(br, e.AffectedBounds)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
        Dim item = e.Item
        If TypeOf item Is ToolStripButton Then
            Dim btn = DirectCast(item, ToolStripButton)
            If btn.Checked OrElse btn.Selected Then
                Using br As New SolidBrush(_palette.MenuHover)
                    e.Graphics.FillRectangle(br, New Rectangle(Point.Empty, item.Size))
                End Using
                Return
            End If
        End If
        If item.Selected OrElse item.Pressed Then
            Using br As New SolidBrush(_palette.MenuHover)
                e.Graphics.FillRectangle(br, New Rectangle(Point.Empty, item.Size))
            End Using
        Else
            Using br As New SolidBrush(_palette.MenuBackground)
                e.Graphics.FillRectangle(br, New Rectangle(Point.Empty, item.Size))
            End Using
        End If
    End Sub

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        If e.Item.Selected Then
            Using br As New SolidBrush(_palette.MenuHover)
                e.Graphics.FillRectangle(br, New Rectangle(Point.Empty, e.Item.Size))
            End Using
        Else
            Using br As New SolidBrush(_palette.MenuBackground)
                e.Graphics.FillRectangle(br, New Rectangle(Point.Empty, e.Item.Size))
            End Using
        End If
    End Sub

    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
        Dim rc = New Rectangle(0, e.Item.Height \ 2, e.Item.Width, 1)
        Using br As New SolidBrush(_palette.MenuBorder)
            e.Graphics.FillRectangle(br, rc)
        End Using
    End Sub

    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
        e.TextColor = _palette.MenuForeground
        MyBase.OnRenderItemText(e)
    End Sub

    Protected Overrides Sub OnRenderGrip(e As ToolStripGripRenderEventArgs)
    End Sub

End Class

''' <summary>ColorTable for ToolStripProfessionalRenderer.</summary>
Public Class ThemeColorTable
    Inherits ProfessionalColorTable

    Private ReadOnly _palette As ThemePalette

    Public Sub New(palette As ThemePalette)
        _palette = palette
    End Sub

    Public Overrides ReadOnly Property MenuItemSelected As Color
        Get
            Return _palette.MenuHover
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder As Color
        Get
            Return _palette.MenuBorder
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder As Color
        Get
            Return _palette.MenuBorder
        End Get
    End Property

    Public Overrides ReadOnly Property MenuStripGradientBegin As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

    Public Overrides ReadOnly Property MenuStripGradientEnd As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripGradientBegin As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripGradientMiddle As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripGradientEnd As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin As Color
        Get
            Return _palette.Surface
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle As Color
        Get
            Return _palette.Surface
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd As Color
        Get
            Return _palette.Surface
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonSelectedHighlight As Color
        Get
            Return _palette.MenuHover
        End Get
    End Property

    Public Overrides ReadOnly Property ButtonCheckedHighlight As Color
        Get
            Return _palette.MenuSelected
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark As Color
        Get
            Return _palette.MenuBorder
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorLight As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

    Public Overrides ReadOnly Property StatusStripGradientBegin As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

    Public Overrides ReadOnly Property StatusStripGradientEnd As Color
        Get
            Return _palette.MenuBackground
        End Get
    End Property

End Class