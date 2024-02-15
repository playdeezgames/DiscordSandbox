Public Interface ICardStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property Character As ICharacterStore
    WriteOnly Property DrawOrder As Integer
    ReadOnly Property InHand As Boolean
    ReadOnly Property SelfDestructs As Boolean
    Sub AddToHand()
    Sub Discard()
    ReadOnly Property LocalEffects As IEnumerable(Of IEffectTypeStore)
    ReadOnly Property CardType As ICardTypeStore
    ReadOnly Property StatisticDeltas As IEnumerable(Of ICardStatisticDeltaStore)
    ReadOnly Property CardTypeGenerators As IEnumerable(Of ICardTypeGeneratorStore)
    ReadOnly Property Destinations As IEnumerable(Of ILocationStore)
    ReadOnly Property HasLocalEffects As Boolean
    ReadOnly Property EffectTypes As IEnumerable(Of IEffectTypeStore)
End Interface
