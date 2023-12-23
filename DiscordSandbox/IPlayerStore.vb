Public Interface IPlayerStore
    Function HasPayRecord(playerId As Integer) As Boolean
    Function IsOwedPay(playerId As Integer) As Boolean
    Function FindOrCreate(discordId As Long) As Integer
    Function InitialPay(playerId As Integer) As (Amount As Integer, Total As Integer)
    Function AdditionalPay(playerId As Integer) As (Amount As Integer, Total As Integer)
    Function PaymentDue(playerId As Integer) As DateTimeOffset
    Function Wallet(playerId As Integer) As Integer
End Interface
