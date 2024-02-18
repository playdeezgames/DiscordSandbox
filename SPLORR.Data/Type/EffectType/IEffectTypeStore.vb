Public Interface IEffectTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property Requirements As IEnumerable(Of IEffectTypeStatisticRequirementStore)
    ReadOnly Property StatisticDeltas As IEnumerable(Of IEffectTypeStatisticDeltaStore)
    ReadOnly Property LocationType As ILocationTypeStore
    ReadOnly Property Destinations As IEnumerable(Of IEffectTypeDestinationStore)
    ReadOnly Property CardTypeGenerators As IEnumerable(Of IEffectTypeCardTypeGeneratorStore)
    ReadOnly Property RefreshHand As Boolean
End Interface
