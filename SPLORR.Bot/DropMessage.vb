Imports SPLORR.Model

Friend Module DropMessage
    Friend Sub Handle(
                     player As IPlayerModel,
                     tokens() As String,
                     outputter As Action(Of String))
        WithTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    player,
                    outputter,
                    Sub(character)
                        Dim itemName = String.Join(" "c, tokens)
                        Dim items = character.Inventory.ItemsByName(itemName)
                        If Not items.Any Then
                            outputter($"{character.Name} does not have any {itemName}.")
                            Return
                        End If
                        Dim item = items.First
                        item.Inventory = character.Location.Inventory
                        outputter($"{character.Name} drops {item.Name}.")
                    End Sub)
            End Sub)
    End Sub
End Module
