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
                    Dim locationType = effect.LocationType
                    If locationType IsNot Nothing Then
                        outputter($"    - Restricted to {locationType.Name}")
                    End If
                    Dim requirements = effect.Requirements
                    For Each requirement In requirements
                        Dim minimumValue = requirement.Minimum
                        Dim maximumValue = requirement.Maximum
                        If minimumValue.hasValue Then
                            outputter($"    - {requirement.Name} minimum {requirement.Minimum}")
                        End If
                        If maximumValue.hasValue Then
                            outputter($"    - {requirement.Name} minimum {requirement.Maximum}")
                        End If
                    Next
                    Dim statisticDeltas = effect.StatisticDeltas
                    For Each statisticDelta In statisticDeltas
                        outputter($"    - {statisticDelta.Name} {statisticDelta.Delta}")
                    Next
                    Dim destinations = effect.Destinations
                    If destinations.Any Then
                        Dim totalWeight = destinations.Sum(Function(x) x.GeneratorWeight)
                        For Each destination In destinations
                            outputter($"    - Move to {destination.Name} {destination.AsPercentage(totalWeight):F0}%")
                        Next
                    End If
                    Dim cardTypeGenerators = effect.CardTypeGenerators
                    For Each cardTypeGenerator In cardTypeGenerators
                        outputter($"    - Generate {cardTypeGenerator.CardCount} card(s) from:")
                        Dim cardTypes = cardTypeGenerator.CardTypes
                        Dim totalWeight = cardTypes.Sum(Function(x) x.GeneratorWeight)
                        For Each cardType In cardTypes
                            outputter($"      - {cardType.Name} {cardType.AsPercentage(totalWeight):f0}%")
                        Next
                    Next
                Next
            End Sub)
    End Sub
End Module
