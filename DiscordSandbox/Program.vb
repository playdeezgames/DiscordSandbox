Imports Discord
Imports Discord.WebSocket

Module Program
    Sub Main(args As String())
        MainAsync(args).
            GetAwaiter().
            GetResult()
    End Sub
    Private client As DiscordSocketClient
    Public Async Function MainAsync(ByVal args() As String) As Task
        client = New DiscordSocketClient()
        AddHandler client.Log, AddressOf OnLog
        AddHandler client.MessageReceived, AddressOf OnMessageReceived
        Dim token = "NzI4MDMzMjg2MDM4ODgwMjk4.GOPki9.PDJD5EmbothtwVp2s-yN5s_Sekc5IV_yXlmfLs"
        Await client.LoginAsync(TokenType.Bot, token)
        Await client.StartAsync()
        Await Task.Delay(-1)
    End Function

    Private Async Function OnMessageReceived(message As SocketMessage) As Task
        If Not message.Author.IsBot Then
            If message.Channel.GetChannelType = ChannelType.DM AndAlso Not String.IsNullOrEmpty(message.CleanContent) Then
                Await message.Channel.SendMessageAsync("!!!")
            End If
        End If
    End Function

    Private Async Function OnLog(message As LogMessage) As Task
        Await Task.Run(Sub()
                           Console.WriteLine(message.Message)
                       End Sub)
    End Function
End Module
