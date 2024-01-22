Public Interface ICardTypeStore
    Inherits IBaseTypeStore
    Function CreateCard(store As ICharacterStore) As ICardStore
    Function AddStatisticDelta(statisticType As IStatisticTypeStore, delta As Integer) As ICardTypeStatisticDeltaStore
    Function TagExists(tagName As String) As Boolean
    Function CreateTag(tagName As String) As ICardTypeTagStore
    ReadOnly Property StatisticDeltas As IRelatedTypeStore(Of ICardTypeStatisticDeltaStore)
    ReadOnly Property AvailableStatisticDeltas As IRelatedTypeStore(Of IStatisticTypeStore)
    ReadOnly Property CanAddStatisticDelta As Boolean
    ReadOnly Property Tags As IRelatedTypeStore(Of ICardTypeTagStore)
End Interface
