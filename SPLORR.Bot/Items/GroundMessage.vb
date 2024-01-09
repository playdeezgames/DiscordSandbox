Imports SPLORR.Model

Friend Module GroundMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    player,
                    outputter,
                    Sub(character)
                        Dim inventory = character.Location.Inventory
                        If Not inventory.HasItems Then
                            outputter($"{character.Name} finds nothing on the ground.")
                            Return
                        End If
                        outputter($"On the ground:")
                        For Each item In inventory.Items
                            outputter($"- {item.Name}")
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
