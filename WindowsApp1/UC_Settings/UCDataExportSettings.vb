Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports WindowsApp1.Services

Namespace UC_Settings

    ''' <summary>
    ''' شاشة تصدير واستيراد البيانات الشاملة والفردية (Excel و PDF)
    ''' مع دعم فلترة التواريخ، جهات اتصال الواتساب، وإلغاء العمليات، وشريط التقدم
    ''' </summary>
    Public Class UCDataExportSettings
        Implements ICloseRequest

        Public Event CloseRequested As EventHandler Implements ICloseRequest.CloseRequested

        Private _cts As CancellationTokenSource

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UCDataExportSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' تهيئة تواريخ الفلترة الافتراضية
            Dim today = DateTime.Today
            dtpFromDate.Value = New DateTime(today.Year, today.Month, 1)
            dtpToDate.Value = today

            PopulateEntities()
            AddHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
        End Sub

        Private Sub UCDataExportSettings_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
            RemoveHandler ThemeManager.Instance.ThemeChanged, AddressOf OnThemeChanged
            _cts?.Dispose()
            _cts = Nothing
        End Sub

        Private Sub OnThemeChanged(sender As Object, theme As AppTheme, palette As ThemePalette)
            ThemeManager.Instance.ApplyToControl(Me)
        End Sub

        Private Sub PopulateEntities()
            Try
                ' 1. ملء قائمة التصدير
                cmbExportEntity.DisplayMember = "DisplayNameAr"
                cmbExportEntity.ValueMember = "Key"
                cmbExportEntity.DataSource = DataExportImportService.SupportedEntities

                ' 2. ملء قائمة الاستيراد (الأقسام التي تدعم الاستيراد)
                Dim importableList As New List(Of EntityExportInfo)()
                For Each item In DataExportImportService.SupportedEntities
                    If item.CanImport Then
                        importableList.Add(item)
                    End If
                Next

                cmbImportEntity.DisplayMember = "DisplayNameAr"
                cmbImportEntity.ValueMember = "Key"
                cmbImportEntity.DataSource = importableList

                If cmbExportEntity.Items.Count > 0 Then
                    cmbExportEntity.SelectedIndex = 0
                End If
                If cmbImportEntity.Items.Count > 0 Then
                    cmbImportEntity.SelectedIndex = 0
                End If
            Catch ex As Exception
                Debug.WriteLine("PopulateEntities error: " & ex.Message)
            End Try
        End Sub

        Private Sub cmbExportEntity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbExportEntity.SelectedIndexChanged
            RefreshExportRecordCount()
        End Sub

        Private Sub chkFilterByDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkFilterByDate.CheckedChanged
            Dim isFiltered = chkFilterByDate.Checked
            dtpFromDate.Enabled = isFiltered
            dtpToDate.Enabled = isFiltered
            btnPresetToday.Enabled = isFiltered
            btnPresetThisMonth.Enabled = isFiltered
            btnPresetAll.Enabled = isFiltered
            RefreshExportRecordCount()
        End Sub

        Private Sub dtpFromDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFromDate.ValueChanged
            If chkFilterByDate.Checked Then
                RefreshExportRecordCount()
            End If
        End Sub

        Private Sub dtpToDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpToDate.ValueChanged
            If chkFilterByDate.Checked Then
                RefreshExportRecordCount()
            End If
        End Sub

        Private Sub btnPresetToday_Click(sender As Object, e As EventArgs) Handles btnPresetToday.Click
            dtpFromDate.Value = DateTime.Today
            dtpToDate.Value = DateTime.Today
            RefreshExportRecordCount()
        End Sub

        Private Sub btnPresetThisMonth_Click(sender As Object, e As EventArgs) Handles btnPresetThisMonth.Click
            Dim today = DateTime.Today
            dtpFromDate.Value = New DateTime(today.Year, today.Month, 1)
            dtpToDate.Value = New DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month))
            RefreshExportRecordCount()
        End Sub

        Private Sub btnPresetAll_Click(sender As Object, e As EventArgs) Handles btnPresetAll.Click
            chkFilterByDate.Checked = False
        End Sub

        Private Async Sub RefreshExportRecordCount()
            Dim entity = TryCast(cmbExportEntity.SelectedItem, EntityExportInfo)
            If entity Is Nothing Then Exit Sub

            lblExportCountInfo.Text = "جارٍ حساب السجلات..."

            Dim fromDate As Nullable(Of DateTime) = Nothing
            Dim toDate As Nullable(Of DateTime) = Nothing

            If chkFilterByDate.Checked Then
                If String.IsNullOrEmpty(entity.DateColumnName) Then
                    lblExportCountInfo.Text = "القسم الحالي لا يرتبط بتاريخ (يتم جلب الكل)"
                Else
                    fromDate = dtpFromDate.Value.Date
                    toDate = dtpToDate.Value.Date
                End If
            End If

            Try
                Dim count = Await Task.Run(
                    Function() As Integer
                        Dim dt = DataExportImportService.GetEntityDataTable(entity, fromDate, toDate)
                        Return dt.Rows.Count
                    End Function)

                If chkFilterByDate.Checked AndAlso Not String.IsNullOrEmpty(entity.DateColumnName) Then
                    lblExportCountInfo.Text = $"السجلات بالفترة: {count:N0} سجل"
                Else
                    lblExportCountInfo.Text = $"إجمالي السجلات: {count:N0} سجل"
                End If
            Catch
                lblExportCountInfo.Text = "عدد السجلات: غير متوفر"
            End Try
        End Sub

        ''' <summary>
        ''' التحقق من صلاحيات الأمان للمستخدم الحالي قبل تنفيذ العمليات الحساسة
        ''' </summary>
        Private Function CheckExportPermissions(operationName As String) As Boolean
            Try
                If Session.CurrentRoleID > 1 Then
                    If Not Session.HasPermission("Settings", "CanEdit") AndAlso Not Session.HasPermission("Settings", "CanView") Then
                        SmartMessageBox.Show($"عذراً، لا تمتلك الصلاحيات الكافية لتنفيذ عملية ({operationName})." & vbCrLf &
                                        "هذه العملية مخصصة لمدير النظام أو للمستخدمين المصرح لهم.",
                                        "صلاحية غير كافية", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End If
            Catch __logEx As Exception
                ' في حال حدوث استثناء بالجلسة نسمح بالعمليات لعدم تعطيل النظام في وضع التطوير
                Logger.LogError("UCDataExportSettings.vb:169", __logEx)
            End Try
            Return True
        End Function

        ''' <summary>
        ''' إدارة حالة عناصر التحكم ورمز الإلغاء أثناء تشغيل العمليات في الخلفية
        ''' </summary>
        Private Sub SetOperationRunning(running As Boolean)
            Dim controlsEnabled = Not running
            btnExportAllExcel.Enabled = controlsEnabled
            btnExportSingleExcel.Enabled = controlsEnabled
            btnExportSinglePdf.Enabled = controlsEnabled
            btnExportWhatsApp.Enabled = controlsEnabled
            btnDownloadTemplate.Enabled = controlsEnabled
            btnSelectImportFile.Enabled = controlsEnabled
            btnStartImport.Enabled = controlsEnabled
            cmbExportEntity.Enabled = controlsEnabled
            cmbImportEntity.Enabled = controlsEnabled
            chkUpdateExisting.Enabled = controlsEnabled
            chkFilterByDate.Enabled = controlsEnabled

            If chkFilterByDate.Checked Then
                dtpFromDate.Enabled = controlsEnabled
                dtpToDate.Enabled = controlsEnabled
                btnPresetToday.Enabled = controlsEnabled
                btnPresetThisMonth.Enabled = controlsEnabled
                btnPresetAll.Enabled = controlsEnabled
            End If

            btnCancelOperation.Visible = running
            btnCancelOperation.Enabled = running

            If running Then
                _cts?.Dispose()
                _cts = New CancellationTokenSource()
            Else
                _cts?.Dispose()
                _cts = Nothing
            End If
        End Sub

        Private Sub btnCancelOperation_Click(sender As Object, e As EventArgs) Handles btnCancelOperation.Click
            If _cts IsNot Nothing AndAlso Not _cts.IsCancellationRequested Then
                lblProgressStatus.Text = "جارٍ طلب إلغاء العملية، يرجى الانتظار..."
                btnCancelOperation.Enabled = False
                _cts.Cancel()
            End If
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' 1. تصدير شامل لكافة بيانات النظام في ملف Excel واحد
        ' ─────────────────────────────────────────────────────────────
        Private Async Sub btnExportAllExcel_Click(sender As Object, e As EventArgs) Handles btnExportAllExcel.Click
            If Not CheckExportPermissions("التصدير الشامل") Then Exit Sub

            Using sfd As New SaveFileDialog()
                sfd.Filter = "ملفات إكسيل Excel Workbook (*.xlsx)|*.xlsx"
                sfd.FileName = $"Sestamk_Full_Backup_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx"
                sfd.Title = "حفظ ملف التصدير الشامل لكافة بيانات النظام"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim targetPath = sfd.FileName
                    SetOperationRunning(True)
                    progressBar.Value = 0

                    Dim progressIndicator As New Progress(Of ExportProgress)(
                        Sub(p)
                            progressBar.Value = Math.Min(100, Math.Max(0, p.Percentage))
                            lblProgressStatus.Text = p.CurrentStep
                        End Sub)

                    Try
                        Dim success = Await DataExportImportService.ExportAllToExcelAsync(targetPath, progressIndicator, _cts.Token)
                        If success Then
                            Dim msg = $"✅ تم تصدير كافة بيانات النظام في ملف إكسيل كامل بنجاح!" & vbCrLf & vbCrLf &
                                      $"المسار: {targetPath}" & vbCrLf & vbCrLf &
                                      "هل ترغب في فتح المجلد المحتوي على الملف الآن؟"
                            If SmartMessageBox.Show(msg, "نجاح التصدير الشامل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                                Dim folder = Path.GetDirectoryName(targetPath)
                                If Directory.Exists(folder) Then
                                    Process.Start("explorer.exe", $"/select,""{targetPath}""")
                                End If
                            End If
                        End If
                    Catch ex As OperationCanceledException
                        lblProgressStatus.Text = "تم إلغاء عملية التصدير الشامل."
                    Catch ex As Exception
                        SmartMessageBox.Show("حدث خطأ أثناء التصدير الشامل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        lblProgressStatus.Text = "فشلت عملية التصدير الشامل."
                    Finally
                        SetOperationRunning(False)
                    End Try
                End If
            End Using
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' 2. تصدير مخصص فردي إلى Excel (مع دعم الفلترة والإلغاء)
        ' ─────────────────────────────────────────────────────────────
        Private Async Sub btnExportSingleExcel_Click(sender As Object, e As EventArgs) Handles btnExportSingleExcel.Click
            Dim entity = TryCast(cmbExportEntity.SelectedItem, EntityExportInfo)
            If entity Is Nothing Then
                SmartMessageBox.Show("يرجى اختيار القسم المراد تصديره أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not CheckExportPermissions($"تصدير {entity.DisplayNameAr} إلى Excel") Then Exit Sub

            Using sfd As New SaveFileDialog()
                sfd.Filter = "ملفات إكسيل Excel Workbook (*.xlsx)|*.xlsx"
                sfd.FileName = $"{entity.DisplayNameAr}_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx"
                sfd.Title = $"تصدير بيانات [{entity.DisplayNameAr}] إلى Excel"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim targetPath = sfd.FileName
                    SetOperationRunning(True)
                    progressBar.Value = 0

                    Dim progressIndicator As New Progress(Of ExportProgress)(
                        Sub(p)
                            progressBar.Value = Math.Min(100, Math.Max(0, p.Percentage))
                            lblProgressStatus.Text = p.CurrentStep
                        End Sub)

                    Dim fromDate As Nullable(Of DateTime) = If(chkFilterByDate.Checked, New Nullable(Of DateTime)(dtpFromDate.Value.Date), Nothing)
                    Dim toDate As Nullable(Of DateTime) = If(chkFilterByDate.Checked, New Nullable(Of DateTime)(dtpToDate.Value.Date), Nothing)

                    Try
                        Dim success = Await DataExportImportService.ExportSingleToExcelAsync(entity.Key, targetPath, progressIndicator, fromDate, toDate, _cts.Token)
                        If success Then
                            Dim msg = $"✅ تم تصدير بيانات [{entity.DisplayNameAr}] إلى Excel بنجاح!" & vbCrLf & vbCrLf &
                                      "هل ترغب في فتح الملف الآن؟"
                            Dim choice = SmartMessageBox.Show(msg, "نجاح التصدير", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                            If choice = DialogResult.Yes Then
                                Process.Start(New ProcessStartInfo(targetPath) With {.UseShellExecute = True})
                            End If
                        End If
                    Catch ex As OperationCanceledException
                        lblProgressStatus.Text = "تم إلغاء عملية التصدير."
                    Catch ex As Exception
                        SmartMessageBox.Show("حدث خطأ أثناء تصدير Excel: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        lblProgressStatus.Text = "فشلت عملية التصدير."
                    Finally
                        SetOperationRunning(False)
                    End Try
                End If
            End Using
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' 3. تصدير مخصص فردي إلى PDF (مع دعم الفلترة والإلغاء)
        ' ─────────────────────────────────────────────────────────────
        Private Async Sub btnExportSinglePdf_Click(sender As Object, e As EventArgs) Handles btnExportSinglePdf.Click
            Dim entity = TryCast(cmbExportEntity.SelectedItem, EntityExportInfo)
            If entity Is Nothing Then
                SmartMessageBox.Show("يرجى اختيار القسم المراد تصديره أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not CheckExportPermissions($"تصدير {entity.DisplayNameAr} إلى PDF") Then Exit Sub

            Using sfd As New SaveFileDialog()
                sfd.Filter = "ملفات أدوبي PDF (*.pdf)|*.pdf"
                sfd.FileName = $"{entity.DisplayNameAr}_{DateTime.Now:yyyy-MM-dd_HH-mm}.pdf"
                sfd.Title = $"تصدير بيانات [{entity.DisplayNameAr}] إلى PDF"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim targetPath = sfd.FileName
                    SetOperationRunning(True)
                    progressBar.Value = 0

                    Dim progressIndicator As New Progress(Of ExportProgress)(
                        Sub(p)
                            progressBar.Value = Math.Min(100, Math.Max(0, p.Percentage))
                            lblProgressStatus.Text = p.CurrentStep
                        End Sub)

                    Dim fromDate As Nullable(Of DateTime) = If(chkFilterByDate.Checked, New Nullable(Of DateTime)(dtpFromDate.Value.Date), Nothing)
                    Dim toDate As Nullable(Of DateTime) = If(chkFilterByDate.Checked, New Nullable(Of DateTime)(dtpToDate.Value.Date), Nothing)

                    Try
                        Dim success = Await DataExportImportService.ExportSingleToPdfAsync(entity.Key, targetPath, progressIndicator, fromDate, toDate, _cts.Token)
                        If success Then
                            Dim msg = $"✅ تم تصدير تقرير [{entity.DisplayNameAr}] إلى PDF بنجاح وبأعلى جودة!" & vbCrLf & vbCrLf &
                                      "هل ترغب في فتح ملف الـ PDF الآن؟"
                            Dim choice = SmartMessageBox.Show(msg, "نجاح التصدير", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                            If choice = DialogResult.Yes Then
                                Process.Start(New ProcessStartInfo(targetPath) With {.UseShellExecute = True})
                            End If
                        End If
                    Catch ex As OperationCanceledException
                        lblProgressStatus.Text = "تم إلغاء عملية تصدير PDF."
                    Catch ex As Exception
                        SmartMessageBox.Show("حدث خطأ أثناء تصدير PDF: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        lblProgressStatus.Text = "فشلت عملية التصدير إلى PDF."
                    Finally
                        SetOperationRunning(False)
                    End Try
                End If
            End Using
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' 4. تصدير جهات اتصال العملاء لحملات الواتساب (WhatsApp Export)
        ' ─────────────────────────────────────────────────────────────
        Private Async Sub btnExportWhatsApp_Click(sender As Object, e As EventArgs) Handles btnExportWhatsApp.Click
            If Not CheckExportPermissions("تصدير جهات اتصال الواتساب") Then Exit Sub

            Using sfd As New SaveFileDialog()
                sfd.Filter = "ملفات إكسيل Excel Workbook (*.xlsx)|*.xlsx"
                sfd.FileName = $"عملاء_الواتساب_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx"
                sfd.Title = "تصدير أرقام العملاء وروابط الدردشة المباشرة لحملات الواتساب"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim targetPath = sfd.FileName
                    SetOperationRunning(True)
                    progressBar.Value = 0

                    Dim progressIndicator As New Progress(Of ExportProgress)(
                        Sub(p)
                            progressBar.Value = Math.Min(100, Math.Max(0, p.Percentage))
                            lblProgressStatus.Text = p.CurrentStep
                        End Sub)

                    Try
                        Dim success = Await DataExportImportService.ExportWhatsAppContactsAsync(targetPath, progressIndicator, _cts.Token)
                        If success Then
                            Dim msg = $"✅ تم تصدير جهات اتصال العملاء لحملات الواتساب بنجاح!" & vbCrLf & vbCrLf &
                                      $"الملف جاهز ويحتوي على الأرقام بالصيغة الدولية وروابط الدردشة الفورية." & vbCrLf & vbCrLf &
                                      "هل ترغب في فتح الملف الآن؟"
                            Dim choice = SmartMessageBox.Show(msg, "نجاح تصدير الواتساب", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                            If choice = DialogResult.Yes Then
                                Process.Start(New ProcessStartInfo(targetPath) With {.UseShellExecute = True})
                            End If
                        End If
                    Catch ex As OperationCanceledException
                        lblProgressStatus.Text = "تم إلغاء عملية تصدير الواتساب."
                    Catch ex As Exception
                        SmartMessageBox.Show("حدث خطأ أثناء تصدير عملاء الواتساب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        lblProgressStatus.Text = "فشلت عملية تصدير الواتساب."
                    Finally
                        SetOperationRunning(False)
                    End Try
                End If
            End Using
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' 5. تحميل نموذج إكسيل فارغ للاستيراد
        ' ─────────────────────────────────────────────────────────────
        Private Sub btnDownloadTemplate_Click(sender As Object, e As EventArgs) Handles btnDownloadTemplate.Click
            Dim entity = TryCast(cmbImportEntity.SelectedItem, EntityExportInfo)
            If entity Is Nothing Then
                SmartMessageBox.Show("يرجى اختيار نوع البيانات المراد تحميل نموذج لها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using sfd As New SaveFileDialog()
                sfd.Filter = "ملفات إكسيل Excel Workbook (*.xlsx)|*.xlsx"
                sfd.FileName = $"نموذج_استيراد_{entity.DisplayNameAr}.xlsx"
                sfd.Title = $"حفظ نموذج إكسيل استرشادي لـ [{entity.DisplayNameAr}]"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Try
                        DataExportImportService.GenerateBlankTemplate(entity.Key, sfd.FileName)
                        Dim msg = $"✅ تم حفظ النموذج الاسترشادي بنجاح!" & vbCrLf & vbCrLf &
                                  "يمكنك ملء البيانات في هذا الملف ثم استيراده مباشرة إلى النظام." & vbCrLf & vbCrLf &
                                  "هل ترغب في فتح الملف الآن لتعبئته؟"
                        If SmartMessageBox.Show(msg, "تم تجهيز النموذج", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            Process.Start(New ProcessStartInfo(sfd.FileName) With {.UseShellExecute = True})
                        End If
                    Catch ex As Exception
                        SmartMessageBox.Show("حدث خطأ أثناء إنشاء النموذج: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End Using
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' 6. اختيار ملف Excel ومعاينته
        ' ─────────────────────────────────────────────────────────────
        Private Sub btnSelectImportFile_Click(sender As Object, e As EventArgs) Handles btnSelectImportFile.Click
            Using ofd As New OpenFileDialog()
                ofd.Filter = "ملفات إكسيل Excel Workbook (*.xlsx)|*.xlsx|كافة الملفات (*.*)|*.*"
                ofd.Title = "اختر ملف Excel لاستيراد البيانات منه"

                If ofd.ShowDialog() = DialogResult.OK Then
                    txtImportFilePath.Text = ofd.FileName
                    lblProgressStatus.Text = "جارٍ قراءة الملف وتحميل المعاينة..."
                    Try
                        Dim previewDt = DataExportImportService.ReadExcelPreview(ofd.FileName, 50)
                        dgvImportPreview.DataSource = previewDt
                        lblPreviewTitle.Text = $"معاينة أولية لبيانات الملف المختار ({previewDt.Rows.Count} صف معروض):"
                        lblProgressStatus.Text = $"تم تحميل معاينة الملف بنجاح ({previewDt.Rows.Count} صف)."
                    Catch ex As Exception
                        SmartMessageBox.Show("تعذر قراءة ملف الإكسيل المحدد: " & ex.Message, "خطأ في قراءة الملف", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        lblProgressStatus.Text = "فشلت قراءة ملف الإكسيل."
                    End Try
                End If
            End Using
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' 7. بدء عملية الاستيراد وحفظ البيانات (مع إدارة الأخطاء والإلغاء)
        ' ─────────────────────────────────────────────────────────────
        Private Async Sub btnStartImport_Click(sender As Object, e As EventArgs) Handles btnStartImport.Click
            Dim entity = TryCast(cmbImportEntity.SelectedItem, EntityExportInfo)
            If entity Is Nothing Then
                SmartMessageBox.Show("يرجى اختيار نوع البيانات المراد استيرادها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not CheckExportPermissions($"استيراد بيانات {entity.DisplayNameAr}") Then Exit Sub

            Dim filePath = txtImportFilePath.Text.Trim()
            If String.IsNullOrEmpty(filePath) OrElse Not File.Exists(filePath) Then
                SmartMessageBox.Show("يرجى اختيار ملف Excel صالح للاستيراد أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnSelectImportFile.Focus()
                Return
            End If

            Dim confirmMsg = $"هل أنت متأكد من بدء استيراد البيانات إلى قسم [{entity.DisplayNameAr}]؟" & vbCrLf & vbCrLf &
                             $"الملف: {Path.GetFileName(filePath)}" & vbCrLf &
                             $"تحديث المكرر: {(If(chkUpdateExisting.Checked, "مفعل (تحديث السجلات)", "غير مفعل (تخطي المكرر)"))}"
            If SmartMessageBox.Show(confirmMsg, "تأكيد بدء الاستيراد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            SetOperationRunning(True)
            progressBar.Value = 0

            Dim progressIndicator As New Progress(Of ExportProgress)(
                Sub(p)
                    progressBar.Value = Math.Min(100, Math.Max(0, p.Percentage))
                    lblProgressStatus.Text = p.CurrentStep
                End Sub)

            Try
                Dim result = Await DataExportImportService.ImportFromExcelAsync(entity.Key, filePath, chkUpdateExisting.Checked, progressIndicator, _cts.Token)

                Dim sb As New System.Text.StringBuilder()
                sb.AppendLine($"📊 تقرير عملية استيراد [{entity.DisplayNameAr}]:")
                sb.AppendLine("────────────────────────────")
                sb.AppendLine($"• إجمالي الصفوف في الملف: {result.TotalRows}")
                sb.AppendLine($"• السجلات الجديدة المضافة: {result.SuccessCount}")
                sb.AppendLine($"• السجلات المحدثة: {result.UpdatedCount}")
                sb.AppendLine($"• السجلات المتخطاة: {result.SkippedCount}")
                sb.AppendLine($"• عدد الأخطاء / المرفوض: {result.ErrorCount}")

                If result.ErrorMessages.Count > 0 Then
                    sb.AppendLine("────────────────────────────")
                    sb.AppendLine("أبرز الملاحظات:")
                    For mIndex As Integer = 0 To Math.Min(3, result.ErrorMessages.Count - 1)
                        sb.AppendLine("- " & result.ErrorMessages(mIndex))
                    Next
                    If result.ErrorMessages.Count > 4 Then
                        sb.AppendLine($"- ... بالإضافة إلى {result.ErrorMessages.Count - 4} ملاحظات أخرى.")
                    End If
                End If

                SmartMessageBox.Show(sb.ToString(), "نتيجة الاستيراد", MessageBoxButtons.OK,
                                If(result.ErrorCount > 0, MessageBoxIcon.Warning, MessageBoxIcon.Information))

                ' إذا وُجد ملف للأخطاء والصفوف المرفوضة، نقوم بسؤال المستخدم إن كان يريد فتحه لفحصه وتصحيحه
                If Not String.IsNullOrEmpty(result.ErrorFilePath) AndAlso File.Exists(result.ErrorFilePath) Then
                    Dim errPrompt = $"⚠️ تنبيه: تم حفظ الصفوف المرفوضة وأسباب عدم قبولها في ملف إكسيل مستقل:" & vbCrLf & vbCrLf &
                                    $"{result.ErrorFilePath}" & vbCrLf & vbCrLf &
                                    "هل ترغب في فتح ملف الأخطاء الآن لمراجعتها وتصحيحها؟"
                    If SmartMessageBox.Show(errPrompt, "ملف الصفوف المرفوضة", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        Process.Start(New ProcessStartInfo(result.ErrorFilePath) With {.UseShellExecute = True})
                    End If
                End If

                ' إعادة تحديث عداد السجلات الحالي
                RefreshExportRecordCount()
            Catch ex As OperationCanceledException
                lblProgressStatus.Text = "تم إلغاء عملية الاستيراد."
            Catch ex As Exception
                SmartMessageBox.Show("حدث خطأ غير متوقع أثناء عملية الاستيراد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblProgressStatus.Text = "فشلت عملية الاستيراد."
            Finally
                SetOperationRunning(False)
            End Try
        End Sub

        ' ─────────────────────────────────────────────────────────────
        ' 8. النقر على بطاقة الميزة القادمة (التصدير المجدول)
        ' ─────────────────────────────────────────────────────────────
        Private Sub badgeComingSoon_Click(sender As Object, e As EventArgs) Handles badgeComingSoon.Click
            SmartMessageBox.Show("ميزة (النسخ والتصدير التلقائي المجدول) قيد التطوير والتجهيز." & vbCrLf & vbCrLf &
                            "ستتوفر قريباً بإذن الله في التحديث القادم، وستدعم الجدولة اليومية/الأسبوعية التلقائية وحفظ النسخ على وسائط التخزين السحابية ومحركات الأقراص المحددة.",
                            "🚀 ميزة ستتوفر قريباً", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            RaiseEvent CloseRequested(Me, EventArgs.Empty)
        End Sub

    End Class

End Namespace
