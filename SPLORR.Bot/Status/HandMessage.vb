Imports SPLORR.Model

Friend Module HandMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    player,
                    outputter,
                    Sub(character)
                        outputter("Cards in Hand:")
                        For Each card In character.Hand
                            outputter($"- {card.Name}")
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
