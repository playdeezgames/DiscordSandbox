Imports SPLORR.Model

Friend Module CreateMessage
    Friend Function Handle(player As IPlayerModel, remainingTokens() As String) As String
        If remainingTokens.Length = 0 Then
            Return InvalidMessage.Handle(player, remainingTokens)
        End If
        Dim firstToken = remainingTokens.First.ToLower
        remainingTokens = remainingTokens.Skip(1).ToArray
        Select Case firstToken
            Case TOKEN_CHARACTER
                Return CreateCharacterMessage.Handle(player, remainingTokens)
            Case Else
                Return InvalidMessage.Handle(player, remainingTokens)
        End Select
    End Function
End Module
