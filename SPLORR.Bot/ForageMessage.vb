Imports SPLORR.Model

Friend Module ForageMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If Not player.HasCharacter Then
            outputter(MESSAGE_NO_CHARACTER)
            Return
        End If
        Dim character = player.Character
        Dim foragedItem = character.Location.GenerateForageItem(character.Inventory)
        If foragedItem Is Nothing Then
            outputter($"{character.Name} finds nothing!")
        End If
        outputter($"{character.Name} finds {foragedItem.Name}.")
    End Sub
End Module
