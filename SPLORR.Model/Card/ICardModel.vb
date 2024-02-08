Imports SPLORR.Data

Public Interface ICardModel
    ReadOnly Property Name As String
    ReadOnly Property Store As ICardStore
    ReadOnly Property CanPlay As Boolean
    Sub Play(outputter As Action(Of String))
    ReadOnly Property Character As ICharacterModel
    ReadOnly Property StatisticDeltas As IEnumerable(Of ICardStatisticDeltaModel)
    ReadOnly Property CardTypeGenerators As IEnumerable(Of ICardTypeGeneratorModel)
End Interface
