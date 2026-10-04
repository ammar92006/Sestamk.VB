Option Strict On
Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' تجزئة كلمات المرور باستخدام PBKDF2 (Rfc2898DeriveBytes + SHA256).
''' الصيغة المخزنة: PBKDF2$&lt;iterations&gt;$&lt;saltBase64&gt;$&lt;hashBase64&gt;
''' كلمات المرور القديمة المخزنة نصاً صريحاً يتم التحقق منها ثم ترقيتها تلقائياً عند تسجيل الدخول.
''' </summary>
Public NotInheritable Class PasswordHasher

    Public Const Prefix As String = "PBKDF2$"
    Private Const DefaultIterations As Integer = 100000
    Private Const SaltSizeBytes As Integer = 16
    Private Const HashSizeBytes As Integer = 32

    Private Sub New()
    End Sub

    ''' <summary>هل النص المخزن مجزأ بالفعل بصيغة PBKDF2؟</summary>
    Public Shared Function IsHashed(stored As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(stored) AndAlso stored.StartsWith(Prefix, StringComparison.Ordinal)
    End Function

    ''' <summary>توليد تجزئة PBKDF2 لكلمة المرور مع ملح عشوائي جديد.</summary>
    Public Shared Function Hash(password As String) As String
        If password Is Nothing Then password = String.Empty
        Dim salt(SaltSizeBytes - 1) As Byte
        Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
            rng.GetBytes(salt)
        End Using
        Using derive As New Rfc2898DeriveBytes(password, salt, DefaultIterations, HashAlgorithmName.SHA256)
            Dim hashBytes As Byte() = derive.GetBytes(HashSizeBytes)
            Return Prefix & DefaultIterations & "$" & Convert.ToBase64String(salt) & "$" & Convert.ToBase64String(hashBytes)
        End Using
    End Function

    ''' <summary>
    ''' التحقق من كلمة المرور مقابل المخزن.
    ''' يدعم الصيغة المجزأة، وكلمات المرور القديمة المخزنة نصاً صريحاً (للسماح بالترقية التلقائية فقط).
    ''' </summary>
    Public Shared Function Verify(password As String, stored As String) As Boolean
        If stored Is Nothing Then stored = String.Empty
        If password Is Nothing Then password = String.Empty

        If Not IsHashed(stored) Then
            ' كلمة مرور قديمة نص صريح - مقارنة ثابتة الزمن، والمستدعي مسؤول عن ترقيتها إلى تجزئة
            Return FixedTimeEquals(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(stored))
        End If

        Dim parts As String() = stored.Split("$"c)
        If parts.Length <> 4 Then Return False

        Dim iterations As Integer
        If Not Integer.TryParse(parts(1), iterations) OrElse iterations < 1000 Then Return False

        Dim salt As Byte()
        Dim expected As Byte()
        Try
            salt = Convert.FromBase64String(parts(2))
            expected = Convert.FromBase64String(parts(3))
        Catch
            Return False
        End Try
        If salt.Length = 0 OrElse expected.Length = 0 Then Return False

        Using derive As New Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256)
            Dim actual As Byte() = derive.GetBytes(expected.Length)
            Return FixedTimeEquals(actual, expected)
        End Using
    End Function

    Private Shared Function FixedTimeEquals(a As Byte(), b As Byte()) As Boolean
        If a Is Nothing OrElse b Is Nothing OrElse a.Length <> b.Length Then Return False
        Dim diff As Integer = 0
        For i As Integer = 0 To a.Length - 1
            diff = diff Or (a(i) Xor b(i))
        Next
        Return diff = 0
    End Function
End Class
