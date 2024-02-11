Imports SPLORR.Model

Friend Module PlayMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithCard(
            player,
            tokens,
            outputter,
            Sub(character, card)
                If Not card.CanPlay Then
                    outputter($"{character.Name} cannot play {card.Name} at this time.")
                    Return
                End If
                outputter($"{character.Name} plays {card.Name}.")
                card.Play(outputter)
            End Sub)
    End Sub
End Module
