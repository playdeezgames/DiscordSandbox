Imports SPLORR.Model

Public Class SPLORRBot
    Implements IBot

    Private Const TOKEN_CREATE As String = "create"
    Private Const TOKEN_STATUS As String = "status"
    Private Const TOKEN_RENAME As String = "rename"
    Private Const TOKEN_CHARACTER As String = "character"

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
        If Not String.IsNullOrEmpty(message) Then
            Dim tokens = message.Split(" "c)
            If tokens.Length > 0 Then
                Return ProcessMessage(worldModel.GetPlayer(authorId), tokens)
            End If
        End If
        Return MESSAGE_INVALID_INPUT
    End Function

    Private Shared Function ProcessMessage(player As IPlayerModel, tokens() As String) As String
        Dim firstToken = tokens.First
        Dim remainingTokens = tokens.Skip(1).ToArray
        Select Case firstToken.ToLower
            Case TOKEN_CREATE
                Return HandleCreateMessage(player, remainingTokens)
            Case TOKEN_STATUS
                Return HandleStatusMessage(player, remainingTokens)
            Case TOKEN_RENAME
                Return HandleRenameMessage(player, remainingTokens)
            Case Else
                Return MESSAGE_INVALID_INPUT
        End Select
    End Function

    Private Shared Function HandleRenameMessage(player As IPlayerModel, remainingTokens() As String) As String
        If remainingTokens.Length = 0 Then
            Return MESSAGE_INVALID_INPUT
        End If
        Dim firstToken = remainingTokens.First
        remainingTokens = remainingTokens.Skip(1).ToArray
        Select Case firstToken.ToLower
            Case TOKEN_CHARACTER
                Return HandleRenameCharacterMessage(player, remainingTokens)
            Case Else
                Return MESSAGE_INVALID_INPUT
        End Select
    End Function

    Private Shared Function HandleRenameCharacterMessage(player As IPlayerModel, remainingTokens() As String) As String
        If remainingTokens.Length = 0 Then
            Return MESSAGE_INVALID_INPUT
        End If
        player.Character.Name = String.Join(" "c, remainingTokens)
        Return $"Character has been renamed to '{player.Character.Name}'."
    End Function

    Private Shared Function HandleCreateMessage(player As IPlayerModel, remainingTokens() As String) As String
        If player.HasCharacter Then
            Return "failure"
        Else
            player.CreateCharacter()
            Return "success"
        End If
    End Function

    Private Shared Function HandleStatusMessage(player As IPlayerModel, tokens As String()) As String
        If tokens.Length = 0 Then
            Return MESSAGE_NO_CHARACTER
        End If
        Return MESSAGE_INVALID_INPUT
    End Function
End Class
