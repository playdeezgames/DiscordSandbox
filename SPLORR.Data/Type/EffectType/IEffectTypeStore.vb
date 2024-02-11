Public Interface IEffectTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property Requirements As IEnumerable(Of IEffectTypeStatisticRequirementStore)
    ReadOnly Property StatisticDeltas As IEnumerable(Of IEffectTypeStatisticDeltaStore)
End Interface
