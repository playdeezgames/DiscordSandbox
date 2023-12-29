Imports SPLORR.Model

Friend Module CreateMessage
    Friend Function Handle(player As IPlayerModel, remainingTokens() As String) As String
        If player.HasCharacter Then
            Return "failure"
        Else
            player.CreateCharacter()
            Return "success"
        End If
    End Function
End Module
