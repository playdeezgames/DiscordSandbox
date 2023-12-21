Imports Discord
Imports Discord.WebSocket

Module Program
    Sub Main(args As String())
        MainAsync(args).
            GetAwaiter().
            GetResult()
    End Sub

    Private Const DISCORD_TOKEN As String = "DISCORD_TOKEN"
    Private client As DiscordSocketClient
    Public Async Function MainAsync(ByVal args() As String) As Task
        client = New DiscordSocketClient()
        AddHandler client.Log, AddressOf OnLog
        AddHandler client.MessageReceived, AddressOf OnMessageReceived
        Dim token = Environment.GetEnvironmentVariable(DISCORD_TOKEN)
        Await client.LoginAsync(TokenType.Bot, token)
        Await client.StartAsync()
        Await Task.Delay(-1)
    End Function

    Private Async Function OnMessageReceived(message As SocketMessage) As Task
        If Not message.Author.IsBot AndAlso
            message.Channel.GetChannelType = ChannelType.DM AndAlso
            Not String.IsNullOrEmpty(message.CleanContent) Then
            Await message.Channel.SendMessageAsync(HandleInput(message.Author.Id, message.CleanContent))
        End If
    End Function

    Private Function HandleInput(authorId As ULong, text As String) As String
        Dim playerId As Integer = DataStore.FindOrCreatePlayerForAuthor(CLng(authorId))
        Return MainProcessor.Process(playerId, text.ToLower.Split(" "c))
    End Function

    Private Async Function OnLog(message As LogMessage) As Task
        Await Task.Run(Sub()
                           Console.WriteLine(message.Message)
                       End Sub)
    End Function
End Module
