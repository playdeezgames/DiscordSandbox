Imports SPLORR.Model

Friend Module RenameCharacterMessage
    Friend Function Handle(player As IPlayerModel, remainingTokens() As String) As String
        If remainingTokens.Length = 0 Then
            Return MESSAGE_INVALID_INPUT
        End If
        player.Character.Name = String.Join(" "c, remainingTokens)
        Return $"Character has been renamed to '{player.Character.Name}'."
    End Function
End Module
