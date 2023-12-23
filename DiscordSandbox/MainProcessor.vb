Public Module MainProcessor
    Private Const ERROR_MESSAGE As String = "Error!"

    Public Function Process(dataStore As IDataStore, playerId As Integer, tokens() As String) As String
        Try
            If tokens.Length = 0 Then
                Return InvalidProcessor.Process(playerId)
            End If
            Dim remainingTokens = tokens.Skip(1).ToArray
            Select Case tokens.First
                Case HELP_TOKEN
                    Return HelpProcessor.Process(dataStore, playerId, remainingTokens)
                Case PAY_TOKEN
                    Return PayProcessor.Process(dataStore, playerId, remainingTokens)
                Case STATUS_TOKEN
                    Return StatusProcessor.Process(dataStore, playerId, remainingTokens)
                Case Else
                    Return InvalidProcessor.Process(playerId)
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Return ERROR_MESSAGE
        End Try
    End Function
End Module
