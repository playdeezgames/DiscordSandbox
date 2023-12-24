
Imports SPLORR.Bot

Module Program
    Private bot As IBot
    Sub Main(args As String())
        AddHandler Console.CancelKeyPress, AddressOf OnCancelKeyPress
        bot = New SPLORRBot
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
