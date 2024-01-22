Public Interface ICharacterTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    Function CreateCharacter(name As String, location As ILocationStore) As ICharacterStore
    ReadOnly Property Statistics As IRelatedTypeStore(Of ICharacterTypeStatisticStore)
    ReadOnly Property AvailableStatistics As IRelatedTypeStore(Of IStatisticTypeStore)
    ReadOnly Property CanAddStatistic As Boolean
    Function AddStatistic(statisticType As IStatisticTypeStore, statisticValue As Integer, minimumValue As Integer?, maximumValue As Integer?) As ICharacterTypeStatisticStore
    ReadOnly Property Cards As IRelatedTypeStore(Of ICharacterTypeCardStore)
    ReadOnly Property AvailableCards As IRelatedTypeStore(Of ICardTypeStore)
    ReadOnly Property CanAddCard As Boolean
    Function AddCard(cardType As ICardTypeStore, cardQuantity As Integer) As ICharacterTypeCardStore
End Interface
