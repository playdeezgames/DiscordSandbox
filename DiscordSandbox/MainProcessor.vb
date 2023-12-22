Friend Module MainProcessor
    Private Const PAY_TOKEN = "pay"
    Private Const ERROR_MESSAGE As String = "Error!"

    Friend Function Process(dataStore As DataStore, playerId As Integer, tokens() As String) As String
        Try
            If tokens.Length = 0 Then
                Return InvalidProcessor.Process(playerId)
            End If
            Select Case tokens.First
                Case PAY_TOKEN
                    Return PayProcessor.Process(dataStore, playerId, tokens.Skip(1).ToArray)
                Case Else
                    Return InvalidProcessor.Process(playerId)
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Return ERROR_MESSAGE
        End Try
    End Function
End Module
