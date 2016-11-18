Imports System.Runtime.InteropServices

Public Class clsProcessProtect

    <DllImport("ntdll")>
    Private Shared Function NtSetInformationProcess(ByVal hProcess As IntPtr, ByVal processInformationClass As Integer, ByRef processInformation As Integer, ByVal processInformationLength As Integer) As Integer
    End Function

    Dim psStop As New EventHandler(AddressOf StopProcessProtection)
    Const iStop As Byte = 0
    Const iStart As Byte = 1
    Const ProcessPriorityClass As Byte = 29

    Public Sub New()

    End Sub

    Public Sub Start()
        StartProcessProtection(iStart)
        AddHandler AppDomain.CurrentDomain.ProcessExit, psStop
        AddHandler AppDomain.CurrentDomain.DomainUnload, psStop
        AddHandler Application.ApplicationExit, psStop
    End Sub

    Private Function StartProcessProtection(ByRef psInfo As Integer) As Boolean
        Try
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, ProcessPriorityClass, psInfo, Marshal.SizeOf(psInfo))
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.InnerException.ToString())
        End Try

    End Function

    Private Function StopProcessProtection(ByVal sender As Object, ByVal e As System.EventArgs) As Boolean
        Try
            StartProcessProtection(iStop)
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & ex.InnerException.ToString())
        End Try
    End Function

End Class
