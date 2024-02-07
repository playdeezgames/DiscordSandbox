Public Interface ICardStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property Character As ICharacterStore
    WriteOnly Property DrawOrder As Integer
    ReadOnly Property InHand As Boolean
    Sub AddToHand()
    Sub Discard()
    ReadOnly Property CardType As ICardTypeStore
    ReadOnly Property StatisticDeltas As IEnumerable(Of ICardStatisticDeltaStore)
End Interface
