Imports SPLORR.Model

Friend Module TakeMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    player,
                    outputter,
                    Sub(character)
                        Dim itemName = String.Join(" "c, tokens)
                        Dim inventory = character.Location.Inventory
                        Dim items = inventory.ItemsByName(itemName)
                        If Not items.Any Then
                            outputter($"The ground has no {itemName}.")
                            Return
                        End If
                        Dim item = items.First
                        item.Inventory = character.Inventory
                        outputter($"{character.Name} takes {item.Name}.")
                    End Sub)
            End Sub)
    End Sub
End Module
