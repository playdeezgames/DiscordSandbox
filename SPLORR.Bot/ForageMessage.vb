Imports SPLORR.Model

Friend Module ForageMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If Not player.HasCharacter Then
            outputter(MESSAGE_NO_CHARACTER)
            Return
        End If
        Throw New NotImplementedException
    End Sub
End Module
