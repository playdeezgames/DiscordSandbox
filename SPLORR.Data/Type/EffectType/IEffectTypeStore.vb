Public Interface IEffectTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property Requirements As IEnumerable(Of IEffectTypeStatisticRequirementStore)
End Interface
