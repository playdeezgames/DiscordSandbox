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
            Return ProcessMessage(authorId, tokens)
        End If
        Return MESSAGE_INVALID_INPUT
    End Function

    Private Function ProcessMessage(authorId As ULong, tokens() As String) As String
        Dim firstToken = tokens.First
        Dim remainingTokens = tokens.Skip(1).ToArray
        Select Case firstToken
            Case TOKEN_CREATE
                Return HandleCreateMessage(authorId, remainingTokens)
            Case TOKEN_STATUS
                Return HandleStatusMessage(authorId, remainingTokens)
            Case Else
                Return MESSAGE_INVALID_INPUT
        End Select
    End Function

    Private Function HandleCreateMessage(authorId As ULong, remainingTokens() As String) As String
        Return "success"
    End Function

    Private Shared Function HandleStatusMessage(authorId As ULong, tokens As String()) As String
        If tokens.Length = 0 Then
            Return MESSAGE_NO_CHARACTER
        End If
        Return MESSAGE_INVALID_INPUT
    End Function
End Class
