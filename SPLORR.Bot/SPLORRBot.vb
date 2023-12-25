Imports SPLORR.Model

Public Class SPLORRBot
    Implements IBot

    Private Const TOKEN_CREATE As String = "create"
    Private Const TOKEN_STATUS As String = "status"
    Private Const MESSAGE_NO_CHARACTER As String = "You have no character!"
    Private Const MESSAGE_INVALID_INPUT As String = "Invalid input!"
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
        Dim player As IPlayerModel = worldModel.GetPlayer(authorId)
        Dim tokens = message.ToLower.Split(" "c)
        If tokens.Length > 0 Then
            Return ProcessMessage(player, tokens)
        End If
        Return MESSAGE_INVALID_INPUT
    End Function

    Private Shared Function ProcessMessage(player As IPlayerModel, tokens() As String) As String
        Dim firstToken = tokens.First
        Dim remainingTokens = tokens.Skip(1).ToArray
        Select Case firstToken
            Case TOKEN_CREATE
                Return HandleCreateMessage(player, remainingTokens)
            Case TOKEN_STATUS
                Return HandleStatusMessage(player, remainingTokens)
            Case Else
                Return MESSAGE_INVALID_INPUT
        End Select
    End Function

    Private Shared Function HandleCreateMessage(player As IPlayerModel, remainingTokens() As String) As String
        player.CreateCharacter()
        Return "success"
    End Function

    Private Shared Function HandleStatusMessage(player As IPlayerModel, tokens As String()) As String
        If tokens.Length = 0 Then
            Return MESSAGE_NO_CHARACTER
        End If
        Return MESSAGE_INVALID_INPUT
    End Function
End Class
