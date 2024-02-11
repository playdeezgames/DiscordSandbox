Imports System.Reflection.Emit
Imports SPLORR.Model

Friend Module DescribeMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithCard(
            player,
            tokens,
            outputter,
            Sub(character, card)
                outputter($"Card Name: {card.Name}")
                Dim effects = card.Effects
                For Each effect In effects
                    outputter($"  - Effect: {effect.Name}")
                    Dim statisticDeltas = effect.StatisticDeltas
                    If statisticDeltas.Any Then
                        outputter($"  - Statistic Deltas:")
                        For Each statisticDelta In statisticDeltas
                            outputter($"    - {statisticDelta.Name} {statisticDelta.Delta}")
                        Next
                    End If
                Next
            End Sub)
    End Sub
End Module
