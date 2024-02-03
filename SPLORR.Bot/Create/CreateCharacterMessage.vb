Imports SPLORR.Model

Friend Module CreateCharacterMessage

    Friend Sub Handle(player As IPlayerModel, remainingTokens() As String, outputter As Action(Of String))
        If player.HasCharacter Then
            outputter(MESSAGE_ALREADY_HAVE_CHARACTER)
            Return
        End If
        If Not remainingTokens.Any Then
            player.CreateCharacter()
            StatusMessage.Handle(player, Array.Empty(Of String), outputter)
            Return
        End If
        Dim characterTypeName = String.Join(" "c, remainingTokens)
        Dim characterType = player.FindSelectableCharacterType(characterTypeName)
        If characterType Is Nothing Then
            outputter("No such character type!")
            Return
        End If
        player.CreateCharacter(characterType)
        StatusMessage.Handle(player, Array.Empty(Of String), outputter)
    End Sub
End Module
