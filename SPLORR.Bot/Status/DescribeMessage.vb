Imports SPLORR.Model

Friend Module DescribeMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithCard(
            player,
            tokens,
            outputter,
            Sub(character, card)
                outputter($"Card Name: {card.Name}")
            End Sub)
    End Sub
End Module
