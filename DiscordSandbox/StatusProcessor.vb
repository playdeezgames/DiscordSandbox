Imports System.Text

Friend Module StatusProcessor
    Friend Function Process(dataStore As IDataStore, playerId As Integer, tokens() As String) As String
        If tokens.Length <> 0 Then
            Return InvalidProcessor.Process(playerId)
        End If
        Dim result As New StringBuilder
        If dataStore.Players.HasPayRecord(playerId) Then
            result.AppendLine($"Next payment due: {dataStore.Players.PaymentDue(playerId)}")
            result.AppendLine($"Wallet: ${dataStore.Players.Wallet(playerId)}")
        Else
            result.AppendLine("Hasn't ever been paid!")
        End If
        Return result.ToString
    End Function
End Module
