Friend Module PayProcessor
    Friend Function Process(playerId As Integer, tokens() As String) As String
        If tokens.Length <> 0 Then
            Return InvalidProcessor.Process(playerId)
        End If
        If DataStore.Players.HasPayRecord(playerId) Then
            If DataStore.Players.IsOwedPay(playerId) Then
                Dim payment = DataStore.Players.AdditionalPay(playerId)
                Return $"You receive ${payment.Amount}, for a total of ${payment.Total}."
            Else
                Return $"You aren't owed pay until {DataStore.Players.PaymentDue(playerId)}."
            End If
        Else
            Dim payment = DataStore.Players.InitialPay(playerId)
            Return $"You receive ${payment.Amount}, for a total of ${payment.Total}."
        End If
    End Function
End Module
