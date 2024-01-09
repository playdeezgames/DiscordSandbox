Imports SPLORR.Model

Friend Module Utility
    Friend Sub WithCharacter(
                            player As IPlayerModel,
                            outputter As Action(Of String),
                            subhandler As Action(Of ICharacterModel))
        If Not player.HasCharacter Then
            outputter(MESSAGE_NO_CHARACTER)
            Return
        End If
        subhandler(player.Character)
    End Sub
    Friend Sub WithNoTokens(tokens As String(),
                            outputter As Action(Of String),
                            subhandler As Action)
        If tokens.Length > 0 Then
            outputter(MESSAGE_INVALID_INPUT)
            Return
        End If
        subhandler()
    End Sub
End Module
