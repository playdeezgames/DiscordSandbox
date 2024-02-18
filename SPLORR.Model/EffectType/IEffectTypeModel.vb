Imports SPLORR.Data

Public Interface IEffectTypeModel
    ReadOnly Property Store As IEffectTypeStore
    ReadOnly Property Name As String
    ReadOnly Property StatisticDeltas As IEnumerable(Of IEffectTypeStatisticDeltaModel)
    ReadOnly Property Requirements As IEnumerable(Of IEffectTypeStatisticRequirementModel)
    ReadOnly Property LocationType As ILocationTypeModel
    ReadOnly Property Destinations As IEnumerable(Of IEffectTypeDestinationModel)
    ReadOnly Property CardTypeGenerators As IEnumerable(Of IEffectTypeCardTypeGeneratorModel)
    ReadOnly Property RefreshHand As Boolean
End Interface
