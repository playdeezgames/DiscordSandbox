Imports System.IO
Imports Discord
Imports Discord.WebSocket
Imports Spectre.Console
Imports SPLORR.Bot
Imports SPLORR.Data
Imports SPLORR.Model

Module Program
    Private Const ENV_VAR_CONNECTION_STRING = "CONNECTION_STRING"
    Private completionSource As TaskCompletionSource = New TaskCompletionSource
    Sub Main(args As String())
        Console.Title = "SPLORR!! Discord Host"
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
    Private bot As IBot
    Private worldModel As IWorldModel = Nothing

    Public Async Function MainAsync(ByVal args() As String) As Task
        Dim dataStore As IDataStore = New DataStore(Environment.GetEnvironmentVariable(ENV_VAR_CONNECTION_STRING))
        worldModel = New WorldModel(dataStore)
        bot = New Bot.SPLORRBot(worldModel)
        bot.Start()
        AnsiConsole.MarkupLine(START_MESSAGE)
        Dim client = New DiscordSocketClient
        AddHandler client.Log, AddressOf OnLog
        AddHandler client.MessageReceived, AddressOf OnMessageReceived
        Await client.LoginAsync(TokenType.Bot, File.ReadAllText(Environment.GetEnvironmentVariable(ENV_VAR_DISCORD_TOKEN)))
        Await client.StartAsync()
        AnsiConsole.MarkupLine(WAITING_MESSAGE)
        Await completionSource.Task
        AnsiConsole.MarkupLine(STOPPING_MESSAGE)
        bot.Stop()
        bot = Nothing
    End Function

    Private Async Function OnMessageReceived(message As SocketMessage) As Task
        Try
            Dim author = message.Author
            Dim channel = message.Channel
            Dim channelType = channel.GetChannelType
            Dim cleanContent = message.CleanContent
            If Not author.IsBot AndAlso
                                channelType = Discord.ChannelType.DM AndAlso
                                Not String.IsNullOrEmpty(cleanContent) Then
                Dim result = bot.HandleMessage(author.Id, cleanContent)
                Await channel.SendMessageAsync(result)
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Async Function OnLog(message As LogMessage) As Task
        Await Task.Run(Sub()
                           AnsiConsole.MarkupLine($"[grey]Log: {message.Message}[/]")
                       End Sub)
    End Function
End Module
