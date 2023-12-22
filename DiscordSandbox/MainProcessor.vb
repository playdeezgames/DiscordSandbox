Friend Module MainProcessor
    Private Const PAY_TOKEN = "pay"
    Friend Function Process(playerId As Integer, tokens() As String) As String
        Try
            If tokens.Length = 0 Then
                Return InvalidProcessor.Process(playerId)
            End If
            Select Case tokens.First
                Case PAY_TOKEN
                    Return PayProcessor.Process(playerId, tokens.Skip(1).ToArray)
                Case Else
                    Return InvalidProcessor.Process(playerId)
            End Select
        Catch ex As Exception
            Throw
        End Try
    End Function
End Module
