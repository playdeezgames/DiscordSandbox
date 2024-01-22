Imports SPLORR.Model

Friend Module PlayMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    player,
                    outputter,
                    Sub(character)
                        Dim cardName = String.Join(" "c, tokens)
                        Dim card As ICardModel = character.HandCardByName(cardName)
                        If card Is Nothing Then
                            outputter($"{character.Name} has no such card.")
                            Return
                        End If
                        If Not card.CanPlay Then
                            outputter($"{character.Name} cannot play {card.Name} at this time.")
                            Return
                        End If
                        outputter($"{character.Name} plays {card.Name}.")
                        card.Play(outputter)
                    End Sub)
            End Sub)
    End Sub
End Module
