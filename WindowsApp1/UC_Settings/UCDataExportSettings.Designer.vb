Namespace UC_Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCDataExportSettings
        Inherits System.Windows.Forms.UserControl

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlMain = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.cardProgress = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardProgressTitle = New System.Windows.Forms.Label()
            Me.progressBar = New Guna.UI2.WinForms.Guna2ProgressBar()
            Me.lblProgressStatus = New System.Windows.Forms.Label()
            Me.cardExportAll = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardExportAllTitle = New System.Windows.Forms.Label()
            Me.lblExportAllDesc = New System.Windows.Forms.Label()
            Me.cardSingleExport = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardSingleExportTitle = New System.Windows.Forms.Label()
            Me.lblSelectExportEntity = New System.Windows.Forms.Label()
            Me.cmbExportEntity = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.lblExportCountInfo = New System.Windows.Forms.Label()
            Me.chkFilterByDate = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.lblFromDate = New System.Windows.Forms.Label()
            Me.dtpFromDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
            Me.lblToDate = New System.Windows.Forms.Label()
            Me.dtpToDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
            Me.btnPresetToday = New Guna.UI2.WinForms.Guna2Button()
            Me.btnPresetThisMonth = New Guna.UI2.WinForms.Guna2Button()
            Me.btnPresetAll = New Guna.UI2.WinForms.Guna2Button()
            Me.lblWhatsAppNote = New System.Windows.Forms.Label()
            Me.cardImport = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblCardImportTitle = New System.Windows.Forms.Label()
            Me.lblSelectImportEntity = New System.Windows.Forms.Label()
            Me.cmbImportEntity = New Guna.UI2.WinForms.Guna2ComboBox()
            Me.btnDownloadTemplate = New Guna.UI2.WinForms.Guna2Button()
            Me.btnSelectImportFile = New Guna.UI2.WinForms.Guna2Button()
            Me.txtImportFilePath = New Guna.UI2.WinForms.Guna2TextBox()
            Me.chkUpdateExisting = New Guna.UI2.WinForms.Guna2CheckBox()
            Me.lblPreviewTitle = New System.Windows.Forms.Label()
            Me.dgvImportPreview = New System.Windows.Forms.DataGridView()
            Me.btnStartImport = New Guna.UI2.WinForms.Guna2Button()
            Me.cardScheduledExport = New Guna.UI2.WinForms.Guna2Panel()
            Me.lblScheduledTitle = New System.Windows.Forms.Label()
            Me.badgeComingSoon = New Guna.UI2.WinForms.Guna2Button()
            Me.lblScheduledDesc = New System.Windows.Forms.Label()
            Me.btnClose = New Guna.UI2.WinForms.Guna2Button()
            Me.btnCancelOperation = New Guna.UI2.WinForms.Guna2Button()
            Me.btnExportAllExcel = New Guna.UI2.WinForms.Guna2Button()
            Me.btnExportSingleExcel = New Guna.UI2.WinForms.Guna2Button()
            Me.btnExportSinglePdf = New Guna.UI2.WinForms.Guna2Button()
            Me.btnExportWhatsApp = New Guna.UI2.WinForms.Guna2Button()
            Me.pnlMain.SuspendLayout()
            Me.cardProgress.SuspendLayout()
            Me.cardExportAll.SuspendLayout()
            Me.cardSingleExport.SuspendLayout()
            Me.cardImport.SuspendLayout()
            CType(Me.dgvImportPreview, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cardScheduledExport.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.AutoScrollMinSize = New System.Drawing.Size(0, 1310)
            Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.pnlMain.Controls.Add(Me.lblTitle)
            Me.pnlMain.Controls.Add(Me.lblSubtitle)
            Me.pnlMain.Controls.Add(Me.cardProgress)
            Me.pnlMain.Controls.Add(Me.cardExportAll)
            Me.pnlMain.Controls.Add(Me.cardSingleExport)
            Me.pnlMain.Controls.Add(Me.cardImport)
            Me.pnlMain.Controls.Add(Me.cardScheduledExport)
            Me.pnlMain.Controls.Add(Me.btnClose)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1238, 1180)
            Me.pnlMain.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(833, 20)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(358, 35)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "تصدير واستيراد البيانات"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(433, 58)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(758, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "تصدير بيانات النظام إلى ملفات Excel و PDF مع دعم الشيتات المتعددة، تصفية التواريخ" &
    "، واستيراد البيانات"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardProgress
            '
            Me.cardProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardProgress.BackColor = System.Drawing.Color.Transparent
            Me.cardProgress.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardProgress.BorderRadius = 12
            Me.cardProgress.BorderThickness = 1
            Me.cardProgress.Controls.Add(Me.lblCardProgressTitle)
            Me.cardProgress.Controls.Add(Me.btnCancelOperation)
            Me.cardProgress.Controls.Add(Me.progressBar)
            Me.cardProgress.Controls.Add(Me.lblProgressStatus)
            Me.cardProgress.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardProgress.Location = New System.Drawing.Point(30, 95)
            Me.cardProgress.Name = "cardProgress"
            Me.cardProgress.Size = New System.Drawing.Size(1161, 100)
            Me.cardProgress.TabIndex = 2
            '
            'lblCardProgressTitle
            '
            Me.lblCardProgressTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardProgressTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardProgressTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardProgressTitle.Location = New System.Drawing.Point(833, 12)
            Me.lblCardProgressTitle.Name = "lblCardProgressTitle"
            Me.lblCardProgressTitle.Size = New System.Drawing.Size(300, 24)
            Me.lblCardProgressTitle.TabIndex = 0
            Me.lblCardProgressTitle.Text = "شريط تقدم وحالة العمليات"
            Me.lblCardProgressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'progressBar
            '
            Me.progressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.progressBar.BorderRadius = 6
            Me.progressBar.FillColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.progressBar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.progressBar.ForeColor = System.Drawing.Color.White
            Me.progressBar.Location = New System.Drawing.Point(25, 42)
            Me.progressBar.Name = "progressBar"
            Me.progressBar.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.progressBar.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
            Me.progressBar.ShowText = True
            Me.progressBar.Size = New System.Drawing.Size(1111, 24)
            Me.progressBar.TabIndex = 1
            Me.progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
            '
            'lblProgressStatus
            '
            Me.lblProgressStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblProgressStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblProgressStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblProgressStatus.Location = New System.Drawing.Point(25, 70)
            Me.lblProgressStatus.Name = "lblProgressStatus"
            Me.lblProgressStatus.Size = New System.Drawing.Size(1111, 22)
            Me.lblProgressStatus.TabIndex = 2
            Me.lblProgressStatus.Text = "جاهز لتنفيذ أي عملية تصدير أو استيراد..."
            Me.lblProgressStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardExportAll
            '
            Me.cardExportAll.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardExportAll.BackColor = System.Drawing.Color.Transparent
            Me.cardExportAll.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardExportAll.BorderRadius = 12
            Me.cardExportAll.BorderThickness = 1
            Me.cardExportAll.Controls.Add(Me.lblCardExportAllTitle)
            Me.cardExportAll.Controls.Add(Me.lblExportAllDesc)
            Me.cardExportAll.Controls.Add(Me.btnExportAllExcel)
            Me.cardExportAll.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardExportAll.Location = New System.Drawing.Point(30, 210)
            Me.cardExportAll.Name = "cardExportAll"
            Me.cardExportAll.Size = New System.Drawing.Size(1161, 125)
            Me.cardExportAll.TabIndex = 3
            '
            'lblCardExportAllTitle
            '
            Me.lblCardExportAllTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardExportAllTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardExportAllTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardExportAllTitle.Location = New System.Drawing.Point(633, 15)
            Me.lblCardExportAllTitle.Name = "lblCardExportAllTitle"
            Me.lblCardExportAllTitle.Size = New System.Drawing.Size(500, 26)
            Me.lblCardExportAllTitle.TabIndex = 0
            Me.lblCardExportAllTitle.Text = "تصدير شامل لكافة بيانات النظام (Excel متعدد الشيتات)"
            Me.lblCardExportAllTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblExportAllDesc
            '
            Me.lblExportAllDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblExportAllDesc.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblExportAllDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblExportAllDesc.Location = New System.Drawing.Point(450, 48)
            Me.lblExportAllDesc.Name = "lblExportAllDesc"
            Me.lblExportAllDesc.Size = New System.Drawing.Size(683, 45)
            Me.lblExportAllDesc.TabIndex = 1
            Me.lblExportAllDesc.Text = "تصدير جميع بيانات النظام (العملاء، الموردين، الأصناف، الأقسام، المخازن، الموظفين،" &
    " المستخدمين، الخزينة، المصروفات، المبيعات، المشتريات) في ملف Excel واحد متكامل ب" &
    "شيت منفصل لكل قسم."
            Me.lblExportAllDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardSingleExport
            '
            Me.cardSingleExport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardSingleExport.BackColor = System.Drawing.Color.Transparent
            Me.cardSingleExport.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardSingleExport.BorderRadius = 12
            Me.cardSingleExport.BorderThickness = 1
            Me.cardSingleExport.Controls.Add(Me.lblCardSingleExportTitle)
            Me.cardSingleExport.Controls.Add(Me.lblSelectExportEntity)
            Me.cardSingleExport.Controls.Add(Me.cmbExportEntity)
            Me.cardSingleExport.Controls.Add(Me.lblExportCountInfo)
            Me.cardSingleExport.Controls.Add(Me.btnExportSingleExcel)
            Me.cardSingleExport.Controls.Add(Me.btnExportSinglePdf)
            Me.cardSingleExport.Controls.Add(Me.chkFilterByDate)
            Me.cardSingleExport.Controls.Add(Me.lblFromDate)
            Me.cardSingleExport.Controls.Add(Me.dtpFromDate)
            Me.cardSingleExport.Controls.Add(Me.lblToDate)
            Me.cardSingleExport.Controls.Add(Me.dtpToDate)
            Me.cardSingleExport.Controls.Add(Me.btnPresetToday)
            Me.cardSingleExport.Controls.Add(Me.btnPresetThisMonth)
            Me.cardSingleExport.Controls.Add(Me.btnPresetAll)
            Me.cardSingleExport.Controls.Add(Me.lblWhatsAppNote)
            Me.cardSingleExport.Controls.Add(Me.btnExportWhatsApp)
            Me.cardSingleExport.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardSingleExport.Location = New System.Drawing.Point(30, 350)
            Me.cardSingleExport.Name = "cardSingleExport"
            Me.cardSingleExport.Size = New System.Drawing.Size(1161, 225)
            Me.cardSingleExport.TabIndex = 4
            '
            'lblCardSingleExportTitle
            '
            Me.lblCardSingleExportTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardSingleExportTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardSingleExportTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardSingleExportTitle.Location = New System.Drawing.Point(633, 15)
            Me.lblCardSingleExportTitle.Name = "lblCardSingleExportTitle"
            Me.lblCardSingleExportTitle.Size = New System.Drawing.Size(500, 26)
            Me.lblCardSingleExportTitle.TabIndex = 0
            Me.lblCardSingleExportTitle.Text = "تصدير مخصص لقسم محدد (Excel أو PDF) مع فلترة التواريخ"
            Me.lblCardSingleExportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSelectExportEntity
            '
            Me.lblSelectExportEntity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSelectExportEntity.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblSelectExportEntity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblSelectExportEntity.Location = New System.Drawing.Point(873, 52)
            Me.lblSelectExportEntity.Name = "lblSelectExportEntity"
            Me.lblSelectExportEntity.Size = New System.Drawing.Size(260, 25)
            Me.lblSelectExportEntity.TabIndex = 1
            Me.lblSelectExportEntity.Text = "اختر القسم أو الجدول المطلوب تصديره:"
            Me.lblSelectExportEntity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbExportEntity
            '
            Me.cmbExportEntity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbExportEntity.BackColor = System.Drawing.Color.Transparent
            Me.cmbExportEntity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbExportEntity.BorderRadius = 8
            Me.cmbExportEntity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbExportEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbExportEntity.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cmbExportEntity.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.cmbExportEntity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.cmbExportEntity.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.cmbExportEntity.ForeColor = System.Drawing.Color.White
            Me.cmbExportEntity.ItemHeight = 30
            Me.cmbExportEntity.Location = New System.Drawing.Point(813, 80)
            Me.cmbExportEntity.Name = "cmbExportEntity"
            Me.cmbExportEntity.Size = New System.Drawing.Size(320, 36)
            Me.cmbExportEntity.TabIndex = 2
            '
            'lblExportCountInfo
            '
            Me.lblExportCountInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblExportCountInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!)
            Me.lblExportCountInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.lblExportCountInfo.Location = New System.Drawing.Point(493, 80)
            Me.lblExportCountInfo.Name = "lblExportCountInfo"
            Me.lblExportCountInfo.Size = New System.Drawing.Size(290, 36)
            Me.lblExportCountInfo.TabIndex = 3
            Me.lblExportCountInfo.Text = "عدد السجلات: 0"
            Me.lblExportCountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkFilterByDate
            '
            Me.chkFilterByDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkFilterByDate.AutoSize = True
            Me.chkFilterByDate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkFilterByDate.CheckedState.BorderRadius = 4
            Me.chkFilterByDate.CheckedState.BorderThickness = 1
            Me.chkFilterByDate.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkFilterByDate.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.chkFilterByDate.ForeColor = System.Drawing.Color.White
            Me.chkFilterByDate.Location = New System.Drawing.Point(996, 138)
            Me.chkFilterByDate.Name = "chkFilterByDate"
            Me.chkFilterByDate.Size = New System.Drawing.Size(137, 21)
            Me.chkFilterByDate.TabIndex = 6
            Me.chkFilterByDate.Text = "تصفية حسب التاريخ:"
            Me.chkFilterByDate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
            Me.chkFilterByDate.UncheckedState.BorderRadius = 4
            Me.chkFilterByDate.UncheckedState.BorderThickness = 1
            Me.chkFilterByDate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            '
            'lblFromDate
            '
            Me.lblFromDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblFromDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblFromDate.Location = New System.Drawing.Point(938, 138)
            Me.lblFromDate.Name = "lblFromDate"
            Me.lblFromDate.Size = New System.Drawing.Size(35, 22)
            Me.lblFromDate.TabIndex = 7
            Me.lblFromDate.Text = "من:"
            Me.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpFromDate
            '
            Me.dtpFromDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dtpFromDate.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.dtpFromDate.BorderRadius = 6
            Me.dtpFromDate.BorderThickness = 1
            Me.dtpFromDate.Checked = True
            Me.dtpFromDate.Enabled = False
            Me.dtpFromDate.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.dtpFromDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.dtpFromDate.ForeColor = System.Drawing.Color.White
            Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFromDate.Location = New System.Drawing.Point(793, 134)
            Me.dtpFromDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
            Me.dtpFromDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
            Me.dtpFromDate.Name = "dtpFromDate"
            Me.dtpFromDate.Size = New System.Drawing.Size(140, 30)
            Me.dtpFromDate.TabIndex = 8
            Me.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.dtpFromDate.Value = New Date(2026, 9, 24, 2, 41, 43, 296)
            '
            'lblToDate
            '
            Me.lblToDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblToDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblToDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblToDate.Location = New System.Drawing.Point(748, 138)
            Me.lblToDate.Name = "lblToDate"
            Me.lblToDate.Size = New System.Drawing.Size(40, 22)
            Me.lblToDate.TabIndex = 9
            Me.lblToDate.Text = "إلى:"
            Me.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpToDate
            '
            Me.dtpToDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dtpToDate.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.dtpToDate.BorderRadius = 6
            Me.dtpToDate.BorderThickness = 1
            Me.dtpToDate.Checked = True
            Me.dtpToDate.Enabled = False
            Me.dtpToDate.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.dtpToDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.dtpToDate.ForeColor = System.Drawing.Color.White
            Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpToDate.Location = New System.Drawing.Point(603, 134)
            Me.dtpToDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
            Me.dtpToDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
            Me.dtpToDate.Name = "dtpToDate"
            Me.dtpToDate.Size = New System.Drawing.Size(140, 30)
            Me.dtpToDate.TabIndex = 10
            Me.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.dtpToDate.Value = New Date(2026, 9, 24, 2, 41, 43, 336)
            '
            'btnPresetToday
            '
            Me.btnPresetToday.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPresetToday.BorderRadius = 6
            Me.btnPresetToday.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPresetToday.Enabled = False
            Me.btnPresetToday.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnPresetToday.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnPresetToday.ForeColor = System.Drawing.Color.White
            Me.btnPresetToday.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnPresetToday.Location = New System.Drawing.Point(508, 134)
            Me.btnPresetToday.Name = "btnPresetToday"
            Me.btnPresetToday.Size = New System.Drawing.Size(85, 30)
            Me.btnPresetToday.TabIndex = 11
            Me.btnPresetToday.Text = "اليوم"
            '
            'btnPresetThisMonth
            '
            Me.btnPresetThisMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPresetThisMonth.BorderRadius = 6
            Me.btnPresetThisMonth.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPresetThisMonth.Enabled = False
            Me.btnPresetThisMonth.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnPresetThisMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnPresetThisMonth.ForeColor = System.Drawing.Color.White
            Me.btnPresetThisMonth.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnPresetThisMonth.Location = New System.Drawing.Point(403, 134)
            Me.btnPresetThisMonth.Name = "btnPresetThisMonth"
            Me.btnPresetThisMonth.Size = New System.Drawing.Size(95, 30)
            Me.btnPresetThisMonth.TabIndex = 12
            Me.btnPresetThisMonth.Text = "هذا الشهر"
            '
            'btnPresetAll
            '
            Me.btnPresetAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPresetAll.BorderRadius = 6
            Me.btnPresetAll.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPresetAll.Enabled = False
            Me.btnPresetAll.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnPresetAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnPresetAll.ForeColor = System.Drawing.Color.White
            Me.btnPresetAll.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnPresetAll.Location = New System.Drawing.Point(298, 134)
            Me.btnPresetAll.Name = "btnPresetAll"
            Me.btnPresetAll.Size = New System.Drawing.Size(95, 30)
            Me.btnPresetAll.TabIndex = 13
            Me.btnPresetAll.Text = "كل الفترات"
            '
            'lblWhatsAppNote
            '
            Me.lblWhatsAppNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblWhatsAppNote.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblWhatsAppNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblWhatsAppNote.Location = New System.Drawing.Point(424, 185)
            Me.lblWhatsAppNote.Name = "lblWhatsAppNote"
            Me.lblWhatsAppNote.Size = New System.Drawing.Size(709, 26)
            Me.lblWhatsAppNote.TabIndex = 14
            Me.lblWhatsAppNote.Text = "استخراج العملاء مع راوابط الواتساب"
            Me.lblWhatsAppNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cardImport
            '
            Me.cardImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardImport.BackColor = System.Drawing.Color.Transparent
            Me.cardImport.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardImport.BorderRadius = 12
            Me.cardImport.BorderThickness = 1
            Me.cardImport.Controls.Add(Me.lblCardImportTitle)
            Me.cardImport.Controls.Add(Me.lblSelectImportEntity)
            Me.cardImport.Controls.Add(Me.cmbImportEntity)
            Me.cardImport.Controls.Add(Me.btnDownloadTemplate)
            Me.cardImport.Controls.Add(Me.btnSelectImportFile)
            Me.cardImport.Controls.Add(Me.txtImportFilePath)
            Me.cardImport.Controls.Add(Me.chkUpdateExisting)
            Me.cardImport.Controls.Add(Me.lblPreviewTitle)
            Me.cardImport.Controls.Add(Me.dgvImportPreview)
            Me.cardImport.Controls.Add(Me.btnStartImport)
            Me.cardImport.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardImport.Location = New System.Drawing.Point(30, 590)
            Me.cardImport.Name = "cardImport"
            Me.cardImport.Size = New System.Drawing.Size(1161, 560)
            Me.cardImport.TabIndex = 5
            '
            'lblCardImportTitle
            '
            Me.lblCardImportTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCardImportTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblCardImportTitle.ForeColor = System.Drawing.Color.White
            Me.lblCardImportTitle.Location = New System.Drawing.Point(633, 15)
            Me.lblCardImportTitle.Name = "lblCardImportTitle"
            Me.lblCardImportTitle.Size = New System.Drawing.Size(500, 26)
            Me.lblCardImportTitle.TabIndex = 0
            Me.lblCardImportTitle.Text = "استيراد البيانات من ملف Excel إلى النظام"
            Me.lblCardImportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSelectImportEntity
            '
            Me.lblSelectImportEntity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSelectImportEntity.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblSelectImportEntity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.lblSelectImportEntity.Location = New System.Drawing.Point(903, 50)
            Me.lblSelectImportEntity.Name = "lblSelectImportEntity"
            Me.lblSelectImportEntity.Size = New System.Drawing.Size(230, 25)
            Me.lblSelectImportEntity.TabIndex = 1
            Me.lblSelectImportEntity.Text = "نوع البيانات المراد استيرادها:"
            Me.lblSelectImportEntity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbImportEntity
            '
            Me.cmbImportEntity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbImportEntity.BackColor = System.Drawing.Color.Transparent
            Me.cmbImportEntity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.cmbImportEntity.BorderRadius = 8
            Me.cmbImportEntity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.cmbImportEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbImportEntity.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cmbImportEntity.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.cmbImportEntity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.cmbImportEntity.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.cmbImportEntity.ForeColor = System.Drawing.Color.White
            Me.cmbImportEntity.ItemHeight = 30
            Me.cmbImportEntity.Location = New System.Drawing.Point(853, 78)
            Me.cmbImportEntity.Name = "cmbImportEntity"
            Me.cmbImportEntity.Size = New System.Drawing.Size(280, 36)
            Me.cmbImportEntity.TabIndex = 2
            '
            'btnDownloadTemplate
            '
            Me.btnDownloadTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDownloadTemplate.BorderRadius = 8
            Me.btnDownloadTemplate.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDownloadTemplate.FillColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnDownloadTemplate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnDownloadTemplate.ForeColor = System.Drawing.Color.White
            Me.btnDownloadTemplate.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.btnDownloadTemplate.Location = New System.Drawing.Point(603, 78)
            Me.btnDownloadTemplate.Name = "btnDownloadTemplate"
            Me.btnDownloadTemplate.Size = New System.Drawing.Size(230, 36)
            Me.btnDownloadTemplate.TabIndex = 3
            Me.btnDownloadTemplate.Text = "📥 تحميل نموذج إكسيل فارغ"
            '
            'btnSelectImportFile
            '
            Me.btnSelectImportFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSelectImportFile.BorderRadius = 8
            Me.btnSelectImportFile.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSelectImportFile.FillColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
            Me.btnSelectImportFile.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSelectImportFile.ForeColor = System.Drawing.Color.White
            Me.btnSelectImportFile.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnSelectImportFile.Location = New System.Drawing.Point(933, 130)
            Me.btnSelectImportFile.Name = "btnSelectImportFile"
            Me.btnSelectImportFile.Size = New System.Drawing.Size(200, 36)
            Me.btnSelectImportFile.TabIndex = 4
            Me.btnSelectImportFile.Text = "📂 اختيار ملف Excel..."
            '
            'txtImportFilePath
            '
            Me.txtImportFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtImportFilePath.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.txtImportFilePath.BorderRadius = 8
            Me.txtImportFilePath.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtImportFilePath.DefaultText = ""
            Me.txtImportFilePath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
            Me.txtImportFilePath.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
            Me.txtImportFilePath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
            Me.txtImportFilePath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
            Me.txtImportFilePath.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.txtImportFilePath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.txtImportFilePath.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtImportFilePath.ForeColor = System.Drawing.Color.White
            Me.txtImportFilePath.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.txtImportFilePath.Location = New System.Drawing.Point(400, 130)
            Me.txtImportFilePath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtImportFilePath.Name = "txtImportFilePath"
            Me.txtImportFilePath.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
            Me.txtImportFilePath.PlaceholderText = "مسار ملف Excel المختار..."
            Me.txtImportFilePath.ReadOnly = True
            Me.txtImportFilePath.SelectedText = ""
            Me.txtImportFilePath.Size = New System.Drawing.Size(518, 36)
            Me.txtImportFilePath.TabIndex = 5
            '
            'chkUpdateExisting
            '
            Me.chkUpdateExisting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkUpdateExisting.AutoSize = True
            Me.chkUpdateExisting.Checked = True
            Me.chkUpdateExisting.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkUpdateExisting.CheckedState.BorderRadius = 4
            Me.chkUpdateExisting.CheckedState.BorderThickness = 1
            Me.chkUpdateExisting.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.chkUpdateExisting.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkUpdateExisting.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.chkUpdateExisting.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.chkUpdateExisting.Location = New System.Drawing.Point(706, 180)
            Me.chkUpdateExisting.Name = "chkUpdateExisting"
            Me.chkUpdateExisting.Size = New System.Drawing.Size(427, 23)
            Me.chkUpdateExisting.TabIndex = 6
            Me.chkUpdateExisting.Text = "تحديث بيانات السجل الموجود مسبقاً إذا تطابق الكود (بدلاً من تخطيه)"
            Me.chkUpdateExisting.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
            Me.chkUpdateExisting.UncheckedState.BorderRadius = 4
            Me.chkUpdateExisting.UncheckedState.BorderThickness = 1
            Me.chkUpdateExisting.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            '
            'lblPreviewTitle
            '
            Me.lblPreviewTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPreviewTitle.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.lblPreviewTitle.ForeColor = System.Drawing.Color.White
            Me.lblPreviewTitle.Location = New System.Drawing.Point(683, 215)
            Me.lblPreviewTitle.Name = "lblPreviewTitle"
            Me.lblPreviewTitle.Size = New System.Drawing.Size(450, 25)
            Me.lblPreviewTitle.TabIndex = 7
            Me.lblPreviewTitle.Text = "معاينة أولية لبيانات الملف المختار (أول 50 سجلاً):"
            Me.lblPreviewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dgvImportPreview
            '
            Me.dgvImportPreview.AllowUserToAddRows = False
            Me.dgvImportPreview.AllowUserToDeleteRows = False
            Me.dgvImportPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvImportPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvImportPreview.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.dgvImportPreview.BorderStyle = System.Windows.Forms.BorderStyle.None
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvImportPreview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvImportPreview.ColumnHeadersHeight = 32
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(252, Byte), Integer))
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvImportPreview.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvImportPreview.EnableHeadersVisualStyles = False
            Me.dgvImportPreview.Location = New System.Drawing.Point(25, 245)
            Me.dgvImportPreview.Name = "dgvImportPreview"
            Me.dgvImportPreview.ReadOnly = True
            Me.dgvImportPreview.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.dgvImportPreview.RowHeadersVisible = False
            Me.dgvImportPreview.RowTemplate.Height = 28
            Me.dgvImportPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvImportPreview.Size = New System.Drawing.Size(1108, 235)
            Me.dgvImportPreview.TabIndex = 8
            '
            'btnStartImport
            '
            Me.btnStartImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnStartImport.BorderRadius = 8
            Me.btnStartImport.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnStartImport.FillColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.btnStartImport.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnStartImport.ForeColor = System.Drawing.Color.White
            Me.btnStartImport.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(150, Byte), Integer))
            Me.btnStartImport.Location = New System.Drawing.Point(733, 495)
            Me.btnStartImport.Name = "btnStartImport"
            Me.btnStartImport.Size = New System.Drawing.Size(400, 48)
            Me.btnStartImport.TabIndex = 9
            Me.btnStartImport.Text = "🚀 بدء عملية الاستيراد وحفظ البيانات"
            '
            'cardScheduledExport
            '
            Me.cardScheduledExport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardScheduledExport.BackColor = System.Drawing.Color.Transparent
            Me.cardScheduledExport.BorderColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
            Me.cardScheduledExport.BorderRadius = 12
            Me.cardScheduledExport.BorderThickness = 1
            Me.cardScheduledExport.Controls.Add(Me.lblScheduledTitle)
            Me.cardScheduledExport.Controls.Add(Me.badgeComingSoon)
            Me.cardScheduledExport.Controls.Add(Me.lblScheduledDesc)
            Me.cardScheduledExport.FillColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.cardScheduledExport.Location = New System.Drawing.Point(30, 1165)
            Me.cardScheduledExport.Name = "cardScheduledExport"
            Me.cardScheduledExport.Size = New System.Drawing.Size(1161, 110)
            Me.cardScheduledExport.TabIndex = 6
            '
            'lblScheduledTitle
            '
            Me.lblScheduledTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblScheduledTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblScheduledTitle.ForeColor = System.Drawing.Color.White
            Me.lblScheduledTitle.Location = New System.Drawing.Point(583, 15)
            Me.lblScheduledTitle.Name = "lblScheduledTitle"
            Me.lblScheduledTitle.Size = New System.Drawing.Size(550, 26)
            Me.lblScheduledTitle.TabIndex = 0
            Me.lblScheduledTitle.Text = "النسخ والتصدير التلقائي المجدول (Auto-Scheduled Export)"
            Me.lblScheduledTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'badgeComingSoon
            '
            Me.badgeComingSoon.BorderRadius = 6
            Me.badgeComingSoon.Cursor = System.Windows.Forms.Cursors.Hand
            Me.badgeComingSoon.FillColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(229, Byte), Integer))
            Me.badgeComingSoon.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.badgeComingSoon.ForeColor = System.Drawing.Color.White
            Me.badgeComingSoon.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.badgeComingSoon.Location = New System.Drawing.Point(25, 15)
            Me.badgeComingSoon.Name = "badgeComingSoon"
            Me.badgeComingSoon.Size = New System.Drawing.Size(240, 32)
            Me.badgeComingSoon.TabIndex = 1
            Me.badgeComingSoon.Text = "🚀 ميزة ستتوفر قريباً (Coming Soon)"
            '
            'lblScheduledDesc
            '
            Me.lblScheduledDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblScheduledDesc.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.lblScheduledDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(175, Byte), Integer))
            Me.lblScheduledDesc.Location = New System.Drawing.Point(280, 48)
            Me.lblScheduledDesc.Name = "lblScheduledDesc"
            Me.lblScheduledDesc.Size = New System.Drawing.Size(853, 45)
            Me.lblScheduledDesc.TabIndex = 2
            Me.lblScheduledDesc.Text = "جدولة تصدير تلقائي يومي أو أسبوعي لكافة بيانات النظام أو أقسام محددة وحفظها تلقائ" &
    "ياً على مجلد محلي، فلاشة خارجية، أو إرسالها إلى البريد الإلكتروني والسحابة لحماي" &
    "ة بياناتك بدون تدخل يدوي."
            Me.lblScheduledDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnClose
            '
            Me.btnClose.BorderColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.btnClose.BorderRadius = 8
            Me.btnClose.BorderThickness = 1
            Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClose.FillColor = System.Drawing.Color.Transparent
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(219, Byte), Integer))
            Me.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnClose.Location = New System.Drawing.Point(30, 20)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(120, 40)
            Me.btnClose.TabIndex = 7
            Me.btnClose.Text = "إغلاق"
            '
            'btnCancelOperation
            '
            Me.btnCancelOperation.BorderRadius = 6
            Me.btnCancelOperation.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCancelOperation.FillColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
            Me.btnCancelOperation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnCancelOperation.ForeColor = System.Drawing.Color.White
            Me.btnCancelOperation.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.btnCancelOperation.Image = Global.WindowsApp1.My.Resources.Resources.cross
            Me.btnCancelOperation.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.btnCancelOperation.ImageOffset = New System.Drawing.Point(3, 0)
            Me.btnCancelOperation.ImageSize = New System.Drawing.Size(32, 32)
            Me.btnCancelOperation.Location = New System.Drawing.Point(25, 10)
            Me.btnCancelOperation.Name = "btnCancelOperation"
            Me.btnCancelOperation.Size = New System.Drawing.Size(140, 26)
            Me.btnCancelOperation.TabIndex = 3
            Me.btnCancelOperation.Text = "إلغاء العملية"
            Me.btnCancelOperation.Visible = False
            '
            'btnExportAllExcel
            '
            Me.btnExportAllExcel.BorderRadius = 8
            Me.btnExportAllExcel.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnExportAllExcel.FillColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(65, Byte), Integer))
            Me.btnExportAllExcel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.btnExportAllExcel.ForeColor = System.Drawing.Color.White
            Me.btnExportAllExcel.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(75, Byte), Integer))
            Me.btnExportAllExcel.Image = Global.WindowsApp1.My.Resources.Resources.sheets
            Me.btnExportAllExcel.ImageSize = New System.Drawing.Size(32, 32)
            Me.btnExportAllExcel.Location = New System.Drawing.Point(25, 38)
            Me.btnExportAllExcel.Name = "btnExportAllExcel"
            Me.btnExportAllExcel.Size = New System.Drawing.Size(380, 50)
            Me.btnExportAllExcel.TabIndex = 2
            Me.btnExportAllExcel.Text = "تصدير الكل في ملف إكسيل كامل [شيتات]"
            '
            'btnExportSingleExcel
            '
            Me.btnExportSingleExcel.BorderRadius = 8
            Me.btnExportSingleExcel.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnExportSingleExcel.FillColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(34, Byte), Integer))
            Me.btnExportSingleExcel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnExportSingleExcel.ForeColor = System.Drawing.Color.White
            Me.btnExportSingleExcel.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(46, Byte), Integer))
            Me.btnExportSingleExcel.Image = Global.WindowsApp1.My.Resources.Resources.excel1
            Me.btnExportSingleExcel.ImageSize = New System.Drawing.Size(32, 32)
            Me.btnExportSingleExcel.Location = New System.Drawing.Point(260, 76)
            Me.btnExportSingleExcel.Name = "btnExportSingleExcel"
            Me.btnExportSingleExcel.Size = New System.Drawing.Size(220, 44)
            Me.btnExportSingleExcel.TabIndex = 4
            Me.btnExportSingleExcel.Text = "تصدير Excel (.xlsx)"
            '
            'btnExportSinglePdf
            '
            Me.btnExportSinglePdf.BorderRadius = 8
            Me.btnExportSinglePdf.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnExportSinglePdf.FillColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
            Me.btnExportSinglePdf.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.btnExportSinglePdf.ForeColor = System.Drawing.Color.White
            Me.btnExportSinglePdf.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(84, Byte), Integer))
            Me.btnExportSinglePdf.Image = Global.WindowsApp1.My.Resources.Resources.file__2_
            Me.btnExportSinglePdf.ImageSize = New System.Drawing.Size(32, 32)
            Me.btnExportSinglePdf.Location = New System.Drawing.Point(25, 76)
            Me.btnExportSinglePdf.Name = "btnExportSinglePdf"
            Me.btnExportSinglePdf.Size = New System.Drawing.Size(220, 44)
            Me.btnExportSinglePdf.TabIndex = 5
            Me.btnExportSinglePdf.Text = " تصدير PDF (.pdf)"
            '
            'btnExportWhatsApp
            '
            Me.btnExportWhatsApp.BorderRadius = 8
            Me.btnExportWhatsApp.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnExportWhatsApp.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(126, Byte), Integer))
            Me.btnExportWhatsApp.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
            Me.btnExportWhatsApp.ForeColor = System.Drawing.Color.White
            Me.btnExportWhatsApp.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(102, Byte), Integer))
            Me.btnExportWhatsApp.Image = Global.WindowsApp1.My.Resources.Resources.apple
            Me.btnExportWhatsApp.ImageSize = New System.Drawing.Size(32, 32)
            Me.btnExportWhatsApp.Location = New System.Drawing.Point(25, 176)
            Me.btnExportWhatsApp.Name = "btnExportWhatsApp"
            Me.btnExportWhatsApp.Size = New System.Drawing.Size(295, 44)
            Me.btnExportWhatsApp.TabIndex = 15
            Me.btnExportWhatsApp.Text = "تصدير عملاء الواتساب (Excel)"
            '
            'UCDataExportSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.Controls.Add(Me.pnlMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "UCDataExportSettings"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(1238, 1180)
            Me.pnlMain.ResumeLayout(False)
            Me.cardProgress.ResumeLayout(False)
            Me.cardExportAll.ResumeLayout(False)
            Me.cardSingleExport.ResumeLayout(False)
            Me.cardSingleExport.PerformLayout()
            Me.cardImport.ResumeLayout(False)
            Me.cardImport.PerformLayout()
            CType(Me.dgvImportPreview, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cardScheduledExport.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents cardProgress As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardProgressTitle As System.Windows.Forms.Label
        Friend WithEvents btnCancelOperation As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents progressBar As Guna.UI2.WinForms.Guna2ProgressBar
        Friend WithEvents lblProgressStatus As System.Windows.Forms.Label
        Friend WithEvents cardExportAll As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardExportAllTitle As System.Windows.Forms.Label
        Friend WithEvents lblExportAllDesc As System.Windows.Forms.Label
        Friend WithEvents btnExportAllExcel As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardSingleExport As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardSingleExportTitle As System.Windows.Forms.Label
        Friend WithEvents lblSelectExportEntity As System.Windows.Forms.Label
        Friend WithEvents cmbExportEntity As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents lblExportCountInfo As System.Windows.Forms.Label
        Friend WithEvents btnExportSingleExcel As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnExportSinglePdf As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents chkFilterByDate As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents lblFromDate As System.Windows.Forms.Label
        Friend WithEvents dtpFromDate As Guna.UI2.WinForms.Guna2DateTimePicker
        Friend WithEvents lblToDate As System.Windows.Forms.Label
        Friend WithEvents dtpToDate As Guna.UI2.WinForms.Guna2DateTimePicker
        Friend WithEvents btnPresetToday As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnPresetThisMonth As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnPresetAll As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblWhatsAppNote As System.Windows.Forms.Label
        Friend WithEvents btnExportWhatsApp As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardImport As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblCardImportTitle As System.Windows.Forms.Label
        Friend WithEvents lblSelectImportEntity As System.Windows.Forms.Label
        Friend WithEvents cmbImportEntity As Guna.UI2.WinForms.Guna2ComboBox
        Friend WithEvents btnDownloadTemplate As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents btnSelectImportFile As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents txtImportFilePath As Guna.UI2.WinForms.Guna2TextBox
        Friend WithEvents chkUpdateExisting As Guna.UI2.WinForms.Guna2CheckBox
        Friend WithEvents lblPreviewTitle As System.Windows.Forms.Label
        Friend WithEvents dgvImportPreview As System.Windows.Forms.DataGridView
        Friend WithEvents btnStartImport As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents cardScheduledExport As Guna.UI2.WinForms.Guna2Panel
        Friend WithEvents lblScheduledTitle As System.Windows.Forms.Label
        Friend WithEvents badgeComingSoon As Guna.UI2.WinForms.Guna2Button
        Friend WithEvents lblScheduledDesc As System.Windows.Forms.Label
        Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button

    End Class
End Namespace
