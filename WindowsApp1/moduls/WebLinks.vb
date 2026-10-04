Imports System
Imports System.Diagnostics
Imports System.Windows.Forms

''' <summary>
''' إدارة وتوجيه الروابط الخارجية لموقع سستامك الرسمي (https://sestamk.site.je)
''' يوفر وصولاً سريعاً وموحداً لكافة صفحات الموقع:
''' الدعم الفني، حول البرنامج، شروط الاستخدام، سياسة الخصوصية، سجل التحديثات، وغيرها.
''' </summary>
Public Module WebLinks

        ''' <summary>
        ''' الدومين الافتراضي المعتمد لموقع سستامك
        ''' </summary>
        Public Const DefaultDomain As String = "https://sestamk.site.je"

        ''' <summary>
        ''' جلب الرابط الأساسي للموقع مع دعم تخصيصه من إعدادات النظام إن وُجد
        ''' </summary>
        Public ReadOnly Property BaseUrl As String
            Get
                Try
                    Dim custom = SettingsManager.GetSetting("Website_Domain")
                    If Not String.IsNullOrWhiteSpace(custom) Then
                        custom = custom.Trim().TrimEnd("/"c)
                        If Not custom.StartsWith("http://", StringComparison.OrdinalIgnoreCase) AndAlso
                           Not custom.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then
                            custom = "https://" & custom
                        End If
                        Return custom
                    End If
                Catch __logEx As Exception
                    Logger.LogError("WebLinks.vb:32", __logEx)
                End Try
                Return DefaultDomain
            End Get
        End Property

        ' =====================================================================
        ' مسارات صفحات الموقع الرسمية (مطابقة لمسارات تطبيق الموقع E:\Sestamk\Sestamk_POS_ERP_System)
        ' =====================================================================
        Public Const RouteHome As String = "/"                     ' الصفحة الرئيسية
        Public Const RouteContact As String = "/contact"          ' اتصل بنا والدعم الفني
        Public Const RouteAbout As String = "/about"              ' من نحن وحول المنظومة
        Public Const RouteTerms As String = "/terms"              ' الشروط والأحكام وشروط الاستخدام
        Public Const RoutePrivacy As String = "/privacy"          ' سياسة الخصوصية
        Public Const RouteUpdates As String = "/updates"          ' سجل التحديثات والإصدارات
        Public Const RouteAcademy As String = "/academy"          ' الأكاديمية والشروحات
        Public Const RouteDownloads As String = "/downloads"      ' مركز التحميلات
        Public Const RoutePricing As String = "/pricing"          ' الخطط والأسعار
        Public Const RouteProducts As String = "/products"        ' الأنظمة والأجهزة
        Public Const RoutePortal As String = "/portal"            ' بوابة العملاء

        ''' <summary>
        ''' فتح أي صفحة أو مسار أو رابط خارجي في المتصفح الافتراضي للعميل
        ''' </summary>
        ''' <param name="pathOrUrl">المسار النسبي مثل "/contact" أو الرابط الكامل "https://..."</param>
        Public Sub OpenUrl(pathOrUrl As String)
            Try
                If String.IsNullOrWhiteSpace(pathOrUrl) Then pathOrUrl = RouteHome

                Dim fullUrl As String
                If pathOrUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) OrElse
                   pathOrUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then
                    fullUrl = pathOrUrl
                Else
                    fullUrl = BaseUrl.TrimEnd("/"c) & "/" & pathOrUrl.TrimStart("/"c)
                End If

                Process.Start(New ProcessStartInfo(fullUrl) With {
                    .UseShellExecute = True
                })

                Try
                    Notify.Toast("جاري فتح الرابط في المتصفح... 🌐", Notify.ToastType.Info)
                Catch __logEx As Exception
                    Logger.LogError("WebLinks.vb:76", __logEx)
                End Try

            Catch ex As Exception
                Logger.LogError("WebLinks.OpenUrl", ex)
                SmartMessageBox.Show("تعذر فتح الرابط في المتصفح:" & vbCrLf & ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        ''' <summary>
        ''' فتح الصفحة الرئيسية للموقع
        ''' </summary>
        Public Sub OpenHome()
            OpenUrl(RouteHome)
        End Sub

        ''' <summary>
        ''' فتح صفحة الدعم الفني واتصل بنا
        ''' </summary>
        Public Sub OpenContact()
            OpenUrl(RouteContact)
        End Sub

        ''' <summary>
        ''' فتح صفحة حول البرنامج (من نحن)
        ''' </summary>
        Public Sub OpenAbout()
            OpenUrl(RouteAbout)
        End Sub

        ''' <summary>
        ''' فتح صفحة شروط الاستخدام والأحكام
        ''' </summary>
        Public Sub OpenTerms()
            OpenUrl(RouteTerms)
        End Sub

        ''' <summary>
        ''' فتح صفحة سياسة الخصوصية
        ''' </summary>
        Public Sub OpenPrivacy()
            OpenUrl(RoutePrivacy)
        End Sub

        ''' <summary>
        ''' فتح صفحة سجل التحديثات والإصدارات
        ''' </summary>
        Public Sub OpenUpdates()
            OpenUrl(RouteUpdates)
        End Sub

        ''' <summary>
        ''' فتح صفحة الأكاديمية والشروحات
        ''' </summary>
        Public Sub OpenAcademy()
            OpenUrl(RouteAcademy)
        End Sub

        ''' <summary>
        ''' فتح صفحة التحميلات
        ''' </summary>
        Public Sub OpenDownloads()
            OpenUrl(RouteDownloads)
        End Sub

        ''' <summary>
        ''' فتح صفحة الخطط والأسعار
        ''' </summary>
        Public Sub OpenPricing()
            OpenUrl(RoutePricing)
        End Sub

        ''' <summary>
        ''' فتح صفحة المنتجات والأنظمة
        ''' </summary>
        Public Sub OpenProducts()
            OpenUrl(RouteProducts)
        End Sub

    End Module
