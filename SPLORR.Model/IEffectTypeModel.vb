Public Interface IEffectTypeModel
    ReadOnly Property Name As String
    ReadOnly Property StatisticDeltas As IEnumerable(Of IEffectTypeStatisticDeltaModel)
End Interface
