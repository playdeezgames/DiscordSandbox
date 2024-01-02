Imports SPLORR.Model

Friend Module ForageMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If Not player.HasCharacter Then
            outputter(MESSAGE_NO_CHARACTER)
            Return
        End If
        Dim verbType = player.GetVerbTypeByName(TOKEN_FORAGE)
        If Not player.Character.CanDoVerb(verbType) Then
            outputter($"{player.Character.Name} cannot {TOKEN_FORAGE} here!")
            Return
        End If
        player.Character.DoVerb(verbType, outputter)
    End Sub
End Module
