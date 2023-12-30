Imports SPLORR.Model

Friend Module CreateCharacterMessage

    Friend Sub Handle(player As IPlayerModel, remainingTokens() As String, outputter As Action(Of String))
        If player.HasCharacter Then
            outputter(MESSAGE_ALREADY_HAVE_CHARACTER)
            Return
        End If
        player.CreateCharacter()
        StatusMessage.Handle(player, Array.Empty(Of String), outputter)
    End Sub
End Module
