Public Interface IDeckStore
    Inherits IRelatedTypeStore(Of ICardStore)

    ReadOnly Property TopOfDeck As ICardStore
    ReadOnly Property Hand As IEnumerable(Of ICardStore)
    ReadOnly Property DiscardPile As IEnumerable(Of ICardStore)
    Sub AddToDrawPile(card As ICardStore)
    Function HandCardByName(cardName As String) As ICardStore
End Interface
