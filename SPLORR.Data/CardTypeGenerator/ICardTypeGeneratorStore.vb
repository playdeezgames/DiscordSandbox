Public Interface ICardTypeGeneratorStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property CardTypes As IRelatedTypeStore(Of ICardTypeGeneratorCardTypeStore)
    ReadOnly Property CanAddCardType As Boolean
    ReadOnly Property AvailableCardTypes As IRelatedTypeStore(Of ICardTypeStore)
    Function AddCardType(cardType As ICardTypeStore, generatorWeight As Integer) As ICardTypeGeneratorCardTypeStore
End Interface
