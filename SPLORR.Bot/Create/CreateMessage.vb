Imports SPLORR.Model

Friend Module CreateMessage
    Friend Sub Handle(player As IPlayerModel, remainingTokens() As String, outputter As Action(Of String))
        If remainingTokens.Length = 0 Then
            InvalidMessage.Handle(player, remainingTokens, outputter)
            Return
        End If
        Dim firstToken = remainingTokens.First.ToLower
        remainingTokens = remainingTokens.Skip(1).ToArray
        Select Case firstToken
            Case TOKEN_CHARACTER
                CreateCharacterMessage.Handle(player, remainingTokens, outputter)
                Return
            Case Else
                InvalidMessage.Handle(player, remainingTokens, outputter)
                Return
        End Select
    End Sub
End Module
