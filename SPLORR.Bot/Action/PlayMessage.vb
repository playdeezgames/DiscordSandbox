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
                        If Not character.CanPlay(card) Then
                            outputter($"{character.Name} cannot play {card.Name} at this time.")
                            Return
                        End If
                        outputter($"{character.Name} plays {card.Name}.")
                        Dim messages As IEnumerable(Of String) = character.Play(card)
                        For Each message In messages
                            outputter(message)
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
