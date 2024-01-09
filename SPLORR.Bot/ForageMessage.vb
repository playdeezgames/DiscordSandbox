Imports SPLORR.Model

Friend Module ForageMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithCharacter(
            player,
            outputter,
            Sub(character)
                Dim foragedItem = character.Location.GenerateForageItem(character.Inventory)
                If foragedItem Is Nothing Then
                    outputter($"{character.Name} finds nothing!")
                    Return
                End If
                outputter($"{character.Name} finds {foragedItem.Name}.")
            End Sub)
    End Sub
End Module
