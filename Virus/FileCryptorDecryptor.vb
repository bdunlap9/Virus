Imports System.Security.Cryptography
Imports System.Text

Public Class FileCryptorDecryptor

    Public Shared Function method(ByVal Key As String) As TripleDES
        Dim m As MD5 = New MD5CryptoServiceProvider
        Dim d As TripleDES = New TripleDESCryptoServiceProvider
        d.Key = m.ComputeHash(Encoding.Unicode.GetBytes(Key))
        d.IV = New Byte(((d.BlockSize / 8)) - 1) {}
        Return d
    End Function

    Public Shared Function encrypt(ByVal value As String, ByVal key As String) As Byte()
        Dim d As TripleDES = method(key)
        Dim c As ICryptoTransform = d.CreateEncryptor
        Dim Input() As Byte = Encoding.Unicode.GetBytes(value)
        Return c.TransformFinalBlock(Input, 0, Input.Length)
    End Function

    Public Shared Function decrypt(ByVal value As String, ByVal key As String) As String
        Dim b() As Byte = Convert.FromBase64String(value)
        Dim d As TripleDES = method(key)
        Dim c As ICryptoTransform = d.CreateDecryptor
        Dim output() As Byte = c.TransformFinalBlock(b, 0, b.Length)
        Return Encoding.Unicode.GetString(output)
    End Function

End Class
