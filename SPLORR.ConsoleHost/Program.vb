
Imports SPLORR.Bot
Imports SPLORR.Model

Module Program
    Private bot As IBot
    Private worldModel As IWorldModel = Nothing
    Sub Main(args As String())
        AddHandler Console.CancelKeyPress, AddressOf OnCancelKeyPress
        bot = New SPLORRBot(worldModel)
        bot.Start()
        Do
            Console.Write("> ")
            Dim input = Console.ReadLine
            Console.WriteLine(bot.HandleMessage(0, input))
        Loop
    End Sub

    Private Sub OnCancelKeyPress(sender As Object, e As ConsoleCancelEventArgs)
        Bot.Stop
        End
    End Sub
End Module
