Imports SPLORR.Model

Friend Module Utility
    Friend Sub WithCharacter(context As (Player As IPlayerModel, Outputter As Action(Of String)),
                            subhandler As Action(Of ICharacterModel))
        If Not context.Player.HasCharacter Then
            context.Outputter(MESSAGE_NO_CHARACTER)
            Return
        End If
        subhandler(context.Player.Character)
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
    Friend Sub WithTokens(tokens As String(),
                            outputter As Action(Of String),
                            subhandler As Action)
        If tokens.Length = 0 Then
            outputter(MESSAGE_INVALID_INPUT)
            Return
        End If
        subhandler()
    End Sub
End Module
