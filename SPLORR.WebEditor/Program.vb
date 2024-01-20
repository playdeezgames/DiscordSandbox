Imports System
Imports SPLORR.Data

Module Program
    Const ENV_VAR_CONNECTION_STRING = "CONNECTION_STRING"
    Private dataStore As IDataStore = Nothing
    Private keepRunning As Boolean = True
    Sub Main(args As String())
        Console.Title = "SPLORR!! Web Editor"
        AddHandler Console.CancelKeyPress, AddressOf OnCancelKeyPress
        Console.WriteLine("Starting HTTP listener...")

        dataStore = New DataStore(Environment.GetEnvironmentVariable(ENV_VAR_CONNECTION_STRING))
        HttpServer.Start("127.0.0.1", 8080, dataStore)

        While keepRunning
        End While
        dataStore.CleanUp()
        HttpServer.Stop()

        Console.WriteLine("Stopping HTTP listener...")
    End Sub

    Private Sub OnCancelKeyPress(sender As Object, e As ConsoleCancelEventArgs)
        e.Cancel = True
        keepRunning = False
    End Sub
End Module
