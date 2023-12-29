Imports SPLORR.Model

Friend Module StatusMessage

    Friend Function Handle(player As IPlayerModel, tokens As String()) As String
        If tokens.Length = 0 Then
            If Not player.HasCharacter Then
                Return MESSAGE_NO_CHARACTER
            End If
            Dim character = player.Character
            Return $"Character Name: {character.Name}
Location Name: {character.Location.Name}"
        End If
        Return MESSAGE_INVALID_INPUT
    End Function

End Module
