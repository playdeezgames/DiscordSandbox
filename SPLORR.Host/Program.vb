Imports Discord
Imports Discord.WebSocket
Imports Spectre.Console

Module Program
    Private completionSource As TaskCompletionSource = New TaskCompletionSource
    Sub Main(args As String())
        AddHandler Console.CancelKeyPress, AddressOf OnCancelKeyPress
        MainAsync(args).
            GetAwaiter().
            GetResult()
    End Sub

    Private Sub OnCancelKeyPress(sender As Object, e As ConsoleCancelEventArgs)
        e.Cancel = True
        completionSource.SetResult()
    End Sub

    Private Const ENV_VAR_DISCORD_TOKEN = "DISCORD_TOKEN"
    Private Const START_MESSAGE As String = "[olive]Starting SPLORR.Host[/]"
    Private Const WAITING_MESSAGE As String = "[olive]Awaiting SIGINT[/]"
    Private Const STOPPING_MESSAGE As String = "[olive]Stopping SPLORR.Host[/]"

    Public Async Function MainAsync(ByVal args() As String) As Task
        AnsiConsole.MarkupLine(START_MESSAGE)
        Dim client = New DiscordSocketClient
        AddHandler client.Log, AddressOf OnLog
        AddHandler client.MessageReceived, AddressOf OnMessageReceived
        Await client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable(ENV_VAR_DISCORD_TOKEN))
        Await client.StartAsync()
        AnsiConsole.MarkupLine(WAITING_MESSAGE)
        Await completionSource.Task
        AnsiConsole.MarkupLine(STOPPING_MESSAGE)
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
