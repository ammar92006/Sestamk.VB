Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports System.Text.Json
Imports System.IO

Public Class WhatsAppAPI

    ' [FIX] إضافة Timeout قصير حتى لا تتجمد الواجهة لو السيرفر المحلي
    '       (localhost:3050) لم يستجب. الافتراضي 100 ثانية = حجب طويل.
    Private Shared ReadOnly client As New HttpClient() With {
        .Timeout = TimeSpan.FromSeconds(8)
    }

    ' =======================
    ' إرسال رسالة نصية
    ' =======================
    Public Shared Async Function SendText(phone As String, message As String) As Task(Of Boolean)
        Dim payload = New With {
            Key .phone = phone,
            Key .message = message
        }

        Dim json As String = JsonSerializer.Serialize(payload)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Try
            Dim response = Await client.PostAsync("http://localhost:3050/send", content)
            Dim responseText = Await response.Content.ReadAsStringAsync()

            If responseText.Contains("""success"":true") Then
                LogMessage(phone, message, "text")
                Return True
            ElseIf responseText.Contains("""notRegistered"":true") Then
                SmartMessageBox.Show("⚠️ الرقم غير مسجّل على واتساب")
                Return False
            Else
                SmartMessageBox.Show("❌ فشل الإرسال" & vbCrLf & responseText)
                Return False
            End If

        Catch ex As Exception
            SmartMessageBox.Show($"المشكلة هنا : {ex.Message}")
            Return False
        End Try
    End Function

    ' =======================
    ' إرسال ملف/صورة/ميديا
    ' =======================
    Public Shared Async Function SendMedia(phone As String, filePath As String, Optional caption As String = "") As Task(Of Boolean)
        If Not File.Exists(filePath) Then
            SmartMessageBox.Show("❌ الملف غير موجود: " & filePath)
            Return False
        End If

        ' تحويل الملف إلى Base64
        Dim fileBytes = File.ReadAllBytes(filePath)
        Dim base64File As String = Convert.ToBase64String(fileBytes)

        Dim payload = New With {
            Key .phone = phone,
            Key .fileName = Path.GetFileName(filePath),
            Key .fileData = base64File,
            Key .caption = caption
        }

        Dim json As String = JsonSerializer.Serialize(payload)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Try
            Dim response = Await client.PostAsync("http://localhost:3050/send-media", content)
            Dim responseText = Await response.Content.ReadAsStringAsync()

            If responseText.Contains("""success"":true") Then
                LogMessage(phone, caption & " [" & Path.GetFileName(filePath) & "]", "media")
                Return True
            ElseIf responseText.Contains("""notRegistered"":true") Then
                SmartMessageBox.Show("⚠️ الرقم غير مسجّل على واتساب")
                Return False
            Else
                SmartMessageBox.Show("❌ فشل الإرسال" & vbCrLf & responseText)
                Return False
            End If

        Catch ex As Exception
            SmartMessageBox.Show($"المشكلة هنا : {ex.Message}")
            Return False
        End Try
    End Function

    ' ===========================
    ' تسجيل الرسائل (Log)
    ' ===========================
    Private Shared Sub LogMessage(phone As String, content As String, type As String)
        'Try
        '    Dim logLine As String = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {phone} | {type} | {content}{Environment.NewLine}"
        '    File.AppendAllText("WhatsAppMessages.log", logLine, Encoding.UTF8)
        'Catch ex As Exception
        'End Try
    End Sub

End Class
