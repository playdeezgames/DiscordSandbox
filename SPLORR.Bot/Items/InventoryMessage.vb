﻿Imports SPLORR.Model

Friend Module InventoryMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    player,
                    outputter,
                    Sub(character)
                        If Not character.Inventory.HasItems Then
                            outputter($"{character.Name} has no items in their inventory.")
                            Return
                        End If
                        outputter($"{character.Name}'s Inventory:")
                        For Each item In character.Inventory.Items
                            outputter($"- {item.Name}")
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
