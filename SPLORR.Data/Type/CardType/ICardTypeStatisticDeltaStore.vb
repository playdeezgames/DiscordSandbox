Public Interface ICardTypeStatisticDeltaStore
    Inherits IBaseTypeStore(Of IDataStore)
    Property Delta As Integer
    ReadOnly Property CardType As ICardTypeStore
    ReadOnly Property StatisticType As IStatisticTypeStore
    Property AllowOverage As Boolean
End Interface
