Imports SPLORR.Model

Friend Module CardsMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    (player,
                    outputter),
                    Sub(character)
                        outputter("Cards:")
                        For Each cardCount In character.CardCounts
                            outputter($"- {cardCount.Name} x {cardCount.Quantity}{If(cardCount.Limit.HasValue, $"/{cardCount.Limit.Value}", "")}")
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
