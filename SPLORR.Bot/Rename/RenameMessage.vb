Imports SPLORR.Model

Friend Module RenameMessage
    Friend Sub Handle(player As IPlayerModel, remainingTokens() As String, outputter As Action(Of String))
        If remainingTokens.Length = 0 Then
            outputter(MESSAGE_INVALID_INPUT)
            Return
        End If
        Dim firstToken = remainingTokens.First
        remainingTokens = remainingTokens.Skip(1).ToArray
        Select Case firstToken.ToLower
            Case TOKEN_CHARACTER
                RenameCharacterMessage.Handle(player, remainingTokens, outputter)
            Case Else
                outputter(MESSAGE_INVALID_INPUT)
        End Select
    End Sub
End Module
