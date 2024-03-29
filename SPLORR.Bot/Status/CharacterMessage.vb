﻿Imports SPLORR.Model

Friend Module CharacterMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    (player,
                    outputter),
                    Sub(character)
                        outputter($"Vital Statistics:")
                        outputter($"Health: {character.Health}/{character.MaximumHealth}")
                        outputter($"Satiety: {character.Satiety}/{character.MaximumSatiety}")
                        outputter($"Energy: {character.Energy}/{character.MaximumEnergy}")
                        outputter($"Rocks: {character.Rocks}")
                        outputter($"Plant Fibers: {character.PlantFibers}")
                        outputter($"Chewed-Up Bubblegum: {character.ChewedUpBubblegum}")
                    End Sub)
            End Sub)
    End Sub
End Module
