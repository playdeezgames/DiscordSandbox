Friend Module PayProcessor
    Friend Function Process(playerId As Integer, tokens() As String) As String
        If tokens.Length <> 0 Then
            Return InvalidProcessor.Process(playerId)
        End If
        Return $"TODO: Pay Player#{playerId}"
    End Function
End Module
