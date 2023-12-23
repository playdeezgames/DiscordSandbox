Imports Discord
Imports Discord.WebSocket

Module Program
    Private tcs As TaskCompletionSource = New TaskCompletionSource
    Private sigintReceived As Boolean = False
    Sub Main(args As String())
        AddHandler Console.CancelKeyPress, AddressOf OnCancelKeyPress
        MainAsync(args).
            GetAwaiter().
            GetResult()
    End Sub

    Private Sub OnCancelKeyPress(sender As Object, e As ConsoleCancelEventArgs)
        e.Cancel = True
        tcs.SetResult()
        sigintReceived = True
    End Sub

    Private Const DISCORD_TOKEN As String = "DISCORD_TOKEN"
    Private client As DiscordSocketClient
    Private dataStore As IDataStore
    Public Async Function MainAsync(ByVal args() As String) As Task
        client = New DiscordSocketClient()
        dataStore = New DataStore
        AddHandler client.Log, AddressOf OnLog
        AddHandler client.MessageReceived, AddressOf OnMessageReceived
        Dim token = Environment.GetEnvironmentVariable(DISCORD_TOKEN)
        Await client.LoginAsync(TokenType.Bot, token)
        Await client.StartAsync()
        Await tcs.Task
        DataStore.Close()
    End Function

    Private Async Function OnMessageReceived(message As SocketMessage) As Task
        If Not message.Author.IsBot AndAlso
            message.Channel.GetChannelType = ChannelType.DM AndAlso
            Not String.IsNullOrEmpty(message.CleanContent) Then
            Await message.Channel.SendMessageAsync(HandleInput(message.Author.Id, message.CleanContent))
        End If
    End Function

    Private Function HandleInput(authorId As ULong, text As String) As String
        Return MainProcessor.Process(
            dataStore,
            dataStore.Players.FindOrCreate(
                CLng(authorId)),
                text.ToLower.Split(" "c))
    End Function

    Private Async Function OnLog(message As LogMessage) As Task
        Await Task.Run(Sub()
                           Console.WriteLine(message.Message)
                       End Sub)
    End Function
End Module
