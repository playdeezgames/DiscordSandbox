Imports SPLORR.Model

Friend Module DieMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    (player,
                    outputter),
                    Sub(character)
                        outputter($"RIP {character.Name}")
                        character.Die()
                    End Sub)
            End Sub)
    End Sub
End Module
