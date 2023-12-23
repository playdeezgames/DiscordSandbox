Imports Discord
Imports Discord.WebSocket
Imports Spectre.Console

Module Program
    Private tcs As TaskCompletionSource = New TaskCompletionSource
    Sub Main(args As String())
        AddHandler Console.CancelKeyPress, AddressOf OnCancelKeyPress
        MainAsync(args).
            GetAwaiter().
            GetResult()
    End Sub

    Private Sub OnCancelKeyPress(sender As Object, e As ConsoleCancelEventArgs)
        e.Cancel = True
        tcs.SetResult()
    End Sub

    Public Async Function MainAsync(ByVal args() As String) As Task
        Const DISCORD_TOKEN = "DISCORD_TOKEN"
        AnsiConsole.MarkupLine("[olive]Starting SPLORR.Host[/]")
        Dim client = New DiscordSocketClient
        AddHandler client.Log, AddressOf OnLog
        AddHandler client.MessageReceived, AddressOf OnMessageReceived
        Await client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable(DISCORD_TOKEN))
        Await client.StartAsync()
        AnsiConsole.MarkupLine("[olive]Awaiting SIGINT[/]")
        Await tcs.Task
        AnsiConsole.MarkupLine("[olive]Stopping SPLORR.Host[/]")
    End Function

    Private Async Function OnMessageReceived(message As SocketMessage) As Task
        Await Task.Run(Sub()
                           AnsiConsole.MarkupLine($"[green]Message From {message.Author.GlobalName}: {message.CleanContent}[/]")
                       End Sub)
    End Function

    Private Async Function OnLog(message As LogMessage) As Task
        Await Task.Run(Sub()
                           AnsiConsole.MarkupLine($"[grey]Log: {message.Message}[/]")
                       End Sub)
    End Function
End Module
