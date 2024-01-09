Imports SPLORR.Model

Friend Module InventoryMessage
    Friend Sub Handle(player As IPlayerModel, token() As String, outputter As Action(Of String))
        WithCharacter(
            player,
            outputter,
            Sub(character)
                Throw New NotImplementedException()
            End Sub)
    End Sub
End Module
