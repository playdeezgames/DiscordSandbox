Imports SPLORR.Model

Friend Module CreateCharacterMessage

    Friend Function Handle(player As IPlayerModel, remainingTokens() As String) As String
        If player.HasCharacter Then
            Return MESSAGE_ALREADY_HAVE_CHARACTER
        End If
        player.CreateCharacter()
        Return StatusMessage.Handle(player, Array.Empty(Of String))
    End Function
End Module
