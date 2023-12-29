Imports SPLORR.Model

Friend Module RenameMessage
    Friend Function Handle(player As IPlayerModel, remainingTokens() As String) As String
        If remainingTokens.Length = 0 Then
            Return MESSAGE_INVALID_INPUT
        End If
        Dim firstToken = remainingTokens.First
        remainingTokens = remainingTokens.Skip(1).ToArray
        Select Case firstToken.ToLower
            Case TOKEN_CHARACTER
                Return RenameCharacterMessage.Handle(player, remainingTokens)
            Case Else
                Return MESSAGE_INVALID_INPUT
        End Select
    End Function
End Module
