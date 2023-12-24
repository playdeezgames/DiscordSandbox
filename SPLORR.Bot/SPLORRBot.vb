Public Class SPLORRBot
    Implements IBot

    Private Const TOKEN_STATUS As String = "status"
    Private Const MESSAGE_NO_CHARACTER As String = "You have no character!"
    Private Const MESSAGE_INVALID_INPUT As String = "Invalid input!"

    Public Sub Start() Implements IBot.Start
    End Sub

    Public Sub [Stop]() Implements IBot.Stop
    End Sub

    Public Function HandleMessage(authorId As ULong, message As String) As String Implements IBot.HandleMessage
        message = message.ToLower
        If message = TOKEN_STATUS Then
            Return MESSAGE_NO_CHARACTER
        End If
        Return MESSAGE_INVALID_INPUT
    End Function
End Class
