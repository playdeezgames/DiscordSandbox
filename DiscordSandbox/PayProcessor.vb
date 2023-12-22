Friend Module PayProcessor
    Friend Function Process(dataStore As DataStore, playerId As Integer, tokens() As String) As String
        If tokens.Length <> 0 Then
            Return InvalidProcessor.Process(playerId)
        End If
        If dataStore.Players.HasPayRecord(playerId) Then
            If dataStore.Players.IsOwedPay(playerId) Then
                Dim payment = dataStore.Players.AdditionalPay(playerId)
                Return $"You receive ${payment.Amount}, for a total of ${payment.Total}."
            Else
                Return $"You aren't owed pay until {dataStore.Players.PaymentDue(playerId)}."
            End If
        Else
            Dim payment = dataStore.Players.InitialPay(playerId)
            Return $"You receive ${payment.Amount}, for a total of ${payment.Total}."
        End If
    End Function
End Module
