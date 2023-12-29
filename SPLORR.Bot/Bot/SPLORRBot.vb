Imports SPLORR.Model

Public Class SPLORRBot
    Implements IBot
    Private ReadOnly worldModel As IWorldModel
    Sub New(worldModel As IWorldModel)
        Me.worldModel = worldModel
    End Sub
    Public Sub Start() Implements IBot.Start
        worldModel.Initialize()
    End Sub
    Public Sub [Stop]() Implements IBot.Stop
        worldModel.CleanUp()
    End Sub
    Public Function HandleMessage(authorId As ULong, message As String) As String Implements IBot.HandleMessage
        If Not String.IsNullOrEmpty(message) Then
            Dim tokens = message.Split(" "c)
            If tokens.Length > 0 Then
                Return SPLORR.Bot.Message.Handle(worldModel.GetPlayer(authorId), tokens)
            End If
        End If
        Return MESSAGE_INVALID_INPUT
    End Function
End Class
