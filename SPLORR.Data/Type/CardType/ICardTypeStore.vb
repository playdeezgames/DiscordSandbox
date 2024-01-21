Public Interface ICardTypeStore
    Inherits IBaseTypeStore
    Function CreateCard(store As ICharacterStore) As ICardStore
    Function AddStatisticDelta(statisticType As IStatisticTypeStore, delta As Integer) As ICardTypeStatisticDeltaStore
    ReadOnly Property StatisticDeltas As IRelatedTypeStore(Of ICardTypeStatisticDeltaStore)
    ReadOnly Property AvailableStatisticDeltas As IRelatedTypeStore(Of IStatisticTypeStore)
    ReadOnly Property CanAddStatisticDelta As Boolean
End Interface
