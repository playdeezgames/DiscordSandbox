Imports SPLORR.Model

Friend Module CardsMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    player,
                    outputter,
                    Sub(character)
                        outputter("Cards:")
                        For Each card In character.Cards
                            outputter($"- {card.Name}")
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
