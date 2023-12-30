Imports SPLORR.Model

Friend Module RenameCharacterMessage
    Friend Sub Handle(player As IPlayerModel, remainingTokens() As String, outputter As Action(Of String))
        If remainingTokens.Length = 0 Then
            outputter(MESSAGE_INVALID_INPUT)
            Return
        End If
        player.Character.Name = String.Join(" "c, remainingTokens)
        outputter($"Character has been renamed to '{player.Character.Name}'.")
    End Sub
End Module
