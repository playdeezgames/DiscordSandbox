Imports SPLORR.Model

Friend Module InventoryMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    (player,
                    outputter),
                    Sub(character)
                        outputter("Inventory:")
                        For Each entry In character.Inventory
                            outputter($"- {entry.Key} x{entry.Value}")
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
