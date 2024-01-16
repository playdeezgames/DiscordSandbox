Public Interface ICharacterTypeStore
    Inherits IBaseTypeStore
    Function CreateCharacter(name As String, location As ILocationStore) As ICharacterStore
    ReadOnly Property Statistics As IRelatedTypeStore(Of ICharacterTypeStatisticStore)
    ReadOnly Property AvailableStatistics As IRelatedTypeStore(Of IStatisticTypeStore)
    ReadOnly Property CanAddStatistic As Boolean
    Function AddStatistic(statisticType As IStatisticTypeStore, statisticValue As Integer) As ICharacterTypeStatisticStore
End Interface
