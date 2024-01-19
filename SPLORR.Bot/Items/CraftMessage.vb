Imports SPLORR.Model

Friend Module CraftMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithCharacter(
            player,
            outputter,
            Sub(character)
                WithTokens(
                    tokens,
                    outputter,
                    Sub()
                        Dim recipeName = String.Join(" "c, tokens)
                        Dim recipe As IRecipeModel = character.FindRecipeByName(recipeName)
                        If recipe Is Nothing OrElse Not character.CanCraft(recipe) Then
                            outputter($"{character.Name} cannot craft {recipeName}.")
                            Return
                        End If
                        Dim deltas As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeModel)) = character.Craft(recipe)
                        For Each delta In deltas
                            outputter($"{delta.Quantity} {delta.ItemType.Name}")
                        Next
                    End Sub)
            End Sub)
    End Sub
End Module
