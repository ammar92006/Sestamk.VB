Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' مساعد التجاوب مع الشاشات: يضمن أن أي فورم لا يتجاوز المساحة المتاحة من الشاشة
''' (يصغّره ويفعّل التمرير لو لزم) ويوسّطه. آمن للاستدعاء من Load أي فورم.
''' الاستخدام: LayoutHelper.FitToWorkingArea(Me)
''' </summary>
Public Module LayoutHelper

    ''' <summary>
    ''' يلائم الفورم مع المساحة المتاحة على الشاشة الحالية:
    '''  - لو الفورم Maximized لا نلمسه.
    '''  - لو أكبر من المساحة المتاحة نصغّره ونفعّل AutoScroll حتى يبقى كل المحتوى قابلاً للوصول.
    '''  - نوسّط الفورم داخل المساحة المتاحة.
    ''' </summary>
    Public Sub FitToWorkingArea(frm As Form)
        Try
            If frm Is Nothing Then Return
            If frm.WindowState = FormWindowState.Maximized Then Return

            Dim wa As Rectangle = Screen.FromControl(frm).WorkingArea

            If frm.Width > wa.Width OrElse frm.Height > wa.Height Then
                frm.AutoScroll = True
                frm.Size = New Size(Math.Min(frm.Width, wa.Width),
                                    Math.Min(frm.Height, wa.Height))
            End If

            frm.Location = New Point(
                wa.Left + Math.Max(0, (wa.Width - frm.Width) \ 2),
                wa.Top + Math.Max(0, (wa.Height - frm.Height) \ 2))
        Catch ex As Exception
            Debug.WriteLine("FitToWorkingArea: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' بديل لفورمات العمل الكبيرة (مثل نقاط البيع): تكبير الفورم لملء الشاشة بدل التمرير.
    ''' يُستخدم عندما يكون التكبير أنسب من التصغير مع التمرير.
    ''' </summary>
    Public Sub MaximizeIfTooLarge(frm As Form)
        Try
            If frm Is Nothing Then Return
            If frm.WindowState = FormWindowState.Maximized Then Return

            Dim wa As Rectangle = Screen.FromControl(frm).WorkingArea
            If frm.Width > wa.Width OrElse frm.Height > wa.Height Then
                frm.WindowState = FormWindowState.Maximized
            Else
                FitToWorkingArea(frm)
            End If
        Catch ex As Exception
            Debug.WriteLine("MaximizeIfTooLarge: " & ex.Message)
        End Try
    End Sub

End Module
