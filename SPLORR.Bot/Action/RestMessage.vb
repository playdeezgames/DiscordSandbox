Imports SPLORR.Model

Friend Module RestMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    player,
                    outputter,
                    Sub(character)
                        For Each message In character.Rest()
                            outputter(message)
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
