
Imports SPLORR.Bot
Imports SPLORR.Data
Imports SPLORR.Model

Module Program
    Private Const ENV_VAR_CONNECTION_STRING = "CONNECTION_STRING"
    Private bot As IBot
    Sub Main(args As String())
        AddHandler Console.CancelKeyPress, AddressOf OnCancelKeyPress
        Try
            Dim worldModel As New WorldModel(New DataStore(Environment.GetEnvironmentVariable(ENV_VAR_CONNECTION_STRING)))
            bot = New SPLORRBot(worldModel)
            bot.Start()
            Do
                Console.Write("> ")
                Dim input = Console.ReadLine
                Console.WriteLine(bot.HandleMessage(0, input))
            Loop
        Catch ex As Exception
            bot.Stop()
            Console.WriteLine($"Exception: {ex}")
            Console.ReadLine()
        End Try
    End Sub

    Private Sub OnCancelKeyPress(sender As Object, e As ConsoleCancelEventArgs)
        bot.Stop()
        End
    End Sub
End Module
