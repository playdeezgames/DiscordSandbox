Public Class SPLORRBot
    Implements IBot

    Public Sub Start() Implements IBot.Start
    End Sub

    Public Sub [Stop]() Implements IBot.Stop
    End Sub

    Public Function HandleMessage() As String Implements IBot.HandleMessage
        Return String.Empty
    End Function
End Class
