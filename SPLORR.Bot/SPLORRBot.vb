Public Class SPLORRBot
    Implements IBot

    Public Sub Start() Implements IBot.Start
    End Sub

    Public Sub [Stop]() Implements IBot.Stop
    End Sub

    Public Function HandleMessage(authorId As ULong, message As String) As String Implements IBot.HandleMessage
        Return "OHAI!"
    End Function
End Class
